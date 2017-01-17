Imports Orphanage.OrphanageClasses
Public Class frmSupporterSelector
    Private Odb As New OrphanageDB.Odb()
    Private _SelectedSupporter As Integer = -1
    Private _SelectedSupporters() As Integer = Nothing
    Public Sub SetGridFont(ByVal fon As Font)
        RadListView1.Font = fon
        RadListView1.Refresh()
        SearchControl1.Font = fon
    End Sub
    Public ReadOnly Property SelectedSupporter As Integer
        Get
            Return _SelectedSupporter
        End Get
    End Property
    Public ReadOnly Property SelectedSupporters As Integer()
        Get
            Return _SelectedSupporters
        End Get
    End Property
    Public Sub New(ByVal MultiSelect As Boolean)
        InitializeComponent()
        Try
            Dim i As Integer = 0
            Dim all As Integer = 0
            Dim PerValue = 0, LastPerValue As Integer = 0
            RadListView1.MultiSelect = MultiSelect
            Dim q = From fath In Odb.Supporters _
                    Select fath

            all = q.Count
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                For Each fat In q
                    PerValue = Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100))
                    Dim SupporterFullName As String = Getter.GetFullName(fat.Name)
                    Dim AccountFullName As String = ""
                    AccountFullName = fat.Box.Name & " " & fat.Box.Currency_Short

                    Dim Initm As New Telerik.WinControls.UI.ListViewDataItem(fat.ID, New String() {fat.ID.ToString(), SupporterFullName, AccountFullName, ATDFormater.ArabicBooleanFormatter.BooleanToArabic(fat.Is_Family_Support), ATDFormater.ArabicBooleanFormatter.BooleanToArabic(fat.Is_Still_Support)})
                    If Not IsNothing(fat.Color_Mark) AndAlso fat.Color_Mark <> 0 Then
                        Initm.BackColor = Color.FromArgb(fat.Color_Mark)
                    End If
                    RadListView1.Items.Add(Initm)
                    i += 1
                    If LastPerValue <> PerValue Then
                        ProgressSate.ShowStatueProgress(PerValue, "")
                        LastPerValue = PerValue
                    End If
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
            Dim PerValue = 0, LastPerValue As Integer = 0
            Dim all As Integer = 0
            RadListView1.MultiSelect = MultiSelect
            Dim q = From fath In Odb.Supporters _
                    Select fath

            all = q.Count
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                For Each fat In q
                    If Not Ids.Contains(fat.ID) Then Continue For
                    PerValue = Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100))
                    Dim SupporterFullName As String = Getter.GetFullName(fat.Name)
                    Dim AccountFullName As String = ""
                    AccountFullName = fat.Box.Name & " " & fat.Box.Currency_Short

                    Dim Initm As New Telerik.WinControls.UI.ListViewDataItem(fat.ID, New String() {fat.ID.ToString(), SupporterFullName, AccountFullName, ATDFormater.ArabicBooleanFormatter.BooleanToArabic(fat.Is_Family_Support), ATDFormater.ArabicBooleanFormatter.BooleanToArabic(fat.Is_Still_Support)})
                    If Not IsNothing(fat.Color_Mark) AndAlso fat.Color_Mark <> 0 Then
                        Initm.BackColor = Color.FromArgb(fat.Color_Mark)
                    End If
                    RadListView1.Items.Add(Initm)
                    i += 1
                    If LastPerValue <> PerValue Then
                        ProgressSate.ShowStatueProgress(PerValue, "")
                        LastPerValue = PerValue
                    End If
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

    Private Sub FrmFatherChooser_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
            If RadListView1.MultiSelect Then
                Dim ar As New ArrayList()
                For Each itm In RadListView1.SelectedItems
                    If Not ar.Contains(CInt(itm.Text)) Then
                        ar.Add(CInt(itm.Text))
                    End If
                Next
                If ar.Count > 0 Then
                    Me._SelectedSupporters = CType(ar.ToArray(GetType(Integer)), Integer())
                Else
                    Me._SelectedSupporters = Nothing
                End If
            End If
            If Not IsNothing(RadListView1.SelectedItem) Then
                Me._SelectedSupporter = CInt(RadListView1.SelectedItem.Text)
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
