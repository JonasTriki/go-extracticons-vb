Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class MultiListBox

#Region " Class MultiItemCollection "

    <Description("Contains a collection of GoVisualTeam.ToolKit.MultiItem objects.")> _
    Public Class MultiItemCollection
        Inherits CollectionBase

        Dim IsReorder As Boolean = False

        Dim MultiListBox As MultiListBox

        Friend Sub New(ByVal Owner As MultiListBox)
            MultiListBox = Owner
        End Sub

        <Description("Create a new MultiItem and adds it to the collection.")> _
        Public Function Add(ByVal Item As MultiItem) As MultiItem

            Item.SuspendLayout()
            MultiListBox.SuspendLayout()

            List.Add(Item)

            Item.ResumeLayout()
            MultiListBox.ResumeLayout()

            Return Item

        End Function

        <Description("Create a new MultiItem and adds it to the collection.")> _
        Public Function Add(ByVal Icon As Icon, ByVal Title As String, ByVal Text As String) As MultiItem
            Dim Item As New MultiItem(MultiListBox, Icon, Title, Text)
            Item.SuspendLayout()
            MultiListBox.SuspendLayout()

            List.Add(Item)

            Item.ResumeLayout()
            MultiListBox.ResumeLayout()

            Return Item

        End Function

        <Description("Create a new MultiItem and adds it to the collection.")> _
        Public Function Add(ByVal Icon As Icon, ByVal Title As String, ByVal ExtraTitle As String, ByVal Text As String) As MultiItem
            Dim Item As New MultiItem(MultiListBox, Icon, Title, ExtraTitle, Text)
            Item.SuspendLayout()
            MultiListBox.SuspendLayout()

            List.Add(Item)

            Item.ResumeLayout()
            MultiListBox.ResumeLayout()

            Return Item

        End Function

        <Description("Selects an Item from the collection.")> _
        Public Sub SelectItem(ByVal Index As Integer)
            MultiListBox.Items(Index).Focus()
        End Sub

        <Description("Selects an Item from the collection.")> _
        Public Sub SelectItem(ByVal Item As MultiItem)
            MultiListBox.Items(IndexOf(Item)).Focus()
        End Sub

        <Description("Selects the first Item from the collection.")> _
        Public Sub SelectFirstItem()
            MultiListBox.Items(0).Focus()
        End Sub

        <Description("Selects the last Item from the collection.")> _
        Public Sub SelectLastItem()
            MultiListBox.Items(MultiListBox.Items.Count - 1).Focus()
        End Sub

        <Description("Selects the next Item from the collection.")> _
        Public Sub SelectNextItem()
            MultiListBox.Items(SelectedIndex() - 1).Focus()
        End Sub

        <Description("Selects the previous Item from the collection.")> _
        Public Sub SelectPreviousItem()
            MultiListBox.Items(SelectedIndex() + 1).Focus()
        End Sub

        <Description("Removes a MultiColumnItem from the collection.")> _
        Public Sub Remove(ByVal Item As MultiItem)
            Try
                MultiListBox.ItemBox.Controls.Remove(Item)
                List.Remove(Item)
            Catch ex As Exception
            End Try
        End Sub

        <Description("Gets a MultiItem in the position Index from the collection.")> _
        Default Public ReadOnly Property Item(ByVal Index As Integer) As MultiItem
            Get
                Return List.Item(Index)
            End Get
        End Property

        <Description("Returns the index of the specified MultiItem in the collection.")> _
        Public Property IndexOf(ByVal Item As MultiItem) As Integer
            Get
                Return List.IndexOf(Item)
            End Get
            Set(ByVal value As Integer)
                IsReorder = True
                List.Remove(Item)
                List.Insert(value, Item)
            End Set
        End Property

        Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)
            MyBase.OnInsertComplete(index, value)
            If IsReorder Then Exit Sub

            DirectCast(value, MultiItem).View = MultiListBox.View

            DirectCast(value, MultiItem).Dock = DockStyle.Top

            MultiListBox.ItemBox.Controls.Add(DirectCast(value, MultiItem))

            DirectCast(value, MultiItem).BringToFront()

            DirectCast(value, MultiItem).Focus()

        End Sub

        Protected Overrides Sub OnRemoveComplete(ByVal index As Integer, ByVal value As Object)
            MyBase.OnRemoveComplete(index, value)
            If IsReorder Then Exit Sub
            Dim s As Integer = SelectedIndex()
            MultiListBox.ItemBox.Controls.Remove(DirectCast(value, MultiItem))
            DirectCast(value, MultiItem).Icon.Dispose()
            DirectCast(value, MultiItem).Dispose()
            SelectItem(s)
        End Sub

        Protected Overrides Sub OnClear()
            MyBase.OnClear()
        End Sub

        Protected Overrides Sub OnClearComplete()
            MyBase.OnClearComplete()
            MultiListBox.ItemBox.Controls.Clear()
        End Sub

        <Description("Returns the selected MultiItem.")> _
        Public Function SelectedItem() As MultiItem

            Return MultiListBox.Items(SelectedIndex)

        End Function

        <Description("Returns the index of the selected MultiItem.")> _
        Public Function SelectedIndex() As Integer
            Dim rt As Integer = 0
            For Each T As MultiItem In List
                If T.Selected Then rt = List.IndexOf(T)
            Next
            Return rt
        End Function

    End Class

#End Region

    Dim WithEvents m_Items As New MultiItemCollection(Me)

    Dim m_FontBoldOnSelect As Boolean = True
    Dim m_FontUnderLineOnHover As Boolean = True

    Dim m_DisabledLineColor As Color = Color.FromArgb(227, 227, 227)
    Dim m_SelectedLineColor As Color = Color.FromArgb(166, 166, 166)

    Dim m_HideSelection As Boolean = False

    Dim m_View As Views = Views.Normal

    Dim m_BorderColor As Color = Color.FromArgb(166, 166, 166)
    Dim m_DrawBorder As Boolean = True

    Public Sub New()

        InitializeComponent()

    End Sub

    Enum Views

        Small = 25

        Normal = 44

        Large = 56

    End Enum

    Private Sub SetBorderColor(ByVal Color As Color)

        TopBorder.BackColor = Color
        RightBorder.BackColor = Color
        BottomBorder.BackColor = Color
        LeftBorder.BackColor = Color

    End Sub

    ''' <summary>
    ''' Gets or sets the view to the items in the control."
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the view to the items in the control.")> <DefaultValue(Views.Normal)> _
    Public Property View As Views
        Get
            Return m_View
        End Get
        Set(ByVal value As Views)
            m_View = value
            For Each i As MultiItem In Items
                i.View = value
            Next
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the items in the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Browsable(False)> <Description("Gets or sets the items in the control.")> _
    Public ReadOnly Property Items() As MultiItemCollection
        Get
            Return m_Items
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the FontBoldOnSelect property to the items in the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the FontBoldOnSelect property to the items in the control.")> _
    Public Property FontBoldOnSelect As Boolean
        Get
            Return m_FontBoldOnSelect
        End Get
        Set(ByVal value As Boolean)
            m_FontBoldOnSelect = value
            For Each i As MultiItem In Items
                i.FontBoldOnSelect = value
            Next
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the FontUnderLineOnHover property to the items in the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the FontUnderLineOnHover property to the items in the control.")> _
    Public Property FontUnderLineOnHover As Boolean
        Get
            Return m_FontUnderLineOnHover
        End Get
        Set(ByVal value As Boolean)
            m_FontUnderLineOnHover = value
            For Each i As MultiItem In Items
                i.FontUnderLineOnHover = value
            Next
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the diabled line color to the items in the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the diabled line color to the items in the control.")> _
    Public Property DisabledLineColor As Color
        Get
            Return m_DisabledLineColor
        End Get
        Set(ByVal value As Color)
            m_DisabledLineColor = value
            For Each i As MultiItem In Items
                i.DisabledLineColor = value
            Next
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the selected line color to the items in the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the selected line color to the items in the control.")> _
    Public Property SelectedLineColor As Color
        Get
            Return m_SelectedLineColor
        End Get
        Set(ByVal value As Color)
            m_SelectedLineColor = value
            For Each i As MultiItem In Items
                i.SelectedLineColor = value
            Next
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the HideSelection property to the items in the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the HideSelection property to the items in the control.")> _
    Public Property HideSelection As Boolean
        Get
            Return m_HideSelection
        End Get
        Set(ByVal value As Boolean)
            m_HideSelection = value
            For Each i As MultiItem In Items
                i.HideSelection = value
            Next
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the border color to the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the border color to the control.")> _
    Public Property BorderColor As Color
        Get
            Return m_BorderColor
        End Get
        Set(ByVal value As Color)
            m_BorderColor = value
            SetBorderColor(m_BorderColor)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the control shoud draw border.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the control shoud draw border.")> _
    Public Property DrawBorder As Boolean
        Get
            Return m_DrawBorder
        End Get
        Set(ByVal value As Boolean)
            m_DrawBorder = value
            TopBorder.Visible = value
            RightBorder.Visible = value
            BottomBorder.Visible = value
            TopBorder.Visible = value
            LeftBorder.Visible = value
        End Set
    End Property

    Private Sub MultiListBox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        For Each i As MultiItem In Items
            i.Size = New Size(Me.Width - 6, i.Height)
        Next

    End Sub
End Class
