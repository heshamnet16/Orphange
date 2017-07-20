<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.AddressForm1 = New AddressForm.AddressForm()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 262)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'AddressForm1
        '
        Me.AddressForm1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AddressForm1.CellPhone = "(0933)000-000"
        Me.AddressForm1.City = ""
        Me.AddressForm1.Country = ""
        Me.AddressForm1.Email = ""
        Me.AddressForm1.Facebook = ""
        Me.AddressForm1.Fax = "(031)0000-000"
        Me.AddressForm1.HideOnEnter = False
        Me.AddressForm1.HomePhone = "(031)0000-000"
        Me.AddressForm1.Location = New System.Drawing.Point(120, 12)
        Me.AddressForm1.MoveFactor = 10
        Me.AddressForm1.MoveType = AddressForm.AddressForm._MoveType.RightToLeft
        Me.AddressForm1.Name = "AddressForm1"
        Me.AddressForm1.Note = ""
        Me.AddressForm1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.AddressForm1.ShowMovement = False
        Me.AddressForm1.Size = New System.Drawing.Size(390, 262)
        Me.AddressForm1.Skype = ""
        Me.AddressForm1.Street = ""
        Me.AddressForm1.TabIndex = 0
        Me.AddressForm1.Town = ""
        Me.AddressForm1.Visible = False
        Me.AddressForm1.WorkPhone = "(031)0000-000"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 308)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.AddressForm1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AddressForm1 As AddressForm.AddressForm
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
