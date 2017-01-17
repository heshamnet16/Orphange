<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMothers
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
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDateTimeColumn1 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewCheckBoxColumn1 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewDateTimeColumn2 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewCheckBoxColumn2 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewCheckBoxColumn3 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn4 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDateTimeColumn3 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewDecimalColumn5 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim RadPrintWatermark1 As Telerik.WinControls.UI.RadPrintWatermark = New Telerik.WinControls.UI.RadPrintWatermark()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.radCmdBar = New Telerik.WinControls.UI.RadCommandBar()
        Me.CommandBarRowElement1 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.btnDelete = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnEdit = New Telerik.WinControls.UI.CommandBarButton()
        Me.mnuSep1 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.btnExclud = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnSetColor = New Telerik.WinControls.UI.CommandBarButton()
        Me.BtnBail = New Telerik.WinControls.UI.CommandBarButton()
        Me.mnuSep2 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.btnShowOrphans = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnShowFathers = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnSep3 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.btnColumn = New Telerik.WinControls.UI.CommandBarButton()
        Me.RadStatusStrip1 = New Telerik.WinControls.UI.RadStatusStrip()
        Me.lblStatus = New Telerik.WinControls.UI.RadLabelElement()
        Me.radDataGrid = New Telerik.WinControls.UI.RadGridView()
        Me.RadPrintDocument1 = New Telerik.WinControls.UI.RadPrintDocument()
        Me.OrphansDBDataSet = New Orphanage.OrphansDBDataSet()
        Me.MothersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MothersTableAdapter = New Orphanage.OrphansDBDataSetTableAdapters.MothersTableAdapter()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.radCmdBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radDataGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrphansDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MothersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.radCmdBar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RadStatusStrip1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.radDataGrid, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(696, 321)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'radCmdBar
        '
        Me.radCmdBar.AutoSize = False
        Me.radCmdBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radCmdBar.Location = New System.Drawing.Point(3, 3)
        Me.radCmdBar.Name = "radCmdBar"
        Me.radCmdBar.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement1})
        Me.radCmdBar.Size = New System.Drawing.Size(690, 39)
        Me.radCmdBar.TabIndex = 0
        '
        'CommandBarRowElement1
        '
        Me.CommandBarRowElement1.MinSize = New System.Drawing.Size(25, 25)
        Me.CommandBarRowElement1.Strips.AddRange(New Telerik.WinControls.UI.CommandBarStripElement() {Me.CommandBarStripElement1})
        Me.CommandBarRowElement1.Text = ""
        '
        'CommandBarStripElement1
        '
        Me.CommandBarStripElement1.AutoSize = True
        Me.CommandBarStripElement1.BorderGradientStyle = Telerik.WinControls.GradientStyles.Gel
        Me.CommandBarStripElement1.ClipDrawing = False
        Me.CommandBarStripElement1.ClipText = False
        Me.CommandBarStripElement1.DisplayName = "CommandBarStripElement1"
        Me.CommandBarStripElement1.DrawBorder = False
        Me.CommandBarStripElement1.EnableImageTransparency = True
        Me.CommandBarStripElement1.GradientAngle = 90.0!
        Me.CommandBarStripElement1.GradientPercentage = 0.54!
        Me.CommandBarStripElement1.GradientPercentage2 = 0.5!
        Me.CommandBarStripElement1.GradientStyle = Telerik.WinControls.GradientStyles.Linear
        '
        '
        '
        Me.CommandBarStripElement1.Grip.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        Me.CommandBarStripElement1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.btnDelete, Me.btnEdit, Me.mnuSep1, Me.btnExclud, Me.btnSetColor, Me.BtnBail, Me.mnuSep2, Me.btnShowOrphans, Me.btnShowFathers, Me.btnSep3, Me.btnColumn})
        Me.CommandBarStripElement1.Name = "CommandBarStripElement1"
        Me.CommandBarStripElement1.NumberOfColors = 16
        Me.CommandBarStripElement1.Opacity = 1.0R
        '
        '
        '
        Me.CommandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        Me.CommandBarStripElement1.RightToLeft = True
        Me.CommandBarStripElement1.ShouldPaint = True
        Me.CommandBarStripElement1.ShowHorizontalLine = False
        CType(Me.CommandBarStripElement1.GetChildAt(0), Telerik.WinControls.UI.RadCommandBarGrip).Visibility = Telerik.WinControls.ElementVisibility.Hidden
        CType(Me.CommandBarStripElement1.GetChildAt(2), Telerik.WinControls.UI.RadCommandBarOverflowButton).Visibility = Telerik.WinControls.ElementVisibility.Hidden
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleDescription = "CommandBarButton1"
        Me.btnDelete.AccessibleName = "CommandBarButton1"
        Me.btnDelete.AutoSize = False
        Me.btnDelete.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnDelete.DisplayName = "CommandBarButton1"
        Me.btnDelete.Image = Global.Orphanage.My.Resources.Resources.DeletePng
        Me.btnDelete.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(0)
        Me.btnDelete.RightToLeft = True
        Me.btnDelete.StretchHorizontally = True
        Me.btnDelete.Text = ""
        Me.btnDelete.ToolTipText = "حذف"
        Me.btnDelete.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnEdit
        '
        Me.btnEdit.AccessibleDescription = "CommandBarButton2"
        Me.btnEdit.AccessibleName = "CommandBarButton2"
        Me.btnEdit.AutoSize = False
        Me.btnEdit.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnEdit.DisplayName = "CommandBarButton2"
        Me.btnEdit.Image = Global.Orphanage.My.Resources.Resources.EditPng
        Me.btnEdit.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Padding = New System.Windows.Forms.Padding(0)
        Me.btnEdit.RightToLeft = True
        Me.btnEdit.StretchHorizontally = True
        Me.btnEdit.Text = ""
        Me.btnEdit.ToolTipText = "تعديل"
        Me.btnEdit.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuSep1
        '
        Me.mnuSep1.AccessibleDescription = "CommandBarSeparator1"
        Me.mnuSep1.AccessibleName = "CommandBarSeparator1"
        Me.mnuSep1.DisplayName = "CommandBarSeparator1"
        Me.mnuSep1.Name = "mnuSep1"
        Me.mnuSep1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.mnuSep1.VisibleInOverflowMenu = False
        '
        'btnExclud
        '
        Me.btnExclud.AutoSize = False
        Me.btnExclud.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnExclud.DisplayName = "CommandBarButton1"
        Me.btnExclud.Image = Global.Orphanage.My.Resources.Resources.ghost
        Me.btnExclud.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExclud.Name = "btnExclud"
        Me.btnExclud.Padding = New System.Windows.Forms.Padding(0)
        Me.btnExclud.RightToLeft = True
        Me.btnExclud.StretchHorizontally = True
        Me.btnExclud.Text = ""
        Me.btnExclud.ToolTipText = "استبعاد"
        Me.btnExclud.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnSetColor
        '
        Me.btnSetColor.AccessibleDescription = "CommandBarButton2"
        Me.btnSetColor.AccessibleName = "CommandBarButton2"
        Me.btnSetColor.AutoSize = False
        Me.btnSetColor.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnSetColor.DisplayName = "CommandBarButton2"
        Me.btnSetColor.Image = Global.Orphanage.My.Resources.Resources.Colors2
        Me.btnSetColor.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSetColor.Name = "btnSetColor"
        Me.btnSetColor.Text = "CommandBarButton2"
        Me.btnSetColor.ToolTipText = "تعيين لون"
        Me.btnSetColor.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'BtnBail
        '
        Me.BtnBail.AutoSize = False
        Me.BtnBail.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.BtnBail.Image = Global.Orphanage.My.Resources.Resources.Bail
        Me.BtnBail.ImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnBail.Name = "BtnBail"
        Me.BtnBail.Text = ""
        Me.BtnBail.ToolTipText = "كفالة العائلة"
        Me.BtnBail.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuSep2
        '
        Me.mnuSep2.AccessibleDescription = "CommandBarSeparator2"
        Me.mnuSep2.AccessibleName = "CommandBarSeparator2"
        Me.mnuSep2.DisplayName = "CommandBarSeparator2"
        Me.mnuSep2.Name = "mnuSep2"
        Me.mnuSep2.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.mnuSep2.VisibleInOverflowMenu = False
        '
        'btnShowOrphans
        '
        Me.btnShowOrphans.AccessibleDescription = "CommandBarButton3"
        Me.btnShowOrphans.AccessibleName = "CommandBarButton3"
        Me.btnShowOrphans.AutoSize = False
        Me.btnShowOrphans.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnShowOrphans.DisplayName = "CommandBarButton3"
        Me.btnShowOrphans.Image = Global.Orphanage.My.Resources.Resources.Orphans
        Me.btnShowOrphans.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowOrphans.Name = "btnShowOrphans"
        Me.btnShowOrphans.Padding = New System.Windows.Forms.Padding(0)
        Me.btnShowOrphans.RightToLeft = True
        Me.btnShowOrphans.StretchHorizontally = True
        Me.btnShowOrphans.Text = ""
        Me.btnShowOrphans.ToolTipText = "عرض الأيتام"
        Me.btnShowOrphans.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnShowFathers
        '
        Me.btnShowFathers.AutoSize = False
        Me.btnShowFathers.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnShowFathers.Image = Global.Orphanage.My.Resources.Resources.dad
        Me.btnShowFathers.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowFathers.Name = "btnShowFathers"
        Me.btnShowFathers.Text = ""
        Me.btnShowFathers.ToolTipText = "عرض الأمهات"
        Me.btnShowFathers.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnSep3
        '
        Me.btnSep3.AccessibleDescription = "CommandBarSeparator1"
        Me.btnSep3.AccessibleName = "CommandBarSeparator1"
        Me.btnSep3.DisplayName = "CommandBarSeparator1"
        Me.btnSep3.Name = "btnSep3"
        Me.btnSep3.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.btnSep3.VisibleInOverflowMenu = False
        '
        'btnColumn
        '
        Me.btnColumn.AccessibleDescription = "CommandBarButton1"
        Me.btnColumn.AccessibleName = "CommandBarButton1"
        Me.btnColumn.AutoSize = False
        Me.btnColumn.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnColumn.DisplayName = "CommandBarButton1"
        Me.btnColumn.Image = Global.Orphanage.My.Resources.Resources.columns
        Me.btnColumn.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnColumn.Name = "btnColumn"
        Me.btnColumn.Text = ""
        Me.btnColumn.TextWrap = False
        Me.btnColumn.ToolTipText = "الأعمدة"
        Me.btnColumn.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.lblStatus})
        Me.RadStatusStrip1.Location = New System.Drawing.Point(3, 295)
        Me.RadStatusStrip1.Name = "RadStatusStrip1"
        Me.RadStatusStrip1.Size = New System.Drawing.Size(690, 24)
        Me.RadStatusStrip1.TabIndex = 1
        Me.RadStatusStrip1.Text = "RadStatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.RadStatusStrip1.SetSpring(Me.lblStatus, False)
        Me.lblStatus.Text = ""
        Me.lblStatus.TextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.lblStatus.TextWrap = True
        Me.lblStatus.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'radDataGrid
        '
        Me.radDataGrid.AutoScroll = True
        Me.radDataGrid.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.radDataGrid.ColumnChooserSortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending
        Me.radDataGrid.Cursor = System.Windows.Forms.Cursors.Default
        Me.radDataGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radDataGrid.EnableCustomDrawing = True
        Me.radDataGrid.EnterKeyMode = Telerik.WinControls.UI.RadGridViewEnterKeyMode.EnterMovesToNextRow
        Me.radDataGrid.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.radDataGrid.ForeColor = System.Drawing.Color.Black
        Me.radDataGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.radDataGrid.Location = New System.Drawing.Point(3, 48)
        '
        'radDataGrid
        '
        Me.radDataGrid.MasterTemplate.AllowAddNewRow = False
        Me.radDataGrid.MasterTemplate.AllowCellContextMenu = False
        Me.radDataGrid.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.radDataGrid.MasterTemplate.AllowDeleteRow = False
        Me.radDataGrid.MasterTemplate.AllowEditRow = False
        Me.radDataGrid.MasterTemplate.AllowRowReorder = True
        Me.radDataGrid.MasterTemplate.ClipboardCopyMode = Telerik.WinControls.UI.GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        GridViewDecimalColumn1.DataType = GetType(Integer)
        GridViewDecimalColumn1.FieldName = "ID"
        GridViewDecimalColumn1.HeaderText = "الرقم"
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.Name = "ID"
        GridViewTextBoxColumn1.FieldName = "MotherName"
        GridViewTextBoxColumn1.HeaderText = "اسم الأم"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.Name = "MotherName"
        GridViewTextBoxColumn2.FieldName = "FatherName"
        GridViewTextBoxColumn2.HeaderText = "اسم المتوفى"
        GridViewTextBoxColumn2.IsAutoGenerated = True
        GridViewTextBoxColumn2.Name = "FatherName"
        GridViewDecimalColumn2.DataType = GetType(Integer)
        GridViewDecimalColumn2.FieldName = "Onum"
        GridViewDecimalColumn2.HeaderText = "عدد الأيتام"
        GridViewDecimalColumn2.IsAutoGenerated = True
        GridViewDecimalColumn2.Name = "Onum"
        GridViewDateTimeColumn1.FieldName = "Birthday"
        GridViewDateTimeColumn1.HeaderText = "تاريخ الولادة"
        GridViewDateTimeColumn1.IsAutoGenerated = True
        GridViewDateTimeColumn1.Name = "Birthday"
        GridViewCheckBoxColumn1.FieldName = "IsDead"
        GridViewCheckBoxColumn1.HeaderText = "متوفية"
        GridViewCheckBoxColumn1.IsAutoGenerated = True
        GridViewCheckBoxColumn1.Name = "IsDead"
        GridViewDateTimeColumn2.FieldName = "Dieday"
        GridViewDateTimeColumn2.HeaderText = "تاريخ الوفاة"
        GridViewDateTimeColumn2.IsAutoGenerated = True
        GridViewDateTimeColumn2.Name = "Dieday"
        GridViewDecimalColumn3.FieldName = "IdentityCard_ID"
        GridViewDecimalColumn3.HeaderText = "رقم الهوية"
        GridViewDecimalColumn3.IsAutoGenerated = True
        GridViewDecimalColumn3.Name = "IdentityCard_ID"
        GridViewCheckBoxColumn2.FieldName = "IsMarried"
        GridViewCheckBoxColumn2.HeaderText = "متزوجة"
        GridViewCheckBoxColumn2.IsAutoGenerated = True
        GridViewCheckBoxColumn2.Name = "IsMarried"
        GridViewCheckBoxColumn3.FieldName = "IsOwnOrphans"
        GridViewCheckBoxColumn3.HeaderText = "تحتضن ايتام"
        GridViewCheckBoxColumn3.IsAutoGenerated = True
        GridViewCheckBoxColumn3.Name = "IsOwnOrphans"
        GridViewTextBoxColumn3.FieldName = "Jop"
        GridViewTextBoxColumn3.HeaderText = "العمل"
        GridViewTextBoxColumn3.IsAutoGenerated = True
        GridViewTextBoxColumn3.Name = "Jop"
        GridViewDecimalColumn4.FieldName = "Salary"
        GridViewDecimalColumn4.HeaderText = "الدخل"
        GridViewDecimalColumn4.IsAutoGenerated = True
        GridViewDecimalColumn4.Name = "Salary"
        GridViewDateTimeColumn3.FieldName = "RegDate"
        GridViewDateTimeColumn3.HeaderText = "تاريخ التسجيل"
        GridViewDateTimeColumn3.IsAutoGenerated = True
        GridViewDateTimeColumn3.Name = "RegDate"
        GridViewDecimalColumn5.DataType = GetType(Long)
        GridViewDecimalColumn5.FieldName = "Color_Mark"
        GridViewDecimalColumn5.HeaderText = "اللون"
        GridViewDecimalColumn5.IsAutoGenerated = True
        GridViewDecimalColumn5.IsVisible = False
        GridViewDecimalColumn5.Name = "Color_Mark"
        Me.radDataGrid.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewDecimalColumn1, GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewDecimalColumn2, GridViewDateTimeColumn1, GridViewCheckBoxColumn1, GridViewDateTimeColumn2, GridViewDecimalColumn3, GridViewCheckBoxColumn2, GridViewCheckBoxColumn3, GridViewTextBoxColumn3, GridViewDecimalColumn4, GridViewDateTimeColumn3, GridViewDecimalColumn5})
        Me.radDataGrid.MasterTemplate.DataSource = Me.MothersBindingSource
        Me.radDataGrid.MasterTemplate.EnableAlternatingRowColor = True
        Me.radDataGrid.MasterTemplate.EnableFiltering = True
        Me.radDataGrid.MasterTemplate.MultiSelect = True
        Me.radDataGrid.MasterTemplate.SelectLastAddedRow = False
        Me.radDataGrid.MasterTemplate.ShowFilterCellOperatorText = False
        Me.radDataGrid.MasterTemplate.ShowTotals = True
        Me.radDataGrid.Name = "radDataGrid"
        Me.radDataGrid.ReadOnly = True
        Me.radDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.radDataGrid.Size = New System.Drawing.Size(690, 241)
        Me.radDataGrid.TabIndex = 2
        '
        'RadPrintDocument1
        '
        Me.RadPrintDocument1.AssociatedObject = Me.radDataGrid
        Me.RadPrintDocument1.DocumentName = "قائمة الأمهات"
        Me.RadPrintDocument1.FooterFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.RadPrintDocument1.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.RadPrintDocument1.Landscape = True
        RadPrintWatermark1.Font = New System.Drawing.Font("Tahoma", 144.0!)
        Me.RadPrintDocument1.Watermark = RadPrintWatermark1
        '
        'OrphansDBDataSet
        '
        Me.OrphansDBDataSet.DataSetName = "OrphansDBDataSet"
        Me.OrphansDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MothersBindingSource
        '
        Me.MothersBindingSource.DataMember = "Mothers"
        Me.MothersBindingSource.DataSource = Me.OrphansDBDataSet
        '
        'MothersTableAdapter
        '
        Me.MothersTableAdapter.ClearBeforeFill = True
        '
        'FrmMothers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 321)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmMothers"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "الأمهات"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.radCmdBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radDataGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrphansDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MothersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents radCmdBar As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement1 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripElement1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents btnDelete As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnEdit As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents mnuSep1 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents btnExclud As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnSetColor As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents mnuSep2 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents btnShowOrphans As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnShowFathers As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnSep3 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents btnColumn As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents RadStatusStrip1 As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents lblStatus As Telerik.WinControls.UI.RadLabelElement
    Friend WithEvents RadPrintDocument1 As Telerik.WinControls.UI.RadPrintDocument
    Friend WithEvents radDataGrid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents BtnBail As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents OrphansDBDataSet As Orphanage.OrphansDBDataSet
    Friend WithEvents MothersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MothersTableAdapter As Orphanage.OrphansDBDataSetTableAdapters.MothersTableAdapter
End Class

