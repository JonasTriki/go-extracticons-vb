Imports System.ComponentModel
Imports System.IO

Public Class FileInfos

    Dim Finised As Boolean = False
    Dim FileList As New List(Of FileInfo)

    Private Sub GetFiles(ByVal Directory As String, ByVal SearchSubFolders As Boolean, ByVal ExtensionsToLookFor As String)

        Dim FileInfos As New ArrayList

        Dim Count As Integer = 0

        If SearchSubFolders Then

            On Error Resume Next

            For Each subdirectory As DirectoryInfo In New DirectoryInfo(Directory).GetDirectories
                Count += 1
                GetFiles(subdirectory.FullName, SearchSubFolders, ExtensionsToLookFor)
            Next

            For Each ext As String In ExtensionsToLookFor.Split(";")

                Dim FilesInFolder As New List(Of FileInfo)
                For Each fi As FileInfo In New DirectoryInfo(Directory).GetFiles(ext)
                    FilesInFolder.Add(fi)
                Next

                'Add files...
                FileInfos.AddRange(FilesInFolder)

            Next

            FileList.AddRange(FileInfos.ToArray(GetType(FileInfo)))

        Else

            For Each ext As String In ExtensionsToLookFor.Split(";")

                Dim FilesInFolder As New List(Of FileInfo)
                For Each fi As FileInfo In New DirectoryInfo(Directory).GetFiles(ext)
                    FilesInFolder.Add(fi)
                Next

                'Add count to count to check if the search is finished...
                Count += FilesInFolder.Count

                'Add files...
                FileInfos.AddRange(FilesInFolder)

            Next

            FileList.AddRange(FileInfos.ToArray(GetType(FileInfo)))

        End If

        Finised = Count > 0

    End Sub

    ''' <summary>
    ''' Gets all files in a directory.
    ''' </summary>
    ''' <param name="Directory">The directory to search in.</param>
    ''' <param name="SearchSubFolders">Search subfolders.</param>
    ''' <param name="ExtensionsToLookFor">The extensions to look for.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllFiles(ByVal Directory As String, Optional ByVal SearchSubFolders As Boolean = False, Optional ByVal ExtensionsToLookFor As String = "*.*") As List(Of FileInfo)

        GetFiles(Directory, SearchSubFolders, ExtensionsToLookFor)

        If Finised Then
            Return FileList
        Else
            Return New List(Of FileInfo)
        End If

    End Function

End Class
