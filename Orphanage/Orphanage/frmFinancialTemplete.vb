Imports System.IO
Imports <xmlns="urn:OrphanageXML:FinancialTemplates">
Imports Telerik.WinControls.UI

Public Class FrmFinancialTemplete
    Public Shared xmlFileName As String = CurDir() & "\FinanTemplets.xaml"
    Private _Name As String = ""

    Public Shared Function DeleteTemplete(ByVal tName As String)
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
                    <IsBookmarks>
                        <%= chkTempIsBookmark.Checked %>
                    </IsBookmarks>
                    <UseCustomBoolean>
                        <%= chkUseCustomBoolean.Checked %>
                    </UseCustomBoolean>
                    <BooleanFontName><%= txtBooleanFont.Text %></BooleanFontName>
                    <BooleanYesMark>
                        <%= IIf(chkUseCustomBoolean.Checked, txtBoolYES.Value, "نعم") %>
                    </BooleanYesMark>
                    <BooleanNOMark>
                        <%= IIf(chkUseCustomBoolean.Checked, txtBoolNO.Value, "لا") %>
                    </BooleanNOMark>
                    <Data>
                        <%= System.Convert.ToBase64String(bytes, Base64FormattingOptions.None) %>
                    </Data>
                    <Bookmarks>
                        <Father>
                            <FullName><%= txtFatherName.Text %></FullName>
                            <DeathDay><%= txtDeathDay.Text %></DeathDay>
                            <Age><%= txtFatherAge.Text %></Age>
                            <Jop><%= txtFatherJop.Text %></Jop>
                            <DeathReason><%= txtFatherDeathReson.Text %></DeathReason>
                        </Father>
                        <Mother>
                            <FullName><%= txtMotherName.Text %></FullName>
                            <IsOwnOrphan><%= txtMotherIsOwnOrphan.Text %></IsOwnOrphan>
                            <ID><%= txtMotherIDNumber.Text %></ID>
                            <Jop><%= txtMotherJop.Text %></Jop>
                            <Age><%= txtMotherAge.Text %></Age>
                        </Mother>
                        <Supporter>
                            <FullName><%= txtSupporterName.Text %></FullName>
                            <Address><%= txtSupporterAddress.Text %></Address>
                            <Note><%= txtSupporterNote.Text %></Note>
                        </Supporter>
                        <Address>
                            <Full><%= txtAddressFull.Text %></Full>
                            <Phone><%= txtAddressPhone.Text %></Phone>
                            <Mobile><%= txtAddressMobile.Text %></Mobile>
                        </Address>
                        <Salaries>
                            <Family><%= txtFamilySalary.Text %></Family>
                            <Orphan><%= txtOrphanSalary.Text %></Orphan>
                            <BondsMan><%= txtBondsManSalary.Text %></BondsMan>
                            <OrphanCount><%= txtOrphansCount.Text %></OrphanCount>
                            <Bail><%= txtBailSalary.Text %></Bail>
                        </Salaries>
                        <Numbers>
                            <IsSerial><%= optNumberSerial.IsChecked %></IsSerial>
                            <IsFather><%= optNumberFAther.IsChecked %></IsFather>
                            <IsMother><%= optNumberMother.IsChecked %></IsMother>
                            <ISFamily><%= optNumberFAm.IsChecked %></ISFamily>
                            <BookMArk><%= txtNumbers.Text %></BookMArk>
                        </Numbers>
                        <Detials>
                            <OrphansNames><%= txtOrphansNames.Text %></OrphansNames>
                            <OrphansSalayies><%= txtOrphansSalaries.Text %></OrphansSalayies>
                            <OrphansNamesSala><%= txtOrphansNameSala.Text %></OrphansNamesSala>
                        </Detials>
                        <Date>
                            <IsSpecific><%= optSpecificDate.IsChecked %></IsSpecific>
                            <IsNow><%= optNowDAte.IsChecked %></IsNow>
                            <SpecificDate><%= dteSpecificDate.Value %></SpecificDate>
                            <BookMark><%= txtDate.Text %></BookMark>
                        </Date>
                    </Bookmarks>
                </Template>
        Return x
    End Function


    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        If FontDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtBooleanFont.Text = FontDialog1.Font.Name
        End If
    End Sub

    Private Sub btnChooseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseFile.Click
        Dim Ofd As New OpenFileDialog()
        Ofd.Filter = "ملفات وورد|*.Docx"
        Ofd.Title = "اختر ملف وورد"
        If Ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtTempPath.Text = Ofd.FileName
        End If
        Ofd.Dispose()
    End Sub

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
        Me.Close()
    End Sub

    Private Sub FrmFinancialTemplete_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not File.Exists(xmlFileName) Then
            Dim xw As Xml.XmlWriter = Xml.XmlWriter.Create(xmlFileName)
            xw.WriteStartDocument()
            xw.WriteElementString("Templates", "urn:OrphanageXML:FinancialTemplates", "")
            'xw.WriteEndElement()
            xw.WriteEndDocument()
            xw.Flush()
            xw.Close()
        End If
        Me.dteSpecificDate.CustomFormat = My.Settings.GeneralDateFormat
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
                    chkUseCustomBoolean.Checked = CBool(xele.<UseCustomBoolean>.Value)
                    txtBooleanFont.Text = xele.<BooleanFontName>.Value()
                    chkTempIsBookmark.Checked = CBool(xele.<IsBookmarks>.Value)
                    If IsNumeric(xele.<BooleanNOMark>.Value) Then
                        txtBoolNO.Value = CInt(xele.<BooleanNOMark>.Value)
                    End If
                    If IsNumeric(xele.<BooleanYesMark>.Value) Then
                        txtBoolYES.Value = CInt(xele.<BooleanYesMark>.Value)
                    End If
                    'Address
                    txtAddressFull.Text = xele.<Bookmarks>.<Address>.<Full>.Value
                    txtAddressMobile.Text = xele.<Bookmarks>.<Address>.<Mobile>.Value
                    txtAddressPhone.Text = xele.<Bookmarks>.<Address>.<Phone>.Value
                    'Salaries
                    txtBailSalary.Text = xele.<Bookmarks>.<Salaries>.<Bail>.Value
                    txtBondsManSalary.Text = xele.<Bookmarks>.<Salaries>.<BondsMan>.Value
                    txtOrphanSalary.Text = xele.<Bookmarks>.<Salaries>.<Orphan>.Value
                    txtOrphansCount.Text = xele.<Bookmarks>.<Salaries>.<OrphanCount>.Value
                    txtFamilySalary.Text = xele.<Bookmarks>.<Salaries>.<Family>.Value
                    'Date
                    txtDate.Text = xele.<Bookmarks>.<Date>.<BookMark>.Value
                    optSpecificDate.IsChecked = CBool(xele.<Bookmarks>.<Date>.<IsSpecific>.Value)
                    optNowDAte.IsChecked = CBool(xele.<Bookmarks>.<Date>.<IsNow>.Value)
                    dteSpecificDate.Value = CDate(xele.<Bookmarks>.<Date>.<SpecificDate>.Value)
                    'Father
                    txtDeathDay.Text = xele.<Bookmarks>.<Father>.<DeathDay>.Value
                    txtFatherAge.Text = xele.<Bookmarks>.<Father>.<Age>.Value
                    txtFatherDeathReson.Text = xele.<Bookmarks>.<Father>.<DeathReason>.Value
                    txtFatherJop.Text = xele.<Bookmarks>.<Father>.<Jop>.Value
                    txtFatherName.Text = xele.<Bookmarks>.<Father>.<FullName>.Value
                    'Mother
                    txtMotherAge.Text = xele.<Bookmarks>.<Mother>.<Age>.Value
                    txtMotherIDNumber.Text = xele.<Bookmarks>.<Mother>.<ID>.Value
                    txtMotherIsOwnOrphan.Text = xele.<Bookmarks>.<Mother>.<IsOwnOrphan>.Value
                    txtMotherJop.Text = xele.<Bookmarks>.<Mother>.<Jop>.Value
                    txtMotherName.Text = xele.<Bookmarks>.<Mother>.<FullName>.Value
                    'Numbers
                    txtNumbers.Text = xele.<Bookmarks>.<Numbers>.<BookMArk>.Value
                    optNumberFAm.IsChecked = CBool(xele.<Bookmarks>.<Numbers>.<ISFamily>.Value)
                    optNumberFAther.IsChecked = CBool(xele.<Bookmarks>.<Numbers>.<IsFather>.Value)
                    optNumberMother.IsChecked = CBool(xele.<Bookmarks>.<Numbers>.<IsMother>.Value)
                    optNumberSerial.IsChecked = CBool(xele.<Bookmarks>.<Numbers>.<IsSerial>.Value)
                    'Details
                    txtOrphansNames.Text = xele.<Bookmarks>.<Detials>.<OrphansNames>.Value
                    txtOrphansSalaries.Text = xele.<Bookmarks>.<Detials>.<OrphansSalayies>.Value
                    txtOrphansNameSala.Text = xele.<Bookmarks>.<Detials>.<OrphansNamesSala>.Value
                    'Supporter
                    txtSupporterAddress.Text = xele.<Bookmarks>.<Supporter>.<Address>.Value
                    txtSupporterName.Text = xele.<Bookmarks>.<Supporter>.<FullName>.Value
                    txtSupporterNote.Text = xele.<Bookmarks>.<Supporter>.<Note>.Value
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

    Private Sub optSpecificDate_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles optSpecificDate.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            dteSpecificDate.Enabled = True
        Else
            dteSpecificDate.Enabled = False
        End If
    End Sub
End Class
