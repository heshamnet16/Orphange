<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBail
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.numAmount = New Telerik.WinControls.UI.RadSpinEditor()
        Me.TrackBarRange1 = New Telerik.WinControls.UI.TrackBarRange()
        Me.TrackBarRange2 = New Telerik.WinControls.UI.TrackBarRange()
        Me.txtSupporterName = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.dteFrom = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.dteTo = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.chkIsMonthly = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.txtNote = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.btnChooseSup = New Telerik.WinControls.UI.RadButton()
        Me.chkIsFamily = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.chkNoTime = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.lblCurrency = New Telerik.WinControls.UI.RadLabel()
        Me.chkIsEnded = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel9 = New Telerik.WinControls.UI.RadLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.numAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSupporterName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnChooseSup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsFamily, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNoTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCurrency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsEnded, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'numAmount
        '
        Me.numAmount.DecimalPlaces = 2
        Me.numAmount.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numAmount.Location = New System.Drawing.Point(42, 43)
        Me.numAmount.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numAmount.Name = "numAmount"
        Me.numAmount.Size = New System.Drawing.Size(154, 20)
        Me.numAmount.TabIndex = 3
        Me.numAmount.TabStop = False
        Me.numAmount.ThousandsSeparator = True
        Me.ToolTip1.SetToolTip(Me.numAmount, "المبلغ المراد دفعه لكل فرد أو عائلة واحدة")
        '
        'TrackBarRange2
        '
        Me.TrackBarRange2.End = 12.0!
        Me.TrackBarRange2.Start = 1.0!
        Me.TrackBarRange2.Text = "s;lsd"
        '
        'txtSupporterName
        '
        Me.txtSupporterName.Location = New System.Drawing.Point(42, 15)
        Me.txtSupporterName.Name = "txtSupporterName"
        Me.txtSupporterName.ReadOnly = True
        Me.txtSupporterName.Size = New System.Drawing.Size(154, 20)
        Me.txtSupporterName.TabIndex = 2
        Me.txtSupporterName.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txtSupporterName, "اسم الكفيل وسيتم اعتماد حسابه المالي كحساب مالي للكفالة")
        '
        'RadLabel2
        '
        Me.RadLabel2.Location = New System.Drawing.Point(202, 42)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(39, 18)
        Me.RadLabel2.TabIndex = 1
        Me.RadLabel2.Text = "المبلغ :"
        Me.RadLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel3
        '
        Me.RadLabel3.Location = New System.Drawing.Point(202, 14)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(41, 18)
        Me.RadLabel3.TabIndex = 1
        Me.RadLabel3.Text = "الكفيل :"
        Me.RadLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'dteFrom
        '
        Me.dteFrom.Location = New System.Drawing.Point(42, 99)
        Me.dteFrom.Name = "dteFrom"
        Me.dteFrom.Size = New System.Drawing.Size(154, 20)
        Me.dteFrom.TabIndex = 5
        Me.dteFrom.TabStop = False
        Me.dteFrom.Text = "Saturday, May 31, 2014"
        Me.ToolTip1.SetToolTip(Me.dteFrom, "تاريخ بدء الكفالة")
        Me.dteFrom.Value = New Date(2014, 5, 31, 12, 4, 52, 559)
        '
        'RadLabel4
        '
        Me.RadLabel4.Location = New System.Drawing.Point(202, 98)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(26, 18)
        Me.RadLabel4.TabIndex = 1
        Me.RadLabel4.Text = "من :"
        Me.RadLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel5
        '
        Me.RadLabel5.Location = New System.Drawing.Point(202, 126)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(28, 18)
        Me.RadLabel5.TabIndex = 1
        Me.RadLabel5.Text = "إلى :"
        Me.RadLabel5.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'dteTo
        '
        Me.dteTo.Location = New System.Drawing.Point(42, 127)
        Me.dteTo.Name = "dteTo"
        Me.dteTo.Size = New System.Drawing.Size(154, 20)
        Me.dteTo.TabIndex = 5
        Me.dteTo.TabStop = False
        Me.dteTo.Text = "Saturday, May 31, 2014"
        Me.ToolTip1.SetToolTip(Me.dteTo, "تاريخ انتهاء الكفالة")
        Me.dteTo.Value = New Date(2014, 5, 31, 12, 4, 52, 559)
        '
        'chkIsMonthly
        '
        Me.chkIsMonthly.Location = New System.Drawing.Point(181, 155)
        Me.chkIsMonthly.Name = "chkIsMonthly"
        Me.chkIsMonthly.Size = New System.Drawing.Size(15, 15)
        Me.chkIsMonthly.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.chkIsMonthly, "كفالة تصرف بشكل شهري")
        '
        'RadLabel6
        '
        Me.RadLabel6.Location = New System.Drawing.Point(202, 154)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(69, 18)
        Me.RadLabel6.TabIndex = 1
        Me.RadLabel6.Text = "كفالة شهرية :"
        Me.RadLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'txtNote
        '
        Me.txtNote.AutoSize = False
        Me.txtNote.Location = New System.Drawing.Point(42, 237)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(154, 68)
        Me.txtNote.TabIndex = 2
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(202, 237)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(54, 18)
        Me.RadLabel1.TabIndex = 1
        Me.RadLabel1.Text = "ملاحظات :"
        Me.RadLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'btnChooseSup
        '
        Me.btnChooseSup.Location = New System.Drawing.Point(12, 15)
        Me.btnChooseSup.Name = "btnChooseSup"
        Me.btnChooseSup.Size = New System.Drawing.Size(24, 20)
        Me.btnChooseSup.TabIndex = 6
        Me.btnChooseSup.Text = "..."
        Me.ToolTip1.SetToolTip(Me.btnChooseSup, "إضغط لاختيار كفيل")
        '
        'chkIsFamily
        '
        Me.chkIsFamily.Location = New System.Drawing.Point(181, 182)
        Me.chkIsFamily.Name = "chkIsFamily"
        Me.chkIsFamily.Size = New System.Drawing.Size(15, 15)
        Me.chkIsFamily.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.chkIsFamily, "كفالة عائلة كاملة تصرف للمسؤول عن الأيتام")
        '
        'RadLabel7
        '
        Me.RadLabel7.Location = New System.Drawing.Point(202, 181)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(65, 18)
        Me.RadLabel7.TabIndex = 1
        Me.RadLabel7.Text = "كفالة عائلية :"
        Me.RadLabel7.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'chkNoTime
        '
        Me.chkNoTime.Location = New System.Drawing.Point(181, 71)
        Me.chkNoTime.Name = "chkNoTime"
        Me.chkNoTime.Size = New System.Drawing.Size(15, 15)
        Me.chkNoTime.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.chkNoTime, "كفالة غير محددة المدة")
        '
        'RadLabel8
        '
        Me.RadLabel8.Location = New System.Drawing.Point(202, 70)
        Me.RadLabel8.Name = "RadLabel8"
        Me.RadLabel8.Size = New System.Drawing.Size(56, 18)
        Me.RadLabel8.TabIndex = 1
        Me.RadLabel8.Text = "بدون مدة :"
        Me.RadLabel8.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(136, 321)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "إالغاء"
        '
        'btnSave
        '
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSave.Location = New System.Drawing.Point(47, 321)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 24)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "حفظ"
        '
        'lblCurrency
        '
        Me.lblCurrency.AutoSize = False
        Me.lblCurrency.Location = New System.Drawing.Point(12, 45)
        Me.lblCurrency.Name = "lblCurrency"
        Me.lblCurrency.Size = New System.Drawing.Size(24, 18)
        Me.lblCurrency.TabIndex = 1
        Me.lblCurrency.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'chkIsEnded
        '
        Me.chkIsEnded.Location = New System.Drawing.Point(181, 209)
        Me.chkIsEnded.Name = "chkIsEnded"
        Me.chkIsEnded.Size = New System.Drawing.Size(15, 15)
        Me.chkIsEnded.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.chkIsEnded, "كفالة منتهية ولم تعد صالحة ولن يتم صرفها بعد الآن إلا في حال تغير هذا البند")
        '
        'RadLabel9
        '
        Me.RadLabel9.Location = New System.Drawing.Point(202, 209)
        Me.RadLabel9.Name = "RadLabel9"
        Me.RadLabel9.Size = New System.Drawing.Size(65, 18)
        Me.RadLabel9.TabIndex = 1
        Me.RadLabel9.Text = "إنهاء الكفالة :"
        Me.RadLabel9.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'FrmBail
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(270, 357)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnChooseSup)
        Me.Controls.Add(Me.dteTo)
        Me.Controls.Add(Me.dteFrom)
        Me.Controls.Add(Me.numAmount)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.txtSupporterName)
        Me.Controls.Add(Me.RadLabel3)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.RadLabel9)
        Me.Controls.Add(Me.RadLabel7)
        Me.Controls.Add(Me.lblCurrency)
        Me.Controls.Add(Me.RadLabel8)
        Me.Controls.Add(Me.RadLabel6)
        Me.Controls.Add(Me.RadLabel5)
        Me.Controls.Add(Me.chkIsEnded)
        Me.Controls.Add(Me.RadLabel4)
        Me.Controls.Add(Me.chkIsFamily)
        Me.Controls.Add(Me.chkNoTime)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.chkIsMonthly)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBail"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "كفالة"
        CType(Me.numAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSupporterName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnChooseSup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsFamily, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNoTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCurrency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsEnded, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents numAmount As Telerik.WinControls.UI.RadSpinEditor
    Friend WithEvents TrackBarRange1 As Telerik.WinControls.UI.TrackBarRange
    Friend WithEvents TrackBarRange2 As Telerik.WinControls.UI.TrackBarRange
    Friend WithEvents txtSupporterName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents dteFrom As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents dteTo As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents chkIsMonthly As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtNote As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents btnChooseSup As Telerik.WinControls.UI.RadButton
    Friend WithEvents chkIsFamily As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkNoTime As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblCurrency As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel9 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkIsEnded As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class

