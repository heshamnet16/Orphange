Imports <xmlns="XML.Orphans">
Public Class OrphanBasket

    Private _Orphans As Dictionary(Of Integer, String)
    Public Property Orphans As Dictionary(Of Integer, String)
        Get
            Return _Orphans
        End Get
        Set(ByVal value As Dictionary(Of Integer, String))
            _Orphans = value
        End Set
    End Property

    Private xmlFile As String
    Private _FirstTime As Boolean = False
    Public Sub New(ByVal FileName As String)
        xmlFile = FileName
        If Not IO.File.Exists(FileName) Then
            Dim x = <Orphans>
                        <Orphan>
                            <ID></ID>
                            <Note></Note>
                        </Orphan>
                    </Orphans>
            Dim xmlW As Xml.XmlWriter = Xml.XmlWriter.Create(FileName)
            xmlW.WriteStartDocument(True)
            x.WriteTo(xmlW)
            xmlW.WriteEndDocument()
            xmlW.Flush()
            xmlW.Close()
            _FirstTime = True
            _Orphans = New Dictionary(Of Integer, String)
        Else
            _Orphans = New Dictionary(Of Integer, String)
            Dim xDoc As XDocument = XDocument.Load(FileName)
            For Each nn In xDoc.<Orphans>.<Orphan>
                If Not IsNothing(nn.<ID>.Value) AndAlso nn.<ID>.Value.Length > 0 Then
                    Dim id As Integer = CInt(nn.<ID>.Value)
                    Dim note As String = nn.<Note>.Value
                    _Orphans.Add(id, note)
                End If
            Next
        End If
    End Sub


    Public Sub Remove(ByVal _id As Integer)
        Dim xDoc As XDocument = XDocument.Load(xmlFile)
        If _Orphans.Keys.Contains(_id) Then
            Dim q = From n In xDoc.<Orphans>.<Orphan> Where n.<ID>.Value = _id Select n
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                For Each cc In q
                    cc.Remove()
                Next
                _Orphans.Remove(_id)
            End If
        Else
            Dim q = From n In xDoc.<Orphans>.<Orphan> Where n.<ID>.Value = _id Select n
            If Not IsNothing(q) AndAlso q.Count > 0 Then
                For Each cc In q
                    cc.Remove()
                Next
            End If
        End If
        xDoc.Save(xmlFile)
    End Sub

    Public Sub Save()
        Dim xDoc As XDocument = XDocument.Load(xmlFile)
        For Each i As Integer In _Orphans.Keys
            Dim note As String = _Orphans(i)
            Dim id As Integer = i
            Dim q = From n In xDoc.<Orphans>.<Orphan> Where n.<ID>.Value = id Select n
            If Not IsNothing(q) AndAlso q.Count > 0 Then                
                For Each cc In q
                    cc.<Note>.Value = note
                Next
            Else
                Dim x = <Orphan>
                            <ID><%= id %></ID>
                            <Note><%= note %></Note>
                        </Orphan>
                xDoc.<Orphans>.FirstOrDefault().Add(x)
            End If
        Next
        xDoc.Save(xmlFile)
    End Sub
End Class
