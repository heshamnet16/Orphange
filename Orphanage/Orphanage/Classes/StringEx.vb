' Declarations will typically be in a separate module.
Imports System.Runtime.CompilerServices

Module StringExtensions
    <Extension()>
    Public Function Remove2(ByVal Str As String) As String
        Dim ret As String = Str
        If ret.Contains("أ") Then
            ret = ret.Replace("أ", "ا")
        End If
        If ret.Contains("إ") Then
            ret = ret.Replace("إ", "ا")
        End If
        If ret.Contains("آ") Then
            ret = ret.Replace("آ", "ا")
        End If
        If ret.Contains("ئ") Then
            ret = ret.Replace("ئ", "ا")
        End If
        If ret.Contains("ء") Then
            ret = ret.Replace("ء", "ا")
        End If
        If ret.Contains("ؤ") Then
            ret = ret.Replace("ؤ", "ا")
        End If
        Return ret
    End Function
    <Extension()>
    Public Function ToImage(ByVal bytes() As Byte) As Image
        If IsNothing(bytes) Then Return Nothing
        Try
            Dim mem As New System.IO.MemoryStream(bytes)
            Dim img As Image = Image.FromStream(mem)
            mem.Close()
            mem.Dispose()
            Return img
        Catch
            Return Nothing
        End Try
    End Function
    <Extension()>
    Public Function ToByte(ByVal img As Image) As Byte()
        If IsNothing(img) Then Return Nothing
        Try
            Dim mem As New System.IO.MemoryStream()
            Dim img1 As Bitmap = New Bitmap(img)
            img1.Save(mem, Imaging.ImageFormat.Jpeg)
            img1.Dispose()
            Return mem.ToArray()
        Catch
            Return Nothing
        End Try
    End Function
End Module