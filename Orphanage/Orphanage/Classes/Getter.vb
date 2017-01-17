
Public Class Getter
#Region "Transforms"
    Public Shared Function GetBoxTransfors(ByVal _id As Integer) As Integer()
        Try
            Dim Ret_ID() As Integer
            Dim Odb As New OrphanageDB.Odb()
            Odb.ObjectTrackingEnabled = False
            Dim q = From bil In Odb.Transforms
                    Where (bil.SourceBox_ID = _id) OrElse bil.DestinationBox_ID = _id
                    Select bil.ID Distinct
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Ret_ID = q.ToArray()
            Else
                Ret_ID = Nothing
            End If
            Odb.Dispose()
            Return Ret_ID
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

#End Region
#Region "Box"
    Public Shared Function GetBoxbyBailID(ByVal _id As Integer) As Integer
        Try
            Dim Ret_ID As Integer = 0
            Dim Odb As New OrphanageDB.Odb()
            Odb.ObjectTrackingEnabled = False
            Dim q = From bil In Odb.Bails
                    Where (bil.ID = _id)
                    Select bil.Box_ID
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Ret_ID = q.FirstOrDefault()
            Else
                Ret_ID = 0
            End If
            Odb.Dispose()
            Return Ret_ID
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

#End Region
#Region "Bill"
    Public Shared Function GetFamilyBills(ByVal F_ID As Integer) As Integer()
        Dim ret() As Integer = Nothing
        Using Odb As New OrphanageDB.Odb
            Odb.ObjectTrackingEnabled = False
            Dim arr As New ArrayList()
            If My.Settings.ShowHiddenObject Then
                Dim q = From bal In Odb.Bills
                    Where bal.Family_ID = F_ID
                    Select bal.ID Distinct
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    arr.AddRange(q.ToArray())
                End If
                q = From bal In Odb.Bills Join orp In Odb.Orphans On orp.ID Equals bal.Orphan_ID
                    Join fam In Odb.Families On fam.ID Equals orp.Family_ID
                    Where bal.Family_ID = F_ID
                    Select bal.ID Distinct
                For Each sId In q
                    If Not arr.Contains(sId) Then arr.Add(sId)
                Next
            Else
                Dim q = From bal In Odb.Bills Join fam In Odb.Families On
                        bal.Family_ID Equals fam.ID
                    Where bal.Family_ID = F_ID And fam.IsExcluded = False
                    Select bal.ID Distinct
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    arr.AddRange(q.ToArray())
                End If
                q = From bal In Odb.Bills Join orp In Odb.Orphans On orp.ID Equals bal.Orphan_ID
                    Join fam In Odb.Families On fam.ID Equals orp.Family_ID
                    Where bal.Family_ID = F_ID And fam.IsExcluded = False _
                            And (orp.IsExcluded = False _
                                    Or Not orp.IsExcluded.HasValue) _
                                Select bal.ID Distinct
                For Each sId In q
                    If Not arr.Contains(sId) Then arr.Add(sId)
                Next
            End If
            If IsNothing(arr) OrElse arr.Count <= 0 Then
                ret = Nothing
            Else
                ret = CType(arr.ToArray(GetType(Integer)), Integer())
            End If
            Odb.Dispose()
        End Using
        Return ret
    End Function
    Public Shared Function GetFamilyBillsCount(ByVal F_ID As Integer) As SByte
        Dim ret As SByte = 0
        Using Odb As New OrphanageDB.Odb
            Odb.ObjectTrackingEnabled = False
            Dim arr As New ArrayList()
            If My.Settings.ShowHiddenObject Then
                Dim q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID Join bal In Odb.Bails On
                    orp.Bail_ID Equals bal.ID
                    Where fam.ID = F_ID
                    Select bal.Supporter_ID Distinct
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    arr.AddRange(q.ToArray())
                End If
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID Join bal In Odb.Bails On
                    fam.Baild_ID Equals bal.ID
                    Where fam.ID = F_ID
                    Select bal.Supporter_ID Distinct
                For Each sId In q
                    If Not sId.HasValue Then Continue For
                    If Not arr.Contains(sId) Then arr.Add(sId)
                Next
            Else
                Dim q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID Join bal In Odb.Bails On
                    orp.Bail_ID Equals bal.ID
                    Where fam.ID = F_ID And fam.IsExcluded = False And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                    Select bal.Supporter_ID Distinct
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    arr.AddRange(q.ToArray())
                End If
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                        orp.Family_ID Equals fam.ID Join bal In Odb.Bails On
                        orp.Bail_ID Equals bal.ID
                            Where fam.ID = F_ID And fam.IsExcluded = False _
                            And (orp.IsExcluded = False _
                                    Or Not orp.IsExcluded.HasValue) _
                                Select bal.Supporter_ID Distinct
                For Each sId In q
                    If Not sId.HasValue Then Continue For
                    If Not arr.Contains(sId.Value) Then arr.Add(sId.Value)
                Next
            End If
            If IsNothing(arr) OrElse arr.Count <= 0 Then
                ret = 0
            Else
                ret = arr.Count()
            End If
            Odb.Dispose()
        End Using
        Return ret
    End Function
    Public Shared Function GetBoxBills(ByVal _id As Integer) As Integer()
        Try
            Dim Ret_ID() As Integer
            Dim Odb As New OrphanageDB.Odb()
            Odb.ObjectTrackingEnabled = False
            Dim q = From bil In Odb.Bills Where (bil.Box_ID = _id)
                    Select bil.ID
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Ret_ID = q.ToArray()
            Else
                Ret_ID = Nothing
            End If
            Odb.Dispose()
            Return Ret_ID
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetBoxBails(ByVal _id As Integer) As Integer()
        Try
            Dim Ret_ID() As Integer
            Dim Odb As New OrphanageDB.Odb()
            Odb.ObjectTrackingEnabled = False
            Dim q = From bx In Odb.Boxes Join bil In Odb.Bails On
                    bil.Box_ID Equals bx.ID
                    Where bx.ID = _id
                    Select bil.ID
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Ret_ID = q.ToArray()
            Else
                Ret_ID = Nothing
            End If
            Odb.Dispose()
            Return Ret_ID
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Shared Function GetSupporterBillsCount(ByVal S_Id As Integer) As Integer
        Dim Ret As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q = From sup In odb.Supporters Join bx In odb.Boxes
                    On bx.ID Equals sup.Box_ID Join bill In odb.Bills On
                    bill.Box_ID Equals bx.ID
                    Where sup.ID = S_Id
                    Select bill.ID
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.Count
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function

    Public Shared Function GetSupporterBills(ByVal S_Id As Integer) As Integer()
        Dim Ret() As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q = From sup In odb.Supporters Join bx In odb.Boxes
                    On bx.ID Equals sup.Box_ID Join bill In odb.Bills On
                    bill.Box_ID Equals bx.ID
                    Where sup.ID = S_Id
                    Select bill.ID
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.ToArray()
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function

#End Region
#Region "Supporter"
    Public Shared Function GetSupporterByID(ByVal _id As Integer, ByVal Odb As OrphanageDB.Odb) As OrphanageClasses.Supporter
        Try
            Dim q = From orp In Odb.Supporters Where orp.ID = _id Select orp
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Return q.First()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetSupporterByID(ByVal _id As Integer) As OrphanageClasses.Supporter
        Try
            Dim ret As OrphanageClasses.Supporter = Nothing
            Using odb As New OrphanageDB.Odb()
                odb.ObjectTrackingEnabled = False
                Dim q = From orp In odb.Supporters Where orp.ID = _id Select orp
                If Not IsNothing(q) AndAlso q.Count >= 1 Then
                    ret = q.First()
                Else
                    ret = Nothing
                End If
                odb.Dispose()
                Return ret
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetFamilySupporters(ByVal F_ID As Integer) As Integer()
        Dim ret() As Integer = Nothing
        Using Odb As New OrphanageDB.Odb
            Odb.ObjectTrackingEnabled = False
            Dim arr As New ArrayList()
            If My.Settings.ShowHiddenObject Then
                Dim q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID Join bal In Odb.Bails On
                    orp.Bail_ID Equals bal.ID
                    Where fam.ID = F_ID
                    Select bal.Supporter_ID Distinct
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    arr.AddRange(q.ToArray())
                End If
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID Join bal In Odb.Bails On
                    fam.Baild_ID Equals bal.ID
                    Where fam.ID = F_ID
                    Select bal.Supporter_ID Distinct
                For Each sId In q
                    If Not sId.HasValue Then Continue For
                    If Not arr.Contains(sId) Then arr.Add(sId)
                Next
            Else
                Dim q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID Join bal In Odb.Bails On
                    orp.Bail_ID Equals bal.ID
                    Where fam.ID = F_ID And fam.IsExcluded = False And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                    Select bal.Supporter_ID Distinct
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    arr.AddRange(q.ToArray())
                End If
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                        orp.Family_ID Equals fam.ID Join bal In Odb.Bails On
                        orp.Bail_ID Equals bal.ID
                            Where fam.ID = F_ID And fam.IsExcluded = False _
                            And (orp.IsExcluded = False _
                                    Or Not orp.IsExcluded.HasValue) _
                                Select bal.Supporter_ID Distinct
                For Each sId In q
                    If Not sId.HasValue Then Continue For
                    If Not arr.Contains(sId.Value) Then arr.Add(sId.Value)
                Next
            End If
            If IsNothing(arr) OrElse arr.Count <= 0 Then
                ret = Nothing
            Else
                ret = CType(arr.ToArray(GetType(Integer)), Integer())
            End If
            Odb.Dispose()
        End Using
        Return ret
    End Function
    Public Shared Function GetFamilySupportersCount(ByVal F_ID As Integer) As SByte
        Dim ret As SByte = 0
        Using Odb As New OrphanageDB.Odb
            Odb.ObjectTrackingEnabled = False
            Dim arr As New ArrayList()
            If My.Settings.ShowHiddenObject Then
                Dim q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID Join bal In Odb.Bails On
                    orp.Bail_ID Equals bal.ID
                    Where fam.ID = F_ID
                    Select bal.Supporter_ID Distinct
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    arr.AddRange(q.ToArray())
                End If
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID Join bal In Odb.Bails On
                    fam.Baild_ID Equals bal.ID
                    Where fam.ID = F_ID
                    Select bal.Supporter_ID Distinct
                For Each sId In q
                    If Not sId.HasValue Then Continue For
                    If Not arr.Contains(sId) Then arr.Add(sId)
                Next
            Else
                Dim q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID Join bal In Odb.Bails On
                    orp.Bail_ID Equals bal.ID
                    Where fam.ID = F_ID And fam.IsExcluded = False And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                    Select bal.Supporter_ID Distinct
                If Not IsNothing(q) AndAlso q.Count > 0 Then
                    arr.AddRange(q.ToArray())
                End If
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                        orp.Family_ID Equals fam.ID Join bal In Odb.Bails On
                        orp.Bail_ID Equals bal.ID
                            Where fam.ID = F_ID And fam.IsExcluded = False _
                            And (orp.IsExcluded = False _
                                    Or Not orp.IsExcluded.HasValue) _
                                Select bal.Supporter_ID Distinct
                For Each sId In q
                    If Not sId.HasValue Then Continue For
                    If Not arr.Contains(sId.Value) Then arr.Add(sId.Value)
                Next
            End If
            If IsNothing(arr) OrElse arr.Count <= 0 Then
                ret = 0
            Else
                ret = arr.Count()
            End If
            Odb.Dispose()
        End Using
        Return ret
    End Function
    Public Shared Function GetboxSupporters(ByVal _id As Integer) As Integer()
        Try
            Dim Ret_ID() As Integer
            Dim Odb As New OrphanageDB.Odb()
            Odb.ObjectTrackingEnabled = False
            Dim q = From bail In Odb.Bails
                    Where bail.Box_ID = _id AndAlso bail.Supporter_ID.HasValue
                    Select bail.Supporter_ID.Value Distinct
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Ret_ID = q.ToArray()
            Else
                Ret_ID = Nothing
            End If
            Odb.Dispose()
            Return Ret_ID
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetSupporter_IDByOrphan_ID(ByVal _id As Integer) As Integer
        Try
            Dim Ret_ID As Integer = 0
            Dim Odb As New OrphanageDB.Odb()
            Odb.ObjectTrackingEnabled = False
            Dim q = From orp In Odb.Orphans Join bal In Odb.Bails
                    On orp.Bail_ID Equals bal.ID
                    Where orp.ID = _id
                    Select bal.Supporter_ID
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Ret_ID = q.First()
            Else
                Ret_ID = 0
            End If
            Odb.Dispose()
            Return Ret_ID
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function
#End Region

#Region "Bails"
    Public Shared Function GetFamiliesBails() As Integer()
        Try
            Dim ret() As Integer = Nothing
            Using Odb As New OrphanageDB.Odb
                Dim q = From bails In Odb.Bails Join sup In Odb.Supporters On sup.ID Equals bails.Supporter_ID
                        Where bails.Is_Family = True AndAlso sup.Is_Still_Support = True
                        Select bails.ID
                If Not IsNothing(q.FirstOrDefault()) AndAlso q.Count > 0 Then
                    ret = q.ToArray()
                End If
                Odb.Dispose()
            End Using
            Return ret
        Catch
            Return Nothing
        End Try
    End Function
    Public Shared Function GetOrphansBails() As Integer()
        Try
            Dim ret() As Integer = Nothing
            Using Odb As New OrphanageDB.Odb
                Dim q = From bails In Odb.Bails Join sup In Odb.Supporters On sup.ID Equals bails.Supporter_ID
                        Where bails.Is_Family = False AndAlso sup.Is_Still_Support = True
                        Select bails.ID
                If Not IsNothing(q.FirstOrDefault()) AndAlso q.Count > 0 Then
                    ret = q.ToArray()
                End If
                Odb.Dispose()
            End Using
            Return ret
        Catch
            Return Nothing
        End Try
    End Function
#End Region
#Region "Father"
    Public Shared Function GetFather_IDByOrphan_ID(ByVal _id As Integer) As Integer
        Try
            Dim Ret_ID As Integer = 0
            Dim Odb As New OrphanageDB.Odb()
            Odb.ObjectTrackingEnabled = False
            Dim q = From orp In Odb.Orphans Join fam In Odb.Families On fam.ID Equals orp.Family_ID
                    Where orp.ID = _id
                    Select fam.Father_ID

            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Ret_ID = q.First()
            Else
                Ret_ID = 0
            End If
            Odb.Dispose()
            Return Ret_ID
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function
    Public Shared Function GetMotherFathersCount(ByVal M_Id As Integer) As SByte
        Dim Ret As SByte = 0
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From fam In odb.Families
                    Where fam.Mother_ID = M_Id
                    Select fam.Father_ID Distinct
            Else
                q = From fam In odb.Families
                    Where fam.Mother_ID = M_Id And _
                            (fam.IsExcluded = False)
                    Select fam.Father_ID Distinct
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.Count
            Else
                Ret = 0
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function

    Public Shared Function GetMotherFathers(ByVal M_Id As Integer) As Integer()
        Dim Ret() As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From fam In odb.Families
                    Where fam.Mother_ID = M_Id
                    Select fam.Father_ID Distinct
            Else
                q = From fam In odb.Families
                    Where fam.Mother_ID = M_Id And _
                            (fam.IsExcluded = False)
                    Select fam.Father_ID Distinct
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.ToArray()
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function
    Public Shared Function GetFatherByID(ByVal _id As Integer, ByVal Odb As OrphanageDB.Odb) As OrphanageClasses.Father
        Try
            Dim q = From orp In Odb.Fathers Where orp.ID = _id Select orp
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Return q.First()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetFatherByID(ByVal _id As Integer) As OrphanageClasses.Father
        Try
            Dim ret As OrphanageClasses.Father = Nothing
            Using odb As New OrphanageDB.Odb()
                odb.ObjectTrackingEnabled = False
                Dim q = From orp In odb.Fathers Where orp.ID = _id Select orp
                If Not IsNothing(q) AndAlso q.Count >= 1 Then
                    ret = q.First()
                Else
                    ret = Nothing
                End If
                odb.Dispose()
            End Using
            Return ret
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

#End Region

#Region "Family"
    Public Shared Function GetFamilyColor(ByVal famliy_ID As Integer) As Color
        Dim ColorM As Long = -102

        Try
            Using Odb As New OrphanageDB.Odb
                Odb.ObjectTrackingEnabled = False
                Dim q = From orp In Odb.Families
                        Where orp.ID = famliy_ID
                        Select orp

                If IsNothing(q) OrElse q.Count = 0 OrElse IsNothing(q.FirstOrDefault()) Then Return Color.Black
                Dim fam As OrphanageClasses.Family = q.FirstOrDefault()
                If My.Settings.UseSupporterColorForBails Then
                    If fam.IsBaild AndAlso fam.Baild_ID.HasValue Then
                        Dim qS = From ss In Odb.Supporters Join
                                 bb In Odb.Bails On bb.Supporter_ID Equals ss.ID
                                 Where bb.ID = fam.Baild_ID.Value
                                 Select ss.Color_Mark
                        If qS.FirstOrDefault().HasValue Then
                            ColorM = qS.FirstOrDefault().Value
                        End If
                    Else
                        If fam.Color_Mark.HasValue Then
                            ColorM = fam.Color_Mark.Value
                        End If
                    End If
                Else
                    If fam.Color_Mark.HasValue Then
                        ColorM = fam.Color_Mark.Value
                    End If
                End If
            End Using
        Catch
            ColorM = -102
        End Try
        If ColorM = -102 Then
            Return Color.Black
        Else
            Return Color.FromArgb(ColorM)
        End If
    End Function
    Public Shared Function IsFamilyHasBaildOrphans(ByVal Fam_id As Integer) As Boolean
        Try
            Dim Ret As Boolean = False
            Dim Odb As New OrphanageDB.Odb()
            Odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From orp In Odb.Orphans
                        Where orp.Family_ID = Fam_id AndAlso orp.IsBailed = True
                        Select orp.Family_ID
            Else
                q = From orp In Odb.Orphans
                        Where orp.Family_ID = Fam_id AndAlso orp.IsBailed = True _
                        AndAlso (orp.IsExcluded = False OrElse Not orp.IsExcluded.HasValue)
                        Select orp.Family_ID
            End If
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Ret = True
            Else
                Ret = False
            End If
            Odb.Dispose()
            Return Ret
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Public Shared Function GetFamily_IDByOrphan_ID(ByVal _id As Integer) As Integer
        Try
            Dim Ret_ID As Integer = 0
            Dim Odb As New OrphanageDB.Odb()
            Odb.ObjectTrackingEnabled = False
            Dim q = From orp In Odb.Orphans
                    Where orp.ID = _id
                    Select orp.Family_ID
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Ret_ID = q.First()
            Else
                Ret_ID = 0
            End If
            Odb.Dispose()
            Return Ret_ID
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function
    Public Shared Function GetBailFamiles(ByVal B_Id As Integer) As Integer()
        Dim Ret() As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From bail In odb.Bails
                    Join fam In odb.Families
                    On bail.ID Equals fam.Baild_ID
                Where (bail.ID = B_Id)
                    Select fam.ID
            Else
                q = From bail In odb.Bails
                    Join fam In odb.Families
                    On bail.ID Equals fam.Baild_ID
                Where (bail.ID = B_Id And (fam.IsExcluded = False))
                    Select fam.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.ToArray()
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function
    Public Shared Function GetBailFamiliesCount(ByVal B_Id As Integer) As Integer
        Dim Ret As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From bail In odb.Bails
                    Join fam In odb.Families
                    On bail.ID Equals fam.Baild_ID
                Where (bail.ID = B_Id)
                    Select fam.ID
            Else
                q = From bail In odb.Bails
                    Join fam In odb.Families
                    On bail.ID Equals fam.Baild_ID
                Where (bail.ID = B_Id And (fam.IsExcluded = False))
                    Select fam.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.Count
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function
    Public Shared Function GetSupporterFamiles(ByVal S_Id As Integer) As Integer()
        Dim Ret() As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From sup In odb.Supporters Join bail In odb.Bails
                    On bail.Supporter_ID Equals sup.ID Join fam In odb.Families
                    On bail.ID Equals fam.Baild_ID
                    Where sup.ID = S_Id
                    Select fam.ID
            Else
                q = From sup In odb.Supporters Join bail In odb.Bails
                    On bail.Supporter_ID Equals sup.ID Join fam In odb.Families
                    On bail.ID Equals fam.Baild_ID
                    Where sup.ID = S_Id And (fam.IsExcluded = False)
                    Select fam.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.ToArray()
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function
    Public Shared Function GetSupporterFamiliesCount(ByVal S_Id As Integer) As Integer
        Dim Ret As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From sup In odb.Supporters Join bail In odb.Bails
                    On bail.Supporter_ID Equals sup.ID Join fam In odb.Families
                    On bail.ID Equals fam.Baild_ID
                    Where sup.ID = S_Id
                    Select fam.ID
            Else
                q = From sup In odb.Supporters Join bail In odb.Bails
                    On bail.Supporter_ID Equals sup.ID Join fam In odb.Families
                    On bail.ID Equals fam.Baild_ID
                    Where sup.ID = S_Id And (fam.IsExcluded = False)
                    Select fam.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.Count
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function
    Public Shared Function GetFatherFamiles(ByVal F_Id As Integer) As Integer()
        Dim Ret() As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From fam In odb.Families
                    Where (fam.Father_ID = F_Id)
                    Select fam.ID
            Else
                q = From fam In odb.Families Join fath In odb.Fathers
                    On fam.Father_ID Equals fath.ID
                    Where fam.Father_ID = F_Id And (fam.IsExcluded = False)
                    Select fam.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.ToArray()
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function
    Public Shared Function GetFatherFamiliesCount(ByVal F_Id As Integer) As Integer
        Dim Ret As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From fam In odb.Families
                    Where (fam.Father_ID = F_Id)
                    Select fam.ID
            Else
                q = From fam In odb.Families Join fath In odb.Fathers
                    On fam.Father_ID Equals fath.ID
                    Where fam.Father_ID = F_Id And (fam.IsExcluded = False)
                    Select fam.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.Count
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function
    Public Shared Function GetMotherFamiles(ByVal M_Id As Integer) As Integer()
        Dim Ret() As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From fam In odb.Families
                    Where (fam.Mother_ID = M_Id)
                    Select fam.ID
            Else
                q = From fam In odb.Families Join fath In odb.Fathers
                    On fam.Father_ID Equals fath.ID
                    Where fam.Mother_ID = M_Id And (fam.IsExcluded = False)
                    Select fam.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.ToArray()
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function
    Public Shared Function GetMotherFamiliesCount(ByVal M_Id As Integer) As Integer
        Dim Ret As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From fam In odb.Families
                    Where (fam.Mother_ID = M_Id)
                    Select fam.ID
            Else
                q = From fam In odb.Families Join fath In odb.Fathers
                    On fam.Father_ID Equals fath.ID
                    Where fam.Mother_ID = M_Id And (fam.IsExcluded = False)
                    Select fam.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.Count
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function
#End Region
#Region "BondsMan"
    Public Shared Function GetFamilyBondsman(ByVal F_ID As Integer) As Integer()
        Dim ret() As Integer = Nothing
        Using Odb As New OrphanageDB.Odb
            Odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer)
            If My.Settings.ShowHiddenObject Then
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID
                    Where fam.ID = F_ID
                    Select orp.BondsMan_ID Distinct
            Else
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID
                    Where fam.ID = F_ID And fam.IsExcluded = False And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                    Select orp.BondsMan_ID Distinct
            End If
            If IsNothing(q) OrElse q.Count <= 0 Then
                ret = Nothing
            Else
                ret = q.ToArray()
            End If
            Odb.Dispose()
        End Using
        Return ret
    End Function
    Public Shared Function GetFamilyBondsmanCount(ByVal F_ID As Integer) As SByte
        Dim ret As SByte = 0
        Using Odb As New OrphanageDB.Odb
            Odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer)
            If My.Settings.ShowHiddenObject Then
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID
                    Where fam.ID = F_ID
                    Select orp.BondsMan_ID Distinct
            Else
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID
                    Where fam.ID = F_ID And fam.IsExcluded = False And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                    Select orp.BondsMan_ID Distinct
            End If
            If IsNothing(q) OrElse q.Count <= 0 Then
                ret = 0
            Else
                ret = q.Count()
            End If
            Odb.Dispose()
        End Using
        Return ret
    End Function

    Public Shared Function GetBondsMan_IDByOrphan_ID(ByVal _id As Integer) As Integer
        Try
            Dim Ret_ID As Integer = 0
            Dim Odb As New OrphanageDB.Odb()
            Odb.ObjectTrackingEnabled = False
            Dim q = From orp In Odb.Orphans
                    Where orp.ID = _id
                    Select orp.BondsMan_ID
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Ret_ID = q.First()
            Else
                Ret_ID = 0
            End If
            Odb.Dispose()
            Return Ret_ID
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

#End Region
#Region "Mother"

    Public Shared Function GetMotherByID(ByVal _id As Integer, ByVal Odb As OrphanageDB.Odb) As OrphanageClasses.Mother
        Try
            Dim q = From orp In Odb.Mothers Where orp.ID = _id Select orp
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Return q.First()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetMotherByID(ByVal _id As Integer) As OrphanageClasses.Mother
        Try
            Dim ret As OrphanageClasses.Mother = Nothing
            Using odb As New OrphanageDB.Odb()
                odb.ObjectTrackingEnabled = False
                Dim q = From orp In odb.Mothers Where orp.ID = _id Select orp
                If Not IsNothing(q) AndAlso q.Count >= 1 Then
                    ret = q.First()
                Else
                    ret = Nothing
                End If
                odb.Dispose()
            End Using
            Return ret
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Shared Function GetBondsmanMothers(ByVal B_ID As Integer) As Integer()
        Dim ret() As Integer = Nothing
        Using Odb As New OrphanageDB.Odb
            Odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer)
            If My.Settings.ShowHiddenObject Then
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID
                    Where orp.BondsMan_ID = B_ID
                    Select fam.Mother_ID Distinct
            Else
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID
                    Where orp.BondsMan_ID = B_ID And fam.IsExcluded = False And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                    Select fam.Mother_ID Distinct
            End If
            If IsNothing(q) OrElse q.Count <= 0 Then
                ret = Nothing
            Else
                ret = q.ToArray()
            End If
            Odb.Dispose()
        End Using
        Return ret
    End Function
    Public Shared Function GetBondsmanMothersCount(ByVal B_ID As Integer) As SByte
        Dim ret As SByte = 0
        Using Odb As New OrphanageDB.Odb
            Odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer)
            If My.Settings.ShowHiddenObject Then
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID
                    Where orp.BondsMan_ID = B_ID
                    Select fam.Mother_ID Distinct
            Else
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID
                    Where orp.BondsMan_ID = B_ID And fam.IsExcluded = False And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                    Select fam.Mother_ID Distinct
            End If
            If IsNothing(q) OrElse q.Count <= 0 Then
                ret = 0
            Else
                ret = q.Count()
            End If
            Odb.Dispose()
        End Using
        Return ret
    End Function


    Public Shared Function GetMother_IDByOrphan_ID(ByVal _id As Integer) As Integer
        Try
            Dim Ret_ID As Integer = 0
            Dim Odb As New OrphanageDB.Odb()
            Odb.ObjectTrackingEnabled = False
            Dim q = From orp In Odb.Orphans Join fam In Odb.Families On fam.ID Equals orp.Family_ID
                    Where orp.ID = _id
                    Select fam.Mother_ID

            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Ret_ID = q.First()
            Else
                Ret_ID = 0
            End If
            Odb.Dispose()
            Return Ret_ID
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

#End Region
#Region "Orphan"

    Public Shared Function GetOrphanColor(ByVal orphan_Id As Integer) As Color
        Dim ColorM As Long = -102

        Try
            Using Odb As New OrphanageDB.Odb
                Odb.ObjectTrackingEnabled = False
                Dim q = From orp In Odb.Orphans
                Where (orp.ID = orphan_Id)
                        Select orp

                If IsNothing(q) OrElse q.Count = 0 OrElse IsNothing(q.FirstOrDefault()) Then Return Color.Black
                Dim fam As OrphanageClasses.Orphan = q.FirstOrDefault()
                If My.Settings.UseSupporterColorForBails Then
                    If fam.IsBailed AndAlso fam.Bail_ID.HasValue Then
                        Dim qS = From ss In Odb.Supporters Join
                                 bb In Odb.Bails On bb.Supporter_ID Equals ss.ID
                                 Where bb.ID = fam.Bail_ID.Value
                                 Select ss.Color_Mark
                        Dim coloRS As Long? = qS.FirstOrDefault()
                        If coloRS.HasValue Then
                            ColorM = coloRS.Value
                        Else
                            If fam.Color_Mark.HasValue Then
                                ColorM = fam.Color_Mark.Value
                            End If
                        End If
                    Else
                        If fam.Color_Mark.HasValue Then
                            ColorM = fam.Color_Mark.Value
                        End If
                    End If
                Else
                    If fam.Color_Mark.HasValue Then
                        ColorM = fam.Color_Mark.Value
                    End If
                End If
            End Using
        Catch
            ColorM = -102
        End Try
        If ColorM = -102 Then
            Return Color.Black
        Else
            Return Color.FromArgb(ColorM)
        End If
    End Function

    Public Shared Function GetOrphansColors(ByVal orphan_Id() As Integer) As Dictionary(Of Integer, Color)

        Dim ret As New Dictionary(Of Integer, Color)
        Try
            Using Odb As New OrphanageDB.Odb
                Odb.ObjectTrackingEnabled = False                
                Dim q = From orp In Odb.Orphans
                        Group Join bail In Odb.Bails Join ss In Odb.Supporters On
                                     bail.Supporter_ID Equals ss.ID
                                     On orp.Bail_ID Equals bail.ID
                Into bailsO = Group
                Select orp, bailsO

                If IsNothing(q) OrElse q.Count = 0 OrElse IsNothing(q.FirstOrDefault()) Then Return Nothing
                Dim retData = q.Where(Function(x) orphan_Id.Contains(x.orp.ID))
                For Each oSb In retData
                    Try
                        Dim ColorM As Long = -102
                        If My.Settings.UseSupporterColorForBails Then
                            If oSb.orp.IsBailed AndAlso oSb.orp.Bail_ID.HasValue Then
                                'Dim qS = From ss In Odb.Supporters Join
                                '         bb In Odb.Bails On bb.Supporter_ID Equals ss.ID
                                '         Where bb.ID = fam.Bail_ID.Value
                                '         Select ss.Color_Mark
                                Dim coloRS As Long? = oSb.bailsO(0).ss.Color_Mark
                                If coloRS.HasValue Then
                                    ColorM = coloRS.Value
                                End If
                            Else
                                If oSb.orp.Color_Mark.HasValue Then
                                    ColorM = oSb.orp.Color_Mark.Value
                                End If
                            End If
                        Else
                            If oSb.orp.Color_Mark.HasValue Then
                                ColorM = oSb.orp.Color_Mark.Value
                            End If
                        End If
                        If ColorM = -102 Then
                            ret.Add(oSb.orp.ID, Color.Black())
                        Else
                            ret.Add(oSb.orp.ID, Color.FromArgb(ColorM))
                        End If
                    Catch
                    End Try
                Next                
            End Using
        Catch
            Return Nothing
        End Try
        Return ret
    End Function

    Public Shared Function GetFatherOrphansNum(ByVal F_Id As Integer) As SByte
        Dim Ret As SByte = 0
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From fam In odb.Families Join orp In odb.Orphans
                    On orp.Family_ID Equals fam.ID
                    Where fam.Father_ID = F_Id
                    Select orp.ID
            Else
                q = From fam In odb.Families Join orp In odb.Orphans
                    On orp.Family_ID Equals fam.ID
                    Where fam.Father_ID = F_Id And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                            And (fam.IsExcluded = False)
                    Select orp.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.Count
            Else
                Ret = 0
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function

    Public Shared Function GetFatherOrphans(ByVal F_Id As Integer) As Integer()
        Dim Ret() As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From fam In odb.Families Join orp In odb.Orphans
                    On orp.Family_ID Equals fam.ID
                    Where fam.Father_ID = F_Id
                    Select orp.ID
            Else
                q = From fam In odb.Families Join orp In odb.Orphans
                    On orp.Family_ID Equals fam.ID
                    Where fam.Father_ID = F_Id And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                            And (fam.IsExcluded = False)
                    Select orp.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.ToArray()
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function

    Public Shared Function GetBondsManOrphansNum(ByVal B_Id As Integer) As SByte
        Dim Ret As SByte = 0
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From fam In odb.Families Join orp In odb.Orphans
                    On orp.Family_ID Equals fam.ID
                    Where orp.BondsMan_ID = B_Id
                    Select orp.ID
            Else
                q = From fam In odb.Families Join orp In odb.Orphans
                    On orp.Family_ID Equals fam.ID
                    Where orp.BondsMan_ID = B_Id And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                            And (fam.IsExcluded = False)
                    Select orp.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.Count
            Else
                Ret = 0
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function

    Public Shared Function GetBondsManOrphans(ByVal B_Id As Integer) As Integer()
        Dim Ret() As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From fam In odb.Families Join orp In odb.Orphans
                    On orp.Family_ID Equals fam.ID
                    Where orp.BondsMan_ID = B_Id
                    Select orp.ID
            Else
                q = From fam In odb.Families Join orp In odb.Orphans
                    On orp.Family_ID Equals fam.ID
                    Where orp.BondsMan_ID = B_Id And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                            And (fam.IsExcluded = False)
                    Select orp.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.ToArray()
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function


    Public Shared Function GetMotherOrphansNum(ByVal M_Id As Integer) As SByte
        Dim Ret As SByte = 0
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From fam In odb.Families Join orp In odb.Orphans
                    On orp.Family_ID Equals fam.ID
                    Where fam.Mother_ID = M_Id
                    Select orp.ID
            Else
                q = From fam In odb.Families Join orp In odb.Orphans
                    On orp.Family_ID Equals fam.ID
                    Where fam.Mother_ID = M_Id And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                            And (fam.IsExcluded = False)
                    Select orp.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.Count
            Else
                Ret = 0
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function

    Public Shared Function GetMotherOrphans(ByVal M_Id As Integer) As Integer()
        Dim Ret() As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From fam In odb.Families Join orp In odb.Orphans
                    On orp.Family_ID Equals fam.ID
                    Where fam.Mother_ID = M_Id
                    Select orp.ID
            Else
                q = From fam In odb.Families Join orp In odb.Orphans
                    On orp.Family_ID Equals fam.ID
                    Where fam.Mother_ID = M_Id And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                            And (fam.IsExcluded = False)
                    Select orp.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.ToArray()
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function

    Public Shared Function GetSupporterOrphans(ByVal S_Id As Integer) As Integer()
        Dim Ret() As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From sup In odb.Supporters Join bail In odb.Bails
                    On bail.Supporter_ID Equals sup.ID Join orp In odb.Orphans
                    On bail.ID Equals orp.Bail_ID
                    Where sup.ID = S_Id
                    Select orp.ID
            Else
                q = From sup In odb.Supporters Join bail In odb.Bails
                    On bail.Supporter_ID Equals sup.ID Join orp In odb.Orphans
                    On bail.ID Equals orp.Bail_ID
                    Where sup.ID = S_Id And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue)
                    Select orp.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.ToArray()
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function

    Public Shared Function GetSupporterOrphansCount(ByVal S_Id As Integer) As Integer
        Dim Ret As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer) = Nothing
            If My.Settings.ShowHiddenObject Then
                q = From sup In odb.Supporters Join bail In odb.Bails
                    On bail.Supporter_ID Equals sup.ID Join orp In odb.Orphans
                    On bail.ID Equals orp.Bail_ID
                    Where sup.ID = S_Id
                    Select orp.ID
            Else
                q = From sup In odb.Supporters Join bail In odb.Bails
                    On bail.Supporter_ID Equals sup.ID Join orp In odb.Orphans
                    On bail.ID Equals orp.Bail_ID
                    Where sup.ID = S_Id And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue)
                    Select orp.ID
            End If
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.Count
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function

    Public Shared Function GetOrphanByID(ByVal _id As Integer, ByVal odb As OrphanageDB.Odb) As OrphanageClasses.Orphan
        Try
            Dim q = From orp In odb.Orphans Where orp.ID = _id Select orp

            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Return q.First()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetOrphanBrothers(ByVal _ID As Integer) As Integer()
        Try
            Dim AllRecord As New ArrayList
            Using Odb As New OrphanageDB.Odb()
                Dim q = From orp In Odb.Orphans Join fam In Odb.Families
                        On orp.Family_ID Equals fam.ID
                        Where orp.ID = _ID
                        Select fam
                If IsNothing(q) OrElse q.Count <= 0 Then
                    Odb.Dispose()
                    Return Nothing
                End If
                Dim OFam As OrphanageClasses.Family = q.FirstOrDefault()
                Dim qF = From fam In Odb.Families Where fam.Father_ID = OFam.Father_ID Or
                         fam.Mother_ID = OFam.Mother_ID
                         Select fam.ID Distinct
                If IsNothing(qF) OrElse qF.Count <= 0 Then
                    Odb.Dispose()
                    Return Nothing
                End If
                For Each fam_ID In qF
                    Dim ors() = GetFamilyOrphans(fam_ID)
                    If Not IsNothing(ors) Then
                        For Each Oid In ors
                            If Oid <> _ID AndAlso Not AllRecord.Contains(Oid) Then
                                AllRecord.Add(Oid)
                            End If
                        Next
                    End If
                Next
                Odb.Dispose()
            End Using
            If AllRecord.Count > 0 Then
                Return CType(AllRecord.ToArray(GetType(Integer)), Integer())
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function GetFamilyOrphans(ByVal F_ID As Integer) As Integer()
        Dim ret() As Integer = Nothing
        Using Odb As New OrphanageDB.Odb
            Odb.ObjectTrackingEnabled = False
            Dim q As System.Linq.IQueryable(Of Integer)
            If My.Settings.ShowHiddenObject Then
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID
                    Where fam.ID = F_ID
                    Select orp.ID
            Else
                q = From fam In Odb.Families Join orp In Odb.Orphans On
                    orp.Family_ID Equals fam.ID
                    Where fam.ID = F_ID And fam.IsExcluded = False And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                    Select orp.ID
            End If
            If IsNothing(q) OrElse q.Count <= 0 Then
                ret = Nothing
            Else
                ret = q.ToArray()
            End If
            Odb.Dispose()
        End Using
        Return ret
    End Function
    Public Shared Function GetOrphanMaleBrothersNumber(ByVal _ID As Integer) As Byte
        Try
            Dim AllRecord As New ArrayList
            Using Odb As New OrphanageDB.Odb()
                Odb.ObjectTrackingEnabled = False
                Dim q As System.Linq.IQueryable(Of OrphanageClasses.Family)
                q = From orp In Odb.Orphans Join fam In Odb.Families
                        On orp.Family_ID Equals fam.ID
                        Where orp.ID = _ID
                        Select fam
                If IsNothing(q) OrElse q.Count <= 0 Then
                    Odb.Dispose()
                    Return 0
                End If
                Dim OFam As OrphanageClasses.Family = q.FirstOrDefault()
                Dim qF As System.Linq.IQueryable(Of Integer)
                If My.Settings.ShowHiddenObject Then
                    qF = From fam In Odb.Families Where fam.Father_ID = OFam.Father_ID Or
                         fam.Mother_ID = OFam.Mother_ID
                         Select fam.ID Distinct
                Else
                    qF = From fam In Odb.Families Where (fam.Father_ID = OFam.Father_ID Or
                         fam.Mother_ID = OFam.Mother_ID) And fam.IsExcluded = False
                         Select fam.ID Distinct
                End If
                If IsNothing(qF) OrElse qF.Count <= 0 Then
                    Odb.Dispose()
                    Return 0
                End If
                For Each fam_ID In qF
                    Dim FFIDD As Integer = fam_ID
                    Dim qOrs As System.Linq.IQueryable(Of Integer)
                    If My.Settings.ShowHiddenObject Then
                        qOrs = From orp In Odb.Orphans
                               Where orp.Family_ID = FFIDD And orp.Gender.Contains("ذ")
                               Select orp.ID
                    Else
                        qOrs = From orp In Odb.Orphans
                               Where orp.Family_ID = FFIDD And orp.Gender.Contains("ذ") _
                                     And (orp.IsExcluded = False _
                                                        Or Not orp.IsExcluded.HasValue) _
                               Select orp.ID
                    End If
                    For Each Oid In qOrs
                        If Oid <> _ID AndAlso Not AllRecord.Contains(Oid) Then
                            AllRecord.Add(Oid)
                        End If
                    Next
                Next
                Odb.Dispose()
            End Using
            If AllRecord.Count > 0 Then
                Return AllRecord.Count
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function GetOrphanFemaleBrothersNumber(ByVal _ID As Integer) As Byte
        Try
            Dim AllRecord As New ArrayList
            Using Odb As New OrphanageDB.Odb()
                Odb.ObjectTrackingEnabled = False
                Dim q As System.Linq.IQueryable(Of OrphanageClasses.Family)
                q = From orp In Odb.Orphans Join fam In Odb.Families
                        On orp.Family_ID Equals fam.ID
                        Where orp.ID = _ID
                        Select fam
                If IsNothing(q) OrElse q.Count <= 0 Then
                    Odb.Dispose()
                    Return 0
                End If
                Dim OFam As OrphanageClasses.Family = q.FirstOrDefault()
                Dim qF As System.Linq.IQueryable(Of Integer)
                If My.Settings.ShowHiddenObject Then
                    qF = From fam In Odb.Families Where fam.Father_ID = OFam.Father_ID Or
                         fam.Mother_ID = OFam.Mother_ID
                         Select fam.ID Distinct
                Else
                    qF = From fam In Odb.Families Where (fam.Father_ID = OFam.Father_ID Or
                         fam.Mother_ID = OFam.Mother_ID) And fam.IsExcluded = False
                         Select fam.ID Distinct
                End If
                If IsNothing(qF) OrElse qF.Count <= 0 Then
                    Odb.Dispose()
                    Return 0
                End If
                For Each fam_ID In qF
                    Dim FFIDD As Integer = fam_ID
                    Dim qOrs As System.Linq.IQueryable(Of Integer)
                    If My.Settings.ShowHiddenObject Then
                        qOrs = From orp In Odb.Orphans
                               Where orp.Family_ID = FFIDD And Not orp.Gender.Contains("ذ")
                               Select orp.ID
                    Else
                        qOrs = From orp In Odb.Orphans
                               Where orp.Family_ID = FFIDD And Not orp.Gender.Contains("ذ") _
                                     And (orp.IsExcluded = False _
                                                        Or Not orp.IsExcluded.HasValue) _
                               Select orp.ID
                    End If
                    For Each Oid In qOrs
                        If Oid <> _ID AndAlso Not AllRecord.Contains(Oid) Then
                            AllRecord.Add(Oid)
                        End If
                    Next
                Next
                Odb.Dispose()
            End Using
            If AllRecord.Count > 0 Then
                Return AllRecord.Count
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function GetFamilyMaleOrphansCount(ByVal _ID As Integer) As Byte
        Using Odb As New OrphanageDB.Odb()
            If _ID > 0 Then
                Dim qOrs As System.Linq.IQueryable(Of Integer)
                If My.Settings.ShowHiddenObject Then
                    qOrs = From orp In Odb.Orphans
                    Where (orp.Family_ID = _ID And orp.Gender.Contains("ذ"))
                           Select orp.ID

                Else
                    qOrs = From orp In Odb.Orphans
                           Where orp.Family_ID = _ID And orp.Gender.Contains("ذ") _
                           And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                           Select orp.ID
                End If
                If Not IsNothing(qOrs) AndAlso qOrs.Count > 0 Then
                    Return qOrs.Count
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        End Using
    End Function
    Public Shared Function GetFamilyFemaleOrphansCount(ByVal _ID As Integer) As Byte
        Using Odb As New OrphanageDB.Odb()
            If _ID > 0 Then
                Dim qOrs As System.Linq.IQueryable(Of Integer)
                If My.Settings.ShowHiddenObject Then
                    qOrs = From orp In Odb.Orphans
                    Where (orp.Family_ID = _ID And Not orp.Gender.Contains("ذ"))
                           Select orp.ID

                Else
                    qOrs = From orp In Odb.Orphans
                           Where orp.Family_ID = _ID And Not orp.Gender.Contains("ذ") _
                           And (orp.IsExcluded = False _
                                                    Or Not orp.IsExcluded.HasValue) _
                           Select orp.ID
                End If
                If Not IsNothing(qOrs) AndAlso qOrs.Count > 0 Then
                    Return qOrs.Count
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        End Using
    End Function

#End Region

    Public Shared Function GetSupporterBailsCount(ByVal S_Id As Integer) As Integer
        Dim Ret As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q = From sup In odb.Supporters Join bail In odb.Bails
                    On bail.Supporter_ID Equals sup.ID
                    Where sup.ID = S_Id
                    Select bail.ID
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.Count
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function

    Public Shared Function GetSupporterBails(ByVal S_Id As Integer) As Integer()
        Dim Ret() As Integer
        Using odb As New OrphanageDB.Odb()
            odb.ObjectTrackingEnabled = False
            Dim q = From sup In odb.Supporters Join bail In odb.Bails
                    On bail.Supporter_ID Equals sup.ID
                    Where sup.ID = S_Id
                    Select bail.ID
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                Ret = q.ToArray()
            Else
                Ret = Nothing
            End If
            odb.Dispose()
        End Using
        Return Ret
    End Function

    Public Shared Function GetBoxByID(ByVal _id As Integer, ByVal odb As OrphanageDB.Odb) As OrphanageClasses.Box
        Try
            Dim q = From orp In odb.Boxes Where orp.ID = _id Select orp
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Return q.First()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetBailByID(ByVal _id As Integer) As OrphanageClasses.Bail
        Try
            Dim Odb As New OrphanageDB.Odb()
            Dim q = From orp In Odb.Bails Where orp.ID = _id Select orp
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Return q.First()
            Else
                Return Nothing
            End If
            Odb.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetBillByID(ByVal _id As Integer) As OrphanageClasses.Bill
        Try
            Dim Odb As New OrphanageDB.Odb()
            Dim q = From orp In Odb.Bills Where orp.ID = _id Select orp
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Return q.First()
            Else
                Return Nothing
            End If
            Odb.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetTransformByID(ByVal _id As Integer) As OrphanageClasses.Transform
        Try
            Dim Odb As New OrphanageDB.Odb()
            Dim q = From orp In Odb.Transforms Where orp.ID = _id Select orp
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Return q.First()
            Else
                Return Nothing
            End If
            Odb.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetUserById(ByVal _id As Integer) As OrphanageClasses.User
        Try
            Dim Odb As New OrphanageDB.Odb()
            Dim q = From orp In Odb.Users Where orp.ID = _id Select orp
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Return q.First()
            Else
                Return Nothing
            End If
            Odb.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetUserByUserName(ByVal _name As String) As OrphanageClasses.User
        Try
            Dim Odb As New OrphanageDB.Odb()
            Dim q = From orp In Odb.Users Where orp.UserName.ToLower() = _name.ToLower() Select orp
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Return q.First()
            Else
                Return Nothing
            End If
            Odb.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Shared Function GetUnOrphanByID(ByVal _id As Integer, ByVal Odb As OrphanageDB.Odb) As OrphanageClasses.UnOrphan
        Try
            Dim q = From orp In Odb.UnOrphans Where orp.ID = _id Select orp
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Return q.First()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Shared Function GetBondsManByID(ByVal _id As Integer, ByVal odb As OrphanageDB.Odb) As OrphanageClasses.BondsMan
        Try
            Dim q = From orp In odb.BondsMans Where orp.ID = _id Select orp
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Return q.First()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetFamilyByID(ByVal _id As Integer, ByVal Odb As OrphanageDB.Odb) As OrphanageClasses.Family
        Try
            Dim q = From orp In Odb.Families Where orp.ID = _id Select orp
            If Not IsNothing(q) AndAlso q.Count >= 1 Then
                Return q.First()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function


    Public Shared Function GetImage(ByVal byts() As Byte, ByVal width As Integer, ByVal height As Integer) As Image
        If Not IsNothing(byts) Then
            Dim mem As New System.IO.MemoryStream(byts)
            Dim img As Image = Image.FromStream(mem)
            Dim retImg As New Bitmap(width, height)
            Dim g = Graphics.FromImage(retImg)
            g.DrawImage(img, 0, 0, width, height)
            g.Save()
            g.Dispose()
            img.Dispose()
            mem.Dispose()
            Return retImg
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetImage(ByVal byts() As Byte) As Image
        If Not IsNothing(byts) Then
            Dim mem As New System.IO.MemoryStream(byts)
            Dim img As Image = Image.FromStream(mem)
            mem.Dispose()
            Return img
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetThumbImage(ByVal byts() As Byte) As Image
        Return GetImage(byts, 50, 50)
    End Function
    Public Shared Function GetFullName(ByVal nam As OrphanageClasses.Name) As String
        If IsNothing(nam) OrElse IsNothing(nam.First) Then Return Nothing
        If IsNothing(nam.Father) OrElse nam.Father.Length = 0 Then
            If IsNothing(nam.Last) OrElse nam.Last.Length = 0 Then
                Return nam.First
            Else
                Return nam.First & " " & nam.Last
            End If
        Else
            If IsNothing(nam.Last) OrElse nam.Last.Length = 0 Then
                If My.Settings.UseFullname Then
                    Return nam.First & " " & nam.Father
                Else
                    Return nam.First
                End If
            Else
                If My.Settings.UseFullname Then
                    Return nam.First & " " & nam.Father & " " & nam.Last
                Else
                    Return nam.First & " " & nam.Last
                End If
            End If
        End If
    End Function
    Public Shared Function GetFullNameE(ByVal nam As OrphanageClasses.Name) As String
        If IsNothing(nam) OrElse IsNothing(nam.EName) Then Return Nothing
        If IsNothing(nam.EFather) OrElse nam.EFather.Length = 0 Then
            If IsNothing(nam.ELast) OrElse nam.ELast.Length = 0 Then
                Return nam.EName
            Else
                Return nam.EName & " " & nam.ELast
            End If
        Else
            If IsNothing(nam.ELast) OrElse nam.ELast.Length = 0 Then
                If My.Settings.UseFullname Then
                    Return nam.EName & " " & nam.EFather
                Else
                    Return nam.EName
                End If
            Else
                If My.Settings.UseFullname Then
                    Return nam.EName & " " & nam.EFather & " " & nam.ELast
                Else
                    Return nam.EName & " " & nam.EFather
                End If
            End If
        End If
    End Function
    Public Shared Function GetFullName(ByVal nam As NameForm.NameForm) As String
        If IsNothing(nam.Middle) OrElse nam.Middle.Length = 0 Then
            Return nam.First & " " & nam.Last
        Else
            If My.Settings.UseFullname Then
                Return nam.First & " " & nam.Middle & " " & nam.Last
            Else
                Return nam.First & " " & nam.Last
            End If
        End If
    End Function
    Public Shared Function GetAddress(ByVal nam As OrphanageClasses.Address) As String
        Dim ret As String = ""
        Dim sep As Char = My.Settings.AddressSeprator
        If IsNothing(nam) Then Return Nothing
        If Not IsNothing(nam.Country) AndAlso nam.Country.Length > 0 Then
            ret = nam.Country
        End If
        If Not IsNothing(nam.City) AndAlso nam.City.Length > 0 Then
            If ret.Length > 0 Then
                ret = ret & sep & nam.City
            Else
                ret = nam.City
            End If
        End If
        If Not IsNothing(nam.Town) AndAlso nam.Town.Length > 0 Then
            If ret.Length > 0 Then
                ret = ret & sep & nam.Town
            Else
                ret = nam.Town
            End If
        End If
        If Not IsNothing(nam.Street) AndAlso nam.Street.Length > 0 Then
            If ret.Length > 0 Then
                ret = ret & sep & nam.Street
            Else
                ret = nam.Street
            End If
        End If
        Return ret
    End Function
    Public Shared Function GetAddress(ByVal nam As AddressForm.AddressForm) As String
        Dim ret As String = ""
        Dim sep As Char = My.Settings.AddressSeprator
        If IsNothing(nam) Then Return Nothing
        If Not IsNothing(nam.Country) AndAlso nam.Country.Length > 0 Then
            ret = nam.Country
        End If
        If Not IsNothing(nam.City) AndAlso nam.City.Length > 0 Then
            If ret.Length > 0 Then
                ret = ret & sep & nam.City
            Else
                ret = nam.City
            End If
        End If
        If Not IsNothing(nam.Town) AndAlso nam.Town.Length > 0 Then
            If ret.Length > 0 Then
                ret = ret & sep & nam.Town
            Else
                ret = nam.Town
            End If
        End If
        If Not IsNothing(nam.Street) AndAlso nam.Street.Length > 0 Then
            If ret.Length > 0 Then
                ret = ret & sep & nam.Street
            Else
                ret = nam.Street
            End If
        End If
        Return ret
    End Function
    Public Shared Function GetFullEducation(ByVal edu As OrphanageClasses.Study) As String
        If edu.Stage.Contains("متخلف") Then
            Return edu.Stage
        Else
            Return edu.Stage
        End If
    End Function
End Class
