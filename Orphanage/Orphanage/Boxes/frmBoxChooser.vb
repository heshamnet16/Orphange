Imports Orphanage.OrphanageClasses

Public Class FrmBoxChooser
    'Private Odb As New OrphanageDB.Odb()
    Private _SelectedBox As Integer
    Public Sub SetGridFont(ByVal fon As Font)
        RadListView1.Font = fon
        RadListView1.Refresh()
        SearchControl1.Font = fon
    End Sub
    Public ReadOnly Property SelectedBox As Integer
        Get
            Return _SelectedBox
        End Get
    End Property
    Private _SelectedBoxes() As Box = Nothing
    Public ReadOnly Property SelectedBoxes As Box()
        Get
            Return _SelectedBoxes
        End Get
    End Property
    Public Sub New(ByVal MultiSelect As Boolean)
        InitializeComponent()
        Try
            Dim i As Integer = 0
            Dim all As Integer = 0
            Dim PerValue = 0, LastPerValue As Integer = 0
            RadListView1.MultiSelect = MultiSelect
            Using Odb As New OrphanageDB.Odb
                Dim q = From bo In Odb.Boxes _
                        Select bo

                all = q.Count
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    For Each bx In q
                        PerValue = CInt(Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100)))
                        Dim itm As New Telerik.WinControls.UI.ListViewDataItem(CStr(bx.ID), New String() {bx.ID.ToString(), bx.Name, bx.Currency_Name, bx.Amount.ToString()})
                        RadListView1.Items.Add(itm)
                        i += 1
                        If LastPerValue <> PerValue Then
                            ProgressSate.ShowStatueProgress(PerValue, "")
                            LastPerValue = PerValue
                        End If
                    Next
                    ProgressSate.ShowStatueProgress(100, "")
                End If
            End Using
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
            Using Odb As New OrphanageDB.Odb
                Dim q = From bx In Odb.Boxes _
                        Select bx
                all = q.Count
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    For Each bx In q
                        If Not Ids.Contains(bx.ID) Then Continue For
                        PerValue = CInt(Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100)))
                        Dim itm As New Telerik.WinControls.UI.ListViewDataItem(CStr(bx.ID), New String() {bx.ID.ToString(), bx.Name, bx.Currency_Name, bx.Amount.ToString()})
                        RadListView1.Items.Add(itm)
                        i += 1
                        If LastPerValue <> PerValue Then
                            ProgressSate.ShowStatueProgress(PerValue, "")
                            LastPerValue = PerValue
                        End If
                    Next
                    ProgressSate.ShowStatueProgress(100, "")
                End If
            End Using
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
                    Dim retBond As Box = Getter.GetBoxByID(CInt(itm.Text), Odb)
                    If Not ar.Contains(retBond) Then
                        ar.Add(retBond)
                    End If
                Next
                If ar.Count > 0 Then
                    ReDim Me._SelectedBoxes(ar.Count)
                    Dim i = 0
                    For Each ft As Box In ar
                        Me._SelectedBoxes(i) = ft
                        i += 1
                    Next
                Else
                    Me._SelectedBoxes = Nothing
                End If                
            End Using
        End If
        If Not IsNothing(RadListView1.SelectedItem) Then
            Me._SelectedBox = CInt(RadListView1.SelectedItem.Text)
        End If
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
        RadListView1.Font = My.Settings.ListsFont
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
        lblStatu.Text = CStr(RadListView1.SelectedItems.Count)
    End Sub

    Private Sub RadListView1_SelectedItemsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadListView1.SelectedItemsChanged
        lblStatu.Text = CStr(RadListView1.SelectedItems.Count)
    End Sub

    Private Sub SearchControl1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchControl1.KeyUp
        If e.KeyCode = Keys.Enter Then
            SearchControl1_SearchButtonClick(Nothing, Nothing)
        End If
    End Sub

End Class
