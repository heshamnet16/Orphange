Imports Telerik.WinControls.UI

Public Class FrmBails
    'Dim Odb As New OrphanageDB.Odb()
    Private StrCount As String = ""
    Private ids() As Integer
    Public Function GetPrintedDocumnent() As Telerik.WinControls.UI.RadPrintDocument
        Return Me.RadPrintDocument1
    End Function
    Public Function GetGridView() As Telerik.WinControls.UI.RadGridView
        Return Me.radDataGrid
    End Function
    Public Sub PrintDocument(ByVal doc As RadPrintDocument)
        Me.radDataGrid.Print(True, doc)
    End Sub
    Public Sub SetGridFont(ByVal fon As Font)
        radDataGrid.Font = fon
        radDataGrid.PrintStyle.CellFont = fon
        radDataGrid.Refresh()
    End Sub
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _ids() As Integer)
        InitializeComponent()
        Me.ids = _ids
    End Sub
    Private Sub LoadData(Optional ByVal Ids() As Integer = Nothing)
        Try
            Using Odb As New OrphanageDB.Odb
                Odb.ObjectTrackingEnabled = False
                Dim i As Integer = 0
                Dim all As Integer = 0
                Dim PerValue = 0, LastPervalue As Integer = 0
                Dim q = From fath In Odb.Bails _
                        Select fath
                all = q.Count
                If radDataGrid.Rows.Count > 0 Then radDataGrid.Rows.Clear()
                For Each bal In q                    
                    PerValue = CInt(Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100)))
                    If Not IsNothing(Ids) AndAlso Ids.Count > 0 AndAlso Not Ids.Contains(bal.ID) Then
                        If i = all - 1 Then
                            If System.IO.File.Exists("Bails.Xaml") AndAlso My.Settings.SaveGridState Then
                                radDataGrid.LoadLayout("Bails.Xaml")
                            End If
                        End If
                        i += 1
                        If LastPervalue <> PerValue Then
                            ProgressSate.ShowStatueProgress(PerValue, "")
                            LastPervalue = PerValue
                        End If
                        Continue For
                    End If
                    Dim Supp_Id As Integer = CInt(bal.Supporter_ID)
                    Dim Box_ID As Integer = bal.Box_ID
                    Dim bal_ID As Integer = bal.ID
                    Dim qSupp = From sp In Odb.Supporters Join nm In Odb.Names On
                                nm.ID Equals sp.Name_ID
                                Where sp.ID = Supp_Id
                                Select sp, nm
                    Dim itm As New GridViewRowInfo(radDataGrid.MasterView)
                    itm.Cells("ID").Value = bal.ID
                    itm.Cells("Supporter").Value = Getter.GetFullName(qSupp.FirstOrDefault().nm)
                    itm.Cells("Amount").Value = bal.Amount
                    Dim Qbx = From bx In Odb.Boxes Where bx.ID = Box_ID Select bx
                    itm.Cells("Currency").Value = Qbx.FirstOrDefault().Currency_Name
                    Try
                        If bal.Start_Date.HasValue Then
                            itm.Cells("StartDate").Value = bal.Start_Date.Value.ToString(My.Settings.GeneralDateFormat)
                        Else
                            itm.Cells("StartDate").Value = "غير محدد"
                        End If
                        If bal.End_Date.HasValue Then
                            itm.Cells("EndDate").Value = bal.End_Date.Value.ToString(My.Settings.GeneralDateFormat)
                        Else
                            itm.Cells("EndDate").Value = "غير محدد"
                        End If
                    Catch
                    End Try
                    If bal.Is_Family Then
                        Dim QfamCount = From fams In Odb.Families Where
                                        fams.Baild_ID = bal_ID
                                        Select fams.ID Distinct
                        If Not IsNothing(QfamCount) AndAlso QfamCount.Count > 0 Then
                            itm.Cells("BailedNumber").Value = QfamCount.Count
                        Else
                            itm.Cells("BailedNumber").Value = 0
                        End If
                    Else
                        Dim QOrpCount = From fams In Odb.Orphans Where
                                            fams.Bail_ID = bal_ID
                                            Select fams.ID Distinct
                        If Not IsNothing(QOrpCount) AndAlso QOrpCount.Count > 0 Then
                            itm.Cells("BailedNumber").Value = QOrpCount.Count
                        Else
                            itm.Cells("BailedNumber").Value = 0
                        End If
                    End If
                    itm.Cells("IsMonthly").Value = bal.IsMonthly
                    itm.Cells("IsFamily").Value = bal.Is_Family
                    itm.Cells("IsEnded").Value = bal.Is_Ended
                    itm.Cells("RegDate").Value = bal.RegDate
                    Dim User_ID As Integer = bal.User_ID
                    Dim qUsr = From usre In Odb.Users Where usre.ID = User_ID Select usre.UserName
                    itm.Cells("UserName").Value = qUsr.FirstOrDefault()
                    radDataGrid.Rows.Add(itm)
                    'load Grid layout
                    If i = all - 1 Then
                        If System.IO.File.Exists("Bails.Xaml") AndAlso My.Settings.SaveGridState Then
                            radDataGrid.LoadLayout("Bails.Xaml")
                        End If
                    End If

                    i += 1
                    If LastPervalue <> PerValue Then
                        ProgressSate.ShowStatueProgress(PerValue, "")
                        LastPervalue = PerValue
                    End If
                Next
                If radDataGrid.RowCount > 0 Then
                    StrCount = "العدد الكلي " & radDataGrid.RowCount
                    lblStatus.Text = StrCount
                End If
                Odb.Dispose()
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try

    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If IsNothing(radDataGrid.SelectedRows()) OrElse radDataGrid.SelectedRows.Count = 0 Then Return
        Dim Row As Telerik.WinControls.UI.GridViewRowInfo = radDataGrid.SelectedRows(0)
        Dim frm As New FrmBail(CType(Row.Cells("ID").Value, Integer))
        frm.ShowDialog()
        frm.Dispose()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        If Not frmLogin.CurrentUser.CanDelete Then
            ExceptionsManager.RaiseAccessDeniedException()
            Return
        End If
        Try
            Dim retD As DialogResult = CType(MsgBox("هل تريد حذف كفالة/كفالات مع كل المتعلقات بهم؟", MsgBoxStyle.Question Or MsgBoxStyle.YesNo), Windows.Forms.DialogResult)
            If retD = vbYes Then
                Dim DeletedRows As New ArrayList()
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                    Dim delbail As OrphanageClasses.Bail = Getter.GetBailByID(CType(row.Cells("ID").Value, Integer))
                    If IsNothing(delbail) Then
                        DeletedRows.Add(row)
                        Continue For
                    End If
                    If Not Deleter.DeleteBail(delbail.ID) Then
                        ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج حذف القيد " & delbail.ID.ToString, True, True))
                        Exit Sub
                    End If
                    DeletedRows.Add(row)
                Next
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In DeletedRows
                    row.IsVisible = False
                    radDataGrid.Rows.Remove(row)
                Next
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub
    Private Sub MnuColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColumn.Click
        radDataGrid.ColumnChooser.Text = "الأعمدة"
        radDataGrid.ColumnChooser.ColumnChooserControl.ColumnChooserElement.Text = "اسحب الأعمدة من و إلى الشبكة"
        radDataGrid.ColumnChooser.Show()
    End Sub
    Private Sub radDataGrid_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.SelectionChanged
        If radDataGrid.SelectedRows.Count = 1 AndAlso Not IsNothing(radDataGrid.SelectedRows(0).Cells("ID").Value) Then
            Dim Bid As Integer = CType(radDataGrid.SelectedRows(0).Cells("ID").Value, Integer)
            Using Odb As New OrphanageDB.Odb
                Odb.ObjectTrackingEnabled = False
                Dim q = From bals In Odb.Bails Where bals.ID = Bid Select bals
                If IsNothing(q) OrElse IsNothing(q.FirstOrDefault()) Then Return
                Dim bal As OrphanageClasses.Bail = q.FirstOrDefault()
                Dim qO = From orrs In Odb.Orphans Where orrs.Bail_ID = Bid Select orrs.ID
                Dim qF = From orrs In Odb.Families Where orrs.Baild_ID = Bid Select orrs.ID
                If Not IsNothing(bal) Then
                    If bal.Is_Family Then
                        If Not IsNothing(qF) AndAlso qF.Count > 0 Then
                            btnShowFAmiles.Enabled = True
                        Else
                            btnShowFAmiles.Enabled = False
                        End If
                        btnShowOrphans.Enabled = False
                    Else
                        If Not IsNothing(qO) AndAlso qO.Count > 0 Then
                            btnShowOrphans.Enabled = True
                        Else
                            btnShowOrphans.Enabled = False
                        End If
                        btnShowFAmiles.Enabled = False
                    End If
                End If
                Odb.Dispose()
            End Using
        End If
        lblStatus.Text = StrCount & " المحدد " & radDataGrid.SelectedRows.Count
    End Sub

    Private Sub FrmFathers_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If My.Settings.SaveWindowsState Then
            Layouts.SaveFormLayout(Me)
        End If
        If My.Settings.SaveGridState Then
            radDataGrid.SaveLayout("Bails.Xaml")
        End If
    End Sub

#Region "UpdateRows"
    Private Sub DeletesBail(ByVal bx As Integer)
        If IsNothing(radDataGrid) OrElse IsNothing(radDataGrid.Rows) Then Exit Sub
        For Each row In radDataGrid.Rows
            Dim id As Integer = CInt(row.Cells("ID").Value)
            If id = bx Then
                row.IsVisible = False
                Exit For
            End If
            Application.DoEvents()
        Next
    End Sub
    Private Sub AddNewBail(ByVal bal As OrphanageClasses.Bail)
        If IsNothing(radDataGrid) OrElse IsNothing(radDataGrid.Rows) Then Exit Sub
        Dim xx = radDataGrid.Rows.AddNew()
        xx.Cells("ID").Value = bal.ID
        xx.Cells("Supporter").Value = Getter.GetFullName(bal.Supporter.Name)
        xx.Cells("Amount").Value = bal.Amount
        xx.Cells("Currency").Value = bal.Box.Currency_Name
        If bal.Start_Date.HasValue Then
            xx.Cells("StartDate").Value = bal.Start_Date.Value.ToString(My.Settings.GeneralDateFormat)
        Else
            xx.Cells("StartDate").Value = "غير محدد"
        End If
        If bal.End_Date.HasValue Then
            xx.Cells("EndDate").Value = bal.End_Date.Value.ToString(My.Settings.GeneralDateFormat)
        Else
            xx.Cells("EndDate").Value = "غير محدد"
        End If
        If bal.Is_Family Then
            If Not IsNothing(bal.Families) AndAlso bal.Families.Count > 0 Then
                xx.Cells("BailedNumber").Value = bal.Families.Count
            Else
                xx.Cells("BailedNumber").Value = 0
            End If
        Else
            If Not IsNothing(bal.Orphans) AndAlso bal.Orphans.Count > 0 Then
                xx.Cells("BailedNumber").Value = bal.Orphans.Count
            Else
                xx.Cells("BailedNumber").Value = 0
            End If
        End If
        xx.Cells("IsMonthly").Value = bal.IsMonthly
        xx.Cells("IsFamily").Value = bal.Is_Family
        xx.Cells("IsEnded").Value = bal.Is_Ended
        xx.Cells("RegDate").Value = bal.RegDate
        xx.Cells("UserName").Value = bal.User.UserName
    End Sub
    Private Sub UpdatesBail(ByVal bal As OrphanageClasses.Bail)
        If IsNothing(radDataGrid) OrElse IsNothing(radDataGrid.Rows) Then Exit Sub
        For Each xx In radDataGrid.Rows
            Dim id As Integer = CInt(xx.Cells("ID").Value)
            If id = bal.ID Then
                xx.Cells("Supporter").Value = Getter.GetFullName(bal.Supporter.Name)
                xx.Cells("Amount").Value = bal.Amount
                xx.Cells("Currency").Value = bal.Box.Currency_Name
                If bal.Start_Date.HasValue Then
                    xx.Cells("StartDate").Value = bal.Start_Date.Value.ToString(My.Settings.GeneralDateFormat)
                Else
                    xx.Cells("StartDate").Value = "غير محدد"
                End If
                If bal.End_Date.HasValue Then
                    xx.Cells("EndDate").Value = bal.End_Date.Value.ToString(My.Settings.GeneralDateFormat)
                Else
                    xx.Cells("EndDate").Value = "غير محدد"
                End If
                If bal.Is_Family Then
                    If Not IsNothing(bal.Families) AndAlso bal.Families.Count > 0 Then
                        xx.Cells("BailedNumber").Value = bal.Families.Count
                    Else
                        xx.Cells("BailedNumber").Value = 0
                    End If
                Else
                    If Not IsNothing(bal.Orphans) AndAlso bal.Orphans.Count > 0 Then
                        xx.Cells("BailedNumber").Value = bal.Orphans.Count
                    Else
                        xx.Cells("BailedNumber").Value = 0
                    End If
                End If
                xx.Cells("IsMonthly").Value = bal.IsMonthly
                xx.Cells("IsFamily").Value = bal.Is_Family
                xx.Cells("IsEnded").Value = bal.Is_Ended
                xx.Cells("RegDate").Value = bal.RegDate
                xx.Cells("UserName").Value = bal.User.UserName
                Exit For
            End If
            Application.DoEvents()
        Next
    End Sub
#End Region

    Private Sub FrmBails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Me.MdiParent) Then
            Me.MdiParent = Application.OpenForms("FrmMain")
        End If
        If Not IsNothing(ids) AndAlso ids.Length > 0 Then
            LoadData(ids)
        Else
            LoadData()
        End If
        If My.Settings.SaveWindowsState Then
            Layouts.LoadFormLayout(Me)
        End If
        AddHandler Updater.NewBail, AddressOf AddNewBail
        AddHandler Updater.UpdateBail, AddressOf UpdatesBail
        AddHandler Updater.DeleteBail, AddressOf DeletesBail
        If My.Settings.SaveGridState AndAlso System.IO.File.Exists("Bails.Xaml") Then
            radDataGrid.LoadLayout("Bails.Xaml")
        End If
        If My.Settings.SaveWindowsState Then
            Layouts.LoadFormLayout(Me)
        End If
        Dim col As GridViewDecimalColumn = CType(radDataGrid.Columns("Amount"), GridViewDecimalColumn)
        col.DecimalPlaces = My.Settings.DecimalPercion
        col.ThousandsSeparator = My.Settings.UseThousendSeprator
        col.FormatString = "{0:F" & My.Settings.DecimalPercion.ToString() & "}"
    End Sub

    Private Sub radDataGrid_CreateCell(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCreateCellEventArgs) Handles radDataGrid.CreateCell
        If e.CellType.FullName.Contains("FilterCellElement") Then
            Dim cell As New GridFilterCellElement(CType(e.Column, GridViewDataColumn), e.Row)
            cell.FilterButton.Enabled = False
            e.CellElement = cell
            e.CellType = cell.GetType()
        End If
        If e.CellType.FullName.Contains("FilterCheckBoxCellElement") Then
            Dim cell As New GridFilterCheckBoxCellElement(CType(e.Column, GridViewDataColumn), e.Row)
            cell.FilterButton.Enabled = False
            cell.FilterButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
            e.CellElement = cell
            e.CellType = cell.GetType()
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If frmLogin.CurrentUser.CanAdd Then
            Dim frm As New FrmBail()
            frm.MdiParent = Me.MdiParent
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub btnShowFAmiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowFAmiles.Click
        If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
            Dim bails As New ArrayList()
            For Each row In radDataGrid.SelectedRows
                Dim B_Id As Integer = CType(row.Cells("ID").Value, Integer)
                Dim Fams() As Integer = Getter.GetBailFamiles(B_Id)
                If Not IsNothing(Fams) AndAlso Fams.Count > 0 Then
                    bails.AddRange(Fams)
                End If
            Next
            WindowsLauncher.LaunchFamilies(CType(bails.ToArray(GetType(Integer)), Integer()))
        End If
    End Sub

    Private Sub btnShowOrphans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowOrphans.Click
        If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
            Dim IdsArray As New ArrayList()
            For Each row In radDataGrid.SelectedRows
                Dim B_Id As Integer = CType(row.Cells("ID").Value, Integer)
                Dim bal As OrphanageClasses.Bail = Getter.GetBailByID(B_Id)
                If Not IsNothing(bal) AndAlso Not IsNothing(bal.Orphans) AndAlso bal.Orphans.Count > 0 Then
                    For Each orp In bal.Orphans
                        If Not IdsArray.Contains(orp.ID) Then IdsArray.Add(orp.ID)
                    Next
                End If
            Next
            If IdsArray.Count > 0 Then
                Dim frm As New frmOrphans(CType(IdsArray.ToArray(GetType(Integer)), Integer()))
                frm.MdiParent = My.Application.OpenForms("FrmMain")
                frm.Show()
                WindowsLauncher.AllWindows.Add(frm)
            End If
        End If

    End Sub

    Private Sub btnDrawBail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrawBail.Click
        If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
            Dim B_Id As Integer = CType(radDataGrid.SelectedRows(0).Cells("ID").Value, Integer)
            Dim bal As OrphanageClasses.Bail = Getter.GetBailByID(B_Id)
            If Not IsNothing(bal) Then
                WindowsLauncher.LaunchNewBills(False, bal)
            End If
        End If
    End Sub
End Class
