Imports Orphanage.OrphanageClasses
Imports Itenso.TimePeriod
Public Class FrmOrphan
    Dim Odb As New OrphanageDB.Odb()
    Private _Id As Integer = 0
    Private Name_ID As Integer = 0
    Private _Orph As Orphan = Nothing
    Private _NewBondsMan As Integer = -1
    Dim SavedAutoComplete() As String
    Private Delegate Sub AutoCompleteDelegate()
    Private CallAutoComplete As New AutoCompleteDelegate(AddressOf SetAutoComplete)
    Dim t As New Threading.Thread(AddressOf CallAutoCompleteThread)
    Public ReplacedBondsMan As Integer = -1
    Public Sub New(ByVal Id As Integer)
        InitializeComponent()
        Me._Id = Id
    End Sub
    Public Sub SetNameForm(ByVal obj As OrphanageClasses.Name)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            NameForm1.First = obj.First
            NameForm1.Middle = obj.Father
            NameForm1.Last = obj.Last
            NameForm1.English_First = obj.EName
            NameForm1.English_Last = obj.ELast
            NameForm1.English_Middle = obj.EFather
            txtOName.Text = Getter.GetFullName(obj)
        End If
    End Sub
    Public Sub SetBoNameForm(ByVal obj As OrphanageClasses.Name)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            NameFormBo.First = obj.First
            NameFormBo.Middle = obj.Father
            NameFormBo.Last = obj.Last
            NameFormBo.English_First = obj.EName
            NameFormBo.English_Last = obj.ELast
            NameFormBo.English_Middle = obj.EFather
            txtBoName.Text = Getter.GetFullName(obj)
        End If
    End Sub

    Public Sub GetFromNameObject(ByRef obj As OrphanageClasses.Name)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            obj.First = NameForm1.First
            'obj.Father = NameForm1.Middle
            'obj.Last = NameForm1.Last
            obj.EName = NameForm1.English_First
            'obj.ELast = NameForm1.English_Last
            'obj.EFather = NameForm1.English_Middle
        Else
            obj = New OrphanageClasses.Name()
            obj.First = NameForm1.First
            'obj.Father = NameForm1.Middle
            'obj.Last = NameForm1.Last
            obj.EName = NameForm1.English_First
            'obj.ELast = NameForm1.English_Last
            'obj.EFather = NameForm1.English_Middle
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
            txtBoAddress.Text = Getter.GetAddress(obj)
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
        Try
            Using Odb As New OrphanageDB.Odb
                'Dim qN = From nam In Odb.Names Select EF = nam.EName, EL = nam.ELast, Efath = nam.EFather Distinct
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
                Dim SickNa As New ArrayList()
                Dim SickMid As New ArrayList()
                Dim SickDocN As New ArrayList()
                Dim qSic = From sic In Odb.Healthies Select Mide = sic.Medicen, SickN = sic.Name, Doc = sic.SupervisorDoctor Distinct
                For Each sick In qSic
                    If Not IsNothing(sick.SickN) AndAlso sick.SickN.Length > 0 AndAlso Not txtHSicknessName.AutoCompleteItems.Contains(sick.SickN) Then
                        Dim sicks() As String = sick.SickN.Split(New Char() {CChar(";")})
                        If Not IsNothing(sicks) AndAlso sicks.Length > 0 Then
                            For Each strg In sicks
                                If Not IsNothing(strg) AndAlso Not SickNa.Contains(strg) Then
                                    SickNa.Add(strg)
                                End If
                            Next
                        Else
                            SickNa.Add(sick.SickN)
                        End If
                    End If
                    If Not IsNothing(sick.Mide) AndAlso sick.Mide.Length > 0 AndAlso Not SickMid.Contains(sick.Mide) Then
                        Dim sicks() As String = sick.Mide.Split(New Char() {CChar(";")})
                        If Not IsNothing(sicks) AndAlso sicks.Length > 0 Then
                            For Each strg In sicks
                                If Not IsNothing(strg) AndAlso Not SickMid.Contains(strg) Then
                                    SickMid.Add(strg)
                                End If
                            Next
                        Else
                            SickMid.Add(sick.Mide)
                        End If
                    End If
                    If Not IsNothing(sick.Doc) AndAlso sick.Doc.Length > 0 AndAlso Not SickDocN.Contains(sick.Doc) Then
                        SickDocN.Add(sick.Doc)
                    End If
                Next
                If SickDocN.Count > 0 Then
                    txtHDoctorName.AutoCompleteCustomSource.AddRange(CType(SickDocN.ToArray(GetType(String)), String()))
                End If
                If SickNa.Count > 0 Then
                    txtHSicknessName.AutoCompleteItems.AddRange(CType(SickNa.ToArray(GetType(String)), String()))
                End If
                If SickMid.Count > 0 Then
                    txtHMedicen.AutoCompleteItems.AddRange(CType(SickMid.ToArray(GetType(String)), String()))
                End If
                Dim EduR As New ArrayList()
                Dim EduS As New ArrayList()
                Dim EduScho As New ArrayList()
                Dim qEdu = From edu In Odb.Studies Select edu.School, edu.Stage, edu.Resons Distinct
                For Each edu In qEdu
                    If Not IsNothing(edu.Resons) AndAlso edu.Resons.Length > 0 AndAlso Not EduR.Contains(edu.Resons) Then
                        EduR.Add(edu.Resons)
                    End If
                    If Not IsNothing(edu.School) AndAlso edu.School.Length > 0 AndAlso Not EduScho.Contains(edu.School) Then
                        EduScho.Add(edu.School)
                    End If
                    If Not IsNothing(edu.Stage) AndAlso edu.Stage.Length > 0 AndAlso Not EduS.Contains(edu.Stage) Then
                        EduS.Add(edu.Stage)
                    End If
                Next
                If EduR.Count > 0 Then
                    txtSReason.AutoCompleteCustomSource.AddRange(CType(EduR.ToArray(GetType(String)), String()))
                End If
                If EduS.Count > 0 Then
                    txtSStudyStage.AutoCompleteCustomSource.AddRange(CType(EduS.ToArray(GetType(String)), String()))
                End If
                If EduScho.Count > 0 Then
                    txtSschoolNAme.AutoCompleteCustomSource.AddRange(CType(EduScho.ToArray(GetType(String)), String()))
                End If
                'Dim orpBp As New ArrayList()
                'Dim orpStory As New ArrayList()
                Dim qO = From Orp In Odb.Orphans Where Orp.BirthPlace.Length > 0 Select Orp.BirthPlace Distinct
                'For Each SS In qO
                '    If Not IsNothing(SS) AndAlso SS.Length > 0 AndAlso Not orpBp.Contains(SS) Then
                '        orpBp.Add(SS)
                '    End If
                'Next
                Dim qOq = From Orp In Odb.Orphans Where Orp.Story.Length > 0 Select Orp.Story Distinct
                'For Each SS In qOq
                '    If Not IsNothing(SS) AndAlso SS.Length > 0 AndAlso Not orpStory.Contains(SS) Then
                '        orpStory.Add(SS)
                '    End If
                'Next
                'If orpBp.Count > 0 Then
                '    txtOBirthPlace.AutoCompleteCustomSource.AddRange(CType(orpBp.ToArray(GetType(String)), String()))
                'End If
                'If orpStory.Count > 0 Then
                '    txtOStory.AutoCompleteCustomSource.AddRange(CType(orpStory.ToArray(GetType(String)), String()))
                'End If
                txtOStory.AutoCompleteCustomSource.AddRange(qOq.ToArray())
                txtOBirthPlace.AutoCompleteCustomSource.AddRange(qO.ToArray())
                Odb.Dispose()
            End Using
        Catch
        End Try
    End Sub


    Private Sub txtName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOName.Enter
        NameForm1.ShowMe()
    End Sub
    Private Sub txtNameBo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoName.Enter
        NameFormBo.ShowMe()
        AddressForm1.HideMe()
    End Sub
    Private Sub txtAddressBo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoAddress.Enter
        NameFormBo.HideMe()
        AddressForm1.ShowMe()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If My.Settings.CheckIdentityBeforEdit Then
                If Not Checker.CheckOrphanBasicDataControls(_Orph.Family, dteOBirthday, numOIdNum, txtOName, New Integer() {_Orph.Name_ID}) OrElse _
                    Not Checker.CheckStudyDataControls(chkSisStudy, txtSStudyStage) Then
                    Return
                End If
            Else
                If Not Checker.CheckOrphanBasicDataControls(_Orph.Family, dteOBirthday, Nothing, txtOName, New Integer() {_Orph.Name_ID}) OrElse _
                    Not Checker.CheckStudyDataControls(chkSisStudy, txtSStudyStage) Then
                    Return
                End If
            End If
            Dim DeletedHealth As Healthy = Nothing
            Dim DeletedStudy As Study = Nothing
            Dim q = From orp In Odb.Orphans Where orp.ID = Me._Id Select orp
            If IsNothing(q) OrElse q.Count <> 1 Then Exit Sub
            Dim Orph As Orphan = q.FirstOrDefault()
            If _NewBondsMan > 0 Then
                ReplacedBondsMan = _NewBondsMan
            End If
            If numOFootSize.Value > 0 Then
                Orph.FootSize = CType(numOFootSize.Value, Byte?)
            End If
            If numOIdNum.Value > 0 Then
                Orph.IdentityNumber = CType(numOIdNum.Value, ULong?)
            End If
            If numOTall.Value > 0 Then
                Orph.Tallness = CType(numOTall.Value, Byte?)
            End If
            If numOWeight.Value > 0 Then
                Orph.Weight = CType(numOWeight.Value, Byte?)
            End If
            If numOkaid.Value > 0 Then
                Orph.Kaid = CType(numOkaid.Value, Integer?)
            End If
            Using tr As New Transactions.TransactionScope
                GetFromNameObject(Orph.Name)
                'Check Healthy Data
                If IsNothing(Orph.Health_ID) Then
                    If chkHIsSick.Checked Then
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
                        If Not IsNothing(Medic) AndAlso Medic.Length > 0 Then
                            Medic = Medic.Substring(0, Medic.Length - 1)
                            hlth.Medicen = Medic
                        End If
                        If Not IsNothing(txtHSicknessName.Items) AndAlso txtHSicknessName.Items.Count > 0 Then
                            For Each itm In txtHSicknessName.Items
                                Sickne &= itm.Text & ";"
                            Next
                        End If
                        If Not IsNothing(Sickne) AndAlso Sickne.Length > 0 Then
                            Sickne = Sickne.Substring(0, Sickne.Length - 1)
                            hlth.Name = Sickne
                        End If
                        hlth.ReporteFile = picHFace.PhotoAsBytes
                        hlth.SupervisorDoctor = txtHDoctorName.Text
                        hlth.Note = txtHNote.Text
                        Odb.Healthies.InsertOnSubmit(hlth)
                        Odb.SubmitChanges()
                        Orph.Healthy = hlth
                    End If
                Else
                    If chkHIsSick.Checked Then
                        If numHCost.Value > 0 Then
                            Orph.Healthy.Cost = numHCost.Value
                        End If
                        Dim Medic As String = ""
                        Dim Sickne As String = ""
                        If Not IsNothing(txtHMedicen.Items) AndAlso txtHMedicen.Items.Count > 0 Then
                            For Each itm In txtHMedicen.Items
                                Medic &= itm.Text & ";"
                            Next
                        End If
                        If Not IsNothing(Medic) AndAlso Medic.Length > 0 Then
                            Medic = Medic.Substring(0, Medic.Length - 1)
                            Orph.Healthy.Medicen = Medic
                        End If
                        If Not IsNothing(txtHSicknessName.Items) AndAlso txtHSicknessName.Items.Count > 0 Then
                            For Each itm In txtHSicknessName.Items
                                Sickne &= itm.Text & ";"
                            Next
                        End If
                        If Not IsNothing(Sickne) AndAlso Sickne.Length > 0 Then
                            Sickne = Sickne.Substring(0, Sickne.Length - 1)
                            Orph.Healthy.Name = Sickne
                        End If
                        Orph.Healthy.ReporteFile = picHFace.PhotoAsBytes
                        Orph.Healthy.SupervisorDoctor = txtHDoctorName.Text
                        Orph.Healthy.Note = txtHNote.Text
                        Odb.SubmitChanges()
                    Else
                        DeletedHealth = Orph.Healthy
                        Orph.Healthy = Nothing
                        Odb.SubmitChanges()
                    End If
                    End If
                'Check Studies Data
                If IsNothing(Orph.Study) Then
                    If chkSisStudy.Checked Then
                        'تسجيل بيان جديد
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
                        Orph.Study = stud
                    Else
                        'تسجيل بيان جديد لايدرس
                        Dim stud As New Study()
                        stud.Stage = txtSStudyStage.Text
                        stud.Resons = txtSReason.Text
                        Odb.Studies.InsertOnSubmit(stud)
                        Odb.SubmitChanges()
                        Orph.Study = stud
                    End If
                Else
                    If chkSisStudy.Checked Then
                        'تعديل البيان إلى يدرس
                        Orph.Study.Note = txtSNote.Text
                        Orph.Study.Certificate_Photo1 = picSStarter.PhotoAsBytes
                        Orph.Study.Certificate_Photo2 = PicSstudyCerti.PhotoAsBytes
                        If numSDegreesRate.Value > 0 Then
                            Orph.Study.DegreesRate = numSDegreesRate.Value
                        Else
                            Orph.Study.DegreesRate = Nothing
                        End If
                        If numSMonthlyCost.Value > 0 Then
                            Orph.Study.MonthlyCost = numSMonthlyCost.Value
                        Else
                            Orph.Study.MonthlyCost = Nothing
                        End If
                        Orph.Study.School = txtSschoolNAme.Text
                        Orph.Study.Stage = txtSStudyStage.Text
                        Odb.SubmitChanges()
                    Else
                        'تعديل البيان إلى لايدرس
                        Orph.Study.Stage = txtSStudyStage.Text
                        Orph.Study.Resons = txtSReason.Text
                        Orph.Study.Note = Nothing
                        Orph.Study.Certificate_Photo1 = Nothing
                        Orph.Study.Certificate_Photo2 = Nothing
                        Orph.Study.DegreesRate = Nothing
                        Orph.Study.MonthlyCost = Nothing
                        Orph.Study.School = Nothing
                        Odb.SubmitChanges()
                    End If
                End If
                Orph.Birthday = dteOBirthday.Value
                'Dim Oage As Integer
                'Dim ddiff As New DateDiff(dteOBirthday.Value, Date.Now)
                'Oage = ddiff.ElapsedYears
                'Orph.Age = Oage
                Orph.BirthCertificate_Photo = picObirthCertificate.PhotoAsBytes
                Orph.BirthPlace = txtOBirthPlace.Text
                Orph.BondsManRelationship = txtOBondsManRelation.Text
                Orph.FacePhoto = picFace.PhotoAsBytes
                Orph.FamilyCardPagePhoto = picOFamilyCardPhoto.PhotoAsBytes
                Orph.FullPhoto = PicBody.PhotoAsBytes
                Orph.Gender = cmbOGender.Text
                Orph.Story = txtOStory.Text
                If Not IsNothing(DeletedHealth) Then
                    Odb.Healthies.DeleteOnSubmit(DeletedHealth)
                    Odb.SubmitChanges()
                End If
                Odb.SubmitChanges()
                tr.Complete()
                ExceptionsManager.RaiseOnDesktopNow(New MyException("تم الحفظ", False, True))
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub picFace_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picFace.DoubleClick, PicBody.DoubleClick, picBoIdPhoto1.DoubleClick, picBoIdphoto2.DoubleClick, picHFace.DoubleClick, picObirthCertificate.DoubleClick, picOFamilyCardPhoto.DoubleClick, picSStarter.DoubleClick, PicSstudyCerti.DoubleClick
        Try
            Dim picxx As PictureSelector.PictureSelector = CType(sender, PictureSelector.PictureSelector)
            Dim frmShopic As FrmShowPic
            If picxx Is picFace Or picxx Is PicBody Then
                frmShopic = New FrmShowPic(picxx.Photo, txtOName.Text)
            Else
                frmShopic = New FrmShowPic(picxx.Photo)
            End If
            frmShopic.MdiParent = My.Application.OpenForms("FrmMain")
            frmShopic.Show()
            WindowsLauncher.AllWindows.Add(frmShopic)
        Catch

        End Try
    End Sub

    Private Sub pgeBasic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pgeBasic.Click, txtOBondsManRelation.Click, RadLabel4.Click, RadLabel36.Click, RadLabel1.Click, RadGroupBox5.Click, RadGroupBox4.Click, picFace.Click, PicBody.Click, numOIdNum.Click
        NameForm1.HideMe()
        txtOName.Text = NameForm1.First & " " & NameForm1.Middle & " " & NameForm1.Last
    End Sub

    Private Sub PgeBondsMan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoNote.Click, RadLabel30.Click, RadLabel27.Click, picBoIdphoto2.Click, picBoIdPhoto1.Click, PgeBondsMan.Click, grpBoIDIMage2.Click, grpBoIDImage1.Click
        NameFormBo.HideMe()
        txtBoName.Text = NameFormBo.First & " " & NameFormBo.Middle & " " & NameFormBo.Last
        AddressForm1.HideMe()
        If AddressForm1.Visible Then
            AddressForm1.HideMe()
            txtBoAddress.Text = ""
            If AddressForm1.Country.Length > 0 Then
                txtBoAddress.Text = AddressForm1.Country
            End If
            If AddressForm1.City.Length > 0 Then
                If txtBoAddress.Text.Length > 0 Then
                    txtBoAddress.Text &= My.Settings.AddressSeprator & AddressForm1.City
                Else
                    txtBoAddress.Text = AddressForm1.City
                End If
            End If
            If AddressForm1.Town.Length > 0 Then
                If txtBoAddress.Text.Length > 0 Then
                    txtBoAddress.Text &= My.Settings.AddressSeprator & AddressForm1.Town
                Else
                    txtBoAddress.Text = AddressForm1.Town
                End If
            End If
            If AddressForm1.Street.Length > 0 Then
                If txtBoAddress.Text.Length > 0 Then
                    txtBoAddress.Text &= My.Settings.AddressSeprator & AddressForm1.Street
                Else
                    txtBoAddress.Text = AddressForm1.Street
                End If
            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
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

    Private Sub FrmOrphan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        t.Priority = Threading.ThreadPriority.Lowest
        t.IsBackground = True
        t.Start()
        ReDim SavedAutoComplete(txtOBondsManRelation.AutoCompleteCustomSource.Count - 1)
        txtOBondsManRelation.AutoCompleteCustomSource.CopyTo(SavedAutoComplete, 0)
        cmbOGender_SelectedIndexChanged(sender, Nothing)
        Me.dteOBirthday.CustomFormat = My.Settings.GeneralDateFormat
        If _Id > 0 Then
            Try
                Dim q = From orph In Odb.Orphans Where orph.ID = _Id Select orph
                If Not IsNothing(q) AndAlso q.Count = 1 Then
                    Me._Orph = q.FirstOrDefault()
                    If IsNothing(_Orph) Then Me.Close()
                    Me.RadPageView1.SelectedPage = pgeBasic
                    SetNameForm(_Orph.Name)
                    dteOBirthday.Value = _Orph.Birthday
                    txtOBirthPlace.Text = _Orph.BirthPlace
                    txtOBondsManRelation.Text = _Orph.BondsManRelationship
                    Dim dte As New DateDiff(dteOBirthday.Value, Date.Now)
                    txtOAge.Text = ATDFormater.ArabicDateFormater.getFullArabicDate(dte.ElapsedYears, dte.ElapsedMonths, dte.ElapsedDays)
                    If Not IsNothing(_Orph.IdentityNumber) Then
                        numOIdNum.Value = CDec(_Orph.IdentityNumber)
                    End If
                    If Not IsNothing(_Orph.Kaid) Then
                        numOkaid.Value = CDec(_Orph.Kaid)
                    End If
                    cmbOGender.Text = _Orph.Gender
                    PicBody.SetImageByBytes(_Orph.FullPhoto)
                    picFace.SetImageByBytes(_Orph.FacePhoto)
                    Me.RadPageView1.SelectedPage = pgeOthers
                    If Not IsNothing(_Orph.Weight) Then
                        numOWeight.Value = CDec(_Orph.Weight)
                    End If
                    If Not IsNothing(_Orph.Tallness) Then
                        numOTall.Value = CDec(_Orph.Tallness)
                    End If
                    If Not IsNothing(_Orph.FootSize) Then
                        numOFootSize.Value = CDec(_Orph.FootSize)
                    End If
                    txtOStory.Text = _Orph.Story
                    picObirthCertificate.SetImageByBytes(_Orph.BirthCertificate_Photo)
                    picOFamilyCardPhoto.SetImageByBytes(_Orph.FamilyCardPagePhoto)
                    'Health
                    Me.RadPageView1.SelectedPage = pgeHealth
                    If Not IsNothing(_Orph.Health_ID) AndAlso _Orph.Health_ID > 0 Then
                        chkHIsSick.Checked = True
                        chkHIsSick_ToggleStateChanged(Nothing, New Telerik.WinControls.UI.StateChangedEventArgs(Telerik.WinControls.Enumerations.ToggleState.On))
                        txtHDoctorName.Text = _Orph.Healthy.SupervisorDoctor
                        If Not IsNothing(_Orph.Healthy.Medicen) Then
                            txtHMedicen.Text = _Orph.Healthy.Medicen.Replace(";", "+")
                            txtHMedicen.Text += "+"
                        End If
                        If Not IsNothing(_Orph.Healthy.Name) Then
                            txtHSicknessName.Text = _Orph.Healthy.Name.Replace(";", "+")
                            txtHSicknessName.Text += "+"
                        End If
                        txtHNote.Text = _Orph.Healthy.Note
                        If _Orph.Healthy.Cost.HasValue Then
                            numHCost.Value = _Orph.Healthy.Cost.Value
                        End If
                        picHFace.SetImageByBytes(_Orph.Healthy.ReporteFile)
                    Else
                        chkHIsSick.Checked = False
                        chkHIsSick_ToggleStateChanged(Nothing, New Telerik.WinControls.UI.StateChangedEventArgs(Telerik.WinControls.Enumerations.ToggleState.Off))
                    End If
                    'Education 
                    Me.RadPageView1.SelectedPage = pgeEducation
                    If Not IsNothing(_Orph.Education_ID) AndAlso _Orph.Education_ID > 0 Then
                        If _Orph.Study.Stage.Contains("متخلف") Then
                            chkSisStudy.Checked = False
                            chkSisStudy_ToggleStateChanged(Nothing, New Telerik.WinControls.UI.StateChangedEventArgs(Telerik.WinControls.Enumerations.ToggleState.Off))
                        Else
                            chkSisStudy.Checked = True
                            chkSisStudy_ToggleStateChanged(Nothing, New Telerik.WinControls.UI.StateChangedEventArgs(Telerik.WinControls.Enumerations.ToggleState.On))
                            txtSNote.Text = _Orph.Study.Note
                            txtSschoolNAme.Text = _Orph.Study.School
                            If _Orph.Study.DegreesRate.HasValue Then
                                numSDegreesRate.Value = _Orph.Study.DegreesRate.Value
                            End If
                            If _Orph.Study.MonthlyCost.HasValue Then
                                numSMonthlyCost.Value = _Orph.Study.MonthlyCost.Value
                            End If
                            picSStarter.SetImageByBytes(_Orph.Study.Certificate_Photo1)
                            PicSstudyCerti.SetImageByBytes(_Orph.Study.Certificate_Photo2)
                        End If
                        txtSStudyStage.Text = _Orph.Study.Stage
                        txtSReason.Text = _Orph.Study.Resons
                    Else
                        chkSisStudy.Checked = False
                        chkSisStudy_ToggleStateChanged(Nothing, New Telerik.WinControls.UI.StateChangedEventArgs(Telerik.WinControls.Enumerations.ToggleState.Off))
                    End If
                    'BondsMan 
                    Me.RadPageView1.SelectedPage = PgeBondsMan
                    SetAddressForm(_Orph.BondsMan.Address)
                    SetBoNameForm(_Orph.BondsMan.Name)
                    txtBoJop.Text = _Orph.BondsMan.Jop
                    txtBoNote.Text = _Orph.BondsMan.Note
                    If Not IsNothing(_Orph.BondsMan.IdentityCard_ID) AndAlso _Orph.BondsMan.IdentityCard_ID > 0 Then numBoIDnumber.Value = CDec(_Orph.BondsMan.IdentityCard_ID)
                    If Not IsNothing(_Orph.BondsMan.Income) AndAlso _Orph.BondsMan.Income > 0 Then numBoMonthlyIncome.Value = CDec(_Orph.BondsMan.Income)
                    picBoIdPhoto1.SetImageByBytes(_Orph.BondsMan.IdentityCard_Photo)
                    picBoIdphoto2.SetImageByBytes(_Orph.BondsMan.IdentityCard_Photo2)
                    Me.RadPageView1.SelectedPage = pgeBasic
                Else
                    Me.Close()
                End If
            Catch ex As Exception
                ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
                Me.Close()
            End Try
        Else
            Me.Close()
        End If
    End Sub
    Private Sub cmbOGender_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbOGender.SelectedIndexChanged
        If IsNothing(SavedAutoComplete) OrElse SavedAutoComplete.Length <= 0 Then Exit Sub
        txtOBondsManRelation.AutoCompleteCustomSource.Clear()
        txtOBondsManRelation.AutoCompleteCustomSource.AddRange(SavedAutoComplete)
        For i1 = 0 To SavedAutoComplete.Length - 1
            Dim St As String = SavedAutoComplete(i1)
            If cmbOGender.Text.Contains("ذ") Then
                If St.EndsWith("ا") AndAlso txtOBondsManRelation.AutoCompleteCustomSource.Contains(St) Then txtOBondsManRelation.AutoCompleteCustomSource.Remove(St)
            Else
                If St.EndsWith("ه") AndAlso txtOBondsManRelation.AutoCompleteCustomSource.Contains(St) Then txtOBondsManRelation.AutoCompleteCustomSource.Remove(St)
            End If
        Next
    End Sub

    Private Sub txtOBirthPlace_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOBondsManRelation.Enter, txtOBirthPlace.Enter, txtSStudyStage.Enter, txtSschoolNAme.Enter, txtSReason.Enter, txtSNote.Enter, txtOStory.Enter, txtHSicknessName.Enter, txtHNote.Enter, txtHMedicen.Enter, txtHDoctorName.Enter, txtBoNote.Enter, txtBoJop.Enter
        LangChanger.CurLang.SaveCurrentLanguage()
        LangChanger.CurLang.ChangeToArabic()
    End Sub

    Private Sub txtOBirthPlace_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOBondsManRelation.Leave, txtOBirthPlace.Leave, txtSStudyStage.Leave, txtSschoolNAme.Leave, txtSReason.Leave, txtSNote.Leave, txtOStory.Leave, txtHSicknessName.Leave, txtHNote.Leave, txtHMedicen.Leave, txtHDoctorName.Leave, txtBoNote.Leave, txtBoJop.Leave
        LangChanger.CurLang.ReturnToSavedLanguage()
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
        txtOAge.Text = ATDFormater.ArabicDateFormater.getFullArabicDate(dte.ElapsedYears, dte.ElapsedMonths, dte.ElapsedDays)
    End Sub

    Private Sub btnBondsMan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBondsMan.Click
        Dim retX As New frmBondsManChooser(False)
        'retX.MdiParent = Application.OpenForms("FrmMain")
        retX.ShowDialog()
        If retX.DialogResult = Windows.Forms.DialogResult.OK Then
            Using Odb As New OrphanageDB.Odb
                Dim q = From bo In Odb.BondsMans Where bo.ID = retX.SelectedBondsMan
                        Select bo
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    Dim bond As BondsMan = q.FirstOrDefault()
                    _NewBondsMan = bond.ID
                    Me.RadPageView1.SelectedPage = PgeBondsMan
                    SetAddressForm(bond.Address)
                    SetBoNameForm(bond.Name)
                    txtBoJop.Text = bond.Jop
                    txtBoNote.Text = bond.Note
                    If Not IsNothing(bond.IdentityCard_ID) AndAlso _Orph.BondsMan.IdentityCard_ID > 0 _
                        AndAlso _Orph.BondsMan.IdentityCard_ID.HasValue Then
                        numBoIDnumber.Value = _Orph.BondsMan.IdentityCard_ID.Value
                    End If
                    If bond.Income.HasValue AndAlso _Orph.BondsMan.Income.Value > 0 Then numBoMonthlyIncome.Value = _Orph.BondsMan.Income.Value
                    picBoIdPhoto1.SetImageByBytes(bond.IdentityCard_Photo)
                    picBoIdphoto2.SetImageByBytes(bond.IdentityCard_Photo2)
                    Me.RadPageView1.SelectedPage = pgeBasic
                End If
                Odb.Dispose()
            End Using
        End If
        retX.Dispose()
    End Sub
End Class
