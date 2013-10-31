Imports System.Text

Module tester

    Sub Main()
        Dim wrapper As New EasyPasteWrapper.Functions

        wrapper.CreatePaste("USERNAME", "TITLE", "CONTENTS", False, EasyPasteWrapper.Functions.HighlightCodes.None)

        Dim author As String = wrapper.GetPasteAuthor("PASTEID")
        Dim title As String = wrapper.GetPasteTitle("PASTEID")
        Dim pasteContent As String = wrapper.GetPasteContent("PASTEID")
        Dim views As Integer = wrapper.GetPasteViews("PASTEID")
        Dim pasteDate As String = wrapper.GetPasteDate("PASTEID")

        Dim totalPastes As Integer = wrapper.GetTotalPastes()

        Dim pasteList As List(Of String) = wrapper.GetPasteRange(0, 4)

        Console.ReadLine()
    End Sub

End Module
