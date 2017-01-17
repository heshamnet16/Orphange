Imports System.IO
Imports System.Text
Imports <xmlns="urn:OrphanageXML:Templates">
Imports Telerik.WinControls.UI

Public Class FrmNewTemplate
    Public Shared xmlFileName As String = CurDir() & "\Templets.xaml"
    Private _Name As String = ""
    Public Shared Function DeleteTemplete(ByVal tName As String) As Boolean
        Dim ret As Boolean = False
        Try
            If File.Exists(xmlFileName) Then
                If Not IsNothing(tName) AndAlso tName.Length > 0 Then
                    Dim xdoc As XDocument = XDocument.Load(xmlFileName)
                    Dim q = From temp In xdoc.<Templates>.<Template>
                            Where temp.<Name>.Value = tName
                            Select temp
                    If Not IsNothing(q) AndAlso q.Count > 0 Then
                        For Each temp In q
                            temp.Remove()
                        Next
                        xdoc.Save(xmlFileName)
                        ret = True
                    End If
                End If
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            ret = False
        End Try
        Return ret
    End Function
    Private Sub btnChooseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseFile.Click
        Dim Ofd As New OpenFileDialog()
        Ofd.Filter = "ملفات وورد|*.Docx"
        Ofd.Title = "اختر ملف وورد"
        If Ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtTempPath.Text = Ofd.FileName
        End If
        Ofd.Dispose()
    End Sub
    Private Function MakeTempleteElement() As XElement
        Dim FileLength As Long = New System.IO.FileInfo(txtTempPath.Text).Length
        Dim bytes() As Byte = File.ReadAllBytes(txtTempPath.Text)
        Dim x = <Template>
                    <Name>
                        <%= txtTempNAme.Text %>
                    </Name>
                    <Size>
                        <%= FileLength %>
                    </Size>
                    <IsFamily>
                        <%= chkIsFamily.Checked %>
                    </IsFamily>
                    <MaxOorphansCount>
                        <%= numMaxOrphanCount.Value.ToString() %>
                    </MaxOorphansCount>
                    <IsBookmarks>
                        <%= chkTempIsBookmark.Checked %>
                    </IsBookmarks>
                    <UseCustomBoolean>
                        <%= chkUseCustomBoolean.Checked %>
                    </UseCustomBoolean>
                    <BooleanFontName><%= txtBooleanFont.Text %></BooleanFontName>
                    <IsBondsManRepeated>
                        <%= chkIsRepeatedBondman.Checked %>
                    </IsBondsManRepeated>
                    <BooleanYesMark>
                        <%= IIf(chkUseCustomBoolean.Checked, txtBoolYES.Value, "نعم") %>
                    </BooleanYesMark>
                    <IsDefaultPictureWH><%= chkHasDefaultPict.Checked %></IsDefaultPictureWH>
                    <DefaultPictureH><%= (numDefualtH.Value * 360000).ToString() %></DefaultPictureH>
                    <DefaultPictureW><%= (numDefaultW.Value * 360000).ToString() %></DefaultPictureW>
                    <BooleanNOMark>
                        <%= IIf(chkUseCustomBoolean.Checked, txtBoolNO.Value, "لا") %>
                    </BooleanNOMark>
                    <Data>
                        <%= System.Convert.ToBase64String(bytes, Base64FormattingOptions.None) %>
                    </Data>
                    <IsSelected><%= chkTempIsDefault.Checked %></IsSelected>
                    <IsDefault><%= chkTempIsDefault.Checked %></IsDefault>
                    <Bookmarks>
                        <Orphan>
                            <FirstName><%= txtOFirstName.Text %></FirstName>
                            <FatherName><%= txtOFatherName.Text %></FatherName>
                            <LastName><%= txtOLastName.Text %></LastName>
                            <FullName><%= txtOFullname.Text %></FullName>
                            <EFirstName><%= txtOFirstNameE.Text %></EFirstName>
                            <EFatherName><%= txtOFatherNameE.Text %></EFatherName>
                            <ELastName><%= txtOLastNameE.Text %></ELastName>
                            <EFullName><%= txtOFullNameE.Text %></EFullName>
                            <Age><%= txtOAge.Text %></Age>
                            <Birthday><%= txtOBirthday.Text %></Birthday>
                            <IsStudy><%= txtOIsStudy.Text %></IsStudy>
                            <Education>
                                <Stage><%= txtOStudyStage.Text %></Stage>
                                <School><%= txtOStudySchool.Text %></School>
                                <Univercity></Univercity>
                                <Collage></Collage>
                                <MonthlyCost><%= txtOStudyCost.Text %></MonthlyCost>
                                <DegreesRate><%= txtOStudyRate.Text %></DegreesRate>
                                <Reasons><%= txtOStudyReason.Text %></Reasons>
                                <Certificate_Photo1><%= txtOStudyPhoto1.Text %></Certificate_Photo1>
                                <Certificate_Photo2><%= txtOStudyPhoto2.Text %></Certificate_Photo2>
                                <Note><%= txtOStudyNote.Text %></Note>
                            </Education>
                            <IsSick><%= txtOIsSick.Text %></IsSick>
                            <Health>
                                <Name><%= txtOHealthName.Text %></Name>
                                <Medicen><%= txtOHealthMedicen.Text %></Medicen>
                                <Cost><%= txtOHealthCost.Text %></Cost>
                                <SupervisorDoctor><%= txtOHealthDoctor.Text %></SupervisorDoctor>
                                <Note><%= txtOHealthNote.Text %></Note>
                                <ReporteFile><%= txtOHealthPhoto.Text %></ReporteFile>
                            </Health>
                            <FullPhoto><%= txtOFullPhoto.Text %></FullPhoto>
                            <FacePhoto><%= txtOFacePhoto.Text %></FacePhoto>
                            <IdentityNumber><%= txtOIdNumber.Text %></IdentityNumber>
                            <FootSize></FootSize>
                            <Weight></Weight>
                            <Tallness></Tallness>
                            <IsBailed><%= txtOIsBailed.Text %></IsBailed>
                            <RegDate><%= txtORegDate.Text %></RegDate>
                            <Story><%= txtOStory.Text %></Story>
                            <BondsManRel><%= txtOBondsManRel.Text %></BondsManRel>
                            <BirthCertificate_Photo><%= txtOBirthPhoto.Text %></BirthCertificate_Photo>
                            <FamilyCardPagePhoto><%= txtOFamilyCardPhoto.Text %></FamilyCardPagePhoto>
                            <Gender><%= txtOSex.Text %></Gender>
                            <Kaid><%= txtOKaid.Text %></Kaid>
                            <Birthplace><%= txtOBirthPlace.Text %></Birthplace>
                            <BrothersCount><%= txtOBrothersCount.Text %></BrothersCount>
                            <MaleBrothersCount><%= txtOMaleBroCount.Text %></MaleBrothersCount>
                            <FemaleBrothersCount><%= txtOFemaleBroCount.Text %></FemaleBrothersCount>
                        </Orphan>
                        <Father>
                            <FirstName><%= txtFFirstName.Text %></FirstName>
                            <FatherName><%= txtFfatherName.Text %></FatherName>
                            <LastName><%= txtFLastNAme.Text %></LastName>
                            <FullName><%= txtFFullName.Text %></FullName>
                            <EFirstName><%= txtFfirstNameE.Text %></EFirstName>
                            <EFatherName><%= txtFfatherNameE.Text %></EFatherName>
                            <ELastName><%= txtFLastNameE.Text %></ELastName>
                            <EFullName><%= txtFfullNameE.Text %></EFullName>
                            <Age><%= txtFAge.Text %></Age>
                            <Birthday><%= txtFBirthday.Text %></Birthday>
                            <Deathday><%= txtFDieday.Text %></Deathday>
                            <Photo><%= txtFPhoto.Text %></Photo>
                            <DeathCertificate_Photo><%= txtFDeathCPhoto.Text %></DeathCertificate_Photo>
                            <Jop><%= txtFJop.Text %></Jop>
                            <Story><%= txtFStory.Text %></Story>
                            <DeathReason><%= txtFDeathReason.Text %></DeathReason>
                            <Note><%= txtFNote.Text %></Note>
                            <IdentityCardNumber><%= txtFIdNumber.Text %></IdentityCardNumber>
                        </Father>
                        <Mother>
                            <FirstName><%= txtMFirstName.Text %></FirstName>
                            <FatherName><%= txtMFatherName.Text %></FatherName>
                            <LastName><%= txtMLastName.Text %></LastName>
                            <FullName><%= txtMFullName.Text %></FullName>
                            <EFirstName><%= txtMFirstNameE.Text %></EFirstName>
                            <EFatherName><%= txtMFatherNameE.Text %></EFatherName>
                            <ELastName><%= txtMLastNameE.Text %></ELastName>
                            <EFullName><%= txtMFullNameE.Text %></EFullName>
                            <Age></Age>
                            <Birthday><%= txtMBirthday.Text %></Birthday>
                            <Deathday><%= txtMDeathDay.Text %></Deathday>
                            <IsDead><%= txtMIsDead.Text %></IsDead>
                            <IdentityCardNumber><%= txtMIdNumber.Text %></IdentityCardNumber>
                            <IdentityCardPhoto1><%= txtMIdPhoto1.Text %></IdentityCardPhoto1>
                            <IdentityCardPhoto2><%= txtMIdPhoto2.Text %></IdentityCardPhoto2>
                            <Address>
                                <State><%= txtMAState.Text %></State>
                                <City><%= txtMACity.Text %></City>
                                <Town><%= txtMATown.Text %></Town>
                                <Street><%= txtMAStreet.Text %></Street>
                                <CellPhone><%= txtMAMobile.Text %></CellPhone>
                                <HomePhone><%= txtMAHomePhone.Text %></HomePhone>
                                <WorkPhone><%= txtMAWorkPhone.Text %></WorkPhone>
                                <Fax><%= txtMAFax.Text %></Fax>
                                <Email><%= txtMAEmail.Text %></Email>
                            </Address>
                            <IsMarried><%= txtMIsMarried.Text %></IsMarried>
                            <IsOwnOrphans><%= txtMIsOwnOrphan.Text %></IsOwnOrphans>
                            <Jop><%= txtMJop.Text %></Jop>
                            <Salary><%= txtMIncome.Text %></Salary>
                            <Note></Note>
                            <Story><%= txtMStory.Text %></Story>
                        </Mother>
                        <BondsMan>
                            <FirstName><%= txtBFirstName.Text %></FirstName>
                            <FatherName><%= txtBFatherName.Text %></FatherName>
                            <LastName><%= txtBLastName.Text %></LastName>
                            <FullName><%= txtBFullName.Text %></FullName>
                            <EFirstName><%= txtBFirstNameE.Text %></EFirstName>
                            <EFatherName><%= txtBFatherNameE.Text %></EFatherName>
                            <ELastName><%= txtBLastNameE.Text %></ELastName>
                            <EFullName><%= txtBFullNameE.Text %></EFullName>
                            <IdentityCardNumber><%= txtBIdNumber.Text %></IdentityCardNumber>
                            <IdentityCardPhoto1><%= txtBIdPhoto1.Text %></IdentityCardPhoto1>
                            <IdentityCardPhoto2><%= txtBIdPhoto2.Text %></IdentityCardPhoto2>
                            <Address>
                                <State><%= txtBAState.Text %></State>
                                <City><%= txtBACity.Text %></City>
                                <Town><%= txtBATown.Text %></Town>
                                <Street><%= txtBAStreet.Text %></Street>
                                <CellPhone><%= txtBAMobile.Text %></CellPhone>
                                <HomePhone><%= txtBAHomePhone.Text %></HomePhone>
                                <WorkPhone><%= txtBAWorkPhone.Text %></WorkPhone>
                                <Fax><%= txtBAFax.Text %></Fax>
                                <Email><%= txtBAEmail.Text %></Email>
                            </Address>
                            <Jop><%= txtBJop.Text %></Jop>
                            <Salary><%= txtBSalary.Text %></Salary>
                            <Note><%= txtBNotes.Text %></Note>
                        </BondsMan>
                        <Family>
                            <FamilyCardPhoto1><%= txtFamPhoto1.Text %></FamilyCardPhoto1>
                            <FamilyCardPhoto2><%= txtFamPhoto2.Text %></FamilyCardPhoto2>
                            <Address>
                                <Current>
                                    <State><%= txtFamACState.Text %></State>
                                    <City><%= txtFamACcity.Text %></City>
                                    <Town><%= txtFamACtown.Text %></Town>
                                    <Street><%= txtFamACStrret.Text %></Street>
                                    <CellPhone><%= txtFamACMobile.Text %></CellPhone>
                                    <HomePhone><%= txtFamACHomePhone.Text %></HomePhone>
                                    <WorkPhone><%= txtFamACWorkPhone.Text %></WorkPhone>
                                    <Fax><%= txtFamACFax.Text %></Fax>
                                    <Email><%= txtFamACEmail.Text %></Email>
                                </Current>
                                <Main>
                                    <State><%= txtFamAOState.Text %></State>
                                    <City><%= txtFamAOCity.Text %></City>
                                    <Town><%= txtFamAOTown.Text %></Town>
                                    <Street><%= txtFamAOStrret.Text %></Street>
                                    <CellPhone><%= txtFamAOMobile.Text %></CellPhone>
                                    <HomePhone><%= txtFamAOHomePhone.Text %></HomePhone>
                                    <WorkPhone><%= txtFamAOWorkPhone.Text %></WorkPhone>
                                    <Fax><%= txtFamAOFax.Text %></Fax>
                                    <Email><%= txtFamAOEmail.Text %></Email>
                                </Main>
                            </Address>
                            <IsRefugee><%= txtFamIsRefugee.Text %></IsRefugee>
                            <FamilyCardNumber><%= txtFamCardNumber.Text %></FamilyCardNumber>
                            <FinnacialState><%= txtFamFinncail.Text %></FinnacialState>
                            <ResidenceState><%= txtFamResidenceState.Text %></ResidenceState>
                            <ResidenceType><%= txtFamResidenceType.Text %></ResidenceType>
                        </Family>
                        <Bail>
                            <Supporter>
                                <FirstName><%= txtSFirstName.Text %></FirstName>
                                <FatherName><%= txtSFatherName.Text %></FatherName>
                                <LastName><%= txtSLastName.Text %></LastName>
                                <FullName><%= txtSFullName.Text %></FullName>
                                <EFirstName><%= txtSFirstNameE.Text %></EFirstName>
                                <EFatherName><%= txtSFatherNameE.Text %></EFatherName>
                                <ELastName><%= txtSLastNameE.Text %></ELastName>
                                <EFullName><%= txtSFullNameE.Text %></EFullName>
                            </Supporter>
                            <Amount><%= txtSAmount.Text %></Amount>
                            <CurnceyShort><%= txtSCurrency_Short.Text %></CurnceyShort>
                            <CurnceyName><%= txtSCurrency.Text %></CurnceyName>
                            <IsFamily><%= txtSIsFamily.Text %></IsFamily>
                            <IsDated><%= txtSIsDated.Text %></IsDated>
                            <StartDate><%= txtSStartDate.Text %></StartDate>
                            <EndDate><%= txtSEndDate.Text %></EndDate>
                            <IsMonthly><%= txtSIsMonthly.Text %></IsMonthly>
                            <Note><%= txtSNote.Text %></Note>
                        </Bail>
                    </Bookmarks>
                </Template>
        Return x
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtTempNAme.Text.Length <= 0 Then
            ExceptionsManager.RaiseOnStatus(New MyException("أدخل اسم النموذج", False, True))
            txtTempNAme.Focus()
            Return
        End If
        If txtTempPath.Text.Length <= 0 Then
            ExceptionsManager.RaiseOnStatus(New MyException("أختر النموذج", False, True))
            btnChooseFile.Focus()
            Return
        End If
        If chkUseCustomBoolean.Checked AndAlso txtBooleanFont.Text.Length <= 0 Then
            ExceptionsManager.RaiseOnStatus(New MyException("اختر خط الترميز", False, True))
            Return
        End If
        Dim Xdoc As XDocument = XDocument.Load(xmlFileName)
        Dim q = From temp In Xdoc.<Templates>.<Template> _
                Where temp.<Name>.Value = txtTempNAme.Text _
                Select temp

        If q.Count > 0 AndAlso q.Count = 1 Then
            For Each t In q
                t.Remove()
                Xdoc.<Templates>.FirstOrDefault().Add(MakeTempleteElement)
                Xdoc.Save(xmlFileName)
            Next
        Else
            Dim te = MakeTempleteElement()
            Xdoc.<Templates>.FirstOrDefault().Add(te)
            Xdoc.Save(xmlFileName)
        End If
        If chkTempIsDefault.Checked Then
            MakeMeDefault(txtTempNAme.Text)
        End If
        Me.Close()
    End Sub
    Public Shared Function GetDefault() As String
        If Not File.Exists(xmlFileName) Then Return Nothing
        Dim Xdoc As XDocument = XDocument.Load(xmlFileName)
        Dim q = From temp In Xdoc.<Templates>.<Template> _
                Select temp

        Dim ret As String = ""
        If q.Count > 0 AndAlso q.Count = 1 Then
            For Each t In q
                If CBool(t.<IsDefault>.Value) Then
                    ret = t.<Name>.Value
                End If
            Next
        End If
        Return ret
    End Function

    Public Shared Function GetSeleted() As String
        If Not File.Exists(xmlFileName) Then Return Nothing
        Dim Xdoc As XDocument = XDocument.Load(xmlFileName)
        Dim q = From temp In Xdoc.<Templates>.<Template> _
                Select temp

        Dim ret As String = ""
        If q.Count > 0 AndAlso q.Count = 1 Then
            For Each t In q
                If CBool(t.<IsSelected>.Value) Then
                    ret = t.<Name>.Value
                End If
            Next
        End If
        Return ret
    End Function
    Public Shared Sub MakeMeSelected(ByVal txtName As String)
        If Not File.Exists(xmlFileName) Then Return
        Dim Xdoc As XDocument = XDocument.Load(xmlFileName)
        Dim q = From temp In Xdoc.<Templates>.<Template> _
                Select temp
        If q.Count > 0 AndAlso q.Count = 1 Then
            For Each t In q
                If t.<Name>.Value = txtName Then
                    t.<IsSelected>.Value = True
                Else
                    t.<IsSelected>.Value = False
                End If
            Next
            Xdoc.Save(xmlFileName)
        End If
    End Sub
    Public Shared Sub MakeMeDefault(ByVal txtName As String)
        If Not File.Exists(xmlFileName) Then Return
        Dim Xdoc As XDocument = XDocument.Load(xmlFileName)
        Dim q = From temp In Xdoc.<Templates>.<Template> _
                Select temp
        If q.Count > 0 AndAlso q.Count = 1 Then
            For Each t In q
                If t.<Name>.Value = txtName Then
                    t.<IsDefault>.Value = True
                Else
                    t.<IsDefault>.Value = False
                End If
            Next
            Xdoc.Save(xmlFileName)
        End If
    End Sub
    Private Sub FrmNewTemplate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not File.Exists(xmlFileName) Then
            Dim xw As Xml.XmlWriter = Xml.XmlWriter.Create(xmlFileName)
            xw.WriteStartDocument()
            xw.WriteElementString("Templates", "urn:OrphanageXML:Templates", "")
            'xw.WriteEndElement()
            xw.WriteEndDocument()
            xw.Flush()
            xw.Close()
        End If
        txtBooleanFont.Text = FontDialog1.Font.Name
        If Me._Name.Length > 0 Then
            Dim xdoc As XDocument = XDocument.Load(xmlFileName)
            Dim q = From temp In xdoc.<Templates>.<Template>
                    Where temp.<Name>.Value = Me._Name
                    Select temp

            If q.Count > 0 Then
                For Each xele In q
                    txtTempNAme.Text = xele.<Name>.Value
                    txtTempPath.Text = ""
                    chkIsFamily.Checked = CBool(xele.<IsFamily>.Value)
                    numMaxOrphanCount.Value = CInt(xele.<MaxOorphansCount>.Value)
                    chkUseCustomBoolean.Checked = CBool(xele.<UseCustomBoolean>.Value)
                    chkIsRepeatedBondman.Checked = CBool(xele.<IsBondsManRepeated>.Value)
                    txtBooleanFont.Text = xele.<BooleanFontName>.Value()
                    chkTempIsBookmark.Checked = CBool(xele.<IsBookmarks>.Value)
                    chkTempIsDefault.Checked = CBool(xele.<IsDefault>.Value)
                    If IsNumeric(xele.<BooleanNOMark>.Value) Then
                        txtBoolNO.Value = CInt(xele.<BooleanNOMark>.Value)
                    End If
                    If IsNumeric(xele.<BooleanYesMark>.Value) Then
                        txtBoolYES.Value = CInt(xele.<BooleanYesMark>.Value)
                    End If
                    chkHasDefaultPict.Checked = CBool(xele.<IsDefaultPictureWH>.Value)
                    numDefaultW.Value = CDec(xele.<DefaultPictureW>.Value) / 360000D
                    numDefualtH.Value = CDec(xele.<DefaultPictureH>.Value) / 360000D
                    'Orphan
                    txtOAge.Text = xele.<Bookmarks>.<Orphan>.<Age>.Value
                    txtOBirthday.Text = xele.<Bookmarks>.<Orphan>.<Birthday>.Value
                    txtOBirthPhoto.Text = xele.<Bookmarks>.<Orphan>.<BirthCertificate_Photo>.Value
                    txtOBirthPlace.Text = xele.<Bookmarks>.<Orphan>.<Birthplace>.Value
                    txtOBondsManRel.Text = xele.<Bookmarks>.<Orphan>.<BondsManRel>.Value
                    txtOBrothersCount.Text = xele.<Bookmarks>.<Orphan>.<BrothersCount>.Value
                    txtOFacePhoto.Text = xele.<Bookmarks>.<Orphan>.<FacePhoto>.Value
                    txtOFamilyCardPhoto.Text = xele.<Bookmarks>.<Orphan>.<FamilyCardPagePhoto>.Value
                    txtOFatherName.Text = xele.<Bookmarks>.<Orphan>.<FatherName>.Value
                    txtOFatherNameE.Text = xele.<Bookmarks>.<Orphan>.<EFatherName>.Value
                    txtOFemaleBroCount.Text = xele.<Bookmarks>.<Orphan>.<FemaleBrothersCount>.Value
                    txtOFirstName.Text = xele.<Bookmarks>.<Orphan>.<FirstName>.Value
                    txtOFirstNameE.Text = xele.<Bookmarks>.<Orphan>.<EFirstName>.Value
                    txtOFullname.Text = xele.<Bookmarks>.<Orphan>.<FullName>.Value
                    txtOFullNameE.Text = xele.<Bookmarks>.<Orphan>.<EFullName>.Value
                    txtOFullPhoto.Text = xele.<Bookmarks>.<Orphan>.<FullPhoto>.Value
                    txtOHealthCost.Text = xele.<Bookmarks>.<Orphan>.<Health>.<Cost>.Value
                    txtOHealthDoctor.Text = xele.<Bookmarks>.<Orphan>.<Health>.<SupervisorDoctor>.Value
                    txtOHealthMedicen.Text = xele.<Bookmarks>.<Orphan>.<Health>.<Medicen>.Value
                    txtOHealthName.Text = xele.<Bookmarks>.<Orphan>.<Health>.<Name>.Value
                    txtOHealthNote.Text = xele.<Bookmarks>.<Orphan>.<Health>.<Note>.Value
                    txtOHealthPhoto.Text = xele.<Bookmarks>.<Orphan>.<Health>.<ReporteFile>.Value
                    txtOIdNumber.Text = xele.<Bookmarks>.<Orphan>.<IdentityNumber>.Value
                    txtOIsBailed.Text = xele.<Bookmarks>.<Orphan>.<IsBailed>.Value
                    txtOIsSick.Text = xele.<Bookmarks>.<Orphan>.<IsSick>.Value
                    txtOIsStudy.Text = xele.<Bookmarks>.<Orphan>.<IsStudy>.Value
                    txtOKaid.Text = xele.<Bookmarks>.<Orphan>.<Kaid>.Value
                    txtOLastName.Text = xele.<Bookmarks>.<Orphan>.<LastName>.Value
                    txtOLastNameE.Text = xele.<Bookmarks>.<Orphan>.<ELastName>.Value
                    txtOMaleBroCount.Text = xele.<Bookmarks>.<Orphan>.<MaleBrothersCount>.Value
                    txtORegDate.Text = xele.<Bookmarks>.<Orphan>.<RegDate>.Value
                    txtOSex.Text = xele.<Bookmarks>.<Orphan>.<Gender>.Value
                    txtOStory.Text = xele.<Bookmarks>.<Orphan>.<Story>.Value
                    txtOStudyCost.Text = xele.<Bookmarks>.<Orphan>.<Education>.<MonthlyCost>.Value
                    txtOStudyNote.Text = xele.<Bookmarks>.<Orphan>.<Education>.<Note>.Value
                    txtOStudyPhoto1.Text = xele.<Bookmarks>.<Orphan>.<Education>.<Certificate_Photo1>.Value
                    txtOStudyPhoto2.Text = xele.<Bookmarks>.<Orphan>.<Education>.<Certificate_Photo2>.Value
                    txtOStudyRate.Text = xele.<Bookmarks>.<Orphan>.<Education>.<DegreesRate>.Value
                    txtOStudyReason.Text = xele.<Bookmarks>.<Orphan>.<Education>.<Reasons>.Value
                    txtOStudySchool.Text = xele.<Bookmarks>.<Orphan>.<Education>.<School>.Value
                    txtOStudyStage.Text = xele.<Bookmarks>.<Orphan>.<Education>.<Stage>.Value
                    'Father
                    txtFAge.Text = xele.<Bookmarks>.<Father>.<Age>.Value
                    txtFBirthday.Text = xele.<Bookmarks>.<Father>.<Birthday>.Value
                    txtFDeathCPhoto.Text = xele.<Bookmarks>.<Father>.<DeathCertificate_Photo>.Value
                    txtFDeathReason.Text = xele.<Bookmarks>.<Father>.<DeathReason>.Value
                    txtFDieday.Text = xele.<Bookmarks>.<Father>.<Deathday>.Value
                    txtFfatherNameE.Text = xele.<Bookmarks>.<Father>.<EFatherName>.Value
                    txtFfatherName.Text = xele.<Bookmarks>.<Father>.<FatherName>.Value
                    txtFFirstName.Text = xele.<Bookmarks>.<Father>.<FirstName>.Value
                    txtFfirstNameE.Text = xele.<Bookmarks>.<Father>.<EFirstName>.Value
                    txtFFullName.Text = xele.<Bookmarks>.<Father>.<FullName>.Value
                    txtFfullNameE.Text = xele.<Bookmarks>.<Father>.<EFullName>.Value
                    txtFIdNumber.Text = xele.<Bookmarks>.<Father>.<IdentityCardNumber>.Value
                    txtFJop.Text = xele.<Bookmarks>.<Father>.<Jop>.Value
                    txtFLastNAme.Text = xele.<Bookmarks>.<Father>.<LastName>.Value
                    txtFLastNameE.Text = xele.<Bookmarks>.<Father>.<ELastName>.Value
                    txtFNote.Text = xele.<Bookmarks>.<Father>.<Note>.Value
                    txtFPhoto.Text = xele.<Bookmarks>.<Father>.<Photo>.Value
                    txtFStory.Text = xele.<Bookmarks>.<Father>.<Story>.Value
                    'Mother
                    txtMACity.Text = xele.<Bookmarks>.<Mother>.<Address>.<City>.Value
                    txtMAEmail.Text = xele.<Bookmarks>.<Mother>.<Address>.<Email>.Value
                    txtMAFax.Text = xele.<Bookmarks>.<Mother>.<Address>.<Fax>.Value
                    txtMAHomePhone.Text = xele.<Bookmarks>.<Mother>.<Address>.<HomePhone>.Value
                    txtMAMobile.Text = xele.<Bookmarks>.<Mother>.<Address>.<CellPhone>.Value
                    txtMAState.Text = xele.<Bookmarks>.<Mother>.<Address>.<State>.Value
                    txtMAStreet.Text = xele.<Bookmarks>.<Mother>.<Address>.<Street>.Value
                    txtMATown.Text = xele.<Bookmarks>.<Mother>.<Address>.<Town>.Value
                    txtMAWorkPhone.Text = xele.<Bookmarks>.<Mother>.<Address>.<WorkPhone>.Value
                    txtMBirthday.Text = xele.<Bookmarks>.<Mother>.<Birthday>.Value
                    txtMDeathDay.Text = xele.<Bookmarks>.<Mother>.<Deathday>.Value
                    txtMFatherName.Text = xele.<Bookmarks>.<Mother>.<FatherName>.Value
                    txtMFatherNameE.Text = xele.<Bookmarks>.<Mother>.<EFatherName>.Value
                    txtMFirstName.Text = xele.<Bookmarks>.<Mother>.<FirstName>.Value
                    txtMFirstNameE.Text = xele.<Bookmarks>.<Mother>.<EFirstName>.Value
                    txtMFullName.Text = xele.<Bookmarks>.<Mother>.<FullName>.Value
                    txtMFullNameE.Text = xele.<Bookmarks>.<Mother>.<EFullName>.Value
                    txtMIdNumber.Text = xele.<Bookmarks>.<Mother>.<IdentityCardNumber>.Value
                    txtMIdPhoto1.Text = xele.<Bookmarks>.<Mother>.<IdentityCardPhoto1>.Value
                    txtMIdPhoto2.Text = xele.<Bookmarks>.<Mother>.<IdentityCardPhoto2>.Value
                    txtMIncome.Text = xele.<Bookmarks>.<Mother>.<Salary>.Value
                    txtMIsDead.Text = xele.<Bookmarks>.<Mother>.<IsDead>.Value
                    txtMIsMarried.Text = xele.<Bookmarks>.<Mother>.<IsMarried>.Value
                    txtMIsOwnOrphan.Text = xele.<Bookmarks>.<Mother>.<IsOwnOrphans>.Value
                    txtMJop.Text = xele.<Bookmarks>.<Mother>.<Jop>.Value
                    txtMLastName.Text = xele.<Bookmarks>.<Mother>.<LastName>.Value
                    txtMLastNameE.Text = xele.<Bookmarks>.<Mother>.<ELastName>.Value
                    txtMStory.Text = xele.<Bookmarks>.<Mother>.<Story>.Value
                    'Family
                    txtFamACcity.Text = xele.<Bookmarks>.<Family>.<Address>.<Current>.<City>.Value
                    txtFamACMobile.Text = xele.<Bookmarks>.<Family>.<Address>.<Current>.<CellPhone>.Value
                    txtFamACEmail.Text = xele.<Bookmarks>.<Family>.<Address>.<Current>.<Email>.Value
                    txtFamACFax.Text = xele.<Bookmarks>.<Family>.<Address>.<Current>.<Fax>.Value
                    txtFamACHomePhone.Text = xele.<Bookmarks>.<Family>.<Address>.<Current>.<HomePhone>.Value
                    txtFamACState.Text = xele.<Bookmarks>.<Family>.<Address>.<Current>.<State>.Value
                    txtFamACStrret.Text = xele.<Bookmarks>.<Family>.<Address>.<Current>.<Street>.Value
                    txtFamACtown.Text = xele.<Bookmarks>.<Family>.<Address>.<Current>.<Town>.Value
                    txtFamACWorkPhone.Text = xele.<Bookmarks>.<Family>.<Address>.<Current>.<WorkPhone>.Value
                    txtFamAOCity.Text = xele.<Bookmarks>.<Family>.<Address>.<Main>.<City>.Value
                    txtFamAOMobile.Text = xele.<Bookmarks>.<Family>.<Address>.<Main>.<CellPhone>.Value
                    txtFamAOEmail.Text = xele.<Bookmarks>.<Family>.<Address>.<Main>.<Email>.Value
                    txtFamAOFax.Text = xele.<Bookmarks>.<Family>.<Address>.<Main>.<Fax>.Value
                    txtFamAOHomePhone.Text = xele.<Bookmarks>.<Family>.<Address>.<Main>.<HomePhone>.Value
                    txtFamAOState.Text = xele.<Bookmarks>.<Family>.<Address>.<Main>.<State>.Value
                    txtFamAOStrret.Text = xele.<Bookmarks>.<Family>.<Address>.<Main>.<Street>.Value
                    txtFamAOTown.Text = xele.<Bookmarks>.<Family>.<Address>.<Main>.<Town>.Value
                    txtFamAOWorkPhone.Text = xele.<Bookmarks>.<Family>.<Address>.<Main>.<WorkPhone>.Value
                    txtFamCardNumber.Text = xele.<Bookmarks>.<Family>.<FamilyCardNumber>.Value
                    txtFamFinncail.Text = xele.<Bookmarks>.<Family>.<FinnacialState>.Value
                    txtFamIsRefugee.Text = xele.<Bookmarks>.<Family>.<IsRefugee>.Value
                    txtFamPhoto1.Text = xele.<Bookmarks>.<Family>.<FamilyCardPhoto1>.Value
                    txtFamPhoto2.Text = xele.<Bookmarks>.<Family>.<FamilyCardPhoto2>.Value
                    txtFamResidenceState.Text = xele.<Bookmarks>.<Family>.<ResidenceState>.Value
                    txtFamResidenceType.Text = xele.<Bookmarks>.<Family>.<ResidenceType>.Value
                    'BondsMan
                    txtBACity.Text = xele.<Bookmarks>.<BondsMan>.<Address>.<City>.Value
                    txtBAMobile.Text = xele.<Bookmarks>.<BondsMan>.<Address>.<CellPhone>.Value
                    txtBAEmail.Text = xele.<Bookmarks>.<BondsMan>.<Address>.<Email>.Value
                    txtBAFax.Text = xele.<Bookmarks>.<BondsMan>.<Address>.<Fax>.Value
                    txtBAHomePhone.Text = xele.<Bookmarks>.<BondsMan>.<Address>.<HomePhone>.Value
                    txtBAState.Text = xele.<Bookmarks>.<BondsMan>.<Address>.<State>.Value
                    txtBAStreet.Text = xele.<Bookmarks>.<BondsMan>.<Address>.<Street>.Value
                    txtBATown.Text = xele.<Bookmarks>.<BondsMan>.<Address>.<Town>.Value
                    txtBAWorkPhone.Text = xele.<Bookmarks>.<BondsMan>.<Address>.<WorkPhone>.Value
                    txtBFatherName.Text = xele.<Bookmarks>.<BondsMan>.<FatherName>.Value
                    txtBFatherNameE.Text = xele.<Bookmarks>.<BondsMan>.<EFatherName>.Value
                    txtBFirstName.Text = xele.<Bookmarks>.<BondsMan>.<FirstName>.Value
                    txtBFirstNameE.Text = xele.<Bookmarks>.<BondsMan>.<EFirstName>.Value
                    txtBFullName.Text = xele.<Bookmarks>.<BondsMan>.<FullName>.Value
                    txtBFullNameE.Text = xele.<Bookmarks>.<BondsMan>.<EFullName>.Value
                    txtBIdNumber.Text = xele.<Bookmarks>.<BondsMan>.<IdentityCardNumber>.Value
                    txtBIdPhoto1.Text = xele.<Bookmarks>.<BondsMan>.<IdentityCardPhoto1>.Value
                    txtBIdPhoto2.Text = xele.<Bookmarks>.<BondsMan>.<IdentityCardPhoto2>.Value
                    txtBJop.Text = xele.<Bookmarks>.<BondsMan>.<Jop>.Value
                    txtBLastName.Text = xele.<Bookmarks>.<BondsMan>.<LastName>.Value
                    txtBLastNameE.Text = xele.<Bookmarks>.<BondsMan>.<ELastName>.Value
                    txtBNotes.Text = xele.<Bookmarks>.<BondsMan>.<Note>.Value
                    txtBSalary.Text = xele.<Bookmarks>.<BondsMan>.<Salary>.Value
                    'Bail
                    txtSAmount.Text = xele.<Bookmarks>.<Bail>.<Amount>.Value
                    txtSCurrency.Text = xele.<Bookmarks>.<Bail>.<CurnceyName>.Value
                    txtSCurrency_Short.Text = xele.<Bookmarks>.<Bail>.<CurnceyShort>.Value
                    txtSEndDate.Text = xele.<Bookmarks>.<Bail>.<EndDate>.Value
                    txtSIsDated.Text = xele.<Bookmarks>.<Bail>.<IsDated>.Value
                    txtSIsFamily.Text = xele.<Bookmarks>.<Bail>.<IsFamily>.Value
                    txtSIsMonthly.Text = xele.<Bookmarks>.<Bail>.<IsMonthly>.Value
                    txtSNote.Text = xele.<Bookmarks>.<Bail>.<Note>.Value
                    txtSStartDate.Text = xele.<Bookmarks>.<Bail>.<StartDate>.Value
                    txtSFatherName.Text = xele.<Bookmarks>.<Bail>.<Supporter>.<FatherName>.Value
                    txtSFatherNameE.Text = xele.<Bookmarks>.<Bail>.<Supporter>.<EFatherName>.Value
                    txtSFirstName.Text = xele.<Bookmarks>.<Bail>.<Supporter>.<FirstName>.Value
                    txtSFirstNameE.Text = xele.<Bookmarks>.<Bail>.<Supporter>.<EFirstName>.Value
                    txtSFullName.Text = xele.<Bookmarks>.<Bail>.<Supporter>.<FullName>.Value
                    txtSFullNameE.Text = xele.<Bookmarks>.<Bail>.<Supporter>.<EFullName>.Value
                    txtSLastName.Text = xele.<Bookmarks>.<Bail>.<Supporter>.<LastName>.Value
                    txtSLastNameE.Text = xele.<Bookmarks>.<Bail>.<Supporter>.<ELastName>.Value
                Next
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal _TempName As String)
        InitializeComponent()
        Me._Name = _TempName
    End Sub

    Private Sub chkUseCustomBoolean_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkUseCustomBoolean.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            txtBoolNO.Enabled = True
            txtBoolYES.Enabled = True
            txtBooleanFont.Enabled = True
            RadButton1.Enabled = True
            txtBooleanFont.Text = FontDialog1.Font.Name
        Else
            txtBoolNO.Enabled = False
            txtBoolYES.Enabled = False
            txtBooleanFont.Enabled = False
            RadButton1.Enabled = False
        End If
    End Sub

    Private Sub chkHasDefaultPict_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkHasDefaultPict.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            numDefaultW.Enabled = True
            numDefualtH.Enabled = True
        Else
            numDefaultW.Enabled = False
            numDefualtH.Enabled = False
        End If
    End Sub

    Private Sub grpTempProper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpTempProper.Click

    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        If FontDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtBooleanFont.Text = FontDialog1.Font.Name
        End If
    End Sub

    Private Sub chkTempIsBookmark_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkTempIsBookmark.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            ChangeTxt(Me.Controls, "اشارة مرجعية")            
        Else
            ChangeTxt(Me.Controls, "النص المراد استبداله")
        End If
    End Sub
    Public Sub ChangeTxt(ByRef ctls As Control.ControlCollection, ByVal str As String)
        If IsNothing(ctls) OrElse ctls.Count = 0 Then Return
        For Each ctl As Control In ctls
            If TypeOf ctl Is RadTextBox Then
                Dim txtBx As RadTextBox = CType(ctl, RadTextBox)
                If txtBx.Name = txtTempNAme.Name OrElse txtBx.Name = txtTempPath.Text OrElse txtBooleanFont.Name = txtBx.Name Then Continue For
                If txtBx.Name.IndexOf("Photo", StringComparison.OrdinalIgnoreCase) = -1 Then
                    txtBx.NullText = str
                End If
            Else
                If ctl.HasChildren Then
                    If TypeOf ctl.Controls Is RadPageViewControlCollection Then
                        Dim ctl2 As RadPageViewControlCollection = CType(ctl.Controls, RadPageViewControlCollection)
                        ChangeTxt(ctl2, str, 0)
                    Else
                        ChangeTxt(ctl.Controls, str)
                    End If

                End If
            End If
        Next
    End Sub
    Public Sub ChangeTxt(ByRef ctls As RadPageViewControlCollection, ByVal str As String, ByVal i As Integer)
        If IsNothing(ctls) OrElse ctls.Count = 0 Then Return
        For Each ctl As Control In ctls
            If TypeOf ctl Is RadTextBox Then
                Dim txtBx As RadTextBox = CType(ctl, RadTextBox)
                If txtBx.Name = txtTempNAme.Name OrElse txtBx.Name = txtTempPath.Text OrElse txtBooleanFont.Name = txtBx.Name Then Continue For
                If txtBx.Name.IndexOf("Photo", StringComparison.OrdinalIgnoreCase) = -1 Then
                    txtBx.NullText = str
                End If
            Else
                If ctl.HasChildren Then
                    If TypeOf ctl.Controls Is RadPageViewControlCollection Then
                        Dim ctl2 As RadPageViewControlCollection = CType(ctl.Controls, RadPageViewControlCollection)
                        ChangeTxt(ctl2, str, 0)
                    Else
                        ChangeTxt(ctl.Controls, str)
                    End If

                End If
            End If
        Next
    End Sub

    Private Sub chkIsFamily_ToggleStateChanged(sender As System.Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkIsFamily.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            numMaxOrphanCount.Enabled = True
            chkIsRepeatedBondman.Enabled = True
            RadLabel167.Enabled = True
            RadLabel168.Enabled = True
        Else
            numMaxOrphanCount.Enabled = False
            chkIsRepeatedBondman.Enabled = False
            RadLabel167.Enabled = False
            RadLabel168.Enabled = False
        End If
    End Sub
End Class
