Imports Telerik.WinControls.UI
Imports Itenso.TimePeriod
Imports Orphanage.OrphanageClasses

Public Class Checker


    Public Shared Function checkFamilyCardId(ByVal FamId As ULong) As Integer()
        Try
            Dim Odb As New OrphanageDB.Odb()
            'خطأ باستخدام replace
            Dim q = From ft In Odb.Families
                Where ft.FamilyCard_Num = FamId
                Select ft.ID
            If Not IsNothing(q) And q.Count > 0 Then
                Return q.ToArray()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnDesktopNow(New MyException(ex.Message, True, True))
            Return Nothing
        End Try
    End Function

    'Public Shared Function checkOrphanByName(ByVal FirstName As String, ByVal UseLike As Boolean, ByVal Fam As OrphanageClasses.Family) As Integer()
    '    Try
    '        Dim Odb As New OrphanageDB.Odb()
    '        'خطأ باستخدام replace
    '        If UseLike Then
    '            For Each orp In Fam.Orphans
    '                If (orp.Name.First.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") = FirstName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "")) Then
    '                    Return New Integer() {orp.ID}
    '                End If
    '            Next
    '            Return Nothing
    '        Else
    '            For Each orp In Fam.Orphans
    '                If orp.Name.First = FirstName Then
    '                    Return New Integer() {orp.ID}
    '                End If
    '            Next
    '            Return Nothing
    '        End If
    '    Catch ex As Exception
    '        ExceptionsManager.RaiseOnDesktopNow(New MyException(ex.Message, True, True))
    '        Return Nothing
    '    End Try
    'End Function

    'Public Shared Function checkOrphanByName(ByVal FirstName As String, ByVal FatherName As String, ByVal UseLike As Boolean, ByVal Fam As OrphanageClasses.Family) As Integer()
    '    Try
    '        Dim Odb As New OrphanageDB.Odb()
    '        'خطأ باستخدام replace
    '        If UseLike Then
    '            For Each orp In Fam.Orphans
    '                If (orp.Name.First.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") = FirstName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "")) And _
    '                (orp.Name.Father.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") = FatherName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "")) Then
    '                    Return New Integer() {orp.ID}
    '                End If
    '            Next
    '            Return Nothing
    '        Else
    '            For Each orp In Fam.Orphans
    '                If orp.Name.First = FirstName And FatherName = orp.Name.Father Then
    '                    Return New Integer() {orp.ID}
    '                End If
    '            Next
    '            Return Nothing
    '        End If
    '    Catch ex As Exception
    '        ExceptionsManager.RaiseOnDesktopNow(New MyException(ex.Message, True, True))
    '        Return Nothing
    '    End Try

    'End Function

    'Public Shared Function checkBondsManByName(ByVal FirstName As String, ByVal LastName As String, ByVal UseLike As Boolean) As Integer()
    '    Try
    '        Dim Odb As New OrphanageDB.Odb()
    '        'خطأ باستخدام replace
    '        If UseLike Then
    '            Dim q = From ft In Odb.BondsMans
    '            Where (ft.Name.First.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") Like "*" & FirstName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") & "*") And _
    '            (ft.Name.Last.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") Like "*" & LastName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") & "*") _
    '                Select ft.ID
    '            If Not IsNothing(q) And q.Count > 0 Then
    '                Return q.ToArray()
    '            Else
    '                Return Nothing
    '            End If
    '        Else
    '            Dim q = From ft In Odb.BondsMans
    'Where (ft.Name.First = FirstName And ft.Name.Last = LastName)
    'Select ft.ID
    '            If Not IsNothing(q) And q.Count > 0 Then
    '                Return q.ToArray()
    '            Else
    '                Return Nothing
    '            End If

    '        End If
    '    Catch ex As Exception
    '        ExceptionsManager.RaiseOnDesktopNow(New MyException(ex.Message, True, True))
    '        Return Nothing
    '    End Try
    'End Function

    'Public Shared Function checkBondsManByName(ByVal FirstName As String, ByVal LastName As String, ByVal FatherName As String, ByVal UseLike As Boolean) As Integer()
    '    Try
    '        Dim Odb As New OrphanageDB.Odb()
    '        'خطأ باستخدام replace
    '        If UseLike Then
    '            Dim q = From ft In Odb.BondsMans
    '            Where (ft.Name.First.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") Like "*" & FirstName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") & "*") And _
    '            (ft.Name.Last.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") Like "*" & LastName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") & "*") And _
    '            (ft.Name.Father.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") Like "*" & FatherName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") & "*")
    '                Select ft.ID
    '            If Not IsNothing(q) And q.Count > 0 Then
    '                Return q.ToArray()
    '            Else
    '                Return Nothing
    '            End If
    '        Else
    '            Dim q = From ft In Odb.BondsMans
    'Where (ft.Name.First = FirstName And ft.Name.Last = LastName And FatherName = ft.Name.Father)
    'Select ft.ID
    '            If Not IsNothing(q) And q.Count > 0 Then
    '                Return q.ToArray()
    '            Else
    '                Return Nothing
    '            End If

    '        End If
    '    Catch ex As Exception
    '        ExceptionsManager.RaiseOnDesktopNow(New MyException(ex.Message, True, True))
    '        Return Nothing
    '    End Try
    'End Function

    'Public Shared Function checkMotherByName(ByVal FirstName As String, ByVal LastName As String, ByVal UseLike As Boolean) As Integer()
    '    Try
    '        Dim Odb As New OrphanageDB.Odb()
    '        'خطأ باستخدام replace
    '        If UseLike Then
    '            Dim q = From ft In Odb.Mothers
    '            Where (ft.Name.First.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") Like "*" & FirstName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") & "*") And _
    '            (ft.Name.Last.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") Like "*" & LastName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") & "*") _
    '                Select ft.ID
    '            If Not IsNothing(q) And q.Count > 0 Then
    '                Return q.ToArray()
    '            Else
    '                Return Nothing
    '            End If
    '        Else
    '            Dim q = From ft In Odb.Mothers
    'Where (ft.Name.First = FirstName And ft.Name.Last = LastName)
    'Select ft.ID
    '            If Not IsNothing(q) And q.Count > 0 Then
    '                Return q.ToArray()
    '            Else
    '                Return Nothing
    '            End If

    '        End If
    '    Catch ex As Exception
    '        ExceptionsManager.RaiseOnDesktopNow(New MyException(ex.Message, True, True))
    '        Return Nothing
    '    End Try

    'End Function

    'Public Shared Function checkMotherByName(ByVal FirstName As String, ByVal LastName As String, ByVal FatherName As String, ByVal UseLike As Boolean) As Integer()
    '    Try
    '        Dim Odb As New OrphanageDB.Odb()
    '        'خطأ باستخدام replace
    '        If UseLike Then
    '            Dim q = From ft In Odb.Mothers
    '            Where (ft.Name.First.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") Like "*" & FirstName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") & "*") And _
    '            (ft.Name.Last.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") Like "*" & LastName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") & "*") And _
    '            (ft.Name.Father.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") Like "*" & FatherName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") & "*")
    '                Select ft.ID
    '            If Not IsNothing(q) And q.Count > 0 Then
    '                Return q.ToArray()
    '            Else
    '                Return Nothing
    '            End If
    '        Else
    '            Dim q = From ft In Odb.Mothers
    'Where (ft.Name.First = FirstName And ft.Name.Last = LastName And FatherName = ft.Name.Father)
    'Select ft.ID
    '            If Not IsNothing(q) And q.Count > 0 Then
    '                Return q.ToArray()
    '            Else
    '                Return Nothing
    '            End If
    '        End If
    '    Catch ex As Exception
    '        ExceptionsManager.RaiseOnDesktopNow(New MyException(ex.Message, True, True))
    '        Return Nothing
    '    End Try
    'End Function

    'Public Shared Function checkFatherByName(ByVal FirstName As String, ByVal LastName As String, ByVal UseLike As Boolean) As Integer()
    '    Try
    '        Dim Odb As New OrphanageDB.Odb()
    '        'خطأ باستخدام replace
    '        If UseLike Then
    '            Dim q = From ft In Odb.Fathers
    '            Where (ft.Name.First.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") Like "*" & FirstName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") & "*") And _
    '            (ft.Name.Last.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") Like "*" & LastName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") & "*") _
    '            Select ft.ID
    '            If Not IsNothing(q) And q.Count > 0 Then
    '                Return q.ToArray()
    '            Else
    '                Return Nothing
    '            End If
    '        Else
    '            Dim q = From ft In Odb.Fathers
    'Where (ft.Name.First = FirstName And ft.Name.Last = LastName)
    'Select ft.ID
    '            If Not IsNothing(q) And q.Count > 0 Then
    '                Return q.ToArray()
    '            Else
    '                Return Nothing
    '            End If

    '        End If
    '    Catch ex As Exception
    '        ExceptionsManager.RaiseOnDesktopNow(New MyException(ex.Message, True, True))
    '        Return Nothing
    '    End Try
    'End Function

    'Public Shared Function checkFatherByName(ByVal FirstName As String, ByVal LastName As String, ByVal FatherName As String, ByVal UseLike As Boolean) As Integer()
    '    Try
    '        Dim Odb As New OrphanageDB.Odb()
    '        'خطأ باستخدام replace
    '        If UseLike Then
    '            Dim q = From ft In Odb.Fathers
    '            Where (ft.Name.First.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") Like "*" & FirstName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") & "*") And _
    '            (ft.Name.Last.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") Like "*" & LastName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") & "*") And _
    '            (ft.Name.Father.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") Like "*" & FatherName.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا").Replace("ئ", "ى").Replace("ؤ", "و").Replace("ء", "") & "*")
    '                Select ft.ID
    '            If Not IsNothing(q) And q.Count > 0 Then
    '                Return q.ToArray()
    '            Else
    '                Return Nothing
    '            End If
    '        Else
    '            Dim q = From ft In Odb.Fathers
    'Where (ft.Name.First = FirstName And ft.Name.Last = LastName And FatherName = ft.Name.Father)
    'Select ft.ID
    '            If Not IsNothing(q) And q.Count > 0 Then
    '                Return q.ToArray()
    '            Else
    '                Return Nothing
    '            End If

    '        End If
    '    Catch ex As Exception
    '        ExceptionsManager.RaiseOnDesktopNow(New MyException(ex.Message, True, True))
    '        Return Nothing
    '    End Try
    'End Function

    Public Shared Function CheckFatherByID(ByVal _id As ULong) As Integer()
        Dim Odb As New OrphanageDB.Odb()
        Dim q
        q = From ft In Odb.Fathers
            Where Not IsNothing(ft.IdentityCard_ID) AndAlso (ft.IdentityCard_ID = _id)
                    Select ft.ID
        If Not IsNothing(q) And q.Count > 0 Then
            Return q.ToArray()
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function CheckMotherByID(ByVal _id As ULong) As Integer()
        Dim Odb As New OrphanageDB.Odb()
        Dim q
        q = From ft In Odb.Mothers
            Where Not IsNothing(ft.IdntityCard_ID) AndAlso (ft.IdntityCard_ID = _id)
                    Select ft.ID
        If Not IsNothing(q) And q.Count > 0 Then
            Return q.ToArray()
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function CheckBondsManByID(ByVal _id As ULong) As Integer()
        Dim Odb As New OrphanageDB.Odb()
        Dim q
        q = From ft In Odb.BondsMans
            Where Not IsNothing(ft.IdentityCard_ID) AndAlso (ft.IdentityCard_ID = _id)
                    Select ft.ID
        If Not IsNothing(q) And q.Count > 0 Then
            Return q.ToArray()
        Else
            Return Nothing
        End If
    End Function

    Public Function IsOrphanExist(ByVal orph As OrphanageClasses.Orphan) As OrphanageClasses.Orphan()
        Dim Odb As New OrphanageDB.Odb()
        'تعديل التايع
        Dim q = From orp In Odb.Orphans
                    Where ((orp.Name.Father.Remove2) Like (orph.Name.Father.Remove2)) AndAlso
                          ((orp.Name.First.Remove2) Like (orph.Name.First.Remove2)) AndAlso
                          ((orp.Name.Last.Remove2) Like (orph.Name.Last.Remove2)) AndAlso
                          ((orp.Family.Mother.Name.First.Remove2) Like (orph.Family.Mother.Name.First.Remove2)) AndAlso
                          ((orp.Family.Mother.Name.Last.Remove2) Like (orph.Family.Mother.Name.Last.Remove2)) AndAlso
                          ((orp.Family.Father.Name.Father.Remove2) Like (orph.Family.Father.Name.Father.Remove2))
                    Select orp
        If Not IsNothing(q) AndAlso q.Count > 0 Then
            Return q.ToArray()
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function checkExistingIdentity(ByVal _id As ULong) As ComplexReturn
        Try
            If _id = 0 Then Return Nothing
            Dim odb As New OrphanageDB.Odb()
            Dim q1 = From orph In odb.Orphans _
                    Where (orph.IdentityNumber = _id) _
                    Select orph
            Dim q2 = From fath In odb.Fathers _
                    Where (fath.IdentityCard_ID = _id) _
                    Select fath
            Dim q3 = From moth In odb.Mothers _
                    Where (moth.IdntityCard_ID = _id) _
                    Select moth
            Dim q4 = From bond In odb.BondsMans _
                    Where (bond.IdentityCard_ID = _id) _
                    Select bond
            Dim faths As OrphanageClasses.Father = Nothing
            Dim orphs As OrphanageClasses.Orphan = Nothing
            Dim moths As OrphanageClasses.Mother = Nothing
            Dim bonds As OrphanageClasses.BondsMan = Nothing
            If Not IsNothing(q1) AndAlso q1.Count > 0 Then
                orphs = q1.First()
            End If
            If Not IsNothing(q2) AndAlso q2.Count > 0 Then
                faths = q2.First()
            End If
            If Not IsNothing(q3) AndAlso q3.Count > 0 Then
                moths = q3.First()
            End If
            If Not IsNothing(q4) AndAlso q4.Count > 0 Then
                bonds = q4.First()
            End If
            If Not IsNothing(faths) Then Return New ComplexReturn(faths, ComplexReturn.ODBTypes.Father)
            If Not IsNothing(moths) Then Return New ComplexReturn(moths, ComplexReturn.ODBTypes.Mother)
            If Not IsNothing(orphs) Then Return New ComplexReturn(orphs, ComplexReturn.ODBTypes.Orphan)
            If Not IsNothing(bonds) Then Return New ComplexReturn(bonds, ComplexReturn.ODBTypes.BondMan)
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function checkExistingIdentity(ByVal _id As ULong, ByVal Exception_Names_Ids() As Integer) As ComplexReturn
        Try
            If _id = 0 Then Return Nothing
            Dim odb As New OrphanageDB.Odb()
            Dim q1 = From orph In odb.Orphans _
                    Where (orph.IdentityNumber = _id) _
                    Select orph
            Dim q2 = From fath In odb.Fathers _
                    Where (fath.IdentityCard_ID = _id) _
                    Select fath
            Dim q3 = From moth In odb.Mothers _
                    Where (moth.IdntityCard_ID = _id) _
                    Select moth
            Dim q4 = From bond In odb.BondsMans _
                    Where (bond.IdentityCard_ID = _id) _
                    Select bond
            Dim faths As OrphanageClasses.Father = Nothing
            Dim orphs As OrphanageClasses.Orphan = Nothing
            Dim moths As OrphanageClasses.Mother = Nothing
            Dim bonds As OrphanageClasses.BondsMan = Nothing
            If Not IsNothing(q1) AndAlso q1.Count > 0 Then
                For Each o In q1
                    If Not Exception_Names_Ids.Contains(o.Name_ID) Then
                        orphs = o
                        Exit For
                    End If
                Next
            End If
            If Not IsNothing(q2) AndAlso q2.Count > 0 Then
                For Each fa In q2
                    If Not Exception_Names_Ids.Contains(fa.Name_ID) Then
                        faths = fa
                        Exit For
                    End If
                Next
            End If
            If Not IsNothing(q3) AndAlso q3.Count > 0 Then
                For Each m In q3
                    If Not Exception_Names_Ids.Contains(m.Name_ID) Then
                        moths = m
                        Exit For
                    End If
                Next
            End If
            If Not IsNothing(q4) AndAlso q4.Count > 0 Then
                For Each bo In q4
                    If Not Exception_Names_Ids.Contains(bo.Name_ID) Then
                        bonds = bo
                        Exit For
                    End If
                Next
            End If
            If Not IsNothing(faths) Then
                Return New ComplexReturn(faths, ComplexReturn.ODBTypes.Father)
            End If
            If Not IsNothing(moths) Then
                Return New ComplexReturn(moths, ComplexReturn.ODBTypes.Mother)
            End If
            If Not IsNothing(orphs) Then
                Return New ComplexReturn(orphs, ComplexReturn.ODBTypes.Orphan)
            End If
            If Not IsNothing(bonds) Then
                Return New ComplexReturn(bonds, ComplexReturn.ODBTypes.BondMan)
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function checkExistingIdentity(ByVal _id As ULong, ByVal Except_Name_ID As Integer) As ComplexReturn
        Try
            If _id = 0 Then Return Nothing
            Dim odb As New OrphanageDB.Odb()
            Dim q1 = From orph In odb.Orphans _
                    Where (orph.IdentityNumber = _id) _
                    Select orph
            Dim q2 = From fath In odb.Fathers _
                    Where (fath.IdentityCard_ID = _id) _
                    Select fath
            Dim q3 = From moth In odb.Mothers _
                    Where (moth.IdntityCard_ID = _id) _
                    Select moth
            Dim q4 = From bond In odb.BondsMans _
                    Where (bond.IdentityCard_ID = _id) _
                    Select bond
            Dim faths As OrphanageClasses.Father = Nothing
            Dim orphs As OrphanageClasses.Orphan = Nothing
            Dim moths As OrphanageClasses.Mother = Nothing
            Dim bonds As OrphanageClasses.BondsMan = Nothing
            If Not IsNothing(q1) AndAlso q1.Count > 0 Then
                For Each o In q1
                    If orphs.Name_ID <> Except_Name_ID Then
                        orphs = o
                        Exit For
                    End If
                Next
            End If
            If Not IsNothing(q2) AndAlso q2.Count > 0 Then
                For Each fa In q2
                    If fa.Name_ID <> Except_Name_ID Then
                        faths = fa
                        Exit For
                    End If
                Next
            End If
            If Not IsNothing(q3) AndAlso q3.Count > 0 Then
                For Each m In q3
                    If m.Name_ID <> Except_Name_ID Then
                        moths = m
                        Exit For
                    End If
                Next
            End If
            If Not IsNothing(q4) AndAlso q4.Count > 0 Then
                For Each bo In q4
                    If bo.Name_ID <> Except_Name_ID Then
                        bonds = bo
                        Exit For
                    End If
                Next
            End If
            If Not IsNothing(faths) Then
                Return New ComplexReturn(faths, ComplexReturn.ODBTypes.Father)
            End If
            If Not IsNothing(moths) Then
                Return New ComplexReturn(moths, ComplexReturn.ODBTypes.Mother)
            End If
            If Not IsNothing(orphs) Then
                Return New ComplexReturn(orphs, ComplexReturn.ODBTypes.Orphan)
            End If
            If Not IsNothing(bonds) Then
                Return New ComplexReturn(bonds, ComplexReturn.ODBTypes.BondMan)
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Structure ComplexReturn
        Private _RetObject As Object
        Public Property RetObject As Object
            Get
                Return _RetObject
            End Get
            Set(ByVal value As Object)
                _RetObject = value
            End Set
        End Property
        Public Enum ODBTypes
            Father
            Mother
            Orphan
            BondMan
            Supporter
            Family
        End Enum
        Private _RetType As ODBTypes
        Public Property RetType As ODBTypes
            Get
                Return _RetType
            End Get
            Set(ByVal value As ODBTypes)
                _RetType = value
            End Set
        End Property
        Public Sub New(ByVal _obj As Object, ByVal typ As ODBTypes)
            _RetObject = _obj
            _RetType = typ
        End Sub
    End Structure
    Public Shared Function IsValidIdentityNumber(ByVal _id As ULong)
        If _id > 999999999 AndAlso _id < 100000000000 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function CheckOrphanBasicDataControls(ByVal OrphanFamily As OrphanageClasses.Family, ByRef dteBirthday As RadDateTimePicker, ByRef numIdentityNumber As RadSpinEditor, ByRef txtFirstName As RadTextBox, Optional ByVal Except_Ids() As Integer = Nothing) As Boolean
        Dim dte As New DateDiff(dteBirthday.Value, Date.Now)
        If dte.ElapsedYears < 0 Then
            ExceptionsManager.RaiseOnStatus(New MyException("يجب تحديد تاريخ سابق لايمكن تحديد تاريخ مستقبلي!", True, False))
            dteBirthday.Focus()
            Return False
        End If
        If dte.ElapsedYears > My.Settings.OrphanMaxAge Then
            ExceptionsManager.RaiseOnStatus(New MyException("عمر اليتيم اكبر من الحد الأعظمي المسموح به!", True, False))
            dteBirthday.Focus()
            Return False
        Else
            If dte.ElapsedYears > My.Settings.OrphanAllowedAge Then
                If MessageBox.Show("عمر اليتيم اكبر من الحد الأدنى المسموح به فهل تريد المتابعة؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    dteBirthday.Focus()
                    Return False
                End If
            End If
        End If
        dte = New DateDiff(OrphanFamily.Mother.Birthday, dteBirthday.Value)
        If dte.ElapsedYears > 55 OrElse dte.ElapsedYears < 12 Then
            If MessageBox.Show("قامت أمه بولادته وعمرها " & ATDFormater.ArabicDateFormater.GetArabicYear(dte.ElapsedYears) & Chr(13) & " فهل تريد المتابعة؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                dteBirthday.Focus()
                Return False
            End If
        End If
        dte = New DateDiff(OrphanFamily.Father.Dieday, dteBirthday.Value)
        If dte.Months >= 10 Then
            ExceptionsManager.RaiseOnStatus(New MyException("ولد بعد وفاة والده بـ " & ATDFormater.ArabicDateFormater.getFullArabicDate(dte.ElapsedYears, dte.ElapsedMonths, dte.ElapsedDays), True, False))
            dteBirthday.Focus()
            Return False
        End If
        If OrphanFamily.Mother.IsDead Then
            If Not IsNothing(OrphanFamily.Mother.Dieday) AndAlso OrphanFamily.Mother.Dieday < dteBirthday.Value Then
                ExceptionsManager.RaiseOnStatus(New MyException("ولدته أمه بعد وفاتها!!!!", True, False))
                dteBirthday.Focus()
                Return False
            End If
        End If
        If Not IsNothing(numIdentityNumber) Then
            If Checker.IsValidIdentityNumber(numIdentityNumber.Value) Then
                Dim Cr As Checker.ComplexReturn
                If IsNothing(Except_Ids) Then
                    Cr = Checker.checkExistingIdentity(numIdentityNumber.Value)
                Else
                    Cr = Checker.checkExistingIdentity(numIdentityNumber.Value, Except_Ids)
                End If
                If Not IsNothing(Cr.RetObject) Then
                    Dim retString As String = "رقم الهوية الذي ادخلته مطابق لـ "
                    Select Case Cr.RetType
                        Case Checker.ComplexReturn.ODBTypes.BondMan
                            retString += "المعيل " & Getter.GetFullName(CType(Cr.RetObject, OrphanageClasses.BondsMan).Name)
                        Case Checker.ComplexReturn.ODBTypes.Father
                            retString += "المتوفي " & Getter.GetFullName(CType(Cr.RetObject, OrphanageClasses.Father).Name)
                        Case Checker.ComplexReturn.ODBTypes.Mother
                            retString += "الأم " & Getter.GetFullName(CType(Cr.RetObject, OrphanageClasses.Mother).Name)
                        Case Checker.ComplexReturn.ODBTypes.Orphan
                            retString += "اليتيم " & Getter.GetFullName(CType(Cr.RetObject, OrphanageClasses.Orphan).Name)
                    End Select
                    ExceptionsManager.RaiseOnStatus(New MyException(retString, True, True))
                    numIdentityNumber.Focus()
                    Return False
                End If
            Else
                If numIdentityNumber.Value <> 0 Then
                    ExceptionsManager.RaiseOnStatus(New MyException("رقم الهوية خاطئ", True, True))
                    numIdentityNumber.Focus()
                    Return False
                End If
            End If
        End If
        If IsNothing(txtFirstName.Text) OrElse txtFirstName.Text.Count = 0 Then
            ExceptionsManager.RaiseOnStatus(New MyException("الرجاء ادخال الاسم الأول", True, True))
            txtFirstName.SelectAll()
            txtFirstName.Focus()
            Return False
        End If

        Return True
    End Function
    Public Shared Function CheckHealthDataControls(ByRef chkIsSick As RadCheckBox, ByRef txtDoctorName As RadTextBox, ByRef txtSicknessName As RadAutoCompleteBox) As Boolean
        If chkIsSick.Checked Then
            If Not IsNothing(txtDoctorName.Text) AndAlso txtDoctorName.Text <> "" AndAlso txtDoctorName.Text.Count < 7 Then
                ExceptionsManager.RaiseOnStatus(New MyException("اسم الطبيب قصير جداُ ,الرجاء إدخال الاسم كاملاً", True, False))
                txtDoctorName.SelectAll()
                txtDoctorName.Focus()
                Return False
            End If
            If txtSicknessName.Items.Count <= 0 Then
                ExceptionsManager.RaiseOnStatus(New MyException("يجب إدخال اسم المرض, يمكنك استخدام إشارة الجمع لإدخال امراض جديدة للبرنامج", True, False))
                txtSicknessName.SelectAll()
                txtSicknessName.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    Public Shared Function CheckStudyDataControls(ByRef chkIsStudy As RadCheckBox, ByRef txtStudyStage As RadTextBox) As Boolean
        If chkIsStudy.Checked Then
            If IsNothing(txtStudyStage.Text) OrElse txtStudyStage.Text.Length = 0 Then
                ExceptionsManager.RaiseOnStatus(New MyException("يجب إدخال المرحلة الدراسية لليتيم.", True, True))
                txtStudyStage.SelectAll()
                txtStudyStage.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    Public Shared Function CheckBondsBasicControls(ByRef txtFullNAme As RadTextBox, ByVal FirstN As String, ByVal LastN As String, ByRef numMonthlyIncom As RadSpinEditor, ByRef numIdentityNum As RadSpinEditor, Optional ByVal ExceptName_ID() As Integer = Nothing) As Boolean
        If IsNothing(txtFullNAme.Text) OrElse txtFullNAme.Text.Length < 2 Then
            ExceptionsManager.RaiseOnStatus(New MyException("يجب إدخال اسم المعيل", True, True))
            txtFullNAme.SelectAll()
            txtFullNAme.Focus()
            Return False
        End If
        If numMonthlyIncom.Value > 7000 Then
            ExceptionsManager.RaiseOnStatus(New MyException("يجب إدخال الدخل الشهري بالدولار!", True, False))
            numMonthlyIncom.Focus()
            Return False
        End If
        If Not IsNothing(numIdentityNum) Then
            If numIdentityNum.Value <> 0 AndAlso Checker.IsValidIdentityNumber(numIdentityNum.Value) Then
                If My.Settings.CheckIdentitysBeforAdd Then
                    Dim ret As Checker.ComplexReturn
                    If IsNothing(ExceptName_ID) Then
                        ret = Checker.checkExistingIdentity(numIdentityNum.Value)
                    Else
                        ret = Checker.checkExistingIdentity(numIdentityNum.Value, ExceptName_ID)
                    End If
                    If Not IsNothing(ret) AndAlso Not IsNothing(ret.RetObject) Then
                        numIdentityNum.Focus()
                        If ret.RetType = Checker.ComplexReturn.ODBTypes.BondMan Then
                            Dim obj As BondsMan = CType(ret.RetObject, OrphanageClasses.BondsMan)
                            ExceptionsManager.RaiseOnStatus(New MyException("رقم البطاقة الشخصية متطابق مع المعيل " & Getter.GetFullName(obj.Name), True, True))
                            Return False
                        ElseIf ret.RetType = Checker.ComplexReturn.ODBTypes.Father Then
                            Dim obj As Father = CType(ret.RetObject, OrphanageClasses.Father)
                            ExceptionsManager.RaiseOnStatus(New MyException("رقم البطاقة الشخصية متطابق مع المتوفى " & Getter.GetFullName(obj.Name), True, True))
                            Return False
                        ElseIf ret.RetType = Checker.ComplexReturn.ODBTypes.Mother Then
                            Dim obj As Mother = CType(ret.RetObject, OrphanageClasses.Mother)
                            ExceptionsManager.RaiseOnStatus(New MyException("رقم البطاقة الشخصية متطابق مع الأم " & Getter.GetFullName(obj.Name), True, True))
                            Return False
                        ElseIf ret.RetType = Checker.ComplexReturn.ODBTypes.Orphan Then
                            Dim obj As Orphan = CType(ret.RetObject, OrphanageClasses.Orphan)
                            ExceptionsManager.RaiseOnStatus(New MyException("رقم البطاقة الشخصية متطابق مع اليتيم " & Getter.GetFullName(obj.Name), True, True))
                            Return False
                        End If
                    End If
                End If
            Else
                If numIdentityNum.Value <> 0 Then
                    ExceptionsManager.RaiseOnStatus(New MyException("ادخل رقم البطاقة الشخصية بشكل صحيح", True))
                    numIdentityNum.Focus()
                    Return False
                End If
            End If
        End If
        'If IsNothing(ExceptName_ID) Then
        '    If My.Settings.checkSmilarNameBeforAdd Then
        '        Dim ret() As Integer = checkBondsManByName(FirstN, LastN, True)
        '        If Not IsNothing(ret) AndAlso ret.Length > 0 Then
        '            Dim fath As OrphanageClasses.BondsMan = Getter.GetBondsManByID(ret(0))
        '            Dim retD = MessageBox.Show("الاسم متشابه مع " & Getter.GetFullName(fath.Name) & Chr(13) & Chr(10) & "هل تريد المتابعة؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        '            If retD <> vbYes Then
        '                ExceptionsManager.RaiseOnStatus(New MyException("الاسم متشابه مع " & Getter.GetFullName(fath.Name), True, True))
        '                txtFullNAme.SelectAll()
        '                txtFullNAme.Focus()
        '                Return False
        '            End If
        '        End If
        '    End If
        'Else
        '    If My.Settings.CheckSmilaNameBeforEdit Then
        '        Dim ret() As Integer = checkBondsManByName(FirstN, LastN, True)
        '        If Not IsNothing(ret) AndAlso ret.Length > 0 Then
        '            Dim Sid As Integer = 0
        '            For Each rid In ret
        '                If Not ExceptName_ID.Contains(rid) Then
        '                    Sid = rid
        '                    Exit For
        '                End If
        '            Next
        '            If Sid > 0 Then
        '                Dim fath As OrphanageClasses.BondsMan = Getter.GetBondsManByID(Sid)
        '                Dim retD = MessageBox.Show("الاسم متشابه مع " & Getter.GetFullName(fath.Name) & Chr(13) & Chr(10) & "هل تريد المتابعة؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        '                If retD <> vbYes Then
        '                    ExceptionsManager.RaiseOnStatus(New MyException("الاسم متشابه مع " & Getter.GetFullName(fath.Name), True, True))
        '                    txtFullNAme.SelectAll()
        '                    txtFullNAme.Focus()
        '                    Return False
        '                End If
        '            End If
        '        End If
        '    End If
        'End If
        Return True
    End Function
    Public Shared Function checkMotherControls(ByRef dteBirthday As RadDateTimePicker, ByVal chkIsDead As RadCheckBox, ByRef dteDieDay As RadDateTimePicker, ByRef numIdentity As RadSpinEditor, ByRef txtNameF As RadTextBox, ByRef txtNameL As RadTextBox, Optional ByVal ExceptName_ID() As Integer = Nothing) As Boolean
        Dim timdeff As New DateDiff(dteBirthday.Value, Date.Now)
        If Not chkIsDead.Checked Then
            timdeff = New DateDiff(dteDieDay.Value, Date.Now)
            If timdeff.ElapsedYears > 18 Then
                ExceptionsManager.RaiseOnStatus(New MyException("متوفية منذ أكثر من " & ATDFormater.ArabicDateFormater.GetArabicYear(timdeff.ElapsedYears), True))
                dteDieDay.Focus()
                Return False
            End If
            timdeff = New DateDiff(dteBirthday.Value, dteDieDay.Value)
            If timdeff.ElapsedYears < 13 Then
                ExceptionsManager.RaiseOnStatus(New MyException("توفيت وعمرها " & ATDFormater.ArabicDateFormater.GetArabicYear(timdeff.ElapsedYears), True))
                dteDieDay.Focus()
                Return False
            End If
        Else
            If timdeff.ElapsedYears < 13 OrElse timdeff.ElapsedYears > 70 Then
                ExceptionsManager.RaiseOnStatus(New MyException("عمر الأم " & ATDFormater.ArabicDateFormater.GetArabicYear(timdeff.ElapsedYears), True))
                dteBirthday.Focus()
                Return False
            End If
        End If
        If Not IsNothing(numIdentity) Then
            If Not IsNothing(numIdentity.Value) AndAlso IsValidIdentityNumber(numIdentity.Value) Then
                If My.Settings.CheckIdentitysBeforAdd Then
                    Dim ret As Checker.ComplexReturn
                    If IsNothing(ExceptName_ID) Then
                        ret = Checker.checkExistingIdentity(numIdentity.Value)
                    Else
                        ret = Checker.checkExistingIdentity(numIdentity.Value, ExceptName_ID)
                    End If
                    If Not IsNothing(ret) AndAlso Not IsNothing(ret.RetObject) Then
                        Select Case ret.RetType
                            Case Checker.ComplexReturn.ODBTypes.BondMan
                                ExceptionsManager.RaiseOnStatus(New MyException("رقم الهوية متطابق مع المعيل " & Getter.GetFullName(CType(ret.RetObject, OrphanageClasses.BondsMan).Name), True, True))
                            Case Checker.ComplexReturn.ODBTypes.Mother
                                ExceptionsManager.RaiseOnStatus(New MyException("رقم الهوية متطابق مع الأم " & Getter.GetFullName(CType(ret.RetObject, OrphanageClasses.Mother).Name), True, True))
                            Case Checker.ComplexReturn.ODBTypes.Father
                                ExceptionsManager.RaiseOnStatus(New MyException("رقم الهوية متطابق مع المتوفى " & Getter.GetFullName(CType(ret.RetObject, OrphanageClasses.Father).Name), True, True))
                            Case Checker.ComplexReturn.ODBTypes.Orphan
                                ExceptionsManager.RaiseOnStatus(New MyException("رقم الهوية متطابق مع اليتيم " & Getter.GetFullName(CType(ret.RetObject, OrphanageClasses.Orphan).Name), True, True))
                        End Select
                        numIdentity.Focus()
                        Return False
                    End If
                End If
            Else
                If numIdentity.Value > 0 Then
                    ExceptionsManager.RaiseOnStatus(New MyException("رقم هوية خاطئ", True, True))
                    numIdentity.Focus()
                    Return False
                End If
            End If
        End If
        If txtNameF.Text.Length <= 1 Then
            ExceptionsManager.RaiseOnStatus(New MyException("يجب إدخال اسم الأم الأول ", True, True))
            txtNameF.SelectAll()
            txtNameF.Focus()
            Return False
        End If
        If txtNameL.Text.Length <= 1 Then
            ExceptionsManager.RaiseOnStatus(New MyException("يجب إدخال نسبة الأم ", True, True))
            txtNameL.SelectAll()
            txtNameL.Focus()
            Return False
        End If

        Return True
    End Function
    Public Shared Function checkFatherControls(ByRef dteBirthday As RadDateTimePicker, ByRef dteDieday As RadDateTimePicker, ByRef numIdentity As RadSpinEditor, ByRef txtFirstNAme As RadTextBox, ByRef txtLastName As RadTextBox, Optional ByVal ExceptName_ID() As Integer = Nothing) As Boolean
        Dim timdeff As New DateDiff(dteBirthday.Value, Date.Now)
        If timdeff.ElapsedYears < 13 Then
            ExceptionsManager.RaiseOnStatus(New MyException("عمر المتوفي " & ATDFormater.ArabicDateFormater.GetArabicYear(timdeff.ElapsedYears), True))
            dteBirthday.Focus()
            Return False
        End If
        timdeff = New DateDiff(dteDieday.Value, Date.Now)
        If timdeff.ElapsedYears > 18 Then
            ExceptionsManager.RaiseOnStatus(New MyException("متوفي منذ أكثر من " & ATDFormater.ArabicDateFormater.GetArabicYear(timdeff.ElapsedYears), True))
            dteDieday.Focus()
            Return False
        End If
        timdeff = New DateDiff(dteBirthday.Value, dteDieday.Value)
        If timdeff.ElapsedYears < 13 Then
            ExceptionsManager.RaiseOnStatus(New MyException("توفي وعمره " & ATDFormater.ArabicDateFormater.GetArabicYear(timdeff.ElapsedYears), True))
            dteDieday.Focus()
            Return False
        End If
        If Not IsNothing(numIdentity) Then
            If Not IsNothing(numIdentity.Value) AndAlso IsValidIdentityNumber(numIdentity.Value) Then
                Dim ret As Checker.ComplexReturn
                If IsNothing(ExceptName_ID) Then
                    ret = Checker.checkExistingIdentity(numIdentity.Value)
                Else
                    ret = Checker.checkExistingIdentity(numIdentity.Value, ExceptName_ID)
                End If
                If Not IsNothing(ret) AndAlso Not IsNothing(ret.RetObject) Then
                    Select Case ret.RetType
                        Case Checker.ComplexReturn.ODBTypes.BondMan
                            ExceptionsManager.RaiseOnStatus(New MyException("رقم الهوية متطابق مع المعيل " & Getter.GetFullName(CType(ret.RetObject, OrphanageClasses.BondsMan).Name), True, True))
                        Case Checker.ComplexReturn.ODBTypes.Mother
                            ExceptionsManager.RaiseOnStatus(New MyException("رقم الهوية متطابق مع الأم " & Getter.GetFullName(CType(ret.RetObject, OrphanageClasses.Mother).Name), True, True))
                        Case Checker.ComplexReturn.ODBTypes.Father
                            ExceptionsManager.RaiseOnStatus(New MyException("رقم الهوية متطابق مع المتوفى " & Getter.GetFullName(CType(ret.RetObject, OrphanageClasses.Father).Name), True, True))
                        Case Checker.ComplexReturn.ODBTypes.Orphan
                            ExceptionsManager.RaiseOnStatus(New MyException("رقم الهوية متطابق مع اليتيم " & Getter.GetFullName(CType(ret.RetObject, OrphanageClasses.Orphan).Name), True, True))
                    End Select
                    numIdentity.Focus()
                    Return False
                End If
            Else
                If numIdentity.Value > 0 Then
                    ExceptionsManager.RaiseOnStatus(New MyException("رقم هوية خاطئ", True, True))
                    numIdentity.Focus()
                    Return False
                End If
            End If
        End If
        If txtFirstNAme.Text.Length <= 1 Then
            ExceptionsManager.RaiseOnStatus(New MyException("يجب إدخال اسم الأب الأول ", True, True))
            txtFirstNAme.SelectAll()
            txtFirstNAme.Focus()
            Return False
        End If
        If txtLastName.Text.Length <= 1 Then
            ExceptionsManager.RaiseOnStatus(New MyException("يجب إدخال نسبة الأب ", True, True))
            txtLastName.SelectAll()
            txtLastName.Focus()
            Return False
        End If
        Return True
    End Function
    Public Shared Function checkFatherControls(ByRef dteBirthday As RadDateTimePicker, ByRef dteDieday As RadDateTimePicker, ByRef numIdentity As RadSpinEditor, ByRef txtFirstNAme As String, ByRef txtLastName As String, Optional ByVal ExceptName_ID() As Integer = Nothing) As Boolean
        Dim txtF, txtL As New RadTextBox()
        txtF.Text = txtFirstNAme
        txtL.Text = txtLastName
        If IsNothing(ExceptName_ID) Then
            Return checkFatherControls(dteBirthday, dteDieday, numIdentity, txtF, txtL)
        Else
            Return checkFatherControls(dteBirthday, dteDieday, numIdentity, txtF, txtL, ExceptName_ID)
        End If
    End Function
    Public Shared Function checkMotherControls(ByRef dteBirthday As RadDateTimePicker, ByVal chkIsDead As RadCheckBox, ByRef dteDieDay As RadDateTimePicker, ByRef numIdentity As RadSpinEditor, ByRef txtFirstNAme As String, ByRef txtLastName As String, Optional ByVal ExceptName_ID() As Integer = Nothing) As Boolean
        Dim txtF, txtL As New RadTextBox()
        txtF.Text = txtFirstNAme
        txtL.Text = txtLastName
        If IsNothing(ExceptName_ID) Then
            Return checkMotherControls(dteBirthday, chkIsDead, dteDieDay, numIdentity, txtF, txtL)
        Else
            Return checkMotherControls(dteBirthday, chkIsDead, dteDieDay, numIdentity, txtF, txtL, ExceptName_ID)
        End If
    End Function
    Public Shared Function CheckBailControls(ByRef dteFrom As RadDateTimePicker, ByRef dteTo As RadDateTimePicker) As Boolean
        If dteFrom.Value.Date < Date.Now.Date Then
            ExceptionsManager.RaiseOnStatus(New MyException("لا يجب أن تبدأ الكفالة بتاريخ قديم!", True, False))
            dteFrom.Focus()
            Return False
        End If
        If dteFrom.Value.Date > dteTo.Value.Date Then
            ExceptionsManager.RaiseOnStatus(New MyException("لا يجب أن يكون تاريخ البدء بعد تاريخ الإنتهاء!", True, False))
            dteFrom.Focus()
            Return False
        End If
        Return True
    End Function

    Public Shared Function isExistBillNumber(ByVal Number As Decimal) As Boolean
        Try
            Dim Odb As New OrphanageDB.Odb()
            'خطأ باستخدام replace
            Dim q = From ft In Odb.Bills
                Where ft.Bill_Number = Number
                Select ft.ID
            If Not IsNothing(q) And q.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ExceptionsManager.RaiseOnStatus(New MyException(ex.Message, True, True))
            Return True
        End Try
    End Function
End Class

Public Class ProgressSate
    Public Delegate Sub delShowProgress(ByVal Pro As Integer, ByVal status As String)
    Public Shared Event ShowProgress As delShowProgress
    Public Shared Sub ShowStatueProgress(ByVal Pro As Integer, ByVal status As String)
        RaiseEvent ShowProgress(Pro, status)
    End Sub

End Class