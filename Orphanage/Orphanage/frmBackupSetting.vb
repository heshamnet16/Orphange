
Public Class FrmBackupSetting
    Dim xmlS As New XMLMapping.TimerClass(CurDir() & "\STD.Xaml")
    Private Sub RadCheckBox1_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkIsON.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            xmlS.IsON = True
            grpPath.Enabled = True
            grpRepete.Enabled = True
            grpSchdu.Enabled = True
        Else
            xmlS.IsON = False
            grpPath.Enabled = False
            grpRepete.Enabled = False
            grpSchdu.Enabled = False
        End If
    End Sub

    Private Sub btnChooseFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseFolder.Click
        Dim fld As New FolderBrowserDialog()
        fld.Description = "أختر مجلد الحفظ"
        fld.RootFolder = Environment.SpecialFolder.MyComputer
        fld.ShowNewFolderButton = True
        If fld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtFolderName.Text = fld.SelectedPath()
        End If
        fld.Dispose()
    End Sub

    Private Sub numMaxCopiesNum_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numMaxCopiesNum.ValueChanged
        xmlS.MaxDatabaseCopies = CByte(numMaxCopiesNum.Value)
    End Sub

    Private Sub FrmBackupSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtFileName.Text = xmlS.FileName
        txtFolderName.Text = xmlS.FolderName
        chkDaily.IsChecked = xmlS.isDaily
        chkMonthly.IsChecked = xmlS.IsMonthly
        chkIsON.Checked = xmlS.IsON
        chkWeekly.IsChecked = xmlS.isWeekly
        chkCreateNewFolder.Checked = xmlS.MakeNewFolder
        numMaxCopiesNum.Value = xmlS.MaxDatabaseCopies
        chkOnFriday.Checked = xmlS.OnFriday
        chkOnMonday.Checked = xmlS.OnMonday
        chkOnSaturday.Checked = xmlS.OnSatarday
        chkOnSunday.Checked = xmlS.OnSunday
        chkOnThuresday.Checked = xmlS.OnThrusday
        chkOnTuesday.Checked = xmlS.OnTuesday
        chkOnWednesday.Checked = xmlS.OnWendsday
        chkReplaceOldest.Checked = xmlS.ReplaceOldDB
        dteDate.Value = New Date(xmlS.NextDate.Year, xmlS.NextDate.Month, xmlS.NextDate.Day)
        dteTime.Value = New Date(xmlS.NextDate.Year, xmlS.NextDate.Month, xmlS.NextDate.Day, xmlS.NextDate.Hour, xmlS.NextDate.Minute, 0)
        chkWeekly_ToggleStateChanged(chkWeekly, New Telerik.WinControls.UI.StateChangedEventArgs(chkWeekly.ToggleState))
        RadCheckBox1_ToggleStateChanged(chkIsON, New Telerik.WinControls.UI.StateChangedEventArgs(chkIsON.ToggleState))
    End Sub

    Private Sub FrmBackupSetting_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        xmlS.NextDate = New Date(dteDate.Value.Year, dteDate.Value.Month, dteDate.Value.Day, dteTime.Value.Value.Hour, 0, 0)
        If chkIsON.Checked Then
            If txtFolderName.Text.Length <= 2 Then
                ExceptionsManager.RaiseOnStatus(New MyException("يجب عليك أختيار مجلد", False, True))
                btnChooseFolder.Focus()
                e.Cancel = True
                Return
            End If
            If chkWeekly.IsChecked Then
                If Not chkOnFriday.Checked AndAlso Not chkOnMonday.Checked AndAlso Not chkOnSaturday.Checked AndAlso _
                    Not chkOnSunday.Checked AndAlso Not chkOnThuresday.Checked AndAlso Not chkOnTuesday.Checked _
                    AndAlso Not chkOnWednesday.Checked Then
                    ExceptionsManager.RaiseOnStatus(New MyException("يجب تحديد يوم واحد في الاسبوع", False, True))
                    e.Cancel = True
                    chkOnSaturday.Focus()
                    Return
                End If
            End If
            If xmlS.NextDate <= Date.Now Then
                ExceptionsManager.RaiseOnStatus(New MyException("يجب تحديد تاريخ مستقبلي", False, True))
                e.Cancel = True
                dteDate.Focus()
                Return
            End If
        End If
        xmlS.FileName = txtFileName.Text
        xmlS.FolderName = txtFolderName.Text
        xmlS.isDaily = chkDaily.IsChecked
        xmlS.IsMonthly = chkMonthly.IsChecked
        xmlS.IsON = chkIsON.Checked
        xmlS.isWeekly = chkWeekly.IsChecked
        xmlS.MakeNewFolder = chkCreateNewFolder.Checked
        xmlS.MaxDatabaseCopies = CByte(numMaxCopiesNum.Value)
        xmlS.OnFriday = chkOnFriday.Checked
        xmlS.OnMonday = chkOnMonday.Checked
        xmlS.OnSatarday = chkOnSaturday.Checked
        xmlS.OnSunday = chkOnSunday.Checked
        xmlS.OnThrusday = chkOnThuresday.Checked
        xmlS.OnTuesday = chkOnTuesday.Checked
        xmlS.OnWendsday = chkOnWednesday.Checked
        xmlS.ReplaceOldDB = chkReplaceOldest.Checked
        xmlS.Save()
    End Sub

    Private Sub chkWeekly_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkWeekly.ToggleStateChanged
        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            chkOnFriday.Enabled = True
            chkOnMonday.Enabled = True
            chkOnSaturday.Enabled = True
            chkOnSunday.Enabled = True
            chkOnThuresday.Enabled = True
            chkOnTuesday.Enabled = True
            chkOnWednesday.Enabled = True
        Else
            chkOnFriday.Enabled = False
            chkOnMonday.Enabled = False
            chkOnSaturday.Enabled = False
            chkOnSunday.Enabled = False
            chkOnThuresday.Enabled = False
            chkOnTuesday.Enabled = False
            chkOnWednesday.Enabled = False
        End If
    End Sub
End Class
