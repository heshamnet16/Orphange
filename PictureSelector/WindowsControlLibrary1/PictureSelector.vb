Public Class PictureSelector
    Private _PhotoPath As String
    Private _Photo As Image
    Private _PhotoAsBytes() As Byte

    Public ReadOnly Property PhotoAsBytes() As Byte()
        Get
            Return Me._PhotoAsBytes
        End Get
    End Property

    Public Property Photo() As Image
        Get
            Return Me._Photo
        End Get
        Set(ByVal value As Image)
            Me.BackgroundImage = value
            Me.BackgroundImageLayout = ImageLayout.Stretch
            Me.Refresh()
        End Set
    End Property

    Public ReadOnly Property PhotoPath() As String
        Get
            Return Me._PhotoPath
        End Get
    End Property

    Public Sub SetImageByBytes(ByVal data() As Byte)
        If IsNothing(data) Then
            Return
        End If
        Dim mem As New System.IO.MemoryStream(data)
        Try
            _Photo = Image.FromStream(mem)
            _PhotoPath = Nothing
            _PhotoAsBytes = data
            Me.BackgroundImage = _Photo
            Me.BackgroundImageLayout = ImageLayout.Stretch
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        mem.Dispose()
    End Sub
    Private Sub UserControl1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.btnBrowes.Top = 0
        Me.btnBrowes.Left = (Me.Width / 2) - (Me.btnBrowes.Width / 2) - 16
        Me.btnCancel.Left = Me.btnBrowes.Left + 32
    End Sub

    Private Sub BtnBrowesClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowes.Click
        If OFD.ShowDialog() = DialogResult.OK Then
            Dim mem As New System.IO.MemoryStream()
            Try
                Me.BackgroundImageLayout = ImageLayout.Stretch
                _Photo = Image.FromFile(OFD.FileName)
                Me.BackgroundImage = _Photo
                _PhotoPath = OFD.FileName
                _Photo.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg)
                _PhotoAsBytes = mem.ToArray()

            Catch
                _Photo = Nothing
                _PhotoPath = Nothing
                MessageBox.Show("لايمكن فتح الصورة")
            End Try
            mem.Dispose()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.BackgroundImageLayout = ImageLayout.Center
        Me.BackgroundImage = btnBrowes.ErrorImage
        _Photo = Nothing
        _PhotoAsBytes = Nothing
        _PhotoPath = Nothing
    End Sub

    Private Sub btnCancel_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.MouseEnter, btnBrowes.MouseEnter, btnCancel.MouseMove, btnBrowes.MouseMove
        Dim img As PictureBox = CType(sender, PictureBox)
        img.BorderStyle = 1
    End Sub

    Private Sub btnCancel_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.MouseLeave, btnBrowes.MouseLeave
        Dim img As PictureBox = CType(sender, PictureBox)
        img.BorderStyle = 0
    End Sub

    Private Sub UserControl1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        btnBrowes.BorderStyle = 0
        btnCancel.BorderStyle = 0
    End Sub

    Private Sub PictureSelector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancel_Click(Nothing, Nothing)
    End Sub

    Private Sub PictureSelector_BackgroundImageChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.BackgroundImageChanged
        Dim mem As New System.IO.MemoryStream()
        Try
            If Me.BackgroundImage Is btnBrowes.ErrorImage Then
                Me.BackgroundImageLayout = ImageLayout.Center
            Else
                Me.BackgroundImageLayout = ImageLayout.Stretch
                _Photo = Me.BackgroundImage
                _PhotoPath = ""
                _Photo.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg)
                _PhotoAsBytes = mem.ToArray()
                Me.Refresh()
            End If
        Catch
        End Try
        mem.Dispose()
    End Sub
End Class
