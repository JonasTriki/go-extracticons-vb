Imports System.Collections
Imports System.ComponentModel

Namespace Html
    ''' <summary>
    ''' The HtmlNode is the base for all objects that may appear in HTML. Currently, 
    ''' this implemention only supports HtmlText and HtmlElement node types.
    ''' </summary>
    Public MustInherit Class HtmlNode
        Protected mParent As HtmlElement

        ''' <summary>
        ''' This constructor is used by the subclasses.
        ''' </summary>
        Protected Sub New()
            mParent = Nothing
        End Sub

        ''' <summary>
        ''' This will return the parent of this node, or null if there is none.
        ''' </summary>
        <Category("Navigation"), Description("The parent node of this one")> _
        Public ReadOnly Property Parent() As HtmlElement
            Get
                Return mParent
            End Get
        End Property

        ''' <summary>
        ''' This will return the next sibling node. If this is the last one, it will return null.
        ''' </summary>
        <Category("Navigation"), Description("The next sibling node")> _
        Public ReadOnly Property [Next]() As HtmlNode
            Get
                If Index = -1 Then
                    Return Nothing
                Else
                    If Parent.Nodes.Count > Index + 1 Then
                        Return Parent.Nodes(Index + 1)
                    Else
                        Return Nothing
                    End If
                End If
            End Get
        End Property

        ''' <summary>
        ''' This will return the previous sibling node. If this is the first one, it will return null.
        ''' </summary>
        <Category("Navigation"), Description("The previous sibling node")> _
        Public ReadOnly Property Previous() As HtmlNode
            Get
                If Index = -1 Then
                    Return Nothing
                Else
                    If Index > 0 Then
                        Return Parent.Nodes(Index - 1)
                    Else
                        Return Nothing
                    End If
                End If
            End Get
        End Property

        ''' <summary>
        ''' This will return the first child node. If there are no children, this
        ''' will return null.
        ''' </summary>
        <Category("Navigation"), Description("The first child of this node")> _
        Public ReadOnly Property FirstChild() As HtmlNode
            Get
                If TypeOf Me Is HtmlElement Then
                    If DirectCast(Me, HtmlElement).Nodes.Count = 0 Then
                        Return Nothing
                    Else
                        Return DirectCast(Me, HtmlElement).Nodes(0)
                    End If
                Else
                    Return Nothing
                End If
            End Get
        End Property

        ''' <summary>
        ''' This will return the last child node. If there are no children, this
        ''' will return null.
        ''' </summary>
        <Category("Navigation"), Description("The last child of this node")> _
        Public ReadOnly Property LastChild() As HtmlNode
            Get
                If TypeOf Me Is HtmlElement Then
                    If DirectCast(Me, HtmlElement).Nodes.Count = 0 Then
                        Return Nothing
                    Else
                        Return DirectCast(Me, HtmlElement).Nodes(DirectCast(Me, HtmlElement).Nodes.Count - 1)
                    End If
                Else
                    Return Nothing
                End If
            End Get
        End Property

        ''' <summary>
        ''' This will return the index position within the parent's nodes that this one resides.
        ''' If this is not in a collection, this will return -1.
        ''' </summary>
        <Category("Navigation"), Description("The zero-based index of this node in the parent's nodes collection")> _
        Public ReadOnly Property Index() As Integer
            Get
                If mParent Is Nothing Then
                    Return -1
                Else
                    Return mParent.Nodes.IndexOf(Me)
                End If
            End Get
        End Property

        ''' <summary>
        ''' This will return true if this is a root node (has no parent).
        ''' </summary>
        <Category("Navigation"), Description("Is this node a root node?")> _
        Public ReadOnly Property IsRoot() As Boolean
            Get
                Return mParent Is Nothing
            End Get
        End Property

        ''' <summary>
        ''' This will return true if this is a child node (has a parent).
        ''' </summary>
        <Category("Navigation"), Description("Is this node a child of another?")> _
        Public ReadOnly Property IsChild() As Boolean
            Get
                Return mParent IsNot Nothing
            End Get
        End Property

        <Category("Navigation"), Description("Does this node have any children?")> _
        Public ReadOnly Property IsParent() As Boolean
            Get
                If TypeOf Me Is HtmlElement Then
                    Return DirectCast(Me, HtmlElement).Nodes.Count > 0
                Else
                    Return False
                End If
            End Get
        End Property

        ''' <summary>
        ''' This will return true if the node passed is a descendent of this node.
        ''' </summary>
        ''' <param name="node">The node that might be the parent or grandparent (etc.)</param>
        ''' <returns>True if this node is a descendent of the one passed in.</returns>
        <Category("Relationships")> _
        Public Function IsDescendentOf(ByVal node As HtmlNode) As Boolean
            Dim parent As HtmlNode = mParent
            While parent IsNot Nothing
                If parent Is node Then
                    Return True
                End If
                parent = parent.Parent
            End While
            Return False
        End Function

        ''' <summary>
        ''' This will return true if the node passed is one of the children or grandchildren of this node.
        ''' </summary>
        ''' <param name="node">The node that might be a child.</param>
        ''' <returns>True if this node is an ancestor of the one specified.</returns>
        <Category("Relationships")> _
        Public Function IsAncestorOf(ByVal node As HtmlNode) As Boolean
            Return node.IsDescendentOf(Me)
        End Function

        ''' <summary>
        ''' This will return the ancstor that is common to this node and the one specified.
        ''' </summary>
        ''' <param name="node">The possible node that is relative</param>
        ''' <returns>The common ancestor, or null if there is none</returns>
        <Category("Relationships")> _
        Public Function GetCommonAncestor(ByVal node As HtmlNode) As HtmlNode
            Dim thisParent As HtmlNode = Me
            While thisParent IsNot Nothing
                Dim thatParent As HtmlNode = node
                While thatParent IsNot Nothing
                    If thisParent Is thatParent Then
                        Return thisParent
                    End If
                    thatParent = thatParent.Parent
                End While
                thisParent = thisParent.Parent
            End While
            Return Nothing
        End Function

        ''' <summary>
        ''' This will remove this node and all child nodes from the tree. If this
        ''' is a root node, this operation will do nothing.
        ''' </summary>
        <Category("General")> _
        Public Sub Remove()
            If mParent IsNot Nothing Then
                mParent.Nodes.RemoveAt(Me.Index)
            End If
        End Sub

        ''' <summary>
        ''' Internal method to maintain the identity of the parent node.
        ''' </summary>
        ''' <param name="parentNode">The parent node of this one</param>
        Friend Sub SetParent(ByVal parentNode As HtmlElement)
            mParent = parentNode
        End Sub

        ''' <summary>
        ''' This will return the full HTML to represent this node (and all child nodes).
        ''' </summary>
        <Category("Output"), Description("The HTML that represents this node and all the children")> _
        Public ReadOnly Property HTML() As String
            Get
                Return ToString()
            End Get
        End Property
        ''' <summary>
        ''' This will return the full XHTML to represent this node (and all child nodes)
        ''' </summary>
        <Category("Output"), Description("The XHTML that represents this node and all the children")> _
        Public ReadOnly Property XHTML() As String
            Get
                Return ToString()
            End Get
        End Property

        <Category("General"), Description("This is true if this is a text node")> _
        Public Function IsText() As Boolean
            Return TypeOf Me Is HtmlText
        End Function

        <Category("General"), Description("This is true if this is an element node")> _
        Public Function IsElement() As Boolean
            Return TypeOf Me Is HtmlElement
        End Function
    End Class

    ''' <summary>
    ''' This object represents a collection of HtmlNodes, which can be either HtmlText
    ''' or HtmlElement objects. The order in which the nodes occur directly corresponds
    ''' to the order in which they appear in the original HTML document.
    ''' </summary>
    Public Class HtmlNodeCollection
        Inherits CollectionBase
        Private mParent As HtmlElement

        ' Public constructor to create an empty collection.
        Public Sub New()
            mParent = Nothing
        End Sub

        ''' <summary>
        ''' A collection is usually associated with a parent node (an HtmlElement, actually)
        ''' but you can pass null to implement an abstracted collection.
        ''' </summary>
        ''' <param name="parent">The parent element, or null if it is not appropriate</param>
        Friend Sub New(ByVal parent As HtmlElement)
            mParent = parent
        End Sub

        ''' <summary>
        ''' This will add a node to the collection.
        ''' </summary>
        ''' <param name="node"></param>
        ''' <returns></returns>
        Public Function Add(ByVal node As HtmlNode) As Integer
            If mParent IsNot Nothing Then
                node.SetParent(mParent)
            End If
            Return MyBase.List.Add(node)
        End Function

        ''' <summary>
        ''' This is used to identify the index of this node as it appears in the collection.
        ''' </summary>
        ''' <param name="node">The node to test</param>
        ''' <returns>The index of the node, or -1 if it is not in this collection</returns>
        Public Function IndexOf(ByVal node As HtmlNode) As Integer
            Return MyBase.List.IndexOf(node)
        End Function

        ''' <summary>
        ''' This will insert a node at the given position
        ''' </summary>
        ''' <param name="index">The position at which to insert the node.</param>
        ''' <param name="node">The node to insert.</param>
        Public Sub Insert(ByVal index As Integer, ByVal node As HtmlNode)
            If mParent IsNot Nothing Then
                node.SetParent(mParent)
            End If
            MyBase.InnerList.Insert(index, node)
        End Sub

        ''' <summary>
        ''' This property allows you to change the node at a particular position in the
        ''' collection.
        ''' </summary>
        Default Public Property Item(ByVal index As Integer) As HtmlNode
            Get
                Return DirectCast(MyBase.InnerList(index), HtmlNode)
            End Get
            Set(ByVal value As HtmlNode)
                If mParent IsNot Nothing Then
                    value.SetParent(mParent)
                End If
                MyBase.InnerList(index) = value
            End Set
        End Property

        ''' <summary>
        ''' This allows you to directly access the first element in this colleciton with the given name.
        ''' If the node does not exist, this will return null.
        ''' </summary>
        Default Public ReadOnly Property Item(ByVal name As String) As HtmlNode
            Get
                Dim results As HtmlNodeCollection = FindByName(name, False)
                If results.Count > 0 Then
                    Return results(0)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        ''' <summary>
        ''' This will search though this collection of nodes for all elements with the
        ''' specified name. If you want to search the subnodes recursively, you should
        ''' pass True as the parameter in searchChildren. This search is guaranteed to
        ''' return nodes in the order in which they are found in the document.
        ''' </summary>
        ''' <param name="name">The name of the element to find</param>
        ''' <returns>A collection of all the nodes that macth.</returns>
        Public Function FindByName(ByVal name As String) As HtmlNodeCollection
            Return FindByName(name, True)
        End Function

        ''' <summary>
        ''' This will search though this collection of nodes for all elements with the
        ''' specified name. If you want to search the subnodes recursively, you should
        ''' pass True as the parameter in searchChildren. This search is guaranteed to
        ''' return nodes in the order in which they are found in the document.
        ''' </summary>
        ''' <param name="name">The name of the element to find</param>
        ''' <param name="searchChildren">True if you want to search sub-nodes, False to
        ''' only search this collection.</param>
        ''' <returns>A collection of all the nodes that macth.</returns>
        Public Function FindByName(ByVal name As String, ByVal searchChildren As Boolean) As HtmlNodeCollection
            Dim results As New HtmlNodeCollection(Nothing)
            For Each node As HtmlNode In MyBase.List
                If TypeOf node Is HtmlElement Then
                    If DirectCast(node, HtmlElement).Name.ToLower().Equals(name.ToLower()) Then
                        results.Add(node)
                    End If
                    If searchChildren Then
                        For Each matchedChild As HtmlNode In DirectCast(node, HtmlElement).Nodes.FindByName(name, searchChildren)
                            results.Add(matchedChild)
                            Application.DoEvents()
                        Next
                    End If
                End If
                Application.DoEvents()
            Next
            Return results
        End Function

        ''' <summary>
        ''' This will search though this collection of nodes for all elements with the an
        ''' attribute with the given name. 
        ''' </summary>
        ''' <param name="attributeName">The name of the attribute to find</param>
        ''' <returns>A collection of all the nodes that macth.</returns>
        Public Function FindByAttributeName(ByVal attributeName As String) As HtmlNodeCollection
            Return FindByAttributeName(attributeName, True)
        End Function

        ''' <summary>
        ''' This will search though this collection of nodes for all elements with the an
        ''' attribute with the given name. 
        ''' </summary>
        ''' <param name="attributeName">The name of the attribute to find</param>
        ''' <param name="searchChildren">True if you want to search sub-nodes, False to
        ''' only search this collection.</param>
        ''' <returns>A collection of all the nodes that macth.</returns>
        Public Function FindByAttributeName(ByVal attributeName As String, ByVal searchChildren As Boolean) As HtmlNodeCollection
            Dim results As New HtmlNodeCollection(Nothing)
            For Each node As HtmlNode In MyBase.List
                If TypeOf node Is HtmlElement Then
                    For Each attribute As HtmlAttribute In DirectCast(node, HtmlElement).Attributes
                        If attribute.Name.ToLower().Equals(attributeName.ToLower()) Then
                            results.Add(node)
                            Exit For
                        End If
                        Application.DoEvents()
                    Next
                    If searchChildren Then
                        For Each matchedChild As HtmlNode In DirectCast(node, HtmlElement).Nodes.FindByAttributeName(attributeName, searchChildren)
                            results.Add(matchedChild)
                            Application.DoEvents()
                        Next
                    End If
                End If
                Application.DoEvents()
            Next
            Return results
        End Function

        Public Function FindByAttributeNameValue(ByVal attributeName As String, ByVal attributeValue As String) As HtmlNodeCollection
            Return FindByAttributeNameValue(attributeName, attributeValue, True)
        End Function

        Public Function FindByAttributeNameValue(ByVal attributeName As String, ByVal attributeValue As String, ByVal searchChildren As Boolean) As HtmlNodeCollection
            Dim results As New HtmlNodeCollection(Nothing)
            For Each node As HtmlNode In MyBase.List
                If TypeOf node Is HtmlElement Then
                    For Each attribute As HtmlAttribute In DirectCast(node, HtmlElement).Attributes
                        If attribute.Name.ToLower().Equals(attributeName.ToLower()) Then
                            If attribute.Value.ToLower().Equals(attributeValue.ToLower()) Then
                                results.Add(node)
                            End If
                            Exit For
                        End If
                        Application.DoEvents()
                    Next
                    If searchChildren Then
                        For Each matchedChild As HtmlNode In DirectCast(node, HtmlElement).Nodes.FindByAttributeNameValue(attributeName, attributeValue, searchChildren)
                            results.Add(matchedChild)
                            Application.DoEvents()
                        Next
                    End If
                End If
                Application.DoEvents()
            Next
            Return results
        End Function
    End Class
End Namespace