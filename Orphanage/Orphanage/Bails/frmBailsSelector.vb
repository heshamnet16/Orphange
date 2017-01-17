Imports Orphanage.OrphanageClasses

Public Class FrmBailsSelector
    'Private Odb As New OrphanageDB.Odb()
    Private _SelectedBail As OrphanageClasses.Bail = Nothing
    Private _SelectedBails() As Bail = Nothing
    Public Sub SetGridFont(ByVal fon As Font)
        RadListView1.Font = fon
        RadListView1.Refresh()
        SearchControl1.Font = fon
    End Sub
    Public ReadOnly Property SelectedBail As Bail
        Get
            Return _SelectedBail
        End Get
    End Property
    Public ReadOnly Property SelectedBails As Bail()
        Get
            Return _SelectedBails
        End Get
    End Property
    Public Sub New(ByVal MultiSelect As Boolean)
        InitializeComponent()
        Try
            Dim i As Integer = 0
            Dim all As Integer = 0
            Dim PerValue = 0, LastPerValue As Integer = 0
            RadListView1.MultiSelect = MultiSelect
            Using odb = New OrphanageDB.Odb
                Dim q = From bo In odb.Bails _
                        Where (bo.Is_Ended = False) OrElse bo.Is_Ended = Nothing
                        Select bo
                all = q.Count
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    For Each bal In q
                        If Not bal.Supporter.Is_Still_Support OrElse bal.Is_Ended Then
                            Continue For
                        End If
                        PerValue = CInt(Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100)))
                        Dim SupporterFullName As String = Getter.GetFullName(bal.Supporter.Name)
                        Dim itm As New Telerik.WinControls.UI.ListViewDataItem(CStr(bal.ID), New String() {bal.ID.ToString(), SupporterFullName, bal.Amount.ToString(), bal.Box.Currency_Name})
                        RadListView1.Items.Add(itm)
                        i += 1
                        If LastPerValue <> PerValue Then
                            ProgressSate.ShowStatueProgress(PerValue, "")
                            LastPerValue = PerValue
                        End If
                    Next
                    ProgressSate.ShowStatueProgress(100, "")
                Else

                End If
                odb.Dispose()
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
            Using odb As New OrphanageDB.Odb
                Dim q = From bo In odb.Bails _
                        Where (bo.Is_Ended = False) OrElse bo.Is_Ended = Nothing
                        Select bo
                all = q.Count
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    For Each bal In q
                        If Not Ids.Contains(bal.ID) Then Continue For
                        PerValue = CInt(Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100)))
                        Dim SupporterFullName As String = Getter.GetFullName(bal.Supporter.Name)
                        Dim itm As New Telerik.WinControls.UI.ListViewDataItem(CStr(bal.ID), New String() {bal.ID.ToString(), SupporterFullName, bal.Amount.ToString(), bal.Box.Currency_Name})
                        RadListView1.Items.Add(itm)
                        i += 1
                        If LastPerValue <> PerValue Then
                            ProgressSate.ShowStatueProgress(PerValue, "")
                            LastPerValue = PerValue
                        End If
                    Next
                    ProgressSate.ShowStatueProgress(100, "")
                End If
                odb.Dispose()
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
        If Me.DialogResult = Windows.Forms.DialogResult.Cancel Then
            Me._SelectedBail = Nothing
            Me._SelectedBails = Nothing
            Exit Sub
        End If
        If RadListView1.MultiSelect Then
            Dim ar As New ArrayList()
            For Each itm In RadListView1.SelectedItems
                Dim retBond As Bail = Getter.GetBailByID(CInt(itm.Text))
                If Not ar.Contains(retBond) Then
                    ar.Add(retBond)
                End If
            Next
            If ar.Count > 0 Then
                ReDim Me._SelectedBails(ar.Count - 1)
                Dim i = 0
                For Each ft As Bail In ar
                    Me._SelectedBails(i) = ft
                    i += 1
                Next
            Else
                Me._SelectedBails = Nothing
            End If
        End If
        If Not IsNothing(RadListView1.SelectedItem) Then
            Me._SelectedBail = Getter.GetBailByID(CInt(RadListView1.SelectedItem.Text))
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
        RadListView1.Font = Me.Font
        lblStatu.Text = "العدد الكلي : " + RadListView1.Items.Count.ToString()
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
