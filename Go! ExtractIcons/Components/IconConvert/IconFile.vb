Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Windows.Media.Imaging

''' <summary>
''' Represents a Windows icon file.
''' </summary>
Public NotInheritable Class IconFile
#Region "Private Fields"
    ''' <summary>
    ''' Stores the images in the icon.
    ''' </summary>
    Private ReadOnly m_images As New IconImageCollection()
#End Region

#Region "Constructors"
    ''' <summary>
    ''' Initializes a new instance of the IconFile class.
    ''' </summary>
    Public Sub New()
    End Sub
#End Region

#Region "Public Properties"
    ''' <summary>
    ''' Gets the images contained in the icon.
    ''' </summary>
    Public ReadOnly Property Images() As IconImageCollection
        Get
            Return Me.m_images
        End Get
    End Property
#End Region

#Region "Public Methods"
    ''' <summary>
    ''' Saves the icon to a file.
    ''' </summary>
    ''' <param name="fileName">Name of file.</param>
    Public Function Save(ByVal fileName As String) As Boolean
        If fileName Is Nothing Then
            Throw New ArgumentNullException("fileName")
        End If

        Using stream = File.OpenWrite(fileName)
            Return Save(stream)
        End Using
    End Function

    Public Function ToIcon() As Icon

        Dim FileName As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) & ".ico"

        If Save(FileName) Then

            Dim Icon As New Icon(FileName)

            My.Computer.FileSystem.DeleteFile(FileName)

            Return Icon

        Else

            Return Nothing

        End If

    End Function

    ''' <summary>
    ''' Saves the icon to a stream.
    ''' </summary>
    ''' <param name="stream">Stream into which icon is saved.</param>
    Public Function Save(ByVal stream As Stream) As Boolean
        If stream Is Nothing Then Return False

        Dim writer As New BinaryWriter(stream)

        Dim sortedImages = Me.Images
        Dim imageData = New Dictionary(Of Integer, Byte())()

        Dim offset As Integer = (Me.m_images.Count * 16) + 6

        ' Write the icon file header.
        writer.Write(CUShort(0))
        ' must be 0
        writer.Write(CUShort(1))
        ' 1 = ico file
        writer.Write(CUShort(Me.m_images.Count))
        ' number of sizes
        For Each image As BitmapSource In sortedImages
            Dim data = GetImageData(image)
            imageData.Add(image.PixelWidth, data)

            writer.Write(CByte(image.Width))
            ' width
            writer.Write(CByte(image.Height))
            ' height
            writer.Write(CByte(0))
            ' colors, 0 = more than 256
            writer.Write(CByte(0))
            ' must be 0
            writer.Write(CUShort(0))
            ' color planes, should be 0 or 1
            writer.Write(CUShort(32))
            ' bits per pixel
            writer.Write(data.Length)
            ' size of bitmap data in bytes
            writer.Write(offset)
            ' bitmap data offset in file
            offset += data.Length
        Next

        Dim sortedData = From i In imageData Order By i.Key Select i.Value

        For Each data As Byte() In sortedData
            writer.Write(data)
        Next

        Return True

    End Function
#End Region

#Region "Private Static Methods"
    ''' <summary>
    ''' Returns a byte array containing the serialized icon image.
    ''' </summary>
    ''' <param name="image">Icon image to serialize.</param>
    ''' <returns>Serialized icon image.</returns>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Justification:="Assembly already requires full trust.")> _
    Private Shared Function GetImageData(ByVal image As BitmapSource) As Byte()
        Using memoryStream As New MemoryStream()
            Dim writer As New BinaryWriter(memoryStream)

            If image.Width < 256 Then
                Dim width As Integer = image.PixelWidth
                Dim pixelCount As Integer = width * width

                writer.Write(40)
                ' size of BITMAPINFOHEADER
                writer.Write(width)
                ' icon width/height
                writer.Write(width * 2)
                ' icon height * 2 (AND plane)
                writer.Write(CShort(1))
                ' must be 1
                writer.Write(CShort(32))
                ' bits per pixel
                writer.Write(0)
                ' must be 0
                writer.Write(pixelCount * 4)
                ' sizeof bitmap data
                writer.Write(New Byte(4 * 4 - 1) {})
                ' must be 0
                Dim pixelData As UInteger() = New UInteger(pixelCount - 1) {}
                image.CopyPixels(pixelData, width * 4, 0)

                For y As Integer = width - 1 To 0 Step -1
                    For x As Integer = 0 To width - 1
                        writer.Write(pixelData((y * width) + x))
                    Next
                Next

                For i As Integer = 0 To pixelCount / 8 - 1
                    writer.Write(CByte(0))
                Next
            Else
                Dim pngEncoder = New PngBitmapEncoder()
                pngEncoder.Frames.Add(BitmapFrame.Create(image))
                pngEncoder.Save(memoryStream)
            End If

            Return memoryStream.ToArray()
        End Using
    End Function
#End Region
End Class