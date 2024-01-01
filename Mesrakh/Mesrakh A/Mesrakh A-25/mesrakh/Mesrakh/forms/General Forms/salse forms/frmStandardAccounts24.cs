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
    public partial class frmStandardAccounts24 : Form
    {
        public frmStandardAccounts24()
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
            lbl08001002001EventsAndProperties(Properties, Events); // ملصق رقم الحساب المعياري
            txt08001002001EventsAndProperties(Properties, Events); // مربع نص رقم الحساب المعياري
            lbl08001002002EventsAndProperties(Properties, Events); // ملصق اسم الحساب المعياري انجليزي
            txt08001002002EventsAndProperties(Properties, Events); // مربع نص اسم الحساب المعياري انجليزي
            lbl08001002003EventsAndProperties(Properties, Events); // ملصق اسم الحساب المعياري عربي
            txt08001002003EventsAndProperties(Properties, Events); // مربع نص اسم الحساب المعياري عربي*

            lbl08001002004EventsAndProperties(Properties, Events); // ملصق معلومات الحساب المعياري
            txt08001002004EventsAndProperties(Properties, Events); // مربع نص معلومات الحساب المعياري
            lbl08001002005EventsAndProperties(Properties, Events); // ملصق الحسابات المحاسبية
            cbx001EventsAndProperties(Properties, Events); // قائمة منسدلة للحسابات المحاسبية



            btn08001002002EventsAndProperties(Properties, Events); // حفظ
            btn08001002003EventsAndProperties(Properties, Events); // تعديل

            dgv08001EventsAndProperties(Properties, Events); // جدول عرض بيانات الحسابات المعيارية
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
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "ربط الحسابات المعيارية بالحسابات المحاسبية الموازية", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "ربط الحسابات المعيارية بالحسابات المحاسبية الموازية", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
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

        private void lbl08001002001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم الحساب المعياري
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم الحساب المعياري", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم الحساب المعياري", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم الحساب المعياري
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002001, "", 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Int);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002001, "",10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true,TextBoxType.Int);
            }
        }

        private void lbl08001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم الحساب المعياري عربي
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "إسم الحساب عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "إسم الحساب عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002002EventsAndProperties(bool Properties = true, bool Events = false) // مربع نص إسم الحساب المعياري عربي
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
        private void lbl08001002003EventsAndProperties(bool Properties, bool Events = false)  // ملصق إسم الحساب المعياري إنجليزي
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "إسم الحساب إنجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "إسم الحساب إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم الحساب المعياري إنجليزي
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

        private void lbl08001002004EventsAndProperties(bool Properties, bool Events = false) // ملصق معلومات الحساب المعياري 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "معلومات الحساب", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "معلومات الحساب", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002004EventsAndProperties(bool Properties = true, bool Events = false) // مربع نص معلومات الحساب المعياري
        {
            string cultureInfo = "";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, cultureInfo,250);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, cultureInfo, 250, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002004.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { cbx001.Select(); };

                };
            }
        }
        private void lbl08001002005EventsAndProperties(bool Properties, bool Events = false) // ملصق الحساب المحاسبي المرتبط 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002005, "الحساب المحاسبي المرتبط", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002005, "الحساب المحاسبي المرتبط", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void cbx001EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة الحساب المحاسبي المرتبط
        {
            if (Properties == true && Events == false)
            {
                try
                {

                    if (TblAccounts is null) return;
                    if (TblAccounts.Rows.Count > 0)
                    {
                        cbx001.DataSource = TblAccounts;
                        cbx001.ValueMember = "AccountNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001.DisplayMember = "AccountNameAR";
                        }
                        else
                        {
                            cbx001.DisplayMember = "AccountNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmStandardAccounts24 >> cbx001EventsAndProperties - 0 ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblAccounts();

                    if (TblAccounts is null) return;
                    if (TblAccounts.Rows.Count > 0)
                    {
                        cbx001.DataSource = TblAccounts;
                        cbx001.ValueMember = "AccountNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001.DisplayMember = "AccountNameAR";
                        }
                        else
                        {
                            cbx001.DisplayMember = "AccountNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001, "", true, true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmStandardAccounts24 >> cbx001EventsAndProperties - 1 ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        btn08001002002.PerformClick();
                    }
                };

            }
        }
        //**********************************************************

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

                        string Error = "";
                        bool? SameAccount = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, cbx001.SelectedValue.ToString(), 4);

                        if (SameAccount == true)
                        {
                            Error = Cultures.ReturnTranslation("يوجد حساب معياري مرتبط بنفس الحساب المحاسبي");
                            cbx001.SelectAll();
                        }

                        if (Error == "")
                        {

                            string[] result = null;
                            object result2 = DataTools.DataBases.Run(ref result, "update TblStandardAccounts set AccountNo = @AccountNo where StandardAccountNo = @StandardAccountNo ", CommandType.Text, new object[][] { new object[] { "@AccountNo", cbx001.SelectedValue.ToString()}, new object[] { "@StandardAccountNo", txt08001002001.Text } });

                            if (result[1] == "succeeded")
                            {

                                cbx001.Enabled = false;
                                btn08001002002.Enabled = false;
                                btn08001002003.Enabled = true;

                                dgv08001.Enabled = true;

                                // تحديث بيانات جدول وحدات التغليف
                                fillTblStandardAccounts();
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
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmStandardAccounts24 >> btn08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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


                                cbx001.Enabled = true;

                                btn08001002002.Enabled = true;

                                dgv08001.Enabled = false;
                            }
                            else
                            {
                                btn08001002003.Text = Cultures.ReturnTranslation("تعديل");

                                cbx001.Enabled = false;

                                btn08001002002.Enabled = false;

                                dgv08001.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmStandardAccounts24 >> btn08001002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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
                    if (TblStandardAccounts.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblStandardAccounts;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الحساب المعياري");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم الحساب المعياري إنجليزي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم الحساب المعياري عربي");
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgv08001.Columns[1].Visible = false;
                            dgv08001.Columns[2].Visible = true;
                        }
                        else
                        {
                            dgv08001.Columns[1].Visible = true;
                            dgv08001.Columns[2].Visible = false;
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
                    GeneralAction.AddNewNotification("frmStandardAccounts24 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                }
            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblStandardAccounts(); // تعبئة جدول الحسابات المعيارية

                    if (TblStandardAccounts.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblStandardAccounts;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الحساب المعياري");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم الحساب المعياري إنجليزي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم الحساب المعياري عربي");
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgv08001.Columns[1].Visible = false;
                            dgv08001.Columns[2].Visible = true;
                        }
                        else
                        {
                            dgv08001.Columns[1].Visible = true;
                            dgv08001.Columns[2].Visible = false;
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
                    GeneralAction.AddNewNotification("frmStandardAccounts24 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                }


                dgv08001.SelectionChanged += delegate
                {
                    try
                    {
                        if (dgv08001.Rows.Count > 0)
                        {
                            if (dgv08001.SelectedRows == null) return;
                            if (dgv08001.SelectedRows.Count == 0  ) return;


                            txt08001002001.Text = dgv08001.SelectedRows[0].Cells[0].Value.ToString();

                            txt08001002002.Text = dgv08001.SelectedRows[0].Cells[1].Value.ToString();

                            txt08001002003.Text = dgv08001.SelectedRows[0].Cells[2].Value.ToString();

                            txt08001002004.Text = dgv08001.SelectedRows[0].Cells[3].Value.ToString();

                            if (cbx001.Items != null)
                            {
                                if (dgv08001.SelectedRows[0].Cells[4].Value != null)
                                {
                                    if (dgv08001.SelectedRows[0].Cells[4].Value.ToString() != "")
                                    {
                                        cbx001.SelectedValue = dgv08001.SelectedRows[0].Cells[4].Value.ToString();
                                    }
                                    else
                                    {
                                        cbx001.SelectedIndex = -1;
                                    }
                                }
                                else
                                {
                                    cbx001.SelectedIndex = -1;
                                }
                            }


                            

                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmStandardAccounts24 >> dgv08001EventsAndProperties ?? ", DateTime.Now, ex.Message, ex.Message);

                    }
                };

                dgv08001.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات

                };
            }
        }




        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- البحث
        private void lblSearchEventsAndProperties(bool Properties, bool Events = false) // ملصق البحث عن الحسابات المعيارية 
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

        private void txtSearchEventsAndProperties(bool Properties, bool Events = false) // مربع نص البحث عن الحسابات المعيارية
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
                        DataView dv = new DataView(TblStandardAccounts);
                        string filter = "";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            filter = "AccountNameAR like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        else
                        {
                            filter = "AccountNameEN like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        dv.RowFilter = filter;
                        dgv08001.DataSource = dv;
                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmStandardAccounts24 >> txtSearchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }

        //------------------------------ 
        DataTable TblStandardAccounts = new DataTable(); // جدول الحسابات المعيارية 
        DataTable TblAccounts = new DataTable(); // جدول الحسابات المحاسبية 

        // تعبئة جدول الحسابات المعيارية
        private void fillTblStandardAccounts()
        {
            try
            {
                if (TblStandardAccounts.Rows.Count > 0)
                {
                    TblStandardAccounts.Rows.Clear();
                }

                if (TblStandardAccounts.Rows.Count > 0) TblStandardAccounts.Rows.Clear();

                TblStandardAccounts = DataTools.DataBases.ReadTabel("select * from TblStandardAccounts ");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmStandardAccounts24 >> fillTblStandardAccounts ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        // تعبئة جدول الحسابات المحاسبية
        private void fillTblAccounts()
        {
            try
            {
                if (TblAccounts is null)
                {
                    TblAccounts = new DataTable();
                }

                if (TblAccounts.Rows.Count > 0)
                {
                    TblAccounts.Rows.Clear();
                }

                if (TblAccounts.Rows.Count > 0) TblAccounts.Rows.Clear();

                TblAccounts = DataTools.DataBases.ReadTabel("select * from TblAccounts ");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmStandardAccounts24 >> fillTblAccounts ", DateTime.Now, ex.Message, ex.Message);
            }
        }

    }


}

