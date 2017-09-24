Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class GrayScaleConverter

''' <summary>
    ''' Converts an image to grayscale
    ''' </summary>
    ''' <param name="inputImage">The image to be converted.</param>
    ''' <returns>Return's the input image, but with grayscale</returns>
    ''' <remarks></remarks>
    <Description("Converts an image to grayscale.")> _
    Public Shared Function ColorImageToGrayScaleImage(ByVal inputImage As Image) As Image

        Dim bmp As New Bitmap(inputImage)
        Dim bmpData As BitmapData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, inputImage.PixelFormat)
        Dim pixelBytes As Integer = Image.GetPixelFormatSize(inputImage.PixelFormat) / 8

        Dim ptr As IntPtr = bmpData.Scan0
        Dim size As Integer = bmpData.Stride * bmp.Height
        Dim pixels As Byte() = New Byte(size - 1) {}
        Dim index As Integer = 0
        Dim Y As Integer = 0
        Dim mulR As Double = 0.2126
        Dim mulG As Double = 0.7152
        Dim mulB As Double = 0.0722

        Marshal.Copy(ptr, pixels, 0, size)

        For row As Integer = 0 To bmp.Height - 1

            For col As Integer = 0 To bmp.Width - 1
                index = (row * bmpData.Stride) + (col * pixelBytes)

                Y = Convert.ToInt32(Math.Round(mulR * pixels(index + 2) + mulG * pixels(index + 1) + mulB * pixels(index + 0)))
                If (Y > 255) Then Y = 255

                pixels(index + 2) = Convert.ToByte(Y)
                pixels(index + 1) = Convert.ToByte(Y)
                pixels(index + 0) = Convert.ToByte(Y)

            Next
        Next

        Marshal.Copy(pixels, 0, ptr, size)
        bmp.UnlockBits(bmpData)

        Return bmp

    End Function
End Class
