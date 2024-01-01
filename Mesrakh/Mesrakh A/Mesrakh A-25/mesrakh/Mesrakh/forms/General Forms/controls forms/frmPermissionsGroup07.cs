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
    public partial class frmPermissionsGroup07 : Form
    {
        public frmPermissionsGroup07()
        {

            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {

            frm07EventsAndProperties(Properties, Events); // النموذج
            pnl07001EventsAndProperties(Properties, Events); // الحاوية الرئيسية
            pnl07001001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl07001001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج

            pnl07001002EventsAndProperties(Properties, Events); // الحاوية الوسطية
            lbl07001002001EventsAndProperties(Properties, Events); // رقم المجموعة
            txt07001002001EventsAndProperties(Properties, Events); // رقم المجموعة
            lbl07001002002EventsAndProperties(Properties, Events); // اسم المجموعة عربي
            txt07001002002EventsAndProperties(Properties, Events); // اسم المجموعة عربي
            lbl07001002003EventsAndProperties(Properties, Events); // اسم المجموعة انجليزي
            txt07001002003EventsAndProperties(Properties, Events); // اسم المجموعة انجليزي
            btn07001002001EventsAndProperties(Properties, Events); // جديد
            btn07001002002EventsAndProperties(Properties, Events); // حفظ
            btn07001002003EventsAndProperties(Properties, Events); // تعديل
            btn07001002004EventsAndProperties(Properties, Events); // حذف
            pnl07001003EventsAndProperties(Properties, Events); // الحاوية السفلية
            lbx07001003001EventsAndProperties(Properties, Events); //  قائمة عرض اسماء مجموعات الصلاحيات
            dgv07001003001EventsAndProperties(Properties, Events); // جدول عرض البيانات

            btn07001003001EventsAndProperties(Properties, Events); //تعديل وحفظ الصلاحيات

        }

        private void frm07EventsAndProperties(bool Properties, bool Events = false) // النموذج 
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

        private void pnl07001EventsAndProperties(bool Properties, bool Events = false) // الحاوية الرئيسية
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl07001);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl07001, ColorPropertyName.BackColor_3, true, true);
            }
        }

        private void pnl07001001EventsAndProperties(bool Properties, bool Events = false) // الحاوية العلوية
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl07001001);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl07001001, ColorPropertyName.BackColor_3, true, true);
            }
        }

        private void lbl07001001001EventsAndProperties(bool Properties, bool Events = false) // ملصق عنوان النموذج 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl07001001001, "مجموعات الصلاحيات", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl07001001001, "مجموعات الصلاحيات", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void pnl07001002EventsAndProperties(bool Properties, bool Events = false) // الحاوية الوسطية
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl07001002);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl07001002, ColorPropertyName.BackColor_3, true, true);
            }
        }

        private void lbl07001002001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم المجموعة  
        {


            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl07001002001, "رقم المجموعة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl07001002001, "رقم المجموعة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt07001002001EventsAndProperties(bool Properties, bool Events = false) // صندوق نص رقم المجموعة  
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt07001002001,"",10);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt07001002001, "",10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lbl07001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق اسم المجموعة عربي 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl07001002002, "إسم المجموعة عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl07001002002, "إسم المجموعة عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt07001002002EventsAndProperties(bool Properties, bool Events = false) // صندوق نص اسم المجموعة عربي  
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt07001002002, "ar-sa",100);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt07001002002, "ar-sa",100, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt07001002002.KeyDown += delegate(object sender,KeyEventArgs e)
                {
                    if(e.KeyData == Keys.Enter)
                    {
                        txt07001002003.Select();
                    }
                };
            }
        }

        private void lbl07001002003EventsAndProperties(bool Properties, bool Events = false) // ملصق اسم المجموعة انجليزي 
        {


            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl07001002003, "إسم المجموعة إنجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl07001002003, "إسم المجموعة إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt07001002003EventsAndProperties(bool Properties, bool Events = false) // صندوق نص اسم المجموعة انجليزي  
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt07001002003, "en-us",100);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt07001002003, "en-us",100, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt07001002003.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter)
                    {
                        btn07001002002.PerformClick();
                    }
                };
            }
        }

        private void btn07001002001EventsAndProperties(bool Properties, bool Events = false) // جديد 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn07001002001,"جديد" );
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn07001002001, "جديد", ColorPropertyName.ForeColor_1, true, true);

                btn07001002001.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Manage_User_Group_Permissions , PermissionType.Add))
                    {

                        if (btn07001002001.Text == Cultures.ReturnTranslation("جديد"))
                        {
                            btn07001002001.Text = Cultures.ReturnTranslation("إلغاء");

                            txt07001002001.Text = "";
                            txt07001002002.Text = "";
                            txt07001002003.Text = "";

                            txt07001002002.Enabled = true;
                            txt07001002003.Enabled = true;

                            btn07001002002.Enabled = true;
                            btn07001002003.Enabled = false;
                            btn07001002004.Enabled = false;

                            txt07001002002.Focus();
                        }
                        else
                        {
                            btn07001002001.Text = Cultures.ReturnTranslation("جديد");

                            txt07001002002.Enabled = false;
                            txt07001002003.Enabled = false;

                            btn07001002002.Enabled = false;
                            btn07001002003.Enabled = true;
                            btn07001002004.Enabled = true;

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

        private void btn07001002002EventsAndProperties(bool Properties, bool Events = false) // حفظ 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn07001002002, "حفظ");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn07001002002, "حفظ", ColorPropertyName.ForeColor_1, true, true);

                btn07001002002.Click += delegate
                {

                    try
                    {
                        if (btn07001002001.Text == Cultures.ReturnTranslation("إلغاء"))
                        {
                            string Error = "";
                            if (txt07001002002.Text=="")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسمية المجموعة باللغة العربية");
                                txt07001002002.Focus();
                            }
                            else if (txt07001002003.Text=="")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسمية المجموعة باللغة الإنجليزية");
                                txt07001002003.Focus();
                            }
                            else
                            {
                                bool? SameArabicName = ElementsTools.ListBox_.findValueThenSelected(lbx07001003001, ActionType.add, txt07001002002.Text, 1);
                                bool? SameEnglishName = ElementsTools.ListBox_.findValueThenSelected(lbx07001003001, ActionType.add, txt07001002003.Text, 2);

                                if(SameArabicName == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد مجموعة بنفس الإسم العربي");
                                    txt07001002002.Select();
                                }
                                else
                                {
                                    if(SameEnglishName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد مجموعة بنفس الإسم الإنجليزي");
                                        txt07001002003.Select();
                                    }
                                }

                            }

                            if (Error == "")
                            {
                                string[] result = null;
                                object PermissionGroupNo = DataTools.DataBases.Run( ref result ,"SpAddUsersPermissionsGroup", CommandType.StoredProcedure, new object[][] { new object[] { "@PermissionGroupNameAR", txt07001002002.Text.Replace("'","") }, new object[] { "@PermissionGroupNameEN", txt07001002003.Text.Replace("'","") }, new object[] { "@PermissionGroupNo", "OUT" } });

                                //string CommandString = "SpAddUsersPermissionsGroup";
                                //SqlCommand com = new SqlCommand(CommandString, ConnectionsTools.ConMesrakhMainDB());
                                //com.CommandType = CommandType.StoredProcedure;
                                //com.Parameters.AddWithValue("@PermissionGroupNameAR", txt07001002002.Text);
                                //com.Parameters.AddWithValue("@PermissionGroupNameEN", txt07001002003.Text);
                                //com.Parameters.AddWithValue("@PermissionGroupNo", SqlDbType.Int).Direction = ParameterDirection.Output;
                                //com.ExecuteNonQuery();
                                //int PermissionGroupNo = int.Parse(com.Parameters["@PermissionGroupNo"].Value.ToString());

                                txt07001002001.Text = PermissionGroupNo.ToString();

                                filltblPermissionsGroup();
                                filltblPermissions();

                                if (lbx07001003001.Items.Count > 0) { lbx07001003001.DataSource = null; lbx07001003001.Items.Clear(); }
                                lbx07001003001.DataSource = tblPermissionsGroup;
                                lbx07001003001.ValueMember = "PermissionGroupNo";
                                if (GeneralVariables.cultureCode == "AR")
                                {
                                    lbx07001003001.DisplayMember = "PermissionGroupNameAR";
                                }
                                else
                                {
                                    lbx07001003001.DisplayMember = "PermissionGroupNameEN";
                                }

                                //---------------------------- 

                                txt07001002002.Enabled = false;
                                txt07001002003.Enabled = false;

                                btn07001002001.Enabled = true;
                                btn07001002002.Enabled = false;
                                btn07001002003.Enabled = true;
                                btn07001002004.Enabled = true;

                                btn07001002001.Text = Cultures.ReturnTranslation("جديد");

                                dgv07001003001EventsAndProperties(true);

                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);
                                txt07001002001.Text = "";
                            }

                        }
                        else if (txt07001002001.Text != "" && btn07001002003.Text== Cultures.ReturnTranslation("إلغاء"))
                        {
                            string Error = "";
                            if (txt07001002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسمية المجموعة باللغة العربية");
                                txt07001002002.Focus();
                            }
                            else if (txt07001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسمية المجموعة باللغة الإنجليزية");
                                txt07001002003.Focus();
                            }
                            else
                            {
                                bool? SameArabicName = ElementsTools.ListBox_.findValueThenSelected(lbx07001003001, ActionType.edit, txt07001002002.Text, 1);
                                bool? SameEnglishName = ElementsTools.ListBox_.findValueThenSelected(lbx07001003001, ActionType.edit, txt07001002003.Text, 2);

                                if (SameArabicName == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد مجموعة بنفس الإسم العربي");
                                    txt07001002002.Select();
                                }
                                else
                                {
                                    if (SameEnglishName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد مجموعة بنفس الإسم الإنجليزي");
                                        txt07001002003.Select();
                                    }
                                }

                            }

                            if(Error == "")
                            {

                                string[] result = null;
                                DataTools.DataBases.Run(ref result, "update TblUsersPermissionsGroup set PermissionGroupNameAR = @PermissionGroupNameAR ,PermissionGroupNameEN = @PermissionGroupNameEN  where PermissionGroupNo =  @PermissionGroupNo ", CommandType.Text, new object[][] { new object[] { "@PermissionGroupNameAR", txt07001002002.Text.Replace("'","") }, new object[] { "@PermissionGroupNameEN", txt07001002003.Text.Replace("'","") }, new object[] { "@PermissionGroupNo", txt07001002001.Text.Replace("'","") } });

                                //string CommandString = "update TblUsersPermissionsGroup set PermissionGroupNameAR = @PermissionGroupNameAR ,PermissionGroupNameEN = @PermissionGroupNameEN  where PermissionGroupNo =  @PermissionGroupNo ";
                                //SqlCommand com = new SqlCommand(CommandString, ConnectionsTools.ConMesrakhMainDB());
                                //com.Parameters.AddWithValue("@PermissionGroupNameAR", txt07001002002.Text);
                                //com.Parameters.AddWithValue("@PermissionGroupNameEN", txt07001002003.Text);
                                //com.Parameters.AddWithValue("@PermissionGroupNo", SqlDbType.Int).Value = int.Parse(txt07001002001.Text);
                                //com.ExecuteNonQuery();

                                filltblPermissionsGroup();
                                filltblPermissions();

                                if (lbx07001003001.Items.Count > 0) { lbx07001003001.DataSource = null; lbx07001003001.Items.Clear(); }
                                lbx07001003001.DataSource = tblPermissionsGroup;
                                lbx07001003001.ValueMember = "PermissionGroupNo";
                                if (GeneralVariables.cultureCode == "AR")
                                {
                                    lbx07001003001.DisplayMember = "PermissionGroupNameAR";
                                }
                                else
                                {
                                    lbx07001003001.DisplayMember = "PermissionGroupNameEN";
                                }

                                // ------------------------------- 

                                txt07001002002.Enabled = false;
                                txt07001002003.Enabled = false;

                                btn07001002001.Enabled = true;
                                btn07001002002.Enabled = false;
                                btn07001002003.Enabled = true;
                                btn07001002004.Enabled = true;

                                btn07001002003.Text = Cultures.ReturnTranslation("تعديل");

                                dgv07001003001EventsAndProperties(true);

                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);

                            }

                        }
                        if (GeneralVariables._frmAccount05 != null) GeneralVariables._frmAccount05 = null;  // لكي يتم تحديث القائمة المنسدلة في نموذج الحسابات
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmPermissionsGroup07 >>  btn07001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        btn07001002001.Text = Cultures.ReturnTranslation("جديد");
                        btn07001002003.Text = Cultures.ReturnTranslation("تعديل");
                    }


                    if (btn07001002001.Text == Cultures.ReturnTranslation("إلغاء"))
                    {
                        btn07001002001.Select();
                    }
                        
                       


                };

            }
        }

        private void btn07001002003EventsAndProperties(bool Properties, bool Events = false) // تعديل 
        {


            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn07001002003, "تعديل");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn07001002003, "تعديل", ColorPropertyName.ForeColor_1, true, true);

                btn07001002003.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Manage_User_Group_Permissions, PermissionType.Edit))
                        {
                            if (btn07001002003.Text == Cultures.ReturnTranslation("تعديل"))
                            {
                                btn07001002003.Text = Cultures.ReturnTranslation("إلغاء");

                                txt07001002002.Enabled = true;
                                txt07001002003.Enabled = true;

                                btn07001002001.Enabled = false;
                                btn07001002002.Enabled = true;
                                btn07001002004.Enabled = false;



                            }
                            else
                            {
                                btn07001002003.Text = Cultures.ReturnTranslation("تعديل");

                                txt07001002002.Enabled = false;
                                txt07001002003.Enabled = false;

                                btn07001002001.Enabled = true;
                                btn07001002002.Enabled = false;
                                btn07001002004.Enabled = true;

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
                        GeneralAction.AddNewNotification("frmPermissionsGroup07 >>  btn07001002003EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                };

            }
        }

        private void btn07001002004EventsAndProperties(bool Properties, bool Events = false) // حذف 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn07001002004, "حذف");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn07001002004, "حذف", ColorPropertyName.ForeColor_1, true, true);

                btn07001002004.Click += delegate
                {
                    try
                    {

                        if (Permissions.AccountHavePermission(PermissionObjectes.Manage_User_Group_Permissions, PermissionType.Delete))
                        {
                            if (txt07001002001.Text.Trim() != "")
                            {

                                string[] result = null;
                                DataTools.DataBases.Run(ref result, "delete from TblPermissions where PermissionGroupNo =  @PermissionGroupNo ; delete from TblUsersAccounts where  PermissionGroupNo =  @PermissionGroupNo ;  delete from TblUsersPermissionsGroup  where PermissionGroupNo =  @PermissionGroupNo ", CommandType.Text, new object[][] { new object[] { "@PermissionGroupNo", txt07001002001.Text.Replace("'", "") } });


                                //string CommandString = "delete from TblPermissions where PermissionGroupNo =  @PermissionGroupNo ; delete from TblUsersAccounts where  PermissionGroupNo =  @PermissionGroupNo ;  delete from TblUsersPermissionsGroup  where PermissionGroupNo =  @PermissionGroupNo ";
                                //SqlCommand com = new SqlCommand(CommandString, ConnectionsTools.ConMesrakhMainDB());

                                //com.Parameters.AddWithValue("@PermissionGroupNo", SqlDbType.Int).Value = int.Parse(txt07001002001.Text);
                                //com.ExecuteNonQuery();

                                txt07001002001.Text = "";
                                txt07001002002.Text = "";
                                txt07001002003.Text = "";


                                filltblPermissionsGroup();
                                filltblPermissions();

                                if (lbx07001003001.Items.Count > 0) { lbx07001003001.DataSource = null; lbx07001003001.Items.Clear(); }
                                lbx07001003001.DataSource = tblPermissionsGroup;
                                lbx07001003001.ValueMember = "PermissionGroupNo";
                                if (GeneralVariables.cultureCode == "AR")
                                {
                                    lbx07001003001.DisplayMember = "PermissionGroupNameAR";
                                }
                                else
                                {
                                    lbx07001003001.DisplayMember = "PermissionGroupNameEN";
                                }

                                dgv07001003001EventsAndProperties(true);
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
                        GeneralAction.AddNewNotification("frmPermissionsGroup07 >>  btn07001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }



                };

            }
        }



        private void pnl07001003EventsAndProperties(bool Properties, bool Events = false) // الحاوية السفلية
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl07001003);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl07001003, ColorPropertyName.BackColor_3, true, true);
            }
        }


        private void lbx07001003001EventsAndProperties(bool Properties, bool Events = false) // قائمة عرض اسماء مجموعات الصلاحيات
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (lbx07001003001.Items.Count > 0) { lbx07001003001.DataSource = null; lbx07001003001.Items.Clear(); }
                    lbx07001003001.DataSource = tblPermissionsGroup;
                    lbx07001003001.ValueMember = "PermissionGroupNo";
                    if (GeneralVariables.cultureCode == "AR")
                    {
                        lbx07001003001.DisplayMember = "PermissionGroupNameAR";
                    }
                    else
                    {
                        lbx07001003001.DisplayMember = "PermissionGroupNameEN";
                    }

                    ElementsTools.ListBox_.CustumProperties(lbx07001003001);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmPermissionsGroup07 >>  lb07001003001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                filltblPermissionsGroup();
                try
                {

                    if (lbx07001003001.Items.Count > 0) { lbx07001003001.DataSource = null; lbx07001003001.Items.Clear(); }
                    lbx07001003001.DataSource = tblPermissionsGroup;
                    lbx07001003001.ValueMember = "PermissionGroupNo";
                    if (GeneralVariables.cultureCode == "AR")
                    {
                        lbx07001003001.DisplayMember = "PermissionGroupNameAR";
                    }
                    else
                    {
                        lbx07001003001.DisplayMember = "PermissionGroupNameEN";
                    }

                    ElementsTools.ListBox_.CustumProperties(lbx07001003001);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmPermissionsGroup07 >>  lb07001003001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


                lbx07001003001.SelectedIndexChanged += delegate
                {
                    try
                    {
                        fillParmissionDataByLestBox();
                        if (lbx07001003001.SelectedIndex > -1)
                        {
                            if (lbx07001003001.SelectedValue + "" == "System.Data.DataRowView") return;
                            DataRow[] dr = tblPermissionsGroup.Select("PermissionGroupNo = " + lbx07001003001.SelectedValue);
                            txt07001002001.Text = dr[0][0].ToString();
                            txt07001002002.Text = dr[0][1].ToString();
                            txt07001002003.Text = dr[0][2].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmPermissionsGroup07 >>  lb07001003001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                ElementsTools.ListBox_.CustumProperties(lbx07001003001, true, true);
            }
        }


        private void dgv07001003001EventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات صلاحيات المجموعات
        {
            if (Properties == true && Events == false)
            {
                fillParmissionDataByLestBox();
                //ElementsTools.DataGridView_.CustumProperties(dgv07001003001);
            }
            else if (Properties == true && Events == true)
            {
                filltblPermissions();
                fillParmissionDataByLestBox();
                ElementsTools.DataGridView_.CustumProperties(dgv07001003001, true, true);

                dgv07001003001.DataBindingComplete += delegate
                {
                    if(btn07001003001.Text != Cultures.ReturnTranslation("حفظ الصلاحيات") ) // يتم التحديث مع التنقل من صف الى صف اذا كان مسموح بتغيير البيانات
                    {
                        ElementsTools.DataGridView_.CustumProperties(dgv07001003001);  // تخصيص خصائص جدول عرض البيانات

                    }
                };
            }
        }




        private void btn07001003001EventsAndProperties(bool Properties, bool Events = false) // تعديل الصلاحيات 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn07001003001, "تعديل الصلاحيات");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn07001003001, "تعديل الصلاحيات", ColorPropertyName.ForeColor_1, true, true);

                btn07001003001.Click += delegate
                {

                    try
                    {

                        if (Permissions.AccountHavePermission(PermissionObjectes.Manage_User_Group_Permissions, PermissionType.Edit))
                        {

                            if (btn07001003001.Text == Cultures.ReturnTranslation("تعديل الصلاحيات"))
                            {
                                btn07001003001.Text = Cultures.ReturnTranslation("حفظ الصلاحيات");
                                dgv07001003001.ReadOnly = false;
                                lbx07001003001.Enabled = false; 
                            }
                            else
                            {
                                btn07001003001.Text = Cultures.ReturnTranslation("تعديل الصلاحيات");
                                dgv07001003001.ReadOnly = true;
                                lbx07001003001.Enabled = true;
                                //-------
                                string commandString = @"update TblPermissions set ShowData = @ShowData,AddData = @AddData,EditData = @EditData,DeleteData = @DeleteData where PermissionGroupNo = @PermissionGroupNo and ObjectNo = @ObjectNo ";
                                bool ShowData;
                                bool AddData;
                                bool EditData;
                                bool DeleteData;
                                int PermissionGroupNo;
                                int ObjectNo;
                                for (int row = 0; row < dgv07001003001.Rows.Count; row++)
                                {
                                    ShowData = dgv07001003001.Rows[row].Cells[6].Value.Equals(true || false);
                                    AddData = dgv07001003001.Rows[row].Cells[7].Value.Equals(true || false);
                                    EditData = dgv07001003001.Rows[row].Cells[8].Value.Equals(true || false);
                                    DeleteData = dgv07001003001.Rows[row].Cells[9].Value.Equals(true || false);
                                    PermissionGroupNo = int.Parse(dgv07001003001.Rows[row].Cells[0].Value.ToString());
                                    ObjectNo = int.Parse(dgv07001003001.Rows[row].Cells[3].Value.ToString());


                                    string[] result = null;
                                    DataTools.DataBases.Run(ref result, commandString, CommandType.Text, new object[][] { new object[] { "@ShowData", ShowData }, new object[] { "@AddData", AddData }, new object[] { "@EditData", EditData }, new object[] { "@DeleteData", DeleteData }, new object[] { "@PermissionGroupNo", PermissionGroupNo }, new object[] { "@ObjectNo", ObjectNo } });
                                }

                                filltblPermissions();
                                dgv07001003001EventsAndProperties(true);
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmPermissionsGroup07 >> btn07001003001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmPermissionsGroup07 >>  btn07001003001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                    
                };
            }
        }

        //---------------------------------------------------------

        DataTable tblPermissions = new DataTable();
        DataTable tblPermissionsGroup = new DataTable();

        public void filltblPermissions() // مجموعات الصلاحيات مع الصلاحيات
        {
            string commandString = @"select TblUsersPermissionsGroup.PermissionGroupNo,TblUsersPermissionsGroup.PermissionGroupNameAR,TblUsersPermissionsGroup.PermissionGroupNameEN,TblObjects.ObjectNo,TblObjects.ObjectNameAR,TblObjects.ObjectNameEN,TblPermissions.ShowData,TblPermissions.AddData,TblPermissions.EditData,TblPermissions.DeleteData 
                                    from TblUsersPermissionsGroup
                                    inner join  TblPermissions on TblUsersPermissionsGroup.PermissionGroupNo = TblPermissions.PermissionGroupNo
                                    inner join TblObjects on TblPermissions.ObjectNo = TblObjects.ObjectNo";
            try
            {

                tblPermissions =  DataTools.DataBases.ReadTabel( commandString);

               //SqlCommand com = new SqlCommand(commandString, ConnectionsTools.ConMesrakhMainDB());
               // GeneralVariables.Permissions = new DataTable();
               // GeneralVariables.Permissions.Load(com.ExecuteReader());
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("Mesrakh  >> frmPermissionsGroup07  >>  fillpermission ", DateTime.Now, " مشكلة عند تعبئة جدول الصلاحيات  ", ex.Message);
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("توجد مشكلة في الإتصال") , MessageBoxStatus.Ok);
            }

        }

        public void filltblPermissionsGroup() // مجموعات الصلاحيات 
        {

            string commandString = @"select * from TblUsersPermissionsGroup";
            try
            {
                tblPermissionsGroup = DataTools.DataBases.ReadTabel( commandString);
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("Mesrakh  >> frmPermissionsGroup07  >>  fillPermissionsGroups ", DateTime.Now, " مشكلة عند تعبئة جدول مجموعات الصلاحيات  ", ex.Message);
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("توجد مشكلة في الإتصال") , MessageBoxStatus.Ok);
            }

        }

        public void fillParmissionDataByLestBox() // تعبئة جدول عرض البيانات بالبيانات من خلال قيمة صندوق القائيمة
        {
            try
            {
                //if (GeneralVariables.Permissions is null) return;
                if (tblPermissions.Rows.Count > 0)
                {
                    DataTable subDt = new DataTable();

                    if (lbx07001003001.SelectedIndex > -1)
                    {
                        subDt.Rows.Clear();
                        subDt.Columns.Clear();
                        foreach (DataColumn dc in tblPermissions.Columns)
                        {
                            subDt.Columns.Add(dc.ColumnName, dc.DataType);
                        }


                        string s = "PermissionGroupNo = " + lbx07001003001.SelectedValue;
                        if (lbx07001003001.SelectedValue + "" == "System.Data.DataRowView") return;
                        DataRow[] drArray = tblPermissions.Select(s);
                        if (drArray.Length > 0)
                        {
                            foreach (DataRow dr in drArray)
                            {
                                subDt.ImportRow(dr);
                            }
                        }
                        dgv07001003001.DataSource = subDt;
                        //ElementsTools.DataGridView_.CustumProperties(dgv07001003001);  // تخصيص خصائص جدول عرض البيانات  ?????????????????????????????????????????????????????????


                        dgv07001003001.Columns[0].Visible = false;
                        dgv07001003001.Columns[1].Visible = false;
                        dgv07001003001.Columns[2].Visible = false;

                        dgv07001003001.Columns[3].Visible = false;


                        dgv07001003001.Columns[4].HeaderText = "إسم الصلاحية";
                        dgv07001003001.Columns[5].HeaderText = "permission Name";

                        dgv07001003001.Columns[6].HeaderText = Cultures.ReturnTranslation("عرض");
                        dgv07001003001.Columns[7].HeaderText = Cultures.ReturnTranslation("إضافة");
                        dgv07001003001.Columns[8].HeaderText = Cultures.ReturnTranslation("تعديل");
                        dgv07001003001.Columns[9].HeaderText = Cultures.ReturnTranslation("حذف");

                        dgv07001003001.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv07001003001.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv07001003001.Columns[6].Width = dgv07001003001.Width / 8;
                        dgv07001003001.Columns[7].Width = dgv07001003001.Width / 8;
                        dgv07001003001.Columns[8].Width = dgv07001003001.Width / 8;
                        dgv07001003001.Columns[9].Width = dgv07001003001.Width / 8;


                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgv07001003001.Columns[4].Visible = true;
                            dgv07001003001.Columns[5].Visible = false;
                        }
                        else
                        {
                            dgv07001003001.Columns[4].Visible = false;
                            dgv07001003001.Columns[5].Visible = true;
                        }

                        dgv07001003001.ScrollBars = ScrollBars.Vertical;


                    }
                }
                else
                {
                    if (dgv07001003001.Rows.Count > 0) { dgv07001003001.DataSource = null; dgv07001003001.Rows.Clear(); };

                }
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmPermissionsGroup07 >>  fillParmissionDataByLestBox ", DateTime.Now, ex.Message, ex.Message);
            }
            
        }


    }
}
