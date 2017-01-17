Public Class FrmBox

    Private Currencies As IDictionary(Of String, String)
    Private Delegate Sub AutoCompleteDelegate()
    Private CallAutoComplete As New AutoCompleteDelegate(AddressOf SetAutoComplete)
    Dim t As New Threading.Thread(AddressOf CallAutoCompleteThread)
    'Private Odb As New OrphanageDB.Odb()
    Private _Box As Integer

    Private Sub CallAutoCompleteThread()
        Try
            Me.Invoke(CallAutoComplete)
        Catch
        End Try
    End Sub
    Public Sub SetAutoComplete()
        Using Odb As New OrphanageDB.Odb
            Odb.ObjectTrackingEnabled = False
            Dim q = From cur In Odb.Boxes Distinct Select cur.Currency_Name, cur.Currency_Short
            For Each cur In q
                If Not Me.Currencies.ContainsKey(cur.Currency_Name) Then
                    Me.Currencies.Add(cur.Currency_Name, cur.Currency_Short)
                End If
                If Not Me.cmbCurrencyName.Items.Contains(cur.Currency_Name) Then
                    Me.cmbCurrencyName.Items.Add(cur.Currency_Name)
                End If
            Next
            Odb.Dispose()
        End Using
        Application.DoEvents()
    End Sub

    Private Sub FrmBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Layouts.SaveFormLayout(Me)
        If Me._Box > 0 Then
            Using Odb As New OrphanageDB.Odb
                Dim q = From bx In Odb.Boxes Where bx.ID = Me._Box Select bx
                If IsNothing(q) OrElse q.Count <= 0 Then                
                    Odb.Dispose()
                    Return
                End If
                Dim box As OrphanageClasses.Box = q.FirstOrDefault()
                txtAccountName.Text = box.Name
                txtCurrencySho.Text = box.Currency_Short
                txtNote.Text = box.Note
                chkIsPositive.Checked = box.Is_Positive
                cmbCurrencyName.Text = box.Currency_Name
                numAmount.Value = box.Amount
                numAmount.ReadOnly = Not My.Settings.CanEditBoxAcmount
                Me.Text &= " " & box.Name & " " & box.Currency_Short
                Odb.Dispose()
            End Using
        End If
    End Sub
    Private Sub cmbCurrencyName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbCurrencyName.SelectedIndexChanged
        If IsNothing(cmbCurrencyName.SelectedItem) Then Exit Sub
        If cmbCurrencyName.SelectedItem.Text.Contains("مريكي") Then
            txtCurrencySho.Text = "$"
        ElseIf cmbCurrencyName.SelectedItem.Text.Contains("سوري") Then
            txtCurrencySho.Text = "ل.س"
        ElseIf cmbCurrencyName.SelectedItem.Text.Contains("وربي") Then
            txtCurrencySho.Text = "€"
        ElseIf cmbCurrencyName.SelectedItem.Text.Contains("سعودي") Then
            txtCurrencySho.Text = "ر.س"
        ElseIf cmbCurrencyName.SelectedItem.Text.Contains("قطري") Then
            txtCurrencySho.Text = "ر.ق"
        ElseIf cmbCurrencyName.SelectedItem.Text.Contains("ردني") Then
            txtCurrencySho.Text = "د.ا"
        ElseIf cmbCurrencyName.SelectedItem.Text.Contains("تركي") Then
            txtCurrencySho.Text = "ŧ"
        ElseIf cmbCurrencyName.SelectedItem.Text.Contains("ليني") Then
            txtCurrencySho.Text = "£"
        ElseIf cmbCurrencyName.SelectedItem.Text.Contains("مصري") Then
            txtCurrencySho.Text = "ج.م"
        ElseIf cmbCurrencyName.SelectedItem.Text.Contains("كويت") Then
            txtCurrencySho.Text = "د.ك"
        Else
            If Currencies.ContainsKey(cmbCurrencyName.SelectedItem.Text) Then
                txtCurrencySho.Text = Currencies(cmbCurrencyName.SelectedItem.Text)
            End If
        End If
    End Sub

    Private Sub txtAccountName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNote.Enter, txtAccountName.Enter, cmbCurrencyName.Enter
        LangChanger.CurLang.SaveCurrentLanguage()
        LangChanger.CurLang.ChangeToArabic()
    End Sub

    Private Sub txtAccountName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNote.Leave, txtAccountName.Leave, cmbCurrencyName.Leave
        LangChanger.CurLang.ReturnToSavedLanguage()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If txtAccountName.Text.Length = 0 Then
            ExceptionsManager.RaiseOnStatus(New MyException("يجب إدخال اسم الحساب!", False, True))
            txtAccountName.Focus()
            Exit Sub
        End If
        If cmbCurrencyName.Text.Length = 0 Then
            ExceptionsManager.RaiseOnStatus(New MyException("يجب إدخال نوع العملة!", False, True))
            cmbCurrencyName.ShowDropDown()
            Exit Sub
        End If
        If txtCurrencySho.Text.Length = 0 Then
            ExceptionsManager.RaiseOnStatus(New MyException("يجب إدخال اختصار اسم العملة!", False, True))
            txtCurrencySho.Focus()
            Exit Sub
        End If
        Try
            Using Odb As New OrphanageDB.Odb
                If IsNothing(Me._Box) OrElse Me._Box = 0 Then
                    Dim bx As New OrphanageClasses.Box() With {.Amount = numAmount.Value, _
                                                               .Currency_Name = cmbCurrencyName.Text, _
                                                               .Currency_Short = txtCurrencySho.Text, _
                                                               .Name = txtAccountName.Text, _
                                                               .Is_Positive = chkIsPositive.Checked, _
                                                               .Note = txtNote.Text, _
                                                               .RegDate = Date.Now, _
                                                               .User_ID = frmLogin.CurrentUser.ID}
                    Odb.Boxes.InsertOnSubmit(bx)
                    Odb.SubmitChanges()
                    Updater.AddNewBox(bx)
                    ExceptionsManager.RaiseSaved()
                    Me.Close()
                Else
                    Dim q = From bxe In Odb.Boxes Where bxe.ID = Me._Box Select bxe
                    Dim bx As OrphanageClasses.Box = q.FirstOrDefault()
                    bx.Name = txtAccountName.Text
                    bx.Currency_Name = cmbCurrencyName.Text
                    bx.Currency_Short = txtCurrencySho.Text
                    bx.Is_Positive = chkIsPositive.Checked
                    bx.Note = txtNote.Text
                    bx.Amount = numAmount.Value
                    'bx.User_ID = frmLogin.CurrentUser.ID
                    Odb.SubmitChanges()
                    Updater.UpdatesBox(bx)
                    ExceptionsManager.RaiseSaved()
                    Me.Close()
                End If
                Odb.Dispose()
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Public Sub New()
        InitializeComponent()
        Me._Box = Nothing
    End Sub
    Public Sub New(ByVal _id As Integer)
        InitializeComponent()
        If _id > 0 Then
            Me._Box = _id
        Else
            Return
        End If
    End Sub

    Private Sub numAmount_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numAmount.ValueChanged
        If chkIsPositive.Checked Then
            If numAmount.Value < 0 Then
                numAmount.Value = 0
                ExceptionsManager.RaiseOnStatus(New MyException("لايمكن أن يكون الحساب الجاري سالباً!", True, False))
            End If
        End If
    End Sub

    Private Sub chkIsPositive_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkIsPositive.ToggleStateChanged
        If Not numAmount.ReadOnly Then
            If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
                If numAmount.Value < 0 Then
                    numAmount.Value = 0
                    ExceptionsManager.RaiseOnStatus(New MyException("لايمكن أن يكون الحساب الجاري سالباً!", True, False))
                End If
            End If
        Else
            If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
                If numAmount.Value < 0 Then
                    ExceptionsManager.RaiseOnStatus(New MyException("لايمكن التعديل على القيمة المالية للحساب!", True, False))
                End If
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
