Imports System.IO
Imports DocumentFormat.OpenXml.Packaging
Imports <xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
Imports <xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
Imports <xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships">

Public Class FinancailCard

    Public ReadOnly Property Document As XDocument
        Get
            Return _Document
        End Get
    End Property
    Private _Document As XDocument = Nothing
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
    Private _Pages As Dictionary(Of Integer, FinancialData) = Nothing
    Public ReadOnly Property Pages As Dictionary(Of Integer, FinancialData)
        Get
            Return _Pages
        End Get
    End Property

    Public Structure FinancialData
        Public FatherName As String
        Public MotherName As String
        Public OrphansCount As String
        Public OrphansNames As String
        Public BillDate As String
        Public Address As String
        Public Salary As String
        Public Sub New(ByVal FName As String, ByVal MName As String, ByVal Ocount As String, ByVal ONames As String, ByVal BillDate As String, _
                       ByVal Address As String, ByVal Salary As String)
            Me.MotherName = MName
            Me.Address = Address
            Me.BillDate = BillDate
            Me.FatherName = FName
            Me.OrphansCount = Ocount
            Me.OrphansNames = ONames
            Me.Salary = Salary
        End Sub
    End Structure

    Private _Data As FinancialData = Nothing
    Public Property DataStructure As FinancialData
        Get
            Return _Data
        End Get
        Set(ByVal value As FinancialData)
            _Data = value
        End Set
    End Property

    Private Sub LoadDocument(ByRef _doc As XDocument, ByVal Data As FinancialData)

        _doc = <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
               <w:document xmlns:wpc="http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas" xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:m="http://schemas.openxmlformats.org/officeDocument/2006/math" xmlns:v="urn:schemas-microsoft-com:vml" xmlns:wp14="http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing" xmlns:wp="http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing" xmlns:w10="urn:schemas-microsoft-com:office:word" xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main" xmlns:w14="http://schemas.microsoft.com/office/word/2010/wordml" xmlns:w15="http://schemas.microsoft.com/office/word/2012/wordml" xmlns:wpg="http://schemas.microsoft.com/office/word/2010/wordprocessingGroup" xmlns:wpi="http://schemas.microsoft.com/office/word/2010/wordprocessingInk" xmlns:wne="http://schemas.microsoft.com/office/word/2006/wordml" xmlns:wps="http://schemas.microsoft.com/office/word/2010/wordprocessingShape" mc:Ignorable="w14 w15 wp14">
                   <w:body>
                       <w:tbl>
                           <w:tblPr>
                               <w:tblStyle w:val="a4"/>
                               <w:bidiVisual/>
                               <w:tblW w:w="0" w:type="auto"/>
                               <w:jc w:val="center"/>
                               <w:tblLook w:val="04A0" w:firstRow="1" w:lastRow="0" w:firstColumn="1" w:lastColumn="0" w:noHBand="0" w:noVBand="1"/>
                           </w:tblPr>
                           <w:tblGrid>
                               <w:gridCol w:w="3260"/>
                               <w:gridCol w:w="4678"/>
                           </w:tblGrid>
                           <w:tr w:rsidR="002F3D6B" w:rsidTr="000E06D3">
                               <w:trPr>
                                   <w:trHeight w:val="6667"/>
                                   <w:jc w:val="center"/>
                               </w:trPr>
                               <w:tc>
                                   <w:tcPr>
                                       <w:tcW w:w="3260" w:type="dxa"/>
                                       <w:tcBorders>
                                           <w:top w:val="nil"/>
                                           <w:left w:val="nil"/>
                                           <w:bottom w:val="nil"/>
                                           <w:right w:val="single" w:sz="48" w:space="0" w:color="auto"/>
                                       </w:tcBorders>
                                       <w:vAlign w:val="center"/>
                                   </w:tcPr>
                                   <w:p w:rsidR="002F3D6B" w:rsidRDefault="002F3D6B" w:rsidP="00550B38">
                                       <w:pPr>
                                           <w:ind w:right="426"/>
                                           <w:jc w:val="center"/>
                                           <w:rPr>
                                               <w:rtl/>
                                               <w:lang w:bidi="ar-SY"/>
                                           </w:rPr>
                                       </w:pPr>
                                       <w:bookmarkStart w:id="0" w:name="_GoBack"/>
                                       <w:bookmarkEnd w:id="0"/>
                                       <w:r>
                                           <w:rPr>
                                               <w:rFonts w:hint="cs"/>
                                               <w:noProof/>
                                           </w:rPr>
                                           <w:drawing>
                                               <wp:inline distT="0" distB="0" distL="0" distR="0" wp14:anchorId="5E8D28E8" wp14:editId="68672AFD">
                                                   <wp:extent cx="3514090" cy="1419152"/>
                                                   <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                                   <wp:docPr id="1" name="صورة 1"/>
                                                   <wp:cNvGraphicFramePr>
                                                       <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" noChangeAspect="1"/>
                                                   </wp:cNvGraphicFramePr>
                                                   <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                       <a:graphicData uri="http://schemas.openxmlformats.org/drawingml/2006/picture">
                                                           <pic:pic xmlns:pic="http://schemas.openxmlformats.org/drawingml/2006/picture">
                                                               <pic:nvPicPr>
                                                                   <pic:cNvPr id="1" name="orphan logo-01.png"/>
                                                                   <pic:cNvPicPr/>
                                                               </pic:nvPicPr>
                                                               <pic:blipFill rotWithShape="1">
                                                                   <a:blip r:embed="rId4" cstate="print">
                                                                       <a:extLst>
                                                                           <a:ext uri="{28A0092B-C50C-407E-A947-70E740481C1C}">
                                                                               <a14:useLocalDpi xmlns:a14="http://schemas.microsoft.com/office/drawing/2010/main" val="0"/>
                                                                           </a:ext>
                                                                       </a:extLst>
                                                                   </a:blip>
                                                                   <a:srcRect l="6979" t="25135" r="9558" b="25405"/>
                                                                   <a:stretch/>
                                                               </pic:blipFill>
                                                               <pic:spPr bwMode="auto">
                                                                   <a:xfrm rot="16200000">
                                                                       <a:off x="0" y="0"/>
                                                                       <a:ext cx="3575890" cy="1444110"/>
                                                                   </a:xfrm>
                                                                   <a:prstGeom prst="rect">
                                                                       <a:avLst/>
                                                                   </a:prstGeom>
                                                                   <a:ln>
                                                                       <a:noFill/>
                                                                   </a:ln>
                                                                   <a:extLst>
                                                                       <a:ext uri="{53640926-AAD7-44D8-BBD7-CCE9431645EC}">
                                                                           <a14:shadowObscured xmlns:a14="http://schemas.microsoft.com/office/drawing/2010/main"/>
                                                                       </a:ext>
                                                                   </a:extLst>
                                                               </pic:spPr>
                                                           </pic:pic>
                                                       </a:graphicData>
                                                   </a:graphic>
                                               </wp:inline>
                                           </w:drawing>
                                       </w:r>
                                   </w:p>
                                   <w:p w:rsidR="002F3D6B" w:rsidRPr="00636BE8" w:rsidRDefault="002F3D6B" w:rsidP="00550B38">
                                       <w:pPr>
                                           <w:ind w:right="426"/>
                                           <w:jc w:val="center"/>
                                           <w:rPr>
                                               <w:rFonts w:ascii="Microsoft Uighur" w:hAnsi="Microsoft Uighur" w:cs="Microsoft Uighur"/>
                                               <w:b/>
                                               <w:bCs/>
                                               <w:rtl/>
                                               <w:lang w:bidi="ar-SY"/>
                                           </w:rPr>
                                       </w:pPr>
                                       <w:r w:rsidRPr="00636BE8">
                                           <w:rPr>
                                               <w:rFonts w:ascii="Microsoft Uighur" w:hAnsi="Microsoft Uighur" w:cs="Microsoft Uighur"/>
                                               <w:b/>
                                               <w:bCs/>
                                               <w:sz w:val="36"/>
                                               <w:szCs w:val="36"/>
                                               <w:rtl/>
                                               <w:lang w:bidi="ar-SY"/>
                                               <w14:glow w14:rad="63500">
                                                   <w14:schemeClr w14:val="accent4">
                                                       <w14:alpha w14:val="60000"/>
                                                       <w14:satMod w14:val="175000"/>
                                                   </w14:schemeClr>
                                               </w14:glow>
                                               <w14:shadow w14:blurRad="60007" w14:dist="310007" w14:dir="7680000" w14:sx="100000" w14:sy="30000" w14:kx="1300200" w14:ky="0" w14:algn="ctr">
                                                   <w14:srgbClr w14:val="000000">
                                                       <w14:alpha w14:val="68000"/>
                                                   </w14:srgbClr>
                                               </w14:shadow>
                                           </w:rPr>
                                           <w:t>لا تنسونا من صالح دعائكم</w:t>
                                       </w:r>
                                   </w:p>
                               </w:tc>
                               <w:tc>
                                   <w:tcPr>
                                       <w:tcW w:w="4678" w:type="dxa"/>
                                       <w:tcBorders>
                                           <w:top w:val="nil"/>
                                           <w:left w:val="single" w:sz="48" w:space="0" w:color="auto"/>
                                           <w:bottom w:val="nil"/>
                                           <w:right w:val="nil"/>
                                       </w:tcBorders>
                                   </w:tcPr>
                                   <w:p w:rsidR="00636BE8" w:rsidRDefault="00636BE8">
                                       <w:pPr>
                                           <w:rPr>
                                               <w:rtl/>
                                           </w:rPr>
                                       </w:pPr>
                                   </w:p>
                                   <w:p w:rsidR="00636BE8" w:rsidRPr="00636BE8" w:rsidRDefault="00636BE8">
                                       <w:pPr>
                                           <w:rPr>
                                               <w:sz w:val="12"/>
                                               <w:szCs w:val="12"/>
                                           </w:rPr>
                                       </w:pPr>
                                   </w:p>
                                   <w:tbl>
                                       <w:tblPr>
                                           <w:tblStyle w:val="a4"/>
                                           <w:bidiVisual/>
                                           <w:tblW w:w="4253" w:type="dxa"/>
                                           <w:jc w:val="center"/>
                                           <w:tblLook w:val="04A0" w:firstRow="1" w:lastRow="0" w:firstColumn="1" w:lastColumn="0" w:noHBand="0" w:noVBand="1"/>
                                       </w:tblPr>
                                       <w:tblGrid>
                                           <w:gridCol w:w="1418"/>
                                           <w:gridCol w:w="2835"/>
                                       </w:tblGrid>
                                       <w:tr w:rsidR="002F3D6B" w:rsidTr="00636BE8">
                                           <w:trPr>
                                               <w:trHeight w:val="845"/>
                                               <w:jc w:val="center"/>
                                           </w:trPr>
                                           <w:tc>
                                               <w:tcPr>
                                                   <w:tcW w:w="4253" w:type="dxa"/>
                                                   <w:gridSpan w:val="2"/>
                                                   <w:tcBorders>
                                                       <w:top w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                       <w:left w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                       <w:right w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                   </w:tcBorders>
                                               </w:tcPr>
                                               <w:p w:rsidR="002F3D6B" w:rsidRPr="00EB6C3E" w:rsidRDefault="000879AF" w:rsidP="000879AF">
                                                   <w:pPr>
                                                       <w:jc w:val="center"/>
                                                       <w:rPr>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="40"/>
                                                           <w:szCs w:val="40"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:reflection w14:blurRad="6350" w14:stA="60000" w14:stPos="0" w14:endA="900" w14:endPos="58000" w14:dist="0" w14:dir="5400000" w14:fadeDir="5400000" w14:sx="100000" w14:sy="-100000" w14:kx="0" w14:ky="0" w14:algn="bl"/>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                           <w14:textFill>
                                                               <w14:gradFill>
                                                                   <w14:gsLst>
                                                                       <w14:gs w14:pos="0">
                                                                           <w14:schemeClr w14:val="accent5">
                                                                               <w14:lumMod w14:val="50000"/>
                                                                           </w14:schemeClr>
                                                                       </w14:gs>
                                                                       <w14:gs w14:pos="50000">
                                                                           <w14:schemeClr w14:val="accent5"/>
                                                                       </w14:gs>
                                                                       <w14:gs w14:pos="100000">
                                                                           <w14:schemeClr w14:val="accent5">
                                                                               <w14:lumMod w14:val="60000"/>
                                                                               <w14:lumOff w14:val="40000"/>
                                                                           </w14:schemeClr>
                                                                       </w14:gs>
                                                                   </w14:gsLst>
                                                                   <w14:lin w14:ang="5400000" w14:scaled="0"/>
                                                               </w14:gradFill>
                                                           </w14:textFill>
                                                       </w:rPr>
                                                       <w:t>مكتب كفال</w:t>
                                                   </w:r>
                                                   <w:r w:rsidR="002F3D6B" w:rsidRPr="00550B38">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="40"/>
                                                           <w:szCs w:val="40"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:reflection w14:blurRad="6350" w14:stA="60000" w14:stPos="0" w14:endA="900" w14:endPos="58000" w14:dist="0" w14:dir="5400000" w14:fadeDir="5400000" w14:sx="100000" w14:sy="-100000" w14:kx="0" w14:ky="0" w14:algn="bl"/>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                           <w14:textFill>
                                                               <w14:gradFill>
                                                                   <w14:gsLst>
                                                                       <w14:gs w14:pos="0">
                                                                           <w14:schemeClr w14:val="accent5">
                                                                               <w14:lumMod w14:val="50000"/>
                                                                           </w14:schemeClr>
                                                                       </w14:gs>
                                                                       <w14:gs w14:pos="50000">
                                                                           <w14:schemeClr w14:val="accent5"/>
                                                                       </w14:gs>
                                                                       <w14:gs w14:pos="100000">
                                                                           <w14:schemeClr w14:val="accent5">
                                                                               <w14:lumMod w14:val="60000"/>
                                                                               <w14:lumOff w14:val="40000"/>
                                                                           </w14:schemeClr>
                                                                       </w14:gs>
                                                                   </w14:gsLst>
                                                                   <w14:lin w14:ang="5400000" w14:scaled="0"/>
                                                               </w14:gradFill>
                                                           </w14:textFill>
                                                       </w:rPr>
                                                       <w:t>ة الأيت</w:t>
                                                   </w:r>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="40"/>
                                                           <w:szCs w:val="40"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:reflection w14:blurRad="6350" w14:stA="60000" w14:stPos="0" w14:endA="900" w14:endPos="58000" w14:dist="0" w14:dir="5400000" w14:fadeDir="5400000" w14:sx="100000" w14:sy="-100000" w14:kx="0" w14:ky="0" w14:algn="bl"/>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                           <w14:textFill>
                                                               <w14:gradFill>
                                                                   <w14:gsLst>
                                                                       <w14:gs w14:pos="0">
                                                                           <w14:schemeClr w14:val="accent5">
                                                                               <w14:lumMod w14:val="50000"/>
                                                                           </w14:schemeClr>
                                                                       </w14:gs>
                                                                       <w14:gs w14:pos="50000">
                                                                           <w14:schemeClr w14:val="accent5"/>
                                                                       </w14:gs>
                                                                       <w14:gs w14:pos="100000">
                                                                           <w14:schemeClr w14:val="accent5">
                                                                               <w14:lumMod w14:val="60000"/>
                                                                               <w14:lumOff w14:val="40000"/>
                                                                           </w14:schemeClr>
                                                                       </w14:gs>
                                                                   </w14:gsLst>
                                                                   <w14:lin w14:ang="5400000" w14:scaled="0"/>
                                                               </w14:gradFill>
                                                           </w14:textFill>
                                                       </w:rPr>
                                                       <w:t>ـ</w:t>
                                                   </w:r>
                                                   <w:r w:rsidR="002F3D6B" w:rsidRPr="00550B38">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="40"/>
                                                           <w:szCs w:val="40"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:reflection w14:blurRad="6350" w14:stA="60000" w14:stPos="0" w14:endA="900" w14:endPos="58000" w14:dist="0" w14:dir="5400000" w14:fadeDir="5400000" w14:sx="100000" w14:sy="-100000" w14:kx="0" w14:ky="0" w14:algn="bl"/>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                           <w14:textFill>
                                                               <w14:gradFill>
                                                                   <w14:gsLst>
                                                                       <w14:gs w14:pos="0">
                                                                           <w14:schemeClr w14:val="accent5">
                                                                               <w14:lumMod w14:val="50000"/>
                                                                           </w14:schemeClr>
                                                                       </w14:gs>
                                                                       <w14:gs w14:pos="50000">
                                                                           <w14:schemeClr w14:val="accent5"/>
                                                                       </w14:gs>
                                                                       <w14:gs w14:pos="100000">
                                                                           <w14:schemeClr w14:val="accent5">
                                                                               <w14:lumMod w14:val="60000"/>
                                                                               <w14:lumOff w14:val="40000"/>
                                                                           </w14:schemeClr>
                                                                       </w14:gs>
                                                                   </w14:gsLst>
                                                                   <w14:lin w14:ang="5400000" w14:scaled="0"/>
                                                               </w14:gradFill>
                                                           </w14:textFill>
                                                       </w:rPr>
                                                       <w:t>ام ف</w:t>
                                                   </w:r>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="40"/>
                                                           <w:szCs w:val="40"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:reflection w14:blurRad="6350" w14:stA="60000" w14:stPos="0" w14:endA="900" w14:endPos="58000" w14:dist="0" w14:dir="5400000" w14:fadeDir="5400000" w14:sx="100000" w14:sy="-100000" w14:kx="0" w14:ky="0" w14:algn="bl"/>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                           <w14:textFill>
                                                               <w14:gradFill>
                                                                   <w14:gsLst>
                                                                       <w14:gs w14:pos="0">
                                                                           <w14:schemeClr w14:val="accent5">
                                                                               <w14:lumMod w14:val="50000"/>
                                                                           </w14:schemeClr>
                                                                       </w14:gs>
                                                                       <w14:gs w14:pos="50000">
                                                                           <w14:schemeClr w14:val="accent5"/>
                                                                       </w14:gs>
                                                                       <w14:gs w14:pos="100000">
                                                                           <w14:schemeClr w14:val="accent5">
                                                                               <w14:lumMod w14:val="60000"/>
                                                                               <w14:lumOff w14:val="40000"/>
                                                                           </w14:schemeClr>
                                                                       </w14:gs>
                                                                   </w14:gsLst>
                                                                   <w14:lin w14:ang="5400000" w14:scaled="0"/>
                                                               </w14:gradFill>
                                                           </w14:textFill>
                                                       </w:rPr>
                                                       <w:t>ـــ</w:t>
                                                   </w:r>
                                                   <w:r w:rsidR="002F3D6B" w:rsidRPr="00550B38">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="40"/>
                                                           <w:szCs w:val="40"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:reflection w14:blurRad="6350" w14:stA="60000" w14:stPos="0" w14:endA="900" w14:endPos="58000" w14:dist="0" w14:dir="5400000" w14:fadeDir="5400000" w14:sx="100000" w14:sy="-100000" w14:kx="0" w14:ky="0" w14:algn="bl"/>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                           <w14:textFill>
                                                               <w14:gradFill>
                                                                   <w14:gsLst>
                                                                       <w14:gs w14:pos="0">
                                                                           <w14:schemeClr w14:val="accent5">
                                                                               <w14:lumMod w14:val="50000"/>
                                                                           </w14:schemeClr>
                                                                       </w14:gs>
                                                                       <w14:gs w14:pos="50000">
                                                                           <w14:schemeClr w14:val="accent5"/>
                                                                       </w14:gs>
                                                                       <w14:gs w14:pos="100000">
                                                                           <w14:schemeClr w14:val="accent5">
                                                                               <w14:lumMod w14:val="60000"/>
                                                                               <w14:lumOff w14:val="40000"/>
                                                                           </w14:schemeClr>
                                                                       </w14:gs>
                                                                   </w14:gsLst>
                                                                   <w14:lin w14:ang="5400000" w14:scaled="0"/>
                                                               </w14:gradFill>
                                                           </w14:textFill>
                                                       </w:rPr>
                                                       <w:t>ي تلبيسة</w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:tc>
                                       </w:tr>
                                       <w:tr w:rsidR="002F3D6B" w:rsidTr="00636BE8">
                                           <w:trPr>
                                               <w:trHeight w:val="770"/>
                                               <w:jc w:val="center"/>
                                           </w:trPr>
                                           <w:tc>
                                               <w:tcPr>
                                                   <w:tcW w:w="1418" w:type="dxa"/>
                                                   <w:tcBorders>
                                                       <w:top w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                       <w:left w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                       <w:bottom w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:right w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                   </w:tcBorders>
                                                   <w:vAlign w:val="center"/>
                                               </w:tcPr>
                                               <w:p w:rsidR="002F3D6B" w:rsidRPr="0040347F" w:rsidRDefault="002F3D6B" w:rsidP="002F3D6B">
                                                   <w:pPr>
                                                       <w:jc w:val="right"/>
                                                       <w:rPr>
                                                           <w:color w:val="000000" w:themeColor="text1"/>
                                                           <w:sz w:val="28"/>
                                                           <w:szCs w:val="28"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:shadow w14:blurRad="38100" w14:dist="19050" w14:dir="2700000" w14:sx="100000" w14:sy="100000" w14:kx="0" w14:ky="0" w14:algn="tl">
                                                               <w14:schemeClr w14:val="dk1">
                                                                   <w14:alpha w14:val="60000"/>
                                                               </w14:schemeClr>
                                                           </w14:shadow>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="0040347F">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:color w:val="000000" w:themeColor="text1"/>
                                                           <w:sz w:val="28"/>
                                                           <w:szCs w:val="28"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:shadow w14:blurRad="38100" w14:dist="19050" w14:dir="2700000" w14:sx="100000" w14:sy="100000" w14:kx="0" w14:ky="0" w14:algn="tl">
                                                               <w14:schemeClr w14:val="dk1">
                                                                   <w14:alpha w14:val="60000"/>
                                                               </w14:schemeClr>
                                                           </w14:shadow>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                       </w:rPr>
                                                       <w:t>اسم المتوفى:</w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:tc>
                                           <w:tc>
                                               <w:tcPr>
                                                   <w:tcW w:w="2835" w:type="dxa"/>
                                                   <w:tcBorders>
                                                       <w:top w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                       <w:left w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:bottom w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:right w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                   </w:tcBorders>
                                                   <w:vAlign w:val="center"/>
                                               </w:tcPr>
                                               <w:p w:rsidR="002F3D6B" w:rsidRPr="0040347F" w:rsidRDefault="000879AF" w:rsidP="002F3D6B">
                                                   <w:pPr>
                                                       <w:jc w:val="both"/>
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:sz w:val="24"/>
                                                           <w:szCs w:val="24"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:proofErr w:type="spellStart"/>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:sz w:val="24"/>
                                                           <w:szCs w:val="24"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.FatherName %></w:t>
                                                   </w:r>
                                                   <w:proofErr w:type="spellEnd"/>
                                               </w:p>
                                           </w:tc>
                                       </w:tr>
                                       <w:tr w:rsidR="00636BE8" w:rsidTr="00636BE8">
                                           <w:trPr>
                                               <w:trHeight w:val="810"/>
                                               <w:jc w:val="center"/>
                                           </w:trPr>
                                           <w:tc>
                                               <w:tcPr>
                                                   <w:tcW w:w="1418" w:type="dxa"/>
                                                   <w:tcBorders>
                                                       <w:top w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:left w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                       <w:bottom w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:right w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                   </w:tcBorders>
                                                   <w:vAlign w:val="center"/>
                                               </w:tcPr>
                                               <w:p w:rsidR="002F3D6B" w:rsidRPr="0040347F" w:rsidRDefault="002F3D6B" w:rsidP="002F3D6B">
                                                   <w:pPr>
                                                       <w:jc w:val="right"/>
                                                       <w:rPr>
                                                           <w:color w:val="000000" w:themeColor="text1"/>
                                                           <w:sz w:val="28"/>
                                                           <w:szCs w:val="28"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:shadow w14:blurRad="38100" w14:dist="19050" w14:dir="2700000" w14:sx="100000" w14:sy="100000" w14:kx="0" w14:ky="0" w14:algn="tl">
                                                               <w14:schemeClr w14:val="dk1">
                                                                   <w14:alpha w14:val="60000"/>
                                                               </w14:schemeClr>
                                                           </w14:shadow>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="0040347F">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:color w:val="000000" w:themeColor="text1"/>
                                                           <w:sz w:val="28"/>
                                                           <w:szCs w:val="28"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:shadow w14:blurRad="38100" w14:dist="19050" w14:dir="2700000" w14:sx="100000" w14:sy="100000" w14:kx="0" w14:ky="0" w14:algn="tl">
                                                               <w14:schemeClr w14:val="dk1">
                                                                   <w14:alpha w14:val="60000"/>
                                                               </w14:schemeClr>
                                                           </w14:shadow>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                       </w:rPr>
                                                       <w:t>اسم الأم:</w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:tc>
                                           <w:tc>
                                               <w:tcPr>
                                                   <w:tcW w:w="2835" w:type="dxa"/>
                                                   <w:tcBorders>
                                                       <w:top w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:left w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:bottom w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:right w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                   </w:tcBorders>
                                                   <w:vAlign w:val="center"/>
                                               </w:tcPr>
                                               <w:p w:rsidR="002F3D6B" w:rsidRPr="0040347F" w:rsidRDefault="000879AF" w:rsidP="002F3D6B">
                                                   <w:pPr>
                                                       <w:jc w:val="both"/>
                                                       <w:rPr>
                                                           <w:sz w:val="24"/>
                                                           <w:szCs w:val="24"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:proofErr w:type="spellStart"/>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:sz w:val="24"/>
                                                           <w:szCs w:val="24"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.MotherName %></w:t>
                                                   </w:r>
                                                   <w:proofErr w:type="spellEnd"/>
                                               </w:p>
                                           </w:tc>
                                       </w:tr>
                                       <w:tr w:rsidR="00636BE8" w:rsidTr="00636BE8">
                                           <w:trPr>
                                               <w:trHeight w:val="402"/>
                                               <w:jc w:val="center"/>
                                           </w:trPr>
                                           <w:tc>
                                               <w:tcPr>
                                                   <w:tcW w:w="1418" w:type="dxa"/>
                                                   <w:tcBorders>
                                                       <w:top w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:left w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                       <w:bottom w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:right w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                   </w:tcBorders>
                                                   <w:vAlign w:val="center"/>
                                               </w:tcPr>
                                               <w:p w:rsidR="002F3D6B" w:rsidRPr="0040347F" w:rsidRDefault="002F3D6B" w:rsidP="002F3D6B">
                                                   <w:pPr>
                                                       <w:jc w:val="right"/>
                                                       <w:rPr>
                                                           <w:color w:val="000000" w:themeColor="text1"/>
                                                           <w:sz w:val="28"/>
                                                           <w:szCs w:val="28"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:shadow w14:blurRad="38100" w14:dist="19050" w14:dir="2700000" w14:sx="100000" w14:sy="100000" w14:kx="0" w14:ky="0" w14:algn="tl">
                                                               <w14:schemeClr w14:val="dk1">
                                                                   <w14:alpha w14:val="60000"/>
                                                               </w14:schemeClr>
                                                           </w14:shadow>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="0040347F">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:color w:val="000000" w:themeColor="text1"/>
                                                           <w:sz w:val="28"/>
                                                           <w:szCs w:val="28"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:shadow w14:blurRad="38100" w14:dist="19050" w14:dir="2700000" w14:sx="100000" w14:sy="100000" w14:kx="0" w14:ky="0" w14:algn="tl">
                                                               <w14:schemeClr w14:val="dk1">
                                                                   <w14:alpha w14:val="60000"/>
                                                               </w14:schemeClr>
                                                           </w14:shadow>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                       </w:rPr>
                                                       <w:t>عدد الأيتام:</w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:tc>
                                           <w:tc>
                                               <w:tcPr>
                                                   <w:tcW w:w="2835" w:type="dxa"/>
                                                   <w:tcBorders>
                                                       <w:top w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:left w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:bottom w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:right w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                   </w:tcBorders>
                                                   <w:vAlign w:val="center"/>
                                               </w:tcPr>
                                               <w:p w:rsidR="002F3D6B" w:rsidRPr="0040347F" w:rsidRDefault="000879AF" w:rsidP="002F3D6B">
                                                   <w:pPr>
                                                       <w:jc w:val="both"/>
                                                       <w:rPr>
                                                           <w:sz w:val="24"/>
                                                           <w:szCs w:val="24"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:proofErr w:type="spellStart"/>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:sz w:val="24"/>
                                                           <w:szCs w:val="24"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.OrphansCount %></w:t>
                                                   </w:r>
                                                   <w:proofErr w:type="spellEnd"/>
                                               </w:p>
                                           </w:tc>
                                       </w:tr>
                                       <w:tr w:rsidR="002F3D6B" w:rsidTr="00636BE8">
                                           <w:trPr>
                                               <w:trHeight w:val="970"/>
                                               <w:jc w:val="center"/>
                                           </w:trPr>
                                           <w:tc>
                                               <w:tcPr>
                                                   <w:tcW w:w="1418" w:type="dxa"/>
                                                   <w:tcBorders>
                                                       <w:top w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:left w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                       <w:bottom w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:right w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                   </w:tcBorders>
                                                   <w:vAlign w:val="center"/>
                                               </w:tcPr>
                                               <w:p w:rsidR="002F3D6B" w:rsidRPr="0040347F" w:rsidRDefault="002F3D6B" w:rsidP="002F3D6B">
                                                   <w:pPr>
                                                       <w:jc w:val="right"/>
                                                       <w:rPr>
                                                           <w:color w:val="000000" w:themeColor="text1"/>
                                                           <w:sz w:val="28"/>
                                                           <w:szCs w:val="28"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:shadow w14:blurRad="38100" w14:dist="19050" w14:dir="2700000" w14:sx="100000" w14:sy="100000" w14:kx="0" w14:ky="0" w14:algn="tl">
                                                               <w14:schemeClr w14:val="dk1">
                                                                   <w14:alpha w14:val="60000"/>
                                                               </w14:schemeClr>
                                                           </w14:shadow>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="0040347F">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:color w:val="000000" w:themeColor="text1"/>
                                                           <w:sz w:val="28"/>
                                                           <w:szCs w:val="28"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:shadow w14:blurRad="38100" w14:dist="19050" w14:dir="2700000" w14:sx="100000" w14:sy="100000" w14:kx="0" w14:ky="0" w14:algn="tl">
                                                               <w14:schemeClr w14:val="dk1">
                                                                   <w14:alpha w14:val="60000"/>
                                                               </w14:schemeClr>
                                                           </w14:shadow>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                       </w:rPr>
                                                       <w:t>أسماء الأيتام:</w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:tc>
                                           <w:tc>
                                               <w:tcPr>
                                                   <w:tcW w:w="2835" w:type="dxa"/>
                                                   <w:tcBorders>
                                                       <w:top w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:left w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:bottom w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:right w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                   </w:tcBorders>
                                                   <w:vAlign w:val="center"/>
                                               </w:tcPr>
                                               <w:p w:rsidR="002F3D6B" w:rsidRPr="0040347F" w:rsidRDefault="000879AF" w:rsidP="002F3D6B">
                                                   <w:pPr>
                                                       <w:jc w:val="both"/>
                                                       <w:rPr>
                                                           <w:sz w:val="24"/>
                                                           <w:szCs w:val="24"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:proofErr w:type="spellStart"/>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:sz w:val="24"/>
                                                           <w:szCs w:val="24"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.OrphansNames %></w:t>
                                                   </w:r>
                                                   <w:proofErr w:type="spellEnd"/>
                                               </w:p>
                                           </w:tc>
                                       </w:tr>
                                       <w:tr w:rsidR="002F3D6B" w:rsidTr="00636BE8">
                                           <w:trPr>
                                               <w:trHeight w:val="1238"/>
                                               <w:jc w:val="center"/>
                                           </w:trPr>
                                           <w:tc>
                                               <w:tcPr>
                                                   <w:tcW w:w="1418" w:type="dxa"/>
                                                   <w:tcBorders>
                                                       <w:top w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:left w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                       <w:bottom w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:right w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                   </w:tcBorders>
                                                   <w:vAlign w:val="center"/>
                                               </w:tcPr>
                                               <w:p w:rsidR="002F3D6B" w:rsidRPr="0040347F" w:rsidRDefault="002F3D6B" w:rsidP="002F3D6B">
                                                   <w:pPr>
                                                       <w:jc w:val="right"/>
                                                       <w:rPr>
                                                           <w:color w:val="000000" w:themeColor="text1"/>
                                                           <w:sz w:val="28"/>
                                                           <w:szCs w:val="28"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:shadow w14:blurRad="38100" w14:dist="19050" w14:dir="2700000" w14:sx="100000" w14:sy="100000" w14:kx="0" w14:ky="0" w14:algn="tl">
                                                               <w14:schemeClr w14:val="dk1">
                                                                   <w14:alpha w14:val="60000"/>
                                                               </w14:schemeClr>
                                                           </w14:shadow>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="0040347F">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:color w:val="000000" w:themeColor="text1"/>
                                                           <w:sz w:val="28"/>
                                                           <w:szCs w:val="28"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:shadow w14:blurRad="38100" w14:dist="19050" w14:dir="2700000" w14:sx="100000" w14:sy="100000" w14:kx="0" w14:ky="0" w14:algn="tl">
                                                               <w14:schemeClr w14:val="dk1">
                                                                   <w14:alpha w14:val="60000"/>
                                                               </w14:schemeClr>
                                                           </w14:shadow>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                       </w:rPr>
                                                       <w:t>العنوان:</w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:tc>
                                           <w:tc>
                                               <w:tcPr>
                                                   <w:tcW w:w="2835" w:type="dxa"/>
                                                   <w:tcBorders>
                                                       <w:top w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:left w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:bottom w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:right w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                   </w:tcBorders>
                                                   <w:vAlign w:val="center"/>
                                               </w:tcPr>
                                               <w:p w:rsidR="002F3D6B" w:rsidRPr="0040347F" w:rsidRDefault="000879AF" w:rsidP="002F3D6B">
                                                   <w:pPr>
                                                       <w:jc w:val="both"/>
                                                       <w:rPr>
                                                           <w:sz w:val="24"/>
                                                           <w:szCs w:val="24"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:proofErr w:type="spellStart"/>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:sz w:val="24"/>
                                                           <w:szCs w:val="24"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Address %></w:t>
                                                   </w:r>
                                                   <w:proofErr w:type="spellEnd"/>
                                               </w:p>
                                           </w:tc>
                                       </w:tr>
                                       <w:tr w:rsidR="002F3D6B" w:rsidTr="00636BE8">
                                           <w:trPr>
                                               <w:trHeight w:val="515"/>
                                               <w:jc w:val="center"/>
                                           </w:trPr>
                                           <w:tc>
                                               <w:tcPr>
                                                   <w:tcW w:w="1418" w:type="dxa"/>
                                                   <w:tcBorders>
                                                       <w:top w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:left w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                       <w:bottom w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:right w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                   </w:tcBorders>
                                                   <w:vAlign w:val="center"/>
                                               </w:tcPr>
                                               <w:p w:rsidR="002F3D6B" w:rsidRPr="0040347F" w:rsidRDefault="002F3D6B" w:rsidP="002F3D6B">
                                                   <w:pPr>
                                                       <w:jc w:val="right"/>
                                                       <w:rPr>
                                                           <w:color w:val="000000" w:themeColor="text1"/>
                                                           <w:sz w:val="28"/>
                                                           <w:szCs w:val="28"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:shadow w14:blurRad="38100" w14:dist="19050" w14:dir="2700000" w14:sx="100000" w14:sy="100000" w14:kx="0" w14:ky="0" w14:algn="tl">
                                                               <w14:schemeClr w14:val="dk1">
                                                                   <w14:alpha w14:val="60000"/>
                                                               </w14:schemeClr>
                                                           </w14:shadow>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="0040347F">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:color w:val="000000" w:themeColor="text1"/>
                                                           <w:sz w:val="28"/>
                                                           <w:szCs w:val="28"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:shadow w14:blurRad="38100" w14:dist="19050" w14:dir="2700000" w14:sx="100000" w14:sy="100000" w14:kx="0" w14:ky="0" w14:algn="tl">
                                                               <w14:schemeClr w14:val="dk1">
                                                                   <w14:alpha w14:val="60000"/>
                                                               </w14:schemeClr>
                                                           </w14:shadow>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                       </w:rPr>
                                                       <w:t>التاريخ:</w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:tc>
                                           <w:tc>
                                               <w:tcPr>
                                                   <w:tcW w:w="2835" w:type="dxa"/>
                                                   <w:tcBorders>
                                                       <w:top w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:left w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:bottom w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:right w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                   </w:tcBorders>
                                                   <w:vAlign w:val="center"/>
                                               </w:tcPr>
                                               <w:p w:rsidR="002F3D6B" w:rsidRPr="0040347F" w:rsidRDefault="000879AF" w:rsidP="002F3D6B">
                                                   <w:pPr>
                                                       <w:jc w:val="both"/>
                                                       <w:rPr>
                                                           <w:sz w:val="24"/>
                                                           <w:szCs w:val="24"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:proofErr w:type="spellStart"/>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:sz w:val="24"/>
                                                           <w:szCs w:val="24"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.BillDate %></w:t>
                                                   </w:r>
                                                   <w:proofErr w:type="spellEnd"/>
                                               </w:p>
                                           </w:tc>
                                       </w:tr>
                                       <w:tr w:rsidR="002F3D6B" w:rsidTr="00636BE8">
                                           <w:trPr>
                                               <w:jc w:val="center"/>
                                           </w:trPr>
                                           <w:tc>
                                               <w:tcPr>
                                                   <w:tcW w:w="1418" w:type="dxa"/>
                                                   <w:tcBorders>
                                                       <w:top w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:left w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                       <w:bottom w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                       <w:right w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                   </w:tcBorders>
                                                   <w:vAlign w:val="center"/>
                                               </w:tcPr>
                                               <w:p w:rsidR="002F3D6B" w:rsidRPr="0040347F" w:rsidRDefault="002F3D6B" w:rsidP="002F3D6B">
                                                   <w:pPr>
                                                       <w:jc w:val="right"/>
                                                       <w:rPr>
                                                           <w:color w:val="000000" w:themeColor="text1"/>
                                                           <w:sz w:val="28"/>
                                                           <w:szCs w:val="28"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:shadow w14:blurRad="38100" w14:dist="19050" w14:dir="2700000" w14:sx="100000" w14:sy="100000" w14:kx="0" w14:ky="0" w14:algn="tl">
                                                               <w14:schemeClr w14:val="dk1">
                                                                   <w14:alpha w14:val="60000"/>
                                                               </w14:schemeClr>
                                                           </w14:shadow>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:r w:rsidRPr="0040347F">
                                                       <w:rPr>
                                                           <w:rFonts w:hint="cs"/>
                                                           <w:color w:val="000000" w:themeColor="text1"/>
                                                           <w:sz w:val="28"/>
                                                           <w:szCs w:val="28"/>
                                                           <w:rtl/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                           <w14:shadow w14:blurRad="38100" w14:dist="19050" w14:dir="2700000" w14:sx="100000" w14:sy="100000" w14:kx="0" w14:ky="0" w14:algn="tl">
                                                               <w14:schemeClr w14:val="dk1">
                                                                   <w14:alpha w14:val="60000"/>
                                                               </w14:schemeClr>
                                                           </w14:shadow>
                                                           <w14:textOutline w14:w="0" w14:cap="flat" w14:cmpd="sng" w14:algn="ctr">
                                                               <w14:noFill/>
                                                               <w14:prstDash w14:val="solid"/>
                                                               <w14:round/>
                                                           </w14:textOutline>
                                                       </w:rPr>
                                                       <w:t>المبلغ:</w:t>
                                                   </w:r>
                                               </w:p>
                                           </w:tc>
                                           <w:tc>
                                               <w:tcPr>
                                                   <w:tcW w:w="2835" w:type="dxa"/>
                                                   <w:tcBorders>
                                                       <w:top w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:left w:val="single" w:sz="4" w:space="0" w:color="AEAAAA" w:themeColor="background2" w:themeShade="BF"/>
                                                       <w:bottom w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                       <w:right w:val="single" w:sz="12" w:space="0" w:color="FFFFFF" w:themeColor="background1"/>
                                                   </w:tcBorders>
                                               </w:tcPr>
                                               <w:p w:rsidR="002F3D6B" w:rsidRPr="00550B38" w:rsidRDefault="000879AF" w:rsidP="000879AF">
                                                   <w:pPr>
                                                       <w:rPr>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="24"/>
                                                           <w:szCs w:val="24"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                   </w:pPr>
                                                   <w:proofErr w:type="spellStart"/>
                                                   <w:r>
                                                       <w:rPr>
                                                           <w:b/>
                                                           <w:bCs/>
                                                           <w:sz w:val="28"/>
                                                           <w:szCs w:val="28"/>
                                                           <w:lang w:bidi="ar-SY"/>
                                                       </w:rPr>
                                                       <w:t><%= Data.Salary %></w:t>
                                                   </w:r>
                                                   <w:proofErr w:type="spellEnd"/>
                                               </w:p>
                                           </w:tc>
                                       </w:tr>
                                   </w:tbl>
                                   <w:p w:rsidR="002F3D6B" w:rsidRDefault="002F3D6B" w:rsidP="00550B38">
                                       <w:pPr>
                                           <w:ind w:right="426"/>
                                           <w:jc w:val="center"/>
                                           <w:rPr>
                                               <w:rtl/>
                                               <w:lang w:bidi="ar-SY"/>
                                           </w:rPr>
                                       </w:pPr>
                                   </w:p>
                               </w:tc>
                           </w:tr>
                       </w:tbl>
                       <w:p w:rsidR="003729F3" w:rsidRDefault="000E06D3" w:rsidP="002F3D6B">
                           <w:pPr>
                               <w:ind w:right="426"/>
                               <w:rPr>
                                   <w:rtl/>
                                   <w:lang w:bidi="ar-SY"/>
                               </w:rPr>
                           </w:pPr>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="0" distB="0" distL="114300" distR="114300" simplePos="0" relativeHeight="251659264" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>-180975</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>-2397760</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="914400" cy="914400"/>
                                               <wp:effectExtent l="171450" t="95250" r="0" b="114300"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="2" name="مثلث قائم الزاوية 2"/>
                                               <wp:cNvGraphicFramePr/>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr/>
                                                           <wps:spPr>
                                                               <a:xfrm rot="8006171" flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="914400" cy="914400"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rtTriangle">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:solidFill>
                                                                   <a:schemeClr val="bg1">
                                                                       <a:lumMod val="95000"/>
                                                                   </a:schemeClr>
                                                               </a:solidFill>
                                                               <a:ln>
                                                                   <a:noFill/>
                                                               </a:ln>
                                                               <a:effectLst>
                                                                   <a:softEdge rad="63500"/>
                                                               </a:effectLst>
                                                           </wps:spPr>
                                                           <wps:style>
                                                               <a:lnRef idx="2">
                                                                   <a:schemeClr val="dk1">
                                                                       <a:shade val="50000"/>
                                                                   </a:schemeClr>
                                                               </a:lnRef>
                                                               <a:fillRef idx="1">
                                                                   <a:schemeClr val="dk1"/>
                                                               </a:fillRef>
                                                               <a:effectRef idx="0">
                                                                   <a:schemeClr val="dk1"/>
                                                               </a:effectRef>
                                                               <a:fontRef idx="minor">
                                                                   <a:schemeClr val="lt1"/>
                                                               </a:fontRef>
                                                           </wps:style>
                                                           <wps:bodyPr rot="0" spcFirstLastPara="0" vertOverflow="overflow" horzOverflow="overflow" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" numCol="1" spcCol="0" rtlCol="1" fromWordArt="0" anchor="ctr" anchorCtr="0" forceAA="0" compatLnSpc="1">
                                                               <a:prstTxWarp prst="textNoShape">
                                                                   <a:avLst/>
                                                               </a:prstTxWarp>
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shapetype w14:anchorId="2E5719D7" id="_x0000_t6" coordsize="21600,21600" o:spt="6" path="m,l,21600r21600,xe">
                                               <v:stroke joinstyle="miter"/>
                                               <v:path gradientshapeok="t" o:connecttype="custom" o:connectlocs="0,0;0,10800;0,21600;10800,21600;21600,21600;10800,10800" textboxrect="1800,12600,12600,19800"/>
                                           </v:shapetype>
                                           <v:shape id="مثلث قائم الزاوية 2" o:spid="_x0000_s1026" type="#_x0000_t6" style="position:absolute;left:0;text-align:left;margin-left:-14.25pt;margin-top:-188.8pt;width:1in;height:1in;rotation:-8744874fd;flip:x;z-index:251659264;visibility:visible;mso-wrap-style:square;mso-wrap-distance-left:9pt;mso-wrap-distance-top:0;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:0;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;v-text-anchor:middle" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQAZAdeq5AIAAAQGAAAOAAAAZHJzL2Uyb0RvYy54bWysVM1uEzEQviPxDpbvdDehv1E3VdRSQCpt&#xa;RIt6drx21sJrG9v544iohHgQKtQbT5O8DWN7s01puSAulj2e+ebz55k5PJrXEk2ZdUKrAne2coyY&#xa;oroUalzgD1enL/Yxcp6okkitWIEXzOGj/vNnhzPTY11daVkyiwBEud7MFLjy3vSyzNGK1cRtacMU&#xa;XHJta+LhaMdZackM0GuZdfN8N5tpWxqrKXMOrCfpEvcjPueM+gvOHfNIFhi4+bjauI7CmvUPSW9s&#xa;iakEbWiQf2BRE6EgaQt1QjxBEyseQdWCWu0091tU15nmXFAW3wCv6eR/vOayIobFt4A4zrQyuf8H&#xa;S8+nQ4tEWeAuRorU8EWrm+Xd6uvyDq2+LG+XP1Y3aHkL51+wflt9X/5E3aDazLgeBF+aoW1ODrZB&#xa;gjm3NbIapN6HD+rsdTDiUpg3UB5RIng0mscfWLQ/wOYeUTAedLa3c/gnClfNHtCzBBrAjXX+NdM1&#xa;CpsCW39lBVFjGWQiPTI9cz4FrB2D2WkpylMhZTyE0mLH0qIpgaIYjRMrOanf6TLZDnZyIJFwYiUG&#xa;90jjAZJUAU/pgJyck4XFugMmKTf3r8oxQ5aAyLsvAbpB3nDLgppJv7jzC8lCsFTvGYffAWW68YEt&#xa;m0S0/JjIu4qULJkC9XWG1jtyj2ABlQPfFrcBeChKwE0vanxDWOLbBuZ/I5QCW++YUSvfBtZCaftU&#xa;sPRt1uQPtDfkCNuRLhdQr7G6oEycoacCCuGMOD8kFjoXjDCN/AUsXOpZgXWzw6jS9vNT9uAPDQW3&#xa;GM1gEhTYfZoQyzCSbxW0WqxDGB3xsL2z14UcdvNmtHmjJvWxhrqCqgd2cRv8vVxbudX1NQytQcgK&#xa;V0RRyF1g6u36cOzThIKxR9lgEN1gXBjiz9SloetGCiV+Nb8m1jTd4KGNzvV6ajxqh+Qb/kPpwcRr&#xa;LmKv3Ova6A2jJhZMMxbDLNs8R6/74d3/DQAA//8DAFBLAwQUAAYACAAAACEA8u6S5eIAAAANAQAA&#xa;DwAAAGRycy9kb3ducmV2LnhtbEyPQU+EMBCF7yb+h2ZMvO2WXbLsBikbY9QDqwmuHjwWOgKRtqQt&#xa;LP57h5PeZua9vPledpx1zyZ0vrNGwGYdAUNTW9WZRsDH+9PqAMwHaZTsrUEBP+jhmF9fZTJV9mLe&#xa;cDqHhlGI8akU0IYwpJz7ukUt/doOaEj7sk7LQKtruHLyQuG659soSriWnaEPrRzwocX6+zxqAae4&#xa;qF7Hx5ey9MVzWU6fLirsSYjbm/n+DljAOfyZYcEndMiJqbKjUZ71Albbw46sNMT7fQJssWx2dKoW&#xa;LY4T4HnG/7fIfwEAAP//AwBQSwECLQAUAAYACAAAACEAtoM4kv4AAADhAQAAEwAAAAAAAAAAAAAA&#xa;AAAAAAAAW0NvbnRlbnRfVHlwZXNdLnhtbFBLAQItABQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAA&#xa;AAAAAAAAAAAAAC8BAABfcmVscy8ucmVsc1BLAQItABQABgAIAAAAIQAZAdeq5AIAAAQGAAAOAAAA&#xa;AAAAAAAAAAAAAC4CAABkcnMvZTJvRG9jLnhtbFBLAQItABQABgAIAAAAIQDy7pLl4gAAAA0BAAAP&#xa;AAAAAAAAAAAAAAAAAD4FAABkcnMvZG93bnJldi54bWxQSwUGAAAAAAQABADzAAAATQYAAAAA&#xa;" fillcolor="#f2f2f2 [3052]" stroked="f" strokeweight="1pt"/>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                       </w:p>
                       <w:sectPr w:rsidR="003729F3" w:rsidSect="000E06D3">
                           <w:type w:val="continuous"/>
                           <w:pgSz w:w="11907" w:h="8391" w:orient="landscape" w:code="11"/>
                           <w:pgMar w:top="720" w:right="720" w:bottom="720" w:left="720" w:header="708" w:footer="708" w:gutter="0"/>
                           <w:cols w:space="1"/>
                           <w:bidi/>
                           <w:rtlGutter/>
                           <w:docGrid w:linePitch="360"/>
                       </w:sectPr>
                   </w:body>
               </w:document>
    End Sub

    Public Sub New(ByVal Data As FinancialData)
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
            File.WriteAllBytes(TempPath, My.Resources.FinancailCrad)
            Using TempDoc As WordprocessingDocument = WordprocessingDocument.Open(TempPath, True)
                Dim MainP = TempDoc.MainDocumentPart
                Using sw As New StreamWriter(MainP.GetStream(FileMode.Create))
                    _Document.Save(sw)
                End Using
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
    Public Sub AddPage(ByVal PageNum As Integer, ByVal PageData As FinancialData)
        If IsNothing(_Pages) Then
            _Pages = New Dictionary(Of Integer, FinancialData)
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
                    Dim NextData As FinancialData = _Pages(key)
                    LoadDocument(NextDoc, _Pages(key))
                    Dim NextBody = NextDoc...<w:body>.First()
                    If i = 0 Then
                        MainBody.ReplaceNodes(NextBody.Elements)
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
