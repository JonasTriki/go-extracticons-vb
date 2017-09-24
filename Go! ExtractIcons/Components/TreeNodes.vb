Public Class TreeNodes

    Dim Finised As Boolean = False
    Dim NodeList As New List(Of TreeNode)

    Private Sub GetNodes(ByVal Nodes As TreeNodeCollection, ByVal SearchSubNodes As Boolean)

        Dim TreeNodes As New List(Of TreeNode)

        Dim Count As Integer = 0

        If SearchSubNodes Then

            ' On Error Resume Next

            For Each Node As TreeNode In Nodes

                For Each n As TreeNode In Node.Nodes
                    Count += n.Nodes.Count
                    For Each ni As TreeNode In n.Nodes
                        TreeNodes.Add(ni)
                        Application.DoEvents()
                    Next
                    Application.DoEvents()
                Next

                For Each n As TreeNode In Node.Nodes
                    Count += 1
                    GetNodes(n.Nodes, SearchSubNodes)
                    Application.DoEvents()
                Next

                NodeList.AddRange(TreeNodes)

                Application.DoEvents()
            Next

        Else

            For Each Node As TreeNode In Nodes
                For Each n As TreeNode In Node.Nodes
                    Count += n.Nodes.Count
                    For Each ni As TreeNode In n.Nodes
                        TreeNodes.Add(ni)
                        Application.DoEvents()
                    Next
                    Application.DoEvents()
                Next
                Application.DoEvents()
            Next

            NodeList.AddRange(TreeNodes)

        End If

        Finised = Count > 0

    End Sub

    ''' <summary>
    ''' Gets all TreeNodes in a TreeNode.
    ''' </summary>
    ''' <param name="Nodes">The TreeNodes to search in.</param>
    ''' <param name="SearchSubNodes">Search subfolders.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllNodes(ByVal Nodes As TreeNodeCollection, Optional ByVal SearchSubNodes As Boolean = True) As List(Of TreeNode)

        GetNodes(Nodes, SearchSubNodes)

        If Finised Then
            Return NodeList
        Else
            Return New List(Of TreeNode)
        End If

    End Function

End Class
