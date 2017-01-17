Imports Itenso.TimePeriod
Imports ATDFormater
Imports System.IO
Imports Telerik.WinControls.UI
Public Class FrmBondsMen
    ' Dim Odb As New OrphanageDB.Odb()
#Region "UpdateRows"
    Private Sub DeletesBondsMan(ByVal bx As Integer)
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
    'GridViewTextBoxColumn1.Name = "BondManName"
    'GridViewDecimalColumn2.Name = "Onum"
    'GridViewTextBoxColumn2.Name = "Jop"
    'GridViewTextBoxColumn3.Name = "FullAddress"
    'GridViewDecimalColumn3.Name = "IdentityCard_ID"
    'GridViewDecimalColumn4.Name = "Income"
    'GridViewDateTimeColumn1.Name = "RegDate"
    'GridViewDecimalColumn5.Name = "Color_Mark"
    'GridViewTextBoxColumn4.Name = "Note"
    Private Sub AddNewBondsMan(ByVal Bond_ID As Integer)
        Dim xx As GridViewRowInfo
        Try
            xx = radDataGrid.Rows.AddNew()
        Catch ex As Exception
            Return
        End Try
        Try
            Using Odb As New OrphanageDB.Odb
                Odb.ObjectTrackingEnabled = False
                Dim q = From bond In Odb.BondsMans Join nam In Odb.Names On bond.Name_ID Equals nam.ID
                        Join add In Odb.Addresses On add.ID Equals bond.Address_ID
                        Where bond.ID = Bond_ID
                        Select oBondsMan = bond, oBName = nam, oBAddress = add

                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    Dim bx = q.FirstOrDefault()
                    xx.Cells("ID").Value = bx.oBondsMan.ID
                    xx.Cells("BondManName").Value = Getter.GetFullName(bx.oBName)
                    xx.Cells("Onum").Value = Getter.GetBondsManOrphansNum(Bond_ID)
                    xx.Cells("FullAddress").Value = Getter.GetAddress(bx.oBAddress)
                    If bx.oBondsMan.IdentityCard_ID.HasValue Then
                        xx.Cells("IdentityCard_ID").Value = bx.oBondsMan.IdentityCard_ID.Value
                    End If
                    If bx.oBondsMan.Income.HasValue Then
                        xx.Cells("Income").Value = bx.oBondsMan.Income.Value
                    End If
                    xx.Cells("RegDate").Value = bx.oBondsMan.RegDate
                    xx.Cells("Color_Mark").Value = bx.oBondsMan.Color_Mark
                    xx.Cells("Note").Value = bx.oBondsMan.Note
                    If My.Settings.UseColors Then
                        Dim ColorM As Long = -102
                        If bx.oBondsMan.Color_Mark.HasValue Then
                            ColorM = bx.oBondsMan.Color_Mark.Value
                        End If
                        If ColorM <> -102 Then
                            For Each cel As GridViewCellInfo In xx.Cells
                                cel.Style.CustomizeFill = True
                                cel.Style.DrawFill = True
                                cel.Style.ForeColor = Color.FromArgb(CInt(ColorM))
                                cel.Style.BackColor = Nothing
                            Next
                        End If
                    End If
                End If
                Odb.Dispose()
            End Using
        Catch
        End Try
    End Sub
    Private Sub UpdatesBondsMan(ByVal Bond_ID As Integer)

        Dim ret = radDataGrid.Rows.Where(Function(x) CInt(x.Cells("ID").Value) = Bond_ID).FirstOrDefault()

        If Not IsNothing(ret) Then
            Dim xx As GridViewRowInfo = ret

            'For Each xx In radDataGrid.Rows
            Dim id1 As Integer = CInt(xx.Cells("ID").Value)

            If id1 = Bond_ID Then
                Try
                    Using Odb As New OrphanageDB.Odb
                        Odb.ObjectTrackingEnabled = False
                        Dim q = From bond In Odb.BondsMans Join nam In Odb.Names On bond.Name_ID Equals nam.ID
                                Join add In Odb.Addresses On add.ID Equals bond.Address_ID
                                Where bond.ID = Bond_ID
                                Select oBondsMan = bond, oBName = nam, oBAddress = add

                        If Not IsNothing(q) AndAlso q.Count > 0 Then
                            Dim bx = q.FirstOrDefault()
                            xx.Cells("ID").Value = bx.oBondsMan.ID
                            xx.Cells("BondManName").Value = Getter.GetFullName(bx.oBName)
                            xx.Cells("Onum").Value = Getter.GetBondsManOrphansNum(Bond_ID)
                            xx.Cells("FullAddress").Value = Getter.GetAddress(bx.oBAddress)
                            If bx.oBondsMan.IdentityCard_ID.HasValue Then
                                xx.Cells("IdentityCard_ID").Value = bx.oBondsMan.IdentityCard_ID.Value
                            End If
                            If bx.oBondsMan.Income.HasValue Then
                                xx.Cells("Income").Value = bx.oBondsMan.Income.Value
                            End If
                            xx.Cells("RegDate").Value = bx.oBondsMan.RegDate
                            xx.Cells("Color_Mark").Value = bx.oBondsMan.Color_Mark
                            xx.Cells("Note").Value = bx.oBondsMan.Note
                            If IDSColors.ContainsKey(Bond_ID) Then IDSColors.Remove(Bond_ID)
                        End If
                        Odb.Dispose()
                        'Exit For
                    End Using
                Catch
                    'Exit For
                End Try
            End If
            Application.DoEvents()
            'Next
        End If
    End Sub
#End Region

    Dim IDSColors As New Dictionary(Of Integer, Color)
    Private StrCount As String = ""
    Private ids() As Integer
    Private _IsReplaceState As Boolean = False
    Private RepIdA As Integer = -1, RepIdB As Integer = -1
    Dim ViewdRows As New ArrayList
    Private _isClosing As Boolean = False
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
            If Not IsNothing(Ids) Then
                If My.Settings.ShowHiddenObject Then
                    Me.BondsMenTableAdapter.Fill(Me.OrphansDBDataSet.BondsMen)
                Else
                    Me.BondsMenTableAdapter.Fill(Me.OrphansDBDataSet.BondsMen)
                End If
                Dim ttt = Me.OrphansDBDataSet.BondsMen.Where(Function(x) Ids.Contains(x.ID))
                Me.radDataGrid.DataSource = ttt.AsDataView()
            End If
            If radDataGrid.RowCount > 0 Then
                StrCount = "العدد الكلي " & radDataGrid.RowCount
                lblStatus.Text = StrCount
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim Row As Telerik.WinControls.UI.GridViewDataRowInfo = radDataGrid.SelectedRows(0)
        Dim frm As New FrmBondsMan(CType(Row.Cells("ID").Value, Integer))
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.OK Then
            Me.UpdatesBondsMan(CInt(Row.Cells("ID").Value))
        End If
        frm.Dispose()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        If Not frmLogin.CurrentUser.CanDelete Then
            ExceptionsManager.RaiseAccessDeniedException()
            Return
        End If
        Try
            Dim retD As DialogResult = MsgBox("هل تريد حذف معيل/معيلين مع كل المتعلقات بهم؟", MsgBoxStyle.Question Or MsgBoxStyle.YesNo)
            If retD = vbYes Then
                Dim DeletedRows As New ArrayList()
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                    Using Odb As New OrphanageDB.Odb
                        Odb.ObjectTrackingEnabled = False
                        Dim bond As OrphanageClasses.BondsMan = Getter.GetBondsManByID(CType(row.Cells("ID").Value, Integer), Odb)
                        If IsNothing(bond) Then
                            DeletedRows.Add(row)
                            Continue For
                        End If
                        If Not Deleter.DeleteBondsMan(bond.ID) Then
                            ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج حذف القيد " & Getter.GetFullName(bond.Name), True, True))
                            Exit Sub
                        End If
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
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub MnuColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColumn.Click
        radDataGrid.ColumnChooser.Text = "الأعمدة"
        radDataGrid.ColumnChooser.ColumnChooserControl.ColumnChooserElement.Text = "اسحب الأعمدة من و إلى الشبكة"
        radDataGrid.ColumnChooser.Show()
    End Sub

    Private Sub radDataGrid_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.SelectionChanged
        If _IsReplaceState = True Then
            If RepIdA > -1 Then
                RepIdB = CInt(radDataGrid.SelectedRows(0).Cells("ID").Value)
                If ReplaceOrphans(RepIdA, RepIdB) Then
                    ExceptionsManager.RaiseOnStatus(New MyException("تم نقل إعالة الأيتام ", False, True))
                    Me.UpdatesBondsMan(RepIdA)
                    Me.UpdatesBondsMan(RepIdB)
                Else
                    ExceptionsManager.RaiseOnStatus(New MyException("لم يتم عمل شيء", True, True))
                End If
                btnShowMothers.Enabled = True
                btnColumn.Enabled = True
                btnDelete.Enabled = True
                btnEdit.Enabled = True
                btnSetColor.Enabled = True
                btnShowOrphans.Enabled = True
                btnReplaceOrphans.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off
                _IsReplaceState = False
                RepIdA = -1
                RepIdB = -1
            End If
        End If
        If radDataGrid.SelectedRows.Count = 1 AndAlso Not IsNothing(radDataGrid.SelectedRows(0).Cells("ID").Value) Then
            Dim Fid As Integer = CType(radDataGrid.SelectedRows(0).Cells("ID").Value, Integer)
            If Getter.GetBondsManOrphansNum(Fid) > 0 Then
                btnShowOrphans.Enabled = True
                btnShowMothers.Enabled = True
                btnReplaceOrphans.Enabled = True
            Else
                btnShowOrphans.Enabled = False
                btnReplaceOrphans.Enabled = False
            End If
        End If
        'radDataGrid.TableElement.FilterRowHeight = 30
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
                        Dim q = From qfath In Odb.BondsMans Where qfath.ID = indexId Select qfath
                        Dim fath As OrphanageClasses.BondsMan = q.FirstOrDefault()
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
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True))
        End Try
    End Sub

    Private Sub FrmFathers_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If My.Settings.SaveWindowsState Then
            Layouts.SaveFormLayout(Me)
        End If
        If My.Settings.SaveGridState Then
            radDataGrid.SaveLayout("BondsMen.Xaml")
        End If
        _isClosing = True
    End Sub



    Private Sub FrmFathers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Me.MdiParent) Then
            Me.MdiParent = Application.OpenForms("FrmMain")
        End If
        AddHandler Updater.NewBondsMan, AddressOf AddNewBondsMan
        AddHandler Updater.UpdateBondsMan, AddressOf UpdatesBondsMan
        AddHandler Updater.DeleteBondsMan, AddressOf DeletesBondsMan
        If Not IsNothing(ids) AndAlso ids.Length > 0 Then
            LoadData(ids)
        Else
            If My.Settings.ShowHiddenObject Then
                Me.BondsMenTableAdapter.Fill(Me.OrphansDBDataSet.BondsMen)
            Else
                Me.BondsMenTableAdapter.Fill(Me.OrphansDBDataSet.BondsMen)
            End If
            'LoadData()
        End If
        Layouts.LoadFormLayout(Me)
        If System.IO.File.Exists("BondsMen.Xaml") AndAlso My.Settings.SaveGridState Then
            radDataGrid.LoadLayout("BondsMen.Xaml")
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
        CType(radDataGrid.Columns("RegDate"), Telerik.WinControls.UI.GridViewDateTimeColumn).Format = DateTimePickerFormat.Custom
        CType(radDataGrid.Columns("RegDate"), Telerik.WinControls.UI.GridViewDateTimeColumn).FormatString = "{0:" + My.Settings.GeneralDateFormat + "}"
    End Sub

    Private Sub btnAddOrphan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub radDataGrid_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles radDataGrid.CellDoubleClick
        If e.RowIndex > 0 AndAlso e.ColumnIndex > 0 Then
            btnEdit_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub radDataGrid_CreateCell(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCreateCellEventArgs) Handles radDataGrid.CreateCell
        If e.CellType.FullName.Contains("FilterCellElement") Then
            Dim cell As New GridFilterCellElement(e.Column, e.Row)
            cell.FilterButton.Enabled = False
            e.CellElement = cell
            e.CellType = cell.GetType()
        End If
    End Sub

    Private Sub radDataGrid_CreateRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCreateRowEventArgs) Handles radDataGrid.CreateRow
        If e.RowType.FullName.Contains("SummaryRowElement") Then
            If e.RowInfo.Height < 40 Then
                e.RowInfo.Height += 40
            End If
        End If
    End Sub

    Private Function ReplaceOrphans(ByVal idA As Integer, ByVal IdB As Integer) As Boolean
        Try
            Using Odb As New OrphanageDB.Odb
                Dim q = From bond In Odb.BondsMans Where bond.ID = idA Select bond
                Odb.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, q)
                If Not IsNothing(q) AndAlso q.Count = 1 Then
                    Dim BondsA As OrphanageClasses.BondsMan = q.FirstOrDefault()
                    Dim BondsB As OrphanageClasses.BondsMan = Getter.GetBondsManByID(IdB, Odb)
                    Using tr = New Transactions.TransactionScope()
                        If Not IsNothing(BondsA) AndAlso Not IsNothing(BondsB) Then
                            Dim qAOrph = From ors In Odb.Orphans Where ors.BondsMan_ID = idA Select ors
                            If Not IsNothing(qAOrph) AndAlso qAOrph.Count > 0 Then
                                For Each orph As OrphanageClasses.Orphan In qAOrph
                                    orph.BondsMan_ID = BondsB.ID
                                    Odb.SubmitChanges()
                                Next
                            Else
                                ExceptionsManager.RaiseOnStatus(New MyException("يجب يكون معيلاً لأيتام!!", True, False))
                                Return False
                            End If
                        Else
                            Return False
                        End If
                        tr.Complete()
                        Return True
                    End Using
                Else
                    Return False
                End If
                Odb.Dispose()
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True))
            Return False
        End Try
        Return True
    End Function

    Private Sub btnReplaceOrphans_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles btnReplaceOrphans.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            If radDataGrid.SelectedRows.Count = 1 Then
                btnShowMothers.Enabled = False
                btnColumn.Enabled = False
                btnDelete.Enabled = False
                btnEdit.Enabled = False
                btnSetColor.Enabled = False
                btnShowOrphans.Enabled = False
                RepIdA = CInt(radDataGrid.SelectedRows(0).Cells("ID").Value)
                _IsReplaceState = True
            Else
                ExceptionsManager.RaiseOnStatus(New MyException("قم بتحديد اسم واحد فقط", True, True))
            End If
        Else
            btnShowMothers.Enabled = True
            btnColumn.Enabled = True
            btnDelete.Enabled = True
            btnEdit.Enabled = True
            btnSetColor.Enabled = True
            btnShowOrphans.Enabled = True
            _IsReplaceState = False
            RepIdA = -1
            RepIdB = -1
        End If
    End Sub

    Private Sub btnShowOrphans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowOrphans.Click
        If IsNothing(radDataGrid.SelectedRows) OrElse radDataGrid.SelectedRows.Count <= 0 Then Return
        Try
            Dim Bonds As New ArrayList
            For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                Dim orps() As Integer = Getter.GetBondsManOrphans(CType(row.Cells("ID").Value, Integer))
                If Not IsNothing(orps) Then
                    Bonds.AddRange(orps)
                End If
            Next
            If Bonds.Count > 0 Then
                WindowsLauncher.LaunchOrphans(CType(Bonds.ToArray(GetType(Integer)), Integer()))
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try

    End Sub

    Private Sub btnShowMothers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowMothers.Click
        If IsNothing(radDataGrid.SelectedRows) OrElse radDataGrid.SelectedRows.Count <= 0 Then Return
        Try
            Dim Mothers_Ids As New ArrayList
            For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                Dim moths() As Integer = Getter.GetBondsmanMothers(CType(row.Cells("ID").Value, Integer))
                If Not IsNothing(moths) Then
                    For Each m_Id In moths
                        If Not Mothers_Ids.Contains(m_Id) Then Mothers_Ids.Add(m_Id)
                    Next
                End If
            Next
            If Mothers_Ids.Count > 0 Then
                WindowsLauncher.LaunchMothers(CType(Mothers_Ids.ToArray(GetType(Integer)), Integer()))
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub radDataGrid_MouseEnter(sender As System.Object, e As System.EventArgs) Handles radDataGrid.MouseEnter
        LangChanger.CurLang.SaveCurrentLanguage()
        LangChanger.CurLang.ChangeToArabic()
    End Sub

    Private Sub radDataGrid_MouseLeave(sender As System.Object, e As System.EventArgs) Handles radDataGrid.MouseLeave
        LangChanger.CurLang.ReturnToSavedLanguage()
    End Sub

    Private Sub radDataGrid_GroupByChanged(sender As System.Object, e As Telerik.WinControls.UI.GridViewCollectionChangedEventArgs) Handles radDataGrid.GroupByChanged
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

    Private Sub radDataGrid_RowFormatting(sender As System.Object, e As Telerik.WinControls.UI.RowFormattingEventArgs) Handles radDataGrid.RowFormatting
        Layouts.DrawRowColors(e, IDSColors, "ID", "Color_Mark", _isClosing)
    End Sub
End Class
