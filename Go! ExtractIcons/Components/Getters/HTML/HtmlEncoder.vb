Imports System.IO
Imports System.Text

Namespace Html
    ''' <summary>
    ''' HTML 5 Entity coding routines
    ''' Added HTML 5 encoding by Jonas...
    ''' </summary>
    Friend MustInherit Class HtmlEncoder
        Public Shared Function EncodeValue(ByVal value As String) As String
            Dim output As New StringBuilder()
            Dim reader As New StringReader(value)
            Dim c As Integer = reader.Read()
            While c <> -1
                Select Case c
                    Case Convert.ToInt32("<"c)
                        output.Append("&lt;")
                        Exit Select
                    Case Convert.ToInt32(">"c)
                        output.Append("&gt;")
                        Exit Select
                    Case Convert.ToInt32(""""c)
                        output.Append("&quot;")
                        Exit Select
                    Case Convert.ToInt32("&"c)
                        output.Append("&amp;")
                        Exit Select
                    Case 193
                        output.Append("&Aacute;")
                        Exit Select
                    Case 225
                        output.Append("&aacute;")
                        Exit Select
                    Case 194
                        output.Append("&Acirc;")
                        Exit Select
                    Case 226
                        output.Append("&acirc;")
                        Exit Select
                    Case 180
                        output.Append("&acute;")
                        Exit Select
                    Case 198
                        output.Append("&AElig;")
                        Exit Select
                    Case 230
                        output.Append("&aelig;")
                        Exit Select
                    Case 192
                        output.Append("&Agrave;")
                        Exit Select
                    Case 224
                        output.Append("&agrave;")
                        Exit Select
                    Case 8501
                        output.Append("&alefsym;")
                        Exit Select
                    Case 913
                        output.Append("&Alpha;")
                        Exit Select
                    Case 945
                        output.Append("&alpha;")
                        Exit Select
                    Case 8743
                        output.Append("&and;")
                        Exit Select
                    Case 8736
                        output.Append("&ang;")
                        Exit Select
                    Case 197
                        output.Append("&Aring;")
                        Exit Select
                    Case 229
                        output.Append("&aring;")
                        Exit Select
                    Case 8776
                        output.Append("&asymp;")
                        Exit Select
                    Case 195
                        output.Append("&Atilde;")
                        Exit Select
                    Case 227
                        output.Append("&atilde;")
                        Exit Select
                    Case 196
                        output.Append("&Auml;")
                        Exit Select
                    Case 228
                        output.Append("&auml;")
                        Exit Select
                    Case 8222
                        output.Append("&bdquo;")
                        Exit Select
                    Case 914
                        output.Append("&Beta;")
                        Exit Select
                    Case 946
                        output.Append("&beta;")
                        Exit Select
                    Case 166
                        output.Append("&brvbar;")
                        Exit Select
                    Case 8226
                        output.Append("&bull;")
                        Exit Select
                    Case 8745
                        output.Append("&cap;")
                        Exit Select
                    Case 199
                        output.Append("&Ccedil;")
                        Exit Select
                    Case 231
                        output.Append("&ccedil;")
                        Exit Select
                    Case 184
                        output.Append("&cedil;")
                        Exit Select
                    Case 162
                        output.Append("&cent;")
                        Exit Select
                    Case 935
                        output.Append("&Chi;")
                        Exit Select
                    Case 967
                        output.Append("&chi;")
                        Exit Select
                    Case 710
                        output.Append("&circ;")
                        Exit Select
                    Case 9827
                        output.Append("&clubs;")
                        Exit Select
                    Case 8773
                        output.Append("&cong;")
                        Exit Select
                    Case 169
                        output.Append("&copy;")
                        Exit Select
                    Case 8629
                        output.Append("&crarr;")
                        Exit Select
                    Case 8746
                        output.Append("&cup;")
                        Exit Select
                    Case 164
                        output.Append("&curren;")
                        Exit Select
                    Case 8224
                        output.Append("&dagger;")
                        Exit Select
                    Case 8225
                        output.Append("&Dagger;")
                        Exit Select
                    Case 8595
                        output.Append("&darr;")
                        Exit Select
                    Case 8659
                        output.Append("&dArr;")
                        Exit Select
                    Case 176
                        output.Append("&deg;")
                        Exit Select
                    Case 916
                        output.Append("&Delta;")
                        Exit Select
                    Case 948
                        output.Append("&delta;")
                        Exit Select
                    Case 9830
                        output.Append("&diams;")
                        Exit Select
                    Case 247
                        output.Append("&divide;")
                        Exit Select
                    Case 201
                        output.Append("&Eacute;")
                        Exit Select
                    Case 233
                        output.Append("&eacute;")
                        Exit Select
                    Case 202
                        output.Append("&Ecirc;")
                        Exit Select
                    Case 234
                        output.Append("&ecirc;")
                        Exit Select
                    Case 200
                        output.Append("&Egrave;")
                        Exit Select
                    Case 232
                        output.Append("&egrave;")
                        Exit Select
                    Case 8709
                        output.Append("&empty;")
                        Exit Select
                    Case 8195
                        output.Append("&emsp;")
                        Exit Select
                    Case 917
                        output.Append("&Epsilon;")
                        Exit Select
                    Case 949
                        output.Append("&epsilon;")
                        Exit Select
                    Case 8801
                        output.Append("&equiv;")
                        Exit Select
                    Case 919
                        output.Append("&Eta;")
                        Exit Select
                    Case 951
                        output.Append("&eta;")
                        Exit Select
                    Case 208
                        output.Append("&ETH;")
                        Exit Select
                    Case 240
                        output.Append("&eth;")
                        Exit Select
                    Case 203
                        output.Append("&Euml;")
                        Exit Select
                    Case 235
                        output.Append("&euml;")
                        Exit Select
                    Case 128
                        output.Append("&euro;")
                        Exit Select
                    Case 8707
                        output.Append("&exist;")
                        Exit Select
                    Case 402
                        output.Append("&fnof;")
                        Exit Select
                    Case 8704
                        output.Append("&forall;")
                        Exit Select
                    Case 189
                        output.Append("&frac12;")
                        Exit Select
                    Case 188
                        output.Append("&frac14;")
                        Exit Select
                    Case 190
                        output.Append("&frac34;")
                        Exit Select
                    Case 8260
                        output.Append("&fras1;")
                        Exit Select
                    Case 915
                        output.Append("&Gamma;")
                        Exit Select
                    Case 947
                        output.Append("&gamma;")
                        Exit Select
                    Case 8805
                        output.Append("&ge;")
                        Exit Select
                    Case 8596
                        output.Append("&harr;")
                        Exit Select
                    Case 8660
                        output.Append("&hArr;")
                        Exit Select
                    Case 9829
                        output.Append("&hearts;")
                        Exit Select
                    Case 8230
                        output.Append("&hellip;")
                        Exit Select
                    Case 205
                        output.Append("&Iacute;")
                        Exit Select
                    Case 237
                        output.Append("&iacute;")
                        Exit Select
                    Case 206
                        output.Append("&Icirc;")
                        Exit Select
                    Case 238
                        output.Append("&icirc;")
                        Exit Select
                    Case 161
                        output.Append("&iexcl;")
                        Exit Select
                    Case 204
                        output.Append("&Igrave;")
                        Exit Select
                    Case 236
                        output.Append("&igrave;")
                        Exit Select
                    Case 8465
                        output.Append("&image;")
                        Exit Select
                    Case 8734
                        output.Append("&infin;")
                        Exit Select
                    Case 8747
                        output.Append("&int;")
                        Exit Select
                    Case 921
                        output.Append("&Iota;")
                        Exit Select
                    Case 953
                        output.Append("&iota;")
                        Exit Select
                    Case 191
                        output.Append("&iquest;")
                        Exit Select
                    Case 8712
                        output.Append("&isin;")
                        Exit Select
                    Case 207
                        output.Append("&Iuml;")
                        Exit Select
                    Case 239
                        output.Append("&iuml;")
                        Exit Select
                    Case 922
                        output.Append("&Kappa;")
                        Exit Select
                    Case 954
                        output.Append("&kappa;")
                        Exit Select
                    Case 923
                        output.Append("&Lambda;")
                        Exit Select
                    Case 955
                        output.Append("&lambda;")
                        Exit Select
                    Case 9001
                        output.Append("&lang;")
                        Exit Select
                    Case 171
                        output.Append("&laquo;")
                        Exit Select
                    Case 8592
                        output.Append("&larr;")
                        Exit Select
                    Case 8656
                        output.Append("&lArr;")
                        Exit Select
                    Case 8968
                        output.Append("&lceil;")
                        Exit Select
                    Case 8220
                        output.Append("&ldquo;")
                        Exit Select
                    Case 8804
                        output.Append("&le;")
                        Exit Select
                    Case 8970
                        output.Append("&lfloor;")
                        Exit Select
                    Case 8727
                        output.Append("&lowast;")
                        Exit Select
                    Case 9674
                        output.Append("&loz;")
                        Exit Select
                    Case 8206
                        output.Append("&lrm;")
                        Exit Select
                    Case 8249
                        output.Append("&lsaquo;")
                        Exit Select
                    Case 8216
                        output.Append("&lsquo;")
                        Exit Select
                    Case 175
                        output.Append("&macr;")
                        Exit Select
                    Case 8212
                        output.Append("&mdash;")
                        Exit Select
                    Case 181
                        output.Append("&micro;")
                        Exit Select
                    Case 183
                        output.Append("&middot;")
                        Exit Select
                    Case 8722
                        output.Append("&minus;")
                        Exit Select
                    Case 924
                        output.Append("&Mu;")
                        Exit Select
                    Case 956
                        output.Append("&mu;")
                        Exit Select
                    Case 8711
                        output.Append("&nabla;")
                        Exit Select
                    Case 160
                        output.Append("&nbsp;")
                        Exit Select
                    Case 8211
                        output.Append("&ndash;")
                        Exit Select
                    Case 8800
                        output.Append("&ne;")
                        Exit Select
                    Case 8715
                        output.Append("&ni;")
                        Exit Select
                    Case 172
                        output.Append("&not;")
                        Exit Select
                    Case 8713
                        output.Append("&notin;")
                        Exit Select
                    Case 8836
                        output.Append("&nsub;")
                        Exit Select
                    Case 209
                        output.Append("&Ntilde;")
                        Exit Select
                    Case 241
                        output.Append("&ntilde;")
                        Exit Select
                    Case 925
                        output.Append("&Nu;")
                        Exit Select
                    Case 957
                        output.Append("&nu;")
                        Exit Select
                    Case 211
                        output.Append("&Oacute;")
                        Exit Select
                    Case 243
                        output.Append("&oacute;")
                        Exit Select
                    Case 212
                        output.Append("&Ocirc;")
                        Exit Select
                    Case 244
                        output.Append("&ocirc;")
                        Exit Select
                    Case 338
                        output.Append("&OElig;")
                        Exit Select
                    Case 339
                        output.Append("&oelig;")
                        Exit Select
                    Case 210
                        output.Append("&Ograve;")
                        Exit Select
                    Case 242
                        output.Append("&ograve;")
                        Exit Select
                    Case 8254
                        output.Append("&oline;")
                        Exit Select
                    Case 937
                        output.Append("&Omega;")
                        Exit Select
                    Case 969
                        output.Append("&omega;")
                        Exit Select
                    Case 927
                        output.Append("&Omicron;")
                        Exit Select
                    Case 959
                        output.Append("&omicron;")
                        Exit Select
                    Case 8853
                        output.Append("&oplus;")
                        Exit Select
                    Case 8744
                        output.Append("&or;")
                        Exit Select
                    Case 170
                        output.Append("&ordf;")
                        Exit Select
                    Case 186
                        output.Append("&ordm;")
                        Exit Select
                    Case 216
                        output.Append("&Oslash;")
                        Exit Select
                    Case 248
                        output.Append("&oslash;")
                        Exit Select
                    Case 213
                        output.Append("&Otilde;")
                        Exit Select
                    Case 245
                        output.Append("&otilde;")
                        Exit Select
                    Case 8855
                        output.Append("&otimes;")
                        Exit Select
                    Case 214
                        output.Append("&Ouml;")
                        Exit Select
                    Case 246
                        output.Append("&ouml;")
                        Exit Select
                    Case 182
                        output.Append("&para;")
                        Exit Select
                    Case 8706
                        output.Append("&part;")
                        Exit Select
                    Case 8240
                        output.Append("&permil;")
                        Exit Select
                    Case 8869
                        output.Append("&perp;")
                        Exit Select
                    Case 934
                        output.Append("&Phi;")
                        Exit Select
                    Case 966
                        output.Append("&phi;")
                        Exit Select
                    Case 928
                        output.Append("&Pi;")
                        Exit Select
                    Case 960
                        output.Append("&pi;")
                        Exit Select
                    Case 982
                        output.Append("&piv;")
                        Exit Select
                    Case 177
                        output.Append("&plusmn;")
                        Exit Select
                    Case 163
                        output.Append("&pound;")
                        Exit Select
                    Case 8242
                        output.Append("&prime;")
                        Exit Select
                    Case 8243
                        output.Append("&Prime;")
                        Exit Select
                    Case 8719
                        output.Append("&prod;")
                        Exit Select
                    Case 8733
                        output.Append("&prop;")
                        Exit Select
                    Case 936
                        output.Append("&Psi;")
                        Exit Select
                    Case 968
                        output.Append("&psi;")
                        Exit Select
                    Case 8730
                        output.Append("&radic;")
                        Exit Select
                    Case 9002
                        output.Append("&rang;")
                        Exit Select
                    Case 187
                        output.Append("&raquo;")
                        Exit Select
                    Case 8594
                        output.Append("&rarr;")
                        Exit Select
                    Case 8658
                        output.Append("&rArr;")
                        Exit Select
                    Case 8969
                        output.Append("&rceil;")
                        Exit Select
                    Case 8221
                        output.Append("&rdquo;")
                        Exit Select
                    Case 8476
                        output.Append("&real;")
                        Exit Select
                    Case 174
                        output.Append("&reg;")
                        Exit Select
                    Case 8971
                        output.Append("&rfloor;")
                        Exit Select
                    Case 929
                        output.Append("&Rho;")
                        Exit Select
                    Case 961
                        output.Append("&rho;")
                        Exit Select
                    Case 8207
                        output.Append("&rlm;")
                        Exit Select
                    Case 8250
                        output.Append("&rsaquo;")
                        Exit Select
                    Case 8217
                        output.Append("&rsquo;")
                        Exit Select
                    Case 8218
                        output.Append("&sbquo;")
                        Exit Select
                    Case 352
                        output.Append("&Scaron;")
                        Exit Select
                    Case 353
                        output.Append("&scaron;")
                        Exit Select
                    Case 8901
                        output.Append("&sdot;")
                        Exit Select
                    Case 167
                        output.Append("&sect;")
                        Exit Select
                    Case 173
                        output.Append("&shy;")
                        Exit Select
                    Case 931
                        output.Append("&Sigma;")
                        Exit Select
                    Case 963
                        output.Append("&sigma;")
                        Exit Select
                    Case 962
                        output.Append("&sigmaf;")
                        Exit Select
                    Case 8764
                        output.Append("&sim;")
                        Exit Select
                    Case 9824
                        output.Append("&spades;")
                        Exit Select
                    Case 8834
                        output.Append("&sub;")
                        Exit Select
                    Case 8838
                        output.Append("&sube;")
                        Exit Select
                    Case 8721
                        output.Append("&sum;")
                        Exit Select
                    Case 8835
                        output.Append("&sup;")
                        Exit Select
                    Case 185
                        output.Append("&sup1;")
                        Exit Select
                    Case 178
                        output.Append("&sup2;")
                        Exit Select
                    Case 179
                        output.Append("&sup3;")
                        Exit Select
                    Case 8839
                        output.Append("&supe;")
                        Exit Select
                    Case 223
                        output.Append("&szlig;")
                        Exit Select
                    Case 932
                        output.Append("&Tau;")
                        Exit Select
                    Case 964
                        output.Append("&tau;")
                        Exit Select
                    Case 8756
                        output.Append("&there4;")
                        Exit Select
                    Case 920
                        output.Append("&Theta;")
                        Exit Select
                    Case 952
                        output.Append("&theta;")
                        Exit Select
                    Case 977
                        output.Append("&thetasym;")
                        Exit Select
                    Case 8201
                        output.Append("&thinsp;")
                        Exit Select
                    Case 222
                        output.Append("&THORN;")
                        Exit Select
                    Case 254
                        output.Append("&thorn;")
                        Exit Select
                    Case 732
                        output.Append("&tilde;")
                        Exit Select
                    Case 215
                        output.Append("&times;")
                        Exit Select
                    Case 8482
                        output.Append("&trade;")
                        Exit Select
                    Case 218
                        output.Append("&Uacute;")
                        Exit Select
                    Case 250
                        output.Append("&uacute;")
                        Exit Select
                    Case 8593
                        output.Append("&uarr;")
                        Exit Select
                    Case 8657
                        output.Append("&uArr;")
                        Exit Select
                    Case 219
                        output.Append("&Ucirc;")
                        Exit Select
                    Case 251
                        output.Append("&ucirc;")
                        Exit Select
                    Case 217
                        output.Append("&Ugrave;")
                        Exit Select
                    Case 249
                        output.Append("&ugrave;")
                        Exit Select
                    Case 168
                        output.Append("&uml;")
                        Exit Select
                    Case 978
                        output.Append("&upsih;")
                        Exit Select
                    Case 933
                        output.Append("&Upsilon;")
                        Exit Select
                    Case 965
                        output.Append("&upsilon;")
                        Exit Select
                    Case 220
                        output.Append("&Uuml;")
                        Exit Select
                    Case 252
                        output.Append("&uuml;")
                        Exit Select
                    Case 8472
                        output.Append("&weierp;")
                        Exit Select
                    Case 926
                        output.Append("&Xi;")
                        Exit Select
                    Case 958
                        output.Append("&xi;")
                        Exit Select
                    Case 221
                        output.Append("&Yacute;")
                        Exit Select
                    Case 253
                        output.Append("&yacute;")
                        Exit Select
                    Case 165
                        output.Append("&yen;")
                        Exit Select
                    Case 376
                        output.Append("&Yuml;")
                        Exit Select
                    Case 255
                        output.Append("&yuml;")
                        Exit Select
                    Case 918
                        output.Append("&Zeta;")
                        Exit Select
                    Case 950
                        output.Append("&zeta;")
                        Exit Select
                    Case 8205
                        output.Append("&zwj;")
                        Exit Select
                    Case 8204
                        output.Append("&zwnj;")
                        Exit Select
                    Case Else
                        If c <= 127 Then
                            output.Append(c)
                        Else
                            output.Append("&#" + c + ";")
                        End If
                        Exit Select
                End Select
                c = reader.Read()
                Application.DoEvents()
            End While
            Return output.ToString()
        End Function

        Public Shared Function DecodeValue(ByVal value As String) As String
            Dim output As New StringBuilder()
            Dim reader As New StringReader(value)
            Dim token As StringBuilder
            Dim c As Integer = reader.Read()
            While c <> -1
                token = New StringBuilder()
                While c <> Convert.ToInt32("&"c) AndAlso c <> -1
                    token.Append(ChrW(c))
                    c = reader.Read()
                    Application.DoEvents()
                End While
                output.Append(token.ToString())
                If c = Convert.ToInt32("&"c) Then
                    token = New StringBuilder()
                    While c <> Convert.ToInt32(";"c) AndAlso c <> -1
                        token.Append(ChrW(c))
                        c = reader.Read()
                        Application.DoEvents()
                    End While
                    If c = Convert.ToInt32(";"c) Then
                        c = reader.Read()
                        token.Append(";"c)
                        If token(1) = "#"c Then
                            Try
                                Dim v As Integer = Integer.Parse(token.ToString().Substring(2, token.Length - 3))
                                output.Append(ChrW(v))
                            Catch ex As Exception
                            End Try
                        Else
                            Select Case token.ToString()
                                Case "&lt;"
                                    output.Append("<")
                                    Exit Select
                                Case "&gt;"
                                    output.Append(">")
                                    Exit Select
                                Case "&quot;"
                                    output.Append("""")
                                    Exit Select
                                Case "&amp;"
                                    output.Append("&")
                                    Exit Select
                                Case "&Aacute;"
                                    output.Append(ChrW(193))
                                    Exit Select
                                Case "&aacute;"
                                    output.Append(ChrW(225))
                                    Exit Select
                                Case "&Acirc;"
                                    output.Append(ChrW(194))
                                    Exit Select
                                Case "&acirc;"
                                    output.Append(ChrW(226))
                                    Exit Select
                                Case "&acute;"
                                    output.Append(ChrW(180))
                                    Exit Select
                                Case "&AElig;"
                                    output.Append(ChrW(198))
                                    Exit Select
                                Case "&aelig;"
                                    output.Append(ChrW(230))
                                    Exit Select
                                Case "&Agrave;"
                                    output.Append(ChrW(192))
                                    Exit Select
                                Case "&agrave;"
                                    output.Append(ChrW(224))
                                    Exit Select
                                Case "&alefsym;"
                                    output.Append(ChrW(8501))
                                    Exit Select
                                Case "&Alpha;"
                                    output.Append(ChrW(913))
                                    Exit Select
                                Case "&alpha;"
                                    output.Append(ChrW(945))
                                    Exit Select
                                Case "&and;"
                                    output.Append(ChrW(8743))
                                    Exit Select
                                Case "&ang;"
                                    output.Append(ChrW(8736))
                                    Exit Select
                                Case "&Aring;"
                                    output.Append(ChrW(197))
                                    Exit Select
                                Case "&aring;"
                                    output.Append(ChrW(229))
                                    Exit Select
                                Case "&asymp;"
                                    output.Append(ChrW(8776))
                                    Exit Select
                                Case "&Atilde;"
                                    output.Append(ChrW(195))
                                    Exit Select
                                Case "&atilde;"
                                    output.Append(ChrW(227))
                                    Exit Select
                                Case "&Auml;"
                                    output.Append(ChrW(196))
                                    Exit Select
                                Case "&auml;"
                                    output.Append(ChrW(228))
                                    Exit Select
                                Case "&bdquo;"
                                    output.Append(ChrW(8222))
                                    Exit Select
                                Case "&Beta;"
                                    output.Append(ChrW(914))
                                    Exit Select
                                Case "&beta;"
                                    output.Append(ChrW(946))
                                    Exit Select
                                Case "&brvbar;"
                                    output.Append(ChrW(166))
                                    Exit Select
                                Case "&bull;"
                                    output.Append(ChrW(8226))
                                    Exit Select
                                Case "&cap;"
                                    output.Append(ChrW(8745))
                                    Exit Select
                                Case "&Ccedil;"
                                    output.Append(ChrW(199))
                                    Exit Select
                                Case "&ccedil;"
                                    output.Append(ChrW(231))
                                    Exit Select
                                Case "&cedil;"
                                    output.Append(ChrW(184))
                                    Exit Select
                                Case "&cent;"
                                    output.Append(ChrW(162))
                                    Exit Select
                                Case "&Chi;"
                                    output.Append(ChrW(935))
                                    Exit Select
                                Case "&chi;"
                                    output.Append(ChrW(967))
                                    Exit Select
                                Case "&circ;"
                                    output.Append(ChrW(710))
                                    Exit Select
                                Case "&clubs;"
                                    output.Append(ChrW(9827))
                                    Exit Select
                                Case "&cong;"
                                    output.Append(ChrW(8773))
                                    Exit Select
                                Case "&copy;"
                                    output.Append(ChrW(169))
                                    Exit Select
                                Case "&crarr;"
                                    output.Append(ChrW(8629))
                                    Exit Select
                                Case "&cup;"
                                    output.Append(ChrW(8746))
                                    Exit Select
                                Case "&curren;"
                                    output.Append(ChrW(164))
                                    Exit Select
                                Case "&dagger;"
                                    output.Append(ChrW(8224))
                                    Exit Select
                                Case "&Dagger;"
                                    output.Append(ChrW(8225))
                                    Exit Select
                                Case "&darr;"
                                    output.Append(ChrW(8595))
                                    Exit Select
                                Case "&dArr;"
                                    output.Append(ChrW(8659))
                                    Exit Select
                                Case "&deg;"
                                    output.Append(ChrW(176))
                                    Exit Select
                                Case "&Delta;"
                                    output.Append(ChrW(916))
                                    Exit Select
                                Case "&delta;"
                                    output.Append(ChrW(948))
                                    Exit Select
                                Case "&diams;"
                                    output.Append(ChrW(9830))
                                    Exit Select
                                Case "&divide;"
                                    output.Append(ChrW(247))
                                    Exit Select
                                Case "&Eacute;"
                                    output.Append(ChrW(201))
                                    Exit Select
                                Case "&eacute;"
                                    output.Append(ChrW(233))
                                    Exit Select
                                Case "&Ecirc;"
                                    output.Append(ChrW(202))
                                    Exit Select
                                Case "&ecirc;"
                                    output.Append(ChrW(234))
                                    Exit Select
                                Case "&Egrave;"
                                    output.Append(ChrW(200))
                                    Exit Select
                                Case "&egrave;"
                                    output.Append(ChrW(232))
                                    Exit Select
                                Case "&empty;"
                                    output.Append(ChrW(8709))
                                    Exit Select
                                Case "&emsp;"
                                    output.Append(ChrW(8195))
                                    Exit Select
                                Case "&Epsilon;"
                                    output.Append(ChrW(917))
                                    Exit Select
                                Case "&epsilon;"
                                    output.Append(ChrW(949))
                                    Exit Select
                                Case "&equiv;"
                                    output.Append(ChrW(8801))
                                    Exit Select
                                Case "&Eta;"
                                    output.Append(ChrW(919))
                                    Exit Select
                                Case "&eta;"
                                    output.Append(ChrW(951))
                                    Exit Select
                                Case "&ETH;"
                                    output.Append(ChrW(208))
                                    Exit Select
                                Case "&eth;"
                                    output.Append(ChrW(240))
                                    Exit Select
                                Case "&Euml;"
                                    output.Append(ChrW(203))
                                    Exit Select
                                Case "&euml;"
                                    output.Append(ChrW(235))
                                    Exit Select
                                Case "&euro;"
                                    output.Append(ChrW(128))
                                    Exit Select
                                Case "&exist;"
                                    output.Append(ChrW(8707))
                                    Exit Select
                                Case "&fnof;"
                                    output.Append(ChrW(402))
                                    Exit Select
                                Case "&forall;"
                                    output.Append(ChrW(8704))
                                    Exit Select
                                Case "&frac12;"
                                    output.Append(ChrW(189))
                                    Exit Select
                                Case "&frac14;"
                                    output.Append(ChrW(188))
                                    Exit Select
                                Case "&frac34;"
                                    output.Append(ChrW(190))
                                    Exit Select
                                Case "&fras1;"
                                    output.Append(ChrW(8260))
                                    Exit Select
                                Case "&Gamma;"
                                    output.Append(ChrW(915))
                                    Exit Select
                                Case "&gamma;"
                                    output.Append(ChrW(947))
                                    Exit Select
                                Case "&ge;"
                                    output.Append(ChrW(8805))
                                    Exit Select
                                Case "&harr;"
                                    output.Append(ChrW(8596))
                                    Exit Select
                                Case "&hArr;"
                                    output.Append(ChrW(8660))
                                    Exit Select
                                Case "&hearts;"
                                    output.Append(ChrW(9829))
                                    Exit Select
                                Case "&hellip;"
                                    output.Append(ChrW(8230))
                                    Exit Select
                                Case "&Iacute;"
                                    output.Append(ChrW(205))
                                    Exit Select
                                Case "&iacute;"
                                    output.Append(ChrW(237))
                                    Exit Select
                                Case "&Icirc;"
                                    output.Append(ChrW(206))
                                    Exit Select
                                Case "&icirc;"
                                    output.Append(ChrW(238))
                                    Exit Select
                                Case "&iexcl;"
                                    output.Append(ChrW(161))
                                    Exit Select
                                Case "&Igrave;"
                                    output.Append(ChrW(204))
                                    Exit Select
                                Case "&igrave;"
                                    output.Append(ChrW(236))
                                    Exit Select
                                Case "&image;"
                                    output.Append(ChrW(8465))
                                    Exit Select
                                Case "&infin;"
                                    output.Append(ChrW(8734))
                                    Exit Select
                                Case "&int;"
                                    output.Append(ChrW(8747))
                                    Exit Select
                                Case "&Iota;"
                                    output.Append(ChrW(921))
                                    Exit Select
                                Case "&iota;"
                                    output.Append(ChrW(953))
                                    Exit Select
                                Case "&iquest;"
                                    output.Append(ChrW(191))
                                    Exit Select
                                Case "&isin;"
                                    output.Append(ChrW(8712))
                                    Exit Select
                                Case "&Iuml;"
                                    output.Append(ChrW(207))
                                    Exit Select
                                Case "&iuml;"
                                    output.Append(ChrW(239))
                                    Exit Select
                                Case "&Kappa;"
                                    output.Append(ChrW(922))
                                    Exit Select
                                Case "&kappa;"
                                    output.Append(ChrW(954))
                                    Exit Select
                                Case "&Lambda;"
                                    output.Append(ChrW(923))
                                    Exit Select
                                Case "&lambda;"
                                    output.Append(ChrW(955))
                                    Exit Select
                                Case "&lang;"
                                    output.Append(ChrW(9001))
                                    Exit Select
                                Case "&laquo;"
                                    output.Append(ChrW(171))
                                    Exit Select
                                Case "&larr;"
                                    output.Append(ChrW(8592))
                                    Exit Select
                                Case "&lArr;"
                                    output.Append(ChrW(8656))
                                    Exit Select
                                Case "&lceil;"
                                    output.Append(ChrW(8968))
                                    Exit Select
                                Case "&ldquo;"
                                    output.Append(ChrW(8220))
                                    Exit Select
                                Case "&le;"
                                    output.Append(ChrW(8804))
                                    Exit Select
                                Case "&lfloor;"
                                    output.Append(ChrW(8970))
                                    Exit Select
                                Case "&lowast;"
                                    output.Append(ChrW(8727))
                                    Exit Select
                                Case "&loz;"
                                    output.Append(ChrW(9674))
                                    Exit Select
                                Case "&lrm;"
                                    output.Append(ChrW(8206))
                                    Exit Select
                                Case "&lsaquo;"
                                    output.Append(ChrW(8249))
                                    Exit Select
                                Case "&lsquo;"
                                    output.Append(ChrW(8216))
                                    Exit Select
                                Case "&macr;"
                                    output.Append(ChrW(175))
                                    Exit Select
                                Case "&mdash;"
                                    output.Append(ChrW(8212))
                                    Exit Select
                                Case "&micro;"
                                    output.Append(ChrW(181))
                                    Exit Select
                                Case "&middot;"
                                    output.Append(ChrW(183))
                                    Exit Select
                                Case "&minus;"
                                    output.Append(ChrW(8722))
                                    Exit Select
                                Case "&Mu;"
                                    output.Append(ChrW(924))
                                    Exit Select
                                Case "&mu;"
                                    output.Append(ChrW(956))
                                    Exit Select
                                Case "&nabla;"
                                    output.Append(ChrW(8711))
                                    Exit Select
                                Case "&nbsp;"
                                    output.Append(ChrW(160))
                                    Exit Select
                                Case "&ndash;"
                                    output.Append(ChrW(8211))
                                    Exit Select
                                Case "&ne;"
                                    output.Append(ChrW(8800))
                                    Exit Select
                                Case "&ni;"
                                    output.Append(ChrW(8715))
                                    Exit Select
                                Case "&not;"
                                    output.Append(ChrW(172))
                                    Exit Select
                                Case "&notin;"
                                    output.Append(ChrW(8713))
                                    Exit Select
                                Case "&nsub;"
                                    output.Append(ChrW(8836))
                                    Exit Select
                                Case "&Ntilde;"
                                    output.Append(ChrW(209))
                                    Exit Select
                                Case "&ntilde;"
                                    output.Append(ChrW(241))
                                    Exit Select
                                Case "&Nu;"
                                    output.Append(ChrW(925))
                                    Exit Select
                                Case "&nu;"
                                    output.Append(ChrW(957))
                                    Exit Select
                                Case "&Oacute;"
                                    output.Append(ChrW(211))
                                    Exit Select
                                Case "&oacute;"
                                    output.Append(ChrW(243))
                                    Exit Select
                                Case "&Ocirc;"
                                    output.Append(ChrW(212))
                                    Exit Select
                                Case "&ocirc;"
                                    output.Append(ChrW(244))
                                    Exit Select
                                Case "&OElig;"
                                    output.Append(ChrW(338))
                                    Exit Select
                                Case "&oelig;"
                                    output.Append(ChrW(339))
                                    Exit Select
                                Case "&Ograve;"
                                    output.Append(ChrW(210))
                                    Exit Select
                                Case "&ograve;"
                                    output.Append(ChrW(242))
                                    Exit Select
                                Case "&oline;"
                                    output.Append(ChrW(8254))
                                    Exit Select
                                Case "&Omega;"
                                    output.Append(ChrW(937))
                                    Exit Select
                                Case "&omega;"
                                    output.Append(ChrW(969))
                                    Exit Select
                                Case "&Omicron;"
                                    output.Append(ChrW(927))
                                    Exit Select
                                Case "&omicron;"
                                    output.Append(ChrW(959))
                                    Exit Select
                                Case "&oplus;"
                                    output.Append(ChrW(8853))
                                    Exit Select
                                Case "&or;"
                                    output.Append(ChrW(8744))
                                    Exit Select
                                Case "&ordf;"
                                    output.Append(ChrW(170))
                                    Exit Select
                                Case "&ordm;"
                                    output.Append(ChrW(186))
                                    Exit Select
                                Case "&Oslash;"
                                    output.Append(ChrW(216))
                                    Exit Select
                                Case "&oslash;"
                                    output.Append(ChrW(248))
                                    Exit Select
                                Case "&Otilde;"
                                    output.Append(ChrW(213))
                                    Exit Select
                                Case "&otilde;"
                                    output.Append(ChrW(245))
                                    Exit Select
                                Case "&otimes;"
                                    output.Append(ChrW(8855))
                                    Exit Select
                                Case "&Ouml;"
                                    output.Append(ChrW(214))
                                    Exit Select
                                Case "&ouml;"
                                    output.Append(ChrW(246))
                                    Exit Select
                                Case "&para;"
                                    output.Append(ChrW(182))
                                    Exit Select
                                Case "&part;"
                                    output.Append(ChrW(8706))
                                    Exit Select
                                Case "&permil;"
                                    output.Append(ChrW(8240))
                                    Exit Select
                                Case "&perp;"
                                    output.Append(ChrW(8869))
                                    Exit Select
                                Case "&Phi;"
                                    output.Append(ChrW(934))
                                    Exit Select
                                Case "&phi;"
                                    output.Append(ChrW(966))
                                    Exit Select
                                Case "&Pi;"
                                    output.Append(ChrW(928))
                                    Exit Select
                                Case "&pi;"
                                    output.Append(ChrW(960))
                                    Exit Select
                                Case "&piv;"
                                    output.Append(ChrW(982))
                                    Exit Select
                                Case "&plusmn;"
                                    output.Append(ChrW(177))
                                    Exit Select
                                Case "&pound;"
                                    output.Append(ChrW(163))
                                    Exit Select
                                Case "&prime;"
                                    output.Append(ChrW(8242))
                                    Exit Select
                                Case "&Prime;"
                                    output.Append(ChrW(8243))
                                    Exit Select
                                Case "&prod;"
                                    output.Append(ChrW(8719))
                                    Exit Select
                                Case "&prop;"
                                    output.Append(ChrW(8733))
                                    Exit Select
                                Case "&Psi;"
                                    output.Append(ChrW(936))
                                    Exit Select
                                Case "&psi;"
                                    output.Append(ChrW(968))
                                    Exit Select
                                Case "&radic;"
                                    output.Append(ChrW(8730))
                                    Exit Select
                                Case "&rang;"
                                    output.Append(ChrW(9002))
                                    Exit Select
                                Case "&raquo;"
                                    output.Append(ChrW(187))
                                    Exit Select
                                Case "&rarr;"
                                    output.Append(ChrW(8594))
                                    Exit Select
                                Case "&rArr;"
                                    output.Append(ChrW(8658))
                                    Exit Select
                                Case "&rceil;"
                                    output.Append(ChrW(8969))
                                    Exit Select
                                Case "&rdquo;"
                                    output.Append(ChrW(8221))
                                    Exit Select
                                Case "&real;"
                                    output.Append(ChrW(8476))
                                    Exit Select
                                Case "&reg;"
                                    output.Append(ChrW(174))
                                    Exit Select
                                Case "&rfloor;"
                                    output.Append(ChrW(8971))
                                    Exit Select
                                Case "&Rho;"
                                    output.Append(ChrW(929))
                                    Exit Select
                                Case "&rho;"
                                    output.Append(ChrW(961))
                                    Exit Select
                                Case "&rlm;"
                                    output.Append(ChrW(8207))
                                    Exit Select
                                Case "&rsaquo;"
                                    output.Append(ChrW(8250))
                                    Exit Select
                                Case "&rsquo;"
                                    output.Append(ChrW(8217))
                                    Exit Select
                                Case "&sbquo;"
                                    output.Append(ChrW(8218))
                                    Exit Select
                                Case "&Scaron;"
                                    output.Append(ChrW(352))
                                    Exit Select
                                Case "&scaron;"
                                    output.Append(ChrW(353))
                                    Exit Select
                                Case "&sdot;"
                                    output.Append(ChrW(8901))
                                    Exit Select
                                Case "&sect;"
                                    output.Append(ChrW(167))
                                    Exit Select
                                Case "&shy;"
                                    output.Append(ChrW(173))
                                    Exit Select
                                Case "&Sigma;"
                                    output.Append(ChrW(931))
                                    Exit Select
                                Case "&sigma;"
                                    output.Append(ChrW(963))
                                    Exit Select
                                Case "&sigmaf;"
                                    output.Append(ChrW(962))
                                    Exit Select
                                Case "&sim;"
                                    output.Append(ChrW(8764))
                                    Exit Select
                                Case "&spades;"
                                    output.Append(ChrW(9824))
                                    Exit Select
                                Case "&sub;"
                                    output.Append(ChrW(8834))
                                    Exit Select
                                Case "&sube;"
                                    output.Append(ChrW(8838))
                                    Exit Select
                                Case "&sum;"
                                    output.Append(ChrW(8721))
                                    Exit Select
                                Case "&sup;"
                                    output.Append(ChrW(8835))
                                    Exit Select
                                Case "&sup1;"
                                    output.Append(ChrW(185))
                                    Exit Select
                                Case "&sup2;"
                                    output.Append(ChrW(178))
                                    Exit Select
                                Case "&sup3;"
                                    output.Append(ChrW(179))
                                    Exit Select
                                Case "&supe;"
                                    output.Append(ChrW(8839))
                                    Exit Select
                                Case "&szlig;"
                                    output.Append(ChrW(223))
                                    Exit Select
                                Case "&Tau;"
                                    output.Append(ChrW(932))
                                    Exit Select
                                Case "&tau;"
                                    output.Append(ChrW(964))
                                    Exit Select
                                Case "&there4;"
                                    output.Append(ChrW(8756))
                                    Exit Select
                                Case "&Theta;"
                                    output.Append(ChrW(920))
                                    Exit Select
                                Case "&theta;"
                                    output.Append(ChrW(952))
                                    Exit Select
                                Case "&thetasym;"
                                    output.Append(ChrW(977))
                                    Exit Select
                                Case "&thinsp;"
                                    output.Append(ChrW(8201))
                                    Exit Select
                                Case "&THORN;"
                                    output.Append(ChrW(222))
                                    Exit Select
                                Case "&thorn;"
                                    output.Append(ChrW(254))
                                    Exit Select
                                Case "&tilde;"
                                    output.Append(ChrW(732))
                                    Exit Select
                                Case "&times;"
                                    output.Append(ChrW(215))
                                    Exit Select
                                Case "&trade;"
                                    output.Append(ChrW(8482))
                                    Exit Select
                                Case "&Uacute;"
                                    output.Append(ChrW(218))
                                    Exit Select
                                Case "&uacute;"
                                    output.Append(ChrW(250))
                                    Exit Select
                                Case "&uarr;"
                                    output.Append(ChrW(8593))
                                    Exit Select
                                Case "&uArr;"
                                    output.Append(ChrW(8657))
                                    Exit Select
                                Case "&Ucirc;"
                                    output.Append(ChrW(219))
                                    Exit Select
                                Case "&ucirc;"
                                    output.Append(ChrW(251))
                                    Exit Select
                                Case "&Ugrave;"
                                    output.Append(ChrW(217))
                                    Exit Select
                                Case "&ugrave;"
                                    output.Append(ChrW(249))
                                    Exit Select
                                Case "&uml;"
                                    output.Append(ChrW(168))
                                    Exit Select
                                Case "&upsih;"
                                    output.Append(ChrW(978))
                                    Exit Select
                                Case "&Upsilon;"
                                    output.Append(ChrW(933))
                                    Exit Select
                                Case "&upsilon;"
                                    output.Append(ChrW(965))
                                    Exit Select
                                Case "&Uuml;"
                                    output.Append(ChrW(220))
                                    Exit Select
                                Case "&uuml;"
                                    output.Append(ChrW(252))
                                    Exit Select
                                Case "&weierp;"
                                    output.Append(ChrW(8472))
                                    Exit Select
                                Case "&Xi;"
                                    output.Append(ChrW(926))
                                    Exit Select
                                Case "&xi;"
                                    output.Append(ChrW(958))
                                    Exit Select
                                Case "&Yacute;"
                                    output.Append(ChrW(221))
                                    Exit Select
                                Case "&yacute;"
                                    output.Append(ChrW(253))
                                    Exit Select
                                Case "&yen;"
                                    output.Append(ChrW(165))
                                    Exit Select
                                Case "&Yuml;"
                                    output.Append(ChrW(376))
                                    Exit Select
                                Case "&yuml;"
                                    output.Append(ChrW(255))
                                    Exit Select
                                Case "&Zeta;"
                                    output.Append(ChrW(918))
                                    Exit Select
                                Case "&zeta;"
                                    output.Append(ChrW(950))
                                    Exit Select
                                Case "&zwj;"
                                    output.Append(ChrW(8205))
                                    Exit Select
                                Case "&zwnj;"
                                    output.Append(ChrW(8204))
                                    Exit Select
                                Case Else
                                    output.Append(token.ToString())
                                    Exit Select
                            End Select
                        End If
                    Else
                        output.Append(token.ToString())
                    End If
                End If
                Application.DoEvents()
            End While
            Return output.ToString()
        End Function
    End Class
End Namespace