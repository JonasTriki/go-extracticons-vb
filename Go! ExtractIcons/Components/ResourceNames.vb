Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices

''' <summary>
''' Represents a resource name (either integer resource or string resource).
''' </summary>
Public Class ResourceName
    Implements IDisposable
#Region "Properties"
    Private _id As System.Nullable(Of Integer)
    ''' <summary>
    ''' Gets the resource identifier, returns null if the resource is not an integer resource.
    ''' </summary>
    Public Property Id() As System.Nullable(Of Integer)
        Get
            Return _id
        End Get
        Private Set(ByVal value As System.Nullable(Of Integer))
            _id = value
        End Set
    End Property

    Private _name As String
    ''' <summary>
    ''' Gets the resource name, returns null if the resource is not a string resource.
    ''' </summary>
    Public Property Name() As String
        Get
            Return _name
        End Get
        Private Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _value As IntPtr
    ''' <summary>
    ''' Gets a pointer to resource name that can be used in FindResource function.
    ''' </summary>
    Public Property Value() As IntPtr
        Get
            If Me.IsIntResource Then
                Return New IntPtr(Me.Id.Value)
            End If

            If Me._value = IntPtr.Zero Then
                Me._value = Marshal.StringToHGlobalAuto(Me.Name)
            End If

            Return _value
        End Get
        Private Set(ByVal value As IntPtr)
            _value = value
        End Set
    End Property

    ''' <summary>
    ''' Gets whether the resource is an integer resource.
    ''' </summary>
    Public ReadOnly Property IsIntResource() As Boolean
        Get
            Return (Me.Id IsNot Nothing)
        End Get
    End Property
#End Region

#Region "Constructor/Destructor"
    ''' <summary>
    ''' Initializes a new TAFactory.IconPack.ResourceName object.
    ''' </summary>
    ''' <param name="lpName">Specifies the resource name. For more ifnormation, see the Remarks section.</param>
    ''' <remarks>
    ''' If the high bit of lpszName is not set (=0), lpszName specifies the integer identifier of the givin resource.
    ''' Otherwise, it is a pointer to a null terminated string.
    ''' If the first character of the string is a pound sign (#), the remaining characters represent a decimal number that specifies the integer identifier of the resource. For example, the string "#258" represents the identifier 258.
    ''' #define IS_INTRESOURCE(_r) ((((ULONG_PTR)(_r)) >> 16) == 0).
    ''' </remarks>
    Public Sub New(ByVal lpName As IntPtr)
        If (CUInt(lpName) >> 16) = 0 Then
            'Integer resource
            Me.Id = lpName.ToInt32()
            Me.Name = Nothing
        Else
            Me.Id = Nothing
            Me.Name = Marshal.PtrToStringAuto(lpName)
        End If
    End Sub
    ''' <summary>
    ''' Destructs the ResourceName object.
    ''' </summary>
    Protected Overrides Sub Finalize()
        Try
            Dispose()
        Finally
            MyBase.Finalize()
        End Try
    End Sub
#End Region

#Region "Public Functions"
    ''' <summary>
    ''' Returns a System.String that represents the current TAFactory.IconPack.ResourceName.
    ''' </summary>
    ''' <returns>Returns a System.String that represents the current TAFactory.IconPack.ResourceName.</returns>
    Public Overrides Function ToString() As String
        If Me.IsIntResource Then
            Return "#" + Me.Id.ToString()
        End If

        Return Me.Name
    End Function
    ''' <summary>
    ''' Releases the pointer to the resource name.
    ''' </summary>
    Public Sub Free()
        If Me._value <> IntPtr.Zero Then
            Try
                Marshal.FreeHGlobal(Me._value)
            Catch
            End Try
            Me._value = IntPtr.Zero
        End If
    End Sub
#End Region

#Region "IDisposable Members"
    ''' <summary>
    ''' Release the pointer to the resource name.
    ''' </summary>
    Public Sub Dispose() Implements System.IDisposable.Dispose
        Free()
    End Sub
#End Region
End Class