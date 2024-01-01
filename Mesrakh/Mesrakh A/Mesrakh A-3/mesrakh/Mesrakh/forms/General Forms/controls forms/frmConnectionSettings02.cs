using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mesrakh
{
    public partial class frmConnectionSettings02 : Form
    {

        public frmConnectionSettings02()
        {
            InitializeComponent(); // اضافة وتخصيص جميع العناصر
            AllEventsAndProperties(true, true); // الخصائص والاحداث لجميع العناصر
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmConnectionSettings02EventsAndProperties(Properties, Events);// اغلاق البرنامج
            pnl02001EventsAndProperties(Properties, Events);// اعلى الحاويات
            lbl02001001EventsAndProperties(Properties, Events); // ملصق قاعدة البيانات
            cmb01001002EventsAndProperties(Properties, Events); // قائمة قاعدة البيانات
            lbl02001003EventsAndProperties(Properties, Events); // ملصق نوع قاعدة البيانات
            cmb02001004EventsAndProperties(Properties, Events); // قائمة نوع قاعدة البيانات
            lbl02001005EventsAndProperties(Properties, Events); // ملصق موقع السيرفر
            cmb02001006EventsAndProperties(Properties, Events); // قائمة موقع السيرفر
            pnl02002EventsAndProperties(Properties, Events); // الحاوية الثانية
            lbl02002001EventsAndProperties(Properties, Events); // ملصق اسم السيرفر المحلي
            cmb02002002EventsAndProperties(Properties, Events); // قائمة اسماء السيرفرات المحلية
            lbl02002003EventsAndProperties(Properties, Events); // ملصق المصادقة
            cmb02002004EventsAndProperties(Properties, Events); // قائمة انواع المصادقة
            pnl02003EventsAndProperties(Properties, Events); // الحاوية الثالثة
            lbl02003001EventsAndProperties(Properties, Events); // ملصق رقم الآي بي
            txt02003002EventsAndProperties(Properties, Events); // صندوق نص رقم الآي بي
            pnl02004EventsAndProperties(Properties, Events); // الحاوية الرابعة
            lbl02004001EventsAndProperties(Properties, Events); // ملصق اسم المستخدم
            txt02004002EventsAndProperties(Properties, Events); // صندوق نص اسم المستخدم
            lbl02004003EventsAndProperties(Properties, Events); // ملصق كلمة المرور
            txt02004004EventsAndProperties(Properties, Events); // صندوق نص كلمة المرور
            pnl02005EventsAndProperties(Properties, Events); // الحاوية الخامسة
            lbl02005001EventsAndProperties(Properties, Events); // ملصق نص الاتصال 
            txt02005002EventsAndProperties(Properties, Events); // صندوق نص الاتصال 
            pnl02006EventsAndProperties(Properties, Events); // الحاوية السادسة
            btn02006001EventsAndProperties(Properties, Events); // زر فحص الاتصال وتغيير اعداداته
            
        }

        private void frmConnectionSettings02EventsAndProperties(bool Properties, bool Events = false) // النموذج الرئيسي
        {

            if (Properties == true && Events == false)
            {
                this.BackColor = DisplayMode.ReturnColor(myElementType.Form, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true && Events == true)
            {
                this.BackColor = DisplayMode.ReturnColor(myElementType.Form, ColorPropertyName.BackColor_2);

                this.Load += delegate
                {
                    try
                    {
                        GeneralVariables.LocaleInstances = ConnectionsTools.ReadAllInstancesOnLocalMachine(); // رفع جميع السيرفرات المحلية
                        cmb02002002.DataSource = GeneralVariables.LocaleInstances;

                        cmb02001002.SelectedIndex = 0;
                        cmb02001004.SelectedIndex = 0;
                        cmb02001006.SelectedIndex = 0;
                        if (GeneralVariables.LocaleInstances.Length > 0) { cmb02002002.SelectedIndex = 0; }
                        cmb02002004.SelectedIndex = 0;


                        //Cultures.cheangeCultuer(this, GeneralVariables.cultureCode); // اللغة
                        AllEventsAndProperties(true); // اللغة
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmConnectionSettings02 >>  frmConnectionSettings02EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }

        private void pnl02001EventsAndProperties(bool Properties, bool Events = false) // الحاوية العلوية
        {


            if (Properties == true && Events == false)
            {
                pnl02001.BackColor = DisplayMode.ReturnColor(myElementType.Panel, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true && Events == true)
            {
                pnl02001.BackColor = DisplayMode.ReturnColor(myElementType.Panel, ColorPropertyName.BackColor_2);
            }
        }

        private void lbl02001001EventsAndProperties(bool Properties, bool Events = false) // ملصق قاعدة البيانات
        {


            if (Properties == true && Events == false)
            {
                lbl02001001.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02001001.Text = Cultures.ReturnTranslation("إسم قاعدة البيانات");
            }
            else if (Properties == true && Events == true)
            {
                lbl02001001.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02001001.Text = Cultures.ReturnTranslation("إسم قاعدة البيانات");
            }
        }

        private void cmb01001002EventsAndProperties(bool Properties, bool Events = false) // قائمة قاعدة البيانات
        {

            if (Properties == true && Events == false)
            {
                cmb02001002.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_1);
                cmb02001002.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                cmb02001002.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_1);
                cmb02001002.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_1);

                cmb02001002.SelectedIndexChanged += delegate 
                {
                    OpenAndClosePanel();
                };
            }

        }

        private void lbl02001003EventsAndProperties(bool Properties, bool Events = false) // ملصق نوع قاعدة البيانات 
        {

            if (Properties == true && Events == false)
            {
                lbl02001003.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02001003.Text = Cultures.ReturnTranslation("نوع قاعدة البيانات");
            }
            else if (Properties == true && Events == true)
            {
                lbl02001003.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02001003.Text = Cultures.ReturnTranslation("نوع قاعدة البيانات");


            }
        }

        private void cmb02001004EventsAndProperties(bool Properties, bool Events = false) // قائمة نوع قاعدة البيانات
        {

            // الخصائص
            if (Properties == true && Events == false)
            {
                cmb02001004.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_1);
                cmb02001004.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_1);
            }
            else if (Properties == true && Events == true)
            {
                cmb02001004.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_1);
                cmb02001004.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_1);

                cmb02001004.SelectedIndexChanged += delegate
                {
                    OpenAndClosePanel();
                };
            }

        }

        private void lbl02001005EventsAndProperties(bool Properties, bool Events = false) // ملصق موقع السيرفر 
        {

            // الخصائص
            if (Properties == true && Events == false)
            {
                lbl02001005.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02001005.Text = Cultures.ReturnTranslation("موقع السيرفر");

            }
            else if (Properties == true && Events == true)
            {
                lbl02001005.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02001005.Text = Cultures.ReturnTranslation("موقع السيرفر");

            }
        }

        private void cmb02001006EventsAndProperties(bool Properties, bool Events = false) // قائمة موقع السيرفر
        {

            if (Properties == true && Events == false)
            {
                cmb02001006.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_1);
                cmb02001006.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_1);
            }
            else if (Properties == true && Events == true)
            {
                cmb02001006.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_1);
                cmb02001006.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_1);

                cmb02001006.SelectedIndexChanged += delegate
                {
                    OpenAndClosePanel();
                };
            }

        }

        private void pnl02002EventsAndProperties(bool Properties, bool Events = false) // الحاوية الثانية
        {

            if (Properties == true && Events == false)
            {
                pnl02002.BackColor = DisplayMode.ReturnColor(myElementType.Panel, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true && Events == true)
            {
                pnl02002.BackColor = DisplayMode.ReturnColor(myElementType.Panel, ColorPropertyName.BackColor_2);


            }
        }

        private void lbl02002001EventsAndProperties(bool Properties, bool Events = false) // ملصق اسم السيرفر المحلي 
        {

            // الخصائص
            if (Properties == true && Events == false)
            {
                lbl02002001.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02002001.Text = Cultures.ReturnTranslation("إسم السيرفر المحلي");
            }
            else if (Properties == true && Events == true)
            {
                lbl02002001.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02002001.Text = Cultures.ReturnTranslation("إسم السيرفر المحلي");


            }
        }

        private void cmb02002002EventsAndProperties(bool Properties, bool Events = false) // قائمة اسماء السيرفرات المحلية
        {

            if (Properties == true && Events == false)
            {
                cmb02002002.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_1);
                cmb02002002.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_1);
            }
            else if (Properties == true && Events == true)
            {
                cmb02002002.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_1);
                cmb02002002.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_1);

                cmb02002002.SelectedIndexChanged += delegate
                {
                    OpenAndClosePanel();
                };
            }

        }

        private void lbl02002003EventsAndProperties(bool Properties, bool Events = false) // ملصق نوع المصادقة  
        {

            if (Properties == true && Events == false)
            {
                lbl02002003.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02002003.Text = Cultures.ReturnTranslation("نوع المصادقة");

            }
            else if (Properties == true && Events == true)
            {
                lbl02002003.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02002003.Text = Cultures.ReturnTranslation("نوع المصادقة");


            }
        }

        private void cmb02002004EventsAndProperties(bool Properties, bool Events = false) // قائمة انواع المصادقة

        {

            // الخصائص
            if (Properties == true && Events == false)
            {
                cmb02002004.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_1);
                cmb02002004.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_1);
            }
            else if (Properties == true && Events == true)
            {
                cmb02002004.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_1);
                cmb02002004.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_1);


                cmb02002004.SelectedIndexChanged += delegate
                {
                    OpenAndClosePanel();
                };
            }

        }

        private void pnl02003EventsAndProperties(bool Properties, bool Events = false) // الحاوية الثالثة
        {

            if (Properties == true && Events == false)
            {
                pnl02003.BackColor = DisplayMode.ReturnColor(myElementType.Panel, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true && Events == true)
            {
                pnl02003.BackColor = DisplayMode.ReturnColor(myElementType.Panel, ColorPropertyName.BackColor_2);
            }
        }

        private void lbl02003001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم الآي بي  
        {

            if (Properties == true && Events == false)
            {
                lbl02003001.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02003001.Text = Cultures.ReturnTranslation("رقم الآي بي");
            }
            else if (Properties == true && Events == true)
            {
                lbl02003001.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02003001.Text = Cultures.ReturnTranslation("رقم الآي بي");


            }
        }

        private void txt02003002EventsAndProperties(bool Properties, bool Events = false) // صندوق نص رقم الآي بي
        {

            if (Properties == true && Events == false)
            {
                txt02003002.BackColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.BackColor_1);
                txt02003002.ForeColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.ForeColor_1);
            }
            else if (Properties == true && Events == true)
            {
                txt02003002.BackColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.BackColor_1);
                txt02003002.ForeColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.ForeColor_1);


            }

        }

        private void pnl02004EventsAndProperties(bool Properties, bool Events = false) // الحاوية الرابعة
        {

            if (Properties == true && Events == false)
            {

                pnl02004.BackColor = DisplayMode.ReturnColor(myElementType.Panel, ColorPropertyName.BackColor_2);

            }
            else if (Properties == true && Events == true)
            {
                pnl02004.BackColor = DisplayMode.ReturnColor(myElementType.Panel, ColorPropertyName.BackColor_2);


            }
        }

        private void lbl02004001EventsAndProperties(bool Properties, bool Events = false) // ملصق اسم المستخدم  
        {

            if (Properties == true && Events == false)
            {
                lbl02004001.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02004001.Text = Cultures.ReturnTranslation("إسم المستخدم");
            }
            else if (Properties == true && Events == true)
            {
                lbl02004001.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02004001.Text = Cultures.ReturnTranslation("إسم المستخدم");


            }
        }

        private void txt02004002EventsAndProperties(bool Properties, bool Events = false) // صندوق نص اسم المستخدم
        {

            if (Properties == true && Events == false)
            {
                txt02004002.BackColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.BackColor_1);
                txt02004002.ForeColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.ForeColor_1);
            }
            else if (Properties == true && Events == true)
            {
                txt02004002.BackColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.BackColor_1);
                txt02004002.ForeColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.ForeColor_1);
            }

        }

        private void lbl02004003EventsAndProperties(bool Properties, bool Events = false) // ملصق كلمة المرور  
        {

            if (Properties == true && Events == false)
            {
                lbl02004003.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02004003.Text = Cultures.ReturnTranslation("كلمة المرور");
            }
            else if (Properties == true && Events == true)
            {
                lbl02004003.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02004003.Text = Cultures.ReturnTranslation("كلمة المرور");


            }
        }

        private void txt02004004EventsAndProperties(bool Properties, bool Events = false) // صندوق كلمة المرور
        {

            if (Properties == true && Events == false)
            {
                txt02004004.BackColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.BackColor_1);
                txt02004004.ForeColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.ForeColor_1);
            }
            else if (Properties == true && Events == true)
            {
                txt02004004.BackColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.BackColor_1);
                txt02004004.ForeColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.ForeColor_1);


            }

        }

        private void pnl02005EventsAndProperties(bool Properties, bool Events = false) // الحاوية الخامسة
        {

            if (Properties == true && Events == false)
            {
                pnl02005.BackColor = DisplayMode.ReturnColor(myElementType.Panel, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true && Events == true)
            {
                pnl02005.BackColor = DisplayMode.ReturnColor(myElementType.Panel, ColorPropertyName.BackColor_2);


            }
        }

        private void lbl02005001EventsAndProperties(bool Properties, bool Events = false) // ملصق نص الاتصال  
        {

            if (Properties == true && Events == false)
            {
                lbl02005001.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02005001.Text = Cultures.ReturnTranslation("نص الإتصال");
            }
            else if (Properties == true && Events == true)
            {
                lbl02005001.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
                lbl02005001.Text = Cultures.ReturnTranslation("نص الإتصال");


            }
        }

        private void txt02005002EventsAndProperties(bool Properties, bool Events = false) // صندوق  نص الاتصال
        {

            if (Properties == true && Events == false)
            {
                txt02005002.BackColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.BackColor_1);
                txt02005002.ForeColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.ForeColor_1);

            }
            else if (Properties == true && Events == true)
            {
                txt02005002.BackColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.BackColor_1);
                txt02005002.ForeColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.ForeColor_1);


            }

        }

        private void pnl02006EventsAndProperties(bool Properties, bool Events = false) // الحاوية السادسة
        {

            if (Properties == true && Events == false)
            {
                pnl02006.BackColor = DisplayMode.ReturnColor(myElementType.Panel, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true && Events == true)
            {
                pnl02006.BackColor = DisplayMode.ReturnColor(myElementType.Panel, ColorPropertyName.BackColor_2);


            }
        }

        private void btn02006001EventsAndProperties(bool Properties, bool Events = false) // زر فحص الاتصال وتغيير اعداداته
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn02006001.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgSaveBlue);
                    }
                    else
                    {
                        btn02006001.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgSaveDark);
                    }
                    btn02006001.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmConnectionSettings02 >>  btn02006001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn02006001.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgSaveBlue);
                    }
                    else
                    {
                        btn02006001.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgSaveDark);
                    }
                    btn02006001.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmConnectionSettings02 >>  btn02006001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


                Image imgEditConnetion = null;
                btn02006001.MouseMove += delegate
                {
                    try
                    {
                        if (imgEditConnetion == null)
                        {
                            imgEditConnetion = btn02006001.Image;
                            btn02006001.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgSaveOther);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmConnectionSettings02 >>  btn02006001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
                btn02006001.MouseLeave += delegate
                {
                    try
                    {
                        btn02006001.Image = imgEditConnetion;
                        imgEditConnetion = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmConnectionSettings02 >>  btn02006001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn02006001.Click += delegate
                {

                    if (Permissions.AccountHavePermission(PermissionObjectes.DataBases_Connections , PermissionType.Add) || Permissions.AccountHavePermission(PermissionObjectes.DataBases_Connections , PermissionType.Edit))
                    {

                        string connectionStringName = "Con" + cmb02001002.Text;
                        string connectionString = "";

                        if (cmb02001004.Text == "SQL Server")
                        {
                            if (cmb02001006.Text == "Local Server")
                            {
                                if (cmb02002004.Text == "Windows Authentication")
                                {
                                    connectionString = string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True", cmb02002002.Text, cmb02001002.Text);
                                }
                                else
                                {
                                    connectionString = string.Format(@"Data Source = {0} ; Initial Catalog = {1} ; User ID = {2} ; Password = {3} ", txt02003002.Text, cmb02001002.Text, txt02004002.Text, txt02004004.Text);
                                }
                            }
                            else
                            {
                                connectionString = string.Format(@"Data Source = {0} ; Initial Catalog = {1} ; User ID = {2} ; Password = {3} ", txt02003002.Text, cmb02001002.Text, txt02004002.Text, txt02004004.Text);
                            }
                        }
                        else
                        {
                            connectionString = txt02005002.Text;
                        }

                        // اختبار الاتصال وتخزين نص الاتصال
                        try
                        {
                            if (cmb02001004.Text == "SQL Server")
                            {
                                SqlConnection con = new SqlConnection(connectionString);
                                con.Open();
                                if (con.State == ConnectionState.Open)
                                {
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("نجاح الإتصال هل تريد الحفظ"), MessageBoxStatus.YesAndNo);
                                    if (GeneralVariables.MessageBoxResult == "Yes")
                                    {
                                        List<string> ls = DataTools.FoldersAndFiles.ReadTextFileWitheLinesIndex(AppDomain.CurrentDomain.BaseDirectory + "\\" + "ConnectionStrings.txt");// قراءة الملف
                                        File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\" + "ConnectionStrings.txt");// حذف الملف
                                        List<string> connectionTextFile = new List<string>();
                                        bool add = true;

                                        if (!(ls is null))
                                        {
                                            foreach (string line in ls)
                                            {
                                                string subLine = SecurityTools.incryption.Decrypt(line);
                                                if (subLine.Trim() != "")
                                                {
                                                    string[] sub2Line = subLine.Split('&');
                                                    if (sub2Line[0] == connectionStringName)
                                                    {
                                                        connectionTextFile.Add(SecurityTools.incryption.Encrypt(connectionStringName + "&" + connectionString));
                                                        add = false;
                                                    }
                                                    else
                                                    {
                                                        connectionTextFile.Add(line);
                                                    }

                                                }
                                            }
                                        }
                                        if (add)
                                        {
                                            connectionTextFile.Add(SecurityTools.incryption.Encrypt(connectionStringName + "&" + connectionString));
                                        }
                                        string[] array = new string[connectionTextFile.Count];
                                        for (int rowNo = 0; rowNo < connectionTextFile.Count; rowNo++)
                                        {
                                            array[rowNo] = connectionTextFile[rowNo].ToString();
                                        }
                                        DataTools.FoldersAndFiles.CreateOrOpenTextFileAndWriteLinse(AppDomain.CurrentDomain.BaseDirectory + "\\" + "ConnectionStrings.txt", array);
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("تم الحفظ بنجاح") , MessageBoxStatus.Ok);
                                    }
                                }
                            }
                            else if (cmb02001004.Text == "SQLite")
                            {
                                SQLiteConnection con = new SQLiteConnection(connectionString);
                                con.Open();
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("نجاح الإتصال هل تريد الحفظ") , MessageBoxStatus.YesAndNo);
                                if (GeneralVariables.MessageBoxResult == "Yes")
                                {
                                    List<string> ls = DataTools.FoldersAndFiles.ReadTextFileWitheLinesIndex(AppDomain.CurrentDomain.BaseDirectory + "\\" + "ConnectionStrings.txt");// قراءة الملف
                                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\" + "ConnectionStrings.txt");// حذف الملف
                                    List<string> connectionTextFile = new List<string>();
                                    bool add = true;

                                    if (!(ls is null))
                                    {
                                        foreach (string line in ls)
                                        {
                                            string subLine = SecurityTools.incryption.Decrypt(line);
                                            if (subLine.Trim() != "")
                                            {
                                                string[] sub2Line = subLine.Split('&');
                                                if (sub2Line[0] == connectionStringName)
                                                {
                                                    connectionTextFile.Add(SecurityTools.incryption.Encrypt(connectionStringName + "&" + connectionString));
                                                    add = false;
                                                }
                                                else
                                                {
                                                    connectionTextFile.Add(line);
                                                }

                                            }
                                        }
                                    }
                                    if (add)
                                    {
                                        connectionTextFile.Add(SecurityTools.incryption.Encrypt(connectionStringName + "&" + connectionString));
                                    }
                                    string[] array = new string[connectionTextFile.Count];
                                    for (int rowNo = 0; rowNo < connectionTextFile.Count; rowNo++)
                                    {
                                        array[rowNo] = connectionTextFile[rowNo].ToString();
                                    }
                                    DataTools.FoldersAndFiles.CreateOrOpenTextFileAndWriteLinse(AppDomain.CurrentDomain.BaseDirectory + "\\" + "ConnectionStrings.txt", array);
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("تم الحفظ بنجاح") , MessageBoxStatus.Ok);
                                }
                                else
                                {
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("تم الحفظ بنجاح") , MessageBoxStatus.Ok);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            GeneralAction.AddNewNotification("Mesrakh  >> frmConnectionSettings02  >>  btn02006001EventsAndProperties ", DateTime.Now, " مشكلة عند فحص الاتصال وتغيير اعداداته  ", ex.Message);

                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("فشل الإتصال"), MessageBoxStatus.Ok);
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


        //-----------------------------------------------------------------------------------------------------------------------

        // فتح واغلاق الحاويات
        private void OpenAndClosePanel()
        {
            try
            {
                if (cmb02001004.Text == "SQL Server" && cmb02001006.Text == "Local Server")
                {
                    pnl02002.Visible = true;
                    cmb02002002.Enabled = true;
                    cmb02001006.Enabled = true;
                    cmb02002004.Enabled = true;

                    if (cmb02002004.Text == "Windows Authentication")
                    {
                        pnl02003.Visible = false;
                        pnl02004.Visible = false;
                        pnl02005.Visible = false;

                    }
                    else
                    {
                        pnl02003.Visible = false;
                        pnl02004.Visible = true;
                        pnl02005.Visible = false;
                    }
                }
                else if (cmb02001004.Text == "SQL Server" && cmb02001006.Text == "Remote Server")
                {
                    pnl02002.Visible = true;
                    cmb02002002.Enabled = false;
                    cmb02002004.SelectedIndex = 1;
                    cmb02002004.Enabled = false;
                    cmb02001006.Enabled = true;

                    if (cmb02002004.Text == "SQL Server Authentication")
                    {
                        pnl02003.Visible = true;
                        pnl02004.Visible = true;
                        pnl02005.Visible = false;

                    }
                    else
                    {
                        pnl02003.Visible = false;
                        pnl02004.Visible = false;
                        pnl02005.Visible = false;
                    }
                }
                else
                {
                    cmb02001006.Enabled = false;
                    pnl02002.Visible = false;
                    pnl02003.Visible = false;
                    pnl02004.Visible = false;
                    pnl02005.Visible = true;
                }

            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmConnectionSettings02 >>  OpenAndClosePanel ", DateTime.Now, ex.Message, ex.Message);
            }

        }

    }
}
