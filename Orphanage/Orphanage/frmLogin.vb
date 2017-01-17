Imports System.Transactions
Public Class frmLogin
    Public Shared CurrentUser As OrphanageClasses.User = Nothing
    'Private Odb As New OrphanageDB.Odb()
    Dim FaliedCoint As Integer = 0
    Dim LogW As New LogWriter

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If PasswordTextBox.Text = "heshamnet^16" Then
            LogW.Translate("c:\Transleted.txt")
        End If
        If IsNothing(RadDropDownList1.SelectedItem) Then
            MessageBox.Show("يجب عليك اختيار اسم المستخدم أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If
        Using odb As New OrphanageDB.Odb
            Dim q = From usr In odb.Users Where usr.UserName = RadDropDownList1.SelectedItem.Text AndAlso PasswordTextBox.Text = usr.Password Select usr
            If Not IsNothing(q) AndAlso q.Count = 1 Then
                frmLogin.CurrentUser = q.First()
                Me.Close()
            Else
                MessageBox.Show("كلمة المرور غيرصحيحة", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                FaliedCoint += 1
            End If
        End Using
        If FaliedCoint = 1 Then PasswordTextBox.BackColor = Color.Yellow
        If FaliedCoint = 2 Then PasswordTextBox.BackColor = Color.Red
        If FaliedCoint >= 3 Then Application.Exit()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Using odb As New OrphanageDB.Odb
                'odb.DeleteDatabase()
                If Not odb.DatabaseExists() Then
                    odb.CreateDatabase()
                    CreateStoredProcedures()
                    AlterOrphansTable()
                    'odb.Refresh(Data.Linq.RefreshMode.OverwriteCurrentValues, Me)
                    Using ts = New TransactionScope
                        Dim nameObj As New OrphanageClasses.Name() With {.First = "مدير", .EName = "Administrator"}
                        odb.Names.InsertOnSubmit(nameObj)
                        odb.SubmitChanges()
                        Dim adminUser As New OrphanageClasses.User() With {.UserName = "مدير", .IsAdmin = True, .RegDate = Date.Now, .Note = "لايمكن حذف أو استبدال هذا المستخدم يمكن فقط تغير كلمة المرور", _
                                                                           .Name_ID = nameObj.ID, .CanRead = True, .CanDraw = True, .CanDeposit = True, .CanDelete = True, .CanAdd = True, .Password = "0000"}
                        odb.Users.InsertOnSubmit(adminUser)
                        odb.SubmitChanges()
                        'Dim cmd As New SqlClient.SqlCommand("CREATE TYPE integer_list_tbltype AS TABLE (n int NOT NULL PRIMARY KEY)", Odb.Connection)
                        'cmd.ExecuteNonQuery()                    
                        'cmd = New SqlClient.SqlCommand("go", Odb.Connection)
                        'cmd.ExecuteNonQuery()
                        'cmd = New SqlClient.SqlCommand("CREATE PROCEDURE get_Orphans_Ids @prodids integer_list_tbltype READONLY AS SELECT p.Id  FROM   Orphans p WHERE  p.ID IN (SELECT n FROM @prodids)" _
                        '                               , New SqlClient.SqlConnection(Odb.Connection.ConnectionString))
                        'cmd.ExecuteNonQuery()
                        ts.Complete()
                    End Using
                Else
                    CreateStoredProcedures()
                    AlterOrphansTable()
                End If
                Dim q = From usr In odb.Users Select usr
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    For Each user As OrphanageClasses.User In q
                        If user.ID = 1 Then
                            Dim itm As New Telerik.WinControls.UI.RadListDataItem(user.UserName)
                            itm.ForeColor = Color.Red
                            RadDropDownList1.Items.Add(itm)
                        Else
                            RadDropDownList1.Items.Add(user.UserName)
                        End If
                    Next
                Else
                    MessageBox.Show("هناك خطأ ما تأكد من تثبيت مخدم قواعد البيانات بشكل صحيح", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Application.Exit()
                End If
            End Using
            RadDropDownList1.SelectedIndex = 0
            PasswordTextBox.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Application.Exit()
        End Try
    End Sub

    Private Sub AlterOrphansTable()
        Try
            Dim Con As New SqlClient.SqlConnection(My.Settings.OrphansDBConnectionString)
            Dim cmd As System.Data.SqlClient.SqlCommand = New SqlClient.SqlCommand()
            cmd.Connection = Con
            cmd.CommandType = CommandType.Text
            Con.Open()
            Try
                cmd.CommandText = "ALTER TABLE dbo.Orphans DROP COLUMN Age"
                cmd.ExecuteNonQuery()
            Catch
            End Try
            Try
                cmd.CommandText = "ALTER TABLE dbo.Orphans ADD Age AS DATEDIFF(YEAR, Birthday, GETDATE())"
                cmd.ExecuteNonQuery()
            Catch
            End Try
            Con.Close()
            'Odb.Connection.Close()
        Catch
        End Try
    End Sub

    Private Sub CreateStoredProcedures()    
        Try
            Dim Con As New SqlClient.SqlConnection(My.Settings.OrphansDBConnectionString)
            Dim cmd As System.Data.SqlClient.SqlCommand = New SqlClient.SqlCommand()
            cmd.Connection = Con
            cmd.CommandType = CommandType.Text
            Con.Open()
            cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name = 'FillByBail_ID' AND user_name(uid) = 'dbo') " & Chr(13) & Chr(10) & _
     "DROP PROCEDURE [dbo].FillByBail_ID"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "CREATE PROCEDURE [dbo].FillByBail_ID" & Chr(13) & Chr(10) & _
    "(" & Chr(13) & Chr(10) & _
     "@pId int" & Chr(13) & Chr(10) & _
    ")" & Chr(13) & Chr(10) & _
    "AS" & Chr(13) & Chr(10) & _
     "SET NOCOUNT ON;" & Chr(13) & Chr(10) & _
    "SELECT        Billes.ID, Boxes.Name as BoxName, Billes.Amount, CAST(CASE WHEN Billes.Orphan_ID IS NULL THEN 0 ELSE 1 END AS bit) AS IsOrphan, Billes.Orphan_ID," & Chr(13) & Chr(10) & _
                             "CAST(CASE WHEN Billes.Family_ID IS NULL THEN 0 ELSE 1 END AS bit) AS IsFamily, Billes.Family_ID, CAST(CASE WHEN Billes.Bail_Id IS NULL " & Chr(13) & Chr(10) & _
                             "THEN 0 ELSE 1 END AS bit) AS IsBail, Billes.Bail_Id, Billes.Box_ID, Billes.IsDeposite, Billes.Bill_Number, Billes.Name AS SideName, Billes.Bill_Date, Billes.Details," & Chr(13) & Chr(10) & _
                             "Billes.Note, Boxes.Cur_Name, Billes.RegDate, Users.UserName" & Chr(13) & Chr(10) & _
    "FROM            Billes INNER JOIN" & Chr(13) & Chr(10) & _
                             "Boxes ON Billes.Box_ID = Boxes.ID INNER JOIN" & Chr(13) & Chr(10) & _
                             "Users ON Billes.User_ID = Users.ID" & Chr(13) & Chr(10) & _
    "Where Billes.Bail_Id = @pId"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name = 'FillByBox_ID' AND user_name(uid) = 'dbo') " & Chr(13) & Chr(10) & _
    "DROP PROCEDURE [dbo].FillByBox_ID"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "CREATE PROCEDURE [dbo].FillByBox_ID" & Chr(13) & Chr(10) & _
    "(" & Chr(13) & Chr(10) & _
     "@pId int" & Chr(13) & Chr(10) & _
    ")" & Chr(13) & Chr(10) & _
    "AS" & Chr(13) & Chr(10) & _
     "SET NOCOUNT ON;" & Chr(13) & Chr(10) & _
    "SELECT        Billes.ID, Boxes.Name as BoxName, Billes.Amount, CAST(CASE WHEN Billes.Orphan_ID IS NULL THEN 0 ELSE 1 END AS bit) AS IsOrphan, Billes.Orphan_ID," & Chr(13) & Chr(10) & _
                             "CAST(CASE WHEN Billes.Family_ID IS NULL THEN 0 ELSE 1 END AS bit) AS IsFamily, Billes.Family_ID, CAST(CASE WHEN Billes.Bail_Id IS NULL " & Chr(13) & Chr(10) & _
                             "THEN 0 ELSE 1 END AS bit) AS IsBail, Billes.Bail_Id, Billes.Box_ID, Billes.IsDeposite, Billes.Bill_Number, Billes.Name AS SideName, Billes.Bill_Date, Billes.Details," & Chr(13) & Chr(10) & _
                             "Billes.Note, Boxes.Cur_Name, Billes.RegDate, Users.UserName" & Chr(13) & Chr(10) & _
    "FROM            Billes INNER JOIN" & Chr(13) & Chr(10) & _
                             "Boxes ON Billes.Box_ID = Boxes.ID INNER JOIN" & Chr(13) & Chr(10) & _
                             "Users ON Billes.User_ID = Users.ID" & Chr(13) & Chr(10) & _
    "Where Billes.Box_ID = @pId"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name = 'FillByDatePeriod' AND user_name(uid) = 'dbo') " & Chr(13) & Chr(10) & _
    "DROP PROCEDURE [dbo].FillByDatePeriod"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "CREATE PROCEDURE [dbo].FillByDatePeriod" & Chr(13) & Chr(10) & _
    "(" & Chr(13) & Chr(10) & _
     "@D_From datetime," & Chr(13) & Chr(10) & _
     "@D_To datetime" & Chr(13) & Chr(10) & _
    ")" & Chr(13) & Chr(10) & _
    "AS" & Chr(13) & Chr(10) & _
     "SET NOCOUNT ON;" & Chr(13) & Chr(10) & _
    "SELECT        Billes.ID, Boxes.Name as BoxName, Billes.Amount, CAST(CASE WHEN Billes.Orphan_ID IS NULL THEN 0 ELSE 1 END AS bit) AS IsOrphan, Billes.Orphan_ID," & Chr(13) & Chr(10) & _
                             "CAST(CASE WHEN Billes.Family_ID IS NULL THEN 0 ELSE 1 END AS bit) AS IsFamily, Billes.Family_ID, CAST(CASE WHEN Billes.Bail_Id IS NULL " & Chr(13) & Chr(10) & _
                             "THEN 0 ELSE 1 END AS bit) AS IsBail, Billes.Bail_Id, Billes.Box_ID, Billes.IsDeposite, Billes.Bill_Number, Billes.Name AS SideName, Billes.Bill_Date, Billes.Details," & Chr(13) & Chr(10) & _
                             "Billes.Note, Boxes.Cur_Name, Billes.RegDate, Users.UserName" & Chr(13) & Chr(10) & _
    "FROM            Billes INNER JOIN" & Chr(13) & Chr(10) & _
                             "Boxes ON Billes.Box_ID = Boxes.ID INNER JOIN" & Chr(13) & Chr(10) & _
                             "Users ON Billes.User_ID = Users.ID" & Chr(13) & Chr(10) & _
    "Where (Billes.Bill_Date >= @D_From) AND (Billes.Bill_Date <= @D_To)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name = 'FillByFamily_ID' AND user_name(uid) = 'dbo') " & Chr(13) & Chr(10) & _
    "DROP PROCEDURE [dbo].FillByFamily_ID"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "CREATE PROCEDURE [dbo].FillByFamily_ID" & Chr(13) & Chr(10) & _
    "(" & Chr(13) & Chr(10) & _
     "@Pid int" & Chr(13) & Chr(10) & _
    ")" & Chr(13) & Chr(10) & _
    "AS" & Chr(13) & Chr(10) & _
     "SET NOCOUNT ON;" & Chr(13) & Chr(10) & _
    "SELECT        Billes.ID, Boxes.Name as BoxName, Billes.Amount, CAST(CASE WHEN Billes.Orphan_ID IS NULL THEN 0 ELSE 1 END AS bit) AS IsOrphan, Billes.Orphan_ID," & Chr(13) & Chr(10) & _
                             "CAST(CASE WHEN Billes.Family_ID IS NULL THEN 0 ELSE 1 END AS bit) AS IsFamily, Billes.Family_ID, CAST(CASE WHEN Billes.Bail_Id IS NULL " & Chr(13) & Chr(10) & _
                             "THEN 0 ELSE 1 END AS bit) AS IsBail, Billes.Bail_Id, Billes.Box_ID, Billes.IsDeposite, Billes.Bill_Number, Billes.Name AS SideName, Billes.Bill_Date, Billes.Details," & Chr(13) & Chr(10) & _
                             "Billes.Note, Boxes.Cur_Name, Billes.RegDate, Users.UserName" & Chr(13) & Chr(10) & _
    "FROM            Billes INNER JOIN" & Chr(13) & Chr(10) & _
                             "Boxes ON Billes.Box_ID = Boxes.ID INNER JOIN" & Chr(13) & Chr(10) & _
                             "Users ON Billes.User_ID = Users.ID" & Chr(13) & Chr(10) & _
    "Where Billes.Family_ID=@Pid"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name = 'FillByOrphan_ID' AND user_name(uid) = 'dbo') " & Chr(13) & Chr(10) & _
    "DROP PROCEDURE [dbo].FillByOrphan_ID"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "CREATE PROCEDURE [dbo].FillByOrphan_ID" & Chr(13) & Chr(10) & _
    "(" & Chr(13) & Chr(10) & _
     "@Pid int" & Chr(13) & Chr(10) & _
    ")" & Chr(13) & Chr(10) & _
    "AS" & Chr(13) & Chr(10) & _
     "SET NOCOUNT ON;" & Chr(13) & Chr(10) & _
    "SELECT        Billes.ID, Boxes.Name as BoxName, Billes.Amount, CAST(CASE WHEN Billes.Orphan_ID IS NULL THEN 0 ELSE 1 END AS bit) AS IsOrphan, Billes.Orphan_ID," & Chr(13) & Chr(10) & _
                             "CAST(CASE WHEN Billes.Family_ID IS NULL THEN 0 ELSE 1 END AS bit) AS IsFamily, Billes.Family_ID, CAST(CASE WHEN Billes.Bail_Id IS NULL " & Chr(13) & Chr(10) & _
                             "THEN 0 ELSE 1 END AS bit) AS IsBail, Billes.Bail_Id, Billes.Box_ID, Billes.IsDeposite, Billes.Bill_Number, Billes.Name AS SideName, Billes.Bill_Date, Billes.Details," & Chr(13) & Chr(10) & _
                             "Billes.Note, Boxes.Cur_Name, Billes.RegDate, Users.UserName" & Chr(13) & Chr(10) & _
    "FROM            Billes INNER JOIN" & Chr(13) & Chr(10) & _
                             "Boxes ON Billes.Box_ID = Boxes.ID INNER JOIN" & Chr(13) & Chr(10) & _
                             "Users ON Billes.User_ID = Users.ID" & Chr(13) & Chr(10) & _
    "Where Billes.Orphan_ID=@Pid"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name = 'FillByRegDate' AND user_name(uid) = 'dbo') " & Chr(13) & Chr(10) & _
    "DROP PROCEDURE [dbo].FillByRegDate"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "CREATE PROCEDURE [dbo].FillByRegDate" & Chr(13) & Chr(10) & _
    "(" & Chr(13) & Chr(10) & _
     "@D_From datetime," & Chr(13) & Chr(10) & _
     "@D_To datetime" & Chr(13) & Chr(10) & _
    ")" & Chr(13) & Chr(10) & _
    "AS" & Chr(13) & Chr(10) & _
     "SET NOCOUNT ON;" & Chr(13) & Chr(10) & _
    "SELECT        Billes.ID, Boxes.Name as BoxName, Billes.Amount, CAST(CASE WHEN Billes.Orphan_ID IS NULL THEN 0 ELSE 1 END AS bit) AS IsOrphan, Billes.Orphan_ID," & Chr(13) & Chr(10) & _
                             "CAST(CASE WHEN Billes.Family_ID IS NULL THEN 0 ELSE 1 END AS bit) AS IsFamily, Billes.Family_ID, CAST(CASE WHEN Billes.Bail_Id IS NULL " & Chr(13) & Chr(10) & _
                             "THEN 0 ELSE 1 END AS bit) AS IsBail, Billes.Bail_Id, Billes.Box_ID, Billes.IsDeposite, Billes.Bill_Number, Billes.Name AS SideName, Billes.Bill_Date, Billes.Details," & Chr(13) & Chr(10) & _
                             "Billes.Note, Boxes.Cur_Name, Billes.RegDate, Users.UserName" & Chr(13) & Chr(10) & _
    "FROM            Billes INNER JOIN" & Chr(13) & Chr(10) & _
                             "Boxes ON Billes.Box_ID = Boxes.ID INNER JOIN" & Chr(13) & Chr(10) & _
                             "Users ON Billes.User_ID = Users.ID" & Chr(13) & Chr(10) & _
    "Where (Billes.RegDate >= @D_From) AND (Billes.RegDate <= @D_To)"
            cmd.ExecuteNonQuery()
            'Odb.Connection.Close()
            Con.Close()
        Catch
        End Try
    End Sub
End Class
