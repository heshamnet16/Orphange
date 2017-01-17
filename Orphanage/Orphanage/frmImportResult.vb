Public Class FrmImportResult
    Public Structure ImportInfo
        Dim FilePath As String
        Dim FatherNAme As String
        Dim MotherName As String
        Dim State As String
        Public Sub New(ByVal FilePath As String, ByVal FAtherNa As String, ByVal motherN As String, ByVal State As String)
            Me.FatherNAme = FAtherNa
            Me.FilePath = FilePath
            Me.MotherName = motherN
            Me.State = State
        End Sub
    End Structure
    Private _PassedData() As ImportInfo
    Public Sub New(ByVal PassedDate() As ImportInfo)
        InitializeComponent()
        _PassedData = PassedDate
    End Sub

    Private Sub FrmImportResult_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(_PassedData) Then
            For Each pd In _PassedData
                AddRow(pd)
            Next
        End If
    End Sub
    Private Sub AddRow(ByVal row As ImportInfo)
        Dim itm As New Telerik.WinControls.UI.ListViewDataItem( _
            row.FilePath, New String() {row.FilePath, row.FatherNAme, row.MotherName, row.State})
        If row.State.IndexOf("نج") > -1 Then
            itm.ForeColor = Color.Green
        Else
            itm.ForeColor = Color.Red
        End If
        RadListView1.Items.Add(itm)
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        Me.Close()
    End Sub
End Class
