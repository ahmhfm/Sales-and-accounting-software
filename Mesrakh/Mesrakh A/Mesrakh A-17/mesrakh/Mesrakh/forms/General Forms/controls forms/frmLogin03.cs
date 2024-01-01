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
using static SecurityTools;

namespace Mesrakh
{
    public partial class frmLogin03 : Form
    {
        public frmLogin03()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع العناصر
        }

        public  void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmLogin03EventsAndProperties(Properties, Events); //  نموذج تسجيل الدخول
            pnl03001EventsAndProperties(Properties, Events); //  حاوية تسجيل الدخول
            lbl03001001EventsAndProperties(Properties, Events); // شريط تسميةاسم المستخدم
            txt03001002EventsAndProperties(Properties, Events); // مربع نص اسم المستخدم
            lbl03001003EventsAndProperties(Properties, Events); // شريط تسمية كلمة المرور 
            txt03001004EventsAndProperties(Properties, Events); // مربع نص كلمة المرور
            btn03001005EventsAndProperties(Properties, Events); // دخول للحساب
            btn03001006EventsAndProperties(Properties, Events); // خروج من الحساب
            lbl03001007EventsAndProperties(Properties, Events); // شريط بيانات الدخول
        }

        private  void frmLogin03EventsAndProperties(bool Properties, bool Events = false) //  نموذج تسجيل الدخول
        {

            if (Properties == true && Events==false)
            {
                ElementsTools.Form_.CustumProperties(this, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Form_.CustumProperties(this, ColorPropertyName.BackColor_2,true,true);
            }
        }

        private  void pnl03001EventsAndProperties(bool Properties, bool Events = false) //  حاوية تسجيل الدخول
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl03001, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl03001, ColorPropertyName.BackColor_2,true,true);
            }
        }

        private  void lbl03001001EventsAndProperties(bool Properties, bool Events = false) // ملصق تسميه اسم المستخدم
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl03001001, "إسم المستخدم");
                lbl03001001.BackColor = Color.Transparent;
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl03001001, "إسم المستخدم",ColorPropertyName.BackColor_1,ColorPropertyName.ForeColor_1,true,true);
                lbl03001001.BackColor = Color.Transparent;
            }
        }

        private void txt03001002EventsAndProperties(bool Properties, bool Events = false) // مربع نص اسم المستخدم
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt03001002,"en-us",50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt03001002, "en-us",50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt03001002.KeyDown += delegate (object sender, KeyEventArgs e) 
                {
                    if (e.KeyData == Keys.Enter) { txt03001004.Select(); };
                };
            }
        }


        private  void lbl03001003EventsAndProperties(bool Properties, bool Events = false) // ملصق تسميه كلمة المرور 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl03001003, "كلمة المرور");
                lbl03001003.BackColor = Color.Transparent;
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl03001003, "كلمة المرور", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl03001003.BackColor = Color.Transparent;
            }
        }

        private void txt03001004EventsAndProperties(bool Properties, bool Events = false) // مربط نص كلمة المرور
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt03001004, "en-us",50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt03001004, "en-us",50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt03001004.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btn03001005.PerformClick(); };
                };
            }
        }

        private  void btn03001005EventsAndProperties(bool Properties, bool Events = false) // دخول للحساب
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn03001005.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLoginBlue);
                    }
                    else
                    {
                        btn03001005.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLoginDark);
                    }
                    btn03001005.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmLogin03 >>  btn03001005EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }
                
            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn03001005.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLoginBlue);
                    }
                    else
                    {
                        btn03001005.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLoginDark);
                    }
                    btn03001005.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmLogin03 >>  btn03001005EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgEnter = null;
                btn03001005.MouseMove += delegate
                {
                    try
                    {
                        if (imgEnter == null)
                        {
                            imgEnter = btn03001005.Image;
                            btn03001005.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLoginOther);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmLogin03 >>  btn03001005EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
                btn03001005.MouseLeave += delegate
                {
                    try
                    {
                        btn03001005.Image = imgEnter;
                        imgEnter = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmLogin03 >>  btn03001005EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn03001005.Click += delegate
                {
                    lbl03001007.Text = "";
                    if (txt03001002.Text.Trim() == "" || txt03001004.Text.Trim() == "")
                    {
                        if (txt03001002.Text.Trim() == "")
                        {
                            lbl03001007.Text += Cultures.ReturnTranslation("رجاء قم بتسجيل إسم المستخدم") ;
                            txt03001002.Focus();
                            if (txt03001004.Text.Trim() == "")
                            {
                                lbl03001007.Text += "\n" + Cultures.ReturnTranslation("رجاء قم بتسجيل كلمة المرور");
                            }
                        }
                       else if (txt03001004.Text.Trim() == "")
                        {
                            lbl03001007.Text += Cultures.ReturnTranslation("رجاء قم بتسجيل كلمة المرور");
                            txt03001004.Focus();
                        }
                    }
                    else
                    {
                        try
                        {
                            GeneralVariables.ActiveAccount = new DataTable();
                            string userName = SecurityTools.incryption.Encrypt(txt03001002.Text);
                            string PassWord = SecurityTools.incryption.Encrypt(txt03001004.Text); 

                            string commandString = @"select * from TblUsersAccounts 
                                                        inner join TblEmployees on TblUsersAccounts.EmployeeNo = TblEmployees.EmployeeNo 
                                                        inner join TblUsersPermissionsGroup on TblUsersAccounts.PermissionGroupNo = TblUsersPermissionsGroup.PermissionGroupNo
                                                        inner join TblPermissions on TblUsersAccounts.PermissionGroupNo  = TblPermissions.PermissionGroupNo
                                                        inner join TblObjects on TblPermissions.ObjectNo = TblObjects.ObjectNo
                                                        where UserAccountName = @UserAccountName and UserAccountPassword = @UserAccountPassword";
                            //string commandString = @"select * from UsersAccounts241 where UserAccountName702 = @UserAccountName702 and UserAccountPassword703 = @UserAccountPassword703";
                            SqlCommand com = new SqlCommand(commandString, ConnectionsTools.ConMesrakhMainDB());
                            com.Parameters.AddWithValue("@UserAccountName", userName);
                            com.Parameters.AddWithValue("@UserAccountPassword", PassWord);

                            if (GeneralVariables.ActiveAccount.Rows.Count>0) { GeneralVariables.ActiveAccount.Rows.Clear(); GeneralVariables.ActiveAccount.Columns.Clear(); }
                            GeneralVariables.ActiveAccount.Load(com.ExecuteReader());

                            if (GeneralVariables.ActiveAccount.Rows.Count > 0)
                            {
                                // هل الحساب نشط
                                if (GeneralVariables.ActiveAccount.Rows[0][5].Equals(true || false) == true)
                                {
                                    //GeneralVariables._frmMain01.Controls["pnl01002"].Controls["pnl01002001"].Controls["btn01002001003"].Enabled = true;//btn01002001003
                                    (GeneralVariables._frmMain01 as frmMain01).btn01002001003.Enabled = true;
                                    (GeneralVariables._frmMain01 as frmMain01).btn01002001003.PerformClick();
                                }
                                else
                                {
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("الحساب غير نشط") , MessageBoxStatus.Ok);
                                    txt03001002.Focus();
                                }

                                //-----------
                                if (GeneralVariables.cultureCode == "AR")
                                {
                                    lbl03001007.Text = GeneralVariables.ActiveAccount.Rows[0][7].ToString();
                                }
                                else { lbl03001007.Text = GeneralVariables.ActiveAccount.Rows[0][8].ToString(); }
                                // ------------
                                btn03001005.Enabled = false;
                                btn03001006.Enabled = true;
                                txt03001002.Text = "";
                                txt03001002.Enabled = false;
                                txt03001004.Text = "";
                                txt03001004.Enabled = false;
                            }
                            else
                            {
                                GeneralVariables.ActiveAccount.Dispose();
                                GeneralVariables.ActiveAccount = new DataTable();

                                string currentUniqueID = specialDevices.getUniqueID( "c");


                                string commandString01 = @"select * from tbl002_Accounts
                                                 inner join tbl003_licenses on tbl002_Accounts.c001_AccountNo = tbl003_licenses.c008_AccountNo
                                                 inner join tbl004_licenseAndDevices on tbl003_licenses.c001_licenseNo = tbl004_licenseAndDevices.c003_licensNo
                                                 inner join tbl001_devices on tbl004_licenseAndDevices.c002_deviceAuotoNo = tbl001_devices.c001_deviceAuotoNo
                                                 where tbl002_Accounts.c002_userName = @c002_userName and tbl002_Accounts.c003_password = @c003_password and tbl001_devices.c002_DeviceNo = @c002_DeviceNo";
                                SqlCommand com01 = new SqlCommand(commandString01, ConnectionsTools.Conlicenses());
                                com01.Parameters.AddWithValue("@c002_userName", txt03001002.Text);
                                com01.Parameters.AddWithValue("@c003_password", txt03001004.Text);
                                com01.Parameters.AddWithValue("@c002_DeviceNo", currentUniqueID);

                                if (GeneralVariables.ActiveAccount.Rows.Count > 0) { GeneralVariables.ActiveAccount.Rows.Clear(); GeneralVariables.ActiveAccount.Columns.Clear(); }
                                GeneralVariables.ActiveAccount.Load(com01.ExecuteReader());

                                if (GeneralVariables.ActiveAccount.Rows.Count > 0)
                                {
                                    lbl03001007.Text = GeneralVariables.ActiveAccount.Rows[0][3].ToString();

                                    // ------------------------
                                    btn03001005.Enabled = false;
                                    btn03001006.Enabled = true;
                                    txt03001002.Text = "";
                                    txt03001002.Enabled = false;
                                    txt03001004.Text = "";
                                    txt03001004.Enabled = false;
                                    //GeneralVariables._frmMain01.Controls["pnl01002"].Controls["pnl01002001"].Controls["btn01002001003"].Enabled = true;
                                    (GeneralVariables._frmMain01 as frmMain01).btn01002001003.Enabled = true;
                                    (GeneralVariables._frmMain01 as frmMain01).btn01002001003.PerformClick();
                                }
                                else
                                {
                                    lbl03001007.Text = Cultures.ReturnTranslation("تأكد من صحة إسم المستخدم وكلمة المرور");
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmLogin03 >>  btn03001005EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                            lbl03001007.Text = Cultures.ReturnTranslation("توجد مشكلة في الاتصال");

                        }

                    }

                };

            }
        }

        private  void btn03001006EventsAndProperties(bool Properties, bool Events = false) // خروج من الحساب
        {


            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn03001006.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgExitBlue);
                    }
                    else
                    {
                        btn03001006.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgExitDark);
                    }
                    btn03001006.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmLogin03 >>  btn03001006EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn03001006.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgExitBlue);
                    }
                    else
                    {
                        btn03001006.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgExitDark);
                    }
                    btn03001006.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmLogin03 >>  btn03001006EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgEnter = null;
                btn03001006.MouseMove += delegate
                {
                    try
                    {
                        if (imgEnter == null)
                        {
                            imgEnter = btn03001006.Image;
                            btn03001006.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgExitOther);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmLogin03 >>  btn03001006EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
                btn03001006.MouseLeave += delegate
                {
                    try
                    {
                        btn03001006.Image = imgEnter;
                        imgEnter = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmLogin03 >>  btn03001006EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn03001006.Click += delegate
                {
                    try
                    {
                        // --- 
                        btn03001005.Enabled = true;
                        btn03001006.Enabled = false;
                        txt03001002.Enabled = true;
                        txt03001002.Focus();
                        txt03001004.Enabled = true;
                        lbl03001007.Text = "";
                        GeneralVariables._frmMain01.Controls["pnl01002"].Controls["pnl01002001"].Controls["btn01002001003"].Enabled = false;
                        GeneralVariables._frmMain01.Controls["pnl01003"].Controls.Clear();

                        GeneralAction.CloseAllForms(); // اغلاق جميع النماذج وذلك بسبب الخروج من الحساب

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmLogin03 >>  btn03001006EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }



                };
            }

        }

        private  void lbl03001007EventsAndProperties(bool Properties, bool Events = false) // ملصق بيانات الدخول
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    lbl03001007.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                    lbl03001007.TextAlign = ContentAlignment.MiddleCenter;
                    lbl03001007.BackColor = Color.Transparent;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmLogin03 >>  btn03001006EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    lbl03001007.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                    lbl03001007.TextAlign = ContentAlignment.MiddleCenter;
                    lbl03001007.BackColor = Color.Transparent;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmLogin03 >>  btn03001006EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
        }

    }
}
