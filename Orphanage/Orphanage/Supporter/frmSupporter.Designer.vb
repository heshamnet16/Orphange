<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSupporter
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
        Dim RadPrintWatermark1 As Telerik.WinControls.UI.RadPrintWatermark = New Telerik.WinControls.UI.RadPrintWatermark()
        Me.btnChooseAccount = New Telerik.WinControls.UI.RadButton()
        Me.txtNote = New Telerik.WinControls.UI.RadTextBox()
        Me.txtName = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.chkIsMonthly = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.txtAddress = New Telerik.WinControls.UI.RadTextBox()
        Me.chkOnlyFamiles = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.chkStillActive = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.txtAccountName = New Telerik.WinControls.UI.RadTextBox()
        Me.NameForm1 = New NameForm.NameForm()
        Me.AddressForm1 = New AddressForm.AddressForm()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RadPrintDocument1 = New Telerik.WinControls.UI.RadPrintDocument()
        CType(Me.btnChooseAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOnlyFamiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkStillActive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccountName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnChooseAccount
        '
        Me.btnChooseAccount.Location = New System.Drawing.Point(57, 141)
        Me.btnChooseAccount.Name = "btnChooseAccount"
        Me.btnChooseAccount.Size = New System.Drawing.Size(24, 20)
        Me.btnChooseAccount.TabIndex = 10131
        Me.btnChooseAccount.Text = "..."
        Me.ToolTip1.SetToolTip(Me.btnChooseAccount, "اختر الحساب الذي يدغع منه الكفيل")
        '
        'txtNote
        '
        Me.txtNote.AutoSize = False
        Me.txtNote.Location = New System.Drawing.Point(88, 229)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(195, 68)
        Me.txtNote.TabIndex = 10129
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(88, 53)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(195, 20)
        Me.txtName.TabIndex = 10130
        Me.txtName.TabStop = False
        '
        'RadLabel3
        '
        Me.RadLabel3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel3.Location = New System.Drawing.Point(289, 53)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(33, 17)
        Me.RadLabel3.TabIndex = 10128
        Me.RadLabel3.Text = "الاسم :"
        Me.RadLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel1
        '
        Me.RadLabel1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(289, 229)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(51, 17)
        Me.RadLabel1.TabIndex = 10126
        Me.RadLabel1.Text = "ملاحظات :"
        Me.RadLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel6
        '
        Me.RadLabel6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel6.Location = New System.Drawing.Point(287, 185)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(38, 17)
        Me.RadLabel6.TabIndex = 10127
        Me.RadLabel6.Text = "شهري :"
        Me.RadLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.RadLabel6, "الكفيل الشهري هو الذي يدفع كفالة شهرية وملتزم بها")
        '
        'chkIsMonthly
        '
        Me.chkIsMonthly.Location = New System.Drawing.Point(266, 188)
        Me.chkIsMonthly.Name = "chkIsMonthly"
        Me.chkIsMonthly.Size = New System.Drawing.Size(15, 15)
        Me.chkIsMonthly.TabIndex = 10125
        Me.ToolTip1.SetToolTip(Me.chkIsMonthly, "الكفيل الشهري هو الذي يدفع كفالة شهرية وملتزم بها")
        '
        'RadLabel2
        '
        Me.RadLabel2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.Location = New System.Drawing.Point(289, 97)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(40, 17)
        Me.RadLabel2.TabIndex = 10128
        Me.RadLabel2.Text = "العنوان :"
        Me.RadLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(88, 97)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.Size = New System.Drawing.Size(195, 20)
        Me.txtAddress.TabIndex = 10130
        Me.txtAddress.TabStop = False
        '
        'chkOnlyFamiles
        '
        Me.chkOnlyFamiles.Location = New System.Drawing.Point(175, 188)
        Me.chkOnlyFamiles.Name = "chkOnlyFamiles"
        Me.chkOnlyFamiles.Size = New System.Drawing.Size(15, 15)
        Me.chkOnlyFamiles.TabIndex = 10125
        Me.ToolTip1.SetToolTip(Me.chkOnlyFamiles, "لا يقوم بكفالة ايتام بل يكفل عائلات فقط")
        '
        'RadLabel4
        '
        Me.RadLabel4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel4.Location = New System.Drawing.Point(196, 185)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(58, 17)
        Me.RadLabel4.TabIndex = 10127
        Me.RadLabel4.Text = "عائلات فقط :"
        Me.RadLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.RadLabel4, "لا يقوم بكفالة ايتام بل يكفل عائلات فقط")
        '
        'chkStillActive
        '
        Me.chkStillActive.Location = New System.Drawing.Point(88, 188)
        Me.chkStillActive.Name = "chkStillActive"
        Me.chkStillActive.Size = New System.Drawing.Size(15, 15)
        Me.chkStillActive.TabIndex = 10125
        Me.ToolTip1.SetToolTip(Me.chkStillActive, "عند إلغء هذا الخيار سيتم تجاهل هذا الكفيل واعتبار الأيتام غير مكفولين في كل العمل" & _
                "يات ولكن لن يتم حذف الكفالات بل سيتم تجاهلها فقط")
        '
        'RadLabel5
        '
        Me.RadLabel5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel5.Location = New System.Drawing.Point(109, 185)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(34, 17)
        Me.RadLabel5.TabIndex = 10127
        Me.RadLabel5.Text = "ملتزم :"
        Me.RadLabel5.TextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.RadLabel5, "عند إلغء هذا الخيار سيتم تجاهل هذا الكفيل واعتبار الأيتام غير مكفولين في كل العمل" & _
                "يات ولكن لن يتم حذف الكفالات بل سيتم تجاهلها فقط")
        '
        'RadLabel7
        '
        Me.RadLabel7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel7.Location = New System.Drawing.Point(289, 141)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(43, 17)
        Me.RadLabel7.TabIndex = 10128
        Me.RadLabel7.Text = "الحساب :"
        Me.RadLabel7.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'txtAccountName
        '
        Me.txtAccountName.Location = New System.Drawing.Point(88, 141)
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.ReadOnly = True
        Me.txtAccountName.Size = New System.Drawing.Size(195, 20)
        Me.txtAccountName.TabIndex = 10130
        Me.txtAccountName.TabStop = False
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
        Me.NameForm1.Location = New System.Drawing.Point(73, 53)
        Me.NameForm1.Middle = ""
        Me.NameForm1.MoveFactor = 20
        Me.NameForm1.MoveType = NameForm.NameForm._MoveType.UpToDown
        Me.NameForm1.Name = "NameForm1"
        Me.NameForm1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NameForm1.ShowMovement = True
        Me.NameForm1.Size = New System.Drawing.Size(242, 179)
        Me.NameForm1.TabIndex = 10132
        Me.NameForm1.Visible = False
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
        Me.AddressForm1.Location = New System.Drawing.Point(19, 30)
        Me.AddressForm1.MoveFactor = 50
        Me.AddressForm1.MoveType = AddressForm.AddressForm._MoveType.DownToUp
        Me.AddressForm1.Name = "AddressForm1"
        Me.AddressForm1.Note = ""
        Me.AddressForm1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.AddressForm1.ShowMovement = True
        Me.AddressForm1.Size = New System.Drawing.Size(311, 264)
        Me.AddressForm1.Skype = ""
        Me.AddressForm1.Street = ""
        Me.AddressForm1.TabIndex = 10133
        Me.AddressForm1.Town = ""
        Me.AddressForm1.Visible = False
        Me.AddressForm1.WorkPhone = "(031)0000-000"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(88, 312)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 24)
        Me.btnSave.TabIndex = 10134
        Me.btnSave.Text = "حفظ"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(181, 312)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 24)
        Me.btnCancel.TabIndex = 10134
        Me.btnCancel.Text = "الغاء الأمر"
        '
        'RadPrintDocument1
        '
        Me.RadPrintDocument1.FooterFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.RadPrintDocument1.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!)
        RadPrintWatermark1.Font = New System.Drawing.Font("Tahoma", 144.0!)
        Me.RadPrintDocument1.Watermark = RadPrintWatermark1
        '
        'FrmSupporter
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(349, 350)
        Me.Controls.Add(Me.AddressForm1)
        Me.Controls.Add(Me.NameForm1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnChooseAccount)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.txtAccountName)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.RadLabel7)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.RadLabel3)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.RadLabel5)
        Me.Controls.Add(Me.RadLabel4)
        Me.Controls.Add(Me.RadLabel6)
        Me.Controls.Add(Me.chkStillActive)
        Me.Controls.Add(Me.chkOnlyFamiles)
        Me.Controls.Add(Me.chkIsMonthly)
        Me.MaximizeBox = False
        Me.Name = "FrmSupporter"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "الكفيل"
        CType(Me.btnChooseAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOnlyFamiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkStillActive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccountName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnChooseAccount As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtNote As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkIsMonthly As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtAddress As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents chkOnlyFamiles As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkStillActive As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtAccountName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents NameForm1 As NameForm.NameForm
    Friend WithEvents AddressForm1 As AddressForm.AddressForm
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents RadPrintDocument1 As Telerik.WinControls.UI.RadPrintDocument
End Class

