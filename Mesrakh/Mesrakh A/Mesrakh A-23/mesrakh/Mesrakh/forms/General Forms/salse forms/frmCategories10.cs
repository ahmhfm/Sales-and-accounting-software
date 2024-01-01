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
    public partial class frmCategories10 : Form
    {
        public frmCategories10()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmCategories10EventsAndProperties(Properties, Events); // النموذج
            pnl08001EventsAndProperties(Properties, Events);// الحاوية الرئيسية
            pnl08001001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl08001001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl08001002EventsAndProperties(Properties, Events); // الحاوية الثانية

            lbl08001002001EventsAndProperties(Properties, Events);// ملصق رقم الصنف 
            txt08001002001EventsAndProperties(Properties, Events);// مربع نص رقم الصنف
            lbl08001002002EventsAndProperties(Properties, Events);// ملصق إسم الصنف عربي 
            txt08001002002EventsAndProperties(Properties, Events);// مربع نص إسم الصنف عربي
            lbl08001002003EventsAndProperties(Properties, Events);// ملصق إسم الصنف إنجليزي 
            txt08001002003EventsAndProperties(Properties, Events);// مربع نص إسم الصنف إنجليزي
            lbl08001002004EventsAndProperties(Properties, Events);// ملصق وصف الصنف 
            txt08001002004EventsAndProperties(Properties, Events);// مربع نص وصف الصنف
            lblManufacturersEventsAndProperties(Properties, Events);// ملصق الصنف الأعلى 
            cbx08001002001EventsAndProperties(Properties, Events);// قائمة منسدلة الصنف الأعلى

            btn08001002001EventsAndProperties(Properties, Events); // جديد
            btn08001002002EventsAndProperties(Properties, Events); // حفظ
            btn08001002003EventsAndProperties(Properties, Events); // تعديل
            btn08001002004EventsAndProperties(Properties, Events); // حذف
            tvEventsAndProperties(Properties, Events); // شجرة عرض التصنيفات
            dgv08001EventsAndProperties(Properties, Events); // جدول عرض بيانات التصنيفات 

            //-------- البحث
            lblSearchEventsAndProperties(Properties, Events);// ملصق البحث عن
            txtSearchEventsAndProperties(Properties, Events);// مربع نص البحث عن

        }

        private void frmCategories10EventsAndProperties(bool Properties, bool Events = false) // النموذج 
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
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "التصنيفات", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "التصنيفات", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
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



        private void lbl08001002001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم الصنف 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم الصنف", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم الصنف", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم الصنف
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

        private void lbl08001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم الصنف عربي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "إسم الصنف عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "إسم الصنف عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002002EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم الصنف عربي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, "ar-SA",100);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, "ar-SA",100, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt08001002002.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if(mye.KeyData == Keys.Enter)
                    {
                        txt08001002003.Select();
                    }
                };
            }
        }

        private void lbl08001002003EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم الصنف إنجليزي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "إسم الصنف إنجليزي", ColorPropertyName.BackColor_1);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "إسم الصنف إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

            }
        }

        private void txt08001002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم الصنف إنجليزي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, "en-US",100);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, "en-US",100, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002003.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002004.Select();
                    }
                };
            }
        }



        private void lbl08001002004EventsAndProperties(bool Properties, bool Events = false) // ملصق وصف الصنف 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "وصف الصنف", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "وصف الصنف", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002004EventsAndProperties(bool Properties, bool Events = false) // مربع نص وصف الصنف
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, "",200);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, "",200, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002004.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx08001002001.Select();
                    }
                };
            }
        }

        private void lblManufacturersEventsAndProperties(bool Properties, bool Events = false) // ملصق الصنف الأعلى 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblManufacturers, "الصنف الأعلى", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblManufacturers, "الصنف الأعلى", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void cbx08001002001EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة الأصناف
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (tblCategories is null) return;
                    if (tblCategories.Rows.Count > 0)
                    {
                        cbx08001002001.DataSource = tblCategoriesForCbx;
                        cbx08001002001.ValueMember = "CategoryNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx08001002001.DisplayMember = "CategoryNameAr";
                        }
                        else
                        {
                            cbx08001002001.DisplayMember = "CategoryNameEn";
                        }
                        ElementsTools.ComboBox_.CustumProperties(cbx08001002001);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmCategories10 >> cbx08001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    filltblCategories(); // تعبئة جدول التصنيفات

                    if (tblCategories is null) return;
                    if (tblCategories.Rows.Count > 0)
                    {
                        cbx08001002001.DataSource = tblCategoriesForCbx;
                        cbx08001002001.ValueMember = "CategoryNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx08001002001.DisplayMember = "CategoryNameAr";
                        }
                        else
                        {
                            cbx08001002001.DisplayMember = "CategoryNameEn";
                        }
                    }

                    ElementsTools.ComboBox_.CustumProperties(cbx08001002001, "", true, true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmCategories10 >> cbx08001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx08001002001.KeyDown += delegate (object mysender, KeyEventArgs mye)
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
                    if (Permissions.AccountHavePermission(PermissionObjectes.Categories, PermissionType.Add))
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
                            cbx08001002001.Enabled = true;
                            dgv08001.Enabled = false;
                            tv.Enabled = false;

                            txt08001002001.Text = "";
                            txt08001002002.Text = "";
                            txt08001002003.Text = "";
                            txt08001002004.Text = "";
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
                            cbx08001002001.Enabled = false;
                            dgv08001.Enabled = true;
                            tv.Enabled = true;

                            dgv08001.Focus();
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmCategories10 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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
                        if ( btn08001002001.Text == Cultures.ReturnTranslation("إلغاء")) // إضافة
                        {
                            string Error = "";
                            if (txt08001002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الصنف عربي");
                                txt08001002002.Focus();
                            }
                            else if (txt08001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الصنف إنجليزي");
                                txt08001002003.Focus();
                            }
                            else
                            {
                                // فحص البيانات للتأكد من عدم وجود تكرار في الجدول
                                bool? SameArabicProductName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002002.Text.Replace("'", ""), 1);
                                bool? SameEnglishProductName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002003.Text.Replace("'", ""), 2);
                                if (SameArabicProductName == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد تصنيف بنفس إسم الصنف العربي");
                                    txt08001002002.Focus();

                                }
                                else
                                {
                                    if (SameEnglishProductName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("يوجد تصنيف بنفس إسم الصنف الإنجليزي");
                                        txt08001002003.Focus();
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                    string[] result = null;
                                    object CategoryNo = DataTools.DataBases.Run(ref result, "spAddCategory",
                                    CommandType.StoredProcedure, new object[][] {
                                      new object[] { "@CategoryNameAr", txt08001002002.Text.Replace("'","") }
                                    , new object[] { "@CategoryNameEn", txt08001002003.Text.Replace("'", "") }
                                    , new object[] { "@CategoryDescription", txt08001002004.Text.Replace("'","") }
                                    , new object[] { "@TopCategory", cbx08001002001.SelectedValue }
                                     , new object[] { "@CategoryNo", "OUT" }
                                    });

                                    if (result[1] == "succeeded")
                                    {


                                        if (GeneralVariables.cultureCode == "AR")
                                        {
                                            TreeNode tn = new TreeNode(txt08001002002.Text.Replace("'", ""));
                                            tn.Tag = CategoryNo;
                                            if (cbx08001002001.SelectedIndex > -1) { ElementsTools.TreeView_.Search(tv, cbx08001002001.SelectedValue).Nodes.Add(tn); } else { tv.Nodes.Add(tn); } // اذا تم تحديد وحدة اعلى يتم الاضافة اليها واذا لم يتم تحديد وحدة اعلى تتم الاضافة على الشجرة العامة

                                        }
                                        else
                                        {
                                            TreeNode tn = new TreeNode(txt08001002003.Text.Replace("'", ""));
                                            tn.Tag = CategoryNo;
                                            if (cbx08001002001.SelectedIndex > -1) { ElementsTools.TreeView_.Search(tv, cbx08001002001.SelectedValue).Nodes.Add(tn); } else { tv.Nodes.Add(tn); }

                                        }

                                        // البيانات الى الجدول
                                        DataRow dr = tblCategories.NewRow();
                                        dr[0] = CategoryNo;
                                        dr[1] = txt08001002002.Text;
                                        dr[2] = txt08001002003.Text;
                                        if (txt08001002004.Text.Trim() == "")
                                        {
                                            dr[3] = DBNull.Value;
                                        }
                                        else
                                        {
                                            dr[3] = txt08001002004.Text;
                                        }
                                        dr[4] = cbx08001002001.SelectedValue == null ? DBNull.Value : cbx08001002001.SelectedValue;
                                        tblCategories.Rows.Add(dr);

                                        // البيانات الى الجدول
                                        DataRow drrr = tblCategoriesForCbx.NewRow();
                                        drrr[0] = CategoryNo;
                                        drrr[1] = txt08001002002.Text;
                                        drrr[2] = txt08001002003.Text;
                                        if (txt08001002004.Text.Trim() == "")
                                        {
                                            dr[3] = DBNull.Value;
                                        }
                                        else
                                        {
                                            dr[3] = txt08001002004.Text;
                                        }
                                        drrr[4] = cbx08001002001.SelectedValue == null ? DBNull.Value : cbx08001002001.SelectedValue;
                                        tblCategoriesForCbx.Rows.Add(drrr);

                                    if (cbx08001002001.DataSource == null)
                                    {
                                        cbx08001002001EventsAndProperties(true);
                                    }

                                    if(dgv08001.DataSource == null)
                                    {
                                        dgv08001EventsAndProperties(true);
                                    }

                                        if (GeneralVariables._frmProductsAndServices09 != null) { GeneralVariables._frmProductsAndServices09.AllEventsAndProperties(true, true); } // تحديث خصائص نموذج المنتجات  ??????????????????

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
                                cbx08001002001.Enabled = false;

                                dgv08001.Enabled = true;
                                tv.Enabled = true;
                                btn08001002001.Select();
                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);

                                txt08001002001.Text = "";
                            }

                        }
                        else if (btn08001002003.Text == Cultures.ReturnTranslation("إلغاء")) // تعديل
                        {

                            string Error = "";
                            if (txt08001002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الصنف عربي");
                                txt08001002002.Focus();
                            }
                            else if (txt08001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الصنف إنجليزي");
                                txt08001002003.Focus();
                            }
                            else
                            {
                                bool? SameArabicProductName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002002.Text.Replace("'", ""), 1);
                                bool? SameEnglishProductName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002003.Text.Replace("'", ""), 2);
                                if (SameArabicProductName == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد تصنيف بنفس إسم الصنف العربي");
                                    txt08001002002.Focus();

                                }
                                else
                                {
                                    if (SameEnglishProductName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("يوجد تصنيف بنفس إسم الصنف الإنجليزي");
                                        txt08001002003.Focus();
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
                                    ElementsTools.TreeView_.CircleOfElements(tv ,MoveNode, MoveNodeTo);
                                    CircleElementsTest = ElementsTools.TreeView_.CircleOfElementsResut;
                                    ElementsTools.TreeView_.CircleOfElementsResut = null; // اعادتها لوضعها الطبيعي
                                }

                                if (CircleElementsTest == false)
                                {
                                    // لا توجد مشكلة دوران

                                    string[] result = null;
                                    DataTools.DataBases.Run(ref result, @"update TblCategories set CategoryNameAr = @CategoryNameAr , CategoryNameEn = @CategoryNameEn , CategoryDescription = @CategoryDescription , TopCategory = @TopCategory  where CategoryNo = @CategoryNo",
                                   CommandType.Text, new object[][]
                                   {
                                      new object[] { "@CategoryNameAr", txt08001002002.Text.Replace("'","") }
                                    , new object[] { "@CategoryNameEn", txt08001002003.Text.Replace("'", "") }
                                    , new object[] { "@CategoryDescription", txt08001002004.Text.ToString() }
                                    , new object[] { "@TopCategory", cbx08001002001.SelectedValue }
                                    , new object[] { "@CategoryNo", txt08001002001.Text.Replace("'","") }
                                   });

                                    if (result[1] == "succeeded")
                                    {

                                        // تحديث بيانات الجدواول
                                        int rowIndex = 0;
                                        DataRow[] dataRows = tblCategories.Select("CategoryNo = " + txt08001002001.Text);
                                        rowIndex = tblCategories.Rows.IndexOf(dataRows[0]);


                                        // table 1
                                        tblCategories.Rows[rowIndex][1] = txt08001002002.Text;
                                        tblCategories.Rows[rowIndex][2] = txt08001002003.Text;
                                        if (txt08001002004.Text.Trim() == "")
                                        {
                                            tblCategories.Rows[rowIndex][3] = DBNull.Value;
                                        }
                                        else
                                        {
                                            tblCategories.Rows[rowIndex][3] = txt08001002004.Text.Trim();
                                        }
                                        tblCategories.Rows[rowIndex][4] = cbx08001002001.SelectedValue == null ? DBNull.Value : cbx08001002001.SelectedValue;

                                        // table 2
                                        tblCategoriesForCbx.Rows[rowIndex][1] = txt08001002002.Text;
                                        tblCategoriesForCbx.Rows[rowIndex][2] = txt08001002003.Text;
                                        if (txt08001002004.Text.Trim() == "")
                                        {
                                            tblCategoriesForCbx.Rows[rowIndex][3] = DBNull.Value;
                                        }
                                        else
                                        {
                                            tblCategoriesForCbx.Rows[rowIndex][3] = txt08001002004.Text.Trim();
                                        }
                                        tblCategoriesForCbx.Rows[rowIndex][4] = cbx08001002001.SelectedValue == null ? DBNull.Value : cbx08001002001.SelectedValue;



                                        // هل هناك نودات محددة
                                        if (tv.SelectedNode == null)
                                        {
                                            // لم يتم تحديد اي نود

                                            // التحديث لأنه تم إضافة النود بدون التابعة له وذلك يتطلب تحديث الجدول بشكل كامل
                                            filltblCategories();
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

                                            if (GeneralVariables._frmProductsAndServices09 != null) { GeneralVariables._frmProductsAndServices09.AllEventsAndProperties(true, true); } // تحديث خصائص نموذج المنتجات
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

                                //------------------

                                btn08001002003.Text = Cultures.ReturnTranslation("تعديل");

                                btn08001002001.Enabled = true;
                                btn08001002002.Enabled = false;
                                btn08001002003.Enabled = true;
                                btn08001002004.Enabled = true;
                                txt08001002001.Enabled = false;
                                txt08001002002.Enabled = false;
                                txt08001002003.Enabled = false;
                                txt08001002004.Enabled = false;
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
                                GeneralAction.AddNewNotification("frmCategories10 >> btn08001002003EventsAndProperties", DateTime.Now, Error, Error);

                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmCategories10 >> btn08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    if (Permissions.AccountHavePermission(PermissionObjectes.Categories, PermissionType.Edit))
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
                        GeneralAction.AddNewNotification("frmCategories10 >> btn08001002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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
                        if (Permissions.AccountHavePermission(PermissionObjectes.Categories, PermissionType.Delete))
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
                                    DataTools.DataBases.Run(ref result, "delete from TblCategories where CategoryNo = @CategoryNo", CommandType.Text, new object[][] { new object[] { "@CategoryNo", tv.SelectedNode.Tag.ToString() } });


                                    if (result[1] == "succeeded")
                                    {

                                        if (result[0] == "1")
                                        {

                                            txt08001002001.Text = "";
                                            txt08001002002.Text = "";
                                            txt08001002003.Text = "";
                                            txt08001002004.Text = "";
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

                                                tblCategories.Rows.Remove(tblCategories.Select("CategoryNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                tblCategoriesForCbx.Rows.Remove(tblCategoriesForCbx.Select("CategoryNo = " + Convert.ToInt32(nodeNumber))[0]);
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
                                                    tblCategories.Rows.Remove(tblCategories.Select("CategoryNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                    tblCategoriesForCbx.Rows.Remove(tblCategoriesForCbx.Select("CategoryNo = " + Convert.ToInt32(nodeNumber))[0]);
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
                                        //  Run تم تسجيل الخطأ من خلال دالة
                                    }

                                }
                                else
                                {
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء قم بتحديد السجل الذي تريد حذفه"), MessageBoxStatus.Ok);
                                }

                            }
                            catch (Exception ex)
                            {

                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), "btn08001002004EventsAndProperties .. " + ex.Message, MessageBoxStatus.Ok);
                            }

                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmCategories10 >> btn08001002004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmCategories10 >> btn08001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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

                    ElementsTools.TreeView_.fillTreeView(tv, tblCategories, "TopCategory", 4, -1, 1, 2, 0);
                    ElementsTools.TreeView_.CustumProperties(tv);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmCategories10 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    tv.Nodes.Clear();
                    ElementsTools.TreeView_.fillTreeView(tv, tblCategories, "TopCategory", 4, -1, 1, 2, 0);
                    ElementsTools.TreeView_.CustumProperties(tv, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmCategories10 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                        // اولا مسح التأثيرات السابقة
                        ElementsTools.TreeView_.changeColors(tv, DisplayMode.ReturnColor(myElementType.TreeView, ColorPropertyName.BackColor_1), DisplayMode.ReturnColor(myElementType.TreeView, ColorPropertyName.ForeColor_1));
                        // ثانيا عمل تأثير جديد
                        tv.SelectedNode.BackColor = Color.FromArgb(255, 0, 120, 215);
                        tv.SelectedNode.ForeColor = Color.White;

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmCategories10 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }
                };


                tv.NodeMouseClick += delegate (object sender, TreeNodeMouseClickEventArgs e)
                {
                    if (btn08001002001.Text == Cultures.ReturnTranslation("إلغاء"))
                    {
                        btn08001002001.PerformClick();
                    }
                    if (btn08001002003.Text == Cultures.ReturnTranslation("إلغاء"))
                    {
                        //if(tv.SelectedNode != null)
                        //{
                            btn08001002003.PerformClick();
                        //}
                    }
                    // تنظيف مربع البحث
                    txtSearch.Clear();
                };

                tv.KeyDown += delegate(object sender,KeyEventArgs e)
                {
                    try
                    {
                        if (e.KeyData == Keys.Subtract)
                        {

                            btn08001002004.PerformClick();

                        }
                        else if (e.KeyData == Keys.Enter)
                        {
                            if (tv.SelectedNode != null)
                            {
                                btn08001002003.PerformClick();
                            }
                        }
                        else if (e.KeyData == Keys.Add)
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

                                            if (cbx08001002001.Items != null)
                                            {
                                                cbx08001002001.SelectedValue = tv.SelectedNode.Tag;
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
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmCategories10 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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

                    if (tblCategories is null) return;
                    if (tblCategories.Rows.Count > 0)
                    {

                        dgv08001.DataSource = tblCategories;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الصنف");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم الصنف عربي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم الصنف إنجليزي");

                        dgv08001.Columns[3].Visible = false;
                        dgv08001.Columns[4].Visible = false;


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
                    GeneralAction.AddNewNotification("frmCategories10 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {

                    if (tblCategories is null) return;
                    if (tblCategories.Rows.Count > 0)
                    {

                        dgv08001.DataSource = tblCategories;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الصنف");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم الصنف عربي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم الصنف إنجليزي");

                        dgv08001.Columns[3].Visible = false;
                        dgv08001.Columns[4].Visible = false;


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
                    GeneralAction.AddNewNotification("frmCategories10 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                            if (cbx08001002001 != null)
                            {
                                if (cbx08001002001.Items.Count > 0)
                                {
                                    if (dgv08001.SelectedRows[0].Cells[4].Value.ToString() != null)
                                    {
                                        if (dgv08001.SelectedRows[0].Cells[4].Value.ToString().Trim() != "")
                                        {
                                            cbx08001002001.SelectedValue = dgv08001.SelectedRows[0].Cells[4].Value.ToString();
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
                        GeneralAction.AddNewNotification("frmCategories10 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                        else if (e.KeyData == Keys.Enter)
                        {
                            if (dgv08001.SelectedRows != null)
                            {
                                btn08001002003.PerformClick();
                            }
                        }
                        else if (e.KeyData == Keys.Add)
                        {

                            btn08001002001.PerformClick();

                            if (cbx08001002001 != null)
                            {

                                if (cbx08001002001.Items.Count > 0)
                                {

                                    if (dgv08001.SelectedRows != null)
                                    {

                                        if (dgv08001.SelectedRows[0].Cells[0].Value.ToString().Trim() != "")
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
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmCategories10 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }
                    
                };

                dgv08001.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                };
            }
        }


        //------------------------------ 
        DataTable tblCategories = new DataTable(); // جدول التصنيفات للجدول السفلي 
        DataTable tblCategoriesForCbx = new DataTable(); // جدول التصنيفات للقائمة المنسدلة
        private void filltblCategories()// تعبئة جدول التصنيفات
        {
            try
            {
                if (tblCategories is null) return;
                if (tblCategories.Rows.Count > 0) { tblCategories.Rows.Clear(); }

                tblCategories = DataTools.DataBases.ReadTabel("select * from TblCategories ");
                tblCategoriesForCbx = DataTools.DataBases.ReadTabel("select * from TblCategories ");
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmCategories10 >> filltblCategories ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- البحث
        private void lblSearchEventsAndProperties(bool Properties, bool Events = false) // ملصق البحث عن التصنيفات 
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

        private void txtSearchEventsAndProperties(bool Properties, bool Events = false) // مربع نص البحث عن التصنيفات
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
                        DataView dv = new DataView(tblCategories);
                        string filter = "";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            filter = "CategoryNameAr like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        else
                        {
                            filter = "CategoryNameEn like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        dv.RowFilter = filter;
                        dgv08001.DataSource = dv;
                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmCategories10 >> txtSearchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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


                toolTip1.SetToolTip(this.tv, Cultures.ReturnTranslation("إنتر للتعديل و + للإضافة و - للحذف"));  // تلميح
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmCategories10 >> tooltip ", DateTime.Now, ex.Message, ex.Message);
            }

        }

    }


}

