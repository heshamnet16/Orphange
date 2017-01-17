Imports LangChanger.CurLang
Public Class NameForm
    Private _ShowMovement As Boolean
    Private isSHown As Boolean = False
    Private hi As Integer
    Private wi As Integer
    Private lef As Integer
    Private tp As Integer
    Private _MoveFactor As Integer = 10

    Public Property English_First_AutoComplete() As AutoCompleteStringCollection
        Get
            Return txtFAtherNameEf.AutoCompleteCustomSource
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            txtFAtherNameEf.AutoCompleteCustomSource = value
        End Set
    End Property
    Public Property English_Middle_AutoComplete() As AutoCompleteStringCollection
        Get
            Return txtFatherNameEFath.AutoCompleteCustomSource
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            txtFatherNameEFath.AutoCompleteCustomSource = value
        End Set
    End Property
    Public Property English_Last_AutoComplete() As AutoCompleteStringCollection
        Get
            Return txtFAtherNameELast.AutoCompleteCustomSource
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            txtFAtherNameELast.AutoCompleteCustomSource = value
        End Set
    End Property
    Public Property Father_Name_ReadOnly As Boolean
        Get
            Return txtFatherNameFAther.ReadOnly Or txtFatherNameEFath.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            txtFatherNameFAther.ReadOnly = value
            txtFatherNameEFath.ReadOnly = value
        End Set
    End Property
    Public Property Last_Name_ReadOnly As Boolean
        Get
            Return txtFAtherNameLast.ReadOnly Or txtFAtherNameELast.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            txtFAtherNameLast.ReadOnly = value
            txtFAtherNameELast.ReadOnly = value
        End Set
    End Property
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
        Set(ByVal value As Integer)
            Me._MoveFactor = Value
        End Set
    End Property

    Public Property ShowMovement() As Boolean
        Get
            Return Me._ShowMovement
        End Get
        Set(ByVal value As Boolean)
            Me._ShowMovement = Value
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

    Public Property First As String
        Get
            Return txtFatherNameF.Text
        End Get
        Set(ByVal value As String)
            txtFatherNameF.Text = value
        End Set
    End Property
    Public Property Middle As String
        Get
            Return txtFatherNameFAther.Text
        End Get
        Set(ByVal value As String)
            txtFatherNameFAther.Text = value
        End Set
    End Property

    Public Property Last As String
        Get
            Return txtFAtherNameLast.Text
        End Get
        Set(ByVal value As String)
            txtFAtherNameLast.Text = value
        End Set
    End Property

    Public Property English_First As String
        Get
            Dim ret As String = Nothing
            If txtFAtherNameEf.Text.Length > 0 Then
                ret = Char.ToUpper(txtFAtherNameEf.Text(0)) & txtFAtherNameEf.Text.Substring(1)
                Return ret
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As String)
            txtFAtherNameEf.Text = value
        End Set
    End Property

    Public Property English_Middle As String
        Get
            Dim ret As String = Nothing
            If txtFatherNameEFath.Text.Length > 0 Then
                ret = Char.ToUpper(txtFatherNameEFath.Text(0)) & txtFatherNameEFath.Text.Substring(1)
                Return ret
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As String)
            txtFatherNameEFath.Text = value
        End Set
    End Property

    Public Property English_Last As String
        Get
            Dim ret As String = Nothing
            If txtFAtherNameELast.Text.Length > 0 Then
                ret = Char.ToUpper(txtFAtherNameELast.Text(0)) & txtFAtherNameELast.Text.Substring(1)
                Return ret
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As String)
            txtFAtherNameELast.Text = value
        End Set
    End Property
    Private Sub txtFatherNameF_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFAtherNameLast.Enter, txtFatherNameFAther.Enter, txtFatherNameF.Enter, RadGroupBox2.Enter
        SaveCurrentLanguage()
        ChangeToArabic()
    End Sub

    Private Sub txtFAtherNameEf_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFAtherNameELast.Enter, txtFatherNameEFath.Enter, txtFAtherNameEf.Enter
        SaveCurrentLanguage()
        ChangeToEnglish()
    End Sub

    Private Sub txtFAtherNameEf_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFAtherNameELast.Leave, txtFatherNameEFath.Leave, txtFAtherNameEf.Leave, txtFAtherNameLast.Leave, txtFatherNameFAther.Leave, txtFatherNameF.Leave, RadGroupBox2.Leave
        ReturnToSavedLanguage()
        If TypeOf sender Is Telerik.WinControls.UI.RadTextBoxControl Then
            Dim txt As Telerik.WinControls.UI.RadTextBoxControl = CType(sender, Telerik.WinControls.UI.RadTextBoxControl)
            Dim ret As String
            If txt.Text.Length > 0 Then
                ret = Char.ToUpper(txt.Text(0))
                ret += txt.Text.Substring(1, txt.Text.Length - 1)
                txt.Text = ret
            End If
        End If
    End Sub

    Private Sub txtFatherNameF_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFAtherNameELast.KeyUp, txtFatherNameEFath.KeyUp, txtFAtherNameEf.KeyUp
        If _HideOnEnter Then
            If e.KeyCode = Keys.Enter Then
                Me.Visible = False
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

End Class
