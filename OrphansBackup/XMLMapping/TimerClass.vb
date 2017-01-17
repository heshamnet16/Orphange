Imports <xmlns="Timing.schedule">
Public Class TimerClass

    Private _isON As Boolean
    Public Property IsON As Boolean
        Get
            Return _isON
        End Get
        Set(ByVal value As Boolean)
            _isON = value
        End Set
    End Property
    Private _NextDate As Date
    Public Property NextDate As Date
        Get
            Return _NextDate
        End Get
        Set(ByVal value As Date)
            _NextDate = value
        End Set
    End Property
    Private _isWeekly As Boolean
    Public Property isWeekly As Boolean
        Get
            Return _isWeekly
        End Get
        Set(ByVal value As Boolean)
            _isWeekly = value
        End Set
    End Property
    Private _isMonthly As Boolean
    Public Property IsMonthly As Boolean
        Get
            Return _isMonthly
        End Get
        Set(ByVal value As Boolean)
            _isMonthly = value
        End Set
    End Property
    Private _isDaily As Boolean
    Public Property isDaily As Boolean
        Get
            Return _isDaily
        End Get
        Set(ByVal value As Boolean)
            _isDaily = value
        End Set
    End Property
    Private _OnSatarday As Boolean
    Public Property OnSatarday As Boolean
        Get
            Return _OnSatarday
        End Get
        Set(ByVal value As Boolean)
            _OnSatarday = value
        End Set
    End Property
    Private _OnSunday As Boolean
    Public Property OnSunday As Boolean
        Get
            Return _OnSunday
        End Get
        Set(ByVal value As Boolean)
            _OnSunday = value
        End Set
    End Property
    Private _OnMonday As Boolean
    Public Property OnMonday As Boolean
        Get
            Return _OnMonday
        End Get
        Set(ByVal value As Boolean)
            _OnMonday = value
        End Set
    End Property
    Private _OnTuesday As Boolean
    Public Property OnTuesday As Boolean
        Get
            Return _OnTuesday
        End Get
        Set(ByVal value As Boolean)
            _OnTuesday = value
        End Set
    End Property
    Private _OnWensday As Boolean
    Public Property OnWendsday As Boolean
        Get
            Return _OnWensday
        End Get
        Set(ByVal value As Boolean)
            _OnWensday = value
        End Set
    End Property
    Private _OnThrusday As Boolean
    Public Property OnThrusday As Boolean
        Get
            Return _OnThrusday
        End Get
        Set(ByVal value As Boolean)
            _OnThrusday = value
        End Set
    End Property
    Private _OnFriday As Boolean
    Public Property OnFriday As Boolean
        Get
            Return _OnFriday
        End Get
        Set(ByVal value As Boolean)
            _OnFriday = value
        End Set
    End Property
    Private _MaxCopies As Byte
    Public Property MaxDatabaseCopies As Byte
        Get
            Return _MaxCopies
        End Get
        Set(ByVal value As Byte)
            _MaxCopies = value
        End Set
    End Property
    Private _ReplaceOldones As Boolean
    Public Property ReplaceOldDB As Boolean
        Get
            Return _ReplaceOldones
        End Get
        Set(ByVal value As Boolean)
            _ReplaceOldones = value
        End Set
    End Property
    Private _FolderName As String
    Public Property FolderName As String
        Get
            Return _FolderName
        End Get
        Set(ByVal value As String)
            _FolderName = value
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
    Private _MakeNewFolder As Boolean
    Public Property MakeNewFolder As Boolean
        Get
            Return _MakeNewFolder
        End Get
        Set(ByVal value As Boolean)
            _MakeNewFolder = value
        End Set
    End Property

    Private xmlFileN As String
    Public Sub New(ByVal xmlFileName As String)
        Me.xmlFileN = xmlFileName
        If Not System.IO.File.Exists(xmlFileName) Then
            Dim x = <Schedule>
                        <IsON><%= False %></IsON>
                        <NextDate><%= Date.Now.ToString("yyyy/MM/dd-HH:mm") %></NextDate>
                        <IsWeekly><%= False %></IsWeekly>
                        <IsDaily><%= False %></IsDaily>
                        <IsMonthly><%= False %></IsMonthly>
                        <OnSatrday><%= False %></OnSatrday>
                        <OnSunday><%= False %></OnSunday>
                        <OnMonday><%= False %></OnMonday>
                        <OnTuesday><%= False %></OnTuesday>
                        <OnWednesday><%= False %></OnWednesday>
                        <OnThursday><%= False %></OnThursday>
                        <OnFriday><%= False %></OnFriday>
                        <Setting>
                            <MaxCopies><%= 0 %></MaxCopies>
                            <ReplaceOldDbs><%= False %></ReplaceOldDbs>
                            <FileName></FileName>
                            <FolderName></FolderName>
                            <MakeAFolderDate><%= False %></MakeAFolderDate>
                        </Setting>
                    </Schedule>
            Dim xmlW As Xml.XmlWriter = Xml.XmlWriter.Create(xmlFileName)
            xmlW.WriteStartDocument(True)
            x.WriteTo(xmlW)
            xmlW.WriteEndDocument()
            xmlW.Flush()
            xmlW.Close()
        End If
        Dim Xdoc As XDocument = XDocument.Load(xmlFileName)
        Dim q = From no In Xdoc.<Schedule> Select no
        For Each nn In q
            If nn.<NextDate>.Value.Length > 0 Then
                Dim strd As String = nn.<NextDate>.Value
                Dim year As Integer = Integer.Parse(strd.Substring(0, 4))
                Dim month As Integer = Integer.Parse(strd.Substring(5, 2))
                Dim day As Integer = Integer.Parse(strd.Substring(8, 2))
                Dim hour As Integer = Integer.Parse(strd.Substring(11, 2))
                Dim minute As Integer = Integer.Parse(strd.Substring(14, 2))
                _NextDate = New Date(year, month, day, hour, minute, 0)
            End If
            If nn.<IsDaily>.Value.Length > 0 Then _isDaily = CBool(nn.<IsDaily>.Value)
            If nn.<IsMonthly>.Value.Length > 0 Then _isMonthly = CBool(nn.<IsMonthly>.Value)
            If nn.<IsWeekly>.Value.Length > 0 Then _isWeekly = CBool(nn.<IsWeekly>.Value)
            If nn.<OnFriday>.Value.Length > 0 Then _OnFriday = CBool(nn.<OnFriday>.Value)
            If nn.<OnMonday>.Value.Length > 0 Then _OnMonday = CBool(nn.<OnMonday>.Value)
            If nn.<OnSatrday>.Value.Length > 0 Then _OnSatarday = CBool(nn.<OnSatrday>.Value)
            If nn.<OnSunday>.Value.Length > 0 Then _OnSunday = CBool(nn.<OnSunday>.Value)
            If nn.<OnThursday>.Value.Length > 0 Then _OnThrusday = CBool(nn.<OnThursday>.Value)
            If nn.<OnTuesday>.Value.Length > 0 Then _OnTuesday = CBool(nn.<OnTuesday>.Value)
            If nn.<OnWednesday>.Value.Length > 0 Then _OnWensday = CBool(nn.<OnWednesday>.Value)
            If nn.<Setting>.<FileName>.Value.Length > 0 Then _FileName = nn.<Setting>.<FileName>.Value
            If nn.<Setting>.<FolderName>.Value.Length > 0 Then _FolderName = nn.<Setting>.<FolderName>.Value
            If nn.<Setting>.<MakeAFolderDate>.Value.Length > 0 Then _MakeNewFolder = CBool(nn.<Setting>.<MakeAFolderDate>.Value)
            If nn.<Setting>.<MaxCopies>.Value.Length > 0 Then _MaxCopies = Byte.Parse(nn.<Setting>.<MaxCopies>.Value)
            If nn.<Setting>.<ReplaceOldDbs>.Value.Length > 0 Then _ReplaceOldones = CBool(nn.<Setting>.<ReplaceOldDbs>.Value)
            If nn.<IsON>.Value.Length > 0 Then _isON = CBool(nn.<IsON>.Value)
        Next
    End Sub

    Public Sub Save()
        Dim x = <Schedule>
                    <IsON><%= _isON %></IsON>
                    <NextDate><%= _NextDate.ToString("yyyy/MM/dd-HH:mm") %></NextDate>
                    <IsWeekly><%= _isWeekly %></IsWeekly>
                    <IsDaily><%= _isDaily %></IsDaily>
                    <IsMonthly><%= _isMonthly %></IsMonthly>
                    <OnSatrday><%= _OnSatarday %></OnSatrday>
                    <OnSunday><%= _OnSunday %></OnSunday>
                    <OnMonday><%= _OnMonday %></OnMonday>
                    <OnTuesday><%= _OnTuesday %></OnTuesday>
                    <OnWednesday><%= _OnWensday %></OnWednesday>
                    <OnThursday><%= _OnThrusday %></OnThursday>
                    <OnFriday><%= _OnFriday %></OnFriday>
                    <Setting>
                        <MaxCopies><%= _MaxCopies %></MaxCopies>
                        <ReplaceOldDbs><%= _ReplaceOldones %></ReplaceOldDbs>
                        <FileName><%= _FileName %></FileName>
                        <FolderName><%= _FolderName %></FolderName>
                        <MakeAFolderDate><%= _MakeNewFolder %></MakeAFolderDate>
                    </Setting>
                </Schedule>
        Dim Xdoc As XDocument = XDocument.Load(xmlFileN)
        Xdoc.<Schedule>.Remove()
        Xdoc.AddFirst(x)
        Xdoc.Save(xmlFileN)
    End Sub
End Class
