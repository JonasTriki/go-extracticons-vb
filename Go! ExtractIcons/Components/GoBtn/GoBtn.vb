Imports System.ComponentModel
Imports System.Drawing.Drawing2D

<DefaultEvent("Click")> _
Public Class GoBtn

    Dim m_HoverImage As Image
    Dim m_PressedImage As Image
    Dim m_DisabledImage As Image
    Dim m_NormalImage As Image
    Dim m_HoverImage_Result As Image
    Dim m_PressedImage_Result As Image
    Dim m_DisabledImage_Result As Image
    Dim m_NormalImage_Result As Image

    Dim m_SecondHoverImage As Image
    Dim m_SecondPressedImage As Image
    Dim m_SecondDisabledImage As Image
    Dim m_SecondNormalImage As Image
    Dim m_SecondHoverImage_Result As Image
    Dim m_SecondPressedImage_Result As Image
    Dim m_SecondDisabledImage_Result As Image
    Dim m_SecondNormalImage_Result As Image

    Dim BaloonTip As New ToolTip

    Dim m_ToolTipText As String
    Dim m_ToolTipOnHover As Boolean = True

    Dim m_BtnStyle As GoBtnStyles = GoBtnStyles.Full
    Dim m_BtnMode As GoBtnModes = GoBtnModes.UseStandardImages

    Dim MouseIsOverBtn As Boolean = False

    <Description("Occurs when the control is clicked.")> _
    Public Shadows Event Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

#Region " Removed properties "

    <Browsable(False)> <EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overloads ReadOnly Property UseWaitCursor() As Boolean
        Get
            Return False
        End Get
    End Property

#End Region

    Enum GoBtnModes

        UseStandardImages = 1

        UseSecondImages = 2

    End Enum

    Enum GoBtnStyles

        Full = 1

        LeftToRight = 2

        RightToLeft = 3

        Middle = 4


    End Enum

    Private Enum GoBtnStates

        Normal

        Hover

        Pressed

        Disabled

    End Enum

    Private Function CreateButtonImage(ByVal Image As Image, ByVal GoBtnState As GoBtnStates) As Image

        Dim BackImg As Image = Nothing

        If m_BtnStyle = GoBtnStyles.Full Then
            If GoBtnState = GoBtnStates.Normal Then
                BackImg = My.Resources.GoBtn_Full_Normal
            ElseIf GoBtnState = GoBtnStates.Hover Then
                BackImg = My.Resources.GoBtn_Full_Hover
            ElseIf GoBtnState = GoBtnStates.Pressed Then
                BackImg = My.Resources.GoBtn_Full_Pressed
            ElseIf GoBtnState = GoBtnStates.Disabled Then
                BackImg = My.Resources.GoBtn_Full_Disabled
            End If
        ElseIf m_BtnStyle = GoBtnStyles.LeftToRight Then
            If GoBtnState = GoBtnStates.Normal Then
                BackImg = My.Resources.GoBtn_LeftToRight_Normal
            ElseIf GoBtnState = GoBtnStates.Hover Then
                BackImg = My.Resources.GoBtn_LeftToRight_Hover
            ElseIf GoBtnState = GoBtnStates.Pressed Then
                BackImg = My.Resources.GoBtn_LeftToRight_Pressed
            ElseIf GoBtnState = GoBtnStates.Disabled Then
                BackImg = My.Resources.GoBtn_LeftToRight_Disabled
            End If
        ElseIf m_BtnStyle = GoBtnStyles.RightToLeft Then
            If GoBtnState = GoBtnStates.Normal Then
                BackImg = My.Resources.GoBtn_RightToLeft_Normal
            ElseIf GoBtnState = GoBtnStates.Hover Then
                BackImg = My.Resources.GoBtn_RightToLeft_Hover
            ElseIf GoBtnState = GoBtnStates.Pressed Then
                BackImg = My.Resources.GoBtn_RightToLeft_Pressed
            ElseIf GoBtnState = GoBtnStates.Disabled Then
                BackImg = My.Resources.GoBtn_RightToLeft_Disabled
            End If
        ElseIf m_BtnStyle = GoBtnStyles.Middle Then
            If GoBtnState = GoBtnStates.Normal Then
                BackImg = My.Resources.GoBtn_Middle_Normal
            ElseIf GoBtnState = GoBtnStates.Hover Then
                BackImg = My.Resources.GoBtn_Middle_Hover
            ElseIf GoBtnState = GoBtnStates.Pressed Then
                BackImg = My.Resources.GoBtn_Middle_Pressed
            ElseIf GoBtnState = GoBtnStates.Disabled Then
                BackImg = My.Resources.GoBtn_Middle_Disabled
            End If
        End If

        Dim g As Graphics = Graphics.FromImage(BackImg)

        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

        If Not IsNothing(Image) Then
            g.DrawImage(Image, New Rectangle((Me.Width - Image.Width) / 2, (Me.Height - Image.Height) / 2, 16, 16))
        End If

        Return BackImg

    End Function

    '''  <summary>
    '''  Gets or sets the style to the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the style to the control.")> _
    Public Property BtnMode() As GoBtnModes
        Get
            Return m_BtnMode
        End Get
        Set(ByVal value As GoBtnModes)
            If Not value = m_BtnMode Then
                m_BtnMode = value
                If value = GoBtnModes.UseStandardImages Then
                    Me.BackgroundImage = CreateButtonImage(m_NormalImage, GoBtnStates.Normal)
                Else
                    Me.BackgroundImage = CreateButtonImage(m_SecondNormalImage, GoBtnStates.Normal)
                End If
            End If
        End Set
    End Property

    '''  <summary>
    '''  Gets or sets the style to the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the style to the control.")> _
    Public Property BtnStyle() As GoBtnStyles
        Get
            Return m_BtnStyle
        End Get
        Set(ByVal value As GoBtnStyles)
            m_BtnStyle = value
            Me.BackgroundImage = CreateButtonImage(m_NormalImage, GoBtnStates.Normal)
        End Set
    End Property

#Region " Normal images... "

    '''  <summary>
    '''  Gets or sets the hover image.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the hover image.")> _
    Public Property HoverImage() As Image
        Get
            Return m_HoverImage
        End Get
        Set(ByVal value As Image)
            m_HoverImage = value
            m_HoverImage_Result = CreateButtonImage(value, GoBtnStates.Hover)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the pressed image.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the pressed image.")> _
    Public Property PressedImage() As Image
        Get
            Return m_PressedImage
        End Get
        Set(ByVal value As Image)
            m_PressedImage = value
            m_PressedImage_Result = CreateButtonImage(value, GoBtnStates.Pressed)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the disabled image.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the disabled image.")> _
    Public Property DisabledImage() As Image
        Get
            Return m_DisabledImage
        End Get
        Set(ByVal value As Image)
            m_DisabledImage = value
            m_DisabledImage_Result = CreateButtonImage(value, GoBtnStates.Disabled)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the normal image.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the normal image.")> _
    Public Property NormalImage() As Image
        Get
            Return m_NormalImage
        End Get
        Set(ByVal value As Image)
            m_NormalImage = value
            m_NormalImage_Result = CreateButtonImage(value, GoBtnStates.Normal)
            If m_BtnMode = GoBtnModes.UseStandardImages Then
                Me.BackgroundImage = m_NormalImage_Result
            End If
        End Set
    End Property

#End Region

#Region " Second images... "

    '''  <summary>
    '''  Gets or sets the second hover image.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the second hover image.")> _
    Public Property SecondHoverImage() As Image
        Get
            Return m_SecondHoverImage
        End Get
        Set(ByVal value As Image)
            m_SecondHoverImage = value
            m_SecondHoverImage_Result = CreateButtonImage(value, GoBtnStates.Hover)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the second pressed image.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the second pressed image.")> _
    Public Property SecondPressedImage() As Image
        Get
            Return m_SecondPressedImage
        End Get
        Set(ByVal value As Image)
            m_SecondPressedImage = value
            m_SecondPressedImage_Result = CreateButtonImage(value, GoBtnStates.Pressed)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the second disabled image.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the second disabled image.")> _
    Public Property SecondDisabledImage() As Image
        Get
            Return m_SecondDisabledImage
        End Get
        Set(ByVal value As Image)
            m_SecondDisabledImage = value
            m_SecondDisabledImage_Result = CreateButtonImage(value, GoBtnStates.Disabled)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the second normal image.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the second normal image.")> _
    Public Property SecondNormalImage() As Image
        Get
            Return m_SecondNormalImage
        End Get
        Set(ByVal value As Image)
            m_SecondNormalImage = value
            m_SecondNormalImage_Result = CreateButtonImage(value, GoBtnStates.Normal)
            If m_BtnMode = GoBtnModes.UseSecondImages Then
                Me.BackgroundImage = m_SecondNormalImage_Result
            End If
        End Set
    End Property

#End Region

    ''' <summary>
    ''' Gets or sets the tooltip text.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the tooltip text.")> _
    Public Property ToolTipText() As String
        Get
            Return m_ToolTipText
        End Get
        Set(ByVal value As String)
            m_ToolTipText = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the tooltip title.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the tooltip title.")> _
    Public Property ToolTipTitle() As String
        Get
            Return BaloonTip.ToolTipTitle
        End Get
        Set(ByVal value As String)
            BaloonTip.ToolTipTitle = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the tooltip icon.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the tooltip icon.")> <DefaultValue(ToolTipIcon.None)> _
    Public Property ToolTipIcon() As ToolTipIcon
        Get
            Return BaloonTip.ToolTipIcon
        End Get
        Set(ByVal value As ToolTipIcon)
            BaloonTip.ToolTipIcon = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the tooltip should be showed on mouse hover.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the tooltip should be showed on mouse hover.")> <DefaultValue(True)> _
    Public Property ToolTipOnHover() As Boolean
        Get
            Return m_ToolTipOnHover
        End Get
        Set(ByVal value As Boolean)
            m_ToolTipOnHover = value
        End Set
    End Property

    ''' <summary>
    ''' Activates the GoBtn when it is clicked by the mouse.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PerformClick()
        RaiseEvent Click(Me, New EventArgs())
    End Sub

    Private Sub GoBtn_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnabledChanged
        If Enabled Then

            Me.BackgroundImage = IIf(m_BtnMode = GoBtnModes.UseStandardImages, m_NormalImage_Result, m_SecondNormalImage_Result)

        ElseIf Not Enabled Then

            Me.BackgroundImage = IIf(m_BtnMode = GoBtnModes.UseStandardImages, m_DisabledImage_Result, m_SecondDisabledImage_Result)

        End If
    End Sub

    Private Sub GoBtn_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        If Enabled Then
            If m_ToolTipOnHover Then
                BaloonTip.Show(m_ToolTipText, Me.ParentForm, MousePosition.X - Me.ParentForm.Location.X, 97)
            End If
        End If
    End Sub

    Private Sub GoBtn_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        If Enabled Then

            Me.BringToFront()

            Me.BackgroundImage = IIf(m_BtnMode = GoBtnModes.UseStandardImages, m_HoverImage_Result, m_SecondHoverImage_Result)

        End If
    End Sub

    Private Sub GoBtn_MouseDown(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        If Enabled Then

            Me.BackgroundImage = IIf(m_BtnMode = GoBtnModes.UseStandardImages, m_PressedImage_Result, m_SecondPressedImage_Result)

        End If
    End Sub

    Private Sub GoBtn_MouseUp(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
        If Enabled Then

            If Me.RectangleToScreen(Me.ClientRectangle).Contains(Me.PointToScreen(New Point(MousePosition.X - Me.ParentForm.Location.X, MousePosition.Y - Me.ParentForm.Location.Y))) Or Me.RectangleToScreen(Me.ClientRectangle).Contains(Me.PointToScreen(New Point(e.X, e.Y))) Then

                Me.BackgroundImage = IIf(m_BtnMode = GoBtnModes.UseStandardImages, m_HoverImage_Result, m_SecondHoverImage_Result)

                If e.Button = Windows.Forms.MouseButtons.Left Then
                    RaiseEvent Click(Me, New EventArgs())
                End If

            Else

                Me.BackgroundImage = m_NormalImage_Result

            End If

        End If
    End Sub

    Private Sub GoBtn_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        If Enabled Then

            Me.BackgroundImage = IIf(m_BtnMode = GoBtnModes.UseStandardImages, m_NormalImage_Result, m_SecondNormalImage_Result)

        End If

        BaloonTip.Hide(Me.ParentForm)

    End Sub
End Class
