Public Class Form1
    Dim i = 0
    Private Sub Form1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Select Case i
            Case 0
                AddressForm1.MoveType = AddressForm.AddressForm._MoveType.LeftToRight
            Case 2
                AddressForm1.MoveType = AddressForm.AddressForm._MoveType.RightToLeft
            Case 4
                AddressForm1.MoveType = AddressForm.AddressForm._MoveType.UpToDown
            Case 6
                AddressForm1.MoveType = AddressForm.AddressForm._MoveType.DownToUp
            Case 8
                i = -1
        End Select
        i += 1
        AddressForm1.ShowMovement = True
        AddressForm1.Visible = Not AddressForm1.Visible
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
