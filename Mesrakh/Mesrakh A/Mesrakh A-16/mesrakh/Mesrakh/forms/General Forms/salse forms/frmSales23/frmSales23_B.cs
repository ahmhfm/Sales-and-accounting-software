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
            txt000EventsAndProperties(Properties, Events); // مربع نص رقم العميل 

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
            //lbl009EventsAndProperties(Properties, Events);  // ملصق رقم الباركود 
            txt001EventsAndProperties(Properties, Events); //  رقم الباركود
            //lbl010EventsAndProperties(Properties, Events); // ملصق إسم الصنف 
            cbx001EventsAndProperties(Properties, Events); //  قائمة منسدلة اسم الصنف
            lbl011EventsAndProperties(Properties, Events); // ملصق السعر 
            txt002EventsAndProperties(Properties, Events); //  مربع نص السعر
            lbl012EventsAndProperties(Properties, Events);  // ملصق الكمية 
            txt003EventsAndProperties(Properties, Events); //  مربع نص الكمبة
            lbl013EventsAndProperties(Properties, Events); // ملصق نسبة التخفيظ 
            txt004EventsAndProperties(Properties, Events); //   مربع نسبة التخفيظ
            lbl014EventsAndProperties(Properties, Events); // ملصق مبلغ التخفيظ
            txt005EventsAndProperties(Properties, Events); //  مربع مبلغ التخفيظ

            lbl015EventsAndProperties(Properties, Events); // ملصق نسبة الضريبة 
            txt006EventsAndProperties(Properties, Events); // مربع نص نسبة الضريبة
            lbl016EventsAndProperties(Properties, Events); // ملصق مبلغ الضريبة 
            txt007EventsAndProperties(Properties, Events); // مربع نص مبلغ الضريبة
            lbl017EventsAndProperties(Properties, Events); // ملصق الكمية المجانية 
            txt008EventsAndProperties(Properties, Events); // مربع نص الكمية المجانية



            lbl018EventsAndProperties(Properties, Events); // ملصق الاجمالي الفرعي
            txt009EventsAndProperties(Properties, Events); //  مربع نص الاجمالي الفرعي
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

                    // 
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
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("إضافة عميل"), Cultures.ReturnTranslation("رجاء قم بتسجيل رقم العميل"), MessageBoxStatus.Text);

                    if(GeneralVariables.MessageBoxResult.Trim().Replace("'","") != "")
                    {
                        fillTblClients(GeneralVariables.MessageBoxResult);
                        if(TblClients != null)
                        {
                            if (TblClients.Rows.Count > 0)
                            {
                                if (GeneralVariables.cultureCode == "AR")
                                {
                                    lbl0033.Text = TblClients.Rows[0][1].ToString();
                                    lbl003.Text = TblClients.Rows[0][0].ToString();
                                }
                                else
                                {
                                    lbl0033.Text = TblClients.Rows[0][2].ToString();
                                    lbl003.Text = TblClients.Rows[0][0].ToString();
                                }
                            }
                        }
                    }

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
                    lbl003.Text = "";
                    lbl0033.Text = "";
                    TblClients = null;
                };

            }
        }


        private void txt000EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم العميل
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);

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


        //private void lbl009EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم الباركود 
        //{


        //    if (Properties == true & Events == false)
        //    {
        //        ElementsTools.Lable_.CustumProperties(lbl009, "رقم الباركود", ColorPropertyName.BackColor_5);
        //        lbl009.BackColor = Color.Transparent;
        //    }
        //    else if (Properties == true & Events == true)
        //    {
        //        ElementsTools.Lable_.CustumProperties(lbl009, "رقم الباركود", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
        //        lbl009.BackColor = Color.Transparent;
        //    }
        //}

        private void txt001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم الباركود
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001, "", 20);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001, "", 20, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        fillTblBarcode();
                        if(TblBarcode != null)
                        {
                            if(TblBarcode.Rows.Count>0)
                            {
                                cbx001.SelectedValue = TblBarcode.Rows[0][1];
                            }
                        }
                        
                    }
                };
            }
        }





        //private void lbl010EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم الصنف 
        //{


        //    if (Properties == true & Events == false)
        //    {
        //        ElementsTools.Lable_.CustumProperties(lbl010, "إسم الصنف", ColorPropertyName.BackColor_5);
        //        lbl010.BackColor = Color.Transparent;
        //    }
        //    else if (Properties == true & Events == true)
        //    {
        //        ElementsTools.Lable_.CustumProperties(lbl010, "إسم الصنف", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
        //        lbl010.BackColor = Color.Transparent;
        //    }
        //}

        private void cbx001EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة اسم الصنف
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblproductAndServicesDetails is null) fillTblproductAndServicesDetails();
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

                    txt002.Text = "0";
                    txt003.Text = "1";
                    txt004.Text = "0";
                    txt005.Text = "0";
                    txt006.Text = "0";
                    txt007.Text = "0";
                    txt008.Text = "0";
                    txt009.Text = "0";


                    fillTblPriceCategories(); // الاسعار
                    fillTblFreeUnitsOffers(); // العروض

                    FillAndCalculate(); // حساب وتعبئة البيانات
                };
            }
        }

        private void FillAndCalculate()
        {

            txt002.Text = price(txt003.Text); // السعر // وضعت هنا لانها تعتمد على قيمة الكمية
            txt008.Text = FreeUnitsOffers(txt003.Text); // الكمية المجانية
            txt009.Text = subTotal();// الاجمالي الفرعي
        }
        // حساب السعر
        private string price(string qty)
        {
            string result = "0";
            if(qty.Trim().Replace("'","") != "")
            {
                // السعر بناء على الفئة
                var price = from pri in TblPriceCategories.AsEnumerable()
                            where float.Parse(pri[2].ToString()) <= float.Parse(qty) && float.Parse(pri[3].ToString()) >= float.Parse(qty)
                            select pri;

                foreach (var row in price)
                {
                    result = row[4].ToString();
                }
            }
            return result;
        }


        // حساب عدد الوحدات المجانية 
        private string FreeUnitsOffers(string qty)
        {
            string result = "0";

            if (qty.Trim().Replace("'", "") != "")
            {
                // عدد الوحدات المجانية بناء على الكمية وتاريخ العرض
                var FreeUnits = from fru in TblFreeUnitsOffers.AsEnumerable()
                                where float.Parse(fru[2].ToString()) <= float.Parse(qty) && float.Parse(fru[3].ToString()) >= float.Parse(qty) && DateTime.Now >= DateTime.Parse(fru[5].ToString()) && DateTime.Now <= DateTime.Parse(fru[6].ToString())
                                select fru;
                foreach (var row in FreeUnits)
                {
                    result = row[4].ToString();
                }
            }

            return result;
        }

        // حساب المجموع الفرعي
        private string subTotal()
        {
            string result = "0";
            if(txt002.Text.Trim().Replace("'","") != "" && txt003.Text.Trim().Replace("'", "") != "" && txt005.Text.Trim().Replace("'", "") != "" && txt007.Text.Trim().Replace("'", "") != "")
            {
                result = Convert.ToString((float.Parse(txt002.Text) * float.Parse(txt003.Text)) - float.Parse(txt005.Text) + float.Parse(txt007.Text));
            }
            return result;
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

                txt003.TextChanged += delegate
                {
                    FillAndCalculate(); // حساب وتعبئة البيانات
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

                txt004.TextChanged += delegate
                {
                    if (txt002.Text.Trim().Replace("'", "") != "" && txt003.Text.Trim().Replace("'", "") != "" && txt004.Text.Trim().Replace("'", "") != "" )
                    {
                        txt005.Text = Convert.ToString((float.Parse(txt002.Text) * float.Parse(txt003.Text)) * (float.Parse(txt004.Text) / 100));

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

                txt005.TextChanged += delegate
                {
                    FillAndCalculate(); // حساب وتعبئة البيانات
                };
            }
        }

        private void lbl015EventsAndProperties(bool Properties, bool Events = false) // ملصق نسبة الضريبة 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl015, "نسبة الضريبة", ColorPropertyName.BackColor_5);
                lbl015.BackColor = Color.Transparent;

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl015, "نسبة الضريبة", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
                lbl015.BackColor = Color.Transparent;

            }
        }

        private void txt006EventsAndProperties(bool Properties, bool Events = false) // مربع نص نسبة الضريبة
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt006, "", 6);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt006, "", 6, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt006.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        //pic003.Select();
                    }
                };

                txt006.TextChanged += delegate
                {

                    if (txt002.Text.Trim().Replace("'", "") != "" && txt003.Text.Trim().Replace("'", "") != "" && txt005.Text.Trim().Replace("'", "") != "")
                    {
                        float taxPracentage = float.Parse(txt006.Text) / 100;
                        float price = ((float.Parse(txt002.Text) * float.Parse(txt003.Text)) - float.Parse(txt005.Text));
                        txt007.Text = Convert.ToString(taxPracentage * price);
                    }


                };
            }
        }

        private void lbl016EventsAndProperties(bool Properties, bool Events = false) // ملصق مبلغ الضريبة 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl016, "مبلغ الضريبة", ColorPropertyName.BackColor_5);
                lbl016.BackColor = Color.Transparent;

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl016, "مبلغ الضريبة", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
                lbl016.BackColor = Color.Transparent;

            }
        }

        private void txt007EventsAndProperties(bool Properties, bool Events = false) // مربع نص مبلغ الضريبة
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt007, "", 10);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt007, "", 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt007.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        //pic003.Select();
                    }
                };

                txt007.TextChanged += delegate
                {
                    FillAndCalculate(); // حساب وتعبئة البيانات
                };
            }
        }

        private void lbl017EventsAndProperties(bool Properties, bool Events = false) // ملصق الكمية المجانية 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl017, "الكمية المجانية", ColorPropertyName.BackColor_5);
                lbl017.BackColor = Color.Transparent;

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl017, "الكمية المجانية", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
                lbl017.BackColor = Color.Transparent;

            }
        }

        private void txt008EventsAndProperties(bool Properties, bool Events = false) // مربع نص الكمية المجانية
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt008, "", 10);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt008, "", 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt008.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        //pic003.Select();
                    }
                };
            }
        }

        private void lbl018EventsAndProperties(bool Properties, bool Events = false) // ملصق الاجمالي الفرعي 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl018, "الإجمالي الفرعي", ColorPropertyName.BackColor_5);
                lbl018.BackColor = Color.Transparent;

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl018, "الإجمالي الفرعي", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
                lbl018.BackColor = Color.Transparent;

            }
        }

        private void txt009EventsAndProperties(bool Properties, bool Events = false) // مربع نص الاجمالي الفرعي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt009, "", 9);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt009, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                //txt006.KeyDown += delegate (object mysender, KeyEventArgs mye)
                //{
                //    if (mye.KeyData == Keys.Enter)
                //    {
                //        pic003.Select();
                //    }
                //};
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

        DataTable TblproductAndServicesDetails = new DataTable(); //جدول تفاصيل السلع والخدمات
        DataTable TblBarcode = new DataTable(); //جدول الباركود
        DataTable TblPriceCategories = new DataTable(); //جدول الفئات السعرية
        DataTable TblFreeUnitsOffers = new DataTable(); //جدول عروض الوحدات المجانية
        DataTable TblClients = new DataTable(); //جدول العملاء 

        DataTable TblSaleCarts = new DataTable(); // جدول بيانات سلال المبيعات
        DataTable TblSalesCartDetails = new DataTable(); //جدول تفاصيل بيانات سلال المبيعات



        // تعبئة جدول السلع والخدمات
        private void fillTblproductAndServicesDetails()
        {
            try
            {
                if (TblproductAndServicesDetails.Rows.Count > 0)
                {
                    TblproductAndServicesDetails.Rows.Clear();
                }

                if (TblproductAndServicesDetails.Rows.Count > 0) TblproductAndServicesDetails.Rows.Clear();

                TblproductAndServicesDetails = DataTools.DataBases.ReadTabel("select * from TblproductAndServicesDetails inner join TblBarcode on TblproductAndServicesDetails.UnitDetailsNo = TblBarcode.UnitDetailsNo ");


            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23 >> fillTblproductAndServicesDetails ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        //جدول الباركود
        private void fillTblBarcode()
        {
            try
            {
                if (TblBarcode.Rows.Count > 0)
                {
                    TblBarcode.Rows.Clear();
                }

                if (TblBarcode.Rows.Count > 0) TblBarcode.Rows.Clear();

                if(txt001.Text.Trim().Replace("'", "") != "")
                {
                    TblBarcode = DataTools.DataBases.ReadTabel("select * from TblBarcode where BarcodeNo = " + txt001.Text.Trim().Replace("'", ""));
                }

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23 >> fillTblBarcode ", DateTime.Now, ex.Message, ex.Message);
            }
        }


         //جدول الفئات السعرية
        private void fillTblPriceCategories()
        {
            try
            {
                if (TblPriceCategories.Rows.Count > 0)
                {
                    TblPriceCategories.Rows.Clear();
                }

                if (TblPriceCategories.Rows.Count > 0) TblPriceCategories.Rows.Clear();

                if(cbx001.SelectedIndex>-1)
                {
                    if(cbx001.SelectedValue.ToString().Trim() != "")
                    {
                        TblPriceCategories = DataTools.DataBases.ReadTabel("select * from TblPriceCategories where  UnitDetailsNo = " + cbx001.SelectedValue.ToString());

                    }
                }


            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23 >> fillTblPriceCategories ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        //جدول عروض الوحدات المجانية
        private void fillTblFreeUnitsOffers()
        {
            try
            {
                if (TblFreeUnitsOffers.Rows.Count > 0)
                {
                    TblFreeUnitsOffers.Rows.Clear();
                }

                if (TblFreeUnitsOffers.Rows.Count > 0) TblFreeUnitsOffers.Rows.Clear();

                if (cbx001.SelectedIndex > -1)
                {
                    if (cbx001.SelectedValue.ToString().Trim() != "")
                    {
                        TblFreeUnitsOffers = DataTools.DataBases.ReadTabel("select * from TblFreeUnitsOffers where  UnitDetailsNo = " + cbx001.SelectedValue.ToString());

                    }
                }



            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23 >> fillTblFreeUnitsOffers ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        //جدول العملاء
        private void fillTblClients(string clientNo)
        {
            try
            {
                if (TblClients == null) TblClients = new DataTable();
                if (TblClients.Rows.Count > 0)
                {
                    TblClients.Rows.Clear();
                }

                if (TblClients.Rows.Count > 0) TblClients.Rows.Clear();

                if (clientNo.Trim().Replace("'", "") != "")
                {
                    TblClients = DataTools.DataBases.ReadTabel("select * from TblClients where ClientsNo = " + clientNo );
                }

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23 >> fillTblClients ", DateTime.Now, ex.Message, ex.Message);
            }
        }

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

                if (lbl001.Text.Trim() != "")
                {
                    TblSalesCartDetails = DataTools.DataBases.ReadTabel("select * from TblSalesCartDetails where SalesCartNo = " + lbl001.Text);
                }

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23 >> fillTblSalesCartDetails ", DateTime.Now, ex.Message, ex.Message);
            }
        }

    }


}

