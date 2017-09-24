Imports System
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Globalization
''' <summary>
''' Maintains a sorted collection of icon images.
''' </summary>
Public NotInheritable Class IconImageCollection
    Implements ICollection(Of BitmapSource)
    Implements INotifyCollectionChanged

#Region "Private Fields"
    ''' <summary>
    ''' Stores icon images.
    ''' </summary>
    Private ReadOnly images As New SortedList(Of Integer, BitmapSource)()
#End Region

#Region "Constructors"
    ''' <summary>
    ''' Initializes a new instance of the IconImageCollection class.
    ''' </summary>
    Public Sub New()
    End Sub
#End Region

#Region "Public Events"
    ''' <summary>
    ''' Occurs when the collection has changed.
    ''' </summary>
    Public Event CollectionChanged As NotifyCollectionChangedEventHandler Implements INotifyCollectionChanged.CollectionChanged
#End Region

#Region "Public Properties"
    ''' <summary>
    ''' Gets the number of images in the collection.
    ''' </summary>
    Public ReadOnly Property Count() As Integer Implements ICollection(Of BitmapSource).Count
        Get
            Return Me.images.Count
        End Get
    End Property

    ''' <summary>
    ''' Gets a value indicating whether the collection is read-only.
    ''' </summary>
    Private ReadOnly Property IsReadOnly() As Boolean Implements ICollection(Of BitmapSource).IsReadOnly
        Get
            Return False
        End Get
    End Property
#End Region

#Region "Public Methods"
    ''' <summary>
    ''' Adds a new image to the collection.
    ''' </summary>
    ''' <param name="item">Image to add.</param>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId:="0", Justification:="False positive. Parameters are validated.")> _
    Public Sub Add(ByVal item As BitmapSource) Implements ICollection(Of BitmapSource).Add

        Me.images.Add(item.PixelWidth, ConvertBitmap(item))
        Me.OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
    End Sub

    ''' <summary>
    ''' Adds an image to the collection, replacing one if it has the same dimensions.
    ''' </summary>
    ''' <param name="item">Image to add.</param>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId:="0", Justification:="False positive. Parameters are validated.")> _
    Public Sub [Set](ByVal item As BitmapSource)

        If Me.images.TryGetValue(item.PixelWidth, Nothing) Then
            If item Is Nothing Then
                Return
            End If

            Me.images(item.PixelWidth) = ConvertBitmap(item)
            Me.OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
        Else
            Me.images.Add(item.PixelWidth, ConvertBitmap(item))
            Me.OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
        End If
    End Sub

    ''' <summary>
    ''' Removes all of the images from the collection.
    ''' </summary>
    Public Sub Clear() Implements ICollection(Of BitmapSource).Clear
        Me.images.Clear()
        Me.OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
    End Sub

    ''' <summary>
    ''' Returns a value indicating whether an image is contained in the collection.
    ''' </summary>
    ''' <param name="item">Image to search for in the collection.</param>
    ''' <returns>Value indicating whether the image was found in the collection.</returns>
    Public Function Contains(ByVal item As BitmapSource) As Boolean Implements ICollection(Of BitmapSource).Contains
        Return Me.images.ContainsValue(item)
    End Function

    ''' <summary>
    ''' Copies the images in the collection to an array.
    ''' </summary>
    ''' <param name="array">Array into which images are copied.</param>
    ''' <param name="arrayIndex">Index in array to begin copying.</param>
    Public Sub CopyTo(ByVal array As BitmapSource(), ByVal arrayIndex As Integer) Implements ICollection(Of BitmapSource).CopyTo
        Me.images.Values.CopyTo(array, arrayIndex)
    End Sub

    ''' <summary>
    ''' Removes an image from the collection.
    ''' </summary>
    ''' <param name="item">Image to remove from the collection.</param>
    ''' <returns>Value indicating whether image was contained in the collection.</returns>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId:="0", Justification:="Parameter is not directly used, so it does not need validation.")> _
    Public Function Remove(ByVal item As BitmapSource) As Boolean Implements ICollection(Of BitmapSource).Remove
        Dim res As Boolean = Me.images.ContainsValue(item)
        If res Then
            Me.images.Remove(item.PixelWidth)
            Me.OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
        End If

        Return res
    End Function

    ''' <summary>
    ''' Returns an instance used to enumerate the images in the collection.
    ''' </summary>
    ''' <returns>Instance used to enumerate the images in the collection.</returns>
    Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return Me.images.Values.GetEnumerator()
    End Function

    ''' <summary>
    ''' Returns an instance used to enumerate the images in the collection.
    ''' </summary>
    ''' <returns>Instance used to enumerate the images in the collection.</returns>
    Public Function GetEnumerator2() As IEnumerator(Of BitmapSource) Implements IEnumerable(Of BitmapSource).GetEnumerator
        Return Me.images.Values.GetEnumerator()
    End Function

#End Region

#Region "Private Static Methods"

    ''' <summary>
    ''' Converts a bitmap to BRGA32 pixel format if necessary.
    ''' </summary>
    ''' <param name="source">Bitmap to convert.</param>
    ''' <returns>Converted bitmap.</returns>
    Private Shared Function ConvertBitmap(ByVal source As BitmapSource) As BitmapSource
        If source.Format = PixelFormats.Bgra32 Then
            Return source
        End If

        Return New FormatConvertedBitmap(source, PixelFormats.Bgr32, Nothing, 0.0)
    End Function
#End Region

#Region "Private Methods"
    ''' <summary>
    ''' Raises the CollectionChanged event.
    ''' </summary>
    ''' <param name="e">Contains information about the event.</param>
    Private Sub OnCollectionChanged(ByVal e As NotifyCollectionChangedEventArgs)
        RaiseEvent CollectionChanged(Me, e)
    End Sub
#End Region

End Class