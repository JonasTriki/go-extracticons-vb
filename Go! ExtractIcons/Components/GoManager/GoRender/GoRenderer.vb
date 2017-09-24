Imports System.Drawing
Imports System.Drawing.Text
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Collections.Generic

''' <summary>
''' Draw ToolStrips using the GoRender.
''' </summary>
Public Class GoRenderer
    Inherits ToolStripProfessionalRenderer

#Region "GradientItemColors"
    Private Class GradientItemColors
#Region "Public Fields"
        Public cInsideTop1 As Color
        Public cInsideTop2 As Color
        Public cInsideBottom1 As Color
        Public cInsideBottom2 As Color
        Public cFillTop1 As Color
        Public cFillTop2 As Color
        Public cFillBottom1 As Color
        Public cFillBottom2 As Color
        Public cBorder1 As Color
        Public cBorder2 As Color
#End Region

#Region "Identity"
        Public Sub New(ByVal insideTop1 As Color, ByVal insideTop2 As Color, ByVal insideBottom1 As Color, ByVal insideBottom2 As Color, ByVal fillTop1 As Color, ByVal fillTop2 As Color, _
         ByVal fillBottom1 As Color, ByVal fillBottom2 As Color, ByVal border1 As Color, ByVal border2 As Color)
            cInsideTop1 = insideTop1
            cInsideTop2 = insideTop2
            cInsideBottom1 = insideBottom1
            cInsideBottom2 = insideBottom2
            cFillTop1 = fillTop1
            cFillTop2 = fillTop2
            cFillBottom1 = fillBottom1
            cFillBottom2 = fillBottom2
            cBorder1 = border1
            cBorder2 = border2
        End Sub
#End Region
    End Class
#End Region

#Region "Static Metrics"
    Private Shared _gripOffset As Integer = 1
    Private Shared _gripSquare As Integer = 2
    Private Shared _gripSize As Integer = 3
    Private Shared _gripMove As Integer = 4
    Private Shared _gripLines As Integer = 3
    Private Shared _checkInset As Integer = 1
    Private Shared _marginInset As Integer = 2
    Private Shared _separatorInset As Integer = 31
    Private Shared _cutToolItemMenu As Single = 1.0F
    Private Shared _cutContextMenu As Single = 0.0F
    Private Shared _cutMenuItemBack As Single = 1.3F
    Private Shared _contextCheckTickThickness As Single = 1.6F
    Private Shared _statusStripBlend As Blend
#End Region

#Region "Static Colors"

    Friend Shared Shadows ColorTable As New GoColorTable

    'Enabled colors...

    Friend Shared insideTop1 As Color = Color.FromArgb(255, 255, 255)
    Friend Shared insideTop2 As Color = Color.FromArgb(255, 255, 255)
    Friend Shared insideBottom1 As Color = Color.FromArgb(255, 255, 255)
    Friend Shared insideBottom2 As Color = Color.FromArgb(255, 255, 255)

    Friend Shared fillTop1 As Color = Color.FromArgb(255, 255, 255)
    Friend Shared fillTop2 As Color = Color.FromArgb(255, 255, 255)
    Friend Shared fillBottom1 As Color = Color.FromArgb(255, 255, 255)
    Friend Shared fillBottom2 As Color = Color.FromArgb(255, 255, 255)

    Friend Shared borderColor1 As Color = Color.FromArgb(160, 160, 160)
    Friend Shared borderColor2 As Color = Color.FromArgb(160, 160, 160)

    'Disabled colors...

    Friend Shared disabledInsideTop1 As Color = Color.FromArgb(160, 160, 160)
    Friend Shared disabledInsideTop2 As Color = Color.FromArgb(160, 160, 160)
    Friend Shared disabledInsideBottom1 As Color = Color.FromArgb(160, 160, 160)
    Friend Shared disabledInsideBottom2 As Color = Color.FromArgb(160, 160, 160)

    Friend Shared disabledFillTop1 As Color = Color.FromArgb(160, 160, 160)
    Friend Shared disabledFillTop2 As Color = Color.FromArgb(160, 160, 160)
    Friend Shared disabledFillBottom1 As Color = Color.FromArgb(160, 160, 160)
    Friend Shared disabledFillBottom2 As Color = Color.FromArgb(160, 160, 160)

    Friend Shared disabledBorderColor1 As Color = Color.FromArgb(130, 130, 130)
    Friend Shared disabledBorderColor2 As Color = Color.FromArgb(130, 130, 130)

    ' Other stuffs...

    Friend Shared _textDisabled As Color = Color.FromArgb(160, 160, 160)
    Friend Shared _textMenuStripItem As Color = Color.FromArgb(64, 64, 64)
    Friend Shared _textStatusStripItem As Color = Color.FromArgb(64, 64, 64)
    Friend Shared _textContextMenuItem As Color = Color.FromArgb(64, 64, 64)
    Friend Shared _textSelected As Color = Color.FromArgb(64, 64, 64)
    Friend Shared _arrowDisabled As Color = Color.FromArgb(64, 64, 64)
    Friend Shared _arrowLight As Color = Color.FromArgb(64, 64, 64)
    Friend Shared _arrowDark As Color = Color.FromArgb(64, 64, 64)
    Friend Shared _arrowSelected As Color = Color.FromArgb(64, 64, 64)
    Friend Shared _separatorMenuLight As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _separatorMenuDark As Color = Color.FromArgb(160, 160, 160)
    Friend Shared _contextMenuBack As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _contextCheckBorder As Color = Color.Transparent
    Friend Shared _contextCheckBorderSelected As Color = Color.Transparent
    Friend Shared _contextCheckTick As Color = Color.FromArgb(64, 64, 64)
    Friend Shared _contextCheckTickSelected As Color = Color.FromArgb(64, 64, 64)
    Friend Shared _statusStripBorderDark As Color = Color.FromArgb(160, 160, 160)
    Friend Shared _statusStripBorderLight As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _gripDark As Color = Color.FromArgb(160, 160, 160)
    Friend Shared _gripLight As Color = Color.FromArgb(255, 255, 255)
    Private Shared _itemContextItemEnabledColors As New GradientItemColors(insideTop1, insideTop2, insideBottom1, insideBottom2, fillTop1, fillTop2, _
    fillBottom1, fillBottom2, borderColor1, borderColor2)
    Private Shared _itemDisabledColors As New GradientItemColors(disabledInsideTop1, disabledInsideTop2, disabledInsideBottom1, disabledInsideBottom2, disabledFillTop1, disabledFillTop2, _
    disabledFillBottom1, disabledFillBottom2, disabledBorderColor1, disabledBorderColor2)
    Private Shared _itemToolItemSelectedColors As New GradientItemColors(insideTop1, insideTop2, insideBottom1, insideBottom2, fillTop1, fillTop2, _
    fillBottom1, fillBottom2, borderColor1, borderColor2)
    Private Shared _itemToolItemPressedColors As New GradientItemColors(insideTop1, insideTop2, insideBottom1, insideBottom2, fillTop1, fillTop2, _
    fillBottom1, fillBottom2, borderColor1, borderColor2)
    Private Shared _itemToolItemCheckedColors As New GradientItemColors(insideTop1, insideTop2, insideBottom1, insideBottom2, fillTop1, fillTop2, _
    fillBottom1, fillBottom2, borderColor1, borderColor2)
    Private Shared _itemToolItemCheckPressColors As New GradientItemColors(insideTop1, insideTop2, insideBottom1, insideBottom2, fillTop1, fillTop2, _
    fillBottom1, fillBottom2, borderColor1, borderColor2)
#End Region

#Region "Identity"
    Shared Sub New()
        ' One time creation of the blend for the status strip gradient brush
        _statusStripBlend = New Blend()
        _statusStripBlend.Positions = New Single() {0.0F, 0.25F, 0.25F, 0.57F, 0.86F, 1.0F}
        _statusStripBlend.Factors = New Single() {0.1F, 0.6F, 1.0F, 0.4F, 0.0F, 0.95F}
    End Sub

    ''' <summary>
    ''' Initialize a new instance of the GoRender class.
    ''' </summary>
    Public Sub New()
        MyBase.New(ColorTable)
    End Sub
#End Region

#Region "OnRenderArrow"
    ''' <summary>
    ''' Raises the RenderArrow event. 
    ''' </summary>
    ''' <param name="e">An ToolStripArrowRenderEventArgs containing the event data.</param>
    Protected Overrides Sub OnRenderArrow(ByVal e As ToolStripArrowRenderEventArgs)
        ' Cannot paint a zero sized area
        If (e.ArrowRectangle.Width > 0) AndAlso (e.ArrowRectangle.Height > 0) Then
            ' Create a path that is used to fill the arrow
            Using arrowPath As GraphicsPath = CreateArrowPath(e.Item, e.ArrowRectangle, e.Direction)
                ' Get the rectangle that encloses the arrow and expand slightly
                ' so that the gradient is always within the expanding bounds
                Dim boundsF As RectangleF = arrowPath.GetBounds()
                boundsF.Inflate(1.0F, 1.0F)

                Dim color1 As Color = (If(e.Item.Enabled, _arrowLight, _arrowDisabled))
                Dim color2 As Color = (If(e.Item.Enabled, _arrowDark, _arrowDisabled))

                If e.Item.Selected Then
                    color1 = _arrowSelected
                    color2 = _arrowSelected
                End If

                Dim angle As Single = 0

                ' Use gradient angle to match the arrow direction
                Select Case e.Direction
                    Case ArrowDirection.Right
                        angle = 0
                        Exit Select
                    Case ArrowDirection.Left
                        angle = 180.0F
                        Exit Select
                    Case ArrowDirection.Down
                        angle = 90.0F
                        Exit Select
                    Case ArrowDirection.Up
                        angle = 270.0F
                        Exit Select
                End Select

                ' Draw the actual arrow using a gradient
                Using arrowBrush As New LinearGradientBrush(boundsF, color1, color2, angle)
                    e.Graphics.FillPath(arrowBrush, arrowPath)
                End Using
            End Using
        End If
    End Sub
#End Region

#Region "OnRenderButtonBackground"
    ''' <summary>
    ''' Raises the RenderButtonBackground event. 
    ''' </summary>
    ''' <param name="e">An ToolStripItemRenderEventArgs containing the event data.</param>
    Protected Overrides Sub OnRenderButtonBackground(ByVal e As ToolStripItemRenderEventArgs)
        ' Cast to correct type
        Dim button As ToolStripButton = DirectCast(e.Item, ToolStripButton)

        If button.Selected OrElse button.Pressed OrElse button.Checked Then
            RenderToolButtonBackground(e.Graphics, button, e.ToolStrip)
        End If
    End Sub
#End Region

#Region "OnRenderDropDownButtonBackground"
    ''' <summary>
    ''' Raises the RenderDropDownButtonBackground event. 
    ''' </summary>
    ''' <param name="e">An ToolStripItemRenderEventArgs containing the event data.</param>
    Protected Overrides Sub OnRenderDropDownButtonBackground(ByVal e As ToolStripItemRenderEventArgs)
        If e.Item.Selected OrElse e.Item.Pressed Then
            RenderToolDropButtonBackground(e.Graphics, e.Item, e.ToolStrip)
        End If
    End Sub
#End Region

#Region "OnRenderItemCheck"
    ''' <summary>
    ''' Raises the RenderItemCheck event. 
    ''' </summary>
    ''' <param name="e">An ToolStripItemImageRenderEventArgs containing the event data.</param>
    Protected Overrides Sub OnRenderItemCheck(ByVal e As ToolStripItemImageRenderEventArgs)
        ' Staring size of the checkbox is the image rectangle
        Dim checkBox As Rectangle = e.ImageRectangle

        ' Make the border of the check box 1 pixel bigger on all sides, as a minimum
        checkBox.Inflate(1, 1)

        ' Can we extend upwards?
        If checkBox.Top > _checkInset Then
            Dim diff As Integer = checkBox.Top - _checkInset
            checkBox.Y -= diff
            checkBox.Height += diff
        End If

        ' Can we extend downwards?
        If checkBox.Height <= (e.Item.Bounds.Height - (_checkInset * 2)) Then
            Dim diff As Integer = e.Item.Bounds.Height - (_checkInset * 2) - checkBox.Height
            checkBox.Height += diff
        End If

        ' Drawing with anti aliasing to create smoother appearance
        Using uaa As New UseAntiAlias(e.Graphics)
            ' Create border path for the check box
            Using borderPath As GraphicsPath = CreateBorderPath(checkBox, _cutMenuItemBack)
                ' Fill the background in a solid color
                Using fillBrush As New SolidBrush(ColorTable.CheckBackground)
                    e.Graphics.FillPath(fillBrush, borderPath)
                End Using

                ' Draw the border around the check box
                Using borderPen As New Pen(DirectCast(IIf(e.Item.Selected, _contextCheckBorderSelected, _contextCheckBorder), Color))
                    e.Graphics.DrawPath(borderPen, borderPath)
                End Using

                ' If there is not an image, then we can draw the tick, square etc...
                If e.Image IsNot Nothing Then
                    Dim checkState__1 As CheckState = CheckState.Unchecked

                    ' Extract the check state from the item
                    If TypeOf e.Item Is ToolStripMenuItem Then
                        Dim item As ToolStripMenuItem = DirectCast(e.Item, ToolStripMenuItem)
                        checkState__1 = item.CheckState
                    End If

                    ' Decide what graphic to draw
                    Select Case checkState__1
                        Case CheckState.Checked
                            ' Create a path for the tick
                            Using tickPath As GraphicsPath = CreateTickPath(checkBox)
                                ' Draw the tick with a thickish brush
                                Using tickPen As New Pen(DirectCast(IIf(e.Item.Selected, _contextCheckTickSelected, _contextCheckTick), Color), _contextCheckTickThickness)
                                    e.Graphics.DrawPath(tickPen, tickPath)
                                End Using
                            End Using
                            Exit Select
                        Case CheckState.Indeterminate
                            ' Create a path for the indeterminate diamond
                            Using tickPath As GraphicsPath = CreateIndeterminatePath(checkBox)
                                ' Draw the tick with a thickish brush
                                Using tickBrush As New SolidBrush(DirectCast(IIf(e.Item.Selected, _contextCheckTickSelected, _contextCheckTick), Color))
                                    e.Graphics.FillPath(tickBrush, tickPath)
                                End Using
                            End Using
                            Exit Select
                    End Select
                End If
            End Using
        End Using
    End Sub
#End Region

#Region "OnRenderItemText"
    ''' <summary>
    ''' Raises the RenderItemText event. 
    ''' </summary>
    ''' <param name="e">An ToolStripItemTextRenderEventArgs containing the event data.</param>
    Protected Overrides Sub OnRenderItemText(ByVal e As ToolStripItemTextRenderEventArgs)
        If (TypeOf e.ToolStrip Is MenuStrip) OrElse (TypeOf e.ToolStrip Is ToolStrip) OrElse (TypeOf e.ToolStrip Is ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is ToolStripDropDownMenu) Then
            ' We set the color depending on the enabled state
            If Not e.Item.Enabled Then
                e.TextColor = _textDisabled
            ElseIf e.Item.Selected Then
                If DirectCast(e.Item, ToolStripMenuItem).DropDown.Visible And DirectCast(e.Item, ToolStripMenuItem).OwnerItem Is Nothing And Not (TypeOf e.ToolStrip Is ContextMenuStrip) Then
                    e.TextColor = _textMenuStripItem
                Else
                    e.TextColor = _textSelected
                End If
            Else

                If (TypeOf e.ToolStrip Is MenuStrip) AndAlso Not e.Item.Pressed AndAlso Not e.Item.Selected Then
                    e.TextColor = _textMenuStripItem
                ElseIf (TypeOf e.ToolStrip Is StatusStrip) AndAlso Not e.Item.Pressed AndAlso Not e.Item.Selected Then
                    e.TextColor = _textStatusStripItem
                Else
                    e.TextColor = _textContextMenuItem
                End If
            End If

            ' All text is draw using the ClearTypeGridFit text rendering hint
            Using clearTypeGridFit As New UseClearTypeGridFit(e.Graphics)
                MyBase.OnRenderItemText(e)
            End Using
        Else
            MyBase.OnRenderItemText(e)
        End If
    End Sub
#End Region

#Region "OnRenderItemImage"
    ''' <summary>
    ''' Raises the RenderItemImage event. 
    ''' </summary>
    ''' <param name="e">An ToolStripItemImageRenderEventArgs containing the event data.</param>
    Protected Overrides Sub OnRenderItemImage(ByVal e As ToolStripItemImageRenderEventArgs)
        ' We only override the image drawing for context menus
        If (TypeOf e.ToolStrip Is ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is ToolStripDropDownMenu) Then
            If e.Image IsNot Nothing Then
                If e.Item.Enabled Then
                    e.Graphics.DrawImage(e.Image, e.ImageRectangle)
                Else
                    'bit correction : drawing the image with the needed size
                    ControlPaint.DrawImageDisabled(e.Graphics, e.Image, e.ImageRectangle.X, e.ImageRectangle.Y, Color.Transparent)
                End If
            End If
        Else
            MyBase.OnRenderItemImage(e)
        End If
    End Sub
#End Region

#Region "OnRenderMenuItemBackground"
    ''' <summary>
    ''' Raises the RenderMenuItemBackground event. 
    ''' </summary>
    ''' <param name="e">An ToolStripItemRenderEventArgs containing the event data.</param>
    Protected Overrides Sub OnRenderMenuItemBackground(ByVal e As ToolStripItemRenderEventArgs)
        If (TypeOf e.ToolStrip Is MenuStrip) OrElse (TypeOf e.ToolStrip Is ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is ToolStripDropDownMenu) Then
            If (e.Item.Pressed) AndAlso (TypeOf e.ToolStrip Is MenuStrip) Then
                ' Draw the menu/tool strip as a header for a context menu item
                DrawContextMenuHeader(e.Graphics, e.Item)
            Else
                ' We only draw a background if the item is selected and enabled
                If e.Item.Selected Then
                    If e.Item.Enabled Then
                        ' Do we draw as a menu strip or context menu item?
                        If TypeOf e.ToolStrip Is MenuStrip Then
                            DrawGradientToolItem(e.Graphics, e.Item, _itemToolItemSelectedColors)
                        Else
                            DrawGradientContextMenuItem(e.Graphics, e.Item, _itemContextItemEnabledColors)
                        End If
                    Else
                        ' Get the mouse position in tool strip coordinates
                        Dim mousePos As Point = e.ToolStrip.PointToClient(Control.MousePosition)

                        ' If the mouse is not in the item area, then draw disabled
                        If Not e.Item.Bounds.Contains(mousePos) Then
                            ' Do we draw as a menu strip or context menu item?
                            If TypeOf e.ToolStrip Is MenuStrip Then
                                DrawGradientToolItem(e.Graphics, e.Item, _itemDisabledColors)
                            Else
                                DrawGradientContextMenuItem(e.Graphics, e.Item, _itemDisabledColors)
                            End If
                        End If
                    End If
                End If
            End If
        Else
            MyBase.OnRenderMenuItemBackground(e)
        End If
    End Sub
#End Region

#Region "OnRenderSplitButtonBackground"
    ''' <summary>
    ''' Raises the RenderSplitButtonBackground event. 
    ''' </summary>
    ''' <param name="e">An ToolStripItemRenderEventArgs containing the event data.</param>
    Protected Overrides Sub OnRenderSplitButtonBackground(ByVal e As ToolStripItemRenderEventArgs)
        If e.Item.Selected OrElse e.Item.Pressed Then
            ' Cast to correct type
            Dim splitButton As ToolStripSplitButton = DirectCast(e.Item, ToolStripSplitButton)

            ' Draw the border and background
            RenderToolSplitButtonBackground(e.Graphics, splitButton, e.ToolStrip)

            ' Get the rectangle that needs to show the arrow
            Dim arrowBounds As Rectangle = splitButton.DropDownButtonBounds

            ' Draw the arrow on top of the background
            OnRenderArrow(New ToolStripArrowRenderEventArgs(e.Graphics, splitButton, arrowBounds, SystemColors.ControlText, ArrowDirection.Down))
        Else
            MyBase.OnRenderSplitButtonBackground(e)
        End If
    End Sub
#End Region

#Region "OnRenderStatusStripSizingGrip"
    ''' <summary>
    ''' Raises the RenderStatusStripSizingGrip event. 
    ''' </summary>
    ''' <param name="e">An ToolStripRenderEventArgs containing the event data.</param>
    Protected Overrides Sub OnRenderStatusStripSizingGrip(ByVal e As ToolStripRenderEventArgs)
        Using darkBrush As New SolidBrush(_gripDark), lightBrush As New SolidBrush(_gripLight)
            ' Do we need to invert the drawing edge?
            Dim rtl As Boolean = (e.ToolStrip.RightToLeft = RightToLeft.Yes)

            ' Find vertical position of the lowest grip line
            Dim y As Integer = e.AffectedBounds.Bottom - _gripSize * 2 + 1

            ' Draw three lines of grips
            For i As Integer = _gripLines To 1 Step -1
                ' Find the rightmost grip position on the line
                Dim x As Integer = (If(rtl, e.AffectedBounds.Left + 1, e.AffectedBounds.Right - _gripSize * 2 + 1))

                ' Draw grips from right to left on line
                For j As Integer = 0 To i - 1
                    ' Just the single grip glyph
                    DrawGripGlyph(e.Graphics, x, y, darkBrush, lightBrush)

                    ' Move left to next grip position
                    x -= (If(rtl, -_gripMove, _gripMove))
                Next

                ' Move upwards to next grip line
                y -= _gripMove
            Next
        End Using
    End Sub
#End Region

#Region "OnRenderToolStripContentPanelBackground"
    ''' <summary>
    ''' Raises the RenderToolStripContentPanelBackground event. 
    ''' </summary>
    ''' <param name="e">An ToolStripContentPanelRenderEventArgs containing the event data.</param>
    Protected Overrides Sub OnRenderToolStripContentPanelBackground(ByVal e As ToolStripContentPanelRenderEventArgs)
        ' Must call base class, otherwise the subsequent drawing does not appear!
        MyBase.OnRenderToolStripContentPanelBackground(e)

        ' Cannot paint a zero sized area
        If (e.ToolStripContentPanel.Width > 0) AndAlso (e.ToolStripContentPanel.Height > 0) Then
            Using backBrush As New LinearGradientBrush(e.ToolStripContentPanel.ClientRectangle, ColorTable.ToolStripContentPanelGradientEnd, ColorTable.ToolStripContentPanelGradientBegin, 90.0F)
                e.Graphics.FillRectangle(backBrush, e.ToolStripContentPanel.ClientRectangle)
            End Using
        End If
    End Sub
#End Region

#Region "OnRenderSeparator"
    ''' <summary>
    ''' Raises the RenderSeparator event. 
    ''' </summary>
    ''' <param name="e">An ToolStripSeparatorRenderEventArgs containing the event data.</param>
    Protected Overrides Sub OnRenderSeparator(ByVal e As ToolStripSeparatorRenderEventArgs)
        If (TypeOf e.ToolStrip Is ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is ToolStripDropDownMenu) Then
            ' Create the light and dark line pens
            Using lightPen As New Pen(_separatorMenuLight), darkPen As New Pen(_separatorMenuDark)
                lightPen.DashStyle = DashStyle.Custom
                lightPen.DashPattern = New Single() {2.0F, 2.0F}
                darkPen.DashStyle = DashStyle.Custom
                darkPen.DashPattern = New Single() {2.0F, 2.0F}
                DrawSeparator(e.Graphics, e.Vertical, e.Item.Bounds, lightPen, darkPen, _separatorInset, _
                 (e.ToolStrip.RightToLeft = RightToLeft.Yes))
            End Using
        ElseIf TypeOf e.ToolStrip Is StatusStrip Then
            ' Create the light and dark line pens
            Using lightPen As New Pen(ColorTable.SeparatorLight), darkPen As New Pen(ColorTable.SeparatorDark)
                DrawSeparator(e.Graphics, e.Vertical, e.Item.Bounds, lightPen, darkPen, 0, _
                 False)
            End Using
        ElseIf TypeOf e.ToolStrip Is MenuStrip Then
            ' Create the light and dark line pens
            Using lightPen As New Pen(ColorTable.SeparatorLight), darkPen As New Pen(ColorTable.SeparatorDark)
                lightPen.DashPattern = New Single() {2.0F, 2.0F}
                darkPen.DashStyle = DashStyle.Custom
                darkPen.DashPattern = New Single() {2.0F, 2.0F}
                DrawSeparator(e.Graphics, e.Vertical, e.Item.Bounds, lightPen, darkPen, _separatorInset, _
                 (e.ToolStrip.RightToLeft = RightToLeft.Yes))
            End Using
        Else
            MyBase.OnRenderSeparator(e)
        End If
    End Sub
#End Region

#Region "OnRenderToolStripBackground"
    ''' <summary>
    ''' Raises the RenderToolStripBackground event. 
    ''' </summary>
    ''' <param name="e">An ToolStripRenderEventArgs containing the event data.</param>
    Protected Overrides Sub OnRenderToolStripBackground(ByVal e As ToolStripRenderEventArgs)
        If (TypeOf e.ToolStrip Is ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is ToolStripDropDownMenu) Then
            ' Create border and clipping paths
            Using borderPath As GraphicsPath = CreateBorderPath(e.AffectedBounds, _cutContextMenu), clipPath As GraphicsPath = CreateClipBorderPath(e.AffectedBounds, _cutContextMenu)
                ' Clip all drawing to within the border path
                Using clipping As New UseClipping(e.Graphics, clipPath)
                    ' Create the background brush
                    Using backBrush As New SolidBrush(_contextMenuBack)
                        e.Graphics.FillPath(backBrush, borderPath)
                    End Using
                End Using
            End Using
        ElseIf TypeOf e.ToolStrip Is StatusStrip Then
            ' We do not paint the top two pixel lines, so are drawn by the status strip border render method
            Dim backRect As New RectangleF(0, 1.5F, e.ToolStrip.Width, e.ToolStrip.Height - 2)

            ' Cannot paint a zero sized area
            If (backRect.Width > 0) AndAlso (backRect.Height > 0) Then
                Using backBrush As New LinearGradientBrush(backRect, ColorTable.StatusStripGradientBegin, ColorTable.StatusStripGradientEnd, 90.0F)
                    backBrush.Blend = _statusStripBlend
                    e.Graphics.FillRectangle(backBrush, backRect)
                End Using
            End If
        Else
            MyBase.OnRenderToolStripBackground(e)
        End If
    End Sub
#End Region

#Region "OnRenderImageMargin"
    ''' <summary>
    ''' Raises the RenderImageMargin event. 
    ''' </summary>
    ''' <param name="e">An ToolStripRenderEventArgs containing the event data.</param>
    Protected Overrides Sub OnRenderImageMargin(ByVal e As ToolStripRenderEventArgs)
        If (TypeOf e.ToolStrip Is ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is ToolStripDropDownMenu) Then
            ' Start with the total margin area
            Dim marginRect As Rectangle = e.AffectedBounds

            ' Do we need to draw with separator on the opposite edge?
            Dim rtl As Boolean = (e.ToolStrip.RightToLeft = RightToLeft.Yes)

            marginRect.Y += _marginInset
            marginRect.Height -= _marginInset * 2

            ' Reduce so it is inside the border
            If Not rtl Then
                marginRect.X += _marginInset
            Else
                marginRect.X += _marginInset / 2
            End If

            ' Draw the entire margine area in a solid color
            Using backBrush As New SolidBrush(ColorTable.ImageMarginGradientBegin)
                e.Graphics.FillRectangle(backBrush, marginRect)
            End Using

            ' Create the light and dark line pens
            Using lightPen As New Pen(_separatorMenuLight), darkPen As New Pen(_separatorMenuDark)
                If Not rtl Then
                    ' Draw the light and dark lines on the right hand side
                    e.Graphics.DrawLine(lightPen, marginRect.Right, marginRect.Top, marginRect.Right, marginRect.Bottom)
                    e.Graphics.DrawLine(darkPen, marginRect.Right - 1, marginRect.Top, marginRect.Right - 1, marginRect.Bottom)
                Else
                    ' Draw the light and dark lines on the left hand side
                    e.Graphics.DrawLine(lightPen, marginRect.Left - 1, marginRect.Top, marginRect.Left - 1, marginRect.Bottom)
                    e.Graphics.DrawLine(darkPen, marginRect.Left, marginRect.Top, marginRect.Left, marginRect.Bottom)
                End If
            End Using
        Else
            MyBase.OnRenderImageMargin(e)
        End If
    End Sub
#End Region

#Region "OnRenderToolStripBorder"
    ''' <summary>
    ''' Raises the RenderToolStripBorder event. 
    ''' </summary>
    ''' <param name="e">An ToolStripRenderEventArgs containing the event data.</param>
    Protected Overrides Sub OnRenderToolStripBorder(ByVal e As ToolStripRenderEventArgs)
        If (TypeOf e.ToolStrip Is ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is ToolStripDropDownMenu) Then
            ' If there is a connected area to be drawn
            If Not e.ConnectedArea.IsEmpty Then
                Using excludeBrush As New SolidBrush(_contextMenuBack)
                    e.Graphics.FillRectangle(excludeBrush, e.ConnectedArea)
                End Using
            End If

            ' Create border and clipping paths
            Using borderPath As GraphicsPath = CreateBorderPath(e.AffectedBounds, e.ConnectedArea, _cutContextMenu), insidePath As GraphicsPath = CreateInsideBorderPath(e.AffectedBounds, e.ConnectedArea, _cutContextMenu), clipPath As GraphicsPath = CreateClipBorderPath(e.AffectedBounds, e.ConnectedArea, _cutContextMenu)
                ' Create the different pen colors we need
                Using borderPen As New Pen(ColorTable.MenuBorder), insidePen As New Pen(_separatorMenuLight)
                    ' Clip all drawing to within the border path
                    Using clipping As New UseClipping(e.Graphics, clipPath)
                        ' Drawing with anti aliasing to create smoother appearance
                        Using uaa As New UseAntiAlias(e.Graphics)
                            ' Draw the inside area first
                            e.Graphics.DrawPath(insidePen, insidePath)

                            ' Draw the border area second, so any overlapping gives it priority
                            e.Graphics.DrawPath(borderPen, borderPath)
                        End Using

                        ' Draw the pixel at the bottom right of the context menu
                        e.Graphics.DrawLine(borderPen, e.AffectedBounds.Right, e.AffectedBounds.Bottom, e.AffectedBounds.Right - 1, e.AffectedBounds.Bottom - 1)
                    End Using
                End Using
            End Using
        ElseIf TypeOf e.ToolStrip Is StatusStrip Then
            ' Draw two lines at top of the status strip
            Using darkBorder As New Pen(_statusStripBorderDark), lightBorder As New Pen(_statusStripBorderLight)
                e.Graphics.DrawLine(darkBorder, 0, 0, e.ToolStrip.Width, 0)
                e.Graphics.DrawLine(lightBorder, 0, 1, e.ToolStrip.Width, 1)
            End Using
        Else
            MyBase.OnRenderToolStripBorder(e)
        End If
    End Sub
#End Region

#Region "Implementation"
    Private Sub RenderToolButtonBackground(ByVal g As Graphics, ByVal button As ToolStripButton, ByVal toolstrip As ToolStrip)
        ' We only draw a background if the item is selected or being pressed
        If button.Enabled Then
            If button.Checked Then
                If button.Pressed Then
                    DrawGradientToolItem(g, button, _itemToolItemPressedColors)
                ElseIf button.Selected Then
                    DrawGradientToolItem(g, button, _itemToolItemCheckPressColors)
                Else
                    DrawGradientToolItem(g, button, _itemToolItemCheckedColors)
                End If
            Else
                If button.Pressed Then
                    DrawGradientToolItem(g, button, _itemToolItemPressedColors)
                ElseIf button.Selected Then
                    DrawGradientToolItem(g, button, _itemToolItemSelectedColors)
                End If
            End If
        Else
            If button.Selected Then
                ' Get the mouse position in tool strip coordinates
                Dim mousePos As Point = toolstrip.PointToClient(Control.MousePosition)

                ' If the mouse is not in the item area, then draw disabled
                If Not button.Bounds.Contains(mousePos) Then
                    DrawGradientToolItem(g, button, _itemDisabledColors)
                End If
            End If
        End If
    End Sub

    Private Sub RenderToolDropButtonBackground(ByVal g As Graphics, ByVal item As ToolStripItem, ByVal toolstrip As ToolStrip)
        ' We only draw a background if the item is selected or being pressed
        If item.Selected OrElse item.Pressed Then
            If item.Enabled Then
                If item.Pressed Then
                    DrawContextMenuHeader(g, item)
                Else
                    DrawGradientToolItem(g, item, _itemToolItemSelectedColors)
                End If
            Else
                ' Get the mouse position in tool strip coordinates
                Dim mousePos As Point = toolstrip.PointToClient(Control.MousePosition)

                ' If the mouse is not in the item area, then draw disabled
                If Not item.Bounds.Contains(mousePos) Then
                    DrawGradientToolItem(g, item, _itemDisabledColors)
                End If
            End If
        End If

    End Sub

    Private Sub RenderToolSplitButtonBackground(ByVal g As Graphics, ByVal splitButton As ToolStripSplitButton, ByVal toolstrip As ToolStrip)
        ' We only draw a background if the item is selected or being pressed
        If splitButton.Selected OrElse splitButton.Pressed Then
            If splitButton.Enabled Then
                If Not splitButton.Pressed AndAlso splitButton.ButtonPressed Then
                    DrawGradientToolSplitItem(g, splitButton, _itemToolItemPressedColors, _itemToolItemSelectedColors, _itemContextItemEnabledColors)
                ElseIf splitButton.Pressed AndAlso Not splitButton.ButtonPressed Then
                    DrawContextMenuHeader(g, splitButton)
                Else
                    DrawGradientToolSplitItem(g, splitButton, _itemToolItemSelectedColors, _itemToolItemSelectedColors, _itemContextItemEnabledColors)
                End If
            Else
                ' Get the mouse position in tool strip coordinates
                Dim mousePos As Point = toolstrip.PointToClient(Control.MousePosition)

                ' If the mouse is not in the item area, then draw disabled
                If Not splitButton.Bounds.Contains(mousePos) Then
                    DrawGradientToolItem(g, splitButton, _itemDisabledColors)
                End If
            End If
        End If

    End Sub

    Public Function DrawArc(ByVal Rectangle As Rectangle, Optional ByVal Radius As Integer = 4) As GraphicsPath

        Dim Path As New GraphicsPath

        Path.AddArc(Rectangle.X, Rectangle.Y, Radius, Radius, 180, 90)
        Path.AddArc(Rectangle.Width - Radius, Rectangle.Y, Radius, Radius, 270, 90)
        Path.AddArc(Rectangle.Width - Radius, Rectangle.Height - Radius, Radius, Radius, 0, 90)
        Path.AddArc(Rectangle.X, Rectangle.Height - Radius, Radius, Radius, 90, 90)
        Path.CloseFigure()

        Return Path

    End Function

    Private Sub DrawGradientToolItem(ByVal g As Graphics, ByVal item As ToolStripItem, ByVal colors As GradientItemColors)
        ' Perform drawing into the entire background of the item
        DrawGradientItem(g, New Rectangle(Point.Empty, item.Bounds.Size), colors)
    End Sub

    Private Sub DrawGradientToolSplitItem(ByVal g As Graphics, ByVal splitButton As ToolStripSplitButton, ByVal colorsButton As GradientItemColors, ByVal colorsDrop As GradientItemColors, ByVal colorsSplit As GradientItemColors)
        ' Create entire area and just the drop button area rectangles
        Dim backRect As New Rectangle(Point.Empty, splitButton.Bounds.Size)
        Dim backRectDrop As Rectangle = splitButton.DropDownButtonBounds

        ' Cannot paint zero sized areas
        If (backRect.Width > 0) AndAlso (backRectDrop.Width > 0) AndAlso (backRect.Height > 0) AndAlso (backRectDrop.Height > 0) Then
            ' Area that is the normal button starts as everything
            Dim backRectButton As Rectangle = backRect

            ' The X offset to draw the split line
            Dim splitOffset As Integer

            ' Is the drop button on the right hand side of entire area?
            If backRectDrop.X > 0 Then
                backRectButton.Width = backRectDrop.Left
                backRectDrop.X -= 1
                backRectDrop.Width += 1
                splitOffset = backRectDrop.X
            Else
                backRectButton.Width -= backRectDrop.Width - 2
                backRectButton.X = backRectDrop.Right - 1
                backRectDrop.Width += 1
                splitOffset = backRectDrop.Right - 1
            End If

            ' Create border path around the item
            Using borderPath As GraphicsPath = CreateBorderPath(backRect, _cutMenuItemBack)
                ' Draw the normal button area background
                DrawGradientBack(g, backRectButton, colorsButton)

                ' Draw the drop button area background
                DrawGradientBack(g, backRectDrop, colorsDrop)

                ' Draw the split line between the areas
                Using splitBrush As New LinearGradientBrush(New Rectangle(backRect.X + splitOffset, backRect.Top, 1, backRect.Height + 1), colorsSplit.cBorder1, colorsSplit.cBorder2, 90.0F)
                    ' Sigma curve, so go from color1 to color2 and back to color1 again
                    splitBrush.SetSigmaBellShape(0.5F)

                    ' Convert the brush to a pen for DrawPath call
                    Using splitPen As New Pen(splitBrush)
                        g.DrawLine(splitPen, backRect.X + splitOffset, backRect.Top + 1, backRect.X + splitOffset, backRect.Bottom - 1)
                    End Using
                End Using

                ' Draw the border of the entire item
                DrawGradientBorder(g, backRect, colorsButton)
            End Using
        End If
    End Sub

    Private Sub DrawContextMenuHeader(ByVal g As Graphics, ByVal item As ToolStripItem)
        ' Get the rectangle the is the items area
        Dim itemRect As New Rectangle(Point.Empty, item.Bounds.Size)

        ' Create border and clipping paths
        Using borderPath As GraphicsPath = CreateBorderPath(itemRect, _cutToolItemMenu), insidePath As GraphicsPath = CreateInsideBorderPath(itemRect, _cutToolItemMenu), clipPath As GraphicsPath = CreateClipBorderPath(itemRect, _cutToolItemMenu)
            ' Clip all drawing to within the border path
            Using clipping As New UseClipping(g, clipPath)
                ' Draw the entire background area first
                Using backBrush As New SolidBrush(_separatorMenuLight)
                    g.FillPath(backBrush, borderPath)
                End Using

                ' Draw the border
                Using borderPen As New Pen(ColorTable.MenuBorder)
                    g.DrawPath(borderPen, borderPath)
                End Using
            End Using
        End Using
    End Sub

    Private Sub DrawGradientContextMenuItem(ByVal g As Graphics, ByVal item As ToolStripItem, ByVal colors As GradientItemColors)
        ' Do we need to draw with separator on the opposite edge?
        Dim backRect As New Rectangle(2, 0, item.Bounds.Width - 3, item.Bounds.Height)

        ' Perform actual drawing into the background
        DrawGradientItem(g, backRect, colors)
    End Sub

    Private Sub DrawGradientItem(ByVal g As Graphics, ByVal backRect As Rectangle, ByVal colors As GradientItemColors)
        ' Cannot paint a zero sized area
        If (backRect.Width > 0) AndAlso (backRect.Height > 0) Then
            ' Draw the background of the entire item
            DrawGradientBack(g, backRect, colors)

            ' Draw the border of the entire item
            DrawGradientBorder(g, backRect, colors)
        End If
    End Sub

    Private Sub DrawGradientBack(ByVal g As Graphics, ByVal backRect As Rectangle, ByVal colors As GradientItemColors)
        ' Reduce rect draw drawing inside the border
        backRect.Inflate(-1, -1)

        Dim y2 As Integer = backRect.Height / 2
        Dim backRect1 As New Rectangle(backRect.X, backRect.Y, backRect.Width, y2)
        Dim backRect2 As New Rectangle(backRect.X, backRect.Y + y2, backRect.Width, backRect.Height - y2)
        Dim backRect1I As Rectangle = backRect1
        Dim backRect2I As Rectangle = backRect2
        backRect1I.Inflate(1, 1)
        backRect2I.Inflate(1, 1)

        Using insideBrush1 As New LinearGradientBrush(backRect1I, colors.cInsideTop1, colors.cInsideTop2, 90.0F), insideBrush2 As New LinearGradientBrush(backRect2I, colors.cInsideBottom1, colors.cInsideBottom2, 90.0F)
            g.FillRectangle(insideBrush1, backRect1)
            g.FillRectangle(insideBrush2, backRect2)
        End Using

        y2 = backRect.Height / 2
        backRect1 = New Rectangle(backRect.X, backRect.Y, backRect.Width, y2)
        backRect2 = New Rectangle(backRect.X, backRect.Y + y2, backRect.Width, backRect.Height - y2)
        backRect1I = backRect1
        backRect2I = backRect2
        backRect1I.Inflate(1, 1)
        backRect2I.Inflate(1, 1)

        Using fillBrush1 As New LinearGradientBrush(backRect1I, colors.cFillTop1, colors.cFillTop2, 90.0F), fillBrush2 As New LinearGradientBrush(backRect2I, colors.cFillBottom1, colors.cFillBottom2, 90.0F)
            ' Reduce rect one more time for the innermost drawing
            backRect.Inflate(-1, -1)

            y2 = backRect.Height / 2
            backRect1 = New Rectangle(backRect.X, backRect.Y, backRect.Width, y2)
            backRect2 = New Rectangle(backRect.X, backRect.Y + y2, backRect.Width, backRect.Height - y2)

            g.FillRectangle(fillBrush1, backRect1)
            g.FillRectangle(fillBrush2, backRect2)
        End Using
    End Sub

    Private Sub DrawGradientBorder(ByVal g As Graphics, ByVal backRect As Rectangle, ByVal colors As GradientItemColors)
        ' Drawing with anti aliasing to create smoother appearance
        Using uaa As New UseAntiAlias(g)
            Dim backRectI As Rectangle = backRect
            backRectI.Inflate(1, 1)

            ' Finally draw the border around the menu item
            Using borderBrush As New LinearGradientBrush(backRectI, colors.cBorder1, colors.cBorder2, 90.0F)
                ' Sigma curve, so go from color1 to color2 and back to color1 again
                borderBrush.SetSigmaBellShape(0.5F)

                ' Convert the brush to a pen for DrawPath call
                Using borderPen As New Pen(borderBrush)
                    ' Create border path around the entire item
                    Using borderPath As GraphicsPath = CreateBorderPath(backRect, _cutMenuItemBack)
                        g.DrawPath(borderPen, borderPath)
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub DrawGripGlyph(ByVal g As Graphics, ByVal x As Integer, ByVal y As Integer, ByVal darkBrush As Brush, ByVal lightBrush As Brush)
        g.FillRectangle(lightBrush, x + _gripOffset, y + _gripOffset, _gripSquare, _gripSquare)
        g.FillRectangle(darkBrush, x, y, _gripSquare, _gripSquare)
    End Sub

    Private Overloads Sub DrawSeparator(ByVal g As Graphics, ByVal vertical As Boolean, ByVal rect As Rectangle, ByVal lightPen As Pen, ByVal darkPen As Pen, ByVal horizontalInset As Integer, _
     ByVal rtl As Boolean)
        If vertical Then
            Dim l As Integer = rect.Width / 2
            Dim t As Integer = rect.Y
            Dim b As Integer = rect.Bottom - 5

            ' Draw vertical lines centered
            g.DrawLine(darkPen, l, t, l, b)
            g.DrawLine(lightPen, l + 1, t, l + 1, b)
        Else
            Dim y As Integer = rect.Height / 2
            Dim l As Integer = rect.X + (If(rtl, 0, horizontalInset))
            Dim r As Integer = rect.Right - (If(rtl, horizontalInset, 0))

            ' Draw horizontal lines centered
            g.DrawLine(darkPen, l, y, r, y)
            g.DrawLine(lightPen, l, y + 1, r, y + 1)
        End If
    End Sub

    Private Function CreateBorderPath(ByVal rect As Rectangle, ByVal exclude As Rectangle, ByVal cut As Single) As GraphicsPath
        ' If nothing to exclude, then use quicker method
        If exclude.IsEmpty Then
            Return CreateBorderPath(rect, cut)
        End If

        ' Drawing lines requires we draw inside the area we want
        rect.Width -= 1
        rect.Height -= 1

        ' Create an array of points to draw lines between
        Dim pts As New List(Of PointF)()

        Dim l As Single = rect.X
        Dim t As Single = rect.Y
        Dim r As Single = rect.Right
        Dim b As Single = rect.Bottom
        Dim x0 As Single = rect.X + cut
        Dim x3 As Single = rect.Right - cut
        Dim y0 As Single = rect.Y + cut
        Dim y3 As Single = rect.Bottom - cut
        Dim cutBack As Single = (If(cut = 0.0F, 1, cut))

        ' Does the exclude intercept the top line
        If (rect.Y >= exclude.Top) AndAlso (rect.Y <= exclude.Bottom) Then
            Dim x1 As Single = exclude.X - 1 - cut
            Dim x2 As Single = exclude.Right + cut

            If x0 <= x1 Then
                pts.Add(New PointF(x0, t))
                pts.Add(New PointF(x1, t))
                pts.Add(New PointF(x1 + cut, t - cutBack))
            Else
                x1 = exclude.X - 1
                pts.Add(New PointF(x1, t))
                pts.Add(New PointF(x1, t - cutBack))
            End If

            If x3 > x2 Then
                pts.Add(New PointF(x2 - cut, t - cutBack))
                pts.Add(New PointF(x2, t))
                pts.Add(New PointF(x3, t))
            Else
                x2 = exclude.Right
                pts.Add(New PointF(x2, t - cutBack))
                pts.Add(New PointF(x2, t))
            End If
        Else
            pts.Add(New PointF(x0, t))
            pts.Add(New PointF(x3, t))
        End If

        pts.Add(New PointF(r, y0))
        pts.Add(New PointF(r, y3))
        pts.Add(New PointF(x3, b))
        pts.Add(New PointF(x0, b))
        pts.Add(New PointF(l, y3))
        pts.Add(New PointF(l, y0))

        ' Create path using a simple set of lines that cut the corner
        Dim path As New GraphicsPath()

        ' Add a line between each set of points
        For i As Integer = 1 To pts.Count - 1
            path.AddLine(pts(i - 1), pts(i))
        Next

        ' Add a line to join the last to the first
        path.AddLine(pts(pts.Count - 1), pts(0))

        Return path
    End Function

    Private Function CreateBorderPath(ByVal rect As Rectangle, ByVal cut As Single) As GraphicsPath
        ' Drawing lines requires we draw inside the area we want
        rect.Width -= 1
        rect.Height -= 1

        ' Create path using a simple set of lines that cut the corner
        Dim path As New GraphicsPath()
        path.AddLine(rect.Left + cut, rect.Top, rect.Right - cut, rect.Top)
        path.AddLine(rect.Right - cut, rect.Top, rect.Right, rect.Top + cut)
        path.AddLine(rect.Right, rect.Top + cut, rect.Right, rect.Bottom - cut)
        path.AddLine(rect.Right, rect.Bottom - cut, rect.Right - cut, rect.Bottom)
        path.AddLine(rect.Right - cut, rect.Bottom, rect.Left + cut, rect.Bottom)
        path.AddLine(rect.Left + cut, rect.Bottom, rect.Left, rect.Bottom - cut)
        path.AddLine(rect.Left, rect.Bottom - cut, rect.Left, rect.Top + cut)
        path.AddLine(rect.Left, rect.Top + cut, rect.Left + cut, rect.Top)
        Return path
    End Function

    Private Function CreateInsideBorderPath(ByVal rect As Rectangle, ByVal cut As Single) As GraphicsPath
        ' Adjust rectangle to be 1 pixel inside the original area
        rect.Inflate(-1, -1)

        ' Now create a path based on this inner rectangle
        Return CreateBorderPath(rect, cut)
    End Function

    Private Function CreateInsideBorderPath(ByVal rect As Rectangle, ByVal exclude As Rectangle, ByVal cut As Single) As GraphicsPath
        ' Adjust rectangle to be 1 pixel inside the original area
        rect.Inflate(-1, -1)

        ' Now create a path based on this inner rectangle
        Return CreateBorderPath(rect, exclude, cut)
    End Function

    Private Function CreateClipBorderPath(ByVal rect As Rectangle, ByVal cut As Single) As GraphicsPath
        ' Clipping happens inside the rect, so make 1 wider and taller
        rect.Width += 1
        rect.Height += 1

        ' Now create a path based on this inner rectangle
        Return CreateBorderPath(rect, cut)
    End Function

    Private Function CreateClipBorderPath(ByVal rect As Rectangle, ByVal exclude As Rectangle, ByVal cut As Single) As GraphicsPath
        ' Clipping happens inside the rect, so make 1 wider and taller
        rect.Width += 1
        rect.Height += 1

        ' Now create a path based on this inner rectangle
        Return CreateBorderPath(rect, exclude, cut)
    End Function

    Private Function CreateArrowPath(ByVal item As ToolStripItem, ByVal rect As Rectangle, ByVal direction As ArrowDirection) As GraphicsPath
        Dim x As Integer, y As Integer

        ' Find the correct starting position, which depends on direction
        If (direction = ArrowDirection.Left) OrElse (direction = ArrowDirection.Right) Then
            x = rect.Right - (rect.Width - 4) / 2
            y = rect.Y + rect.Height / 2
        Else
            x = rect.X + rect.Width / 2
            y = rect.Bottom - (rect.Height - 3) / 2

            ' The drop down button is position 1 pixel incorrectly when in RTL
            If (TypeOf item Is ToolStripDropDownButton) AndAlso (item.RightToLeft = RightToLeft.Yes) Then
                x += 1
            End If
        End If

        ' Create triangle using a series of lines
        Dim path As New GraphicsPath()

        Select Case direction
            Case ArrowDirection.Right
                path.AddLine(x, y, x - 4, y - 4)
                path.AddLine(x - 4, y - 4, x - 4, y + 4)
                path.AddLine(x - 4, y + 4, x, y)
                Exit Select
            Case ArrowDirection.Left
                path.AddLine(x - 4, y, x, y - 4)
                path.AddLine(x, y - 4, x, y + 4)
                path.AddLine(x, y + 4, x - 4, y)
                Exit Select
            Case ArrowDirection.Down
                path.AddLine(x + 3.0F, y - 3.0F, x - 2.0F, y - 3.0F)
                path.AddLine(x - 2.0F, y - 3.0F, x, y)
                path.AddLine(x, y, x + 3.0F, y - 3.0F)
                Exit Select
            Case ArrowDirection.Up
                path.AddLine(x + 3.0F, y, x - 3.0F, y)
                path.AddLine(x - 3.0F, y, x, y - 4.0F)
                path.AddLine(x, y - 4.0F, x + 3.0F, y)
                Exit Select
        End Select

        Return path
    End Function

    Private Function CreateTickPath(ByVal rect As Rectangle) As GraphicsPath
        ' Get the center point of the rect
        Dim x As Integer = rect.X + rect.Width / 2
        Dim y As Integer = rect.Y + rect.Height / 2

        Dim path As New GraphicsPath()
        path.AddLine(x - 4, y, x - 2, y + 4)
        path.AddLine(x - 2, y + 4, x + 3, y - 5)
        Return path
    End Function

    Private Function CreateIndeterminatePath(ByVal rect As Rectangle) As GraphicsPath
        ' Get the center point of the rect
        Dim x As Integer = rect.X + rect.Width / 2
        Dim y As Integer = rect.Y + rect.Height / 2

        Dim path As New GraphicsPath()
        path.AddLine(x - 3, y, x, y - 3)
        path.AddLine(x, y - 3, x + 3, y)
        path.AddLine(x + 3, y, x, y + 3)
        path.AddLine(x, y + 3, x - 3, y)
        Return path
    End Function
#End Region

End Class