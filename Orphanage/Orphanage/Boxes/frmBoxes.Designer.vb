<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBoxes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBoxes))
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim ConditionalFormattingObject1 As Telerik.WinControls.UI.ConditionalFormattingObject = New Telerik.WinControls.UI.ConditionalFormattingObject()
        Dim GridViewCheckBoxColumn1 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDateTimeColumn1 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim RadPrintWatermark1 As Telerik.WinControls.UI.RadPrintWatermark = New Telerik.WinControls.UI.RadPrintWatermark()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadStatusStrip1 = New Telerik.WinControls.UI.RadStatusStrip()
        Me.lblStatus = New Telerik.WinControls.UI.RadLabelElement()
        Me.radCmdBar = New Telerik.WinControls.UI.RadCommandBar()
        Me.CommandBarRowElement3 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.btnNew = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnEdit = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnDelete = New Telerik.WinControls.UI.CommandBarButton()
        Me.mnuSep1 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.btnDoTransformes = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnDoBills = New Telerik.WinControls.UI.CommandBarButton()
        Me.mnuSep2 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.btnShowBills = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnShowTransforms = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnSep3 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.btnColumn = New Telerik.WinControls.UI.CommandBarButton()
        Me.RadSplitContainer1 = New Telerik.WinControls.UI.RadSplitContainer()
        Me.SplitPanel1 = New Telerik.WinControls.UI.SplitPanel()
        Me.RadTextBox1 = New Telerik.WinControls.UI.RadTextBox()
        Me.SplitPanel2 = New Telerik.WinControls.UI.SplitPanel()
        Me.radDataGrid = New Telerik.WinControls.UI.RadGridView()
        Me.BoxesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrphansDBDataSet = New Orphanage.OrphansDBDataSet()
        Me.BoxesTableAdapter = New Orphanage.OrphansDBDataSetTableAdapters.BoxesTableAdapter()
        Me.RadPrintDocument1 = New Telerik.WinControls.UI.RadPrintDocument()
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
        CType(Me.BoxesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(565, 324)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadStatusStrip1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.lblStatus})
        Me.RadStatusStrip1.Location = New System.Drawing.Point(3, 296)
        Me.RadStatusStrip1.Name = "RadStatusStrip1"
        Me.RadStatusStrip1.Size = New System.Drawing.Size(559, 25)
        Me.RadStatusStrip1.TabIndex = 2
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
        Me.radCmdBar.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement3})
        Me.radCmdBar.Size = New System.Drawing.Size(559, 39)
        Me.radCmdBar.TabIndex = 1
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
        Me.CommandBarStripElement1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.mnuSep1, Me.btnDoTransformes, Me.btnDoBills, Me.mnuSep2, Me.btnShowBills, Me.btnShowTransforms, Me.btnSep3, Me.btnColumn})
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
        Me.btnNew.DisplayName = "CommandBarButton1"
        Me.btnNew.Image = Global.Orphanage.My.Resources.Resources.NewPng
        Me.btnNew.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Text = ""
        Me.btnNew.ToolTipText = "جديد"
        Me.btnNew.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnEdit
        '
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
        Me.mnuSep1.AccessibleDescription = "CommandBarSeparator1"
        Me.mnuSep1.AccessibleName = "CommandBarSeparator1"
        Me.mnuSep1.DisplayName = "CommandBarSeparator1"
        Me.mnuSep1.Name = "mnuSep1"
        Me.mnuSep1.StretchHorizontally = False
        Me.mnuSep1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.mnuSep1.VisibleInOverflowMenu = False
        '
        'btnDoTransformes
        '
        Me.btnDoTransformes.AutoSize = False
        Me.btnDoTransformes.Bounds = New System.Drawing.Rectangle(0, 0, 47, 40)
        Me.btnDoTransformes.DisplayName = "CommandBarButton1"
        Me.btnDoTransformes.Image = Global.Orphanage.My.Resources.Resources.transfer_money
        Me.btnDoTransformes.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDoTransformes.Name = "btnDoTransformes"
        Me.btnDoTransformes.Padding = New System.Windows.Forms.Padding(0)
        Me.btnDoTransformes.RightToLeft = True
        Me.btnDoTransformes.StretchHorizontally = False
        Me.btnDoTransformes.Text = ""
        Me.btnDoTransformes.ToolTipText = "تحويل"
        Me.btnDoTransformes.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnDoBills
        '
        Me.btnDoBills.AutoSize = False
        Me.btnDoBills.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnDoBills.DisplayName = "CommandBarButton2"
        Me.btnDoBills.Image = Global.Orphanage.My.Resources.Resources.Bill1
        Me.btnDoBills.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDoBills.Name = "btnDoBills"
        Me.btnDoBills.StretchHorizontally = False
        Me.btnDoBills.Text = ""
        Me.btnDoBills.ToolTipText = "سحب/ايداع"
        Me.btnDoBills.Visibility = Telerik.WinControls.ElementVisibility.Visible
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
        'btnShowBills
        '
        Me.btnShowBills.AutoSize = False
        Me.btnShowBills.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnShowBills.DisplayName = "CommandBarButton3"
        Me.btnShowBills.Image = CType(resources.GetObject("btnShowBills.Image"), System.Drawing.Image)
        Me.btnShowBills.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowBills.Name = "btnShowBills"
        Me.btnShowBills.Padding = New System.Windows.Forms.Padding(0)
        Me.btnShowBills.RightToLeft = True
        Me.btnShowBills.ShouldPaint = True
        Me.btnShowBills.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.[Default]
        Me.btnShowBills.StretchHorizontally = False
        Me.btnShowBills.Text = ""
        Me.btnShowBills.ToolTipText = "عرض الوصول"
        Me.btnShowBills.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnShowTransforms
        '
        Me.btnShowTransforms.AutoSize = False
        Me.btnShowTransforms.Bounds = New System.Drawing.Rectangle(0, 0, 49, 40)
        Me.btnShowTransforms.DisplayName = "CommandBarButton1"
        Me.btnShowTransforms.Image = Global.Orphanage.My.Resources.Resources.transfer_moneies
        Me.btnShowTransforms.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowTransforms.Name = "btnShowTransforms"
        Me.btnShowTransforms.StretchHorizontally = False
        Me.btnShowTransforms.Text = ""
        Me.btnShowTransforms.ToolTipText = "عرض التحويلات"
        Me.btnShowTransforms.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnSep3
        '
        Me.btnSep3.AccessibleDescription = "CommandBarSeparator1"
        Me.btnSep3.AccessibleName = "CommandBarSeparator1"
        Me.btnSep3.DisplayName = "CommandBarSeparator1"
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
        Me.RadSplitContainer1.Size = New System.Drawing.Size(565, 248)
        Me.RadSplitContainer1.SplitterWidth = 4
        Me.RadSplitContainer1.TabIndex = 2
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
        Me.SplitPanel1.Size = New System.Drawing.Size(120, 248)
        Me.SplitPanel1.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(-0.2860963!, 0.0!)
        Me.SplitPanel1.SizeInfo.SplitterCorrection = New System.Drawing.Size(-129, 0)
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
        Me.RadTextBox1.Size = New System.Drawing.Size(120, 248)
        Me.RadTextBox1.TabIndex = 0
        '
        'SplitPanel2
        '
        Me.SplitPanel2.Controls.Add(Me.radDataGrid)
        Me.SplitPanel2.Location = New System.Drawing.Point(124, 0)
        Me.SplitPanel2.Name = "SplitPanel2"
        '
        '
        '
        Me.SplitPanel2.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitPanel2.Size = New System.Drawing.Size(441, 248)
        Me.SplitPanel2.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.2860963!, 0.0!)
        Me.SplitPanel2.SizeInfo.SplitterCorrection = New System.Drawing.Size(129, 0)
        Me.SplitPanel2.TabIndex = 1
        Me.SplitPanel2.TabStop = False
        Me.SplitPanel2.Text = "SplitPanel2"
        '
        'radDataGrid
        '
        Me.radDataGrid.AutoScroll = True
        Me.radDataGrid.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.radDataGrid.Cursor = System.Windows.Forms.Cursors.Default
        Me.radDataGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radDataGrid.EnterKeyMode = Telerik.WinControls.UI.RadGridViewEnterKeyMode.EnterMovesToNextRow
        Me.radDataGrid.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.radDataGrid.ForeColor = System.Drawing.Color.Black
        Me.radDataGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.radDataGrid.Location = New System.Drawing.Point(0, 0)
        '
        'radDataGrid
        '
        Me.radDataGrid.MasterTemplate.AllowAddNewRow = False
        Me.radDataGrid.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.radDataGrid.MasterTemplate.AllowDeleteRow = False
        Me.radDataGrid.MasterTemplate.AllowEditRow = False
        Me.radDataGrid.MasterTemplate.ClipboardCopyMode = Telerik.WinControls.UI.GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        GridViewDecimalColumn1.DataType = GetType(Integer)
        GridViewDecimalColumn1.DecimalPlaces = 0
        GridViewDecimalColumn1.FieldName = "ID"
        GridViewDecimalColumn1.HeaderText = "الرقم"
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.Name = "ID"
        GridViewDecimalColumn1.ReadOnly = True
        GridViewDecimalColumn1.Width = 26
        GridViewTextBoxColumn1.FieldName = "Name"
        GridViewTextBoxColumn1.HeaderText = "اسم الحساب"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.Name = "Name"
        GridViewTextBoxColumn1.Width = 53
        GridViewTextBoxColumn2.FieldName = "Cur_Name"
        GridViewTextBoxColumn2.HeaderText = "اسم العملة"
        GridViewTextBoxColumn2.IsAutoGenerated = True
        GridViewTextBoxColumn2.Name = "Cur_Name"
        GridViewTextBoxColumn2.Width = 45
        GridViewTextBoxColumn3.FieldName = "Cur_Short"
        GridViewTextBoxColumn3.HeaderText = "اختصار العملة"
        GridViewTextBoxColumn3.IsAutoGenerated = True
        GridViewTextBoxColumn3.IsVisible = False
        GridViewTextBoxColumn3.Name = "Cur_Short"
        ConditionalFormattingObject1.ApplyToRow = True
        ConditionalFormattingObject1.CellBackColor = System.Drawing.Color.Empty
        ConditionalFormattingObject1.CellForeColor = System.Drawing.Color.Empty
        ConditionalFormattingObject1.Name = "NewCondition"
        ConditionalFormattingObject1.RowBackColor = System.Drawing.Color.Empty
        ConditionalFormattingObject1.RowForeColor = System.Drawing.Color.Red
        ConditionalFormattingObject1.TValue1 = "<0"
        GridViewDecimalColumn2.ConditionalFormattingObjectList.Add(ConditionalFormattingObject1)
        GridViewDecimalColumn2.FieldName = "AMount"
        GridViewDecimalColumn2.HeaderText = "المبلغ"
        GridViewDecimalColumn2.IsAutoGenerated = True
        GridViewDecimalColumn2.Name = "AMount"
        GridViewDecimalColumn2.Width = 28
        GridViewCheckBoxColumn1.FieldName = "Is_Positive"
        GridViewCheckBoxColumn1.HeaderText = "حساب جاري"
        GridViewCheckBoxColumn1.IsAutoGenerated = True
        GridViewCheckBoxColumn1.Name = "Is_Positive"
        GridViewCheckBoxColumn1.Width = 57
        GridViewTextBoxColumn4.FieldName = "Note"
        GridViewTextBoxColumn4.HeaderText = "ملاحظات"
        GridViewTextBoxColumn4.IsAutoGenerated = True
        GridViewTextBoxColumn4.IsVisible = False
        GridViewTextBoxColumn4.Name = "Note"
        GridViewTextBoxColumn5.FieldName = "UserName"
        GridViewTextBoxColumn5.HeaderText = "اسم المستخدم"
        GridViewTextBoxColumn5.IsAutoGenerated = True
        GridViewTextBoxColumn5.Name = "UserName"
        GridViewTextBoxColumn5.Width = 58
        GridViewDateTimeColumn1.FieldName = "RegDate"
        GridViewDateTimeColumn1.HeaderText = "تاريخ التسجيل"
        GridViewDateTimeColumn1.IsAutoGenerated = True
        GridViewDateTimeColumn1.Name = "RegDate"
        GridViewDateTimeColumn1.Width = 60
        Me.radDataGrid.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewDecimalColumn1, GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewDecimalColumn2, GridViewCheckBoxColumn1, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewDateTimeColumn1})
        Me.radDataGrid.MasterTemplate.DataSource = Me.BoxesBindingSource
        Me.radDataGrid.MasterTemplate.EnableAlternatingRowColor = True
        Me.radDataGrid.MasterTemplate.EnableFiltering = True
        Me.radDataGrid.MasterTemplate.EnableGrouping = False
        Me.radDataGrid.MasterTemplate.MultiSelect = True
        Me.radDataGrid.MasterTemplate.SelectLastAddedRow = False
        Me.radDataGrid.MasterTemplate.ShowFilterCellOperatorText = False
        Me.radDataGrid.Name = "radDataGrid"
        Me.radDataGrid.ReadOnly = True
        Me.radDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.radDataGrid.ShowGroupPanel = False
        Me.radDataGrid.Size = New System.Drawing.Size(441, 248)
        Me.radDataGrid.TabIndex = 3
        '
        'BoxesBindingSource
        '
        Me.BoxesBindingSource.AllowNew = True
        Me.BoxesBindingSource.DataMember = "Boxes"
        Me.BoxesBindingSource.DataSource = Me.OrphansDBDataSet
        '
        'OrphansDBDataSet
        '
        Me.OrphansDBDataSet.DataSetName = "OrphansDBDataSet"
        Me.OrphansDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BoxesTableAdapter
        '
        Me.BoxesTableAdapter.ClearBeforeFill = True
        '
        'RadPrintDocument1
        '
        Me.RadPrintDocument1.AssociatedObject = Me.radDataGrid
        Me.RadPrintDocument1.DocumentName = "حسابات مالية"
        Me.RadPrintDocument1.FooterFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.RadPrintDocument1.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!)
        RadPrintWatermark1.Font = New System.Drawing.Font("Tahoma", 144.0!)
        Me.RadPrintDocument1.Watermark = RadPrintWatermark1
        '
        'FrmBoxes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 324)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmBoxes"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "حسابات"
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
        CType(Me.BoxesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrphansDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents radCmdBar As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement3 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripElement1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents btnDelete As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnEdit As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents mnuSep1 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents btnDoTransformes As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnDoBills As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents mnuSep2 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents btnShowBills As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnShowTransforms As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnSep3 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents btnColumn As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents RadSplitContainer1 As Telerik.WinControls.UI.RadSplitContainer
    Friend WithEvents SplitPanel1 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents RadTextBox1 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents SplitPanel2 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents RadStatusStrip1 As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents lblStatus As Telerik.WinControls.UI.RadLabelElement
    Friend WithEvents btnNew As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents radDataGrid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents OrphansDBDataSet As Orphanage.OrphansDBDataSet
    Friend WithEvents BoxesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BoxesTableAdapter As Orphanage.OrphansDBDataSetTableAdapters.BoxesTableAdapter
    Friend WithEvents RadPrintDocument1 As Telerik.WinControls.UI.RadPrintDocument
End Class

