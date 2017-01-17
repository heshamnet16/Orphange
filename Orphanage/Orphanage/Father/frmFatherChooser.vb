Imports Orphanage.OrphanageClasses

Public Class FrmFatherChooser
    'Private Odb As New OrphanageDB.Odb()
    Private _SelectedFather As Integer = -1
    Private _SelectedFamily As Integer = -1
    Private _WithParameters As Boolean = False
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
    Public ReadOnly Property SelectedFather As Integer
        Get
            Return _SelectedFather
        End Get
    End Property
    Private _SelectedFathers() As Integer = Nothing
    Public ReadOnly Property SelectedFathers As Integer()
        Get
            Return _SelectedFathers
        End Get
    End Property
    Public Sub New(ByVal MultiSelect As Boolean)
        InitializeComponent()
        'Try
        Dim i As Integer = 0
        Dim all As Integer = 0
        Dim PerValue = 0, LastPerValue As Integer = 0
        RadListView1.MultiSelect = MultiSelect
        '    Dim q = From fath In Odb.Fathers _
        '            Select fath

        '    all = q.Count
        '    If Not IsNothing(q) AndAlso q.Count > 0 Then
        '        For Each fat In q
        '            PerValue = Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100))
        '            Dim FatherFullName As String = Getter.GetFullName(fat.Name)
        '            Dim MotherFullName As String = ""
        '            If Not IsNothing(fat.Families) AndAlso fat.Families.Count <> 0 Then
        '                If fat.Families.Count > 1 Then
        '                    For Each fam As Family In fat.Families
        '                        If Not My.Settings.ShowHiddenObject Then
        '                            If fam.IsExcluded Then Continue For
        '                        End If
        '                        Dim grouped As New Telerik.WinControls.UI.ListViewDataItemGroup(FatherFullName)
        '                        RadListView1.Groups.Add(grouped)
        '                        MotherFullName = Getter.GetFullName(fam.Mother.Name)
        '                        Dim Initm As New Telerik.WinControls.UI.ListViewDataItem(fat.ID, New String() {fat.ID.ToString(), FatherFullName, MotherFullName, fat.Dieday.ToString("yyyy/MM/dd"), fam.Orphans.Count, fam.UnOrphans.Count})
        '                        Initm.Group = grouped
        '                        If Not IsNothing(fat.Color_Mark) AndAlso fat.Color_Mark <> 0 Then
        '                            Initm.BackColor = Color.FromArgb(fat.Color_Mark)
        '                        End If
        '                        RadListView1.Items.Add(Initm)
        '                    Next
        '                Else
        '                    Dim fam As Family = fat.Families(0)
        '                    If Not My.Settings.ShowHiddenObject Then
        '                        If fam.IsExcluded Then Continue For
        '                    End If
        '                    MotherFullName = Getter.GetFullName(fam.Mother.Name)
        '                    Dim itm As New Telerik.WinControls.UI.ListViewDataItem(fat.ID, New String() {fat.ID.ToString(), FatherFullName, MotherFullName, fat.Dieday.ToString("yyyy/MM/dd"), fam.Orphans.Count, fam.UnOrphans.Count})
        '                    Dim grouped As New Telerik.WinControls.UI.ListViewDataItemGroup(FatherFullName)
        '                    RadListView1.Groups.Add(grouped)
        '                    itm.Group = grouped
        '                    If Not IsNothing(fat.Color_Mark) AndAlso fat.Color_Mark <> 0 Then
        '                        itm.BackColor = Color.FromArgb(fat.Color_Mark)
        '                    End If
        '                    RadListView1.Items.Add(itm)
        '                End If
        '            End If
        '            i += 1
        '            If LastPerValue <> PerValue Then
        '                ProgressSate.ShowStatueProgress(PerValue, "")
        '                LastPerValue = PerValue
        '            End If
        '        Next
        '    End If
        'Catch ex As Exception
        '    ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        'End Try
    End Sub
    Public Sub New(ByVal MultiSelect As Boolean, ByVal Ids() As Integer)
        InitializeComponent()
        Try
                Dim i As Integer = 0
                Dim PerValue = 0, LastPerValue As Integer = 0
                Dim all As Integer = 0
                RadListView1.MultiSelect = MultiSelect
                _WithParameters = True
            all = Ids.Count
            For Each fat_id In Ids
                Using Odb As New OrphanageDB.Odb
                    Dim mot_id As Integer = fat_id
                    Dim q = From mo In Odb.Mothers Where mot_id = mo.ID Select mo
                    Dim fat As Mother = q.FirstOrDefault()
                    If IsNothing(fat) Then Continue For
                    PerValue = Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100))
                    Dim FatherFullName As String = Getter.GetFullName(fat.Name)
                    Dim MotherFullName As String = ""
                    If Not IsNothing(fat.Families) AndAlso fat.Families.Count <> 0 Then
                        If fat.Families.Count > 1 Then
                            For Each fam As Family In fat.Families
                                If Not My.Settings.ShowHiddenObject Then
                                    If fam.IsExcluded Then Continue For
                                End If
                                Dim grouped As New Telerik.WinControls.UI.ListViewDataItemGroup(FatherFullName)
                                RadListView1.Groups.Add(grouped)
                                MotherFullName = Getter.GetFullName(fam.Mother.Name)
                                Dim Initm As New Telerik.WinControls.UI.ListViewDataItem(fat.ID, New String() {fat.ID.ToString(), FatherFullName, MotherFullName, fat.Dieday.ToString(My.Settings.GeneralDateFormat), Getter.GetFatherOrphansNum(fat.ID), fam.UnOrphans.Count})
                                Initm.Group = grouped
                                If Not IsNothing(fat.Color_Mark) AndAlso fat.Color_Mark <> 0 Then
                                    Initm.BackColor = Color.FromArgb(fat.Color_Mark)
                                End If
                                RadListView1.Items.Add(Initm)
                            Next
                        Else
                            Dim fam As Family = fat.Families(0)
                            If Not My.Settings.ShowHiddenObject Then
                                If fam.IsExcluded Then Continue For
                            End If
                            MotherFullName = Getter.GetFullName(fam.Mother.Name)
                            Dim itm As New Telerik.WinControls.UI.ListViewDataItem(fat.ID, New String() {fat.ID.ToString(), FatherFullName, MotherFullName, fat.Dieday.ToString(My.Settings.GeneralDateFormat), Getter.GetFatherOrphansNum(fat.ID), fam.UnOrphans.Count})
                            Dim grouped As New Telerik.WinControls.UI.ListViewDataItemGroup(FatherFullName)
                            RadListView1.Groups.Add(grouped)
                            itm.Group = grouped
                            If Not IsNothing(fat.Color_Mark) AndAlso fat.Color_Mark <> 0 Then
                                itm.BackColor = Color.FromArgb(fat.Color_Mark)
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
        Using odb As New OrphanageDB.Odb
            If RadListView1.MultiSelect Then
                Dim ar As New ArrayList()
                For Each itm In RadListView1.SelectedItems
                    Dim retFath As Integer = CInt(itm.Text)
                    If Not ar.Contains(retFath) Then
                        ar.Add(retFath)
                    End If
                Next
                If ar.Count > 0 Then
                    Me._SelectedFathers = CType(ar.ToArray(GetType(Integer)), Integer())
                Else
                    Me._SelectedFathers = Nothing
                End If
            End If
            If Not IsNothing(RadListView1.SelectedItem) Then
                Me._SelectedFather = CInt(RadListView1.SelectedItem.Text)
                Dim fams() As Integer = Getter.GetFatherFamiles(Me._SelectedFather)
                If Not IsNothing(fams) AndAlso fams.Count > 1 Then
                    For Each fam In fams
                        Dim Fam_Id As Integer = fam
                        Dim q = From mot In odb.Mothers Join famr In odb.Families On
                                mot.ID Equals famr.Mother_ID _
                                Where famr.ID = Fam_Id _
                                Select mot.Name
                        Dim MotherFullName As String = Getter.GetFullName(q.FirstOrDefault())
                        If IsNothing(MotherFullName) Then Continue For
                        If MotherFullName.Substring(0, 3) = RadListView1.SelectedItem(2).ToString().Substring(0, 3) _
                            AndAlso MotherFullName.Substring(MotherFullName.Length - 4, 3) = RadListView1.SelectedItem(2).ToString().Substring(RadListView1.SelectedItem(2).ToString().Length - 4, 3) Then
                            Me._SelectedFamily = fam
                            Exit For
                        End If
                    Next
                Else
                    Me._SelectedFamily = fams(0)
                End If

            End If
        End Using
        If My.Settings.SaveWindowsState Then
            Layouts.SaveFormLayout(Me)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmFatherChooser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If _WithParameters = False Then
            If My.Settings.ShowHiddenObject Then
                Me.FamliesSelectorTableAdapter.Fill(Me.OrphansDBDataSet.FamliesSelector)
            Else
                Me.FamliesSelectorTableAdapter.FillByUnExcluded(Me.OrphansDBDataSet.FamliesSelector)
            End If
            RadListView1.BeginEdit()
            RadListView1.Columns(0).Width = 30
            RadListView1.Columns(1).Width = 100
            RadListView1.Columns(2).Width = 100
            RadListView1.Columns(3).Width = 80
            RadListView1.Columns(4).Width = 80
            RadListView1.Columns(0).HeaderText = "الرقم"
            RadListView1.Columns(1).HeaderText = "اسم المتوفى"
            RadListView1.Columns(2).HeaderText = "اسم الزوجة"
            RadListView1.Columns(3).HeaderText = "تاريخ الوفاة"
            RadListView1.Columns(4).HeaderText = "عدد الأيتام"
            RadListView1.EndEdit()
        End If
        If My.Settings.SaveWindowsState Then
            Layouts.LoadFormLayout(Me)
        End If
        RadListView1.Font = Me.Font
    End Sub

    Private Sub SearchControl1_SearchButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchControl1.SearchButtonClick
        For Each itm In RadListView1.Items
            For i As Integer = 1 To RadListView1.Columns.Count - 1
                If InStr(itm(i).ToString(), SearchControl1.SearchedText) > 0 Then
                    itm.Visible = True
                    'itm.Group.Visible = True                    
                    Exit For
                Else
                    itm.Visible = False
                    'itm.Group.Visible = False
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

    Private Sub SearchControl1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchControl1.KeyUp
        If e.KeyCode = Keys.Enter Then
            SearchControl1_SearchButtonClick(Nothing, Nothing)
        End If
    End Sub
End Class
