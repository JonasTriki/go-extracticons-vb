Imports System.IO
Imports System.Collections
Imports System.Drawing

''' <summary>
''' Provides methods for converting between the bitmap and icon formats
''' </summary>
Public Class Converter
    Private Sub New()
    End Sub
    Public Shared Function BitmapToIcon(ByVal b As Bitmap) As Icon
        Dim ico As IconHolder = BitmapToIconHolder(b)
        Dim newIcon As Icon
        Using bw As New BinaryWriter(New MemoryStream())
            ico.Save(bw)
            bw.BaseStream.Position = 0
            newIcon = New Icon(bw.BaseStream)
        End Using
        Return newIcon
    End Function

    Public Shared Function BitmapToIconHolder(ByVal b As Bitmap) As IconHolder
        Dim bmp As New BitmapHolder()


        Using stream As New MemoryStream()
            b.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)
            stream.Position = 0
            bmp.Open(stream)
        End Using
        Return BitmapToIconHolder(bmp)
    End Function

    Public Shared Function BitmapToIconHolder(ByVal bmp As BitmapHolder) As IconHolder
        Dim mapColors As Boolean = (bmp.info.infoHeader.biBitCount <= 24)
        Dim maximumColors As Integer = 1 << bmp.info.infoHeader.biBitCount
        'Hashtable uniqueColors = new Hashtable(maximumColors);
        ' actual colors is probably nowhere near maximum, so dont try to initialize the hashtable
        Dim uniqueColors As New Hashtable()

        Dim sourcePosition As Integer = 0
        Dim numPixels As Integer = bmp.info.infoHeader.biHeight * bmp.info.infoHeader.biWidth
        Dim indexedImage As Byte() = New Byte(numPixels - 1) {}
        Dim colorIndex As Byte

        If mapColors Then
            For i As Integer = 0 To indexedImage.Length - 1
                'TODO: currently assumes source bitmap is 24bit color
                'read 3 bytes, convert to color
                Dim pixel As Byte() = New Byte(2) {}
                Array.Copy(bmp.imageData, sourcePosition, pixel, 0, 3)
                sourcePosition += 3

                Dim color As New RGBQUAD(pixel)
                If uniqueColors.Contains(color) Then
                    colorIndex = Convert.ToByte(uniqueColors(color))
                Else
                    If uniqueColors.Count > Byte.MaxValue Then
                        Throw New NotSupportedException([String].Format("The source image contains more than {0} colors.", Byte.MaxValue))
                    End If
                    colorIndex = Convert.ToByte(uniqueColors.Count)
                    uniqueColors.Add(color, colorIndex)
                End If
                ' store pixel as an index into the color table
                indexedImage(i) = colorIndex
            Next
        Else
            ' added by Pavel Janda on 14/11/2006
            If bmp.info.infoHeader.biBitCount = 32 Then
                For i As Integer = 0 To indexedImage.Length - 1
                    'TODO: currently assumes source bitmap is 32bit color with alpha set to zero
                    'ignore first byte, read another 3 bytes, convert to color
                    Dim pixel As Byte() = New Byte(3) {}
                    Array.Copy(bmp.imageData, sourcePosition, pixel, 0, 4)
                    sourcePosition += 4

                    Dim color As New RGBQUAD(pixel(0), pixel(1), pixel(2), pixel(3))
                    If uniqueColors.Contains(color) Then
                        colorIndex = Convert.ToByte(uniqueColors(color))
                    Else
                        If uniqueColors.Count > Byte.MaxValue Then
                            Throw New NotSupportedException([String].Format("The source image contains more than {0} colors.", Byte.MaxValue))
                        End If
                        colorIndex = Convert.ToByte(uniqueColors.Count)
                        uniqueColors.Add(color, colorIndex)
                    End If
                    ' store pixel as an index into the color table
                    indexedImage(i) = colorIndex
                    ' end of addition
                Next
            Else
                'TODO: implement converting an indexed bitmap
                Throw New NotImplementedException("Unable to convert indexed bitmaps.")
            End If
        End If

        Dim bitCount As UShort = getBitCount(uniqueColors.Count)
        ' *** Build Icon ***
        Dim ico As New IconHolder()
        ico.iconDirectory.Entries = New ICONDIRENTRY2(0) {}
        'TODO: is it really safe to assume the bitmap width/height are bytes?
        ico.iconDirectory.Entries(0).Width = bmp.info.infoHeader.biWidth
        ico.iconDirectory.Entries(0).Height = bmp.info.infoHeader.biHeight
        ico.iconDirectory.Entries(0).BitCount = bitCount
        ' maybe 0?
        ico.iconDirectory.Entries(0).ColorCount = If((uniqueColors.Count > Byte.MaxValue), CByte(0), CByte(uniqueColors.Count))
        'HACK: safe to assume that the first imageoffset is always 22
        ico.iconDirectory.Entries(0).ImageOffset = 22
        ico.iconDirectory.Entries(0).Planes = 0
        ico.iconImages(0).Header.biBitCount = bitCount
        ico.iconImages(0).Header.biWidth = ico.iconDirectory.Entries(0).Width
        ' height is doubled in header, to account for XOR and AND
        ico.iconImages(0).Header.biHeight = ico.iconDirectory.Entries(0).Height << 1
        ico.iconImages(0).[XOR] = New Byte(ico.iconImages(0).numBytesInXor() - 1) {}
        ico.iconImages(0).[AND] = New Byte(ico.iconImages(0).numBytesInAnd() - 1) {}
        ico.iconImages(0).Header.biSize = 40
        ' always
        ico.iconImages(0).Header.biSizeImage = CUInt(ico.iconImages(0).[XOR].Length)
        ico.iconImages(0).Header.biPlanes = 1
        ico.iconImages(0).Colors = buildColorTable(uniqueColors, bitCount)
        'BytesInRes = biSize + colors * 4 + XOR + AND
        ico.iconDirectory.Entries(0).BytesInRes = CUInt(ico.iconImages(0).Header.biSize + (ico.iconImages(0).Colors.Length * 4) + ico.iconImages(0).[XOR].Length + ico.iconImages(0).[AND].Length)

        ' copy image data
        Dim bytePosXOR As Integer = 0
        Dim bytePosAND As Integer = 0
        Dim transparentIndex As Byte = 0
        transparentIndex = indexedImage(0)
        'initialize AND
        ico.iconImages(0).[AND](0) = Byte.MaxValue

        Dim pixelsPerByte As Integer
        Dim bytesPerRow As Integer
        ' must be a long boundary (multiple of 4)
        Dim shiftCounts As Integer()

        Select Case bitCount
            Case 1
                pixelsPerByte = 8
                shiftCounts = New Integer() {7, 6, 5, 4, 3, 2, _
                 1, 0}
                Exit Select
            Case 4
                pixelsPerByte = 2
                shiftCounts = New Integer() {4, 0}
                Exit Select
            Case 8
                pixelsPerByte = 1
                shiftCounts = New Integer() {0}
                Exit Select
            Case Else
                Throw New NotSupportedException("Bits per pixel must be 1, 4, or 8")
        End Select
        bytesPerRow = ico.iconDirectory.Entries(0).Width / pixelsPerByte
        Dim padBytes As Integer = bytesPerRow Mod 4
        If padBytes > 0 Then
            padBytes = 4 - padBytes
        End If

        Dim currentByte As Byte
        sourcePosition = 0
        For row As Integer = 0 To ico.iconDirectory.Entries(0).Height - 1
            For rowByte As Integer = 0 To bytesPerRow - 1
                currentByte = 0
                For pixel As Integer = 0 To pixelsPerByte - 1
                    Dim index As Byte = indexedImage(System.Math.Max(System.Threading.Interlocked.Increment(sourcePosition), sourcePosition - 1))
                    Dim shiftedIndex As Byte = CByte(index << shiftCounts(pixel))
                    currentByte = currentByte Or shiftedIndex
                Next
                ico.iconImages(0).[XOR](bytePosXOR) = currentByte
                bytePosXOR += 1
            Next
            ' make sure each scan line ends on a long boundary
            bytePosXOR += padBytes
        Next

        For i As Integer = 0 To indexedImage.Length - 1
            Dim index As Byte = indexedImage(i)
            Dim bitPosAND As Integer = 128 >> (i Mod 8)
            If index <> transparentIndex Then
                ico.iconImages(0).[AND](bytePosAND) = ico.iconImages(0).[AND](bytePosAND) Xor CByte(bitPosAND)
            End If
            If bitPosAND = 1 Then
                ' need to start another byte for next pixel
                If bytePosAND Mod 2 = 1 Then
                    'TODO: fix assumption that icon is 16px wide
                    'skip some bytes so that scanline ends on a long barrier
                    bytePosAND += 3
                Else
                    bytePosAND += 1
                End If
                If bytePosAND < ico.iconImages(0).[AND].Length Then
                    ico.iconImages(0).[AND](bytePosAND) = Byte.MaxValue
                End If
            End If
        Next
        Return ico
    End Function

    Private Shared Function getBitCount(ByVal uniqueColorCount As Integer) As UShort
        If uniqueColorCount <= 2 Then
            Return 1
        End If
        If uniqueColorCount <= 16 Then
            Return 4
        End If
        If uniqueColorCount <= 256 Then
            Return 8
        End If
        Return 24
    End Function

    Private Shared Function buildColorTable(ByVal colors As Hashtable, ByVal bpp As UShort) As RGBQUAD()
        'RGBQUAD[] colorTable = new RGBQUAD[colors.Count];
        'HACK: it looks like the color array needs to be the max size based on bitcount
        Dim numColors As Integer = 1 << bpp
        Dim colorTable As RGBQUAD() = New RGBQUAD(numColors - 1) {}
        For Each color As RGBQUAD In colors.Keys
            Dim colorIndex As Integer = Convert.ToInt32(colors(color))
            colorTable(colorIndex) = color
        Next
        Return colorTable
    End Function
End Class