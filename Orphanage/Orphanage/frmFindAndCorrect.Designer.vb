<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFindAndCorrect
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
        Dim ListViewDetailColumn1 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "الرقم")
        Dim ListViewDetailColumn2 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "الاسم")
        Dim ListViewDetailColumn3 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "نوع القيد")
        Dim ListViewDetailColumn4 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 4", "ملاحظات")
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.optOrphanDelete = New Telerik.WinControls.UI.RadRadioButton()
        Me.RadRadioButton1 = New Telerik.WinControls.UI.RadRadioButton()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.optOrphanExclude = New Telerik.WinControls.UI.RadRadioButton()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.LstLog = New Telerik.WinControls.UI.RadListView()
        Me.RadGroupBox3 = New Telerik.WinControls.UI.RadGroupBox()
        Me.ProgCurrent = New Telerik.WinControls.UI.RadProgressBar()
        Me.progAll = New Telerik.WinControls.UI.RadProgressBar()
        Me.btnStart = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.RadGroupBox4 = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.chkIds = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkNames = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkOrphansAges = New Telerik.WinControls.UI.RadCheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkEditStudyStage = New System.Windows.Forms.CheckBox()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.optOrphanDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadRadioButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optOrphanExclude, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.LstLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox3.SuspendLayout()
        CType(Me.ProgCurrent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.progAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox4.SuspendLayout()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNames, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOrphansAges, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel7)
        Me.RadGroupBox1.Controls.Add(Me.chkEditStudyStage)
        Me.RadGroupBox1.Controls.Add(Me.optOrphanDelete)
        Me.RadGroupBox1.Controls.Add(Me.RadRadioButton1)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel6)
        Me.RadGroupBox1.Controls.Add(Me.optOrphanExclude)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel2)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel1)
        Me.RadGroupBox1.HeaderText = "خيارات"
        Me.RadGroupBox1.Location = New System.Drawing.Point(12, 71)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(465, 55)
        Me.RadGroupBox1.TabIndex = 0
        Me.RadGroupBox1.Text = "خيارات"
        '
        'optOrphanDelete
        '
        Me.optOrphanDelete.Location = New System.Drawing.Point(373, 23)
        Me.optOrphanDelete.Name = "optOrphanDelete"
        Me.optOrphanDelete.Size = New System.Drawing.Size(15, 15)
        Me.optOrphanDelete.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.optOrphanDelete, "سيتم حذف اليتم المتجاوز للسن المسموح به")
        '
        'RadRadioButton1
        '
        Me.RadRadioButton1.Location = New System.Drawing.Point(164, 22)
        Me.RadRadioButton1.Name = "RadRadioButton1"
        Me.RadRadioButton1.Size = New System.Drawing.Size(15, 15)
        Me.RadRadioButton1.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.RadRadioButton1, "لن يتم عمل شيئ بالنسبة للأيتام المتجاوزين للسن المسموح به ")
        '
        'RadLabel6
        '
        Me.RadLabel6.Location = New System.Drawing.Point(185, 20)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(35, 18)
        Me.RadLabel6.TabIndex = 1
        Me.RadLabel6.Text = "لاشيئ"
        Me.RadLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.RadLabel6, "لن يتم عمل شيئ بالنسبة للأيتام المتجاوزين للسن المسموح به ")
        '
        'optOrphanExclude
        '
        Me.optOrphanExclude.Location = New System.Drawing.Point(250, 23)
        Me.optOrphanExclude.Name = "optOrphanExclude"
        Me.optOrphanExclude.Size = New System.Drawing.Size(15, 15)
        Me.optOrphanExclude.TabIndex = 2
        Me.optOrphanExclude.TabStop = True
        Me.optOrphanExclude.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        Me.ToolTip1.SetToolTip(Me.optOrphanExclude, "سيتم استبعاد اليتيم المتجاوز للسن المسموح به")
        '
        'RadLabel2
        '
        Me.RadLabel2.Location = New System.Drawing.Point(271, 20)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(69, 18)
        Me.RadLabel2.TabIndex = 1
        Me.RadLabel2.Text = "استبعاد اليتيم"
        Me.RadLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.RadLabel2, "سيتم استبعاد اليتيم المتجاوز للسن المسموح به")
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(394, 20)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(58, 18)
        Me.RadLabel1.TabIndex = 1
        Me.RadLabel1.Text = "حذف اليتيم"
        Me.RadLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.RadLabel1, "سيتم حذف اليتم المتجاوز للسن المسموح به")
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox2.Controls.Add(Me.LstLog)
        Me.RadGroupBox2.HeaderText = "السجل"
        Me.RadGroupBox2.Location = New System.Drawing.Point(12, 132)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Size = New System.Drawing.Size(465, 156)
        Me.RadGroupBox2.TabIndex = 0
        Me.RadGroupBox2.Text = "السجل"
        '
        'LstLog
        '
        Me.LstLog.AllowEdit = False
        ListViewDetailColumn1.HeaderText = "الرقم"
        ListViewDetailColumn1.Width = 50.0!
        ListViewDetailColumn2.HeaderText = "الاسم"
        ListViewDetailColumn2.Width = 150.0!
        ListViewDetailColumn3.HeaderText = "نوع القيد"
        ListViewDetailColumn3.Width = 60.0!
        ListViewDetailColumn4.HeaderText = "ملاحظات"
        Me.LstLog.Columns.AddRange(New Telerik.WinControls.UI.ListViewDetailColumn() {ListViewDetailColumn1, ListViewDetailColumn2, ListViewDetailColumn3, ListViewDetailColumn4})
        Me.LstLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstLog.EnableSorting = True
        Me.LstLog.ItemSpacing = -1
        Me.LstLog.Location = New System.Drawing.Point(2, 18)
        Me.LstLog.Name = "LstLog"
        Me.LstLog.ShowGridLines = True
        Me.LstLog.Size = New System.Drawing.Size(461, 136)
        Me.LstLog.TabIndex = 0
        Me.LstLog.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView
        '
        'RadGroupBox3
        '
        Me.RadGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox3.Controls.Add(Me.ProgCurrent)
        Me.RadGroupBox3.Controls.Add(Me.progAll)
        Me.RadGroupBox3.HeaderText = "التقدم"
        Me.RadGroupBox3.Location = New System.Drawing.Point(14, 298)
        Me.RadGroupBox3.Name = "RadGroupBox3"
        Me.RadGroupBox3.Size = New System.Drawing.Size(465, 86)
        Me.RadGroupBox3.TabIndex = 0
        Me.RadGroupBox3.Text = "التقدم"
        '
        'ProgCurrent
        '
        Me.ProgCurrent.Location = New System.Drawing.Point(5, 51)
        Me.ProgCurrent.Name = "ProgCurrent"
        Me.ProgCurrent.ProgressOrientation = Telerik.WinControls.ProgressOrientation.Right
        Me.ProgCurrent.Size = New System.Drawing.Size(455, 24)
        Me.ProgCurrent.TabIndex = 0
        '
        'progAll
        '
        Me.progAll.Location = New System.Drawing.Point(5, 21)
        Me.progAll.Name = "progAll"
        Me.progAll.ProgressOrientation = Telerik.WinControls.ProgressOrientation.Right
        Me.progAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.progAll.Size = New System.Drawing.Size(455, 24)
        Me.progAll.TabIndex = 0
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(131, 390)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(110, 24)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "ابدأ"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(247, 390)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(110, 24)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "الغاء"
        '
        'RadGroupBox4
        '
        Me.RadGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox4.Controls.Add(Me.RadLabel3)
        Me.RadGroupBox4.Controls.Add(Me.RadLabel5)
        Me.RadGroupBox4.Controls.Add(Me.RadLabel4)
        Me.RadGroupBox4.Controls.Add(Me.chkIds)
        Me.RadGroupBox4.Controls.Add(Me.chkNames)
        Me.RadGroupBox4.Controls.Add(Me.chkOrphansAges)
        Me.RadGroupBox4.HeaderText = "تدقيق"
        Me.RadGroupBox4.Location = New System.Drawing.Point(12, 12)
        Me.RadGroupBox4.Name = "RadGroupBox4"
        Me.RadGroupBox4.Size = New System.Drawing.Size(465, 53)
        Me.RadGroupBox4.TabIndex = 0
        Me.RadGroupBox4.Text = "تدقيق"
        '
        'RadLabel3
        '
        Me.RadLabel3.Location = New System.Drawing.Point(41, 19)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(67, 18)
        Me.RadLabel3.TabIndex = 1
        Me.RadLabel3.Text = "أرقام الهويات"
        Me.RadLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.RadLabel3, "سيتم تدقيق ارقام الهويات لإيجاد الارقام الناقصة و التضاربات")
        '
        'RadLabel5
        '
        Me.RadLabel5.Location = New System.Drawing.Point(213, 19)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(39, 18)
        Me.RadLabel5.TabIndex = 1
        Me.RadLabel5.Text = "الاسماء"
        Me.RadLabel5.TextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.RadLabel5, "سيتم تدقيق اسماء جميع السجلات لإيجاد التشابه بين الاسماء")
        '
        'RadLabel4
        '
        Me.RadLabel4.Location = New System.Drawing.Point(401, 19)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(59, 18)
        Me.RadLabel4.TabIndex = 1
        Me.RadLabel4.Text = "أعمار الأيتام"
        Me.RadLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.RadLabel4, "سيتم تدقيق اعمار الايتام")
        '
        'chkIds
        '
        Me.chkIds.Location = New System.Drawing.Point(20, 22)
        Me.chkIds.Name = "chkIds"
        Me.chkIds.Size = New System.Drawing.Size(15, 15)
        Me.chkIds.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.chkIds, "سيتم تدقيق ارقام الهويات لإيجاد الارقام الناقصة و التضاربات")
        '
        'chkNames
        '
        Me.chkNames.Location = New System.Drawing.Point(192, 22)
        Me.chkNames.Name = "chkNames"
        Me.chkNames.Size = New System.Drawing.Size(15, 15)
        Me.chkNames.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.chkNames, "سيتم تدقيق اسماء جميع السجلات لإيجاد التشابه بين الاسماء")
        '
        'chkOrphansAges
        '
        Me.chkOrphansAges.Location = New System.Drawing.Point(380, 22)
        Me.chkOrphansAges.Name = "chkOrphansAges"
        Me.chkOrphansAges.Size = New System.Drawing.Size(15, 15)
        Me.chkOrphansAges.TabIndex = 0
        Me.chkOrphansAges.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        Me.ToolTip1.SetToolTip(Me.chkOrphansAges, "سيتم تدقيق اعمار الايتام")
        '
        'chkEditStudyStage
        '
        Me.chkEditStudyStage.AutoSize = True
        Me.chkEditStudyStage.Location = New System.Drawing.Point(13, 23)
        Me.chkEditStudyStage.Name = "chkEditStudyStage"
        Me.chkEditStudyStage.Size = New System.Drawing.Size(15, 14)
        Me.chkEditStudyStage.TabIndex = 3
        Me.chkEditStudyStage.UseVisualStyleBackColor = True
        '
        'RadLabel7
        '
        Me.RadLabel7.Location = New System.Drawing.Point(34, 20)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(112, 18)
        Me.RadLabel7.TabIndex = 1
        Me.RadLabel7.Text = "تعديل المرحلة الدراسية"
        Me.RadLabel7.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'FrmFindAndCorrect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 422)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.RadGroupBox3)
        Me.Controls.Add(Me.RadGroupBox2)
        Me.Controls.Add(Me.RadGroupBox4)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmFindAndCorrect"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "تدقيق"
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.optOrphanDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadRadioButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optOrphanExclude, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        CType(Me.LstLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox3.ResumeLayout(False)
        CType(Me.ProgCurrent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.progAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox4.ResumeLayout(False)
        Me.RadGroupBox4.PerformLayout()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNames, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOrphansAges, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents LstLog As Telerik.WinControls.UI.RadListView
    Friend WithEvents RadGroupBox3 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents btnStart As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents ProgCurrent As Telerik.WinControls.UI.RadProgressBar
    Friend WithEvents progAll As Telerik.WinControls.UI.RadProgressBar
    Friend WithEvents optOrphanDelete As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optOrphanExclude As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadGroupBox4 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkIds As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkOrphansAges As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkNames As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadRadioButton1 As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkEditStudyStage As System.Windows.Forms.CheckBox
End Class

