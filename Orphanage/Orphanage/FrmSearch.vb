Imports Telerik.WinControls.UI

Public Class FrmSearch
    Dim odb As New OrphanageDB.Odb()
    Dim Ret As System.Linq.IQueryable(Of OrphanageClasses.Orphan)
    Dim ADDed As New ArrayList
    Dim _Stop As Boolean = False

#Region "ContextMenu"
    Dim WithEvents MainMnu As New RadContextMenu()
    Dim WithEvents SubSFamilies As New RadMenuItem("عرض العائلات")
    Dim WithEvents SubSFAthers As New RadMenuItem("عرض الآباء")
    Dim WithEvents SubSMothers As New RadMenuItem("عرض الأمهات")
    Dim WithEvents SubSBondsMen As New RadMenuItem("عرض المعيلين")

    Private Sub BuildContextList()
        'Show Menu
        MainMnu.Items.Add(SubSFamilies)
        MainMnu.Items.Add(SubSFAthers)
        MainMnu.Items.Add(SubSMothers)
        MainMnu.Items.Add(SubSBondsMen)
    End Sub
    Private Sub radDataGrid_ContextMenuOpening(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.ContextMenuOpeningEventArgs) Handles Radgrid.ContextMenuOpening
        e.ContextMenu = MainMnu.DropDown
    End Sub
#End Region



    Private Sub EnDisEnabledPage(ByRef pge As Telerik.WinControls.UI.RadPageViewPage, ByVal bol As Boolean)
        For Each cld In pge.Controls
            If TypeOf cld Is Telerik.WinControls.UI.RadCheckBox Then
                Dim chk As Telerik.WinControls.UI.RadCheckBox = CType(cld, Telerik.WinControls.UI.RadCheckBox)
                If Not chk.Text.Contains("تفعي") Then
                    chk.Enabled = bol
                End If
            End If
            If TypeOf cld Is Telerik.WinControls.UI.RadTextBox Then
                Dim chk As Telerik.WinControls.UI.RadTextBox = CType(cld, Telerik.WinControls.UI.RadTextBox)
                chk.Enabled = bol
            End If
            If TypeOf cld Is Telerik.WinControls.UI.RadGroupBox Then
                Dim chk As Telerik.WinControls.UI.RadGroupBox = CType(cld, Telerik.WinControls.UI.RadGroupBox)
                If bol Then
                    If chk Is grpFathDieDate Then
                        If chkFathEnabledDieDate.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
                            chk.Enabled = True
                        Else
                            chk.Enabled = False
                        End If
                    End If
                    If chk Is grpMothBirth Then
                        If chkMothEnabledBirth.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
                            chk.Enabled = True
                        Else
                            chk.Enabled = False
                        End If
                    End If
                    If chk Is grpOrphDate Then
                        If chkOrphEnabledBirthday.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
                            chk.Enabled = True
                        Else
                            chk.Enabled = False
                        End If
                    End If
                Else
                    chk.Enabled = False
                End If
            End If
            If TypeOf cld Is Telerik.WinControls.UI.RadDateTimePicker Then
                Dim chk As Telerik.WinControls.UI.RadDateTimePicker = CType(cld, Telerik.WinControls.UI.RadDateTimePicker)
                chk.Enabled = bol
            End If
            If TypeOf cld Is Telerik.WinControls.UI.RadSpinEditor Then
                Dim chk As Telerik.WinControls.UI.RadSpinEditor = CType(cld, Telerik.WinControls.UI.RadSpinEditor)
                chk.Enabled = bol
            End If
            If TypeOf cld Is Telerik.WinControls.UI.RadDropDownList Then
                Dim chk As Telerik.WinControls.UI.RadDropDownList = CType(cld, Telerik.WinControls.UI.RadDropDownList)
                chk.Enabled = bol
            End If
        Next
    End Sub
    Private Sub chkEnableOrph_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkEnableOrph.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            EnDisEnabledPage(pgeOrphan, True)
        Else
            EnDisEnabledPage(pgeOrphan, False)
        End If
    End Sub

    Private Sub chkEnableFath_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkEnableFath.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            EnDisEnabledPage(pgeFather, True)
        Else
            EnDisEnabledPage(pgeFather, False)
        End If
    End Sub

    Private Sub chkEnableMother_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkEnableMother.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            EnDisEnabledPage(pgeMother, True)
        Else
            EnDisEnabledPage(pgeMother, False)
        End If
    End Sub

    Private Sub chkEnableBondsMan_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkEnableBondsMan.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            EnDisEnabledPage(pgeBondsMan, True)
        Else
            EnDisEnabledPage(pgeBondsMan, False)
        End If
    End Sub

    Private Sub chkOrphEnabledBirthday_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkOrphEnabledBirthday.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            grpOrphDate.Enabled = True
        Else
            grpOrphDate.Enabled = False
        End If
    End Sub

    Private Sub chkFathEnabledDieDate_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkFathEnabledDieDate.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            grpFathDieDate.Enabled = True
        Else
            grpFathDieDate.Enabled = False
        End If
    End Sub

    Private Sub chkMothEnabledBirth_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkMothEnabledBirth.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            grpMothBirth.Enabled = True
        Else
            grpMothBirth.Enabled = False
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Ret = From orp In odb.Orphans Select orp
        ADDed.Clear()
        Radgrid.Rows.Clear()
        If chkEnableOrph.Checked = True Then
            If txtOrphNAme.Text.Length > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                 x.Name.First.Contains(txtOrphNAme.Text) OrElse
                                 x.Name.Father.Contains(txtOrphNAme.Text) OrElse
                                 x.Name.Last.Contains(txtOrphNAme.Text))
            End If
            If grpOrphDate.Enabled Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                 x.Birthday >= dteOrphFrom.Value AndAlso
                 x.Birthday <= dteOrphTo.Value)
            End If
            If numOrphAge.Value > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                        x.Age.HasValue AndAlso x.Age.Value = CInt(numOrphAge.Value))
            End If
            If txtOrphBirthPlace.Text.Length > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                    x.BirthPlace.Contains(txtOrphBirthPlace.Text))
            End If
            If txtOrphSex.Text.Length > 0 AndAlso Not txtOrphSex.Text.Contains("غير") Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                    x.Gender.Contains(txtOrphSex.Text))
            End If
            If numOrphKaid.Value > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                 x.Kaid.HasValue AndAlso x.Kaid.Value = CInt(numOrphKaid.Value))
            End If
            If chkOrphIsBaild.ToggleState <> Telerik.WinControls.Enumerations.ToggleState.Indeterminate Then
                If chkOrphIsBaild.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
                    Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                        x.Bail_ID.HasValue _
                                        OrElse x.Family.Baild_ID.HasValue)
                Else
                    Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                    Not x.Bail_ID.HasValue _
                    AndAlso Not x.Family.Baild_ID.HasValue)
                End If
            End If
            If chkOrphIsSick.ToggleState <> Telerik.WinControls.Enumerations.ToggleState.Indeterminate Then
                If chkOrphIsSick.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
                    Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                        x.Health_ID.HasValue)
                Else
                    Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                        Not x.Health_ID.HasValue)
                End If
            End If
            If chkOrphHasFacePhoto.ToggleState <> Telerik.WinControls.Enumerations.ToggleState.Indeterminate Then
                If chkOrphHasFacePhoto.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
                    Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                        x.FacePhoto Is Nothing = False)
                Else
                    Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                        x.FacePhoto Is Nothing = True)
                End If
            End If
            If chkOrphHasBodyPhoto.ToggleState <> Telerik.WinControls.Enumerations.ToggleState.Indeterminate Then
                If chkOrphHasBodyPhoto.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
                    Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                         x.FullPhoto Is Nothing = False)
                Else
                    Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                        x.FullPhoto Is Nothing = True)
                End If
            End If
        End If
        If chkEnableFath.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            If txtFathName.Text.Length > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                    x.Family.Father.Name.First.Contains(txtFathName.Text) OrElse _
                                    x.Family.Father.Name.Last.Contains(txtFathName.Text))
            End If
            If grpFathDieDate.Enabled Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                 x.Family.Father.Dieday >= dteFathFrom.Value AndAlso
                 x.Family.Father.Dieday <= dteFathTo.Value)
            End If
            If txtFathDeathRe.Text.Length > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                    x.Family.Father.DeathResone.Contains(txtFathDeathRe.Text))
            End If
            If txtFatheJop.Text.Length > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                    x.Family.Father.Jop.Contains(txtFatheJop.Text))
            End If
            If numFathId.Value > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                    x.Family.Father.IdentityCard_ID = numFathId.Value)
            End If
        End If
        'Mother
        If chkEnableMother.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            If txtMothName.Text.Length > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                 x.Family.Mother.Name.First.Contains(txtMothName.Text) OrElse
                                 x.Family.Mother.Name.Father.Contains(txtMothName.Text) OrElse
                                 x.Family.Mother.Name.Last.Contains(txtMothName.Text))
            End If
            If grpMothBirth.Enabled Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                 x.Family.Mother.Birthday >= dteMothFrom.Value AndAlso
                 x.Family.Mother.Birthday <= dteMothTo.Value)
            End If
            If txtMotheJop.Text.Length > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                    x.Family.Mother.Jop.Contains(txtMotheJop.Text))
            End If
            If txtMothAdd.Text.Length > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                        If(x.Family.Mother.Address_ID.HasValue, x.Family.Mother.Address.Country.Contains(txtMothAdd.Text), Nothing) _
                                        OrElse If(x.Family.Mother.Address_ID.HasValue, x.Family.Mother.Address.City.Contains(txtMothAdd.Text), Nothing) _
                                        OrElse If(x.Family.Mother.Address_ID.HasValue, x.Family.Mother.Address.Town.Contains(txtMothAdd.Text), Nothing) _
                                        OrElse If(x.Family.Mother.Address_ID.HasValue, x.Family.Mother.Address.Street.Contains(txtMothAdd.Text), Nothing) _
                                        OrElse If(x.Family.Address_ID.HasValue, x.Family.Address.Country.Contains(txtMothAdd.Text), Nothing) _
                                        OrElse If(x.Family.Address_ID.HasValue, x.Family.Address.City.Contains(txtMothAdd.Text), Nothing) _
                                        OrElse If(x.Family.Address_ID.HasValue, x.Family.Address.Town.Contains(txtMothAdd.Text), Nothing) _
                                        OrElse If(x.Family.Address_ID.HasValue, x.Family.Address.Street.Contains(txtMothAdd.Text), Nothing) _
                                        OrElse If(x.Family.Address_ID2.HasValue, x.Family.Address1.Country.Contains(txtMothAdd.Text), Nothing) _
                                        OrElse If(x.Family.Address_ID2.HasValue, x.Family.Address1.City.Contains(txtMothAdd.Text), Nothing) _
                                        OrElse If(x.Family.Address_ID2.HasValue, x.Family.Address1.Town.Contains(txtMothAdd.Text), Nothing) _
                                        OrElse If(x.Family.Address_ID2.HasValue, x.Family.Address1.Street.Contains(txtMothAdd.Text), Nothing))
            End If
            If numMothId.Value > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                              x.Family.Mother.IdntityCard_ID.HasValue AndAlso x.Family.Mother.IdntityCard_ID.Value = CULng(numMothId.Value))
            End If
            If chkMothIsDead.ToggleState <> Telerik.WinControls.Enumerations.ToggleState.Indeterminate Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                        x.Family.Mother.IsDead = chkMothIsDead.Checked)
            End If
            If chkMothIsMarried.ToggleState <> Telerik.WinControls.Enumerations.ToggleState.Indeterminate Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                        x.Family.Mother.IsMarried = chkMothIsMarried.Checked)
            End If
        End If
        'BondsMan
        If chkEnableBondsMan.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            If txtBondsName.Text.Length > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                 x.BondsMan.Name.First.Contains(txtBondsName.Text) OrElse
                                 x.BondsMan.Name.Father.Contains(txtBondsName.Text) OrElse
                                 x.BondsMan.Name.Last.Contains(txtBondsName.Text))
            End If
            If txtBondsAddre.Text.Length > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                        If(x.Family.Mother.Address_ID.HasValue, x.BondsMan.Address.Country.Contains(txtBondsAddre.Text), Nothing) _
                                        OrElse If(x.BondsMan.Address_ID.HasValue, x.BondsMan.Address.City.Contains(txtBondsAddre.Text), Nothing) _
                                        OrElse If(x.BondsMan.Address_ID.HasValue, x.BondsMan.Address.Town.Contains(txtBondsAddre.Text), Nothing) _
                                        OrElse If(x.BondsMan.Address_ID.HasValue, x.BondsMan.Address.Street.Contains(txtBondsAddre.Text), Nothing))
            End If
            If numBondsID.Value > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                 x.BondsMan.IdentityCard_ID.HasValue AndAlso x.BondsMan.IdentityCard_ID.Value = CULng(numBondsID.Value))
            End If
            If txtBondsJop.Text.Length > 0 Then
                Ret = Ret.Where(Function(x As OrphanageClasses.Orphan) _
                                 x.BondsMan.Jop.Contains(txtBondsJop.Text))
            End If
        End If
        If Ret.Count > 0 Then
            lblState.Text = "عدد النتائج : " & Ret.Count.ToString()
            btnShow.Enabled = True
        Else
            lblState.Text = "لا يوجد نتائج"
            btnShow.Enabled = False
        End If
    End Sub
    Private Sub AddNewOrphan(ByVal orp_ID As Integer)
        Using oDB1 As New OrphanageDB.Odb
            oDB1.ObjectTrackingEnabled = False
            Try
                Dim qO1n = From nam In oDB1.Names Join or1p In oDB1.Orphans On nam.ID Equals or1p.Name_ID
                    From fat In oDB1.Fathers Join Fnm In oDB1.Names On Fnm.ID Equals fat.Name_ID
                    From moth In oDB1.Mothers Join Mnm In oDB1.Names On moth.Name_ID Equals Mnm.ID
                    From Fam In oDB1.Families
                    Where Fam.Father_ID = fat.ID And moth.ID = Fam.Mother_ID And or1p.Family_ID = Fam.ID And orp_ID = or1p.ID
                    Select FAtherName = Fnm, MOtherName = Mnm, OrphanName = nam

                If Not IsNothing(qO1n) AndAlso qO1n.Count > 0 Then
                    Dim itm = Radgrid.Rows.AddNew
                    itm.Cells("ID").Value = orp_ID
                    itm.Cells("OrphanName").Value = qO1n.First.OrphanName.First
                    itm.Cells("FatherName").Value = Getter.GetFullName(qO1n.First.FAtherName)
                    itm.Cells("MotherName").Value = Getter.GetFullName(qO1n.First.MOtherName)
                End If

            Catch
            End Try
        End Using
    End Sub

    Private Sub FrmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadPageView1.SelectedPage = pgeOrphan
        BuildContextList()
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click

        lblState.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        btnSearch.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        btnShow.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        btnStop.Visibility = Telerik.WinControls.ElementVisibility.Visible
        radWatingBar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        CommandBarSeparator1.Size = New Size(Me.Width - 20, 18)
        CommandBarSeparator1.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        radWatingBar.StartWaiting()
        Radgrid.VirtualMode = True
        Dim Ids() As Integer = Ret.Select(Function(x) x.ID).ToArray()
        For Each or1 As Integer In Ids
            If (_Stop) Then
                _Stop = False
                CommandBarSeparator1.Visibility = Telerik.WinControls.ElementVisibility.Visible
                lblState.Visibility = Telerik.WinControls.ElementVisibility.Visible
                btnSearch.Visibility = Telerik.WinControls.ElementVisibility.Visible
                btnShow.Visibility = Telerik.WinControls.ElementVisibility.Visible
                btnStop.Visibility = Telerik.WinControls.ElementVisibility.Hidden
                radWatingBar.StopWaiting()
                radWatingBar.Visibility = Telerik.WinControls.ElementVisibility.Hidden
                Radgrid.VirtualMode = False
                btnShow.Enabled = False
                Exit Sub
            Else
                If Not ADDed.Contains(or1) Then
                    ADDed.Add(or1)
                    AddNewOrphan(or1)
                    Application.DoEvents()
                    Console.WriteLine(or1)
                End If
            End If
        Next
        CommandBarSeparator1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        lblState.Visibility = Telerik.WinControls.ElementVisibility.Visible
        btnSearch.Visibility = Telerik.WinControls.ElementVisibility.Visible
        btnShow.Visibility = Telerik.WinControls.ElementVisibility.Visible
        btnStop.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        radWatingBar.StopWaiting()
        radWatingBar.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        Radgrid.VirtualMode = False
        btnShow.Enabled = False
    End Sub

    Private Function GetOrphans() As Integer()
        If Not IsNothing(Radgrid.SelectedRows) AndAlso Radgrid.SelectedRows.Count > 0 Then
            Dim orphs As New ArrayList            
            For Each row In Radgrid.SelectedRows
                Using Odb As New OrphanageDB.Odb
                    Try
                        Dim Id As Integer = CInt(row.Cells("ID").Value)
                        If Id > 0 AndAlso Not orphs.Contains(Id) Then
                            orphs.Add(Id)
                        End If
                    Catch

                    End Try
                    Odb.Dispose()
                End Using
            Next
            If orphs.Count > 0 Then
                Return CType(orphs.ToArray(GetType(Integer)), Integer())
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

    Private Sub SubSFamilies_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubSFamilies.Click
        Dim oss = GetOrphans()
        If Not IsNothing(oss) Then
            Dim fAm_Ids As New ArrayList()
            For Each o_id In oss
                Dim fam_id As Integer = Getter.GetFamily_IDByOrphan_ID(o_id)
                If fam_id > 0 AndAlso Not fAm_Ids.Contains(fam_id) Then
                    fAm_Ids.Add(fam_id)
                End If
            Next
            WindowsLauncher.LaunchFamilies(CType(fAm_Ids.ToArray(GetType(Integer)), Integer()))
        End If
    End Sub

    Private Sub SubSFAthers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubSFAthers.Click
        Dim oss = GetOrphans()
        If Not IsNothing(oss) Then
            Dim fAm_Ids As New ArrayList()
            For Each o_id In oss
                Dim fam_id As Integer = Getter.GetFather_IDByOrphan_ID(o_id)
                If fam_id > 0 AndAlso Not fAm_Ids.Contains(fam_id) Then
                    fAm_Ids.Add(fam_id)
                End If
            Next
            WindowsLauncher.LaunchFathers(CType(fAm_Ids.ToArray(GetType(Integer)), Integer()))
        End If
    End Sub

    Private Sub SubSMothers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubSMothers.Click
        Dim oss = GetOrphans()
        If Not IsNothing(oss) Then
            Dim fAm_Ids As New ArrayList()
            For Each o_id In oss
                Dim fam_id As Integer = Getter.GetMother_IDByOrphan_ID(o_id)
                If fam_id > 0 AndAlso Not fAm_Ids.Contains(fam_id) Then
                    fAm_Ids.Add(fam_id)
                End If
            Next
            WindowsLauncher.LaunchMothers(CType(fAm_Ids.ToArray(GetType(Integer)), Integer()))
        End If
    End Sub

    Private Sub SubSBondsMen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubSBondsMen.Click
        Dim oss = GetOrphans()
        If Not IsNothing(oss) Then
            Dim fAm_Ids As New ArrayList()
            For Each o_id In oss
                Dim fam_id As Integer = Getter.GetBondsMan_IDByOrphan_ID(o_id)
                If fam_id > 0 AndAlso Not fAm_Ids.Contains(fam_id) Then
                    fAm_Ids.Add(fam_id)
                End If
            Next
            WindowsLauncher.LaunchFamilies(CType(fAm_Ids.ToArray(GetType(Integer)), Integer()))
        End If
    End Sub

    Private Sub Radgrid_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radgrid.DoubleClick
        Try
            Dim Id As Integer = CInt(Radgrid.SelectedRows(0).Cells("ID").Value)
            If Id > 0 Then
                Dim frm As New FrmOrphan(Id)
                frm.MdiParent = Application.OpenForms("frmMain")
                frm.Show()
            End If
        Catch

        End Try
    End Sub

    Private Sub pgeOrphan_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pgeOrphan.Paint

    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        _Stop = True
    End Sub
End Class
