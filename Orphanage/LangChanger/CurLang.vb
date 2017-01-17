Imports System
Imports System.Windows.Forms
Public Class CurLang
    Private Shared curL As InputLanguage = InputLanguage.CurrentInputLanguage
    Public Shared Sub ChangeToArabic()
        If InputLanguage.CurrentInputLanguage.Culture.EnglishName.ToLower().IndexOf("arabic") = -1 Then
            For Each lang As InputLanguage In InputLanguage.InstalledInputLanguages
                If lang.Culture.EnglishName.ToLower().IndexOf("arabic") <> -1 Then
                    InputLanguage.CurrentInputLanguage = lang
                    Exit For
                End If
            Next 
        End If
    End Sub
    Public Shared Sub ChangeToEnglish()
        If InputLanguage.CurrentInputLanguage.Culture.EnglishName.ToLower().IndexOf("english") = -1 Then
            For Each lang As InputLanguage In InputLanguage.InstalledInputLanguages
                If lang.Culture.EnglishName.ToLower().IndexOf("english") <> -1 Then
                    InputLanguage.CurrentInputLanguage = lang
                    Exit For
                End If
            Next
        End If
    End Sub
    Public Shared Sub ReturnToSavedLanguage()
        InputLanguage.CurrentInputLanguage = curL
    End Sub
    Public Shared Sub SaveCurrentLanguage()
        curL = InputLanguage.CurrentInputLanguage
    End Sub
End Class
