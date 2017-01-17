Imports System.IO
Imports <xmlns="urn:OrphanageXML:FinancialTemplates">
Public Class FrmPaymentTEst

    Private _StaticBox As Integer
    Private _CalculatedFamiles As New Dictionary(Of Integer, Decimal)
    Private _CalculatedBaiFamiles As New Dictionary(Of Integer, Decimal)
    Private _StaticOCount As Integer = 0
    Private _StaticAll As Decimal = 0
    Private _IsCalculated As Boolean = False
    Dim _Supporters As Dictionary(Of Integer, Decimal)
    Public ShowdData As New Dictionary(Of Integer, FrmShowSalaries.FinancialData)
    Public Structure Currencies
        Public CurrencyName As String
        Public CurrencyShort As String
        Public OneValuetoStaticBox As Decimal
    End Structure
    Public Shared CurrenciesConverter As New Dictionary(Of String, Currencies)
    Private Sub optBailed_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles optBailed.ToggleStateChanged, optALL.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            grpBails.Enabled = True
        Else
            grpBails.Enabled = False
        End If
    End Sub

    Private Sub btnAddBail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBail.Click
        If frmLogin.CurrentUser.CanDraw Then
            Dim frm As New FrmBailsSelector(True)
            frm.ShowDialog()
            If Not IsNothing(frm.SelectedBails) AndAlso frm.SelectedBails.Length > 0 Then
                For Each bal In frm.SelectedBails
                    Dim itm As New Telerik.WinControls.UI.RadListDataItem(Getter.GetFullName(bal.Supporter.Name) & " " & bal.Amount, bal)
                    Dim found As Boolean = False
                    For Each Sitm In txtABails.Items
                        If Sitm.Text = itm.Text Then found = True
                    Next
                    If Not found Then
                        txtABails.AutoCompleteItems.Add(itm)
                        txtABails.Text &= itm.Text & ";"
                    End If
                Next
            End If
            frm.Dispose()
        End If
    End Sub

    Private Sub btnChooseStaticBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseStaticBox.Click
        If frmLogin.CurrentUser.CanDraw Then
            Dim frm As New FrmBoxChooser(False)
            frm.ShowDialog()
            If frm.SelectedBox > 0 AndAlso frm.DialogResult = Windows.Forms.DialogResult.OK Then
                Using Odb As New OrphanageDB.Odb
                    Dim q = From bx In Odb.Boxes Where bx.ID = frm.SelectedBox Select bx
                    If Not IsNothing(q) AndAlso q.Count > 0 Then
                        txtStaticBox.Text = q.FirstOrDefault.Name
                        _StaticBox = q.FirstOrDefault.ID
                        lblCurBond.Text = q.FirstOrDefault.Currency_Short
                        lblCurExOrph.Text = q.FirstOrDefault.Currency_Short
                        lblCurOrph.Text = q.FirstOrDefault.Currency_Short
                    End If
                End Using
            Else
                txtStaticBox.Text = ""
                lblCurBond.Text = ""
                lblCurExOrph.Text = ""
                lblCurOrph.Text = ""
                _StaticBox = Nothing
            End If
            frm.Dispose()
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub



    Private Sub chkUseExtendedOrph_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkUseExtendedOrph.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            grpExStatics.Enabled = True
        Else
            grpExStatics.Enabled = False
        End If
    End Sub

    Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
        Try
            SetStaticSalary()
            If chkConvertCurrency.Checked AndAlso CurrenciesConverter.Count <= 0 Then
                ExceptionsManager.RaiseOnStatus(New MyException("حدد اسغار تصريف العملات أولاً", True, True))
                btnSetCurrencies.Focus()
                Return
            End If
            Me.Enabled = False
            If _StaticBox > 0 Then
                _CalculatedBaiFamiles.Clear()
                _CalculatedFamiles.Clear()
                ShowdData.Clear()
                _StaticOCount = 0
                _StaticAll = 0
                _Supporters = New Dictionary(Of Integer, Decimal)
                Dim Sd As FrmShowSalaryStatics.StaticData = Nothing
                Using Odb As New OrphanageDB.Odb
                    Dim q = From bx In Odb.Boxes Where bx.ID = _StaticBox Select bx
                    If optALL.IsChecked Then
                        CalculateBailed()
                        CalculateUnBailed()
                        Sd = New FrmShowSalaryStatics.StaticData(_StaticOCount, _CalculatedFamiles.Count, _StaticAll, q.FirstOrDefault.Amount - _StaticAll)
                        Sd.Cur_short = q.FirstOrDefault.Currency_Short
                    End If
                    If optBailed.IsChecked Then
                        CalculateBailed()
                        Sd = New FrmShowSalaryStatics.StaticData(_StaticOCount, _CalculatedFamiles.Count, _StaticAll, q.FirstOrDefault.Amount - _StaticAll)
                        Sd.Cur_short = q.FirstOrDefault.Currency_Short
                    End If
                    If optUnBailed.IsChecked Then
                        'CalculateBailed()
                        CalculateUnBailed()
                        Sd = New FrmShowSalaryStatics.StaticData(_StaticOCount, _CalculatedFamiles.Count, _StaticAll, q.FirstOrDefault.Amount - _StaticAll)
                        Sd.Cur_short = q.FirstOrDefault.Currency_Short
                    End If
                End Using
                If chkConvertCurrency.Checked AndAlso CurrenciesConverter.Count > 0 Then
                    If Not IsNothing(ShowdData) AndAlso ShowdData.Count > 0 Then
                        Dim errored = ShowdData.Where(Function(x) x.Value.HasErrors).Select(Function(x) x.Key)
                        Dim NN() As Integer = errored.ToArray()
                        For Each errData In NN
                            Dim Shd As New FrmShowSalaries.FinancialData
                            Shd = ShowdData(errData)
                            For Each nam As String In Shd.OrphansNamesSalary
                                For Each cur In CurrenciesConverter.Keys
                                    If nam.IndexOf(cur) > -1 Then
                                        Dim sep1 As Integer = nam.IndexOf("-")
                                        Dim sep2 As Integer = nam.IndexOf(cur)
                                        Dim Amount As String = nam.Substring(sep1 + 1, sep2 - sep1 - 1)
                                        Dim NewAmount As Decimal = CDec(Amount) * CurrenciesConverter(cur).OneValuetoStaticBox
                                        Shd.Salary -= CDec(Amount)
                                        Shd.Salary += NewAmount
                                        Shd.HasErrors = False
                                    End If
                                Next
                            Next
                            Shd.Currency_short = Sd.Cur_short
                            ShowdData.Remove(errData)
                            ShowdData.Add(errData, Shd)
                        Next
                    End If
                End If
                Dim frm As New FrmShowSalaryStatics(Sd, _Supporters)
                frm.FamiliesData = ShowdData
                frm.MdiParent = Me.MdiParent
                frm.Show()
                WindowsLauncher.AllWindows.Add(frm)
                _IsCalculated = True
            Else
                ExceptionsManager.RaiseOnStatus(New MyException("اختر الحساب للأيتام غير المكفولين", False, False))
                btnChooseStaticBox.Focus()
                _IsCalculated = False
            End If
            Me.Enabled = True
        Catch ex As Exception
            Me.Enabled = True
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub FrmPaymentTEst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        numExStaticOrphMony.DecimalPlaces = My.Settings.DecimalPercion
        numStaticBond.DecimalPlaces = My.Settings.DecimalPercion
        numStaticOrphan.DecimalPlaces = My.Settings.DecimalPercion
        numExStaticOrphMony.ThousandsSeparator = My.Settings.UseThousendSeprator
        numStaticBond.ThousandsSeparator = My.Settings.UseThousendSeprator
        numStaticOrphan.ThousandsSeparator = My.Settings.UseThousendSeprator
    End Sub

    Private Sub btnDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        If Not _IsCalculated Then Exit Sub
        If IsNothing(ShowdData) OrElse ShowdData.Count = 0 Then Exit Sub
        Dim frm As New FrmShowSalaries(ShowdData)
        frm.MdiParent = Application.OpenForms("FrmMain")
        If My.Settings.WordFinancialTemplete = "افتراضي" Then
            frm.ViewStatics.IsFamilyNumber = False
            frm.ViewStatics.IsFatherNumber = False
            frm.ViewStatics.IsMotherNumber = False
            frm.ViewStatics.IsNowDate = True
            frm.ViewStatics.IsSerialNumbers = True
            frm.ViewStatics.IsSpecificDate = False
        Else
            If File.Exists(FrmNewTemplate.xmlFileName) Then
                Dim xDoc As XDocument = XDocument.Load(FrmNewTemplate.xmlFileName)
                Dim q = From ele In xDoc.<Templates>.<Template> Where ele.<Name>.Value = My.Settings.WordFinancialTemplete Select ele
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    For Each xtemp In q
                        For Each key In xtemp.<Bookmarks>
                            frm.ViewStatics.IsFamilyNumber = CBool(key.<Numbers>.<ISFamily>.Value)
                            frm.ViewStatics.IsFatherNumber = CBool(key.<Numbers>.<IsFather>.Value)
                            frm.ViewStatics.IsMotherNumber = CBool(key.<Numbers>.<IsMother>.Value)
                            frm.ViewStatics.IsSerialNumbers = CBool(key.<Numbers>.<IsSerial>.Value)
                            frm.ViewStatics.IsNowDate = CBool(key.<Date>.<IsNow>.Value)
                            frm.ViewStatics.IsSpecificDate = CBool(key.<Date>.<IsSpecific>.Value)
                            frm.ViewStatics.SpecificDate = CDate(key.<Date>.<SpecificDate>.Value)
                            Exit For
                        Next
                        Exit For
                    Next
                End If
            Else
                frm.ViewStatics.IsFamilyNumber = False
                frm.ViewStatics.IsFatherNumber = False
                frm.ViewStatics.IsMotherNumber = False
                frm.ViewStatics.IsSerialNumbers = True
                frm.ViewStatics.IsNowDate = True
                frm.ViewStatics.IsSpecificDate = False
                frm.ViewStatics.SpecificDate = Nothing
            End If
        End If
        frm.Show()
        WindowsLauncher.AllWindows.Add(frm)
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub
    'New Code
    Private StaticSalaries As New Dictionary(Of Integer, Decimal)
    Private Sub CalculateBailed()
        Dim AllFams() As Integer = Nothing
        Using BailD As New OrphanageDB.Odb()
            BailD.ObjectTrackingEnabled = False
            Dim qFamie = From fam In BailD.Families
                            Select fam.ID

            If IsNothing(qFamie) OrElse qFamie.Count <= 0 Then
                Return
            End If
            AllFams = qFamie.ToArray()
        End Using
        Dim proc As Decimal = 0D
        Dim AllP As Decimal = CDec(AllFams.Length)
        For Each famid In AllFams
            Using Odb As New OrphanageDB.Odb
                Dim fam_ID As Integer = famid
                Dim fam As OrphanageClasses.Family = Getter.GetFamilyByID(fam_ID, Odb)
                Dim Break As Boolean = True
                If Not fam.IsBaild Then
                    Dim qOrps As System.Linq.IQueryable(Of OrphanageClasses.Orphan)
                    If My.Settings.ShowHiddenObject Then
                        qOrps = From orps In Odb.Orphans Where orps.Family_ID = fam_ID Select orps
                    Else
                        qOrps = From orps In Odb.Orphans Where orps.Family_ID = fam_ID AndAlso (orps.IsExcluded.HasValue = False OrElse orps.IsExcluded.Value = False) Select orps
                    End If
                    For Each orp In qOrps
                        If orp.IsBailed Then
                            Break = False
                            Exit For
                        End If
                    Next
                    If Break Then
                        AllP -= 1
                        Continue For
                    End If
                    If qOrps.Count = 0 Then
                        AllP -= 1
                        Continue For
                    End If
                End If
                Dim Fam_salary = SalaryBaildFamily(fam_ID)

                proc += 1
                Dim Precentage = Int(Math.Floor((proc / AllP) * 100D))
                ProgressSate.ShowStatueProgress(CInt(Precentage), "المكفولين")
                Application.DoEvents()
                Odb.Dispose()
            End Using
        Next
        GC.Collect()
    End Sub
    Private Sub CalculateUnBailed()
        Dim allFams() As Integer
        Using FamDb As New OrphanageDB.Odb()
            FamDb.ObjectTrackingEnabled = False
            Dim qFams = From fam In FamDb.Families
                            Where (fam.IsBaild = False)
                                Select fam.ID Distinct
            If IsNothing(qFams) OrElse qFams.Count <= 0 Then
                Return
            End If
            allFams = qFams.ToArray()
            FamDb.Dispose()
        End Using
        Dim proc As Decimal = 0D
        Dim AllP As Decimal = CDec(allFams.Length)
        Dim Precentage As Integer = 0
        For Each famid In allFams
            Using Odb As New OrphanageDB.Odb
                Dim fam_ID As Integer = famid
                Dim fam As OrphanageClasses.Family = Getter.GetFamilyByID(fam_ID, Odb)
                If Not My.Settings.ShowHiddenObject Then
                    If fam.IsExcluded Then
                        AllP -= 1
                        Continue For
                    End If
                End If
                Dim Break As Boolean = False
                Dim qOrps As System.Linq.IQueryable(Of OrphanageClasses.Orphan)
                If My.Settings.ShowHiddenObject Then
                    qOrps = From orps In Odb.Orphans Where orps.Family_ID = fam_ID Select orps
                Else
                    qOrps = From orps In Odb.Orphans Where orps.Family_ID = fam_ID AndAlso (orps.IsExcluded.HasValue = False OrElse orps.IsExcluded.Value = False) Select orps
                End If
                For Each orp In qOrps
                    If orp.IsBailed Then
                        Break = True
                        Exit For
                    End If
                Next
                If Break Then
                    AllP -= 1
                    Continue For
                End If
                If qOrps.Count = 0 Then
                    AllP -= 1
                    Continue For
                End If
                Dim Fam_salary = SalaryUnBaildFamily(fam_ID)
                AddCalculatedUnBailed(fam_ID, Fam_salary)
                proc += 1
                Precentage = CInt(Int(Math.Floor((proc / AllP) * 100D)))
                ProgressSate.ShowStatueProgress(Precentage, "غير المكفولين")
                Application.DoEvents()
                Odb.Dispose()
            End Using
        Next
    End Sub
    Private Sub SetStaticSalary()
        StaticSalaries.Clear()
        For i As Integer = 1 To 30
            If chkUseExtendedOrph.Checked Then
                If i < numExMaxOrphNumber.Value Then
                    StaticSalaries.Add(i, numStaticBond.Value + (numStaticOrphan.Value * i))
                Else
                    Dim BigS As Integer = CInt(numExMaxOrphNumber.Value - 1)
                    Dim Over As Integer = i - BigS
                    StaticSalaries.Add(i, (BigS * numStaticOrphan.Value) + numStaticBond.Value + _
                                       (numExStaticOrphMony.Value * Over))
                End If
            Else
                StaticSalaries.Add(i, numStaticBond.Value + (numStaticOrphan.Value * i))
            End If
        Next
    End Sub

    Private Function SalaryUnBaildFamily(ByVal fam_id As Integer) As Decimal
        Dim OrpCount As Byte = 0
        Using FamDc As New OrphanageDB.Odb()
            FamDc.ObjectTrackingEnabled = False
            Dim q = From fam1 In FamDc.Families Where fam1.ID = fam_id Select fam1
            If IsNothing(q) OrElse q.Count <= 0 Then
                Return 0
            End If
            Dim fam As OrphanageClasses.Family = q.FirstOrDefault
            If IsNothing(fam) Then Return 0
            If Not My.Settings.ShowHiddenObject AndAlso fam.IsExcluded Then Return 0
            Dim Qb = From bx In FamDc.Boxes Where bx.ID = _StaticBox Select bx
            Dim shD As New FrmShowSalaries.FinancialData()
            shD.OrphansNames = New ArrayList()
            shD.OrphansNamesSalary = New ArrayList()
            shD.OrphansSalary = New ArrayList()
            shD.BondsManSalary = numStaticBond.Value.ToString & " " & Qb.FirstOrDefault.Currency_Short
            shD.Currency_short = Qb.FirstOrDefault.Currency_Short
            shD.HasErrors = False
            shD.IsBailed = False
            shD.OrphanSalary = numStaticOrphan.Value & " " & Qb.FirstOrDefault.Currency_Short
            OrpCount = ShowedOrphansCount(fam_id, shD)
            shD.OrphansCount = OrpCount
            shD.Salary = StaticSalaries(OrpCount)
            _StaticOCount += OrpCount
            _StaticAll += shD.Salary
            AddToTable(fam_id, shD)
            FamDc.Dispose()
        End Using
        Return StaticSalaries(OrpCount)
    End Function
    Private Function SalaryBaildFamily(ByVal Fam_id As Integer) As Decimal
        Dim ret As Decimal = 0
        Using FamDc As New OrphanageDB.Odb
            Dim q = From fam1 In FamDc.Families Where fam1.ID = Fam_id Select fam1
            If IsNothing(q) OrElse q.Count <= 0 Then
                Return 0
            End If
            Dim fam As OrphanageClasses.Family = q.FirstOrDefault
            If IsNothing(fam) Then Return 0
            If Not My.Settings.ShowHiddenObject AndAlso fam.IsExcluded Then Return 0
            Dim qB = From bail In FamDc.Bails Where bail.ID = fam.Baild_ID Select bail
            Dim shD As New FrmShowSalaries.FinancialData()
            shD.OrphansNames = New ArrayList()
            shD.OrphansNamesSalary = New ArrayList()
            shD.OrphansSalary = New ArrayList()
            If Not IsNothing(qB) AndAlso qB.Count > 0 Then
                'كفالة عائلية وجدت
                Dim Fbail As OrphanageClasses.Bail = qB.FirstOrDefault
                Dim Supp As OrphanageClasses.Supporter = Fbail.Supporter
                If Fbail.Is_Ended Then Return 0
                If Not Fbail.Supporter.Is_Still_Support Then Return 0
                If Not IsSelectedBail(Fbail.ID) Then
                    If chkOtherBaild.Checked Then
                        Dim Fam_salary = SalaryUnBaildFamily(Fam_id)
                        ret += Fam_salary
                        AddCalculatedUnBailed(Fam_id, Fam_salary)                        
                    End If
                Else
                    Dim Ocount As Byte = ShowedOrphansCount(Fam_id, shD)
                    shD.BailSalary = Fbail.Amount.ToString
                    shD.Currency_short = Fbail.Box.Currency_Short
                    shD.HasErrors = False
                    shD.IsBailed = True
                    shD.OrphansCount = Ocount
                    shD.Salary = Fbail.Amount
                    shD.SuporterName = Getter.GetFullName(Supp.Name)
                    shD.SupporterAddress = Getter.GetAddress(Supp.Address)
                    shD.supporterNote = Supp.Note
                    AddSupporter(Supp.ID, Fbail.Amount)
                    AddCalculatedBailed(Fam_id, Fbail.Amount)
                    AddToTable(Fam_id, shD)
                    ret = Fbail.Amount
                End If
            Else
                'كفالة غير موجودة
                'البحث عن كفالات أيتام
                Dim NonStaticSalary As Boolean = False
                For Each orp In fam.Orphans
                    If orp.IsBailed AndAlso IsSelectedBail(orp.Bail.ID) Then
                        NonStaticSalary = True
                    End If
                Next
                If NonStaticSalary Then
                    Dim qbo = From bx In FamDc.Boxes Where bx.ID = _StaticBox Select bx.Currency_Short
                    Dim foS = GetFamilyOrphansBailedSalary(Fam_id, shD, qbo.FirstOrDefault())
                    If foS > 0 Then
                        AddToTable(Fam_id, shD)
                    End If
                    AddCalculatedBailed(Fam_id, foS)
                    ret = foS
                Else
                    If chkOtherBaild.Checked Then
                        Dim Fam_salary = SalaryUnBaildFamily(Fam_id)
                        ret += 0
                        AddCalculatedUnBailed(Fam_id, Fam_salary)
                    End If
                End If
            End If
            FamDc.Dispose()
        End Using
        Return ret
    End Function
    Private Function GetFamilyOrphansBailedSalary(ByVal fam_id As Integer, ByRef FfD As FrmShowSalaries.FinancialData, ByVal cur_short As String) As Decimal
        Using FamDc As New OrphanageDB.Odb
            Dim q = From orp In FamDc.Orphans Where orp.Family_ID = fam_id Select orp
            If IsNothing(q) OrElse q.Count <= 0 Then
                Return 0
            End If
            Dim UnBaild As Boolean = False
            Dim Baild As Boolean = False
            FfD.OrphansCount = 0
            FfD.OrphanSalary = "0"
            FfD.Salary = 0
            FfD.OrphansSalary.Clear()
            FfD.OrphansNamesSalary.Clear()
            FfD.OrphansNames.Clear()
            For Each orp In q
                If Not My.Settings.ShowHiddenObject Then
                    If orp.IsExcluded.HasValue AndAlso orp.IsExcluded.Value Then Continue For
                End If
                If orp.Bail_ID.HasValue AndAlso orp.Bail_ID.Value > 0 Then
                    'يتيم(مكفول)
                    Dim Bail_id As Integer = orp.Bail_ID.Value
                    Dim qBail = From bal In FamDc.Bails Where bal.ID = Bail_id Select bal
                    Dim bail As OrphanageClasses.Bail = qBail.FirstOrDefault()
                    If optBailed.IsChecked OrElse optALL.IsChecked Then
                        'عائلة تحوي أكثر من كفالة
                        If Not IsSelectedBail(bail.ID) Then
                            If chkOtherBaild.Checked Then
                                FfD.OrphansCount += 1
                                _StaticOCount += 1
                                If Not IsNothing(FfD.Currency_short) AndAlso _
                                    FfD.Currency_short.Length > 0 AndAlso _
                                    FfD.Currency_short <> cur_short Then
                                    FfD.HasErrors = True
                                End If

                                FfD.Currency_short = cur_short
                                If FfD.OrphansCount < numExMaxOrphNumber.Value Then
                                    FfD.Salary += numStaticOrphan.Value
                                    _StaticAll += numStaticOrphan.Value
                                    FfD.OrphansSalary.Add(numStaticOrphan.Value & " " & cur_short)
                                    FfD.OrphansNamesSalary.Add(orp.Name.First & "-" & numStaticOrphan.Value & " " & cur_short)
                                Else
                                    FfD.Salary += numExStaticOrphMony.Value
                                    _StaticAll += numExStaticOrphMony.Value
                                    FfD.OrphansSalary.Add(numExStaticOrphMony.Value & " " & cur_short)
                                    FfD.OrphansNamesSalary.Add(orp.Name.First & "-" & numExStaticOrphMony.Value & " " & cur_short)
                                End If
                                UnBaild = True
                                Continue For
                            Else
                                Continue For
                            End If
                        End If
                    End If
                    Dim qcur = From bx In FamDc.Boxes Where bx.ID = bail.Box_ID
                               Select bx.Currency_Short
                    Dim BailCurShort As String = qcur.FirstOrDefault()
                    Dim qSupp = From sup In FamDc.Supporters Where sup.ID = bail.Supporter_ID
                                Select sup
                    Dim Supp As OrphanageClasses.Supporter = qSupp.FirstOrDefault()
                    FfD.OrphansNames.Add(orp.Name.First)
                    If bail.Is_Ended OrElse Not Supp.Is_Still_Support Then
                        'كفالة منتهية
                        FfD.OrphansSalary.Add(0 & " " & BailCurShort)
                        FfD.OrphansNamesSalary.Add(orp.Name.First & "- 0 " & BailCurShort)
                        FfD.OrphansCount += 1
                        Continue For
                    End If
                    AddSupporter(Supp.ID, bail.Amount)
                    FfD.Salary += bail.Amount
                    FfD.OrphansSalary.Add(bail.Amount & " " & BailCurShort)
                    FfD.OrphansNamesSalary.Add(orp.Name.First & "-" & bail.Amount & " " & BailCurShort)
                    FfD.OrphansCount += 1
                    _StaticOCount += 1
                    FfD.SuporterName = Getter.GetFullName(Supp.Name)
                    FfD.SupporterAddress = Getter.GetAddress(Supp.Address)
                    FfD.supporterNote = Supp.Note
                    FfD.IsBailed = True
                    FfD.BailSalary = bail.Amount.ToString
                    If Not IsNothing(FfD.Currency_short) AndAlso _
                        FfD.Currency_short.Length > 0 AndAlso _
                        FfD.Currency_short <> BailCurShort Then
                        FfD.HasErrors = True
                    End If
                    FfD.Currency_short = BailCurShort
                    Baild = True
                Else
                    'يتيم غير مكفول
                    UnBaild = True
                    FfD.OrphansCount += 1
                    _StaticOCount += 1
                    If Not IsNothing(FfD.Currency_short) AndAlso _
                            FfD.Currency_short.Length > 0 AndAlso _
                            FfD.Currency_short <> cur_short Then
                        FfD.HasErrors = True
                    End If
                    FfD.Currency_short = cur_short
                    If FfD.OrphansCount < numExMaxOrphNumber.Value Then
                        FfD.Salary += numStaticOrphan.Value
                        _StaticAll += numStaticOrphan.Value
                        FfD.OrphansSalary.Add(numStaticOrphan.Value & " " & cur_short)
                        FfD.OrphansNamesSalary.Add(orp.Name.First & "-" & numStaticOrphan.Value & " " & cur_short)
                    Else
                        FfD.Salary += numExStaticOrphMony.Value
                        _StaticAll += numExStaticOrphMony.Value
                        FfD.OrphansSalary.Add(numExStaticOrphMony.Value & " " & cur_short)
                        FfD.OrphansNamesSalary.Add(orp.Name.First & "-" & numExStaticOrphMony.Value & " " & cur_short)
                    End If
                End If
            Next
            If Baild AndAlso UnBaild Then
                'FfD.HasErrors = True
            End If
            FamDc.Dispose()
        End Using
        Return FfD.Salary
    End Function
    Private Sub AddToTable(ByVal Fid As Integer, ByVal shD As FrmShowSalaries.FinancialData)
        If ShowdData.ContainsKey(Fid) Then
            If Not ShowdData(Fid).HasErrors Then
                ShowdData(Fid) = shD
            End If
        Else
            ShowdData.Add(Fid, shD)
        End If
    End Sub
    Private Function IsSelectedBail(ByVal bail_id As Integer) As Boolean
        Dim ret As Boolean = False
        Using BailDc As New OrphanageDB.Odb()
            Dim q = From bal In BailDc.Bails Where bal.ID = bail_id Select bal
            If IsNothing(q) OrElse q.Count <= 0 Then Return False
            For Each itm In txtABails.Items
                Dim Sitm As OrphanageClasses.Bail = CType(itm.Value, OrphanageClasses.Bail)
                If Sitm.Amount = q.FirstOrDefault.Amount AndAlso q.FirstOrDefault.Supporter_ID = Sitm.Supporter_ID Then
                    ret = True
                End If
            Next
            BailDc.Dispose()
        End Using
        Return ret
    End Function
    Private Function ShowedOrphansCount(ByVal fam_id As Integer, Optional ByRef FinnacialData As FrmShowSalaries.FinancialData = Nothing) As Byte
        Using ss As New OrphanageDB.Odb()            
            Dim q1 = From orph In ss.Orphans Where orph.Family_ID = fam_id Select orph
            If IsNothing(q1) OrElse q1.Count <= 0 Then
                Return 0
            End If
            If My.Settings.ShowHiddenObject Then
                Return CByte(q1.Count)
            Else
                Dim Onum As Byte = 0
                For Each orp In q1
                    If Not orp.IsExcluded.HasValue OrElse Not orp.IsExcluded Then
                        Onum = CByte(Onum + 1)
                        If Not IsNothing(FinnacialData) Then FinnacialData.OrphansNames.Add(orp.Name.First)
                    End If
                Next
                If Onum > 0 Then
                    Return Onum
                Else
                    Return 0
                End If
            End If
            ss.Dispose()
        End Using    
    End Function
    Private Sub AddSupporter(ByVal Sid As Integer, ByVal Amount As Decimal)
        If _Supporters.ContainsKey(Sid) Then
            _Supporters(Sid) += Amount
        Else
            _Supporters.Add(Sid, Amount)
        End If
    End Sub
    Private Sub AddCalculatedBailed(ByVal Sid As Integer, ByVal Amount As Decimal)
        If _CalculatedBaiFamiles.ContainsKey(Sid) Then
            _CalculatedBaiFamiles(Sid) += Amount
        Else
            _CalculatedBaiFamiles.Add(Sid, Amount)
        End If
    End Sub
    Private Sub AddCalculatedUnBailed(ByVal Sid As Integer, ByVal Amount As Decimal)
        If _CalculatedFamiles.ContainsKey(Sid) Then
            _CalculatedFamiles(Sid) += Amount
        Else
            _CalculatedFamiles.Add(Sid, Amount)
        End If
    End Sub
    Private Sub AddCurrnciesConverter(ByVal Sid As String, ByVal Amount As Currencies)
        If CurrenciesConverter.ContainsKey(Sid) Then
            CurrenciesConverter(Sid) = Amount
        Else
            CurrenciesConverter.Add(Sid, Amount)
        End If
    End Sub
    Private Sub chkConvertCurrency_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkConvertCurrency.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            btnSetCurrencies.Enabled = True
        Else
            btnSetCurrencies.Enabled = False
        End If
    End Sub

    Private Sub btnSetCurrencies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetCurrencies.Click
        If txtABails.Items.Count > 0 Then
            If _StaticBox <= 0 Then
                ExceptionsManager.RaiseOnStatus(New MyException("اختر الحساب للأيتام غير المكفولين", False, False))
                btnChooseStaticBox.Focus()
                Return
            End If
            Dim cur_short As String
            Using odb As New OrphanageDB.Odb
                Dim q = From bx In odb.Boxes Where bx.ID = Me._StaticBox Select bx.Currency_Short
                cur_short = q.FirstOrDefault()
            End Using
            For Each itm In txtABails.Items
                Dim Sitm As OrphanageClasses.Bail = CType(itm.Value, OrphanageClasses.Bail)
                If CurrenciesConverter.ContainsKey(Sitm.Box.Currency_Short) Then Continue For
                If Sitm.Box.Currency_Short <> cur_short Then
                    Dim str As String = InputBox("أدخل سعر التصريف بحيث" & vbNewLine & "1 " & Sitm.Box.Currency_Short & "=", "", )
                    If Not IsNothing(str) AndAlso str.Length > 0 Then
                        Dim cur As New Currencies
                        Dim value As Decimal
                        Try
                            value = CDec(str)
                        Catch
                            Continue For
                        End Try
                        cur.CurrencyName = Sitm.Box.Currency_Name
                        cur.CurrencyShort = Sitm.Box.Currency_Short
                        cur.OneValuetoStaticBox = value
                        AddCurrnciesConverter(cur.CurrencyShort, cur)
                    End If
                End If
            Next
        End If
    End Sub
End Class

