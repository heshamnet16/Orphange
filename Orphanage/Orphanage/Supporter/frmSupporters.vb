Imports Telerik.WinControls.UI

Public Class FrmSupporters

    'Dim Odb As New OrphanageDB.Odb()
    Private StrCount As String = ""
    Private ids() As Integer
    Dim IDSColors As New Dictionary(Of Integer, Color)
#Region "ContextMenu"
    Dim WithEvents MainMnu As New RadContextMenu()
    Dim WithEvents mnuShows As New RadMenuItem("عرض")
    Dim WithEvents mnuShowOrphans As New RadMenuItem("عرض الأيتام")
    Dim WithEvents mnuShowFAmilies As New RadMenuItem("عرض العائلات")
    Dim WithEvents MnuShowBails As New RadMenuItem("عرض كفالات")
    Dim WithEvents mnuShowBills As New RadMenuItem("عرض إيصالات")
    Dim WithEvents MnuOprations As New RadMenuItem("عمليات")
    Dim WithEvents mnuDoMony As New RadMenuItem("صرف كفالة")
    Dim WithEvents mnuCreateBill As New RadMenuItem("إنشاء إيصال")
    Dim WithEvents mnuCreateBail As New RadMenuItem("إنشاء كفالة")
    Private Sub BuildContextList()
        'Show Menu
        mnuShows.Items.Add(mnuShowOrphans)
        mnuShows.Items.Add(mnuShowFAmilies)
        mnuShows.Items.Add(New RadMenuSeparatorItem())
        mnuShows.Items.Add(MnuShowBails)
        mnuShows.Items.Add(mnuShowBills)
        'Operation Menu        
        MnuOprations.Items.Add(mnuCreateBill)
        MnuOprations.Items.Add(mnuCreateBail)
        MnuOprations.Items.Add(New RadMenuSeparatorItem())
        MnuOprations.Items.Add(mnuDoMony)
        'Main Menu
        MainMnu.Items.Add(mnuShows)
        MainMnu.Items.Add(New RadMenuSeparatorItem())
        MainMnu.Items.Add(MnuOprations)
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
        Try
            Dim i As Integer = 0
            Dim all As Integer = 0
            Dim PerValu As Integer = 0
            Dim LastPerValue As Integer = 0
            If IsNothing(Ids) Then
                Using odb As New OrphanageDB.Odb
                    odb.ObjectTrackingEnabled = False
                    Dim q = From spp In odb.Supporters Select spp.ID
                    If Not IsNothing(q) AndAlso q.Count > 0 Then
                        Ids = q.ToArray()
                    End If
                    odb.Dispose()
                End Using
            End If
            all = Ids.Count
            If radDataGrid.Rows.Count > 0 Then radDataGrid.Rows.Clear()
            For Each supp_Id In Ids
                Using Odb As New OrphanageDB.Odb
                    PerValu = Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100))
                    Dim supp As OrphanageClasses.Supporter = Getter.GetSupporterByID(supp_Id, Odb)
                    If IsNothing(supp) Then
                        If i = all - 1 Then
                            If My.Settings.SaveGridState Then
                                If System.IO.File.Exists("SupportersLayout.Xaml") Then
                                    radDataGrid.LoadLayout("SupportersLayout.Xaml")
                                End If
                            End If
                        End If
                        i += 1
                        If PerValu <> LastPerValue Then
                            ProgressSate.ShowStatueProgress(PerValu, "")
                            LastPerValue = PerValu
                        End If
                        Continue For
                    End If
                    Dim BoxName As String = ""
                    Dim OrphansNum As Integer = Getter.GetSupporterOrphansCount(supp_Id)
                    Dim FamiliesNum As Integer = Getter.GetSupporterFamiliesCount(supp_Id)
                    Dim AddressName As String = ""
                    If Not IsNothing(supp.Address_ID) AndAlso supp.Address_ID > 0 Then
                        AddressName = Getter.GetAddress(supp.Address)
                    End If
                    If Not IsNothing(supp.Box_ID) AndAlso supp.Box_ID > 0 Then
                        BoxName = supp.Box.Name & " " & supp.Box.Currency_Short
                    End If
                    Dim itm = radDataGrid.Rows.AddNew()
                    itm.Cells("ID").Value = supp.ID
                    itm.Cells("Name").Value = Getter.GetFullName(supp.Name)

                    If frmLogin.CurrentUser.CanDeposit AndAlso frmLogin.CurrentUser.CanDraw Then
                        itm.Cells("Amount").Value = supp.Box.Amount
                        itm.Cells("BoxName").Value = BoxName
                    Else
                        itm.Cells("Amount").Value = 0
                        itm.Cells("BoxName").Value = "لاتمتلك الصلاحية"
                    End If
                    itm.Cells("OrphansNum").Value = OrphansNum
                    itm.Cells("FamiliesNum").Value = FamiliesNum
                    itm.Cells("Is_Still_Suppo").Value = supp.Is_Still_Support
                    itm.Cells("Is_Monthly_sup").Value = supp.Is_Monthly_Support
                    itm.Cells("Is_Family_Sup").Value = supp.Is_Family_Support
                    itm.Cells("Address").Value = AddressName
                    itm.Cells("Note").Value = supp.Note
                    itm.Cells("UserName").Value = supp.User.UserName
                    itm.Cells("RegDate").Value = supp.RegDate
                    itm.Cells("Color_Mark").Value = supp.Color_Mark
                    'radDataGrid.Rows.Add(itm)
                    i += 1
                    If PerValu <> LastPerValue Then
                        ProgressSate.ShowStatueProgress(PerValu, "")
                        LastPerValue = PerValu
                    End If
                    Odb.Dispose()
                End Using
            Next
            If My.Settings.SaveGridState Then
                If System.IO.File.Exists("SupportersLayout.Xaml") Then
                    radDataGrid.LoadLayout("SupportersLayout.Xaml")
                End If
            End If
            ProgressSate.ShowStatueProgress(100, "")
            GC.Collect()
            If radDataGrid.RowCount > 0 Then
                StrCount = "العدد الكلي " & radDataGrid.RowCount
                lblStatus.Text = StrCount
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try

    End Sub
    Private Sub FrmSupporters_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If My.Settings.SaveGridState Then
            radDataGrid.SaveLayout("SupportersLayout.Xaml")
        End If
        If My.Settings.SaveWindowsState Then
            Layouts.SaveFormLayout(Me)
        End If
    End Sub

#Region "UpdateRows"
    Private Sub DeletesSupporter(ByVal bx As Integer)
        For Each row In radDataGrid.Rows
            Dim id As Integer = CInt(row.Cells("ID").Value)
            If id = bx Then
                row.IsVisible = False
                Exit For
            End If
            Application.DoEvents()
        Next
    End Sub
    Private Sub AddNewSupporter(ByVal supp As OrphanageClasses.Supporter)
        Dim xx = radDataGrid.Rows.AddNew()
        Dim BoxName As String = ""
        Dim OrphansNum As Integer = 0
        Dim FamiliesNum As Integer = 0
        Dim AddressName As String = ""
        If Not IsNothing(supp.Address_ID) AndAlso supp.Address_ID > 0 Then
            AddressName = Getter.GetAddress(supp.Address)
        End If
        If Not IsNothing(supp.Box_ID) AndAlso supp.Box_ID > 0 Then
            BoxName = supp.Box.Name & " " & supp.Box.Currency_Short
        End If
        If Not IsNothing(supp.Orphans) AndAlso supp.Orphans.Count > 0 Then
            OrphansNum = supp.Orphans.Count
        Else
            OrphansNum = 0
        End If
        If Not IsNothing(supp.Bails) AndAlso supp.Bails.Count > 0 Then
            For Each bal In supp.Bails
                If bal.Is_Family Then
                    FamiliesNum += bal.Families.Count
                End If
            Next
        End If
        xx.Cells("ID").Value = supp.ID
        xx.Cells("Name").Value = Getter.GetFullName(supp.Name)

        If frmLogin.CurrentUser.CanDeposit AndAlso frmLogin.CurrentUser.CanDraw Then
            xx.Cells("Amount").Value = supp.Box.Amount
            xx.Cells("BoxName").Value = BoxName
        Else
            xx.Cells("Amount").Value = 0
            xx.Cells("BoxName").Value = "لاتمتلك الصلاحية"
        End If
        xx.Cells("OrphansNum").Value = OrphansNum
        xx.Cells("FamiliesNum").Value = FamiliesNum
        xx.Cells("Is_Still_Suppo").Value = supp.Is_Still_Support
        xx.Cells("Is_Monthly_sup").Value = supp.Is_Monthly_Support
        xx.Cells("Is_Family_Sup").Value = supp.Is_Family_Support
        xx.Cells("Address").Value = AddressName
        xx.Cells("Note").Value = supp.Note
        xx.Cells("UserName").Value = supp.User.UserName
        xx.Cells("RegDate").Value = supp.RegDate
        xx.Cells("Color_Mark").Value = supp.Color_Mark
    End Sub
    Private Sub UpdatesSupporter(ByVal supp As OrphanageClasses.Supporter)
        Dim ret = radDataGrid.Rows.Where(Function(x) CInt(x.Cells("ID").Value) = supp.ID).FirstOrDefault()

        If Not IsNothing(ret) Then
            Dim xx As GridViewRowInfo = ret
            Dim id As Integer = CInt(xx.Cells("ID").Value)
            If id = supp.ID Then
                Dim BoxName As String = ""
                Dim OrphansNum As Integer = 0
                Dim FamiliesNum As Integer = 0
                Dim AddressName As String = ""
                If Not IsNothing(supp.Box_ID) AndAlso supp.Box_ID > 0 Then
                    BoxName = supp.Box.Name & " " & supp.Box.Currency_Short
                End If
                OrphansNum = Getter.GetSupporterOrphansCount(supp.ID)
                FamiliesNum = Getter.GetSupporterFamiliesCount(supp.ID)
                xx.Cells("ID").Value = supp.ID
                xx.Cells("Name").Value = Getter.GetFullName(supp.Name)

                If frmLogin.CurrentUser.CanDeposit AndAlso frmLogin.CurrentUser.CanDraw Then
                    xx.Cells("Amount").Value = supp.Box.Amount
                    xx.Cells("BoxName").Value = BoxName
                Else
                    xx.Cells("Amount").Value = 0
                    xx.Cells("BoxName").Value = "لاتمتلك الصلاحية"
                End If
                xx.Cells("OrphansNum").Value = OrphansNum
                xx.Cells("FamiliesNum").Value = FamiliesNum
                xx.Cells("Is_Still_Suppo").Value = supp.Is_Still_Support
                xx.Cells("Is_Monthly_sup").Value = supp.Is_Monthly_Support
                xx.Cells("Is_Family_Sup").Value = supp.Is_Family_Support
                xx.Cells("Address").Value = AddressName
                xx.Cells("Note").Value = supp.Note
                xx.Cells("UserName").Value = supp.User.UserName
                xx.Cells("RegDate").Value = supp.RegDate
                If supp.Color_Mark.HasValue Then
                    xx.Cells("Color_Mark").Value = supp.Color_Mark.Value
                Else
                    xx.Cells("Color_Mark").Value = Nothing
                End If
                If IDSColors.ContainsKey(supp.ID) Then IDSColors.Remove(supp.ID)
                If Not IsNothing(supp.Address_ID) AndAlso supp.Address_ID > 0 Then
                    AddressName = Getter.GetAddress(supp.Address)
                End If               
            End If
            Application.DoEvents()
        End If
    End Sub
#End Region
    Private Sub FrmSupporters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        AddHandler Updater.NewSupporter, AddressOf AddNewSupporter
        AddHandler Updater.UpdateSupporter, AddressOf UpdatesSupporter
        AddHandler Updater.DeleteSupporter, AddressOf DeletesSupporter
        Dim col As GridViewDecimalColumn = CType(radDataGrid.Columns("Amount"), GridViewDecimalColumn)
        col.DecimalPlaces = My.Settings.DecimalPercion
        col.ThousandsSeparator = My.Settings.UseThousendSeprator
        col.FormatString = "{0:F" & My.Settings.DecimalPercion.ToString() & "}"
        BuildContextList()
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

    Private Sub MnuColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColumn.Click
        radDataGrid.ColumnChooser.Text = "الأعمدة"
        radDataGrid.ColumnChooser.ColumnChooserControl.ColumnChooserElement.Text = "اسحب الأعمدة من و إلى الشبكة"
        radDataGrid.ColumnChooser.Show()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If frmLogin.CurrentUser.CanAdd Then
            Dim frm As New FrmSupporter()
            frm.MdiParent = Me.MdiParent
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If frmLogin.CurrentUser.CanDelete Then
            If IsNothing(radDataGrid.SelectedRows) Then Exit Sub
            Dim Row As Telerik.WinControls.UI.GridViewRowInfo = radDataGrid.SelectedRows(0)
            Dim frm As New FrmSupporter(CType(Row.Cells("ID").Value, Integer))
            frm.ShowDialog()
            frm.Dispose()
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        If Not frmLogin.CurrentUser.CanDelete Then
            ExceptionsManager.RaiseAccessDeniedException()
            Return
        End If
        Try
            Dim retD As DialogResult = MsgBox("هل تريد حذف كفيل/كفلاء مع كل المتعلقات بهم؟", MsgBoxStyle.Question Or MsgBoxStyle.YesNo)
            If retD = vbYes Then
                Dim DeletedRows As New ArrayList()
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                    If Not Deleter.DeleteSupporter(CType(row.Cells("ID").Value, Integer)) Then
                        ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج حذف القيد " & CType(row.Cells("ID").Value, Integer).ToString(), True, True))
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

    Private Sub RefreshOthers(ByVal IdP As Object)
        Dim id As Integer = CInt(IdP)
        For Each frm As Form In WindowsLauncher.AllWindows
            If TypeOf frm Is FrmFamiles Then
                If frm.Visible Then
                    Dim fas_IDs() As Integer = Getter.GetSupporterFamiles(id)
                    If Not IsNothing(fas_IDs) AndAlso fas_IDs.Length > 0 Then
                        For Each f_id In fas_IDs
                            Try
                                Dim Fam_Id As Integer = f_id
                                Using odb = New OrphanageDB.Odb
                                    'odb.ObjectTrackingEnabled = False
                                    Dim qF = From fam In odb.Families Where fam.ID = Fam_Id Select fam
                                    If Not IsNothing(qF) AndAlso qF.Count = 1 Then
                                        Dim ff As OrphanageClasses.Family = qF.FirstOrDefault()
                                        If Not IsNothing(ff) Then
                                            'BeginInvoke(New MethodInvoker(Sub() Updater.UpdatesFamily(ff)))
                                            Updater.UpdatesFamily(ff)
                                        End If
                                    End If
                                    odb.Dispose()
                                End Using
                            Catch
                            End Try
                        Next
                        CType(frm, FrmFamiles).StartBackgroundWorker()
                    End If
                End If
            End If
            If TypeOf frm Is frmOrphans Then
                If frm.Visible Then
                    Dim Ors_IDs() As Integer = Getter.GetSupporterOrphans(id)
                    If Not IsNothing(Ors_IDs) AndAlso Ors_IDs.Length > 0 Then
                        For Each o_id In Ors_IDs
                            Try
                                Dim orph_Id As Integer = o_id
                                Using odb = New OrphanageDB.Odb
                                    'odb.ObjectTrackingEnabled = False
                                    Dim qF = From orph In odb.Orphans Where orph.ID = orph_Id Select orph
                                    If Not IsNothing(qF) AndAlso qF.Count = 1 Then
                                        Dim ff As OrphanageClasses.Orphan = qF.FirstOrDefault()
                                        If Not IsNothing(ff) Then
                                            'BeginInvoke(New MethodInvoker(Sub() Updater.UpdatesOrphan(qF.FirstOrDefault())))
                                            Updater.UpdatesOrphan(qF.FirstOrDefault())
                                        End If
                                    End If
                                    odb.Dispose()
                                End Using
                            Catch
                            End Try
                        Next
                        CType(frm, frmOrphans).RunBackgroundWorker()
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub btnSetColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetColor.Click
        If frmLogin.CurrentUser.CanAdd Then
            Try
                Dim ColDia As New ColorDialog()
                If ColDia.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim i As Decimal = 0D
                    Dim all As Decimal = radDataGrid.SelectedRows.Count
                    For Each itm As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                        Using Odb As New OrphanageDB.Odb
                            Dim indexId As Integer = CInt(itm.Cells("ID").Value)
                            Dim q = From qfath In Odb.Supporters Where qfath.ID = indexId Select qfath
                            Dim fath As OrphanageClasses.Supporter = q.FirstOrDefault()
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
                                Try
                                    Dim t As New Threading.Thread(New Threading.ParameterizedThreadStart(AddressOf RefreshOthers))
                                    t.Start(indexId)
                                Catch
                                End Try
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
                ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True))
            End Try
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub radDataGrid_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.SelectionChanged
        If radDataGrid.SelectedRows.Count = 1 AndAlso Not IsNothing(radDataGrid.SelectedRows(0).Cells("ID").Value) Then
            Dim id As Integer = CInt(radDataGrid.SelectedRows(0).Cells("ID").Value)
            If id = 0 Then Exit Sub
            Using Odb As New OrphanageDB.Odb
                Odb.ObjectTrackingEnabled = False
                Dim temp As OrphanageClasses.Supporter = Getter.GetSupporterByID(id, Odb)
                Dim strAll As String = ""
                Dim LastBail As String = "غير معروف"
                Dim AllPayedMoney As Double = 0.0
                Dim AllMustPayed As Double = 0.0
                Dim ActiveBailNum As Integer = 0
                Dim AllBailsNum As Integer = 0
                Dim AllBailedFamilies As Integer = 0
                Dim AllBailedOrphans As Integer = 0
                Dim LasDate As Date = #1/1/1900#
                RadTextBox1.Text = "جاري اعداد التفاصيل"
                Dim Qbails = From bals In Odb.Bails Where bals.Supporter_ID = temp.ID Select bals
                If Not IsNothing(Qbails) AndAlso Qbails.Count > 0 Then
                    MnuShowBails.Enabled = True
                    mnuCreateBill.Enabled = True
                    mnuDoMony.Enabled = True
                    For Each bal In Qbails
                        AllBailsNum += 1
                        If bal.End_Date.HasValue Then
                            If bal.End_Date.Value > LasDate Then
                                LasDate = bal.End_Date.Value
                            End If
                        End If
                        If Not bal.Is_Ended Then
                            ActiveBailNum += 1
                            Dim bal_id As Integer = bal.ID
                            If Not bal.Is_Family Then
                                Dim Qorphs = From fam In Odb.Orphans Where fam.Bail_ID = bal_id Select fam
                                If Not IsNothing(Qorphs) AndAlso Qorphs.Count > 0 Then
                                    AllMustPayed += CDbl(CDbl(bal.Amount) * CDbl(Qorphs.Count))
                                    AllBailedOrphans += Qorphs.Count()
                                End If
                            Else
                                Dim Qfam = From fam In Odb.Families Where fam.Baild_ID = bal_id Select fam
                                If Not IsNothing(Qfam) AndAlso Qfam.Count > 0 Then
                                    AllMustPayed += CDbl(CDbl(bal.Amount) * CDbl(Qfam.Count))
                                    AllBailedFamilies += Qfam.Count()
                                End If
                            End If
                        Else
                            Continue For
                        End If
                    Next
                    Application.DoEvents()
                    RadTextBox1.Text = "جاري اعداد التفاصيل" & "."
                Else
                    MnuShowBails.Enabled = False
                    mnuCreateBill.Enabled = False
                    mnuDoMony.Enabled = False
                End If
                Dim qbox = From bx In Odb.Boxes Where bx.ID = temp.Box_ID Select bx
                Dim qBills = From bill In Odb.Bills Where bill.Box_ID = temp.Box_ID Select bill
                If Not IsNothing(qBills) AndAlso qBills.Count > 0 Then
                    For Each bil In qBills
                        If bil.IsDeposite Then
                            AllPayedMoney += CDbl(bil.Amount)
                        End If
                    Next
                    mnuShowBills.Enabled = True
                    Application.DoEvents()
                    RadTextBox1.Text = "جاري اعداد التفاصيل" & ".."
                Else
                    mnuShowBills.Enabled = False
                End If
                If LasDate.Year > 1900 Then
                    LastBail = LasDate.ToString(My.Settings.GeneralDateFormat)
                End If
                If Not IsNothing(radDataGrid.SelectedRows(0).Cells("FamiliesNum").Value) AndAlso CInt(radDataGrid.SelectedRows(0).Cells("FamiliesNum").Value) > 0 Then
                    mnuShowFAmilies.Enabled = True
                Else
                    mnuShowFAmilies.Enabled = False
                End If
                If Not IsNothing(radDataGrid.SelectedRows(0).Cells("OrphansNum").Value) AndAlso CInt(radDataGrid.SelectedRows(0).Cells("OrphansNum").Value) > 0 Then
                    mnuShowOrphans.Enabled = True
                Else
                    mnuShowOrphans.Enabled = False
                End If
                Dim qsName = From nam In Odb.Names Where nam.ID = temp.Name_ID Select nam
                strAll = "الكفيل : " & Getter.GetFullName(qsName.FirstOrDefault()) & vbNewLine
                strAll &= "تاريخ أنتهاء آخر كفالة : " & LastBail & vbNewLine
                strAll &= "عدد العائلات المكفولة : " & AllBailedFamilies & vbNewLine
                strAll &= "عدد الأيتام المكفولين : " & AllBailedOrphans & vbNewLine
                strAll &= "عدد الكفالات الكلي : " & AllBailsNum.ToString("F0") & vbNewLine
                strAll &= "عدد الكفالات الصالحة : " & ActiveBailNum.ToString("F0") & vbNewLine
                strAll &= "مجموع المبالغ المدفوعة : " & AllPayedMoney.ToString("F2") & " " & qbox.FirstOrDefault.Currency_Short & vbNewLine
                strAll &= "مجموع المبالغ اللازمة : " & AllMustPayed.ToString("F2") & " " & qbox.FirstOrDefault.Currency_Short & vbNewLine
                strAll &= "مجموع المبالغ المتبقة : " & Math.Abs((AllMustPayed - AllPayedMoney)).ToString("F2") & " " & qbox.FirstOrDefault.Currency_Short & vbNewLine
                RadTextBox1.Text = strAll
            End Using
        Else
            btnShowOrphans.Enabled = True
            GC.Collect()

        End If
        'radDataGrid.TableElement.FilterRowHeight = 30
        lblStatus.Text = StrCount & " المحدد " & radDataGrid.SelectedRows.Count
    End Sub
    Private Sub btnShowOrphans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowOrphans.Click
        If frmLogin.CurrentUser.CanRead Then
            If Not IsNothing(radDataGrid.SelectedRows) Then
                Dim orps As New ArrayList
                For Each row In radDataGrid.SelectedRows
                    Dim indexId As Integer = CInt(row.Cells("ID").Value)
                    Dim tempSup() As Integer = Getter.GetSupporterOrphans(indexId)
                    If IsNothing(tempSup) Then Continue For
                    orps.AddRange(tempSup)
                Next
                If orps.Count > 0 Then
                    WindowsLauncher.LaunchOrphans(CType(orps.ToArray(GetType(Integer)), Integer()))
                End If
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub btnDoBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoBills.Click
        If frmLogin.CurrentUser.CanAdd Then
            If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then            
                Dim S_id As Long = CLng(radDataGrid.SelectedRows(0).Cells("ID").Value)
                If S_id > 0 Then
                    WindowsLauncher.LaunchNewBail(S_id)
                End If
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Private Sub radDataGrid_ContextMenuOpening(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.ContextMenuOpeningEventArgs) Handles radDataGrid.ContextMenuOpening
        e.ContextMenu = MainMnu.DropDown
    End Sub
    Private Sub mnuCreateBail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCreateBail.Click
        btnDoBills_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuShowOrphans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowOrphans.Click
        btnShowOrphans_Click(Nothing, Nothing)
    End Sub

    Private Sub MnuShowBails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuShowBails.Click
        If frmLogin.CurrentUser.CanRead Then
            If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
                Dim ar As New ArrayList
                For Each ro As GridViewRowInfo In radDataGrid.SelectedRows
                    Dim R_id As Integer = CInt(ro.Cells("ID").Value)
                    Dim bails_IDS() As Integer = Getter.GetSupporterBails(R_id)
                    If Not IsNothing(bails_IDS) AndAlso bails_IDS.Length > 0 Then
                        ar.AddRange(bails_IDS)
                    End If
                Next
                If ar.Count > 0 Then
                    WindowsLauncher.LaunchBails(CType(ar.ToArray(GetType(Integer)), Integer()))
                End If
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub btnShowBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowBills.Click
        If frmLogin.CurrentUser.CanRead Then
            If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
                Dim ar As New ArrayList
                For Each ro As GridViewRowInfo In radDataGrid.SelectedRows
                    Dim S_id As Integer = CInt(ro.Cells("ID").Value)
                    Dim SBills() As Integer = Getter.GetSupporterBills(S_id)
                    If Not IsNothing(SBills) AndAlso SBills.Count > 0 Then
                        ar.AddRange(SBills)
                    End If                
                Next
                If ar.Count > 0 Then
                    WindowsLauncher.LaunchBills(CType(ar.ToArray(GetType(Integer)), Integer()))
                End If
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub mnuShowBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowBills.Click
        btnShowBills_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuShowFAmilies_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuShowFAmilies.Click
        If frmLogin.CurrentUser.CanRead Then
            If Not IsNothing(radDataGrid.SelectedRows) Then
                Dim fams As New ArrayList
                For Each row In radDataGrid.SelectedRows
                    Dim indexId As Integer = CInt(row.Cells("ID").Value)
                    Dim tempSup() As Integer = Getter.GetSupporterFamiles(indexId)
                    If IsNothing(tempSup) OrElse tempSup.Length <= 0 Then Continue For
                    fams.AddRange(tempSup)
                Next
                If fams.Count > 0 Then
                    WindowsLauncher.LaunchFamilies(CType(fams.ToArray(GetType(Integer)), Integer()))
                End If
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Private Sub radDataGrid_RowFormatting(sender As System.Object, e As Telerik.WinControls.UI.RowFormattingEventArgs) Handles radDataGrid.RowFormatting
        Layouts.DrawRowColors(e, IDSColors, "ID", "Color_Mark", False)
    End Sub
End Class
