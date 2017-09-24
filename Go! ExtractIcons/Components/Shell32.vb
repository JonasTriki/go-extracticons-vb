Imports System
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices

Public Class Shell32

#Region " SHGFI Const's "

    Public Const SHGFI_ICON As UInteger = &H100
    ' get icon
    Public Const SHGFI_DISPLAYNAME As UInteger = &H200
    ' get display name
    Public Const SHGFI_TYPENAME As UInteger = &H400
    ' get type name
    Public Const SHGFI_ATTRIBUTES As UInteger = &H800
    ' get attributes
    Public Const SHGFI_ICONLOCATION As UInteger = &H1000
    ' get icon location
    Public Const SHGFI_EXETYPE As UInteger = &H2000
    ' return exe type
    Public Const SHGFI_SYSICONINDEX As UInteger = &H4000
    ' get system icon index
    Public Const SHGFI_LINKOVERLAY As UInteger = &H8000
    ' put a link overlay on icon
    Public Const SHGFI_SELECTED As UInteger = &H10000
    ' show icon in selected state
    Public Const SHGFI_ATTR_SPECIFIED As UInteger = &H20000
    ' get only specified attributes
    Public Const SHGFI_LARGEICON As UInteger = &H0
    ' get large icon
    Public Const SHGFI_SMALLICON As UInteger = &H1
    ' get small icon
    Public Const SHGFI_OPENICON As UInteger = &H2
    ' get open icon
    Public Const SHGFI_SHELLICONSIZE As UInteger = &H4
    ' get shell size icon
    Public Const SHGFI_PIDL As UInteger = &H8
    ' pszPath is a pidl
    Public Const SHGFI_USEFILEATTRIBUTES As UInteger = &H10
    ' use passed dwFileAttribute
    Public Const SHGFI_ADDOVERLAYS As UInteger = &H20
    ' apply the appropriate overlays
    Public Const SHGFI_OVERLAYINDEX As UInteger = &H40
    ' Get the index of the overlay
    Public Const FILE_ATTRIBUTE_DIRECTORY As UInteger = &H10
    Public Const FILE_ATTRIBUTE_NORMAL As UInteger = &H80

#End Region

    Enum IconStyles

        Normal = 1

        LinkOverlay = 2

        Selected = 3

        LinkOverlayAndSelected = 4

    End Enum

#Region " Properities "

    Public Shared Function GetIcon(ByVal FilePath As String, Optional ByVal IconStyle As IconStyles = IconStyles.Normal) As Icon

        Dim flags As UInteger = Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON

        If IconStyle = IconStyles.Normal Then
            flags = Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
        ElseIf IconStyle = IconStyles.LinkOverlay Then
            flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
        ElseIf IconStyle = IconStyles.Selected Then
            flags = Shell32.SHGFI_SELECTED Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
        ElseIf IconStyle = IconStyles.LinkOverlayAndSelected Then
            flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_SELECTED Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
        End If

        'Get the extension
        Dim ext As String = IO.Path.GetExtension(FilePath)

        Dim ShellFileInfo As New Shell32.SHFILEINFO()

        Shell32.SHGetFileInfo(ext, 0, ShellFileInfo, Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(ShellFileInfo)), flags)

        Dim Icon As System.Drawing.Icon = System.Drawing.Icon.FromHandle(ShellFileInfo.hIcon)

        Return Icon

    End Function

    Public Shared Function GetIcon(ByVal FilePath As String, ByVal LargeIcon As Boolean, Optional ByVal IconStyle As IconStyles = IconStyles.Normal) As Icon

        If Not LargeIcon Then

            Dim flags As UInteger = Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON

            If IconStyle = IconStyles.Normal Then
                flags = Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
            ElseIf IconStyle = IconStyles.LinkOverlay Then
                flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
            ElseIf IconStyle = IconStyles.Selected Then
                flags = Shell32.SHGFI_SELECTED Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
            ElseIf IconStyle = IconStyles.LinkOverlayAndSelected Then
                flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_SELECTED Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
            End If

            'Get the extension
            Dim ext As String = IO.Path.GetExtension(FilePath)

            Dim ShellFileInfo As New Shell32.SHFILEINFO()

            Shell32.SHGetFileInfo(ext, 0, ShellFileInfo, Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(ShellFileInfo)), flags)

            Dim Icon As System.Drawing.Icon = System.Drawing.Icon.FromHandle(ShellFileInfo.hIcon)

            Return Icon

        Else

            Dim flags As UInteger = Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_LARGEICON

            If IconStyle = IconStyles.Normal Then
                flags = Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_LARGEICON
            ElseIf IconStyle = IconStyles.LinkOverlay Then
                flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_LARGEICON
            ElseIf IconStyle = IconStyles.Selected Then
                flags = Shell32.SHGFI_SELECTED Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_LARGEICON
            ElseIf IconStyle = IconStyles.LinkOverlayAndSelected Then
                flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_SELECTED Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_LARGEICON
            End If

            'Get the extension
            Dim ext As String = IO.Path.GetExtension(FilePath)

            Dim ShellFileInfo As New SHFILEINFO()

            Shell32.SHGetFileInfo(ext, 0, ShellFileInfo, Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(ShellFileInfo)), flags)

            Dim Icon As System.Drawing.Icon = System.Drawing.Icon.FromHandle(ShellFileInfo.hIcon)

            Return Icon

        End If

    End Function

    Public Shared Function GetFileType(ByVal FilePath As String) As String

        Dim ext As String = IO.Path.GetExtension(FilePath)

        Dim flags As UInteger = Shell32.SHGFI_TYPENAME Or Shell32.SHGFI_USEFILEATTRIBUTES

        Dim ShellFileInfo As New SHFILEINFO()

        Shell32.SHGetFileInfo(ext, FILE_ATTRIBUTE_NORMAL, ShellFileInfo, Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(ShellFileInfo)), flags)

        Return ShellFileInfo.szTypeName

    End Function

    Public Shared Sub UpdateRegistry()

        Call SendMessageTimeout(HWND_BROADCAST, WM_SETTINGCHANGE, 0&, 0&, SMTO_ABORTIFHUNG, 1000&, 0)

        Call PostMessage(HWND_BROADCAST, WM_SETTINGCHANGE, 0&, 0&)

    End Sub

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure SHFILEINFO

        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As System.UInt32
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String

    End Structure

    <DllImport("Shell32.dll")> _
    Private Shared Function SHGetFileInfo( _
        ByVal pszPath As String, _
        ByVal dwFileAttributes As System.UInt32, _
        ByRef psfi As SHFILEINFO, _
        ByVal cbFileInfo As System.UInt32, _
        ByVal uFlags As System.UInt32) As IntPtr
    End Function

    Private Const HWND_BROADCAST As Long = &HFFFF&
    Private Const WM_SETTINGCHANGE As Long = &H1A
    Private Const SMTO_ABORTIFHUNG As Long = &H2

    Private Declare Function SendMessageTimeout Lib "User32.dll" _
  Alias "SendMessageTimeoutA" _
 (ByVal hwnd As Long, ByVal msg As Long, _
  ByVal wParam As Long, ByVal lParam As Long, _
  ByVal fuFlags As Long, ByVal uTimeout As Long, _
  ByVal lpdwResult As Long) As Long

    Private Declare Function PostMessage Lib "User32.dll" _
  Alias "PostMessageA" _
 (ByVal hwnd As Long, _
  ByVal wMsg As Long, _
  ByVal wParam As Long, _
  ByVal lParam As Long) As Long

    Friend Declare Auto Function SendMessage _
         Lib "user32.dll" ( _
         ByVal hWnd As IntPtr, _
         ByVal msg As UInt32, _
         ByVal sparam As UInt32, _
         ByVal lparam As UInt32) _
         As UInt32
    Friend Const BCM_SETSHIELD As Int32 = &H160C


#End Region

End Class