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
    public partial class frmProductsAndServices09 : Form
    {
        public frmProductsAndServices09()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmEventsAndProperties(Properties, Events); // النموذج
            pnl000EventsAndProperties(Properties, Events);// الحاوية الرئيسية
            pnl001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl002EventsAndProperties(Properties, Events); // الحاوية الثانية

            lbl002001EventsAndProperties(Properties, Events);// ملصق رقم السلعة او الخدمة  
            txt002001EventsAndProperties(Properties, Events);// مربع نص رقم السلعة او الخدمة 
            lbl002002EventsAndProperties(Properties, Events);// ملصق إسم السلعة او الخدمة عربي 
            txt002002EventsAndProperties(Properties, Events);// مربع نص إسم السلعة او الخدمة عربي
            lbl002003EventsAndProperties(Properties, Events);// ملصق إسم السلعة او الخدمة إنجليزي 
            txt002003EventsAndProperties(Properties, Events);// مربع نص إسم السلعة او الخدمة إنجليزي
            lbl002004EventsAndProperties(Properties, Events);// ملصق وصف السلعة او الخدمة عربي 
            txt002004EventsAndProperties(Properties, Events);// مربع نص وصف السلعة او الخدمة عربي
            lbl002005EventsAndProperties(Properties, Events);// ملصق وصف السلعة او الخدمة إنجليزي 
            txt002005EventsAndProperties(Properties, Events);// مربع نص وصف السلعة او الخدمة إنجليزي
            rb001EventsAndProperties(Properties, Events);//  دائرة اختيار - سلعة
            rb002EventsAndProperties(Properties, Events);// دائرة اختيار - سلعة

            btn002001EventsAndProperties(Properties, Events); // جديد
            btn002002EventsAndProperties(Properties, Events); // حفظ
            btn002003EventsAndProperties(Properties, Events); // تعديل
            btn002004EventsAndProperties(Properties, Events); // حذف

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

        private void pnl000EventsAndProperties(bool Properties, bool Events = false) // الحاوية الرئيسية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl000);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl000, ColorPropertyName.BackColor_3, true, true);
            }
        }

        private void pnl001EventsAndProperties(bool Properties, bool Events = false) // الحاوية العلوية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl001, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl001, ColorPropertyName.BackColor_2, true, true);
            }
        }

        private void lbl001001EventsAndProperties(bool Properties, bool Events = false) // ملصق عنوان النموذج 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001001, "السلع والخدمات", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001001, "السلع والخدمات", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void pnl002EventsAndProperties(bool Properties, bool Events = false) // الحاوية الثانية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl002);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl002, ColorPropertyName.BackColor_3, true, true);
            }
        }


        private void lbl002001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم السلعة او الخدمة 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl002001, "رقم السلعة او الخدمة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl002001, "رقم السلعة او الخدمة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم السلعة او الخدمة
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt002001);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt002001, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lbl002002EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم السلعة او الخدمة عربي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl002002, "إسم السلعة او الخدمة عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl002002, "إسم السلعة او الخدمة عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt002002EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم السلعة او الخدمة عربي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt002002, "ar-SA");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt002002, "ar-SA", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt002002.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt002003.Select(); };
                };

            }
        }

        private void lbl002003EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم السلعة او الخدمة إنجليزي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl002003, "إسم السلعة او الخدمة إنجليزي", ColorPropertyName.BackColor_1);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl002003, "إسم السلعة او الخدمة إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

            }
        }

        private void txt002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم السلعة او الخدمة إنجليزي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt002003, "en-US");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt002003, "en-US", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt002003.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt002004.Select(); };
                };

            }
        }


        private void lbl002004EventsAndProperties(bool Properties, bool Events = false) // ملصق وصف السلعة او الخدمة عربي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl002004, "وصف السلعة او الخدمة عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl002004, "وصف السلعة او الخدمة عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt002004EventsAndProperties(bool Properties, bool Events = false) // مربع نص وصف السلعة او الخدمة عربي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt002004, "ar-SA");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt002004, "ar-SA", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt002004.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt002005.Select(); };
                };

            }
        }

        private void lbl002005EventsAndProperties(bool Properties, bool Events = false) // ملصق وصف السلعة او الخدمة إنجليزي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl002005, "وصف السلعة او الخدمة إنجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl002005, "وصف السلعة او الخدمة إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt002005EventsAndProperties(bool Properties, bool Events = false) // مربع نص وصف السلعة او الخدمة إنجليزي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt002005, "en-US");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt002005, "en-US", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt002005.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btn002002.PerformClick(); };
                };

            }
        }

        private void rb001EventsAndProperties(bool Properties, bool Events = false) // سلعة 
        {

            if (Properties == true && Events == false)
            {
                rb002001.Text = Cultures.ReturnTranslation("سلعة");
            }
            else if (Properties == true && Events == true)
            {
                rb002001.Text = Cultures.ReturnTranslation("سلعة");

                rb002001.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btn002001.PerformClick(); }
                };
            }
        }

        private void rb002EventsAndProperties(bool Properties, bool Events = false) // خدمة 
        {

            if (Properties == true && Events == false)
            {
                rb002002.Text = Cultures.ReturnTranslation("خدمة");
            }
            else if (Properties == true && Events == true)
            {
                rb002002.Text = Cultures.ReturnTranslation("خدمة");

                rb002002.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btn002001.PerformClick(); }
                };
            }
        }

        //--------------------------*******
        private void btn002001EventsAndProperties(bool Properties, bool Events = false) // جديد 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn002001, "جديد");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn002001, "جديد", ColorPropertyName.ForeColor_1, true, true);

                btn002001.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Products_And_Services, PermissionType.Add))
                    {

                        if (btn002001.Text == Cultures.ReturnTranslation("جديد"))
                        {
                            btn002001.Text = Cultures.ReturnTranslation("إلغاء");

                            btn002002.Enabled = true;
                            btn002003.Enabled = false;
                            btn002004.Enabled = false;

                            txt002001.Enabled = false;
                            txt002002.Enabled = true;
                            txt002003.Enabled = true;
                            txt002004.Enabled = true;
                            txt002005.Enabled = true;

                            dgv002001.Enabled = false;

                            txt002001.Text = "";
                            txt002002.Text = "";
                            txt002003.Text = "";
                            txt002004.Text = "";
                            txt002005.Text = "";


                            txt002002.Focus();
                        }
                        else
                        {
                            btn002001.Text = Cultures.ReturnTranslation("جديد");
                            btn002002.Enabled = false;
                            btn002003.Enabled = true;
                            btn002004.Enabled = true;

                            txt002001.Enabled = false;
                            txt002002.Enabled = false;
                            txt002003.Enabled = false;
                            txt002004.Enabled = false;
                            txt002005.Enabled = false;

                            dgv002001.Enabled = true;

                            dgv002001.Focus();
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmProductsAndServices09 >> btn002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }


                };


            }


        }

        private void btn002002EventsAndProperties(bool Properties, bool Events = false) // حفظ 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn002002, "حفظ");
            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn002002, "حفظ", ColorPropertyName.ForeColor_1, true, true);

                btn002002.Click += delegate
                {

                    try
                    {
                        if ( btn002001.Text == Cultures.ReturnTranslation("إلغاء") ) // إضافة
                        {
                            string Error = "";
                            if (txt002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم المنتج عربي");
                                txt002002.Focus();
                            }
                            else if (txt002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم المنتج إنجليزي");
                                txt002003.Focus();
                            }
                            else
                            {
                                bool? SameArabicProductName = ElementsTools.DataGridView_.findValueThenSelected(dgv002001, ActionType.add, txt002002.Text.Replace("'", ""), 2);
                                bool? SameEnglishProductName = ElementsTools.DataGridView_.findValueThenSelected(dgv002001, ActionType.add, txt002003.Text.Replace("'", ""), 3);
                                if (SameArabicProductName == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد منتج بنفس إسم المنتج العربي");
                                    txt002002.Focus();

                                }
                                else
                                {
                                    if (SameEnglishProductName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("يوجد منتج بنفس إسم المنتج الإنجليزي");
                                        txt002003.Focus();
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string[] result = null;
                                DataTools.DataBases.Run(ref result, "insert into TblProductsAndServices values (@ProductOrService,@ProductOrServiceNameAR,@ProductOrServiceNameEN,@ProductOrServiceDescriptionAR,@ProductOrServiceDescriptionEN);",
                                    CommandType.Text, new object[][] {
                                      new object[] { "@ProductOrService", rb002001.Checked }
                                    , new object[] { "@ProductOrServiceNameAR", txt002002.Text.Replace("'","") }
                                    , new object[] { "@ProductOrServiceNameEN", txt002003.Text.Replace("'", "") }
                                    , new object[] { "@ProductOrServiceDescriptionAR", txt002004.Text.Replace("'","") }
                                    , new object[] { "@ProductOrServiceDescriptionEN", txt002005.Text.Replace("'","") }
                                    });



                                //-----------

                                btn002001.Enabled = true;
                                btn002002.Enabled = false;
                                btn002003.Enabled = true;
                                btn002004.Enabled = true;

                                txt002001.Enabled = false;
                                txt002002.Enabled = false;
                                txt002003.Enabled = false;
                                txt002004.Enabled = false;
                                txt002005.Enabled = false;

                                dgv002001.Enabled = true;


                                // تحديث بيانات جدول البيانات
                                fillTblProductsAndServices(); // تعبئة جدول الشركات الصانعة
                                AllEventsAndProperties(true); // تم تحديث جميع الخصائص لتعود الازرار لوضعها الطبيعي

                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);

                                txt002001.Text = "";
                            }
                            btn002001.Select();
                        }
                        else if (btn002003.Text == Cultures.ReturnTranslation("إلغاء")) // تعديل
                        {

                            string Error = "";
                            if (txt002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم المنتج عربي");
                                txt002002.Focus();
                            }
                            else if (txt002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم المنتج إنجليزي");
                                txt002003.Focus();
                            }
                            else
                            {
                                bool? SameArabicProductName = ElementsTools.DataGridView_.findValueThenSelected(dgv002001, ActionType.edit, txt002002.Text.Replace("'", ""), 2);
                                bool? SameEnglishProductName = ElementsTools.DataGridView_.findValueThenSelected(dgv002001, ActionType.edit, txt002003.Text.Replace("'", ""), 3);
                                if (SameArabicProductName == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد منتج بنفس إسم المنتج العربي");
                                    txt002002.Focus();

                                }
                                else
                                {
                                    if (SameEnglishProductName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("يوجد منتج بنفس إسم المنتج الإنجليزي");
                                        txt002003.Focus();
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string[] result = null;
                                DataTools.DataBases.Run(ref result, @"update TblProductsAndServices set 
                                                                      ProductOrService = @ProductOrService , 
                                                                      ProductOrServiceNameAR = @ProductOrServiceNameAR , 
                                                                      ProductOrServiceNameEN = @ProductOrServiceNameEN , 
                                                                      ProductOrServiceDescriptionAR = @ProductOrServiceDescriptionAR , 
                                                                      ProductOrServiceDescriptionEN = @ProductOrServiceDescriptionEN 
                                                                      where ProductOrServiceNumber = @ProductOrServiceNumber ",
                                    CommandType.Text, new object[][]
                                    {
                                      new object[] { "@ProductOrService", rb002001.Checked }
                                    , new object[] { "@ProductOrServiceNameAR", txt002002.Text.Replace("'","") }
                                    , new object[] { "@ProductOrServiceNameEN", txt002003.Text.Replace("'", "") }
                                    , new object[] { "@ProductOrServiceDescriptionAR", txt002004.Text.Replace("'","") }
                                    , new object[] { "@ProductOrServiceDescriptionEN", txt002005.Text.Replace("'","") }
                                    , new object[] { "@ProductOrServiceNumber", txt002001.Text.Replace("'","") }
                                    });



                                //-----------

                                btn002001.Enabled = true;
                                btn002002.Enabled = false;
                                btn002003.Enabled = true;
                                btn002004.Enabled = true;

                                txt002001.Enabled = false;
                                txt002002.Enabled = false;
                                txt002003.Enabled = false;
                                txt002004.Enabled = false;
                                txt002005.Enabled = false;

                                dgv002001.Enabled = true;



                                dgv002001.Enabled = true;

                                // تحديث بيانات جدول البيانات
                                fillTblProductsAndServices();
                                AllEventsAndProperties(true);

                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);
                                dgv002001.Enabled = true;
                            }
                            btn002003.Select();
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmProductsAndServices09 >> btn002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };


            }


        }


        private void btn002003EventsAndProperties(bool Properties, bool Events = false) // تعديل 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn002003, "تعديل");

            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn002003, "تعديل", ColorPropertyName.ForeColor_1, true, true);
                btn002003.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Products_And_Services, PermissionType.Edit))
                    {
                        if (btn002003.Enabled)
                        {
                            if (btn002003.Text == Cultures.ReturnTranslation("تعديل"))
                            {
                                btn002003.Text = Cultures.ReturnTranslation("إلغاء");

                                btn002001.Enabled = false;
                                btn002002.Enabled = true;
                                btn002004.Enabled = false;

                                txt002001.Enabled = false;
                                txt002002.Enabled = true;
                                txt002003.Enabled = true;
                                txt002004.Enabled = true;
                                txt002005.Enabled = true;

                                dgv002001.Enabled = false;

                                txt002002.Focus();
                            }
                            else
                            {
                                btn002003.Text = Cultures.ReturnTranslation("تعديل");

                                btn002001.Enabled = true;
                                btn002002.Enabled = false;
                                btn002004.Enabled = true;

                                txt002001.Enabled = false;
                                txt002002.Enabled = false;
                                txt002003.Enabled = false;
                                txt002004.Enabled = false;
                                txt002005.Enabled = false;

                                dgv002001.Enabled = true;

                                dgv002001.Focus();
                            }
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmProductsAndServices09 >> btn002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }


                };

            }
        }
        private void btn002004EventsAndProperties(bool Properties, bool Events = false) // حذف 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn002004, "حذف");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn002004, "حذف", ColorPropertyName.ForeColor_1, true, true);
                btn002004.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Products_And_Services, PermissionType.Delete))
                    {
                        try
                        {
                            string[] result = null;
                            DataTools.DataBases.Run(ref result, "delete from TblProductsAndServices where ProductOrServiceNumber = @ProductOrServiceNumber", CommandType.Text, new object[][] { new object[] { "@ProductOrServiceNumber", txt002001.Text.Replace("'", "") } });
                            //if(result[0] != "susses")
                            //{
                            //    MessageBox.Show(result[1]);
                            //}

                        }
                        catch (Exception ex)
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmProductsAndServices09 >> btn002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        }

                        txt002001.Text = "";
                        txt002002.Text = "";
                        txt002003.Text = "";
                        txt002004.Text = "";
                        txt002005.Text = "";

                        txtSearch.Text = "";

                        // تحديث بيانات جدول البيانات
                        fillTblProductsAndServices();
                        dgv08001EventsAndProperties(true);
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmProductsAndServices09 >> btn002004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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
                        DataView dv = new DataView(TblProductsAndServices);
                        string filter = "";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            filter = "ProductOrServiceNameAR like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        else
                        {
                            filter = "ProductOrServiceNameEN like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        dv.RowFilter = filter;
                        dgv002001.DataSource = dv;
                        ElementsTools.DataGridView_.CustumProperties(dgv002001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmProductsAndServices09 >> txtSearchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    if(TblProductsAndServices != null)
                    {
                        if (TblProductsAndServices.Rows.Count > 0)
                        {

                            dgv002001.DataSource = TblProductsAndServices;

                            dgv002001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم المنتج");
                            dgv002001.Columns[1].Visible = false;
                            dgv002001.Columns[2].HeaderText = Cultures.ReturnTranslation("الاسم المفصل للمنتج اوالخدمة عربي");
                            dgv002001.Columns[3].HeaderText = Cultures.ReturnTranslation("الاسم المفصل للمنتج اوالخدمة انجليزي");
                            dgv002001.Columns[4].Visible = false;
                            dgv002001.Columns[5].Visible = false;


                            if (GeneralVariables.cultureCode == "AR")
                            {
                                dgv002001.Columns[2].Visible = true;
                                dgv002001.Columns[3].Visible = false;


                            }
                            else
                            {
                                dgv002001.Columns[2].Visible = false;
                                dgv002001.Columns[3].Visible = true;

                            }

                            dgv002001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dgv002001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv002001.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                            ElementsTools.DataGridView_.CustumProperties(dgv002001);  // تخصيص خصائص جدول عرض البيانات
                        }
                        else
                        {
                            if (dgv002001.Rows.Count > 0) { dgv002001.DataSource = null; dgv002001.Rows.Clear(); };
                            ElementsTools.DataGridView_.CustumProperties(dgv002001);  // تخصيص خصائص جدول عرض البيانات

                        }
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmProductsAndServices09 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }
                
            }
            else if (Properties == true && Events == true)
            {
                fillTblProductsAndServices(); // تعبئة جدول الشركات الصانعة

                try
                {
                    if(TblProductsAndServices != null)
                    {
                        if (TblProductsAndServices.Rows.Count > 0)
                        {

                            dgv002001.DataSource = TblProductsAndServices;

                            dgv002001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم المنتج");
                            dgv002001.Columns[1].Visible = false;
                            dgv002001.Columns[2].HeaderText = Cultures.ReturnTranslation("الاسم المفصل للمنتج اوالخدمة عربي");
                            dgv002001.Columns[3].HeaderText = Cultures.ReturnTranslation("الاسم المفصل للمنتج اوالخدمة انجليزي");
                            dgv002001.Columns[4].Visible = false;
                            dgv002001.Columns[5].Visible = false;

                            if (GeneralVariables.cultureCode == "AR")
                            {
                                dgv002001.Columns[2].Visible = true;
                                dgv002001.Columns[3].Visible = false;


                            }
                            else
                            {
                                dgv002001.Columns[2].Visible = false;
                                dgv002001.Columns[3].Visible = true;

                            }

                            dgv002001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dgv002001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv002001.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                            ElementsTools.DataGridView_.CustumProperties(dgv002001);  // تخصيص خصائص جدول عرض البيانات
                        }
                        else
                        {
                            if (dgv002001.Rows.Count > 0) { dgv002001.DataSource = null; dgv002001.Rows.Clear(); };
                            ElementsTools.DataGridView_.CustumProperties(dgv002001);  // تخصيص خصائص جدول عرض البيانات

                        }
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmProductsAndServices09 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


                dgv002001.SelectionChanged += delegate
                {
                    try
                    {
                        if (dgv002001.Rows.Count > 0)
                        {

                            if (dgv002001.SelectedRows.Count == 0 || dgv002001.SelectedRows == null) return;

                            txt002001.Text = dgv002001.SelectedRows[0].Cells[0].Value.ToString();
                            rb002001.Checked = Convert.ToBoolean(dgv002001.SelectedRows[0].Cells[1].Value);
                            rb002002.Checked = !Convert.ToBoolean(dgv002001.SelectedRows[0].Cells[1].Value);
                            txt002002.Text = dgv002001.SelectedRows[0].Cells[2].Value.ToString();
                            txt002003.Text = dgv002001.SelectedRows[0].Cells[3].Value.ToString();
                            txt002004.Text = dgv002001.SelectedRows[0].Cells[4].Value.ToString();
                            txt002005.Text = dgv002001.SelectedRows[0].Cells[5].Value.ToString();

                            // تحديث التصنيف
                            filltblCurrentProductCategory();
                            lblCurrentCategoryNumberEventsAndProperties(true);
                            lblCurrentCategoryEventsAndProperties(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmProductsAndServices09 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }
                };

                dgv002001.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv002001);  // تخصيص خصائص جدول عرض البيانات
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
                    GeneralAction.AddNewNotification("frmProductsAndServices09 >> lblCurrentCategoryNumberEventsAndProperties Properties", DateTime.Now, ex.Message, ex.Message);
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
                    GeneralAction.AddNewNotification("frmProductsAndServices09 >> lblCurrentCategoryNumberEventsAndProperties  Events", DateTime.Now, ex.Message, ex.Message);
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
                    GeneralAction.AddNewNotification("frmProductsAndServices09 >> lblCurrentCategoryEventsAndProperties Properties", DateTime.Now, ex.Message, ex.Message);
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
                    GeneralAction.AddNewNotification("frmProductsAndServices09 >> lblCurrentCategoryEventsAndProperties Events ", DateTime.Now, ex.Message, ex.Message);
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
                        if (Permissions.AccountHavePermission(PermissionObjectes.Products_And_Services, PermissionType.Edit))
                        {
                            if (!string.IsNullOrEmpty(lblCurrentCategoryNumber.Text) && !string.IsNullOrEmpty(txt002001.Text))
                            {
                                string[] result = null;
                                DataTools.DataBases.Run(ref result, "delete from TblProductsOrServicesAndCategory where CateGOryNo =  @CateGOryNo and productOrServiceNumber = @productOrServiceNumber ", CommandType.Text, new object[][] { new object[] { "@CateGOryNo", lblCurrentCategoryNumber.Text }, new object[] { "@productOrServiceNumber", txt002001.Text } });
                            }

                            if (!string.IsNullOrEmpty(txtCategoryNumber.Text) && !string.IsNullOrEmpty(txt002001.Text))
                            {
                                string[] result = null;
                                DataTools.DataBases.Run(ref result, "insert into TblProductsOrServicesAndCategory values (@CateGOryNo,@productOrServiceNumber)", CommandType.Text, new object[][] { new object[] { "@CateGOryNo", txtCategoryNumber.Text }, new object[] { "@productOrServiceNumber", txt002001.Text } });
                            }

                            filltblCurrentProductCategory();
                            lblCurrentCategoryNumberEventsAndProperties(true);
                            lblCurrentCategoryEventsAndProperties(true);
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmProductsAndServices09 >> btnSaveNewCategoryEventsAndProperties 1", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmProductsAndServices09 >> btnSaveNewCategoryEventsAndProperties 2", DateTime.Now, ex.Message, ex.Message);
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
                    GeneralAction.AddNewNotification("frmProductsAndServices09 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    GeneralAction.AddNewNotification("frmProductsAndServices09 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                        GeneralAction.AddNewNotification("frmProductsAndServices09 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }
                };


            }
        }

        // اعادة جدول بتصنيفات المنتج
        private void filltblCurrentProductCategory()
        {
            try
            {
                if(!string.IsNullOrEmpty(txt002001.Text.Replace("'", "").Trim()) )
                {
                    if (tblCurrentProductCategory is null) tblCurrentProductCategory = new DataTable();
                    if (tblCurrentProductCategory.Rows.Count > 0) tblCurrentProductCategory.Rows.Clear();
                    // تم اختيار هذه الطريقة لان كمية البيانات العائدة كبير جدا وليس من الجيد الاحتفاظ بها على الرام
                    tblCurrentProductCategory = DataTools.DataBases.ReadTabel(@"select * from TblCategories inner join TblProductsOrServicesAndCategory on TblCategories.CategoryNo = TblProductsOrServicesAndCategory.CateGOryNo inner join TblProductsAndServices on TblProductsOrServicesAndCategory.productOrServiceNumber = TblProductsAndServices.productOrServiceNumber where TblProductsAndServices.ProductOrServiceNumber = " + txt002001.Text.Replace("'", ""));

                }
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmProductsAndServices09 >> filltblCurrentProductCategory ", DateTime.Now, ex.Message, ex.Message);
            }

        }

        //-----
        DataTable TblProductsAndServices = new DataTable(); // جدول السلع والخدمات 

        private void fillTblProductsAndServices()
        {
            try
            {
                if(TblProductsAndServices == null) TblProductsAndServices = new DataTable();
                if (TblProductsAndServices.Rows.Count > 0)
                {
                    TblProductsAndServices.Rows.Clear();
                }


                TblProductsAndServices = DataTools.DataBases.ReadTabel("select * from TblProductsAndServices  ");

            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmProductsAndServices09 >> fillTblProducts ", DateTime.Now, ex.Message, ex.Message);
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
                GeneralAction.AddNewNotification("frmProductsAndServices09 >> filltblCategories ", DateTime.Now, ex.Message, ex.Message);
            }
        }
    }


}

