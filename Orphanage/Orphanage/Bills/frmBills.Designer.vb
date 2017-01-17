<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBills
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
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewCheckBoxColumn1 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDateTimeColumn1 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewCheckBoxColumn2 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewDecimalColumn4 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewCheckBoxColumn3 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewDecimalColumn5 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewCheckBoxColumn4 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewDecimalColumn6 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn7 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDateTimeColumn2 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim RadPrintWatermark1 As Telerik.WinControls.UI.RadPrintWatermark = New Telerik.WinControls.UI.RadPrintWatermark()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.radCmdBar = New Telerik.WinControls.UI.RadCommandBar()
        Me.CommandBarRowElement3 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.btnDelete = New Telerik.WinControls.UI.CommandBarButton()
        Me.mnuSep1 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.btnUnDoBill = New Telerik.WinControls.UI.CommandBarButton()
        Me.mnuSep2 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.btnShowOrphans = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnShowFamilies = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnShowBails = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnSep3 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.btnColumn = New Telerik.WinControls.UI.CommandBarButton()
        Me.RadStatusStrip1 = New Telerik.WinControls.UI.RadStatusStrip()
        Me.lblStatus = New Telerik.WinControls.UI.RadLabelElement()
        Me.RadSplitContainer1 = New Telerik.WinControls.UI.RadSplitContainer()
        Me.SplitPanel2 = New Telerik.WinControls.UI.SplitPanel()
        Me.radDataGrid = New Telerik.WinControls.UI.RadGridView()
        Me.BillsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrphansDBDataSet = New Orphanage.OrphansDBDataSet()
        Me.RadSplitContainer2 = New Telerik.WinControls.UI.RadSplitContainer()
        Me.SplitPanel3 = New Telerik.WinControls.UI.SplitPanel()
        Me.RadGroupBox3 = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblAllDeposit = New Telerik.WinControls.UI.RadLabel()
        Me.lblGroupCol = New Telerik.WinControls.UI.RadLabel()
        Me.lblAllDraws = New Telerik.WinControls.UI.RadLabel()
        Me.SplitPanel4 = New Telerik.WinControls.UI.SplitPanel()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.btnSort = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.dteTo = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.dteFrom = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.SplitPanel5 = New Telerik.WinControls.UI.SplitPanel()
        Me.chkSort = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.optRegDate = New Telerik.WinControls.UI.RadRadioButton()
        Me.optBillDate = New Telerik.WinControls.UI.RadRadioButton()
        Me.BillsTableAdapter = New Orphanage.OrphansDBDataSetTableAdapters.BillsTableAdapter()
        Me.RadPrintDocument1 = New Telerik.WinControls.UI.RadPrintDocument()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.radCmdBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadSplitContainer1.SuspendLayout()
        CType(Me.SplitPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel2.SuspendLayout()
        CType(Me.radDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radDataGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BillsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrphansDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadSplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadSplitContainer2.SuspendLayout()
        CType(Me.SplitPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel3.SuspendLayout()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox3.SuspendLayout()
        CType(Me.lblAllDeposit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGroupCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAllDraws, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel4.SuspendLayout()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.btnSort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel5.SuspendLayout()
        CType(Me.chkSort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.optRegDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optBillDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.radCmdBar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RadStatusStrip1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.RadSplitContainer1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.RadSplitContainer2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(678, 433)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'radCmdBar
        '
        Me.radCmdBar.AutoSize = False
        Me.radCmdBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radCmdBar.Location = New System.Drawing.Point(3, 3)
        Me.radCmdBar.Name = "radCmdBar"
        Me.radCmdBar.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement3})
        Me.radCmdBar.Size = New System.Drawing.Size(672, 41)
        Me.radCmdBar.TabIndex = 3
        '
        'CommandBarRowElement3
        '
        Me.CommandBarRowElement3.MinSize = New System.Drawing.Size(25, 25)
        Me.CommandBarRowElement3.Strips.AddRange(New Telerik.WinControls.UI.CommandBarStripElement() {Me.CommandBarStripElement1})
        Me.CommandBarRowElement3.Text = ""
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
        Me.CommandBarStripElement1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.btnDelete, Me.mnuSep1, Me.btnUnDoBill, Me.mnuSep2, Me.btnShowOrphans, Me.btnShowFamilies, Me.btnShowBails, Me.btnSep3, Me.btnColumn})
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
        'mnuSep1
        '
        Me.mnuSep1.DisplayName = "CommandBarSeparator1"
        Me.mnuSep1.Name = "mnuSep1"
        Me.mnuSep1.StretchHorizontally = False
        Me.mnuSep1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.mnuSep1.VisibleInOverflowMenu = False
        '
        'btnUnDoBill
        '
        Me.btnUnDoBill.AutoSize = False
        Me.btnUnDoBill.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnUnDoBill.DisplayName = "CommandBarButton1"
        Me.btnUnDoBill.Image = Global.Orphanage.My.Resources.Resources.UnDoBill
        Me.btnUnDoBill.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUnDoBill.Name = "btnUnDoBill"
        Me.btnUnDoBill.Padding = New System.Windows.Forms.Padding(0)
        Me.btnUnDoBill.RightToLeft = True
        Me.btnUnDoBill.StretchHorizontally = False
        Me.btnUnDoBill.Text = ""
        Me.btnUnDoBill.ToolTipText = "تراجع عن الوصل"
        Me.btnUnDoBill.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuSep2
        '
        Me.mnuSep2.DisplayName = "CommandBarSeparator2"
        Me.mnuSep2.Name = "mnuSep2"
        Me.mnuSep2.StretchHorizontally = False
        Me.mnuSep2.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.mnuSep2.VisibleInOverflowMenu = False
        '
        'btnShowOrphans
        '
        Me.btnShowOrphans.AutoSize = False
        Me.btnShowOrphans.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
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
        'btnShowFamilies
        '
        Me.btnShowFamilies.AutoSize = False
        Me.btnShowFamilies.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnShowFamilies.DisplayName = "CommandBarButton2"
        Me.btnShowFamilies.Image = Global.Orphanage.My.Resources.Resources.Family
        Me.btnShowFamilies.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowFamilies.Name = "btnShowFamilies"
        Me.btnShowFamilies.Text = ""
        Me.btnShowFamilies.ToolTipText = "عرض العائلات"
        Me.btnShowFamilies.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnShowBails
        '
        Me.btnShowBails.AutoSize = False
        Me.btnShowBails.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnShowBails.DisplayName = "CommandBarButton1"
        Me.btnShowBails.Image = Global.Orphanage.My.Resources.Resources.Bail
        Me.btnShowBails.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowBails.Name = "btnShowBails"
        Me.btnShowBails.Text = ""
        Me.btnShowBails.ToolTipText = "عرض الكفالات"
        Me.btnShowBails.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnSep3
        '
        Me.btnSep3.Name = "btnSep3"
        Me.btnSep3.StretchHorizontally = False
        Me.btnSep3.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.btnSep3.VisibleInOverflowMenu = False
        '
        'btnColumn
        '
        Me.btnColumn.AccessibleDescription = "CommandBarButton1"
        Me.btnColumn.AccessibleName = "CommandBarButton1"
        Me.btnColumn.AutoSize = False
        Me.btnColumn.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnColumn.Image = Global.Orphanage.My.Resources.Resources.columns
        Me.btnColumn.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnColumn.Name = "btnColumn"
        Me.btnColumn.StretchHorizontally = False
        Me.btnColumn.Text = ""
        Me.btnColumn.TextWrap = False
        Me.btnColumn.ToolTipText = "الأعمدة"
        Me.btnColumn.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.lblStatus})
        Me.RadStatusStrip1.Location = New System.Drawing.Point(3, 408)
        Me.RadStatusStrip1.Name = "RadStatusStrip1"
        Me.RadStatusStrip1.Size = New System.Drawing.Size(672, 24)
        Me.RadStatusStrip1.TabIndex = 3
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
        'RadSplitContainer1
        '
        Me.RadSplitContainer1.Controls.Add(Me.SplitPanel2)
        Me.RadSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadSplitContainer1.Location = New System.Drawing.Point(0, 115)
        Me.RadSplitContainer1.Name = "RadSplitContainer1"
        '
        '
        '
        Me.RadSplitContainer1.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.RadSplitContainer1.Size = New System.Drawing.Size(678, 290)
        Me.RadSplitContainer1.SplitterWidth = 4
        Me.RadSplitContainer1.TabIndex = 0
        Me.RadSplitContainer1.TabStop = False
        Me.RadSplitContainer1.Text = "RadSplitContainer1"
        '
        'SplitPanel2
        '
        Me.SplitPanel2.Controls.Add(Me.radDataGrid)
        Me.SplitPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SplitPanel2.Name = "SplitPanel2"
        '
        '
        '
        Me.SplitPanel2.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitPanel2.Size = New System.Drawing.Size(678, 290)
        Me.SplitPanel2.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.2531807!, 0.0!)
        Me.SplitPanel2.SizeInfo.SplitterCorrection = New System.Drawing.Size(99, 0)
        Me.SplitPanel2.TabIndex = 1
        Me.SplitPanel2.TabStop = False
        Me.SplitPanel2.Text = "SplitPanel2"
        '
        'radDataGrid
        '
        Me.radDataGrid.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.radDataGrid.ColumnChooserSortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending
        Me.radDataGrid.Cursor = System.Windows.Forms.Cursors.Default
        Me.radDataGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radDataGrid.EnableCustomDrawing = True
        Me.radDataGrid.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.radDataGrid.ForeColor = System.Drawing.Color.Black
        Me.radDataGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.radDataGrid.Location = New System.Drawing.Point(0, 0)
        '
        'radDataGrid
        '
        Me.radDataGrid.MasterTemplate.AllowAddNewRow = False
        Me.radDataGrid.MasterTemplate.AllowEditRow = False
        GridViewDecimalColumn1.DataType = GetType(Integer)
        GridViewDecimalColumn1.FieldName = "ID"
        GridViewDecimalColumn1.HeaderText = "ID"
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.IsVisible = False
        GridViewDecimalColumn1.Name = "ID"
        GridViewDecimalColumn1.VisibleInColumnChooser = False
        GridViewDecimalColumn2.FieldName = "Bill_Number"
        GridViewDecimalColumn2.HeaderText = "رقم الإيصال"
        GridViewDecimalColumn2.IsAutoGenerated = True
        GridViewDecimalColumn2.Name = "Bill_Number"
        GridViewDecimalColumn2.Width = 83
        GridViewTextBoxColumn1.FieldName = "BoxName"
        GridViewTextBoxColumn1.HeaderText = "الحساب"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.Name = "BoxName"
        GridViewTextBoxColumn1.Width = 83
        GridViewDecimalColumn3.FieldName = "Amount"
        GridViewDecimalColumn3.HeaderText = "المبلغ"
        GridViewDecimalColumn3.IsAutoGenerated = True
        GridViewDecimalColumn3.Name = "Amount"
        GridViewDecimalColumn3.Width = 83
        GridViewTextBoxColumn2.FieldName = "Cur_Name"
        GridViewTextBoxColumn2.HeaderText = "العملة"
        GridViewTextBoxColumn2.IsAutoGenerated = True
        GridViewTextBoxColumn2.Name = "Cur_Name"
        GridViewTextBoxColumn2.Width = 83
        GridViewTextBoxColumn3.FieldName = "SideName"
        GridViewTextBoxColumn3.HeaderText = "الجهة"
        GridViewTextBoxColumn3.IsAutoGenerated = True
        GridViewTextBoxColumn3.Name = "SideName"
        GridViewTextBoxColumn3.Width = 83
        GridViewCheckBoxColumn1.FieldName = "IsDeposite"
        GridViewCheckBoxColumn1.HeaderText = "إيداع"
        GridViewCheckBoxColumn1.IsAutoGenerated = True
        GridViewCheckBoxColumn1.Name = "IsDeposite"
        GridViewCheckBoxColumn1.Width = 83
        GridViewTextBoxColumn4.FieldName = "Details"
        GridViewTextBoxColumn4.HeaderText = "تفاصيل"
        GridViewTextBoxColumn4.IsAutoGenerated = True
        GridViewTextBoxColumn4.Name = "Details"
        GridViewTextBoxColumn4.Width = 83
        GridViewDateTimeColumn1.FieldName = "Bill_Date"
        GridViewDateTimeColumn1.HeaderText = "تاريخ الإيصال"
        GridViewDateTimeColumn1.IsAutoGenerated = True
        GridViewDateTimeColumn1.Name = "Bill_Date"
        GridViewDateTimeColumn1.Width = 83
        GridViewCheckBoxColumn2.FieldName = "IsOrphan"
        GridViewCheckBoxColumn2.HeaderText = "يتيم"
        GridViewCheckBoxColumn2.IsAutoGenerated = True
        GridViewCheckBoxColumn2.IsVisible = False
        GridViewCheckBoxColumn2.Name = "IsOrphan"
        GridViewDecimalColumn4.DataType = GetType(Integer)
        GridViewDecimalColumn4.FieldName = "Orphan_ID"
        GridViewDecimalColumn4.HeaderText = "Orphan_ID"
        GridViewDecimalColumn4.IsAutoGenerated = True
        GridViewDecimalColumn4.IsVisible = False
        GridViewDecimalColumn4.Name = "Orphan_ID"
        GridViewDecimalColumn4.VisibleInColumnChooser = False
        GridViewCheckBoxColumn3.FieldName = "IsFamily"
        GridViewCheckBoxColumn3.HeaderText = "عائلة"
        GridViewCheckBoxColumn3.IsAutoGenerated = True
        GridViewCheckBoxColumn3.IsVisible = False
        GridViewCheckBoxColumn3.Name = "IsFamily"
        GridViewDecimalColumn5.DataType = GetType(Integer)
        GridViewDecimalColumn5.FieldName = "Family_ID"
        GridViewDecimalColumn5.HeaderText = "Family_ID"
        GridViewDecimalColumn5.IsAutoGenerated = True
        GridViewDecimalColumn5.IsVisible = False
        GridViewDecimalColumn5.Name = "Family_ID"
        GridViewDecimalColumn5.VisibleInColumnChooser = False
        GridViewCheckBoxColumn4.FieldName = "IsBail"
        GridViewCheckBoxColumn4.HeaderText = "كفالة"
        GridViewCheckBoxColumn4.IsAutoGenerated = True
        GridViewCheckBoxColumn4.IsVisible = False
        GridViewCheckBoxColumn4.Name = "IsBail"
        GridViewDecimalColumn6.DataType = GetType(Integer)
        GridViewDecimalColumn6.FieldName = "Bail_Id"
        GridViewDecimalColumn6.HeaderText = "Bail_Id"
        GridViewDecimalColumn6.IsAutoGenerated = True
        GridViewDecimalColumn6.IsVisible = False
        GridViewDecimalColumn6.Name = "Bail_Id"
        GridViewDecimalColumn6.VisibleInColumnChooser = False
        GridViewDecimalColumn7.DataType = GetType(Integer)
        GridViewDecimalColumn7.FieldName = "Box_ID"
        GridViewDecimalColumn7.HeaderText = "Box_ID"
        GridViewDecimalColumn7.IsAutoGenerated = True
        GridViewDecimalColumn7.IsVisible = False
        GridViewDecimalColumn7.Name = "Box_ID"
        GridViewDecimalColumn7.VisibleInColumnChooser = False
        GridViewTextBoxColumn5.FieldName = "Note"
        GridViewTextBoxColumn5.HeaderText = "Note"
        GridViewTextBoxColumn5.IsAutoGenerated = True
        GridViewTextBoxColumn5.IsVisible = False
        GridViewTextBoxColumn5.Name = "Note"
        GridViewDateTimeColumn2.DataType = GetType(String)
        GridViewDateTimeColumn2.FieldName = "RegDate"
        GridViewDateTimeColumn2.HeaderText = "تاريخ التسجيل"
        GridViewDateTimeColumn2.IsAutoGenerated = True
        GridViewDateTimeColumn2.IsVisible = False
        GridViewDateTimeColumn2.Name = "RegDate"
        GridViewTextBoxColumn6.FieldName = "UserName"
        GridViewTextBoxColumn6.HeaderText = "اسم المستخدم"
        GridViewTextBoxColumn6.IsAutoGenerated = True
        GridViewTextBoxColumn6.IsVisible = False
        GridViewTextBoxColumn6.Name = "UserName"
        Me.radDataGrid.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewDecimalColumn1, GridViewDecimalColumn2, GridViewTextBoxColumn1, GridViewDecimalColumn3, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewCheckBoxColumn1, GridViewTextBoxColumn4, GridViewDateTimeColumn1, GridViewCheckBoxColumn2, GridViewDecimalColumn4, GridViewCheckBoxColumn3, GridViewDecimalColumn5, GridViewCheckBoxColumn4, GridViewDecimalColumn6, GridViewDecimalColumn7, GridViewTextBoxColumn5, GridViewDateTimeColumn2, GridViewTextBoxColumn6})
        Me.radDataGrid.MasterTemplate.DataSource = Me.BillsBindingSource
        Me.radDataGrid.MasterTemplate.EnableAlternatingRowColor = True
        Me.radDataGrid.MasterTemplate.EnableFiltering = True
        Me.radDataGrid.MasterTemplate.MultiSelect = True
        Me.radDataGrid.MasterTemplate.ShowFilterCellOperatorText = False
        Me.radDataGrid.Name = "radDataGrid"
        Me.radDataGrid.ReadOnly = True
        Me.radDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.radDataGrid.Size = New System.Drawing.Size(678, 290)
        Me.radDataGrid.TabIndex = 0
        '
        'BillsBindingSource
        '
        Me.BillsBindingSource.DataMember = "Bills"
        Me.BillsBindingSource.DataSource = Me.OrphansDBDataSet
        '
        'OrphansDBDataSet
        '
        Me.OrphansDBDataSet.DataSetName = "OrphansDBDataSet"
        Me.OrphansDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RadSplitContainer2
        '
        Me.RadSplitContainer2.Controls.Add(Me.SplitPanel3)
        Me.RadSplitContainer2.Controls.Add(Me.SplitPanel4)
        Me.RadSplitContainer2.Controls.Add(Me.SplitPanel5)
        Me.RadSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadSplitContainer2.Location = New System.Drawing.Point(0, 47)
        Me.RadSplitContainer2.Name = "RadSplitContainer2"
        '
        '
        '
        Me.RadSplitContainer2.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.RadSplitContainer2.Size = New System.Drawing.Size(678, 68)
        Me.RadSplitContainer2.SplitterWidth = 4
        Me.RadSplitContainer2.TabIndex = 4
        Me.RadSplitContainer2.TabStop = False
        Me.RadSplitContainer2.Text = "RadSplitContainer2"
        '
        'SplitPanel3
        '
        Me.SplitPanel3.Controls.Add(Me.RadGroupBox3)
        Me.SplitPanel3.Location = New System.Drawing.Point(0, 0)
        Me.SplitPanel3.Name = "SplitPanel3"
        '
        '
        '
        Me.SplitPanel3.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitPanel3.Size = New System.Drawing.Size(349, 68)
        Me.SplitPanel3.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.1875622!, 0.0!)
        Me.SplitPanel3.SizeInfo.SplitterCorrection = New System.Drawing.Size(139, 0)
        Me.SplitPanel3.TabIndex = 0
        Me.SplitPanel3.TabStop = False
        Me.SplitPanel3.Text = "SplitPanel3"
        '
        'RadGroupBox3
        '
        Me.RadGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox3.Controls.Add(Me.lblAllDeposit)
        Me.RadGroupBox3.Controls.Add(Me.lblGroupCol)
        Me.RadGroupBox3.Controls.Add(Me.lblAllDraws)
        Me.RadGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadGroupBox3.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.RadGroupBox3.HeaderText = "مجموع"
        Me.RadGroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.RadGroupBox3.Name = "RadGroupBox3"
        Me.RadGroupBox3.Size = New System.Drawing.Size(349, 68)
        Me.RadGroupBox3.TabIndex = 0
        Me.RadGroupBox3.Text = "مجموع"
        '
        'lblAllDeposit
        '
        Me.lblAllDeposit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAllDeposit.AutoSize = False
        Me.lblAllDeposit.BorderVisible = True
        Me.lblAllDeposit.Location = New System.Drawing.Point(180, 43)
        Me.lblAllDeposit.Name = "lblAllDeposit"
        Me.lblAllDeposit.Size = New System.Drawing.Size(164, 18)
        Me.lblAllDeposit.TabIndex = 0
        Me.lblAllDeposit.Text = "المبالغ المودعة :"
        Me.lblAllDeposit.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'lblGroupCol
        '
        Me.lblGroupCol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGroupCol.AutoSize = False
        Me.lblGroupCol.BorderVisible = True
        Me.lblGroupCol.Location = New System.Drawing.Point(5, 22)
        Me.lblGroupCol.Name = "lblGroupCol"
        Me.lblGroupCol.Size = New System.Drawing.Size(339, 18)
        Me.lblGroupCol.TabIndex = 0
        Me.lblGroupCol.Text = "اسم الحساب :"
        Me.lblGroupCol.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'lblAllDraws
        '
        Me.lblAllDraws.AutoSize = False
        Me.lblAllDraws.BorderVisible = True
        Me.lblAllDraws.Location = New System.Drawing.Point(5, 43)
        Me.lblAllDraws.Name = "lblAllDraws"
        Me.lblAllDraws.Size = New System.Drawing.Size(169, 18)
        Me.lblAllDraws.TabIndex = 0
        Me.lblAllDraws.Text = "المبالغ المسحوبة :"
        Me.lblAllDraws.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'SplitPanel4
        '
        Me.SplitPanel4.Controls.Add(Me.RadGroupBox2)
        Me.SplitPanel4.Location = New System.Drawing.Point(353, 0)
        Me.SplitPanel4.Name = "SplitPanel4"
        '
        '
        '
        Me.SplitPanel4.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitPanel4.Size = New System.Drawing.Size(229, 68)
        Me.SplitPanel4.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.00845769!, 0.0!)
        Me.SplitPanel4.SizeInfo.SplitterCorrection = New System.Drawing.Size(-22, 0)
        Me.SplitPanel4.TabIndex = 1
        Me.SplitPanel4.TabStop = False
        Me.SplitPanel4.Text = "SplitPanel4"
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox2.Controls.Add(Me.btnSort)
        Me.RadGroupBox2.Controls.Add(Me.RadLabel2)
        Me.RadGroupBox2.Controls.Add(Me.RadLabel1)
        Me.RadGroupBox2.Controls.Add(Me.dteTo)
        Me.RadGroupBox2.Controls.Add(Me.dteFrom)
        Me.RadGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadGroupBox2.Enabled = False
        Me.RadGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.RadGroupBox2.HeaderText = "المدة"
        Me.RadGroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Size = New System.Drawing.Size(229, 68)
        Me.RadGroupBox2.TabIndex = 0
        Me.RadGroupBox2.Text = "المدة"
        '
        'btnSort
        '
        Me.btnSort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSort.Location = New System.Drawing.Point(6, 21)
        Me.btnSort.Name = "btnSort"
        Me.btnSort.Size = New System.Drawing.Size(69, 42)
        Me.btnSort.TabIndex = 2
        Me.btnSort.Text = "فرز"
        '
        'RadLabel2
        '
        Me.RadLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadLabel2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.Location = New System.Drawing.Point(198, 23)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(24, 17)
        Me.RadLabel2.TabIndex = 1
        Me.RadLabel2.Text = "من :"
        Me.RadLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel1
        '
        Me.RadLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadLabel1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(198, 43)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(25, 17)
        Me.RadLabel1.TabIndex = 1
        Me.RadLabel1.Text = "إلى :"
        Me.RadLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'dteTo
        '
        Me.dteTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dteTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteTo.Location = New System.Drawing.Point(83, 43)
        Me.dteTo.Name = "dteTo"
        Me.dteTo.Size = New System.Drawing.Size(111, 20)
        Me.dteTo.TabIndex = 0
        Me.dteTo.TabStop = False
        Me.dteTo.Text = "6/15/2014"
        Me.dteTo.Value = New Date(2014, 6, 15, 16, 51, 13, 696)
        '
        'dteFrom
        '
        Me.dteFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dteFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteFrom.Location = New System.Drawing.Point(83, 21)
        Me.dteFrom.Name = "dteFrom"
        Me.dteFrom.Size = New System.Drawing.Size(111, 20)
        Me.dteFrom.TabIndex = 0
        Me.dteFrom.TabStop = False
        Me.dteFrom.Text = "6/15/2014"
        Me.dteFrom.Value = New Date(2014, 6, 15, 16, 51, 13, 696)
        '
        'SplitPanel5
        '
        Me.SplitPanel5.Controls.Add(Me.chkSort)
        Me.SplitPanel5.Controls.Add(Me.RadGroupBox1)
        Me.SplitPanel5.Location = New System.Drawing.Point(586, 0)
        Me.SplitPanel5.Name = "SplitPanel5"
        '
        '
        '
        Me.SplitPanel5.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitPanel5.Size = New System.Drawing.Size(92, 68)
        Me.SplitPanel5.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(-0.1960199!, 0.0!)
        Me.SplitPanel5.SizeInfo.SplitterCorrection = New System.Drawing.Size(-117, 0)
        Me.SplitPanel5.TabIndex = 2
        Me.SplitPanel5.TabStop = False
        Me.SplitPanel5.Text = "SplitPanel5"
        '
        'chkSort
        '
        Me.chkSort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSort.Location = New System.Drawing.Point(58, 1)
        Me.chkSort.Name = "chkSort"
        Me.chkSort.Size = New System.Drawing.Size(15, 15)
        Me.chkSort.TabIndex = 1
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.optRegDate)
        Me.RadGroupBox1.Controls.Add(Me.optBillDate)
        Me.RadGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadGroupBox1.Enabled = False
        Me.RadGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.RadGroupBox1.HeaderText = "فرز"
        Me.RadGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(92, 68)
        Me.RadGroupBox1.TabIndex = 0
        Me.RadGroupBox1.Text = "فرز"
        '
        'optRegDate
        '
        Me.optRegDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optRegDate.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optRegDate.Location = New System.Drawing.Point(4, 22)
        Me.optRegDate.Name = "optRegDate"
        Me.optRegDate.Size = New System.Drawing.Size(76, 17)
        Me.optRegDate.TabIndex = 0
        Me.optRegDate.Text = "تاريخ التسجيل"
        '
        'optBillDate
        '
        Me.optBillDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optBillDate.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optBillDate.Location = New System.Drawing.Point(8, 43)
        Me.optBillDate.Name = "optBillDate"
        Me.optBillDate.Size = New System.Drawing.Size(72, 17)
        Me.optBillDate.TabIndex = 0
        Me.optBillDate.TabStop = True
        Me.optBillDate.Text = "تاريخ الوصل"
        Me.optBillDate.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'BillsTableAdapter
        '
        Me.BillsTableAdapter.ClearBeforeFill = True
        '
        'RadPrintDocument1
        '
        Me.RadPrintDocument1.AssociatedObject = Me.radDataGrid
        Me.RadPrintDocument1.DocumentName = "إيصالات مالية"
        Me.RadPrintDocument1.FooterFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.RadPrintDocument1.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!)
        RadPrintWatermark1.Font = New System.Drawing.Font("Tahoma", 144.0!)
        Me.RadPrintDocument1.Watermark = RadPrintWatermark1
        '
        'FrmBills
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 433)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmBills"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "ايصالات"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.radCmdBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadSplitContainer1.ResumeLayout(False)
        CType(Me.SplitPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel2.ResumeLayout(False)
        CType(Me.radDataGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BillsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrphansDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadSplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadSplitContainer2.ResumeLayout(False)
        CType(Me.SplitPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel3.ResumeLayout(False)
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox3.ResumeLayout(False)
        CType(Me.lblAllDeposit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGroupCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAllDraws, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel4.ResumeLayout(False)
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        Me.RadGroupBox2.PerformLayout()
        CType(Me.btnSort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel5.ResumeLayout(False)
        Me.SplitPanel5.PerformLayout()
        CType(Me.chkSort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.optRegDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optBillDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RadSplitContainer1 As Telerik.WinControls.UI.RadSplitContainer
    Friend WithEvents SplitPanel2 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents radDataGrid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents radCmdBar As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement3 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripElement1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents btnDelete As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents mnuSep1 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents btnUnDoBill As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents mnuSep2 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents btnShowOrphans As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnShowBails As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnShowFamilies As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnSep3 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents btnColumn As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents RadStatusStrip1 As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents lblStatus As Telerik.WinControls.UI.RadLabelElement
    Friend WithEvents OrphansDBDataSet As Orphanage.OrphansDBDataSet
    Friend WithEvents BillsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BillsTableAdapter As Orphanage.OrphansDBDataSetTableAdapters.BillsTableAdapter
    Friend WithEvents RadSplitContainer2 As Telerik.WinControls.UI.RadSplitContainer
    Friend WithEvents SplitPanel3 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents SplitPanel4 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents optRegDate As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optBillDate As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents dteTo As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents dteFrom As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents chkSort As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents btnSort As Telerik.WinControls.UI.RadButton
    Friend WithEvents SplitPanel5 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents RadGroupBox3 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblGroupCol As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblAllDraws As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblAllDeposit As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadPrintDocument1 As Telerik.WinControls.UI.RadPrintDocument
End Class

