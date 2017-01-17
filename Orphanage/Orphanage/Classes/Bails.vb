Public Class Bails

#Region "Properties"


    Private _SkipedIds As ArrayList
    Public ReadOnly Property SkipedIds() As ArrayList
        Get
            Return _SkipedIds
        End Get
    End Property

    Private _CancelFamiliesBails As Boolean
    Public Property CancelFamiliesBails() As Boolean
        Get
            Return _CancelFamiliesBails
        End Get
        Set(ByVal value As Boolean)
            _CancelFamiliesBails = value
        End Set
    End Property
    Private _CancelOrphansBails As Boolean
    Public Property CancelOrphansBails As Boolean
        Get
            Return _CancelOrphansBails
        End Get
        Set(ByVal value As Boolean)
            _CancelOrphansBails = value
        End Set
    End Property

    Private _HasSuporterColor As Boolean
    Public ReadOnly Property HasSuporterColor As Boolean
        Get
            Return _HasSuporterColor
        End Get
    End Property

    Private _SupporterColor As Color
    Public ReadOnly Property SupporterColor As Color
        Get
            Return _SupporterColor
        End Get
    End Property
    Private _IsFamily As Boolean
    Public Property IsFamily() As Boolean
        Get
            Return _IsFamily
        End Get
        Set(ByVal value As Boolean)
            _IsFamily = value
        End Set
    End Property

    Private _IsOrphan As Boolean
    Public Property IsOrphan() As Boolean
        Get
            Return _IsOrphan
        End Get
        Set(ByVal value As Boolean)
            _IsOrphan = value
        End Set
    End Property

    Private _FamiliesIds As Integer()
    Public Property FamiliesIds() As Integer()
        Get
            Return _FamiliesIds
        End Get
        Set(ByVal value As Integer())
            _FamiliesIds = value
        End Set
    End Property

    Private _OrphansIds As Integer()
    Public Property OrphansIds() As Integer()
        Get
            Return _OrphansIds
        End Get
        Set(ByVal value As Integer())
            _OrphansIds = value
        End Set
    End Property

    Private _ReplaceOldBails As Boolean
    Public Property ReplaceOldBails() As Boolean
        Get
            Return _ReplaceOldBails
        End Get
        Set(ByVal value As Boolean)
            _ReplaceOldBails = value
        End Set
    End Property
#End Region
#Region "Constractors"
    Public Sub New()
        _FamiliesIds = Nothing
        _IsFamily = False
        _IsOrphan = False
        _OrphansIds = Nothing
        _ReplaceOldBails = False
        _CancelOrphansBails = False
        _CancelFamiliesBails = False
        _SkipedIds = New ArrayList()
    End Sub
    Public Sub New(ByVal Ids() As Integer, ByVal IsFamilies As Boolean)
        If IsFamilies Then
            _FamiliesIds = Ids
            _IsFamily = True
            _IsOrphan = False
            _OrphansIds = Nothing
        Else
            _FamiliesIds = Nothing
            _IsFamily = False
            _IsOrphan = True
            _OrphansIds = Ids
        End If
        _ReplaceOldBails = False
        _CancelOrphansBails = False
        _CancelFamiliesBails = False
        _SkipedIds = New ArrayList()
    End Sub
    Public Sub New(ByVal Ids() As Integer, ByVal IsFamilies As Boolean, ByVal ReplaceOldBails As Boolean)
        If IsFamilies Then
            _FamiliesIds = Ids
            _IsFamily = True
            _IsOrphan = False
            _OrphansIds = Nothing
        Else
            _FamiliesIds = Nothing
            _IsFamily = False
            _IsOrphan = True
            _OrphansIds = Ids
        End If
        _ReplaceOldBails = ReplaceOldBails
        _CancelOrphansBails = False
        _CancelFamiliesBails = False
        _SkipedIds = New ArrayList()
    End Sub
#End Region

    Public Sub DoBails()
        Dim i As Decimal = 0D
        Dim All As Decimal = 0D
        _SkipedIds.Clear()
        If IsNothing(_FamiliesIds) AndAlso IsNothing(_OrphansIds) Then
            Throw New Exception("قم بإدخال بعض القيود من أجل الكفالة")
            Exit Sub
        End If
        If _IsFamily Then
            If IsNothing(_FamiliesIds) Then
                Throw New Exception("قم بإدخال بعض القيود من أجل الكفالة")
                Exit Sub
            End If
            Dim BailsIds() As Integer = Getter.GetFamiliesBails()
            If IsNothing(BailsIds) Then
                Throw New Exception("لايوجد كفالات عائلية صالحة مدخلة")
                Exit Sub
            End If
            Dim frm As New FrmBailsSelector(False, BailsIds)
            If frm.ShowDialog() = DialogResult.OK Then
                Dim tempBail As OrphanageClasses.Bail = frm.SelectedBail
                _HasSuporterColor = tempBail.Supporter.Color_Mark.HasValue
                If _HasSuporterColor Then
                    _SupporterColor = Color.FromArgb(CInt(tempBail.Supporter.Color_Mark.Value))
                End If
                All = _FamiliesIds.Length
                For Each famId In _FamiliesIds
                    Dim ForFamId As Integer = famId
                    If Getter.IsFamilyHasBaildOrphans(ForFamId) Then
                        If CancelOrphansBails = False Then
                            i += 1
                            ExceptionsManager.RaiseOnStatus(New MyException("لا يمكن كفالة العائلة لأنها تحوي على ايتام مكفولين", False, True))
                            ProgressSate.ShowStatueProgress(Math.Ceiling(((i / All) * 100D)), "")
                            _SkipedIds.Add(ForFamId)
                            Continue For
                        Else
                            If Not removeOrphansBails(ForFamId) Then
                                i += 1
                                ExceptionsManager.RaiseOnStatus(New MyException("لا يمكن الغاء كفالات الأيتام", False, True))
                                ProgressSate.ShowStatueProgress(Math.Ceiling(((i / All) * 100D)), "")
                                _SkipedIds.Add(ForFamId)
                                Continue For
                            End If
                        End If
                    End If
                    Using mBillDc As New OrphanageDB.Odb
                        Using tr = New Transactions.TransactionScope()
                            Dim q = From fam In mBillDc.Families Where fam.ID = ForFamId Select fam
                            Dim q1 = From fam In mBillDc.Bails Where fam.ID = tempBail.ID Select fam

                            If Not IsNothing(q.FirstOrDefault()) AndAlso q.Count > 0 Then
                                Dim temp As OrphanageClasses.Family = q.FirstOrDefault()
                                If Me._ReplaceOldBails Then
                                    temp.IsBaild = True
                                    'temp.Baild_ID = q1.FirstOrDefault().ID
                                    temp.Bail = q1.FirstOrDefault()
                                    mBillDc.SubmitChanges()
                                    Try
                                        Updater.UpdatesFamily(temp)
                                    Catch
                                    End Try
                                Else
                                    If temp.IsBaild AndAlso Not IsNothing(temp.Bail) Then
                                        i += 1
                                        ExceptionsManager.RaiseOnStatus(New MyException("العائلة مكفولة الرجاء الغاء الكفالة", False, True))
                                        ProgressSate.ShowStatueProgress(Math.Ceiling(((i / All) * 100D)), "")
                                        _SkipedIds.Add(ForFamId)
                                        Continue For
                                    Else
                                        temp.IsBaild = True
                                        'temp.Baild_ID = q1.FirstOrDefault().ID
                                        temp.Bail = q1.FirstOrDefault()
                                        mBillDc.SubmitChanges()
                                        Try
                                            Updater.UpdatesFamily(temp)
                                        Catch
                                        End Try
                                    End If
                                End If
                            End If
                            ExceptionsManager.RaiseSaved()
                            Try
                                Updater.UpdatesBail(tempBail)
                                Updater.UpdatesSupporter(tempBail.Supporter)
                            Catch
                            End Try
                            tr.Complete()
                        End Using
                        mBillDc.Dispose()
                    End Using
                    i += 1
                    Dim prec As Integer = Math.Ceiling(((i / All) * 100D))
                    ProgressSate.ShowStatueProgress(prec, "")
                Next
                ProgressSate.ShowStatueProgress(100, "")
            End If
        Else
            If IsNothing(_OrphansIds) Then
                Throw New Exception("قم بإدخال بعض القيود من أجل الكفالة")
            End If
            Dim BailsIds() As Integer = Getter.GetOrphansBails()
            If IsNothing(BailsIds) Then
                Throw New Exception("لايوجد كفالات صالحة مدخلة")
                Exit Sub
            End If
            Dim frm As New FrmBailsSelector(False, BailsIds)
            If frm.ShowDialog() = DialogResult.OK Then
                Dim tempBail As OrphanageClasses.Bail = frm.SelectedBail
                _HasSuporterColor = tempBail.Supporter.Color_Mark.HasValue
                If _HasSuporterColor Then
                    _SupporterColor = Color.FromArgb(CInt(tempBail.Supporter.Color_Mark.Value))
                End If
                All = _OrphansIds.Length
                For Each famId In _OrphansIds
                    Dim ForFamId As Integer = famId

                    Using mBillDc As New OrphanageDB.Odb
                        Using tr = New Transactions.TransactionScope()
                            Dim q = From fam In mBillDc.Orphans Where fam.ID = ForFamId Select fam
                            Dim q1 = From fam In mBillDc.Bails Where fam.ID = tempBail.ID Select fam

                            If Not IsNothing(q.FirstOrDefault()) AndAlso q.Count > 0 Then
                                Dim temp As OrphanageClasses.Orphan = q.FirstOrDefault()
                                If temp.Family.IsBaild OrElse temp.Bail_ID.HasValue Then
                                    If _CancelFamiliesBails = False Then
                                        i += 1
                                        ExceptionsManager.RaiseOnStatus(New MyException("عائلة هذا اليتيم مكفولة الرجاء الغاء الكفالة", False, True))
                                        ProgressSate.ShowStatueProgress(Math.Ceiling(((i / All) * 100D)), "")
                                        _SkipedIds.Add(ForFamId)
                                        Continue For
                                    Else
                                        Try
                                            temp.Family.IsBaild = False
                                            temp.Bail = Nothing
                                            mBillDc.SubmitChanges()
                                            Try
                                                Updater.UpdatesFamily(temp.Family)
                                                Updater.UpdatesOrphan(temp)
                                            Catch
                                            End Try
                                        Catch
                                            i += 1
                                            ExceptionsManager.RaiseOnStatus(New MyException("لا يمكن الغاء كفالة العائلة", False, True))
                                            ProgressSate.ShowStatueProgress(Math.Ceiling(((i / All) * 100D)), "")
                                            _SkipedIds.Add(ForFamId)
                                            Continue For
                                        End Try
                                    End If
                                End If
                                If Me._ReplaceOldBails Then
                                    temp.IsBailed = True
                                    'temp.Baild_ID = q1.FirstOrDefault().ID
                                    temp.Bail = q1.FirstOrDefault()
                                    'temp.Supporter = tempBail.Supporter
                                    mBillDc.SubmitChanges()
                                    Try
                                        Updater.UpdatesOrphan(temp)
                                    Catch
                                    End Try
                                Else
                                    If temp.IsBailed AndAlso temp.Bail_ID.HasValue Then
                                        i += 1
                                        ExceptionsManager.RaiseOnStatus(New MyException("هذا اليتيم مكفول الرجاء الغاء الكفالة", False, True))
                                        ProgressSate.ShowStatueProgress(Math.Ceiling(((i / All) * 100D)), "")
                                        _SkipedIds.Add(ForFamId)
                                        Continue For
                                    Else
                                        temp.IsBailed = True
                                        'temp.Baild_ID = q1.FirstOrDefault().ID
                                        temp.Bail = q1.FirstOrDefault()
                                        'temp.Supporter = tempBail.Supporter
                                        mBillDc.SubmitChanges()
                                        Try
                                            Updater.UpdatesOrphan(temp)
                                        Catch
                                        End Try
                                    End If
                                End If
                            End If
                            ExceptionsManager.RaiseSaved()
                            Try
                                Updater.UpdatesBail(tempBail)
                                Updater.UpdatesSupporter(tempBail.Supporter)
                            Catch
                            End Try
                            tr.Complete()
                        End Using
                        mBillDc.Dispose()
                    End Using
                    i += 1
                    Dim prec As Integer = Math.Ceiling(((i / All) * 100D))
                    ProgressSate.ShowStatueProgress(prec, "")
                Next
                ProgressSate.ShowStatueProgress(100, "")
            End If
        End If
    End Sub
    Public Sub UnDoBails()
        Dim i As Decimal = 0D
        Dim All As Decimal = 0D
        _SkipedIds.Clear()
        If IsNothing(_FamiliesIds) AndAlso IsNothing(_OrphansIds) Then
            Throw New Exception("قم بإدخال بعض القيود من أجل الكفالة")
            Exit Sub
        End If
        If _IsFamily Then
            If IsNothing(_FamiliesIds) Then
                Throw New Exception("قم بإدخال بعض القيود من أجل الكفالة")
                Exit Sub
            End If
            _HasSuporterColor = True
            _SupporterColor = Color.Black
            All = _FamiliesIds.Length
            For Each famId In _FamiliesIds
                Dim ForFamId As Integer = famId
                Using mBillDc As New OrphanageDB.Odb
                    Using tr = New Transactions.TransactionScope()
                        Dim tempBail As OrphanageClasses.Bail = Nothing
                        Dim q = From fam In mBillDc.Families Where fam.ID = ForFamId Select fam
                        If Not IsNothing(q.FirstOrDefault()) AndAlso q.Count > 0 Then
                            Dim temp As OrphanageClasses.Family = q.FirstOrDefault()
                            tempBail = temp.Bail
                            temp.IsBaild = False
                            'temp.Baild_ID = q1.FirstOrDefault().ID
                            temp.Bail = Nothing
                            mBillDc.SubmitChanges()
                        End If
                        ExceptionsManager.RaiseSaved()
                        Try
                            Updater.UpdatesFamily(q.FirstOrDefault())
                            Updater.UpdatesBail(tempBail)
                            Updater.UpdatesSupporter(tempBail.Supporter)
                        Catch

                        End Try
                        tr.Complete()
                    End Using
                    mBillDc.Dispose()
                End Using
                i += 1
                Dim prec As Integer = Math.Ceiling(((i / All) * 100D))
                ProgressSate.ShowStatueProgress(prec, "")
            Next
        ProgressSate.ShowStatueProgress(100, "")
        Else
            If IsNothing(_OrphansIds) Then
                Throw New Exception("قم بإدخال بعض القيود من أجل الكفالة")
            End If
            _HasSuporterColor = False
            _SupporterColor = Nothing
            All = _OrphansIds.Length
            For Each famId In _OrphansIds
                Dim ForFamId As Integer = famId

                Using mBillDc As New OrphanageDB.Odb
                    Using tr = New Transactions.TransactionScope()
                        Dim q = From fam In mBillDc.Orphans Where fam.ID = ForFamId Select fam
                        Dim tempBail As OrphanageClasses.Bail = Nothing
                        If Not IsNothing(q.FirstOrDefault()) AndAlso q.Count > 0 Then
                            Dim temp As OrphanageClasses.Orphan = q.FirstOrDefault()
                            tempBail = temp.Bail
                            temp.IsBailed = False
                            'temp.Baild_ID = q1.FirstOrDefault().ID
                            temp.Bail = Nothing
                            temp.Supporter = Nothing
                            mBillDc.SubmitChanges()
                        End If
                        ExceptionsManager.RaiseSaved()
                        Try
                            Updater.UpdatesOrphan(q.FirstOrDefault())
                            Updater.UpdatesBail(tempBail)
                            Updater.UpdatesSupporter(tempBail.Supporter)
                        Catch

                        End Try
                        tr.Complete()
                    End Using
                    mBillDc.Dispose()
                End Using
                i += 1
                Dim prec As Integer = Math.Ceiling(((i / All) * 100D))
                ProgressSate.ShowStatueProgress(prec, "")
            Next
            ProgressSate.ShowStatueProgress(100, "")
        End If
    End Sub
    Private Function removeOrphansBails(ByVal FamId As Integer) As Boolean
        Dim ret As Boolean = False
        Try
            Using Odb As New OrphanageDB.Odb
                Dim q = From orps In Odb.Orphans Where orps.Family_ID = FamId Select orps
                If Not IsNothing(q.FirstOrDefault) AndAlso q.Count > 0 Then
                    For Each orph In q
                        If orph.IsBailed OrElse orph.Bail_ID.HasValue Then
                            Dim tempBail As OrphanageClasses.Bail = Nothing
                            tempBail = orph.Bail
                            orph.IsBailed = False
                            orph.Bail = Nothing
                            orph.Supporter = Nothing
                            Odb.SubmitChanges()
                            Try
                                Updater.UpdatesOrphan(orph)
                                Updater.UpdatesSupporter(tempBail.Supporter)
                                Updater.UpdatesBail(tempBail)
                            Catch
                            End Try
                        End If
                    Next
                End If
                Odb.Dispose()
            End Using
            ret = True
        Catch
            ret = False
        End Try
        Return ret
    End Function
End Class
