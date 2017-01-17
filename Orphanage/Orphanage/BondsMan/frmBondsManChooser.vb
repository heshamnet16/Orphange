Imports Orphanage.OrphanageClasses
Public Class frmBondsManChooser
    'Private Odb As New OrphanageDB.Odb()
    Private _SelectedBondsMan As Integer = Nothing
    Public Sub SetGridFont(ByVal fon As Font)
        RadListView1.Font = fon
        RadListView1.Refresh()
        SearchControl1.Font = fon
    End Sub
    Public ReadOnly Property SelectedBondsMan As Integer
        Get
            Return _SelectedBondsMan
        End Get
    End Property
    Private _SelectedBondsMen() As Integer = Nothing
    Public ReadOnly Property SelectedBondsMen As Integer()
        Get
            Return _SelectedBondsMen
        End Get
    End Property
    Public Sub New(ByVal MultiSelect As Boolean)
        InitializeComponent()
        Try
            Dim i As Integer = 0
            Dim all As Integer = 0
            Dim PerValue = 0, LastPerValue As Integer = 0
            RadListView1.MultiSelect = MultiSelect
            Dim AllBonds() As Integer
            Using Odb As New OrphanageDB.Odb
                Dim q = From bo In Odb.BondsMans _
                        Select bo.ID
                all = q.Count
                AllBonds = q.ToArray()
                Odb.Dispose()
            End Using
            If Not IsNothing(AllBonds) AndAlso AllBonds.Count > 0 Then
                For Each bond_idF In AllBonds
                    Using Odb As New OrphanageDB.Odb
                        Dim BondId As Integer = bond_idF
                        Dim bond = Getter.GetBondsManByID(BondId, Odb)
                        PerValue = CInt(Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100)))
                        Dim FatherFullName As String = Getter.GetFullName(bond.Name)
                        Dim Addre As String = ""
                        If Not IsNothing(bond.Address) Then
                            Addre = Getter.GetAddress(bond.Address)
                        End If
                        Dim OrphansCount As Integer = Getter.GetBondsManOrphansNum(BondId)
                        If Not IsNothing(OrphansCount) AndAlso OrphansCount <> 0 Then
                            OrphansCount = OrphansCount
                        Else
                            OrphansCount = 0
                        End If
                        Dim Minc As Integer = 0
                        Dim Jop As String = ""
                        If Not IsNothing(bond.Jop) Then
                            Jop = bond.Jop
                        End If
                        If Not IsNothing(bond.Income) Then
                            Minc = CInt(bond.Income)
                        End If
                        Dim itm As New Telerik.WinControls.UI.ListViewDataItem(CStr(bond.ID), New String() {bond.ID.ToString(), FatherFullName, OrphansCount.ToString(), Jop, CStr(Minc), Addre})
                        If bond.Color_Mark.HasValue AndAlso bond.Color_Mark.Value <> 0 Then
                            itm.BackColor = Color.FromArgb(CInt(bond.Color_Mark.Value))
                        End If
                        RadListView1.Items.Add(itm)
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
            Dim all As Integer = Ids.Length
                Dim PerValue = 0, LastPerValue As Integer = 0
                RadListView1.MultiSelect = MultiSelect
            If Not IsNothing(Ids) AndAlso Ids.Count > 0 Then
                For Each bond_id In Ids
                    Using Odb As New OrphanageDB.Odb
                        Dim BondId As Integer = bond_id
                        Dim bond As OrphanageClasses.BondsMan = Getter.GetBondsManByID(BondId, Odb)
                        If IsNothing(bond) Then Continue For
                        PerValue = CInt(Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100)))
                        Dim FatherFullName As String = Getter.GetFullName(bond.Name)
                        Dim Addre As String = ""
                        If Not IsNothing(bond.Address) Then
                            Addre = Getter.GetAddress(bond.Address)
                        End If
                        Dim OrphansCount As Integer = Getter.GetBondsManOrphansNum(bond_id)
                        If Not IsNothing(OrphansCount) AndAlso OrphansCount <> 0 Then
                            OrphansCount = bond.Orphans.Count
                        Else
                            OrphansCount = 0
                        End If
                        Dim Minc As Integer = 0
                        Dim Jop As String = ""
                        If Not IsNothing(bond.Jop) Then
                            Jop = bond.Jop
                        End If
                        If Not IsNothing(bond.Income) Then
                            Minc = CInt(bond.Income)
                        End If
                        Dim itm As New Telerik.WinControls.UI.ListViewDataItem(CStr(bond.ID), New String() {bond.ID.ToString(), FatherFullName, OrphansCount.ToString(), Jop, CStr(Minc), Addre})
                        If bond.Color_Mark.HasValue AndAlso bond.Color_Mark.Value <> 0 Then
                            itm.BackColor = Color.FromArgb(CInt(bond.Color_Mark.Value))
                        End If
                        RadListView1.Items.Add(itm)
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


    Private Sub RadButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click, RadListView1.DoubleClick
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub FrmBondsmanChooser_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If RadListView1.MultiSelect Then
            Dim ar As New ArrayList()
            Using Odb As New OrphanageDB.Odb
                For Each itm In RadListView1.SelectedItems
                    Dim retBond As Integer = CInt(itm.Text)
                    If Not ar.Contains(retBond) Then
                        ar.Add(retBond)
                    End If
                Next
                If ar.Count > 0 Then
                    Me._SelectedBondsMen = CType(ar.ToArray(GetType(Integer)), Integer())
                Else
                    Me._SelectedBondsMen = Nothing
                End If
                Odb.Dispose()
            End Using
        End If
        If Not IsNothing(RadListView1.SelectedItem) Then
            Me._SelectedBondsMan = CInt(RadListView1.SelectedItem.Text)
        End If
        Layouts.SaveFormLayout(Me)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmFatherChooser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Layouts.LoadFormLayout(Me)
        RadListView1.Font = Me.Font
    End Sub

    Private Sub SearchControl1_SearchButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchControl1.SearchButtonClick
        For Each itm In RadListView1.Items
            For i As Integer = 1 To RadListView1.Columns.Count - 1
                If InStr(itm(i).ToString(), SearchControl1.SearchedText) > 0 Then
                    itm.Visible = True
                    Exit For
                Else
                    itm.Visible = False
                End If
            Next
        Next
    End Sub

    Private Sub RadListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadListView1.SelectedIndexChanged
        lblStatu.Text = CStr(RadListView1.SelectedItems.Count)
    End Sub

    Private Sub RadListView1_SelectedItemsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadListView1.SelectedItemsChanged
        lblStatu.Text = CStr(RadListView1.SelectedItems.Count)
    End Sub

    Private Sub RadListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SearchControl1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchControl1.KeyUp
        If e.KeyCode = Keys.Enter Then
            SearchControl1_SearchButtonClick(Nothing, Nothing)
        End If
    End Sub

End Class
