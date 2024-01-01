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
    public partial class frmProducts09 : Form
    {
        public frmProducts09()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frm08EventsAndProperties(Properties, Events); // النموذج
            pnl08001EventsAndProperties(Properties, Events);// الحاوية الرئيسية
            pnl08001001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl08001001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl08001002EventsAndProperties(Properties, Events); // الحاوية الثانية

            lbl08001002001EventsAndProperties(Properties, Events);// ملصق رقم المنتج 
            txt08001002001EventsAndProperties(Properties, Events);// مربع نص رقم المنتج
            lbl08001002002EventsAndProperties(Properties, Events);// ملصق إسم المنتج عربي 
            txt08001002002EventsAndProperties(Properties, Events);// مربع نص إسم المنتج عربي
            lbl08001002003EventsAndProperties(Properties, Events);// ملصق إسم المنتج إنجليزي 
            txt08001002003EventsAndProperties(Properties, Events);// مربع نص إسم المنتج إنجليزي
            lblManufacturersEventsAndProperties(Properties, Events);// ملصق الشركة الصانعة 
            cbx08001002001EventsAndProperties(Properties, Events);// قائمة منسدلة الشركة الصانعة
            lbl08001002004EventsAndProperties(Properties, Events);// ملصق الموديل 
            txt08001002004EventsAndProperties(Properties, Events);// مربع نص الموديل
            lbl08001002005EventsAndProperties(Properties, Events);// ملصق وصف المنتج عربي 
            txt08001002005EventsAndProperties(Properties, Events);// مربع نص وصف المنتج عربي
            lbl08001002006EventsAndProperties(Properties, Events);// ملصق وصف المنتج إنجليزي 
            txt08001002006EventsAndProperties(Properties, Events);// مربع نص وصف المنتج إنجليزي
            lblPriceCalculationMethodEventsAndProperties(Properties, Events);// ملصق أسلوب إحتساب السعر
            cbx08001002002EventsAndProperties(Properties, Events);// قائمة منسدلة أسلوب إحتساب السعر

            btn08001002001EventsAndProperties(Properties, Events); // جديد
            btn08001002002EventsAndProperties(Properties, Events); // حفظ
            btn08001002003EventsAndProperties(Properties, Events); // تعديل
            btn08001002004EventsAndProperties(Properties, Events); // حذف

            //-------- البحث
            lblSearchEventsAndProperties(Properties, Events);// ملصق البحث عن
            txtSearchEventsAndProperties(Properties, Events);// مربع نص البحث عن
            dgv08001EventsAndProperties(Properties, Events); // جدول عرض بيانات الشركات الصانعة

            //---------- التصنيف
            groupBox1EventsAndProperties(Properties, Events); // حاوية معلومات التصنيف المحفوظة
            lblCurrentCategoryNumberEventsAndProperties(Properties, Events); // ملسق رقم تصنيف المنتج
            lblCurrentCategoryEventsAndProperties(Properties, Events); // ملسق تصنيف المنتج
            txtCategoryNumberEventsAndProperties(Properties, Events);  // مربع نص رقم التصنيف
            btnSaveNewCategoryEventsAndProperties(Properties, Events); // زر حفظ التصنيف الجديد
            tvEventsAndProperties(Properties, Events); // العرض الشجري للتصنيفات

        }

        private void frm08EventsAndProperties(bool Properties, bool Events = false) // النموذج 
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

        private void pnl08001EventsAndProperties(bool Properties, bool Events = false) // الحاوية الرئيسية
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl08001);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl08001, ColorPropertyName.BackColor_3, true, true);
            }
        }

        private void pnl08001001EventsAndProperties(bool Properties, bool Events = false) // الحاوية العلوية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl08001001, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl08001001, ColorPropertyName.BackColor_2, true, true);
            }
        }

        private void lbl08001001001EventsAndProperties(bool Properties, bool Events = false) // ملصق عنوان النموذج 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "المنتجات", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "المنتجات", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void pnl08001002EventsAndProperties(bool Properties, bool Events = false) // الحاوية الثانية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl08001002);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl08001002, ColorPropertyName.BackColor_3, true, true);
            }
        }



        private void lbl08001002001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم المنتج 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم المنتج", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم المنتج", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم المنتج
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002001);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002001, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lbl08001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم المنتج عربي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "إسم المنتج عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "إسم المنتج عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002002EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم المنتج عربي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, "ar-SA");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, "ar-SA", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002002.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt08001002003.Select(); };
                };

            }
        }

        private void lbl08001002003EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم المنتج إنجليزي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "إسم المنتج إنجليزي", ColorPropertyName.BackColor_1);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "إسم المنتج إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

            }
        }

        private void txt08001002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم المنتج إنجليزي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, "en-US");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, "en-US", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002003.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { cbx08001002001.Select(); };
                };

            }
        }

        private void lblManufacturersEventsAndProperties(bool Properties, bool Events = false) // ملصق الشركة الصانعة 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblManufacturers, "الشركة الصانعة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblManufacturers, "الشركة الصانعة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void cbx08001002001EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة الشركة الصانعة
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (tblManufacturers.Rows.Count > 0)
                    {
                        cbx08001002001.DataSource = tblManufacturers;
                        cbx08001002001.ValueMember = "ManufacturerNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx08001002001.DisplayMember = "CompanyNameAr";
                        }
                        else
                        {
                            cbx08001002001.DisplayMember = "CompanyNameEn";
                        }
                        ElementsTools.ComboBox_.CustumProperties(cbx08001002001);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmProducts09 >> cbx08001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                filltblManufacturers(); // تعبئة جدول انواع طرق الاتصال

                if (tblManufacturers.Rows.Count > 0)
                {
                    try
                    {
                        if (tblManufacturers.Rows.Count > 0)
                        {
                            cbx08001002001.DataSource = tblManufacturers;
                            cbx08001002001.ValueMember = "ManufacturerNo";
                            if (GeneralVariables.cultureCode == "AR")
                            {
                                cbx08001002001.DisplayMember = "CompanyNameAr";
                            }
                            else
                            {
                                cbx08001002001.DisplayMember = "CompanyNameEn";
                            }
                            
                        }
                        ElementsTools.ComboBox_.CustumProperties(cbx08001002001, "", true, true);
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmProducts09 >> btn08001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                    ElementsTools.ComboBox_.CustumProperties(cbx08001002001, "",  true, true);

                    cbx08001002001.KeyDown += delegate (object sender, KeyEventArgs e)
                    {
                        if (e.KeyData == Keys.Enter) { txt08001002004.Select(); };
                    };
                }
            }
        }

        DataTable tblManufacturers = new DataTable(); // جدول الشركات الصانعة 

        private void filltblManufacturers()// تعبئة جدول الشركات الصانعة
        {
            try
            {
                if (tblManufacturers.Rows.Count > 0) { tblManufacturers.Rows.Clear(); }

                tblManufacturers = DataTools.DataBases.ReadTabel("select * from TblManufacturers ");

            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmProducts09 >> filltblManufacturers ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        //--------------------------********

        private void lbl08001002004EventsAndProperties(bool Properties, bool Events = false) // ملصق الموديل 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "الموديل", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "الموديل", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002004EventsAndProperties(bool Properties, bool Events = false) // مربع نص الموديل
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, "en-US");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, "en-US", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002004.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt08001002005.Select(); };
                };

            }
        }

        private void lbl08001002005EventsAndProperties(bool Properties, bool Events = false) // ملصق وصف المنتج عربي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002005, "وصف المنتج عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002005, "وصف المنتج عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002005EventsAndProperties(bool Properties, bool Events = false) // مربع نص وصف المنتج عربي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002005, "ar-SA");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002005, "ar-SA", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002005.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt08001002006.Select(); };
                };

            }
        }

        private void lbl08001002006EventsAndProperties(bool Properties, bool Events = false) // ملصق وصف المنتج إنجليزي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002006, "وصف المنتج إنجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002006, "وصف المنتج إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002006EventsAndProperties(bool Properties, bool Events = false) // مربع نص وصف المنتج إنجليزي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002006, "en-US");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002006, "en-US", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002006.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { cbx08001002002.Select(); };
                };

            }
        }

        private void lblPriceCalculationMethodEventsAndProperties(bool Properties, bool Events = false) // ملصق أسلوب إحتساب السعر 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblPriceCalculationMethod, "أسلوب إحتساب السعر", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblPriceCalculationMethod, "أسلوب إحتساب السعر", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void cbx08001002002EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة أسلوب إحتساب السعر
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Value", typeof(int));
                    dt.Columns.Add("Text", typeof(string));
                    dt.Rows.Add(new object[] { 0, Cultures.ReturnTranslation("الفئات السعرية") });
                    dt.Rows.Add(new object[] { 1, Cultures.ReturnTranslation("نسبة ربح من سعر التكلفة") });
                    cbx08001002002.DataSource = dt;
                    cbx08001002002.DisplayMember = "Text";
                    cbx08001002002.ValueMember = "Value";

                    ElementsTools.ComboBox_.CustumProperties(cbx08001002002);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmProducts09 >> cbx08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {

                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Value", typeof(int));
                    dt.Columns.Add("Text", typeof(string));
                    dt.Rows.Add(new object[] { 0, Cultures.ReturnTranslation("الفئات السعرية") });
                    dt.Rows.Add(new object[] { 1, Cultures.ReturnTranslation("نسبة ربح من سعر التكلفة") });
                    cbx08001002002.DataSource = dt;
                    cbx08001002002.DisplayMember = "Text";
                    cbx08001002002.ValueMember = "Value";

                    ElementsTools.ComboBox_.CustumProperties(cbx08001002002,"",true,true);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmProducts09 >> cbx08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx08001002002.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btn08001002002.PerformClick(); };
                };
            }
        }


        //--------------------------*******
        private void btn08001002001EventsAndProperties(bool Properties, bool Events = false) // جديد 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn08001002001, "جديد");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn08001002001, "جديد", ColorPropertyName.ForeColor_1, true, true);

                btn08001002001.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Products, PermissionType.Add))
                    {

                        if (btn08001002001.Text == Cultures.ReturnTranslation("جديد"))
                        {
                            btn08001002001.Text = Cultures.ReturnTranslation("إلغاء");
                            btn08001002002.Enabled = true;
                            btn08001002003.Enabled = false;
                            btn08001002004.Enabled = false;
                            txt08001002001.Enabled = false;
                            txt08001002002.Enabled = true;
                            txt08001002003.Enabled = true;
                            txt08001002004.Enabled = true;
                            txt08001002005.Enabled = true;
                            txt08001002006.Enabled = true;
                            cbx08001002001.Enabled = true;
                            cbx08001002002.Enabled = true;
                            dgv08001.Enabled = false;

                            txt08001002001.Text = "";
                            txt08001002002.Text = "";
                            txt08001002003.Text = "";
                            txt08001002004.Text = "";
                            txt08001002005.Text = "";
                            txt08001002006.Text = "";
                            if (cbx08001002001.Items.Count > 0) cbx08001002001.SelectedIndex = 0;
                            if (cbx08001002002.Items.Count > 0) cbx08001002002.SelectedIndex = 0;




                            txt08001002002.Focus();
                        }
                        else
                        {
                            btn08001002001.Text = Cultures.ReturnTranslation("جديد");
                            btn08001002002.Enabled = false;
                            btn08001002003.Enabled = true;
                            btn08001002004.Enabled = true;
                            txt08001002001.Enabled = false;
                            txt08001002002.Enabled = false;
                            txt08001002003.Enabled = false;
                            txt08001002004.Enabled = false;
                            txt08001002005.Enabled = false;
                            txt08001002006.Enabled = false;
                            cbx08001002001.Enabled = false;
                            cbx08001002002.Enabled = false;
                            dgv08001.Enabled = true;

                            dgv08001.Focus();
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }


                };


            }


        }

        private void btn08001002002EventsAndProperties(bool Properties, bool Events = false) // حفظ 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn08001002002, "حفظ");
            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn08001002002, "حفظ", ColorPropertyName.ForeColor_1, true, true);

                btn08001002002.Click += delegate
                {

                    try
                    {
                        if ( btn08001002001.Text == Cultures.ReturnTranslation("إلغاء") ) // إضافة
                        {
                            string Error = "";
                            if (txt08001002002.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم المنتج عربي");
                                txt08001002002.Focus();
                            }
                            else if (txt08001002003.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم المنتج إنجليزي");
                                txt08001002003.Focus();
                            }
                            else if (txt08001002004.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل موديل المنتج");
                                txt08001002004.Focus();
                            }
                            else if (txt08001002005.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بوصف المنتج عربي");
                                txt08001002005.Focus();
                            }
                            else if (txt08001002006.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بوصف المنتج إنجليزي");
                                txt08001002006.Focus();
                            }
                            else if (cbx08001002001.SelectedIndex < 0)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتحديد الشركة الصانعة");
                                cbx08001002001.Focus();
                            }
                            else if (cbx08001002002.SelectedIndex < 0)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتحديد أسلوب إحتساب السعر");
                                cbx08001002002.Focus();
                            }
                            else
                            {
                                bool? SameArabicProductName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002002.Text.Replace("'", ""), 1);
                                bool? SameEnglishProductName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002003.Text.Replace("'", ""), 2);
                                if (SameArabicProductName == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد منتج بنفس إسم المنتج العربي");
                                    txt08001002002.Focus();

                                }
                                else
                                {
                                    if (SameEnglishProductName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("يوجد منتج بنفس إسم المنتج الإنجليزي");
                                        txt08001002003.Focus();
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string[] result = null;
                                DataTools.DataBases.Run(ref result, "insert into TblProducts values (@ProductNameAR,@ProductNameEN,@ManufacturerNo,@Model,@ProductDescriptionAR,@ProductDescriptionEN,@PriceCalculationMethod);",
                                    CommandType.Text, new object[][] {
                                      new object[] { "@ProductNameAR",txt08001002002.Text.Replace("'","") }
                                    , new object[] { "@ProductNameEN", txt08001002003.Text.Replace("'", "") }
                                    , new object[] { "@ManufacturerNo", (int)cbx08001002001.SelectedValue }
                                    , new object[] { "@Model", txt08001002004.Text.Replace("'","") }
                                    , new object[] { "@ProductDescriptionAR", txt08001002005.Text.Replace("'","") }
                                    , new object[] { "@ProductDescriptionEN", txt08001002006.Text.Replace("'","") }
                                    , new object[] { "@PriceCalculationMethod", (int)cbx08001002002.SelectedValue }});



                                //-----------

                                btn08001002001.Enabled = true;
                                btn08001002002.Enabled = false;
                                btn08001002003.Enabled = true;
                                btn08001002004.Enabled = true;
                                txt08001002001.Enabled = false;
                                txt08001002002.Enabled = false;
                                txt08001002003.Enabled = false;
                                txt08001002004.Enabled = false;
                                txt08001002005.Enabled = false;
                                txt08001002006.Enabled = false;
                                cbx08001002001.Enabled = false;
                                cbx08001002002.Enabled = false;
                                dgv08001.Enabled = true;


                                // تحديث بيانات جدول البيانات
                                fillTblProducts(); // تعبئة جدول الشركات الصانعة
                                AllEventsAndProperties(true); // تم تحديث جميع الخصائص لتعود الازرار لوضعها الطبيعي

                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);

                                txt08001002001.Text = "";
                            }
                            btn08001002001.Select();
                        }
                        else if (btn08001002003.Text == Cultures.ReturnTranslation("إلغاء")) // تعديل
                        {

                            string Error = "";
                            if (txt08001002002.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم المنتج عربي");
                                txt08001002002.Focus();
                            }
                            else if (txt08001002003.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم المنتج إنجليزي");
                                txt08001002003.Focus();
                            }
                            else if (txt08001002004.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل موديل المنتج");
                                txt08001002004.Focus();
                            }
                            else if (txt08001002005.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بوصف المنتج عربي");
                                txt08001002005.Focus();
                            }
                            else if (txt08001002006.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بوصف المنتج إنجليزي");
                                txt08001002006.Focus();
                            }
                            else if (cbx08001002001.SelectedIndex < 0)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتحديد الشركة الصانعة");
                                cbx08001002001.Focus();
                            }
                            else if (cbx08001002002.SelectedIndex < 0)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتحديد أسلوب إحتساب السعر");
                                cbx08001002002.Focus();
                            }
                            else
                            {
                                bool? SameArabicProductName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002002.Text.Replace("'", ""), 1);
                                bool? SameEnglishProductName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002003.Text.Replace("'", ""), 2);
                                if (SameArabicProductName == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد منتج بنفس إسم المنتج العربي");
                                    txt08001002002.Focus();

                                }
                                else
                                {
                                    if (SameEnglishProductName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("يوجد منتج بنفس إسم المنتج الإنجليزي");
                                        txt08001002003.Focus();
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string[] result = null;
                                DataTools.DataBases.Run(ref result, @"update TblProducts set ProductNameAR = @ProductNameAR , ProductNameEN = @ProductNameEN , ManufacturerNo = @ManufacturerNo , Model = @Model , ProductDescriptionAR = @ProductDescriptionAR , ProductDescriptionEN = @ProductDescriptionEN , PriceCalculationMethod = @PriceCalculationMethod where ProductNumber = @ProductNumber",
                                    CommandType.Text, new object[][]
                                    {
                                      new object[] { "@ProductNameAR",txt08001002002.Text.Replace("'","") }
                                    , new object[] { "@ProductNameEN", txt08001002003.Text.Replace("'", "") }
                                    , new object[] { "@ManufacturerNo", cbx08001002001.SelectedValue.ToString() }
                                    , new object[] { "@Model", txt08001002004.Text.Replace("'","") }
                                    , new object[] { "@ProductDescriptionAR", txt08001002005.Text.Replace("'","") }
                                    , new object[] { "@ProductDescriptionEN", txt08001002006.Text.Replace("'","") }
                                    , new object[] { "@PriceCalculationMethod", cbx08001002002.SelectedValue.ToString() }
                                    , new object[] { "@ProductNumber", txt08001002001.Text.Replace("'","") }
                                    });



                                //-----------

                                btn08001002001.Enabled = true;
                                btn08001002002.Enabled = false;
                                btn08001002003.Enabled = true;
                                btn08001002004.Enabled = true;
                                txt08001002001.Enabled = false;
                                txt08001002002.Enabled = false;
                                txt08001002003.Enabled = false;
                                txt08001002004.Enabled = false;
                                txt08001002005.Enabled = false;
                                txt08001002006.Enabled = false;
                                cbx08001002001.Enabled = false;
                                cbx08001002002.Enabled = false;
                                dgv08001.Enabled = true;



                                dgv08001.Enabled = true;

                                // تحديث بيانات جدول البيانات
                                fillTblProducts();
                                AllEventsAndProperties(true);

                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);
                                dgv08001.Enabled = true;
                            }
                            btn08001002003.Select();
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmProducts09 >> btn08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };


            }


        }


        private void btn08001002003EventsAndProperties(bool Properties, bool Events = false) // تعديل 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn08001002003, "تعديل");

            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn08001002003, "تعديل", ColorPropertyName.ForeColor_1, true, true);
                btn08001002003.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Products, PermissionType.Edit))
                    {
                        if (btn08001002003.Enabled)
                        {
                            if (btn08001002003.Text == Cultures.ReturnTranslation("تعديل"))
                            {
                                btn08001002003.Text = Cultures.ReturnTranslation("إلغاء");

                                btn08001002001.Enabled = false;
                                btn08001002002.Enabled = true;
                                btn08001002004.Enabled = false;
                                txt08001002001.Enabled = false;
                                txt08001002002.Enabled = true;
                                txt08001002003.Enabled = true;
                                txt08001002004.Enabled = true;
                                txt08001002005.Enabled = true;
                                txt08001002006.Enabled = true;
                                cbx08001002001.Enabled = true;
                                cbx08001002002.Enabled = true;
                                dgv08001.Enabled = false;

                                txt08001002002.Focus();
                            }
                            else
                            {
                                btn08001002003.Text = Cultures.ReturnTranslation("تعديل");

                                btn08001002001.Enabled = true;
                                btn08001002002.Enabled = false;
                                btn08001002004.Enabled = true;
                                txt08001002001.Enabled = false;
                                txt08001002002.Enabled = false;
                                txt08001002003.Enabled = false;
                                txt08001002004.Enabled = false;
                                txt08001002005.Enabled = false;
                                txt08001002006.Enabled = false;
                                cbx08001002001.Enabled = false;
                                cbx08001002002.Enabled = false;
                                dgv08001.Enabled = true;

                                dgv08001.Focus();
                            }
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmProducts09 >> btn08001002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }


                };

            }
        }
        private void btn08001002004EventsAndProperties(bool Properties, bool Events = false) // حذف 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn08001002004, "حذف");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn08001002004, "حذف", ColorPropertyName.ForeColor_1, true, true);
                btn08001002004.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Products, PermissionType.Delete))
                    {
                        try
                        {
                            string[] result = null;
                            DataTools.DataBases.Run(ref result, "delete from TblProducts where ProductNumber = @ProductNumber", CommandType.Text, new object[][] { new object[] { "@ProductNumber", txt08001002001.Text.Replace("'", "") } });
                            //if(result[0] != "susses")
                            //{
                            //    MessageBox.Show(result[1]);
                            //}

                        }
                        catch (Exception ex)
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmProducts09 >> btn08001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        }

                        txt08001002001.Text = "";
                        txt08001002002.Text = "";
                        txt08001002003.Text = "";
                        txt08001002004.Text = "";
                        txt08001002005.Text = "";
                        txt08001002006.Text = "";
                        cbx08001002001.SelectedIndex = 0;
                        cbx08001002002.SelectedIndex = 0;
                        txtSearch.Text = "";

                        // تحديث بيانات جدول البيانات
                        fillTblProducts();
                        dgv08001EventsAndProperties(true);
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmProducts09 >> btn08001002004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }


                };
            }
        }




        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- الحاوية السفلية
        //private void tabControl1EventsAndProperties(bool Properties, bool Events = false) // tabcontrol  
        //{

        //    if (Properties == true && Events == false)
        //    {
        //        ElementsTools.TabControl_.CustumProperties(tabControl1, new string[] { Cultures.ReturnTranslation("البحث"), Cultures.ReturnTranslation("التصنيف"), Cultures.ReturnTranslation("الباركود") }, ColorPropertyName.BackColor_3 );
        //    }
        //    else if (Properties == true && Events == true)
        //    {
        //        ElementsTools.TabControl_.CustumProperties(tabControl1, new string[] { Cultures.ReturnTranslation("البحث"), Cultures.ReturnTranslation("التصنيف"), Cultures.ReturnTranslation("الباركود") }, ColorPropertyName.BackColor_3, ColorPropertyName.ForeColor_1, true, true);
        //    }
        //}




        //------------------ البحث
        private void lblSearchEventsAndProperties(bool Properties, bool Events = false) // ملصق البحث عن المنتجات 
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

        private void txtSearchEventsAndProperties(bool Properties, bool Events = false) // مربع نص البحث عن المنتجات
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txtSearch);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtSearch, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txtSearch.TextChanged += delegate
                {
                    try
                    {
                        DataView dv = new DataView(TblProducts);
                        string filter = "";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            filter = "ProductNameAR like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        else
                        {
                            filter = "ProductNameEN like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        dv.RowFilter = filter;
                        dgv08001.DataSource = dv;
                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmProducts09 >> txtSearchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                };
            }
        }


        private void dgv08001EventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات المنتجات
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblProducts.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblProducts;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم المنتج");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم المنتج عربي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم المنتج إنجليزي");
                        dgv08001.Columns[3].Visible = false;
                        //dgv08001.Columns[4].HeaderText = Cultures.ReturnTranslation("الموديل");
                        //dgv08001.Columns[5].HeaderText = Cultures.ReturnTranslation("وصف المنتج عربي");
                        //dgv08001.Columns[6].HeaderText = Cultures.ReturnTranslation("وصف المنتج إنجليزي");
                        dgv08001.Columns[4].Visible = false;
                        dgv08001.Columns[5].Visible = false;
                        dgv08001.Columns[6].Visible = false;
                        dgv08001.Columns[7].Visible = false;
                        dgv08001.Columns[8].Visible = false;
                        //dgv08001.Columns[9].HeaderText = Cultures.ReturnTranslation("إسم الشركة الصانعة عربي");
                        //dgv08001.Columns[10].HeaderText = Cultures.ReturnTranslation("إسم الشركة الصانعة إنجليزي");
                        dgv08001.Columns[9].Visible = false;
                        dgv08001.Columns[10].Visible = false;
                        dgv08001.Columns[11].Visible = false;

                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgv08001.Columns[1].Visible = true;
                            dgv08001.Columns[2].Visible = false;


                        }
                        else
                        {
                            dgv08001.Columns[1].Visible = false;
                            dgv08001.Columns[2].Visible = true;

                        }

                        dgv08001.Columns[0].Width = dgv08001.Width / 4;
                        dgv08001.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv08001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    else
                    {
                        if (dgv08001.Rows.Count > 0) { dgv08001.DataSource = null; dgv08001.Rows.Clear(); };
                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات

                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmProducts09 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }
                
            }
            else if (Properties == true && Events == true)
            {
                fillTblProducts(); // تعبئة جدول الشركات الصانعة

                try
                {
                    if (TblProducts.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblProducts;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم المنتج");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم المنتج عربي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم المنتج إنجليزي");
                        dgv08001.Columns[3].Visible = false;
                        //dgv08001.Columns[4].HeaderText = Cultures.ReturnTranslation("الموديل");
                        //dgv08001.Columns[5].HeaderText = Cultures.ReturnTranslation("وصف المنتج عربي");
                        //dgv08001.Columns[6].HeaderText = Cultures.ReturnTranslation("وصف المنتج إنجليزي");
                        dgv08001.Columns[4].Visible = false;
                        dgv08001.Columns[5].Visible = false;
                        dgv08001.Columns[6].Visible = false;
                        dgv08001.Columns[7].Visible = false;
                        dgv08001.Columns[8].Visible = false;
                        //dgv08001.Columns[9].HeaderText = Cultures.ReturnTranslation("إسم الشركة الصانعة عربي");
                        //dgv08001.Columns[10].HeaderText = Cultures.ReturnTranslation("إسم الشركة الصانعة إنجليزي");
                        dgv08001.Columns[9].Visible = false;
                        dgv08001.Columns[10].Visible = false;
                        dgv08001.Columns[11].Visible = false;

                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgv08001.Columns[1].Visible = true;
                            dgv08001.Columns[2].Visible = false;


                        }
                        else
                        {
                            dgv08001.Columns[1].Visible = false;
                            dgv08001.Columns[2].Visible = true;

                        }

                        dgv08001.Columns[0].Width = dgv08001.Width / 4;
                        dgv08001.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv08001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    else
                    {
                        if (dgv08001.Rows.Count > 0) { dgv08001.DataSource = null; dgv08001.Rows.Clear(); };
                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات

                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmProducts09 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


                dgv08001.SelectionChanged += delegate
                {
                    try
                    {
                        if (dgv08001.Rows.Count > 0)
                        {

                            if (dgv08001.SelectedRows.Count == 0 || dgv08001.SelectedRows == null) return;

                            txt08001002001.Text = dgv08001.SelectedRows[0].Cells[0].Value.ToString();
                            txt08001002002.Text = dgv08001.SelectedRows[0].Cells[1].Value.ToString();
                            txt08001002003.Text = dgv08001.SelectedRows[0].Cells[2].Value.ToString();
                            cbx08001002001.SelectedValue = (int)dgv08001.SelectedRows[0].Cells[3].Value;
                            txt08001002004.Text = dgv08001.SelectedRows[0].Cells[4].Value.ToString();
                            txt08001002005.Text = dgv08001.SelectedRows[0].Cells[5].Value.ToString();
                            txt08001002006.Text = dgv08001.SelectedRows[0].Cells[6].Value.ToString();
                            cbx08001002002.SelectedValue = (int)dgv08001.SelectedRows[0].Cells[7].Value;

                            // تحديث التصنيف
                            filltblCurrentProductCategory();
                            lblCurrentCategoryNumberEventsAndProperties(true);
                            lblCurrentCategoryEventsAndProperties(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmProducts09 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }
                };

                dgv08001.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                };
            }
        }




        //------------------ التصنيف
        DataTable tblCurrentProductCategory = new DataTable();// جدول تصنيفات المنتج المحدد

        private void groupBox1EventsAndProperties(bool Properties, bool Events = false) // حاوية معلومات التصنيف 
        {

            if (Properties == true && Events == false)
            {

                ElementsTools.GroupBox_.CustumProperties(groupBox1, Cultures.ReturnTranslation("التصنيف"), ColorPropertyName.BackColor_3, ColorPropertyName.ForeColor_1);
            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.GroupBox_.CustumProperties(groupBox1, Cultures.ReturnTranslation("التصنيف"), ColorPropertyName.BackColor_3, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void lblCurrentCategoryNumberEventsAndProperties(bool Properties, bool Events = false) // ملصق رقم التصنيف 
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (tblCurrentProductCategory == null) filltblCurrentProductCategory();
                    string text = "";
                    if (tblCurrentProductCategory != null)
                    {
                        if (tblCurrentProductCategory.Rows.Count > 0)
                        {
                            text = tblCurrentProductCategory.Rows[0][0].ToString();
                        }
                        ElementsTools.Lable_.CustumProperties(lblCurrentCategoryNumber, text, ColorPropertyName.BackColor_2, ColorPropertyName.ForeColor_4);

                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmProducts09 >> fillTblProducts ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    filltblCurrentProductCategory();
                    string text = "";
                    if (tblCurrentProductCategory != null)
                    {
                        if (tblCurrentProductCategory.Rows.Count > 0)
                        {
                            text = tblCurrentProductCategory.Rows[0][0].ToString();
                        }
                        ElementsTools.Lable_.CustumProperties(lblCurrentCategoryNumber, text, ColorPropertyName.BackColor_2, ColorPropertyName.ForeColor_4);

                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmProducts09 >> fillTblProducts ", DateTime.Now, ex.Message, ex.Message);
                }

            }
        }

        private void lblCurrentCategoryEventsAndProperties(bool Properties, bool Events = false) // ملصق اسم تصنيف المنتج 
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (tblCurrentProductCategory == null) filltblCurrentProductCategory();
                    string text = "";
                    if (tblCurrentProductCategory != null)
                    {
                        if (tblCurrentProductCategory.Rows.Count > 0)
                        {
                            text = GeneralVariables.cultureCode == "AR" ? tblCurrentProductCategory.Rows[0][1].ToString() : tblCurrentProductCategory.Rows[0][2].ToString();
                        }
                        ElementsTools.Lable_.CustumProperties(lblCurrentCategory, text, ColorPropertyName.BackColor_2, ColorPropertyName.ForeColor_4, true, true);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmProducts09 >> lblCurrentCategoryEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (tblCurrentProductCategory == null) filltblCurrentProductCategory();
                    string text = "";
                    if (tblCurrentProductCategory != null)
                    {
                        if (tblCurrentProductCategory.Rows.Count > 0)
                        {
                            text = GeneralVariables.cultureCode == "AR" ? tblCurrentProductCategory.Rows[0][1].ToString() : tblCurrentProductCategory.Rows[0][2].ToString();
                        }
                        ElementsTools.Lable_.CustumProperties(lblCurrentCategory, text, ColorPropertyName.BackColor_2, ColorPropertyName.ForeColor_4, true, true);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmProducts09 >> lblCurrentCategoryEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
        }


        private void txtCategoryNumberEventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم التصنيف 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txtCategoryNumber, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Int);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtCategoryNumber, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true,TextBoxType.Int);
            }
        }


        private void btnSaveNewCategoryEventsAndProperties(bool Properties, bool Events = false) // حفظ 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btnSaveNewCategory, "حفظ");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btnSaveNewCategory, "حفظ", ColorPropertyName.ForeColor_1, true, true);

                btnSaveNewCategory.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Products, PermissionType.Edit))
                        {
                            if (!string.IsNullOrEmpty(lblCurrentCategoryNumber.Text) && !string.IsNullOrEmpty(txt08001002001.Text))
                            {
                                string[] result = null;
                                DataTools.DataBases.Run(ref result, "delete from TblProductsAndCategory where CateGOryNo =  @CateGOryNo and ProductNumber = @ProductNumber ", CommandType.Text, new object[][] { new object[] { "@CateGOryNo", lblCurrentCategoryNumber.Text }, new object[] { "@ProductNumber", txt08001002001.Text } });
                            }

                            if (!string.IsNullOrEmpty(txtCategoryNumber.Text) && !string.IsNullOrEmpty(txt08001002001.Text))
                            {
                                string[] result = null;
                                DataTools.DataBases.Run(ref result, "insert into TblProductsAndCategory values (@CateGOryNo,@ProductNumber)", CommandType.Text, new object[][] { new object[] { "@CateGOryNo", txtCategoryNumber.Text }, new object[] { "@ProductNumber", txt08001002001.Text } });
                            }

                            filltblCurrentProductCategory();
                            lblCurrentCategoryNumberEventsAndProperties(true);
                            lblCurrentCategoryEventsAndProperties(true);
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmProducts09 >> btn08001002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmProducts09 >> btnSaveNewCategoryEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

            }

        }

        private void tvEventsAndProperties(bool Properties, bool Events = false) // شجرة عرض التصنيفات
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    tvCategories.Nodes.Clear();
                    ElementsTools.TreeView_.fillTreeView(tvCategories, tblCategories, "TopCategory", 4, -1, 1, 2, 0);
                    ElementsTools.TreeView_.CustumProperties(tvCategories);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmProducts09 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    filltblCategories();
                    tvCategories.Nodes.Clear();
                    ElementsTools.TreeView_.fillTreeView(tvCategories, tblCategories, "TopCategory", 4, -1, 1, 2, 0);
                    ElementsTools.TreeView_.CustumProperties(tvCategories, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmProducts09 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }



                tvCategories.AfterSelect += delegate
                {
                    try
                    {
                        // عرض البيانات بناء على النود الذي تم الضغط عليه
                        DataRow[] dr = tblCategories.Select("CategoryNo = " + tvCategories.SelectedNode.Tag);
                        txtCategoryNumber.Text = dr[0][0].ToString();
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmProducts09 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }
                };


            }
        }

        // اعادة جدول بتصنيفات المنتج
        private void filltblCurrentProductCategory()
        {
            try
            {
                if(!string.IsNullOrEmpty(txt08001002001.Text.Replace("'", "").Trim()) )
                {
                    if (tblCurrentProductCategory is null) tblCurrentProductCategory = new DataTable();
                    if (tblCurrentProductCategory.Rows.Count > 0) tblCurrentProductCategory.Rows.Clear();
                    // تم اختيار هذه الطريقة لان كمية البيانات العائدة كبير جدا وليس من الجيد الاحتفاظ بها على الرام
                    tblCurrentProductCategory = DataTools.DataBases.ReadTabel(@"select * from TblCategories inner join TblProductsAndCategory on TblCategories.CategoryNo = TblProductsAndCategory.CateGOryNo inner join TblProducts on TblProductsAndCategory.ProductNumber = TblProducts.ProductNumber where TblProducts.ProductNumber = " + txt08001002001.Text.Replace("'", ""));

                }
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmProducts09 >> filltblCurrentProductCategory ", DateTime.Now, ex.Message, ex.Message);
            }

        }

        //-----
        DataTable TblProducts = new DataTable(); // جدول المنتجات 

        private void fillTblProducts()
        {
            try
            {
                if (TblProducts.Rows.Count > 0)
                {
                    TblProducts.Rows.Clear();
                }


                TblProducts = DataTools.DataBases.ReadTabel("select * from TblProducts inner join TblManufacturers on TblProducts.ManufacturerNo=TblManufacturers.ManufacturerNo ");

            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmProducts09 >> fillTblProducts ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        //------------------------------ 

        DataTable tblCategories = new DataTable(); // جدول التصنيفات للجدول السفلي 
        private void filltblCategories()// تعبئة جدول التصنيفات
        {
            try
            {
                if (tblCategories is null) return;
                if (tblCategories.Rows.Count > 0) { tblCategories.Rows.Clear(); }

                tblCategories = DataTools.DataBases.ReadTabel("select * from TblCategories ");
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmProducts09 >> filltblCategories ", DateTime.Now, ex.Message, ex.Message);
            }
        }
    }


}

