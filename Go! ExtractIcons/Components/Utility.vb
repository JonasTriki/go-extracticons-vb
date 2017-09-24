Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Runtime.InteropServices

''' <summary>
''' Holds a set of utilities.
''' </summary>
Public NotInheritable Class Utility
    Private Sub New()
    End Sub
#Region "Stream Utilities"
    ''' <summary>
    ''' Reads a structure of type T from the input stream.
    ''' </summary>
    ''' <typeparam name="T">The structure type to be read.</typeparam>
    ''' <param name="inputStream">The input stream to read from.</param>
    ''' <returns>A structure of type T that was read from the stream.</returns>
    Public Shared Function ReadStructure(Of T As Structure)(ByVal inputStream As Stream) As T
        Dim size As Integer = Marshal.SizeOf(GetType(T))
        Dim buffer As Byte() = New Byte(size - 1) {}
        inputStream.Read(buffer, 0, size)
        Dim ptr As IntPtr = Marshal.AllocHGlobal(size)
        Marshal.Copy(buffer, 0, ptr, size)
        Dim ret As Object = Marshal.PtrToStructure(ptr, GetType(T))
        Marshal.FreeHGlobal(ptr)

        Return DirectCast(ret, T)
    End Function
    ''' <summary>
    ''' Writes as structure of type T to the output stream.
    ''' </summary>
    ''' <typeparam name="T">The structure type to be written.</typeparam>
    ''' <param name="outputStream">The output stream to write to.</param>
    ''' <param name="structure">The structure to be written.</param>
    Public Shared Sub WriteStructure(Of T As Structure)(ByVal outputStream As Stream, ByVal [structure] As T)
        Dim size As Integer = Marshal.SizeOf(GetType(T))
        Dim buffer As Byte() = New Byte(size - 1) {}
        Dim ptr As IntPtr = Marshal.AllocHGlobal(size)
        Marshal.StructureToPtr([structure], ptr, True)
        Marshal.Copy(ptr, buffer, 0, size)
        Marshal.FreeHGlobal(ptr)
        outputStream.Write(buffer, 0, size)
    End Sub
#End Region
End Class