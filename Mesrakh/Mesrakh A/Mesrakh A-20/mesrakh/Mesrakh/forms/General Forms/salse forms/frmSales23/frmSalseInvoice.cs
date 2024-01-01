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
    public partial class frmSalseInvoice : Form
    {
        public frmSalseInvoice()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmEncapsulationUnits13EventsAndProperties(Properties, Events); // النموذج
            pnlMainEventsAndProperties(Properties, Events); // الحاوية الرئيسية
            pnl001EventsAndProperties(Properties, Events); // الحاوية العلوية

            lblTitelEventsAndProperties(Properties, Events);   // ملصق عنوان النموذج 
            lbl001EventsAndProperties(Properties, Events);   // ملصق إجمالي الفاتورة 
            txt001EventsAndProperties(Properties, Events);   // إجمالي الفاتورة
            lbl002EventsAndProperties(Properties, Events);   // ملصق المبلغ المستحق 
            txt002EventsAndProperties(Properties, Events);   // المبلغ المستحق
            lbl003EventsAndProperties(Properties, Events);   // ملصق المبلغ المتبقي 
            txt003EventsAndProperties(Properties, Events);   // المبلغ المتبقي

            btn001EventsAndProperties(Properties, Events); // زر اضافة سلة مبيعات



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
                ElementsTools.Lable_.CustumProperties(lblTitel, "المبيعات", ColorPropertyName.BackColor_1);
                //lblTitel.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblTitel, "المبيعات", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                //lblTitel.BackColor = Color.Transparent;

            }
        }


        private void lbl001EventsAndProperties(bool Properties, bool Events = false) // ملصق إجمالي الفاتورة 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001, "إجمالي الفاتورة", ColorPropertyName.BackColor_1);
                lbl001.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001, "إجمالي الفاتورة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl001.BackColor = Color.Transparent;

            }
        }

        private void txt001EventsAndProperties(bool Properties, bool Events = false) // إجمالي الفاتورة
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true,TextBoxType.Decimal);
                txt001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        
                    }
                };
            }
        }

        private void lbl002EventsAndProperties(bool Properties, bool Events = false) // ملصق المبلغ المستحق 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl002, "المبلغ المستحق", ColorPropertyName.BackColor_1);
                lbl002.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl002, "المبلغ المستحق", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl002.BackColor = Color.Transparent;

            }
        }

        private void txt002EventsAndProperties(bool Properties, bool Events = false) // المبلغ المستحق
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt002, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt002, "", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Decimal);
                txt002.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {

                    }
                };
            }
        }

        private void lbl003EventsAndProperties(bool Properties, bool Events = false) // ملصق المبلغ المتبقي 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "المبلغ المتبقي", ColorPropertyName.BackColor_1);
                lbl003.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "المبلغ المتبقي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl003.BackColor = Color.Transparent;

            }
        }

        private void txt003EventsAndProperties(bool Properties, bool Events = false) // المبلغ المتبقي
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

                    }
                };
            }
        }

        public string SalesCartNo = "";// رقم سلة المشتريات
        public string ShiftNumber = ""; // رقم الوردية

        private void btn001EventsAndProperties(bool Properties, bool Events = false) // زر اضافة سلة مبيعات
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001, Cultures.ReturnTranslation("إصدار سند قبض"), ColorPropertyName.ForeColor_1);

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn001, Cultures.ReturnTranslation("إصدار سند قبض"), ColorPropertyName.ForeColor_1,true,true);

                btn001.Click += delegate
                {
                    DateTime dt = DateTime.Now;
                    string[] result = null;
                    object SalesInvoiceNumber = DataTools.DataBases.Run(ref result, "SpSalesBill",
                    CommandType.StoredProcedure,
                    new object[][] {
                                      new object[] { "@RegistrationDateAndTime", dt.ToString() } // تاريخ الفاتورة
                                    , new object[] { "@SalesCartNo", SalesCartNo } // رقم سلة المشتريات
                                    , new object[] { "@JournalEntryNo", "" } // رقم قيد اليومية
                                    , new object[] { "@ShiftNumber", ShiftNumber } // رقم الوردية
                                    , new object[] { "@TotalBill", txt001.Text } // مجموع الفاتورة
                                    , new object[] { "@DeservedAmount", txt002.Text } // المبلغ المستحق
                                    , new object[] { "@RemainingAmount", txt003.Text } // المبلغ المتبقي
                                    , new object[] { "@SalesInvoiceNumber", "OUT" } 
                    });

                    if (result[1] == "succeeded")
                    {
                        MessageBox.Show(SalesInvoiceNumber.ToString());

                        //int index = tc001.TabPages.Count;
                        //tc001.TabPages.Add(SalesCartNo.ToString());
                        //tc001.TabPages[index].AutoScroll = true;
                        //tabsNames.Add(SalesCartNo.ToString());
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("توجد مشكلة لم تسمح بإضافة سلة جديدة"), MessageBoxStatus.Ok);
                    }

                    this.Close();

                };

            }


        }

    }


}

