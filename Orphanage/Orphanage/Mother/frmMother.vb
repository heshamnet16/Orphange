Imports Itenso.TimePeriod
Imports Orphanage.OrphanageClasses

Public Class FrmMother
    Private _ID As Integer
    'Private Odb As New OrphanageDB.Odb()
    Private _moth As Mother
    Private Delegate Sub AutoCompleteDelegate()
    Private CallAutoComplete As New AutoCompleteDelegate(AddressOf SetAutoComplete)
    Dim t As New Threading.Thread(AddressOf CallAutoCompleteThread)

    Public Sub New(ByVal id As Integer)
        InitializeComponent()
        Me._ID = id
    End Sub

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
    Public Sub GetFromNameForm1(ByRef obj As OrphanageClasses.Name)
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

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Try
            Using Odb As New OrphanageDB.Odb
                Dim q = From fth In Odb.Mothers Where fth.ID = _ID Select fth
                Dim motH As OrphanageClasses.Mother = q.FirstOrDefault()
                Dim qBo = From bo In Odb.BondsMans Where bo.IdentityCard_ID = motH.IdntityCard_ID Select bo.Name_ID
                Dim bond As Integer = qBo.FirstOrDefault()
                If My.Settings.CheckIdentityBeforEdit Then
                    If Not Checker.checkMotherControls(dteBirthday, chkIsDead, dteDieDate, numIdentitynmber, NameForm1.First, NameForm1.Last, New Integer() {motH.Name_ID, bond}) Then
                        Return
                    End If
                Else
                    Dim Tid = numIdentitynmber
                    Tid.Value = 0
                    If Not Checker.checkMotherControls(dteBirthday, chkIsDead, dteDieDate, Tid, NameForm1.First, NameForm1.Last, New Integer() {motH.Name_ID, bond}) Then
                        Return
                    End If
                End If
                GetFromAddressForm1(motH.Address)
                GetFromNameForm1(motH.Name)
                If Not IsNothing(motH.Husband_Name) Then
                    txtHusbandName.Text = motH.Husband_Name
                End If
                motH.IsDead = chkIsDead.Checked
                motH.IsMarried = chkIsMarried.Checked
                motH.IsOwnOrphans = chkIsOwnOrphan.Checked
                motH.Jop = txtJop.Text
                motH.Note = txtNote.Text
                motH.Story = txtStory.Text
                motH.IdntityCard_ID = CType(numIdentitynmber.Value, ULong?)
                motH.Salary = numSalary.Value
                motH.Birthday = dteBirthday.Value
                If chkIsDead.Checked Then
                    motH.Dieday = dteDieDate.Value
                Else
                    motH.Dieday = Nothing
                End If
                motH.IdentityCard_Photo2 = picIdentityCardBack.PhotoAsBytes
                motH.IdentityCard_Photo = picIdentityCardFace.PhotoAsBytes
                If clrColor.Value <> Color.White Then
                    motH.Color_Mark = clrColor.Value.ToArgb()
                Else
                    motH.Color_Mark = Nothing
                End If
                Odb.SubmitChanges()
                Updater.UpdatesMother(motH)
                ExceptionsManager.RaiseOnDesktopNow(New MyException("تم الحفظ", False, True))
                Me.DialogResult = DialogResult.OK
                Odb.Dispose()
                Me.Close()
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnDesktopNow(New MyException(ex.Message, True, True))
        End Try
    End Sub
    Private Sub CallAutoCompleteThread()
        Me.Invoke(CallAutoComplete)
    End Sub
    Public Sub SetAutoComplete()
        Try
            Using Odb As New OrphanageDB.Odb
                Odb.ObjectTrackingEnabled = False
                'Dim qN = From nam In Odb.Names Select EF = nam.EName, EL = nam.ELast, Efath = nam.EFather Distinct
                Dim qFirst = From nam In Odb.Names Where nam.EName.Length > 0 Select nam.EName Distinct
                Dim qFath = From nam In Odb.Names Where nam.EFather.Length > 0 Select nam.EFather Distinct
                Dim qLast = From nam In Odb.Names Where nam.ELast.Length > 0 Select nam.ELast Distinct
                Dim xx = qFath.Where(Function(x) Not qFirst.Contains(x))

                NameForm1.English_First_AutoComplete.AddRange(qFirst.ToArray())
                NameForm1.English_Middle_AutoComplete.AddRange(qFirst.ToArray())
                NameForm1.English_First_AutoComplete.AddRange(xx.ToArray())
                NameForm1.English_Middle_AutoComplete.AddRange(xx.ToArray())

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
                Dim qJ = From j In Odb.Fathers Where j.Jop.Length > 0 Select j.Jop Distinct
                txtJop.AutoCompleteCustomSource.AddRange(qJ.ToArray())
                'Dim JopArr As New ArrayList()
                'For Each jp In qJ
                '    If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not JopArr.Contains(jp) Then
                '        JopArr.Add(jp)
                '    End If
                'Next
                'If JopArr.Count > 0 Then
                '    txtJop.AutoCompleteCustomSource.AddRange(CType(JopArr.ToArray(GetType(String)), String()))
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
        Catch
        End Try
    End Sub

    Private Sub FrmMother_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If _ID > 0 Then
            t.Priority = Threading.ThreadPriority.Lowest
            t.Start()
            Using Odb As New OrphanageDB.Odb
                Dim q = From Mot In Odb.Mothers Where Mot.ID = _ID Select Mot
                Dim MotH As OrphanageClasses.Mother = q.FirstOrDefault()
                _moth = MotH
                If IsNothing(MotH) Then
                    Dim myexc As New MyException("الأم رقم " & _ID.ToString() & " غير موجود.", True, True)
                    Me.Close()
                    Return
                Else
                    SetAddressForm(MotH.Address)
                    SetNameForm(MotH.Name)
                    If Not IsNothing(MotH.Husband_Name) Then
                        txtHusbandName.Text = MotH.Husband_Name
                    End If
                    chkIsDead.Checked = MotH.IsDead
                    chkIsMarried.Checked = MotH.IsMarried
                    chkIsOwnOrphan.Checked = MotH.IsOwnOrphans
                    txtJop.Text = MotH.Jop
                    txtNote.Text = MotH.Note
                    txtStory.Text = MotH.Story
                    If MotH.IdntityCard_ID.HasValue Then
                        numIdentitynmber.Value = MotH.IdntityCard_ID.Value
                    End If
                    If MotH.Salary.HasValue Then
                        numSalary.Value = MotH.Salary.Value
                    End If
                    dteBirthday.Value = MotH.Birthday
                    If Not IsNothing(MotH.Dieday) AndAlso MotH.Dieday.HasValue Then
                        dteDieDate.Value = MotH.Dieday.Value
                    Else
                        dteDieDate.Enabled = False
                    End If
                    picIdentityCardBack.SetImageByBytes(MotH.IdentityCard_Photo2)
                    picIdentityCardFace.SetImageByBytes(MotH.IdentityCard_Photo)
                    If Not IsNothing(MotH.Color_Mark) AndAlso MotH.Color_Mark.HasValue Then
                        clrColor.Value = Color.FromArgb(CInt(MotH.Color_Mark.Value))
                    Else
                        clrColor.Value = Color.White
                    End If
                    If MotH.IsDead Then
                        dteDieDate.Enabled = True
                    Else
                        dteDieDate.Enabled = False
                    End If
                    If MotH.IsMarried Then
                        txtHusbandName.Enabled = True
                    Else
                        txtHusbandName.Enabled = False
                    End If
                    Me.Text = "الأم " & Getter.GetFullName(MotH.Name)
                    txtName.Focus()
                    End If
                    Odb.Dispose()
            End Using
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress.Click
        If txtAddress.Enabled Then
            AddressForm1.ShowMe()
            NameForm1.HideMe()
        End If
    End Sub

    Private Sub RadGroupBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStory.Click, txtHusbandName.Click, RadGroupBox2.Click, RadGroupBox1.Click, picIdentityCardBack.Click, MyBase.Click, RadLabel9.Click, RadLabel8.Click, RadLabel6.Click, RadLabel5.Click, RadLabel4.Click, RadLabel3.Click, RadLabel16.Click, RadLabel15.Click, RadLabel14.Click, RadLabel13.Click, RadLabel12.Click, RadLabel11.Click, RadLabel1.Click
        If AddressForm1.Visible Then
            AddressForm1.HideMe()
            txtAddress.Text = Getter.GetAddress(AddressForm1)
        End If

        If NameForm1.Visible Then
            NameForm1.HideMe()
            txtName.Text = Getter.GetFullName(NameForm1)
        End If
    End Sub

    Private Sub chkIsDead_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkIsDead.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            dteDieDate.Enabled = True
        Else
            dteDieDate.Enabled = False
        End If
    End Sub

    Private Sub chkIsMarried_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkIsMarried.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            txtHusbandName.Enabled = True
        Else
            txtHusbandName.Enabled = False
        End If
    End Sub

    Private Sub txtAddress_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress.Enter
        If txtAddress.Enabled Then
            AddressForm1.ShowMe()
            NameForm1.HideMe()
        End If
    End Sub


    Private Sub txtName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.Click
        NameForm1.ShowMe()
        AddressForm1.HideMe()
    End Sub

    Private Sub txtName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.Enter
        NameForm1.ShowMe()
        AddressForm1.HideMe()
    End Sub
    Private Sub picPhoto_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picIdentityCardFace.DoubleClick, picIdentityCardBack.DoubleClick
        Try
            If Not IsNothing(CType(sender, PictureSelector.PictureSelector).Photo) Then
                Dim picxx As PictureSelector.PictureSelector = CType(sender, PictureSelector.PictureSelector)
                Dim frmShopic As New FrmShowPic(picxx.Photo)
                frmShopic.Show(Me)
            End If
        Catch

        End Try
    End Sub
End Class
