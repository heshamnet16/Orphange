Imports System.IO
Public Class BinaryFile
    Private _UseCrypto As Boolean
    Public Property UseCrypto As Boolean
        Get
            Return _UseCrypto
        End Get
        Set(ByVal value As Boolean)
            _UseCrypto = value
        End Set
    End Property
    Private _FileName As String
    Public Property FileName As String
        Get
            Return _FileName
        End Get
        Set(ByVal value As String)
            _FileName = value
        End Set
    End Property
    Private _Overwite As Boolean
    Public Property Overwite() As Boolean
        Get
            Return _Overwite
        End Get
        Set(ByVal value As Boolean)
            _Overwite = value
        End Set
    End Property
    Public Function Create(ByVal bytes() As Byte)
        Dim ret As Boolean = False
        Dim Bw As BinaryWriter = Nothing
        Try
            If Not _Overwite Then
                If File.Exists(_FileName) Then
                    Return False
                End If
            Else
                If File.Exists(_FileName) Then
                    File.Delete(_FileName)
                End If
            End If
            If _UseCrypto Then
                Dim crp As New Crypto()
                bytes = crp.EncryptBytes(bytes)
            End If
            Bw = New BinaryWriter(New FileStream(_FileName, FileMode.CreateNew))
            Bw.Write(bytes)
            Bw.Flush()
            ret = True
        Catch
            ret = False
        Finally
            If Not IsNothing(Bw) Then
                Bw.Close()
                Bw.Dispose()
            End If
        End Try
        Return ret
    End Function
    Public Function Create(ByVal str As String)
        Dim ret As Boolean = False
        Dim Bw As BinaryWriter = Nothing
        Try
            If Not _Overwite Then
                If File.Exists(_FileName) Then
                    Return False
                End If
            Else
                If File.Exists(_FileName) Then
                    File.Delete(_FileName)
                End If
            End If
            If _UseCrypto Then
                Dim crp As New Crypto()
                str = crp.EncryptString(str)
            End If
            Bw = New BinaryWriter(New FileStream(_FileName, FileMode.CreateNew))
            Bw.Write(str)
            Bw.Flush()
            ret = True
        Catch
            ret = False
        Finally
            If Not IsNothing(Bw) Then
                Bw.Close()
                Bw.Dispose()
            End If
        End Try
        Return ret
    End Function
    Public Function ReadAllText() As String
        Dim ret As String
        Try
            ret = File.ReadAllText(_FileName)
            If _UseCrypto Then
                Dim crp As New Crypto()
                ret = crp.DecryptString(ret)
            End If
        Catch
            ret = Nothing
        End Try
        Return ret
    End Function
    Public Function ReadAllBytes() As Byte()
        Dim ret() As Byte
        Try
            ret = File.ReadAllBytes(_FileName)
            If _UseCrypto Then
                Dim crp As New Crypto()
                ret = crp.DecryptBytes(ret)
            End If
        Catch
            ret = Nothing
        End Try
        Return ret
    End Function
    Public Shared Function ReadAllBytes(ByVal _FileName As Stream, ByVal UseEncryption As Boolean) As Byte()
        Dim ret() As Byte
        Try

            ret = New BinaryReader(_FileName).ReadBytes(_FileName.Length)
            If UseEncryption Then
                Dim crp As New Crypto()
                ret = crp.DecryptBytes(ret)
            End If
        Catch
            ret = Nothing
        End Try
        Return ret
    End Function
End Class
