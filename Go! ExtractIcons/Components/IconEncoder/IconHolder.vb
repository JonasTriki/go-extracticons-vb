Imports System.IO

Public Class IconHolder
    Public iconDirectory As ICONDIR2
    Public iconImages As ICONIMAGE()

    Public Sub New()
        iconDirectory.Reserved = 0
        iconDirectory.ResourceType = 1
        iconDirectory.EntryCount = 1
        iconImages = New ICONIMAGE() {New ICONIMAGE()}
    End Sub

    Public Sub Open(ByVal filename As String)
        Me.Open(File.OpenRead(filename))
    End Sub

    Public Sub Open(ByVal stream As Stream)
        Using br As New BinaryReader(stream)
            iconDirectory.Populate(br)
            iconImages = New ICONIMAGE(iconDirectory.EntryCount - 1) {}
            ' Loop through and read in each image
            For i As Integer = 0 To iconImages.Length - 1
                ' Seek to the location in the file that has the image
                '  SetFilePointer( hFile, pIconDir->idEntries[i].dwImageOffset, NULL, FILE_BEGIN );
                br.BaseStream.Seek(iconDirectory.Entries(i).ImageOffset, SeekOrigin.Begin)
                ' Read the image data
                '  ReadFile( hFile, pIconImage, pIconDir->idEntries[i].dwBytesInRes, &dwBytesRead, NULL );
                ' Here, pIconImage is an ICONIMAGE structure. Party on it :)
                iconImages(i) = New ICONIMAGE()
                iconImages(i).Populate(br)
            Next
        End Using
    End Sub
    Public Sub Save(ByVal filename As String)
        Using bw As New BinaryWriter(File.OpenWrite(filename))
            Me.Save(bw)
        End Using
    End Sub
    Public Sub Save(ByVal bw As BinaryWriter)
        iconDirectory.Save(bw)
        For i As Integer = 0 To iconImages.Length - 1
            iconImages(i).Save(bw)
        Next
    End Sub
    Public Function ToIcon() As System.Drawing.Icon
        Dim newIcon As System.Drawing.Icon
        Using bw As New BinaryWriter(New MemoryStream())
            Me.Save(bw)
            bw.BaseStream.Position = 0
            newIcon = New System.Drawing.Icon(bw.BaseStream)
        End Using
        Return newIcon
    End Function
End Class