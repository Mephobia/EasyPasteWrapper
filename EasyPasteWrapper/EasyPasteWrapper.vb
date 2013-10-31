Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Collections.Specialized
Imports System.Text.RegularExpressions

Namespace EasyPasteWrapper
    Public Class Functions
        Shared HttpLib As New HTTP

        Public Enum HighlightCodes
            None
            ActionScript
            Apache
            AppleScript
            AsciiDoc
            AVRAssembler
            Axapta
            Bash
            Brainfuck
            Clojure
            CMake
            CoffeeScript
            CPP
            C
            CSharp
            CSS
            D
            Delphi
            Diff
            Django
            DOS
            ErlangREPL
            Erlang
            FSharp
            GLSL
            Go
            Haml
            Handlebars
            Haskell
            HTTP
            Ini
            Java
            JavaScript
            JSON
            Lasso
            Lisp
            Lua
            Markdown
            Matlab
            Mel
            Mizar
            NGinx
            ObjectiveC
            Parser3
            Perl
            PHP
            Profile
            Python
            R
            RenderManRIB
            RenderManRSL
            Ruby
            Rust
            Scala
            SmallTalk
            SQL
            TeX
            Vala
            VisualBasic
            VBScript
            XML
        End Enum

        Public Function CreatePaste(ByVal author As String, ByVal title As String, ByVal paste As String, ByVal unlisted As Boolean, ByVal highlightCode As HighlightCodes) As String
            Dim pasteLink As String = "http://ubbe.me/pastes/"
            Dim sb As New StringBuilder

            sb.AppendLine("author=" + author)
            sb.AppendLine("&title=" + title)
            sb.AppendLine("&data=" + paste)

            If unlisted = True Then
                sb.AppendLine("&unlisted=on")
            Else
                sb.AppendLine("&unlisted=off")
            End If

            Select Case highlightCode
                Case HighlightCodes.None
                    sb.AppendLine("&highlight=" + "no-highlight")
                Case HighlightCodes.ActionScript
                    sb.AppendLine("&highlight=" + "actionscript")
                Case HighlightCodes.Apache
                    sb.AppendLine("&highlight=" + "apache")
                Case HighlightCodes.AppleScript
                    sb.AppendLine("&highlight=" + "applescript")
                Case HighlightCodes.AsciiDoc
                    sb.AppendLine("&highlight=" + "asciidoc")
                Case HighlightCodes.AVRAssembler
                    sb.AppendLine("&highlight=" + "avrasm")
                Case HighlightCodes.Axapta
                    sb.AppendLine("&highlight=" + "axapta")
                Case HighlightCodes.Bash
                    sb.AppendLine("&highlight=" + "base")
                Case HighlightCodes.Brainfuck
                    sb.AppendLine("&highlight=" + "brainfuck")
                Case HighlightCodes.Clojure
                    sb.AppendLine("&highlight=" + "clojure")
                Case HighlightCodes.CMake
                    sb.AppendLine("&highlight=" + "cmake")
                Case HighlightCodes.CoffeeScript
                    sb.AppendLine("&highlight=" + "coffeescript")
                Case HighlightCodes.CPP
                    sb.AppendLine("&highlight=" + "cpp")
                Case HighlightCodes.C
                    sb.AppendLine("&highlight=" + "c")
                Case HighlightCodes.CSharp
                    sb.AppendLine("&highlight=" + "cs")
                Case HighlightCodes.CSS
                    sb.AppendLine("&highlight=" + "css")
                Case HighlightCodes.D
                    sb.AppendLine("&highlight=" + "d")
                Case HighlightCodes.Delphi
                    sb.AppendLine("&highlight=" + "delphi")
                Case HighlightCodes.Diff
                    sb.AppendLine("&highlight=" + "diff")
                Case HighlightCodes.Django
                    sb.AppendLine("&highlight=" + "django")
                Case HighlightCodes.DOS
                    sb.AppendLine("&highlight=" + "dos")
                Case HighlightCodes.ErlangREPL
                    sb.AppendLine("&highlight=" + "erlang-repl")
                Case HighlightCodes.Erlang
                    sb.AppendLine("&highlight=" + "erlang")
                Case HighlightCodes.FSharp
                    sb.AppendLine("&highlight=" + "fsharp")
                Case HighlightCodes.GLSL
                    sb.AppendLine("&highlight=" + "glsl")
                Case HighlightCodes.Go
                    sb.AppendLine("&highlight=" + "go")
                Case HighlightCodes.Haml
                    sb.AppendLine("&highlight=" + "haml")
                Case HighlightCodes.Handlebars
                    sb.AppendLine("&highlight=" + "handlebars")
                Case HighlightCodes.Haskell
                    sb.AppendLine("&highlight=" + "haskell")
                Case HighlightCodes.HTTP
                    sb.AppendLine("&highlight=" + "http")
                Case HighlightCodes.Ini
                    sb.AppendLine("&highlight=" + "ini")
                Case HighlightCodes.Java
                    sb.AppendLine("&highlight=" + "java")
                Case HighlightCodes.JavaScript
                    sb.AppendLine("&highlight=" + "javascript")
                Case HighlightCodes.JSON
                    sb.AppendLine("&highlight=" + "json")
                Case HighlightCodes.Lasso
                    sb.AppendLine("&highlight=" + "lasso")
                Case HighlightCodes.Lisp
                    sb.AppendLine("&highlight=" + "lisp")
                Case HighlightCodes.Lua
                    sb.AppendLine("&highlight=" + "lua")
                Case HighlightCodes.Markdown
                    sb.AppendLine("&highlight=" + "markdown")
                Case HighlightCodes.Matlab
                    sb.AppendLine("&highlight=" + "matlab")
                Case HighlightCodes.Mel
                    sb.AppendLine("&highlight=" + "mel")
                Case HighlightCodes.Mizar
                    sb.AppendLine("&highlight=" + "mizar")
                Case HighlightCodes.NGinx
                    sb.AppendLine("&highlight=" + "nginx")
                Case HighlightCodes.ObjectiveC
                    sb.AppendLine("&highlight=" + "objectivec")
                Case HighlightCodes.Parser3
                    sb.AppendLine("&highlight=" + "parser3")
                Case HighlightCodes.Perl
                    sb.AppendLine("&highlight=" + "perl")
                Case HighlightCodes.PHP
                    sb.AppendLine("&highlight=" + "php")
                Case HighlightCodes.Profile
                    sb.AppendLine("&highlight=" + "profile")
                Case HighlightCodes.Python
                    sb.AppendLine("&highlight=" + "python")
                Case HighlightCodes.R
                    sb.AppendLine("&highlight=" + "r")
                Case HighlightCodes.RenderManRIB
                    sb.AppendLine("&highlight=" + "rib")
                Case HighlightCodes.RenderManRSL
                    sb.AppendLine("&highlight=" + "rsl")
                Case HighlightCodes.Ruby
                    sb.AppendLine("&highlight=" + "ruby")
                Case HighlightCodes.Rust
                    sb.AppendLine("&highlight=" + "rust")
                Case HighlightCodes.Scala
                    sb.AppendLine("&highlight=" + "scala")
                Case HighlightCodes.SmallTalk
                    sb.AppendLine("&highlight=" + "smalltalk")
                Case HighlightCodes.SQL
                    sb.AppendLine("&highlight=" + "sql")
                Case HighlightCodes.TeX
                    sb.AppendLine("&highlight=" + "tex")
                Case HighlightCodes.Vala
                    sb.AppendLine("&highlight=" + "vala")
                Case HighlightCodes.VisualBasic
                    sb.AppendLine("&highlight=" + "vbnet")
                Case HighlightCodes.VBScript
                    sb.AppendLine("&highlight=" + "vbscript")
                Case HighlightCodes.XML
                    sb.AppendLine("&highlight=" + "xml")
            End Select

            Dim pageResults As String = HttpLib.PostRequest(sb.ToString(), "http://ubbe.me/api/v1/pastes/create", "http://ubbe.me/")

            If pageResults.Contains("{" & """" & "status" & """" & ":" & """" & "OK" & """") Then
                pasteLink += Parsing.GetBetween(pageResults, "," & """" & "id" & """" & ":" & """", """" & "}")
            Else
                pasteLink = "ERROR"
            End If

            Return pasteLink
        End Function

        Public Function GetPasteContent(ByVal ID As String) As String
            Dim pageSource As String = HttpLib.CookieRequest("http://ubbe.me/api/v1/pastes/" + ID)
            Dim paste As String = Parsing.GetBetween(pageSource, """" & "," & """" & "data" & """" & ":" & """", """" & "," & """" & "length" & """" & ":" & """")

            paste = paste.Replace("\r\n", vbNewLine)
            paste = paste.Replace("\" & """", """")

            Return paste
        End Function

        Public Function GetTotalPastes() As Integer
            Dim pageSource As String = HttpLib.CookieRequest("http://ubbe.me/api/v1/pastes")
            Dim pasteNumber As String = Parsing.GetBetween(pageSource, "{" & """" & "count" & """" & ":" & """", """" & "}")

            Return Integer.Parse(pasteNumber)
        End Function

        Public Function GetPasteViews(ByVal ID As String) As Integer
            Dim pageSource As String = HttpLib.CookieRequest("http://ubbe.me/api/v1/pastes/" + ID)
            Dim pasteViews As String = Parsing.GetBetween(pageSource, """" & "," & """" & "views" & """" & ":" & """", """" & "}")

            Return Integer.Parse(pasteViews)
        End Function

        Public Function GetPasteDate(ByVal ID As String) As String
            Dim pageSource As String = HttpLib.CookieRequest("http://ubbe.me/api/v1/pastes/" + ID)
            Dim pasteDate As String = Parsing.GetBetween(pageSource, """" & "," & """" & "uploaded" & """" & ":" & """", """" & "," & """" & "views" & """")

            Return pasteDate
        End Function

        Public Function GetPasteAuthor(ByVal ID As String) As String
            Dim pageSource As String = HttpLib.CookieRequest("http://ubbe.me/api/v1/pastes/" + ID)
            Dim pasteAuthor As String = Parsing.GetBetween(pageSource, """" & "," & """" & "author" & """" & ":" & """", """" & "," & """" & "data" & """")

            Return pasteAuthor
        End Function

        Public Function GetPasteTitle(ByVal ID As String) As String
            Dim pageSource As String = HttpLib.CookieRequest("http://ubbe.me/api/v1/pastes/" + ID)
            Dim pasteTitle As String = Parsing.GetBetween(pageSource, """" & "," & """" & "title" & """" & ":" & """", """" & "," & """" & "unlisted" & """")

            Return pasteTitle
        End Function

        Public Function GetPasteRange(ByVal min As Integer, ByVal max As Integer) As List(Of String)
            Dim outputList As New List(Of String)
            Dim pageSource As String = HttpLib.CookieRequest("http://ubbe.me/api/v1/pastes/0/200")
            Dim onlyIDs As String = Parsing.GetBetween(pageSource, "[", "]")
            Dim splitIDs As String() = onlyIDs.Split(",")

            If min > 200 Or min > splitIDs.Length Or max > 200 Or max > splitIDs.Length Then
                outputList.Add("OutOfRange Error: Your minimum or maximum value is outside the range of pastes")
                Return outputList
            Else
                For start As Integer = min To max
                    outputList.Add("http://ubbe.me/pastes/" + Parsing.GetBetween(splitIDs(start), "{" & """" & "id" & """" & ":" & """", """" & "}"))
                Next
            End If

            Return outputList
        End Function
    End Class

    Public Class HTTP
        Public Shared PermCookie As New CookieContainer
        Public Function PostRequest(ByVal PostData As String, ByVal Request As String, ByVal Referer As String) As String
            Dim PData As String = PostData
            Dim Encoding As New ASCIIEncoding
            Dim ByteData As Byte() = Encoding.GetBytes(PostData)
            Dim RQuest As HttpWebRequest = HttpWebRequest.Create(Request)
            RQuest.Method = "POST"
            RQuest.KeepAlive = True
            RQuest.CookieContainer = PermCookie
            RQuest.ContentType = "application/x-www-form-urlencoded"
            RQuest.Referer = Referer
            RQuest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:24.0) Gecko/20100101 Firefox/24.0"
            RQuest.Proxy = Nothing
            RQuest.ContentLength = ByteData.Length
            Dim PostStream As Stream = RQuest.GetRequestStream()
            PostStream.Write(ByteData, 0, ByteData.Length)
            PostStream.Close()
            Dim Response As HttpWebResponse = RQuest.GetResponse
            Dim Sr As New StreamReader(Response.GetResponseStream)
            Dim Code As String = Sr.ReadToEnd
            Sr.Close()
            Return Code
        End Function
        Public Function CookieRequest(ByVal URL As String) As String
            Dim RQuest As HttpWebRequest = HttpWebRequest.Create(URL)
            RQuest.CookieContainer = PermCookie
            RQuest.KeepAlive = True
            RQuest.ContentType = "application/x-www-form-urlencoded"
            RQuest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:24.0) Gecko/20100101 Firefox/24.0"
            Dim Response As HttpWebResponse = RQuest.GetResponse
            Dim Sr As New StreamReader(Response.GetResponseStream)
            Dim Code As String = Sr.ReadToEnd
            Sr.Close()
            Return Code
        End Function
    End Class

    Class Parsing
        Public Shared Function GetBetween(ByVal sSearch As String, ByVal sStart As String, ByVal sStop As String, Optional ByVal lSearch As Integer = 1) As String
            Dim lTemp As Long

            lSearch = InStr(lSearch, sSearch, sStart)
            If lSearch > 0 Then
                lSearch = lSearch + Len(sStart)
                lTemp = InStr(lSearch, sSearch, sStop)
                If lTemp > lSearch Then Return Trim(Mid$(sSearch, lSearch, lTemp - lSearch))
            End If
            Return vbNullString
        End Function
    End Class
End Namespace
