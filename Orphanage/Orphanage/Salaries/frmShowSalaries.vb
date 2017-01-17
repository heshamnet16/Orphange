Imports Telerik.WinControls.UI
Imports System.IO
Imports <xmlns:b="urn:OrphanageXML:FinancialTemplates">
Imports System.Text

Public Class FrmShowSalaries
    Private StrCount As String = ""
    Dim SerialNumber As Integer = 0
    Dim _StopValidation As Boolean = False
    Public ViewStatics As New FinancialData
    'GridViewDecimalColumn1.Name = "ID"
    'GridViewTextBoxColumn1.Name = "FatherName"
    'GridViewTextBoxColumn2.Name = "FatherAge"
    'GridViewTextBoxColumn3.Name = "FatherDeathReason"
    'GridViewTextBoxColumn4.Name = "FatherDeath"
    'GridViewTextBoxColumn5.Name = "FatherJop"
    'GridViewTextBoxColumn6.Name = "MotherName"
    'GridViewTextBoxColumn7.Name = "MotherAge"
    'GridViewTextBoxColumn8.Name = "MotherJop"
    'GridViewTextBoxColumn9.Name = "MotherID"
    'GridViewCheckBoxColumn1.Name = "MotherIsOwnOrphan"
    'GridViewTextBoxColumn10.Name = "OrphanCount"
    'GridViewTextBoxColumn11.Name = "OrphanNames"
    'GridViewCheckBoxColumn2.Name = "IsBailedFam"
    'GridViewCalculatorColumn1.Name = "Salary"
    'GridViewTextBoxColumn12.Name = "CurrencyShort"
    'GridViewTextBoxColumn13.Name = "OrphansNamesSalaries"
    'GridViewTextBoxColumn14.Name = "OrphansSalaries"
    'GridViewTextBoxColumn15.Name = "OrphanSalary"
    'GridViewTextBoxColumn16.Name = "BailSalary"
    'GridViewTextBoxColumn17.Name = "BondsManSalary"
    'GridViewTextBoxColumn18.Name = "SupporterName"
    'GridViewTextBoxColumn19.Name = "SupporterAddress"
    'GridViewTextBoxColumn20.Name = "SupporterNote"
    'GridViewTextBoxColumn21.Name = "PhoneNumber"
    'GridViewTextBoxColumn22.Name = "MobileNumber"
    'GridViewTextBoxColumn23.Name = "Address"
    'GridViewTextBoxColumn24.Name = "Date"

#Region "UpdateRows"
    Private Sub AddNewFinancialFam(ByVal Id As Integer, ByVal Data As FinancialData)
        Try
            'If Data.IsBailed Then Stop
            _StopValidation = True
            Using Odb As New OrphanageDB.Odb
                Odb.ObjectTrackingEnabled = False
                Dim Fam = Getter.GetFamilyByID(Id, Odb)
                Dim xx As GridViewRowInfo = radDataGrid.Rows.AddNew()
                If ViewStatics.IsFamilyNumber Then
                    xx.Cells("ID").Value = Id
                ElseIf ViewStatics.IsFatherNumber Then
                    xx.Cells("ID").Value = Fam.Father_ID
                ElseIf ViewStatics.IsMotherNumber Then
                    xx.Cells("ID").Value = Fam.Mother_ID
                Else
                    SerialNumber += 1
                    xx.Cells("ID").Value = Me.SerialNumber
                End If
                Dim qfther = From fath In Odb.Fathers Where fath.ID = Fam.Father_ID Select fath, fath.Name
                Dim ssFather = qfther.FirstOrDefault()
                xx.Cells("FatherName").Value = Getter.GetFullName(ssFather.Name)
                If Not IsNothing(ssFather.fath.Birthday) Then
                    Dim df As New Itenso.TimePeriod.DateDiff(ssFather.fath.Birthday, ssFather.fath.Dieday)
                    xx.Cells("FatherAge").Value = ATDFormater.ArabicDateFormater.GetArabicYear(df.ElapsedYears)
                End If
                xx.Cells("FatherDeathReason").Value = ssFather.fath.DeathResone
                xx.Cells("FatherDeath").Value = ssFather.fath.Dieday.ToString("yyyy/MM")
                xx.Cells("FatherJop").Value = ssFather.fath.Jop
                Dim qMoth = From mot In Odb.Mothers Where mot.ID = Fam.Mother_ID Select mot.Name, mot
                Dim ssMother = qMoth.FirstOrDefault()
                xx.Cells("MotherName").Value = Getter.GetFullName(ssMother.Name)
                If ssMother.mot.Dieday.HasValue AndAlso ssMother.mot.IsDead Then
                    Dim df As New Itenso.TimePeriod.DateDiff(ssMother.mot.Birthday, ssMother.mot.Dieday.Value)
                    xx.Cells("MotherAge").Value = ATDFormater.ArabicDateFormater.GetArabicYear(df.ElapsedYears)
                Else
                    Dim df As New Itenso.TimePeriod.DateDiff(ssMother.mot.Birthday, Date.Now)
                    xx.Cells("MotherAge").Value = ATDFormater.ArabicDateFormater.GetArabicYear(df.ElapsedYears)
                End If
                xx.Cells("MotherJop").Value = ssMother.mot.Jop
                xx.Cells("MotherID").Value = ssMother.mot.IdntityCard_ID
                xx.Cells("MotherIsOwnOrphan").Value = ssMother.mot.IsOwnOrphans
                xx.Cells("OrphanCount").Value = Data.OrphansCount
                For Each tr As String In Data.OrphansNames
                    If IsNothing(xx.Cells("OrphanNames").Value) OrElse xx.Cells("OrphanNames").Value.ToString().Length = 0 Then
                        xx.Cells("OrphanNames").Value = tr
                    Else
                        xx.Cells("OrphanNames").Value = xx.Cells("OrphanNames").Value.ToString() & "-" & tr
                    End If
                Next
                xx.Cells("IsBailedFam").Value = Data.IsBailed
                xx.Cells("Salary").Value = Data.Salary
                xx.Cells("CurrencyShort").Value = Data.Currency_short
                'xx.Cells("OrphansNamesSalaries").Value = Data.OrphansCoun
                For Each tr As String In Data.OrphansNamesSalary
                    If IsNothing(xx.Cells("OrphansNamesSalaries").Value) OrElse xx.Cells("OrphansNamesSalaries").Value.ToString().Length = 0 Then
                        xx.Cells("OrphansNamesSalaries").Value = tr
                    Else
                        xx.Cells("OrphansNamesSalaries").Value = xx.Cells("OrphansNamesSalaries").Value.ToString() & vbNewLine & tr
                    End If
                Next
                For Each tr As String In Data.OrphansSalary
                    If IsNothing(xx.Cells("OrphansSalaries").Value) OrElse xx.Cells("OrphansSalaries").Value.ToString().Length = 0 Then
                        xx.Cells("OrphansSalaries").Value = tr
                    Else
                        xx.Cells("OrphansSalaries").Value = xx.Cells("OrphansSalaries").Value.ToString() & "-" & tr
                    End If
                Next
                xx.Cells("OrphanSalary").Value = Data.OrphanSalary
                xx.Cells("BailSalary").Value = Data.BailSalary
                xx.Cells("BondsManSalary").Value = Data.BondsManSalary
                If Data.IsBailed Then
                    xx.Cells("SupporterName").Value = Data.SuporterName
                    xx.Cells("SupporterAddress").Value = Data.SupporterAddress
                    xx.Cells("SupporterNote").Value = Data.supporterNote
                Else
                    xx.Cells("SupporterName").Value = "غير مكفولة"
                    xx.Cells("SupporterAddress").Value = ""
                    xx.Cells("SupporterNote").Value = ""
                End If
                If Fam.Address_ID2.HasValue Then
                    Dim qAdd1 = From add In Odb.Addresses Where add.ID = Fam.Address_ID2 Select add
                    xx.Cells("PhoneNumber").Value = qAdd1.FirstOrDefault().Home_Phone
                    xx.Cells("MobileNumber").Value = qAdd1.FirstOrDefault().Cell_Phone
                    xx.Cells("Address").Value = Getter.GetAddress(qAdd1.FirstOrDefault())
                Else
                    If Fam.Address_ID.HasValue Then
                        Dim qAdd1 = From add In Odb.Addresses Where add.ID = Fam.Address_ID Select add
                        xx.Cells("PhoneNumber").Value = qAdd1.FirstOrDefault().Home_Phone
                        xx.Cells("MobileNumber").Value = qAdd1.FirstOrDefault().Cell_Phone
                        xx.Cells("Address").Value = Getter.GetAddress(qAdd1.FirstOrDefault())
                    Else
                        xx.Cells("Address").Value = "يا أخي ليش ماتدخل العنوان" & vbNewLine & "والله مايصير"
                    End If
                End If
                If ViewStatics.IsSpecificDate Then
                    xx.Cells("Date").Value = Data.SpecificDate.ToString(My.Settings.GeneralDateFormat)
                Else
                    xx.Cells("Date").Value = Date.Now.ToString(My.Settings.GeneralDateFormat)
                End If
                If Data.HasErrors Then
                    For Each cel As GridViewCellInfo In xx.Cells
                        cel.Style.CustomizeFill = True
                        cel.Style.DrawFill = True
                        cel.Style.ForeColor = Color.Red
                        cel.Style.BackColor = Color.Black
                    Next
                End If
                Odb.Dispose()
            End Using
            _StopValidation = False
        Catch ex As Exception
            _StopValidation = False
        End Try
    End Sub
#End Region
    Public Structure FinancialData
        Public OrphanSalary As String
        Public BondsManSalary As String
        Public BailSalary As String
        Public OrphansNames As ArrayList
        Public OrphansSalary As ArrayList
        Public OrphansNamesSalary As ArrayList
        Public OrphansCount As Integer
        Public Salary As Decimal
        Public Currency_short As String
        Public IsSerialNumbers As Boolean
        Public IsFatherNumber As Boolean
        Public IsMotherNumber As Boolean
        Public IsFamilyNumber As Boolean
        Public IsSpecificDate As Boolean
        Public IsNowDate As Boolean
        Public SpecificDate As Date
        Public IsBailed As Boolean
        Public SuporterName As String
        Public supporterNote As String
        Public SupporterAddress As String
        Public HasErrors As Boolean
    End Structure
    Public Data As Dictionary(Of Integer, FinancialData)
    Public Sub New(ByVal Data As Dictionary(Of Integer, FinancialData))
        InitializeComponent()
        Me.Data = Data
    End Sub
    Public Function GetPrintedDocumnent() As Telerik.WinControls.UI.RadPrintDocument
        Return Me.RadPrintDocument1
    End Function
    Public Function GetGridView() As Telerik.WinControls.UI.RadGridView
        Return Me.radDataGrid
    End Function
    Public Sub PrintDocument(ByVal doc As RadPrintDocument)
        Me.radDataGrid.Print(True, doc)
    End Sub
    Public Sub SetGridFont(ByVal fon As Font)
        Me.Font = fon
        radDataGrid.Font = fon
        radDataGrid.PrintStyle.CellFont = fon
        radDataGrid.Refresh()
    End Sub
    Private Sub LoadData()
        Try
            Dim i As Integer = 0
            Dim all As Integer = 0
            Dim PerValue = 0, LastPerValue As Integer = 0
            If IsNothing(Data) OrElse Data.Count = 0 Then Return
            all = Data.Count
            If radDataGrid.Rows.Count > 0 Then radDataGrid.Rows.Clear()
            SerialNumber = 0
            For Each fam In Data.Keys
                PerValue = CInt(Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100)))
                AddNewFinancialFam(fam, Data(fam))
                i += 1
                If LastPerValue <> PerValue Then
                    ProgressSate.ShowStatueProgress(PerValue, "")
                    LastPerValue = PerValue
                End If
            Next
            ProgressSate.ShowStatueProgress(100, "")
            If radDataGrid.RowCount > 0 Then
                StrCount = "العدد الكلي " & radDataGrid.RowCount
                lblStatus.Text = StrCount
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try

    End Sub

    Private Sub FrmShowSalaries_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If File.Exists("ShowSala.xaml") AndAlso My.Settings.SaveGridState Then
            radDataGrid.LoadLayout("ShowSala.xaml")
        End If
        Layouts.LoadFormLayout(Me)
        radDataGrid.TableElement.GridViewElement.GroupPanelElement.Text = "اسحب الاعمدة هنا"
        For Each elm In radDataGrid.TableElement.GridViewElement.GroupPanelElement.Children
            For Each elm1 In elm.Children
                For Each elm2 In elm1.Children
                    If TypeOf elm2 Is LightVisualElement Then
                        Dim Xobj As LightVisualElement = CType(elm2, LightVisualElement)
                        If Xobj.Text = "Group by:" Then
                            Xobj.Text = "تجميع بواسطة : "
                            Exit For
                        End If
                    End If
                Next
            Next
        Next
        LoadData()
    End Sub

    Private Sub radDataGrid_CreateCell(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCreateCellEventArgs) Handles radDataGrid.CreateCell
        If _StopValidation Then Exit Sub
        If IsNothing(e.CellType) Then Return
        If e.CellType.FullName.Contains("FilterCellElement") Then
            Dim cell As New GridFilterCellElement(CType(e.Column, GridViewDataColumn), e.Row)
            cell.FilterButton.Enabled = False
            e.CellElement = cell
            e.CellType = cell.GetType()
        End If
        If e.CellType.FullName.Contains("FilterCheckBoxCellElement") Then
            Dim cell As New GridFilterCheckBoxCellElement(CType(e.Column, GridViewDataColumn), e.Row)
            cell.FilterButton.Enabled = False
            cell.FilterButton.AutoSize = False
            cell.FilterButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
            cell.FilterButton.Size = New Size(1, 1)
            e.CellElement = cell
            e.CellType = cell.GetType()
        End If
    End Sub

    Private Sub radDataGrid_GroupByChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCollectionChangedEventArgs) Handles radDataGrid.GroupByChanged
        radDataGrid.TableElement.GridViewElement.GroupPanelElement.Text = "اسحب الاعمدة هنا"
        For Each elm In radDataGrid.TableElement.GridViewElement.GroupPanelElement.Children
            For Each elm1 In elm.Children
                For Each elm2 In elm1.Children
                    If TypeOf elm2 Is LightVisualElement Then
                        Dim Xobj As LightVisualElement = CType(elm2, LightVisualElement)
                        If Xobj.Text = "Group by:" Then
                            Xobj.Text = "تجميع بواسطة : "
                            Exit For
                        End If
                    End If
                Next
            Next
        Next
    End Sub

    Private Sub FrmShowSalar_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If My.Settings.SaveGridState Then
            radDataGrid.SaveLayout("ShowSala.Xaml")
        End If
        If My.Settings.SaveWindowsState Then
            Layouts.SaveFormLayout(Me)
        End If
    End Sub

    Private Sub btnColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColumn.Click
        radDataGrid.ColumnChooser.Text = "الأعمدة"
        radDataGrid.ColumnChooser.ColumnChooserControl.ColumnChooserElement.Text = "اسحب الأعمدة من و إلى الشبكة"
        radDataGrid.ColumnChooser.Show()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        Try
            Dim DeletedRows As New ArrayList()
            For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                DeletedRows.Add(row)
            Next
            For Each row As Telerik.WinControls.UI.GridViewRowInfo In DeletedRows
                row.IsVisible = False
                radDataGrid.Rows.Remove(row)
            Next
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
        StrCount = "العدد الكلي " & radDataGrid.RowCount
        lblStatus.Text = StrCount
    End Sub

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

    Private Sub btnToWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToWord.Click
        If IsNothing(radDataGrid.SelectedRows) OrElse radDataGrid.SelectedRows.Count = 0 Then Return
        Dim SavedFiles As New ArrayList()
        Dim i As Decimal = 0D
        Dim FileName As String
        Dim FullPath As String
        If radDataGrid.SelectedRows.Count = 1 Then
            FileName = ShowWordSave()
        Else
            FileName = ShowWordSaveFolder()
        End If
        If IsNothing(FileName) Then Return
        For Each row As GridViewRowInfo In radDataGrid.SelectedRows
            Dim Destination_FileName As String
            If radDataGrid.SelectedRows.Count = 1 Then
                Destination_FileName = FileName
            Else
                If My.Settings.WordMakeNewFolder Then
                    FullPath = FileName & "\" & row.Cells("FatherName").Value.ToString()
                    If Not Directory.Exists(FullPath) Then
                        Directory.CreateDirectory(FullPath)
                    End If
                    If My.Settings.WordUseOrphanName Then
                        Destination_FileName = FullPath & "\" & row.Cells("FatherName").Value.ToString() & ".Docx"
                    Else
                        Destination_FileName = FullPath & "\" & row.Cells("ID").Value.ToString() & ".Docx"
                    End If
                Else
                    If My.Settings.WordUseOrphanName Then
                        Destination_FileName = FileName & "\" & row.Cells("FatherName").Value.ToString() & ".Docx"
                    Else
                        Destination_FileName = FileName & "\" & row.Cells("ID").Value.ToString() & ".Docx"
                    End If
                End If
            End If
            If My.Settings.WordFinancialTemplete = "افتراضي" Then
                Dim wordData As WordTemletes.FinancailCard.FinancialData = Fill_Maktab1_Data(row)
                Dim Word3Taa2 As New WordTemletes.FinancailCard(wordData)
                Word3Taa2.CreateWordFile(Destination_FileName, True)
            Else
                If My.Settings.ConvertToWordByCom Then
                    Dim boolDict As New Dictionary(Of String, Integer)
                    Dim UseBookMark As Boolean = False
                    Dim CustomBoolFont As String = ""
                    Dim StrDict As Dictionary(Of String, String) = Fill_CustomString(row, My.Settings.WordFinancialTemplete, Destination_FileName, UseBookMark, boolDict, CustomBoolFont)
                    If Not IsNothing(StrDict) AndAlso (StrDict.Count > 0) Then
                        Dim CtW As New CTWBCOM.BookMarkInserter(Destination_FileName)
                        CtW.ThrowExceptions = True
                        CtW.UseImageBorder = True
                        CtW.UseLastParagraphSetting = True
                        CtW.StringBookMarks = StrDict
                        CtW.UseCustomBoolean = CBool(IIf(IsNothing(boolDict), False, True))
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
                    Dim boolDict As New Dictionary(Of String, Integer)
                    Dim UseBookMark As Boolean = False
                    Dim customFont As String = ""
                    Dim StrDict As Dictionary(Of String, String) = Fill_CustomString(row, My.Settings.WordFinancialTemplete, Destination_FileName, UseBookMark, boolDict, customFont)
                    If Not IsNothing(StrDict) AndAlso (StrDict.Count > 0) Then
                        Dim CtW As New CTWBOXML.BookMarkReplacer(Destination_FileName)
                        CtW.ThrowExceptions = True
                        CtW.UseImageBorder = True
                        CtW.UseLastParagraphSetting = True
                        CtW.StringBookMarks = StrDict
                        CtW.CustomBoolFontName = customFont
                        CtW.UseCustomBoolean = CBool(IIf(IsNothing(boolDict), False, True))
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
            If My.Settings.WordMakeOneFile Then
                SavedFiles.Add(Destination_FileName)
            End If
            i += 1
            Dim prog As Integer = CInt((i / CDec(radDataGrid.SelectedRows.Count)) * 100D)
            ProgressSate.ShowStatueProgress(prog, row.Cells("FatherName").Value.ToString())
        Next
        'Make One File
        If radDataGrid.SelectedRows.Count > 1 AndAlso My.Settings.WordMakeOneFile Then
            Try
                Dim MergerFileName As String = ShowWordSave()
                Dim CtwXml As New CTWBOXML.DocMerger
                CtwXml.DestinationFile = CStr(SavedFiles(0))
                Dim strFile(SavedFiles.Count - 2) As String
                For i1 As Integer = 1 To SavedFiles.Count - 1
                    strFile(i1 - 1) = CStr(SavedFiles(i1))
                Next
                CtwXml.WordFiles = strFile
                AddHandler CtwXml.StringProgress, AddressOf ProgressSate.ShowStatueProgress
                CtwXml.Merge()
                File.Copy(CStr(SavedFiles(0)), MergerFileName, True)
                If Not My.Settings.WordMakeNewFolder Then
                    For Each strF As String In SavedFiles
                        File.Delete(strF)
                    Next
                End If
            Catch ex As Exception
                ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            End Try
        End If
    End Sub
    Public Function Fill_Maktab1_Data(ByVal row As GridViewRowInfo) As WordTemletes.FinancailCard.FinancialData
        Dim wordData As New WordTemletes.FinancailCard.FinancialData
        wordData.Address = row.Cells("Address").Value.ToString
        wordData.BillDate = row.Cells("Date").Value.ToString
        wordData.FatherName = row.Cells("FatherName").Value.ToString
        wordData.MotherName = row.Cells("MotherName").Value.ToString
        wordData.OrphansCount = row.Cells("OrphanCount").Value.ToString
        wordData.OrphansNames = row.Cells("OrphanNames").Value.ToString
        wordData.Salary = row.Cells("Salary").Value.ToString & " " & row.Cells("CurrencyShort").Value.ToString
        Return wordData
    End Function
    Private Function AnotherDecode64(ByVal base64Decoded As String) As Byte()
        Dim temp As String = base64Decoded.TrimEnd(CChar("="))
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
        temp += New String(CChar("="), asciiChars)

        Return Convert.FromBase64String(temp)
    End Function
    Public Function Fill_CustomString(ByVal row As GridViewRowInfo, ByVal TempName As String, ByVal DestinationFile As String, ByRef UseBookMark As Boolean, ByRef boolBookmark As Dictionary(Of String, Integer), Optional ByRef CustomFont As String = "") As Dictionary(Of String, String)
        If Not File.Exists(FrmFinancialTemplete.xmlFileName) Then
            Return Nothing
        End If
        If IsNothing(row) Then Return Nothing
        If IsNothing(TempName) OrElse TempName.Length = 0 Then Return Nothing
        Dim ret As New Dictionary(Of String, String)
        Dim xDoc As XDocument = XDocument.Load(FrmFinancialTemplete.xmlFileName)
        Dim q = From ele In xDoc.<b:Templates>.<b:Template> Where ele.<b:Name>.Value = TempName Select ele
        If Not IsNothing(q) AndAlso q.Count > 0 Then
            For Each xtemp In q
                Dim FileLength As Long = CLng(xtemp.<b:Size>.Value)
                UseBookMark = CBool(xtemp.<b:IsBookmarks>.Value)
                Dim UseCustomBool As Boolean = CBool(xtemp.<b:UseCustomBoolean>.Value())
                If UseCustomBool Then
                    boolBookmark = New Dictionary(Of String, Integer)
                Else
                    boolBookmark = Nothing
                End If
                CustomFont = xtemp.<b:BooleanFontName>.Value
                Dim YesBool, NoBool As Integer
                If UseCustomBool Then
                    NoBool = CInt(xtemp.<b:BooleanNOMark>.Value)
                    YesBool = CInt(xtemp.<b:BooleanYesMark>.Value)
                End If
                Dim Data() As Byte
                Data = AnotherDecode64(xtemp.<b:Data>.Value)
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
                For Each key In xtemp.<b:Bookmarks>
                    If key.<b:Supporter>.<b:FullName>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("SupporterName").Value) Then
                            ret.Add(key.<b:Supporter>.<b:FullName>.Value, row.Cells("SupporterName").Value.ToString())
                        End If
                    End If
                    If key.<b:Supporter>.<b:Address>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("SupporterAddress").Value) Then
                            ret.Add(key.<b:Supporter>.<b:Address>.Value, row.Cells("SupporterAddress").Value.ToString())
                        End If
                    End If
                    If key.<b:Supporter>.<b:Note>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("SupporterNote").Value) Then
                            ret.Add(key.<b:Supporter>.<b:Note>.Value, row.Cells("SupporterNote").Value.ToString())
                        End If
                    End If
                    'Mother
                    If key.<b:Mother>.<b:Age>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("MotherAge").Value) Then
                            ret.Add(key.<b:Mother>.<b:Age>.Value, row.Cells("MotherAge").Value.ToString())
                        End If
                    End If
                    If key.<b:Mother>.<b:FullName>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("MotherName").Value) Then
                            ret.Add(key.<b:Mother>.<b:FullName>.Value, row.Cells("MotherName").Value.ToString())
                        End If
                    End If
                    If key.<b:Mother>.<b:Jop>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("MotherJop").Value) Then
                            ret.Add(key.<b:Mother>.<b:Jop>.Value, row.Cells("MotherJop").Value.ToString())
                        End If
                    End If
                    If key.<b:Mother>.<b:ID>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("MotherID").Value) Then
                            ret.Add(key.<Mother>.<b:ID>.Value, row.Cells("MotherID").Value.ToString())
                        End If
                    End If
                    If key.<b:Mother>.<b:IsOwnOrphan>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("MotherIsOwnOrphan").Value) Then
                            If CBool(row.Cells("MotherIsOwnOrphan").Value) Then
                                If Not UseCustomBool Then
                                    ret.Add(key.<b:Mother>.<b:IsOwnOrphan>.Value, "نعم")
                                Else
                                    boolBookmark.Add(key.<b:Mother>.<b:IsOwnOrphan>.Value, YesBool)
                                End If
                            Else
                                If Not UseCustomBool Then
                                    ret.Add(key.<b:Mother>.<b:IsOwnOrphan>.Value, "لا")
                                Else
                                    boolBookmark.Add(key.<b:Mother>.<b:IsOwnOrphan>.Value, NoBool)
                                End If
                            End If
                        End If
                    End If
                    'Father
                    If key.<b:Father>.<b:FullName>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("FatherName").Value) Then
                            ret.Add(key.<b:Father>.<b:FullName>.Value, row.Cells("FatherName").Value.ToString())
                        End If
                    End If
                    If key.<b:Father>.<b:Age>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("FatherAge").Value) Then
                            ret.Add(key.<b:Father>.<b:Age>.Value, row.Cells("FatherAge").Value.ToString())
                        End If
                    End If
                    If key.<b:Father>.<b:DeathReason>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("FatherDeathReason").Value) Then
                            ret.Add(key.<b:Father>.<b:DeathReason>.Value, row.Cells("FatherDeathReason").Value.ToString())
                        End If
                    End If
                    If key.<b:Father>.<b:DeathDay>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("FatherDeath").Value) Then
                            ret.Add(key.<b:Father>.<b:DeathDay>.Value, row.Cells("FatherDeath").Value.ToString())
                        End If
                    End If
                    If key.<b:Father>.<b:Jop>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("FatherJop").Value) Then
                            ret.Add(key.<b:Father>.<b:Jop>.Value, row.Cells("FatherJop").Value.ToString())
                        End If
                    End If
                    'Address
                    If key.<b:Address>.<b:Full>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("Address").Value) Then
                            ret.Add(key.<b:Address>.<b:Full>.Value, row.Cells("Address").Value.ToString())
                        End If
                    End If
                    If key.<b:Address>.<b:Mobile>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("MobileNumber").Value) Then
                            ret.Add(key.<b:Address>.<b:Mobile>.Value, row.Cells("MobileNumber").Value.ToString())
                        End If
                    End If
                    If key.<b:Address>.<b:Phone>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("PhoneNumber").Value) Then
                            ret.Add(key.<b:Address>.<b:Phone>.Value, row.Cells("PhoneNumber").Value.ToString())
                        End If
                    End If
                    If key.<b:Date>.<b:BookMark>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("Date").Value) Then
                            ret.Add(key.<b:Date>.<b:BookMark>.Value, row.Cells("Date").Value.ToString())
                        End If
                    End If
                    'Salaries
                    If Not IsNothing(row.Cells("CurrencyShort").Value) Then
                        If key.<b:Salaries>.<b:Bail>.Value.Length > 0 Then
                            If Not IsNothing(row.Cells("BailSalary").Value) Then
                                ret.Add(key.<b:Salaries>.<b:Bail>.Value, row.Cells("BailSalary").Value.ToString() & " " & row.Cells("CurrencyShort").Value.ToString())
                            End If
                        End If
                        If key.<b:Salaries>.<b:OrphanCount>.Value.Length > 0 Then
                            If Not IsNothing(row.Cells("OrphanCount").Value) Then                            
                                ret.Add(key.<b:Salaries>.<b:OrphanCount>.Value, row.Cells("OrphanCount").Value.ToString())
                            End If
                        End If
                        If key.<b:Salaries>.<b:BondsMan>.Value.Length > 0 Then
                            If Not IsNothing(row.Cells("BondsManSalary").Value) Then
                                ret.Add(key.<b:Salaries>.<b:BondsMan>.Value, row.Cells("BondsManSalary").Value.ToString() & " " & row.Cells("CurrencyShort").Value.ToString())
                            End If
                        End If
                        If key.<b:Salaries>.<b:Family>.Value.Length > 0 Then
                            If Not IsNothing(row.Cells("Salary").Value) Then
                                ret.Add(key.<b:Salaries>.<b:Family>.Value, row.Cells("Salary").Value.ToString() & " " & row.Cells("CurrencyShort").Value.ToString())
                            End If
                        End If
                        If key.<b:Salaries>.<b:Orphan>.Value.Length > 0 Then
                            If Not IsNothing(row.Cells("OrphanSalary").Value) Then
                                ret.Add(key.<b:Salaries>.<b:Orphan>.Value, row.Cells("OrphanSalary").Value.ToString() & " " & row.Cells("CurrencyShort").Value.ToString())
                            End If
                        End If
                    Else
                        If key.<b:Salaries>.<b:Bail>.Value.Length > 0 Then
                            If Not IsNothing(row.Cells("BailSalary").Value) Then
                                ret.Add(key.<b:Salaries>.<b:Bail>.Value, row.Cells("BailSalary").Value.ToString())
                            End If
                        End If
                        If key.<b:Salaries>.<b:OrphanCount>.Value.Length > 0 Then
                            If Not IsNothing(row.Cells("OrphanCount").Value) Then
                                ret.Add(key.<b:Salaries>.<b:OrphanCount>.Value, row.Cells("OrphanCount").Value.ToString())
                            End If
                        End If
                        If key.<b:Salaries>.<b:BondsMan>.Value.Length > 0 Then
                            If Not IsNothing(row.Cells("BondsManSalary").Value) Then
                                ret.Add(key.<b:Salaries>.<b:BondsMan>.Value, row.Cells("BondsManSalary").Value.ToString())
                            End If
                        End If
                        If key.<b:Salaries>.<b:Family>.Value.Length > 0 Then
                            If Not IsNothing(row.Cells("Salary").Value) Then
                                ret.Add(key.<b:Salaries>.<b:Family>.Value, row.Cells("Salary").Value.ToString())
                            End If
                        End If
                        If key.<b:Salaries>.<b:Orphan>.Value.Length > 0 Then
                            If Not IsNothing(row.Cells("OrphanSalary").Value) Then
                                ret.Add(key.<b:Salaries>.<b:Orphan>.Value, row.Cells("OrphanSalary").Value.ToString())
                            End If
                        End If
                    End If
                    'detail
                    'GridViewCheckBoxColumn2.Name = "IsBailedFam"
                    If key.<b:Detials>.<b:OrphansNames>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("OrphanNames").Value) Then
                            ret.Add(key.<b:Detials>.<b:OrphansNames>.Value, row.Cells("OrphanNames").Value.ToString())
                        End If
                    End If
                    If key.<b:Detials>.<b:OrphansNamesSala>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("OrphansNamesSalaries").Value) Then
                            ret.Add(key.<b:Detials>.<b:OrphansNamesSala>.Value, row.Cells("OrphansNamesSalaries").Value.ToString())
                        End If
                    End If
                    If key.<b:Detials>.<b:OrphansSalayies>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("OrphansSalaries").Value) Then
                            ret.Add(key.<b:Detials>.<b:OrphansSalayies>.Value, row.Cells("OrphansSalaries").Value.ToString())
                        End If
                    End If
                    'Number
                    If key.<b:Numbers>.<b:BookMArk>.Value.Length > 0 Then
                        If Not IsNothing(row.Cells("ID").Value) Then
                            ret.Add(key.<b:Numbers>.<b:BookMArk>.Value, row.Cells("ID").Value.ToString())
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

End Class
