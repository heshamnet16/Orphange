Imports LangChanger.CurLang
Public Class AddressForm
    Private _ShowMovement As Boolean
    Private _MoveFactor As Integer = 10
    Public Property MoveType() As _MoveType
        Get
            Return Me._Mtype
        End Get
        Set(ByVal value As _MoveType)
            Me._Mtype = value
        End Set
    End Property

    Public Enum _MoveType
        LeftToRight
        RightToLeft
        UpToDown
        DownToUp
    End Enum
    Private _Mtype As _MoveType = _MoveType.UpToDown
    Public Property MoveFactor() As Integer
        Get
            Return Me._MoveFactor
        End Get
        Set
            Me._MoveFactor = Value
        End Set
    End Property

    Public Property Country_AutoComplete As AutoCompleteStringCollection
        Get
            Return txtCountry.AutoCompleteCustomSource
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            txtCountry.AutoCompleteCustomSource = value
        End Set
    End Property
    Public Property City_AutoComplete As AutoCompleteStringCollection
        Get
            Return txtCity.AutoCompleteCustomSource
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            txtCity.AutoCompleteCustomSource = value
        End Set
    End Property
    Public Property Town_AutoComplete As AutoCompleteStringCollection
        Get
            Return txtTown.AutoCompleteCustomSource
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            txtTown.AutoCompleteCustomSource = value
        End Set
    End Property
    Public Property Street_AutoComplete As AutoCompleteStringCollection
        Get
            Return txtStreet.AutoCompleteCustomSource
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            txtStreet.AutoCompleteCustomSource = value
        End Set
    End Property

    Public Property ShowMovement() As Boolean
        Get
            Return Me._ShowMovement
        End Get
        Set
            Me._ShowMovement = Value
        End Set
    End Property

    Public Property Note() As String
        Get
            Return Me.txtNote.Text
        End Get
        Set(ByVal value As String)
            Me.txtNote.Text = Value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return Me.txtEmail.Text
        End Get
        Set(ByVal value As String)
            Me.txtEmail.Text = Value
        End Set
    End Property

    Public Property Facebook() As String
        Get
            Return Me.txtFacebook.Text
        End Get
        Set(ByVal value As String)
            Me.txtFacebook.Text = Value
        End Set
    End Property

    Public Property Skype() As String
        Get
            Return Me.txtSkype.Text
        End Get
        Set(ByVal value As String)
            Me.txtSkype.Text = Value
        End Set
    End Property

    Public Property Fax() As String
        Get
            Return Me.txtFaxNumb.Text
        End Get
        Set(ByVal value As String)
            Me.txtFaxNumb.Text = Value
        End Set
    End Property

    Public Property WorkPhone() As String
        Get
            Return Me.txtWorkPhon.Text
        End Get
        Set(ByVal value As String)
            Me.txtWorkPhon.Text = Value
        End Set
    End Property

    Public Property HomePhone() As String
        Get
            Return Me.txtHomePho.Text
        End Get
        Set(ByVal value As String)
            Me.txtHomePho.Text = Value
        End Set
    End Property

    Public Property CellPhone() As String
        Get
            Return Me.txtCellNumb.Text
        End Get
        Set(ByVal value As String)
            Me.txtCellNumb.Text = Value
        End Set
    End Property

    Public Property Street() As String
        Get
            Return Me.txtStreet.Text
        End Get
        Set(ByVal value As String)
            Me.txtStreet.Text = Value
        End Set
    End Property

    Public Property Town() As String
        Get
            Return Me.txtTown.Text
        End Get
        Set(ByVal value As String)
            Me.txtTown.Text = Value
        End Set
    End Property

    Public Property City() As String
        Get
            Return Me.txtCity.Text
        End Get
        Set(ByVal value As String)
            Me.txtCity.Text = Value
        End Set
    End Property

    Public Property Country() As String
        Get
            Return Me.txtCountry.Text
        End Get
        Set(ByVal value As String)
            Me.txtCountry.Text = Value
        End Set
    End Property
    Private _HideOnEnter As Boolean = False
    Public Property HideOnEnter As Boolean
        Get
            Return _HideOnEnter
        End Get
        Set(ByVal value As Boolean)
            _HideOnEnter = value
        End Set
    End Property
    Private isSHown As Boolean = False
    Private hi As Integer
    Private wi As Integer
    Private lef As Integer
    Private tp As Integer
    Private Sub txtCountry_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTown.Enter, txtStreet.Enter, txtNote.Enter, txtCity.Enter, txtCountry.Enter
        SaveCurrentLanguage()
        ChangeToArabic()
    End Sub

    Private Sub txtCountry_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTown.Leave, txtStreet.Leave, txtNote.Leave, txtCity.Leave, txtSkype.Leave, txtFacebook.Leave, txtEmail.Leave, txtCountry.Leave
        ReturnToSavedLanguage()
        If sender Is txtFacebook Then
            If txtFacebook.Text = "Https://www.Facebook.com/" Then
                txtFacebook.Text = Nothing
            End If
        End If
    End Sub

    Private Sub txtEmail_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSkype.Enter, txtFacebook.Enter, txtEmail.Enter
        SaveCurrentLanguage()
        ChangeToEnglish()
        If sender Is txtFacebook Then
            If IsNothing(txtFacebook.Text) OrElse txtFacebook.Text = "" Then
                txtFacebook.Text = "Https://www.Facebook.com/"
                txtFacebook.SelectionStart = txtFacebook.Text.Length
            End If
        End If
    End Sub

    Public Sub HideMe()
        If isSHown = True Then
            If Me._Mtype = _MoveType.UpToDown Then
                Me.Width = wi
                For i As Integer = hi To 0 Step -_MoveFactor
                    Me.Height = i
                    Application.DoEvents()
                    Me.Refresh()
                Next
                Me.Height = 0
            ElseIf Me._Mtype = _MoveType.DownToUp Then
                Me.Width = wi
                For i As Integer = hi To 0 Step -_MoveFactor
                    Me.Height = i
                    Application.DoEvents()
                    Me.Refresh()
                    Me.Top += _MoveFactor / 2
                Next
                Me.Height = 0
                Me.Top = Me.tp + (Me.hi / 2)
            ElseIf Me._Mtype = _MoveType.LeftToRight Then
                Me.Height = hi
                For i As Integer = wi To 0 Step -_MoveFactor
                    Me.Width = i
                    Application.DoEvents()
                    Me.Refresh()
                Next
                Me.Width = 0
            Else ''''''''''''''''''''''
                Me.Height = hi
                For i As Integer = wi To 0 Step -_MoveFactor
                    Me.Width = i
                    Application.DoEvents()
                    Me.Refresh()
                    Me.Left += _MoveFactor / 2
                Next
                Me.Width = 0
                Me.Left = Me.lef + (Me.wi / 2)
            End If
            _ShowMovement = False
            Me.Visible = False
            _ShowMovement = True
            isSHown = False
        End If

    End Sub
    Public Sub ShowMe()
        _ShowMovement = False
        Me.Visible = True
        _ShowMovement = True
        If isSHown = False Then
            If Me._Mtype = _MoveType.UpToDown Then
                Me.Width = wi
                Me.Left = Me.lef
                Me.Top = Me.tp
                For i As Integer = 0 To hi Step _MoveFactor
                    Me.Height = i
                    Application.DoEvents()
                    Me.Refresh()
                Next
                Me.Height = hi
            ElseIf Me._Mtype = _MoveType.DownToUp Then
                Me.Width = wi
                Me.Left = Me.lef
                Me.Top = Me.tp + (Me.hi / 2)
                For i As Integer = 0 To hi Step _MoveFactor
                    Me.Height = i
                    Application.DoEvents()
                    Me.Refresh()
                    Me.Top -= _MoveFactor / 2
                Next
                Me.Height = hi
                Me.Top = Me.tp
            ElseIf Me._Mtype = _MoveType.LeftToRight Then
                Me.Height = hi
                Me.Left = Me.lef
                Me.Top = Me.tp
                For i As Integer = 0 To wi Step _MoveFactor
                    Me.Width = i
                    Application.DoEvents()
                    Me.Refresh()
                    'Me.Left += (i / 2)
                Next
                Me.Width = wi
            Else
                Me.Height = hi
                Me.Left = Me.lef + (Me.wi / 2)
                For i As Integer = 0 To wi Step _MoveFactor
                    Me.Width = i
                    Application.DoEvents()
                    Me.Refresh()
                    Me.Left -= (_MoveFactor / 2)
                Next
                Me.Width = wi
                Me.Left = lef
            End If
            isSHown = True
        End If
    End Sub

    Private Sub AddressForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.hi = Me.Height
        Me.wi = Me.Width
        Me.tp = Me.Top
        Me.lef = Me.Left
    End Sub
    Private Sub AddressForm_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If _ShowMovement Then
            If Me.Visible Then
                ShowMe()
            Else
                _ShowMovement = False
                Me.Visible = True
                HideMe()
                Me.Visible = False
                _ShowMovement = True
            End If
        End If
    End Sub

    Private Sub txtNote_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWorkPhon.KeyUp, txtTown.KeyUp, txtStreet.KeyUp, txtSkype.KeyUp, txtNote.KeyUp, txtHomePho.KeyUp, txtFaxNumb.KeyUp, txtFacebook.KeyUp, txtEmail.KeyUp, txtCity.KeyUp, txtCellNumb.KeyUp, txtCountry.KeyUp
        If _HideOnEnter Then
            If e.KeyCode = Keys.Enter Then
                Me.Visible = False
            End If
        End If
    End Sub
End Class
