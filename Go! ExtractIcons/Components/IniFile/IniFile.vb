Imports System.ComponentModel

<ToolboxBitmap(GetType(System.Drawing.Bitmap), "Ini_File")> _
<Description("Provides data for the GoVisualTeam.IniFile class.")> _
Public Class IniFile

#Region " API functions "

    Private Declare Ansi Function GetPrivateProfileString _
      Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
      (ByVal lpApplicationName As String, _
      ByVal lpKeyName As String, ByVal lpDefault As String, _
      ByVal lpReturnedString As System.Text.StringBuilder, _
      ByVal nSize As Integer, ByVal lpFileName As String) _
      As Integer
    Private Declare Ansi Function WritePrivateProfileString _
      Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
      (ByVal lpApplicationName As String, _
      ByVal lpKeyName As String, ByVal lpString As String, _
      ByVal lpFileName As String) As Integer
    Private Declare Ansi Function GetPrivateProfileInt _
      Lib "kernel32.dll" Alias "GetPrivateProfileIntA" _
      (ByVal lpApplicationName As String, _
      ByVal lpKeyName As String, ByVal nDefault As Integer, _
      ByVal lpFileName As String) As Integer
    Private Declare Ansi Function FlushPrivateProfileString _
      Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
      (ByVal lpApplicationName As Integer, _
      ByVal lpKeyName As Integer, ByVal lpString As Integer, _
      ByVal lpFileName As String) As Integer

#End Region

    Dim m_FileName As String

    ''' <summary>
    ''' Initializes a new instance of the GoVisualTeam.IniFile class.
    ''' </summary>
    ''' <param name="Filename">The filename of the Inifile.</param>
    ''' <remarks></remarks>
    <Description("Initializes a new instance of the GoVisualTeam.IniFile class.")> _
    Public Sub New(ByVal Filename As String)
        m_FileName = Filename
        If Not My.Computer.FileSystem.FileExists(Filename) Then
            My.Computer.FileSystem.WriteAllText(Filename, Nothing, True)
        End If
    End Sub

    ''' <summary>
    ''' Return's the filename of the INI file.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Return's the filename of the INI file.")> _
    ReadOnly Property FileName() As String
        Get
            Return m_FileName
        End Get
    End Property

    ''' <summary>
    ''' Returns a string from the INI file.
    ''' </summary>
    ''' <param name="Section">The selection to get the string from.</param>
    ''' <param name="Key">The key to get the string from.</param>
    ''' <param name="Default">The default value.</param>
    ''' <remarks></remarks>
    Public Function GetString(ByVal Section As String, _
      ByVal Key As String, Optional ByVal [Default] As String = "") As String
        Dim intCharCount As Integer
        Dim objResult As New System.Text.StringBuilder(256)
        intCharCount = GetPrivateProfileString(Section, Key, _
           [Default], objResult, objResult.Capacity, m_FileName)
        If intCharCount > 0 Then
            Return Left(objResult.ToString, intCharCount)
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' Returns an integer from the INI file.
    ''' </summary>
    ''' <param name="Section">The selection to get the integer from.</param>
    ''' <param name="Key">The key to get the integer from.</param>
    ''' <param name="Default">The default value.</param>
    ''' <remarks></remarks>
    Public Function GetInteger(ByVal Section As String, _
      ByVal Key As String, Optional ByVal [Default] As Integer = 0) As Integer
        Return GetPrivateProfileInt(Section, Key, _
           [Default], m_FileName)
    End Function

    ''' <summary>
    ''' Returns a boolean from the INI file.
    ''' </summary>
    ''' <param name="Section">The selection to get the boolean from.</param>
    ''' <param name="Key">The key to get the boolean from.</param>
    ''' <param name="Default">The default value.</param>
    ''' <remarks></remarks>
    Public Function GetBoolean(ByVal Section As String, _
      ByVal Key As String, Optional ByVal [Default] As Boolean = False) As Boolean
        Return (GetPrivateProfileInt(Section, Key, _
           CInt([Default]), m_FileName) = 1)
    End Function

    ''' <summary>
    ''' Writes a string to the INI file.
    ''' </summary>
    ''' <param name="Section">The selection to write in. If it doesn't exist, it creates a new with the name.</param>
    ''' <param name="Key">The key to write.</param>
    ''' <param name="Value">The string value to write on the key.</param>
    ''' <remarks></remarks>
    Public Sub WriteString(ByVal Section As String, _
      ByVal Key As String, ByVal Value As String)
        WritePrivateProfileString(Section, Key, Value, m_FileName)
        Flush()
    End Sub

    ''' <summary>
    ''' Writes an integer to the INI file.
    ''' </summary>
    ''' <param name="Section">The selection to write in. If it doesn't exist, it creates a new with the name.</param>
    ''' <param name="Key">The key to write.</param>
    ''' <param name="Value">The integer value to write on the key.</param>
    ''' <remarks></remarks>
    Public Sub WriteInteger(ByVal Section As String, _
      ByVal Key As String, ByVal Value As Integer)
        WriteString(Section, Key, CStr(Value))
        Flush()
    End Sub

    ''' <summary>
    ''' Writes a boolean to the INI file.
    ''' </summary>
    ''' <param name="Section">The selection to write in. If it doesn't exist, it creates a new with the name.</param>
    ''' <param name="Key">The key to write.</param>
    ''' <param name="Value">The boolean value to write on the key.</param>
    ''' <remarks></remarks>
    Public Sub WriteBoolean(ByVal Section As String, _
      ByVal Key As String, ByVal Value As Boolean)
        WriteString(Section, Key, CStr(CInt(Value)))
        Flush()
    End Sub

    ''' <summary>
    ''' Stores all the cached changes to the INI file.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Flush()
        FlushPrivateProfileString(0, 0, 0, m_FileName)
    End Sub
End Class