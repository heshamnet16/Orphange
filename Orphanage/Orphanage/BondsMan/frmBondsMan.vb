Imports Orphanage.OrphanageClasses

Public Class FrmBondsMan
    Private _ID As Integer = 0
    ' Private Odb As New OrphanageDB.Odb()
    'Public BondsManObj As OrphanageClasses.BondsMan = Nothing
    Private Delegate Sub AutoCompleteDelegate()
    Private CallAutoComplete As New AutoCompleteDelegate(AddressOf SetAutoComplete)
    Dim t As New Threading.Thread(AddressOf CallAutoCompleteThread)
    Private Sub CallAutoCompleteThread()
        Me.Invoke(CallAutoComplete)
    End Sub
    Public Sub SetAutoComplete()
        Try
            Using Odb As New OrphanageDB.Odb
                Odb.ObjectTrackingEnabled = False
                'Dim qN = From nam In Odb.Names  Select EF = nam.EName, EL = nam.ELast, Efath = nam.EFather Distinct
                Dim qEname = From nam In Odb.Names Where nam.EName.Length > 0 Select nam.EName Distinct
                Dim qFath = From nam In Odb.Names Where nam.EFather.Length > 0 Select nam.EFather Distinct
                Dim qLast = From nam In Odb.Names Where nam.ELast.Length > 0 Select nam.ELast Distinct
                'For Each Nm In qN
                '    If Not IsNothing(Nm.EF) AndAlso Nm.EF.Length > 0 AndAlso Not NameForm1.English_First_AutoComplete.Contains(Nm.EF) Then
                '        NameForm1.English_First_AutoComplete.Add(Nm.EF)
                '    End If
                '    If Not IsNothing(Nm.Efath) AndAlso Nm.Efath.Length > 0 AndAlso Not NameForm1.English_Middle_AutoComplete.Contains(Nm.Efath) Then
                '        NameForm1.English_Middle_AutoComplete.Add(Nm.Efath)
                '    End If
                '    If Not IsNothing(Nm.EL) AndAlso Nm.EL.Length > 0 AndAlso Not NameForm1.English_Last_AutoComplete.Contains(Nm.EL) Then
                '        NameForm1.English_Last_AutoComplete.Add(Nm.EL)
                '    End If
                '    Application.DoEvents()
                'Next
                Dim xx = qFath.Where(Function(x) qEname.Contains(x) = False)
                NameForm1.English_First_AutoComplete.AddRange(qEname.ToArray())
                NameForm1.English_Middle_AutoComplete.AddRange(qEname.ToArray())
                NameForm1.English_First_AutoComplete.AddRange(xx.ToArray())
                NameForm1.English_Middle_AutoComplete.AddRange(xx.ToArray())
                NameForm1.English_Last_AutoComplete.AddRange(qLast.ToArray())
                Dim qJ = From j In Odb.BondsMans Where j.Jop.Length > 0 Select j.Jop Distinct
                'For Each jp In qJ
                '    If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not txtjop.AutoCompleteCustomSource.Contains(jp) Then
                '        txtjop.AutoCompleteCustomSource.Add(jp)
                '    End If
                '    Application.DoEvents()
                'Next
                txtjop.AutoCompleteCustomSource.AddRange(qJ.ToArray())
                Dim qACou = From j In Odb.Addresses Where j.Country.Length > 0 Select j.Country Distinct
                'For Each jp In qACou
                '    If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not AddressForm1.Country_AutoComplete.Contains(jp) Then
                '        AddressForm1.Country_AutoComplete.Add(jp)
                '    End If
                '    Application.DoEvents()
                'Next
                AddressForm1.Country_AutoComplete.AddRange(qACou.ToArray())
                Dim qAcit = From j In Odb.Addresses Where j.City.Length > 0 Select j.City Distinct
                'For Each jp In qAcit
                '    If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not AddressForm1.City_AutoComplete.Contains(jp) Then
                '        AddressForm1.City_AutoComplete.Add(jp)
                '    End If
                '    Application.DoEvents()
                'Next
                AddressForm1.City_AutoComplete.AddRange(qAcit.ToArray())
                Dim qATo = From j In Odb.Addresses Where j.Town.Length > 0 Select j.Town Distinct
                'For Each jp In qATo
                '    If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not AddressForm1.Town_AutoComplete.Contains(jp) Then
                '        AddressForm1.Town_AutoComplete.Add(jp)
                '    End If
                '    Application.DoEvents()
                'Next
                AddressForm1.Town_AutoComplete.AddRange(qATo.ToArray())
                Dim qAStr = From j In Odb.Addresses Where j.Street.Length > 0 Select j.Street Distinct
                'For Each jp In qJ
                '    If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not AddressForm1.Street_AutoComplete.Contains(jp) Then
                '        AddressForm1.Street_AutoComplete.Add(jp)
                '    End If
                '    Application.DoEvents()
                'Next
                AddressForm1.Street_AutoComplete.AddRange(qAStr.ToArray())
                Odb.Dispose()
            End Using
        Catch
        End Try
    End Sub

    Public Sub SetNameForm(ByVal obj As OrphanageClasses.Name)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            NameForm1.First = obj.First
            NameForm1.Middle = obj.Father
            NameForm1.Last = obj.Last
            NameForm1.English_First = obj.EName
            NameForm1.English_Last = obj.ELast
            NameForm1.English_Middle = obj.EFather
            txtName.Text = obj.First & " " & obj.Father & " " & obj.Last
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

    Private Function CheckBondsBasic() As Boolean
        If My.Settings.CheckIdentityBeforEdit Then
            Return Checker.CheckBondsBasicControls(txtName, NameForm1.First, NameForm1.Last, numMonthlyIncom, numIdentity)
        Else
            Return Checker.CheckBondsBasicControls(txtName, NameForm1.First, NameForm1.Last, Nothing, numIdentity)
        End If
    End Function

    Public Sub New(ByVal ID As Integer)
        InitializeComponent()
        Me._ID = ID
    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Not CheckBondsBasic() Then
                Return
            End If
            Using Odb As New OrphanageDB.Odb
                If Me._ID <> 0 Then
                    Dim q = From fth In Odb.BondsMans Where fth.ID = _ID Select fth
                    Dim motH As OrphanageClasses.BondsMan = q.FirstOrDefault()
                    GetFromAddressForm1(motH.Address)
                    GetFromNameObject(motH.Name)
                    motH.Jop = txtjop.Text
                    motH.Note = txtNote.Text
                    If numIdentity.Value > 0 Then
                        motH.IdentityCard_ID = numIdentity.Value
                    Else
                        motH.IdentityCard_ID = Nothing
                    End If
                    If numMonthlyIncom.Value > 0 Then
                        motH.Income = numMonthlyIncom.Value
                    Else
                        motH.IdentityCard_ID = Nothing
                    End If
                    motH.IdentityCard_Photo2 = PicIDBack.PhotoAsBytes
                    motH.IdentityCard_Photo = picIDFront.PhotoAsBytes
                    If clrColor.Value <> Color.White Then
                        motH.Color_Mark = clrColor.Value.ToArgb()
                    Else
                        motH.Color_Mark = Nothing
                    End If
                    Odb.SubmitChanges()
                    Updater.UpdatesBondsMan(motH.ID)
                    ExceptionsManager.RaiseOnDesktopNow(New MyException("تم الحفظ", False, True))
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    Dim Moth As New OrphanageClasses.BondsMan()
                    GetFromAddressForm1(Moth.Address)
                    GetFromNameObject(Moth.Name)
                    Moth.Jop = txtjop.Text
                    Moth.Note = txtNote.Text
                    If numIdentity.Value > 0 Then
                        Moth.IdentityCard_ID = numIdentity.Value
                    Else
                        Moth.IdentityCard_ID = Nothing
                    End If
                    If numMonthlyIncom.Value > 0 Then
                        Moth.Income = numMonthlyIncom.Value
                    Else
                        Moth.IdentityCard_ID = Nothing
                    End If
                    Moth.IdentityCard_Photo2 = PicIDBack.PhotoAsBytes
                    Moth.IdentityCard_Photo = picIDFront.PhotoAsBytes
                    If clrColor.Value <> Color.White Then
                        Moth.Color_Mark = clrColor.Value.ToArgb()
                    Else
                        Moth.Color_Mark = Nothing
                    End If
                    Moth.User = frmLogin.CurrentUser
                    Moth.RegDate = Date.Now
                    Odb.BondsMans.InsertOnSubmit(Moth)
                    Odb.SubmitChanges()
                    Updater.AddNewBondsMan(Moth.ID)
                    ExceptionsManager.RaiseOnDesktopNow(New MyException("تم الحفظ", False, True))
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End If
                Odb.Dispose()
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnDesktopNow(New MyException(ex.Message, True, True))
        End Try

    End Sub

    Private Sub picIDFront_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picIDFront.DoubleClick, PicIDBack.DoubleClick
        Dim sen = CType(sender, PictureSelector.PictureSelector)
        If Not IsNothing(sen.Photo) Then
            Dim frm As New FrmShowPic(sen.Photo, Me.txtName.Text)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            WindowsLauncher.AllWindows.Add(frm)
        End If
    End Sub

    Private Sub FrmBondsMan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If _ID > 0 Then
                t.Priority = Threading.ThreadPriority.Lowest
                t.Start()
                Using Odb As New OrphanageDB.Odb
                    Dim q = From fth In Odb.BondsMans Where fth.ID = _ID Select fth
                    Dim bond As OrphanageClasses.BondsMan = q.FirstOrDefault()
                    If IsNothing(bond) Then
                        Dim myexc As New MyException("المعيل رقم " & _ID.ToString() & " غير موجود.", True, True)
                        Me.Close()
                        Return
                    Else
                        txtName.Text = Getter.GetFullName(bond.Name)
                        txtAddress.Text = Getter.GetAddress(bond.Address)
                        If Not IsNothing(bond.Income) AndAlso bond.Income >= 0 Then
                            numMonthlyIncom.Value = bond.Income
                        End If
                        If Not IsNothing(bond.IdentityCard_ID) AndAlso bond.IdentityCard_ID >= 0 Then
                            numIdentity.Value = bond.IdentityCard_ID
                        End If
                        txtjop.Text = bond.Jop
                        txtNote.Text = bond.Note
                        picIDFront.SetImageByBytes(bond.IdentityCard_Photo)
                        PicIDBack.SetImageByBytes(bond.IdentityCard_Photo2)
                        SetNameForm(bond.Name)
                        SetAddressForm(bond.Address)
                        If Not IsNothing(bond.Color_Mark) Then
                            clrColor.Value = Color.FromArgb(bond.Color_Mark)
                        Else
                            clrColor.Value = Color.White
                        End If
                        Me.Text = "المعيل " & Getter.GetFullName(bond.Name)
                    End If
                    Odb.Dispose()
                End Using
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub
    Private Sub txtName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.Enter
        NameForm1.ShowMe()
        AddressForm1.HideMe()
    End Sub
    Private Sub txtAddress_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress.Enter
        AddressForm1.ShowMe()
        NameForm1.HideMe()
    End Sub

    Private Sub RadGroupBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNote.Click, txtjop.Click, RadLabel7.Click, RadLabel6.Click, RadLabel5.Click, RadLabel4.Click, RadLabel1.Click, RadGroupBox2.Click, RadGroupBox1.Click, picIDFront.Click, PicIDBack.Click, numIdentity.Click, MyBase.Click, jhkjdd.Click
        NameForm1.HideMe()
        AddressForm1.HideMe()
        txtName.Text = Getter.GetFullName(NameForm1)        
        txtAddress.Text = Getter.GetAddress(AddressForm1)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub picPhoto_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicIDBack.DoubleClick, picIDFront.DoubleClick
        Try
            Dim picxx As PictureSelector.PictureSelector = CType(sender, PictureSelector.PictureSelector)
            Dim frmShopic As New FrmShowPic(picxx.Photo)
            frmShopic.ShowDialog(Me)
        Catch

        End Try
    End Sub
End Class
