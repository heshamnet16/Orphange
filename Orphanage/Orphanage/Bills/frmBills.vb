Imports Telerik.WinControls.UI
Imports Itenso.TimePeriod
Public Class FrmBills
    Dim groupBy As String = ""
    Dim AllDr_Bill As Decimal = 0
    Dim AllDe_Bill As Decimal = 0
    Private _Box_ID As Integer = 0
    Private _Bail_ID As Integer = 0
    Private Orphan_Id As Integer = 0
    Private Family_Id As Integer = 0
    Private _Box_Ids As System.Data.Linq.EntitySet(Of OrphanageClasses.Box) = Nothing
    Private _Orphan_Ids As System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan) = Nothing
    Private _Family_Ids As System.Data.Linq.EntitySet(Of OrphanageClasses.Family) = Nothing
    Private _Bail_IDs As System.Data.Linq.EntitySet(Of OrphanageClasses.Bail) = Nothing
    Private _MultiFill As Boolean = False
    Private _IDS() As Integer = Nothing
    Private StrCount As String = ""
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

    Public Sub New()
        InitializeComponent()        
    End Sub
    Public Sub New(ByVal ids() As Integer)
        InitializeComponent()
        Me._IDS = ids
        _MultiFill = True
    End Sub
    Public Sub New(ByVal Bx As OrphanageClasses.Box)
        InitializeComponent()
        Me._Box_ID = Bx.ID
    End Sub
    Public Sub New(ByVal Bx As System.Data.Linq.EntitySet(Of OrphanageClasses.Bail))
        InitializeComponent()
        Me._Bail_IDs = Bx
        _MultiFill = True
    End Sub
    Public Sub New(ByVal Bx As System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan))
        InitializeComponent()
        Me._Orphan_Ids = Bx
        _MultiFill = True
    End Sub
    Public Sub New(ByVal Bx As System.Data.Linq.EntitySet(Of OrphanageClasses.Box))
        InitializeComponent()
        Me._Box_Ids = Bx
        _MultiFill = True
    End Sub
    Public Sub New(ByVal Bx As System.Data.Linq.EntitySet(Of OrphanageClasses.Family))
        InitializeComponent()
        Me._Family_Ids = Bx
        _MultiFill = True
    End Sub
    Public Sub New(ByVal Orp As OrphanageClasses.Orphan)
        InitializeComponent()
        Me.Orphan_Id = Orp.ID
    End Sub
    Public Sub New(ByVal fam As OrphanageClasses.Family)
        InitializeComponent()
        Me.Family_Id = fam.ID
    End Sub
    Public Sub New(ByVal bal As OrphanageClasses.Bail)
        InitializeComponent()
        Me._Bail_ID = bal.ID
    End Sub

#Region "UpdateRows"
    Private Sub DeletesFamily(ByVal bx As Integer)
        For Each row In radDataGrid.Rows
            Dim id As Integer = CInt(row.Cells("ID").Value)
            If id = bx Then
                row.IsVisible = False
                Exit For
            End If
            Application.DoEvents()
        Next
    End Sub
    Private Sub AddNewBill(ByVal bx As OrphanageClasses.Bill)
        Dim xx As GridViewRowInfo
        Try
            xx = radDataGrid.Rows.AddNew()
        Catch ex As Exception
            Return
        End Try
        Try
            xx.Cells("ID").Value = bx.ID
            xx.Cells("Bill_Number").Value = bx.Bill_Number
            xx.Cells("BoxName").Value = bx.Box.Name
            xx.Cells("Amount").Value = bx.Amount
            xx.Cells("Cur_Name").Value = bx.Box.Currency_Name
            xx.Cells("SideName").Value = bx.Name
            xx.Cells("IsDeposite").Value = bx.IsDeposite
            xx.Cells("Details").Value = bx.Details
            xx.Cells("Bill_Date").Value = bx.Bill_Date
            xx.Cells("IsOrphan").Value = IIf(bx.Orphan_ID.HasValue, True, False)
            xx.Cells("Orphan_ID").Value = IIf(bx.Orphan_ID.HasValue, Orphan_Id, Nothing)
            xx.Cells("IsFamily").Value = IIf(bx.Family_ID.HasValue, True, False)
            xx.Cells("Family_ID").Value = IIf(bx.Family_ID.HasValue, Orphan_Id, Nothing)
            xx.Cells("IsBail").Value = IIf(bx.Bail_ID.HasValue, True, False)
            xx.Cells("Bail_Id").Value = IIf(bx.Bail_ID.HasValue, Orphan_Id, Nothing)
            xx.Cells("Box_ID").Value = bx.Box.ID
            xx.Cells("Note").Value = bx.Note
            xx.Cells("RegDate").Value = bx.RegDate
            xx.Cells("UserName").Value = bx.User.UserName
        Catch
        End Try
    End Sub
    Private Sub UpdatesBill(ByVal bx As OrphanageClasses.Bill)
        For Each xx In radDataGrid.Rows
            Dim id As Integer = CInt(xx.Cells("ID").Value)
            If id = bx.ID Then
                xx.Cells("Bill_Number").Value = bx.Bill_Number
                xx.Cells("BoxName").Value = bx.Box.Name
                xx.Cells("Amount").Value = bx.Amount
                xx.Cells("Cur_Name").Value = bx.Box.Currency_Name
                xx.Cells("SideName").Value = bx.Name
                xx.Cells("IsDeposite").Value = bx.IsDeposite
                xx.Cells("Details").Value = bx.Details
                xx.Cells("Bill_Date").Value = bx.Bill_Date
                xx.Cells("IsOrphan").Value = IIf(bx.Orphan_ID.HasValue, True, False)
                xx.Cells("Orphan_ID").Value = IIf(bx.Orphan_ID.HasValue, Orphan_Id, Nothing)
                xx.Cells("IsFamily").Value = IIf(bx.Family_ID.HasValue, True, False)
                xx.Cells("Family_ID").Value = IIf(bx.Family_ID.HasValue, Orphan_Id, Nothing)
                xx.Cells("IsBail").Value = IIf(bx.Bail_ID.HasValue, True, False)
                xx.Cells("Bail_Id").Value = IIf(bx.Bail_ID.HasValue, Orphan_Id, Nothing)
                xx.Cells("Box_ID").Value = bx.Box.ID
                xx.Cells("Note").Value = bx.Note
                xx.Cells("RegDate").Value = bx.RegDate
                xx.Cells("UserName").Value = bx.User.UserName
                Exit For
            End If
            Application.DoEvents()
        Next
    End Sub
#End Region

    Private Sub LoadFroDB()
        If Not _MultiFill Then
            If Me._Box_ID > 0 Then
                Me.BillsTableAdapter.ClearBeforeFill = True
                Me.BillsTableAdapter.FillByBox_ID(Me.OrphansDBDataSet.Bills, Me._Box_ID)
            ElseIf Me._Bail_ID > 0 Then
                Me.BillsTableAdapter.ClearBeforeFill = True
                Me.BillsTableAdapter.FillByBail_ID(Me.OrphansDBDataSet.Bills, Me._Bail_ID)
            ElseIf Me.Orphan_Id > 0 Then
                Me.BillsTableAdapter.ClearBeforeFill = True
                Me.BillsTableAdapter.FillByOrphan_ID(Me.OrphansDBDataSet.Bills, Me.Orphan_Id)
            ElseIf Me.Family_Id > 0 Then
                Me.BillsTableAdapter.ClearBeforeFill = True
                Me.BillsTableAdapter.FillByFamily_ID(Me.OrphansDBDataSet.Bills, Me.Family_Id)
            Else
                Me.BillsTableAdapter.ClearBeforeFill = True
                Me.BillsTableAdapter.Fill(Me.OrphansDBDataSet.Bills)
            End If
        Else
            If Not IsNothing(Me._Box_Ids) Then
                Me.BillsTableAdapter.ClearBeforeFill = True
                For Each bal In _Box_Ids
                    Me.BillsTableAdapter.FillByBox_ID(Me.OrphansDBDataSet.Bills, bal.ID)
                    If Me.BillsTableAdapter.ClearBeforeFill = True Then
                        Me.BillsTableAdapter.ClearBeforeFill = False
                    End If
                Next
            ElseIf Not IsNothing(Me._Bail_IDs) Then
                Me.BillsTableAdapter.ClearBeforeFill = True
                For Each bal In _Bail_IDs
                    Me.BillsTableAdapter.FillByBail_ID(Me.OrphansDBDataSet.Bills, bal.ID)
                    If Me.BillsTableAdapter.ClearBeforeFill = True Then
                        Me.BillsTableAdapter.ClearBeforeFill = False
                    End If
                Next
            ElseIf Not IsNothing(Me._Orphan_Ids) Then
                Me.BillsTableAdapter.ClearBeforeFill = True
                For Each bal In _Orphan_Ids
                    Me.BillsTableAdapter.FillByOrphan_ID(Me.OrphansDBDataSet.Bills, bal.ID)
                    If Me.BillsTableAdapter.ClearBeforeFill = True Then
                        Me.BillsTableAdapter.ClearBeforeFill = False
                    End If
                Next
            ElseIf Not IsNothing(Me._Family_Ids) Then
                Me.BillsTableAdapter.ClearBeforeFill = True
                For Each bal In _Family_Ids
                    Me.BillsTableAdapter.FillByFamily_ID(Me.OrphansDBDataSet.Bills, bal.ID)
                    If Me.BillsTableAdapter.ClearBeforeFill = True Then
                        Me.BillsTableAdapter.ClearBeforeFill = False
                    End If
                Next
            Else
                If IsNothing(Me._IDS) Then
                    Me.BillsTableAdapter.ClearBeforeFill = True
                    Me.BillsTableAdapter.Fill(Me.OrphansDBDataSet.Bills)
                Else
                    Dim i As Integer = 0
                    Dim all As Integer = _IDS.Count
                    Dim PerValue = 0, LastPerValue As Integer = 0
                    For Each id In Me._IDS
                        Dim bill As OrphanageClasses.Bill = Getter.GetBillByID(id)
                        i += 1
                        PerValue = CInt(Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100)))
                        If Not IsNothing(bill) Then
                            AddNewBill(bill)
                            If LastPerValue <> PerValue Then
                                ProgressSate.ShowStatueProgress(PerValue, "")
                                LastPerValue = PerValue
                                Application.DoEvents()
                            End If
                        End If
                    Next
                    ProgressSate.ShowStatueProgress(100, "")
                End If
            End If
        End If
        ProgressSate.ShowStatueProgress(100, "")
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
        If radDataGrid.RowCount > 0 Then
            StrCount = "العدد الكلي " & radDataGrid.RowCount
            lblStatus.Text = StrCount
        End If
    End Sub

    Private Sub FrmBills_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.SaveGridState Then
            radDataGrid.SaveLayout("Bills.Xaml")
        End If
        If My.Settings.SaveWindowsState Then
            Layouts.SaveFormLayout(Me)
        End If
    End Sub

    Private Sub FrmBills_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        radDataGrid.MasterTemplate.AddNewBoundRowBeforeEdit = True
        LoadFroDB()
        ProgressSate.ShowStatueProgress(100, "")
        Dim M1 As Integer = dteFrom.Value.Month
        M1 -= 1
        If M1 = 0 Then
            dteFrom.Value = New Date(dteFrom.Value.Year - 1, 12, dteFrom.Value.Day)
        Else
            dteFrom.Value = New Date(dteFrom.Value.Year, M1, dteFrom.Value.Day)
        End If
        If My.Settings.SaveGridState AndAlso IO.File.Exists("Bills.Xaml") Then
            radDataGrid.LoadLayout("Bills.Xaml")
        End If
        If My.Settings.SaveWindowsState Then
            Layouts.LoadFormLayout(Me)
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
        Dim col As GridViewDecimalColumn = CType(radDataGrid.Columns("Amount"), GridViewDecimalColumn)
        col.DecimalPlaces = My.Settings.DecimalPercion
        col.ThousandsSeparator = My.Settings.UseThousendSeprator
        col.FormatString = "{0:F" & My.Settings.DecimalPercion.ToString() & "}"
        If radDataGrid.RowCount > 0 Then
            StrCount = "العدد الكلي " & radDataGrid.RowCount
            lblStatus.Text = StrCount
        End If
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
        ArabicGridView(radDataGrid.ChildRows)
        Try
            For Each itm As GridGroupByExpression In e.NewItems
                If itm.Expression.Contains("IsDeposite") Then
                    For Each grp As DataGroup In radDataGrid.Groups
                        Dim grp1 As GridViewGroupRowInfo = grp.GroupRow
                        If grp1.HeaderText.Length = 9 AndAlso grp1.HeaderText.StartsWith("إيداع") Then
                            If grp1.HeaderText = ("إيداع: لا") Then
                                grp1.HeaderText = "عمليات سحب"
                            Else
                                grp1.HeaderText = "عمليات إيداع"
                            End If
                        End If
                    Next
                End If
            Next
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
        Catch
        End Try
    End Sub
    Private Sub ArabicGridView(ByVal rows As GridViewChildRowCollection)
        If Not IsNothing(rows) AndAlso rows.Count > 0 Then
            Dim sets = False
            For Each grp In rows
                If TypeOf grp Is GridViewGroupRowInfo Then
                    Dim grp1 As GridViewGroupRowInfo = CType(grp, GridViewGroupRowInfo)
                    sets = True
                    If grp1.HeaderText.ToLower().Contains("false") Then
                        grp1.HeaderText = grp1.HeaderText.Replace("False", "لا")
                    Else
                        grp1.HeaderText = grp1.HeaderText.Replace("True", "نعم")
                    End If
                End If
                If grp.HasChildRows Then
                    ArabicGridView(grp.ChildRows)
                End If
            Next
            If Not sets Then
                Try
                    Dim grp1 As GridViewGroupRowInfo = CType(rows(0).Group.GroupRow, GridViewGroupRowInfo)
                    sets = True
                    If grp1.HeaderText.ToLower().Contains("false") Then
                        grp1.HeaderText = grp1.HeaderText.Replace("False", "لا")
                    Else
                        grp1.HeaderText = grp1.HeaderText.Replace("True", "نعم")
                    End If
                Catch
                End Try
            End If
        End If
    End Sub
    Private Sub radDataGrid_CreateCell(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCreateCellEventArgs) Handles radDataGrid.CreateCell
        If IsNothing(e.CellType) Then Return
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

    Private Sub btnSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSort.Click
        If optBillDate.IsChecked Then
            If dteFrom.Value < dteTo.Value Then
                Me.BillsTableAdapter.ClearBeforeFill = True
                Me.BillsTableAdapter.FillByDatePeriod(Me.OrphansDBDataSet.Bills, dteFrom.Value, dteTo.Value)
                Me.BillsTableAdapter.ClearBeforeFill = False
            Else
                ExceptionsManager.RaiseOnStatus(New MyException("تحقق من التواريخ المدخلة", False, True))
                dteTo.Focus()
            End If
        Else
            If dteFrom.Value < dteTo.Value Then
                Me.BillsTableAdapter.ClearBeforeFill = True
                Me.BillsTableAdapter.FillByRegDate(Me.OrphansDBDataSet.Bills, dteFrom.Value, dteTo.Value)
                Me.BillsTableAdapter.ClearBeforeFill = False
            Else
                ExceptionsManager.RaiseOnStatus(New MyException("تحقق من التواريخ المدخلة", False, True))
                dteTo.Focus()
            End If
        End If
    End Sub

    Private Sub radDataGrid_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.SelectionChanged
        If IsNothing(radDataGrid.SelectedRows) Then Exit Sub
        If TypeOf radDataGrid.CurrentRow Is GridViewGroupRowInfo Then
            Try
                Dim itm As GridViewGroupRowInfo = CType(radDataGrid.CurrentRow, GridViewGroupRowInfo)
                AllDe_Bill = 0
                AllDr_Bill = 0
                btnShowFamilies.Enabled = False
                btnShowBails.Enabled = False
                btnShowOrphans.Enabled = False                
                For Each roe In itm.ChildRows
                    Dim isDep As Boolean = CBool(roe.Cells("IsDeposite").Value)
                    If isDep Then
                        AllDe_Bill += CDec(roe.Cells("Amount").Value)
                    Else
                        AllDr_Bill += CDec(roe.Cells("Amount").Value)
                    End If

                Next
                lblGroupCol.Text = "تجميع بواسطة : " & itm.HeaderText
                lblAllDeposit.Text = "المبالغ المودعة : " & AllDe_Bill
                lblAllDraws.Text = "المبالغ المسحوبة : " & AllDr_Bill
            Catch
            End Try
        Else
            If radDataGrid.SelectedRows.Count = 1 Then
                Try
                    AllDe_Bill = 0
                    AllDr_Bill = 0
                    If IsNothing(radDataGrid.SelectedRows) Then Exit Sub
                    Dim selectedBox As String = radDataGrid.SelectedRows(0).Cells("BoxName").Value.ToString & " العملة " & radDataGrid.SelectedRows(0).Cells("Cur_Name").Value.ToString
                    For Each itm In radDataGrid.ChildRows
                        Dim isDep As Boolean = CBool(itm.Cells("IsDeposite").Value)
                        If itm.Cells("BoxName").Value.ToString() & " العملة " & itm.Cells("Cur_Name").Value.ToString() = selectedBox Then
                            If isDep Then
                                AllDe_Bill += CDec(itm.Cells("Amount").Value)
                            Else
                                AllDr_Bill += CDec(itm.Cells("Amount").Value)
                            End If
                        End If
                    Next
                    lblGroupCol.Text = "اسم الحساب : " & selectedBox
                    lblAllDeposit.Text = "المبالغ المودعة : " & AllDe_Bill
                    lblAllDraws.Text = "المبالغ المسحوبة : " & AllDr_Bill
                Catch
                End Try
                Dim isbal As Boolean = CBool(radDataGrid.SelectedRows(0).Cells("IsBail").Value)
                If isbal Then
                    btnShowBails.Enabled = True
                Else
                    btnShowBails.Enabled = False
                End If
                Dim isfam As Boolean = CBool(radDataGrid.SelectedRows(0).Cells("IsFamily").Value)
                If isfam Then
                    btnShowFamilies.Enabled = True
                Else
                    btnShowFamilies.Enabled = False
                End If
                Dim isOrp As Boolean = CBool(radDataGrid.SelectedRows(0).Cells("IsOrphan").Value)
                If isOrp Then
                    btnShowOrphans.Enabled = True
                Else
                    btnShowOrphans.Enabled = False
                End If
            Else
                If IsNothing(radDataGrid.SelectedRows) Then Exit Sub
                AllDe_Bill = 0
                AllDr_Bill = 0
                Try
                    btnShowFamilies.Enabled = False
                    btnShowBails.Enabled = False
                    btnShowOrphans.Enabled = False
                    Dim selectedBox As String = radDataGrid.SelectedRows(0).Cells("BoxName").Value.ToString & " العملة " & radDataGrid.SelectedRows(0).Cells("Cur_Name").Value.ToString
                    Dim NoBx As Boolean = False
                    For Each itm In radDataGrid.SelectedRows
                        Dim isDep As Boolean = CBool(itm.Cells("IsDeposite").Value)
                        If isDep Then
                            AllDe_Bill += CDec(itm.Cells("Amount").Value)
                        Else
                            AllDr_Bill += CDec(itm.Cells("Amount").Value)
                        End If
                        If itm.Cells("BoxName").Value.ToString() & " العملة " & itm.Cells("Cur_Name").Value.ToString() <> selectedBox Then
                            NoBx = True
                        End If
                        Dim isbal As Boolean = CBool(itm.Cells("IsBail").Value)
                        If isbal Then
                            btnShowBails.Enabled = True
                        End If
                        Dim isfam As Boolean = CBool(itm.Cells("IsFamily").Value)
                        If isfam Then
                            btnShowFamilies.Enabled = True
                        End If
                        Dim isOrp As Boolean = CBool(itm.Cells("IsOrphan").Value)
                        If isOrp Then
                            btnShowOrphans.Enabled = True
                        End If
                    Next
                    If NoBx Then
                        lblGroupCol.Text = "اسم الحساب : " & "..."
                    Else
                        lblGroupCol.Text = "اسم الحساب : " & selectedBox
                    End If
                    lblAllDeposit.Text = "المبالغ المودعة : " & AllDe_Bill
                    lblAllDraws.Text = "المبالغ المسحوبة : " & AllDr_Bill
                Catch
                End Try
            End If
        End If
        lblAllDeposit.TextAlignment = ContentAlignment.TopLeft
        lblAllDraws.TextAlignment = ContentAlignment.TopLeft
        lblGroupCol.TextAlignment = ContentAlignment.TopLeft
        If lblAllDraws.Text.Count > 33 Then
            lblAllDraws.Text = "م.س : " & AllDr_Bill
        End If
        If lblAllDeposit.Text.Count > 33 Then
            lblAllDeposit.Text = "م.د : " & AllDe_Bill
        End If
        If radDataGrid.RowCount > 0 Then
            StrCount = "العدد الكلي " & radDataGrid.RowCount
            lblStatus.Text = StrCount
        End If
    End Sub

    Private Sub chkSort_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkSort.ToggleStateChanged
        RadGroupBox1.Enabled = chkSort.Checked
        RadGroupBox2.Enabled = chkSort.Checked
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off Then
            LoadFroDB()
        End If
    End Sub

    Private Sub btnColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColumn.Click
        radDataGrid.ColumnChooser.Text = "الأعمدة"
        radDataGrid.ColumnChooser.ColumnChooserControl.ColumnChooserElement.Text = "اسحب الأعمدة من و إلى الشبكة"
        radDataGrid.ColumnChooser.Show()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        If Not frmLogin.CurrentUser.CanDelete Then
            ExceptionsManager.RaiseAccessDeniedException()
            Return
        End If
        Try
            Dim retD As DialogResult = CType(MsgBox("هل تريد حذف وصل/وصول مع كل المتعلقات بهم؟", MsgBoxStyle.Question Or MsgBoxStyle.YesNo), Windows.Forms.DialogResult)
            If retD = vbYes Then
                Dim DeletedRows As New ArrayList()
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                    Dim bil As OrphanageClasses.Bill = Getter.GetBillByID(CType(row.Cells("ID").Value, Integer))
                    If IsNothing(bil) Then
                        DeletedRows.Add(row)
                        Continue For
                    End If
                    If Not Deleter.DeleteBill(bil.ID) Then
                        ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج حذف القيد ", True, True))
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

    Private Sub btnUnDoBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnDoBill.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        If Not frmLogin.CurrentUser.CanDelete Then
            ExceptionsManager.RaiseAccessDeniedException()
            Return
        End If
        Try
            Dim retD As DialogResult = CType(MsgBox("هل تريد إعادة المبالغ إلى حسابتها؟", MsgBoxStyle.Question Or MsgBoxStyle.YesNo), Windows.Forms.DialogResult)
            If retD = vbYes Then
                Dim DeletedRows As New ArrayList()
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                    Dim bil As OrphanageClasses.Bill = Getter.GetBillByID(CType(row.Cells("ID").Value, Integer))
                    If IsNothing(bil) Then
                        DeletedRows.Add(row)
                        Continue For
                    End If
                    If Not Deleter.UndoBill(bil.ID) Then
                        ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج إلغاء الوصل ", True, True))
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

    Private Sub btnShowOrphans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowOrphans.Click
        Try
            If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
                Dim bils As New System.Data.Linq.EntitySet(Of OrphanageClasses.Bill)
                For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                    Dim OrphID As Integer = CInt(row.Cells("ID").Value)
                    Dim bil As OrphanageClasses.Bill = Getter.GetBillByID(OrphID)
                    If Not IsNothing(bil) AndAlso Not bils.Contains(bil) Then
                        bils.Add(bil)
                    End If
                Next
                If bils.Count > 0 Then
                    WindowsLauncher.LaunchOrphans(bils)
                End If
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub btnShowFamilies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowFamilies.Click
        Try
            If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
                Dim bils As New System.Data.Linq.EntitySet(Of OrphanageClasses.Bill)
                For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                    Dim OrphID As Integer = CInt(row.Cells("ID").Value)
                    Dim bil As OrphanageClasses.Bill = Getter.GetBillByID(OrphID)
                    If Not IsNothing(bil) AndAlso Not bils.Contains(bil) Then
                        bils.Add(bil)
                    End If
                Next
                If bils.Count > 0 Then
                    WindowsLauncher.LaunchFamilies(bils)
                End If
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub btnShowBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowBails.Click
        Try
            If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
                Dim bils As New System.Data.Linq.EntitySet(Of OrphanageClasses.Bill)
                For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                    Dim OrphID As Integer = CInt(row.Cells("ID").Value)
                    Dim bil As OrphanageClasses.Bill = Getter.GetBillByID(OrphID)
                    If Not IsNothing(bil) AndAlso Not bils.Contains(bil) Then
                        bils.Add(bil)
                    End If
                Next
                If bils.Count > 0 Then
                    WindowsLauncher.LaunchBails(bils)
                End If
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub radDataGrid_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.MouseEnter
        LangChanger.CurLang.SaveCurrentLanguage()
        LangChanger.CurLang.ChangeToArabic()
        radDataGrid.Cursor = Cursors.Default
    End Sub

    Private Sub radDataGrid_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.MouseLeave
        LangChanger.CurLang.ReturnToSavedLanguage()
    End Sub
End Class
