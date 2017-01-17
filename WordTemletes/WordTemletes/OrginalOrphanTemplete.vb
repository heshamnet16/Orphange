Imports System.IO
Imports DocumentFormat.OpenXml.Wordprocessing
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml
Imports System.Drawing
Imports <xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
Imports <xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
Imports <xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships">
Public Class OrginalOrphanTemplete

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
    Private _Pages As Dictionary(Of Integer, _MaktabData) = Nothing
    Public ReadOnly Property Pages As Dictionary(Of Integer, _MaktabData)
        Get
            Return _Pages
        End Get
    End Property

    Public Structure _MaktabData
        Public Orphan_FirstName As String
        Public Orphan_Sex As String
        Public Orphan_Birthday As Date
        Public Orphan_Age As String
        Public Orphan_FullHealth As String
        Public Orphan_Education As String
        Public Orphan_BondsManRelation As String
        Public Orphan_FacePhoto() As Byte
        Public Orphan_Regdate As Date
        Public Orphan_HasBirthCertificate As String
        Public Orphan_IsBailed As Boolean
        Public Orphan_BirthPlaceANDKaid As String
        Public Father_FullName As String
        Public Father_DieDate As Date
        Public Father_HasDeathCertificate As String
        Public Mother_FullName As String
        Public Mother_IsAlive As Boolean
        Public Mother_IsMarried As Boolean
        Public Mother_IsOwnOrphans As Boolean
        Public Mother_IsOwnOthersOrphans As String
        Public Mother_Jop As String
        Public Mother_IdNumber As String
        Public Mother_Birthday As Date
        Public Family_FullAdress As String
        Public Family_HasFamilyCardPhoto As String
        Public Family_Phone As String
        Public Family_ResidenceState As String
        Public Family_Residence_Type As String
        Public Family_CardNumber As String
        Public Family_Finncial_State As String
        Public BondsMan_FullName As String
        Public BondsMan_HasBondsManIdPhoto As String
        Public BondsMan_Jop As String
        Public BondsMan_Salary As String
    End Structure

    Private _Data As _MaktabData = Nothing
    Public Property DataStructure As _MaktabData
        Get
            Return _Data
        End Get
        Set(ByVal value As _MaktabData)
            _Data = value
        End Set
    End Property

    Private Sub LoadDocument(ByRef _doc As XDocument, ByVal Data As _MaktabData)
        Dim Mother_Alive As String
        If Data.Mother_IsAlive Then
            Mother_Alive = "نعم"
        Else
            Mother_Alive = "لا"
        End If
        Dim Mother_Married As String
        If Data.Mother_IsMarried Then
            Mother_Married = "نعم"
        Else
            Mother_Married = "لا"
        End If
        Dim Mother_OwnOrphans As String
        If Data.Mother_IsOwnOrphans Then
            Mother_OwnOrphans = "نعم"
        Else
            Mother_OwnOrphans = "لا"
        End If
        Dim Orphan_bailed As String
        If Data.Orphan_IsBailed Then
            Orphan_bailed = "نعم"
        Else
            Orphan_bailed = "لا"
        End If
        _doc = <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
               <w:document xmlns:wpc="http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas" xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:m="http://schemas.openxmlformats.org/officeDocument/2006/math" xmlns:v="urn:schemas-microsoft-com:vml" xmlns:wp14="http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing" xmlns:wp="http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing" xmlns:w10="urn:schemas-microsoft-com:office:word" xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main" xmlns:w14="http://schemas.microsoft.com/office/word/2010/wordml" xmlns:w15="http://schemas.microsoft.com/office/word/2012/wordml" xmlns:wpg="http://schemas.microsoft.com/office/word/2010/wordprocessingGroup" xmlns:wpi="http://schemas.microsoft.com/office/word/2010/wordprocessingInk" xmlns:wne="http://schemas.microsoft.com/office/word/2006/wordml" xmlns:wps="http://schemas.microsoft.com/office/word/2010/wordprocessingShape" mc:Ignorable="w14 w15 wp14">
                   <w:body>
                       <w:p w:rsidR="00FA4D79" w:rsidRDefault="00262613">
                           <w:pPr>
                               <w:rPr>
                                   <w:sz w:val="18"/>
                                   <w:szCs w:val="18"/>
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
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251659264" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="1CE0421A" wp14:editId="6254AC18">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>-114300</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>64234</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="981710" cy="290830"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="1" name="مربع نص 1"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="981710" cy="290830"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00262613" w:rsidRPr="00262613" w:rsidRDefault="00262613" w:rsidP="00262613">
                                                                       <w:pPr>
                                                                           <w:rPr>
                                                                               <w:sz w:val="24"/>
                                                                               <w:szCs w:val="24"/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r>
                                                                           <w:rPr>
                                                                               <w:sz w:val="24"/>
                                                                               <w:szCs w:val="24"/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Orphan_Regdate.ToString("yyyy/MM/dd") %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shapetype w14:anchorId="1CE0421A" id="_x0000_t202" coordsize="21600,21600" o:spt="202" path="m,l,21600r21600,l21600,xe">
                                               <v:stroke joinstyle="miter"/>
                                               <v:path gradientshapeok="t" o:connecttype="rect"/>
                                           </v:shapetype>
                                           <v:shape id="مربع نص 1" o:spid="_x0000_s1026" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:-9pt;margin-top:5.05pt;width:77.3pt;height:22.9pt;flip:x;z-index:251659264;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQDXADdPIwIAAAAEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNElp2TZqulp2WUBa&#xa;fqSFB3Adp7GwPcZ2m3Tv8CxcOXDgTbpvw9jplgpuiBwsOzP+Zr5vPi/Oe63IVjgvwVS0GOWUCMOh&#xa;lmZd0Y8frp/MKPGBmZopMKKiO+Hp+fLxo0VnSzGGFlQtHEEQ48vOVrQNwZZZ5nkrNPMjsMJgsAGn&#xa;WcCjW2e1Yx2ia5WN8/xZ1oGrrQMuvMe/V0OQLhN+0wge3jWNF4GoimJvIa0urau4ZssFK9eO2Vby&#xa;QxvsH7rQTBoseoS6YoGRjZN/QWnJHXhowoiDzqBpJBeJA7Ip8j/Y3LbMisQFxfH2KJP/f7D87fa9&#xa;I7LG2VFimMYR3X/Zf99/2/8k91/3P0gRJeqsLzHz1mJu6J9DH9MjXW9vgH/yxMBly8xaXDgHXStY&#xa;jS2mm9nJ1QHHR5BV9wZqrMU2ARJQ3zhNGiXtqwdo1IZgHRza7jgo0QfC8ed8VpwVGOEYGs/z2dM0&#xa;yIyVESb2ZZ0PLwVoEjcVdeiDVIZtb3xAQpj6kBLTDVxLpZIXlCEdFpiOp+nCSUTLgFZVUld0lsdv&#xa;ME9k+8LU6XJgUg17LKAM1on0I+OBe+hX/UHOFdQ7FMLBYEl8Qrhpwd1R0qEdK+o/b5gTlKjXBsWc&#xa;F5NJ9G86TKZnYzy408jqNMIMR6iKBkqG7WVInh+4XqDojUwyxPaGTg69os2SOocnEX18ek5Zvx/u&#xa;8hcAAAD//wMAUEsDBBQABgAIAAAAIQDG/HqA4AAAAAkBAAAPAAAAZHJzL2Rvd25yZXYueG1sTI/B&#xa;TsMwEETvSPyDtUjcWidAQglxKoSExCEgmlYqRzfexlHtdRS7bfh73BMcRzOaeVMuJ2vYCUffOxKQ&#xa;zhNgSK1TPXUCNuu32QKYD5KUNI5QwA96WFbXV6UslDvTCk9N6FgsIV9IATqEoeDctxqt9HM3IEVv&#xa;70YrQ5Rjx9Uoz7HcGn6XJDm3sqe4oOWArxrbQ3O0AlS93WaPh6Fe6e+H/bv5VHXz9SHE7c308gws&#xa;4BT+wnDBj+hQRaadO5LyzAiYpYv4JUQjSYFdAvd5DmwnIMuegFcl//+g+gUAAP//AwBQSwECLQAU&#xa;AAYACAAAACEAtoM4kv4AAADhAQAAEwAAAAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRfVHlwZXNdLnht&#xa;bFBLAQItABQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAAAAAAAAAAAAAAC8BAABfcmVscy8ucmVs&#xa;c1BLAQItABQABgAIAAAAIQDXADdPIwIAAAAEAAAOAAAAAAAAAAAAAAAAAC4CAABkcnMvZTJvRG9j&#xa;LnhtbFBLAQItABQABgAIAAAAIQDG/HqA4AAAAAkBAAAPAAAAAAAAAAAAAAAAAH0EAABkcnMvZG93&#xa;bnJldi54bWxQSwUGAAAAAAQABADzAAAAigUAAAAA&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00262613" w:rsidRPr="00262613" w:rsidRDefault="00262613" w:rsidP="00262613">
                                                           <w:pPr>
                                                               <w:rPr>
                                                                   <w:sz w:val="24"/>
                                                                   <w:szCs w:val="24"/>
                                                                   <w:rtl/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r>
                                                               <w:rPr>
                                                                   <w:sz w:val="24"/>
                                                                   <w:szCs w:val="24"/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Orphan_Regdate.ToString("yyyy/MM/dd") %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                       </w:p>
                       <w:p w:rsidR="00FA4D79" w:rsidRPr="00FA4D79" w:rsidRDefault="00FA4D79">
                           <w:pPr>
                               <w:rPr>
                                   <w:sz w:val="8"/>
                                   <w:szCs w:val="8"/>
                                   <w:rtl/>
                                   <w:lang w:bidi="ar-SY"/>
                               </w:rPr>
                           </w:pPr>
                       </w:p>
                       <w:p w:rsidR="00AB47DB" w:rsidRDefault="00AB47DB" w:rsidP="00FA4D79">
                           <w:pPr>
                               <w:rPr>
                                   <w:rtl/>
                                   <w:lang w:bidi="ar-SY"/>
                               </w:rPr>
                           </w:pPr>
                       </w:p>
                       <w:p w:rsidR="00AB47DB" w:rsidRDefault="00AB47DB" w:rsidP="00FA4D79">
                           <w:pPr>
                               <w:rPr>
                                   <w:rtl/>
                                   <w:lang w:bidi="ar-SY"/>
                               </w:rPr>
                           </w:pPr>
                       </w:p>
                       <w:p w:rsidR="00AB47DB" w:rsidRDefault="00AB47DB" w:rsidP="00FA4D79">
                           <w:pPr>
                               <w:rPr>
                                   <w:rFonts w:hint="cs"/>
                                   <w:rtl/>
                                   <w:lang w:bidi="ar-SY"/>
                               </w:rPr>
                           </w:pPr>
                       </w:p>
                       <w:p w:rsidR="00AB47DB" w:rsidRDefault="00AB47DB" w:rsidP="00FA4D79">
                           <w:pPr>
                               <w:rPr>
                                   <w:rtl/>
                                   <w:lang w:bidi="ar-SY"/>
                               </w:rPr>
                           </w:pPr>
                       </w:p>
                       <w:p w:rsidR="00AB47DB" w:rsidRDefault="00AB47DB" w:rsidP="00FA4D79">
                           <w:pPr>
                               <w:rPr>
                                   <w:rtl/>
                                   <w:lang w:bidi="ar-SY"/>
                               </w:rPr>
                           </w:pPr>
                       </w:p>
                       <w:p w:rsidR="007A6B2D" w:rsidRDefault="007A6B2D" w:rsidP="00FA4D79">
                           <w:pPr>
                               <w:rPr>
                                   <w:rtl/>
                                   <w:lang w:bidi="ar-SY"/>
                               </w:rPr>
                           </w:pPr>
                       </w:p>
                       <w:p w:rsidR="005734CD" w:rsidRPr="007A6B2D" w:rsidRDefault="00E86C95" w:rsidP="007A6B2D">
                           <w:pPr>
                               <w:rPr>
                                   <w:rtl/>
                                   <w:lang w:bidi="ar-SY"/>
                               </w:rPr>
                           </w:pPr>
                           <w:bookmarkStart w:id="0" w:name="_GoBack"/>
                           <w:bookmarkEnd w:id="0"/>
                           <w:r>
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251633152" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="11171B34" wp14:editId="3E7B4FB1">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>-257175</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>869950</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1224280" cy="285750"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="21" name="مربع نص 21"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1224280" cy="285750"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00C91656">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Orphan_Sex %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="11171B34" id="مربع نص 21" o:spid="_x0000_s1027" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:-20.25pt;margin-top:68.5pt;width:96.4pt;height:22.5pt;flip:x;z-index:251633152;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQB9moHjJwIAAAoEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNG3Ust2o7mrZZQFp&#xa;+ZEWHsB1nMbC9hjbbVLu8CxcOXDgTbpvw9jplgpuiBwsOzP+Zr5vPi8ueqPJVvqgwDI6GY0pkVZA&#xa;reya0Q/vb57MKQmR25prsJLRnQz0Yvn40aJzlSyhBV1LTxDEhqpzjLYxuqoogmil4WEETloMNuAN&#xa;j3j066L2vEN0o4tyPH5adOBr50HIEPDv9RCky4zfNFLEt00TZCSaUewt5tXndZXWYrng1dpz1ypx&#xa;aIP/QxeGK4tFj1DXPHKy8eovKKOEhwBNHAkwBTSNEjJzQDaT8R9s7lruZOaC4gR3lCn8P1jxZvvO&#xa;E1UzWk4osdzgjO6/7L/vv+1/kvuv+x8E/6NInQsV5t45zI79M+hx2JlwcLcgPgZi4arldi0vvYeu&#xa;lbzGJvPN4uTqgBMSyKp7DTUW45sIGahvvCGNVu7lAzSqQ7AOjm13HJXsIxGpeFlOyzmGBMbK+exs&#xa;lmdZ8CrhpEk4H+ILCYakDaMerZDr8O1tiMgIUx9SUrqFG6V1toO2pGP0fFbO8oWTiFER3aqVYXQ+&#xa;Tt/gn0T3ua3z5ciVHvZYQFusk/gnygP52K/6rPdR1hXUOxTEw2BOfEy4acF/pqRDYzIaPm24l5To&#xa;VxZFPZ9Mp8nJ+TCdnZV48KeR1WmEW4FQjEZKhu1VzO4fKF+i+I3KaqQuh04OLaPhskiHx5EcfXrO&#xa;Wb+f8PIXAAAA//8DAFBLAwQUAAYACAAAACEA9XBDPeIAAAALAQAADwAAAGRycy9kb3ducmV2Lnht&#xa;bEyPT2vCQBDF74V+h2UKveluo6kSs5FSKPSQFk0LelyzYxLcPyG7avrtO57a2zzejzfv5evRGnbB&#xa;IXTeSXiaCmDoaq8710j4/nqbLIGFqJxWxjuU8IMB1sX9Xa4y7a9ui5cqNoxCXMiUhDbGPuM81C1a&#xa;Faa+R0fe0Q9WRZJDw/WgrhRuDU+EeOZWdY4+tKrH1xbrU3W2EnS526WLU19u2/38+G4+dVltPqR8&#xa;fBhfVsAijvEPhlt9qg4FdTr4s9OBGQmTuUgJJWO2oFE3Ik1mwA50LBMBvMj5/w3FLwAAAP//AwBQ&#xa;SwECLQAUAAYACAAAACEAtoM4kv4AAADhAQAAEwAAAAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRfVHlw&#xa;ZXNdLnhtbFBLAQItABQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAAAAAAAAAAAAAAC8BAABfcmVs&#xa;cy8ucmVsc1BLAQItABQABgAIAAAAIQB9moHjJwIAAAoEAAAOAAAAAAAAAAAAAAAAAC4CAABkcnMv&#xa;ZTJvRG9jLnhtbFBLAQItABQABgAIAAAAIQD1cEM94gAAAAsBAAAPAAAAAAAAAAAAAAAAAIEEAABk&#xa;cnMvZG93bnJldi54bWxQSwUGAAAAAAQABADzAAAAkAUAAAAA&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00C91656">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Orphan_Sex %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="001F0B97">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251624960" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="2DBD86CF" wp14:editId="5AE98CBD">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>2266950</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>2117725</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1304290" cy="466725"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="17" name="مربع نص 17"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1304290" cy="466725"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi" w:hint="cs"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Father_FullName %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="b" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="2DBD86CF" id="مربع نص 17" o:spid="_x0000_s1028" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:178.5pt;margin-top:166.75pt;width:102.7pt;height:36.75pt;flip:x;z-index:251624960;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:bottom" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQDD6ajmJQIAAAoEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNGnozzZqulp2WUBa&#xa;fqSFB3Acp7FwPMZ2m5Q7PAtXDhx4k+7bMHa63Wq5IXKw7Mz4m/m++bw871tFtsI6Cbqg41FKidAc&#xa;KqnXBf308frZGSXOM10xBVoUdCccPV89fbLsTC4yaEBVwhIE0S7vTEEb702eJI43omVuBEZoDNZg&#xa;W+bxaNdJZVmH6K1KsjSdJR3Yyljgwjn8ezUE6Sri17Xg/n1dO+GJKij25uNq41qGNVktWb62zDSS&#xa;H9pg/9BFy6TGokeoK+YZ2Vj5F1QruQUHtR9xaBOoa8lF5IBsxukjNrcNMyJyQXGcOcrk/h8sf7f9&#xa;YImscHZzSjRrcUZ33/Y/9z/2v8nd9/0vgv9RpM64HHNvDWb7/gX0eCESduYG+GdHNFw2TK/FhbXQ&#xa;NYJV2OQ43ExOrg44LoCU3VuosBjbeIhAfW1bUitpXt9DozoE6+DYdsdRid4THoo/TyfZAkMcY5PZ&#xa;bJ5NYzGWB5wwCWOdfyWgJWFTUItWiHXY9sb50NdDSkjXcC2VinZQmnQFXUwR8lGklR7dqmRb0LM0&#xa;fIN/At2XuoqXPZNq2GMBpQ/8A+WBvO/LPuqd3ctaQrVDQSwM5sTHhJsG7FdKOjRmQd2XDbOCEvVG&#xa;o6iL8WQSnBwPk+k8w4M9jZSnEaY5QhW0pGTYXvro/oHYBYpfy6hGmNLQyaFlNFwU6fA4gqNPzzHr&#xa;4Qmv/gAAAP//AwBQSwMEFAAGAAgAAAAhAJFXbmDhAAAACwEAAA8AAABkcnMvZG93bnJldi54bWxM&#xa;j81qwzAQhO+FvoPYQi+lkRPHbnAshxDooZBL0158k6WNbaIfYymJ/fbdntrbDjPMflPuJmvYDcfQ&#xa;eydguUiAoVNe964V8P31/roBFqJ0WhrvUMCMAXbV40MpC+3v7hNvp9gyKnGhkAK6GIeC86A6tDIs&#xa;/ICOvLMfrYwkx5brUd6p3Bq+SpKcW9k7+tDJAQ8dqsvpagUc57zeL1+OKjtfDmo2TY0fbS3E89O0&#xa;3wKLOMW/MPziEzpUxNT4q9OBGQFp9kZbIh1pmgGjRJav1sAaAeuELF6V/P+G6gcAAP//AwBQSwEC&#xa;LQAUAAYACAAAACEAtoM4kv4AAADhAQAAEwAAAAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRfVHlwZXNd&#xa;LnhtbFBLAQItABQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAAAAAAAAAAAAAAC8BAABfcmVscy8u&#xa;cmVsc1BLAQItABQABgAIAAAAIQDD6ajmJQIAAAoEAAAOAAAAAAAAAAAAAAAAAC4CAABkcnMvZTJv&#xa;RG9jLnhtbFBLAQItABQABgAIAAAAIQCRV25g4QAAAAsBAAAPAAAAAAAAAAAAAAAAAH8EAABkcnMv&#xa;ZG93bnJldi54bWxQSwUGAAAAAAQABADzAAAAjQUAAAAA&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi" w:hint="cs"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:rtl/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Father_FullName %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="001F0B97">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251670016" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="4CC90AD2" wp14:editId="57B10429">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>3352800</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>4889500</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1562100" cy="552450"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="52" name="مربع نص 2"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1562100" cy="552450"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="0054320A" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi" w:hint="cs"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.BondsMan_FullName %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="4CC90AD2" id="مربع نص 2" o:spid="_x0000_s1029" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:264pt;margin-top:385pt;width:123pt;height:43.5pt;flip:x;z-index:251670016;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQDIOF8bJgIAAAkEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNGlolt2o6WrZZQFp&#xa;+ZEWHsB1nMbC9hjbbVLu8CxcOXDgTbpvw9jpdiu4IXKw7Mz4m/m++Tw/H7QiG+G8BFPT6SSnRBgO&#xa;jTSrmn78cP3klBIfmGmYAiNquhWeni8eP5r3thIFdKAa4QiCGF/1tqZdCLbKMs87oZmfgBUGgy04&#xa;zQIe3SprHOsRXausyPOTrAfXWAdceI9/r8YgXST8thU8vGtbLwJRNcXeQlpdWpdxzRZzVq0cs53k&#xa;+zbYP3ShmTRY9AB1xQIjayf/gtKSO/DQhgkHnUHbSi4SB2Qzzf9gc9sxKxIXFMfbg0z+/8Hyt5v3&#xa;jsimpmVBiWEaZ3T3dfdj9333i9x92/0kRdSot77C1FuLyWF4DgPOOvH19gb4J08MXHbMrMSFc9B3&#xa;gjXY4zTezI6ujjg+giz7N9BgLbYOkICG1mnSKmlf3UOjOATr4NS2h0mJIRAei5cnxTTHEMdYWRaz&#xa;Mo0yY1XEiYOwzoeXAjSJm5o6dEKqwzY3PsS+HlJiuoFrqVRygzKkr+lZWZTpwlFEy4BmVVLX9DSP&#xa;32ifSPeFadLlwKQa91hAmT3/SHkkH4blkOR+ei/rEpotCuJg9Ca+Jdx04L5Q0qMva+o/r5kTlKjX&#xa;BkU9m85m0cjpMCufFXhwx5HlcYQZjlA1DZSM28uQzD9SvkDxW5nUiFMaO9m3jH5LIu3fRjT08Tll&#xa;PbzgxW8AAAD//wMAUEsDBBQABgAIAAAAIQB3xGFt4QAAAAsBAAAPAAAAZHJzL2Rvd25yZXYueG1s&#xa;TI9RS8MwFIXfBf9DuIJvLnGsptSmQwTBhyquCvMxa+6asiYpTbbVf+/1ab6dwz2c+51yPbuBnXCK&#xa;ffAK7hcCGPo2mN53Cr4+X+5yYDFpb/QQPCr4wQjr6vqq1IUJZ7/BU5M6RiU+FlqBTWksOI+tRafj&#xa;Iozo6bYPk9OJ7NRxM+kzlbuBL4V44E73nj5YPeKzxfbQHJ0CU2+3mTyM9cZ+r/avw7upm483pW5v&#xa;5qdHYAnndAnDHz6hQ0VMu3D0JrJBQbbMaUtSIKUgQQkpVyR2CvJMCuBVyf9vqH4BAAD//wMAUEsB&#xa;Ai0AFAAGAAgAAAAhALaDOJL+AAAA4QEAABMAAAAAAAAAAAAAAAAAAAAAAFtDb250ZW50X1R5cGVz&#xa;XS54bWxQSwECLQAUAAYACAAAACEAOP0h/9YAAACUAQAACwAAAAAAAAAAAAAAAAAvAQAAX3JlbHMv&#xa;LnJlbHNQSwECLQAUAAYACAAAACEAyDhfGyYCAAAJBAAADgAAAAAAAAAAAAAAAAAuAgAAZHJzL2Uy&#xa;b0RvYy54bWxQSwECLQAUAAYACAAAACEAd8RhbeEAAAALAQAADwAAAAAAAAAAAAAAAACABAAAZHJz&#xa;L2Rvd25yZXYueG1sUEsFBgAAAAAEAAQA8wAAAI4FAAAAAA==&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="0054320A" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi" w:hint="cs"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:rtl/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                               <w:t><%= Data.BondsMan_FullName %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="001F0B97">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251637248" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="3CF98BFC" wp14:editId="4C7C1C63">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>3352800</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>3298824</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1436370" cy="428625"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="28" name="مربع نص 2"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1436370" cy="428625"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Mother_FullName %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="3CF98BFC" id="_x0000_s1030" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:264pt;margin-top:259.75pt;width:113.1pt;height:33.75pt;flip:x;z-index:251637248;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQBd+4sFJQIAAAkEAAAOAAAAZHJzL2Uyb0RvYy54bWysU81uEzEQviPxDpbvZJPtJk2jbKrSUkAq&#xa;P1LhARyvN2the4ztZDe9w7Nw5cCBN0nfhrE3TaNyQ+zBsnfG38z3zef5eacV2QjnJZiSjgZDSoTh&#xa;UEmzKunnT9cvppT4wEzFFBhR0q3w9Hzx/Nm8tTORQwOqEo4giPGz1pa0CcHOsszzRmjmB2CFwWAN&#xa;TrOAR7fKKsdaRNcqy4fDSdaCq6wDLrzHv1d9kC4Sfl0LHj7UtReBqJJibyGtLq3LuGaLOZutHLON&#xa;5Ps22D90oZk0WPQAdcUCI2sn/4LSkjvwUIcBB51BXUsuEgdkMxo+YXPbMCsSFxTH24NM/v/B8veb&#xa;j47IqqQ5TsowjTO6/7b7ufux+03uv+9+kTxq1Fo/w9Rbi8mhewkdzjrx9fYG+BdPDFw2zKzEhXPQ&#xa;NoJV2OMo3syOrvY4PoIs23dQYS22DpCAutppUitp3zxAozgE6+DUtodJiS4QHosXJ5OTUwxxjBX5&#xa;dJKPUzE2izhxENb58FqAJnFTUodOSHXY5saH2NdjSkw3cC2VSm5QhrQlPRsj5JOIlgHNqqQu6XQY&#xa;v94+ke4rU6XLgUnV77GAMnv+kXJPPnTLLsldPMi6hGqLgjjovYlvCTcNuDtKWvRlSf3XNXOCEvXW&#xa;oKhno6KIRk6HYnya48EdR5bHEWY4QpU0UNJvL0Myf0/sAsWvZVIjTqnvZN8y+i2JtH8b0dDH55T1&#xa;+IIXfwAAAP//AwBQSwMEFAAGAAgAAAAhAGL8JWHiAAAACwEAAA8AAABkcnMvZG93bnJldi54bWxM&#xa;j8FOwzAQRO9I/IO1SNyo06ghIcSpEBISh4DagFSObuzGUe11FLtt+HuWE9x2d0azb6r17Cw76ykM&#xa;HgUsFwkwjZ1XA/YCPj9e7gpgIUpU0nrUAr51gHV9fVXJUvkLbvW5jT2jEAylFGBiHEvOQ2e0k2Hh&#xa;R42kHfzkZKR16rma5IXCneVpktxzJwekD0aO+tno7tienADV7HZZfhybrflaHV7tu2razZsQtzfz&#xa;0yOwqOf4Z4ZffEKHmpj2/oQqMCsgSwvqEmlYPmTAyJFnqxTYni5FngCvK/6/Q/0DAAD//wMAUEsB&#xa;Ai0AFAAGAAgAAAAhALaDOJL+AAAA4QEAABMAAAAAAAAAAAAAAAAAAAAAAFtDb250ZW50X1R5cGVz&#xa;XS54bWxQSwECLQAUAAYACAAAACEAOP0h/9YAAACUAQAACwAAAAAAAAAAAAAAAAAvAQAAX3JlbHMv&#xa;LnJlbHNQSwECLQAUAAYACAAAACEAXfuLBSUCAAAJBAAADgAAAAAAAAAAAAAAAAAuAgAAZHJzL2Uy&#xa;b0RvYy54bWxQSwECLQAUAAYACAAAACEAYvwlYeIAAAALAQAADwAAAAAAAAAAAAAAAAB/BAAAZHJz&#xa;L2Rvd25yZXYueG1sUEsFBgAAAAAEAAQA8wAAAI4FAAAAAA==&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Mother_FullName %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="006E7BF9">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251682304" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="5059D3A3" wp14:editId="2118ED9B">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>2246630</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>4897755</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1244600" cy="302260"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="2540"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="55" name="مربع نص 55"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1244600" cy="302260"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="0054320A" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Orphan_BondsManRelation %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="5059D3A3" id="مربع نص 55" o:spid="_x0000_s1031" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:176.9pt;margin-top:385.65pt;width:98pt;height:23.8pt;flip:x;z-index:251682304;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQDMU7CuJgIAAAoEAAAOAAAAZHJzL2Uyb0RvYy54bWysU8Fy0zAQvTPDP2h0J3ZMElpPnE5pKTBT&#xa;CjOFD1BkOdYgaYWkxA53+BauHHrgT9K/YSWnaQZuDD5oJO/q7b63T/OzXiuyEc5LMBUdj3JKhOFQ&#xa;S7Oq6KePV89OKPGBmZopMKKiW+Hp2eLpk3lnS1FAC6oWjiCI8WVnK9qGYMss87wVmvkRWGEw2IDT&#xa;LODRrbLasQ7RtcqKPJ9lHbjaOuDCe/x7OQTpIuE3jeDhfdN4EYiqKPYW0urSuoxrtpizcuWYbSXf&#xa;t8H+oQvNpMGiB6hLFhhZO/kXlJbcgYcmjDjoDJpGcpE4IJtx/geb25ZZkbigON4eZPL/D5bfbD44&#xa;IuuKTqeUGKZxRvffdj93P3a/yP333R3B/yhSZ32JubcWs0P/EnocdiLs7TXwz54YuGiZWYlz56Br&#xa;BauxyXG8mR1dHXB8BFl276DGYmwdIAH1jdOkUdK+eYBGdQjWwbFtD6MSfSA8Fi8mk1mOIY6x53lR&#xa;zNIsM1ZGnDgJ63x4LUCTuKmoQyukOmxz7UPs6zElphu4kkolOyhDuoqeTotpunAU0TKgW5XUFT3J&#xa;4zf4J9J9Zep0OTCphj0WUGbPP1IeyId+2Q96P8i6hHqLgjgYzImPCTctuK+UdGjMivova+YEJeqt&#xa;QVFPx5NJdHI6TKYvCjy448jyOMIMR6iKBkqG7UVI7h8on6P4jUxqxCkNnexbRsMlkfaPIzr6+Jyy&#xa;Hp/w4jcAAAD//wMAUEsDBBQABgAIAAAAIQBUf/Hv4wAAAAsBAAAPAAAAZHJzL2Rvd25yZXYueG1s&#xa;TI/BTsMwEETvSPyDtUjcqBPSkDTEqRASEodQ0YBUjm68jaPGdhS7bfh7lhMcd3Y086Zcz2ZgZ5x8&#xa;76yAeBEBQ9s61dtOwOfHy10OzAdplRycRQHf6GFdXV+VslDuYrd4bkLHKMT6QgrQIYwF577VaKRf&#xa;uBEt/Q5uMjLQOXVcTfJC4Wbg91H0wI3sLTVoOeKzxvbYnIwAVe92aXYc663+Wh5eh42qm/c3IW5v&#xa;5qdHYAHn8GeGX3xCh4qY9u5klWeDgCRNCD0IyLI4AUaOdLkiZS8gj/MV8Krk/zdUPwAAAP//AwBQ&#xa;SwECLQAUAAYACAAAACEAtoM4kv4AAADhAQAAEwAAAAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRfVHlw&#xa;ZXNdLnhtbFBLAQItABQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAAAAAAAAAAAAAAC8BAABfcmVs&#xa;cy8ucmVsc1BLAQItABQABgAIAAAAIQDMU7CuJgIAAAoEAAAOAAAAAAAAAAAAAAAAAC4CAABkcnMv&#xa;ZTJvRG9jLnhtbFBLAQItABQABgAIAAAAIQBUf/Hv4wAAAAsBAAAPAAAAAAAAAAAAAAAAAIAEAABk&#xa;cnMvZG93bnJldi54bWxQSwUGAAAAAAQABADzAAAAkAUAAAAA&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="0054320A" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:rtl/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Orphan_BondsManRelation %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="006E7BF9">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251674112" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="54602188" wp14:editId="06F35087">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>1042035</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>4896485</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1202055" cy="302260"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="2540"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="53" name="مربع نص 53"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1202055" cy="302260"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="0054320A" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.BondsMan_Jop %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="54602188" id="مربع نص 53" o:spid="_x0000_s1032" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:82.05pt;margin-top:385.55pt;width:94.65pt;height:23.8pt;flip:x;z-index:251674112;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQDVL1fiKAIAAAoEAAAOAAAAZHJzL2Uyb0RvYy54bWysU81uEzEQviPxDpbvZDfbJLSrbKrSUkAq&#xa;P1LhARyvN2the4ztZDe9w7Nw5cCBN0nfhrE3TSO4IfZg2Tvjb+b75vP8vNeKbITzEkxFx6OcEmE4&#xa;1NKsKvrp4/WzU0p8YKZmCoyo6FZ4er54+mTe2VIU0IKqhSMIYnzZ2Yq2IdgyyzxvhWZ+BFYYDDbg&#xa;NAt4dKusdqxDdK2yIs9nWQeutg648B7/Xg1Bukj4TSN4eN80XgSiKoq9hbS6tC7jmi3mrFw5ZlvJ&#xa;922wf+hCM2mw6AHqigVG1k7+BaUld+ChCSMOOoOmkVwkDshmnP/B5rZlViQuKI63B5n8/4Pl7zYf&#xa;HJF1RacnlBimcUb3X3c/dt93v8j9t91Pgv9RpM76EnNvLWaH/gX0OOxE2Nsb4J89MXDZMrMSF85B&#xa;1wpWY5PjeDM7ujrg+Aiy7N5CjcXYOkAC6hunSaOkff0AjeoQrINj2x5GJfpAeCxe5EU+nVLCMXaS&#xa;F8UszTJjZcSJk7DOh1cCNImbijq0QqrDNjc+xL4eU2K6gWupVLKDMqSr6Nm0mKYLRxEtA7pVSV3R&#xa;0zx+g38i3ZemTpcDk2rYYwFl9vwj5YF86Jd90nv2IOsS6i0K4mAwJz4m3LTg7ijp0JgV9V/WzAlK&#xa;1BuDop6NJ5Po5HSYTJ8XeHDHkeVxhBmOUBUNlAzby5DcP1C+QPEbmdSIUxo62beMhksi7R9HdPTx&#xa;OWU9PuHFbwAAAP//AwBQSwMEFAAGAAgAAAAhANWr7KnhAAAACwEAAA8AAABkcnMvZG93bnJldi54&#xa;bWxMj01Lw0AQhu+C/2EZwZvdxKZNiNkUEQQPUWwU6nGbnWZD9yNkt238944nvc3LPLzzTLWZrWFn&#xa;nMLgnYB0kQBD13k1uF7A58fzXQEsROmUNN6hgG8MsKmvrypZKn9xWzy3sWdU4kIpBegYx5Lz0Gm0&#xa;Miz8iI52Bz9ZGSlOPVeTvFC5Nfw+SdbcysHRBS1HfNLYHduTFaCa3W6VH8dmq7+yw4t5U037/irE&#xa;7c38+AAs4hz/YPjVJ3WoyWnvT04FZiivs5RQAXme0kDEcrXMgO0FFGmRA68r/v+H+gcAAP//AwBQ&#xa;SwECLQAUAAYACAAAACEAtoM4kv4AAADhAQAAEwAAAAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRfVHlw&#xa;ZXNdLnhtbFBLAQItABQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAAAAAAAAAAAAAAC8BAABfcmVs&#xa;cy8ucmVsc1BLAQItABQABgAIAAAAIQDVL1fiKAIAAAoEAAAOAAAAAAAAAAAAAAAAAC4CAABkcnMv&#xa;ZTJvRG9jLnhtbFBLAQItABQABgAIAAAAIQDVq+yp4QAAAAsBAAAPAAAAAAAAAAAAAAAAAIIEAABk&#xa;cnMvZG93bnJldi54bWxQSwUGAAAAAAQABADzAAAAkAUAAAAA&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="0054320A" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.BondsMan_Jop %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="006E7BF9">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251678208" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="3F64F0A8" wp14:editId="1E713DEA">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>-243205</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>4896485</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1214755" cy="302260"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="2540"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="54" name="مربع نص 54"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1214755" cy="302260"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="0054320A" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.BondsMan_Salary %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="3F64F0A8" id="مربع نص 54" o:spid="_x0000_s1033" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:-19.15pt;margin-top:385.55pt;width:95.65pt;height:23.8pt;flip:x;z-index:251678208;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQDjwKs+KAIAAAoEAAAOAAAAZHJzL2Uyb0RvYy54bWysU81uEzEQviPxDpbvZDdLtmmjbKrSUkAq&#xa;P1LhARyvN2the4ztZDe9w7Nw5cCBN0nfhrE3TSO4IfZg2Tvjb+b75vP8vNeKbITzEkxFx6OcEmE4&#xa;1NKsKvrp4/WzU0p8YKZmCoyo6FZ4er54+mTe2ZkooAVVC0cQxPhZZyvahmBnWeZ5KzTzI7DCYLAB&#xa;p1nAo1tltWMdomuVFXl+knXgauuAC+/x79UQpIuE3zSCh/dN40UgqqLYW0irS+syrtlizmYrx2wr&#xa;+b4N9g9daCYNFj1AXbHAyNrJv6C05A48NGHEQWfQNJKLxAHZjPM/2Ny2zIrEBcXx9iCT/3+w/N3m&#xa;gyOyrmg5ocQwjTO6/7r7sfu++0Xuv+1+EvyPInXWzzD31mJ26F9Aj8NOhL29Af7ZEwOXLTMrceEc&#xa;dK1gNTY5jjezo6sDjo8gy+4t1FiMrQMkoL5xmjRK2tcP0KgOwTo4tu1hVKIPhMfixXgyLUtKOMae&#xa;50VxkmaZsVnEiZOwzodXAjSJm4o6tEKqwzY3PsS+HlNiuoFrqVSygzKkq+hZWZTpwlFEy4BuVVJX&#xa;9DSP3+CfSPelqdPlwKQa9lhAmT3/SHkgH/pln/SePsi6hHqLgjgYzImPCTctuDtKOjRmRf2XNXOC&#xa;EvXGoKhn48kkOjkdJuW0wIM7jiyPI8xwhKpooGTYXobk/oHyBYrfyKRGnNLQyb5lNFwSaf84oqOP&#xa;zynr8QkvfgMAAP//AwBQSwMEFAAGAAgAAAAhABqdBWziAAAACwEAAA8AAABkcnMvZG93bnJldi54&#xa;bWxMj1FLwzAUhd8F/0O4gm9bWutsqb0dIgg+VHFVmI9ZkzVlyU1psq3+e7Mnfbzcj3O+U61na9hJ&#xa;TX5whJAuE2CKOicH6hG+Pl8WBTAfBElhHCmEH+VhXV9fVaKU7kwbdWpDz2II+VIg6BDGknPfaWWF&#xa;X7pRUfzt3WRFiOfUczmJcwy3ht8lyQO3YqDYoMWonrXqDu3RIshmu13lh7HZ6O/7/at5l0378YZ4&#xa;ezM/PQILag5/MFz0ozrU0WnnjiQ9MwiLrMgiipDnaQrsQqyyuG6HUKRFDryu+P8N9S8AAAD//wMA&#xa;UEsBAi0AFAAGAAgAAAAhALaDOJL+AAAA4QEAABMAAAAAAAAAAAAAAAAAAAAAAFtDb250ZW50X1R5&#xa;cGVzXS54bWxQSwECLQAUAAYACAAAACEAOP0h/9YAAACUAQAACwAAAAAAAAAAAAAAAAAvAQAAX3Jl&#xa;bHMvLnJlbHNQSwECLQAUAAYACAAAACEA48CrPigCAAAKBAAADgAAAAAAAAAAAAAAAAAuAgAAZHJz&#xa;L2Uyb0RvYy54bWxQSwECLQAUAAYACAAAACEAGp0FbOIAAAALAQAADwAAAAAAAAAAAAAAAACCBAAA&#xa;ZHJzL2Rvd25yZXYueG1sUEsFBgAAAAAEAAQA8wAAAJEFAAAAAA==&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="0054320A" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:rtl/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.BondsMan_Salary %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="006E7BF9">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251649536" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="79610E86" wp14:editId="1B7726B0">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>-257175</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>3946526</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1268730" cy="248920"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="37" name="مربع نص 37"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1268730" cy="248920"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                           <w:t><%= Mother_Married %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="79610E86" id="مربع نص 37" o:spid="_x0000_s1034" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:-20.25pt;margin-top:310.75pt;width:99.9pt;height:19.6pt;flip:x;z-index:251649536;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQCiB5ipKAIAAAoEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNG223bZR09WyywLS&#xa;8iMtPIDrOI2F7TG226Tc4Vm4cuDAm3TfhrHT7VZwQ+Rg2ZnxN/N983lx0WlFtsJ5Caako8GQEmE4&#xa;VNKsS/rxw82zGSU+MFMxBUaUdCc8vVg+fbJobSFyaEBVwhEEMb5obUmbEGyRZZ43QjM/ACsMBmtw&#xa;mgU8unVWOdYiulZZPhyeZy24yjrgwnv8e90H6TLh17Xg4V1dexGIKin2FtLq0rqKa7ZcsGLtmG0k&#xa;P7TB/qELzaTBokeoaxYY2Tj5F5SW3IGHOgw46AzqWnKROCCb0fAPNncNsyJxQXG8Pcrk/x8sf7t9&#xa;74isSno2pcQwjTO6/7r/sf++/0Xuv+1/EvyPIrXWF5h7ZzE7dM+hw2Enwt7eAv/kiYGrhpm1uHQO&#xa;2kawCpscxZvZydUex0eQVfsGKizGNgESUFc7TWol7asHaFSHYB0c2+44KtEFwmPx/Hw2PcMQx1g+&#xa;ns3zNMuMFREnTsI6H14K0CRuSurQCqkO2976EPt6TInpBm6kUskOypC2pPNJPkkXTiJaBnSrkrqk&#xa;s2H8ev9Eui9MlS4HJlW/xwLKHPhHyj350K26pPfsQdYVVDsUxEFvTnxMuGnAfaGkRWOW1H/eMCco&#xa;Ua8NijofjcfRyekwnkyROHGnkdVphBmOUCUNlPTbq5Dc31O+RPFrmdSIU+o7ObSMhksiHR5HdPTp&#xa;OWU9PuHlbwAAAP//AwBQSwMEFAAGAAgAAAAhAJyotsHiAAAACwEAAA8AAABkcnMvZG93bnJldi54&#xa;bWxMj8tOwzAQRfdI/IM1SOxau6VJIcSpEBISi4BoWqks3XgaR43tKHbb8PdMV7Cbx9GdM/lqtB07&#xa;4xBa7yTMpgIYutrr1jUStpu3ySOwEJXTqvMOJfxggFVxe5OrTPuLW+O5ig2jEBcyJcHE2Gech9qg&#xa;VWHqe3S0O/jBqkjt0HA9qAuF247PhUi5Va2jC0b1+GqwPlYnK0GXu12yPPbl2nwvDu/dpy6rrw8p&#xa;7+/Gl2dgEcf4B8NVn9ShIKe9PzkdWCdhshAJoRLS+YyKK5E8PQDb0yQVS+BFzv//UPwCAAD//wMA&#xa;UEsBAi0AFAAGAAgAAAAhALaDOJL+AAAA4QEAABMAAAAAAAAAAAAAAAAAAAAAAFtDb250ZW50X1R5&#xa;cGVzXS54bWxQSwECLQAUAAYACAAAACEAOP0h/9YAAACUAQAACwAAAAAAAAAAAAAAAAAvAQAAX3Jl&#xa;bHMvLnJlbHNQSwECLQAUAAYACAAAACEAogeYqSgCAAAKBAAADgAAAAAAAAAAAAAAAAAuAgAAZHJz&#xa;L2Uyb0RvYy54bWxQSwECLQAUAAYACAAAACEAnKi2weIAAAALAQAADwAAAAAAAAAAAAAAAACCBAAA&#xa;ZHJzL2Rvd25yZXYueG1sUEsFBgAAAAAEAAQA8wAAAJEFAAAAAA==&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                               <w:t><%= Mother_Married %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="006E7BF9">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251657728" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="4513F917" wp14:editId="2A47C850">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>986155</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>3945890</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1268730" cy="248920"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="39" name="مربع نص 39"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1268730" cy="248920"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Mother_Married %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="4513F917" id="مربع نص 39" o:spid="_x0000_s1035" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:77.65pt;margin-top:310.7pt;width:99.9pt;height:19.6pt;flip:x;z-index:251657728;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQAkG7jsJwIAAAoEAAAOAAAAZHJzL2Uyb0RvYy54bWysU81uEzEQviPxDpbvZJNt0iarbKrSUkAq&#xa;P1LhARyvN2the4ztZDe9w7Nw7aEH3iR9G8bekEZwQ+zBsnfG38z3zef5eacV2QjnJZiSjgZDSoTh&#xa;UEmzKunnT9cvppT4wEzFFBhR0q3w9Hzx/Nm8tYXIoQFVCUcQxPiitSVtQrBFlnneCM38AKwwGKzB&#xa;aRbw6FZZ5ViL6Fpl+XB4mrXgKuuAC+/x71UfpIuEX9eChw917UUgqqTYW0irS+syrtlizoqVY7aR&#xa;fN8G+4cuNJMGix6grlhgZO3kX1Bacgce6jDgoDOoa8lF4oBsRsM/2Nw2zIrEBcXx9iCT/3+w/P3m&#xa;oyOyKunJjBLDNM7o8dvufvdj95M8ft89EPyPIrXWF5h7azE7dC+hw2Enwt7eAP/iiYHLhpmVuHAO&#xa;2kawCpscxZvZ0dUex0eQZfsOKizG1gESUFc7TWol7Zvf0KgOwTo4tu1hVKILhMfi+en07ARDHGP5&#xa;eDrL0ywzVkScOAnrfHgtQJO4KalDK6Q6bHPjQ+zrKSWmG7iWSiU7KEPaks4m+SRdOIpoGdCtSuqS&#xa;Tofx6/0T6b4yVbocmFT9Hgsos+cfKffkQ7fskt4HWZdQbVEQB7058THhpgF3R0mLxiyp/7pmTlCi&#xa;3hoUdTYaj6OT02E8OUPixB1HlscRZjhClTRQ0m8vQ3J/T/kCxa9lUiNOqe9k3zIaLom0fxzR0cfn&#xa;lPX0hBe/AAAA//8DAFBLAwQUAAYACAAAACEAmyeA6eIAAAALAQAADwAAAGRycy9kb3ducmV2Lnht&#xa;bEyPwU7DMAyG70i8Q2QkbizttpapNJ0QEhKHgraCtB2zJmuqJU7VZFt5e8wJjr/96ffncj05yy56&#xa;DL1HAeksAaax9arHTsDX5+vDCliIEpW0HrWAbx1gXd3elLJQ/opbfWlix6gEQyEFmBiHgvPQGu1k&#xa;mPlBI+2OfnQyUhw7rkZ5pXJn+TxJcu5kj3TByEG/GN2emrMToOrdLns8DfXW7JfHN/uh6mbzLsT9&#xa;3fT8BCzqKf7B8KtP6lCR08GfUQVmKWfZglAB+TxdAiNikWUpsANN8iQHXpX8/w/VDwAAAP//AwBQ&#xa;SwECLQAUAAYACAAAACEAtoM4kv4AAADhAQAAEwAAAAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRfVHlw&#xa;ZXNdLnhtbFBLAQItABQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAAAAAAAAAAAAAAC8BAABfcmVs&#xa;cy8ucmVsc1BLAQItABQABgAIAAAAIQAkG7jsJwIAAAoEAAAOAAAAAAAAAAAAAAAAAC4CAABkcnMv&#xa;ZTJvRG9jLnhtbFBLAQItABQABgAIAAAAIQCbJ4Dp4gAAAAsBAAAPAAAAAAAAAAAAAAAAAIEEAABk&#xa;cnMvZG93bnJldi54bWxQSwUGAAAAAAQABADzAAAAkAUAAAAA&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:rtl/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Mother_IsOwnOthersOrphans %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="006E7BF9">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251653632" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="1EDC808D" wp14:editId="0C3C72C0">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>2293620</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>3945890</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1192530" cy="248920"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="38" name="مربع نص 38"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1192530" cy="248920"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                               <a:effectLst>
                                                                   <a:softEdge rad="0"/>
                                                               </a:effectLst>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Mother_IsOwnOthersOrphans %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="1EDC808D" id="مربع نص 38" o:spid="_x0000_s1036" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:180.6pt;margin-top:310.7pt;width:93.9pt;height:19.6pt;flip:x;z-index:251653632;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQC2govWOwIAADsEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNE22hTZqulr2B5CW&#xa;H2nhAVzHaSwcj7HdJt07PAtXDhx4k+7bMHa6bQQ3RA6WnZn5Zub7ZhbnXaPIVlgnQRc0HY0pEZpD&#xa;KfW6oJ8+3jybUeI80yVToEVBd8LR8+XTJ4vW5CKDGlQpLEEQ7fLWFLT23uRJ4ngtGuZGYIRGYwW2&#xa;YR6fdp2UlrWI3qgkG4+fJy3Y0ljgwjn8e9Ub6TLiV5Xg/n1VOeGJKijW5uNp47kKZ7JcsHxtmakl&#xa;P5TB/qGKhkmNSY9QV8wzsrHyL6hGcgsOKj/i0CRQVZKL2AN2k47/6OauZkbEXpAcZ440uf8Hy99t&#xa;P1giy4KeoVKaNajRw9f9j/33/S/y8G3/k+B/JKk1LkffO4PevnsJHYodG3bmFvhnRzRc1kyvxYW1&#xa;0NaClVhkGiKTQWiP4wLIqn0LJSZjGw8RqKtsQyolzetHaGSHYB6UbXeUSnSe8JA8nWfTMzRxtGWT&#xa;2TyLWiYsDzhBCWOdfyWgIeFSUIujEPOw7a3zoa6TS3DXcCOViuOgNGkLOp9m0xgwsDTS47Qq2RR0&#xa;Ng5fPz+h3WtdxmDPpOrvmEDpAC3iHGLW8AjaX5drQSxD0h+LHrhEvgJFPVm+W3VRnzT6BjJXUO6Q&#xa;QQv9NOP24aUGe09Ji5NcUPdlw6ygRL3RqMI8nUzC6MfHZPoCmSJ2aFkNLUxzhCqop6S/Xvq4Lj1H&#xa;F6hWJSN9p0oOGuOERlYP2xRWYPiOXqedX/4GAAD//wMAUEsDBBQABgAIAAAAIQBeMfiJ4gAAAAsB&#xa;AAAPAAAAZHJzL2Rvd25yZXYueG1sTI/BTsMwDIbvSLxDZCRuLG3pCpSmE0JC4lAmVpDGMWuyplri&#xa;VE22lbfHnOBo+9Pv769Ws7PspKcweBSQLhJgGjuvBuwFfH683NwDC1GiktajFvCtA6zqy4tKlsqf&#xa;caNPbewZhWAopQAT41hyHjqjnQwLP2qk295PTkYap56rSZ4p3FmeJUnBnRyQPhg56meju0N7dAJU&#xa;s90u7w5jszFf+f7VrlXTvr8JcX01Pz0Ci3qOfzD86pM61OS080dUgVkBt0WaESqgyNIcGBHL/IHa&#xa;7WhTJAXwuuL/O9Q/AAAA//8DAFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAAAAAAAAA&#xa;AAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9If/WAAAAlAEAAAsA&#xa;AAAAAAAAAAAAAAAALwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhALaCi9Y7AgAAOwQAAA4A&#xa;AAAAAAAAAAAAAAAALgIAAGRycy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAhAF4x+IniAAAACwEA&#xa;AA8AAAAAAAAAAAAAAAAAlQQAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAEAPMAAACkBQAAAAA=&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Mother_OwnOrphans %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="006E7BF9">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251622912" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="44BCA0D0" wp14:editId="13722421">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>986790</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>871855</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1249045" cy="295275"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="11" name="مربع نص 11"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1249045" cy="295275"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00C91656">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Orphan_BirthPlaceANDKaid %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="44BCA0D0" id="مربع نص 11" o:spid="_x0000_s1037" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:77.7pt;margin-top:68.65pt;width:98.35pt;height:23.25pt;flip:x;z-index:251622912;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQBwPfNdJgIAAAsEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNGnUstuo6WrZZQFp&#xa;+ZEWHsB1nMbC9hjbbVLuy7Nw5cCBN+m+DWOn7VZwQ+Rg2ZmZb+b7/Hl+0WtFNsJ5Caai41FOiTAc&#xa;amlWFf308ebZOSU+MFMzBUZUdCs8vVg8fTLvbCkKaEHVwhEEMb7sbEXbEGyZZZ63QjM/AisMBhtw&#xa;mgU8ulVWO9YhulZZkefPsw5cbR1w4T3+vR6CdJHwm0bw8L5pvAhEVRRnC2l1aV3GNVvMWblyzLaS&#xa;78dg/zCFZtJg0yPUNQuMrJ38C0pL7sBDE0YcdAZNI7lIHJDNOP+DzV3LrEhcUBxvjzL5/wfL320+&#xa;OCJrvLsxJYZpvKOH+92P3ffdL/LwbfeT4H8UqbO+xNw7i9mhfwE9FiTC3t4C/+yJgauWmZW4dA66&#xa;VrAah0yV2UnpgOMjyLJ7CzU2Y+sACahvnCaNkvb1ARrVIdgHr217vCrRB8Jj82IyyydTSjjGitm0&#xa;OJvGMTNWRpx4E9b58EqAJnFTUYdWSH3Y5taHIfWQEtMN3Eilkh2UIV1FEXOaCk4iWgZ0q5K6oud5&#xa;/Ab/RLovTZ2KA5Nq2OMsyuBIkX+kPJAP/bI/6I0FMbiEeouKOBjcia8JNy24r5R06MyK+i9r5gQl&#xa;6o1BVWfjySRaOR0m07MCD+40sjyNMMMRqqKBkmF7FZL9B86XqH4jkxyPk+xnRsclQfevI1r69Jyy&#xa;Ht/w4jcAAAD//wMAUEsDBBQABgAIAAAAIQDdEn8p4gAAAAsBAAAPAAAAZHJzL2Rvd25yZXYueG1s&#xa;TI9PS8NAEMXvgt9hGcGb3bRpbIjZFBEED1FsFOpxm51mQ/dPyG7b+O07Pelt3szjze+V68kadsIx&#xa;9N4JmM8SYOhar3rXCfj+en3IgYUonZLGOxTwiwHW1e1NKQvlz26DpyZ2jEJcKKQAHeNQcB5ajVaG&#xa;mR/Q0W3vRysjybHjapRnCreGL5LkkVvZO/qg5YAvGttDc7QCVL3dZqvDUG/0z3L/Zj5U3Xy+C3F/&#xa;Nz0/AYs4xT8zXPEJHSpi2vmjU4EZ0lm2JCsN6SoFRo40W8yB7WiTpznwquT/O1QXAAAA//8DAFBL&#xa;AQItABQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBl&#xa;c10ueG1sUEsBAi0AFAAGAAgAAAAhADj9If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxz&#xa;Ly5yZWxzUEsBAi0AFAAGAAgAAAAhAHA9810mAgAACwQAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9l&#xa;Mm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAhAN0SfyniAAAACwEAAA8AAAAAAAAAAAAAAAAAgAQAAGRy&#xa;cy9kb3ducmV2LnhtbFBLBQYAAAAABAAEAPMAAACPBQAAAAA=&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00C91656">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Orphan_BirthPlaceANDKaid %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="006E7BF9">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251629056" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="1CE0D44A" wp14:editId="783CED9A">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>2266315</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>1506220</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1221105" cy="285750"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="20" name="مربع نص 2"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1221105" cy="285750"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Orphan_bailed %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="1CE0D44A" id="_x0000_s1038" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:178.45pt;margin-top:118.6pt;width:96.15pt;height:22.5pt;flip:x;z-index:251629056;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQDdMak2JQIAAAoEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNE3UsN2o6WrZZQFp&#xa;+ZEWHsB1nMbC9hjbbVLu8CxcOXDgTbpvw9gp3QpuiBwsOzP+Zr5vPi8uBq3IVjgvwdQ0n0wpEYZD&#xa;I826ph/e3zyZU+IDMw1TYERNd8LTi+XjR4veVqKADlQjHEEQ46ve1rQLwVZZ5nknNPMTsMJgsAWn&#xa;WcCjW2eNYz2ia5UV0+nTrAfXWAdceI9/r8cgXSb8thU8vG1bLwJRNcXeQlpdWldxzZYLVq0ds53k&#xa;hzbYP3ShmTRY9Ah1zQIjGyf/gtKSO/DQhgkHnUHbSi4SB2STT/9gc9cxKxIXFMfbo0z+/8HyN9t3&#xa;jsimpgXKY5jGGd1/2X/ff9v/JPdf9z9IETXqra8w9c5ichiewYCzTny9vQX+0RMDVx0za3HpHPSd&#xa;YA32mMeb2cnVEcdHkFX/GhqsxTYBEtDQOk1aJe3L39AoDsE62NbuOCkxBMJj8aLI82lJCcdYMS/P&#xa;yjTKjFURJw7COh9eCNAkbmrq0AmpDtve+hD7ekiJ6QZupFLJDcqQvqbnZVGmCycRLQOaVUld0/k0&#xa;fqN9It3npkmXA5Nq3GMBZQ78I+WRfBhWQ5I7P+q6gmaHijgYzYmPCTcduM+U9GjMmvpPG+YEJeqV&#xa;QVXP89ksOjkdZuVZnJs7jaxOI8xwhKppoGTcXoXk/pHzJarfyiRHHNPYyaFnNFxS6fA4oqNPzynr&#xa;4QkvfwEAAP//AwBQSwMEFAAGAAgAAAAhAHNmedziAAAACwEAAA8AAABkcnMvZG93bnJldi54bWxM&#xa;j8tOwzAQRfdI/IM1SOyog9v0EeJUCAmJRYpoQCpLN54mUf2IYrcNf99hBbt5HN05k69Ha9gZh9B5&#xa;J+FxkgBDV3vduUbC1+frwxJYiMppZbxDCT8YYF3c3uQq0/7itniuYsMoxIVMSWhj7DPOQ92iVWHi&#xa;e3S0O/jBqkjt0HA9qAuFW8NFksy5VZ2jC63q8aXF+lidrARd7nbp4tiX2/Z7dngz77qsPjZS3t+N&#xa;z0/AIo7xD4ZffVKHgpz2/uR0YEbCNJ2vCJUgpgsBjIh0tqJiT5OlEMCLnP//obgCAAD//wMAUEsB&#xa;Ai0AFAAGAAgAAAAhALaDOJL+AAAA4QEAABMAAAAAAAAAAAAAAAAAAAAAAFtDb250ZW50X1R5cGVz&#xa;XS54bWxQSwECLQAUAAYACAAAACEAOP0h/9YAAACUAQAACwAAAAAAAAAAAAAAAAAvAQAAX3JlbHMv&#xa;LnJlbHNQSwECLQAUAAYACAAAACEA3TGpNiUCAAAKBAAADgAAAAAAAAAAAAAAAAAuAgAAZHJzL2Uy&#xa;b0RvYy54bWxQSwECLQAUAAYACAAAACEAc2Z53OIAAAALAQAADwAAAAAAAAAAAAAAAAB/BAAAZHJz&#xa;L2Rvd25yZXYueG1sUEsFBgAAAAAEAAQA8wAAAI4FAAAAAA==&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Orphan_bailed %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="006E7BF9">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251619840" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="54741B2A" wp14:editId="0542FB98">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>3522345</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>1500505</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1207770" cy="295275"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="10" name="مربع نص 10"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1207770" cy="295275"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00C91656">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Orphan_Age %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="54741B2A" id="مربع نص 10" o:spid="_x0000_s1039" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:277.35pt;margin-top:118.15pt;width:95.1pt;height:23.25pt;flip:x;z-index:251619840;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQC4yeZYJAIAAAsEAAAOAAAAZHJzL2Uyb0RvYy54bWysU8Fy0zAQvTPDP2h0J3ZMQlpPnE5pKTBT&#xa;CjOFD1BkOdYgaYWkxA53+BauHHrgT9K/YSWnaQZuDD5oJO/u231PT/OzXiuyEc5LMBUdj3JKhOFQ&#xa;S7Oq6KePV89OKPGBmZopMKKiW+Hp2eLpk3lnS1FAC6oWjiCI8WVnK9qGYMss87wVmvkRWGEw2IDT&#xa;LODRrbLasQ7RtcqKPH+RdeBq64AL7/Hv5RCki4TfNIKH903jRSCqojhbSKtL6zKu2WLOypVjtpV8&#xa;Pwb7hyk0kwabHqAuWWBk7eRfUFpyBx6aMOKgM2gayUXigGzG+R9sbltmReKC4nh7kMn/P1h+s/ng&#xa;iKzx7lAewzTe0f233c/dj90vcv99d0fwP4rUWV9i7q3F7NC/hB4LEmFvr4F/9sTARcvMSpw7B10r&#xa;WI1DjmNldlQ64PgIsuzeQY3N2DpAAuobp0mjpH3zAI3qEOyDc20PVyX6QHhsXuSz2QxDHGPF6bSY&#xa;TVMzVkaceBPW+fBagCZxU1GHVkh92ObahzjXY0pMN3AllUp2UIZ0FUXMaSo4imgZ0K1K6oqe5PEb&#xa;/BPpvjJ1Kg5MqmGPDZTZ84+UB/KhX/aD3s8fdF1CvUVFHAzuxNeEmxbcV0o6dGZF/Zc1c4IS9dag&#xa;qqfjySRaOR0m01mBB3ccWR5HmOEIVdFAybC9CMn+A+dzVL+RSY54TcMk+5nRcUml/euIlj4+p6zH&#xa;N7z4DQAA//8DAFBLAwQUAAYACAAAACEA06C18OMAAAALAQAADwAAAGRycy9kb3ducmV2LnhtbEyP&#xa;wU7DMAyG70i8Q2Qkbiyla9dSmk4ICYlDmVhBGses8ZpqjVM12VbennCCo+1Pv7+/XM9mYGecXG9J&#xa;wP0iAobUWtVTJ+Dz4+UuB+a8JCUHSyjgGx2sq+urUhbKXmiL58Z3LISQK6QA7f1YcO5ajUa6hR2R&#xa;wu1gJyN9GKeOq0leQrgZeBxFK25kT+GDliM+a2yPzckIUPVul2bHsd7qr+TwOmxU3by/CXF7Mz89&#xa;AvM4+z8YfvWDOlTBaW9PpBwbBKRpkgVUQLxcLYEFIkuSB2D7sMnjHHhV8v8dqh8AAAD//wMAUEsB&#xa;Ai0AFAAGAAgAAAAhALaDOJL+AAAA4QEAABMAAAAAAAAAAAAAAAAAAAAAAFtDb250ZW50X1R5cGVz&#xa;XS54bWxQSwECLQAUAAYACAAAACEAOP0h/9YAAACUAQAACwAAAAAAAAAAAAAAAAAvAQAAX3JlbHMv&#xa;LnJlbHNQSwECLQAUAAYACAAAACEAuMnmWCQCAAALBAAADgAAAAAAAAAAAAAAAAAuAgAAZHJzL2Uy&#xa;b0RvYy54bWxQSwECLQAUAAYACAAAACEA06C18OMAAAALAQAADwAAAAAAAAAAAAAAAAB+BAAAZHJz&#xa;L2Rvd25yZXYueG1sUEsFBgAAAAAEAAQA8wAAAI4FAAAAAA==&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00C91656">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:rtl/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Orphan_Age %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00041588">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <w:drawing>
                                   <wp:anchor distT="0" distB="0" distL="114300" distR="114300" simplePos="0" relativeHeight="251697664" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="75BAA7D1" wp14:editId="14C50692">
                                       <wp:simplePos x="0" y="0"/>
                                       <wp:positionH relativeFrom="column">
                                           <wp:posOffset>4959184</wp:posOffset>
                                       </wp:positionH>
                                       <wp:positionV relativeFrom="paragraph">
                                           <wp:posOffset>12700</wp:posOffset>
                                       </wp:positionV>
                                       <wp:extent cx="1955800" cy="2042795"/>
                                       <wp:effectExtent l="19050" t="0" r="25400" b="605155"/>
                                       <wp:wrapNone/>
                                       <wp:docPr id="204" name="صورة 204"/>
                                       <wp:cNvGraphicFramePr>
                                           <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" noChangeAspect="1"/>
                                       </wp:cNvGraphicFramePr>
                                       <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                           <a:graphicData uri="http://schemas.openxmlformats.org/drawingml/2006/picture">
                                               <pic:pic xmlns:pic="http://schemas.openxmlformats.org/drawingml/2006/picture">
                                                   <pic:nvPicPr>
                                                       <pic:cNvPr id="204" name="NoImage.png"/>
                                                       <pic:cNvPicPr/>
                                                   </pic:nvPicPr>
                                                   <pic:blipFill>
                                                       <a:blip r:embed="rId8">
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
                                                           <a:ext cx="1955800" cy="2042795"/>
                                                       </a:xfrm>
                                                       <a:prstGeom prst="roundRect">
                                                           <a:avLst>
                                                               <a:gd name="adj" fmla="val 8594"/>
                                                           </a:avLst>
                                                       </a:prstGeom>
                                                       <a:solidFill>
                                                           <a:srgbClr val="FFFFFF">
                                                               <a:shade val="85000"/>
                                                           </a:srgbClr>
                                                       </a:solidFill>
                                                       <a:ln>
                                                           <a:noFill/>
                                                       </a:ln>
                                                       <a:effectLst>
                                                           <a:reflection blurRad="12700" stA="38000" endPos="28000" dist="5000" dir="5400000" sy="-100000" algn="bl" rotWithShape="0"/>
                                                       </a:effectLst>
                                                   </pic:spPr>
                                               </pic:pic>
                                           </a:graphicData>
                                       </a:graphic>
                                       <wp14:sizeRelH relativeFrom="margin">
                                           <wp14:pctWidth>0</wp14:pctWidth>
                                       </wp14:sizeRelH>
                                       <wp14:sizeRelV relativeFrom="margin">
                                           <wp14:pctHeight>0</wp14:pctHeight>
                                       </wp14:sizeRelV>
                                   </wp:anchor>
                               </w:drawing>
                           </w:r>
                           <w:r w:rsidR="00226F49">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251659776" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="6599DC70" wp14:editId="5AAAA6E0">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>3504565</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>5951220</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1221105" cy="278130"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="44" name="مربع نص 2"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1221105" cy="278130"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Family_CardNumber %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="6599DC70" id="_x0000_s1040" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:275.95pt;margin-top:468.6pt;width:96.15pt;height:21.9pt;flip:x;z-index:251659776;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQBy7H65JwIAAAoEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNE1I2W7UdLXssoC0&#xa;/EgLD+A6TmNhe4ztNlnu8CxcOXDgTbpvw9jpdiu4IXKw7Mz4m/m++bw4G7QiW+G8BFPTfDKlRBgO&#xa;jTTrmn78cPVkTokPzDRMgRE1vRWeni0fP1r0thIFdKAa4QiCGF/1tqZdCLbKMs87oZmfgBUGgy04&#xa;zQIe3TprHOsRXausmE6fZT24xjrgwnv8ezkG6TLht63g4V3behGIqin2FtLq0rqKa7ZcsGrtmO0k&#xa;37fB/qELzaTBogeoSxYY2Tj5F5SW3IGHNkw46AzaVnKROCCbfPoHm5uOWZG4oDjeHmTy/w+Wv92+&#xa;d0Q2NS1LSgzTOKO7r7sfu++7X+Tu2+4nKaJGvfUVpt5YTA7Dcxhw1omvt9fAP3li4KJjZi3OnYO+&#xa;E6zBHvN4Mzu6OuL4CLLq30CDtdgmQAIaWqdJq6R9dQ+N4hCsg1O7PUxKDIHwWLwo8nw6o4RjrDiZ&#xa;50/TKDNWRZw4COt8eClAk7ipqUMnpDpse+1D7OshJaYbuJJKJTcoQ/qans6KWbpwFNEyoFmV1DWd&#xa;T+M32ifSfWGadDkwqcY9FlBmzz9SHsmHYTUkufPyXtcVNLeoiIPRnPiYcNOB+0JJj8asqf+8YU5Q&#xa;ol4bVPU0L8vo5HQoZycFHtxxZHUcYYYjVE0DJeP2IiT3j5zPUf1WJjnimMZO9j2j4ZJK+8cRHX18&#xa;TlkPT3j5GwAA//8DAFBLAwQUAAYACAAAACEAGODGAOMAAAALAQAADwAAAGRycy9kb3ducmV2Lnht&#xa;bEyPy07DMBBF90j8gzVI7KiTkpA2xKkQEhKLUNFQqV26sRtHjcdR7Lbh7xlWsJvH0Z0zxWqyPbvo&#xa;0XcOBcSzCJjGxqkOWwHbr7eHBTAfJCrZO9QCvrWHVXl7U8hcuStu9KUOLaMQ9LkUYEIYcs59Y7SV&#xa;fuYGjbQ7utHKQO3YcjXKK4Xbns+j6Ilb2SFdMHLQr0Y3p/psBahqt0uz01BtzD45vvdrVdWfH0Lc&#xa;300vz8CCnsIfDL/6pA4lOR3cGZVnvYA0jZeEClg+ZnNgRGRJQsWBJos4Al4W/P8P5Q8AAAD//wMA&#xa;UEsBAi0AFAAGAAgAAAAhALaDOJL+AAAA4QEAABMAAAAAAAAAAAAAAAAAAAAAAFtDb250ZW50X1R5&#xa;cGVzXS54bWxQSwECLQAUAAYACAAAACEAOP0h/9YAAACUAQAACwAAAAAAAAAAAAAAAAAvAQAAX3Jl&#xa;bHMvLnJlbHNQSwECLQAUAAYACAAAACEAcux+uScCAAAKBAAADgAAAAAAAAAAAAAAAAAuAgAAZHJz&#xa;L2Uyb0RvYy54bWxQSwECLQAUAAYACAAAACEAGODGAOMAAAALAQAADwAAAAAAAAAAAAAAAACBBAAA&#xa;ZHJzL2Rvd25yZXYueG1sUEsFBgAAAAAEAAQA8wAAAJEFAAAAAA==&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:rtl/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Family_CardNumber %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00226F49">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251665920" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="5FD0D8AF" wp14:editId="6A158E55">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>-287020</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>5950585</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1286510" cy="278130"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="47" name="مربع نص 47"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1286510" cy="278130"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Family_ResidenceState %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="5FD0D8AF" id="مربع نص 47" o:spid="_x0000_s1041" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:-22.6pt;margin-top:468.55pt;width:101.3pt;height:21.9pt;flip:x;z-index:251665920;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQBycV+VKAIAAAsEAAAOAAAAZHJzL2Uyb0RvYy54bWysU81uEzEQviPxDpbvZLNL0qarbKrSUkAq&#xa;P1LhARyvN2the4ztZDe9w7Nw5cCBN0nfhrE3TSO4IfZg2Tvjb+b75vP8vNeKbITzEkxF89GYEmE4&#xa;1NKsKvrp4/WzGSU+MFMzBUZUdCs8PV88fTLvbCkKaEHVwhEEMb7sbEXbEGyZZZ63QjM/AisMBhtw&#xa;mgU8ulVWO9YhulZZMR6fZB242jrgwnv8ezUE6SLhN43g4X3TeBGIqij2FtLq0rqMa7aYs3LlmG0l&#xa;37fB/qELzaTBogeoKxYYWTv5F5SW3IGHJow46AyaRnKROCCbfPwHm9uWWZG4oDjeHmTy/w+Wv9t8&#xa;cETWFZ2cUmKYxhndf9392H3f/SL333Y/Cf5HkTrrS8y9tZgd+hfQ47ATYW9vgH/2xMBly8xKXDgH&#xa;XStYjU3m8WZ2dHXA8RFk2b2FGouxdYAE1DdOk0ZJ+/oBGtUhWAfHtj2MSvSB8Fi8mJ1McwxxjBWn&#xa;s/x5mmXGyogTJ2GdD68EaBI3FXVohVSHbW58iH09psR0A9dSqWQHZUhX0bNpMU0XjiJaBnSrkrqi&#xa;s3H8Bv9Eui9NnS4HJtWwxwLK7PlHygP50C/7pHc+fdB1CfUWFXEwuBNfE25acHeUdOjMivova+YE&#xa;JeqNQVXP8skkWjkdJtPTAg/uOLI8jjDDEaqigZJhexmS/QfOF6h+I5MccUxDJ/ue0XFJpf3riJY+&#xa;Pqesxze8+A0AAP//AwBQSwMEFAAGAAgAAAAhAOqHj+njAAAACwEAAA8AAABkcnMvZG93bnJldi54&#xa;bWxMj8FuwjAMhu+T9g6RJ+0GKaxdoWuKpkmTdujQ6JDgGBrTViRO1QTo3n7htB1tf/r9/flqNJpd&#xa;cHCdJQGzaQQMqbaqo0bA9vt9sgDmvCQltSUU8IMOVsX9XS4zZa+0wUvlGxZCyGVSQOt9n3Hu6haN&#xa;dFPbI4Xb0Q5G+jAODVeDvIZwo/k8ip65kR2FD63s8a3F+lSdjQBV7nZJeurLTbuPjx96rcrq61OI&#xa;x4fx9QWYx9H/wXDTD+pQBKeDPZNyTAuYxMk8oAKWT+kM2I1I0hjYIWwW0RJ4kfP/HYpfAAAA//8D&#xa;AFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9U&#xa;eXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9y&#xa;ZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhAHJxX5UoAgAACwQAAA4AAAAAAAAAAAAAAAAALgIAAGRy&#xa;cy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAhAOqHj+njAAAACwEAAA8AAAAAAAAAAAAAAAAAggQA&#xa;AGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAEAPMAAACSBQAAAAA=&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Family_ResidenceState %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00226F49">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251663872" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="58024E23" wp14:editId="6B7C66D5">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>1022350</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>5955030</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1214755" cy="278130"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="46" name="مربع نص 46"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1214755" cy="278130"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Family_Residence_Type %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="58024E23" id="مربع نص 46" o:spid="_x0000_s1042" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:80.5pt;margin-top:468.9pt;width:95.65pt;height:21.9pt;flip:x;z-index:251663872;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQAOIuShJwIAAAsEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNE1ot92o6WrZZQFp&#xa;+ZEWHsB1nMbC9hjbbVLu8CxcOXDgTbpvw9gp3QpuiBwsOzP+Zr5vPi8ueq3IVjgvwVQ0H40pEYZD&#xa;Lc26oh/e3zyZU+IDMzVTYERFd8LTi+XjR4vOlqKAFlQtHEEQ48vOVrQNwZZZ5nkrNPMjsMJgsAGn&#xa;WcCjW2e1Yx2ia5UV4/FZ1oGrrQMuvMe/10OQLhN+0wge3jaNF4GoimJvIa0urau4ZssFK9eO2Vby&#xa;QxvsH7rQTBoseoS6ZoGRjZN/QWnJHXhowoiDzqBpJBeJA7LJx3+wuWuZFYkLiuPtUSb//2D5m+07&#xa;R2Rd0ckZJYZpnNH9l/33/bf9T3L/df+D4H8UqbO+xNw7i9mhfwY9DjsR9vYW+EdPDFy1zKzFpXPQ&#xa;tYLV2GQeb2YnVwccH0FW3WuosRjbBEhAfeM0aZS0L39DozoE6+DYdsdRiT4QHosX+WQ2nVLCMVbM&#xa;5vnTNMuMlREnTsI6H14I0CRuKurQCqkO2976EPt6SInpBm6kUskOypCuoufTYpounES0DOhWJXVF&#xa;5+P4Df6JdJ+bOl0OTKphjwWUOfCPlAfyoV/1Se/8qOsK6h0q4mBwJ74m3LTgPlPSoTMr6j9tmBOU&#xa;qFcGVT3PJ5No5XSYTGcFHtxpZHUaYYYjVEUDJcP2KiT7D5wvUf1GJjnimIZODj2j45JKh9cRLX16&#xa;TlkPb3j5CwAA//8DAFBLAwQUAAYACAAAACEAoMtALeIAAAALAQAADwAAAGRycy9kb3ducmV2Lnht&#xa;bEyPwU7DMBBE70j8g7VI3KiThqYlxKkQEhKHUNGAVI5u7MZR7XUUu234e5YTHGd2NDuvXE/OsrMe&#xa;Q+9RQDpLgGlsveqxE/D58XK3AhaiRCWtRy3gWwdYV9dXpSyUv+BWn5vYMSrBUEgBJsah4Dy0RjsZ&#xa;Zn7QSLeDH52MJMeOq1FeqNxZPk+SnDvZI30wctDPRrfH5uQEqHq3WyyPQ701X/eHV7tRdfP+JsTt&#xa;zfT0CCzqKf6F4Xc+TYeKNu39CVVglnSeEksU8JAtiYES2WKeAduTs0pz4FXJ/zNUPwAAAP//AwBQ&#xa;SwECLQAUAAYACAAAACEAtoM4kv4AAADhAQAAEwAAAAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRfVHlw&#xa;ZXNdLnhtbFBLAQItABQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAAAAAAAAAAAAAAC8BAABfcmVs&#xa;cy8ucmVsc1BLAQItABQABgAIAAAAIQAOIuShJwIAAAsEAAAOAAAAAAAAAAAAAAAAAC4CAABkcnMv&#xa;ZTJvRG9jLnhtbFBLAQItABQABgAIAAAAIQCgy0At4gAAAAsBAAAPAAAAAAAAAAAAAAAAAIEEAABk&#xa;cnMvZG93bnJldi54bWxQSwUGAAAAAAQABADzAAAAkAUAAAAA&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:rtl/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Family_Residence_Type %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00226F49">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251661824" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="1E81FC95" wp14:editId="7BC395B3">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>2299335</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>5955030</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1202055" cy="278130"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="45" name="مربع نص 45"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1202055" cy="278130"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Family_Finncial_State %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="1E81FC95" id="مربع نص 45" o:spid="_x0000_s1043" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:181.05pt;margin-top:468.9pt;width:94.65pt;height:21.9pt;flip:x;z-index:251661824;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQDRq7/YKAIAAAsEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNGloaTdqulp2WUBa&#xa;fqSFB3Adp7GwPcZ2m5Q7PAtXDhx4k+7bMHa63QpuiBwsOzP+Zr5vPi/Oe63IVjgvwVR0PMopEYZD&#xa;Lc26oh8/XD+ZU+IDMzVTYERFd8LT8+XjR4vOlqKAFlQtHEEQ48vOVrQNwZZZ5nkrNPMjsMJgsAGn&#xa;WcCjW2e1Yx2ia5UVef4s68DV1gEX3uPfqyFIlwm/aQQP75rGi0BURbG3kFaX1lVcs+WClWvHbCv5&#xa;oQ32D11oJg0WPUJdscDIxsm/oLTkDjw0YcRBZ9A0kovEAdmM8z/Y3LbMisQFxfH2KJP/f7D87fa9&#xa;I7Ku6GRKiWEaZ3T3df9j/33/i9x92/8k+B9F6qwvMffWYnbon0OPw06Evb0B/skTA5ctM2tx4Rx0&#xa;rWA1NjmON7OTqwOOjyCr7g3UWIxtAiSgvnGaNEraV/fQqA7BOji23XFUog+Ex+JFXuRTbJljrJjN&#xa;x0/TLDNWRpw4Cet8eClAk7ipqEMrpDpse+ND7OshJaYbuJZKJTsoQ7qKnk2LabpwEtEyoFuV1BWd&#xa;5/Eb/BPpvjB1uhyYVMMeCyhz4B8pD+RDv+qT3uPZva4rqHeoiIPBnfiacNOC+0JJh86sqP+8YU5Q&#xa;ol4bVPVsPJlEK6fDZDor8OBOI6vTCDMcoSoaKBm2lyHZf+B8geo3MskRxzR0cugZHZdUOryOaOnT&#xa;c8p6eMPL3wAAAP//AwBQSwMEFAAGAAgAAAAhACL/kqviAAAACwEAAA8AAABkcnMvZG93bnJldi54&#xa;bWxMj8FOwzAMhu9IvENkJG4s7bZ2ozSdEBISh4JYQRrHrMmaaolTNdlW3h5zgqPtT7+/v9xMzrKz&#xa;HkPvUUA6S4BpbL3qsRPw+fF8twYWokQlrUct4FsH2FTXV6UslL/gVp+b2DEKwVBIASbGoeA8tEY7&#xa;GWZ+0Ei3gx+djDSOHVejvFC4s3yeJDl3skf6YOSgn4xuj83JCVD1bpetjkO9NV/Lw4t9U3Xz/irE&#xa;7c30+AAs6in+wfCrT+pQkdPen1AFZgUs8nlKqID7xYo6EJFl6RLYnjbrNAdelfx/h+oHAAD//wMA&#xa;UEsBAi0AFAAGAAgAAAAhALaDOJL+AAAA4QEAABMAAAAAAAAAAAAAAAAAAAAAAFtDb250ZW50X1R5&#xa;cGVzXS54bWxQSwECLQAUAAYACAAAACEAOP0h/9YAAACUAQAACwAAAAAAAAAAAAAAAAAvAQAAX3Jl&#xa;bHMvLnJlbHNQSwECLQAUAAYACAAAACEA0au/2CgCAAALBAAADgAAAAAAAAAAAAAAAAAuAgAAZHJz&#xa;L2Uyb0RvYy54bWxQSwECLQAUAAYACAAAACEAIv+Sq+IAAAALAQAADwAAAAAAAAAAAAAAAACCBAAA&#xa;ZHJzL2Rvd25yZXYueG1sUEsFBgAAAAAEAAQA8wAAAJEFAAAAAA==&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:rtl/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Family_Finncial_State %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00462147">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251688448" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="1952EF5D" wp14:editId="1DB575AA">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>5028565</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>2523490</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="800100" cy="290830"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="192" name="مربع نص 2"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="800100" cy="290830"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00462147" w:rsidRPr="00462147" w:rsidRDefault="00462147" w:rsidP="00462147">
                                                                       <w:pPr>
                                                                           <w:rPr>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:color w:val="FF0000"/>
                                                                               <w:sz w:val="28"/>
                                                                               <w:szCs w:val="28"/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r>
                                                                           <w:rPr>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:color w:val="FF0000"/>
                                                                               <w:sz w:val="28"/>
                                                                               <w:szCs w:val="28"/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Father_HasDeathCertificate %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="1952EF5D" id="_x0000_s1044" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:395.95pt;margin-top:198.7pt;width:63pt;height:22.9pt;flip:x;z-index:251688448;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQAv4i2kJAIAAAoEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNGlooY2arpZdFpCW&#xa;H2nhAVzHaSxsj7HdJt07PAtXDhx4k+7bMHa63QpuiIs19sx8M98348VZrxXZCuclmIqORzklwnCo&#xa;pVlX9NPHqyczSnxgpmYKjKjoTnh6tnz8aNHZUhTQgqqFIwhifNnZirYh2DLLPG+FZn4EVhh0NuA0&#xa;C3h166x2rEN0rbIiz59lHbjaOuDCe3y9HJx0mfCbRvDwvmm8CERVFHsL6XTpXMUzWy5YuXbMtpIf&#xa;2mD/0IVm0mDRI9QlC4xsnPwLSkvuwEMTRhx0Bk0juUgckM04/4PNTcusSFxQHG+PMvn/B8vfbT84&#xa;Imuc3bygxDCNQ7r7uv+x/77/Re6+7X+SIorUWV9i7I3F6NC/gB4TEmFvr4F/9sTARcvMWpw7B10r&#xa;WI1NjmNmdpI64PgIsureQo212CZAAuobp0mjpH19D43qEKyDY9sdRyX6QDg+znKUCz0cXcU8nz1N&#xa;o8xYGWHiIKzz4ZUATaJRUYebkMqw7bUPsa2HkBhu4EoqlbZBGdJVdD4tpinhxKNlwGVVUqf6OdZP&#xa;CZHtS1MnOzCpBhsLKHOgHxkP3EO/6ge5Z/eyrqDeoSAOhuXEz4RGC+6Wkg4Xs6L+y4Y5QYl6Y1DU&#xa;+XgyiZucLpPp8wIv7tSzOvUwwxGqooGSwbwIafsHzucofiOTHHFKQyeHnnHhkkqHzxE3+vSeoh6+&#xa;8PI3AAAA//8DAFBLAwQUAAYACAAAACEAEoXwh+IAAAALAQAADwAAAGRycy9kb3ducmV2LnhtbEyP&#xa;wU7DMAyG70i8Q2QkbiztVigtTSeEhMShIFaQxjFrvKZa4lRNtpW3J5zgaPvT7++v1rM17ISTHxwJ&#xa;SBcJMKTOqYF6AZ8fzzf3wHyQpKRxhAK+0cO6vryoZKncmTZ4akPPYgj5UgrQIYwl577TaKVfuBEp&#xa;3vZusjLEceq5muQ5hlvDl0lyx60cKH7QcsQnjd2hPVoBqtlub/PD2Gz0V7Z/MW+qad9fhbi+mh8f&#xa;gAWcwx8Mv/pRHerotHNHUp4ZAXmRFhEVsCryDFgkijSPm52ALFstgdcV/9+h/gEAAP//AwBQSwEC&#xa;LQAUAAYACAAAACEAtoM4kv4AAADhAQAAEwAAAAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRfVHlwZXNd&#xa;LnhtbFBLAQItABQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAAAAAAAAAAAAAAC8BAABfcmVscy8u&#xa;cmVsc1BLAQItABQABgAIAAAAIQAv4i2kJAIAAAoEAAAOAAAAAAAAAAAAAAAAAC4CAABkcnMvZTJv&#xa;RG9jLnhtbFBLAQItABQABgAIAAAAIQAShfCH4gAAAAsBAAAPAAAAAAAAAAAAAAAAAH4EAABkcnMv&#xa;ZG93bnJldi54bWxQSwUGAAAAAAQABADzAAAAjQUAAAAA&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00462147" w:rsidRPr="00462147" w:rsidRDefault="00462147" w:rsidP="00462147">
                                                           <w:pPr>
                                                               <w:rPr>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:color w:val="FF0000"/>
                                                                   <w:sz w:val="28"/>
                                                                   <w:szCs w:val="28"/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r>
                                                               <w:rPr>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:color w:val="FF0000"/>
                                                                   <w:sz w:val="28"/>
                                                                   <w:szCs w:val="28"/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Father_HasDeathCertificate %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00462147">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251694592" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="556FBB0C" wp14:editId="3A678F5B">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>5028565</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>3322955</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="800100" cy="290830"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="203" name="مربع نص 2"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="800100" cy="290830"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00462147" w:rsidRPr="00462147" w:rsidRDefault="00462147" w:rsidP="00462147">
                                                                       <w:pPr>
                                                                           <w:rPr>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:color w:val="FF0000"/>
                                                                               <w:sz w:val="28"/>
                                                                               <w:szCs w:val="28"/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r>
                                                                           <w:rPr>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:color w:val="FF0000"/>
                                                                               <w:sz w:val="28"/>
                                                                               <w:szCs w:val="28"/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.BondsMan_HasBondsManIdPhoto %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="556FBB0C" id="_x0000_s1045" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:395.95pt;margin-top:261.65pt;width:63pt;height:22.9pt;flip:x;z-index:251694592;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQB5+2biJQIAAAoEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNGm2hTZqulp2WUBa&#xa;fqSFB3Adp7GwPcZ2m5Q7PAtXDhx4k+7bMHa63QpuiIs14xl/M98348V5rxXZCuclmIqORzklwnCo&#xa;pVlX9OOH6yczSnxgpmYKjKjoTnh6vnz8aNHZUhTQgqqFIwhifNnZirYh2DLLPG+FZn4EVhgMNuA0&#xa;C+i6dVY71iG6VlmR50+zDlxtHXDhPd5eDUG6TPhNI3h41zReBKIqir2FdLp0ruKZLResXDtmW8kP&#xa;bbB/6EIzabDoEeqKBUY2Tv4FpSV34KEJIw46g6aRXCQOyGac/8HmtmVWJC4ojrdHmfz/g+Vvt+8d&#xa;kXVFi/yMEsM0Dunu6/7H/vv+F7n7tv9JiihSZ32JubcWs0P/HHocdiLs7Q3wT54YuGyZWYsL56Br&#xa;BauxyXF8mZ08HXB8BFl1b6DGWmwTIAH1jdOkUdK+uodGdQjWwbHtjqMSfSAcL2c5yoURjqFins/O&#xa;0igzVkaYOAjrfHgpQJNoVNThJqQybHvjQ2zrISWmG7iWSqVtUIZ0FZ1Pi2l6cBLRMuCyKqlT/Rzr&#xa;pweR7QtTJzswqQYbCyhzoB8ZD9xDv+qT3OP5vawrqHcoiINhOfEzodGC+0JJh4tZUf95w5ygRL02&#xa;KOp8PJnETU7OZPqsQMedRlanEWY4QlU0UDKYlyFt/8D5AsVvZJIjTmno5NAzLlxS6fA54kaf+inr&#xa;4QsvfwMAAP//AwBQSwMEFAAGAAgAAAAhAMx45HDiAAAACwEAAA8AAABkcnMvZG93bnJldi54bWxM&#xa;j01Lw0AQhu+C/2EZwZvdpLWNidkUEQQPsdgo1OM2O82G7kfIbtv47x1Pepx3Ht55plxP1rAzjqH3&#xa;TkA6S4Cha73qXSfg8+Pl7gFYiNIpabxDAd8YYF1dX5WyUP7itnhuYseoxIVCCtAxDgXnodVoZZj5&#xa;AR3tDn60MtI4dlyN8kLl1vB5kqy4lb2jC1oO+KyxPTYnK0DVu90yOw71Vn/dH17NRtXN+5sQtzfT&#xa;0yOwiFP8g+FXn9ShIqe9PzkVmBGQ5WlOqIDlfLEARkSeZpTsKVnlKfCq5P9/qH4AAAD//wMAUEsB&#xa;Ai0AFAAGAAgAAAAhALaDOJL+AAAA4QEAABMAAAAAAAAAAAAAAAAAAAAAAFtDb250ZW50X1R5cGVz&#xa;XS54bWxQSwECLQAUAAYACAAAACEAOP0h/9YAAACUAQAACwAAAAAAAAAAAAAAAAAvAQAAX3JlbHMv&#xa;LnJlbHNQSwECLQAUAAYACAAAACEAeftm4iUCAAAKBAAADgAAAAAAAAAAAAAAAAAuAgAAZHJzL2Uy&#xa;b0RvYy54bWxQSwECLQAUAAYACAAAACEAzHjkcOIAAAALAQAADwAAAAAAAAAAAAAAAAB/BAAAZHJz&#xa;L2Rvd25yZXYueG1sUEsFBgAAAAAEAAQA8wAAAI4FAAAAAA==&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00462147" w:rsidRPr="00462147" w:rsidRDefault="00462147" w:rsidP="00462147">
                                                           <w:pPr>
                                                               <w:rPr>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:color w:val="FF0000"/>
                                                                   <w:sz w:val="28"/>
                                                                   <w:szCs w:val="28"/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r>
                                                               <w:rPr>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:color w:val="FF0000"/>
                                                                   <w:sz w:val="28"/>
                                                                   <w:szCs w:val="28"/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                               <w:t><%= Data.BondsMan_HasBondsManIdPhoto %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00462147">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251692544" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="31F3614A" wp14:editId="60E81572">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>5028565</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>3051175</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="800100" cy="290830"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="202" name="مربع نص 2"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="800100" cy="290830"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00462147" w:rsidRPr="00462147" w:rsidRDefault="00462147" w:rsidP="00462147">
                                                                       <w:pPr>
                                                                           <w:rPr>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:color w:val="FF0000"/>
                                                                               <w:sz w:val="28"/>
                                                                               <w:szCs w:val="28"/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r>
                                                                           <w:rPr>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:color w:val="FF0000"/>
                                                                               <w:sz w:val="28"/>
                                                                               <w:szCs w:val="28"/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Family_HasFamilyCardPhoto %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="31F3614A" id="_x0000_s1046" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:395.95pt;margin-top:240.25pt;width:63pt;height:22.9pt;flip:x;z-index:251692544;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQAgswcTIwIAAAoEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNGlooY2arpZdFpCW&#xa;H2nhAVzHaSxsj7HdJt07PAtXDhx4k+7bMHa63QpuiIs14xl/M98348VZrxXZCuclmIqORzklwnCo&#xa;pVlX9NPHqyczSnxgpmYKjKjoTnh6tnz8aNHZUhTQgqqFIwhifNnZirYh2DLLPG+FZn4EVhgMNuA0&#xa;C+i6dVY71iG6VlmR58+yDlxtHXDhPd5eDkG6TPhNI3h43zReBKIqir2FdLp0ruKZLResXDtmW8kP&#xa;bbB/6EIzabDoEeqSBUY2Tv4FpSV34KEJIw46g6aRXCQOyGac/8HmpmVWJC4ojrdHmfz/g+Xvth8c&#xa;kXVFi7ygxDCNQ7r7uv+x/77/Re6+7X+SIorUWV9i7o3F7NC/gB6HnQh7ew38sycGLlpm1uLcOeha&#xa;wWpschxfZidPBxwfQVbdW6ixFtsESEB94zRplLSv76FRHYJ1cGy746hEHwjHy1mOcmGEY6iY57On&#xa;aZQZKyNMHIR1PrwSoEk0KupwE1IZtr32Ibb1kBLTDVxJpdI2KEO6is6nxTQ9OIloGXBZldSpfo71&#xa;04PI9qWpkx2YVIONBZQ50I+MB+6hX/UHue9lXUG9Q0EcDMuJnwmNFtwtJR0uZkX9lw1zghL1xqCo&#xa;8/FkEjc5OZPp8wIddxpZnUaY4QhV0UDJYF6EtP0D53MUv5FJjjiloZNDz7hwSaXD54gbfeqnrIcv&#xa;vPwNAAD//wMAUEsDBBQABgAIAAAAIQCeppG44wAAAAsBAAAPAAAAZHJzL2Rvd25yZXYueG1sTI/B&#xa;TsMwDIbvSLxDZCRuLO1Y17U0nRASEocOsYI0jlnjNdUap2qyrbz9wgmOtj/9/v5iPZmenXF0nSUB&#xa;8SwChtRY1VEr4Ovz9WEFzHlJSvaWUMAPOliXtzeFzJW90BbPtW9ZCCGXSwHa+yHn3DUajXQzOyCF&#xa;28GORvowji1Xo7yEcNPzeRQtuZEdhQ9aDviisTnWJyNAVbtdkh6Haqu/F4e3/l1V9cdGiPu76fkJ&#xa;mMfJ/8Hwqx/UoQxOe3si5VgvIM3iLKACFqsoARaILE7DZi8gmS8fgZcF/9+hvAIAAP//AwBQSwEC&#xa;LQAUAAYACAAAACEAtoM4kv4AAADhAQAAEwAAAAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRfVHlwZXNd&#xa;LnhtbFBLAQItABQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAAAAAAAAAAAAAAC8BAABfcmVscy8u&#xa;cmVsc1BLAQItABQABgAIAAAAIQAgswcTIwIAAAoEAAAOAAAAAAAAAAAAAAAAAC4CAABkcnMvZTJv&#xa;RG9jLnhtbFBLAQItABQABgAIAAAAIQCeppG44wAAAAsBAAAPAAAAAAAAAAAAAAAAAH0EAABkcnMv&#xa;ZG93bnJldi54bWxQSwUGAAAAAAQABADzAAAAjQUAAAAA&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00462147" w:rsidRPr="00462147" w:rsidRDefault="00462147" w:rsidP="00462147">
                                                           <w:pPr>
                                                               <w:rPr>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:color w:val="FF0000"/>
                                                                   <w:sz w:val="28"/>
                                                                   <w:szCs w:val="28"/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r>
                                                               <w:rPr>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:color w:val="FF0000"/>
                                                                   <w:sz w:val="28"/>
                                                                   <w:szCs w:val="28"/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Family_HasFamilyCardPhoto %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00462147">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251690496" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="428B8DC8" wp14:editId="7ECB038D">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>5028565</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>2783205</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="800100" cy="290830"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="193" name="مربع نص 2"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="800100" cy="290830"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00462147" w:rsidRPr="00462147" w:rsidRDefault="00462147" w:rsidP="00462147">
                                                                       <w:pPr>
                                                                           <w:rPr>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:color w:val="FF0000"/>
                                                                               <w:sz w:val="28"/>
                                                                               <w:szCs w:val="28"/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r>
                                                                           <w:rPr>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:color w:val="FF0000"/>
                                                                               <w:sz w:val="28"/>
                                                                               <w:szCs w:val="28"/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Orphan_HasBirthCertificate %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="428B8DC8" id="_x0000_s1047" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:395.95pt;margin-top:219.15pt;width:63pt;height:22.9pt;flip:x;z-index:251690496;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQB2qkxVIwIAAAoEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNGm2hTZqulp2WUBa&#xa;fqSFB3Adp7GwPcZ2m+ze4Vm4cuDAm3TfhrFT2gpuiIs19sx8M98348V5rxXZCuclmIqORzklwnCo&#xa;pVlX9OOH6yczSnxgpmYKjKjonfD0fPn40aKzpSigBVULRxDE+LKzFW1DsGWWed4KzfwIrDDobMBp&#xa;FvDq1lntWIfoWmVFnj/NOnC1dcCF9/h6NTjpMuE3jeDhXdN4EYiqKPYW0unSuYpntlywcu2YbSXf&#xa;t8H+oQvNpMGiB6grFhjZOPkXlJbcgYcmjDjoDJpGcpE4IJtx/geb25ZZkbigON4eZPL/D5a/3b53&#xa;RNY4u/kZJYZpHNLDl9333bfdT/LwdfeDFFGkzvoSY28tRof+OfSYkAh7ewP8kycGLltm1uLCOeha&#xa;wWpschwzs5PUAcdHkFX3BmqsxTYBElDfOE0aJe2r39CoDsE6OLa7w6hEHwjHx1mOcqGHo6uY57Oz&#xa;NMqMlREmDsI6H14K0CQaFXW4CakM2974ENs6hsRwA9dSqbQNypCuovNpMU0JJx4tAy6rkjrVz7F+&#xa;SohsX5g62YFJNdhYQJk9/ch44B76VZ/kLpI4UZsV1HcoiINhOfEzodGCu6ekw8WsqP+8YU5Qol4b&#xa;FHU+nkziJqfLZPqswIs79axOPcxwhKpooGQwL0Pa/oHzBYrfyCTHsZN9z7hwSaX954gbfXpPUccv&#xa;vPwFAAD//wMAUEsDBBQABgAIAAAAIQAOdRYZ4gAAAAsBAAAPAAAAZHJzL2Rvd25yZXYueG1sTI/L&#xa;TsMwEEX3SPyDNUjsqBMayKNxKoSExCIgGpDapRu7SVR7HMVuG/6eYQXLuXN050y5nq1hZz35waGA&#xa;eBEB09g6NWAn4Ovz5S4D5oNEJY1DLeBbe1hX11elLJS74Eafm9AxKkFfSAF9CGPBuW97baVfuFEj&#xa;7Q5usjLQOHVcTfJC5dbw+yh65FYOSBd6OernXrfH5mQFqHq7fUiPY73pd8nh1byruvl4E+L2Zn5a&#xa;AQt6Dn8w/OqTOlTktHcnVJ4ZAWke54QKSJbZEhgReZxSsqckS2LgVcn//1D9AAAA//8DAFBLAQIt&#xa;ABQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBlc10u&#xa;eG1sUEsBAi0AFAAGAAgAAAAhADj9If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxzLy5y&#xa;ZWxzUEsBAi0AFAAGAAgAAAAhAHaqTFUjAgAACgQAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9lMm9E&#xa;b2MueG1sUEsBAi0AFAAGAAgAAAAhAA51FhniAAAACwEAAA8AAAAAAAAAAAAAAAAAfQQAAGRycy9k&#xa;b3ducmV2LnhtbFBLBQYAAAAABAAEAPMAAACMBQAAAAA=&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00462147" w:rsidRPr="00462147" w:rsidRDefault="00462147" w:rsidP="00462147">
                                                           <w:pPr>
                                                               <w:rPr>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:color w:val="FF0000"/>
                                                                   <w:sz w:val="28"/>
                                                                   <w:szCs w:val="28"/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r>
                                                               <w:rPr>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:color w:val="FF0000"/>
                                                                   <w:sz w:val="28"/>
                                                                   <w:szCs w:val="28"/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Orphan_HasBirthCertificate %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00AB47DB">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251686400" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="4D542684" wp14:editId="30567E2E">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>-265815</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>6967722</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="3749173" cy="318977"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="5080"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="61" name="مربع نص 61"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="3749173" cy="318977"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="0054320A" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Family_FullAdress %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="4D542684" id="مربع نص 61" o:spid="_x0000_s1048" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:-20.95pt;margin-top:548.65pt;width:295.2pt;height:25.1pt;flip:x;z-index:251686400;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQBdudXyKwIAAAsEAAAOAAAAZHJzL2Uyb0RvYy54bWysU8uO0zAU3SPxD5b3NE3aTtuo6WiYYQBp&#xa;eEgDH+A6TmPh+BrbbdLZw7ewZcGCP+n8DddOWyrYIbKIbN/r43OOjxeXXaPIVlgnQRc0HQwpEZpD&#xa;KfW6oB8/3D6bUeI80yVToEVBd8LRy+XTJ4vW5CKDGlQpLEEQ7fLWFLT23uRJ4ngtGuYGYITGYgW2&#xa;YR6ndp2UlrWI3qgkGw4vkhZsaSxw4Ryu3vRFuoz4VSW4f1dVTniiCorcfPzb+F+Ff7JcsHxtmakl&#xa;P9Bg/8CiYVLjoSeoG+YZ2Vj5F1QjuQUHlR9waBKoKslF1IBq0uEfau5rZkTUguY4c7LJ/T9Y/nb7&#xa;3hJZFvQipUSzBu/o8cv++/7b/id5/Lr/QXAdTWqNy7H33mC3755Dh5cdBTtzB/yTIxqua6bX4spa&#xa;aGvBSiQZdyZnW3scF0BW7Rso8TC28RCBuso2pFLSvDpCozsEz8Fr252uSnSecFwcTcfzdDqihGNt&#xa;lM7m02mgmbA84ISbMNb5lwIaEgYFtRiFeA7b3jnftx5bQruGW6lUjIPSpC3ofJJN4oazSiM9plXJ&#xa;pqCzYfj6/AS5L3QZN3smVT9GLkojpaA/SO7F+27VRb+z7OjrCsodOmKhTye+JhzUYB8oaTGZBXWf&#xa;N8wKStRrja7O0/E4RDlOxpNphhN7XlmdV5jmCFVQT0k/vPYx/r3mK3S/ktGOQLNncuCMiYuGHl5H&#xa;iPT5PHb9fsPLXwAAAP//AwBQSwMEFAAGAAgAAAAhAJTae5vkAAAADQEAAA8AAABkcnMvZG93bnJl&#xa;di54bWxMj8FOwzAMhu9IvENkJG5bWmjpVppOCAmJQ5lYmbQds8ZrqjVJ1WRbeXvMCY72/+n352I1&#xa;mZ5dcPSdswLieQQMbeNUZ1sB26+32QKYD9Iq2TuLAr7Rw6q8vSlkrtzVbvBSh5ZRifW5FKBDGHLO&#xa;faPRSD93A1rKjm40MtA4tlyN8krlpucPUfTEjewsXdBywFeNzak+GwGq2u3S7DRUG71Pju/9WlX1&#xa;54cQ93fTyzOwgFP4g+FXn9ShJKeDO1vlWS9glsRLQimIltkjMELSZJECO9AqTrIUeFnw/1+UPwAA&#xa;AP//AwBQSwECLQAUAAYACAAAACEAtoM4kv4AAADhAQAAEwAAAAAAAAAAAAAAAAAAAAAAW0NvbnRl&#xa;bnRfVHlwZXNdLnhtbFBLAQItABQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAAAAAAAAAAAAAAC8B&#xa;AABfcmVscy8ucmVsc1BLAQItABQABgAIAAAAIQBdudXyKwIAAAsEAAAOAAAAAAAAAAAAAAAAAC4C&#xa;AABkcnMvZTJvRG9jLnhtbFBLAQItABQABgAIAAAAIQCU2nub5AAAAA0BAAAPAAAAAAAAAAAAAAAA&#xa;AIUEAABkcnMvZG93bnJldi54bWxQSwUGAAAAAAQABADzAAAAlgUAAAAA&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="0054320A" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Family_FullAdress %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00AB47DB">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251684352" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="01337797" wp14:editId="2E7F9D45">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>3493770</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>6972300</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1221105" cy="298450"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="6350"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="60" name="مربع نص 2"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1221105" cy="298450"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="0054320A" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Family_Phone %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="01337797" id="_x0000_s1049" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:275.1pt;margin-top:549pt;width:96.15pt;height:23.5pt;flip:x;z-index:251684352;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQCUQ2N8JwIAAAoEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNE1olzZqulp2WUBa&#xa;fqSFB3Adp7GwPcZ2m5Q7PAtXDhx4k+7bMHa63QpuiBwsOzP+Zr5vPi/Oe63IVjgvwVQ0H40pEYZD&#xa;Lc26oh8/XD+ZUeIDMzVTYERFd8LT8+XjR4vOlqKAFlQtHEEQ48vOVrQNwZZZ5nkrNPMjsMJgsAGn&#xa;WcCjW2e1Yx2ia5UV4/FZ1oGrrQMuvMe/V0OQLhN+0wge3jWNF4GoimJvIa0urau4ZssFK9eO2Vby&#xa;QxvsH7rQTBoseoS6YoGRjZN/QWnJHXhowoiDzqBpJBeJA7LJx3+wuW2ZFYkLiuPtUSb//2D52+17&#xa;R2Rd0TOUxzCNM7r7uv+x/77/Re6+7X+SImrUWV9i6q3F5NA/hx5nnfh6ewP8kycGLltm1uLCOeha&#xa;wWrsMY83s5OrA46PIKvuDdRYi20CJKC+cZo0StpX99AoDsE62NbuOCnRB8Jj8aLI8/GUEo6xYj6b&#xa;TNMoM1ZGnDgI63x4KUCTuKmoQyekOmx740Ps6yElphu4lkolNyhDuorOp8U0XTiJaBnQrErqis7G&#xa;8RvsE+m+MHW6HJhUwx4LKHPgHykP5EO/6pPcxdN7XVdQ71ARB4M58THhpgX3hZIOjVlR/3nDnKBE&#xa;vTao6jyfTKKT02EyfVbgwZ1GVqcRZjhCVTRQMmwvQ3L/wPkC1W9kkiOOaejk0DMaLql0eBzR0afn&#xa;lPXwhJe/AQAA//8DAFBLAwQUAAYACAAAACEAVXZD+OMAAAANAQAADwAAAGRycy9kb3ducmV2Lnht&#xa;bEyPzU7DMBCE70i8g7VI3KjdKKYljVMhJCQOAbUBqT26sRtH9U8Uu214e5YTHHfm0+xMuZ6cJRc9&#xa;xj54AfMZA6J9G1TvOwFfn68PSyAxSa+kDV4L+NYR1tXtTSkLFa5+qy9N6giG+FhIASaloaA0tkY7&#xa;GWdh0B69YxidTHiOHVWjvGK4szRj7JE62Xv8YOSgX4xuT83ZCVD1bscXp6Hemn1+fLMfqm4270Lc&#xa;303PKyBJT+kPht/6WB0q7HQIZ68isQI4ZxmiaLCnJa5CZJFnHMgBpXnOGdCqpP9XVD8AAAD//wMA&#xa;UEsBAi0AFAAGAAgAAAAhALaDOJL+AAAA4QEAABMAAAAAAAAAAAAAAAAAAAAAAFtDb250ZW50X1R5&#xa;cGVzXS54bWxQSwECLQAUAAYACAAAACEAOP0h/9YAAACUAQAACwAAAAAAAAAAAAAAAAAvAQAAX3Jl&#xa;bHMvLnJlbHNQSwECLQAUAAYACAAAACEAlENjfCcCAAAKBAAADgAAAAAAAAAAAAAAAAAuAgAAZHJz&#xa;L2Uyb0RvYy54bWxQSwECLQAUAAYACAAAACEAVXZD+OMAAAANAQAADwAAAAAAAAAAAAAAAACBBAAA&#xa;ZHJzL2Rvd25yZXYueG1sUEsFBgAAAAAEAAQA8wAAAJEFAAAAAA==&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00306F0A" w:rsidRPr="00455C15" w:rsidRDefault="0054320A" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Family_Phone %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00AB47DB">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251641344" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="70C1297F" wp14:editId="3D61D2C7">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>1035212</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>3308350</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1193165" cy="290830"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="30" name="مربع نص 30"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1193165" cy="290830"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Mother_IdNumber %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="70C1297F" id="مربع نص 30" o:spid="_x0000_s1050" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:81.5pt;margin-top:260.5pt;width:93.95pt;height:22.9pt;flip:x;z-index:251641344;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQAr9P2NJwIAAAsEAAAOAAAAZHJzL2Uyb0RvYy54bWysU81uEzEQviPxDpbvZH+alCTKpiotBaTy&#xa;IxUewPF6sxa2x9hOdts7PAtXDhx4k/RtGHvTNIIbYg+WvTP+Zr5vPi/Oeq3IVjgvwVS0GOWUCMOh&#xa;lmZd0U8fr55NKfGBmZopMKKit8LTs+XTJ4vOzkUJLahaOIIgxs87W9E2BDvPMs9boZkfgRUGgw04&#xa;zQIe3TqrHesQXauszPPTrANXWwdceI9/L4cgXSb8phE8vG8aLwJRFcXeQlpdWldxzZYLNl87ZlvJ&#xa;922wf+hCM2mw6AHqkgVGNk7+BaUld+ChCSMOOoOmkVwkDsimyP9gc9MyKxIXFMfbg0z+/8Hyd9sP&#xa;jsi6oicoj2EaZ3T/dfdj9333i9x/2/0k+B9F6qyfY+6NxezQv4Aeh50Ie3sN/LMnBi5aZtbi3Dno&#xa;WsFqbLKIN7OjqwOOjyCr7i3UWIxtAiSgvnGaNEra1w/QqA7BOtjX7WFUog+Ex+LF7KQ4nVDCMVbO&#xa;8unQZsbmESdOwjofXgnQJG4q6tAKqQ7bXvsQ+3pMiekGrqRSyQ7KkK6is0k5SReOIloGdKuSuqLT&#xa;PH6DfyLdl6ZOlwOTathjAWX2/CPlgXzoV33Suxw/6LqC+hYVcTC4E18Tblpwd5R06MyK+i8b5gQl&#xa;6o1BVWfFeBytnA7jyfMSD+44sjqOMMMRqqKBkmF7EZL9B87nqH4jkxxxTEMn+57RcUml/euIlj4+&#xa;p6zHN7z8DQAA//8DAFBLAwQUAAYACAAAACEAfBBg1+IAAAALAQAADwAAAGRycy9kb3ducmV2Lnht&#xa;bEyPQU/DMAyF70j8h8hI3Fi6jZZRmk4ICYlDQawgjWPWeG21xKmabCv/HnOCm5/99Py9Yj05K044&#xa;ht6TgvksAYHUeNNTq+Dz4/lmBSJETUZbT6jgGwOsy8uLQufGn2mDpzq2gkMo5FpBF+OQSxmaDp0O&#xa;Mz8g8W3vR6cjy7GVZtRnDndWLpIkk073xB86PeBTh82hPjoFptpu07vDUG26r9v9i30zVf3+qtT1&#xa;1fT4ACLiFP/M8IvP6FAy084fyQRhWWdL7hIVpIs5D+xYpsk9iB1vsmwFsizk/w7lDwAAAP//AwBQ&#xa;SwECLQAUAAYACAAAACEAtoM4kv4AAADhAQAAEwAAAAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRfVHlw&#xa;ZXNdLnhtbFBLAQItABQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAAAAAAAAAAAAAAC8BAABfcmVs&#xa;cy8ucmVsc1BLAQItABQABgAIAAAAIQAr9P2NJwIAAAsEAAAOAAAAAAAAAAAAAAAAAC4CAABkcnMv&#xa;ZTJvRG9jLnhtbFBLAQItABQABgAIAAAAIQB8EGDX4gAAAAsBAAAPAAAAAAAAAAAAAAAAAIEEAABk&#xa;cnMvZG93bnJldi54bWxQSwUGAAAAAAQABADzAAAAkAUAAAAA&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:rtl/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Mother_IdNumber %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00AB47DB">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251643392" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="6CDFF23C" wp14:editId="665CCEBF">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>-260512</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>3308350</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1267460" cy="290830"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="31" name="مربع نص 31"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1267460" cy="290830"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Mother_Jop %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="6CDFF23C" id="مربع نص 31" o:spid="_x0000_s1051" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:-20.5pt;margin-top:260.5pt;width:99.8pt;height:22.9pt;flip:x;z-index:251643392;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQAPriNiKgIAAAsEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNGm27bZV09WyywLS&#xa;8iMtPIDrOI2F7TG226R7h2fhyoEDb9J9G8ZOt1RwQ+Rg2ZnxN/N983lx0WlFtsJ5Caakw0FOiTAc&#xa;KmnWJf344ebZlBIfmKmYAiNKuhOeXiyfPlm0di4KaEBVwhEEMX7e2pI2Idh5lnneCM38AKwwGKzB&#xa;aRbw6NZZ5ViL6FplRZ5PshZcZR1w4T3+ve6DdJnw61rw8K6uvQhElRR7C2l1aV3FNVsu2HztmG0k&#xa;P7TB/qELzaTBokeoaxYY2Tj5F5SW3IGHOgw46AzqWnKROCCbYf4Hm7uGWZG4oDjeHmXy/w+Wv92+&#xa;d0RWJT0bUmKYxhk9fNl/33/b/yQPX/c/CP5HkVrr55h7ZzE7dM+hw2Enwt7eAv/kiYGrhpm1uHQO&#xa;2kawCptMN7OTqz2OjyCr9g1UWIxtAiSgrnaa1EraV4/QqA7BOji23XFUoguEx+LF5Hw0wRDHWDHL&#xa;p2dplhmbR5w4Cet8eClAk7gpqUMrpDpse+sDMsLUx5SYbuBGKpXsoAxpSzobF+N04SSiZUC3KqlL&#xa;Os3j1/sn0n1hqnQ5MKn6PRZQButE/pFyTz50qy7pjegHXVdQ7VARB7078TXhpgF3T0mLziyp/7xh&#xa;TlCiXhtUdTYcjaKV02E0Pi/w4E4jq9MIMxyhShoo6bdXIdm/53yJ6tcyyRHb7Ds59IyOSyodXke0&#xa;9Ok5Zf1+w8tfAAAA//8DAFBLAwQUAAYACAAAACEAWdfvreEAAAALAQAADwAAAGRycy9kb3ducmV2&#xa;LnhtbEyPwU7DMBBE70j8g7VI3FqnVROiEKdCSEgcAqIBqRzdeBtHtddR7Lbh73FOcNvdGc2+KbeT&#xa;NeyCo+8dCVgtE2BIrVM9dQK+Pl8WOTAfJClpHKGAH/SwrW5vSlkod6UdXprQsRhCvpACdAhDwblv&#xa;NVrpl25AitrRjVaGuI4dV6O8xnBr+DpJMm5lT/GDlgM+a2xPzdkKUPV+nz6chnqnvzfHV/Ou6ubj&#xa;TYj7u+npEVjAKfyZYcaP6FBFpoM7k/LMCFhsVrFLEJCu52F2pHkG7BAvWZYDr0r+v0P1CwAA//8D&#xa;AFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9U&#xa;eXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9y&#xa;ZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhAA+uI2IqAgAACwQAAA4AAAAAAAAAAAAAAAAALgIAAGRy&#xa;cy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAhAFnX763hAAAACwEAAA8AAAAAAAAAAAAAAAAAhAQA&#xa;AGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAEAPMAAACSBQAAAAA=&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Mother_Jop %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00AB47DB">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251639296" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="11746568" wp14:editId="39630F76">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>2271395</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>3308985</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1211580" cy="290830"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="29" name="مربع نص 29"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1211580" cy="290830"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Mother_Birthday.ToString("yyyy/MM/dd") %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="11746568" id="مربع نص 29" o:spid="_x0000_s1052" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:178.85pt;margin-top:260.55pt;width:95.4pt;height:22.9pt;flip:x;z-index:251639296;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQCyAl2zJwIAAAsEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNE1olzZqulp2WUBa&#xa;fqSFB3Adp7GwPcZ2m5Q7PAtXDhx4k+7bMHa63QpuiBwsOzP+Zr5vPi/Oe63IVjgvwVQ0H40pEYZD&#xa;Lc26oh8/XD+ZUeIDMzVTYERFd8LT8+XjR4vOlqKAFlQtHEEQ48vOVrQNwZZZ5nkrNPMjsMJgsAGn&#xa;WcCjW2e1Yx2ia5UV4/FZ1oGrrQMuvMe/V0OQLhN+0wge3jWNF4GoimJvIa0urau4ZssFK9eO2Vby&#xa;QxvsH7rQTBoseoS6YoGRjZN/QWnJHXhowoiDzqBpJBeJA7LJx3+wuW2ZFYkLiuPtUSb//2D52+17&#xa;R2Rd0WJOiWEaZ3T3df9j/33/i9x92/8k+B9F6qwvMffWYnbon0OPw06Evb0B/skTA5ctM2tx4Rx0&#xa;rWA1NpnHm9nJ1QHHR5BV9wZqLMY2ARJQ3zhNGiXtq3toVIdgHRzb7jgq0QfCY/Eiz6czDHGMFfPx&#xa;7GmaZcbKiBMnYZ0PLwVoEjcVdWiFVIdtb3yIfT2kxHQD11KpZAdlSFfR+bSYpgsnES0DulVJXdHZ&#xa;OH6DfyLdF6ZOlwOTathjAWUO/CPlgXzoV/2g99m9riuod6iIg8Gd+Jpw04L7QkmHzqyo/7xhTlCi&#xa;XhtUdZ5PJtHK6TCZPivw4E4jq9MIMxyhKhooGbaXIdl/4HyB6jcyyRHHNHRy6Bkdl1Q6vI5o6dNz&#xa;ynp4w8vfAAAA//8DAFBLAwQUAAYACAAAACEAhU1tZuMAAAALAQAADwAAAGRycy9kb3ducmV2Lnht&#xa;bEyPy07DMBBF90j8gzVI7KiTUiclxKkQEhKLUNFQqV26sRtH9SOK3Tb8PcMKdjOaozvnlqvJGnJR&#xa;Y+i945DOEiDKtV72ruOw/Xp7WAIJUTgpjHeKw7cKsKpub0pRSH91G3VpYkcwxIVCcNAxDgWlodXK&#xa;ijDzg3J4O/rRiojr2FE5iiuGW0PnSZJRK3qHH7QY1KtW7ak5Ww6y3u1Yfhrqjd4vju9mLevm84Pz&#xa;+7vp5RlIVFP8g+FXH9WhQqeDPzsZiOHwyPIcUQ5snqZAkGCLJQNywCHLnoBWJf3fofoBAAD//wMA&#xa;UEsBAi0AFAAGAAgAAAAhALaDOJL+AAAA4QEAABMAAAAAAAAAAAAAAAAAAAAAAFtDb250ZW50X1R5&#xa;cGVzXS54bWxQSwECLQAUAAYACAAAACEAOP0h/9YAAACUAQAACwAAAAAAAAAAAAAAAAAvAQAAX3Jl&#xa;bHMvLnJlbHNQSwECLQAUAAYACAAAACEAsgJdsycCAAALBAAADgAAAAAAAAAAAAAAAAAuAgAAZHJz&#xa;L2Uyb0RvYy54bWxQSwECLQAUAAYACAAAACEAhU1tZuMAAAALAQAADwAAAAAAAAAAAAAAAACBBAAA&#xa;ZHJzL2Rvd25yZXYueG1sUEsFBgAAAAAEAAQA8wAAAJEFAAAAAA==&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Mother_Birthday.ToString("yyyy/MM/dd") %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00AB47DB">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251645440" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="2855030D" wp14:editId="6062D3C0">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>3491230</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>3948903</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1213485" cy="248920"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="36" name="مربع نص 2"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1213485" cy="248920"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Mother_Alive %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="2855030D" id="_x0000_s1053" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:274.9pt;margin-top:310.95pt;width:95.55pt;height:19.6pt;flip:x;z-index:251645440;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQAdYstQKAIAAAoEAAAOAAAAZHJzL2Uyb0RvYy54bWysU8FuEzEQvSPxD5bvZJNt0iarbKrSUkBq&#xa;AanwAY7Xm7WwPcZ2shvu8C1ce+DAn6R/w9ibphHcEHuw7J3xm3lvnufnnVZkI5yXYEo6GgwpEYZD&#xa;Jc2qpJ8+Xr+YUuIDMxVTYERJt8LT88XzZ/PWFiKHBlQlHEEQ44vWlrQJwRZZ5nkjNPMDsMJgsAan&#xa;WcCjW2WVYy2ia5Xlw+Fp1oKrrAMuvMe/V32QLhJ+XQse3te1F4GokmJvIa0urcu4Zos5K1aO2Uby&#xa;fRvsH7rQTBoseoC6YoGRtZN/QWnJHXiow4CDzqCuJReJA7IZDf9gc9cwKxIXFMfbg0z+/8Hyd5sP&#xa;jsiqpCenlBimcUYP33b3ux+7X+Th++4nyaNGrfUFpt5ZTA7dS+hw1omvtzfAP3ti4LJhZiUunIO2&#xa;EazCHkfxZnZ0tcfxEWTZ3kKFtdg6QALqaqdJraR98wiN4hCsg1PbHiYlukB4LJ6PTsbTCSUcY/l4&#xa;OsvTKDNWRJw4COt8eC1Ak7gpqUMnpDpsc+ND7OspJaYbuJZKJTcoQ9qSzib5JF04imgZ0KxK6pJO&#xa;h/Hr7RPpvjJVuhyYVP0eCyiz5x8p9+RDt+yS3PnZo65LqLaoiIPenPiYcNOA+0pJi8Ysqf+yZk5Q&#xa;ot4aVHU2Go+jk9NhPDlD5sQdR5bHEWY4QpU0UNJvL0Nyf8/5AtWvZZIjjqnvZN8zGi6ptH8c0dHH&#xa;55T19IQXvwEAAP//AwBQSwMEFAAGAAgAAAAhAJoy7OzjAAAACwEAAA8AAABkcnMvZG93bnJldi54&#xa;bWxMj8FOwzAQRO9I/IO1SNyokypNaYhTISQkDgHRgFSObuzGUe11FLtt+PtuT3DbnR3NvC3Xk7Ps&#xa;pMfQexSQzhJgGluveuwEfH+9PjwCC1GiktajFvCrA6yr25tSFsqfcaNPTewYhWAopAAT41BwHlqj&#xa;nQwzP2ik296PTkZax46rUZ4p3Fk+T5KcO9kjNRg56Bej20NzdAJUvd0uloeh3pifbP9mP1TdfL4L&#xa;cX83PT8Bi3qKf2a44hM6VMS080dUgVkBi2xF6FFAPk9XwMixzBIadqTkaQq8Kvn/H6oLAAAA//8D&#xa;AFBLAQItABQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9U&#xa;eXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhADj9If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9y&#xa;ZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhAB1iy1AoAgAACgQAAA4AAAAAAAAAAAAAAAAALgIAAGRy&#xa;cy9lMm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAhAJoy7OzjAAAACwEAAA8AAAAAAAAAAAAAAAAAggQA&#xa;AGRycy9kb3ducmV2LnhtbFBLBQYAAAAABAAEAPMAAACSBQAAAAA=&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Mother_Alive %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00AB47DB">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251625984" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="4A625846" wp14:editId="39E14202">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>-249082</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>2190115</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1244600" cy="290830"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="19" name="مربع نص 19"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1244600" cy="290830"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Father_DieDate.ToString("yyyy/MM/dd") %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="4A625846" id="مربع نص 19" o:spid="_x0000_s1054" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:-19.6pt;margin-top:172.45pt;width:98pt;height:22.9pt;flip:x;z-index:251625984;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQA0ouHNJwIAAAsEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNGlolzZqulp2WUBa&#xa;fqSFB3Adp7GwPcZ2m5Q7PAtXDhx4k+7bMHa63QpuiBwsO+P5Zr5vPi/Oe63IVjgvwVR0PMopEYZD&#xa;Lc26oh8/XD+ZUeIDMzVTYERFd8LT8+XjR4vOlqKAFlQtHEEQ48vOVrQNwZZZ5nkrNPMjsMJgsAGn&#xa;WcCjW2e1Yx2ia5UVeX6WdeBq64AL7/Hv1RCky4TfNIKHd03jRSCqothbSKtL6yqu2XLByrVjtpX8&#xa;0Ab7hy40kwaLHqGuWGBk4+RfUFpyBx6aMOKgM2gayUXigGzG+R9sbltmReKC4nh7lMn/P1j+dvve&#xa;EVnj7OaUGKZxRndf9z/23/e/yN23/U+C/1GkzvoS795avB3659BjQiLs7Q3wT54YuGyZWYsL56Br&#xa;BauxyXHMzE5SBxwfQVbdG6ixGNsESEB94zRplLSv7qFRHYJ1cGy746hEHwiPxYvJ5CzHEMdYMc9n&#xa;T9MsM1ZGnDgJ63x4KUCTuKmoQyukOmx740Ps6+FKvG7gWiqV7KAM6So6nxbTlHAS0TKgW5XUFZ3l&#xa;8Rv8E+m+MHVKDkyqYY8FlDnwj5QH8qFf9UnvYnav6wrqHSriYHAnvibctOC+UNKhMyvqP2+YE5So&#xa;1wZVnY8nk2jldJhMnxV4cKeR1WmEGY5QFQ2UDNvLkOw/cL5A9RuZ5IhjGjo59IyOSyodXke09Ok5&#xa;3Xp4w8vfAAAA//8DAFBLAwQUAAYACAAAACEAhvjlcuIAAAALAQAADwAAAGRycy9kb3ducmV2Lnht&#xa;bEyPTU/CQBCG7yb+h82YeIOtUMDWbokxMfFQiVQTPC7doduwH013gfrvHU56nJkn7zxvsR6tYWcc&#xa;QuedgIdpAgxd41XnWgFfn6+TR2AhSqek8Q4F/GCAdXl7U8hc+Yvb4rmOLaMQF3IpQMfY55yHRqOV&#xa;Yep7dHQ7+MHKSOPQcjXIC4Vbw2dJsuRWdo4+aNnji8bmWJ+sAFXtdovVsa+2+js9vJmNquqPdyHu&#xa;78bnJ2ARx/gHw1Wf1KEkp70/ORWYETCZZzNCBczTNAN2JRZLKrOnTZasgJcF/9+h/AUAAP//AwBQ&#xa;SwECLQAUAAYACAAAACEAtoM4kv4AAADhAQAAEwAAAAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRfVHlw&#xa;ZXNdLnhtbFBLAQItABQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAAAAAAAAAAAAAAC8BAABfcmVs&#xa;cy8ucmVsc1BLAQItABQABgAIAAAAIQA0ouHNJwIAAAsEAAAOAAAAAAAAAAAAAAAAAC4CAABkcnMv&#xa;ZTJvRG9jLnhtbFBLAQItABQABgAIAAAAIQCG+OVy4gAAAAsBAAAPAAAAAAAAAAAAAAAAAIEEAABk&#xa;cnMvZG93bnJldi54bWxQSwUGAAAAAAQABADzAAAAkAUAAAAA&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00F37D64" w:rsidP="00D33C64">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:rtl/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Father_DieDate.ToString("yyyy/MM/dd") %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00AB47DB">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251642880" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="1E2C79DD" wp14:editId="2B4BD659">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>1025052</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>1490980</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1206500" cy="289560"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="22" name="مربع نص 22"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1206500" cy="289560"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00C91656">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Orphan_FullHealth %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="1E2C79DD" id="مربع نص 22" o:spid="_x0000_s1055" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:80.7pt;margin-top:117.4pt;width:95pt;height:22.8pt;flip:x;z-index:251642880;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQBwes7iJwIAAAsEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNGnUlm3UdLXssoC0&#xa;/EgLD+A6TmNhe4ztNin35Vm4cuDAm3TfhrHT7VZwQ+Rg2ZnxN/N983lx3mtFtsJ5Caai41FOiTAc&#xa;amnWFf308frZGSU+MFMzBUZUdCc8PV8+fbLobCkKaEHVwhEEMb7sbEXbEGyZZZ63QjM/AisMBhtw&#xa;mgU8unVWO9YhulZZkeezrANXWwdceI9/r4YgXSb8phE8vG8aLwJRFcXeQlpdWldxzZYLVq4ds63k&#xa;hzbYP3ShmTRY9Ah1xQIjGyf/gtKSO/DQhBEHnUHTSC4SB2Qzzv9gc9syKxIXFMfbo0z+/8Hyd9sP&#xa;jsi6okVBiWEaZ3R/t/+x/77/Re6/7X8S/I8iddaXmHtrMTv0L6DHYSfC3t4A/+yJgcuWmbW4cA66&#xa;VrAamxzHm9nJ1QHHR5BV9xZqLMY2ARJQ3zhNGiXt6wdoVIdgHRzb7jgq0QfCY/Ein01zDHGMFWfz&#xa;6SzNMmNlxImTsM6HVwI0iZuKOrRCqsO2Nz7Evh5TYrqBa6lUsoMypKvofFpM04WTiJYB3aqkruhZ&#xa;Hr/BP5HuS1Ony4FJNeyxgDIH/pHyQD70q37Qe/6g6wrqHSriYHAnvibctOC+UtKhMyvqv2yYE5So&#xa;NwZVnY8nk2jldJhMnxd4cKeR1WmEGY5QFQ2UDNvLkOw/cL5A9RuZ5IhjGjo59IyOSyodXke09Ok5&#xa;ZT2+4eVvAAAA//8DAFBLAwQUAAYACAAAACEAdbzZJOEAAAALAQAADwAAAGRycy9kb3ducmV2Lnht&#xa;bEyPwU7DMBBE70j8g7VI3KjTNi1ViFMhJCQOAbUBqRzdeJtEtddR7Lbh79me4DizT7Mz+Xp0Vpxx&#xa;CJ0nBdNJAgKp9qajRsHX5+vDCkSImoy2nlDBDwZYF7c3uc6Mv9AWz1VsBIdQyLSCNsY+kzLULTod&#xa;Jr5H4tvBD05HlkMjzaAvHO6snCXJUjrdEX9odY8vLdbH6uQUmHK3Wzwe+3LbfqeHN/thymrzrtT9&#xa;3fj8BCLiGP9guNbn6lBwp70/kQnCsl5OU0YVzOYpb2Bivrg6e3ZWSQqyyOX/DcUvAAAA//8DAFBL&#xa;AQItABQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBl&#xa;c10ueG1sUEsBAi0AFAAGAAgAAAAhADj9If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxz&#xa;Ly5yZWxzUEsBAi0AFAAGAAgAAAAhAHB6zuInAgAACwQAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9l&#xa;Mm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAhAHW82SThAAAACwEAAA8AAAAAAAAAAAAAAAAAgQQAAGRy&#xa;cy9kb3ducmV2LnhtbFBLBQYAAAAABAAEAPMAAACPBQAAAAA=&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00C91656">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:rtl/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Orphan_FullHealth %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00AB47DB">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251643904" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="176ADD9D" wp14:editId="79C49C3C">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>-266065</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>1494155</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1251585" cy="290830"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="23" name="مربع نص 23"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1251585" cy="290830"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="00C91656" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00C91656">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Orphan_Education %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="007F2F25" w:rsidP="00C91656">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="176ADD9D" id="مربع نص 23" o:spid="_x0000_s1056" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:-20.95pt;margin-top:117.65pt;width:98.55pt;height:22.9pt;flip:x;z-index:251643904;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQDh5okZJgIAAAsEAAAOAAAAZHJzL2Uyb0RvYy54bWysU82O0zAQviPxDpbvNGm2gbZqulp2WUBa&#xa;fqSFB3Adp7GwPcZ2m+ze4Vm4cuDAm3TfhrFT2gpuiBwsOzP+Zr5vPi/Oe63IVjgvwVR0PMopEYZD&#xa;Lc26oh8/XD+ZUuIDMzVTYERF74Sn58vHjxadnYsCWlC1cARBjJ93tqJtCHaeZZ63QjM/AisMBhtw&#xa;mgU8unVWO9YhulZZkedPsw5cbR1w4T3+vRqCdJnwm0bw8K5pvAhEVRR7C2l1aV3FNVsu2HztmG0l&#xa;37fB/qELzaTBogeoKxYY2Tj5F5SW3IGHJow46AyaRnKROCCbcf4Hm9uWWZG4oDjeHmTy/w+Wv92+&#xa;d0TWFS3OKDFM44wevuy+777tfpKHr7sfBP+jSJ31c8y9tZgd+ufQ47ATYW9vgH/yxMBly8xaXDgH&#xa;XStYjU2O483s5OqA4yPIqnsDNRZjmwAJqG+cJo2S9tVvaFSHYB0c291hVKIPhMfiRTkupyUlHGPF&#xa;LJ+epVlmbB5x4iSs8+GlAE3ipqIOrZDqsO2ND7GvY0pMN3AtlUp2UIZ0FZ2VRZkunES0DOhWJXVF&#xa;p3n8Bv9Eui9MnS4HJtWwxwLK7PlHygP50K/6pPfQcBRnBfUdKuJgcCe+Jty04O4p6dCZFfWfN8wJ&#xa;StRrg6rOxpNJtHI6TMpnBR7caWR1GmGGI1RFAyXD9jIk+w+cL1D9RiY5jp3se0bHJZX2ryNa+vSc&#xa;so5vePkLAAD//wMAUEsDBBQABgAIAAAAIQCYJZ464gAAAAsBAAAPAAAAZHJzL2Rvd25yZXYueG1s&#xa;TI/BTsMwDIbvSLxDZCRuW9puhVGaTggJiUNBrCCNY9Z4TbXEqZpsK29PdoKj7U+/v79cT9awE46+&#xa;dyQgnSfAkFqneuoEfH2+zFbAfJCkpHGEAn7Qw7q6viplodyZNnhqQsdiCPlCCtAhDAXnvtVopZ+7&#xa;ASne9m60MsRx7Lga5TmGW8OzJLnjVvYUP2g54LPG9tAcrQBVb7f5/WGoN/p7uX8176puPt6EuL2Z&#xa;nh6BBZzCHwwX/agOVXTauSMpz4yA2TJ9iKiAbJEvgF2IPM+A7eJmlabAq5L/71D9AgAA//8DAFBL&#xa;AQItABQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAAAAAAAAAAAAAAAAAAABbQ29udGVudF9UeXBl&#xa;c10ueG1sUEsBAi0AFAAGAAgAAAAhADj9If/WAAAAlAEAAAsAAAAAAAAAAAAAAAAALwEAAF9yZWxz&#xa;Ly5yZWxzUEsBAi0AFAAGAAgAAAAhAOHmiRkmAgAACwQAAA4AAAAAAAAAAAAAAAAALgIAAGRycy9l&#xa;Mm9Eb2MueG1sUEsBAi0AFAAGAAgAAAAhAJglnjriAAAACwEAAA8AAAAAAAAAAAAAAAAAgAQAAGRy&#xa;cy9kb3ducmV2LnhtbFBLBQYAAAAABAAEAPMAAACPBQAAAAA=&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="00C91656" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00C91656">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:rtl/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Orphan_Education %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="007F2F25" w:rsidP="00C91656">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
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
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00AB47DB">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251641856" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="0DBE3AE2" wp14:editId="55E5A048">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>2265045</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>895985</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1211580" cy="290830"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="9" name="مربع نص 9"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1211580" cy="290830"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00C91656">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:rtl/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Orphan_Birthday.ToString("yyyy/MM/dd") %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="0DBE3AE2" id="مربع نص 9" o:spid="_x0000_s1057" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:178.35pt;margin-top:70.55pt;width:95.4pt;height:22.9pt;flip:x;z-index:251641856;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQDKY7PdJAIAAAkEAAAOAAAAZHJzL2Uyb0RvYy54bWysU0uOEzEQ3SNxB8t70p9JIInSGQ0zDCAN&#xa;H2ngAI7bnbawXcZ20j2zh7OwZcGCm2RuQ9kdkgh2iF5Ydlf5Vb1Xz4vzXiuyFc5LMBUtRjklwnCo&#xa;pVlX9OOH6ydTSnxgpmYKjKjonfD0fPn40aKzc1FCC6oWjiCI8fPOVrQNwc6zzPNWaOZHYIXBYANO&#xa;s4BHt85qxzpE1yor8/xp1oGrrQMuvMe/V0OQLhN+0wge3jWNF4GoimJvIa0urau4ZssFm68ds63k&#xa;+zbYP3ShmTRY9AB1xQIjGyf/gtKSO/DQhBEHnUHTSC4SB2RT5H+wuW2ZFYkLiuPtQSb//2D52+17&#xa;R2Rd0Rklhmkc0cOX3ffdt91P8vB194PMokSd9XPMvLWYG/rn0OOoE11vb4B/8sTAZcvMWlw4B10r&#xa;WI0tFvFmdnJ1wPERZNW9gRprsU2ABNQ3TpNGSfvqNzRqQ7AODu3uMCjRB8Jj8bIoJlMMcYyVs3x6&#xa;liaZsXnEiXOwzoeXAjSJm4o6NEKqw7Y3PsS+jikx3cC1VCqZQRnSoRqTcpIunES0DOhVJXVFp3n8&#xa;BvdEui9MnS4HJtWwxwLK7PlHygP50K/6pPZZUieKs4L6DhVxMHgT3xJuWnD3lHToy4r6zxvmBCXq&#xa;tUFVZ8V4HI2cDuPJsxIP7jSyOo0wwxGqooGSYXsZkvkHzheofiOTHMdO9j2j35JK+7cRDX16TlnH&#xa;F7z8BQAA//8DAFBLAwQUAAYACAAAACEAJ2kGcOIAAAALAQAADwAAAGRycy9kb3ducmV2LnhtbEyP&#xa;y07DMBBF90j8gzVI7KgTyKOEOBVCQmKRIhqQytKNp3HU2I5itw1/32EFy5l7dOdMuZrNwE44+d5Z&#xa;AfEiAoa2daq3nYCvz9e7JTAfpFVycBYF/KCHVXV9VcpCubPd4KkJHaMS6wspQIcwFpz7VqORfuFG&#xa;tJTt3WRkoHHquJrkmcrNwO+jKONG9pYuaDnii8b20ByNAFVvt2l+GOuN/k72b8O7qpuPtRC3N/Pz&#xa;E7CAc/iD4Vef1KEip507WuXZIOAhzXJCKUjiGBgRaZKnwHa0WWaPwKuS//+hugAAAP//AwBQSwEC&#xa;LQAUAAYACAAAACEAtoM4kv4AAADhAQAAEwAAAAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRfVHlwZXNd&#xa;LnhtbFBLAQItABQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAAAAAAAAAAAAAAC8BAABfcmVscy8u&#xa;cmVsc1BLAQItABQABgAIAAAAIQDKY7PdJAIAAAkEAAAOAAAAAAAAAAAAAAAAAC4CAABkcnMvZTJv&#xa;RG9jLnhtbFBLAQItABQABgAIAAAAIQAnaQZw4gAAAAsBAAAPAAAAAAAAAAAAAAAAAH4EAABkcnMv&#xa;ZG93bnJldi54bWxQSwUGAAAAAAQABADzAAAAjQUAAAAA&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00C91656">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:rtl/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Orphan_Birthday.ToString("yyyy/MM/dd") %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                           <w:r w:rsidR="00AB47DB">
                               <w:rPr>
                                   <w:noProof/>
                                   <w:rtl/>
                               </w:rPr>
                               <mc:AlternateContent>
                                   <mc:Choice Requires="wps">
                                       <w:drawing>
                                           <wp:anchor distT="45720" distB="45720" distL="114300" distR="114300" simplePos="0" relativeHeight="251640832" behindDoc="0" locked="0" layoutInCell="1" allowOverlap="1" wp14:anchorId="5A8F8BEE" wp14:editId="4FF80566">
                                               <wp:simplePos x="0" y="0"/>
                                               <wp:positionH relativeFrom="column">
                                                   <wp:posOffset>3475828</wp:posOffset>
                                               </wp:positionH>
                                               <wp:positionV relativeFrom="paragraph">
                                                   <wp:posOffset>897255</wp:posOffset>
                                               </wp:positionV>
                                               <wp:extent cx="1221105" cy="290830"/>
                                               <wp:effectExtent l="0" t="0" r="0" b="0"/>
                                               <wp:wrapNone/>
                                               <wp:docPr id="8" name="مربع نص 2"/>
                                               <wp:cNvGraphicFramePr>
                                                   <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                                               </wp:cNvGraphicFramePr>
                                               <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                                   <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                                                       <wps:wsp>
                                                           <wps:cNvSpPr txBox="1">
                                                               <a:spLocks noChangeArrowheads="1"/>
                                                           </wps:cNvSpPr>
                                                           <wps:spPr bwMode="auto">
                                                               <a:xfrm flipH="1">
                                                                   <a:off x="0" y="0"/>
                                                                   <a:ext cx="1221105" cy="290830"/>
                                                               </a:xfrm>
                                                               <a:prstGeom prst="rect">
                                                                   <a:avLst/>
                                                               </a:prstGeom>
                                                               <a:noFill/>
                                                               <a:ln w="9525">
                                                                   <a:noFill/>
                                                                   <a:miter lim="800000"/>
                                                                   <a:headEnd/>
                                                                   <a:tailEnd/>
                                                               </a:ln>
                                                           </wps:spPr>
                                                           <wps:txbx>
                                                               <w:txbxContent>
                                                                   <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00C91656">
                                                                       <w:pPr>
                                                                           <w:jc w:val="center"/>
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                       </w:pPr>
                                                                       <w:r w:rsidRPr="00455C15">
                                                                           <w:rPr>
                                                                               <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                               <w:b/>
                                                                               <w:bCs/>
                                                                               <w:lang w:bidi="ar-SY"/>
                                                                           </w:rPr>
                                                                           <w:t><%= Data.Orphan_FirstName %></w:t>
                                                                       </w:r>
                                                                   </w:p>
                                                               </w:txbxContent>
                                                           </wps:txbx>
                                                           <wps:bodyPr rot="0" vert="horz" wrap="square" lIns="91440" tIns="45720" rIns="91440" bIns="45720" anchor="t" anchorCtr="0">
                                                               <a:noAutofit/>
                                                           </wps:bodyPr>
                                                       </wps:wsp>
                                                   </a:graphicData>
                                               </a:graphic>
                                               <wp14:sizeRelH relativeFrom="margin">
                                                   <wp14:pctWidth>0</wp14:pctWidth>
                                               </wp14:sizeRelH>
                                               <wp14:sizeRelV relativeFrom="margin">
                                                   <wp14:pctHeight>0</wp14:pctHeight>
                                               </wp14:sizeRelV>
                                           </wp:anchor>
                                       </w:drawing>
                                   </mc:Choice>
                                   <mc:Fallback>
                                       <w:pict>
                                           <v:shape w14:anchorId="5A8F8BEE" id="_x0000_s1058" type="#_x0000_t202" style="position:absolute;left:0;text-align:left;margin-left:273.7pt;margin-top:70.65pt;width:96.15pt;height:22.9pt;flip:x;z-index:251640832;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:text;mso-position-vertical:absolute;mso-position-vertical-relative:text;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top" o:gfxdata="UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF&#xa;90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA&#xa;0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD&#xa;OlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893&#xa;SUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y&#xa;JsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl&#xa;bHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR&#xa;JVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY&#xa;22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i&#xa;OWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA&#xa;IQBw+I5uJQIAAAkEAAAOAAAAZHJzL2Uyb0RvYy54bWysU81uEzEQviPxDpbvZH+aQLPKpiotBaTy&#xa;IxUewPF6sxa2x9hOdts7PAtXDhx4k/RtGHtDGsENsQfL3hl/M983nxdng1ZkK5yXYGpaTHJKhOHQ&#xa;SLOu6ccPV09OKfGBmYYpMKKmt8LTs+XjR4veVqKEDlQjHEEQ46ve1rQLwVZZ5nknNPMTsMJgsAWn&#xa;WcCjW2eNYz2ia5WVef4068E11gEX3uPfyzFIlwm/bQUP79rWi0BUTbG3kFaX1lVcs+WCVWvHbCf5&#xa;vg32D11oJg0WPUBdssDIxsm/oLTkDjy0YcJBZ9C2kovEAdkU+R9sbjpmReKC4nh7kMn/P1j+dvve&#xa;EdnUFAdlmMYR3X/Zfd992/0k9193P0gZJeqtrzDzxmJuGJ7DgKNOdL29Bv7JEwMXHTNrce4c9J1g&#xa;DbZYxJvZ0dURx0eQVf8GGqzFNgES0NA6TVol7avf0KgNwTo4tNvDoMQQCI/Fy7Io8hklHGPlPD89&#xa;SZPMWBVx4hys8+GlAE3ipqYOjZDqsO21D7Gvh5SYbuBKKpXMoAzpazqflbN04SiiZUCvKqlRrDx+&#xa;o3si3RemSZcDk2rcYwFl9vwj5ZF8GFZDUvvkoOsKmltUxMHoTXxLuOnA3VHSoy9r6j9vmBOUqNcG&#xa;VZ0X02k0cjpMZ89KPLjjyOo4wgxHqJoGSsbtRUjmHzmfo/qtTHLEMY2d7HtGvyWV9m8jGvr4nLIe&#xa;XvDyFwAAAP//AwBQSwMEFAAGAAgAAAAhAORVyhPiAAAACwEAAA8AAABkcnMvZG93bnJldi54bWxM&#xa;j8FOwzAMhu9IvENkJG4sLevIKE0nhITEoSBWkMYxa7ymWpNUTbaVt593gqP9f/r9uVhNtmdHHEPn&#xa;nYR0lgBD13jduVbC99fr3RJYiMpp1XuHEn4xwKq8vipUrv3JrfFYx5ZRiQu5kmBiHHLOQ2PQqjDz&#xa;AzrKdn60KtI4tlyP6kTltuf3SfLAreocXTBqwBeDzb4+WAm62mwWYj9Ua/OT7d76D13Vn+9S3t5M&#xa;z0/AIk7xD4aLPqlDSU5bf3A6sF7CIhMZoRRk6RwYEWL+KIBtabMUKfCy4P9/KM8AAAD//wMAUEsB&#xa;Ai0AFAAGAAgAAAAhALaDOJL+AAAA4QEAABMAAAAAAAAAAAAAAAAAAAAAAFtDb250ZW50X1R5cGVz&#xa;XS54bWxQSwECLQAUAAYACAAAACEAOP0h/9YAAACUAQAACwAAAAAAAAAAAAAAAAAvAQAAX3JlbHMv&#xa;LnJlbHNQSwECLQAUAAYACAAAACEAcPiObiUCAAAJBAAADgAAAAAAAAAAAAAAAAAuAgAAZHJzL2Uy&#xa;b0RvYy54bWxQSwECLQAUAAYACAAAACEA5FXKE+IAAAALAQAADwAAAAAAAAAAAAAAAAB/BAAAZHJz&#xa;L2Rvd25yZXYueG1sUEsFBgAAAAAEAAQA8wAAAI4FAAAAAA==&#xa;" filled="f" stroked="f">
                                               <v:textbox>
                                                   <w:txbxContent>
                                                       <w:p w:rsidR="007F2F25" w:rsidRPr="00455C15" w:rsidRDefault="00C91656" w:rsidP="00C91656">
                                                           <w:pPr>
                                                               <w:jc w:val="center"/>
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                           </w:pPr>
                                                           <w:r w:rsidRPr="00455C15">
                                                               <w:rPr>
                                                                   <w:rFonts w:asciiTheme="minorBidi" w:hAnsiTheme="minorBidi"/>
                                                                   <w:b/>
                                                                   <w:bCs/>
                                                                   <w:lang w:bidi="ar-SY"/>
                                                               </w:rPr>
                                                               <w:t><%= Data.Orphan_FirstName %></w:t>
                                                           </w:r>
                                                       </w:p>
                                                   </w:txbxContent>
                                               </v:textbox>
                                           </v:shape>
                                       </w:pict>
                                   </mc:Fallback>
                               </mc:AlternateContent>
                           </w:r>
                       </w:p>
                       <w:sectPr w:rsidR="005734CD" w:rsidRPr="007A6B2D" w:rsidSect="00E86C95">
                           <w:headerReference w:type="default" r:id="rId9"/>
                           <w:pgSz w:w="11906" w:h="16838"/>
                           <w:pgMar w:top="180" w:right="26" w:bottom="180" w:left="720" w:header="283" w:footer="1757" w:gutter="0"/>
                           <w:cols w:space="708"/>
                           <w:bidi/>
                           <w:rtlGutter/>
                           <w:docGrid w:linePitch="360"/>
                       </w:sectPr>
                   </w:body>
               </w:document>
    End Sub

    Public Sub New(ByVal Data As _MaktabData)
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
            File.WriteAllBytes(TempPath, My.Resources.Maktab1)
            Using TempDoc As WordprocessingDocument = WordprocessingDocument.Open(TempPath, True)
                Dim MainP = TempDoc.MainDocumentPart
                Using sw As New StreamWriter(MainP.GetStream(FileMode.Create))
                    _Document.Save(sw)
                End Using
                If Not IsNothing(_Data.Orphan_FacePhoto) Then
                    Try
                        Dim img = MainP.GetPartById("rId8")
                        Using ss As New MemoryStream(_Data.Orphan_FacePhoto)
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
End Class
