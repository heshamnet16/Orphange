Public Class frmUser
    Private _Id As Integer
    Public ReadOnly Property User_Id As Integer
        Get
            Return _Id
        End Get
    End Property
    Private usr As OrphanageClasses.User = Nothing
    Private Obd As New OrphanageDB.Odb()

    Private Sub AddressForm1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAddress.Click
        AddressForm1.ShowMe()
    End Sub
    Private Sub txtAddress_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddressForm1.Leave
        'AddressForm1.HideMe()
        txtAddress.Text = AddressForm1.City & " " & AddressForm1.Town & " " & AddressForm1.Street
    End Sub

    Private Sub txtAddress_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress.Enter
        'AddressForm1.ShowMe()
        NameForm1.HideMe()
    End Sub

    Private Sub txtName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NameForm1.Leave
        'NameForm1.HideMe()
        txtName.Text = NameForm1.First & " " & NameForm1.Middle & " " & NameForm1.Last
    End Sub

    Private Sub txtName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Click
        NameForm1.ShowMe()
    End Sub

    Private Sub txtName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.Enter
        'NameForm1.ShowMe()
        AddressForm1.HideMe()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me._Id = 0
        Me.usr = Nothing
    End Sub
    Public Sub New(ByVal _id As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        Try
            Dim q = From usr In Obd.Users Where usr.ID = _id Select usr
            If Not IsNothing(q) AndAlso Not IsNothing(q.FirstOrDefault()) Then
                Me.usr = q.First()
                Me._Id = _id
            Else
                ExceptionsManager.RaiseOnStatus(New MyException("المستخدم غير موجود!", True, True))
                Me.Close()
                Return
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseThis(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub frmUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click, RadGroupBox1.Click, RadGroupBox2.Click, RadGroupBox3.Click
        If AddressForm1.Visible Then
            AddressForm1.Visible = False
        End If
        If NameForm1.Visible Then
            NameForm1.Visible = False
        End If
    End Sub

    Private Sub frmUser_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If AddressForm1.Visible Then
            AddressForm1.Visible = False
        End If
        If NameForm1.Visible Then
            NameForm1.Visible = False
        End If
    End Sub
    Private Sub frmUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtUserName.Focus()
        'Me.usr = Getter.GetUserById(2)
        'Me._Id = 2
        If Not IsNothing(Me.usr) Then
            txtUserName.Text = usr.UserName
            txtPassword.Text = usr.Password
            chkCanAdd.Checked = usr.CanAdd
            chkCanDelete.Checked = usr.CanDelete
            chkCanDeposit.Checked = usr.CanDeposit
            chkCanDraw.Checked = usr.CanDraw
            chkCanRead.Checked = usr.CanRead
            chkIsAdmin.Checked = usr.IsAdmin
            If chkIsAdmin.Checked = False Then
                If chkCanAdd.Checked OrElse chkCanDelete.Checked OrElse chkCanDeposit.Checked OrElse _
                    chkCanDraw.Checked OrElse chkCanRead.Checked Then
                    RadGroupBox2.Enabled = True
                End If
            Else
                chkCanAdd.Checked = True
                chkCanDelete.Checked = True
                chkCanDeposit.Checked = True
                chkCanDraw.Checked = True
                chkCanRead.Checked = True
                RadGroupBox2.Enabled = False
            End If
            SetAddressForm(usr.Address)
            SetNameForm(usr.Name)
            txtNote.Text = usr.Note
            If Me.usr.ID = 1 Then
                chkIsAdmin.Enabled = False
                RadGroupBox2.Enabled = False
                txtNote.Enabled = False
                NameForm1.Enabled = False
                AddressForm1.Enabled = False
                txtUserName.Enabled = False
            Else
                txtUserName.Enabled = False
                If Not IsNothing(frmLogin.CurrentUser) AndAlso frmLogin.CurrentUser.ID = usr.ID Then
                    If Not usr.IsAdmin Then
                        chkIsAdmin.Enabled = False
                        RadGroupBox2.Enabled = False
                    End If
                End If
            End If
        End If
    End Sub
    Public Sub GetFromAddressObject(ByRef obj As OrphanageClasses.Address)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            obj.City = AddressForm1.City
            obj.Country = AddressForm1.Country
            obj.Town = AddressForm1.Town
            obj.Street = AddressForm1.Street
            obj.Cell_Phone = AddressForm1.CellPhone
            obj.Home_Phone = AddressForm1.HomePhone
            obj.Work_Phone = AddressForm1.WorkPhone
            obj.Fax = AddressForm1.Fax
            obj.Facebook = AddressForm1.Facebook
            obj.Email = AddressForm1.Email
            obj.Note = AddressForm1.Note
            obj.Twitter = AddressForm1.Skype
        Else
            obj = New OrphanageClasses.Address()
            obj.City = AddressForm1.City
            obj.Country = AddressForm1.Country
            obj.Town = AddressForm1.Town
            obj.Street = AddressForm1.Street
            obj.Cell_Phone = AddressForm1.CellPhone
            obj.Home_Phone = AddressForm1.HomePhone
            obj.Work_Phone = AddressForm1.WorkPhone
            obj.Fax = AddressForm1.Fax
            obj.Facebook = AddressForm1.Facebook
            obj.Email = AddressForm1.Email
            obj.Note = AddressForm1.Note
            obj.Twitter = AddressForm1.Skype
        End If
    End Sub

    Public Sub SetAddressForm(ByVal obj As OrphanageClasses.Address)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            AddressForm1.City = obj.City
            AddressForm1.Country = obj.Country
            AddressForm1.Town = obj.Town
            AddressForm1.Street = obj.Street
            AddressForm1.CellPhone = obj.Cell_Phone
            AddressForm1.HomePhone = obj.Home_Phone
            AddressForm1.WorkPhone = obj.Work_Phone
            AddressForm1.Fax = obj.Fax
            AddressForm1.Facebook = obj.Facebook
            AddressForm1.Email = obj.Email
            AddressForm1.Note = obj.Note
            AddressForm1.Skype = obj.Twitter
            txtAddress.Text = obj.City & "-" & obj.Town & "-" & obj.Street
        End If
    End Sub
    Public Sub SetNameForm(ByVal obj As OrphanageClasses.Name)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            NameForm1.First = obj.First
            NameForm1.Middle = obj.Father
            NameForm1.Last = obj.Last
            NameForm1.English_First = obj.EName
            NameForm1.English_Last = obj.ELast
            NameForm1.English_Middle = obj.EFather
            txtName.Text = obj.First & " " & obj.Father & " " & obj.Last
        End If
    End Sub
    Public Sub GetFromNameObject(ByRef obj As OrphanageClasses.Name)
        If Not IsNothing(obj) AndAlso obj.ID > 0 Then
            obj.First = NameForm1.First
            obj.Father = NameForm1.Middle
            obj.Last = NameForm1.Last
            obj.EName = NameForm1.English_First
            obj.ELast = NameForm1.English_Last
            obj.EFather = NameForm1.English_Middle
        Else
            obj = New OrphanageClasses.Name()
            obj.First = NameForm1.First
            obj.Father = NameForm1.Middle
            obj.Last = NameForm1.Last
            obj.EName = NameForm1.English_First
            obj.ELast = NameForm1.English_Last
            obj.EFather = NameForm1.English_Middle
        End If
    End Sub


    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If IsNothing(txtPassword.Text) OrElse txtPassword.Text.Length <= 6 Then
            ExceptionsManager.RaiseOnStatus(New MyException("تحقق من كلمة المرور يجب أن تكون 6 محارف على الأقل.", True))
            txtPassword.SelectAll()
            txtPassword.Focus()
            Return
        End If
        If IsNothing(txtUserName.Text) OrElse txtUserName.Text.Length = 0 Then
            ExceptionsManager.RaiseOnStatus(New MyException("أدخل اسم المستخدم.", True))
            txtUserName.Focus()
            Return
        End If
        If IsNothing(Me.usr) Then
            If Not IsNothing(Getter.GetUserByUserName(txtUserName.Text)) Then
                ExceptionsManager.RaiseOnStatus(New MyException("اسم المستخدم موجود, قم باختيار اسم آخر.", True))
                txtUserName.SelectAll()
                txtUserName.Focus()
                Return
            End If
        End If
        If chkCanAdd.Checked = False AndAlso chkCanDelete.Checked = False AndAlso chkCanDeposit.Checked = False _
            AndAlso chkCanDraw.Checked = False AndAlso chkCanRead.Checked = False AndAlso chkIsAdmin.Checked = False Then
            ExceptionsManager.RaiseOnStatus(New MyException("يجب عليك اختيار صلاحية على الأقل لهذا المستخدم!", True))
            Return
        End If
        Try
            If Me._Id = 0 Then
                Using ts = New Transactions.TransactionScope
                    Dim SName As OrphanageClasses.Name = Nothing
                    Dim SAdd As OrphanageClasses.Address = Nothing
                    Dim Susr As New OrphanageClasses.User()
                    If Not IsNothing(NameForm1.First) AndAlso NameForm1.First.Length > 0 Then
                        SName = New OrphanageClasses.Name
                        GetFromNameObject(SName)
                        Obd.Names.InsertOnSubmit(SName)
                        Obd.SubmitChanges()
                        'Obd.Refresh(Data.Linq.RefreshMode.OverwriteCurrentValues, SName)
                        Susr.Name_ID = SName.ID
                    Else
                        Susr.Name_ID = Nothing
                    End If
                    If Not IsNothing(AddressForm1.City) AndAlso AddressForm1.City.Length > 0 Then
                        SAdd = New OrphanageClasses.Address
                        GetFromAddressObject(SAdd)
                        Obd.Addresses.InsertOnSubmit(SAdd)
                        Obd.SubmitChanges()
                        'Obd.Refresh(Data.Linq.RefreshMode.OverwriteCurrentValues, SAdd)
                        Susr.Address_ID = SAdd.ID
                    Else
                        Susr.Address_ID = Nothing
                    End If
                    If txtNote.Text.Length = 0 Then
                        Susr.Note = Nothing
                    Else
                        Susr.Note = txtNote.Text
                    End If
                    Susr.UserName = txtUserName.Text
                    Susr.Password = txtPassword.Text
                    Susr.CanAdd = chkCanAdd.Checked
                    Susr.CanDelete = chkCanDelete.Checked
                    Susr.CanDeposit = chkCanDeposit.Checked
                    Susr.CanDraw = chkCanDraw.Checked
                    Susr.CanRead = chkCanRead.Checked
                    Susr.IsAdmin = chkIsAdmin.Checked
                    Susr.RegDate = Date.Now
                    Obd.Users.InsertOnSubmit(Susr)
                    Obd.SubmitChanges()
                    'Obd.Refresh(Data.Linq.RefreshMode.OverwriteCurrentValues, Susr)
                    Me._Id = Susr.ID
                    ts.Complete()
                    ExceptionsManager.RaiseOnStatus(New MyException("تم الحفظ", False, True))
                    Me.Close()
                End Using
            Else
                'edit
                Using ts = New Transactions.TransactionScope
                    'User Enter Name
                    If Not IsNothing(NameForm1.First) AndAlso NameForm1.First.Length > 0 Then
                        'Name Exist
                        If Not IsNothing(usr.Name_ID) Then
                            GetFromNameObject(usr.Name)
                            Obd.SubmitChanges()
                        Else
                            Dim SName As New OrphanageClasses.Name
                            GetFromNameObject(SName)
                            Obd.Names.InsertOnSubmit(SName)
                            Obd.SubmitChanges()
                            'Obd.Refresh(Data.Linq.RefreshMode.OverwriteCurrentValues, SName)
                            usr.Name = SName
                        End If
                    Else
                        If Not IsNothing(usr.Name_ID) AndAlso usr.Name_ID > 0 Then
                            'Dim delInt As Integer =usr.Name_ID 
                            Obd.Names.DeleteOnSubmit(usr.Name)
                            usr.Name = Nothing
                            'Obd.SubmitChanges()
                            Obd.SubmitChanges()
                        End If
                    End If
                    'user enter Address
                    If Not IsNothing(AddressForm1.City) AndAlso AddressForm1.City.Length > 0 Then
                        'Address exist
                        If Not IsNothing(usr.Address) Then
                            'usr.Address = New OrphanageClasses.Address
                            GetFromAddressObject(usr.Address)
                            Obd.SubmitChanges()
                            'Obd.Refresh(Data.Linq.RefreshMode.OverwriteCurrentValues, usr.Address)
                        Else
                            Dim SAdd As New OrphanageClasses.Address
                            GetFromAddressObject(SAdd)
                            Obd.Addresses.InsertOnSubmit(SAdd)
                            Obd.SubmitChanges()
                            'Obd.Refresh(Data.Linq.RefreshMode.OverwriteCurrentValues, nothin)
                            usr.Address = SAdd
                        End If
                    Else
                        If Not IsNothing(usr.Address) Then
                            Obd.Addresses.DeleteOnSubmit(usr.Address)
                            usr.Address = Nothing
                            'Obd.SubmitChanges()
                            Obd.SubmitChanges()
                        End If
                    End If
                    If txtNote.Text.Length = 0 Then
                        usr.Note = Nothing
                    Else
                        usr.Note = txtNote.Text
                    End If
                    usr.UserName = txtUserName.Text
                    usr.Password = txtPassword.Text
                    usr.CanAdd = chkCanAdd.Checked
                    usr.CanDelete = chkCanDelete.Checked
                    usr.CanDeposit = chkCanDeposit.Checked
                    usr.CanDraw = chkCanDraw.Checked
                    usr.CanRead = chkCanRead.Checked
                    usr.IsAdmin = chkIsAdmin.Checked
                    'usr.RegDate = Date.Now
                    Obd.SubmitChanges()
                    ts.Complete()
                    ExceptionsManager.RaiseOnStatus(New MyException("تم الحفظ", False, True))
                    Me.Close()                
                End Using
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseThis(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtUserName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUserName.Leave
        If txtUserName.Text.Length > 0 Then
            If Not IsNothing(Getter.GetUserByUserName(txtUserName.Text)) Then
                ExceptionsManager.RaiseOnStatus(New MyException("اسم المستخدم موجود, قم باختيار اسم آخر.", True))
                txtUserName.SelectAll()
                txtUserName.Focus()
                Return
            End If
        End If
    End Sub

    Private Sub chkIsAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsAdmin.Click
        RadGroupBox2.Enabled = chkIsAdmin.Checked
        For Each itm As Object In RadGroupBox2.Controls
            If (TypeOf (itm) Is Telerik.WinControls.UI.RadCheckBox) Then
                itm.Checked = Not chkIsAdmin.Checked
            End If
        Next
    End Sub
End Class
