<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUsers
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadStatusStrip1 = New Telerik.WinControls.UI.RadStatusStrip()
        Me.lblStatue = New Telerik.WinControls.UI.RadLabelElement()
        Me.RadSplitContainer1 = New Telerik.WinControls.UI.RadSplitContainer()
        Me.SplitPanel2 = New Telerik.WinControls.UI.SplitPanel()
        Me.RadScrollablePanel1 = New Telerik.WinControls.UI.RadScrollablePanel()
        Me.RadCommandBar1 = New Telerik.WinControls.UI.RadCommandBar()
        Me.CommandBarRowElement1 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.btnNew = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnEdit = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnDelete = New Telerik.WinControls.UI.CommandBarButton()
        Me.CommandBarSeparator1 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.btnShowOrphans = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnShowFamiles = New Telerik.WinControls.UI.CommandBarButton()
        Me.CommandBarSeparator2 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.btnSupporters = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnShowBails = New Telerik.WinControls.UI.CommandBarButton()
        Me.CommandBarSeparator3 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.btnShowBills = New Telerik.WinControls.UI.CommandBarButton()
        Me.btnShowTRan = New Telerik.WinControls.UI.CommandBarButton()
        Me.RadSplitContainer2 = New Telerik.WinControls.UI.RadSplitContainer()
        Me.SplitPanel1 = New Telerik.WinControls.UI.SplitPanel()
        Me.RadTextBox1 = New Telerik.WinControls.UI.RadTextBox()
        Me.SplitPanel3 = New Telerik.WinControls.UI.SplitPanel()
        Me.radDataGrid = New Telerik.WinControls.UI.RadGridView()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadSplitContainer1.SuspendLayout()
        CType(Me.SplitPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel2.SuspendLayout()
        CType(Me.RadScrollablePanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadScrollablePanel1.PanelContainer.SuspendLayout()
        Me.RadScrollablePanel1.SuspendLayout()
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadSplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadSplitContainer2.SuspendLayout()
        CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel1.SuspendLayout()
        CType(Me.RadTextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel3.SuspendLayout()
        CType(Me.radDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radDataGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.RadStatusStrip1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.RadSplitContainer1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RadSplitContainer2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(652, 323)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.lblStatue})
        Me.RadStatusStrip1.Location = New System.Drawing.Point(3, 301)
        Me.RadStatusStrip1.Name = "RadStatusStrip1"
        Me.RadStatusStrip1.Size = New System.Drawing.Size(646, 19)
        Me.RadStatusStrip1.TabIndex = 2
        Me.RadStatusStrip1.Text = "RadStatusStrip1"
        '
        'lblStatue
        '
        Me.lblStatue.Name = "lblStatue"
        Me.RadStatusStrip1.SetSpring(Me.lblStatue, False)
        Me.lblStatue.Text = ""
        Me.lblStatue.TextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.lblStatue.TextWrap = True
        Me.lblStatue.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'RadSplitContainer1
        '
        Me.RadSplitContainer1.Controls.Add(Me.SplitPanel2)
        Me.RadSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadSplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.RadSplitContainer1.Name = "RadSplitContainer1"
        '
        '
        '
        Me.RadSplitContainer1.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.RadSplitContainer1.Size = New System.Drawing.Size(652, 41)
        Me.RadSplitContainer1.SplitterWidth = 4
        Me.RadSplitContainer1.TabIndex = 4
        Me.RadSplitContainer1.TabStop = False
        Me.RadSplitContainer1.Text = "RadSplitContainer1"
        '
        'SplitPanel2
        '
        Me.SplitPanel2.Controls.Add(Me.RadScrollablePanel1)
        Me.SplitPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SplitPanel2.Name = "SplitPanel2"
        '
        '
        '
        Me.SplitPanel2.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitPanel2.Size = New System.Drawing.Size(652, 41)
        Me.SplitPanel2.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.09217876!, 0.0!)
        Me.SplitPanel2.SizeInfo.SplitterCorrection = New System.Drawing.Size(46, 0)
        Me.SplitPanel2.TabIndex = 1
        Me.SplitPanel2.TabStop = False
        Me.SplitPanel2.Text = "SplitPanel2"
        '
        'RadScrollablePanel1
        '
        Me.RadScrollablePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadScrollablePanel1.Location = New System.Drawing.Point(0, 0)
        Me.RadScrollablePanel1.Name = "RadScrollablePanel1"
        '
        'RadScrollablePanel1.PanelContainer
        '
        Me.RadScrollablePanel1.PanelContainer.Controls.Add(Me.RadCommandBar1)
        Me.RadScrollablePanel1.PanelContainer.Size = New System.Drawing.Size(650, 39)
        Me.RadScrollablePanel1.Size = New System.Drawing.Size(652, 41)
        Me.RadScrollablePanel1.TabIndex = 0
        Me.RadScrollablePanel1.Text = "RadScrollablePanel1"
        '
        'RadCommandBar1
        '
        Me.RadCommandBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.RadCommandBar1.Name = "RadCommandBar1"
        Me.RadCommandBar1.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement1})
        Me.RadCommandBar1.Size = New System.Drawing.Size(650, 40)
        Me.RadCommandBar1.TabIndex = 1
        '
        'CommandBarRowElement1
        '
        Me.CommandBarRowElement1.MinSize = New System.Drawing.Size(25, 25)
        Me.CommandBarRowElement1.Strips.AddRange(New Telerik.WinControls.UI.CommandBarStripElement() {Me.CommandBarStripElement1})
        Me.CommandBarRowElement1.Text = ""
        '
        'CommandBarStripElement1
        '
        Me.CommandBarStripElement1.Alignment = System.Drawing.ContentAlignment.MiddleRight
        Me.CommandBarStripElement1.AutoSize = True
        Me.CommandBarStripElement1.BorderGradientStyle = Telerik.WinControls.GradientStyles.Gel
        Me.CommandBarStripElement1.ClipDrawing = True
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
        Me.CommandBarStripElement1.Grip.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.CommandBarStripElement1.Grip.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        Me.CommandBarStripElement1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.CommandBarSeparator1, Me.btnShowOrphans, Me.btnShowFamiles, Me.CommandBarSeparator2, Me.btnSupporters, Me.btnShowBails, Me.CommandBarSeparator3, Me.btnShowBills, Me.btnShowTRan})
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
        Me.CommandBarStripElement1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        Me.CommandBarStripElement1.StretchHorizontally = False
        CType(Me.CommandBarStripElement1.GetChildAt(0), Telerik.WinControls.UI.RadCommandBarGrip).BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        CType(Me.CommandBarStripElement1.GetChildAt(0), Telerik.WinControls.UI.RadCommandBarGrip).Visibility = Telerik.WinControls.ElementVisibility.Hidden
        CType(Me.CommandBarStripElement1.GetChildAt(2), Telerik.WinControls.UI.RadCommandBarOverflowButton).Visibility = Telerik.WinControls.ElementVisibility.Hidden
        '
        'btnNew
        '
        Me.btnNew.AutoSize = False
        Me.btnNew.AutoToolTip = True
        Me.btnNew.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnNew.Image = Global.Orphanage.My.Resources.Resources.NewPng
        Me.btnNew.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNew.Name = "btnNew"
        Me.btnNew.StretchHorizontally = True
        Me.btnNew.Text = ""
        Me.btnNew.ToolTipText = "جديد"
        Me.btnNew.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnEdit
        '
        Me.btnEdit.AutoSize = False
        Me.btnEdit.AutoToolTip = True
        Me.btnEdit.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
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
        'btnDelete
        '
        Me.btnDelete.AutoSize = False
        Me.btnDelete.AutoToolTip = True
        Me.btnDelete.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnDelete.DrawText = False
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
        'CommandBarSeparator1
        '
        Me.CommandBarSeparator1.AccessibleDescription = "CommandBarSeparator1"
        Me.CommandBarSeparator1.AccessibleName = "CommandBarSeparator1"
        Me.CommandBarSeparator1.DisplayName = "CommandBarSeparator1"
        Me.CommandBarSeparator1.Name = "CommandBarSeparator1"
        Me.CommandBarSeparator1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.CommandBarSeparator1.VisibleInOverflowMenu = False
        '
        'btnShowOrphans
        '
        Me.btnShowOrphans.AutoSize = False
        Me.btnShowOrphans.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        Me.btnShowOrphans.AutoToolTip = True
        Me.btnShowOrphans.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnShowOrphans.Image = Global.Orphanage.My.Resources.Resources.Orphans
        Me.btnShowOrphans.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowOrphans.Name = "btnShowOrphans"
        Me.btnShowOrphans.StretchHorizontally = False
        Me.btnShowOrphans.Text = ""
        Me.btnShowOrphans.ToolTipText = "عرض الأيتام"
        Me.btnShowOrphans.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnShowFamiles
        '
        Me.btnShowFamiles.AccessibleDescription = "CommandBarButton3"
        Me.btnShowFamiles.AutoSize = False
        Me.btnShowFamiles.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        Me.btnShowFamiles.AutoToolTip = True
        Me.btnShowFamiles.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnShowFamiles.Image = Global.Orphanage.My.Resources.Resources.Family
        Me.btnShowFamiles.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowFamiles.Name = "btnShowFamiles"
        Me.btnShowFamiles.StretchHorizontally = False
        Me.btnShowFamiles.Text = ""
        Me.btnShowFamiles.ToolTipText = "عرض العائلات"
        Me.btnShowFamiles.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'CommandBarSeparator2
        '
        Me.CommandBarSeparator2.AccessibleDescription = "CommandBarSeparator2"
        Me.CommandBarSeparator2.AccessibleName = "CommandBarSeparator2"
        Me.CommandBarSeparator2.DisplayName = "CommandBarSeparator2"
        Me.CommandBarSeparator2.Name = "CommandBarSeparator2"
        Me.CommandBarSeparator2.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.CommandBarSeparator2.VisibleInOverflowMenu = False
        '
        'btnSupporters
        '
        Me.btnSupporters.AutoSize = False
        Me.btnSupporters.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnSupporters.DisplayName = "CommandBarButton1"
        Me.btnSupporters.Image = Global.Orphanage.My.Resources.Resources.Supporter
        Me.btnSupporters.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSupporters.Name = "btnSupporters"
        Me.btnSupporters.Text = ""
        Me.btnSupporters.ToolTipText = "عرض الكفلاء"
        Me.btnSupporters.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnShowBails
        '
        Me.btnShowBails.AutoSize = False
        Me.btnShowBails.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnShowBails.Image = Global.Orphanage.My.Resources.Resources.Bail
        Me.btnShowBails.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowBails.Name = "btnShowBails"
        Me.btnShowBails.Text = ""
        Me.btnShowBails.ToolTipText = "عرض الكفالات"
        Me.btnShowBails.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'CommandBarSeparator3
        '
        Me.CommandBarSeparator3.AccessibleDescription = "CommandBarSeparator3"
        Me.CommandBarSeparator3.AccessibleName = "CommandBarSeparator3"
        Me.CommandBarSeparator3.DisplayName = "CommandBarSeparator3"
        Me.CommandBarSeparator3.Name = "CommandBarSeparator3"
        Me.CommandBarSeparator3.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.CommandBarSeparator3.VisibleInOverflowMenu = False
        '
        'btnShowBills
        '
        Me.btnShowBills.AutoSize = False
        Me.btnShowBills.Bounds = New System.Drawing.Rectangle(0, 0, 40, 40)
        Me.btnShowBills.Image = Global.Orphanage.My.Resources.Resources.Bills
        Me.btnShowBills.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowBills.Name = "btnShowBills"
        Me.btnShowBills.Text = ""
        Me.btnShowBills.ToolTipText = "عرض الإيصالات"
        Me.btnShowBills.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnShowTRan
        '
        Me.btnShowTRan.AutoSize = False
        Me.btnShowTRan.Bounds = New System.Drawing.Rectangle(0, 0, 45, 40)
        Me.btnShowTRan.DisplayName = "CommandBarButton2"
        Me.btnShowTRan.Image = Global.Orphanage.My.Resources.Resources.transfer_moneies
        Me.btnShowTRan.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowTRan.Name = "btnShowTRan"
        Me.btnShowTRan.Text = ""
        Me.btnShowTRan.ToolTipText = "عرض التحويلات"
        Me.btnShowTRan.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'RadSplitContainer2
        '
        Me.RadSplitContainer2.Controls.Add(Me.SplitPanel1)
        Me.RadSplitContainer2.Controls.Add(Me.SplitPanel3)
        Me.RadSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadSplitContainer2.Location = New System.Drawing.Point(0, 41)
        Me.RadSplitContainer2.Name = "RadSplitContainer2"
        '
        '
        '
        Me.RadSplitContainer2.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.RadSplitContainer2.Size = New System.Drawing.Size(652, 257)
        Me.RadSplitContainer2.SplitterWidth = 6
        Me.RadSplitContainer2.TabIndex = 5
        Me.RadSplitContainer2.TabStop = False
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
        Me.SplitPanel1.Size = New System.Drawing.Size(176, 257)
        Me.SplitPanel1.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(-0.2280405!, 0.0!)
        Me.SplitPanel1.SizeInfo.SplitterCorrection = New System.Drawing.Size(-122, 0)
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
        Me.RadTextBox1.Size = New System.Drawing.Size(176, 257)
        Me.RadTextBox1.TabIndex = 0
        '
        'SplitPanel3
        '
        Me.SplitPanel3.Controls.Add(Me.radDataGrid)
        Me.SplitPanel3.Location = New System.Drawing.Point(182, 0)
        Me.SplitPanel3.Name = "SplitPanel3"
        '
        '
        '
        Me.SplitPanel3.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitPanel3.Size = New System.Drawing.Size(470, 257)
        Me.SplitPanel3.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.2280405!, 0.0!)
        Me.SplitPanel3.SizeInfo.SplitterCorrection = New System.Drawing.Size(122, 0)
        Me.SplitPanel3.TabIndex = 1
        Me.SplitPanel3.TabStop = False
        Me.SplitPanel3.Text = "SplitPanel3"
        '
        'radDataGrid
        '
        Me.radDataGrid.AutoGenerateHierarchy = True
        Me.radDataGrid.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.radDataGrid.ColumnChooserSortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending
        Me.radDataGrid.Cursor = System.Windows.Forms.Cursors.Default
        Me.radDataGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radDataGrid.EnableCustomDrawing = True
        Me.radDataGrid.EnableFastScrolling = True
        Me.radDataGrid.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.radDataGrid.ForeColor = System.Drawing.Color.Black
        Me.radDataGrid.GroupExpandAnimationType = Telerik.WinControls.UI.GridExpandAnimationType.Fade
        Me.radDataGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.radDataGrid.Location = New System.Drawing.Point(0, 0)
        '
        'radDataGrid
        '
        Me.radDataGrid.MasterTemplate.AllowAddNewRow = False
        Me.radDataGrid.MasterTemplate.AllowCellContextMenu = False
        Me.radDataGrid.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.radDataGrid.MasterTemplate.AllowEditRow = False
        Me.radDataGrid.MasterTemplate.AllowRowReorder = True
        Me.radDataGrid.MasterTemplate.ClipboardCopyMode = Telerik.WinControls.UI.GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.radDataGrid.MasterTemplate.ClipboardPasteMode = Telerik.WinControls.UI.GridViewClipboardPasteMode.Disable
        Me.radDataGrid.MasterTemplate.EnableAlternatingRowColor = True
        Me.radDataGrid.MasterTemplate.EnableHierarchyFiltering = True
        Me.radDataGrid.MasterTemplate.MultiSelect = True
        Me.radDataGrid.MasterTemplate.ShowGroupedColumns = True
        Me.radDataGrid.Name = "radDataGrid"
        Me.radDataGrid.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.None
        Me.radDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.radDataGrid.ShowGroupPanel = False
        Me.radDataGrid.Size = New System.Drawing.Size(470, 257)
        Me.radDataGrid.StandardTab = True
        Me.radDataGrid.TabIndex = 3
        '
        'FrmUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 323)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmUsers"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "مستخدمين"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadSplitContainer1.ResumeLayout(False)
        CType(Me.SplitPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel2.ResumeLayout(False)
        Me.RadScrollablePanel1.PanelContainer.ResumeLayout(False)
        Me.RadScrollablePanel1.PanelContainer.PerformLayout()
        CType(Me.RadScrollablePanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadScrollablePanel1.ResumeLayout(False)
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadSplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadSplitContainer2.ResumeLayout(False)
        CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel1.ResumeLayout(False)
        CType(Me.RadTextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel3.ResumeLayout(False)
        CType(Me.radDataGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents radDataGrid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents RadStatusStrip1 As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents lblStatue As Telerik.WinControls.UI.RadLabelElement
    Friend WithEvents RadSplitContainer1 As Telerik.WinControls.UI.RadSplitContainer
    Friend WithEvents SplitPanel2 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents RadScrollablePanel1 As Telerik.WinControls.UI.RadScrollablePanel
    Friend WithEvents RadCommandBar1 As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement1 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripElement1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents btnNew As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnDelete As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnEdit As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents CommandBarSeparator1 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents btnShowFamiles As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnShowOrphans As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents RadSplitContainer2 As Telerik.WinControls.UI.RadSplitContainer
    Friend WithEvents SplitPanel1 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents SplitPanel3 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents RadTextBox1 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btnShowBails As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents CommandBarSeparator2 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents btnShowBills As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents btnSupporters As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents CommandBarSeparator3 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents btnShowTRan As Telerik.WinControls.UI.CommandBarButton
End Class

