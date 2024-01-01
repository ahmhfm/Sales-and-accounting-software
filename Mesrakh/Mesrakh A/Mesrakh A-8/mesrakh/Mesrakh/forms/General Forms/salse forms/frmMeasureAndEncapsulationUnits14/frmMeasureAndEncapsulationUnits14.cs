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
    public partial class frmMeasureAndEncapsulationUnits14 : Form  // نموذج وحدات القياس والتغليف
    {
        public frmMeasureAndEncapsulationUnits14()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmMeasureAndEncapsulationUnits14EventsAndProperties(Properties, Events); // النموذج
            pnl08001EventsAndProperties(Properties, Events);// الحاوية الرئيسية
            pnl08001001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl08001001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl08001002EventsAndProperties(Properties, Events); // الحاوية الثانية

            //-----

            lbl08001002001EventsAndProperties(Properties, Events);// ملصق رقم وحدة القياس والتغليف 
            txt08001002001EventsAndProperties(Properties, Events);// مربع نص رقم وحدة القياس والتغليف
            lbl08001002002EventsAndProperties(Properties, Events);// ملصق رقم وحدة التغليف 
            cbx001002001EventsAndProperties(Properties, Events);// قائمة منسدلة رقم وحدة التغليف
            lbl08001002003EventsAndProperties(Properties, Events);// ملصق رقم المنتج 
            cbx001002002EventsAndProperties(Properties, Events);// قائمة منسدلة رقم المنتج
            lbl08001002004EventsAndProperties(Properties, Events);// ملصق قيمة وحدةالقياس 
            txt08001002002EventsAndProperties(Properties, Events);// مربع نص قيمة وحدةالقياس
            //lbl08001002005EventsAndProperties(Properties, Events);// ملصق رقم وحدة القياس 
            cbx001002003EventsAndProperties(Properties, Events);// قائمة منسدلة رقم وحدة القياس
            lbl08001002006EventsAndProperties(Properties, Events);// ملصق قيمة وحدة القياس والتغليف 
            txt08001002003EventsAndProperties(Properties, Events);// مربع نص قيمة وحدة القياس والتغليف
            //lbl08001002007EventsAndProperties(Properties, Events);// ملصق رقم وحدة القياس والتغليف 
            cbx001002004EventsAndProperties(Properties, Events);// قائمة منسدلة رقم وحدة القياس والتغليف
            lbl08001002008EventsAndProperties(Properties, Events);// ملصق اسم وحدة القياس والتغليف عربي 
            txt08001002004EventsAndProperties(Properties, Events);// مربع نص اسم وحدة القياس والتغليف عربي
            lbl08001002009EventsAndProperties(Properties, Events);// ملصق اسم وحدة القياس والتغليف انجليزي 
            txt08001002005EventsAndProperties(Properties, Events); // مربع نص اسم وحدة القياس والتغليف انجليزي

            //-----

            btn08001002001EventsAndProperties(Properties, Events); // جديد
            btn08001002002EventsAndProperties(Properties, Events); // حفظ
            btn08001002003EventsAndProperties(Properties, Events); // تعديل
            btn08001002004EventsAndProperties(Properties, Events); // حذف
            tvEventsAndProperties(Properties, Events); // شجرة عرض التصنيفات
            dgv08001EventsAndProperties(Properties, Events); // جدول عرض بيانات التصنيفات 

            //-------- البحث
            lblSearchEventsAndProperties(Properties, Events);// ملصق البحث عن
            txtSearchEventsAndProperties(Properties, Events);// مربع نص البحث عن

            //---------- القوائم الجانبية
            btnBarcodeEventsAndProperties(Properties, Events); // زر فتح الباركود 
            btnPriceCategoriesEventsAndProperties(Properties, Events);// زر فتح الفئات السعرية 
            btnFreeUnitsOffersEventsAndProperties(Properties, Events);// زر فتح عروض الوحدات المجانية 
            pnl08001002001EventsAndProperties(Properties, Events);// الحاوية الجانبية



        }

        private void frmMeasureAndEncapsulationUnits14EventsAndProperties(bool Properties, bool Events = false) // النموذج 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Form_.CustumProperties(this);
                tooltip();

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Form_.CustumProperties(this, ColorPropertyName.BackColor_3, true, true);
                tooltip();
            }
        }

        private void pnl08001EventsAndProperties(bool Properties, bool Events = false) // الحاوية الرئيسية
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl08001);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl08001, ColorPropertyName.BackColor_3, true, true);
            }
        }

        private void pnl08001001EventsAndProperties(bool Properties, bool Events = false) // الحاوية العلوية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl08001001, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl08001001, ColorPropertyName.BackColor_2, true, true);
            }
        }

        private void lbl08001001001EventsAndProperties(bool Properties, bool Events = false) // ملصق عنوان النموذج 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "وحدات القياس والتغليف", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "وحدات القياس والتغليف", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void pnl08001002EventsAndProperties(bool Properties, bool Events = false) // الحاوية الثانية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl08001002);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl08001002, ColorPropertyName.BackColor_3, true, true);
            }
        }


        //*******************

        private void lbl08001002001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم وحدة القياس والتغليف 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم الوحدة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم الوحدة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم وحدة القياس والتغليف
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002001, "en-US");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002001, "en-US", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt08001002001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx001002001.Select();
                    }
                };
            }
        }

       

        private void lbl08001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم وحدة التغليف 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "وحدة التغليف", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "وحدة التغليف", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void cbx001002001EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة رقم وحدة التغليف
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblEncapsulationUnits is null) return;
                    if (TblEncapsulationUnits.Rows.Count > 0)
                    {
                        cbx001002001.DataSource = TblEncapsulationUnits;
                        cbx001002001.ValueMember = "EncapsulationUnitsNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002001.DisplayMember = "UnitNameAR";
                        }
                        else
                        {
                            cbx001002001.DisplayMember = "UnitNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001002001);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> cbx08001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblEncapsulationUnits();
                    if (TblEncapsulationUnits is null) return;
                    if (TblEncapsulationUnits.Rows.Count > 0)
                    {
                        cbx001002001.DataSource = TblEncapsulationUnits;
                        cbx001002001.ValueMember = "EncapsulationUnitsNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002001.DisplayMember = "UnitNameAR";
                        }
                        else
                        {
                            cbx001002001.DisplayMember = "UnitNameEN";
                        }
                    }

                    ElementsTools.ComboBox_.CustumProperties(cbx001002001, "", true, true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> cbx08001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx001002001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx001002002.Select();
                    }
                };
            }
        }


        private void lbl08001002003EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم المنتج 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "المنتج", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "المنتج", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void cbx001002002EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة رقم المنتج
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblProducts is null) return;
                    if (TblProducts.Rows.Count > 0)
                    {
                        cbx001002002.DataSource = TblProducts;
                        cbx001002002.ValueMember = "ProductNumber";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002002.DisplayMember = "ProductNameAR";
                        }
                        else
                        {
                            cbx001002002.DisplayMember = "ProductNameEN";
                        }

                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001002002);

                }


                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> cbx001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblProducts();
                    if (TblProducts is null) return;
                    if (TblProducts.Rows.Count > 0)
                    {
                        cbx001002002.DataSource = TblProducts;
                        cbx001002002.ValueMember = "ProductNumber";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002002.DisplayMember = "ProductNameAR";
                        }
                        else
                        {
                            cbx001002002.DisplayMember = "ProductNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001002002, "", true, true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> cbx001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx001002002.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002002.Select();
                    }
                };
            }
        }


        private void lbl08001002004EventsAndProperties(bool Properties, bool Events = false) // ملصق قيمة وحدةالقياس 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "قيمة وحدةالقياس", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002004, "قيمة وحدةالقياس", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void txt08001002002EventsAndProperties(bool Properties, bool Events = false) // مربع نص قيمة وحدةالقياس
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Int);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true,TextBoxType.Int);
                txt08001002002.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx001002003.Select();
                    }
                };
            }
        }


        //private void lbl08001002005EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم وحدة القياس 
        //{

        //    if (Properties == true & Events == false)
        //    {
        //        ElementsTools.Lable_.CustumProperties(lbl08001002005, "وحدة القياس", ColorPropertyName.BackColor_1);
        //    }
        //    else if (Properties == true & Events == true)
        //    {
        //        ElementsTools.Lable_.CustumProperties(lbl08001002005, "وحدة القياس", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
        //    }
        //}


        private void cbx001002003EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة رقم وحدة القياس
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblMeasureUnit is null) return;
                    if (TblMeasureUnit.Rows.Count > 0)
                    {
                        cbx001002003.DataSource = TblMeasureUnit;
                        cbx001002003.ValueMember = "MeasureUnitNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002003.DisplayMember = "UnitNameAR";
                        }
                        else
                        {
                            cbx001002003.DisplayMember = "UnitNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001002003);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> cbx001002003EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblMeasureUnit();

                    if (TblMeasureUnit is null) return;
                    if (TblMeasureUnit.Rows.Count > 0)
                    {
                        cbx001002003.DataSource = TblMeasureUnit;
                        cbx001002003.ValueMember = "MeasureUnitNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002003.DisplayMember = "UnitNameAR";
                        }
                        else
                        {
                            cbx001002003.DisplayMember = "UnitNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001002003, "", true, true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> cbx001002003EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx001002003.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002003.Select();
                    }
                };
            }
        }

  


        private void lbl08001002006EventsAndProperties(bool Properties, bool Events = false) // ملصق قيمة وحدة القياس والتغليف 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002006, "قيمة وحدة القياس والتغليف", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002006, "قيمة وحدة القياس والتغليف", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void txt08001002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص قيمة وحدة القياس والتغليف
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Int);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Int);
                txt08001002003.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx001002004.Select();
                    }
                };
            }
        }

        //private void lbl08001002007EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم وحدة القياس والتغليف 
        //{

        //    if (Properties == true & Events == false)
        //    {
        //        ElementsTools.Lable_.CustumProperties(lbl08001002007, "وحدة القياس والتغليف", ColorPropertyName.BackColor_1);
        //    }
        //    else if (Properties == true & Events == true)
        //    {
        //        ElementsTools.Lable_.CustumProperties(lbl08001002007, "وحدة القياس والتغليف", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
        //    }
        //}

        private void cbx001002004EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة رقم وحدة القياس والتغليف
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblMeasureAndEncapsulationUnitsForCbx is null) { TblMeasureAndEncapsulationUnitsForCbx = new DataTable();  }
                    cbx001002004.DataSource = TblMeasureAndEncapsulationUnitsForCbx;
                    if (TblMeasureAndEncapsulationUnitsForCbx.Rows.Count > 0)
                    {
                       
                        cbx001002004.ValueMember = "MeasureAndEncapsulationUnitNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002004.DisplayMember = "MeasureAndEncapsulationUnitNameAR";
                        }
                        else
                        {
                            cbx001002004.DisplayMember = "MeasureAndEncapsulationUnitNameEN";
                        }
                        
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001002004);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> cbx001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblMeasureAndEncapsulationUnits();

                    if (TblMeasureAndEncapsulationUnitsForCbx is null) { TblMeasureAndEncapsulationUnitsForCbx = new DataTable(); }
                    cbx001002004.DataSource = TblMeasureAndEncapsulationUnitsForCbx;
                    if (TblMeasureAndEncapsulationUnitsForCbx.Rows.Count > 0)
                    {
                        
                        cbx001002004.ValueMember = "MeasureAndEncapsulationUnitNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002004.DisplayMember = "MeasureAndEncapsulationUnitNameAR";
                        }
                        else
                        {
                            cbx001002004.DisplayMember = "MeasureAndEncapsulationUnitNameEN";
                        }
                    }

                    ElementsTools.ComboBox_.CustumProperties(cbx001002004, "", true, true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> cbx001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx001002004.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002004.Select();
                    }
                };

                //cbx001002004.Enter += delegate
                //{
                //    cbx001002004.DataSource = TblMeasureAndEncapsulationUnitsForCbx;
                //};


            }
        }


        private void lbl08001002008EventsAndProperties(bool Properties, bool Events = false) // ملصق اسم وحدة القياس والتغليف عربي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002008, "اسم الوحدة عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002008, "اسم الوحدة عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002004EventsAndProperties(bool Properties, bool Events = false) // مربع نص اسم وحدة القياس والتغليف عربي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, "ar-SA");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, "ar-SA", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt08001002004.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002005.Select();
                    }
                };
            }
        }


        private void lbl08001002009EventsAndProperties(bool Properties, bool Events = false) // ملصق اسم وحدة القياس والتغليف انجليزي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002009, "اسم الوحدة انجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002009, "اسم الوحدة انجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void txt08001002005EventsAndProperties(bool Properties, bool Events = false) // مربع نص اسم وحدة القياس والتغليف انجليزي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002005, "en-US");

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002005, "en-US", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt08001002005.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        btn08001002002.PerformClick();
                    }
                };
            }
        }


        //******************************************




        private void btn08001002001EventsAndProperties(bool Properties, bool Events = false) // جديد 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn08001002001, "جديد");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn08001002001, "جديد", ColorPropertyName.ForeColor_1, true, true);

                btn08001002001.Click += delegate
                {

                    if (Permissions.AccountHavePermission(PermissionObjectes.Measure_And_Encapsulation_Units, PermissionType.Add))
                    {

                        if (btn08001002001.Text == Cultures.ReturnTranslation("جديد"))
                        {
                            btn08001002001.Text = Cultures.ReturnTranslation("إلغاء");

                            btn08001002002.Enabled = true;
                            btn08001002003.Enabled = false;
                            btn08001002004.Enabled = false;

                            txt08001002001.Enabled = false;
                            txt08001002002.Enabled = true;
                            txt08001002003.Enabled = true;
                            txt08001002004.Enabled = true;
                            txt08001002005.Enabled = true;

                            cbx001002001.Enabled = true;
                            cbx001002002.Enabled = true;
                            cbx001002003.Enabled = true;
                            cbx001002004.Enabled = true;

                            dgv08001.Enabled = false;
                            tv.Enabled = false;

                            txt08001002001.Text = "";
                            txt08001002002.Text = "";
                            txt08001002003.Text = "";
                            txt08001002004.Text = "";
                            txt08001002005.Text = "";

                            if (cbx001002001 != null && cbx001002001.Items.Count > 0) cbx001002001.SelectedIndex = -1;
                            if (cbx001002002 != null && cbx001002002.Items.Count > 0) cbx001002002.SelectedIndex = -1;
                            if (cbx001002003 != null && cbx001002003.Items.Count > 0) cbx001002003.SelectedIndex = -1;
                            if (cbx001002004 != null && cbx001002004.Items.Count > 0) cbx001002004.SelectedIndex = -1;

                            cbx001002001.Focus();
                        }
                        else
                        {
                            btn08001002001.Text = Cultures.ReturnTranslation("جديد");

                            btn08001002002.Enabled = false;
                            btn08001002003.Enabled = true;
                            btn08001002004.Enabled = true;

                            txt08001002001.Enabled = false;
                            txt08001002002.Enabled = false;
                            txt08001002003.Enabled = false;
                            txt08001002004.Enabled = false;
                            txt08001002005.Enabled = false;

                            cbx001002001.Enabled = false;
                            cbx001002002.Enabled = false;
                            cbx001002003.Enabled = false;
                            cbx001002004.Enabled = false;

                            dgv08001.Enabled = false;
                            tv.Enabled = false;

                            dgv08001.Focus();
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }


                };


            }


        }

        private void btn08001002002EventsAndProperties(bool Properties, bool Events = false) // حفظ 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn08001002002, "حفظ");
            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn08001002002, "حفظ", ColorPropertyName.ForeColor_1, true, true);

                btn08001002002.Click += delegate
                {

                    try
                    {
                        if ( btn08001002001.Text == Cultures.ReturnTranslation("إلغاء")) // إضافة
                        {
                            string Error = "";
                            if (cbx001002001.SelectedIndex == -1)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار وحدة التغليف");
                                cbx001002001.Focus();
                            }
                            else if (cbx001002002.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار المنتج");
                                cbx001002002.Focus();
                            }
                            else if (txt08001002002.Text.Trim() == "" && txt08001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل قيمة وحدة القياس أو قيمة وحدة القياس والتغليف");
                                txt08001002001.Focus();
                            }
                            else if (cbx001002003.SelectedIndex == -1  && cbx001002004.SelectedIndex == -1)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار وحدة قياس أو وحدة قياس وتغليف");
                                cbx001002003.Focus();
                            }
                            else
                            {
                                // فحص البيانات للتأكد من عدم وجود تكرار في الجدول
                                bool? SameArabicName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002004.Text.Replace("'", ""), 1);
                                bool? SameEnglishName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002005.Text.Replace("'", ""), 2);

                                if (SameArabicName == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد وحدة بنفس الإسم العربي");
                                    txt08001002004.Focus();

                                }
                                else
                                {
                                    if (SameEnglishName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد وحدة بنفس الإسم الإنجليزي");
                                        txt08001002005.Focus();
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string[] result = null;
                                object returnNumber = DataTools.DataBases.Run(ref result, "spAddMeasureAndEncapsulationUnits",
                                CommandType.StoredProcedure, new object[][] {
                                      new object[] { "@EncapsulationUnitsNo", cbx001002001.SelectedValue }
                                    , new object[] { "@ProductNumber", cbx001002002.SelectedValue }
                                    , new object[] { "@MeasureUnitValue", txt08001002002.Text.Replace("'", "") }
                                    , new object[] { "@MeasureUnitNo", cbx001002003.SelectedValue }
                                    , new object[] { "@MeasureAndEncapsulationUnitNo_selfJoinValue", txt08001002003.Text.Replace("'", "") }
                                    , new object[] { "@MeasureAndEncapsulationUnitNoSelfJoin", cbx001002004.SelectedValue }
                                    , new object[] { "@MeasureAndEncapsulationUnitNameAR", txt08001002004.Text.Replace("'","") }
                                    , new object[] { "@MeasureAndEncapsulationUnitNameEN", txt08001002005.Text.Replace("'", "") }
                                     , new object[] { "@MeasureAndEncapsulationUnitNo", "OUT" }
                                });

                                if (result[1] == "succeeded")
                                {


                                    if (GeneralVariables.cultureCode == "AR")
                                    {
                                        TreeNode tn = new TreeNode(txt08001002004.Text.Replace("'", ""));
                                        tn.Tag = returnNumber;
                                        if (cbx001002004.SelectedIndex > -1) { ElementsTools.TreeView_.Search(tv, cbx001002004.SelectedValue).Nodes.Add(tn); } else { tv.Nodes.Add(tn); } // اذا تم تحديد وحدة اعلى يتم الاضافة اليها واذا لم يتم تحديد وحدة اعلى تتم الاضافة على الشجرة العامة

                                    }
                                    else
                                    {
                                        TreeNode tn = new TreeNode(txt08001002005.Text.Replace("'", ""));
                                        tn.Tag = returnNumber;
                                        if (cbx001002004.SelectedIndex > -1) { ElementsTools.TreeView_.Search(tv, cbx001002004.SelectedValue).Nodes.Add(tn); } else { tv.Nodes.Add(tn); } // اذا تم تحديد وحدة اعلى يتم الاضافة اليها واذا لم يتم تحديد وحدة اعلى تتم الاضافة على الشجرة العامة

                                    }

                                    // البيانات الى الجدول
                                    // table 1 
                                    DataRow dr = TblMeasureAndEncapsulationUnits.NewRow();
                                    dr[0] = returnNumber;
                                    dr[1] = cbx001002001.SelectedValue == null ? DBNull.Value : cbx001002001.SelectedValue;
                                    dr[2] = cbx001002002.SelectedValue == null ? DBNull.Value : cbx001002002.SelectedValue;
                                    if (txt08001002002.Text.Trim() == "")
                                    {
                                        dr[3] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr[3] = txt08001002002.Text;
                                    }
                                    dr[4] = cbx001002003.SelectedValue == null ? DBNull.Value : cbx001002003.SelectedValue;
                                    if (txt08001002003.Text.Trim() == "")
                                    {
                                        dr[5] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr[5] = txt08001002003.Text;
                                    }
                                    dr[6] = cbx001002004.SelectedValue == null ? DBNull.Value : cbx001002004.SelectedValue;
                                    dr[7] = txt08001002004.Text;
                                    dr[8] = txt08001002005.Text;
                                    TblMeasureAndEncapsulationUnits.Rows.Add(dr);

                                    // table 2 
                                    DataRow dr2 = TblMeasureAndEncapsulationUnitsForCbx.NewRow();
                                    dr2[0] = returnNumber;
                                    dr2[1] = cbx001002001.SelectedValue == null ? DBNull.Value : cbx001002001.SelectedValue;
                                    dr2[2] = cbx001002002.SelectedValue == null ? DBNull.Value : cbx001002002.SelectedValue;
                                    if (txt08001002002.Text.Trim() == "")
                                    {
                                        dr2[3] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr2[3] = txt08001002002.Text;
                                    }
                                    dr2[4] = cbx001002003.SelectedValue == null ? DBNull.Value : cbx001002003.SelectedValue;
                                    if (txt08001002003.Text.Trim() == "")
                                    {
                                        dr2[5] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr2[5] = txt08001002003.Text;
                                    }
                                    dr2[6] = cbx001002004.SelectedValue == null ? DBNull.Value : cbx001002004.SelectedValue;
                                    dr2[7] = txt08001002004.Text;
                                    dr2[8] = txt08001002005.Text;
                                    TblMeasureAndEncapsulationUnitsForCbx.Rows.Add(dr2);


                                    if (cbx001002004.DataSource == null)
                                    {
                                        cbx001002004EventsAndProperties(true);
                                    }

                                    if (dgv08001.DataSource == null)
                                    {
                                        dgv08001EventsAndProperties(true);
                                    }

                                    //if (GeneralVariables._frmProducts09 != null) { GeneralVariables._frmProducts09.AllfrmProducts09ElementsEventsAndProperties(true, true); } // تحديث خصائص نموذج المنتجات  ??????????????????

                                }


                                btn08001002001.Text = Cultures.ReturnTranslation("جديد");

                                btn08001002002.Enabled = false;
                                btn08001002003.Enabled = true;
                                btn08001002004.Enabled = true;

                                txt08001002001.Enabled = false;
                                txt08001002002.Enabled = false;
                                txt08001002003.Enabled = false;
                                txt08001002004.Enabled = false;
                                txt08001002005.Enabled = false;

                                cbx001002001.Enabled = false;
                                cbx001002002.Enabled = false;
                                cbx001002003.Enabled = false;
                                cbx001002004.Enabled = false;

                                dgv08001.Enabled = true;
                                tv.Enabled = true;
                                tv.Focus();
                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);

                                txt08001002001.Text = "";
                            }

                        }
                        else if (btn08001002003.Text == Cultures.ReturnTranslation("إلغاء")) // تعديل
                        {

                            string Error = "";
                            if (cbx001002001.SelectedIndex == -1)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار وحدة التغليف");
                                cbx001002001.Focus();
                            }
                            else if (cbx001002002.Text == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار المنتج");
                                cbx001002002.Focus();
                            }
                            else if (txt08001002001.Text.Trim() == "" && txt08001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل قيمة وحدة القياس أو قيمة وحدة القياس والتغليف");
                                txt08001002001.Focus();
                            }
                            else if (cbx001002003.SelectedIndex == -1 && cbx001002004.SelectedIndex == -1)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار وحدة قياس أو وحدة قياس وتغليف");
                                cbx001002003.Focus();
                            }
                            else
                            {
                                // فحص البيانات للتأكد من عدم وجود تكرار في الجدول
                                bool? SameArabicName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002004.Text.Replace("'", ""), 1);
                                bool? SameEnglishName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002005.Text.Replace("'", ""), 2);

                                if (SameArabicName == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد وحدة بنفس الإسم العربي");
                                    txt08001002004.Focus();
                                }
                                else
                                {
                                    if (SameEnglishName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد وحدة بنفس الإسم الإنجليزي");
                                        txt08001002005.Focus();
                                    }
                                }
                            }

                            if (Error == "")
                            {


                                // فحص مشكلة الدوران
                                bool? CircleElementsTest;
                                if (cbx001002004.SelectedValue == null)
                                {
                                    // لا توجد مشكلة دوران لانه سينقل الى فارغ
                                    CircleElementsTest = false;
                                }
                                else
                                {

                                    TreeNode MoveNode = ElementsTools.TreeView_.Search(tv, Convert.ToInt32(txt08001002001.Text));
                                    TreeNode MoveNodeTo = ElementsTools.TreeView_.Search(tv, cbx001002004.SelectedValue);
                                    ElementsTools.TreeView_.CircleOfElements(tv ,MoveNode, MoveNodeTo);
                                    CircleElementsTest = ElementsTools.TreeView_.CircleOfElementsResut;
                                    ElementsTools.TreeView_.CircleOfElementsResut = null; // اعادتها لوضعها الطبيعي
                                }

                                if (CircleElementsTest == false)
                                {
                                    // لا توجد مشكلة دوران

                                    string[] result = null;
                                    DataTools.DataBases.Run(ref result  , @"update TblMeasureAndEncapsulationUnits set 
                                    EncapsulationUnitsNo = @EncapsulationUnitsNo , 
                                    ProductNumber = @ProductNumber ,
                                    MeasureUnitValue = @MeasureUnitValue ,
                                    MeasureUnitNo = @MeasureUnitNo  ,
                                    MeasureAndEncapsulationUnitNo_selfJoinValue = @MeasureAndEncapsulationUnitNo_selfJoinValue , 
                                    MeasureAndEncapsulationUnitNoSelfJoin = @MeasureAndEncapsulationUnitNoSelfJoin ,
                                    MeasureAndEncapsulationUnitNameAR = @MeasureAndEncapsulationUnitNameAR ,
                                    MeasureAndEncapsulationUnitNameEN = @MeasureAndEncapsulationUnitNameEN 
                                    where MeasureAndEncapsulationUnitNo = @MeasureAndEncapsulationUnitNo"
                                    ,
                                    CommandType.Text, new object[][] {
                                      new object[] { "@MeasureAndEncapsulationUnitNo", txt08001002001.Text.Replace("'", "") }
                                    , new object[] { "@EncapsulationUnitsNo", cbx001002001.SelectedValue }
                                    , new object[] { "@ProductNumber", cbx001002002.SelectedValue }
                                    , new object[] { "@MeasureUnitValue", txt08001002002.Text.Replace("'","") }
                                    , new object[] { "@MeasureUnitNo", cbx001002003.SelectedValue }
                                    , new object[] { "@MeasureAndEncapsulationUnitNo_selfJoinValue", txt08001002003.Text.Replace("'","") }
                                    , new object[] { "@MeasureAndEncapsulationUnitNoSelfJoin", cbx001002004.SelectedValue }
                                    , new object[] { "@MeasureAndEncapsulationUnitNameAR", txt08001002004.Text.Replace("'","") }
                                    , new object[] { "@MeasureAndEncapsulationUnitNameEN", txt08001002005.Text.Replace("'", "") }
                                    });

                                    if (result[1] == "succeeded")
                                    {

                                        // تحديث بيانات الجدول
                                        int rowIndex = 0;
                                        DataRow[] dataRows = TblMeasureAndEncapsulationUnits.Select("MeasureAndEncapsulationUnitNo = " + txt08001002001.Text);
                                        rowIndex = TblMeasureAndEncapsulationUnits.Rows.IndexOf(dataRows[0]);

                                        // table 1
                                        TblMeasureAndEncapsulationUnits.Rows[rowIndex][1] = cbx001002001.SelectedValue == null ? DBNull.Value : cbx001002001.SelectedValue;
                                        TblMeasureAndEncapsulationUnits.Rows[rowIndex][2] = cbx001002002.SelectedValue == null ? DBNull.Value : cbx001002002.SelectedValue;
                                        if (txt08001002002.Text.Trim() == "")
                                        {
                                            TblMeasureAndEncapsulationUnits.Rows[rowIndex][3] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureAndEncapsulationUnits.Rows[rowIndex][3] = txt08001002002.Text;
                                        }
                                        TblMeasureAndEncapsulationUnits.Rows[rowIndex][4] = cbx001002003.SelectedValue == null ? DBNull.Value : cbx001002003.SelectedValue;
                                        if (txt08001002003.Text.Trim() == "")
                                        {
                                            TblMeasureAndEncapsulationUnits.Rows[rowIndex][5] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureAndEncapsulationUnits.Rows[rowIndex][5] = txt08001002003.Text;
                                        }
                                        TblMeasureAndEncapsulationUnits.Rows[rowIndex][6] = cbx001002004.SelectedValue == null ? DBNull.Value : cbx001002004.SelectedValue;
                                        TblMeasureAndEncapsulationUnits.Rows[rowIndex][7] = txt08001002004.Text;
                                        TblMeasureAndEncapsulationUnits.Rows[rowIndex][8] = txt08001002005.Text;

                                        // table 2
                                        TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][1] = cbx001002001.SelectedValue == null ? DBNull.Value : cbx001002001.SelectedValue;
                                        TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][2] = cbx001002002.SelectedValue == null ? DBNull.Value : cbx001002002.SelectedValue;
                                        if (txt08001002002.Text.Trim() == "")
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][3] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][3] = txt08001002002.Text;
                                        }
                                        TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][4] = cbx001002003.SelectedValue == null ? DBNull.Value : cbx001002003.SelectedValue;
                                        if (txt08001002003.Text.Trim() == "")
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][5] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][5] = txt08001002003.Text;
                                        }
                                        TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][6] = cbx001002004.SelectedValue == null ? DBNull.Value : cbx001002004.SelectedValue;
                                        TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][7] = txt08001002004.Text;
                                        TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][8] = txt08001002005.Text;


                                        // هل هناك نودات محددة
                                        if (tv.SelectedNode == null)
                                        {
                                            // لم يتم تحديد اي نود

                                            // التحديث لأنه تم إضافة النود بدون التابعة له وذلك يتطلب تحديث الجدول بشكل كامل
                                            fillTblMeasureAndEncapsulationUnits();
                                            dgv08001EventsAndProperties(true);
                                            tvEventsAndProperties(true);
                                        }
                                        else
                                        {
                                            // تم تحديد نود

                                            // تحديث بيانات النود
                                            tv.SelectedNode.Text = GeneralVariables.cultureCode == "AR" ? txt08001002004.Text.Replace("'", "").Trim() : txt08001002005.Text.Replace("'", "").Trim();

                                            // تحريك النود
                                            {
                                                // مسح الالوان
                                                ElementsTools.TreeView_.changeColors(tv, DisplayMode.ReturnColor(myElementType.TreeView, ColorPropertyName.BackColor_1), DisplayMode.ReturnColor(myElementType.TreeView, ColorPropertyName.ForeColor_1));

                                                bool? A = null;
                                                bool? B = null;
                                                bool? C = null;
                                                bool? D = null;



                                                // هل النود يمتلك اب
                                                if (tv.SelectedNode.Parent == null)
                                                {
                                                    // لا هذه النود رئيسي ولا يمتلك اب

                                                    A = true;
                                                }
                                                else
                                                {
                                                    // نعم هذا النود تابع لاب

                                                    B = true;
                                                }


                                                // هل تم اختيار اب للانتقال اليه
                                                if (cbx001002004.SelectedValue == null)
                                                {
                                                    // لا لم يتم اختيار اب  اذن النقل يسيكون للرئيسي

                                                    C = true;

                                                }
                                                else
                                                {
                                                    // نعم تم اختيار اب والنقل سيكون لفرعي

                                                    D = true;

                                                }



                                                //التحريك

                                                if (A == true && C == true) // النقل من رئيسي الى رئيسي
                                                {
                                                    // لم يتم طلب التحريك
                                                }
                                                else if (A == true && D == true) // النقل من رئيسي الى فرعي
                                                {
                                                    TreeNode MoveNode = tv.SelectedNode;
                                                    TreeNode MoveNodeTo = ElementsTools.TreeView_.Search(tv, cbx001002004.SelectedValue);
                                                    tv.Nodes.Remove(tv.SelectedNode);
                                                    MoveNodeTo.Nodes.Add(MoveNode);
                                                }
                                                else if (B == true && C == true) //  النقل من فرعي الى رئيسي
                                                {
                                                    TreeNode MoveNode = tv.SelectedNode;
                                                    tv.SelectedNode.Parent.Nodes.Remove(tv.SelectedNode);
                                                    tv.Nodes.Add(MoveNode);
                                                }
                                                else if (B == true && D == true) // النقل من فرعي الى فرعي
                                                {
                                                    TreeNode MoveNode = tv.SelectedNode;
                                                    TreeNode MoveNodeTo = ElementsTools.TreeView_.Search(tv, cbx001002004.SelectedValue);

                                                    if (tv.SelectedNode.Parent.Tag.ToString().Trim() == cbx001002004.SelectedValue.ToString().Trim())
                                                    {
                                                        // لم يتم طلب التحريك
                                                    }
                                                    else
                                                    {
                                                        tv.SelectedNode.Parent.Nodes.Remove(tv.SelectedNode);
                                                        MoveNodeTo.Nodes.Add(MoveNode);
                                                    }
                                                }

                                            }

                                            //if (GeneralVariables._frmProducts09 != null) { GeneralVariables._frmProducts09.AllfrmProducts09ElementsEventsAndProperties(true, true); } // تحديث خصائص نموذج المنتجات
                                        }

                                    }
                                    else
                                    {
                                        // لم تنفذ على مستوى قاعدة البيانات
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("فشل التنفيذ"), MessageBoxStatus.Ok);
                                    }

                                }
                                else 
                                {
                                    if (CircleElementsTest == true)
                                    {
                                        // توجد مشكلة دوران
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لقد إرتكبت خطأ منطقي حيث يوجد عناصر كلاً منهما يتبع الاّخر"), MessageBoxStatus.Ok);
                                        GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> btn08001002003EventsAndProperties", DateTime.Now, "لقد إرتكبت خطأ منطقي حيث يوجد سجلين كلاً منهما يتبع الاّخر", "You made a logical error as there are two records that follow each other");
                                        ElementsTools.TreeView_.CircleOfElementsResut = null;
                                        cbx001002004.SelectedIndex = -1;
                                    }
                                    else
                                    {
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء قم بالمحاولة من جديد"), MessageBoxStatus.Ok);
                                        GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> btn08001002003EventsAndProperties", DateTime.Now, "رجاء قم بالمحاولة من جديد", "Please try again");

                                        ElementsTools.TreeView_.CircleOfElementsResut = null;
                                        cbx001002004.SelectedIndex = -1;
                                    }
                                }

                                //------------------

                                btn08001002003.Text = Cultures.ReturnTranslation("تعديل");

                                btn08001002001.Enabled = true;
                                btn08001002002.Enabled = false;
                                btn08001002004.Enabled = true;

                                txt08001002001.Enabled = false;
                                txt08001002004.Enabled = false;
                                txt08001002005.Enabled = false;
                                txt08001002002.Enabled = false;
                                txt08001002003.Enabled = false;

                                cbx001002001.Enabled = false;
                                cbx001002002.Enabled = false;
                                cbx001002003.Enabled = false;
                                cbx001002004.Enabled = false;

                                dgv08001.Enabled = true;
                                tv.Enabled = true;
                                tv.Focus();

                                dgv08001.Enabled = true;


                            }
                            else
                            {
                                btn08001002003.PerformClick();
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);
                                GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> btn08001002003EventsAndProperties", DateTime.Now, Error, Error);

                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> btn08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }




                };


            }


        }


        private void btn08001002003EventsAndProperties(bool Properties, bool Events = false) // تعديل 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn08001002003, "تعديل");

            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn08001002003, "تعديل", ColorPropertyName.ForeColor_1, true, true);
                btn08001002003.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Measure_And_Encapsulation_Units, PermissionType.Edit))
                    {
                        if (btn08001002003.Enabled)
                        {
                            if (btn08001002003.Text == Cultures.ReturnTranslation("تعديل"))
                            {
                                btn08001002003.Text = Cultures.ReturnTranslation("إلغاء");

                                btn08001002001.Enabled = false;
                                btn08001002002.Enabled = true;
                                btn08001002004.Enabled = false;

                                txt08001002001.Enabled = false;
                                txt08001002004.Enabled = true;
                                txt08001002005.Enabled = true;
                                txt08001002002.Enabled = true;
                                txt08001002003.Enabled = true;

                                cbx001002001.Enabled = true;
                                cbx001002002.Enabled = true;
                                cbx001002003.Enabled = true;
                                cbx001002004.Enabled = true;

                                dgv08001.Enabled = false;
                                tv.Enabled = false;

                                cbx001002001.Focus();
                            }
                            else
                            {
                                btn08001002003.Text = Cultures.ReturnTranslation("تعديل");

                                btn08001002001.Enabled = true;
                                btn08001002002.Enabled = false;
                                btn08001002004.Enabled = true;

                                txt08001002001.Enabled = false;
                                txt08001002004.Enabled = false;
                                txt08001002005.Enabled = false;
                                txt08001002002.Enabled = false;
                                txt08001002003.Enabled = false;

                                cbx001002001.Enabled = false;
                                cbx001002002.Enabled = false;
                                cbx001002003.Enabled = false;
                                cbx001002004.Enabled = false;

                                dgv08001.Enabled = true;
                                tv.Enabled = true;


                                dgv08001.Focus();
                            }
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> btn08001002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }



                };

            }
        }
        private void btn08001002004EventsAndProperties(bool Properties, bool Events = false) // حذف   
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn08001002004, "حذف");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn08001002004, "حذف", ColorPropertyName.ForeColor_1, true, true);
                btn08001002004.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Measure_And_Encapsulation_Units, PermissionType.Delete))
                        {
                            try
                            {

                                int? nodeNumber = null;
                                if (txt08001002001.Text.Trim() != "")
                                {
                                    nodeNumber = int.Parse(txt08001002001.Text);

                                }

                                if (nodeNumber != null)
                                {
                                    if (string.IsNullOrEmpty(txt08001002001.Text.ToString()))
                                    {
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء قم بتحديد السجل الذي تريد حذفه"), MessageBoxStatus.Ok);
                                        return;
                                    }
                                    string[] result = null;
                                    DataTools.DataBases.Run(ref result, "delete from TblMeasureAndEncapsulationUnits where MeasureAndEncapsulationUnitNo = @MeasureAndEncapsulationUnitNo", CommandType.Text, new object[][] { new object[] { "@MeasureAndEncapsulationUnitNo", txt08001002001.Text.ToString() } });


                                    if (result[1] == "succeeded")
                                    {

                                        if (result[0] == "1")
                                        {

                                            txt08001002001.Text = "";
                                            txt08001002004.Text = "";
                                            txt08001002005.Text = "";
                                            txt08001002002.Text = "";
                                            txt08001002003.Text = "";

                                            if (cbx001002001 != null && cbx001002001.Items.Count > 0) cbx001002001.SelectedIndex = -1;
                                            if (cbx001002002 != null && cbx001002002.Items.Count > 0) cbx001002002.SelectedIndex = -1;
                                            if (cbx001002003 != null && cbx001002003.Items.Count > 0) cbx001002003.SelectedIndex = -1;
                                            if (cbx001002004 != null && cbx001002004.Items.Count > 0) cbx001002004.SelectedIndex = -1;

                                            txtSearch.Text = "";


                                            if (tv.SelectedNode != null)
                                            {

                                                TblMeasureAndEncapsulationUnits.Rows.Remove(TblMeasureAndEncapsulationUnits.Select("MeasureAndEncapsulationUnitNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                TblMeasureAndEncapsulationUnitsForCbx.Rows.Remove(TblMeasureAndEncapsulationUnitsForCbx.Select("MeasureAndEncapsulationUnitNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                TreeNode deleteTreeNode = ElementsTools.TreeView_.Search(tv, nodeNumber);




                                                // حل مشكلة الانتقال الغير منطقي
                                                ElementsTools.TreeView_.StarchNextNode(tv, deleteTreeNode);

                                                // ازالة النود
                                                tv.Nodes.Remove(deleteTreeNode);

                                                // التوجه الى النود التالي
                                                tv.SelectedNode = ElementsTools.TreeView_.NextTreeNode;

                                            }
                                            else
                                            {
                                                if (dgv08001.SelectedRows != null)
                                                {
                                                    TblMeasureAndEncapsulationUnits.Rows.Remove(TblMeasureAndEncapsulationUnits.Select("MeasureAndEncapsulationUnitNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                    TblMeasureAndEncapsulationUnitsForCbx.Rows.Remove(TblMeasureAndEncapsulationUnitsForCbx.Select("MeasureAndEncapsulationUnitNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                }

                                            }

                                        }

                                        else
                                        {
                                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("عملية الحذف لم تتم"), MessageBoxStatus.Ok);
                                        }

                                    }
                                    else
                                    {
                                        //  Run تم تسجيل الخطأ من خلال دالة
                                    }

                                }
                                else
                                {
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء قم بتحديد السجل الذي تريد حذفه"), MessageBoxStatus.Ok);
                                }

                            }
                            catch (Exception ex)
                            {

                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), "btn08001002004EventsAndProperties .. " + ex.Message, MessageBoxStatus.Ok);
                            }

                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> btn08001002004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> btn08001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }

        private void tvEventsAndProperties(bool Properties, bool Events = false) // شجرة عرض التصنيفات
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    tv.Nodes.Clear();

                    ElementsTools.TreeView_.fillTreeView(tv, TblMeasureAndEncapsulationUnits, "MeasureAndEncapsulationUnitNoSelfJoin", 6, -1, 7, 8, 0);
                    ElementsTools.TreeView_.CustumProperties(tv);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                //fillTblMeasureAndEncapsulationUnits();
                try
                {
                    tv.Nodes.Clear();

                    ElementsTools.TreeView_.fillTreeView(tv, TblMeasureAndEncapsulationUnits, "MeasureAndEncapsulationUnitNoSelfJoin", 6, -1, 7, 8, 0);
                    ElementsTools.TreeView_.CustumProperties(tv);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


                tv.AfterSelect += delegate
                {
                    try
                    {
                        if (tv.SelectedNode.Tag is null) return;

                        foreach (DataGridViewRow row in dgv08001.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == tv.SelectedNode.Tag.ToString())
                            {
                                dgv08001.ClearSelection();
                                row.Selected = true;
                                break;
                            }
                        }

                        // تأثيرات التحديد
                        // اولا مسح التأثيرات السابقة
                        ElementsTools.TreeView_.changeColors(tv, DisplayMode.ReturnColor(myElementType.TreeView, ColorPropertyName.BackColor_1), DisplayMode.ReturnColor(myElementType.TreeView, ColorPropertyName.ForeColor_1));
                        // ثانيا عمل تأثير جديد
                        tv.SelectedNode.BackColor = Color.FromArgb(255, 0, 120, 215);
                        tv.SelectedNode.ForeColor = Color.White;

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }
                };


                tv.NodeMouseClick += delegate (object sender, TreeNodeMouseClickEventArgs e)
                {
                    if (btn08001002001.Text == Cultures.ReturnTranslation("إلغاء"))
                    {
                        btn08001002001.PerformClick();
                    }
                    if (btn08001002003.Text == Cultures.ReturnTranslation("إلغاء"))
                    {
                        //if(tv.SelectedNode != null)
                        //{
                        btn08001002003.PerformClick();
                        //}
                    }
                    // تنظيف مربع البحث
                    txtSearch.Clear();
                };

                tv.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    try
                    {
                        if (e.KeyData == Keys.Subtract)
                        {

                            btn08001002004.PerformClick();

                        }
                        else if (e.KeyData == Keys.Add)
                        {
                            if (tv.SelectedNode != null)
                            {
                                btn08001002003.PerformClick();
                            }
                        }
                        else if (e.KeyData == Keys.Enter)
                        {

                            btn08001002001.PerformClick();

                            if (cbx001002004 != null)
                            {

                                if (cbx001002004.Items.Count > 0)
                                {

                                    if (tv.SelectedNode != null)
                                    {

                                        if (tv.SelectedNode.Tag.ToString().Trim() != "")
                                        {

                                            if (cbx001002004.Items != null)
                                            {
                                                cbx001002004.SelectedValue = tv.SelectedNode.Tag;
                                            }
                                        }
                                        else
                                        {
                                            cbx001002004.Text = "";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }

        private void dgv08001EventsAndProperties(bool Properties, bool Events = false) // جدول عرض التصنيفات
        {
            if (Properties == true && Events == false)
            {
                try
                {

                    if (TblMeasureAndEncapsulationUnits is null) { TblMeasureAndEncapsulationUnits = new DataTable(); };
                    if (TblMeasureAndEncapsulationUnits.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblMeasureAndEncapsulationUnits;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الوحدة");
                        dgv08001.Columns[1].Visible = false;
                        dgv08001.Columns[2].Visible = false;
                        dgv08001.Columns[3].Visible = false;
                        dgv08001.Columns[4].Visible = false;
                        dgv08001.Columns[5].Visible = false;
                        dgv08001.Columns[6].Visible = false;
                        dgv08001.Columns[7].HeaderText = Cultures.ReturnTranslation("اسم الوحدة عربي");
                        dgv08001.Columns[8].HeaderText = Cultures.ReturnTranslation("اسم الوحدة انجليزي");

                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgv08001.Columns[7].Visible = true;
                            dgv08001.Columns[8].Visible = false;
                        }
                        else
                        {
                            dgv08001.Columns[7].Visible = false;
                            dgv08001.Columns[8].Visible = true;
                        }


                        dgv08001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgv08001.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv08001.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    else
                    {
                        if (dgv08001.Rows.Count > 0) { dgv08001.DataSource = null; dgv08001.Rows.Clear(); };
                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات

                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    //fillTblMeasureAndEncapsulationUnits();

                    if (TblMeasureAndEncapsulationUnits is null) { TblMeasureAndEncapsulationUnits = new DataTable(); };
                    if (TblMeasureAndEncapsulationUnits.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblMeasureAndEncapsulationUnits;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الوحدة");
                        dgv08001.Columns[1].Visible = false;
                        dgv08001.Columns[2].Visible = false;
                        dgv08001.Columns[3].Visible = false;
                        dgv08001.Columns[4].Visible = false;
                        dgv08001.Columns[5].Visible = false;
                        dgv08001.Columns[6].Visible = false;
                        dgv08001.Columns[7].HeaderText = Cultures.ReturnTranslation("اسم الوحدة عربي");
                        dgv08001.Columns[8].HeaderText = Cultures.ReturnTranslation("اسم الوحدة انجليزي");

                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgv08001.Columns[7].Visible = true;
                            dgv08001.Columns[8].Visible = false;
                        }
                        else
                        {
                            dgv08001.Columns[7].Visible = false;
                            dgv08001.Columns[8].Visible = true;
                        }


                        dgv08001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgv08001.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv08001.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    else
                    {
                        if (dgv08001.Rows.Count > 0) { dgv08001.DataSource = null; dgv08001.Rows.Clear(); };
                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات

                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                dgv08001.SelectionChanged += delegate
                {
                    try
                    {
                        if (dgv08001.Rows.Count > 0)
                        {

                            if (dgv08001.SelectedRows.Count == 0 || dgv08001.SelectedRows == null) return;

                            txt08001002001.Text = dgv08001.SelectedRows[0].Cells[0].Value.ToString();

                            if (cbx001002001 != null)
                            {
                                if (cbx001002001.Items.Count > 0)
                                {
                                    if (dgv08001.SelectedRows[0].Cells[1].Value.ToString() != null)
                                    {
                                        if (dgv08001.SelectedRows[0].Cells[1].Value.ToString().Trim() != "")
                                        {
                                            cbx001002001.SelectedValue = dgv08001.SelectedRows[0].Cells[1].Value.ToString();
                                        }
                                        else
                                        {
                                            cbx001002001.SelectedIndex = -1;
                                        }
                                    }
                                    else
                                    {
                                        cbx001002001.SelectedIndex = -1;
                                    }
                                }
                            }

                            if (cbx001002002 != null)
                            {
                                if (cbx001002002.Items.Count > 0)
                                {
                                    if (dgv08001.SelectedRows[0].Cells[2].Value.ToString() != null)
                                    {
                                        if (dgv08001.SelectedRows[0].Cells[2].Value.ToString().Trim() != "")
                                        {
                                            cbx001002002.SelectedValue = dgv08001.SelectedRows[0].Cells[2].Value.ToString();
                                        }
                                        else
                                        {
                                            cbx001002002.SelectedIndex = -1;
                                        }
                                    }
                                    else
                                    {
                                        cbx001002002.SelectedIndex = -1;
                                    }
                                }
                            }



                            txt08001002002.Text = dgv08001.SelectedRows[0].Cells[3].Value.ToString();

                            if (cbx001002003 != null)
                            {
                                if (cbx001002003.Items.Count > 0)
                                {
                                    if (dgv08001.SelectedRows[0].Cells[4].Value.ToString() != null)
                                    {
                                        if (dgv08001.SelectedRows[0].Cells[4].Value.ToString().Trim() != "")
                                        {
                                            cbx001002003.SelectedValue = dgv08001.SelectedRows[0].Cells[4].Value.ToString();
                                        }
                                        else
                                        {
                                            cbx001002003.SelectedIndex = -1;
                                        }
                                    }
                                    else
                                    {
                                        cbx001002003.SelectedIndex = -1;
                                    }
                                }
                            }

                            txt08001002003.Text = dgv08001.SelectedRows[0].Cells[5].Value.ToString();

                            if (cbx001002004 != null)
                            {
                                if (cbx001002004.Items.Count > 0)
                                {
                                    if (dgv08001.SelectedRows[0].Cells[6].Value.ToString() != null)
                                    {
                                        if (dgv08001.SelectedRows[0].Cells[6].Value.ToString().Trim() != "")
                                        {
                                            cbx001002004.SelectedValue = dgv08001.SelectedRows[0].Cells[6].Value.ToString();
                                        }
                                        else
                                        {
                                            cbx001002004.SelectedIndex = -1;
                                        }
                                    }
                                    else
                                    {
                                        cbx001002004.SelectedIndex = -1;
                                    }
                                }
                            }

                            txt08001002004.Text = dgv08001.SelectedRows[0].Cells[7].Value.ToString();
                            txt08001002005.Text = dgv08001.SelectedRows[0].Cells[8].Value.ToString();



                            tv.SelectedNode = ElementsTools.TreeView_.Search(tv, dgv08001.SelectedRows[0].Cells[0].Value);

                            // تحديث بيانات النماذج الفرعية
                            if (pnl08001002001.Controls.Count>0)
                            {
                                if (pnl08001002001.Controls[0].Name == "frmBarcode")
                                {
                                    (pnl08001002001.Controls[0] as frmBarcode).fillTblBarcode();
                                }
                                else if (pnl08001002001.Controls[0].Name == "frmFreeUnitsOffers")
                                {
                                    (pnl08001002001.Controls[0] as frmFreeUnitsOffers).fillTblFreeUnitsOffers();
                                }
                                else if (pnl08001002001.Controls[0].Name == "frmPriceCategories")
                                {
                                    (pnl08001002001.Controls[0] as frmPriceCategories).fillTblPriceCategories();
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                };

                dgv08001.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    try
                    {
                        if (e.KeyData == Keys.Subtract)
                        {

                            btn08001002004.PerformClick();

                        }
                        else if (e.KeyData == Keys.Enter)
                        {
                            if (dgv08001.SelectedRows != null)
                            {
                                btn08001002003.PerformClick();
                            }
                        }
                        else if (e.KeyData == Keys.Add)
                        {

                            btn08001002001.PerformClick();

                            if (cbx001002004 != null)
                            {

                                if (cbx001002004.Items.Count > 0)
                                {

                                    if (dgv08001.SelectedRows != null)
                                    {

                                        if (dgv08001.SelectedRows[0].Cells[0].Value.ToString().Trim() != "")
                                        {

                                            if (cbx001002004.Items != null)
                                            {
                                                cbx001002004.SelectedValue = dgv08001.SelectedRows[0].Cells[0].Value.ToString().Trim();
                                            }
                                        }
                                        else
                                        {
                                            cbx001002004.Text = "";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                dgv08001.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات
                };
            }
        }



        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- البحث
        private void lblSearchEventsAndProperties(bool Properties, bool Events = false) // ملصق البحث عن التصنيفات 
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

        private void txtSearchEventsAndProperties(bool Properties, bool Events = false) // مربع نص البحث عن التصنيفات
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txtSearch);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtSearch, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txtSearch.TextChanged += delegate
                {
                    try
                    {
                        DataView dv = new DataView(TblMeasureAndEncapsulationUnits);
                        string filter = "";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            filter = "MeasureAndEncapsulationUnitNameAR like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        else
                        {
                            filter = "MeasureAndEncapsulationUnitNameEN like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        dv.RowFilter = filter;
                        dgv08001.DataSource = dv;
                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> txtSearchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }


        //------------------------------ 

        DataTable TblMeasureAndEncapsulationUnits = new DataTable(); // جدول وحدات القياس والتغليف للجدول السفلي 
        DataTable TblMeasureAndEncapsulationUnitsForCbx = new DataTable(); // جدول وحدات القياس والتغليف للقائمة المنسدلة
        DataTable TblEncapsulationUnits = new DataTable(); // جدول وحدات التغليف 
        DataTable TblMeasureUnit = new DataTable(); // جدول وحدات القياس
        DataTable TblProducts = new DataTable(); // جدول المنتجات


        private void fillTblMeasureAndEncapsulationUnits()// تعبئة جدول وحدات القياس والتغليف
        {
            try
            {
                if (TblMeasureAndEncapsulationUnits is null) { TblMeasureAndEncapsulationUnits = new DataTable(); };
                if (TblMeasureAndEncapsulationUnits.Rows.Count > 0) { TblMeasureAndEncapsulationUnits.Rows.Clear(); }
                if (TblMeasureAndEncapsulationUnitsForCbx is null) { TblMeasureAndEncapsulationUnitsForCbx = new DataTable(); };
                if (TblMeasureAndEncapsulationUnitsForCbx.Rows.Count > 0) { TblMeasureAndEncapsulationUnitsForCbx.Rows.Clear(); }

                TblMeasureAndEncapsulationUnits = DataTools.DataBases.ReadTabel("select * from TblMeasureAndEncapsulationUnits ");
                TblMeasureAndEncapsulationUnitsForCbx = DataTools.DataBases.ReadTabel("select * from TblMeasureAndEncapsulationUnits ");
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> fillTblMeasureAndEncapsulationUnits ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        private void fillTblEncapsulationUnits()// تعبئة جدول وحدات التغليف
        {
            try
            {
                if (TblEncapsulationUnits is null) { TblEncapsulationUnits = new DataTable(); };
                if (TblEncapsulationUnits.Rows.Count > 0) { TblEncapsulationUnits.Rows.Clear(); }

                TblEncapsulationUnits = DataTools.DataBases.ReadTabel("select * from TblEncapsulationUnits ");

            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> fillTblEncapsulationUnits ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        private void fillTblMeasureUnit()// تعبئة جدول وحدات القياس 
        {
            try
            {
                if (TblMeasureUnit is null) { TblMeasureUnit = new DataTable(); };
                if (TblMeasureUnit.Rows.Count > 0) { TblMeasureUnit.Rows.Clear(); }

                TblMeasureUnit = DataTools.DataBases.ReadTabel("select * from TblMeasureUnit ");
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> fillTblMeasureUnit ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        private void fillTblProducts()// تعبئة جدول المنتجات
        {
            try
            {
                if (TblProducts is null) { TblProducts = new DataTable(); };
                if (TblProducts.Rows.Count > 0) { TblProducts.Rows.Clear(); }

                TblProducts = DataTools.DataBases.ReadTabel("select * from TblProducts ");
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> fillTblProducts ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        //----------------------  القوائم الجانبية

        private void btnBarcodeEventsAndProperties(bool Properties, bool Events = false) // زر فتح الباركود 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btnBarcode, "الباركود");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btnBarcode, "الباركود", ColorPropertyName.ForeColor_1, true, true);

                btnBarcode.Click += delegate
                {

                    if (Permissions.AccountHavePermission(PermissionObjectes.Barcode, PermissionType.Show))
                    {
                        foreach (Control c in pnl08001002001.Controls)
                        {
                            c.Dispose();
                        }
                        frmBarcode frm = new frmBarcode();
                        frm.TopLevel = false;
                        frm.TopMost = true;
                        pnl08001002001.Controls.Add(frm);
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.Show();
                        frm.fillTblBarcode();
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> btnBarcodeEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }

                };

            }

        }

        private void btnPriceCategoriesEventsAndProperties(bool Properties, bool Events = false) // زر فتح الفئات السعرية 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btnPriceCategories, "الفئات السعرية");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btnPriceCategories, "الفئات السعرية", ColorPropertyName.ForeColor_1, true, true);

                btnPriceCategories.Click += delegate
                {

                    if (Permissions.AccountHavePermission(PermissionObjectes.Price_Categories, PermissionType.Show))
                    {
                        foreach (Control c in pnl08001002001.Controls)
                        {
                            c.Dispose();
                        }

                        frmPriceCategories frm = new frmPriceCategories();
                        frm.TopLevel = false;
                        frm.TopMost = true;
                        pnl08001002001.Controls.Add(frm);
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.Show();
                        frm.fillTblPriceCategories();
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> btnPriceCategoriesEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }

                };

            }

        }

        //frmFreeUnitsOffers
        private void btnFreeUnitsOffersEventsAndProperties(bool Properties, bool Events = false) // زر فتح عروض الوحدات المجانية 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btnFreeUnitsOffers, "عروض الوحدات المجانية");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btnFreeUnitsOffers, "عروض الوحدات المجانية", ColorPropertyName.ForeColor_1, true, true);

                btnFreeUnitsOffers.Click += delegate
                {

                    if (Permissions.AccountHavePermission(PermissionObjectes.Free_Unit_Offers, PermissionType.Show))
                    {
                        foreach (Control c in pnl08001002001.Controls)
                        {
                            c.Dispose();
                        }
                        frmFreeUnitsOffers frm = new frmFreeUnitsOffers();
                        frm.TopLevel = false;
                        frm.TopMost = true;
                        pnl08001002001.Controls.Add(frm);
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.Show();
                        frm.fillTblFreeUnitsOffers();
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> btnFreeUnitsOffersEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }

                };

            }

        }


        private void pnl08001002001EventsAndProperties(bool Properties, bool Events = false) // الحاوية اليسرى
        {

            if (Properties == true & Events == false)
            {
                //ElementsTools.panel_.CustumProperties(pnl08001002001);
                pnl08001002001.BorderStyle = BorderStyle.FixedSingle;

                // تحديث بيانات النماذج الفرعية
                if (pnl08001002001.Controls.Count > 0)
                {
                    if (pnl08001002001.Controls[0].Name == "frmBarcode")
                    {
                        (pnl08001002001.Controls[0] as frmBarcode).AllEventsAndProperties(true);
                    }
                    else if (pnl08001002001.Controls[0].Name == "frmFreeUnitsOffers")
                    {
                        (pnl08001002001.Controls[0] as frmFreeUnitsOffers).AllEventsAndProperties(true);
                    }
                    else if (pnl08001002001.Controls[0].Name == "frmPriceCategories")
                    {
                        (pnl08001002001.Controls[0] as frmPriceCategories).AllEventsAndProperties(true);
                    }
                }
            }
            else if (Properties == true & Events == true)
            {
                //ElementsTools.panel_.CustumProperties(pnl08001002001, ColorPropertyName.BackColor_3, true, true);
                pnl08001002001.BorderStyle = BorderStyle.FixedSingle;


                // تحديث بيانات النماذج الفرعية
                if (pnl08001002001.Controls.Count > 0)
                {
                    if (pnl08001002001.Controls[0].Name == "frmBarcode")
                    {
                        (pnl08001002001.Controls[0] as frmBarcode).AllEventsAndProperties(true);
                    }
                    else if (pnl08001002001.Controls[0].Name == "frmFreeUnitsOffers")
                    {
                        (pnl08001002001.Controls[0] as frmFreeUnitsOffers).AllEventsAndProperties(true);
                    }
                    else if (pnl08001002001.Controls[0].Name == "frmPriceCategories")
                    {
                        (pnl08001002001.Controls[0] as frmPriceCategories).AllEventsAndProperties(true);
                    }
                }

                pnl08001002001.FontChanged += delegate
                {
                    if(pnl08001002001.Controls.Count>0)
                    {
                        pnl08001002001.Controls[0].Font = pnl08001002001.Font;
                    }
                };
            }
        }




        // ------------  اداة التلميح
        ToolTip toolTip1;
        private void tooltip()
        {
            try
            {
                if (toolTip1 == null)
                {
                    toolTip1 = new ToolTip();

                    // Set up the delays for the ToolTip.
                    toolTip1.AutoPopDelay = 5000;
                    toolTip1.InitialDelay = 1000;
                    toolTip1.ReshowDelay = 500;
                    // Force the ToolTip text to be displayed whether or not the form is active.
                    toolTip1.ShowAlways = true;
                }


                toolTip1.SetToolTip(this.tv, Cultures.ReturnTranslation("إنتر للتعديل و + للإضافة و - للحذف"));  // تلميح
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmMeasureAndEncapsulationUnits14 >> tooltip ", DateTime.Now, ex.Message, ex.Message);
            }

        }



    }


}

