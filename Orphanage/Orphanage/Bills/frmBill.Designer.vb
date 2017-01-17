<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBill
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBill))
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.optDeposite = New Telerik.WinControls.UI.RadRadioButton()
        Me.optDraw = New Telerik.WinControls.UI.RadRadioButton()
        Me.grpType = New Telerik.WinControls.UI.RadGroupBox()
        Me.grpBox = New Telerik.WinControls.UI.RadGroupBox()
        Me.btnChooseBox = New Telerik.WinControls.UI.RadButton()
        Me.txtBox = New Telerik.WinControls.UI.RadTextBox()
        Me.grpSide = New Telerik.WinControls.UI.RadGroupBox()
        Me.btnChooseSide = New Telerik.WinControls.UI.RadButton()
        Me.txtSide = New Telerik.WinControls.UI.RadTextBox()
        Me.optOthers = New Telerik.WinControls.UI.RadRadioButton()
        Me.optFAmily = New Telerik.WinControls.UI.RadRadioButton()
        Me.optOrphan = New Telerik.WinControls.UI.RadRadioButton()
        Me.RadGroupBox4 = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.numNumber = New Telerik.WinControls.UI.RadSpinEditor()
        Me.dteDate = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.grpOthers = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtDetails = New Telerik.WinControls.UI.RadTextBox()
        Me.RadGroupBox8 = New Telerik.WinControls.UI.RadGroupBox()
        Me.PictureSelector1 = New PictureSelector.PictureSelector()
        Me.RadGroupBox5 = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtNote = New Telerik.WinControls.UI.RadTextBox()
        Me.grpAMount = New Telerik.WinControls.UI.RadGroupBox()
        Me.numAmount = New Telerik.WinControls.UI.RadSpinEditor()
        Me.lblCurrency = New Telerik.WinControls.UI.RadLabel()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optDeposite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optDraw, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpType.SuspendLayout()
        CType(Me.grpBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBox.SuspendLayout()
        CType(Me.btnChooseBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpSide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSide.SuspendLayout()
        CType(Me.btnChooseSide, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSide, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optOthers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optFAmily, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optOrphan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox4.SuspendLayout()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpOthers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOthers.SuspendLayout()
        CType(Me.txtDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox8.SuspendLayout()
        CType(Me.RadGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox5.SuspendLayout()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpAMount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAMount.SuspendLayout()
        CType(Me.numAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCurrency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(25, 459)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(312, 24)
        Me.btnSave.TabIndex = 21
        Me.btnSave.Text = "إيداع"
        '
        'optDeposite
        '
        Me.optDeposite.Location = New System.Drawing.Point(80, 13)
        Me.optDeposite.Name = "optDeposite"
        Me.optDeposite.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optDeposite.Size = New System.Drawing.Size(38, 18)
        Me.optDeposite.TabIndex = 8
        Me.optDeposite.TabStop = True
        Me.optDeposite.Text = "إيداع"
        '
        'optDraw
        '
        Me.optDraw.Location = New System.Drawing.Point(214, 13)
        Me.optDraw.Name = "optDraw"
        Me.optDraw.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optDraw.Size = New System.Drawing.Size(41, 18)
        Me.optDraw.TabIndex = 7
        Me.optDraw.TabStop = True
        Me.optDraw.Text = "سحب"
        '
        'grpType
        '
        Me.grpType.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grpType.Controls.Add(Me.optDraw)
        Me.grpType.Controls.Add(Me.optDeposite)
        Me.grpType.Enabled = False
        Me.grpType.HeaderText = "الإجراء"
        Me.grpType.Location = New System.Drawing.Point(12, 109)
        Me.grpType.Name = "grpType"
        Me.grpType.Size = New System.Drawing.Size(335, 37)
        Me.grpType.TabIndex = 6
        Me.grpType.Text = "الإجراء"
        '
        'grpBox
        '
        Me.grpBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grpBox.Controls.Add(Me.btnChooseBox)
        Me.grpBox.Controls.Add(Me.txtBox)
        Me.grpBox.HeaderText = "الحساب"
        Me.grpBox.Location = New System.Drawing.Point(12, 56)
        Me.grpBox.Name = "grpBox"
        Me.grpBox.Size = New System.Drawing.Size(335, 47)
        Me.grpBox.TabIndex = 4
        Me.grpBox.Text = "الحساب"
        '
        'btnChooseBox
        '
        Me.btnChooseBox.Location = New System.Drawing.Point(5, 18)
        Me.btnChooseBox.Name = "btnChooseBox"
        Me.btnChooseBox.Size = New System.Drawing.Size(24, 20)
        Me.btnChooseBox.TabIndex = 5
        Me.btnChooseBox.Text = "..."
        '
        'txtBox
        '
        Me.txtBox.Location = New System.Drawing.Point(35, 18)
        Me.txtBox.Name = "txtBox"
        Me.txtBox.NullText = "أختر الحساب"
        Me.txtBox.ReadOnly = True
        Me.txtBox.Size = New System.Drawing.Size(279, 20)
        Me.txtBox.TabIndex = 435
        Me.txtBox.TabStop = False
        '
        'grpSide
        '
        Me.grpSide.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grpSide.Controls.Add(Me.btnChooseSide)
        Me.grpSide.Controls.Add(Me.txtSide)
        Me.grpSide.Controls.Add(Me.optOthers)
        Me.grpSide.Controls.Add(Me.optFAmily)
        Me.grpSide.Controls.Add(Me.optOrphan)
        Me.grpSide.Enabled = False
        Me.grpSide.HeaderText = "الجهة"
        Me.grpSide.Location = New System.Drawing.Point(12, 152)
        Me.grpSide.Name = "grpSide"
        Me.grpSide.Size = New System.Drawing.Size(335, 63)
        Me.grpSide.TabIndex = 9
        Me.grpSide.Text = "الجهة"
        '
        'btnChooseSide
        '
        Me.btnChooseSide.Enabled = False
        Me.btnChooseSide.Location = New System.Drawing.Point(5, 35)
        Me.btnChooseSide.Name = "btnChooseSide"
        Me.btnChooseSide.Size = New System.Drawing.Size(24, 20)
        Me.btnChooseSide.TabIndex = 14
        Me.btnChooseSide.Text = "..."
        '
        'txtSide
        '
        Me.txtSide.Location = New System.Drawing.Point(35, 35)
        Me.txtSide.Name = "txtSide"
        Me.txtSide.NullText = "أختر الجهة"
        Me.txtSide.Size = New System.Drawing.Size(279, 20)
        Me.txtSide.TabIndex = 13
        '
        'optOthers
        '
        Me.optOthers.Location = New System.Drawing.Point(54, 14)
        Me.optOthers.Name = "optOthers"
        Me.optOthers.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optOthers.Size = New System.Drawing.Size(42, 18)
        Me.optOthers.TabIndex = 12
        Me.optOthers.TabStop = True
        Me.optOthers.Text = "أخرى"
        Me.optOthers.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'optFAmily
        '
        Me.optFAmily.Enabled = False
        Me.optFAmily.Location = New System.Drawing.Point(153, 14)
        Me.optFAmily.Name = "optFAmily"
        Me.optFAmily.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optFAmily.Size = New System.Drawing.Size(38, 18)
        Me.optFAmily.TabIndex = 11
        Me.optFAmily.TabStop = True
        Me.optFAmily.Text = "عائلة"
        '
        'optOrphan
        '
        Me.optOrphan.Enabled = False
        Me.optOrphan.Location = New System.Drawing.Point(248, 14)
        Me.optOrphan.Name = "optOrphan"
        Me.optOrphan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optOrphan.Size = New System.Drawing.Size(32, 18)
        Me.optOrphan.TabIndex = 10
        Me.optOrphan.TabStop = True
        Me.optOrphan.Text = "يتيم"
        '
        'RadGroupBox4
        '
        Me.RadGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox4.Controls.Add(Me.RadLabel2)
        Me.RadGroupBox4.Controls.Add(Me.RadLabel1)
        Me.RadGroupBox4.Controls.Add(Me.numNumber)
        Me.RadGroupBox4.Controls.Add(Me.dteDate)
        Me.RadGroupBox4.HeaderText = "ارشفة"
        Me.RadGroupBox4.Location = New System.Drawing.Point(12, 7)
        Me.RadGroupBox4.Name = "RadGroupBox4"
        Me.RadGroupBox4.Size = New System.Drawing.Size(335, 43)
        Me.RadGroupBox4.TabIndex = 1
        Me.RadGroupBox4.Text = "ارشفة"
        '
        'RadLabel2
        '
        Me.RadLabel2.Location = New System.Drawing.Point(110, 16)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(37, 18)
        Me.RadLabel2.TabIndex = 2
        Me.RadLabel2.Text = "التاريخ :"
        Me.RadLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(296, 16)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(29, 18)
        Me.RadLabel1.TabIndex = 2
        Me.RadLabel1.Text = "الرقم :"
        Me.RadLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'numNumber
        '
        Me.numNumber.Location = New System.Drawing.Point(193, 15)
        Me.numNumber.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.numNumber.Name = "numNumber"
        Me.numNumber.ShowUpDownButtons = False
        Me.numNumber.Size = New System.Drawing.Size(101, 20)
        Me.numNumber.TabIndex = 2
        Me.numNumber.TabStop = False
        '
        'dteDate
        '

        Me.dteDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dteDate.Location = New System.Drawing.Point(5, 15)
        Me.dteDate.Name = "dteDate"
        Me.dteDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dteDate.Size = New System.Drawing.Size(101, 20)
        Me.dteDate.TabIndex = 3
        Me.dteDate.TabStop = False
        Me.dteDate.Text = "2014/06/08"
        Me.dteDate.Value = New Date(2014, 6, 8, 16, 17, 37, 620)
        '
        'grpOthers
        '
        Me.grpOthers.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grpOthers.Controls.Add(Me.txtDetails)
        Me.grpOthers.Controls.Add(Me.RadGroupBox8)
        Me.grpOthers.Controls.Add(Me.RadGroupBox5)
        Me.grpOthers.Enabled = False
        Me.grpOthers.HeaderText = "معلومات أخرى"
        Me.grpOthers.Location = New System.Drawing.Point(12, 276)
        Me.grpOthers.Name = "grpOthers"
        Me.grpOthers.Size = New System.Drawing.Size(335, 177)
        Me.grpOthers.TabIndex = 17
        Me.grpOthers.Text = "معلومات أخرى"
        '
        'txtDetails
        '
        Me.txtDetails.AutoSize = False
        Me.txtDetails.Location = New System.Drawing.Point(5, 21)
        Me.txtDetails.Multiline = True
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.NullText = "أدخل تفاصيل الوصل"
        Me.txtDetails.Size = New System.Drawing.Size(309, 43)
        Me.txtDetails.TabIndex = 18
        '
        'RadGroupBox8
        '
        Me.RadGroupBox8.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox8.Controls.Add(Me.PictureSelector1)
        Me.RadGroupBox8.HeaderText = "صورة"
        Me.RadGroupBox8.Location = New System.Drawing.Point(5, 69)
        Me.RadGroupBox8.Name = "RadGroupBox8"
        Me.RadGroupBox8.Size = New System.Drawing.Size(131, 99)
        Me.RadGroupBox8.TabIndex = 3
        Me.RadGroupBox8.Text = "صورة"
        '
        'PictureSelector1
        '
        Me.PictureSelector1.BackgroundImage = CType(resources.GetObject("PictureSelector1.BackgroundImage"), System.Drawing.Image)
        Me.PictureSelector1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureSelector1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureSelector1.Location = New System.Drawing.Point(2, 18)
        Me.PictureSelector1.Name = "PictureSelector1"
        Me.PictureSelector1.Size = New System.Drawing.Size(127, 79)
        Me.PictureSelector1.TabIndex = 16
        '
        'RadGroupBox5
        '
        Me.RadGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox5.Controls.Add(Me.txtNote)
        Me.RadGroupBox5.HeaderText = "ملاحظات"
        Me.RadGroupBox5.Location = New System.Drawing.Point(142, 69)
        Me.RadGroupBox5.Name = "RadGroupBox5"
        Me.RadGroupBox5.Size = New System.Drawing.Size(175, 99)
        Me.RadGroupBox5.TabIndex = 19
        Me.RadGroupBox5.Text = "ملاحظات"
        '
        'txtNote
        '
        Me.txtNote.AutoSize = False
        Me.txtNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNote.Location = New System.Drawing.Point(2, 18)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(171, 79)
        Me.txtNote.TabIndex = 20
        '
        'grpAMount
        '
        Me.grpAMount.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grpAMount.Controls.Add(Me.numAmount)
        Me.grpAMount.Controls.Add(Me.lblCurrency)
        Me.grpAMount.Enabled = False
        Me.grpAMount.HeaderText = "المبلغ "
        Me.grpAMount.Location = New System.Drawing.Point(12, 221)
        Me.grpAMount.Name = "grpAMount"
        Me.grpAMount.Size = New System.Drawing.Size(335, 49)
        Me.grpAMount.TabIndex = 15
        Me.grpAMount.Text = "المبلغ "
        '
        'numAmount
        '
        Me.numAmount.Location = New System.Drawing.Point(35, 19)
        Me.numAmount.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.numAmount.Name = "numAmount"
        Me.numAmount.ShowUpDownButtons = False
        Me.numAmount.Size = New System.Drawing.Size(279, 20)
        Me.numAmount.TabIndex = 16
        Me.numAmount.TabStop = False
        '
        'lblCurrency
        '
        Me.lblCurrency.AutoSize = False
        Me.lblCurrency.Location = New System.Drawing.Point(7, 19)
        Me.lblCurrency.Name = "lblCurrency"
        Me.lblCurrency.Size = New System.Drawing.Size(22, 18)
        Me.lblCurrency.TabIndex = 2
        Me.lblCurrency.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'FrmBill
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 490)
        Me.Controls.Add(Me.grpOthers)
        Me.Controls.Add(Me.RadGroupBox4)
        Me.Controls.Add(Me.grpBox)
        Me.Controls.Add(Me.grpSide)
        Me.Controls.Add(Me.grpAMount)
        Me.Controls.Add(Me.grpType)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmBill"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "أيصال"
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optDeposite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optDraw, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpType.ResumeLayout(False)
        Me.grpType.PerformLayout()
        CType(Me.grpBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBox.ResumeLayout(False)
        Me.grpBox.PerformLayout()
        CType(Me.btnChooseBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpSide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSide.ResumeLayout(False)
        Me.grpSide.PerformLayout()
        CType(Me.btnChooseSide, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSide, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optOthers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optFAmily, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optOrphan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox4.ResumeLayout(False)
        Me.RadGroupBox4.PerformLayout()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpOthers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOthers.ResumeLayout(False)
        CType(Me.txtDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox8.ResumeLayout(False)
        CType(Me.RadGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox5.ResumeLayout(False)
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpAMount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAMount.ResumeLayout(False)
        Me.grpAMount.PerformLayout()
        CType(Me.numAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCurrency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents optDeposite As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optDraw As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents grpType As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grpBox As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtBox As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents grpSide As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents btnChooseBox As Telerik.WinControls.UI.RadButton
    Friend WithEvents optFAmily As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents txtSide As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents optOthers As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optOrphan As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents btnChooseSide As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadGroupBox4 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents numNumber As Telerik.WinControls.UI.RadSpinEditor
    Friend WithEvents dteDate As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents grpOthers As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtDetails As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadGroupBox8 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents PictureSelector1 As PictureSelector.PictureSelector
    Friend WithEvents RadGroupBox5 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtNote As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents grpAMount As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents numAmount As Telerik.WinControls.UI.RadSpinEditor
    Friend WithEvents lblCurrency As Telerik.WinControls.UI.RadLabel
End Class

