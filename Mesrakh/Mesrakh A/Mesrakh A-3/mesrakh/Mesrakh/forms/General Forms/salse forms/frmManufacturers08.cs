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
    public partial class frmManufacturers08 : Form
    {
        public frmManufacturers08()
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
            lbl08001002000EventsAndProperties(Properties, Events); // ملصق عنوان جزء الشركات
            lbl08001002001EventsAndProperties(Properties, Events); // ملصق رقم المستخدم
            txt08001002001EventsAndProperties(Properties, Events); // مربع نص رقم المستخدم
            lbl08001002002EventsAndProperties(Properties, Events); // ملصق اسم الشركة عربي
            txt08001002002EventsAndProperties(Properties, Events); // مربع نص اسم الشركة عربي
            lbl08001002003EventsAndProperties(Properties, Events); // ملصق اسم الشركة انجليزي
            txt08001002003EventsAndProperties(Properties, Events); // مربع نص اسم الشركة انجليزي
            btn08001002001EventsAndProperties(Properties, Events); // جديد
            btn08001002002EventsAndProperties(Properties, Events); // حفظ
            btn08001002003EventsAndProperties(Properties, Events); // تعديل
            btn08001002004EventsAndProperties(Properties, Events); // حذف
            dgv08001EventsAndProperties(Properties, Events); // جدول عرض بيانات الشركات الصانعة
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
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "الشركات الصانعة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "الشركات الصانعة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
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

        private void lbl08001002000EventsAndProperties(bool Properties, bool Events = false) // ملصق عنوان جزءالشركات 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002000, "الشركات الصانعة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002000, "الشركات الصانعة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lbl08001002001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم الشركة الصانعة 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم الشركة الصانعة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم الشركة الصانعة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم الشركة الصانعة
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
        private void lbl08001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق اسم الشركة عربي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "اسم الشركة عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "اسم الشركة عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002002EventsAndProperties(bool Properties = true, bool Events = false) // مربع نص اسم الشركة عربي
        {
            string cultureInfo = "ar-sa";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, cultureInfo);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, cultureInfo, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002002.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt08001002003.Select(); };

                };
            }
        }
        private void lbl08001002003EventsAndProperties(bool Properties, bool Events = false) // ملصق اسم الشركة انجليزي 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "اسم الشركة انجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "اسم الشركة انجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص اسم الشركة انجليزي
        {
            string cultureInfo = "en-us";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, cultureInfo);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, cultureInfo, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002003.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btn08001002002.PerformClick(); };
                };
            }
        }

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
                        if (Permissions.AccountHavePermission(PermissionObjectes.Manufacturers, PermissionType.Add))
                        {

                            if (btn08001002001.Text == Cultures.ReturnTranslation("جديد"))
                            {
                                btn08001002001.Text = Cultures.ReturnTranslation("إلغاء");

                                txt08001002002.Enabled = true;
                                txt08001002003.Enabled = true;

                                txt08001002001.Text = "";
                                txt08001002002.Text = "";
                                txt08001002003.Text = "";

                                txt08001002002.Focus();

                                btn08001002002.Enabled = true;
                                btn08001002003.Enabled = false;
                                btn08001002004.Enabled = false;

                                dgv08001.Enabled = false;
                            }
                            else
                            {
                                btn08001002001.Text = Cultures.ReturnTranslation("جديد");

                                txt08001002002.Enabled = false;
                                txt08001002003.Enabled = false;

                                btn08001002002.Enabled = false;
                                btn08001002003.Enabled = true;
                                btn08001002004.Enabled = true;

                                dgv08001.Enabled = true;
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmManufacturers08 >> btn08001002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmManufacturers08 >> btn08001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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

                        if (txt08001002001.Text == "")
                        {
                            string Error = "";
                            if (txt08001002002.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الشركة عربي");
                                txt08001002002.Focus();
                            }
                            else if (txt08001002003.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الشركة إنجليزي");
                                txt08001002003.Focus();
                            }
                            else
                            {
                                bool? SameArabicCompanyName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002002.Text.Replace("'", ""), 1);
                                bool? SameEnglishCompanyName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002003.Text.Replace("'", ""), 2);
                                if (SameArabicCompanyName == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد شركة بنفس إسم الشركة العربي");
                                    txt08001002002.Focus();

                                }
                                else
                                {
                                    if (SameEnglishCompanyName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد شركة بنفس إسم الشركة الإنجليزي");
                                        txt08001002003.Focus();
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string[] result = null;
                                object ConnectingMethodsOfCommunicationNO = DataTools.DataBases.Run(ref result, "SpAddNewTblConnectingMethodsOfCommunication", CommandType.StoredProcedure, new object[][] { new object[] { "@OtherDetails", "Add New TblManufacturers  >> " + DateTime.Now }, new object[] { "@ConnectingMethodsOfCommunicationNO", "OUT" } });

                                string[] result00 = null;
                                object ManufacturerNo = DataTools.DataBases.Run(ref result00, "spAddManufacturers", CommandType.StoredProcedure, new object[][] { new object[] { "@CompanyNameAr", txt08001002002.Text }, new object[] { "@CompanyNameEn", txt08001002003.Text }, new object[] { "@ConnectingMethodsOfCommunicationNO", ConnectingMethodsOfCommunicationNO }, new object[] { "@ManufacturerNo", "OUT" } });


                               if(result00[1] == "succeeded")
                                {

                                    txt08001002002.Enabled = false;
                                    txt08001002003.Enabled = false;

                                    btn08001002001.Enabled = true;
                                    btn08001002002.Enabled = false;
                                    btn08001002003.Enabled = true;
                                    btn08001002004.Enabled = true;

                                    dgv08001.Enabled = true;

                                    // تحديث بيانات جدول البيانات
                                    fillManufacturersTable(); // تعبئة جدول الشركات الصانعة
                                    AllEventsAndProperties(true); // تم تحديث جميع الخصائص لتعود الازرار لوضعها الطبيعي

                                    // تحديث بيانات جدول المنتجات 
                                    if (GeneralVariables._frmProductsAndServices09 != null) GeneralVariables._frmProductsAndServices09 = null;
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
                            if (txt08001002002.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الشركة عربي");
                                txt08001002002.Focus();
                            }
                            else if (txt08001002003.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الشركة إنجليزي");
                                txt08001002003.Focus();
                            }
                            else
                            {
                                bool? SameArabicCompanyName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002002.Text.Replace("'", ""), 1);
                                bool? SameEnglishCompanyName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002003.Text.Replace("'", ""), 2);
                                if (SameArabicCompanyName == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد شركة بنفس إسم الشركة العربي");
                                    txt08001002002.Focus();

                                }
                                else
                                {
                                    if (SameEnglishCompanyName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد شركة بنفس إسم الشركة الإنجليزي");
                                        txt08001002003.Focus();
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string[] result00 = null;
                                object result2 = DataTools.DataBases.Run(ref result00, "update TblManufacturers set CompanyNameAr = @CompanyNameAr,CompanyNameEn = @CompanyNameEn where ManufacturerNo = @ManufacturerNo ", CommandType.Text, new object[][] { new object[] { "@CompanyNameAr", txt08001002002.Text }, new object[] { "@CompanyNameEn", txt08001002003.Text }, new object[] { "@ManufacturerNo", txt08001002001.Text } });
                                //MessageBox.Show(result[0]+"  "+result[1]);

                                if (result00[1] == "succeeded")
                                {
                                    txt08001002002.Enabled = false;
                                    txt08001002003.Enabled = false;

                                    btn08001002001.Enabled = true;
                                    btn08001002002.Enabled = false;
                                    btn08001002003.Enabled = true;
                                    btn08001002004.Enabled = true;



                                    dgv08001.Enabled = true;

                                    // تحديث بيانات جدول البيانات
                                    fillManufacturersTable();
                                    AllEventsAndProperties(true);

                                    // تحديث بيانات الشركات الصانعة بنموذج المنتجات
                                    if (GeneralVariables._frmProductsAndServices09 != null) GeneralVariables._frmProductsAndServices09 = null;
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
                        GeneralAction.AddNewNotification("frmManufacturers08 >> btn08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    if (Permissions.AccountHavePermission(PermissionObjectes.Manufacturers , PermissionType.Edit))
                    {
                        if (btn08001002003.Enabled)
                        {
                            if (btn08001002003.Text == Cultures.ReturnTranslation("تعديل"))
                            {
                                btn08001002003.Text = Cultures.ReturnTranslation("إلغاء");

                                txt08001002002.Enabled = true;
                                txt08001002003.Enabled = true;

                                btn08001002001.Enabled = false;
                                btn08001002002.Enabled = true;
                                btn08001002004.Enabled = false;

                                dgv08001.Enabled = false;
                            }
                            else
                            {
                                btn08001002003.Text = Cultures.ReturnTranslation("تعديل");

                                txt08001002002.Enabled = false;
                                txt08001002003.Enabled = false;

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
                        GeneralAction.AddNewNotification("frmManufacturers08 >> btn08001002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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
                    if (Permissions.AccountHavePermission(PermissionObjectes.Manufacturers , PermissionType.Delete))
                    {
                        try
                        {

                            string[] result = null;
                            DataTools.DataBases.Run(ref result, "delete from TblManufacturers where ManufacturerNo = @ManufacturerNo", CommandType.Text, new object[][] { new object[] { "@ManufacturerNo", txt08001002001.Text } });

                            if(result[1] == "succeeded")
                            {
                                txt08001002001.Text = "";
                                txt08001002002.Text = "";
                                txtSearch.Text = "";

                                // تحديث بيانات جدول البيانات
                                fillManufacturersTable();
                                dgv08001EventsAndProperties(true);
                            }

                        }
                        catch (Exception ex)
                        {
                            GeneralAction.AddNewNotification("frmManufacturers08 >> btn08001002004EventsAndProperties ", DateTime.Now,ex.Message, ex.Message);
                        }


                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmManufacturers08 >> btn08001002004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }


                };
            }
        }

        int SelectedRowIndex = -1; // يستخدم في تعبئة الجدول

        private void dgv08001EventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات الشركات الصانعة
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (tblManufacturersTable.Rows.Count > 0)
                    {

                        dgv08001.DataSource = tblManufacturersTable;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الشركة الصانعة");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("اسم الشركة عربي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("اسم الشركة انجليزي");

                        dgv08001.Columns[0].Width = dgv08001.Width / 4;
                        dgv08001.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv08001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



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
                        dgv08001.Columns[3].Visible = false;

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
                    GeneralAction.AddNewNotification("frmManufacturers08 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                }
            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillManufacturersTable(); // تعبئة جدول الشركات الصانعة

                    if (tblManufacturersTable.Rows.Count > 0)
                    {

                        dgv08001.DataSource = tblManufacturersTable;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الشركة الصانعة");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("اسم الشركة عربي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("اسم الشركة انجليزي");

                        dgv08001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgv08001.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv08001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



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
                        dgv08001.Columns[3].Visible = false;

                        ElementsTools.DataGridView_.CustumProperties(dgv08001, true, true);  // تخصيص خصائص جدول عرض البيانات
                    }
                    else
                    {
                        if (dgv08001.Rows.Count > 0) { dgv08001.DataSource = null; dgv08001.Rows.Clear(); };
                        ElementsTools.DataGridView_.CustumProperties(dgv08001, true, true);  // تخصيص خصائص جدول عرض البيانات
                    }

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmManufacturers08 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

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

                            SelectedRowIndex = dgv08001.SelectedRows[0].Index;

                            txtConnectionNo.Text = "";
                            txtOtherDetails.Text = "";
                            cbxConnectionMethodsTypes.SelectedIndex = -1;

                            filltblCompanyConnectionMethods(); // تعبئة جدول طرق الاتصال حسب السجل الجديد
                            dgvAllConnectionsNumbersEventsAndProperties(true); // خصائص جدول عرض بيانات طرق الاتصال

                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmManufacturers08 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                    }
                };

                dgv08001.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات

                };
            }
        }


        //------------------------------ 
        DataTable tblManufacturersTable = new DataTable(); // بيانات الشركات الصانعة

        // بيانات الشركات الصانعة
        private void fillManufacturersTable()
        {
            try
            {
                if (tblManufacturersTable.Rows.Count > 0)
                {
                    tblManufacturersTable.Rows.Clear();
                }

                if (tblManufacturersTable.Rows.Count > 0) tblManufacturersTable.Rows.Clear();

                tblManufacturersTable = DataTools.DataBases.ReadTabel( "select * from TblManufacturers ");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmManufacturers08 >> btn08001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                ElementsTools.TextBox_.CustumProperties(txtSearch);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtSearch, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txtSearch.TextChanged += delegate
                {
                    try
                    {
                        DataView dv = new DataView(tblManufacturersTable);
                        string filter = "";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            filter = "CompanyNameAr like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        else
                        {
                            filter = "CompanyNameEn like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        dv.RowFilter = filter;
                        dgv08001.DataSource = dv;
                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmManufacturers08 >> txtSearchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    GeneralAction.AddNewNotification("frmManufacturers08 >> cbxConnectionMethodsTypesEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    GeneralAction.AddNewNotification("frmManufacturers08 >> cbxConnectionMethodsTypesEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                ElementsTools.TextBox_.CustumProperties(txtConnectionNo, "en-US");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtConnectionNo, "en-US", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

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
                ElementsTools.TextBox_.CustumProperties(txtOtherDetails);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtOtherDetails, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

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
                                    object x = DataTools.DataBases.Run(ref result, "SpAddNewCommunicationMethod", CommandType.StoredProcedure, new object[][] { new object[] { "@tableName", "TblManufacturers" }, new object[] { "@keyRecordName", "ManufacturerNo" }, new object[] { "@keyRecordValue", int.Parse(txt08001002001.Text) }, new object[] { "@ContactMethodsTypeNo", cbxConnectionMethodsTypes.SelectedValue }, new object[] { "@CommunicationNo", txtConnectionNo.Text }, new object[] { "@OtherDetails", txtOtherDetails.Text } });

                                    filltblCompanyConnectionMethods(); // تعبئة جدول طرق الاتصال حسب السجل الجديد
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
                            GeneralAction.AddNewNotification("frmManufacturers08 >> btnAddConnectionNumberEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmManufacturers08 >> btnAddConnectionNumberEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                                filltblCompanyConnectionMethods(); // تعبئة جدول طرق الاتصال حسب السجل الجديد
                                dgvAllConnectionsNumbersEventsAndProperties(true);
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmManufacturers08 >> btnDeleteConnectionNumberEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmManufacturers08 >> btnDeleteConnectionNumberEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    GeneralAction.AddNewNotification("frmManufacturers08 >> dgvAllConnectionsNumbersEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    GeneralAction.AddNewNotification("frmManufacturers08 >> dgvAllConnectionsNumbersEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                        GeneralAction.AddNewNotification("frmManufacturers08 >> dgvAllConnectionsNumbersEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                GeneralAction.AddNewNotification("frmManufacturers08 >> filltblConnectionMethodsTypes ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        // جدول بيانات طرق الاتصال بالشركة الصانعة المحددة
        private void filltblCompanyConnectionMethods()
        {
            try
            {
                if (tblCompanyConnectionMethods.Rows.Count > 0) tblCompanyConnectionMethods.Clear();
                string commandString = @"select TblMethodsOfCommunication.MethodsOfCommunicationNo,TblMethodsOfCommunication.ConnectingMethodsOfCommunicationNO,TblMethodsOfCommunication.ContactMethodsTypeNo,TblContactMethodsTypes.ContactMethodsTypeNoNameAR , TblContactMethodsTypes.ContactMethodsTypeNoNameEN , CommunicationNo , OtherDetails from TblMethodsOfCommunication inner join TblContactMethodsTypes on TblMethodsOfCommunication.ContactMethodsTypeNo = TblContactMethodsTypes.ContactMethodsTypeNo where ConnectingMethodsOfCommunicationNO = @ConnectingMethodsOfCommunicationNO";
                SqlCommand com = new SqlCommand(commandString, ConnectionsTools.ConMesrakhMainDB());


                    if (dgv08001.CurrentRow.Cells[3].Value is null)
                    {
                        fillManufacturersTable();
                        dgv08001EventsAndProperties(true);
                        dgv08001.Rows[SelectedRowIndex].Selected = true; // تحديد الصف الذي كنا عليه
                    }
                    com.Parameters.AddWithValue("@ConnectingMethodsOfCommunicationNO", dgv08001.CurrentRow.Cells[3].Value); // وضعت في هذا المكان لكي لا يعدود السطر الحالي فارغ



                tblCompanyConnectionMethods.Load(com.ExecuteReader());
                //MessageBox.Show(tblCompanyConnectionMethods.Rows.Count+"    <>    "+ dgv08001.CurrentRow.Cells[3].Value);

            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmManufacturers08 >> filltblCompanyConnectionMethods ", DateTime.Now, ex.Message, ex.Message);
            }
        }
    }


}

