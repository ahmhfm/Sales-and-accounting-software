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
            lbl003EventsAndProperties(Properties, Events);   //  ملصق كاش
            txt003EventsAndProperties(Properties, Events);   // مربع نص كاش
            lbl004EventsAndProperties(Properties, Events);   // ملصق بنك
            txt004EventsAndProperties(Properties, Events);   // مربع نص بنك
            lbl005EventsAndProperties(Properties, Events);   // ملصق شيك بنك
            txt005EventsAndProperties(Properties, Events);   // مربع نص شيك بنك
            lbl006EventsAndProperties(Properties, Events);   // ملصق آجل
            txt006EventsAndProperties(Properties, Events);   // مربع نص آجل

            btn001EventsAndProperties(Properties, Events); // زر اضافة عميل
            btn002EventsAndProperties(Properties, Events); // زر حفظ سند القبض



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
                pnl001.BackColor = Color.White;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl001, ColorPropertyName.BackColor_1, true, true);
                pnl001.BackColor = Color.White;
            }
        }


        private void lblTitelEventsAndProperties(bool Properties, bool Events = false) // ملصق عنوان النموذج 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblTitel, "سند قبض", ColorPropertyName.BackColor_1);
                //lblTitel.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblTitel, "سند قبض", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                //lblTitel.BackColor = Color.Transparent;

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

        private void txt001EventsAndProperties(bool Properties, bool Events = false) // إجمالي الفاتورة
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001, "", 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Int);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001, "", 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true,TextBoxType.Int);

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

                        //string[] result = null;
                        //object OUT_SalesCartDetailsNo = DataTools.DataBases.Run(ref result, "update TblSaleCarts set ClientsNo = @ClientsNo where SalesCartNo = SalesCartNo",
                        // CommandType.Text, new object[][] {
                        //              new object[] { "@SalesCartNo", lbl001.Text } // رقم سلة المبيعات
                        //              , new object[] { "@ClientsNo", GeneralVariables.MessageBoxResult } // رقم العميل
                        // });



                        //if (result[1] == "succeeded")
                        //{


                        //}

                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لم تقم بتسجيل رقم السلة"), MessageBoxStatus.Ok);

                    }
                };

            }
        }



        public  string SalesCartNo = "";// رقم سلة المشتريات
        public  string ShiftNumber = ""; // رقم الوردية
        public  string ClientsNo = ""; // رقم العميل
        //public  string SalesInvoiceNumber = ""; // رقم فاتورة البيع

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
                    if(txt006.Text.Trim() == "")
                    {
                        txt006.Text = "0";
                    }
                    if(txt006.Text != "0" && txt001.Text.Trim() == "")
                    {
                        btn001.PerformClick();

                        return;
                    }
                    string[] result = null;
                    DataTools.DataBases.Run(ref result, "SpReceiptVouchers",
                   CommandType.StoredProcedure,
                   new object[][] {
                                      new object[] { "@RegistrationDateAndTime", DateTime.Now.ToString() } // تاريخ ووقت التسجيل
                                    , new object[] { "@SalesInvoiceNumber", txt000.Text } // رقم فاتورة البيع
                                    , new object[] { "@ClientsNo", txt001.Text } // رقم العميل
                                    , new object[] { "@cash", txt003.Text } // كاش
                                    , new object[] { "@Bank", txt004.Text } // بنك
                                    , new object[] { "@BankCheck", txt005.Text } // شيك بنك
                                    , new object[] { "@DeferredPayment", txt006.Text } // آجل
                                    , new object[] { "@JournalEntryNo", "" } // رقم قيد اليومية
                                    , new object[] { "@ShiftNumber", ShiftNumber } // رقم الوردية
                   });

                    if (result[1] == "succeeded")
                    {
                        this.Close();
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("توجد مشكلة لم تسمح بإضافة سند القبض"), MessageBoxStatus.Ok);
                    }

                    this.Close();

                };

            }


        }

        DataTable TblClients = new DataTable();
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
                    TblClients = DataTools.DataBases.ReadTabel("select * from TblClients where ClientsNo = " + clientNo);
                }

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23 >> fillTblClients ", DateTime.Now, ex.Message, ex.Message);
            }
        }

    }


}

