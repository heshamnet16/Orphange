Imports System.IO
Imports Orphanage.OrphanageClasses
Imports Itenso.TimePeriod

Public Class DbXmlFileMaper
    Private _FileName As String
    Private _DeleteTheFile As Boolean = False
    Private odb As New OrphanageDB.Odb
    Public Property FileName() As String
        Get
            Return _FileName
        End Get
        Set(ByVal value As String)
            _FileName = value
        End Set
    End Property

    Public Sub New()
        _FileName = My.Computer.FileSystem.GetTempFileName
    End Sub
    Public Sub New(ByVal tempfilePath As String, ByVal deleteThefile As Boolean)
        _FileName = tempfilePath
        _DeleteTheFile = deleteThefile
    End Sub
    Public Function CreateFamilyFile(ByVal _Fam_ID As Integer) As Boolean
        If _Fam_ID <= 0 Then Return False
        Try
            Dim fam As OrphanageClasses.Family = Getter.GetFamilyByID(_Fam_ID, odb)
            Dim fath As Father = fam.Father
            Dim moth As Mother = fam.Mother
            If IsNothing(fam) Then Return False
            Dim mapper As New FileCreation.XmlBuilder()
            If fam.Address_ID2.HasValue Then
                mapper.Fam_Add_CellPhone2 = fam.Address1.Cell_Phone
                mapper.Fam_Add_City2 = fam.Address1.City
                mapper.Fam_Add_Country2 = fam.Address1.Country
                mapper.Fam_Add_Email2 = fam.Address1.Email
                mapper.Fam_Add_Facebook2 = fam.Address1.Facebook
                mapper.Fam_Add_Fax2 = fam.Address1.Fax
                mapper.Fam_Add_HomePhone2 = fam.Address1.Home_Phone
                mapper.Fam_Add_Street2 = fam.Address1.Street
                mapper.Fam_Add_Town2 = fam.Address1.Town
                mapper.Fam_Add_Twitter2 = fam.Address1.Twitter
                mapper.Fam_Add_WorkPhone2 = fam.Address1.Work_Phone
            End If
            If fam.Address_ID.HasValue Then
                mapper.Fam_Add_CellPhone = fam.Address.Cell_Phone
                mapper.Fam_Add_City = fam.Address.City
                mapper.Fam_Add_Country = fam.Address.Country
                mapper.Fam_Add_Email = fam.Address.Email
                mapper.Fam_Add_Facebook = fam.Address.Facebook
                mapper.Fam_Add_Fax = fam.Address.Fax
                mapper.Fam_Add_HomePhone = fam.Address.Home_Phone
                mapper.Fam_Add_Street = fam.Address.Street
                mapper.Fam_Add_Town = fam.Address.Town
                mapper.Fam_Add_Twitter = fam.Address.Twitter
                mapper.Fam_Add_WorkPhone = fam.Address.Work_Phone
            End If
            mapper.Fam_CardNumber = fam.FamilyCard_Num
            mapper.Fam_CardPhoto1 = fam.FamilyCardPhoto.ToImage
            mapper.Fam_CardPhoto2 = fam.FamilyCardPhotoP2.ToImage
            mapper.Fam_Finncial_State = fam.Finncial_Sate
            mapper.Fam_IsRefugee = fam.IsRefugee
            mapper.Fam_Note = fam.Note
            mapper.Fam_Residence_State = fam.Residece_Sate
            mapper.Fam_Residence_Type = fam.Residenc_Type
            'Father
            mapper.Fath_Birthday = fath.Birthday
            mapper.Fath_DeathCertificate = fath.DeathCertificate_Photo.ToImage
            mapper.Fath_DeathResone = fath.DeathResone
            mapper.Fath_Dieday = fath.Dieday
            mapper.Fath_EFatherName = fath.Name.EFather
            mapper.Fath_EFirstName = fath.Name.EName
            mapper.Fath_ELastName = fath.Name.ELast
            mapper.Fath_FatherName = fath.Name.Father
            mapper.Fath_FirstName = fath.Name.First
            mapper.Fath_IdentityNumber = CStr(fath.IdentityCard_ID)
            mapper.Fath_Jop = fath.Jop
            mapper.Fath_LastName = fath.Name.Last
            mapper.Fath_Note = fath.Note
            mapper.Fath_Photo = fath.Photo.ToImage()
            mapper.Fath_Story = fath.Story
            'Mother
            If moth.Address_ID.HasValue Then
                mapper.Moth_Add_CellPhone = moth.Address.Cell_Phone
                mapper.Moth_Add_City = moth.Address.City
                mapper.Moth_Add_Country = moth.Address.Country
                mapper.Moth_Add_Email = moth.Address.Email
                mapper.Moth_Add_Facebook = moth.Address.Facebook
                mapper.Moth_Add_Fax = moth.Address.Fax
                mapper.Moth_Add_HomePhone = moth.Address.Home_Phone
                mapper.Moth_Add_Street = moth.Address.Street
                mapper.Moth_Add_Town = moth.Address.Town
                mapper.Moth_Add_Twitter = moth.Address.Twitter
                mapper.Moth_Add_WorkPhone = moth.Address.Work_Phone
            End If
            mapper.Moth_Birthday = moth.Birthday.ToString(My.Settings.GeneralDateFormat)
            If moth.Dieday.HasValue Then
                mapper.Moth_Dieday = moth.Dieday.Value
            End If
            mapper.Moth_EFatherName = moth.Name.EFather
            mapper.Moth_EFirstName = moth.Name.EName
            mapper.Moth_ELastName = moth.Name.ELast
            mapper.Moth_FatherName = moth.Name.Father
            mapper.Moth_FirstName = moth.Name.First
            mapper.Moth_HusbendName = moth.Husband_Name
            If moth.IdntityCard_ID.HasValue Then
                mapper.Moth_IdentityNumber = CStr(moth.IdntityCard_ID.Value)
            End If
            mapper.Moth_IdentityPhoto1 = moth.IdentityCard_Photo.ToImage()
            mapper.Moth_IdentityPhoto2 = moth.IdentityCard_Photo2.ToImage()
            mapper.Moth_IsDead = moth.IsDead
            mapper.Moth_IsMarried = moth.IsMarried
            mapper.Moth_IsOwnOrphans = moth.IsOwnOrphans
            mapper.Moth_Jop = moth.Jop
            mapper.Moth_LastName = moth.Name.Last
            mapper.Moth_Note = moth.Note
            If moth.Salary.HasValue Then
                mapper.Moth_Salary = moth.Salary.Value
            End If
            mapper.Moth_Story = moth.Story
            'BondsMan
            Dim q = From ors In odb.Orphans Where ors.Family_ID = _Fam_ID Select ors
            Dim BondsIds As New ArrayList
            Dim BondsMansArr As New ArrayList
            Dim BondsXML As New ArrayList
            Dim OrphansXML As New ArrayList
            For Each orp In q
                If Not BondsIds.Contains(orp.BondsMan_ID) Then
                    BondsIds.Add(orp.BondsMan_ID)
                    BondsMansArr.Add(orp.BondsMan)
                End If
            Next
            For Each bo As BondsMan In BondsMansArr
                Dim BoID As Integer = bo.ID
                q = From ors In odb.Orphans Where ors.BondsMan_ID = BoID Select ors
                Dim bondsX As New FileCreation.XmlBuilder.BondsMan
                If bo.Address_ID.HasValue Then
                    bondsX.Bo_Add_CellPhone = bo.Address.Cell_Phone
                    bondsX.Bo_Add_City = bo.Address.City
                    bondsX.Bo_Add_Country = bo.Address.Country
                    bondsX.Bo_Add_Email = bo.Address.Email
                    bondsX.Bo_Add_Facebook = bo.Address.Facebook
                    bondsX.Bo_Add_Fax = bo.Address.Fax
                    bondsX.Bo_Add_HomePhone = bo.Address.Home_Phone
                    bondsX.Bo_Add_Street = bo.Address.Street
                    bondsX.Bo_Add_Town = bo.Address.Town
                    bondsX.Bo_Add_Twitter = bo.Address.Twitter
                    bondsX.Bo_Add_WorkPhone = bo.Address.Work_Phone
                End If
                bondsX.Bo_EFatherName = bo.Name.EFather
                bondsX.Bo_EFirstName = bo.Name.EName
                bondsX.Bo_ELastName = bo.Name.ELast
                bondsX.Bo_FatherName = bo.Name.Father
                bondsX.Bo_FingerPrint = bo.FingerPrint.ToImage()
                bondsX.Bo_FirstName = bo.Name.First
                If bo.IdentityCard_ID.HasValue Then
                    bondsX.Bo_IdentityNumber = CStr(bo.IdentityCard_ID.Value)
                End If
                bondsX.Bo_IdentityPhoto1 = bo.IdentityCard_Photo.ToImage()
                bondsX.Bo_IdentityPhoto2 = bo.IdentityCard_Photo2.ToImage()
                If bo.Income.HasValue Then
                    bondsX.Bo_Income = CStr(bo.Income.Value)
                End If
                bondsX.Bo_Jop = bo.Jop
                bondsX.Bo_LastName = bo.Name.Last
                bondsX.Bo_Note = bo.Note
                OrphansXML.Clear()
                For Each orph In q
                    Dim OrphanX As New FileCreation.XmlBuilder.Orphan
                    OrphanX.BirthCertificate = orph.BirthCertificate_Photo.ToImage()
                    OrphanX.Birthday = orph.Birthday
                    OrphanX.Birthplace = orph.BirthPlace
                    OrphanX.BondManRelation = orph.BondsManRelationship
                    If orph.Education_ID.HasValue Then
                        OrphanX.EducationCerPhoto1 = orph.Study.Certificate_Photo1.ToImage()
                        OrphanX.EducationCerPhoto2 = orph.Study.Certificate_Photo2.ToImage()
                        If orph.Study.DegreesRate.HasValue Then
                            OrphanX.EducationDegreesRate = CInt(orph.Study.DegreesRate.Value)
                        End If
                        If orph.Study.MonthlyCost.HasValue Then
                            OrphanX.EducationMonthlyCost = orph.Study.MonthlyCost.Value
                        End If
                        OrphanX.EducationNote = orph.Study.Note
                        OrphanX.EducationReasons = orph.Study.Resons
                        OrphanX.EducationSchool = orph.Study.School
                        OrphanX.EducationStage = orph.Study.Stage
                    End If
                    OrphanX.EFatherName = orph.Name.EFather
                    OrphanX.EFirstName = orph.Name.EName
                    OrphanX.ELastName = orph.Name.ELast
                    OrphanX.FatherName = orph.Name.Father
                    OrphanX.FirstName = orph.Name.First
                    OrphanX.LastName = orph.Name.Last
                    OrphanX.FacePhoto = orph.FacePhoto.ToImage()
                    OrphanX.FingerPrint = orph.FingerPrint.ToImage()
                    If orph.FootSize.HasValue Then
                        OrphanX.FootSiye = orph.FootSize.Value
                    End If
                    OrphanX.FullPhoto = orph.FullPhoto.ToImage()
                    OrphanX.Gender = orph.Gender
                    OrphanX.IsSick = orph.Health_ID.HasValue
                    If OrphanX.IsSick Then
                        If orph.Healthy.Cost.HasValue Then
                            OrphanX.HealthCost = orph.Healthy.Cost.Value
                        End If
                        OrphanX.HealthDoctor = orph.Healthy.SupervisorDoctor
                        OrphanX.HealthMedicen = orph.Healthy.Medicen
                        OrphanX.HealthName = orph.Healthy.Name
                        OrphanX.HealthNote = orph.Healthy.Note
                        OrphanX.HealthReportFile = orph.Healthy.ReporteFile.ToImage()
                    End If
                    If orph.IdentityNumber.HasValue Then
                        OrphanX.IdentityNumber = CStr(orph.IdentityNumber.Value)
                    End If
                    If orph.Kaid.HasValue Then
                        OrphanX.Kaid = orph.Kaid.Value
                    End If
                    OrphanX.Story = orph.Story
                    If orph.Tallness.HasValue Then
                        OrphanX.Tallness = orph.Tallness.Value
                    End If
                    If orph.Weight.HasValue Then
                        OrphanX.Weight = orph.Weight.Value
                    End If
                    OrphansXML.Add(OrphanX)
                Next
                bondsX.Orphans = CType(OrphansXML.ToArray(GetType(FileCreation.XmlBuilder.Orphan)), FileCreation.XmlBuilder.Orphan())
                BondsXML.Add(bondsX)
            Next
            mapper.BondsManS = CType(BondsXML.ToArray(GetType(FileCreation.XmlBuilder.BondsMan)), FileCreation.XmlBuilder.BondsMan())

            Dim CrF As New FileCreation.BinaryFile()
            CrF.FileName = _FileName
            CrF.Overwite = True
            CrF.UseCrypto = True
            Dim StrXml() As Byte = mapper.BuildFamily()
            CrF.Create(StrXml)
        Catch
            Return False
        End Try
        Return True
    End Function
    Public Function CreateFamilyFile(ByVal _Fam_ID As Integer, ByVal FolderName As String, ByVal UseFatherN As Boolean) As Boolean
        If _Fam_ID <= 0 Then Return False
        Try
            Dim fam As OrphanageClasses.Family = Getter.GetFamilyByID(_Fam_ID, odb)
            Dim fath As Father = fam.Father
            Dim moth As Mother = fam.Mother
            If Not FolderName.EndsWith("\") Then
                FolderName += "\"
            End If
            If IsNothing(fam) Then Return False
            Dim mapper As New FileCreation.XmlBuilder()
            If fam.Address_ID2.HasValue Then
                mapper.Fam_Add_CellPhone2 = fam.Address1.Cell_Phone
                mapper.Fam_Add_City2 = fam.Address1.City
                mapper.Fam_Add_Country2 = fam.Address1.Country
                mapper.Fam_Add_Email2 = fam.Address1.Email
                mapper.Fam_Add_Facebook2 = fam.Address1.Facebook
                mapper.Fam_Add_Fax2 = fam.Address1.Fax
                mapper.Fam_Add_HomePhone2 = fam.Address1.Home_Phone
                mapper.Fam_Add_Street2 = fam.Address1.Street
                mapper.Fam_Add_Town2 = fam.Address1.Town
                mapper.Fam_Add_Twitter2 = fam.Address1.Twitter
                mapper.Fam_Add_WorkPhone2 = fam.Address1.Work_Phone
            End If
            If fam.Address_ID.HasValue Then
                mapper.Fam_Add_CellPhone = fam.Address.Cell_Phone
                mapper.Fam_Add_City = fam.Address.City
                mapper.Fam_Add_Country = fam.Address.Country
                mapper.Fam_Add_Email = fam.Address.Email
                mapper.Fam_Add_Facebook = fam.Address.Facebook
                mapper.Fam_Add_Fax = fam.Address.Fax
                mapper.Fam_Add_HomePhone = fam.Address.Home_Phone
                mapper.Fam_Add_Street = fam.Address.Street
                mapper.Fam_Add_Town = fam.Address.Town
                mapper.Fam_Add_Twitter = fam.Address.Twitter
                mapper.Fam_Add_WorkPhone = fam.Address.Work_Phone
            End If
            mapper.Fam_CardNumber = fam.FamilyCard_Num
            mapper.Fam_CardPhoto1 = fam.FamilyCardPhoto.ToImage
            mapper.Fam_CardPhoto2 = fam.FamilyCardPhotoP2.ToImage
            mapper.Fam_Finncial_State = fam.Finncial_Sate
            mapper.Fam_IsRefugee = fam.IsRefugee
            mapper.Fam_Note = fam.Note
            mapper.Fam_Residence_State = fam.Residece_Sate
            mapper.Fam_Residence_Type = fam.Residenc_Type
            'Father
            mapper.Fath_Birthday = fath.Birthday
            mapper.Fath_DeathCertificate = fath.DeathCertificate_Photo.ToImage
            mapper.Fath_DeathResone = fath.DeathResone
            mapper.Fath_Dieday = fath.Dieday
            mapper.Fath_EFatherName = fath.Name.EFather
            mapper.Fath_EFirstName = fath.Name.EName
            mapper.Fath_ELastName = fath.Name.ELast
            mapper.Fath_FatherName = fath.Name.Father
            mapper.Fath_FirstName = fath.Name.First
            mapper.Fath_IdentityNumber = CStr(fath.IdentityCard_ID)
            mapper.Fath_Jop = fath.Jop
            mapper.Fath_LastName = fath.Name.Last
            mapper.Fath_Note = fath.Note
            mapper.Fath_Photo = fath.Photo.ToImage()
            mapper.Fath_Story = fath.Story
            'Mother
            If moth.Address_ID.HasValue Then
                mapper.Moth_Add_CellPhone = moth.Address.Cell_Phone
                mapper.Moth_Add_City = moth.Address.City
                mapper.Moth_Add_Country = moth.Address.Country
                mapper.Moth_Add_Email = moth.Address.Email
                mapper.Moth_Add_Facebook = moth.Address.Facebook
                mapper.Moth_Add_Fax = moth.Address.Fax
                mapper.Moth_Add_HomePhone = moth.Address.Home_Phone
                mapper.Moth_Add_Street = moth.Address.Street
                mapper.Moth_Add_Town = moth.Address.Town
                mapper.Moth_Add_Twitter = moth.Address.Twitter
                mapper.Moth_Add_WorkPhone = moth.Address.Work_Phone
            End If
            mapper.Moth_Birthday = moth.Birthday.ToString(My.Settings.GeneralDateFormat)
            If moth.Dieday.HasValue Then
                mapper.Moth_Dieday = moth.Dieday.Value
            End If
            mapper.Moth_EFatherName = moth.Name.EFather
            mapper.Moth_EFirstName = moth.Name.EName
            mapper.Moth_ELastName = moth.Name.ELast
            mapper.Moth_FatherName = moth.Name.Father
            mapper.Moth_FirstName = moth.Name.First
            mapper.Moth_HusbendName = moth.Husband_Name
            If moth.IdntityCard_ID.HasValue Then
                mapper.Moth_IdentityNumber = CStr(moth.IdntityCard_ID.Value)
            End If
            mapper.Moth_IdentityPhoto1 = moth.IdentityCard_Photo.ToImage()
            mapper.Moth_IdentityPhoto2 = moth.IdentityCard_Photo2.ToImage()
            mapper.Moth_IsDead = moth.IsDead
            mapper.Moth_IsMarried = moth.IsMarried
            mapper.Moth_IsOwnOrphans = moth.IsOwnOrphans
            mapper.Moth_Jop = moth.Jop
            mapper.Moth_LastName = moth.Name.Last
            mapper.Moth_Note = moth.Note
            If moth.Salary.HasValue Then
                mapper.Moth_Salary = moth.Salary.Value
            End If
            mapper.Moth_Story = moth.Story
            'BondsMan
            Dim q = From ors In odb.Orphans Where ors.Family_ID = _Fam_ID Select ors
            Dim BondsIds As New ArrayList
            Dim BondsMansArr As New ArrayList
            Dim BondsXML As New ArrayList
            Dim OrphansXML As New ArrayList
            For Each orp In q
                If Not BondsIds.Contains(orp.BondsMan_ID) Then
                    BondsIds.Add(orp.BondsMan_ID)
                    BondsMansArr.Add(orp.BondsMan)
                End If
            Next
            For Each bo As BondsMan In BondsMansArr
                Dim BoID As Integer = bo.ID
                q = From ors In odb.Orphans Where ors.BondsMan_ID = BoID Select ors
                Dim bondsX As New FileCreation.XmlBuilder.BondsMan
                If bo.Address_ID.HasValue Then
                    bondsX.Bo_Add_CellPhone = bo.Address.Cell_Phone
                    bondsX.Bo_Add_City = bo.Address.City
                    bondsX.Bo_Add_Country = bo.Address.Country
                    bondsX.Bo_Add_Email = bo.Address.Email
                    bondsX.Bo_Add_Facebook = bo.Address.Facebook
                    bondsX.Bo_Add_Fax = bo.Address.Fax
                    bondsX.Bo_Add_HomePhone = bo.Address.Home_Phone
                    bondsX.Bo_Add_Street = bo.Address.Street
                    bondsX.Bo_Add_Town = bo.Address.Town
                    bondsX.Bo_Add_Twitter = bo.Address.Twitter
                    bondsX.Bo_Add_WorkPhone = bo.Address.Work_Phone
                End If
                bondsX.Bo_EFatherName = bo.Name.EFather
                bondsX.Bo_EFirstName = bo.Name.EName
                bondsX.Bo_ELastName = bo.Name.ELast
                bondsX.Bo_FatherName = bo.Name.Father
                bondsX.Bo_FingerPrint = bo.FingerPrint.ToImage()
                bondsX.Bo_FirstName = bo.Name.First
                If bo.IdentityCard_ID.HasValue Then
                    bondsX.Bo_IdentityNumber = CStr(bo.IdentityCard_ID.Value)
                End If
                bondsX.Bo_IdentityPhoto1 = bo.IdentityCard_Photo.ToImage()
                bondsX.Bo_IdentityPhoto2 = bo.IdentityCard_Photo2.ToImage()
                If bo.Income.HasValue Then
                    bondsX.Bo_Income = CStr(bo.Income.Value)
                End If
                bondsX.Bo_Jop = bo.Jop
                bondsX.Bo_LastName = bo.Name.Last
                bondsX.Bo_Note = bo.Note
                OrphansXML.Clear()
                For Each orph In q
                    Dim OrphanX As New FileCreation.XmlBuilder.Orphan
                    OrphanX.BirthCertificate = orph.BirthCertificate_Photo.ToImage()
                    OrphanX.Birthday = orph.Birthday
                    OrphanX.Birthplace = orph.BirthPlace
                    OrphanX.BondManRelation = orph.BondsManRelationship
                    If orph.Education_ID.HasValue Then
                        OrphanX.EducationCerPhoto1 = orph.Study.Certificate_Photo1.ToImage()
                        OrphanX.EducationCerPhoto2 = orph.Study.Certificate_Photo2.ToImage()
                        If orph.Study.DegreesRate.HasValue Then
                            OrphanX.EducationDegreesRate = CInt(orph.Study.DegreesRate.Value)
                        End If
                        If orph.Study.MonthlyCost.HasValue Then
                            OrphanX.EducationMonthlyCost = orph.Study.MonthlyCost.Value
                        End If
                        OrphanX.EducationNote = orph.Study.Note
                        OrphanX.EducationReasons = orph.Study.Resons
                        OrphanX.EducationSchool = orph.Study.School
                        OrphanX.EducationStage = orph.Study.Stage
                    End If
                    OrphanX.EFatherName = orph.Name.EFather
                    OrphanX.EFirstName = orph.Name.EName
                    OrphanX.ELastName = orph.Name.ELast
                    OrphanX.FatherName = orph.Name.Father
                    OrphanX.FirstName = orph.Name.First
                    OrphanX.LastName = orph.Name.Last
                    OrphanX.FacePhoto = orph.FacePhoto.ToImage()
                    OrphanX.FingerPrint = orph.FingerPrint.ToImage()
                    If orph.FootSize.HasValue Then
                        OrphanX.FootSiye = orph.FootSize.Value
                    End If
                    OrphanX.FullPhoto = orph.FullPhoto.ToImage()
                    OrphanX.Gender = orph.Gender
                    OrphanX.IsSick = orph.Health_ID.HasValue
                    If OrphanX.IsSick Then
                        If orph.Healthy.Cost.HasValue Then
                            OrphanX.HealthCost = orph.Healthy.Cost.Value
                        End If
                        OrphanX.HealthDoctor = orph.Healthy.SupervisorDoctor
                        OrphanX.HealthMedicen = orph.Healthy.Medicen
                        OrphanX.HealthName = orph.Healthy.Name
                        OrphanX.HealthNote = orph.Healthy.Note
                        OrphanX.HealthReportFile = orph.Healthy.ReporteFile.ToImage()
                    End If
                    If orph.IdentityNumber.HasValue Then
                        OrphanX.IdentityNumber = CStr(orph.IdentityNumber.Value)
                    End If
                    If orph.Kaid.HasValue Then
                        OrphanX.Kaid = orph.Kaid.Value
                    End If
                    OrphanX.Story = orph.Story
                    If orph.Tallness.HasValue Then
                        OrphanX.Tallness = orph.Tallness.Value
                    End If
                    If orph.Weight.HasValue Then
                        OrphanX.Weight = orph.Weight.Value
                    End If
                    OrphansXML.Add(OrphanX)
                Next
                bondsX.Orphans = CType(OrphansXML.ToArray(GetType(FileCreation.XmlBuilder.Orphan)), FileCreation.XmlBuilder.Orphan())
                BondsXML.Add(bondsX)
            Next
            mapper.BondsManS = CType(BondsXML.ToArray(GetType(FileCreation.XmlBuilder.BondsMan)), FileCreation.XmlBuilder.BondsMan())

            Dim CrF As New FileCreation.BinaryFile()
            If UseFatherN Then
                Dim filn As String = FolderName + Getter.GetFullName(fath.Name) + " و " + _
                    Getter.GetFullName(moth.Name) + ".Fam"
                If File.Exists(filn) Then
                    filn = filn.Replace(".Fam", "")
                    filn += fam.ID.ToString() + ".Fam"
                End If
                CrF.FileName = filn
            End If
            CrF.Overwite = True
            CrF.UseCrypto = True
            Dim StrXml() As Byte = mapper.BuildFamily()
            CrF.Create(StrXml)
        Catch
            Return False
        End Try
        Return True
    End Function
    Public Function CreateOrphanFile(ByVal _Orph_ID As Integer, ByVal FolderName As String, ByVal UseFatherN As Boolean) As Boolean
        If _Orph_ID <= 0 Then Return False
        Try
            Using Odb As New OrphanageDB.Odb
                Dim Orph As Orphan = Getter.GetOrphanByID(_Orph_ID, Odb)
                If IsNothing(Orph) Then Return False
                Dim _Fam_ID As Integer = Orph.Family_ID
                Dim fam As OrphanageClasses.Family = Getter.GetFamilyByID(_Fam_ID, Odb)
                Dim fath As Father = fam.Father
                Dim moth As Mother = fam.Mother
                Dim Bo As BondsMan = Orph.BondsMan
                If Not FolderName.EndsWith("\") Then
                    FolderName += "\"
                End If
                If IsNothing(fam) Then Return False
                Dim mapper As New FileCreation.XmlBuilder()
                If fam.Address_ID2.HasValue Then
                    mapper.Fam_Add_CellPhone2 = fam.Address1.Cell_Phone
                    mapper.Fam_Add_City2 = fam.Address1.City
                    mapper.Fam_Add_Country2 = fam.Address1.Country
                    mapper.Fam_Add_Email2 = fam.Address1.Email
                    mapper.Fam_Add_Facebook2 = fam.Address1.Facebook
                    mapper.Fam_Add_Fax2 = fam.Address1.Fax
                    mapper.Fam_Add_HomePhone2 = fam.Address1.Home_Phone
                    mapper.Fam_Add_Street2 = fam.Address1.Street
                    mapper.Fam_Add_Town2 = fam.Address1.Town
                    mapper.Fam_Add_Twitter2 = fam.Address1.Twitter
                    mapper.Fam_Add_WorkPhone2 = fam.Address1.Work_Phone
                End If
                If fam.Address_ID.HasValue Then
                    mapper.Fam_Add_CellPhone = fam.Address.Cell_Phone
                    mapper.Fam_Add_City = fam.Address.City
                    mapper.Fam_Add_Country = fam.Address.Country
                    mapper.Fam_Add_Email = fam.Address.Email
                    mapper.Fam_Add_Facebook = fam.Address.Facebook
                    mapper.Fam_Add_Fax = fam.Address.Fax
                    mapper.Fam_Add_HomePhone = fam.Address.Home_Phone
                    mapper.Fam_Add_Street = fam.Address.Street
                    mapper.Fam_Add_Town = fam.Address.Town
                    mapper.Fam_Add_Twitter = fam.Address.Twitter
                    mapper.Fam_Add_WorkPhone = fam.Address.Work_Phone
                End If
                mapper.Fam_CardNumber = fam.FamilyCard_Num
                mapper.Fam_CardPhoto1 = fam.FamilyCardPhoto.ToImage
                mapper.Fam_CardPhoto2 = fam.FamilyCardPhotoP2.ToImage
                mapper.Fam_Finncial_State = fam.Finncial_Sate
                mapper.Fam_IsRefugee = fam.IsRefugee
                mapper.Fam_Note = fam.Note
                mapper.Fam_Residence_State = fam.Residece_Sate
                mapper.Fam_Residence_Type = fam.Residenc_Type
                'Father
                mapper.Fath_Birthday = fath.Birthday
                mapper.Fath_DeathCertificate = fath.DeathCertificate_Photo.ToImage
                mapper.Fath_DeathResone = fath.DeathResone
                mapper.Fath_Dieday = fath.Dieday
                mapper.Fath_EFatherName = fath.Name.EFather
                mapper.Fath_EFirstName = fath.Name.EName
                mapper.Fath_ELastName = fath.Name.ELast
                mapper.Fath_FatherName = fath.Name.Father
                mapper.Fath_FirstName = fath.Name.First
                mapper.Fath_IdentityNumber = fath.IdentityCard_ID.ToString
                mapper.Fath_Jop = fath.Jop
                mapper.Fath_LastName = fath.Name.Last
                mapper.Fath_Note = fath.Note
                mapper.Fath_Photo = fath.Photo.ToImage()
                mapper.Fath_Story = fath.Story
                'Mother
                If moth.Address_ID.HasValue Then
                    mapper.Moth_Add_CellPhone = moth.Address.Cell_Phone
                    mapper.Moth_Add_City = moth.Address.City
                    mapper.Moth_Add_Country = moth.Address.Country
                    mapper.Moth_Add_Email = moth.Address.Email
                    mapper.Moth_Add_Facebook = moth.Address.Facebook
                    mapper.Moth_Add_Fax = moth.Address.Fax
                    mapper.Moth_Add_HomePhone = moth.Address.Home_Phone
                    mapper.Moth_Add_Street = moth.Address.Street
                    mapper.Moth_Add_Town = moth.Address.Town
                    mapper.Moth_Add_Twitter = moth.Address.Twitter
                    mapper.Moth_Add_WorkPhone = moth.Address.Work_Phone
                End If
                mapper.Moth_Birthday = moth.Birthday.ToString(My.Settings.GeneralDateFormat)
                If moth.Dieday.HasValue Then
                    mapper.Moth_Dieday = moth.Dieday.Value
                End If
                mapper.Moth_EFatherName = moth.Name.EFather
                mapper.Moth_EFirstName = moth.Name.EName
                mapper.Moth_ELastName = moth.Name.ELast
                mapper.Moth_FatherName = moth.Name.Father
                mapper.Moth_FirstName = moth.Name.First
                mapper.Moth_HusbendName = moth.Husband_Name
                If moth.IdntityCard_ID.HasValue Then
                    mapper.Moth_IdentityNumber = CStr(moth.IdntityCard_ID.Value)
                End If
                mapper.Moth_IdentityPhoto1 = moth.IdentityCard_Photo.ToImage()
                mapper.Moth_IdentityPhoto2 = moth.IdentityCard_Photo2.ToImage()
                mapper.Moth_IsDead = moth.IsDead
                mapper.Moth_IsMarried = moth.IsMarried
                mapper.Moth_IsOwnOrphans = moth.IsOwnOrphans
                mapper.Moth_Jop = moth.Jop
                mapper.Moth_LastName = moth.Name.Last
                mapper.Moth_Note = moth.Note
                If moth.Salary.HasValue Then
                    mapper.Moth_Salary = moth.Salary.Value
                End If
                mapper.Moth_Story = moth.Story
                'BondsMan
                Dim bondsX As New FileCreation.XmlBuilder.BondsMan
                Dim OrphanX As New FileCreation.XmlBuilder.Orphan
                If Bo.Address_ID.HasValue Then
                    bondsX.Bo_Add_CellPhone = Bo.Address.Cell_Phone
                    bondsX.Bo_Add_City = Bo.Address.City
                    bondsX.Bo_Add_Country = Bo.Address.Country
                    bondsX.Bo_Add_Email = Bo.Address.Email
                    bondsX.Bo_Add_Facebook = Bo.Address.Facebook
                    bondsX.Bo_Add_Fax = Bo.Address.Fax
                    bondsX.Bo_Add_HomePhone = Bo.Address.Home_Phone
                    bondsX.Bo_Add_Street = Bo.Address.Street
                    bondsX.Bo_Add_Town = Bo.Address.Town
                    bondsX.Bo_Add_Twitter = Bo.Address.Twitter
                    bondsX.Bo_Add_WorkPhone = Bo.Address.Work_Phone
                End If
                bondsX.Bo_EFatherName = Bo.Name.EFather
                bondsX.Bo_EFirstName = Bo.Name.EName
                bondsX.Bo_ELastName = Bo.Name.ELast
                bondsX.Bo_FatherName = Bo.Name.Father
                bondsX.Bo_FingerPrint = Bo.FingerPrint.ToImage()
                bondsX.Bo_FirstName = Bo.Name.First
                If Bo.IdentityCard_ID.HasValue Then
                    bondsX.Bo_IdentityNumber = CStr(Bo.IdentityCard_ID.Value)
                End If
                bondsX.Bo_IdentityPhoto1 = Bo.IdentityCard_Photo.ToImage()
                bondsX.Bo_IdentityPhoto2 = Bo.IdentityCard_Photo2.ToImage()
                If Bo.Income.HasValue Then
                    bondsX.Bo_Income = CStr(Bo.Income.Value)
                End If
                bondsX.Bo_Jop = Bo.Jop
                bondsX.Bo_LastName = Bo.Name.Last
                bondsX.Bo_Note = Bo.Note


                OrphanX.BirthCertificate = Orph.BirthCertificate_Photo.ToImage()
                OrphanX.Birthday = Orph.Birthday
                OrphanX.Birthplace = Orph.BirthPlace
                OrphanX.BondManRelation = Orph.BondsManRelationship
                If Orph.Education_ID.HasValue Then
                    OrphanX.EducationCerPhoto1 = Orph.Study.Certificate_Photo1.ToImage()
                    OrphanX.EducationCerPhoto2 = Orph.Study.Certificate_Photo2.ToImage()
                    If Orph.Study.DegreesRate.HasValue Then
                        OrphanX.EducationDegreesRate = CInt(Orph.Study.DegreesRate.Value)
                    End If
                    If Orph.Study.MonthlyCost.HasValue Then
                        OrphanX.EducationMonthlyCost = Orph.Study.MonthlyCost.Value
                    End If
                    OrphanX.EducationNote = Orph.Study.Note
                    OrphanX.EducationReasons = Orph.Study.Resons
                    OrphanX.EducationSchool = Orph.Study.School
                    OrphanX.EducationStage = Orph.Study.Stage
                End If
                OrphanX.EFatherName = Orph.Name.EFather
                OrphanX.EFirstName = Orph.Name.EName
                OrphanX.ELastName = Orph.Name.ELast
                OrphanX.FatherName = Orph.Name.Father
                OrphanX.FirstName = Orph.Name.First
                OrphanX.LastName = Orph.Name.Last
                OrphanX.FacePhoto = Orph.FacePhoto.ToImage()
                OrphanX.FingerPrint = Orph.FingerPrint.ToImage()
                If Orph.FootSize.HasValue Then
                    OrphanX.FootSiye = Orph.FootSize.Value
                End If
                OrphanX.FullPhoto = Orph.FullPhoto.ToImage()
                OrphanX.Gender = Orph.Gender
                OrphanX.IsSick = Orph.Health_ID.HasValue
                If OrphanX.IsSick Then
                    If Orph.Healthy.Cost.HasValue Then
                        OrphanX.HealthCost = Orph.Healthy.Cost.Value
                    End If
                    OrphanX.HealthDoctor = Orph.Healthy.SupervisorDoctor
                    OrphanX.HealthMedicen = Orph.Healthy.Medicen
                    OrphanX.HealthName = Orph.Healthy.Name
                    OrphanX.HealthNote = Orph.Healthy.Note
                    OrphanX.HealthReportFile = Orph.Healthy.ReporteFile.ToImage()
                End If
                If Orph.IdentityNumber.HasValue Then
                    OrphanX.IdentityNumber = CStr(Orph.IdentityNumber.Value)
                End If
                If Orph.Kaid.HasValue Then
                    OrphanX.Kaid = Orph.Kaid.Value
                End If
                OrphanX.Story = Orph.Story
                If Orph.Tallness.HasValue Then
                    OrphanX.Tallness = Orph.Tallness.Value
                End If
                If Orph.Weight.HasValue Then
                    OrphanX.Weight = Orph.Weight.Value
                End If
                bondsX.Orphans = New FileCreation.XmlBuilder.Orphan() {OrphanX}
                mapper.BondsManS = New FileCreation.XmlBuilder.BondsMan() {bondsX}
                Dim CrF As New FileCreation.BinaryFile()
                If UseFatherN Then
                    Dim filn As String = FolderName + Getter.GetFullName(Orph.Name) + ".Fam"
                    If File.Exists(filn) Then
                        filn = filn.Replace(".Fam", "")
                        filn += Orph.ID.ToString + ".Fam"
                    End If
                    CrF.FileName = filn
                End If
                CrF.Overwite = True
                CrF.UseCrypto = True
                Dim StrXml() As Byte = mapper.BuildFamily()
                CrF.Create(StrXml)
                Odb.Dispose()
            End Using
        Catch
            Return False
        End Try
        Return True
    End Function
    Public Function CreateOrphanFile(ByVal _Orph_ID As Integer) As Boolean
        If _Orph_ID <= 0 Then Return False
        Try
            Using Odb As New OrphanageDB.Odb
                Dim Orph As Orphan = Getter.GetOrphanByID(_Orph_ID, Odb)
                If IsNothing(Orph) Then Return False
                Dim _Fam_ID As Integer = Orph.Family_ID
                Dim fam As OrphanageClasses.Family = Getter.GetFamilyByID(_Fam_ID, Odb)
                Dim fath As Father = fam.Father
                Dim moth As Mother = fam.Mother
                Dim Bo As BondsMan = Orph.BondsMan
                If IsNothing(fam) Then Return False
                Dim mapper As New FileCreation.XmlBuilder()
                If fam.Address_ID2.HasValue Then
                    mapper.Fam_Add_CellPhone2 = fam.Address1.Cell_Phone
                    mapper.Fam_Add_City2 = fam.Address1.City
                    mapper.Fam_Add_Country2 = fam.Address1.Country
                    mapper.Fam_Add_Email2 = fam.Address1.Email
                    mapper.Fam_Add_Facebook2 = fam.Address1.Facebook
                    mapper.Fam_Add_Fax2 = fam.Address1.Fax
                    mapper.Fam_Add_HomePhone2 = fam.Address1.Home_Phone
                    mapper.Fam_Add_Street2 = fam.Address1.Street
                    mapper.Fam_Add_Town2 = fam.Address1.Town
                    mapper.Fam_Add_Twitter2 = fam.Address1.Twitter
                    mapper.Fam_Add_WorkPhone2 = fam.Address1.Work_Phone
                End If
                If fam.Address_ID.HasValue Then
                    mapper.Fam_Add_CellPhone = fam.Address.Cell_Phone
                    mapper.Fam_Add_City = fam.Address.City
                    mapper.Fam_Add_Country = fam.Address.Country
                    mapper.Fam_Add_Email = fam.Address.Email
                    mapper.Fam_Add_Facebook = fam.Address.Facebook
                    mapper.Fam_Add_Fax = fam.Address.Fax
                    mapper.Fam_Add_HomePhone = fam.Address.Home_Phone
                    mapper.Fam_Add_Street = fam.Address.Street
                    mapper.Fam_Add_Town = fam.Address.Town
                    mapper.Fam_Add_Twitter = fam.Address.Twitter
                    mapper.Fam_Add_WorkPhone = fam.Address.Work_Phone
                End If
                mapper.Fam_CardNumber = fam.FamilyCard_Num
                mapper.Fam_CardPhoto1 = fam.FamilyCardPhoto.ToImage
                mapper.Fam_CardPhoto2 = fam.FamilyCardPhotoP2.ToImage
                mapper.Fam_Finncial_State = fam.Finncial_Sate
                mapper.Fam_IsRefugee = fam.IsRefugee
                mapper.Fam_Note = fam.Note
                mapper.Fam_Residence_State = fam.Residece_Sate
                mapper.Fam_Residence_Type = fam.Residenc_Type
                'Father
                mapper.Fath_Birthday = fath.Birthday
                mapper.Fath_DeathCertificate = fath.DeathCertificate_Photo.ToImage
                mapper.Fath_DeathResone = fath.DeathResone
                mapper.Fath_Dieday = fath.Dieday
                mapper.Fath_EFatherName = fath.Name.EFather
                mapper.Fath_EFirstName = fath.Name.EName
                mapper.Fath_ELastName = fath.Name.ELast
                mapper.Fath_FatherName = fath.Name.Father
                mapper.Fath_FirstName = fath.Name.First
                mapper.Fath_IdentityNumber = fath.IdentityCard_ID.ToString
                mapper.Fath_Jop = fath.Jop
                mapper.Fath_LastName = fath.Name.Last
                mapper.Fath_Note = fath.Note
                mapper.Fath_Photo = fath.Photo.ToImage()
                mapper.Fath_Story = fath.Story
                'Mother
                If moth.Address_ID.HasValue Then
                    mapper.Moth_Add_CellPhone = moth.Address.Cell_Phone
                    mapper.Moth_Add_City = moth.Address.City
                    mapper.Moth_Add_Country = moth.Address.Country
                    mapper.Moth_Add_Email = moth.Address.Email
                    mapper.Moth_Add_Facebook = moth.Address.Facebook
                    mapper.Moth_Add_Fax = moth.Address.Fax
                    mapper.Moth_Add_HomePhone = moth.Address.Home_Phone
                    mapper.Moth_Add_Street = moth.Address.Street
                    mapper.Moth_Add_Town = moth.Address.Town
                    mapper.Moth_Add_Twitter = moth.Address.Twitter
                    mapper.Moth_Add_WorkPhone = moth.Address.Work_Phone
                End If
                mapper.Moth_Birthday = moth.Birthday.ToString(My.Settings.GeneralDateFormat)
                If moth.Dieday.HasValue Then
                    mapper.Moth_Dieday = moth.Dieday.Value
                End If
                mapper.Moth_EFatherName = moth.Name.EFather
                mapper.Moth_EFirstName = moth.Name.EName
                mapper.Moth_ELastName = moth.Name.ELast
                mapper.Moth_FatherName = moth.Name.Father
                mapper.Moth_FirstName = moth.Name.First
                mapper.Moth_HusbendName = moth.Husband_Name
                If moth.IdntityCard_ID.HasValue Then
                    mapper.Moth_IdentityNumber = CStr(moth.IdntityCard_ID.Value)
                End If
                mapper.Moth_IdentityPhoto1 = moth.IdentityCard_Photo.ToImage()
                mapper.Moth_IdentityPhoto2 = moth.IdentityCard_Photo2.ToImage()
                mapper.Moth_IsDead = moth.IsDead
                mapper.Moth_IsMarried = moth.IsMarried
                mapper.Moth_IsOwnOrphans = moth.IsOwnOrphans
                mapper.Moth_Jop = moth.Jop
                mapper.Moth_LastName = moth.Name.Last
                mapper.Moth_Note = moth.Note
                If moth.Salary.HasValue Then
                    mapper.Moth_Salary = moth.Salary.Value
                End If
                mapper.Moth_Story = moth.Story
                'BondsMan
                Dim bondsX As New FileCreation.XmlBuilder.BondsMan
                Dim OrphanX As New FileCreation.XmlBuilder.Orphan
                If Bo.Address_ID.HasValue Then
                    bondsX.Bo_Add_CellPhone = Bo.Address.Cell_Phone
                    bondsX.Bo_Add_City = Bo.Address.City
                    bondsX.Bo_Add_Country = Bo.Address.Country
                    bondsX.Bo_Add_Email = Bo.Address.Email
                    bondsX.Bo_Add_Facebook = Bo.Address.Facebook
                    bondsX.Bo_Add_Fax = Bo.Address.Fax
                    bondsX.Bo_Add_HomePhone = Bo.Address.Home_Phone
                    bondsX.Bo_Add_Street = Bo.Address.Street
                    bondsX.Bo_Add_Town = Bo.Address.Town
                    bondsX.Bo_Add_Twitter = Bo.Address.Twitter
                    bondsX.Bo_Add_WorkPhone = Bo.Address.Work_Phone
                End If
                bondsX.Bo_EFatherName = Bo.Name.EFather
                bondsX.Bo_EFirstName = Bo.Name.EName
                bondsX.Bo_ELastName = Bo.Name.ELast
                bondsX.Bo_FatherName = Bo.Name.Father
                bondsX.Bo_FingerPrint = Bo.FingerPrint.ToImage()
                bondsX.Bo_FirstName = Bo.Name.First
                If Bo.IdentityCard_ID.HasValue Then
                    bondsX.Bo_IdentityNumber = CStr(Bo.IdentityCard_ID.Value)
                End If
                bondsX.Bo_IdentityPhoto1 = Bo.IdentityCard_Photo.ToImage()
                bondsX.Bo_IdentityPhoto2 = Bo.IdentityCard_Photo2.ToImage()
                If Bo.Income.HasValue Then
                    bondsX.Bo_Income = CStr(Bo.Income.Value)
                End If
                bondsX.Bo_Jop = Bo.Jop
                bondsX.Bo_LastName = Bo.Name.Last
                bondsX.Bo_Note = Bo.Note


                OrphanX.BirthCertificate = Orph.BirthCertificate_Photo.ToImage()
                OrphanX.Birthday = Orph.Birthday
                OrphanX.Birthplace = Orph.BirthPlace
                OrphanX.BondManRelation = Orph.BondsManRelationship
                If Orph.Education_ID.HasValue Then
                    OrphanX.EducationCerPhoto1 = Orph.Study.Certificate_Photo1.ToImage()
                    OrphanX.EducationCerPhoto2 = Orph.Study.Certificate_Photo2.ToImage()
                    If Orph.Study.DegreesRate.HasValue Then
                        OrphanX.EducationDegreesRate = CInt(Orph.Study.DegreesRate.Value)
                    End If
                    If Orph.Study.MonthlyCost.HasValue Then
                        OrphanX.EducationMonthlyCost = Orph.Study.MonthlyCost.Value
                    End If
                    OrphanX.EducationNote = Orph.Study.Note
                    OrphanX.EducationReasons = Orph.Study.Resons
                    OrphanX.EducationSchool = Orph.Study.School
                    OrphanX.EducationStage = Orph.Study.Stage
                End If
                OrphanX.EFatherName = Orph.Name.EFather
                OrphanX.EFirstName = Orph.Name.EName
                OrphanX.ELastName = Orph.Name.ELast
                OrphanX.FatherName = Orph.Name.Father
                OrphanX.FirstName = Orph.Name.First
                OrphanX.LastName = Orph.Name.Last
                OrphanX.FacePhoto = Orph.FacePhoto.ToImage()
                OrphanX.FingerPrint = Orph.FingerPrint.ToImage()
                If Orph.FootSize.HasValue Then
                    OrphanX.FootSiye = Orph.FootSize.Value
                End If
                OrphanX.FullPhoto = Orph.FullPhoto.ToImage()
                OrphanX.Gender = Orph.Gender
                OrphanX.IsSick = Orph.Health_ID.HasValue
                If OrphanX.IsSick Then
                    If Orph.Healthy.Cost.HasValue Then
                        OrphanX.HealthCost = Orph.Healthy.Cost.Value
                    End If
                    OrphanX.HealthDoctor = Orph.Healthy.SupervisorDoctor
                    OrphanX.HealthMedicen = Orph.Healthy.Medicen
                    OrphanX.HealthName = Orph.Healthy.Name
                    OrphanX.HealthNote = Orph.Healthy.Note
                    OrphanX.HealthReportFile = Orph.Healthy.ReporteFile.ToImage()
                End If
                If Orph.IdentityNumber.HasValue Then
                    OrphanX.IdentityNumber = CStr(Orph.IdentityNumber.Value)
                End If
                If Orph.Kaid.HasValue Then
                    OrphanX.Kaid = Orph.Kaid.Value
                End If
                OrphanX.Story = Orph.Story
                If Orph.Tallness.HasValue Then
                    OrphanX.Tallness = Orph.Tallness.Value
                End If
                If Orph.Weight.HasValue Then
                    OrphanX.Weight = Orph.Weight.Value
                End If
                bondsX.Orphans = New FileCreation.XmlBuilder.Orphan() {OrphanX}
                mapper.BondsManS = New FileCreation.XmlBuilder.BondsMan() {bondsX}
                Dim CrF As New FileCreation.BinaryFile()
                CrF.FileName = _FileName
                CrF.Overwite = True
                CrF.UseCrypto = True
                Dim StrXml() As Byte = mapper.BuildFamily()
                CrF.Create(StrXml)
                Odb.Dispose()
            End Using
        Catch
            Return False
        End Try
        Return True
    End Function

    Public Function GetFamilyFile(ByVal filePath As String) As FileCreation.XmlBuilder
        Try
            If IsNothing(filePath) OrElse filePath.Length < 5 Then Return Nothing
            Dim br As New FileCreation.BinaryFile()
            Dim xmlFile As New FileCreation.XmlBuilder()
            br.FileName = filePath
            br.UseCrypto = True
            Dim bts() As Byte = br.ReadAllBytes()
            xmlFile.FromXMLBytes(bts)
            Return xmlFile
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return Nothing
        End Try
    End Function

    Public Function AddFamily(ByVal xmlM As FileCreation.XmlBuilder) As Boolean
        Try
            Using tr = New Transactions.TransactionScope()
                Dim FADD1 As OrphanageClasses.Address = Nothing
                Dim FADD2 As OrphanageClasses.Address = Nothing
                Dim Famclass As New Family
                Dim MAdd As New Address
                Dim MName As New Name
                Dim Mclass As New Mother
                Dim Fclass As Father
                Dim FName As Name
                odb.Dispose()
                odb = New OrphanageDB.Odb()
                ExceptionsManager.RaiseOnStatus(New MyException("إدخال بينات عنوان العائلة"))
                Application.DoEvents()
                If Not IsNothing(xmlM.Fam_Add_Country) AndAlso Not IsNothing(xmlM.Fam_Add_City) _
                    AndAlso xmlM.Fam_Add_Country.Length > 0 AndAlso xmlM.Fam_Add_City.Length > 0 Then
                    FADD1 = New Address() With {.Cell_Phone = xmlM.Fam_Add_CellPhone,
                                                .City = xmlM.Fam_Add_City,
                                                .Country = xmlM.Fam_Add_Country,
                                                .Email = xmlM.Fam_Add_Email,
                                                .Facebook = xmlM.Fam_Add_Facebook,
                                                .Home_Phone = xmlM.Fam_Add_HomePhone,
                                                .Street = xmlM.Fam_Add_Street,
                                                .Town = xmlM.Fam_Add_Town,
                                                .Twitter = xmlM.Fam_Add_Twitter,
                                                .Work_Phone = xmlM.Fam_Add_WorkPhone,
                                                .Fax = xmlM.Fam_Add_Fax}
                    odb.Addresses.InsertOnSubmit(FADD1)
                    odb.SubmitChanges()
                End If
                ExceptionsManager.RaiseOnStatus(New MyException("تم"))
                Application.DoEvents()
                If Not IsNothing(xmlM.Fam_Add_Country) AndAlso Not IsNothing(xmlM.Fam_Add_City) _
                    AndAlso xmlM.Fam_Add_Country.Length > 0 AndAlso xmlM.Fam_Add_City.Length > 0 _
                    AndAlso xmlM.Fam_IsRefugee Then
                    ExceptionsManager.RaiseOnStatus(New MyException("إدخال العنوان الحالي للعائلة"))
                    Application.DoEvents()
                    FADD2 = New Address() With {.Cell_Phone = xmlM.Fam_Add_CellPhone2,
                                                .City = xmlM.Fam_Add_City2,
                                                .Country = xmlM.Fam_Add_Country2,
                                                .Email = xmlM.Fam_Add_Email2,
                                                .Facebook = xmlM.Fam_Add_Facebook2,
                                                .Home_Phone = xmlM.Fam_Add_HomePhone2,
                                                .Street = xmlM.Fam_Add_Street2,
                                                .Town = xmlM.Fam_Add_Town2,
                                                .Twitter = xmlM.Fam_Add_Twitter2,
                                                .Work_Phone = xmlM.Fam_Add_WorkPhone2,
                                                .Fax = xmlM.Fam_Add_Fax2}
                    odb.Addresses.InsertOnSubmit(FADD2)
                    odb.SubmitChanges()
                    ExceptionsManager.RaiseOnStatus(New MyException("تم"))
                    Application.DoEvents()
                End If
                ExceptionsManager.RaiseOnStatus(New MyException("إدخال بينات العائلة"))
                Application.DoEvents()
                Famclass = New Family With {.Residece_Sate = xmlM.Fam_Residence_State,
                                            .Residenc_Type = xmlM.Fam_Residence_Type,
                                            .Note = xmlM.Fam_Note,
                                            .FamilyCard_Num = xmlM.Fam_CardNumber,
                                            .IsRefugee = xmlM.Fam_IsRefugee,
                                            .IsExcluded = False,
                                            .Finncial_Sate = xmlM.Fam_Finncial_State,
                                            .RegDate = Date.Now,
                                            .Address_ID = FADD1.ID,
                                            .FamilyCardPhoto = xmlM.Fam_CardPhoto1.ToByte(),
                                            .FamilyCardPhotoP2 = xmlM.Fam_CardPhoto1.ToByte(),
                                            .User_ID = frmLogin.CurrentUser.ID}

                If Not IsNothing(xmlM.Fam_Add_Country) AndAlso Not IsNothing(xmlM.Fam_Add_City) _
                    AndAlso xmlM.Fam_Add_Country.Length > 0 AndAlso xmlM.Fam_Add_City.Length > 0 _
                    AndAlso xmlM.Fam_IsRefugee Then
                    Famclass.Address_ID2 = FADD2.ID
                End If
                Mclass = New Mother()
                Fclass = New Father()
                MName = New Name()
                FName = New Name()
                ExceptionsManager.RaiseOnStatus(New MyException("إدخال بينات الأم"))
                Application.DoEvents()
                If Not IsNothing(xmlM.Moth_Add_Country) AndAlso Not IsNothing(xmlM.Moth_Add_City) _
                        AndAlso xmlM.Moth_Add_Country.Length > 0 AndAlso xmlM.Moth_Add_City.Length > 0 _
                        AndAlso xmlM.Fam_IsRefugee Then
                    ExceptionsManager.RaiseOnStatus(New MyException(Space(8) & "إدخال العنوان"))
                    Application.DoEvents()
                    MAdd = New Address()
                    MAdd.Cell_Phone = xmlM.Moth_Add_CellPhone
                    MAdd.City = xmlM.Moth_Add_City
                    MAdd.Email = xmlM.Moth_Add_Email
                    MAdd.Work_Phone = xmlM.Moth_Add_WorkPhone
                    MAdd.Street = xmlM.Moth_Add_Street
                    MAdd.Town = xmlM.Moth_Add_Town
                    MAdd.Country = xmlM.Moth_Add_Country
                    MAdd.Facebook = xmlM.Moth_Add_Facebook
                    MAdd.Fax = xmlM.Moth_Add_Fax
                    MAdd.Home_Phone = xmlM.Moth_Add_HomePhone
                    MAdd.Twitter = xmlM.Moth_Add_Twitter
                    odb.Addresses.InsertOnSubmit(MAdd)
                    odb.SubmitChanges()
                    ExceptionsManager.RaiseOnStatus(New MyException(Space(8) & "تم"))
                    Application.DoEvents()
                    Mclass.Address_ID = MAdd.ID
                End If
                ExceptionsManager.RaiseOnStatus(New MyException(Space(8) & "إدخال الاسم"))
                Application.DoEvents()
                MName.Father = xmlM.Moth_FatherName
                MName.First = xmlM.Moth_FirstName
                Mclass.Husband_Name = xmlM.Moth_HusbendName
                Mclass.Jop = xmlM.Moth_Jop
                MName.Last = xmlM.Moth_LastName
                MName.EName = xmlM.Moth_EFirstName
                MName.EFather = xmlM.Moth_EFatherName
                MName.ELast = xmlM.Moth_ELastName
                odb.Names.InsertOnSubmit(MName)
                odb.SubmitChanges()
                ExceptionsManager.RaiseOnStatus(New MyException(Space(8) & "تم"))
                Application.DoEvents()
                Mclass.Name_ID = MName.ID
                ExceptionsManager.RaiseOnStatus(New MyException(Space(8) & "حفظ البيانات..."))
                Application.DoEvents()
                Mclass.Note = xmlM.Moth_Note
                Mclass.Story = xmlM.Moth_Story
                Mclass.IdentityCard_Photo2 = xmlM.Moth_IdentityPhoto1.ToByte
                Mclass.IdentityCard_Photo = xmlM.Moth_IdentityPhoto2.ToByte
                Mclass.IdntityCard_ID = CType(xmlM.Moth_IdentityNumber, ULong?)
                Mclass.Salary = CType(xmlM.Moth_Salary, Decimal?)
                Mclass.IsDead = xmlM.Moth_IsDead
                Mclass.IsMarried = xmlM.Moth_IsMarried
                Mclass.IsOwnOrphans = xmlM.Moth_IsOwnOrphans
                Mclass.Birthday = CDate(xmlM.Moth_Birthday)
                If xmlM.Moth_IsDead Then
                    Mclass.Dieday = xmlM.Moth_Dieday
                Else
                    Mclass.Dieday = Nothing
                End If
                Mclass.RegDate = Date.Now
                Mclass.User_Id = frmLogin.CurrentUser.ID
                odb.Mothers.InsertOnSubmit(Mclass)
                odb.SubmitChanges()
                ExceptionsManager.RaiseOnStatus(New MyException("تم"))
                Application.DoEvents()
                ExceptionsManager.RaiseOnStatus(New MyException("إدخال بينات الأب"))
                Application.DoEvents()
                ExceptionsManager.RaiseOnStatus(New MyException(Space(8) & "إدخال الاسم"))
                Application.DoEvents()
                FName.First = xmlM.Fath_FirstName
                FName.Last = xmlM.Fath_LastName
                FName.Father = xmlM.Fath_FatherName
                FName.EFather = xmlM.Fath_EFatherName
                FName.ELast = xmlM.Fath_ELastName
                FName.EName = xmlM.Fath_EFirstName
                Fclass.Birthday = xmlM.Fath_Birthday
                Fclass.DeathCertificate_Photo = xmlM.Fath_DeathCertificate.ToByte
                Fclass.DeathResone = xmlM.Fath_DeathResone
                Fclass.Dieday = xmlM.Fath_Dieday
                Fclass.IdentityCard_ID = CULng(xmlM.Fath_IdentityNumber)
                Fclass.Jop = xmlM.Fath_Jop
                Fclass.Photo = xmlM.Fath_Photo.ToByte
                Fclass.RegDate = Date.Now
                Fclass.Story = xmlM.Fath_Story
                Fclass.User_ID = frmLogin.CurrentUser.ID
                odb.Names.InsertOnSubmit(FName)
                odb.SubmitChanges()
                ExceptionsManager.RaiseOnStatus(New MyException(Space(8) & "تم"))
                Application.DoEvents()
                ExceptionsManager.RaiseOnStatus(New MyException(Space(8) & "حفظ البيانات..."))
                Application.DoEvents()
                Fclass.Name_ID = FName.ID
                Fclass.User_ID = frmLogin.CurrentUser.ID
                odb.Fathers.InsertOnSubmit(Fclass)
                odb.SubmitChanges()
                ExceptionsManager.RaiseOnStatus(New MyException("تم"))
                Application.DoEvents()
                Famclass.Father_ID = Fclass.ID
                Application.DoEvents()
                Famclass.Mother_ID = Mclass.ID
                ExceptionsManager.RaiseOnStatus(New MyException(Space(8) & "حفظ البيانات..."))
                Application.DoEvents()
                odb.Families.InsertOnSubmit(Famclass)
                odb.SubmitChanges()
                ExceptionsManager.RaiseOnStatus(New MyException("تم"))
                'AddOrphan and Bondsman
                For Each xbo As FileCreation.XmlBuilder.BondsMan In xmlM.BondsManS
                    ExceptionsManager.RaiseOnStatus(New MyException("جاري معالجة البيانات...."))
                    Application.DoEvents()
                    ExceptionsManager.RaiseOnStatus(New MyException("جاري تسجيل معيل جديد..."))
                    Application.DoEvents()
                    Dim bo As New BondsMan()
                    Dim BoAdd As Address
                    Dim BoName As Name
                    ExceptionsManager.RaiseOnStatus(New MyException(vbTab & "جاري تسجيل العنوان و الاسم..."))
                    Application.DoEvents()
                    BoAdd = New Address() With {.Cell_Phone = xbo.Bo_Add_CellPhone, .City = xbo.Bo_Add_City, _
                                               .Country = xbo.Bo_Add_Country, .Email = xbo.Bo_Add_Email, _
                                               .Facebook = xbo.Bo_Add_Facebook, .Fax = xbo.Bo_Add_Fax, _
                                               .Home_Phone = xbo.Bo_Add_HomePhone, .Note = xbo.Bo_Add_Note, _
                                               .Street = xbo.Bo_Add_Street, .Town = xbo.Bo_Add_Town, _
                                               .Twitter = xbo.Bo_Add_Twitter, .Work_Phone = xbo.Bo_Add_WorkPhone}
                    BoName = New Name With {.EFather = xbo.Bo_EFatherName, .ELast = xbo.Bo_ELastName, _
                                           .EName = xbo.Bo_EFirstName, .Father = xbo.Bo_FatherName, _
                                           .First = xbo.Bo_FirstName, .Last = xbo.Bo_LastName}
                    ExceptionsManager.RaiseOnStatus(New MyException(vbTab & "تم الحفظ"))
                    Application.DoEvents()
                    ExceptionsManager.RaiseOnStatus(New MyException(vbTab & "جاري تسجيل بيانات المعيل...."))
                    Application.DoEvents()
                    If xbo.Bo_IdentityNumber.Length > 0 Then
                        bo.IdentityCard_ID = CType(xbo.Bo_IdentityNumber, ULong?)
                    End If
                    If xbo.Bo_Income.Length > 0 Then
                        bo.Income = CType(xbo.Bo_Income, Decimal?)
                    End If
                    bo.Jop = xbo.Bo_Jop
                    bo.Note = xbo.Bo_Note
                    bo.IdentityCard_Photo = xbo.Bo_IdentityPhoto1.ToByte()
                    bo.IdentityCard_Photo2 = xbo.Bo_IdentityPhoto2.ToByte()
                    odb.Names.InsertOnSubmit(BoName)
                    odb.Addresses.InsertOnSubmit(BoAdd)
                    odb.SubmitChanges()
                    odb.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, BoName)
                    odb.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, BoAdd)
                    bo.Address_ID = BoAdd.ID
                    bo.Name_ID = BoName.ID
                    bo.RegDate = Date.Now
                    bo.User_ID = frmLogin.CurrentUser.ID
                    odb.BondsMans.InsertOnSubmit(bo)
                    odb.SubmitChanges()
                    For Each xOrp In xbo.Orphans
                        Dim Orph As New Orphan()
                        Dim OName As Name
                        If xOrp.FootSiye > 0 Then
                            Orph.FootSize = CType(xOrp.FootSiye, Byte?)
                        End If
                        If xOrp.IdentityNumber.Length > 0 Then
                            Orph.IdentityNumber = CType(xOrp.IdentityNumber, ULong?)
                        End If
                        If xOrp.Tallness > 0 Then
                            Orph.Tallness = CType(xOrp.Tallness, Byte?)
                        End If
                        If xOrp.Weight > 0 Then
                            Orph.Weight = CType(xOrp.Weight, Byte?)
                        End If
                        If xOrp.Kaid > 0 Then
                            Orph.Kaid = xOrp.Kaid
                        End If
                        ExceptionsManager.RaiseOnStatus(New MyException("تم الحفظ"))
                        Application.DoEvents()
                        ExceptionsManager.RaiseOnStatus(New MyException("جاري تسجيل يتيم جديد..."))
                        Application.DoEvents()
                        ExceptionsManager.RaiseOnStatus(New MyException("جاري تسجيل الاسم..."))
                        Application.DoEvents()
                        OName = New Name With {.First = xOrp.FirstName, .Father = xOrp.FatherName, _
                                              .Last = xOrp.LastName, .EName = xOrp.EFirstName, _
                                              .ELast = xOrp.ELastName, .EFather = xOrp.EFatherName}
                        odb.Names.InsertOnSubmit(OName)
                        odb.SubmitChanges()
                        ExceptionsManager.RaiseOnStatus(New MyException("تم الحفظ"))
                        Application.DoEvents()
                        'Check Healthy Data
                        If xOrp.IsSick Then
                            ExceptionsManager.RaiseOnStatus(New MyException("جاري تسجيل البيانات الصحية..."))
                            Application.DoEvents()
                            Dim hlth As New Healthy()
                            If xOrp.HealthCost > 0 Then
                                hlth.Cost = CType(xOrp.HealthCost, Decimal?)
                            End If
                            If xOrp.HealthMedicen.Length > 0 Then
                                hlth.Medicen = xOrp.HealthMedicen
                            End If
                            If xOrp.HealthName.Length > 0 Then
                                hlth.Name = xOrp.HealthName
                            End If
                            hlth.ReporteFile = xOrp.HealthReportFile.ToByte()
                            hlth.SupervisorDoctor = xOrp.HealthDoctor
                            hlth.Note = xOrp.HealthNote
                            odb.Healthies.InsertOnSubmit(hlth)
                            odb.SubmitChanges()
                            Orph.Health_ID = hlth.ID
                            ExceptionsManager.RaiseOnStatus(New MyException("تم الحفظ"))
                            Application.DoEvents()
                        End If
                        'Check Studies Data
                        ExceptionsManager.RaiseOnStatus(New MyException("جاري تسجيل البيانات الدراسية..."))
                        Application.DoEvents()
                        If Not xOrp.EducationStage.Contains("متخلف") Then
                            Dim stud As New Study()
                            stud.Note = xOrp.EducationNote
                            stud.Certificate_Photo1 = xOrp.EducationCerPhoto1.ToByte()
                            stud.Certificate_Photo2 = xOrp.EducationCerPhoto2.ToByte()
                            If xOrp.EducationDegreesRate > 0 Then
                                stud.DegreesRate = xOrp.EducationDegreesRate
                            End If
                            If xOrp.EducationMonthlyCost > 0 Then
                                stud.MonthlyCost = CType(xOrp.EducationMonthlyCost, Decimal?)
                            End If
                            stud.School = xOrp.EducationSchool
                            stud.Stage = xOrp.EducationStage
                            odb.Studies.InsertOnSubmit(stud)
                            odb.SubmitChanges()
                            Orph.Education_ID = stud.ID
                            ExceptionsManager.RaiseOnStatus(New MyException("تم الحفظ"))
                            Application.DoEvents()
                        Else
                            Dim stud As New Study()
                            stud.Stage = xOrp.EducationStage
                            stud.Resons = xOrp.EducationReasons
                            odb.Studies.InsertOnSubmit(stud)
                            odb.SubmitChanges()
                            Orph.Education_ID = stud.ID
                            ExceptionsManager.RaiseOnStatus(New MyException("تم الحفظ"))
                            Application.DoEvents()
                        End If
                        ExceptionsManager.RaiseOnStatus(New MyException("جاري تسجيل بيانات اليتيم...."))
                        Application.DoEvents()
                        Orph.Name_ID = OName.ID
                        Orph.Family_ID = Famclass.ID
                        Orph.BondsMan_ID = bo.ID
                        Orph.Birthday = xOrp.Birthday
                        'Dim Oage As Integer
                        'Dim ddiff As New DateDiff(xOrp.Birthday, Date.Now)
                        'Oage = ddiff.ElapsedYears
                        'Orph.Age = Oage
                        Orph.BirthCertificate_Photo = xOrp.BirthCertificate.ToByte()
                        Orph.BirthPlace = xOrp.Birthplace
                        Orph.BondsManRelationship = xOrp.BondManRelation
                        Orph.FacePhoto = xOrp.FacePhoto.ToByte()
                        Orph.FamilyCardPagePhoto = xOrp.FamilyCardPhoto.ToByte()
                        Orph.FullPhoto = xOrp.FullPhoto.ToByte()
                        Orph.Gender = xOrp.Gender
                        ' Orph.IdentityNumber = numOIdNum.Value
                        Orph.RegDate = Date.Now
                        Orph.User_ID = frmLogin.CurrentUser.ID
                        odb.Orphans.InsertOnSubmit(Orph)
                        odb.SubmitChanges()
                        ExceptionsManager.RaiseOnStatus(New MyException("تم الحفظ"))
                        Application.DoEvents()
                        Try
                            Updater.AddNewOrphan(Orph)
                            Updater.AddNewBondsMan(bo.ID)
                            Updater.AddNewFamily(Famclass)
                            Updater.AddNewFather(Fclass)
                            Updater.AddNewMother(Mclass)
                        Catch
                        End Try
                    Next
                Next
                ExceptionsManager.RaiseOnStatus(New MyException("تمت العملية بنجاح"))
                Application.DoEvents()
                ExceptionsManager.RaiseOnStatus(New MyException("تم الحفظ!", False, True))
                Application.DoEvents()
                tr.Complete()
                Return True
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return False
        End Try
    End Function
    Protected Overrides Sub Finalize()
        Try
            If _DeleteTheFile Then
                My.Computer.FileSystem.DeleteFile(_FileName)
            End If
        Catch
        End Try
        MyBase.Finalize()
    End Sub
End Class
