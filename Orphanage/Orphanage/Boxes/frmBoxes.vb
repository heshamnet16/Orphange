Imports Telerik.WinControls.UI
Public Class FrmBoxes
    Private StrCount As String = ""


#Region "ContextMenu"
    Dim WithEvents MainMnu As New RadContextMenu()
    Dim WithEvents mnuShows As New RadMenuItem("عرض")
    Dim WithEvents SubSBills As New RadMenuItem("عرض الوصول")
    Dim WithEvents SubSBails As New RadMenuItem("عرض الكفالات")
    Dim WithEvents SubSTransforms As New RadMenuItem("عرض التحويلات")
    Dim WithEvents SubSSupporters As New RadMenuItem("عرض الكفلاء")
    Dim WithEvents mnuOperations As New RadMenuItem("عمليات")
    Dim WithEvents mnuDrawABill As New RadMenuItem("سحب")
    Dim WithEvents mnuDepositeABail As New RadMenuItem("إيداع")
    Dim WithEvents mnuCollapseAll As New RadMenuItem("طي الكل")
    Dim WithEvents mnuExpandAll As New RadMenuItem("توسيع الكل")
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
        Me.Font = fon
        radDataGrid.Font = fon
        radDataGrid.PrintStyle.CellFont = fon
        radDataGrid.Refresh()
    End Sub
    Private Sub BuildContextList()
        AddHandler mnuCollapseAll.Click, AddressOf mnuCollapseAll_Click
        AddHandler mnuExpandAll.Click, AddressOf mnuExpandAll_MouseDown
        mnuShows.Items.Add(SubSBills)
        mnuShows.Items.Add(SubSTransforms)
        mnuOperations.Items.Add(New RadMenuSeparatorItem())
        mnuShows.Items.Add(SubSSupporters)
        mnuShows.Items.Add(SubSBails)
        MainMnu.Items.Add(mnuShows)
        mnuOperations.Items.Add(mnuDrawABill)
        mnuOperations.Items.Add(mnuDepositeABail)
        MainMnu.Items.Add(mnuOperations)
        MainMnu.Items.Add(New RadMenuSeparatorItem())
        MainMnu.Items.Add(mnuCollapseAll)
        MainMnu.Items.Add(mnuExpandAll)
    End Sub
#End Region

    Private Sub FrmBoxes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.SaveGridState Then
            radDataGrid.SaveLayout("BoxsLayout.Xaml")
        End If
        If My.Settings.SaveWindowsState Then
            Layouts.SaveFormLayout(Me)
        End If
    End Sub
    Private Sub FrmBoxes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'OrphansDBDataSet.Boxes' table. You can move, or remove it, as needed.
        radDataGrid.MasterTemplate.AddNewBoundRowBeforeEdit = True
        Me.BoxesTableAdapter.Fill(Me.OrphansDBDataSet.Boxes)
        AddHandler Updater.NewBox, AddressOf AddNewBox
        AddHandler Updater.UpdateBox, AddressOf UpdatesBox
        AddHandler Updater.DeleteBox, AddressOf DeletesBox
        If radDataGrid.RowCount > 0 Then
            StrCount = "العدد الكلي " & radDataGrid.RowCount
            lblStatus.Text = StrCount
        End If
        If My.Settings.SaveGridState Then
            If System.IO.File.Exists("BoxsLayout.Xaml") Then
                radDataGrid.LoadLayout("BoxsLayout.Xaml")
            End If
        End If
        If My.Settings.SaveWindowsState Then
            Layouts.LoadFormLayout(Me)
        End If
        Dim col As GridViewDecimalColumn = CType(radDataGrid.Columns("AMount"), GridViewDecimalColumn)
        col.DecimalPlaces = My.Settings.DecimalPercion
        col.ThousandsSeparator = My.Settings.UseThousendSeprator
        col.FormatString = "{0:F" & My.Settings.DecimalPercion.ToString() & "}"
        BuildContextList()
    End Sub
#Region "UpdateRows"
    Private Sub DeletesBox(ByVal bx As Integer)
        For Each row In radDataGrid.Rows
            Dim id As Integer = CInt(row.Cells("ID").Value)
            If id = bx Then
                row.IsVisible = False
                Exit For
            End If
            Application.DoEvents()
        Next
    End Sub
    Private Sub AddNewBox(ByVal bx As OrphanageClasses.Box)
        Dim xx = radDataGrid.Rows.AddNew()
        xx.Cells("ID").Value = bx.ID
        xx.Cells("Name").Value = bx.Name
        xx.Cells("Cur_Name").Value = bx.Currency_Name
        xx.Cells("Cur_Short").Value = bx.Currency_Short
        xx.Cells("AMount").Value = bx.Amount
        xx.Cells("Is_Positive").Value = bx.Is_Positive
        xx.Cells("Note").Value = bx.Note
        xx.Cells("RegDate").Value = bx.RegDate
        xx.Cells("UserName").Value = bx.User.UserName
    End Sub
    Private Sub UpdatesBox(ByVal bx As OrphanageClasses.Box)
        For Each row In radDataGrid.Rows
            Dim id As Integer = CInt(row.Cells("ID").Value)
            If id = bx.ID Then
                row.Cells("ID").Value = bx.ID
                row.Cells("Name").Value = bx.Name
                row.Cells("Cur_Name").Value = bx.Currency_Name
                row.Cells("Cur_Short").Value = bx.Currency_Short
                row.Cells("AMount").Value = bx.Amount
                row.Cells("Is_Positive").Value = bx.Is_Positive
                row.Cells("Note").Value = bx.Note
                row.Cells("RegDate").Value = bx.RegDate
                row.Cells("UserName").Value = bx.User.UserName
                Exit For
            End If
            Application.DoEvents()
        Next
    End Sub
#End Region
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If frmLogin.CurrentUser.IsAdmin AndAlso frmLogin.CurrentUser.CanAdd Then
            Dim frm As New FrmBox()
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        End If
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count = 1 Then
            Dim frm As New FrmBox(CInt(radDataGrid.SelectedRows(0).Cells("ID").Value))
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
            Dim Id As Integer = CInt(radDataGrid.SelectedRows(0).Cells("ID").Value)
            If Deleter.DeleteBox(Id) Then
                ExceptionsManager.RaiseOnStatus(New MyException("تم الحذف بنجاح!", False, True))
            End If
        End If
    End Sub

    Private Sub btnColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColumn.Click
        radDataGrid.ColumnChooser.Text = "الأعمدة"
        radDataGrid.ColumnChooser.ColumnChooserControl.ColumnChooserElement.Text = "اسحب الأعمدة من و إلى الشبكة"
        radDataGrid.ColumnChooser.Show()
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
    Private Sub RadGridView1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.Enter
        LangChanger.CurLang.SaveCurrentLanguage()
        LangChanger.CurLang.ChangeToArabic()
    End Sub

    Private Sub RadGridView1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.Leave
        LangChanger.CurLang.ReturnToSavedLanguage()
    End Sub

    Private Sub radDataGrid_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.SelectionChanged
        If radDataGrid.SelectedRows.Count = 1 Then
            Dim id As Integer = CInt(radDataGrid.SelectedRows(0).Cells("ID").Value)
            If id = 0 Then Exit Sub
            Using odb As New OrphanageDB.Odb
                Dim temp As OrphanageClasses.Box = Getter.GetBoxByID(id, odb)
                Dim strAll As String = ""
                Dim BillsCount As Integer = 0
                Dim TransformsFrom As Integer = 0
                Dim TransformsTo As Integer = 0
                Dim BailsCount As Integer = 0
                Dim AllOutComing = 0.0, AllIncoming As Double = 0
                If Not IsNothing(temp) Then
                    If Not IsNothing(temp.Bills) AndAlso temp.Bills.Count > 0 Then
                        btnShowBills.Enabled = True
                        BillsCount = temp.Bills.Count
                        'For Each bil In temp.Bills
                        '    If bil.IsDeposite Then
                        '        AllIncoming += CDbl(bil.Amount)
                        '    Else
                        '        AllOutComing += CDbl(bil.Amount)
                        '    End If
                        'Next
                    Else
                        btnShowBills.Enabled = False
                        BillsCount = 0
                    End If
                    If Not IsNothing(temp.Transforms) AndAlso temp.Transforms.Count > 0 Then
                        btnShowTransforms.Enabled = True
                        TransformsFrom = temp.Transforms.Count
                    Else
                        btnShowTransforms.Enabled = False
                        TransformsFrom = 0
                    End If
                    If Not IsNothing(temp.Transforms1) AndAlso temp.Transforms1.Count > 0 Then
                        If Not btnShowTransforms.Enabled Then
                            btnShowTransforms.Enabled = True
                        End If
                        TransformsTo = temp.Transforms1.Count
                    Else
                        TransformsTo = 0
                    End If
                    If Not IsNothing(temp.Bails) AndAlso temp.Bails.Count > 0 Then
                        BailsCount = temp.Bails.Count
                    Else
                        BailsCount = 0
                    End If
                End If
                strAll = "عدد الفواتير : " & BillsCount.ToString & vbNewLine
                strAll &= "عدد التحويلات من الحساب : " & TransformsFrom.ToString & vbNewLine
                strAll &= "عدد التحويلات إلى الحساب : " & TransformsTo.ToString() & vbNewLine
                strAll &= "عدد الكفالات : " & BailsCount.ToString() & vbNewLine
                'strAll &= "مجموع المبالغ الواردة : " & AllIncoming.ToString() & vbNewLine
                'strAll &= "مجموع المبالغ الصادرة : " & AllOutComing.ToString() & vbNewLine
                RadTextBox1.Text = strAll
                odb.Dispose()
            End Using
        Else
            GC.Collect()
        End If
        'radDataGrid.TableElement.FilterRowHeight = 30
        lblStatus.Text = StrCount & " المحدد " & radDataGrid.SelectedRows.Count
    End Sub

    Private Sub mnuDraw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If radDataGrid.SelectedRows.Count = 1 Then
            Dim id As Integer = CInt(radDataGrid.SelectedRows(0).Cells("ID").Value)
            If id = 0 Then Exit Sub
            Dim frm As New FrmBill(False, id)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        End If
    End Sub

    Private Sub mnuDeposite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If radDataGrid.SelectedRows.Count = 1 Then
            Dim id As Integer = CInt(radDataGrid.SelectedRows(0).Cells("ID").Value)
            If id = 0 Then Exit Sub
            Dim frm As New FrmBill(True, id)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        End If
    End Sub

    Private Sub mnuCollapseAll_Click(ByVal sender As Object, ByVal e As EventArgs)
        radDataGrid.MasterTemplate.CollapseAllGroups()
    End Sub

    Private Sub mnuExpandAll_MouseDown(ByVal sender As Object, ByVal e As EventArgs)
        radDataGrid.MasterTemplate.ExpandAllGroups()
    End Sub

    Private Sub radDataGrid_ContextMenuOpening(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.ContextMenuOpeningEventArgs) Handles radDataGrid.ContextMenuOpening
        e.ContextMenu = MainMnu.DropDown
    End Sub

    Private Sub mnuDrawABill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDrawABill.Click
        If IsNothing(radDataGrid.SelectedRows) Then Return
        If radDataGrid.SelectedRows.Count = 1 Then
            Dim id As Integer = CInt(radDataGrid.SelectedRows(0).Cells("ID").Value)
            If id = 0 Then Exit Sub
            WindowsLauncher.LaunchNewBills(False, id)
        End If
    End Sub

    Private Sub mnuDepositeABail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDepositeABail.Click
        If IsNothing(radDataGrid.SelectedRows) Then Return
        If radDataGrid.SelectedRows.Count = 1 Then
            Dim id As Integer = CInt(radDataGrid.SelectedRows(0).Cells("ID").Value)
            If id = 0 Then Exit Sub
            WindowsLauncher.LaunchNewBills(True, id)
        End If
    End Sub

    Private Sub btnShowBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowBills.Click, SubSBills.Click
        If IsNothing(radDataGrid.SelectedRows) Then Return
        If radDataGrid.SelectedRows.Count > 0 Then
            Dim arBox As New ArrayList()
            For Each row In radDataGrid.SelectedRows
                Dim id As Integer = CInt(row.Cells("ID").Value)
                If id = 0 Then Exit Sub
                Dim temp() As Integer = Getter.GetBoxBills(id)
                If Not IsNothing(temp) Then
                    arBox.AddRange(temp)
                End If
            Next
            If arBox.Count > 0 Then
                WindowsLauncher.LaunchBills(CType(arBox.ToArray(GetType(Integer)), Integer()))
            End If
        End If
    End Sub

    Private Sub SubSBails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubSBails.Click
        If IsNothing(radDataGrid.SelectedRows) Then Return
        If radDataGrid.SelectedRows.Count > 0 Then
            Dim arBox As New ArrayList()
            For Each row In radDataGrid.SelectedRows                
                Dim id As Integer = CInt(row.Cells("ID").Value)
                If id = 0 Then Exit Sub
                Dim temp() As Integer = Getter.GetBoxBails(id)
                If Not IsNothing(temp) Then
                    arBox.AddRange(temp)
                End If
            Next
            If arBox.Count > 0 Then
                WindowsLauncher.LaunchBails(CType(arBox.ToArray(GetType(Integer)), Integer()))
            End If
        End If
    End Sub

    Private Sub SubSSupporters_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubSSupporters.Click
        If IsNothing(radDataGrid.SelectedRows) Then Return
        If radDataGrid.SelectedRows.Count > 0 Then
            Dim arBox As New ArrayList()
            For Each row In radDataGrid.SelectedRows
                Dim id As Integer = CInt(row.Cells("ID").Value)
                If id = 0 Then Exit Sub
                Dim temp() As Integer = Getter.GetboxSupporters(id)
                If Not IsNothing(temp) Then
                    For Each sup In temp
                        If Not arBox.Contains(temp) Then arBox.Add(temp)
                    Next
                End If
            Next
            If arBox.Count > 0 Then
                WindowsLauncher.LaunchSupporters(CType(arBox.ToArray(GetType(Integer)), Integer()))
            End If
        End If
    End Sub

    Private Sub btnDoBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoBills.Click
        If IsNothing(radDataGrid.SelectedRows) Then Return
        If radDataGrid.SelectedRows.Count = 1 Then
            Using odb As New OrphanageDB.Odb
                Dim id As Integer = CInt(radDataGrid.SelectedRows(0).Cells("ID").Value)
                If id = 0 Then Exit Sub
                Dim temp As OrphanageClasses.Box = Getter.GetBoxByID(id, odb)
                If Not IsNothing(temp) Then
                    WindowsLauncher.LaunchNewBills(temp)
                End If
            End Using
        End If
    End Sub

    Private Sub radDataGrid_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.MouseEnter
        LangChanger.CurLang.SaveCurrentLanguage()
        LangChanger.CurLang.ChangeToArabic()
        radDataGrid.Cursor = Cursors.Default
    End Sub

    Private Sub radDataGrid_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.MouseLeave
        LangChanger.CurLang.ReturnToSavedLanguage()
    End Sub

    Private Sub btnDoTransformes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoTransformes.Click
        If IsNothing(radDataGrid.SelectedRows) Then Return
        If radDataGrid.SelectedRows.Count = 1 Then
            Dim id As Integer = CInt(radDataGrid.SelectedRows(0).Cells("ID").Value)
            If id = 0 Then Exit Sub
            WindowsLauncher.LaunchNewTransfor(id)
        End If
    End Sub

    Private Sub btnShowTransforms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowTransforms.Click
        If IsNothing(radDataGrid.SelectedRows) Then Return
        If radDataGrid.SelectedRows.Count > 0 Then
            Dim arBox As New ArrayList()
            For Each row In radDataGrid.SelectedRows
                Dim id As Integer = CInt(row.Cells("ID").Value)
                If id = 0 Then Exit Sub
                Dim temp() As Integer = Getter.GetBoxTransfors(id)
                If Not IsNothing(temp) Then
                    For Each tr In temp
                        If Not arBox.Contains(tr) Then arBox.Add(temp)
                    Next
                End If
            Next
            If arBox.Count > 0 Then
                WindowsLauncher.LaunchTransforms(CType(arBox.ToArray(GetType(Integer)), Integer()))
            End If
        End If
    End Sub
End Class
