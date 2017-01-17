using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Itenso.TimePeriod;
using Telerik.WinControls.UI;

namespace OrphansViewer
{
    class Checker
    {
        public static bool IsValidIdentityNumber(ulong _id)
        {
            if (_id > 999999999 && _id < 100000000000)
                return true;
            else
            {
                return false;
            }
        }
        public static bool CheckOrphanBasicDataControls( FileCreation.XmlBuilder xml, ref RadDateTimePicker dteBirthday, ref RadSpinEditor numIdentityNumber, ref NameForm.NameForm  txtFirstName)    
        { 
            DateDiff dte = new DateDiff(dteBirthday.Value, DateTime.Now);
        if( dte.ElapsedYears < 0 )
        {            
            dteBirthday.Focus();
            throw new Exception("يجب تحديد تاريخ سابق لايمكن تحديد تاريخ مستقبلي!");
        }
        dte = new DateDiff( DateTime.Parse( xml.Moth_Birthday) , dteBirthday.Value);
        if( dte.ElapsedYears > 55 ||  dte.ElapsedYears < 12 )
        {
            if( MessageBox.Show("قامت أمه بولادته وعمرها " + ATDFormater.ArabicDateFormater.GetArabicYear(dte.ElapsedYears) +"\n" + " فهل تريد المتابعة؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No ){
                dteBirthday.Focus();
                return false;
            }
        }
        dte = new DateDiff(xml.Fath_Dieday, dteBirthday.Value);
        if( dte.Months >= 10 )
        {
            dteBirthday.Focus();
            throw new Exception("ولد بعد وفاة والده بـ " + ATDFormater.ArabicDateFormater.getFullArabicDate(dte.ElapsedYears, dte.ElapsedMonths, dte.ElapsedDays));
        }
        if( xml.Moth_IsDead){
            if (xml.Moth_Dieday != null && xml.Moth_Dieday < dteBirthday.Value)
            {
                dteBirthday.Focus();
                throw new Exception("ولدته أمه بعد وفاتها!!!!");
            }
        }
        if( numIdentityNumber != null){
            if(! Checker.IsValidIdentityNumber((ulong)numIdentityNumber.Value) )
            {
                if( numIdentityNumber.Value != 0 )
                {
                    numIdentityNumber.Focus();
                    throw new Exception("رقم الهوية خاطئ");
                }
            }
        }
        if (txtFirstName.First == null || txtFirstName.First.Count() == 0)
        {
            txtFirstName.ShowMe() ;
            txtFirstName.Focus();
            throw new Exception("الرجاء ادخال الاسم الأول");
        }

        return true;
    }
        public static bool CheckHealthDataControls(ref RadCheckBox chkIsSick, ref RadTextBox txtDoctorName, ref RadAutoCompleteBox txtSicknessName)
        {
            if (chkIsSick.Checked)
            {
                if (txtDoctorName.Text != null && txtDoctorName.Text != "" && txtDoctorName.Text.Count() < 7)
                {
                    txtDoctorName.SelectAll();
                    txtDoctorName.Focus();
                    throw new Exception("اسم الطبيب قصير جداُ ,الرجاء إدخال الاسم كاملاً");
                }
                if (txtSicknessName.Items.Count <= 0)
                {
                    txtSicknessName.SelectAll();
                    txtSicknessName.Focus();
                    throw new Exception("يجب إدخال اسم المرض, يمكنك استخدام إشارة الجمع لإدخال امراض جديدة للبرنامج");
                }
            }
            return true;
        }
        public static bool CheckStudyDataControls(ref RadCheckBox chkIsStudy, ref RadTextBox txtStudyStage)
        {
            if (chkIsStudy.Checked)
            {
                if (txtStudyStage.Text == null || txtStudyStage.Text.Length == 0)
                {
                    txtStudyStage.SelectAll();
                    txtStudyStage.Focus();
                    throw new Exception("يجب إدخال المرحلة الدراسية لليتيم.");
                }
            }
            return true;
        }
        
        public static bool CheckBondsBasicControls(ref RadTextBox txtFullNAme, string FirstN, string LastN, ref RadSpinEditor numMonthlyIncom, ref RadSpinEditor numIdentityNum)
        {
            if (txtFullNAme.Text == null || txtFullNAme.Text.Length < 2)
            {
                txtFullNAme.SelectAll();
                txtFullNAme.Focus();
                throw new Exception("يجب إدخال اسم المعيل");
            }
            if (numMonthlyIncom.Value > 7000)
            {
                numMonthlyIncom.Focus();
                throw new Exception("يجب إدخال الدخل الشهري بالدولار!");
            }
            if (numIdentityNum != null)
            {
                if (numIdentityNum.Value != 0 && !Checker.IsValidIdentityNumber((ulong)numIdentityNum.Value))
                {
                    numIdentityNum.Focus();
                    throw new Exception("ادخل رقم البطاقة الشخصية بشكل صحيح");
                }
            }
            return true;
        }       
        public static bool checkMotherControls(ref RadDateTimePicker dteBirthday, RadCheckBox chkIsDead, ref RadDateTimePicker dteDieDay, ref RadSpinEditor numIdentity, ref NameForm.NameForm  txtNameF)
        {
            DateDiff timdeff = new DateDiff(dteBirthday.Value, DateTime.Now);
            if (chkIsDead.Checked)
            {
                timdeff = new DateDiff(dteDieDay.Value, DateTime.Now);
                if (timdeff.ElapsedYears > 18)
                {
                    dteDieDay.Focus();
                    throw new Exception("متوفية منذ أكثر من " + ATDFormater.ArabicDateFormater.GetArabicYear(timdeff.ElapsedYears));
                }
                timdeff = new DateDiff(dteBirthday.Value, dteDieDay.Value);
                if (timdeff.ElapsedYears < 13)
                {
                    dteDieDay.Focus();
                    throw new Exception("توفيت وعمرها " + ATDFormater.ArabicDateFormater.GetArabicYear(timdeff.ElapsedYears));
                }
                else
                {
                    if (timdeff.ElapsedYears < 13 || timdeff.ElapsedYears > 70)
                    {
                        dteBirthday.Focus();
                        throw new Exception("عمر الأم " + ATDFormater.ArabicDateFormater.GetArabicYear(timdeff.ElapsedYears));
                    }
                }
            }
            else
            {
                timdeff = new DateDiff(dteBirthday.Value, DateTime.Now);
                if (timdeff.ElapsedYears < 13 || timdeff.ElapsedYears > 70)
                {
                    dteBirthday.Focus();
                    throw new Exception("عمر الأم " + ATDFormater.ArabicDateFormater.GetArabicYear(timdeff.ElapsedYears));
                }
            }
            if (numIdentity != null)
            {
                if (!IsValidIdentityNumber((ulong)numIdentity.Value))
                {
                    if (numIdentity.Value > 0)
                    {
                        numIdentity.Focus();
                        throw new Exception("رقم هوية خاطئ");
                    }
                }
            }
            if (txtNameF.First.Length <= 1)
            {
                txtNameF.ShowMe();
                txtNameF.Focus();
                throw new Exception("يجب إدخال اسم الأم الأول ");
            }
            if (txtNameF.Last.Length <= 1)
            {
                txtNameF.ShowMe();
                txtNameF.Focus();
                throw new Exception("يجب إدخال نسبة الأم ");
            }
            return true;
        }
        public static bool checkFatherControls(ref RadDateTimePicker dteBirthday, ref RadDateTimePicker dteDieday, ref RadSpinEditor numIdentity, ref NameForm.NameForm  txtFirstNAme)
        {
            DateDiff timdeff = new DateDiff(dteBirthday.Value, DateTime.Now);
            if (timdeff.ElapsedYears < 13)
            {
                dteBirthday.Focus();
                throw new Exception("عمر المتوفي " + ATDFormater.ArabicDateFormater.GetArabicYear(timdeff.ElapsedYears));
            }
            timdeff = new DateDiff(dteDieday.Value, DateTime.Now);
            if (timdeff.ElapsedYears > 18)
            {
                dteDieday.Focus();
                throw new Exception("متوفي منذ أكثر من " + ATDFormater.ArabicDateFormater.GetArabicYear(timdeff.ElapsedYears));
            }
            timdeff = new DateDiff(dteBirthday.Value, dteDieday.Value);
            if (timdeff.ElapsedYears < 13)
            {
                dteDieday.Focus();
                throw new Exception("توفي وعمره " + ATDFormater.ArabicDateFormater.GetArabicYear(timdeff.ElapsedYears));
            }
            if (numIdentity != null)
            {
                if ( !IsValidIdentityNumber((ulong)numIdentity.Value))
                {
                    if (numIdentity.Value > 0)
                    {
                        numIdentity.Focus();
                        throw new Exception("رقم هوية خاطئ");
                    }
                }
            }
            if (txtFirstNAme.First.Length <= 1)
            {
                txtFirstNAme.ShowMe();
                txtFirstNAme.Focus();
                throw new Exception("يجب إدخال اسم الأب الأول ");
            }
            if (txtFirstNAme.Last.Length <= 1)
            {
                txtFirstNAme.ShowMe();
                txtFirstNAme.Focus();
                throw new Exception("يجب إدخال نسبة الأب ");
            }
            return true;
        }

    }
}
