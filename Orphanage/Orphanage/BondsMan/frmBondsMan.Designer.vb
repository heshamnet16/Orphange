<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBondsMan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBondsMan))
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.PicIDBack = New PictureSelector.PictureSelector()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.picIDFront = New PictureSelector.PictureSelector()
        Me.numIdentity = New Telerik.WinControls.UI.RadSpinEditor()
        Me.txtName = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.numMonthlyIncom = New Telerik.WinControls.UI.RadSpinEditor()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.txtjop = New Telerik.WinControls.UI.RadTextBox()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.clrColor = New Telerik.WinControls.UI.RadColorBox()
        Me.RadLabel11 = New Telerik.WinControls.UI.RadLabel()
        Me.txtNote = New Telerik.WinControls.UI.RadTextBox()
        Me.txtAddress = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.jhkjdd = New Telerik.WinControls.UI.RadLabel()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.AddressForm1 = New AddressForm.AddressForm()
        Me.NameForm1 = New NameForm.NameForm()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numIdentity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMonthlyIncom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtjop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.clrColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.jhkjdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.RadLabel5)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel4)
        Me.RadGroupBox1.Controls.Add(Me.PicIDBack)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel1)
        Me.RadGroupBox1.Controls.Add(Me.picIDFront)
        Me.RadGroupBox1.Controls.Add(Me.numIdentity)
        Me.RadGroupBox1.HeaderText = "بطاقة شخصية"
        Me.RadGroupBox1.Location = New System.Drawing.Point(12, 199)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(457, 153)
        Me.RadGroupBox1.TabIndex = 1
        Me.RadGroupBox1.Text = "بطاقة شخصية"
        '
        'RadLabel5
        '
        Me.RadLabel5.Location = New System.Drawing.Point(196, 58)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(57, 18)
        Me.RadLabel5.TabIndex = 5
        Me.RadLabel5.Text = "صورة خلفية :"
        Me.RadLabel5.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel4
        '
        Me.RadLabel4.Location = New System.Drawing.Point(385, 58)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(59, 18)
        Me.RadLabel4.TabIndex = 5
        Me.RadLabel4.Text = "صورة امامية :"
        Me.RadLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'PicIDBack
        '
        Me.PicIDBack.BackgroundImage = CType(resources.GetObject("PicIDBack.BackgroundImage"), System.Drawing.Image)
        Me.PicIDBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicIDBack.Location = New System.Drawing.Point(68, 45)
        Me.PicIDBack.Name = "PicIDBack"
        Me.PicIDBack.Size = New System.Drawing.Size(122, 103)
        Me.PicIDBack.TabIndex = 0
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(387, 21)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(24, 18)
        Me.RadLabel1.TabIndex = 5
        Me.RadLabel1.Text = "رقم :"
        Me.RadLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'picIDFront
        '
        Me.picIDFront.BackgroundImage = CType(resources.GetObject("picIDFront.BackgroundImage"), System.Drawing.Image)
        Me.picIDFront.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picIDFront.Location = New System.Drawing.Point(259, 45)
        Me.picIDFront.Name = "picIDFront"
        Me.picIDFront.Size = New System.Drawing.Size(122, 103)
        Me.picIDFront.TabIndex = 0
        '
        'numIdentity
        '
        Me.numIdentity.Location = New System.Drawing.Point(68, 19)
        Me.numIdentity.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.numIdentity.Name = "numIdentity"
        Me.numIdentity.Size = New System.Drawing.Size(313, 20)
        Me.numIdentity.TabIndex = 3
        Me.numIdentity.TabStop = False
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(223, 16)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(158, 20)
        Me.txtName.TabIndex = 4
        '
        'RadLabel2
        '
        Me.RadLabel2.Location = New System.Drawing.Point(387, 17)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(31, 18)
        Me.RadLabel2.TabIndex = 8
        Me.RadLabel2.Text = "الاسم :"
        Me.RadLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'numMonthlyIncom
        '
        Me.numMonthlyIncom.Location = New System.Drawing.Point(223, 80)
        Me.numMonthlyIncom.Maximum = New Decimal(New Integer() {20000, 0, 0, 0})
        Me.numMonthlyIncom.Name = "numMonthlyIncom"
        Me.numMonthlyIncom.Size = New System.Drawing.Size(158, 20)
        Me.numMonthlyIncom.TabIndex = 3
        Me.numMonthlyIncom.TabStop = False
        '
        'RadLabel6
        '
        Me.RadLabel6.Location = New System.Drawing.Point(387, 85)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(65, 18)
        Me.RadLabel6.TabIndex = 6
        Me.RadLabel6.Text = "الدخل الشهري :"
        Me.RadLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel7
        '
        Me.RadLabel7.Location = New System.Drawing.Point(387, 56)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(31, 18)
        Me.RadLabel7.TabIndex = 8
        Me.RadLabel7.Text = "العمل :"
        Me.RadLabel7.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'txtjop
        '
        Me.txtjop.AutoCompleteCustomSource.AddRange(New String() {"نجار", "حداد", "جزار", "مزارع", "عامل", "سائق تاكسي", "سائق شاحنة", "سائق آلية ثقيلة", "موظف", "ممرض", "طبيب", "مهندس", "مدرس", "مترجم", "متعهد", "تاجر", "مساعد مهندس", "مراقب فني", "صيدلي", "فنان", "دهان"})
        Me.txtjop.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtjop.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtjop.Location = New System.Drawing.Point(223, 48)
        Me.txtjop.Name = "txtjop"
        Me.txtjop.Size = New System.Drawing.Size(158, 20)
        Me.txtjop.TabIndex = 4
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox2.Controls.Add(Me.clrColor)
        Me.RadGroupBox2.Controls.Add(Me.RadLabel11)
        Me.RadGroupBox2.Controls.Add(Me.txtNote)
        Me.RadGroupBox2.Controls.Add(Me.txtAddress)
        Me.RadGroupBox2.Controls.Add(Me.txtName)
        Me.RadGroupBox2.Controls.Add(Me.RadLabel8)
        Me.RadGroupBox2.Controls.Add(Me.txtjop)
        Me.RadGroupBox2.Controls.Add(Me.RadLabel2)
        Me.RadGroupBox2.Controls.Add(Me.RadLabel7)
        Me.RadGroupBox2.Controls.Add(Me.jhkjdd)
        Me.RadGroupBox2.Controls.Add(Me.RadLabel6)
        Me.RadGroupBox2.Controls.Add(Me.numMonthlyIncom)
        Me.RadGroupBox2.HeaderText = "بيانات"
        Me.RadGroupBox2.Location = New System.Drawing.Point(12, 6)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Size = New System.Drawing.Size(457, 187)
        Me.RadGroupBox2.TabIndex = 1
        Me.RadGroupBox2.Text = "بيانات"
        '
        'clrColor
        '
        Me.clrColor.Location = New System.Drawing.Point(334, 112)
        Me.clrColor.Name = "clrColor"
        Me.clrColor.Size = New System.Drawing.Size(47, 20)
        Me.clrColor.TabIndex = 10
        Me.clrColor.Value = System.Drawing.Color.Black
        '
        'RadLabel11
        '
        Me.RadLabel11.Location = New System.Drawing.Point(386, 114)
        Me.RadLabel11.Name = "RadLabel11"
        Me.RadLabel11.Size = New System.Drawing.Size(49, 18)
        Me.RadLabel11.TabIndex = 9
        Me.RadLabel11.Text = "تمييز بلون :"
        Me.RadLabel11.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'txtNote
        '
        Me.txtNote.AutoSize = False
        Me.txtNote.Location = New System.Drawing.Point(16, 41)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(188, 91)
        Me.txtNote.TabIndex = 4
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(16, 142)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.Size = New System.Drawing.Size(365, 20)
        Me.txtAddress.TabIndex = 4
        '
        'RadLabel8
        '
        Me.RadLabel8.Location = New System.Drawing.Point(387, 144)
        Me.RadLabel8.Name = "RadLabel8"
        Me.RadLabel8.Size = New System.Drawing.Size(37, 18)
        Me.RadLabel8.TabIndex = 8
        Me.RadLabel8.Text = "العنوان :"
        Me.RadLabel8.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'jhkjdd
        '
        Me.jhkjdd.Location = New System.Drawing.Point(158, 17)
        Me.jhkjdd.Name = "jhkjdd"
        Me.jhkjdd.Size = New System.Drawing.Size(46, 18)
        Me.jhkjdd.TabIndex = 6
        Me.jhkjdd.Text = "ملاحظات :"
        Me.jhkjdd.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(156, 368)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 24)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "حفظ"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(245, 368)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "إالغاء"
        '
        'AddressForm1
        '
        Me.AddressForm1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AddressForm1.CellPhone = "(0944)000-000"
        Me.AddressForm1.City = ""
        Me.AddressForm1.Country = ""
        Me.AddressForm1.Email = ""
        Me.AddressForm1.Facebook = ""
        Me.AddressForm1.Fax = "(031)0000-000"
        Me.AddressForm1.HideOnEnter = False
        Me.AddressForm1.HomePhone = "(031)0000-000"
        Me.AddressForm1.Location = New System.Drawing.Point(12, 36)
        Me.AddressForm1.MoveFactor = 50
        Me.AddressForm1.MoveType = AddressForm.AddressForm._MoveType.DownToUp
        Me.AddressForm1.Name = "AddressForm1"
        Me.AddressForm1.Note = ""
        Me.AddressForm1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.AddressForm1.ShowMovement = True
        Me.AddressForm1.Size = New System.Drawing.Size(457, 264)
        Me.AddressForm1.Skype = ""
        Me.AddressForm1.Street = ""
        Me.AddressForm1.TabIndex = 53
        Me.AddressForm1.Town = ""
        Me.AddressForm1.Visible = False
        Me.AddressForm1.WorkPhone = "(031)0000-000"
        '
        'NameForm1
        '
        Me.NameForm1.English_First = Nothing
        Me.NameForm1.English_Last = Nothing
        Me.NameForm1.English_Middle = Nothing
        Me.NameForm1.Father_Name_ReadOnly = False
        Me.NameForm1.First = ""
        Me.NameForm1.HideOnEnter = False
        Me.NameForm1.Last = ""
        Me.NameForm1.Last_Name_ReadOnly = False
        Me.NameForm1.Location = New System.Drawing.Point(182, 22)
        Me.NameForm1.Middle = ""
        Me.NameForm1.MoveFactor = 20
        Me.NameForm1.MoveType = NameForm.NameForm._MoveType.UpToDown
        Me.NameForm1.Name = "NameForm1"
        Me.NameForm1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NameForm1.ShowMovement = True
        Me.NameForm1.Size = New System.Drawing.Size(247, 186)
        Me.NameForm1.TabIndex = 54
        Me.NameForm1.Visible = False
        '
        'FrmBondsMan
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(481, 407)
        Me.Controls.Add(Me.AddressForm1)
        Me.Controls.Add(Me.NameForm1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.RadGroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmBondsMan"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "بيانات المعيل"
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numIdentity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMonthlyIncom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtjop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        Me.RadGroupBox2.PerformLayout()
        CType(Me.clrColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.jhkjdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picIDFront As PictureSelector.PictureSelector
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents PicIDBack As PictureSelector.PictureSelector
    Friend WithEvents numMonthlyIncom As Telerik.WinControls.UI.RadSpinEditor
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtjop As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtNote As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents jhkjdd As Telerik.WinControls.UI.RadLabel
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents numIdentity As Telerik.WinControls.UI.RadSpinEditor
    Friend WithEvents txtAddress As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents AddressForm1 As AddressForm.AddressForm
    Friend WithEvents NameForm1 As NameForm.NameForm
    Friend WithEvents clrColor As Telerik.WinControls.UI.RadColorBox
    Friend WithEvents RadLabel11 As Telerik.WinControls.UI.RadLabel
End Class

