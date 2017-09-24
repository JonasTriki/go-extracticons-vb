Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.ComponentModel

''' <summary>
''' Provides information about a givin icon.
''' This class cannot be inherited.
''' </summary>
<Serializable()> _
Public Class IconInfo
#Region "ReadOnly"
    Public Shared SizeOfIconDir As Integer = Marshal.SizeOf(GetType(IconDir))
    Public Shared SizeOfIconDirEntry As Integer = Marshal.SizeOf(GetType(IconDirEntry))
    Public Shared SizeOfGroupIconDir As Integer = Marshal.SizeOf(GetType(GroupIconDir))
    Public Shared SizeOfGroupIconDirEntry As Integer = Marshal.SizeOf(GetType(GroupIconDirEntry))
#End Region

#Region "Properties"
    Private _sourceIcon As Icon
    ''' <summary>
    ''' Gets the source System.Drawing.Icon.
    ''' </summary>
    Public Property SourceIcon() As Icon
        Get
            Return _sourceIcon
        End Get
        Private Set(ByVal value As Icon)
            _sourceIcon = value
        End Set
    End Property

    Private _fileName As String = Nothing
    ''' <summary>
    ''' Gets the icon's file name. 
    ''' </summary>
    Public Property FileName() As String
        Get
            Return _fileName
        End Get
        Private Set(ByVal value As String)
            _fileName = value
        End Set
    End Property

    Private _images As List(Of Icon)
    ''' <summary>
    ''' Gets a list System.Drawing.Icon that presents the icon contained images.
    ''' </summary>
    Public Property Images() As List(Of Icon)
        Get
            Return _images
        End Get
        Private Set(ByVal value As List(Of Icon))
            _images = value
        End Set
    End Property

    ''' <summary>
    ''' Get whether the icon contain more than one image or not.
    ''' </summary>
    Public ReadOnly Property IsMultiIcon() As Boolean
        Get
            Return (Me.Images.Count > 1)
        End Get
    End Property

    Private _bestFitIconIndex As Integer
    ''' <summary>
    ''' Gets icon index that best fits to screen resolution.
    ''' </summary>
    Public Property BestFitIconIndex() As Integer
        Get
            Return _bestFitIconIndex
        End Get
        Private Set(ByVal value As Integer)
            _bestFitIconIndex = value
        End Set
    End Property

    Private _width As Integer
    ''' <summary>
    ''' Gets icon width.
    ''' </summary>
    Public Property Width() As Integer
        Get
            Return _width
        End Get
        Private Set(ByVal value As Integer)
            _width = value
        End Set
    End Property

    Private _height As Integer
    ''' <summary>
    ''' Gets icon height.
    ''' </summary>
    Public Property Height() As Integer
        Get
            Return _height
        End Get
        Private Set(ByVal value As Integer)
            _height = value
        End Set
    End Property

    Private _colorCount As Integer
    ''' <summary>
    ''' Gets number of colors in icon (0 if >=8bpp).
    ''' </summary>
    Public Property ColorCount() As Long
        Get
            If Not _colorCount = 0 Then
                Return _colorCount
            Else
                Return 2 ^ ColorDepth
            End If
        End Get
        Private Set(ByVal value As Long)
            _colorCount = value
        End Set
    End Property

    Private _planes As Integer
    ''' <summary>
    ''' Gets icon color planes.
    ''' </summary>
    Public Property Planes() As Integer
        Get
            Return _planes
        End Get
        Private Set(ByVal value As Integer)
            _planes = value
        End Set
    End Property

    Private _bitCount As Integer
    ''' <summary>
    ''' Gets icon bits per pixel (0 if 8bpp or less)
    ''' </summary>
    Public Property BitCount() As Integer
        Get
            Return _bitCount
        End Get
        Private Set(ByVal value As Integer)
            _bitCount = value
        End Set
    End Property

    ''' <summary>
    ''' Gets icon bits per pixel.
    ''' </summary>
    Public ReadOnly Property ColorDepth() As Integer
        Get
            If Me.BitCount <> 0 Then
                Return Me.BitCount
            End If
            If Me.ColorCount = 0 Then
                Return 0
            End If
            Return CInt(Math.Log(Me.ColorCount, 2))
        End Get
    End Property
#End Region

#Region "Icon Headers Properties"
    Private _iconDir As IconDir
    ''' <summary>
    ''' Gets the TAFactory.IconPack.IconDir of the icon.
    ''' </summary>
    Public Property IconDir() As IconDir
        Get
            Return _iconDir
        End Get
        Private Set(ByVal value As IconDir)
            _iconDir = value
        End Set
    End Property

    Private _groupIconDir As GroupIconDir
    ''' <summary>
    ''' Gets the TAFactory.IconPack.GroupIconDir of the icon.
    ''' </summary>
    Public Property GroupIconDir() As GroupIconDir
        Get
            Return _groupIconDir
        End Get
        Private Set(ByVal value As GroupIconDir)
            _groupIconDir = value
        End Set
    End Property

    Private _iconDirEntries As List(Of IconDirEntry)
    ''' <summary>
    ''' Gets a list of TAFactory.IconPack.IconDirEntry of the icon.
    ''' </summary>
    Public Property IconDirEntries() As List(Of IconDirEntry)
        Get
            Return _iconDirEntries
        End Get
        Private Set(ByVal value As List(Of IconDirEntry))
            _iconDirEntries = value
        End Set
    End Property

    Private _groupIconDirEntries As List(Of GroupIconDirEntry)
    ''' <summary>
    ''' Gets a list of TAFactory.IconPack.GroupIconDirEntry of the icon.
    ''' </summary>
    Public Property GroupIconDirEntries() As List(Of GroupIconDirEntry)
        Get
            Return _groupIconDirEntries
        End Get
        Private Set(ByVal value As List(Of GroupIconDirEntry))
            _groupIconDirEntries = value
        End Set
    End Property

    Private _rawData As List(Of Byte())
    ''' <summary>
    ''' Gets a list of raw data for each icon image.
    ''' </summary>
    Public Property RawData() As List(Of Byte())
        Get
            Return _rawData
        End Get
        Private Set(ByVal value As List(Of Byte()))
            _rawData = value
        End Set
    End Property

    Private _resourceRawData As Byte()
    ''' <summary>
    ''' Gets the icon raw data as a resource data.
    ''' </summary>
    Public Property ResourceRawData() As Byte()
        Get
            Return _resourceRawData
        End Get
        Set(ByVal value As Byte())
            _resourceRawData = value
        End Set
    End Property
#End Region

#Region "Constructors"
    ''' <summary>
    ''' Intializes a new instance of TAFactory.IconPack.IconInfo which contains the information about the givin icon.
    ''' </summary>
    ''' <param name="icon">A System.Drawing.Icon object to retrieve the information about.</param>
    Public Sub New(ByVal Icon As Icon)
        Me.FileName = Nothing
        LoadIconInfo(Icon)
    End Sub

    ''' <summary>
    ''' Intializes a new instance of TAFactory.IconPack.IconInfo which contains the information about the icon in the givin file.
    ''' </summary>
    ''' <param name="FileName">A fully qualified name of the icon file, it can contain environment variables.</param>
    Public Sub New(ByVal FileName As String)
        Me.FileName = FileName
        LoadIconInfo(New Icon(FileName))
    End Sub
#End Region

#Region "Public Methods"
    ''' <summary>
    ''' Gets the index of the icon that best fits the current display device.
    ''' </summary>
    ''' <returns>The icon index.</returns>
    Public Function GetBestFitIconIndex() As Integer
        Dim iconIndex As Integer = 0
        Dim resBits As IntPtr = Marshal.AllocHGlobal(Me.ResourceRawData.Length)
        Marshal.Copy(Me.ResourceRawData, 0, resBits, Me.ResourceRawData.Length)
        Try
            iconIndex = Win32.LookupIconIdFromDirectory(resBits, True)
        Finally
            Marshal.FreeHGlobal(resBits)
        End Try

        Return iconIndex
    End Function
    ''' <summary>
    ''' Gets the index of the icon that best fits the current display device.
    ''' </summary>
    ''' <param name="desiredSize">Specifies the desired size of the icon.</param>
    ''' <returns>The icon index.</returns>
    Public Function GetBestFitIconIndex(ByVal desiredSize As Size) As Integer
        Return GetBestFitIconIndex(desiredSize, False)
    End Function
    ''' <summary>
    ''' Gets the index of the icon that best fits the current display device.
    ''' </summary>
    ''' <param name="desiredSize">Specifies the desired size of the icon.</param>
    ''' <param name="isMonochrome">Specifies whether to get the monochrome icon or the colored one.</param>
    ''' <returns>The icon index.</returns>
    Public Function GetBestFitIconIndex(ByVal desiredSize As Size, ByVal isMonochrome As Boolean) As Integer
        Dim iconIndex As Integer = 0
        Dim flags As LookupIconIdFromDirectoryExFlags = LookupIconIdFromDirectoryExFlags.LR_DEFAULTCOLOR
        If isMonochrome Then
            flags = LookupIconIdFromDirectoryExFlags.LR_MONOCHROME
        End If
        Dim resBits As IntPtr = Marshal.AllocHGlobal(Me.ResourceRawData.Length)
        Marshal.Copy(Me.ResourceRawData, 0, resBits, Me.ResourceRawData.Length)
        Try
            iconIndex = Win32.LookupIconIdFromDirectoryEx(resBits, True, desiredSize.Width, desiredSize.Height, flags)
        Finally
            Marshal.FreeHGlobal(resBits)
        End Try

        Return iconIndex
    End Function
#End Region

#Region "Private Methods"
    ''' <summary>
    ''' Loads the icon information from the givin icon into class members.
    ''' </summary>
    ''' <param name="icon">A System.Drawing.Icon object to retrieve the information about.</param>
    Private Sub LoadIconInfo(ByVal icon As Icon)

        If IsNothing(icon) Then
            frmMain.ShowError(frmMain.Errors.TheIconIsEmpty)
            Exit Sub
        End If

        Me.SourceIcon = icon
        Dim inputStream As New MemoryStream()
        Me.SourceIcon.Save(inputStream)

        inputStream.Seek(0, SeekOrigin.Begin)
        Dim dir As IconDir = Utility.ReadStructure(Of IconDir)(inputStream)

        Me.IconDir = dir
        Me.GroupIconDir = dir.ToGroupIconDir()

        Me.Images = New List(Of Icon)(dir.Count)
        Me.IconDirEntries = New List(Of IconDirEntry)(dir.Count)
        Me.GroupIconDirEntries = New List(Of GroupIconDirEntry)(dir.Count)
        Me.RawData = New List(Of Byte())(dir.Count)

        Dim newDir As IconDir = dir
        newDir.Count = 1
        For i As Integer = 0 To dir.Count - 1
            inputStream.Seek(SizeOfIconDir + i * SizeOfIconDirEntry, SeekOrigin.Begin)

            Dim entry As IconDirEntry = Utility.ReadStructure(Of IconDirEntry)(inputStream)

            Me.IconDirEntries.Add(entry)
            Me.GroupIconDirEntries.Add(entry.ToGroupIconDirEntry(i))

            Dim content As Byte() = New Byte(entry.BytesInRes - 1) {}
            inputStream.Seek(entry.ImageOffset, SeekOrigin.Begin)
            inputStream.Read(content, 0, content.Length)
            Me.RawData.Add(content)

            Dim newEntry As IconDirEntry = entry
            newEntry.ImageOffset = SizeOfIconDir + SizeOfIconDirEntry

            Dim outputStream As New MemoryStream()
            Utility.WriteStructure(Of IconDir)(outputStream, newDir)
            Utility.WriteStructure(Of IconDirEntry)(outputStream, newEntry)
            outputStream.Write(content, 0, content.Length)

            outputStream.Seek(0, SeekOrigin.Begin)
            Dim newIcon As New Icon(outputStream)
            outputStream.Close()

            Me.Images.Add(newIcon)
            If dir.Count = 1 Then
                Me.BestFitIconIndex = 0

                Me.Width = entry.Width
                Me.Height = entry.Height
                Me.ColorCount = entry.ColorCount
                Me.Planes = entry.Planes
                Me.BitCount = entry.BitCount
            End If
            Application.DoEvents()
        Next
        inputStream.Close()
        Me.ResourceRawData = GetIconResourceData()

        If dir.Count > 1 Then
            Me.BestFitIconIndex = GetBestFitIconIndex()

            Me.Width = Me.IconDirEntries(Me.BestFitIconIndex).Width
            Me.Height = Me.IconDirEntries(Me.BestFitIconIndex).Height
            Me.ColorCount = Me.IconDirEntries(Me.BestFitIconIndex).ColorCount
            Me.Planes = Me.IconDirEntries(Me.BestFitIconIndex).Planes
            Me.BitCount = Me.IconDirEntries(Me.BestFitIconIndex).BitCount
        End If

    End Sub

    ''' <summary>
    ''' Returns the icon's raw data as a resource data.
    ''' </summary>
    ''' <returns>The icon's raw as a resource data.</returns>
    Private Function GetIconResourceData() As Byte()
        Dim outputStream As New MemoryStream()
        Utility.WriteStructure(Of GroupIconDir)(outputStream, Me.GroupIconDir)
        For Each entry As GroupIconDirEntry In Me.GroupIconDirEntries
            Utility.WriteStructure(Of GroupIconDirEntry)(outputStream, entry)
            Application.DoEvents()
        Next

        Return outputStream.ToArray()
    End Function
#End Region
End Class