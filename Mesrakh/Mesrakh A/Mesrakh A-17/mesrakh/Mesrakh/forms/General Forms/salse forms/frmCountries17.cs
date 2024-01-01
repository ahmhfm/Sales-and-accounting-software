using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mesrakh
{
    public partial class frmCountries17 : Form
    {
        public frmCountries17()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmEventsAndProperties(Properties, Events); // النموذج
            pnl001EventsAndProperties(Properties, Events);// الحاوية الرئيسية
            pnl001001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl001001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl001002EventsAndProperties(Properties, Events); // الحاوية الثانية

            lbl001002001EventsAndProperties(Properties, Events); // ملصق رقم الدولة
            txt001002001EventsAndProperties(Properties, Events); // مربع نص رقم الدولة
            lbl001002002EventsAndProperties(Properties, Events); // ملصق إسم الدولة عربي 
            txt001002002EventsAndProperties(Properties, Events); // مربع نص إسم الدولة عربي
            lbl001002003EventsAndProperties(Properties, Events); // ملصق إسم الدولة إنجليزي 
            txt001002003EventsAndProperties(Properties, Events); // مربع نص إسم الدولة إنجليزي
            lbl001002004EventsAndProperties(Properties, Events); // ملصق الجنسية للذكور عربي 
            txt001002004EventsAndProperties(Properties, Events); // مربع نص الجنسية للذكور عربي
            lbl001002005EventsAndProperties(Properties, Events); // ملصق الجنسية للذكور إنجليزي 
            txt001002005EventsAndProperties(Properties, Events); // مربع نص الجنسية للذكور إنجليزي
            lbl001002006EventsAndProperties(Properties, Events); // // ملصق الجنسية للاناث عربي
            txt001002006EventsAndProperties(Properties, Events); // مربع نص الجنسية للاناث عربي
            lbl001002007EventsAndProperties(Properties, Events); // ملصق الجنسية للاناث إنجليزي 
            txt001002007EventsAndProperties(Properties, Events); // مربع نص الجنسية للاناث إنجليزي
            lbl001002008EventsAndProperties(Properties, Events); // ملصق إسم العملة عربي 
            txt001002008EventsAndProperties(Properties, Events); // مربع نص إسم العملة عربي
            lbl001002009EventsAndProperties(Properties, Events); // ملصق إسم العملة إنجليزي 
            txt001002009EventsAndProperties(Properties, Events); // مربع نص إسم العملة إنجليزي
            lbl001002010EventsAndProperties(Properties, Events); // ملصق القيمة مقابل الدولار 
            txt001002010EventsAndProperties(Properties, Events); // مربع نص القيمة مقابل الدولار

            btn001002001EventsAndProperties(Properties, Events); // جديد
            btn001002002EventsAndProperties(Properties, Events); // حفظ
            btn001002003EventsAndProperties(Properties, Events); // تعديل
            btn001002004EventsAndProperties(Properties, Events); // حذف

            dgv001EventsAndProperties(Properties, Events); // جدول عرض بيانات الفروع
            //-------- البحث
            lblSearchEventsAndProperties(Properties, Events);// ملصق البحث عن
            txtSearchEventsAndProperties(Properties, Events);// مربع نص البحث عن


        }

        private void frmEventsAndProperties(bool Properties, bool Events = false) // النموذج 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Form_.CustumProperties(this);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Form_.CustumProperties(this, ColorPropertyName.BackColor_3, true, true);
            }
        }

        private void pnl001EventsAndProperties(bool Properties, bool Events = false) // الحاوية الرئيسية
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl001);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl001, ColorPropertyName.BackColor_3, true, true);
            }
        }

        private void pnl001001EventsAndProperties(bool Properties, bool Events = false) // الحاوية العلوية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl001001, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl001001, ColorPropertyName.BackColor_2, true, true);
            }
        }

        private void lbl001001001EventsAndProperties(bool Properties, bool Events = false) // ملصق عنوان النموذج 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001001001, "الدول", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001001001, "الدول", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void pnl001002EventsAndProperties(bool Properties, bool Events = false) // الحاوية الثانية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl001002);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl001002, ColorPropertyName.BackColor_3, true, true);
            }
        }


        private void lbl001002001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم الدولة
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002001, "رقم الدولة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002001, "رقم الدولة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم الدولة
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002001,"",10);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002001, "",10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }



        private void lbl001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم الدولة عربي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002002, "إسم الدولة عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002002, "إسم الدولة عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002002EventsAndProperties(bool Properties = true, bool Events = false) // مربع نص إسم الدولة عربي
        {
            string cultureInfo = "ar-sa";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002002, cultureInfo,50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002002, cultureInfo,50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt001002002.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002003.Select(); };

                };
            }
        }
        private void lbl001002003EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم الدولة إنجليزي 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002003, "إسم الدولة إنجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002003, "إسم الدولة إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم الدولة إنجليزي
        {
            string cultureInfo = "en-us";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002003, cultureInfo,50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002003, cultureInfo,50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt001002003.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002004.Select(); };
                };
            }
        }


        private void lbl001002004EventsAndProperties(bool Properties, bool Events = false) // ملصق الجنسية للذكور عربي 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002004, "الجنسية للذكور عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002004, "الجنسية للذكور عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002004EventsAndProperties(bool Properties, bool Events = false) // مربع نص الجنسية للذكور عربي
        {
            string cultureInfo = "ar-sa";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002004, cultureInfo,50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002004, cultureInfo,50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt001002004.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002005.Select(); };
                };
            }
        }

        private void lbl001002005EventsAndProperties(bool Properties, bool Events = false) // ملصق الجنسية للذكور إنجليزي 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002005, "الجنسية للذكور إنجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002005, "الجنسية للذكور إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002005EventsAndProperties(bool Properties, bool Events = false) // مربع نص الجنسية للذكور إنجليزي
        {
            string cultureInfo = "en-US";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002005, cultureInfo,50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002005, cultureInfo,50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt001002005.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002006.Select(); };
                };
            }
        }


        private void lbl001002006EventsAndProperties(bool Properties, bool Events = false) // // ملصق الجنسية للاناث عربي
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002006, "الجنسية للاناث عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002006, "الجنسية للاناث عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002006EventsAndProperties(bool Properties, bool Events = false) // مربع نص الجنسية للاناث عربي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002006,"ar-SA",50);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002006, "",50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt001002006.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002007.Select(); };
                };
            }
        }



        private void lbl001002007EventsAndProperties(bool Properties, bool Events = false) // ملصق الجنسية للاناث إنجليزي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002007, "الجنسية للاناث إنجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002007, "الجنسية للاناث إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002007EventsAndProperties(bool Properties = true, bool Events = false) // مربع نص الجنسية للاناث إنجليزي
        {
            string cultureInfo = "en-US";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002007, cultureInfo,50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002007, cultureInfo,50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt001002007.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002008.Select(); };

                };
            }
        }

        private void lbl001002008EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم العملة عربي 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002008, "إسم العملة عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002008, "إسم العملة عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002008EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم العملة عربي
        {
            string cultureInfo = "ar-SA";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002008, cultureInfo,50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002008, cultureInfo,50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt001002008.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002009.Select(); };
                };
            }
        }

        private void lbl001002009EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم العملة إنجليزي 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002009, "إسم العملة إنجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002009, "إسم العملة إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002009EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم العملة إنجليزي
        {
            string cultureInfo = "en-US";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002009, cultureInfo,50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002009, cultureInfo,50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt001002009.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002010.Select(); };
                };
            }
        }

        private void lbl001002010EventsAndProperties(bool Properties, bool Events = false) // ملصق القيمة مقابل الدولار 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002010, "القيمة مقابل الدولار", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002010, "القيمة مقابل الدولار", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002010EventsAndProperties(bool Properties, bool Events = false) // مربع نص القيمة مقابل الدولار
        {
            string cultureInfo = "";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002010, cultureInfo,10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false,TextBoxType.Decimal);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002010, cultureInfo,10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Decimal);

                txt001002010.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btn001002002.PerformClick(); };
                };
            }
        }

        //-----------
        private void btn001002001EventsAndProperties(bool Properties, bool Events = false) // جديد 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001002001, "جديد");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn001002001, "جديد", ColorPropertyName.ForeColor_1, true, true);

                btn001002001.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Countries, PermissionType.Add))
                        {

                            if (btn001002001.Text == Cultures.ReturnTranslation("جديد"))
                            {
                                btn001002001.Text = Cultures.ReturnTranslation("إلغاء");

                                txt001002001.Enabled = false;
                                txt001002002.Enabled = true;
                                txt001002003.Enabled = true;
                                txt001002004.Enabled = true;
                                txt001002005.Enabled = true;
                                txt001002006.Enabled = true;
                                txt001002007.Enabled = true;
                                txt001002008.Enabled = true;
                                txt001002009.Enabled = true;
                                txt001002010.Enabled = true;


                                txt001002001.Text = "";
                                txt001002002.Text = ""; 
                                txt001002003.Text = "";
                                txt001002004.Text = "";
                                txt001002005.Text = "";
                                txt001002006.Text = "";
                                txt001002007.Text = "";
                                txt001002008.Text = "";
                                txt001002009.Text = "";
                                txt001002010.Text = "";


                                txt001002002.Select();

                                btn001002002.Enabled = true;
                                btn001002003.Enabled = false;
                                btn001002004.Enabled = false;

                                dgv001001.Enabled = false;
                            }
                            else
                            {
                                btn001002001.Text = Cultures.ReturnTranslation("جديد");

                                txt001002001.Enabled = false;
                                txt001002002.Enabled = false;
                                txt001002003.Enabled = false;
                                txt001002004.Enabled = false;
                                txt001002005.Enabled = false;
                                txt001002006.Enabled = false;
                                txt001002007.Enabled = false;
                                txt001002008.Enabled = false;
                                txt001002009.Enabled = false;
                                txt001002010.Enabled = false;

                                btn001002002.Enabled = false;
                                btn001002003.Enabled = true;
                                btn001002004.Enabled = true;

                                dgv001001.Enabled = true;
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmCountries17 >> btn001002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmCountries17 >> btn001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                };


            }


        }

        private void btn001002002EventsAndProperties(bool Properties, bool Events = false) // حفظ 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001002002, "حفظ");
            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn001002002, "حفظ", ColorPropertyName.ForeColor_1, true, true);

                btn001002002.Click += delegate
                {
                    try
                    {

                        if (txt001002001.Text.Trim() == "")
                        {
                            string Error = "";

                            if (txt001002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتحديد نوع الفرع");
                                txt001002002.Focus();
                            }
                            else if (txt001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الدولة عربي");
                                txt001002003.Focus();
                            }

                            else if (txt001002004.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الدولة إنجليزي");
                                txt001002004.Focus();
                            }
                            else if (txt001002005.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل الجنسية للذكور عربي");
                                txt001002005.Focus();
                            }
                            else if (txt001002006.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل الجنسية للذكور إنجليزي");
                                txt001002006.Focus();
                            }
                            else if (txt001002007.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل الجنسية للاناث عربي");
                                txt001002007.Focus();
                            }

                            else if (txt001002008.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل الجنسية للاناث إنجليزي");
                                txt001002008.Focus();
                            }
                            else if (txt001002009.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم العملة عربي");
                                txt001002009.Focus();
                            }
                            else if (txt001002010.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم العملة إنجليزي");
                                txt001002010.Focus();
                            }
                            else if (txt001002010.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل قيمة العملة مقابل الدولار الأمريكي");
                                txt001002010.Focus();
                            }
                            else
                            {
                                bool? SameCountrNameAr = ElementsTools.DataGridView_.findValueThenSelected(dgv001001, ActionType.add, txt001002002.Text.Replace("'", ""), 1);
                                bool? SameCountrNameEn = ElementsTools.DataGridView_.findValueThenSelected(dgv001001, ActionType.add, txt001002003.Text.Replace("'", ""), 2);
                               
                                if (SameCountrNameAr == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد دولة بنفس الإسم العربي");
                                    txt001002002.Focus();

                                }
                                else
                                {
                                    if (SameCountrNameEn == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد دولة بنفس الإسم الإنجليزي");
                                        txt001002003.Focus();
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string[] result00 = null;
                                DataTools.DataBases.Run(ref result00, "insert into TblCountries values (@CountrNameAr , @CountrNameEn , @NationalityMaleAr , @NationalityMaleEn , @NationalityFeMaleAr , @NationalityFemaleEn , @CurrencyAr , @CurrencyEn , @CurrencyAgainstTheUSDollar )", CommandType.Text, new object[][] { 
                                    new object[] { "@CountrNameAr", txt001002002.Text },
                                    new object[] { "@CountrNameEn", txt001002003.Text },
                                    new object[] { "@NationalityMaleAr", txt001002004.Text },
                                    new object[] { "@NationalityMaleEn", txt001002005.Text },
                                    new object[] { "@NationalityFeMaleAr", txt001002006.Text },
                                    new object[] { "@NationalityFemaleEn", txt001002007.Text }, 
                                    new object[] { "@CurrencyAr", txt001002008.Text },
                                    new object[] { "@CurrencyEn", txt001002009.Text },
                                    new object[] { "@CurrencyAgainstTheUSDollar", txt001002010.Text} });


                               if(result00[1] == "succeeded")
                                {

                                    btn001002001.Text = Cultures.ReturnTranslation("جديد");

                                    txt001002001.Enabled = false;
                                    txt001002002.Enabled = false;
                                    txt001002003.Enabled = false;
                                    txt001002004.Enabled = false;
                                    txt001002005.Enabled = false;
                                    txt001002006.Enabled = false;
                                    txt001002007.Enabled = false;
                                    txt001002008.Enabled = false;
                                    txt001002009.Enabled = false;
                                    txt001002010.Enabled = false;


                                    btn001002001.Enabled = true;
                                    btn001002002.Enabled = false;
                                    btn001002003.Enabled = true;
                                    btn001002004.Enabled = true;

                                    dgv001001.Enabled = true;

                                    // تحديث بيانات جدول البيانات
                                    fillTblCountries(); // تعبئة جدول الفروع
                                    dgv001EventsAndProperties(true);

                                    //// تحديث بيانات جدول المنتجات 
                                    //if (GeneralVariables._frmProductsAndServices09 != null) GeneralVariables._frmProductsAndServices09 = null;
                                }



                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);

                                txt001002001.Text = "";
                            }
                            btn001002001.Select();
                        }
                        else
                        {

                            string Error = "";
                            if (txt001002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتحديد نوع الفرع");
                                txt001002002.Focus();
                            }
                            else if (txt001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الدولة عربي");
                                txt001002003.Focus();
                            }

                            else if (txt001002004.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الدولة إنجليزي");
                                txt001002004.Focus();
                            }
                            else if (txt001002005.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل الجنسية للذكور عربي");
                                txt001002005.Focus();
                            }
                            else if (txt001002006.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل الجنسية للذكور إنجليزي");
                                txt001002006.Focus();
                            }
                            else if (txt001002007.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل الجنسية للاناث عربي");
                                txt001002007.Focus();
                            }

                            else if (txt001002008.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل الجنسية للاناث إنجليزي");
                                txt001002008.Focus();
                            }
                            else if (txt001002009.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم العملة عربي");
                                txt001002009.Focus();
                            }
                            else if (txt001002010.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم العملة إنجليزي");
                                txt001002010.Focus();
                            }
                            else if (txt001002010.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل قيمة العملة مقابل الدولار الأمريكي");
                                txt001002010.Focus();
                            }
                            else
                            {
                                bool? SameCountrNameAr = ElementsTools.DataGridView_.findValueThenSelected(dgv001001, ActionType.edit, txt001002002.Text.Replace("'", ""), 1);
                                bool? SameCountrNameEn = ElementsTools.DataGridView_.findValueThenSelected(dgv001001, ActionType.edit, txt001002003.Text.Replace("'", ""), 2);

                                if (SameCountrNameAr == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد دولة بنفس الإسم العربي");
                                    txt001002002.Focus();

                                }
                                else
                                {
                                    if (SameCountrNameEn == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد دولة بنفس الإسم الإنجليزي");
                                        txt001002003.Focus();
                                    }
                                }
                            }



                            if (Error == "")
                            {

                                string[] result00 = null;
                                DataTools.DataBases.Run(ref result00, "update TblCountries set CountrNameAr = @CountrNameAr , CountrNameEn = @CountrNameEn , NationalityMaleAr = @NationalityMaleAr , NationalityMaleEn = @NationalityMaleEn , NationalityFeMaleAr = @NationalityFeMaleAr , NationalityFemaleEn = @NationalityFemaleEn , CurrencyAr = @CurrencyAr , CurrencyEn = @CurrencyEn , CurrencyAgainstTheUSDollar = @CurrencyAgainstTheUSDollar where CountrNo = @CountrNo", CommandType.Text, new object[][] {
                                    new object[] { "@CountrNo", txt001002001.Text },
                                    new object[] { "@CountrNameAr", txt001002002.Text },
                                    new object[] { "@CountrNameEn", txt001002003.Text },
                                    new object[] { "@NationalityMaleAr", txt001002004.Text },
                                    new object[] { "@NationalityMaleEn", txt001002005.Text },
                                    new object[] { "@NationalityFeMaleAr", txt001002006.Text },
                                    new object[] { "@NationalityFemaleEn", txt001002007.Text },
                                    new object[] { "@CurrencyAr", txt001002008.Text },
                                    new object[] { "@CurrencyEn", txt001002009.Text },
                                    new object[] { "@CurrencyAgainstTheUSDollar", txt001002010.Text} });


                                if (result00[1] == "succeeded")
                                {
                                    btn001002003.Text = Cultures.ReturnTranslation("تعديل");

                                    txt001002001.Enabled = false;
                                    txt001002002.Enabled = false;
                                    txt001002003.Enabled = false;
                                    txt001002004.Enabled = false;
                                    txt001002005.Enabled = false;
                                    txt001002006.Enabled = false;
                                    txt001002007.Enabled = false;
                                    txt001002008.Enabled = false;
                                    txt001002009.Enabled = false;
                                    txt001002010.Enabled = false;

                                    btn001002001.Enabled = true;
                                    btn001002002.Enabled = false;
                                    btn001002003.Enabled = true;
                                    btn001002004.Enabled = true;



                                    dgv001001.Enabled = true;

                                    // تحديث بيانات جدول البيانات
                                    fillTblCountries(); // تعبئة جدول الدول
                                    dgv001EventsAndProperties(true);

                                    //// تحديث بيانات الشركات الصانعة بنموذج المنتجات
                                    //if (GeneralVariables._frmProductsAndServices09 != null) GeneralVariables._frmProductsAndServices09 = null;
                                }


                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);
                                dgv001001.Enabled = true;
                            }
                            btn001002003.Select();
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmCountries17 >> btn001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                

            }


        }


        private void btn001002003EventsAndProperties(bool Properties, bool Events = false) // تعديل 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001002003, "تعديل");

            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn001002003, "تعديل", ColorPropertyName.ForeColor_1, true, true);
                btn001002003.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Countries, PermissionType.Edit))
                    {
                        if (btn001002003.Enabled)
                        {
                            if (btn001002003.Text == Cultures.ReturnTranslation("تعديل"))
                            {
                                btn001002003.Text = Cultures.ReturnTranslation("إلغاء");

                                txt001002001.Enabled = false;
                                txt001002002.Enabled = true;
                                txt001002003.Enabled = true;
                                txt001002004.Enabled = true;
                                txt001002005.Enabled = true;
                                txt001002006.Enabled = true;
                                txt001002007.Enabled = true;
                                txt001002008.Enabled = true;
                                txt001002009.Enabled = true;
                                txt001002010.Enabled = true;

                                btn001002001.Enabled = false;
                                btn001002002.Enabled = true;
                                btn001002004.Enabled = false;

                                dgv001001.Enabled = false;
                            }
                            else
                            {
                                btn001002003.Text = Cultures.ReturnTranslation("تعديل");

                                txt001002001.Enabled = false;
                                txt001002002.Enabled = false;
                                txt001002003.Enabled = false;
                                txt001002004.Enabled = false;
                                txt001002005.Enabled = false;
                                txt001002006.Enabled = false;
                                txt001002007.Enabled = false;
                                txt001002008.Enabled = false;
                                txt001002009.Enabled = false;
                                txt001002010.Enabled = false;

                                btn001002001.Enabled = true;
                                btn001002002.Enabled = false;
                                btn001002004.Enabled = true;

                                dgv001001.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmCountries17 >> btn08001002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }

                    

                };

            }
        }
        private void btn001002004EventsAndProperties(bool Properties, bool Events = false) // حذف 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001002004, "حذف");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn001002004, "حذف", ColorPropertyName.ForeColor_1, true, true);
                btn001002004.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Countries, PermissionType.Delete))
                    {
                        try
                        {

                            string[] result = null;
                            DataTools.DataBases.Run(ref result, "delete from TblCountries where CountrNo = @CountrNo", CommandType.Text, new object[][] { new object[] { "@CountrNo", txt001002001.Text } });

                            if(result[1] == "succeeded")
                            {
                                txt001002001.Text = "";
                                txt001002002.Text = "";
                                txt001002003.Text = "";
                                txt001002004.Text = "";
                                txt001002005.Text = "";
                                txt001002006.Text = "";
                                txt001002007.Text = "";
                                txt001002008.Text = "";
                                txt001002009.Text = "";
                                txt001002010.Text = "";

                                txtSearch.Text = "";

                                // تحديث بيانات جدول البيانات
                                fillTblCountries(); // تحديث جدول الدول
                                dgv001EventsAndProperties(true);
                            }

                        }
                        catch (Exception ex)
                        {
                            GeneralAction.AddNewNotification("frmCountries17 >> btn001002004EventsAndProperties ", DateTime.Now,ex.Message, ex.Message);
                        }


                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmCountries17 >> btn001002004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }


                };
            }
        }

        int SelectedRowIndex = -1; // يستخدم في تعبئة الجدول
        private void dgv001EventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات فروع الشركات
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblCountries is null)
                    {
                        fillTblCountries();
                    }
                    if (TblCountries.Rows.Count > 0)
                    {

                        dgv001001.DataSource = TblCountries;

                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgv001001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الدولة");
                            dgv001001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم الدولة عربي");
                            dgv001001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم الدولة إنجليزي");
                            dgv001001.Columns[3].HeaderText = Cultures.ReturnTranslation("الجنسية للذكور عربي");
                            dgv001001.Columns[4].HeaderText = Cultures.ReturnTranslation("الجنسية للذكور إنجليزي");
                            dgv001001.Columns[5].HeaderText = Cultures.ReturnTranslation("الجنسية للاناث عربي");
                            dgv001001.Columns[6].HeaderText = Cultures.ReturnTranslation("الجنسية للاناث إنجليزي");
                            dgv001001.Columns[7].HeaderText = Cultures.ReturnTranslation("إسم العملة عربي");
                            dgv001001.Columns[8].HeaderText = Cultures.ReturnTranslation("إسم العملة إنجليزي");
                            dgv001001.Columns[9].HeaderText = Cultures.ReturnTranslation("القيمة مقابل الدولار");

                            dgv001001.Columns[0].Visible = true;
                            dgv001001.Columns[1].Visible = true;
                            dgv001001.Columns[2].Visible = false;
                            dgv001001.Columns[3].Visible = true;
                            dgv001001.Columns[4].Visible = false;
                            dgv001001.Columns[5].Visible = true;
                            dgv001001.Columns[6].Visible = false;
                            dgv001001.Columns[7].Visible = true;
                            dgv001001.Columns[8].Visible = false;
                            dgv001001.Columns[9].Visible = true;

                            dgv001001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        else
                        {
                            dgv001001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الدولة");
                            dgv001001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم الدولة عربي");
                            dgv001001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم الدولة إنجليزي");
                            dgv001001.Columns[3].HeaderText = Cultures.ReturnTranslation("الجنسية للذكور عربي");
                            dgv001001.Columns[4].HeaderText = Cultures.ReturnTranslation("الجنسية للذكور إنجليزي");
                            dgv001001.Columns[5].HeaderText = Cultures.ReturnTranslation("الجنسية للاناث عربي");
                            dgv001001.Columns[6].HeaderText = Cultures.ReturnTranslation("الجنسية للاناث إنجليزي");
                            dgv001001.Columns[7].HeaderText = Cultures.ReturnTranslation("إسم العملة عربي");
                            dgv001001.Columns[8].HeaderText = Cultures.ReturnTranslation("إسم العملة إنجليزي");
                            dgv001001.Columns[9].HeaderText = Cultures.ReturnTranslation("القيمة مقابل الدولار");

                            dgv001001.Columns[0].Visible = true;
                            dgv001001.Columns[1].Visible = false;
                            dgv001001.Columns[2].Visible = true;
                            dgv001001.Columns[3].Visible = false;
                            dgv001001.Columns[4].Visible = true;
                            dgv001001.Columns[5].Visible = false;
                            dgv001001.Columns[6].Visible = true;
                            dgv001001.Columns[7].Visible = false;
                            dgv001001.Columns[8].Visible = true;
                            dgv001001.Columns[9].Visible = true;


                            dgv001001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }


                        ElementsTools.DataGridView_.CustumProperties(dgv001001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    else
                    {
                        if (dgv001001.Rows.Count > 0) { dgv001001.DataSource = null; dgv001001.Rows.Clear(); };
                        ElementsTools.DataGridView_.CustumProperties(dgv001001);  // تخصيص خصائص جدول عرض البيانات

                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmCountries17 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                }
            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblCountries();

                    if (TblCountries.Rows.Count > 0)
                    {

                        dgv001001.DataSource = TblCountries;




                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgv001001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الدولة");
                            dgv001001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم الدولة عربي");
                            dgv001001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم الدولة إنجليزي");
                            dgv001001.Columns[3].HeaderText = Cultures.ReturnTranslation("الجنسية للذكور عربي");
                            dgv001001.Columns[4].HeaderText = Cultures.ReturnTranslation("الجنسية للذكور إنجليزي");
                            dgv001001.Columns[5].HeaderText = Cultures.ReturnTranslation("الجنسية للاناث عربي");
                            dgv001001.Columns[6].HeaderText = Cultures.ReturnTranslation("الجنسية للاناث إنجليزي");
                            dgv001001.Columns[7].HeaderText = Cultures.ReturnTranslation("إسم العملة عربي");
                            dgv001001.Columns[8].HeaderText = Cultures.ReturnTranslation("إسم العملة إنجليزي");
                            dgv001001.Columns[9].HeaderText = Cultures.ReturnTranslation("القيمة مقابل الدولار");

                            dgv001001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الدولة");
                            dgv001001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم الدولة عربي");
                            dgv001001.Columns[2].Visible = false;
                            dgv001001.Columns[3].HeaderText = Cultures.ReturnTranslation("الجنسية للذكور عربي");
                            dgv001001.Columns[4].Visible = false;
                            dgv001001.Columns[5].HeaderText = Cultures.ReturnTranslation("الجنسية للاناث عربي");
                            dgv001001.Columns[6].Visible = false;
                            dgv001001.Columns[7].HeaderText = Cultures.ReturnTranslation("إسم العملة عربي");
                            dgv001001.Columns[8].Visible = false;
                            dgv001001.Columns[9].HeaderText = Cultures.ReturnTranslation("القيمة مقابل الدولار");

                            dgv001001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        else
                        {
                            dgv001001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الدولة");
                            dgv001001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم الدولة عربي");
                            dgv001001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم الدولة إنجليزي");
                            dgv001001.Columns[3].HeaderText = Cultures.ReturnTranslation("الجنسية للذكور عربي");
                            dgv001001.Columns[4].HeaderText = Cultures.ReturnTranslation("الجنسية للذكور إنجليزي");
                            dgv001001.Columns[5].HeaderText = Cultures.ReturnTranslation("الجنسية للاناث عربي");
                            dgv001001.Columns[6].HeaderText = Cultures.ReturnTranslation("الجنسية للاناث إنجليزي");
                            dgv001001.Columns[7].HeaderText = Cultures.ReturnTranslation("إسم العملة عربي");
                            dgv001001.Columns[8].HeaderText = Cultures.ReturnTranslation("إسم العملة إنجليزي");
                            dgv001001.Columns[9].HeaderText = Cultures.ReturnTranslation("القيمة مقابل الدولار");

                            dgv001001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الدولة");
                            dgv001001.Columns[1].Visible = false;
                            dgv001001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم الدولة إنجليزي");
                            dgv001001.Columns[3].Visible = false;
                            dgv001001.Columns[4].HeaderText = Cultures.ReturnTranslation("الجنسية للذكور إنجليزي");
                            dgv001001.Columns[5].Visible = false;
                            dgv001001.Columns[6].HeaderText = Cultures.ReturnTranslation("الجنسية للاناث إنجليزي");
                            dgv001001.Columns[7].Visible = false;
                            dgv001001.Columns[8].HeaderText = Cultures.ReturnTranslation("إسم العملة إنجليزي");
                            dgv001001.Columns[9].HeaderText = Cultures.ReturnTranslation("القيمة مقابل الدولار");


                            dgv001001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001001.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }


                        ElementsTools.DataGridView_.CustumProperties(dgv001001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    else
                    {
                        if (dgv001001.Rows.Count > 0) { dgv001001.DataSource = null; dgv001001.Rows.Clear(); };
                        ElementsTools.DataGridView_.CustumProperties(dgv001001);  // تخصيص خصائص جدول عرض البيانات

                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmCountries17 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                }


                dgv001001.SelectionChanged += delegate
                {
                    try
                    {
                        if (dgv001001.Rows.Count > 0)
                        {

                            if (dgv001001.SelectedRows.Count == 0 || dgv001001.SelectedRows == null) return;

                            txt001002001.Text = dgv001001.SelectedRows[0].Cells[0].Value.ToString();
                            txt001002002.Text = dgv001001.SelectedRows[0].Cells[1].Value.ToString();
                            txt001002003.Text = dgv001001.SelectedRows[0].Cells[2].Value.ToString();
                            txt001002004.Text = dgv001001.SelectedRows[0].Cells[3].Value.ToString();
                            txt001002005.Text = dgv001001.SelectedRows[0].Cells[4].Value.ToString();
                            txt001002006.Text = dgv001001.SelectedRows[0].Cells[5].Value.ToString();
                            txt001002007.Text = dgv001001.SelectedRows[0].Cells[6].Value.ToString();
                            txt001002008.Text = dgv001001.SelectedRows[0].Cells[7].Value.ToString();
                            txt001002009.Text = dgv001001.SelectedRows[0].Cells[8].Value.ToString();
                            txt001002010.Text = dgv001001.SelectedRows[0].Cells[9].Value.ToString();

                            SelectedRowIndex = dgv001001.SelectedRows[0].Index;


                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmCountries17 >> dgv001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                    }
                };

                dgv001001.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv001001);  // تخصيص خصائص جدول عرض البيانات

                };
            }
        }


        //------------------------------ 
        DataTable TblCountries = new DataTable(); // جدول حفظ بيانات الدول 

        //تعبئة جدول حفظ بيانات الدول  
        private void fillTblCountries()
        {
            try
            {
                if (TblCountries.Rows.Count > 0)
                {
                    TblCountries.Rows.Clear();
                }

                if (TblCountries.Rows.Count > 0) TblCountries.Rows.Clear();

                TblCountries = DataTools.DataBases.ReadTabel("select * from TblCountries ");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmCountries17 >> fillTblCountries ", DateTime.Now, ex.Message, ex.Message);
            }
        }



        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- البحث
        private void lblSearchEventsAndProperties(bool Properties, bool Events = false) // ملصق البحث عن الشركات 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblSearch, "البحث عن", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblSearch, "البحث عن", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txtSearchEventsAndProperties(bool Properties, bool Events = false) // مربع نص البحث عن الشركات
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txtSearch,"",50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtSearch, "",50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txtSearch.TextChanged += delegate
                {
                    try
                    {
                        DataView dv = new DataView(TblCountries);
                        string filter = "";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            filter = "CountrNameAr like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        else
                        {
                            filter = "CountrNameEn like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        dv.RowFilter = filter;
                        dgv001001.DataSource = dv;
                        ElementsTools.DataGridView_.CustumProperties(dgv001001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmCountries17 >> txtSearchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }


    }


}

