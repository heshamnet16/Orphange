Imports Orphanage.OrphanageClasses

Public Class FrmOrphansChooser
    Private Odb As New OrphanageDB.Odb()
    Private _SelectedOrphan As Orphan = Nothing
    Public Sub SetGridFont(ByVal fon As Font)
        RadListView1.Font = fon
        RadListView1.Refresh()
        SearchControl1.Font = fon
    End Sub
    Public ReadOnly Property SelectedOrphan As Orphan
        Get
            Return _SelectedOrphan
        End Get
    End Property
    Private _SelectedOrphans() As Orphan = Nothing
    Public ReadOnly Property SelectedOrphans As Orphan()
        Get
            Return _SelectedOrphans
        End Get
    End Property
    Public Sub New(ByVal MultiSelect As Boolean, ByVal Fam_Id As Integer)
        InitializeComponent()
        Try
            Dim i As Integer = 0
            Dim all As Integer = 0
            Dim PerValue = 0, LastPerValue As Integer = 0
            RadListView1.MultiSelect = MultiSelect
            Dim q = From fath In Odb.Orphans _
                    Where fath.Family_ID = Fam_Id
                    Select fath
            all = q.Count
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                RadListView1.BeginUpdate()
                For Each orp In q
                    If Not My.Settings.ShowHiddenObject Then
                        If orp.IsExcluded Then Continue For
                    End If
                    PerValue = Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100))
                    Dim itm As New Telerik.WinControls.UI.ListViewDataItem(orp.ID, New String() {orp.ID.ToString(), Getter.GetFullName(orp.Name), orp.Birthday.ToShortDateString()})
                    If My.Settings.UseColors Then
                        If My.Settings.UseSupporterColorForBails Then
                            If orp.IsBailed AndAlso orp.Bail_ID.HasValue AndAlso orp.Bail.Supporter.Color_Mark.HasValue Then
                                itm.BackColor = Color.FromArgb(orp.Bail.Supporter.Color_Mark)
                            Else
                                If Not IsNothing(orp.Color_Mark) AndAlso orp.Color_Mark <> 0 Then
                                    itm.BackColor = Color.FromArgb(orp.Color_Mark)
                                End If
                            End If
                        Else
                            If Not IsNothing(orp.Color_Mark) AndAlso orp.Color_Mark <> 0 Then
                                itm.BackColor = Color.FromArgb(orp.Color_Mark)
                            End If
                        End If
                    End If
                    RadListView1.Items.Add(itm)
                    i += 1
                    If LastPerValue <> PerValue Then
                        ProgressSate.ShowStatueProgress(PerValue, "")
                        LastPerValue = PerValue
                    End If
                Next
                RadListView1.EndUpdate()
                ProgressSate.ShowStatueProgress(100, "")
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub RadButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click, RadListView1.DoubleClick
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub FrmFatherChooser_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Using Odb As New OrphanageDB.Odb
            If RadListView1.MultiSelect Then
                Dim ar As New ArrayList()
                For Each itm In RadListView1.SelectedItems
                    Dim retFath As Orphan = Getter.GetOrphanByID(CInt(itm.Text), Odb)
                    If Not ar.Contains(retFath) Then
                        ar.Add(retFath)
                    End If
                Next
                If ar.Count > 0 Then
                    ReDim Me._SelectedOrphans(ar.Count)
                    Dim i = 0
                    For Each ft As Orphan In ar
                        Me._SelectedOrphans(i) = ft
                        i += 1
                    Next
                Else
                    Me._SelectedOrphans = Nothing
                End If
            End If
            If Not IsNothing(RadListView1.SelectedItem) Then
                Me._SelectedOrphan = Getter.GetOrphanByID(CInt(RadListView1.SelectedItem.Text), Odb)
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

    Private Sub SearchControl1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchControl1.KeyUp
        If e.KeyCode = Keys.Enter Then
            SearchControl1_SearchButtonClick(Nothing, Nothing)
        End If
    End Sub
End Class
