Public Class FrmShowSalaryStatics
    Public Structure StaticData
        Public OrphanCount As Integer
        Public FamilyCount As Integer
        Public FamilySalaries As Decimal
        Public LeftMoney As Decimal
        Public Cur_short As String
        Public Sub New(ByVal OC As Integer, ByVal FC As Integer, ByVal FS As Decimal, ByVal LeftMoney As Decimal)
            Me.FamilyCount = FC
            Me.FamilySalaries = FS
            Me.LeftMoney = LeftMoney
            Me.OrphanCount = OC
        End Sub
    End Structure

    Private _StaticData As StaticData
    Public Property StaticFamilies As StaticData
        Get
            Return _StaticData
        End Get
        Set(ByVal value As StaticData)
            _StaticData = value
        End Set
    End Property
    Private _BailedData As Dictionary(Of Integer, Decimal)
    Public Property BailedFamilies As Dictionary(Of Integer, Decimal)
        Get
            Return _BailedData
        End Get
        Set(ByVal value As Dictionary(Of Integer, Decimal))
            _BailedData = value
        End Set
    End Property


    Private _familiesData As Dictionary(Of Integer, FrmShowSalaries.FinancialData)
    Public Property FamiliesData() As Dictionary(Of Integer, FrmShowSalaries.FinancialData)
        Get
            Return _familiesData
        End Get
        Set(ByVal value As Dictionary(Of Integer, FrmShowSalaries.FinancialData))
            _familiesData = value
        End Set
    End Property

    Public Sub New(ByVal _SD As StaticData, ByVal BD As Dictionary(Of Integer, Decimal))
        InitializeComponent()
        _BailedData = BD
        _StaticData = _SD
    End Sub

    Private Sub FrmShowSalaryStatics_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(_BailedData) Then
            For Each id In _BailedData.Keys
                Using odb As New OrphanageDB.Odb
                    Dim supp As OrphanageClasses.Supporter = Getter.GetSupporterByID(id, odb)
                    AddSupporter(supp, _BailedData(id).ToString())
                    odb.Dispose()
                End Using
            Next
        End If
        txtAllMonies.Text = _StaticData.FamilySalaries & " " & _StaticData.Cur_short
        txtLeftMony.Text = _StaticData.LeftMoney & " " & _StaticData.Cur_short
        txtFamiliesCount.Text = _StaticData.FamilyCount.ToString
        txtOrphanCount.Text = _StaticData.OrphanCount.ToString
        If _StaticData.LeftMoney <= 0 Then
            txtLeftMony.ForeColor = Color.Red
        End If
        If Not IsNothing(_familiesData) AndAlso _familiesData.Count > 0 Then
            For Each key In _familiesData.Keys
                Using Odb As New OrphanageDB.Odb
                    If _familiesData(key).HasErrors Then
                        Dim ConFam As OrphanageClasses.Family = Getter.GetFamilyByID(key, Odb)
                        Dim arr As New ArrayList()
                        For Each orp In ConFam.Orphans
                            If orp.Bail_ID.HasValue AndAlso Not arr.Contains(orp.Bail.Supporter_ID) Then
                                arr.Add(orp.Bail.Supporter_ID)
                            End If
                        Next
                        If arr.Count > 0 Then
                            For Each id In arr
                                Dim sup As OrphanageClasses.Supporter = Getter.GetSupporterByID(CInt(id), Odb)
                                AddConf(ConFam, sup, CStr(_familiesData(key).Salary))
                            Next
                        End If
                    End If
                    Odb.Dispose()
                End Using
            Next
        End If
    End Sub

    Public Sub AddSupporter(ByVal sup As OrphanageClasses.Supporter, ByVal val As String)
        If Not IsNothing(sup) Then
            Dim itm As New Telerik.WinControls.UI.ListViewDataItem(Getter.GetFullName(sup.Name), New String() {Getter.GetFullName(sup.Name), val.ToString() & " " & sup.Box.Currency_Short})
            lstSuppor.Items.Add(itm)
        End If
    End Sub
    Public Sub AddConf(ByVal fam As OrphanageClasses.Family, ByVal sup As OrphanageClasses.Supporter, ByVal val As String)
        If Not IsNothing(sup) Then
            Dim ret() As Integer = Getter.GetFamilyOrphans(fam.ID)
            Dim AllCount As String = CStr(IIf(IsNothing(ret), 0, ret.Length))
            Dim BaildCoutn As Integer = 0
            Dim BaildAmount As String = ""
            Dim FamName As String = Getter.GetFullName(fam.Father.Name) & " و " & Getter.GetFullName(fam.Mother.Name)
            For Each orph In fam.Orphans
                If Not IsNothing(orph.IsBailed) AndAlso orph.IsBailed AndAlso Not IsNothing(orph.Bail) AndAlso
                    orph.Bail.Supporter_ID = sup.ID Then
                    BaildCoutn += 1
                    BaildAmount = orph.Bail.Amount.ToString() & " " & orph.Bail.Box.Currency_Short
                End If
            Next
            val = val & " " & _StaticData.Cur_short
            Dim itm As New Telerik.WinControls.UI.ListViewDataItem(FamName, New String() {FamName, Getter.GetFullName(sup.Name), AllCount, CStr(BaildCoutn), BaildAmount, val})
            lstConf.Items.Add(itm)
        End If
    End Sub
End Class
