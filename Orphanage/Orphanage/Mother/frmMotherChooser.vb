Imports Orphanage.OrphanageClasses

Public Class FrmMotherChooser
    'Private Odb As New OrphanageDB.Odb()
    Private _SelectedMother As Integer = -1
    Private _SelectedFamily As Integer = -1
    Public ReadOnly Property SelectedFamily As Integer
        Get
            Return _SelectedFamily
        End Get
    End Property
    Public Sub SetGridFont(ByVal fon As Font)
        RadListView1.Font = fon
        RadListView1.Refresh()
        SearchControl1.Font = fon
    End Sub
    Public ReadOnly Property SelectedMother As Integer
        Get
            Return _SelectedMother
        End Get
    End Property
    Private _SelectedMothers() As Integer = Nothing
    Public ReadOnly Property SelectedMothers As Integer()
        Get
            Return _SelectedMothers
        End Get
    End Property
    Public Sub New(ByVal MultiSelect As Boolean)
        InitializeComponent()
        Try
            Dim i As Integer = 0
            Dim all As Integer = 0
            Dim PerValue = 0, LastPerValue As Integer = 0
            RadListView1.MultiSelect = MultiSelect
            Dim allIds As New ArrayList()
            Using Odb As New OrphanageDB.Odb
                Dim q = From fath In Odb.Mothers _
                        Where fath.ID > 0
                        Select fath.ID

                allIds.AddRange(q.ToArray())
                Odb.Dispose()
            End Using
            all = allIds.Count
            If allIds.Count > 0 Then
                For Each fat_id In allIds
                    PerValue = Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100))
                    Using Odb As New OrphanageDB.Odb
                        Dim mot_Id As Integer = fat_id
                        Dim qfath = From fater In Odb.Mothers Where fater.ID = mot_Id Select fater
                        Dim fat As OrphanageClasses.Mother = qfath.FirstOrDefault()
                        If IsNothing(fat) Then Continue For
                        Dim FatherFullName As String = ""
                        Dim MotherFullName As String = fat.Name.First & " " & fat.Name.Father & " " & fat.Name.Last
                        If Not IsNothing(fat.Families) AndAlso fat.Families.Count <> 0 Then
                            If fat.Families.Count > 1 Then
                                Dim grouped As New Telerik.WinControls.UI.ListViewDataItemGroup(MotherFullName)
                                RadListView1.Groups.Add(grouped)
                                For Each fam As Family In fat.Families
                                    If Not My.Settings.ShowHiddenObject Then
                                        If fam.IsExcluded Then Continue For
                                    End If
                                    FatherFullName = Getter.GetFullName(fam.Father.Name)
                                    Dim age As String = Nothing
                                    If fat.IsDead AndAlso fat.Dieday.HasValue Then
                                        age = ATDFormater.ArabicDateFormater.GetArabicYear(New Itenso.TimePeriod.DateDiff(fat.Birthday, fat.Dieday.Value).ElapsedYears)
                                    Else
                                        age = ATDFormater.ArabicDateFormater.GetArabicYear(New Itenso.TimePeriod.DateDiff(fat.Birthday, Date.Now).ElapsedYears)
                                    End If
                                    Dim Initm As New Telerik.WinControls.UI.ListViewDataItem(fat.ID, New String() {fat.ID.ToString(), MotherFullName, FatherFullName, age, fam.Orphans.Count, (fam.UnOrphans.Count + fam.Orphans.Count)})
                                    Initm.Group = grouped
                                    If fat.Color_Mark.HasValue Then
                                        Initm.BackColor = Color.FromArgb(CInt(fat.Color_Mark.Value))
                                    Else
                                        If fam.Color_Mark.HasValue Then
                                            Initm.BackColor = Color.FromArgb(CInt(fam.Color_Mark.Value))
                                        End If
                                    End If
                                    RadListView1.Items.Add(Initm)
                                    'Initm.Dispose()
                                Next
                            Else
                                Dim age As String = Nothing
                                If fat.IsDead AndAlso fat.Dieday.HasValue Then
                                    age = ATDFormater.ArabicDateFormater.GetArabicYear(New Itenso.TimePeriod.DateDiff(fat.Birthday, fat.Dieday.Value).ElapsedYears)
                                Else
                                    age = ATDFormater.ArabicDateFormater.GetArabicYear(New Itenso.TimePeriod.DateDiff(fat.Birthday, Date.Now).ElapsedYears)
                                End If
                                Dim fam As Family = fat.Families(0)
                                If Not My.Settings.ShowHiddenObject Then
                                    If fam.IsExcluded Then Continue For
                                End If
                                FatherFullName = fam.Father.Name.First & " " & fam.Father.Name.Father & " " & fam.Father.Name.Last
                                Dim itm As New Telerik.WinControls.UI.ListViewDataItem(fat.ID, New String() {fat.ID.ToString(), MotherFullName, FatherFullName, age, fam.Orphans.Count, (fam.UnOrphans.Count + fam.Orphans.Count)})
                                Dim grouped As New Telerik.WinControls.UI.ListViewDataItemGroup(MotherFullName)
                                RadListView1.Groups.Add(grouped)
                                itm.Group = grouped
                                If fat.Color_Mark.HasValue Then
                                    itm.BackColor = Color.FromArgb(CInt(fat.Color_Mark.Value))
                                Else
                                    If fam.Color_Mark.HasValue Then
                                        itm.BackColor = Color.FromArgb(CInt(fam.Color_Mark.Value))
                                    End If
                                End If
                                RadListView1.Items.Add(itm)
                            End If
                        End If
                        i += 1
                        If LastPerValue <> PerValue Then
                            ProgressSate.ShowStatueProgress(PerValue, "")
                            LastPerValue = PerValue
                        End If
                        Odb.Dispose()
                    End Using
                Next
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub
    Public Sub New(ByVal MultiSelect As Boolean, ByVal Ids() As Integer)
        InitializeComponent()
        Try
            Dim i As Integer = 0
            Dim all As Integer = 0
            Dim PerValue = 0, LastPerValue As Integer = 0
            RadListView1.MultiSelect = MultiSelect
            all = Ids.Length
            For Each fat_id In Ids
                Using Odb As New OrphanageDB.Odb
                    Dim moth_id As Integer = fat_id
                    Dim q = From mo In Odb.Mothers Where mo.ID = moth_id Select mo

                    Dim fat As OrphanageClasses.Mother = q.FirstOrDefault()
                    If IsNothing(fat) Then Continue For
                    PerValue = CInt(Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100)))
                    Dim FatherFullName As String = ""
                    Dim MotherFullName As String = Getter.GetFullName(fat.Name)
                    If Not IsNothing(fat.Families) AndAlso fat.Families.Count > 0 Then
                        If fat.Families.Count > 1 Then
                            Dim grouped As New Telerik.WinControls.UI.ListViewDataItemGroup(MotherFullName)
                            RadListView1.Groups.Add(grouped)
                            For Each fam As Family In fat.Families
                                If Not My.Settings.ShowHiddenObject Then
                                    If fam.IsExcluded Then Continue For
                                End If
                                Dim OrphCountArr() As Integer = Getter.GetFamilyOrphans(fam.ID)
                                Dim OrphCount As Integer = 0
                                If Not IsNothing(OrphCountArr) Then
                                    OrphCount = OrphCountArr.Length
                                End If
                                FatherFullName = Getter.GetFullName(fam.Father.Name)
                                Dim age As String = Nothing
                                If fat.IsDead AndAlso fat.Dieday.HasValue Then
                                    age = ATDFormater.ArabicDateFormater.GetArabicYear(New Itenso.TimePeriod.DateDiff(fat.Birthday, fat.Dieday.Value).ElapsedYears)
                                Else
                                    age = ATDFormater.ArabicDateFormater.GetArabicYear(New Itenso.TimePeriod.DateDiff(fat.Birthday, Date.Now).ElapsedYears)
                                End If
                                Dim Initm As New Telerik.WinControls.UI.ListViewDataItem(CStr(fat.ID), New String() {fat.ID.ToString(), MotherFullName, FatherFullName, age, CStr(OrphCount), CStr(OrphCount)})
                                Initm.Group = grouped
                                If fat.Color_Mark.HasValue Then
                                    Initm.BackColor = Color.FromArgb(CInt(fat.Color_Mark.Value))
                                Else
                                    If fam.Color_Mark.HasValue Then
                                        Initm.BackColor = Color.FromArgb(CInt(fam.Color_Mark.Value))
                                    End If
                                End If
                                RadListView1.Items.Add(Initm)
                            Next
                        Else
                            Dim age As String = Nothing
                            If fat.IsDead AndAlso fat.Dieday.HasValue Then
                                age = ATDFormater.ArabicDateFormater.GetArabicYear(New Itenso.TimePeriod.DateDiff(fat.Birthday, fat.Dieday.Value).ElapsedYears)
                            Else
                                age = ATDFormater.ArabicDateFormater.GetArabicYear(New Itenso.TimePeriod.DateDiff(fat.Birthday, Date.Now).ElapsedYears)
                            End If
                            Dim fam As Family = fat.Families(0)
                            If Not My.Settings.ShowHiddenObject Then
                                If fam.IsExcluded Then Continue For
                            End If
                            FatherFullName = Getter.GetFullName(fam.Father.Name)
                            Dim itm As New Telerik.WinControls.UI.ListViewDataItem(fat.ID, New String() {fat.ID.ToString(), MotherFullName, FatherFullName, age, fam.Orphans.Count, (fam.UnOrphans.Count + fam.Orphans.Count)})
                            Dim grouped As New Telerik.WinControls.UI.ListViewDataItemGroup(MotherFullName)
                            RadListView1.Groups.Add(grouped)
                            itm.Group = grouped
                            If fat.Color_Mark.HasValue Then
                                itm.BackColor = Color.FromArgb(CInt(fat.Color_Mark.Value))
                            Else
                                If fam.Color_Mark.HasValue Then
                                    itm.BackColor = Color.FromArgb(CInt(fam.Color_Mark.Value))
                                End If
                            End If
                            RadListView1.Items.Add(itm)
                        End If
                    End If
                    i += 1
                    If LastPerValue <> PerValue Then
                        ProgressSate.ShowStatueProgress(PerValue, "")
                        LastPerValue = PerValue
                    End If
                    Odb.Dispose()
                End Using
            Next
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub


    Private Sub RadButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click, RadListView1.DoubleClick
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub FrmFatherChooser_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If RadListView1.MultiSelect Then
            Dim ar As New ArrayList()
            For Each itm In RadListView1.SelectedItems
                Using Odb As New OrphanageDB.Odb
                    Dim retFath As Integer = CInt(itm.Text)
                    If Not ar.Contains(retFath) Then
                        ar.Add(retFath)
                    End If
                    Odb.Dispose()
                End Using
            Next
            If ar.Count > 0 Then
                Me._SelectedMothers = CType(ar.ToArray(GetType(Integer)), Integer())
            Else
                Me._SelectedMothers = Nothing
            End If
        End If
        If Not IsNothing(RadListView1.SelectedItem) Then
            Using Odb As New OrphanageDB.Odb
                Me._SelectedMother = CInt(RadListView1.SelectedItem.Text)
                Dim fams() As Integer = Getter.GetMotherFamiles(Me._SelectedMother)
                If Not IsNothing(fams) AndAlso fams.Count > 1 Then
                    For Each fam In fams
                        Dim fam_id As Integer = fam
                        Dim q = From fath In Odb.Fathers Join
                                fams1 In Odb.Families On fams1.Father_ID Equals fath.ID
                        Where fams1.ID = fam_id Select fath.Name
                        Dim FatherFullName As String = Getter.GetFullName(q.FirstOrDefault())
                        If FatherFullName = RadListView1.SelectedItem(2).ToString() Then
                            Me._SelectedFamily = fam
                            Exit For
                        End If
                    Next
                Else
                    Me._SelectedFamily = fams(0)
                End If
                Odb.Dispose()
            End Using
        End If
        Layouts.SaveFormLayout(Me)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SearchControl1_SearchButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchControl1.SearchButtonClick
        For Each itm In RadListView1.Items
            For i As Integer = 1 To RadListView1.Columns.Count - 1
                If InStr(itm(i).ToString(), SearchControl1.SearchedText) > 0 Then
                    itm.Visible = True
                    itm.Group.Visible = True
                    Exit For
                Else
                    itm.Visible = False
                    itm.Group.Visible = False
                End If
            Next
        Next
    End Sub

    Private Sub RadListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadListView1.SelectedIndexChanged
        lblStatu.Text = RadListView1.SelectedItems.Count
    End Sub

    Private Sub RadListView1_SelectedItemsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadListView1.SelectedItemsChanged
        lblStatu.Text = RadListView1.SelectedItems.Count
    End Sub

    Private Sub FrmMotherChooser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Layouts.LoadFormLayout(Me)
        RadListView1.Font = Me.Font
    End Sub

    Private Sub SearchControl1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchControl1.KeyUp
        If e.KeyCode = Keys.Enter Then
            SearchControl1_SearchButtonClick(Nothing, Nothing)
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
