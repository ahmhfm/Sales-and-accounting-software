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
    public partial class frmAccounts11 : Form
    {
        public frmAccounts11()
        {
            //fillTblAccounts(); // تعبئة جدول الحسابات
            //fillTblClients(); // تعبئة جدول العملاء
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmAccounts11EventsAndProperties(Properties, Events); // النموذج
            pnl08001EventsAndProperties(Properties, Events);// الحاوية الرئيسية
            pnl08001001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl08001001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl08001002EventsAndProperties(Properties, Events); // الحاوية الثانية

            lbl08001002001EventsAndProperties(Properties, Events);// ملصق رقم الحساب 
            txt08001002001EventsAndProperties(Properties, Events);// مربع نص رقم الحساب
            lbl08001002002EventsAndProperties(Properties, Events);// ملصق إسم الحساب انجليزي
            txt08001002002EventsAndProperties(Properties, Events);// مربع نص إسم الحساب انجليزي
            lbl08001002003EventsAndProperties(Properties, Events);// ملصق إسم الحساب عربي 
            txt08001002003EventsAndProperties(Properties, Events);// مربع نص إسم الحساب عربي
            lbl08001002004EventsAndProperties(Properties, Events);// ملصق معلومات الحساب 
            txt08001002004EventsAndProperties(Properties, Events);// مربع نص معلومات الحساب
            lblManufacturersEventsAndProperties(Properties, Events);// ملصق الحساب الأعلى 
            cbx08001002001EventsAndProperties(Properties, Events);// قائمة منسدلة الحساب الأعلى
            lblClientsNoEventsAndProperties(Properties, Events);//  ملصق العملاء 
            cbx08001002002EventsAndProperties(Properties, Events);// قائمة منسدلة العملاء  

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

        private void frmAccounts11EventsAndProperties(bool Properties, bool Events = false) // النموذج 
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
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "الحسابات", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "الحسابات", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
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



        private void lbl08001002001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم الحساب 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم الحساب", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم الحساب", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم الحساب
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002001, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Int);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002001, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Int);

                txt08001002001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002002.Select();
                    }
                };
            }
        }

        private void lbl08001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم الحساب انجليزي  
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "إسم الحساب إنجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "إسم الحساب إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002002EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم الحساب انجليزي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, "en-US");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, "en-US", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt08001002002.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002003.Select();
                    }
                };
            }
        }

        private void lbl08001002003EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم الحساب عربي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "إسم الحساب عربي", ColorPropertyName.BackColor_1);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "إسم الحساب عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

            }
        }

        private void txt08001002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم الحساب عربي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, "ar-SA");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, "ar-SA", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002003.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002004.Select();
                    }
                };
            }
        }



        private void lbl08001002004EventsAndProperties(bool Properties, bool Events = false) // ملصق وصف الحساب 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "وصف الحساب", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "وصف الحساب", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002004EventsAndProperties(bool Properties, bool Events = false) // مربع نص وصف الحساب
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, "");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002004.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx08001002001.Select();
                    }
                };
            }
        }

        private void lblManufacturersEventsAndProperties(bool Properties, bool Events = false) // ملصق الحساب الأعلى 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblTopAccountNo, "الحساب الأعلى", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblTopAccountNo, "الحساب الأعلى", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void cbx08001002001EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة الحسابات
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblAccounts is null) return;
                    if (TblAccounts.Rows.Count > 0)
                    {
                        cbx08001002001.DataSource = TblAccountsForCbx;
                        cbx08001002001.ValueMember = "AccountNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx08001002001.DisplayMember = "AccountNameAR";
                        }
                        else
                        {
                            cbx08001002001.DisplayMember = "AccountNameEN";
                        }
                        ElementsTools.ComboBox_.CustumProperties(cbx08001002001);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmAccounts11 >> cbx08001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                        cbx08001002001.DataSource = TblAccountsForCbx;
                        cbx08001002001.ValueMember = "AccountNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx08001002001.DisplayMember = "AccountNameAR";
                        }
                        else
                        {
                            cbx08001002001.DisplayMember = "AccountNameEN";
                        }
                    }
                        ElementsTools.ComboBox_.CustumProperties(cbx08001002001, "", true, true);
                    
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmAccounts11 >> cbx08001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx08001002001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
      
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx08001002002.Select();
                    }
      
                };


            }
        }

        private void lblClientsNoEventsAndProperties(bool Properties, bool Events = false) // ملصق العميل 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblClientsNo, "العميل", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblClientsNo, "العميل", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void cbx08001002002EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة العميل
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblAccounts is null) return;
                    if (TblAccounts.Rows.Count > 0)
                    {
                        cbx08001002002.DataSource = TblClients;
                        cbx08001002002.ValueMember = "ClientsNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx08001002002.DisplayMember = "ClientNameAR";
                        }
                        else
                        {
                            cbx08001002002.DisplayMember = "ClientNameEN";
                        }
                        ElementsTools.ComboBox_.CustumProperties(cbx08001002002);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmAccounts11 >> cbx08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }
                

            }
            else if (Properties == true && Events == true)
            {

                try
                {
                    fillTblClients(); // تعبئة جدول العملاء

                    if (TblAccounts is null) return;
                    if (TblAccounts.Rows.Count > 0)
                    {
                        cbx08001002002.DataSource = TblClients;
                        cbx08001002002.ValueMember = "ClientsNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx08001002002.DisplayMember = "ClientNameAR";
                        }
                        else
                        {
                            cbx08001002002.DisplayMember = "ClientNameEN";

                            ElementsTools.ComboBox_.CustumProperties(cbx08001002002, "", true, true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmAccounts11 >> cbx08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx08001002002.KeyDown += delegate (object mysender, KeyEventArgs mye)
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
                    if (Permissions.AccountHavePermission(PermissionObjectes.Users_Accounts, PermissionType.Add))
                    {

                        if (btn08001002001.Text == Cultures.ReturnTranslation("جديد"))
                        {
                            btn08001002001.Text = Cultures.ReturnTranslation("إلغاء");
                            btn08001002002.Enabled = true;
                            btn08001002003.Enabled = false;
                            btn08001002004.Enabled = false;
                            txt08001002001.Enabled = true;
                            txt08001002002.Enabled = true;
                            txt08001002003.Enabled = true;
                            txt08001002004.Enabled = true;
                            cbx08001002001.Enabled = true;
                            cbx08001002002.Enabled = true;
                            dgv08001.Enabled = false;
                            tv.Enabled = false;

                            txt08001002001.Text = "";
                            txt08001002002.Text = "";
                            txt08001002003.Text = "";
                            txt08001002004.Text = "";
                            if (cbx08001002001 != null && cbx08001002001.Items.Count > 0) cbx08001002001.SelectedIndex = -1;




                            txt08001002001.Focus();
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
                            cbx08001002002.Enabled = false;

                            dgv08001.Enabled = true;
                            tv.Enabled = true;

                            dgv08001.Focus();
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmAccounts11 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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
                            if (txt08001002001.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل رقم الحساب");
                                txt08001002001.Focus();
                            }
                            else if (txt08001002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الحساب إنجليزي");
                                txt08001002002.Focus();
                            }
                            else if (txt08001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الحساب عربي");
                                txt08001002003.Focus();
                            }
                            else
                            {
                                // فحص البيانات للتأكد من عدم وجود تكرار في الجدول
                                bool? SameAccountNo = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002001.Text.Replace("'", ""), 0);
                                bool? SameEnglishAccountName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002002.Text.Replace("'", ""), 1);
                                bool? SameArabicAccountName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002003.Text.Replace("'", ""), 2);


                                if (SameAccountNo == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد حساب بنفس رقم الحساب");
                                    txt08001002001.Focus();
                                }
                                else
                                {
                                    if (SameEnglishAccountName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("يوجد حساب بنفس إسم الحساب الانجليزي");
                                        txt08001002003.Focus();
                                    }
                                    else
                                    {
                                        if (SameArabicAccountName == true)
                                        {
                                            Error = Cultures.ReturnTranslation("يوجد حساب بنفس إسم الحساب العربي");
                                            txt08001002002.Focus();

                                        }
                                    }


                                }

                            }

                            if (Error == "")
                            {
                                      //---------------------------------------------------------- اضافة 

                                    string[] result = null;
                                    DataTools.DataBases.Run(ref result, "spAddAccount",
                                    CommandType.StoredProcedure, new object[][] {
                                      new object[] { "@AccountNo", txt08001002001.Text.Replace("'","") }
                                    , new object[] { "@AccountNameEN", txt08001002002.Text.Replace("'","") }
                                    , new object[] { "@AccountNameAR", txt08001002003.Text.Replace("'", "") }
                                    , new object[] { "@AccountInformations", txt08001002004.Text.Replace("'","") }
                                    , new object[] { "@TopAccountNo", cbx08001002001.SelectedValue }
                                    , new object[] { "@ClientsNo", cbx08001002002.SelectedValue  }
                                    });

                                    if (result[1] == "succeeded")
                                    {


                                        if (GeneralVariables.cultureCode != "AR")
                                        {
                                            TreeNode tn = new TreeNode(txt08001002002.Text.Replace("'", ""));
                                            tn.Tag = Convert.ToInt32(txt08001002001.Text);
                                            if (cbx08001002001.SelectedIndex > -1) { ElementsTools.TreeView_.Search(tv, cbx08001002001.SelectedValue).Nodes.Add(tn); } else { tv.Nodes.Add(tn); }

                                        }
                                        else
                                        {
                                            TreeNode tn = new TreeNode(txt08001002003.Text.Replace("'", ""));
                                            tn.Tag = Convert.ToInt32(txt08001002001.Text);
                                            if (cbx08001002001.SelectedIndex > -1) { ElementsTools.TreeView_.Search(tv, cbx08001002001.SelectedValue).Nodes.Add(tn); } else { tv.Nodes.Add(tn); }

                                        }

                                        // البيانات الى الجدول
                                        DataRow dr = TblAccounts.NewRow();
                                        dr[0] = txt08001002001.Text.Trim().Replace("'", "");
                                        dr[1] = txt08001002002.Text.Trim().Replace("'", "");
                                        dr[2] = txt08001002003.Text.Trim().Replace("'", "");
                                        if (txt08001002004.Text.Trim() == "")
                                        {
                                            dr[3] = DBNull.Value;
                                        }
                                        else
                                        {
                                            dr[3] = txt08001002004.Text.Trim().Replace("'", "");
                                        }
                                        dr[4] = cbx08001002001.SelectedValue == null ? DBNull.Value : cbx08001002001.SelectedValue;
                                        dr[5] = cbx08001002002.SelectedValue == null ? DBNull.Value : cbx08001002002.SelectedValue;
                                        TblAccounts.Rows.Add(dr);

                                        // البيانات الى الجدول
                                        DataRow drr = TblAccountsForCbx.NewRow();
                                        drr[0] = txt08001002001.Text.Trim().Replace("'", "");
                                        drr[1] = txt08001002002.Text.Trim().Replace("'", "");
                                        drr[2] = txt08001002003.Text.Trim().Replace("'", "");
                                        if (txt08001002004.Text.Trim() == "")
                                        {
                                            drr[3] = DBNull.Value;
                                        }
                                        else
                                        {
                                            drr[3] = txt08001002004.Text.Trim().Replace("'", "");
                                        }
                                        drr[4] = cbx08001002001.SelectedValue == null ? DBNull.Value : cbx08001002001.SelectedValue;
                                        drr[5] = cbx08001002002.SelectedValue == null ? DBNull.Value : cbx08001002002.SelectedValue;
                                        TblAccountsForCbx.Rows.Add(drr);


                                        if (cbx08001002001.DataSource == null)
                                        {
                                            cbx08001002001.DataSource = TblAccountsForCbx;
                                            cbx08001002001EventsAndProperties(true);
                                        }
                                        if (cbx08001002002.DataSource == null)
                                        {
                                            cbx08001002002.DataSource = TblClients;
                                            cbx08001002001EventsAndProperties(true);
                                        }
                                        if (dgv08001.DataSource == null)
                                        {
                                            cbx08001002001.DataSource = TblAccountsForCbx;
                                            dgv08001EventsAndProperties(true);
                                        }

                                    }


                                //-----------


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
                                cbx08001002002.Enabled = false;

                                dgv08001.Enabled = true;
                                tv.Enabled = true;
                                tv.Focus();
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
                            if (txt08001002001.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل رقم الحساب");
                                txt08001002001.Focus();
                            }
                            else if (txt08001002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الحساب إنجليزي");
                                txt08001002002.Focus();
                            }
                            else if (txt08001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الحساب عربي");
                                txt08001002003.Focus();
                            }
                            else
                            {
                                // فحص البيانات للتأكد من عدم وجود تكرار في الجدول
                                bool? SameAccountNo = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002001.Text.Replace("'", ""), 0);
                                bool? SameEnglishAccountName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002002.Text.Replace("'", ""), 1);
                                bool? SameArabicAccountName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002003.Text.Replace("'", ""), 2);


                                if (SameAccountNo == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد حساب بنفس رقم الحساب");
                                    txt08001002001.Focus();
                                }
                                else
                                {
                                    if (SameEnglishAccountName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("يوجد حساب بنفس إسم الحساب الانجليزي");
                                        txt08001002003.Focus();
                                    }
                                    else
                                    {
                                        if (SameArabicAccountName == true)
                                        {
                                            Error = Cultures.ReturnTranslation("يوجد حساب بنفس إسم الحساب العربي");
                                            txt08001002002.Focus();

                                        }
                                    }


                                }
                            }

                            if (Error == "")
                            {

                                // فحص مشكلة الدوران
                                bool? CircleElementsTest = true ;
                                if (cbx08001002001.SelectedValue == null)
                                {
                                    // لا توجد مشكلة دوران لانه سينقل الى فارغ
                                    CircleElementsTest = false;
                                }
                                else
                                {

                                    TreeNode MoveNode = ElementsTools.TreeView_.Search(tv, Convert.ToInt32(txt08001002001.Text));
                                    TreeNode MoveNodeTo = ElementsTools.TreeView_.Search(tv, cbx08001002001.SelectedValue);
                                    ElementsTools.TreeView_.CircleOfElements(tv, MoveNode, MoveNodeTo);
                                    CircleElementsTest = ElementsTools.TreeView_.CircleOfElementsResut;
                                    ElementsTools.TreeView_.CircleOfElementsResut = null; // اعادتها لوضعها الطبيعي
                                }


                                if (CircleElementsTest == false)
                                {
                                    string[] result = null;
                                    DataTools.DataBases.Run(ref result, "spEditAccount",
                                    CommandType.StoredProcedure
                                    , new object[][] {
                                      new object[] { "@AccountNo", txt08001002001.Text.Replace("'","") }
                                    , new object[] { "@AccountNameEN", txt08001002002.Text.Replace("'","") }
                                    , new object[] { "@AccountNameAR", txt08001002003.Text.Replace("'", "") }
                                    , new object[] { "@AccountInformations", txt08001002004.Text.Replace("'","") }
                                    , new object[] { "@TopAccountNo", cbx08001002001.SelectedValue }
                                    , new object[] { "@ClientsNo", cbx08001002002.SelectedValue  }
                                    });

                                    if (result[1] == "succeeded")
                                    {

                                        // تحديث بيانات الجدواول
                                        int rowIndex = 0;
                                        DataRow[] drs = TblAccounts.Select("AccountNo = " + txt08001002001.Text);
                                        rowIndex = TblAccounts.Rows.IndexOf(drs[0]);

                                        // table 1
                                        TblAccounts.Rows[rowIndex][1] = txt08001002002.Text;
                                        TblAccounts.Rows[rowIndex][2] = txt08001002003.Text;
                                        if (txt08001002004.Text.Trim() == "")
                                        {
                                            TblAccounts.Rows[rowIndex][3] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblAccounts.Rows[rowIndex][3] = txt08001002004.Text.Trim().Replace("'", "");
                                        }
                                        TblAccounts.Rows[rowIndex][4] = cbx08001002001.SelectedValue == null ? DBNull.Value : cbx08001002001.SelectedValue;
                                        TblAccounts.Rows[rowIndex][5] = cbx08001002002.SelectedValue == null ? DBNull.Value : cbx08001002002.SelectedValue;

                                        //table 2 
                                        TblAccountsForCbx.Rows[rowIndex][1] = txt08001002002.Text;
                                        TblAccountsForCbx.Rows[rowIndex][2] = txt08001002003.Text;
                                        if (txt08001002004.Text.Trim() == "")
                                        {
                                            TblAccountsForCbx.Rows[rowIndex][3] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblAccountsForCbx.Rows[rowIndex][3] = txt08001002004.Text.Trim().Replace("'", "");
                                        }
                                        TblAccountsForCbx.Rows[rowIndex][4] = cbx08001002001.SelectedValue == null ? DBNull.Value : cbx08001002001.SelectedValue;
                                        TblAccountsForCbx.Rows[rowIndex][5] = cbx08001002002.SelectedValue == null ? DBNull.Value : cbx08001002002.SelectedValue;


                                        // هل هناك نودات محددة
                                        if (tv.SelectedNode == null)
                                        {
                                            // لم يتم تحديد اي نود

                                            // التحديث لأنه تم إضافة النود بدون التابعة له وذلك يتطلب تحديث الجدول بشكل كامل
                                            fillTblAccounts();
                                            dgv08001EventsAndProperties(true);
                                            tvEventsAndProperties(true);
                                        }
                                        else
                                        {
                                            // تم تحديد نود

                                            // تحديث بيانات النود
                                            tv.SelectedNode.Text = GeneralVariables.cultureCode == "AR" ? txt08001002003.Text.Replace("'", "") : txt08001002002.Text.Replace("'", "");

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
                                    if(CircleElementsTest == true)
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

                                //---------

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
                                GeneralAction.AddNewNotification("frmAccounts11 >> btn08001002003EventsAndProperties", DateTime.Now, Error, Error);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmAccounts11 >> btn08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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

                    if (Permissions.AccountHavePermission(PermissionObjectes.Users_Accounts, PermissionType.Edit))
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
                                cbx08001002002.Enabled = true;

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
                                cbx08001002002.Enabled = false;

                                dgv08001.Enabled = true;
                                tv.Enabled = true;

                                dgv08001.Focus();
                            }
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmAccounts11 >> btn08001002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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

                        if (Permissions.AccountHavePermission(PermissionObjectes.Users_Accounts, PermissionType.Delete))
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
                                    DataTools.DataBases.Run(ref result, "delete from TblAccounts where AccountNo = @AccountNo", CommandType.Text, new object[][] { new object[] { "@AccountNo", nodeNumber } });

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

                                            if (cbx08001002002 != null)
                                            {
                                                if (cbx08001002002.Items.Count > 0)
                                                {
                                                    cbx08001002002.SelectedIndex = -1;
                                                }
                                                else
                                                {
                                                    cbx08001002002.Text = "";
                                                }
                                            }

                                            txtSearch.Text = "";


                                            if (tv.SelectedNode != null)
                                            {
                                                // الحذف من الجداول
                                                TblAccounts.Rows.Remove(TblAccounts.Select("AccountNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                TblAccountsForCbx.Rows.Remove(TblAccountsForCbx.Select("AccountNo = " + Convert.ToInt32(nodeNumber))[0]);

                                                //النود الذي سيتم حذفه
                                                TreeNode deleteTreeNode = ElementsTools.TreeView_.Search(tv, nodeNumber);

                                                // انشاء النود القادم
                                                ElementsTools.TreeView_.StarchNextNode(tv, deleteTreeNode);

                                                // ازالة النود
                                                tv.Nodes.Remove(deleteTreeNode);

                                                // التوجه الى النود الذي تم انشائه
                                                tv.SelectedNode = ElementsTools.TreeView_.NextTreeNode;

                                            }
                                            else
                                            {
                                                if (dgv08001.SelectedRows != null)
                                                {
                                                    TblAccounts.Rows.Remove(TblAccounts.Select("AccountNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                    TblAccountsForCbx.Rows.Remove(TblAccountsForCbx.Select("AccountNo = " + Convert.ToInt32(nodeNumber))[0]);

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

                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), "frmAccounts11  >> btn08001002004EventsAndProperties .. " + ex.Message, MessageBoxStatus.Ok);
                            }

                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmAccounts11 >> btn08001002004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmAccounts11 >> btn08001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    ElementsTools.TreeView_.fillTreeView(tv, TblAccounts, "TopAccountNo", 4, -1, 2, 1, 0);
                    ElementsTools.TreeView_.CustumProperties(tv);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmAccounts11 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    tv.Nodes.Clear();
                    ElementsTools.TreeView_.fillTreeView(tv, TblAccounts, "TopAccountNo", 4, -1, 2, 1, 0);
                    ElementsTools.TreeView_.CustumProperties(tv);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmAccounts11 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                            tv.SelectedNode.BackColor = Color.FromArgb(255, 0, 120, 215);
                            tv.SelectedNode.ForeColor = Color.White;
                    

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmAccounts11 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                        btn08001002003.PerformClick();
                    }
                    // تنظيف مربع البحث
                    txtSearch.Clear();
                };

                tv.KeyDown += delegate (object sender, KeyEventArgs e)
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
                        GeneralAction.AddNewNotification("frmAccounts11 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    if (TblAccounts is null) return;
                    if (TblAccounts.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblAccounts;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الحساب");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم الحساب إنجليزي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم الحساب عربي");


                        dgv08001.Columns[3].Visible = false;
                        dgv08001.Columns[4].Visible = false;
                        dgv08001.Columns[5].Visible = false;

                        if (GeneralVariables.cultureCode != "AR")
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
                    GeneralAction.AddNewNotification("frmAccounts11 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (TblAccounts is null) return;
                    if (TblAccounts.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblAccounts;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الحساب");
                        dgv08001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم الحساب إنجليزي");
                        dgv08001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم الحساب عربي");


                        dgv08001.Columns[3].Visible = false;
                        dgv08001.Columns[4].Visible = false;
                        dgv08001.Columns[5].Visible = false;

                        if (GeneralVariables.cultureCode != "AR")
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
                    GeneralAction.AddNewNotification("frmAccounts11 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                                            cbx08001002001.SelectedValue = dgv08001.SelectedRows[0].Cells[4].Value;
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

                            if (cbx08001002002 != null)
                            {
                                if (cbx08001002002.Items.Count > 0)
                                {
                                    if (dgv08001.SelectedRows[0].Cells[5].Value.ToString() != null)
                                    {
                                        if (dgv08001.SelectedRows[0].Cells[5].Value.ToString().Trim() != "")
                                        {
                                            cbx08001002002.SelectedValue = dgv08001.SelectedRows[0].Cells[5].Value.ToString();
                                        }
                                        else
                                        {
                                            cbx08001002002.SelectedIndex = -1;
                                        }
                                    }
                                    else
                                    {
                                        cbx08001002002.SelectedIndex = -1;
                                    }
                                }
                            }

                            tv.SelectedNode = ElementsTools.TreeView_.Search(tv, dgv08001.SelectedRows[0].Cells[0].Value);

                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmAccounts11 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                        GeneralAction.AddNewNotification("frmAccounts11 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                dgv08001.DataBindingComplete += delegate
                {
          
                    ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                };
            }
        }


        //------------------------------ 
        DataTable TblAccounts = new DataTable(); // جدول الحسابات للجدول السفلي 
        DataTable TblAccountsForCbx = new DataTable(); // جدول الحسابات للقائمة المنسدلة
        DataTable TblClients = new DataTable(); // جدول العملاء 
        private void fillTblAccounts()// تعبئة جدول الحسابت
        {
            try
            {
                if (TblAccounts is null) return;
                if (TblAccounts.Rows.Count > 0) { TblAccounts.Rows.Clear(); }

                TblAccounts = DataTools.DataBases.ReadTabel("select * from TblAccounts ");
                TblAccountsForCbx = DataTools.DataBases.ReadTabel("select * from TblAccounts ");
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmAccounts11 >> fillTblAccounts ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        private void fillTblClients()// تعبئة جدول العملاء
        {
            try
            {
                if (TblClients is null) return;
                if (TblClients.Rows.Count > 0) { TblClients.Rows.Clear(); }

                TblClients = DataTools.DataBases.ReadTabel("select * from TblClients ");
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmAccounts11 >> fillTblClients ", DateTime.Now, ex.Message, ex.Message);
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
                        DataView dv = new DataView(TblAccounts);
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
                        GeneralAction.AddNewNotification("frmAccounts11 >> txtSearchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                GeneralAction.AddNewNotification("frmAccounts11 >> tooltip ", DateTime.Now, ex.Message, ex.Message);
            }

        }

    }


}

