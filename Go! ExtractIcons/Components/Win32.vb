Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices

<UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet:=CharSet.Auto)> _
Public Delegate Function EnumResNameProc(ByVal hModule As IntPtr, ByVal lpszType As ResourceTypes, ByVal lpszName As IntPtr, ByVal lParam As IntPtr) As Boolean

#Region "Enumurations"
<Flags()> _
Public Enum LoadLibraryExFlags As Integer
    DONT_RESOLVE_DLL_REFERENCES = &H1
    LOAD_LIBRARY_AS_DATAFILE = &H2
    LOAD_WITH_ALTERED_SEARCH_PATH = &H8
End Enum
Public Enum GetLastErrorResult As Integer
    ERROR_SUCCESS = 0
    ERROR_FILE_NOT_FOUND = 2
    ERROR_BAD_EXE_FORMAT = 193
    ERROR_RESOURCE_TYPE_NOT_FOUND = 1813
End Enum
Public Enum ResourceTypes As Integer
    RT_ACCELERATOR = 9
    RT_ANICURSOR = 21
    RT_ANIICON = 22
    RT_BITMAP = 2
    RT_CURSOR = 1
    RT_DIALOG = 5
    RT_DLGINCLUDE = 17
    RT_FONT = 8
    RT_FONTDIR = 7
    RT_GROUP_CURSOR = 12
    RT_GROUP_ICON = 14
    RT_HTML = 23
    RT_ICON = 3
    RT_MANIFEST = 24
    RT_MENU = 4
    RT_MESSAGETABLE = 11
    RT_PLUGPLAY = 19
    RT_RCDATA = 10
    RT_STRING = 6
    RT_VERSION = 16
    RT_VXD = 20
End Enum
Public Enum LookupIconIdFromDirectoryExFlags As Integer
    LR_DEFAULTCOLOR = 0
    LR_MONOCHROME = 1
End Enum
Public Enum LoadImageTypes As Integer
    IMAGE_BITMAP = 0
    IMAGE_ICON = 1
    IMAGE_CURSOR = 2
End Enum
<Flags()> _
Public Enum SHGetFileInfoFlags As Integer
    Icon = &H100
    ' get icon
    DisplayName = &H200
    ' get display name
    TypeName = &H400
    ' get type name
    Attributes = &H800
    ' get attributes
    IconLocation = &H1000
    ' get icon location
    ExeType = &H2000
    ' return exe type
    SysIconIndex = &H4000
    ' get system icon index
    LinkOverlay = &H8000
    ' put a link overlay on icon
    Selected = &H10000
    ' show icon in selected state
    AttrSpecified = &H20000
    ' get only specified attributes
    LargeIcon = &H0
    ' get large icon
    SmallIcon = &H1
    ' get small icon
    OpenIcon = &H2
    ' get open icon
    ShellIconSize = &H4
    ' get shell size icon
    PIDL = &H8
    ' pszPath is a pidl
    UseFileAttributes = &H10
    ' use passed dwFileAttribute
End Enum
#End Region

#Region "Structures"
<StructLayout(LayoutKind.Sequential)> _
Public Structure SHFILEINFO
    Public hIcon As IntPtr
    Public iIcon As IntPtr
    Public dwAttributes As UInteger
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
    Public szDisplayName As String
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
    Public szTypeName As String
End Structure
#End Region

Public NotInheritable Class Win32
    Private Sub New()
    End Sub
#Region "Constants"
    Public Const MAX_PATH As Integer = 260
#End Region

#Region "Helper Functions"
    Public Shared Function IsIntResource(ByVal lpszName As IntPtr) As Boolean
        Return ((CUInt(lpszName) >> 16) = 0)
    End Function
#End Region

#Region "API Functions"
    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function LoadLibrary(ByVal lpFileName As String) As IntPtr
    End Function

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function LoadLibraryEx(ByVal lpFileName As String, ByVal hFile As IntPtr, ByVal dwFlags As LoadLibraryExFlags) As IntPtr
    End Function

    Public Declare Auto Function FreeLibrary Lib "kernel32.dll" (ByVal hModule As IntPtr) As Boolean

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function GetModuleFileName(ByVal hModule As IntPtr, ByVal lpFilename As StringBuilder, ByVal nSize As Integer) As Integer
    End Function

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function EnumResourceNames(ByVal hModule As IntPtr, ByVal lpszType As ResourceTypes, ByVal lpEnumFunc As EnumResNameProc, ByVal lParam As IntPtr) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function FindResource(ByVal hModule As IntPtr, ByVal lpName As IntPtr, ByVal lpType As ResourceTypes) As IntPtr
    End Function

    Public Declare Auto Function LoadResource Lib "kernel32.dll" (ByVal hModule As IntPtr, ByVal hResInfo As IntPtr) As IntPtr

    Public Declare Auto Function LockResource Lib "kernel32.dll" (ByVal hResData As IntPtr) As IntPtr

    Public Declare Auto Function SizeofResource Lib "kernel32.dll" (ByVal hModule As IntPtr, ByVal hResInfo As IntPtr) As Integer

    Public Declare Auto Function LookupIconIdFromDirectory Lib "user32.dll" (ByVal presbits As IntPtr, ByVal fIcon As Boolean) As Integer

    Public Declare Auto Function LookupIconIdFromDirectoryEx Lib "user32.dll" (ByVal presbits As IntPtr, ByVal fIcon As Boolean, ByVal cxDesired As Integer, ByVal cyDesired As Integer, ByVal Flags As LookupIconIdFromDirectoryExFlags) As Integer

    Public Declare Auto Function LoadImage Lib "user32.dll" Alias "LoadImageW" (ByVal hInstance As IntPtr, ByVal lpszName As IntPtr, ByVal imageType As LoadImageTypes, ByVal cxDesired As Integer, ByVal cyDesired As Integer, ByVal fuLoad As UInteger) As IntPtr

    <DllImport("shell32.dll")> _
    Public Shared Function SHGetFileInfo(ByVal pszPath As String, ByVal dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, ByVal cbSizeFileInfo As UInteger, ByVal uFlags As SHGetFileInfoFlags) As IntPtr
    End Function
#End Region
End Class