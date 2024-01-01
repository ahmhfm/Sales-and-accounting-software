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
    public partial class frmEnterpriseBranches16 : Form
    {
        public frmEnterpriseBranches16()
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

            lbl08001002001EventsAndProperties(Properties, Events); // ملصق رقم الفرع
            txt08001002001EventsAndProperties(Properties, Events); // مربع نص رقم الفرع
            lbl08001002002EventsAndProperties(Properties, Events); // ملصق المنشأة
            cbx08001002001EventsAndProperties(Properties, Events); // قائمة المنشأة
            lbl08001002003EventsAndProperties(Properties, Events);  // ملصق نوع الفرع
            cbx08001002002EventsAndProperties(Properties, Events);  // قائمة نوع الفرع
            lbl08001002004EventsAndProperties(Properties, Events); // ملصق إسم الفرع عربي
            txt08001002002EventsAndProperties(Properties, Events); // مربع نص إسم الفرع عربي
            lbl08001002005EventsAndProperties(Properties, Events); // ملصق إسم الفرع إنجليزي
            txt08001002003EventsAndProperties(Properties, Events); // مربع نص إسم الفرع إنجليزي
            lbl08001002006EventsAndProperties(Properties, Events); // ملصق العنوان
            txt08001002004EventsAndProperties(Properties, Events); // مربع نص العنوان
            lbl08001002007EventsAndProperties(Properties, Events); // ملصق التفصيل
            txt08001002005EventsAndProperties(Properties, Events); // مربع نص التفصيل

            btn08001002001EventsAndProperties(Properties, Events); // جديد
            btn08001002002EventsAndProperties(Properties, Events); // حفظ
            btn08001002003EventsAndProperties(Properties, Events); // تعديل
            btn08001002004EventsAndProperties(Properties, Events); // حذف

            dgv08001EventsAndProperties(Properties, Events); // جدول عرض بيانات الفروع
            //-------- البحث
            lblSearchEventsAndProperties(Properties, Events);// ملصق البحث عن
            txtSearchEventsAndProperties(Properties, Events);// مربع نص البحث عن
            //------ حقول التواصل
            lblConnectionTitelEventsAndProperties(Properties, Events); //  عنوان حقول طرق التواصل
            lblConnectionTypeEventsAndProperties(Properties, Events);
            cbxConnectionMethodsTypesEventsAndProperties(Properties, Events); //  قائمة منسدلة بأنواع طرق التواصل
            lblConnectionNoEventsAndProperties(Properties, Events);
            txtConnectionNoEventsAndProperties(Properties, Events); //  مربع نص لرقم طريقة التواصل
            lblConnectionDetailsEventsAndProperties(Properties, Events);
            txtOtherDetailsEventsAndProperties(Properties, Events); //  مربع نص تفاصيل اخرى
            btnAddConnectionNumberEventsAndProperties(Properties, Events); // زر اضافة طريقة اتصال
            btnDeleteConnectionNumberEventsAndProperties(Properties, Events); //  زر حذف طريقة اتصال
            dgvAllConnectionsNumbersEventsAndProperties(Properties, Events); // جدول عرض بيانات التواصل

            //------------- وحدات العمليات
            lblOperationUnitsEventsAndProperties(Properties, Events); // ملصق عنوان وحدات العمليات
            lblUnitNoInBranchEventsAndProperties(Properties, Events);  // ملصق  وحدات العمليات
            txtUnitNoInBranchEventsAndProperties(Properties, Events);  // مربع نص رمز وحدة العمليات في الفرع
            addUnitBranchEventsAndProperties(Properties, Events);  // زر اضافة وحدة عمليات
            btnDeleteUnitBranchEventsAndProperties(Properties, Events);  // زر حذف وحدات العمليات 
            dgvUnitBranchEventsAndProperties(Properties, Events);// جدول عرض بيانات وحدات العمليات

            //------------- الأرفف
            lblShelvesEventsAndProperties(Properties, Events); // ملصق عنوان جزءالرفوف
            lblShelfGeneralNoEventsAndProperties(Properties, Events); // ملصق الرقم المتسلسل للرف
            txtShelfGeneralNoEventsAndProperties(Properties, Events); // مربع نص الرقم المتسلسل للرف
            btnAddShelfEventsAndProperties(Properties, Events); // زر اضافة رف
            btnDeleteShelfEventsAndProperties(Properties, Events); // زر حذف رف
            dgvShelvesEventsAndProperties(Properties, Events); // جدول عرض الأرفف

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
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "فروع المنشأة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "فروع المنشأة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
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


        private void lbl08001002001EventsAndProperties(bool Properties, bool Events = false) // // ملصق رقم الفرع
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم الفرع", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم الفرع", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم الفرع
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002001,"",10);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002001, "",10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }
        //--------
        private void lbl08001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق المنشأة 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "المنشأة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "المنشأة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }
        private void cbx08001002001EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة المنشأة
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblEnterprise is null) return;
                    if (TblEnterprise.Rows.Count > 0)
                    {
                        cbx08001002001.DataSource = TblEnterprise;
                        cbx08001002001.ValueMember = "EnterpriseNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx08001002001.DisplayMember = "EnterpriseNameAR";
                        }
                        else
                        {
                            cbx08001002001.DisplayMember = "EnterpriseNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx08001002001);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> cbx08001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblEnterprise();

                    if (TblEnterprise is null) return;
                    if (TblEnterprise.Rows.Count > 0)
                    {
                        cbx08001002001.DataSource = TblEnterprise;
                        cbx08001002001.ValueMember = "EnterpriseNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx08001002001.DisplayMember = "EnterpriseNameAR";
                        }
                        else
                        {
                            cbx08001002001.DisplayMember = "EnterpriseNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx08001002001, "", true, true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> cbx001002003EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx08001002001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx08001002002.Select();
                    }
                };

                cbx08001002001.SelectedIndexChanged += delegate
                {
                    fillTblEnterpriseBranches();
                    dgv08001EventsAndProperties(true);
                };
            }
        }

        private void lbl08001002003EventsAndProperties(bool Properties, bool Events = false) // ملصق نوع الفرع 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "نوع الفرع", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "نوع الفرع", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }
        private void cbx08001002002EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة نوع الفرع
        {
            DataTable dt = new DataTable();
            if (Properties == true && Events == false)
            {
                try
                {
                    if (dt is null) { dt = new DataTable(); }
                    if(dt.Columns.Count <1)
                    {
                        dt.Columns.Add("no");
                        dt.Columns.Add("ar");
                        dt.Columns.Add("en");
                        dt.Rows.Add("1", "مستودع", "stor");
                        dt.Rows.Add("2", "معرض", "Exhibition");
                        dt.Rows.Add("3", "ورشة", "workshop");
                        dt.Rows.Add("4", "مصنع", "Factory");
                    }
                    else
                    {
                        if (dt.Rows.Count < 1)
                        {
                            dt.Rows.Add("1", "مستودع", "stor");
                            dt.Rows.Add("2", "معرض", "Exhibition");
                            dt.Rows.Add("3", "ورشة", "workshop");
                            dt.Rows.Add("4", "مصنع", "Factory");
                        }
                    }

                    cbx08001002002.DataSource = dt;
                    cbx08001002002.ValueMember = "no";
                    if (GeneralVariables.cultureCode == "AR")
                    {
                        cbx08001002002.DisplayMember = "ar";
                    }
                    else
                    {
                        cbx08001002002.DisplayMember = "en";
                    }

                    ElementsTools.ComboBox_.CustumProperties(cbx08001002002);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> cbx08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (dt is null) { dt = new DataTable(); }
                    if (dt.Columns.Count < 1)
                    {
                        dt.Columns.Add("no");
                        dt.Columns.Add("ar");
                        dt.Columns.Add("en");
                        dt.Rows.Add("1", "مستودع", "stor");
                        dt.Rows.Add("2", "معرض", "Exhibition");
                        dt.Rows.Add("3", "ورشة", "workshop");
                        dt.Rows.Add("4", "مصنع", "Factory");
                    }
                    else
                    {
                        if (dt.Rows.Count < 1)
                        {
                            dt.Rows.Add("1", "مستودع", "stor");
                            dt.Rows.Add("2", "معرض", "Exhibition");
                            dt.Rows.Add("3", "ورشة", "workshop");
                            dt.Rows.Add("4", "مصنع", "Factory");
                        }
                    }

                    cbx08001002002.DataSource = dt;
                    cbx08001002002.ValueMember = "no";
                    if (GeneralVariables.cultureCode == "AR")
                    {
                        cbx08001002002.DisplayMember = "ar";
                    }
                    else
                    {
                        cbx08001002002.DisplayMember = "en";
                    }

                    ElementsTools.ComboBox_.CustumProperties(cbx08001002002,"",true,true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> cbx08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx08001002002.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002002.Select();
                    }
                };

                //cbx08001002002.SelectedIndexChanged += delegate
                //{
                //    WritingProductName();
                //};
            }
        }
        //---------
        private void lbl08001002004EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم الفرع عربي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "إسم الفرع عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "إسم الفرع عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002002EventsAndProperties(bool Properties = true, bool Events = false) // مربع نص إسم الفرع عربي
        {
            string cultureInfo = "ar-sa";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, cultureInfo,200);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, cultureInfo,200, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002002.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt08001002003.Select(); };

                };
            }
        }
        private void lbl08001002005EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم الفرع إنجليزي 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002005, "إسم الفرع إنجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002005, "إسم الفرع إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم الفرع إنجليزي
        {
            string cultureInfo = "en-us";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, cultureInfo,200);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, cultureInfo,200, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002003.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt08001002004.Select(); };
                };
            }
        }
        //----------

        private void lbl08001002006EventsAndProperties(bool Properties, bool Events = false) // ملصق العنوان الوطني 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002006, "العنوان الوطني", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002006, "العنوان الوطني", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002004EventsAndProperties(bool Properties, bool Events = false) // مربع نص العنوان
        {
            string cultureInfo = "";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, cultureInfo,200);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, cultureInfo,200, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002004.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt08001002005.Select(); };
                };
            }
        }

        private void lbl08001002007EventsAndProperties(bool Properties, bool Events = false) // ملصق التفاصيل 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002007, "تفاصيل", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002007, "تفاصيل", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002005EventsAndProperties(bool Properties, bool Events = false) // مربع نص التفاصيل
        {
            string cultureInfo = "";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002005, cultureInfo,500);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002005, cultureInfo,500, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002005.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btn08001002002.PerformClick(); };
                };
            }
        }


        //-----------
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
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Enterprise_Branches, PermissionType.Add))
                        {

                            if (btn08001002001.Text == Cultures.ReturnTranslation("جديد"))
                            {
                                btn08001002001.Text = Cultures.ReturnTranslation("إلغاء");

                                cbx08001002001.Enabled = false;
                                cbx08001002002.Enabled = true;
                                txt08001002002.Enabled = true;
                                txt08001002003.Enabled = true;
                                txt08001002004.Enabled = true;
                                txt08001002005.Enabled = true;


                                if(cbx08001002001.Items.Count>0) cbx08001002001.SelectedIndex = 0;
                                cbx08001002002.SelectedIndex = 0;
                                txt08001002001.Text = "";
                                txt08001002002.Text = "";
                                txt08001002003.Text = "";
                                txt08001002004.Text = "";
                                txt08001002005.Text = "";


                                cbx08001002002.Focus();

                                btn08001002002.Enabled = true;
                                btn08001002003.Enabled = false;
                                btn08001002004.Enabled = false;

                                dgv08001.Enabled = false;
                            }
                            else
                            {
                                btn08001002001.Text = Cultures.ReturnTranslation("جديد");

                                cbx08001002001.Enabled = true;
                                cbx08001002002.Enabled = false;
                                txt08001002002.Enabled = false;
                                txt08001002003.Enabled = false;
                                txt08001002004.Enabled = false;
                                txt08001002005.Enabled = false;

                                btn08001002002.Enabled = false;
                                btn08001002003.Enabled = true;
                                btn08001002004.Enabled = true;

                                dgv08001.Enabled = true;
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btn08001002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btn08001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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

                        if (txt08001002001.Text.Trim() == "")
                        {
                            string Error = "";

                            if (cbx08001002001.SelectedIndex < 0)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار منشأة");
                                cbx08001002001.Focus();
                            }
                            else if (cbx08001002002.SelectedIndex < 0)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتحديد نوع الفرع");
                                cbx08001002002.Focus();
                            }
                            else if (txt08001002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الفرع عربي");
                                txt08001002002.Focus();
                            }

                            else if (txt08001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الفرع إنجليزي");
                                txt08001002003.Focus();
                            }
                            else if (txt08001002004.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل عنوان الفرع");
                                txt08001002004.Focus();
                            }
                            else
                            {
                                bool? SameBranchNameAR = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002002.Text.Replace("'", ""), 3);
                                bool? SameBranchNameEN = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002003.Text.Replace("'", ""), 4);
                               
                                if (SameBranchNameAR == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد فرع بنفس الإسم العربي");
                                    txt08001002002.Focus();

                                }
                                else
                                {
                                    if (SameBranchNameEN == true)
                                    {
                                        Error = Cultures.ReturnTranslation("يوجد فرع بنفس الإسم الإنجليزي");
                                        txt08001002003.Focus();
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string[] result = null;
                                object ConnectingMethodsOfCommunicationNO = DataTools.DataBases.Run(ref result, "SpAddNewTblConnectingMethodsOfCommunication", CommandType.StoredProcedure, new object[][] { new object[] { "@OtherDetails", "Add New TblEnterpriseBranches  >> " + DateTime.Now }, new object[] { "@ConnectingMethodsOfCommunicationNO", "OUT" } });

                                string[] result00 = null;
                                object BranchNumber = DataTools.DataBases.Run(ref result00, "spAddEnterpriseBranches", CommandType.StoredProcedure, new object[][] { 
                                    new object[] { "@EnterpriseNo", cbx08001002001.SelectedValue }, 
                                    new object[] { "@BranchTypeNo", cbx08001002002.SelectedValue },
                                    new object[] { "@BranchNameAR", txt08001002002.Text },
                                    new object[] { "@BranchNameEN", txt08001002003.Text },
                                    new object[] { "@NationalAddress", txt08001002004.Text },
                                    new object[] { "@BranchDetail", txt08001002005.Text },
                                    new object[] { "@ConnectingMethodsOfCommunicationNO", ConnectingMethodsOfCommunicationNO }, 
                                    new object[] { "@BranchNumber", "OUT" } });


                               if(result00[1] == "succeeded")
                                {

                                    cbx08001002001.Enabled = true;
                                    cbx08001002002.Enabled = false;
                                    txt08001002002.Enabled = false;
                                    txt08001002003.Enabled = false;
                                    txt08001002004.Enabled = false;
                                    txt08001002005.Enabled = false;


                                    btn08001002001.Enabled = true;
                                    btn08001002002.Enabled = false;
                                    btn08001002003.Enabled = true;
                                    btn08001002004.Enabled = true;

                                    dgv08001.Enabled = true;

                                    // تحديث بيانات جدول البيانات
                                    fillTblEnterpriseBranches(); // تعبئة جدول الفروع
                                    AllEventsAndProperties(true); // تم تحديث جميع الخصائص لتعود الازرار لوضعها الطبيعي

                                    //// تحديث بيانات جدول المنتجات 
                                    //if (GeneralVariables._frmProductsAndServices09 != null) GeneralVariables._frmProductsAndServices09 = null;
                                }



                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);

                                txt08001002001.Text = "";
                            }
                            btn08001002001.Select();
                        }
                        else
                        {

                            string Error = "";
                            if (cbx08001002001.SelectedIndex < 0)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار منشأة");
                                cbx08001002001.Focus();
                            }
                            else if (cbx08001002002.SelectedIndex < 0)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتحديد نوع الفرع");
                                cbx08001002002.Focus();
                            }
                            else if (txt08001002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الفرع عربي");
                                txt08001002002.Focus();
                            }

                            else if (txt08001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الفرع إنجليزي");
                                txt08001002003.Focus();
                            }
                            else if (txt08001002004.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل عنوان الفرع");
                                txt08001002004.Focus();
                            }
                            else
                            {
                                bool? SameBranchNameAR = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002002.Text.Replace("'", ""), 3);
                                bool? SameBranchNameEN = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002003.Text.Replace("'", ""), 4);

                                if (SameBranchNameAR == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد فرع بنفس الإسم العربي");
                                    txt08001002002.Focus();

                                }
                                else
                                {
                                    if (SameBranchNameEN == true)
                                    {
                                        Error = Cultures.ReturnTranslation("يوجد فرع بنفس الإسم الإنجليزي");
                                        txt08001002003.Focus();
                                    }
                                }
                            }



                            if (Error == "")
                            {

                                string[] result00 = null;
                                object result2 = DataTools.DataBases.Run(ref result00, "update TblEnterpriseBranches set BranchTypeNo = @BranchTypeNo,BranchNameAR = @BranchNameAR ,BranchNameEN = @BranchNameEN ,NationalAddress = @NationalAddress ,BranchDetail = @BranchDetail where BranchNumber = @BranchNumber ", CommandType.Text, new object[][] {
                                    new object[] { "@BranchNumber", txt08001002001.Text},
                                    new object[] { "@EnterpriseNo", cbx08001002001.SelectedValue },
                                    new object[] { "@BranchTypeNo", cbx08001002002.SelectedValue },
                                    new object[] { "@BranchNameAR", txt08001002002.Text },
                                    new object[] { "@BranchNameEN", txt08001002003.Text },
                                    new object[] { "@NationalAddress", txt08001002004.Text },
                                    new object[] { "@BranchDetail", txt08001002005.Text } });
                                //MessageBox.Show(result[0]+"  "+result[1]);

                                if (result00[1] == "succeeded")
                                {
                                    cbx08001002001.Enabled = true;
                                    cbx08001002002.Enabled = false;
                                    txt08001002002.Enabled = false;
                                    txt08001002003.Enabled = false;
                                    txt08001002004.Enabled = false;
                                    txt08001002005.Enabled = false;

                                    btn08001002001.Enabled = true;
                                    btn08001002002.Enabled = false;
                                    btn08001002003.Enabled = true;
                                    btn08001002004.Enabled = true;



                                    dgv08001.Enabled = true;

                                    // تحديث بيانات جدول البيانات
                                    fillTblEnterpriseBranches(); // تعبئة جدول الفروع
                                    AllEventsAndProperties(true);

                                    //// تحديث بيانات الشركات الصانعة بنموذج المنتجات
                                    //if (GeneralVariables._frmProductsAndServices09 != null) GeneralVariables._frmProductsAndServices09 = null;
                                }


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
                        GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btn08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    if (Permissions.AccountHavePermission(PermissionObjectes.Enterprise_Branches, PermissionType.Edit))
                    {
                        if (btn08001002003.Enabled)
                        {
                            if (btn08001002003.Text == Cultures.ReturnTranslation("تعديل"))
                            {
                                btn08001002003.Text = Cultures.ReturnTranslation("إلغاء");

                                cbx08001002001.Enabled = false;
                                cbx08001002002.Enabled = true;
                                txt08001002002.Enabled = true;
                                txt08001002003.Enabled = true;
                                txt08001002004.Enabled = true;
                                txt08001002005.Enabled = true;

                                btn08001002001.Enabled = false;
                                btn08001002002.Enabled = true;
                                btn08001002004.Enabled = false;

                                dgv08001.Enabled = false;
                            }
                            else
                            {
                                btn08001002003.Text = Cultures.ReturnTranslation("تعديل");

                                cbx08001002001.Enabled = true;
                                cbx08001002002.Enabled = false;
                                txt08001002002.Enabled = false;
                                txt08001002003.Enabled = false;
                                txt08001002004.Enabled = false;
                                txt08001002005.Enabled = false;

                                btn08001002001.Enabled = true;
                                btn08001002002.Enabled = false;
                                btn08001002004.Enabled = true;

                                dgv08001.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btn08001002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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
                    if (Permissions.AccountHavePermission(PermissionObjectes.Enterprise_Branches, PermissionType.Delete))
                    {
                        try
                        {

                            string[] result = null;
                            DataTools.DataBases.Run(ref result, "delete from TblEnterpriseBranches where BranchNumber = @BranchNumber", CommandType.Text, new object[][] { new object[] { "@BranchNumber", txt08001002001.Text } });

                            if(result[1] == "succeeded")
                            {
                                cbx08001002001.SelectedIndex = -1;
                                cbx08001002002.SelectedIndex = -1;
                                txt08001002001.Text = "";
                                txt08001002002.Text = "";
                                txt08001002003.Text = "";
                                txt08001002004.Text = "";
                                txt08001002005.Text = "";

                                txtSearch.Text = "";

                                // تحديث بيانات جدول البيانات
                                fillTblEnterpriseBranches(); // تحديث جدول فروع المنشآت
                                dgv08001EventsAndProperties(true);
                            }

                        }
                        catch (Exception ex)
                        {
                            GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btn08001002004EventsAndProperties ", DateTime.Now,ex.Message, ex.Message);
                        }


                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btn08001002004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }


                };
            }
        }

        int SelectedRowIndex = -1; // يستخدم في تعبئة الجدول

        private void dgv08001EventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات فروع الشركات
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblEnterpriseBranches is null)
                    {
                        fillTblEnterpriseBranches();
                    }
                    
                    if(TblEnterpriseBranches != null)
                    {
                        if (TblEnterpriseBranches.Rows.Count > 0)
                        {

                            dgv08001.DataSource = TblEnterpriseBranches;

                            dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الفرع");
                            dgv08001.Columns[1].Visible = false;
                            dgv08001.Columns[2].Visible = false;
                            dgv08001.Columns[3].HeaderText = Cultures.ReturnTranslation("إسم الفرع عربي");
                            dgv08001.Columns[4].HeaderText = Cultures.ReturnTranslation("إسم الفرع إنجليزي");
                            dgv08001.Columns[5].Visible = false;
                            dgv08001.Columns[6].Visible = false;
                            dgv08001.Columns[7].Visible = false;

                            dgv08001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dgv08001.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv08001.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                            if (GeneralVariables.cultureCode == "AR")
                            {
                                dgv08001.Columns[3].Visible = true;
                                dgv08001.Columns[4].Visible = false;
                            }
                            else
                            {
                                dgv08001.Columns[3].Visible = false;
                                dgv08001.Columns[4].Visible = true;
                            }


                            ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                        }
                        else
                        {
                            if (dgv08001.Rows.Count > 0) { dgv08001.DataSource = null; dgv08001.Rows.Clear(); };
                            ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات

                        }
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                }
            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblEnterpriseBranches(); // تعبئة جدول فروع المنشآت

                    if(TblEnterpriseBranches != null)
                    {
                        if (TblEnterpriseBranches.Rows.Count > 0)
                        {

                            dgv08001.DataSource = TblEnterpriseBranches;

                            dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الفرع");
                            dgv08001.Columns[1].Visible = false;
                            dgv08001.Columns[2].Visible = false;
                            dgv08001.Columns[3].HeaderText = Cultures.ReturnTranslation("إسم الفرع عربي");
                            dgv08001.Columns[4].HeaderText = Cultures.ReturnTranslation("إسم الفرع إنجليزي");
                            dgv08001.Columns[5].Visible = false;
                            dgv08001.Columns[6].Visible = false;
                            dgv08001.Columns[7].Visible = false;

                            dgv08001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dgv08001.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv08001.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                            if (GeneralVariables.cultureCode == "AR")
                            {
                                dgv08001.Columns[3].Visible = true;
                                dgv08001.Columns[4].Visible = false;
                            }
                            else
                            {
                                dgv08001.Columns[3].Visible = false;
                                dgv08001.Columns[4].Visible = true;
                            }


                            ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                        }
                        else
                        {
                            if (dgv08001.Rows.Count > 0) { dgv08001.DataSource = null; dgv08001.Rows.Clear(); };
                            ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات

                        }
                    }

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                }


                dgv08001.SelectionChanged += delegate
                {
                    try
                    {
                        if (dgv08001.Rows.Count > 0)
                        {

                            if (dgv08001.SelectedRows.Count == 0 || dgv08001.SelectedRows == null) return;

                            txt08001002001.Text = dgv08001.SelectedRows[0].Cells[0].Value.ToString();
                            cbx08001002001.SelectedValue = dgv08001.SelectedRows[0].Cells[1].Value;
                            cbx08001002002.SelectedValue = dgv08001.SelectedRows[0].Cells[2].Value;
                            txt08001002002.Text = dgv08001.SelectedRows[0].Cells[3].Value.ToString();
                            txt08001002003.Text = dgv08001.SelectedRows[0].Cells[4].Value.ToString();
                            txt08001002004.Text = dgv08001.SelectedRows[0].Cells[5].Value.ToString();
                            txt08001002005.Text = dgv08001.SelectedRows[0].Cells[6].Value.ToString();

                            SelectedRowIndex = dgv08001.SelectedRows[0].Index;

                            txtConnectionNo.Text = "";
                            txtOtherDetails.Text = "";
                            cbxConnectionMethodsTypes.SelectedIndex = -1;

                            fillTblMethodsOfCommunication(); // تعبئة جدول طرق الاتصال حسب السجل الجديد
                            dgvAllConnectionsNumbersEventsAndProperties(true); // خصائص جدول عرض بيانات طرق الاتصال

                            fillTblOperationUnits(); // تعبئة جدول بيانات وحدات العمليات
                            dgvUnitBranchEventsAndProperties(true); // تحديث جدول عرض وحدات العمليات


                            fillTblShelves();// تحديث جدول حفظ بيانات الارفف
                            dgvShelvesEventsAndProperties(true); // تحديث جدول عرض بيانات الارفف
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                    }
                };

                dgv08001.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات

                };
            }
        }


        //------------------------------ 
        DataTable TblEnterprise = new DataTable(); // بيانات المنشآت
        DataTable TblEnterpriseBranches = new DataTable(); // بيانات الفروع

        // بيانات المنشآت
        private void fillTblEnterprise()
        {
            try
            {
                if (TblEnterprise.Rows.Count > 0)
                {
                    TblEnterprise.Rows.Clear();
                }

                if (TblEnterprise.Rows.Count > 0) TblEnterprise.Rows.Clear();

                TblEnterprise = DataTools.DataBases.ReadTabel("select * from TblEnterprise ");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> fillTblEnterprise ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        // بيانات الفروع
        private void fillTblEnterpriseBranches()
        {
            try
            {
                if (TblEnterpriseBranches is null) TblEnterpriseBranches = new DataTable();

                if (TblEnterpriseBranches.Rows.Count > 0)
                {
                    TblEnterpriseBranches.Rows.Clear();
                }

                if (TblEnterpriseBranches.Rows.Count > 0) TblEnterpriseBranches.Rows.Clear();
                TblEnterpriseBranches = DataTools.DataBases.ReadTabel("select * from TblEnterpriseBranches where EnterpriseNo = " + cbx08001002001.SelectedValue);


            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> fillTblEnterpriseBranches ", DateTime.Now, ex.Message, ex.Message);
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
                        DataView dv = new DataView(TblEnterpriseBranches);
                        string filter = "";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            filter = "BranchNameAR like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        else
                        {
                            filter = "BranchNameEN like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        dv.RowFilter = filter;
                        dgv08001.DataSource = dv;
                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> txtSearchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- طرق الاتصال الاتصال



        private void lblConnectionTitelEventsAndProperties(bool Properties, bool Events = false) // عنوان حقول طرق التواصل
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionTitel, "وسائل التواصل", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionTitel, "وسائل التواصل", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lblConnectionTypeEventsAndProperties(bool Properties, bool Events = false) // ملصق نوع طريقة الاتصال 
        {

            // الخصائص
            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionType, "طريقة الإتصال", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionType, "طريقة الإتصال", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }
        private void cbxConnectionMethodsTypesEventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة بأنواع طرق التواصل
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (tblConnectionMethodsTypes.Rows.Count > 0)
                    {
                        cbxConnectionMethodsTypes.DataSource = tblConnectionMethodsTypes;
                        cbxConnectionMethodsTypes.ValueMember = "ContactMethodsTypeNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbxConnectionMethodsTypes.DisplayMember = "ContactMethodsTypeNoNameAR";
                        }
                        else
                        {
                            cbxConnectionMethodsTypes.DisplayMember = "ContactMethodsTypeNoNameEN";
                        }
                        ElementsTools.ComboBox_.CustumProperties(cbxConnectionMethodsTypes);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> cbxConnectionMethodsTypesEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                filltblConnectionMethodsTypes(); // تعبئة جدول انواع طرق الاتصال

                try
                {
                    if (tblConnectionMethodsTypes.Rows.Count > 0)
                    {
                        cbxConnectionMethodsTypes.DataSource = tblConnectionMethodsTypes;
                        cbxConnectionMethodsTypes.ValueMember = "ContactMethodsTypeNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbxConnectionMethodsTypes.DisplayMember = "ContactMethodsTypeNoNameAR";
                        }
                        else
                        {
                            cbxConnectionMethodsTypes.DisplayMember = "ContactMethodsTypeNoNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbxConnectionMethodsTypes,"",true,true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> cbxConnectionMethodsTypesEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbxConnectionMethodsTypes.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txtConnectionNo.Select(); };
                };
            }
        }

        private void lblConnectionNoEventsAndProperties(bool Properties, bool Events = false) // ملصق رقم طريقة الاتصال 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionNo, "الرقم", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionNo, "الرقم", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txtConnectionNoEventsAndProperties(bool Properties, bool Events = false) // مربع نص لرقم طريقة التواصل
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txtConnectionNo, "en-US",100);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtConnectionNo, "en-US",100, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txtConnectionNo.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txtOtherDetails.Select(); };
                };
            }
        }

        private void lblConnectionDetailsEventsAndProperties(bool Properties, bool Events = false) // ملصق نص تفاصيل اخرى 
        {

            // الخصائص
            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionDetails, "تفاصيل أخرى", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionDetails, "تفاصيل أخرى", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txtOtherDetailsEventsAndProperties(bool Properties, bool Events = false) //  مربع نص تفاصيل اخرى
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txtOtherDetails,"",250);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtOtherDetails, "",250, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txtOtherDetails.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btnAddConnectionNumber.PerformClick(); };
                };
            }
        }

        private void btnAddConnectionNumberEventsAndProperties(bool Properties, bool Events = false) // زر اضافة طريقة اتصال
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btnAddConnectionNumber, "إضافة");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btnAddConnectionNumber, "إضافة", ColorPropertyName.ForeColor_1, true, true);

                btnAddConnectionNumber.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Manufacturers, PermissionType.Add))
                        {

                            if (btnAddConnectionNumber.Text == Cultures.ReturnTranslation("إضافة"))
                            {
                                btnAddConnectionNumber.Text = Cultures.ReturnTranslation("حفظ");
                                txtConnectionNo.Enabled = true;
                                txtOtherDetails.Enabled = true;
                                cbxConnectionMethodsTypes.Enabled = true;

                                txtConnectionNo.Text = "";
                                txtOtherDetails.Text = "";
                                cbxConnectionMethodsTypes.SelectedIndex = 0;

                                cbxConnectionMethodsTypes.Select();
                            }
                            else
                            {
                                string check = "";

                                if (txt08001002001.Text.Trim() == "")
                                {
                                    check += Cultures.ReturnTranslation("رجاء قم بتحديد الشركةالتي تريد إضافة طريقة إتصال جديدة إليها");
                                    //dgv08001.Rows[0].Selected = true;
                                    btnAddConnectionNumber.Text = Cultures.ReturnTranslation("إضافة");
                                }
                                else if (cbxConnectionMethodsTypes.SelectedValue == null)
                                {
                                    check += Cultures.ReturnTranslation("رجاء قم بتحديد نوع طريقة الإتصال");
                                    cbxConnectionMethodsTypes.Focus();
                                }
                                else if (txtConnectionNo.Text.Trim() == "")
                                {
                                    check += Cultures.ReturnTranslation("رجاء قم بتسجيل رقم طريقة الإتصال الجديدة");
                                    txtConnectionNo.Focus();
                                }
                                else
                                {
                                    bool? SameConnectionNo = ElementsTools.DataGridView_.findValueThenSelected(dgvAllConnectionsNumbers, ActionType.add, txtConnectionNo.Text.Replace("'", ""), 5);

                                    if (SameConnectionNo == true)
                                    {
                                        check = Cultures.ReturnTranslation("توجد وسيلة إتصال لها نفس الرقم");
                                        txtConnectionNo.Focus();
                                    }

                                }

                                if (check == "")
                                {
                                    btnAddConnectionNumber.Text = Cultures.ReturnTranslation("إضافة");
                                    txtConnectionNo.Enabled = false;
                                    txtOtherDetails.Enabled = false;
                                    cbxConnectionMethodsTypes.Enabled = false;
                                    //----------

                                    string[] result = null;
                                    object x = DataTools.DataBases.Run(ref result, "SpAddNewCommunicationMethod", CommandType.StoredProcedure, new object[][] { new object[] { "@tableName", "TblEnterpriseBranches" }, new object[] { "@keyRecordName", "BranchNumber" }, new object[] { "@keyRecordValue", int.Parse(txt08001002001.Text) }, new object[] { "@ContactMethodsTypeNo", cbxConnectionMethodsTypes.SelectedValue }, new object[] { "@CommunicationNo", txtConnectionNo.Text }, new object[] { "@OtherDetails", txtOtherDetails.Text } });

                                    fillTblMethodsOfCommunication(); // تعبئة جدول طرق الاتصال حسب السجل الجديد
                                    dgvAllConnectionsNumbersEventsAndProperties(true);
                                    btnAddConnectionNumber.Focus();
                                }
                                else
                                {
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), check, MessageBoxStatus.Ok);

                                }
                                
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btnAddConnectionNumberEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btnAddConnectionNumberEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }



                };
            }
        }


        private void btnDeleteConnectionNumberEventsAndProperties(bool Properties, bool Events = false) // زر حذف طريقة اتصال
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btnDeleteConnectionNumber, "حذف");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btnDeleteConnectionNumber, "حذف", ColorPropertyName.ForeColor_1, true, true);

                btnDeleteConnectionNumber.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Manufacturers, PermissionType.Delete))
                        {
                            int xxx = 0;
                            if (dgvAllConnectionsNumbers.Rows.Count > 0) 
                            { 
                                if(dgvAllConnectionsNumbers.SelectedRows != null)
                                {
                                    if (dgvAllConnectionsNumbers.SelectedRows.Count > 0)
                                    {
                                        xxx = int.Parse(dgvAllConnectionsNumbers.SelectedRows[0].Cells[0].Value.ToString());
                                    }
                                    else
                                    {
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء قم بالضغط على طريقة الإتصال التي تريد حذفها"), MessageBoxStatus.Ok);
                                        return;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else 
                            { 
                                return;
                            }

                            if (xxx > -1)
                            {
                                string[] result = null;
                                object r = DataTools.DataBases.Run(ref result, "delete from TblMethodsOfCommunication where MethodsOfCommunicationNo = @MethodsOfCommunicationNo", CommandType.Text, new object[][] { new object[] { "@MethodsOfCommunicationNo", xxx } });
                                fillTblMethodsOfCommunication(); // تعبئة جدول طرق الاتصال حسب السجل الجديد
                                dgvAllConnectionsNumbersEventsAndProperties(true);

                                cbxConnectionMethodsTypes.SelectedIndex = -1;
                                txtConnectionNo.Text = "";
                                txtOtherDetails.Text = "";
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btnDeleteConnectionNumberEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btnDeleteConnectionNumberEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                };


            }
        }

        private void dgvAllConnectionsNumbersEventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات التواصل
        {
            if (Properties == true && Events == false)
            {

                try
                {
                    if (tblCompanyConnectionMethods.Rows.Count > 0)
                    {
                        dgvAllConnectionsNumbers.DataSource = tblCompanyConnectionMethods;

                        dgvAllConnectionsNumbers.Columns[0].Visible = false;
                        dgvAllConnectionsNumbers.Columns[1].Visible = false;
                        dgvAllConnectionsNumbers.Columns[2].Visible = false;
                        dgvAllConnectionsNumbers.Columns[6].Visible = false;


                        dgvAllConnectionsNumbers.Columns[3].HeaderText = Cultures.ReturnTranslation("طريقة الإتصال");
                        dgvAllConnectionsNumbers.Columns[4].HeaderText = Cultures.ReturnTranslation("طريقة الإتصال");
                        dgvAllConnectionsNumbers.Columns[5].HeaderText = Cultures.ReturnTranslation("الرقم");


                        dgvAllConnectionsNumbers.Columns[3].Width = dgvAllConnectionsNumbers.Width / 4;
                        dgvAllConnectionsNumbers.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvAllConnectionsNumbers.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;




                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgvAllConnectionsNumbers.Columns[3].Visible = true;
                            dgvAllConnectionsNumbers.Columns[4].Visible = false;
                        }
                        else
                        {
                            dgvAllConnectionsNumbers.Columns[3].Visible = false;
                            dgvAllConnectionsNumbers.Columns[4].Visible = true;
                        }

                        ElementsTools.DataGridView_.CustumProperties(dgvAllConnectionsNumbers);
                    }
                    else
                    {
                        dgvAllConnectionsNumbers.DataSource = null;
                        dgvAllConnectionsNumbers.Rows.Clear();
                        ElementsTools.DataGridView_.CustumProperties(dgvAllConnectionsNumbers);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> dgvAllConnectionsNumbersEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }

            // الاحداث
            if (Properties == true && Events == true)
            {

                try
                {
                    if (tblCompanyConnectionMethods.Rows.Count > 0)
                    {
                        dgvAllConnectionsNumbers.DataSource = tblCompanyConnectionMethods;

                        dgvAllConnectionsNumbers.Columns[0].Visible = false;
                        dgvAllConnectionsNumbers.Columns[1].Visible = false;
                        dgvAllConnectionsNumbers.Columns[2].Visible = false;
                        dgvAllConnectionsNumbers.Columns[6].Visible = false;


                        dgvAllConnectionsNumbers.Columns[3].HeaderText = Cultures.ReturnTranslation("طريقة الإتصال");
                        dgvAllConnectionsNumbers.Columns[4].HeaderText = Cultures.ReturnTranslation("طريقة الإتصال");
                        dgvAllConnectionsNumbers.Columns[5].HeaderText = Cultures.ReturnTranslation("الرقم");


                        dgvAllConnectionsNumbers.Columns[3].Width = dgvAllConnectionsNumbers.Width / 4;
                        dgvAllConnectionsNumbers.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvAllConnectionsNumbers.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;




                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgvAllConnectionsNumbers.Columns[3].Visible = true;
                            dgvAllConnectionsNumbers.Columns[4].Visible = false;
                        }
                        else
                        {
                            dgvAllConnectionsNumbers.Columns[3].Visible = false;
                            dgvAllConnectionsNumbers.Columns[4].Visible = true;
                        }

                        ElementsTools.DataGridView_.CustumProperties(dgvAllConnectionsNumbers);
                    }
                    else
                    {
                        dgvAllConnectionsNumbers.DataSource = null;
                        dgvAllConnectionsNumbers.Rows.Clear();
                        ElementsTools.DataGridView_.CustumProperties(dgvAllConnectionsNumbers);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> dgvAllConnectionsNumbersEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                dgvAllConnectionsNumbers.SelectionChanged += delegate
                {
                    try
                    {
                        string str = "";
                        int itemIndex = 0;
                        if (cbxConnectionMethodsTypes.Items.Count > 0 && dgvAllConnectionsNumbers.Rows.Count > 0)
                        {
                            if (GeneralVariables.cultureCode == "AR")
                            {
                                if (dgvAllConnectionsNumbers.SelectedRows != null)
                                {
                                    if (dgvAllConnectionsNumbers.Rows.Count == 0 || dgvAllConnectionsNumbers.SelectedRows.Count == 0 || dgvAllConnectionsNumbers.Columns.Count == 0) return;
                                    //MessageBox.Show(dgvAllConnectionsNumbers.Rows.Count + "  //  " + dgvAllConnectionsNumbers.SelectedRows.Count + "  //  " + dgvAllConnectionsNumbers.Columns.Count);
                                    str = dgvAllConnectionsNumbers.SelectedRows[0].Cells[3].Value.ToString();


                                }
                            }
                            else
                            {
                                if (dgvAllConnectionsNumbers.SelectedRows != null)
                                {
                                    if (dgvAllConnectionsNumbers.Rows.Count == 0 || dgvAllConnectionsNumbers.SelectedRows.Count == 0 || dgvAllConnectionsNumbers.Columns.Count == 0) return;
                                    str = dgvAllConnectionsNumbers.SelectedRows[0].Cells[4].Value.ToString();

                                }
                            }

                            if (str != null || str.Trim() != "")
                            {

                                foreach (DataRowView item in cbxConnectionMethodsTypes.Items)
                                {
                                    if (GeneralVariables.cultureCode == "AR")
                                    {
                                        if (str == item[1].ToString()) { cbxConnectionMethodsTypes.SelectedIndex = itemIndex; break; }
                                    }
                                    else
                                    {
                                        if (str == item[2].ToString()) { cbxConnectionMethodsTypes.SelectedIndex = itemIndex; break; }
                                    }
                                    itemIndex++;
                                }

                            }
                            else
                            {
                                cbxConnectionMethodsTypes.SelectedIndex = 0;
                            }

                            txtConnectionNo.Text = dgvAllConnectionsNumbers.SelectedRows[0].Cells[5].Value.ToString();
                            txtOtherDetails.Text = dgvAllConnectionsNumbers.SelectedRows[0].Cells[6].Value.ToString();
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> dgvAllConnectionsNumbersEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                dgvAllConnectionsNumbers.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgvAllConnectionsNumbers);

                };
            }
        }


        //------------------------------ جداول البيانات
        DataTable tblConnectionMethodsTypes = new DataTable(); // جدول انواع طرق الاتصال 
        DataTable tblCompanyConnectionMethods = new DataTable(); // جدول بيانات طرق الاتصال بالشركة الصانعة المحددة




        // جدول انواع طرق الاتصال 
        private void filltblConnectionMethodsTypes()
        {
            try
            {
                if (tblConnectionMethodsTypes.Rows.Count > 0) { tblConnectionMethodsTypes.Rows.Clear(); }
                if (tblConnectionMethodsTypes.Rows.Count > 0) tblConnectionMethodsTypes.Rows.Clear();

                tblConnectionMethodsTypes = DataTools.DataBases.ReadTabel( "select * from TblContactMethodsTypes ");

                //string commandString = @"select * from TblContactMethodsTypes ";
                //SqlCommand com = new SqlCommand(commandString, ConnectionsTools.ConMesrakhMainDB());
                //tblConnectionMethodsTypes.Load(com.ExecuteReader());
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> filltblConnectionMethodsTypes ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        // جدول بيانات طرق الاتصال بالشركة الصانعة المحددة
        private void fillTblMethodsOfCommunication()
        {
            try
            {
                if (tblCompanyConnectionMethods.Rows.Count > 0) tblCompanyConnectionMethods.Clear();
                string commandString = @"select TblMethodsOfCommunication.MethodsOfCommunicationNo,TblMethodsOfCommunication.ConnectingMethodsOfCommunicationNO,TblMethodsOfCommunication.ContactMethodsTypeNo,TblContactMethodsTypes.ContactMethodsTypeNoNameAR , TblContactMethodsTypes.ContactMethodsTypeNoNameEN , CommunicationNo , OtherDetails from TblMethodsOfCommunication inner join TblContactMethodsTypes on TblMethodsOfCommunication.ContactMethodsTypeNo = TblContactMethodsTypes.ContactMethodsTypeNo where ConnectingMethodsOfCommunicationNO = @ConnectingMethodsOfCommunicationNO";
                SqlCommand com = new SqlCommand(commandString, ConnectionsTools.ConMesrakhMainDB());


                    if (dgv08001.CurrentRow.Cells[3].Value is null)
                    {
                        fillTblEnterprise();
                        dgv08001EventsAndProperties(true);
                        dgv08001.Rows[SelectedRowIndex].Selected = true; // تحديد الصف الذي كنا عليه
                    }
                    com.Parameters.AddWithValue("@ConnectingMethodsOfCommunicationNO", dgv08001.CurrentRow.Cells[7].Value); // وضعت في هذا المكان لكي لا يعدود السطر الحالي فارغ



                tblCompanyConnectionMethods.Load(com.ExecuteReader());
                //MessageBox.Show(tblCompanyConnectionMethods.Rows.Count+"    <>    "+ dgv08001.CurrentRow.Cells[3].Value);

            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> fillTblMethodsOfCommunication ", DateTime.Now, ex.Message, ex.Message);
            }
        }



        //----------------------------------  وحدات العمليات


        private void lblOperationUnitsEventsAndProperties(bool Properties, bool Events = false) // ملصق عنوان وحدات العمليات
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblOperationUnits, "وحدات العمليات", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblOperationUnits, "وحدات العمليات", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lblUnitNoInBranchEventsAndProperties(bool Properties, bool Events = false) // ملصق عنوان وحدات العمليات
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblUnitNoInBranch, "رمز الوحدة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblUnitNoInBranch, "رمز الوحدة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void txtUnitNoInBranchEventsAndProperties(bool Properties = true, bool Events = false) // مربع نص رمز وحدة العمليات في الفرع
        {
            string cultureInfo = "en-US";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txtUnitNoInBranch, cultureInfo,50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtUnitNoInBranch, cultureInfo,50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txtUnitNoInBranch.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { addUnitBranch.PerformClick(); };

                };
            }
        }


        private void addUnitBranchEventsAndProperties(bool Properties, bool Events = false) // زر اضافة وحدة عمليات
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(addUnitBranch, "إضافة");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(addUnitBranch, "إضافة", ColorPropertyName.ForeColor_1, true, true);

                addUnitBranch.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Unit_Branch, PermissionType.Add))
                        {

                            if (addUnitBranch.Text == Cultures.ReturnTranslation("إضافة"))
                            {

                                addUnitBranch.Text = Cultures.ReturnTranslation("حفظ");
                                txtUnitNoInBranch.Enabled = true;
                                txtUnitNoInBranch.Text = "";
                                dgvUnitBranch.Enabled = true;

                                txtUnitNoInBranch.Select();

                            }
                            else
                            {
                                string check = "";
                                if (txt08001002001.Text.Trim() == "")
                                {
                                    check += Cultures.ReturnTranslation("رجاء قم بتحديد الفرع الذي تريد إضافة وحدة عمليات جديدة إليه");
                                    addUnitBranch.Text = Cultures.ReturnTranslation("إضافة");
                                }
                                else if (txtUnitNoInBranch.Text.Trim() == "")
                                {
                                    check += Cultures.ReturnTranslation("رجاء قم بتسجيل وحدة العمليات الجديدة");
                                    txtUnitNoInBranch.Focus();
                                }
                                else
                                {
                                    bool? SameOperationUnit = ElementsTools.DataGridView_.findValueThenSelected(dgvUnitBranch, ActionType.add, txtUnitNoInBranch.Text.Replace("'", ""), 2);

                                    if (SameOperationUnit == true)
                                    {
                                        check = Cultures.ReturnTranslation("توجد وحدة عمليات لها نفس الرمز");
                                        txtUnitNoInBranch.Focus();
                                    }

                                }

                                if (check == "")
                                {

                                    string[] result = null;
                                    object x = DataTools.DataBases.Run(ref result, "insert into TblOperationUnits values (@BranchNumber,@UnitNoInBranch,'')", CommandType.Text, new object[][] { new object[] { "@BranchNumber", txt08001002001.Text }, new object[] { "@UnitNoInBranch", txtUnitNoInBranch.Text }});

                                    addUnitBranch.Text = Cultures.ReturnTranslation("إضافة");
                                    txtUnitNoInBranch.Enabled = false;

                                    fillTblOperationUnits(); // تعبئة جدول وحدات العمليات
                                    dgvUnitBranchEventsAndProperties(true);
                                    addUnitBranch.Focus();
                                }
                                else
                                {
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), check, MessageBoxStatus.Ok);

                                }

                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> addUnitBranchEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> addUnitBranchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }



                };
            }
        }


        private void btnDeleteUnitBranchEventsAndProperties(bool Properties, bool Events = false) // زر حذف وحدات العمليات
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btnDeleteUnitBranch, "حذف");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btnDeleteUnitBranch, "حذف", ColorPropertyName.ForeColor_1, true, true);

                btnDeleteUnitBranch.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Unit_Branch, PermissionType.Delete))
                        {
                            int xxx = 0;
                            if (dgvUnitBranch.Rows.Count > 0)
                            {
                                if (dgvUnitBranch.SelectedRows != null)
                                {
                                    if (dgvUnitBranch.SelectedRows.Count > 0)
                                    {
                                        xxx = int.Parse(dgvUnitBranch.SelectedRows[0].Cells[0].Value.ToString());
                                    }
                                    else
                                    {
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء قم بالضغط على وحدة العمليات التي ترغب في حذفها"), MessageBoxStatus.Ok);

                                        //if (dgvUnitBranch.Rows.Count > 0)
                                        //{
                                        //    dgvUnitBranch.Rows[0].Selected = true;
                                        //}
                                        //else
                                        //{
                                        //    return;
                                        //}
                                       
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }

                            if (xxx > -1)
                            {
                                string[] result = null;
                                object r = DataTools.DataBases.Run(ref result, "delete from TblOperationUnits where OperationUnitNumber = @OperationUnitNumber", CommandType.Text, new object[][] { new object[] { "@OperationUnitNumber", xxx } });
                                fillTblOperationUnits(); // تعبئة جدول وحدات العمليات
                                dgvUnitBranchEventsAndProperties(true);
                                txtUnitNoInBranch.Text = "";
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btnDeleteUnitBranchEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btnDeleteUnitBranchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                };


            }
        }

        private void dgvUnitBranchEventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات وحدات العمليات
        {
            if (Properties == true && Events == false)
            {

                try
                {
                    if (TblOperationUnits is null) fillTblOperationUnits();
                    if (TblOperationUnits.Rows.Count > 0)
                    {
                        dgvUnitBranch.DataSource = TblOperationUnits;
                        dgvUnitBranch.Columns[0].Visible = false;
                        dgvUnitBranch.Columns[1].Visible = false;
                        dgvUnitBranch.Columns[2].HeaderText = Cultures.ReturnTranslation("رمز وحدة العمليات");
                        dgvUnitBranch.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvUnitBranch.Columns[3].Visible = false;

                        ElementsTools.DataGridView_.CustumProperties(dgvAllConnectionsNumbers);
                    }
                    else
                    {
                        dgvUnitBranch.DataSource = null;
                        dgvUnitBranch.Rows.Clear();
                        ElementsTools.DataGridView_.CustumProperties(dgvUnitBranch);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> dgvUnitBranchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }

            // الاحداث
            if (Properties == true && Events == true)
            {

                try
                {
                    if (TblOperationUnits is null) fillTblOperationUnits();
                    if (TblOperationUnits.Rows.Count > 0)
                    {
                        dgvUnitBranch.DataSource = TblOperationUnits;
                        dgvUnitBranch.Columns[0].Visible = false;
                        dgvUnitBranch.Columns[1].Visible = false;
                        dgvUnitBranch.Columns[2].HeaderText = Cultures.ReturnTranslation("رمز وحدة العمليات");
                        dgvUnitBranch.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvUnitBranch.Columns[3].Visible = false;

                        ElementsTools.DataGridView_.CustumProperties(dgvUnitBranch);
                    }
                    else
                    {
                        dgvUnitBranch.DataSource = null;
                        dgvUnitBranch.Rows.Clear();
                        ElementsTools.DataGridView_.CustumProperties(dgvUnitBranch);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> dgvUnitBranchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                dgvUnitBranch.SelectionChanged += delegate
                {
                    try
                    {
                        if(dgvUnitBranch.SelectedRows != null)
                        {
                            if(dgvUnitBranch.SelectedRows.Count >0)
                            {
                                txtUnitNoInBranch.Text = dgvUnitBranch.SelectedRows[0].Cells[2].Value.ToString();

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> dgvUnitBranchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                dgvUnitBranch.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgvUnitBranch);

                };
            }
        }

        //---------

        DataTable TblOperationUnits = new DataTable(); // جدول بيانات وحدات العمليات

        // جدول وحدات العمليات 
        private void fillTblOperationUnits()
        {
            try
            {
                if (TblOperationUnits is null) TblOperationUnits = new DataTable();
                if (TblOperationUnits.Rows.Count > 0) { TblOperationUnits.Rows.Clear(); }
                TblOperationUnits = DataTools.DataBases.ReadTabel("select * from TblOperationUnits where BranchNumber = "+ txt08001002001.Text);

            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> fillTblOperationUnits ", DateTime.Now, ex.Message, ex.Message);
            }
        }




        //----------------------------------  الأرفف

        private void lblShelvesEventsAndProperties(bool Properties, bool Events = false) // ملصق عنوان جزءالرفوف
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblShelves, "الأرفف", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblShelves, "الأرفف", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lblShelfGeneralNoEventsAndProperties(bool Properties, bool Events = false) // ملصق كود الرف
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblShelfGeneralNo, "رمز الرف", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblShelfGeneralNo, "رمز الرف", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void txtShelfGeneralNoEventsAndProperties(bool Properties = true, bool Events = false) // مربع نص كود الرف
        {
            string cultureInfo = "en-US";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(ShelfCode, cultureInfo,50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(ShelfCode, cultureInfo,50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                ShelfCode.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btnAddShelf.PerformClick(); };

                };
            }
        }


        private void btnAddShelfEventsAndProperties(bool Properties, bool Events = false) // زر اضافة رف
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btnAddShelf, "إضافة");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btnAddShelf, "إضافة", ColorPropertyName.ForeColor_1, true, true);

                btnAddShelf.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Shelves, PermissionType.Add))
                        {

                            if (btnAddShelf.Text == Cultures.ReturnTranslation("إضافة"))
                            {
                                btnAddShelf.Text = Cultures.ReturnTranslation("حفظ");
                                ShelfCode.Enabled = true;
                                ShelfCode.Text = "";
                                dgvShelves.Enabled = true;

                                ShelfCode.Select();
                            }
                            else
                            {
                                string check = "";

                                if (txt08001002001.Text.Trim() == "")
                                {
                                    check += Cultures.ReturnTranslation("رجاء قم بتحديد الفرع الذي تريد إضافة أرفف جديدة إليه");
                                    btnAddShelf.Text = Cultures.ReturnTranslation("إضافة");
                                }
                                else if (ShelfCode.Text.Trim() == "")
                                {
                                    check += Cultures.ReturnTranslation("رجاء قم بتسجيل رمز الرف الجديد");
                                    ShelfCode.Focus();
                                }
                                else
                                {
                                    bool? SameShelfCode = ElementsTools.DataGridView_.findValueThenSelected(dgvShelves, ActionType.add, ShelfCode.Text.Replace("'", ""), 1);

                                    if (SameShelfCode == true)
                                    {
                                        check = Cultures.ReturnTranslation("يوجد رف يحمل نفس الرمز");
                                        ShelfCode.Focus();
                                    }

                                }

                                if (check == "")
                                {


                                    string[] result = null;
                                    object x = DataTools.DataBases.Run(ref result, "insert into TblShelves values (@ShelfCode,@BranchNumber)", CommandType.Text, new object[][] { new object[] { "@ShelfCode", ShelfCode.Text }  ,  new object[] { "@BranchNumber", txt08001002001.Text }});

                                    btnAddShelf.Text = Cultures.ReturnTranslation("إضافة");
                                    ShelfCode.Enabled = false;

                                    fillTblShelves(); // تعبئة جدول الأرفف
                                    dgvShelvesEventsAndProperties(true);
                                    btnAddShelf.Focus();
                                }
                                else
                                {
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), check, MessageBoxStatus.Ok);

                                }

                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btnAddShelfEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btnAddShelfEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }



                };
            }
        }


        private void btnDeleteShelfEventsAndProperties(bool Properties, bool Events = false) // زر حذف رف
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btnDeleteShelf, "حذف");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btnDeleteShelf, "حذف", ColorPropertyName.ForeColor_1, true, true);

                btnDeleteShelf.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Shelves, PermissionType.Delete))
                        {
                            int xxx = 0;
                            if (dgvShelves.Rows.Count > 0)
                            {
                                if (dgvShelves.SelectedRows != null)
                                {
                                    if (dgvShelves.SelectedRows.Count > 0)
                                    {
                                        xxx = int.Parse(dgvShelves.SelectedRows[0].Cells[0].Value.ToString());
                                    }
                                    else
                                    {
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء قم بالضغط على الرف الذي ترغب في حذفه"), MessageBoxStatus.Ok);

                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }

                            if (xxx > -1)
                            {
                                string[] result = null;
                                object r = DataTools.DataBases.Run(ref result, "delete from TblShelves where ShelfGeneralNo = @ShelfGeneralNo", CommandType.Text, new object[][] { new object[] { "@ShelfGeneralNo", xxx } });
                                
                                fillTblShelves(); // تعبئة جدول وحدات العمليات
                                dgvShelvesEventsAndProperties(true);
                                ShelfCode.Text = "";
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btnDeleteShelfEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> btnDeleteShelfEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                };


            }
        }

        private void dgvShelvesEventsAndProperties(bool Properties, bool Events = false) // جدول عرض الأرفف
        {
            if (Properties == true && Events == false)
            {

                try
                {
                    if (TblShelves is null) fillTblShelves();
                    if (TblShelves.Rows.Count > 0)
                    {
                        dgvShelves.DataSource = TblShelves;
                        dgvShelves.Columns[0].Visible = false;
                        dgvShelves.Columns[2].Visible = false;
                        dgvShelves.Columns[1].HeaderText = Cultures.ReturnTranslation("رمز الرف");
                        dgvShelves.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        ElementsTools.DataGridView_.CustumProperties(dgvShelves);
                    }
                    else
                    {
                        dgvShelves.DataSource = null;
                        dgvShelves.Rows.Clear();
                        ElementsTools.DataGridView_.CustumProperties(dgvShelves);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> dgvShelvesEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }

            // الاحداث
            if (Properties == true && Events == true)
            {

                try
                {
                    if (TblShelves is null) fillTblShelves();
                    if (TblShelves.Rows.Count > 0)
                    {
                        dgvShelves.DataSource = TblShelves;
                        dgvShelves.Columns[0].Visible = false;
                        dgvShelves.Columns[2].Visible = false;
                        dgvShelves.Columns[1].HeaderText = Cultures.ReturnTranslation("رمز الرف");
                        dgvShelves.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        ElementsTools.DataGridView_.CustumProperties(dgvShelves);
                    }
                    else
                    {
                        dgvShelves.DataSource = null;
                        dgvShelves.Rows.Clear();
                        ElementsTools.DataGridView_.CustumProperties(dgvShelves);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> dgvShelvesEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                dgvShelves.SelectionChanged += delegate
                {
                    try
                    {
                        if (dgvShelves.SelectedRows != null)
                        {
                            if (dgvShelves.SelectedRows.Count > 0)
                            {
                                ShelfCode.Text = dgvShelves.SelectedRows[0].Cells[1].Value.ToString();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> dgvShelvesEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                dgvShelves.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgvShelves);

                };
            }
        }

        //---------

        DataTable TblShelves = new DataTable(); // جدول بيانات الأرفف

        // تعبئة جدول الارفف 
        private void fillTblShelves()
        {
            try
            {
                if (TblShelves is null) TblShelves = new DataTable();
                if (TblShelves.Rows.Count > 0) { TblShelves.Rows.Clear(); }
                TblShelves = DataTools.DataBases.ReadTabel("select * from TblShelves where BranchNumber = " + txt08001002001.Text);

            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmEnterpriseBranches16 >> fillTblShelves ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        //-- -- 
    }


}

