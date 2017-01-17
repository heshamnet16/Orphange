Imports System.Security.Cryptography
Imports System.IO

Public Class LogWriter
    Private FileName As String = "c:\OrphansLOG.log"
    Private Key As String = "OrphansRegistriesByHeshamnet16"
    Private TripleDes As New TripleDESCryptoServiceProvider
    Public Sub New()
        TripleDes.Key = TruncateHash(Key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub
    Public Sub AddLine(ByVal line As String)
        Dim Sw As New StreamWriter(FileName, True)
        Sw.WriteLine(EncryptData(line))
        Sw.Flush()
        Sw.Close()
        Sw.Dispose()
    End Sub
    Private Function TruncateHash(
    ByVal key As String,
    ByVal length As Integer) As Byte()

        Dim sha1 As New SHA1CryptoServiceProvider

        ' Hash the key. 
        Dim keyBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ' Truncate or pad the hash. 
        ReDim Preserve hash(length - 1)
        Return hash
    End Function
    Public Sub ClearALL()
        Try
            If File.Exists(FileName) Then
                File.Delete(FileName)
            End If
        Catch
        End Try
    End Sub
    Public Sub Translate(ByVal destFileName As String)
        If File.Exists(FileName) Then
            Dim Sr As New StreamReader(FileName)
            Dim Sw As New StreamWriter(destFileName)
            While Not Sr.EndOfStream
                Sw.WriteLine(DecryptData(Sr.ReadLine()))
            End While
            Sw.Flush()
            Sr.Close()
            Sw.Close()
            Sr.Dispose()
            Sw.Dispose()
        End If
    End Sub
    Public Function DecryptData(
    ByVal encryptedtext As String) As String

        ' Convert the encrypted text string to a byte array. 
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        ' Create the stream. 
        Dim ms As New System.IO.MemoryStream
        ' Create the decoder to write to the stream. 
        Dim decStream As New CryptoStream(ms,
            TripleDes.CreateDecryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()
        Dim ar() As Byte = ms.ToArray
        decStream.Close()
        ms.Close()
        ms.Dispose()
        decStream.Dispose()
        ' Convert the plaintext stream to a string. 
        Return System.Text.Encoding.Unicode.GetString(ar)
    End Function
    Private Function EncryptData(
        ByVal plaintext As String) As String

        ' Convert the plaintext string to a byte array. 
        Dim plaintextBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(plaintext)

        ' Create the stream. 
        Dim ms As New System.IO.MemoryStream
        ' Create the encoder to write to the stream. 
        Dim encStream As New CryptoStream(ms,
            TripleDes.CreateEncryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()
        Dim ar() As Byte = ms.ToArray
        ms.Close()
        ms.Dispose()
        encStream.Close()
        encStream.Dispose()
        ' Convert the encrypted stream to a printable string. 
        Return Convert.ToBase64String(ar)
    End Function
End Class
