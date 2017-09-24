Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.IO

#Region "Enumuration"
'[Flags]
Public Enum IconFlags As Integer
    Icon = &H100
    ' get icon
    LinkOverlay = &H8000
    ' put a link overlay on icon
    Selected = &H10000
    ' show icon in selected state
    LargeIcon = &H0
    ' get large icon
    SmallIcon = &H1
    ' get small icon
    OpenIcon = &H2
    ' get open icon
    ShellIconSize = &H4
    ' get shell size icon
End Enum
#End Region

''' <summary>
''' Contains helper function to help dealing with System.Drawing.Icon.
''' </summary>
Public NotInheritable Class IconHelper
    Private Sub New()
    End Sub
#Region "Public Methods"
    ''' <summary>
    ''' Returns TAFactory.IconPack.IconInfo object that holds the information about the icon.
    ''' </summary>
    ''' <param name="icon">System.Drawing.Icon to get the information about.</param>
    ''' <returns>TAFactory.IconPack.IconInfo object that holds the information about the icon.</returns>
    Public Shared Function GetIconInfo(ByVal icon As Icon) As IconInfo
        Return New IconInfo(icon)
    End Function
    ''' <summary>
    ''' Returns TAFactory.IconPack.IconInfo object that holds the information about the icon.
    ''' </summary>
    ''' <param name="fileName">The icon file path.</param>
    ''' <returns>TAFactory.IconPack.IconInfo object that holds the information about the icon.</returns>
    Public Shared Function GetIconInfo(ByVal fileName As String) As IconInfo
        Return New IconInfo(fileName)
    End Function

    ''' <summary>
    ''' Extracts an icon from a givin icon file or an executable module (.dll or an .exe file).
    ''' </summary>
    ''' <param name="fileName">The path of the icon file or the executable module.</param>
    ''' <param name="iconIndex">The index of the icon in the executable module.</param>
    ''' <returns>A System.Drawing.Icon extracted from the file at the specified index in case of an executable module.</returns>
    Public Shared Function ExtractIcon(ByVal fileName As String, ByVal iconIndex As Integer) As Icon
        Dim icon As Icon = Nothing
        'Try to load the file as icon file.
        Try
            icon = New Icon(Environment.ExpandEnvironmentVariables(fileName))
        Catch
        End Try

        If icon IsNot Nothing Then
            'The file was an icon file, return the icon.
            Return icon
        End If

        'Load the file as an executable module.
        Using extractor As New IconExtractor(fileName)
            Return extractor.GetIconAt(iconIndex)
        End Using
    End Function

    ''' <summary>
    ''' Extracts all the icons from a givin icon file or an executable module (.dll or an .exe file).
    ''' </summary>
    ''' <param name="fileName">The path of the icon file or the executable module.</param>
    ''' <returns>
    ''' A list of System.Drawing.Icon found in the file.
    ''' If the file was an icon file, it will return a list containing a single icon.
    ''' </returns>
    Public Shared Function ExtractAllIcons(ByVal fileName As String) As List(Of Icon)
        Dim icon As Icon = Nothing
        Dim list As New List(Of Icon)()
        'Try to load the file as icon file.
        Try
            icon = New Icon(Environment.ExpandEnvironmentVariables(fileName))
        Catch
        End Try

        If icon IsNot Nothing Then
            'The file was an icon file.
            list.Add(icon)
            Return list
        End If

        'Load the file as an executable module.
        Using extractor As New IconExtractor(fileName)
            For i As Integer = 0 To extractor.IconCount - 1
                list.Add(extractor.GetIconAt(i))
                Application.DoEvents()
            Next
        End Using

        'This is just a test...
        'Load the file as an executable module.
        'Using extractor As New CursorExtractor(fileName)
        ' For i As Integer = 0 To extractor.CursorCount - 1
        '        MsgBox(extractor.CursorCount)
        '       MsgBox(extractor.GetIconAt(i).cursor.HotSpot.Y)
        '      MsgBox(extractor.GetIconAt(i).cursor.HotSpot.X)
        '    MsgBox(extractor.GetIconAt(i).cursor.Size.Height)
        '   MsgBox(extractor.GetIconAt(i).cursor.Size.Width)
        '  frmMain.FastPanel.Cursor = extractor.GetIconAt(i).cursor
        ' Application.DoEvents()
        ' Next
        'End Using

        Return list
    End Function

    ''' <summary>
    ''' Splits the group icon into a list of icons (the single icon file can contain a set of icons).
    ''' </summary>
    ''' <param name="icon">The System.Drawing.Icon need to be splitted.</param>
    ''' <returns>List of System.Drawing.Icon.</returns>
    Public Shared Function SplitGroupIcon(ByVal icon As Icon) As List(Of Icon)
        Dim info As New IconInfo(icon)
        Return info.Images
    End Function

    ''' <summary>
    ''' Gets the System.Drawing.Icon that best fits the current display device.
    ''' </summary>
    ''' <param name="icon">System.Drawing.Icon to be searched.</param>
    ''' <returns>System.Drawing.Icon that best fit the current display device.</returns>
    Public Shared Function GetBestFitIcon(ByVal icon As Icon) As Icon
        Dim info As New IconInfo(icon)
        Dim index As Integer = info.GetBestFitIconIndex()
        Return info.Images(index)
    End Function
    ''' <summary>
    ''' Gets the System.Drawing.Icon that best fits the current display device.
    ''' </summary>
    ''' <param name="icon">System.Drawing.Icon to be searched.</param>
    ''' <param name="desiredSize">Specifies the desired size of the icon.</param>
    ''' <returns>System.Drawing.Icon that best fit the current display device.</returns>
    Public Shared Function GetBestFitIcon(ByVal icon As Icon, ByVal desiredSize As Size) As Icon
        Dim info As New IconInfo(icon)
        Dim index As Integer = info.GetBestFitIconIndex(desiredSize)
        Return info.Images(index)
    End Function
    ''' <summary>
    ''' Gets the System.Drawing.Icon that best fits the current display device.
    ''' </summary>
    ''' <param name="icon">System.Drawing.Icon to be searched.</param>
    ''' <param name="desiredSize">Specifies the desired size of the icon.</param>
    ''' <param name="isMonochrome">Specifies whether to get the monochrome icon or the colored one.</param>
    ''' <returns>System.Drawing.Icon that best fit the current display device.</returns>
    Public Shared Function GetBestFitIcon(ByVal icon As Icon, ByVal desiredSize As Size, ByVal isMonochrome As Boolean) As Icon
        Dim info As New IconInfo(icon)
        Dim index As Integer = info.GetBestFitIconIndex(desiredSize, isMonochrome)
        Return info.Images(index)
    End Function

    ''' <summary>
    ''' Extracts an icon (that best fits the current display device) from a givin icon file or an executable module (.dll or an .exe file).
    ''' </summary>
    ''' <param name="fileName">The path of the icon file or the executable module.</param>
    ''' <param name="iconIndex">The index of the icon in the executable module.</param>
    ''' <returns>A System.Drawing.Icon (that best fits the current display device) extracted from the file at the specified index in case of an executable module.</returns>
    Public Shared Function ExtractBestFitIcon(ByVal fileName As String, ByVal iconIndex As Integer) As Icon
        Dim icon As Icon = ExtractIcon(fileName, iconIndex)
        Return GetBestFitIcon(icon)
    End Function
    ''' <summary>
    ''' Extracts an icon (that best fits the current display device) from a givin icon file or an executable module (.dll or an .exe file).
    ''' </summary>
    ''' <param name="fileName">The path of the icon file or the executable module.</param>
    ''' <param name="iconIndex">The index of the icon in the executable module.</param>
    ''' <param name="desiredSize">Specifies the desired size of the icon.</param>
    ''' <returns>A System.Drawing.Icon (that best fits the current display device) extracted from the file at the specified index in case of an executable module.</returns>
    Public Shared Function ExtractBestFitIcon(ByVal fileName As String, ByVal iconIndex As Integer, ByVal desiredSize As Size) As Icon
        Dim icon As Icon = ExtractIcon(fileName, iconIndex)
        Return GetBestFitIcon(icon, desiredSize)
    End Function
    ''' <summary>
    ''' Extracts an icon (that best fits the current display device) from a givin icon file or an executable module (.dll or an .exe file).
    ''' </summary>
    ''' <param name="fileName">The path of the icon file or the executable module.</param>
    ''' <param name="iconIndex">The index of the icon in the executable module.</param>
    ''' <param name="desiredSize">Specifies the desired size of the icon.</param>
    ''' <param name="isMonochrome">Specifies whether to get the monochrome icon or the colored one.</param>
    ''' <returns>A System.Drawing.Icon (that best fits the current display device) extracted from the file at the specified index in case of an executable module.</returns>
    Public Shared Function ExtractBestFitIcon(ByVal fileName As String, ByVal iconIndex As Integer, ByVal desiredSize As Size, ByVal isMonochrome As Boolean) As Icon
        Dim icon As Icon = ExtractIcon(fileName, iconIndex)
        Return GetBestFitIcon(icon, desiredSize, isMonochrome)
    End Function

    ''' <summary>
    ''' Gets icon associated with the givin file.
    ''' </summary>
    ''' <param name="fileName">The file path (both absolute and relative paths are valid).</param>
    ''' <param name="flags">Specifies which icon to be retrieved (Larg, Small, Selected, Link Overlay and Shell Size).</param>
    ''' <returns>A System.Drawing.Icon associated with the givin file.</returns>
    Public Shared Function GetAssociatedIcon(ByVal fileName As String, ByVal flags As IconFlags) As Icon
        flags = flags Or IconFlags.Icon
        Dim fileInfo As New SHFILEINFO()
        Dim result As IntPtr = Win32.SHGetFileInfo(fileName, 0, fileInfo, CUInt(Marshal.SizeOf(fileInfo)), DirectCast(flags, SHGetFileInfoFlags))

        If fileInfo.hIcon = IntPtr.Zero Then
            Return Nothing
        End If

        Return Icon.FromHandle(fileInfo.hIcon)
    End Function
    ''' <summary>
    ''' Gets large icon associated with the givin file.
    ''' </summary>
    ''' <param name="fileName">The file path (both absolute and relative paths are valid).</param>
    ''' <returns>A System.Drawing.Icon associated with the givin file.</returns>
    Public Shared Function GetAssociatedLargeIcon(ByVal fileName As String) As Icon
        Return GetAssociatedIcon(fileName, IconFlags.LargeIcon)
    End Function
    ''' <summary>
    ''' Gets small icon associated with the givin file.
    ''' </summary>
    ''' <param name="fileName">The file path (both absolute and relative paths are valid).</param>
    ''' <returns>A System.Drawing.Icon associated with the givin file.</returns>
    Public Shared Function GetAssociatedSmallIcon(ByVal fileName As String) As Icon
        Return GetAssociatedIcon(fileName, IconFlags.SmallIcon)
    End Function

    ''' <summary>
    ''' Merges a list of icons into one single icon.
    ''' </summary>
    ''' <param name="icons">The icons to be merged.</param>
    ''' <returns>System.Drawing.Icon that contains all the images of the giving icons.</returns>
    Public Shared Function Merge(ByVal icons As List(Of Icon)) As Icon
        Dim list As New List(Of IconInfo)(icons.Count)
        Dim numImages As Integer = 0
        For Each icon As Icon In icons
            If icon IsNot Nothing Then
                Dim info As New IconInfo(icon)
                list.Add(info)
                numImages += info.Images.Count
            End If
            Application.DoEvents()
        Next
        If list.Count = 0 Then
            frmMain.ShowError(frmMain.Errors.TheIconsListShoudContainAtLeastOneIcon)
            Return Nothing
            Exit Function
        End If

        'Write the icon to a stream.
        Dim outputStream As New MemoryStream()
        Dim imageIndex As Integer = 0
        Dim imageOffset As Integer = IconInfo.SizeOfIconDir + numImages * IconInfo.SizeOfIconDirEntry
        For i As Integer = 0 To list.Count - 1
            Dim iconInfo__1 As IconInfo = list(i)
            'The firs image, we should write the icon header.
            If i = 0 Then
                'Get the IconDir and update image count with the new count.
                Dim dir As IconDir = iconInfo__1.IconDir
                dir.Count = CShort(numImages)

                'Write the IconDir header.
                outputStream.Seek(0, SeekOrigin.Begin)
                Utility.WriteStructure(Of IconDir)(outputStream, dir)
            End If
            'For each image in the current icon, we should write the IconDirEntry and the image raw data.
            For j As Integer = 0 To iconInfo__1.Images.Count - 1
                'Get the IconDirEntry and update the ImageOffset to the new offset.
                Dim entry As IconDirEntry = iconInfo__1.IconDirEntries(j)
                entry.ImageOffset = imageOffset

                'Write the IconDirEntry to the stream.
                outputStream.Seek(IconInfo.SizeOfIconDir + imageIndex * IconInfo.SizeOfIconDirEntry, SeekOrigin.Begin)
                Utility.WriteStructure(Of IconDirEntry)(outputStream, entry)

                'Write the image raw data.
                outputStream.Seek(imageOffset, SeekOrigin.Begin)
                outputStream.Write(iconInfo__1.RawData(j), 0, entry.BytesInRes)

                'Update the imageIndex and the imageOffset
                imageIndex += 1
                imageOffset += entry.BytesInRes
            Next
            Application.DoEvents()
        Next

        'Create the icon from the stream.
        outputStream.Seek(0, SeekOrigin.Begin)
        Dim resultIcon As New Icon(outputStream)
        outputStream.Close()

        Return resultIcon
    End Function

    Public Shared Function GetIconSize(ByVal Icon As Icon) As Byte()

        If Not IsNothing(Icon) Then

            Dim stream As New MemoryStream : Icon.Save(stream)

            Return stream.GetBuffer
        Else
            Return New Byte() {0}
        End If

    End Function

    Public Shared Function ChangeColorDepthOfBitmap(ByVal b As Bitmap, ByVal ColorDepthToChangeTo As ColorDepth) As Bitmap

        Dim bmp As Bitmap = Nothing

        If ColorDepthToChangeTo = ColorDepth.Depth4Bit Then
            bmp = New Bitmap(b.Width, b.Height, Imaging.PixelFormat.Format4bppIndexed)
        ElseIf ColorDepthToChangeTo = ColorDepth.Depth8Bit Then
            bmp = New Bitmap(b.Width, b.Height, Imaging.PixelFormat.Format64bppPArgb)
        ElseIf ColorDepthToChangeTo = ColorDepth.Depth16Bit Then
            bmp = New Bitmap(b.Width, b.Height, Imaging.PixelFormat.Format16bppRgb565)
        ElseIf ColorDepthToChangeTo = ColorDepth.Depth24Bit Then
            bmp = New Bitmap(b.Width, b.Height, Imaging.PixelFormat.Format24bppRgb)
        ElseIf ColorDepthToChangeTo = ColorDepth.Depth32Bit Then
            bmp = New Bitmap(b.Width, b.Height, Imaging.PixelFormat.Format32bppArgb)
        End If

        Dim g As Graphics = Graphics.FromImage(bmp)

        g.DrawImage(b, New Rectangle(0, 0, b.Width, b.Height))

        Return bmp

    End Function

    ''' <summary>
    ''' Changes the icon color depth of an Icon.
    ''' </summary>
    ''' <param name="Icon">The icon to be converted.</param>
    ''' <param name="ColorDepthToChangeTo">The color depth to change to.</param>
    ''' <returns>The input icon, but with a different color depth.</returns>
    Public Shared Function ChangeIconColorDepth(ByVal Icon As Icon, ByVal ColorDepthToChangeTo As ColorDepth) As Icon

        Try
            If Not IsNothing(Icon) Then
                If Not New IconInfo(Icon).ColorDepth = ColorDepthToChangeTo Then

                    Dim stream As New MemoryStream
                    Dim writer As New BinaryWriter(stream)
                    Dim imageData As New Dictionary(Of Integer, Byte())()

                    ' Write the icon file header.
                    writer.Write(CUShort(0))
                    ' must be 0
                    writer.Write(CUShort(1))
                    ' 1 = ico file
                    writer.Write(CUShort(1))
                    ' number of sizes

                    Dim data As Byte() = GetIconSize(Icon.FromHandle(ChangeColorDepthOfBitmap(Icon.ToBitmap, ColorDepthToChangeTo).GetHicon))
                    imageData.Add(Icon.Width, Data)

                    writer.Write(CByte(Icon.Width))
                    ' width
                    writer.Write(CByte(Icon.Height))
                    ' height
                    writer.Write(CByte(DirectCast(IIf(2 ^ ColorDepthToChangeTo >= 256, 0, 1), Integer)))
                    ' colors, 0 = more than 256
                    writer.Write(CByte(0))
                    ' must be 0
                    writer.Write(CUShort(0))
                    ' color planes, should be 0 or 1
                    writer.Write(CUShort(ColorDepthToChangeTo))
                    ' bits per pixel
                    writer.Write(Data.Length)
                    ' size of bitmap data in bytes
                    writer.Write(22)
                    ' bitmap data offset in file

                    Dim sortedData = From i In imageData Order By i.Key Select i.Value

                    For Each sData As Byte() In sortedData
                        writer.Write(sData)
                    Next

                    Return New Icon(stream)

                Else
                    Return Icon
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Icon
        End Try

    End Function

    Public Shared Function ImagePixelsToIconPixels(ByVal Img As Image) As Icon

        Try
            Dim newImg As New Bitmap(Img.Width, Img.Height, Imaging.PixelFormat.Format32bppArgb)
            Dim g As Graphics = Graphics.FromImage(newImg)

            For x As Integer = 0 To Img.Width - 1
                For y As Integer = 0 To Img.Height - 1
                    If Not DirectCast(Img, Bitmap).GetPixel(x, y) = Color.Transparent Then
                        MsgBox(x & " : " & y)
                        g.DrawRectangle(New Pen(DirectCast(Img, Bitmap).GetPixel(x, y), 1), New Rectangle(x, y, 1, 1))
                    End If
                Next
            Next

            Return Icon.FromHandle(newImg.GetHicon())
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Converts an image to an icon.
    ''' </summary>
    ''' <param name="Image">The image to be converted.</param>
    ''' <returns>System.Drawing.Icon from an image.</returns>
    Public Shared Function ConvertImageToIcon(ByVal Image As Image) As Icon

        Dim SquareBmb As New Bitmap(Image.Width, Image.Height, Imaging.PixelFormat.Format32bppArgb)
        Dim g As Graphics = Graphics.FromImage(SquareBmb)

        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic

        g.DrawImage(Image, 0, 0, Image.Width, Image.Height)
        g.Flush()

        Return Converter.BitmapToIcon(SquareBmb)

    End Function

    ''' <summary>
    ''' Converts an image to an icon.
    ''' </summary>
    ''' <param name="FileName">The filename to the image.</param>
    ''' <returns>System.Drawing.Icon from an image.</returns>
    Public Shared Function ConvertImageToIcon(ByVal FileName As String) As Icon

        Dim SquareBmb As New Bitmap(Image.FromFile(FileName).Width, Image.FromFile(FileName).Height, Imaging.PixelFormat.Format32bppArgb)
        Dim g As Graphics = Graphics.FromImage(SquareBmb)

        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic

        g.DrawImage(Image.FromFile(FileName), 0, 0, Image.FromFile(FileName).Width, Image.FromFile(FileName).Height)
        g.Flush()

        Return Converter.BitmapToIcon(SquareBmb)

    End Function

#End Region
End Class