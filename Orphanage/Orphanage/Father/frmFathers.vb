Imports Itenso.TimePeriod
Imports ATDFormater
Imports System.IO
Imports Telerik.WinControls.UI
Imports System.ComponentModel

Public Class FrmFathers
    'Dim Odb As New OrphanageDB.Odb()
    Private StrCount As String = ""
    Private ids() As Integer
    Private ShowExcluded As Boolean = False
    Dim IsLoading As Boolean = True
    Dim IDSColors As New Dictionary(Of Integer, Color)
#Region "UpdateRows"
    Private Sub DeletesFather(ByVal bx As Integer)
        radDataGrid.TableElement.BeginUpdate()
        For Each row In radDataGrid.Rows
            Dim id As Integer = CInt(row.Cells("Father_Id").Value)
            If id = bx Then
                row.IsVisible = False
                Exit For
            End If
            Application.DoEvents()
        Next
        radDataGrid.TableElement.EndUpdate()
    End Sub
    Private Function AddNewFather(ByVal bx As OrphanageClasses.Father) As Integer
        Dim xx As GridViewRowInfo
        Try
            xx = radDataGrid.Rows.AddNew()
        Catch ex As Exception
            Return -1
        End Try
        Try
            xx.Cells("Father_Id").Value = bx.ID
            xx.Cells("Birthday").Value = bx.Birthday
            xx.Cells("Dieday").Value = bx.Dieday
            Dim OrphNum As Integer = Getter.GetFatherOrphansNum(bx.ID)
            Dim WifesNameStr As String = ""
            Try
                Using Odb As New OrphanageDB.Odb
                    Dim qFname = From nm In Odb.Names Where nm.ID = bx.Name_ID Select nm
                    xx.Cells("FatherName").Value = Getter.GetFullName(qFname.FirstOrDefault())
                    Dim qFmas = From fams In Odb.Families Where fams.Father_ID = bx.ID Select fams
                    For Each fam In qFmas
                        Dim famId As Integer = fam.ID
                        Dim MothID As Integer = fam.Mother_ID
                        Dim qM = From Mo In Odb.Mothers, Nmo In Odb.Names Where Mo.Name_ID = Nmo.ID AndAlso
                                 MothID = Mo.ID
                                 Select Nmo
                        If WifesNameStr.Length > 0 Then
                            WifesNameStr += " - " + Getter.GetFullName(qM.FirstOrDefault())
                        Else
                            WifesNameStr += Getter.GetFullName(qM.FirstOrDefault())
                        End If
                    Next
                    Odb.Dispose()
                End Using
            Catch
                OrphNum = -1
            End Try
            xx.Cells("MotherName").Value = WifesNameStr
            xx.Cells("Onum").Value = OrphNum
            xx.Cells("Jop").Value = bx.Jop
            xx.Cells("IdentityCard_ID").Value = bx.IdentityCard_ID
            xx.Cells("RegDate").Value = bx.RegDate
            xx.Cells("DeathResone").Value = bx.DeathResone
            xx.Cells("Photo").Value = bx.Photo
            If My.Settings.UseColors Then
                Dim ColorM As Long = -102
                If bx.Color_Mark.HasValue Then
                    ColorM = CLng(bx.Color_Mark.Value)
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
        Catch ex As Exception
            Return -1
        End Try
        Return -1
    End Function
    Private Sub UpdatesFather(ByVal bx As OrphanageClasses.Father)

        Dim ret = radDataGrid.Rows.Where(Function(x) CInt(x.Cells("Father_Id").Value) = bx.ID).FirstOrDefault()

        If Not IsNothing(ret) Then
            Dim xx As GridViewRowInfo = ret
            Dim id1 As Integer = CInt(xx.Cells("Father_Id").Value)
            If id1 = bx.ID Then
                Try
                    xx.Cells("Father_Id").Value = bx.ID
                    xx.Cells("FatherName").Value = Getter.GetFullName(bx.Name)
                    xx.Cells("Birthday").Value = bx.Birthday
                    xx.Cells("Dieday").Value = bx.Dieday
                    Dim OrphNum As Integer = Getter.GetFatherOrphansNum(bx.ID)
                    Dim WifesNameStr As String = ""
                    Try
                        Using Odb As New OrphanageDB.Odb
                            Odb.ObjectTrackingEnabled = False
                            For Each fam In bx.Families
                                Dim famId As Integer = fam.ID
                                Dim MothID As Integer = fam.Mother_ID
                                Dim qM = From Mo In Odb.Mothers, Nmo In Odb.Names Where Mo.Name_ID = Nmo.ID AndAlso
                                         MothID = Mo.ID
                                         Select Nmo
                                If WifesNameStr.Length > 0 Then
                                    WifesNameStr += " - " + Getter.GetFullName(qM.FirstOrDefault())
                                Else
                                    WifesNameStr += Getter.GetFullName(qM.FirstOrDefault())
                                End If
                            Next
                        End Using
                    Catch
                        OrphNum = -1
                    End Try
                    xx.Cells("MotherName").Value = WifesNameStr
                    xx.Cells("Onum").Value = OrphNum
                    xx.Cells("Jop").Value = bx.Jop
                    xx.Cells("IdentityCard_ID").Value = bx.IdentityCard_ID
                    xx.Cells("RegDate").Value = bx.RegDate
                    xx.Cells("DeathResone").Value = bx.DeathResone
                    xx.Cells("Photo").Value = bx.Photo
                    If bx.Color_Mark.HasValue Then
                        xx.Cells("Color_Mark").Value = bx.Color_Mark.Value
                    Else
                        xx.Cells("Color_Mark").Value = Nothing
                    End If
                    If IDSColors.ContainsKey(bx.ID) Then IDSColors.Remove(bx.ID)
                Catch ex As Exception

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
        Me.Font = fon
        radDataGrid.Font = fon
        radDataGrid.PrintStyle.CellFont = fon
        radDataGrid.Refresh()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.ShowExcluded = My.Settings.ShowHiddenObject
    End Sub

    Public Sub New(ByVal _ids() As Integer)
        InitializeComponent()
        Me.ids = _ids
        Me.ShowExcluded = My.Settings.ShowHiddenObject
    End Sub
    Private Sub LoadData(Optional ByVal Ids() As Integer = Nothing)
        Try
            If IsNothing(Ids) OrElse Ids.Count <= 0 Then
                Return
            End If
            'RemoveHandler radDataGrid.ViewCellFormatting, AddressOf radDataGrid_ViewCellFormatting
            If My.Settings.ShowHiddenObject Then
                Me.FathersTableAdapter.Fill(Me.OrphansDBDataSet.Fathers)
            Else
                Me.FathersTableAdapter.FillByUnExcluded(Me.OrphansDBDataSet.Fathers)
            End If
            Dim ttt = Me.OrphansDBDataSet.Fathers.Where(Function(x) Ids.Contains(x.Father_Id))
            Me.radDataGrid.DataSource = ttt.AsDataView()
            'AddHandler radDataGrid.ViewCellFormatting, AddressOf radDataGrid_ViewCellFormatting
            'Using Odb As New OrphanageDB.Odb
            '    Odb.ObjectTrackingEnabled = False
            '    Dim i As Integer = 0
            '    Dim all As Integer = 0
            '    Dim PerValue = 0, LastPerValue As Integer = 0
            '    Dim Photo As Image = Nothing
            '    Dim q = From fath In Odb.Fathers _
            '            Select fath, fath.Name
            '    all = q.Count
            '    If radDataGrid.Rows.Count > 0 Then radDataGrid.Rows.Clear()
            '    radDataGrid.TableElement.BeginUpdate()
            '    For Each fath In q
            '        Dim Fath_ID As Integer = fath.fath.ID
            '        PerValue = Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100))
            '        If Not Ids.Contains(Fath_ID) Then
            '            If i = all - 1 Then
            '                If System.IO.File.Exists("FathersLayout.Xaml") AndAlso My.Settings.SaveGridState Then
            '                    radDataGrid.LoadLayout("FathersLayout.Xaml")
            '                End If
            '            End If
            '            i += 1
            '            If LastPerValue <> PerValue Then
            '                ProgressSate.ShowStatueProgress(PerValue, "")
            '                LastPerValue = PerValue
            '            End If
            '            Continue For
            '        End If
            '        Dim OrphanNum As Byte = Getter.GetFatherOrphansNum(Fath_ID)
            '        If Not IsNothing(fath.fath.Photo) Then
            '            Photo = Getter.GetThumbImage(fath.fath.Photo)
            '        End If
            '        AddNewFather(fath.fath)
            '        'load Grid layout
            '        If i = all - 1 Then
            '            If System.IO.File.Exists("FathersLayout.Xaml") AndAlso My.Settings.SaveGridState Then
            '                radDataGrid.LoadLayout("FathersLayout.Xaml")
            '            End If
            '        End If

            '        i += 1
            '        If LastPerValue <> PerValue Then
            '            ProgressSate.ShowStatueProgress(PerValue, "")
            '            LastPerValue = PerValue
            '        End If
            '    Next
            '    If Not IsNothing(Photo) Then Photo.Dispose()
            '    GC.Collect()
            '    radDataGrid.TableElement.EndUpdate()
            '    Odb.Dispose()
            'End Using
            If System.IO.File.Exists("FathersLayout.Xaml") AndAlso My.Settings.SaveGridState Then
                radDataGrid.LoadLayout("FathersLayout.Xaml")
            End If
            ProgressSate.ShowStatueProgress(100, "")
            If radDataGrid.RowCount > 0 Then
                StrCount = "العدد الكلي " & radDataGrid.RowCount
                lblStatus.Text = StrCount
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try

    End Sub

    Public Overloads Sub Refresh(ByRef id As Integer)
        Try
            Using Odb As New OrphanageDB.Odb
                For Each row In radDataGrid.Rows
                    If CInt(row.Cells("Father_Id").Value) = id Then
                        Dim Fath As OrphanageClasses.Father = Getter.GetFatherByID(id, Odb)
                        Dim WifesName As String = ""
                        Dim OrphanNum As Byte = 0
                        Dim ChildrenNum As Byte = 0
                        For Each fam In Fath.Families
                            If Not fam.IsExcluded Then
                                OrphanNum += fam.Orphans.Count
                                ChildrenNum += fam.UnOrphans.Count
                                If WifesName.Length > 0 Then
                                    WifesName = WifesName & "," & Getter.GetFullName(fam.Mother.Name)
                                Else
                                    WifesName = Getter.GetFullName(fam.Mother.Name)
                                End If
                            End If
                        Next
                        If WifesName.Length = 0 Then Return
                        Dim Photo As Image = Nothing
                        If Not IsNothing(Fath.Photo) Then
                            Photo = Getter.GetThumbImage(Fath.Photo)
                        End If
                        Try
                            row.Cells("Photo").Value = Photo
                        Catch
                            Try
                                Dim ztt As New MemoryStream()
                                Photo.Save(ztt, System.Drawing.Imaging.ImageFormat.Jpeg)
                                row.Cells("Photo").Value = ztt.ToArray()
                            Catch
                            End Try
                        End Try
                        row.Cells("FatherName").Value = Getter.GetFullName(Fath.Name)
                        row.Cells("Birthday").Value = Fath.Birthday
                        row.Cells("MotherName").Value = WifesName
                        row.Cells("Onum").Value = OrphanNum
                        row.Cells("IdentityCard_ID").Value = Fath.IdentityCard_ID
                        row.Cells("Jop").Value = Fath.Jop
                        row.Cells("RegDate").Value = Fath.RegDate
                        row.Cells("DeathResone").Value = Fath.DeathResone
                        row.Cells("Dieday").Value = Fath.Dieday
                        If Not IsNothing(Photo) Then Photo.Dispose()
                        If Fath.Color_Mark.HasValue Then
                            If IDSColors.ContainsKey(id) Then IDSColors.Remove(id)
                        End If
                        Exit For
                    End If
                Next
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim Row As Telerik.WinControls.UI.GridViewDataRowInfo = radDataGrid.SelectedRows(0)
        Dim frm As New FrmFather(CType(Row.Cells("Father_Id").Value, Integer))
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.OK Then
            Me.Refresh(CInt(Row.Cells("Father_Id").Value))
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
            Using Odb As New OrphanageDB.Odb
                Dim retD As DialogResult = MsgBox("هل تريد حذف أب/آباء مع كل المتعلقات بهم؟", MsgBoxStyle.Question Or MsgBoxStyle.YesNo)
                If retD = vbYes Then
                    Dim DeletedRows As New ArrayList()
                    For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                        Dim fath As OrphanageClasses.Father = Getter.GetFatherByID(CType(row.Cells("Father_Id").Value, Integer), Odb)
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
                    Next
                    For Each row As Telerik.WinControls.UI.GridViewRowInfo In DeletedRows
                        row.IsVisible = False
                        radDataGrid.Rows.Remove(row)
                    Next
                End If
            End Using
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
        If Me.IsLoading Then Exit Sub
        If radDataGrid.SelectedRows.Count = 1 AndAlso Not IsNothing(radDataGrid.SelectedRows(0).Cells("Father_Id").Value) Then
            Dim Fid As Integer = CType(radDataGrid.SelectedRows(0).Cells("Father_Id").Value, Integer)
            Dim hasCild As Boolean = False
            Using odb As New OrphanageDB.Odb
                Dim Fath As OrphanageClasses.Father = Getter.GetFatherByID(Fid, odb)
                If Not IsNothing(Fath) Then
                    For Each fam As OrphanageClasses.Family In Fath.Families
                        If Not fam.IsBaild Then
                            BtnBail.ToolTipText = "كفالة"
                            BtnBail.Image = My.Resources.Bail
                            'Continue For
                        Else
                            BtnBail.ToolTipText = "الغاء الكفالة"
                            BtnBail.Image = My.Resources.CancelBail
                        End If
                        If My.Settings.ShowHiddenObject Then
                            If fam.Orphans.Count() > 0 Then
                                hasCild = True
                            End If
                        Else
                            If fam.Orphans.Where(Function(c) c.IsExcluded = False OrElse Not c.IsExcluded.HasValue).Count() > 0 Then
                                hasCild = True
                                'Continue For
                            End If
                        End If
                        If fam.IsExcluded Then
                            btnExclud.ToolTipText = "إلغاء الاستبعاد"
                        Else
                            btnExclud.ToolTipText = "استبعاد"
                        End If
                    Next
                End If
            End Using
            btnShowOrphans.Enabled = hasCild
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
                        Dim indexId As Integer = CInt(itm.Cells("Father_Id").Value)
                        Dim q = From qfath In Odb.Fathers Where qfath.ID = indexId Select qfath
                        Dim fath As OrphanageClasses.Father = q.FirstOrDefault()
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
                                UpdatesFather(fath)
                            Catch

                            End Try
                        End If
                        Odb.Dispose()
                    End Using
                    i += 1
                    Dim val As Integer
                    val = CInt((i / all) * 100D)
                    ProgressSate.ShowStatueProgress(val, "")
                Next
            End If
            ColDia.Dispose()
        Catch ex As Exception
            ProgressSate.ShowStatueProgress(100, "")
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True))
        End Try
    End Sub

    Private Sub FrmFathers_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        radDataGrid.SaveLayout("FathersLayout.Xaml")
        Layouts.SaveFormLayout(Me)
    End Sub

    Private Sub btnExclud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExclud.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        Try
            Dim retD As DialogResult = MsgBox("لن تظهر هذه العائلة بأية عمليات بحث أو طباعة أو كفالات هل تريد المتابعة؟", MsgBoxStyle.Question Or MsgBoxStyle.YesNo)
            If retD = vbYes Then
                Dim DeletedRows As New ArrayList()
                Using Odb As New OrphanageDB.Odb
                    For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                        Dim fath As OrphanageClasses.Father = Getter.GetFatherByID(CType(row.Cells("ID").Value, Integer), Odb)
                        Dim Fams() As OrphanageClasses.Family = fath.Families.ToArray()
                        For Each fam As OrphanageClasses.Family In Fams
                            If Not fam.IsExcluded Then
                                If Not Deleter.ExcludeFamily(fam.ID) Then
                                    ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج استبعاد القيد " & Getter.GetFullName(fath.Name), True, True))
                                    Exit Sub
                                Else
                                    ExceptionsManager.RaiseOnStatus(New MyException("تم استبعاد القيد " & Getter.GetFullName(fath.Name), False, False))
                                    DeletedRows.Add(row)
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
                    Next
                End Using
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In DeletedRows
                    radDataGrid.Rows.RemoveAt(row.Index)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub FrmFathers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(ids) OrElse ids.Length <= 0 Then
            If My.Settings.ShowHiddenObject Then
                Me.FathersTableAdapter.Fill(Me.OrphansDBDataSet.Fathers)
            Else
                Me.FathersTableAdapter.FillByUnExcluded(Me.OrphansDBDataSet.Fathers)
            End If
            If My.Settings.SaveGridState AndAlso IO.File.Exists("FathersLayout.Xaml") Then
                radDataGrid.LoadLayout("FathersLayout.Xaml")
            End If
            If My.Settings.SaveWindowsState Then
                Layouts.LoadFormLayout(Me)
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
        AddHandler Updater.NewFather, AddressOf AddNewFather
        AddHandler Updater.UpdateFather, AddressOf UpdatesFather
        AddHandler Updater.DeleteFather, AddressOf DeletesFather
        If radDataGrid.RowCount > 0 Then
            StrCount = "العدد الكلي " & radDataGrid.RowCount
            lblStatus.Text = StrCount
        End If
        If IsNothing(Me.MdiParent) Then
            Me.MdiParent = Application.OpenForms("FrmMain")
        End If
        'radDataGrid.BestFitColumns(Telerik.WinControls.UI.BestFitColumnMode.AllCells)
        Layouts.LoadFormLayout(Me)
        Me.IsLoading = False
        Try
            CType(radDataGrid.Columns("Birthday"), Telerik.WinControls.UI.GridViewDateTimeColumn).Format = DateTimePickerFormat.Custom
            CType(radDataGrid.Columns("Birthday"), Telerik.WinControls.UI.GridViewDateTimeColumn).FormatString = "{0:" + My.Settings.GeneralDateFormat + "}"
            CType(radDataGrid.Columns("Dieday"), Telerik.WinControls.UI.GridViewDateTimeColumn).Format = DateTimePickerFormat.Custom
            CType(radDataGrid.Columns("Dieday"), Telerik.WinControls.UI.GridViewDateTimeColumn).FormatString = "{0:" + My.Settings.GeneralDateFormat + "}"
        Catch
        End Try
        For Each col In radDataGrid.Columns
            If TypeOf (col) Is GridViewImageColumn Then
                col.ImageLayout = ImageLayout.Zoom
            End If
        Next
    End Sub

    Private Sub btnShowMothers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowMothers.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        Try
            Dim Rows = radDataGrid.SelectedRows
            Dim FathersIds As New ArrayList()
            Using odb As New OrphanageDB.Odb
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In Rows
                    Dim fath As OrphanageClasses.Father = Getter.GetFatherByID(CType(row.Cells("Father_Id").Value, Integer), odb)
                    Dim Fams() As OrphanageClasses.Family = fath.Families.ToArray()
                    For Each fam As OrphanageClasses.Family In Fams
                        If Not FathersIds.Contains(fam.Mother_ID) Then
                            FathersIds.Add(fam.Mother_ID)
                        End If
                    Next
                Next
            End Using
            If FathersIds.Count > 0 Then
                Dim Fids(FathersIds.Count) As Integer
                For i As Integer = 0 To FathersIds.Count - 1
                    Fids(i) = CInt(FathersIds(i))
                Next
                Dim frmFaths As New FrmMothers(Fids)
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
                Using odb As New OrphanageDB.Odb
                    Dim fth As OrphanageClasses.Father = Getter.GetFatherByID(CType(e.Row.Cells("Father_Id").Value, Integer), odb)
                    If IsNothing(fth) Then Return
                    Dim phot As Image = Nothing
                    If e.Column.Name = "Photo" Then
                        If IsNothing(fth.Photo) Then Return
                        phot = Getter.GetImage(fth.Photo)
                    End If
                    Dim frmShopic As New FrmShowPic(phot, radDataGrid.Rows(e.RowIndex).Cells("FatherName").Value.ToString())
                    frmShopic.ShowDialog()
                    frmShopic.Dispose()
                    odb.Dispose()
                End Using
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

    Private Sub btnShowOrphans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowOrphans.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        Try
            Dim Rows = radDataGrid.SelectedRows
            Dim FathersIds As New ArrayList()
            For Each row As Telerik.WinControls.UI.GridViewRowInfo In Rows
                Dim orphs() As Integer = Getter.GetFatherOrphans(CType(row.Cells("Father_Id").Value, Integer))
                If Not IsNothing(orphs) Then
                    For Each orp In orphs
                        If Not FathersIds.Contains(orp) Then
                            FathersIds.Add(orp)
                        End If
                    Next
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
            Dim Fid As Integer = 0
            Dim Fids As New Dictionary(Of Integer, GridViewRowInfo)
            If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
                For Each ros In radDataGrid.SelectedRows
                    Fid = CInt(ros.Cells("Father_Id").Value)
                    Dim FamIds() As Integer = Getter.GetFatherFamiles(Fid)
                    For Each inFid As Integer In FamIds
                        If Not Fids.ContainsKey(inFid) Then
                            Fids.Add(inFid, ros)
                        End If
                    Next
                Next
            End If
            If Fid = 0 OrElse Fids.Count = 0 Then Return
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
                If Not IsNothing(famId) And famId > 0 Then
                    Using Odb As New OrphanageDB.Odb
                        Dim forFamID As Integer = famId
                        Dim q = From fam In Odb.Families Where fam.ID = forFamID Select fam
                        Try
                            Updater.UpdatesFamily(q.FirstOrDefault())
                            UpdatesFather(q.FirstOrDefault().Father)
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
        Layouts.DrawRowColors(e, IDSColors, "Father_Id", "Color_Mark", IsLoading)
    End Sub
End Class
