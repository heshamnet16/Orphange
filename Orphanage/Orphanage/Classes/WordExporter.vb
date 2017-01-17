Imports System.IO
Imports <xmlns="urn:OrphanageXML:Templates">
Imports System.Text

Public Class WordExporter

    Private Sub SaveImage(ByVal xx() As Byte, ByVal FileName As String)
        If Not IsNothing(xx) AndAlso xx.Length > 0 Then
            Try
                Dim img = Image.FromStream(New MemoryStream(xx))
                Dim bits As Bitmap = CType(img, Bitmap)
                bits.Save(FileName, Drawing.Imaging.ImageFormat.Jpeg)
                img.Dispose()
                bits.Dispose()
            Catch

            End Try
        End If
    End Sub

    Public Sub ExportDocument(ByVal orph As OrphanageClasses.Orphan, ByVal FolderPath As String)
        SaveImage(orph.Family.FamilyCardPhoto, FolderPath & "\" & "بطاقة عائلية1.jpg")
        SaveImage(orph.Family.FamilyCardPhotoP2, FolderPath & "\" & "بطاقة عائلية2.jpg")
        SaveImage(orph.Family.Father.Photo, FolderPath & "\" & "صورة " & Getter.GetFullName(orph.Family.Father.Name) & ".jpg")
        SaveImage(orph.Family.Father.DeathCertificate_Photo, FolderPath & "\" & "شهادة وفاة " & Getter.GetFullName(orph.Family.Father.Name) & ".jpg")
        SaveImage(orph.Family.Mother.IdentityCard_Photo, FolderPath & "\" & "هوية " & Getter.GetFullName(orph.Family.Mother.Name) & ".jpg")
        SaveImage(orph.Family.Mother.IdentityCard_Photo2, FolderPath & "\" & "هوية2 " & Getter.GetFullName(orph.Family.Mother.Name) & ".jpg")
        SaveImage(orph.BirthCertificate_Photo, FolderPath & "\" & "شهادة ولادة " & Getter.GetFullName(orph.Name) & ".jpg")
        SaveImage(orph.FacePhoto, FolderPath & "\" & "صورة شخصية لـ " & Getter.GetFullName(orph.Name) & ".jpg")
        SaveImage(orph.FullPhoto, FolderPath & "\" & "صورة كاملة لـ " & Getter.GetFullName(orph.Name) & ".jpg")
        SaveImage(orph.FamilyCardPagePhoto, FolderPath & "\" & "صورة بيان العائلة لـ " & Getter.GetFullName(orph.Name) & ".jpg")
        If orph.Education_ID.HasValue AndAlso Not IsNothing(orph.Study.Certificate_Photo1) Then
            SaveImage(orph.Study.Certificate_Photo1, FolderPath & "\" & "شهادة دراسية لـ " & Getter.GetFullName(orph.Name) & ".jpg")
        End If
        If orph.Education_ID.HasValue AndAlso Not IsNothing(orph.Study.Certificate_Photo2) Then
            SaveImage(orph.Study.Certificate_Photo2, FolderPath & "\" & "شهادة دراسية2 لـ " & Getter.GetFullName(orph.Name) & ".jpg")
        End If
        If orph.Health_ID.HasValue AndAlso Not IsNothing(orph.Healthy.ReporteFile) Then
            SaveImage(orph.Healthy.ReporteFile, FolderPath & "\" & "تقرير طبي لـ " & Getter.GetFullName(orph.Name) & ".jpg")
        End If
        SaveImage(orph.BondsMan.IdentityCard_Photo, FolderPath & "\" & "صورة هوية المعيل " & Getter.GetFullName(orph.BondsMan.Name) & ".jpg")
        SaveImage(orph.BondsMan.IdentityCard_Photo2, FolderPath & "\" & "صورة هوية المعيل2 " & Getter.GetFullName(orph.BondsMan.Name) & ".jpg")

    End Sub
    Public Sub ExportDocument(ByVal Fam As OrphanageClasses.Family, ByVal FolderPath As String)
        SaveImage(Fam.FamilyCardPhoto, FolderPath & "\" & "بطاقة عائلية1.jpg")
        SaveImage(Fam.FamilyCardPhotoP2, FolderPath & "\" & "بطاقة عائلية2.jpg")
        SaveImage(Fam.Father.Photo, FolderPath & "\" & "صورة " & Getter.GetFullName(Fam.Father.Name) & ".jpg")
        SaveImage(Fam.Father.DeathCertificate_Photo, FolderPath & "\" & "شهادة وفاة " & Getter.GetFullName(Fam.Father.Name) & ".jpg")
        SaveImage(Fam.Mother.IdentityCard_Photo, FolderPath & "\" & "هوية " & Getter.GetFullName(Fam.Mother.Name) & ".jpg")
        SaveImage(Fam.Mother.IdentityCard_Photo2, FolderPath & "\" & "هوية2 " & Getter.GetFullName(Fam.Mother.Name) & ".jpg")
    End Sub

    Public Function Fill_3Taa2_Data(ByVal orph As OrphanageClasses.Orphan) As WordTemletes._3Taa2._3Taa2Data
        Dim moth As OrphanageClasses.Mother = orph.Family.Mother
        Dim fath As OrphanageClasses.Father = orph.Family.Father
        Dim bond As OrphanageClasses.BondsMan = orph.BondsMan
        Dim fam As OrphanageClasses.Family = orph.Family
        Dim wordData As New WordTemletes._3Taa2._3Taa2Data()
        'Orphan
        wordData.Orphan_Birthday = orph.Birthday
        wordData.Orphan_BondsManRelation = orph.BondsManRelationship
        If IsNothing(orph.Name.Father) Then
            wordData.Orphan_FatherName = ""
        Else
            'wordData.Orphan_FatherName = orph.Name.Father
            wordData.Orphan_FatherName = fath.Name.First
        End If
        wordData.Orphan_FirstName = orph.Name.First
        wordData.Orphan_MotherFullName = Getter.GetFullName(moth.Name)
        wordData.Orphan_Brother_Female_Number = Getter.GetOrphanFemaleBrothersNumber(orph.ID)
        wordData.Orphan_Brother_Male_Number = Getter.GetOrphanMaleBrothersNumber(orph.ID)
        If IsNothing(fath.Name.Father) Then
            wordData.Orphan_GranFatherName = ""
        Else
            wordData.Orphan_GranFatherName = fath.Name.Father
        End If
        wordData.Orphan_Id = orph.ID
        If IsNothing(orph.IdentityNumber) Then
            wordData.Orphan_IDentityNumber = "لايملك بطاقة شخصية"
        Else
            wordData.Orphan_IDentityNumber = "0" & orph.IdentityNumber.ToString()
        End If
        wordData.Orphan_Img = orph.FacePhoto
        wordData.Orphan_LastName = orph.Name.Last
        wordData.Orphan_Sex = orph.Gender
        'Family
        If IsNothing(fam.Address_ID2) Then
            wordData.Family_CurAdd_BigCity = ""
            wordData.Family_CurAdd_City = ""
            wordData.Family_CurAdd_Phone = ""
            wordData.Family_CurAdd_Street = ""
            wordData.Family_CurAdd_Town = ""
        Else
            wordData.Family_CurAdd_BigCity = fam.Address1.Country
            wordData.Family_CurAdd_City = fam.Address1.City
            wordData.Family_CurAdd_Phone = fam.Address1.Cell_Phone
            wordData.Family_CurAdd_Street = fam.Address1.Street
            wordData.Family_CurAdd_Town = fam.Address1.Town
        End If
        If IsNothing(fam.Address_ID) Then
            wordData.Family_OrgAdd_BigCity = ""
            wordData.Family_OrgAdd_City = ""
            wordData.Family_OrgAdd_Phone = ""
            wordData.Family_OrgAdd_Street = ""
            wordData.Family_OrgAdd_Town = ""
        Else
            wordData.Family_OrgAdd_BigCity = fam.Address.Country
            wordData.Family_OrgAdd_City = fam.Address.City
            wordData.Family_OrgAdd_Phone = fam.Address.Cell_Phone
            wordData.Family_OrgAdd_Street = fam.Address.Street
            wordData.Family_OrgAdd_Town = fam.Address.Town
        End If
        If Not IsNothing(fam.Finncial_Sate) Then
            wordData.Family_Finncial_State = fam.Finncial_Sate
        Else
            wordData.Family_Finncial_State = "سيئ جداً"
        End If
        wordData.Family_IsRentalHouse = fam.Residenc_Type
        wordData.Family_ResidenceState = fam.Residece_Sate
        'Mother
        If IsNothing(moth.Dieday) Then
            wordData.Mother_DieDate = ""
        Else
            wordData.Mother_DieDate = moth.Dieday.Value.ToString(My.Settings.GeneralDateFormat)
        End If
        wordData.Mother_IsDead = moth.IsDead
        wordData.Mother_IsMarried = moth.IsMarried
        If IsNothing(moth.Jop) OrElse moth.Jop.Contains("منزل") Then
            wordData.Mother_IsWorking = False
        Else
            wordData.Mother_IsWorking = True
        End If
        If IsNothing(moth.Salary) Then
            wordData.Mother_MonthlyIncome = 0
        Else
            wordData.Mother_MonthlyIncome = Int(moth.Salary).ToString()
        End If
        'Father
        wordData.Father_DieDate = orph.Family.Father.Dieday
        wordData.Father_DeathReson = orph.Family.Father.DeathResone
        wordData.BondsMan_FullName = Getter.GetFullName(orph.BondsMan.Name)
        'Education
        If Not orph.Education_ID.HasValue Then
            wordData.Education_Degrees = 0
            wordData.Education_SchoolName = ""
            wordData.Education_StageState = ""
        Else
            If orph.Study.DegreesRate.HasValue Then
                wordData.Education_Degrees = 0
            Else
                wordData.Education_Degrees = CByte(orph.Study.DegreesRate.Value)
            End If
            wordData.Education_SchoolName = orph.Study.School
            wordData.Education_StageState = orph.Study.Stage
        End If
        'Health
        If IsNothing(orph.Health_ID) Then
            wordData.Healthy_Cost = ""
            wordData.Healthy_IsSick = False
            wordData.Healthy_SicknessName = ""
        Else
            If IsNothing(orph.Healthy.Cost) Then
                wordData.Healthy_Cost = ""
            Else
                wordData.Healthy_Cost = orph.Healthy.Cost.ToString() & "$"
            End If
            wordData.Healthy_IsSick = True
            wordData.Healthy_SicknessName = orph.Healthy.Name.Replace(";", " ")
        End If
        'Support
        'If IsNothing(orph.Suppoter_ID) Then
        wordData.Supporter_BailDuration = ""
        wordData.Supporter_BailMony = 0
        wordData.Supporter_FullName = ""
        wordData.Supporter_StartBail = ""
        'End If           
        Return wordData
    End Function
    Public Function Fill_Maktab1_Data(ByVal orph As OrphanageClasses.Orphan) As WordTemletes.OrginalOrphanTemplete._MaktabData
        Dim moth As OrphanageClasses.Mother = orph.Family.Mother
        Dim fath As OrphanageClasses.Father = orph.Family.Father
        Dim bond As OrphanageClasses.BondsMan = orph.BondsMan
        Dim fam As OrphanageClasses.Family = orph.Family
        Dim wordData As New WordTemletes.OrginalOrphanTemplete._MaktabData
        'Orphan
        wordData.Orphan_Birthday = orph.Birthday
        wordData.Orphan_BondsManRelation = orph.BondsManRelationship
        If orph.Education_ID.HasValue Then
            wordData.Orphan_Education = orph.Study.Stage
        Else
            wordData.Orphan_Education = ""
        End If
        wordData.Orphan_FacePhoto = orph.FacePhoto
        wordData.Orphan_FirstName = orph.Name.First
        wordData.Orphan_BirthPlaceANDKaid = orph.BirthPlace & "-" & orph.Kaid
        If orph.Health_ID.HasValue Then
            wordData.Orphan_FullHealth = "مريض بـ" & orph.Healthy.Name.Replace(";", "-")
        Else
            wordData.Orphan_FullHealth = "بصحة جيدة"
        End If
        If Not IsNothing(orph.BirthCertificate_Photo) Then
            wordData.Orphan_HasBirthCertificate = "نعم"
        Else
            wordData.Orphan_HasBirthCertificate = "لا"
        End If
        If orph.Age.HasValue Then
            wordData.Orphan_Age = ATDFormater.ArabicDateFormater.GetArabicYear(orph.Age.Value)
        End If
        wordData.Orphan_Regdate = orph.RegDate
        wordData.Orphan_Sex = orph.Gender
        wordData.Orphan_IsBailed = orph.IsBailed
        wordData.Father_DieDate = fath.Dieday
        wordData.Father_FullName = Getter.GetFullName(fath.Name)
        If Not IsNothing(fath.DeathCertificate_Photo) Then
            wordData.Father_HasDeathCertificate = "نعم"
        Else
            wordData.Father_HasDeathCertificate = "لا"
        End If
        wordData.Mother_Birthday = moth.Birthday
        wordData.Mother_FullName = Getter.GetFullName(moth.Name)
        If moth.IdntityCard_ID.HasValue Then
            wordData.Mother_IdNumber = CStr(moth.IdntityCard_ID.Value)
        Else
            wordData.Mother_IdNumber = "لا تمتلك بطاقة شخصية"
        End If
        wordData.Mother_IsAlive = Not moth.IsDead
        wordData.Mother_IsMarried = moth.IsMarried
        wordData.Mother_IsOwnOrphans = moth.IsOwnOrphans
        If bond.Name.First = moth.Name.First AndAlso bond.Name.Last = moth.Name.Last Then
            If Not IsNothing(bond.Orphans) AndAlso bond.Orphans.Count > 1 Then
                wordData.Mother_IsOwnOthersOrphans = "نعم " & bond.Orphans.Count - 1
            Else
                wordData.Mother_IsOwnOthersOrphans = "لا"
            End If
        Else
            wordData.Mother_IsOwnOthersOrphans = "لا"
        End If
        wordData.Mother_Jop = moth.Jop
        wordData.Family_CardNumber = fam.FamilyCard_Num
        wordData.Family_Finncial_State = fam.Finncial_Sate
        If fam.Address_ID2.HasValue Then
            wordData.Family_FullAdress = Getter.GetAddress(fam.Address1)
            wordData.Family_Phone = fam.Address1.Cell_Phone
        Else
            If fam.Address_ID.HasValue Then
                wordData.Family_FullAdress = Getter.GetAddress(fam.Address)
                wordData.Family_Phone = fam.Address.Cell_Phone
            Else
                wordData.Family_FullAdress = "العنوان الحالي غير معروف"
            End If
        End If
        If Not IsNothing(fam.FamilyCardPhoto) OrElse Not IsNothing(fam.FamilyCardPhotoP2) Then
            wordData.Family_HasFamilyCardPhoto = "نعم"
        Else
            wordData.Family_HasFamilyCardPhoto = "لا"
        End If
        wordData.Family_Residence_Type = fam.Residenc_Type
        wordData.Family_ResidenceState = fam.Residece_Sate
        wordData.BondsMan_FullName = Getter.GetFullName(bond.Name)
        If Not IsNothing(bond.IdentityCard_Photo) OrElse Not IsNothing(bond.IdentityCard_Photo2) Then
            wordData.BondsMan_HasBondsManIdPhoto = "نعم"
        Else
            wordData.BondsMan_HasBondsManIdPhoto = "لا"
        End If
        wordData.BondsMan_Jop = bond.Jop
        If bond.Income.HasValue AndAlso bond.Income > 0 Then
            wordData.BondsMan_Salary = Int(bond.Income).ToString()
        Else
            wordData.BondsMan_Salary = ""
        End If
        Return wordData
    End Function
    Private Function AnotherDecode64(ByVal base64Decoded As String) As Byte()    
        Dim temp As String = base64Decoded.TrimEnd("=")
        Dim asciiChars As Integer = temp.Length - temp.Count(Function(c) Char.IsWhiteSpace(c))
        Select (asciiChars Mod 4)    
            Case 1
                'This would always produce an exception!!
                'Regardless what (or what not) you attach to your string!
                'Better would be some kind of throw new Exception()
                Return New Byte() {}
            Case 0
                asciiChars = 0
                Exit Select
            Case 2
                asciiChars = 2
                Exit Select
            Case 3
                asciiChars = 1
                Exit Select
        End Select
        temp += New String("=", asciiChars)

        Return Convert.FromBase64String(temp)
    End Function

    Public Function Fill_CustomString(ByVal _Fam As OrphanageClasses.Family, ByVal TempName As String, ByVal DestinationFile As String, ByRef Imgs As Dictionary(Of String, Image), ByRef UseBookMark As Boolean, ByRef useDefaultPicSize As Boolean, ByRef defautlPicSize As Size, ByRef boolBookmark As Dictionary(Of String, Integer), Optional ByRef CustomFont As String = "") As Dictionary(Of String, String)
        If Not File.Exists(FrmNewTemplate.xmlFileName) Then
            Return Nothing
        End If
        If IsNothing(_Fam) Then Return Nothing
        If IsNothing(TempName) OrElse TempName.Length = 0 Then Return Nothing
        Dim ret As New Dictionary(Of String, String)
        Dim Fam = _Fam
        Dim Fath = Fam.Father
        Dim Moth = Fam.Mother
        Dim bail As OrphanageClasses.Bail = Nothing
        If Fam.IsBaild AndAlso Fam.Baild_ID.HasValue Then
            bail = Fam.Bail
        Else
            If Fam.IsBaild AndAlso Fam.Baild_ID.HasValue Then
                bail = Fam.Bail
            End If
        End If
        Dim xDoc As XDocument = XDocument.Load(FrmNewTemplate.xmlFileName)
        Dim q = From ele In xDoc.<Templates>.<Template> Where ele.<Name>.Value = TempName Select ele

        If Not IsNothing(q) AndAlso q.Count > 0 Then
            For Each xtemp In q
                Dim MaxOrphanCount As Integer = 0
                Dim CurrentOrphanNumber = 0
                Dim IsRepeatedBondMan As Boolean = CBool(xtemp.<IsBondsManRepeated>.Value)
                Dim IsFamily As Boolean = CBool(xtemp.<IsFamily>.Value)
                If IsFamily Then
                    MaxOrphanCount = CInt(xtemp.<MaxOorphansCount>.Value)
                End If
                Dim FileLength As Long = CLng(xtemp.<Size>.Value)
                UseBookMark = CBool(xtemp.<IsBookmarks>.Value)
                Dim UseCustomBool As Boolean = CBool(xtemp.<UseCustomBoolean>.Value())
                Dim YesBool, NoBool As String
                If UseCustomBool Then
                    boolBookmark = New Dictionary(Of String, Integer)
                    NoBool = CInt(xtemp.<BooleanNOMark>.Value)
                    YesBool = CInt(xtemp.<BooleanYesMark>.Value)
                Else
                    boolBookmark = Nothing
                    NoBool = xtemp.<BooleanNOMark>.Value
                    YesBool = xtemp.<BooleanYesMark>.Value
                End If
                CustomFont = xtemp.<BooleanFontName>.Value


                useDefaultPicSize = CBool(xtemp.<IsDefaultPictureWH>.Value)
                defautlPicSize = New Size(CInt(xtemp.<DefaultPictureW>.Value), CInt(xtemp.<DefaultPictureH>.Value))
                Dim Data() As Byte
                Data = AnotherDecode64(xtemp.<Data>.Value)
                Try
                    Dim mem As New MemoryStream(Data)
                    Dim zz As New FileStream(DestinationFile, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
                    mem.WriteTo(zz)
                    mem.Flush()
                    zz.Flush()
                    zz.Close()
                    mem.Close()
                    zz.Dispose()
                    mem.Dispose()
                Catch
                End Try
                For Each key In xtemp.<Bookmarks>
                    'Bail
                    If key.<Bail>.<Amount>.Value.Length > 0 Then
                        If Not IsNothing(bail) Then
                            ret.Add(key.<Bail>.<Amount>.Value, bail.Amount.ToString())
                        Else
                            ret.Add(key.<Bail>.<Amount>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<CurnceyName>.Value.Length > 0 Then
                        If Not IsNothing(bail) Then
                            ret.Add(key.<Bail>.<CurnceyName>.Value, bail.Box.Currency_Name.ToString())
                        Else
                            ret.Add(key.<Bail>.<CurnceyName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<CurnceyShort>.Value.Length > 0 Then
                        ret.Add(key.<Bail>.<CurnceyShort>.Value, bail.Box.Currency_Short.ToString())
                    End If
                    If key.<Bail>.<EndDate>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso bail.End_Date.HasValue Then
                            ret.Add(key.<Bail>.<EndDate>.Value, bail.End_Date.ToString(My.Settings.GeneralDateFormat))
                        Else
                            ret.Add(key.<Bail>.<EndDate>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<IsDated>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso bail.End_Date.HasValue AndAlso bail.Start_Date.HasValue Then
                            If Not UseCustomBool Then
                                ret.Add(key.<Bail>.<IsDated>.Value, YesBool)
                            Else
                                boolBookmark.Add(key.<Bail>.<IsDated>.Value, YesBool)
                            End If
                        Else
                            If Not UseCustomBool Then
                                ret.Add(key.<Bail>.<IsDated>.Value, NoBool)
                            Else
                                boolBookmark.Add(key.<Bail>.<IsDated>.Value, NoBool)
                            End If
                        End If
                    End If
                    If key.<Bail>.<IsFamily>.Value.Length > 0 Then
                        If Not IsNothing(bail) Then
                            If Not UseCustomBool Then
                                ret.Add(key.<Bail>.<IsFamily>.Value, IIf(bail.Is_Family, YesBool, NoBool))
                            Else
                                boolBookmark.Add(key.<Bail>.<IsFamily>.Value, IIf(bail.Is_Family, YesBool, NoBool))
                            End If
                        Else
                            If Not UseCustomBool Then
                                ret.Add(key.<Bail>.<IsFamily>.Value, NoBool)
                            Else
                                boolBookmark.Add(key.<Bail>.<IsFamily>.Value, NoBool)
                            End If
                        End If
                    End If
                    If key.<Bail>.<IsMonthly>.Value.Length > 0 Then
                        If Not IsNothing(bail) Then
                            If Not UseCustomBool Then
                                ret.Add(key.<Bail>.<IsMonthly>.Value, IIf(bail.IsMonthly, YesBool, NoBool))
                            Else
                                boolBookmark.Add(key.<Bail>.<IsMonthly>.Value, IIf(bail.IsMonthly, YesBool, NoBool))
                            End If
                        Else
                            If Not UseCustomBool Then
                                ret.Add(key.<Bail>.<IsMonthly>.Value, NoBool)
                            Else
                                boolBookmark.Add(key.<Bail>.<IsMonthly>.Value, NoBool)
                            End If
                        End If
                    End If
                    If key.<Bail>.<Note>.Value.Length > 0 Then
                        If Not IsNothing(bail) Then
                            ret.Add(key.<Bail>.<Note>.Value, bail.Note)
                        Else
                            ret.Add(key.<Bail>.<Note>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<StartDate>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso bail.Start_Date.HasValue Then
                            ret.Add(key.<Bail>.<StartDate>.Value, bail.Start_Date.ToString(My.Settings.GeneralDateFormat))
                        Else
                            ret.Add(key.<Bail>.<StartDate>.Value, "")
                        End If
                    End If
                    'SupoName
                    If key.<Bail>.<Supporter>.<EFatherName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.EFather) Then
                            ret.Add(key.<Bail>.<Supporter>.<EFatherName>.Value, bail.Supporter.Name.EFather)
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<EFatherName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<Supporter>.<EFirstName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.EName) Then
                            ret.Add(key.<Bail>.<Supporter>.<EFirstName>.Value, bail.Supporter.Name.EName)
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<EFirstName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<Supporter>.<EFullName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.EName) Then
                            ret.Add(key.<Bail>.<Supporter>.<EFullName>.Value, Getter.GetFullNameE(bail.Supporter.Name))
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<EFullName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<Supporter>.<ELastName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.ELast) Then
                            ret.Add(key.<Bail>.<Supporter>.<ELastName>.Value, bail.Supporter.Name.ELast)
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<ELastName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<Supporter>.<FatherName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.Father) Then
                            ret.Add(key.<Bail>.<Supporter>.<FatherName>.Value, bail.Supporter.Name.Father)
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<FatherName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<Supporter>.<FirstName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.First) Then
                            ret.Add(key.<Bail>.<Supporter>.<FirstName>.Value, bail.Supporter.Name.First)
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<FirstName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<Supporter>.<FullName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.First) Then
                            ret.Add(key.<Bail>.<Supporter>.<FullName>.Value, Getter.GetFullName(bail.Supporter.Name))
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<FullName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<Supporter>.<LastName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.Last) Then
                            ret.Add(key.<Bail>.<Supporter>.<LastName>.Value, bail.Supporter.Name.Last)
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<LastName>.Value, "")
                        End If
                    End If
                    'Orphan
                    Dim Orph_Ids() As Integer = Getter.GetFamilyOrphans(Fam.ID)
                    Dim _odb As New OrphanageDB.Odb()
                    Do
                        If CurrentOrphanNumber >= Orph_Ids.Length Then Exit Do
                        Dim qO = From orp In _odb.Orphans Where orp.ID = Orph_Ids(CurrentOrphanNumber)
                                Select orp
                        If IsNothing(qO) OrElse qO.Count <= 0 Then
                            Continue Do
                        End If
                        Dim orph As Orphanage.OrphanageClasses.Orphan = qO.FirstOrDefault()
                        Dim Bond As OrphanageClasses.BondsMan = orph.BondsMan
                        CurrentOrphanNumber += 1
                        Dim StringToAdd As String = CurrentOrphanNumber.ToString()
                        If key.<Orphan>.<BirthCertificate_Photo>.Value.Length > 0 Then
                            If Not IsNothing(orph.BirthCertificate_Photo) Then
                                Dim img As Image = Image.FromStream(New MemoryStream(orph.BirthCertificate_Photo))
                                Imgs.Add(key.<Orphan>.<BirthCertificate_Photo>.Value & StringToAdd, img)
                            End If
                        End If
                        If key.<Orphan>.<FamilyCardPagePhoto>.Value.Length > 0 Then
                            If Not IsNothing(orph.FamilyCardPagePhoto) Then
                                Dim img As Image = Image.FromStream(New MemoryStream(orph.FamilyCardPagePhoto))
                                Imgs.Add(key.<Orphan>.<FamilyCardPagePhoto>.Value & StringToAdd, img)
                            End If
                        End If
                        If key.<Orphan>.<FullPhoto>.Value.Length > 0 Then
                            If Not IsNothing(orph.FullPhoto) Then
                                Dim img As Image = Image.FromStream(New MemoryStream(orph.FullPhoto))
                                Imgs.Add(key.<Orphan>.<FullPhoto>.Value & StringToAdd, img)
                            End If
                        End If
                        If key.<Orphan>.<FacePhoto>.Value.Length > 0 Then
                            If Not IsNothing(orph.FacePhoto) Then
                                Dim img As Image = Image.FromStream(New MemoryStream(orph.FacePhoto))
                                Imgs.Add(key.<Orphan>.<FacePhoto>.Value & StringToAdd, img)
                            End If
                        End If
                        If key.<Orphan>.<Age>.Value.Length > 0 Then
                            If orph.Age.HasValue Then
                                ret.Add(key.<Orphan>.<Age>.Value & StringToAdd, CStr(orph.Age.Value))
                            Else
                                ret.Add(key.<Orphan>.<Age>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<Birthday>.Value.Length > 0 Then
                            ret.Add(key.<Orphan>.<Birthday>.Value & StringToAdd, orph.Birthday.ToString(My.Settings.GeneralDateFormat))
                        Else
                            'ret.Add(key.<Orphan>.<Birthday>.Value, "")
                        End If
                        If key.<Orphan>.<Birthplace>.Value.Length > 0 Then
                            If Not IsNothing(orph.BirthPlace) Then
                                ret.Add(key.<Orphan>.<Birthplace>.Value & StringToAdd, orph.BirthPlace)
                            Else
                                ret.Add(key.<Orphan>.<Birthplace>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<BondsManRel>.Value.Length > 0 Then
                            If Not IsNothing(orph.BondsManRelationship) Then
                                ret.Add(key.<Orphan>.<BondsManRel>.Value & StringToAdd, orph.BondsManRelationship)
                            Else
                                ret.Add(key.<Orphan>.<BondsManRel>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<BrothersCount>.Value.Length > 0 Then
                            If Not IsNothing(Fam.Orphans) Then
                                ret.Add(key.<Orphan>.<BrothersCount>.Value & StringToAdd, Fam.Orphans.Count - 1)
                            Else
                                ret.Add(key.<Orphan>.<BrothersCount>.Value & StringToAdd, "")
                            End If
                        End If
                        'Study
                        If orph.Education_ID.HasValue Then
                            If key.<Orphan>.<Education>.<Certificate_Photo1>.Value.Length > 0 Then
                                If Not IsNothing(orph.Study.Certificate_Photo1) Then
                                    Dim img As Image = Image.FromStream(New MemoryStream(orph.Study.Certificate_Photo1))
                                    Imgs.Add(key.<Orphan>.<Education>.<Certificate_Photo1>.Value & StringToAdd, img)
                                End If
                            End If
                            If key.<Orphan>.<Education>.<Certificate_Photo2>.Value.Length > 0 Then
                                If Not IsNothing(orph.Study.Certificate_Photo2) Then
                                    Dim img As Image = Image.FromStream(New MemoryStream(orph.Study.Certificate_Photo2))
                                    Imgs.Add(key.<Orphan>.<Education>.<Certificate_Photo2>.Value & StringToAdd, img)
                                End If
                            End If
                            If key.<Orphan>.<Education>.<Collage>.Value.Length > 0 Then
                                If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.Collage) Then
                                    ret.Add(key.<Orphan>.<Education>.<Collage>.Value & StringToAdd, orph.Study.Collage)
                                Else
                                    ret.Add(key.<Orphan>.<Education>.<Collage>.Value & StringToAdd, "")
                                End If
                            End If
                            If key.<Orphan>.<Education>.<DegreesRate>.Value.Length > 0 Then
                                If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.DegreesRate) Then
                                    ret.Add(key.<Orphan>.<Education>.<DegreesRate>.Value & StringToAdd, orph.Study.DegreesRate.ToString())
                                Else
                                    ret.Add(key.<Orphan>.<Education>.<DegreesRate>.Value & StringToAdd, "")
                                End If
                            End If
                            If key.<Orphan>.<Education>.<MonthlyCost>.Value.Length > 0 Then
                                If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.MonthlyCost) Then
                                    ret.Add(key.<Orphan>.<Education>.<MonthlyCost>.Value & StringToAdd, orph.Study.MonthlyCost.ToString())
                                Else
                                    ret.Add(key.<Orphan>.<Education>.<MonthlyCost>.Value & StringToAdd, "")
                                End If
                            End If
                            If key.<Orphan>.<Education>.<Note>.Value.Length > 0 Then
                                If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.Note) Then
                                    ret.Add(key.<Orphan>.<Education>.<Note>.Value & StringToAdd, orph.Study.Note)
                                Else
                                    ret.Add(key.<Orphan>.<Education>.<Note>.Value & StringToAdd, "")
                                End If
                            End If
                            If key.<Orphan>.<Education>.<Reasons>.Value.Length > 0 Then
                                If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.Resons) Then
                                    ret.Add(key.<Orphan>.<Education>.<Reasons>.Value & StringToAdd, orph.Study.Resons)
                                Else
                                    ret.Add(key.<Orphan>.<Education>.<Reasons>.Value & StringToAdd, "")
                                End If
                            End If
                            If key.<Orphan>.<Education>.<School>.Value.Length > 0 Then
                                If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.School) Then
                                    ret.Add(key.<Orphan>.<Education>.<School>.Value & StringToAdd, orph.Study.School)
                                Else
                                    ret.Add(key.<Orphan>.<Education>.<School>.Value & StringToAdd, "")
                                End If
                            End If
                            If key.<Orphan>.<Education>.<Stage>.Value.Length > 0 Then
                                If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.Stage) Then
                                    ret.Add(key.<Orphan>.<Education>.<Stage>.Value & StringToAdd, orph.Study.Stage)
                                Else
                                    ret.Add(key.<Orphan>.<Education>.<Stage>.Value & StringToAdd, "")
                                End If
                            End If
                            If key.<Orphan>.<Education>.<Univercity>.Value.Length > 0 Then
                                If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.Univercity) Then
                                    ret.Add(key.<Orphan>.<Education>.<Univercity>.Value & StringToAdd, orph.Study.Univercity)
                                Else
                                    ret.Add(key.<Orphan>.<Education>.<Univercity>.Value & StringToAdd, "")
                                End If
                            End If
                        End If
                        If key.<Orphan>.<EFatherName>.Value.Length > 0 Then
                            If Not IsNothing(orph.Name.EFather) Then
                                ret.Add(key.<Orphan>.<EFatherName>.Value & StringToAdd, orph.Name.EFather)
                            Else
                                ret.Add(key.<Orphan>.<EFatherName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<EFirstName>.Value.Length > 0 Then
                            If Not IsNothing(orph.Name.EName) Then
                                ret.Add(key.<Orphan>.<EFirstName>.Value & StringToAdd, orph.Name.EName)
                            Else
                                ret.Add(key.<Orphan>.<EFirstName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<EFullName>.Value.Length > 0 Then
                            If Not IsNothing(orph.Name) Then
                                ret.Add(key.<Orphan>.<EFullName>.Value & StringToAdd, Getter.GetFullNameE(orph.Name))
                            Else
                                ret.Add(key.<Orphan>.<EFullName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<ELastName>.Value.Length > 0 Then
                            If Not IsNothing(orph.Name.ELast) Then
                                ret.Add(key.<Orphan>.<ELastName>.Value & StringToAdd, orph.Name.ELast)
                            Else
                                ret.Add(key.<Orphan>.<ELastName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<FatherName>.Value.Length > 0 Then
                            If Not IsNothing(orph.Name.Father) Then
                                ret.Add(key.<Orphan>.<FatherName>.Value & StringToAdd, orph.Name.Father)
                            Else
                                ret.Add(key.<Orphan>.<FatherName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<FemaleBrothersCount>.Value.Length > 0 Then
                            If Not IsNothing(Fam.Orphans) Then
                                Dim Mb As Integer = Getter.GetFamilyFemaleOrphansCount(Fam.ID)
                                If Not orph.Gender.Contains("ذ") Then
                                    If Mb > 0 Then Mb -= 1
                                End If
                                ret.Add(key.<Orphan>.<FemaleBrothersCount>.Value & StringToAdd, Mb.ToString())
                            Else
                                ret.Add(key.<Orphan>.<FemaleBrothersCount>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<FirstName>.Value.Length > 0 Then
                            If Not IsNothing(orph.Name.First) Then
                                ret.Add(key.<Orphan>.<FirstName>.Value & StringToAdd, orph.Name.First)
                            Else
                                ret.Add(key.<Orphan>.<FirstName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<FootSize>.Value.Length > 0 Then
                            If Not IsNothing(orph.FootSize) Then
                                ret.Add(key.<Orphan>.<FootSize>.Value & StringToAdd, orph.FootSize)
                            Else
                                ret.Add(key.<Orphan>.<FootSize>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<FullName>.Value.Length > 0 Then
                            If Not IsNothing(orph.Name) Then
                                ret.Add(key.<Orphan>.<FullName>.Value & StringToAdd, Getter.GetFullName(orph.Name))
                            Else
                                ret.Add(key.<Orphan>.<FullName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<Gender>.Value.Length > 0 Then
                            If Not IsNothing(orph.Gender) Then
                                ret.Add(key.<Orphan>.<Gender>.Value & StringToAdd, orph.Gender)
                            Else
                                ret.Add(key.<Orphan>.<Gender>.Value & StringToAdd, "")
                            End If
                        End If
                        'Health
                        If key.<Orphan>.<Health>.<ReporteFile>.Value.Length > 0 Then
                            If orph.Health_ID.HasValue AndAlso Not IsNothing(orph.Healthy.ReporteFile) Then
                                Dim img As Image = Image.FromStream(New MemoryStream(orph.Healthy.ReporteFile))
                                Imgs.Add(key.<Orphan>.<Health>.<ReporteFile>.Value & StringToAdd, img)
                            End If
                        End If
                        If key.<Orphan>.<Health>.<Cost>.Value.Length > 0 Then
                            If orph.Health_ID.HasValue AndAlso Not IsNothing(orph.Healthy) AndAlso Not IsNothing(orph.Healthy.Cost) Then
                                ret.Add(key.<Orphan>.<Health>.<Cost>.Value & StringToAdd, orph.Healthy.Cost)
                            Else
                                ret.Add(key.<Orphan>.<Health>.<Cost>.Value & StringToAdd, "")
                            End If
                        End If
                        If orph.Health_ID.HasValue AndAlso key.<Orphan>.<Health>.<Medicen>.Value.Length > 0 Then
                            If Not IsNothing(orph.Healthy) AndAlso Not IsNothing(orph.Healthy.Medicen) Then
                                ret.Add(key.<Orphan>.<Health>.<Medicen>.Value & StringToAdd, orph.Healthy.Medicen.Replace(";", " "))
                            Else
                                ret.Add(key.<Orphan>.<Health>.<Medicen>.Value & StringToAdd, "")
                            End If
                        End If
                        If orph.Health_ID.HasValue AndAlso key.<Orphan>.<Health>.<Name>.Value.Length > 0 Then
                            If Not IsNothing(orph.Healthy) AndAlso Not IsNothing(orph.Healthy.Name) Then
                                ret.Add(key.<Orphan>.<Health>.<Name>.Value & StringToAdd, orph.Healthy.Name.Replace(";", " "))
                            Else
                                ret.Add(key.<Orphan>.<Health>.<Name>.Value & StringToAdd, "")
                            End If
                        End If
                        If orph.Health_ID.HasValue AndAlso key.<Orphan>.<Health>.<Note>.Value.Length > 0 Then
                            If Not IsNothing(orph.Healthy) AndAlso Not IsNothing(orph.Healthy.Note) Then
                                ret.Add(key.<Orphan>.<Health>.<Note>.Value & StringToAdd, orph.Healthy.Note)
                            Else
                                ret.Add(key.<Orphan>.<Health>.<Note>.Value & StringToAdd, "")
                            End If
                        End If
                        If orph.Health_ID.HasValue AndAlso key.<Orphan>.<Health>.<SupervisorDoctor>.Value.Length > 0 Then
                            If Not IsNothing(orph.Healthy) AndAlso Not IsNothing(orph.Healthy.SupervisorDoctor) Then
                                ret.Add(key.<Orphan>.<Health>.<SupervisorDoctor>.Value & StringToAdd, orph.Healthy.SupervisorDoctor)
                            Else
                                ret.Add(key.<Orphan>.<Health>.<SupervisorDoctor>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<IdentityNumber>.Value.Length > 0 Then
                            If Not IsNothing(orph.IdentityNumber) Then
                                ret.Add(key.<Orphan>.<IdentityNumber>.Value & StringToAdd, orph.IdentityNumber.ToString())
                            Else
                                ret.Add(key.<Orphan>.<IdentityNumber>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<IsBailed>.Value.Length > 0 Then
                            If Not IsNothing(orph.IsBailed) Then
                                If Not UseCustomBool Then
                                    ret.Add(key.<Orphan>.<IsBailed>.Value & StringToAdd, IIf(orph.IsBailed, YesBool, NoBool))
                                Else
                                    boolBookmark.Add(key.<Orphan>.<IsBailed>.Value & StringToAdd, IIf(orph.IsBailed, YesBool, NoBool))
                                End If
                            Else
                                If Not UseCustomBool Then
                                    ret.Add(key.<Orphan>.<IsBailed>.Value & StringToAdd, NoBool)
                                Else
                                    boolBookmark.Add(key.<Orphan>.<IsBailed>.Value & StringToAdd, NoBool)
                                End If
                            End If
                        End If

                        If key.<Orphan>.<IsSick>.Value.Length > 0 Then
                            If orph.Health_ID.HasValue Then
                                If Not UseCustomBool Then
                                    ret.Add(key.<Orphan>.<IsSick>.Value & StringToAdd, YesBool)
                                Else
                                    boolBookmark.Add(key.<Orphan>.<IsSick>.Value & StringToAdd, YesBool)
                                End If
                            Else
                                If Not UseCustomBool Then
                                    ret.Add(key.<Orphan>.<IsSick>.Value & StringToAdd, NoBool)
                                Else
                                    boolBookmark.Add(key.<Orphan>.<IsSick>.Value & StringToAdd, NoBool)
                                End If
                            End If
                        End If
                        If key.<Orphan>.<IsStudy>.Value.Length > 0 Then
                            If orph.Education_ID.HasValue Then
                                If Not UseCustomBool Then
                                    ret.Add(key.<Orphan>.<IsStudy>.Value & StringToAdd, YesBool)
                                Else
                                    boolBookmark.Add(key.<Orphan>.<IsStudy>.Value & StringToAdd, YesBool)
                                End If
                            Else
                                If Not UseCustomBool Then
                                    ret.Add(key.<Orphan>.<IsStudy>.Value & StringToAdd, NoBool)
                                Else
                                    boolBookmark.Add(key.<Orphan>.<IsStudy>.Value & StringToAdd, NoBool)
                                End If
                            End If
                        End If
                        If key.<Orphan>.<Kaid>.Value.Length > 0 Then
                            If Not IsNothing(orph.Kaid) Then
                                ret.Add(key.<Orphan>.<Kaid>.Value & StringToAdd, orph.Kaid)
                            Else
                                ret.Add(key.<Orphan>.<Kaid>.Value & StringToAdd, "")
                            End If

                        End If
                        If key.<Orphan>.<LastName>.Value.Length > 0 Then
                            If Not IsNothing(orph.Name.Last) Then
                                ret.Add(key.<Orphan>.<LastName>.Value & StringToAdd, orph.Name.Last)
                            Else
                                ret.Add(key.<Orphan>.<LastName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<MaleBrothersCount>.Value.Length > 0 Then
                            If Not IsNothing(Fam.Orphans) Then
                                Dim Mb As Integer = Getter.GetFamilyMaleOrphansCount(Fam.ID)
                                If orph.Gender.Contains("ذ") Then
                                    If Mb > 0 Then Mb -= 1
                                End If
                                ret.Add(key.<Orphan>.<MaleBrothersCount>.Value & StringToAdd, Mb)
                            Else
                                ret.Add(key.<Orphan>.<MaleBrothersCount>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<RegDate>.Value.Length > 0 Then
                            If Not IsNothing(orph.RegDate) Then
                                ret.Add(key.<Orphan>.<RegDate>.Value & StringToAdd, orph.RegDate.ToString(My.Settings.GeneralDateFormat))
                            Else
                                ret.Add(key.<Orphan>.<RegDate>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<Story>.Value.Length > 0 Then
                            If Not IsNothing(orph.Story) Then
                                ret.Add(key.<Orphan>.<Story>.Value & StringToAdd, orph.Story)
                            Else
                                ret.Add(key.<Orphan>.<Story>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<Tallness>.Value.Length > 0 Then
                            If Not IsNothing(orph.Tallness) Then
                                ret.Add(key.<Orphan>.<Tallness>.Value & StringToAdd, orph.Tallness)
                            Else
                                ret.Add(key.<Orphan>.<Tallness>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<Orphan>.<Weight>.Value.Length > 0 Then
                            If Not IsNothing(orph.Weight) Then
                                ret.Add(key.<Orphan>.<Weight>.Value & StringToAdd, orph.Weight)
                            Else
                                ret.Add(key.<Orphan>.<Weight>.Value & StringToAdd, "")
                            End If
                        End If
                        'BondsMan
                        If Not IsRepeatedBondMan Then
                            StringToAdd = ""
                            If CurrentOrphanNumber > 1 Then Continue Do
                        End If
                        If key.<BondsMan>.<IdentityCardPhoto1>.Value.Length > 0 Then
                            If Not IsNothing(Bond.IdentityCard_Photo) Then
                                Dim img As Image = Image.FromStream(New MemoryStream(Bond.IdentityCard_Photo))
                                Imgs.Add(key.<BondsMan>.<IdentityCardPhoto1>.Value & StringToAdd, img)
                            End If
                        End If
                        If key.<BondsMan>.<IdentityCardPhoto2>.Value.Length > 0 Then
                            If Not IsNothing(Bond.IdentityCard_Photo2) Then
                                Dim img As Image = Image.FromStream(New MemoryStream(Bond.IdentityCard_Photo2))
                                Imgs.Add(key.<BondsMan>.<IdentityCardPhoto2>.Value & StringToAdd, img)
                            End If
                        End If
                        If key.<BondsMan>.<EFatherName>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Name.EFather) Then
                                ret.Add(key.<BondsMan>.<EFatherName>.Value & StringToAdd, Bond.Name.EFather)
                            Else
                                ret.Add(key.<BondsMan>.<EFatherName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<FirstName>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Name.First) Then
                                ret.Add(key.<BondsMan>.<FirstName>.Value & StringToAdd, Bond.Name.First)
                            Else
                                ret.Add(key.<BondsMan>.<FirstName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<EFirstName>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Name.EName) Then
                                ret.Add(key.<BondsMan>.<EFirstName>.Value & StringToAdd, Bond.Name.EName)
                            Else
                                ret.Add(key.<BondsMan>.<EFirstName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<EFullName>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Name) Then
                                ret.Add(key.<BondsMan>.<EFullName>.Value & StringToAdd, Getter.GetFullNameE(Bond.Name))
                            Else
                                ret.Add(key.<BondsMan>.<EFullName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<ELastName>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Name.ELast) Then
                                ret.Add(key.<BondsMan>.<ELastName>.Value & StringToAdd, Bond.Name.ELast)
                            Else
                                ret.Add(key.<BondsMan>.<ELastName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<FatherName>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Name.Father) Then
                                ret.Add(key.<BondsMan>.<FatherName>.Value & StringToAdd, Bond.Name.Father)
                            Else
                                ret.Add(key.<BondsMan>.<FatherName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<FullName>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Name) Then
                                ret.Add(key.<BondsMan>.<FullName>.Value & StringToAdd, Getter.GetFullName(Bond.Name))
                            Else
                                ret.Add(key.<BondsMan>.<FullName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<IdentityCardNumber>.Value.Length > 0 Then
                            If Not IsNothing(Bond.IdentityCard_ID) Then
                                ret.Add(key.<BondsMan>.<IdentityCardNumber>.Value & StringToAdd, Bond.IdentityCard_ID)
                            Else
                                ret.Add(key.<BondsMan>.<IdentityCardNumber>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<Jop>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Jop) Then
                                ret.Add(key.<BondsMan>.<Jop>.Value & StringToAdd, Bond.Jop)
                            Else
                                ret.Add(key.<BondsMan>.<Jop>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<LastName>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Name.Last) Then
                                ret.Add(key.<BondsMan>.<LastName>.Value & StringToAdd, Bond.Name.Last)
                            Else
                                ret.Add(key.<BondsMan>.<LastName>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<Note>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Note) Then
                                ret.Add(key.<BondsMan>.<Note>.Value & StringToAdd, Bond.Note)
                            Else
                                ret.Add(key.<BondsMan>.<Note>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<Salary>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Income) Then
                                ret.Add(key.<BondsMan>.<Salary>.Value & StringToAdd, Bond.Income)
                            Else
                                ret.Add(key.<BondsMan>.<Salary>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<Address>.<CellPhone>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Cell_Phone) AndAlso Not Bond.Address.Cell_Phone.Contains("(000") Then
                                ret.Add(key.<BondsMan>.<Address>.<CellPhone>.Value & StringToAdd, Bond.Address.Cell_Phone)
                            Else
                                ret.Add(key.<BondsMan>.<Address>.<CellPhone>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<Address>.<City>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.City) Then
                                ret.Add(key.<BondsMan>.<Address>.<City>.Value & StringToAdd, Bond.Address.City)
                            Else
                                ret.Add(key.<BondsMan>.<Address>.<City>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<Address>.<Email>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Email) Then
                                ret.Add(key.<BondsMan>.<Address>.<Email>.Value & StringToAdd, Bond.Address.Email)
                            Else
                                ret.Add(key.<BondsMan>.<Address>.<Email>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<Address>.<Fax>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Fax) AndAlso Not Bond.Address.Fax.Contains("(000") Then
                                ret.Add(key.<BondsMan>.<Address>.<Fax>.Value & StringToAdd, Bond.Address.Fax)
                            Else
                                ret.Add(key.<BondsMan>.<Address>.<Fax>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<Address>.<HomePhone>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Home_Phone) AndAlso Not Bond.Address.Home_Phone.Contains("(000") Then
                                ret.Add(key.<BondsMan>.<Address>.<HomePhone>.Value & StringToAdd, Bond.Address.Home_Phone)
                            Else
                                ret.Add(key.<BondsMan>.<Address>.<HomePhone>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<Address>.<State>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Country) Then
                                ret.Add(key.<BondsMan>.<Address>.<State>.Value & StringToAdd, Bond.Address.Country)
                            Else
                                ret.Add(key.<BondsMan>.<Address>.<State>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<Address>.<Street>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Street) Then
                                ret.Add(key.<BondsMan>.<Address>.<Street>.Value & StringToAdd, Bond.Address.Street)
                            Else
                                ret.Add(key.<BondsMan>.<Address>.<Street>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<Address>.<Town>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Town) Then
                                ret.Add(key.<BondsMan>.<Address>.<Town>.Value & StringToAdd, Bond.Address.Town)
                            Else
                                ret.Add(key.<BondsMan>.<Address>.<Town>.Value & StringToAdd, "")
                            End If
                        End If
                        If key.<BondsMan>.<Address>.<WorkPhone>.Value.Length > 0 Then
                            If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Work_Phone) AndAlso Not Bond.Address.Work_Phone.Contains("(000") Then
                                ret.Add(key.<BondsMan>.<Address>.<WorkPhone>.Value & StringToAdd, Bond.Address.Work_Phone)
                            Else
                                ret.Add(key.<BondsMan>.<Address>.<WorkPhone>.Value & StringToAdd, "")
                            End If
                        End If
                    Loop While CurrentOrphanNumber < MaxOrphanCount
                    'Family
                    If key.<Family>.<FamilyCardPhoto1>.Value.Length > 0 Then
                        If Not IsNothing(Fam.FamilyCardPhoto) Then
                            Dim img As Image = Image.FromStream(New MemoryStream(Fam.FamilyCardPhoto))
                            Imgs.Add(key.<Family>.<FamilyCardPhoto1>.Value, img)
                        End If
                    End If
                    If key.<Family>.<FamilyCardPhoto2>.Value.Length > 0 Then
                        If Not IsNothing(Fam.FamilyCardPhotoP2) Then
                            Dim img As Image = Image.FromStream(New MemoryStream(Fam.FamilyCardPhotoP2))
                            Imgs.Add(key.<Family>.<FamilyCardPhoto2>.Value, img)
                        End If
                    End If
                    If key.<Family>.<Address>.<Main>.<CellPhone>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Cell_Phone) AndAlso Not Fam.Address.Cell_Phone.Contains("(000") Then
                            ret.Add(key.<Family>.<Address>.<Main>.<CellPhone>.Value, Fam.Address.Cell_Phone)
                        Else
                            ret.Add(key.<Family>.<Address>.<Main>.<CellPhone>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Main>.<City>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.City) Then
                            ret.Add(key.<Family>.<Address>.<Main>.<City>.Value, Fam.Address.City)
                        Else
                            ret.Add(key.<Family>.<Address>.<Main>.<City>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Main>.<Email>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Email) Then
                            ret.Add(key.<Family>.<Address>.<Main>.<Email>.Value, Fam.Address.Email)
                        Else
                            ret.Add(key.<Family>.<Address>.<Main>.<Email>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Main>.<Fax>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Fax) AndAlso Not Fam.Address.Fax.Contains("(000") Then
                            ret.Add(key.<Family>.<Address>.<Main>.<Fax>.Value, Fam.Address.Fax)
                        Else
                            ret.Add(key.<Family>.<Address>.<Main>.<Fax>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Main>.<HomePhone>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Home_Phone) AndAlso Not Fam.Address.Home_Phone.Contains("(000") Then
                            ret.Add(key.<Family>.<Address>.<Main>.<HomePhone>.Value, Fam.Address.Home_Phone)
                        Else
                            ret.Add(key.<Family>.<Address>.<Main>.<HomePhone>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Main>.<State>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Country) Then
                            ret.Add(key.<Family>.<Address>.<Main>.<State>.Value, Fam.Address.Country)
                        Else
                            ret.Add(key.<Family>.<Address>.<Main>.<State>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Main>.<Street>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Street) Then
                            ret.Add(key.<Family>.<Address>.<Main>.<Street>.Value, Fam.Address.Street)
                        Else
                            ret.Add(key.<Family>.<Address>.<Main>.<Street>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Main>.<Town>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Town) Then
                            ret.Add(key.<Family>.<Address>.<Main>.<Town>.Value, Fam.Address.Town)
                        Else
                            ret.Add(key.<Family>.<Address>.<Main>.<Town>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Main>.<WorkPhone>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Work_Phone) AndAlso Not Fam.Address.Work_Phone.Contains("(000") Then
                            ret.Add(key.<Family>.<Address>.<Main>.<WorkPhone>.Value, Fam.Address.Work_Phone)
                        Else
                            ret.Add(key.<Family>.<Address>.<Main>.<WorkPhone>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Current>.<CellPhone>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Cell_Phone) AndAlso Not Fam.Address.Cell_Phone.Contains("(000") Then
                            ret.Add(key.<Family>.<Address>.<Current>.<CellPhone>.Value, Fam.Address1.Cell_Phone)
                        Else
                            ret.Add(key.<Family>.<Address>.<Current>.<CellPhone>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Current>.<City>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.City) Then
                            ret.Add(key.<Family>.<Address>.<Current>.<City>.Value, Fam.Address1.City)
                        Else
                            ret.Add(key.<Family>.<Address>.<Current>.<City>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Current>.<Email>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Email) Then
                            ret.Add(key.<Family>.<Address>.<Current>.<Email>.Value, Fam.Address1.Email)
                        Else
                            ret.Add(key.<Family>.<Address>.<Current>.<Email>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Current>.<Fax>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Fax) AndAlso Not Fam.Address1.Fax.Contains("(000") Then
                            ret.Add(key.<Family>.<Address>.<Current>.<Fax>.Value, Fam.Address1.Fax)
                        Else
                            ret.Add(key.<Family>.<Address>.<Current>.<Fax>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Current>.<HomePhone>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Home_Phone) AndAlso Not Fam.Address1.Home_Phone.Contains("(000") Then
                            ret.Add(key.<Family>.<Address>.<Current>.<HomePhone>.Value, Fam.Address1.Home_Phone)
                        Else
                            ret.Add(key.<Family>.<Address>.<Current>.<HomePhone>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Current>.<State>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Country) Then
                            ret.Add(key.<Family>.<Address>.<Current>.<State>.Value, Fam.Address1.Country)
                        Else
                            ret.Add(key.<Family>.<Address>.<Current>.<State>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Current>.<Street>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Street) Then
                            ret.Add(key.<Family>.<Address>.<Current>.<Street>.Value, Fam.Address1.Street)
                        Else
                            ret.Add(key.<Family>.<Address>.<Current>.<Street>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Current>.<Town>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Town) Then
                            ret.Add(key.<Family>.<Address>.<Current>.<Town>.Value, Fam.Address1.Town)
                        Else
                            ret.Add(key.<Family>.<Address>.<Current>.<Town>.Value, "")
                        End If
                    End If
                    If key.<Family>.<Address>.<Current>.<WorkPhone>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Work_Phone) AndAlso Not Fam.Address1.Work_Phone.Contains("(000") Then
                            ret.Add(key.<Family>.<Address>.<Current>.<WorkPhone>.Value, Fam.Address1.Work_Phone)
                        Else
                            ret.Add(key.<Family>.<Address>.<Current>.<WorkPhone>.Value, "")
                        End If
                    End If
                    If key.<Family>.<FamilyCardNumber>.Value.Length > 0 Then
                        If Not IsNothing(Fam.FamilyCard_Num) Then
                            ret.Add(key.<Family>.<FamilyCardNumber>.Value, Fam.FamilyCard_Num)
                        Else
                            ret.Add(key.<Family>.<FamilyCardNumber>.Value, "")
                        End If
                    End If
                    If key.<Family>.<FinnacialState>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Finncial_Sate) Then
                            ret.Add(key.<Family>.<FinnacialState>.Value, Fam.Finncial_Sate)
                        Else
                            ret.Add(key.<Family>.<FinnacialState>.Value, "")
                        End If
                    End If
                    If key.<Family>.<IsRefugee>.Value.Length > 0 Then
                        If Not IsNothing(Fam.IsRefugee) Then
                            If Not UseCustomBool Then
                                ret.Add(key.<Family>.<IsRefugee>.Value, IIf(Fam.IsRefugee, YesBool, NoBool))
                            Else
                                boolBookmark.Add(key.<Family>.<IsRefugee>.Value, CInt(IIf(Fam.IsRefugee, YesBool, NoBool)))
                            End If
                        Else
                            If Not UseCustomBool Then
                                ret.Add(key.<Family>.<IsRefugee>.Value, NoBool)
                            Else
                                boolBookmark.Add(key.<Family>.<IsRefugee>.Value, NoBool)
                            End If
                        End If
                    End If
                    If key.<Family>.<ResidenceState>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Residece_Sate) Then
                            ret.Add(key.<Family>.<ResidenceState>.Value, Fam.Residece_Sate)
                        Else
                            ret.Add(key.<Family>.<ResidenceState>.Value, "")
                        End If
                    End If
                    If key.<Family>.<ResidenceType>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Residenc_Type) Then
                            ret.Add(key.<Family>.<ResidenceType>.Value, Fam.Residenc_Type)
                        Else
                            ret.Add(key.<Family>.<ResidenceType>.Value, "")
                        End If
                    End If
                    'Father
                    If key.<Father>.<DeathCertificate_Photo>.Value.Length > 0 Then
                        If Not IsNothing(Fath.DeathCertificate_Photo) Then
                            Dim img As Image = Image.FromStream(New MemoryStream(Fath.DeathCertificate_Photo))
                            Imgs.Add(key.<Father>.<DeathCertificate_Photo>.Value, img)
                        End If
                    End If
                    If key.<Father>.<Photo>.Value.Length > 0 Then
                        If Not IsNothing(Fath.Photo) Then
                            Dim img As Image = Image.FromStream(New MemoryStream(Fath.Photo))
                            Imgs.Add(key.<Father>.<Photo>.Value, img)
                        End If
                    End If
                    If key.<Father>.<Age>.Value.Length > 0 Then
                        If Not IsNothing(Fath.Birthday) Then
                            Dim dt As New Itenso.TimePeriod.DateDiff(Fath.Birthday, Fath.Dieday)
                            ret.Add(key.<Father>.<Age>.Value, ATDFormater.ArabicDateFormater.GetArabicYear(dt.ElapsedYears))
                        Else
                            ret.Add(key.<Father>.<Age>.Value, "")
                        End If
                    End If
                    If key.<Father>.<Birthday>.Value.Length > 0 Then
                        If Not IsNothing(Fath.Birthday) Then
                            ret.Add(key.<Father>.<Birthday>.Value, Fath.Birthday.ToString(My.Settings.GeneralDateFormat))
                        Else
                            ret.Add(key.<Father>.<Birthday>.Value, "")
                        End If
                    End If
                    If key.<Father>.<DeathReason>.Value.Length > 0 Then
                        If Not IsNothing(Fath.DeathResone) Then
                            ret.Add(key.<Father>.<DeathReason>.Value, Fath.DeathResone)
                        Else
                            ret.Add(key.<Father>.<DeathReason>.Value, "")
                        End If
                    End If
                    If key.<Father>.<Deathday>.Value.Length > 0 Then
                        If Not IsNothing(Fath.Dieday) Then
                            ret.Add(key.<Father>.<Deathday>.Value, Fath.Dieday.ToString(My.Settings.GeneralDateFormat))
                        Else
                            ret.Add(key.<Father>.<Deathday>.Value, "")
                        End If
                    End If
                    If key.<Father>.<EFatherName>.Value.Length > 0 Then
                        If Not IsNothing(Fath.Name.EFather) Then
                            ret.Add(key.<Father>.<EFatherName>.Value, Fath.Name.EFather)
                        Else
                            ret.Add(key.<Father>.<EFatherName>.Value, "")
                        End If
                    End If
                    If key.<Father>.<EFirstName>.Value.Length > 0 Then
                        If Not IsNothing(Fath.Name.EName) Then
                            ret.Add(key.<Father>.<EFirstName>.Value, Fath.Name.EName)
                        Else
                            ret.Add(key.<Father>.<EFirstName>.Value, "")
                        End If
                    End If
                    If key.<Father>.<EFullName>.Value.Length > 0 Then
                        If Not IsNothing(Fath.Name.EName) Then
                            ret.Add(key.<Father>.<EFullName>.Value, Getter.GetFullNameE(Fath.Name))
                        Else
                            ret.Add(key.<Father>.<EFullName>.Value, "")
                        End If
                    End If
                    If key.<Father>.<ELastName>.Value.Length > 0 Then
                        If Not IsNothing(Fath.Name.ELast) Then
                            ret.Add(key.<Father>.<ELastName>.Value, Fath.Name.ELast)
                        Else
                            ret.Add(key.<Father>.<ELastName>.Value, "")
                        End If
                    End If
                    If key.<Father>.<FatherName>.Value.Length > 0 Then
                        If Not IsNothing(Fath.Name.Father) Then
                            ret.Add(key.<Father>.<FatherName>.Value, Fath.Name.Father)
                        Else
                            ret.Add(key.<Father>.<FatherName>.Value, "")
                        End If
                    End If
                    If key.<Father>.<FirstName>.Value.Length > 0 Then
                        If Not IsNothing(Fath.Name.First) Then
                            ret.Add(key.<Father>.<FirstName>.Value, Fath.Name.First)
                        Else
                            ret.Add(key.<Father>.<FirstName>.Value, "")
                        End If
                    End If
                    If key.<Father>.<FullName>.Value.Length > 0 Then
                        If Not IsNothing(Fath.Name.First) Then
                            ret.Add(key.<Father>.<FullName>.Value, Getter.GetFullName(Fath.Name))
                        Else
                            ret.Add(key.<Father>.<FullName>.Value, "")
                        End If
                    End If
                    If key.<Father>.<LastName>.Value.Length > 0 Then
                        If Not IsNothing(Fath.Name.Last) Then
                            ret.Add(key.<Father>.<LastName>.Value, Fath.Name.Last)
                        Else
                            ret.Add(key.<Father>.<LastName>.Value, "")
                        End If
                    End If
                    If key.<Father>.<IdentityCardNumber>.Value.Length > 0 Then
                        If Not IsNothing(Fath.IdentityCard_ID) Then
                            ret.Add(key.<Father>.<IdentityCardNumber>.Value, Fath.IdentityCard_ID)
                        Else
                            ret.Add(key.<Father>.<IdentityCardNumber>.Value, "")
                        End If
                    End If
                    If key.<Father>.<Jop>.Value.Length > 0 Then
                        If Not IsNothing(Fath.Jop) Then
                            ret.Add(key.<Father>.<Jop>.Value, Fath.Jop)
                        Else
                            ret.Add(key.<Father>.<Jop>.Value, "")
                        End If
                    End If
                    If key.<Father>.<Note>.Value.Length > 0 Then
                        If Not IsNothing(Fath.Note) Then
                            ret.Add(key.<Father>.<Note>.Value, Fath.Note)
                        Else
                            ret.Add(key.<Father>.<Note>.Value, "")
                        End If
                    End If
                    If key.<Father>.<Story>.Value.Length > 0 Then
                        If Not IsNothing(Fath.Story) Then
                            ret.Add(key.<Father>.<Story>.Value, Fath.Story)
                        Else
                            ret.Add(key.<Father>.<Story>.Value, "")
                        End If
                    End If
                    'Mother
                    If key.<Mother>.<IdentityCardPhoto1>.Value.Length > 0 Then
                        If Not IsNothing(Moth.IdentityCard_Photo) Then
                            Dim img As Image = Image.FromStream(New MemoryStream(Moth.IdentityCard_Photo))
                            Imgs.Add(key.<Mother>.<IdentityCardPhoto1>.Value, img)
                        End If
                    End If
                    If key.<Mother>.<IdentityCardPhoto2>.Value.Length > 0 Then
                        If Not IsNothing(Moth.IdentityCard_Photo2) Then
                            Dim img As Image = Image.FromStream(New MemoryStream(Moth.IdentityCard_Photo2))
                            Imgs.Add(key.<Mother>.<IdentityCardPhoto2>.Value, img)
                        End If
                    End If
                    If key.<Mother>.<Age>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Birthday) Then
                            Dim dt = New Itenso.TimePeriod.DateDiff(Moth.Birthday, Date.Now)
                            If Moth.IsDead AndAlso Moth.Dieday.HasValue Then
                                dt = New Itenso.TimePeriod.DateDiff(Moth.Birthday, Moth.Dieday)
                            Else
                                dt = New Itenso.TimePeriod.DateDiff(Moth.Birthday, Date.Now)
                            End If
                            ret.Add(key.<Mother>.<Age>.Value, ATDFormater.ArabicDateFormater.GetArabicYear(dt.ElapsedYears))
                        Else
                            ret.Add(key.<Mother>.<Age>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<Birthday>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Birthday) Then
                            ret.Add(key.<Mother>.<Birthday>.Value, Moth.Birthday.ToString(My.Settings.GeneralDateFormat))
                        Else
                            ret.Add(key.<Mother>.<Birthday>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<Deathday>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Dieday) AndAlso Moth.IsDead Then
                            ret.Add(key.<Mother>.<Deathday>.Value, Moth.Dieday.Value.ToString(My.Settings.GeneralDateFormat))
                        Else
                            ret.Add(key.<Mother>.<Deathday>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<EFatherName>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Name.EFather) Then
                            ret.Add(key.<Mother>.<EFatherName>.Value, Moth.Name.EFather)
                        Else
                            ret.Add(key.<Mother>.<EFatherName>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<EFirstName>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Name.EName) Then
                            ret.Add(key.<Mother>.<EFirstName>.Value, Moth.Name.EName)
                        Else
                            ret.Add(key.<Mother>.<EFirstName>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<EFullName>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Name.EName) Then
                            ret.Add(key.<Mother>.<EFullName>.Value, Getter.GetFullNameE(Moth.Name))
                        Else
                            ret.Add(key.<Mother>.<EFullName>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<ELastName>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Name.ELast) Then
                            ret.Add(key.<Mother>.<ELastName>.Value, Moth.Name.ELast)
                        Else
                            ret.Add(key.<Mother>.<ELastName>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<FatherName>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Name.Father) Then
                            ret.Add(key.<Mother>.<FatherName>.Value, Moth.Name.Father)
                        Else
                            ret.Add(key.<Mother>.<FatherName>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<FirstName>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Name.First) Then
                            ret.Add(key.<Mother>.<FirstName>.Value, Moth.Name.First)
                        Else
                            ret.Add(key.<Mother>.<FirstName>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<FullName>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Name.First) Then
                            ret.Add(key.<Mother>.<FullName>.Value, Getter.GetFullName(Moth.Name))
                        Else
                            ret.Add(key.<Mother>.<FullName>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<IdentityCardNumber>.Value.Length > 0 Then
                        If Not IsNothing(Moth.IdntityCard_ID) Then
                            ret.Add(key.<Mother>.<IdentityCardNumber>.Value, Moth.IdntityCard_ID)
                        Else
                            ret.Add(key.<Mother>.<IdentityCardNumber>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<IsDead>.Value.Length > 0 Then
                        If Not IsNothing(Moth.IsDead) Then
                            If Not UseCustomBool Then
                                ret.Add(key.<Mother>.<IsDead>.Value, IIf(Moth.IsDead, YesBool, NoBool))
                            Else
                                boolBookmark.Add(key.<Mother>.<IsDead>.Value, CInt(IIf(Moth.IsDead, YesBool, NoBool)))
                            End If
                        Else
                            If Not UseCustomBool Then
                                ret.Add(key.<Mother>.<IsDead>.Value, NoBool)
                            Else
                                boolBookmark.Add(key.<Mother>.<IsDead>.Value, NoBool)
                            End If
                        End If
                    End If
                    If key.<Mother>.<IsMarried>.Value.Length > 0 Then
                        If Not IsNothing(Moth.IsMarried) Then
                            If Not UseCustomBool Then
                                ret.Add(key.<Mother>.<IsMarried>.Value, IIf(Moth.IsMarried, YesBool, NoBool))
                            Else
                                boolBookmark.Add(key.<Mother>.<IsMarried>.Value, CInt(IIf(Moth.IsMarried, YesBool, NoBool)))
                            End If
                        Else
                            If Not UseCustomBool Then
                                ret.Add(key.<Mother>.<IsMarried>.Value, NoBool)
                            Else
                                boolBookmark.Add(key.<Mother>.<IsMarried>.Value, NoBool)
                            End If
                        End If
                    End If
                    If key.<Mother>.<IsOwnOrphans>.Value.Length > 0 Then
                        If Not IsNothing(Moth.IsOwnOrphans) Then
                            If Not UseCustomBool Then
                                ret.Add(key.<Mother>.<IsOwnOrphans>.Value, IIf(Moth.IsOwnOrphans, YesBool, NoBool))
                            Else
                                boolBookmark.Add(key.<Mother>.<IsOwnOrphans>.Value, CInt(IIf(Moth.IsOwnOrphans, YesBool, NoBool)))
                            End If
                        Else
                            If Not UseCustomBool Then
                                ret.Add(key.<Mother>.<IsOwnOrphans>.Value, NoBool)
                            Else
                                boolBookmark.Add(key.<Mother>.<IsOwnOrphans>.Value, NoBool)
                            End If
                        End If
                    End If
                    If key.<Mother>.<Jop>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Jop) Then
                            ret.Add(key.<Mother>.<Jop>.Value, Moth.Jop)
                        Else
                            ret.Add(key.<Mother>.<Jop>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<Note>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Note) Then
                            ret.Add(key.<Mother>.<Note>.Value, Moth.Note)
                        Else
                            ret.Add(key.<Mother>.<Note>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<Salary>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Salary) AndAlso Moth.Salary.HasValue Then
                            ret.Add(key.<Mother>.<Salary>.Value, Moth.Salary.ToString())
                        Else
                            ret.Add(key.<Mother>.<Salary>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<Story>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Story) Then
                            ret.Add(key.<Mother>.<Story>.Value, Moth.Story)
                        Else
                            ret.Add(key.<Mother>.<Story>.Value, "")
                        End If
                    End If
                    If Moth.Address_ID.HasValue Then
                        If key.<Mother>.<Address>.<CellPhone>.Value.Length > 0 Then
                            If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Cell_Phone) AndAlso Not Moth.Address.Cell_Phone.Contains("(000") Then
                                ret.Add(key.<Mother>.<Address>.<CellPhone>.Value, Moth.Address.Cell_Phone)
                            Else
                                ret.Add(key.<Mother>.<Address>.<CellPhone>.Value, "")
                            End If
                        End If
                        If key.<Mother>.<Address>.<City>.Value.Length > 0 Then
                            If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.City) Then
                                ret.Add(key.<Mother>.<Address>.<City>.Value, Moth.Address.City)
                            Else
                                ret.Add(key.<Mother>.<Address>.<City>.Value, "")
                            End If
                        End If
                        If key.<Mother>.<Address>.<Email>.Value.Length > 0 Then
                            If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Email) Then
                                ret.Add(key.<Mother>.<Address>.<Email>.Value, Moth.Address.Email)
                            Else
                                ret.Add(key.<Mother>.<Address>.<Email>.Value, "")
                            End If
                        End If
                        If key.<Mother>.<Address>.<Fax>.Value.Length > 0 Then
                            If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Fax) AndAlso Not Moth.Address.Fax.Contains("(000") Then
                                ret.Add(key.<Mother>.<Address>.<Fax>.Value, Moth.Address.Fax)
                            Else
                                ret.Add(key.<Mother>.<Address>.<Fax>.Value, "")
                            End If
                        End If
                        If key.<Mother>.<Address>.<HomePhone>.Value.Length > 0 Then
                            If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Home_Phone) AndAlso Not Moth.Address.Home_Phone.Contains("(000") Then
                                ret.Add(key.<Mother>.<Address>.<HomePhone>.Value, Moth.Address.Home_Phone)
                            Else
                                ret.Add(key.<Mother>.<Address>.<HomePhone>.Value, "")
                            End If
                        End If
                        If key.<Mother>.<Address>.<State>.Value.Length > 0 Then
                            If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Country) Then
                                ret.Add(key.<Mother>.<Address>.<State>.Value, Moth.Address.Country)
                            Else
                                ret.Add(key.<Mother>.<Address>.<State>.Value, "")
                            End If
                        End If
                        If key.<Mother>.<Address>.<Street>.Value.Length > 0 Then
                            If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Street) Then
                                ret.Add(key.<Mother>.<Address>.<Street>.Value, Moth.Address.Street)
                            Else
                                ret.Add(key.<Mother>.<Address>.<Street>.Value, "")
                            End If
                        End If
                        If key.<Mother>.<Address>.<Town>.Value.Length > 0 Then
                            If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Town) Then
                                ret.Add(key.<Mother>.<Address>.<Town>.Value, Moth.Address.Town)
                            Else
                                ret.Add(key.<Mother>.<Address>.<Town>.Value, "")
                            End If
                        End If
                        If key.<Mother>.<Address>.<WorkPhone>.Value.Length > 0 Then
                            If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Work_Phone) AndAlso Not Moth.Address.Work_Phone.Contains("(000") Then
                                ret.Add(key.<Mother>.<Address>.<WorkPhone>.Value, Moth.Address.Work_Phone)
                            Else
                                ret.Add(key.<Mother>.<Address>.<WorkPhone>.Value, "")
                            End If
                        End If
                    End If
                    Exit For
                Next
                Exit For
            Next
        Else
            Return Nothing
        End If
        Return ret
    End Function

    Public Function Fill_CustomString(ByVal orph As OrphanageClasses.Orphan, ByVal TempName As String, ByVal DestinationFile As String, ByRef Imgs As Dictionary(Of String, Image), ByRef UseBookMark As Boolean, ByRef useDefaultPicSize As Boolean, ByRef defautlPicSize As Size, ByRef boolBookmark As Dictionary(Of String, Integer), Optional ByRef CustomFont As String = "") As Dictionary(Of String, String)
        If Not File.Exists(FrmNewTemplate.xmlFileName) Then
            Return Nothing
        End If
        If IsNothing(orph) Then Return Nothing
        If IsNothing(TempName) OrElse TempName.Length = 0 Then Return Nothing
        Dim ret As New Dictionary(Of String, String)
        Dim Fam = orph.Family
        Dim Bond = orph.BondsMan
        Dim Fath = Fam.Father
        Dim Moth = Fam.Mother
        Dim bail As OrphanageClasses.Bail = Nothing
        If orph.IsBailed AndAlso orph.Bail_ID.HasValue Then
            bail = orph.Bail
        Else
            If Fam.IsBaild AndAlso Fam.Baild_ID.HasValue Then
                bail = orph.Bail
            End If
        End If
        Dim xDoc As XDocument = XDocument.Load(FrmNewTemplate.xmlFileName)
        Dim q = From ele In xDoc.<Templates>.<Template> Where ele.<Name>.Value = TempName Select ele

        If Not IsNothing(q) AndAlso q.Count > 0 Then
            For Each xtemp In q
                Dim FileLength As Long = CLng(xtemp.<Size>.Value)
                UseBookMark = CBool(xtemp.<IsBookmarks>.Value)
                Dim UseCustomBool As Boolean = CBool(xtemp.<UseCustomBoolean>.Value())
                Dim YesBool, NoBool As String
                If UseCustomBool Then
                    boolBookmark = New Dictionary(Of String, Integer)
                    NoBool = CInt(xtemp.<BooleanNOMark>.Value)
                    YesBool = CInt(xtemp.<BooleanYesMark>.Value)
                Else
                    boolBookmark = Nothing
                    NoBool = xtemp.<BooleanNOMark>.Value
                    YesBool = xtemp.<BooleanYesMark>.Value
                End If
                CustomFont = xtemp.<BooleanFontName>.Value


                useDefaultPicSize = CBool(xtemp.<IsDefaultPictureWH>.Value)
                defautlPicSize = New Size(CInt(xtemp.<DefaultPictureW>.Value), CInt(xtemp.<DefaultPictureH>.Value))
                Dim Data() As Byte
                Data = AnotherDecode64(xtemp.<Data>.Value)
                Try
                    Dim mem As New MemoryStream(Data)
                    Dim zz As New FileStream(DestinationFile, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
                    mem.WriteTo(zz)
                    mem.Flush()
                    zz.Flush()
                    zz.Close()
                    mem.Close()
                    zz.Dispose()
                    mem.Dispose()
                Catch
                End Try
                For Each key In xtemp.<Bookmarks>
                    'Bail
                    If key.<Bail>.<Amount>.Value.Length > 0 Then
                        If Not IsNothing(bail) Then
                            ret.Add(key.<Bail>.<Amount>.Value, bail.Amount.ToString())
                        Else
                            ret.Add(key.<Bail>.<Amount>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<CurnceyName>.Value.Length > 0 Then
                        If Not IsNothing(bail) Then
                            ret.Add(key.<Bail>.<CurnceyName>.Value, bail.Box.Currency_Name.ToString())
                        Else
                            ret.Add(key.<Bail>.<CurnceyName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<CurnceyShort>.Value.Length > 0 Then
                        ret.Add(key.<Bail>.<CurnceyShort>.Value, bail.Box.Currency_Short.ToString())
                    End If
                    If key.<Bail>.<EndDate>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso bail.End_Date.HasValue Then
                            ret.Add(key.<Bail>.<EndDate>.Value, bail.End_Date.ToString(My.Settings.GeneralDateFormat))
                        Else
                            ret.Add(key.<Bail>.<EndDate>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<IsDated>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso bail.End_Date.HasValue AndAlso bail.Start_Date.HasValue Then
                            If Not UseCustomBool Then
                                ret.Add(key.<Bail>.<IsDated>.Value, YesBool)
                            Else
                                boolBookmark.Add(key.<Bail>.<IsDated>.Value, YesBool)
                            End If
                        Else
                            If Not UseCustomBool Then
                                ret.Add(key.<Bail>.<IsDated>.Value, NoBool)
                            Else
                                boolBookmark.Add(key.<Bail>.<IsDated>.Value, NoBool)
                            End If
                        End If
                    End If
                    If key.<Bail>.<IsFamily>.Value.Length > 0 Then
                        If Not IsNothing(bail) Then
                            If Not UseCustomBool Then
                                ret.Add(key.<Bail>.<IsFamily>.Value, IIf(bail.Is_Family, YesBool, NoBool))
                            Else
                                boolBookmark.Add(key.<Bail>.<IsFamily>.Value, IIf(bail.Is_Family, YesBool, NoBool))
                            End If
                        Else
                            If Not UseCustomBool Then
                                ret.Add(key.<Bail>.<IsFamily>.Value, NoBool)
                            Else
                                boolBookmark.Add(key.<Bail>.<IsFamily>.Value, NoBool)
                            End If
                        End If
                    End If
                    If key.<Bail>.<IsMonthly>.Value.Length > 0 Then
                        If Not IsNothing(bail) Then
                            If Not UseCustomBool Then
                                ret.Add(key.<Bail>.<IsMonthly>.Value, IIf(bail.IsMonthly, YesBool, NoBool))
                            Else
                                boolBookmark.Add(key.<Bail>.<IsMonthly>.Value, IIf(bail.IsMonthly, YesBool, NoBool))
                            End If
                        Else
                            If Not UseCustomBool Then
                                ret.Add(key.<Bail>.<IsMonthly>.Value, NoBool)
                            Else
                                boolBookmark.Add(key.<Bail>.<IsMonthly>.Value, NoBool)
                            End If
                        End If
                    End If
                    If key.<Bail>.<Note>.Value.Length > 0 Then
                        If Not IsNothing(bail) Then
                            ret.Add(key.<Bail>.<Note>.Value, bail.Note)
                        Else
                            ret.Add(key.<Bail>.<Note>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<StartDate>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso bail.Start_Date.HasValue Then
                            ret.Add(key.<Bail>.<StartDate>.Value, bail.Start_Date.ToString(My.Settings.GeneralDateFormat))
                        Else
                            ret.Add(key.<Bail>.<StartDate>.Value, "")
                        End If
                    End If
                    'SupoName
                    If key.<Bail>.<Supporter>.<EFatherName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.EFather) Then
                            ret.Add(key.<Bail>.<Supporter>.<EFatherName>.Value, bail.Supporter.Name.EFather)
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<EFatherName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<Supporter>.<EFirstName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.EName) Then
                            ret.Add(key.<Bail>.<Supporter>.<EFirstName>.Value, bail.Supporter.Name.EName)
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<EFirstName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<Supporter>.<EFullName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.EName) Then
                            ret.Add(key.<Bail>.<Supporter>.<EFullName>.Value, Getter.GetFullNameE(bail.Supporter.Name))
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<EFullName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<Supporter>.<ELastName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.ELast) Then
                            ret.Add(key.<Bail>.<Supporter>.<ELastName>.Value, bail.Supporter.Name.ELast)
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<ELastName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<Supporter>.<FatherName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.Father) Then
                            ret.Add(key.<Bail>.<Supporter>.<FatherName>.Value, bail.Supporter.Name.Father)
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<FatherName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<Supporter>.<FirstName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.First) Then
                            ret.Add(key.<Bail>.<Supporter>.<FirstName>.Value, bail.Supporter.Name.First)
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<FirstName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<Supporter>.<FullName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.First) Then
                            ret.Add(key.<Bail>.<Supporter>.<FullName>.Value, Getter.GetFullName(bail.Supporter.Name))
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<FullName>.Value, "")
                        End If
                    End If
                    If key.<Bail>.<Supporter>.<LastName>.Value.Length > 0 Then
                        If Not IsNothing(bail) AndAlso Not IsNothing(bail.Supporter.Name.Last) Then
                            ret.Add(key.<Bail>.<Supporter>.<LastName>.Value, bail.Supporter.Name.Last)
                        Else
                            ret.Add(key.<Bail>.<Supporter>.<LastName>.Value, "")
                        End If
                    End If
                    'Orphan
                    If key.<Orphan>.<BirthCertificate_Photo>.Value.Length > 0 Then
                        If Not IsNothing(orph.BirthCertificate_Photo) Then
                            Dim img As Image = Image.FromStream(New MemoryStream(orph.BirthCertificate_Photo))
                            Imgs.Add(key.<Orphan>.<BirthCertificate_Photo>.Value, img)
                        End If
                    End If
                    If key.<Orphan>.<FamilyCardPagePhoto>.Value.Length > 0 Then
                        If Not IsNothing(orph.FamilyCardPagePhoto) Then
                            Dim img As Image = Image.FromStream(New MemoryStream(orph.FamilyCardPagePhoto))
                            Imgs.Add(key.<Orphan>.<FamilyCardPagePhoto>.Value, img)
                        End If
                    End If
                    If key.<Orphan>.<FullPhoto>.Value.Length > 0 Then
                        If Not IsNothing(orph.FullPhoto) Then
                            Dim img As Image = Image.FromStream(New MemoryStream(orph.FullPhoto))
                            Imgs.Add(key.<Orphan>.<FullPhoto>.Value, img)
                        End If
                    End If
                    If key.<Orphan>.<FacePhoto>.Value.Length > 0 Then
                        If Not IsNothing(orph.FacePhoto) Then
                            Dim img As Image = Image.FromStream(New MemoryStream(orph.FacePhoto))
                            Imgs.Add(key.<Orphan>.<FacePhoto>.Value, img)
                        End If
                    End If
                    If key.<Orphan>.<Age>.Value.Length > 0 Then
                        If orph.Age.HasValue Then
                            ret.Add(key.<Orphan>.<Age>.Value, CStr(orph.Age.Value))
                        Else
                            ret.Add(key.<Orphan>.<Age>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<Birthday>.Value.Length > 0 Then
                        ret.Add(key.<Orphan>.<Birthday>.Value, orph.Birthday.ToString(My.Settings.GeneralDateFormat))
                    Else
                        'ret.Add(key.<Orphan>.<Birthday>.Value, "")
                    End If
                    If key.<Orphan>.<Birthplace>.Value.Length > 0 Then
                        If Not IsNothing(orph.BirthPlace) Then
                            ret.Add(key.<Orphan>.<Birthplace>.Value, orph.BirthPlace)
                        Else
                            ret.Add(key.<Orphan>.<Birthplace>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<BondsManRel>.Value.Length > 0 Then
                        If Not IsNothing(orph.BondsManRelationship) Then
                            ret.Add(key.<Orphan>.<BondsManRel>.Value, orph.BondsManRelationship)
                        Else
                            ret.Add(key.<Orphan>.<BondsManRel>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<BrothersCount>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Orphans) Then
                            ret.Add(key.<Orphan>.<BrothersCount>.Value, Fam.Orphans.Count - 1)
                        Else
                            ret.Add(key.<Orphan>.<BrothersCount>.Value, "")
                        End If
                    End If
                    'Study
                    If orph.Education_ID.HasValue Then
                        If key.<Orphan>.<Education>.<Certificate_Photo1>.Value.Length > 0 Then
                            If Not IsNothing(orph.Study.Certificate_Photo1) Then
                                Dim img As Image = Image.FromStream(New MemoryStream(orph.Study.Certificate_Photo1))
                                Imgs.Add(key.<Orphan>.<Education>.<Certificate_Photo1>.Value, img)
                            End If
                        End If
                        If key.<Orphan>.<Education>.<Certificate_Photo2>.Value.Length > 0 Then
                            If Not IsNothing(orph.Study.Certificate_Photo2) Then
                                Dim img As Image = Image.FromStream(New MemoryStream(orph.Study.Certificate_Photo2))
                                Imgs.Add(key.<Orphan>.<Education>.<Certificate_Photo2>.Value, img)
                            End If
                        End If
                        If key.<Orphan>.<Education>.<Collage>.Value.Length > 0 Then
                            If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.Collage) Then
                                ret.Add(key.<Orphan>.<Education>.<Collage>.Value, orph.Study.Collage)
                            Else
                                ret.Add(key.<Orphan>.<Education>.<Collage>.Value, "")
                            End If
                        End If
                        If key.<Orphan>.<Education>.<DegreesRate>.Value.Length > 0 Then
                            If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.DegreesRate) Then
                                ret.Add(key.<Orphan>.<Education>.<DegreesRate>.Value, orph.Study.DegreesRate.ToString())
                            Else
                                ret.Add(key.<Orphan>.<Education>.<DegreesRate>.Value, "")
                            End If
                        End If
                        If key.<Orphan>.<Education>.<MonthlyCost>.Value.Length > 0 Then
                            If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.MonthlyCost) Then
                                ret.Add(key.<Orphan>.<Education>.<MonthlyCost>.Value, orph.Study.MonthlyCost.ToString())
                            Else
                                ret.Add(key.<Orphan>.<Education>.<MonthlyCost>.Value, "")
                            End If
                        End If
                        If key.<Orphan>.<Education>.<Note>.Value.Length > 0 Then
                            If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.Note) Then
                                ret.Add(key.<Orphan>.<Education>.<Note>.Value, orph.Study.Note)
                            Else
                                ret.Add(key.<Orphan>.<Education>.<Note>.Value, "")
                            End If
                        End If
                        If key.<Orphan>.<Education>.<Reasons>.Value.Length > 0 Then
                            If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.Resons) Then
                                ret.Add(key.<Orphan>.<Education>.<Reasons>.Value, orph.Study.Resons)
                            Else
                                ret.Add(key.<Orphan>.<Education>.<Reasons>.Value, "")
                            End If
                        End If
                        If key.<Orphan>.<Education>.<School>.Value.Length > 0 Then
                            If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.School) Then
                                ret.Add(key.<Orphan>.<Education>.<School>.Value, orph.Study.School)
                            Else
                                ret.Add(key.<Orphan>.<Education>.<School>.Value, "")
                            End If
                        End If
                        If key.<Orphan>.<Education>.<Stage>.Value.Length > 0 Then
                            If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.Stage) Then
                                ret.Add(key.<Orphan>.<Education>.<Stage>.Value, orph.Study.Stage)
                            Else
                                ret.Add(key.<Orphan>.<Education>.<Stage>.Value, "")
                            End If
                        End If
                        If key.<Orphan>.<Education>.<Univercity>.Value.Length > 0 Then
                            If Not IsNothing(orph.Study) AndAlso Not IsNothing(orph.Study.Univercity) Then
                                ret.Add(key.<Orphan>.<Education>.<Univercity>.Value, orph.Study.Univercity)
                            Else
                                ret.Add(key.<Orphan>.<Education>.<Univercity>.Value, "")
                            End If
                        End If
                    End If
                    If key.<Orphan>.<EFatherName>.Value.Length > 0 Then
                        If Not IsNothing(orph.Name.EFather) Then
                            ret.Add(key.<Orphan>.<EFatherName>.Value, orph.Name.EFather)
                        Else
                            ret.Add(key.<Orphan>.<EFatherName>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<EFirstName>.Value.Length > 0 Then
                        If Not IsNothing(orph.Name.EName) Then
                            ret.Add(key.<Orphan>.<EFirstName>.Value, orph.Name.EName)
                        Else
                            ret.Add(key.<Orphan>.<EFirstName>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<EFullName>.Value.Length > 0 Then
                        If Not IsNothing(orph.Name) Then
                            ret.Add(key.<Orphan>.<EFullName>.Value, Getter.GetFullNameE(orph.Name))
                        Else
                            ret.Add(key.<Orphan>.<EFullName>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<ELastName>.Value.Length > 0 Then
                        If Not IsNothing(orph.Name.ELast) Then
                            ret.Add(key.<Orphan>.<ELastName>.Value, orph.Name.ELast)
                        Else
                            ret.Add(key.<Orphan>.<ELastName>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<FatherName>.Value.Length > 0 Then
                        If Not IsNothing(orph.Name.Father) Then
                            ret.Add(key.<Orphan>.<FatherName>.Value, orph.Name.Father)
                        Else
                            ret.Add(key.<Orphan>.<FatherName>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<FemaleBrothersCount>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Orphans) Then
                            Dim Mb As Integer = Getter.GetFamilyFemaleOrphansCount(Fam.ID)
                            If Not orph.Gender.Contains("ذ") Then
                                If Mb > 0 Then Mb -= 1
                            End If
                            ret.Add(key.<Orphan>.<FemaleBrothersCount>.Value, Mb.ToString())
                        Else
                            ret.Add(key.<Orphan>.<FemaleBrothersCount>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<FirstName>.Value.Length > 0 Then
                        If Not IsNothing(orph.Name.First) Then
                            ret.Add(key.<Orphan>.<FirstName>.Value, orph.Name.First)
                        Else
                            ret.Add(key.<Orphan>.<FirstName>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<FootSize>.Value.Length > 0 Then
                        If Not IsNothing(orph.FootSize) Then
                            ret.Add(key.<Orphan>.<FootSize>.Value, orph.FootSize)
                        Else
                            ret.Add(key.<Orphan>.<FootSize>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<FullName>.Value.Length > 0 Then
                        If Not IsNothing(orph.Name) Then
                            ret.Add(key.<Orphan>.<FullName>.Value, Getter.GetFullName(orph.Name))
                        Else
                            ret.Add(key.<Orphan>.<FullName>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<Gender>.Value.Length > 0 Then
                        If Not IsNothing(orph.Gender) Then
                            ret.Add(key.<Orphan>.<Gender>.Value, orph.Gender)
                        Else
                            ret.Add(key.<Orphan>.<Gender>.Value, "")
                        End If
                    End If
                    'Health
                    If key.<Orphan>.<Health>.<ReporteFile>.Value.Length > 0 Then
                        If orph.Health_ID.HasValue AndAlso Not IsNothing(orph.Healthy.ReporteFile) Then
                            Dim img As Image = Image.FromStream(New MemoryStream(orph.Healthy.ReporteFile))
                            Imgs.Add(key.<Orphan>.<Health>.<ReporteFile>.Value, img)
                        End If
                    End If
                    If key.<Orphan>.<Health>.<Cost>.Value.Length > 0 Then
                        If orph.Health_ID.HasValue AndAlso Not IsNothing(orph.Healthy) AndAlso Not IsNothing(orph.Healthy.Cost) Then
                            ret.Add(key.<Orphan>.<Health>.<Cost>.Value, orph.Healthy.Cost)
                        Else
                            ret.Add(key.<Orphan>.<Health>.<Cost>.Value, "")
                        End If
                    End If
                    If orph.Health_ID.HasValue AndAlso key.<Orphan>.<Health>.<Medicen>.Value.Length > 0 Then
                        If Not IsNothing(orph.Healthy) AndAlso Not IsNothing(orph.Healthy.Medicen) Then
                            ret.Add(key.<Orphan>.<Health>.<Medicen>.Value, orph.Healthy.Medicen.Replace(";", " "))
                        Else
                            ret.Add(key.<Orphan>.<Health>.<Medicen>.Value, "")
                        End If
                    End If
                    If orph.Health_ID.HasValue AndAlso key.<Orphan>.<Health>.<Name>.Value.Length > 0 Then
                        If Not IsNothing(orph.Healthy) AndAlso Not IsNothing(orph.Healthy.Name) Then
                            ret.Add(key.<Orphan>.<Health>.<Name>.Value, orph.Healthy.Name.Replace(";", " "))
                        Else
                            ret.Add(key.<Orphan>.<Health>.<Name>.Value, "")
                        End If
                    End If
                    If orph.Health_ID.HasValue AndAlso key.<Orphan>.<Health>.<Note>.Value.Length > 0 Then
                        If Not IsNothing(orph.Healthy) AndAlso Not IsNothing(orph.Healthy.Note) Then
                            ret.Add(key.<Orphan>.<Health>.<Note>.Value, orph.Healthy.Note)
                        Else
                            ret.Add(key.<Orphan>.<Health>.<Note>.Value, "")
                        End If
                    End If
                    If orph.Health_ID.HasValue AndAlso key.<Orphan>.<Health>.<SupervisorDoctor>.Value.Length > 0 Then
                        If Not IsNothing(orph.Healthy) AndAlso Not IsNothing(orph.Healthy.SupervisorDoctor) Then
                            ret.Add(key.<Orphan>.<Health>.<SupervisorDoctor>.Value, orph.Healthy.SupervisorDoctor)
                        Else
                            ret.Add(key.<Orphan>.<Health>.<SupervisorDoctor>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<IdentityNumber>.Value.Length > 0 Then
                        If Not IsNothing(orph.IdentityNumber) Then
                            ret.Add(key.<Orphan>.<IdentityNumber>.Value, orph.IdentityNumber.ToString())
                        Else
                            ret.Add(key.<Orphan>.<IdentityNumber>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<IsBailed>.Value.Length > 0 Then
                        If Not IsNothing(orph.IsBailed) Then
                            If Not UseCustomBool Then
                                ret.Add(key.<Orphan>.<IsBailed>.Value, IIf(orph.IsBailed, YesBool, NoBool))
                            Else
                                boolBookmark.Add(key.<Orphan>.<IsBailed>.Value, IIf(orph.IsBailed, YesBool, NoBool))
                            End If
                        Else
                            If Not UseCustomBool Then
                                ret.Add(key.<Orphan>.<IsBailed>.Value, NoBool)
                            Else
                                boolBookmark.Add(key.<Orphan>.<IsBailed>.Value, NoBool)
                            End If
                        End If
                    End If

                    If key.<Orphan>.<IsSick>.Value.Length > 0 Then
                        If orph.Health_ID.HasValue Then
                            If Not UseCustomBool Then
                                ret.Add(key.<Orphan>.<IsSick>.Value, YesBool)
                            Else
                                boolBookmark.Add(key.<Orphan>.<IsSick>.Value, YesBool)
                            End If
                        Else
                            If Not UseCustomBool Then
                                ret.Add(key.<Orphan>.<IsSick>.Value, NoBool)
                            Else
                                boolBookmark.Add(key.<Orphan>.<IsSick>.Value, NoBool)
                            End If
                        End If
                    End If
                    If key.<Orphan>.<IsStudy>.Value.Length > 0 Then
                        If orph.Education_ID.HasValue Then
                            If Not UseCustomBool Then
                                ret.Add(key.<Orphan>.<IsStudy>.Value, YesBool)
                            Else
                                boolBookmark.Add(key.<Orphan>.<IsStudy>.Value, YesBool)
                            End If
                        Else
                            If Not UseCustomBool Then
                                ret.Add(key.<Orphan>.<IsStudy>.Value, NoBool)
                            Else
                                boolBookmark.Add(key.<Orphan>.<IsStudy>.Value, NoBool)
                            End If
                        End If
                    End If
                    If key.<Orphan>.<Kaid>.Value.Length > 0 Then
                        If Not IsNothing(orph.Kaid) Then
                            ret.Add(key.<Orphan>.<Kaid>.Value, orph.Kaid)
                        Else
                            ret.Add(key.<Orphan>.<Kaid>.Value, "")
                        End If

                    End If
                    If key.<Orphan>.<LastName>.Value.Length > 0 Then
                        If Not IsNothing(orph.Name.Last) Then
                            ret.Add(key.<Orphan>.<LastName>.Value, orph.Name.Last)
                        Else
                            ret.Add(key.<Orphan>.<LastName>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<MaleBrothersCount>.Value.Length > 0 Then
                        If Not IsNothing(Fam.Orphans) Then
                            Dim Mb As Integer = Getter.GetFamilyMaleOrphansCount(Fam.ID)
                            If orph.Gender.Contains("ذ") Then
                                If Mb > 0 Then Mb -= 1
                            End If
                            ret.Add(key.<Orphan>.<MaleBrothersCount>.Value, Mb)
                        Else
                            ret.Add(key.<Orphan>.<MaleBrothersCount>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<RegDate>.Value.Length > 0 Then
                        If Not IsNothing(orph.RegDate) Then
                            ret.Add(key.<Orphan>.<RegDate>.Value, orph.RegDate.ToString(My.Settings.GeneralDateFormat))
                        Else
                            ret.Add(key.<Orphan>.<RegDate>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<Story>.Value.Length > 0 Then
                        If Not IsNothing(orph.Story) Then
                            ret.Add(key.<Orphan>.<Story>.Value, orph.Story)
                        Else
                            ret.Add(key.<Orphan>.<Story>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<Tallness>.Value.Length > 0 Then
                        If Not IsNothing(orph.Tallness) Then
                            ret.Add(key.<Orphan>.<Tallness>.Value, orph.Tallness)
                        Else
                            ret.Add(key.<Orphan>.<Tallness>.Value, "")
                        End If
                    End If
                    If key.<Orphan>.<Weight>.Value.Length > 0 Then
                        If Not IsNothing(orph.Weight) Then
                            ret.Add(key.<Orphan>.<Weight>.Value, orph.Weight)
                        Else
                            ret.Add(key.<Orphan>.<Weight>.Value, "")
                        End If
                    End If
                'BondsMan
                If key.<BondsMan>.<IdentityCardPhoto1>.Value.Length > 0 Then
                    If Not IsNothing(Bond.IdentityCard_Photo) Then
                        Dim img As Image = Image.FromStream(New MemoryStream(Bond.IdentityCard_Photo))
                        Imgs.Add(key.<BondsMan>.<IdentityCardPhoto1>.Value, img)
                    End If
                End If
                If key.<BondsMan>.<IdentityCardPhoto2>.Value.Length > 0 Then
                    If Not IsNothing(Bond.IdentityCard_Photo2) Then
                        Dim img As Image = Image.FromStream(New MemoryStream(Bond.IdentityCard_Photo2))
                        Imgs.Add(key.<BondsMan>.<IdentityCardPhoto2>.Value, img)
                    End If
                End If
                If key.<BondsMan>.<EFatherName>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Name.EFather) Then
                        ret.Add(key.<BondsMan>.<EFatherName>.Value, Bond.Name.EFather)
                    Else
                        ret.Add(key.<BondsMan>.<EFatherName>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<FirstName>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Name.First) Then
                        ret.Add(key.<BondsMan>.<FirstName>.Value, Bond.Name.First)
                    Else
                        ret.Add(key.<BondsMan>.<FirstName>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<EFirstName>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Name.EName) Then
                        ret.Add(key.<BondsMan>.<EFirstName>.Value, Bond.Name.EName)
                    Else
                        ret.Add(key.<BondsMan>.<EFirstName>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<EFullName>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Name) Then
                        ret.Add(key.<BondsMan>.<EFullName>.Value, Getter.GetFullNameE(Bond.Name))
                    Else
                        ret.Add(key.<BondsMan>.<EFullName>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<ELastName>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Name.ELast) Then
                        ret.Add(key.<BondsMan>.<ELastName>.Value, Bond.Name.ELast)
                    Else
                        ret.Add(key.<BondsMan>.<ELastName>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<FatherName>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Name.Father) Then
                        ret.Add(key.<BondsMan>.<FatherName>.Value, Bond.Name.Father)
                    Else
                        ret.Add(key.<BondsMan>.<FatherName>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<FullName>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Name) Then
                        ret.Add(key.<BondsMan>.<FullName>.Value, Getter.GetFullName(Bond.Name))
                    Else
                        ret.Add(key.<BondsMan>.<FullName>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<IdentityCardNumber>.Value.Length > 0 Then
                    If Not IsNothing(Bond.IdentityCard_ID) Then
                        ret.Add(key.<BondsMan>.<IdentityCardNumber>.Value, Bond.IdentityCard_ID)
                    Else
                        ret.Add(key.<BondsMan>.<IdentityCardNumber>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<Jop>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Jop) Then
                        ret.Add(key.<BondsMan>.<Jop>.Value, Bond.Jop)
                    Else
                        ret.Add(key.<BondsMan>.<Jop>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<LastName>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Name.Last) Then
                        ret.Add(key.<BondsMan>.<LastName>.Value, Bond.Name.Last)
                    Else
                        ret.Add(key.<BondsMan>.<LastName>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<Note>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Note) Then
                        ret.Add(key.<BondsMan>.<Note>.Value, Bond.Note)
                    Else
                        ret.Add(key.<BondsMan>.<Note>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<Salary>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Income) Then
                        ret.Add(key.<BondsMan>.<Salary>.Value, Bond.Income)
                    Else
                        ret.Add(key.<BondsMan>.<Salary>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<Address>.<CellPhone>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Cell_Phone) AndAlso Not Bond.Address.Cell_Phone.Contains("(000") Then
                        ret.Add(key.<BondsMan>.<Address>.<CellPhone>.Value, Bond.Address.Cell_Phone)
                    Else
                        ret.Add(key.<BondsMan>.<Address>.<CellPhone>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<Address>.<City>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.City) Then
                        ret.Add(key.<BondsMan>.<Address>.<City>.Value, Bond.Address.City)
                    Else
                        ret.Add(key.<BondsMan>.<Address>.<City>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<Address>.<Email>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Email) Then
                        ret.Add(key.<BondsMan>.<Address>.<Email>.Value, Bond.Address.Email)
                    Else
                        ret.Add(key.<BondsMan>.<Address>.<Email>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<Address>.<Fax>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Fax) AndAlso Not Bond.Address.Fax.Contains("(000") Then
                        ret.Add(key.<BondsMan>.<Address>.<Fax>.Value, Bond.Address.Fax)
                    Else
                        ret.Add(key.<BondsMan>.<Address>.<Fax>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<Address>.<HomePhone>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Home_Phone) AndAlso Not Bond.Address.Home_Phone.Contains("(000") Then
                        ret.Add(key.<BondsMan>.<Address>.<HomePhone>.Value, Bond.Address.Home_Phone)
                    Else
                        ret.Add(key.<BondsMan>.<Address>.<HomePhone>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<Address>.<State>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Country) Then
                        ret.Add(key.<BondsMan>.<Address>.<State>.Value, Bond.Address.Country)
                    Else
                        ret.Add(key.<BondsMan>.<Address>.<State>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<Address>.<Street>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Street) Then
                        ret.Add(key.<BondsMan>.<Address>.<Street>.Value, Bond.Address.Street)
                    Else
                        ret.Add(key.<BondsMan>.<Address>.<Street>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<Address>.<Town>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Town) Then
                        ret.Add(key.<BondsMan>.<Address>.<Town>.Value, Bond.Address.Town)
                    Else
                        ret.Add(key.<BondsMan>.<Address>.<Town>.Value, "")
                    End If
                End If
                If key.<BondsMan>.<Address>.<WorkPhone>.Value.Length > 0 Then
                    If Not IsNothing(Bond.Address_ID) AndAlso Not IsNothing(Bond.Address.Work_Phone) AndAlso Not Bond.Address.Work_Phone.Contains("(000") Then
                        ret.Add(key.<BondsMan>.<Address>.<WorkPhone>.Value, Bond.Address.Work_Phone)
                    Else
                        ret.Add(key.<BondsMan>.<Address>.<WorkPhone>.Value, "")
                    End If
                End If
                'Family
                If key.<Family>.<FamilyCardPhoto1>.Value.Length > 0 Then
                    If Not IsNothing(Fam.FamilyCardPhoto) Then
                        Dim img As Image = Image.FromStream(New MemoryStream(Fam.FamilyCardPhoto))
                        Imgs.Add(key.<Family>.<FamilyCardPhoto1>.Value, img)
                    End If
                End If
                If key.<Family>.<FamilyCardPhoto2>.Value.Length > 0 Then
                    If Not IsNothing(Fam.FamilyCardPhotoP2) Then
                        Dim img As Image = Image.FromStream(New MemoryStream(Fam.FamilyCardPhotoP2))
                        Imgs.Add(key.<Family>.<FamilyCardPhoto2>.Value, img)
                    End If
                End If
                If key.<Family>.<Address>.<Main>.<CellPhone>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Cell_Phone) AndAlso Not Fam.Address.Cell_Phone.Contains("(000") Then
                        ret.Add(key.<Family>.<Address>.<Main>.<CellPhone>.Value, Fam.Address.Cell_Phone)
                    Else
                        ret.Add(key.<Family>.<Address>.<Main>.<CellPhone>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Main>.<City>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.City) Then
                        ret.Add(key.<Family>.<Address>.<Main>.<City>.Value, Fam.Address.City)
                    Else
                        ret.Add(key.<Family>.<Address>.<Main>.<City>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Main>.<Email>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Email) Then
                        ret.Add(key.<Family>.<Address>.<Main>.<Email>.Value, Fam.Address.Email)
                    Else
                        ret.Add(key.<Family>.<Address>.<Main>.<Email>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Main>.<Fax>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Fax) AndAlso Not Fam.Address.Fax.Contains("(000") Then
                        ret.Add(key.<Family>.<Address>.<Main>.<Fax>.Value, Fam.Address.Fax)
                    Else
                        ret.Add(key.<Family>.<Address>.<Main>.<Fax>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Main>.<HomePhone>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Home_Phone) AndAlso Not Fam.Address.Home_Phone.Contains("(000") Then
                        ret.Add(key.<Family>.<Address>.<Main>.<HomePhone>.Value, Fam.Address.Home_Phone)
                    Else
                        ret.Add(key.<Family>.<Address>.<Main>.<HomePhone>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Main>.<State>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Country) Then
                        ret.Add(key.<Family>.<Address>.<Main>.<State>.Value, Fam.Address.Country)
                    Else
                        ret.Add(key.<Family>.<Address>.<Main>.<State>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Main>.<Street>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Street) Then
                        ret.Add(key.<Family>.<Address>.<Main>.<Street>.Value, Fam.Address.Street)
                    Else
                        ret.Add(key.<Family>.<Address>.<Main>.<Street>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Main>.<Town>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Town) Then
                        ret.Add(key.<Family>.<Address>.<Main>.<Town>.Value, Fam.Address.Town)
                    Else
                        ret.Add(key.<Family>.<Address>.<Main>.<Town>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Main>.<WorkPhone>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID) AndAlso Not IsNothing(Fam.Address.Work_Phone) AndAlso Not Fam.Address.Work_Phone.Contains("(000") Then
                        ret.Add(key.<Family>.<Address>.<Main>.<WorkPhone>.Value, Fam.Address.Work_Phone)
                    Else
                        ret.Add(key.<Family>.<Address>.<Main>.<WorkPhone>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Current>.<CellPhone>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Cell_Phone) AndAlso Not Fam.Address.Cell_Phone.Contains("(000") Then
                        ret.Add(key.<Family>.<Address>.<Current>.<CellPhone>.Value, Fam.Address1.Cell_Phone)
                    Else
                        ret.Add(key.<Family>.<Address>.<Current>.<CellPhone>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Current>.<City>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.City) Then
                        ret.Add(key.<Family>.<Address>.<Current>.<City>.Value, Fam.Address1.City)
                    Else
                        ret.Add(key.<Family>.<Address>.<Current>.<City>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Current>.<Email>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Email) Then
                        ret.Add(key.<Family>.<Address>.<Current>.<Email>.Value, Fam.Address1.Email)
                    Else
                        ret.Add(key.<Family>.<Address>.<Current>.<Email>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Current>.<Fax>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Fax) AndAlso Not Fam.Address1.Fax.Contains("(000") Then
                        ret.Add(key.<Family>.<Address>.<Current>.<Fax>.Value, Fam.Address1.Fax)
                    Else
                        ret.Add(key.<Family>.<Address>.<Current>.<Fax>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Current>.<HomePhone>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Home_Phone) AndAlso Not Fam.Address1.Home_Phone.Contains("(000") Then
                        ret.Add(key.<Family>.<Address>.<Current>.<HomePhone>.Value, Fam.Address1.Home_Phone)
                    Else
                        ret.Add(key.<Family>.<Address>.<Current>.<HomePhone>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Current>.<State>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Country) Then
                        ret.Add(key.<Family>.<Address>.<Current>.<State>.Value, Fam.Address1.Country)
                    Else
                        ret.Add(key.<Family>.<Address>.<Current>.<State>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Current>.<Street>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Street) Then
                        ret.Add(key.<Family>.<Address>.<Current>.<Street>.Value, Fam.Address1.Street)
                    Else
                        ret.Add(key.<Family>.<Address>.<Current>.<Street>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Current>.<Town>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Town) Then
                        ret.Add(key.<Family>.<Address>.<Current>.<Town>.Value, Fam.Address1.Town)
                    Else
                        ret.Add(key.<Family>.<Address>.<Current>.<Town>.Value, "")
                    End If
                End If
                If key.<Family>.<Address>.<Current>.<WorkPhone>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Address_ID2) AndAlso Not IsNothing(Fam.Address1.Work_Phone) AndAlso Not Fam.Address1.Work_Phone.Contains("(000") Then
                        ret.Add(key.<Family>.<Address>.<Current>.<WorkPhone>.Value, Fam.Address1.Work_Phone)
                    Else
                        ret.Add(key.<Family>.<Address>.<Current>.<WorkPhone>.Value, "")
                    End If
                End If
                If key.<Family>.<FamilyCardNumber>.Value.Length > 0 Then
                    If Not IsNothing(Fam.FamilyCard_Num) Then
                        ret.Add(key.<Family>.<FamilyCardNumber>.Value, Fam.FamilyCard_Num)
                    Else
                        ret.Add(key.<Family>.<FamilyCardNumber>.Value, "")
                    End If
                End If
                If key.<Family>.<FinnacialState>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Finncial_Sate) Then
                        ret.Add(key.<Family>.<FinnacialState>.Value, Fam.Finncial_Sate)
                    Else
                        ret.Add(key.<Family>.<FinnacialState>.Value, "")
                    End If
                End If
                If key.<Family>.<IsRefugee>.Value.Length > 0 Then
                    If Not IsNothing(Fam.IsRefugee) Then
                        If Not UseCustomBool Then
                            ret.Add(key.<Family>.<IsRefugee>.Value, IIf(Fam.IsRefugee, YesBool, NoBool))
                        Else
                            boolBookmark.Add(key.<Family>.<IsRefugee>.Value, CInt(IIf(Fam.IsRefugee, YesBool, NoBool)))
                        End If
                    Else
                        If Not UseCustomBool Then
                            ret.Add(key.<Family>.<IsRefugee>.Value, NoBool)
                        Else
                            boolBookmark.Add(key.<Family>.<IsRefugee>.Value, NoBool)
                        End If
                    End If
                End If
                If key.<Family>.<ResidenceState>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Residece_Sate) Then
                        ret.Add(key.<Family>.<ResidenceState>.Value, Fam.Residece_Sate)
                    Else
                        ret.Add(key.<Family>.<ResidenceState>.Value, "")
                    End If
                End If
                If key.<Family>.<ResidenceType>.Value.Length > 0 Then
                    If Not IsNothing(Fam.Residenc_Type) Then
                        ret.Add(key.<Family>.<ResidenceType>.Value, Fam.Residenc_Type)
                    Else
                        ret.Add(key.<Family>.<ResidenceType>.Value, "")
                    End If
                End If
                'Father
                If key.<Father>.<DeathCertificate_Photo>.Value.Length > 0 Then
                    If Not IsNothing(Fath.DeathCertificate_Photo) Then
                        Dim img As Image = Image.FromStream(New MemoryStream(Fath.DeathCertificate_Photo))
                        Imgs.Add(key.<Father>.<DeathCertificate_Photo>.Value, img)
                    End If
                End If
                If key.<Father>.<Photo>.Value.Length > 0 Then
                    If Not IsNothing(Fath.Photo) Then
                        Dim img As Image = Image.FromStream(New MemoryStream(Fath.Photo))
                        Imgs.Add(key.<Father>.<Photo>.Value, img)
                    End If
                End If
                If key.<Father>.<Age>.Value.Length > 0 Then
                    If Not IsNothing(Fath.Birthday) Then
                        Dim dt As New Itenso.TimePeriod.DateDiff(Fath.Birthday, Fath.Dieday)
                        ret.Add(key.<Father>.<Age>.Value, ATDFormater.ArabicDateFormater.GetArabicYear(dt.ElapsedYears))
                    Else
                        ret.Add(key.<Father>.<Age>.Value, "")
                    End If
                End If
                If key.<Father>.<Birthday>.Value.Length > 0 Then
                    If Not IsNothing(Fath.Birthday) Then
                        ret.Add(key.<Father>.<Birthday>.Value, Fath.Birthday.ToString(My.Settings.GeneralDateFormat))
                    Else
                        ret.Add(key.<Father>.<Birthday>.Value, "")
                    End If
                End If
                If key.<Father>.<DeathReason>.Value.Length > 0 Then
                    If Not IsNothing(Fath.DeathResone) Then
                        ret.Add(key.<Father>.<DeathReason>.Value, Fath.DeathResone)
                    Else
                        ret.Add(key.<Father>.<DeathReason>.Value, "")
                    End If
                End If
                If key.<Father>.<Deathday>.Value.Length > 0 Then
                    If Not IsNothing(Fath.Dieday) Then
                        ret.Add(key.<Father>.<Deathday>.Value, Fath.Dieday.ToString(My.Settings.GeneralDateFormat))
                    Else
                        ret.Add(key.<Father>.<Deathday>.Value, "")
                    End If
                End If
                If key.<Father>.<EFatherName>.Value.Length > 0 Then
                    If Not IsNothing(Fath.Name.EFather) Then
                        ret.Add(key.<Father>.<EFatherName>.Value, Fath.Name.EFather)
                    Else
                        ret.Add(key.<Father>.<EFatherName>.Value, "")
                    End If
                End If
                If key.<Father>.<EFirstName>.Value.Length > 0 Then
                    If Not IsNothing(Fath.Name.EName) Then
                        ret.Add(key.<Father>.<EFirstName>.Value, Fath.Name.EName)
                    Else
                        ret.Add(key.<Father>.<EFirstName>.Value, "")
                    End If
                End If
                If key.<Father>.<EFullName>.Value.Length > 0 Then
                    If Not IsNothing(Fath.Name.EName) Then
                        ret.Add(key.<Father>.<EFullName>.Value, Getter.GetFullNameE(Fath.Name))
                    Else
                        ret.Add(key.<Father>.<EFullName>.Value, "")
                    End If
                End If
                If key.<Father>.<ELastName>.Value.Length > 0 Then
                    If Not IsNothing(Fath.Name.ELast) Then
                        ret.Add(key.<Father>.<ELastName>.Value, Fath.Name.ELast)
                    Else
                        ret.Add(key.<Father>.<ELastName>.Value, "")
                    End If
                End If
                If key.<Father>.<FatherName>.Value.Length > 0 Then
                    If Not IsNothing(Fath.Name.Father) Then
                        ret.Add(key.<Father>.<FatherName>.Value, Fath.Name.Father)
                    Else
                        ret.Add(key.<Father>.<FatherName>.Value, "")
                    End If
                End If
                If key.<Father>.<FirstName>.Value.Length > 0 Then
                    If Not IsNothing(Fath.Name.First) Then
                        ret.Add(key.<Father>.<FirstName>.Value, Fath.Name.First)
                    Else
                        ret.Add(key.<Father>.<FirstName>.Value, "")
                    End If
                End If
                If key.<Father>.<FullName>.Value.Length > 0 Then
                    If Not IsNothing(Fath.Name.First) Then
                        ret.Add(key.<Father>.<FullName>.Value, Getter.GetFullName(Fath.Name))
                    Else
                        ret.Add(key.<Father>.<FullName>.Value, "")
                    End If
                End If
                If key.<Father>.<LastName>.Value.Length > 0 Then
                    If Not IsNothing(Fath.Name.Last) Then
                        ret.Add(key.<Father>.<LastName>.Value, Fath.Name.Last)
                    Else
                        ret.Add(key.<Father>.<LastName>.Value, "")
                    End If
                End If
                If key.<Father>.<IdentityCardNumber>.Value.Length > 0 Then
                    If Not IsNothing(Fath.IdentityCard_ID) Then
                        ret.Add(key.<Father>.<IdentityCardNumber>.Value, Fath.IdentityCard_ID)
                    Else
                        ret.Add(key.<Father>.<IdentityCardNumber>.Value, "")
                    End If
                End If
                If key.<Father>.<Jop>.Value.Length > 0 Then
                    If Not IsNothing(Fath.Jop) Then
                        ret.Add(key.<Father>.<Jop>.Value, Fath.Jop)
                    Else
                        ret.Add(key.<Father>.<Jop>.Value, "")
                    End If
                End If
                If key.<Father>.<Note>.Value.Length > 0 Then
                    If Not IsNothing(Fath.Note) Then
                        ret.Add(key.<Father>.<Note>.Value, Fath.Note)
                    Else
                        ret.Add(key.<Father>.<Note>.Value, "")
                    End If
                End If
                If key.<Father>.<Story>.Value.Length > 0 Then
                    If Not IsNothing(Fath.Story) Then
                        ret.Add(key.<Father>.<Story>.Value, Fath.Story)
                    Else
                        ret.Add(key.<Father>.<Story>.Value, "")
                    End If
                End If
                'Mother
                If key.<Mother>.<IdentityCardPhoto1>.Value.Length > 0 Then
                    If Not IsNothing(Moth.IdentityCard_Photo) Then
                        Dim img As Image = Image.FromStream(New MemoryStream(Moth.IdentityCard_Photo))
                        Imgs.Add(key.<Mother>.<IdentityCardPhoto1>.Value, img)
                    End If
                End If
                If key.<Mother>.<IdentityCardPhoto2>.Value.Length > 0 Then
                    If Not IsNothing(Moth.IdentityCard_Photo2) Then
                        Dim img As Image = Image.FromStream(New MemoryStream(Moth.IdentityCard_Photo2))
                        Imgs.Add(key.<Mother>.<IdentityCardPhoto2>.Value, img)
                    End If
                End If
                If key.<Mother>.<Age>.Value.Length > 0 Then
                    If Not IsNothing(Moth.Birthday) Then
                        Dim dt = New Itenso.TimePeriod.DateDiff(Moth.Birthday, Date.Now)
                        If Moth.IsDead AndAlso Moth.Dieday.HasValue Then
                            dt = New Itenso.TimePeriod.DateDiff(Moth.Birthday, Moth.Dieday)
                        Else
                            dt = New Itenso.TimePeriod.DateDiff(Moth.Birthday, Date.Now)
                        End If
                        ret.Add(key.<Mother>.<Age>.Value, ATDFormater.ArabicDateFormater.GetArabicYear(dt.ElapsedYears))
                    Else
                        ret.Add(key.<Mother>.<Age>.Value, "")
                    End If
                End If
                If key.<Mother>.<Birthday>.Value.Length > 0 Then
                    If Not IsNothing(Moth.Birthday) Then
                        ret.Add(key.<Mother>.<Birthday>.Value, Moth.Birthday.ToString(My.Settings.GeneralDateFormat))
                    Else
                        ret.Add(key.<Mother>.<Birthday>.Value, "")
                    End If
                End If
                If key.<Mother>.<Deathday>.Value.Length > 0 Then
                    If Not IsNothing(Moth.Dieday) AndAlso Moth.IsDead Then
                        ret.Add(key.<Mother>.<Deathday>.Value, Moth.Dieday.Value.ToString(My.Settings.GeneralDateFormat))
                    Else
                        ret.Add(key.<Mother>.<Deathday>.Value, "")
                    End If
                End If
                If key.<Mother>.<EFatherName>.Value.Length > 0 Then
                    If Not IsNothing(Moth.Name.EFather) Then
                        ret.Add(key.<Mother>.<EFatherName>.Value, Moth.Name.EFather)
                    Else
                        ret.Add(key.<Mother>.<EFatherName>.Value, "")
                    End If
                End If
                If key.<Mother>.<EFirstName>.Value.Length > 0 Then
                    If Not IsNothing(Moth.Name.EName) Then
                        ret.Add(key.<Mother>.<EFirstName>.Value, Moth.Name.EName)
                    Else
                        ret.Add(key.<Mother>.<EFirstName>.Value, "")
                    End If
                End If
                If key.<Mother>.<EFullName>.Value.Length > 0 Then
                    If Not IsNothing(Moth.Name.EName) Then
                        ret.Add(key.<Mother>.<EFullName>.Value, Getter.GetFullNameE(Moth.Name))
                    Else
                        ret.Add(key.<Mother>.<EFullName>.Value, "")
                    End If
                End If
                If key.<Mother>.<ELastName>.Value.Length > 0 Then
                    If Not IsNothing(Moth.Name.ELast) Then
                        ret.Add(key.<Mother>.<ELastName>.Value, Moth.Name.ELast)
                    Else
                        ret.Add(key.<Mother>.<ELastName>.Value, "")
                    End If
                End If
                If key.<Mother>.<FatherName>.Value.Length > 0 Then
                    If Not IsNothing(Moth.Name.Father) Then
                        ret.Add(key.<Mother>.<FatherName>.Value, Moth.Name.Father)
                    Else
                        ret.Add(key.<Mother>.<FatherName>.Value, "")
                    End If
                End If
                If key.<Mother>.<FirstName>.Value.Length > 0 Then
                    If Not IsNothing(Moth.Name.First) Then
                        ret.Add(key.<Mother>.<FirstName>.Value, Moth.Name.First)
                    Else
                        ret.Add(key.<Mother>.<FirstName>.Value, "")
                    End If
                End If
                If key.<Mother>.<FullName>.Value.Length > 0 Then
                    If Not IsNothing(Moth.Name.First) Then
                        ret.Add(key.<Mother>.<FullName>.Value, Getter.GetFullName(Moth.Name))
                    Else
                        ret.Add(key.<Mother>.<FullName>.Value, "")
                    End If
                End If
                If key.<Mother>.<IdentityCardNumber>.Value.Length > 0 Then
                    If Not IsNothing(Moth.IdntityCard_ID) Then
                        ret.Add(key.<Mother>.<IdentityCardNumber>.Value, Moth.IdntityCard_ID)
                    Else
                        ret.Add(key.<Mother>.<IdentityCardNumber>.Value, "")
                    End If
                End If
                If key.<Mother>.<IsDead>.Value.Length > 0 Then
                    If Not IsNothing(Moth.IsDead) Then
                        If Not UseCustomBool Then
                            ret.Add(key.<Mother>.<IsDead>.Value, IIf(Moth.IsDead, YesBool, NoBool))
                        Else
                            boolBookmark.Add(key.<Mother>.<IsDead>.Value, CInt(IIf(Moth.IsDead, YesBool, NoBool)))
                        End If
                    Else
                        If Not UseCustomBool Then
                            ret.Add(key.<Mother>.<IsDead>.Value, NoBool)
                        Else
                            boolBookmark.Add(key.<Mother>.<IsDead>.Value, NoBool)
                        End If
                    End If
                End If
                If key.<Mother>.<IsMarried>.Value.Length > 0 Then
                    If Not IsNothing(Moth.IsMarried) Then
                        If Not UseCustomBool Then
                            ret.Add(key.<Mother>.<IsMarried>.Value, IIf(Moth.IsMarried, YesBool, NoBool))
                        Else
                            boolBookmark.Add(key.<Mother>.<IsMarried>.Value, CInt(IIf(Moth.IsMarried, YesBool, NoBool)))
                        End If
                    Else
                        If Not UseCustomBool Then
                            ret.Add(key.<Mother>.<IsMarried>.Value, NoBool)
                        Else
                            boolBookmark.Add(key.<Mother>.<IsMarried>.Value, NoBool)
                        End If
                    End If
                End If
                If key.<Mother>.<IsOwnOrphans>.Value.Length > 0 Then
                    If Not IsNothing(Moth.IsOwnOrphans) Then
                        If Not UseCustomBool Then
                            ret.Add(key.<Mother>.<IsOwnOrphans>.Value, IIf(Moth.IsOwnOrphans, YesBool, NoBool))
                        Else
                            boolBookmark.Add(key.<Mother>.<IsOwnOrphans>.Value, CInt(IIf(Moth.IsOwnOrphans, YesBool, NoBool)))
                        End If
                    Else
                        If Not UseCustomBool Then
                            ret.Add(key.<Mother>.<IsOwnOrphans>.Value, NoBool)
                        Else
                            boolBookmark.Add(key.<Mother>.<IsOwnOrphans>.Value, NoBool)
                        End If
                    End If
                End If
                If key.<Mother>.<Jop>.Value.Length > 0 Then
                    If Not IsNothing(Moth.Jop) Then
                        ret.Add(key.<Mother>.<Jop>.Value, Moth.Jop)
                    Else
                        ret.Add(key.<Mother>.<Jop>.Value, "")
                    End If
                End If
                If key.<Mother>.<Note>.Value.Length > 0 Then
                    If Not IsNothing(Moth.Note) Then
                        ret.Add(key.<Mother>.<Note>.Value, Moth.Note)
                    Else
                        ret.Add(key.<Mother>.<Note>.Value, "")
                    End If
                End If
                If key.<Mother>.<Salary>.Value.Length > 0 Then
                    If Not IsNothing(Moth.Salary) AndAlso Moth.Salary.HasValue Then
                        ret.Add(key.<Mother>.<Salary>.Value, Moth.Salary.ToString())
                    Else
                        ret.Add(key.<Mother>.<Salary>.Value, "")
                    End If
                End If
                If key.<Mother>.<Story>.Value.Length > 0 Then
                    If Not IsNothing(Moth.Story) Then
                        ret.Add(key.<Mother>.<Story>.Value, Moth.Story)
                    Else
                        ret.Add(key.<Mother>.<Story>.Value, "")
                    End If
                End If
                If Moth.Address_ID.HasValue Then
                    If key.<Mother>.<Address>.<CellPhone>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Cell_Phone) AndAlso Not Moth.Address.Cell_Phone.Contains("(000") Then
                            ret.Add(key.<Mother>.<Address>.<CellPhone>.Value, Moth.Address.Cell_Phone)
                        Else
                            ret.Add(key.<Mother>.<Address>.<CellPhone>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<Address>.<City>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.City) Then
                            ret.Add(key.<Mother>.<Address>.<City>.Value, Moth.Address.City)
                        Else
                            ret.Add(key.<Mother>.<Address>.<City>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<Address>.<Email>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Email) Then
                            ret.Add(key.<Mother>.<Address>.<Email>.Value, Moth.Address.Email)
                        Else
                            ret.Add(key.<Mother>.<Address>.<Email>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<Address>.<Fax>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Fax) AndAlso Not Moth.Address.Fax.Contains("(000") Then
                            ret.Add(key.<Mother>.<Address>.<Fax>.Value, Moth.Address.Fax)
                        Else
                            ret.Add(key.<Mother>.<Address>.<Fax>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<Address>.<HomePhone>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Home_Phone) AndAlso Not Moth.Address.Home_Phone.Contains("(000") Then
                            ret.Add(key.<Mother>.<Address>.<HomePhone>.Value, Moth.Address.Home_Phone)
                        Else
                            ret.Add(key.<Mother>.<Address>.<HomePhone>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<Address>.<State>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Country) Then
                            ret.Add(key.<Mother>.<Address>.<State>.Value, Moth.Address.Country)
                        Else
                            ret.Add(key.<Mother>.<Address>.<State>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<Address>.<Street>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Street) Then
                            ret.Add(key.<Mother>.<Address>.<Street>.Value, Moth.Address.Street)
                        Else
                            ret.Add(key.<Mother>.<Address>.<Street>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<Address>.<Town>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Town) Then
                            ret.Add(key.<Mother>.<Address>.<Town>.Value, Moth.Address.Town)
                        Else
                            ret.Add(key.<Mother>.<Address>.<Town>.Value, "")
                        End If
                    End If
                    If key.<Mother>.<Address>.<WorkPhone>.Value.Length > 0 Then
                        If Not IsNothing(Moth.Address_ID) AndAlso Not IsNothing(Moth.Address.Work_Phone) AndAlso Not Moth.Address.Work_Phone.Contains("(000") Then
                            ret.Add(key.<Mother>.<Address>.<WorkPhone>.Value, Moth.Address.Work_Phone)
                        Else
                            ret.Add(key.<Mother>.<Address>.<WorkPhone>.Value, "")
                        End If
                    End If
                End If
                Exit For
            Next
                Exit For
            Next
        Else
            Return Nothing
        End If
        Return ret
    End Function

    Private Function ShowWordSave() As String
        Dim SVD As New SaveFileDialog()
        SVD.AddExtension = True
        SVD.Filter = "Word Files|*.Docx"
        SVD.Title = "أختر مكان حفظ الملف"
        SVD.ShowHelp = False
        SVD.RestoreDirectory = True
        SVD.OverwritePrompt = True
        SVD.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        If SVD.ShowDialog(Application.OpenForms("FrmMain")) = DialogResult.OK Then
            Return SVD.FileName
        Else
            Return Nothing
        End If
    End Function
    Private Function ShowWordSaveFolder() As String
        Dim SVD As New FolderBrowserDialog()
        SVD.ShowNewFolderButton = True
        SVD.RootFolder = Environment.SpecialFolder.Desktop
        SVD.Description = "أختر مجلد الحفظ"
        If SVD.ShowDialog(Application.OpenForms("FrmMain")) = DialogResult.OK Then
            Return SVD.SelectedPath
        Else
            Return Nothing
        End If
    End Function

    Public Sub ConvertToWord(ByVal O_IDs() As Integer)
        Dim SavedFiles As New ArrayList()
        Dim i As Decimal = 0D
        Dim FileName As String
        Dim FullPath As String
        If IsNothing(O_IDs) Then Return
        If O_IDs.Length = 1 Then
            FileName = ShowWordSave()
        Else
            FileName = ShowWordSaveFolder()
        End If
        If IsNothing(FileName) Then Return
        For Each id As Integer In O_IDs
            Using Odb As New OrphanageDB.Odb
                Dim orph As OrphanageClasses.Orphan = Getter.GetOrphanByID(id, Odb)
                If IsNothing(orph) Then Continue For
                Dim Destination_FileName As String
                If O_IDs.Length = 1 Then
                    Destination_FileName = FileName
                Else
                    If My.Settings.WordMakeNewFolder Then
                        FullPath = FileName & "\" & Getter.GetFullName(orph.Family.Father.Name)
                        If Not Directory.Exists(FullPath) Then
                            Directory.CreateDirectory(FullPath)
                        End If
                        If My.Settings.WordUseOrphanName Then
                            Destination_FileName = FullPath & "\" & orph.Name.First & ".Docx"
                        Else
                            Destination_FileName = FullPath & "\" & orph.ID & ".Docx"
                        End If
                    Else
                        If My.Settings.WordUseOrphanName Then
                            Destination_FileName = FileName & "\" & Getter.GetFullName(orph.Name) & "-" & orph.ID.ToString() & ".Docx"
                        Else
                            Destination_FileName = FileName & "\" & orph.ID & ".Docx"
                        End If
                    End If
                End If
                If My.Settings.WordSelectedTemplete = "نموذج يتيم1" Then
                    Dim wordData As WordTemletes.OrginalOrphanTemplete._MaktabData = Fill_Maktab1_Data(orph)
                    Dim Word3Taa2 As New WordTemletes.OrginalOrphanTemplete(wordData)
                    Word3Taa2.CreateWordFile(Destination_FileName, True)
                ElseIf My.Settings.WordSelectedTemplete = "نموذج عطاء" Then
                    Dim wordData As WordTemletes._3Taa2._3Taa2Data = Fill_3Taa2_Data(orph)
                    Dim Word3Taa2 As New WordTemletes._3Taa2(wordData)
                    Word3Taa2.CreateWordFile(Destination_FileName, True)
                Else
                    If My.Settings.ConvertToWordByCom Then
                        Dim imgDict As New Dictionary(Of String, Image)
                        Dim boolDict As New Dictionary(Of String, Integer)
                        Dim UseBookMark As Boolean = False
                        Dim UseDefaultPicS As Boolean
                        Dim DefautlPicS As Size
                        Dim CustomBoolFont As String = ""
                        Dim StrDict As Dictionary(Of String, String) = Fill_CustomString(orph, My.Settings.WordSelectedTemplete, Destination_FileName, imgDict, UseBookMark, UseDefaultPicS, DefautlPicS, boolDict, CustomBoolFont)
                        If Not IsNothing(StrDict) AndAlso (StrDict.Count > 0 OrElse imgDict.Count > 0) Then
                            Dim CtW As New CTWBCOM.BookMarkInserter(Destination_FileName)
                            CtW.ThrowExceptions = True
                            CtW.UseImageBorder = True
                            CtW.UseLastParagraphSetting = True
                            CtW.ImageBookMarks = imgDict
                            CtW.StringBookMarks = StrDict
                            CtW.UseDefaultImageSize = UseDefaultPicS
                            CtW.DefuaultImageSize = DefautlPicS
                            CtW.UseCustomBoolean = IIf(IsNothing(boolDict), False, True)
                            CtW.BoolBookmarke = boolDict
                            CtW.CustomBoolFontName = CustomBoolFont
                            If UseBookMark Then
                                CtW.AddAfterBookmark()
                            Else
                                CtW.ReplaceText()
                            End If
                        End If
                    Else
                        'Use OpenXml
                        Dim imgDict As New Dictionary(Of String, Image)
                        Dim boolDict As New Dictionary(Of String, Integer)
                        Dim UseBookMark As Boolean = False
                        Dim UseDefaultPicS As Boolean
                        Dim DefautlPicS As Size
                        Dim customFont As String = ""
                        Dim StrDict As Dictionary(Of String, String) = Fill_CustomString(orph, My.Settings.WordSelectedTemplete, Destination_FileName, imgDict, UseBookMark, UseDefaultPicS, DefautlPicS, boolDict, customFont)
                        If Not IsNothing(StrDict) AndAlso (StrDict.Count > 0 OrElse imgDict.Count > 0) Then
                            Dim CtW As New CTWBOXML.BookMarkReplacer(Destination_FileName)
                            CtW.ThrowExceptions = True
                            CtW.UseImageBorder = True
                            CtW.UseLastParagraphSetting = True
                            CtW.ImageBookMarks = imgDict
                            CtW.StringBookMarks = StrDict
                            CtW.DefuaultImageSize = DefautlPicS
                            CtW.UseDefaultImageSize = UseDefaultPicS
                            CtW.CustomBoolFontName = customFont
                            CtW.UseCustomBoolean = IIf(IsNothing(boolDict), False, True)
                            CtW.BoolBookmarke = boolDict
                            If UseBookMark Then
                                'CtW.A
                                CtW.AddAfterBookmark()
                            Else
                                CtW.ReplaceText()
                            End If
                        End If
                    End If
                End If
                If My.Settings.WordExportDocuments Then
                    Dim fold = Path.GetDirectoryName(Destination_FileName)
                    ExportDocument(orph, fold)
                End If
                If My.Settings.WordMakeOneFile Then
                    SavedFiles.Add(Destination_FileName)
                End If
                i += 1
                Dim prog As Integer = CInt((i / CDec(O_IDs.Length)) * 100D)
                ProgressSate.ShowStatueProgress(prog, Getter.GetFullName(orph.Name))
                Odb.Dispose()
            End Using
        Next
        'Make One File
        If O_IDs.Length > 1 AndAlso My.Settings.WordMakeOneFile Then
            Try
                Dim MergerFileName As String = ShowWordSave()
                Dim CtwXml As New CTWBOXML.DocMerger
                CtwXml.DestinationFile = SavedFiles(0)
                Dim strFile(SavedFiles.Count - 2) As String
                For i1 As Integer = 1 To SavedFiles.Count - 1
                    strFile(i1 - 1) = SavedFiles(i1)
                Next
                CtwXml.WordFiles = strFile
                AddHandler CtwXml.StringProgress, AddressOf ProgressSate.ShowStatueProgress
                CtwXml.Merge()
                File.Copy(SavedFiles(0), MergerFileName, True)
                If Not My.Settings.WordMakeNewFolder Then
                    For Each strF In SavedFiles
                        File.Delete(strF)
                    Next
                End If
            Catch ex As Exception
                ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            End Try
        End If
    End Sub


    Public Sub ConvertFamilyToWord(ByVal F_IDs() As Integer)
        Dim SavedFiles As New ArrayList()
        Dim i As Decimal = 0D
        Dim FileName As String
        Dim FullPath As String
        If IsNothing(F_IDs) Then Return
        If F_IDs.Length = 1 Then
            FileName = ShowWordSave()
        Else
            FileName = ShowWordSaveFolder()
        End If
        If IsNothing(FileName) Then Return
        For Each id As Integer In F_IDs
            Using Odb As New OrphanageDB.Odb
                Dim Fam As OrphanageClasses.Family = Getter.GetFamilyByID(id, Odb)
                Dim FamilyFileStringName As String = Getter.GetFullName(Fam.Father.Name) & " و " & Getter.GetFullName(Fam.Mother.Name)
                If IsNothing(Fam) Then Continue For
                Dim Destination_FileName As String
                If F_IDs.Length = 1 Then
                    Destination_FileName = FileName
                Else
                    If My.Settings.WordMakeNewFolder Then
                        FullPath = FileName & "\" & FamilyFileStringName
                        If Not Directory.Exists(FullPath) Then
                            Directory.CreateDirectory(FullPath)
                        End If
                        Destination_FileName = FullPath & "\" & FamilyFileStringName & ".Docx"
                    Else

                        Destination_FileName = FileName & "\" & FamilyFileStringName & ".Docx"
                    End If
                End If
                If My.Settings.ConvertToWordByCom Then
                    Dim imgDict As New Dictionary(Of String, Image)
                    Dim boolDict As New Dictionary(Of String, Integer)
                    Dim UseBookMark As Boolean = False
                    Dim UseDefaultPicS As Boolean
                    Dim DefautlPicS As Size
                    Dim CustomBoolFont As String = ""
                    Dim StrDict As Dictionary(Of String, String) = Fill_CustomString(Fam, My.Settings.WordSelectedTemplete, Destination_FileName, imgDict, UseBookMark, UseDefaultPicS, DefautlPicS, boolDict, CustomBoolFont)
                    If Not IsNothing(StrDict) AndAlso (StrDict.Count > 0 OrElse imgDict.Count > 0) Then
                        Dim CtW As New CTWBCOM.BookMarkInserter(Destination_FileName)
                        CtW.ThrowExceptions = True
                        CtW.UseImageBorder = True
                        CtW.UseLastParagraphSetting = True
                        CtW.ImageBookMarks = imgDict
                        CtW.StringBookMarks = StrDict
                        CtW.UseDefaultImageSize = UseDefaultPicS
                        CtW.DefuaultImageSize = DefautlPicS
                        CtW.UseCustomBoolean = IIf(IsNothing(boolDict), False, True)
                        CtW.BoolBookmarke = boolDict
                        CtW.CustomBoolFontName = CustomBoolFont
                        If UseBookMark Then
                            CtW.AddAfterBookmark()
                        Else
                            CtW.ReplaceText()
                        End If
                    End If
                Else
                    'Use OpenXml
                    Dim imgDict As New Dictionary(Of String, Image)
                    Dim boolDict As New Dictionary(Of String, Integer)
                    Dim UseBookMark As Boolean = False
                    Dim UseDefaultPicS As Boolean
                    Dim DefautlPicS As Size
                    Dim customFont As String = ""
                    Dim StrDict As Dictionary(Of String, String) = Fill_CustomString(Fam, My.Settings.WordSelectedTemplete, Destination_FileName, imgDict, UseBookMark, UseDefaultPicS, DefautlPicS, boolDict, customFont)
                    If Not IsNothing(StrDict) AndAlso (StrDict.Count > 0 OrElse imgDict.Count > 0) Then
                        Dim CtW As New CTWBOXML.BookMarkReplacer(Destination_FileName)
                        CtW.ThrowExceptions = True
                        CtW.UseImageBorder = True
                        CtW.UseLastParagraphSetting = True
                        CtW.ImageBookMarks = imgDict
                        CtW.StringBookMarks = StrDict
                        CtW.DefuaultImageSize = DefautlPicS
                        CtW.UseDefaultImageSize = UseDefaultPicS
                        CtW.CustomBoolFontName = customFont
                        CtW.UseCustomBoolean = IIf(IsNothing(boolDict), False, True)
                        CtW.BoolBookmarke = boolDict
                        If UseBookMark Then
                            'CtW.A
                            CtW.AddAfterBookmark()
                        Else
                            CtW.ReplaceText()
                        End If
                    End If
                End If
                If My.Settings.WordExportDocuments Then
                    Dim fold = Path.GetDirectoryName(Destination_FileName)
                    ExportDocument(Fam, fold)
                End If
                If My.Settings.WordMakeOneFile Then
                    SavedFiles.Add(Destination_FileName)
                End If
                i += 1
                Dim prog As Integer = CInt((i / CDec(F_IDs.Length)) * 100D)
                ProgressSate.ShowStatueProgress(prog, FamilyFileStringName)
                Odb.Dispose()
            End Using
        Next
        'Make One File
        If F_IDs.Length > 1 AndAlso My.Settings.WordMakeOneFile Then
            Try
                Dim MergerFileName As String = ShowWordSave()
                Dim CtwXml As New CTWBOXML.DocMerger
                CtwXml.DestinationFile = SavedFiles(0)
                Dim strFile(SavedFiles.Count - 2) As String
                For i1 As Integer = 1 To SavedFiles.Count - 1
                    strFile(i1 - 1) = SavedFiles(i1)
                Next
                CtwXml.WordFiles = strFile
                AddHandler CtwXml.StringProgress, AddressOf ProgressSate.ShowStatueProgress
                CtwXml.Merge()
                File.Copy(SavedFiles(0), MergerFileName, True)
                If Not My.Settings.WordMakeNewFolder Then
                    For Each strF In SavedFiles
                        File.Delete(strF)
                    Next
                End If
            Catch ex As Exception
                ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            End Try
        End If
    End Sub


End Class
