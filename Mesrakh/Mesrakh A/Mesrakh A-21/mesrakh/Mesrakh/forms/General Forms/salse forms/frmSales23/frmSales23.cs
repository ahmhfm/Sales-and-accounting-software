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
    public partial class frmSales23 : Form
    {
        public frmSales23()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmEncapsulationUnits13EventsAndProperties(Properties, Events); // النموذج
            pnlMainEventsAndProperties(Properties, Events); // الحاوية الرئيسية
            pnl001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lblTitelEventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl002EventsAndProperties(Properties, Events); // الحاوية الثانية
            btn001EventsAndProperties(Properties, Events); // زر اضافة سلة مبيعات
            btn002EventsAndProperties(Properties, Events); // زر فتح سلة مبيعات
            //pnl003EventsAndProperties(Properties, Events); // حاوية العمل
            tc001EventsAndProperties(Properties, Events); // الحاوية المتعددة 


        }


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
                    CheckOpenShiftsOnThisDevice();  // الورديات المفتوحة لهذا الجهاز

                    if (TblOpenShiftsForThisOperationUnit != null)
                    {
                        if (TblOpenShiftsForThisOperationUnit.Rows.Count > 0)
                        {
                            if (GeneralVariables.ActiveAccount.Rows[0][0].ToString() == TblOpenShiftsForThisOperationUnit.Rows[0][4].ToString())
                            {
                                btn001.Enabled = true;
                                btn002.Enabled = true;
                            }

                        }

                    }

                };


                this.FontChanged += delegate
                {
                    foreach (TabPage tp in tc001.TabPages)
                    {
                        if(tp.Controls.Count>0)
                        {
                            tp.Controls[0].Font = this.Font;
                        }
                    }
                };

                lblTitel.TextChanged += delegate
                {
                    foreach (TabPage tp in tc001.TabPages)
                    {
                        if (tp.Controls.Count > 0)
                        {
                            (tp.Controls[0] as frmSales23_B).AllEventsAndProperties(true);
                        }
                    }
                };

                this.BackColorChanged += delegate
                {
                    foreach (TabPage tp in tc001.TabPages)
                    {
                        if (tp.Controls.Count > 0)
                        {
                            (tp.Controls[0] as frmSales23_B).AllEventsAndProperties(true);
                        }
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
                lblTitel.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblTitel, "المبيعات", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lblTitel.BackColor = Color.Transparent;

            }
        }

        private void pnl002EventsAndProperties(bool Properties, bool Events = false) // الحاوية الثانية
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

        private void btn001EventsAndProperties(bool Properties, bool Events = false) // زر اضافة سلة مبيعات
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn001.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCart);
                        btn001.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        btn001.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCart);
                        btn001.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //btn001.BorderStyle = BorderStyle.None;
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
                        btn001.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCart);
                        btn001.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        btn001.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCart);
                        btn001.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //btn001.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  pic001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                btn001.Click += delegate
                {
                    string[] result = null;
                    object SalesCartNo = DataTools.DataBases.Run(ref result, "spAddSaleCarts",
                    CommandType.StoredProcedure, 
                    new object[][] {
                                      new object[] { "@RegistrationDateAndTime", DateTime.Now.ToString() }
                                    , new object[] { "@TotalSalePrice", "0" }
                                    , new object[] { "@TotalDiscount", "0" }
                                    , new object[] { "@TotalSalePriceAfterDiscount", "0" }
                                    , new object[] { "@TotalOutputTax", "0" }
                                    , new object[] { "@TotalSellingPriceIncludingTax", "0" }
                                    , new object[] { "@ClientsNo", "" }
                                    , new object[] { "@LinkType", "0" }
                                    , new object[] { "@SalesCartNo", "OUT" }
                    });

                    if (result[1] == "succeeded")
                    {
                        int index = tc001.TabPages.Count;
                        tc001.TabPages.Add(SalesCartNo.ToString());
                        tc001.TabPages[index].AutoScroll = true;
                        tabsNames.Add(SalesCartNo.ToString());
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("توجد مشكلة لم تسمح بإضافة سلة جديدة"), MessageBoxStatus.Ok);
                    }

                    
                };

            }
        }


        private void btn002EventsAndProperties(bool Properties, bool Events = false) // زر فتح سلة مبيعات
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn002.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgOpenCart);
                        btn002.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        btn002.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgOpenCart);
                        btn002.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //btn001.BorderStyle = BorderStyle.None;
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
                        btn002.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgOpenCart);
                        btn002.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        btn002.BackgroundImage = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgOpenCart);
                        btn002.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //btn001.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmSales23 >>  pic002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                btn002.Click += delegate
                {
                    

                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("فتح السلة"), Cultures.ReturnTranslation("رجاء قم بتسجيل رقم السلة"), MessageBoxStatus.Number);
                    if (GeneralVariables.MessageBoxResult == "")
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("فتح السلة"), Cultures.ReturnTranslation("لم تقم بتسجيل رقم السلة"), MessageBoxStatus.Ok);
                        return;
                    }
                    fillTblSaleCarts(GeneralVariables.MessageBoxResult);
                    if(TblSaleCarts.Rows.Count>0)
                    {
                        int index = tc001.TabPages.Count;
                        tc001.TabPages.Add(GeneralVariables.MessageBoxResult);
                        tc001.TabPages[index].AutoScroll = true;

                        tabsNames.Add(GeneralVariables.MessageBoxResult); // tc001EventsAndProperties();
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد عربة مبيعات بهذا الرقم"), MessageBoxStatus.Ok);

                    }

                };

            }
        }

        DataTable TblSaleCarts = new DataTable(); //  جدول بيانات سلال المبيعات 
        // تعبئة جدول بيانات سلال المبيعات 
        private void fillTblSaleCarts(string SalesCartNo)
        {
            try
            {
                if (TblSaleCarts != null)
                {
                    if (TblSaleCarts.Rows.Count > 0)
                    {
                        TblSaleCarts.Rows.Clear();
                    }

                    if (TblSaleCarts.Rows.Count > 0) TblSaleCarts.Rows.Clear();
                }

                TblSaleCarts = DataTools.DataBases.ReadTabel("select * from TblSaleCarts where SalesCartNo = " + SalesCartNo);

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmSales23 >> fillTblSaleCarts ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        List<string> tabsNames = new List<string>();
        private void tc001EventsAndProperties(bool Properties, bool Events = false) // الحاوية المتعددة  
        {

            if (Properties == true && Events == false)
            {
                //string[] tabsNames = new string[4];
                //tabsNames[0] = Cultures.ReturnTranslation("وحدات العمليات");
                //tabsNames[1] = Cultures.ReturnTranslation("الأرفف");
                //tabsNames[2] = Cultures.ReturnTranslation("الحسابات البنكية");
                //tabsNames[3] = Cultures.ReturnTranslation("صناديق النقدية");

                ElementsTools.TabControl_.CustumProperties(tc001, tabsNames, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false);
            }
            else if (Properties == true && Events == true)
            {
                //string[] tabsNames = new string[4];
                //tabsNames[0] = Cultures.ReturnTranslation("وحدات العمليات");
                //tabsNames[1] = Cultures.ReturnTranslation("الأرفف");
                //tabsNames[2] = Cultures.ReturnTranslation("الحسابات البنكية");
                //tabsNames[3] = Cultures.ReturnTranslation("صناديق النقدية");

                ElementsTools.TabControl_.CustumProperties(tc001, tabsNames, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                

                // عند اضافة صفحة جديدة
                tc001.ControlAdded += delegate
                {
                    frmSales23_B frm = new frmSales23_B();
                    
                    frm.TopLevel = false;
                    frm.TopMost = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    tc001.TabPages[tc001.TabPages.Count - 1].Controls.Add(frm);
                    frm.Show();
                    frm.Font = this.Font;
                    //frm.Height = frm.Parent.Parent.Height-frm.Parent.Height;
                    frm.Dock = DockStyle.Fill;
                    
                };
            }
        }


        //---------------------
        public DataTable TblOpenShiftsForThisOperationUnit = new DataTable(); // الوردية المفتوحة لوحدة العمليات الحالية 

        private void CheckOpenShiftsOnThisDevice() // فحص الورديات المفتوحة على هذا الجهاز
        {
            try
            {
                if (TblOpenShiftsForThisOperationUnit is null)
                {
                    TblOpenShiftsForThisOperationUnit = new DataTable();
                }
                if (TblOpenShiftsForThisOperationUnit.Rows.Count > 0)
                {
                    TblOpenShiftsForThisOperationUnit.Rows.Clear();
                }

                if (TblOpenShiftsForThisOperationUnit.Rows.Count > 0) TblOpenShiftsForThisOperationUnit.Rows.Clear();

                TblOpenShiftsForThisOperationUnit = DataTools.DataBases.ReadTabel(@"select * from TblShifts inner join TblOperationUnits on TblShifts.OperationUnitNumber = TblOperationUnits.OperationUnitNumber where DeviceNumber = '" + SecurityTools.specialDevices.getCPUID() + "' and DateAndTimeOfShiftClosing  = '1999-01-01 00:00:00.000' ");

                if (TblOpenShiftsForThisOperationUnit != null)
                {
                    if (TblOpenShiftsForThisOperationUnit.Rows.Count > 0)
                    {
                        if (TblOpenShiftsForThisOperationUnit.Rows[0][4].ToString() != GeneralVariables.ActiveAccount.Rows[0][0].ToString()) // هل الوردية المفتوحة ليست لهذا الحساب
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("يوجد حساب آخر لديه وردية مفتوحة على هذا الجهاز"), MessageBoxStatus.Ok);
                            foreach (Control control in this.Controls)
                            {
                                control.Enabled = false;
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmShifts21 >> CheckOpenShiftsOnThisDevice ", DateTime.Now, ex.Message, ex.Message);
            }
        }

    }


}

