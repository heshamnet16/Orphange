Imports ATDFormater
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class FrmUsers
    Private odb As New OrphanageDB.Odb()
    Private _id() As OrphanageClasses.User = Nothing
    Dim WithEvents ExcpMgr As New ExceptionsManager()
    Private _ShowOnstatusCount As Integer = 0
    Public Class UserInGid
        Private _id As Integer
        Public Property ID As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property
        Private _UserName As String
        Public Property UserName As String
            Get
                Return _UserName
            End Get
            Set(ByVal value As String)
                _UserName = value
            End Set
        End Property
        Private _IsAdmin As String
        Public Property IsAdmin As String
            Get
                Return _IsAdmin
            End Get
            Set(ByVal value As String)
                _IsAdmin = value
            End Set
        End Property
        Private _CanAdd As String
        Public Property CanAdd As String
            Get
                Return _CanAdd
            End Get
            Set(ByVal value As String)
                _CanAdd = value
            End Set
        End Property
        Private _CanRead As String
        Public Property CanRead As String
            Get
                Return _CanRead
            End Get
            Set(ByVal value As String)
                _CanRead = value
            End Set
        End Property
        Private _CanDelete As String
        Public Property CanDelete As String
            Get
                Return _CanDelete
            End Get
            Set(ByVal value As String)
                _CanDelete = value
            End Set
        End Property
        Private _CanDeposit As String
        Public Property CanDeposit As String
            Get
                Return _CanDeposit
            End Get
            Set(ByVal value As String)
                _CanDeposit = value
            End Set
        End Property
        Private _CanDraw As String
        Public Property CanDraw As String
            Get
                Return _CanDraw
            End Get
            Set(ByVal value As String)
                _CanDraw = value
            End Set
        End Property
        'Private _FullName As String
        'Public Property FullName As String
        '    Get
        '        Return _FullName
        '    End Get
        '    Set(ByVal value As String)
        '        _FullName = value
        '    End Set
        'End Property
        Private _Note As String
        Public Property Note As String
            Get
                Return _Note
            End Get
            Set(ByVal value As String)
                _Note = value
            End Set
        End Property
        Private _regdate As Date
        Public Property RegDate As Date
            Get
                Return _regdate
            End Get
            Set(ByVal value As Date)
                _regdate = value
            End Set
        End Property
        Public Sub New()
            Me._CanAdd = ""
            Me._id = 0
            Me._CanDelete = ""
            Me._CanDeposit = ""
            Me._CanDraw = ""
            Me._CanRead = ""
            Me._IsAdmin = ""
            Me._Note = ""
            Me._regdate = Date.Now
            Me._UserName = ""
        End Sub
        Public Sub New(ByVal Id As Integer, ByVal usrName As String, ByVal CanAdd As String _
                        , ByVal CanDelete As String, ByVal canRead As String, ByVal CanDepos As String _
                        , ByVal CanDraw As String, ByVal IsAdmin As String, ByVal note As String, ByVal regD As Date)
            Me._CanAdd = CanAdd
            Me._id = Id
            Me._CanDelete = CanDelete
            Me._CanDeposit = CanDepos
            Me._CanDraw = CanDraw
            Me._CanRead = canRead
            Me._IsAdmin = IsAdmin
            Me._Note = note
            Me._regdate = regD
            Me._UserName = usrName
        End Sub
        Public Sub New(ByVal Id As Integer, ByVal usrName As String, ByVal CanAdd As Boolean _
                        , ByVal CanDelete As Boolean, ByVal canRead As Boolean, ByVal CanDepos As Boolean _
                        , ByVal CanDraw As Boolean, ByVal IsAdmin As Boolean, ByVal note As String, ByVal regD As Date)
            Me._CanAdd = ArabicBooleanFormatter.BooleanToArabic(CanAdd)
            Me._id = Id
            Me._CanDelete = ArabicBooleanFormatter.BooleanToArabic(CanDelete)
            Me._CanDeposit = ArabicBooleanFormatter.BooleanToArabic(CanDepos)
            Me._CanDraw = ArabicBooleanFormatter.BooleanToArabic(CanDraw)
            Me._CanRead = ArabicBooleanFormatter.BooleanToArabic(canRead)
            Me._IsAdmin = ArabicBooleanFormatter.BooleanToArabic(IsAdmin)
            Me._Note = note
            Me._regdate = regD
            Me._UserName = usrName
        End Sub
    End Class
    Public Sub New(ByVal _ids() As Integer)
        InitializeComponent()
        If Not IsNothing(_ids) Then
            LoadData(_ids)
        End If
    End Sub
    Public Sub New()
        InitializeComponent()
        Me._id = Nothing
        LoadData()
    End Sub
    Private Sub LoadData()
        radDataGrid.MasterTemplate.AllowAddNewRow = False
        radDataGrid.MasterTemplate.AllowCellContextMenu = False
        radDataGrid.MasterTemplate.AllowColumnReorder = True
        radDataGrid.MasterTemplate.AllowColumnResize = True
        radDataGrid.MasterTemplate.AllowDeleteRow = True
        radDataGrid.MasterTemplate.AllowEditRow = False
        radDataGrid.MasterTemplate.AllowMultiColumnSorting = True
        radDataGrid.MasterTemplate.AutoGenerateColumns = True
        radDataGrid.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.FullRowSelect
        radDataGrid.ColumnChooser.Text = "الأعمدة"
        radDataGrid.ColumnChooser.ColumnChooserControl.ColumnChooserElement.Text = "اسحب الأعمدة من و إلى الشبكة"
        radDataGrid.TableElement.BeginUpdate()

        Dim q = From usr In odb.Users _
                Select New UserInGid(usr.ID, usr.UserName, ArabicBooleanFormatter.BooleanToArabic(usr.CanAdd) _
                       , ArabicBooleanFormatter.BooleanToArabic(usr.CanDelete) _
                       , ArabicBooleanFormatter.BooleanToArabic(usr.CanRead) _
                       , ArabicBooleanFormatter.BooleanToArabic(usr.CanDeposit) _
                       , ArabicBooleanFormatter.BooleanToArabic(usr.CanDraw) _
                       , ArabicBooleanFormatter.BooleanToArabic(usr.IsAdmin) _
                       , usr.Note, usr.RegDate)
        'Dim q = From usr In odb.Users Select usr
        radDataGrid.DataSource = q

        radDataGrid.Columns("ID").HeaderText = "الرقم"
        radDataGrid.Columns("ID").IsVisible = False
        radDataGrid.Columns("UserName").HeaderText = "اسم المستخدم"
        radDataGrid.Columns("IsAdmin").HeaderText = "مدير"
        radDataGrid.Columns("CanAdd").HeaderText = "أضافة"
        radDataGrid.Columns("CanRead").HeaderText = "قراءة"
        radDataGrid.Columns("CanDelete").HeaderText = "حذف"
        radDataGrid.Columns("CanDraw").HeaderText = "سحب"
        radDataGrid.Columns("CanDeposit").HeaderText = "إيداع"
        radDataGrid.Columns("Note").HeaderText = "ملاحظات"
        radDataGrid.Columns("RegDate").HeaderText = "تاريخ التسجيل"
        radDataGrid.MasterTemplate.BestFitColumns(Telerik.WinControls.UI.BestFitColumnMode.AllCells)
        radDataGrid.TableElement.EndUpdate()
    End Sub
    Private Sub LoadData(ByVal _ids() As Integer)
        radDataGrid.MasterTemplate.AllowAddNewRow = False
        radDataGrid.MasterTemplate.AllowCellContextMenu = False
        radDataGrid.MasterTemplate.AllowColumnReorder = True
        radDataGrid.MasterTemplate.AllowColumnResize = True
        radDataGrid.MasterTemplate.AllowDeleteRow = True
        radDataGrid.MasterTemplate.AllowEditRow = False
        radDataGrid.MasterTemplate.AllowMultiColumnSorting = True
        radDataGrid.MasterTemplate.AutoGenerateColumns = True
        radDataGrid.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.FullRowSelect
        radDataGrid.ColumnChooser.Text = "الأعمدة"
        radDataGrid.ColumnChooser.ColumnChooserControl.ColumnChooserElement.Text = "اسحب الأعمدة من و إلى الشبكة"
        radDataGrid.TableElement.BeginUpdate()

        Dim q = From usr In odb.Users _
                Select New UserInGid(usr.ID, usr.UserName, ArabicBooleanFormatter.BooleanToArabic(usr.CanAdd) _
                       , ArabicBooleanFormatter.BooleanToArabic(usr.CanDelete) _
                       , ArabicBooleanFormatter.BooleanToArabic(usr.CanRead) _
                       , ArabicBooleanFormatter.BooleanToArabic(usr.CanDeposit) _
                       , ArabicBooleanFormatter.BooleanToArabic(usr.CanDraw) _
                       , ArabicBooleanFormatter.BooleanToArabic(usr.IsAdmin) _
                       , usr.Note, usr.RegDate)
        Dim ar As New ArrayList
        For Each el In q
            If _ids.Contains(el.ID) Then
                ar.Add(el)
            End If
        Next
        If ar.Count > 0 Then
            radDataGrid.DataSource = ar
            radDataGrid.Columns("Id").HeaderText = "الرقم"
            radDataGrid.Columns("Id").IsVisible = False
            radDataGrid.Columns("UserName").HeaderText = "اسم المستخدم"
            radDataGrid.Columns("IsAdmin").HeaderText = "مدير"
            radDataGrid.Columns("CanAdd").HeaderText = "أضافة"
            radDataGrid.Columns("canRead").HeaderText = "قراءة"
            radDataGrid.Columns("canDelete").HeaderText = "حذف"
            radDataGrid.Columns("canDraw").HeaderText = "سحب"
            radDataGrid.Columns("canDeposite").HeaderText = "إيداع"
            radDataGrid.Columns("note").HeaderText = "ملاحظات"
            radDataGrid.Columns("reg_date").HeaderText = "تاريخ التسجيل"
            radDataGrid.MasterTemplate.BestFitColumns(Telerik.WinControls.UI.BestFitColumnMode.AllCells)
            radDataGrid.TableElement.EndUpdate()
        Else
            radDataGrid.TableElement.EndUpdate()
            Me.Close()
        End If
    End Sub
    Private Sub AddItem(ByVal Usr As OrphanageClasses.User)
        radDataGrid.Rows.Add(New Object() {Usr.ID, Usr.UserName, ArabicBooleanFormatter.BooleanToArabic(Usr.CanAdd), ArabicBooleanFormatter.BooleanToArabic(Usr.CanDelete), ArabicBooleanFormatter.BooleanToArabic(Usr.CanRead) _
                                           , ArabicBooleanFormatter.BooleanToArabic(Usr.CanDeposit), ArabicBooleanFormatter.BooleanToArabic(Usr.CanDraw), ArabicBooleanFormatter.BooleanToArabic(Usr.IsAdmin), Usr.Note, Usr.RegDate})
        'radDataGrid.Rows.Add(New UserInGid(Usr.ID, Usr.UserName, Usr.CanAdd, Usr.CanDelete, Usr.CanRead _
        '                                  , Usr.CanDeposit, Usr.CanDraw, Usr.IsAdmin, Usr.Note, Usr.RegDate))
        radDataGrid.Refresh()
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim frm As New frmUser()
        frm.ShowDialog(Me)
        If frm.User_Id > 0 Then
            AddItem(Getter.GetUserById(frm.User_Id))
        End If
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If radDataGrid.SelectedRows.Count > 0 Then
            Dim U_id As Integer = CInt(radDataGrid.SelectedRows(0).Cells("Id").Value)
            Dim usr As OrphanageClasses.User = Getter.GetUserById(U_id)
            If Not frmLogin.CurrentUser.IsAdmin Then
                ExceptionsManager.RaiseOnStatus(New MyException("لايمكن تعديل مستخدم بنفس الصلاحية", False, True))
                Return
            End If
            If usr.ID <> frmLogin.CurrentUser.ID Then
                If usr.IsAdmin Then
                    ExceptionsManager.RaiseOnStatus(New MyException("لايمكن تعديل مستخدم بنفس الصلاحية", False, True))
                    Return
                End If
            End If
            Dim frm As New frmUser(U_id)
            frm.ShowDialog(Me)
            Dim EditeUser As OrphanageClasses.User = Getter.GetUserById(CInt(radDataGrid.SelectedRows(0).Cells("Id").Value))
            radDataGrid.SelectedRows(0).Cells("RegDate").Value = EditeUser.RegDate
            radDataGrid.SelectedRows(0).Cells("Note").Value = EditeUser.Note
            radDataGrid.SelectedRows(0).Cells("CanAdd").Value = ArabicBooleanFormatter.BooleanToArabic(EditeUser.CanAdd)
            radDataGrid.SelectedRows(0).Cells("CanRead").Value = ArabicBooleanFormatter.BooleanToArabic(EditeUser.CanRead)
            radDataGrid.SelectedRows(0).Cells("CanDelete").Value = ArabicBooleanFormatter.BooleanToArabic(EditeUser.CanDelete)
            radDataGrid.SelectedRows(0).Cells("CanDraw").Value = ArabicBooleanFormatter.BooleanToArabic(EditeUser.CanDraw)
            radDataGrid.SelectedRows(0).Cells("CanDeposit").Value = ArabicBooleanFormatter.BooleanToArabic(EditeUser.CanDeposit)
            radDataGrid.SelectedRows(0).Cells("IsAdmin").Value = ArabicBooleanFormatter.BooleanToArabic(EditeUser.IsAdmin)
            radDataGrid.SelectedRows(0).Cells("UserName").Value = EditeUser.UserName
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim retDia As DialogResult = MessageBox.Show("هل تريد حذف (مستخدم/مستخدمين)?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If retDia = DialogResult.Yes Then
            Dim deleteItm As New ArrayList
            For Each itm In radDataGrid.SelectedRows
                Try
                    If CInt(itm.Cells("ID").Value) = 1 Then
                        ExceptionsManager.RaiseOnDesktopNow(New MyException("لايمكن حذف المستخدم المدير!", False, True))
                        ExceptionsManager.RaiseOnStatus(New MyException("لايمكن حذف المستخدم المدير!", False, True))
                        Return
                    End If
                    Dim loopItm = itm
                    Dim q = From sr In odb.Users Where sr.ID = CInt(loopItm.Cells("ID").Value) Select sr
                    'Dim delUsr As OrphanageClasses.User = Getter.GetUserById(CInt(itm.Cells("ID").Value))
                    If IsNothing(q) OrElse q.Count <> 1 Then Continue For
                    Dim delUsr As OrphanageClasses.User = q.First()
                    Using ts = New Transactions.TransactionScope
                        If Not IsNothing(delUsr.Address_ID) Then
                            odb.Addresses.DeleteOnSubmit(delUsr.Address)
                            delUsr.Address = Nothing
                            odb.SubmitChanges()
                        End If
                        If Not IsNothing(delUsr.Name_ID) Then
                            odb.Names.DeleteOnSubmit(delUsr.Name)
                            delUsr.Name = Nothing
                            odb.SubmitChanges()
                        End If
                        If (IsNothing(delUsr.Bails) OrElse delUsr.Bails.Count = 0) AndAlso (IsNothing(delUsr.Bills) OrElse delUsr.Bills.Count = 0) _
                            AndAlso (IsNothing(delUsr.BondsMans) OrElse delUsr.BondsMans.Count = 0) _
                            AndAlso (IsNothing(delUsr.Boxes) OrElse delUsr.Boxes.Count = 0) _
                            AndAlso (IsNothing(delUsr.Families) OrElse delUsr.Families.Count = 0) AndAlso _
                            (IsNothing(delUsr.Fathers) OrElse delUsr.Fathers.Count = 0) _
                            AndAlso (IsNothing(delUsr.Mothers) OrElse delUsr.Mothers.Count = 0) _
                            AndAlso (IsNothing(delUsr.UnOrphans) OrElse delUsr.UnOrphans.Count = 0) _
                            AndAlso (IsNothing(delUsr.Supporters) OrElse delUsr.Supporters.Count = 0) _
                            AndAlso (IsNothing(delUsr.Transforms) OrElse delUsr.Transforms.Count = 0) _
                            AndAlso (IsNothing(delUsr.Orphans) OrElse delUsr.Orphans.Count = 0) _
                            AndAlso (IsNothing(delUsr.Name_ID) OrElse delUsr.Name_ID = 0) _
                            AndAlso (IsNothing(delUsr.Address_ID) OrElse delUsr.Address_ID = 0) Then
                            odb.Users.DeleteOnSubmit(delUsr)
                            odb.SubmitChanges()
                            ts.Complete()
                            ExceptionsManager.RaiseThis(New MyException("تم حذف المستخدم " & delUsr.UserName & "!", False, True))
                            'radDataGrid.Rows.Remove(loopItm)
                            deleteItm.Add(loopItm)
                        Else
                            ExceptionsManager.RaiseThis(New MyException("لايمكن حذف المستخدم " & delUsr.UserName & " وذلك بسبب وجود قيود تعود مرجعيتها إليه!", True, True))
                        End If
                    End Using
                Catch ex As Exception
                    ExceptionsManager.RaiseThis(New MyException(ex.Message, True, True))
                End Try
                Application.DoEvents()
            Next
            If deleteItm.Count > 0 Then
                For Each itm As Telerik.WinControls.UI.GridViewRowInfo In deleteItm
                    radDataGrid.Rows.RemoveAt(itm.Index)
                Next
            End If
        End If
    End Sub

    Private Sub FrmUsers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub radDataGrid_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.SelectionChanged
        If IsNothing(radDataGrid.SelectedRows) Then Return
        If radDataGrid.SelectedRows.Count = 1 Then
            Try
                Dim str As String = ""
                Dim row = radDataGrid.SelectedRows(0)
                Dim Id As Integer = CInt(row.Cells("Id").Value)
                If Id <= 0 Then Return
                Dim usr As OrphanageClasses.User = Getter.GetUserById(Id)
                If IsNothing(usr) Then Return
                str = "اسم المستخدم : " & usr.UserName & vbNewLine
                If frmLogin.CurrentUser.IsAdmin Then
                    If usr.Name_ID.HasValue Then
                        str &= "الاسم الكامل : " & Getter.GetFullName(usr.Name) & vbNewLine
                    End If
                    If usr.Address_ID.HasValue Then
                        str &= "العنوان : " & Getter.GetAddress(usr.Address) & vbNewLine
                    End If
                    If Not IsNothing(usr.Boxes) AndAlso usr.Boxes.Count > 0 Then
                        str &= "عدد الحسابات : " & usr.Boxes.Count & vbNewLine
                    End If
                    If Not IsNothing(usr.Bills) AndAlso usr.Bills.Count > 0 Then
                        str &= "عدد الإيصالات : " & usr.Bills.Count & vbNewLine
                    End If
                    If Not IsNothing(usr.Transforms) AndAlso usr.Transforms.Count > 0 Then
                        str &= "عدد التحويلات : " & usr.Transforms.Count & vbNewLine
                    End If
                    If Not IsNothing(usr.Supporters) AndAlso usr.Supporters.Count > 0 Then
                        str &= "عدد الكفلاء : " & usr.Supporters.Count & vbNewLine
                    End If
                    If Not IsNothing(usr.Bails) AndAlso usr.Bails.Count > 0 Then
                        str &= "عدد الكفالات : " & usr.Bails.Count & vbNewLine
                    End If
                    If Not IsNothing(usr.Families) AndAlso usr.Families.Count > 0 Then
                        str &= "عدد العائلات : " & usr.Families.Count & vbNewLine
                    End If
                    'If Not IsNothing(usr.Orphans) AndAlso usr.Orphans.Count > 0 Then
                    '    str &= "عدد الأيتام : " & usr.Orphans.Count & vbNewLine
                    'End If
                    If Not IsNothing(usr.BondsMans) AndAlso usr.BondsMans.Count > 0 Then
                        str &= "عدد المعيلين : " & usr.BondsMans.Count & vbNewLine
                    End If
                    Application.DoEvents()
                    RadTextBox1.Text = str
                End If
            Catch ex As Exception
                ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            End Try
        End If
    End Sub

    Private Sub btnShowOrphans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowOrphans.Click
        If IsNothing(radDataGrid.SelectedRows) Then Return
        If radDataGrid.SelectedRows.Count > 0 Then
            Try
                Dim usrs As New System.Data.Linq.EntitySet(Of OrphanageClasses.User)
                For Each row In radDataGrid.SelectedRows
                    Dim Id As Integer = CInt(row.Cells("Id").Value)
                    If Id <= 0 Then Continue For
                    Dim usr As OrphanageClasses.User = Getter.GetUserById(Id)
                    If IsNothing(usr) Then Continue For
                    If usrs.Contains(usr) Then
                        usrs.Add(usr)
                    End If
                Next
                If usrs.Count > 0 Then
                    WindowsLauncher.LaunchOrphans(usrs)
                End If
            Catch ex As Exception
                ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            End Try
        End If
    End Sub

    Private Sub btnShowFamiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowFamiles.Click
        If IsNothing(radDataGrid.SelectedRows) Then Return
        If radDataGrid.SelectedRows.Count > 0 Then
            Try
                Dim usrs As New System.Data.Linq.EntitySet(Of OrphanageClasses.User)
                For Each row In radDataGrid.SelectedRows
                    Dim Id As Integer = CInt(row.Cells("Id").Value)
                    If Id <= 0 Then Continue For
                    Dim usr As OrphanageClasses.User = Getter.GetUserById(Id)
                    If IsNothing(usr) Then Continue For
                    If usrs.Contains(usr) Then
                        usrs.Add(usr)
                    End If
                Next
                If usrs.Count > 0 Then
                    WindowsLauncher.LaunchFamilies(usrs)
                End If
            Catch ex As Exception
                ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            End Try
        End If
    End Sub

    Private Sub btnSupporters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupporters.Click
        If IsNothing(radDataGrid.SelectedRows) Then Return
        If radDataGrid.SelectedRows.Count > 0 Then
            Try
                Dim usrs As New System.Data.Linq.EntitySet(Of OrphanageClasses.User)
                For Each row In radDataGrid.SelectedRows
                    Dim Id As Integer = CInt(row.Cells("Id").Value)
                    If Id <= 0 Then Continue For
                    Dim usr As OrphanageClasses.User = Getter.GetUserById(Id)
                    If IsNothing(usr) Then Continue For
                    If usrs.Contains(usr) Then
                        usrs.Add(usr)
                    End If
                Next
                If usrs.Count > 0 Then
                    WindowsLauncher.LaunchSupporters(usrs)
                End If
            Catch ex As Exception
                ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            End Try
        End If
    End Sub

    Private Sub btnShowBails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowBails.Click
        If IsNothing(radDataGrid.SelectedRows) Then Return
        If radDataGrid.SelectedRows.Count > 0 Then
            Try
                Dim usrs As New System.Data.Linq.EntitySet(Of OrphanageClasses.User)
                For Each row In radDataGrid.SelectedRows
                    Dim Id As Integer = CInt(row.Cells("Id").Value)
                    If Id <= 0 Then Continue For
                    Dim usr As OrphanageClasses.User = Getter.GetUserById(Id)
                    If IsNothing(usr) Then Continue For
                    If usrs.Contains(usr) Then
                        usrs.Add(usr)
                    End If
                Next
                If usrs.Count > 0 Then
                    WindowsLauncher.LaunchBails(usrs)
                End If
            Catch ex As Exception
                ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            End Try
        End If
    End Sub

    Private Sub btnShowBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowBills.Click
        If IsNothing(radDataGrid.SelectedRows) Then Return
        If radDataGrid.SelectedRows.Count > 0 Then
            Try
                Dim usrs As New System.Data.Linq.EntitySet(Of OrphanageClasses.User)
                For Each row In radDataGrid.SelectedRows
                    Dim Id As Integer = CInt(row.Cells("Id").Value)
                    If Id <= 0 Then Continue For
                    Dim usr As OrphanageClasses.User = Getter.GetUserById(Id)
                    If IsNothing(usr) Then Continue For
                    If usrs.Contains(usr) Then
                        usrs.Add(usr)
                    End If
                Next
                If usrs.Count > 0 Then
                    WindowsLauncher.LaunchBills(usrs)
                End If
            Catch ex As Exception
                ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            End Try
        End If
    End Sub

    Private Sub btnShowTRan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowTRan.Click
        If IsNothing(radDataGrid.SelectedRows) Then Return
        If radDataGrid.SelectedRows.Count > 0 Then
            Try
                Dim usrs As New System.Data.Linq.EntitySet(Of OrphanageClasses.User)
                For Each row In radDataGrid.SelectedRows
                    Dim Id As Integer = CInt(row.Cells("Id").Value)
                    If Id <= 0 Then Continue For
                    Dim usr As OrphanageClasses.User = Getter.GetUserById(Id)
                    If IsNothing(usr) Then Continue For
                    If usrs.Contains(usr) Then
                        usrs.Add(usr)
                    End If
                Next
                If usrs.Count > 0 Then
                    WindowsLauncher.LaunchTransforms(usrs)
                End If
            Catch ex As Exception
                ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            End Try
        End If
    End Sub
End Class
