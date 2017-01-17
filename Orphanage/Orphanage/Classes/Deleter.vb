Imports Itenso.TimePeriod
Imports System.Transactions

Public Class Deleter
    Public Shared Function ExcludeFamily(ByVal FamId As Integer) As Boolean
        Try
            Dim Odb As New OrphanageDB.Odb()
            Using tr = New Transactions.TransactionScope()
                Dim qF = From faml In Odb.Families Where faml.ID = FamId Select faml
                If qF.Count <> 1 Then Return False
                Dim fam = qF.First()
                fam.IsExcluded = True
                For Each O In fam.Orphans
                    O.IsExcluded = True
                Next
                Odb.SubmitChanges()
                tr.Complete()
            End Using
            Return True
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return False
        End Try
    End Function
    Public Shared Function UnExcludeFamily(ByVal FamId As Integer) As Boolean
        Try
            Dim Odb As New OrphanageDB.Odb()
            Using tr = New Transactions.TransactionScope()
                Dim qF = From faml In Odb.Families Where faml.ID = FamId Select faml
                If qF.Count <> 1 Then Return False
                Dim fam = qF.First()
                fam.IsExcluded = False
                For Each O In fam.Orphans
                    O.IsExcluded = False
                Next
                Odb.SubmitChanges()
                tr.Complete()
            End Using
            Return True
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return False
        End Try
    End Function
    Public Shared Function ExcludeOrphan(ByVal FamId As Integer) As Boolean
        Try
            Dim Odb As New OrphanageDB.Odb()
            Using tr = New Transactions.TransactionScope()
                Dim qF = From faml In Odb.Orphans Where faml.ID = FamId Select faml
                If qF.Count <> 1 Then Return False
                Dim fam = qF.First()
                fam.IsExcluded = True
                Odb.SubmitChanges()
                tr.Complete()
            End Using
            Return True
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return False
        End Try
    End Function
    Public Shared Function UnExcludeOrphan(ByVal FamId As Integer) As Boolean
        Try
            Dim Odb As New OrphanageDB.Odb()
            Using tr = New Transactions.TransactionScope()
                Dim qF = From faml In Odb.Orphans Where faml.ID = FamId Select faml
                If qF.Count <> 1 Then Return False
                Dim fam = qF.First()
                fam.IsExcluded = False
                Odb.SubmitChanges()
                tr.Complete()
            End Using
            Return True
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return False
        End Try
    End Function
    Public Shared Function DeleteFamilies(ByVal famID As Integer) As Boolean
        Try
            Dim Odb As New OrphanageDB.Odb()
            Using tr = New Transactions.TransactionScope()
                Dim qF = From faml In Odb.Families Where faml.ID = famID Select faml
                If qF.Count <> 1 Then Return False
                Dim fam = qF.First()
                Dim add1 As OrphanageClasses.Address = fam.Address
                Dim add2 As OrphanageClasses.Address = fam.Address1
                Dim delFathid As Integer = -1
                Dim DelOidas As Integer = -1
                Dim delMoid As Integer = -1
                Dim delBoId As Integer = -1
                If Not IsNothing(fam.Bills) AndAlso fam.Bills.Count > 0 Then
                    Odb.Bills.DeleteAllOnSubmit(fam.Bills)
                    Odb.SubmitChanges()                    
                End If
                'Delete Orphans
                If fam.Orphans.Count > 0 Then
                    Dim DeletedOrphans As New ArrayList()
                    Dim DeletedBondsMan As New ArrayList()
                    For Each orphan As OrphanageClasses.Orphan In fam.Orphans
                        If Not IsNothing(orphan.Bills) AndAlso orphan.Bills.Count > 0 Then
                            Odb.Bills.DeleteAllOnSubmit(orphan.Bills)
                            Odb.SubmitChanges()
                        End If
                        If Not IsNothing(orphan.Bail_ID) AndAlso orphan.Bail_ID > 0 Then
                            If orphan.Bail.Families.Count = 0 AndAlso orphan.Bail.Orphans.Count = 1 Then
                                If orphan.Bail.Bills.Count > 0 Then
                                    Odb.Bills.DeleteAllOnSubmit(orphan.Bail.Bills)
                                    Odb.SubmitChanges()
                                End If
                                Odb.Bails.DeleteOnSubmit(orphan.Bail)
                                orphan.Bail = Nothing
                                Odb.SubmitChanges()
                            End If
                        End If
                        If Not IsNothing(orphan.Education_ID) AndAlso orphan.Education_ID > 0 Then
                            Odb.Studies.DeleteOnSubmit(orphan.Study)
                            orphan.Study = Nothing
                            Odb.SubmitChanges()
                        End If
                        If Not IsNothing(orphan.Health_ID) AndAlso orphan.Health_ID > 0 Then
                            Odb.Healthies.DeleteOnSubmit(orphan.Healthy)
                            orphan.Healthy = Nothing
                            Odb.SubmitChanges()
                        End If
                        Dim DeleteBondsMan As Boolean = False
                        If Not IsNothing(orphan.BondsMan_ID) AndAlso orphan.BondsMan_ID > 0 Then
                            If orphan.BondsMan.Orphans.Count = 1 Then
                                If Not IsNothing(orphan.BondsMan.Address_ID) AndAlso orphan.BondsMan.Address_ID > 0 Then
                                    Odb.Addresses.DeleteOnSubmit(orphan.BondsMan.Address)
                                    orphan.BondsMan.Address = Nothing
                                    Odb.SubmitChanges()
                                End If
                                DeleteBondsMan = True
                            End If
                        End If
                        If DeleteBondsMan Then DeletedBondsMan.Add(orphan.BondsMan)
                        DeletedOrphans.Add(orphan)
                    Next
                    If DeletedOrphans.Count > 0 Then
                        For Each delO As OrphanageClasses.Orphan In DeletedOrphans
                            Dim ONAme As OrphanageClasses.Name = delO.Name
                            DelOidas = delO.ID
                            Odb.Orphans.DeleteOnSubmit(delO)
                            Odb.SubmitChanges()

                            If Not IsNothing(ONAme) AndAlso ONAme.ID > 0 Then
                                Odb.Names.DeleteOnSubmit(ONAme)
                                Odb.SubmitChanges()
                            End If
                        Next
                    End If
                    If DeletedBondsMan.Count > 0 Then
                        For Each delO As OrphanageClasses.BondsMan In DeletedBondsMan
                            Dim ONAme As OrphanageClasses.Name = delO.Name
                            delBoId = delO.ID
                            Odb.BondsMans.DeleteOnSubmit(delO)
                            Odb.SubmitChanges()

                            If Not IsNothing(ONAme) AndAlso ONAme.ID > 0 Then
                                Odb.Names.DeleteOnSubmit(ONAme)
                                Odb.SubmitChanges()
                            End If
                        Next
                    End If
                End If
                'Delete UnOrphans
                If fam.UnOrphans.Count > 0 Then
                    Dim DeletedUnOrph As New ArrayList()
                    For Each Unorphan As OrphanageClasses.UnOrphan In fam.UnOrphans
                        If Not IsNothing(Unorphan.Address_ID) AndAlso Unorphan.Address_ID > 0 Then
                            Odb.Addresses.DeleteOnSubmit(Unorphan.Address)
                            Unorphan.Address = Nothing
                            Odb.SubmitChanges()
                        End If
                        Dim UnOName As OrphanageClasses.Name = Unorphan.Name
                        If Not IsNothing(UnOName) AndAlso UnOName.ID > 0 Then
                            Unorphan.Name = Nothing
                            Odb.Names.DeleteOnSubmit(UnOName)
                            Odb.SubmitChanges()
                        End If
                        DeletedUnOrph.Add(Unorphan)
                    Next
                    If DeletedUnOrph.Count > 0 Then
                        For Each delUnO As OrphanageClasses.UnOrphan In DeletedUnOrph
                            Odb.UnOrphans.DeleteOnSubmit(delUnO)
                            Odb.SubmitChanges()
                        Next
                    End If
                End If
                Dim QFa = From fath In Odb.Fathers Where fath.ID = fam.Father_ID Select fath
                Dim QM = From fath In Odb.Mothers Where fath.ID = fam.Mother_ID Select fath

                Dim FamFather As OrphanageClasses.Father = QFa.FirstOrDefault
                Dim FamMother As OrphanageClasses.Mother = QM.FirstOrDefault
                If Not IsNothing(add1) AndAlso add1.ID > 0 Then
                    fam.Address = Nothing
                    Odb.Addresses.DeleteOnSubmit(add1)
                    Odb.SubmitChanges()
                End If
                If Not IsNothing(fam.Address_ID2) AndAlso fam.Address_ID2 > 0 Then
                    Odb.Addresses.DeleteOnSubmit(fam.Address1)
                    fam.Address1 = Nothing
                    Odb.SubmitChanges()
                End If
                Odb.Families.DeleteOnSubmit(fam)
                Odb.SubmitChanges()
                'Delete Mother
                If Not IsNothing(FamMother) AndAlso FamMother.ID > 0 Then
                    If FamMother.Families.Count = 0 Then
                        If Not IsNothing(FamMother.Address_ID) AndAlso FamMother.Address_ID > 0 Then
                            Odb.Addresses.DeleteOnSubmit(FamMother.Address)
                            FamMother.Address = Nothing
                            Odb.SubmitChanges()
                        End If
                        Dim MothName As OrphanageClasses.Name = FamMother.Name
                        delMoid = FamMother.ID
                        Odb.Mothers.DeleteOnSubmit(FamMother)
                        Odb.SubmitChanges()

                        If Not IsNothing(MothName) AndAlso MothName.ID > 0 Then
                            Odb.Names.DeleteOnSubmit(MothName)
                            Odb.SubmitChanges()
                        End If
                    End If
                End If
                'Delete Father
                If Not IsNothing(FamFather) AndAlso FamFather.ID > 0 Then
                    If FamFather.Families.Count = 0 Then
                        Dim FName As OrphanageClasses.Name = FamFather.Name
                        delFathid = FamFather.ID
                        Odb.Fathers.DeleteOnSubmit(FamFather)
                        Odb.SubmitChanges()

                        If Not IsNothing(FName) AndAlso FName.ID > 0 Then
                            Odb.Names.DeleteOnSubmit(FName)
                            Odb.SubmitChanges()
                        End If
                    End If
                End If
                Odb.SubmitChanges()
                ' Delete Family Data
                tr.Complete()
                Try
                    If famID > 0 Then Updater.DeletesFamily(famID)
                    If delMoid > 0 Then Updater.DeletesMother(delMoid)
                    If DelOidas > 0 Then Updater.DeletesOrphan(DelOidas)
                    If delBoId > 0 Then Updater.DeletesBondsMan(delBoId)
                    If delFathid > 0 Then Updater.DeletesFather(delFathid)
                Catch
                End Try
            End Using
            Return True
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return False
        End Try
    End Function
    Public Shared Function DeleteBondsMan(ByVal bondID As Integer) As Boolean
        Try
            Dim Odb As New OrphanageDB.Odb()
            Using tr = New Transactions.TransactionScope()
                Dim qF = From faml In Odb.BondsMans Where faml.ID = bondID Select faml
                If qF.Count <> 1 Then Return False
                Dim bon = qF.First()
                Dim add1 As OrphanageClasses.Address = bon.Address
                'Delete Orphans
                If bon.Orphans.Count > 0 Then
                    Dim DeletedOrphans As New ArrayList()
                    For Each orphan As OrphanageClasses.Orphan In bon.Orphans
                        If Not IsNothing(orphan.Bills) AndAlso orphan.Bills.Count > 0 Then
                            Odb.Bills.DeleteAllOnSubmit(orphan.Bills)                            
                            Odb.SubmitChanges()
                        End If
                        If Not IsNothing(orphan.Bail_ID) AndAlso orphan.Bail_ID > 0 Then
                            If orphan.Bail.Families.Count = 0 AndAlso orphan.Bail.Orphans.Count = 1 Then
                                If orphan.Bail.Bills.Count > 0 Then
                                    Odb.Bills.DeleteAllOnSubmit(orphan.Bail.Bills)
                                    Odb.SubmitChanges()
                                End If
                                'Odb.Bails.DeleteOnSubmit(orphan.Bail)
                                orphan.Bail = Nothing
                                Odb.SubmitChanges()
                            End If
                        End If
                        If Not IsNothing(orphan.Education_ID) AndAlso orphan.Education_ID > 0 Then
                            Odb.Studies.DeleteOnSubmit(orphan.Study)
                            orphan.Study = Nothing
                            Odb.SubmitChanges()
                        End If
                        If Not IsNothing(orphan.Health_ID) AndAlso orphan.Health_ID > 0 Then
                            Odb.Healthies.DeleteOnSubmit(orphan.Healthy)
                            orphan.Healthy = Nothing
                            Odb.SubmitChanges()
                        End If
                        DeletedOrphans.Add(orphan)
                    Next
                    If DeletedOrphans.Count > 0 Then
                        For Each delO As OrphanageClasses.Orphan In DeletedOrphans
                            Odb.Orphans.DeleteOnSubmit(delO)
                            Odb.SubmitChanges()
                            Dim ONAme As OrphanageClasses.Name = delO.Name
                            If Not IsNothing(ONAme) AndAlso ONAme.ID > 0 Then
                                Odb.Names.DeleteOnSubmit(ONAme)
                                Odb.SubmitChanges()
                            End If
                        Next
                    End If
                End If
                If Not IsNothing(add1) AndAlso add1.ID > 0 Then
                    bon.Address = Nothing
                    Odb.Addresses.DeleteOnSubmit(add1)
                    Odb.SubmitChanges()
                End If
                Dim BoName As OrphanageClasses.Name = bon.Name
                Odb.BondsMans.DeleteOnSubmit(bon)
                Odb.Names.DeleteOnSubmit(BoName)
                Odb.SubmitChanges()
                tr.Complete()
                Try
                    If bondID > 0 Then Updater.DeletesBondsMan(bondID)
                Catch
                End Try
            End Using
            Return True
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return False
        End Try
    End Function
    Public Shared Function DeleteOrphan(ByVal OrphId As Integer) As Boolean
        Try
            Dim Odb As New OrphanageDB.Odb()
            Dim DeletedOrphans As New ArrayList()
            Dim q = From orp In Odb.Orphans Where orp.ID = OrphId Select orp

            Dim orphan As OrphanageClasses.Orphan = q.FirstOrDefault()
            Dim DeletedBondsMen As New ArrayList()
            If IsNothing(orphan) Then Return False
            Using tr = New Transactions.TransactionScope()
                If Not IsNothing(orphan.Bills) AndAlso orphan.Bills.Count > 0 Then
                    Odb.Bills.DeleteAllOnSubmit(orphan.Bills)
                    Odb.SubmitChanges()
                End If
                If Not IsNothing(orphan.Bail_ID) AndAlso orphan.Bail_ID > 0 Then
                    If orphan.Bail.Families.Count = 0 AndAlso orphan.Bail.Orphans.Count = 1 Then
                        If orphan.Bail.Bills.Count > 0 Then
                            Odb.Bills.DeleteAllOnSubmit(orphan.Bail.Bills)
                            Odb.SubmitChanges()
                        End If
                        Odb.Bails.DeleteOnSubmit(orphan.Bail)
                        orphan.Bail = Nothing
                        Odb.SubmitChanges()
                    End If
                End If
                If Not IsNothing(orphan.Education_ID) AndAlso orphan.Education_ID > 0 Then
                    Odb.Studies.DeleteOnSubmit(orphan.Study)
                    orphan.Study = Nothing
                    Odb.SubmitChanges()
                End If
                If Not IsNothing(orphan.Health_ID) AndAlso orphan.Health_ID > 0 Then
                    Odb.Healthies.DeleteOnSubmit(orphan.Healthy)
                    orphan.Healthy = Nothing
                    Odb.SubmitChanges()
                End If
                If Not IsNothing(orphan.BondsMan_ID) AndAlso orphan.BondsMan_ID > 0 Then
                    If orphan.BondsMan.Orphans.Count = 1 Then
                        If Not IsNothing(orphan.BondsMan.Address_ID) AndAlso orphan.BondsMan.Address_ID > 0 Then
                            Odb.Addresses.DeleteOnSubmit(orphan.BondsMan.Address)
                            orphan.BondsMan.Address = Nothing
                            Odb.SubmitChanges()
                        End If
                        DeletedBondsMen.Add(orphan.BondsMan)
                    End If
                End If
                DeletedOrphans.Add(orphan)
                If DeletedOrphans.Count > 0 Then
                    For Each delO As OrphanageClasses.Orphan In DeletedOrphans
                        Odb.Orphans.DeleteOnSubmit(delO)
                        Odb.SubmitChanges()
                        Dim ONAme As OrphanageClasses.Name = delO.Name
                        If Not IsNothing(ONAme) AndAlso ONAme.ID > 0 Then
                            Odb.Names.DeleteOnSubmit(ONAme)
                            Odb.SubmitChanges()
                        End If
                    Next
                End If
                If DeletedBondsMen.Count > 0 Then
                    For Each bo As OrphanageClasses.BondsMan In DeletedBondsMen
                        Dim BONAme As OrphanageClasses.Name = bo.Name
                        Odb.BondsMans.DeleteOnSubmit(bo)
                        If Not IsNothing(BONAme) AndAlso BONAme.ID > 0 Then
                            Odb.Names.DeleteOnSubmit(BONAme)
                            Odb.SubmitChanges()
                        End If
                    Next
                End If
                tr.Complete()
                Return True
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return False
        End Try
    End Function

    Public Shared Function DeleteBox(ByVal Box_Id As Integer) As Boolean
        Try
            Dim Odb As New OrphanageDB.Odb()
            Dim q = From bbx In Odb.Boxes Where bbx.ID = Box_Id Select bbx

            Dim bx As OrphanageClasses.Box = q.FirstOrDefault()
            Using tr = New Transactions.TransactionScope()
                If Not IsNothing(bx) Then
                    'Transforms
                    If (Not IsNothing(bx.Transforms) AndAlso bx.Transforms.Count > 0) OrElse
                        (Not IsNothing(bx.Transforms1) AndAlso bx.Transforms1.Count > 0) Then
                        Dim ret As DialogResult = MessageBox.Show("إن حذف هذا الحساب سيؤدي إلى حذف جميع التحويلات المالية منه وإليه!" & Chr(10) & Chr(13) & "هل تريد المتابعة؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        If ret = DialogResult.Yes Then
                            If (Not IsNothing(bx.Transforms) AndAlso bx.Transforms.Count > 0) Then
                                Odb.Transforms.DeleteAllOnSubmit(bx.Transforms)
                            End If
                            If (Not IsNothing(bx.Transforms1) AndAlso bx.Transforms1.Count > 0) Then
                                Odb.Transforms.DeleteAllOnSubmit(bx.Transforms1)
                            End If
                            Odb.SubmitChanges()
                        Else
                            Return False
                        End If
                    End If
                    'Bills
                    If (Not IsNothing(bx.Bills) AndAlso bx.Bills.Count > 0) Then
                        Dim ret As DialogResult = MessageBox.Show("إن حذف هذا الحساب سيؤدي إلى حذف جميع الفواتير المتعلقة به!" & Chr(10) & Chr(13) & "هل تريد المتابعة؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        If ret = DialogResult.Yes Then
                            Odb.Bills.DeleteAllOnSubmit(bx.Bills)
                            Odb.SubmitChanges()
                        Else
                            Return False
                        End If
                    End If
                    'Bails
                    If (Not IsNothing(bx.Bails) AndAlso bx.Bails.Count > 0) Then
                        Dim ret As DialogResult = MessageBox.Show("إن حذف هذا الحساب سيؤدي إلى حذف جميع الكفالات المتعلقة به!" & Chr(10) & Chr(13) & "هل تريد المتابعة؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        If ret = DialogResult.Yes Then
                            Dim BaiCount = bx.Bails.Count - 1
                            For Bi = 0 To BaiCount
                                Dim bal = bx.Bails(0)
                                If Not IsNothing(bal.Families) AndAlso bal.Families.Count > 0 Then
                                    Dim FamCount As Integer = bal.Families.Count - 1
                                    For Fi = 0 To FamCount
                                        Dim fam = bal.Families(0)
                                        fam.IsBaild = False
                                        fam.Bail = Nothing
                                    Next
                                    Odb.SubmitChanges()
                                End If
                                If Not IsNothing(bal.Bills) AndAlso bal.Bills.Count > 0 Then
                                    Dim BilCount = bal.Bills.Count - 1
                                    For Fi = 0 To BilCount
                                        Dim fam = bal.Bills(0)
                                        fam.Bail = Nothing
                                    Next
                                    Odb.SubmitChanges()
                                End If
                                If Not IsNothing(bal.Orphans) AndAlso bal.Orphans.Count > 0 Then
                                    Dim OrpsCount = bal.Orphans.Count - 1
                                    For Fi = 0 To OrpsCount
                                        Dim fam = bal.Orphans(0)
                                        fam.IsBailed = False
                                        fam.Bail = Nothing
                                    Next
                                    Odb.SubmitChanges()
                                End If
                                Odb.Bails.DeleteOnSubmit(bal)
                                Odb.SubmitChanges()
                            Next
                        Else
                            Return False
                        End If
                    End If
                    'Supporter
                    If (Not IsNothing(bx.Supporters) AndAlso bx.Supporters.Count > 0) Then
                        Dim ret As DialogResult = MessageBox.Show("إن حذف هذا الحساب سيؤدي إلى حذف جميع الكفلاء المتعلقين به!" & Chr(10) & Chr(13) & "هل تريد المتابعة؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        If ret = DialogResult.Yes Then
                            Dim SupsCount = bx.Supporters.Count - 1
                            For Si = 0 To SupsCount
                                Dim supp = bx.Supporters(0)
                                If Not IsNothing(supp.Address) AndAlso supp.Address_ID > 0 Then
                                    Odb.Addresses.DeleteOnSubmit(supp.Address)
                                    supp.Address = Nothing
                                    'Odb.SubmitChanges()
                                End If
                                If Not IsNothing(supp.Name) AndAlso supp.Name_ID > 0 Then
                                    Odb.Names.DeleteOnSubmit(supp.Name)
                                    supp.Name = Nothing
                                    'Odb.SubmitChanges()
                                End If
                                If Not IsNothing(supp.Bails) AndAlso supp.Bails.Count > 0 Then
                                    Dim BaiCount = supp.Bails.Count - 1
                                    For Bi = 0 To BaiCount
                                        Dim bal = supp.Bails(0)
                                        If Not IsNothing(bal.Families) AndAlso bal.Families.Count > 0 Then
                                            Dim FamCount As Integer = bal.Families.Count - 1
                                            For Fi = 0 To FamCount
                                                Dim fam = bal.Families(0)
                                                fam.IsBaild = False
                                                fam.Bail = Nothing
                                            Next
                                            Odb.SubmitChanges()
                                        End If
                                        If Not IsNothing(bal.Bills) AndAlso bal.Bills.Count > 0 Then
                                            Dim BilCount = bal.Bills.Count - 1
                                            For Fi = 0 To BilCount
                                                Dim fam = bal.Bills(0)
                                                fam.Bail = Nothing
                                            Next
                                            Odb.SubmitChanges()
                                        End If
                                        If Not IsNothing(bal.Orphans) AndAlso bal.Orphans.Count > 0 Then
                                            Dim OrpsCount = bal.Orphans.Count - 1
                                            For Fi = 0 To OrpsCount
                                                Dim fam = bal.Orphans(0)
                                                fam.IsBailed = False
                                                fam.Bail = Nothing
                                            Next
                                            Odb.SubmitChanges()
                                        End If
                                        Odb.Bails.DeleteOnSubmit(bal)
                                        Odb.SubmitChanges()
                                    Next
                                End If
                                If Not IsNothing(supp.Orphans) AndAlso supp.Orphans.Count > 0 Then
                                    Dim Ocount = supp.Orphans.Count - 1
                                    For Oi = 0 To Ocount
                                        Dim O = supp.Orphans(0)
                                        O.Supporter = Nothing
                                        Odb.SubmitChanges()
                                    Next
                                End If
                                Odb.Supporters.DeleteOnSubmit(supp)
                                Odb.SubmitChanges()
                            Next
                        Else
                            Return False
                        End If
                    End If
                    Odb.Boxes.DeleteOnSubmit(bx)
                    Odb.SubmitChanges()
                    tr.Complete()
                    Try
                        Updater.DeletesBox(Box_Id)
                    Catch
                    End Try
                    Return True
                Else
                    Return True
                End If
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return False
        End Try
    End Function
    Public Shared Function DeleteBail(ByVal Bal_id As Integer) As Boolean
        Try
            Dim Odb As New OrphanageDB.Odb()
            Dim q = From bbx In Odb.Bails Where bbx.ID = Bal_id Select bbx
            Dim bal As OrphanageClasses.Bail = q.FirstOrDefault()
            Using tr = New Transactions.TransactionScope()
                If Not IsNothing(bal.Families) AndAlso bal.Families.Count > 0 Then
                    Dim FamCount As Integer = bal.Families.Count - 1
                    For Fi = 0 To FamCount
                        Dim fam = bal.Families(0)
                        fam.IsBaild = False
                        fam.Bail = Nothing
                    Next
                    Odb.SubmitChanges()
                End If
                If Not IsNothing(bal.Bills) AndAlso bal.Bills.Count > 0 Then
                    Dim BilCount = bal.Bills.Count - 1
                    For Fi = 0 To BilCount
                        Dim fam = bal.Bills(0)
                        fam.Bail = Nothing
                    Next
                    Odb.SubmitChanges()
                End If
                If Not IsNothing(bal.Orphans) AndAlso bal.Orphans.Count > 0 Then
                    Dim OrpsCount = bal.Orphans.Count - 1
                    For Fi = 0 To OrpsCount
                        Dim fam = bal.Orphans(0)
                        fam.IsBailed = False
                        fam.Bail = Nothing
                    Next
                    Odb.SubmitChanges()
                End If
                Odb.Bails.DeleteOnSubmit(bal)
                Odb.SubmitChanges()
                tr.Complete()
                Try
                    Updater.DeletesBail(Bal_id)
                Catch
                End Try
                Return True
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return False
        End Try
    End Function
    Public Shared Function DeleteBill(ByVal Bal_id As Integer) As Boolean
        Try
            Dim Odb As New OrphanageDB.Odb()
            Dim q = From bbx In Odb.Bills Where bbx.ID = Bal_id Select bbx
            Dim bal As OrphanageClasses.Bill = q.FirstOrDefault()
            Using tr = New Transactions.TransactionScope()
                Odb.Bills.DeleteOnSubmit(bal)
                Odb.SubmitChanges()
                tr.Complete()
                Try
                    Updater.DeletesBill(Bal_id)
                Catch
                End Try
                Return True
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return False
        End Try
    End Function
    Public Shared Function DeleteTransform(ByVal Tran_id As Integer)
        Try
            Dim Odb As New OrphanageDB.Odb()
            Dim q = From bbx In Odb.Transforms Where bbx.ID = Tran_id Select bbx
            Dim tra As OrphanageClasses.Transform = q.FirstOrDefault()
            If IsNothing(tra) Then Return True
            Using tr = New Transactions.TransactionScope()
                Odb.Transforms.DeleteOnSubmit(tra)
                Odb.SubmitChanges()
                tr.Complete()
                Try
                    Updater.DeletesTransform(Tran_id)
                Catch
                End Try
                Return True
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return False
        End Try
    End Function
    Public Shared Function UndoBill(ByVal Bal_id As Integer) As Boolean
        Try
            Dim Odb As New OrphanageDB.Odb()
            Dim q = From bbx In Odb.Bills Where bbx.ID = Bal_id Select bbx
            Dim bal As OrphanageClasses.Bill = q.FirstOrDefault()
            Dim qbx = From bx In Odb.Boxes Where bx.ID = bal.Box_ID
            Dim qBox As OrphanageClasses.Box = qbx.FirstOrDefault()
            Using tr = New Transactions.TransactionScope()
                If bal.IsDeposite Then
                    bal.Box.Amount -= bal.Amount
                    Odb.SubmitChanges()
                Else
                    bal.Box.Amount += bal.Amount
                    Odb.SubmitChanges()
                End If
                Odb.Bills.DeleteOnSubmit(bal)
                Odb.SubmitChanges()
                tr.Complete()
                Try
                    Updater.UpdatesBox(qBox)
                    Updater.DeletesBill(Bal_id)
                Catch
                End Try
                Return True
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return False
        End Try
    End Function
    Public Shared Function UndoTransform(ByVal tra_id As Integer)
        Try
            Dim Odb As New OrphanageDB.Odb()
            Dim q = From bbx In Odb.Transforms Where bbx.ID = tra_id Select bbx
            Dim tra As OrphanageClasses.Transform = q.FirstOrDefault()
            Dim qsbx = From bx In Odb.Boxes Where bx.ID = tra.SourceBox_ID
            Dim qSBox As OrphanageClasses.Box = qsbx.FirstOrDefault()
            Dim qdbx = From bx In Odb.Boxes Where bx.ID = tra.DestinationBox_ID
            Dim qDBox As OrphanageClasses.Box = qdbx.FirstOrDefault()
            Dim Bil_Id As Integer = 0
            Dim QBills = From bil In Odb.Bills Where bil.Bill_Number = tra.Tranc_Number AndAlso _
                         tra.RegDate.ToString().Substring(0, 10) = bil.RegDate.ToString().Substring(0, 10) AndAlso _
                        bil.Bill_Date = tra.Tranc_Date AndAlso bil.User_ID = tra.User_ID AndAlso bil.Note Like "*بشكل اتو*"
            Using tr = New Transactions.TransactionScope()
                If Not IsNothing(QBills.FirstOrDefault()) Then
                    Dim bilcount As Integer = QBills.Count - 1                    
                    For i As Integer = 0 To bilcount
                        Bil_Id = QBills(0).ID
                        Odb.Bills.DeleteOnSubmit(QBills(0))
                        Odb.SubmitChanges()
                    Next
                End If
                qSBox.Amount += tra.Source_Amount
                qDBox.Amount -= tra.Des_Amount
                Odb.Transforms.DeleteOnSubmit(tra)
                Odb.SubmitChanges()
                tr.Complete()
            End Using
            Try
                If Bil_Id > 0 Then Updater.DeletesBill(Bil_Id)
                Updater.UpdatesBox(qSBox)
                Updater.UpdatesBox(qDBox)
                Updater.DeletesTransform(tra_id)
            Catch
            End Try
            Return True

        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return False
        End Try
    End Function

    Public Shared Function DeleteSupporter(ByVal Supp_id As Integer)
        Try
            Dim Odb As New OrphanageDB.Odb()
            Dim q = From sup In Odb.Supporters Where sup.ID = Supp_id Select sup
            Dim supp As OrphanageClasses.Supporter = q.FirstOrDefault()
            If IsNothing(supp) Then
                Return True
            End If
            Using tr = New Transactions.TransactionScope()
                Dim delAddress As OrphanageClasses.Address = supp.Address
                Dim DelName As OrphanageClasses.Name = supp.Name
                If Not IsNothing(supp.Address) AndAlso supp.Address_ID > 0 Then
                    supp.Address = Nothing
                    Odb.Addresses.DeleteOnSubmit(delAddress)
                    Odb.SubmitChanges()
                End If
                If Not IsNothing(supp.Bails) AndAlso supp.Bails.Count > 0 Then
                    Dim BaiCount = supp.Bails.Count - 1
                    For Bi = 0 To BaiCount
                        Dim bal = supp.Bails(0)
                        If Not IsNothing(bal.Families) AndAlso bal.Families.Count > 0 Then
                            Dim FamCount As Integer = bal.Families.Count - 1
                            For Fi = 0 To FamCount
                                Dim fam = bal.Families(0)
                                fam.IsBaild = False
                                fam.Bail = Nothing
                            Next
                            Odb.SubmitChanges()
                        End If
                        If Not IsNothing(bal.Bills) AndAlso bal.Bills.Count > 0 Then
                            Dim BilCount = bal.Bills.Count - 1
                            For Fi = 0 To BilCount
                                Dim fam = bal.Bills(0)
                                fam.Bail = Nothing
                            Next
                            Odb.SubmitChanges()
                        End If
                        If Not IsNothing(bal.Orphans) AndAlso bal.Orphans.Count > 0 Then
                            Dim OrpsCount = bal.Orphans.Count - 1
                            For Fi = 0 To OrpsCount
                                Dim fam = bal.Orphans(0)
                                fam.IsBailed = False
                                fam.Bail = Nothing
                            Next
                            Odb.SubmitChanges()
                        End If
                        Odb.Bails.DeleteOnSubmit(bal)
                        Odb.SubmitChanges()
                    Next
                End If
                If Not IsNothing(supp.Orphans) AndAlso supp.Orphans.Count > 0 Then
                    Dim Ocount = supp.Orphans.Count - 1
                    For Oi = 0 To Ocount
                        Dim O = supp.Orphans(0)
                        O.Supporter = Nothing
                        Odb.SubmitChanges()
                    Next
                End If
                Odb.Supporters.DeleteOnSubmit(supp)
                Odb.SubmitChanges()
                If Not IsNothing(supp.Name) AndAlso supp.Name_ID > 0 Then
                    supp.Name = Nothing
                    Odb.Names.DeleteOnSubmit(DelName)
                    Odb.SubmitChanges()
                End If
                tr.Complete()
                ExceptionsManager.RaiseDeleted("الكفيل رقم " & Supp_id)
                Try
                    Updater.DeletesSupporter(Supp_id)
                Catch
                End Try
                Return True
            End Using
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return False
        End Try
    End Function
End Class
