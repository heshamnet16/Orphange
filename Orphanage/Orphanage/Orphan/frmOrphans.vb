Imports Telerik.WinControls.UI
Imports System.IO
Imports System.Threading
Imports System.Runtime.CompilerServices
Imports System.ComponentModel
Imports Telerik.WinControls

Public Class frmOrphans
    Private StrCount As String = ""
    Private _BailedOrphanOnly As Boolean = False
    Private _CustomView As Boolean = False
    Private _Ids() As Integer = Nothing
    Private _StopValidation As Boolean = False
    Public IsLoading As Boolean = True
    Private _OrphansSet As System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan) = Nothing
    Private _isClosing As Boolean = False
    Private _SeletedRows As New ArrayList()
    Dim IDSColors As New Dictionary(Of Integer, Color)
    Public obj As New Object
#Region "ContextMenu"
    Dim WithEvents MainMnu As New RadContextMenu()
    Dim WithEvents mnuShows As New RadMenuItem("عرض")
    Dim WithEvents SubSOrphans As New RadMenuItem("عرض الأخوة")
    Dim WithEvents SubSFamilies As New RadMenuItem("عرض العائلات")
    Dim WithEvents SubSFAthers As New RadMenuItem("عرض الآباء")
    Dim WithEvents SubSMothers As New RadMenuItem("عرض الأمهات")
    Dim WithEvents SubSBondsMen As New RadMenuItem("عرض المعيلين")
    Dim WithEvents SubSSupporters As New RadMenuItem("عرض الكفلاء")
    Dim WithEvents SubSBails As New RadMenuItem("عرض كفالات")
    Dim WithEvents SubSBills As New RadMenuItem("عرض إيصالات")
    Dim WithEvents MnuOprations As New RadMenuItem("عمليات")
    Dim WithEvents subOExclude As New RadMenuItem("استبعاد")
    Dim WithEvents SubOBill As New RadMenuItem("إيصال")
    Dim WithEvents SubOBail As New RadMenuItem("كفالة")
    Dim WithEvents mnuCollapseAll As New RadMenuItem("طي الكل")
    Dim WithEvents mnuExpandAll As New RadMenuItem("توسيع الكل")
    Private Sub BuildContextList()
        AddHandler mnuCollapseAll.Click, AddressOf mnuCollapseAll_Click
        AddHandler mnuExpandAll.Click, AddressOf mnuExpandAll_MouseDown
        'Show Menu
        mnuShows.Items.Add(SubSFamilies)
        mnuShows.Items.Add(SubSFAthers)
        mnuShows.Items.Add(SubSMothers)
        mnuShows.Items.Add(SubSOrphans)
        mnuShows.Items.Add(SubSBondsMen)
        mnuShows.Items.Add(New RadMenuSeparatorItem())
        mnuShows.Items.Add(SubSSupporters)
        mnuShows.Items.Add(SubSBails)
        mnuShows.Items.Add(SubSBills)
        'Operation Menu        
        MnuOprations.Items.Add(SubOBail)
        MnuOprations.Items.Add(New RadMenuSeparatorItem())
        MnuOprations.Items.Add(SubOBill)
        MnuOprations.Items.Add(New RadMenuSeparatorItem())
        MnuOprations.Items.Add(subOExclude)
        'Main Menu
        MainMnu.Items.Add(mnuShows)
        MainMnu.Items.Add(New RadMenuSeparatorItem())
        MainMnu.Items.Add(MnuOprations)
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

#Region "UpdateRows"
    Private Sub DeletesOrphan(ByVal bx As Integer)
        For Each row In radDataGrid.Rows
            Dim id As Integer = CInt(row.Cells("ID").Value)
            If id = bx Then
                row.IsVisible = False
                Exit For
            End If
            Application.DoEvents()
        Next
    End Sub
    Private Sub AddNewOrphan(ByVal bx As OrphanageClasses.Orphan)
        Try
            _StopValidation = True
            Using AddNewCn As New OrphanageDB.Odb
                AddNewCn.ObjectTrackingEnabled = False
                Dim qq = From orp In AddNewCn.Orphans Where orp.ID = bx.ID Select orp, orp.Name
                bx = qq.FirstOrDefault().orp
                Dim qFam = From fm In AddNewCn.Families Where fm.ID = bx.Family_ID
                           Select fm
                Dim Fam = qFam.FirstOrDefault()
                Dim qFath = From fat In AddNewCn.Fathers Join Nfat In AddNewCn.Names
                            On fat.Name_ID Equals Nfat.ID
                            Where fat.ID = Fam.Father_ID
                            Select fat, Nfat
                Dim Fath = qFath.FirstOrDefault().fat
                Dim FathN = qFath.FirstOrDefault.Nfat
                Dim qMoth = From mo In AddNewCn.Mothers, Nmo In AddNewCn.Names Where mo.ID = Fam.Mother_ID AndAlso Nmo.ID = mo.Name_ID
                            Select mo, Nmo
                Dim Moth = qMoth.FirstOrDefault().mo
                Dim MothN = qMoth.FirstOrDefault().Nmo
                Dim qBond = From bo In AddNewCn.BondsMans, nBo In AddNewCn.Names Where bo.ID = bx.BondsMan_ID AndAlso nBo.ID = bo.Name_ID
                            Select bo, nBo
                Dim Bond = qBond.FirstOrDefault.bo
                Dim BondN = qBond.FirstOrDefault.nBo
                Dim QFamAdd1 = From add1 In AddNewCn.Addresses Where add1.ID = Fam.Address_ID Select add1
                Dim QFamAdd2 = From add2 In AddNewCn.Addresses Where add2.ID = Fam.Address_ID2 Select add2
                Dim FamAdd = QFamAdd1.FirstOrDefault()
                Dim FamAdd2 = QFamAdd2.FirstOrDefault()
                Dim xx As GridViewRowInfo = radDataGrid.Rows.AddNew()
                xx.Cells("ID").Value = bx.ID
                xx.Cells("OrphanFN").Value = qq.FirstOrDefault().Name.First
                xx.Cells("OrphanFatherN").Value = qq.FirstOrDefault().Name.Father
                xx.Cells("OrphanLN").Value = qq.FirstOrDefault().Name.Last
                xx.Cells("FAtherFather").Value = FathN.Father
                xx.Cells("Birthday").Value = bx.Birthday
                'Dim xkk() As Integer = Getter.GetOrphanBrothers(bx.ID)
                'If Not IsNothing(xkk) Then
                '    xx.Cells("OrphanBrothersCount").Value = xkk.Length
                'End If
                'xx.Cells("OrphanBrothersSex").Value = Getter.GetOrphanFemaleBrothersNumber(bx.ID) & " إناث" & Getter.GetOrphanMaleBrothersNumber(bx.ID) & " ذكور"
                xx.Cells("Birthplace").Value = bx.BirthPlace
                xx.Cells("Gender").Value = bx.Gender
                'xx.Cells("FacePhoto").Value = bx.FacePhoto
                xx.Cells("IsBailed").Value = bx.IsBailed
                xx.Cells("Age").Value = IIf(bx.Age.HasValue, bx.Age, Nothing)
                If bx.IsExcluded.HasValue Then
                    xx.Cells("IsExcluded").Value = bx.IsExcluded.Value
                Else
                    xx.Cells("IsExcluded").Value = False
                End If
                xx.Cells("RegDate").Value = bx.RegDate
                If bx.Color_Mark.HasValue Then
                    xx.Cells("Color_Mark").Value = bx.Color_Mark.Value
                End If
                'xx.Cells("FullPhoto").Value = bx.FullPhoto
                If bx.Weight.HasValue Then
                    xx.Cells("Weight").Value = bx.Weight.Value
                End If
                If bx.Tallness.HasValue Then
                    xx.Cells("Tallness").Value = bx.Tallness.Value
                End If
                If bx.IdentityNumber.HasValue Then
                    xx.Cells("IdentityNumber").Value = bx.IdentityNumber.Value
                End If
                If bx.FootSize.HasValue Then
                    xx.Cells("FootSize").Value = bx.FootSize.Value
                End If
                xx.Cells("Story").Value = bx.Story
                If bx.Education_ID.HasValue Then
                    Dim Qst = From ostud In AddNewCn.Studies Where ostud.ID = bx.Education_ID _
                              Select ostud.Stage, ostud.Resons
                    xx.Cells("Stage").Value = Qst.FirstOrDefault.Stage
                    xx.Cells("Reasons").Value = Qst.FirstOrDefault.Resons
                End If
                If bx.Health_ID.HasValue Then
                    Dim Qh = From qhl In AddNewCn.Healthies Where qhl.ID = bx.Health_ID Select Name
                    xx.Cells("HealthName").Value = Qh.FirstOrDefault()
                End If
                If bx.Kaid.HasValue Then
                    xx.Cells("Kaid").Value = bx.Kaid.Value
                End If
                xx.Cells("EName").Value = qq.FirstOrDefault().Name.EName
                xx.Cells("EFather").Value = qq.FirstOrDefault().Name.EFather
                xx.Cells("ELast").Value = qq.FirstOrDefault().Name.ELast
                xx.Cells("MotherF").Value = MothN.First
                xx.Cells("MotherFather").Value = MothN.Father
                xx.Cells("MotherL").Value = MothN.Last
                xx.Cells("FamilyIsBailed").Value = Fam.IsBaild
                xx.Cells("Redidence_State").Value = Fam.Residece_Sate
                xx.Cells("Residence_Type").Value = Fam.Residenc_Type
                xx.Cells("IsRefugee").Value = Fam.IsRefugee
                xx.Cells("Finncial_State").Value = Fam.Finncial_Sate
                xx.Cells("FamilyCard_Num").Value = Fam.FamilyCard_Num
                If Fam.Color_Mark.HasValue Then
                    xx.Cells("FamilyColor").Value = Fam.Color_Mark.Value
                End If
                If Fam.IsRefugee Then
                    If Fam.Address_ID2.HasValue Then
                        xx.Cells("Country").Value = FamAdd2.Country
                        xx.Cells("City").Value = FamAdd2.City
                        xx.Cells("Town").Value = FamAdd2.Town
                        xx.Cells("Street").Value = FamAdd2.Street
                        xx.Cells("Home_Phone").Value = FamAdd2.Home_Phone
                        xx.Cells("Cell_Phone").Value = FamAdd2.Cell_Phone
                        xx.Cells("Fax").Value = FamAdd2.Fax
                        xx.Cells("Email").Value = FamAdd2.Email
                        xx.Cells("Twitter").Value = FamAdd2.Twitter
                        xx.Cells("Facebook").Value = FamAdd2.Facebook
                    Else
                        If Fam.Address_ID.HasValue Then
                            xx.Cells("Country").Value = FamAdd.Country
                            xx.Cells("City").Value = FamAdd.City
                            xx.Cells("Town").Value = FamAdd.Town
                            xx.Cells("Street").Value = FamAdd.Street
                            xx.Cells("Home_Phone").Value = FamAdd.Home_Phone
                            xx.Cells("Cell_Phone").Value = FamAdd.Cell_Phone
                            xx.Cells("Fax").Value = FamAdd.Fax
                            xx.Cells("Email").Value = FamAdd.Email
                            xx.Cells("Twitter").Value = FamAdd.Twitter
                            xx.Cells("Facebook").Value = FamAdd.Facebook
                        End If
                    End If
                End If
                xx.Cells("FamilyIsExcluded").Value = Fam.IsExcluded
                xx.Cells("MotherEFN").Value = MothN.EName
                xx.Cells("MotherEFatherN").Value = MothN.EFather
                xx.Cells("MotherELN").Value = MothN.ELast
                xx.Cells("EFAthersFatherN").Value = FathN.EFather
                xx.Cells("FatherDeath").Value = Fath.Dieday
                xx.Cells("FatherJop").Value = Fath.Jop
                xx.Cells("FAtherDeathReason").Value = Fath.DeathResone
                xx.Cells("FAtherBirthday").Value = Fath.Birthday
                xx.Cells("MotherBirthday").Value = Moth.Birthday
                xx.Cells("MotherIsDead").Value = Moth.IsDead
                If Moth.IsDead Then
                    xx.Cells("MotherDieDate").Value = Moth.Dieday
                End If
                If Moth.IdntityCard_ID.HasValue Then
                    xx.Cells("MotherIdCardNumber").Value = Moth.IdntityCard_ID.Value
                End If
                xx.Cells("IsMarried").Value = Moth.IsMarried
                xx.Cells("MotherJop").Value = Moth.Jop
                If Moth.Salary.HasValue Then
                    xx.Cells("MotherSalary").Value = Moth.Salary.Value
                End If
                xx.Cells("BondsManRel").Value = bx.BondsManRelationship
                If Bond.IdentityCard_ID.HasValue Then
                    xx.Cells("BondsCardID").Value = Bond.IdentityCard_ID.Value
                End If
                xx.Cells("BondsJop").Value = Bond.Jop
                If Bond.Income.HasValue Then
                    xx.Cells("BondsIncome").Value = Bond.Income.Value
                End If
                xx.Cells("BondsFirstN").Value = BondN.First
                xx.Cells("BondsFAtherN").Value = BondN.Father
                xx.Cells("BondsLast").Value = BondN.Last
                xx.Cells("BondsEFirst").Value = BondN.EName
                xx.Cells("BondsEFather").Value = BondN.EFather
                xx.Cells("BondELast").Value = BondN.ELast
                If IDSColors.ContainsKey(bx.ID) Then IDSColors.Remove(bx.ID)
                AddNewCn.Dispose()
            End Using
            _StopValidation = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub UpdatesOrphan(ByVal bx As OrphanageClasses.Orphan)
        Try
            Dim DeletedRow As GridViewRowInfo = Nothing
            Dim ret = radDataGrid.Rows.Where(Function(x) CInt(x.Cells("ID").Value) = bx.ID).FirstOrDefault()

            If Not IsNothing(ret) Then
                Dim xx As GridViewRowInfo = ret
                If _isClosing Then Exit Sub
                Dim id As Integer = CInt(xx.Cells("ID").Value)
                If id = bx.ID Then
                    If Not bx.IsExcluded Or Not bx.Family.IsExcluded Then
                        xx.Cells("ID").Value = bx.ID
                        xx.Cells("OrphanFN").Value = bx.Name.First
                        xx.Cells("OrphanFatherN").Value = bx.Name.Father
                        xx.Cells("OrphanLN").Value = bx.Name.Last
                        xx.Cells("FAtherFather").Value = bx.Family.Father.Name.Father
                        xx.Cells("Birthday").Value = bx.Birthday
                        xx.Cells("Gender").Value = bx.Gender
                        xx.Cells("Birthplace").Value = bx.BirthPlace
                        'xx.Cells("FacePhoto").Value = bx.FacePhoto
                        xx.Cells("IsBailed").Value = bx.IsBailed
                        xx.Cells("Age").Value = bx.Age
                        xx.Cells("IsExcluded").Value = bx.IsExcluded
                        xx.Cells("Color_Mark").Value = bx.Color_Mark
                        xx.Cells("RegDate").Value = bx.RegDate
                        'xx.Cells("FullPhoto").Value = bx.FullPhoto
                        xx.Cells("Weight").Value = bx.Weight
                        xx.Cells("Tallness").Value = bx.Tallness
                        xx.Cells("IdentityNumber").Value = bx.IdentityNumber
                        xx.Cells("FootSize").Value = bx.FootSize
                        xx.Cells("Story").Value = bx.Story
                        If bx.Education_ID.HasValue Then
                            xx.Cells("Stage").Value = bx.Study.Stage
                            xx.Cells("Reasons").Value = bx.Study.Resons
                        End If
                        If bx.Health_ID.HasValue Then
                            xx.Cells("HealthName").Value = bx.Healthy.Name
                        End If
                        xx.Cells("Kaid").Value = bx.Kaid
                        xx.Cells("EName").Value = bx.Name.EName
                        xx.Cells("EFather").Value = bx.Name.EFather
                        xx.Cells("ELast").Value = bx.Name.ELast
                        xx.Cells("MotherF").Value = bx.Family.Mother.Name.First
                        xx.Cells("MotherFather").Value = bx.Family.Mother.Name.Father
                        xx.Cells("MotherL").Value = bx.Family.Mother.Name.Last
                        xx.Cells("FamilyIsBailed").Value = bx.Family.IsBaild
                        xx.Cells("Redidence_State").Value = bx.Family.Residece_Sate
                        xx.Cells("Residence_Type").Value = bx.Family.Residenc_Type
                        xx.Cells("IsRefugee").Value = bx.Family.IsRefugee
                        xx.Cells("Finncial_State").Value = bx.Family.Finncial_Sate
                        xx.Cells("FamilyCard_Num").Value = bx.Family.FamilyCard_Num
                        xx.Cells("FamilyColor").Value = bx.Family.Color_Mark
                        If bx.Family.IsRefugee Then
                            If bx.Family.Address_ID2.HasValue Then
                                xx.Cells("Country").Value = bx.Family.Address1.Country
                                xx.Cells("City").Value = bx.Family.Address1.City
                                xx.Cells("Town").Value = bx.Family.Address1.Town
                                xx.Cells("Street").Value = bx.Family.Address1.Street
                                xx.Cells("Home_Phone").Value = bx.Family.Address1.Home_Phone
                                xx.Cells("Cell_Phone").Value = bx.Family.Address1.Cell_Phone
                                xx.Cells("Fax").Value = bx.Family.Address1.Fax
                                xx.Cells("Email").Value = bx.Family.Address1.Email
                                xx.Cells("Twitter").Value = bx.Family.Address1.Twitter
                                xx.Cells("Facebook").Value = bx.Family.Address1.Facebook
                            Else
                                If bx.Family.Address_ID.HasValue Then
                                    xx.Cells("Country").Value = bx.Family.Address.Country
                                    xx.Cells("City").Value = bx.Family.Address.City
                                    xx.Cells("Town").Value = bx.Family.Address.Town
                                    xx.Cells("Street").Value = bx.Family.Address.Street
                                    xx.Cells("Home_Phone").Value = bx.Family.Address.Home_Phone
                                    xx.Cells("Cell_Phone").Value = bx.Family.Address.Cell_Phone
                                    xx.Cells("Fax").Value = bx.Family.Address.Fax
                                    xx.Cells("Email").Value = bx.Family.Address.Email
                                    xx.Cells("Twitter").Value = bx.Family.Address.Twitter
                                    xx.Cells("Facebook").Value = bx.Family.Address.Facebook
                                End If
                            End If
                        End If
                        xx.Cells("FamilyIsExcluded").Value = bx.Family.IsExcluded
                        xx.Cells("MotherEFN").Value = bx.Family.Mother.Name.EName
                        xx.Cells("MotherEFatherN").Value = bx.Family.Mother.Name.EFather
                        xx.Cells("MotherELN").Value = bx.Family.Mother.Name.ELast
                        xx.Cells("EFAthersFatherN").Value = bx.Family.Father.Name.EFather
                        xx.Cells("FatherDeath").Value = bx.Family.Father.Dieday
                        xx.Cells("FatherJop").Value = bx.Family.Father.Jop
                        xx.Cells("FAtherDeathReason").Value = bx.Family.Father.DeathResone
                        xx.Cells("FAtherBirthday").Value = bx.Family.Father.Birthday
                        xx.Cells("MotherBirthday").Value = bx.Family.Mother.Birthday
                        xx.Cells("MotherIsDead").Value = bx.Family.Mother.IsDead
                        If bx.Family.Mother.IsDead Then
                            xx.Cells("MotherDieDate").Value = bx.Family.Mother.Dieday
                        End If
                        xx.Cells("MotherIdCardNumber").Value = bx.Family.Mother.IdntityCard_ID
                        xx.Cells("IsMarried").Value = bx.Family.Mother.IsMarried
                        xx.Cells("MotherJop").Value = bx.Family.Mother.Jop
                        xx.Cells("MotherSalary").Value = bx.Family.Mother.Salary
                        xx.Cells("BondsManRel").Value = bx.BondsManRelationship
                        xx.Cells("BondsCardID").Value = bx.BondsMan.IdentityCard_ID
                        xx.Cells("BondsJop").Value = bx.BondsMan.Jop
                        xx.Cells("BondsIncome").Value = bx.BondsMan.Income
                        xx.Cells("BondsFirstN").Value = bx.BondsMan.Name.First
                        xx.Cells("BondsFAtherN").Value = bx.BondsMan.Name.Father
                        xx.Cells("BondsLast").Value = bx.BondsMan.Name.Last
                        xx.Cells("BondsEFirst").Value = bx.BondsMan.Name.EName
                        xx.Cells("BondsEFather").Value = bx.BondsMan.Name.EFather
                        xx.Cells("BondELast").Value = bx.BondsMan.Name.ELast
                        If IDSColors.ContainsKey(bx.ID) Then IDSColors.Remove(bx.ID)
                    Else
                        DeletedRow = xx
                    End If
                    'Exit For
                End If
                Application.DoEvents()

            End If
            'For Each xx In radDataGrid.Rows
            'Next
            If Not IsNothing(DeletedRow) Then
                radDataGrid.Rows.Remove(DeletedRow)
            End If
        Catch
        End Try
    End Sub
#End Region
    Private Sub FrmFathers_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.radDataGrid.Cursor = Cursors.WaitCursor Then
            Me.radDataGrid.Cursor = Cursors.Default
        End If
        If My.Settings.SaveGridState Then
            radDataGrid.SaveLayout("OrphansAllLayout.Xaml")
        End If
        If My.Settings.SaveWindowsState Then
            Layouts.SaveFormLayout(Me)
        End If
        _isClosing = True
    End Sub
    Private Sub LoadData(ByVal ids() As Integer)
        Try
            If Not My.Settings.ShowHiddenObject Then
                Me.AllOrphansTableAdapter.FillByUnExcluded(Me.OrphansDBDataSet.AllOrphans)
            Else
                Me.AllOrphansTableAdapter.AllData(Me.OrphansDBDataSet.AllOrphans)
            End If
            Dim xx = Me.OrphansDBDataSet.AllOrphans.Where(Function(x) ids.Contains(x.ID))
            'Me.radDataGrid.DataSource = Nothing
            Me.radDataGrid.DataSource = xx.AsDataView()
            ProgressSate.ShowStatueProgress(100, "")
            If radDataGrid.RowCount > 0 Then
                StrCount = "العدد الكلي " & radDataGrid.RowCount
                lblStatus.Text = StrCount
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub
    Private Sub LoadData()
        Try
            Dim i As Integer = 0
            Dim all As Integer = 0
            Dim PerValue = 0, LastPerValue As Integer = 0
            Dim ColorArray As New Dictionary(Of Integer, Long)
            all = _OrphansSet.Count
            If radDataGrid.Rows.Count > 0 Then radDataGrid.Rows.Clear()
            radDataGrid.TableElement.BeginUpdate()
            For Each orp In _OrphansSet
                If _isClosing Then Exit Sub
                PerValue = Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100))
                If Not IsNothing(orp) Then
                    If My.Settings.ShowHiddenObject Then
                        AddNewOrphan(orp)
                    Else
                        If IsNothing(orp.IsExcluded) OrElse Not orp.IsExcluded Then
                            AddNewOrphan(orp)
                        End If
                    End If
                End If
                i += 1
                If PerValue Mod 2 = 0 Then ProgressSate.ShowStatueProgress(PerValue, "")
            Next
            radDataGrid.TableElement.EndUpdate()
            ProgressSate.ShowStatueProgress(100, "")
            If radDataGrid.RowCount > 0 Then
                StrCount = "العدد الكلي " & radDataGrid.RowCount
                lblStatus.Text = StrCount
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub AddCheckBoxColumn()
        Dim checkColumn As New GridViewCheckBoxColumn()
        checkColumn.Name = "Select"
        checkColumn.HeaderText = "تحديد"
        Me.radDataGrid.Columns.Insert(0, checkColumn)
    End Sub
    'Private Sub AddBrothersColumn()
    '    Dim OrphanBrothers As New GridViewTextBoxColumn
    '    OrphanBrothers.Name = "OrphanBrothersCount"
    '    OrphanBrothers.HeaderText = "عدد الأخوة"
    '    Me.radDataGrid.Columns.Insert(Me.radDataGrid.Columns.Count - 1, OrphanBrothers)
    '    Dim OrphanBrothersSex As New GridViewTextBoxColumn
    '    OrphanBrothersSex.Name = "OrphanBrothersSex"
    '    OrphanBrothersSex.HeaderText = "الأخوة"
    '    Me.radDataGrid.Columns.Insert(Me.radDataGrid.Columns.Count - 1, OrphanBrothersSex)
    'End Sub
    Private Sub FrmTestOrphans_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Me.radDataGrid.Columns.Contains("Select") Then
            AddCheckBoxColumn()
        End If
        'If Not Me.radDataGrid.Columns.Contains("OrphanBrothersCount") Then
        '    AddBrothersColumn()
        'End If
        If Not _CustomView Then
            If Not My.Settings.ShowHiddenObject Then
                Me.AllOrphansTableAdapter.FillByUnExcluded(Me.OrphansDBDataSet.AllOrphans)
            Else
                Me.AllOrphansTableAdapter.AllData(Me.OrphansDBDataSet.AllOrphans)
            End If
        Else
            If Not IsNothing(_Ids) Then
                LoadData(Me._Ids)
            ElseIf Not IsNothing(_OrphansSet) Then
                LoadData()
            Else
                If _BailedOrphanOnly Then
                    If Not My.Settings.ShowHiddenObject Then
                        Me.AllOrphansTableAdapter.FillByBailed(Me.OrphansDBDataSet.AllOrphans)
                    Else
                        Me.AllOrphansTableAdapter.FillByBailedUnExcl(Me.OrphansDBDataSet.AllOrphans)
                    End If
                Else
                    If Not My.Settings.ShowHiddenObject Then
                        Me.AllOrphansTableAdapter.FillByUnBailedUnExc(Me.OrphansDBDataSet.AllOrphans)
                    Else
                        Me.AllOrphansTableAdapter.FillByUnBaild(Me.OrphansDBDataSet.AllOrphans)
                    End If
                End If
            End If
        End If
        AddHandler Updater.NewOrphan, AddressOf AddNewOrphan
        AddHandler Updater.UpdateOrphan, AddressOf UpdatesOrphan
        AddHandler Updater.DeleteOrphan, AddressOf DeletesOrphan
        If IsNothing(Me.MdiParent) Then
            Me.MdiParent = Application.OpenForms("FrmMain")
        End If
        If radDataGrid.RowCount > 0 Then
            StrCount = "العدد الكلي " & radDataGrid.RowCount
            lblStatus.Text = StrCount
        End If
        If My.Settings.SaveGridState AndAlso IO.File.Exists("OrphansAllLayout.Xaml") Then
            radDataGrid.LoadLayout("OrphansAllLayout.Xaml")
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
        CType(radDataGrid.Columns("Birthday"), Telerik.WinControls.UI.GridViewDateTimeColumn).Format = DateTimePickerFormat.Custom
        CType(radDataGrid.Columns("FatherDeath"), Telerik.WinControls.UI.GridViewDateTimeColumn).Format = DateTimePickerFormat.Custom
        CType(radDataGrid.Columns("FAtherBirthday"), Telerik.WinControls.UI.GridViewDateTimeColumn).Format = DateTimePickerFormat.Custom
        CType(radDataGrid.Columns("MotherBirthday"), Telerik.WinControls.UI.GridViewDateTimeColumn).Format = DateTimePickerFormat.Custom
        CType(radDataGrid.Columns("MotherDieDate"), Telerik.WinControls.UI.GridViewDateTimeColumn).Format = DateTimePickerFormat.Custom
        CType(radDataGrid.Columns("Birthday"), Telerik.WinControls.UI.GridViewDateTimeColumn).FormatString = "{0:" + My.Settings.GeneralDateFormat + "}"
        CType(radDataGrid.Columns("FatherDeath"), Telerik.WinControls.UI.GridViewDateTimeColumn).FormatString = "{0:" + My.Settings.GeneralDateFormat + "}"
        CType(radDataGrid.Columns("FAtherBirthday"), Telerik.WinControls.UI.GridViewDateTimeColumn).FormatString = "{0:" + My.Settings.GeneralDateFormat + "}"
        CType(radDataGrid.Columns("MotherBirthday"), Telerik.WinControls.UI.GridViewDateTimeColumn).FormatString = "{0:" + My.Settings.GeneralDateFormat + "}"
        CType(radDataGrid.Columns("MotherDieDate"), Telerik.WinControls.UI.GridViewDateTimeColumn).FormatString = "{0:" + My.Settings.GeneralDateFormat + "}"
        RadGridView1_SelectionChanged(Nothing, Nothing)
        'Me.radDataGrid.GridBehavior = New gridBehavior(Me)
        RunBackgroundWorker()
    End Sub

    Public Sub RunBackgroundWorker()
        If Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Private Sub radDataGrid_CreateCell(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCreateCellEventArgs) Handles radDataGrid.CreateCell
        If _StopValidation Then Exit Sub
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

    Private Sub Setdata(ByVal _OrphId As Object)
        Try
            Dim OrphId As Integer = CInt(_OrphId)
            If OrphId > 0 Then
                Using Odb As New OrphanageDB.Odb
                    Odb.ObjectTrackingEnabled = False
                    Dim temp As OrphanageClasses.Orphan = Getter.GetOrphanByID(OrphId, Odb)
                    Dim qFam = From fam In Odb.Families Where fam.ID = temp.Family_ID Select fam
                    Dim strAll As String = ""
                    Dim MaleBro As Integer = 0
                    Dim femaleBro As Integer = 0
                    If Not IsNothing(temp) Then
                        If Not IsNothing(temp.FacePhoto) Then
                            Try
                                Dim xx As New MemoryStream(temp.FacePhoto)
                                Dim img As Image = Image.FromStream(xx)
                                BeginInvoke(New MethodInvoker(Sub() PictureBox1.Image = img))
                                xx.Close()
                                xx.Dispose()
                            Catch
                            End Try
                        Else
                            BeginInvoke(New MethodInvoker(Sub() PictureBox1.Image = Nothing))
                        End If
                        If Not temp.IsBailed Then
                            BeginInvoke(New MethodInvoker(Sub() BtnBail.ToolTipText = "كفالة"))
                            BeginInvoke(New MethodInvoker(Sub() SubOBail.Text = "كفالة"))
                            BeginInvoke(New MethodInvoker(Sub() BtnBail.Image = My.Resources.Bail))
                        Else
                            BeginInvoke(New MethodInvoker(Sub() BtnBail.ToolTipText = "الغاء الكفالة"))
                            BeginInvoke(New MethodInvoker(Sub() SubOBail.Text = "الغاء الكفالة"))
                            BeginInvoke(New MethodInvoker(Sub() BtnBail.Image = My.Resources.CancelBail))
                        End If
                        MaleBro = Getter.GetOrphanMaleBrothersNumber(OrphId)
                        femaleBro = Getter.GetOrphanFemaleBrothersNumber(OrphId)
                        If MaleBro + femaleBro > 0 Then
                            BeginInvoke(New MethodInvoker(Sub() btnShowOrphans.Enabled = True))
                        Else
                            BeginInvoke(New MethodInvoker(Sub() btnShowOrphans.Enabled = False))
                        End If
                        If temp.IsExcluded.HasValue AndAlso temp.IsExcluded.Value Then
                            btnExclud.ToolTipText = "إلغاء الاستبعاد"
                            subOExclude.Text = "إلغاء الاستبعاد"
                            btnExclud.Image = My.Resources.Cancelghost
                        Else
                            BeginInvoke(New MethodInvoker(Sub() btnExclud.ToolTipText = "استبعاد"))
                            BeginInvoke(New MethodInvoker(Sub() subOExclude.Text = "استبعاد"))
                            BeginInvoke(New MethodInvoker(Sub() btnExclud.Image = My.Resources.ghost))
                        End If
                        Dim Father_ID = Getter.GetFather_IDByOrphan_ID(OrphId)
                        Dim qfath = From fth In Odb.Fathers Where fth.ID = Father_ID Select fth, fth.Name
                        strAll = "اسم الأب : " & Getter.GetFullName(qfath.FirstOrDefault().Name) & vbNewLine
                        Try
                            strAll &= "تاريخ الوفاة : " & qfath.FirstOrDefault().fth.Dieday.ToString(My.Settings.GeneralDateFormat) & vbNewLine
                        Catch
                        End Try
                        Dim moth_ID = Getter.GetMother_IDByOrphan_ID(OrphId)
                        Dim qMoth = From mth In Odb.Mothers Where mth.ID = moth_ID Select mth.Name, mth
                        strAll &= "اسم الأم : " & Getter.GetFullName(qMoth.FirstOrDefault().Name) & vbNewLine
                        strAll &= " الأم متوفية : " & ATDFormater.ArabicBooleanFormatter.BooleanToArabic(qMoth.FirstOrDefault().mth.IsDead) & vbNewLine
                        Try
                            If qMoth.FirstOrDefault().mth.IsDead AndAlso qMoth.FirstOrDefault().mth.Dieday.HasValue Then
                                strAll &= "تاريخ وفاة الأم : " & qMoth.FirstOrDefault().mth.Dieday.Value.ToString(My.Settings.GeneralDateFormat) & vbNewLine
                            End If
                        Catch
                        End Try
                        strAll &= " الأم متزوجة : " & ATDFormater.ArabicBooleanFormatter.BooleanToArabic(qMoth.FirstOrDefault().mth.IsMarried) & vbNewLine
                        If qMoth.FirstOrDefault().mth.IsMarried AndAlso Not IsNothing(qMoth.FirstOrDefault().mth.Husband_Name) Then
                            strAll &= "اسم زوج الأم : " & qMoth.FirstOrDefault().mth.Husband_Name & vbNewLine
                        End If
                        If temp.Age.HasValue Then
                            strAll &= "العمر : " & ATDFormater.ArabicDateFormater.GetArabicYear(temp.Age.Value) & vbNewLine
                        End If
                        strAll &= "عدد الأخوة : " & MaleBro & " ذكور " & femaleBro & " إناث" & vbNewLine
                        If temp.IsBailed Or qFam.FirstOrDefault().IsBaild Then
                            Dim bal As OrphanageClasses.Bail = Nothing
                            If qFam.FirstOrDefault().IsBaild Then
                                Dim qbal = From bl In Odb.Bails Where bl.ID = qFam.FirstOrDefault.Baild_ID Select bl
                                bal = qbal.FirstOrDefault()
                            Else
                                Dim qbal = From bl In Odb.Bails Where bl.ID = temp.Bail_ID Select bl
                                bal = qbal.FirstOrDefault()
                            End If
                            If Not IsNothing(bal) Then
                                Dim qSuppNAme = From sup In Odb.Supporters Where sup.ID = bal.Supporter_ID Select sup.Name
                                Dim qCurName = From Cur In Odb.Boxes Where Cur.ID = bal.Box_ID Select Cur.Currency_Short
                                strAll &= "مكفول : " & "نعم" & vbNewLine
                                strAll &= "اسم الكفيل : " & Getter.GetFullName(qSuppNAme.FirstOrDefault()) & vbNewLine
                                strAll &= "كفالة عائلية : " & ATDFormater.ArabicBooleanFormatter.BooleanToArabic(bal.Is_Family) & vbNewLine
                                strAll &= "المبلغ : " & bal.Amount.ToString() & " " & qCurName.FirstOrDefault() & vbNewLine
                                strAll &= "كفالة شهرية : " & ATDFormater.ArabicBooleanFormatter.BooleanToArabic(bal.IsMonthly) & vbNewLine
                                strAll &= "كفالة منتهية : " & ATDFormater.ArabicBooleanFormatter.BooleanToArabic(bal.Is_Ended) & vbNewLine
                            Else
                                strAll &= "مكفول : " & "لا" & vbNewLine
                            End If
                        Else
                            strAll &= "مكفول : " & "لا" & vbNewLine
                        End If
                        If temp.Education_ID.HasValue Then
                            Dim qEdu = From ed In Odb.Studies Where ed.ID = temp.Education_ID Select ed
                            Dim edu = qEdu.FirstOrDefault()
                            If Not IsNothing(edu) Then
                                If edu.Stage.Contains("متخلف") Then
                                    strAll &= "يدرس : " & "لا" & vbNewLine
                                    If Not IsNothing(edu.Resons) Then
                                        strAll &= "السبب : " & edu.Resons & vbNewLine
                                    End If
                                Else
                                    strAll &= "يدرس : " & "نعم" & vbNewLine
                                    If Not IsNothing(edu.Stage) Then
                                        strAll &= "المرحلة الدراسية : " & edu.Stage & vbNewLine
                                    End If
                                    If edu.DegreesRate.HasValue Then
                                        strAll &= "المعدل : " & edu.DegreesRate.ToString() & "%" & vbNewLine
                                    End If
                                    If Not IsNothing(edu.School) Then
                                        strAll &= " اسم المدرسة : " & edu.School & vbNewLine
                                    End If
                                End If
                            End If
                        Else
                            strAll &= "يدرس : " & "لا" & vbNewLine
                        End If
                        If temp.Health_ID.HasValue Then
                            Dim qHlth = From hl In Odb.Healthies Where hl.ID = temp.Health_ID Select hl
                            Dim hlth = qHlth.FirstOrDefault()
                            If Not IsNothing(hlth) Then
                                strAll &= "مريض : " & "نعم" & vbNewLine
                                If Not IsNothing(hlth.Name) Then
                                    strAll &= "اسم المرض : " & hlth.Name.Replace(";", ",") & vbNewLine
                                End If
                                If Not IsNothing(hlth.Medicen) Then
                                    strAll &= "الأدوية : " & hlth.Medicen.Replace(";", ",") & vbNewLine
                                End If
                                If hlth.Cost.HasValue Then
                                    strAll &= "الكلفة : " & hlth.Cost.ToString() & vbNewLine
                                End If
                            End If
                        Else
                            strAll &= "مريض : " & "لا" & vbNewLine
                        End If
                        BeginInvoke(New MethodInvoker(Sub() RadTextBox1.Text = strAll))
                    End If
                    Odb.Dispose()
                End Using
            Else
                btnShowOrphans.Enabled = True
                GC.Collect()
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message))
        End Try
    End Sub

    Private Sub RadGridView1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.SelectionChanged
        If _StopValidation OrElse Me.IsLoading Then Exit Sub
        lblStatus.Text = StrCount & " المحدد " & radDataGrid.SelectedRows.Count
        If radDataGrid.SelectedRows.Count = 1 Then
            Dim id As Integer = CInt(radDataGrid.SelectedRows(0).Cells("ID").Value)
            If id <= 0 Then Exit Sub
            Dim t As New Thread(New ParameterizedThreadStart(AddressOf Setdata))
            t.Start(id)
        End If
        'radDataGrid.TableElement.FilterRowHeight = 30
        lblStatus.Text = StrCount & " المحدد " & radDataGrid.SelectedRows.Count
    End Sub

    Private Sub RadGridView1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.Enter
        LangChanger.CurLang.SaveCurrentLanguage()
        LangChanger.CurLang.ChangeToArabic()
    End Sub

    Private Sub RadGridView1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.Leave
        LangChanger.CurLang.ReturnToSavedLanguage()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        If Not frmLogin.CurrentUser.CanDelete Then
            ExceptionsManager.RaiseAccessDeniedException()
            Return
        End If
        Try
            Dim retD As DialogResult = MsgBox("هل تريد حذف يتيم/ايتام مع كل المتعلقات بهم؟", MsgBoxStyle.Question Or MsgBoxStyle.YesNo)
            If retD = vbYes Then

                Dim DeletedRows As New ArrayList()
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                    Using Odb As New OrphanageDB.Odb
                        Dim orph As OrphanageClasses.Orphan = Getter.GetOrphanByID(CType(row.Cells("ID").Value, Integer), Odb)
                        If IsNothing(orph) Then
                            DeletedRows.Add(row)
                            Continue For
                        End If
                        If Not Deleter.DeleteOrphan(orph.ID) Then
                            ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج حذف القيد " & Getter.GetFullName(orph.Name), True, True))
                            Exit Sub
                        End If
                        Try
                            Updater.UpdatesBondsMan(orph.BondsMan_ID)
                            Updater.UpdatesOrphan(orph)
                            Updater.UpdatesFamily(orph.Family)
                            Updater.UpdatesFather(orph.Family.Father)
                            Updater.UpdatesMother(orph.Family.Mother)
                            Updater.UpdatesSupporter(orph.Supporter)
                            If orph.Bail_ID.HasValue Then
                                Updater.UpdatesBail(orph.Bail)
                            End If
                        Catch
                        End Try
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

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            Dim Row As Telerik.WinControls.UI.GridViewRowInfo = radDataGrid.SelectedRows(0)
            Dim frm As New FrmOrphan(CType(Row.Cells("ID").Value, Integer))
            frm.ShowDialog()
            Using EdBondCd As New OrphanageDB.Odb
                Dim q = From Orph In EdBondCd.Orphans Where Orph.ID = CType(Row.Cells("ID").Value, Integer) Select Orph
                If frm.ReplacedBondsMan > 0 Then
                    Dim q1 = From bond In EdBondCd.BondsMans Where bond.ID = frm.ReplacedBondsMan Select bond
                    If IsNothing(q.FirstOrDefault()) OrElse IsNothing(q1.FirstOrDefault()) Then Exit Sub
                    q.FirstOrDefault().BondsMan = q1.FirstOrDefault()
                    EdBondCd.SubmitChanges()
                    Updater.UpdatesBondsMan(q1.FirstOrDefault().ID)
                End If
                Updater.UpdatesOrphan(q.FirstOrDefault())
                EdBondCd.Dispose()
            End Using
            frm.Dispose()
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub btnExclud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExclud.Click, subOExclude.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        Try
            Dim retD As DialogResult = MsgBox("لن يظهر هذا اليتيم بأية عمليات بحث أو طباعة أو كفالات هل تريد المتابعة؟", MsgBoxStyle.Question Or MsgBoxStyle.YesNo)
            If retD = vbYes Then
                Dim DeletedRows As New ArrayList()
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                    Using Odb As New OrphanageDB.Odb
                        Dim orph As OrphanageClasses.Orphan = Getter.GetOrphanByID(CType(row.Cells("ID").Value, Integer), Odb)
                        If IsNothing(orph.IsExcluded) OrElse Not orph.IsExcluded Then
                            If Not Deleter.ExcludeOrphan(orph.ID) Then
                                ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج استبعاد القيد " & Getter.GetFullName(orph.Name), True, True))
                                Exit Sub
                            Else
                                ExceptionsManager.RaiseOnStatus(New MyException("تم استبعاد القيد " & Getter.GetFullName(orph.Name), False, False))
                                DeletedRows.Add(row)
                                Try
                                    Updater.UpdatesBondsMan(orph.BondsMan_ID)
                                    Updater.UpdatesOrphan(orph)
                                    Updater.UpdatesFamily(orph.Family)
                                    Updater.UpdatesFather(orph.Family.Father)
                                    Updater.UpdatesMother(orph.Family.Mother)
                                    Updater.UpdatesSupporter(orph.Supporter)
                                    If orph.Bail_ID.HasValue Then
                                        Updater.UpdatesBail(orph.Bail)
                                    End If
                                Catch
                                End Try
                            End If
                        Else
                            If Not Deleter.UnExcludeOrphan(orph.ID) Then
                                ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج استرداد القيد " & Getter.GetFullName(orph.Name), True, True))
                                Exit Sub
                            Else
                                ExceptionsManager.RaiseOnStatus(New MyException("تم استرداد القيد " & Getter.GetFullName(orph.Name), False, False))
                                Try
                                    Updater.UpdatesBondsMan(orph.BondsMan_ID)
                                    Updater.UpdatesOrphan(orph)
                                    Updater.UpdatesFamily(orph.Family)
                                    Updater.UpdatesFather(orph.Family.Father)
                                    Updater.UpdatesMother(orph.Family.Mother)
                                    Updater.UpdatesSupporter(orph.Supporter)
                                    If orph.Bail_ID.HasValue Then
                                        Updater.UpdatesBail(orph.Bail)
                                    End If
                                Catch
                                End Try

                            End If
                        End If
                        Odb.Dispose()
                    End Using
                Next
                If Not My.Settings.ShowHiddenObject Then
                    For Each row As Telerik.WinControls.UI.GridViewRowInfo In DeletedRows
                        radDataGrid.Rows.Remove(row)
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSetColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetColor.Click
        Try
            RemoveHandler Me.radDataGrid.RowFormatting, AddressOf radDataGrid_RowFormatting
            'ColorCd.ObjectTrackingEnabled = False
            Dim ColDia As New ColorDialog()
            If ColDia.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim i As Decimal = 0D
                Dim all As Decimal = radDataGrid.SelectedRows.Count
                For Each itm As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                    Using ColorCd As New OrphanageDB.Odb
                        Dim indexId As Integer = CInt(itm.Cells("ID").Value)
                        Dim q = From qfath In ColorCd.Orphans Where qfath.ID = indexId Select qfath
                        Dim fath As OrphanageClasses.Orphan = q.FirstOrDefault()
                        If Not IsNothing(fath) Then
                            If ColDia.Color <> Color.White Then
                                fath.Color_Mark = ColDia.Color.ToArgb()
                            Else
                                fath.Color_Mark = Nothing
                            End If
                            ColorCd.SubmitChanges()
                            If IDSColors.ContainsKey(fath.ID) Then IDSColors.Remove(fath.ID)
                            Try
                                Updater.UpdatesOrphan(fath)
                            Catch
                            End Try
                        End If
                        i += 1
                        Dim val As Integer
                        val = CInt((i / all) * 100D)
                        ProgressSate.ShowStatueProgress(val, "")
                        ColorCd.Dispose()
                    End Using
                Next
            End If
            ColDia.Dispose()
            AddHandler Me.radDataGrid.RowFormatting, AddressOf radDataGrid_RowFormatting
        Catch ex As Exception
            AddHandler Me.radDataGrid.RowFormatting, AddressOf radDataGrid_RowFormatting
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True))
            ProgressSate.ShowStatueProgress(100, "")
        End Try
    End Sub

    Private Sub btnColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColumn.Click
        radDataGrid.ColumnChooser.Text = "الأعمدة"
        radDataGrid.ColumnChooser.ColumnChooserControl.ColumnChooserElement.Text = "اسحب الأعمدة من و إلى الشبكة"
        radDataGrid.ColumnChooser.Show()
    End Sub

    Private Sub btnShowOrphans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowOrphans.Click, SubSOrphans.Click
        Try
            If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
                Dim orphs As New ArrayList
                For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                    Dim OrphID As Integer = CInt(row.Cells("ID").Value)
                    Dim orps As Integer() = Getter.GetOrphanBrothers(OrphID)
                    If Not IsNothing(orps) Then
                        For Each orp In orps
                            If Not orphs.Contains(orp) Then
                                orphs.Add(orp)
                            End If
                        Next
                    End If
                Next
                If orphs.Count > 0 Then
                    WindowsLauncher.LaunchOrphans(CType(orphs.ToArray(GetType(Integer)), Integer()))
                End If
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try

    End Sub

    Public Sub New()
        InitializeComponent()
        Me._CustomView = False
    End Sub
    Public Sub New(ByVal OnlyBailed As Boolean)
        InitializeComponent()
        Me._CustomView = True
        Me._BailedOrphanOnly = OnlyBailed
    End Sub
    Public Sub New(ByVal ids() As Integer)
        InitializeComponent()
        Me._CustomView = True
        Me._Ids = ids
    End Sub
    Public Sub New(ByVal orphs As System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan))
        InitializeComponent()
        Me._CustomView = True
        Me._OrphansSet = orphs
    End Sub
    Private Sub btnShowMothers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowMothers.Click, SubSMothers.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) AndAlso radDataGrid.SelectedRows().Count = 0 Then Exit Sub
            Dim orphs As New ArrayList()
            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Dim OrphID As Integer = CInt(row.Cells("ID").Value)
                Dim Moth_Id As Integer = Getter.GetMother_IDByOrphan_ID(OrphID)
                If Not orphs.Contains(Moth_Id) Then
                    orphs.Add(Moth_Id)
                    If OrphID Mod 5 = 0 Then Application.DoEvents()
                End If
            Next
            If orphs.Count > 0 Then
                WindowsLauncher.LaunchMothers(CType(orphs.ToArray(GetType(Integer)), Integer()))
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
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

    Private Sub btnShowFathers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowFathers.Click, SubSFAthers.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) AndAlso radDataGrid.SelectedRows().Count = 0 Then Exit Sub
            Dim fam As New ArrayList
            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Dim OrphID As Integer = CInt(row.Cells("ID").Value)
                Dim fath_ID As Integer = Getter.GetFather_IDByOrphan_ID(OrphID)
                If Not fam.Contains(fath_ID) Then
                    fam.Add(fath_ID)
                End If
            Next
            If fam.Count > 0 Then
                WindowsLauncher.LaunchFathers(CType(fam.ToArray(GetType(Integer)), Integer()))
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub btnShowFamilies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowFamilies.Click, SubSFamilies.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) AndAlso radDataGrid.SelectedRows().Count = 0 Then Exit Sub
            Dim fam As New ArrayList()
            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Using Odb As New OrphanageDB.Odb
                    Dim OrphID As Integer = CInt(row.Cells("ID").Value)
                    Dim Orp As OrphanageClasses.Orphan = Getter.GetOrphanByID(OrphID, Odb)
                    If Not fam.Contains(Orp.Family_ID) Then
                        fam.Add(Orp.Family_ID)
                        If Orp.Family_ID Mod 3 = 0 Then Application.DoEvents()
                    End If
                    Odb.Dispose()
                End Using
            Next
            If fam.Count > 0 Then
                WindowsLauncher.LaunchFamilies(CType(fam.ToArray(GetType(Integer)), Integer()))
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
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

    Private Sub BtnBail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBail.Click, SubOBail.Click
        Try
            Dim Oid As Integer = 0
            Dim Oids As New Dictionary(Of Integer, GridViewRowInfo)
            If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
                For Each ros In radDataGrid.SelectedRows
                    Oid = CInt(ros.Cells("ID").Value)
                    If Not Oids.ContainsKey(Oid) Then
                        Oids.Add(Oid, ros)
                    End If
                Next
            End If
            If Oid = 0 OrElse Oids.Count = 0 Then Return
            Dim FamsIds() As Integer = Oids.Keys.ToArray()
            Dim BailClass As New Bails(FamsIds, False, My.Settings.BailsReplaceAll)
            BailClass.CancelFamiliesBails = My.Settings.CancelFamiliesBails
            BailClass.CancelOrphansBails = My.Settings.BailsCancelOrphansBails
            If Not BtnBail.ToolTipText.Contains("غاء") Then
                BailClass.DoBails()
            Else
                BailClass.UnDoBails()
            End If
            For Each orpId As Integer In Oids.Keys
                If BailClass.SkipedIds.Contains(orpId) Then Continue For
                If Not IsNothing(Oids(orpId)) Then
                    If My.Settings.UseColors AndAlso My.Settings.UseSupporterColorForBails Then
                        If BailClass.HasSuporterColor Then
                            For Each cel As GridViewCellInfo In Oids(orpId).Cells
                                cel.Style.CustomizeFill = True
                                cel.Style.DrawFill = True
                                cel.Style.ForeColor = BailClass.SupporterColor
                                cel.Style.BackColor = Nothing
                            Next
                        End If
                    End If
                End If
                If Not IsNothing(orpId) And orpId > 0 Then
                    Using Odb As New OrphanageDB.Odb
                        Dim fororpID As Integer = orpId
                        Dim q = From fam In Odb.Orphans Where fam.ID = fororpID Select fam
                        Try
                            UpdatesOrphan(q.FirstOrDefault())
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

    Private Sub radDataGrid_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles radDataGrid.CellDoubleClick
        Dim img As Image = Nothing
        Dim str As String = Nothing
        If e.Column.Name = "FullPhoto" OrElse e.Column.Name = "FacePhoto" Then
            If Not IsNothing(e.Value) AndAlso Not IsDBNull(e.Value) Then
                Try
                    Using Odb As New OrphanageDB.Odb
                        Dim mem As New MemoryStream(CType(e.Value, Byte()))
                        img = Image.FromStream(mem)
                        str = Getter.GetFullName(Getter.GetOrphanByID(CInt(e.Row.Cells("ID").Value), Odb).Name)
                        Dim frm As New FrmShowPic(img, str)
                        frm.MdiParent = My.Application.OpenForms("FrmMain")
                        frm.Show()
                        WindowsLauncher.AllWindows.Add(frm)
                        Odb.Dispose()
                    End Using
                Catch

                End Try
            End If
        End If
    End Sub

    Private Sub PictureBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        Dim img As Image = Nothing
        Dim str As String = Nothing
        If Not IsNothing(PictureBox1.Image) Then
            Try
                Using Odb As New OrphanageDB.Odb
                    img = PictureBox1.Image
                    str = Getter.GetFullName(Getter.GetOrphanByID(CInt(radDataGrid.SelectedRows(0).Cells("ID").Value), Odb).Name)
                    Dim frm As New FrmShowPic(img, str)
                    frm.MdiParent = My.Application.OpenForms("FrmMain")
                    frm.Show()
                    WindowsLauncher.AllWindows.Add(frm)
                    Odb.Dispose()
                End Using
            Catch

            End Try
        End If
    End Sub

    Private Sub SubSBondsMen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubSBondsMen.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) AndAlso radDataGrid.SelectedRows().Count = 0 Then Exit Sub
            Dim bondsIds As New ArrayList()
            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Dim OrphID As Integer = CInt(row.Cells("ID").Value)
                Dim bond_Id As Integer = Getter.GetBondsMan_IDByOrphan_ID(OrphID)
                If Not bondsIds.Contains(bond_Id) Then
                    bondsIds.Add(bond_Id)
                End If
            Next
            If bondsIds.Count > 0 Then
                WindowsLauncher.LaunchBondsMen(CType(bondsIds.ToArray(GetType(Integer)), Integer()))
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub SubSSupporters_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubSSupporters.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) AndAlso radDataGrid.SelectedRows().Count = 0 Then Exit Sub
            Dim fam As New ArrayList()
            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Dim OrphID As Integer = CInt(row.Cells("ID").Value)
                Dim supp_id As Integer = Getter.GetSupporter_IDByOrphan_ID(OrphID)
                If Not fam.Contains(supp_id) Then
                    fam.Add(supp_id)
                End If
            Next
            If fam.Count > 0 Then
                WindowsLauncher.LaunchSupporters(CType(fam.ToArray(GetType(Integer)), Integer()))
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub SubSBails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubSBails.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) AndAlso radDataGrid.SelectedRows().Count = 0 Then Exit Sub
            Dim fam As New System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan)()

            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Using Odb As New OrphanageDB.Odb
                    Dim OrphID As Integer = CInt(row.Cells("ID").Value)
                    Dim Orp As OrphanageClasses.Orphan = Getter.GetOrphanByID(OrphID, Odb)
                    If Not fam.Contains(Orp) Then
                        fam.Add(Orp)
                    End If
                    Odb.Dispose()
                End Using
            Next

            If fam.Count > 0 Then
                WindowsLauncher.LaunchBails(fam)
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub SubSBills_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubSBills.Click
        Try
            If IsNothing(radDataGrid.SelectedRows()) AndAlso radDataGrid.SelectedRows().Count = 0 Then Exit Sub
            Dim fam As New System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan)()

            For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                Using Odb As New OrphanageDB.Odb
                    Dim OrphID As Integer = CInt(row.Cells("ID").Value)
                    Dim Orp As OrphanageClasses.Orphan = Getter.GetOrphanByID(OrphID, Odb)
                    If Not fam.Contains(Orp) Then
                        fam.Add(Orp)
                    End If
                    Odb.Dispose()
                End Using
            Next

            If fam.Count > 0 Then
                WindowsLauncher.LaunchBails(fam)
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub SubOBill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubOBill.Click

    End Sub


    Private Sub radDataGrid_CellClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles radDataGrid.CellClick
        For Each index As Integer In _SeletedRows
            Me.IsLoading = True
            'RemoveHandler radDataGrid.SelectionChanged, AddressOf Me.RadGridView1_SelectionChanged            
            radDataGrid.Rows(index).IsSelected = True
            'AddHandler radDataGrid.SelectionChanged, AddressOf Me.RadGridView1_SelectionChanged
            Me.IsLoading = False
        Next
        If e.Row.GetType.FullName.Contains("Filter") Then
            Exit Sub
        End If
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
        lblStatus.Text = StrCount & " المحدد " & radDataGrid.SelectedRows.Count
    End Sub


    Private Sub radDataGrid_RowFormatting(sender As System.Object, e As Telerik.WinControls.UI.RowFormattingEventArgs) Handles radDataGrid.RowFormatting
        'If _StopValidation OrElse Me.IsLoading Then Exit Sub
        SyncLock obj
            Layouts.DrawRowColorsOrphan(e, IDSColors, _isClosing)
        End SyncLock
    End Sub
    'Public Class gridBehavior
    '    Inherits BaseGridBehavior
    '    Private Parent As frmOrphans
    '    Public Sub New(oParent As frmOrphans)
    '        Me.Parent = oParent
    '    End Sub
    '    Public Overrides Function OnMouseWheel(e As MouseEventArgs) As Boolean
    '        Me.Parent.IsLoading = True
    '        Console.WriteLine(e.Delta)
    '        Dim ret As Boolean = MyBase.OnMouseWheel(e)
    '        Me.Parent.IsLoading = False
    '        Return ret
    '    End Function
    'End Class


    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Console.WriteLine("Start at " & Now)        
        Dim Bailed = radDataGrid.Rows.OrderByDescending(Function(x) CBool(x.Cells("IsBailed").Value))
        For Each row In Bailed
            Try
                Dim Fid As Integer = CInt(row.Cells("ID").Value)
                If _isClosing Then
                    Control.CheckForIllegalCrossThreadCalls = True
                    Exit Sub
                End If
                Dim ColorM As Color
                If Not IDSColors.Keys.Contains(Fid) Then
                    If Not CBool(row.Cells("IsBailed").Value) AndAlso (Not IsNothing(row.Cells("Color_Mark").Value) AndAlso Not IsDBNull(row.Cells("Color_Mark").Value)) Then
                        ColorM = Color.FromArgb(row.Cells("Color_Mark").Value)
                    Else
                        ColorM = Getter.GetOrphanColor(Fid)
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
