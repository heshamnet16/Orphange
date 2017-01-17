
Public Class FrmFamily
    Private Delegate Sub AutoCompleteDelegate()
    Private CallAutoComplete As New AutoCompleteDelegate(AddressOf SetAutoComplete)
    Dim t As New Threading.Thread(AddressOf CallAutoCompleteThread)
    Dim Odb As New OrphanageDB.Odb()
    Dim _id As Integer = 0


    Public Sub SetAddress1Form(ByVal obj As OrphanageClasses.Address)
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

    Public Sub SetAddressForm2(ByVal obj As OrphanageClasses.Address)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            AddressForm2.Country = obj.Country
            AddressForm2.City = obj.City
            AddressForm2.Town = obj.Town
            AddressForm2.Street = obj.Street
            AddressForm2.CellPhone = obj.Cell_Phone
            AddressForm2.HomePhone = obj.Home_Phone
            AddressForm2.WorkPhone = obj.Work_Phone
            AddressForm2.Skype = obj.Twitter
            AddressForm2.Email = obj.Email
            AddressForm2.Fax = obj.Fax
            AddressForm2.Facebook = obj.Facebook
            AddressForm2.Note = obj.Note
            txtAddress2.Text = Getter.GetAddress(obj)
        End If
    End Sub
    Public Sub GetFromAddressForm2(ByRef obj As OrphanageClasses.Address)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            obj.Country = AddressForm2.Country
            obj.City = AddressForm2.City
            obj.Town = AddressForm2.Town
            obj.Street = AddressForm2.Street
            obj.Cell_Phone = AddressForm2.CellPhone
            obj.Home_Phone = AddressForm2.HomePhone
            obj.Work_Phone = AddressForm2.WorkPhone
            obj.Twitter = AddressForm2.Skype
            obj.Email = AddressForm2.Email
            obj.Fax = AddressForm2.Fax
            obj.Facebook = AddressForm2.Facebook
            obj.Note = AddressForm2.Note
        Else
            obj = New OrphanageClasses.Address()
            obj.Country = AddressForm2.Country
            obj.City = AddressForm2.City
            obj.Town = AddressForm2.Town
            obj.Street = AddressForm2.Street
            obj.Cell_Phone = AddressForm2.CellPhone
            obj.Home_Phone = AddressForm2.HomePhone
            obj.Work_Phone = AddressForm2.WorkPhone
            obj.Twitter = AddressForm2.Skype
            obj.Email = AddressForm2.Email
            obj.Fax = AddressForm2.Fax
            obj.Facebook = AddressForm2.Facebook
            obj.Note = AddressForm2.Note
        End If
    End Sub
    Private Sub CallAutoCompleteThread()
        Me.Invoke(CallAutoComplete)
    End Sub
    Public Sub SetAutoComplete()
        Dim qACou = From j In Odb.Addresses Distinct Select j.Country
        For Each jp In qACou
            If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not AddressForm1.Country_AutoComplete.Contains(jp) Then
                AddressForm1.Country_AutoComplete.Add(jp)
                AddressForm2.Country_AutoComplete.Add(jp)
            End If
            Application.DoEvents()
        Next
        Dim qAcit = From j In Odb.Addresses Distinct Select j.City
        For Each jp In qAcit
            If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not AddressForm1.City_AutoComplete.Contains(jp) Then
                AddressForm1.City_AutoComplete.Add(jp)
                AddressForm2.City_AutoComplete.Add(jp)
            End If
            Application.DoEvents()
        Next
        Dim qATo = From j In Odb.Addresses Distinct Select j.Town
        For Each jp In qATo
            If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not AddressForm1.Town_AutoComplete.Contains(jp) Then
                AddressForm1.Town_AutoComplete.Add(jp)
                AddressForm2.Town_AutoComplete.Add(jp)
            End If
            Application.DoEvents()
        Next
        Dim qAStr = From j In Odb.Addresses Distinct Select j.Street
        For Each jp In qAStr
            If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not AddressForm1.Street_AutoComplete.Contains(jp) Then
                AddressForm1.Street_AutoComplete.Add(jp)
                AddressForm2.Street_AutoComplete.Add(jp)
            End If
            Application.DoEvents()
        Next
    End Sub

    Private Sub chkIsRefugee_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkIsRefugee.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            txtAddress2.Enabled = True
            lblAddress2.Enabled = True
        Else
            txtAddress2.Enabled = False
            lblAddress2.Enabled = False
        End If
    End Sub
    Private Sub FrmFamily_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click, RadGroupBox8.Click, RadGroupBox2.Click, txtResidenceType.Click, RadLabel41.Click, picCardphoto1.Click, RadGroupBox3.Click
        If AddressForm1.Visible Then
            AddressForm1.HideMe()
            txtAddress.Text = Getter.GetAddress(AddressForm1)
        End If
        If AddressForm2.Visible Then
            AddressForm2.HideMe()
            txtAddress2.Text = Getter.GetAddress(AddressForm2)
        End If
    End Sub
    Private Sub txtAddress_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress.Enter, txtAddress.Click
        If Not AddressForm1.Visible Then
            If AddressForm2.Visible Then
                AddressForm2.HideMe()
            End If
            AddressForm1.ShowMe()
        End If
    End Sub
    Private Sub txtAddress2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress2.Enter, txtAddress2.Click
        If Not AddressForm2.Visible Then
            If AddressForm1.Visible Then
                AddressForm1.HideMe()
            End If
            AddressForm2.ShowMe()
        End If
    End Sub

    Private Sub FrmFamily_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If _id > 0 Then
            t.Priority = Threading.ThreadPriority.Lowest
            t.Start()
            Dim q = From Mot In Odb.Families Where Mot.ID = _id Select Mot
            Dim Fam As OrphanageClasses.Family = q.FirstOrDefault()
            If IsNothing(Fam) Then
                Dim myexc As New MyException("العائلة رقم " & _id.ToString() & " غير موجود.", True, True)
                Me.Close()
                Return
            Else
                If Fam.Address_ID.HasValue Then
                    SetAddress1Form(Fam.Address)
                End If
                If Fam.Address_ID2.HasValue Then
                    SetAddressForm2(Fam.Address1)
                    txtAddress2.Enabled = True
                    lblAddress2.Enabled = True
                Else
                    txtAddress2.Enabled = False
                    lblAddress2.Enabled = False
                End If
                chkIsRefugee.Checked = Fam.IsRefugee
                If Not chkIsRefugee.Checked Then
                    txtAddress2.Enabled = False
                    lblAddress2.Enabled = False
                End If
                txtFinnicialState.Text = Fam.Finncial_Sate
                txtNote.Text = Fam.Note
                txtResidenceState.Text = Fam.Residece_Sate
                txtResidenceType.Text = Fam.Residenc_Type
                picCardphoto1.SetImageByBytes(Fam.FamilyCardPhoto)
                picCardPhoto2.SetImageByBytes(Fam.FamilyCardPhotoP2)
                Try
                    If Not IsNothing(Fam.FamilyCard_Num) Then numCardID.Value = Fam.FamilyCard_Num
                Catch
                    numCardID.Value = 0
                End Try
                Me.Text &= Getter.GetFullName(Fam.Father.Name) & " و " & Getter.GetFullName(Fam.Mother.Name)
                txtResidenceType.Focus()
            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub picPhoto_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCardphoto1.DoubleClick, picCardPhoto2.DoubleClick
        Try
            If Not IsNothing(CType(sender, PictureSelector.PictureSelector).Photo) Then
                Dim picxx As PictureSelector.PictureSelector = CType(sender, PictureSelector.PictureSelector)
                Dim frmShopic As New FrmShowPic(picxx.Photo)
                frmShopic.ShowDialog(Me)
            End If
        Catch

        End Try
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Try
            If My.Settings.checkFamilyCardBeforEdit Then
                Dim ret() As Integer = Checker.checkFamilyCardId(numCardID.Value)
                If Not IsNothing(ret) AndAlso ret.Length > 0 Then
                    Using Odb As New OrphanageDB.Odb
                        Dim famm = Getter.GetFamilyByID(ret(0), Odb)
                        Dim str As String = Getter.GetFullName(famm.Father.Name) & " و " & Getter.GetFullName(famm.Mother.Name)
                        ExceptionsManager.RaiseOnStatus(New MyException("هناك تطابق برقم بطاقة العائلة مع عائلة " & str, True, True))
                        numCardID.Focus()
                        Odb.Dispose()
                    End Using
                    Return
                End If
            End If
            Dim q = From fth In Odb.Families Where fth.ID = _id Select fth
            Dim fam As OrphanageClasses.Family = q.FirstOrDefault()
            If chkIsRefugee.Checked Then
                If AddressForm2.City.Count > 0 AndAlso AddressForm2.Country.Count > 0 Then
                    GetFromAddressForm2(fam.Address1)
                End If
            End If
            GetFromAddressForm1(fam.Address)
            fam.FamilyCard_Num = numCardID.Value
            fam.FamilyCardPhoto = picCardphoto1.PhotoAsBytes
            fam.FamilyCardPhotoP2 = picCardPhoto2.PhotoAsBytes
            fam.Finncial_Sate = txtFinnicialState.Text
            fam.IsRefugee = chkIsRefugee.Checked
            fam.Note = txtNote.Text
            fam.Residece_Sate = txtResidenceState.Text
            fam.Residenc_Type = txtResidenceType.Text
            Odb.SubmitChanges()
            Try
                Updater.UpdatesFamily(fam)
            Catch
            End Try
            ExceptionsManager.RaiseOnDesktopNow(New MyException("تم الحفظ", False, True))
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            ExceptionsManager.RaiseOnDesktopNow(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Public Sub New(ByVal id As Integer)
        InitializeComponent()
        Me._id = id
    End Sub
End Class
