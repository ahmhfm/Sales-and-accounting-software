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


    public partial class frmReceiptVouchers : Form
    {
        public string _TypesOfReceiptBonds; // نوع سند القبض
        public string SalesCartNo = "";// رقم سلة المشتريات
        public string ShiftNumber = ""; // رقم الوردية
        public string BalanceInRecords = ""; // الرصيد القيدي في جدول الورديات
        public string OperationUnitNumber = ""; // رقم وحدة العمليات
        public string OperationUnitAccountNo = ""; // رقم الحساب المحاسبي لصندوق الكاشير
        public string BranchNumber = ""; // رقم الفرع
        public string OutputTax = ""; // ضريبة المخرجات
        public string SalePriceAfterDiscount = ""; // سعر البيع بعد الخصم التجاري
        
        public frmReceiptVouchers()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {

            frmEncapsulationUnits13EventsAndProperties(Properties, Events); // النموذج
            pnlMainEventsAndProperties(Properties, Events); // الحاوية الرئيسية
            pnl001EventsAndProperties(Properties, Events); // الحاوية العلوية

            lblTitelEventsAndProperties(Properties, Events);   // سند قبض
            lbl001EventsAndProperties(Properties, Events);   // ملصق رقم العميل 
            txt001EventsAndProperties(Properties, Events);   // مربع نص رقم العميل 

            lbl000EventsAndProperties(Properties, Events);   // ملصق رقم الفاتورة 
            txt000EventsAndProperties(Properties, Events);   // مربع نص رقم الفاتورة 

            lbl002EventsAndProperties(Properties, Events);   // ملصق اسم العميل 
            txt002EventsAndProperties(Properties, Events);   // مربع نص اسم العميل

            lblBanckAccountEventsAndProperties(Properties, Events);   // ملصق رقم الحساب البنكي
            cbxBanckAccountEventsAndProperties(Properties, Events);   // قائمة منسدلة الحسابات البنكية الخاصة بهذا الفرع

            lbl003EventsAndProperties(Properties, Events);   //  ملصق كاش
            txt003EventsAndProperties(Properties, Events);   // مربع نص كاش
            lbl004EventsAndProperties(Properties, Events);   // ملصق بنك
            txt004EventsAndProperties(Properties, Events);   // مربع نص بنك
            lbl005EventsAndProperties(Properties, Events);   // ملصق شيك بنك
            txt005EventsAndProperties(Properties, Events);   // مربع نص شيك بنك
            lbl006EventsAndProperties(Properties, Events);   // ملصق آجل
            txt006EventsAndProperties(Properties, Events);   // مربع نص آجل
            lbl007EventsAndProperties(Properties, Events);   // ملصق عند التسليم
            txt007EventsAndProperties(Properties, Events);   // مربع نص عند التسليم
            lbl008EventsAndProperties(Properties, Events);   // ملصق المجموع
            txt008EventsAndProperties(Properties, Events);   // مربع نص المجموع

            btnCloseEventsAndProperties(Properties, Events); // زر اغلاق
            btn000EventsAndProperties(Properties, Events); // زر اضافة فاتورة مرتبطة
            btn001EventsAndProperties(Properties, Events); // زر اضافة عميل
            btn002EventsAndProperties(Properties, Events); // زر حفظ سند القبض والتعديل على الرصيد القيدي بالوردية

        }

        private void frmEncapsulationUnits13EventsAndProperties(bool Properties, bool Events = false) // النموذج 
        {

            if (Properties == true & Events == false)
            {
                //ElementsTools.Form_.CustumProperties(this);

            }
            else if (Properties == true & Events == true)
            {
                //ElementsTools.Form_.CustumProperties(this, ColorPropertyName.BackColor_3, true, true);
                this.Load += delegate
                {
                    txt003.SelectAll();

                    cbxBanckAccountEventsAndProperties(true, true);

                    if(txt001.Text.Trim() != "")
                    {
                        fillTblClients(txt001.Text);
                    }
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
                ElementsTools.panel_.CustumProperties(pnl001, ColorPropertyName.BackColor_1);
                //pnl001.BackColor = Color.White;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl001, ColorPropertyName.BackColor_1, true, true);
                //pnl001.BackColor = Color.White;
            }
        }


        private void lblTitelEventsAndProperties(bool Properties, bool Events = false) // ملصق عنوان النموذج 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblTitel, "سند قبض", ColorPropertyName.BackColor_1);
                lblTitel.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblTitel, "سند قبض", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lblTitel.BackColor = Color.Transparent;

            }
        }

        private void lbl000EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم الفاتورة 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl000, "رقم الفاتورة", ColorPropertyName.BackColor_1);
                lbl000.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl000, "رقم الفاتورة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl000.BackColor = Color.Transparent;

            }
        }

        private void txt000EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم الفاتورة
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt000, "", 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Int);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt000, "", 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Int);

            }
        }

        private void lbl001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم العميل 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001, "رقم العميل", ColorPropertyName.BackColor_1);
                lbl001.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001, "رقم العميل", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl001.BackColor = Color.Transparent;

            }
        }

        private void txt001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم العميل
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001, "", 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Int);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001, "", 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Int);

            }
        }

        private void lbl002EventsAndProperties(bool Properties, bool Events = false) // ملصق إسم العميل 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl002, "إسم العميل", ColorPropertyName.BackColor_1);
                lbl002.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl002, "إسم العميل", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl002.BackColor = Color.Transparent;

            }
        }

        private void txt002EventsAndProperties(bool Properties, bool Events = false) // مربع نص إسم العميل
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt002, "", 50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.String);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt002, "", 50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.String);

            }
        }

        private void lblBanckAccountEventsAndProperties(bool Properties, bool Events = false) // ملصق الحساب البنكي 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblBanckAccount, "الحساب البنكي", ColorPropertyName.BackColor_1);
                lblBanckAccount.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblBanckAccount, "الحساب البنكي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lblBanckAccount.BackColor = Color.Transparent;

            }
        }

        private void cbxBanckAccountEventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة الحسابات
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblBankAccounts is null) return;
                    if (TblBankAccounts.Rows.Count > 0)
                    {
                        cbxBanckAccount.DataSource = TblBankAccounts;
                        cbxBanckAccount.ValueMember = "AccountNo";
                        cbxBanckAccount.DisplayMember = "AccountHoldersName";
                        ElementsTools.ComboBox_.CustumProperties(cbxBanckAccount);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23  frmReceiptVouchers >> cbxBanckAccountEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {

                fillTblBankAccounts(BranchNumber);

                try
                {
                    if (TblBankAccounts is null) return;
                    if (TblBankAccounts.Rows.Count > 0)
                    {
                        cbxBanckAccount.DataSource = TblBankAccounts;
                        cbxBanckAccount.ValueMember = "AccountNo";
                        cbxBanckAccount.DisplayMember = "AccountHoldersName";
                        ElementsTools.ComboBox_.CustumProperties(cbxBanckAccount);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23  frmReceiptVouchers >> cbxBanckAccountEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
        
        }


        private void lbl003EventsAndProperties(bool Properties, bool Events = false) //  ملصق كاش
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "كاش", ColorPropertyName.BackColor_1);
                lbl003.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "كاش", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl003.BackColor = Color.Transparent;

            }
        }

        private void txt003EventsAndProperties(bool Properties, bool Events = false) // مربع نص كاش
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt003, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt003, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Decimal);
                txt003.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {

                    if (mye.KeyData == Keys.Enter)
                    {
                        txt004.Focus();
                        txt004.SelectAll();
                    }
                };
            }
        }

        private void lbl004EventsAndProperties(bool Properties, bool Events = false) // ملصق بنك 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl004, "بنك", ColorPropertyName.BackColor_1);
                lbl004.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl004, "بنك", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl004.BackColor = Color.Transparent;

            }
        }

        private void txt004EventsAndProperties(bool Properties, bool Events = false) // مربع نص بنك
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt004, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt004, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Decimal);
                txt004.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt005.Focus();
                        txt005.SelectAll();
                    }
                };
            }
        }


        private void lbl005EventsAndProperties(bool Properties, bool Events = false) // ملصق شيك بنك 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl005, "شيك بنك", ColorPropertyName.BackColor_1);
                lbl005.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl005, "شيك بنك", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl005.BackColor = Color.Transparent;

            }
        }

        private void txt005EventsAndProperties(bool Properties, bool Events = false) // مربع نص شيك بنك
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt005, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt005, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Decimal);
                txt005.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt006.Focus();
                        txt006.SelectAll();
                    }
                };
            }
        }


        private void lbl006EventsAndProperties(bool Properties, bool Events = false) // ملصق آجل 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl006, "آجل", ColorPropertyName.BackColor_1);
                lbl006.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl006, "آجل", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl006.BackColor = Color.Transparent;

            }
        }

        private void txt006EventsAndProperties(bool Properties, bool Events = false) //  مربع نص آجل
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt006, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt006, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Decimal);
                txt006.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        btn002.PerformClick();
                    }
                };
            }
        }

        private void lbl007EventsAndProperties(bool Properties, bool Events = false) // ملصق عند التسليم 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl007, "عند التسليم", ColorPropertyName.BackColor_1);
                lbl007.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl007, "عند التسليم", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl007.BackColor = Color.Transparent;

            }
        }

        private void txt007EventsAndProperties(bool Properties, bool Events = false) //  مربع نص عند التسليم
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt007, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt007, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Decimal);
                //lbl007.KeyDown += delegate (object mysender, KeyEventArgs mye)
                //{
                //    //if (mye.KeyData == Keys.Enter)
                //    //{
                //    //    btn002.PerformClick();
                //    //}
                //};
            }
        }


        private void lbl008EventsAndProperties(bool Properties, bool Events = false) // ملصق المجموع 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl008, "المجموع", ColorPropertyName.BackColor_1);
                lbl008.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl008, "المجموع", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl008.BackColor = Color.Transparent;

            }
        }

        private void txt008EventsAndProperties(bool Properties, bool Events = false) //  مربع نص المجموع
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt008, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt008, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Decimal);
                //lbl007.KeyDown += delegate (object mysender, KeyEventArgs mye)
                //{
                //    //if (mye.KeyData == Keys.Enter)
                //    //{
                //    //    btn002.PerformClick();
                //    //}
                //};
            }
        }




        private void btnCloseEventsAndProperties(bool Properties, bool Events = false) // زر اغلاق النموذج
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btnClose.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCloseBlue);
                    }
                    else
                    {
                        btnClose.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCloseDark);
                    }
                    btnClose.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {

                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23    frmSalseInvoice >>  btnCloseEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btnClose.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCloseBlue);
                    }
                    else
                    {
                        btnClose.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCloseDark);
                    }
                    btnClose.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {

                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23    frmSalseInvoice >>  btnCloseEventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgClose = null;
                btnClose.MouseMove += delegate
                {
                    try
                    {
                        if (imgClose == null)
                        {
                            imgClose = btnClose.Image;
                            btnClose.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCloseRed);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmSales23    frmSalseInvoice >>  btnCloseEventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
                btnClose.MouseLeave += delegate
                {
                    try
                    {
                        btnClose.Image = imgClose;
                        imgClose = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmSales23    frmSalseInvoice >>  btnCloseEventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btnClose.Click += delegate
                {
                    this.Close();
                };
            }
        }


        private void btn000EventsAndProperties(bool Properties, bool Events = false) // زر اضافة رقم فاتورة
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn000, Cultures.ReturnTranslation("الفاتورة المرتبطة"), ColorPropertyName.ForeColor_1);

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn000, Cultures.ReturnTranslation("الفاتورة المرتبطة"), ColorPropertyName.ForeColor_1, true, true);

                btn000.Click += delegate
                {

                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("إضافة فاتورة مرتبطة"), Cultures.ReturnTranslation("رجاء قم بتسجيل رقم الفاتورة"), MessageBoxStatus.Text);

                    if (GeneralVariables.MessageBoxResult.Trim().Replace("'", "") != "")
                    {

                        fillTblSalesBill(GeneralVariables.MessageBoxResult);
                        if (TblSalesBill.Rows.Count < 1)
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا يوجد فاتورة بهذه البيانات"), MessageBoxStatus.Ok);
                            return;
                        }
                        if (TblSalesBill != null)
                        {
                            if (TblSalesBill.Rows.Count > 0)
                            {
                                txt000.Text = TblSalesBill.Rows[0][0].ToString();
                            }
                        }

                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لم تقم بتسجيل رقم السلة"), MessageBoxStatus.Ok);

                    }
                };

            }
        }


        private void btn001EventsAndProperties(bool Properties, bool Events = false) // زر اضافة اسم عميل
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001, Cultures.ReturnTranslation("إضافة عميل"), ColorPropertyName.ForeColor_1);

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn001, Cultures.ReturnTranslation("إضافة عميل"), ColorPropertyName.ForeColor_1, true, true);

                btn001.Click += delegate
                {

                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("إضافة عميل"), Cultures.ReturnTranslation("رجاء قم بتسجيل رقم العميل"), MessageBoxStatus.Text);

                    if (GeneralVariables.MessageBoxResult.Trim().Replace("'", "") != "")
                    {

                        fillTblClients(GeneralVariables.MessageBoxResult);
                        if (TblClients.Rows.Count < 1)
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا يوجد عميل بهذه البيانات"), MessageBoxStatus.Ok);
                            return;
                        }
                        if (TblClients != null)
                        {
                            if (TblClients.Rows.Count > 0)
                            {
                                if (GeneralVariables.cultureCode == "AR")
                                {
                                    txt002.Text = TblClients.Rows[0][1].ToString();
                                    txt001.Text = TblClients.Rows[0][0].ToString();
                                }
                                else
                                {
                                    txt002.Text = TblClients.Rows[0][2].ToString();
                                    txt001.Text = TblClients.Rows[0][0].ToString();
                                }
                            }
                        }

                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لم تقم بتسجيل رقم السلة"), MessageBoxStatus.Ok);

                    }
                };

            }
        }





        private void btn002EventsAndProperties(bool Properties, bool Events = false) // زر حفظ سند القبض
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn002, Cultures.ReturnTranslation("حفظ سند قبض"), ColorPropertyName.ForeColor_1);

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn002, Cultures.ReturnTranslation("حفظ سند قبض"), ColorPropertyName.ForeColor_1,true,true);

                btn002.Click += delegate
                {

                    if (txt003.Text.Trim() == "" || txt003.Text.Trim() == ".")
                    {
                        txt003.Text = "0";
                    }
                    if (txt004.Text.Trim() == "" || txt004.Text.Trim() == ".")
                    {
                        txt004.Text = "0";
                    }
                    if (txt005.Text.Trim() == "" || txt005.Text.Trim() == ".")
                    {
                        txt005.Text = "0";
                    }

                    if (txt006.Text.Trim() == "" || txt006.Text.Trim() == ".")
                    {
                        txt006.Text = "0";
                    }
                    if (txt007.Text.Trim() == "" || txt007.Text.Trim() == ".")
                    {
                        txt007.Text = "0";
                    }
                    if (txt008.Text.Trim() == "" || txt008.Text.Trim() == ".")
                    {
                        txt008.Text = "0";
                    }

                    
                    decimal cash = decimal.Parse(txt003.Text);// كاش
                    decimal Bank = decimal.Parse(txt004.Text);// بنك
                    decimal BankCheck = decimal.Parse(txt005.Text); // اوراق قبض
                    decimal DeferredPayment = decimal.Parse(txt006.Text); // آجل
                    decimal OnDelivery = decimal.Parse(txt007.Text);// عند التسليم
                    decimal all = decimal.Parse(txt008.Text);  // المجموع


                    //------ اذا كان الدفع بالآجل
                    if (txt006.Text != "0" && txt001.Text.Trim() == "")
                    {
                        btn001.PerformClick(); // اضافة عميل
                        return;
                    }




                    object journalEntryNo = ""; // رقم قيد اليومية

                    //---- بناء قيود اليمية
                    {
                        if (_TypesOfReceiptBonds == TypesOfReceiptBonds.NewInvoice.ToString())// فاتورة جديدة
                        {
                            //----- التأكد هل المبالغ تساوي المجموع
                            if ((cash + Bank + BankCheck + DeferredPayment + OnDelivery) != all)
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("طرفي المعادلة غير متساوية"), MessageBoxStatus.Ok);
                                return;
                            }

                            // ايجاد الحسابات المحاسبية وايجاد قيمها
                            List<JournalEntry> accounts = new List<JournalEntry>();
                            {

                                // قيد الكاش المستلم
                                if (cash != 0)
                                {

                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = OperationUnitAccountNo; // رقم الحساب المحاسبي لصندوق الكاشير
                                    j.DebitValue = cash.ToString(); // مدين
                                    j.CreditValue = "0"; // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);
                                }

                                // قيد المبلغ المحول للحساب 
                                if (Bank != 0)
                                {
 
                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = cbxBanckAccount.SelectedValue.ToString(); // رقم الحساب المحاسبي للحساب البنكي
                                    j.DebitValue = Bank.ToString(); // مدين
                                    j.CreditValue = "0"; // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);
                                }

                                // قيد اوراق القبض 
                                if (BankCheck != 0)
                                {

                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = GeneralVariables.TblStandardAccounts.Rows[7][4].ToString(); // رقم الحساب المحاسبي لحساب اوراق القبض
                                    j.DebitValue = BankCheck.ToString(); // مدين
                                    j.CreditValue = "0"; // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);
                                }

                                // قيد سداد آجل 
                                if (DeferredPayment != 0)
                                {

                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = TblClients.Rows[0][19].ToString(); // رقم الحساب المحاسبي للزبون
                                    j.DebitValue = DeferredPayment.ToString(); // مدين
                                    j.CreditValue = "0"; // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);
                                }

                                // قيد الدفعة التي تستحق عند التوريد
                                if (OnDelivery != 0)
                                {
                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = GeneralVariables.TblStandardAccounts.Rows[11][4].ToString(); // رقم الحساب المحاسبي لحساب دفعات تستحق عند التوريد
                                    j.DebitValue = OnDelivery.ToString(); // مدين
                                    j.CreditValue = "0"; // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);
                                }
                                 
                                // قيد اثبات ضريبة المخرجات
                                {

                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = GeneralVariables.TblStandardAccounts.Rows[10][4].ToString(); // رقم الحساب المحاسبي للضرائب الخارجة
                                    j.DebitValue = "0"; // مدين
                                    j.CreditValue = OutputTax; // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);


                                }

                                // قيد اثبات المبيعات 
                                {
                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = GeneralVariables.TblStandardAccounts.Rows[6][4].ToString(); // رقم الحساب المحاسبي للمبيعات 
                                    
                                    j.DebitValue = "0"; // مدين
                                    j.CreditValue = SalePriceAfterDiscount; // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);
                                }
                            }

                            //--- تنفيذ قيد اليومية الرئيسي
                            string[] result00 = null;
                                    journalEntryNo = DataTools.DataBases.Run(ref result00, "psJournalEntry", CommandType.StoredProcedure, new object[][] {
                                    new object[] { "@EntryDateTime", DateTime.Now }
                                    , new object[] { "@AccountingEntrytStatement", "فاتورة المبيعات رقم " + txt000.Text }
                                    ,  new object[] { "@JournalEntryNo", "OUT" }
                                });

                            //---- تنفيذ قيود اليومية الفرعية
                            foreach (JournalEntry _JournalEntry in accounts)
                            {
                                string[] result11 = null;
                                DataTools.DataBases.Run(ref result11, "insert into TblSubJournalEntry values (@JournalEntryNo , @AccountNo , @DebitValue , @CreditValue , @AccountingEntrytStatement)", CommandType.Text, new object[][]
                               { new object[] { "@JournalEntryNo", journalEntryNo },
                                        new object[] { "@AccountNo", _JournalEntry.AccountNo } ,
                                        new object[] { "@DebitValue", _JournalEntry.DebitValue } ,
                                        new object[] { "@CreditValue", _JournalEntry.CreditValue } ,
                                        new object[] { "@AccountingEntrytStatement", _JournalEntry.AccountingEntrytStatement } 
                                });
                            }

                        }
                        else if (_TypesOfReceiptBonds == TypesOfReceiptBonds.FuturePayment.ToString())// سند قبض دفعات مؤخرة برقم الفاتورة
                        {

                            // ايجاد الحسابات المحاسبية وايجاد قيمها
                            List<JournalEntry> accounts = new List<JournalEntry>();
                            {
                                // قيد الكاش المستلم
                                if (cash != 0)
                                {

                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = OperationUnitAccountNo; // رقم الحساب المحاسبي لصندوق الكاشير
                                    j.DebitValue = cash.ToString(); // مدين
                                    j.CreditValue = "0"; // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);
                                }

                                // قيد المبلغ المحول للحساب 
                                if (Bank != 0)
                                {

                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = cbxBanckAccount.SelectedValue.ToString(); // رقم الحساب المحاسبي للحساب البنكي
                                    j.DebitValue = Bank.ToString(); // مدين
                                    j.CreditValue = "0"; // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);
                                }

                                // قيد اوراق القبض 
                                if (BankCheck != 0)
                                {

                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = GeneralVariables.TblStandardAccounts.Rows[7][4].ToString(); // رقم الحساب المحاسبي لحساب اوراق القبض
                                    j.DebitValue = BankCheck.ToString(); // مدين
                                    j.CreditValue = "0"; // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);
                                }

                                // قيد سداد آجل 
                                if (DeferredPayment != 0)
                                {

                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = TblClients.Rows[0][19].ToString(); // رقم الحساب المحاسبي للزبون
                                    j.DebitValue = DeferredPayment.ToString(); // مدين
                                    j.CreditValue = "0"; // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);
                                }

                                //// قيد الدفعة التي تستحق عند التوريد
                                //if (OnDelivery != 0)
                                {
                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = GeneralVariables.TblStandardAccounts.Rows[11][4].ToString(); // رقم الحساب المحاسبي لحساب دفعات تستحق عند التوريد
                                    j.DebitValue = "0"; // مدين
                                    j.CreditValue = (cash + Bank + BankCheck + DeferredPayment).ToString(); // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);
                                }



                            }

                            //--- تنفيذ قيد اليومية الرئيسي
                            string[] result00 = null;
                            journalEntryNo = DataTools.DataBases.Run(ref result00, "psJournalEntry", CommandType.StoredProcedure, new object[][] {
                                    new object[] { "@EntryDateTime", DateTime.Now }
                                    , new object[] { "@AccountingEntrytStatement", "فاتورة المبيعات رقم " + txt000.Text }
                                    ,  new object[] { "@JournalEntryNo", "OUT" }
                                });

                            //---- تنفيذ قيود اليومية الفرعية
                            foreach (JournalEntry _JournalEntry in accounts)
                            {
                                string[] result11 = null;
                                DataTools.DataBases.Run(ref result11, "insert into TblSubJournalEntry values (@JournalEntryNo , @AccountNo , @DebitValue , @CreditValue , @AccountingEntrytStatement)", CommandType.Text, new object[][]
                               { new object[] { "@JournalEntryNo", journalEntryNo },
                                        new object[] { "@AccountNo", _JournalEntry.AccountNo } ,
                                        new object[] { "@DebitValue", _JournalEntry.DebitValue } ,
                                        new object[] { "@CreditValue", _JournalEntry.CreditValue } ,
                                        new object[] { "@AccountingEntrytStatement", _JournalEntry.AccountingEntrytStatement }
                                });
                            }

                        }
                        else if (_TypesOfReceiptBonds == TypesOfReceiptBonds.RepayDebts.ToString())// سداد ديون
                        {
                            // ايجاد الحسابات المحاسبية وايجاد قيمها
                            List<JournalEntry> accounts = new List<JournalEntry>();
                            {
                                // قيد الكاش المستلم
                                if (cash != 0)
                                {

                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = OperationUnitAccountNo; // رقم الحساب المحاسبي لصندوق الكاشير
                                    j.DebitValue = cash.ToString(); // مدين
                                    j.CreditValue = "0"; // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);
                                }

                                // قيد المبلغ المحول للحساب 
                                if (Bank != 0)
                                {

                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = cbxBanckAccount.SelectedValue.ToString(); // رقم الحساب المحاسبي للحساب البنكي
                                    j.DebitValue = Bank.ToString(); // مدين
                                    j.CreditValue = "0"; // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);
                                }

                                // قيد اوراق القبض 
                                if (BankCheck != 0)
                                {

                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = GeneralVariables.TblStandardAccounts.Rows[7][4].ToString(); // رقم الحساب المحاسبي لحساب اوراق القبض
                                    j.DebitValue = BankCheck.ToString(); // مدين
                                    j.CreditValue = "0"; // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);
                                }

                                // الى حساب المدين فلان 
                                {

                                    JournalEntry j = new JournalEntry();
                                    j.AccountNo = TblClients.Rows[0][19].ToString(); // رقم الحساب المحاسبي للزبون
                                    j.DebitValue = "0"; // مدين
                                    j.CreditValue = (cash + Bank + BankCheck + DeferredPayment).ToString(); // دائن
                                    j.AccountingEntrytStatement = "";

                                    accounts.Add(j);
                                }

                            }

                            //--- تنفيذ قيد اليومية الرئيسي
                            string[] result00 = null;
                            journalEntryNo = DataTools.DataBases.Run(ref result00, "psJournalEntry", CommandType.StoredProcedure, new object[][] {
                                    new object[] { "@EntryDateTime", DateTime.Now }
                                    , new object[] { "@AccountingEntrytStatement", "فاتورة المبيعات رقم " + txt000.Text }
                                    ,  new object[] { "@JournalEntryNo", "OUT" }
                                });

                            //---- تنفيذ قيود اليومية الفرعية
                            foreach (JournalEntry _JournalEntry in accounts)
                            {
                                string[] result11 = null;
                                DataTools.DataBases.Run(ref result11, "insert into TblSubJournalEntry values (@JournalEntryNo , @AccountNo , @DebitValue , @CreditValue , @AccountingEntrytStatement)", CommandType.Text, new object[][]
                               { new object[] { "@JournalEntryNo", journalEntryNo },
                                        new object[] { "@AccountNo", _JournalEntry.AccountNo } ,
                                        new object[] { "@DebitValue", _JournalEntry.DebitValue } ,
                                        new object[] { "@CreditValue", _JournalEntry.CreditValue } ,
                                        new object[] { "@AccountingEntrytStatement", _JournalEntry.AccountingEntrytStatement }
                                });
                            }
                        }
                        else if (_TypesOfReceiptBonds == TypesOfReceiptBonds.ReturnPurchases.ToString())// مردودات مشتريات
                        {


                        }
                        else if (_TypesOfReceiptBonds == TypesOfReceiptBonds.Allowances.ToString())// مسموحات مشتريات
                        {

                        }
                        else
                        {

                        }
                    }

                    //-------------- اضافة سند قبض جديد
                    {
                        string[] result = null;
                        DataTools.DataBases.Run(ref result, "SpReceiptVouchers",
                       CommandType.StoredProcedure,
                       new object[][] {
                                      new object[] { "@RegistrationDateAndTime", DateTime.Now.ToString() } // تاريخ ووقت التسجيل
                                    , new object[] { "@SalesInvoiceNumber", txt000.Text } // رقم فاتورة البيع
                                    , new object[] { "@ClientsNo", txt001.Text } // رقم العميل
                                    , new object[] { "@cash", cash } // كاش
                                    , new object[] { "@Bank", Bank } // بنك
                                    , new object[] { "@BankCheck", BankCheck } // شيك بنك
                                    , new object[] { "@DeferredPayment", DeferredPayment } // آجل
                                    , new object[] { "@JournalEntryNo", journalEntryNo } // رقم قيد اليومية
                                    , new object[] { "@ShiftNumber", ShiftNumber } // رقم الوردية
                                    , new object[] { "@OnDelivery", OnDelivery } // مبلغ عند التسليم
                       });

                        if (result[1] == "succeeded")
                        {




                            //---------
                            this.Close();
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("توجد مشكلة لم تسمح بإضافة سند القبض"), MessageBoxStatus.Ok);
                        }
                    }


                    // الإضافة الى الرصيد القيدي في جدول الورديات
                    {
                        
                        string[] result = null;
                        DataTools.DataBases.Run(ref result, "update TblShifts set BalanceInRecords = @BalanceInRecords where ShiftNumber = @ShiftNumber "  ,
                       CommandType.Text,
                       new object[][] {
                                      new object[] { "@BalanceInRecords ", (Convert.ToDecimal(BalanceInRecords) + cash) } // الرصيد القيدي
                                    , new object[] { "@ShiftNumber", ShiftNumber } // رقم الوردية
                       });

                        if (result[1] == "succeeded")
                        {




                            //---------
                            this.Close();
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("توجد مشكلة لم تسمح بإضافة سند القبض"), MessageBoxStatus.Ok);
                        }
                    }



                    this.Close();

                };

            }


        }

        //جدول العملاء
        DataTable TblClients = new DataTable();
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
                    TblClients = DataTools.DataBases.ReadTabel("select * from TblClients where ClientsNo = " + clientNo);
                }

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23  frmReceiptVouchers >> fillTblClients ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        //جدول فاتورة البيع
        DataTable TblSalesBill = new DataTable();
        private void fillTblSalesBill(string SalesInvoiceNumber)
        {
            try
            {
                if (TblSalesBill == null) TblSalesBill = new DataTable();
                if (TblSalesBill.Rows.Count > 0)
                {
                    TblSalesBill.Rows.Clear();
                }

                if (TblSalesBill.Rows.Count > 0) TblSalesBill.Rows.Clear();

                if (SalesInvoiceNumber.Trim().Replace("'", "") != "")
                {
                    TblSalesBill = DataTools.DataBases.ReadTabel("select * from TblSalesBill where SalesInvoiceNumber = " + SalesInvoiceNumber);
                }

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23  frmReceiptVouchers >> fillTblSalesBill ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        //جدول الحسابات البنكية لهذا الحساب
        DataTable TblBankAccounts = new DataTable();
        private void fillTblBankAccounts(string BranchNumber)
        {
            try
            {
                if (TblBankAccounts == null) TblBankAccounts = new DataTable();
                if (TblBankAccounts.Rows.Count > 0)
                {
                    TblBankAccounts.Rows.Clear();
                }

                if (TblBankAccounts.Rows.Count > 0) TblBankAccounts.Rows.Clear();

                if (BranchNumber.Trim().Replace("'", "") != "")
                {
                    //MessageBox.Show("select * from TblBankAccounts  where BranchNumber = " + BranchNumber);
                    TblBankAccounts = DataTools.DataBases.ReadTabel("select * from TblBankAccounts  where BranchNumber = " + BranchNumber);
                }

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23  frmReceiptVouchers >> fillTblSalesBill ", DateTime.Now, ex.Message, ex.Message);
            }
        }


    }

    // كلاس قيود اليومية
    class JournalEntry
    {
        public string AccountNo { get; set; }// رقم الحساب
        public string DebitValue { get; set; }// مدين
        public string CreditValue { get; set; }// دائن
        public string AccountingEntrytStatement { get; set; }// البيان

    }

    // انواع سندات القبض
    /// <summary>
    /// NewInvoice فاتورة بيع / FuturePayment دفعة آجلة / RepayDebts  سداد ديون / ReturnPurchases مردودات المشتريات / Allowances مسموحات المشتريات
    /// </summary>
    enum TypesOfReceiptBonds { NewInvoice, FuturePayment, RepayDebts, ReturnPurchases, Allowances } // { مسموحات المشتريات ,  مردودات المشتريات  , سداد ديون  , دفعة آجلة ,  فاتورة بيع}

}

