'Return's a list of all made Structures for functions...

Public Structure ICONGETTERINFO

    Dim URL As String
    Dim CommandLine As String

End Structure

Public Structure FAVICONANDTITLEGETTERINFO

    Dim Title As String
    Dim FaviconURL As String
    Dim FaviconURLCommandLine As String

    Dim FaviconAsIcon As Icon
    Dim FaviconAsImage As Image

End Structure

Public Structure FileAlreadyExistsInfo

    Enum FileAlreadyExistsInfoEnum

        OverWriteFile = 1
        RenameFile = 2

        OverWriteIfFileIsLarger = 3
        OverWriteIfFileIsSmaller = 4

        JumpOver = 5

    End Enum

    Dim EnumInfo As FileAlreadyExistsInfoEnum

    Dim AlwaysUseThisOption As Boolean
    Dim OnlyUseOptionOnCurrentList As Boolean

End Structure