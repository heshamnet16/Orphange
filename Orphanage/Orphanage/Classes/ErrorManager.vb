Imports System.Collections
Public Class ExceptionsManager
    Private Shared Exceptions As New ArrayList()
    Public Delegate Sub MyexcEventHandler(ByVal myExc As MyException)
    'Public Delegate Sub myAllExcption(ByVal myAllexc() As MyException)
    Public Shared Event OnAdd As MyexcEventHandler
    Public Shared Event OdDelete As MyexcEventHandler
    Public Shared Event Immidiate As MyexcEventHandler
    Public Shared Event showOnDesktop As MyexcEventHandler
    Public Shared Event showOnStatus As MyexcEventHandler
    Private Shared dontRaise As Boolean = False
    Public Shared Sub addException(ByVal exc As MyException)
        Exceptions.Add(exc)
        RaiseEvent OnAdd(exc)
    End Sub
    Public Shared Sub RaiseOnStatus(ByVal exc As MyException)
        dontRaise = True
        'removeException(exc)
        RaiseEvent showOnStatus(exc)
    End Sub
    Public Shared Sub RaiseOnDesktopNow(ByVal exc As MyException)
        dontRaise = True
        'removeException(exc)
        RaiseEvent showOnDesktop(exc)
    End Sub
    Public Shared Sub removeException(ByVal exc As MyException)
        Exceptions.Remove(exc)
        For i = 0 To Exceptions.Count - 1
            Dim Mexc As MyException = CType(Exceptions.Item(i), MyException)
            If Mexc.ID = exc.ID Then
                Exceptions.RemoveAt(i)
            End If
        Next
        If dontRaise = False Then
            RaiseEvent OdDelete(exc)
            dontRaise = True
        End If
    End Sub
    Public Shared Sub RaiseThis(ByVal exc As MyException)
        dontRaise = True
        'removeException(exc)
        RaiseEvent Immidiate(exc)
    End Sub
    Public Shared Sub RaiseAccessDeniedException()
        Dim exc As New MyException("عذراً انت لاتملك الصلاحية!", True, True)
        RaiseOnStatus(exc)
    End Sub
    Public Shared Sub RaiseSaved()
        Dim exc As New MyException("تم الحفظ", False, True)
        RaiseOnStatus(exc)
    End Sub
    Public Shared Sub RaiseNotSaved()
        Dim exc As New MyException("لم يتم حفظ شيئ", False, True)
        RaiseOnStatus(exc)
    End Sub
    Public Shared Sub RaiseDeleted(ByVal txt As String)
        Dim exc As New MyException("تم حذف " & txt, False, True)
        RaiseOnStatus(exc)
    End Sub
End Class

Public Class MyException
    Private _Message As String
    Private _isError As Boolean
    Private _isImportantMessage As Boolean
    Private _SenderControl As Object
    Private _randNum As Integer = 0

    Public ReadOnly Property ID As Integer
        Get
            Return _randNum
        End Get
    End Property
    Public Property SenderControll As Object
        Get
            Return _SenderControl
        End Get
        Set(ByVal value As Object)
            _SenderControl = value
        End Set
    End Property
    Public Property Message As String
        Get
            Return _Message
        End Get
        Set(ByVal value As String)
            _Message = value
        End Set
    End Property

    Public Property IsError As Boolean
        Get
            Return _isError
        End Get
        Set(ByVal value As Boolean)
            _isError = value
        End Set
    End Property

    Public Property isImportantMessage As Boolean
        Get
            Return _isImportantMessage
        End Get
        Set(ByVal value As Boolean)
            _isImportantMessage = value
        End Set
    End Property
    Public Sub New(ByVal _SendeCont As Object, ByVal _msg As String)
        Me._isError = False
        Me._isImportantMessage = False
        Me._Message = _msg
        Me._SenderControl = _SendeCont
        Dim rnd As New Random(50000)
        Randomize()
        Me._randNum = rnd.Next(10000, 99999)
        ExceptionsManager.addException(Me)
    End Sub
    Public Sub New(ByVal _SendeCont As Object, ByVal _msg As String, ByVal isErr As Boolean)
        Me._isError = isErr
        Me._isImportantMessage = False
        Me._Message = _msg
        Me._SenderControl = _SendeCont
        Dim rnd As New Random(50000)
        Randomize()
        Me._randNum = rnd.Next(10000, 99999)
        ExceptionsManager.addException(Me)
    End Sub
    Public Sub New(ByVal _SendeCont As Object, ByVal _msg As String, ByVal isErr As Boolean, ByVal IsImportant As Boolean)
        Me._isError = isErr
        Me._isImportantMessage = IsImportant
        Me._Message = _msg
        Me._SenderControl = _SendeCont
        Dim rnd As New Random(50000)
        Randomize()
        Me._randNum = rnd.Next(10000, 99999)
        ExceptionsManager.addException(Me)
    End Sub
    'dsds
    Public Sub New(ByVal _msg As String)
        Me._isError = False
        Me._isImportantMessage = False
        Me._Message = _msg
        Dim rnd As New Random(50000)
        Randomize()
        Me._randNum = rnd.Next(10000, 99999)
        ExceptionsManager.addException(Me)
    End Sub
    Public Sub New(ByVal _msg As String, ByVal isErr As Boolean)
        Me._isError = isErr
        Me._isImportantMessage = False
        Me._Message = _msg
        Dim rnd As New Random(50000)
        Randomize()
        Me._randNum = rnd.Next(10000, 99999)
        ExceptionsManager.addException(Me)
    End Sub
    Public Sub New(ByVal _msg As String, ByVal isErr As Boolean, ByVal IsImportant As Boolean)
        Me._isError = isErr
        Me._isImportantMessage = IsImportant
        Me._Message = _msg
        Dim rnd As New Random(50000)
        Randomize()
        Me._randNum = rnd.Next(10000, 99999)
        ExceptionsManager.addException(Me)
    End Sub
End Class
