<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFamiles
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
        Dim GridViewDecimalColumn5 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn14 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDateTimeColumn2 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewTextBoxColumn15 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn6 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn16 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn17 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn18 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewCheckBoxColumn3 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewCheckBoxColumn4 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewTextBoxColumn19 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn20 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn21 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn22 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn23 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn24 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn7 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn8 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim RadPrintWatermark2 As Telerik.WinControls.UI.RadPrintWatermark = New Telerik.WinControls.UI.RadPrintWatermark()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadStatusStrip1 = New Telerik.WinControls.UI.RadStatusStrip()
        Me.lblStatus = New Telerik.WinControls.UI.RadLabelElement()
        Me.radCmdBar = New Telerik.WinControls.UI.RadCommandBar()
        Me.CommandBarRowElement1 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.btnNew = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnDelete = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnEdit = New Telerik.WinControls.UI.CommandBarButton()
        Me.mnuSep1 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.btnExclud = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnSetColor = New Telerik.WinControls.UI.CommandBarButton()
        Me.mnuSep2 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.btnShowOrphans = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnShowMothers = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnShowFathers = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnSep3 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.btnColumn = New Telerik.WinControls.UI.CommandBarButton()
        Me.RadSplitContainer1 = New Telerik.WinControls.UI.RadSplitContainer()
        Me.SplitPanel1 = New Telerik.WinControls.UI.SplitPanel()
        Me.RadTextBox1 = New Telerik.WinControls.UI.RadTextBox()
        Me.SplitPanel2 = New Telerik.WinControls.UI.SplitPanel()
        Me.radDataGrid = New Telerik.WinControls.UI.RadGridView()
        Me.FamiliesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrphansDBDataSet = New Orphanage.OrphansDBDataSet()
        Me.RadPrintDocument1 = New Telerik.WinControls.UI.RadPrintDocument()
        Me.FamiliesTableAdapter = New Orphanage.OrphansDBDataSetTableAdapters.FamiliesTableAdapter()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radCmdBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadSplitContainer1.SuspendLayout()
        CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel1.SuspendLayout()
        CType(Me.RadTextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel2.SuspendLayout()
        CType(Me.radDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radDataGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FamiliesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrphansDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.RadStatusStrip1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.radCmdBar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RadSplitContainer1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(613, 401)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadStatusStrip1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.lblStatus})
        Me.RadStatusStrip1.Location = New System.Drawing.Point(3, 376)
        Me.RadStatusStrip1.Name = "RadStatusStrip1"
        Me.RadStatusStrip1.Size = New System.Drawing.Size(607, 22)
        Me.RadStatusStrip1.TabIndex = 2
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
        'radCmdBar
        '
        Me.radCmdBar.AutoSize = False
        Me.radCmdBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radCmdBar.Location = New System.Drawing.Point(3, 3)
        Me.radCmdBar.Name = "radCmdBar"
        Me.radCmdBar.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement1})
        Me.radCmdBar.Size = New System.Drawing.Size(607, 39)
        Me.radCmdBar.TabIndex = 2
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
        Me.CommandBarStripElement1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.btnNew, Me.btnDelete, Me.btnEdit, Me.mnuSep1, Me.btnExclud, Me.btnSetColor, Me.mnuSep2, Me.btnShowOrphans, Me.btnShowMothers, Me.btnShowFathers, Me.btnSep3, Me.btnColumn})
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
        'btnNew
        '
        Me.btnNew.AutoSize = False
        Me.btnNew.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnNew.Image = Global.Orphanage.My.Resources.Resources.NewPng
        Me.btnNew.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Text = ""
        Me.btnNew.ToolTipText = "جديد"
        Me.btnNew.Visibility = Telerik.WinControls.ElementVisibility.Visible
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
        Me.btnDelete.StretchHorizontally = False
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
        Me.btnEdit.StretchHorizontally = False
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
        Me.mnuSep1.StretchHorizontally = False
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
        Me.btnExclud.StretchHorizontally = False
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
        Me.btnSetColor.StretchHorizontally = False
        Me.btnSetColor.Text = ""
        Me.btnSetColor.ToolTipText = "تعيين لون"
        Me.btnSetColor.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuSep2
        '
        Me.mnuSep2.AccessibleDescription = "CommandBarSeparator2"
        Me.mnuSep2.AccessibleName = "CommandBarSeparator2"
        Me.mnuSep2.DisplayName = "CommandBarSeparator2"
        Me.mnuSep2.Name = "mnuSep2"
        Me.mnuSep2.StretchHorizontally = False
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
        Me.btnShowOrphans.StretchHorizontally = False
        Me.btnShowOrphans.Text = ""
        Me.btnShowOrphans.ToolTipText = "عرض الأيتام"
        Me.btnShowOrphans.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnShowMothers
        '
        Me.btnShowMothers.AccessibleDescription = "CommandBarButton1"
        Me.btnShowMothers.AccessibleName = "CommandBarButton1"
        Me.btnShowMothers.AutoSize = False
        Me.btnShowMothers.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnShowMothers.DisplayName = "CommandBarButton1"
        Me.btnShowMothers.Image = Global.Orphanage.My.Resources.Resources.mom
        Me.btnShowMothers.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowMothers.Name = "btnShowMothers"
        Me.btnShowMothers.StretchHorizontally = False
        Me.btnShowMothers.Text = ""
        Me.btnShowMothers.ToolTipText = "عرض الأمهات"
        Me.btnShowMothers.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnShowFathers
        '
        Me.btnShowFathers.AutoSize = False
        Me.btnShowFathers.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnShowFathers.DisplayName = "CommandBarButton1"
        Me.btnShowFathers.Image = Global.Orphanage.My.Resources.Resources.dad
        Me.btnShowFathers.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowFathers.Name = "btnShowFathers"
        Me.btnShowFathers.Text = ""
        Me.btnShowFathers.ToolTipText = "عرض الآباء"
        Me.btnShowFathers.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnSep3
        '
        Me.btnSep3.AccessibleDescription = "CommandBarSeparator1"
        Me.btnSep3.AccessibleName = "CommandBarSeparator1"
        Me.btnSep3.DisplayName = "CommandBarSeparator1"
        Me.btnSep3.Name = "btnSep3"
        Me.btnSep3.StretchHorizontally = True
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
        Me.btnColumn.StretchHorizontally = False
        Me.btnColumn.Text = ""
        Me.btnColumn.TextWrap = False
        Me.btnColumn.ToolTipText = "الأعمدة"
        Me.btnColumn.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'RadSplitContainer1
        '
        Me.RadSplitContainer1.Controls.Add(Me.SplitPanel1)
        Me.RadSplitContainer1.Controls.Add(Me.SplitPanel2)
        Me.RadSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadSplitContainer1.Location = New System.Drawing.Point(0, 45)
        Me.RadSplitContainer1.Name = "RadSplitContainer1"
        '
        '
        '
        Me.RadSplitContainer1.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.RadSplitContainer1.Size = New System.Drawing.Size(613, 328)
        Me.RadSplitContainer1.SplitterWidth = 4
        Me.RadSplitContainer1.TabIndex = 0
        Me.RadSplitContainer1.TabStop = False
        Me.RadSplitContainer1.Text = "RadSplitContainer1"
        '
        'SplitPanel1
        '
        Me.SplitPanel1.Controls.Add(Me.RadTextBox1)
        Me.SplitPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SplitPanel1.Name = "SplitPanel1"
        '
        '
        '
        Me.SplitPanel1.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitPanel1.Size = New System.Drawing.Size(145, 328)
        Me.SplitPanel1.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(-0.2622505!, 0.0!)
        Me.SplitPanel1.SizeInfo.SplitterCorrection = New System.Drawing.Size(-145, 0)
        Me.SplitPanel1.TabIndex = 0
        Me.SplitPanel1.TabStop = False
        Me.SplitPanel1.Text = "SplitPanel1"
        '
        'RadTextBox1
        '
        Me.RadTextBox1.AutoSize = False
        Me.RadTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.RadTextBox1.Multiline = True
        Me.RadTextBox1.Name = "RadTextBox1"
        Me.RadTextBox1.Size = New System.Drawing.Size(145, 328)
        Me.RadTextBox1.TabIndex = 0
        Me.RadTextBox1.Text = "..."
        '
        'SplitPanel2
        '
        Me.SplitPanel2.Controls.Add(Me.radDataGrid)
        Me.SplitPanel2.Location = New System.Drawing.Point(149, 0)
        Me.SplitPanel2.Name = "SplitPanel2"
        '
        '
        '
        Me.SplitPanel2.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitPanel2.Size = New System.Drawing.Size(464, 328)
        Me.SplitPanel2.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.2622505!, 0.0!)
        Me.SplitPanel2.SizeInfo.SplitterCorrection = New System.Drawing.Size(145, 0)
        Me.SplitPanel2.TabIndex = 1
        Me.SplitPanel2.TabStop = False
        Me.SplitPanel2.Text = "SplitPanel2"
        '
        'radDataGrid
        '
        Me.radDataGrid.AutoScroll = True
        Me.radDataGrid.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.radDataGrid.CausesValidation = False
        Me.radDataGrid.ColumnChooserSortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending
        Me.radDataGrid.Cursor = System.Windows.Forms.Cursors.Default
        Me.radDataGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radDataGrid.EnableCustomDrawing = True
        Me.radDataGrid.EnableFastScrolling = True
        Me.radDataGrid.EnableGestures = False
        Me.radDataGrid.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.radDataGrid.ForeColor = System.Drawing.Color.Black
        Me.radDataGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.radDataGrid.Location = New System.Drawing.Point(0, 0)
        '
        'radDataGrid
        '
        Me.radDataGrid.MasterTemplate.AllowAddNewRow = False
        Me.radDataGrid.MasterTemplate.AllowEditRow = False
        GridViewDecimalColumn5.DataType = GetType(Integer)
        GridViewDecimalColumn5.FieldName = "Family_ID"
        GridViewDecimalColumn5.HeaderText = "رقم العائلة"
        GridViewDecimalColumn5.IsAutoGenerated = True
        GridViewDecimalColumn5.Name = "Family_ID"
        GridViewTextBoxColumn13.FieldName = "FathName"
        GridViewTextBoxColumn13.HeaderText = "اسم الأب"
        GridViewTextBoxColumn13.IsAutoGenerated = True
        GridViewTextBoxColumn13.Name = "FathName"
        GridViewTextBoxColumn14.FieldName = "MothName"
        GridViewTextBoxColumn14.HeaderText = "اسم الأم"
        GridViewTextBoxColumn14.IsAutoGenerated = True
        GridViewTextBoxColumn14.Name = "MothName"
        GridViewDateTimeColumn2.FieldName = "Dieday"
        GridViewDateTimeColumn2.HeaderText = "تاريخ الوفاة"
        GridViewDateTimeColumn2.IsAutoGenerated = True
        GridViewDateTimeColumn2.Name = "Dieday"
        GridViewTextBoxColumn15.FieldName = "DeathResone"
        GridViewTextBoxColumn15.HeaderText = "سبب الوفاة"
        GridViewTextBoxColumn15.IsAutoGenerated = True
        GridViewTextBoxColumn15.Name = "DeathResone"
        GridViewDecimalColumn6.DataType = GetType(Integer)
        GridViewDecimalColumn6.FieldName = "OrphansCount"
        GridViewDecimalColumn6.HeaderText = "عدد الأيتام"
        GridViewDecimalColumn6.IsAutoGenerated = True
        GridViewDecimalColumn6.Name = "OrphansCount"
        GridViewTextBoxColumn16.FieldName = "Finncial_State"
        GridViewTextBoxColumn16.HeaderText = "الحالة المالية"
        GridViewTextBoxColumn16.IsAutoGenerated = True
        GridViewTextBoxColumn16.Name = "Finncial_State"
        GridViewTextBoxColumn17.FieldName = "Redidence_State"
        GridViewTextBoxColumn17.HeaderText = "حالة السكن"
        GridViewTextBoxColumn17.IsAutoGenerated = True
        GridViewTextBoxColumn17.Name = "Redidence_State"
        GridViewTextBoxColumn18.FieldName = "Residence_Type"
        GridViewTextBoxColumn18.HeaderText = "نوع السكن"
        GridViewTextBoxColumn18.IsAutoGenerated = True
        GridViewTextBoxColumn18.Name = "Residence_Type"
        GridViewCheckBoxColumn3.FieldName = "IsRefugee"
        GridViewCheckBoxColumn3.HeaderText = "مهجرة"
        GridViewCheckBoxColumn3.IsAutoGenerated = True
        GridViewCheckBoxColumn3.Name = "IsRefugee"
        GridViewCheckBoxColumn4.FieldName = "IsBailed"
        GridViewCheckBoxColumn4.HeaderText = "مكفولة"
        GridViewCheckBoxColumn4.IsAutoGenerated = True
        GridViewCheckBoxColumn4.Name = "IsBailed"
        GridViewTextBoxColumn19.FieldName = "Country"
        GridViewTextBoxColumn19.HeaderText = "المحافظة"
        GridViewTextBoxColumn19.IsAutoGenerated = True
        GridViewTextBoxColumn19.Name = "Country"
        GridViewTextBoxColumn20.FieldName = "City"
        GridViewTextBoxColumn20.HeaderText = "المدينة"
        GridViewTextBoxColumn20.IsAutoGenerated = True
        GridViewTextBoxColumn20.Name = "City"
        GridViewTextBoxColumn21.FieldName = "Town"
        GridViewTextBoxColumn21.HeaderText = "البلدة"
        GridViewTextBoxColumn21.IsAutoGenerated = True
        GridViewTextBoxColumn21.Name = "Town"
        GridViewTextBoxColumn22.FieldName = "Street"
        GridViewTextBoxColumn22.HeaderText = "الشارع"
        GridViewTextBoxColumn22.IsAutoGenerated = True
        GridViewTextBoxColumn22.Name = "Street"
        GridViewTextBoxColumn23.FieldName = "Home_Phone"
        GridViewTextBoxColumn23.HeaderText = "هاتف ارضي"
        GridViewTextBoxColumn23.IsAutoGenerated = True
        GridViewTextBoxColumn23.Name = "Home_Phone"
        GridViewTextBoxColumn24.FieldName = "Cell_Phone"
        GridViewTextBoxColumn24.HeaderText = "خليوي"
        GridViewTextBoxColumn24.IsAutoGenerated = True
        GridViewTextBoxColumn24.Name = "Cell_Phone"
        GridViewDecimalColumn7.DataType = GetType(Integer)
        GridViewDecimalColumn7.FieldName = "AddressID"
        GridViewDecimalColumn7.HeaderText = "رقم العنوان"
        GridViewDecimalColumn7.IsAutoGenerated = True
        GridViewDecimalColumn7.Name = "AddressID"
        GridViewDecimalColumn8.DataType = GetType(Long)
        GridViewDecimalColumn8.FieldName = "Color_Mark"
        GridViewDecimalColumn8.HeaderText = "اللون"
        GridViewDecimalColumn8.IsAutoGenerated = True
        GridViewDecimalColumn8.Name = "Color_Mark"
        Me.radDataGrid.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewDecimalColumn5, GridViewTextBoxColumn13, GridViewTextBoxColumn14, GridViewDateTimeColumn2, GridViewTextBoxColumn15, GridViewDecimalColumn6, GridViewTextBoxColumn16, GridViewTextBoxColumn17, GridViewTextBoxColumn18, GridViewCheckBoxColumn3, GridViewCheckBoxColumn4, GridViewTextBoxColumn19, GridViewTextBoxColumn20, GridViewTextBoxColumn21, GridViewTextBoxColumn22, GridViewTextBoxColumn23, GridViewTextBoxColumn24, GridViewDecimalColumn7, GridViewDecimalColumn8})
        Me.radDataGrid.MasterTemplate.DataSource = Me.FamiliesBindingSource
        Me.radDataGrid.MasterTemplate.EnableAlternatingRowColor = True
        Me.radDataGrid.MasterTemplate.EnableFiltering = True
        Me.radDataGrid.MasterTemplate.MultiSelect = True
        Me.radDataGrid.MasterTemplate.ShowFilterCellOperatorText = False
        Me.radDataGrid.Name = "radDataGrid"
        Me.radDataGrid.ReadOnly = True
        Me.radDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.radDataGrid.ShowCellErrors = False
        Me.radDataGrid.ShowItemToolTips = False
        Me.radDataGrid.ShowRowErrors = False
        Me.radDataGrid.Size = New System.Drawing.Size(464, 328)
        Me.radDataGrid.TabIndex = 0
        '
        'FamiliesBindingSource
        '
        Me.FamiliesBindingSource.DataMember = "Families"
        Me.FamiliesBindingSource.DataSource = Me.OrphansDBDataSet
        '
        'OrphansDBDataSet
        '
        Me.OrphansDBDataSet.DataSetName = "OrphansDBDataSet"
        Me.OrphansDBDataSet.EnforceConstraints = False
        Me.OrphansDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RadPrintDocument1
        '
        Me.RadPrintDocument1.AssociatedObject = Me.radDataGrid
        Me.RadPrintDocument1.DocumentName = "عائلات"
        Me.RadPrintDocument1.FooterFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.RadPrintDocument1.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!)
        RadPrintWatermark2.Font = New System.Drawing.Font("Tahoma", 144.0!)
        Me.RadPrintDocument1.Watermark = RadPrintWatermark2
        '
        'FamiliesTableAdapter
        '
        Me.FamiliesTableAdapter.ClearBeforeFill = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'BackgroundWorker1
        '
        '
        'FrmFamiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 401)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmFamiles"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "عائلات"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radCmdBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadSplitContainer1.ResumeLayout(False)
        CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel1.ResumeLayout(False)
        CType(Me.RadTextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel2.ResumeLayout(False)
        CType(Me.radDataGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FamiliesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrphansDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RadSplitContainer1 As Telerik.WinControls.UI.RadSplitContainer
    Friend WithEvents SplitPanel1 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents SplitPanel2 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents RadTextBox1 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents radCmdBar As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement1 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripElement1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents btnNew As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnDelete As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnEdit As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents mnuSep1 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents btnExclud As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnSetColor As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents mnuSep2 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents btnShowOrphans As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnShowMothers As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnShowFathers As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnSep3 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents btnColumn As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents RadStatusStrip1 As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents lblStatus As Telerik.WinControls.UI.RadLabelElement
    Friend WithEvents RadPrintDocument1 As Telerik.WinControls.UI.RadPrintDocument
    Friend WithEvents radDataGrid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents OrphansDBDataSet As Orphanage.OrphansDBDataSet
    Friend WithEvents FamiliesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FamiliesTableAdapter As Orphanage.OrphansDBDataSetTableAdapters.FamiliesTableAdapter
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class

