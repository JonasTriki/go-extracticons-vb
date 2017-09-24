Imports System.Text
Imports System.ComponentModel

Namespace Html
    ''' <summary>
    ''' The HtmlElement object represents any HTML element. An element has a name
    ''' and zero or more attributes.
    ''' </summary>
    Public Class HtmlElement
        Inherits HtmlNode
        Protected mName As String
        Protected mNodes As HtmlNodeCollection
        Protected mAttributes As HtmlAttributeCollection
        Protected mIsTerminated As Boolean
        Protected mIsExplicitlyTerminated As Boolean

        ''' <summary>
        ''' This constructs a new HTML element with the specified tag name.
        ''' </summary>
        ''' <param name="name">The name of this element</param>
        Public Sub New(ByVal name As String)
            mNodes = New HtmlNodeCollection(Me)
            mAttributes = New HtmlAttributeCollection(Me)
            mName = name
            mIsTerminated = False
        End Sub

        ''' <summary>
        ''' This is the tag name of the element. e.g. BR, BODY, TABLE etc.
        ''' </summary>
        <Category("General"), Description("The name of the tag/element")> _
        Public Property Name() As String
            Get
                Return mName
            End Get
            Set(ByVal value As String)
                mName = value
            End Set
        End Property

        ''' <summary>
        ''' This is the collection of all child nodes of this one. If this node is actually
        ''' a text node, this will throw an InvalidOperationException exception.
        ''' </summary>
        <Category("General"), Description("The set of child nodes")> _
        Public ReadOnly Property Nodes() As HtmlNodeCollection
            Get
                If IsText() Then
                    Throw New InvalidOperationException("An HtmlText node does not have child nodes")
                End If
                Return mNodes
            End Get
        End Property

        ''' <summary>
        ''' This is the collection of attributes associated with this element.
        ''' </summary>
        <Category("General"), Description("The set of attributes associated with this element")> _
        Public ReadOnly Property Attributes() As HtmlAttributeCollection
            Get
                Return mAttributes
            End Get
        End Property

        ''' <summary>
        ''' This flag indicates that the element is explicitly closed using the "<name/>" method.
        ''' </summary>
        Friend Property IsTerminated() As Boolean
            Get
                If Nodes.Count > 0 Then
                    Return False
                Else
                    Return mIsTerminated Or mIsExplicitlyTerminated
                End If
            End Get
            Set(ByVal value As Boolean)
                mIsTerminated = value
            End Set
        End Property

        ''' <summary>
        ''' This flag indicates that the element is explicitly closed using the "name" method.
        ''' </summary>
        Friend Property IsExplicitlyTerminated() As Boolean
            Get
                Return mIsExplicitlyTerminated
            End Get
            Set(ByVal value As Boolean)
                mIsExplicitlyTerminated = value
            End Set
        End Property

        Friend ReadOnly Property NoEscaping() As Boolean
            Get
                Return "script".Equals(Name.ToLower()) OrElse "style".Equals(Name.ToLower())
            End Get
        End Property

        ''' <summary>
        ''' This will return the HTML representation of this element.
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function ToString() As String
            Dim value As String = "<" + mName
            For Each attribute As HtmlAttribute In Attributes
                value += " " + attribute.ToString()
                Application.DoEvents()
            Next
            value += ">"
            Return value
        End Function

        <Category("General"), Description("A concatination of all the text associated with this element")> _
        Public ReadOnly Property Text() As String
            Get
                Dim stringBuilder As New StringBuilder()
                For Each node As HtmlNode In Nodes
                    If TypeOf node Is HtmlText Then
                        stringBuilder.Append(DirectCast(node, HtmlText).Text)
                    End If
                    Application.DoEvents()
                Next
                Return stringBuilder.ToString()
            End Get
        End Property

        ''' <summary>
        ''' This will return the HTML for this element and all subnodes.
        ''' </summary>
        <Category("Output")> _
        Public Overloads ReadOnly Property HTML() As String
            Get
                Dim _html As New StringBuilder()
                _html.Append("<" + mName)
                For Each attribute As HtmlAttribute In Attributes
                    _html.Append(" " + attribute.HTML)
                    Application.DoEvents()
                Next
                If Nodes.Count > 0 Then
                    _html.Append(">")
                    For Each node As HtmlNode In Nodes
                        _html.Append(node.HTML)
                        Application.DoEvents()
                    Next
                    _html.Append("</" + mName + ">")
                Else
                    If IsExplicitlyTerminated Then
                        _html.Append("></" + mName + ">")
                    ElseIf IsTerminated Then
                        _html.Append("/>")
                    Else
                        _html.Append(">")
                    End If
                End If
                Return _html.ToString()
            End Get
        End Property

        ''' <summary>
        ''' This will return the clean HTML for this element and all subnodes.
        ''' </summary>
        <Category("Output")> _
        Public Overloads ReadOnly Property CleanHTML() As String
            Get
                Dim _html As New StringBuilder()
                _html.Append("<" + mName)
                For Each attribute As HtmlAttribute In Attributes
                    _html.Append(" " + attribute.CleanHTML)
                    Application.DoEvents()
                Next
                If Nodes.Count > 0 Then
                    _html.Append(">")
                    For Each node As HtmlNode In Nodes
                        _html.Append(node.HTML)
                        Application.DoEvents()
                    Next
                    _html.Append("</" + mName + ">")
                Else
                    If IsExplicitlyTerminated Then
                        _html.Append("></" + mName + ">")
                    ElseIf IsTerminated Then
                        _html.Append("/>")
                    Else
                        _html.Append(">")
                    End If
                End If
                Return _html.ToString()
            End Get
        End Property

        ''' <summary>
        ''' This will return the XHTML for this element and all subnodes.
        ''' </summary>
        <Category("Output")> _
        Public Overloads ReadOnly Property XHTML() As String
            Get
                If "html".Equals(mName) AndAlso Me.Attributes("xmlns") Is Nothing Then
                    Attributes.Add(New HtmlAttribute("xmlns", "http://www.w3.org/1999/xhtml"))
                End If
                Dim html As New StringBuilder()
                html.Append("<" + mName.ToLower())
                For Each attribute As HtmlAttribute In Attributes
                    html.Append(" " + attribute.XHTML)
                    Application.DoEvents()
                Next
                If IsTerminated Then
                    html.Append("/>")
                Else
                    If Nodes.Count > 0 Then
                        html.Append(">")
                        For Each node As Html.HtmlNode In Nodes
                            html.Append(node.XHTML)
                            Application.DoEvents()
                        Next
                        html.Append("</" + mName.ToLower() + ">")
                    Else
                        html.Append("/>")
                    End If
                End If
                Return html.ToString()
            End Get
        End Property

        ''' <summary>
        ''' This will return the XHTML for this element and all subnodes.
        ''' </summary>
        <Category("Output")> _
        Public Overloads ReadOnly Property CleanXHTML() As String
            Get
                If "html".Equals(mName) AndAlso Me.Attributes("xmlns") Is Nothing Then
                    Attributes.Add(New HtmlAttribute("xmlns", "http://www.w3.org/1999/xhtml"))
                End If
                Dim html As New StringBuilder()
                html.Append("<" + mName.ToLower())
                For Each attribute As HtmlAttribute In Attributes
                    html.Append(" " + attribute.CleanXHTML)
                    Application.DoEvents()
                Next
                If IsTerminated Then
                    html.Append("/>")
                Else
                    If Nodes.Count > 0 Then
                        html.Append(">")
                        For Each node As Html.HtmlNode In Nodes
                            html.Append(node.XHTML)
                            Application.DoEvents()
                        Next
                        html.Append("</" + mName.ToLower() + ">")
                    Else
                        html.Append("/>")
                    End If
                End If
                Return html.ToString()
            End Get
        End Property
    End Class
End Namespace