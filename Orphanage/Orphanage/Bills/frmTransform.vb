Imports Orphanage.OrphanageClasses
Public Class FrmTransform
    Dim End_Operation As Boolean = True
    Private qSbox As Integer
    Private qDbox As Integer
    'Private Odb As New OrphanageDB.Odb()

    Private Sub numSourceAmount_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numSourceAmount.ValueChanging, numSourceAmount.Leave
        If End_Operation Then
            End_Operation = False
            numDestinationAmount.Value = numSourceAmount.Value * numPrice.Value
            End_Operation = True
        End If
    End Sub

    Private Sub numPrice_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPrice.ValueChanging, numPrice.Leave
        If End_Operation Then
            End_Operation = False
            numDestinationAmount.Value = numSourceAmount.Value * numPrice.Value
            End_Operation = True
        End If
    End Sub

    Private Sub numDestinationAmount_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDestinationAmount.ValueChanging, numDestinationAmount.Leave
        If End_Operation Then
            End_Operation = False
            numPrice.Value = numDestinationAmount.Value / numSourceAmount.Value
            End_Operation = True
        End If
    End Sub

    Private Sub FrmTransform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        numDestinationAmount.DecimalPlaces = My.Settings.DecimalPercion
        numDestinationAmount.ThousandsSeparator = My.Settings.UseThousendSeprator
        numPrice.DecimalPlaces = My.Settings.DecimalPercion
        numPrice.ThousandsSeparator = My.Settings.UseThousendSeprator
        numSourceAmount.DecimalPlaces = My.Settings.DecimalPercion
        numSourceAmount.ThousandsSeparator = My.Settings.UseThousendSeprator
        Me.dteDate.CustomFormat = My.Settings.GeneralDateFormat
        If Me.qSbox > 0 Then
            Using Odb As New OrphanageDB.Odb
                Dim q = From bx In Odb.Boxes Where bx.ID = Me.qSbox Select bx.Name, bx.Currency_Short
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    grpSBox.Enabled = False
                    txtSBox.Text = q.FirstOrDefault.Name
                    lblSourceCur.Text = q.FirstOrDefault.Currency_Short
                End If
            End Using
        End If
    End Sub

    Private Sub btnChooseSBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseSBox.Click
        Dim frm As New FrmBoxChooser(False)
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.qSbox = frm.SelectedBox
            Using Odb As New OrphanageDB.Odb
                Dim q = From bx In Odb.Boxes Where bx.ID = Me.qSbox
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    Dim Sbox As Box = q.FirstOrDefault()
                    txtSBox.Text = Sbox.Name
                    lblSourceCur.Text = Sbox.Currency_Short
                    If Sbox.Is_Positive Then
                        numSourceAmount.Maximum = Sbox.Amount
                    Else
                        numSourceAmount.Maximum = Decimal.MaxValue
                    End If
                    If Not IsNothing(qDbox) Then
                        If qDbox = Sbox.ID Then
                            ExceptionsManager.RaiseOnStatus(New MyException("لقد قمت باختيار نفس الحساب وهذا النوع من العمليات غير ممكن !", False, True))
                            btnChooseDBox_Click(Nothing, Nothing)
                        End If
                        If lblDesCur.Text.Trim() = lblSourceCur.Text.Trim() Then
                            numPrice.Value = 1
                            numPrice.ReadOnly = True
                        Else
                            numPrice.Value = 1
                            numPrice.ReadOnly = False
                        End If
                    End If
                Else
                    btnSave.Enabled = False
                End If
            End Using
        End If
        frm.Dispose()
    End Sub

    Private Sub btnChooseDBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseDBox.Click
        Dim frm As New FrmBoxChooser(False)
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.qDbox = frm.SelectedBox
            Using Odb As New OrphanageDB.Odb
                Dim q = From bx In Odb.Boxes Where bx.ID = Me.qDbox Select bx.Name, bx.Currency_Short
                If Me.qDbox > 0 AndAlso Not IsNothing(q) AndAlso q.Count > 0 Then
                    If qDbox = qSbox Then
                        ExceptionsManager.RaiseOnStatus(New MyException("لقد قمت باختيار نفس الحساب وهذا النوع من العمليات غير ممكن !", False, True))
                        btnChooseDBox_Click(Nothing, Nothing)
                    End If
                    txtDBox.Text = q.FirstOrDefault.Name
                    lblDesCur.Text = q.FirstOrDefault.Currency_Short
                    btnSave.Enabled = True
                    If lblDesCur.Text.Trim() = lblSourceCur.Text.Trim() Then
                        numPrice.Value = 1
                        numPrice.ReadOnly = True
                    Else
                        numPrice.Value = 1
                        numPrice.ReadOnly = False
                    End If
                Else
                    btnSave.Enabled = False
                End If
                Odb.Dispose()
            End Using
        End If
        frm.Dispose()
    End Sub

    Private Sub numNumber_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numNumber.Leave
        If numNumber.Value > 0 Then
            If Checker.isExistBillNumber(numNumber.Value) Then
                ExceptionsManager.RaiseOnStatus(New MyException("رقم الإيصال موجود مسبقاً", True, True))
                numNumber.Focus()
            End If
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If numNumber.Value > 0 Then
            If Checker.isExistBillNumber(numNumber.Value) Then
                ExceptionsManager.RaiseOnStatus(New MyException("رقم الفاتورة موجود مسبقاً", True, True))
                numNumber.Focus()
                Return
            End If
        End If
        If numSourceAmount.Value = 0 OrElse numDestinationAmount.Value = 0 OrElse numPrice.Value = 0 Then
            ExceptionsManager.RaiseOnStatus(New MyException("لايمكن اتمام عملية تحويل تحتوي على اصفار!", False, True))
            numSourceAmount.Focus()
            Return
        End If
        Try
            Using Odb As New OrphanageDB.Odb
                Dim qDB = From dbx In Odb.Boxes Where dbx.ID = qDbox Select dbx
                Dim qSB = From sbx In Odb.Boxes Where sbx.ID = qSbox Select sbx
                Dim Dbox = qDB.FirstOrDefault()
                Dim Sbox = qSB.FirstOrDefault()
                If IsNothing(Me.qSbox) Then
                    ExceptionsManager.RaiseOnStatus(New MyException("الرجاء اختيار الحساب المصدر", False, True))
                    btnChooseSBox.Focus()
                    Return
                End If
                If IsNothing(Me.qDbox) Then
                    ExceptionsManager.RaiseOnStatus(New MyException("الرجاء اختيار الحساب الهدف", False, True))
                    btnChooseSBox.Focus()
                    Return
                End If
                If Sbox.Is_Positive Then
                    If numSourceAmount.Value > Sbox.Amount Then
                        ExceptionsManager.RaiseOnStatus(New MyException("الحساب لايحتوي على المبلغ المراد سحبه!!", False, True))
                        numSourceAmount.Focus()
                        Return
                    End If
                End If
                Using tr = New Transactions.TransactionScope()
                    Dim Ntra As New Transform() With {.Des_Amount = numDestinationAmount.Value, .DestinationBox_ID = Dbox.ID _
                                                    , .Details = txtDetails.Text, .Note = txtNote.Text, .Photo = PictureSelector1.PhotoAsBytes, _
                                                     .RegDate = Date.Now, .Source_Amount = numSourceAmount.Value, .SourceBox_ID = Sbox.ID, _
                                                     .Tranc_Date = dteDate.Value, .Tranc_Number = numNumber.Value, .Tranc_Price = numPrice.Value, _
                                                     .User_ID = frmLogin.CurrentUser.ID}
                    Odb.Transforms.InsertOnSubmit(Ntra)
                    Odb.SubmitChanges()
                    Dbox.Amount += numDestinationAmount.Value
                    Sbox.Amount -= numSourceAmount.Value
                    Odb.SubmitChanges()
                    If My.Settings.Make_A_Tow_Bills_For_One_Transaction Then
                        Dim newDBill As New Bill With {.Amount = numSourceAmount.Value, .Bill_Date = dteDate.Value, _
                                                      .Bill_Number = numNumber.Value, .Box_ID = Sbox.ID, .IsDeposite = False, _
                                                      .RegDate = Date.Now, .User_ID = frmLogin.CurrentUser.ID, .Photo = PictureSelector1.PhotoAsBytes}
                        newDBill.Name = "عملية تحويل"
                        newDBill.Details = "تم سحب المبلغ من أجل عملية تحويل حيث كانت النسبة " & "\" & numPrice.Value & "/" & "وتم وضع المبلغ الناتج في الحساب " & "\" & txtDBox.Text
                        newDBill.Note = "صرفت بشكل اوتماتيكي"
                        Odb.Bills.InsertOnSubmit(newDBill)
                        Dim newDpBill As New Bill With {.Amount = numDestinationAmount.Value, .Bill_Date = dteDate.Value, _
                                  .Bill_Number = numNumber.Value, .Box_ID = Dbox.ID, .IsDeposite = True, _
                                  .RegDate = Date.Now, .User_ID = frmLogin.CurrentUser.ID, .Photo = PictureSelector1.PhotoAsBytes}
                        newDpBill.Name = "عملية تحويل"
                        newDpBill.Details = "تم إيداع المبلغ وهو ناتج عن عملية تحويل حيث كانت النسبة " & "\" & numPrice.Value & "/" & "وتم سحب المبلغ الأصلي من الحساب " & "\" & txtSBox.Text
                        newDpBill.Note = "صرفت بشكل اتوماتيكي"
                        Odb.Bills.InsertOnSubmit(newDpBill)
                        Odb.SubmitChanges()
                        Updater.AddNewBill(newDBill)
                        Updater.AddNewBill(newDpBill)
                    End If
                    Updater.AddNeWTransform(Ntra)
                    Updater.UpdatesBox(Sbox)
                    Updater.UpdatesBox(Dbox)
                    tr.Complete()                    
                    Me.Close()
                End Using
                Odb.Dispose()
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub txtDetails_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNote.Enter, txtDetails.Enter
        LangChanger.CurLang.ReturnToSavedLanguage()
        LangChanger.CurLang.ChangeToArabic()
    End Sub

    Private Sub txtDetails_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNote.Leave, txtDetails.Leave
        LangChanger.CurLang.ReturnToSavedLanguage()
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal Sbox As Integer)
        InitializeComponent()
        Me.qSbox = Sbox
    End Sub

    Private Sub PictureSelector1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureSelector1.DoubleClick
        Try
            Dim frm As New FrmShowPic(PictureSelector1.Photo, "عملية تحويل من " & txtSBox.Text & " إلى " & txtDBox.Text)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        Catch

        End Try
    End Sub
End Class
