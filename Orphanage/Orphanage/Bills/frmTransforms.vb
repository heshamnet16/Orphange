Imports Telerik.WinControls.UI

Public Class FrmTransforms
    Private StrCount As String = ""
    Private _Box As OrphanageClasses.Box = Nothing
    Private _Boxs As System.Data.Linq.EntitySet(Of OrphanageClasses.Box) = Nothing
    Private _Ids() As Integer = Nothing
    Public Function GetPrintedDocumnent() As Telerik.WinControls.UI.RadPrintDocument
        Return Me.RadPrintDocument1
    End Function
    Public Function GetGridView() As Telerik.WinControls.UI.RadGridView
        Return Me.radDataGrid
    End Function
    Public Sub PrintDocument(ByVal doc As RadPrintDocument)
        Me.radDataGrid.Print(True, doc)
    End Sub
    Public Sub SetGridFont(ByVal fon As Font)
        Me.Font = fon
        radDataGrid.Font = fon
        radDataGrid.PrintStyle.CellFont = fon
        radDataGrid.Refresh()
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal bx As OrphanageClasses.Box)
        InitializeComponent()
        Me._Box = bx
    End Sub
    Public Sub New(ByVal bx As System.Data.Linq.EntitySet(Of OrphanageClasses.Box))
        InitializeComponent()
        Me._Boxs = bx
    End Sub
    Public Sub New(ByVal ids() As Integer)
        InitializeComponent()
        Me._Ids = ids
    End Sub

#Region "UpdateRows"
    Private Sub DeletesTransform(ByVal bx As Integer)
        For Each row In radDataGrid.Rows
            Dim id As Integer = CInt(row.Cells("ID").Value)
            If id = bx Then
                row.IsVisible = False
                Exit For
            End If
            Application.DoEvents()
        Next
    End Sub
    Private Sub AddNewTransform(ByVal bx As OrphanageClasses.Transform)
        Dim xx As GridViewRowInfo
        Try
            xx = radDataGrid.Rows.AddNew()
        Catch ex As Exception
            Return
        End Try
        xx.Cells("ID").Value = bx.ID
        xx.Cells("Tranc_Numb").Value = bx.Tranc_Number
        xx.Cells("Dest_Box").Value = bx.Box1.Name
        xx.Cells("Sourc_Box").Value = bx.Box.Name
        xx.Cells("Source_Amount").Value = bx.Source_Amount
        xx.Cells("Tranc_Price").Value = bx.Tranc_Price
        xx.Cells("Destination_Amount").Value = bx.Des_Amount
        xx.Cells("Details").Value = bx.Details
        xx.Cells("Tranc_Date").Value = bx.Tranc_Date
        xx.Cells("SourceBox_Id").Value = bx.SourceBox_ID
        xx.Cells("DestinationBox_ID").Value = bx.DestinationBox_ID
        xx.Cells("User_ID").Value = bx.User_ID
        xx.Cells("RegDate").Value = bx.RegDate
        xx.Cells("UserName").Value = bx.User.UserName
    End Sub
    Private Sub UpdatesTransform(ByVal bx As OrphanageClasses.Transform)
        For Each xx In radDataGrid.Rows
            Dim id As Integer = CInt(xx.Cells("ID").Value)
            If id = bx.ID Then
                xx.Cells("Tranc_Numb").Value = bx.Tranc_Number
                xx.Cells("Dest_Box").Value = bx.Box1.Name
                xx.Cells("Sourc_Box").Value = bx.Box.Name
                xx.Cells("Source_Amount").Value = bx.Source_Amount
                xx.Cells("Tranc_Price").Value = bx.Tranc_Price
                xx.Cells("Destination_Amount").Value = bx.Des_Amount
                xx.Cells("Details").Value = bx.Details
                xx.Cells("Tranc_Date").Value = bx.Tranc_Date
                xx.Cells("SourceBox_Id").Value = bx.SourceBox_ID
                xx.Cells("DestinationBox_ID").Value = bx.DestinationBox_ID
                xx.Cells("User_ID").Value = bx.User_ID
                xx.Cells("RegDate").Value = bx.RegDate
                xx.Cells("UserName").Value = bx.User.UserName
                Exit For
            End If
            Application.DoEvents()
        Next
    End Sub
#End Region

    Private Sub LoadData()
        If Not IsNothing(Me._Ids) AndAlso IsNothing(Me._Box) AndAlso IsNothing(Me._Boxs) Then
            Dim i As Integer = 0
            Dim all As Integer = _Ids.Count
            Dim PerValue = 0, LastPerValue As Integer = 0
            For Each id In Me._Ids
                Dim Tran As OrphanageClasses.Transform = Getter.GetTransformByID(id)
                i += 1
                PerValue = Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100))
                If Not IsNothing(Tran) Then
                    AddNewTransform(Tran)
                    If LastPerValue <> PerValue Then
                        ProgressSate.ShowStatueProgress(PerValue, "")
                        LastPerValue = PerValue
                        Application.DoEvents()
                    End If
                End If
            Next
            ProgressSate.ShowStatueProgress(100, "")
        ElseIf IsNothing(_Ids) AndAlso Not IsNothing(Me._Box) AndAlso IsNothing(Me._Boxs) Then
            Dim trans As New ArrayList()
            For Each tra In _Box.Transforms
                If Not Trans.Contains(tra.ID) Then
                    Trans.Add(tra.ID)
                    AddNewTransform(tra)
                End If
            Next
            For Each tra In _Box.Transforms1
                If Not Trans.Contains(tra.ID) Then
                    Trans.Add(tra.ID)
                    AddNewTransform(tra)
                End If
            Next
        ElseIf IsNothing(_Ids) AndAlso IsNothing(Me._Box) AndAlso Not IsNothing(Me._Boxs) Then
            Dim i As Integer = 0
            Dim all As Integer = _Boxs.Count
            Dim PerValue = 0, LastPerValue As Integer = 0
            Dim Trans As New ArrayList()
            For Each bx In Me._Boxs
                i += 1
                PerValue = Math.Floor((CDbl(i) / CDbl(all)) * CDbl(100))
                If Not IsNothing(bx) Then
                    For Each tra In bx.Transforms
                        If Not Trans.Contains(tra.ID) Then
                            Trans.Add(tra.ID)
                            AddNewTransform(tra)
                        End If
                    Next
                    For Each tra In bx.Transforms1
                        If Not Trans.Contains(tra.ID) Then
                            Trans.Add(tra.ID)
                            AddNewTransform(tra)
                        End If
                    Next
                    If LastPerValue <> PerValue Then
                        ProgressSate.ShowStatueProgress(PerValue, "")
                        LastPerValue = PerValue
                        Application.DoEvents()
                    End If
                End If
            Next
            ProgressSate.ShowStatueProgress(100, "")
        Else
            Me.TransformsTableAdapter.Fill(Me.OrphansDBDataSet.Transforms)
        End If

        radDataGrid.TableElement.GridViewElement.GroupPanelElement.Text = "اسحب الاعمدة هنا"
        For Each elm In radDataGrid.TableElement.GridViewElement.GroupPanelElement.Children
            For Each elm1 In elm.Children
                For Each elm2 In elm1.Children
                    If TypeOf elm2 Is LightVisualElement Then
                        Dim Xobj As LightVisualElement = CType(elm2, LightVisualElement)
                        If Xobj.Text = "Group by:" Then
                            Xobj.Text = "تجميع بواسطة : "
                            Exit For
                        End If
                    End If
                Next
            Next
        Next
        Dim col As GridViewDecimalColumn = CType(radDataGrid.Columns("Source_Amount"), GridViewDecimalColumn)
        col.DecimalPlaces = My.Settings.DecimalPercion
        col.ThousandsSeparator = My.Settings.UseThousendSeprator
        col.FormatString = "{0:F" & My.Settings.DecimalPercion.ToString() & "}"
        Dim col1 As GridViewDecimalColumn = CType(radDataGrid.Columns("Destination_Amount"), GridViewDecimalColumn)
        col1.DecimalPlaces = My.Settings.DecimalPercion
        col1.ThousandsSeparator = My.Settings.UseThousendSeprator
        col1.FormatString = "{0:F" & My.Settings.DecimalPercion.ToString() & "}"
        Dim col2 As GridViewDecimalColumn = CType(radDataGrid.Columns("Tranc_Price"), GridViewDecimalColumn)
        col2.DecimalPlaces = My.Settings.DecimalPercion
        col2.ThousandsSeparator = My.Settings.UseThousendSeprator
        col2.FormatString = "{0:F" & My.Settings.DecimalPercion.ToString() & "}"
        If radDataGrid.RowCount > 0 Then
            StrCount = "العدد الكلي " & radDataGrid.RowCount
            lblStatus.Text = StrCount
        End If
    End Sub

    Private Sub FrmTransforms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        radDataGrid.MasterTemplate.AddNewBoundRowBeforeEdit = True
        LoadData()
        AddHandler Updater.NewTransform, AddressOf AddNewTransform
        AddHandler Updater.DeleteTransform, AddressOf DeletesTransform
        For Each elm In radDataGrid.TableElement.GridViewElement.GroupPanelElement.Children
            For Each elm1 In elm.Children
                For Each elm2 In elm1.Children
                    If TypeOf elm2 Is LightVisualElement Then
                        Dim Xobj As LightVisualElement = CType(elm2, LightVisualElement)
                        If Xobj.Text = "Group by:" Then
                            Xobj.Text = "تجميع بواسطة : "
                            Exit For
                        End If
                    End If
                Next
            Next
        Next
        If My.Settings.SaveGridState AndAlso IO.File.Exists("TransformsLayout.Xaml") Then
            radDataGrid.LoadLayout("TransformsLayout.Xaml")
        End If
        If My.Settings.SaveWindowsState Then
            Layouts.LoadFormLayout(Me)
        End If
    End Sub
    Private Sub FrmBoxes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.SaveGridState Then
            radDataGrid.SaveLayout("TransformsLayout.Xaml")
        End If
        If My.Settings.SaveWindowsState Then
            Layouts.SaveFormLayout(Me)
        End If
    End Sub
    Private Sub radDataGrid_GroupByChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCollectionChangedEventArgs) Handles radDataGrid.GroupByChanged
        radDataGrid.TableElement.GridViewElement.GroupPanelElement.Text = "اسحب الاعمدة هنا"
        For Each elm In radDataGrid.TableElement.GridViewElement.GroupPanelElement.Children
            For Each elm1 In elm.Children
                For Each elm2 In elm1.Children
                    If TypeOf elm2 Is LightVisualElement Then
                        Dim Xobj As LightVisualElement = CType(elm2, LightVisualElement)
                        If Xobj.Text = "Group by:" Then
                            Xobj.Text = "تجميع بواسطة : "
                            Exit For
                        End If
                    End If
                Next
            Next
        Next
    End Sub
    Private Sub radDataGrid_CreateCell(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCreateCellEventArgs) Handles radDataGrid.CreateCell
        If IsNothing(e.CellType) Then Return
        If e.CellType.FullName.Contains("FilterCellElement") Then
            Dim cell As New GridFilterCellElement(e.Column, e.Row)
            cell.FilterButton.Enabled = False
            e.CellElement = cell
            e.CellType = cell.GetType()
        End If
        If e.CellType.FullName.Contains("FilterCheckBoxCellElement") Then
            Dim cell As New GridFilterCheckBoxCellElement(e.Column, e.Row)
            cell.FilterButton.Enabled = False
            cell.FilterButton.AutoSize = False
            cell.FilterButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
            cell.FilterButton.Size = New Size(1, 1)
            e.CellElement = cell
            e.CellType = cell.GetType()
        End If
    End Sub
    Private Sub radDataGrid_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.SelectionChanged
        If IsNothing(radDataGrid.SelectedRows) Then Exit Sub
        If TypeOf radDataGrid.CurrentRow Is GridViewGroupRowInfo Then
            Try
            Catch
            End Try
        Else
            If radDataGrid.SelectedRows.Count = 1 Then
                Try
                Catch
                End Try
            Else
                If IsNothing(radDataGrid.SelectedRows) Then Exit Sub
                Try
                Catch
                End Try
            End If
        End If
        If radDataGrid.RowCount > 0 Then
            StrCount = "العدد الكلي " & radDataGrid.RowCount
            lblStatus.Text = StrCount
        End If
    End Sub
    Private Sub btnColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColumn.Click
        radDataGrid.ColumnChooser.Text = "الأعمدة"
        radDataGrid.ColumnChooser.ColumnChooserControl.ColumnChooserElement.Text = "اسحب الأعمدة من و إلى الشبكة"
        radDataGrid.ColumnChooser.Show()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        If Not frmLogin.CurrentUser.CanDelete Then
            ExceptionsManager.RaiseAccessDeniedException()
            Return
        End If
        Try
            Dim retD As DialogResult = MsgBox("هل تريد حذف عملية/عمليات تحويل مع كل المتعلقات بهم؟", MsgBoxStyle.Question Or MsgBoxStyle.YesNo)
            If retD = vbYes Then
                Dim DeletedRows As New ArrayList()
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                    Dim Tid As Integer = CType(row.Cells("ID").Value, Integer)
                    If Not Deleter.DeleteBill(Tid) Then
                        ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج حذف القيد ", True, True))
                        Exit Sub
                    End If
                    DeletedRows.Add(row)
                Next
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In DeletedRows
                    row.IsVisible = False
                    radDataGrid.Rows.Remove(row)
                Next
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub btnUnDoBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnDoBill.Click
        If radDataGrid.SelectedRows.Count <= 0 Then Return
        If Not frmLogin.CurrentUser.CanDelete Then
            ExceptionsManager.RaiseAccessDeniedException()
            Return
        End If
        Try
            Dim retD As DialogResult = MsgBox("هل تريد إعادة المبالغ إلى حسابتها؟", MsgBoxStyle.Question Or MsgBoxStyle.YesNo)
            If retD = vbYes Then
                Dim DeletedRows As New ArrayList()
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In radDataGrid.SelectedRows
                    Dim Tra As OrphanageClasses.Transform = Getter.GetTransformByID(CType(row.Cells("ID").Value, Integer))
                    If IsNothing(Tra) Then
                        DeletedRows.Add(row)
                        Continue For
                    End If
                    If Not Deleter.UndoTransform(Tra.ID) Then
                        ExceptionsManager.RaiseOnStatus(New MyException("لم يستطع البرنامج إلغاء عملية التحويل ", True, True))
                        Exit Sub
                    End If
                    DeletedRows.Add(row)
                Next
                For Each row As Telerik.WinControls.UI.GridViewRowInfo In DeletedRows
                    row.IsVisible = False
                    radDataGrid.Rows.Remove(row)
                Next
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub

    Private Sub radDataGrid_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.MouseEnter
        LangChanger.CurLang.SaveCurrentLanguage()
        LangChanger.CurLang.ChangeToArabic()
        radDataGrid.Cursor = Cursors.Default
    End Sub

    Private Sub radDataGrid_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDataGrid.MouseLeave
        LangChanger.CurLang.ReturnToSavedLanguage()
    End Sub

    Private Sub btnShowBails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowBails.Click
        Try
            If Not IsNothing(radDataGrid.SelectedRows) AndAlso radDataGrid.SelectedRows.Count > 0 Then
                Dim trans As New System.Data.Linq.EntitySet(Of OrphanageClasses.Transform)
                For Each row As GridViewRowInfo In radDataGrid.SelectedRows()
                    Dim OrphID As Integer = row.Cells("ID").Value
                    Dim bil As OrphanageClasses.Transform = Getter.GetTransformByID(OrphID)
                    If Not IsNothing(bil) AndAlso Not trans.Contains(bil) Then
                        trans.Add(bil)
                    End If
                Next
                If trans.Count > 0 Then
                    WindowsLauncher.LaunchBills(trans)
                End If
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
        End Try
    End Sub
End Class
