Public Class FrmSupporter
    'Private Odb As New OrphanageDB.Odb()
    Private Sup_ID As Integer = -1
    Private Delegate Sub AutoCompleteDelegate()
    Private CallAutoComplete As New AutoCompleteDelegate(AddressOf SetAutoComplete)
    Private Sbox_ID As Integer = -1
    Dim t As New Threading.Thread(AddressOf CallAutoCompleteThread)

    Public Sub SetNameForm(ByVal obj As OrphanageClasses.Name)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            NameForm1.First = obj.First
            NameForm1.Middle = obj.Father
            NameForm1.Last = obj.Last
            NameForm1.English_First = obj.EName
            NameForm1.English_Last = obj.ELast
            NameForm1.English_Middle = obj.EFather
            txtName.Text = Getter.GetFullName(obj)
        End If
    End Sub
    Public Sub GetFromNameObject(ByRef obj As OrphanageClasses.Name)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            obj.First = NameForm1.First
            obj.Father = NameForm1.Middle
            obj.Last = NameForm1.Last
            obj.EName = NameForm1.English_First
            obj.ELast = NameForm1.English_Last
            obj.EFather = NameForm1.English_Middle
        Else
            obj = New OrphanageClasses.Name()
            obj.First = NameForm1.First
            obj.Father = NameForm1.Middle
            obj.Last = NameForm1.Last
            obj.EName = NameForm1.English_First
            obj.ELast = NameForm1.English_Last
            obj.EFather = NameForm1.English_Middle
        End If
    End Sub
    Public Sub SetAddressForm(ByVal obj As OrphanageClasses.Address)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            AddressForm1.Country = obj.Country
            AddressForm1.City = obj.City
            AddressForm1.Town = obj.Town
            AddressForm1.Street = obj.Street
            AddressForm1.CellPhone = obj.Cell_Phone
            AddressForm1.HomePhone = obj.Home_Phone
            AddressForm1.WorkPhone = obj.Work_Phone
            AddressForm1.Skype = obj.Twitter
            AddressForm1.Email = obj.Email
            AddressForm1.Fax = obj.Fax
            AddressForm1.Facebook = obj.Facebook
            AddressForm1.Note = obj.Note
            txtAddress.Text = Getter.GetAddress(obj)
        End If
    End Sub
    Public Sub GetFromAddressForm1(ByRef obj As OrphanageClasses.Address)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            obj.Country = AddressForm1.Country
            obj.City = AddressForm1.City
            obj.Town = AddressForm1.Town
            obj.Street = AddressForm1.Street
            obj.Cell_Phone = AddressForm1.CellPhone
            obj.Home_Phone = AddressForm1.HomePhone
            obj.Work_Phone = AddressForm1.WorkPhone
            obj.Twitter = AddressForm1.Skype
            obj.Email = AddressForm1.Email
            obj.Fax = AddressForm1.Fax
            obj.Facebook = AddressForm1.Facebook
            obj.Note = AddressForm1.Note
        Else
            obj = New OrphanageClasses.Address()
            obj.Country = AddressForm1.Country
            obj.City = AddressForm1.City
            obj.Town = AddressForm1.Town
            obj.Street = AddressForm1.Street
            obj.Cell_Phone = AddressForm1.CellPhone
            obj.Home_Phone = AddressForm1.HomePhone
            obj.Work_Phone = AddressForm1.WorkPhone
            obj.Twitter = AddressForm1.Skype
            obj.Email = AddressForm1.Email
            obj.Fax = AddressForm1.Fax
            obj.Facebook = AddressForm1.Facebook
            obj.Note = AddressForm1.Note
        End If
    End Sub
    Private Sub CallAutoCompleteThread()
        Try
            Me.Invoke(CallAutoComplete)
        Catch
        End Try
    End Sub
    Public Sub SetAutoComplete()
        Using Odb As New OrphanageDB.Odb
            Odb.ObjectTrackingEnabled = False
            Dim qN = From nam In Odb.Names Distinct Select EF = nam.EName, EL = nam.ELast, Efath = nam.EFather
            Dim qFirst = From nam In Odb.Names Where nam.EName.Length > 0 Select nam.EName Distinct
            Dim qFath = From nam In Odb.Names Where nam.EFather.Length > 0 Select nam.EFather Distinct
            Dim qLast = From nam In Odb.Names Where nam.ELast.Length > 0 Select nam.ELast Distinct

            Dim xx = qFath.Where(Function(x) Not qFirst.Contains(x))
            NameForm1.English_First_AutoComplete.AddRange(qFirst.ToArray())
            NameForm1.English_Middle_AutoComplete.AddRange(qFirst.ToArray())
            NameForm1.English_First_AutoComplete.AddRange(xx.ToArray())
            NameForm1.English_Middle_AutoComplete.AddRange(xx.ToArray())

            NameForm1.English_Last_AutoComplete.AddRange(qLast.ToArray())
            'Dim EFNamse As New ArrayList
            'Dim ELNamse As New ArrayList
            'For Each Nm In qN
            '    If Not IsNothing(Nm.EF) AndAlso Nm.EF.Length > 0 AndAlso Not EFNamse.Contains(Nm.EF) Then
            '        EFNamse.Add(Nm.EF)
            '    End If
            '    If Not IsNothing(Nm.Efath) AndAlso Nm.Efath.Length > 0 AndAlso Not EFNamse.Contains(Nm.Efath) Then
            '        EFNamse.Add(Nm.Efath)
            '    End If
            '    If Not IsNothing(Nm.EL) AndAlso Nm.EL.Length > 0 AndAlso Not ELNamse.Contains(Nm.EL) Then
            '        ELNamse.Add(Nm.EL)
            '    End If
            'Next
            'If EFNamse.Count > 0 Then
            '    NameForm1.English_First_AutoComplete.AddRange(CType(EFNamse.ToArray(GetType(String)), String()))
            '    NameForm1.English_Middle_AutoComplete.AddRange(CType(EFNamse.ToArray(GetType(String)), String()))
            'End If
            'If ELNamse.Count > 0 Then
            '    NameForm1.English_Last_AutoComplete.AddRange(CType(ELNamse.ToArray(GetType(String)), String()))
            'End If
            'Dim AddCountr As New ArrayList()
            Dim qACou = From j In Odb.Addresses Where j.Country.Length > 0 Select j.Country Distinct
            'For Each jp In qACou
            '    If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not AddCountr.Contains(jp) Then
            '        AddCountr.Add(jp)
            '    End If
            'Next
            AddressForm1.Country_AutoComplete.AddRange(qACou.ToArray())
            'Dim AddCity As New ArrayList()
            Dim qAcit = From j In Odb.Addresses Where j.City.Length > 0 Select j.City Distinct
            'For Each jp In qAcit
            '    If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not AddCity.Contains(jp) Then
            '        AddCity.Add(jp)
            '    End If
            'Next
            AddressForm1.City_AutoComplete.AddRange(qAcit.ToArray())
            'Dim addTown As New ArrayList()
            Dim qATo = From j In Odb.Addresses Where j.Town.Length > 0 Select j.Town Distinct
            'For Each jp In qATo
            '    If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not addTown.Contains(jp) Then
            '        addTown.Add(jp)
            '    End If
            'Next
            AddressForm1.Town_AutoComplete.AddRange(qATo.ToArray())
            'Dim AddStreet As New ArrayList()
            Dim qAStr = From j In Odb.Addresses Where j.Street.Length > 0 Select j.Street Distinct
            'For Each jp In qAStr
            '    If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not AddStreet.Contains(jp) Then
            '        AddStreet.Add(jp)
            '    End If
            'Next
            AddressForm1.Street_AutoComplete.AddRange(qAStr.ToArray())
            Odb.Dispose()
        End Using
    End Sub

    Private Sub txtName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.Enter
        NameForm1.ShowMe()
        AddressForm1.HideMe()
    End Sub

    Private Sub txtAddress_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress.Enter
        AddressForm1.ShowMe()
        NameForm1.HideMe()
    End Sub

    Private Sub FrmSupporter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click, txtNote.Click, RadLabel7.Click, RadLabel2.Click, RadLabel1.Click
        If AddressForm1.Visible Then
            AddressForm1.HideMe()
            txtAddress.Text = Getter.GetAddress(AddressForm1)
        End If

        If NameForm1.Visible Then
            NameForm1.HideMe()
            txtName.Text = Getter.GetFullName(NameForm1)
        End If
    End Sub

    Public Sub New(ByVal Id As Integer)
        InitializeComponent()
        If Id > 0 Then
            Using Odb As New OrphanageDB.Odb
                Me.Sup_ID = Id
                Odb.Dispose()
                If IsNothing(Getter.GetSupporterByID(Id, Odb)) Then
                    ExceptionsManager.RaiseOnStatus(New MyException("الكفيل رقم " & Id.ToString() & " غير موجود!", True, True))
                    Me.Close()
                End If
            End Using
        Else
            ExceptionsManager.RaiseOnStatus(New MyException("الكفيل رقم " & Id.ToString() & " غير موجود!", True, True))
            Me.Close()
        End If
    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtName.Text.Length = 0 Then
                ExceptionsManager.RaiseOnStatus(New MyException("عليك إدخال اسم الكفيل أولاً", True, False))
                Return
            End If
            If txtAccountName.Text.Length = 0 OrElse Me.Sbox_ID <= 0 Then
                ExceptionsManager.RaiseOnStatus(New MyException("عليك اختيار حساب الكفيل أولاً", True, False))
                Return
            End If
            If Me.Sup_ID <= 0 Then
                'Add New Supporter
                Dim add As OrphanageClasses.Address = Nothing
                Dim SName As New OrphanageClasses.Name()
                Using Odb As New OrphanageDB.Odb
                    Using tr = New Transactions.TransactionScope()
                        GetFromNameObject(SName)
                        Odb.Names.InsertOnSubmit(SName)
                        Odb.SubmitChanges()
                        Dim NewSup = New OrphanageClasses.Supporter() With {.Name_ID = SName.ID, .Box_ID = Me.Sbox_ID, _
                                                                       .Is_Family_Support = chkOnlyFamiles.Checked, _
                                                                        .Is_Monthly_Support = chkIsMonthly.Checked, _
                                                                        .Is_Still_Support = chkStillActive.Checked, _
                                                                        .Note = txtNote.Text, .RegDate = Date.Now, _
                                                                        .User_ID = frmLogin.CurrentUser.ID}
                        If txtAddress.Text.Length > 0 Then
                            add = New OrphanageClasses.Address()
                            GetFromAddressForm1(add)
                            Odb.Addresses.InsertOnSubmit(add)
                            Odb.SubmitChanges()
                            NewSup.Address_ID = add.ID
                        End If
                        Odb.Supporters.InsertOnSubmit(NewSup)
                        Odb.SubmitChanges()
                        tr.Complete()
                        Try
                            Updater.AddNewSupporter(NewSup)
                        Catch ex As Exception
                        End Try
                        ExceptionsManager.RaiseSaved()
                        Me.Close()
                    End Using
                End Using
            Else
                ' Update Supporter
                Using Odb As New OrphanageDB.Odb
                    Using tr = New Transactions.TransactionScope()
                        Dim q = From sup In Odb.Supporters Where sup.ID = Me.Sup_ID Select sup
                        Dim qbx = From bx In Odb.Boxes Where bx.ID = Me.Sbox_ID Select bx
                        For Each qSup In q
                            GetFromNameObject(qSup.Name)
                            If txtAddress.Text.Length > 0 Then
                                GetFromAddressForm1(qSup.Address)
                            Else
                                If qSup.Address_ID.HasValue Then
                                    Odb.Addresses.DeleteOnSubmit(qSup.Address)
                                    Odb.SubmitChanges()
                                End If
                            End If
                            Odb.SubmitChanges()
                            qSup.Box_ID = qbx.FirstOrDefault().ID
                            Odb.SubmitChanges()
                            qSup.Is_Family_Support = chkOnlyFamiles.Checked
                            qSup.Is_Monthly_Support = chkIsMonthly.Checked
                            qSup.Is_Still_Support = chkStillActive.Checked
                            qSup.Note = txtNote.Text
                            qSup.User_ID = frmLogin.CurrentUser.ID
                            Odb.SubmitChanges()
                            Try
                                Updater.UpdatesSupporter(qSup)
                            Catch
                            End Try
                        Next
                        tr.Complete()
                        ExceptionsManager.RaiseSaved()
                        Me.Close()
                    End Using
                End Using
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub FrmSupporter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        t.Priority = Threading.ThreadPriority.Lowest
        t.Start()
        If Me.Sup_ID > 0 Then
            Using Odb As New OrphanageDB.Odb
                Odb.ObjectTrackingEnabled = False
                Dim Qsup = From sup In Odb.Supporters Where sup.ID = Me.Sup_ID Select
                           sup.Name, sup.Address, sup.Box, sup
                SetNameForm(Qsup.FirstOrDefault().Name)
                If Not IsNothing(Qsup.FirstOrDefault().Address) Then
                    SetAddressForm(Qsup.FirstOrDefault().Address)
                End If
                txtAccountName.Text = Qsup.FirstOrDefault().Box.Name & " " & Qsup.FirstOrDefault().Box.Currency_Short
                txtNote.Text = Qsup.FirstOrDefault().sup.Note
                chkIsMonthly.Checked = Qsup.FirstOrDefault().sup.Is_Monthly_Support
                chkOnlyFamiles.Checked = Qsup.FirstOrDefault().sup.Is_Family_Support
                chkStillActive.Checked = Qsup.FirstOrDefault().sup.Is_Still_Support
                Me.Sbox_ID = Qsup.FirstOrDefault().Box.ID
                Me.Text &= " " & txtName.Text
            End Using
        End If
    End Sub

    Private Sub btnChooseAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseAccount.Click
        Dim frmB As New FrmBoxChooser(False)
        frmB.ShowDialog()
        If frmB.DialogResult = Windows.Forms.DialogResult.OK Then
            If frmB.SelectedBox > 0 Then
                Using Odb As New OrphanageDB.Odb
                    Odb.ObjectTrackingEnabled = False
                    Dim q = From bx In Odb.Boxes Where bx.ID = frmB.SelectedBox
                    Me.Sbox_ID = q.FirstOrDefault().ID
                    txtAccountName.Text = q.FirstOrDefault().Name & " " & q.FirstOrDefault().Currency_Short
                    Odb.Dispose()
                End Using
            End If
        End If
        frmB.Dispose()
    End Sub
End Class
