﻿using System;
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
        bool working = false; // عندما يتم العمل على اجراء حسابات يتم ايقاف بقية الحسابات الاخرى لكي لا تتكرر العمليات
        public frmSales23_B()
        {
            fillTblEnterprise(); // بيانات المنشأة

            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmEncapsulationUnits13EventsAndProperties(Properties, Events); // النموذج
            pnlMainEventsAndProperties(Properties, Events); // الحاوية الرئيسية
            pnl001EventsAndProperties(Properties, Events);  // الحاوية العلوية
            pnl004EventsAndProperties(Properties, Events);  // الحاوية العلوية الداخلية

            btnCloseEventsAndProperties(Properties, Events);  // زر اغلاق عربة التسوق 
            lbl001EventsAndProperties(Properties, Events);  // ملصق رقم عربة التسوق 
            lbl002EventsAndProperties(Properties, Events);  // ملصق تاريخ ووقت فتح عربة التسوق 
            btn001EventsAndProperties(Properties, Events);  // زر اضافة عميل
            btn002EventsAndProperties(Properties, Events);  // زر حذف عميل
            lbl003EventsAndProperties(Properties, Events); //  ملصق رقم العميل 
            lbl0033EventsAndProperties(Properties, Events);// ملصق اسم العميل 
            lbl004EventsAndProperties(Properties, Events); // ملصق مجموع سعر البيع 
            lbl0044EventsAndProperties(Properties, Events);// ملصق مجموع سعر البيع 
            lbl005EventsAndProperties(Properties, Events); // ملصق الخصم التجاري 
            lbl0055EventsAndProperties(Properties, Events);// ملصق الخصم التجاري 
            lbl006EventsAndProperties(Properties, Events); // ملصق سعر البيع بعد الخصم 
            lbl0066EventsAndProperties(Properties, Events);// ملصق سعر البيع بعد الخصم 
            lbl007EventsAndProperties(Properties, Events); // ملصق مجموع ضريبة المخرجات 
            lbl0077EventsAndProperties(Properties, Events);// ملصق مجموع ضريبة المخرجات 
            lbl008EventsAndProperties(Properties, Events); // ملصق سعر البيع شاملا الضريبة 
            lbl0088EventsAndProperties(Properties, Events);// ملصق سعر البيع شاملا الضريبة 
            pnl005EventsAndProperties(Properties, Events); //  الحاوية خاصة بعناصر اضافة ومنتجات والتعديل عليها
            txt001EventsAndProperties(Properties, Events); //  رقم الباركود
            cbx001EventsAndProperties(Properties, Events); //  قائمة منسدلة اسم الصنف
            lbl011EventsAndProperties(Properties, Events); // ملصق السعر 
            txt002EventsAndProperties(Properties, Events); //  مربع نص السعر
            lbl012EventsAndProperties(Properties, Events); // ملصق الكمية 
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
            btn003EventsAndProperties(Properties, Events); //   زر اضافة الصنف
            //btn004EventsAndProperties(Properties, Events); //  زر حذف الصنف
            pnl003EventsAndProperties(Properties, Events); // الحاوية الوسطية
            dgv001EventsAndProperties(Properties, Events); // جدول عرض تفاصيل سلة المبيعات
            pnl002EventsAndProperties(Properties, Events); // الحاوية السفلية

            // --------- إصدار الفاتورة
            pnl006EventsAndProperties(Properties, Events); // الحاوية الخاصة بعناصر الفاتورة
            btn004EventsAndProperties(Properties, Events); // زر اصدار فاتورة
            lbl0010EventsAndProperties(Properties, Events); // رقم الفاتورة
            lbl0011EventsAndProperties(Properties, Events); // تاريخ الفاتورة

            //-------
            fiilData();
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

                    lbl001.Text = this.Parent.Text; // رقم السلة

                    cbx001.SelectedIndex = -1; // الغاء تحديد الاصناف من القائمة المنسدلة

                    //lbl001.Font = new Font(lbl001.Parent.Font.Name, this.Parent.Font.Size + 10, FontStyle.Bold);

                    //-------------------------------  عند فتح سلة قديمة

                    // تعبئة جدول اجماليات السلة
                    fillTblSaleCarts();
                    if(TblSaleCarts != null)
                    {
                        if(TblSaleCarts.Rows.Count>0)
                        {
                            fiilData();
                        }
                    }
                    

                };
            }
        }

        private void fiilData()
        {
            if(TblSaleCarts != null )
            {
                if(TblSaleCarts.Rows.Count > 0)
                {
                    // تاريخ فتح السلة
                    lbl002.Text = TblSaleCarts.Rows[0][1].ToString();

                    // رقم العميل واسمه
                    lbl002.Text = TblSaleCarts.Rows[0][1].ToString(); // رقم العميل
                    lbl002.Text = TblSaleCarts.Rows[0][1].ToString(); // اسم العميل

                    // العميل
                    string[] clientData = GeneralAction.returnClientData(TblSaleCarts.Rows[0][7].ToString());
                    if (clientData[0] != null)
                    {
                        lbl003.Text = GeneralVariables.MessageBoxResult;
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            lbl0033.Text = clientData[0];
                        }
                        else
                        {
                            lbl0033.Text = clientData[1];
                        }
                    }

                    // سعر البيع
                    lbl0044.Text = TblSaleCarts.Rows[0][2].ToString();

                    // الخصم
                    lbl0055.Text = TblSaleCarts.Rows[0][3].ToString();

                    // سعر البيع بعد الخصم
                    lbl0066.Text = TblSaleCarts.Rows[0][4].ToString();

                    // مبلغ الضريبة 
                    lbl0077.Text = TblSaleCarts.Rows[0][5].ToString();

                    // سعر البيع شاملاً الضريبة
                    lbl0088.Text = TblSaleCarts.Rows[0][6].ToString();

                    // تعبئة جدول تفاصيل السلة
                    fillTblSalesCartDetails();
                    if (dgv001.DataSource == null)
                    {
                        dgv001.DataSource = TblSalesCartDetails;
                    }
                    dgv001EventsAndProperties(true);
                }


                // رقم وتاريخ الفاتورة
                if (this.Parent != null)
                {
                    // تعبئة رقم الفاتورة وتاريخها
                    fillTblSalesBill(this.Parent.Text);
                }
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

        private void btnCloseEventsAndProperties(bool Properties, bool Events = false) // زر  اغلاق عربة التسوق
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btnClose.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCloseProduct);
                        btnClose.BackgroundImageLayout = ImageLayout.Stretch;

                    }
                    else
                    {
                        btnClose.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCloseProduct);
                        btnClose.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //pic001.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  btnCloseEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btnClose.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCloseProduct);
                        btnClose.BackgroundImageLayout = ImageLayout.Stretch;

                    }
                    else
                    {
                        btnClose.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCloseProduct);
                        btnClose.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //pic001.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  btnCloseEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                btnClose.Click += delegate
                {
                    //MessageBox.Show();
                    //int index = (this.Parent.Parent as TabControl).TabPages.IndexOf((this.Parent.Parent as TabControl).SelectedTab);
                    (this.Parent.Parent as TabControl).TabPages.Remove((this.Parent.Parent as TabControl).SelectedTab);
                };

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

        private void btn001EventsAndProperties(bool Properties, bool Events = false) // زر اضافة عميل
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn001.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddCustomer);
                        btn001.BackgroundImageLayout = ImageLayout.Stretch;

                    }
                    else
                    {
                        btn001.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddCustomer);
                        btn001.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //pic001.BorderStyle = BorderStyle.None;
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
                        btn001.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddCustomer);
                        btn001.BackgroundImageLayout = ImageLayout.Stretch;

                    }
                    else
                    {
                        btn001.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddCustomer);
                        btn001.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //pic001.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  pic001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                btn001.Click += delegate
                {

                    if (lbl0010.Text.Trim() != "")
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("لا يمكن التعديل على فاتورة تم حفظها سابقاً"), MessageBoxStatus.Ok);
                        return;
                    }

                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("إضافة عميل"), Cultures.ReturnTranslation("رجاء قم بتسجيل رقم العميل"), MessageBoxStatus.Text);

                    if(GeneralVariables.MessageBoxResult.Trim().Replace("'","") != "")
                    {
                        string[] clientData = GeneralAction.returnClientData(GeneralVariables.MessageBoxResult);

                        if (clientData[0] == null)
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا يوجد عميل بهذه البيانات"), MessageBoxStatus.Ok);
                            return;
                        }

                        string[] result = null;
                        object OUT_SalesCartDetailsNo = DataTools.DataBases.Run(ref result, "update TblSaleCarts set ClientsNo = @ClientsNo where SalesCartNo = SalesCartNo",
                         CommandType.Text, new object[][] {
                                      new object[] { "@SalesCartNo", lbl001.Text } // رقم سلة المبيعات
                                      , new object[] { "@ClientsNo", GeneralVariables.MessageBoxResult } // رقم العميل
                         });


                        
                        if (result[1] == "succeeded")
                        {

                            lbl003.Text = GeneralVariables.MessageBoxResult;
                            if (GeneralVariables.cultureCode == "AR")
                            {
                                lbl0033.Text = clientData[0];
                            }
                            else
                            {
                                lbl0033.Text = clientData[1];
                            }

                        }

                    }

                };

            }
        }

        private void btn002EventsAndProperties(bool Properties, bool Events = false) // زر حذف عميل
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn002.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDeleteCustomer);
                        btn002.BackgroundImageLayout = ImageLayout.Stretch;

                    }
                    else
                    {
                        btn002.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDeleteCustomer);
                        btn002.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //pic002.BorderStyle = BorderStyle.None;
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
                        btn002.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDeleteCustomer);
                        btn002.BackgroundImageLayout = ImageLayout.Stretch;

                    }
                    else
                    {
                        btn002.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDeleteCustomer);
                        btn002.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //pic002.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  pic002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                btn002.Click += delegate
                {
                    if (lbl0010.Text.Trim() != "")
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("لا يمكن التعديل على فاتورة تم حفظها سابقاً"), MessageBoxStatus.Ok);
                        return;
                    }

                    string[] result = null;
                    object OUT_SalesCartDetailsNo = DataTools.DataBases.Run(ref result, "update TblSaleCarts set ClientsNo = Null where SalesCartNo = SalesCartNo",
                     CommandType.Text, new object[][] {
                                      new object[] { "@SalesCartNo", lbl001.Text } // رقم سلة المبيعات
                     });

                    if (result[1] == "succeeded")
                    {
                        lbl003.Text = "";
                        lbl0033.Text = "";
                        //TblClients = null;
                    }

                };

            }
        }


        private void lbl003EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم العميل
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "");
                lbl003.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
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
                ElementsTools.Lable_.CustumProperties(lbl0044, "0", ColorPropertyName.BackColor_5);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl0044, "0", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
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
                ElementsTools.Lable_.CustumProperties(lbl0055, "0", ColorPropertyName.BackColor_5);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl0055, "0", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
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
                ElementsTools.Lable_.CustumProperties(lbl0066, "0", ColorPropertyName.BackColor_5);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl0066, "0", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
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
                ElementsTools.Lable_.CustumProperties(lbl0077, "0", ColorPropertyName.BackColor_5);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl0077, "0", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
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
                ElementsTools.Lable_.CustumProperties(lbl0088, "0", ColorPropertyName.BackColor_5);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl0088, "0", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_1, true, true);
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
                    if (lbl0010.Text.Trim() != "")
                    {
                        txt001.Text = "";
                        return;
                    }

                    if (mye.KeyData == Keys.Enter)
                    {
                        fillTblBarcode();
                        if(TblBarcode != null)
                        {
                            if(TblBarcode.Rows.Count>0)
                            {
                                cbx001.SelectedValue = TblBarcode.Rows[0][1];
                                btn003.PerformClick(); // ؟؟؟؟؟
                            }
                        }

                        
                    }
                };
            }
        }


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
                    if (lbl0010.Text.Trim() != "")
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("لا يمكن التعديل على فاتورة تم حفظها سابقاً"), MessageBoxStatus.Ok);
                        return;
                    }

                    if (mye.KeyData == Keys.Enter)
                    {
                        txt002.Select();
                    }
                };

                cbx001.SelectedIndexChanged += delegate
                {
                    if (lbl0010.Text.Trim() != "")
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("لا يمكن التعديل على فاتورة تم حفظها سابقاً"), MessageBoxStatus.Ok);
                        return;
                    }

                    working = true; 

                    txt001.Text = "";
                    txt002.Text = "0";
                    txt003.Text = "1";
                    txt004.Text = "0";
                    txt005.Text = "0";
                    if (TblEnterprise != null) { if (TblEnterprise.Rows.Count>0) { txt006.Text = TblEnterprise.Rows[0][5].ToString(); } };
                    txt007.Text = "0";
                    txt008.Text = "0";
                    txt009.Text = "0";

                    

                    if (cbx001.SelectedIndex > -1)
                    {
                        if (cbx001.SelectedValue.ToString().Trim() != "")
                        {
                            if (cbx001.SelectedValue == null) return;
                            float[] result =  FillAndCalculate(cbx001.SelectedValue.ToString().Trim(), txt003.Text, txt005.Text, txt006.Text);
                            working = true;
                            txt003.Text = result[0].ToString(); //  الكمية
                            txt008.Text = result[1].ToString(); //  الكمية المجانية
                            txt002.Text = result[2].ToString(); // سعر بيع الوحدة
                            //txt002.Text = result[3].ToString(); // مجموع سعر البيع
                            txt005.Text = result[4].ToString(); //  الخصم التجاري
                            //txt002.Text = result[5].ToString(); // مجموع سعر البيع بعد الخصم التجاري
                            txt006.Text = result[6].ToString();// نسبة ضريبة القيمة المضافة
                            txt007.Text = result[7].ToString(); //  ضريبة المخرجات
                            txt009.Text = result[8].ToString(); // الاجمالي
                            working = false;
                        }
                    }

                    working = false;


                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UnitDetailsNo">رقم المنتج التفصلي</param>
        /// <param name="quantity">كمية المنتج</param>
        /// <param name="discount">الخصم التجاري</param>
        /// <param name="vaTrate">نسبة الضريبة</param>
        private float[] FillAndCalculate(string UnitDetailsNo , string quantity , string discount , string vaTrate)
        {
            float[] result = new float[9];
            //---------------------
            float Quantity = float.Parse(quantity.Trim()!=""? quantity:"0"); //  الكمية
            float FreeQuantity = float.Parse(FreeUnitsOffers(UnitDetailsNo , quantity.Trim() != "" ? quantity : "0")); //  الكمية المجانية
            float UnitSalePrice = float.Parse(price(UnitDetailsNo , quantity.Trim() != "" ? quantity : "0")); // سعر بيع الوحدة
            float TotalSalePrice = UnitSalePrice * Quantity; // مجموع سعر البيع
            float Discount = float.Parse(discount.Trim() != "" ? discount : "0"); //  الخصم التجاري
            float TotalSalePriceAfterDiscount = TotalSalePrice - Discount; // مجموع سعر البيع بعد الخصم التجاري
            float VATrate = float.Parse(vaTrate.Trim() != "" ? vaTrate : "0");// نسبة ضريبة القيمة المضافة
            float OutputTax = (VATrate / 100) * TotalSalePriceAfterDiscount; //  ضريبة المخرجات
            float TotalSellingPriceIncludingTax = TotalSalePriceAfterDiscount + OutputTax; // الاجمالي
            //---------------------
            result[0] = Quantity ; //  الكمية
            result[1] = FreeQuantity ; //  الكمية المجانية
            result[2] = UnitSalePrice ; // سعر بيع الوحدة
            result[3] = TotalSalePrice ; // مجموع سعر البيع
            result[4] = Discount ; //  الخصم التجاري
            result[5] = TotalSalePriceAfterDiscount ; // مجموع سعر البيع بعد الخصم التجاري
            result[6] = VATrate ;// نسبة ضريبة القيمة المضافة
            result[7] = OutputTax ; //  ضريبة المخرجات
            result[8] = TotalSellingPriceIncludingTax; // الاجمالي

            return result;
        }
        // حساب السعر
        private string price(string UnitDetailsNo , string qty)
        {
            fillTblPriceCategories(UnitDetailsNo); // تعبئة جدول فئات الاسعار بناء على اسم المنتج التفصيلي 

            string result = "0";
            if(qty.Trim().Replace("'","") != "" && char.IsDigit(qty[0]))
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
        private string FreeUnitsOffers(string UnitDetailsNo,  string qty)
        {


            if(!string.IsNullOrEmpty(UnitDetailsNo))
            {
                fillTblFreeUnitsOffers(UnitDetailsNo); // تعبئة جدول عروض الوحدات المجانية بناء على اسم المنتج التفصيلي

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
            return "0";
        }

        //// حساب المجموع الفرعي
        //private string subTotal()
        //{
        //    string result = "0";
        //    if(txt002.Text.Trim().Replace("'","") != "" && char.IsDigit(txt002.Text[0]) && txt003.Text.Trim().Replace("'", "") != "" && char.IsDigit(txt003.Text[0]) && txt005.Text.Trim().Replace("'", "") != "" && char.IsDigit(txt005.Text[0]) && txt007.Text.Trim().Replace("'", "") != "" && char.IsDigit(txt007.Text[0]))
        //    {
        //        result = Convert.ToString((float.Parse(txt002.Text) * float.Parse(txt003.Text)) - float.Parse(txt005.Text) + float.Parse(txt007.Text));
        //    }
        //    return result;
        //}


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
                //txt002.KeyDown += delegate (object mysender, KeyEventArgs mye)
                //{
                //    if (mye.KeyData == Keys.Enter)
                //    {
                //        txt003.Select();
                //    }
                //};
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
                //txt003.KeyDown += delegate (object mysender, KeyEventArgs mye)
                //{
                //    if (mye.KeyData == Keys.Enter)
                //    {
                //        txt004.Select();
                //    }
                //};

                txt003.TextChanged += delegate
                {
                    if(!working)
                    {
                        working = true;
                        if (cbx001.SelectedValue == null) return;
                        float[] result = FillAndCalculate(cbx001.SelectedValue.ToString().Trim(), txt003.Text, txt005.Text, txt006.Text);

                        txt003.Text = result[0].ToString(); //  الكمية
                        txt008.Text = result[1].ToString(); //  الكمية المجانية
                        txt002.Text = result[2].ToString(); // سعر بيع الوحدة
                                                            //txt002.Text = result[3].ToString(); // مجموع سعر البيع
                        txt005.Text = result[4].ToString(); //  الخصم التجاري
                                                            //txt002.Text = result[5].ToString(); // مجموع سعر البيع بعد الخصم التجاري
                        txt006.Text = result[6].ToString();// نسبة ضريبة القيمة المضافة
                        txt007.Text = result[7].ToString(); //  ضريبة المخرجات
                        txt009.Text = result[8].ToString(); // الاجمالي
                        working = false;
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
                //txt004.KeyDown += delegate (object mysender, KeyEventArgs mye)
                //{
                //    if (mye.KeyData == Keys.Enter)
                //    {
                //        txt005.Select();
                //    }
                //};

                txt004.TextChanged += delegate
                {
                        if (txt002.Text.Trim().Replace("'", "") != "" && txt003.Text.Trim().Replace("'", "") != "" && txt004.Text.Trim().Replace("'", "") != "")
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
                //txt005.KeyDown += delegate (object mysender, KeyEventArgs mye)
                //{
                //    if (mye.KeyData == Keys.Enter)
                //    {
                //        pic003.Select();
                //    }
                //};

                txt005.TextChanged += delegate
                {
                    if (!working)
                    {
                        working = true;

                        if (cbx001.SelectedValue == null) return;
                        float[] result = FillAndCalculate(cbx001.SelectedValue.ToString().Trim(), txt003.Text, txt005.Text, txt006.Text);

                        txt003.Text = result[0].ToString(); //  الكمية
                        txt008.Text = result[1].ToString(); //  الكمية المجانية
                        txt002.Text = result[2].ToString(); // سعر بيع الوحدة
                                                            //txt002.Text = result[3].ToString(); // مجموع سعر البيع
                        txt005.Text = result[4].ToString(); //  الخصم التجاري
                                                            //txt002.Text = result[5].ToString(); // مجموع سعر البيع بعد الخصم التجاري
                        txt006.Text = result[6].ToString();// نسبة ضريبة القيمة المضافة
                        txt007.Text = result[7].ToString(); //  ضريبة المخرجات
                        txt009.Text = result[8].ToString(); // الاجمالي

                        working = false;
                    }
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
                if (TblEnterprise != null) { if (TblEnterprise.Rows.Count > 0) { txt006.Text = TblEnterprise.Rows[0][5].ToString(); } };


            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt006, "", 6, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                if (TblEnterprise != null) { if (TblEnterprise.Rows.Count > 0) { txt006.Text = TblEnterprise.Rows[0][5].ToString(); } };

                //txt006.KeyDown += delegate (object mysender, KeyEventArgs mye)
                //{
                //    if (mye.KeyData == Keys.Enter)
                //    {
                //        //pic003.Select();
                //    }
                //};

                txt006.TextChanged += delegate
                {
                        if (txt002.Text.Trim().Replace("'", "") != "" && char.IsDigit(txt002.Text[0]) && txt003.Text.Trim().Replace("'", "") != "" && char.IsDigit(txt002.Text[0]) && txt005.Text.Trim().Replace("'", "") != "" && char.IsDigit(txt002.Text[0]) && txt006.Text.Trim().Replace("'", "") != "" && char.IsDigit(txt006.Text[0]))
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
                //txt007.KeyDown += delegate (object mysender, KeyEventArgs mye)
                //{
                //    if (mye.KeyData == Keys.Enter)
                //    {
                //        //pic003.Select();
                //    }
                //};

                txt007.TextChanged += delegate
                {
                    if (!working)
                    {
                        working = true;

                        if (cbx001.SelectedValue == null) return;
                        float[] result = FillAndCalculate(cbx001.SelectedValue.ToString().Trim(), txt003.Text, txt005.Text, txt006.Text);

                        txt003.Text = result[0].ToString(); //  الكمية
                        txt008.Text = result[1].ToString(); //  الكمية المجانية
                        txt002.Text = result[2].ToString(); // سعر بيع الوحدة
                                                            //txt002.Text = result[3].ToString(); // مجموع سعر البيع
                        txt005.Text = result[4].ToString(); //  الخصم التجاري
                                                            //txt002.Text = result[5].ToString(); // مجموع سعر البيع بعد الخصم التجاري
                        txt006.Text = result[6].ToString();// نسبة ضريبة القيمة المضافة
                        txt007.Text = result[7].ToString(); //  ضريبة المخرجات
                        txt009.Text = result[8].ToString(); // الاجمالي

                        working = false;
                    }
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
                //txt008.KeyDown += delegate (object mysender, KeyEventArgs mye)
                //{
                //    if (mye.KeyData == Keys.Enter)
                //    {
                //        //pic003.Select();
                //    }
                //};
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
        private void btn003EventsAndProperties(bool Properties, bool Events = false) // زر اضافة الصنف
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn003.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddProduct);
                        btn003.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        btn003.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddProduct);
                        btn003.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //pic003.BorderStyle = BorderStyle.None;
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
                        btn003.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddProduct);
                        btn003.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        btn003.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAddProduct);
                        btn003.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //pic003.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  pic003EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                btn003.Click += delegate
                {
                    if (lbl0010.Text.Trim() != "")
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("لا يمكن التعديل على فاتورة تم حفظها سابقاً"), MessageBoxStatus.Ok);
                        return;
                    }

                    if (cbx001.SelectedValue == null )
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لم تقم بتحديد الصنف") , MessageBoxStatus.Ok);
                        return; 
                    }
                    bool? SameSalesCartDetailsNo = ElementsTools.DataGridView_.findValueThenSelected(dgv001, ActionType.add, cbx001.SelectedValue.ToString(), 2);
                    

                    if(SameSalesCartDetailsNo != true)
                    {
                        string[] result = null;
                        object OUT_SalesCartDetailsNo = DataTools.DataBases.Run(ref result, "SpSalesCartDetails",
                         CommandType.StoredProcedure, new object[][] {
                                      new object[] { "@SalesCartNo", lbl001.Text.Replace("'","") } // رقم سلة المبيعات
                                    , new object[] { "@UnitDetailsNo", cbx001.SelectedValue } // رقم تفصيل الوحدة
                                    , new object[] { "@ShortArabicName", TblproductAndServicesDetails.Rows[cbx001.SelectedIndex][12].ToString() } // الاسم العربي المختصر
                                    , new object[] { "@ShortEnglishName", TblproductAndServicesDetails.Rows[cbx001.SelectedIndex][13].ToString() } // الاسم الانجليزي المختصر
                                    , new object[] { "@UnitSalePrice", txt002.Text.Replace("'", "") } // سعر بيع الوحدة
                                    , new object[] { "@Quantity", txt003.Text.Replace("'","") } //  الكمية  
                                    , new object[] { "@FreeQuantity", txt008.Text.Replace("'","") } //  الكمية المجانية
                                    , new object[] { "@TotalSalePrice", (float.Parse(txt002.Text.Replace("'", "")) * float.Parse(txt003.Text.Replace("'", ""))) } // مجموع سعر البيع
                                    , new object[] { "@Discount", txt005.Text.Replace("'", "") } //  الخصم التجاري
                                    , new object[] { "@TotalSalePriceAfterDiscount", ((float.Parse(txt002.Text.Replace("'", "")) * float.Parse(txt003.Text.Replace("'", ""))) - float.Parse(txt005.Text.Replace("'", ""))) } // مجموع سعر البيع بعد الخصم التجاري
                                    , new object[] { "@VATrate", txt006.Text.Replace("'", "") } // نسبة ضريبة القيمة المضافة
                                    , new object[] { "@OutputTax", txt007.Text.Replace("'","")} // ضريبة المخرجات
                                    , new object[] { "@TotalSellingPriceIncludingTax", txt009.Text.Replace("'", "") } // مجموع سعر البيع شاملا الضريبة
                                    , new object[] { "@SalesCartDetailsNo", "OUT" } //  رقم تفصيل سلة المبيعات
                         });

                        if (result[1] == "succeeded")
                        {

                            fillTblSalesCartDetails();
                            if (dgv001.DataSource == null)
                            {
                                dgv001.DataSource = TblSalesCartDetails;
                            }
                            dgv001EventsAndProperties(true);

                        }
                    }
                    else
                    {


                        string SalesCartDetailsNo = dgv001.SelectedRows[0].Cells[0].Value.ToString(); // رقم السجل الفرعي الذي تمت الاضافة عليه
                        txt003.Text = (float.Parse(txt003.Text.Replace("'", "")) + float.Parse(dgv001.SelectedRows[0].Cells[6].Value.ToString())).ToString(); // زيادة الكمية

                        string[] result = null;
                        object OUT_SalesCartDetailsNo = DataTools.DataBases.Run(ref result, "SpSalesCartDetailsEdit",
                         CommandType.StoredProcedure, new object[][] {
                                      new object[] { "@SalesCartDetailsNo", SalesCartDetailsNo } // رقم تفصيل سلة المبيعات
                                    , new object[] { "@UnitSalePrice", txt002.Text.Replace("'", "") } // سعر بيع الوحدة
                                    , new object[] { "@Quantity", txt003.Text.Replace("'", "") } //  الكمية
                                    , new object[] { "@FreeQuantity", txt008.Text.Replace("'","") } //  الكمية المجانية
                                    , new object[] { "@TotalSalePrice", (float.Parse(txt002.Text.Replace("'", "")) * float.Parse(txt003.Text.Replace("'", ""))) } // مجموع سعر البيع
                                    , new object[] { "@Discount", txt005.Text.Replace("'", "") } //  الخصم التجاري
                                    , new object[] { "@TotalSalePriceAfterDiscount", ((float.Parse(txt002.Text.Replace("'", "")) * float.Parse(txt003.Text.Replace("'", ""))) - float.Parse(txt005.Text.Replace("'", ""))) } // مجموع سعر البيع بعد الخصم التجاري
                                    , new object[] { "@VATrate", txt006.Text.Replace("'", "") } // نسبة ضريبة القيمة المضافة
                                    , new object[] { "@OutputTax", txt007.Text.Replace("'","")} // ضريبة المخرجات
                                    , new object[] { "@TotalSellingPriceIncludingTax", txt009.Text.Replace("'", "") } // مجموع سعر البيع شاملا الضريبة

                         });

                        if (result[1] == "succeeded")
                        {

                            fillTblSalesCartDetails();
                            if (dgv001.DataSource == null)
                            {
                                dgv001.DataSource = TblSalesCartDetails;
                            }
                            dgv001EventsAndProperties(true);

                        }
                    }

                    // الاجمالي
                    {

                        decimal TotalSalePrice = 0;  //مجموع سعر البيع
                        decimal TotalDiscount = 0;   // مجموع الخصم التجاري
                        decimal TotalOutputTax = 0;   // مجموع ضريبة المخرجات

                        foreach (DataGridViewRow row in dgv001.Rows)
                        {
                            TotalSalePrice += decimal.Parse(row.Cells[8].Value.ToString());
                            TotalDiscount += decimal.Parse(row.Cells[9].Value.ToString());
                            TotalOutputTax += decimal.Parse(row.Cells[12].Value.ToString());
                        }

                        decimal TotalSalePriceAfterDiscount = TotalSalePrice - TotalDiscount ;   // مجموع سعر البيع بعد الخصم التجاري
                        decimal TotalSellingPriceIncludingTax = TotalSalePriceAfterDiscount + TotalOutputTax ;   // مجموع سعر البيع شاملا الضريبة

                        string[] result = null;
                        object OUT_SalesCartDetailsNo = DataTools.DataBases.Run(ref result, "update TblSaleCarts set TotalSalePrice = @TotalSalePrice , TotalDiscount = @TotalDiscount , TotalOutputTax = @TotalOutputTax , TotalSalePriceAfterDiscount = @TotalSalePriceAfterDiscount , TotalSellingPriceIncludingTax = @TotalSellingPriceIncludingTax where SalesCartNo = @SalesCartNo",
                         CommandType.Text, new object[][] {
                                      new object[] { "@TotalSalePrice", TotalSalePrice } // 
                                    , new object[] { "@TotalDiscount", TotalDiscount } // 
                                    , new object[] { "@TotalOutputTax", TotalOutputTax } //  
                                    , new object[] { "@TotalSalePriceAfterDiscount", TotalSalePriceAfterDiscount } // 
                                    , new object[] { "@TotalSellingPriceIncludingTax", TotalSellingPriceIncludingTax } // 
                                    , new object[] { "@SalesCartNo", lbl001.Text } //

                         });

                        if (result[1] == "succeeded")
                        {

                            fillTblSaleCarts();

                            if(TblSaleCarts != null)
                            {
                                if(TblSaleCarts.Rows.Count > 0)
                                {
                                    lbl0044.Text = TblSaleCarts.Rows[0][2].ToString();//مجموع سعر البيع
                                    lbl0055.Text = TblSaleCarts.Rows[0][3].ToString();//مجموع الخصم التجاري
                                    lbl0066.Text = TblSaleCarts.Rows[0][4].ToString();//مجموع سعر البيع بعد الخصم التجاري
                                    lbl0077.Text = TblSaleCarts.Rows[0][5].ToString();//مجموع ضريبة المخرجات
                                    lbl0088.Text = TblSaleCarts.Rows[0][6].ToString();//مجموع سعر البيع شاملا الضريبة
                                }
                            }


                        }
                    }



                    {

                        //-----------
                        working = true;
                        cbx001.SelectedIndex = -1;


                        txt001.Text = "";
                        txt002.Text = "0";
                        txt003.Text = "1";
                        txt004.Text = "0";
                        txt005.Text = "0";
                        if (TblEnterprise != null) { if (TblEnterprise.Rows.Count > 0) { txt006.Text = TblEnterprise.Rows[0][5].ToString(); } }; // نسبة الضريبة
                        txt007.Text = "0";
                        txt008.Text = "0";
                        txt009.Text = "0";

                        working = false;
                    }



                    txt001.Focus();
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

                            dgv001.Columns[0].Visible = false;
                            dgv001.Columns[1].Visible = false;
                            dgv001.Columns[2].HeaderText = Cultures.ReturnTranslation("رقم الصنف");
                            dgv001.Columns[3].HeaderText = Cultures.ReturnTranslation("الإسم العربي");
                            dgv001.Columns[4].HeaderText = Cultures.ReturnTranslation("الإسم الإنجليزي");
                            dgv001.Columns[5].HeaderText = Cultures.ReturnTranslation("السعر");
                            dgv001.Columns[6].HeaderText = Cultures.ReturnTranslation("الكمية");
                            dgv001.Columns[7].HeaderText = Cultures.ReturnTranslation("الكمية المجانية");
                            dgv001.Columns[8].HeaderText = Cultures.ReturnTranslation("مجموع سعر البيع");
                            dgv001.Columns[9].HeaderText = Cultures.ReturnTranslation("الخصم التجاري");
                            dgv001.Columns[10].HeaderText = Cultures.ReturnTranslation("سعر البيع بعد الخصم");
                            dgv001.Columns[11].HeaderText = Cultures.ReturnTranslation("نسبة ضريبة");
                            dgv001.Columns[12].HeaderText = Cultures.ReturnTranslation("ضريبة المخرجات");
                            dgv001.Columns[13].HeaderText = Cultures.ReturnTranslation("المجموع الفرعي");

                            //dgv001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            //dgv001.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dgv001.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dgv001.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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

                            dgv001.Columns[0].Visible = false;
                            dgv001.Columns[1].Visible = false;
                            dgv001.Columns[2].HeaderText = Cultures.ReturnTranslation("رقم الصنف");
                            dgv001.Columns[3].HeaderText = Cultures.ReturnTranslation("الإسم العربي");
                            dgv001.Columns[4].HeaderText = Cultures.ReturnTranslation("الإسم الإنجليزي");
                            dgv001.Columns[5].HeaderText = Cultures.ReturnTranslation("السعر");
                            dgv001.Columns[6].HeaderText = Cultures.ReturnTranslation("الكمية");
                            dgv001.Columns[7].HeaderText = Cultures.ReturnTranslation("الكمية المجانية");
                            dgv001.Columns[8].HeaderText = Cultures.ReturnTranslation("مجموع سعر البيع");
                            dgv001.Columns[9].HeaderText = Cultures.ReturnTranslation("الخصم التجاري");
                            dgv001.Columns[10].HeaderText = Cultures.ReturnTranslation("سعر البيع بعد الخصم");
                            dgv001.Columns[11].HeaderText = Cultures.ReturnTranslation("نسبة ضريبة");
                            dgv001.Columns[12].HeaderText = Cultures.ReturnTranslation("ضريبة المخرجات");
                            dgv001.Columns[13].HeaderText = Cultures.ReturnTranslation("المجموع الفرعي");

                            //dgv001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            //dgv001.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dgv001.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dgv001.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgv001.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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

                            SelectedRowIndex = dgv001.SelectedRows[0].Index;

                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmSales23 >> dgv001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                    }
                };



                dgv001.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (lbl0010.Text.Trim() != "")
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("لا يمكن التعديل على فاتورة تم حفظها سابقاً"), MessageBoxStatus.Ok);
                        return;
                    }

                    try
                    {
                        if (e.KeyData == Keys.F12)// تعديل الكمية
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تعديل الكمية"), Cultures.ReturnTranslation("رجاء قم بتسجيل الكمية"), MessageBoxStatus.Number);
                            dgv001.CurrentRow.Cells[6].Value = GeneralVariables.MessageBoxResult != "" ? (float.Parse(GeneralVariables.MessageBoxResult)) : 0 ;
                        }
                        else if (e.KeyData == Keys.F11)//تعديل مبلغ الخصم
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تعديل مبلغ الخصم"), Cultures.ReturnTranslation("رجاء قم بتسجيل مبلغ الخصم"), MessageBoxStatus.Number);
                            dgv001.CurrentRow.Cells[9].Value = GeneralVariables.MessageBoxResult != "" ? (float.Parse(GeneralVariables.MessageBoxResult)) : 0;
                        }
                        else if (e.KeyData == Keys.F10)//تعديل نسبة الضريبة
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تعديل نسبة الضريبة"), Cultures.ReturnTranslation("رجاء قم بتسجيل نسبة الضريبة"), MessageBoxStatus.Number);
                            dgv001.CurrentRow.Cells[11].Value = GeneralVariables.MessageBoxResult != "" ? (float.Parse(GeneralVariables.MessageBoxResult)) : 0;
                        }

                        if(e.KeyData == Keys.F10  || e.KeyData == Keys.F11  || e.KeyData == Keys.F12)
                        {
                            string SalesCartDetailsNo = dgv001.CurrentRow.Cells[0].Value.ToString(); // رقم السجل الفرعي الذي تم التعديل عليه  
                            UpdateDataGridView(SalesCartDetailsNo, dgv001.CurrentRow.Cells[2].Value.ToString(), dgv001.CurrentRow.Cells[6].Value.ToString(), dgv001.CurrentRow.Cells[9].Value.ToString(), dgv001.CurrentRow.Cells[11].Value.ToString());
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="SalesCartDetailsNo">رقم تفصيل سلة الاصناف</param>
        /// <param name="UnitDetailsNo">رقم المنتج التفصلي</param>
        /// <param name="quantity">كمية المنتج</param>
        /// <param name="discount">الخصم التجاري</param>
        /// <param name="vaTrate">نسبة الضريبة</param>
        private void UpdateDataGridView(string SalesCartDetailsNo , string UnitDetailsNo, string quantity, string discount, string vaTrate)
        {
            try
            {

                {
                    

                    float[] res = FillAndCalculate(UnitDetailsNo, quantity, discount, vaTrate);

                    float Quantity = res[0]; //  الكمية
                    float FreeQuantity = res[1]; //  الكمية المجانية
                    float UnitSalePrice = res[2]; // سعر بيع الوحدة
                    float TotalSalePrice = res[3]; // مجموع سعر البيع
                    float Discount = res[4]; //  الخصم التجاري
                    float TotalSalePriceAfterDiscount = res[5]; // مجموع سعر البيع بعد الخصم التجاري
                    float VATrate = res[6];// نسبة ضريبة القيمة المضافة
                    float OutputTax = res[7]; //  ضريبة المخرجات
                    float TotalSellingPriceIncludingTax = res[8]; // الاجمالي


                    if (Quantity > 0)
                    {
                        string[] result = null;
                        object OUT_SalesCartDetailsNo = DataTools.DataBases.Run(ref result, "SpSalesCartDetailsEdit",
                         CommandType.StoredProcedure, new object[][] {
                                      new object[] { "@SalesCartDetailsNo", SalesCartDetailsNo } // رقم تفصيل سلة المبيعات
                                    , new object[] { "@UnitSalePrice", UnitSalePrice } // سعر بيع الوحدة
                                    , new object[] { "@Quantity", Quantity } //  الكمية
                                    , new object[] { "@FreeQuantity", FreeQuantity } //  الكمية المجانية
                                    , new object[] { "@TotalSalePrice", TotalSalePrice } // مجموع سعر البيع
                                    , new object[] { "@Discount", Discount } //  الخصم التجاري
                                    , new object[] { "@TotalSalePriceAfterDiscount", TotalSalePriceAfterDiscount } // مجموع سعر البيع بعد الخصم التجاري
                                    , new object[] { "@VATrate", VATrate } // نسبة ضريبة القيمة المضافة
                                    , new object[] { "@OutputTax", OutputTax  } // ضريبة المخرجات
                                    , new object[] { "@TotalSellingPriceIncludingTax", TotalSellingPriceIncludingTax  } // مجموع سعر البيع شاملا الضريبة

                         });

                        if (result[1] == "succeeded")
                        {

                            fillTblSalesCartDetails();
                            if (dgv001.DataSource == null)
                            {
                                dgv001.DataSource = TblSalesCartDetails;
                            }
                            dgv001EventsAndProperties(true);

                        }
                    }
                    else
                    {
                        string[] result = null;
                        DataTools.DataBases.Run(ref result, "delete from TblSalesCartDetails where SalesCartDetailsNo = @SalesCartDetailsNo ",
                        CommandType.Text, new object[][] {
                                      new object[] { "@SalesCartDetailsNo", SalesCartDetailsNo } // رقم تفصيل سلة المبيعات
                        });

                        if (result[1] == "succeeded")
                        {

                            fillTblSalesCartDetails();
                            if (dgv001.DataSource == null)
                            {
                                dgv001.DataSource = TblSalesCartDetails;
                            }
                            dgv001EventsAndProperties(true);
                            txt001.Focus();
                        }
                    }

                }

                // الاجمالي
                {

                    decimal TotalSalePrice = 0;  //مجموع سعر البيع
                    decimal TotalDiscount = 0;   // مجموع الخصم التجاري
                    decimal TotalOutputTax = 0;   // مجموع ضريبة المخرجات

                    foreach (DataGridViewRow row in dgv001.Rows)
                    {
                        TotalSalePrice += decimal.Parse(row.Cells[8].Value.ToString());
                        TotalDiscount += decimal.Parse(row.Cells[9].Value.ToString());
                        TotalOutputTax += decimal.Parse(row.Cells[12].Value.ToString());
                    }

                    decimal TotalSalePriceAfterDiscount = TotalSalePrice - TotalDiscount;   // مجموع سعر البيع بعد الخصم التجاري
                    decimal TotalSellingPriceIncludingTax = TotalSalePriceAfterDiscount + TotalOutputTax;   // مجموع سعر البيع شاملا الضريبة

                    string[] result = null;
                    object OUT_SalesCartDetailsNo = DataTools.DataBases.Run(ref result, "update TblSaleCarts set TotalSalePrice = @TotalSalePrice , TotalDiscount = @TotalDiscount , TotalOutputTax = @TotalOutputTax , TotalSalePriceAfterDiscount = @TotalSalePriceAfterDiscount , TotalSellingPriceIncludingTax = @TotalSellingPriceIncludingTax where SalesCartNo = @SalesCartNo",
                     CommandType.Text, new object[][] {
                                      new object[] { "@TotalSalePrice", TotalSalePrice } // 
                                    , new object[] { "@TotalDiscount", TotalDiscount } // 
                                    , new object[] { "@TotalOutputTax", TotalOutputTax } //  
                                    , new object[] { "@TotalSalePriceAfterDiscount", TotalSalePriceAfterDiscount } // 
                                    , new object[] { "@TotalSellingPriceIncludingTax", TotalSellingPriceIncludingTax } // 
                                    , new object[] { "@SalesCartNo", lbl001.Text } //


                     });

                    if (result[1] == "succeeded")
                    {

                        fillTblSaleCarts();

                        lbl0044.Text = TblSaleCarts.Rows[0][2].ToString();//مجموع سعر البيع
                        lbl0055.Text = TblSaleCarts.Rows[0][3].ToString();//مجموع الخصم التجاري
                        lbl0066.Text = TblSaleCarts.Rows[0][4].ToString();//مجموع سعر البيع بعد الخصم التجاري
                        lbl0077.Text = TblSaleCarts.Rows[0][5].ToString();//مجموع ضريبة المخرجات
                        lbl0088.Text = TblSaleCarts.Rows[0][6].ToString();//مجموع سعر البيع شاملا الضريبة


                    }
                }


            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmSales23 >> dgv001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
            }

            //----------------

            working = true;
            txt001.Text = "";
            txt002.Text = "0";
            txt003.Text = "1";
            txt004.Text = "0";
            txt005.Text = "0";
            if (TblEnterprise != null) { if (TblEnterprise.Rows.Count > 0) { txt006.Text = TblEnterprise.Rows[0][5].ToString(); } }; // نسبة الضريبة
            txt007.Text = "0";
            txt008.Text = "0";
            txt009.Text = "0";

            cbx001.SelectedIndex = -1;

            working = false;

            txt001.Focus();
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

                pnl002.FontChanged += delegate
                {
                    lbl0010.Font = pnl002.Font;
                    lbl0011.Font = pnl002.Font;
                };
            }
        }

        //------------------ اصدار فاتورة

        private void pnl006EventsAndProperties(bool Properties, bool Events = false) // الحاوية الخاصة بعناصر الفاتورة
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl006, ColorPropertyName.BackColor_3);
                pnl006.BackColor = Color.FromArgb(255, 115, 201, 201);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl006, ColorPropertyName.BackColor_3, true, true);
                pnl006.BackColor = Color.FromArgb(255, 115, 201, 201);
            }
        }

        private void btn004EventsAndProperties(bool Properties, bool Events = false) // زر اضافة الصنف
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn004.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgBlueInvoice);
                        btn004.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        btn004.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDarkInvoice);
                        btn004.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //pic003.BorderStyle = BorderStyle.None;
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
                        btn004.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgBlueInvoice);
                        btn004.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        btn004.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDarkInvoice);
                        btn004.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //pic003.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  btn004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                btn004.Click += delegate
                {
                    
                    if(lbl0010.Text.Trim() != "")
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("لا يمكن التعديل على فاتورة تم حفظها سابقاً"), MessageBoxStatus.Ok);
                        return;
                    }

                    // اضافة فاتورة مبيعات
                    string[] result = null;
                    object SalesInvoiceNumber = DataTools.DataBases.Run(ref result, "SpSalesBill",
                    CommandType.StoredProcedure,
                    new object[][] {
                                      new object[] { "@RegistrationDateAndTime", DateTime.Now.ToString() } // تاريخ الفاتورة
                                    , new object[] { "@SalesCartNo", lbl001.Text } // رقم سلة المشتريات
                                    , new object[] { "@JournalEntryNo", "" } // رقم قيد اليومية
                                    , new object[] { "@ShiftNumber", GeneralVariables.TblShiftsOpenOnThisDevice } //  رقم الوردية
                                    , new object[] { "@TotalBill", lbl0088.Text } // مجموع الفاتورة
                                    , new object[] { "@SalesInvoiceNumber", "OUT" }
                    });

                    if (result[1] == "succeeded")
                    {



                        //----------------- تعديل كميات المخزون
                        foreach (DataGridViewRow row in dgv001.Rows)
                        {

                            string[] result4 = null;
                             DataTools.DataBases.Run(ref result4, "spQuantityDiscount",
                            CommandType.StoredProcedure,
                            new object[][] {
                                      new object[] { "@UnitDetailsNo", row.Cells[2].Value.ToString() } // رقم تفصيل السلعة
                                    , new object[] { "@Qty", Convert.ToDecimal(row.Cells[6].Value.ToString()) + Convert.ToDecimal(row.Cells[7].Value.ToString()) } // الكمية المخصومة

                            });
                        }

                        //----------------- فتح نموذج سندات القبض
                        frmReceiptVouchers frm = new frmReceiptVouchers();
                        frm.SalesCartNo = lbl001.Text ;// رقم سلة المشتريات

                        fillTblShifts(); // تحديث بيانات جدول الوردية المفتوحة لكي يتحدث الرصيد القيدي
                        frm.ShiftNumber = GeneralVariables.TblShiftsOpenOnThisDevice.Rows[0][0].ToString(); // رقم الوردية
                        frm.BalanceInRecords = GeneralVariables.TblShiftsOpenOnThisDevice.Rows[0][9].ToString(); // الرصيد القيدي بجدول الورديات
                        frm.OperationUnitNumber = GeneralVariables.TblShiftsOpenOnThisDevice.Rows[0][5].ToString(); // رقم وحدة العمليات
                        
                        frm.OperationUnitAccountNo = GeneralVariables.TblOperationUnits.Rows[0][4].ToString(); // رقم حساب وحدة العمليات

                        frm.BranchNumber = GeneralVariables.TblOperationUnits.Rows[0][1].ToString(); // رقم الفرع
                        frm._TypesOfReceiptBonds = TypesOfReceiptBonds.NewInvoice.ToString(); // نوع سند القبض
                        frm.SalePriceAfterDiscount = lbl0066.Text; // سعر البيع بعد الخصم التجاري وقبل الضريبة
                        frm.OutputTax = lbl0077.Text; // ضريبة المخرجات

                        frm.txt000.Text = SalesInvoiceNumber.ToString(); // رقم فاتورة البيع
                        frm.Font = this.Font;
                        frm.txt001.Text = lbl003.Text; // رقم العميل
                        frm.txt002.Text = lbl0033.Text; ; // اسم العميل
                        frm.txt003.Text = lbl0088.Text;
                        frm.txt004.Text = "0";
                        frm.txt005.Text = "0";
                        frm.txt006.Text = "0";
                        frm.txt007.Text = "0";
                        frm.txt008.Text = lbl0088.Text; // اجمالي الفاتورة 
                        frm.btnClose.Visible = false; // اخفاء زر الاغلاق وذلك لتسجيل القيود المحاسبية اجباراً
                        frm.ShowDialog();
                        btnClose.PerformClick(); // زر الاغلاق
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("توجد مشكلة لم تسمح بإضافة فاتورة جديدة"), MessageBoxStatus.Ok);
                    }

                    
                };

            }
        }

        private void lbl0010EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم الفاتورة 
        {


            if (Properties == true & Events == false)
            {

                ElementsTools.Lable_.CustumProperties(lbl0010, "", ColorPropertyName.BackColor_6 , ColorPropertyName.ForeColor_5, true, false);
                lbl0010.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {

                ElementsTools.Lable_.CustumProperties(lbl0010, "", ColorPropertyName.BackColor_6, ColorPropertyName.ForeColor_5, true, true);
                lbl0010.BackColor = Color.Transparent;
            }
        }

        private void lbl0011EventsAndProperties(bool Properties, bool Events = false) // ملصق تاريخ اصدار الفاتورة 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl0011, "", ColorPropertyName.BackColor_6, ColorPropertyName.ForeColor_5, true, false);
                lbl0011.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl0011, "", ColorPropertyName.BackColor_6, ColorPropertyName.ForeColor_5, true, true);
                lbl0011.BackColor = Color.Transparent;
            }
        }
        

        //------------------------------------------------------------------------------------------------------------------------------------------------ 

        DataTable TblproductAndServicesDetails = new DataTable(); //جدول تفاصيل السلع والخدمات
        DataTable TblBarcode = new DataTable(); //جدول الباركود
        DataTable TblPriceCategories = new DataTable(); //جدول الفئات السعرية
        DataTable TblFreeUnitsOffers = new DataTable(); //جدول عروض الوحدات المجانية
        //DataTable TblClients = new DataTable(); //جدول العملاء 

        DataTable TblSaleCarts = new DataTable(); // جدول بيانات سلال المبيعات
        DataTable TblSalesCartDetails = new DataTable(); //جدول تفاصيل بيانات سلال المبيعات


        // تعبئة جدول السلع والخدمات
        private void fillTblproductAndServicesDetails()
        {
            try
            {

                if(TblproductAndServicesDetails != null)
                {
                    if (TblproductAndServicesDetails.Rows.Count > 0)
                    {
                        TblproductAndServicesDetails.Rows.Clear();
                    }

                    if (TblproductAndServicesDetails.Rows.Count > 0) TblproductAndServicesDetails.Rows.Clear();
                }

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
                if(TblBarcode != null)
                {
                    if (TblBarcode.Rows.Count > 0)
                    {
                        TblBarcode.Rows.Clear();
                    }

                    if (TblBarcode.Rows.Count > 0) TblBarcode.Rows.Clear();
                }

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
        private void fillTblPriceCategories(string UnitDetailsNo)
        {
            try
            {
                if(TblPriceCategories != null)
                {
                    if (TblPriceCategories.Rows.Count > 0)
                    {
                        TblPriceCategories.Rows.Clear();
                    }

                    if (TblPriceCategories.Rows.Count > 0) TblPriceCategories.Rows.Clear();
                }

                if(!string.IsNullOrEmpty(UnitDetailsNo))
                {
                    TblPriceCategories = DataTools.DataBases.ReadTabel("select * from TblPriceCategories where  UnitDetailsNo = " + UnitDetailsNo);

                }




            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23 >> fillTblPriceCategories ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        //جدول عروض الوحدات المجانية
        private void fillTblFreeUnitsOffers(string UnitDetailsNo)
        {
            try
            {
                if(TblFreeUnitsOffers != null)
                {
                    if (TblFreeUnitsOffers.Rows.Count > 0)
                    {
                        TblFreeUnitsOffers.Rows.Clear();
                    }
                }
                else
                {
                    TblFreeUnitsOffers = new DataTable();
                }

                if(!string.IsNullOrEmpty(UnitDetailsNo))
                {
                    TblFreeUnitsOffers = DataTools.DataBases.ReadTabel("select * from TblFreeUnitsOffers where  UnitDetailsNo = " + UnitDetailsNo);
                }






            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23 >> fillTblFreeUnitsOffers ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        ////جدول العملاء
        //private void fillTblClients(string clientNo)
        //{
        //    try
        //    {
        //        if (TblClients == null) TblClients = new DataTable();
        //        if (TblClients.Rows.Count > 0)
        //        {
        //            TblClients.Rows.Clear();
        //        }

        //        if (TblClients.Rows.Count > 0) TblClients.Rows.Clear();

        //        if (clientNo.Trim().Replace("'", "") != "")
        //        {
        //            TblClients = DataTools.DataBases.ReadTabel("select * from TblClients where ClientsNo = " + clientNo );
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralAction.AddNewNotification("frmSales23 >> fillTblClients ", DateTime.Now, ex.Message, ex.Message);
        //    }
        //}

        // تعبئة جدول بيانات سلال المبيعات 
        private void fillTblSaleCarts()
        {
            try
            {
                if(TblSaleCarts != null)
                {
                    if (TblSaleCarts.Rows.Count > 0)
                    {
                        TblSaleCarts.Rows.Clear();
                    }

                    if (TblSaleCarts.Rows.Count > 0) TblSaleCarts.Rows.Clear();
                }
                
                TblSaleCarts = DataTools.DataBases.ReadTabel("select * from TblSaleCarts where SalesCartNo = "+lbl001.Text);

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
                if(TblSalesCartDetails != null)
                {
                    if (TblSalesCartDetails.Rows.Count > 0)
                    {
                        TblSalesCartDetails.Rows.Clear();
                    }

                    if (TblSalesCartDetails.Rows.Count > 0) TblSalesCartDetails.Rows.Clear();
                }

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

        //--------------------------------------------------
        DataTable TblEnterprise = new DataTable(); // جدول المنشآت 

        // تعبئة جدول المنشأة
        private void fillTblEnterprise()
        {
            try
            {
                if(TblEnterprise != null)
                {
                    if (TblEnterprise.Rows.Count > 0)
                    {
                        TblEnterprise.Rows.Clear();
                    }

                    if (TblEnterprise.Rows.Count > 0) TblEnterprise.Rows.Clear();
                }

                TblEnterprise = DataTools.DataBases.ReadTabel("select * from TblEnterprise ");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23 >> fillTblEnterprise ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        //------------------------ 
        DataTable TblSalesBill = new DataTable(); // جدول الفواتير

        private void fillTblSalesBill(string SalesCartNo)
        {
            try
            {
                if (TblSalesBill != null)
                {
                    if (TblSalesBill.Rows.Count > 0)
                    {
                        TblSalesBill.Rows.Clear();
                    }

                    if (TblSalesBill.Rows.Count > 0) TblSalesBill.Rows.Clear();
                }


                TblSalesBill = DataTools.DataBases.ReadTabel("select * from TblSalesBill where SalesCartNo = " + SalesCartNo);

                if (TblSalesBill != null)
                {
                    if (TblSalesBill.Rows.Count > 0)
                    {
                        lbl0010.Text = TblSalesBill.Rows[0][0].ToString();
                        lbl0011.Text = Convert.ToDateTime(TblSalesBill.Rows[0][1].ToString()).ToString("yyyy/MM/dd hh:mm tt");
                        lbl0011.RightToLeft = RightToLeft.No;
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23 >> fillSalesBill ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        private void fillTblShifts() // تعبئة بيانات جدول الوردية المفتوحة
        {
            try
            {

                if (GeneralVariables.TblShiftsOpenOnThisDevice is null)
                {
                    GeneralVariables.TblShiftsOpenOnThisDevice = new DataTable();
                }

                if (GeneralVariables.TblShiftsOpenOnThisDevice.Rows.Count > 0)
                {
                    GeneralVariables.TblShiftsOpenOnThisDevice.Rows.Clear();
                }

                //TblOpenShiftsForThisOperationUnit = DataTools.DataBases.ReadTabel(@"select * from TblShifts inner join TblOperationUnits on TblShifts.OperationUnitNumber = TblOperationUnits.OperationUnitNumber where DeviceNumber = '" + SecurityTools.specialDevices.getCPUID() + "' and DateAndTimeOfShiftClosing  = '1999-01-01 00:00:00.000' ");
                GeneralVariables.TblShiftsOpenOnThisDevice = DataTools.DataBases.ReadTabel(@"select * from TblShifts where OperationUnitNumber = '" + Properties.Settings.Default["OperationUnitNumber"].ToString() + "' and ShiftStatus  in (1,2) ");



            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23_B >> fillTblShifts ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        //private DataRow currentOperationAccountNo()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        dt = DataTools.DataBases.ReadTabel(@"select BranchNumber , AccountNo from TblOperationUnits where  OperationUnitNumber = " + TblShifts.Rows[0][5].ToString());

        //        return dt.Rows[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralAction.AddNewNotification("frmSales23 >> currentOperationAccountNo ", DateTime.Now, ex.Message, ex.Message);

        //        return null ;
        //    }

        //}
    }


}

