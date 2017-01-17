Imports System.Drawing
Imports System.IO
Public Class XmlBuilder
    Private Function AnotherDecode64(ByVal base64Decoded As String) As Byte()
        Dim temp As String = base64Decoded.TrimEnd("=")
        Dim asciiChars As Integer = temp.Length - temp.Count(Function(c) Char.IsWhiteSpace(c))
        Select Case (asciiChars Mod 4)
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
    Public Class BondsMan
        Inherits XmlBuilder
        Private _Orphans() As Orphan
        Public Property Orphans As Orphan()
            Get
                Return _Orphans
            End Get
            Set(ByVal value() As Orphan)
                _Orphans = value
            End Set
        End Property

#Region "Property"
        Private _Bo_FirstName As String
        Public Property Bo_FirstName As String
            Get
                Return _Bo_FirstName
            End Get
            Set(ByVal value As String)
                _Bo_FirstName = value
            End Set
        End Property
        Private _Bo_FatherName As String
        Public Property Bo_FatherName As String
            Get
                Return _Bo_FatherName
            End Get
            Set(ByVal value As String)
                _Bo_FatherName = value
            End Set
        End Property

        Private _Bo_LastName As String
        Public Property Bo_LastName As String
            Get
                Return _Bo_LastName
            End Get
            Set(ByVal value As String)
                _Bo_LastName = value
            End Set
        End Property
        Private _Bo_EFirstName As String
        Public Property Bo_EFirstName As String
            Get
                Return _Bo_EFirstName
            End Get
            Set(ByVal value As String)
                _Bo_EFirstName = value
            End Set
        End Property
        Private _Bo_EFatherName As String
        Public Property Bo_EFatherName As String
            Get
                Return _Bo_EFatherName
            End Get
            Set(ByVal value As String)
                _Bo_EFatherName = value
            End Set
        End Property
        Private _Bo_ELastName As String
        Public Property Bo_ELastName As String
            Get
                Return _Bo_ELastName
            End Get
            Set(ByVal value As String)
                _Bo_ELastName = value
            End Set
        End Property
        Private _Bo_IdentityNumber As String
        Public Property Bo_IdentityNumber As String
            Get
                Return _Bo_IdentityNumber
            End Get
            Set(ByVal value As String)
                _Bo_IdentityNumber = value
            End Set
        End Property
        Private _Bo_IdentityPhoto1 As Image
        Public Property Bo_IdentityPhoto1 As Image
            Get
                Return _Bo_IdentityPhoto1
            End Get
            Set(ByVal value As Image)
                _Bo_IdentityPhoto1 = value
            End Set
        End Property
        Private _Bo_IdentityPhoto2 As Image
        Public Property Bo_IdentityPhoto2 As Image
            Get
                Return _Bo_IdentityPhoto2
            End Get
            Set(ByVal value As Image)
                _Bo_IdentityPhoto2 = value
            End Set
        End Property
        Private _Bo_Jop As String
        Public Property Bo_Jop As String
            Get
                Return _Bo_Jop
            End Get
            Set(ByVal value As String)
                _Bo_Jop = value
            End Set
        End Property
        Private _Bo_Income As String
        Public Property Bo_Income As String
            Get
                Return _Bo_Income
            End Get
            Set(ByVal value As String)
                _Bo_Income = value
            End Set
        End Property
        Private _Bo_Note As String
        Public Property Bo_Note As String
            Get
                Return _Bo_Note
            End Get
            Set(ByVal value As String)
                _Bo_Note = value
            End Set
        End Property
        Private _Bo_FingerPrint As Image
        Public Property Bo_FingerPrint As Image
            Get
                Return _Bo_FingerPrint
            End Get
            Set(ByVal value As Image)
                _Bo_FingerPrint = value
            End Set
        End Property
        Private _Bo_Add_Country As String
        Public Property Bo_Add_Country As String
            Get
                Return _Bo_Add_Country
            End Get
            Set(ByVal value As String)
                _Bo_Add_Country = value
            End Set
        End Property
        Private _Bo_Add_City As String
        Public Property Bo_Add_City As String
            Get
                Return _Bo_Add_City
            End Get
            Set(ByVal value As String)
                _Bo_Add_City = value
            End Set
        End Property
        Private _Bo_Add_Town As String
        Public Property Bo_Add_Town As String
            Get
                Return _Bo_Add_Town
            End Get
            Set(ByVal value As String)
                _Bo_Add_Town = value
            End Set
        End Property
        Private _Bo_Add_Street As String
        Public Property Bo_Add_Street As String
            Get
                Return _Bo_Add_Street
            End Get
            Set(ByVal value As String)
                _Bo_Add_Street = value
            End Set
        End Property
        Private _Bo_Add_HomePhone As String
        Public Property Bo_Add_HomePhone As String
            Get
                Return _Bo_Add_HomePhone
            End Get
            Set(ByVal value As String)
                _Bo_Add_HomePhone = value
            End Set
        End Property
        Private _Bo_Add_CellPhone As String
        Public Property Bo_Add_CellPhone As String
            Get
                Return _Bo_Add_CellPhone
            End Get
            Set(ByVal value As String)
                _Bo_Add_CellPhone = value
            End Set
        End Property
        Private _Bo_Add_WorkPhone As String
        Public Property Bo_Add_WorkPhone As String
            Get
                Return _Bo_Add_WorkPhone
            End Get
            Set(ByVal value As String)
                _Bo_Add_WorkPhone = value
            End Set
        End Property
        Private _Bo_Add_Fax As String
        Public Property Bo_Add_Fax As String
            Get
                Return _Bo_Add_Fax
            End Get
            Set(ByVal value As String)
                _Bo_Add_Fax = value
            End Set
        End Property
        Private _Bo_Add_Email As String
        Public Property Bo_Add_Email As String
            Get
                Return _Bo_Add_Email
            End Get
            Set(ByVal value As String)
                _Bo_Add_Email = value
            End Set
        End Property
        Private _Bo_Add_Facebook As String
        Public Property Bo_Add_Facebook As String
            Get
                Return _Bo_Add_Facebook
            End Get
            Set(ByVal value As String)
                _Bo_Add_Facebook = value
            End Set
        End Property
        Private _Bo_Add_Twitter As String
        Public Property Bo_Add_Twitter As String
            Get
                Return _Bo_Add_Twitter
            End Get
            Set(ByVal value As String)
                _Bo_Add_Twitter = value
            End Set
        End Property
        Private _Bo_Add_Note As String
        Public Property Bo_Add_Note As String
            Get
                Return _Bo_Add_Note
            End Get
            Set(ByVal value As String)
                _Bo_Add_Note = value
            End Set
        End Property
#End Region
        Public Function GetBondsMan() As XElement
            Dim ret = <BondsMan>
                          <Name>
                              <First><%= IIf(Not IsNothing(_Bo_FirstName), _Bo_FirstName, "") %></First>
                              <Father><%= IIf(Not IsNothing(_Bo_FatherName), _Bo_FatherName, "") %></Father>
                              <Last><%= IIf(Not IsNothing(_Bo_LastName), _Bo_LastName, "") %></Last>
                              <EFirst><%= IIf(Not IsNothing(_Bo_EFirstName), _Bo_EFirstName, "") %></EFirst>
                              <EFather><%= IIf(Not IsNothing(_Bo_EFatherName), _Bo_EFatherName, "") %></EFather>
                              <ELast><%= IIf(Not IsNothing(_Bo_ELastName), _Bo_ELastName, "") %></ELast>
                          </Name>
                          <IdentityPhoto1><%= _Bo_IdentityPhoto1.To64bitStr %></IdentityPhoto1>
                          <IdentityPhoto2><%= _Bo_IdentityPhoto2.To64bitStr %></IdentityPhoto2>
                          <IdentityNumber><%= IIf(Not IsNothing(_Bo_IdentityNumber), _Bo_IdentityNumber, "") %></IdentityNumber>
                          <FingerPrint><%= _Bo_FingerPrint.To64bitStr %></FingerPrint>
                          <Address>
                              <State><%= IIf(Not IsNothing(_Bo_Add_Country), _Bo_Add_Country, "") %></State>
                              <City><%= IIf(Not IsNothing(_Bo_Add_City), _Bo_Add_City, "") %></City>
                              <Town><%= IIf(Not IsNothing(_Bo_Add_Town), _Bo_Add_Town, "") %></Town>
                              <Street><%= IIf(Not IsNothing(_Bo_Add_Street), _Bo_Add_Street, "") %></Street>
                              <HomePhone><%= IIf(Not IsNothing(_Bo_Add_HomePhone), _Bo_Add_HomePhone, "") %></HomePhone>
                              <CellPhone><%= IIf(Not IsNothing(_Bo_Add_CellPhone), _Bo_Add_CellPhone, "") %></CellPhone>
                              <WorkPhone><%= IIf(Not IsNothing(_Bo_Add_WorkPhone), _Bo_Add_WorkPhone, "") %></WorkPhone>
                              <Fax><%= IIf(Not IsNothing(_Bo_Add_Fax), _Bo_Add_Fax, "") %></Fax>
                              <Email><%= IIf(Not IsNothing(_Bo_Add_Email), _Bo_Add_Email, "") %></Email>
                              <Facebook><%= IIf(Not IsNothing(_Bo_Add_Facebook), _Bo_Add_Facebook, "") %></Facebook>
                              <Twitter><%= IIf(Not IsNothing(_Bo_Add_Twitter), _Bo_Add_Twitter, "") %></Twitter>
                              <Note><%= IIf(Not IsNothing(_Bo_Add_Note), _Bo_Add_Note, "") %></Note>
                          </Address>
                          <Jop><%= IIf(Not IsNothing(_Bo_Jop), _Bo_Jop, "") %></Jop>
                          <Income><%= IIf(Not IsNothing(_Bo_Income), _Bo_Income, "") %></Income>
                          <Note><%= IIf(Not IsNothing(_Bo_Note), _Bo_Note, "") %></Note>
                      </BondsMan>
            Return ret
        End Function
        Public Sub BondsManFromString(ByVal str As XElement)
            Dim memBytes() As Byte
            _Bo_FirstName = str.<Name>.<First>.Value
            _Bo_FatherName = str.<Name>.<Father>.Value
            _Bo_LastName = str.<Name>.<Last>.Value
            _Bo_EFirstName = str.<Name>.<EFirst>.Value
            _Bo_EFatherName = str.<Name>.<EFather>.Value
            _Bo_ELastName = str.<Name>.<ELast>.Value
            Try
                memBytes = AnotherDecode64(str.<IdentityPhoto1>.Value)
                _Bo_IdentityPhoto1 = Image.FromStream(New System.IO.MemoryStream(memBytes))
            Catch
            End Try
            Try
                memBytes = AnotherDecode64(str.<IdentityPhoto2>.Value)
                _Bo_IdentityPhoto2 = Image.FromStream(New System.IO.MemoryStream(memBytes))
            Catch
            End Try
            Try
                memBytes = AnotherDecode64(str.<FingerPrint>.Value)
                _Bo_FingerPrint = Image.FromStream(New System.IO.MemoryStream(memBytes))
            Catch
            End Try
            _Bo_IdentityNumber = str.<IdentityNumber>.Value
            _Bo_Jop = str.<Jop>.Value
            _Bo_Income = str.<Income>.Value
            _Bo_Note = str.<Note>.Value
            _Bo_Add_Country = str.<Address>.<State>.Value
            _Bo_Add_City = str.<Address>.<City>.Value
            _Bo_Add_Town = str.<Address>.<Town>.Value
            _Bo_Add_Street = str.<Address>.<Street>.Value
            _Bo_Add_HomePhone = str.<Address>.<HomePhone>.Value
            _Bo_Add_CellPhone = str.<Address>.<CellPhone>.Value
            _Bo_Add_WorkPhone = str.<Address>.<WorkPhone>.Value
            _Bo_Add_Fax = str.<Address>.<Fax>.Value
            _Bo_Add_Email = str.<Address>.<Email>.Value
            _Bo_Add_Facebook = str.<Address>.<Facebook>.Value
            _Bo_Add_Twitter = str.<Address>.<Twitter>.Value
            _Bo_Add_Note = str.<Address>.<Note>.Value
        End Sub
    End Class
    Public Class Orphan
        Inherits XmlBuilder
#Region "Property"
        Private _FirstName As String
        Public Property FirstName As String
            Get
                Return _FirstName
            End Get
            Set(ByVal value As String)
                _FirstName = value
            End Set
        End Property

        Private _FatherName As String
        Public Property FatherName As String
            Get
                Return _FatherName
            End Get
            Set(ByVal value As String)
                _FatherName = value
            End Set
        End Property
        Private _LastName As String
        Public Property LastName As String
            Get
                Return _LastName
            End Get
            Set(ByVal value As String)
                _LastName = value
            End Set
        End Property
        Private _EFirstName As String
        Public Property EFirstName As String
            Get
                Return _EFirstName
            End Get
            Set(ByVal value As String)
                _EFirstName = value
            End Set
        End Property
        Private _EFatherName As String
        Public Property EFatherName As String
            Get
                Return _EFatherName
            End Get
            Set(ByVal value As String)
                _EFatherName = value
            End Set
        End Property
        Private _ELastName As String
        Public Property ELastName As String
            Get
                Return _ELastName
            End Get
            Set(ByVal value As String)
                _ELastName = value
            End Set
        End Property
        Private _Birthday As Date
        Public Property Birthday As Date
            Get
                Return _Birthday
            End Get
            Set(ByVal value As Date)
                _Birthday = value
            End Set
        End Property
        Private _EducationStage As String
        Public Property EducationStage As String
            Get
                Return _EducationStage
            End Get
            Set(ByVal value As String)
                _EducationStage = value
            End Set
        End Property
        Private _EducationSchool As String
        Public Property EducationSchool As String
            Get
                Return _EducationSchool
            End Get
            Set(ByVal value As String)
                _EducationSchool = value
            End Set
        End Property
        Private _EducationNote As String
        Public Property EducationNote As String
            Get
                Return _EducationNote
            End Get
            Set(ByVal value As String)
                _EducationNote = value
            End Set
        End Property
        Private _EducationMonthlyCost As Double
        Public Property EducationMonthlyCost As Double
            Get
                Return _EducationMonthlyCost
            End Get
            Set(ByVal value As Double)
                _EducationMonthlyCost = value
            End Set
        End Property
        Private _EducationDegreesRate As Integer
        Public Property EducationDegreesRate As Integer
            Get
                Return _EducationDegreesRate
            End Get
            Set(ByVal value As Integer)
                _EducationDegreesRate = value
            End Set
        End Property
        Private _EducationReasons As String
        Public Property EducationReasons As String
            Get
                Return _EducationReasons
            End Get
            Set(ByVal value As String)
                _EducationReasons = value
            End Set
        End Property
        Private _EducationCerPhoto1 As System.Drawing.Image
        Public Property EducationCerPhoto1 As Image
            Get
                Return _EducationCerPhoto1
            End Get
            Set(ByVal value As Image)
                _EducationCerPhoto1 = value
            End Set
        End Property
        Private _EducationCerPhoto2 As System.Drawing.Image
        Public Property EducationCerPhoto2 As Image
            Get
                Return _EducationCerPhoto2
            End Get
            Set(ByVal value As Image)
                _EducationCerPhoto2 = value
            End Set
        End Property
        Private _HealthName As String
        Public Property HealthName As String
            Get
                Return _HealthName
            End Get
            Set(ByVal value As String)
                _HealthName = value
            End Set
        End Property
        Private _HealthMedicen As String
        Public Property HealthMedicen As String
            Get
                Return _HealthMedicen
            End Get
            Set(ByVal value As String)
                _HealthMedicen = value
            End Set
        End Property
        Private _HealthNote As String
        Public Property HealthNote As String
            Get
                Return _HealthNote
            End Get
            Set(ByVal value As String)
                _HealthNote = value
            End Set
        End Property
        Private _HealthCost As Double
        Public Property HealthCost As Double
            Get
                Return _HealthCost
            End Get
            Set(ByVal value As Double)
                _HealthCost = value
            End Set
        End Property
        Private _HealthDoctor As String
        Public Property HealthDoctor As String
            Get
                Return _HealthDoctor
            End Get
            Set(ByVal value As String)
                _HealthDoctor = value
            End Set
        End Property
        Private _HealthReportFile As System.Drawing.Image
        Public Property HealthReportFile As Image
            Get
                Return _HealthReportFile
            End Get
            Set(ByVal value As Image)
                _HealthReportFile = value
            End Set
        End Property
        Private _IsSick As Boolean
        Public Property IsSick As Boolean
            Get
                Return _IsSick
            End Get
            Set(ByVal value As Boolean)
                _IsSick = value
            End Set
        End Property
        Private _FullPhoto As Image
        Public Property FullPhoto As Image
            Get
                Return _FullPhoto
            End Get
            Set(ByVal value As Image)
                _FullPhoto = value
            End Set
        End Property
        Private _FacePhoto As Image
        Public Property FacePhoto As Image
            Get
                Return _FacePhoto
            End Get
            Set(ByVal value As Image)
                _FacePhoto = value
            End Set
        End Property
        Private _IdentityNumber As String
        Public Property IdentityNumber As String
            Get
                Return _IdentityNumber
            End Get
            Set(ByVal value As String)
                _IdentityNumber = value
            End Set
        End Property
        Private _FootSize As Integer
        Public Property FootSiye As Integer
            Get
                Return _FootSize
            End Get
            Set(ByVal value As Integer)
                _FootSize = value
            End Set
        End Property
        Private _Weight As Integer
        Public Property Weight As Integer
            Get
                Return _Weight
            End Get
            Set(ByVal value As Integer)
                _Weight = value
            End Set
        End Property
        Private _Tallness As Integer
        Public Property Tallness As Integer
            Get
                Return _Tallness
            End Get
            Set(ByVal value As Integer)
                _Tallness = value
            End Set
        End Property
        Private _Story As String
        Public Property Story As String
            Get
                Return _Story
            End Get
            Set(ByVal value As String)
                _Story = value
            End Set
        End Property
        Private _FingerPrint As Image
        Public Property FingerPrint As Image
            Get
                Return _FingerPrint
            End Get
            Set(ByVal value As Image)
                _FingerPrint = value
            End Set
        End Property
        Private _BondManRelation As String
        Public Property BondManRelation As String
            Get
                Return _BondManRelation
            End Get
            Set(ByVal value As String)
                _BondManRelation = value
            End Set
        End Property
        Private _BirthCertificate As Image
        Public Property BirthCertificate As Image
            Get
                Return _BirthCertificate
            End Get
            Set(ByVal value As Image)
                _BirthCertificate = value
            End Set
        End Property
        Private _FamilyCardPhoto As Image
        Public Property FamilyCardPhoto As Image
            Get
                Return _FamilyCardPhoto
            End Get
            Set(ByVal value As Image)
                _FamilyCardPhoto = value
            End Set
        End Property
        Private _Gender As String
        Public Property Gender As String
            Get
                Return _Gender
            End Get
            Set(ByVal value As String)
                _Gender = value
            End Set
        End Property
        Private _Kaid As Integer
        Public Property Kaid As Integer
            Get
                Return _Kaid
            End Get
            Set(ByVal value As Integer)
                _Kaid = value
            End Set
        End Property
        Private _Birthplace As String
        Public Property Birthplace As String
            Get
                Return _Birthplace
            End Get
            Set(ByVal value As String)
                _Birthplace = value
            End Set
        End Property
#End Region
        Public Function GetOrphan() As XElement
            Dim ret = <Orphan>
                          <Name>
                              <First><%= IIf(Not IsNothing(_FirstName), _FirstName, "") %></First>
                              <Father><%= IIf(Not IsNothing(_FatherName), _FatherName, "") %></Father>
                              <Last><%= IIf(Not IsNothing(_LastName), _LastName, "") %></Last>
                              <EFirst><%= IIf(Not IsNothing(_EFirstName), _EFirstName, "") %></EFirst>
                              <EFather><%= IIf(Not IsNothing(_EFatherName), _EFatherName, "") %></EFather>
                              <ELast><%= IIf(Not IsNothing(_ELastName), _ELastName, "") %></ELast>
                          </Name>
                          <Birthday><%= IIf(Not IsNothing(_Birthday), _Birthday, "") %></Birthday>
                          <Education>
                              <Stage><%= IIf(Not IsNothing(_EducationStage), _EducationStage, "") %></Stage>
                              <School><%= IIf(Not IsNothing(_EducationSchool), _EducationSchool, "") %></School>
                              <MonthlyCost><%= IIf(Not IsNothing(_EducationMonthlyCost), _EducationMonthlyCost, "") %></MonthlyCost>
                              <DegreesRate><%= IIf(Not IsNothing(_EducationDegreesRate), _EducationDegreesRate, "") %></DegreesRate>
                              <Reasons><%= IIf(Not IsNothing(_EducationReasons), _EducationReasons, "") %></Reasons>
                              <CertificatePhoto><%= _EducationCerPhoto1.To64bitStr %></CertificatePhoto>
                              <CertificatePhoto2><%= _EducationCerPhoto2.To64bitStr %></CertificatePhoto2>
                              <Note><%= IIf(Not IsNothing(_EducationNote), _EducationNote, "") %></Note>
                          </Education>
                          <Healthy>
                              <IsSick><%= _IsSick %></IsSick>
                              <Name><%= IIf(Not IsNothing(_HealthName), _HealthName, "") %></Name>
                              <Medicen><%= IIf(Not IsNothing(_HealthMedicen), _HealthMedicen, "") %></Medicen>
                              <Cost><%= IIf(Not IsNothing(_HealthCost), _HealthCost, "") %></Cost>
                              <Doctor><%= IIf(Not IsNothing(_HealthDoctor), _HealthDoctor, "") %></Doctor>
                              <Note><%= IIf(Not IsNothing(_HealthNote), _HealthNote, "") %></Note>
                              <ReportePhoto><%= _HealthReportFile.To64bitStr %></ReportePhoto>
                          </Healthy>
                          <FullPhoto><%= _FullPhoto.To64bitStr %></FullPhoto>
                          <FacePhoto><%= _FacePhoto.To64bitStr %></FacePhoto>
                          <IdentityNumber><%= IIf(Not IsNothing(_IdentityNumber), _IdentityNumber, "") %></IdentityNumber>
                          <FootSize><%= IIf(Not IsNothing(_FootSize), _FootSize, "") %></FootSize>
                          <Weight><%= IIf(Not IsNothing(_Weight), _Weight, "") %></Weight>
                          <Tallness><%= IIf(Not IsNothing(_Tallness), _Tallness, "") %></Tallness>
                          <Story><%= IIf(Not IsNothing(_Story), _Story, "") %></Story>
                          <FingerPrint><%= _FingerPrint.To64bitStr %></FingerPrint>
                          <BondsmanRelation><%= IIf(Not IsNothing(_BondManRelation), _BondManRelation, "") %></BondsmanRelation>
                          <BirthCertificatePhoto><%= BirthCertificate.To64bitStr %></BirthCertificatePhoto>
                          <FamilycardPhoto><%= _FamilyCardPhoto.To64bitStr %></FamilycardPhoto>
                          <Gender><%= IIf(Not IsNothing(_Gender), _Gender, "") %></Gender>
                          <Kaid><%= IIf(Not IsNothing(_Kaid), _Kaid, "") %></Kaid>
                          <Birthplace><%= IIf(Not IsNothing(_Birthplace), _Birthplace, "") %></Birthplace>
                      </Orphan>
            Return ret

        End Function
        Public Function OrphanFromXML(ByVal str As XElement) As Boolean
            Dim ret As Boolean = False
            Try
                _FirstName = str.<Name>.<First>.Value
                _FatherName = str.<Name>.<Father>.Value
                _LastName = str.<Name>.<Last>.Value
                _EFirstName = str.<Name>.<EFirst>.Value
                _EFatherName = str.<Name>.<EFather>.Value
                _ELastName = str.<Name>.<ELast>.Value
                _Birthday = CDate(str.<Birthday>.Value)
                _EducationStage = str.<Education>.<Stage>.Value
                _EducationSchool = str.<Education>.<School>.Value
                _EducationMonthlyCost = CDbl(str.<Education>.<MonthlyCost>.Value)
                _EducationDegreesRate = CInt(str.<Education>.<DegreesRate>.Value)
                _EducationReasons = str.<Education>.<Reasons>.Value
                Dim memBytes() As Byte
                Try
                    memBytes = AnotherDecode64(str.<Education>.<CertificatePhoto>.Value)
                    _EducationCerPhoto1 = Image.FromStream(New System.IO.MemoryStream(memBytes))
                Catch
                End Try
                Try
                    memBytes = AnotherDecode64(str.<Education>.<CertificatePhoto2>.Value)
                    _EducationCerPhoto2 = Image.FromStream(New System.IO.MemoryStream(memBytes))
                Catch
                End Try
                _EducationNote = str.<Education>.<Note>.Value
                _IsSick = CBool(str.<Healthy>.<IsSick>.Value)
                _HealthCost = CDbl(str.<Healthy>.<Cost>.Value)
                _HealthDoctor = str.<Healthy>.<Doctor>.Value
                _HealthMedicen = str.<Healthy>.<Medicen>.Value
                _HealthName = str.<Healthy>.<Name>.Value
                _HealthNote = str.<Healthy>.<Note>.Value
                Try
                    memBytes = AnotherDecode64(str.<Healthy>.<ReportePhoto>.Value)
                    _HealthReportFile = Image.FromStream(New System.IO.MemoryStream(memBytes))
                Catch
                End Try
                Try
                    memBytes = AnotherDecode64(str.<FullPhoto>.Value)
                    _FullPhoto = Image.FromStream(New System.IO.MemoryStream(memBytes))
                Catch
                End Try
                Try
                    memBytes = AnotherDecode64(str.<FacePhoto>.Value)
                    _FacePhoto = Image.FromStream(New System.IO.MemoryStream(memBytes))
                Catch
                End Try
                _IdentityNumber = str.<IdentityNumber>.Value
                _FootSize = CInt(str.<FootSize>.Value)
                _Weight = CInt(str.<Weight>.Value)
                _Tallness = CInt(str.<Tallness>.Value)
                _Story = str.<Story>.Value
                _BondManRelation = str.<BondsmanRelation>.Value
                _Gender = str.<Gender>.Value
                _Kaid = CInt(str.<Kaid>.Value)
                _Birthplace = str.<Birthplace>.Value
                Try
                    memBytes = AnotherDecode64(str.<FingerPrint>.Value)
                    _FingerPrint = Image.FromStream(New System.IO.MemoryStream(memBytes))
                Catch
                End Try
                Try
                    memBytes = AnotherDecode64(str.<BirthCertificatePhoto>.Value)
                    BirthCertificate = Image.FromStream(New System.IO.MemoryStream(memBytes))
                Catch
                End Try
                Try
                    memBytes = AnotherDecode64(str.<FamilycardPhoto>.Value)
                    _FamilyCardPhoto = Image.FromStream(New System.IO.MemoryStream(memBytes))
                Catch
                End Try
                ret = True
            Catch
                ret = False
            End Try
            Return ret
        End Function
    End Class

    Private _BondsManS() As BondsMan
    Public Property BondsManS As BondsMan()
        Get
            Return _BondsManS
        End Get
        Set(ByVal value() As BondsMan)
            _BondsManS = value
        End Set
    End Property


#Region "Properties"

    Private _Fath_FirstName As String
    Public Property Fath_FirstName As String
        Get
            Return _Fath_FirstName
        End Get
        Set(ByVal value As String)
            _Fath_FirstName = value
        End Set
    End Property
    Private _Fath_FatherName As String
    Public Property Fath_FatherName As String
        Get
            Return _Fath_FatherName
        End Get
        Set(ByVal value As String)
            _Fath_FatherName = value
        End Set
    End Property
    Private _Fath_LastName As String
    Public Property Fath_LastName As String
        Get
            Return _Fath_LastName
        End Get
        Set(ByVal value As String)
            _Fath_LastName = value
        End Set
    End Property
    Private _Fath_EFirstName As String
    Public Property Fath_EFirstName As String
        Get
            Return _Fath_EFirstName
        End Get
        Set(ByVal value As String)
            _Fath_EFirstName = value
        End Set
    End Property
    Private _Fath_EFatherName As String
    Public Property Fath_EFatherName As String
        Get
            Return _Fath_EFatherName
        End Get
        Set(ByVal value As String)
            _Fath_EFatherName = value
        End Set
    End Property
    Private _Fath_ELastName As String
    Public Property Fath_ELastName As String
        Get
            Return _Fath_ELastName
        End Get
        Set(ByVal value As String)
            _Fath_ELastName = value
        End Set
    End Property
    Private _Fath_Birthday As Date
    Public Property Fath_Birthday As Date
        Get
            Return _Fath_Birthday
        End Get
        Set(ByVal value As Date)
            _Fath_Birthday = value
        End Set
    End Property
    Private _Fath_Dieday As Date
    Public Property Fath_Dieday As Date
        Get
            Return _Fath_Dieday
        End Get
        Set(ByVal value As Date)
            _Fath_Dieday = value
        End Set
    End Property
    Private _Fath_Photo As Image
    Public Property Fath_Photo As Image
        Get
            Return _Fath_Photo
        End Get
        Set(ByVal value As Image)
            _Fath_Photo = value
        End Set
    End Property
    Private _Fath_DeathCertificate As Image
    Public Property Fath_DeathCertificate As Image
        Get
            Return _Fath_DeathCertificate
        End Get
        Set(ByVal value As Image)
            _Fath_DeathCertificate = value
        End Set
    End Property
    Private _Fath_Jop As String
    Public Property Fath_Jop As String
        Get
            Return _Fath_Jop
        End Get
        Set(ByVal value As String)
            _Fath_Jop = value
        End Set
    End Property
    Private _Fath_Story As String
    Public Property Fath_Story As String
        Get
            Return _Fath_Story
        End Get
        Set(ByVal value As String)
            _Fath_Story = value
        End Set
    End Property
    Private _Fath_DeathResone As String
    Public Property Fath_DeathResone As String
        Get
            Return _Fath_DeathResone
        End Get
        Set(ByVal value As String)
            _Fath_DeathResone = value
        End Set
    End Property
    Private _Fath_IdentityNumber As String
    Public Property Fath_IdentityNumber As String
        Get
            Return _Fath_IdentityNumber
        End Get
        Set(ByVal value As String)
            _Fath_IdentityNumber = value
        End Set
    End Property
    Private _Fath_Note As String
    Public Property Fath_Note As String
        Get
            Return _Fath_Note
        End Get
        Set(ByVal value As String)
            _Fath_Note = value
        End Set
    End Property
    Private _Moth_FirstName As String
    Public Property Moth_FirstName As String
        Get
            Return _Moth_FirstName
        End Get
        Set(ByVal value As String)
            _Moth_FirstName = value
        End Set
    End Property
    Private _Moth_FatherName As String
    Public Property Moth_FatherName As String
        Get
            Return _Moth_FatherName
        End Get
        Set(ByVal value As String)
            _Moth_FatherName = value
        End Set
    End Property
    Private _Moth_LastName As String
    Public Property Moth_LastName As String
        Get
            Return _Moth_LastName
        End Get
        Set(ByVal value As String)
            _Moth_LastName = value
        End Set
    End Property

    Private _Moth_EFirstName As String
    Public Property Moth_EFirstName As String
        Get
            Return _Moth_EFirstName
        End Get
        Set(ByVal value As String)
            _Moth_EFirstName = value
        End Set
    End Property

    Private _Moth_EFatherName As String
    Public Property Moth_EFatherName As String
        Get
            Return _Moth_EFatherName
        End Get
        Set(ByVal value As String)
            _Moth_EFatherName = value
        End Set
    End Property

    Private _Moth_ELastName As String
    Public Property Moth_ELastName As String
        Get
            Return _Moth_ELastName
        End Get
        Set(ByVal value As String)
            _Moth_ELastName = value
        End Set
    End Property

    Private _Moth_Birthday As Date
    Public Property Moth_Birthday As String
        Get
            Return _Moth_Birthday
        End Get
        Set(ByVal value As String)
            _Moth_Birthday = value
        End Set
    End Property

    Private _Moth_IsDead As Boolean
    Public Property Moth_IsDead As Boolean
        Get
            Return _Moth_IsDead
        End Get
        Set(ByVal value As Boolean)
            _Moth_IsDead = value
        End Set
    End Property

    Private _Moth_Dieday As Date
    Public Property Moth_Dieday As Date
        Get
            Return _Moth_Dieday
        End Get
        Set(ByVal value As Date)
            _Moth_Dieday = value
        End Set
    End Property

    Private _Moth_IdentityNumber As String
    Public Property Moth_IdentityNumber As String
        Get
            Return _Moth_IdentityNumber
        End Get
        Set(ByVal value As String)
            _Moth_IdentityNumber = value
        End Set
    End Property

    Private _Moth_IdentityPhoto1 As Image
    Public Property Moth_IdentityPhoto1 As Image
        Get
            Return _Moth_IdentityPhoto1
        End Get
        Set(ByVal value As Image)
            _Moth_IdentityPhoto1 = value
        End Set
    End Property

    Private _Moth_IdentityPhoto2 As Image
    Public Property Moth_IdentityPhoto2 As Image
        Get
            Return _Moth_IdentityPhoto2
        End Get
        Set(ByVal value As Image)
            _Moth_IdentityPhoto2 = value
        End Set
    End Property

    Private _Moth_IsMarried As Boolean
    Public Property Moth_IsMarried As Boolean
        Get
            Return _Moth_IsMarried
        End Get
        Set(ByVal value As Boolean)
            _Moth_IsMarried = value
        End Set
    End Property

    Private _Moth_HusbendName As String
    Public Property Moth_HusbendName As String
        Get
            Return _Moth_HusbendName
        End Get
        Set(ByVal value As String)
            _Moth_HusbendName = value
        End Set
    End Property

    Private _Moth_IsOwnOrphans As Boolean
    Public Property Moth_IsOwnOrphans As Boolean
        Get
            Return _Moth_IsOwnOrphans
        End Get
        Set(ByVal value As Boolean)
            _Moth_IsOwnOrphans = value
        End Set
    End Property

    Private _Moth_Jop As String
    Public Property Moth_Jop As String
        Get
            Return _Moth_Jop
        End Get
        Set(ByVal value As String)
            _Moth_Jop = value
        End Set
    End Property

    Private _Moth_Salary As Double
    Public Property Moth_Salary As Double
        Get
            Return _Moth_Salary
        End Get
        Set(ByVal value As Double)
            _Moth_Salary = value
        End Set
    End Property

    Private _Moth_Story As String
    Public Property Moth_Story As String
        Get
            Return _Moth_Story
        End Get
        Set(ByVal value As String)
            _Moth_Story = value
        End Set
    End Property

    Private _Moth_Note As String
    Public Property Moth_Note As String
        Get
            Return _Moth_Note
        End Get
        Set(ByVal value As String)
            _Moth_Note = value
        End Set
    End Property

    Private _Moth_Add_Country As String
    Public Property Moth_Add_Country As String
        Get
            Return _Moth_Add_Country
        End Get
        Set(ByVal value As String)
            _Moth_Add_Country = value
        End Set
    End Property
    Private _Moth_Add_City As String
    Public Property Moth_Add_City As String
        Get
            Return _Moth_Add_City
        End Get
        Set(ByVal value As String)
            _Moth_Add_City = value
        End Set
    End Property
    Private _Moth_Add_Town As String
    Public Property Moth_Add_Town As String
        Get
            Return _Moth_Add_Town
        End Get
        Set(ByVal value As String)
            _Moth_Add_Town = value
        End Set
    End Property
    Private _Moth_Add_Street As String
    Public Property Moth_Add_Street As String
        Get
            Return _Moth_Add_Street
        End Get
        Set(ByVal value As String)
            _Moth_Add_Street = value
        End Set
    End Property
    Private _Moth_Add_HomePhone As String
    Public Property Moth_Add_HomePhone As String
        Get
            Return _Moth_Add_HomePhone
        End Get
        Set(ByVal value As String)
            _Moth_Add_HomePhone = value
        End Set
    End Property
    Private _Moth_Add_CellPhone As String
    Public Property Moth_Add_CellPhone As String
        Get
            Return _Moth_Add_CellPhone
        End Get
        Set(ByVal value As String)
            _Moth_Add_CellPhone = value
        End Set
    End Property
    Private _Moth_Add_WorkPhone As String
    Public Property Moth_Add_WorkPhone As String
        Get
            Return _Moth_Add_WorkPhone
        End Get
        Set(ByVal value As String)
            _Moth_Add_WorkPhone = value
        End Set
    End Property
    Private _Moth_Add_Fax As String
    Public Property Moth_Add_Fax As String
        Get
            Return _Moth_Add_Fax
        End Get
        Set(ByVal value As String)
            _Moth_Add_Fax = value
        End Set
    End Property
    Private _Moth_Add_Email As String
    Public Property Moth_Add_Email As String
        Get
            Return _Moth_Add_Email
        End Get
        Set(ByVal value As String)
            _Moth_Add_Email = value
        End Set
    End Property
    Private _Moth_Add_Facebook As String
    Public Property Moth_Add_Facebook As String
        Get
            Return _Moth_Add_Facebook
        End Get
        Set(ByVal value As String)
            _Moth_Add_Facebook = value
        End Set
    End Property
    Private _Moth_Add_Twitter As String
    Public Property Moth_Add_Twitter As String
        Get
            Return _Moth_Add_Twitter
        End Get
        Set(ByVal value As String)
            _Moth_Add_Twitter = value
        End Set
    End Property
    Private _Fam_CardPhoto1 As Image
    Public Property Fam_CardPhoto1 As Image
        Get
            Return _Fam_CardPhoto1
        End Get
        Set(ByVal value As Image)
            _Fam_CardPhoto1 = value
        End Set
    End Property
    Private _Fam_CardPhoto2 As Image
    Public Property Fam_CardPhoto2 As Image
        Get
            Return _Fam_CardPhoto2
        End Get
        Set(ByVal value As Image)
            _Fam_CardPhoto2 = value
        End Set
    End Property
    Private _Fam_Residence_State As String
    Public Property Fam_Residence_State As String
        Get
            Return _Fam_Residence_State
        End Get
        Set(ByVal value As String)
            _Fam_Residence_State = value
        End Set
    End Property

    Private _Fam_Residence_Type As String
    Public Property Fam_Residence_Type As String
        Get
            Return _Fam_Residence_Type
        End Get
        Set(ByVal value As String)
            _Fam_Residence_Type = value
        End Set
    End Property

    Private _Fam_IsRefugee As Boolean
    Public Property Fam_IsRefugee As Boolean
        Get
            Return _Fam_IsRefugee
        End Get
        Set(ByVal value As Boolean)
            _Fam_IsRefugee = value
        End Set
    End Property

    Private _Fam_CardNumber As String
    Public Property Fam_CardNumber As String
        Get
            Return _Fam_CardNumber
        End Get
        Set(ByVal value As String)
            _Fam_CardNumber = value
        End Set
    End Property

    Private _Fam_Finncial_State As String
    Public Property Fam_Finncial_State As String
        Get
            Return _Fam_Finncial_State
        End Get
        Set(ByVal value As String)
            _Fam_Finncial_State = value
        End Set
    End Property

    Private _Fam_Note As String
    Public Property Fam_Note As String
        Get
            Return _Fam_Note
        End Get
        Set(ByVal value As String)
            _Fam_Note = value
        End Set
    End Property

    Private _Fam_Add_Country As String
    Public Property Fam_Add_Country As String
        Get
            Return _Fam_Add_Country
        End Get
        Set(ByVal value As String)
            _Fam_Add_Country = value
        End Set
    End Property
    Private _Fam_Add_City As String
    Public Property Fam_Add_City As String
        Get
            Return _Fam_Add_City
        End Get
        Set(ByVal value As String)
            _Fam_Add_City = value
        End Set
    End Property
    Private _Fam_Add_Town As String
    Public Property Fam_Add_Town As String
        Get
            Return _Fam_Add_Town
        End Get
        Set(ByVal value As String)
            _Fam_Add_Town = value
        End Set
    End Property
    Private _Fam_Add_Street As String
    Public Property Fam_Add_Street As String
        Get
            Return _Fam_Add_Street
        End Get
        Set(ByVal value As String)
            _Fam_Add_Street = value
        End Set
    End Property
    Private _Fam_Add_HomePhone As String
    Public Property Fam_Add_HomePhone As String
        Get
            Return _Fam_Add_HomePhone
        End Get
        Set(ByVal value As String)
            _Fam_Add_HomePhone = value
        End Set
    End Property
    Private _Fam_Add_CellPhone As String
    Public Property Fam_Add_CellPhone As String
        Get
            Return _Fam_Add_CellPhone
        End Get
        Set(ByVal value As String)
            _Fam_Add_CellPhone = value
        End Set
    End Property
    Private _Fam_Add_WorkPhone As String
    Public Property Fam_Add_WorkPhone As String
        Get
            Return _Fam_Add_WorkPhone
        End Get
        Set(ByVal value As String)
            _Fam_Add_WorkPhone = value
        End Set
    End Property
    Private _Fam_Add_Fax As String
    Public Property Fam_Add_Fax As String
        Get
            Return _Fam_Add_Fax
        End Get
        Set(ByVal value As String)
            _Fam_Add_Fax = value
        End Set
    End Property
    Private _Fam_Add_Email As String
    Public Property Fam_Add_Email As String
        Get
            Return _Fam_Add_Email
        End Get
        Set(ByVal value As String)
            _Fam_Add_Email = value
        End Set
    End Property
    Private _Fam_Add_Facebook As String
    Public Property Fam_Add_Facebook As String
        Get
            Return _Fam_Add_Facebook
        End Get
        Set(ByVal value As String)
            _Fam_Add_Facebook = value
        End Set
    End Property
    Private _Fam_Add_Twitter As String
    Public Property Fam_Add_Twitter As String
        Get
            Return _Fam_Add_Twitter
        End Get
        Set(ByVal value As String)
            _Fam_Add_Twitter = value
        End Set
    End Property
    Private _Fam_Add_Country2 As String
    Public Property Fam_Add_Country2 As String
        Get
            Return _Fam_Add_Country2
        End Get
        Set(ByVal value As String)
            _Fam_Add_Country2 = value
        End Set
    End Property
    Private _Fam_Add_City2 As String
    Public Property Fam_Add_City2 As String
        Get
            Return _Fam_Add_City2
        End Get
        Set(ByVal value As String)
            _Fam_Add_City2 = value
        End Set
    End Property
    Private _Fam_Add_Town2 As String
    Public Property Fam_Add_Town2 As String
        Get
            Return _Fam_Add_Town2
        End Get
        Set(ByVal value As String)
            _Fam_Add_Town2 = value
        End Set
    End Property
    Private _Fam_Add_Street2 As String
    Public Property Fam_Add_Street2 As String
        Get
            Return _Fam_Add_Street2
        End Get
        Set(ByVal value As String)
            _Fam_Add_Street2 = value
        End Set
    End Property
    Private _Fam_Add_HomePhone2 As String
    Public Property Fam_Add_HomePhone2 As String
        Get
            Return _Fam_Add_HomePhone2
        End Get
        Set(ByVal value As String)
            _Fam_Add_HomePhone2 = value
        End Set
    End Property
    Private _Fam_Add_CellPhone2 As String
    Public Property Fam_Add_CellPhone2 As String
        Get
            Return _Fam_Add_CellPhone2
        End Get
        Set(ByVal value As String)
            _Fam_Add_CellPhone2 = value
        End Set
    End Property
    Private _Fam_Add_WorkPhone2 As String
    Public Property Fam_Add_WorkPhone2 As String
        Get
            Return _Fam_Add_WorkPhone2
        End Get
        Set(ByVal value As String)
            _Fam_Add_WorkPhone2 = value
        End Set
    End Property
    Private _Fam_Add_Fax2 As String
    Public Property Fam_Add_Fax2 As String
        Get
            Return _Fam_Add_Fax2
        End Get
        Set(ByVal value As String)
            _Fam_Add_Fax2 = value
        End Set
    End Property
    Private _Fam_Add_Email2 As String
    Public Property Fam_Add_Email2 As String
        Get
            Return _Fam_Add_Email2
        End Get
        Set(ByVal value As String)
            _Fam_Add_Email2 = value
        End Set
    End Property
    Private _Fam_Add_Facebook2 As String
    Public Property Fam_Add_Facebook2 As String
        Get
            Return _Fam_Add_Facebook2
        End Get
        Set(ByVal value As String)
            _Fam_Add_Facebook2 = value
        End Set
    End Property
    Private _Fam_Add_Twitter2 As String
    Public Property Fam_Add_Twitter2 As String
        Get
            Return _Fam_Add_Twitter2
        End Get
        Set(ByVal value As String)
            _Fam_Add_Twitter2 = value
        End Set
    End Property
#End Region
    Private Function GetFamily() As XElement
        Dim ret = <Family>
                      <CardPhoto1><%= _Fam_CardPhoto1.To64bitStr %></CardPhoto1>
                      <CardPhoto2><%= _Fam_CardPhoto2.To64bitStr %></CardPhoto2>
                      <ResidenceState><%= IIf(Not IsNothing(_Fam_Residence_State), _Fam_Residence_State, "") %></ResidenceState>
                      <ResidenceType><%= IIf(Not IsNothing(_Fam_Residence_Type), _Fam_Residence_Type, "") %></ResidenceType>
                      <Address>
                          <State><%= IIf(Not IsNothing(_Fam_Add_Country), _Fam_Add_Country, "") %></State>
                          <City><%= IIf(Not IsNothing(_Fam_Add_City), _Fam_Add_City, "") %></City>
                          <Town><%= IIf(Not IsNothing(_Fam_Add_Town), _Fam_Add_Town, "") %></Town>
                          <Street><%= IIf(Not IsNothing(_Fam_Add_Street), _Fam_Add_Street, "") %></Street>
                          <HomePhone><%= IIf(Not IsNothing(_Fam_Add_HomePhone), _Fam_Add_HomePhone, "") %></HomePhone>
                          <CellPhone><%= IIf(Not IsNothing(_Fam_Add_CellPhone), _Fam_Add_CellPhone, "") %></CellPhone>
                          <WorkPhone><%= IIf(Not IsNothing(_Fam_Add_WorkPhone), _Fam_Add_WorkPhone, "") %></WorkPhone>
                          <Fax><%= IIf(Not IsNothing(_Fam_Add_Fax), _Fam_Add_Fax, "") %></Fax>
                          <Email><%= IIf(Not IsNothing(_Fam_Add_Email), _Fam_Add_Email, "") %></Email>
                          <Facebook><%= IIf(Not IsNothing(_Fam_Add_Facebook), _Fam_Add_Facebook, "") %></Facebook>
                          <Twitter><%= IIf(Not IsNothing(_Fam_Add_Twitter), _Fam_Add_Twitter, "") %></Twitter>
                      </Address>
                      <IsRefugee><%= _Fam_IsRefugee %></IsRefugee>
                      <Address2>
                          <State><%= IIf(Not IsNothing(_Fam_Add_Country2), _Fam_Add_Country2, "") %></State>
                          <City><%= IIf(Not IsNothing(_Fam_Add_City2), _Fam_Add_City2, "") %></City>
                          <Town><%= IIf(Not IsNothing(_Fam_Add_Town2), _Fam_Add_Town2, "") %></Town>
                          <Street><%= IIf(Not IsNothing(_Fam_Add_Street2), _Fam_Add_Street2, "") %></Street>
                          <HomePhone><%= IIf(Not IsNothing(_Fam_Add_HomePhone2), _Fam_Add_HomePhone2, "") %></HomePhone>
                          <CellPhone><%= IIf(Not IsNothing(_Fam_Add_CellPhone2), _Fam_Add_CellPhone2, "") %></CellPhone>
                          <WorkPhone><%= IIf(Not IsNothing(_Fam_Add_WorkPhone2), _Fam_Add_WorkPhone2, "") %></WorkPhone>
                          <Fax><%= IIf(Not IsNothing(_Fam_Add_Fax2), _Fam_Add_Fax2, "") %></Fax>
                          <Email><%= IIf(Not IsNothing(_Fam_Add_Email2), _Fam_Add_Email2, "") %></Email>
                          <Facebook><%= IIf(Not IsNothing(_Fam_Add_Facebook2), _Fam_Add_Facebook2, "") %></Facebook>
                          <Twitter><%= IIf(Not IsNothing(_Fam_Add_Twitter2), _Fam_Add_Twitter2, "") %></Twitter>
                      </Address2>
                      <FamilyCardNumber><%= IIf(Not IsNothing(_Fam_CardNumber), _Fam_CardNumber, "") %></FamilyCardNumber>
                      <FinncialState><%= IIf(Not IsNothing(_Fam_Finncial_State), _Fam_Finncial_State, "") %></FinncialState>
                      <Note><%= IIf(Not IsNothing(_Fam_Note), _Fam_Note, "") %></Note>
                  </Family>
        Return ret
    End Function
    Private Sub FamilyFromString(ByVal str As XElement)
        Dim ret As Boolean = False
        Dim memBytes() As Byte
        Try
            memBytes = AnotherDecode64(str.<CardPhoto1>.Value)
            _Fam_CardPhoto1 = Image.FromStream(New System.IO.MemoryStream(memBytes))
        Catch
        End Try
        Try
            memBytes = AnotherDecode64(str.<CardPhoto2>.Value)
            _Fam_CardPhoto2 = Image.FromStream(New System.IO.MemoryStream(memBytes))
        Catch
        End Try
        _Fam_Residence_State = str.<ResidenceState>.Value
        _Fam_Residence_Type = str.<ResidenceType>.Value
        _Fam_IsRefugee = CBool(str.<IsRefugee>.Value)
        _Fam_CardNumber = str.<FamilyCardNumber>.Value
        _Fam_Finncial_State = str.<FinncialState>.Value
        _Fam_Note = str.<Note>.Value
        _Fam_Add_Country = str.<Address>.<State>.Value
        _Fam_Add_City = str.<Address>.<City>.Value
        _Fam_Add_Town = str.<Address>.<Town>.Value
        _Fam_Add_Street = str.<Address>.<Street>.Value
        _Fam_Add_HomePhone = str.<Address>.<HomePhone>.Value
        _Fam_Add_CellPhone = str.<Address>.<CellPhone>.Value
        _Fam_Add_WorkPhone = str.<Address>.<WorkPhone>.Value
        _Fam_Add_Fax = str.<Address>.<Fax>.Value
        _Fam_Add_Email = str.<Address>.<Email>.Value
        _Fam_Add_Facebook = str.<Address>.<Facebook>.Value
        _Fam_Add_Twitter = str.<Address>.<Twitter>.Value
        _Fam_Add_Country2 = str.<Address2>.<State>.Value
        _Fam_Add_City2 = str.<Address2>.<City>.Value
        _Fam_Add_Town2 = str.<Address2>.<Town>.Value
        _Fam_Add_Street2 = str.<Address2>.<Street>.Value
        _Fam_Add_HomePhone2 = str.<Address2>.<HomePhone>.Value
        _Fam_Add_CellPhone2 = str.<Address2>.<CellPhone>.Value
        _Fam_Add_WorkPhone2 = str.<Address2>.<WorkPhone>.Value
        _Fam_Add_Fax2 = str.<Address2>.<Fax>.Value
        _Fam_Add_Email2 = str.<Address2>.<Email>.Value
        _Fam_Add_Facebook2 = str.<Address2>.<Facebook>.Value
        _Fam_Add_Twitter2 = str.<Address2>.<Twitter>.Value
    End Sub
    Private Function GetFather() As XElement
        Dim ret = <Father>
                      <Name>
                          <First><%= IIf(Not IsNothing(_Fath_FirstName), _Fath_FirstName, "") %></First>
                          <Father><%= IIf(Not IsNothing(_Fath_FatherName), _Fath_FatherName, "") %></Father>
                          <Last><%= IIf(Not IsNothing(_Fath_LastName), _Fath_LastName, "") %></Last>
                          <EFirst><%= IIf(Not IsNothing(_Fath_EFirstName), _Fath_EFirstName, "") %></EFirst>
                          <EFather><%= IIf(Not IsNothing(_Fath_EFatherName), _Fath_EFatherName, "") %></EFather>
                          <ELast><%= IIf(Not IsNothing(_Fath_ELastName), _Fath_ELastName, "") %></ELast>
                      </Name>
                      <Birthday><%= IIf(Not IsNothing(_Fath_Birthday), _Fath_Birthday, "") %></Birthday>
                      <Dieday><%= IIf(Not IsNothing(_Fath_Dieday), _Fath_Dieday, "") %></Dieday>
                      <Story><%= IIf(Not IsNothing(_Fath_Story), _Fath_Story, "") %></Story>
                      <DeathCertificatePhoto><%= _Fath_DeathCertificate.To64bitStr %></DeathCertificatePhoto>
                      <Photo><%= _Fath_Photo.To64bitStr %></Photo>
                      <IdentityNumber><%= IIf(Not IsNothing(_Fath_IdentityNumber), _Fath_IdentityNumber, "") %></IdentityNumber>
                      <Jop><%= IIf(Not IsNothing(_Fath_Jop), _Fath_Jop, "") %></Jop>
                      <DeathResone><%= IIf(Not IsNothing(_Fath_DeathResone), _Fath_DeathResone, "") %></DeathResone>
                      <Note><%= IIf(Not IsNothing(_Fath_Note), _Fath_Note, "") %></Note>
                  </Father>
        Return ret
    End Function
    Private Sub FatherFromString(ByVal str As XElement)
        Dim memBytes() As Byte
        _Fath_FirstName = str.<Name>.<First>.Value
        _Fath_FatherName = str.<Name>.<Father>.Value
        _Fath_LastName = str.<Name>.<Last>.Value
        _Fath_EFirstName = str.<Name>.<EFirst>.Value
        _Fath_EFatherName = str.<Name>.<EFather>.Value
        _Fath_ELastName = str.<Name>.<ELast>.Value
        _Fath_Birthday = CDate(str.<Birthday>.Value)
        _Fath_Dieday = CDate(str.<Dieday>.Value)
        _Fath_Story = str.<Story>.Value
        _Fath_Jop = str.<Jop>.Value
        _Fath_DeathResone = str.<DeathResone>.Value
        _Fath_Note = str.<Note>.Value
        _Fath_IdentityNumber = str.<IdentityNumber>.Value
        Try
            memBytes = AnotherDecode64(str.<DeathCertificatePhoto>.Value)
            _Fath_DeathCertificate = Image.FromStream(New System.IO.MemoryStream(memBytes))
        Catch
        End Try
        Try
            memBytes = AnotherDecode64(str.<Photo>.Value)
            _Fath_Photo = Image.FromStream(New System.IO.MemoryStream(memBytes))
        Catch
        End Try
    End Sub
    Private Function GetMother() As XElement
        Dim ret = <Mother>
                      <Name>
                          <First><%= IIf(Not IsNothing(_Moth_FirstName), _Moth_FirstName, "") %></First>
                          <Father><%= IIf(Not IsNothing(_Moth_FatherName), _Moth_FatherName, "") %></Father>
                          <Last><%= IIf(Not IsNothing(_Moth_LastName), _Moth_LastName, "") %></Last>
                          <EFirst><%= IIf(Not IsNothing(_Moth_EFirstName), _Moth_EFirstName, "") %></EFirst>
                          <EFather><%= IIf(Not IsNothing(_Moth_EFatherName), _Moth_EFatherName, "") %></EFather>
                          <ELast><%= IIf(Not IsNothing(_Moth_ELastName), _Moth_ELastName, "") %></ELast>
                      </Name>
                      <Birthday><%= IIf(Not IsNothing(_Moth_Birthday), _Moth_Birthday, "") %></Birthday>
                      <IsDead><%= _Moth_IsDead %></IsDead>
                      <IsMarried><%= _Moth_IsMarried %></IsMarried>
                      <HusbandName><%= IIf(Not IsNothing(_Moth_HusbendName), _Moth_HusbendName, "") %></HusbandName>
                      <IsOwnOrphans><%= _Moth_IsOwnOrphans %></IsOwnOrphans>
                      <Dieday><%= IIf(Not IsNothing(_Moth_Dieday), _Moth_Dieday, "") %></Dieday>
                      <Story><%= IIf(Not IsNothing(_Moth_Story), _Moth_Story, "") %></Story>
                      <IdentityPhoto1><%= _Moth_IdentityPhoto1.To64bitStr %></IdentityPhoto1>
                      <IdentityPhoto2><%= _Moth_IdentityPhoto2.To64bitStr %></IdentityPhoto2>
                      <IdentityNumber><%= IIf(Not IsNothing(_Moth_IdentityNumber), _Moth_IdentityNumber, "") %></IdentityNumber>
                      <Jop><%= IIf(Not IsNothing(_Moth_Jop), _Moth_Jop, "") %></Jop>
                      <Note><%= IIf(Not IsNothing(_Moth_Note), _Moth_Note, "") %></Note>
                      <Income><%= IIf(Not IsNothing(_Moth_Salary), _Moth_Salary, "") %></Income>
                      <Address>
                          <State><%= IIf(Not IsNothing(_Moth_Add_Country), _Moth_Add_Country, "") %></State>
                          <City><%= IIf(Not IsNothing(_Moth_Add_City), _Moth_Add_City, "") %></City>
                          <Town><%= IIf(Not IsNothing(_Moth_Add_Town), _Moth_Add_Town, "") %></Town>
                          <Street><%= IIf(Not IsNothing(_Moth_Add_Street), _Moth_Add_Street, "") %></Street>
                          <HomePhone><%= IIf(Not IsNothing(_Moth_Add_HomePhone), _Moth_Add_HomePhone, "") %></HomePhone>
                          <CellPhone><%= IIf(Not IsNothing(_Moth_Add_CellPhone), _Moth_Add_CellPhone, "") %></CellPhone>
                          <WorkPhone><%= IIf(Not IsNothing(_Moth_Add_WorkPhone), _Moth_Add_WorkPhone, "") %></WorkPhone>
                          <Fax><%= IIf(Not IsNothing(_Moth_Add_Fax), _Moth_Add_Fax, "") %></Fax>
                          <Email><%= IIf(Not IsNothing(_Moth_Add_Email), _Moth_Add_Email, "") %></Email>
                          <Facebook><%= IIf(Not IsNothing(_Moth_Add_Facebook), _Moth_Add_Facebook, "") %></Facebook>
                          <Twitter><%= IIf(Not IsNothing(_Moth_Add_Twitter), _Moth_Add_Twitter, "") %></Twitter>
                      </Address>
                  </Mother>
        Return ret
    End Function
    Private Sub MotherFromString(ByVal str As XElement)
        Dim memBytes() As Byte
        _Moth_FirstName = str.<Name>.<First>.Value
        _Moth_FatherName = str.<Name>.<Father>.Value
        _Moth_LastName = str.<Name>.<Last>.Value
        _Moth_EFirstName = str.<Name>.<EFirst>.Value
        _Moth_EFatherName = str.<Name>.<EFather>.Value
        _Moth_ELastName = str.<Name>.<ELast>.Value
        _Moth_Birthday = CDate(str.<Birthday>.Value)
        _Moth_IsDead = CBool(str.<IsDead>.Value)
        _Moth_IsMarried = CBool(str.<IsMarried>.Value)
        _Moth_HusbendName = str.<HusbandName>.Value
        _Moth_IsOwnOrphans = CBool(str.<IsOwnOrphans>.Value)
        _Moth_Dieday = CDate(str.<Dieday>.Value)
        _Moth_Story = str.<Story>.Value
        _Moth_Jop = str.<Jop>.Value
        _Moth_Note = str.<Note>.Value
        _Moth_Salary = CDbl(str.<Income>.Value)
        _Moth_IdentityNumber = str.<IdentityNumber>.Value
        Try
            memBytes = AnotherDecode64(str.<IdentityPhoto1>.Value)
            _Moth_IdentityPhoto1 = Image.FromStream(New System.IO.MemoryStream(memBytes))
        Catch
        End Try
        Try
            memBytes = AnotherDecode64(str.<IdentityPhoto2>.Value)
            _Moth_IdentityPhoto2 = Image.FromStream(New System.IO.MemoryStream(memBytes))
        Catch
        End Try
        _Moth_Add_Country = str.<Address>.<State>.Value
        _Moth_Add_City = str.<Address>.<City>.Value
        _Moth_Add_Town = str.<Address>.<Town>.Value
        _Moth_Add_Street = str.<Address>.<Street>.Value
        _Moth_Add_HomePhone = str.<Address>.<HomePhone>.Value
        _Moth_Add_CellPhone = str.<Address>.<CellPhone>.Value
        _Moth_Add_WorkPhone = str.<Address>.<WorkPhone>.Value
        _Moth_Add_Fax = str.<Address>.<Fax>.Value
        _Moth_Add_Email = str.<Address>.<Email>.Value
        _Moth_Add_Facebook = str.<Address>.<Facebook>.Value
        _Moth_Add_Twitter = str.<Address>.<Twitter>.Value
    End Sub
    Public Function BuildFamily(ByVal bonds() As BondsMan) As Byte()
        If IsNothing(bonds) Then Return Nothing
        Dim ret As XElement = GetFamily()
        ret.Add(GetFather)
        ret.Add(GetMother)
        For Each bond In bonds
            Dim bnXml As XElement = bond.GetBondsMan()
            For Each ors In bond.Orphans
                bnXml.Add(ors.GetOrphan())
            Next
            ret.Add(bnXml)
        Next
        Dim doc As New XDocument()
        doc.Add(ret)
        Dim mem As New IO.MemoryStream()
        doc.Save(mem)
        Return mem.ToArray()
    End Function
    Public Function BuildFamily() As Byte()
        Return BuildFamily(Me.BondsManS)
    End Function
    Public Sub FromXMLString(ByVal str As String)
        Try
            Dim TempFile As String = My.Computer.FileSystem.GetTempFileName()
            File.WriteAllText(TempFile, str)            
            Dim doc As XDocument = XDocument.Load(TempFile)
            Dim Family = doc...<Family>.First()
            FamilyFromString(Family)
            FatherFromString(Family.<Father>)
            MotherFromString(Family.<Mother>)
            Dim bondsArr As New ArrayList()
            For Each xBo In Family.<BondsMan>
                Dim tbond As New BondsMan
                Dim OrphansArr As New ArrayList
                tbond.BondsManFromString(xBo)
                For Each XOrp In xBo.<Orphan>
                    Dim Torph As New Orphan
                    Torph.OrphanFromXML(XOrp)
                    OrphansArr.Add(Torph)
                Next
                tbond.Orphans = CType(OrphansArr.ToArray(GetType(Orphan)), Orphan())
                bondsArr.Add(tbond)
            Next
            Me.BondsManS = CType(bondsArr.ToArray(GetType(BondsMan)), BondsMan())
            Try
                File.Delete(TempFile)
            Catch
            End Try        
        Catch

        End Try
    End Sub
    Public Sub FromXMLBytes(ByVal bytes() As Byte)
        Try
            Dim doc As XDocument = XDocument.Load(New MemoryStream(bytes))
            Dim Family = doc...<Family>.First()
            FamilyFromString(Family)
            FatherFromString(Family...<Father>.First())
            MotherFromString(Family...<Mother>.First())
            Dim bondsArr As New ArrayList()
            For Each xBo In Family.<BondsMan>
                Dim tbond As New BondsMan
                Dim OrphansArr As New ArrayList
                tbond.BondsManFromString(xBo)
                For Each XOrp In xBo.<Orphan>
                    Dim Torph As New Orphan
                    Torph.OrphanFromXML(XOrp)
                    OrphansArr.Add(Torph)
                Next
                tbond.Orphans = CType(OrphansArr.ToArray(GetType(Orphan)), Orphan())
                bondsArr.Add(tbond)
            Next
            Me.BondsManS = CType(bondsArr.ToArray(GetType(BondsMan)), BondsMan())
        Catch

        End Try
    End Sub
    Public Function OrphanImagesFromXMLBytes(ByVal bytes() As Byte) As Image()
        Try
            Dim doc As XDocument = XDocument.Load(New MemoryStream(bytes))
            Dim Family = doc...<Family>.First()
            Dim OrphansArr As New ArrayList
            For Each xBo In Family.<BondsMan>
                Dim tbond As New BondsMan
                For Each XOrp In xBo.<Orphan>
                    Dim Torph As New Orphan
                    Torph.OrphanFromXML(XOrp)
                    If Not IsNothing(Torph.FacePhoto) Then
                        OrphansArr.Add(Torph.FacePhoto)
                    Else
                        If (Not IsNothing(Torph.FullPhoto)) Then
                            OrphansArr.Add(Torph.FullPhoto)
                        End If
                    End If
                Next
            Next
            Return CType(OrphansArr.ToArray(GetType(Image)), Image())
        Catch
            Return Nothing
        End Try
    End Function
    Public Function OrphanIconsFromXMLBytes(ByVal bytes() As Byte, ByVal sz As Size) As Icon()
        Try
            Dim doc As XDocument = XDocument.Load(New MemoryStream(bytes))
            Dim Family = doc...<Family>.First()
            Dim OrphansArr As New ArrayList
            For Each xBo In Family.<BondsMan>
                Dim tbond As New BondsMan
                For Each XOrp In xBo.<Orphan>
                    Dim Torph As New Orphan
                    Torph.OrphanFromXML(XOrp)
                    If Not IsNothing(Torph.FacePhoto) Then
                        Try
                            Dim bim As Bitmap = New Bitmap(Torph.FacePhoto, sz)
                            Dim ic As Icon = Icon.FromHandle(bim.GetHicon)
                            OrphansArr.Add(ic)
                        Catch
                        End Try
                    Else
                        If (Not IsNothing(Torph.FullPhoto)) Then
                            Try
                                Dim bim As Bitmap = New Bitmap(Torph.FacePhoto, sz)
                                Dim ic As Icon = Icon.FromHandle(bim.GetHicon)
                                OrphansArr.Add(ic)
                            Catch
                            End Try
                        End If
                    End If
                Next
            Next
            Return CType(OrphansArr.ToArray(GetType(Icon)), Icon())
        Catch
            Return Nothing
        End Try
    End Function
    Public Function OrphanIconsFromXMLBytes(ByVal bytes() As Byte) As Icon()
        Try
            Dim doc As XDocument = XDocument.Load(New MemoryStream(bytes))
            Dim Family = doc...<Family>.First()
            Dim OrphansArr As New ArrayList
            For Each xBo In Family.<BondsMan>
                Dim tbond As New BondsMan
                For Each XOrp In xBo.<Orphan>
                    Dim Torph As New Orphan
                    Torph.OrphanFromXML(XOrp)
                    If Not IsNothing(Torph.FacePhoto) Then
                        Try
                            Dim bim As Bitmap = New Bitmap(Torph.FacePhoto)
                            Dim ic As Icon = Icon.FromHandle(bim.GetHicon)
                            OrphansArr.Add(ic)
                        Catch
                        End Try
                    Else
                        If (Not IsNothing(Torph.FullPhoto)) Then
                            Try
                                Dim bim As Bitmap = New Bitmap(Torph.FacePhoto)
                                Dim ic As Icon = Icon.FromHandle(bim.GetHicon)
                                OrphansArr.Add(ic)
                            Catch
                            End Try
                        End If
                    End If
                Next
            Next
            Return CType(OrphansArr.ToArray(GetType(Icon)), Icon())
        Catch
            Return Nothing
        End Try
    End Function
    Public Function GetInfo(ByVal bytes() As Byte) As String()
        Dim Ret() As String = {"?", "?", "?", "?", "?", "?"}
        Try
            Dim FAtherName As String
            Dim MotherName As String
            Dim OrphanCount As String
            Dim BondsManCount As String
            Dim FamilyAddress As String
            Dim TelphoneNumber As String
            Dim doc As XDocument = XDocument.Load(New MemoryStream(bytes))
            Dim Family = doc...<Family>.First()
            FamilyFromString(Family)
            FatherFromString(Family...<Father>.First())
            MotherFromString(Family...<Mother>.First())
            BondsManCount = "عدد المعيلين: " + Family...<BondsMan>.Count().ToString()
            OrphanCount = "عدد الأيتام: " + Family...<Orphan>.Count().ToString()
            TelphoneNumber = "للتواصل: "
            If Me.Fam_IsRefugee Then
                FamilyAddress = "العنوان الحالي: " + Fam_Add_Country2 + "-" + Fam_Add_City2 + "-" + Fam_Add_Town2 + "-" + Fam_Add_Street2
                If Not IsNothing(Me.Fam_Add_CellPhone2) AndAlso Me.Fam_Add_CellPhone2.Length > 0 AndAlso _
                        Not Me.Fam_Add_CellPhone2.Contains("000-000") Then
                    TelphoneNumber += Me.Fam_Add_CellPhone2 + ","
                End If
                If Not IsNothing(Me.Fam_Add_HomePhone2) AndAlso Me.Fam_Add_HomePhone2.Length > 0 AndAlso _
                        Not Me.Fam_Add_HomePhone2.Contains("000-000") Then
                    TelphoneNumber += Me.Fam_Add_HomePhone2 + ","
                End If
                If Not IsNothing(Me.Fam_Add_WorkPhone2) AndAlso Me.Fam_Add_WorkPhone2.Length > 0 AndAlso _
                        Not Me.Fam_Add_WorkPhone2.Contains("000-000") Then
                    TelphoneNumber += Me.Fam_Add_WorkPhone2 + ","
                End If
            Else
                FamilyAddress = "العنوان الاصلي: " + Fam_Add_Country + "-" + Fam_Add_City + "-" + Fam_Add_Town + "-" + Fam_Add_Street
                If Not IsNothing(Me.Fam_Add_CellPhone) AndAlso Me.Fam_Add_CellPhone.Length > 0 AndAlso _
                        Not Me.Fam_Add_CellPhone.Contains("000-000") Then
                    TelphoneNumber += Me.Fam_Add_CellPhone + ","
                End If
                If Not IsNothing(Me.Fam_Add_HomePhone) AndAlso Me.Fam_Add_HomePhone.Length > 0 AndAlso _
                        Not Me.Fam_Add_HomePhone.Contains("000-000") Then
                    TelphoneNumber += Me.Fam_Add_HomePhone + ","
                End If
                If Not IsNothing(Me.Fam_Add_WorkPhone) AndAlso Me.Fam_Add_WorkPhone.Length > 0 AndAlso _
                        Not Me.Fam_Add_WorkPhone.Contains("000-000") Then
                    TelphoneNumber += Me.Fam_Add_WorkPhone + ","
                End If
            End If
            If TelphoneNumber.Length <= 10 Then
                TelphoneNumber += "??????"
            End If
            FAtherName = "اسم المتوفى: " + Me.Fath_FirstName + " " + " " + Me.Fath_LastName
            MotherName = "اسم الزوجة: " + " " + Me.Moth_FirstName + " " + Me.Moth_LastName
            Ret(0) = FAtherName
            Ret(1) = MotherName
            Ret(2) = BondsManCount
            Ret(3) = OrphanCount
            Ret(4) = FamilyAddress
            Ret(5) = TelphoneNumber
        Catch            
        End Try
        Return Ret
    End Function
End Class
