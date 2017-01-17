Imports System.Transactions
Imports OrphansRegistries
Imports COWTranslation.TranslationToWord
Imports System.IO

Module Main
    Dim NewDb As New NewOdb.NewOrphanageDataContext()
    Dim BondArray As New Dictionary(Of Integer, Integer)()
    Dim MaxNumber As Integer = 50
    Private Sub ExportToWord(ByVal from As Date, ByVal To1 As Date, ByRef SName As String)
        Dim opD As New OpenFileDialog()
        Console.WriteLine("Oepn Word File.")
        opD.Filter = "*.docx|*.docx"
        If opD.ShowDialog() <> DialogResult.OK Then Exit Sub
        Dim DocxFile As String = opD.FileName
        Dim Wtr As New COWTranslation.TranslationToWord(DocxFile, SName, True)
        Wtr.InsertImage = True
        Console.WriteLine("Loading Fathers....")
        Dim I As Integer = 0
        For Each fath In Father.GetFathers()
            If fath.Birthday > from AndAlso fath.Birthday < To1 Then
                Console.WriteLine("Father Number {0} Loading Sons...", fath.Id)
                If I > MaxNumber Then
                    Exit For
                End If
                For Each orph In fath.GetSons()
                    If orph.IsSupported() Then
                        Console.ForegroundColor = ConsoleColor.Green
                        Console.WriteLine("Supported Orphan")
                        Console.ForegroundColor = ConsoleColor.White
                        'Continue For
                    End If
                    I += 1
                    Dim ImagesBook As New Dictionary(Of String, Byte())
                    Dim StringBook As New Dictionary(Of String, String)
                    Dim mom As Mother = orph.GetMother()
                    Dim bond As BondsMan = orph.GetBondsMan()
                    Dim fam As Family = orph.GetFamily()
                    Dim Meme As New MemoryStream()
                    Try
                        orph.Photo.Save(Meme, System.Drawing.Imaging.ImageFormat.Jpeg)
                        'ImagesBook.Add("Picture".ToLower(), Meme.ToArray())
                    Catch
                    End Try
                    StringBook.Add("Number".ToLower(), orph.Id)
                    StringBook.Add("OrphName".ToLower(), orph.Name)
                    StringBook.Add("OrphBirthday".ToLower(), orph.Birthday.ToString("yyyy/MM/dd"))
                    StringBook.Add("OrphKaid".ToLower(), orph.BirthPlace)
                    StringBook.Add("OrphHealth".ToLower(), orph.HealthyState)
                    StringBook.Add("OrphSex".ToLower(), orph.Sex)
                    StringBook.Add("OrphStudy".ToLower(), orph.StudiesStage)
                    StringBook.Add("FathDie".ToLower(), fath.Birthday.ToString("yyyy/MM/dd"))
                    StringBook.Add("FathNAme".ToLower(), fath.Name)
                    StringBook.Add("FathJop".ToLower(), fath.Work)
                    StringBook.Add("FathDeathR".ToLower(), fath.Notes)
                    StringBook.Add("MothBirthday".ToLower(), mom.Birthday.ToString("yyyy/MM/dd"))
                    StringBook.Add("MothID".ToLower(), mom.IdentityNum)
                    StringBook.Add("MothIsAlive".ToLower(), ToOffice.BoolToTxt(mom.IsAlive))
                    If mom.IsMarried Then
                        StringBook.Add("MothIsMarried".ToLower(), "نعم")
                    Else
                        StringBook.Add("MothIsMarried".ToLower(), "لا")
                    End If
                    StringBook.Add("MothIsOwnAnother".ToLower(), mom.IsOwnOtherOrphans)
                    StringBook.Add("MothIsOwnOrphan".ToLower(), ToOffice.BoolToTxt(mom.IsOwnOrphan))
                    StringBook.Add("MothName".ToLower(), mom.Name)
                    StringBook.Add("MothWork".ToLower(), mom.Jop)
                    StringBook.Add("FamilyFinn".ToLower(), fam.FinancialState)
                    StringBook.Add("FamilyId".ToLower(), fam.Number)
                    StringBook.Add("FamilyRS".ToLower(), fam.ResidenceState)
                    StringBook.Add("FamilyRT".ToLower(), fam.ResidenceType)
                    StringBook.Add("BondsJop".ToLower(), bond.Jop)
                    StringBook.Add("BondsMI".ToLower(), bond.MonthlyIncome)
                    StringBook.Add("BondsName".ToLower(), bond.Name)
                    StringBook.Add("BondsRelation".ToLower(), orph.BondsMan_R)
                    StringBook.Add("Address".ToLower(), bond.Address)
                    StringBook.Add("Phone".ToLower(), bond.Phone)
                    StringBook.Add("Date".ToLower(), Date.Now.ToShortDateString)
                    Wtr.AddPage(orph.Id, ImagesBook, StringBook)
                    Console.WriteLine("Add Orphan number {0} .", orph.Id)
                    If I = 60 Then
                        I = 0
                        Wtr.DoIt()
                        GC.ReRegisterForFinalize(Wtr)
                        Wtr = New COWTranslation.TranslationToWord(DocxFile, SName, True)
                        Wtr.InsertImage = True
                    End If
                Next
            End If
            GC.Collect()
        Next
        GC.Collect()
        Console.WriteLine("Write Data To Word File....")
        Wtr.DoIt()
    End Sub
    Private Sub ExportFilesToWord(ByVal from As Date, ByVal To1 As Date, ByRef SName As String)
        Dim opD As New OpenFileDialog()
        Console.WriteLine("Oepn Word File.")
        opD.Filter = "*.docx|*.docx"
        If opD.ShowDialog() <> DialogResult.OK Then Exit Sub
        Dim DocxFile As String = opD.FileName
        Console.WriteLine("Loading Fathers....")
        Dim I As Integer = 0
        Dim OrphanIndex = 0, FatherIndex As Integer = 0
        If Not System.IO.Directory.Exists(SName) Then
            System.IO.Directory.CreateDirectory(SName)
        End If
        Dim bond As BondsMan = Nothing
        Dim Sons() As Orphan = Nothing
        Dim fath As Father = Nothing
        For FatherIndex = 0 To 3000
            fath = Father.GetFather(FatherIndex)
            If IsNothing(fath) Then Continue For
            If fath.Birthday > from AndAlso fath.Birthday < To1 Then
                Console.WriteLine("Father Number {0} Loading Sons...", fath.Id)
                Sons = fath.GetSons()
                For Each orph In Sons
                    Dim fatherDest As String = SName & "\" & fath.Name
                    Dim DestinationDoc As String = fatherDest & "\" & orph.Name & ".docx"
                    fatherDest &= "\"
                    If Not System.IO.Directory.Exists(fatherDest) Then
                        System.IO.Directory.CreateDirectory(fatherDest)
                    Else
                        If System.IO.File.Exists(fatherDest & orph.Name & ".jpg") AndAlso System.IO.File.Exists(DestinationDoc) Then
                            Console.WriteLine("Skiped")
                            Continue For
                        End If
                    End If
                    If orph.IsSupported() Then
                        Console.ForegroundColor = ConsoleColor.Green
                        Console.WriteLine("Supported Orphan")
                        Console.ForegroundColor = ConsoleColor.White
                        'Continue For
                    End If
                    I += 1
                    bond = orph.GetBondsMan()
                    Try
                        orph.Photo.Save(fatherDest & orph.Name & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                        File.Copy(DocxFile, DestinationDoc, True)
                    Catch
                    End Try
                    COWTranslation.TranslationToWord.UpadteTextAfterBookmarke("Number".ToLower(), orph.Id, DestinationDoc)
                    COWTranslation.TranslationToWord.UpadteTextAfterBookmarke("OrphName".ToLower(), orph.Name, DestinationDoc)
                    COWTranslation.TranslationToWord.UpadteTextAfterBookmarke("FathDie".ToLower(), fath.Birthday.ToString("yyyy/MM/dd"), DestinationDoc)
                    COWTranslation.TranslationToWord.UpadteTextAfterBookmarke("FathJop".ToLower(), fath.Work, DestinationDoc)
                    COWTranslation.TranslationToWord.UpadteTextAfterBookmarke("Address".ToLower(), bond.Address, DestinationDoc)
                    COWTranslation.TranslationToWord.UpadteTextAfterBookmarke("Phone".ToLower(), bond.Phone, DestinationDoc)
                    COWTranslation.TranslationToWord.UpadteTextAfterBookmarke("Date".ToLower(), Date.Now.ToShortDateString, DestinationDoc)
                    Console.WriteLine("Add Orphan number {0} .", orph.Id)
                Next
            End If
            GC.Collect()
            GC.WaitForFullGCComplete()
            GC.WaitForFullGCApproach()
        Next
        GC.Collect()
        Console.WriteLine("Write Data To Word File....")
    End Sub

    Private Sub ExportToExcel(ByVal S_Father_id As Integer, ByVal E_FAther_ID As Integer, ByVal SFilename As String, ByVal UnSFilename As String)
        Dim opD As New FolderBrowserDialog
        Console.WriteLine("Oepn Excel File.")
        If opD.ShowDialog() <> DialogResult.OK Then Exit Sub
        SFilename = opD.SelectedPath & "\" & SFilename
        UnSFilename = opD.SelectedPath & "\" & UnSFilename
        Console.WriteLine("Loading Fathers....")
        Dim SupData As New Dictionary(Of String, String())
        Dim UnSupData As New Dictionary(Of String, String())

        Dim OrphanNAme As New ArrayList()
        Dim FAtherNAme As New ArrayList()
        Dim MotherNAme As New ArrayList()
        Dim BrothersCouut As New ArrayList()
        Dim SupporterName As New ArrayList()
        Dim orphanSalaries As New ArrayList()
        Dim orphanAge As New ArrayList()
        Dim OrphanBirthday As New ArrayList()
        Dim FathersDiedate As New ArrayList()

        Dim SOrphanNAme As New ArrayList()
        Dim SFAtherNAme As New ArrayList()
        Dim SMotherNAme As New ArrayList()
        Dim SBrothersCouut As New ArrayList()
        Dim SorphanAge As New ArrayList()
        Dim SOrphanBirthday As New ArrayList()
        Dim SFathersDiedate As New ArrayList()

        Dim I As Integer = 0
        Dim OrphanIndex = 0, FatherIndex As Integer = 0
        Dim bond As BondsMan = Nothing
        Dim Sons() As Orphan = Nothing
        Dim fath As Father = Nothing
        For FatherIndex = S_Father_id To E_FAther_ID
            fath = Father.GetFather(FatherIndex)
            If IsNothing(fath) Then Continue For
            Console.WriteLine("Father Number {0} Loading Sons...", fath.Id)
            Sons = fath.GetSons()
            For Each orph In Sons
                If Not IsNothing(orph.Suporter_ID) AndAlso orph.IsSupported() AndAlso orph.Suporter_ID > 0 Then
                    Dim bro() = orph.GetBrothers()
                    Dim td As New Itenso.TimePeriod.DateDiff(orph.Birthday, Date.Now)
                    SOrphanNAme.Add(orph.Name)
                    SorphanAge.Add(td.ElapsedYears.ToString())
                    SOrphanBirthday.Add(orph.Birthday.ToString("yyyy/MM/dd"))
                    SFAtherNAme.Add(fath.Name)
                    SFathersDiedate.Add(fath.Birthday.ToString("yyyy/MM/dd"))
                    SMotherNAme.Add(orph.GetMother().Name)
                    SupporterName.Add(orph.GetSuporter().Name)
                    If Not IsNothing(bro) AndAlso bro.Length > 0 Then
                        SBrothersCouut.Add(bro.Length.ToString())
                    Else
                        SBrothersCouut.Add("0")
                    End If
                    If Not IsNothing(orph.Salary) AndAlso orph.Salary > 0 Then
                        orphanSalaries.Add(orph.Salary.ToString())
                    Else
                        orphanSalaries.Add("0")
                    End If
                    Console.WriteLine("Add Orphan number {0} .", orph.Id)
                Else
                    Dim bro() = orph.GetBrothers()
                    Dim td As New Itenso.TimePeriod.DateDiff(orph.Birthday, Date.Now)
                    OrphanNAme.Add(orph.Name)
                    orphanAge.Add(td.ElapsedYears.ToString())
                    OrphanBirthday.Add(orph.Birthday.ToString("yyyy/MM/dd"))
                    FAtherNAme.Add(fath.Name)
                    FathersDiedate.Add(fath.Birthday.ToString("yyyy/MM/dd"))
                    MotherNAme.Add(orph.GetMother().Name)
                    If Not IsNothing(bro) AndAlso bro.Length > 0 Then
                        BrothersCouut.Add(bro.Length.ToString())
                    Else
                        BrothersCouut.Add("0")
                    End If
                    Console.WriteLine("Add Orphan number {0} .", orph.Id)
                End If
            Next
            GC.Collect()
            GC.WaitForFullGCComplete()
            GC.WaitForFullGCApproach()
        Next
        SupData.Add("A", CType(SOrphanNAme.ToArray(GetType(String)), String()))
        SupData.Add("B", CType(SOrphanBirthday.ToArray(GetType(String)), String()))
        SupData.Add("C", CType(SorphanAge.ToArray(GetType(String)), String()))
        SupData.Add("D", CType(SBrothersCouut.ToArray(GetType(String)), String()))
        SupData.Add("E", CType(SFAtherNAme.ToArray(GetType(String)), String()))
        SupData.Add("F", CType(SFathersDiedate.ToArray(GetType(String)), String()))
        SupData.Add("G", CType(SMotherNAme.ToArray(GetType(String)), String()))
        SupData.Add("H", CType(SupporterName.ToArray(GetType(String)), String()))
        SupData.Add("I", CType(orphanSalaries.ToArray(GetType(String)), String()))
        COWTranslation.TranslateToExcel.SendStringsToExcel(SFilename, SupData)
        UnSupData.Add("A", CType(OrphanNAme.ToArray(GetType(String)), String()))
        UnSupData.Add("B", CType(OrphanBirthday.ToArray(GetType(String)), String()))
        UnSupData.Add("C", CType(orphanAge.ToArray(GetType(String)), String()))
        UnSupData.Add("D", CType(BrothersCouut.ToArray(GetType(String)), String()))
        UnSupData.Add("E", CType(FAtherNAme.ToArray(GetType(String)), String()))
        UnSupData.Add("F", CType(FathersDiedate.ToArray(GetType(String)), String()))
        UnSupData.Add("G", CType(MotherNAme.ToArray(GetType(String)), String()))
        COWTranslation.TranslateToExcel.SendStringsToExcel(UnSFilename, UnSupData)
        GC.Collect()
        Console.WriteLine("Write Data To Word File....")
    End Sub
    Public Sub Main()
        'Dim qOrph = From orph In OldDb.Orphans Select orph
        'Dim qFAth = From fath In OldDb.Fathers Select fath
        'Dim qMoth = From moth In OldDb.Mothers Select moth
        'Dim qFam = From fam In OldDb.Families Select fam
        'Dim qBond = From bond In OldDb.BondsMans Select bond
        Console.WriteLine("this program will add the old data in your old Database to the new Database.")
        Console.WriteLine("Please entre yor Administrator password")
        Console.WriteLine("Password:")
        Dim str As String = Console.ReadLine()
        Dim checkUsr = From sr In NewDb.Users Where sr.Password = str AndAlso sr.UserName = "مدير" Select sr
        If IsNothing(checkUsr) OrElse checkUsr.Count <> 1 Then
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("Access Denied!")
            Console.ForegroundColor = ConsoleColor.White
            Console.Read()
            Exit Sub
        End If
        Console.WriteLine("Oepn Old Orphan DataBase")
        Dim opD As New OpenFileDialog()
        opD.Filter = "*.MDF|*.MDF"
        If opD.ShowDialog() <> DialogResult.OK Then Exit Sub
        DataBaseWorker.DBPath = opD.FileName
        'ExportToExcel(0, 50, "مكفول1.xlsx", "غير مكفول1.xlsx")
        'ExportToExcel(51, 100, "مكفول2.xlsx", "غير مكفول2.xlsx")
        'ExportToExcel(101, 150, "مكفول3.xlsx", "غير مكفول3.xlsx")
        'ExportToExcel(151, 200, "مكفول4.xlsx", "غير مكفول4.xlsx")
        'ExportToExcel(401, 450, "مكفول5.xlsx", "غير مكفول5.xlsx")
        'ExportToExcel(451, 500, "مكفول6.xlsx", "غير مكفول6.xlsx")
        'ExportToExcel(501, 550, "مكفول7.xlsx", "غير مكفول7.xlsx")
        'ExportToExcel(551, 600, "مكفول8.xlsx", "غير مكفول8.xlsx")
        'ExportToExcel(601, 650, "مكفول9.xlsx", "غير مكفول9.xlsx")
        'ExportToExcel(651, 700, "مكفول10.xlsx", "غير مكفول10.xlsx")
        ExportToExcel(701, 735, "مكفول11.xlsx", "غير مكفول11.xlsx")
        'ExportToWord(#1/1/2005#, #1/1/2008#, "c:\1234-1.docx")
        'ExportToWord(#1/1/2008#, #1/1/2011#, "c:\1234-2.docx")
        'ExportToWord(#1/1/2011#, #1/1/2012#, "c:\1234-3.docx")
        'ExportToWord(#1/1/2012#, #5/1/2012#, "c:\1234-4.docx")
        'ExportToWord(#5/1/2012#, #7/15/2012#, "c:\1234-5.docx")
        'ExportToWord(#7/15/2012#, #10/1/2012#, "c:\1234-6.docx")
        'ExportToWord(#10/1/2012#, #1/1/2013#, "c:\1234-7.docx")
        'ExportToWord(#1/1/2013#, #5/1/2013#, "c:\1234-8.docx")
        'ExportToWord(#5/1/2013#, #10/1/2013#, "c:\1234-9..docx")
        'ExportToWord(#10/1/2013#, #1/1/2014#, "c:\1234-10.docx")
        'ExportFilesToWord(#1/1/2014#, #5/5/2014#, "c:\Exports")
        'Console.WriteLine("Success.")
        'Console.ReadLine()
        'Return
        Dim qUsr = From usr In NewDb.Users Where usr.UserName = "البرنامج القديم" Select usr
        Dim AddAdmin As Boolean = False
        Dim SavedFamilies As New ArrayList()
        Dim adminUser As NewOClasses.User
        If qUsr.Count = 0 Then
            Using ts = New TransactionScope
                Dim nameObj As New NewOClasses.Name With {.First = "البرنامج القديم", .EName = "Old Program"}
                NewDb.Names.InsertOnSubmit(nameObj)
                NewDb.SubmitChanges()
                NewDb.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, nameObj)
                adminUser = New NewOClasses.User() With {.UserName = "البرنامج القديم", .IsAdmin = True, .RegDate = Date.Now, .Note = "لايمكن حذف أو استبدال هذا المستخدم يمكن فقط تغير كلمة المرور", _
                                                                   .Name_ID = nameObj.ID, .CanRead = True, .CanDraw = True, .CanDeposit = True, .CanDelete = True, .CanAdd = True, .Password = "0000"}
                NewDb.Users.InsertOnSubmit(adminUser)
                NewDb.SubmitChanges()
                ts.Complete()
                AddAdmin = True
            End Using
        Else
            adminUser = qUsr.First()
            AddAdmin = True
        End If
        If Not AddAdmin Then
            Exit Sub
        End If
        Dim Fs As New FileStream("c:\logoo.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
        Dim Sw As New StreamWriter(Fs)
        For Each fath In Father.GetFathers()
            If Not SavedFamilies.Contains(fath.Id) AndAlso fath.Id > 615 Then
                If Father.HasAnSupportedOrphan(fath) Then
                    Dim sons = fath.GetSons()
                    For Each orp In sons
                        Sw.WriteLine(fath.Name)
                        If orp.IsSupported() OrElse (Not IsNothing(orp.Suporter_ID) AndAlso orp.Suporter_ID > 0) Then
                            Sw.WriteLine(Space(8) & orp.Name)
                            Sw.WriteLine(Space(8) & orp.GetSuporter().Name)
                        End If
                    Next
                    Console.WriteLine(fath.Id)
                    Sw.Flush()
                    GC.RemoveMemoryPressure(10000000)
                    GC.Collect()
                End If
                'If AddFamily(fath, adminUser.ID) Then SavedFamilies.Add(fath.Id)
            End If
        Next
        Sw.Flush()
        Sw.Close()
        Fs.Close()
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("FINISHED")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("Press any key to continue")
        Console.Read()
    End Sub
    Public Structure FullName
        Public First As String
        Public Last As String
        Public Father As String
        Public HasFather As Boolean
        Public Overrides Function ToString() As String
            If Me.HasFather Then
                Return Me.First + " " + Me.Father + " " + Me.Last
            Else
                Return Me.First + " " + Me.Last
            End If
        End Function
    End Structure
    Public Structure FullAddress
        Public State As String
        Public City As String
        Public Town As String
        Public Street As String
        Public Overrides Function ToString() As String
            If Not IsNothing(Me.State) And Me.State.Trim.Length > 0 Then
                Return Me.State + " " + Me.City + " " + Me.Town + " " + Me.Street
            Else
                If Not IsNothing(Me.City) And Me.City.Trim.Length > 0 Then
                    Return Me.City + " " + Me.Town + " " + Me.Street
                Else
                    Return Me.Town + " " + Me.Street
                End If
            End If
        End Function
    End Structure

    Public Function AddFamily(ByVal OldFather As Father, ByVal AdminID As Integer) As Boolean
        Try
            Dim LastFAtherID As Integer = 0
            For Each fam In OldFather.GetFamily()
                Dim moth As Mother = fam.GetMother()
                Dim FullFAtherNAme As FullName = GetLastName(OldFather.Name)
                Dim FullMotherNAme As FullName = GetLastName(moth.Name)
                Dim NewFName As New NewOClasses.Name With {.First = FullFAtherNAme.First, .Last = FullFAtherNAme.Last}
                Dim NewMName As New NewOClasses.Name With {.First = FullMotherNAme.First, .Last = FullMotherNAme.Last}
                Dim CurAddress As New NewOClasses.Address()
                If FullFAtherNAme.HasFather Then
                    NewFName.Father = FullFAtherNAme.Father
                End If
                Dim NewMother As New NewOClasses.Mother
                Dim NewFather As New NewOClasses.Father
                Dim NewFamily As New NewOClasses.Famly
                Dim Sons As Orphan() = moth.GetSons()
                If IsNothing(Sons) Then Continue For
                Using scope = New TransactionScope

                    NewDb.Names.InsertOnSubmit(NewFName)
                    NewDb.SubmitChanges()
                    NewDb.Names.InsertOnSubmit(NewMName)
                    NewDb.SubmitChanges()
                    NewMother.Birthday = moth.Birthday
                    Try
                        NewMother.IdentityCard_ID = IIf(IsNumeric(moth.IdentityNum), Decimal.Parse(moth.IdentityNum), Nothing)
                    Catch
                    End Try
                    NewMother.IsDead = Not (moth.IsAlive)
                    NewMother.IsMarried = moth.IsMarried
                    NewMother.IsOwnOrphans = moth.IsOwnOrphan
                    NewMother.Jop = moth.Jop
                    NewMother.Note = moth.Notes
                    NewMother.Name_Id = NewMName.ID
                    NewMother.RegDate = Date.Now
                    NewMother.User_ID = AdminID

                    NewFather.Name_ID = NewFName.ID
                    NewFather.Dieday = OldFather.Birthday
                    NewFather.Birthday = New Date(1975, 1, 1)
                    NewFather.Jop = OldFather.Work
                    NewFather.Note = OldFather.Notes
                    NewFather.RegDate = Date.Now
                    NewFather.User_ID = AdminID

                    NewDb.Mothers.InsertOnSubmit(NewMother)
                    NewDb.SubmitChanges()
                    If LastFAtherID = 0 Then
                        NewDb.Fathers.InsertOnSubmit(NewFather)
                        NewDb.SubmitChanges()
                        LastFAtherID = NewFather.ID
                    End If

                    NewFamily.IsBailed = False
                    NewFamily.isExcluded = False
                    NewFamily.IsRefugee = False
                    NewFamily.FamilyCard_Num = fam.Number.ToString()
                    NewFamily.Father_Id = LastFAtherID
                    NewFamily.Mother_ID = NewMother.ID

                    If fam.ResidenceState.Contains("جي") Then
                        NewFamily.Redidence_State = "جيد"
                    ElseIf fam.ResidenceState.Contains("سط") Then
                        NewFamily.Redidence_State = "مقبول"
                    ElseIf fam.ResidenceState.EndsWith("يء") Then
                        NewFamily.Redidence_State = "سيئ"
                    Else
                        NewFamily.Redidence_State = "سيئ جداً"
                    End If
                    NewFamily.Residence_Type = fam.ResidenceType
                    If fam.FinancialState.Contains("جيدة") Then
                        NewFamily.Finncial_State = "جيد"
                    ElseIf fam.FinancialState.Contains("وسط") Then
                        fam.FinancialState = "متوسط"
                    ElseIf fam.FinancialState.Contains("ماسة") Then
                        fam.FinancialState = "سيئ"
                    Else
                        fam.FinancialState = "سيئ جداً"
                    End If
                    NewFamily.RegDate = Date.Now
                    NewFamily.User_ID = AdminID

                    NewDb.Famlies.InsertOnSubmit(NewFamily)
                    NewDb.SubmitChanges()
                    scope.Complete()
                    Application.DoEvents()
                    Console.WriteLine("Add New Family number " & fam.Id)
                End Using
                'If fam.Id = 697 Then Stop
                For Each orph As Orphan In Sons
                    If orph.IsSupported() Then
                        Console.ForegroundColor = ConsoleColor.Blue
                        Console.WriteLine(vbTab & "Orphan Number {0} is Supported.", orph.Id)
                        Console.ForegroundColor = ConsoleColor.White
                        Continue For
                    End If
                    Dim NewOrph As New NewOClasses.Orphan()
                    Dim OldBo As BondsMan = orph.GetBondsMan()
                    Dim bo As New NewOClasses.BondsMen
                    Dim Gbona As FullName = GetLastName(OldBo.Name)
                    Dim Oname As FullName = GetLastName(orph.Name)
                    Dim NOname As New NewOClasses.Name With {.First = Oname.First, .Last = Oname.Last}
                    If Not IsNothing(NewFather.Name) AndAlso Not IsNothing(NewFather.Name.First) Then
                        NOname.Father = NewFather.Name.First
                    Else

                    End If
                    Dim BoNAme As New NewOClasses.Name() With {.First = Gbona.First, .Last = Gbona.Last}
                    Using scope = New TransactionScope
                        If Not IsNothing(OldBo) AndAlso Not BondArray.ContainsKey(OldBo.Id) Then
                            If Gbona.HasFather Then
                                BoNAme.Father = Gbona.Father
                            End If
                            NewDb.Names.InsertOnSubmit(BoNAme)
                            NewDb.SubmitChanges()
                            bo.Name_Id = BoNAme.ID
                            bo.Note = OldBo.Notes
                            bo.Income = GetNum(OldBo.MonthlyIncome)
                            bo.Jop = OldBo.MonthlyIncome
                            bo.User_ID = AdminID
                            bo.RegDate = Date.Now
                            Dim FamAdd As FullAddress = GetAddress(OldBo.Address)
                            CurAddress.Country = FamAdd.State
                            CurAddress.City = FamAdd.City
                            CurAddress.Town = FamAdd.Town
                            CurAddress.Street = FamAdd.Street
                            CurAddress.Cell_Phone = OldBo.Phone
                            NewDb.Addresses.InsertOnSubmit(CurAddress)
                            NewDb.SubmitChanges()
                            NewFamily.Address_ID2 = CurAddress.ID
                            NewDb.BondsMens.InsertOnSubmit(bo)
                            NewDb.SubmitChanges()
                            BondArray.Add(OldBo.Id, bo.ID)
                        End If
                        NewDb.Names.InsertOnSubmit(NOname)
                        NewDb.SubmitChanges()
                        Console.ForegroundColor = ConsoleColor.Green
                        Console.WriteLine(vbTab & "Add New BondsMan number " & OldBo.Id)
                        Console.ForegroundColor = ConsoleColor.White
                        Application.DoEvents()
                        Dim Oage As Integer = New Itenso.TimePeriod.DateDiff(orph.Birthday, Date.Now).ElapsedYears
                        NewOrph.Family_ID = NewFamily.ID
                        NewOrph.BondsMan_ID = BondArray(OldBo.Id)
                        NewOrph.Name = NOname.ID
                        NewOrph.Age = Oage
                        NewOrph.Birthday = orph.Birthday
                        NewOrph.BondsManRel = orph.BondsMan_R
                        NewOrph.Gender = orph.Sex
                        NewOrph.Kaid = GetNum(orph.BirthPlace)
                        NewOrph.Birthplace = GetOnlyString(orph.BirthPlace)
                        NewOrph.FacePhoto = orph.BytePhoto
                        NewOrph.RegDate = Date.Now
                        NewOrph.User_ID = AdminID
                        NewDb.Orphans.InsertOnSubmit(NewOrph)
                        NewDb.SubmitChanges()
                        Console.ForegroundColor = ConsoleColor.Magenta
                        Console.WriteLine(vbTab & vbTab & "Add New Orphan number " & orph.Id)
                        Console.ForegroundColor = ConsoleColor.White
                        Application.DoEvents()
                        scope.Complete()
                    End Using
                Next
            Next
            Return True
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine(ex.Message)
            Console.ForegroundColor = ConsoleColor.White
            Console.Read()
            Return False
        End Try
    End Function
    Public Function GetOnlyString(ByVal str As String) As String
        Dim r As String = ""
        For Each c As Char In str
            If Char.IsLetter(c) Then
                r &= c
            End If
        Next
        If r.Length > 0 Then
            Return r
        Else
            Return Nothing
        End If
    End Function

    Public Function GetNum(ByVal str As String) As Integer
        Dim ret As Integer
        Dim r As String = ""
        For Each c As Char In str
            If Char.IsNumber(c) Then
                r &= c
            End If
        Next
        If r.Length > 0 Then
            Try
                ret = Integer.Parse(r)
            Catch
                ret = -1
            End Try
            Return ret
        Else
            Return -1
        End If
    End Function
    Public Function GetLastName(ByVal str As String) As FullName
        Dim strAr = str.Split(New Char() {" "})
        Dim fulN As New FullName()
        Dim Reallength As Integer = 0

        For Each ss As String In strAr
            If ss.Trim().Length > 2 Then Reallength += 1
        Next
        Select Case Reallength
            Case 1
                Dim i = 0
                For Each ss As String In strAr
                    If ss.Trim().Length > 2 Then
                        i += 1
                        If i = 1 Then
                            fulN.First = ss
                        End If
                    End If
                Next
            Case 2
                Dim i = 0
                For Each ss As String In strAr
                    If ss.Trim().Length > 2 Then
                        i += 1
                        If i = 1 Then
                            fulN.First = ss
                        ElseIf i = 2 Then
                            fulN.Last = ss
                        End If
                    End If
                Next
            Case 3
                Dim i = 0
                Dim HasAFather As Boolean = False
                For Each ss As String In strAr
                    If ss.Trim().Length > 2 Then
                        i += 1
                        If i = 1 Then
                            If ss.Trim() <> "عبد" Then
                                HasAFather = True
                            End If
                        End If
                        If HasAFather = True Then
                            If i = 1 Then
                                fulN.First = ss
                            ElseIf i = 2 Then
                                fulN.Father = ss
                                fulN.HasFather = True
                            ElseIf i = 3 Then
                                fulN.Last = ss
                            End If
                        Else
                            If i = 1 Then
                                fulN.First = ss
                            ElseIf i = 2 Then
                                fulN.First += " " + ss
                            ElseIf i = 3 Then
                                fulN.Last = ss
                            End If
                        End If
                    End If
                Next
            Case 4
                Dim i = 0
                Dim HasAComplexFather As Boolean = False
                For Each ss As String In strAr
                    If ss.Trim().Length > 2 Then
                        i += 1
                        If i = 1 Then
                            If ss.Trim() <> "عبد" Then
                                HasAComplexFather = True
                            End If
                            fulN.First = ss
                        End If
                        If HasAComplexFather = True Then
                            If i = 2 Then
                                fulN.Father = ss
                                fulN.HasFather = True
                            ElseIf i = 3 Then
                                fulN.Father += " " + ss
                            ElseIf i = 4 Then
                                fulN.Last = ss
                            End If
                        Else
                            If i = 2 Then
                                fulN.First += " " + ss
                            ElseIf i = 3 Then
                                fulN.Father = " " + ss
                                fulN.HasFather = True
                            ElseIf i = 4 Then
                                fulN.Last = ss
                            End If
                        End If
                    End If
                Next
            Case 5
                Dim i = 0
                Dim HasAComplexFather As Boolean = False
                For Each ss As String In strAr
                    If ss.Trim().Length > 2 Then
                        i += 1
                        If i = 1 Then
                            fulN.First = ss
                        ElseIf i = 2 Then
                            fulN.First += " " + ss
                        ElseIf i = 3 Then
                            fulN.Father = ss
                            fulN.HasFather = True
                        ElseIf i = 4 Then
                            fulN.Father += " " + ss
                        ElseIf i = 5 Then
                            fulN.Last = ss
                        End If
                    End If
                Next
            Case Else
                Console.WriteLine(str)
        End Select
        Return fulN
    End Function

    Public Function GetAddress(ByVal str As String) As FullAddress
        Dim ret As FullAddress = Nothing
        Dim strAr = str.Split(New Char() {"-"})
        Dim Reallength As Integer = 0
        Reallength = strAr.Length
        ret = New FullAddress
        Select Case Reallength
            Case 1
                For Each ss As String In strAr
                    If ss.StartsWith("تلب") Then
                        ret.State = "حمص"
                        ret.City = "تلبيسة"
                        ret.Town = ""
                        ret.Street = ""
                    Else
                        ret.State = "حمص"
                        ret.City = "تلبيسة"
                        ret.Town = ss
                        ret.Street = ""
                    End If
                Next
                Return ret
            Case 2
                Dim i = 0
                ret.State = "حمص"
                For Each ss As String In strAr
                    If i = 0 Then
                        If ss.StartsWith("تلب") Then
                            ret.City = "تلبيسة"
                        Else
                            ret.City = "تلبيسة"
                            ret.Town = ss
                        End If
                    Else
                        ret.Street = ss
                    End If
                    i += 1
                Next
                Return ret
            Case 3
                Dim i = 0
                ret.State = "حمص"
                For Each ss As String In strAr
                    If i = 0 Then
                        If ss.StartsWith("تلب") Then
                            ret.City = "تلبيسة"
                        Else
                            ret.City = "تلبيسة"
                            ret.Town = ss
                        End If
                    ElseIf i = 1 Then
                        If IsNothing(ret.Town) OrElse ret.Town.Length = 0 Then
                            ret.Town = ss
                        End If
                    Else
                        ret.Street = ss
                    End If
                    i += 1
                Next
                Return ret
            Case Else
                MsgBox("")
        End Select
        Return ret
    End Function

End Module
