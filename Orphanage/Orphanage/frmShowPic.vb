Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Public Class FrmShowPic
    Private _img As Image = Nothing
    Private _name As String = Nothing
    Dim hic As IntPtr = Nothing
    Dim FileN As String = Nothing

    <System.Runtime.InteropServices.DllImportAttribute("user32.dll")> _
    Private Shared Function DestroyIcon(ByVal handle As IntPtr) As Boolean
    End Function

    Public Sub New(ByVal img As Image, ByVal name As String)
        InitializeComponent()
        Me._img = img
        hic = CType(img, Bitmap).GetHicon()
        Me.Icon = Icon.FromHandle(hic)
        Me.BackgroundImage = _img
        Me.Text = "صورة " & _name
    End Sub
    Public Sub New(ByVal img As Image)
        InitializeComponent()
        Me._img = img
        hic = CType(img, Bitmap).GetHicon()
        Dim NewIcon As Icon = Icon.FromHandle(hic)
        Me.Icon = NewIcon
        Me.BackgroundImage = _img
        Me.Text = "صورة "
    End Sub

    Private Sub FrmShowPic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Me.BackgroundImage = _img
    End Sub

    Private Sub FrmShowPic_CursorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Not IsNothing(hic) Then
            DestroyIcon(hic)
        End If
    End Sub

    Private Sub mnuSavePic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSavePic.Click
        Try
            Dim dia As New SaveFileDialog()
            dia.Title = "حفظ صورة"
            dia.Filter = "Jpeg|*.jpg"
            dia.AddExtension = True
            dia.RestoreDirectory = True
            If dia.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If System.IO.File.Exists(dia.FileName) Then
                    System.IO.File.Delete(dia.FileName)
                End If
                Dim btmap As New Bitmap(Me.BackgroundImage)
                btmap.Save(dia.FileName, ImageFormat.Jpeg)
            End If
            dia.Dispose()
        Catch ex As Exception            
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, False))
        End Try
    End Sub

    Private Sub mnuPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPreview.Click
        Try
            FileN = My.Computer.FileSystem.GetTempFileName()
            If System.IO.File.Exists(FileN) Then
                System.IO.File.Delete(FileN)
            End If
            FileN = FileN.Substring(0, FileN.Length - 3) & "jpg"            
            Dim btmap As New Bitmap(Me.BackgroundImage)
            btmap.Save(FileN, ImageFormat.Jpeg)
            Process.Start(FileN)
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, False))
        End Try
    End Sub

    Private Sub FrmShowPic_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Not IsNothing(FileN) AndAlso FileN.Length > 2 Then
                For Each proc In Process.GetProcesses()
                    If Not proc.HasExited AndAlso proc.MainWindowTitle.Contains(System.IO.Path.GetFileNameWithoutExtension(FileN)) Then
                        proc.Kill()
                        Exit For
                    End If
                Next
                System.IO.File.Delete(FileN)
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, False))
        End Try
    End Sub
End Class
