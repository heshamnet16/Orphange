Imports Telerik.WinControls.UI
Imports System.IO
Imports System.ComponentModel

Public Class FrmFamiles
    'Private Delegate Sub AutoCompleteDelegate()
    'Private CallAutoComplete As New AutoCompleteDelegate(AddressOf UpdateData)
    'Dim t As New Threading.Thread(AddressOf CallUpdateData)
    'Dim Odb As New OrphanageDB.Odb()
    Private Delegate Sub FamilyRefreshDelegate(ByVal _id As Integer)
    Private StrCount As String = ""
    Private _OnlyBailed As Boolean = False
    Private _CustomView As Boolean = False
    Private IsLoading As Boolean = True
    Private _Ids() As Integer
    Private _SeletedRows As New ArrayList()
    Private _IsClosing As Boolean = False
    Dim ViewdRows As New ArrayList
#Region "ContextMenu"
    Dim WithEvents MainMnu As New RadContextMenu()
    Dim WithEvents mnuShows As New RadMenuItem("عرض")
    Dim WithEvents SubSOrphans As New RadMenuItem("عرض الأيتام")
    Dim WithEvents SubSFAthers As New RadMenuItem("عرض الآباء")
    Dim WithEvents SubSMothers As New RadMenuItem("عرض الأمهات")
    Dim WithEvents SubSBondsMen As New RadMenuItem("عرض المعيلين")
    Dim WithEvents SubSSupporters As New RadMenuItem("عرض الكفلاء")
    Dim WithEvents SubSBails As New RadMenuItem("عرض كفالات")
    Dim WithEvents SubSBills As New RadMenuItem("عرض فواتير")
    Dim WithEvents mnuOperations As New RadMenuItem("عمليات")
    Dim WithEvents mnuMakeABill As New RadMenuItem("سحب مبلغ")
    Dim WithEvents mnuDrawABail As New RadMenuItem("صرف كفالة")
    Dim WithEvents mnuMakeABail As New RadMenuItem("كفالة")
    Dim WithEvents mnuAddNewOrph As New RadMenuItem("إضافة يتيم")
    Dim WithEvents mnuCollapseAll As New RadMenuItem("طي الكل")
    Dim WithEvents mnuExpandAll As New RadMenuItem("توسيع الكل")
    Private Sub BuildContextList()
        AddHandler mnuCollapseAll.Click, AddressOf mnuCollapseAll_Click
        AddHandler mnuExpandAll.Click, AddressOf mnuExpandAll_MouseDown
        mnuShows.Items.Add(SubSFAthers)
        mnuShows.Items.Add(SubSMothers)
        mnuShows.Items.Add(SubSOrphans)
        mnuShows.Items.Add(SubSBondsMen)
        mnuShows.Items.Add(New RadMenuSeparatorItem())
        mnuShows.Items.Add(SubSSupporters)
        mnuShows.Items.Add(SubSBails)
        mnuShows.Items.Add(SubSBills)
        MainMnu.Items.Add(mnuShows)
        mnuOperations.Items.Add(mnuAddNewOrph)
        mnuOperations.Items.Add(New RadMenuSeparatorItem())
        mnuOperations.Items.Add(mnuMakeABill)
        mnuOperations.Items.Add(mnuDrawABail)
        mnuOperations.Items.Add(New RadMenuSeparatorItem())
        mnuOperations.Items.Add(mnuMakeABail)
        MainMnu.Items.Add(mnuOperations)
        MainMnu.Items.Add(New RadMenuSeparatorItem())
        MainMnu.Items.Add(mnuCollapseAll)
        MainMnu.Items.Add(mnuExpandAll)
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
        Me._CustomView = False
    End Sub
    Public Sub New(ByVal OnlyBailed As Boolean)
        InitializeComponent()
        Me._OnlyBailed = OnlyBailed
        Me._CustomView = True
    End Sub
    Public Sub New(ByVal Ids() As Integer)
        InitializeComponent()
        Me._Ids = Ids
        Me._CustomView = True
    End Sub
    Private Sub LoadData(ByVal _ids() As Integer)
        Try
            'RemoveHandler radDataGrid.ViewCellFormatting, AddressOf radDataGrid_ViewCellFormatting
            If My.Settings.ShowHiddenObject Then
                Me.FamiliesTableAdapter.UnBailed(Me.OrphansDBDataSet.Families)
            Else
                Me.FamiliesTableAdapter.UnBailedANDUnExcluded(Me.OrphansDBDataSet.Families)
            End If
            Dim xx = Me.OrphansDBDataSet.Families.Where(Function(x) _ids.Contains(x.Family_ID))
            radDataGrid.DataSource = xx.AsDataView()
            'AddHandler radDataGrid.ViewCellFormatting, AddressOf radDataGrid_ViewCellFormatting
            'Dim i As Integer = 0
            'Dim all As Integer = 0
            'Dim PerValue = 0, LastPerValue As Integer = 0
            'Dim ColorArray As New Dictionary(Of Integer, Long)
            'all = _ids.Count
            'If radDataGrid.Rows.Count > 0 Then radDataGrid.Rows.Clear()
            'radDataGrid.TableElement.BeginUpdate()
            'For Each id In _ids
            '    If _IsClosing Then Exit Sub
            '    i += 1
            '    PerValue = Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100))
            '    Using Odb As New OrphanageDB.Odb
            '        Dim fam As OrphanageClasses.Family = Getter.GetFamilyByID(id, Odb)
            '        If Not IsNothing(fam) Then
            '            If My.Settings.ShowHiddenObject Then
            '                AddNewFamily(fam)
            '            Else
            '                If IsNothing(fam.IsExcluded) OrElse Not fam.IsExcluded Then
            '                    AddNewFamily(fam)
            '                End If
            '            End If
            '        End If
            '        If LastPerValue <> PerValue Then
            '            ProgressSate.ShowStatueProgress(PerValue, "")
            '            LastPerValue = PerValue
            '        End If
            '    End Using
            'Next
            'radDataGrid.TableElement.EndUpdate()
            ProgressSate.ShowStatueProgress(100, "")
            If radDataGrid.RowCount > 0 Then
                StrCount = "العدد الكلي " & radDataGrid.RowCount
                lblStatus.Text = StrCount
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

#Region "UpdateRows"
    Private Sub DeletesFamily(ByVal bx As Integer)
        radDataGrid.TableElement.BeginUpdate()
        For Each row In radDataGrid.Rows
            Dim id As Integer = CInt(row.Cells("Family_ID").Value)
            If id = bx Then
                row.IsVisible = False
                Exit For
            End If
            Application.DoEvents()
        Next
        radDataGrid.TableElement.EndUpdate()
    End Sub
    Private Sub AddNewFamily(ByVal bx As OrphanageClasses.Family)
        Dim xx As GridViewRowInfo
        Try
            xx = radDataGrid.Rows.AddNew()
        Catch ex As Exception
            Return
        End Try
        Try
            Using AddNfam As New OrphanageDB.Odb
                Dim QFamAdd1 = From add1 In AddNfam.Addresses Where add1.ID = bx.Address_ID Select add1
                Dim QFamAdd2 = From add2 In AddNfam.Addresses Where add2.ID = bx.Address_ID2 Select add2
                Dim QFath = From fat In AddNfam.Fathers, Nfat In AddNfam.Names Where fat.Name_ID = Nfat.ID AndAlso fat.ID = bx.Father_ID
                            Select fat, Nfat
                Dim QMoth = From mot In AddNfam.Mothers, Nmot In AddNfam.Names Where mot.Name_ID = Nmot.ID AndAlso mot.ID = bx.Mother_ID
                            Select Nmot

                Dim QorphCount = Getter.GetFamilyOrphans(bx.ID)

                xx.Cells("Family_ID").Value = bx.ID
                xx.Cells("FathName").Value = Getter.GetFullName(QFath.FirstOrDefault().Nfat)
                xx.Cells("MothName").Value = Getter.GetFullName(QMoth.FirstOrDefault())
                xx.Cells("DeathResone").Value = QFath.FirstOrDefault().fat.DeathResone
                xx.Cells("Dieday").Value = QFath.FirstOrDefault().fat.Dieday
                If Not IsNothing(QorphCount) AndAlso QorphCount.Length > 0 Then
                    xx.Cells("OrphansCount").Value = QorphCount.Length
                Else
                    xx.Cells("OrphansCount").Value = 0
                End If
                xx.Cells("IsBailed").Value = bx.IsBaild
                If bx.Address_ID2.HasValue Then
                    xx.Cells("Country").Value = QFamAdd2.FirstOrDefault().Country
                    xx.Cells("City").Value = QFamAdd2.FirstOrDefault().City
                    xx.Cells("Town").Value = QFamAdd2.FirstOrDefault().Town
                    xx.Cells("Street").Value = QFamAdd2.FirstOrDefault().Street
                    xx.Cells("Home_Phone").Value = QFamAdd2.FirstOrDefault().Home_Phone
                    xx.Cells("Cell_Phone").Value = QFamAdd2.FirstOrDefault().Cell_Phone
                    xx.Cells("AddressID").Value = QFamAdd2.FirstOrDefault().ID
                Else
                    If bx.Address_ID.HasValue Then
                        xx.Cells("Country").Value = QFamAdd1.FirstOrDefault().Country
                        xx.Cells("City").Value = QFamAdd1.FirstOrDefault().City
                        xx.Cells("Town").Value = QFamAdd1.FirstOrDefault().Town
                        xx.Cells("Street").Value = QFamAdd1.FirstOrDefault().Street
                        xx.Cells("Home_Phone").Value = QFamAdd1.FirstOrDefault().Home_Phone
                        xx.Cells("Cell_Phone").Value = QFamAdd1.FirstOrDefault().Cell_Phone
                        xx.Cells("AddressID").Value = QFamAdd1.FirstOrDefault().ID
                    End If
                End If
                xx.Cells("Redidence_State").Value = bx.Residece_Sate
                xx.Cells("Residence_Type").Value = bx.Residenc_Type
                xx.Cells("Finncial_State").Value = bx.Finncial_Sate
                If bx.Color_Mark.HasValue Then
                    xx.Cells("Color_Mark").Value = bx.Color_Mark.Value
                End If
                xx.Cells("IsRefugee").Value = bx.IsRefugee
                If My.Settings.UseColors Then
                    Dim ColorM As Long = -102
                    If My.Settings.UseSupporterColorForBails Then
                        If bx.IsBaild AndAlso bx.Baild_ID.HasValue AndAlso bx.Bail.Supporter.Color_Mark.HasValue Then
                            ColorM = bx.Bail.Supporter.Color_Mark.Value
                        Else
                            If Not IsNothing(xx.Cells("Color_Mark").Value) AndAlso Not IsDBNull(xx.Cells("Color_Mark").Value) Then
                                ColorM = CLng(xx.Cells("Color_Mark").Value)
                            End If
                        End If
                    Else
                        If Not IsNothing(xx.Cells("Color_Mark").Value) AndAlso Not IsDBNull(xx.Cells("Color_Mark").Value) Then
                            ColorM = CLng(xx.Cells("Color_Mark").Value)
                        End If
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
                AddNfam.Dispose()
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Private Sub UpdatesFamliy(ByVal bx As OrphanageClasses.Family)
        Dim delRow As GridViewRowInfo = Nothing
        Dim re = radDataGrid.Rows.Where(Function(x) CInt(x.Cells("Family_ID").Value) = bx.ID).FirstOrDefault()
        Dim xx As GridViewRowInfo = re
        If IsNothing(xx) Then Exit Sub
        'For Each xx In radDataGrid.Rows
        Dim id As Integer = CInt(xx.Cells("Family_ID").Value)
        If id = bx.ID Then
            If Not bx.IsExcluded Then
                xx.Cells("FathName").Value = Getter.GetFullName(bx.Father.Name)
                xx.Cells("MothName").Value = Getter.GetFullName(bx.Mother.Name)
                xx.Cells("DeathResone").Value = bx.Father.DeathResone
                xx.Cells("Dieday").Value = bx.Father.Dieday
                If bx.Address_ID2.HasValue Then
                    xx.Cells("Country").Value = bx.Address1.Country
                    xx.Cells("City").Value = bx.Address1.City
                    xx.Cells("Town").Value = bx.Address1.Town
                    xx.Cells("Street").Value = bx.Address1.Street
                    xx.Cells("Home_Phone").Value = bx.Address1.Home_Phone
                    xx.Cells("Cell_Phone").Value = bx.Address1.Cell_Phone
                    xx.Cells("AddressID").Value = bx.Address1.ID
                Else
                    If bx.Address_ID.HasValue Then
                        xx.Cells("Country").Value = bx.Address.Country
                        xx.Cells("City").Value = bx.Address.City
                        xx.Cells("Town").Value = bx.Address.Town
                        xx.Cells("Street").Value = bx.Address.Street
                        xx.Cells("Home_Phone").Value = bx.Address.Home_Phone
                        xx.Cells("Cell_Phone").Value = bx.Address.Cell_Phone
                        xx.Cells("AddressID").Value = bx.Address.ID
                    End If
                End If
                Dim Ocount() As Integer = Getter.GetFamilyOrphans(bx.ID)
                If Not IsNothing(Ocount) AndAlso Ocount.Length > 0 Then
                    xx.Cells("OrphansCount").Value = Ocount.Length
                Else
                    xx.Cells("OrphansCount").Value = 0
                End If
                xx.Cells("IsBailed").Value = bx.IsBaild
                xx.Cells("Redidence_State").Value = bx.Residece_Sate
                xx.Cells("Residence_Type").Value = bx.Residenc_Type
                xx.Cells("Finncial_State").Value = bx.Finncial_Sate
                If bx.Color_Mark.HasValue Then
                    xx.Cells("Color_Mark").Value = bx.Color_Mark.Value
                Else
                    xx.Cells("Color_Mark").Value = Nothing
                End If
                xx.Cells("IsRefugee").Value = bx.IsRefugee
                If IDSColors.ContainsKey(bx.ID) Then IDSColors.Remove(bx.ID)
            Else
                xx.IsVisible = False
                delRow = xx
            End If
            'Exit For
        End If
        Application.DoEvents()
        'Next
        If Not IsNothing(delRow) Then
            Try
                radDataGrid.Rows.Remove(delRow)
            Catch
                Try
                    delRow.Delete()
                Catch

                End Try
            End Try
        End If
    End Sub
#End Region
    Private Sub AddCheckBoxColumn()
        Dim checkColumn As New GridViewCheckBoxColumn()
        checkColumn.Name = "Select"
        checkColumn.HeaderText = "تحديد"
        Me.radDataGrid.Columns.Insert(0, checkColumn)
    End Sub
    Private Sub FrmFamiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.SaveGridState AndAlso IO.File.Exists("Families.Xaml") Then
            radDataGrid.LoadLayout("Families.Xaml")
        End If
        If Not Me.radDataGrid.Columns.Contains("Select") Then
            AddCheckBoxColumn()
        End If
        If Me._CustomView Then
            If IsNothing(Me._Ids) Then
                If Me._OnlyBailed Then
                    If My.Settings.ShowHiddenObject Then
                        Me.FamiliesTableAdapter.Bailed(Me.OrphansDBDataSet.Families)
                    Else
                        Me.FamiliesTableAdapter.BailedAndUnExcluded(Me.OrphansDBDataSet.Families)
                    End If
                Else
                    If My.Settings.ShowHiddenObject Then
                        Me.FamiliesTableAdapter.UnBailed(Me.OrphansDBDataSet.Families)
                    Else
                        Me.FamiliesTableAdapter.UnBailedANDUnExcluded(Me.OrphansDBDataSet.Families)
                    End If
                End If
            Else
                LoadData(_Ids)
            End If
        Else
            If My.Settings.ShowHiddenObject Then
                Me.FamiliesTableAdapter.Fill(Me.OrphansDBDataSet.Families)
            Else
                Me.FamiliesTableAdapter.UnExcluded(Me.OrphansDBDataSet.Families)
            End If
        End If
        AddHandler Updater.NewFamily, AddressOf AddNewFamily
        AddHandler Updater.UpdateFamily, AddressOf UpdatesFamliy
        AddHandler Updater.DeleteFamily, AddressOf DeletesFamily
        'BackgroundWorker1.RunWorkerAsync()
        If IsNothing(Me.MdiParent) Then
            Me.MdiParent = Application.OpenForms("FrmMain")
        End If
        If radDataGrid.RowCount > 0 Then
            StrCount = "العدد الكلي " & radDataGrid.RowCount
            lblStatus.Text = StrCount
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
        BuildContextList()
        Me.IsLoading = False
        CType(radDataGrid.Columns("Dieday"), Telerik.WinControls.UI.GridViewDateTimeColumn).Format = DateTimePickerFormat.Custom
        CType(radDataGrid.Columns("Dieday"), Telerik.WinControls.UI.GridViewDateTimeColumn).FormatString = "{0:" + My.Settings.GeneralDateFormat + "}"
        RadGridView1_SelectionChanged(Nothing, Nothing)
        StartBackgroundWorker()
    End Sub
    Public Sub StartBackgroundWorker()
        If Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Private Sub FrmFathers_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.radDataGrid.Cursor = Cursors.WaitCursor Then
            Me.radDataGrid.Cursor = Cursors.Default
        End If
        If My.Settings.SaveGridState Then
            radDataGrid.SaveLayout("Families.Xaml")
        End If
        If My.Settings.SaveWindowsState Then
            Layouts.SaveFormLayout(Me)
        End If
        _IsClosing = True
    End Sub

    Private Sub radDataGrid_CreateCell(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCreateCellEventArgs) Handles radDataGrid.CreateCell
        'Console.WriteLine(e.CellType.FullName)
        If IsNothing(e.CellType) Then Return
        If e.CellType.FullName.Contains("FilterCellElement") Then
            Dim cell As New GridFilterCellElement(e.Column, e.Row)
            cell.FilterButton.Enabled = False
            e.CellElement = cell
            e.CellType = cell.GetType()
        End If
        If e.CellType.FullName.Contains("FilterCheckBoxCellElement") Then
            Dim cell As New GridFilterCheckBoxCellElement(e.Column, e.Row)
            cell.FilterButton.Enabled = False
            cell.FilterButton.AutoSize = False
            cell.FilterButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
            cell.FilterButton.Size = New Size(1, 1)
            e.CellElement = cell
            e.CellType = cell.GetType()
        End If
    End Sub

    Public Sub SetData(ByVal _idP As Object)
        Dim _id As Integer = CInt(_idP)
        Using EditFamCd As New OrphanageDB.Odb
            Dim temp As OrphanageClasses.Family = Getter.GetFamilyByID(_id, EditFamCd)
            Dim qFath = From fath1 In EditFamCd.Fathers, fam In EditFamCd.Families Where fam.Father_ID = fath1.ID And
                        fam.ID = _id Select fath1
            Dim Fath As OrphanageClasses.Father = qFath.First()
            Dim qMoth = From Moth1 In EditFamCd.Mothers, fam In EditFamCd.Families Where fam.Mother_ID = Moth1.ID And
                fam.ID = _id Select Moth1
            Dim Moth As OrphanageClasses.Mother = qMoth.First()
            If IsNothing(temp) Then Return
            Dim strAll As String = ""
            Dim MaleBro As Integer = 0
            Dim femaleBro As Integer = 0

            If Not IsNothing(temp) Then
                If Not temp.IsBaild Then
                    BeginInvoke(New MethodInvoker(Sub() mnuMakeABail.Text = "كفالة"))
                Else
                    BeginInvoke(New MethodInvoker(Sub() mnuMakeABail.Text = "الغاء الكفالة"))
                End If
                MaleBro = Getter.GetFamilyMaleOrphansCount(_id)
                femaleBro = Getter.GetFamilyFemaleOrphansCount(_id)
                If MaleBro + femaleBro > 0 Then
                    BeginInvoke(New MethodInvoker(Sub() btnShowOrphans.Enabled = True))
                Else
                    BeginInvoke(New MethodInvoker(Sub() btnShowOrphans.Enabled = False))
                End If
                If temp.IsExcluded Then
                    BeginInvoke(New MethodInvoker(Sub() btnExclud.ToolTipText = "إلغاء الاستبعاد"))
                    BeginInvoke(New MethodInvoker(Sub() btnExclud.Image = My.Resources.Cancelghost))
                Else
                    BeginInvoke(New MethodInvoker(Sub() btnExclud.ToolTipText = "استبعاد"))
                    BeginInvoke(New MethodInvoker(Sub() btnExclud.Image = My.Resources.ghost))
                End If
            End If
            Try
                strAll = "اسم الأب : " & Getter.GetFullName(Fath.Name) & vbNewLine
                strAll &= "تاريخ الوفاة : " & Fath.Dieday.ToString(My.Settings.GeneralDateFormat) & vbNewLine
                strAll &= "اسم الأم : " & Getter.GetFullName(Moth.Name) & vbNewLine
                strAll &= "متوفية : " & ATDFormater.ArabicBooleanFormatter.BooleanToArabic(Moth.IsDead) & vbNewLine
                If Moth.IsDead AndAlso Moth.Dieday.HasValue Then
                    Try
                        strAll &= "تاريخ الوفاة : " & Moth.Dieday.Value.ToString(My.Settings.GeneralDateFormat) & vbNewLine
                    Catch
                    End Try
                End If
                strAll &= "عدد الأيتام : " & MaleBro & " ذكور " & femaleBro & " إناث" & vbNewLine
                strAll &= "رقم البطاقة العائلة: " & temp.FamilyCard_Num & vbNewLine
                strAll &= "نوع السكن: " & temp.Residenc_Type & vbNewLine
                strAll &= "حالة السكن: " & temp.Residece_Sate & vbNewLine
                strAll &= "الحالة المالية: " & temp.Finncial_Sate & vbNewLine
                strAll &= "عائلة مهجرة : " & ATDFormater.ArabicBooleanFormatter.BooleanToArabic(temp.IsRefugee) & vbNewLine
                If temp.Address_ID.HasValue Then
                    strAll &= "العنوان الأصلي : " & Getter.GetAddress(temp.Address) & vbNewLine
                End If
                If temp.Address_ID2.HasValue Then
                    strAll &= "العنوان الحالي : " & Getter.GetAddress(temp.Address1) & vbNewLine
                End If
                strAll &= "مكفولة : " & ATDFormater.ArabicBooleanFormatter.BooleanToArabic(temp.IsBaild) & vbNewLine
                If temp.IsBaild AndAlso Not IsNothing(temp.Bail) AndAlso temp.Bail.ID > 0 AndAlso Not temp.Bail.Is_Ended Then
                    strAll &= "الكفيل: " & Getter.GetFullName(temp.Bail.Supporter.Name) & vbNewLine
                    strAll &= "مبلغ الكفالة: " & temp.Bail.Amount.ToString() & " " & temp.Bail.Box.Currency_Short & vbNewLine
                    strAll &= "كفالة شهرية : " & ATDFormater.ArabicBooleanFormatter.BooleanToArabic(temp.Bail.IsMonthly) & vbNewLine
                End If
            Catch
            End Try
            EditFamCd.Dispose()
            BeginInvoke(New MethodInvoker(Sub() RadTextBox1.Text = strAll))
        End Using
    End Sub
    Private Sub RadGridView1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.SelectionChanged
        If Me.IsLoading Then
            lblStatus.Text = StrCount & " المحدد " & radDataGrid.SelectedRows.Count
            Exit Sub
        End If
        Dim id As Integer = 0
        Try
            If Not IsNothing(radDataGrid.CurrentRow) AndAlso TypeOf radDataGrid.CurrentRow Is GridViewGroupRowInfo Then
                Dim itm = CType(radDataGrid.CurrentRow, GridViewGroupRowInfo)
                If itm.HasChildRows() Then
                    For Each citm In itm.ChildRows
                        Try
                            id = CInt(citm.Cells("Family_ID").Value)
                            Exit For
                        Catch
                        End Try
                    Next
                End If
            End If
            If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
                id = CInt(radDataGrid.SelectedRows(0).Cells("Family_ID").Value)
            End If
        Catch
        End Try
        If id = 0 Then
            Exit Sub
        Else
            btnShowOrphans.Enabled = True
            GC.Collect()
        End If
        Dim t As New Threading.Thread(New Threading.ParameterizedThreadStart(AddressOf SetData))
        t.Start(id)
        'Me.Invoke(New FamilyRefreshDelegate(AddressOf SetData), New Object() {id})
        'radDataGrid.TableElement.FilterRowHeight = 30
        lblStatus.Text = StrCount & " المحدد " & radDataGrid.SelectedRows.Count
    End Sub
    Private Sub RadGridView1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.MouseEnter
        LangChanger.CurLang.SaveCurrentLanguage()
        LangChanger.CurLang.ChangeToArabic()
    End Sub

    Private Sub RadGridView1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.MouseLeave
        LangChanger.CurLang.ReturnToSavedLanguage()
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

    Private Sub mnuCollapseAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        radDataGrid.MasterTemplate.CollapseAllGroups()
    End Sub

    Private Sub mnuExpandAll_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs)
        radDataGrid.MasterTemplate.ExpandAllGroups()
    End Sub

    Private Sub radDataGrid_ContextMenuOpening(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.ContextMenuOpeningEventArgs) Handles radDataGrid.ContextMenuOpening
        e.ContextMenu = MainMnu.DropDown
    End Sub

    Private Sub mnuMakeABail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMakeABail.Click
        Dim Fid As Integer = 0
        Dim Fids As New Dictionary(Of Integer, GridViewRowInfo)
        If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
            For Each ros In radDataGrid.SelectedRows
                Fid = CInt(ros.Cells("Family_ID").Value)
                Dim FName As String = ros.Cells("FathName").Value.ToString()
                If Not Fids.ContainsKey(Fid) Then
                    Fids.Add(Fid, ros)
                End If
            Next
        Else
            If Not IsNothing(radDataGrid.CurrentRow) AndAlso TypeOf radDataGrid.CurrentRow Is GridViewGroupRowInfo Then
                Dim itm = CType(radDataGrid.CurrentRow, GridViewGroupRowInfo)
                If itm.HasChildRows() Then
                    For Each citm In itm.ChildRows
                        Fid = CInt(citm.Cells("Family_ID").Value)
                        If Not Fids.ContainsKey(Fid) Then
                            Fids.Add(Fid, citm)
                        End If
                        Exit For
                    Next
                End If
            End If
        End If
        Try
            If Fid = 0 OrElse Fids.Count = 0 Then Return
            Dim FamsIds() As Integer = Fids.Keys.ToArray()
            Dim BailClass As New Bails(FamsIds, True, My.Settings.BailsReplaceAll)
            BailClass.CancelFamiliesBails = My.Settings.CancelFamiliesBails
            BailClass.CancelOrphansBails = My.Settings.BailsCancelOrphansBails
            If Not mnuMakeABail.Text.Contains("غاء") Then
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

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) OrElse radDataGrid.SelectedRows.Count > 1 Then Exit Sub
            WindowsLauncher.LaunchNewFamilies()
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub btnShowOrphans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowOrphans.Click, SubSOrphans.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) Then Exit Sub
            Dim Ids As New ArrayList
            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Dim FamID As Integer = row.Cells("Family_ID").Value
                Dim orps() As Integer = Getter.GetFamilyOrphans(FamID)
                If Not IsNothing(orps) AndAlso orps.Count > 0 Then
                    Ids.AddRange(orps)
                End If
            Next
            If Ids.Count > 0 Then
                WindowsLauncher.LaunchOrphans(CType(Ids.ToArray(GetType(Integer)), Integer()))
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub btnShowMothers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowMothers.Click, SubSMothers.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) Then Exit Sub
            Dim Ids As New ArrayList()
            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Using Odb As New OrphanageDB.Odb
                    Dim FamID As Integer = row.Cells("Family_ID").Value
                    Dim temp As OrphanageClasses.Family = Getter.GetFamilyByID(FamID, Odb)
                    If IsNothing(temp) Then Continue For
                    If Not Ids.Contains(temp.Mother_ID) Then Ids.Add(temp.Mother_ID)
                    Odb.Dispose()
                End Using
            Next
            If Ids.Count > 0 Then
                WindowsLauncher.LaunchMothers(CType(Ids.ToArray(GetType(Integer)), Integer()))
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub btnShowFathers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowFathers.Click, SubSFAthers.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) Then Exit Sub
            Dim Ids As New ArrayList()
            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Using Odb As New OrphanageDB.Odb
                    Dim FamID As Integer = row.Cells("Family_ID").Value
                    Dim temp As OrphanageClasses.Family = Getter.GetFamilyByID(FamID, Odb)
                    If IsNothing(temp) Then Continue For
                    If Not Ids.Contains(temp.Father_ID) Then Ids.Add(temp.Father_ID)
                    Odb.Dispose()
                End Using
            Next
            If Ids.Count > 0 Then
                WindowsLauncher.LaunchFathers(CType(Ids.ToArray(GetType(Integer)), Integer()))
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub SubSBondsMen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubSBondsMen.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) Then Exit Sub
            Dim Ids As New ArrayList()
            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Dim FamID As Integer = row.Cells("Family_ID").Value
                Dim bonds_ids() As Integer = Getter.GetFamilyBondsman(FamID)
                If IsNothing(bonds_ids) Then Continue For
                For Each bond In bonds_ids
                    If Not Ids.Contains(bond) Then Ids.Add(bond)
                Next
            Next
            If Ids.Count > 0 Then
                WindowsLauncher.LaunchBondsMen(CType(Ids.ToArray(GetType(Integer)), Integer()))
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub SubSSupporters_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubSSupporters.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) Then Exit Sub
            Dim Ids As New ArrayList()
            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Dim FamID As Integer = row.Cells("Family_ID").Value
                Dim temp() As Integer = Getter.GetFamilySupporters(FamID)
                If IsNothing(temp) Then Continue For
                For Each sId In temp
                    If Not Ids.Contains(sId) Then
                        Ids.Add(sId)
                    End If
                Next
            Next
            If Ids.Count > 0 Then
                WindowsLauncher.LaunchSupporters(CType(Ids.ToArray(GetType(Integer)), Integer()))
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub btnColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColumn.Click
        radDataGrid.ColumnChooser.Text = "الأعمدة"
        radDataGrid.ColumnChooser.ColumnChooserControl.ColumnChooserElement.Text = "اسحب الأعمدة من و إلى الشبكة"
        radDataGrid.ColumnChooser.Show()
    End Sub

    Private Sub btnSetColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetColor.Click
        Try
            Dim ColDia As New ColorDialog()
            'ColorDc.ObjectTrackingEnabled = False
            If ColDia.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim i As Decimal = 0D
                Dim all As Decimal = radDataGrid.SelectedRows.Count
                For Each itm As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                    Using ColorDc As New OrphanageDB.Odb
                        Dim indexId As Integer = CInt(itm.Cells("Family_ID").Value)
                        Dim q = From qfath In ColorDc.Families Where qfath.ID = indexId Select qfath
                        Dim fam As OrphanageClasses.Family = q.FirstOrDefault()
                        If Not IsNothing(fam) Then
                            If ColDia.Color <> Color.White Then
                                fam.Color_Mark = ColDia.Color.ToArgb()
                            Else
                                fam.Color_Mark = Nothing
                            End If
                            ColorDc.SubmitChanges()
                            If IDSColors.ContainsKey(indexId) Then IDSColors.Remove(indexId)
                            Try
                                Updater.UpdatesFamily(fam)
                            Catch
                            End Try
                        End If
                        i += 1
                        Dim val As Integer
                        val = CInt((i / all) * 100D)
                        ProgressSate.ShowStatueProgress(val, "")
                        ColorDc.Dispose()
                    End Using
                Next
            End If
            ColDia.Dispose()
        Catch ex As Exception
            ProgressSate.ShowStatueProgress(100, "")
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True))
        End Try
    End Sub

    Private Sub btnExclud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExclud.Click
        Try
            Dim retD As DialogResult = MsgBox("لن تظهر هذه العائلة بأية عمليات بحث أو طباعة أو كفالات هل تريد المتابعة؟", MsgBoxStyle.Question Or MsgBoxStyle.YesNo)
            If retD = vbYes Then
                Using Odb As New OrphanageDB.Odb
                    'Odb.ObjectTrackingEnabled = False
                    Dim DeletedRows As New ArrayList()
                    For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                        Dim fam As OrphanageClasses.Family = Getter.GetFamilyByID(CType(row.Cells("Family_ID").Value, Integer), Odb)
                        If IsNothing(fam.IsExcluded) OrElse Not fam.IsExcluded Then
                            If Not Deleter.ExcludeFamily(fam.ID) Then
                                ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج استبعاد القيد " & Getter.GetFullName(fam.Father.Name) & " و " & Getter.GetFullName(fam.Mother.Name), True, True))
                                Exit Sub
                            Else
                                ExceptionsManager.RaiseOnStatus(New MyException("تم استبعاد القيد " & Getter.GetFullName(fam.Father.Name) & " و " & Getter.GetFullName(fam.Mother.Name), False, False))
                                DeletedRows.Add(row)
                            End If
                        Else
                            If Not Deleter.UnExcludeFamily(fam.ID) Then
                                ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج استرداد القيد " & Getter.GetFullName(fam.Father.Name) & " و " & Getter.GetFullName(fam.Mother.Name), True, True))
                                Exit Sub
                            Else
                                ExceptionsManager.RaiseOnStatus(New MyException("تم استرداد القيد " & Getter.GetFullName(fam.Father.Name) & " و " & Getter.GetFullName(fam.Mother.Name), False, False))
                            End If
                        End If
                    Next
                    If Not My.Settings.ShowHiddenObject Then
                        For Each row As Telerik.WinControls.UI.GridViewRowInfo In DeletedRows
                            radDataGrid.Rows.Remove(row)
                        Next
                    End If
                    Odb.Dispose()
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) OrElse radDataGrid.SelectedRows.Count <= 0 Then Exit Sub
            Dim fId As Integer = CInt(radDataGrid.SelectedRows(0).Cells("Family_ID").Value)
            Using Odb As New OrphanageDB.Odb
                Odb.ObjectTrackingEnabled = False
                Dim temp As OrphanageClasses.Family = Getter.GetFamilyByID(fId, Odb)
                If Not IsNothing(temp) Then
                    If frmLogin.CurrentUser.CanDelete AndAlso frmLogin.CurrentUser.CanAdd Then
                        Dim frm As New FrmFamily(fId)
                        frm.MdiParent = Application.OpenForms("FrmMain")
                        frm.Show()
                        WindowsLauncher.AllWindows.Add(frm)
                    End If
                End If
                Odb.Dispose()
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If IsNothing(radDataGrid.SelectedRows) OrElse radDataGrid.SelectedRows.Count <= 0 Then Return
        If Not frmLogin.CurrentUser.CanDelete Then
            ExceptionsManager.RaiseAccessDeniedException()
            Return
        End If
        Try
            Dim retD As DialogResult = MsgBox("هل تريد حذف عائلة/عائلات مع كل المتعلقات بهم؟", MsgBoxStyle.Question Or MsgBoxStyle.YesNo)
            If retD = vbYes Then
                Using Odb As New OrphanageDB.Odb
                    Odb.ObjectTrackingEnabled = False
                    Dim DeletedRows As New ArrayList()
                    For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                        Dim orph As OrphanageClasses.Family = Getter.GetFamilyByID(CType(row.Cells("Family_ID").Value, Integer), Odb)
                        If IsNothing(orph) Then
                            DeletedRows.Add(row)
                            Continue For
                        End If
                        If Not Deleter.DeleteFamilies(orph.ID) Then
                            ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج حذف القيد " & " عائلة " & Getter.GetFullName(orph.Father.Name) & " و " & Getter.GetFullName(orph.Mother.Name), True, True))
                            Exit Sub
                        End If
                        DeletedRows.Add(row)
                    Next
                    For Each row As Telerik.WinControls.UI.GridViewRowInfo In DeletedRows
                        row.IsVisible = False
                        radDataGrid.Rows.Remove(row)
                    Next
                    Odb.Dispose()
                End Using
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub SubSBills_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubSBills.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) Then Exit Sub
            Dim Ids As New System.Data.Linq.EntitySet(Of OrphanageClasses.Family)
            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Using Odb As New OrphanageDB.Odb
                    Dim FamID As Integer = row.Cells("Family_ID").Value
                    Dim temp As OrphanageClasses.Family = Getter.GetFamilyByID(FamID, Odb)
                    If IsNothing(temp) Then Continue For
                    Ids.Add(temp)
                    Odb.Dispose()
                End Using
            Next
            If Ids.Count > 0 Then
                WindowsLauncher.LaunchBills(Ids)
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub mnuMakeABill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMakeABill.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) Then Exit Sub
            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Using Odb As New OrphanageDB.Odb
                    Dim FamID As Integer = row.Cells("Family_ID").Value
                    Dim temp As OrphanageClasses.Family = Getter.GetFamilyByID(FamID, Odb)
                    If IsNothing(temp) Then Continue For
                    WindowsLauncher.LaunchNewBills(False, temp)
                End Using
                Exit For
            Next
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub mnuDrawABail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDrawABail.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) Then Exit Sub
            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Using Odb As New OrphanageDB.Odb
                    Dim FamID As Integer = row.Cells("Family_ID").Value
                    Dim temp As OrphanageClasses.Family = Getter.GetFamilyByID(FamID, Odb)
                    If IsNothing(temp) Then Continue For
                    If temp.IsBaild Then
                        Dim bal As OrphanageClasses.Bail = temp.Bail
                        If IsNothing(bal) Then Continue For
                        WindowsLauncher.LaunchNewBills(False, bal, temp)
                    End If
                End Using
                Exit For
            Next
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub
    Private Sub mnuAddNewOrphan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAddNewOrph.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) Then Exit Sub
            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Dim FamID As Integer = row.Cells("Family_ID").Value
                If frmLogin.CurrentUser.CanAdd Then
                    Dim frm As New FrmAddNewOrphanW(FamID)
                    frm.MdiParent = Me.MdiParent
                    frm.Show()
                    WindowsLauncher.AllWindows.Add(frm)
                Else
                    ExceptionsManager.RaiseAccessDeniedException()
                    Exit Sub
                End If
                Exit For
            Next
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub SubSBails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubSBails.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) AndAlso radDataGrid.SelectedRows().Count = 0 Then Exit Sub
            Dim fams As New System.Data.Linq.EntitySet(Of OrphanageClasses.Family)()
            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Using Odb As New OrphanageDB.Odb
                    Dim FamID As Integer = CInt(row.Cells("Family_ID").Value)
                    Dim fam As OrphanageClasses.Family = Getter.GetFamilyByID(FamID, Odb)
                    If Not fams.Contains(fam) Then
                        fams.Add(fam)
                    End If
                    Odb.Dispose()
                End Using
            Next

            If fams.Count > 0 Then
                WindowsLauncher.LaunchBails(fams)
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub radDataGrid_CellClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles radDataGrid.CellClick
        Me.IsLoading = True
        For Each index As Integer In _SeletedRows
            If index < 0 Then
                _SeletedRows.Clear()
            Else
                radDataGrid.Rows(index).IsSelected = True
            End If
        Next
        Me.IsLoading = False
        If Not IsNothing(e.Column) AndAlso e.Column.Name = "Select" Then
            Try
                Dim x = CBool(e.Value)
            Catch
                Exit Sub
            End Try
            If Not IsNothing(CBool(e.Value)) Then
                Try
                    If CBool(e.Value) Then
                        e.Row.IsSelected = False
                        e.Row.Cells(e.ColumnIndex).Value = False
                        _SeletedRows.Remove(e.RowIndex)
                    Else
                        e.Row.IsSelected = True
                        e.Row.Cells(e.ColumnIndex).Value = True
                        _SeletedRows.Add(e.RowIndex)
                    End If

                Catch
                End Try
            End If
        End If
    End Sub

    Dim IDSColors As New Dictionary(Of Integer, Color)
    Public obj As New Object
    Private Sub radDataGrid_RowFormatting(sender As System.Object, e As Telerik.WinControls.UI.RowFormattingEventArgs) Handles radDataGrid.RowFormatting
        SyncLock obj
            Layouts.DrawRowColorsFamilies(e, IDSColors, _IsClosing)
        End SyncLock
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Console.WriteLine("Start at " & Now)
        Dim Bailed = radDataGrid.Rows.OrderByDescending(Function(x) CBool(x.Cells("IsBailed").Value))
        For Each row In Bailed
            Try
                Dim Fid As Integer = CInt(row.Cells("Family_ID").Value)
                If _IsClosing Then
                    Control.CheckForIllegalCrossThreadCalls = True
                    Exit Sub
                End If
                Dim ColorM As Color
                If Not IDSColors.Keys.Contains(Fid) Then
                    If Not CBool(row.Cells("IsBailed").Value) AndAlso (Not IsNothing(row.Cells("Color_Mark").Value) AndAlso Not IsDBNull(row.Cells("Color_Mark").Value)) Then
                        ColorM = Color.FromArgb(row.Cells("Color_Mark").Value)
                    Else
                        ColorM = Getter.GetFamilyColor(Fid)
                    End If
                    SyncLock obj
                        IDSColors.Add(Fid, ColorM)
                    End SyncLock
                End If
            Catch
            End Try
        Next
        Console.WriteLine("exit at " & Now)
    End Sub
End Class
