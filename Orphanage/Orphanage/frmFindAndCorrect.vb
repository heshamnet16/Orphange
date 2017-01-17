Imports Itenso.TimePeriod
Public Class FrmFindAndCorrect
    Dim All1 As Integer = 0
    Dim All2 As Integer = 0
    Dim i1 As Integer = 0
    Dim i2 As Integer = 0
    Dim Stage As String = "Orphan"
    Dim CurrentID As Integer = 0
    Dim _Pause = False, _Stop As Boolean = False
    Dim OrphansArr As New ArrayList()
    Dim FathersArr As New ArrayList()
    Dim MothersArr As New ArrayList()
    Dim BondsManArr As New ArrayList()
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If btnStart.Text = "ابدأ" Then
            i1 = 0
            i2 = 0
            All1 = 0
            All2 = 0
            _Pause = False
            _Stop = False
            Stage = "Orphan"
            CurrentID = 0
            btnStart.Text = "توقف مؤقت"
            RadGroupBox1.Enabled = False
            RadGroupBox2.Enabled = False
            RadGroupBox4.Enabled = False
            Start()
            If Not _Pause Then
                RadGroupBox1.Enabled = True
                RadGroupBox2.Enabled = True
                RadGroupBox4.Enabled = True
                progAll.Value1 = 0
                progAll.Text = ""
                ProgCurrent.Value1 = 0
                ProgCurrent.Text = ""
                btnStart.Text = "ابدأ"
            End If
        ElseIf btnStart.Text = "توقف مؤقت" Then
            btnStart.Text = "استمرار"
            _Pause = True
        Else
            btnStart.Text = "توقف مؤقت"
            _Pause = False
            RadGroupBox1.Enabled = False
            RadGroupBox2.Enabled = False
            RadGroupBox4.Enabled = False
            Start()
            If Not _Pause Then
                RadGroupBox1.Enabled = True
                RadGroupBox2.Enabled = True
                RadGroupBox4.Enabled = True
                progAll.Value1 = 0
                progAll.Text = ""
                ProgCurrent.Value1 = 0
                ProgCurrent.Text = ""
                btnStart.Text = "ابدأ"
            End If
        End If
    End Sub
    Private Sub Start()
        Try
            If i1 = 0 Then
                Using Odb As New OrphanageDB.Odb
                    Dim qOrph = From op In Odb.Orphans Select op.ID Order By ID Ascending
                    Dim qMoth = From op In Odb.Mothers Select op.ID Order By ID Ascending
                    Dim qFath = From op In Odb.Fathers Select op.ID Order By ID Ascending
                    Dim qBond = From op In Odb.BondsMans Select op.ID Order By ID Ascending
                    If Not IsNothing(qOrph) AndAlso qOrph.Count > 0 Then
                        Dim arr() As Integer = qOrph.ToArray()
                        OrphansArr.AddRange(arr)
                        All1 += OrphansArr.Count
                    End If
                    If Not IsNothing(qFath) AndAlso qFath.Count > 0 Then
                        Dim arr() As Integer = qFath.ToArray()
                        FathersArr.AddRange(arr)
                        All1 += FathersArr.Count
                    End If
                    If Not IsNothing(qMoth) AndAlso qMoth.Count > 0 Then
                        Dim arr() As Integer = qMoth.ToArray()
                        MothersArr.AddRange(arr)
                        All1 += MothersArr.Count
                    End If
                    If Not IsNothing(qBond) AndAlso qBond.Count > 0 Then
                        Dim arr() As Integer = qBond.ToArray()
                        BondsManArr.AddRange(arr)
                        All1 += BondsManArr.Count
                    End If
                End Using
            End If
            If Stage = "Orphan" Then
                For Oid As Integer = CurrentID To OrphansArr.Count - 1
                    Try
                        i2 = 0
                        All2 = 0
                        If _Pause Then
                            Exit Sub
                        End If
                        If _Stop Then
                            i1 = 0
                            i2 = 0
                            All1 = 0
                            All2 = 0
                            CurrentID = 0
                            Stage = "Orphan"
                            Exit Sub
                        End If
                        Dim OrphanID As Integer = OrphansArr(Oid)
                        Using Odb As New OrphanageDB.Odb
                            Dim q = From op In Odb.Orphans Where op.ID = OrphanID Select op
                            If Not IsNothing(q) AndAlso q.Count > 0 Then
                                If chkOrphansAges.Checked Then
                                    If chkEditStudyStage.Checked AndAlso q.FirstOrDefault.Age > 6 AndAlso q.FirstOrDefault.Age < 19 Then
                                        If q.FirstOrDefault.Education_ID.HasValue AndAlso Not q.FirstOrDefault.Study.Stage.Contains("متخلف") Then
                                            Select Case q.FirstOrDefault.Age
                                                Case 7
                                                    q.FirstOrDefault.Study.Stage = "الصف الأول الابتدائي"
                                                Case 8
                                                    q.FirstOrDefault.Study.Stage = "الصف الثاني الابتدائي"
                                                Case 9
                                                    q.FirstOrDefault.Study.Stage = "الصف الثالث الابتدائي"
                                                Case 10
                                                    q.FirstOrDefault.Study.Stage = "الصف الرابع الابتدائي"
                                                Case 11
                                                    q.FirstOrDefault.Study.Stage = "الصف الخامس الابتدائي"
                                                Case 12
                                                    q.FirstOrDefault.Study.Stage = "الصف السادس الابتدائي"
                                                Case 13
                                                    q.FirstOrDefault.Study.Stage = "الصف السابع الاعدادي"
                                                Case 14
                                                    q.FirstOrDefault.Study.Stage = "الصف الثامن الاعدادي"
                                                Case 15
                                                    q.FirstOrDefault.Study.Stage = "الصف التاسع الاعدادي"
                                                Case 16
                                                    q.FirstOrDefault.Study.Stage = "الصف الأول الثانوي"
                                                Case 17
                                                    q.FirstOrDefault.Study.Stage = "الصف الثاني الثانوي"
                                                Case 18
                                                    q.FirstOrDefault.Study.Stage = "الصف الثالث الثانوي"
                                            End Select
                                            AddToList(OrphanID.ToString(), Getter.GetFullName(q.FirstOrDefault.Name), "اليتيم", " تم تعديل المرحلة الدراسية بحسب العمر.")

                                            Odb.SubmitChanges()
                                        End If
                                    End If
                                    If q.FirstOrDefault.Age > My.Settings.OrphanAllowedAge Then
                                        If optOrphanDelete.IsChecked Then
                                            If Deleter.DeleteOrphan(OrphanID) Then
                                                AddToList(OrphanID.ToString(), Getter.GetFullName(q.FirstOrDefault.Name), "يتيم", "تم حذف اليتيم")
                                            Else
                                                AddToList(OrphanID.ToString(), Getter.GetFullName(q.FirstOrDefault.Name), "يتيم", "خطأ لم يتم حذف اليتيم")
                                            End If
                                        End If
                                        If optOrphanExclude.IsChecked Then
                                            If Deleter.ExcludeOrphan(OrphanID) Then
                                                AddToList(OrphanID.ToString(), Getter.GetFullName(q.FirstOrDefault.Name), "اليتيم", "تم استبعاد اليتيم")
                                            Else
                                                AddToList(OrphanID.ToString(), Getter.GetFullName(q.FirstOrDefault.Name), "اليتيم", "خطأ لم يتم استبعاد اليتيم")
                                            End If
                                        End If
                                        If RadRadioButton1.IsChecked Then
                                            AddToList(OrphanID.ToString(), Getter.GetFullName(q.FirstOrDefault.Name), "اليتيم", "اكبر من " & ATDFormater.ArabicDateFormater.GetArabicYear(My.Settings.OrphanAllowedAge))
                                        End If
                                    End If
                                End If
                                If chkIds.Checked AndAlso q.FirstOrDefault.IdentityNumber.HasValue AndAlso q.FirstOrDefault.IdentityNumber.Value > 0 Then
                                    CheckId(q.FirstOrDefault.IdentityNumber.Value, OrphanID.ToString, "اليتيم", q.FirstOrDefault.Name)
                                End If
                                If chkNames.Checked Then
                                    CheckNames(q.FirstOrDefault.Name, OrphanID, "اليتيم")
                                End If
                            End If
                            i1 += 1
                            CurrentID += 1
                            ShowProg1("اليتيم" & ": " & Getter.GetFullName(q.FirstOrDefault.Name))
                        End Using
                    Catch eO As Exception
                        AddToList(Oid.ToString(), eO.Message, "", "")
                    End Try
                Next
                CurrentID = 0
                Stage = "Father"
            End If
            If Stage = "Father" Then
                For Fid As Integer = CurrentID To FathersArr.Count - 1
                    Try
                        i2 = 0
                        All2 = 0
                        If _Pause Then
                            Exit Sub
                        End If
                        If _Stop Then
                            i1 = 0
                            i2 = 0
                            All1 = 0
                            All2 = 0
                            CurrentID = 0
                            Stage = "Orphan"
                            Exit Sub
                        End If
                        Dim FatherID As Integer = FathersArr(Fid)
                        Using Odb As New OrphanageDB.Odb
                            Dim q = From op In Odb.Fathers Where op.ID = FatherID Select op
                            If Not IsNothing(q) AndAlso q.Count > 0 Then
                                If chkIds.Checked AndAlso q.FirstOrDefault.IdentityCard_ID > 0 Then
                                    CheckId(q.FirstOrDefault.IdentityCard_ID, FatherID.ToString, "المتوفى", q.FirstOrDefault.Name)
                                End If
                                If chkNames.Checked Then
                                    CheckNames(q.FirstOrDefault.Name, FatherID, "المتوفى")
                                End If
                            End If
                            i1 += 1
                            CurrentID += 1
                            ShowProg1("المتوفى" & ": " & Getter.GetFullName(q.FirstOrDefault.Name))
                        End Using
                    Catch eO As Exception
                        AddToList(Fid.ToString(), eO.Message, "", "")
                    End Try
                Next
                CurrentID = 0
                Stage = "Mother"
            End If
            If Stage = "Mother" Then
                For Mid As Integer = CurrentID To MothersArr.Count - 1
                    Try
                        i2 = 0
                        All2 = 0
                        If _Pause Then
                            Exit Sub
                        End If
                        If _Stop Then
                            i1 = 0
                            i2 = 0
                            All1 = 0
                            All2 = 0
                            CurrentID = 0
                            Stage = "Orphan"
                            Exit Sub
                        End If
                        Dim MotherID As Integer = MothersArr(Mid)
                        Using Odb As New OrphanageDB.Odb
                            Dim q = From op In Odb.Mothers Where op.ID = MotherID Select op
                            If Not IsNothing(q) AndAlso q.Count > 0 Then
                                If chkIds.Checked AndAlso q.FirstOrDefault.IdntityCard_ID.HasValue AndAlso q.FirstOrDefault.IdntityCard_ID.Value > 0 Then
                                    CheckId(q.FirstOrDefault.IdntityCard_ID.Value, MotherID.ToString, "الأم", q.FirstOrDefault.Name)
                                ElseIf Not q.FirstOrDefault.IdntityCard_ID.HasValue Then
                                    AddToList(MotherID.ToString(), Getter.GetFullName(q.FirstOrDefault.Name), "الأم", "تنبيه لم يتم إدخال رقم الهوية")
                                ElseIf q.FirstOrDefault.IdntityCard_ID.HasValue AndAlso q.FirstOrDefault.IdntityCard_ID.Value < 1000 Then
                                    AddToList(MotherID.ToString(), Getter.GetFullName(q.FirstOrDefault.Name), "الأم", "تنبيه لم يتم إدخال رقم الهوية")
                                End If
                                If chkNames.Checked Then
                                    CheckNames(q.FirstOrDefault.Name, MotherID, "الأم")
                                End If
                            End If
                            i1 += 1
                            CurrentID += 1
                            ShowProg1("الأم" & ": " & Getter.GetFullName(q.FirstOrDefault.Name))
                        End Using
                    Catch eO As Exception
                        AddToList(Mid.ToString(), eO.Message, "", "")
                    End Try
                Next
                CurrentID = 0
                Stage = "BondsMan"
            End If
            If Stage = "BondsMan" Then
                For Bid As Integer = CurrentID To BondsManArr.Count - 1
                    Try
                        i2 = 0
                        All2 = 0
                        If _Pause Then
                            Exit Sub
                        End If
                        If _Stop Then
                            i1 = 0
                            i2 = 0
                            All1 = 0
                            All2 = 0
                            CurrentID = 0
                            Stage = "Orphan"
                            Exit Sub
                        End If
                        Dim MotherID As Integer = BondsManArr(Bid)
                        Using Odb As New OrphanageDB.Odb
                            Dim q = From op In Odb.BondsMans Where op.ID = MotherID Select op
                            If Not IsNothing(q) AndAlso q.Count > 0 Then
                                If chkIds.Checked AndAlso q.FirstOrDefault.IdentityCard_ID.HasValue AndAlso q.FirstOrDefault.IdentityCard_ID.Value > 0 Then
                                    CheckId(q.FirstOrDefault.IdentityCard_ID.Value, MotherID.ToString, "المعيل", q.FirstOrDefault.Name)
                                ElseIf Not q.FirstOrDefault.IdentityCard_ID.HasValue Then
                                    AddToList(MotherID.ToString(), Getter.GetFullName(q.FirstOrDefault.Name), "المعيل", "تنبيه لم يتم إدخال رقم الهوية")
                                ElseIf q.FirstOrDefault.IdentityCard_ID.HasValue AndAlso q.FirstOrDefault.IdentityCard_ID.Value < 1000 Then
                                    AddToList(MotherID.ToString(), Getter.GetFullName(q.FirstOrDefault.Name), "المعيل", "تنبيه لم يتم إدخال رقم الهوية")
                                End If
                                If chkNames.Checked Then
                                    CheckNames(q.FirstOrDefault.Name, MotherID, "المعيل")
                                End If
                            End If
                            i1 += 1
                            CurrentID += 1
                            ShowProg1("المعيل" & ": " & Getter.GetFullName(q.FirstOrDefault.Name))
                        End Using
                    Catch eO As Exception
                        AddToList(Bid.ToString(), eO.Message, "", "")
                    End Try
                Next
                i1 = 0
                i2 = 0
                All1 = 0
                All2 = 0
                CurrentID = 0
                Stage = "Orphan"
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True))
            Me.Close()
        End Try
    End Sub

    Private Sub AddToList(ByVal Number As String, ByVal NAme As String, ByVal Type1 As String, ByVal Notea As String)
        LstLog.Items.Add(New String() {Number, NAme, Type1, Notea})
    End Sub

    Private Sub CheckId(ByVal id As String, ByVal Sid As String, ByVal Stype As String, ByVal Sname As OrphanageClasses.Name)
        Try
            Using Odb As New OrphanageDB.Odb
                Dim type As String = ""
                Dim qOrph = From orps In Odb.Orphans Where orps.Name_ID <> Sname.ID AndAlso orps.IdentityNumber.ToString = id Select orps

                Dim qMoth = From moths In Odb.Mothers Where moths.Name_ID <> Sname.ID AndAlso moths.IdntityCard_ID.ToString() = id Select moths

                Dim qFath = From fahts In Odb.Fathers Where fahts.Name_ID <> Sname.ID AndAlso fahts.IdentityCard_ID.ToString() = id Select fahts

                Dim qBond = From bonds In Odb.BondsMans Where bonds.Name_ID <> Sname.ID AndAlso bonds.IdentityCard_ID.ToString() = id Select bonds

                If Not IsNothing(qMoth) Then All2 += qMoth.Count
                If Not IsNothing(qOrph) Then All2 += qOrph.Count
                If Not IsNothing(qFath) Then All2 += qFath.Count
                If Not IsNothing(qBond) Then All2 += qBond.Count

                If Not IsNothing(qOrph) AndAlso qOrph.Count > 0 Then
                    type = "اليتيم"
                    For Each orp In qOrph
                        AddToList(Sid, Getter.GetFullName(Sname), Stype, "رقم هوية متطابق مع " & type & " " & Getter.GetFullName(orp.Name))
                        i2 += 1
                        ShowProg2(Getter.GetFullName(orp.Name))
                    Next
                End If
                If Not IsNothing(qMoth) AndAlso qMoth.Count > 0 Then
                    type = "الأم"
                    For Each orp In qMoth
                        If Sname.First <> orp.Name.First AndAlso Sname.Last <> orp.Name.Last Then
                            AddToList(Sid, Getter.GetFullName(Sname), Stype, "رقم هوية متطابق مع " & type & " " & Getter.GetFullName(orp.Name))
                            i2 += 1
                        Else
                            i2 -= 1
                        End If
                        ShowProg2(Getter.GetFullName(orp.Name))
                    Next
                End If
                If Not IsNothing(qFath) AndAlso qFath.Count > 0 Then
                    type = "المتوفى"
                    For Each orp In qFath
                        AddToList(Sid, Getter.GetFullName(Sname), Stype, "رقم هوية متطابق مع " & type & " " & Getter.GetFullName(orp.Name))
                        i2 += 1
                        ShowProg2(Getter.GetFullName(orp.Name))
                    Next
                End If
                If Not IsNothing(qBond) AndAlso qBond.Count > 0 Then
                    type = "المعيل"
                    For Each orp In qBond
                        If Sname.First <> orp.Name.First AndAlso Sname.Last <> orp.Name.Last Then
                            AddToList(Sid, Getter.GetFullName(Sname), Stype, "رقم هوية متطابق مع " & type & " " & Getter.GetFullName(orp.Name))
                            i2 += 1
                        Else
                            i2 -= 1
                        End If
                        ShowProg2(Getter.GetFullName(orp.Name))
                    Next
                End If
                Odb.Dispose()
            End Using
        Catch

        End Try
    End Sub
    Private Sub CheckNames(ByVal SName As OrphanageClasses.Name, ByVal SId As Integer, ByVal Stype As String)
        Try
            Using Odb As New OrphanageDB.Odb
                Dim type As String = ""
                Dim qToCapital = From nam In Odb.Names Where nam.ID = SName.ID Select nam

                For Each nam In qToCapital
                    Dim submit As Boolean = False
                    If Not IsNothing(nam.EFather) AndAlso nam.EFather.Length > 0 AndAlso Char.IsLower(nam.EFather(0)) Then
                        nam.EFather = Char.ToUpper(nam.EFather(0)) & nam.EFather.Substring(1, nam.EFather.Length - 1)
                        submit = True
                    End If
                    If Not IsNothing(nam.ELast) AndAlso nam.ELast.Length > 0 AndAlso Char.IsLower(nam.ELast(0)) Then
                        nam.ELast = Char.ToUpper(nam.ELast(0)) & nam.ELast.Substring(1, nam.ELast.Length - 1)
                        submit = True
                    End If
                    If Not IsNothing(nam.EName) AndAlso nam.EName.Length > 0 AndAlso Char.IsLower(nam.EName(0)) Then
                        nam.EName = Char.ToUpper(nam.EName(0)) & nam.EName.Substring(1, nam.EName.Length - 1)
                        submit = True
                    End If
                    If submit Then
                        AddToList(SId.ToString(), Getter.GetFullName(SName), Stype, "تصحيح الاسم باللغة الانكليزية")
                        Odb.SubmitChanges()
                    End If
                Next
                Dim qOrph = From orps In Odb.Orphans Where orps.Name_ID <> SName.ID AndAlso _
                            orps.Name.First = SName.First AndAlso orps.Name.Father = SName.Father _
                            AndAlso orps.Name.Last = SName.Last Select orps

                Dim qMoth = From moths In Odb.Mothers Where moths.Name_ID <> SName.ID AndAlso _
                            moths.Name.First = SName.First AndAlso moths.Name.Father = SName.Father _
                            AndAlso moths.Name.Last = SName.Last Select moths

                Dim qFath = From fahts In Odb.Fathers Where fahts.Name_ID <> SName.ID AndAlso _
                            fahts.Name.First = SName.First AndAlso fahts.Name.Father = SName.Father _
                            AndAlso fahts.Name.Last = SName.Last Select fahts

                Dim qBond = From bonds In Odb.BondsMans Where bonds.Name_ID <> SName.ID AndAlso _
                            bonds.Name.First = SName.First AndAlso bonds.Name.Father = SName.Father _
                            AndAlso bonds.Name.Last = SName.Last Select bonds

                If Not IsNothing(qOrph) AndAlso qOrph.Count > 0 AndAlso Stype = "اليتيم" Then
                    type = "اليتيم"
                    All2 += qOrph.Count
                    For Each orp In qOrph
                        Dim qMn = From op In Odb.Orphans Where op.ID = SId Select op.Family.Mother.Name
                        If Not IsNothing(qMn) AndAlso qMn.Count > 0 Then
                            If orp.Family.Mother.Name.First = qMn.FirstOrDefault.First Then
                                AddToList(SId, Getter.GetFullName(SName), Stype, "الاسم متطابق مع " & type & " " & Getter.GetFullName(orp.Name))
                            End If
                        End If
                        i2 += 1
                        ShowProg2(Getter.GetFullName(orp.Name))
                    Next
                End If
                If Not IsNothing(qMoth) AndAlso qMoth.Count > 0 AndAlso (Stype = "الأم" OrElse Stype = "المعيل") Then
                    type = "الأم"
                    All2 += qMoth.Count
                    For Each orp In qMoth
                        If qMoth.Count > 1 Then
                            AddToList(SId, Getter.GetFullName(SName), Stype, "الاسم متطابق مع " & type & " " & Getter.GetFullName(orp.Name))
                            i2 += 1
                        End If
                        ShowProg2(Getter.GetFullName(orp.Name))
                    Next
                End If
                If Not IsNothing(qFath) AndAlso qFath.Count > 0 AndAlso Stype = "المتوفى" Then
                    type = "المتوفى"
                    All2 += qFath.Count
                    For Each orp In qFath
                        AddToList(SId, Getter.GetFullName(SName), Stype, "الاسم متطابق مع " & type & " " & Getter.GetFullName(orp.Name))
                        i2 += 1
                        ShowProg2(Getter.GetFullName(orp.Name))
                    Next
                End If
                If Not IsNothing(qBond) AndAlso qBond.Count > 0 AndAlso (Stype = "الأم" OrElse Stype = "المعيل") Then
                    type = "المعيل"
                    All2 += qBond.Count
                    For Each orp In qBond
                        If qBond.Count > 1 Then
                            AddToList(SId, Getter.GetFullName(SName), Stype, "الاسم متطابق مع " & type & " " & Getter.GetFullName(orp.Name))
                            i2 += 1
                        End If
                        ShowProg2(Getter.GetFullName(orp.Name))
                    Next
                End If
                    Odb.Dispose()
            End Using
        Catch

        End Try
    End Sub
    Private Sub ShowProg2(ByVal str As String)
        Dim val As Integer = (CDec(i2) / CDec(All2)) * 100D
        If val <= 100 AndAlso val >= 0 Then
            ProgCurrent.Value1 = val
            ProgCurrent.Text = str
            Application.DoEvents()
        End If
    End Sub
    Private Sub ShowProg1(ByVal str As String)
        Dim val As Integer = (CDec(i1) / CDec(All1)) * 100D
        progAll.Value1 = val
        progAll.Text = str
        Application.DoEvents()
    End Sub

    Private Sub FrmFindAndCorrect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        _Stop = True
        btnStart.Text = "ابدأ"
        RadGroupBox1.Enabled = True
        RadGroupBox2.Enabled = True
        RadGroupBox4.Enabled = True
        progAll.Value1 = 0
        progAll.Text = ""
        ProgCurrent.Value1 = 0
        ProgCurrent.Text = ""
    End Sub

    Private Sub chkOrphansAges_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkOrphansAges.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            RadGroupBox1.Enabled = True
        Else
            RadGroupBox1.Enabled = False
        End If
    End Sub
End Class
