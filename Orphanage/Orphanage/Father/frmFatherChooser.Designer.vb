﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFatherChooser
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
        Dim ListViewDetailColumn3 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "اسم الزوجة")
        Dim ListViewDetailColumn4 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 3", "تاريخ الوفاة")
        Dim ListViewDetailColumn5 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 4", "عدد الأيتام")
        Dim ListViewDetailColumn6 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 5", "عدد الأولاد")
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadStatusStrip1 = New Telerik.WinControls.UI.RadStatusStrip()
        Me.lblStatu = New Telerik.WinControls.UI.RadLabelElement()
        Me.RadListView1 = New Telerik.WinControls.UI.RadListView()
        Me.FamliesSelectorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrphansDBDataSet = New Orphanage.OrphansDBDataSet()
        Me.SearchControl1 = New SearchControl.SearchControl()
        Me.RadScrollablePanel1 = New Telerik.WinControls.UI.RadScrollablePanel()
        Me.btnOK = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.FamliesSelectorTableAdapter = New Orphanage.OrphansDBDataSetTableAdapters.FamliesSelectorTableAdapter()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FamliesSelectorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrphansDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadScrollablePanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadScrollablePanel1.PanelContainer.SuspendLayout()
        Me.RadScrollablePanel1.SuspendLayout()
        CType(Me.btnOK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.RadStatusStrip1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.RadListView1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.SearchControl1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RadScrollablePanel1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(489, 340)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.lblStatu})
        Me.RadStatusStrip1.Location = New System.Drawing.Point(3, 315)
        Me.RadStatusStrip1.Name = "RadStatusStrip1"
        Me.RadStatusStrip1.Size = New System.Drawing.Size(483, 22)
        Me.RadStatusStrip1.TabIndex = 4
        Me.RadStatusStrip1.Text = "RadStatusStrip1"
        '
        'lblStatu
        '
        Me.lblStatu.Name = "lblStatu"
        Me.RadStatusStrip1.SetSpring(Me.lblStatu, False)
        Me.lblStatu.Text = ""
        Me.lblStatu.TextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.lblStatu.TextWrap = True
        Me.lblStatu.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'RadListView1
        '
        Me.RadListView1.AllowEdit = False
        Me.RadListView1.AllowRemove = False
        ListViewDetailColumn1.HeaderText = "الرقم"
        ListViewDetailColumn1.Width = 60.0!
        ListViewDetailColumn2.HeaderText = "الاسم"
        ListViewDetailColumn2.Width = 120.0!
        ListViewDetailColumn3.HeaderText = "اسم الزوجة"
        ListViewDetailColumn3.Width = 120.0!
        ListViewDetailColumn4.HeaderText = "تاريخ الوفاة"
        ListViewDetailColumn4.Width = 120.0!
        ListViewDetailColumn5.HeaderText = "عدد الأيتام"
        ListViewDetailColumn5.Width = 60.0!
        ListViewDetailColumn6.HeaderText = "عدد الأولاد"
        ListViewDetailColumn6.Width = 60.0!
        Me.RadListView1.Columns.AddRange(New Telerik.WinControls.UI.ListViewDetailColumn() {ListViewDetailColumn1, ListViewDetailColumn2, ListViewDetailColumn3, ListViewDetailColumn4, ListViewDetailColumn5, ListViewDetailColumn6})
        Me.RadListView1.DataSource = Me.FamliesSelectorBindingSource
        Me.RadListView1.DisplayMember = "Father_Id"
        Me.RadListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadListView1.EnableColumnSort = True
        Me.RadListView1.EnableCustomGrouping = True
        Me.RadListView1.EnableGrouping = True
        Me.RadListView1.EnableSorting = True
        Me.RadListView1.ItemSpacing = -1
        Me.RadListView1.Location = New System.Drawing.Point(3, 37)
        Me.RadListView1.MultiSelect = True
        Me.RadListView1.Name = "RadListView1"
        Me.RadListView1.ShowGridLines = True
        Me.RadListView1.ShowGroups = True
        Me.RadListView1.Size = New System.Drawing.Size(483, 232)
        Me.RadListView1.TabIndex = 0
        Me.RadListView1.ValueMember = "Father_Id"
        Me.RadListView1.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView
        '
        'FamliesSelectorBindingSource
        '
        Me.FamliesSelectorBindingSource.DataMember = "FamliesSelector"
        Me.FamliesSelectorBindingSource.DataSource = Me.OrphansDBDataSet
        '
        'OrphansDBDataSet
        '
        Me.OrphansDBDataSet.DataSetName = "OrphansDBDataSet"
        Me.OrphansDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SearchControl1
        '
        Me.SearchControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SearchControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SearchControl1.Location = New System.Drawing.Point(3, 3)
        Me.SearchControl1.MaximumSize = New System.Drawing.Size(4000, 20)
        Me.SearchControl1.MinimumSize = New System.Drawing.Size(30, 15)
        Me.SearchControl1.Name = "SearchControl1"
        Me.SearchControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SearchControl1.SearchedText = ""
        Me.SearchControl1.Size = New System.Drawing.Size(483, 20)
        Me.SearchControl1.TabIndex = 3
        '
        'RadScrollablePanel1
        '
        Me.RadScrollablePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadScrollablePanel1.Location = New System.Drawing.Point(3, 275)
        Me.RadScrollablePanel1.Name = "RadScrollablePanel1"
        '
        'RadScrollablePanel1.PanelContainer
        '
        Me.RadScrollablePanel1.PanelContainer.Controls.Add(Me.btnOK)
        Me.RadScrollablePanel1.PanelContainer.Controls.Add(Me.btnCancel)
        Me.RadScrollablePanel1.PanelContainer.Size = New System.Drawing.Size(481, 32)
        Me.RadScrollablePanel1.Size = New System.Drawing.Size(483, 34)
        Me.RadScrollablePanel1.TabIndex = 2
        Me.RadScrollablePanel1.Text = "RadScrollablePanel1"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(6, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(63, 26)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "موافق"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(75, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(63, 26)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "إلغاء الأمر"
        '
        'FamliesSelectorTableAdapter
        '
        Me.FamliesSelectorTableAdapter.ClearBeforeFill = True
        '
        'FrmFatherChooser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(489, 340)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MaximizeBox = False
        Me.Name = "FrmFatherChooser"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "اختر أب"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FamliesSelectorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrphansDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadScrollablePanel1.PanelContainer.ResumeLayout(False)
        CType(Me.RadScrollablePanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadScrollablePanel1.ResumeLayout(False)
        CType(Me.btnOK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RadListView1 As Telerik.WinControls.UI.RadListView
    Friend WithEvents RadScrollablePanel1 As Telerik.WinControls.UI.RadScrollablePanel
    Friend WithEvents btnOK As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents SearchControl1 As SearchControl.SearchControl
    Friend WithEvents RadStatusStrip1 As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents lblStatu As Telerik.WinControls.UI.RadLabelElement
    Friend WithEvents OrphansDBDataSet As Orphanage.OrphansDBDataSet
    Friend WithEvents FamliesSelectorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FamliesSelectorTableAdapter As Orphanage.OrphansDBDataSetTableAdapters.FamliesSelectorTableAdapter
End Class

