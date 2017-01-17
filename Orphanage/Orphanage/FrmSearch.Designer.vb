<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSearch
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
        Dim DescriptionTextListDataItem1 As Telerik.WinControls.UI.DescriptionTextListDataItem = New Telerik.WinControls.UI.DescriptionTextListDataItem()
        Dim DescriptionTextListDataItem2 As Telerik.WinControls.UI.DescriptionTextListDataItem = New Telerik.WinControls.UI.DescriptionTextListDataItem()
        Dim DescriptionTextListDataItem3 As Telerik.WinControls.UI.DescriptionTextListDataItem = New Telerik.WinControls.UI.DescriptionTextListDataItem()
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadStatusStrip1 = New Telerik.WinControls.UI.RadStatusStrip()
        Me.btnSearch = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnShow = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnStop = New Telerik.WinControls.UI.RadButtonElement()
        Me.CommandBarSeparator1 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.lblState = New Telerik.WinControls.UI.RadLabelElement()
        Me.radWatingBar = New Telerik.WinControls.UI.RadWaitingBarElement()
        Me.RadSplitContainer1 = New Telerik.WinControls.UI.RadSplitContainer()
        Me.SplitPanel1 = New Telerik.WinControls.UI.SplitPanel()
        Me.RadPageView1 = New Telerik.WinControls.UI.RadPageView()
        Me.pgeOrphan = New Telerik.WinControls.UI.RadPageViewPage()
        Me.chkEnableOrph = New Telerik.WinControls.UI.RadCheckBox()
        Me.txtOrphSex = New Telerik.WinControls.UI.RadDropDownList()
        Me.numOrphKaid = New Telerik.WinControls.UI.RadSpinEditor()
        Me.numOrphAge = New Telerik.WinControls.UI.RadSpinEditor()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel27 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel26 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel9 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.chkOrphIsSick = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.chkOrphHasBodyPhoto = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkOrphHasFacePhoto = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkOrphIsBaild = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkOrphEnabledBirthday = New Telerik.WinControls.UI.RadCheckBox()
        Me.grpOrphDate = New Telerik.WinControls.UI.RadGroupBox()
        Me.dteOrphTo = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.dteOrphFrom = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.txtOrphBirthPlace = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.txtOrphNAme = New Telerik.WinControls.UI.RadTextBox()
        Me.pgeFather = New Telerik.WinControls.UI.RadPageViewPage()
        Me.numFathId = New Telerik.WinControls.UI.RadSpinEditor()
        Me.numFathAge = New Telerik.WinControls.UI.RadSpinEditor()
        Me.RadLabel12 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel13 = New Telerik.WinControls.UI.RadLabel()
        Me.chkFathEnabledDieDate = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel14 = New Telerik.WinControls.UI.RadLabel()
        Me.grpFathDieDate = New Telerik.WinControls.UI.RadGroupBox()
        Me.dteFathTo = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.dteFathFrom = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadLabel15 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel16 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel17 = New Telerik.WinControls.UI.RadLabel()
        Me.txtFathDeathRe = New Telerik.WinControls.UI.RadTextBox()
        Me.txtFatheJop = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel18 = New Telerik.WinControls.UI.RadLabel()
        Me.txtFathName = New Telerik.WinControls.UI.RadTextBox()
        Me.chkEnableFath = New Telerik.WinControls.UI.RadCheckBox()
        Me.pgeMother = New Telerik.WinControls.UI.RadPageViewPage()
        Me.numMothId = New Telerik.WinControls.UI.RadSpinEditor()
        Me.numMothAge = New Telerik.WinControls.UI.RadSpinEditor()
        Me.RadLabel10 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel11 = New Telerik.WinControls.UI.RadLabel()
        Me.chkMothEnabledBirth = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel19 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel20 = New Telerik.WinControls.UI.RadLabel()
        Me.chkMothIsDead = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel21 = New Telerik.WinControls.UI.RadLabel()
        Me.chkMothIsMarried = New Telerik.WinControls.UI.RadCheckBox()
        Me.grpMothBirth = New Telerik.WinControls.UI.RadGroupBox()
        Me.dteMothTo = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.dteMothFrom = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadLabel22 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel23 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel24 = New Telerik.WinControls.UI.RadLabel()
        Me.txtMothAdd = New Telerik.WinControls.UI.RadTextBox()
        Me.txtMotheJop = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel25 = New Telerik.WinControls.UI.RadLabel()
        Me.txtMothName = New Telerik.WinControls.UI.RadTextBox()
        Me.chkEnableMother = New Telerik.WinControls.UI.RadCheckBox()
        Me.pgeBondsMan = New Telerik.WinControls.UI.RadPageViewPage()
        Me.numBondsID = New Telerik.WinControls.UI.RadSpinEditor()
        Me.RadLabel28 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel29 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel33 = New Telerik.WinControls.UI.RadLabel()
        Me.txtBondsAddre = New Telerik.WinControls.UI.RadTextBox()
        Me.txtBondsJop = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel34 = New Telerik.WinControls.UI.RadLabel()
        Me.txtBondsName = New Telerik.WinControls.UI.RadTextBox()
        Me.chkEnableBondsMan = New Telerik.WinControls.UI.RadCheckBox()
        Me.SplitPanel2 = New Telerik.WinControls.UI.SplitPanel()
        Me.Radgrid = New Telerik.WinControls.UI.RadGridView()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadSplitContainer1.SuspendLayout()
        CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel1.SuspendLayout()
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageView1.SuspendLayout()
        Me.pgeOrphan.SuspendLayout()
        CType(Me.chkEnableOrph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrphSex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numOrphKaid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numOrphAge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOrphIsSick, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOrphHasBodyPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOrphHasFacePhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOrphIsBaild, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOrphEnabledBirthday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpOrphDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOrphDate.SuspendLayout()
        CType(Me.dteOrphTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteOrphFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrphBirthPlace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrphNAme, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgeFather.SuspendLayout()
        CType(Me.numFathId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFathAge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkFathEnabledDieDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpFathDieDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFathDieDate.SuspendLayout()
        CType(Me.dteFathTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteFathFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFathDeathRe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFatheJop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFathName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkEnableFath, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgeMother.SuspendLayout()
        CType(Me.numMothId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMothAge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMothEnabledBirth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMothIsDead, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMothIsMarried, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpMothBirth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMothBirth.SuspendLayout()
        CType(Me.dteMothTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteMothFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMothAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMotheJop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMothName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkEnableMother, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgeBondsMan.SuspendLayout()
        CType(Me.numBondsID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBondsAddre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBondsJop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBondsName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkEnableBondsMan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel2.SuspendLayout()
        CType(Me.Radgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Radgrid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.RadStatusStrip1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.RadSplitContainer1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(615, 377)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnSearch, Me.btnShow, Me.btnStop, Me.CommandBarSeparator1, Me.lblState, Me.radWatingBar})
        Me.RadStatusStrip1.Location = New System.Drawing.Point(3, 352)
        Me.RadStatusStrip1.Name = "RadStatusStrip1"
        Me.RadStatusStrip1.Size = New System.Drawing.Size(609, 22)
        Me.RadStatusStrip1.TabIndex = 1
        '
        'btnSearch
        '
        Me.btnSearch.AccessibleDescription = "بحث"
        Me.btnSearch.AccessibleName = "بحث"
        Me.btnSearch.Name = "btnSearch"
        Me.RadStatusStrip1.SetSpring(Me.btnSearch, True)
        Me.btnSearch.Text = "بحث"
        Me.btnSearch.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnShow
        '
        Me.btnShow.AccessibleDescription = "عرض"
        Me.btnShow.AccessibleName = "عرض"
        Me.btnShow.Enabled = False
        Me.btnShow.Name = "btnShow"
        Me.RadStatusStrip1.SetSpring(Me.btnShow, True)
        Me.btnShow.Text = "عرض"
        Me.btnShow.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnStop
        '
        Me.btnStop.AccessibleDescription = "توقف"
        Me.btnStop.AccessibleName = "توقف"
        Me.btnStop.Name = "btnStop"
        Me.RadStatusStrip1.SetSpring(Me.btnStop, True)
        Me.btnStop.Text = "توقف"
        Me.btnStop.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        '
        'CommandBarSeparator1
        '
        Me.CommandBarSeparator1.AccessibleDescription = "CommandBarSeparator1"
        Me.CommandBarSeparator1.AccessibleName = "CommandBarSeparator1"
        Me.CommandBarSeparator1.Name = "CommandBarSeparator1"
        Me.RadStatusStrip1.SetSpring(Me.CommandBarSeparator1, False)
        Me.CommandBarSeparator1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.CommandBarSeparator1.VisibleInOverflowMenu = False
        '
        'lblState
        '
        Me.lblState.AccessibleDescription = "RadLabelElement1"
        Me.lblState.AccessibleName = "RadLabelElement1"
        Me.lblState.Name = "lblState"
        Me.RadStatusStrip1.SetSpring(Me.lblState, True)
        Me.lblState.Text = ""
        Me.lblState.TextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.lblState.TextWrap = True
        Me.lblState.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'radWatingBar
        '
        Me.radWatingBar.AutoSize = False
        Me.radWatingBar.Bounds = New System.Drawing.Rectangle(0, 0, 100, 18)
        Me.radWatingBar.Name = "radWatingBar"
        Me.radWatingBar.ShouldPaint = False
        Me.RadStatusStrip1.SetSpring(Me.radWatingBar, True)
        Me.radWatingBar.StretchHorizontally = True
        Me.radWatingBar.StretchIndicatorsHorizontally = True
        Me.radWatingBar.Text = ""
        Me.radWatingBar.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        '
        'RadSplitContainer1
        '
        Me.RadSplitContainer1.Controls.Add(Me.SplitPanel1)
        Me.RadSplitContainer1.Controls.Add(Me.SplitPanel2)
        Me.RadSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadSplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.RadSplitContainer1.Name = "RadSplitContainer1"
        Me.RadSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        '
        '
        Me.RadSplitContainer1.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.RadSplitContainer1.Size = New System.Drawing.Size(615, 349)
        Me.RadSplitContainer1.SplitterWidth = 4
        Me.RadSplitContainer1.TabIndex = 2
        Me.RadSplitContainer1.TabStop = False
        Me.RadSplitContainer1.Text = "RadSplitContainer1"
        '
        'SplitPanel1
        '
        Me.SplitPanel1.Controls.Add(Me.RadPageView1)
        Me.SplitPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SplitPanel1.Name = "SplitPanel1"
        '
        '
        '
        Me.SplitPanel1.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitPanel1.Size = New System.Drawing.Size(615, 200)
        Me.SplitPanel1.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.0!, 0.07971015!)
        Me.SplitPanel1.SizeInfo.SplitterCorrection = New System.Drawing.Size(0, 23)
        Me.SplitPanel1.TabIndex = 0
        Me.SplitPanel1.TabStop = False
        Me.SplitPanel1.Text = "SplitPanel1"
        '
        'RadPageView1
        '
        Me.RadPageView1.Controls.Add(Me.pgeOrphan)
        Me.RadPageView1.Controls.Add(Me.pgeFather)
        Me.RadPageView1.Controls.Add(Me.pgeMother)
        Me.RadPageView1.Controls.Add(Me.pgeBondsMan)
        Me.RadPageView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadPageView1.Location = New System.Drawing.Point(0, 0)
        Me.RadPageView1.MinimumSize = New System.Drawing.Size(615, 202)
        Me.RadPageView1.Name = "RadPageView1"
        '
        '
        '
        Me.RadPageView1.RootElement.MinSize = New System.Drawing.Size(615, 202)
        Me.RadPageView1.SelectedPage = Me.pgeOrphan
        Me.RadPageView1.Size = New System.Drawing.Size(615, 202)
        Me.RadPageView1.TabIndex = 0
        Me.RadPageView1.Text = "يتيم"
        CType(Me.RadPageView1.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.None
        CType(Me.RadPageView1.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ItemAlignment = Telerik.WinControls.UI.StripViewItemAlignment.Near
        CType(Me.RadPageView1.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.Fill
        CType(Me.RadPageView1.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Top
        '
        'pgeOrphan
        '
        Me.pgeOrphan.Controls.Add(Me.chkEnableOrph)
        Me.pgeOrphan.Controls.Add(Me.txtOrphSex)
        Me.pgeOrphan.Controls.Add(Me.numOrphKaid)
        Me.pgeOrphan.Controls.Add(Me.numOrphAge)
        Me.pgeOrphan.Controls.Add(Me.RadLabel8)
        Me.pgeOrphan.Controls.Add(Me.RadLabel27)
        Me.pgeOrphan.Controls.Add(Me.RadLabel26)
        Me.pgeOrphan.Controls.Add(Me.RadLabel5)
        Me.pgeOrphan.Controls.Add(Me.RadLabel9)
        Me.pgeOrphan.Controls.Add(Me.RadLabel7)
        Me.pgeOrphan.Controls.Add(Me.chkOrphIsSick)
        Me.pgeOrphan.Controls.Add(Me.RadLabel4)
        Me.pgeOrphan.Controls.Add(Me.chkOrphHasBodyPhoto)
        Me.pgeOrphan.Controls.Add(Me.chkOrphHasFacePhoto)
        Me.pgeOrphan.Controls.Add(Me.chkOrphIsBaild)
        Me.pgeOrphan.Controls.Add(Me.chkOrphEnabledBirthday)
        Me.pgeOrphan.Controls.Add(Me.grpOrphDate)
        Me.pgeOrphan.Controls.Add(Me.RadLabel6)
        Me.pgeOrphan.Controls.Add(Me.txtOrphBirthPlace)
        Me.pgeOrphan.Controls.Add(Me.RadLabel1)
        Me.pgeOrphan.Controls.Add(Me.txtOrphNAme)
        Me.pgeOrphan.Location = New System.Drawing.Point(10, 37)
        Me.pgeOrphan.Name = "pgeOrphan"
        Me.pgeOrphan.Size = New System.Drawing.Size(594, 154)
        Me.pgeOrphan.Text = "يتيم"
        '
        'chkEnableOrph
        '
        Me.chkEnableOrph.Location = New System.Drawing.Point(3, 0)
        Me.chkEnableOrph.Name = "chkEnableOrph"
        Me.chkEnableOrph.Size = New System.Drawing.Size(48, 18)
        Me.chkEnableOrph.TabIndex = 11
        Me.chkEnableOrph.Text = "تفعيل"
        Me.chkEnableOrph.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'txtOrphSex
        '
        Me.txtOrphSex.DefaultItemsCountInDropDown = 3
        Me.txtOrphSex.DropDownHeight = 60
        DescriptionTextListDataItem1.Text = "غير محدد"
        DescriptionTextListDataItem1.TextWrap = True
        DescriptionTextListDataItem2.Text = "ذكر"
        DescriptionTextListDataItem2.TextWrap = True
        DescriptionTextListDataItem3.Text = "انثى"
        DescriptionTextListDataItem3.TextWrap = True
        Me.txtOrphSex.Items.Add(DescriptionTextListDataItem1)
        Me.txtOrphSex.Items.Add(DescriptionTextListDataItem2)
        Me.txtOrphSex.Items.Add(DescriptionTextListDataItem3)
        Me.txtOrphSex.Location = New System.Drawing.Point(174, 36)
        Me.txtOrphSex.Name = "txtOrphSex"
        Me.txtOrphSex.SelectNextOnDoubleClick = True
        Me.txtOrphSex.Size = New System.Drawing.Size(138, 20)
        Me.txtOrphSex.TabIndex = 7
        Me.txtOrphSex.Text = "غير محدد"
        '
        'numOrphKaid
        '
        Me.numOrphKaid.Location = New System.Drawing.Point(174, 65)
        Me.numOrphKaid.Name = "numOrphKaid"
        Me.numOrphKaid.Size = New System.Drawing.Size(138, 20)
        Me.numOrphKaid.TabIndex = 8
        Me.numOrphKaid.TabStop = False
        '
        'numOrphAge
        '
        Me.numOrphAge.Location = New System.Drawing.Point(406, 115)
        Me.numOrphAge.Name = "numOrphAge"
        Me.numOrphAge.Size = New System.Drawing.Size(138, 20)
        Me.numOrphAge.TabIndex = 5
        Me.numOrphAge.TabStop = False
        '
        'RadLabel8
        '
        Me.RadLabel8.Location = New System.Drawing.Point(318, 116)
        Me.RadLabel8.Name = "RadLabel8"
        Me.RadLabel8.Size = New System.Drawing.Size(40, 18)
        Me.RadLabel8.TabIndex = 5
        Me.RadLabel8.Text = "مريض:"
        Me.RadLabel8.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel27
        '
        Me.RadLabel27.Location = New System.Drawing.Point(195, 116)
        Me.RadLabel27.Name = "RadLabel27"
        Me.RadLabel27.Size = New System.Drawing.Size(63, 18)
        Me.RadLabel27.TabIndex = 5
        Me.RadLabel27.Text = "صورة كاملة:"
        Me.RadLabel27.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel26
        '
        Me.RadLabel26.Location = New System.Drawing.Point(195, 91)
        Me.RadLabel26.Name = "RadLabel26"
        Me.RadLabel26.Size = New System.Drawing.Size(56, 18)
        Me.RadLabel26.TabIndex = 5
        Me.RadLabel26.Text = "صورة وجه:"
        Me.RadLabel26.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel5
        '
        Me.RadLabel5.Location = New System.Drawing.Point(318, 91)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(40, 18)
        Me.RadLabel5.TabIndex = 5
        Me.RadLabel5.Text = "مكفول:"
        Me.RadLabel5.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel9
        '
        Me.RadLabel9.Location = New System.Drawing.Point(318, 62)
        Me.RadLabel9.Name = "RadLabel9"
        Me.RadLabel9.Size = New System.Drawing.Size(50, 18)
        Me.RadLabel9.TabIndex = 5
        Me.RadLabel9.Text = "رقم القيد:"
        Me.RadLabel9.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel7
        '
        Me.RadLabel7.Location = New System.Drawing.Point(318, 35)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(39, 18)
        Me.RadLabel7.TabIndex = 5
        Me.RadLabel7.Text = "الجنس:"
        Me.RadLabel7.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'chkOrphIsSick
        '
        Me.chkOrphIsSick.IsThreeState = True
        Me.chkOrphIsSick.Location = New System.Drawing.Point(297, 119)
        Me.chkOrphIsSick.Name = "chkOrphIsSick"
        Me.chkOrphIsSick.Size = New System.Drawing.Size(15, 15)
        Me.chkOrphIsSick.TabIndex = 10
        Me.chkOrphIsSick.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Indeterminate
        '
        'RadLabel4
        '
        Me.RadLabel4.Location = New System.Drawing.Point(550, 117)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(33, 18)
        Me.RadLabel4.TabIndex = 5
        Me.RadLabel4.Text = "العمر:"
        Me.RadLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'chkOrphHasBodyPhoto
        '
        Me.chkOrphHasBodyPhoto.IsThreeState = True
        Me.chkOrphHasBodyPhoto.Location = New System.Drawing.Point(174, 119)
        Me.chkOrphHasBodyPhoto.Name = "chkOrphHasBodyPhoto"
        Me.chkOrphHasBodyPhoto.Size = New System.Drawing.Size(15, 15)
        Me.chkOrphHasBodyPhoto.TabIndex = 9
        Me.chkOrphHasBodyPhoto.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Indeterminate
        '
        'chkOrphHasFacePhoto
        '
        Me.chkOrphHasFacePhoto.IsThreeState = True
        Me.chkOrphHasFacePhoto.Location = New System.Drawing.Point(174, 94)
        Me.chkOrphHasFacePhoto.Name = "chkOrphHasFacePhoto"
        Me.chkOrphHasFacePhoto.Size = New System.Drawing.Size(15, 15)
        Me.chkOrphHasFacePhoto.TabIndex = 9
        Me.chkOrphHasFacePhoto.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Indeterminate
        '
        'chkOrphIsBaild
        '
        Me.chkOrphIsBaild.IsThreeState = True
        Me.chkOrphIsBaild.Location = New System.Drawing.Point(297, 94)
        Me.chkOrphIsBaild.Name = "chkOrphIsBaild"
        Me.chkOrphIsBaild.Size = New System.Drawing.Size(15, 15)
        Me.chkOrphIsBaild.TabIndex = 9
        Me.chkOrphIsBaild.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Indeterminate
        '
        'chkOrphEnabledBirthday
        '
        Me.chkOrphEnabledBirthday.Location = New System.Drawing.Point(506, 32)
        Me.chkOrphEnabledBirthday.Name = "chkOrphEnabledBirthday"
        Me.chkOrphEnabledBirthday.Size = New System.Drawing.Size(15, 15)
        Me.chkOrphEnabledBirthday.TabIndex = 2
        '
        'grpOrphDate
        '
        Me.grpOrphDate.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grpOrphDate.Controls.Add(Me.dteOrphTo)
        Me.grpOrphDate.Controls.Add(Me.dteOrphFrom)
        Me.grpOrphDate.Controls.Add(Me.RadLabel3)
        Me.grpOrphDate.Controls.Add(Me.RadLabel2)
        Me.grpOrphDate.Enabled = False
        Me.grpOrphDate.HeaderText = "تاريخ الولادة"
        Me.grpOrphDate.Location = New System.Drawing.Point(406, 32)
        Me.grpOrphDate.Name = "grpOrphDate"
        Me.grpOrphDate.Size = New System.Drawing.Size(185, 76)
        Me.grpOrphDate.TabIndex = 2
        Me.grpOrphDate.Text = "تاريخ الولادة"
        '
        'dteOrphTo
        '
        Me.dteOrphTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteOrphTo.Location = New System.Drawing.Point(15, 44)
        Me.dteOrphTo.Name = "dteOrphTo"
        Me.dteOrphTo.Size = New System.Drawing.Size(123, 20)
        Me.dteOrphTo.TabIndex = 4
        Me.dteOrphTo.TabStop = False
        Me.dteOrphTo.Text = "25-Jan-15"
        Me.dteOrphTo.Value = New Date(2015, 1, 25, 21, 0, 0, 656)
        '
        'dteOrphFrom
        '
        Me.dteOrphFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteOrphFrom.Location = New System.Drawing.Point(15, 20)
        Me.dteOrphFrom.Name = "dteOrphFrom"
        Me.dteOrphFrom.Size = New System.Drawing.Size(123, 20)
        Me.dteOrphFrom.TabIndex = 3
        Me.dteOrphFrom.TabStop = False
        Me.dteOrphFrom.Text = "25-Jan-15"
        Me.dteOrphFrom.Value = New Date(2015, 1, 25, 21, 0, 0, 656)
        '
        'RadLabel3
        '
        Me.RadLabel3.Location = New System.Drawing.Point(144, 44)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(25, 18)
        Me.RadLabel3.TabIndex = 1
        Me.RadLabel3.Text = "إلى:"
        Me.RadLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel2
        '
        Me.RadLabel2.Location = New System.Drawing.Point(144, 20)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(23, 18)
        Me.RadLabel2.TabIndex = 1
        Me.RadLabel2.Text = "من:"
        Me.RadLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel6
        '
        Me.RadLabel6.Location = New System.Drawing.Point(318, 8)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(65, 18)
        Me.RadLabel6.TabIndex = 1
        Me.RadLabel6.Text = "مكان الولادة:"
        Me.RadLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'txtOrphBirthPlace
        '
        Me.txtOrphBirthPlace.Location = New System.Drawing.Point(174, 7)
        Me.txtOrphBirthPlace.Name = "txtOrphBirthPlace"
        Me.txtOrphBirthPlace.Size = New System.Drawing.Size(138, 20)
        Me.txtOrphBirthPlace.TabIndex = 6
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(550, 8)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(34, 18)
        Me.RadLabel1.TabIndex = 1
        Me.RadLabel1.Text = "الاسم:"
        Me.RadLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'txtOrphNAme
        '
        Me.txtOrphNAme.Location = New System.Drawing.Point(406, 7)
        Me.txtOrphNAme.Name = "txtOrphNAme"
        Me.txtOrphNAme.Size = New System.Drawing.Size(138, 20)
        Me.txtOrphNAme.TabIndex = 1
        '
        'pgeFather
        '
        Me.pgeFather.Controls.Add(Me.numFathId)
        Me.pgeFather.Controls.Add(Me.numFathAge)
        Me.pgeFather.Controls.Add(Me.RadLabel12)
        Me.pgeFather.Controls.Add(Me.RadLabel13)
        Me.pgeFather.Controls.Add(Me.chkFathEnabledDieDate)
        Me.pgeFather.Controls.Add(Me.RadLabel14)
        Me.pgeFather.Controls.Add(Me.grpFathDieDate)
        Me.pgeFather.Controls.Add(Me.RadLabel17)
        Me.pgeFather.Controls.Add(Me.txtFathDeathRe)
        Me.pgeFather.Controls.Add(Me.txtFatheJop)
        Me.pgeFather.Controls.Add(Me.RadLabel18)
        Me.pgeFather.Controls.Add(Me.txtFathName)
        Me.pgeFather.Controls.Add(Me.chkEnableFath)
        Me.pgeFather.Location = New System.Drawing.Point(10, 37)
        Me.pgeFather.Name = "pgeFather"
        Me.pgeFather.Size = New System.Drawing.Size(594, 154)
        Me.pgeFather.Text = "متوفى"
        '
        'numFathId
        '
        Me.numFathId.Enabled = False
        Me.numFathId.Location = New System.Drawing.Point(174, 115)
        Me.numFathId.Name = "numFathId"
        Me.numFathId.Size = New System.Drawing.Size(138, 20)
        Me.numFathId.TabIndex = 28
        Me.numFathId.TabStop = False
        '
        'numFathAge
        '
        Me.numFathAge.Enabled = False
        Me.numFathAge.Location = New System.Drawing.Point(406, 115)
        Me.numFathAge.Name = "numFathAge"
        Me.numFathAge.Size = New System.Drawing.Size(138, 20)
        Me.numFathAge.TabIndex = 25
        Me.numFathAge.TabStop = False
        Me.numFathAge.Visible = False
        '
        'RadLabel12
        '
        Me.RadLabel12.Location = New System.Drawing.Point(318, 116)
        Me.RadLabel12.Name = "RadLabel12"
        Me.RadLabel12.Size = New System.Drawing.Size(56, 18)
        Me.RadLabel12.TabIndex = 18
        Me.RadLabel12.Text = "رقم الهوية:"
        Me.RadLabel12.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel13
        '
        Me.RadLabel13.Location = New System.Drawing.Point(318, 62)
        Me.RadLabel13.Name = "RadLabel13"
        Me.RadLabel13.Size = New System.Drawing.Size(62, 18)
        Me.RadLabel13.TabIndex = 20
        Me.RadLabel13.Text = "سبب الوفاة:"
        Me.RadLabel13.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'chkFathEnabledDieDate
        '
        Me.chkFathEnabledDieDate.Enabled = False
        Me.chkFathEnabledDieDate.Location = New System.Drawing.Point(510, 32)
        Me.chkFathEnabledDieDate.Name = "chkFathEnabledDieDate"
        Me.chkFathEnabledDieDate.Size = New System.Drawing.Size(15, 15)
        Me.chkFathEnabledDieDate.TabIndex = 22
        '
        'RadLabel14
        '
        Me.RadLabel14.Enabled = False
        Me.RadLabel14.Location = New System.Drawing.Point(550, 117)
        Me.RadLabel14.Name = "RadLabel14"
        Me.RadLabel14.Size = New System.Drawing.Size(33, 18)
        Me.RadLabel14.TabIndex = 19
        Me.RadLabel14.Text = "العمر:"
        Me.RadLabel14.TextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.RadLabel14.Visible = False
        '
        'grpFathDieDate
        '
        Me.grpFathDieDate.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grpFathDieDate.Controls.Add(Me.dteFathTo)
        Me.grpFathDieDate.Controls.Add(Me.dteFathFrom)
        Me.grpFathDieDate.Controls.Add(Me.RadLabel15)
        Me.grpFathDieDate.Controls.Add(Me.RadLabel16)
        Me.grpFathDieDate.Enabled = False
        Me.grpFathDieDate.HeaderText = "تاريخ الوفاة"
        Me.grpFathDieDate.Location = New System.Drawing.Point(406, 32)
        Me.grpFathDieDate.Name = "grpFathDieDate"
        Me.grpFathDieDate.Size = New System.Drawing.Size(185, 76)
        Me.grpFathDieDate.TabIndex = 12
        Me.grpFathDieDate.Text = "تاريخ الوفاة"
        '
        'dteFathTo
        '
        Me.dteFathTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteFathTo.Location = New System.Drawing.Point(15, 44)
        Me.dteFathTo.Name = "dteFathTo"
        Me.dteFathTo.Size = New System.Drawing.Size(123, 20)
        Me.dteFathTo.TabIndex = 24
        Me.dteFathTo.TabStop = False
        Me.dteFathTo.Text = "25-Jan-15"
        Me.dteFathTo.Value = New Date(2015, 1, 25, 21, 0, 0, 656)
        '
        'dteFathFrom
        '
        Me.dteFathFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteFathFrom.Location = New System.Drawing.Point(15, 20)
        Me.dteFathFrom.Name = "dteFathFrom"
        Me.dteFathFrom.Size = New System.Drawing.Size(123, 20)
        Me.dteFathFrom.TabIndex = 23
        Me.dteFathFrom.TabStop = False
        Me.dteFathFrom.Text = "25-Jan-15"
        Me.dteFathFrom.Value = New Date(2015, 1, 25, 21, 0, 0, 656)
        '
        'RadLabel15
        '
        Me.RadLabel15.Location = New System.Drawing.Point(144, 44)
        Me.RadLabel15.Name = "RadLabel15"
        Me.RadLabel15.Size = New System.Drawing.Size(25, 18)
        Me.RadLabel15.TabIndex = 1
        Me.RadLabel15.Text = "إلى:"
        Me.RadLabel15.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel16
        '
        Me.RadLabel16.Location = New System.Drawing.Point(144, 20)
        Me.RadLabel16.Name = "RadLabel16"
        Me.RadLabel16.Size = New System.Drawing.Size(23, 18)
        Me.RadLabel16.TabIndex = 1
        Me.RadLabel16.Text = "من:"
        Me.RadLabel16.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel17
        '
        Me.RadLabel17.Location = New System.Drawing.Point(318, 8)
        Me.RadLabel17.Name = "RadLabel17"
        Me.RadLabel17.Size = New System.Drawing.Size(36, 18)
        Me.RadLabel17.TabIndex = 10
        Me.RadLabel17.Text = "العمل:"
        Me.RadLabel17.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'txtFathDeathRe
        '
        Me.txtFathDeathRe.Enabled = False
        Me.txtFathDeathRe.Location = New System.Drawing.Point(174, 61)
        Me.txtFathDeathRe.Name = "txtFathDeathRe"
        Me.txtFathDeathRe.Size = New System.Drawing.Size(138, 20)
        Me.txtFathDeathRe.TabIndex = 27
        '
        'txtFatheJop
        '
        Me.txtFatheJop.Enabled = False
        Me.txtFatheJop.Location = New System.Drawing.Point(174, 7)
        Me.txtFatheJop.Name = "txtFatheJop"
        Me.txtFatheJop.Size = New System.Drawing.Size(138, 20)
        Me.txtFatheJop.TabIndex = 26
        '
        'RadLabel18
        '
        Me.RadLabel18.Location = New System.Drawing.Point(550, 8)
        Me.RadLabel18.Name = "RadLabel18"
        Me.RadLabel18.Size = New System.Drawing.Size(34, 18)
        Me.RadLabel18.TabIndex = 11
        Me.RadLabel18.Text = "الاسم:"
        Me.RadLabel18.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'txtFathName
        '
        Me.txtFathName.Enabled = False
        Me.txtFathName.Location = New System.Drawing.Point(406, 7)
        Me.txtFathName.Name = "txtFathName"
        Me.txtFathName.Size = New System.Drawing.Size(138, 20)
        Me.txtFathName.TabIndex = 21
        '
        'chkEnableFath
        '
        Me.chkEnableFath.Location = New System.Drawing.Point(4, 0)
        Me.chkEnableFath.Name = "chkEnableFath"
        Me.chkEnableFath.Size = New System.Drawing.Size(48, 18)
        Me.chkEnableFath.TabIndex = 20
        Me.chkEnableFath.Text = "تفعيل"
        '
        'pgeMother
        '
        Me.pgeMother.Controls.Add(Me.numMothId)
        Me.pgeMother.Controls.Add(Me.numMothAge)
        Me.pgeMother.Controls.Add(Me.RadLabel10)
        Me.pgeMother.Controls.Add(Me.RadLabel11)
        Me.pgeMother.Controls.Add(Me.chkMothEnabledBirth)
        Me.pgeMother.Controls.Add(Me.RadLabel19)
        Me.pgeMother.Controls.Add(Me.RadLabel20)
        Me.pgeMother.Controls.Add(Me.chkMothIsDead)
        Me.pgeMother.Controls.Add(Me.RadLabel21)
        Me.pgeMother.Controls.Add(Me.chkMothIsMarried)
        Me.pgeMother.Controls.Add(Me.grpMothBirth)
        Me.pgeMother.Controls.Add(Me.RadLabel24)
        Me.pgeMother.Controls.Add(Me.txtMothAdd)
        Me.pgeMother.Controls.Add(Me.txtMotheJop)
        Me.pgeMother.Controls.Add(Me.RadLabel25)
        Me.pgeMother.Controls.Add(Me.txtMothName)
        Me.pgeMother.Controls.Add(Me.chkEnableMother)
        Me.pgeMother.Location = New System.Drawing.Point(10, 37)
        Me.pgeMother.Name = "pgeMother"
        Me.pgeMother.Size = New System.Drawing.Size(594, 154)
        Me.pgeMother.Text = "أم"
        '
        'numMothId
        '
        Me.numMothId.Enabled = False
        Me.numMothId.Location = New System.Drawing.Point(174, 63)
        Me.numMothId.Name = "numMothId"
        Me.numMothId.Size = New System.Drawing.Size(138, 20)
        Me.numMothId.TabIndex = 38
        Me.numMothId.TabStop = False
        '
        'numMothAge
        '
        Me.numMothAge.Enabled = False
        Me.numMothAge.Location = New System.Drawing.Point(406, 115)
        Me.numMothAge.Name = "numMothAge"
        Me.numMothAge.Size = New System.Drawing.Size(138, 20)
        Me.numMothAge.TabIndex = 35
        Me.numMothAge.TabStop = False
        Me.numMothAge.Visible = False
        '
        'RadLabel10
        '
        Me.RadLabel10.Location = New System.Drawing.Point(318, 112)
        Me.RadLabel10.Name = "RadLabel10"
        Me.RadLabel10.Size = New System.Drawing.Size(40, 18)
        Me.RadLabel10.TabIndex = 17
        Me.RadLabel10.Text = "متوفية:"
        Me.RadLabel10.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel11
        '
        Me.RadLabel11.Location = New System.Drawing.Point(318, 86)
        Me.RadLabel11.Name = "RadLabel11"
        Me.RadLabel11.Size = New System.Drawing.Size(41, 18)
        Me.RadLabel11.TabIndex = 16
        Me.RadLabel11.Text = "متزوجة:"
        Me.RadLabel11.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'chkMothEnabledBirth
        '
        Me.chkMothEnabledBirth.Enabled = False
        Me.chkMothEnabledBirth.Location = New System.Drawing.Point(506, 32)
        Me.chkMothEnabledBirth.Name = "chkMothEnabledBirth"
        Me.chkMothEnabledBirth.Size = New System.Drawing.Size(15, 15)
        Me.chkMothEnabledBirth.TabIndex = 32
        '
        'RadLabel19
        '
        Me.RadLabel19.Location = New System.Drawing.Point(318, 60)
        Me.RadLabel19.Name = "RadLabel19"
        Me.RadLabel19.Size = New System.Drawing.Size(56, 18)
        Me.RadLabel19.TabIndex = 18
        Me.RadLabel19.Text = "رقم الهوية:"
        Me.RadLabel19.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel20
        '
        Me.RadLabel20.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel20.Location = New System.Drawing.Point(318, 34)
        Me.RadLabel20.Name = "RadLabel20"
        Me.RadLabel20.Size = New System.Drawing.Size(42, 18)
        Me.RadLabel20.TabIndex = 20
        Me.RadLabel20.Text = "العنوان:"
        Me.RadLabel20.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'chkMothIsDead
        '
        Me.chkMothIsDead.Enabled = False
        Me.chkMothIsDead.IsThreeState = True
        Me.chkMothIsDead.Location = New System.Drawing.Point(297, 114)
        Me.chkMothIsDead.Name = "chkMothIsDead"
        Me.chkMothIsDead.Size = New System.Drawing.Size(15, 15)
        Me.chkMothIsDead.TabIndex = 40
        Me.chkMothIsDead.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Indeterminate
        '
        'RadLabel21
        '
        Me.RadLabel21.Location = New System.Drawing.Point(550, 117)
        Me.RadLabel21.Name = "RadLabel21"
        Me.RadLabel21.Size = New System.Drawing.Size(33, 18)
        Me.RadLabel21.TabIndex = 19
        Me.RadLabel21.Text = "العمر:"
        Me.RadLabel21.TextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.RadLabel21.Visible = False
        '
        'chkMothIsMarried
        '
        Me.chkMothIsMarried.Enabled = False
        Me.chkMothIsMarried.IsThreeState = True
        Me.chkMothIsMarried.Location = New System.Drawing.Point(297, 91)
        Me.chkMothIsMarried.Name = "chkMothIsMarried"
        Me.chkMothIsMarried.Size = New System.Drawing.Size(15, 15)
        Me.chkMothIsMarried.TabIndex = 39
        Me.chkMothIsMarried.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Indeterminate
        '
        'grpMothBirth
        '
        Me.grpMothBirth.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grpMothBirth.Controls.Add(Me.dteMothTo)
        Me.grpMothBirth.Controls.Add(Me.dteMothFrom)
        Me.grpMothBirth.Controls.Add(Me.RadLabel22)
        Me.grpMothBirth.Controls.Add(Me.RadLabel23)
        Me.grpMothBirth.Enabled = False
        Me.grpMothBirth.HeaderText = "تاريخ الولادة"
        Me.grpMothBirth.Location = New System.Drawing.Point(406, 32)
        Me.grpMothBirth.Name = "grpMothBirth"
        Me.grpMothBirth.Size = New System.Drawing.Size(185, 76)
        Me.grpMothBirth.TabIndex = 12
        Me.grpMothBirth.Text = "تاريخ الولادة"
        '
        'dteMothTo
        '
        Me.dteMothTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteMothTo.Location = New System.Drawing.Point(15, 44)
        Me.dteMothTo.Name = "dteMothTo"
        Me.dteMothTo.Size = New System.Drawing.Size(123, 20)
        Me.dteMothTo.TabIndex = 34
        Me.dteMothTo.TabStop = False
        Me.dteMothTo.Text = "25-Jan-15"
        Me.dteMothTo.Value = New Date(2015, 1, 25, 21, 0, 0, 656)
        '
        'dteMothFrom
        '
        Me.dteMothFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteMothFrom.Location = New System.Drawing.Point(15, 20)
        Me.dteMothFrom.Name = "dteMothFrom"
        Me.dteMothFrom.Size = New System.Drawing.Size(123, 20)
        Me.dteMothFrom.TabIndex = 33
        Me.dteMothFrom.TabStop = False
        Me.dteMothFrom.Text = "25-Jan-15"
        Me.dteMothFrom.Value = New Date(2015, 1, 25, 21, 0, 0, 656)
        '
        'RadLabel22
        '
        Me.RadLabel22.Location = New System.Drawing.Point(144, 44)
        Me.RadLabel22.Name = "RadLabel22"
        Me.RadLabel22.Size = New System.Drawing.Size(25, 18)
        Me.RadLabel22.TabIndex = 1
        Me.RadLabel22.Text = "إلى:"
        Me.RadLabel22.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel23
        '
        Me.RadLabel23.Location = New System.Drawing.Point(144, 20)
        Me.RadLabel23.Name = "RadLabel23"
        Me.RadLabel23.Size = New System.Drawing.Size(23, 18)
        Me.RadLabel23.TabIndex = 1
        Me.RadLabel23.Text = "من:"
        Me.RadLabel23.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel24
        '
        Me.RadLabel24.Location = New System.Drawing.Point(318, 8)
        Me.RadLabel24.Name = "RadLabel24"
        Me.RadLabel24.Size = New System.Drawing.Size(36, 18)
        Me.RadLabel24.TabIndex = 10
        Me.RadLabel24.Text = "العمل:"
        Me.RadLabel24.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'txtMothAdd
        '
        Me.txtMothAdd.Enabled = False
        Me.txtMothAdd.Location = New System.Drawing.Point(174, 35)
        Me.txtMothAdd.Name = "txtMothAdd"
        Me.txtMothAdd.Size = New System.Drawing.Size(138, 20)
        Me.txtMothAdd.TabIndex = 37
        '
        'txtMotheJop
        '
        Me.txtMotheJop.Enabled = False
        Me.txtMotheJop.Location = New System.Drawing.Point(174, 7)
        Me.txtMotheJop.Name = "txtMotheJop"
        Me.txtMotheJop.Size = New System.Drawing.Size(138, 20)
        Me.txtMotheJop.TabIndex = 36
        '
        'RadLabel25
        '
        Me.RadLabel25.Location = New System.Drawing.Point(550, 8)
        Me.RadLabel25.Name = "RadLabel25"
        Me.RadLabel25.Size = New System.Drawing.Size(34, 18)
        Me.RadLabel25.TabIndex = 11
        Me.RadLabel25.Text = "الاسم:"
        Me.RadLabel25.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'txtMothName
        '
        Me.txtMothName.Enabled = False
        Me.txtMothName.Location = New System.Drawing.Point(406, 7)
        Me.txtMothName.Name = "txtMothName"
        Me.txtMothName.Size = New System.Drawing.Size(138, 20)
        Me.txtMothName.TabIndex = 31
        '
        'chkEnableMother
        '
        Me.chkEnableMother.Location = New System.Drawing.Point(4, 0)
        Me.chkEnableMother.Name = "chkEnableMother"
        Me.chkEnableMother.Size = New System.Drawing.Size(48, 18)
        Me.chkEnableMother.TabIndex = 30
        Me.chkEnableMother.Text = "تفعيل"
        '
        'pgeBondsMan
        '
        Me.pgeBondsMan.Controls.Add(Me.numBondsID)
        Me.pgeBondsMan.Controls.Add(Me.RadLabel28)
        Me.pgeBondsMan.Controls.Add(Me.RadLabel29)
        Me.pgeBondsMan.Controls.Add(Me.RadLabel33)
        Me.pgeBondsMan.Controls.Add(Me.txtBondsAddre)
        Me.pgeBondsMan.Controls.Add(Me.txtBondsJop)
        Me.pgeBondsMan.Controls.Add(Me.RadLabel34)
        Me.pgeBondsMan.Controls.Add(Me.txtBondsName)
        Me.pgeBondsMan.Controls.Add(Me.chkEnableBondsMan)
        Me.pgeBondsMan.Location = New System.Drawing.Point(10, 37)
        Me.pgeBondsMan.Name = "pgeBondsMan"
        Me.pgeBondsMan.Size = New System.Drawing.Size(594, 154)
        Me.pgeBondsMan.Text = "معيل"
        '
        'numBondsID
        '
        Me.numBondsID.Enabled = False
        Me.numBondsID.Location = New System.Drawing.Point(394, 98)
        Me.numBondsID.Name = "numBondsID"
        Me.numBondsID.Size = New System.Drawing.Size(138, 20)
        Me.numBondsID.TabIndex = 54
        Me.numBondsID.TabStop = False
        '
        'RadLabel28
        '
        Me.RadLabel28.Location = New System.Drawing.Point(538, 98)
        Me.RadLabel28.Name = "RadLabel28"
        Me.RadLabel28.Size = New System.Drawing.Size(56, 18)
        Me.RadLabel28.TabIndex = 33
        Me.RadLabel28.Text = "رقم الهوية:"
        Me.RadLabel28.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel29
        '
        Me.RadLabel29.Location = New System.Drawing.Point(550, 65)
        Me.RadLabel29.Name = "RadLabel29"
        Me.RadLabel29.Size = New System.Drawing.Size(42, 18)
        Me.RadLabel29.TabIndex = 35
        Me.RadLabel29.Text = "العنوان:"
        Me.RadLabel29.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel33
        '
        Me.RadLabel33.Location = New System.Drawing.Point(550, 37)
        Me.RadLabel33.Name = "RadLabel33"
        Me.RadLabel33.Size = New System.Drawing.Size(36, 18)
        Me.RadLabel33.TabIndex = 26
        Me.RadLabel33.Text = "العمل:"
        Me.RadLabel33.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'txtBondsAddre
        '
        Me.txtBondsAddre.Enabled = False
        Me.txtBondsAddre.Location = New System.Drawing.Point(394, 65)
        Me.txtBondsAddre.Name = "txtBondsAddre"
        Me.txtBondsAddre.Size = New System.Drawing.Size(138, 20)
        Me.txtBondsAddre.TabIndex = 53
        '
        'txtBondsJop
        '
        Me.txtBondsJop.Enabled = False
        Me.txtBondsJop.Location = New System.Drawing.Point(394, 37)
        Me.txtBondsJop.Name = "txtBondsJop"
        Me.txtBondsJop.Size = New System.Drawing.Size(138, 20)
        Me.txtBondsJop.TabIndex = 52
        '
        'RadLabel34
        '
        Me.RadLabel34.Location = New System.Drawing.Point(550, 8)
        Me.RadLabel34.Name = "RadLabel34"
        Me.RadLabel34.Size = New System.Drawing.Size(34, 18)
        Me.RadLabel34.TabIndex = 27
        Me.RadLabel34.Text = "الاسم:"
        Me.RadLabel34.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'txtBondsName
        '
        Me.txtBondsName.Enabled = False
        Me.txtBondsName.Location = New System.Drawing.Point(394, 6)
        Me.txtBondsName.Name = "txtBondsName"
        Me.txtBondsName.Size = New System.Drawing.Size(138, 20)
        Me.txtBondsName.TabIndex = 51
        '
        'chkEnableBondsMan
        '
        Me.chkEnableBondsMan.Location = New System.Drawing.Point(4, 0)
        Me.chkEnableBondsMan.Name = "chkEnableBondsMan"
        Me.chkEnableBondsMan.Size = New System.Drawing.Size(48, 18)
        Me.chkEnableBondsMan.TabIndex = 50
        Me.chkEnableBondsMan.Text = "تفعيل"
        '
        'SplitPanel2
        '
        Me.SplitPanel2.Controls.Add(Me.Radgrid)
        Me.SplitPanel2.Location = New System.Drawing.Point(0, 204)
        Me.SplitPanel2.Name = "SplitPanel2"
        '
        '
        '
        Me.SplitPanel2.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitPanel2.Size = New System.Drawing.Size(615, 145)
        Me.SplitPanel2.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.0!, -0.07971015!)
        Me.SplitPanel2.SizeInfo.SplitterCorrection = New System.Drawing.Size(0, -23)
        Me.SplitPanel2.TabIndex = 1
        Me.SplitPanel2.TabStop = False
        Me.SplitPanel2.Text = "SplitPanel2"
        '
        'Radgrid
        '
        Me.Radgrid.AutoScroll = True
        Me.Radgrid.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        Me.Radgrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Radgrid.EnableCustomDrawing = True
        Me.Radgrid.EnableFastScrolling = True
        Me.Radgrid.Location = New System.Drawing.Point(0, 0)
        '
        'Radgrid
        '
        Me.Radgrid.MasterTemplate.AllowAddNewRow = False
        Me.Radgrid.MasterTemplate.AllowColumnChooser = False
        Me.Radgrid.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.Radgrid.MasterTemplate.AllowDragToGroup = False
        Me.Radgrid.MasterTemplate.AllowEditRow = False
        Me.Radgrid.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        GridViewDecimalColumn1.DecimalPlaces = 0
        GridViewDecimalColumn1.HeaderText = "الرقم"
        GridViewDecimalColumn1.Name = "ID"
        GridViewDecimalColumn1.ShowUpDownButtons = False
        GridViewDecimalColumn1.Width = 53
        GridViewTextBoxColumn1.HeaderText = "اسم اليتيم"
        GridViewTextBoxColumn1.Name = "OrphanName"
        GridViewTextBoxColumn1.Width = 163
        GridViewTextBoxColumn2.HeaderText = "اسم الأب"
        GridViewTextBoxColumn2.Name = "FatherName"
        GridViewTextBoxColumn2.Width = 165
        GridViewTextBoxColumn3.HeaderText = "اسم الأم"
        GridViewTextBoxColumn3.Name = "MotherName"
        GridViewTextBoxColumn3.Width = 216
        Me.Radgrid.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewDecimalColumn1, GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3})
        Me.Radgrid.MasterTemplate.EnableAlternatingRowColor = True
        Me.Radgrid.MasterTemplate.MultiSelect = True
        Me.Radgrid.MasterTemplate.ShowFilteringRow = False
        Me.Radgrid.Name = "Radgrid"
        Me.Radgrid.ReadOnly = True
        Me.Radgrid.ShowCellErrors = False
        Me.Radgrid.ShowGroupPanel = False
        Me.Radgrid.Size = New System.Drawing.Size(615, 145)
        Me.Radgrid.TabIndex = 100
        Me.Radgrid.Text = "RadGridView1"
        '
        'FrmSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 377)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MaximizeBox = False
        Me.Name = "FrmSearch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "بحث"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadSplitContainer1.ResumeLayout(False)
        CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel1.ResumeLayout(False)
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageView1.ResumeLayout(False)
        Me.pgeOrphan.ResumeLayout(False)
        Me.pgeOrphan.PerformLayout()
        CType(Me.chkEnableOrph, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrphSex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numOrphKaid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numOrphAge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOrphIsSick, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOrphHasBodyPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOrphHasFacePhoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOrphIsBaild, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOrphEnabledBirthday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpOrphDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOrphDate.ResumeLayout(False)
        Me.grpOrphDate.PerformLayout()
        CType(Me.dteOrphTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteOrphFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrphBirthPlace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrphNAme, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgeFather.ResumeLayout(False)
        Me.pgeFather.PerformLayout()
        CType(Me.numFathId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFathAge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkFathEnabledDieDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpFathDieDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFathDieDate.ResumeLayout(False)
        Me.grpFathDieDate.PerformLayout()
        CType(Me.dteFathTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteFathFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFathDeathRe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFatheJop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFathName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkEnableFath, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgeMother.ResumeLayout(False)
        Me.pgeMother.PerformLayout()
        CType(Me.numMothId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMothAge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMothEnabledBirth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMothIsDead, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMothIsMarried, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpMothBirth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMothBirth.ResumeLayout(False)
        Me.grpMothBirth.PerformLayout()
        CType(Me.dteMothTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteMothFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMothAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMotheJop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMothName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkEnableMother, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgeBondsMan.ResumeLayout(False)
        Me.pgeBondsMan.PerformLayout()
        CType(Me.numBondsID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBondsAddre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBondsJop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBondsName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkEnableBondsMan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel2.ResumeLayout(False)
        CType(Me.Radgrid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Radgrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RadStatusStrip1 As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents RadSplitContainer1 As Telerik.WinControls.UI.RadSplitContainer
    Friend WithEvents SplitPanel1 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents RadPageView1 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pgeOrphan As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents pgeFather As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents pgeMother As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents pgeBondsMan As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents SplitPanel2 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents Radgrid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtOrphNAme As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents grpOrphDate As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkEnableOrph As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkEnableFath As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkEnableMother As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkEnableBondsMan As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkOrphEnabledBirthday As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents btnShow As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents lblState As Telerik.WinControls.UI.RadLabelElement
    Friend WithEvents dteOrphTo As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents dteOrphFrom As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents numOrphAge As Telerik.WinControls.UI.RadSpinEditor
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkOrphIsBaild As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents txtOrphSex As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents numOrphKaid As Telerik.WinControls.UI.RadSpinEditor
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel9 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkOrphIsSick As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtOrphBirthPlace As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents numFathId As Telerik.WinControls.UI.RadSpinEditor
    Friend WithEvents numFathAge As Telerik.WinControls.UI.RadSpinEditor
    Friend WithEvents RadLabel12 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel13 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel14 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkFathEnabledDieDate As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents grpFathDieDate As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents dteFathTo As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents dteFathFrom As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadLabel15 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel16 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel17 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtFatheJop As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel18 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtFathName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtFathDeathRe As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents numMothId As Telerik.WinControls.UI.RadSpinEditor
    Friend WithEvents numMothAge As Telerik.WinControls.UI.RadSpinEditor
    Friend WithEvents RadLabel10 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel11 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel19 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel20 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkMothIsDead As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel21 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkMothIsMarried As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkMothEnabledBirth As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents grpMothBirth As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents dteMothTo As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents dteMothFrom As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadLabel22 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel23 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel24 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtMotheJop As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel25 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtMothName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtMothAdd As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents numBondsID As Telerik.WinControls.UI.RadSpinEditor
    Friend WithEvents RadLabel28 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel29 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel33 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtBondsAddre As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtBondsJop As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel34 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtBondsName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents radWatingBar As Telerik.WinControls.UI.RadWaitingBarElement
    Friend WithEvents btnSearch As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents CommandBarSeparator1 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents RadLabel27 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel26 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkOrphHasBodyPhoto As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkOrphHasFacePhoto As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents btnStop As Telerik.WinControls.UI.RadButtonElement
End Class

