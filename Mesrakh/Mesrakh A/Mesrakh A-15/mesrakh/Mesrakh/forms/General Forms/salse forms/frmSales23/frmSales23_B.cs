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
    public partial class frmSales23_B : Form
    {
        public frmSales23_B()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmEncapsulationUnits13EventsAndProperties(Properties, Events); // النموذج
            pnlMainEventsAndProperties(Properties, Events); // الحاوية الرئيسية
            pnl001EventsAndProperties(Properties, Events); // الحاوية العلوية
            pnl004EventsAndProperties(Properties, Events); // الحاوية العلوية الداخلية

            lbl001EventsAndProperties(Properties, Events); // ملصق رقم عربة التسوق 
            lbl002EventsAndProperties(Properties, Events); // ملصق تاريخ ووقت فتح عربة التسوق 
            pic001EventsAndProperties(Properties, Events); // زر اضافة عميل
            pic002EventsAndProperties(Properties, Events);  // زر حذف عميل
            lbl003EventsAndProperties(Properties, Events); // ملصق رقم العميل 
            lbl0033EventsAndProperties(Properties, Events); // ملصق اسم العميل 
            lbl004EventsAndProperties(Properties, Events); // ملصق مجموع سعر البيع 
            lbl0044EventsAndProperties(Properties, Events); // ملصق مجموع سعر البيع 
            lbl005EventsAndProperties(Properties, Events); // ملصق الخصم التجاري 
            lbl0055EventsAndProperties(Properties, Events); // ملصق الخصم التجاري 
            lbl006EventsAndProperties(Properties, Events); // ملصق سعر البيع بعد الخصم 
            lbl0066EventsAndProperties(Properties, Events); // ملصق سعر البيع بعد الخصم 
            lbl007EventsAndProperties(Properties, Events); // ملصق مجموع ضريبة المخرجات 
            lbl0077EventsAndProperties(Properties, Events); // ملصق مجموع ضريبة المخرجات 
            lbl008EventsAndProperties(Properties, Events); // ملصق سعر البيع شاملا الضريبة 
            lbl0088EventsAndProperties(Properties, Events); // ملصق سعر البيع شاملا الضريبة 

            pnl005EventsAndProperties(Properties, Events);  //  الحاوية خاصة بعناصر اضافة ومنتجات والتعديل عليها
            lbl009EventsAndProperties(Properties, Events);  // ملصق رقم الباركود 
            txt001EventsAndProperties(Properties, Events); //  رقم الباركود
            lbl010EventsAndProperties(Properties, Events); // ملصق إسم الصنف 
            cbx001EventsAndProperties(Properties, Events); //  قائمة منسدلة اسم الصنف
            lbl011EventsAndProperties(Properties, Events); // ملصق السعر 
            txt002EventsAndProperties(Properties, Events); //  مربع نص السعر
            lbl012EventsAndProperties(Properties, Events);  // ملصق الكمية 
            txt003EventsAndProperties(Properties, Events); //  مربع نص الكمبة
            lbl013EventsAndProperties(Properties, Events); // ملصق نسبة التخفيظ 
            txt004EventsAndProperties(Properties, Events); //   مربع نسبة التخفيظ
            lbl014EventsAndProperties(Properties, Events); // ملصق مبلغ التخفيظ
            txt005EventsAndProperties(Properties, Events); //  مربع مبلغ التخفيظ
            pic003EventsAndProperties(Properties, Events); //   زر اضافة الصنف
            pic004EventsAndProperties(Properties, Events); //  زر حذف الصنف

            pnl003EventsAndProperties(Properties, Events); // الحاوية الوسطية
            dgv001EventsAndProperties(Properties, Events); // جدول عرض تفاصيل سلة المبيعات
            pnl002EventsAndProperties(Properties, Events); // الحاوية السفلية
        }

        DateTime openFormDateTime = DateTime.Now;

        private void frmEncapsulationUnits13EventsAndProperties(bool Properties, bool Events = false) // النموذج 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Form_.CustumProperties(this);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Form_.CustumProperties(this, ColorPropertyName.BackColor_3, true, true);

                this.Load += delegate
                {
                    lbl001.Text = this.Parent.Text;
                    //lbl001.Font = new Font(lbl001.Parent.Font.Name, this.Parent.Font.Size + 10, FontStyle.Bold);
                };
            }
        }

        private void pnlMainEventsAndProperties(bool Properties, bool Events = false) // الحاوية الرئيسية
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnlMain);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnlMain, ColorPropertyName.BackColor_3, true, true);
            }
        }

        private void pnl001EventsAndProperties(bool Properties, bool Events = false) // الحاوية العلوية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl001, ColorPropertyName.BackColor_4);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl001, ColorPropertyName.BackColor_4, true, true);
            }
        }


        private void pnl004EventsAndProperties(bool Properties, bool Events = false) // الحاوية العلوية الداخلية
        {

            if (Properties == true & Events == false)
            {
                //ElementsTools.panel_.CustumProperties(pnl004, ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                //ElementsTools.panel_.CustumProperties(pnl004, ColorPropertyName.BackColor_1, true, true);
            }
        }


        private void lbl001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم عربة التسوق 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001, "", ColorPropertyName.BackColor_1);
                lbl001.Text = this.Parent.Text;
                //lbl001.Font = new Font(lbl001.Parent.Font.Name, this.Parent.Font.Size + 10,FontStyle.Bold);
                lbl001.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                
                ElementsTools.Lable_.CustumProperties(lbl001, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                //lbl001.Text = this.Parent.Text; // لانه لم يضاف داخل التاب كنترول لذلك فالاب لا يوجد ولذلك سجل هذا السطر في تحميل النموذج
                lbl001.BackColor = Color.Transparent;

            }
        }

        private void lbl002EventsAndProperties(bool Properties, bool Events = false) // ملصق تاريخ ووقت فتح عربة التسوق 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl002, "", ColorPropertyName.BackColor_1);
                lbl002.Text = openFormDateTime.ToString("yyyy-MM-dd hh:mm tt");
                lbl002.RightToLeft = RightToLeft.No;
                lbl002.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl002, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl002.Text = openFormDateTime.ToString("yyyy-MM-dd hh:mm tt");
                lbl002.RightToLeft = RightToLeft.No;
                lbl002.BackColor = Color.Transparent;
            }
        }

        private void pic001EventsAndProperties(bool Properties, bool Events = false) // زر اضافة عميل
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        pic001.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddCustomer);
                    }
                    else
                    {
                        pic001.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddCustomer);
                    }
                    pic001.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  pic001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        pic001.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddCustomer);
                    }
                    else
                    {
                        pic001.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddCustomer);
                    }
                    pic001.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  pic001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                pic001.Click += delegate
                {
                    MessageBox.Show("Test");
                };

            }
        }

        private void pic002EventsAndProperties(bool Properties, bool Events = false) // زر حذف عميل
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        pic002.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDeleteCustomer);
                    }
                    else
                    {
                        pic002.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDeleteCustomer);
                    }
                    pic002.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  pic002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        pic002.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDeleteCustomer);
                    }
                    else
                    {
                        pic002.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDeleteCustomer);
                    }
                    pic002.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  pic002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                pic002.Click += delegate
                {
                    MessageBox.Show("Test");
                };

            }
        }


        private void lbl003EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم العميل 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "", ColorPropertyName.BackColor_1);
                lbl003.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl003.BackColor = Color.Transparent;

            }
        }

        private void lbl0033EventsAndProperties(bool Properties, bool Events = false) // ملصق اسم العميل 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl0033, "", ColorPropertyName.BackColor_1);
                lbl0033.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl0033, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl0033.BackColor = Color.Transparent;

            }
        }

        private void lbl004EventsAndProperties(bool Properties, bool Events = false) // ملصق مجموع سعر البيع 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl004, "سعر البيع", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl004, "سعر البيع", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lbl0044EventsAndProperties(bool Properties, bool Events = false) // ملصق مجموع سعر البيع 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl0044, "", ColorPropertyName.BackColor_5);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl0044, "", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void lbl005EventsAndProperties(bool Properties, bool Events = false) // ملصق الخصم التجاري 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl005, "الخصم", ColorPropertyName.BackColor_5);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl005, "الخصم", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lbl0055EventsAndProperties(bool Properties, bool Events = false) // ملصق الخصم التجاري 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl0055, "", ColorPropertyName.BackColor_5);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl0055, "", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lbl006EventsAndProperties(bool Properties, bool Events = false) // ملصق سعر البيع بعد الخصم 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl006, "سعر البيع بعد الخصم", ColorPropertyName.BackColor_5);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl006, "سعر البيع بعد الخصم", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lbl0066EventsAndProperties(bool Properties, bool Events = false) // ملصق سعر البيع بعد الخصم 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl0066, "", ColorPropertyName.BackColor_5);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl0066, "", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void lbl007EventsAndProperties(bool Properties, bool Events = false) // ملصق مجموع ضريبة المخرجات 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl007, "الضريبة", ColorPropertyName.BackColor_5);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl007, "الضريبة", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lbl0077EventsAndProperties(bool Properties, bool Events = false) // ملصق مجموع ضريبة المخرجات 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl0077, "", ColorPropertyName.BackColor_5);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl0077, "", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lbl008EventsAndProperties(bool Properties, bool Events = false) // ملصق سعر البيع شاملا الضريبة 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl008, "سعر البيع شاملا الضريبة", ColorPropertyName.BackColor_5);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl008, "سعر البيع شاملا الضريبة", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void lbl0088EventsAndProperties(bool Properties, bool Events = false) // ملصق سعر البيع شاملا الضريبة 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl0088, "", ColorPropertyName.BackColor_5);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl0088, "", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void pnl005EventsAndProperties(bool Properties, bool Events = false) // الحاوية خاصة بعناصر اضافة ومنتجات والتعديل عليها
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl005, ColorPropertyName.BackColor_6);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl005, ColorPropertyName.BackColor_6, true, true);
            }
        }


        private void lbl009EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم الباركود 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl009, "رقم الباركود", ColorPropertyName.BackColor_5);
                lbl009.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl009, "رقم الباركود", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
                lbl009.BackColor = Color.Transparent;
            }
        }

        private void txt001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم الباركود
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001, "", 9);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx001.Select();
                    }
                };
            }
        }





        private void lbl010EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم الصنف 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl010, "إسم الصنف", ColorPropertyName.BackColor_5);
                lbl010.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl010, "إسم الصنف", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
                lbl010.BackColor = Color.Transparent;
            }
        }

        private void cbx001EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة اسم الصنف
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblproductAndServicesDetails is null) return;
                    if (TblproductAndServicesDetails.Rows.Count > 0)
                    {
                        cbx001.DataSource = TblproductAndServicesDetails;
                        cbx001.ValueMember = "UnitDetailsNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001.DisplayMember = "DetailedNameForProductOrServiceAr";
                        }
                        else
                        {
                            cbx001.DisplayMember = "DetailedNameForProductOrServiceEn";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> cbx001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblproductAndServicesDetails();
                    if (TblproductAndServicesDetails is null) return;
                    if (TblproductAndServicesDetails.Rows.Count > 0)
                    {
                        cbx001.DataSource = TblproductAndServicesDetails;
                        cbx001.ValueMember = "UnitDetailsNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001.DisplayMember = "DetailedNameForProductOrServiceAr";
                        }
                        else
                        {
                            cbx001.DisplayMember = "DetailedNameForProductOrServiceEn";
                        }
                    }

                    ElementsTools.ComboBox_.CustumProperties(cbx001, "", true, true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> cbx001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt002.Select();
                    }
                };

                cbx001.SelectedIndexChanged += delegate
                {
                    //WritingProductName();
                };
            }
        }

        private void lbl011EventsAndProperties(bool Properties, bool Events = false) // ملصق السعر 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl011, "السعر", ColorPropertyName.BackColor_5);
                lbl011.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl011, "السعر", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
                lbl011.BackColor = Color.Transparent;

            }
        }

        private void txt002EventsAndProperties(bool Properties, bool Events = false) // مربع نص السعر
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt002, "", 9);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt002, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt002.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt003.Select();
                    }
                };
            }
        }

        private void lbl012EventsAndProperties(bool Properties, bool Events = false) // ملصق الكمية 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl012, "الكمية", ColorPropertyName.BackColor_5);
                lbl012.BackColor = Color.Transparent;

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl012, "الكمية", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
                lbl012.BackColor = Color.Transparent;

            }
        }

        private void txt003EventsAndProperties(bool Properties, bool Events = false) // مربع نص الكمبة
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt003, "", 9);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt003, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt003.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt004.Select();
                    }
                };
            }
        }

        private void lbl013EventsAndProperties(bool Properties, bool Events = false) // ملصق نسبة التخفيظ 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl013, "نسبة التخفيظ", ColorPropertyName.BackColor_5);
                lbl013.BackColor = Color.Transparent;

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl013, "نسبة التخفيظ", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
                lbl013.BackColor = Color.Transparent;

            }
        }

        private void txt004EventsAndProperties(bool Properties, bool Events = false) // مربع نسبة التخفيظ
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt004, "", 9);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt004, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt004.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt005.Select();
                    }
                };
            }
        }

        private void lbl014EventsAndProperties(bool Properties, bool Events = false) // ملصق مبلغ التخفيظ 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl014, "مبلغ التخفيظ", ColorPropertyName.BackColor_5);
                lbl014.BackColor = Color.Transparent;

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl014, "مبلغ التخفيظ", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
                lbl014.BackColor = Color.Transparent;

            }
        }

        private void txt005EventsAndProperties(bool Properties, bool Events = false) // مربع مبلغ التخفيظ
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt005, "", 9);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt005, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt005.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        pic003.Select();
                    }
                };
            }
        }



        private void pic003EventsAndProperties(bool Properties, bool Events = false) // زر اضافة الصنف
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        pic003.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddProduct);
                    }
                    else
                    {
                        pic003.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddProduct);
                    }
                    pic003.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  pic003EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        pic003.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddProduct);
                    }
                    else
                    {
                        pic003.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddProduct);
                    }
                    pic003.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  pic003EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                pic003.Click += delegate
                {
                    MessageBox.Show("Test");
                };

            }
        }


        private void pic004EventsAndProperties(bool Properties, bool Events = false) // زر حذف الصنف
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        pic004.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDeleteProduct);
                    }
                    else
                    {
                        pic004.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDeleteProduct);
                    }
                    pic004.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  pic004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        pic004.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDeleteProduct);
                    }
                    else
                    {
                        pic004.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDeleteProduct);
                    }
                    pic004.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  pic004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                pic004.Click += delegate
                {
                    MessageBox.Show("Test");
                };

            }
        }


        private void pnl003EventsAndProperties(bool Properties, bool Events = false) // الحاوية الوسطية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl003, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl003, ColorPropertyName.BackColor_2, true, true);
            }
        }

        int SelectedRowIndex = -1; // يستخدم في تعبئة الجدول
        private void dgv001EventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات فروع الشركات
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblSalesCartDetails is null)
                    {
                        fillTblSalesCartDetails();
                    }

                    if (TblSalesCartDetails != null)
                    {
                        if (TblSalesCartDetails.Rows.Count > 0)
                        {

                            dgv001.DataSource = TblSalesCartDetails;

                            dgv001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الفرع");
                            dgv001.Columns[1].Visible = false;
                            dgv001.Columns[2].Visible = false;
                            dgv001.Columns[3].HeaderText = Cultures.ReturnTranslation("إسم الفرع عربي");
                            dgv001.Columns[4].HeaderText = Cultures.ReturnTranslation("إسم الفرع إنجليزي");
                            dgv001.Columns[5].Visible = false;
                            dgv001.Columns[6].Visible = false;
                            dgv001.Columns[7].Visible = false;

                            dgv001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dgv001.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                            if (GeneralVariables.cultureCode == "AR")
                            {
                                dgv001.Columns[3].Visible = true;
                                dgv001.Columns[4].Visible = false;
                            }
                            else
                            {
                                dgv001.Columns[3].Visible = false;
                                dgv001.Columns[4].Visible = true;
                            }


                            ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
                        }
                        else
                        {
                            if (dgv001.Rows.Count > 0) { dgv001.DataSource = null; dgv001.Rows.Clear(); };
                            ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات

                        }
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >> dgv001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                }
            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblSalesCartDetails(); // تعبئة جدول فروع المنشآت

                    if (TblSalesCartDetails != null)
                    {
                        if (TblSalesCartDetails.Rows.Count > 0)
                        {

                            dgv001.DataSource = TblSalesCartDetails;

                            dgv001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الفرع");
                            dgv001.Columns[1].Visible = false;
                            dgv001.Columns[2].Visible = false;
                            dgv001.Columns[3].HeaderText = Cultures.ReturnTranslation("إسم الفرع عربي");
                            dgv001.Columns[4].HeaderText = Cultures.ReturnTranslation("إسم الفرع إنجليزي");
                            dgv001.Columns[5].Visible = false;
                            dgv001.Columns[6].Visible = false;
                            dgv001.Columns[7].Visible = false;

                            dgv001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dgv001.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                            if (GeneralVariables.cultureCode == "AR")
                            {
                                dgv001.Columns[3].Visible = true;
                                dgv001.Columns[4].Visible = false;
                            }
                            else
                            {
                                dgv001.Columns[3].Visible = false;
                                dgv001.Columns[4].Visible = true;
                            }


                            ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
                        }
                        else
                        {
                            if (dgv001.Rows.Count > 0) { dgv001.DataSource = null; dgv001.Rows.Clear(); };
                            ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات

                        }
                    }

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >> dgv001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                }


                dgv001.SelectionChanged += delegate
                {
                    try
                    {
                        if (dgv001.Rows.Count > 0)
                        {

                            if (dgv001.SelectedRows.Count == 0 || dgv001.SelectedRows == null) return;

                            //txt08001002001.Text = dgv001.SelectedRows[0].Cells[0].Value.ToString();
                            //cbx08001002001.SelectedValue = dgv001.SelectedRows[0].Cells[1].Value;
                            //cbx08001002002.SelectedValue = dgv001.SelectedRows[0].Cells[2].Value;
                            //txt08001002002.Text = dgv001.SelectedRows[0].Cells[3].Value.ToString();
                            //txt08001002003.Text = dgv001.SelectedRows[0].Cells[4].Value.ToString();
                            //txt08001002004.Text = dgv001.SelectedRows[0].Cells[5].Value.ToString();
                            //txt08001002005.Text = dgv001.SelectedRows[0].Cells[6].Value.ToString();

                            SelectedRowIndex = dgv001.SelectedRows[0].Index;

                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmSales23 >> dgv001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                    }
                };

                dgv001.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
                    dgv001.AllowUserToAddRows = true;
                };
            }
        }

        private void pnl002EventsAndProperties(bool Properties, bool Events = false) // الحاوية السفلية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl002, ColorPropertyName.BackColor_4);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl002, ColorPropertyName.BackColor_4, true, true);
            }
        }

        //------------------------------ 
        DataTable TblSaleCarts = new DataTable(); // جدول بيانات سلال المبيعات
        DataTable TblSalesCartDetails = new DataTable(); //جدول تفاصيل بيانات سلال المبيعات
        DataTable TblproductAndServicesDetails = new DataTable(); //جدول تفاصيل السلع والخدمات


        // تعبئة جدول بيانات سلال المبيعات 
        private void fillTblSaleCarts()
        {
            try
            {
                if (TblSaleCarts.Rows.Count > 0)
                {
                    TblSaleCarts.Rows.Clear();
                }

                if (TblSaleCarts.Rows.Count > 0) TblSaleCarts.Rows.Clear();

                TblSaleCarts = DataTools.DataBases.ReadTabel("select * from TblSaleCarts ");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23 >> fillTblSaleCarts ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        // تعبئة جدول تفاصيل بيانات سلال المبيعات 
        private void fillTblSalesCartDetails()
        {
            try
            {
                if (TblSalesCartDetails.Rows.Count > 0)
                {
                    TblSalesCartDetails.Rows.Clear();
                }

                if (TblSalesCartDetails.Rows.Count > 0) TblSalesCartDetails.Rows.Clear();

                if(lbl001.Text.Trim() != "")
                {
                    TblSalesCartDetails = DataTools.DataBases.ReadTabel("select * from TblSalesCartDetails where SalesCartNo = " + lbl001.Text);
                }

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23 >> fillTblSalesCartDetails ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        // تعبئة جدول تفاصيل السلع والخدمات
        private void fillTblproductAndServicesDetails()
        {
            try
            {
                if (TblproductAndServicesDetails.Rows.Count > 0)
                {
                    TblproductAndServicesDetails.Rows.Clear();
                }

                if (TblproductAndServicesDetails.Rows.Count > 0) TblproductAndServicesDetails.Rows.Clear();

                if (lbl001.Text.Trim() != "")
                {
                    TblproductAndServicesDetails = DataTools.DataBases.ReadTabel("select * from TblproductAndServicesDetails" );
                }

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23 >> fillTblproductAndServicesDetails ", DateTime.Now, ex.Message, ex.Message);
            }
        }
    }


}

