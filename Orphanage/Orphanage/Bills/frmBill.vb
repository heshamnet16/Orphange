Imports Orphanage.OrphanageClasses
Imports System.Globalization

Public Class FrmBill
    Dim _is_Deposite As Boolean = False
    Dim NoParameter As Boolean = False
    Dim AllDone As Boolean = True
    Dim qOrph_ID As Integer
    Dim qOrph As Orphan = Nothing
    Dim qFam As Family = Nothing
    Dim qFam_ID As Integer
    Dim qBox_ID As Integer
    Dim qBail As Bail = Nothing
    Dim qBail_ID As Integer
    'Dim Odb As New OrphanageDB.Odb()

    Private Sub FrmBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        numAmount.DecimalPlaces = CInt(My.Settings.DecimalPercion)        
        numAmount.ThousandsSeparator = My.Settings.UseThousendSeprator
        Me.dteDate.CustomFormat = My.Settings.GeneralDateFormat
        dteDate.Value = Date.Now
        'Bail Check
        Using Odb As New OrphanageDB.Odb
            Dim q = From bal In Odb.Bails Where bal.ID = qBail_ID Select bal                    
            Me.qBail = q.FirstOrDefault()
            Dim Qo = From orp In Odb.Orphans Where orp.ID = Me.qOrph_ID Select orp
            Me.qOrph = Qo.FirstOrDefault()
            Dim Qb = From bx In Odb.Boxes Where bx.ID = qBox_ID Select bx
            Dim qBox As Box = Qb.FirstOrDefault()
            Dim Qf = From fam In Odb.Families Where fam.ID = qFam_ID Select fam
            Me.qFam = Qf.FirstOrDefault()
            If Not IsNothing(Me.qBail) Then
                optDraw.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On
                grpBox.Enabled = False
                grpType.Enabled = False
                grpAMount.Enabled = False
                qBox = Me.qBail.Box
                txtBox.Text = qBox.Name
                lblCurrency.Text = qBox.Currency_Short
                If IsNothing(Me.qOrph) AndAlso IsNothing(Me.qFam) Then
                    Dim AllMoney As Decimal = 0
                    If Me.qBail.Is_Family AndAlso Not IsNothing(Me.qBail.Families) AndAlso Me.qBail.Families.Count > 0 Then
                        AllMoney = Me.qBail.Families.Count * qBail.Amount
                        optFAmily.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On
                        optFAmily.Enabled = True
                        optOthers.Enabled = False
                        optOrphan.Enabled = False
                    End If
                    If Not Me.qBail.Is_Family AndAlso Not IsNothing(Me.qBail.Orphans) AndAlso Me.qBail.Orphans.Count > 0 Then
                        AllMoney = Me.qBail.Orphans.Count * qBail.Amount
                        optOrphan.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On
                        optFAmily.Enabled = False
                        optOthers.Enabled = False
                        optOrphan.Enabled = True
                    End If
                    numAmount.Value = AllMoney
                    If (AllMoney > qBox.Amount) AndAlso qBox.Is_Positive Then
                        ExceptionsManager.RaiseOnStatus(New MyException("لايحتوي الحساب على المبلغ المراد صرفه للكفالة", False, True))
                        Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
                        Return
                    End If
                    grpAMount.Enabled = False
                    grpBox.Enabled = False
                    grpType.Enabled = False
                    txtDetails.Text = "كفالة " & Getter.GetFullName(Me.qBail.Supporter.Name) & " المبلغ " & Me.qBail.Amount & " " & Me.qBail.Box.Currency_Short
                Else
                    If Not IsNothing(Me.qOrph) Then
                        optOrphan.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On
                        numAmount.Value = qBail.Amount
                        txtDetails.Text = "كفالة " & Getter.GetFullName(Me.qBail.Supporter.Name) & " المبلغ " & Me.qBail.Amount & " " & Me.qBail.Box.Currency_Short _
                            & vbNewLine & "اليتيم " & Getter.GetFullName(Me.qOrph.Name)
                        txtSide.Text = "اليتيم " & Getter.GetFullName(Me.qOrph.Name)
                        optFAmily.Enabled = False
                        optOthers.Enabled = False
                        optOrphan.Enabled = True
                        btnChooseBox.Enabled = False
                    Else
                        optFAmily.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On
                        numAmount.Value = qBail.Amount
                        txtDetails.Text = "كفالة " & Getter.GetFullName(Me.qBail.Supporter.Name) & " المبلغ " & Me.qBail.Amount & " " & Me.qBail.Box.Currency_Short _
                            & vbNewLine & "العائلة " & Getter.GetFullName(Me.qFam.Father.Name) & " و " & Getter.GetFullName(Me.qFam.Mother.Name)
                        txtSide.Text = "عائلة " & Getter.GetFullName(Me.qFam.Father.Name) & " و " & Getter.GetFullName(Me.qFam.Mother.Name)
                        optFAmily.Enabled = True
                        optOthers.Enabled = False
                        optOrphan.Enabled = False
                        btnChooseBox.Enabled = False
                    End If
                    If numAmount.Value > qBox.Amount AndAlso qBox.Is_Positive Then
                        ExceptionsManager.RaiseOnStatus(New MyException("لايحتوي الحساب على المبلغ المراد صرفه للكفالة", False, True))
                        Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
                        Return
                    End If
                End If
            End If
            If Not IsNothing(qBox) Then
                grpBox.Enabled = False
                txtBox.Text = qBox.Name
                lblCurrency.Text = qBox.Currency_Short
            End If
            If Not IsNothing(Me.qFam) AndAlso IsNothing(qBail) Then
                optDraw.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On
                optFAmily.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On
                grpSide.Enabled = False
                grpType.Enabled = False
                txtSide.Text = "عائلة " & Getter.GetFullName(Me.qFam.Father.Name) & " و " & Getter.GetFullName(Me.qFam.Mother.Name)
                txtDetails.Text = "عائلة " & Getter.GetFullName(Me.qFam.Father.Name) & " و " & Getter.GetFullName(Me.qFam.Mother.Name)
            End If
            If Not IsNothing(Me.qOrph) AndAlso IsNothing(qBail) Then
                optDraw.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On
                optOrphan.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On
                grpSide.Enabled = False
                grpType.Enabled = False
                txtSide.Text = "اليتيم " & Getter.GetFullName(Me.qOrph.Name)
                txtDetails.Text = "اليتيم " & Getter.GetFullName(Me.qOrph.Name)
            End If
            Odb.Dispose()
        End Using
        If Not Me.NoParameter Then
            grpType.Enabled = False
            If Not Me._is_Deposite Then
                optDraw.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On
            Else
                optDeposite.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On
            End If
        End If
    End Sub

    Private Sub optBail_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs)
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            btnChooseSide.Enabled = True
        End If
    End Sub

    Private Sub optOrphan_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles optOrphan.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            btnChooseSide.Enabled = True
        End If
    End Sub

    Private Sub optFAmily_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles optFAmily.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            btnChooseSide.Enabled = True
        End If
    End Sub

    Private Sub optOthers_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles optOthers.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            btnChooseSide.Enabled = False
        End If
    End Sub

    Private Sub optDraw_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles optDraw.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            optFAmily.Enabled = True
            optOrphan.Enabled = True
            grpSide.Enabled = True
            grpAMount.Enabled = True
            grpOthers.Enabled = True
            btnSave.Enabled = True
            btnSave.Text = "سحب"
            grpSide.Text = "الجهة المستلمة"
            Using odb As New OrphanageDB.Odb
                Dim q = From bx In odb.Boxes Where bx.ID = Me.qBox_ID Select bx
                If Not IsNothing(q) AndAlso q.Count > 0 AndAlso q.FirstOrDefault.Is_Positive Then
                    numAmount.Maximum = q.FirstOrDefault.Amount
                Else
                    numAmount.Maximum = 999999999999
                End If
            End Using
        End If
    End Sub

    Private Sub optDeposite_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles optDeposite.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            optFAmily.Enabled = False
            optOrphan.Enabled = False
            txtSide.ReadOnly = False
            btnChooseSide.Enabled = False
            numAmount.Maximum = 999999999999
            grpSide.Enabled = True
            grpAMount.Enabled = True
            grpOthers.Enabled = True
            btnSave.Enabled = True
            btnSave.Text = "إيداع"
            grpSide.Text = "الجهة المودعة"
        End If
    End Sub

    Private Sub NumNumber_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numNumber.Leave
        If numNumber.Value > 0 Then
            If Checker.isExistBillNumber(numNumber.Value) Then
                ExceptionsManager.RaiseOnStatus(New MyException("رقم الفاتورة موجود مسبقاً", True, True))
                numNumber.Focus()
                AllDone = False
            Else
                AllDone = True
            End If
        End If
    End Sub

    Private Sub btnChooseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseBox.Click
        Dim frm As New FrmBoxChooser(False)
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.qBox_ID = frm.SelectedBox
            If Me.qBox_ID > 0 Then
                Using Odb As New OrphanageDB.Odb
                    Dim q = From bx In Odb.Boxes Where bx.ID = Me.qBox_ID Select bx.Name, bx.Currency_Short
                    txtBox.Text = q.FirstOrDefault.Name
                    lblCurrency.Text = q.FirstOrDefault.Currency_Short
                    btnSave.Enabled = True
                End Using
            Else
                txtBox.Text = ""
                lblCurrency.Text = ""
                grpAMount.Enabled = False
                grpOthers.Enabled = False
                grpSide.Enabled = False
                btnSave.Enabled = False
                AllDone = False
            End If
        End If
        frm.Dispose()
    End Sub
    Private Sub btnChooseSide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseSide.Click
        If optFAmily.IsChecked Then
            Dim frm As New FrmFatherChooser(False)
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                If Not IsNothing(frm.SelectedFamily) AndAlso frm.SelectedFamily > 0 Then
                    Using Odb As New OrphanageDB.Odb
                        Dim q = From fam In Odb.Families Join mot In Odb.Mothers On
                                fam.Mother_ID Equals mot.ID Join fath In Odb.Fathers On
                                fath.ID Equals fam.Father_ID
                                Where fam.ID = frm.SelectedFamily
                                Select motherName = mot.Name, fathName = fath.Name, fam                                
                        txtSide.Text = "عائلة " & Getter.GetFullName(q.FirstOrDefault().fathName) & " و " & Getter.GetFullName(q.FirstOrDefault().motherName)
                        Me.qFam = q.FirstOrDefault().fam
                    End Using
                End If
            End If
            frm.Dispose()
        End If
        If optOrphan.IsChecked Then
            Dim frm As New FrmFatherChooser(False)
            frm.ShowDialog()
            Dim frm1 As New FrmOrphansChooser(False, frm.SelectedFamily)
            frm1.ShowDialog()
            If frm1.DialogResult = Windows.Forms.DialogResult.OK Then
                If Not IsNothing(frm1.SelectedOrphan) Then
                    txtSide.Text = "اليتيم : " & Getter.GetFullName(frm1.SelectedOrphan.Name)
                    Me.qOrph = frm1.SelectedOrphan
                End If
            End If
            frm.Dispose()
            frm1.Dispose()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If numNumber.Value > 0 Then
                If Checker.isExistBillNumber(numNumber.Value) Then
                    ExceptionsManager.RaiseOnStatus(New MyException("رقم الإيصال موجود مسبقاً", True, True))
                    numNumber.Focus()
                    AllDone = False
                Else
                    AllDone = True
                End If
            End If
            If Not AllDone Then Return
            If numAmount.Value <= 0 Then
                ExceptionsManager.RaiseOnStatus(New MyException("يجب ان يكون المبلغ أكبر من صفر", False, True))
                numNumber.Focus()
                Return
            End If
            If IsNothing(Me.qBox_ID) OrElse Me.qBox_ID <= 0 Then
                ExceptionsManager.RaiseOnStatus(New MyException("يجب اختيار الحساب أولا", False, True))
                btnChooseBox.Focus()
                Return
            End If
            If txtSide.Text = "" Then
                ExceptionsManager.RaiseOnStatus(New MyException("يجب اختيار الجهة أولا", False, True))
                txtSide.Focus()
                Return
            End If
            Using Odb As New OrphanageDB.Odb
                Dim Sbox As Box = Nothing
                Dim q = From Sbx In Odb.Boxes Where Sbx.ID = qBox_ID Select Sbx

                If IsNothing(q) OrElse q.Count = 0 Then
                    ExceptionsManager.RaiseNotSaved()
                    Return
                Else
                    Sbox = q.FirstOrDefault()
                End If
                Using tr = New Transactions.TransactionScope()
                    Dim Sbill As New Bill() With {.Amount = numAmount.Value, .Bill_Date = dteDate.Value, _
                                                 .Bill_Number = numNumber.Value, .Box_ID = qBox_ID, _
                                                  .Name = txtSide.Text}
                    If optFAmily.IsChecked AndAlso qFam_ID > 0 Then
                        Sbill.Family_ID = qFam_ID
                    End If
                    If optOrphan.IsChecked And qOrph_ID > 0 Then
                        Sbill.Orphan_ID = qOrph_ID
                    End If
                    If Not IsNothing(Me.qBail) AndAlso IsNothing(qFam) AndAlso IsNothing(qOrph) Then
                        Sbill.Bail_ID = Me.qBail.ID
                        If Me.qBail.Is_Family Then
                            If My.Settings.Make_A_Bill_for_every_Family Then
                                Dim prec = 0, all = 0, i As Integer = 0
                                If Not IsNothing(Me.qBail.Families) AndAlso Me.qBail.Families.Count > 0 Then
                                    all = Me.qBail.Families.Count
                                    For Each fam In Me.qBail.Families
                                        Dim FBill As New Bill() With {.Amount = Me.qBail.Amount, _
                                                                     .Bail_ID = Me.qBail.ID, _
                                                                     .Bill_Date = dteDate.Value, _
                                                                     .Bill_Number = 0, _
                                                                     .Box_ID = Me.qBail.Box_ID, _
                                                                     .Details = "صرفت بشكل اتوماتيكي من قبل البرنامج.", _
                                                                     .Family_ID = fam.ID, _
                                                                     .IsDeposite = False, _
                                                                     .Name = "كفالة مقدمة من " & Getter.GetFullName(Me.qBail.Supporter.Name), _
                                                                     .Note = "يمكنك إيقاف عملية الصرف الأوتماتيكي من خيارات الصرف", _
                                                                     .RegDate = Date.Now, _
                                                                     .User_ID = frmLogin.CurrentUser.ID}
                                        Odb.Bills.InsertOnSubmit(FBill)
                                        Odb.SubmitChanges()
                                        i += 1
                                        prec = CInt((CDbl(i) / CDbl(all)) * 100D)
                                        ProgressSate.ShowStatueProgress(prec, "")
                                        Application.DoEvents()
                                    Next
                                    ProgressSate.ShowStatueProgress(100, "")
                                End If
                            End If
                        Else
                            If My.Settings.Make_A_Bill_for_every_orphan Then
                                Dim prec = 0, all = 0, i As Integer = 0
                                If Not IsNothing(Me.qBail.Orphans) AndAlso Me.qBail.Orphans.Count > 0 Then
                                    all = Me.qBail.Orphans.Count
                                    For Each orp In Me.qBail.Orphans
                                        Dim FBill As New Bill() With {.Amount = Me.qBail.Amount, _
                                                                     .Bail_ID = Me.qBail.ID, _
                                                                     .Bill_Date = dteDate.Value, _
                                                                     .Bill_Number = 0, _
                                                                     .Box_ID = Me.qBail.Box_ID, _
                                                                     .Details = "صرفت بشكل اتوماتيكي من قبل البرنامج.", _
                                                                     .Orphan_ID = orp.ID, _
                                                                     .IsDeposite = False, _
                                                                     .Name = "كفالة مقدمة من " & Getter.GetFullName(Me.qBail.Supporter.Name), _
                                                                     .Note = "يمكنك إيقاف عملية الصرف الأوتماتيكي من خيارات الصرف", _
                                                                     .RegDate = Date.Now, _
                                                                     .User_ID = frmLogin.CurrentUser.ID}
                                        Odb.Bills.InsertOnSubmit(FBill)
                                        Odb.SubmitChanges()
                                        i += 1
                                        prec = CInt((CDbl(i) / CDbl(all)) * 100D)
                                        ProgressSate.ShowStatueProgress(prec, "")
                                        Application.DoEvents()
                                    Next
                                    ProgressSate.ShowStatueProgress(100, "")
                                End If
                            End If
                        End If
                    Else
                        If Not IsNothing(qBail) AndAlso Not IsNothing(qFam) Then
                            Sbill.Bail_ID = Me.qBail.ID
                            If My.Settings.Make_A_Bill_for_every_Family Then
                                If Me.qBail.Is_Family Then
                                    If Not IsNothing(Me.qBail.Families) AndAlso Me.qBail.Families.Count > 0 Then
                                        If qBail.Families.Contains(qFam) Then
                                            Dim FBill As New Bill() With {.Amount = Me.qBail.Amount, _
                                                        .Bail_ID = Me.qBail.ID, _
                                                        .Bill_Date = dteDate.Value, _
                                                        .Bill_Number = 0, _
                                                        .Box_ID = Me.qBail.Box_ID, _
                                                        .Details = "صرفت بشكل اتوماتيكي من قبل البرنامج.", _
                                                        .Family_ID = qFam.ID, _
                                                        .IsDeposite = False, _
                                                        .Name = "كفالة مقدمة من " & Getter.GetFullName(Me.qBail.Supporter.Name), _
                                                        .Note = "يمكنك إيقاف عملية الصرف الأوتماتيكي من خيارات الصرف", _
                                                        .RegDate = Date.Now, _
                                                        .User_ID = frmLogin.CurrentUser.ID}
                                            Odb.Bills.InsertOnSubmit(FBill)
                                            Odb.SubmitChanges()
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            If Not IsNothing(qBail) AndAlso Not IsNothing(qOrph) Then
                                Sbill.Bail_ID = Me.qBail.ID
                                If My.Settings.Make_A_Bill_for_every_orphan Then
                                    If Not Me.qBail.Is_Family Then
                                        If Not IsNothing(Me.qBail.Orphans) AndAlso Me.qBail.Orphans.Count > 0 Then
                                            If qBail.Orphans.Contains(qOrph) Then
                                                Dim FBill As New Bill() With {.Amount = Me.qBail.Amount, _
                                                            .Bail_ID = Me.qBail.ID, _
                                                            .Bill_Date = dteDate.Value, _
                                                            .Bill_Number = 0, _
                                                            .Box_ID = Me.qBail.Box_ID, _
                                                            .Details = "صرفت بشكل اتوماتيكي من قبل البرنامج.", _
                                                            .Orphan_ID = qOrph.ID, _
                                                            .IsDeposite = False, _
                                                            .Name = "كفالة مقدمة من " & Getter.GetFullName(Me.qBail.Supporter.Name), _
                                                            .Note = "يمكنك إيقاف عملية الصرف الأوتماتيكي من خيارات الصرف", _
                                                            .RegDate = Date.Now, _
                                                            .User_ID = frmLogin.CurrentUser.ID}
                                                Odb.Bills.InsertOnSubmit(FBill)
                                                Odb.SubmitChanges()
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If optDeposite.IsChecked Then
                        'Deposite
                        Sbill.IsDeposite = True
                        Sbox.Amount += numAmount.Value
                    Else
                        'Draw
                        Sbill.IsDeposite = False
                        If Sbox.Is_Positive AndAlso Sbox.Amount >= numAmount.Value Then
                            Sbox.Amount -= numAmount.Value
                        ElseIf Not Sbox.Is_Positive Then
                            Sbox.Amount -= numAmount.Value
                        Else
                            ExceptionsManager.RaiseOnStatus(New MyException("المبلغ المطلوب سحبه غير موجود بالحساب " & Sbox.Name, False, True))
                            Return
                        End If
                    End If
                    If Not IsNothing(PictureSelector1.PhotoAsBytes) Then
                        Sbill.Photo = PictureSelector1.PhotoAsBytes
                    End If
                    If Not IsNothing(txtDetails.Text) AndAlso txtDetails.Text.Length > 0 Then
                        Sbill.Details = txtDetails.Text
                    End If
                    If Not IsNothing(txtNote.Text) AndAlso txtNote.Text.Length > 0 Then
                        Sbill.Note = txtNote.Text
                    End If
                    Sbill.User_ID = frmLogin.CurrentUser.ID
                    Sbill.RegDate = Date.Now
                    Odb.Bills.InsertOnSubmit(Sbill)
                    Odb.SubmitChanges()
                    tr.Complete()
                    Try
                        ProgressSate.ShowStatueProgress(100, "")
                        Updater.AddNewBill(Sbill)
                        Updater.UpdatesBox(Sbill.Box)
                    Catch
                    End Try
                End Using
                Odb.Dispose()
                Me.Close()
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub
    Public Sub New()
        InitializeComponent()
        Me.NoParameter = True
    End Sub
    Public Sub New(ByVal pbox_ID As Integer)
        InitializeComponent()
        Me.NoParameter = True
        Me.qBox_ID = pbox_ID
    End Sub
    Public Sub New(ByVal isDeposite As Boolean)
        InitializeComponent()
        Me._is_Deposite = isDeposite
    End Sub
    Public Sub New(ByVal isDeposite As Boolean, ByVal fam As Family)
        InitializeComponent()
        Me.qFam = fam
        Me._is_Deposite = isDeposite
    End Sub
    Public Sub New(ByVal isDeposite As Boolean, ByVal bal As Bail)
        InitializeComponent()
        Me.qBail = bal
        Me._is_Deposite = isDeposite
    End Sub
    Public Sub New(ByVal isDeposite As Boolean, ByVal bal As Bail, ByVal fam As Family)
        InitializeComponent()
        Me.qBail = bal
        Me.qFam = fam
        Me._is_Deposite = isDeposite
    End Sub
    Public Sub New(ByVal isDeposite As Boolean, ByVal bal As Bail, ByVal orh As Orphan)
        InitializeComponent()
        Me.qBail = bal
        Me.qOrph = orh
        Me._is_Deposite = isDeposite
    End Sub
    Public Sub New(ByVal isDeposite As Boolean, ByVal orh As Orphan)
        InitializeComponent()
        Me.qOrph = orh
        Me._is_Deposite = isDeposite
    End Sub
    Public Sub New(ByVal isDeposite As Boolean, ByVal pbox As Integer)
        InitializeComponent()
        Me.qBox_ID = pbox
        Me._is_Deposite = isDeposite
    End Sub

    Private Sub txtSide_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSide.Enter, txtNote.Enter, txtDetails.Enter
        LangChanger.CurLang.SaveCurrentLanguage()
        LangChanger.CurLang.ChangeToArabic()
    End Sub

    Private Sub txtSide_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSide.Leave, numAmount.Leave, txtNote.Leave, txtDetails.Leave
        LangChanger.CurLang.ReturnToSavedLanguage()
    End Sub

    Private Sub numAmount_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numAmount.Enter
        LangChanger.CurLang.SaveCurrentLanguage()
        LangChanger.CurLang.ChangeToEnglish()
    End Sub
    Private Sub MakeDetails()
        Dim srt1 As String = ""
        Dim nfi As Globalization.NumberFormatInfo = New CultureInfo("en-US", False).NumberFormat
        If lblCurrency.Text <> "" AndAlso lblCurrency.Text.Length > 0 Then
            nfi.CurrencySymbol = lblCurrency.Text
        Else
            Exit Sub
        End If
        nfi.NumberDecimalDigits = 2        
        If optDeposite.IsChecked Then
            If txtSide.Text.Length > 0 Then
                srt1 = "قبضت من السيد " & txtSide.Text & " مبلغ " & numAmount.Value.ToString(nfi)
            Else
                Exit Sub
            End If
        Else
            If txtSide.Text.Length > 0 Then
                srt1 = "دفعت للسيد " & txtSide.Text & " مبلغ " & numAmount.Value.ToString(nfi)
            Else
                Exit Sub
            End If
        End If
        txtDetails.Text = srt1 & vbNewLine & "وذلك لقاء "
    End Sub

    Private Sub numAmount_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numAmount.ValueChanged
        MakeDetails()
    End Sub

    Private Sub PictureSelector1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureSelector1.DoubleClick
        Try
            Dim frm As New FrmShowPic(PictureSelector1.Photo, "إيصال لــ " & txtSide.Text)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        Catch

        End Try
    End Sub
End Class
