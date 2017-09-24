Public Class HtmlNodes

    Dim m_Nodes As New Html.HtmlNodeCollection

    Private Sub GetNodes(ByVal Nodes As Html.HtmlNodeCollection)

        For Each node As Html.HtmlNode In Nodes
            If TypeOf (node) Is Html.HtmlElement Then
                m_Nodes.Add(node)
                GetNodes(DirectCast(node, Html.HtmlElement).Nodes)
            End If
            Application.DoEvents()
        Next

    End Sub

    Public Function GetAllNodes(ByVal HtmlDocument As Html.HtmlDocument) As Html.HtmlNodeCollection

        GetNodes(HtmlDocument.Nodes)

        Return m_Nodes

    End Function

End Class
