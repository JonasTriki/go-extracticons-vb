Imports System.IO

Imports [BYTE] = System.Byte
Imports WORD = System.UInt16
Imports DWORD = System.UInt32
Imports [LONG] = System.Int32

Public Structure ICONIMAGE
    ''' <summary>
    ''' icHeader: DIB format header
    ''' </summary>
    Public Header As BITMAPINFOHEADER
    ''' <summary>
    ''' icColors: Color table
    ''' </summary>
    Public Colors As RGBQUAD()
    ''' <summary>
    ''' icXOR: DIB bits for XOR mask
    ''' </summary>
    Public [XOR] As [BYTE]()
    ''' <summary>
    ''' icAND: DIB bits for AND mask
    ''' </summary>
    Public [AND] As [BYTE]()

    Public Sub Populate(ByVal br As BinaryReader)
        ' read in the header
        Me.Header.Populate(br)
        Me.Colors = New RGBQUAD(Header.biClrUsed - 1) {}
        ' read in the color table
        For i As Integer = 0 To Me.Header.biClrUsed - 1
            Me.Colors(i).Populate(br)
        Next
        ' read in the XOR mask
        Me.[XOR] = br.ReadBytes(numBytesInXor())
        ' read in the AND mask
        Me.[AND] = br.ReadBytes(numBytesInAnd())
    End Sub

    Public Sub Save(ByVal bw As BinaryWriter)
        Header.Save(bw)
        For i As Integer = 0 To Colors.Length - 1
            Colors(i).Save(bw)
        Next
        bw.Write([XOR])
        bw.Write([AND])
    End Sub

#Region "byte count calculation functions"
    Public Function numBytesInXor() As Integer
        ' number of bytes per pixel depends on bitcount
        Dim bytesPerLine As Integer = Convert.ToInt32(Math.Ceiling((Header.biWidth * Header.biBitCount) / 8.0))
        ' If necessary, a scan line must be zero-padded to end on a 32-bit boundary.			
        ' so there will be some padding, if the icon is less than 32 pixels wide
        Dim padding As Integer = (bytesPerLine Mod 4)
        If padding > 0 Then
            bytesPerLine += (4 - padding)
        End If
        Return bytesPerLine * (Header.biHeight >> 1)

    End Function
    Public Function numBytesInAnd() As Integer
        ' each byte can hold 8 pixels (1bpp)
        ' check for a remainder
        Dim bytesPerLine As Integer = Convert.ToInt32(Math.Ceiling(Header.biWidth / 8.0))
        ' If necessary, a scan line must be zero-padded to end on a 32-bit boundary.			
        ' so there will be some padding, if the icon is less than 32 pixels wide
        Dim padding As Integer = (bytesPerLine Mod 4)
        If padding > 0 Then
            bytesPerLine += (4 - padding)
        End If
        Return bytesPerLine * (Header.biHeight >> 1)
    End Function
#End Region
End Structure

Public Structure ICONDIR2
    ''' <summary>
    ''' idReserved: Always 0
    ''' </summary>
    Public Reserved As WORD
    ' Reserved
    ''' <summary>
    ''' idType: Resource type (Always 1 for icons)
    ''' </summary>
    Public ResourceType As WORD
    ''' <summary>
    ''' idCount: Number of images in directory
    ''' </summary>
    Public EntryCount As WORD
    ''' <summary>
    ''' idEntries: Directory entries for each image
    ''' </summary>
    Public Entries As ICONDIRENTRY2()

    Public Sub Save(ByVal bw As BinaryWriter)
        bw.Write(Reserved)
        bw.Write(ResourceType)
        bw.Write(EntryCount)
        For i As Integer = 0 To Entries.Length - 1
            Entries(i).Save(bw)
        Next
    End Sub

    Public Sub Populate(ByVal br As BinaryReader)
        Reserved = br.ReadUInt16()
        ResourceType = br.ReadUInt16()
        EntryCount = br.ReadUInt16()
        Entries = New ICONDIRENTRY2(Me.EntryCount - 1) {}
        For i As Integer = 0 To Entries.Length - 1
            Entries(i).Populate(br)
        Next
    End Sub
End Structure

Public Structure ICONDIRENTRY2
    ''' <summary>
    ''' bWidth: In pixels.  Must be 16, 32, or 64
    ''' </summary>
    Public Width As [BYTE]
    ''' <summary>
    ''' bHeight: In pixels.  Must be 16, 32, or 64
    ''' </summary>
    Public Height As [BYTE]
    ''' <summary>
    ''' bColorCount: Number of colors in image (0 if >=8bpp)
    ''' </summary>
    Public ColorCount As [BYTE]
    ''' <summary>
    ''' bReserved: Must be zero
    ''' </summary>
    Public Reserved As [BYTE]
    ''' <summary>
    ''' wPlanes: Number of color planes in the icon bitmap
    ''' </summary>
    Public Planes As WORD
    ''' <summary>
    ''' wBitCount: Number of bits in each pixel of the icon.  Must be 1,4,8, or 24
    ''' </summary>
    Public BitCount As WORD
    ''' <summary>
    ''' dwBytesInRes: Number of bytes in the resource
    ''' </summary>
    Public BytesInRes As DWORD
    ''' <summary>
    ''' dwImageOffset: Number of bytes from the beginning of the file to the image
    ''' </summary>
    Public ImageOffset As DWORD

    Public Sub Save(ByVal bw As BinaryWriter)
        bw.Write(Width)
        bw.Write(Height)
        bw.Write(ColorCount)
        bw.Write(Reserved)
        bw.Write(Planes)
        bw.Write(BitCount)
        bw.Write(BytesInRes)
        bw.Write(ImageOffset)
    End Sub

    Public Sub Populate(ByVal br As BinaryReader)
        Width = br.ReadByte()
        Height = br.ReadByte()
        ColorCount = br.ReadByte()
        Reserved = br.ReadByte()
        Planes = br.ReadUInt16()
        BitCount = br.ReadUInt16()
        BytesInRes = br.ReadUInt32()
        ImageOffset = br.ReadUInt32()
    End Sub
End Structure


Public Structure BITMAPFILEHEADER
    Public Type As WORD
    Public Size As DWORD
    Public Reserved1 As WORD
    Public Reserved2 As WORD
    Public OffBits As DWORD

    Public Sub Populate(ByVal br As BinaryReader)
        Type = br.ReadUInt16()
        Size = br.ReadUInt32()
        Reserved1 = br.ReadUInt16()
        Reserved2 = br.ReadUInt16()
        OffBits = br.ReadUInt32()
    End Sub

    Public Sub Save(ByVal bw As BinaryWriter)
        bw.Write(Type)
        bw.Write(Size)
        bw.Write(Reserved1)
        bw.Write(Reserved2)
        bw.Write(OffBits)
    End Sub

End Structure
Public Structure BITMAPINFO
    Public infoHeader As BITMAPINFOHEADER
    Public colorMap As RGBQUAD()

    Public Sub Populate(ByVal br As BinaryReader)
        infoHeader.Populate(br)
        colorMap = New RGBQUAD(getNumberOfColors() - 1) {}
        ' read in the color table
        For i As Integer = 0 To colorMap.Length - 1
            colorMap(i).Populate(br)
        Next
    End Sub
    Public Sub Save(ByVal bw As BinaryWriter)
        infoHeader.Save(bw)
        For i As Integer = 0 To colorMap.Length - 1
            colorMap(i).Save(bw)
        Next
    End Sub

    Private Function getNumberOfColors() As UInteger
        If infoHeader.biClrUsed > 0 Then
            ' number of colors is specified
            Return infoHeader.biClrUsed
        Else
            ' number of colors is based on the bitcount
            Select Case infoHeader.biBitCount
                Case 1
                    Return 2
                Case 4
                    Return 16
                Case 8
                    Return 256
                Case Else
                    Return 0
            End Select
        End If
    End Function
End Structure

''' <summary>
''' Describes the format of the bitmap image
''' </summary>
''' <remarks>
''' BITMAPHEADERINFO struct
''' referenced by http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnwui/html/msdn_icons.asp
''' defined by http://www.whisqu.se/per/docs/graphics52.htm
''' Only the following members are used: biSize, biWidth, biHeight, biPlanes, biBitCount, biSizeImage. All other members must be 0. The biHeight member specifies the combined height of the XOR and AND masks. The members of icHeader define the contents and sizes of the other elements of the ICONIMAGE structure in the same way that the BITMAPINFOHEADER structure defines a CF_DIB format DIB
''' </remarks>
Public Structure BITMAPINFOHEADER
    Public Const Size As Integer = 40
    Public biSize As DWORD
    Public biWidth As [LONG]
    ''' <summary>
    ''' Height of bitmap.  For icons, this is the height of XOR and AND masks together. Divide by 2 to get true height.
    ''' </summary>
    Public biHeight As [LONG]
    Public biPlanes As WORD
    Public biBitCount As WORD
    Public biCompression As DWORD
    Public biSizeImage As DWORD
    Public biXPelsPerMeter As [LONG]
    Public biYPelsPerMeter As [LONG]
    Public biClrUsed As DWORD
    Public biClrImportant As DWORD

    Public Sub Save(ByVal bw As BinaryWriter)
        bw.Write(biSize)
        bw.Write(biWidth)
        bw.Write(biHeight)
        bw.Write(biPlanes)
        bw.Write(biBitCount)
        bw.Write(biCompression)
        bw.Write(biSizeImage)
        bw.Write(biXPelsPerMeter)
        bw.Write(biYPelsPerMeter)
        bw.Write(biClrUsed)
        bw.Write(biClrImportant)
    End Sub

    Public Sub Populate(ByVal br As BinaryReader)
        biSize = br.ReadUInt32()
        biWidth = br.ReadInt32()
        biHeight = br.ReadInt32()
        biPlanes = br.ReadUInt16()
        biBitCount = br.ReadUInt16()
        biCompression = br.ReadUInt32()
        biSizeImage = br.ReadUInt32()
        biXPelsPerMeter = br.ReadInt32()
        biYPelsPerMeter = br.ReadInt32()
        biClrUsed = br.ReadUInt32()
        biClrImportant = br.ReadUInt32()
    End Sub
End Structure

' RGBQUAD structure changed by Pavel Janda on 14/11/2006
Public Structure RGBQUAD
    Public Const Size As Integer = 4
    Public blue As [BYTE]
    Public green As [BYTE]
    Public red As [BYTE]
    Public alpha As [BYTE]

    Public Sub New(ByVal bgr As [BYTE]())
        Me.New(bgr(0), bgr(1), bgr(2))
    End Sub

    Public Sub New(ByVal blue As [BYTE], ByVal green As [BYTE], ByVal red As [BYTE])
        Me.blue = blue
        Me.green = green
        Me.red = red
        Me.alpha = 0
    End Sub

    Public Sub New(ByVal blue As [BYTE], ByVal green As [BYTE], ByVal red As [BYTE], ByVal alpha As [BYTE])
        Me.blue = blue
        Me.green = green
        Me.red = red
        Me.alpha = alpha
    End Sub

    Public Sub Save(ByVal bw As BinaryWriter)
        bw.BaseStream.WriteByte(blue)
        bw.BaseStream.WriteByte(green)
        bw.BaseStream.WriteByte(red)
        bw.BaseStream.WriteByte(alpha)
    End Sub

    Public Sub Populate(ByVal br As BinaryReader)
        blue = br.ReadByte()
        green = br.ReadByte()
        red = br.ReadByte()
        alpha = br.ReadByte()
    End Sub
End Structure