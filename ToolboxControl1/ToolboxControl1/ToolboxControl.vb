Imports System.Windows.Forms

<ProvideToolboxControl("ToolboxControl1", false)>
Public Class ToolboxControl

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MessageBox.Show(String.Format(System.Globalization.CultureInfo.CurrentUICulture, "We are inside {0}.Button1_Click()", Me.ToString()))
    End Sub

End Class
