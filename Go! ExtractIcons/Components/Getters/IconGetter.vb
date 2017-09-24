Imports System.IO
Imports System.Net
Imports System.ComponentModel

Public Class IconGetter

    Private Function GetHTML(ByVal URL As String) As String
        Try
            Dim Request As HttpWebRequest = DirectCast(WebRequest.Create(URL), HttpWebRequest)
            Request.Method = "GET"
            Return New System.Text.UTF8Encoding().GetString(New ExtendedBinaryReader(DirectCast(Request.GetResponse, HttpWebResponse).GetResponseStream).ReadToEnd())
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function FixURL(ByVal URL As String) As String
        If Not URL.ToLower().StartsWith("http://") Then URL = "http://" & URL
        Return URL
    End Function

    Public Function GetAllIconsFromHTML(ByVal HTML As String) As List(Of ICONGETTERINFO)

        Dim ResultIconList As New List(Of ICONGETTERINFO)

        If HTML = "" Then
            ResultIconList = New List(Of ICONGETTERINFO)
        Else
            For Each node As Html.HtmlNode In New Html.HtmlDocument(HTML, False).All
                If TypeOf (node) Is Html.HtmlElement Then
                    If Not IsNothing(DirectCast(node, Html.HtmlElement).Attributes.FindByName("href")) Then
                        If DirectCast(node, Html.HtmlElement).Attributes("href").Value.EndsWith(".ico") Then
                            If DirectCast(node, Html.HtmlElement).Attributes("href").Value.StartsWith("http") Then
                                Dim ICONGETTERINFO As New ICONGETTERINFO
                                ICONGETTERINFO.CommandLine = DirectCast(node, Html.HtmlElement).CleanHTML
                                ICONGETTERINFO.URL = DirectCast(node, Html.HtmlElement).Attributes("href").Value
                                ResultIconList.Add(ICONGETTERINFO)
                                Application.DoEvents()
                                Continue For
                            Else
                                Dim ICONGETTERINFO As New ICONGETTERINFO
                                ICONGETTERINFO.CommandLine = DirectCast(node, Html.HtmlElement).CleanHTML
                                ICONGETTERINFO.URL = ""
                                ResultIconList.Add(ICONGETTERINFO)
                                Application.DoEvents()
                                Continue For
                            End If
                        End If
                    End If
                End If
                Application.DoEvents()
            Next
        End If

        Return ResultIconList

    End Function

    Public Function GetAllIcons(ByVal URL As String) As List(Of ICONGETTERINFO)

        Dim ResultIconList As New List(Of ICONGETTERINFO)

        Dim HTML As String = GetHTML(FixURL(URL))
        If HTML = "" Then
            ResultIconList = New List(Of ICONGETTERINFO)
        Else
            For Each node As Html.HtmlNode In New Html.HtmlDocument(HTML, False).All
                If TypeOf (node) Is Html.HtmlElement Then
                    If Not IsNothing(DirectCast(node, Html.HtmlElement).Attributes.FindByName("href")) Then
                        If DirectCast(node, Html.HtmlElement).Attributes("href").Value.EndsWith(".ico") Then
                            If DirectCast(node, Html.HtmlElement).Attributes("href").Value.StartsWith("http") Then
                                Dim ICONGETTERINFO As New ICONGETTERINFO
                                ICONGETTERINFO.CommandLine = DirectCast(node, Html.HtmlElement).CleanHTML
                                ICONGETTERINFO.URL = DirectCast(node, Html.HtmlElement).Attributes("href").Value
                                ResultIconList.Add(ICONGETTERINFO)
                                Application.DoEvents()
                                Continue For
                            Else
                                Dim ICONGETTERINFO As New ICONGETTERINFO
                                ICONGETTERINFO.CommandLine = DirectCast(node, Html.HtmlElement).CleanHTML
                                ICONGETTERINFO.URL = FixURL(New Uri(FixURL(URL)).Host) & DirectCast(IIf(DirectCast(node, Html.HtmlElement).Attributes("href").Value.StartsWith("/"), DirectCast(node, Html.HtmlElement).Attributes("href").Value, "/" & DirectCast(node, Html.HtmlElement).Attributes("href").Value), String)
                                ResultIconList.Add(ICONGETTERINFO)
                                Application.DoEvents()
                                Continue For
                            End If
                        End If
                    End If
                End If
                Application.DoEvents()
            Next
        End If

        Return ResultIconList

    End Function

End Class
