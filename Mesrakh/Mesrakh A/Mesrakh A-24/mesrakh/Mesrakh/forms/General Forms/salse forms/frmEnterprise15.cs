using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mesrakh
{
    public partial class frmEnterprise15 : Form
    {
        public frmEnterprise15()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmEncapsulationUnits13EventsAndProperties(Properties, Events); // النموذج
            pnl08001EventsAndProperties(Properties, Events);// الحاوية الرئيسية
            pnl08001001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl08001001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl08001002EventsAndProperties(Properties, Events); // الحاوية الثانية

            lbl08001002001EventsAndProperties(Properties, Events); // ملصق رقم المنشأة
            txt08001002001EventsAndProperties(Properties, Events); // مربع نص رقم المنشأة
            lbl08001002002EventsAndProperties(Properties, Events); // ملصق اسم المنشأة عربي
            txt08001002002EventsAndProperties(Properties, Events); // مربع نص اسم المنشأة عربي
            lbl08001002003EventsAndProperties(Properties, Events); // ملصق اسم المنشأة انجليزي
            txt08001002003EventsAndProperties(Properties, Events); // مربع نص اسم المنشأة انجليزي*
            lbl08001002004EventsAndProperties(Properties, Events); // ملصق تفاصيل
            txt08001002004EventsAndProperties(Properties, Events); // مربع نص تفاصيل
            lbl08001002005EventsAndProperties(Properties, Events); // ملصق نسبة الضريبة
            txt08001002005EventsAndProperties(Properties, Events); // مربع نص نسبة الضريبة

            pictureBox1EventsAndProperties(Properties, Events); // شعار المنشأة
            btnChosenImageEventsAndProperties(Properties, Events); // زر اختيار صورة
            btnDeleteImageEventsAndProperties(Properties, Events); // زر حذف الصورة


            btn08001002001EventsAndProperties(Properties, Events); // جديد
            btn08001002002EventsAndProperties(Properties, Events); // حفظ
            btn08001002003EventsAndProperties(Properties, Events); // تعديل
            btn08001002004EventsAndProperties(Properties, Events); // حذف
            dgv08001EventsAndProperties(Properties, Events); // جدول عرض بيانات وحدات التغليف
            //-------- البحث
            lblSearchEventsAndProperties(Properties, Events);// ملصق البحث عن
            txtSearchEventsAndProperties(Properties, Events);// مربع نص البحث عن


        }

        private void frmEncapsulationUnits13EventsAndProperties(bool Properties, bool Events = false) // النموذج 
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
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "المنشآت", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "المنشآت", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
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

        private void lbl08001002001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم المنشأة
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم المنشأة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم المنشأة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم المنشأة
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
        private void lbl08001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق اسم المنشأة عربي
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "إسم المنشأة عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "إسم المنشأة عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002002EventsAndProperties(bool Properties = true, bool Events = false) // مربع نص اسم المنشأة عربي
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
        private void lbl08001002003EventsAndProperties(bool Properties, bool Events = false)  // ملصق إسم المنشأة إنجليزي
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "إسم المنشأة إنجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "إسم المنشأة إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم المنشأة انجليزي
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

        private void lbl08001002004EventsAndProperties(bool Properties, bool Events = false) // ملصق تفاصيل 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "تفاصيل", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "تفاصيل", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002004EventsAndProperties(bool Properties = true, bool Events = false) // مربع نص details
        {
            string cultureInfo = "ar-sa";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, cultureInfo,200);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, cultureInfo,200, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002004.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt08001002005.Focus(); };

                };
            }
        }


        private void lbl08001002005EventsAndProperties(bool Properties, bool Events = false) // ملصق نسبة الضريبة 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002005, "نسبة الضريبة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002005, "نسبة الضريبة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002005EventsAndProperties(bool Properties = true, bool Events = false) // مربع نص نسبة الضريبة
        {
            string cultureInfo = "ar-sa";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002005, cultureInfo, 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Int);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002005, cultureInfo, 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true,TextBoxType.Int);

                txt08001002005.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btnChosenImage.Focus(); };

                };
            }
        }


        //----------------------------------------------------

        private void pictureBox1EventsAndProperties(bool Properties, bool Events = false) // شعار المنشأة
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.PictureBox_.CustumProperties(pictureBox1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.PictureBox_.CustumProperties(pictureBox1, ColorPropertyName.BackColor_1 , true, true);

            }
        }

        private void btnChosenImageEventsAndProperties(bool Properties, bool Events = false) // زر اختيار صورة
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btnChosenImage, "إختيار صورة");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btnChosenImage, "إختيار صورة");

                btnChosenImage.Click += delegate 
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    if(ofd.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image = Images.OpenImageFileThenReturnImageVareableWithCheangeSizeAndType(ofd.FileName,System.Drawing.Imaging.ImageFormat.Png,250,250);

                    }
                };
            }
        }

        private void btnDeleteImageEventsAndProperties(bool Properties, bool Events = false) // زر حذف الصورة
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btnDeleteImage, "حذف الصورة");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btnDeleteImage, "حذف الصورة");

                btnDeleteImage.Click += delegate
                {
                    pictureBox1.Image = new PictureBox().Image;
                };
            }
        }

        //**********************************************************
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
                        if (Permissions.AccountHavePermission(PermissionObjectes.Encapsulation_Units, PermissionType.Add))
                        {

                            if (btn08001002001.Text == Cultures.ReturnTranslation("جديد"))
                            {
                                btn08001002001.Text = Cultures.ReturnTranslation("إلغاء");

                                txt08001002002.Enabled = true;
                                txt08001002003.Enabled = true;
                                txt08001002004.Enabled = true;
                                txt08001002005.Enabled = true;

                                txt08001002001.Text = "";
                                txt08001002002.Text = "";
                                txt08001002003.Text = "";
                                txt08001002004.Text = "";
                                txt08001002005.Text = "";

                                txt08001002002.Focus();

                                btn08001002002.Enabled = true;
                                btn08001002003.Enabled = false;
                                btn08001002004.Enabled = false;

                                btnChosenImage.Enabled = true;
                                btnDeleteImage.Enabled = true;

                                pictureBox1.Image = new PictureBox().Image;

                                dgv08001.Enabled = false;
                            }
                            else
                            {
                                btn08001002001.Text = Cultures.ReturnTranslation("جديد");

                                txt08001002002.Enabled = false;
                                txt08001002003.Enabled = false;
                                txt08001002004.Enabled = false;
                                txt08001002005.Enabled = false;

                                btn08001002002.Enabled = false;
                                btn08001002003.Enabled = true;
                                btn08001002004.Enabled = true;

                                btnChosenImage.Enabled = false;
                                btnDeleteImage.Enabled = false;

                                dgv08001.Enabled = true;
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmEncapsulationUnits13 >> btn08001002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEncapsulationUnits13 >> btn08001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                            if (txt08001002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم المنشأة عربي");
                                txt08001002002.Focus();
                            }
                            else if (txt08001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم المنشأة إنجليزي");
                                txt08001002003.Focus();
                            }
                            else
                            {
                                bool? SameArabicName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002002.Text.Replace("'", ""), 1);
                                bool? SameEnglishName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002003.Text.Replace("'", ""), 2);

                                if (SameArabicName == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد منشأة بنفس الإسم العربي");
                                    txt08001002002.Focus();

                                }
                                else
                                {
                                    if (SameEnglishName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد منشأة بنفس الإسم الإنجليزي");
                                        txt08001002003.Focus();
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string ss = "";
                                if(pictureBox1.Image != null)
                                {
                                    ss = Images.ConvertImageToBase64String(pictureBox1.Image);
                                }
                                else
                                {
                                   
                                    return;
                                }

                                string[] result = null;
                                object result2 = DataTools.DataBases.Run(ref result, "insert into TblEnterprise values (@EnterpriseNameAR,@EnterpriseNameEN,@EnterpriseIcon,@EnterpriseDetails , @VATrate)", 
                                    CommandType.Text, new object[][] 
                                    { new object[] { "@EnterpriseNameAR", txt08001002002.Text }, 
                                        new object[] { "@EnterpriseNameEN", txt08001002003.Text },
                                        new object[] { "@EnterpriseIcon", ss }, 
                                        new object[] { "@EnterpriseDetails", txt08001002004.Text },
                                        new object[] { "@VATrate", txt08001002005.Text }});


                                if(result[1] == "succeeded")
                                {
                                    txt08001002002.Enabled = false;
                                    txt08001002003.Enabled = false;
                                    txt08001002004.Enabled = false;
                                    txt08001002005.Enabled = false;

                                    btn08001002001.Enabled = true;
                                    btn08001002002.Enabled = false;
                                    btn08001002003.Enabled = true;
                                    btn08001002004.Enabled = true;

                                    btnChosenImage.Enabled = false;
                                    btnDeleteImage.Enabled = false;

                                    dgv08001.Enabled = true;

                                    // تحديث بيانات جدول وحدات التغليف
                                    fillTblEnterprise(); // تعبئة جدول  وحدات التغليف
                                    AllEventsAndProperties(true); // تم تحديث جميع الخصائص لتعود الازرار لوضعها الطبيعي
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
                            if (txt08001002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم المنشأة عربي");
                                txt08001002002.Focus();
                            }
                            else if (txt08001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم المنشأة إنجليزي");
                                txt08001002003.Focus();
                            }
                            else
                            {
                                bool? SameArabicName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002002.Text.Replace("'", ""), 1);
                                bool? SameEnglishName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002003.Text.Replace("'", ""), 2);

                                if (SameArabicName == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد منشأة بنفس الإسم العربي");
                                    txt08001002002.Focus();

                                }
                                else
                                {
                                    if (SameEnglishName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد منشأة بنفس الإسم الإنجليزي");
                                        txt08001002003.Focus();
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string[] result = null;
                                object result2 = DataTools.DataBases.Run(ref result, "update TblEnterprise set EnterpriseNameAR = @EnterpriseNameAR,EnterpriseNameEN = @EnterpriseNameEN  ,EnterpriseIcon = @EnterpriseIcon   ,EnterpriseDetails = @EnterpriseDetails   , VATrate = @VATrate   where EnterpriseNo = @EnterpriseNo ", CommandType.Text,  new object[][] { new object[] { "@EnterpriseNameAR", txt08001002002.Text }, new object[] { "@EnterpriseNameEN", txt08001002003.Text }, new object[] { "@EnterpriseIcon", Images.ConvertImageToBase64String(pictureBox1.Image) }, new object[] { "@EnterpriseDetails", txt08001002004.Text }, new object[] { "@VATrate", txt08001002005.Text } , new object[] { "@EnterpriseNo", txt08001002001.Text } });


                                if (result[1] == "succeeded")
                                {

                                    txt08001002002.Enabled = false;
                                    txt08001002003.Enabled = false;
                                    txt08001002004.Enabled = false;
                                    txt08001002005.Enabled = false;

                                    btn08001002001.Enabled = true;
                                    btn08001002002.Enabled = false;
                                    btn08001002003.Enabled = true;
                                    btn08001002004.Enabled = true;

                                    btnChosenImage.Enabled = false;
                                    btnDeleteImage.Enabled = false;

                                    dgv08001.Enabled = true;

                                    // تحديث بيانات جدول وحدات التغليف
                                    fillTblEnterprise();
                                    AllEventsAndProperties(true);
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
                        GeneralAction.AddNewNotification("frmEncapsulationUnits13 >> btn08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    if (Permissions.AccountHavePermission(PermissionObjectes.Encapsulation_Units, PermissionType.Edit))
                    {
                        if (btn08001002003.Enabled)
                        {
                            if (btn08001002003.Text == Cultures.ReturnTranslation("تعديل"))
                            {
                                btn08001002003.Text = Cultures.ReturnTranslation("إلغاء");

                                txt08001002002.Enabled = true;
                                txt08001002003.Enabled = true;
                                txt08001002004.Enabled = true;
                                txt08001002005.Enabled = true;

                                btn08001002001.Enabled = false;
                                btn08001002002.Enabled = true;
                                btn08001002004.Enabled = false;

                                btnChosenImage.Enabled = true;
                                btnDeleteImage.Enabled = true;

                                dgv08001.Enabled = false;
                            }
                            else
                            {
                                btn08001002003.Text = Cultures.ReturnTranslation("تعديل");

                                txt08001002002.Enabled = false;
                                txt08001002003.Enabled = false;
                                txt08001002004.Enabled = false;
                                txt08001002005.Enabled = false;

                                btn08001002001.Enabled = true;
                                btn08001002002.Enabled = false;
                                btn08001002004.Enabled = true;

                                btnChosenImage.Enabled = false;
                                btnDeleteImage.Enabled = false;

                                dgv08001.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEncapsulationUnits13 >> btn08001002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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
                    if (Permissions.AccountHavePermission(PermissionObjectes.Encapsulation_Units, PermissionType.Delete))
                    {
                        try
                        {

                            string[] result = null;
                            DataTools.DataBases.Run(ref result, "delete from TblEnterprise where EnterpriseNo = @EnterpriseNo", CommandType.Text, new object[][] { new object[] { "@EnterpriseNo", txt08001002001.Text } });

                            if (result[1] == "succeeded")
                            {
                                txt08001002001.Text = "";
                                txt08001002002.Text = "";
                                txt08001002003.Text = "";
                                txt08001002004.Text = "";
                                txt08001002005.Text = "";

                                pictureBox1.Image = new PictureBox().Image;


                                txtSearch.Text = "";

                                // تحديث بيانات جدول البيانات
                                fillTblEnterprise();
                                dgv08001EventsAndProperties(true);
                            }

                        }
                        catch (Exception ex)
                        {
                            GeneralAction.AddNewNotification("frmEncapsulationUnits13 >> btn08001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        }


                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEncapsulationUnits13 >> btn08001002004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }


                };
            }
        }

        private void dgv08001EventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات وحدات التغليف
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblEnterprise.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblEnterprise;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم المنشأة");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم المنشأة عربي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم المنشأة إنجليزي");
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
                        dgv08001.Columns[4].Visible = false;
                        dgv08001.Columns[5].Visible = false;

                        dgv08001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
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
                    GeneralAction.AddNewNotification("frmEncapsulationUnits13 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                }
            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblEnterprise(); // تعبئة جدول المنشآت

                    if (TblEnterprise.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblEnterprise;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم المنشأة");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم المنشأة عربي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم المنشأة إنجليزي");
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
                        dgv08001.Columns[4].Visible = false;
                        dgv08001.Columns[5].Visible = false;


                        dgv08001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
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
                    GeneralAction.AddNewNotification("frmEncapsulationUnits13 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

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
                            pictureBox1.Image = Images.ConvertBase64StringToImage(dgv08001.SelectedRows[0].Cells[3].Value.ToString());
                            txt08001002004.Text = dgv08001.SelectedRows[0].Cells[4].Value.ToString();
                            txt08001002005.Text = dgv08001.SelectedRows[0].Cells[5].Value.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEncapsulationUnits13 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                    }
                };

                dgv08001.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات

                };
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

        private void txtSearchEventsAndProperties(bool Properties, bool Events = false) // مربع نص البحث عن وحدات التخزين
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txtSearch,"",50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtSearch, "", 50,ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txtSearch.TextChanged += delegate
                {
                    try
                    {
                        DataView dv = new DataView(TblEnterprise);
                        string filter = "";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            filter = "EnterpriseNameAR like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        else
                        {
                            filter = "EnterpriseNameEN like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        dv.RowFilter = filter;
                        dgv08001.DataSource = dv;
                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEncapsulationUnits13 >> txtSearchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }





        //------------------------------ 
        DataTable TblEnterprise = new DataTable(); // جدول المنشآت 

        // تعبئة جدول وحدات التغليف
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
                GeneralAction.AddNewNotification("frmEncapsulationUnits13 >> fillTblEnterprise ", DateTime.Now, ex.Message, ex.Message);
            }
        }
    }


}

