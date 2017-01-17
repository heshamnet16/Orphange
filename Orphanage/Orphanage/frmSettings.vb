Imports <xmlns:a="urn:OrphanageXML:Templates">
Imports <xmlns:b="urn:OrphanageXML:FinancialTemplates">
Public Class FrmSettings

    Private Sub RadPageView1_SelectedPageChanging(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.RadPageViewCancelEventArgs) Handles RadPageView1.SelectedPageChanging
        'Next Page (Load When Load)
        If e.Page Is pgePublic Then
            'Page Public
            chkSaveGridState.Checked = My.Settings.SaveGridState
            chkSaveWindowState.Checked = My.Settings.SaveWindowsState
            chkShowHidden.Checked = My.Settings.ShowHiddenObject
            txtGeneralDate.Text = My.Settings.GeneralDateFormat
        ElseIf e.Page Is pgeOrphan Then
            'Page Orphan
            chkUseFullName.Checked = My.Settings.UseFullname
            numAllowedOrphanAge.Value = My.Settings.OrphanAllowedAge
            numMaxOrphanAge.Value = My.Settings.OrphanMaxAge
            chkBailsRemoveFamilyBail.Checked = My.Settings.CancelFamiliesBails
            chkBailsRemoveOrphansBail.Checked = My.Settings.BailsCancelOrphansBails
            chkBailsReplaceAll.Checked = My.Settings.BailsReplaceAll
        ElseIf e.Page Is pgeApperace Then
            'Page Apperance
            chkUseColors.Checked = My.Settings.UseColors
            txtAddressSeprator.Text = My.Settings.AddressSeprator
            chkUseSupporeterColor.Checked = My.Settings.UseSupporterColorForBails
            chkUseBackgroundColor.Checked = My.Settings.UseBackgroundColor
        ElseIf e.Page Is pgeCheck Then
            'Page Chckers
            chkCheckIDBeforADD.Checked = My.Settings.CheckIdentitysBeforAdd
            chkCheckIDBeforEdit.Checked = My.Settings.CheckIdentityBeforEdit
            chkCheckNamesBeforAdd.Checked = My.Settings.checkSmilarNameBeforAdd
            chkCheckNamesBeforEdit.Checked = My.Settings.CheckSmilaNameBeforEdit
            chkCheckFamCardBeforAdd.Checked = My.Settings.CheckFamilyCardBeforAdd
            chkCheckFamCardBeforEdit.Checked = My.Settings.checkFamilyCardBeforEdit
        ElseIf e.Page Is pgeAccounting Then
            'Page Accounting
            chkEditBoxAmount.Checked = My.Settings.CanEditBoxAcmount
            chkUseThousandSeprator.Checked = My.Settings.UseThousendSeprator
            chkMakeAbillForBailedFam.Checked = My.Settings.Make_A_Bill_for_every_Family
            chkMakeABillForBailedOrphan.Checked = My.Settings.Make_A_Bill_for_every_orphan
            numDecimalPercion.Value = My.Settings.DecimalPercion
            chkTowBillsForTrans.Checked = My.Settings.Make_A_Tow_Bills_For_One_Transaction
        ElseIf e.Page Is pgeExcel Then
            'page Excel
            txtExcelDateFormat.Text = My.Settings.ExcelDateFormat
        ElseIf e.Page Is pgeWord Then
            'Word Setting
            chkWordUseCom.Checked = My.Settings.ConvertToWordByCom
            chkWordMakeOneFile.Checked = My.Settings.WordMakeOneFile
            chkWordUseOrphanName.Checked = My.Settings.WordUseOrphanName
            chkWordExportDecuments.Checked = My.Settings.WordExportDocuments
            chkWordMakeFolder.Checked = My.Settings.WordMakeNewFolder
            If IO.File.Exists(FrmNewTemplate.xmlFileName) Then
                Dim xdoc As XDocument = XDocument.Load(FrmNewTemplate.xmlFileName)
                Dim q = From temp In xdoc.<a:Templates>.<a:Template> Select temp
                For Each tem In q
                    If Not cmbTemps.Items.Contains(tem.<a:Name>.Value) Then
                        cmbTemps.Items.Add(tem.<a:Name>.Value)
                    End If
                Next
            Else
                btnEditTemp.Enabled = False
                btnDeleteTemp.Enabled = False
            End If
            If My.Settings.WordSelectedTemplete.Length > 0 Then
                cmbTemps.Text = My.Settings.WordSelectedTemplete
            Else
                If cmbTemps.Items.Count > 0 Then
                    cmbTemps.Text = cmbTemps.Items(0).Text
                End If
            End If
            If IO.File.Exists(FrmFinancialTemplete.xmlFileName) Then
                Dim xdoc2 As XDocument = XDocument.Load(FrmFinancialTemplete.xmlFileName)
                Dim q2 = From temp2 In xdoc2.<b:Templates>.<b:Template> Select temp2
                For Each tem In q2
                    If Not cmbFTemps.Items.Contains(tem.<b:Name>.Value) Then
                        cmbFTemps.Items.Add(tem.<b:Name>.Value)
                    End If
                Next
            Else
                btnEditFTemp.Enabled = False
                btnDeleteFtemp.Enabled = False
                My.Settings.WordFinancialTemplete = "افتراضي"
            End If
            If My.Settings.WordFinancialTemplete.Length > 0 Then
                cmbFTemps.Text = My.Settings.WordFinancialTemplete
            Else
                cmbFTemps.Text = cmbFTemps.Items(0).Text
            End If
        End If
            'Current Page (Save when Leave)
        If RadPageView1.SelectedPage Is pgePublic Then
            My.Settings.ShowHiddenObject = chkShowHidden.Checked
            My.Settings.SaveGridState = chkSaveGridState.Checked
            My.Settings.SaveWindowsState = chkSaveWindowState.Checked
            If lblGeneralDateExam.ForeColor <> Color.Red Then
                My.Settings.GeneralDateFormat = txtGeneralDate.Text
            End If
            My.Settings.Save()
        ElseIf RadPageView1.SelectedPage Is pgeOrphan Then
            My.Settings.UseFullname = chkUseFullName.Checked
            My.Settings.OrphanAllowedAge = numAllowedOrphanAge.Value
            My.Settings.OrphanMaxAge = numMaxOrphanAge.Value
            My.Settings.CancelFamiliesBails = chkBailsRemoveFamilyBail.Checked
            My.Settings.BailsCancelOrphansBails = chkBailsRemoveOrphansBail.Checked
            My.Settings.BailsReplaceAll = chkBailsReplaceAll.Checked
            My.Settings.Save()
        ElseIf RadPageView1.SelectedPage Is pgeApperace Then
            My.Settings.UseColors = chkUseColors.Checked
            My.Settings.UseSupporterColorForBails = chkUseSupporeterColor.Checked
            My.Settings.AddressSeprator = txtAddressSeprator.Text
            My.Settings.UseBackgroundColor = chkUseBackgroundColor.Checked
            My.Settings.Save()
        ElseIf RadPageView1.SelectedPage Is pgeCheck Then
            'Page Chckers
            My.Settings.CheckIdentitysBeforAdd = chkCheckIDBeforADD.Checked
            My.Settings.CheckIdentityBeforEdit = chkCheckIDBeforEdit.Checked
            My.Settings.checkSmilarNameBeforAdd = chkCheckNamesBeforAdd.Checked
            My.Settings.CheckSmilaNameBeforEdit = chkCheckNamesBeforEdit.Checked
            My.Settings.CheckFamilyCardBeforAdd = chkCheckFamCardBeforAdd.Checked
            My.Settings.checkFamilyCardBeforEdit = chkCheckFamCardBeforEdit.Checked
            My.Settings.Save()
        ElseIf RadPageView1.SelectedPage Is pgeAccounting Then
            'Page Accounting
            My.Settings.CanEditBoxAcmount = chkEditBoxAmount.Checked
            My.Settings.UseThousendSeprator = chkUseThousandSeprator.Checked
            My.Settings.Make_A_Bill_for_every_Family = chkMakeAbillForBailedFam.Checked
            My.Settings.Make_A_Bill_for_every_orphan = chkMakeABillForBailedOrphan.Checked
            My.Settings.DecimalPercion = numDecimalPercion.Value
            My.Settings.Make_A_Tow_Bills_For_One_Transaction = chkTowBillsForTrans.Checked
            My.Settings.Save()
        ElseIf RadPageView1.SelectedPage Is pgeExcel Then
            'pge Excel
            If lblexcelDateExam.ForeColor <> Color.Red Then
                My.Settings.ExcelDateFormat = txtExcelDateFormat.Text
            End If
        ElseIf RadPageView1.SelectedPage Is pgeWord Then
            ' Page Word
            If cmbTemps.Text.Length > 0 Then
                FrmNewTemplate.MakeMeSelected(cmbTemps.Text)
                My.Settings.WordSelectedTemplete = cmbTemps.Text
            End If
            If cmbFTemps.Text.Length > 0 Then
                My.Settings.WordFinancialTemplete = cmbFTemps.Text
            End If
            My.Settings.ConvertToWordByCom = chkWordUseCom.Checked
            My.Settings.WordMakeOneFile = chkWordMakeOneFile.Checked
            My.Settings.WordUseOrphanName = chkWordUseOrphanName.Checked
            My.Settings.WordExportDocuments = chkWordExportDecuments.Checked
            My.Settings.WordMakeNewFolder = chkWordMakeFolder.Checked
            My.Settings.Save()
        End If
    End Sub

    Private Sub FrmSettings_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.ShowHiddenObject = chkShowHidden.Checked
        My.Settings.SaveGridState = chkSaveGridState.Checked
        My.Settings.SaveWindowsState = chkSaveWindowState.Checked
        My.Settings.UseFullname = chkUseFullName.Checked
        My.Settings.OrphanAllowedAge = numAllowedOrphanAge.Value
        My.Settings.OrphanMaxAge = numMaxOrphanAge.Value
        My.Settings.CancelFamiliesBails = chkBailsRemoveFamilyBail.Checked
        My.Settings.BailsCancelOrphansBails = chkBailsRemoveOrphansBail.Checked
        My.Settings.BailsReplaceAll = chkBailsReplaceAll.Checked
        My.Settings.UseColors = chkUseColors.Checked
        My.Settings.UseSupporterColorForBails = chkUseSupporeterColor.Checked
        My.Settings.UseBackgroundColor = chkUseBackgroundColor.Checked
        My.Settings.AddressSeprator = txtAddressSeprator.Text
        If lblGeneralDateExam.ForeColor <> Color.Red Then
            My.Settings.GeneralDateFormat = txtGeneralDate.Text
        End If
        'Page Chckers
        My.Settings.CheckIdentitysBeforAdd = chkCheckIDBeforADD.Checked
        My.Settings.CheckIdentityBeforEdit = chkCheckIDBeforEdit.Checked
        My.Settings.checkSmilarNameBeforAdd = chkCheckNamesBeforAdd.Checked
        My.Settings.CheckSmilaNameBeforEdit = chkCheckNamesBeforEdit.Checked
        My.Settings.CheckFamilyCardBeforAdd = chkCheckFamCardBeforAdd.Checked
        My.Settings.checkFamilyCardBeforEdit = chkCheckFamCardBeforEdit.Checked
        'Page Accounting
        My.Settings.CanEditBoxAcmount = chkEditBoxAmount.Checked
        My.Settings.UseThousendSeprator = chkUseThousandSeprator.Checked
        My.Settings.Make_A_Bill_for_every_Family = chkMakeAbillForBailedFam.Checked
        My.Settings.Make_A_Bill_for_every_orphan = chkMakeABillForBailedOrphan.Checked
        My.Settings.DecimalPercion = numDecimalPercion.Value
        My.Settings.Make_A_Tow_Bills_For_One_Transaction = chkTowBillsForTrans.Checked
        'page Excel
        If lblexcelDateExam.ForeColor <> Color.Red Then
            My.Settings.ExcelDateFormat = txtExcelDateFormat.Text
        End If
        'Page Word
        If cmbTemps.Text.Length > 0 Then
            FrmNewTemplate.MakeMeSelected(cmbTemps.Text)
            My.Settings.WordSelectedTemplete = cmbTemps.Text
        End If
        If cmbFTemps.Text.Length > 0 Then
            My.Settings.WordFinancialTemplete = cmbFTemps.Text
        End If
        My.Settings.ConvertToWordByCom = chkWordUseCom.Checked
        My.Settings.WordMakeOneFile = chkWordMakeOneFile.Checked
        My.Settings.WordUseOrphanName = chkWordUseOrphanName.Checked
        My.Settings.WordExportDocuments = chkWordExportDecuments.Checked
        My.Settings.WordMakeNewFolder = chkWordMakeFolder.Checked
        My.Settings.Save()
    End Sub

    Private Sub btnAddNewTemplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewTemplete.Click
        If frmLogin.CurrentUser.CanAdd Then
            Dim frm As New FrmNewTemplate()
            frm.MdiParent = Application.OpenForms("FrmMain")
            AddHandler frm.FormClosed, AddressOf FrmClosing
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        End If
    End Sub

    Private Sub btnEditTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditTemp.Click
        If frmLogin.CurrentUser.CanAdd Then
            Dim frm As New FrmNewTemplate(cmbTemps.Text)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        End If
    End Sub

    Private Sub btnAddNewFTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewFTemp.Click
        If frmLogin.CurrentUser.CanAdd Then
            Dim frm As New FrmFinancialTemplete()
            frm.MdiParent = Application.OpenForms("FrmMain")
            AddHandler frm.FormClosed, AddressOf FrmClosing
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        End If
    End Sub
    Private Sub FrmClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If IO.File.Exists(FrmNewTemplate.xmlFileName) Then
            Dim xdoc As XDocument = XDocument.Load(FrmNewTemplate.xmlFileName)
            Dim q = From temp In xdoc.<a:Templates>.<a:Template> Select temp
            For Each tem In q
                If Not cmbTemps.Items.Contains(tem.<a:Name>.Value) Then
                    cmbTemps.Items.Add(tem.<a:Name>.Value)
                End If
            Next
        Else
            btnEditTemp.Enabled = False
        End If
        If My.Settings.WordSelectedTemplete.Length > 0 Then
            cmbTemps.Text = My.Settings.WordSelectedTemplete
        Else
            cmbTemps.Text = cmbTemps.Items(0).Text
        End If
        If IO.File.Exists(FrmFinancialTemplete.xmlFileName) Then
            Dim xdoc2 As XDocument = XDocument.Load(FrmFinancialTemplete.xmlFileName)
            Dim q2 = From temp2 In xdoc2.<b:Templates>.<b:Template> Select temp2
            For Each tem In q2
                If Not cmbFTemps.Items.Contains(tem.<b:Name>.Value) Then
                    cmbFTemps.Items.Add(tem.<b:Name>.Value)
                End If
            Next
        Else
            btnEditFTemp.Enabled = False
            My.Settings.WordFinancialTemplete = "افتراضي"
        End If
        If My.Settings.WordFinancialTemplete.Length > 0 Then
            cmbFTemps.Text = My.Settings.WordFinancialTemplete
        Else
            cmbFTemps.Text = cmbFTemps.Items(0).Text
        End If
    End Sub

    Private Sub btnEditFTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditFTemp.Click
        If frmLogin.CurrentUser.CanAdd Then
            Dim frm As New FrmFinancialTemplete(cmbFTemps.Text)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        cmbTemps.Items.Add("نموذج يتيم1")
        cmbTemps.Items.Add("نموذج عطاء")
        cmbFTemps.Items.Add("افتراضي")
    End Sub

    Private Sub btnRest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRest.Click
        Dim Files = System.IO.Directory.GetFiles(CurDir())
        Try
            For Each file In Files

                If System.IO.Path.GetExtension(file).ToLower() = ".xaml" Then
                    If file.ToLower() <> FrmNewTemplate.xmlFileName.ToLower() Then
                        My.Computer.FileSystem.DeleteFile(file)
                    End If
                End If
            Next
            If System.IO.File.Exists("FormsLayouts.dat") Then
                My.Computer.FileSystem.DeleteFile("FormsLayouts.dat")
            End If
            ExceptionsManager.RaiseOnStatus(New MyException("تمت إعادة الضبط بنجاح"))
        Catch SecExc As Security.SecurityException
            MessageBox.Show("لاتمتلك الصلاحية الرجاء إعادة تشغيل البرنامج بصلاحية مدير", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch IOExc As IO.IOException
            MessageBox.Show(" لا يمكن إعادة الضبط الملف قيد الاستخدام", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtExcelDateFormat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExcelDateFormat.TextChanged
        Try
            Dim xx As New Date(1995, 10, 5, 22, 30, 30, 10)
            lblexcelDateExam.Text = xx.ToString(txtExcelDateFormat.Text)
            lblexcelDateExam.ForeColor = Color.Black
        Catch
            lblexcelDateExam.ForeColor = Color.Red
            lblexcelDateExam.Text = "صيغة خاطئة"
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click
        Process.Start("https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx")
        Process.Start("https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx")
    End Sub

    Private Sub txtGeneralDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGeneralDate.TextChanged
        Try
            Dim xx As New Date(1995, 10, 5, 22, 30, 30, 10)
            lblGeneralDateExam.Text = xx.ToString(txtGeneralDate.Text)
            lblGeneralDateExam.ForeColor = Color.Black
        Catch
            lblGeneralDateExam.ForeColor = Color.Red
            lblGeneralDateExam.Text = "صيغة خاطئة"
        End Try
    End Sub

    Private Sub FrmSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtGeneralDate.Text = My.Settings.GeneralDateFormat
        Me.txtExcelDateFormat.Text = My.Settings.GeneralDateFormat
    End Sub

    Private Sub btnDeleteTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteTemp.Click
        If frmLogin.CurrentUser.IsAdmin Then
            If Not cmbTemps.Text.Contains("نموذج يتيم1") AndAlso Not cmbTemps.Text.Contains("نموذج عطاء") Then
                If FrmNewTemplate.DeleteTemplete(cmbTemps.Text) Then
                    cmbTemps.Items.Remove(cmbTemps.SelectedItem)
                    ExceptionsManager.RaiseSaved()
                End If
            End If
        End If
    End Sub

    Private Sub btnDeleteTempF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteFtemp.Click
        If frmLogin.CurrentUser.IsAdmin Then
            If Not cmbFTemps.Text.Contains("افتراضي") Then
                If FrmFinancialTemplete.DeleteTemplete(cmbFTemps.Text) Then
                    cmbFTemps.Items.Remove(cmbFTemps.SelectedItem)
                    ExceptionsManager.RaiseSaved()
                End If
            End If
        End If
    End Sub

    Private Sub btnResetColor_Click(sender As System.Object, e As System.EventArgs) Handles btnResetColor.Click
        Dim ret = MessageBox.Show("هل انت متأكد من حذف جميع القيم اللونية لجميع السجلات(ايتام,عائلات,آباء,امهات,.....)", "", _
                                  MessageBoxButtons.YesNo, _
                                  MessageBoxIcon.Question Or MessageBoxIcon.Warning)
        If ret = Windows.Forms.DialogResult.Yes Then
            Dim sqlConn As New SqlClient.SqlConnection(My.Settings.OrphansDBConnectionString)
            sqlConn.Open()
            Dim SqlCommandStr As String = "Update orphans set Color_Mark=NULL"
            Dim sqlCommand As New SqlClient.SqlCommand(SqlCommandStr, sqlConn)
            Dim effected As Integer = sqlCommand.ExecuteNonQuery()
            ''''''''''''''''' Bondsman
            SqlCommandStr = "Update BondsMen set Color_Mark=NULL"
            sqlCommand = New SqlClient.SqlCommand(SqlCommandStr, sqlConn)
            effected = sqlCommand.ExecuteNonQuery()
            ''''''''''''''''' families
            SqlCommandStr = "Update Famlies set Color_Mark=NULL"
            sqlCommand = New SqlClient.SqlCommand(SqlCommandStr, sqlConn)
            effected = sqlCommand.ExecuteNonQuery()
            ''''''''''''''''' father
            SqlCommandStr = "Update Fathers set Color_Mark=NULL"
            sqlCommand = New SqlClient.SqlCommand(SqlCommandStr, sqlConn)
            effected = sqlCommand.ExecuteNonQuery()
            ''''''''''''''''' Mothters
            SqlCommandStr = "Update Mothers set Color_Mark=NULL"
            sqlCommand = New SqlClient.SqlCommand(SqlCommandStr, sqlConn)
            effected = sqlCommand.ExecuteNonQuery()
            ''''''''''''''''' Supporter
            SqlCommandStr = "Update Supporters set Color_Mark=NULL"
            sqlCommand = New SqlClient.SqlCommand(SqlCommandStr, sqlConn)
            effected = sqlCommand.ExecuteNonQuery()
            sqlConn.Close()
        End If
    End Sub
End Class
