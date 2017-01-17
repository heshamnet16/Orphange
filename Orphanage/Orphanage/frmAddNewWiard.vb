Imports LangChanger
Imports Orphanage.OrphanageClasses
Imports Itenso.TimePeriod
Imports Telerik.WinControls.UI

Public Class FrmAddNewWiard
    Dim Odb As New OrphanageDB.Odb()
    Dim FName As New OrphanageClasses.Name
    Dim MName As New Name()
    Dim MAdd As New Address()
    Dim FADD1 As New Address()
    Dim FADD2 As New Address()
    Dim Fclass As New Father()
    Dim Mclass As New Mother()
    Dim Famclass As New Family()
    Private IsChoosedFAther As Boolean = False
    Private IsChoosedMother As Boolean = False
    Private IsClosing As Boolean = False
    Private Delegate Sub AutoCompleteDelegate()
    Private CallAutoComplete As New AutoCompleteDelegate(AddressOf SetAutoComplete)
    Dim t As New Threading.Thread(AddressOf CallAutoCompleteThread)
    Private Sub CallAutoCompleteThread()
        Me.Invoke(CallAutoComplete)
    End Sub
    Public Sub SetAutoComplete()
        Using InOdb As New OrphanageDB.Odb
            Try
                Dim qEF = From nam In Odb.Names Where nam.EName.Length > 0 Select nam.EName Distinct
                Dim qEL = From nam In Odb.Names Where nam.ELast.Length > 0 Select nam.ELast Distinct
                Dim qEfa = From nam In Odb.Names Where nam.EFather.Length > 0 Select nam.EFather Distinct
                txtFAtherNameEf.AutoCompleteCustomSource.AddRange(qEF.ToArray())
                txtFatherNameEFath.AutoCompleteCustomSource.AddRange(qEF.ToArray())
                txtMotherNameEF.AutoCompleteCustomSource.AddRange(qEF.ToArray())
                txtMotherNAmeEFath.AutoCompleteCustomSource.AddRange(qEF.ToArray())
                'For Each Nm In qEF
                '    If Not IsNothing(Nm) AndAlso Nm.Length > 0 Then
                '        txtFAtherNameEf.AutoCompleteCustomSource.Add(Nm)
                '        txtFatherNameEFath.AutoCompleteCustomSource.Add(Nm)
                '        txtMotherNameEF.AutoCompleteCustomSource.Add(Nm)
                '        txtMotherNAmeEFath.AutoCompleteCustomSource.Add(Nm)
                '        If Nm.Length Mod 5 = 0 Then Application.DoEvents()
                '    End If
                '    If IsClosing Then Exit Sub
                'Next
                Dim xx = qEfa.Where(Function(x) qEF.Contains(x) = False)
                'For Each Nm In qEfa
                '    If Not IsNothing(Nm) AndAlso Nm.Length > 0 AndAlso Not txtMotherNAmeEFath.AutoCompleteCustomSource.Contains(Nm) Then
                '        txtFAtherNameEf.AutoCompleteCustomSource.Add(Nm)
                '        txtFatherNameEFath.AutoCompleteCustomSource.Add(Nm)
                '        txtMotherNameEF.AutoCompleteCustomSource.Add(Nm)
                '        txtMotherNAmeEFath.AutoCompleteCustomSource.Add(Nm)
                '        If Nm.Length Mod 5 = 0 Then Application.DoEvents()
                '    End If
                '    If IsClosing Then Exit Sub
                'Next
                txtFAtherNameEf.AutoCompleteCustomSource.AddRange(xx.ToArray())
                txtFatherNameEFath.AutoCompleteCustomSource.AddRange(xx.ToArray())
                txtMotherNameEF.AutoCompleteCustomSource.AddRange(xx.ToArray())
                txtMotherNAmeEFath.AutoCompleteCustomSource.AddRange(xx.ToArray())
                'For Each Nm In qEL
                '    If Not IsNothing(Nm) AndAlso Nm.Length > 0 Then
                '        txtFAtherNameELast.AutoCompleteCustomSource.Add(Nm)
                '        txtMotherNameELast.AutoCompleteCustomSource.Add(Nm)
                '        If Nm.Length Mod 5 = 0 Then Application.DoEvents()
                '    End If
                '    If IsClosing Then Exit Sub
                'Next
                txtFAtherNameELast.AutoCompleteCustomSource.AddRange(qEL.ToArray())
                txtMotherNameELast.AutoCompleteCustomSource.AddRange(qEL.ToArray())
                Dim qACountry = From add In InOdb.Addresses Where add.Country.Length > 0 Select add.Country Distinct
                Dim qACity = From add In InOdb.Addresses Where add.City.Length > 0 Select add.City Distinct
                Dim qATown = From add In InOdb.Addresses Where add.Town.Length > 0 Select add.Town Distinct
                Dim qAStreet = From add In InOdb.Addresses Where add.Street.Length > 0 Select add.Street Distinct
                txtFamilyAdd1City.AutoCompleteCustomSource.AddRange(qACity.ToArray())
                txtFamilyADD2City.AutoCompleteCustomSource.AddRange(qACity.ToArray())
                txtMotherAddCity.AutoCompleteCustomSource.AddRange(qACity.ToArray())
                txtFamilyAdd1Country.AutoCompleteCustomSource.AddRange(qACountry.ToArray())
                txtFamilyADD2Country.AutoCompleteCustomSource.AddRange(qACountry.ToArray())
                txtFamilyAdd1Town.AutoCompleteCustomSource.AddRange(qATown.ToArray())
                txtFamilyAdd2Town.AutoCompleteCustomSource.AddRange(qATown.ToArray())
                txtMotherAddTown.AutoCompleteCustomSource.AddRange(qATown.ToArray())
                txtFamilyAdd1Street.AutoCompleteCustomSource.AddRange(qAStreet.ToArray())
                txtFamilyADD2Street.AutoCompleteCustomSource.AddRange(qAStreet.ToArray())
                txtMotherAddStreet.AutoCompleteCustomSource.AddRange(qAStreet.ToArray())
                'For Each Adre In qA
                '    If Not IsNothing(Adre.city) AndAlso Adre.city.Length > 0 AndAlso Not txtFamilyAdd1City.AutoCompleteCustomSource.Contains(Adre.city) Then
                '        txtFamilyAdd1City.AutoCompleteCustomSource.Add(Adre.city)
                '        txtFamilyADD2City.AutoCompleteCustomSource.Add(Adre.city)
                '        txtMotherAddCity.AutoCompleteCustomSource.Add(Adre.city)
                '    End If
                '    If Not IsNothing(Adre.country) AndAlso Adre.country.Length > 0 AndAlso Not txtFamilyAdd1City.AutoCompleteCustomSource.Contains(Adre.country) Then
                '        txtFamilyAdd1Country.AutoCompleteCustomSource.Add(Adre.country)
                '        txtFamilyADD2Country.AutoCompleteCustomSource.Add(Adre.country)
                '    End If
                '    If Not IsNothing(Adre.town) AndAlso Adre.town.Length > 0 AndAlso Not txtFamilyAdd1City.AutoCompleteCustomSource.Contains(Adre.town) Then
                '        txtFamilyAdd1Town.AutoCompleteCustomSource.Add(Adre.town)
                '        txtFamilyAdd2Town.AutoCompleteCustomSource.Add(Adre.town)
                '        txtMotherAddTown.AutoCompleteCustomSource.Add(Adre.town)
                '    End If
                '    If Not IsNothing(Adre.street) AndAlso Adre.street.Length > 0 AndAlso Not txtFamilyAdd1City.AutoCompleteCustomSource.Contains(Adre.street) Then
                '        txtFamilyAdd1Street.AutoCompleteCustomSource.Add(Adre.street)
                '        txtFamilyADD2Street.AutoCompleteCustomSource.Add(Adre.street)
                '        txtMotherAddStreet.AutoCompleteCustomSource.Add(Adre.street)
                '        If Adre.street.Length Mod 4 = 0 Then
                '            Try
                '                Application.DoEvents()
                '            Catch
                '            End Try
                '        End If
                '    End If
                '    If IsClosing Then Exit Sub
                'Next
                Dim qJ = From j In InOdb.Fathers Where j.Jop.Length > 0 Select j.Jop Distinct
                'For Each jp In qJ
                '    If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not txtFAtherJop.AutoCompleteCustomSource.Contains(jp) Then
                '        txtFAtherJop.AutoCompleteCustomSource.Add(jp)
                '    End If
                '    If IsClosing Then Exit Sub
                'Next
                txtFAtherJop.AutoCompleteCustomSource.AddRange(qJ.ToArray())
                Dim qDr = From j In InOdb.Fathers Select j.DeathResone Distinct
                'For Each dr In qDr
                '    If Not IsNothing(dr) AndAlso dr.Length > 0 Then
                '        txtFatherDeathREason.AutoCompleteCustomSource.Add(dr)
                '    End If
                '    If IsClosing Then Exit Sub
                'Next
                txtFatherDeathREason.AutoCompleteCustomSource.AddRange(qDr.ToArray())
                Dim qJM = From j In InOdb.Mothers Where j.Jop.Length > 0 Select j.Jop Distinct
                'For Each jp In qJM
                '    If Not IsNothing(jp) AndAlso jp.Length > 0 Then
                '        txtMotherJop.AutoCompleteCustomSource.Add(jp)
                '    End If
                '    If IsClosing Then Exit Sub
                'Next
                txtMotherJop.AutoCompleteCustomSource.AddRange(qJM.ToArray())
            Catch
                InOdb.Dispose()
            End Try
            InOdb.Dispose()
        End Using
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.RadWizard1.HelpButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        Me.RadWizard1.CancelButton.Text = "الغاء الأمر"
        Me.RadWizard1.NextButton.Text = "التالي"
        Me.RadWizard1.BackButton.Text = "السابق"
        Me.RadWizard1.FinishButton.Text = "إنهاء"
    End Sub

    Private Sub txtMotherIsAlive_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkMotherIsDead.ToggleStateChanged
        dteMotherDieday.Enabled = chkMotherIsDead.Checked
    End Sub

    Private Sub chkMotherIsMarried_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkMotherIsMarried.ToggleStateChanged
        txtMotherHusbandName.Enabled = chkMotherIsMarried.Checked
    End Sub

    Private Sub CancelBuutonClick(ByVal sender As Object, ByVal e As EventArgs) Handles RadWizard1.Cancel
        Me.Close()
    End Sub
    Private Sub txtMotherFName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMotherStory.Enter, txtMotherNotes.Enter, txtMotherLName.Enter, txtMotherJop.Enter, txtMotherHusbandName.Enter, txtMotherFName.Enter, txtMotherFatherName.Enter, txtFAtherNameLast.Enter, txtFatherNameFAther.Enter, txtFatherNameF.Enter, txtFAtherJop.Enter, txtFatherDeathREason.Enter, txtMotherAddTown.Enter, txtMotherAddStreet.Enter, txtMotherAddCity.Enter, txtFAtherStory.Enter
        CurLang.SaveCurrentLanguage()
        CurLang.ChangeToArabic()
    End Sub

    Private Sub txtMotherNameEF_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMotherNameELast.Enter, txtMotherNAmeEFath.Enter, txtMotherNameEF.Enter, txtMotherAddEmail.Enter, txtFAtherNameELast.Enter, txtFatherNameEFath.Enter, txtFAtherNameEf.Enter, txtFamilyAdd2Skype.Enter, txtFamilyAdd2Facebook.Enter, txtFamilyADD2Email.Enter
        CurLang.SaveCurrentLanguage()
        CurLang.ChangeToEnglish()
    End Sub

    Private Sub txtMotherNameEF_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMotherNameELast.Leave, txtMotherNAmeEFath.Leave, txtMotherNameEF.Leave, txtMotherAddEmail.Leave, txtFAtherNameELast.Leave, txtFatherNameEFath.Leave, txtFAtherNameEf.Leave, txtFamilyAdd2Skype.Leave, txtFamilyAdd2Facebook.Leave, txtFamilyADD2Email.Leave
        CurLang.ReturnToSavedLanguage()
    End Sub

    Private Sub txtMotherFName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMotherStory.Leave, txtMotherNotes.Leave, txtMotherLName.Leave, txtMotherJop.Leave, txtMotherHusbandName.Leave, txtMotherFName.Leave, txtMotherFatherName.Leave, txtFAtherNameLast.Leave, txtFatherNameFAther.Leave, txtFatherNameF.Leave, txtFAtherJop.Leave, txtFatherDeathREason.Leave, txtMotherAddTown.Leave, txtMotherAddStreet.Leave, txtMotherAddCity.Leave, txtFAtherStory.Leave
        CurLang.ReturnToSavedLanguage()
    End Sub

    Private Sub FrmAddNewWiard_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If t.IsAlive Then
            t.Abort()
        End If
        IsClosing = True
    End Sub

    Private Sub FrmAddNewWiard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtFamilyFinnicialState.Text = txtFamilyFinnicialState.Items(0).Text
        txtFamilyResidenceState.Text = txtFamilyResidenceState.Items(0).Text
        txtFamilyResidenceType.Text = txtFamilyResidenceType.Items(0).Text
        dteMotherBirthday.Value = New Date(1996, 1, 1, 12, 0, 0, 212)
        dteMotherDieday.Value = Date.Now
        dteFatherBirthday.Value = New Date(1994, 1, 1, 12, 0, 0, 212)
        dteFAtherDieday.Value = Date.Now
        t.IsBackground = True
        t.Priority = Threading.ThreadPriority.Lowest
        t.Start()
    End Sub

    Private Function checkFatherControls() As Boolean
        If My.Settings.CheckIdentitysBeforAdd Then
            Return Checker.checkFatherControls(dteFatherBirthday, dteFAtherDieday, numFAtherIdntintyNum, txtFatherNameF, txtFAtherNameLast)
        Else
            Return Checker.checkFatherControls(dteFatherBirthday, dteFAtherDieday, Nothing, txtFatherNameF, txtFAtherNameLast)
        End If
    End Function
    Private Function checkMotherControls() As Boolean
        If My.Settings.CheckIdentitysBeforAdd Then
            Return Checker.checkMotherControls(dteMotherBirthday, chkMotherIsDead, dteMotherDieday, numMotherIdNum, txtMotherFName, txtMotherLName)
        Else

            Return Checker.checkMotherControls(dteMotherBirthday, chkMotherIsDead, dteMotherDieday, Nothing, txtMotherFName, txtMotherLName)
        End If
    End Function
    Private Function FamilySaver() As Boolean
        Try
            Using tr = New Transactions.TransactionScope()
                Odb.Dispose()
                Odb = New OrphanageDB.Odb()
                lstStatus.Items.Add("إدخال بينات عنوان العائلة")
                Application.DoEvents()
                FADD1 = New Address() With {.Cell_Phone = txtFamilyAdd1CellNumb.Text,
                                            .City = txtFamilyAdd1City.Text,
                                            .Country = txtFamilyAdd1Country.Text,
                                            .Email = txtFamilyAdd1Email.Text,
                                            .Facebook = txtFamilyAdd1Facebook.Text,
                                            .Home_Phone = txtFamilyAdd1HomePho.Text,
                                            .Note = txtFamilyAdd1Note.Text,
                                            .Street = txtFamilyAdd1Street.Text,
                                            .Town = txtFamilyAdd1Town.Text,
                                            .Twitter = txtFamilyAdd1Skype.Text,
                                            .Work_Phone = txtFamilyAdd1WorkPhon.Text,
                                            .Fax = txtFamilyAdd1Fax.Text}
                Odb.Addresses.InsertOnSubmit(FADD1)
                Odb.SubmitChanges()
                lstStatus.Items.Add("تم")
                Application.DoEvents()
                If chkFamilyIsRefugee.Checked Then
                    lstStatus.Items.Add("إدخال العنوان الحالي للعائلة")
                    Application.DoEvents()
                    FADD2 = New Address() With {.Cell_Phone = txtFamilyADD2Cell_Phone.Text,
                                                .City = txtFamilyADD2City.Text,
                                                .Country = txtFamilyADD2Country.Text,
                                                .Email = txtFamilyADD2Email.Text,
                                                .Facebook = txtFamilyAdd2Facebook.Text,
                                                .Home_Phone = txtFamilyADD2HomeNum.Text,
                                                .Note = txtFamilyAdd2Note.Text,
                                                .Street = txtFamilyADD2Street.Text,
                                                .Town = txtFamilyAdd2Town.Text,
                                                .Twitter = txtFamilyAdd2Skype.Text,
                                                .Work_Phone = txtFamilyADD2WorkNumb.Text,
                                                .Fax = txtFamilyADD2Fax.Text}
                    Odb.Addresses.InsertOnSubmit(FADD2)
                    Odb.SubmitChanges()
                    lstStatus.Items.Add("تم")
                    Application.DoEvents()
                End If
                lstStatus.Items.Add("إدخال بينات العائلة")
                Application.DoEvents()
                Famclass = New Family With {.Residece_Sate = txtFamilyResidenceState.Text,
                                            .Residenc_Type = txtFamilyResidenceType.Text,
                                            .Note = txtFamilyNote.Text,
                                            .FamilyCard_Num = numFamilyCardID.Value.ToString,
                                            .IsRefugee = chkFamilyIsRefugee.Checked,
                                            .IsExcluded = False,
                                            .Finncial_Sate = txtFamilyFinnicialState.Text,
                                            .RegDate = Date.Now,
                                            .Address_ID = FADD1.ID,
                                            .FamilyCardPhoto = picFamilyCardphoto1.PhotoAsBytes,
                                            .FamilyCardPhotoP2 = picFamilyCardPhoto2.PhotoAsBytes,
                                            .User_ID = frmLogin.CurrentUser.ID}

                If chkFamilyIsRefugee.Checked Then
                    Famclass.Address_ID2 = FADD2.ID
                End If
                If Me.IsChoosedFAther AndAlso Not Me.IsChoosedMother Then
                    lstStatus.Items.Add("إدخال بينات الأم")
                    MAdd = New Address()
                    MName = New Name()
                    Mclass = New Mother()
                    Application.DoEvents()
                    Famclass.Father_ID = Fclass.ID
                    lstStatus.Items.Add(Space(8) & "إدخال العنوان")
                    Application.DoEvents()
                    MAdd.Cell_Phone = txtMotherAddCell.Text
                    MAdd.City = txtMotherAddCity.Text
                    MAdd.Email = txtMotherAddEmail.Text
                    MAdd.Work_Phone = txtMotherAddPhone.Text
                    MAdd.Street = txtMotherAddStreet.Text
                    MAdd.Town = txtMotherAddTown.Text
                    Odb.Addresses.InsertOnSubmit(MAdd)
                    Odb.SubmitChanges()
                    lstStatus.Items.Add(Space(8) & "تم")
                    Application.DoEvents()
                    Mclass.Address_ID = MAdd.ID
                    lstStatus.Items.Add(Space(8) & "إدخال الاسم")
                    Application.DoEvents()
                    MName.Father = txtMotherFatherName.Text
                    MName.First = txtMotherFName.Text
                    If chkMotherIsMarried.Checked Then
                        Mclass.Husband_Name = txtMotherHusbandName.Text
                    End If
                    Mclass.Jop = txtMotherJop.Text
                    MName.Last = txtMotherLName.Text
                    MName.EName = txtMotherNameEF.Text
                    MName.EFather = txtMotherNAmeEFath.Text
                    MName.ELast = txtMotherNameELast.Text
                    Odb.Names.InsertOnSubmit(MName)
                    Odb.SubmitChanges()
                    lstStatus.Items.Add(Space(8) & "تم")
                    Application.DoEvents()
                    Mclass.Name_ID = MName.ID
                    lstStatus.Items.Add(Space(8) & "حفظ البيانات...")
                    Application.DoEvents()
                    Mclass.Note = txtMotherNotes.Text
                    Mclass.Story = txtMotherStory.Text
                    Mclass.IdentityCard_Photo2 = picMotherIDBack.PhotoAsBytes
                    Mclass.IdentityCard_Photo = picMotherIDFace.PhotoAsBytes
                    Mclass.IdntityCard_ID = CULng(numMotherIdNum.Value)
                    Mclass.Salary = numMotherIncom.Value
                    Mclass.IsDead = chkMotherIsDead.Checked
                    Mclass.IsMarried = chkMotherIsMarried.Checked
                    Mclass.IsOwnOrphans = chkMotherIsOwnOrphan.Checked
                    Mclass.Birthday = dteMotherBirthday.Value
                    If chkMotherIsDead.Checked = True Then
                        Mclass.Dieday = dteMotherDieday.Value
                    Else
                        Mclass.Dieday = Nothing
                    End If
                    Mclass.RegDate = Date.Now
                    Mclass.User_Id = frmLogin.CurrentUser.ID
                    Odb.Mothers.InsertOnSubmit(Mclass)
                    Odb.SubmitChanges()
                    lstStatus.Items.Add("تم")
                    Application.DoEvents()
                    Famclass.Mother_ID = Mclass.ID
                ElseIf Not Me.IsChoosedFAther AndAlso Me.IsChoosedMother Then
                    lstStatus.Items.Add("إدخال بينات الأب")
                    FName = New Name()
                    Fclass = New Father()
                    Application.DoEvents()
                    Famclass.Mother_ID = Mclass.ID
                    lstStatus.Items.Add(Space(8) & "إدخال الاسم")
                    Application.DoEvents()
                    FName.First = txtFatherNameF.Text
                    FName.Last = txtFAtherNameLast.Text
                    FName.Father = txtFatherNameFAther.Text
                    FName.EFather = txtFatherNameEFath.Text
                    FName.ELast = txtFAtherNameELast.Text
                    FName.EName = txtFAtherNameEf.Text
                    Fclass.Birthday = dteFatherBirthday.Value
                    Fclass.DeathCertificate_Photo = picFAtherDeathCertifi.PhotoAsBytes
                    Fclass.DeathResone = txtFatherDeathREason.Text
                    Fclass.Dieday = dteFAtherDieday.Value
                    Fclass.IdentityCard_ID = CULng(numFAtherIdntintyNum.Value)
                    Fclass.Jop = txtFAtherJop.Text
                    Fclass.Photo = picFatherPhoto.PhotoAsBytes
                    Fclass.RegDate = Date.Now
                    Fclass.Story = txtFAtherStory.Text
                    Fclass.User_ID = frmLogin.CurrentUser.ID
                    lstStatus.Items.Add(Space(8) & "حفظ البيانات...")
                    Application.DoEvents()
                    Odb.Names.InsertOnSubmit(FName)
                    Odb.SubmitChanges()
                    lstStatus.Items.Add(Space(8) & "تم")
                    Application.DoEvents()
                    Fclass.Name_ID = FName.ID
                    Fclass.User_ID = frmLogin.CurrentUser.ID
                    Odb.Fathers.InsertOnSubmit(Fclass)
                    Odb.SubmitChanges()
                    lstStatus.Items.Add("تم")
                    Application.DoEvents()
                    Famclass.Father_ID = Fclass.ID
                Else
                    MAdd = New Address()
                    Mclass = New Mother()
                    Fclass = New Father()
                    MName = New Name()
                    FName = New Name()
                    lstStatus.Items.Add("إدخال بينات الأم")
                    lstStatus.Items.Add(Space(8) & "إدخال العنوان")
                    Application.DoEvents()
                    MAdd.Cell_Phone = txtMotherAddCell.Text
                    MAdd.City = txtMotherAddCity.Text
                    MAdd.Email = txtMotherAddEmail.Text
                    MAdd.Work_Phone = txtMotherAddPhone.Text
                    MAdd.Street = txtMotherAddStreet.Text
                    MAdd.Town = txtMotherAddTown.Text
                    Odb.Addresses.InsertOnSubmit(MAdd)
                    Odb.SubmitChanges()
                    lstStatus.Items.Add(Space(8) & "تم")
                    Application.DoEvents()
                    Mclass.Address_ID = MAdd.ID
                    lstStatus.Items.Add(Space(8) & "إدخال الاسم")
                    Application.DoEvents()
                    MName.Father = txtMotherFatherName.Text
                    MName.First = txtMotherFName.Text
                    Mclass.Husband_Name = txtMotherHusbandName.Text
                    Mclass.Jop = txtMotherJop.Text
                    MName.Last = txtMotherLName.Text
                    MName.EName = txtMotherNameEF.Text
                    MName.EFather = txtMotherNAmeEFath.Text
                    MName.ELast = txtMotherNameELast.Text
                    Odb.Names.InsertOnSubmit(MName)
                    Odb.SubmitChanges()
                    lstStatus.Items.Add(Space(8) & "تم")
                    Application.DoEvents()
                    Mclass.Name_ID = MName.ID
                    lstStatus.Items.Add(Space(8) & "حفظ البيانات...")
                    Application.DoEvents()
                    Mclass.Note = txtMotherNotes.Text
                    Mclass.Story = txtMotherStory.Text
                    Mclass.IdentityCard_Photo2 = picMotherIDBack.PhotoAsBytes
                    Mclass.IdentityCard_Photo = picMotherIDFace.PhotoAsBytes
                    Mclass.IdntityCard_ID = CULng(numMotherIdNum.Value)
                    Mclass.Salary = numMotherIncom.Value
                    Mclass.IsDead = chkMotherIsDead.Checked
                    Mclass.IsMarried = chkMotherIsMarried.Checked
                    Mclass.IsOwnOrphans = chkMotherIsOwnOrphan.Checked
                    Mclass.Birthday = dteMotherBirthday.Value
                    If chkMotherIsDead.Checked = True Then
                        Mclass.Dieday = dteMotherDieday.Value
                    Else
                        Mclass.Dieday = Nothing
                    End If
                    Mclass.RegDate = Date.Now
                    Mclass.User_Id = frmLogin.CurrentUser.ID
                    Odb.Mothers.InsertOnSubmit(Mclass)
                    Odb.SubmitChanges()
                    lstStatus.Items.Add("تم")
                    lstStatus.Items.Add("إدخال بينات الأب")
                    lstStatus.Items.Add(Space(8) & "إدخال الاسم")
                    Application.DoEvents()
                    FName.First = txtFatherNameF.Text
                    FName.Last = txtFAtherNameLast.Text
                    FName.Father = txtFatherNameFAther.Text
                    FName.EFather = txtFAtherNameEf.Text
                    FName.ELast = txtFAtherNameELast.Text
                    FName.EName = txtFAtherNameEf.Text
                    Fclass.Birthday = dteFatherBirthday.Value
                    Fclass.DeathCertificate_Photo = picFAtherDeathCertifi.PhotoAsBytes
                    Fclass.DeathResone = txtFatherDeathREason.Text
                    Fclass.Dieday = dteFAtherDieday.Value
                    Fclass.IdentityCard_ID = CULng(numFAtherIdntintyNum.Value)
                    Fclass.Jop = txtFAtherJop.Text
                    Fclass.Photo = picFatherPhoto.PhotoAsBytes
                    Fclass.RegDate = Date.Now
                    Fclass.Story = txtFAtherStory.Text
                    Fclass.User_ID = frmLogin.CurrentUser.ID
                    Odb.Names.InsertOnSubmit(FName)
                    Odb.SubmitChanges()
                    lstStatus.Items.Add(Space(8) & "تم")
                    lstStatus.Items.Add(Space(8) & "حفظ البيانات...")
                    Application.DoEvents()
                    Fclass.Name_ID = FName.ID
                    Fclass.User_ID = frmLogin.CurrentUser.ID
                    Odb.Fathers.InsertOnSubmit(Fclass)
                    Odb.SubmitChanges()
                    lstStatus.Items.Add("تم")
                    Famclass.Father_ID = Fclass.ID
                    Application.DoEvents()
                    Famclass.Mother_ID = Mclass.ID
                End If
                lstStatus.Items.Add(Space(8) & "حفظ البيانات...")
                Application.DoEvents()
                Odb.Families.InsertOnSubmit(Famclass)
                Odb.SubmitChanges()
                lstStatus.Items.Add("تم")
                lstStatus.Items.Add("تمت العملية بنجاح")
                Application.DoEvents()
                ExceptionsManager.RaiseOnStatus(New MyException("تم الحفظ!", False, True))
                tr.Complete()
                Return True
            End Using
        Catch exx As Exception
            MsgBox(exx.Message, MsgBoxStyle.Critical)
            lstStatus.Items.Add(exx.Message)
            Return False
        End Try
    End Function

    Private Sub RadWizard1_SelectedPageChanged(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.SelectedPageChangedEventArgs) Handles RadWizard1.SelectedPageChanged
        If e.SelectedPage Is WPprogress Then
            progressBar1.StartWaiting()
            If FamilySaver() Then
                RadWizard1.SelectNextPage()
                RadWizard1.BackButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
                RadWizard1.CancelButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
                lblFinishMessage.Text = "انتهت العملية بنجاح وتم تسجيل عائلة" & Chr(13) & Famclass.Father.Name.First & " " & Famclass.Father.Name.Last & " و " & Famclass.Mother.Name.First & " " & Famclass.Mother.Name.Last
            End If
            progressBar1.StopWaiting()
        End If
    End Sub
    Private Sub RadWizard1_SelectedPageChanging(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.SelectedPageChangingEventArgs) Handles RadWizard1.SelectedPageChanging
        If (e.NextPage Is WPFamily) OrElse e.NextPage Is WPFamily2 OrElse e.NextPage Is WPprogress OrElse e.NextPage Is WizardCompletionPage1 Then
            btnFatherBrowse.Visible = False
            btnFAtherNew.Visible = False
        Else
            btnFatherBrowse.Visible = True
            btnFAtherNew.Visible = True
        End If
        If (e.NextPage Is WPMother) AndAlso IsChoosedFAther Then
            btnFatherBrowse.Enabled = False
        Else
            btnFatherBrowse.Enabled = True
        End If
        If (e.NextPage Is WPFather) AndAlso IsChoosedMother Then
            btnFatherBrowse.Enabled = False
        Else
            btnFatherBrowse.Enabled = True
        End If
        '''''''''''''''''''''''''''''''''''''''
        If e.SelectedPage Is WPFather Then ' Father Page      
            If Not Me.IsChoosedFAther Then
                If Not checkFatherControls() Then
                    e.Cancel = True
                    Return
                End If
            End If
        ElseIf e.SelectedPage Is WPMother Then 'Mother Page
            If Not Me.IsChoosedMother Then
                If Not checkMotherControls() Then
                    e.Cancel = True
                    Return
                End If
            End If
        ElseIf e.SelectedPage Is WPFamily Then 'FAmily Page

        ElseIf e.SelectedPage Is WPFamily2 Then
            If My.Settings.CheckFamilyCardBeforAdd Then
                If numFamilyCardID.Value > 0 Then
                    Dim ret() As Integer = Checker.checkFamilyCardId(CULng(numFamilyCardID.Value))
                    If Not IsNothing(ret) AndAlso ret.Length > 0 Then
                        Dim famm = Getter.GetFamilyByID(ret(0), Odb)
                        Dim str As String = Getter.GetFullName(famm.Father.Name) & " و " & Getter.GetFullName(famm.Mother.Name)
                        ExceptionsManager.RaiseOnStatus(New MyException("هناك تطابق برقم بطاقة العائلة مع عائلة " & str, True, True))
                        e.Cancel = True
                        numFamilyCardID.Focus()
                        Return
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnFAtherNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFAtherNew.Click
        If WPFather.IsSelected Then
            IsChoosedFAther = False
            pnlFAther.Enabled = True
            ClearControls(pnlFAther.Controls)
            Fclass = New Father()
            FName = New Name()
        ElseIf WPMother.IsSelected Then
            IsChoosedMother = False
            pnlMother.Enabled = True
            ClearControls(pnlMother.Controls)
            Mclass = New Mother()
            MName = New Name()
            MAdd = New Address()
        End If
    End Sub

    Private Sub ClearControls(ByVal conts As System.Windows.Forms.Control.ControlCollection)
        For Each ctl As Control In conts
            If TypeOf ctl Is RadTextBox Then
                CType(ctl, RadTextBox).Text = ""
            ElseIf TypeOf ctl Is RadCheckBox Then
                CType(ctl, RadCheckBox).Checked = False
            ElseIf TypeOf ctl Is RadDateTimePicker Then
                CType(ctl, RadDateTimePicker).Value = Date.Now
            ElseIf TypeOf ctl Is PictureSelector.PictureSelector Then
                CType(ctl, PictureSelector.PictureSelector).SetImageByBytes(Nothing)
                CType(ctl, PictureSelector.PictureSelector).BackgroundImage = Nothing
            ElseIf TypeOf ctl Is RadSpinEditor Then
                CType(ctl, RadSpinEditor).Value = 0
            Else
                If ctl.HasChildren Then
                    ClearControls(ctl.Controls)
                End If
            End If
        Next
    End Sub
    Private Sub btnFatherBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFatherBrowse.Click
        If WPFather.IsSelected And Not IsChoosedMother Then
            Dim frm As New FrmFatherChooser(False)
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                IsChoosedFAther = True
                pnlFAther.Enabled = False
                Fclass = Getter.GetFatherByID(frm.SelectedFather, Odb)
                FName = Fclass.Name
                txtFatherDeathREason.Text = Fclass.DeathResone
                txtFAtherJop.Text = Fclass.Jop
                txtFAtherNameEf.Text = Fclass.Name.EName
                txtFatherNameEFath.Text = Fclass.Name.EFather
                txtFAtherNameELast.Text = Fclass.Name.ELast
                txtFatherNameF.Text = Fclass.Name.First
                txtFatherNameFAther.Text = Fclass.Name.Father
                txtFAtherNameLast.Text = Fclass.Name.Last
                txtFAtherStory.Text = Fclass.Story
                picFatherPhoto.SetImageByBytes(Fclass.Photo)
                picFAtherDeathCertifi.SetImageByBytes(Fclass.Photo)
                dteFatherBirthday.Value = Fclass.Birthday
                dteFAtherDieday.Value = Fclass.Dieday
                numFAtherIdntintyNum.Value = Fclass.IdentityCard_ID
            End If
            frm.Dispose()
        ElseIf WPMother.IsSelected And Not IsChoosedFAther Then
            Dim frm As New FrmMotherChooser(False)
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                IsChoosedMother = True
                Mclass = Getter.GetMotherByID(frm.SelectedMother, Odb)
                MName = Mclass.Name
                MAdd = Mclass.Address
                txtMotherAddCell.Text = MAdd.Cell_Phone
                txtMotherAddCity.Text = MAdd.City
                txtMotherAddEmail.Text = MAdd.Email
                txtMotherAddPhone.Text = MAdd.Work_Phone
                txtMotherAddStreet.Text = MAdd.Street
                txtMotherAddTown.Text = MAdd.Town
                txtMotherFatherName.Text = MName.Father
                txtMotherFName.Text = MName.First
                txtMotherHusbandName.Text = Mclass.Husband_Name
                txtMotherJop.Text = Mclass.Jop
                txtMotherLName.Text = MName.Last
                txtMotherNameEF.Text = MName.EName
                txtMotherNAmeEFath.Text = MName.EFather
                txtMotherNameELast.Text = MName.ELast
                txtMotherNotes.Text = Mclass.Note
                txtMotherStory.Text = Mclass.Story
                picMotherIDBack.SetImageByBytes(Mclass.IdentityCard_Photo2)
                picMotherIDFace.SetImageByBytes(Mclass.IdentityCard_Photo)
                If Mclass.IdntityCard_ID.HasValue Then
                    numMotherIdNum.Value = Mclass.IdntityCard_ID.Value
                End If
                If Mclass.Salary.HasValue Then
                    numMotherIncom.Value = Mclass.Salary.Value
                End If
                chkMotherIsDead.Checked = Mclass.IsDead
                chkMotherIsMarried.Checked = Mclass.IsMarried
                chkMotherIsOwnOrphan.Checked = Mclass.IsOwnOrphans
                dteMotherBirthday.Value = Mclass.Birthday
                If Not IsNothing(Mclass.Dieday) AndAlso Mclass.Dieday.HasValue Then
                    dteMotherDieday.Value = Mclass.Dieday.Value
                End If
            End If
            frm.Dispose()
            End If
    End Sub

    Private Sub chkFamilyIsRefugee_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkFamilyIsRefugee.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            groupAdd2.Enabled = True
        Else
            groupAdd2.Enabled = False
        End If
    End Sub

    Private Sub txtFamilyADD2Country_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFamilyNote.Enter, txtFamilyAdd1Town.Enter, txtFamilyAdd1Street.Enter, txtFamilyAdd1Country.Enter, txtFamilyAdd1City.Enter, txtFamilyAdd1Note.Enter, txtFamilyAdd2Town.Enter, txtFamilyADD2Street.Enter, txtFamilyAdd2Note.Enter, txtFamilyADD2Country.Enter, txtFamilyADD2City.Enter
        CurLang.SaveCurrentLanguage()
        CurLang.ChangeToArabic()
    End Sub

    Private Sub txtFamilyADD2Country_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFamilyAdd1Town.Leave, txtFamilyAdd1Street.Leave, txtFamilyAdd1Country.Leave, txtFamilyAdd1City.Leave, txtFamilyAdd1Note.Leave, txtFamilyNote.Leave, txtFamilyAdd2Town.Leave, txtFamilyADD2Street.Leave, txtFamilyAdd2Note.Leave, txtFamilyADD2Country.Leave, txtFamilyADD2City.Leave
        CurLang.ReturnToSavedLanguage()
    End Sub

    Private Sub txtFamilyAdd1Country_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CurLang.ReturnToSavedLanguage()
    End Sub

    Private Sub RadWizard1_Finish(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadWizard1.Finish
        Me.Close()
    End Sub
End Class
