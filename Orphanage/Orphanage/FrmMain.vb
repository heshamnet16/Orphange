Imports Telerik.WinControls.UI
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports System.Data.Sql

Public Class FrmMain

    'Dim WithEvents fFathers As FrmFathers = Nothing
    Dim PrintedDocumnet As RadPrintDocument = Nothing
    Dim angel As Integer = 90
    Dim LowColor As Color = Color.Black, HightColor As Color = Color.LightGreen
    Private Sub StartBackupService()
        Try
            Dim Pinfo As New ProcessStartInfo("NET")
            Pinfo.Arguments = "START"
            Pinfo.CreateNoWindow = True
            Pinfo.UseShellExecute = False
            Pinfo.RedirectStandardOutput = True
            Dim P As Process = Process.Start(Pinfo)
            Dim StrAll = P.StandardOutput.ReadToEnd()
            If StrAll.IndexOf("Orphans Auto Backup", StringComparison.OrdinalIgnoreCase) = -1 Then
                Pinfo = New ProcessStartInfo("install.exe")
                Pinfo.Arguments = "i"
                Pinfo.CreateNoWindow = False
                Pinfo.UseShellExecute = True
                Process.Start(Pinfo)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function HasSqlServer() As Boolean
        Try
            Dim Pinfo As New ProcessStartInfo("NET")
            Pinfo.Arguments = "START"
            Pinfo.CreateNoWindow = True
            Pinfo.UseShellExecute = False
            Pinfo.RedirectStandardOutput = True
            Dim P = Process.Start(Pinfo)
            If IsNothing(P) Then
                MessageBox.Show("برنامج إدارة قواعد البيانات غير مثبت", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
                Return False
            End If
            Dim StrAll = P.StandardOutput.ReadToEnd()
            If StrAll.IndexOf("sql server", StringComparison.OrdinalIgnoreCase) > -1 Then
                If Not (StrAll.IndexOf("SQLEXPRESS", StringComparison.OrdinalIgnoreCase) > -1) Then
                    MessageBox.Show("برنامج إدارة قواعد البيانات مثبت لكن السيرفر مطفئ أو اسمه غير صحيح يجب أن يكون الأسم" & Chr(13) & "SQLEXPRESS", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Application.Exit()
                    Return False
                End If
            Else
                MessageBox.Show("برنامج إدارة قواعد البيانات غير مثبت", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
                Return False
            End If
        Catch
            Return False
        End Try
        Return True
    End Function
    Private Sub mnuNewOrphan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewOrphan.Click
        If frmLogin.CurrentUser.CanAdd Then
            Dim frm As New FrmAddNewOrphanW()
            frm.MdiParent = Me
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Private Sub mnuShowSOrphans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowSOrphans.Click
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New frmOrphans(True)
            frm.MdiParent = My.Application.OpenForms("FrmMain")
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub


    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StartBackupService()
        If Not HasSqlServer() Then
            Application.Exit()
            Exit Sub
        End If
        Telerik.WinControls.ThemeResolutionService.ApplicationThemeName = My.Settings.Theme
        Me.DoubleBuffered = True
        For Each c As Control In Me.Controls
            If TypeOf c Is MdiClient Then
                Dim ctl As MdiClient = CType(c, MdiClient)
                AddHandler ctl.Paint, AddressOf DrawBackground
                AddHandler ctl.Click, AddressOf ClickBackground
            End If
        Next
        Dim frm As New frmLogin
        'frm.MdiParent = Me
        frm.StartPosition = FormStartPosition.CenterParent
        frm.ShowDialog()
        If Not IsNothing(frmLogin.CurrentUser) Then
            If Not frmLogin.CurrentUser.IsAdmin Then
                If frmLogin.CurrentUser.CanDeposit OrElse frmLogin.CurrentUser.CanDraw Then
                    radMnuAccounts.Visibility = Telerik.WinControls.ElementVisibility.Visible
                    mnuShowAccounts.Visibility = Telerik.WinControls.ElementVisibility.Visible
                Else
                    radMnuAccounts.Visibility = Telerik.WinControls.ElementVisibility.Hidden
                    mnuShowAccounts.Visibility = Telerik.WinControls.ElementVisibility.Hidden
                End If
                SepNewUserSep.Visibility = Telerik.WinControls.ElementVisibility.Hidden
                SepShowUser.Visibility = Telerik.WinControls.ElementVisibility.Hidden
                mnuNewUser.Visibility = Telerik.WinControls.ElementVisibility.Hidden
                mnuShowUsers.Visibility = Telerik.WinControls.ElementVisibility.Hidden
            Else
                radMnuAccounts.Visibility = Telerik.WinControls.ElementVisibility.Visible
                mnuShowAccounts.Visibility = Telerik.WinControls.ElementVisibility.Visible
                SepNewUserSep.Visibility = Telerik.WinControls.ElementVisibility.Visible
                SepShowUser.Visibility = Telerik.WinControls.ElementVisibility.Visible
                mnuNewUser.Visibility = Telerik.WinControls.ElementVisibility.Visible
                mnuShowUsers.Visibility = Telerik.WinControls.ElementVisibility.Visible
            End If
        End If
        AddHandler ExceptionsManager.showOnStatus, AddressOf ShowOnStatus
        'AddHandler ExceptionsManager.showOnDesktop, AddressOf ShowOnDesktop
        AddHandler ProgressSate.ShowProgress, AddressOf ShowProgress
        AddHandler COWTranslation.TranslateToExcel.Progress, AddressOf ShowProgress
        If My.Settings.AddressSeprator = " " OrElse My.Settings.AddressSeprator = "" Then
            My.Settings.AddressSeprator = CChar("-")
        End If
        frm.Dispose()
    End Sub
    Dim HFactor As Double = 1
    Private Sub ClickBackground(ByVal sender As Object, ByVal args As System.EventArgs)
        Dim ctl As MdiClient = CType(sender, MdiClient)
        For i As Double = 1 To 1.7 Step 0.29
            HFactor = i
            ctl.Refresh()
            'System.Threading.Thread.Sleep(10)
        Next
        For i As Double = HFactor To 1 Step -0.09
            HFactor = i
            ctl.Refresh()
            'System.Threading.Thread.Sleep(10)
        Next
        HFactor = 1
        ctl.Refresh()
    End Sub
    Private Sub DrawBackground(ByVal sender As Object, ByVal args As PaintEventArgs)
        Dim ctl As MdiClient = CType(sender, MdiClient)
        Dim mi As MethodInfo = GetType(MdiClient).GetMethod("SetStyle", BindingFlags.Instance Or BindingFlags.NonPublic)
        mi.Invoke(ctl, New Object() {ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True})
        Dim g As Graphics = args.Graphics
        Dim img As Bitmap = CType(My.Resources.Logo, Bitmap)
        Dim ImH As Integer = 150 * HFactor, ImW As Integer = 420 * HFactor
        Dim center As Point = New Point(CInt(((Me.Width) / 2) - (ImW / 2)), CInt(((Me.Height) / 2) - ImH))
        Dim col As Color = img.GetPixel(10, 10)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        img.MakeTransparent(Color.Red)
        'g.Clear(Color.Black)
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        Dim Lbrush As LinearGradientBrush = New LinearGradientBrush(New Rectangle(0, 0, Me.Width, Me.Height), HightColor, LowColor, angel, True)
        g.FillRectangle(Lbrush, New Rectangle(0, 0, Me.Width, Me.Height))
        g.DrawImage(img, New Rectangle(center, New Size(ImW, ImH)))
        angel += 5
        If angel >= 360 Then
            angel = 0
        End If
        If Date.Now.Hour >= 2 AndAlso Date.Now.Hour <= 3 Then
            LowColor = Color.Black
            HightColor = Color.White
        ElseIf Date.Now.Hour >= 4 AndAlso Date.Now.Hour <= 7 Then
            LowColor = Color.Black
            HightColor = Color.LightYellow
        ElseIf Date.Now.Hour >= 8 AndAlso Date.Now.Hour <= 11 Then
            LowColor = Color.GreenYellow
            HightColor = Color.LightYellow
        ElseIf Date.Now.Hour >= 12 AndAlso Date.Now.Hour <= 15 Then
            LowColor = Color.OrangeRed
            HightColor = Color.LightYellow
        ElseIf Date.Now.Hour >= 16 AndAlso Date.Now.Hour <= 17 Then
            LowColor = Color.RosyBrown
            HightColor = Color.DarkOrange
        ElseIf Date.Now.Hour >= 18 AndAlso Date.Now.Hour <= 19 Then
            LowColor = Color.Black
            HightColor = Color.Brown
        ElseIf Date.Now.Hour >= 20 AndAlso Date.Now.Hour <= 23 Then
            LowColor = Color.Black
            HightColor = Color.Black
        End If
        'g.Dispose()
        img.Dispose()
        GC.Collect()
        'ctl.Dispose()        
    End Sub

    Private Sub ShowOnStatus(ByVal exc As MyException)
        lblStatus.Text = exc.Message
        If exc.isImportantMessage AndAlso exc.IsError = False Then
            lblStatus.ForeColor = Color.Orange
            Beep()
        ElseIf exc.isImportantMessage = False AndAlso exc.IsError Then
            lblStatus.ForeColor = Color.Red
        ElseIf exc.IsError AndAlso exc.isImportantMessage Then
            lblStatus.ForeColor = Color.Red
            Beep()
        Else
            lblStatus.ForeColor = Color.Black
        End If
    End Sub

    Private Sub mnuNewFamily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewFamily.Click
        If frmLogin.CurrentUser.CanAdd Then
            Dim frm As New FrmAddNewWiard()
            frm.MdiParent = Me
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Private Sub mnuShowBonds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowBonds.Click
        WindowsLauncher.LaunchBondsMen()
    End Sub
    Private Sub mnuShowFathers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowFathers.Click
        WindowsLauncher.LaunchFathers()
    End Sub
    Public Sub ShowProgress(ByVal int As Integer, ByVal str As String)

        If RadProgressBarElement1.Visibility = Telerik.WinControls.ElementVisibility.Hidden Then
            RadProgressBarElement1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        End If
        If Me.LastProgValue <> int Then
            If int >= 0 AndAlso int <= 100 Then
                RadProgressBarElement1.Value1 = int
                Application.DoEvents()
            End If
            LastProgValue = int
        End If
        If int = 100 Then
            RadProgressBarElement1.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        End If
    End Sub

    Private Sub mnuShowMothers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowMothers.Click
        Dim x As New WindowsLauncher
        x.LaunchMothers()
    End Sub
    Dim LastProgValue As Integer = 0
    Dim ProgCounter As Integer = 0
    Dim LastStatues As String = ""
    Dim StatusCounter As Integer = 0
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If LastStatues <> lblStatus.Text Then
            LastStatues = lblStatus.Text
            StatusCounter = 0
        Else
            StatusCounter += 1
        End If
        If StatusCounter > 10 Then
            lblStatus.Text = ""
            lblStatus.ForeColor = Color.Black
        End If
        If RadProgressBarElement1.Value1 <> LastProgValue Then
            LastProgValue = RadProgressBarElement1.Value1
            ProgCounter = 0
        Else
            ProgCounter += 1
        End If
        If ProgCounter = 3 Then
            RadProgressBarElement1.Value1 = 0
            RadProgressBarElement1.Visibility = Telerik.WinControls.ElementVisibility.Hidden
            LastProgValue = 0
        End If
        'For Each ctl In Me.Controls
        '    If TypeOf ctl Is MdiClient Then
        '        CType(ctl, MdiClient).Refresh()
        '    End If
        'Next
        WindowsLauncher.ClearMemery()
    End Sub

    Private Sub btnSetFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetFont.Click
        Dim ActiveForm As Form = Me.ActiveMdiChild
        If Not IsNothing(ActiveForm) Then
            If TypeOf ActiveForm Is FrmTransforms Then
                Dim Fform As FrmTransforms = CType(ActiveForm, FrmTransforms)
                If FontDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Fform.SetGridFont(FontDialog1.Font)
                End If
                FontDialog1.Dispose()
            End If
            If TypeOf ActiveForm Is FrmFamiles Then
                Dim Fform As FrmFamiles = CType(ActiveForm, FrmFamiles)
                If FontDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Fform.SetGridFont(FontDialog1.Font)
                End If
                FontDialog1.Dispose()
            End If
            If TypeOf ActiveForm Is frmOrphans Then
                Dim Fform As frmOrphans = CType(ActiveForm, frmOrphans)
                If FontDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Fform.SetGridFont(FontDialog1.Font)
                End If
                FontDialog1.Dispose()
            End If
            If TypeOf ActiveForm Is FrmBills Then
                Dim Fform As FrmBills = CType(ActiveForm, FrmBills)
                If FontDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Fform.SetGridFont(FontDialog1.Font)
                End If
                FontDialog1.Dispose()
            End If
            If TypeOf ActiveForm Is FrmBoxes Then
                Dim Fform As FrmBoxes = CType(ActiveForm, FrmBoxes)
                If FontDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Fform.SetGridFont(FontDialog1.Font)
                End If
                FontDialog1.Dispose()
            End If
            If TypeOf ActiveForm Is FrmSupporters Then
                Dim Fform As FrmSupporters = CType(ActiveForm, FrmSupporters)
                If FontDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Fform.SetGridFont(FontDialog1.Font)
                End If
                FontDialog1.Dispose()
            End If
            If TypeOf ActiveForm Is FrmBondsMen Then
                Dim Fform As FrmBondsMen = CType(ActiveForm, FrmBondsMen)
                If FontDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Fform.SetGridFont(FontDialog1.Font)
                End If
                FontDialog1.Dispose()
            End If
            If TypeOf ActiveForm Is FrmFathers Then
                Dim Fform As FrmFathers = CType(ActiveForm, FrmFathers)
                If FontDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Fform.SetGridFont(FontDialog1.Font)
                End If
                FontDialog1.Dispose()
            End If
            If TypeOf ActiveForm Is FrmMothers Then
                Dim Fform As FrmMothers = CType(ActiveForm, FrmMothers)
                If FontDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Fform.SetGridFont(FontDialog1.Font)
                End If
                FontDialog1.Dispose()
            End If
            If TypeOf ActiveForm Is FrmFatherChooser Then
                Dim Fform As FrmFatherChooser = CType(ActiveForm, FrmFatherChooser)
                If FontDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Fform.SetGridFont(FontDialog1.Font)
                End If
                FontDialog1.Dispose()
            End If
            If TypeOf ActiveForm Is FrmMotherChooser Then
                Dim Fform As FrmMotherChooser = CType(ActiveForm, FrmMotherChooser)
                If FontDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Fform.SetGridFont(FontDialog1.Font)
                End If
                FontDialog1.Dispose()
            End If
        End If
    End Sub

    Private Sub FrmMain_MdiChildActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MdiChildActivate
        Dim ActiveForm As Form = Me.ActiveMdiChild
        If Not IsNothing(ActiveForm) Then
            If TypeOf ActiveForm Is FrmFamiles Then
                btnExportToFam.Enabled = True
            End If
            If TypeOf ActiveForm Is frmOrphans Then
                btnExportToFam.Enabled = True
            End If
            If Not IsNothing(GetDataGrid()) Then
                btnSetFont.Enabled = True
                btnTranslateToExcel.Enabled = True
                btnPrint.Enabled = True
                btnPrintPreview.Enabled = True
            Else
                btnSetFont.Enabled = False
                btnTranslateToExcel.Enabled = False
                btnPrint.Enabled = False
                btnPrintPreview.Enabled = False
            End If
            If Not IsNothing(GetWordDataGrid()) Then
                btnTrabslateToWord.Enabled = True
            Else
                btnTrabslateToWord.Enabled = False
            End If
        Else
            btnSetFont.Enabled = False
            btnTranslateToExcel.Enabled = False
            btnTrabslateToWord.Enabled = False
            btnPrint.Enabled = False
            btnPrintPreview.Enabled = False
            btnExportToFam.Enabled = False
        End If
    End Sub
    Private Sub ShowPrintPreview(ByVal them As String, ByRef prinDoc As RadPrintDocument)
        Dim dialog As New RadPrintPreviewDialog()
        dialog.ThemeName = them
        dialog.Document = prinDoc
        dialog.AllowTheming = True
        dialog.StartPosition = FormStartPosition.CenterScreen
        dialog.MdiParent = Me
        dialog.Show()
        WindowsLauncher.AllWindows.Add(dialog)
    End Sub
    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        Dim ActiveForm As Form = Me.ActiveMdiChild
        If Not IsNothing(ActiveForm) Then
            If TypeOf ActiveForm Is FrmFathers Then
                Dim Fform As FrmFathers = CType(ActiveForm, FrmFathers)
                PrintedDocumnet = Fform.GetPrintedDocumnent
                ShowPrintPreview(Fform.ThemeName, PrintedDocumnet)
            End If
            If TypeOf ActiveForm Is FrmMothers Then
                Dim Fform As FrmMothers = CType(ActiveForm, FrmMothers)
                PrintedDocumnet = Fform.GetPrintedDocumnent
                ShowPrintPreview(Fform.ThemeName, PrintedDocumnet)
            End If
            If TypeOf ActiveForm Is FrmFamiles Then
                Dim Fform As FrmFamiles = CType(ActiveForm, FrmFamiles)
                PrintedDocumnet = Fform.GetPrintedDocumnent
                ShowPrintPreview(Fform.ThemeName, PrintedDocumnet)
            End If
            If TypeOf ActiveForm Is frmOrphans Then
                Dim Fform As frmOrphans = CType(ActiveForm, frmOrphans)
                PrintedDocumnet = Fform.GetPrintedDocumnent
                ShowPrintPreview(Fform.ThemeName, PrintedDocumnet)
            End If
            If TypeOf ActiveForm Is FrmBondsMen Then
                Dim Fform As FrmBondsMen = CType(ActiveForm, FrmBondsMen)
                PrintedDocumnet = Fform.GetPrintedDocumnent
                ShowPrintPreview(Fform.ThemeName, PrintedDocumnet)
            End If
            If TypeOf ActiveForm Is FrmSupporters Then
                Dim Fform As FrmSupporters = CType(ActiveForm, FrmSupporters)
                PrintedDocumnet = Fform.GetPrintedDocumnent
                ShowPrintPreview(Fform.ThemeName, PrintedDocumnet)
            End If
            If TypeOf ActiveForm Is FrmBoxes Then
                Dim Fform As FrmBoxes = CType(ActiveForm, FrmBoxes)
                PrintedDocumnet = Fform.GetPrintedDocumnent
                ShowPrintPreview(Fform.ThemeName, PrintedDocumnet)
            End If
            If TypeOf ActiveForm Is FrmBills Then
                Dim Fform As FrmBills = CType(ActiveForm, FrmBills)
                PrintedDocumnet = Fform.GetPrintedDocumnent
                ShowPrintPreview(Fform.ThemeName, PrintedDocumnet)
            End If
            If TypeOf ActiveForm Is FrmTransforms Then
                Dim Fform As FrmTransforms = CType(ActiveForm, FrmTransforms)
                PrintedDocumnet = Fform.GetPrintedDocumnent
                ShowPrintPreview(Fform.ThemeName, PrintedDocumnet)
            End If
            If TypeOf ActiveForm Is FrmShowSalaries Then
                Dim Fform As FrmShowSalaries = CType(ActiveForm, FrmShowSalaries)
                PrintedDocumnet = Fform.GetPrintedDocumnent
                ShowPrintPreview(Fform.ThemeName, PrintedDocumnet)
            End If
            If TypeOf ActiveForm Is FrmFatherChooser Then
                Dim Fform As FrmFatherChooser = CType(ActiveForm, FrmFatherChooser)
            End If
            If TypeOf ActiveForm Is FrmMotherChooser Then
                Dim Fform As FrmMotherChooser = CType(ActiveForm, FrmMotherChooser)
            End If
        End If
    End Sub

    Private Function GetDataGrid() As RadGridView
        Dim ActiveForm As Form = Me.ActiveMdiChild
        If Not IsNothing(ActiveForm) Then
            If TypeOf ActiveForm Is FrmFathers Then
                Dim Fform As FrmFathers = CType(ActiveForm, FrmFathers)
                Return Fform.GetGridView
            End If
            If TypeOf ActiveForm Is FrmMothers Then
                Dim Fform As FrmMothers = CType(ActiveForm, FrmMothers)
                Return Fform.GetGridView
            End If
            If TypeOf ActiveForm Is FrmFamiles Then
                Dim Fform As FrmFamiles = CType(ActiveForm, FrmFamiles)
                Return Fform.GetGridView
            End If
            If TypeOf ActiveForm Is frmOrphans Then
                Dim Fform As frmOrphans = CType(ActiveForm, frmOrphans)
                Return Fform.GetGridView
            End If
            If TypeOf ActiveForm Is FrmBoxes Then
                Dim Fform As FrmBoxes = CType(ActiveForm, FrmBoxes)
                Return Fform.GetGridView
            End If
            If TypeOf ActiveForm Is FrmBills Then
                Dim Fform As FrmBills = CType(ActiveForm, FrmBills)
                Return Fform.GetGridView
            End If
            If TypeOf ActiveForm Is FrmTransforms Then
                Dim Fform As FrmTransforms = CType(ActiveForm, FrmTransforms)
                Return Fform.GetGridView
            End If
            If TypeOf ActiveForm Is FrmSupporters Then
                Dim Fform As FrmSupporters = CType(ActiveForm, FrmSupporters)
                Return Fform.GetGridView
            End If
            If TypeOf ActiveForm Is FrmShowSalaries Then
                Dim Fform As FrmShowSalaries = CType(ActiveForm, FrmShowSalaries)
                Return Fform.GetGridView
            End If
        End If
        Return Nothing
    End Function
    Private Function GetWordDataGrid() As RadGridView
        Dim ActiveForm As Form = Me.ActiveMdiChild
        If Not IsNothing(ActiveForm) Then
            If TypeOf ActiveForm Is frmOrphans Then
                Dim Fform As frmOrphans = CType(ActiveForm, frmOrphans)
                Return Fform.GetGridView
            End If
            If TypeOf ActiveForm Is FrmFamiles Then
                Dim fForm As FrmFamiles = CType(ActiveForm, FrmFamiles)
                Return fForm.GetGridView
            End If
        End If
        Return Nothing
    End Function

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        btnPrintPreview_Click(sender, e)
    End Sub
    Private Function ShowExcelSave() As String
        Dim SVD As New SaveFileDialog()
        SVD.AddExtension = True
        SVD.Filter = "Excel Files|*.xlsx"
        SVD.Title = "أختر مكان حفظ الملف"
        SVD.ShowHelp = False
        SVD.RestoreDirectory = True
        SVD.OverwritePrompt = True
        SVD.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        If SVD.ShowDialog(Application.OpenForms("FrmMain")) = Windows.Forms.DialogResult.OK Then
            Return SVD.FileName
        Else
            Return Nothing
        End If
    End Function
    Private Function ShowWordSave() As String
        Dim SVD As New SaveFileDialog()
        SVD.AddExtension = True
        SVD.Filter = "Word Files|*.Docx"
        SVD.Title = "أختر مكان حفظ الملف"
        SVD.ShowHelp = False
        SVD.RestoreDirectory = True
        SVD.OverwritePrompt = True
        SVD.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        If SVD.ShowDialog(Application.OpenForms("FrmMain")) = Windows.Forms.DialogResult.OK Then
            Return SVD.FileName
        Else
            Return Nothing
        End If
    End Function
    Private Sub btnSelectionToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTranslateToExcel.Click
        Dim grid As RadGridView = Me.GetDataGrid()
        If Not IsNothing(grid) Then
            Dim FileName As String = ShowExcelSave()
            If IsNothing(FileName) Then Return
            Dim dec As New Dictionary(Of String, String())
            If grid.SelectedRows.Count = 0 Then Exit Sub
            Dim ColCount As Integer = 0
            For Each col In grid.Columns
                If col.IsVisible AndAlso Not TypeOf col Is GridViewImageColumn Then
                    ColCount += 1
                End If
            Next
            Dim cellsData(ColCount - 1, grid.SelectedRows.Count + 1) As String
            Dim i = 0, j As Integer = 0
            For i = 0 To grid.Columns.Count - 1
                If grid.SelectedRows(0).Cells(i).ColumnInfo.IsVisible AndAlso Not TypeOf grid.SelectedRows(0).Cells(i).ColumnInfo Is GridViewImageColumn Then
                    If i - j + 65 <= Asc("Z") Then
                        cellsData(i - j, 0) = Chr(i - j + 65)
                    Else
                        If i - j + 39 <= Asc("Z") Then
                            cellsData(i - j, 0) = ("A") + Chr(i - j + 39)
                        Else
                            cellsData(i - j, 0) = ("B") + Chr(i - j + 13)
                        End If
                    End If
                    cellsData(i - j, 1) = grid.SelectedRows(0).Cells(i).ColumnInfo.HeaderText
                Else
                    j += 1
                End If
            Next
            i = 2
            j = 0
            For Each itm As GridViewRowInfo In grid.SelectedRows
                For Each cell As GridViewCellInfo In itm.Cells
                    If cell.ColumnInfo.IsVisible AndAlso Not TypeOf cell.ColumnInfo Is GridViewImageColumn Then
                        If IsNothing(cell.Value) Then
                            cellsData(j, i) = Nothing
                        Else
                            If TypeOf cell.Value Is Boolean Then
                                cellsData(j, i) = ATDFormater.ArabicBooleanFormatter.BooleanToArabic(CBool(cell.Value))
                            ElseIf TypeOf cell.Value Is Date Then
                                cellsData(j, i) = CType(cell.Value, Date).ToString(My.Settings.ExcelDateFormat)
                            Else
                                cellsData(j, i) = cell.Value.ToString
                            End If
                        End If
                        j += 1
                    End If
                Next
                j = 0
                i += 1
            Next
            For i = 0 To ColCount - 1
                Dim key As String = cellsData(i, 0)
                Dim data(grid.SelectedRows.Count) As String
                For j = 0 To grid.SelectedRows.Count
                    data(j) = cellsData(i, j + 1)
                Next
                dec.Add(key, data)
            Next
            COWTranslation.TranslateToExcel.SendStringsToExcel(FileName, dec)
        End If
    End Sub

    Private Sub mnuShowOrphans_ALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowOrhans_ALL.Click
        If frmLogin.CurrentUser.CanRead Then
            WindowsLauncher.LaunchOrphans()
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub mnuShowUnSOrphans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowUnSOrphans.Click
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New frmOrphans(False)
            frm.MdiParent = Me
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub mnuShowAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAccounts.Click
        If frmLogin.CurrentUser.CanRead AndAlso frmLogin.CurrentUser.CanDraw Then
            Dim frm As New FrmBoxes()
            frm.MdiParent = Me
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub mnuNewSupporter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewSupporter.Click
        If frmLogin.CurrentUser.CanAdd Then
            Dim frm As New FrmSupporter
            frm.MdiParent = Me
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub mnuShowSupporter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowSupporter.Click
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New FrmSupporters()
            frm.MdiParent = Me
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        End If
    End Sub



    Private Sub mnuNewAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewAccount.Click
        If frmLogin.CurrentUser.CanAdd AndAlso frmLogin.CurrentUser.CanDeposit Then
            Dim frm As New FrmBox()
            frm.MdiParent = Me
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub mnuDrawBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDrawBill.Click
        WindowsLauncher.LaunchNewBills(False)
    End Sub

    Private Sub mnuShowAllFamilies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAllFamilies.Click
        WindowsLauncher.LaunchFamilies()
    End Sub

    Private Sub mnuShowSFamilies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowSFamilies.Click
        WindowsLauncher.LaunchFamilies(True)
    End Sub

    Private Sub mnuShowUnSFamilies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowUnSFamilies.Click
        WindowsLauncher.LaunchFamilies(False)
    End Sub

    Private Sub mnuNewBail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewBail.Click
        WindowsLauncher.LaunchNewBail()
    End Sub

    Private Sub mnuShowBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowBills.Click
        WindowsLauncher.LaunchBills()
    End Sub

    Private Sub mnudepositBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnudepositBill.Click
        WindowsLauncher.LaunchNewBills(True)
    End Sub

    Private Sub RadMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowSetting.Click
        If frmLogin.CurrentUser.IsAdmin Then
            Dim frm As New FrmSettings()
            frm.MdiParent = Me
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        End If
    End Sub

    Private Sub btnTrabslateToWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrabslateToWord.Click
        Try
            Dim grid As RadGridView = Me.GetWordDataGrid()
            If IsNothing(grid) Then Exit Sub
            If grid.SelectedRows.Count = 0 Then Exit Sub
            Dim arr As New ArrayList()
            Dim isFamily As Boolean = False
            If grid.Columns.Contains("Family_ID") Then
                isFamily = True
            End If
            For Each row As Telerik.WinControls.UI.GridViewRowInfo In grid.SelectedRows
                Dim Id As Integer
                If isFamily Then
                    Id = CInt(Int(row.Cells("Family_ID").Value))
                Else
                    Id = CInt(Int(row.Cells("ID").Value))
                End If
                arr.Add(Id)
            Next
            Dim xp As New WordExporter()
            If Not isFamily Then
                xp.ConvertToWord(CType(arr.ToArray(GetType(Integer)), Integer()))
            Else
                xp.ConvertFamilyToWord(CType(arr.ToArray(GetType(Integer)), Integer()))
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub mnuBackupSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBackupSetting.Click
        If frmLogin.CurrentUser.IsAdmin Then
            Dim frm As New FrmBackupSetting()
            frm.MdiParent = Me
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        End If
    End Sub

    Private Sub mnuCreateSalaryTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCreateSalaryTable.Click
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            Dim frm As New FrmPaymentTEst()
            frm.MdiParent = Me
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        End If
    End Sub

    Private Sub mnuBackupNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBackupNow.Click
        Try
            Dim Svd As New SaveFileDialog()
            Svd.Filter = "نسخ احتياطي|*.odb"
            Svd.RestoreDirectory = True
            Svd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            Svd.CheckPathExists = True
            If Svd.ShowDialog = Windows.Forms.DialogResult.OK Then
                If File.Exists(Svd.FileName) Then
                    File.Delete(Svd.FileName)
                End If
                Dim Pinf As ProcessStartInfo = New ProcessStartInfo(CurDir() + "\MakeBackup.exe")
                If Svd.FileName.Contains(" ") Then
                    Pinf.Arguments = "OrphansDB " & """" & Svd.FileName & """" & " -B"
                Else
                    Pinf.Arguments = "OrphansDB " + Svd.FileName + " -B"
                End If
                Pinf.CreateNoWindow = False
                Pinf.UseShellExecute = True
                Process.Start(Pinf)
            End If
            Svd.Dispose()
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub mnuRestoreNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRestoreNow.Click
        Try
            Dim Svd As New OpenFileDialog()
            Svd.Filter = "نسخ احتياطي|*.odb"
            Svd.RestoreDirectory = True
            Svd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            Svd.CheckPathExists = True
            Svd.CheckFileExists = True
            If Svd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim Pinf As ProcessStartInfo = New ProcessStartInfo("NET")
                Pinf.Arguments = "STOP ""SQL Server (SQLEXPRESS)"""
                Process.Start(Pinf)
                ProgressSate.ShowStatueProgress(20, "")
                System.Threading.Thread.Sleep(10000)
                Pinf.Arguments = "START ""SQL Server (SQLEXPRESS)"""
                Process.Start(Pinf)
                ProgressSate.ShowStatueProgress(40, "")
                System.Threading.Thread.Sleep(10000)
                ProgressSate.ShowStatueProgress(60, "")
                Pinf = New ProcessStartInfo(CurDir() + "\MakeBackup.exe")
                If Svd.FileName.Contains(" ") Then
                    Pinf.Arguments = "OrphansDB " & """" & Svd.FileName & """" & " -R"
                Else
                    Pinf.Arguments = "OrphansDB " + Svd.FileName + " -R"
                End If
                Pinf.CreateNoWindow = False
                Pinf.UseShellExecute = True
                Process.Start(Pinf)
            End If
            Svd.Dispose()
            System.Threading.Thread.Sleep(10000)
            ProgressSate.ShowStatueProgress(100, "")
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub
#Region "Apperance"
    Private Sub mnuAppDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAppDefault.Click
        Telerik.WinControls.ThemeResolutionService.ApplicationThemeName = Nothing
        My.Settings.Theme = ""
        My.Settings.Save()
        For Each ctl As RadMenuItem In mnuApperance.Items
            ctl.IsChecked = False
        Next
        mnuAppDefault.IsChecked = True
    End Sub
    Private Sub mnuAppDesert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAppDesert.Click
        Telerik.WinControls.ThemeResolutionService.ApplicationThemeName = DesertTheme1.ThemeName
        My.Settings.Theme = DesertTheme1.ThemeName
        My.Settings.Save()
        For Each ctl As RadMenuItem In mnuApperance.Items
            ctl.IsChecked = False
        Next
        mnuAppDesert.IsChecked = True
    End Sub

    Private Sub mnuAppBreaze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAppBreaze.Click
        Telerik.WinControls.ThemeResolutionService.ApplicationThemeName = BreezeTheme1.ThemeName
        My.Settings.Theme = BreezeTheme1.ThemeName
        My.Settings.Save()
        For Each ctl As RadMenuItem In mnuApperance.Items
            ctl.IsChecked = False
        Next
        mnuAppBreaze.IsChecked = True
    End Sub

    Private Sub mnuAppAqua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAppAqua.Click
        Telerik.WinControls.ThemeResolutionService.ApplicationThemeName = AquaTheme1.ThemeName
        My.Settings.Theme = AquaTheme1.ThemeName
        My.Settings.Save()
        For Each ctl As RadMenuItem In mnuApperance.Items
            ctl.IsChecked = False
        Next
        mnuAppAqua.IsChecked = True
    End Sub

    Private Sub mnuAppHighCont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAppHighCont.Click
        Telerik.WinControls.ThemeResolutionService.ApplicationThemeName = HighContrastBlackTheme1.ThemeName
        My.Settings.Theme = HighContrastBlackTheme1.ThemeName
        My.Settings.Save()
        For Each ctl As RadMenuItem In mnuApperance.Items
            ctl.IsChecked = False
        Next
        mnuAppHighCont.IsChecked = True
    End Sub

    Private Sub mnuAppOffice2013_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAppOffice2013.Click
        Telerik.WinControls.ThemeResolutionService.ApplicationThemeName = Office2013LightTheme1.ThemeName
        My.Settings.Theme = Office2013LightTheme1.ThemeName
        My.Settings.Save()
        For Each ctl As RadMenuItem In mnuApperance.Items
            ctl.IsChecked = False
        Next
        mnuAppOffice2013.IsChecked = True
    End Sub

    Private Sub mnuAppMetro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAppMetro.Click
        Telerik.WinControls.ThemeResolutionService.ApplicationThemeName = TelerikMetroTouchTheme1.ThemeName
        My.Settings.Theme = TelerikMetroTouchTheme1.ThemeName
        My.Settings.Save()
        For Each ctl As RadMenuItem In mnuApperance.Items
            ctl.IsChecked = False
        Next
        mnuAppMetro.IsChecked = True
    End Sub

    Private Sub mnuAppWin7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAppWin7.Click
        Telerik.WinControls.ThemeResolutionService.ApplicationThemeName = Windows7Theme1.ThemeName
        My.Settings.Theme = Windows7Theme1.ThemeName
        My.Settings.Save()
        For Each ctl As RadMenuItem In mnuApperance.Items
            ctl.IsChecked = False
        Next
        mnuAppWin7.IsChecked = True
    End Sub

    Private Sub mnuAppWin8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAppWin8.Click
        Telerik.WinControls.ThemeResolutionService.ApplicationThemeName = Windows8Theme1.ThemeName
        My.Settings.Theme = Windows8Theme1.ThemeName
        My.Settings.Save()
        For Each ctl As RadMenuItem In mnuApperance.Items
            ctl.IsChecked = False
        Next
        mnuAppWin8.IsChecked = True
    End Sub

#End Region

    Private Sub mnuNewUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewUser.Click
        If frmLogin.CurrentUser.IsAdmin Then
            Dim frm As New frmUser()
            frm.MdiParent = Me
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub mnuShowUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowUsers.Click
        If frmLogin.CurrentUser.IsAdmin Then
            Dim frm As New FrmUsers()
            frm.MdiParent = Me
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub mnuShowDesOrph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowDesOrph.Click
        If frmLogin.CurrentUser.IsAdmin Then
            Dim showExcbool As Boolean = My.Settings.ShowHiddenObject
            Dim odb As New OrphanageDB.Odb()
            Dim q = From fams In odb.Orphans Where fams.IsExcluded = True Select fams
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Dim ors As New System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan)
                For Each fm In q
                    ors.Add(fm)
                Next
                My.Settings.ShowHiddenObject = True
                WindowsLauncher.LaunchOrphans(ors)
                My.Settings.ShowHiddenObject = showExcbool
            Else
                ExceptionsManager.RaiseOnStatus(New MyException("لا يوجد قيود مستبعدة", False, False))
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub mnuShowExceFams_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowExceFams.Click
        If frmLogin.CurrentUser.IsAdmin Then
            Dim odb As New OrphanageDB.Odb()
            Dim q = From fams In odb.Families Where fams.IsExcluded = True Select fams
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Dim Famis As New System.Data.Linq.EntitySet(Of OrphanageClasses.Family)
                For Each fm In q
                    Famis.Add(fm)
                Next
                Dim showExcbool As Boolean = My.Settings.ShowHiddenObject
                My.Settings.ShowHiddenObject = True
                WindowsLauncher.LaunchFamilies(Famis)
                My.Settings.ShowHiddenObject = showExcbool
            Else
                ExceptionsManager.RaiseOnStatus(New MyException("لا يوجد قيود مستبعدة", False, False))
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub mnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSearch.Click
        If frmLogin.CurrentUser.IsAdmin Then
            Dim frm As New FrmSearch()
            frm.MdiParent = Me
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub btnExportToFam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToFam.Click
        Try
            Dim progi As Double = 0
            Dim all As Double = 0
            If TypeOf ActiveMdiChild Is FrmFamiles Then
                Dim Fform As FrmFamiles = CType(ActiveMdiChild, FrmFamiles)
                Dim grd = GetDataGrid()
                If grd.SelectedRows.Count = 1 Then
                    Dim Svd As New SaveFileDialog()
                    Svd.Filter = "OrphansViewer Files|*.Fam"
                    If Svd.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
                    Dim xml As New DbXmlFileMaper(Svd.FileName, False)
                    For Each row In grd.SelectedRows
                        Dim idF As Integer = CInt(row.Cells("Family_ID").Value)
                        xml.CreateFamilyFile(idF)
                    Next
                Else
                    Dim Svd As New FolderBrowserDialog()
                    Svd.ShowNewFolderButton = True
                    If Svd.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
                    Dim xml As New DbXmlFileMaper(Svd.SelectedPath, False)
                    all = grd.SelectedRows.Count
                    For Each row In grd.SelectedRows
                        progi += 1
                        Dim idF As Integer = CInt(row.Cells("Family_ID").Value)
                        xml.CreateFamilyFile(idF, Svd.SelectedPath, True)
                        ProgressSate.ShowStatueProgress(CInt(CDbl((progi / all) * 100.0F)), "")
                    Next
                End If
            End If
            If TypeOf ActiveMdiChild Is frmOrphans Then
                Dim Fform As frmOrphans = CType(ActiveMdiChild, frmOrphans)
                Dim grd = GetDataGrid()
                If grd.SelectedRows.Count = 1 Then
                    Dim Svd As New SaveFileDialog()
                    Svd.Filter = "OrphansViewer Files|*.Fam"
                    If Svd.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
                    Dim xml As New DbXmlFileMaper(Svd.FileName, False)
                    For Each row In grd.SelectedRows
                        Dim idF As Integer = CInt(row.Cells("ID").Value)
                        xml.CreateOrphanFile(idF)
                    Next
                Else
                    Dim Svd As New FolderBrowserDialog()
                    Svd.ShowNewFolderButton = True
                    If Svd.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
                    Dim xml As New DbXmlFileMaper(Svd.SelectedPath, False)
                    all = grd.SelectedRows.Count
                    For Each row In grd.SelectedRows
                        progi += 1
                        Dim idF As Integer = CInt(row.Cells("ID").Value)
                        xml.CreateOrphanFile(idF, Svd.SelectedPath, True)
                        ProgressSate.ShowStatueProgress(CInt((progi / all) * 100.0F), "")
                    Next
                End If
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message))
        End Try
    End Sub

    Private Sub btnImportFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportFiles.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim progi As Double = 0
            Dim all As Double = 0
            Dim Svd As New OpenFileDialog()
            Svd.Filter = "OrphansViewer Files|*.Fam"
            Svd.CheckFileExists = True
            Svd.CheckPathExists = True
            Svd.RestoreDirectory = True
            Svd.Multiselect = True
            If Svd.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            Dim arr As New ArrayList()
            all = Svd.FileNames.Count
            For Each fl In Svd.FileNames
                Try
                    Dim xmlM As New DbXmlFileMaper()
                    Dim xmlR As FileCreation.XmlBuilder = xmlM.GetFamilyFile(fl)
                    If IsNothing(xmlR) Then
                        Dim inf As New FrmImportResult.ImportInfo(fl, "", "", "فشل")
                        arr.Add(inf)
                    Else
                        Dim FatherN As String = xmlR.Fath_FirstName + " " + xmlR.Fath_LastName
                        Dim MotherN As String = xmlR.Moth_FirstName + " " + xmlR.Moth_LastName
                        If xmlM.AddFamily(xmlR) Then
                            Dim inf As New FrmImportResult.ImportInfo(fl, FatherN, MotherN, "اضيفت بنجاح")
                            arr.Add(inf)
                        Else
                            Dim inf As New FrmImportResult.ImportInfo(fl, FatherN, MotherN, "فشل")
                            arr.Add(inf)
                        End If
                    End If
                Catch
                    Dim inf As New FrmImportResult.ImportInfo(fl, "", "", "فشل")
                    arr.Add(inf)
                End Try
                progi += 1
                ProgressSate.ShowStatueProgress(CInt((progi / all) * 100.0F), "")
            Next
            Dim xret() As FrmImportResult.ImportInfo
            xret = CType(arr.ToArray(GetType(FrmImportResult.ImportInfo)), FrmImportResult.ImportInfo())
            Dim frmI As New FrmImportResult(xret)
            frmI.MdiParent = Me
            frmI.Show()
            WindowsLauncher.AllWindows.Add(frmI)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message))
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub mnuCorrections_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCorrections.Click
        If frmLogin.CurrentUser.IsAdmin Then
            Dim frm As New FrmFindAndCorrect
            frm.MdiParent = Me
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
End Class
