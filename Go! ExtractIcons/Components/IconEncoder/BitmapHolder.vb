Imports System.IO

Public Class BitmapHolder
    Public fileHeader As BITMAPFILEHEADER
    Public info As BITMAPINFO
    Public imageData As Byte()

    Public Sub Open(ByVal filename As String)
        Me.Open(File.OpenRead(filename))
    End Sub

    Public Sub Open(ByVal stream As Stream)
        Using br As New BinaryReader(stream)
            fileHeader.Populate(br)
            info.Populate(br)
            If info.infoHeader.biSizeImage > 0 Then
                imageData = br.ReadBytes(CInt(info.infoHeader.biSizeImage))
            Else
                imageData = br.ReadBytes(CInt(br.BaseStream.Length - br.BaseStream.Position))
            End If
        End Using
    End Sub

    Public Sub Save(ByVal filename As String)
        Me.Save(File.OpenWrite(filename))
    End Sub

    Public Sub Save(ByVal stream As Stream)
        Using bw As New BinaryWriter(stream)
            fileHeader.Save(bw)
            info.Save(bw)
            bw.Write(imageData)
        End Using
    End Sub
End Class