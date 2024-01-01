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
    public partial class frmEncapsulationUnits13 : Form
    {
        public frmEncapsulationUnits13()
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
            lbl08001002001EventsAndProperties(Properties, Events); // ملصق رقم وحدة التغليف
            txt08001002001EventsAndProperties(Properties, Events); // مربع نص رقم وحدة التغليف
            lbl08001002002EventsAndProperties(Properties, Events); // ملصق اسم وحدة التغليف عربي
            txt08001002002EventsAndProperties(Properties, Events); // مربع نص اسم وحدة التغليف عربي
            lbl08001002003EventsAndProperties(Properties, Events); // ملصق اسم وحدة التغليف انجليزي
            txt08001002003EventsAndProperties(Properties, Events); // مربع نص اسم وحدة التغليف انجليزي*

            lbl08001002004EventsAndProperties(Properties, Events); // ملصق رمز وحدة التغليف عربي
            txt08001002004EventsAndProperties(Properties, Events); // مربع نص رمز وحدة التغليف عربي
            lbl08001002005EventsAndProperties(Properties, Events); // ملصق رمز وحدة التغليف انجليزي
            txt08001002005EventsAndProperties(Properties, Events); // مربع نص رمز وحدة التغليف انجليزي


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
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "وحدات التغليف", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "وحدات التغليف", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
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

        private void lbl08001002001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم وحدة التغليف
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم وحدة التغليف", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم وحدة التغليف", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم وحدة التغليف
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
        private void lbl08001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق اسم وحدة التغليف عربي
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "اسم الوحدة عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "اسم الوحدة عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002002EventsAndProperties(bool Properties = true, bool Events = false) // مربع نص اسم وحدة التغليف عربي
        {
            string cultureInfo = "ar-sa";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, cultureInfo,50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, cultureInfo,50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002002.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt08001002003.Select(); };

                };
            }
        }
        private void lbl08001002003EventsAndProperties(bool Properties, bool Events = false)  // ملصق اسم وحدة التغليف انجليزي
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "اسم الوحدة انجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "اسم الوحدة انجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص اسم وحدة التغليف انجليزي
        {
            string cultureInfo = "en-us";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, cultureInfo,50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, cultureInfo,50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002003.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt08001002004.Select(); };
                };
            }
        }

        private void lbl08001002004EventsAndProperties(bool Properties, bool Events = false) // ملصق رمز وحدة التغليف عربي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "رمز الوحدة عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "رمز الوحدة عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002004EventsAndProperties(bool Properties = true, bool Events = false) // مربع نص رمز وحدة التغليف عربي
        {
            string cultureInfo = "ar-sa";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, cultureInfo,15);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, cultureInfo,15, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002004.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt08001002005.Select(); };

                };
            }
        }
        private void lbl08001002005EventsAndProperties(bool Properties, bool Events = false) // ملصق رمز وحدة التغليف انجليزي 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002005, "رمز الوحدة انجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002005, "رمز الوحدة انجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002005EventsAndProperties(bool Properties, bool Events = false) // مربع نص رمز وحدة التغليف انجليزي
        {
            string cultureInfo = "en-us";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002005, cultureInfo,15);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002005, cultureInfo,15, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002005.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btn08001002002.PerformClick(); };
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
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم وحدة التغليف عربي");
                                txt08001002002.Focus();
                            }
                            else if (txt08001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم وحدة التغليف إنجليزي");
                                txt08001002003.Focus();
                            }
                            else if (txt08001002004.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل رمز وحدة التغليف عربي");
                                txt08001002004.Focus();
                            }
                            else if (txt08001002005.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل رمز وحدة التغليف إنجليزي");
                                txt08001002005.Focus();
                            }
                            else
                            {
                                bool? SameArabicCompanyName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002002.Text.Replace("'", ""), 1);
                                bool? SameEnglishCompanyName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002003.Text.Replace("'", ""), 2);
                                bool? SameArabicCompanyCode = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002004.Text.Replace("'", ""), 3);
                                bool? SameEnglishCompanyCode = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002005.Text.Replace("'", ""), 4);

                                if (SameArabicCompanyName == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد وحدة بنفس إسم الوحدة العربي");
                                    txt08001002002.Focus();

                                }
                                else
                                {
                                    if (SameEnglishCompanyName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد وحدة بنفس إسم الوحدة الإنجليزي");
                                        txt08001002003.Focus();
                                    }
                                    else
                                    {
                                        if(SameArabicCompanyCode == true)
                                        {
                                            Error = Cultures.ReturnTranslation("توجد وحدة بنفس رمز الوحدة العربي");
                                            txt08001002004.Focus();
                                        }
                                        else
                                        {
                                            if (SameEnglishCompanyCode == true)
                                            {
                                                Error = Cultures.ReturnTranslation("توجد وحدة بنفس رمز الوحدة الانجليزي");
                                                txt08001002005.Focus();
                                            }
                                        }
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string[] result = null;
                                object result2 = DataTools.DataBases.Run(ref result, "insert into TblEncapsulationUnits values (@UnitNameAR,@UnitNameEN,@UnitCodeAR,@UnitCodeEN)", CommandType.Text, new object[][] { new object[] { "@UnitNameAR", txt08001002002.Text }, new object[] { "@UnitNameEN", txt08001002003.Text }, new object[] { "@UnitCodeAR", txt08001002004.Text }, new object[] { "@UnitCodeEN", txt08001002005.Text }  });


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

                                    dgv08001.Enabled = true;

                                    // تحديث بيانات جدول وحدات التغليف
                                    fillTblEncapsulationUnits(); // تعبئة جدول  وحدات التغليف
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
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم وحدة التغليف عربي");
                                txt08001002002.Focus();
                            }
                            else if (txt08001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم وحدة التغليف إنجليزي");
                                txt08001002003.Focus();
                            }
                            else if (txt08001002004.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل رمز وحدة التغليف عربي");
                                txt08001002004.Focus();
                            }
                            else if (txt08001002005.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل رمز وحدة التغليف إنجليزي");
                                txt08001002005.Focus();
                            }
                            else
                            {
                                bool? SameArabicCompanyName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002002.Text.Replace("'", ""), 1);
                                bool? SameEnglishCompanyName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002003.Text.Replace("'", ""), 2);
                                bool? SameArabicCompanyCode = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002004.Text.Replace("'", ""), 3);
                                bool? SameEnglishCompanyCode = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002005.Text.Replace("'", ""), 4);

                                if (SameArabicCompanyName == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد وحدة بنفس إسم الوحدة العربي");
                                    txt08001002002.Focus();

                                }
                                else
                                {
                                    if (SameEnglishCompanyName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد وحدة بنفس إسم الوحدة الإنجليزي");
                                        txt08001002003.Focus();
                                    }
                                    else
                                    {
                                        if (SameArabicCompanyCode == true)
                                        {
                                            Error = Cultures.ReturnTranslation("توجد وحدة بنفس رمز الوحدة العربي");
                                            txt08001002004.Focus();
                                        }
                                        else
                                        {
                                            if (SameEnglishCompanyCode == true)
                                            {
                                                Error = Cultures.ReturnTranslation("توجد وحدة بنفس رمز الوحدة الانجليزي");
                                                txt08001002005.Focus();
                                            }
                                        }
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string[] result = null;
                                object result2 = DataTools.DataBases.Run(ref result, "update TblEncapsulationUnits set UnitNameAR = @UnitNameAR,UnitNameEN = @UnitNameEN  ,UnitCodeAR = @UnitCodeAR   ,UnitCodeEN = @UnitCodeEN    where EncapsulationUnitsNo = @EncapsulationUnitsNo ", CommandType.Text,  new object[][] { new object[] { "@UnitNameAR", txt08001002002.Text }, new object[] { "@UnitNameEN", txt08001002003.Text }, new object[] { "@UnitCodeAR", txt08001002004.Text }, new object[] { "@UnitCodeEN", txt08001002005.Text }, new object[] { "@EncapsulationUnitsNo", txt08001002001.Text } });


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

                                    dgv08001.Enabled = true;

                                    // تحديث بيانات جدول وحدات التغليف
                                    fillTblEncapsulationUnits();
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
                            DataTools.DataBases.Run(ref result, "delete from TblEncapsulationUnits where EncapsulationUnitsNo = @EncapsulationUnitsNo", CommandType.Text, new object[][] { new object[] { "@EncapsulationUnitsNo", txt08001002001.Text } });

                            if (result[1] == "succeeded")
                            {
                                txt08001002001.Text = "";
                                txt08001002002.Text = "";
                                txt08001002003.Text = "";
                                txt08001002004.Text = "";
                                txt08001002005.Text = "";

                                txtSearch.Text = "";

                                // تحديث بيانات جدول البيانات
                                fillTblEncapsulationUnits();
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
                    if (TblEncapsulationUnits.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblEncapsulationUnits;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم وحدة التغليف");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("اسم الوحدة عربي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("اسم الوحدة انجليزي");
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
                    fillTblEncapsulationUnits(); // تعبئة جدول الشركات الصانعة

                    if (TblEncapsulationUnits.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblEncapsulationUnits;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم وحدة التغليف");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("اسم الوحدة عربي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("اسم الوحدة انجليزي");
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
                            txt08001002004.Text = dgv08001.SelectedRows[0].Cells[3].Value.ToString();
                            txt08001002005.Text = dgv08001.SelectedRows[0].Cells[4].Value.ToString();

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
                ElementsTools.TextBox_.CustumProperties(txtSearch, "",50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txtSearch.TextChanged += delegate
                {
                    try
                    {
                        DataView dv = new DataView(TblEncapsulationUnits);
                        string filter = "";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            filter = "UnitNameAR like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        else
                        {
                            filter = "UnitNameEN like '%" + txtSearch.Text.Replace("'", "") + "%'";
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
        DataTable TblEncapsulationUnits = new DataTable(); // جدول وحدات التغليف 

        // تعبئة جدول وحدات التغليف
        private void fillTblEncapsulationUnits()
        {
            try
            {
                if (TblEncapsulationUnits.Rows.Count > 0)
                {
                    TblEncapsulationUnits.Rows.Clear();
                }

                if (TblEncapsulationUnits.Rows.Count > 0) TblEncapsulationUnits.Rows.Clear();

                TblEncapsulationUnits = DataTools.DataBases.ReadTabel("select * from TblEncapsulationUnits ");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmEncapsulationUnits13 >> btn08001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
            }
        }


    }


}

