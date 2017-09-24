Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Provide GoRender colors
''' </summary>
Public Class GoColorTable
    Inherits ProfessionalColorTable

#Region "Static Fixed Colors - Go Color Scheme"
    Friend Shared _contextMenuBack As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _buttonPressedBegin As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _buttonPressedEnd As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _buttonPressedMiddle As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _buttonSelectedBegin As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _buttonSelectedEnd As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _buttonSelectedMiddle As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _menuItemSelectedBegin As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _menuItemSelectedEnd As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _checkBack As Color = Color.Transparent
    Friend Shared _gripDark As Color = Color.FromArgb(160, 160, 160)
    Friend Shared _gripLight As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _imageMargin As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _menuBorder As Color = Color.FromArgb(160, 160, 160)
    Friend Shared _overflowBegin As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _overflowEnd As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _overflowMiddle As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _menuToolBack As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _separatorDark As Color = Color.FromArgb(160, 160, 160)
    Friend Shared _separatorLight As Color = Color.Transparent
    Friend Shared _statusStripLight As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _statusStripDark As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _toolStripBorder As Color = Color.FromArgb(160, 160, 160)
    Friend Shared _toolStripContentEnd As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _toolStripBegin As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _toolStripEnd As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _toolStripMiddle As Color = Color.FromArgb(255, 255, 255)
    Friend Shared _buttonBorder As Color = Color.FromArgb(229, 195, 101)
#End Region

#Region "Identity"
    ''' <summary>
    ''' Initialize a new instance of the GoRenderColorTable class.
    ''' </summary>
    Public Sub New()
    End Sub
#End Region

#Region "ButtonPressed"
    ''' <summary>
    ''' Gets the starting color of the gradient used when the button is pressed down.
    ''' </summary>
    Public Overrides ReadOnly Property ButtonPressedGradientBegin() As Color
        Get
            Return _buttonPressedBegin
        End Get
    End Property

    ''' <summary>
    ''' Gets the end color of the gradient used when the button is pressed down.
    ''' </summary>
    Public Overrides ReadOnly Property ButtonPressedGradientEnd() As Color
        Get
            Return _buttonPressedEnd
        End Get
    End Property

    ''' <summary>
    ''' Gets the middle color of the gradient used when the button is pressed down.
    ''' </summary>
    Public Overrides ReadOnly Property ButtonPressedGradientMiddle() As Color
        Get
            Return _buttonPressedMiddle
        End Get
    End Property
#End Region

#Region "ButtonSelected"
    ''' <summary>
    ''' Gets the starting color of the gradient used when the button is selected.
    ''' </summary>
    Public Overrides ReadOnly Property ButtonSelectedGradientBegin() As Color
        Get
            Return _buttonSelectedBegin
        End Get
    End Property

    ''' <summary>
    ''' Gets the end color of the gradient used when the button is selected.
    ''' </summary>
    Public Overrides ReadOnly Property ButtonSelectedGradientEnd() As Color
        Get
            Return _buttonSelectedEnd
        End Get
    End Property

    ''' <summary>
    ''' Gets the middle color of the gradient used when the button is selected.
    ''' </summary>
    Public Overrides ReadOnly Property ButtonSelectedGradientMiddle() As Color
        Get
            Return _buttonSelectedMiddle
        End Get
    End Property

    ''' <summary>
    ''' Gets the border color to use with ButtonSelectedHighlight.
    ''' </summary>
    Public Overrides ReadOnly Property ButtonSelectedHighlightBorder() As Color
        Get
            Return _buttonBorder
        End Get
    End Property
#End Region

#Region "Check"
    ''' <summary>
    ''' Gets the solid color to use when the check box is selected and gradients are being used.
    ''' </summary>
    Public Overrides ReadOnly Property CheckBackground() As Color
        Get
            Return _checkBack
        End Get
    End Property
#End Region

#Region "Grip"
    ''' <summary>
    ''' Gets the color to use for shadow effects on the grip or move handle.
    ''' </summary>
    Public Overrides ReadOnly Property GripDark() As Color
        Get
            Return _gripDark
        End Get
    End Property

    ''' <summary>
    ''' Gets the color to use for highlight effects on the grip or move handle.
    ''' </summary>
    Public Overrides ReadOnly Property GripLight() As Color
        Get
            Return _gripLight
        End Get
    End Property
#End Region

#Region "ImageMargin"
    ''' <summary>
    ''' Gets the starting color of the gradient used in the image margin of a ToolStripDropDownMenu.
    ''' </summary>
    Public Overrides ReadOnly Property ImageMarginGradientBegin() As Color
        Get
            Return _imageMargin
        End Get
    End Property
#End Region

#Region "MenuBorder"
    ''' <summary>
    ''' Gets the border color or a MenuStrip.
    ''' </summary>
    Public Overrides ReadOnly Property MenuBorder() As Color
        Get
            Return _menuBorder
        End Get
    End Property
#End Region

#Region "MenuItem"
    ''' <summary>
    ''' Gets the starting color of the gradient used when a top-level ToolStripMenuItem is pressed down.
    ''' </summary>
    Public Overrides ReadOnly Property MenuItemPressedGradientBegin() As Color
        Get
            Return _toolStripBegin
        End Get
    End Property

    ''' <summary>
    ''' Gets the end color of the gradient used when a top-level ToolStripMenuItem is pressed down.
    ''' </summary>
    Public Overrides ReadOnly Property MenuItemPressedGradientEnd() As Color
        Get
            Return _toolStripEnd
        End Get
    End Property

    ''' <summary>
    ''' Gets the middle color of the gradient used when a top-level ToolStripMenuItem is pressed down.
    ''' </summary>
    Public Overrides ReadOnly Property MenuItemPressedGradientMiddle() As Color
        Get
            Return _toolStripMiddle
        End Get
    End Property

    ''' <summary>
    ''' Gets the starting color of the gradient used when the ToolStripMenuItem is selected.
    ''' </summary>
    Public Overrides ReadOnly Property MenuItemSelectedGradientBegin() As Color
        Get
            Return _menuItemSelectedBegin
        End Get
    End Property

    ''' <summary>
    ''' Gets the end color of the gradient used when the ToolStripMenuItem is selected.
    ''' </summary>
    Public Overrides ReadOnly Property MenuItemSelectedGradientEnd() As Color
        Get
            Return _menuItemSelectedEnd
        End Get
    End Property
#End Region

#Region "MenuStrip"
    ''' <summary>
    ''' Gets the starting color of the gradient used in the MenuStrip.
    ''' </summary>
    Public Overrides ReadOnly Property MenuStripGradientBegin() As Color
        Get
            Return _menuToolBack
        End Get
    End Property

    ''' <summary>
    ''' Gets the end color of the gradient used in the MenuStrip.
    ''' </summary>
    Public Overrides ReadOnly Property MenuStripGradientEnd() As Color
        Get
            Return _menuToolBack
        End Get
    End Property
#End Region

#Region "OverflowButton"
    ''' <summary>
    ''' Gets the starting color of the gradient used in the ToolStripOverflowButton.
    ''' </summary>
    Public Overrides ReadOnly Property OverflowButtonGradientBegin() As Color
        Get
            Return _overflowBegin
        End Get
    End Property

    ''' <summary>
    ''' Gets the end color of the gradient used in the ToolStripOverflowButton.
    ''' </summary>
    Public Overrides ReadOnly Property OverflowButtonGradientEnd() As Color
        Get
            Return _overflowEnd
        End Get
    End Property

    ''' <summary>
    ''' Gets the middle color of the gradient used in the ToolStripOverflowButton.
    ''' </summary>
    Public Overrides ReadOnly Property OverflowButtonGradientMiddle() As Color
        Get
            Return _overflowMiddle
        End Get
    End Property
#End Region

#Region "RaftingContainer"
    ''' <summary>
    ''' Gets the starting color of the gradient used in the ToolStripContainer.
    ''' </summary>
    Public Overrides ReadOnly Property RaftingContainerGradientBegin() As Color
        Get
            Return _menuToolBack
        End Get
    End Property

    ''' <summary>
    ''' Gets the end color of the gradient used in the ToolStripContainer.
    ''' </summary>
    Public Overrides ReadOnly Property RaftingContainerGradientEnd() As Color
        Get
            Return _menuToolBack
        End Get
    End Property
#End Region

#Region "Separator"
    ''' <summary>
    ''' Gets the color to use to for shadow effects on the ToolStripSeparator.
    ''' </summary>
    Public Overrides ReadOnly Property SeparatorDark() As Color
        Get
            Return _separatorDark
        End Get
    End Property

    ''' <summary>
    ''' Gets the color to use to for highlight effects on the ToolStripSeparator.
    ''' </summary>
    Public Overrides ReadOnly Property SeparatorLight() As Color
        Get
            Return _separatorLight
        End Get
    End Property
#End Region

#Region "StatusStrip"
    ''' <summary>
    ''' Gets the starting color of the gradient used on the StatusStrip.
    ''' </summary>
    Public Overrides ReadOnly Property StatusStripGradientBegin() As Color
        Get
            Return _statusStripLight
        End Get
    End Property

    ''' <summary>
    ''' Gets the end color of the gradient used on the StatusStrip.
    ''' </summary>
    Public Overrides ReadOnly Property StatusStripGradientEnd() As Color
        Get
            Return _statusStripDark
        End Get
    End Property
#End Region

#Region "ToolStrip"
    ''' <summary>
    ''' Gets the border color to use on the bottom edge of the ToolStrip.
    ''' </summary>
    Public Overrides ReadOnly Property ToolStripBorder() As Color
        Get
            Return _toolStripBorder
        End Get
    End Property

    ''' <summary>
    ''' Gets the starting color of the gradient used in the ToolStripContentPanel.
    ''' </summary>
    Public Overrides ReadOnly Property ToolStripContentPanelGradientBegin() As Color
        Get
            Return _toolStripContentEnd
        End Get
    End Property

    ''' <summary>
    ''' Gets the end color of the gradient used in the ToolStripContentPanel.
    ''' </summary>
    Public Overrides ReadOnly Property ToolStripContentPanelGradientEnd() As Color
        Get
            Return _menuToolBack
        End Get
    End Property

    ''' <summary>
    ''' Gets the solid background color of the ToolStripDropDown.
    ''' </summary>
    Public Overrides ReadOnly Property ToolStripDropDownBackground() As Color
        Get
            Return _contextMenuBack
        End Get
    End Property

    ''' <summary>
    ''' Gets the starting color of the gradient used in the ToolStrip background.
    ''' </summary>
    Public Overrides ReadOnly Property ToolStripGradientBegin() As Color
        Get
            Return _toolStripBegin
        End Get
    End Property

    ''' <summary>
    ''' Gets the end color of the gradient used in the ToolStrip background.
    ''' </summary>
    Public Overrides ReadOnly Property ToolStripGradientEnd() As Color
        Get
            Return _toolStripEnd
        End Get
    End Property

    ''' <summary>
    ''' Gets the middle color of the gradient used in the ToolStrip background.
    ''' </summary>
    Public Overrides ReadOnly Property ToolStripGradientMiddle() As Color
        Get
            Return _toolStripMiddle
        End Get
    End Property

    ''' <summary>
    ''' Gets the starting color of the gradient used in the ToolStripPanel.
    ''' </summary>
    Public Overrides ReadOnly Property ToolStripPanelGradientBegin() As Color
        Get
            Return _menuToolBack
        End Get
    End Property

    ''' <summary>
    ''' Gets the end color of the gradient used in the ToolStripPanel.
    ''' </summary>
    Public Overrides ReadOnly Property ToolStripPanelGradientEnd() As Color
        Get
            Return _menuToolBack
        End Get
    End Property
#End Region

End Class
