<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBox
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
        Dim RadListDataItem1 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem2 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem3 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem4 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem5 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem6 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem7 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem8 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem9 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem10 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.btnOk = New Telerik.WinControls.UI.RadButton()
        Me.chkIsPositive = New Telerik.WinControls.UI.RadCheckBox()
        Me.txtNote = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.txtAccountName = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.txtCurrencySho = New Telerik.WinControls.UI.RadTextBox()
        Me.numAmount = New Telerik.WinControls.UI.RadSpinEditor()
        Me.cmbCurrencyName = New Telerik.WinControls.UI.RadDropDownList()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnOk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsPositive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccountName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCurrencySho, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCurrencyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(202, 199)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(46, 18)
        Me.RadLabel1.TabIndex = 0
        Me.RadLabel1.Text = "ملاحظات :"
        Me.RadLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(61, 282)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(71, 24)
        Me.btnOk.TabIndex = 7
        Me.btnOk.Text = "حفظ"
        '
        'chkIsPositive
        '
        Me.chkIsPositive.Location = New System.Drawing.Point(181, 167)
        Me.chkIsPositive.Name = "chkIsPositive"
        Me.chkIsPositive.Size = New System.Drawing.Size(15, 15)
        Me.chkIsPositive.TabIndex = 5
        '
        'txtNote
        '
        Me.txtNote.AutoSize = False
        Me.txtNote.Location = New System.Drawing.Point(32, 199)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.NullText = "ادخل ملاحظاتك عن الحساب"
        Me.txtNote.Size = New System.Drawing.Size(164, 62)
        Me.txtNote.TabIndex = 6
        '
        'RadLabel2
        '
        Me.RadLabel2.Location = New System.Drawing.Point(202, 24)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(57, 18)
        Me.RadLabel2.TabIndex = 0
        Me.RadLabel2.Text = "اسم الحساب :"
        Me.RadLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'txtAccountName
        '
        Me.txtAccountName.Location = New System.Drawing.Point(32, 24)
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.NullText = "ادخل اسم الحساب"
        Me.txtAccountName.Size = New System.Drawing.Size(164, 20)
        Me.txtAccountName.TabIndex = 1
        '
        'RadLabel3
        '
        Me.RadLabel3.Location = New System.Drawing.Point(202, 94)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(65, 18)
        Me.RadLabel3.TabIndex = 0
        Me.RadLabel3.Text = "اختصار العملة :"
        Me.RadLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel4
        '
        Me.RadLabel4.Location = New System.Drawing.Point(202, 59)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(49, 18)
        Me.RadLabel4.TabIndex = 0
        Me.RadLabel4.Text = "اسم العملة :"
        Me.RadLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel5
        '
        Me.RadLabel5.Location = New System.Drawing.Point(202, 129)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(32, 18)
        Me.RadLabel5.TabIndex = 0
        Me.RadLabel5.Text = "المبلغ :"
        Me.RadLabel5.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel6
        '
        Me.RadLabel6.Location = New System.Drawing.Point(202, 164)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(60, 18)
        Me.RadLabel6.TabIndex = 0
        Me.RadLabel6.Text = "حساب جاري :"
        Me.RadLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'txtCurrencySho
        '
        Me.txtCurrencySho.Location = New System.Drawing.Point(32, 94)
        Me.txtCurrencySho.MaxLength = 3
        Me.txtCurrencySho.Name = "txtCurrencySho"
        Me.txtCurrencySho.NullText = "اختصار العملة"
        Me.txtCurrencySho.Size = New System.Drawing.Size(164, 20)
        Me.txtCurrencySho.TabIndex = 3
        '
        'numAmount
        '
        Me.numAmount.DecimalPlaces = 2
        Me.numAmount.Location = New System.Drawing.Point(32, 129)
        Me.numAmount.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 0})
        Me.numAmount.Minimum = New Decimal(New Integer() {1316134911, 2328, 0, -2147483648})
        Me.numAmount.Name = "numAmount"
        Me.numAmount.ShowBorder = False
        Me.numAmount.Size = New System.Drawing.Size(164, 20)
        Me.numAmount.TabIndex = 4
        Me.numAmount.ThousandsSeparator = True
        '
        'cmbCurrencyName
        '
        Me.cmbCurrencyName.AutoSizeItems = True
        RadListDataItem1.Selected = True
        RadListDataItem1.Text = "الجنيه الاسترليني"
        RadListDataItem1.TextWrap = True
        RadListDataItem2.Text = "الجنيه المصري"
        RadListDataItem2.TextWrap = True
        RadListDataItem3.Text = "الدولار الأمريكي"
        RadListDataItem3.TextWrap = True
        RadListDataItem4.Text = "الدينار الأردني"
        RadListDataItem4.TextWrap = True
        RadListDataItem5.Text = "الدينار الكويتي"
        RadListDataItem5.TextWrap = True
        RadListDataItem6.Text = "الريال السعودي"
        RadListDataItem6.TextWrap = True
        RadListDataItem7.Text = "الريال القطري"
        RadListDataItem7.TextWrap = True
        RadListDataItem8.Text = "الليرة التركية"
        RadListDataItem8.TextWrap = True
        RadListDataItem9.Text = "الليرة السورية"
        RadListDataItem9.TextWrap = True
        RadListDataItem10.Text = "اليورو الأوربي"
        RadListDataItem10.TextWrap = True
        Me.cmbCurrencyName.Items.Add(RadListDataItem1)
        Me.cmbCurrencyName.Items.Add(RadListDataItem2)
        Me.cmbCurrencyName.Items.Add(RadListDataItem3)
        Me.cmbCurrencyName.Items.Add(RadListDataItem4)
        Me.cmbCurrencyName.Items.Add(RadListDataItem5)
        Me.cmbCurrencyName.Items.Add(RadListDataItem6)
        Me.cmbCurrencyName.Items.Add(RadListDataItem7)
        Me.cmbCurrencyName.Items.Add(RadListDataItem8)
        Me.cmbCurrencyName.Items.Add(RadListDataItem9)
        Me.cmbCurrencyName.Items.Add(RadListDataItem10)
        Me.cmbCurrencyName.Location = New System.Drawing.Point(32, 59)
        Me.cmbCurrencyName.Name = "cmbCurrencyName"
        Me.cmbCurrencyName.NullText = "اختر عملة"
        Me.cmbCurrencyName.SelectNextOnDoubleClick = True
        Me.cmbCurrencyName.Size = New System.Drawing.Size(164, 20)
        Me.cmbCurrencyName.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending
        Me.cmbCurrencyName.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(138, 282)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(71, 24)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "عودة"
        '
        'FrmBox
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(270, 323)
        Me.Controls.Add(Me.cmbCurrencyName)
        Me.Controls.Add(Me.numAmount)
        Me.Controls.Add(Me.txtAccountName)
        Me.Controls.Add(Me.txtCurrencySho)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.chkIsPositive)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.RadLabel4)
        Me.Controls.Add(Me.RadLabel5)
        Me.Controls.Add(Me.RadLabel3)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.RadLabel6)
        Me.Controls.Add(Me.RadLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmBox"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "حساب"
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnOk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsPositive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccountName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCurrencySho, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCurrencyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents btnOk As Telerik.WinControls.UI.RadButton
    Friend WithEvents chkIsPositive As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents txtNote As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtAccountName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtCurrencySho As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents numAmount As Telerik.WinControls.UI.RadSpinEditor
    Friend WithEvents cmbCurrencyName As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
End Class

