Imports System.IO
Imports System.Net
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class FaviconAndTitleGetter

    Private Function GetHTML(ByVal URL As String) As String
        Try
            Dim Request As HttpWebRequest = DirectCast(WebRequest.Create(URL), HttpWebRequest)
            Request.Method = "GET"
            Return New System.Text.UTF8Encoding().GetString(New ExtendedBinaryReader(DirectCast(Request.GetResponse, HttpWebResponse).GetResponseStream).ReadToEnd())
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function URLExists(ByVal URL As String) As Boolean
        Try
            Dim WebRequest As WebRequest = WebRequest.Create(New Uri(URL))
            Try
                Dim WebResponse As WebResponse = WebRequest.GetResponse
                WebResponse.Close()
                WebRequest = Nothing
                Return True
            Catch Ex As Exception
                WebRequest = Nothing
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function GetUriScheme(ByVal URL As String) As String
        Dim Scheme As String = ""
        Dim Request As WebRequest = WebRequest.Create(URL)
        Try
            Dim Response As WebResponse = Request.GetResponse
            Scheme = Response.ResponseUri.Scheme
            Response.Close()
            Request = Nothing
            Return Scheme
        Catch Ex As Exception
            Request = Nothing
            Return ""
        End Try
    End Function

    Private Function GetImageFromURL(ByVal URL As String) As Image
        Try
            Dim FIcon As Image = Image.FromStream(HttpWebRequest.Create(URL).GetResponse().GetResponseStream())
            If IsNothing(FIcon) Then
                Return Nothing
            Else
                Return FIcon
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function GetIconFromURL(ByVal URL As String) As Icon
        Try
            Dim FIcon As New Icon(HttpWebRequest.Create(URL).GetResponse().GetResponseStream())
            If IsNothing(FIcon) Then
                Return Nothing
            Else
                Return FIcon
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function FixURL(ByVal URL As String) As String
        Dim scheme As String = GetUriScheme("http://" & New Uri(URL).Host)
        If Not scheme = "" Then
            Return scheme & Mid(URL, URL.IndexOf(":") + 1)
        Else
            Return ""
        End If
    End Function

    Public Function GetFaviconAndTitleInfoFromHTML(ByVal HTML As String) As FAVICONANDTITLEGETTERINFO
        Dim FAVICONANDTITLEGETTERINFO As New FAVICONANDTITLEGETTERINFO
        Dim ResultURL As String = ""
        If Not HTML = "" Then
            For Each node As Html.HtmlNode In New Html.HtmlDocument(HTML, False).All
                If TypeOf (node) Is Html.HtmlElement Then
                    If DirectCast(node, Html.HtmlElement).Name.ToLower = "link" Then
                        If DirectCast(node, Html.HtmlElement).Attributes("rel").Value.ToLower = "shortcut icon" Or DirectCast(node, Html.HtmlElement).Attributes("rel").Value.ToLower = "icon" Then
                            If DirectCast(node, Html.HtmlElement).Attributes("href").Value.StartsWith("http") Then
                                If URLExists(DirectCast(node, Html.HtmlElement).Attributes("href").Value) Then
                                    ResultURL = DirectCast(node, Html.HtmlElement).Attributes("href").Value
                                    FAVICONANDTITLEGETTERINFO.FaviconURLCommandLine = DirectCast(node, Html.HtmlElement).CleanHTML
                                    FAVICONANDTITLEGETTERINFO.FaviconURL = ResultURL
                                    Application.DoEvents()
                                Else
                                    ResultURL = ""
                                    FAVICONANDTITLEGETTERINFO.FaviconURL = ResultURL
                                    Application.DoEvents()
                                End If
                            Else
                                ResultURL = ""
                                FAVICONANDTITLEGETTERINFO.FaviconURL = ResultURL
                                Application.DoEvents()
                            End If
                        End If
                    ElseIf DirectCast(node, Html.HtmlElement).Name.ToLower = "title" Then
                        FAVICONANDTITLEGETTERINFO.Title = Regex.Replace(DirectCast(node, Html.HtmlElement).Text, "\s+", " ")
                        Application.DoEvents()
                    End If
                End If
                Application.DoEvents()
            Next
        End If

        'Get the favicon as icon...
        Try
            FAVICONANDTITLEGETTERINFO.FaviconAsIcon = IIf(Not IsNothing(GetImageFromURL(ResultURL)), IconConverter.ImageToIcon(GetImageFromURL(ResultURL)), Nothing)
        Catch ex As ArgumentNullException
            FAVICONANDTITLEGETTERINFO.FaviconAsIcon = IIf(Not IsNothing(GetIconFromURL(ResultURL)), GetIconFromURL(ResultURL), Nothing)
        End Try

        'Get the favicon as image...
        Try
            FAVICONANDTITLEGETTERINFO.FaviconAsImage = IIf(Not IsNothing(GetImageFromURL(ResultURL)), GetImageFromURL(ResultURL), Nothing)
        Catch ex As ArgumentNullException
            FAVICONANDTITLEGETTERINFO.FaviconAsImage = IIf(Not IsNothing(GetIconFromURL(ResultURL)), GetIconFromURL(ResultURL).ToBitmap, Nothing)
        End Try

        Return FAVICONANDTITLEGETTERINFO

    End Function

    Public Function GetFaviconAndTitleInfo(ByVal URL As String) As FAVICONANDTITLEGETTERINFO
        Dim FAVICONANDTITLEGETTERINFO As New FAVICONANDTITLEGETTERINFO
        Dim ResultURL As String = ""
        Dim HTML As String = GetHTML(URL)
        If Not HTML = "" Then
            For Each node As Html.HtmlNode In New Html.HtmlDocument(HTML, False).All
                If TypeOf (node) Is Html.HtmlElement Then
                    If DirectCast(node, Html.HtmlElement).Name.ToLower = "link" Then
                        If DirectCast(node, Html.HtmlElement).Attributes("rel").Value.ToLower = "shortcut icon" Or DirectCast(node, Html.HtmlElement).Attributes("rel").Value.ToLower = "icon" Then
                            If DirectCast(node, Html.HtmlElement).Attributes("href").Value.StartsWith("http") Then
                                If URLExists(DirectCast(node, Html.HtmlElement).Attributes("href").Value) Then
                                    ResultURL = DirectCast(node, Html.HtmlElement).Attributes("href").Value
                                    FAVICONANDTITLEGETTERINFO.FaviconURLCommandLine = DirectCast(node, Html.HtmlElement).CleanHTML
                                    FAVICONANDTITLEGETTERINFO.FaviconURL = ResultURL
                                    Application.DoEvents()
                                Else
                                    ResultURL = ""
                                    FAVICONANDTITLEGETTERINFO.FaviconURL = ResultURL
                                    Application.DoEvents()
                                End If
                            Else
                                Dim fixedFaviconURL As String = FixURL("http://" & New Uri(URL).Host & DirectCast(IIf(DirectCast(node, Html.HtmlElement).Attributes("href").Value.StartsWith("/"), DirectCast(node, Html.HtmlElement).Attributes("href").Value, "/" & DirectCast(node, Html.HtmlElement).Attributes("href").Value), String))
                                If Not fixedFaviconURL = "" Then
                                    ResultURL = fixedFaviconURL
                                    FAVICONANDTITLEGETTERINFO.FaviconURLCommandLine = DirectCast(node, Html.HtmlElement).CleanHTML
                                    FAVICONANDTITLEGETTERINFO.FaviconURL = ResultURL
                                    Application.DoEvents()
                                Else
                                    ResultURL = ""
                                    FAVICONANDTITLEGETTERINFO.FaviconURL = ResultURL
                                    Application.DoEvents()
                                End If
                            End If
                        End If
                    ElseIf DirectCast(node, Html.HtmlElement).Name.ToLower = "title" Then
                        FAVICONANDTITLEGETTERINFO.Title = Regex.Replace(DirectCast(node, Html.HtmlElement).Text, "\s+", " ")
                        Application.DoEvents()
                    End If
                End If
                Application.DoEvents()
            Next
        End If

        If ResultURL = "" Then
            Dim fixedURL As String = "" : Try : fixedURL = FixURL("http://" & New Uri(URL).Host) : Catch ex As UriFormatException : End Try
            If URLExists(fixedURL & "/favicon.ico") Then
                ResultURL = fixedURL & "/favicon.ico"
                FAVICONANDTITLEGETTERINFO.FaviconURL = ResultURL
            End If
        End If

        'Get the favicon as icon...
        Try
            FAVICONANDTITLEGETTERINFO.FaviconAsIcon = IIf(Not IsNothing(GetImageFromURL(ResultURL)), IconConverter.ImageToIcon(GetImageFromURL(ResultURL)), Nothing)
        Catch ex As ArgumentNullException
            FAVICONANDTITLEGETTERINFO.FaviconAsIcon = IIf(Not IsNothing(GetIconFromURL(ResultURL)), GetIconFromURL(ResultURL), Nothing)
        End Try

        'Get the favicon as image...
        Try
            FAVICONANDTITLEGETTERINFO.FaviconAsImage = IIf(Not IsNothing(GetImageFromURL(ResultURL)), GetImageFromURL(ResultURL), Nothing)
        Catch ex As ArgumentNullException
            FAVICONANDTITLEGETTERINFO.FaviconAsImage = IIf(Not IsNothing(GetIconFromURL(ResultURL)), GetIconFromURL(ResultURL).ToBitmap, Nothing)
        End Try

        Return FAVICONANDTITLEGETTERINFO

    End Function

End Class