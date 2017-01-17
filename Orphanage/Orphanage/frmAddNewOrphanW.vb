Imports Orphanage.OrphanageClasses
Imports Itenso.TimePeriod
Imports Telerik.WinControls.UI
Public Class FrmAddNewOrphanW
    Private OrphanFamily As Family = Nothing
    Private OHealthy As Healthy = Nothing
    Private OStudy As Study = Nothing
    Private BoName As Name = Nothing
    Private BoAdd As Address = Nothing
    Private Bo As BondsMan = Nothing
    Private OName As Name = Nothing
    Private Orph As Orphan = Nothing
    Private IsBoMother As Boolean = False
    Private IsBoExist As Boolean = False
    Private IsClosing As Boolean = False
    Dim Odb As New OrphanageDB.Odb()
    Dim SavedAutoComplete() As String
    Private Delegate Sub AutoCompleteDelegate()
    Private CallAutoComplete As New AutoCompleteDelegate(AddressOf SetAutoComplete)
    Dim t As New Threading.Thread(AddressOf CallAutoCompleteThread)
    Dim AddedNew As New ArrayList()
    Private Sub CallAutoCompleteThread()
        Me.Invoke(CallAutoComplete)
    End Sub
    Public Sub SetAutoComplete()
        Try
            Dim qEF = From nam In Odb.Names Where nam.EName.Length > 0 Select nam.EName Distinct
            Dim qEL = From nam In Odb.Names Where nam.ELast.Length > 0 Select nam.ELast Distinct
            Dim qEfa = From nam In Odb.Names Where nam.EFather.Length > 0 Select nam.EFather Distinct

            Dim xx = qEfa.Where(Function(x) Not qEF.Contains(x))
            'For Each Nm In qEF
            '    If Not IsNothing(Nm) AndAlso Nm.Length > 0 Then
            '        txtBoNameEfirst.AutoCompleteCustomSource.Add(Nm)
            '        txtONameEf.AutoCompleteCustomSource.Add(Nm)
            '        If Nm.Length Mod 4 Then Application.DoEvents()
            '    End If
            '    If IsClosing Then Exit Sub
            'Next
            txtBoNameEfirst.AutoCompleteCustomSource.AddRange(qEF.ToArray())
            txtONameEf.AutoCompleteCustomSource.AddRange(qEF.ToArray())
            txtBoNameEfirst.AutoCompleteCustomSource.AddRange(xx.ToArray())
            txtONameEf.AutoCompleteCustomSource.AddRange(xx.ToArray())
            'For Each Nm In qEfa
            '    If Not IsNothing(Nm) AndAlso Nm.Length > 0 Then
            '        txtBoNameEFather.AutoCompleteCustomSource.Add(Nm)
            '        txtONameEFath.AutoCompleteCustomSource.Add(Nm)
            '        If Nm.Length Mod 4 Then Application.DoEvents()
            '    End If
            '    If IsClosing Then Exit Sub
            'Next
            txtBoNameEFather.AutoCompleteCustomSource.AddRange(qEF.ToArray())
            txtONameEFath.AutoCompleteCustomSource.AddRange(qEF.ToArray())
            txtBoNameEFather.AutoCompleteCustomSource.AddRange(xx.ToArray())
            txtONameEFath.AutoCompleteCustomSource.AddRange(xx.ToArray())
            'For Each Nm In qEL
            '    If Not IsNothing(Nm) AndAlso Nm.Length > 0 Then
            '        txtBoNameELast.AutoCompleteCustomSource.Add(Nm)
            '        txtONameELast.AutoCompleteCustomSource.Add(Nm)
            '        If Nm.Length Mod 4 Then Application.DoEvents()
            '    End If
            '    If IsClosing Then Exit Sub
            'Next
            txtBoNameELast.AutoCompleteCustomSource.AddRange(qEL.ToArray())
            txtONameELast.AutoCompleteCustomSource.AddRange(qEL.ToArray())
            Dim qJ = From j In Odb.BondsMans Where j.Jop.Length > 0 Select j.Jop Distinct
            'For Each jp In qJ
            '    If Not IsNothing(jp) AndAlso jp.Length > 0 Then
            '        txtBoJop.AutoCompleteCustomSource.Add(jp)
            '    End If
            '    If IsClosing Then Exit Sub
            'Next
            txtBoJop.AutoCompleteCustomSource.AddRange(qJ.ToArray())
            Dim qACou = From j In Odb.Addresses Where j.Country.Length > 0 Select j.Country Distinct
            'For Each jp In qACou
            '    If Not IsNothing(jp) AndAlso jp.Length > 0 Then
            '        txtBOADDCountry.AutoCompleteCustomSource.Add(jp)
            '    End If
            '    If IsClosing Then Exit Sub
            'Next
            txtBOADDCountry.AutoCompleteCustomSource.AddRange(qACou.ToArray())
            Dim qAcit = From j In Odb.Addresses Where j.City.Length > 0 Select j.City Distinct
            'For Each jp In qAcit
            '    If Not IsNothing(jp) AndAlso jp.Length > 0 Then
            '        txtBOADDCity.AutoCompleteCustomSource.Add(jp)
            '    End If
            '    If IsClosing Then Exit Sub
            'Next
            txtBOADDCity.AutoCompleteCustomSource.AddRange(qAcit.ToArray())
            Dim qATo = From j In Odb.Addresses Where j.Town.Length > 0 Select j.Town Distinct
            'For Each jp In qATo
            '    If Not IsNothing(jp) AndAlso jp.Length > 0 Then
            '        txtBoAddTown.AutoCompleteCustomSource.Add(jp)
            '    End If
            '    If IsClosing Then Exit Sub
            'Next
            txtBoAddTown.AutoCompleteCustomSource.AddRange(qATo.ToArray())
            Dim qAStr = From j In Odb.Addresses Where j.Street.Length > 0 Select j.Street Distinct
            'For Each jp In qJ
            '    If Not IsNothing(jp) AndAlso jp.Length > 0 Then
            '        txtBoADDStreet.AutoCompleteCustomSource.Add(jp)
            '        If jp.Length Mod 4 Then Application.DoEvents()
            '    End If
            '    If IsClosing Then Exit Sub
            'Next
            txtBoADDStreet.AutoCompleteCustomSource.AddRange(qJ.ToArray())
            Dim qSic = From sic In Odb.Healthies Select Mide = sic.Medicen, SickN = sic.Name, Doc = sic.SupervisorDoctor Distinct
            For Each sick In qSic
                If Not IsNothing(sick.SickN) AndAlso sick.SickN.Length > 0 AndAlso Not txtHSicknessName.AutoCompleteItems.Contains(sick.SickN) Then
                    Dim sicks() As String = sick.SickN.Split(New Char() {";"})
                    If Not IsNothing(sicks) AndAlso sicks.Length > 0 Then
                        For Each strg In sicks
                            If Not IsNothing(strg) AndAlso Not txtHSicknessName.AutoCompleteItems.Contains(strg) Then
                                txtHSicknessName.AutoCompleteItems.Add(strg)
                            End If
                        Next
                    Else
                        txtHSicknessName.AutoCompleteItems.Add(sick.SickN)
                    End If
                End If
                If Not IsNothing(sick.Mide) AndAlso sick.Mide.Length > 0 AndAlso Not txtHMedicen.AutoCompleteItems.Contains(sick.Mide) Then
                    Dim sicks() As String = sick.Mide.Split(New Char() {";"})
                    If Not IsNothing(sicks) AndAlso sicks.Length > 0 Then
                        For Each strg In sicks
                            If Not IsNothing(strg) AndAlso Not txtHMedicen.AutoCompleteItems.Contains(strg) Then
                                txtHMedicen.AutoCompleteItems.Add(strg)
                            End If
                        Next
                    Else
                        txtHMedicen.AutoCompleteItems.Add(sick.SickN)
                    End If
                End If
                If Not IsNothing(sick.Doc) AndAlso sick.Doc.Length > 0 AndAlso Not txtHDoctorName.AutoCompleteCustomSource.Contains(sick.Doc) Then
                    txtHDoctorName.AutoCompleteCustomSource.Add(sick.Doc)
                End If
                If IsClosing Then Exit Sub
            Next
            Dim qEdu = From edu In Odb.Studies Select edu.School, edu.Stage, edu.Resons Distinct
            For Each edu In qEdu
                If Not IsNothing(edu.Resons) AndAlso edu.Resons.Length > 0 AndAlso Not txtSReason.AutoCompleteCustomSource.Contains(edu.Resons) Then
                    txtSReason.AutoCompleteCustomSource.Add(edu.Resons)
                End If
                If Not IsNothing(edu.School) AndAlso edu.School.Length > 0 AndAlso Not txtSschoolNAme.AutoCompleteCustomSource.Contains(edu.School) Then
                    txtSschoolNAme.AutoCompleteCustomSource.Add(edu.School)
                End If
                If Not IsNothing(edu.Stage) AndAlso edu.Stage.Length > 0 AndAlso Not txtSStudyStage.AutoCompleteCustomSource.Contains(edu.Stage) Then
                    txtSStudyStage.AutoCompleteCustomSource.Add(edu.Stage)
                End If
                If IsClosing Then Exit Sub
            Next
            Dim qO = From Orp In Odb.Orphans Where Orp.BirthPlace.Length > 0 Select Orp.BirthPlace Distinct
            'For Each SS In qO
            '    If Not IsNothing(SS) AndAlso SS.Length > 0 Then
            '        txtOBirthPlace.AutoCompleteCustomSource.Add(SS)
            '    End If
            '    If IsClosing Then Exit Sub
            'Next
            txtOBirthPlace.AutoCompleteCustomSource.AddRange(qO.ToArray())
        Catch
        End Try
    End Sub

    Private Sub FillBondsManAddress(ByVal add As Address)
        If IsNothing(add) Then Exit Sub
        txtBoADDCell_Phone.Text = add.Cell_Phone
        txtBOADDCity.Text = add.City
        txtBOADDCountry.Text = add.Country
        txtBoADDEmail.Text = add.Email
        txtBoAddFacebook.Text = add.Facebook
        txtBoADDFax.Text = add.Fax
        txtBoADDHomeNum.Text = add.Home_Phone
        txtBoAddNote.Text = add.Note
        txtBoAddSkype.Text = add.Twitter
        txtBoADDStreet.Text = add.Street
        txtBoAddTown.Text = add.Town
        txtBoADDWorkNumb.Text = add.Work_Phone
    End Sub
    Private Sub FillBondsManName(ByVal nam As Name)
        If IsNothing(nam) Then Exit Sub
        txtBoNameEFather.Text = nam.EFather
        txtBoNameEfirst.Text = nam.EName
        txtBoNameELast.Text = nam.ELast
        txtBoNameFather.Text = nam.Father
        txtBoNameFirst.Text = nam.First
        txtBoNameLast.Text = nam.Last
    End Sub
    Private Function CheckOrphanBasicData() As Boolean
        If My.Settings.CheckIdentitysBeforAdd Then
            Return Checker.CheckOrphanBasicDataControls(OrphanFamily, dteOBirthday, numOIdNum, txtONameF)
        Else

            Return Checker.CheckOrphanBasicDataControls(OrphanFamily, dteOBirthday, Nothing, txtONameF)
        End If
    End Function
    Private Function CheckHealthData() As Boolean
        Return Checker.CheckHealthDataControls(chkHIsSick, txtHDoctorName, txtHSicknessName)
    End Function
    Private Function CheckStudyData() As Boolean
        Return Checker.CheckStudyDataControls(chkSisStudy, txtSStudyStage)
    End Function
    Private Function CheckBondsBasic() As Boolean
        If IsBoMother = False AndAlso IsBoExist = False Then
            If My.Settings.CheckIdentitysBeforAdd Then
                Return Checker.CheckBondsBasicControls(txtBoNameFirst, txtBoNameFirst.Text, txtBoNameLast.Text, numBoMonthlyIncome, numBoIDnumber)
            Else
                Return Checker.CheckBondsBasicControls(txtBoNameFirst, txtBoNameFirst.Text, txtBoNameLast.Text, numBoMonthlyIncome, Nothing)
            End If
        Else
            If IsBoMother Then
                Dim q = From bond In Odb.BondsMans Where bond.IdentityCard_ID = numBoIDnumber.Value Select bond
                Dim ExcNam() As Integer
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    ExcNam = New Integer() {OrphanFamily.Mother.Name_ID, q.First().Name_ID}
                Else
                    ExcNam = New Integer() {OrphanFamily.Mother.Name_ID}
                End If
                If My.Settings.CheckIdentitysBeforAdd Then
                    Return Checker.CheckBondsBasicControls(txtBoNameFirst, txtBoNameFirst.Text, txtBoNameLast.Text, numBoMonthlyIncome, numBoIDnumber, ExcNam)
                Else
                    Return Checker.CheckBondsBasicControls(txtBoNameFirst, txtBoNameFirst.Text, txtBoNameLast.Text, numBoMonthlyIncome, Nothing, ExcNam)
                End If
            Else
                Dim q = From bond In Odb.Mothers Where bond.IdntityCard_ID = numBoIDnumber.Value Select bond
                Dim ExcNam() As Integer
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    ExcNam = New Integer() {Bo.Name_ID, q.First().Name_ID}
                Else
                    ExcNam = New Integer() {Bo.Name_ID}
                End If
                If My.Settings.CheckFamilyCardBeforAdd Then
                    Return Checker.CheckBondsBasicControls(txtBoNameFirst, txtBoNameFirst.Text, txtBoNameLast.Text, numBoMonthlyIncome, numBoIDnumber, ExcNam)
                Else
                    Return Checker.CheckBondsBasicControls(txtBoNameFirst, txtBoNameFirst.Text, txtBoNameLast.Text, numBoMonthlyIncome, Nothing, ExcNam)
                End If
            End If
        End If
    End Function
    Private Sub btnFatherBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFatherBrowse.Click
        Dim frm As New FrmFatherChooser(False)
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            If Not IsNothing(frm.SelectedFamily) Then
                    Dim q = From fam In Odb.Families Join mot In Odb.Mothers On
                            fam.Mother_ID Equals mot.ID Join fath In Odb.Fathers On
                            fath.ID Equals fam.Father_ID
                            Where fam.ID = frm.SelectedFamily
                            Select motherName = mot.Name, fathName = fath.Name, fam
                    Me.OrphanFamily = q.FirstOrDefault().fam
                    txtMotherName.Text = Getter.GetFullName(q.FirstOrDefault().motherName)
                    txtFatherName.Text = Getter.GetFullName(q.FirstOrDefault().fathName)
                    txtONameFAther.Text = q.FirstOrDefault().fathName.First
                    txtONameLast.Text = q.FirstOrDefault().fathName.Last
                    txtONameELast.Text = q.FirstOrDefault().fathName.ELast
                    txtONameEFath.Text = q.FirstOrDefault().fathName.EFather
                    Me.RadWizard1.NextButton.Enabled = True
                    grpOBasic.Enabled = True
                    grpOName.Enabled = True
                    Dim q1 = From o In Odb.Orphans Where o.Family_ID = Me.OrphanFamily.ID Select o
                    If Not IsNothing(q1) AndAlso q1.Count > 0 Then
                        Me.Bo = q1.First().BondsMan
                        SetBondsManData()
                        Me.IsBoExist = True
                        Me.IsBoMother = False
                    End If
            Else
                Me.RadWizard1.NextButton.Enabled = False
                grpOBasic.Enabled = False
                grpOName.Enabled = False
                txtONameFAther.Text = ""
                txtONameLast.Text = ""
                txtONameELast.Text = ""
                txtONameEFath.Text = ""
            End If
        Else
            Me.RadWizard1.NextButton.Enabled = False
            grpOBasic.Enabled = False
            grpOName.Enabled = False
            txtONameFAther.Text = ""
            txtONameLast.Text = ""
            txtONameELast.Text = ""
            txtONameEFath.Text = ""
        End If
        frm.Dispose()
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        Me.RadWizard1.HelpButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        Me.RadWizard1.CancelButton.Text = "الغاء الأمر"
        Me.RadWizard1.NextButton.Text = "التالي"
        Me.RadWizard1.NextButton.Enabled = False
        Me.RadWizard1.BackButton.Text = "السابق"
        Me.RadWizard1.FinishButton.Text = "إنهاء"
    End Sub
    Public Sub New(ByVal Fam_Id As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        Me.RadWizard1.HelpButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        Me.RadWizard1.CancelButton.Text = "الغاء الأمر"
        Me.RadWizard1.NextButton.Text = "التالي"
        Me.RadWizard1.NextButton.Enabled = False
        Me.RadWizard1.BackButton.Text = "السابق"
        Me.RadWizard1.FinishButton.Text = "إنهاء"
        Dim fam As Family = Getter.GetFamilyByID(Fam_Id, Odb)
        If Not IsNothing(fam) Then
            Me.OrphanFamily = fam
            txtMotherName.Text = Getter.GetFullName(fam.Mother.Name)
            txtFatherName.Text = Getter.GetFullName(fam.Father.Name)
            txtONameFAther.Text = fam.Father.Name.First
            txtONameLast.Text = fam.Father.Name.Last
            txtONameELast.Text = fam.Father.Name.ELast
            txtONameEFath.Text = fam.Father.Name.EFather
            Me.RadWizard1.NextButton.Enabled = True
            grpOBasic.Enabled = True
            grpOName.Enabled = True
        End If
    End Sub

    Private Sub CancelBuutonClick(ByVal sender As Object, ByVal e As EventArgs) Handles RadWizard1.Cancel
        Me.Close()
    End Sub

    Private Sub RadWizard1_Finish(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadWizard1.Finish
        Me.Close()
    End Sub
    Private Sub chkHIsSick_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkHIsSick.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            picHFace.Enabled = True
            txtHNote.Enabled = True
            txtHDoctorName.Enabled = True
            txtHMedicen.Enabled = True
            txtHSicknessName.Enabled = True
            numHCost.Enabled = True
            grpHPicReporte.Enabled = True
        Else
            grpHPicReporte.Enabled = False
            picHFace.Enabled = False
            txtHNote.Enabled = False
            txtHDoctorName.Enabled = False
            txtHMedicen.Enabled = False
            txtHSicknessName.Enabled = False
            numHCost.Enabled = False
        End If
    End Sub


    Private Sub PicShow_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicSstudyCerti.DoubleClick, picBoIdPhoto1.DoubleClick, picBoIdphoto2.DoubleClick, picSStarter.DoubleClick, PicOFacePhoto.DoubleClick, PicOBodyPhoto.DoubleClick, picHFace.DoubleClick, picObirthCertificate.DoubleClick, picOFamilyCardPhoto.DoubleClick
        If TypeOf sender Is PictureSelector.PictureSelector Then
            Dim pic As PictureSelector.PictureSelector = DirectCast(sender, PictureSelector.PictureSelector)
            Dim frm As New FrmShowPic(pic.Photo)            
            frm.ShowDialog()
            frm.Dispose()
        End If
    End Sub

    Private Sub chkSisStudy_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkSisStudy.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            txtSNote.Enabled = True
            txtSschoolNAme.Enabled = True
            txtSStudyStage.Enabled = True
            numSDegreesRate.Enabled = True
            numSMonthlyCost.Enabled = True
            picSStarter.Enabled = True
            PicSstudyCerti.Enabled = True
            grpPicSStarter.Enabled = True
            grpPicSstudyCerti.Enabled = True
            txtSStudyStage.Text = ""
        Else
            grpPicSStarter.Enabled = False
            grpPicSstudyCerti.Enabled = False
            txtSNote.Enabled = False
            txtSschoolNAme.Enabled = False
            txtSStudyStage.Enabled = False
            numSDegreesRate.Enabled = False
            numSMonthlyCost.Enabled = False
            picSStarter.Enabled = False
            PicSstudyCerti.Enabled = False
            txtSStudyStage.Text = "متخلف عن الدراسة"
        End If
    End Sub

    Private Sub RadWizard1_SelectedPageChanging(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.SelectedPageChangingEventArgs) Handles RadWizard1.SelectedPageChanging
        If e.SelectedPage Is pageOBasic Then
            If Not CheckOrphanBasicData() Then e.Cancel = True
        ElseIf e.SelectedPage Is pageHealth AndAlso e.NextPage Is pageStudy Then
            If Not CheckHealthData() Then e.Cancel = True
        ElseIf e.SelectedPage Is pageStudy AndAlso e.NextPage Is pageBoBasic Then
            If Not CheckStudyData() Then e.Cancel = True
        ElseIf e.SelectedPage Is pageBoBasic AndAlso e.NextPage Is pageBoAddress Then
            If Not CheckBondsBasic() Then e.Cancel = True
        ElseIf e.SelectedPage Is pageBoAddress AndAlso e.NextPage Is pageProgress Then
            If Not IsBoExist AndAlso Not IsBoMother Then
                If Not IsNothing(txtBOADDCountry.Text) AndAlso txtBOADDCountry.Text.Length <= 1 Then
                    ExceptionsManager.RaiseOnStatus(New MyException("أدخل عنوان المعيل - المحافظة", True, True))
                    e.Cancel = True
                    Return
                End If
                If Not IsNothing(txtBOADDCity.Text) AndAlso txtBOADDCity.Text.Length <= 1 Then
                    ExceptionsManager.RaiseOnStatus(New MyException("أدخل عنوان المعيل - المدينة", True, True))
                    e.Cancel = True
                    Return
                End If
            End If
        ElseIf e.SelectedPage Is pageProgress AndAlso e.NextPage Is PageFinish Then
        End If
    End Sub

    Private Sub btnBMom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBMom.Click
        If Not IsNothing(OrphanFamily) Then
            grpBoAddress.Enabled = False
            numBoMonthlyIncome.Enabled = True
            txtBoJop.Enabled = False
            txtBoNote.Enabled = False
            txtBoName.Enabled = False
            numBoIDnumber.Enabled = False
            grpBoName.Enabled = False
            grpBoIDImage1.Enabled = False
            grpBoIDIMage2.Enabled = False
            Dim mom As Mother = OrphanFamily.Mother
            FillBondsManAddress(mom.Address)
            txtBoName.Text = Getter.GetFullName(mom.Name)
            FillBondsManName(mom.Name)
            picBoIdPhoto1.SetImageByBytes(mom.IdentityCard_Photo)
            picBoIdphoto2.SetImageByBytes(mom.IdentityCard_Photo2)
            If Not IsNothing(mom.IdntityCard_ID) Then
                numBoIDnumber.Value = mom.IdntityCard_ID
            End If
            txtBoJop.Text = mom.Jop
            txtBoNote.Text = mom.Note
            IsBoMother = True
            IsBoExist = False
        End If
    End Sub

    Private Sub ClearNumTxt(ByVal grp As Telerik.WinControls.UI.RadGroupBox)
        If grp.HasChildren Then
            For Each child In grp.Controls
                If TypeOf child Is RadTextBox Then
                    CType(child, RadTextBox).Text = ""
                End If
                If TypeOf child Is RadSpinEditor Then
                    CType(child, RadSpinEditor).Value = 0
                End If
                If TypeOf child Is RadMaskedEditBox Then
                    CType(child, RadMaskedEditBox).Text = ""
                End If
            Next
        End If
    End Sub
    Private Sub btnBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBNew.Click
        grpBoAddress.Enabled = True
        grpBoBaisc.Enabled = True
        grpBoName.Enabled = True
        numBoMonthlyIncome.Enabled = True
        txtBoJop.Enabled = True
        txtBoNote.Enabled = True
        numBoIDnumber.Enabled = True
        txtBoName.Enabled = True
        txtBoName.Text = ""
        grpBoIDImage1.Enabled = True
        grpBoIDIMage2.Enabled = True
        IsBoExist = False
        IsBoMother = False
        ClearNumTxt(grpBoName)
        ClearNumTxt(grpBoAddress)
        ClearNumTxt(grpBoBaisc)
    End Sub

    Private Sub SetBondsManData(Optional ByVal Bo As OrphanageClasses.BondsMan = Nothing)
        Dim SelectedPage As WizardPage = RadWizard1.SelectedPage
        If IsNothing(Bo) AndAlso IsNothing(Me.Bo) Then
            Return
        ElseIf IsNothing(Bo) AndAlso Not IsNothing(Me.Bo) Then
            RadWizard1.SelectedPage = pageBoBasic
            txtBoName.Text = Getter.GetFullName(Me.Bo.Name)
            FillBondsManName(Me.Bo.Name)
            txtBoJop.Text = Me.Bo.Jop
            txtBoNote.Text = Me.Bo.Note
            numBoIDnumber.Value = IIf(IsNothing(Me.Bo.IdentityCard_ID), 0, Me.Bo.IdentityCard_ID)
            numBoMonthlyIncome.Value = IIf(IsNothing(Me.Bo.Income) OrElse Me.Bo.Income < 0, 0, Me.Bo.Income)
            RadWizard1.SelectedPage = pageBoAddress
            If Not IsNothing(Me.Bo.Address) Then
                FillBondsManAddress(Me.Bo.Address)
            End If
            picBoIdPhoto1.SetImageByBytes(Me.Bo.IdentityCard_Photo)
            picBoIdphoto2.SetImageByBytes(Me.Bo.IdentityCard_Photo2)
        ElseIf Not IsNothing(Bo) AndAlso IsNothing(Me.Bo) Then
            RadWizard1.SelectedPage = pageBoBasic
            txtBoName.Text = Getter.GetFullName(Bo.Name)
            FillBondsManName(Bo.Name)
            txtBoJop.Text = Bo.Jop
            txtBoNote.Text = Bo.Note
            numBoIDnumber.Value = IIf(IsNothing(Bo.IdentityCard_ID), 0, Bo.IdentityCard_ID)
            numBoMonthlyIncome.Value = IIf(IsNothing(Bo.Income) OrElse Bo.Income < 0, 0, Bo.Income)
            RadWizard1.SelectedPage = pageBoAddress
            If Not IsNothing(Bo.Address) Then
                FillBondsManAddress(Bo.Address)
            End If
            picBoIdPhoto1.SetImageByBytes(Bo.IdentityCard_Photo)
            picBoIdphoto2.SetImageByBytes(Bo.IdentityCard_Photo2)
        Else
            RadWizard1.SelectedPage = pageBoBasic
            txtBoName.Text = Getter.GetFullName(Me.Bo.Name)
            FillBondsManName(Me.Bo.Name)
            txtBoJop.Text = Me.Bo.Jop
            txtBoNote.Text = Me.Bo.Note
            numBoIDnumber.Value = IIf(IsNothing(Me.Bo.IdentityCard_ID), 0, Me.Bo.IdentityCard_ID)
            numBoMonthlyIncome.Value = IIf(IsNothing(Me.Bo.Income) OrElse Me.Bo.Income < 0, 0, Me.Bo.Income)
            RadWizard1.SelectedPage = pageBoAddress
            If Not IsNothing(Me.Bo.Address) Then
                FillBondsManAddress(Me.Bo.Address)
            End If
            picBoIdPhoto1.SetImageByBytes(Me.Bo.IdentityCard_Photo)
            picBoIdphoto2.SetImageByBytes(Me.Bo.IdentityCard_Photo2)
        End If
        txtBoName.Enabled = False
        grpBoAddress.Enabled = False
        grpBoName.Enabled = False
        grpBoBaisc.Enabled = False
        grpBoIDImage1.Enabled = False
        grpBoIDIMage2.Enabled = False
        RadWizard1.SelectedPage = SelectedPage
    End Sub
    Private Sub btnBChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBChoose.Click
        Try
            Dim frm As New frmBondsManChooser(False)
            frm.ShowDialog(Application.OpenForms("FrmMain"))
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                If IsNothing(frm.SelectedBondsMan) Then Return
                Me.Bo = Getter.GetBondsManByID(frm.SelectedBondsMan, Odb)
                SetBondsManData()
                IsBoExist = True
                IsBoMother = False
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub
    Private Sub Save()
        Try
            Orph = New Orphan()
            If numOFootSize.Value > 0 Then
                Orph.FootSize = numOFootSize.Value
            End If
            If numOIdNum.Value > 0 Then
                Orph.IdentityNumber = numOIdNum.Value
            End If
            If numOTall.Value > 0 Then
                Orph.Tallness = numOTall.Value
            End If
            If numOWeight.Value > 0 Then
                Orph.Weight = numOWeight.Value
            End If
            If numOkaid.Value > 0 Then
                Orph.Kaid = numOkaid.Value
            End If
            lstStatus.Items.Add("جاري معالجة البيانات....")
            Application.DoEvents()
            Using tr = New Transactions.TransactionScope
                If IsBoExist Then
                    Orph.BondsMan_ID = Bo.ID
                    lstStatus.Items.Add("تم إسناد المعيل")
                    Application.DoEvents()
                Else
                    If IsBoMother Then
                        lstStatus.Items.Add("جاري البحث عن معيل متطابق مع الام...")
                        Application.DoEvents()
                        Dim qBf = From bond In Odb.BondsMans Where bond.IdentityCard_ID = numBoIDnumber.Value Select bond

                        If Not IsNothing(qBf) AndAlso Not IsNothing(qBf.FirstOrDefault) Then
                            lstStatus.Items.Add("تم العثور على معيل متطابق...")
                            Application.DoEvents()
                            Orph.BondsMan_ID = qBf.FirstOrDefault.ID
                            lstStatus.Items.Add("تم إسناد المعيل")
                            Application.DoEvents()
                        Else
                            lstStatus.Items.Add("لم يتم العثور على معيل متطابق...")
                            Application.DoEvents()
                            lstStatus.Items.Add("جاري تسجيل معيل جديد...")
                            Application.DoEvents()
                            Bo = New BondsMan()
                            lstStatus.Items.Add(vbTab & "جاري تسجيل العنوان و الاسم...")
                            Application.DoEvents()
                            BoAdd = New Address() With {.Cell_Phone = txtBoADDCell_Phone.Text, .City = txtBOADDCity.Text, _
                                                       .Country = txtBOADDCountry.Text, .Email = txtBoADDEmail.Text, _
                                                       .Facebook = txtBoAddFacebook.Text, .Fax = txtBoADDFax.Text, _
                                                       .Home_Phone = txtBoADDHomeNum.Text, .Note = txtBoAddNote.Text, _
                                                       .Street = txtBoADDStreet.Text, .Town = txtBoAddTown.Text, _
                                                       .Twitter = txtBoAddSkype.Text, .Work_Phone = txtBoADDWorkNumb.Text}
                            BoName = New Name With {.EFather = txtBoNameEFather.Text, .ELast = txtBoNameELast.Text, _
                                                   .EName = txtBoNameEfirst.Text, .Father = txtBoNameFather.Text, _
                                                   .First = txtBoNameFirst.Text, .Last = txtBoNameLast.Text}
                            lstStatus.Items.Add(vbTab & "تم الحفظ")
                            lstStatus.Items.Add(vbTab & "جاري تسجيل بيانات المعيل....")
                            Application.DoEvents()
                            If numBoIDnumber.Value > 0 Then
                                Bo.IdentityCard_ID = numBoIDnumber.Value
                            End If
                            If numBoMonthlyIncome.Value > 0 Then
                                Bo.Income = numBoMonthlyIncome.Value
                            End If
                            Bo.Jop = txtBoJop.Text
                            Bo.Note = txtBoNote.Text
                            Bo.IdentityCard_Photo = picBoIdPhoto1.PhotoAsBytes
                            Bo.IdentityCard_Photo2 = picBoIdphoto2.PhotoAsBytes
                            Odb.Names.InsertOnSubmit(BoName)
                            Odb.Addresses.InsertOnSubmit(BoAdd)
                            Odb.SubmitChanges()
                            Odb.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, BoName)
                            Odb.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, BoAdd)
                            Bo.Address_ID = BoAdd.ID
                            Bo.Name_ID = BoName.ID
                            Bo.RegDate = Date.Now
                            Bo.User_ID = frmLogin.CurrentUser.ID
                            Odb.BondsMans.InsertOnSubmit(Bo)
                            Odb.SubmitChanges()
                            Orph.BondsMan_ID = Bo.ID
                            lstStatus.Items.Add(vbTab & "تم الحفظ")
                            Application.DoEvents()
                        End If
                    Else
                        lstStatus.Items.Add("جاري تسجيل معيل جديد...")
                        Application.DoEvents()
                        Bo = New BondsMan()
                        lstStatus.Items.Add(vbTab & "جاري تسجيل العنوان و الاسم...")
                        Application.DoEvents()
                        BoAdd = New Address() With {.Cell_Phone = txtBoADDCell_Phone.Text, .City = txtBOADDCity.Text, _
                                                   .Country = txtBOADDCountry.Text, .Email = txtBoADDEmail.Text, _
                                                   .Facebook = txtBoAddFacebook.Text, .Fax = txtBoADDFax.Text, _
                                                   .Home_Phone = txtBoADDHomeNum.Text, .Note = txtBoAddNote.Text, _
                                                   .Street = txtBoADDStreet.Text, .Town = txtBoAddTown.Text, _
                                                   .Twitter = txtBoAddSkype.Text, .Work_Phone = txtBoADDWorkNumb.Text}
                        BoName = New Name With {.EFather = txtBoNameEFather.Text, .ELast = txtBoNameELast.Text, _
                                               .EName = txtBoNameEfirst.Text, .Father = txtBoNameFather.Text, _
                                               .First = txtBoNameFirst.Text, .Last = txtBoNameLast.Text}
                        lstStatus.Items.Add(vbTab & "تم الحفظ")
                        lstStatus.Items.Add(vbTab & "جاري تسجيل بيانات المعيل....")
                        Application.DoEvents()
                        If numBoIDnumber.Value > 0 Then
                            Bo.IdentityCard_ID = numBoIDnumber.Value
                        End If
                        If numBoMonthlyIncome.Value > 0 Then
                            Bo.Income = numBoMonthlyIncome.Value
                        End If
                        Bo.Jop = txtBoJop.Text
                        Bo.Note = txtBoNote.Text
                        Bo.IdentityCard_Photo = picBoIdPhoto1.PhotoAsBytes
                        Bo.IdentityCard_Photo2 = picBoIdphoto2.PhotoAsBytes
                        Odb.Names.InsertOnSubmit(BoName)
                        Odb.Addresses.InsertOnSubmit(BoAdd)
                        Odb.SubmitChanges()
                        Odb.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, BoName)
                        Odb.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, BoAdd)
                        Bo.Address_ID = BoAdd.ID
                        Bo.Name_ID = BoName.ID
                        Bo.RegDate = Date.Now
                        Bo.User_ID = frmLogin.CurrentUser.ID
                        Odb.BondsMans.InsertOnSubmit(Bo)
                        Odb.SubmitChanges()
                        Orph.BondsMan_ID = Bo.ID
                        lstStatus.Items.Add(vbTab & "تم الحفظ")
                        Application.DoEvents()
                    End If
                End If
                lstStatus.Items.Add("جاري تسجيل يتيم جديد...")
                lstStatus.Items.Add(vbTab & "جاري تسجيل الاسم...")
                Application.DoEvents()
                OName = New Name With {.First = txtONameF.Text, .Father = txtONameFAther.Text, _
                                      .Last = txtONameLast.Text, .EName = txtONameEf.Text, _
                                      .ELast = txtONameELast.Text, .EFather = txtONameEFath.Text}
                Odb.Names.InsertOnSubmit(OName)
                Odb.SubmitChanges()
                lstStatus.Items.Add(vbTab & "تم الحفظ")
                Application.DoEvents()
                'Check Healthy Data
                If chkHIsSick.Checked Then
                    lstStatus.Items.Add(vbTab & "جاري تسجيل البيانات الصحية...")
                    Application.DoEvents()
                    Dim hlth As New Healthy()
                    If numHCost.Value > 0 Then
                        hlth.Cost = numHCost.Value
                    End If
                    Dim Medic As String = ""
                    Dim Sickne As String = ""
                    If Not IsNothing(txtHMedicen.Items) AndAlso txtHMedicen.Items.Count > 0 Then
                        For Each itm In txtHMedicen.Items
                            Medic &= itm.Text & ";"
                        Next
                    End If
                    If Medic.Length > 0 Then
                        Medic = Medic.Substring(0, Medic.Length - 1)
                        hlth.Medicen = Medic
                    End If
                    If Not IsNothing(txtHSicknessName.Items) AndAlso txtHSicknessName.Items.Count > 0 Then
                        For Each itm In txtHSicknessName.Items
                            Sickne &= itm.Text & ";"
                        Next
                    End If
                    If Sickne.Length > 0 Then
                        Sickne = Sickne.Substring(0, Sickne.Length - 1)
                        hlth.Name = Sickne
                    End If
                    hlth.ReporteFile = picHFace.PhotoAsBytes
                    hlth.SupervisorDoctor = txtHDoctorName.Text
                    hlth.Note = txtHNote.Text
                    Odb.Healthies.InsertOnSubmit(hlth)
                    Odb.SubmitChanges()
                    Orph.Health_ID = hlth.ID
                    lstStatus.Items.Add(vbTab & "تم الحفظ")
                    Application.DoEvents()
                End If
                'Check Studies Data
                lstStatus.Items.Add(vbTab & "جاري تسجيل البيانات الدراسية...")
                Application.DoEvents()
                If chkSisStudy.Checked Then
                    Dim stud As New Study()
                    stud.Note = txtSNote.Text
                    stud.Certificate_Photo1 = picSStarter.PhotoAsBytes
                    stud.Certificate_Photo2 = PicSstudyCerti.PhotoAsBytes
                    If numSDegreesRate.Value > 0 Then
                        stud.DegreesRate = numSDegreesRate.Value
                    End If
                    If numSMonthlyCost.Value > 0 Then
                        stud.MonthlyCost = numSMonthlyCost.Value
                    End If
                    stud.School = txtSschoolNAme.Text
                    stud.Stage = txtSStudyStage.Text
                    Odb.Studies.InsertOnSubmit(stud)
                    Odb.SubmitChanges()
                    Orph.Education_ID = stud.ID
                    lstStatus.Items.Add(vbTab & "تم الحفظ")
                    Application.DoEvents()
                Else
                    Dim stud As New Study()
                    stud.Stage = txtSStudyStage.Text
                    stud.Resons = txtSReason.Text
                    Odb.Studies.InsertOnSubmit(stud)
                    Odb.SubmitChanges()
                    Orph.Education_ID = stud.ID
                    lstStatus.Items.Add(vbTab & "تم الحفظ")
                    Application.DoEvents()
                End If
                lstStatus.Items.Add(vbTab & "جاري تسجيل بيانات اليتيم....")
                Application.DoEvents()
                Orph.Name_ID = OName.ID
                Orph.Family_ID = OrphanFamily.ID
                Orph.Birthday = dteOBirthday.Value
                'Dim Oage As Integer
                'Dim ddiff As New DateDiff(dteOBirthday.Value, Date.Now)
                'Oage = ddiff.ElapsedYears
                'Orph.Age = Oage
                Orph.BirthCertificate_Photo = picObirthCertificate.PhotoAsBytes
                Orph.BirthPlace = txtOBirthPlace.Text
                Orph.BondsManRelationship = txtOBoRelation.Text
                Orph.FacePhoto = PicOFacePhoto.PhotoAsBytes
                Orph.FamilyCardPagePhoto = picOFamilyCardPhoto.PhotoAsBytes
                Orph.FullPhoto = PicOBodyPhoto.PhotoAsBytes
                Orph.Gender = RadDropDownList1.Text
                ' Orph.IdentityNumber = numOIdNum.Value
                Orph.RegDate = Date.Now
                Orph.User_ID = frmLogin.CurrentUser.ID
                Odb.Orphans.InsertOnSubmit(Orph)
                Odb.SubmitChanges()
                tr.Complete()
                lstStatus.Items.Add(vbTab & "تم الحفظ")
                Application.DoEvents()
                lblFinishMessage.ForeColor = Color.Green
                lblFinishMessage.Text = "انتهت العملية بنجاح وتم تسجيل اليتيم " & Chr(13) & Getter.GetFullName(Orph.Name)
                RadWizard1.SelectNextPage()
                RadWizard1.BackButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
                RadWizard1.CancelButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
                AddedNew.Add(Orph.ID)
            End Using
            Try
                Updater.AddNewOrphan(Orph)
                Updater.UpdatesFamily(OrphanFamily)
            Catch
            End Try
        Catch ex As Exception
            lstStatus.Items.Add(vbTab & "لم يتم حفظ شي!")
            lblFinishMessage.ForeColor = Color.Red
            lblFinishMessage.Text = "حدث الخطأ التالي ولم يتم إضافة اية بيانات جديدة" & Chr(13) & ex.Message
            RadWizard1.BackButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
            RadWizard1.CancelButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
            RadWizard1.NextButton.Enabled = True
            LinkLabel1.Visible = False
            lblAddNewC.Visible = False
            'RadWizard1.SelectNextPage()
            Application.DoEvents()
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub txtBoNameFirst_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoNote.Enter, txtBoNameLast.Enter, txtBoNameFirst.Enter, txtBoNameFather.Enter, txtBoJop.Enter, txtSStudyStage.Enter, txtSschoolNAme.Enter, txtSReason.Enter, txtSNote.Enter, txtONameLast.Enter, txtONameFAther.Enter, txtONameF.Enter, txtOBoRelation.Enter, txtOBirthPlace.Enter, txtHSicknessName.Enter, txtHNote.Enter, txtHMedicen.Enter, txtHDoctorName.Enter, txtBoAddTown.Enter, txtBoADDStreet.Enter, txtBoAddNote.Enter, txtBOADDCountry.Enter, txtBOADDCity.Enter
        LangChanger.CurLang.SaveCurrentLanguage()
        LangChanger.CurLang.ChangeToArabic()
    End Sub

    Private Sub txtBoNameFirst_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoNote.Leave, txtBoNameLast.Leave, txtBoNameFirst.Leave, txtBoNameFather.Leave, txtBoJop.Leave, txtBoNameELast.Leave, txtBoNameEfirst.Leave, txtBoNameEFather.Leave, txtSStudyStage.Leave, txtSschoolNAme.Leave, txtSReason.Leave, txtSNote.Leave, txtONameLast.Leave, txtONameFAther.Leave, txtONameF.Leave, txtONameELast.Leave, txtONameEFath.Leave, txtONameEf.Leave, txtOBoRelation.Leave, txtOBirthPlace.Leave, txtHSicknessName.Leave, txtHNote.Leave, txtHMedicen.Leave, txtHDoctorName.Leave, txtBoAddTown.Leave, txtBoADDStreet.Leave, txtBoAddSkype.Leave, txtBoAddNote.Leave, txtBoAddFacebook.Leave, txtBoADDEmail.Leave, txtBOADDCountry.Leave, txtBOADDCity.Leave
        LangChanger.CurLang.ReturnToSavedLanguage()
    End Sub

    Private Sub txtBoNameEfirst_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoNameELast.Enter, txtBoNameEfirst.Enter, txtBoNameEFather.Enter, txtONameELast.Enter, txtONameEFath.Enter, txtONameEf.Enter, txtBoAddSkype.Enter, txtBoAddFacebook.Enter, txtBoADDEmail.Enter
        LangChanger.CurLang.SaveCurrentLanguage()
        LangChanger.CurLang.ChangeToEnglish()
    End Sub

    Private Sub RadWizard1_SelectedPageChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.SelectedPageChangedEventArgs) Handles RadWizard1.SelectedPageChanged
        If e.SelectedPage Is pageProgress Then
            progressBar1.StartWaiting()
            Me.RadWizard1.BackButton.Enabled = False
            Me.RadWizard1.NextButton.Enabled = False
            Me.RadWizard1.CancelButton.Enabled = False
            Save()
            progressBar1.StopWaiting()
        ElseIf e.SelectedPage Is PageFinish Then
            Me.RadWizard1.BackButton.Enabled = True
            Me.RadWizard1.NextButton.Enabled = True
            Me.RadWizard1.CancelButton.Enabled = True
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        RadWizard1.BackButton.Visibility = Telerik.WinControls.ElementVisibility.Visible
        RadWizard1.CancelButton.Visibility = Telerik.WinControls.ElementVisibility.Visible
        txtONameF.Text = ""
        txtONameEf.Text = ""        
        txtONameF.Focus()
        RadWizard1.SelectedPage = pageOBasic
    End Sub

    Private Sub RadDropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles RadDropDownList1.SelectedIndexChanged
        If IsNothing(SavedAutoComplete) OrElse SavedAutoComplete.Length <= 0 Then Exit Sub
        txtOBoRelation.AutoCompleteCustomSource.Clear()
        txtOBoRelation.AutoCompleteCustomSource.AddRange(SavedAutoComplete)
        For i1 = 0 To SavedAutoComplete.Length - 1
            Dim St As String = SavedAutoComplete(i1)
            If RadDropDownList1.Text.Contains("ذ") Then
                If St.EndsWith("ا") AndAlso txtOBoRelation.AutoCompleteCustomSource.Contains(St) Then txtOBoRelation.AutoCompleteCustomSource.Remove(St)
            Else
                If St.EndsWith("ه") AndAlso txtOBoRelation.AutoCompleteCustomSource.Contains(St) Then txtOBoRelation.AutoCompleteCustomSource.Remove(St)
            End If
        Next
    End Sub

    Private Sub FrmAddNewOrphanW_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If t.IsAlive Then
            t.Abort()
        End If
        IsClosing = True
    End Sub

    Private Sub FrmAddNewOrphanW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        t.Priority = Threading.ThreadPriority.Lowest
        t.IsBackground = True
        t.Start()
        ReDim SavedAutoComplete(txtOBoRelation.AutoCompleteCustomSource.Count - 1)
        txtOBoRelation.AutoCompleteCustomSource.CopyTo(SavedAutoComplete, 0)
        RadDropDownList1_SelectedIndexChanged(sender, Nothing)
    End Sub

    Private Sub dteOBirthday_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dteOBirthday.ValueChanged
        Dim dte As New DateDiff(dteOBirthday.Value, Date.Now)
        If dte.ElapsedYears <= 5 Then
            chkSisStudy.Checked = False
            chkSisStudy_ToggleStateChanged(Nothing, New Telerik.WinControls.UI.StateChangedEventArgs(Telerik.WinControls.Enumerations.ToggleState.Off))
            txtSReason.Text = "دون السن القانوني للدراسة"
        ElseIf dte.ElapsedYears > 5 AndAlso dte.ElapsedYears < 17 Then
            chkSisStudy.Checked = True
            chkSisStudy_ToggleStateChanged(Nothing, New Telerik.WinControls.UI.StateChangedEventArgs(Telerik.WinControls.Enumerations.ToggleState.On))
            txtSStudyStage.Text = txtSStudyStage.AutoCompleteCustomSource(dte.ElapsedYears - 6)
            txtSReason.Text = ""
        End If
    End Sub
End Class
