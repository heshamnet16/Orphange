Imports System.IO
Imports DocumentFormat.OpenXml.Wordprocessing
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml
Imports System.Drawing
Imports <xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
Imports <xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
Imports <xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships">
Public Class _3Taa2    

    Public ReadOnly Property Document As XDocument
        Get
            Return _Document
        End Get
    End Property
    Private _Document As XDocument = Nothing
    Private Sign_Yes = "F0FC", Sign_NO As String = "F0FB"
    Public ReadOnly Property Body As XElement
        Get
            If IsNothing(_Document) Then
                Dim ret As XElement = _Document...<Body>.FirstOrDefault()
                If IsNothing(ret) Then
                    Return Nothing
                Else
                    Return ret
                End If
            Else
                Return Nothing
            End If
        End Get
    End Property
    Private _Pages As Dictionary(Of Integer, _3Taa2Data) = Nothing
    Public ReadOnly Property Pages As Dictionary(Of Integer, _3Taa2Data)
        Get
            Return _Pages
        End Get
    End Property

    Public Structure _3Taa2Data
        Public Orphan_FirstName As String
        Public Orphan_FatherName As String
        Public Orphan_LastName As String
        Public Orphan_GranFatherName As String
        Public Orphan_MotherFullName As String
        Public Orphan_Sex As String
        Public Orphan_Birthday As Date
        Public Orphan_IDentityNumber As String
        Public Orphan_Id As Integer
        Public Family_CurAdd_City As String
        Public Family_CurAdd_Town As String
        Public Family_CurAdd_Street As String
        Public Family_CurAdd_BigCity As String
        Public Family_CurAdd_Phone As String
        Public Family_OrgAdd_City As String
        Public Family_OrgAdd_Town As String
        Public Family_OrgAdd_Street As String
        Public Family_OrgAdd_BigCity As String
        Public Family_OrgAdd_Phone As String
        Public Orphan_Brother_Male_Number As Byte
        Public Orphan_Brother_Female_Number As Byte
        Public Mother_IsDead As Boolean
        Public Father_DieDate As Date
        Public Father_DeathReson As String
        Public Mother_IsMarried As Boolean
        Public Mother_IsWorking As Boolean
        Public Mother_MonthlyIncome As Integer
        Public Mother_DieDate As String
        Public BondsMan_FullName As String
        Public Orphan_BondsManRelation As String
        Public Family_IsRentalHouse As String
        Public Family_ResidenceState As String
        Public Family_Finncial_State As String
        Public Education_StageState As String
        Public Education_Degrees As Byte
        Public Education_SchoolName As String
        Public Healthy_IsSick As Boolean
        Public Healthy_SicknessName As String
        Public Healthy_Cost As String
        Public Supporter_FullName As String
        Public Supporter_StartBail As String
        Public Supporter_BailMony As Integer
        Public Supporter_BailDuration As String
        Public Orphan_Img() As Byte
        Public Sub New(ByVal Orphan_FirstName As String, ByVal Orphan_FatherName As String _
                       , ByVal Orphan_LastName As String, ByVal Orphan_GranFatherName As String _
                       , ByVal Orphan_MotherFullName As String, ByVal Orphan_Sex As String, _
                       ByVal Orphan_Birthday As Date, ByVal Orphan_IDentityNumber As String, ByVal Orphan_Image() As Byte, _
                       ByVal Orphan_Id As Integer, ByVal Family_CurAdd_City As String, _
                       ByVal Family_CurAdd_Town As String, ByVal Family_CurAdd_Street As String, _
                       ByVal Family_CurAdd_BigCity As String, ByVal Family_CurAdd_Phone As String, _
                       ByVal Family_OrgAdd_City As String, ByVal Family_OrgAdd_Town As String, _
                       ByVal Family_OrgAdd_Street As String, ByVal Family_OrgAdd_BigCity As String, _
                       ByVal Family_OrgAdd_Phone As String, ByVal Orphan_Brother_Male_Number As Byte, _
                       ByVal Orphan_Brother_Female_Number As Byte, ByVal Mother_IsDead As Boolean, ByVal Father_DieDate As Date _
                       , ByVal Father_DeathReson As String, ByVal Mother_IsMarried As Boolean, _
                       ByVal Mother_IsWorking As Boolean, ByVal Mother_MonthlyIncome As Integer _
                       , ByVal Mother_DieDate As String, ByVal BondsMan_FullName As String, _
                       ByVal Orphan_BondsManRelation As String, ByVal Family_IsRentalHouse As String _
                       , ByVal Family_ResidenceState As String, ByVal Family_Finncial_State As String, _
                       ByVal Education_StageState As String, ByVal Education_Degrees As Byte, ByVal Education_SchoolName As String _
                       , ByVal Healthy_IsSick As Boolean, ByVal Healthy_SicknessName As String, ByVal Healthy_Cost As String)
            Me.Orphan_Img = Orphan_Image
            Me.Orphan_FirstName = Orphan_FirstName
            Me.Orphan_FatherName = Orphan_FatherName
            Me.Orphan_LastName = Orphan_LastName
            Me.Orphan_GranFatherName = Orphan_GranFatherName
            Me.Orphan_MotherFullName = Orphan_MotherFullName
            Me.Orphan_Sex = Orphan_Sex
            Me.Orphan_Birthday = Orphan_Birthday
            Me.Orphan_IDentityNumber = Orphan_IDentityNumber
            Me.Orphan_Id = Orphan_Id
            Me.Family_CurAdd_City = Family_CurAdd_City
            Me.Family_CurAdd_Town = Family_CurAdd_Town
            Me.Family_CurAdd_Street = Family_CurAdd_Street
            Me.Family_CurAdd_BigCity = Family_CurAdd_BigCity
            Me.Family_CurAdd_Phone = Family_CurAdd_Phone
            Me.Family_OrgAdd_City = Family_OrgAdd_City
            Me.Family_OrgAdd_Town = Family_OrgAdd_Town
            Me.Family_OrgAdd_Street = Family_OrgAdd_Street
            Me.Family_OrgAdd_BigCity = Family_OrgAdd_BigCity
            Me.Family_OrgAdd_Phone = Family_OrgAdd_Phone
            Me.Orphan_Brother_Male_Number = Orphan_Brother_Male_Number
            Me.Orphan_Brother_Female_Number = Orphan_Brother_Female_Number
            Me.Mother_IsDead = Mother_IsDead
            Me.Father_DieDate = Father_DieDate
            Me.Father_DeathReson = Father_DeathReson
            Me.Mother_IsMarried = Mother_IsMarried
            Me.Mother_IsWorking = Mother_IsWorking
            Me.Mother_MonthlyIncome = Mother_MonthlyIncome
            Me.Mother_DieDate = Mother_DieDate
            Me.BondsMan_FullName = BondsMan_FullName
            Me.Orphan_BondsManRelation = Orphan_BondsManRelation
            Me.Family_IsRentalHouse = Family_IsRentalHouse
            Me.Family_ResidenceState = Family_ResidenceState
            Me.Family_Finncial_State = Family_Finncial_State
            Me.Education_StageState = Education_StageState
            Me.Education_Degrees = Education_Degrees
            Me.Education_SchoolName = Education_SchoolName
            Me.Healthy_IsSick = Healthy_IsSick
            Me.Healthy_SicknessName = Healthy_SicknessName
            Me.Healthy_Cost = Healthy_Cost
        End Sub
    End Structure

    Private _Data As _3Taa2Data = Nothing
    Public Property DataStructure As _3Taa2Data
        Get
            Return _Data
        End Get
        Set(ByVal value As _3Taa2Data)
            _Data = value
        End Set
    End Property

    Private Sub LoadDocument(ByRef _doc As XDocument, ByVal Data As _3Taa2Data)
        Dim Mother_incom As String
        Dim Sex_Male, Sex_Female As String
        Dim FAmily_Finn_Boor, Family_Finn_Mid, Family_Finn_Good As String
        Dim FAmily_Residence_Boor, Family_Residence_Mid, Family_Residence_Good As String
        Dim Family_RentalHouse, Family_OwnHouse As String
        Dim Mother_Working, Mother_NotWorking As String
        Dim Mother_Married, Mother_NotMarried As String
        Dim Mother_Dead, Mother_NotDead As String
        Dim Health_Sick, Health_NotSick As String
        Dim Education_Level As String
        If Data.Mother_MonthlyIncome > 0 Then
            Mother_incom = Data.Mother_MonthlyIncome.ToString()
        Else
            Mother_incom = "لا يوجد"
        End If
        If Data.Orphan_Sex.Contains("ذ") Then
            Sex_Male = Sign_Yes
            Sex_Female = Sign_NO
        Else
            Sex_Male = Sign_NO
            Sex_Female = Sign_Yes
        End If
        If Data.Family_Finncial_State.Contains("جيد") OrElse Data.Family_Finncial_State.Contains("مقب") Then
            FAmily_Finn_Boor = Sign_NO
            Family_Finn_Mid = Sign_NO
            Family_Finn_Good = Sign_Yes
        ElseIf Data.Family_Finncial_State.Contains("متوسط") Then
            FAmily_Finn_Boor = Sign_NO
            Family_Finn_Mid = Sign_Yes
            Family_Finn_Good = Sign_NO
        Else
            FAmily_Finn_Boor = Sign_Yes
            Family_Finn_Mid = Sign_NO
            Family_Finn_Good = Sign_NO
        End If
        If Data.Family_ResidenceState.Contains("جيد") Then
            FAmily_Residence_Boor = Sign_NO
            Family_Residence_Mid = Sign_NO
            Family_Residence_Good = Sign_Yes
        ElseIf Data.Family_ResidenceState.Contains("جد") Then
            FAmily_Residence_Boor = Sign_Yes
            Family_Residence_Mid = Sign_NO
            Family_Residence_Good = Sign_NO
        Else
            FAmily_Residence_Boor = Sign_NO
            Family_Residence_Mid = Sign_Yes
            Family_Residence_Good = Sign_NO
        End If
        If Data.Family_IsRentalHouse.Contains("مل") Then
            Family_RentalHouse = Sign_NO
            Family_OwnHouse = Sign_Yes
        Else
            Family_RentalHouse = Sign_Yes
            Family_OwnHouse = Sign_NO
        End If
        If Data.Mother_IsWorking Then
            Mother_NotWorking = Sign_NO
            Mother_Working = Sign_Yes
        Else
            Mother_NotWorking = Sign_Yes
            Mother_Working = Sign_NO
        End If
        If Data.Mother_IsMarried Then
            Mother_NotMarried = Sign_NO
            Mother_Married = Sign_Yes
        Else
            Mother_NotMarried = Sign_Yes
            Mother_Married = Sign_NO
        End If
        If Data.Mother_IsDead Then
            Mother_Dead = Sign_Yes
            Mother_NotDead = Sign_NO
        Else
            Mother_Dead = Sign_NO
            Mother_NotDead = Sign_Yes
        End If
        If Not Data.Healthy_IsSick Then
            Health_NotSick = Sign_Yes
            Health_Sick = Sign_NO
        Else
            Health_NotSick = Sign_NO
            Health_Sick = Sign_Yes
        End If
        If Data.Education_Degrees >= 40 AndAlso Data.Education_Degrees <= 60 Then
            Education_Level = "متوسط"
        ElseIf Data.Education_Degrees > 60 AndAlso Data.Education_Degrees <= 70 Then
            Education_Level = "جيد"
        ElseIf Data.Education_Degrees > 70 AndAlso Data.Education_Degrees <= 80 Then
            Education_Level = "جيد جداً"
        ElseIf Data.Education_Degrees > 80 AndAlso Data.Education_Degrees <= 100 Then
            Education_Level = "ممتاز"
        ElseIf Data.Education_Degrees >= 30 AndAlso Data.Education_Degrees < 40 Then
            Education_Level = "ضعيف"
        ElseIf Data.Education_Degrees = 0 Then
            Education_Level = ""
        Else
            Education_Level = "ضعيف جداً"
        End If

        _doc = <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
               <w:document xmlns:wpc="http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas" xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:m="http://schemas.openxmlformats.org/officeDocument/2006/math" xmlns:v="urn:schemas-microsoft-com:vml" xmlns:wp14="http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing" xmlns:wp="http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing" xmlns:w10="urn:schemas-microsoft-com:office:word" xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main" xmlns:w14="http://schemas.microsoft.com/office/word/2010/wordml" xmlns:w15="http://schemas.microsoft.com/office/word/2012/wordml" xmlns:wpg="http://schemas.microsoft.com/office/word/2010/wordprocessingGroup" xmlns:wpi="http://schemas.microsoft.com/office/word/2010/wordprocessingInk" xmlns:wne="http://schemas.microsoft.com/office/word/2006/wordml" xmlns:wps="http://schemas.microsoft.com/office/word/2010/wordprocessingShape" mc:Ignorable="w14 w15 wp14">
                   <w:body>
                       <w:p w:rsidR="00FB585F" w:rsidRDefault="00E35D26" w:rsidP="00B4518E">
                           <w:bookmarkStart w:id="0" w:name="_GoBack"/>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shapetype id="_x0000_t202" coordsize="21600,21600" o:spt="202" path="m,l,21600r21600,l21600,xe">
                                       <v:stroke joinstyle="miter"/>
                                       <v:path gradientshapeok="t" o:connecttype="rect"/>
                                   </v:shapetype>
                                   <v:shape id="_x0000_s1034" type="#_x0000_t202" style="position:absolute;margin-left:315.1pt;margin-top:-497.1pt;width:16.3pt;height:17.75pt;z-index:251636736;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1034">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00E35D26" w:rsidRPr="001970EA" w:rsidRDefault="00E35D26" w:rsidP="00E35D26">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Sex_Female %>/>
                                                   </w:r>
                                               </w:p>
                                               <w:p w:rsidR="0075152E" w:rsidRPr="002D35AC" w:rsidRDefault="0075152E" w:rsidP="00834F30">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r w:rsidR="005969DA">
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1125" type="#_x0000_t202" style="position:absolute;margin-left:353.25pt;margin-top:-31.75pt;width:17.4pt;height:22pt;z-index:251677696;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1125">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00FF54C0" w:rsidRPr="001970EA" w:rsidRDefault="005969DA" w:rsidP="00FF54C0">
                                                   <w:pPr>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Family_Residence_Mid %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r w:rsidR="005969DA">
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1094" type="#_x0000_t202" style="position:absolute;margin-left:28.9pt;margin-top:-285.2pt;width:20.05pt;height:22.65pt;z-index:251654144;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1094">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="001970EA" w:rsidRDefault="005969DA" w:rsidP="007C3E5D">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Mother_NotMarried %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r w:rsidR="005969DA">
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1127" type="#_x0000_t202" style="position:absolute;margin-left:-20.2pt;margin-top:-164.75pt;width:17.4pt;height:20.15pt;z-index:251679744;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1127">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00FF54C0" w:rsidRPr="001970EA" w:rsidRDefault="005969DA" w:rsidP="00FF54C0">
                                                   <w:pPr>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= FAmily_Finn_Boor %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r w:rsidR="005969DA">
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1135" type="#_x0000_t202" style="position:absolute;margin-left:68.15pt;margin-top:-165.95pt;width:15.05pt;height:15.65pt;z-index:251684864;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1135">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00EF5E0B" w:rsidRPr="001970EA" w:rsidRDefault="005969DA" w:rsidP="007C3E5D">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Family_Finn_Mid %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r w:rsidR="005969DA">
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1102" type="#_x0000_t202" style="position:absolute;margin-left:144.85pt;margin-top:-164.65pt;width:15.05pt;height:15.65pt;z-index:251660288;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1102">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="001970EA" w:rsidRDefault="005969DA" w:rsidP="005969DA">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Family_Finn_Good %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r w:rsidR="005969DA">
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1097" type="#_x0000_t202" style="position:absolute;margin-left:435.45pt;margin-top:-164.65pt;width:23.2pt;height:23.2pt;z-index:251657216;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1097">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="005969DA" w:rsidRDefault="005969DA" w:rsidP="005969DA">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="005969DA">
                                                       <w:rPr>
                                                           <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Family_Residence_Good %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r w:rsidR="005969DA">
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1129" type="#_x0000_t202" style="position:absolute;margin-left:26.3pt;margin-top:-326pt;width:17.4pt;height:22pt;z-index:251681792;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1129">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00FF54C0" w:rsidRPr="001970EA" w:rsidRDefault="005969DA" w:rsidP="00DC25BD">
                                                   <w:pPr>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Mother_NotDead %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r w:rsidR="005969DA">
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1093" type="#_x0000_t202" style="position:absolute;margin-left:133.6pt;margin-top:-286.5pt;width:18.3pt;height:18.2pt;z-index:251653120;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1093">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="001970EA" w:rsidRDefault="005969DA" w:rsidP="00DC25BD">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Mother_Married %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r w:rsidR="00B00E5E">
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1134" type="#_x0000_t202" style="position:absolute;margin-left:358.7pt;margin-top:-496.35pt;width:29pt;height:22.2pt;z-index:251683840;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1134">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00DF53D2" w:rsidRPr="001970EA" w:rsidRDefault="00B00E5E" w:rsidP="00572971">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Sex_Male %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1118" type="#_x0000_t202" style="position:absolute;margin-left:80.6pt;margin-top:-247.2pt;width:115.75pt;height:24.75pt;z-index:251674624;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1118">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00F65CBC" w:rsidRPr="001970EA" w:rsidRDefault="00EF5E0B" w:rsidP="00F65CBC">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Mother_incom %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1138" type="#_x0000_t202" style="position:absolute;margin-left:-74.85pt;margin-top:-608.7pt;width:94.2pt;height:23.35pt;z-index:251687936;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQCiUCKECgIAAPIDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vtjxkqwxohRduw4D&#xa;ugvQ7gNkWY6FSaImKbGzrx8lp2mwvQ3zgyCa5CHPIbW5Ho0mB+mDAsvofFZSIq2AVtkdo9+f7t9c&#xa;URIity3XYCWjRxno9fb1q83gallBD7qVniCIDfXgGO1jdHVRBNFLw8MMnLTo7MAbHtH0u6L1fEB0&#xa;o4uqLFfFAL51HoQMAf/eTU66zfhdJ0X82nVBRqIZxd5iPn0+m3QW2w2vd567XolTG/wfujBcWSx6&#xa;hrrjkZO9V39BGSU8BOjiTIApoOuUkJkDspmXf7B57LmTmQuKE9xZpvD/YMWXwzdPVMvoihLLDY7o&#xa;SY6RvIeRVEmdwYUagx4dhsURf+OUM9PgHkD8CMTCbc/tTt54D0MveYvdzVNmcZE64YQE0gyfocUy&#xa;fB8hA42dN0k6FIMgOk7peJ5MakWkkvP1qlwtKBHoq9art9Uil+D1c7bzIX6UYEi6MOpx8hmdHx5C&#xa;TN3w+jkkFbNwr7TO09eWDIyul9UyJ1x4jIq4nFoZRq/K9E3rkkh+sG1Ojlzp6Y4FtD2xTkQnynFs&#xa;RgxMUjTQHpG/h2kJ8dHgpQf/i5IBF5DR8HPPvaREf7Ko4Xq+WKSNzcZi+a5Cw196mksPtwKhGI2U&#xa;TNfbmLd84nqDWncqy/DSyalXXKyszukRpM29tHPUy1Pd/gYAAP//AwBQSwMEFAAGAAgAAAAhAMWV&#xa;D9nhAAAADwEAAA8AAABkcnMvZG93bnJldi54bWxMj8FOwzAMhu9IvENkJG5bklK6tTSdEIgraAMm&#xa;ccuarK1onKrJ1vL2eCc4/van35/Lzex6drZj6DwqkEsBzGLtTYeNgo/3l8UaWIgaje49WgU/NsCm&#xa;ur4qdWH8hFt73sWGUQmGQitoYxwKzkPdWqfD0g8WaXf0o9OR4thwM+qJyl3PEyEy7nSHdKHVg31q&#xa;bf29OzkFn6/Hr30q3ppndz9MfhYcXc6Vur2ZHx+ARTvHPxgu+qQOFTkd/AlNYD3lTCaEKlhIKfMU&#xa;GDF3aZ4BO1xmYpWsgFcl//9H9QsAAP//AwBQSwECLQAUAAYACAAAACEAtoM4kv4AAADhAQAAEwAA&#xa;AAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRfVHlwZXNdLnhtbFBLAQItABQABgAIAAAAIQA4/SH/1gAA&#xa;AJQBAAALAAAAAAAAAAAAAAAAAC8BAABfcmVscy8ucmVsc1BLAQItABQABgAIAAAAIQCiUCKECgIA&#xa;APIDAAAOAAAAAAAAAAAAAAAAAC4CAABkcnMvZTJvRG9jLnhtbFBLAQItABQABgAIAAAAIQDFlQ/Z&#xa;4QAAAA8BAAAPAAAAAAAAAAAAAAAAAGQEAABkcnMvZG93bnJldi54bWxQSwUGAAAAAAQABADzAAAA&#xa;cgUAAAAA&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1138">
                                           <w:txbxContent>
                                               <w:p w:rsidR="0045613D" w:rsidRPr="001970EA" w:rsidRDefault="0045613D" w:rsidP="007C3E5D">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Orphan_IDentityNumber %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1042" type="#_x0000_t202" style="position:absolute;margin-left:234.8pt;margin-top:-420pt;width:60.35pt;height:19.6pt;z-index:251643904;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1042">
                                           <w:txbxContent>
                                               <w:p w:rsidR="0075152E" w:rsidRPr="00DF53D2" w:rsidRDefault="00DF53D2" w:rsidP="00DF53D2">
                                                   <w:pPr>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="00DF53D2">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Family_CurAdd_Town %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1100" type="#_x0000_t202" style="position:absolute;margin-left:115.75pt;margin-top:-205.45pt;width:17.2pt;height:22.1pt;z-index:251659264;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1100">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="001970EA" w:rsidRDefault="007D1D9E" w:rsidP="002D35AC">
                                                   <w:pPr>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Family_OwnHouse %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1105" type="#_x0000_t202" style="position:absolute;margin-left:294.5pt;margin-top:-32.2pt;width:15.8pt;height:17.15pt;z-index:251663360;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1105">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="001970EA" w:rsidRDefault="005969DA" w:rsidP="007C3E5D">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Health_Sick %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1095" type="#_x0000_t202" style="position:absolute;margin-left:422.65pt;margin-top:-245.45pt;width:17.7pt;height:16.95pt;z-index:251655168;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1095">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="001970EA" w:rsidRDefault="005969DA" w:rsidP="007C3E5D">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Mother_Working %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r w:rsidR="001970EA">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <w:drawing>
                                   <wp:anchor distT="0" distB="0" distL="114300" distR="114300" simplePos="0" relativeHeight="251663872" behindDoc="1" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="31CE9DD2" wp14:editId="5E895761">
                                       <wp:simplePos x="0" y="0"/>
                                       <wp:positionH relativeFrom="column">
                                           <wp:posOffset>-1158903</wp:posOffset>
                                       </wp:positionH>
                                       <wp:positionV relativeFrom="paragraph">
                                           <wp:posOffset>-914400</wp:posOffset>
                                       </wp:positionV>
                                       <wp:extent cx="7581900" cy="10725150"/>
                                       <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                       <wp:wrapSquare wrapText="bothSides"/>
                                       <wp:docPr id="10" name="Picture 2"/>
                                       <wp:cNvGraphicFramePr>
                                           <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" noChangeAspect="1"/>
                                       </wp:cNvGraphicFramePr>
                                       <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                           <a:graphicData uri="http://schemas.openxmlformats.org/drawingml/2006/picture">
                                               <pic:pic xmlns:pic="http://schemas.openxmlformats.org/drawingml/2006/picture">
                                                   <pic:nvPicPr>
                                                       <pic:cNvPr id="0" name="نموذج استمارة يتيم عطاء.jpg"/>
                                                       <pic:cNvPicPr/>
                                                   </pic:nvPicPr>
                                                   <pic:blipFill>
                                                       <a:blip r:embed="rId6" cstate="print">
                                                           <a:extLst>
                                                               <a:ext uri="{28A0092B-C50C-407E-A947-70E740481C1C}">
                                                                   <a14:useLocalDpi xmlns:a14="http://schemas.microsoft.com/office/drawing/2010/main" val="0"/>
                                                               </a:ext>
                                                           </a:extLst>
                                                       </a:blip>
                                                       <a:stretch>
                                                           <a:fillRect/>
                                                       </a:stretch>
                                                   </pic:blipFill>
                                                   <pic:spPr>
                                                       <a:xfrm>
                                                           <a:off x="0" y="0"/>
                                                           <a:ext cx="7581900" cy="10725150"/>
                                                       </a:xfrm>
                                                       <a:prstGeom prst="rect">
                                                           <a:avLst/>
                                                       </a:prstGeom>
                                                   </pic:spPr>
                                               </pic:pic>
                                           </a:graphicData>
                                       </a:graphic>
                                   </wp:anchor>
                               </w:drawing>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1092" type="#_x0000_t202" style="position:absolute;margin-left:228.15pt;margin-top:-286.4pt;width:115.75pt;height:20.45pt;z-index:251652096;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1092">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="001970EA" w:rsidRDefault="00DF53D2" w:rsidP="00880301">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Father_DeathReson %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1087" type="#_x0000_t202" style="position:absolute;margin-left:134.25pt;margin-top:-326.95pt;width:17.75pt;height:18.8pt;z-index:251646976;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1087">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="001970EA" w:rsidRDefault="005969DA" w:rsidP="00DC25BD">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Mother_Dead %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1045" type="#_x0000_t202" style="position:absolute;margin-left:80.6pt;margin-top:-419.4pt;width:81.2pt;height:19.6pt;z-index:251645952;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1045">
                                           <w:txbxContent>
                                               <w:p w:rsidR="0075152E" w:rsidRPr="00DF53D2" w:rsidRDefault="005969DA" w:rsidP="005969DA">
                                                   <w:pPr>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Family_CurAdd_Phone %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1040" type="#_x0000_t202" style="position:absolute;margin-left:168.5pt;margin-top:-419.65pt;width:60.35pt;height:19.6pt;z-index:251641856;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1040">
                                           <w:txbxContent>
                                               <w:p w:rsidR="0075152E" w:rsidRPr="00DF53D2" w:rsidRDefault="00DF53D2" w:rsidP="00DF53D2">
                                                   <w:pPr>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidR="005969DA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Family_CurAdd_Street %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1037" type="#_x0000_t202" style="position:absolute;margin-left:366.15pt;margin-top:-420.3pt;width:60.35pt;height:19.6pt;z-index:251638784;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1037">
                                           <w:txbxContent>
                                               <w:p w:rsidR="0075152E" w:rsidRPr="00DF53D2" w:rsidRDefault="00DF53D2" w:rsidP="00DF53D2">
                                                   <w:pPr>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="00DF53D2">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Family_CurAdd_BigCity %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1137" type="#_x0000_t202" style="position:absolute;margin-left:-41.8pt;margin-top:-388.25pt;width:42.55pt;height:18.2pt;z-index:251686912;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1137">
                                           <w:txbxContent>
                                               <w:p w:rsidR="001970EA" w:rsidRPr="007C3E5D" w:rsidRDefault="001970EA" w:rsidP="007C3E5D">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="16"/>
                                                           <w:szCs w:val="16"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="16"/>
                                                           <w:szCs w:val="16"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Orphan_Id %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1109" type="#_x0000_t202" style="position:absolute;margin-left:-57.2pt;margin-top:30.95pt;width:100.45pt;height:18.7pt;z-index:251667456;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1109">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00F65CBC" w:rsidRPr="001970EA" w:rsidRDefault="00EF5E0B" w:rsidP="00F65CBC">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Supporter_BailDuration %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1108" type="#_x0000_t202" style="position:absolute;margin-left:55.8pt;margin-top:30.95pt;width:100.45pt;height:21.3pt;z-index:251666432;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1108">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00F65CBC" w:rsidRPr="001970EA" w:rsidRDefault="00EF5E0B" w:rsidP="00F65CBC">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Supporter_BailMony %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1107" type="#_x0000_t202" style="position:absolute;margin-left:168.5pt;margin-top:30.9pt;width:100.45pt;height:20.7pt;z-index:251665408;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1107">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00F65CBC" w:rsidRPr="001970EA" w:rsidRDefault="00EF5E0B" w:rsidP="00F65CBC">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Supporter_StartBail %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1110" type="#_x0000_t202" style="position:absolute;margin-left:91.35pt;margin-top:-33.3pt;width:143.45pt;height:23.8pt;z-index:251668480;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1110">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00F65CBC" w:rsidRPr="001970EA" w:rsidRDefault="00EF5E0B" w:rsidP="00EF5E0B">
                                                   <w:pPr>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Healthy_SicknessName %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1111" type="#_x0000_t202" style="position:absolute;margin-left:-63.6pt;margin-top:-32.75pt;width:144.2pt;height:22.15pt;z-index:251669504;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1111">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00F65CBC" w:rsidRPr="001970EA" w:rsidRDefault="00EF5E0B" w:rsidP="00EF5E0B">
                                                   <w:pPr>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Healthy_Cost %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1136" type="#_x0000_t202" style="position:absolute;margin-left:-63.6pt;margin-top:-99.95pt;width:144.25pt;height:30pt;z-index:251685888;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1136">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00EF5E0B" w:rsidRPr="001970EA" w:rsidRDefault="00EF5E0B" w:rsidP="00EF5E0B">
                                                   <w:pPr>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Education_SchoolName %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1113" type="#_x0000_t202" style="position:absolute;margin-left:91.35pt;margin-top:-101.3pt;width:144.25pt;height:30pt;z-index:251671552;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1113">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00F65CBC" w:rsidRPr="001970EA" w:rsidRDefault="00EF5E0B" w:rsidP="00EF5E0B">
                                                   <w:pPr>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Education_Level %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1112" type="#_x0000_t202" style="position:absolute;margin-left:243.45pt;margin-top:-99.35pt;width:144.25pt;height:21.95pt;z-index:251670528;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1112">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00F65CBC" w:rsidRPr="001970EA" w:rsidRDefault="00EF5E0B" w:rsidP="00EF5E0B">
                                                   <w:pPr>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Education_StageState %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1119" type="#_x0000_t202" style="position:absolute;margin-left:-59.95pt;margin-top:-247.2pt;width:115.75pt;height:19.45pt;z-index:251675648;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1119">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00F65CBC" w:rsidRPr="001970EA" w:rsidRDefault="00EF5E0B" w:rsidP="00F65CBC">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Mother_DieDate %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1126" type="#_x0000_t202" style="position:absolute;margin-left:278.4pt;margin-top:-165.3pt;width:17.4pt;height:22pt;z-index:251678720;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1126">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00FF54C0" w:rsidRPr="001970EA" w:rsidRDefault="005969DA" w:rsidP="00FF54C0">
                                                   <w:pPr>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= FAmily_Residence_Boor %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r w:rsidR="00EF5E0B">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <w:drawing>
                                   <wp:anchor distT="0" distB="0" distL="114300" distR="114300" simplePos="0" relativeHeight="251654656" behindDoc="1" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="2ECB2441" wp14:editId="423A9ECA">
                                       <wp:simplePos x="0" y="0"/>
                                       <wp:positionH relativeFrom="column">
                                           <wp:posOffset>-1143000</wp:posOffset>
                                       </wp:positionH>
                                       <wp:positionV relativeFrom="paragraph">
                                           <wp:posOffset>-922351</wp:posOffset>
                                       </wp:positionV>
                                       <wp:extent cx="7581900" cy="10725150"/>
                                       <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                       <wp:wrapSquare wrapText="bothSides"/>
                                       <wp:docPr id="2" name="Picture 2"/>
                                       <wp:cNvGraphicFramePr>
                                           <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" noChangeAspect="1"/>
                                       </wp:cNvGraphicFramePr>
                                       <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                           <a:graphicData uri="http://schemas.openxmlformats.org/drawingml/2006/picture">
                                               <pic:pic xmlns:pic="http://schemas.openxmlformats.org/drawingml/2006/picture">
                                                   <pic:nvPicPr>
                                                       <pic:cNvPr id="0" name="نموذج استمارة يتيم عطاء.jpg"/>
                                                       <pic:cNvPicPr/>
                                                   </pic:nvPicPr>
                                                   <pic:blipFill>
                                                       <a:blip r:embed="rId6" cstate="print">
                                                           <a:extLst>
                                                               <a:ext uri="{28A0092B-C50C-407E-A947-70E740481C1C}">
                                                                   <a14:useLocalDpi xmlns:a14="http://schemas.microsoft.com/office/drawing/2010/main" val="0"/>
                                                               </a:ext>
                                                           </a:extLst>
                                                       </a:blip>
                                                       <a:stretch>
                                                           <a:fillRect/>
                                                       </a:stretch>
                                                   </pic:blipFill>
                                                   <pic:spPr>
                                                       <a:xfrm>
                                                           <a:off x="0" y="0"/>
                                                           <a:ext cx="7581900" cy="10725150"/>
                                                       </a:xfrm>
                                                       <a:prstGeom prst="rect">
                                                           <a:avLst/>
                                                       </a:prstGeom>
                                                   </pic:spPr>
                                               </pic:pic>
                                           </a:graphicData>
                                       </a:graphic>
                                   </wp:anchor>
                               </w:drawing>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1098" type="#_x0000_t202" style="position:absolute;margin-left:367.45pt;margin-top:-165.3pt;width:12.55pt;height:21.25pt;z-index:251658240;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1098">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="001970EA" w:rsidRDefault="005969DA" w:rsidP="007C3E5D">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Family_Residence_Mid %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1089" type="#_x0000_t202" style="position:absolute;margin-left:422.3pt;margin-top:-326pt;width:18.35pt;height:20.8pt;z-index:251649024;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1089">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="001970EA" w:rsidRDefault="00DF53D2" w:rsidP="007C3E5D">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Orphan_Brother_Male_Number.ToString() %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1035" type="#_x0000_t202" style="position:absolute;margin-left:366.15pt;margin-top:-437.05pt;width:60.35pt;height:18.85pt;z-index:251637760;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1035">
                                           <w:txbxContent>
                                               <w:p w:rsidR="0075152E" w:rsidRPr="00DF53D2" w:rsidRDefault="00DF53D2" w:rsidP="0075152E">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="00DF53D2">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Family_OrgAdd_BigCity %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1038" type="#_x0000_t202" style="position:absolute;margin-left:300.55pt;margin-top:-435.75pt;width:60.35pt;height:20.1pt;z-index:251639808;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1038">
                                           <w:txbxContent>
                                               <w:p w:rsidR="0075152E" w:rsidRPr="00DF53D2" w:rsidRDefault="00DF53D2" w:rsidP="0075152E">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="00DF53D2">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Family_OrgAdd_City %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1041" type="#_x0000_t202" style="position:absolute;margin-left:234.8pt;margin-top:-435.75pt;width:60.35pt;height:18.85pt;z-index:251642880;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1041">
                                           <w:txbxContent>
                                               <w:p w:rsidR="0075152E" w:rsidRPr="00DF53D2" w:rsidRDefault="00DF53D2" w:rsidP="0075152E">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="00DF53D2">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Family_OrgAdd_Town %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1043" type="#_x0000_t202" style="position:absolute;margin-left:168.5pt;margin-top:-435.75pt;width:60.35pt;height:20.75pt;z-index:251644928;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1043">
                                           <w:txbxContent>
                                               <w:p w:rsidR="0075152E" w:rsidRPr="00DF53D2" w:rsidRDefault="00DF53D2" w:rsidP="0075152E">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="00DF53D2">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Family_OrgAdd_Street %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1123" type="#_x0000_t202" style="position:absolute;margin-left:80.65pt;margin-top:-435.75pt;width:81.2pt;height:16.8pt;z-index:251676672;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1123">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00A44C4C" w:rsidRPr="00DF53D2" w:rsidRDefault="00DF53D2" w:rsidP="00DF53D2">
                                                   <w:pPr>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="00DF53D2">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Family_OrgAdd_Phone %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1039" type="#_x0000_t202" style="position:absolute;margin-left:300.55pt;margin-top:-418.35pt;width:60.35pt;height:20.6pt;z-index:251640832;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1039">
                                           <w:txbxContent>
                                               <w:p w:rsidR="0075152E" w:rsidRPr="00DF53D2" w:rsidRDefault="00DF53D2" w:rsidP="005969DA">
                                                   <w:pPr>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="00DF53D2">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Family_CurAdd_City %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="مربع نص 2" o:spid="_x0000_s1132" type="#_x0000_t202" style="position:absolute;margin-left:-69.15pt;margin-top:134.55pt;width:108.15pt;height:133.9pt;flip:x;z-index:251682816;visibility:visible;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6GX1gQgIAAF4EAAAOAAAAZHJzL2Uyb0RvYy54bWysVM1uEzEQviPxDpbvZH+apM0qm6qkBJDK&#xa;j1R4AK/Xm7XwH7aT3fYOz8KVAwfeJH0bxt40jQpcEHuwbM/4m5nvm9n5eS8F2jLruFYlzkYpRkxR&#xa;XXO1LvHHD6tnZxg5T1RNhFasxDfM4fPF0yfzzhQs160WNbMIQJQrOlPi1ntTJImjLZPEjbRhCoyN&#xa;tpJ4ONp1UlvSAboUSZ6m06TTtjZWU+Yc3F4ORryI+E3DqH/XNI55JEoMufm42rhWYU0Wc1KsLTEt&#xa;p/s0yD9kIQlXEPQAdUk8QRvLf4OSnFrtdONHVMtENw2nLNYA1WTpo2quW2JYrAXIceZAk/t/sPTt&#xa;9r1FvC5xnp1ipIgEke6+7L7vvu1+oruvux8oDyR1xhXge23A2/fPdQ9ix4KdudL0k0NKL1ui1uzC&#xa;Wt21jNSQZBZeJkdPBxwXQKruja4hFtl4HYH6xkrUCG5e3UMDOwjigGw3B6lY7xGFy/xkms5OwETB&#xa;lo3T8TSPYiakCEBBCmOdf8m0RGFTYgu9EAOR7ZXzIbEHl+DutOD1igsRD3ZdLYVFWwJ9s4pfrOWR&#xa;m1CoK/Fskk8GLv4KkcbvTxCSexgAwWWJzw5OpAgMvlB1bE9PuBj2kLJQe0oDiwOfvq/6KOFkei9V&#xa;pesbINnqoeFhQGHTanuLUQfNXmL3eUMsw0i8ViDULBuPw3TEw3hyClwie2ypji1EUYAqscdo2C59&#xa;nKhInLkAQVc8EhyUHzLZ5wxNHHnfD1yYkuNz9Hr4LSx+AQAA//8DAFBLAwQUAAYACAAAACEAvWzd&#xa;D9sAAAAHAQAADwAAAGRycy9kb3ducmV2LnhtbEyPQU/DMAyF70j8h8hI3FjSIehUmk5oEhLiAhvj&#xa;njWmDTROlWRd9+8xJ7j5+Vnvfa7Xsx/EhDG5QBqKhQKB1AbrqNOwf3+6WYFI2ZA1QyDUcMYE6+by&#xa;ojaVDSfa4rTLneAQSpXR0Oc8VlKmtkdv0iKMSOx9huhNZhk7aaM5cbgf5FKpe+mNI27ozYibHtvv&#xa;3dFrcHb62JZfzhbptYzd2/OZ9i8bra+v5scHEBnn/HcMv/iMDg0zHcKRbBKDBn4ka1iumJ/d27Lg&#xa;4cCLO6VANrX8z9/8AAAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAAAAAAAAA&#xa;AAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9If/WAAAAlAEAAAsA&#xa;AAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoZfWBCAgAAXgQAAA4A&#xa;AAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAhAL1s3Q/bAAAABwEA&#xa;AA8AAAAAAAAAAAAAAAAAnAQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAEAPMAAACkBQAAAAA=&#xa;" stroked="f">
                                       <v:textbox style="mso-next-textbox:#مربع نص 2" inset="0,0,0,0">
                                           <w:txbxContent>
                                               <w:p w:rsidR="009B564D" w:rsidRDefault="009B564D">
                                                   <w:bookmarkStart w:id="1" w:name="picture"/>
                                                   <w:r w:rsidRPr="009B564D">
                                                       <w:rPr>
                                                           <w:noProof/>
                                                       </w:rPr>
                                                       <w:drawing>
                                                           <wp:inline distT="0" distB="0" distL="0" distR="0" wp14:anchorId="087901B9" wp14:editId="2543DD51">
                                                               <wp:extent cx="1390650" cy="1476375"/>
                                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                                               <wp:docPr id="4" name="صورة 4"/>
                                                               <wp:cNvGraphicFramePr>
                                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" noChangeAspect="1"/>
                                                               </wp:cNvGraphicFramePr>
                                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                                   <a:graphicData uri="http://schemas.openxmlformats.org/drawingml/2006/picture">
                                                                       <pic:pic xmlns:pic="http://schemas.openxmlformats.org/drawingml/2006/picture">
                                                                           <pic:nvPicPr>
                                                                               <pic:cNvPr id="0" name="Picture 1"/>
                                                                               <pic:cNvPicPr>
                                                                                   <a:picLocks noChangeAspect="1" noChangeArrowheads="1"/>
                                                                               </pic:cNvPicPr>
                                                                           </pic:nvPicPr>
                                                                           <pic:blipFill>
                                                                               <a:blip r:embed="rId7">
                                                                                   <a:extLst>
                                                                                       <a:ext uri="{28A0092B-C50C-407E-A947-70E740481C1C}">
                                                                                           <a14:useLocalDpi xmlns:a14="http://schemas.microsoft.com/office/drawing/2010/main" val="0"/>
                                                                                       </a:ext>
                                                                                   </a:extLst>
                                                                               </a:blip>
                                                                               <a:srcRect/>
                                                                               <a:stretch>
                                                                                   <a:fillRect/>
                                                                               </a:stretch>
                                                                           </pic:blipFill>
                                                                           <pic:spPr bwMode="auto">
                                                                               <a:xfrm>
                                                                                   <a:off x="0" y="0"/>
                                                                                   <a:ext cx="1390650" cy="1476375"/>
                                                                               </a:xfrm>
                                                                               <a:prstGeom prst="rect">
                                                                                   <a:avLst/>
                                                                               </a:prstGeom>
                                                                               <a:noFill/>
                                                                               <a:ln>
                                                                                   <a:noFill/>
                                                                               </a:ln>
                                                                           </pic:spPr>
                                                                       </pic:pic>
                                                                   </a:graphicData>
                                                               </a:graphic>
                                                           </wp:inline>
                                                       </w:drawing>
                                                   </w:r>
                                                   <w:bookmarkEnd w:id="1"/>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                       <w10:wrap type="square"/>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1128" type="#_x0000_t202" style="position:absolute;margin-left:38pt;margin-top:-206.2pt;width:17.4pt;height:22pt;z-index:251680768;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1128">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00EF5E0B" w:rsidRPr="001970EA" w:rsidRDefault="00DC25BD" w:rsidP="00EF5E0B">
                                                   <w:pPr>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidR="00EF5E0B" w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Family_RentalHouse %>/>
                                                   </w:r>
                                               </w:p>
                                               <w:p w:rsidR="00FF54C0" w:rsidRPr="001970EA" w:rsidRDefault="00FF54C0" w:rsidP="00FF54C0">
                                                   <w:pPr>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1096" type="#_x0000_t202" style="position:absolute;margin-left:314.8pt;margin-top:-244.45pt;width:17.4pt;height:22pt;z-index:251656192;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1096">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="001970EA" w:rsidRDefault="005969DA" w:rsidP="00FF54C0">
                                                   <w:pPr>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                       </w:rPr>
                                                       <w:sym w:font="Wingdings" w:char=<%= Mother_NotWorking %>/>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1027" type="#_x0000_t202" style="position:absolute;margin-left:181.95pt;margin-top:-559pt;width:94.2pt;height:23.35pt;z-index:251631616;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQC3dflqDQIAAPkDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vtjxkqwxohRduw4D&#xa;ugvQ7gNkWY6FSaImKbGzrx8lp2mwvQ3zgyCa5CHPIbW5Ho0mB+mDAsvofFZSIq2AVtkdo9+f7t9c&#xa;URIity3XYCWjRxno9fb1q83gallBD7qVniCIDfXgGO1jdHVRBNFLw8MMnLTo7MAbHtH0u6L1fEB0&#xa;o4uqLFfFAL51HoQMAf/eTU66zfhdJ0X82nVBRqIZxd5iPn0+m3QW2w2vd567XolTG/wfujBcWSx6&#xa;hrrjkZO9V39BGSU8BOjiTIApoOuUkJkDspmXf7B57LmTmQuKE9xZpvD/YMWXwzdPVMvokhLLDY7o&#xa;SY6RvIeRVEmdwYUagx4dhsURf+OUM9PgHkD8CMTCbc/tTt54D0MveYvdzVNmcZE64YQE0gyfocUy&#xa;fB8hA42dN0k6FIMgOk7peJ5MakWkkvP1qlwtKBHoq9art9Uil+D1c7bzIX6UYEi6MOpx8hmdHx5C&#xa;TN3w+jkkFbNwr7TO09eWDIyul9UyJ1x4jIq4nFoZRq/K9E3rkkh+sG1Ojlzp6Y4FtD2xTkQnynFs&#xa;xixvliQp0kB7RBk8TLuIbwcvPfhflAy4h4yGn3vuJSX6k0Up1/PFIi1uNhbLdxUa/tLTXHq4FQjF&#xa;aKRkut7GvOwT5RuUvFNZjZdOTi3jfmWRTm8hLfClnaNeXuz2NwAAAP//AwBQSwMEFAAGAAgAAAAh&#xa;AKAbGz3iAAAADwEAAA8AAABkcnMvZG93bnJldi54bWxMj01PwzAMhu9I/IfISNy2pO06WGk6IRBX&#xa;EOND4pY1XlvROFWTreXf453gaPvR6+ctt7PrxQnH0HnSkCwVCKTa244aDe9vT4tbECEasqb3hBp+&#xa;MMC2urwoTWH9RK942sVGcAiFwmhoYxwKKUPdojNh6Qckvh386EzkcWykHc3E4a6XqVJr6UxH/KE1&#xa;Az60WH/vjk7Dx/Ph63OlXppHlw+Tn5Ukt5FaX1/N93cgIs7xD4azPqtDxU57fyQbRK8hW2cbRjUs&#xa;kiRNuBYzeZ5mIPbnnbpZZSCrUv7vUf0CAAD//wMAUEsBAi0AFAAGAAgAAAAhALaDOJL+AAAA4QEA&#xa;ABMAAAAAAAAAAAAAAAAAAAAAAFtDb250ZW50X1R5cGVzXS54bWxQSwECLQAUAAYACAAAACEAOP0h&#xa;/9YAAACUAQAACwAAAAAAAAAAAAAAAAAvAQAAX3JlbHMvLnJlbHNQSwECLQAUAAYACAAAACEAt3X5&#xa;ag0CAAD5AwAADgAAAAAAAAAAAAAAAAAuAgAAZHJzL2Uyb0RvYy54bWxQSwECLQAUAAYACAAAACEA&#xa;oBsbPeIAAAAPAQAADwAAAAAAAAAAAAAAAABnBAAAZHJzL2Rvd25yZXYueG1sUEsFBgAAAAAEAAQA&#xa;8wAAAHYFAAAAAA==&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1027">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00FD4F12" w:rsidRPr="001970EA" w:rsidRDefault="001970EA" w:rsidP="00FD4F12">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Orphan_GranFatherName %></w:t>
                                                   </w:r>
                                               </w:p>
                                               <w:p w:rsidR="004F1751" w:rsidRPr="001970EA" w:rsidRDefault="004F1751" w:rsidP="00834F30">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                   </w:pPr>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1104" type="#_x0000_t202" style="position:absolute;margin-left:353.45pt;margin-top:-30.25pt;width:20.75pt;height:17.15pt;z-index:251662336;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1104">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="007C3E5D" w:rsidRDefault="007C3E5D" w:rsidP="007C3E5D">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="16"/>
                                                           <w:szCs w:val="16"/>
                                                           <w:rtl/>
                                                       </w:rPr>
                                                   </w:pPr>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1103" type="#_x0000_t202" style="position:absolute;margin-left:-18.9pt;margin-top:-162.7pt;width:19.65pt;height:21.25pt;z-index:251661312;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1103">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="00FF54C0" w:rsidRDefault="007C3E5D" w:rsidP="00FF54C0">
                                                   <w:pPr>
                                                       <w:rPr>
                                                           <w:sz w:val="16"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1088" type="#_x0000_t202" style="position:absolute;margin-left:27.7pt;margin-top:-325pt;width:18.8pt;height:21.1pt;z-index:251648000;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1088">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="007C3E5D" w:rsidRDefault="007C3E5D" w:rsidP="007C3E5D">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="16"/>
                                                           <w:szCs w:val="16"/>
                                                           <w:rtl/>
                                                       </w:rPr>
                                                   </w:pPr>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1090" type="#_x0000_t202" style="position:absolute;margin-left:317.3pt;margin-top:-325pt;width:18.15pt;height:21.1pt;z-index:251650048;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1090">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="001970EA" w:rsidRDefault="00DF53D2" w:rsidP="007C3E5D">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="20"/>
                                                           <w:szCs w:val="20"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Orphan_Brother_Female_Number %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1117" type="#_x0000_t202" style="position:absolute;margin-left:228.15pt;margin-top:-204.8pt;width:115.75pt;height:22.1pt;z-index:251673600;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1117">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00F65CBC" w:rsidRPr="001970EA" w:rsidRDefault="00DF53D2" w:rsidP="00F65CBC">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Orphan_BondsManRelation %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1116" type="#_x0000_t202" style="position:absolute;margin-left:366.15pt;margin-top:-204.8pt;width:115.75pt;height:22.1pt;z-index:251672576;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1116">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00F65CBC" w:rsidRPr="001970EA" w:rsidRDefault="00DF53D2" w:rsidP="00BC5BCC">
                                                   <w:pPr>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.BondsMan_FullName %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1106" type="#_x0000_t202" style="position:absolute;margin-left:282.6pt;margin-top:32.1pt;width:100.45pt;height:17.55pt;z-index:251664384;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1106">
                                           <w:txbxContent>
                                               <w:p w:rsidR="00F65CBC" w:rsidRPr="001970EA" w:rsidRDefault="00EF5E0B" w:rsidP="00EF5E0B">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Supporter_FullName %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1091" type="#_x0000_t202" style="position:absolute;margin-left:366.15pt;margin-top:-287.7pt;width:115.75pt;height:17.3pt;z-index:251651072;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1091">
                                           <w:txbxContent>
                                               <w:p w:rsidR="007C3E5D" w:rsidRPr="001970EA" w:rsidRDefault="00DF53D2" w:rsidP="007C3E5D">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Father_DieDate.ToString("dd/MM/yyyy") %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1033" type="#_x0000_t202" style="position:absolute;margin-left:80.6pt;margin-top:-500.75pt;width:94.2pt;height:23.35pt;z-index:251635712;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1033">
                                           <w:txbxContent>
                                               <w:p w:rsidR="0075152E" w:rsidRPr="001970EA" w:rsidRDefault="007C3E5D" w:rsidP="00834F30">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                       </w:rPr>
                                                       <w:t>سوري</w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1032" type="#_x0000_t202" style="position:absolute;margin-left:181.95pt;margin-top:-500.75pt;width:94.2pt;height:23.35pt;z-index:251634688;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1032">
                                           <w:txbxContent>
                                               <w:p w:rsidR="0075152E" w:rsidRPr="001970EA" w:rsidRDefault="001970EA" w:rsidP="00834F30">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Orphan_Birthday.ToString("dd/MM/yyyy") %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1031" type="#_x0000_t202" style="position:absolute;margin-left:387.7pt;margin-top:-500.75pt;width:94.2pt;height:23.35pt;z-index:251633664;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1031">
                                           <w:txbxContent>
                                               <w:p w:rsidR="0075152E" w:rsidRPr="001970EA" w:rsidRDefault="001970EA" w:rsidP="00834F30">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Orphan_MotherFullName %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="Text Box 2" o:spid="_x0000_s1026" type="#_x0000_t202" style="position:absolute;margin-left:80.6pt;margin-top:-559.7pt;width:94.2pt;height:23.35pt;z-index:251632640;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQCiUCKECgIAAPIDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vtjxkqwxohRduw4D&#xa;ugvQ7gNkWY6FSaImKbGzrx8lp2mwvQ3zgyCa5CHPIbW5Ho0mB+mDAsvofFZSIq2AVtkdo9+f7t9c&#xa;URIity3XYCWjRxno9fb1q83gallBD7qVniCIDfXgGO1jdHVRBNFLw8MMnLTo7MAbHtH0u6L1fEB0&#xa;o4uqLFfFAL51HoQMAf/eTU66zfhdJ0X82nVBRqIZxd5iPn0+m3QW2w2vd567XolTG/wfujBcWSx6&#xa;hrrjkZO9V39BGSU8BOjiTIApoOuUkJkDspmXf7B57LmTmQuKE9xZpvD/YMWXwzdPVMvoihLLDY7o&#xa;SY6RvIeRVEmdwYUagx4dhsURf+OUM9PgHkD8CMTCbc/tTt54D0MveYvdzVNmcZE64YQE0gyfocUy&#xa;fB8hA42dN0k6FIMgOk7peJ5MakWkkvP1qlwtKBHoq9art9Uil+D1c7bzIX6UYEi6MOpx8hmdHx5C&#xa;TN3w+jkkFbNwr7TO09eWDIyul9UyJ1x4jIq4nFoZRq/K9E3rkkh+sG1Ojlzp6Y4FtD2xTkQnynFs&#xa;RgxMUjTQHpG/h2kJ8dHgpQf/i5IBF5DR8HPPvaREf7Ko4Xq+WKSNzcZi+a5Cw196mksPtwKhGI2U&#xa;TNfbmLd84nqDWncqy/DSyalXXKyszukRpM29tHPUy1Pd/gYAAP//AwBQSwMEFAAGAAgAAAAhAMWV&#xa;D9nhAAAADwEAAA8AAABkcnMvZG93bnJldi54bWxMj8FOwzAMhu9IvENkJG5bklK6tTSdEIgraAMm&#xa;ccuarK1onKrJ1vL2eCc4/van35/Lzex6drZj6DwqkEsBzGLtTYeNgo/3l8UaWIgaje49WgU/NsCm&#xa;ur4qdWH8hFt73sWGUQmGQitoYxwKzkPdWqfD0g8WaXf0o9OR4thwM+qJyl3PEyEy7nSHdKHVg31q&#xa;bf29OzkFn6/Hr30q3ppndz9MfhYcXc6Vur2ZHx+ARTvHPxgu+qQOFTkd/AlNYD3lTCaEKlhIKfMU&#xa;GDF3aZ4BO1xmYpWsgFcl//9H9QsAAP//AwBQSwECLQAUAAYACAAAACEAtoM4kv4AAADhAQAAEwAA&#xa;AAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRfVHlwZXNdLnhtbFBLAQItABQABgAIAAAAIQA4/SH/1gAA&#xa;AJQBAAALAAAAAAAAAAAAAAAAAC8BAABfcmVscy8ucmVsc1BLAQItABQABgAIAAAAIQCiUCKECgIA&#xa;APIDAAAOAAAAAAAAAAAAAAAAAC4CAABkcnMvZTJvRG9jLnhtbFBLAQItABQABgAIAAAAIQDFlQ/Z&#xa;4QAAAA8BAAAPAAAAAAAAAAAAAAAAAGQEAABkcnMvZG93bnJldi54bWxQSwUGAAAAAAQABADzAAAA&#xa;cgUAAAAA&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#Text Box 2">
                                           <w:txbxContent>
                                               <w:p w:rsidR="004F1751" w:rsidRPr="001970EA" w:rsidRDefault="001970EA" w:rsidP="007C3E5D">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Orphan_LastName %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1028" type="#_x0000_t202" style="position:absolute;margin-left:284.5pt;margin-top:-560.6pt;width:94.2pt;height:23.35pt;z-index:251630592;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQDGS+XPDQIAAPkDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk6wxohRduw4D&#xa;ugvQ7gNkWY6FSaImKbGzrx8lp1mwvQ3zgyCa5CHPIbW5GY0mB+mDAsvofFZSIq2AVtkdo9+eH95c&#xa;UxIity3XYCWjRxnozfb1q83gallBD7qVniCIDfXgGO1jdHVRBNFLw8MMnLTo7MAbHtH0u6L1fEB0&#xa;o4uqLFfFAL51HoQMAf/eT066zfhdJ0X80nVBRqIZxd5iPn0+m3QW2w2vd567XolTG/wfujBcWSx6&#xa;hrrnkZO9V39BGSU8BOjiTIApoOuUkJkDspmXf7B56rmTmQuKE9xZpvD/YMXnw1dPVMvoFSWWGxzR&#xa;sxwjeQcjqZI6gws1Bj05DIsj/sYpZ6bBPYL4HoiFu57bnbz1HoZe8ha7m6fM4iJ1wgkJpBk+QYtl&#xa;+D5CBho7b5J0KAZBdJzS8TyZ1IpIJefrVblaUCLQV61XV9Uil+D1S7bzIX6QYEi6MOpx8hmdHx5D&#xa;TN3w+iUkFbPwoLTO09eWDIyul9UyJ1x4jIq4nFoZRq/L9E3rkki+t21Ojlzp6Y4FtD2xTkQnynFs&#xa;xizvWcwG2iPK4GHaRXw7eOnB/6RkwD1kNPzYcy8p0R8tSrmeLxZpcbOxWL6t0PCXnubSw61AKEYj&#xa;JdP1LuZlnyjfouSdymqk2UydnFrG/coind5CWuBLO0f9frHbXwAAAP//AwBQSwMEFAAGAAgAAAAh&#xa;ACjCGdvjAAAADwEAAA8AAABkcnMvZG93bnJldi54bWxMj8FuwjAQRO+V+AdrkXoDO1FCShoHIape&#xa;W5W2SNxMvCRR43UUG5L+fc2pHGdnNPum2EymY1ccXGtJQrQUwJAqq1uqJXx9vi6egDmvSKvOEkr4&#xa;RQebcvZQqFzbkT7wuvc1CyXkciWh8b7POXdVg0a5pe2Rgne2g1E+yKHmelBjKDcdj4VYcaNaCh8a&#xa;1eOuwepnfzESvt/Ox0Mi3usXk/ajnQQns+ZSPs6n7TMwj5P/D8MNP6BDGZhO9kLasU5CulqHLV7C&#xa;IoriKAYWMlmaJcBOt5vIkhR4WfD7HeUfAAAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhAMZL&#xa;5c8NAgAA+QMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;ACjCGdvjAAAADwEAAA8AAAAAAAAAAAAAAAAAZwQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1028">
                                           <w:txbxContent>
                                               <w:p w:rsidR="004F1751" w:rsidRPr="001970EA" w:rsidRDefault="001970EA" w:rsidP="001970EA">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Orphan_FatherName %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                               </w:rPr>
                               <w:pict>
                                   <v:shape id="_x0000_s1029" type="#_x0000_t202" style="position:absolute;margin-left:387.7pt;margin-top:-562.1pt;width:94.2pt;height:23.35pt;z-index:251629568;visibility:visible;mso-position-horizontal-relative:text;mso-position-vertical-relative:text;mso-width-relative:margin;mso-height-relative:margin" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA6EKdzDwIAAPsDAAAOAAAAZHJzL2Uyb0RvYy54bWysU9tu2zAMfR+wfxD0vthxk7QxohRduw4D&#xa;ugvQ7gMUWY6FSaImKbGzry8lJ1mwvQ3zgyCa5CHPIbW6HYwme+mDAsvodFJSIq2ARtkto99fHt/d&#xa;UBIitw3XYCWjBxno7frtm1XvallBB7qRniCIDXXvGO1idHVRBNFJw8MEnLTobMEbHtH026LxvEd0&#xa;o4uqLBdFD75xHoQMAf8+jE66zvhtK0X82rZBRqIZxd5iPn0+N+ks1itebz13nRLHNvg/dGG4slj0&#xa;DPXAIyc7r/6CMkp4CNDGiQBTQNsqITMHZDMt/2Dz3HEnMxcUJ7izTOH/wYov+2+eqIbRq/KaEssN&#xa;DulFDpG8h4FUSZ/ehRrDnh0GxgF/45wz1+CeQPwIxMJ9x+1W3nkPfSd5g/1NU2ZxkTrihASy6T9D&#xa;g2X4LkIGGlpvkngoB0F0nNPhPJvUikglp8tFuZhRItBXLRdX1SyX4PUp2/kQP0owJF0Y9Tj7jM73&#xa;TyGmbnh9CknFLDwqrfP8tSU9o8t5Nc8JFx6jIq6nVobRmzJ948Ikkh9sk5MjV3q8YwFtj6wT0ZFy&#xa;HDbDKPBJzA00B5TBw7iN+Hrw0oH/RUmPm8ho+LnjXlKiP1mUcjmdzdLqZmM2v67Q8JeezaWHW4FQ&#xa;jEZKxut9zOs+Ur5DyVuV1UizGTs5towblkU6voa0wpd2jvr9ZtevAAAA//8DAFBLAwQUAAYACAAA&#xa;ACEAyDS7euEAAAAPAQAADwAAAGRycy9kb3ducmV2LnhtbEyPzU7DMBCE70i8g7VI3Fo7IW1piFMh&#xa;EFcQ5Ufi5sbbJCJeR7HbhLfv9lSOO/NpdqbYTK4TRxxC60lDMlcgkCpvW6o1fH68zO5BhGjIms4T&#xa;avjDAJvy+qowufUjveNxG2vBIRRyo6GJsc+lDFWDzoS575HY2/vBmcjnUEs7mJHDXSdTpZbSmZb4&#xa;Q2N6fGqw+t0enIav1/3Pd6be6me36Ec/KUluLbW+vZkeH0BEnOIFhnN9rg4ld9r5A9kgOg2r1SJj&#xa;VMMsSdIsBcHMennHc3ZnTbEPsizk/x3lCQAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEB&#xa;AAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9&#xa;If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhADoQ&#xa;p3MPAgAA+wMAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAh&#xa;AMg0u3rhAAAADwEAAA8AAAAAAAAAAAAAAAAAaQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAE&#xa;APMAAAB3BQAAAAA=&#xa;" filled="f" stroked="f">
                                       <v:textbox style="mso-next-textbox:#_x0000_s1029">
                                           <w:txbxContent>
                                               <w:p w:rsidR="004F1751" w:rsidRPr="001970EA" w:rsidRDefault="001970EA" w:rsidP="00834F30">
                                                   <w:pPr>
                                                       <w:bidi/>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="001970EA">
                                                       <w:rPr>
                                                           <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi" w:hint="cs"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Orphan_FirstName %></w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:txbxContent>
                                       </v:textbox>
                                   </v:shape>
                               </w:pict>
                           </w:r>
                           <w:bookmarkEnd w:id="0"/>
                       </w:p>
                       <w:sectPr w:rsidR="00FB585F" w:rsidSect="000F1F28">
                           <w:pgSz w:w="11907" w:h="16839" w:code="9"/>
                           <w:pgMar w:top="1440" w:right="1800" w:bottom="1440" w:left="1800" w:header="720" w:footer="720" w:gutter="0"/>
                           <w:cols w:space="720"/>
                           <w:docGrid w:linePitch="360"/>
                       </w:sectPr>
                   </w:body>
               </w:document>
    End Sub

    Public Sub New(ByVal Data As _3Taa2Data)
        Me._Data = Data
        LoadDocument(Me._Document, Me._Data)
    End Sub
    Public Sub New()
        Me._Data = Nothing
        Me._Document = Nothing
    End Sub

    Public Function CreateWordFile(ByVal FilePath As String, Optional ByVal Overwrite As Boolean = True) As Boolean
        If File.Exists(FilePath) Then
            If Not Overwrite Then
                Throw New Exception("الملف موجود!")
            Else
                File.Delete(FilePath)
            End If
        End If
        If IsNothing(Me._Data) Then
            Throw New Exception("قم بإدخال البيانات")
        End If
        Dim TempPath As String = My.Computer.FileSystem.GetTempFileName()
        Try
            File.WriteAllBytes(TempPath, My.Resources._3Taa)
            Using TempDoc As WordprocessingDocument = WordprocessingDocument.Open(TempPath, True)
                Dim MainP = TempDoc.MainDocumentPart
                Using sw As New StreamWriter(MainP.GetStream(FileMode.Create))
                    _Document.Save(sw)
                End Using
                If Not IsNothing(_Data.Orphan_Img) Then
                    Try
                        Dim img = MainP.GetPartById("rId7")
                        Using ss As New MemoryStream(_Data.Orphan_Img)
                            img.FeedData(ss)
                        End Using
                    Catch
                    End Try
                End If
            End Using
            File.Copy(TempPath, FilePath, True)
            File.Delete(TempPath)
            Return True
        Catch ex As Exception
            File.Delete(TempPath)
            Throw ex
        End Try
        Return False
    End Function
    Public Sub AddPage(ByVal PageNum As Integer, ByVal PageData As _3Taa2Data)
        If IsNothing(_Pages) Then
            _Pages = New Dictionary(Of Integer, _3Taa2Data)
        End If
        If Not _Pages.ContainsKey(PageNum) Then
            _Pages.Add(PageNum, PageData)
        End If
    End Sub
    Public Function CreateMultiPagesFile(ByVal FilePath As String, Optional ByVal Overwrite As Boolean = True) As Boolean
        If File.Exists(FilePath) Then
            If Not Overwrite Then
                Throw New Exception("الملف موجود!")
            Else
                File.Delete(FilePath)
            End If
        End If
        If IsNothing(Me._Pages) Then
            Throw New Exception("قم بإدخال البيانات")
        End If
        Dim TempPath As String = My.Computer.FileSystem.GetTempFileName()
        Dim i As Integer = 0
        Try
            File.WriteAllBytes(TempPath, My.Resources._3Taa)
            Using TempDoc As WordprocessingDocument = WordprocessingDocument.Open(TempPath, True)
                Dim MainP = TempDoc.MainDocumentPart
                Dim MainXml As XElement
                Using Sr As New StreamReader(MainP.GetStream())
                    MainXml = XElement.Load(Sr)
                End Using
                Dim MainBody As XElement = MainXml...<w:body>.First()
                For Each key As Integer In _Pages.Keys
                    Dim NextDoc As XDocument = Nothing
                    Dim NextData As _3Taa2Data = _Pages(key)
                    LoadDocument(NextDoc, _Pages(key))
                    Dim NextBody = NextDoc...<w:body>.First()
                    If i = 0 Then
                        MainBody.ReplaceNodes(NextBody.Elements)
                        If Not IsNothing(NextData.Orphan_Img) Then
                            Try
                                Dim img = MainP.GetPartById("rId7")
                                Using ss As New MemoryStream(NextData.Orphan_Img)
                                    img.FeedData(ss)
                                End Using
                            Catch
                            End Try
                        End If
                    Else
                        'Dim PageBreak As New Break()
                        'PageBreak.Type = BreakValues.Page
                        'Dim PAgeBreakParagraph As New Paragraph(New Run(PageBreak))                        
                        Dim PageEl = <w:p>
                                         <w:r>
                                             <w:br w:type="page"/>
                                         </w:r>
                                     </w:p>
                        NextBody.Add(PageEl)
                        If Not IsNothing(NextData.Orphan_Img) Then
                            Try
                                Dim SavedImage = MainP.GetPartById("rId7")
                                Dim ImgP As ImagePart = MainP.AddImagePart(ImagePartType.Jpeg)
                                Using ss As New MemoryStream(NextData.Orphan_Img)
                                    ImgP.FeedData(ss)
                                End Using
                                Dim images = NextBody...<a:blip>
                                For Each img In images
                                    If img.@<r:embed> = "rId7" Then
                                        img.@<r:embed> = MainP.GetIdOfPart(ImgP)
                                    End If
                                Next
                            Catch
                            End Try
                        End If
                        MainBody.Add(NextBody.Elements)
                    End If
                    i += 1
                Next
                Using Sr As New StreamWriter(MainP.GetStream(FileMode.Create, FileAccess.ReadWrite))
                    MainXml.Save(Sr)
                End Using
                MainP.Document.Save()
            End Using
            File.Copy(TempPath, FilePath, True)
            File.Delete(TempPath)
            Return True
        Catch ex As Exception
            File.Delete(TempPath)
            Throw ex
        End Try
        Return False

    End Function

End Class
