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
    public partial class frmClients19 : Form
    {
        public frmClients19()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmEventsAndProperties(Properties, Events); // النموذج
            pnl001EventsAndProperties(Properties, Events);// الحاوية الرئيسية
            pnl001001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl001001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl001002EventsAndProperties(Properties, Events); // الحاوية الثانية


            lbl001002001EventsAndProperties(Properties, Events); //  ملصق رقم العميل
            txt001002001EventsAndProperties(Properties, Events); // مربع نص رقم العميل
            lbl001002002EventsAndProperties(Properties, Events); // ملصق إسم العميل عربي 
            txt001002002EventsAndProperties(Properties, Events); // مربع نص إسم العميل عربي
            lbl001002003EventsAndProperties(Properties, Events); // ملصق إسم العميل إنجليزي 
            txt001002003EventsAndProperties(Properties, Events); // مربع نص إسم العميل إنجليزي
            lbl001002004EventsAndProperties(Properties, Events); //نوع المورد 
            cbCustomerEventsAndProperties(Properties, Events); // مربع اختيار زبون  
            cbSupplierEventsAndProperties(Properties, Events); // مربع اختيار مورد  
            lbl001002005EventsAndProperties(Properties, Events); // ملصق الرقم الضريبي 
            txt001002004EventsAndProperties(Properties, Events); // مربع نص الرقم الضريبي
            lbl001002006EventsAndProperties(Properties, Events); // ملصق تفاصيل أخرى 
            txt001002005EventsAndProperties(Properties, Events); // مربع نص تفاصيل أخرى
            lbl001002007EventsAndProperties(Properties, Events); // ملصق الفائدة على رأس المال 
            txt001002006EventsAndProperties(Properties, Events); // مربع نص الفائدة على رأس المال
            lbl001002008EventsAndProperties(Properties, Events); // ملصق نسبة الشريك من الأرباح 
            txt001002007EventsAndProperties(Properties, Events); // مربع نص إسم ملصق نسبة الشريك من الأرباح 
            lbl001002009EventsAndProperties(Properties, Events); // ملصق العنوان الوطني 
            txt001002008EventsAndProperties(Properties, Events); // مربع نص العنوان الوطني 

            btn001002001EventsAndProperties(Properties, Events); // جديد
            btn001002002EventsAndProperties(Properties, Events); // حفظ
            btn001002003EventsAndProperties(Properties, Events); // تعديل
            btn001002004EventsAndProperties(Properties, Events); // حذف

            dgv001EventsAndProperties(Properties, Events); // جدول عرض بيانات الفروع
            //-------- البحث
            lblSearchEventsAndProperties(Properties, Events);// ملصق البحث عن
            txtSearchEventsAndProperties(Properties, Events);// مربع نص البحث عن
            //------ حقول التواصل
            lblConnectionTitelEventsAndProperties(Properties, Events); //  عنوان حقول طرق التواصل
            lblConnectionTypeEventsAndProperties(Properties, Events);
            cbxConnectionMethodsTypesEventsAndProperties(Properties, Events); //  قائمة منسدلة بأنواع طرق التواصل
            lblConnectionNoEventsAndProperties(Properties, Events);
            txtConnectionNoEventsAndProperties(Properties, Events); //  مربع نص لرقم طريقة التواصل
            lblConnectionDetailsEventsAndProperties(Properties, Events);
            txtOtherDetailsEventsAndProperties(Properties, Events); //  مربع نص تفاصيل اخرى
            btnAddConnectionNumberEventsAndProperties(Properties, Events); // زر اضافة طريقة اتصال
            btnDeleteConnectionNumberEventsAndProperties(Properties, Events); //  زر حذف طريقة اتصال
            dgvAllConnectionsNumbersEventsAndProperties(Properties, Events); // جدول عرض بيانات التواصل



        }

        private void frmEventsAndProperties(bool Properties, bool Events = false) // النموذج 
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

        private void pnl001EventsAndProperties(bool Properties, bool Events = false) // الحاوية الرئيسية
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl001);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl001, ColorPropertyName.BackColor_3, true, true);
            }
        }

        private void pnl001001EventsAndProperties(bool Properties, bool Events = false) // الحاوية العلوية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl001001, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl001001, ColorPropertyName.BackColor_2, true, true);
            }
        }

        private void lbl001001001EventsAndProperties(bool Properties, bool Events = false) // ملصق عنوان النموذج 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001001001, "العملاء", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001001001, "العملاء", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void pnl001002EventsAndProperties(bool Properties, bool Events = false) // الحاوية الثانية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl001002);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl001002, ColorPropertyName.BackColor_3, true, true);
            }
        }


        private void lbl001002001EventsAndProperties(bool Properties, bool Events = false) //  ملصق رقم العميل
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002001, "رقم العميل", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002001, "رقم العميل", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم العميل
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002001,"",10);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002001, "",10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }



     
        private void lbl001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم العميل عربي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002002, "إسم العميل عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002002, "إسم العميل عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

            }
        }

        private void txt001002002EventsAndProperties(bool Properties = true, bool Events = false) // مربع نص إسم العميل عربي
        {
            string cultureInfo = "ar-sa";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002002, cultureInfo,100);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002002, cultureInfo,100, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt001002002.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002003.Select(); };

                };
            }
        }
        private void lbl001002003EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم العميل إنجليزي 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002003, "إسم العميل إنجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002003, "إسم العميل إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم العميل إنجليزي
        {
            string cultureInfo = "en-us";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002003, cultureInfo,100);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002003, cultureInfo,100, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt001002003.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { cbCustomer.Select(); };
                };
            }
        }


        private void lbl001002004EventsAndProperties(bool Properties, bool Events = false) //نوع المورد 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002004, "نوع العميل", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002004, "نوع العميل", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);


            }
        }

        private void cbCustomerEventsAndProperties(bool Properties, bool Events = false) // مربع اختيار زبون  
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.CheckBox_.CustumProperties(cbCustomer,Cultures.ReturnTranslation("زبون"));
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.CheckBox_.CustumProperties(cbCustomer, Cultures.ReturnTranslation("زبون"), ColorPropertyName.ForeColor_1,true,true);
                cbCustomer.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { cbSupplier.Select(); };
                };
            }
        }


        private void cbSupplierEventsAndProperties(bool Properties, bool Events = false) // مربع اختيار مورد  
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.CheckBox_.CustumProperties(cbSupplier, Cultures.ReturnTranslation("مورد"));
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.CheckBox_.CustumProperties(cbSupplier, Cultures.ReturnTranslation("مورد"), ColorPropertyName.ForeColor_1, true, true);
                cbSupplier.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002004.Select(); };
                };
            }
        }

        private void lbl001002005EventsAndProperties(bool Properties, bool Events = false) // ملصق الرقم الضريبي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002005, "الرقم الضريبي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002005, "الرقم الضريبي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002004EventsAndProperties(bool Properties, bool Events = false) // مربع نص الرقم الضريبي
        {
            string cultureInfo = "en-us";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002004, cultureInfo,50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002004, cultureInfo,50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt001002004.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002005.Select(); };
                };
            }
        }


        private void lbl001002006EventsAndProperties(bool Properties, bool Events = false) // ملصق تفاصيل أخرى 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002006, "تفاصيل أخرى", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002006, "تفاصيل أخرى", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002005EventsAndProperties(bool Properties, bool Events = false) // مربع نص تفاصيل أخرى
        {
            string cultureInfo = "";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002005, cultureInfo,200);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002005, cultureInfo,200, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt001002005.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002006.Select(); };
                };
            }
        }

        private void lbl001002007EventsAndProperties(bool Properties, bool Events = false) // ملصق الفائدة على رأس المال 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002007, "الفائدة على رأس المال", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002007, "الفائدة على رأس المال", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002006EventsAndProperties(bool Properties, bool Events = false) // مربع نص الفائدة على رأس المال
        {
            string cultureInfo = "en-us";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002006, cultureInfo,8, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002006, cultureInfo,8, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Decimal);

                txt001002006.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002007.Select(); };
                };
            }
        }

        private void lbl001002008EventsAndProperties(bool Properties, bool Events = false) // ملصق نسبة الشريك من الأرباح 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002008, "نسبة الشريك من الأرباح", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002008, "نسبة الشريك من الأرباح", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002007EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم ملصق نسبة الشريك من الأرباح 
        {
            string cultureInfo = "";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002007, cultureInfo,8, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002007, cultureInfo,8, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true,TextBoxType.Decimal);

                txt001002007.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002008.Select(); };
                };
            }
        }

        private void lbl001002009EventsAndProperties(bool Properties, bool Events = false) // ملصق العنوان الوطني 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002009, "العنوان الوطني", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002009, "العنوان الوطني", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002008EventsAndProperties(bool Properties, bool Events = false) // مربع نص العنوان الوطني 
        {
            string cultureInfo = "";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002008, cultureInfo,200, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002008, cultureInfo,200, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt001002008.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btn001002002.PerformClick(); };
                };
            }
        }

        private void btn001002001EventsAndProperties(bool Properties, bool Events = false) // جديد 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001002001, "جديد");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn001002001, "جديد", ColorPropertyName.ForeColor_1, true, true);

                btn001002001.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Clients, PermissionType.Add))
                        {

                            if (btn001002001.Text == Cultures.ReturnTranslation("جديد"))
                            {
                                btn001002001.Text = Cultures.ReturnTranslation("إلغاء");

                                txt001002001.Enabled = false;
                                txt001002002.Enabled = true;
                                txt001002003.Enabled = true;
                                txt001002004.Enabled = true;
                                txt001002005.Enabled = true;
                                txt001002006.Enabled = true;
                                txt001002007.Enabled = true;
                                txt001002008.Enabled = true;
                                cbCustomer.Enabled = true;
                                cbSupplier.Enabled = true;

                                txt001002001.Text = "";
                                txt001002002.Text = "";
                                txt001002003.Text = "";
                                txt001002004.Text = "";
                                txt001002005.Text = "";
                                txt001002006.Text = "";
                                txt001002007.Text = "";
                                txt001002008.Text = "";
                                cbCustomer.Checked = false;
                                cbSupplier.Checked = false;

                                txt001002002.Focus();

                                btn001002002.Enabled = true;
                                btn001002003.Enabled = false;
                                btn001002004.Enabled = false;

                                dgv001.Enabled = false;
                            }
                            else
                            {
                                btn001002001.Text = Cultures.ReturnTranslation("جديد");


                                txt001002001.Enabled = false;
                                txt001002002.Enabled = false;
                                txt001002003.Enabled = false;
                                txt001002004.Enabled = false;
                                txt001002005.Enabled = false;
                                txt001002006.Enabled = false;
                                txt001002007.Enabled = false;
                                txt001002008.Enabled = false;
                                cbCustomer.Enabled = false;
                                cbSupplier.Enabled = false;


                                btn001002002.Enabled = false;
                                btn001002003.Enabled = true;
                                btn001002004.Enabled = true;

                                dgv001.Enabled = true;
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmClients19 >> btn001002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmClients19 >> btn001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

            }

        }

        private void btn001002002EventsAndProperties(bool Properties, bool Events = false) // حفظ 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001002002, "حفظ");
            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn001002002, "حفظ", ColorPropertyName.ForeColor_1, true, true);

                btn001002002.Click += delegate
                {
                    try
                    {

                        if (txt001002001.Text.Trim() == "")
                        {
                            string Error = "";

                            if (txt001002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم العميل عربي");
                                txt001002002.Focus();
                            }

                            else if (txt001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم العميل إنجليزي");
                                txt001002003.Focus();
                            }
                            else if (cbCustomer.Checked == false && cbSupplier.Checked == false)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتحديد نوع العميل");
                                cbCustomer.Focus();
                            }

                            else
                            {
                                bool? SameClientNameAR = ElementsTools.DataGridView_.findValueThenSelected(dgv001, ActionType.add, txt001002002.Text.Replace("'", ""), 1);
                                bool? SameClientNameEN = ElementsTools.DataGridView_.findValueThenSelected(dgv001, ActionType.add, txt001002003.Text.Replace("'", ""), 2);
                               
                                if (SameClientNameAR == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد عميل بنفس الإسم العربي");
                                    txt001002002.Focus();

                                }
                                else
                                {
                                    if (SameClientNameEN == true)
                                    {
                                        Error = Cultures.ReturnTranslation("يوجد عميل بنفس الإسم الإنجليزي");
                                        txt001002003.Focus();
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string[] result = null;
                                object ConnectingMethodsOfCommunicationNO = DataTools.DataBases.Run(ref result, "SpAddNewTblConnectingMethodsOfCommunication", CommandType.StoredProcedure, new object[][] { new object[] { "@OtherDetails", "Add New TblEnterpriseBranches  >> " + DateTime.Now }, new object[] { "@ConnectingMethodsOfCommunicationNO", "OUT" } });

                                string[] result00 = null;
                                DataTools.DataBases.Run(ref result00, "insert into TblClients values " +
                                    "(@ClientNameAR,@ClientNameEN,@Customer,@Supplier,@TaxNo,@OtherDetails,@InterestOnCapital,@PartnersShareOfProfits,@ConnectingMethodsOfCommunicationNO,@NationalAddress)", CommandType.Text, new object[][] { 
                                    new object[] { "@ClientNameAR", txt001002002.Text }, 
                                    new object[] { "@ClientNameEN", txt001002003.Text },
                                    new object[] { "@Customer", cbCustomer.Checked },
                                    new object[] { "@Supplier", cbSupplier.Checked },
                                    new object[] { "@TaxNo", txt001002004.Text },
                                    new object[] { "@OtherDetails", txt001002005.Text },
                                    new object[] { "@InterestOnCapital", txt001002006.Text },
                                    new object[] { "@PartnersShareOfProfits", txt001002007.Text},
                                    new object[] { "@ConnectingMethodsOfCommunicationNO", ConnectingMethodsOfCommunicationNO},
                                    new object[] { "@NationalAddress", txt001002008.Text} 
                                    });


                               if(result00[1] == "succeeded")
                                {

                                    txt001002001.Enabled = false;
                                    txt001002002.Enabled = false;
                                    txt001002003.Enabled = false;
                                    txt001002004.Enabled = false;
                                    txt001002005.Enabled = false;
                                    txt001002006.Enabled = false;
                                    txt001002007.Enabled = false;
                                    txt001002008.Enabled = false;
                                    cbCustomer.Enabled = false;
                                    cbSupplier.Enabled = false;

                                    txt001002001.Text = "";
                                    txt001002002.Text = "";
                                    txt001002003.Text = "";
                                    txt001002004.Text = "";
                                    txt001002005.Text = "";
                                    txt001002006.Text = "";
                                    txt001002007.Text = "";
                                    txt001002008.Text = "";
                                    cbCustomer.Checked = false;
                                    cbSupplier.Checked = false;


                                    btn001002001.Enabled = true;
                                    btn001002002.Enabled = false;
                                    btn001002003.Enabled = true;
                                    btn001002004.Enabled = true;

                                    dgv001.Enabled = true;

                                    // تحديث بيانات جدول البيانات
                                    fillTblClients(); // تعبئة جدول العملاء
                                    AllEventsAndProperties(true); // تم تحديث جميع الخصائص لتعود الازرار لوضعها الطبيعي

                                    //// تحديث بيانات جدول المنتجات 
                                    //if (GeneralVariables._frmProductsAndServices09 != null) GeneralVariables._frmProductsAndServices09 = null;
                                }



                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);

                                txt001002001.Text = "";
                            }
                            btn001002001.Select();
                        }
                        else
                        {

                            string Error = "";

                            if (txt001002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم العميل عربي");
                                txt001002002.Focus();
                            }

                            else if (txt001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم العميل إنجليزي");
                                txt001002003.Focus();
                            }
                            else if (cbCustomer.Checked == false && cbSupplier.Checked == false)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتحديد نوع العميل");
                                cbCustomer.Focus();
                            }

                            else
                            {
                                bool? SameClientNameAR = ElementsTools.DataGridView_.findValueThenSelected(dgv001, ActionType.edit, txt001002002.Text.Replace("'", ""), 1);
                                bool? SameClientNameEN = ElementsTools.DataGridView_.findValueThenSelected(dgv001, ActionType.edit, txt001002003.Text.Replace("'", ""), 2);

                                if (SameClientNameAR == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد عميل بنفس الإسم العربي");
                                    txt001002002.Focus();

                                }
                                else
                                {
                                    if (SameClientNameEN == true)
                                    {
                                        Error = Cultures.ReturnTranslation("يوجد عميل بنفس الإسم الإنجليزي");
                                        txt001002003.Focus();
                                    }
                                }
                            }



                            if (Error == "")
                            {

                                string[] result00 = null;
                                DataTools.DataBases.Run(ref result00, "update TblClients set " +
                                    " ClientNameAR = @ClientNameAR,ClientNameEN = @ClientNameEN, Customer = @Customer,Supplier = @Supplier,TaxNo = @TaxNo,OtherDetails = @OtherDetails,InterestOnCapital = @InterestOnCapital,PartnersShareOfProfits = @PartnersShareOfProfits , NationalAddress =@NationalAddress  where ClientsNo = @ClientsNo ", CommandType.Text, new object[][] {
                                    new object[] { "@ClientNameAR", txt001002002.Text },
                                    new object[] { "@ClientNameEN", txt001002003.Text },
                                    new object[] { "@Customer", cbCustomer.Checked },
                                    new object[] { "@Supplier", cbSupplier.Checked },
                                    new object[] { "@TaxNo", txt001002004.Text },
                                    new object[] { "@OtherDetails", txt001002005.Text },
                                    new object[] { "@InterestOnCapital", txt001002006.Text },
                                    new object[] { "@PartnersShareOfProfits", txt001002007.Text},
                                    new object[] { "@NationalAddress", txt001002008.Text},
                                    new object[] { "@ClientsNo", txt001002001.Text } });

                                if (result00[1] == "succeeded")
                                {
                                    txt001002001.Enabled = false;
                                    txt001002002.Enabled = false;
                                    txt001002003.Enabled = false;
                                    txt001002004.Enabled = false;
                                    txt001002005.Enabled = false;
                                    txt001002006.Enabled = false;
                                    txt001002007.Enabled = false;
                                    txt001002008.Enabled = false;
                                    cbCustomer.Enabled = false;
                                    cbSupplier.Enabled = false;

                                    txt001002001.Text = "";
                                    txt001002002.Text = "";
                                    txt001002003.Text = "";
                                    txt001002004.Text = "";
                                    txt001002005.Text = "";
                                    txt001002006.Text = "";
                                    txt001002007.Text = "";
                                    txt001002008.Text = "";
                                    cbCustomer.Checked = false;
                                    cbSupplier.Checked = false;

                                    btn001002001.Enabled = true;
                                    btn001002002.Enabled = false;
                                    btn001002003.Enabled = true;
                                    btn001002004.Enabled = true;



                                    dgv001.Enabled = true;

                                    // تحديث بيانات جدول البيانات
                                    fillTblClients(); // تعبئة جدول العملاء
                                    AllEventsAndProperties(true);

                                    //// تحديث بيانات الشركات الصانعة بنموذج المنتجات
                                    //if (GeneralVariables._frmProductsAndServices09 != null) GeneralVariables._frmProductsAndServices09 = null;
                                }


                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);
                                dgv001.Enabled = true;
                            }
                            btn001002003.Select();
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmClients19 >> btn001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                

            }


        }


        private void btn001002003EventsAndProperties(bool Properties, bool Events = false) // تعديل 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001002003, "تعديل");

            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn001002003, "تعديل", ColorPropertyName.ForeColor_1, true, true);
                btn001002003.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Clients, PermissionType.Edit))
                    {
                        if (btn001002003.Enabled)
                        {
                            if (btn001002003.Text == Cultures.ReturnTranslation("تعديل"))
                            {
                                btn001002003.Text = Cultures.ReturnTranslation("إلغاء");

                                txt001002001.Enabled = false;
                                txt001002002.Enabled = true;
                                txt001002003.Enabled = true;
                                txt001002004.Enabled = true;
                                txt001002005.Enabled = true;
                                txt001002006.Enabled = true;
                                txt001002007.Enabled = true;
                                txt001002008.Enabled = true;
                                cbCustomer.Enabled = true;
                                cbSupplier.Enabled = true;

                                btn001002001.Enabled = false;
                                btn001002002.Enabled = true;
                                btn001002004.Enabled = false;

                                dgv001.Enabled = false;
                            }
                            else
                            {
                                btn001002003.Text = Cultures.ReturnTranslation("تعديل");

                                txt001002001.Enabled = false;
                                txt001002002.Enabled = false;
                                txt001002003.Enabled = false;
                                txt001002004.Enabled = false;
                                txt001002005.Enabled = false;
                                txt001002006.Enabled = false;
                                txt001002007.Enabled = false;
                                txt001002008.Enabled = false;
                                cbCustomer.Enabled = false;
                                cbSupplier.Enabled = false;

                                btn001002001.Enabled = true;
                                btn001002002.Enabled = false;
                                btn001002004.Enabled = true;

                                dgv001.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmClients19 >> btn001002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }

                    

                };

            }
        }
        private void btn001002004EventsAndProperties(bool Properties, bool Events = false) // حذف 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001002004, "حذف");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn001002004, "حذف", ColorPropertyName.ForeColor_1, true, true);
                btn001002004.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Clients, PermissionType.Delete))
                    {
                        try
                        {

                            string[] result = null;
                            DataTools.DataBases.Run(ref result, "delete from TblClients where ClientsNo = @ClientsNo", CommandType.Text, new object[][] { new object[] { "@ClientsNo", txt001002001.Text } });

                            if(result[1] == "succeeded")
                            {
                                txt001002001.Text = "";
                                txt001002002.Text = "";
                                txt001002003.Text = "";
                                txt001002004.Text = "";
                                txt001002005.Text = "";
                                txt001002006.Text = "";
                                txt001002007.Text = "";
                                txt001002008.Text = "";
                                cbCustomer.Checked = false;
                                cbSupplier.Checked = false;


                                txtSearch.Text = "";

                                // تحديث بيانات جدول البيانات
                                fillTblClients(); // تحديث جدول فروع المنشآت
                                dgv001EventsAndProperties(true);
                            }

                        }
                        catch (Exception ex)
                        {
                            GeneralAction.AddNewNotification("frmClients19 >> btn001002004EventsAndProperties ", DateTime.Now,ex.Message, ex.Message);
                        }


                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmClients19 >> btn001002004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }


                };
            }
        }

        int SelectedRowIndex = -1; // يستخدم في تعبئة الجدول

        private void dgv001EventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات الموظفين
        {
            if (Properties == true && Events == false)
            {
                try
                {

                        fillTblClients();

                    if (TblClients.Rows.Count > 0)
                    {

                        dgv001.DataSource = TblClients;

                        dgv001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم العميل");
                        dgv001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم العميل عربي");
                        dgv001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم العميل إنجليزي");
                        dgv001.Columns[3].Visible = false;
                        dgv001.Columns[4].Visible = false;
                        dgv001.Columns[5].Visible = false;
                        dgv001.Columns[6].Visible = false;
                        dgv001.Columns[7].Visible = false;
                        dgv001.Columns[8].Visible = false;
                        dgv001.Columns[9].Visible = false;

                        dgv001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv001.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgv001.Columns[1].Visible = true;
                            dgv001.Columns[2].Visible = false;
                        }
                        else
                        {
                            dgv001.Columns[1].Visible = false;
                            dgv001.Columns[2].Visible = true;
                        }


                        ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    else
                    {
                        if (dgv001.Rows.Count > 0) { dgv001.DataSource = null; dgv001.Rows.Clear(); };
                        ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات

                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmClients19 >> dgv001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                }
            }
            else if (Properties == true && Events == true)
            {
                try
                {

                        fillTblClients();

                    if (TblClients.Rows.Count > 0)
                    {

                        dgv001.DataSource = TblClients;
                        dgv001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم العميل");
                        dgv001.Columns[1].HeaderText = Cultures.ReturnTranslation("إسم العميل عربي");
                        dgv001.Columns[2].HeaderText = Cultures.ReturnTranslation("إسم العميل إنجليزي");
                        dgv001.Columns[3].Visible = false;
                        dgv001.Columns[4].Visible = false;
                        dgv001.Columns[5].Visible = false;
                        dgv001.Columns[6].Visible = false;
                        dgv001.Columns[7].Visible = false;
                        dgv001.Columns[8].Visible = false;
                        dgv001.Columns[9].Visible = false;

                        dgv001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv001.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgv001.Columns[1].Visible = true;
                            dgv001.Columns[2].Visible = false;
                        }
                        else
                        {
                            dgv001.Columns[1].Visible = false;
                            dgv001.Columns[2].Visible = true;
                        }


                        ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    else
                    {
                        if (dgv001.Rows.Count > 0) { dgv001.DataSource = null; dgv001.Rows.Clear(); };
                        ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات

                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmClients19 >> dgv001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                }


                dgv001.SelectionChanged += delegate
                {
                    try
                    {
                        if (dgv001.Rows.Count > 0)
                        {

                            if (dgv001.SelectedRows.Count == 0 || dgv001.SelectedRows == null) return;

                            txt001002001.Text = dgv001.SelectedRows[0].Cells[0].Value.ToString();
                            txt001002002.Text = dgv001.SelectedRows[0].Cells[1].Value.ToString();
                            txt001002003.Text = dgv001.SelectedRows[0].Cells[2].Value.ToString();
                            cbCustomer.Checked = Convert.ToBoolean(dgv001.SelectedRows[0].Cells[3].Value.ToString());
                            cbSupplier.Checked = Convert.ToBoolean(dgv001.SelectedRows[0].Cells[4].Value.ToString());
                            txt001002004.Text = dgv001.SelectedRows[0].Cells[5].Value.ToString();
                            txt001002005.Text = dgv001.SelectedRows[0].Cells[6].Value.ToString();
                            txt001002006.Text = dgv001.SelectedRows[0].Cells[7].Value.ToString();
                            txt001002007.Text = dgv001.SelectedRows[0].Cells[8].Value.ToString();
                            txt001002008.Text = dgv001.SelectedRows[0].Cells[10].Value.ToString();
                            SelectedRowIndex = dgv001.SelectedRows[0].Index;

                            txtConnectionNo.Text = "";
                            txtOtherDetails.Text = "";
                            cbxConnectionMethodsTypes.SelectedIndex = -1;

                            fillTblMethodsOfCommunication(); // تعبئة جدول طرق الاتصال حسب السجل الجديد
                            dgvAllConnectionsNumbersEventsAndProperties(true); // خصائص جدول عرض بيانات طرق الاتصال

                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmClients19 >> dgv001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                    }
                };

                dgv001.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات

                };
            }
        }


        //------------------------------ 
        DataTable TblClients = new DataTable(); // بيانات العملاء


        // بيانات العملاء
        private void fillTblClients()
        {
            try
            {
                if(TblClients is null)
                {
                    TblClients = new DataTable();
                }
                if (TblClients.Rows.Count > 0)
                {
                    TblClients.Rows.Clear();
                }

                if (TblClients.Rows.Count > 0) TblClients.Rows.Clear();

                TblClients = DataTools.DataBases.ReadTabel("select * from TblClients ");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmClients19 >> fillTblClients ", DateTime.Now, ex.Message, ex.Message);
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

        private void txtSearchEventsAndProperties(bool Properties, bool Events = false) // مربع نص البحث عن الشركات
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
                        DataView dv = new DataView(TblClients);
                        string filter = "";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            filter = "ClientNameAR like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        else
                        {
                            filter = "ClientNameEN like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        dv.RowFilter = filter;
                        dgv001.DataSource = dv;
                        ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmClients19 >> txtSearchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- طرق الاتصال الاتصال



        private void lblConnectionTitelEventsAndProperties(bool Properties, bool Events = false) // عنوان حقول طرق التواصل
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionTitel, "وسائل التواصل", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionTitel, "وسائل التواصل", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lblConnectionTypeEventsAndProperties(bool Properties, bool Events = false) // ملصق نوع طريقة الاتصال 
        {

            // الخصائص
            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionType, "طريقة الإتصال", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionType, "طريقة الإتصال", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }
        private void cbxConnectionMethodsTypesEventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة بأنواع طرق التواصل
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (tblConnectionMethodsTypes.Rows.Count > 0)
                    {
                        cbxConnectionMethodsTypes.DataSource = tblConnectionMethodsTypes;
                        cbxConnectionMethodsTypes.ValueMember = "ContactMethodsTypeNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbxConnectionMethodsTypes.DisplayMember = "ContactMethodsTypeNoNameAR";
                        }
                        else
                        {
                            cbxConnectionMethodsTypes.DisplayMember = "ContactMethodsTypeNoNameEN";
                        }
                        ElementsTools.ComboBox_.CustumProperties(cbxConnectionMethodsTypes);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmClients19 >> cbxConnectionMethodsTypesEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                filltblConnectionMethodsTypes(); // تعبئة جدول انواع طرق الاتصال

                try
                {
                    if (tblConnectionMethodsTypes.Rows.Count > 0)
                    {
                        cbxConnectionMethodsTypes.DataSource = tblConnectionMethodsTypes;
                        cbxConnectionMethodsTypes.ValueMember = "ContactMethodsTypeNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbxConnectionMethodsTypes.DisplayMember = "ContactMethodsTypeNoNameAR";
                        }
                        else
                        {
                            cbxConnectionMethodsTypes.DisplayMember = "ContactMethodsTypeNoNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbxConnectionMethodsTypes,"",true,true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmClients19 >> cbxConnectionMethodsTypesEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbxConnectionMethodsTypes.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txtConnectionNo.Select(); };
                };
            }
        }

        private void lblConnectionNoEventsAndProperties(bool Properties, bool Events = false) // ملصق رقم طريقة الاتصال 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionNo, "الرقم", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionNo, "الرقم", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txtConnectionNoEventsAndProperties(bool Properties, bool Events = false) // مربع نص لرقم طريقة التواصل
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txtConnectionNo, "en-US",100);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtConnectionNo, "en-US",100, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txtConnectionNo.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txtOtherDetails.Select(); };
                };
            }
        }

        private void lblConnectionDetailsEventsAndProperties(bool Properties, bool Events = false) // ملصق نص تفاصيل اخرى 
        {

            // الخصائص
            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionDetails, "تفاصيل أخرى", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblConnectionDetails, "تفاصيل أخرى", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txtOtherDetailsEventsAndProperties(bool Properties, bool Events = false) //  مربع نص تفاصيل اخرى
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txtOtherDetails,"",250);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtOtherDetails, "",250, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txtOtherDetails.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btnAddConnectionNumber.PerformClick(); };
                };
            }
        }

        private void btnAddConnectionNumberEventsAndProperties(bool Properties, bool Events = false) // زر اضافة طريقة اتصال
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btnAddConnectionNumber, "إضافة");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btnAddConnectionNumber, "إضافة", ColorPropertyName.ForeColor_1, true, true);

                btnAddConnectionNumber.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Manufacturers, PermissionType.Add))
                        {

                            if (btnAddConnectionNumber.Text == Cultures.ReturnTranslation("إضافة"))
                            {
                                btnAddConnectionNumber.Text = Cultures.ReturnTranslation("حفظ");
                                txtConnectionNo.Enabled = true;
                                txtOtherDetails.Enabled = true;
                                cbxConnectionMethodsTypes.Enabled = true;

                                txtConnectionNo.Text = "";
                                txtOtherDetails.Text = "";
                                cbxConnectionMethodsTypes.SelectedIndex = 0;

                                cbxConnectionMethodsTypes.Select();
                            }
                            else
                            {
                                string check = "";

                                if (txt001002001.Text.Trim() == "")
                                {
                                    check += Cultures.ReturnTranslation("رجاء قم بتحديد الموظف تريد إضافة طريقة إتصال جديدة إليه");
                                    //dgv001.Rows[0].Selected = true;
                                    btnAddConnectionNumber.Text = Cultures.ReturnTranslation("إضافة");
                                }
                                else if (cbxConnectionMethodsTypes.SelectedValue == null)
                                {
                                    check += Cultures.ReturnTranslation("رجاء قم بتحديد نوع طريقة الإتصال");
                                    cbxConnectionMethodsTypes.Focus();
                                }
                                else if (txtConnectionNo.Text.Trim() == "")
                                {
                                    check += Cultures.ReturnTranslation("رجاء قم بتسجيل رقم طريقة الإتصال الجديدة");
                                    txtConnectionNo.Focus();
                                }
                                else
                                {
                                    bool? SameConnectionNo = ElementsTools.DataGridView_.findValueThenSelected(dgvAllConnectionsNumbers, ActionType.add, txtConnectionNo.Text.Replace("'", ""), 5);

                                    if (SameConnectionNo == true)
                                    {
                                        check = Cultures.ReturnTranslation("توجد وسيلة إتصال لها نفس الرقم");
                                        txtConnectionNo.Focus();
                                    }

                                }

                                if (check == "")
                                {
                                    btnAddConnectionNumber.Text = Cultures.ReturnTranslation("إضافة");
                                    txtConnectionNo.Enabled = false;
                                    txtOtherDetails.Enabled = false;
                                    cbxConnectionMethodsTypes.Enabled = false;
                                    //----------

                                    string[] result = null;
                                    object x = DataTools.DataBases.Run(ref result, "SpAddNewCommunicationMethod", CommandType.StoredProcedure, new object[][] { new object[] { "@tableName", "TblClients" }, new object[] { "@keyRecordName", "ClientsNo" }, new object[] { "@keyRecordValue", int.Parse(txt001002001.Text) }, new object[] { "@ContactMethodsTypeNo", cbxConnectionMethodsTypes.SelectedValue }, new object[] { "@CommunicationNo", txtConnectionNo.Text }, new object[] { "@OtherDetails", txtOtherDetails.Text } });

                                    fillTblMethodsOfCommunication(); // تعبئة جدول طرق الاتصال حسب السجل الجديد
                                    dgvAllConnectionsNumbersEventsAndProperties(true);
                                    btnAddConnectionNumber.Focus();
                                }
                                else
                                {
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), check, MessageBoxStatus.Ok);

                                }
                                
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmClients19 >> btnAddConnectionNumberEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmClients19 >> btnAddConnectionNumberEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }



                };
            }
        }


        private void btnDeleteConnectionNumberEventsAndProperties(bool Properties, bool Events = false) // زر حذف طريقة اتصال
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btnDeleteConnectionNumber, "حذف");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btnDeleteConnectionNumber, "حذف", ColorPropertyName.ForeColor_1, true, true);

                btnDeleteConnectionNumber.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Manufacturers, PermissionType.Delete))
                        {
                            int xxx = 0;
                            if (dgvAllConnectionsNumbers.Rows.Count > 0) 
                            { 
                                if(dgvAllConnectionsNumbers.SelectedRows != null)
                                {
                                    if (dgvAllConnectionsNumbers.SelectedRows.Count > 0)
                                    {
                                        xxx = int.Parse(dgvAllConnectionsNumbers.SelectedRows[0].Cells[0].Value.ToString());
                                    }
                                    else
                                    {
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء قم بالضغط على طريقة الإتصال التي تريد حذفها"), MessageBoxStatus.Ok);
                                        return;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else 
                            { 
                                return;
                            }

                            if (xxx > -1)
                            {
                                string[] result = null;
                                object r = DataTools.DataBases.Run(ref result, "delete from TblMethodsOfCommunication where MethodsOfCommunicationNo = @MethodsOfCommunicationNo", CommandType.Text, new object[][] { new object[] { "@MethodsOfCommunicationNo", xxx } });
                                fillTblMethodsOfCommunication(); // تعبئة جدول طرق الاتصال حسب السجل الجديد
                                dgvAllConnectionsNumbersEventsAndProperties(true);

                                cbxConnectionMethodsTypes.SelectedIndex = -1;
                                txtConnectionNo.Text = "";
                                txtOtherDetails.Text = "";
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmClients19 >> btnDeleteConnectionNumberEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmClients19 >> btnDeleteConnectionNumberEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                };


            }
        }

        private void dgvAllConnectionsNumbersEventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات التواصل
        {
            if (Properties == true && Events == false)
            {

                try
                {
                    if (tblCompanyConnectionMethods.Rows.Count > 0)
                    {
                        dgvAllConnectionsNumbers.DataSource = tblCompanyConnectionMethods;

                        dgvAllConnectionsNumbers.Columns[0].Visible = false;
                        dgvAllConnectionsNumbers.Columns[1].Visible = false;
                        dgvAllConnectionsNumbers.Columns[2].Visible = false;
                        dgvAllConnectionsNumbers.Columns[6].Visible = false;


                        dgvAllConnectionsNumbers.Columns[3].HeaderText = Cultures.ReturnTranslation("طريقة الإتصال");
                        dgvAllConnectionsNumbers.Columns[4].HeaderText = Cultures.ReturnTranslation("طريقة الإتصال");
                        dgvAllConnectionsNumbers.Columns[5].HeaderText = Cultures.ReturnTranslation("الرقم");


                        dgvAllConnectionsNumbers.Columns[3].Width = dgvAllConnectionsNumbers.Width / 4;
                        dgvAllConnectionsNumbers.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvAllConnectionsNumbers.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;




                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgvAllConnectionsNumbers.Columns[3].Visible = true;
                            dgvAllConnectionsNumbers.Columns[4].Visible = false;
                        }
                        else
                        {
                            dgvAllConnectionsNumbers.Columns[3].Visible = false;
                            dgvAllConnectionsNumbers.Columns[4].Visible = true;
                        }

                        ElementsTools.DataGridView_.CustumProperties(dgvAllConnectionsNumbers);
                    }
                    else
                    {
                        dgvAllConnectionsNumbers.DataSource = null;
                        dgvAllConnectionsNumbers.Rows.Clear();
                        ElementsTools.DataGridView_.CustumProperties(dgvAllConnectionsNumbers);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmClients19 >> dgvAllConnectionsNumbersEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }

            // الاحداث
            if (Properties == true && Events == true)
            {

                try
                {
                    if (tblCompanyConnectionMethods.Rows.Count > 0)
                    {
                        dgvAllConnectionsNumbers.DataSource = tblCompanyConnectionMethods;

                        dgvAllConnectionsNumbers.Columns[0].Visible = false;
                        dgvAllConnectionsNumbers.Columns[1].Visible = false;
                        dgvAllConnectionsNumbers.Columns[2].Visible = false;
                        dgvAllConnectionsNumbers.Columns[6].Visible = false;


                        dgvAllConnectionsNumbers.Columns[3].HeaderText = Cultures.ReturnTranslation("طريقة الإتصال");
                        dgvAllConnectionsNumbers.Columns[4].HeaderText = Cultures.ReturnTranslation("طريقة الإتصال");
                        dgvAllConnectionsNumbers.Columns[5].HeaderText = Cultures.ReturnTranslation("الرقم");


                        dgvAllConnectionsNumbers.Columns[3].Width = dgvAllConnectionsNumbers.Width / 4;
                        dgvAllConnectionsNumbers.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvAllConnectionsNumbers.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;




                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgvAllConnectionsNumbers.Columns[3].Visible = true;
                            dgvAllConnectionsNumbers.Columns[4].Visible = false;
                        }
                        else
                        {
                            dgvAllConnectionsNumbers.Columns[3].Visible = false;
                            dgvAllConnectionsNumbers.Columns[4].Visible = true;
                        }

                        ElementsTools.DataGridView_.CustumProperties(dgvAllConnectionsNumbers);
                    }
                    else
                    {
                        dgvAllConnectionsNumbers.DataSource = null;
                        dgvAllConnectionsNumbers.Rows.Clear();
                        ElementsTools.DataGridView_.CustumProperties(dgvAllConnectionsNumbers);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmClients19 >> dgvAllConnectionsNumbersEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                dgvAllConnectionsNumbers.SelectionChanged += delegate
                {
                    try
                    {
                        string str = "";
                        int itemIndex = 0;
                        if (cbxConnectionMethodsTypes.Items.Count > 0 && dgvAllConnectionsNumbers.Rows.Count > 0)
                        {
                            if (GeneralVariables.cultureCode == "AR")
                            {
                                if (dgvAllConnectionsNumbers.SelectedRows != null)
                                {
                                    if (dgvAllConnectionsNumbers.Rows.Count == 0 || dgvAllConnectionsNumbers.SelectedRows.Count == 0 || dgvAllConnectionsNumbers.Columns.Count == 0) return;
                                    //MessageBox.Show(dgvAllConnectionsNumbers.Rows.Count + "  //  " + dgvAllConnectionsNumbers.SelectedRows.Count + "  //  " + dgvAllConnectionsNumbers.Columns.Count);
                                    str = dgvAllConnectionsNumbers.SelectedRows[0].Cells[3].Value.ToString();


                                }
                            }
                            else
                            {
                                if (dgvAllConnectionsNumbers.SelectedRows != null)
                                {
                                    if (dgvAllConnectionsNumbers.Rows.Count == 0 || dgvAllConnectionsNumbers.SelectedRows.Count == 0 || dgvAllConnectionsNumbers.Columns.Count == 0) return;
                                    str = dgvAllConnectionsNumbers.SelectedRows[0].Cells[4].Value.ToString();

                                }
                            }

                            if (str != null || str.Trim() != "")
                            {

                                foreach (DataRowView item in cbxConnectionMethodsTypes.Items)
                                {
                                    if (GeneralVariables.cultureCode == "AR")
                                    {
                                        if (str == item[1].ToString()) { cbxConnectionMethodsTypes.SelectedIndex = itemIndex; break; }
                                    }
                                    else
                                    {
                                        if (str == item[2].ToString()) { cbxConnectionMethodsTypes.SelectedIndex = itemIndex; break; }
                                    }
                                    itemIndex++;
                                }

                            }
                            else
                            {
                                cbxConnectionMethodsTypes.SelectedIndex = 0;
                            }

                            txtConnectionNo.Text = dgvAllConnectionsNumbers.SelectedRows[0].Cells[5].Value.ToString();
                            txtOtherDetails.Text = dgvAllConnectionsNumbers.SelectedRows[0].Cells[6].Value.ToString();
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmClients19 >> dgvAllConnectionsNumbersEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                dgvAllConnectionsNumbers.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgvAllConnectionsNumbers);

                };
            }
        }


        //------------------------------ جداول البيانات
        DataTable tblConnectionMethodsTypes = new DataTable(); // جدول انواع طرق الاتصال 
        DataTable tblCompanyConnectionMethods = new DataTable(); // جدول بيانات طرق الاتصال بالشركة الصانعة المحددة




        // جدول انواع طرق الاتصال 
        private void filltblConnectionMethodsTypes()
        {
            try
            {
                if (tblConnectionMethodsTypes.Rows.Count > 0) { tblConnectionMethodsTypes.Rows.Clear(); }
                if (tblConnectionMethodsTypes.Rows.Count > 0) tblConnectionMethodsTypes.Rows.Clear();

                tblConnectionMethodsTypes = DataTools.DataBases.ReadTabel( "select * from TblContactMethodsTypes ");

                //string commandString = @"select * from TblContactMethodsTypes ";
                //SqlCommand com = new SqlCommand(commandString, ConnectionsTools.ConMesrakhMainDB());
                //tblConnectionMethodsTypes.Load(com.ExecuteReader());
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmClients19 >> filltblConnectionMethodsTypes ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        // جدول بيانات طرق الاتصال بالشركة الصانعة المحددة
        private void fillTblMethodsOfCommunication()
        {
            try
            {
                if (tblCompanyConnectionMethods.Rows.Count > 0) tblCompanyConnectionMethods.Clear();
                string commandString = @"select TblMethodsOfCommunication.MethodsOfCommunicationNo,TblMethodsOfCommunication.ConnectingMethodsOfCommunicationNO,TblMethodsOfCommunication.ContactMethodsTypeNo,TblContactMethodsTypes.ContactMethodsTypeNoNameAR , TblContactMethodsTypes.ContactMethodsTypeNoNameEN , CommunicationNo , OtherDetails from TblMethodsOfCommunication inner join TblContactMethodsTypes on TblMethodsOfCommunication.ContactMethodsTypeNo = TblContactMethodsTypes.ContactMethodsTypeNo where ConnectingMethodsOfCommunicationNO = @ConnectingMethodsOfCommunicationNO";
                SqlCommand com = new SqlCommand(commandString, ConnectionsTools.ConMesrakhMainDB());


                    if (dgv001.CurrentRow.Cells[3].Value is null)
                    {
                        fillTblClients();
                        dgv001EventsAndProperties(true);
                        dgv001.Rows[SelectedRowIndex].Selected = true; // تحديد الصف الذي كنا عليه
                    }
                    com.Parameters.AddWithValue("@ConnectingMethodsOfCommunicationNO", dgv001.CurrentRow.Cells[9].Value); // وضعت في هذا المكان لكي لا يعدود السطر الحالي فارغ



                tblCompanyConnectionMethods.Load(com.ExecuteReader());
                //MessageBox.Show(tblCompanyConnectionMethods.Rows.Count+"    <>    "+ dgv001.CurrentRow.Cells[3].Value);

            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmClients19 >> fillTblMethodsOfCommunication ", DateTime.Now, ex.Message, ex.Message);
            }
        }


    }


}

