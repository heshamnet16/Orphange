Imports Itenso.TimePeriod
Imports Orphanage.OrphanageClasses

Public Class FrmFather
    Private _ID As Integer
    'Private Odb As New OrphanageDB.Odb()
    Private _fath As Father
    Private Delegate Sub AutoCompleteDelegate()
    Private CallAutoComplete As New AutoCompleteDelegate(AddressOf SetAutoComplete)
    Dim t As New Threading.Thread(AddressOf CallAutoCompleteThread)
    Public Sub New(ByVal id As Integer)
        InitializeComponent()
        Me._ID = id
    End Sub
    Private Sub CallAutoCompleteThread()
        Me.Invoke(CallAutoComplete)
    End Sub
    Public Sub SetAutoComplete()
        Try
            Using Odb As New OrphanageDB.Odb
                Odb.ObjectTrackingEnabled = False
                'Dim qN = From nam In Odb.Names Select EF = nam.EName, EL = nam.ELast, Efath = nam.EFather Distinct
                Dim qFirst = From nam In Odb.Names Where nam.EName.Length > 0 Select nam.EName Distinct
                Dim qFather = From nam In Odb.Names Where nam.EFather.Length > 0 Select nam.EFather Distinct
                Dim qLast = From nam In Odb.Names Where nam.ELast.Length > 0 Select nam.ELast Distinct
                'Dim EFNamse As New ArrayList
                'Dim ELNamse As New ArrayList
                'For Each Nm In qN
                '    If Not IsNothing(Nm.EF) AndAlso Nm.EF.Length > 0 AndAlso Not EFNamse.Contains(Nm.EF) Then
                '        EFNamse.Add(Nm.EF)
                '    End If
                '    If Not IsNothing(Nm.Efath) AndAlso Nm.Efath.Length > 0 AndAlso Not EFNamse.Contains(Nm.Efath) Then
                '        EFNamse.Add(Nm.Efath)
                '    End If
                '    If Not IsNothing(Nm.EL) AndAlso Nm.EL.Length > 0 AndAlso Not ELNamse.Contains(Nm.EL) Then
                '        ELNamse.Add(Nm.EL)
                '    End If
                'Next
                'If EFNamse.Count > 0 Then
                '    NameForm1.English_First_AutoComplete.AddRange(CType(EFNamse.ToArray(GetType(String)), String()))
                '    NameForm1.English_Middle_AutoComplete.AddRange(CType(EFNamse.ToArray(GetType(String)), String()))
                'End If
                'If ELNamse.Count > 0 Then
                '    NameForm1.English_Last_AutoComplete.AddRange(CType(ELNamse.ToArray(GetType(String)), String()))
                'End If
                Dim xx = qFather.Where(Function(x) qFirst.Contains(x) = False)
                NameForm1.English_First_AutoComplete.AddRange(qFirst.ToArray())
                NameForm1.English_Middle_AutoComplete.AddRange(qFirst.ToArray())
                NameForm1.English_First_AutoComplete.AddRange(xx.ToArray())
                NameForm1.English_Middle_AutoComplete.AddRange(xx.ToArray())
                NameForm1.English_Last_AutoComplete.AddRange(qLast.ToArray())
                Dim qJ = From j In Odb.Fathers Where j.Jop.Length > 0 Select j.Jop Distinct
                'Dim JopArr As New ArrayList()
                'For Each jp In qJ
                '    If Not IsNothing(jp) AndAlso jp.Length > 0 AndAlso Not JopArr.Contains(jp) Then
                '        JopArr.Add(jp)
                '    End If
                'Next
                'If JopArr.Count > 0 Then
                '    txtJop.AutoCompleteCustomSource.AddRange(CType(JopArr.ToArray(GetType(String)), String()))
                'End If
                txtJop.AutoCompleteCustomSource.AddRange(qJ.ToArray())
                'Dim DeathR As New ArrayList()
                Dim qDr = From j In Odb.Fathers Where j.DeathResone.Length > 0 Select j.DeathResone Distinct
                'For Each dr In qDr
                '    If Not IsNothing(dr) AndAlso dr.Length > 0 AndAlso Not DeathR.Contains(dr) Then
                '        DeathR.Add(dr)
                '    End If
                'Next
                'If DeathR.Count > 0 Then
                '    txtJop.AutoCompleteCustomSource.AddRange(CType(DeathR.ToArray(GetType(String)), String()))
                'End If
                txtJop.AutoCompleteCustomSource.AddRange(qDr.ToArray())
                Odb.Dispose()
            End Using
        Catch
        End Try
    End Sub
    Public Sub SetNameForm(ByVal obj As OrphanageClasses.Name)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            NameForm1.First = obj.First
            NameForm1.Middle = obj.Father
            NameForm1.Last = obj.Last
            NameForm1.English_First = obj.EName
            NameForm1.English_Last = obj.ELast
            NameForm1.English_Middle = obj.EFather
            txtName.Text = obj.First & " " & obj.Father & " " & obj.Last
        End If
    End Sub
    Public Sub GetFromNameObject(ByRef obj As OrphanageClasses.Name)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            obj.First = NameForm1.First
            obj.Father = NameForm1.Middle
            obj.Last = NameForm1.Last
            obj.EName = NameForm1.English_First
            obj.ELast = NameForm1.English_Last
            obj.EFather = NameForm1.English_Middle
        Else
            obj = New OrphanageClasses.Name()
            obj.First = NameForm1.First
            obj.Father = NameForm1.Middle
            obj.Last = NameForm1.Last
            obj.EName = NameForm1.English_First
            obj.ELast = NameForm1.English_Last
            obj.EFather = NameForm1.English_Middle
        End If
    End Sub
    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Try
            Using Odb As New OrphanageDB.Odb
                Dim q = From fth In Odb.Fathers Where fth.ID = _ID Select fth
                Dim fath As OrphanageClasses.Father = q.FirstOrDefault()
                If My.Settings.CheckIdentityBeforEdit Then
                    If Not Checker.checkFatherControls(dteBirthday, dteDieDate, numIdentitynmber, NameForm1.First, NameForm1.Last, New Integer() {fath.Name_ID}) Then
                        Return
                    End If
                Else
                    Dim Tid = numIdentitynmber
                    Tid.Value = 0
                    If Not Checker.checkFatherControls(dteBirthday, dteDieDate, Tid, NameForm1.First, NameForm1.Last, New Integer() {fath.Name_ID}) Then
                        Return
                    End If
                End If
                GetFromNameObject(fath.Name)
                fath.DeathResone = txtDeathReson.Text
                fath.Jop = txtJop.Text
                fath.Note = txtNote.Text
                fath.Story = txtStory.Text
                fath.IdentityCard_ID = CULng(numIdentitynmber.Value)
                fath.Birthday = dteBirthday.Value
                fath.Dieday = dteDieDate.Value
                fath.DeathCertificate_Photo = picDeathCertificate.PhotoAsBytes
                fath.Photo = picPhoto.PhotoAsBytes
                If clrColor.Value <> Color.White Then
                    fath.Color_Mark = clrColor.Value.ToArgb()
                Else
                    fath.Color_Mark = Nothing
                End If
                Odb.SubmitChanges()
                ExceptionsManager.RaiseOnDesktopNow(New MyException("تم الحفظ", False, True))
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnDesktopNow(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub FrmFather_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Using Odb As New OrphanageDB.Odb
                If _ID > 0 Then
                    t.Priority = Threading.ThreadPriority.Lowest
                    t.Start()
                    Dim q = From fth In Odb.Fathers Where fth.ID = _ID Select fth
                    Dim fath As OrphanageClasses.Father = q.FirstOrDefault()
                    _fath = fath
                    If IsNothing(fath) Then
                        Dim myexc As New MyException("المتوفى رقم " & _ID.ToString() & " غير موجود.", True, True)
                        Me.Close()
                        Return
                    Else
                        txtName.Text = Getter.GetFullName(fath.Name)
                        txtDeathReson.Text = fath.DeathResone
                        txtJop.Text = fath.Jop
                        txtNote.Text = fath.Note
                        txtStory.Text = fath.Story
                        numIdentitynmber.Value = fath.IdentityCard_ID
                        dteBirthday.Value = fath.Birthday
                        dteDieDate.Value = fath.Dieday
                        picDeathCertificate.SetImageByBytes(fath.DeathCertificate_Photo)
                        picPhoto.SetImageByBytes(fath.Photo)
                        SetNameForm(fath.Name)
                        If Not IsNothing(fath.Color_Mark) AndAlso fath.Color_Mark.HasValue Then
                            clrColor.Value = Color.FromArgb(CInt(fath.Color_Mark.Value))
                        Else
                            clrColor.Value = Color.White
                        End If
                        Me.Text = "المتوفى " & Getter.GetFullName(fath.Name)
                    End If
                End If
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub txtName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.Enter
        NameForm1.ShowMe()
    End Sub

    Private Sub RadGroupBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStory.Click, txtNote.Click, txtJop.Click, txtDeathReson.Click, RadLabel9.Click, RadLabel7.Click, RadLabel6.Click, RadLabel5.Click, RadLabel4.Click, RadLabel3.Click, RadLabel10.Click, RadLabel1.Click, RadGroupBox2.Click, RadGroupBox1.Click, picPhoto.Click, picDeathCertificate.Click, numIdentitynmber.Click, MyBase.Click, RadLabel11.Click
        NameForm1.HideMe()
        txtName.Text = NameForm1.First & " " & NameForm1.Middle & " " & NameForm1.Last
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub picPhoto_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picPhoto.DoubleClick, picDeathCertificate.DoubleClick
        Try
            Dim picxx As PictureSelector.PictureSelector = CType(sender, PictureSelector.PictureSelector)
            Dim frmShopic As New FrmShowPic(picxx.Photo)
            frmShopic.MdiParent = My.Application.OpenForms("FrmMain")
            frmShopic.Show()
            WindowsLauncher.AllWindows.Add(frmShopic)
        Catch

        End Try
    End Sub
End Class
