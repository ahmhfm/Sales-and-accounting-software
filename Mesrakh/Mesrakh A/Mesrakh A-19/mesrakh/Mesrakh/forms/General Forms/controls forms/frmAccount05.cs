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
    public partial class frmAccount05 : Form
    {
        DataTable TblUsersPermissionsGroup = new DataTable(); // جدول مجموعات الصلاحيات
        DataTable TblEmployees = new DataTable(); // جدول اسماء الموظفين
        DataTable TblUsersAccounts = new DataTable();  // جدول حسابات المستخدمين

        public frmAccount05()
        {
            //if (GeneralVariables.font is null)
            //{
            //    GeneralVariables.font = new Font("Microsoft Sans Serif", 12);
            //}

            fillTblUsersAccounts();// تعبئة جدول معلومات الحسابات
            fillTblUsersPermissionsGroup();// تعبئة جدول مجموعات الصلاحيات
            fillTblEmployees();// تعبئة جدول الموظفين
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        private void fillTblUsersPermissionsGroup()// تعبئة جدول مجموعات الصلاحيات
        {
            try
            {
                if (TblUsersPermissionsGroup.Rows.Count > 0)
                {
                    TblUsersPermissionsGroup.Rows.Clear();
                }

                TblUsersPermissionsGroup = DataTools.DataBases.ReadTabel("select * from TblUsersPermissionsGroup");
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmAccount05  >>  fillTblUsersPermissionsGroup  ", DateTime.Now, ex.Message, ex.Message);
            }

        }

        private void fillTblEmployees() // تعبئة جدول الموظفين
        {
            try
            {
                if (TblEmployees.Rows.Count > 0)
                {
                    TblEmployees.Rows.Clear();
                }
                TblEmployees = DataTools.DataBases.ReadTabel("select * from TblEmployees");
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmAccount05  >>  fillTblEmployees  ", DateTime.Now, ex.Message, ex.Message);
            }

        }

        private void fillTblUsersAccounts() // تعبئة جدول المستخدمين
        {
            try
            {
                if (TblUsersAccounts.Rows.Count > 0)
                {
                    TblUsersAccounts.Rows.Clear();
                }


                TblUsersAccounts = DataTools.DataBases.ReadTabel( "select * from TblUsersAccounts inner join TblEmployees on TblUsersAccounts.EmployeeNo = TblEmployees.EmployeeNo");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("Mesrakh  >> frmAccount05  >>  fillAccountsInformation ", DateTime.Now, " مشكلة عند تحميل معلومات حسابت المستخدمين  ", ex.Message); //---------------------------

                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("توجد مشكلة في الإتصال") , MessageBoxStatus.Ok);
            }
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frm05EventsAndProperties(Properties, Events); // النموذج
            pnl000EventsAndProperties(Properties, Events); // الحاوية الرئيسية
            pnl05001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl05001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl05002EventsAndProperties(Properties, Events); // الحاوية الثانية
            lbl05002001EventsAndProperties(Properties, Events); // ملصق رقم المستخدم
            txt05002002EventsAndProperties(Properties, Events); // مربع نص رقم المستخدم
            lbl05002003EventsAndProperties(Properties, Events); // ملصق اسم المستخدم
            txt05002004EventsAndProperties(Properties, Events); // مربع نص اسم المستخدم
            lbl05002005EventsAndProperties(Properties, Events); // ملصق كلمة المرور
            txt05002006EventsAndProperties(Properties, Events); // مربع نص كلمة المرور
            lbl05002007EventsAndProperties(Properties, Events); // ملصق اسم الموظف
            cmb05002008EventsAndProperties(Properties, Events); // قائمة منسدلة للموظفين
            lbl05002006EventsAndProperties(Properties, Events); // ملصق مجموعة الصلاحيات
            lbl05002009EventsAndProperties(Properties, Events); // ملصق هل الحساب نشط
            cb05002001EventsAndProperties(Properties, Events); // مربع اختيار هل الحساب نشط
            cmb05002006EventsAndProperties(Properties, Events); // قائمة مجموعات الصلاحيات
            btn05002009EventsAndProperties(Properties, Events); // جديد
            btn05002010EventsAndProperties(Properties, Events); // حفظ
            btn05002011EventsAndProperties(Properties, Events); // تعديل
            btn05002012EventsAndProperties(Properties, Events); // حذف
            dgv05003EventsAndProperties(Properties, Events); // جدول عرض بيانات الحسابات

        }




        private void frm05EventsAndProperties(bool Properties, bool Events = false) // النموذج 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Form_.CustumProperties(this);

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Form_.CustumProperties(this, ColorPropertyName.BackColor_3, true, true);
            }
        }
        private void pnl000EventsAndProperties(bool Properties, bool Events = false) // الحاوية الرئيسية
        {


            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl000);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl000, ColorPropertyName.BackColor_3, true, true);
            }
        }

        private void pnl05001EventsAndProperties(bool Properties, bool Events = false) // الحاوية العلوية
        {


            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl05001);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl05001, ColorPropertyName.BackColor_3, true, true);

            }
        }
        private void lbl05001001EventsAndProperties(bool Properties, bool Events = false) // ملصق عنوان النموذج 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl05001001, "حسابات المستخدمين", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl05001001, "حسابات المستخدمين", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }
        private void pnl05002EventsAndProperties(bool Properties, bool Events = false) // الحاوية الثانية
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl05002);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl05002, ColorPropertyName.BackColor_3, true, true);
            }
        }
        private void lbl05002001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم المستخدم 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl05002001, "رقم المستخدم", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl05002001, "رقم المستخدم", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt05002002EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم المستخدم 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt05002002, "en-us",10);

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt05002002, "en-us",10, ColorPropertyName.BackColor_1,ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lbl05002003EventsAndProperties(bool Properties, bool Events = false) // ملصق اسم المستخدم 
        {


            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl05002003, "إسم المستخدم", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl05002003, "إسم المستخدم", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt05002004EventsAndProperties(bool Properties, bool Events = false) // مربع نص اسم المستخدم 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt05002004, "en-us",50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1);

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt05002004, "en-us",50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt05002004.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt05002006.Select(); }
                };
            }
        }


        private void lbl05002005EventsAndProperties(bool Properties, bool Events = false) // ملصق كلمة المرور 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl05002008, "كلمة المرور", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl05002008, "كلمة المرور", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt05002006EventsAndProperties(bool Properties, bool Events = false) // مربع نص كلمة المرور 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt05002006, "en-us",50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1);

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt05002006, "en-us",50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt05002006.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { cb05002001.Select(); }
                };
            }
        }

        private void lbl05002007EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم الموظف 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl05002007, "إسم الموظف", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl05002007, "إسم الموظف", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void cmb05002008EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة للموظفين 
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (cmb05002008.DataSource is null) return;
                    if ((cmb05002008.DataSource as DataTable).Rows.Count > 0)
                    {
                        cmb05002008.ValueMember = "EmployeeNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cmb05002008.DisplayMember = "EmployeeNameAR";
                        }
                        else
                        {
                            cmb05002008.DisplayMember = "EmployeeNameEN";
                        }

                        ElementsTools.ComboBox_.CustumProperties(cmb05002008);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmAccount05  >>  cmb05002008EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (TblEmployees.Rows.Count > 0)
                    {
                        cmb05002008.DataSource = TblEmployees;
                        cmb05002008.ValueMember = "EmployeeNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cmb05002008.DisplayMember = "EmployeeNameAR";
                        }
                        else
                        {
                            cmb05002008.DisplayMember = "EmployeeNameEN";
                        }
                        ElementsTools.ComboBox_.CustumProperties(cmb05002008,"", true, true);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmAccount05  >>  cmb05002008EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                }


                cmb05002008.KeyDown += delegate (object sender,KeyEventArgs e)
                {
                    if (e.KeyData==Keys.Enter) { cmb05002006.Select(); }
                };
            }
        }

        private void lbl05002006EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم مجموعة الصلاحيات 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl05002006, "مجموعات الصلاحيات", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl05002006, "مجموعات الصلاحيات", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lbl05002009EventsAndProperties(bool Properties, bool Events = false) // ملصق هل الحساب نشط 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl05002009, "هل الحساب نشط", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl05002009, "هل الحساب نشط", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void cb05002001EventsAndProperties(bool Properties, bool Events = false) // مربع اختيار هل الحساب نشط 
        {

            if (Properties == true && Events == false)
            {
                
            }
            else if (Properties == true && Events == true)
            {
                cb05002001.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btn05002010.PerformClick(); }
                };
            }
        }

        private void cmb05002006EventsAndProperties(bool Properties, bool Events = false) // قائمة مجموعات الصلاحيات 
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    cmb05002006.DataSource = TblUsersPermissionsGroup;
                    cmb05002006.ValueMember = "PermissionGroupNo";
                    if (GeneralVariables.cultureCode == "AR")
                    {
                        cmb05002006.DisplayMember = "PermissionGroupNameAR";
                    }
                    else
                    {
                        cmb05002006.DisplayMember = "PermissionGroupNameEN";
                    }

                    ElementsTools.ComboBox_.CustumProperties(cmb05002006);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmAccount05  >>  cmb05002006EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                }
                
            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    cmb05002006.DataSource = TblUsersPermissionsGroup;
                    cmb05002006.ValueMember = "PermissionGroupNo";
                    if (GeneralVariables.cultureCode == "AR")
                    {
                        cmb05002006.DisplayMember = "PermissionGroupNameAR";
                    }
                    else
                    {
                        cmb05002006.DisplayMember = "PermissionGroupNameEN";
                    }

                    ElementsTools.ComboBox_.CustumProperties(cmb05002006, "",  true, true);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmAccount05  >>  cmb05002006EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                }



                cmb05002006.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt05002004.Select(); }
                };
            }
        }

        private void btn05002009EventsAndProperties(bool Properties, bool Events = false) // جديد 
        {

            // الخصائص
            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn05002009, "جديد");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn05002009, "جديد", ColorPropertyName.ForeColor_1, true, true);
                btn05002009.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Users_Accounts, PermissionType.Add))
                        {

                            if (btn05002009.Text == Cultures.ReturnTranslation("جديد"))
                            {
                                txt05002004.Enabled = true;
                                txt05002006.Enabled = true;
                                cmb05002008.Enabled = true;
                                cmb05002006.Enabled = true;

                                txt05002002.Text = "";
                                txt05002004.Text = "";
                                txt05002006.Text = "";
                                cmb05002008.SelectedIndex = -1;

                                cmb05002008.Focus();


                                btn05002010.Enabled = true;
                                btn05002011.Enabled = false;
                                btn05002012.Enabled = false;

                                dgv05003.Enabled = false;

                                btn05002009.Text = Cultures.ReturnTranslation("إلغاء");
                            }
                            else
                            {
                                txt05002004.Enabled = false;
                                txt05002006.Enabled = false;
                                cmb05002008.Enabled = false;
                                cmb05002006.Enabled = false;

                                btn05002010.Enabled = false;
                                btn05002011.Enabled = true;
                                btn05002012.Enabled = true;

                                dgv05003.Enabled = true;
                                dgv05003.Focus();

                                btn05002009.Text = Cultures.ReturnTranslation("جديد");
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmAccount05  >>  btn05002009EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

            }
        }
        private void btn05002010EventsAndProperties(bool Properties, bool Events = false) // حفظ 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn05002010, "حفظ");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn05002010, "حفظ", ColorPropertyName.ForeColor_1, true, true);

                btn05002010.Click += delegate
                {


                        string userName = SecurityTools.incryption.Encrypt(txt05002004.Text);
                        string userPassword = SecurityTools.incryption.Encrypt(txt05002006.Text);
                        int parmissionGroupNo = 0;
                        if (cmb05002006.SelectedValue != null)
                        {
                            parmissionGroupNo = Convert.ToInt32(cmb05002006.SelectedValue.ToString());
                        }
                        int EmployeeNo = 0;
                        if (cmb05002008.SelectedValue != null)
                        {
                            EmployeeNo = Convert.ToInt32(cmb05002008.SelectedValue);
                        }

                        try
                        {
                            if (txt05002002.Text.Trim() == "")
                            {
                                bool isActive = cb05002001.Checked ? true : false;

                                string Errors = "";

                                if (txt05002004.Text.Trim() == "")
                                {
                                    Errors = Cultures.ReturnTranslation("رجاء قم بكتابة إسم المستخدم");
                                    txt05002004.Focus();
                                }
                                else if (txt05002006.Text.Trim() == "")
                                {
                                    Errors = Cultures.ReturnTranslation("رجاء قم بكتابة كلمة المرور");
                                    txt05002006.Focus();
                                }
                                else if (cmb05002008.SelectedIndex == -1)
                                {
                                    Errors = Cultures.ReturnTranslation("رجاء قم بإختيار موظف");
                                    cmb05002008.Focus();
                                }
                                else if (cmb05002006.SelectedIndex < 0)
                                {
                                    Errors = Cultures.ReturnTranslation("رجاء قم بإختيار مجموعة الصلاحيات");
                                    cmb05002006.Focus();
                                }
                                else
                                {

                                    bool? FindUserName = ElementsTools.DataGridView_.findValueThenSelected(dgv05003, ActionType.add, txt05002004.Text, 1);
                                    if (FindUserName == true)
                                    {
                                        Errors = Cultures.ReturnTranslation("يوجد مستخدم بنفس الإسم");
                                    }
                                    else
                                    {
                                        bool? FindEmployee = ElementsTools.DataGridView_.findValueThenSelected(dgv05003, ActionType.add, cmb05002008.SelectedValue.ToString(), 4);
                                        if (FindEmployee == true)
                                        {
                                            Errors = Cultures.ReturnTranslation("هذا الموظف لديه حساب سابق");
                                        }
                                    }

                                }

                                if (Errors == "")
                                {
                                    string[] result = null;
                                    DataTools.DataBases.Run(ref result, "insert into TblUsersAccounts values (@UserAccountName,@UserAccountPassword,@PermissionGroupNo,@EmployeeNo,@IsActive)", CommandType.Text, new object[][] { new object[] { "@UserAccountName", userName }, new object[] { "@UserAccountPassword", userPassword }, new object[] { "@PermissionGroupNo", parmissionGroupNo }, new object[] { "@EmployeeNo", EmployeeNo }, new object[] { "@IsActive", isActive } });

                                    txt05002004.Enabled = false;
                                    txt05002006.Enabled = false;
                                    cmb05002008.Enabled = false;
                                    cmb05002006.Enabled = false;

                                    btn05002009.Enabled = true;
                                    btn05002010.Enabled = false;
                                    btn05002011.Enabled = true;
                                    btn05002012.Enabled = true;



                                    dgv05003.Enabled = true;
                                //--------------------------
                                btn05002009.Text = Cultures.ReturnTranslation("جديد");

                                txt05002006.Text = "";
                                    // تحديث بيانات جدول البيانات
                                    fillTblUsersAccounts();
                                    dgv05003EventsAndProperties(true);
                                }
                                else
                                {

                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Errors, MessageBoxStatus.Ok);

                                    //txt05002004.Enabled = false;
                                    //txt05002006.Enabled = false;
                                    //cmb05002008.Enabled = false;
                                    //cmb05002006.Enabled = false;

                                    //btn05002009.Enabled = true;
                                    //btn05002010.Enabled = false;
                                    //btn05002011.Enabled = true;
                                    //btn05002012.Enabled = true;

                                    //dgv05003.Enabled = true;
                                    ////--------------------------
                                    //btn05002009.Text = Cultures.ReturnTranslation("جديد");

                                    //txt05002006.Text = "";

                                }

                            }
                            else
                            {

                                string Errors = "";

                                if (txt05002004.Text.Trim() == "")
                                {
                                    Errors = Cultures.ReturnTranslation("رجاء قم بكتابة إسم المستخدم");
                                    txt05002004.Focus();
                                }
                                else if (cmb05002008.SelectedIndex == -1)
                                {
                                    Errors = Cultures.ReturnTranslation("رجاء قم بإختيار موظف");
                                    cmb05002008.Focus();
                                }
                                else if (cmb05002006.SelectedIndex < 0)
                                {
                                    Errors = Cultures.ReturnTranslation("رجاء قم بإختيار مجموعة الصلاحيات");
                                    cmb05002006.Focus();
                                }
                                else
                                {
                                    bool? FindUserName = ElementsTools.DataGridView_.findValueThenSelected(dgv05003, ActionType.edit, txt05002004.Text, 1);
                                    if (FindUserName == true)
                                    {
                                        Errors = Cultures.ReturnTranslation("يوجد مستخدم بنفس الإسم");
                                    }
                                    else
                                    {
                                        bool? FindEmployee = ElementsTools.DataGridView_.findValueThenSelected(dgv05003, ActionType.edit, cmb05002008.SelectedValue.ToString(), 4);
                                        if (FindEmployee == true)
                                        {
                                            Errors = Cultures.ReturnTranslation("هذا الموظف لديه حساب سابق");
                                        }
                                    }
                                }

                                if (Errors == "")
                                {

                                    bool isActive = cb05002001.Checked ? true : false;

                                    if (txt05002006.Text.Trim() == "")
                                    {
                                        string[] result = null;
                                        DataTools.DataBases.Run(ref result, "update TblUsersAccounts set UserAccountName = @UserAccountName,PermissionGroupNo = @PermissionGroupNo ,EmployeeNo = @EmployeeNo , IsActive = @IsActive  where UserAccountNo = @UserAccountNo", CommandType.Text, new object[][] { new object[] { "@UserAccountName", userName }, new object[] { "@PermissionGroupNo", parmissionGroupNo }, new object[] { "@IsActive", isActive }, new object[] { "@EmployeeNo", EmployeeNo }, new object[] { "@UserAccountNo", txt05002002.Text } });//

                                    }
                                    else
                                    {
                                        string[] result = null;
                                        DataTools.DataBases.Run(ref result, "update TblUsersAccounts set UserAccountName = @UserAccountName,UserAccountPassword = @UserAccountPassword,PermissionGroupNo = @PermissionGroupNo ,EmployeeNo = @EmployeeNo , IsActive = @IsActive  where UserAccountNo = @UserAccountNo", CommandType.Text, new object[][] { new object[] { "@UserAccountName", userName }, new object[] { "@UserAccountPassword", userPassword }, new object[] { "@PermissionGroupNo", parmissionGroupNo }, new object[] { "@IsActive", isActive }, new object[] { "@EmployeeNo", EmployeeNo }, new object[] { "@UserAccountNo", txt05002002.Text } });//

                                    }

                                    txt05002004.Enabled = false;
                                    txt05002006.Enabled = false;
                                    cmb05002008.Enabled = false;
                                    cmb05002006.Enabled = false;

                                    btn05002009.Enabled = true;
                                    btn05002010.Enabled = false;
                                    btn05002011.Enabled = true;
                                    btn05002012.Enabled = true;

                                    dgv05003.Enabled = true;
                                //--------------------------
                                btn05002011.Text = Cultures.ReturnTranslation("تعديل");

                                txt05002006.Text = "";
                                    // تحديث بيانات جدول البيانات
                                    fillTblUsersAccounts();
                                    dgv05003EventsAndProperties(true);

                                }
                                else
                                {
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Errors, MessageBoxStatus.Ok);

                                    //txt05002004.Enabled = false;
                                    //txt05002006.Enabled = false;
                                    //cmb05002008.Enabled = false;
                                    //cmb05002006.Enabled = false;

                                    //btn05002009.Enabled = true;
                                    //btn05002010.Enabled = false;
                                    //btn05002011.Enabled = true;
                                    //btn05002012.Enabled = true;

                                    //dgv05003.Enabled = true;
                                    ////--------------------------
                                    //btn05002011.Text = Cultures.ReturnTranslation("تعديل");

                                    //txt05002006.Text = "";
                                }

                            }
                        }
                        catch (Exception ex)
                        {

                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmAccount05  >>  btn05002010EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);

                        txt05002004.Enabled = false;
                            txt05002006.Enabled = false;
                            cmb05002008.Enabled = false;
                            cmb05002006.Enabled = false;

                            btn05002009.Enabled = true;
                            btn05002010.Enabled = false;
                            btn05002011.Enabled = true;
                            btn05002012.Enabled = true;

                            dgv05003.Enabled = true;
                            dgv05003.Focus();
                            //--------------------------
                            //btn05002009.Text = Cultures.ReturnTranslation("جديد");
                            //btn05002011.Text = Cultures.ReturnTranslation("تعديل");

                            txt05002006.Text = "";
                            // تحديث بيانات جدول البيانات
                            fillTblUsersAccounts();
                            dgv05003EventsAndProperties(true);
                        }

                };
            }


        }
        private void btn05002011EventsAndProperties(bool Properties, bool Events = false) // تعديل 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn05002011, "تعديل");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn05002011, "تعديل", ColorPropertyName.ForeColor_1, true, true);

                btn05002011.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Users_Accounts , PermissionType.Edit))
                    {

                        if (btn05002011.Text == Cultures.ReturnTranslation("تعديل"))
                        {
                            txt05002004.Enabled = true;
                            txt05002006.Enabled = true;
                            cmb05002008.Enabled = true;
                            cmb05002006.Enabled = true;

                            txt05002004.Focus();

                            btn05002009.Enabled = false;
                            btn05002010.Enabled = true;
                            btn05002012.Enabled = false;

                            dgv05003.Enabled = false;
                            btn05002011.Text = Cultures.ReturnTranslation("إلغاء");
                        }
                        else
                        {
                            btn05002011.Text = Cultures.ReturnTranslation("تعديل");

                            txt05002004.Enabled = false;
                            txt05002006.Enabled = false;
                            cmb05002008.Enabled = false;
                            cmb05002006.Enabled = false;

                            txt05002004.Focus();

                            btn05002009.Enabled = true;
                            btn05002010.Enabled = false;
                            btn05002011.Enabled = true;
                            btn05002012.Enabled = true;

                            dgv05003.Enabled = true;
                            dgv05003.Focus();
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }



                };
            }
        }
        private void btn05002012EventsAndProperties(bool Properties, bool Events = false) // حذف 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn05002012, "حذف");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn05002012, "حذف", ColorPropertyName.ForeColor_1, true, true);
                btn05002012.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Users_Accounts , PermissionType.Delete))
                    {

                        try
                        {
                            bool isActive = cb05002001.Checked ? true : false;

                            string[] result = null;
                            DataTools.DataBases.Run(ref result, "delete from TblUsersAccounts where UserAccountNo = @UserAccountNo", CommandType.Text, new object[][] { new object[] { "@UserAccountNo", Convert.ToInt32(txt05002002.Text) } });

                        }
                        catch (Exception ex)
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmAccount05  >>  btn05002012EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                        }

                        txt05002002.Text = "";
                        txt05002004.Text = "";
                        txt05002006.Text = "";
                        cmb05002008.SelectedIndex = -1;

                        // تحديث بيانات جدول البيانات
                        fillTblUsersAccounts();
                        dgv05003EventsAndProperties(true);
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }

                };
            }
        }

        private void dgv05003EventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات الحسابات
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblUsersAccounts.Rows.Count > 0)
                    {
                        dgv05003.DataSource = TblUsersAccounts;

                        dgv05003.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الحساب");

                        dgv05003.Columns[7].HeaderText = Cultures.ReturnTranslation("إسم الموظف");
                        dgv05003.Columns[8].HeaderText = Cultures.ReturnTranslation("إسم الموظف");

                        dgv05003.Columns[0].Width = dgv05003.Width / 4;
                        dgv05003.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv05003.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        dgv05003.Columns[1].Visible = false;
                        dgv05003.Columns[2].Visible = false;
                        dgv05003.Columns[3].Visible = false;
                        dgv05003.Columns[4].Visible = false;
                        dgv05003.Columns[5].Visible = false;
                        dgv05003.Columns[6].Visible = false;
                        dgv05003.Columns[9].Visible = false;
                        dgv05003.Columns[10].Visible = false;
                        dgv05003.Columns[11].Visible = false;


                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgv05003.Columns[7].Visible = true;
                            dgv05003.Columns[8].Visible = false;
                        }
                        else
                        {
                            dgv05003.Columns[7].Visible = false;
                            dgv05003.Columns[8].Visible = true;
                        }

                        ElementsTools.DataGridView_.CustumProperties(dgv05003);  // تخصيص خصائص جدول عرض البيانات
                    }
                    else
                    {
                        if (dgv05003.Rows.Count > 0) { dgv05003.DataSource = null; dgv05003.Rows.Clear(); };
                        ElementsTools.DataGridView_.CustumProperties(dgv05003);  // تخصيص خصائص جدول عرض البيانات
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmAccount05  >>  dgv05003EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (TblUsersAccounts.Rows.Count > 0)
                    {
                        dgv05003.DataSource = TblUsersAccounts;

                        dgv05003.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الحساب");

                        dgv05003.Columns[7].HeaderText = Cultures.ReturnTranslation("إسم الموظف");
                        dgv05003.Columns[8].HeaderText = Cultures.ReturnTranslation("إسم الموظف");

                        dgv05003.Columns[0].Width = dgv05003.Width / 4;
                        dgv05003.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv05003.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        dgv05003.Columns[1].Visible = false;
                        dgv05003.Columns[2].Visible = false;
                        dgv05003.Columns[3].Visible = false;
                        dgv05003.Columns[4].Visible = false;
                        dgv05003.Columns[5].Visible = false;
                        dgv05003.Columns[6].Visible = false;
                        dgv05003.Columns[9].Visible = false;
                        dgv05003.Columns[10].Visible = false;
                        dgv05003.Columns[11].Visible = false;


                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgv05003.Columns[7].Visible = true;
                            dgv05003.Columns[8].Visible = false;
                        }
                        else
                        {
                            dgv05003.Columns[7].Visible = false;
                            dgv05003.Columns[8].Visible = true;
                        }

                        ElementsTools.DataGridView_.CustumProperties(dgv05003, true, true);  // تخصيص خصائص جدول عرض البيانات
                    }
                    else
                    {
                        if (dgv05003.Rows.Count > 0) { dgv05003.DataSource = null; dgv05003.Rows.Clear(); };
                        ElementsTools.DataGridView_.CustumProperties(dgv05003, true, true);  // تخصيص خصائص جدول عرض البيانات
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmAccount05  >>  dgv05003EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                }
                

                dgv05003.SelectionChanged += delegate
                {
                    try
                    {
                        if (dgv05003.SelectedRows.Count < 1) return;
                        txt05002002.Text = dgv05003.SelectedRows[0].Cells[0].Value.ToString();
                        txt05002004.Text = SecurityTools.incryption.Decrypt(dgv05003.SelectedRows[0].Cells[1].Value.ToString());

                        int itemIndex0 = 0;
                        string str0 = dgv05003.SelectedRows[0].Cells[4].Value + "";
                        foreach (DataRowView item in cmb05002008.Items)
                        {
                            //MessageBox.Show(item[0].ToString()  + "    " + str0);
                            if (item[0].ToString() == str0) { cmb05002008.SelectedIndex = itemIndex0; break; }
                            itemIndex0++;
                        }

                        int itemIndex = 0;
                        string str = dgv05003.SelectedRows[0].Cells[3].Value + "";
                        foreach (DataRowView item in cmb05002006.Items)
                        {
                            if (item[0].ToString() == str) { cmb05002006.SelectedIndex = itemIndex; break; }
                            itemIndex++;
                        }

                        cb05002001.Checked = dgv05003.SelectedRows[0].Cells[5].Value.Equals(true | false);
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmAccount05  >>  dgv05003EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                    }

                };


                dgv05003.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv05003);  // تخصيص خصائص جدول عرض البيانات
                };
            }
        }






    }
}
