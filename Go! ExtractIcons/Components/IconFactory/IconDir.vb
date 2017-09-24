Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices
Imports [BYTE] = System.Byte
Imports WORD = System.Int16
Imports DWORD = System.Int32

''' <summary>
''' Presents an Icon Directory.
''' </summary>
<StructLayout(LayoutKind.Sequential, Size:=6)> _
Public Structure IconDir
    Public Reserved As WORD
    ' Reserved (must be 0)
    Public Type As WORD
    ' Resource Type (1 for icons)
    Public Count As WORD
    ' How many images?
    ''' <summary>
    ''' Converts the current TAFactory.IconPack.IconDir into TAFactory.IconPack.GroupIconDir.
    ''' </summary>
    ''' <returns>TAFactory.IconPack.GroupIconDir</returns>
    Public Function ToGroupIconDir() As GroupIconDir
        Dim grpDir As New GroupIconDir()
        grpDir.Reserved = Me.Reserved
        grpDir.Type = Me.Type
        grpDir.Count = Me.Count
        Return grpDir
    End Function
End Structure

''' <summary>
''' Presents an Icon Directory Entry.
''' </summary>
<StructLayout(LayoutKind.Sequential, Size:=16)> _
Public Structure IconDirEntry
    Public Width As [BYTE]
    ' Width, in pixels, of the image
    Public Height As [BYTE]
    ' Height, in pixels, of the image
    Public ColorCount As [BYTE]
    ' Number of colors in image (0 if >=8bpp)
    Public Reserved As [BYTE]
    ' Reserved ( must be 0)
    Public Planes As WORD
    ' Color Planes
    Public BitCount As WORD
    ' Bits per pixel
    Public BytesInRes As DWORD
    ' How many bytes in this resource?
    Public ImageOffset As DWORD
    ' Where in the file is this image?
    ''' <summary>
    ''' Converts the current TAFactory.IconPack.IconDirEntry into TAFactory.IconPack.GroupIconDirEntry.
    ''' </summary>
    ''' <param name="id">The resource identifier.</param>
    ''' <returns>TAFactory.IconPack.GroupIconDirEntry</returns>
    Public Function ToGroupIconDirEntry(ByVal id As Integer) As GroupIconDirEntry
        Dim grpEntry As New GroupIconDirEntry()
        grpEntry.Width = Me.Width
        grpEntry.Height = Me.Height
        grpEntry.ColorCount = Me.ColorCount
        grpEntry.Reserved = Me.Reserved
        grpEntry.Planes = Me.Planes
        grpEntry.BitCount = Me.BitCount
        grpEntry.BytesInRes = Me.BytesInRes
        grpEntry.ID = CShort(id)
        Return grpEntry
    End Function
End Structure

''' <summary>
''' Presents a Group Icon Directory.
''' </summary>
<StructLayout(LayoutKind.Sequential, Size:=6)> _
Public Structure GroupIconDir
    Public Reserved As WORD
    ' Reserved (must be 0)
    Public Type As WORD
    ' Resource Type (1 for icons)
    Public Count As WORD
    ' How many images?
    ''' <summary>
    ''' Converts the current TAFactory.IconPack.GroupIconDir into TAFactory.IconPack.IconDir.
    ''' </summary>
    ''' <returns>TAFactory.IconPack.IconDir</returns>
    Public Function ToIconDir() As IconDir
        Dim dir As New IconDir()
        dir.Reserved = Me.Reserved
        dir.Type = Me.Type
        dir.Count = Me.Count
        Return dir
    End Function
End Structure

''' <summary>
''' Presents a Group Icon Directory Entry.
''' </summary>
<StructLayout(LayoutKind.Sequential, Size:=14)> _
Public Structure GroupIconDirEntry
    Public Width As [BYTE]
    ' Width, in pixels, of the image
    Public Height As [BYTE]
    ' Height, in pixels, of the image
    Public ColorCount As [BYTE]
    ' Number of colors in image (0 if >=8bpp)
    Public Reserved As [BYTE]
    ' Reserved ( must be 0)
    Public Planes As WORD
    ' Color Planes
    Public BitCount As WORD
    ' Bits per pixel
    Public BytesInRes As DWORD
    ' How many bytes in this resource?
    Public ID As WORD
    ' the ID
    ''' <summary>
    ''' Converts the current TAFactory.IconPack.GroupIconDirEntry into TAFactory.IconPack.IconDirEntry.
    ''' </summary>
    ''' <returns>TAFactory.IconPack.IconDirEntry</returns>
    Public Function ToIconDirEntry(ByVal imageOffiset As Integer) As IconDirEntry
        Dim entry As New IconDirEntry()
        entry.Width = Me.Width
        entry.Height = Me.Height
        entry.ColorCount = Me.ColorCount
        entry.Reserved = Me.Reserved
        entry.Planes = Me.Planes
        entry.BitCount = Me.BitCount
        entry.BytesInRes = Me.BytesInRes
        entry.ImageOffset = imageOffiset
        Return entry
    End Function
End Structure