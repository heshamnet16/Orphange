<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PictureSelector
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.btnBrowes = New System.Windows.Forms.PictureBox()
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.btnCancel = New System.Windows.Forms.PictureBox()
        CType(Me.btnBrowes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBrowes
        '
        Me.btnBrowes.Image = Global.PictureSelector.My.Resources.Resources.up
        Me.btnBrowes.Location = New System.Drawing.Point(32, 0)
        Me.btnBrowes.Name = "btnBrowes"
        Me.btnBrowes.Size = New System.Drawing.Size(26, 25)
        Me.btnBrowes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnBrowes.TabIndex = 0
        Me.btnBrowes.TabStop = False
        '
        'OFD
        '
        Me.OFD.Filter = "Photos|*.jpg;*.jprg;*.gif;*.png|All files|*.*"
        Me.OFD.RestoreDirectory = True
        Me.OFD.Title = "Choose your photo"
        '
        'btnCancel
        '
        Me.btnCancel.Image = Global.PictureSelector.My.Resources.Resources.BRIGHTS_DELETE
        Me.btnCancel.Location = New System.Drawing.Point(64, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(26, 25)
        Me.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.TabStop = False
        '
        'PictureSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnBrowes)
        Me.Name = "PictureSelector"
        Me.Size = New System.Drawing.Size(123, 132)
        CType(Me.btnBrowes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBrowes As System.Windows.Forms.PictureBox
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnCancel As System.Windows.Forms.PictureBox

End Class
