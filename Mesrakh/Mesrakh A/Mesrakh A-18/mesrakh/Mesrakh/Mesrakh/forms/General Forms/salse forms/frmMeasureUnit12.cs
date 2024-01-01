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
    public partial class frmMeasureUnit12 : Form
    {
        public frmMeasureUnit12()
        {
            InitializeComponent();
            AllfrmMeasureUnit12ElementsEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllfrmMeasureUnit12ElementsEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmfrmMeasureUnit12EventsAndProperties(Properties, Events); // النموذج
            pnl08001EventsAndProperties(Properties, Events);// الحاوية الرئيسية
            pnl08001001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl08001001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl08001002EventsAndProperties(Properties, Events); // الحاوية الثانية

            lbl08001002001EventsAndProperties(Properties, Events);// ملصق رقم وحدة القياس 
            txt08001002001EventsAndProperties(Properties, Events);// مربع نص رقم وحدة القياس
            lbl08001002002EventsAndProperties(Properties, Events);//  ملصق إسم وحدة القياس عربي
            txt08001002002EventsAndProperties(Properties, Events);// مربع نص إسم وحدة القياس عربي
            lbl08001002003EventsAndProperties(Properties, Events);// ملصق إسم وحدة القياس انجليزي
            txt08001002003EventsAndProperties(Properties, Events);// مربع نص إسم وحدة القياس انجليزي
            lbl08001002004EventsAndProperties(Properties, Events);// ملصق رمز وحدة القياس عربي 
            txt08001002004EventsAndProperties(Properties, Events);// مربع رمز وحدة القياس عربي
            lbl08001002005EventsAndProperties(Properties, Events);// ملصق وحدة القياس إنجليزي
            txt08001002005EventsAndProperties(Properties, Events);// مربع نص وحدة القياس إنجليزي
            lblManufacturersEventsAndProperties(Properties, Events);// ملصق وحدة القياس الأعلى
            cbx08001002001EventsAndProperties(Properties, Events);// قائمة منسدلة وحدة القياس الأعلى
            lbl08001002006EventsAndProperties(Properties, Events);// ملصق قيمة التحويل من الوحدة الأعلى 
            txt08001002006EventsAndProperties(Properties, Events);// مربع نص قيمة التحويل من الوحدة الأعلى

            btn08001002001EventsAndProperties(Properties, Events); // جديد
            btn08001002002EventsAndProperties(Properties, Events); // حفظ
            btn08001002003EventsAndProperties(Properties, Events); // تعديل
            btn08001002004EventsAndProperties(Properties, Events); // حذف
            tvEventsAndProperties(Properties, Events); // شجرة عرض الحسابات
            dgv08001EventsAndProperties(Properties, Events); // جدول عرض بيانات الحسابات
            //-------- البحث
            lblSearchEventsAndProperties(Properties, Events);// ملصق البحث عن
            txtSearchEventsAndProperties(Properties, Events);// مربع نص البحث عن

        }

        private void frmfrmMeasureUnit12EventsAndProperties(bool Properties, bool Events = false) // النموذج 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Form_.CustumProperties(this);
                tooltip();
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Form_.CustumProperties(this, ColorPropertyName.BackColor_3, true, true);
                tooltip();

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
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "وحدات القياس", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "وحدات القياس", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
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



        private void lbl08001002001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم وحدة القياس
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم وحدة القياس", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم وحدة القياس", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم وحدة القياس
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002001);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002001, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002002.Select();
                    }
                };
            }
        }

        private void lbl08001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم الوحدة عربي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "إسم الوحدة عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "إسم الوحدة عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002002EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم الوحدة عربي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, "ar-SA");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, "ar-SA", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt08001002002.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if(mye.KeyData == Keys.Enter)
                    {
                        txt08001002003.Select();
                    }
                };
            }
        }

        private void lbl08001002003EventsAndProperties(bool Properties, bool Events = false) //ملصق إسم الوحدةانجليزي
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "إسم الوحدةانجليزي", ColorPropertyName.BackColor_1);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "إسم الوحدةانجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

            }
        }

        private void txt08001002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم الوحدة انجليزي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, "en-US");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, "en-US", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002003.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002004.Select();
                    }
                };
            }
        }



        private void lbl08001002004EventsAndProperties(bool Properties, bool Events = false) //ملصق رمز الوحدة عربي 
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

        private void txt08001002004EventsAndProperties(bool Properties, bool Events = false) //مربع رمز الوحدة عربي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, "ar-SA");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, "ar-SA", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002004.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002005.Select();
                    }
                };
            }
        }

        private void lbl08001002005EventsAndProperties(bool Properties, bool Events = false) // ملصق رمز الوحدة إنجليزي
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002005, "رمز الوحدة إنجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002005, "رمز الوحدة إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002005EventsAndProperties(bool Properties, bool Events = false) // مربع نص  رمز الوحدة إنجليزي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002005, "en-US");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002005, "en-US", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002005.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx08001002001.Select();
                    }
                };
            }
        }

        private void lblManufacturersEventsAndProperties(bool Properties, bool Events = false) // ملصق الوحدة الأعلى
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblTopAccountNo, "الوحدة الأعلى", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblTopAccountNo, "الوحدة الأعلى", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void cbx08001002001EventsAndProperties(bool Properties, bool Events = false) //قائمة منسدلة الوحدة الأعلى
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblMeasureUnitForDgv is null) return;
                    if (TblMeasureUnitForDgv.Rows.Count > 0)
                    {
                        cbx08001002001.DataSource = TblMeasureUnitForCbx;
                        cbx08001002001.ValueMember = "MeasureUnitNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx08001002001.DisplayMember = "UnitNameAR";
                        }
                        else
                        {
                            cbx08001002001.DisplayMember = "UnitNameEN";
                        }
                        ElementsTools.ComboBox_.CustumProperties(cbx08001002001);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureUnit12 >> cbx08001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {

                try
                {
                    fillTblMeasureUnit();

                    if (TblMeasureUnitForDgv is null) return;
                    if (TblMeasureUnitForDgv.Rows.Count > 0)
                    {
                        cbx08001002001.DataSource = TblMeasureUnitForCbx;
                        cbx08001002001.ValueMember = "MeasureUnitNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx08001002001.DisplayMember = "UnitNameAR";
                        }
                        else
                        {
                            cbx08001002001.DisplayMember = "UnitNameEN";
                        }
                        ElementsTools.ComboBox_.CustumProperties(cbx08001002001);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureUnit12 >> cbx08001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx08001002001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002006.Select();
                    }
                };



            }
        }

        private void lbl08001002006EventsAndProperties(bool Properties, bool Events = false) // ملصق قيمة التحويل من الوحدة الأعلى 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002006, "قيمة التحويل", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002006, "قيمة التحويل", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002006EventsAndProperties(bool Properties, bool Events = false) // مربع نص قيمة التحويل من الوحدة الأعلى
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002006, "",ColorPropertyName.BackColor_1,ColorPropertyName.ForeColor_1,true,false, TextBoxType.Decimal);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002006, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Decimal);

                txt08001002006.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        btn08001002002.PerformClick();
                    }
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
                    if (Permissions.AccountHavePermission(PermissionObjectes.Measurement_units, PermissionType.Add))
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

                            //dgv08001.Enabled = false;
                            tv.Enabled = false;

                            txt08001002001.Text = "";
                            txt08001002002.Text = "";
                            txt08001002003.Text = "";
                            txt08001002004.Text = "";
                            txt08001002005.Text = "";
                            txt08001002006.Text = "";
                            if (cbx08001002001 != null && cbx08001002001.Items.Count > 0) cbx08001002001.SelectedIndex = -1;




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


                            //dgv08001.Enabled = true;
                            tv.Enabled = true;

                            dgv08001.Focus();
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureUnit12 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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

                        if (btn08001002001.Text == Cultures.ReturnTranslation("إلغاء")) // إضافة
                        {
                            string Error = "";

                            if (txt08001002002.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الوحدة عربي");
                                txt08001002002.Focus();
                            }
                            else if (txt08001002003.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الوحدة إنجليزي");
                                txt08001002003.Focus();
                            }
                            else if (txt08001002004.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل رمز الوحدة عربي");
                                txt08001002004.Focus();
                            }
                            else if (txt08001002005.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل رمز الوحدة إنجليزي");
                                txt08001002005.Focus();
                            }
                            else
                            {
                                // فحص البيانات للتأكد من عدم وجود تكرار في الجدول
                                bool? SameArabicUnitName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002002.Text.Replace("'", ""), 1);
                                bool? SameEnglishUnitName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002003.Text.Replace("'", ""), 2);
                                bool? SameArabicUnitCode = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002004.Text.Replace("'", ""), 3);
                                bool? SameEnglishUnitCode = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002005.Text.Replace("'", ""), 4);


                                if (SameArabicUnitName == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد وحدة بنفس إسم الوحدة العربي");
                                    txt08001002002.Focus();
                                }
                                else
                                {
                                    if (SameEnglishUnitName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد وحدة بنفس إسم الوحدة الإنجليزي");
                                        txt08001002003.Focus();
                                    }
                                    else
                                    {
                                        if (SameArabicUnitCode == true)
                                        {
                                            Error = Cultures.ReturnTranslation("يوجد رمز وحدة بنفس رمز الوحدة العربي");
                                            txt08001002004.Focus();

                                        }
                                        else
                                        {
                                            if (SameEnglishUnitCode == true)
                                            {
                                                Error = Cultures.ReturnTranslation("يوجد رمز وحدة بنفس رمز الوحدة الإنجليزي");
                                                txt08001002005.Focus();

                                            }
                                        }
                                    }


                                }

                            }

                            if (Error == "")
                            {
                                    //---------------------------------------------------------- اضافة 

                                    string[] result = null;
                                    int MeasureUnitNo = (int)DataTools.DataBases.Run(ref result, "spAddMeasureUnit",
                                    CommandType.StoredProcedure, new object[][] {
                                      new object[] { "@UnitNameAR", txt08001002002.Text.Replace("'","") }
                                    , new object[] { "@UnitNameEN", txt08001002003.Text.Replace("'", "") }
                                    , new object[] { "@UnitCodeAR", txt08001002004.Text.Replace("'","") }
                                    , new object[] { "@UnitCodeEN", txt08001002005.Text.Replace("'","") }
                                    , new object[] { "@TopMeasureUnit", cbx08001002001.SelectedValue }
                                    , new object[] { "@EqualFromTopMeasureUnit", txt08001002006.Text.Replace("'", "")  }
                                    , new object[] { "@MeasureUnitNo", "OUT" }
                                    });

                                    if (result[1] == "succeeded")
                                    {


                                        if (GeneralVariables.cultureCode == "AR")
                                        {
                                            TreeNode tn = new TreeNode(txt08001002002.Text.Replace("'", ""));
                                            tn.Tag = MeasureUnitNo;
                                            if (cbx08001002001.SelectedIndex > -1) { ElementsTools.TreeView_.Search(tv, cbx08001002001.SelectedValue).Nodes.Add(tn); } else { tv.Nodes.Add(tn); } // اذا تم تحديد وحدة اعلى يتم الاضافة اليها واذا لم يتم تحديد وحدة اعلى تتم الاضافة على الشجرة العامة

                                        }
                                        else
                                        {
                                            TreeNode tn = new TreeNode(txt08001002003.Text.Replace("'", ""));
                                            tn.Tag = MeasureUnitNo;
                                            if (cbx08001002001.SelectedIndex > -1) { ElementsTools.TreeView_.Search(tv, cbx08001002001.SelectedValue).Nodes.Add(tn); } else { tv.Nodes.Add(tn); }

                                        }

                                        // البيانات الى الجدول
                                        DataRow dr = TblMeasureUnitForDgv.NewRow();
                                        dr[0] = MeasureUnitNo;
                                        dr[1] = txt08001002002.Text.Trim().Replace("'", "");
                                        dr[2] = txt08001002003.Text.Trim().Replace("'", "");
                                        dr[3] = txt08001002004.Text.Trim().Replace("'", "");
                                        dr[4] = txt08001002005.Text.Trim().Replace("'", "");
                                        dr[5] = cbx08001002001.SelectedValue == null ? DBNull.Value : cbx08001002001.SelectedValue;
                                        if (txt08001002006.Text.Trim() == "")
                                        {
                                            dr[6] = DBNull.Value;
                                        }
                                        else
                                        {
                                            dr[6] = txt08001002006.Text.Trim().Replace("'", "");
                                        }
                                        TblMeasureUnitForDgv.Rows.Add(dr);

                                        // البيانات الى الجدول
                                        DataRow drr = TblMeasureUnitForCbx.NewRow();
                                        drr[0] = MeasureUnitNo;
                                        drr[1] = txt08001002002.Text.Trim().Replace("'", "");
                                        drr[2] = txt08001002003.Text.Trim().Replace("'", "");
                                        drr[3] = txt08001002004.Text.Trim().Replace("'", "");
                                        drr[4] = txt08001002005.Text.Trim().Replace("'", "");
                                        drr[5] = cbx08001002001.SelectedValue == null ? DBNull.Value : cbx08001002001.SelectedValue;
                                        if (txt08001002006.Text.Trim() == "")
                                        {
                                            drr[6] = DBNull.Value;
                                        }
                                        else
                                        {
                                            drr[6] = txt08001002006.Text.Trim().Replace("'", "");
                                        }
                                        TblMeasureUnitForCbx.Rows.Add(drr);

                                        // البيانات الى الجدول
                                        DataRow drrr = TblMeasureUnitForTv.NewRow();
                                        drrr[0] = MeasureUnitNo;
                                        drrr[1] = txt08001002002.Text.Trim().Replace("'", "");
                                        drrr[2] = txt08001002003.Text.Trim().Replace("'", "");
                                        drrr[3] = txt08001002004.Text.Trim().Replace("'", "");
                                        drrr[4] = txt08001002005.Text.Trim().Replace("'", "");
                                        drrr[5] = cbx08001002001.SelectedValue == null ? DBNull.Value : cbx08001002001.SelectedValue;
                                        if (txt08001002006.Text.Trim() == "")
                                        {
                                            drrr[6] = DBNull.Value;
                                        }
                                        else
                                        {
                                            drrr[6] = txt08001002006.Text.Trim().Replace("'", "");
                                        }
                                        TblMeasureUnitForTv.Rows.Add(drrr);


                                        if (cbx08001002001.DataSource == null)
                                        {
                                            cbx08001002001.DataSource = TblMeasureUnitForCbx;
                                            cbx08001002001EventsAndProperties(true);
                                        }
                                        if (dgv08001.DataSource == null)
                                        {
                                            dgv08001.DataSource = TblMeasureUnitForDgv;
                                            dgv08001EventsAndProperties(true);
                                        }


                                    }



                                btn08001002001.Text = Cultures.ReturnTranslation("جديد");

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


                                //dgv08001.Enabled = true;
                                tv.Enabled = true;
                                tv.Focus();
                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);

                                txt08001002001.Text = "";
                            }

                        }
                        else if (btn08001002003.Text == Cultures.ReturnTranslation("إلغاء")) //-----------------------------  تعديل
                        {

                            string Error = "";
                            if (txt08001002002.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الوحدة عربي");
                                txt08001002002.Focus();
                            }
                            else if (txt08001002003.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الوحدة إنجليزي");
                                txt08001002003.Focus();
                            }
                            else if (txt08001002004.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل رمز الوحدة عربي");
                                txt08001002004.Focus();
                            }
                            else if (txt08001002005.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل رمز الوحدة إنجليزي");
                                txt08001002005.Focus();
                            }
                            else
                            {
                                // فحص البيانات للتأكد من عدم وجود تكرار في الجدول
                                bool? SameArabicUnitName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002002.Text.Replace("'", ""), 1);
                                bool? SameEnglishUnitName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002003.Text.Replace("'", ""), 2);
                                bool? SameArabicUnitCode = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002004.Text.Replace("'", ""), 3);
                                bool? SameEnglishUnitCode = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002005.Text.Replace("'", ""), 4);


                                if (SameArabicUnitName == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد وحدة بنفس إسم الوحدة العربي");
                                    txt08001002002.Focus();
                                }
                                else
                                {
                                    if (SameEnglishUnitName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد وحدة بنفس إسم الوحدة الإنجليزي");
                                        txt08001002003.Focus();
                                    }
                                    else
                                    {
                                        if (SameArabicUnitCode == true)
                                        {
                                            Error = Cultures.ReturnTranslation("يوجد رمز وحدة بنفس رمز الوحدة العربي");
                                            txt08001002004.Focus();

                                        }
                                        else
                                        {
                                            if (SameEnglishUnitCode == true)
                                            {
                                                Error = Cultures.ReturnTranslation("يوجد رمز وحدة بنفس رمز الوحدة الإنجليزي");
                                                txt08001002005.Focus();

                                            }
                                        }
                                    }


                                }

                            }

                            if (Error == "")
                            {


                                // فحص مشكلة الدوران
                                bool? CircleElementsTest;
                                if (cbx08001002001.SelectedValue == null)
                                {
                                    // لا توجد مشكلة دوران لانه سينقل الى فارغ
                                    CircleElementsTest = false;
                                }
                                else
                                {

                                    TreeNode MoveNode = ElementsTools.TreeView_.Search(tv, Convert.ToInt32(txt08001002001.Text));
                                    TreeNode MoveNodeTo = ElementsTools.TreeView_.Search(tv, cbx08001002001.SelectedValue);
                                    ElementsTools.TreeView_.CircleOfElements(tv , MoveNode, MoveNodeTo);
                                    CircleElementsTest = ElementsTools.TreeView_.CircleOfElementsResut;
                                    ElementsTools.TreeView_.CircleOfElementsResut = null; // اعادتها لوضعها الطبيعي
                                }


                                if (CircleElementsTest == false)
                                {
                                    // لا توجد مشكلة دوران




                                    string[] result = null;
                                    DataTools.DataBases.Run(ref result, "spEditMeasureUnit",
                                    CommandType.StoredProcedure, new object[][] {
                                      new object[] { "@MeasureUnitNo", txt08001002001.Text.Replace("'", "") }
                                    , new object[] { "@UnitNameAR", txt08001002002.Text.Replace("'","") }
                                    , new object[] { "@UnitNameEN", txt08001002003.Text.Replace("'", "") }
                                    , new object[] { "@UnitCodeAR", txt08001002004.Text.Replace("'","") }
                                    , new object[] { "@UnitCodeEN", txt08001002005.Text.Replace("'","") }
                                    , new object[] { "@TopMeasureUnit", cbx08001002001.SelectedValue  }
                                    , new object[] { "@EqualFromTopMeasureUnit", txt08001002006.Text.Replace("'", "")  }

                                    });

                                    if (result[1] == "succeeded")
                                    {
                                        // تحديث بيانات الجدواول
                                        int rowIndex = 0;
                                        DataRow[] dataRows = TblMeasureUnitForDgv.Select("MeasureUnitNo = " + txt08001002001.Text);
                                        rowIndex = TblMeasureUnitForDgv.Rows.IndexOf(dataRows[0]);

                                        // table 1
                                        TblMeasureUnitForDgv.Rows[rowIndex][1] = txt08001002002.Text;
                                        TblMeasureUnitForDgv.Rows[rowIndex][2] = txt08001002003.Text;
                                        TblMeasureUnitForDgv.Rows[rowIndex][3] = txt08001002004.Text;
                                        TblMeasureUnitForDgv.Rows[rowIndex][4] = txt08001002005.Text;

                                        TblMeasureUnitForDgv.Rows[rowIndex][5] = cbx08001002001.SelectedValue == null ? DBNull.Value : cbx08001002001.SelectedValue;

                                        if (txt08001002006.Text.Trim() == "")
                                        {
                                            TblMeasureUnitForDgv.Rows[rowIndex][6] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureUnitForDgv.Rows[rowIndex][6] = txt08001002006.Text.Trim();
                                        }

                                        // table 2
                                        TblMeasureUnitForCbx.Rows[rowIndex][1] = txt08001002002.Text;
                                        TblMeasureUnitForCbx.Rows[rowIndex][2] = txt08001002003.Text;
                                        TblMeasureUnitForCbx.Rows[rowIndex][3] = txt08001002004.Text;
                                        TblMeasureUnitForCbx.Rows[rowIndex][4] = txt08001002005.Text;
                                        TblMeasureUnitForCbx.Rows[rowIndex][5] = cbx08001002001.SelectedValue == null ? DBNull.Value : cbx08001002001.SelectedValue;
                                        if (txt08001002006.Text.Trim() == "")
                                        {
                                            TblMeasureUnitForCbx.Rows[rowIndex][6] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureUnitForCbx.Rows[rowIndex][6] = txt08001002006.Text.Trim();
                                        }

                                        //table 3
                                        TblMeasureUnitForTv.Rows[rowIndex][1] = txt08001002002.Text;
                                        TblMeasureUnitForTv.Rows[rowIndex][2] = txt08001002003.Text;
                                        TblMeasureUnitForTv.Rows[rowIndex][3] = txt08001002004.Text;
                                        TblMeasureUnitForTv.Rows[rowIndex][4] = txt08001002005.Text;
                                        TblMeasureUnitForTv.Rows[rowIndex][5] = cbx08001002001.SelectedValue == null ? DBNull.Value : cbx08001002001.SelectedValue;
                                        if (txt08001002006.Text.Trim() == "")
                                        {
                                            TblMeasureUnitForTv.Rows[rowIndex][6] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureUnitForTv.Rows[rowIndex][6] = txt08001002006.Text.Trim();
                                        }


                                        // هل هناك نودات محددة
                                        if (tv.SelectedNode == null)
                                        {
                                            // لم يتم تحديد اي نود

                                            // التحديث لأنه تم إضافة النود بدون التابعة له وذلك يتطلب تحديث الجدول بشكل كامل
                                            fillTblMeasureUnit();
                                            dgv08001EventsAndProperties(true);
                                            tvEventsAndProperties(true);
                                        }
                                        else
                                        {
                                            // تم تحديد نود

                                            // تحديث بيانات النود
                                            tv.SelectedNode.Text = GeneralVariables.cultureCode == "AR" ? txt08001002002.Text.Replace("'", "").Trim() : txt08001002003.Text.Replace("'", "").Trim();

                                            // تحريك النود
                                            {
                                                // مسح الالوان
                                                ElementsTools.TreeView_.changeColors(tv, DisplayMode.ReturnColor(myElementType.TreeView, ColorPropertyName.BackColor_1), DisplayMode.ReturnColor(myElementType.TreeView, ColorPropertyName.ForeColor_1));

                                                bool? A = null;
                                                bool? B = null;
                                                bool? C = null;
                                                bool? D = null;



                                                // هل النود يمتلك اب
                                                if (tv.SelectedNode.Parent == null)
                                                {
                                                    // لا هذه النود رئيسي ولا يمتلك اب

                                                    A = true;
                                                }
                                                else
                                                {
                                                    // نعم هذا النود تابع لاب

                                                    B = true;
                                                }


                                                // هل تم اختيار اب للانتقال اليه
                                                if (cbx08001002001.SelectedValue == null)
                                                {
                                                    // لا لم يتم اختيار اب  اذن النقل يسيكون للرئيسي

                                                    C = true;

                                                }
                                                else
                                                {
                                                    // نعم تم اختيار اب والنقل سيكون لفرعي

                                                    D = true;

                                                }



                                                //التحريك

                                                if (A == true && C == true) // النقل من رئيسي الى رئيسي
                                                {
                                                    // لم يتم طلب التحريك
                                                }
                                                else if (A == true && D == true) // النقل من رئيسي الى فرعي
                                                {
                                                    TreeNode MoveNode = tv.SelectedNode;
                                                    TreeNode MoveNodeTo = ElementsTools.TreeView_.Search(tv, cbx08001002001.SelectedValue);
                                                    tv.Nodes.Remove(tv.SelectedNode);
                                                    MoveNodeTo.Nodes.Add(MoveNode);
                                                }
                                                else if (B == true && C == true) //  النقل من فرعي الى رئيسي
                                                {
                                                    TreeNode MoveNode = tv.SelectedNode;
                                                    tv.SelectedNode.Parent.Nodes.Remove(tv.SelectedNode);
                                                    tv.Nodes.Add(MoveNode);
                                                }
                                                else if (B == true && D == true) // النقل من فرعي الى فرعي
                                                {
                                                    TreeNode MoveNode = tv.SelectedNode;
                                                    TreeNode MoveNodeTo = ElementsTools.TreeView_.Search(tv, cbx08001002001.SelectedValue);

                                                    if (tv.SelectedNode.Parent.Tag.ToString().Trim() == cbx08001002001.SelectedValue.ToString().Trim())
                                                    {
                                                        // لم يتم طلب التحريك
                                                    }
                                                    else
                                                    {
                                                        tv.SelectedNode.Parent.Nodes.Remove(tv.SelectedNode);
                                                        MoveNodeTo.Nodes.Add(MoveNode);
                                                    }
                                                }

                                            }




                                        }

                                    }
                                    else
                                    {
                                        // لم تنفذ على مستوى قاعدة البيانات
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("فشل التنفيذ"), MessageBoxStatus.Ok);
                                    }
                                }
                                else 
                                {
                                    if (CircleElementsTest == true)
                                    {
                                        // توجد مشكلة دوران
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لقد إرتكبت خطأ منطقي حيث يوجد عناصر كلاً منهما يتبع الاّخر"), MessageBoxStatus.Ok);
                                        GeneralAction.AddNewNotification("frmAccounts11 >> btn08001002003EventsAndProperties", DateTime.Now, "لقد إرتكبت خطأ منطقي حيث يوجد سجلين كلاً منهما يتبع الاّخر", "You made a logical error as there are two records that follow each other");
                                        ElementsTools.TreeView_.CircleOfElementsResut = null;
                                        cbx08001002001.SelectedIndex = -1;
                                    }
                                    else
                                    {
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء قم بالمحاولة من جديد"), MessageBoxStatus.Ok);
                                        GeneralAction.AddNewNotification("frmAccounts11 >> btn08001002003EventsAndProperties", DateTime.Now, "رجاء قم بالمحاولة من جديد", "Please try again");

                                        ElementsTools.TreeView_.CircleOfElementsResut = null;
                                        cbx08001002001.SelectedIndex = -1;
                                    }
                                }

                                //-----------

                                btn08001002003.Text = Cultures.ReturnTranslation("تعديل");

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
                                dgv08001.Enabled = true;
                                tv.Enabled = true;
                                tv.Focus();

                                dgv08001.Enabled = true;


                            }
                            else
                            {
                                btn08001002003.PerformClick();
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);
                                GeneralAction.AddNewNotification("frmMeasureUnit12 >> btn08001002003EventsAndProperties", DateTime.Now, Error, Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureUnit12 >> btn08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    if (Permissions.AccountHavePermission(PermissionObjectes.Measurement_units, PermissionType.Edit))
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


                                dgv08001.Enabled = false;
                                tv.Enabled = false;

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


                                dgv08001.Enabled = true;
                                tv.Enabled = true;

                                dgv08001.Focus();
                            }
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureUnit12 >> btn08001002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Measurement_units, PermissionType.Delete))
                        {
                            try
                            {
                                int? nodeNumber = null;
                                if (txt08001002001.Text.Trim() != "")
                                {
                                    nodeNumber = int.Parse(txt08001002001.Text);

                                }

                                if (nodeNumber != null)
                                {

                                    string[] result = null;
                                    DataTools.DataBases.Run(ref result, "delete from TblMeasureUnit where MeasureUnitNo = @MeasureUnitNo", CommandType.Text, new object[][] { new object[] { "@MeasureUnitNo", nodeNumber } });

                                    if (result[1] == "succeeded")
                                    {
                                        if (result[0] == "1")
                                        {

                                            txt08001002001.Text = "";
                                            txt08001002002.Text = "";
                                            txt08001002003.Text = "";
                                            txt08001002004.Text = "";
                                            txt08001002005.Text = "";
                                            txt08001002006.Text = "";
                                            if (cbx08001002001 != null)
                                            {
                                                if (cbx08001002001.Items.Count > 0)
                                                {
                                                    cbx08001002001.SelectedIndex = -1;
                                                }
                                                else
                                                {
                                                    cbx08001002001.Text = "";
                                                }
                                            }

                                            txtSearch.Text = "";


                                            if (tv.SelectedNode != null)
                                            {

                                                TblMeasureUnitForDgv.Rows.Remove(TblMeasureUnitForDgv.Select("MeasureUnitNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                TblMeasureUnitForCbx.Rows.Remove(TblMeasureUnitForCbx.Select("MeasureUnitNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                TblMeasureUnitForTv.Rows.Remove(TblMeasureUnitForTv.Select("MeasureUnitNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                TreeNode deleteTreeNode = ElementsTools.TreeView_.Search(tv, nodeNumber);




                                                // حل مشكلة الانتقال الغير منطقي
                                                ElementsTools.TreeView_.StarchNextNode(tv, deleteTreeNode);

                                                // ازالة النود
                                                tv.Nodes.Remove(deleteTreeNode);

                                                // التوجه الى النود التالي
                                                tv.SelectedNode = ElementsTools.TreeView_.NextTreeNode;

                                            }
                                            else
                                            {
                                                if (dgv08001.SelectedRows != null)
                                                {
                                                    TblMeasureUnitForDgv.Rows.Remove(TblMeasureUnitForDgv.Select("MeasureUnitNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                    TblMeasureUnitForCbx.Rows.Remove(TblMeasureUnitForCbx.Select("MeasureUnitNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                    TblMeasureUnitForTv.Rows.Remove(TblMeasureUnitForTv.Select("MeasureUnitNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                }

                                            }

                                        }

                                        else
                                        {
                                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("عملية الحذف لم تتم"), MessageBoxStatus.Ok);
                                        }

                                    }
                                    else
                                    {
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("توجد مشكلة"), MessageBoxStatus.Ok);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), "frmMeasureUnit12  >> btn08001002004EventsAndProperties .. " + ex.Message, MessageBoxStatus.Ok);
                            }



                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmMeasureUnit12 >> btn08001002004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureUnit12 >> btn08001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    tv.Nodes.Clear();
                    ElementsTools.TreeView_.fillTreeView(tv, TblMeasureUnitForTv, "TopMeasureUnit", 5, -1, 1, 2, 0);
                    ElementsTools.TreeView_.CustumProperties(tv);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureUnit12 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    tv.Nodes.Clear();
                    ElementsTools.TreeView_.fillTreeView(tv, TblMeasureUnitForTv, "TopMeasureUnit", 5, -1, 1, 2, 0);
                    ElementsTools.TreeView_.CustumProperties(tv);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureUnit12 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                tv.AfterSelect += delegate
                {
                    try
                    {

                        if (tv.SelectedNode.Tag is null) return;

                        foreach (DataGridViewRow row in dgv08001.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == tv.SelectedNode.Tag.ToString())
                            {
                                dgv08001.ClearSelection();
                                row.Selected = true;
                                break;
                            }
                        }

                        // تأثيرات التحديد
                        ElementsTools.TreeView_.changeColors(tv, DisplayMode.ReturnColor(myElementType.TreeView, ColorPropertyName.BackColor_1), DisplayMode.ReturnColor(myElementType.TreeView, ColorPropertyName.ForeColor_1));
                        if (tv.SelectedNode != null) tv.SelectedNode.BackColor = Color.FromArgb(255, 0, 120, 215);
                        if (tv.SelectedNode != null) tv.SelectedNode.ForeColor = Color.White;


                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureUnit12 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                };


                tv.NodeMouseClick += delegate (object sender, TreeNodeMouseClickEventArgs e)
                {

                    try
                    {
                        ElementsTools.TreeView_.changeColors(tv, DisplayMode.ReturnColor(myElementType.TreeView, ColorPropertyName.BackColor_1), DisplayMode.ReturnColor(myElementType.TreeView, ColorPropertyName.ForeColor_1));


                        if (btn08001002001.Text == Cultures.ReturnTranslation("إلغاء"))
                        {
                            btn08001002001.PerformClick();
                        }
                        if (btn08001002003.Text == Cultures.ReturnTranslation("إلغاء"))
                        {
                            btn08001002003.PerformClick();
                        }
                        // تنظيف مربع البحث
                        txtSearch.Clear();
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureUnit12 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                };

                tv.KeyDown += delegate(object sender,KeyEventArgs e)
                {
                    try
                    {
                        if (e.KeyData == Keys.Subtract)
                        {

                            btn08001002004.PerformClick();

                        }
                        else if (e.KeyData == Keys.Add)
                        {
                            if (tv.SelectedNode != null)
                            {
                                btn08001002003.PerformClick();
                            }
                        }
                        else if (e.KeyData == Keys.Enter)
                        {

                            btn08001002001.PerformClick();

                            if (cbx08001002001 != null)
                            {

                                if (cbx08001002001.Items.Count > 0)
                                {

                                    if (tv.SelectedNode != null)
                                    {

                                        if (tv.SelectedNode.Tag.ToString().Trim() != "")
                                        {

                                            cbx08001002001.SelectedValue = tv.SelectedNode.Tag.ToString();
                                        }
                                        else
                                        {
                                            cbx08001002001.Text = "";
                                        }
                                    }
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureUnit12 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }
                    

                };

            }
        }

        private void dgv08001EventsAndProperties(bool Properties, bool Events = false) // جدول عرض التصنيفات
        {
            if (Properties == true && Events == false)
            {
                try
                {

                    if (TblMeasureUnitForDgv is null) return;
                    if (TblMeasureUnitForDgv.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblMeasureUnitForDgv;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم وحدة القياس");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم الوحدة عربي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم الوحدةانجليزي");


                        dgv08001.Columns[3].Visible = false;
                        dgv08001.Columns[4].Visible = false;
                        dgv08001.Columns[5].Visible = false;
                        dgv08001.Columns[6].Visible = false;

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
                    GeneralAction.AddNewNotification("frmMeasureUnit12 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {

                try
                {

                    if (TblMeasureUnitForDgv is null) return;
                    if (TblMeasureUnitForDgv.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblMeasureUnitForDgv;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم وحدة القياس");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم الوحدة عربي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم الوحدةانجليزي");


                        dgv08001.Columns[3].Visible = false;
                        dgv08001.Columns[4].Visible = false;
                        dgv08001.Columns[5].Visible = false;
                        dgv08001.Columns[6].Visible = false;

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
                    GeneralAction.AddNewNotification("frmMeasureUnit12 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                            txt08001002006.Text = dgv08001.SelectedRows[0].Cells[6].Value.ToString();
                            if (cbx08001002001 != null)
                            {
                                if (cbx08001002001.Items.Count > 0)
                                {
                                    if (dgv08001.SelectedRows[0].Cells[5].Value.ToString() != null)
                                    {
                                        if (dgv08001.SelectedRows[0].Cells[5].Value.ToString().Trim() != "")
                                        {
                                            cbx08001002001.SelectedValue = dgv08001.SelectedRows[0].Cells[5].Value.ToString();
                                        }
                                        else
                                        {
                                            cbx08001002001.SelectedIndex = -1;
                                        }
                                    }
                                    else
                                    {
                                        cbx08001002001.SelectedIndex = -1;
                                    }
                                }
                            }

                            tv.SelectedNode = ElementsTools.TreeView_.Search(tv, dgv08001.SelectedRows[0].Cells[0].Value);

                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureUnit12 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }
                    

                };

                dgv08001.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    try
                    {
                        if (e.KeyData == Keys.Subtract)
                        {

                            btn08001002004.PerformClick();

                        }
                        else if (e.KeyData == Keys.Add)
                        {
                            if (tv.SelectedNode != null)
                            {
                                btn08001002003.PerformClick();
                            }
                        }
                        else if (e.KeyData == Keys.Enter)
                        {

                            btn08001002001.PerformClick();

                            if (cbx08001002001 != null)
                            {

                                if (cbx08001002001.Items.Count > 0)
                                {
                                    if (tv.SelectedNode.Tag.ToString().Trim() != "")
                                    {

                                        if (cbx08001002001.Items != null)
                                        {
                                            cbx08001002001.SelectedValue = dgv08001.SelectedRows[0].Cells[0].Value.ToString().Trim();
                                        }
                                    }
                                    else
                                    {
                                        cbx08001002001.Text = "";
                                    }
                                }
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureUnit12 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }
                    
                };


                dgv08001.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                };
            }
        }


        //------------------------------ 
        DataTable TblMeasureUnitForDgv = new DataTable(); // جدول الحسابات للجدول السفلي 
        DataTable TblMeasureUnitForCbx = new DataTable(); // جدول الحسابات للقائمة المنسدلة
        DataTable TblMeasureUnitForTv = new DataTable(); // جدول الحسابات للعرض الشجري 
        private void fillTblMeasureUnit()// تعبئة جدول الحسابت
        {
            try
            {
                if (TblMeasureUnitForDgv is null) return;
                if (TblMeasureUnitForDgv.Rows.Count > 0) { TblMeasureUnitForDgv.Rows.Clear(); }

                TblMeasureUnitForDgv = DataTools.DataBases.ReadTabel("select * from TblMeasureUnit ");
                TblMeasureUnitForCbx = DataTools.DataBases.ReadTabel("select * from TblMeasureUnit ");
                TblMeasureUnitForTv = DataTools.DataBases.ReadTabel("select * from TblMeasureUnit ");

            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmMeasureUnit12 >> fillTblMeasureUnit ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- البحث
        private void lblSearchEventsAndProperties(bool Properties, bool Events = false) // ملصق البحث عن الحسابات 
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

        private void txtSearchEventsAndProperties(bool Properties, bool Events = false) // مربع نص البحث عن الحسابات
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

                        DataView dv = new DataView(TblMeasureUnitForDgv);
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
                        GeneralAction.AddNewNotification("frmMeasureUnit12 >> txtSearchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }

        // اداة التلميح
        ToolTip toolTip1;
        private void tooltip()
        {
            try
            {
                if (toolTip1 == null)
                {
                    toolTip1 = new ToolTip();

                    // Set up the delays for the ToolTip.
                    toolTip1.AutoPopDelay = 5000;
                    toolTip1.InitialDelay = 1000;
                    toolTip1.ReshowDelay = 500;
                    // Force the ToolTip text to be displayed whether or not the form is active.
                    toolTip1.ShowAlways = true;
                }

                toolTip1.SetToolTip(this.tv, Cultures.ReturnTranslation("إنتر للإضافة و + للتعديل و - للحذف"));  // تلميح
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmMeasureUnit12 >> tooltip ", DateTime.Now, ex.Message, ex.Message);
            }

        }
    }


}

