Public Class WindowsLauncher
    Public Shared AllWindows As New ArrayList
    Public Shared Sub ClearMemery()
        Try
            Dim allI As Integer = AllWindows.Count
            For i As Integer = 0 To allI - 1
                If TypeOf AllWindows(i) Is Form Then
                    Dim frm As Form = CType(AllWindows(i), Form)
                    If Not IsNothing(frm) Then
                        If Not frm.Visible Then
                            GC.Collect()
                            frm.Dispose()
                            GC.WaitForPendingFinalizers()
                            GC.WaitForFullGCApproach()
                            GC.WaitForFullGCComplete()
                            GC.Collect()
                            AllWindows.RemoveAt(i)
                            i -= 1
                        End If
                    Else
                        AllWindows.RemoveAt(i)
                        i -= 1
                    End If
                Else
                    Dim frm As Telerik.WinControls.UI.RadForm = CType(AllWindows(i), Telerik.WinControls.UI.RadForm)
                    If Not IsNothing(frm) Then
                        If Not frm.Visible Then
                            GC.Collect()
                            frm.Dispose()
                            GC.WaitForPendingFinalizers()
                            GC.WaitForFullGCApproach()
                            GC.WaitForFullGCComplete()
                            GC.Collect()
                            AllWindows.RemoveAt(i)
                            i -= 1
                        End If
                    Else
                        AllWindows.RemoveAt(i)
                        i -= 1
                    End If
                End If
            Next
        Catch
        End Try
    End Sub
#Region "Supporters"
    Public Shared Sub LaunchSupporters()
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New FrmSupporters()
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchSupporters(ByVal ids() As Integer)
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New FrmSupporters(ids)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchSupporters(ByVal Usrs As System.Data.Linq.EntitySet(Of OrphanageClasses.User))
        If frmLogin.CurrentUser.IsAdmin Then
            If IsNothing(Usrs) OrElse Usrs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each usr In Usrs
                If Not IsNothing(usr.Supporters) AndAlso usr.Supporters.Count > 0 Then
                    For Each sup In usr.Supporters
                        If Not ar.Contains(sup.ID) Then
                            ar.Add(sup.ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmSupporters(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchSupporters(ByVal Fams As System.Data.Linq.EntitySet(Of OrphanageClasses.Family))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(Fams) OrElse Fams.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fam In Fams
                If fam.IsBaild Then
                    If Not IsNothing(fam.Bail.Supporter) AndAlso Not ar.Contains(fam.Bail.Supporter.ID) Then
                        ar.Add(fam.Bail.Supporter.ID)
                    End If
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmSupporters(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchSupporters(ByVal orphs As System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(orphs) OrElse orphs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each orp In orphs
                If orp.IsBailed Then
                    If Not IsNothing(orp.Bail.Supporter) AndAlso Not ar.Contains(orp.Bail.Supporter.ID) Then
                        ar.Add(orp.Bail.Supporter.ID)
                    End If
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmSupporters(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchSupporters(ByVal faths As System.Data.Linq.EntitySet(Of OrphanageClasses.Father))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(faths) OrElse faths.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fath In faths
                If Not IsNothing(fath.Families) AndAlso fath.Families.Count > 0 Then
                    For Each fam In fath.Families
                        If fam.IsBaild Then
                            If Not IsNothing(fam.Bail.Supporter) AndAlso Not ar.Contains(fam.Bail.Supporter.ID) Then
                                ar.Add(fam.Bail.Supporter.ID)
                            End If
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmSupporters(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchSupporters(ByVal moths As System.Data.Linq.EntitySet(Of OrphanageClasses.Mother))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(moths) OrElse moths.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each moth In moths
                If Not IsNothing(moth.Families) AndAlso moth.Families.Count > 0 Then
                    For Each fam In moth.Families
                        If fam.IsBaild Then
                            If Not IsNothing(fam.Bail.Supporter) AndAlso Not ar.Contains(fam.Bail.Supporter.ID) Then
                                ar.Add(fam.Bail.Supporter.ID)
                            End If
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmSupporters(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchSupporters(ByVal bals As System.Data.Linq.EntitySet(Of OrphanageClasses.Bail))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bals) OrElse bals.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bal In bals
                If Not IsNothing(bal.Supporter) AndAlso Not ar.Contains(bal.Supporter.ID) Then
                    ar.Add(bal.Supporter.ID)
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmSupporters(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchSupporters(ByVal bils As System.Data.Linq.EntitySet(Of OrphanageClasses.Bill))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bils) OrElse bils.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bil In bils
                If Not IsNothing(bil.Bail_ID) AndAlso bil.Bail_ID > 0 Then
                    If Not IsNothing(bil.Bail.Supporter) AndAlso Not ar.Contains(bil.Bail.Supporter.ID) Then
                        ar.Add(bil.Bail.Supporter.ID)
                    End If
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmSupporters(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchSupporters(ByVal bxs As System.Data.Linq.EntitySet(Of OrphanageClasses.Box))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bxs) OrElse bxs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bx In bxs
                If Not IsNothing(bx.Supporters) AndAlso bx.Supporters.Count > 0 Then
                    For Each sup In bx.Supporters
                        If Not ar.Contains(sup.ID) Then ar.Add(sup.ID)
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmSupporters(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
#End Region

#Region "Bills"
    Public Shared Sub LaunchNewBills()
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            Dim frm As New FrmBill()
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchNewBills(ByVal Fam As OrphanageClasses.Box)
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            Dim frm As New FrmBill(Fam.ID)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchNewBills(ByVal IsDeposite As Boolean)
        If IsDeposite Then
            If frmLogin.CurrentUser.CanDeposit Then
                Dim frm As New FrmBill(IsDeposite)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            Else
                ExceptionsManager.RaiseAccessDeniedException()
            End If
        Else
            If frmLogin.CurrentUser.CanDraw Then
                Dim frm As New FrmBill(IsDeposite)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            Else
                ExceptionsManager.RaiseAccessDeniedException()
            End If
        End If
    End Sub
    Public Shared Sub LaunchNewBills(ByVal IsDeposite As Boolean, ByVal Fam As OrphanageClasses.Family)
        If IsDeposite Then
            If frmLogin.CurrentUser.CanDeposit Then
                Dim frm As New FrmBill(IsDeposite, Fam)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            Else
                ExceptionsManager.RaiseAccessDeniedException()
            End If
        Else
            If frmLogin.CurrentUser.CanDraw Then
                Dim frm As New FrmBill(IsDeposite, Fam)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            Else
                ExceptionsManager.RaiseAccessDeniedException()
            End If
        End If
    End Sub
    Public Shared Sub LaunchNewBills(ByVal IsDeposite As Boolean, ByVal Fam As OrphanageClasses.Orphan)
        If IsDeposite Then
            If frmLogin.CurrentUser.CanDeposit Then
                Dim frm As New FrmBill(IsDeposite, Fam)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            Else
                ExceptionsManager.RaiseAccessDeniedException()
            End If
        Else
            If frmLogin.CurrentUser.CanDraw Then
                Dim frm As New FrmBill(IsDeposite, Fam)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            Else
                ExceptionsManager.RaiseAccessDeniedException()
            End If
        End If
    End Sub
    Public Shared Sub LaunchNewBills(ByVal IsDeposite As Boolean, ByVal box_id As Integer)
        If IsDeposite Then
            If frmLogin.CurrentUser.CanDeposit Then
                Dim frm As New FrmBill(IsDeposite, box_id)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            Else
                ExceptionsManager.RaiseAccessDeniedException()
            End If
        Else
            If frmLogin.CurrentUser.CanDraw Then
                Dim frm As New FrmBill(IsDeposite, box_id)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            Else
                ExceptionsManager.RaiseAccessDeniedException()
            End If
        End If
    End Sub
    Public Shared Sub LaunchNewBills(ByVal IsDeposite As Boolean, ByVal Fam As OrphanageClasses.Bail)
        If IsDeposite Then
            If frmLogin.CurrentUser.CanDeposit Then
                Dim frm As New FrmBill(IsDeposite, Fam)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            Else
                ExceptionsManager.RaiseAccessDeniedException()
            End If
        Else
            If frmLogin.CurrentUser.CanDraw Then
                Dim frm As New FrmBill(IsDeposite, Fam)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            Else
                ExceptionsManager.RaiseAccessDeniedException()
            End If
        End If
    End Sub
    Public Shared Sub LaunchNewBills(ByVal IsDeposite As Boolean, ByVal Fam As OrphanageClasses.Bail, ByVal orph As OrphanageClasses.Orphan)
        If IsDeposite Then
            If frmLogin.CurrentUser.CanDeposit Then
                Dim frm As New FrmBill(IsDeposite, Fam, orph)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            Else
                ExceptionsManager.RaiseAccessDeniedException()
            End If
        Else
            If frmLogin.CurrentUser.CanDraw Then
                Dim frm As New FrmBill(IsDeposite, Fam, orph)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            Else
                ExceptionsManager.RaiseAccessDeniedException()
            End If
        End If
    End Sub
    Public Shared Sub LaunchNewBills(ByVal IsDeposite As Boolean, ByVal bal As OrphanageClasses.Bail, ByVal Fam As OrphanageClasses.Family)
        If IsDeposite Then
            If frmLogin.CurrentUser.CanDeposit Then
                Dim frm As New FrmBill(IsDeposite, bal, Fam)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            Else
                ExceptionsManager.RaiseAccessDeniedException()
            End If
        Else
            If frmLogin.CurrentUser.CanDraw Then
                Dim frm As New FrmBill(IsDeposite, bal, Fam)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            Else
                ExceptionsManager.RaiseAccessDeniedException()
            End If
        End If
    End Sub

    Public Shared Sub LaunchBills()
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            Dim frm As New FrmBills()
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBills(ByVal ids() As Integer)
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            Dim frm As New FrmBills(ids)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBills(ByVal Usrs As System.Data.Linq.EntitySet(Of OrphanageClasses.User))
        If frmLogin.CurrentUser.IsAdmin Then
            If IsNothing(Usrs) OrElse Usrs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each usr In Usrs
                If Not IsNothing(usr.Bills) AndAlso usr.Bills.Count > 0 Then
                    For Each sup In usr.Bills
                        If Not ar.Contains(sup.ID) Then
                            ar.Add(sup.ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBills(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBills(ByVal Fams As System.Data.Linq.EntitySet(Of OrphanageClasses.Family))
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            If IsNothing(Fams) OrElse Fams.Count = 0 Then Exit Sub
            Dim frm As New FrmBills(Fams)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBills(ByVal orphs As System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan))
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            If IsNothing(orphs) OrElse orphs.Count = 0 Then Exit Sub
            Dim frm As New FrmBills(orphs)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBills(ByVal faths As System.Data.Linq.EntitySet(Of OrphanageClasses.Father))
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            If IsNothing(faths) OrElse faths.Count = 0 Then Exit Sub
            Dim Fams As New System.Data.Linq.EntitySet(Of OrphanageClasses.Family)
            Dim orph As New System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan)
            Dim bail As New System.Data.Linq.EntitySet(Of OrphanageClasses.Bail)
            For Each fath In faths
                If Not IsNothing(fath.Families) AndAlso fath.Families.Count > 0 Then
                    For Each fam In fath.Families
                        If Not IsNothing(fam.Bills) AndAlso fam.Bills.Count > 0 Then
                            Fams.Add(fam)
                        End If
                        If Not IsNothing(fam.Orphans) AndAlso fam.Orphans.Count > 0 Then
                            For Each orp In fam.Orphans
                                If Not IsNothing(orp.Bills) AndAlso orp.Bills.Count > 0 Then
                                    orph.Add(orp)
                                End If
                                If Not IsNothing(orp.Bail) AndAlso Not IsNothing(orp.Bail.Bills) AndAlso orp.Bail.Bills.Count > 0 Then
                                    If Not bail.Contains(orp.Bail) Then
                                        bail.Add(orp.Bail)
                                    End If
                                End If
                            Next
                        End If
                        If Not IsNothing(fam.Bail) AndAlso Not IsNothing(fam.Bail.Bills) AndAlso fam.Bail.Bills.Count > 0 Then
                            If Not bail.Contains(fam.Bail) Then
                                bail.Add(fam.Bail)
                            End If
                        End If
                    Next
                End If
            Next
            If bail.Count > 0 Then
                Dim frm As New FrmBills(bail)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
            If Fams.Count > 0 Then
                Dim frm As New FrmBills(Fams)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
            If orph.Count > 0 Then
                Dim frm As New FrmBills(orph)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBills(ByVal moths As System.Data.Linq.EntitySet(Of OrphanageClasses.Mother))
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            If IsNothing(moths) OrElse moths.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each moth In moths
                If Not IsNothing(moth.Families) AndAlso moth.Families.Count > 0 Then
                    For Each fam In moth.Families
                        If Not IsNothing(fam.Bills) AndAlso fam.Bills.Count > 0 Then
                            For Each bil In fam.Bills
                                ar.Add(bil.ID)
                            Next
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBills(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBills(ByVal bals As System.Data.Linq.EntitySet(Of OrphanageClasses.Bail))
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            If IsNothing(bals) OrElse bals.Count = 0 Then Exit Sub
            Dim frm As New FrmBills(bals)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBills(ByVal bils As System.Data.Linq.EntitySet(Of OrphanageClasses.Bill))
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            If IsNothing(bils) OrElse bils.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bil In bils
                ar.Add(bil.ID)
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBills(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBills(ByVal trans As System.Data.Linq.EntitySet(Of OrphanageClasses.Transform))
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            If IsNothing(trans) OrElse trans.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            Dim Odb As New OrphanageDB.Odb()
            For Each tra In trans
                Dim traT As OrphanageClasses.Transform = tra
                Dim SubQ = From bil In Odb.Bills Where bil.Bill_Date = traT.Tranc_Date AndAlso _
                                                    bil.Bill_Number = traT.Tranc_Number AndAlso _
                                                    bil.RegDate.ToShortDateString() = traT.RegDate.ToShortDateString() AndAlso _
                                                    bil.Note Like "*بشكل اتو*" AndAlso bil.User_ID = traT.User_ID
                For Each bi In SubQ
                    ar.Add(bi.ID)
                Next
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBills(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBills(ByVal bxs As System.Data.Linq.EntitySet(Of OrphanageClasses.Box))
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            If IsNothing(bxs) OrElse bxs.Count = 0 Then Exit Sub
            Dim frm As New FrmBills(bxs)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBills(ByVal sups As System.Data.Linq.EntitySet(Of OrphanageClasses.Supporter))
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            If IsNothing(sups) OrElse sups.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each sup In sups
                If Not IsNothing(sup.Box.Bills) AndAlso sup.Box.Bills.Count > 0 Then
                    For Each bil In sup.Box.Bills
                        ar.Add(bil.ID)
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBills(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
#End Region

#Region "Transforms"
    Public Shared Sub LaunchNewTransfor()
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            Dim frm As New FrmTransform()
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchNewTransfor(ByVal bz As Integer)
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            Dim frm As New FrmTransform(bz)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub

    Public Shared Sub LaunchTransforms()
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            Dim frm As New FrmTransforms()
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchTransforms(ByVal ids() As Integer)
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            Dim frm As New FrmTransforms(ids)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchTransforms(ByVal Usrs As System.Data.Linq.EntitySet(Of OrphanageClasses.User))
        If frmLogin.CurrentUser.IsAdmin Then
            If IsNothing(Usrs) OrElse Usrs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each usr In Usrs
                If Not IsNothing(usr.Transforms) AndAlso usr.Transforms.Count > 0 Then
                    For Each sup In usr.Transforms
                        If Not ar.Contains(sup.ID) Then
                            ar.Add(sup.ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmTransforms(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchTransforms(ByVal trans As System.Data.Linq.EntitySet(Of OrphanageClasses.Transform))
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            If IsNothing(trans) OrElse trans.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            Dim Odb As New OrphanageDB.Odb()
            For Each tra In trans
                If Not IsNothing(tra) AndAlso Not ar.Contains(tra.ID) Then
                    ar.Add(tra.ID)
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmTransforms(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchTransforms(ByVal bxs As System.Data.Linq.EntitySet(Of OrphanageClasses.Box))
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            If IsNothing(bxs) OrElse bxs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bx In bxs
                If Not IsNothing(bx.Transforms) AndAlso bx.Transforms.Count > 0 Then
                    For Each tra In bx.Transforms
                        If Not IsNothing(tra) AndAlso Not ar.Contains(tra.ID) Then
                            ar.Add(tra.ID)
                        End If
                    Next
                End If
                If Not IsNothing(bx.Transforms1) AndAlso bx.Transforms1.Count > 0 Then
                    For Each tra In bx.Transforms1
                        If Not IsNothing(tra) AndAlso Not ar.Contains(tra.ID) Then
                            ar.Add(tra.ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmTransforms(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchTransforms(ByVal bx As OrphanageClasses.Box)
        If frmLogin.CurrentUser.CanDraw AndAlso frmLogin.CurrentUser.CanDeposit Then
            If IsNothing(bx) Then Exit Sub
            Dim frm As New FrmTransforms(bx)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
#End Region

#Region "Families"
    Public Shared Sub LaunchNewFamilies()
        If frmLogin.CurrentUser.CanAdd Then
            Dim frm As New FrmAddNewWiard()
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFamilies()
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New FrmFamiles()
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFamilies(ByVal ids() As Integer)
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New FrmFamiles(ids)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFamilies(ByVal OnlyBailed As Boolean)
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New FrmFamiles(OnlyBailed)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFamilies(ByVal Usrs As System.Data.Linq.EntitySet(Of OrphanageClasses.User))
        If frmLogin.CurrentUser.IsAdmin Then
            If IsNothing(Usrs) OrElse Usrs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each usr In Usrs
                If Not IsNothing(usr.Families) AndAlso usr.Families.Count > 0 Then
                    For Each sup In usr.Families
                        If Not ar.Contains(sup.ID) Then
                            ar.Add(sup.ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFamiles(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFamilies(ByVal Fams As System.Data.Linq.EntitySet(Of OrphanageClasses.Family))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(Fams) OrElse Fams.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fam In Fams
                If Not ar.Contains(fam.ID) Then
                    ar.Add(fam.ID)
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFamiles(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFamilies(ByVal orphs As System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(orphs) OrElse orphs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each orp In orphs
                If Not ar.Contains(orp.Family_ID) Then
                    ar.Add(orp.Family_ID)
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFamiles(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFamilies(ByVal faths As System.Data.Linq.EntitySet(Of OrphanageClasses.Father))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(faths) OrElse faths.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fath In faths
                If Not IsNothing(fath.Families) AndAlso fath.Families.Count > 0 Then
                    For Each fam In fath.Families
                        If Not ar.Contains(fam.ID) Then
                            ar.Add(fam.ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFamiles(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFamilies(ByVal moths As System.Data.Linq.EntitySet(Of OrphanageClasses.Mother))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(moths) OrElse moths.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each moth In moths
                If Not IsNothing(moth.Families) AndAlso moth.Families.Count > 0 Then
                    For Each fam In moth.Families
                        If Not ar.Contains(fam.ID) Then
                            ar.Add(fam.ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFamiles(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFamilies(ByVal bals As System.Data.Linq.EntitySet(Of OrphanageClasses.Bail))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bals) OrElse bals.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bal In bals
                If bal.Is_Ended Then Continue For
                If Not IsNothing(bal.Bills) AndAlso bal.Bills.Count > 0 Then
                    For Each bil In bal.Bills
                        If bil.Family_ID.HasValue Then
                            If Not ar.Contains(bil.Family_ID) Then
                                ar.Add(bil.Family_ID)
                            End If
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFamiles(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFamilies(ByVal bils As System.Data.Linq.EntitySet(Of OrphanageClasses.Bill))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bils) OrElse bils.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bil In bils
                If bil.Family_ID.HasValue Then
                    If Not ar.Contains(bil.Family_ID) Then
                        ar.Add(bil.Family_ID)
                    End If
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFamiles(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFamilies(ByVal sups As System.Data.Linq.EntitySet(Of OrphanageClasses.Supporter))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(sups) OrElse sups.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each sup In sups
                If Not IsNothing(sup.Box.Bails) AndAlso sup.Box.Bails.Count > 0 Then
                    For Each bal In sup.Box.Bails
                        If bal.Is_Family AndAlso Not bal.Is_Ended Then
                            For Each fam In bal.Families
                                If Not ar.Contains(fam.ID) Then
                                    ar.Add(fam.ID)
                                End If
                            Next
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFamiles(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
#End Region

#Region "Mothers"
    Public Sub LaunchMothers()
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New FrmMothers()
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchMothers(ByVal ids() As Integer)
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New FrmMothers(ids)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchMothers(ByVal Usrs As System.Data.Linq.EntitySet(Of OrphanageClasses.User))
        If frmLogin.CurrentUser.IsAdmin Then
            If IsNothing(Usrs) OrElse Usrs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each usr In Usrs
                If Not IsNothing(usr.Mothers) AndAlso usr.Mothers.Count > 0 Then
                    For Each sup In usr.Mothers
                        If Not ar.Contains(sup.ID) Then
                            ar.Add(sup.ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmMothers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchMothers(ByVal Fams As System.Data.Linq.EntitySet(Of OrphanageClasses.Family))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(Fams) OrElse Fams.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fam In Fams
                If Not ar.Contains(fam.Mother_ID) Then ar.Add(fam.Mother_ID)
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmMothers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchMothers(ByVal orphs As System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(orphs) OrElse orphs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each orp In orphs
                If Not ar.Contains(orp.Family.Mother_ID) Then ar.Add(orp.Family.Mother_ID)
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmMothers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchMothers(ByVal faths As System.Data.Linq.EntitySet(Of OrphanageClasses.Father))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(faths) OrElse faths.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fath In faths
                If Not IsNothing(fath.Families) AndAlso fath.Families.Count > 0 Then
                    For Each fam In fath.Families
                        If Not ar.Contains(fam.Mother_ID) Then ar.Add(fam.Mother_ID)
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmMothers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchMothers(ByVal bonds As System.Data.Linq.EntitySet(Of OrphanageClasses.BondsMan))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bonds) OrElse bonds.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fath In bonds
                If Not IsNothing(fath.Orphans) AndAlso fath.Orphans.Count > 0 Then
                    For Each fam In fath.Orphans
                        If Not ar.Contains(fam.Family.Mother_ID) Then
                            ar.Add(fam.Family.Mother_ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmMothers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchMothers(ByVal moths As System.Data.Linq.EntitySet(Of OrphanageClasses.Mother))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(moths) OrElse moths.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each moth In moths
                If Not ar.Contains(moth.ID) Then ar.Add(moth.ID)
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmMothers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchMothers(ByVal bals As System.Data.Linq.EntitySet(Of OrphanageClasses.Bail))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bals) OrElse bals.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bal In bals
                If Not IsNothing(bal.Bills) AndAlso bal.Bills.Count > 0 Then
                    For Each bil In bal.Bills
                        If bil.Family_ID.HasValue Then
                            If Not ar.Contains(bil.Family.Mother_ID) Then ar.Add(bil.Family.Mother_ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmMothers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchMothers(ByVal bils As System.Data.Linq.EntitySet(Of OrphanageClasses.Bill))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bils) OrElse bils.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bil In bils
                If bil.Family_ID.HasValue Then
                    If Not ar.Contains(bil.Family.Mother_ID) Then ar.Add(bil.Family.Mother_ID)
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmMothers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchMothers(ByVal sups As System.Data.Linq.EntitySet(Of OrphanageClasses.Supporter))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(sups) OrElse sups.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each sup In sups
                If Not IsNothing(sup.Box.Bails) AndAlso sup.Box.Bails.Count > 0 Then
                    For Each bal In sup.Box.Bails
                        If bal.Is_Family AndAlso Not bal.Is_Ended Then
                            For Each fam In bal.Families
                                If Not ar.Contains(fam.Mother_ID) Then ar.Add(fam.Mother_ID)
                            Next
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmMothers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
#End Region

#Region "Fathers"
    Public Shared Sub LaunchFathers()
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New FrmFathers()
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFathers(ByVal ids() As Integer)
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New FrmFathers(ids)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFathers(ByVal Usrs As System.Data.Linq.EntitySet(Of OrphanageClasses.User))
        If frmLogin.CurrentUser.IsAdmin Then
            If IsNothing(Usrs) OrElse Usrs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each usr In Usrs
                If Not IsNothing(usr.Fathers) AndAlso usr.Fathers.Count > 0 Then
                    For Each sup In usr.Fathers
                        If Not ar.Contains(sup.ID) Then
                            ar.Add(sup.ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFathers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFathers(ByVal Fams As System.Data.Linq.EntitySet(Of OrphanageClasses.Family))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(Fams) OrElse Fams.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fam In Fams
                If Not ar.Contains(fam.Father_ID) Then ar.Add(fam.Father_ID)
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFathers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFathers(ByVal orphs As System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(orphs) OrElse orphs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each orp In orphs
                If Not ar.Contains(orp.Family.Father_ID) Then ar.Add(orp.Family.Father_ID)
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFathers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFathers(ByVal moths As System.Data.Linq.EntitySet(Of OrphanageClasses.Mother))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(moths) OrElse moths.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fath In moths
                If Not IsNothing(fath.Families) AndAlso fath.Families.Count > 0 Then
                    For Each fam In fath.Families
                        If Not ar.Contains(fam.Father_ID) Then ar.Add(fam.Father_ID)
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFathers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFathers(ByVal fath As System.Data.Linq.EntitySet(Of OrphanageClasses.Father))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(fath) OrElse fath.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each moth In fath
                If Not ar.Contains(moth.ID) Then ar.Add(moth.ID)
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFathers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFathers(ByVal bals As System.Data.Linq.EntitySet(Of OrphanageClasses.Bail))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bals) OrElse bals.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bal In bals
                If Not IsNothing(bal.Bills) AndAlso bal.Bills.Count > 0 Then
                    For Each bil In bal.Bills
                        If bil.Family_ID.HasValue Then
                            If Not ar.Contains(bil.Family.Father_ID) Then ar.Add(bil.Family.Father_ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFathers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFathers(ByVal bils As System.Data.Linq.EntitySet(Of OrphanageClasses.Bill))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bils) OrElse bils.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bil In bils
                If bil.Family_ID.HasValue Then
                    If Not ar.Contains(bil.Family.Father_ID) Then ar.Add(bil.Family.Father_ID)
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFathers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchFAthers(ByVal sups As System.Data.Linq.EntitySet(Of OrphanageClasses.Supporter))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(sups) OrElse sups.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each sup In sups
                If Not IsNothing(sup.Box.Bails) AndAlso sup.Box.Bails.Count > 0 Then
                    For Each bal In sup.Box.Bails
                        If bal.Is_Family AndAlso Not bal.Is_Ended Then
                            For Each fam In bal.Families
                                If Not ar.Contains(fam.Father_ID) Then ar.Add(fam.Father_ID)
                            Next
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmFathers(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
#End Region

#Region "Orphans"
    Public Shared Sub LaunchOrphans()
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New frmOrphans()
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchOrphans(ByVal ids() As Integer)
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New frmOrphans(ids)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchOrphans(ByVal Usrs As System.Data.Linq.EntitySet(Of OrphanageClasses.User))
        If frmLogin.CurrentUser.IsAdmin Then
            If IsNothing(Usrs) OrElse Usrs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each usr In Usrs
                If Not IsNothing(usr.Orphans) AndAlso usr.Orphans.Count > 0 Then
                    For Each sup In usr.Orphans
                        If Not ar.Contains(sup.ID) Then
                            ar.Add(sup.ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New frmOrphans(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchOrphans(ByVal Fams As System.Data.Linq.EntitySet(Of OrphanageClasses.Family))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(Fams) OrElse Fams.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fam In Fams
                If Not IsNothing(fam.Orphans) AndAlso fam.Orphans.Count > 0 Then
                    For Each orph In fam.Orphans
                        ar.Add(orph.ID)
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New frmOrphans(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchOrphans(ByVal orphs As System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(orphs) OrElse orphs.Count = 0 Then Exit Sub
            If orphs.Count > 0 Then
                Dim frm As New frmOrphans(orphs)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchOrphans(ByVal moths As System.Data.Linq.EntitySet(Of OrphanageClasses.Mother))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(moths) OrElse moths.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fath In moths
                If Not IsNothing(fath.Families) AndAlso fath.Families.Count > 0 Then
                    For Each fam In fath.Families
                        If Not IsNothing(fam.Orphans) AndAlso fam.Orphans.Count > 0 Then
                            For Each orp In fam.Orphans
                                ar.Add(orp.ID)
                            Next
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New frmOrphans(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchOrphans(ByVal faths As System.Data.Linq.EntitySet(Of OrphanageClasses.Father))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(faths) OrElse faths.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fath In faths
                If Not IsNothing(fath.Families) AndAlso fath.Families.Count > 0 Then
                    For Each fam In fath.Families
                        If Not IsNothing(fam.Orphans) AndAlso fam.Orphans.Count > 0 Then
                            For Each orp In fam.Orphans
                                ar.Add(orp.ID)
                            Next
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New frmOrphans(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchOrphans(ByVal Bonds As System.Data.Linq.EntitySet(Of OrphanageClasses.BondsMan))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(Bonds) OrElse Bonds.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fath In Bonds
                If Not IsNothing(fath.Orphans) AndAlso fath.Orphans.Count > 0 Then
                    For Each orp In fath.Orphans
                        ar.Add(orp.ID)
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New frmOrphans(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchOrphans(ByVal bals As System.Data.Linq.EntitySet(Of OrphanageClasses.Bail))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bals) OrElse bals.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bal In bals
                If bal.Is_Family Then
                    If Not IsNothing(bal.Families) AndAlso bal.Families.Count > 0 Then
                        For Each orp In bal.Families
                            ar.Add(bal.ID)
                        Next
                    End If
                Else
                    If Not IsNothing(bal.Orphans) AndAlso bal.Orphans.Count > 0 Then
                        For Each orp In bal.Orphans
                            ar.Add(orp.ID)
                        Next
                    End If
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New frmOrphans(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchOrphans(ByVal bils As System.Data.Linq.EntitySet(Of OrphanageClasses.Bill))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bils) OrElse bils.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bil In bils
                If bil.Family_ID.HasValue Then
                    If Not IsNothing(bil.Family.Orphans) AndAlso bil.Family.Orphans.Count > 0 Then
                        For Each orp In bil.Family.Orphans
                            If ar.Contains(orp.ID) Then Continue For
                            ar.Add(orp.ID)
                        Next
                    End If
                Else
                    If bil.Orphan_ID.HasValue Then
                        If ar.Contains(bil.Orphan_ID) Then Continue For
                        ar.Add(bil.Orphan_ID)
                    End If
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New frmOrphans(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchOrphans(ByVal sups As System.Data.Linq.EntitySet(Of OrphanageClasses.Supporter))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(sups) OrElse sups.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each sup In sups
                If Not IsNothing(sup.Box.Bails) AndAlso sup.Box.Bails.Count > 0 Then
                    For Each bal In sup.Box.Bails
                        If bal.Is_Ended Then Continue For
                        If bal.Is_Family Then
                            For Each fam In bal.Families
                                If Not IsNothing(fam.Orphans) AndAlso fam.Orphans.Count > 0 Then
                                    For Each orp In fam.Orphans
                                        If ar.Contains(orp.ID) Then Continue For
                                        ar.Add(orp.ID)
                                    Next
                                End If
                            Next
                        Else
                            If Not IsNothing(bal.Orphans) AndAlso bal.Orphans.Count > 0 Then
                                For Each orp In bal.Orphans
                                    If ar.Contains(orp.ID) Then Continue For
                                    ar.Add(orp.ID)
                                Next
                            End If
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New frmOrphans(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
#End Region

#Region "Bails"
    Public Shared Sub LaunchNewBail()
        If frmLogin.CurrentUser.CanAdd Then
            Dim frm As New FrmBail()
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchNewBail(ByVal Id As Integer)
        If frmLogin.CurrentUser.CanRead AndAlso frmLogin.CurrentUser.CanDelete Then
            Dim frm As New FrmBail(Id)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchNewBail(ByVal sup As Long)
        If frmLogin.CurrentUser.CanAdd Then
            Dim frm As New FrmBail(sup)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBails()
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New FrmBails()
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBails(ByVal ids() As Integer)
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New FrmBails(ids)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBails(ByVal Usrs As System.Data.Linq.EntitySet(Of OrphanageClasses.User))
        If frmLogin.CurrentUser.IsAdmin Then
            If IsNothing(Usrs) OrElse Usrs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each usr In Usrs
                If Not IsNothing(usr.Bails) AndAlso usr.Bails.Count > 0 Then
                    For Each sup In usr.Bails
                        If Not ar.Contains(sup.ID) Then
                            ar.Add(sup.ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBails(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBails(ByVal orphs As System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(orphs) OrElse orphs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each orph In orphs
                If orph.IsBailed AndAlso orph.Bail_ID.HasValue Then
                    If Not ar.Contains(orph.Bail_ID.Value) Then
                        ar.Add(orph.Bail_ID.Value)
                    End If
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBails(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBails(ByVal Fams As System.Data.Linq.EntitySet(Of OrphanageClasses.Family))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(Fams) OrElse Fams.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fam In Fams
                If fam.Baild_ID.HasValue AndAlso fam.IsBaild Then
                    If Not ar.Contains(fam.Baild_ID.Value) Then
                        ar.Add(fam.Baild_ID.Value)
                    End If
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBails(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBails(ByVal moths As System.Data.Linq.EntitySet(Of OrphanageClasses.Mother))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(moths) OrElse moths.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fath In moths
                If Not IsNothing(fath.Families) AndAlso fath.Families.Count > 0 Then
                    For Each fam In fath.Families
                        If Not IsNothing(fam.Baild_ID) AndAlso fam.Bail.ID > 0 Then
                            If Not ar.Contains(fam.Baild_ID) Then
                                ar.Add(fam.Baild_ID)
                            End If
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBails(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBails(ByVal faths As System.Data.Linq.EntitySet(Of OrphanageClasses.Father))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(faths) OrElse faths.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fath In faths
                If Not IsNothing(fath.Families) AndAlso fath.Families.Count > 0 Then
                    For Each fam In fath.Families
                        If Not IsNothing(fam.Baild_ID) AndAlso fam.Bail.ID > 0 Then
                            If Not ar.Contains(fam.Baild_ID) Then
                                ar.Add(fam.Baild_ID)
                            End If
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBails(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBails(ByVal bals As System.Data.Linq.EntitySet(Of OrphanageClasses.Bail))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bals) OrElse bals.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bal In bals
                If Not ar.Contains(bal.ID) Then
                    ar.Add(bal.ID)
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBails(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBails(ByVal bils As System.Data.Linq.EntitySet(Of OrphanageClasses.Bill))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bils) OrElse bils.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bil In bils
                If Not IsNothing(bil.Bail_ID) AndAlso bil.Bail.ID > 0 Then
                    If Not ar.Contains(bil.Bail_ID) Then
                        ar.Add(bil.Bail_ID)
                    End If
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBails(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBails(ByVal sups As System.Data.Linq.EntitySet(Of OrphanageClasses.Supporter))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(sups) OrElse sups.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each sup In sups
                If Not IsNothing(sup.Box.Bails) AndAlso sup.Box.Bails.Count > 0 Then
                    For Each bal In sup.Box.Bails
                        If Not IsNothing(bal.ID) AndAlso bal.ID > 0 Then
                            If Not ar.Contains(bal.ID) Then
                                ar.Add(bal.ID)
                            End If
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBails(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBails(ByVal bx As System.Data.Linq.EntitySet(Of OrphanageClasses.Box))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bx) OrElse bx.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each sup In bx
                If Not IsNothing(sup.Bails) AndAlso sup.Bails.Count > 0 Then
                    For Each bal In sup.Bails
                        If Not IsNothing(bal.ID) AndAlso bal.ID > 0 Then
                            If Not ar.Contains(bal.ID) Then
                                ar.Add(bal.ID)
                            End If
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBails(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
#End Region

#Region "BondsMen"
    Public Shared Sub LaunchBondsMen()
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New FrmBondsMen()
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBondsMen(ByVal ids() As Integer)
        If frmLogin.CurrentUser.CanRead Then
            Dim frm As New FrmBondsMen(ids)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBondsMen(ByVal Usrs As System.Data.Linq.EntitySet(Of OrphanageClasses.User))
        If frmLogin.CurrentUser.IsAdmin Then
            If IsNothing(Usrs) OrElse Usrs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each usr In Usrs
                If Not IsNothing(usr.BondsMans) AndAlso usr.BondsMans.Count > 0 Then
                    For Each sup In usr.BondsMans
                        If Not ar.Contains(sup.ID) Then
                            ar.Add(sup.ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBondsMen(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBondsMen(ByVal Fams As System.Data.Linq.EntitySet(Of OrphanageClasses.Family))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(Fams) OrElse Fams.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fam In Fams
                If Not IsNothing(fam.Orphans) AndAlso fam.Orphans.Count > 0 Then
                    For Each orph In fam.Orphans
                        If Not ar.Contains(orph.BondsMan_ID) Then
                            ar.Add(orph.BondsMan_ID)
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBondsMen(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBondsMen(ByVal orphs As System.Data.Linq.EntitySet(Of OrphanageClasses.Orphan))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(orphs) OrElse orphs.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each orph In orphs
                If Not ar.Contains(orph.BondsMan_ID) Then
                    ar.Add(orph.BondsMan_ID)
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBondsMen(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBondsMen(ByVal moths As System.Data.Linq.EntitySet(Of OrphanageClasses.Mother))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(moths) OrElse moths.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fath In moths
                If Not IsNothing(fath.Families) AndAlso fath.Families.Count > 0 Then
                    For Each fam In fath.Families
                        If Not IsNothing(fam.Orphans) AndAlso fam.Orphans.Count > 0 Then
                            For Each orp In fam.Orphans
                                If Not ar.Contains(orp.BondsMan_ID) Then
                                    ar.Add(orp.BondsMan_ID)
                                End If
                            Next
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBondsMen(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBondsMen(ByVal faths As System.Data.Linq.EntitySet(Of OrphanageClasses.Father))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(faths) OrElse faths.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each fath In faths
                If Not IsNothing(fath.Families) AndAlso fath.Families.Count > 0 Then
                    For Each fam In fath.Families
                        If Not IsNothing(fam.Orphans) AndAlso fam.Orphans.Count > 0 Then
                            For Each orp In fam.Orphans
                                If Not ar.Contains(orp.BondsMan_ID) Then
                                    ar.Add(orp.BondsMan_ID)
                                End If
                            Next
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBondsMen(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBondsMen(ByVal bals As System.Data.Linq.EntitySet(Of OrphanageClasses.Bail))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bals) OrElse bals.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bal In bals
                If bal.Is_Family Then
                    If Not IsNothing(bal.Families) AndAlso bal.Families.Count > 0 Then
                        For Each fam In bal.Families
                            For Each orp In fam.Orphans
                                If Not ar.Contains(orp.BondsMan_ID) Then
                                    ar.Add(orp.BondsMan_ID)
                                End If
                            Next
                        Next
                    End If
                Else
                    If Not IsNothing(bal.Orphans) AndAlso bal.Orphans.Count > 0 Then
                        For Each orp In bal.Orphans
                            If Not ar.Contains(orp.BondsMan_ID) Then
                                ar.Add(orp.BondsMan_ID)
                            End If
                        Next
                    End If
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBondsMen(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBondsMen(ByVal bils As System.Data.Linq.EntitySet(Of OrphanageClasses.Bill))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(bils) OrElse bils.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each bil In bils
                If bil.Family_ID.HasValue Then
                    If Not IsNothing(bil.Family.Orphans) AndAlso bil.Family.Orphans.Count > 0 Then
                        For Each orp In bil.Family.Orphans
                            If Not ar.Contains(orp.BondsMan_ID) Then
                                ar.Add(orp.BondsMan_ID)
                            End If
                        Next
                    End If
                Else
                    If bil.Orphan_ID.HasValue Then
                        If ar.Contains(bil.Orphan_ID) Then Continue For
                        ar.Add(bil.Orphan_ID)
                    End If
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBondsMen(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchBondsMen(ByVal sups As System.Data.Linq.EntitySet(Of OrphanageClasses.Supporter))
        If frmLogin.CurrentUser.CanRead Then
            If IsNothing(sups) OrElse sups.Count = 0 Then Exit Sub
            Dim ar As New ArrayList()
            For Each sup In sups
                If Not IsNothing(sup.Box.Bails) AndAlso sup.Box.Bails.Count > 0 Then
                    For Each bal In sup.Box.Bails
                        If bal.Is_Ended Then Continue For
                        If bal.Is_Family Then
                            For Each fam In bal.Families
                                If Not IsNothing(fam.Orphans) AndAlso fam.Orphans.Count > 0 Then
                                    For Each orp In fam.Orphans
                                        If Not ar.Contains(orp.BondsMan_ID) Then
                                            ar.Add(orp.BondsMan_ID)
                                        End If
                                    Next
                                End If
                            Next
                        Else
                            If Not IsNothing(bal.Orphans) AndAlso bal.Orphans.Count > 0 Then
                                For Each orp In bal.Orphans
                                    If Not ar.Contains(orp.BondsMan_ID) Then
                                        ar.Add(orp.BondsMan_ID)
                                    End If
                                Next
                            End If
                        End If
                    Next
                End If
            Next
            If ar.Count > 0 Then
                Dim ids() As Integer = CType(ar.ToArray(GetType(Integer)), Integer())
                Dim frm As New FrmBondsMen(ids)
                frm.MdiParent = Application.OpenForms("FrmMain")
                frm.Show()
                AllWindows.Add(frm)
            End If
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
#End Region

#Region "Users"
    Public Shared Sub LaunchUsers()
        If frmLogin.CurrentUser.IsAdmin Then
            Dim frm As New FrmUsers()
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
    Public Shared Sub LaunchUsers(ByVal ids() As Integer)
        If frmLogin.CurrentUser.IsAdmin Then
            Dim frm As New FrmUsers(ids)
            frm.MdiParent = Application.OpenForms("FrmMain")
            frm.Show()
            AllWindows.Add(frm)
        Else
            ExceptionsManager.RaiseAccessDeniedException()
        End If
    End Sub
#End Region



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New()

    End Sub
End Class
