Public Class FrmBail
    'Private Odb As New OrphanageDB.Odb()
    Private QSUpp_ID As Integer = -1
    Dim _ID As Integer = 0
    Dim Intit As Boolean = True
    Private Sub FrmBail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        numAmount.DecimalPlaces = My.Settings.DecimalPercion
        numAmount.ThousandsSeparator = My.Settings.UseThousendSeprator
        Try
            If _ID > 0 Then
                Using Odb As New OrphanageDB.Odb
                    Dim q = From fth In Odb.Bails Where fth.ID = _ID Select fth
                    Dim bal As OrphanageClasses.Bail = q.FirstOrDefault()
                    If IsNothing(bal) Then
                        Dim myexc As New MyException("المعيل رقم " & _ID.ToString() & " غير موجود.", True, True)
                        Me.Close()
                        Return
                    Else
                        txtSupporterName.Text = Getter.GetFullName(bal.Supporter.Name)
                        Me.QSUpp_ID = bal.Supporter.ID
                        lblCurrency.Text = bal.Supporter.Box.Currency_Short
                        numAmount.Value = bal.Amount
                        If Not IsNothing(bal.Start_Date) Then
                            dteFrom.Value = CDate(bal.Start_Date)
                        Else
                            chkNoTime.Checked = True
                            chkNoTime_ToggleStateChanged(Nothing, New Telerik.WinControls.UI.StateChangedEventArgs(Telerik.WinControls.Enumerations.ToggleState.On))
                        End If
                        If Not IsNothing(bal.End_Date) Then
                            dteTo.Value = CDate(bal.End_Date)
                        Else
                            chkNoTime.Checked = True
                            chkNoTime_ToggleStateChanged(Nothing, New Telerik.WinControls.UI.StateChangedEventArgs(Telerik.WinControls.Enumerations.ToggleState.On))
                        End If
                        txtNote.Text = bal.Note
                        chkIsEnded.Checked = bal.Is_Ended
                        chkIsFamily.Checked = bal.Is_Family
                        chkIsMonthly.Checked = bal.IsMonthly
                        chkIsFamily.Enabled = Not bal.Supporter.Is_Family_Support
                        If bal.Is_Ended Then
                            chkIsEnded_ToggleStateChanged(Nothing, New Telerik.WinControls.UI.StateChangedEventArgs(Telerik.WinControls.Enumerations.ToggleState.On))
                        End If
                        chkIsFamily.Enabled = False
                    End If
                    Odb.Dispose()
                End Using
            Else
                If Me.QSUpp_ID > 0 Then
                    Using odb As New OrphanageDB.Odb
                        odb.ObjectTrackingEnabled = False
                        Dim retSup As OrphanageClasses.Supporter = Getter.GetSupporterByID(Me.QSUpp_ID, odb)
                        If Not IsNothing(retSup) Then
                            Dim q = From nam In odb.Names Where nam.ID = retSup.Name_ID Select nam

                            Dim q1 = From bx In odb.Boxes Where bx.ID = retSup.Box_ID Select bx
                            btnChooseSup.Enabled = False
                            chkIsFamily.Checked = retSup.Is_Family_Support
                            chkIsFamily.Enabled = Not retSup.Is_Family_Support
                            chkIsMonthly.Checked = retSup.Is_Monthly_Support
                            txtSupporterName.Text = Getter.GetFullName(q.FirstOrDefault())
                            lblCurrency.Text = q1.FirstOrDefault().Currency_Short
                        End If
                        odb.Dispose()
                    End Using
                End If
            End If
            Intit = False
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseSup.Click
        Dim frm As New frmSupporterSelector(False)
        frm.ShowDialog()
        If Not IsNothing(frm.SelectedSupporter) Then
            QSUpp_ID = frm.SelectedSupporter
            Using Odb As New OrphanageDB.Odb
                Dim Supp = Getter.GetSupporterByID(Me.QSUpp_ID, Odb)
                chkIsFamily.Checked = Supp.Is_Family_Support
                chkIsFamily.Enabled = Not Supp.Is_Family_Support
                chkIsMonthly.Checked = Supp.Is_Monthly_Support
                txtSupporterName.Text = Getter.GetFullName(Supp.Name)
                lblCurrency.Text = Supp.Box.Currency_Short
                Odb.Dispose()
            End Using
        End If
        frm.Dispose()
    End Sub

    Private Sub RadDateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dteTo.ValueChanged, dteFrom.ValueChanged
        If Intit Then Return
        Dim dte As Telerik.WinControls.UI.RadDateTimePicker = CType(sender, Telerik.WinControls.UI.RadDateTimePicker)
        dte.Value = New Date(dte.Value.Year, dte.Value.Month, dte.Value.Day)
        If dteTo.Value < Date.Now OrElse dteTo.Value <= dteFrom.Value Then
            ExceptionsManager.RaiseOnStatus(New MyException("الكفالة منتهية فعلاً , تحقق من تاريخ انتهاء الكفالة", False, True))
            dteTo.Focus()
            Return
        End If
    End Sub

    Private Sub chkNoTime_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkNoTime.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            dteFrom.Enabled = False
            dteTo.Enabled = False
        Else
            dteFrom.Enabled = True
            dteTo.Enabled = True
        End If
    End Sub
    Public Sub New(ByVal ID As Integer)
        InitializeComponent()
        Me._ID = ID
    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal sup_ID As Long)
        InitializeComponent()
        Me.QSUpp_ID = CInt(sup_ID)
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me.QSUpp_ID <= 0 Then
            ExceptionsManager.RaiseOnStatus(New MyException("يجب اختيار اسم الكفيل اولاً.", False, True))
            Return
        End If
        If Not chkNoTime.Checked Then
            If dteTo.Value < Date.Now OrElse dteTo.Value <= dteFrom.Value Then
                ExceptionsManager.RaiseOnStatus(New MyException("الكفالة منتهية فعلاً , تحقق من تاريخ انتهاء الكفالة", False, True))
                dteTo.Focus()
                Return
            End If
            If Not Checker.CheckBailControls(dteFrom, dteTo) Then
                Return
            End If
        End If
        Try
            Using Odb As New OrphanageDB.Odb
                Dim qBox_Id = From sup In Odb.Supporters Where sup.ID = Me.QSUpp_ID Select sup.Box_ID
                If Me._ID > 0 Then
                    Dim q = From fth In Odb.Bails Where fth.ID = _ID Select fth
                    Dim bal As OrphanageClasses.Bail = q.FirstOrDefault()
                    If Not IsNothing(bal) Then
                        bal.Amount = numAmount.Value
                        bal.Box_ID = qBox_Id.FirstOrDefault()
                        bal.Supporter_ID = QSUpp_ID
                        If chkNoTime.Checked Then
                            bal.End_Date = Nothing
                            bal.Start_Date = Nothing
                        Else
                            bal.End_Date = dteTo.Value
                            bal.Start_Date = dteFrom.Value
                        End If
                        bal.Is_Family = chkIsFamily.Checked
                        bal.IsMonthly = chkIsMonthly.Checked
                        bal.Is_Ended = chkIsEnded.Checked
                        bal.Note = txtNote.Text
                        Odb.SubmitChanges()
                        Try
                            Updater.UpdatesBail(bal)
                        Catch
                        End Try
                        ExceptionsManager.RaiseOnDesktopNow(New MyException("تم الحفظ", False, True))
                        Me.DialogResult = DialogResult.OK
                    Else
                        ExceptionsManager.RaiseNotSaved()
                        Me.DialogResult = DialogResult.None
                    End If
                    Me.Close()
                Else
                    Dim bal As New OrphanageClasses.Bail()
                    If Not IsNothing(bal) Then
                        bal.Amount = numAmount.Value
                        bal.Box_ID = qBox_Id.FirstOrDefault()
                        bal.Supporter_ID = QSUpp_ID
                        If chkNoTime.Checked Then
                            bal.End_Date = Nothing
                            bal.Start_Date = Nothing
                        Else
                            bal.End_Date = dteTo.Value
                            bal.Start_Date = dteFrom.Value
                        End If
                        bal.Is_Family = chkIsFamily.Checked
                        bal.IsMonthly = chkIsMonthly.Checked
                        bal.Is_Ended = chkIsEnded.Checked
                        bal.Note = txtNote.Text
                        bal.User_ID = frmLogin.CurrentUser.ID
                        bal.RegDate = Date.Now
                        Odb.Bails.InsertOnSubmit(bal)
                        Odb.SubmitChanges()
                        Try
                            Updater.AddNewBail(bal)
                        Catch
                        End Try
                        ExceptionsManager.RaiseSaved()
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    End If
                End If
                Odb.Dispose()
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub
    Private Sub chkIsEnded_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkIsEnded.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            chkIsFamily.Enabled = False
            chkIsMonthly.Enabled = False
            txtNote.Enabled = False
            txtSupporterName.Enabled = False
            numAmount.Enabled = False
            btnChooseSup.Enabled = False
            chkNoTime.Enabled = False
            dteFrom.Enabled = False
            dteTo.Enabled = False
        Else
            txtNote.Enabled = True
            txtSupporterName.Enabled = True
            numAmount.Enabled = True
            btnChooseSup.Enabled = True
            chkNoTime.Enabled = True
            dteFrom.Enabled = Not chkNoTime.Checked
            dteTo.Enabled = Not chkNoTime.Checked
            If Me.QSUpp_ID > 0 Then
                Using odb As New OrphanageDB.Odb
                    odb.ObjectTrackingEnabled = False
                    Dim supp As OrphanageClasses.Supporter = Getter.GetSupporterByID(Me.QSUpp_ID, odb)
                    btnChooseSup.Enabled = False
                    chkIsFamily.Checked = supp.Is_Family_Support
                    chkIsFamily.Enabled = Not supp.Is_Family_Support
                    chkIsMonthly.Checked = supp.Is_Monthly_Support
                    odb.Dispose()
                End Using
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
