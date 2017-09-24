Imports System.IO
Imports System.ComponentModel
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Drawing.Imaging

Public Class IconConverter

    Public Shared Function IconToImage(ByVal Icon As Icon) As Image
        Return Icon.ToBitmap
    End Function

    Public Shared Function ImageToIcon(ByVal FileName As String) As Icon

        Dim fs As New FileStream(FileName, FileMode.Open, FileAccess.Read)

        Dim IconF As New IconFile

        Dim decoder = BitmapDecoder.Create(fs, BitmapCreateOptions.None, BitmapCacheOption.None)

        If decoder.Frames.Count > 0 Then IconF.Images.Add(decoder.Frames(0))

        Return IconF.ToIcon()

    End Function

    Public Shared Function ImageToIcon(ByVal Image As Image) As Icon

        Try
            Dim ImageS As New MemoryStream() : Image.Save(ImageS, System.Drawing.Imaging.ImageFormat.Png)
            Dim IconF As New IconFile

            Dim decoder = BitmapDecoder.Create(ImageS, BitmapCreateOptions.None, BitmapCacheOption.Default)

            If decoder.Frames.Count > 0 Then IconF.Images.Add(decoder.Frames(0))

            Return IconF.ToIcon()
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

End Class
