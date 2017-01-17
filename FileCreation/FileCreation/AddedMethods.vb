Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.IO

Module AddedMethods
    <Extension()>
    Public Function ToBytesArray1(ByVal img As Image) As Byte()
        If IsNothing(img) Then
            Return Nothing
        End If
        Dim ret() As Byte = Nothing
        Try
            Dim mem As New MemoryStream()
            img.Save(mem, Imaging.ImageFormat.Jpeg)
            ret = mem.ToArray()
            mem.Close()
            mem.Dispose()
        Catch
            Return Nothing
        End Try
        Return ret
    End Function
    <Extension()>
    Public Function To64bitStr(ByVal img As Image) As String
        If IsNothing(img) Then
            Return ""
        End If
        Dim ret As String = Nothing
        Try
            Dim bimp As New Bitmap(img)
            Dim Tempfile As String = My.Computer.FileSystem.GetTempFileName()
            bimp.Save(Tempfile, Imaging.ImageFormat.Jpeg)
            Dim mem() As Byte = My.Computer.FileSystem.ReadAllBytes(Tempfile)
            ret = System.Convert.ToBase64String(mem, Base64FormattingOptions.None)
            Try
                My.Computer.FileSystem.DeleteFile(Tempfile)
            Catch

            End Try
        Catch
            Return ""
        End Try
        Return ret
    End Function
End Module
