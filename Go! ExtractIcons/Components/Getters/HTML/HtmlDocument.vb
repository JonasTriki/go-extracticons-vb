Imports System.Text
Imports System.Collections
Imports System.ComponentModel

Namespace Html
    ''' <summary>
    ''' This is the basic HTML document object used to represent a sequence of HTML.
    ''' </summary>
    Public Class HtmlDocument
        Private mNodes As New HtmlNodeCollection(Nothing)
        Private mXhtmlHeader As String = "<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">"

        ''' <summary>
        ''' This will create a new document object by parsing the HTML specified.
        ''' </summary>
        ''' <param name="html">The HTML to parse.</param>
        Friend Sub New(ByVal html As String, ByVal wantSpaces As Boolean)
            Dim parser As New HtmlParser()
            parser.RemoveEmptyElementText = Not wantSpaces
            mNodes = parser.Parse(html)
        End Sub

        <Category("General"), Description("This is the DOCTYPE for XHTML production")> _
        Public Property DocTypeXHTML() As String
            Get
                Return mXhtmlHeader
            End Get
            Set(ByVal value As String)
                mXhtmlHeader = value
            End Set
        End Property

        ''' <summary>
        ''' This is the collection of nodes used to represent this document.
        ''' </summary>
        Public ReadOnly Property Nodes() As HtmlNodeCollection
            Get
                Return mNodes
            End Get
        End Property

        ''' <summary>
        ''' This is the collection of nodes used to represent this document.
        ''' </summary>
        Public ReadOnly Property All() As HtmlNodeCollection
            Get
                Return New HtmlNodes().GetAllNodes(Me)
            End Get
        End Property

        ''' <summary>
        ''' This will create a new document object by parsing the HTML specified.
        ''' </summary>
        ''' <param name="html">The HTML to parse.</param>
        ''' <returns>An instance of the newly created object.</returns>
        Public Shared Function Create(ByVal html As String) As HtmlDocument
            Return New HtmlDocument(html, False)
        End Function

        ''' <summary>
        ''' This will create a new document object by parsing the HTML specified.
        ''' </summary>
        ''' <param name="html">The HTML to parse.</param>
        ''' <param name="wantSpaces">Set this to true if you want to preserve all whitespace from the input HTML</param>
        ''' <returns>An instance of the newly created object.</returns>
        Public Shared Function Create(ByVal html As String, ByVal wantSpaces As Boolean) As HtmlDocument
            Return New HtmlDocument(html, wantSpaces)
        End Function

        ''' <summary>
        ''' This will return the HTML used to represent this document.
        ''' </summary>
        <Category("Output"), Description("The HTML version of this document")> _
        Public ReadOnly Property HTML() As String
            Get
                Dim _html As New StringBuilder()
                For Each node As HtmlNode In Nodes
                    _html.Append(node.HTML)
                    Application.DoEvents()
                Next
                Return _html.ToString()
            End Get
        End Property

        ''' <summary>
        ''' This will return the XHTML document used to represent this document.
        ''' </summary>
        <Category("Output"), Description("The XHTML version of this document")> _
        Public ReadOnly Property XHTML() As String
            Get
                Dim html As New StringBuilder()
                If mXhtmlHeader IsNot Nothing Then
                    html.Append(mXhtmlHeader)
                    html.Append(vbCr & vbLf)
                End If
                For Each node As HtmlNode In Nodes
                    html.Append(node.XHTML)
                    Application.DoEvents()
                Next
                Return html.ToString()
            End Get
        End Property
    End Class
End Namespace