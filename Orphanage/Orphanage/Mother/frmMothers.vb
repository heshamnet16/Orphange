Imports Itenso.TimePeriod
Imports ATDFormater
Imports System.IO
Imports Telerik.WinControls.UI
Imports System.ComponentModel

Public Class FrmMothers

    'Dim Odb As New OrphanageDB.Odb()
    Private StrCount As String = ""
    Private ids() As Integer
    Dim IsLoading As Boolean = True
    Dim IDSColors As New Dictionary(Of Integer, Color)
#Region "UpdateRows"
    Private Sub DeletesMother(ByVal bx As Integer)
        radDataGrid.TableElement.BeginUpdate()
        For Each row In radDataGrid.Rows
            Dim id As Integer = CInt(row.Cells("ID").Value)
            If id = bx Then
                row.IsVisible = False
                Exit For
            End If
            Application.DoEvents()
        Next
        radDataGrid.TableElement.EndUpdate()
    End Sub
    'GridViewDecimalColumn1.Name = "ID"
    'GridViewTextBoxColumn1.Name = "MotherName"
    'GridViewTextBoxColumn2.Name = "FatherName"
    'GridViewDecimalColumn2.Name = "Onum"
    'GridViewDateTimeColumn1.Name = "Birthday"
    'GridViewCheckBoxColumn1.Name = "IsDead"
    'GridViewDateTimeColumn2.Name = "Dieday"
    'GridViewDecimalColumn3.Name = "IdentityCard_ID"
    'GridViewCheckBoxColumn2.Name = "IsMarried"
    'GridViewCheckBoxColumn3.Name = "IsOwnOrphans"
    'GridViewTextBoxColumn3.Name = "Jop"
    'GridViewDecimalColumn4.Name = "Salary"
    'GridViewDateTimeColumn3.Name = "RegDate"
    Private Sub AddNewMother(ByVal bx As OrphanageClasses.Mother)
        Dim xx As GridViewRowInfo
        Try
            xx = radDataGrid.Rows.AddNew()
        Catch ex As Exception
            Return
        End Try
        Try
            Using odb As New OrphanageDB.Odb
                odb.ObjectTrackingEnabled = False
                Dim FatherSName As String = ""
                Dim qMoth = From mt In odb.Mothers Where mt.ID = bx.ID Select mt, mt.Name, mt.Address
                If IsNothing(qMoth) OrElse qMoth.Count <= 0 OrElse IsNothing(qMoth.FirstOrDefault()) Then
                    Return
                End If
                xx.Cells("ID").Value = bx.ID
                xx.Cells("MotherName").Value = Getter.GetFullName(qMoth.FirstOrDefault.Name)
                xx.Cells("Birthday").Value = bx.Birthday
                If bx.Dieday.HasValue Then
                    xx.Cells("Dieday").Value = bx.Dieday.Value
                Else
                    xx.Cells("Dieday").Value = Nothing
                End If
                Dim q = From fam In odb.Families Join mo In odb.Mothers On fam.Mother_ID Equals mo.ID
                        Join fat In odb.Fathers On fat.ID Equals fam.Father_ID _
                        Where mo.ID = bx.ID
                        Select fat.Name, fam.ID
                Dim OrphansCount As Integer = Getter.GetMotherOrphansNum(bx.ID)
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    For Each fN In q
                        Dim FamId As Integer = fN.ID
                        If FatherSName.Length > 0 Then
                            FatherSName &= " - " & Getter.GetFullName(fN.Name)
                        Else
                            FatherSName = Getter.GetFullName(fN.Name)
                        End If
                    Next
                Else
                    FatherSName = "لا يوجد"
                End If
                xx.Cells("FatherName").Value = FatherSName
                xx.Cells("Onum").Value = OrphansCount
                xx.Cells("IsDead").Value = bx.IsDead
                xx.Cells("IsMarried").Value = bx.IsMarried
                xx.Cells("IsOwnOrphans").Value = bx.IsOwnOrphans
                xx.Cells("Jop").Value = bx.Jop
                If bx.IdntityCard_ID.HasValue Then
                    xx.Cells("IdentityCard_ID").Value = bx.IdntityCard_ID.Value
                End If
                If bx.Salary.HasValue Then
                    xx.Cells("Salary").Value = bx.Salary.Value
                End If
                xx.Cells("Address").Value = Getter.GetAddress(qMoth.FirstOrDefault.Address)
                xx.Cells("RegDate").Value = bx.RegDate
                If My.Settings.UseColors Then
                    Dim ColorM As Long = -102
                    If bx.Color_Mark.HasValue Then
                        ColorM = bx.Color_Mark.Value
                    End If
                    If ColorM <> -102 Then
                        For Each cel As GridViewCellInfo In xx.Cells
                            cel.Style.CustomizeFill = True
                            cel.Style.DrawFill = True
                            cel.Style.ForeColor = Color.FromArgb(ColorM)
                            cel.Style.BackColor = Nothing
                        Next
                    End If
                End If
                odb.Dispose()
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Private Sub UpdatesMother(ByVal bx As OrphanageClasses.Mother)

        Dim ret = radDataGrid.Rows.Where(Function(x) CInt(x.Cells("ID").Value) = bx.ID).FirstOrDefault()

        If Not IsNothing(ret) Then
            Dim xx As GridViewRowInfo = ret
            Dim id1 As Integer = CInt(xx.Cells("ID").Value)
            If id1 = bx.ID Then
                Try
                    Dim FatherSName As String = ""
                    xx.Cells("ID").Value = bx.ID
                    xx.Cells("MotherName").Value = Getter.GetFullName(bx.Name)
                    xx.Cells("Birthday").Value = bx.Birthday
                    If Not IsNothing(bx.Dieday) Then
                        xx.Cells("Dieday").Value = bx.Dieday
                    Else
                        xx.Cells("Dieday").Value = Nothing
                    End If
                    Using Odb As New OrphanageDB.Odb
                        Dim q = From fam In Odb.Families Join mo In Odb.Mothers On fam.Mother_ID Equals mo.ID Join fat In Odb.Fathers On fat.ID Equals fam.Father_ID _
                                Where mo.ID = bx.ID
                                Select fat.Name, fam.ID

                        Dim OrphansCount As Integer = 0
                        If Not IsNothing(q) AndAlso q.Count > 0 Then
                            For Each fN In q
                                Dim famId As Integer = fN.ID
                                Dim q1 = From fam1 In Odb.Orphans Where fam1.Family_ID = famId Group By fam1.ID Into Count()
                                If FatherSName.Length > 0 Then
                                    FatherSName &= " - " & Getter.GetFullName(fN.Name)
                                Else
                                    FatherSName = Getter.GetFullName(fN.Name)
                                End If
                                If Not IsNothing(q1) AndAlso q1.Count > 0 Then
                                    OrphansCount += q1.First.Count
                                End If
                            Next
                        Else
                            FatherSName = "لا يوجد"
                        End If
                        xx.Cells("FatherName").Value = FatherSName
                        xx.Cells("Onum").Value = OrphansCount
                        xx.Cells("IsDead").Value = bx.IsDead
                        xx.Cells("IsMarried").Value = bx.IsMarried
                        xx.Cells("IsOwnOrphans").Value = bx.IsOwnOrphans
                        xx.Cells("Jop").Value = bx.Jop
                        xx.Cells("IdentityCard_ID").Value = bx.IdntityCard_ID
                        xx.Cells("Salary").Value = bx.Salary
                        xx.Cells("RegDate").Value = bx.RegDate
                        If bx.Color_Mark.HasValue Then
                            xx.Cells("Color_Mark").Value = bx.Color_Mark.Value
                        Else
                            xx.Cells("Color_Mark").Value = Nothing
                        End If
                        If IDSColors.ContainsKey(bx.ID) Then IDSColors.Remove(bx.ID)
                        Odb.Dispose()
                    End Using
                Catch
                End Try
            End If
            Application.DoEvents()
        End If
    End Sub
#End Region
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
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _ids() As Integer)
        InitializeComponent()
        Me.ids = _ids
    End Sub
    
    Private Sub LoadData(Optional ByVal Ids() As Integer = Nothing)
        If IsNothing(Ids) OrElse Ids.Count <= 0 Then
            Return
        End If

        If My.Settings.ShowHiddenObject Then
            Me.MothersTableAdapter.Fill(Me.OrphansDBDataSet.Mothers)
        Else
            Me.MothersTableAdapter.FillByUnExcluded(Me.OrphansDBDataSet.Mothers)
        End If
        Dim ttt = Me.OrphansDBDataSet.Mothers.Where(Function(x) Ids.Contains(x.ID))
        Me.radDataGrid.DataSource = ttt.AsDataView()

        'Dim i As Integer = 0
        'Dim all As Integer = 0
        'Dim PerValue = 0, LastPerValue As Integer = 0
        'all = Ids.Count
        'If radDataGrid.Rows.Count > 0 Then radDataGrid.Rows.Clear()
        'For Each moth_id In Ids
        '    Using Odb As New OrphanageDB.Odb
        '        Dim moth As OrphanageClasses.Mother = Getter.GetMotherByID(moth_id, Odb)
        '        If IsNothing(moth) Then
        '            i += 1
        '            Odb.Dispose()
        '            Continue For
        '        Else
        '            AddNewMother(moth)
        '        End If
        '        PerValue = Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100))
        '        i += 1
        '        If LastPerValue <> PerValue Then
        '            ProgressSate.ShowStatueProgress(PerValue, "")
        '            LastPerValue = PerValue
        '        End If
        '        Odb.Dispose()
        '    End Using
        'Next
        ProgressSate.ShowStatueProgress(100, "")
        If radDataGrid.RowCount > 0 Then
            StrCount = "العدد الكلي " & radDataGrid.RowCount
            lblStatus.Text = StrCount
        End If
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
            Dim Row As Telerik.WinControls.UI.GridViewDataRowInfo = CType(radDataGrid.SelectedRows(0), GridViewDataRowInfo)
            Dim frm As New FrmMother(CType(Row.Cells("ID").Value, Integer))
            frm.ShowDialog()
            If frm.DialogResult = DialogResult.OK Then
                Using Odb As New OrphanageDB.Odb
                    Dim mot As OrphanageClasses.Mother = Nothing
                    mot = Getter.GetMotherByID(CInt(Row.Cells("ID").Value), Odb)
                    If Not IsNothing(mot) Then
                        Me.UpdatesMother(mot)
                    End If
                End Using
            End If
            frm.Dispose()
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        If Not frmLogin.CurrentUser.CanDelete Then
            ExceptionsManager.RaiseAccessDeniedException()
            Return
        End If

        Try
            Dim retD As DialogResult = MsgBox("هل تريد حذف أم/أمهات مع كل المتعلقات بهم؟", MsgBoxStyle.Question Or MsgBoxStyle.YesNo)
            If retD = vbYes Then
                Dim DeletedRows As New ArrayList()
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                    Using Odb As New OrphanageDB.Odb
                        Dim fath As OrphanageClasses.Mother = Getter.GetMotherByID(CType(row.Cells("ID").Value, Integer), Odb)
                        If IsNothing(fath) Then
                            DeletedRows.Add(row)
                            Continue For
                        End If
                        Dim Fams() As OrphanageClasses.Family = fath.Families.ToArray()
                        For Each fam As OrphanageClasses.Family In Fams
                            If Not Deleter.DeleteFamilies(fam.ID) Then
                                ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج حذف القيد " & Getter.GetFullName(fath.Name), True, True))
                                Exit Sub
                            End If
                        Next
                        DeletedRows.Add(row)
                        Odb.Dispose()
                    End Using
                Next
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In DeletedRows
                    row.IsVisible = False
                    radDataGrid.Rows.Remove(row)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub MnuColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColumn.Click
        radDataGrid.ColumnChooser.Text = "الأعمدة"
        radDataGrid.ColumnChooser.ColumnChooserControl.ColumnChooserElement.Text = "اسحب الأعمدة من و إلى الشبكة"
        radDataGrid.ColumnChooser.Show()
    End Sub

    Private Sub radDataGrid_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.SelectionChanged
        If Me.IsLoading Then Return
        If radDataGrid.SelectedRows.Count > 0 AndAlso Not IsNothing(radDataGrid.SelectedRows(0).Cells("ID").Value) Then
            Using Odb As New OrphanageDB.Odb
                Odb.ObjectTrackingEnabled = False
                Dim Fid As Integer = CType(radDataGrid.SelectedRows(0).Cells("ID").Value, Integer)
                Dim OrphansCount As Integer = Getter.GetMotherOrphansNum(Fid)
                If OrphansCount > 0 Then
                    btnShowOrphans.Enabled = True
                    'Continue For
                Else
                    btnShowOrphans.Enabled = False
                End If
                Dim q = From fams In Odb.Families Where fams.Mother_ID = Fid Select fams
                For Each fam As OrphanageClasses.Family In q
                    If Not fam.IsBaild Then
                        BtnBail.ToolTipText = "كفالة"
                        BtnBail.Image = My.Resources.Bail
                        'Continue For
                    Else
                        BtnBail.ToolTipText = "الغاء الكفالة"
                        BtnBail.Image = My.Resources.CancelBail
                    End If
                    If fam.IsExcluded Then
                        btnExclud.ToolTipText = "إلغاء الاستبعاد"
                    Else
                        btnExclud.ToolTipText = "استبعاد"
                    End If
                Next
                Odb.Dispose()
            End Using
        End If
        lblStatus.Text = StrCount & " المحدد " & radDataGrid.SelectedRows.Count
    End Sub

    Private Sub mnuSetColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetColor.Click
        Try
            Dim ColDia As New ColorDialog()
            If ColDia.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim i As Decimal = 0D
                Dim all As Decimal = radDataGrid.SelectedRows.Count
                For Each itm As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                    Using Odb As New OrphanageDB.Odb
                        Dim indexId As Integer = CInt(itm.Cells("ID").Value)
                        Dim q = From qfath In Odb.Mothers Where qfath.ID = indexId Select qfath
                        Dim fath As OrphanageClasses.Mother = q.FirstOrDefault()
                        If Not IsNothing(fath) Then
                            If ColDia.Color <> Color.White Then
                                fath.Color_Mark = ColDia.Color.ToArgb()
                                itm.Cells("Color_Mark").Value = ColDia.Color.ToArgb()
                            Else
                                fath.Color_Mark = Nothing
                                itm.Cells("Color_Mark").Value = Nothing
                            End If
                            Odb.SubmitChanges()
                            If IDSColors.ContainsKey(fath.ID) Then IDSColors.Remove(fath.ID)
                        End If
                        i += 1
                        Dim val As Integer
                        val = CInt((i / all) * 100D)
                        ProgressSate.ShowStatueProgress(val, "")
                        Odb.Dispose()
                    End Using
                Next
            End If
            ColDia.Dispose()
        Catch ex As Exception
            ProgressSate.ShowStatueProgress(100, "")
            ExceptionsManager.RaiseOnStatus(New MyException("حدث خطأ مجهول أثناء تغير لون السجل", True, True))
        End Try
    End Sub

    Private Sub FrmMothers_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        radDataGrid.SaveLayout("MothersLayout.Xaml")
        Layouts.SaveFormLayout(Me)
    End Sub

    Private Sub btnExclud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExclud.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        Try
            Dim retD As DialogResult = MsgBox("لن تظهر هذه العائلة بأية عمليات بحث أو طباعة أو كفالات هل تريد المتابعة؟", MsgBoxStyle.Question Or MsgBoxStyle.YesNo)
            If retD = vbYes Then
                Dim DeletedRows As New ArrayList
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                    Using Odb As New OrphanageDB.Odb
                        Dim fath As OrphanageClasses.Mother = Getter.GetMotherByID(CType(row.Cells("ID").Value, Integer), Odb)
                        Dim Fams() As OrphanageClasses.Family = fath.Families.ToArray()
                        For Each fam As OrphanageClasses.Family In Fams
                            If Not fam.IsExcluded Then
                                If Not Deleter.ExcludeFamily(fam.ID) Then
                                    ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج استبعاد القيد " & Getter.GetFullName(fath.Name), True, True))
                                    Exit Sub
                                Else
                                    DeletedRows.Add(row)
                                    ExceptionsManager.RaiseOnStatus(New MyException("تم استبعاد القيد " & Getter.GetFullName(fath.Name), False, False))
                                End If
                            Else
                                If Not Deleter.UnExcludeFamily(fam.ID) Then
                                    ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج استرداد القيد " & Getter.GetFullName(fath.Name), True, True))
                                    Exit Sub
                                Else
                                    ExceptionsManager.RaiseOnStatus(New MyException("تم استرداد القيد " & Getter.GetFullName(fath.Name), False, False))
                                End If
                            End If
                        Next
                        Odb.Dispose()
                    End Using
                Next
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In DeletedRows
                    radDataGrid.Rows.RemoveAt(row.Index)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub FrmFathers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'OrphansDBDataSet.Mothers' table. You can move, or remove it, as needed.
        Me.MothersTableAdapter.Fill(Me.OrphansDBDataSet.Mothers)
        If My.Settings.SaveGridState AndAlso IO.File.Exists("MothersLayout.Xaml") Then
            radDataGrid.LoadLayout("MothersLayout.Xaml")
        End If
        If My.Settings.SaveWindowsState Then
            Layouts.LoadFormLayout(Me)
        End If
        If IsNothing(ids) OrElse ids.Length <= 0 Then
            If My.Settings.ShowHiddenObject Then
                Me.MothersTableAdapter.Fill(Me.OrphansDBDataSet.Mothers)
            Else
                Me.MothersTableAdapter.FillByUnExcluded(Me.OrphansDBDataSet.Mothers)
            End If
        Else
            LoadData(ids)
        End If
        radDataGrid.TableElement.GridViewElement.GroupPanelElement.Text = "اسحب الاعمدة هنا"
        For Each elm In radDataGrid.TableElement.GridViewElement.GroupPanelElement.Children
            For Each elm1 In elm.Children
                For Each elm2 In elm1.Children
                    If TypeOf elm2 Is LightVisualElement Then
                        Dim Xobj As LightVisualElement = CType(elm2, LightVisualElement)
                        If Xobj.Text = "Group by:" Then
                            Xobj.Text = "تجميع بواسطة : "
                            Exit For
                        End If
                    End If
                Next
            Next
        Next
        If IsNothing(Me.MdiParent) Then
            Me.MdiParent = Application.OpenForms("FrmMain")
        End If
        AddHandler Updater.NewMother, AddressOf AddNewMother
        AddHandler Updater.UpdateMother, AddressOf UpdatesMother
        AddHandler Updater.DeleteMother, AddressOf DeletesMother
        If radDataGrid.RowCount > 0 Then
            StrCount = "العدد الكلي " & radDataGrid.RowCount
            lblStatus.Text = StrCount
        End If
        For Each col In radDataGrid.Columns
            If TypeOf (col) Is GridViewImageColumn Then
                col.ImageLayout = ImageLayout.Zoom
            End If
        Next
        Me.IsLoading = False
        Try
            CType(radDataGrid.Columns("Birthday"), Telerik.WinControls.UI.GridViewDateTimeColumn).Format = DateTimePickerFormat.Custom
            CType(radDataGrid.Columns("Birthday"), Telerik.WinControls.UI.GridViewDateTimeColumn).FormatString = "{0:" + My.Settings.GeneralDateFormat + "}"
            CType(radDataGrid.Columns("Dieday"), Telerik.WinControls.UI.GridViewDateTimeColumn).Format = DateTimePickerFormat.Custom
            CType(radDataGrid.Columns("Dieday"), Telerik.WinControls.UI.GridViewDateTimeColumn).FormatString = "{0:" + My.Settings.GeneralDateFormat + "}"
        Catch
        End Try
    End Sub

    Private Sub btnShowFathers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowFathers.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        Try
            Dim Rows = radDataGrid.SelectedRows
            Dim FathersIds As New ArrayList()
            For Each row As Telerik.WinControls.UI.GridViewRowInfo In Rows
                Dim moth As Integer = CType(row.Cells("ID").Value, Integer)
                Dim faths() As Integer = Getter.GetMotherFathers(moth)
                If Not IsNothing(faths) AndAlso faths.Count > 0 Then
                    For Each ff In faths
                        If Not FathersIds.Contains(ff) Then FathersIds.Add(ff)
                    Next
                End If
            Next
            If FathersIds.Count > 0 Then
                Dim frmFaths As New FrmFathers(CType(FathersIds.ToArray(GetType(Integer)), Integer()))
                frmFaths.MdiParent = Application.OpenForms("FrmMain")
                frmFaths.Show()
                WindowsLauncher.AllWindows.Add(frmFaths)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub radDataGrid_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles radDataGrid.CellDoubleClick
        If TypeOf e.Value Is Image Then
            Try
                Dim picxx As Image = CType(e.Value, Image)
                Dim frmShopic As New FrmShowPic(picxx, radDataGrid.Rows(e.RowIndex).Cells("FullName").Value.ToString())
                frmShopic.ShowDialog()
                frmShopic.Dispose()
            Catch

            End Try
        Else
            If e.RowIndex > 0 AndAlso e.ColumnIndex > 0 Then
                btnEdit_Click(Nothing, Nothing)
            End If
        End If
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
            cell.FilterButton.AutoSize = False
            cell.FilterButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
            cell.FilterButton.Size = New Size(1, 1)
            e.CellElement = cell
            e.CellType = cell.GetType()
        End If
    End Sub

    Private Sub btnShowOrphans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowOrphans.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        Try
            Dim Rows = radDataGrid.SelectedRows
            Dim FathersIds As New ArrayList()
            For Each row As Telerik.WinControls.UI.GridViewRowInfo In Rows
                Dim orps() As Integer = Getter.GetMotherOrphans(CType(row.Cells("ID").Value, Integer))
                If Not IsNothing(orps) AndAlso orps.Length > 0 Then
                    FathersIds.AddRange(orps)
                End If
            Next
            If FathersIds.Count > 0 Then
                WindowsLauncher.LaunchOrphans(CType(FathersIds.ToArray(GetType(Integer)), Integer()))
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Try
            radDataGrid.Dispose()
        Catch
        End Try
        MyBase.Finalize()
    End Sub

    Private Sub radDataGrid_GroupByChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCollectionChangedEventArgs) Handles radDataGrid.GroupByChanged
        radDataGrid.TableElement.GridViewElement.GroupPanelElement.Text = "اسحب الاعمدة هنا"
        For Each elm In radDataGrid.TableElement.GridViewElement.GroupPanelElement.Children
            For Each elm1 In elm.Children
                For Each elm2 In elm1.Children
                    If TypeOf elm2 Is LightVisualElement Then
                        Dim Xobj As LightVisualElement = CType(elm2, LightVisualElement)
                        If Xobj.Text = "Group by:" Then
                            Xobj.Text = "تجميع بواسطة : "
                            Exit For
                        End If
                    End If
                Next
            Next
        Next
    End Sub

    Private Sub MnuBail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBail.Click
        Try
            Dim Mid As Integer = 0
            Dim Fids As New Dictionary(Of Integer, GridViewRowInfo)
            If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
                For Each ros In radDataGrid.SelectedRows
                    Mid = CInt(ros.Cells("ID").Value)
                    Dim FamIds() As Integer = Getter.GetMotherFamiles(Mid)
                    For Each inMid As Integer In FamIds
                        If Not Fids.ContainsKey(inMid) Then
                            Fids.Add(inMid, ros)
                        End If
                    Next
                Next
            End If
            If Mid = 0 OrElse Fids.Count = 0 Then Return
            Dim FamsIds() As Integer = Fids.Keys.ToArray()
            Dim BailClass As New Bails(FamsIds, True, My.Settings.BailsReplaceAll)
            BailClass.CancelFamiliesBails = My.Settings.CancelFamiliesBails
            BailClass.CancelOrphansBails = My.Settings.BailsCancelOrphansBails
            If Not BtnBail.ToolTipText.Contains("غاء") Then
                BailClass.DoBails()
            Else
                BailClass.UnDoBails()
            End If
            For Each famId As Integer In Fids.Keys
                If BailClass.SkipedIds.Contains(famId) Then Continue For
                If Not IsNothing(Fids(famId)) Then
                    If My.Settings.UseColors AndAlso My.Settings.UseSupporterColorForBails Then
                        If BailClass.HasSuporterColor Then
                            For Each cel As GridViewCellInfo In Fids(famId).Cells
                                cel.Style.CustomizeFill = True
                                cel.Style.DrawFill = True
                                cel.Style.ForeColor = BailClass.SupporterColor
                                cel.Style.BackColor = Nothing
                            Next
                        End If
                    End If
                End If
                If Not IsNothing(famId) And famId > 0 Then
                    Using Odb As New OrphanageDB.Odb
                        Dim forFamID As Integer = famId
                        Dim q = From fam In Odb.Families Where fam.ID = forFamID Select fam
                        Try
                            Updater.UpdatesFamily(q.FirstOrDefault())
                            UpdatesMother(q.FirstOrDefault().Mother)
                        Catch
                        End Try
                        Odb.Dispose()
                    End Using
                End If
            Next
            radDataGrid.ClearSelection()
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub radDataGrid_RowFormatting(sender As System.Object, e As Telerik.WinControls.UI.RowFormattingEventArgs) Handles radDataGrid.RowFormatting
        Layouts.DrawRowColors(e, IDSColors, "ID", "Color_Mark", IsLoading)
    End Sub
End Class
