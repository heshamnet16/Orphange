<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShowSalaryStatics
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
        Dim ListViewDetailColumn9 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "الكفيل")
        Dim ListViewDetailColumn10 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "المبلغ")
        Dim ListViewDetailColumn1 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "اسم العائلة")
        Dim ListViewDetailColumn2 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "اسم الكفيل")
        Dim ListViewDetailColumn11 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "عدد الايتام")
        Dim ListViewDetailColumn12 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 3", "عدد الايتام المكفولين")
        Dim ListViewDetailColumn13 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 4", "مبلغ الكفالة")
        Dim ListViewDetailColumn14 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 5", "المبلغ الثابت")
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadSeparator1 = New Telerik.WinControls.UI.RadSeparator()
        Me.txtFamiliesCount = New Telerik.WinControls.UI.RadTextBox()
        Me.txtLeftMony = New Telerik.WinControls.UI.RadTextBox()
        Me.txtAllMonies = New Telerik.WinControls.UI.RadTextBox()
        Me.txtOrphanCount = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.lstSuppor = New Telerik.WinControls.UI.RadListView()
        Me.RadGroupBox3 = New Telerik.WinControls.UI.RadGroupBox()
        Me.lstConf = New Telerik.WinControls.UI.RadListView()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.RadSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFamiliesCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLeftMony, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAllMonies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrphanCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.lstSuppor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox3.SuspendLayout()
        CType(Me.lstConf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.RadGroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RadGroupBox2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.RadGroupBox3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(487, 426)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.RadSeparator1)
        Me.RadGroupBox1.Controls.Add(Me.txtFamiliesCount)
        Me.RadGroupBox1.Controls.Add(Me.txtLeftMony)
        Me.RadGroupBox1.Controls.Add(Me.txtAllMonies)
        Me.RadGroupBox1.Controls.Add(Me.txtOrphanCount)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel4)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel3)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel2)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel1)
        Me.RadGroupBox1.HeaderText = "الأيتام الغير مكفولين"
        Me.RadGroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(481, 100)
        Me.RadGroupBox1.TabIndex = 0
        Me.RadGroupBox1.Text = "الأيتام الغير مكفولين"
        '
        'RadSeparator1
        '
        Me.RadSeparator1.Location = New System.Drawing.Point(235, 13)
        Me.RadSeparator1.Name = "RadSeparator1"
        Me.RadSeparator1.Size = New System.Drawing.Size(10, 82)
        Me.RadSeparator1.TabIndex = 2
        Me.RadSeparator1.Text = "RadSeparator1"
        CType(Me.RadSeparator1.GetChildAt(0), Telerik.WinControls.UI.SeparatorElement).DrawFill = False
        CType(Me.RadSeparator1.GetChildAt(0), Telerik.WinControls.UI.SeparatorElement).AngleTransform = 90.0!
        '
        'txtFamiliesCount
        '
        Me.txtFamiliesCount.Location = New System.Drawing.Point(9, 21)
        Me.txtFamiliesCount.Name = "txtFamiliesCount"
        Me.txtFamiliesCount.ReadOnly = True
        Me.txtFamiliesCount.Size = New System.Drawing.Size(118, 20)
        Me.txtFamiliesCount.TabIndex = 1
        '
        'txtLeftMony
        '
        Me.txtLeftMony.Location = New System.Drawing.Point(9, 63)
        Me.txtLeftMony.Name = "txtLeftMony"
        Me.txtLeftMony.ReadOnly = True
        Me.txtLeftMony.Size = New System.Drawing.Size(118, 20)
        Me.txtLeftMony.TabIndex = 1
        '
        'txtAllMonies
        '
        Me.txtAllMonies.Location = New System.Drawing.Point(258, 63)
        Me.txtAllMonies.Name = "txtAllMonies"
        Me.txtAllMonies.ReadOnly = True
        Me.txtAllMonies.Size = New System.Drawing.Size(146, 20)
        Me.txtAllMonies.TabIndex = 1
        '
        'txtOrphanCount
        '
        Me.txtOrphanCount.Location = New System.Drawing.Point(258, 21)
        Me.txtOrphanCount.Name = "txtOrphanCount"
        Me.txtOrphanCount.ReadOnly = True
        Me.txtOrphanCount.Size = New System.Drawing.Size(146, 20)
        Me.txtOrphanCount.TabIndex = 1
        '
        'RadLabel4
        '
        Me.RadLabel4.Location = New System.Drawing.Point(133, 63)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(92, 18)
        Me.RadLabel4.TabIndex = 0
        Me.RadLabel4.Text = "المتبقي ضمن الحساب :"
        Me.RadLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel3
        '
        Me.RadLabel3.Location = New System.Drawing.Point(410, 63)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(66, 18)
        Me.RadLabel3.TabIndex = 0
        Me.RadLabel3.Text = "المبلغ المطلوب :"
        Me.RadLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel2
        '
        Me.RadLabel2.Location = New System.Drawing.Point(133, 21)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(58, 18)
        Me.RadLabel2.TabIndex = 0
        Me.RadLabel2.Text = "عدد العائلات :"
        Me.RadLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(410, 21)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(50, 18)
        Me.RadLabel1.TabIndex = 0
        Me.RadLabel1.Text = "عدد الأيتام :"
        Me.RadLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox2.Controls.Add(Me.lstSuppor)
        Me.RadGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadGroupBox2.HeaderText = "الأيتام المكفولين"
        Me.RadGroupBox2.Location = New System.Drawing.Point(3, 113)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Size = New System.Drawing.Size(481, 152)
        Me.RadGroupBox2.TabIndex = 0
        Me.RadGroupBox2.Text = "الأيتام المكفولين"
        '
        'lstSuppor
        '
        ListViewDetailColumn9.HeaderText = "الكفيل"
        ListViewDetailColumn10.HeaderText = "المبلغ"
        Me.lstSuppor.Columns.AddRange(New Telerik.WinControls.UI.ListViewDetailColumn() {ListViewDetailColumn9, ListViewDetailColumn10})
        Me.lstSuppor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstSuppor.ItemSpacing = -1
        Me.lstSuppor.Location = New System.Drawing.Point(2, 18)
        Me.lstSuppor.Name = "lstSuppor"
        Me.lstSuppor.Size = New System.Drawing.Size(477, 132)
        Me.lstSuppor.TabIndex = 0
        Me.lstSuppor.Text = "RadListView1"
        Me.lstSuppor.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView
        '
        'RadGroupBox3
        '
        Me.RadGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox3.Controls.Add(Me.lstConf)
        Me.RadGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadGroupBox3.HeaderText = "العائلات المتقاطعة"
        Me.RadGroupBox3.Location = New System.Drawing.Point(3, 271)
        Me.RadGroupBox3.Name = "RadGroupBox3"
        Me.RadGroupBox3.Size = New System.Drawing.Size(481, 152)
        Me.RadGroupBox3.TabIndex = 0
        Me.RadGroupBox3.Text = "العائلات المتقاطعة"
        '
        'lstConf
        '
        ListViewDetailColumn1.HeaderText = "اسم العائلة"
        ListViewDetailColumn1.Width = 130.0!
        ListViewDetailColumn2.HeaderText = "اسم الكفيل"
        ListViewDetailColumn2.Width = 130.0!
        ListViewDetailColumn11.HeaderText = "عدد الايتام"
        ListViewDetailColumn11.Width = 50.0!
        ListViewDetailColumn12.HeaderText = "عدد الايتام المكفولين"
        ListViewDetailColumn12.Width = 50.0!
        ListViewDetailColumn13.HeaderText = "مبلغ الكفالة"
        ListViewDetailColumn13.Width = 50.0!
        ListViewDetailColumn14.HeaderText = "المبلغ الثابت"
        ListViewDetailColumn14.Width = 50.0!
        Me.lstConf.Columns.AddRange(New Telerik.WinControls.UI.ListViewDetailColumn() {ListViewDetailColumn1, ListViewDetailColumn2, ListViewDetailColumn11, ListViewDetailColumn12, ListViewDetailColumn13, ListViewDetailColumn14})
        Me.lstConf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstConf.ItemSpacing = -1
        Me.lstConf.Location = New System.Drawing.Point(2, 18)
        Me.lstConf.Name = "lstConf"
        Me.lstConf.Size = New System.Drawing.Size(477, 132)
        Me.lstConf.TabIndex = 0
        Me.lstConf.Text = "RadListView1"
        Me.lstConf.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView
        '
        'FrmShowSalaryStatics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 426)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmShowSalaryStatics"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "النتائج"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.RadSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFamiliesCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLeftMony, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAllMonies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrphanCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        CType(Me.lstSuppor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox3.ResumeLayout(False)
        CType(Me.lstConf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadGroupBox3 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lstSuppor As Telerik.WinControls.UI.RadListView
    Friend WithEvents lstConf As Telerik.WinControls.UI.RadListView
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadSeparator1 As Telerik.WinControls.UI.RadSeparator
    Friend WithEvents txtFamiliesCount As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtLeftMony As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtAllMonies As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtOrphanCount As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
End Class

