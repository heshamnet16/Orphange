using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI ;
using System.Collections;
namespace OrphansViewer
{
    public partial class frmMain : Telerik.WinControls.UI.RadForm
    {
        private bool AllisOK = true;
        private string FilePath = "";
        private bool IsLoded = false;
        Dictionary<FileCreation.XmlBuilder.Orphan, FileCreation.XmlBuilder.BondsMan> dicOrphans;
        ArrayList OrphansId;
        int CurrentID = 0;        
        public frmMain()
        {
            InitializeComponent();
            dicOrphans = new Dictionary<FileCreation.XmlBuilder.Orphan, FileCreation.XmlBuilder.BondsMan>();
            OrphansId = new ArrayList();
        }
        public frmMain(string filePath)
        {
            InitializeComponent();
            dicOrphans = new Dictionary<FileCreation.XmlBuilder.Orphan, FileCreation.XmlBuilder.BondsMan>();
            OrphansId = new ArrayList();
            this.FilePath = filePath;
        }
        public static bool IsCorrectFile(string FileName)
        {
            try
            {
                FileCreation.BinaryFile Br = new FileCreation.BinaryFile();
                Br.FileName = FileName;
                Br.UseCrypto = true;
                byte[] xx = Br.ReadAllBytes();
                FileCreation.XmlBuilder Xml = new FileCreation.XmlBuilder();
                Xml.FromXMLBytes(xx);
                if (Xml.Fath_FirstName != null && Xml.Fath_FirstName.Length != 0)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }
        private void EditMode(Control.ControlCollection conts, bool val)
        {
            if (conts == null || conts.Count == 0) return;
            foreach (Control con in conts)
            {
                if (con is AddressForm.AddressForm)
                    ((AddressForm.AddressForm)con).Enabled = val;
                if (con is NameForm.NameForm)
                    ((NameForm.NameForm)con).Enabled = val;
                if (con is RadTextBox)
                {
                    RadTextBox txt = (RadTextBox)con;
                    if (!txt.ReadOnly)
                        txt.Enabled = val;                    
                }
                if (con is RadCheckBox )
                    ((RadCheckBox)con).Enabled = val;
                if (con is RadSpinEditor )
                    ((RadSpinEditor)con).Enabled = val;
                if (con is RadAutoCompleteBox )
                    ((RadAutoCompleteBox)con).Enabled = val;
                if (con is RadDateTimePicker)
                    ((RadDateTimePicker)con).Enabled = val;
                if (con is RadDropDownList )
                    ((RadDropDownList)con).Enabled = val;
                if (con is PictureSelector.PictureSelector)
                    ((PictureSelector.PictureSelector)con).Enabled = val;
                if (con.HasChildren || con.Controls != null)
                    EditMode(con.Controls,val);
            }
        }
        private void txtBAddress_Click(object sender, EventArgs e)
        {
            HideAddressOrName(this.Controls);
            BAddressForm.ShowMe();
        }

        private void txtBName_Click(object sender, EventArgs e)
        {
            HideAddressOrName(this.Controls);
            BNameForm.ShowMe();
        }

        private void HideAllNAme_Address_FormControls_Click(object sender, EventArgs e)
        {
            HideAddressOrName(this.Controls );
            if (pges.SelectedPage == pgeOrphans)
                txtOName.Text= Getter.GetFullName(OnameForm);
            if (pges.SelectedPage == pgeFAther)
                txtFathName.Text = Getter.GetFullName(FathNameform);
            if (pges.SelectedPage == pgeMother)
            {
                txtMothAddress.Text = Getter.GetAddress(MothAddresForm);
                txtMothName.Text = Getter.GetFullName(MothNAmeForm);
            }
            if (pges.SelectedPage == pgeFamily)
            {
                txtFamAddresCurrent.Text = Getter.GetAddress(FamAddressCurrent);
                txtFamAddressOrg.Text = Getter.GetAddress(FamAddressOrg);
            }
            if (pges.SelectedPage == pgeBondsMan)
            {
                txtBAddress.Text = Getter.GetAddress(BAddressForm);
                txtBName.Text = Getter.GetFullName(BNameForm);
            }
        }
        private void HideAddressOrName(Control.ControlCollection conts)
        {
            if (conts == null || conts.Count == 0 ) return;
            foreach (Control con in conts)
            {
                if (con is AddressForm.AddressForm)
                    ((AddressForm.AddressForm)con).HideMe();
                if (con is NameForm.NameForm )
                    ((NameForm.NameForm)con).HideMe();
                if (con.HasChildren || con.Controls!=null)
                    HideAddressOrName(con.Controls);
            }
        }

        private void txtOName_Click(object sender, EventArgs e)
        {
            HideAddressOrName(this.Controls);
            OnameForm.ShowMe();
        }

        private void txtFathName_Click(object sender, EventArgs e)
        {
            HideAddressOrName(this.Controls);
            FathNameform.ShowMe();
        }

        private void txtMothAddress_Click(object sender, EventArgs e)
        {
            HideAddressOrName(this.Controls);
            MothAddresForm.ShowMe();
        }

        private void txtMothName_Click(object sender, EventArgs e)
        {
            HideAddressOrName(this.Controls);
            MothNAmeForm.ShowMe();
        }

        private void txtFamAddresCurrent_Click(object sender, EventArgs e)
        {
            HideAddressOrName(this.Controls);
            FamAddressCurrent.ShowMe();
        }

        private void txtFamAddressOrg_Click(object sender, EventArgs e)
        {
            HideAddressOrName(this.Controls);
            FamAddressOrg.ShowMe();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            pges.SelectedPage = pgeFAther;
            pgeView2.SelectedPage = pgeOBasic;
            //EditMode(this.Controls,false);
            if (this.FilePath != null && this.FilePath.Length > 3)
            {
                FileCreation.BinaryFile br = new FileCreation.BinaryFile();
                FileCreation.XmlBuilder xb = new FileCreation.XmlBuilder();
                br.UseCrypto = true;
                br.FileName = this.FilePath;
                this.Icon= xb.OrphanIconsFromXMLBytes(br.ReadAllBytes(),new Size(64,64))[0];
            }
            btnEdit.ToggleState  = Telerik.WinControls.Enumerations.ToggleState.Off;
        }

        private void chkMothIsdead_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                dteMothDieday.Enabled = true;
            else
                dteMothDieday.Enabled = false;
        }

        private void chkMothIsMarried_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                txtMothHusbendName.Enabled = true;
            else
                txtMothHusbendName.Enabled = false;
        }

        private void chkFamIsRefugee_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                txtFamAddresCurrent.Enabled = true;
            else
                txtFamAddresCurrent.Enabled = false;
        }

        private void SetOrphanStudyVisability(bool val)
        {
            txtOSnote.Enabled = val;
            txtOSreasons.Enabled = !val;
            txtOSschoolName .Enabled = val;
            txtOSstage.Enabled = val;
            numOSdegreerate.Enabled = val;
            numOSmonthlycost .Enabled = val;
            grpOSphoto1.Enabled = val;
            grpOSphoto2.Enabled = val;
        }
        private void chkOIsStudy_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                SetOrphanStudyVisability(true);
            else
            {
                SetOrphanStudyVisability(false);
                txtOSstage.Text = "متخلف عن الدراسة";
            }
        }
        private void SetOrphanHealthVisability(bool val)
        {
            txtOHdocname.Enabled = val;
            txtOHMedicens.Enabled = val;
            txtOHName.Enabled = val;
            txtOHnote.Enabled = val;
            numOHcost.Enabled = val;
            grpOHreport.Enabled = val;
        }
        private void chkOIsSick_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                SetOrphanHealthVisability(true);
            else
                SetOrphanHealthVisability(false);
        }

        private void btnEdit_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                EditMode(this.Controls, true);
                btnAddOrphan.Enabled = true;
                btnDeleteOrphan.Enabled = true;
            }
            else
            { 
                EditMode(this.Controls, false);
                btnAddOrphan.Enabled = false;
                btnDeleteOrphan.Enabled = false ;
            }
            btnSave.Enabled = true;
            btnSaveAS.Enabled = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                OpenFile(openFileDialog1.FileName);
            }
        }
        private void OpenFile(string filename)
        {
            this.IsLoded = false;
            OrphansId.Clear();
            dicOrphans.Clear();
            FileCreation.BinaryFile Bf = new FileCreation.BinaryFile();
            FileCreation.XmlBuilder Xr = new FileCreation.XmlBuilder();
            Bf.UseCrypto = true;
            Bf.FileName = filename;
            byte[] data = Bf.ReadAllBytes();
            Xr.FromXMLBytes(data);
            SetXMLData(Xr);
            //EditMode(this.Controls, false);
            btnEdit.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
            this.FilePath = filename;
            getStatusP();
            btnEdit.Enabled = true;
            EditMode(this.Controls, false);
            btnAddOrphan.Enabled = false;
            btnDeleteOrphan.Enabled = false;
            pges.SelectedPage = pgeFAther;
            pgeView2.SelectedPage = pgeOBasic;
            this.Name = " عائلة " +  Xr.Fath_FirstName + " " + Xr.Fath_FatherName +" " + Xr.Fath_LastName;
            this.Name += " و " + Xr.Moth_FirstName + " " + Xr.Moth_FatherName + " " + Xr.Moth_LastName;
            this.IsLoded = true;
        }
        private void SaveAs()
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.FilePath = saveFileDialog1.FileName;
                    FileCreation.BinaryFile Bf = new FileCreation.BinaryFile();
                    FileCreation.XmlBuilder Xr = getXMLData();
                    Checker.CheckOrphanBasicDataControls(Xr, ref dteOBirthdate,
                            ref numOIDnumber, ref OnameForm);
                    if (!AllisOK) return;
                    Bf.UseCrypto = true;
                    Bf.FileName = this.FilePath;
                    Bf.Overwite = true;
                    Bf.Create(Xr.BuildFamily());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Save()
        {
            try
            {
                FileCreation.BinaryFile Bf = new FileCreation.BinaryFile();
                FileCreation.XmlBuilder Xr = getXMLData();
                Checker.CheckOrphanBasicDataControls(Xr, ref dteOBirthdate,
                        ref numOIDnumber, ref OnameForm);
                if (!AllisOK) return;
                SaveCurrentOrphanBonds();
                if (this.FilePath == null || this.FilePath.Length <= 5)
                {
                    SaveAs();
                    return;
                }
                Bf.UseCrypto = true;
                Bf.FileName = this.FilePath;
                Bf.Overwite = true;
                Bf.Create(Xr.BuildFamily());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetXMLData(FileCreation.XmlBuilder xml)
        {
            pges.SelectedPage = pgeFamily;
            txtFamNote.Text = xml.Fam_Note;
            cmbFamFinnicialState.Text = xml.Fam_Finncial_State;
            cmbFamResideState.Text = xml.Fam_Residence_State;
            cmbFamResType.Text = xml.Fam_Residence_Type;
            if (xml.Fam_IsRefugee)
                chkFamIsRefugee.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            else
                chkFamIsRefugee.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
            try
            {
                numFamCardNumber.Value = decimal.Parse( xml.Fam_CardNumber);
            }
            catch { }
            picFamCardPhoto1.BackgroundImage = xml.Fam_CardPhoto1;
            picFamCradPhoto2.BackgroundImage = xml.Fam_CardPhoto2;
            //Address
            FamAddressCurrent.Country = xml.Fam_Add_Country2;
            FamAddressCurrent.City = xml.Fam_Add_City2;
            FamAddressCurrent.Town = xml.Fam_Add_Town2;
            FamAddressCurrent.Street = xml.Fam_Add_Street2;
            FamAddressCurrent.WorkPhone = xml.Fam_Add_WorkPhone2;
            FamAddressCurrent.Skype = xml.Fam_Add_Twitter2;
            FamAddressCurrent.HomePhone = xml.Fam_Add_HomePhone2;
            FamAddressCurrent.Fax = xml.Fam_Add_Fax2;
            FamAddressCurrent.Facebook = xml.Fam_Add_Facebook2;
            FamAddressCurrent.Email = xml.Fam_Add_Email2;
            FamAddressCurrent.CellPhone = xml.Fam_Add_CellPhone2;     
            //Address Org
            FamAddressOrg.Country = xml.Fam_Add_Country;
            FamAddressOrg.City = xml.Fam_Add_City;
            FamAddressOrg.Town = xml.Fam_Add_Town;
            FamAddressOrg.Street = xml.Fam_Add_Street;
            FamAddressOrg.WorkPhone = xml.Fam_Add_WorkPhone;
            FamAddressOrg.Skype = xml.Fam_Add_Twitter;
            FamAddressOrg.HomePhone = xml.Fam_Add_HomePhone;
            FamAddressOrg.Fax = xml.Fam_Add_Fax;
            FamAddressOrg.Facebook = xml.Fam_Add_Facebook;
            FamAddressOrg.Email = xml.Fam_Add_Email;
            FamAddressOrg.CellPhone = xml.Fam_Add_CellPhone;   
            //
            txtFamAddresCurrent.Text = Getter.GetAddress(FamAddressCurrent);
            txtFamAddressOrg.Text = Getter.GetAddress(FamAddressOrg);
            ////////////////////////////////////
            ////////////////////////FAther
            pges.SelectedPage = pgeFAther;
            txtFathDeathreason.Text = xml.Fath_DeathResone;
            txtFathJop.Text = xml.Fath_Jop;
            txtFathNote.Text = xml.Fath_Note;
            txtFathStory.Text = xml.Fath_Story;
            picFathDeathcertificate.BackgroundImage = xml.Fath_DeathCertificate;
            picFathPhoto.BackgroundImage = xml.Fath_Photo;
            try { numFathIdnumber.Value = decimal.Parse( xml.Fath_IdentityNumber); }
            catch { }
            dteFAthBirthday.Value = xml.Fath_Birthday;
            dteFathDiedate.Value = xml.Fath_Dieday;
            //Name
            FathNameform.First = xml.Fath_FirstName;
            FathNameform.Middle = xml.Fath_FatherName;
            FathNameform.Last = xml.Fath_LastName;
            FathNameform.English_First = xml.Fath_EFirstName;
            FathNameform.English_Middle = xml.Fath_EFatherName;
            FathNameform.English_Last = xml.Fath_ELastName;
            //
            txtFathName.Text  = Getter.GetFullName(FathNameform);
            /////////////////////////////////////
            ////////////MOTHER//////////////////
            pges.SelectedPage = pgeMother;
            picMothID1.BackgroundImage = xml.Moth_IdentityPhoto1;
            picMothID2.BackgroundImage = xml.Moth_IdentityPhoto2;            
            if (xml.Moth_IsDead)
                chkMothIsdead.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            else
                chkMothIsdead.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
            if (xml.Moth_IsMarried)
                chkMothIsMarried.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            else
                chkMothIsMarried.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
            if (xml.Moth_IsOwnOrphans)
                chkMothIsownOrphans.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            else
                chkMothIsownOrphans.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
            try { numMothIdNumber.Value = decimal.Parse(xml.Moth_IdentityNumber); }
            catch { }
            try { numMothIncome.Value = (decimal)(xml.Moth_Salary); }
            catch { }
            txtMothStory.Text = xml.Moth_Story;
            txtMothNote.Text = xml.Moth_Note;
            txtMothJop.Text = xml.Moth_Jop;
            txtMothHusbendName.Text = xml.Moth_HusbendName;
            dteMothBirthday.Value = DateTime.Parse(xml.Moth_Birthday);
            dteMothDieday.Value = xml.Moth_Dieday;
            numMothIdNumber.Value = decimal.Parse( xml.Moth_IdentityNumber );
            numMothIncome.Value = (decimal)xml.Moth_Salary;
            //Name
            MothNAmeForm.First = xml.Moth_FirstName;
            MothNAmeForm.Middle = xml.Moth_FatherName;
            MothNAmeForm.Last = xml.Moth_LastName;
            MothNAmeForm.English_First = xml.Moth_EFirstName;
            MothNAmeForm.English_Middle = xml.Moth_EFatherName;
            MothNAmeForm.English_Last = xml.Moth_ELastName;
            //Address
            MothAddresForm.Country = xml.Moth_Add_Country;
            MothAddresForm.City = xml.Moth_Add_City;
            MothAddresForm.Town = xml.Moth_Add_Town;
            MothAddresForm.Street = xml.Moth_Add_Street;
            MothAddresForm.WorkPhone = xml.Moth_Add_WorkPhone;
            MothAddresForm.Skype = xml.Moth_Add_Twitter;
            MothAddresForm.HomePhone = xml.Moth_Add_HomePhone;
            MothAddresForm.Fax = xml.Moth_Add_Fax;
            MothAddresForm.Facebook = xml.Moth_Add_Facebook;
            MothAddresForm.Email = xml.Moth_Add_Email;
            MothAddresForm.CellPhone = xml.Moth_Add_CellPhone; 
            //
            txtMothAddress.Text = Getter.GetFullName(MothNAmeForm);
            txtMothName.Text = Getter.GetFullName(MothNAmeForm);
            /////////////////BondsMans
            DateTime oldest = new DateTime(1800, 1, 1);
            FileCreation.XmlBuilder.Orphan Oldorph = null;
            FileCreation.XmlBuilder.BondsMan OldBond = null;
            foreach (FileCreation.XmlBuilder.BondsMan bond in xml.BondsManS)
            {
                foreach (FileCreation.XmlBuilder.Orphan orph in bond.Orphans)
                {
                    dicOrphans.Add(orph, bond);
                    OrphansId.Add(orph);
                    if (oldest <= orph.Birthday)
                    {
                        oldest = orph.Birthday;
                        Oldorph = orph;
                        OldBond = bond;
                    }
                }
            }
            if (Oldorph != null)
            {
                SetBondsManData(OldBond);
                SetOrphanData(Oldorph);
               CurrentID = OrphansId.IndexOf(Oldorph);
            }
        }        
        private void SetBondsManData(FileCreation.XmlBuilder.BondsMan xBond)
        {
            pges.SelectedPage = pgeBondsMan;
            txtBJop.Text = xBond.Bo_Jop;
            txtBNote.Text = xBond.Bo_Note;
            try
            { numBoIncome.Value = decimal.Parse( xBond.Bo_Income); }
            catch { }
            try
            {numBIDnumber.Value = decimal.Parse(xBond.Bo_IdentityNumber);}
            catch { }
            picBID1.BackgroundImage = xBond.Bo_IdentityPhoto1;
            picBID2.BackgroundImage = xBond.Bo_IdentityPhoto2;
            //Address
            BAddressForm.Country = xBond.Bo_Add_Country;
            BAddressForm.City = xBond.Bo_Add_City;
            BAddressForm.Town = xBond.Bo_Add_Town;
            BAddressForm.Street = xBond.Bo_Add_Street;
            BAddressForm.WorkPhone = xBond.Bo_Add_WorkPhone;
            BAddressForm.Skype = xBond.Bo_Add_Twitter;
            BAddressForm.Note = xBond.Bo_Add_Note;
            BAddressForm.HomePhone = xBond.Bo_Add_HomePhone;
            BAddressForm.Fax = xBond.Bo_Add_Fax;
            BAddressForm.Facebook = xBond.Bo_Add_Facebook;
            BAddressForm.Email = xBond.Bo_Add_Email;
            BAddressForm.CellPhone = xBond.Bo_Add_CellPhone;            
            //NAme
            BNameForm.First = xBond.Bo_FirstName;
            BNameForm.Middle = xBond.Bo_FatherName;
            BNameForm.Last = xBond.Bo_LastName;
            BNameForm.English_First = xBond.Bo_EFirstName;
            BNameForm.English_Middle = xBond.Bo_EFatherName;
            BNameForm.English_Last = xBond.Bo_ELastName;
            //
            txtBName.Text = Getter.GetFullName(BNameForm);
            txtBAddress.Text = Getter.GetAddress(BAddressForm);
        }
        private void SetOrphanData(FileCreation.XmlBuilder.Orphan xOrph)
        {
            pges.SelectedPage = pgeOrphans;
            pgeView2.SelectedPage = pgeOHealth;
            if (xOrph.IsSick)
            {
                chkOIsSick.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                picOHreport.BackgroundImage = xOrph.HealthReportFile;
                txtOHdocname.Text = xOrph.HealthDoctor;
                if (xOrph.HealthMedicen != null && xOrph.HealthMedicen.Length > 0)
                {
                    txtOHMedicens.Text = xOrph.HealthMedicen.Replace(";", "+");
                    txtOHMedicens.Text += "+";
                }
                else
                {
                    txtOHMedicens.Text = "";
                }
                if (xOrph.HealthName != null && xOrph.HealthName.Length > 0)
                {
                    txtOHName.Text = xOrph.HealthName.Replace(";", "+");
                    txtOHName.Text += "+";
                }
                else
                {
                    txtOHName.Text = "";
                }
                txtOHnote.Text = xOrph.HealthNote;
                numOHcost.Value = (decimal)xOrph.HealthCost;
            }
            else
            {
                 chkOIsSick.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                 picOHreport.BackgroundImage = null;
                 txtOHdocname.Text = "";
                 txtOHMedicens.Text = "";
                 txtOHName.Text = "";
                 txtOHnote.Text = "";
                 numOHcost.Value = 0M;
            }
            pgeView2.SelectedPage = pgeOStudy;
            if (xOrph.EducationStage.Contains("متخلف") || xOrph.EducationStage.Length == 0)
            {
                chkOIsStudy.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                txtOSreasons.Text = xOrph.EducationReasons;
                picOScertificate1.BackgroundImage = null;
                picOScertificate2.BackgroundImage = null;
                txtOSnote.Text = "";
                txtOSschoolName.Text = "";
                txtOSstage.Text = "";
                numOSdegreerate.Value = 0M;
                numOSmonthlycost.Value = 0M;
            }
            else            
            {
                chkOIsStudy.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                picOScertificate1.BackgroundImage = xOrph.EducationCerPhoto1;
                picOScertificate2.BackgroundImage = xOrph.EducationCerPhoto2;
                txtOSnote.Text = xOrph.EducationNote;
                txtOSreasons.Text = xOrph.EducationReasons;
                txtOSschoolName.Text = xOrph.EducationSchool;
                txtOSstage.Text = xOrph.EducationStage;
                numOSdegreerate.Value = xOrph.EducationDegreesRate;
                numOSmonthlycost.Value = (decimal)xOrph.EducationMonthlyCost;
            }
            pgeView2.SelectedPage = pgeOothersdata;
            txtOStory.Text = xOrph.Story;
            picOBirthCert.BackgroundImage = xOrph.BirthCertificate;
            picOFamilyCardphoto.BackgroundImage = xOrph.FamilyCardPhoto;
            numOFootSize.Value = xOrph.FootSiye;
            numOTall.Value = xOrph.Tallness;
            numOWeight.Value = xOrph.Weight;
            Itenso.TimePeriod.DateDiff xx = new Itenso.TimePeriod.DateDiff(xOrph.Birthday, DateTime.Now);
            txtOAge.Text = ATDFormater.ArabicDateFormater.getFullArabicDate(xx.ElapsedYears, xx.ElapsedMonths, xx.ElapsedDays);
            numOKaid.Value = xOrph.Kaid;
            pgeView2.SelectedPage = pgeOBasic;
            picOFace.BackgroundImage = xOrph.FacePhoto;
            picOFullBody.BackgroundImage = xOrph.FullPhoto;
            dteOBirthdate.Value = xOrph.Birthday;
            try
            {
                numOIDnumber.Value = decimal.Parse(xOrph.IdentityNumber);
            }
            catch { }

            txtOBirthplace.Text = xOrph.Birthplace;
            txtOBondsmanRelation.Text = xOrph.BondManRelation;
            //Orphan Name
            OnameForm.First = xOrph.FirstName;
            OnameForm.Middle = xOrph.FatherName;
            OnameForm.Last = xOrph.LastName;
            OnameForm.English_First = xOrph.EFirstName ;
            OnameForm.English_Middle = xOrph.EFatherName;
            OnameForm.English_Last = xOrph.ELastName;
            txtOName.Text = Getter.GetFullName(OnameForm);
            //   
            cmbOSex.Text = xOrph.Gender;
        }

        private FileCreation.XmlBuilder getXMLData()
        {
            FileCreation.XmlBuilder xml = new FileCreation.XmlBuilder();
            xml.Fam_Note = txtFamNote.Text;
            xml.Fam_Finncial_State=cmbFamFinnicialState.Text;
            xml.Fam_Residence_State=cmbFamResideState.Text;
            xml.Fam_Residence_Type=cmbFamResType.Text;
            xml.Fam_IsRefugee =chkFamIsRefugee.Checked;
            try
            {
                xml.Fam_CardNumber=numFamCardNumber.Value.ToString();
            }
            catch { }
            xml.Fam_CardPhoto1 = picFamCardPhoto1.BackgroundImage;
            xml.Fam_CardPhoto2 = picFamCradPhoto2.BackgroundImage;
            //Address
            xml.Fam_Add_Country2=FamAddressCurrent.Country;
            xml.Fam_Add_City2=FamAddressCurrent.City;
            xml.Fam_Add_Town2=FamAddressCurrent.Town  ;
            xml.Fam_Add_Street2=FamAddressCurrent.Street ;
            xml.Fam_Add_WorkPhone2=FamAddressCurrent.WorkPhone;
            xml.Fam_Add_Twitter2=FamAddressCurrent.Skype;
            xml.Fam_Add_HomePhone2=FamAddressCurrent.HomePhone;
            xml.Fam_Add_Fax2=FamAddressCurrent.Fax;
            xml.Fam_Add_Facebook2=FamAddressCurrent.Facebook;
            xml.Fam_Add_Email2=FamAddressCurrent.Email;
            xml.Fam_Add_CellPhone2=FamAddressCurrent.CellPhone;
            //Address Org
            xml.Fam_Add_Country=FamAddressOrg.Country;
            xml.Fam_Add_City=FamAddressOrg.City;
            xml.Fam_Add_Town=FamAddressOrg.Town;
            xml.Fam_Add_Street=FamAddressOrg.Street;
            xml.Fam_Add_WorkPhone=FamAddressOrg.WorkPhone;
            xml.Fam_Add_Twitter=FamAddressOrg.Skype;
            xml.Fam_Add_HomePhone=FamAddressOrg.HomePhone;
            xml.Fam_Add_Fax=FamAddressOrg.Fax;
            xml.Fam_Add_Facebook=FamAddressOrg.Facebook;
            xml.Fam_Add_Email=FamAddressOrg.Email;
            xml.Fam_Add_CellPhone=FamAddressOrg.CellPhone;           
            ////////////////////////////////////
            ////////////////////////FAther
            xml.Fath_DeathResone=txtFathDeathreason.Text;
            xml.Fath_Jop=txtFathJop.Text;
            xml.Fath_Note=txtFathNote.Text;
            xml.Fath_Story=txtFathStory.Text;
            xml.Fath_DeathCertificate = picFathDeathcertificate.BackgroundImage;
            xml.Fath_Photo = picFathPhoto.BackgroundImage;
            xml.Fath_IdentityNumber = numFathIdnumber.Value.ToString();
            xml.Fath_Birthday=dteFAthBirthday.Value;
            xml.Fath_Dieday=dteFathDiedate.Value;
            //Name
            xml.Fath_FirstName=FathNameform.First;
            xml.Fath_FatherName=FathNameform.Middle;
            xml.Fath_LastName=FathNameform.Last;
            xml.Fath_EFirstName=FathNameform.English_First;
            xml.Fath_EFatherName=FathNameform.English_Middle;
            xml.Fath_ELastName=FathNameform.English_Last;
            /////////////////////////////////////
            ////////////MOTHER//////////////////
            xml.Moth_IdentityPhoto1 = picMothID1.BackgroundImage;
            xml.Moth_IdentityPhoto2 = picMothID2.BackgroundImage;
            xml.Moth_IsDead = chkMothIsdead.Checked ;
            xml.Moth_IsMarried = chkMothIsMarried.Checked ;
            xml.Moth_IsOwnOrphans = chkMothIsownOrphans.Checked ;
            xml.Moth_IdentityNumber=numMothIdNumber.Value.ToString();
            xml.Moth_Salary= (double)numMothIncome.Value;
            xml.Moth_Story=txtMothStory.Text;
            xml.Moth_Note=txtMothNote.Text;
            xml.Moth_Jop=txtMothJop.Text;
            xml.Moth_HusbendName=txtMothHusbendName.Text;
            xml.Moth_Birthday = dteMothBirthday.Value.ToString();
            xml.Moth_Dieday = dteMothDieday.Value;
            //Name
            xml.Moth_FirstName=MothNAmeForm.First;
            xml.Moth_FatherName=MothNAmeForm.Middle;
            xml.Moth_LastName=MothNAmeForm.Last;
            xml.Moth_EFirstName=MothNAmeForm.English_First;
            xml.Moth_EFatherName=MothNAmeForm.English_Middle;
            xml.Moth_ELastName=MothNAmeForm.English_Last;
            //Address
            xml.Moth_Add_Country=MothAddresForm.Country;
            xml.Moth_Add_City=MothAddresForm.City;
            xml.Moth_Add_Town=MothAddresForm.Town;
            xml.Moth_Add_Street=MothAddresForm.Street;
            xml.Moth_Add_WorkPhone=MothAddresForm.WorkPhone;
            xml.Moth_Add_Twitter=MothAddresForm.Skype;
            xml.Moth_Add_HomePhone=MothAddresForm.HomePhone;
            xml.Moth_Add_Fax=MothAddresForm.Fax;
            xml.Moth_Add_Facebook=MothAddresForm.Facebook;
            xml.Moth_Add_Email=MothAddresForm.Email;
            xml.Moth_Add_CellPhone=MothAddresForm.CellPhone;
            /////////////////BondsMans
            SaveCurrentOrphanBonds();
            Dictionary<FileCreation.XmlBuilder.BondsMan, ArrayList> dicBonds = new Dictionary<FileCreation.XmlBuilder.BondsMan, ArrayList>();
            foreach (FileCreation.XmlBuilder.Orphan orph in OrphansId)
            {
                FileCreation.XmlBuilder.BondsMan Bond = dicOrphans[orph];
                bool Equal = false ;                
                foreach (FileCreation.XmlBuilder.BondsMan bon in dicBonds.Keys  )
                {
                    if (bon.Bo_FirstName + bon.Bo_LastName == Bond.Bo_FirstName + Bond.Bo_LastName)
                    {
                        Equal = true;
                        Bond = bon;
                    }
                    else
                        Equal = false; 
                }
                if (!Equal)
                {
                    ArrayList tmp = new ArrayList();
                    tmp.Add(orph);
                    dicBonds.Add(Bond, tmp);
                }
                else 
                {
                    if (dicBonds.ContainsKey(Bond))
                    {
                        ArrayList tmp = dicBonds[Bond];
                        tmp.Add(orph);
                        dicBonds[Bond] = tmp;
                    }
                    else
                    {
                        ArrayList tmp = new ArrayList();
                        tmp.Add(orph);
                        dicBonds.Add(Bond, tmp);
                    }
                }
            }
            ArrayList arrBond = new ArrayList();
            foreach (FileCreation.XmlBuilder.BondsMan dbond in dicBonds.Keys)
            {
                ArrayList tmp = dicBonds[dbond];
                FileCreation.XmlBuilder.Orphan[] ors = (FileCreation.XmlBuilder.Orphan[])tmp.ToArray(typeof (FileCreation.XmlBuilder.Orphan) );
                dbond.Orphans = ors;
                arrBond.Add(dbond);
            }
            xml.BondsManS = (FileCreation.XmlBuilder.BondsMan[])arrBond.ToArray(typeof(FileCreation.XmlBuilder.BondsMan));
            return xml;
        }
        private FileCreation.XmlBuilder.BondsMan getBondsManData()
        {
            FileCreation.XmlBuilder.BondsMan xBond = new FileCreation.XmlBuilder.BondsMan();
            xBond.Bo_Jop=txtBJop.Text;
            xBond.Bo_Note=txtBNote.Text;            
            xBond.Bo_Income=numBoIncome.Value.ToString() ;                         
            xBond.Bo_IdentityNumber= numBIDnumber.Value.ToString();
            
            xBond.Bo_IdentityPhoto1=picBID1.BackgroundImage ;
            xBond.Bo_IdentityPhoto2=picBID2.BackgroundImage;
            //Address
            xBond.Bo_Add_Country=BAddressForm.Country;
            xBond.Bo_Add_City=BAddressForm.City;
            xBond.Bo_Add_Town=BAddressForm.Town;
            xBond.Bo_Add_Street=BAddressForm.Street;
            xBond.Bo_Add_WorkPhone=BAddressForm.WorkPhone;
            xBond.Bo_Add_Twitter=BAddressForm.Skype;
            xBond.Bo_Add_Note=BAddressForm.Note;
            xBond.Bo_Add_HomePhone=BAddressForm.HomePhone;
            xBond.Bo_Add_Fax=BAddressForm.Fax;
            xBond.Bo_Add_Facebook=BAddressForm.Facebook;
            xBond.Bo_Add_Email=BAddressForm.Email;
            xBond.Bo_Add_CellPhone=BAddressForm.CellPhone;
            //NAme
            xBond.Bo_FirstName=BNameForm.First;
            xBond.Bo_FatherName=BNameForm.Middle;
            xBond.Bo_LastName=BNameForm.Last;
            xBond.Bo_EFirstName=BNameForm.English_First;
            xBond.Bo_EFatherName=BNameForm.English_Middle;
            xBond.Bo_ELastName=BNameForm.English_Last;

            return xBond;
        }
        private FileCreation.XmlBuilder.Orphan getOrphanData( )
        {
            FileCreation.XmlBuilder.Orphan xOrph = new FileCreation.XmlBuilder.Orphan();
            xOrph.IsSick = chkOIsSick.Checked;
            if (chkOIsSick.Checked)
            {
                xOrph.HealthReportFile = picOHreport.BackgroundImage;
                xOrph.HealthDoctor = txtOHdocname.Text;
                string Medic = null;
                string Sickne = null;
                foreach (RadTokenizedTextItem itm in txtOHMedicens.Items)
                    Medic += itm.Text + ";";
                if ((Medic != null) && Medic.Length > 0)
                {
                    Medic = Medic.Substring(0, Medic.Length - 1);
                    xOrph.HealthMedicen = Medic;
                }
                foreach (RadTokenizedTextItem itm in txtOHName.Items)
                    Sickne += itm.Text + ";";
                if (Sickne != null && Sickne.Length > 0)
                {
                    Sickne = Sickne.Substring(0, Sickne.Length - 1);
                    xOrph.HealthName = Sickne;
                }
                xOrph.HealthNote = txtOHnote.Text;
                xOrph.HealthCost = (double)numOHcost.Value;
            }
            else
            {
                xOrph.HealthReportFile =null;
                xOrph.HealthDoctor = null;
                xOrph.HealthMedicen = null;
                xOrph.HealthName = null;               
                xOrph.HealthNote = "";
                xOrph.HealthCost = 0;
            }
            if (!chkOIsStudy.Checked)
            {
                xOrph.EducationReasons = txtOSreasons.Text;
                xOrph.EducationCerPhoto1 = null;
                xOrph.EducationCerPhoto2 = null;
                xOrph.EducationNote = "";
                xOrph.EducationSchool = "";
                xOrph.EducationStage = "متخلف عن الدراسة";
                xOrph.EducationDegreesRate = 0;
                xOrph.EducationMonthlyCost = 0d;
            }
            else
            {
                xOrph.EducationCerPhoto1 = picOScertificate1.BackgroundImage;
                xOrph.EducationCerPhoto2=picOScertificate2.BackgroundImage;
                xOrph.EducationNote=txtOSnote.Text;
                xOrph.EducationReasons=txtOSreasons.Text;
                xOrph.EducationSchool=txtOSschoolName.Text;
                xOrph.EducationStage=txtOSstage.Text;
                xOrph.EducationDegreesRate=(int)numOSdegreerate.Value;
                xOrph.EducationMonthlyCost=(double)numOSmonthlycost.Value;
            }
            xOrph.Story=txtOStory.Text;
            xOrph.BirthCertificate=picOBirthCert.BackgroundImage ;
            xOrph.FamilyCardPhoto=picOFamilyCardphoto.BackgroundImage;
            xOrph.FootSiye=(int)numOFootSize.Value;
            xOrph.Tallness=(int)numOTall.Value;
            xOrph.Weight=(int)numOWeight.Value;
            xOrph.Kaid=(int)numOKaid.Value;
            xOrph.FacePhoto=picOFace.BackgroundImage;
            xOrph.FullPhoto=picOFullBody.BackgroundImage;
            xOrph.Birthday = dteOBirthdate.Value;
            xOrph.IdentityNumber=numOIDnumber.Value.ToString();

            xOrph.Birthplace=txtOBirthplace.Text;
            xOrph.BondManRelation=txtOBondsmanRelation.Text;
            //Orphan Name
            xOrph.FirstName=OnameForm.First;
            xOrph.FatherName=OnameForm.Middle;
            xOrph.LastName=OnameForm.Last;
            xOrph.EFirstName=OnameForm.English_First;
            xOrph.EFatherName=OnameForm.English_Middle;
            xOrph.ELastName=OnameForm.English_Last;
            //   
            xOrph.Gender=cmbOSex.Text;
            return xOrph;
        }
       
        private void NextOrphan()
        {
            if (CurrentID >= OrphansId.Count || CurrentID <0)
            {
                CurrentID = 0;
            }
            SaveCurrentOrphanBonds();
            CurrentID++;
            if (CurrentID >= OrphansId.Count)
            {
                CurrentID = 0;
            }
            FileCreation.XmlBuilder.Orphan NextOrph;
            NextOrph = (FileCreation.XmlBuilder.Orphan)OrphansId[CurrentID];
            SetBondsManData(dicOrphans[NextOrph]);
            SetOrphanData(NextOrph);
            getStatusP();
        }
        private void getStatusP()
        {
            if (OrphansId.Count <= 0)
            {
                btnPrevOrphan.Enabled = false;
                btnNextOrph.Enabled = false;
                btnDeleteOrphan.Enabled = false;
            }
            else
            {
                btnDeleteOrphan.Enabled = true;
                if (CurrentID <= 0)
                    btnPrevOrphan.Enabled = false;
                else
                    btnPrevOrphan.Enabled = true;
                if (CurrentID == OrphansId.Count - 1)
                    btnNextOrph.Enabled = false;
                else
                    btnNextOrph.Enabled = true;
                if (CurrentID != OrphansId.Count - 1 && CurrentID != 0)
                {
                    btnNextOrph.Enabled = true;
                    btnPrevOrphan.Enabled = true;
                }
            }
            if (OrphansId.Count != 0)
                lblStatu.Text = "اليتيم رقم " + (CurrentID+1).ToString() + " من " + OrphansId.Count.ToString();
            else
                lblStatu.Text = "اليتيم رقم " + (CurrentID).ToString() + " من " + OrphansId.Count.ToString();
        }
        private void PrevOrphan()
        {
            SaveCurrentOrphanBonds();
            CurrentID--;
            if (CurrentID < 0)
            {
                CurrentID = OrphansId.Count -1;
            }
            FileCreation.XmlBuilder.Orphan NextOrph;
            NextOrph = (FileCreation.XmlBuilder.Orphan)OrphansId[CurrentID];
            SetBondsManData(dicOrphans[NextOrph]);
            SetOrphanData(NextOrph);
            getStatusP();
        }
        private void SaveCurrentOrphanBonds()
        {
            if (dicOrphans.Count > 0 && OrphansId.Count > 0)
            {
                //EditMode
                FileCreation.XmlBuilder.Orphan CurrentOrph;
                FileCreation.XmlBuilder.BondsMan CurrentBondsMan;
                dicOrphans.Remove((FileCreation.XmlBuilder.Orphan)OrphansId[CurrentID]);
                CurrentOrph = getOrphanData();
                OrphansId[CurrentID] = CurrentOrph;                
                CurrentBondsMan = getBondsManData();
                dicOrphans.Add(CurrentOrph, CurrentBondsMan);
            }
        }
        private void AddNewOrphan()
        {
            FileCreation.XmlBuilder.BondsMan bond = getBondsManData();
            FileCreation.XmlBuilder.Orphan Orp = getOrphanData();
            dicOrphans.Add(Orp, bond);
            OrphansId.Add(Orp);
            CurrentID = OrphansId.Count - 1;
            getStatusP();
        }
        private void RemoveCurrentOrphan()
        {
            if (OrphansId.Count == 1)
            {
                dicOrphans.Clear();
                OrphansId.Clear();
                CurrentID = 0;
                ClearControls(pgeOrphans.Controls);
                ClearControls(pgeBondsMan.Controls);
            }
            else if (OrphansId.Count == 0)
            { CurrentID = 0; }
            else
            {
                FileCreation.XmlBuilder.Orphan orp = (FileCreation.XmlBuilder.Orphan)OrphansId[CurrentID];
                dicOrphans.Remove(orp);
                OrphansId.RemoveAt(CurrentID);
                orp = null;
                ClearControls(pgeOrphans.Controls);
                CurrentID++;
                if (CurrentID >= OrphansId.Count)
                {
                    CurrentID = 0;
                }
                FileCreation.XmlBuilder.Orphan NextOrph;
                NextOrph = (FileCreation.XmlBuilder.Orphan)OrphansId[CurrentID];
                SetBondsManData(dicOrphans[NextOrph]);
                SetOrphanData(NextOrph);
            }
            getStatusP();
        }
        private void ClearAddressForm(ref AddressForm.AddressForm afrm)
        {
            afrm.Country = "";
            afrm.City = "";
            afrm.Town = "";
            afrm.Street ="";
            afrm.WorkPhone = "";
            afrm.Skype = "";
            afrm.Note = "";
            afrm.HomePhone = "";
            afrm.Fax = "";
            afrm.Facebook = "";
            afrm.Email = "";
            afrm.CellPhone = "";   
        }
        private void ClearNameForm(ref NameForm.NameForm nfrm)
        {
            nfrm.First = "";
            nfrm.Middle = "";
            nfrm.Last = "";
            nfrm.English_First = "";
            nfrm.English_Middle = "";
            nfrm.English_Last = "";
        }
        private void ClearControls(Control.ControlCollection conts)
        {
            if (conts == null || conts.Count == 0) return;
            foreach (Control con in conts)
            {
                if (con is AddressForm.AddressForm)
                {
                    AddressForm.AddressForm aF = (AddressForm.AddressForm)con;
                    ClearAddressForm(ref aF);
                }
                if (con is NameForm.NameForm)
                {
                    NameForm.NameForm nF = (NameForm.NameForm)con;
                    ClearNameForm(ref nF);
                }
                if (con is RadTextBox)
                {
                    RadTextBox txt = (RadTextBox)con;
                    //if (!txt.ReadOnly)
                        txt.Text = "";
                }
                if (con is RadCheckBox)
                    ((RadCheckBox)con).Checked  = false ;
                if (con is RadSpinEditor)
                    ((RadSpinEditor)con).Value = 0;
                if (con is RadAutoCompleteBox)
                    ((RadAutoCompleteBox)con).Clear();
                if (con is RadDateTimePicker)
                    ((RadDateTimePicker)con).Value  = DateTime.Now;
                if (con is RadDropDownList)
                    ((RadDropDownList)con).Text = "";
                if (con is PictureSelector.PictureSelector)
                    ((PictureSelector.PictureSelector)con).BackgroundImage  = null;
                if (con.HasChildren || con.Controls != null)
                    ClearControls (con.Controls);
            }
        }
        private void btnNextOrph_Click(object sender, EventArgs e)
        {
            NextOrphan();
        }
        private void btnPrevOrphan_Click(object sender, EventArgs e)
        {
            PrevOrphan();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnAddOrphan_Click(object sender, EventArgs e)
        {
            AddNewOrphan();
        }

        private void btnDeleteOrphan_Click(object sender, EventArgs e)
        {
            RemoveCurrentOrphan();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OrphansId.Clear();
            dicOrphans.Clear();
            ClearControls(this.Controls);
            this.FilePath = "";
            getStatusP();
            pges.SelectedPage = pgeFAther;
            pgeView2.SelectedPage = pgeOBasic;
            btnSaveAS.Enabled = true;
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.S)
                    Save();
                if (e.KeyCode == Keys.O)
                    btnOpen_Click(null, null);
                if (e.KeyCode == Keys.N)
                    btnNew_Click(null, null);
                if (e.KeyCode == Keys.E)
                {
                    if (btnEdit.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                        btnEdit.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                    else
                        btnEdit.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                }
            }
        }

        private void pges_SelectedPageChanging(object sender, RadPageViewCancelEventArgs e)
        {
            if (btnEdit.Enabled == true && btnEdit.ToggleState == Telerik.WinControls.Enumerations.ToggleState.Off)
                return;
            if (!this.IsLoded ) return;
            if (pges.SelectedPage == pgeFAther)
            {
                try
                {
                    Checker.checkFatherControls(ref dteFAthBirthday, ref dteFathDiedate,
                        ref numFathIdnumber, ref FathNameform);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AllisOK  = false;
                    e.Cancel = true;
                }
            }
            if (pges.SelectedPage == pgeMother)
            {
                try
                {
                    Checker.checkMotherControls(ref dteMothBirthday ,chkMothIsdead ,
                        ref dteFathDiedate,
                        ref numFathIdnumber, ref FathNameform);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AllisOK = false;
                    e.Cancel = true;
                }
            }
            if (pges.SelectedPage == pgeBondsMan)
            {
                try
                {
                    Checker.CheckBondsBasicControls(ref txtBName ,BNameForm.First ,BNameForm.Last,
                        ref numMothIncome  , ref numMothIdNumber );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AllisOK = false;
                    e.Cancel = true;
                }
            }
            if (pges.SelectedPage == pgeOrphans)
            {
                try
                {
                    RadPageViewPage   xx= pgeView2.SelectedPage;
                    pgeView2.SelectedPage = pgeOHealth;
                    Checker.CheckHealthDataControls(ref chkOIsSick, ref txtOHdocname,
                                            ref txtOHName);
                    pgeView2.SelectedPage = pgeOStudy;
                    Checker.CheckStudyDataControls(ref chkOIsSick, ref txtOSstage);
                    pgeView2.SelectedPage = xx;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AllisOK = false;
                    e.Cancel = true;
                }
            }
            AllisOK = true;
        }

        private void btnSaveAS_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void picFamCardPhoto1_MouseEnter(object sender, EventArgs e)
        {
            PictureSelector.PictureSelector xx = (PictureSelector.PictureSelector)sender;
            xx.Refresh();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if(this.FilePath != null && this.FilePath.Length>3)
                    OpenFile(this.FilePath);
            IsLoded = true;
        }

    }
}
