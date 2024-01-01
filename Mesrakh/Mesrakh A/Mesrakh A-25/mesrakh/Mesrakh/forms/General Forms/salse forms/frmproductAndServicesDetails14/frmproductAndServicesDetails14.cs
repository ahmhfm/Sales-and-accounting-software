// ملاحظة تم تغيير المنتجات الى السلع والخدمات ومن تغيير وحدات القياس والتغليف على الوحدات 

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
    public partial class frmproductAndServicesDetails14 : Form  // نموذج وحدات القياس والتغليف
    {
        public frmproductAndServicesDetails14()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        //----------------------
        DataTable tblManufacturers = new DataTable(); // جدول الشركات الصانعة 
        private void filltblManufacturers()// تعبئة جدول الشركات الصانعة
        {
            try
            {
                if (tblManufacturers == null) tblManufacturers = new DataTable();
                if (tblManufacturers.Rows.Count > 0) { tblManufacturers.Rows.Clear(); }

                tblManufacturers = DataTools.DataBases.ReadTabel("select * from TblManufacturers ");

            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> filltblManufacturers ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        //----------------------
        // كتابة اسم المنتج
        private void WritingProductName()
        {
            string DetailedNameForProductOrServiceAr = ""; //------------ الاسم التفصيلي للسلعة او الخدمة عربي
            string DetailedNameForProductOrServiceEn = ""; //------------ الاسم التفصيلي للسلعة او الخدمة انجليزي
            string EncapsulationUnitNameAr = "";  //---------------------- اسم وحدة التغليف عربي
            string EncapsulationUnitNameEn = "";  //---------------------- اسم وحدة التغليف انجليزي
            string ProductOrServiceNameAr = ""; //---------------------------------   اسم السلعة او الخدمة عربي
            string ProductOrServiceNameEn = ""; //---------------------------------   اسم السلعة او الخدمة انجليزي
            string MeasureUnitNameAr = "";  //---------------------------- اسم وحدة القياس عربي
            string MeasureUnitNameEn = "";  //---------------------------- اسم وحدة القياس انجليزي
            string MeasureUnitValue = "";  //--------------------------- قيمة وحدة القياس
            string DetailedNameForProductOrServiceArSelfJoinAr = "";  //--- اسم تفاصيل السلعة او الخدمة المتبوعة عربي
            string DetailedNameForProductOrServiceEnSelfJoinEn = "";  //--- اسم تفاصيل السلعة او الخدمة المتبوعة انجليزي
            string UnitDetailsValue = ""; //--- قيمة وحدة تفاصيل السلعة او الخدمة المتبوعة


            string ManufacturerArabicName = ""; //--- الشركة الصانعة عربي
            string ManufacturerEnglishName = ""; //--- الشركة الصانعة انجليزي
            string ModelOrArabicDescription = ""; //--- الموديل او الوصف عربي  
            string ModelOrEnglishDescription = ""; //--- الموديل او الوصف انجليزي  


            if (TblProductsAndServices != null) //  اسم السلعة او الخدمة عربي
            {
                if (TblProductsAndServices.Rows.Count > 0)
                {
                    if (cbx001002001.Items.Count > 0)
                    {
                        if (cbx001002001.SelectedItem != null)
                        {
                            ProductOrServiceNameAr = TblProductsAndServices.Rows[cbx001002001.SelectedIndex][2].ToString();
                        }
                    }
                }
            }
            if (TblProductsAndServices != null) //  اسم السلعة او الخدمة انجليزي
            {
                if (TblProductsAndServices.Rows.Count > 0)
                {
                    if (cbx001002001.Items.Count > 0)
                    {
                        if (cbx001002001.SelectedItem != null)
                        {
                            ProductOrServiceNameEn = TblProductsAndServices.Rows[cbx001002001.SelectedIndex][3].ToString();
                        }
                    }
                }
            }

            if (TblEncapsulationUnits != null) //  اسم وحدة التغليف عربي
            {
                if (TblEncapsulationUnits.Rows.Count > 0)
                {
                    if (cbx001002002.Items.Count > 0)
                    {
                        if (cbx001002002.SelectedItem != null)
                        {
                            EncapsulationUnitNameAr = TblEncapsulationUnits.Rows[cbx001002002.SelectedIndex][1].ToString();
                        }
                    }
                }
            }
            if (TblEncapsulationUnits != null) //  اسم وحدة التغليف انجليزي
            {
                if (TblEncapsulationUnits.Rows.Count > 0)
                {
                    if (cbx001002002.Items.Count > 0)
                    {
                        if (cbx001002002.SelectedItem != null)
                        {
                            EncapsulationUnitNameEn = TblEncapsulationUnits.Rows[cbx001002002.SelectedIndex][2].ToString();
                        }
                    }
                }
            }


            if (TblMeasureUnit != null)//  اسم وحدة القياس عربي
            {
                if (TblMeasureUnit.Rows.Count > 0)
                {
                    if (cbx001002003.Items.Count > 0)
                    {
                        if (cbx001002003.SelectedItem != null)
                        {
                            MeasureUnitNameAr = TblMeasureUnit.Rows[cbx001002003.SelectedIndex][1].ToString();
                        }
                    }
                }
            }

            if (TblMeasureUnit != null)//  اسم وحدة القياس انجليزي
            {
                if (TblMeasureUnit.Rows.Count > 0)
                {
                    if (cbx001002003.Items.Count > 0)
                    {
                        if (cbx001002003.SelectedItem != null)
                        {
                            MeasureUnitNameEn = TblMeasureUnit.Rows[cbx001002003.SelectedIndex][2].ToString();
                        }
                    }
                }
            }

            MeasureUnitValue = txt08001002002.Text.Trim(); //  قيمة وحدة القياس عربي

            if (TblMeasureAndEncapsulationUnitsForCbx != null)//   اسم الوحدة المتبوعة عربي
            {
                if (TblMeasureAndEncapsulationUnitsForCbx.Rows.Count > 0)
                {
                    if (cbx001002004.Items.Count > 0)
                    {
                        if (cbx001002004.SelectedItem != null)
                        {
                            DetailedNameForProductOrServiceArSelfJoinAr = TblMeasureAndEncapsulationUnitsForCbx.Rows[cbx001002004.SelectedIndex][10].ToString();
                        }
                    }
                }
            }
            if (TblMeasureAndEncapsulationUnitsForCbx != null)//  اسم الوحدة المتبوعة انجليزي
            {
                if (TblMeasureAndEncapsulationUnitsForCbx.Rows.Count > 0)
                {
                    if (cbx001002004.Items.Count > 0)
                    {
                        if (cbx001002004.SelectedItem != null)
                        {
                            DetailedNameForProductOrServiceEnSelfJoinEn = TblMeasureAndEncapsulationUnitsForCbx.Rows[cbx001002004.SelectedIndex][11].ToString();
                        }
                    }
                }
            }


            UnitDetailsValue = txt08001002003.Text.Trim();//  قيمة الوحدة المتبوعة

            if (tblManufacturers != null) //  اسم الشركة الصانعة عربي
            {
                if (tblManufacturers.Rows.Count > 0)
                {
                    if (cbx001002005.Items.Count > 0)
                    {
                        if (cbx001002005.SelectedItem != null)
                        {
                            ManufacturerArabicName = tblManufacturers.Rows[cbx001002005.SelectedIndex][1].ToString();
                        }
                    }
                }
            }

            if (tblManufacturers != null) //  اسم الشركة الصانعة انجليزي
            {
                if (tblManufacturers.Rows.Count > 0)
                {
                    if (cbx001002005.Items.Count > 0)
                    {
                        if (cbx001002005.SelectedItem != null)
                        {
                            ManufacturerEnglishName = tblManufacturers.Rows[cbx001002005.SelectedIndex][2].ToString();
                        }
                    }
                }
            }

            ModelOrArabicDescription = txt08001002007.Text.Trim();//  الموديل او الوصف عربي
            ModelOrEnglishDescription = txt08001002004.Text.Trim();//  الموديل او الوصف انجليزي



            //------------اسم تفاصيل السلعة او الخدمة 
            if (UnitDetailsValue == "")
            {
                // العربي
                if(!((EncapsulationUnitNameAr == "علبة" && MeasureUnitValue == "1" && MeasureUnitNameAr == "قطعة")||(EncapsulationUnitNameAr == "Box" && MeasureUnitValue == "1" && MeasureUnitNameAr == "Piece")))
                {
                    if(EncapsulationUnitNameAr != "بدون" && EncapsulationUnitNameEn != "non")
                    {
                        if (EncapsulationUnitNameAr != "بدون" && EncapsulationUnitNameEn != "non") { DetailedNameForProductOrServiceAr = EncapsulationUnitNameAr; } //--------- اسم وحدة التغليف عربي

                        DetailedNameForProductOrServiceAr += " " + ProductOrServiceNameAr; //------------ اسم السلعة او الخدمة عربي
                        DetailedNameForProductOrServiceAr += " " + ManufacturerArabicName; //------------ الشركة الصانعة
                        DetailedNameForProductOrServiceAr += " " + ModelOrArabicDescription; //------------ الموديل او الوصف

                        DetailedNameForProductOrServiceAr += " " + MeasureUnitValue; //------ قيمة وحدة القياس
                        DetailedNameForProductOrServiceAr += " " + MeasureUnitNameAr; //------ اسم وحدة القياس
                    }
                    else
                    {
                        DetailedNameForProductOrServiceAr += " " + ProductOrServiceNameAr; //------------ اسم السلعة او الخدمة عربي
                        DetailedNameForProductOrServiceAr += " " + ManufacturerArabicName; //------------ الشركة الصانعة
                        DetailedNameForProductOrServiceAr += " " + ModelOrArabicDescription; //------------ الموديل او الوصف

                        DetailedNameForProductOrServiceAr += " " + MeasureUnitValue; //------ قيمة وحدة القياس
                        DetailedNameForProductOrServiceAr += " " + MeasureUnitNameAr; //------ اسم وحدة القياس
                    }

                }
                else
                {
                    DetailedNameForProductOrServiceAr += " " + ProductOrServiceNameAr; //------------ اسم السلعة او الخدمة عربي
                    DetailedNameForProductOrServiceAr += " " + ManufacturerArabicName; //------------ الشركة الصانعة
                    DetailedNameForProductOrServiceAr += " " + ModelOrArabicDescription; //------------ الموديل او الوصف
                }



                // الانجليزي
                if (!((EncapsulationUnitNameAr == "علبة" && MeasureUnitValue == "1" && MeasureUnitNameAr == "قطعة") || (EncapsulationUnitNameAr == "Box" && MeasureUnitValue == "1" && MeasureUnitNameAr == "Piece")))
                {
                    if (EncapsulationUnitNameAr != "بدون" && EncapsulationUnitNameEn != "non")
                    {


                        DetailedNameForProductOrServiceEn += " " + ManufacturerEnglishName; //------------ الشركة الصانعة
                        DetailedNameForProductOrServiceEn += " " + ProductOrServiceNameEn; //------------ اسم السلعة او الخدمة عربي
                        DetailedNameForProductOrServiceEn += " " + ModelOrEnglishDescription; //------------ الموديل او الوصف


                        if (EncapsulationUnitNameAr != "بدون" && EncapsulationUnitNameEn != "non") { DetailedNameForProductOrServiceEn += " " + EncapsulationUnitNameEn; } //--------- اسم وحدة التغليف انجليزي

                        DetailedNameForProductOrServiceEn += " " + MeasureUnitValue; //------ قيمة وحدة القياس
                        DetailedNameForProductOrServiceEn += " " + MeasureUnitNameEn; //------ اسم وحدة القياس

                    } //--------- اسم وحدة التغليف انجليزي
                    else
                    {
                        DetailedNameForProductOrServiceEn += " " + ManufacturerEnglishName; //------------ الشركة الصانعة
                        DetailedNameForProductOrServiceEn += " " + ProductOrServiceNameEn; //------------ اسم السلعة او الخدمة عربي
                        DetailedNameForProductOrServiceEn += " " + ModelOrEnglishDescription; //------------ الموديل او الوصف

                        DetailedNameForProductOrServiceEn += " " + MeasureUnitValue; //------ قيمة وحدة القياس
                        DetailedNameForProductOrServiceEn += " " + MeasureUnitNameEn; //------ اسم وحدة القياس
                    }

                }
                else
                {
                    DetailedNameForProductOrServiceEn += " " + ManufacturerEnglishName; //------------ الشركة الصانعة
                    DetailedNameForProductOrServiceEn += " " + ProductOrServiceNameEn; //------------ اسم السلعة او الخدمة عربي
                    DetailedNameForProductOrServiceEn += " " + ModelOrEnglishDescription; //------------ الموديل او الوصف
                }

            }
            else
            {
                //العربي
                if (EncapsulationUnitNameAr != "بدون" && EncapsulationUnitNameEn != "non") { DetailedNameForProductOrServiceAr = EncapsulationUnitNameAr; } //--------- اسم وحدة التغليف عربي
                DetailedNameForProductOrServiceAr += " يحوي ";
                DetailedNameForProductOrServiceAr += " " + UnitDetailsValue; //--- قيمة وحدة تفاصيل السلعة او الخدمة المتبوعة
                DetailedNameForProductOrServiceAr += " ( ";
                DetailedNameForProductOrServiceAr += " " + DetailedNameForProductOrServiceArSelfJoinAr; //---  اسم وحدة تفاصيل السلعة او الخدمة المتبوعة عربي
                DetailedNameForProductOrServiceAr += " ) ";
                // الانجليزي
                if (EncapsulationUnitNameAr != "بدون" && EncapsulationUnitNameEn != "non") { DetailedNameForProductOrServiceEn = EncapsulationUnitNameEn; } //--------- اسم وحدة التغليف انجليزي
                DetailedNameForProductOrServiceEn += " Have ";
                DetailedNameForProductOrServiceEn += " " + UnitDetailsValue; //---  قيمة وحدة تفاصيل السلعة او الخدمة المتبوعة
                DetailedNameForProductOrServiceEn += " ( ";
                DetailedNameForProductOrServiceEn += " " + DetailedNameForProductOrServiceEnSelfJoinEn; //--- اسم وحدة تفاصيل السلعة او الخدمة المتبوعة انجليزي 
                DetailedNameForProductOrServiceEn += " ) ";
            }

            txt08001002005.Text = DetailedNameForProductOrServiceAr;
            txt08001002008.Text = DetailedNameForProductOrServiceAr;
            txt08001002006.Text = DetailedNameForProductOrServiceEn;
            txt08001002009.Text = DetailedNameForProductOrServiceEn;
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmproductAndServicesDetails14EventsAndProperties(Properties, Events); // النموذج
            pnl08001EventsAndProperties(Properties, Events);// الحاوية الرئيسية
            pnl08001001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl08001001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl08001002EventsAndProperties(Properties, Events); // الحاوية الثانية

            //-----

            frmproductAndServicesDetails14EventsAndProperties(Properties, Events); // النموذج 
            pnl08001EventsAndProperties(Properties, Events); // الحاوية الرئيسية
            pnl08001001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl08001001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl08001002EventsAndProperties(Properties, Events); // الحاوية الثانية

            lbl08001002001EventsAndProperties(Properties, Events); // ملصق رقم تفاصيل الوحدة 
            txt08001002001EventsAndProperties(Properties, Events); // مربع نص رقم تفاصيل الوحدة
            lbl08001002002EventsAndProperties(Properties, Events); // ملصق رقم السلعة او الخدمة 
            cbx001002001EventsAndProperties(Properties, Events); // قائمة منسدلة رقم السلعة او الخدمة
            lbl08001002003EventsAndProperties(Properties, Events); // ملصق رقم وحدة التغليف 
            cbx001002002EventsAndProperties(Properties, Events); // قائمة منسدلة رقم وحدة التغليف
            lbl08001002004EventsAndProperties(Properties, Events); // ملصق قيمة وحدةالقياس 
            txt08001002002EventsAndProperties(Properties, Events); // مربع نص قيمة وحدةالقياس
            cbx001002003EventsAndProperties(Properties, Events); // قائمة منسدلة رقم وحدة القياس
            lbl08001002005EventsAndProperties(Properties, Events); // ملصق قيمة الوحدة المتبوعة 
            txt08001002003EventsAndProperties(Properties, Events); // مربع نص قيمة الوحدة المتبوعة
            cbx001002004EventsAndProperties(Properties, Events); // قائمة منسدلة الوحدة المتبوعة
            lbl08001002006EventsAndProperties(Properties, Events); // ملصق الشركة الصانعة 
            cbx001002005EventsAndProperties(Properties, Events); // قائمة منسدلة الشركة الصانعة
            lbl08001002009EventsAndProperties(Properties, Events); // ملصق  الموديل او وصف السلعة عربي 
            txt08001002007EventsAndProperties(Properties, Events); // مربع نص الموديل او وصف السلعة عربي
            lbl08001002007EventsAndProperties(Properties, Events); // ملصق الموديل او وصف السلعة إنجليزي 
            txt08001002004EventsAndProperties(Properties, Events); // مربع نص الموديل او وصف السلعة إنجليزي
            lbl08001002008EventsAndProperties(Properties, Events); // ملصق الاسم المفصل للمنتج اوالخدمة
            txt08001002005EventsAndProperties(Properties, Events); // مربع نص الاسم المفصل للمنتج اوالخدمة عربي
            txt08001002006EventsAndProperties(Properties, Events); // مربع نص اسم وحدة القياس والتغليف انجليزي
            lbl08001002010EventsAndProperties(Properties, Events); //  ملصق الاسم المختصر للمنتج او الخدمة بالعربي  
            txt08001002008EventsAndProperties(Properties, Events); // مربع نص الاسم المختصر للمنتج او الخدمة بالعربي
            lbl08001002011EventsAndProperties(Properties, Events); //  ملصق الاسم المختصر للمنتج او الخدمة بالانجليزي  
            txt08001002009EventsAndProperties(Properties, Events); // مربع نص الاسم المختصر للمنتج او الخدمة بالانجليزي
            lbl08001002012EventsAndProperties(Properties, Events); //  ملصق كمية المخزون  
            txt08001002010EventsAndProperties(Properties, Events); // مربع نص كمية المخزون
            lbl08001002013EventsAndProperties(Properties, Events); //  ملصق تكلفة المخزون  
            txt08001002011EventsAndProperties(Properties, Events); // مربع نص تكلفة المخزون
            lbl08001002014EventsAndProperties(Properties, Events); //  ملصق تكلفة الوحدة  
            txt08001002012EventsAndProperties(Properties, Events); // مربع نص تكلفة الوحدة
            lbl08001002015EventsAndProperties(Properties, Events); // ملصق أسلوب إحتساب سعر البيع 
            cbx001002006EventsAndProperties(Properties, Events); // قائمة منسدلة أسلوب إحتساب سعر البيع


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

        private void frmproductAndServicesDetails14EventsAndProperties(bool Properties, bool Events = false) // النموذج 
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
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "تفاصيل السلع والخدمات", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "تفاصيل السلع والخدمات", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
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


        private void lbl08001002001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم تفاصيل الوحدة 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم التفصيل", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "رقم التفصيل", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم تفاصيل الوحدة
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002001, "",10);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002001, "",10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt08001002001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx001002001.Select();
                    }
                };
            }
        }

        private void lbl08001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم السلعة او الخدمة 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "السلعة او الخدمة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "السلعة او الخدمة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void cbx001002001EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة رقم السلعة او الخدمة
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblProductsAndServices is null) return;
                    if (TblProductsAndServices.Rows.Count > 0)
                    {
                        cbx001002001.DataSource = TblProductsAndServices;
                        cbx001002001.ValueMember = "ProductOrServiceNumber";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002001.DisplayMember = "ProductOrServiceNameAR";
                        }
                        else
                        {
                            cbx001002001.DisplayMember = "ProductOrServiceNameEN";
                        }

                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001002001);

                }


                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> cbx001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblProductsAndServices();
                    if (TblProductsAndServices is null) return;
                    if (TblProductsAndServices.Rows.Count > 0)
                    {
                        cbx001002001.DataSource = TblProductsAndServices;
                        cbx001002001.ValueMember = "ProductOrServiceNumber";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002001.DisplayMember = "ProductOrServiceNameAR";
                        }
                        else
                        {
                            cbx001002001.DisplayMember = "ProductOrServiceNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001002001, "", true, true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> cbx001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx001002001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx001002002.Select();
                    }
                };

                cbx001002001.SelectedIndexChanged += delegate
                {
                    if(cbx001002001.SelectedItem != null)
                    {

                        if(Convert.ToBoolean((cbx001002001.DataSource as DataTable).Rows[cbx001002001.SelectedIndex][1].ToString()))
                        {
                            lbl08001002003.Visible = true;
                            lbl08001002004.Visible = true;
                            lbl08001002005.Visible = true;
                            lbl08001002006.Visible = true;
                            lbl08001002007.Visible = true;
                            lbl08001002009.Visible = true;
                            lbl08001002014.Visible = true;

                            txt08001002002.Visible = true;
                            txt08001002003.Visible = true;
                            txt08001002004.Visible = true;
                            txt08001002007.Visible = true;

                            cbx001002002.Visible = true;
                            cbx001002003.Visible = true;
                            cbx001002004.Visible = true;
                            cbx001002005.Visible = true;
                            cbx001002006.Visible = true;
                        }
                        else
                        {
                            lbl08001002003.Visible = false;
                            lbl08001002004.Visible = false;
                            lbl08001002005.Visible = false;
                            lbl08001002006.Visible = false;
                            lbl08001002007.Visible = false;
                            lbl08001002009.Visible = false;
                            lbl08001002014.Visible = false;

                            txt08001002002.Visible = false;
                            txt08001002003.Visible = false;
                            txt08001002004.Visible = false;
                            txt08001002007.Visible = false;

                            txt08001002002.Text = "";
                            txt08001002003.Text = "";
                            txt08001002004.Text = "";
                            txt08001002007.Text = "";


                            cbx001002002.Visible = false;
                            cbx001002003.Visible = false;
                            cbx001002004.Visible = false;
                            cbx001002005.Visible = false;
                            cbx001002006.Visible = false;

                            cbx001002002.Text = "";
                            cbx001002003.Text = "";
                            cbx001002004.Text = "";
                            cbx001002005.Text = "";
                            cbx001002006.Text = "";

                        }
                    }
                    WritingProductName();
                };
            }
        }

        private void lbl08001002003EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم وحدة التغليف 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "وحدة التغليف", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "وحدة التغليف", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void cbx001002002EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة رقم وحدة التغليف
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblEncapsulationUnits is null) return;
                    if (TblEncapsulationUnits.Rows.Count > 0)
                    {
                        cbx001002002.DataSource = TblEncapsulationUnits;
                        cbx001002002.ValueMember = "EncapsulationUnitsNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002002.DisplayMember = "UnitNameAR";
                        }
                        else
                        {
                            cbx001002002.DisplayMember = "UnitNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001002002);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> cbx001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                        cbx001002002.DataSource = TblEncapsulationUnits;
                        cbx001002002.ValueMember = "EncapsulationUnitsNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002002.DisplayMember = "UnitNameAR";
                        }
                        else
                        {
                            cbx001002002.DisplayMember = "UnitNameEN";
                        }
                    }

                    ElementsTools.ComboBox_.CustumProperties(cbx001002002, "", true, true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> cbx001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx001002002.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002002.Select();
                    }
                };

                cbx001002002.SelectedIndexChanged += delegate
                {
                    WritingProductName();
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
                ElementsTools.TextBox_.CustumProperties(txt08001002002, "",9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Int);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, "",9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true,TextBoxType.Int);
                txt08001002002.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx001002003.Select();
                    }

                };

                txt08001002002.TextChanged += delegate
                {

                    if(txt08001002002.Text.Trim() != "")
                    {
                        txt08001002003.Enabled = false;
                        cbx001002004.Enabled = false;

                        txt08001002003.Text = "";
                        cbx001002004.Text = "";
                    }
                    else
                    {
                        txt08001002003.Enabled = true;
                        cbx001002004.Enabled = true;

                    }
                    WritingProductName();
                };
            }
        }

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
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> cbx001002003EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> cbx001002003EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx001002003.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        if(txt08001002003.Enabled)
                        {
                            txt08001002003.Select();
                        }
                        else
                        {
                            cbx001002005.Select();
                        }
                    }
                };

                cbx001002003.SelectedIndexChanged += delegate
                {
                    WritingProductName();
                };
            }
        }


        private void lbl08001002005EventsAndProperties(bool Properties, bool Events = false) // ملصق قيمة الوحدة المتبوعة 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002005, "قيمة الوحدة المتبوعة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002005, "قيمة الوحدة المتبوعة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void txt08001002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص قيمة الوحدة المتبوعة
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, "",9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Int);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, "",9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Int);
                txt08001002003.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx001002004.Select();
                    }
                };

                txt08001002003.TextChanged += delegate
                {
                    if (txt08001002003.Text.Trim() != "")
                    {
                        txt08001002002.Enabled = false;
                        cbx001002003.Enabled = false;
                        txt08001002002.Text = "";
                        cbx001002003.Text = "";
                    }
                    else
                    {
                        txt08001002002.Enabled = true;
                        cbx001002003.Enabled = true;
                    }

                    if(cbx001002004.SelectedIndex >= 0)
                    {
                        cbx001002001.SelectedValue = TblMeasureAndEncapsulationUnitsForCbx.Rows[cbx001002004.SelectedIndex][1];
                        cbx001002005.SelectedValue = TblMeasureAndEncapsulationUnitsForCbx.Rows[cbx001002004.SelectedIndex][7];
                        txt08001002004.Text = TblMeasureAndEncapsulationUnitsForCbx.Rows[cbx001002004.SelectedIndex][8].ToString();

                        cbx001002001.Enabled = false;
                        cbx001002005.Enabled = false;
                        txt08001002004.Enabled = false;
                    }
                    WritingProductName();


                };
            }
        }

        private void cbx001002004EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة الوحدة المتبوعة
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblMeasureAndEncapsulationUnitsForCbx is null) { TblMeasureAndEncapsulationUnitsForCbx = new DataTable();  }
                    cbx001002004.DataSource = TblMeasureAndEncapsulationUnitsForCbx;
                    if (TblMeasureAndEncapsulationUnitsForCbx.Rows.Count > 0)
                    {
                       
                        cbx001002004.ValueMember = "UnitDetailsNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002004.DisplayMember = "DetailedNameForProductOrServiceAr";
                        }
                        else
                        {
                            cbx001002004.DisplayMember = "DetailedNameForProductOrServiceEn";
                        }
                        
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001002004);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> cbx001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblproductAndServicesDetails();

                    if (TblMeasureAndEncapsulationUnitsForCbx is null) { TblMeasureAndEncapsulationUnitsForCbx = new DataTable(); }
                    cbx001002004.DataSource = TblMeasureAndEncapsulationUnitsForCbx;
                    if (TblMeasureAndEncapsulationUnitsForCbx.Rows.Count > 0)
                    {
                        
                        cbx001002004.ValueMember = "UnitDetailsNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002004.DisplayMember = "DetailedNameForProductOrServiceAr";
                        }
                        else
                        {
                            cbx001002004.DisplayMember = "DetailedNameForProductOrServiceEn";
                        }
                    }

                    ElementsTools.ComboBox_.CustumProperties(cbx001002004, "", true, true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> cbx001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx001002004.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        if(cbx001002005.Enabled)
                        {
                            cbx001002005.Select();
                        }
                        else
                        {
                            cbx001002006.Select();
                        }
                    }
                };


                cbx001002004.SelectedIndexChanged += delegate
                {

                    if(cbx001002004.SelectedIndex != -1)
                    {
                        cbx001002001.SelectedValue = TblMeasureAndEncapsulationUnitsForCbx.Rows[cbx001002004.SelectedIndex][1];
                        cbx001002005.SelectedValue = TblMeasureAndEncapsulationUnitsForCbx.Rows[cbx001002004.SelectedIndex][7];
                        txt08001002004.Text = TblMeasureAndEncapsulationUnitsForCbx.Rows[cbx001002004.SelectedIndex][9].ToString();
                        txt08001002007.Text = TblMeasureAndEncapsulationUnitsForCbx.Rows[cbx001002004.SelectedIndex][8].ToString();

                        cbx001002001.Enabled = false;
                        cbx001002005.Enabled = false;
                        txt08001002004.Enabled = false;
                        txt08001002007.Enabled = false;
                    }

                    WritingProductName();

                };

            }
        }


        //***********
        private void lbl08001002006EventsAndProperties(bool Properties, bool Events = false) // ملصق الشركة الصانعة 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002006, "الشركة الصانعة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002006, "الشركة الصانعة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void cbx001002005EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة الشركة الصانعة
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (tblManufacturers.Rows.Count > 0)
                    {
                        cbx001002005.DataSource = tblManufacturers;
                        cbx001002005.ValueMember = "ManufacturerNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002005.DisplayMember = "CompanyNameAr";
                        }
                        else
                        {
                            cbx001002005.DisplayMember = "CompanyNameEn";
                        }
                        ElementsTools.ComboBox_.CustumProperties(cbx001002005);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> cbx001002005EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                filltblManufacturers(); // تعبئة جدول انواع طرق الاتصال

                if (tblManufacturers.Rows.Count > 0)
                {
                    try
                    {
                        if (tblManufacturers.Rows.Count > 0)
                        {
                            cbx001002005.DataSource = tblManufacturers;
                            cbx001002005.ValueMember = "ManufacturerNo";
                            if (GeneralVariables.cultureCode == "AR")
                            {
                                cbx001002005.DisplayMember = "CompanyNameAr";
                            }
                            else
                            {
                                cbx001002005.DisplayMember = "CompanyNameEn";
                            }

                        }
                        ElementsTools.ComboBox_.CustumProperties(cbx001002005, "", true, true);
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> cbx001002005EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                    ElementsTools.ComboBox_.CustumProperties(cbx001002005, "", true, true);

                    cbx001002005.KeyDown += delegate (object sender, KeyEventArgs e)
                    {
                        if (e.KeyData == Keys.Enter) { txt08001002007.Select(); };
                    };

                    cbx001002005.SelectedIndexChanged += delegate
                    {
                        WritingProductName();
                    };
                }
            }
        }

        private void lbl08001002009EventsAndProperties(bool Properties, bool Events = false) // ملصق  الموديل أو وصف السلعة عربي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002009, "الموديل أو وصف السلعة عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002009, "الموديل أو وصف السلعة عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002007EventsAndProperties(bool Properties, bool Events = false) // مربع نص الموديل أو وصف السلعة عربي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002007, "ar-SA", 100);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002007, "ar-SA", 100, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002007.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002004.Select();
                    }
                };

                txt08001002007.TextChanged += delegate
                {
                    WritingProductName();
                };

            }
        }


        private void lbl08001002007EventsAndProperties(bool Properties, bool Events = false) // ملصق الموديل او وصف السلعة إنجليزي 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002007, "الموديل او وصف السلعة إنجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002007, "الموديل او وصف السلعة إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002004EventsAndProperties(bool Properties, bool Events = false) // مربع نص الموديل او وصف السلعة إنجليزي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, "en-US", 100);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002004, "en-US", 100, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002004.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt08001002008.Select(); };
                };

                txt08001002004.TextChanged += delegate
                {
                    WritingProductName();
                };
            }
        }


        private void lbl08001002008EventsAndProperties(bool Properties, bool Events = false) // ملصق الاسم المفصل للمنتج اوالخدمة  
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002008, "الإسم المفصل للسلعة أو الخدمة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002008, "الإسم المفصل للسلعة أو الخدمة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002005EventsAndProperties(bool Properties, bool Events = false) // مربع نص الاسم المفصل للمنتج اوالخدمة عربي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002005, "ar-SA",100);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002005, "ar-SA",100, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002005.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt08001002006.Select(); };
                };
            }
        }



        private void txt08001002006EventsAndProperties(bool Properties, bool Events = false) // مربع نص اسم وحدة القياس والتغليف انجليزي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002006, "en-US",100);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002006, "en-US",100, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt08001002006.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt08001002008.Select(); };
                };
            }
        }


        private void lbl08001002010EventsAndProperties(bool Properties, bool Events = false) //  ملصق الاسم المختصر للمنتج او الخدمة بالعربي  
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002010, "الإسم المختصر عربي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002010, "الإسم المختصر عربي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002008EventsAndProperties(bool Properties, bool Events = false) // مربع نص الاسم المختصر للمنتج او الخدمة بالعربي
        {
            if (Properties == true & Events == false)
            {

                ElementsTools.TextBox_.CustumProperties(txt08001002008, "ar-SA", 30);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002008, "ar-SA", 30, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt08001002008.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002009.Select();
                    }
                };

                txt08001002008.TextChanged += delegate
                {
                    if (txt08001002008.TextLength > txt08001002008.MaxLength)
                    {
                        txt08001002008.Text = txt08001002008.Text.Substring(0, txt08001002008.MaxLength);
                    }
                };

            }
        }

        private void lbl08001002011EventsAndProperties(bool Properties, bool Events = false) //  ملصق الاسم المختصر للمنتج او الخدمة بالانجليزي  
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002011, "الإسم المختصر إنجليزي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002011, "الإسم المختصر إنجليزي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002009EventsAndProperties(bool Properties, bool Events = false) // مربع نص الاسم المختصر للمنتج او الخدمة بالانجليزي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002009, "en-US", 30);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002009, "en-US", 30, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt08001002009.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002010.Select();
                    }
                };

                txt08001002009.TextChanged += delegate
                {

                    if (txt08001002009.TextLength > txt08001002009.MaxLength)
                    {
                        txt08001002009.Text = txt08001002009.Text.Substring(0, txt08001002009.MaxLength);
                    }
                };

            }
        }

        private void lbl08001002012EventsAndProperties(bool Properties, bool Events = false) //  ملصق كمية المخزون  
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002012, "كمية المخزون", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002012, "كمية المخزون", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002010EventsAndProperties(bool Properties, bool Events = false) // مربع نص كمية المخزون
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002010, "en-US", 9 );

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002010, "en-US", 9 , ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt08001002010.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002011.Select();
                    }
                };
            }
        }


        private void lbl08001002013EventsAndProperties(bool Properties, bool Events = false) //  ملصق تكلفة المخزون  
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002013, "تكلفة المخزون", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002013, "تكلفة المخزون", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002011EventsAndProperties(bool Properties, bool Events = false) // مربع نص تكلفة المخزون
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002011, "en-US", 9);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002011, "en-US", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt08001002011.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002012.Select();
                    }
                };
            }
        }

        private void lbl08001002014EventsAndProperties(bool Properties, bool Events = false) //  ملصق تكلفة الوحدة  
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002014, "تكلفة الوحدة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002014, "تكلفة الوحدة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt08001002012EventsAndProperties(bool Properties, bool Events = false) // مربع نص تكلفة الوحدة
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002012, "en-US", 9);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002012, "en-US", 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt08001002012.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx001002006.Select();
                    }
                };
            }
        }


        private void lbl08001002015EventsAndProperties(bool Properties, bool Events = false) // ملصق أسلوب إحتساب سعر البيع 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002015, "أسلوب إحتساب سعر البيع", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002015, "أسلوب إحتساب سعر البيع", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }



        private void cbx001002006EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة أسلوب إحتساب سعر البيع
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("no");
                    dt.Columns.Add("AR");
                    dt.Columns.Add("EN");

                    DataRow dr1 = dt.NewRow();
                    dr1[0] = 1;
                    dr1[1] = "نسبة مئوية";
                    dr1[2] = "percent";

                    DataRow dr2 = dt.NewRow();
                    dr2[0] = 2;
                    dr2[1] = "الفئات السعرية";
                    dr2[2] = "Price Categories";

                    dt.Rows.Add(dr1);
                    dt.Rows.Add(dr2);

                    if(cbx001002006.DataSource == null)
                    {
                        cbx001002006.Items.Clear();

                        cbx001002006.DataSource = dt;
                        cbx001002006.ValueMember = "no";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001002006.DisplayMember = "AR";
                        }
                        else
                        {
                            cbx001002006.DisplayMember = "EN";
                        }
                    }

                    ElementsTools.ComboBox_.CustumProperties(cbx001002006);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> cbx001002006EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {

                try
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("no");
                    dt.Columns.Add("AR");
                    dt.Columns.Add("EN");

                    DataRow dr1 = dt.NewRow();
                    dr1[0] = 1;
                    dr1[1] = "نسبة مئوية";
                    dr1[2] = "percent";

                    DataRow dr2 = dt.NewRow();
                    dr2[0] = 2;
                    dr2[1] = "الفئات السعرية";
                    dr2[2] = "Price Categories";

                    dt.Rows.Add(dr1);
                    dt.Rows.Add(dr2);

                    cbx001002006.Items.Clear();

                    cbx001002006.DataSource = dt;
                    cbx001002006.ValueMember = "no";
                    if (GeneralVariables.cultureCode == "AR")
                    {
                        cbx001002006.DisplayMember = "AR";
                    }
                    else
                    {
                        cbx001002006.DisplayMember = "EN";
                    }

                    ElementsTools.ComboBox_.CustumProperties(cbx001002006);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> cbx001002006EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx001002006.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btn08001002002.PerformClick(); };
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

                    if (Permissions.AccountHavePermission(PermissionObjectes.product_And_Services_Details, PermissionType.Add))
                    {

                        if (btn08001002001.Text == Cultures.ReturnTranslation("جديد"))
                        {
                            btn08001002001.Text = Cultures.ReturnTranslation("إلغاء");

                            btn08001002001.Enabled = true;
                            btn08001002002.Enabled = true;
                            btn08001002003.Enabled = false;
                            btn08001002004.Enabled = false;

                            txt08001002001.Enabled = false;
                            txt08001002002.Enabled = true;
                            txt08001002003.Enabled = true;
                            txt08001002004.Enabled = true;
                            txt08001002007.Enabled = true;
                            txt08001002008.Enabled = true;
                            txt08001002009.Enabled = true;
                            txt08001002010.Enabled = true;
                            txt08001002011.Enabled = true;
                            txt08001002012.Enabled = true; 



                            cbx001002002.Enabled = true;
                            cbx001002001.Enabled = true;
                            cbx001002003.Enabled = true;
                            cbx001002004.Enabled = true;
                            cbx001002005.Enabled = true;
                            cbx001002006.Enabled = true;

                            dgv08001.Enabled = false;
                            tv.Enabled = false;


                            if (cbx001002001 != null && cbx001002001.Items.Count > 0) cbx001002001.SelectedIndex = -1;
                            if (cbx001002002 != null && cbx001002002.Items.Count > 0) cbx001002002.SelectedIndex = -1;
                            if (cbx001002003 != null && cbx001002003.Items.Count > 0) cbx001002003.SelectedIndex = -1;
                            if (cbx001002004 != null && cbx001002004.Items.Count > 0) cbx001002004.SelectedIndex = -1;
                            if (cbx001002005 != null && cbx001002005.Items.Count > 0) cbx001002005.SelectedIndex = -1;
                            if (cbx001002006 != null && cbx001002006.Items.Count > 0) cbx001002006.SelectedIndex = -1;


                            txt08001002001.Text = "";
                            txt08001002002.Text = "";
                            txt08001002003.Text = "";
                            txt08001002004.Text = "";
                            txt08001002005.Text = "";
                            txt08001002006.Text = "";
                            txt08001002007.Text = "";
                            txt08001002008.Text = "";
                            txt08001002009.Text = "";
                            txt08001002010.Text = "";
                            txt08001002011.Text = "";
                            txt08001002012.Text = "";

                            cbx001002001.Focus();
                        }
                        else
                        {
                            btn08001002001.Text = Cultures.ReturnTranslation("جديد");

                            btn08001002001.Enabled = true;
                            btn08001002002.Enabled = false;
                            btn08001002003.Enabled = true;
                            btn08001002004.Enabled = true;

                            txt08001002001.Enabled = false;
                            txt08001002002.Enabled = false;
                            txt08001002003.Enabled = false;
                            txt08001002004.Enabled = false;
                            txt08001002007.Enabled = false;
                            txt08001002008.Enabled = false;
                            txt08001002009.Enabled = false;
                            txt08001002010.Enabled = false;
                            txt08001002011.Enabled = false;
                            txt08001002012.Enabled = false;

                            cbx001002002.Enabled = false;
                            cbx001002001.Enabled = false;
                            cbx001002003.Enabled = false;
                            cbx001002004.Enabled = false;
                            cbx001002005.Enabled = false;
                            cbx001002006.Enabled = false;

                            dgv08001.Enabled = true;
                            tv.Enabled = true;

                            dgv08001.Focus();
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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
                        if (btn08001002001.Text == Cultures.ReturnTranslation("إلغاء")) // إضافة
                        {
                            string Error = "";
                            if (cbx001002001.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار الخدمة او السلعة");
                                cbx001002001.Focus();
                            }
                            else
                            {
                                if (Convert.ToBoolean((cbx001002001.DataSource as DataTable).Rows[cbx001002001.SelectedIndex][1].ToString()))
                                {
                                    if (cbx001002002.SelectedIndex == -1)
                                    {
                                        Error = Cultures.ReturnTranslation("رجاء قم بإختيار وحدة التغليف");
                                        cbx001002002.Focus();
                                    }
                                    else if (txt08001002002.Text.Trim() == "" && txt08001002003.Text.Trim() == "")
                                    {
                                        Error = Cultures.ReturnTranslation("رجاء قم بتسجيل قيمة وحدة القياس أو قيمة الوحدة المتبوعة");
                                        txt08001002001.Focus();
                                    }
                                    else if (cbx001002003.SelectedIndex == -1 && cbx001002004.SelectedIndex == -1)
                                    {
                                        Error = Cultures.ReturnTranslation("رجاء قم بإختيار وحدة قياس أو الوحدة المتبوعة");
                                        cbx001002003.Focus();
                                    }
                                }
                            }
                            if (Error == "")
                            {
                                // فحص البيانات للتأكد من عدم وجود تكرار في الجدول
                                bool? SameArabicName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002005.Text.Replace("'", ""), 10);
                                bool? SameEnglishName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002006.Text.Replace("'", ""), 11);

                                bool? SameShortArabicName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002008.Text.Replace("'", ""), 12);
                                bool? SameShortEnglishName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.add, txt08001002009.Text.Replace("'", ""), 13);

                                if (SameArabicName == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد سلعة أو خدمة بنفس الإسم العربي المفصل");
                                    txt08001002005.Focus();

                                }
                                else
                                {
                                    if (SameEnglishName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد سلعة أو خدمة بنفس الإسم الإنجليزي المفصل");
                                        txt08001002006.Focus();
                                    }
                                    else
                                    {
                                        if (SameEnglishName == true)
                                        {
                                            Error = Cultures.ReturnTranslation("توجد سلعة أو خدمة بنفس الإسم العربي المختصر");
                                            txt08001002008.Focus();
                                        }
                                        else
                                        {
                                            if (SameEnglishName == true)
                                            {
                                                Error = Cultures.ReturnTranslation("توجد سلعة أو خدمة بنفس الإسم الإنجليزي المختصر");
                                                txt08001002009.Focus();
                                            }

                                        }
                                    }
                                }
                            }
                            if(Error == "" && cbx001002006.SelectedIndex < 0)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتحديد طريقة التسعير");
                                cbx001002006.Focus();
                            }
                            if (Error == "" && txt08001002010.Text.Trim()!="")
                            {
                                if(Convert.ToDouble(txt08001002010.Text) > 999999.99)
                                {
                                    Error = Cultures.ReturnTranslation("تجاوزت أكبر رقم وهو 999999.99");
                                    txt08001002010.Focus();
                                }
                            }
                            if (Error == "" && txt08001002011.Text.Trim() != "")
                            {
                                if (Convert.ToDouble(txt08001002011.Text) > 999999.99)
                                {
                                    Error = Cultures.ReturnTranslation("تجاوزت أكبر رقم وهو 999999.99");
                                    txt08001002011.Focus();
                                }
                            }
                            if (Error == "" && txt08001002012.Text.Trim() != "")
                            {
                                if (Convert.ToDouble(txt08001002012.Text) > 999999.99)
                                {
                                    Error = Cultures.ReturnTranslation("تجاوزت أكبر رقم وهو 999999.99");
                                    txt08001002012.Focus();
                                }
                            }
                            if (Error == "")
                            {

                                string[] result = null;
                                object returnNumber = DataTools.DataBases.Run(ref result, "spAddProductAndServicesDetails",
                                CommandType.StoredProcedure, new object[][] {
                                      new object[] { "@productOrServiceNumber", cbx001002001.SelectedValue }
                                    , new object[] { "@EncapsulationUnitsNo", cbx001002002.SelectedValue }
                                    , new object[] { "@MeasureUnitValue", txt08001002002.Text.Replace("'", "") }
                                    , new object[] { "@MeasureUnitNo", cbx001002003.SelectedValue }
                                    , new object[] { "@UnitDetailsValue", txt08001002003.Text.Replace("'", "") }
                                    , new object[] { "@UnitDetailsNoSelfJoin", cbx001002004.SelectedValue }
                                    , new object[] { "@ManufacturerNo", cbx001002005.SelectedValue }
                                    , new object[] { "@ModelOrProductArabicDescription", txt08001002007.Text.Replace("'", "") }
                                    , new object[] { "@ModelEnglishOrProductEnglishDescription", txt08001002004.Text.Replace("'", "") }
                                    , new object[] { "@DetailedNameForProductOrServiceAr", txt08001002005.Text.Replace("'","") }
                                    , new object[] { "@DetailedNameForProductOrServiceEn", txt08001002006.Text.Replace("'", "") }
                                    , new object[] { "@ShortArabicName", txt08001002008.Text.Replace("'", "") }
                                    , new object[] { "@ShortEnglishName", txt08001002009.Text.Replace("'", "") }
                                    , new object[] { "@StockQuantity", txt08001002010.Text.Replace("'", "") }
                                    , new object[] { "@StockCost", txt08001002011.Text.Replace("'", "") }
                                    , new object[] { "@UnitCost", txt08001002012.Text.Replace("'", "") }
                                    , new object[] { "@PriceCalculationMethod ", cbx001002006.SelectedValue }
                                    , new object[] { "@UnitDetailsNo", "OUT" }
                                });

                                if (result[1] == "succeeded")
                                {

                                    if (GeneralVariables.cultureCode == "AR")
                                    {
                                        TreeNode tn = new TreeNode(txt08001002005.Text.Replace("'", ""));
                                        tn.Tag = returnNumber;
                                        if (cbx001002004.SelectedIndex > -1) { ElementsTools.TreeView_.Search(tv, cbx001002004.SelectedValue).Nodes.Add(tn); } else { tv.Nodes.Add(tn); } // اذا تم تحديد وحدة اعلى يتم الاضافة اليها واذا لم يتم تحديد وحدة اعلى تتم الاضافة على الشجرة العامة
                                    }
                                    else
                                    {
                                        TreeNode tn = new TreeNode(txt08001002006.Text.Replace("'", ""));
                                        tn.Tag = returnNumber;
                                        if (cbx001002004.SelectedIndex > -1) { ElementsTools.TreeView_.Search(tv, cbx001002004.SelectedValue).Nodes.Add(tn); } else { tv.Nodes.Add(tn); } // اذا تم تحديد وحدة اعلى يتم الاضافة اليها واذا لم يتم تحديد وحدة اعلى تتم الاضافة على الشجرة العامة
                                    }

                                    // البيانات الى الجدول
                                    // table 1 
                                    DataRow dr = TblproductAndServicesDetails.NewRow();
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

                                    dr[7] = cbx001002005.SelectedValue == null ? DBNull.Value : cbx001002005.SelectedValue;
                                    if (txt08001002004.Text.Trim() == "")
                                    {
                                        dr[8] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr[8] = txt08001002004.Text;
                                    }

                                    if (txt08001002007.Text.Trim() == "")
                                    {
                                        dr[9] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr[9] = txt08001002007.Text;
                                    }


                                    if (txt08001002005.Text.Trim() == "")
                                    {
                                        dr[10] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr[10] = txt08001002005.Text;
                                    }
                                    if (txt08001002006.Text.Trim() == "")
                                    {
                                        dr[11] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr[11] = txt08001002006.Text;
                                    }

                                    if (txt08001002008.Text.Trim() == "")
                                    {
                                        dr[12] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr[12] = txt08001002008.Text;
                                    }

                                    if (txt08001002009.Text.Trim() == "")
                                    {
                                        dr[13] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr[13] = txt08001002009.Text;
                                    }

                                    if (txt08001002010.Text.Trim() == "")
                                    {
                                        dr[14] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr[14] = txt08001002010.Text;
                                    }

                                    if (txt08001002011.Text.Trim() == "")
                                    {
                                        dr[15] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr[15] = txt08001002011.Text;
                                    }

                                    if (txt08001002012.Text.Trim() == "")
                                    {
                                        dr[16] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr[16] = txt08001002012.Text;
                                    }

                                    dr[17] = cbx001002006.SelectedValue;
                                    TblproductAndServicesDetails.Rows.Add(dr);

                                    // عند اضافة اول سجل فقط
                                    if (TblMeasureAndEncapsulationUnitsForCbx.Rows.Count == 1)
                                    {

                                        cbx001002004.ValueMember = "UnitDetailsNo";
                                        if (GeneralVariables.cultureCode == "AR")
                                        {
                                            cbx001002004.DisplayMember = "DetailedNameForProductOrServiceAr";
                                        }
                                        else
                                        {
                                            cbx001002004.DisplayMember = "DetailedNameForProductOrServiceEn";
                                        }
                                    }



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

                                    dr2[7] = cbx001002005.SelectedValue == null ? DBNull.Value : cbx001002005.SelectedValue;
                                    if (txt08001002004.Text.Trim() == "")
                                    {
                                        dr2[8] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr2[8] = txt08001002004.Text;
                                    }

                                    if (txt08001002007.Text.Trim() == "")
                                    {
                                        dr2[9] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr2[9] = txt08001002007.Text;
                                    }


                                    if (txt08001002005.Text.Trim() == "")
                                    {
                                        dr2[10] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr2[10] = txt08001002005.Text;
                                    }
                                    if (txt08001002006.Text.Trim() == "")
                                    {
                                        dr2[11] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr2[11] = txt08001002006.Text;
                                    }
                                    if (txt08001002008.Text.Trim() == "")
                                    {
                                        dr2[12] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr2[12] = txt08001002008.Text;
                                    }

                                    if (txt08001002009.Text.Trim() == "")
                                    {
                                        dr2[13] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr2[13] = txt08001002009.Text;
                                    }

                                    if (txt08001002010.Text.Trim() == "")
                                    {
                                        dr2[14] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr2[14] = txt08001002010.Text;
                                    }

                                    if (txt08001002011.Text.Trim() == "")
                                    {
                                        dr2[15] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr2[15] = txt08001002011.Text;
                                    }

                                    if (txt08001002012.Text.Trim() == "")
                                    {
                                        dr2[16] = DBNull.Value;
                                    }
                                    else
                                    {
                                        dr2[16] = txt08001002012.Text;
                                    }

                                    dr2[17] = cbx001002006.SelectedValue;
                                    TblMeasureAndEncapsulationUnitsForCbx.Rows.Add(dr2);


                                    if (cbx001002004.DataSource == null)
                                    {
                                        cbx001002004EventsAndProperties(true);
                                    }

                                    if (dgv08001.DataSource == null)
                                    {
                                        dgv08001EventsAndProperties(true);
                                    }

                                    //if (GeneralVariables._frmproductAndServicesDetails14 != null) { GeneralVariables._frmproductAndServicesDetails14.AllfrmproductAndServicesDetails14ElementsEventsAndProperties(true, true); } // تحديث خصائص نموذج المنتجات  ??????????????????

                                    btn08001002001.Text = Cultures.ReturnTranslation("جديد");

                                    btn08001002001.Enabled = true;
                                    btn08001002002.Enabled = false;
                                    btn08001002003.Enabled = true;
                                    btn08001002004.Enabled = true;

                                    txt08001002001.Enabled = false;
                                    txt08001002002.Enabled = false;
                                    txt08001002003.Enabled = false;
                                    txt08001002004.Enabled = false;
                                    txt08001002007.Enabled = false;
                                    txt08001002008.Enabled = false;
                                    txt08001002009.Enabled = false;
                                    txt08001002010.Enabled = false;
                                    txt08001002011.Enabled = false;
                                    txt08001002012.Enabled = false;

                                    cbx001002002.Enabled = false;
                                    cbx001002001.Enabled = false;
                                    cbx001002003.Enabled = false;
                                    cbx001002004.Enabled = false;
                                    cbx001002005.Enabled = false;
                                    cbx001002006.Enabled = false;

                                    dgv08001.Enabled = true;
                                    tv.Enabled = true;

                                    btn08001002001.Select();
                                    dgv08001.Rows[dgv08001.Rows.Count - 1].Selected = true;


                                }



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
                            if (cbx001002001.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار الخدمة او السلعة");
                                cbx001002001.Focus();
                            }
                            else
                            {
                                if (Convert.ToBoolean((cbx001002001.DataSource as DataTable).Rows[cbx001002001.SelectedIndex][1].ToString()))
                                {
                                    if (cbx001002002.SelectedIndex == -1)
                                    {
                                        Error = Cultures.ReturnTranslation("رجاء قم بإختيار وحدة التغليف");
                                        cbx001002002.Focus();
                                    }
                                    else if (txt08001002002.Text.Trim() == "" && txt08001002003.Text.Trim() == "")
                                    {
                                        Error = Cultures.ReturnTranslation("رجاء قم بتسجيل قيمة وحدة القياس أو قيمة الوحدة المتبوعة");
                                        txt08001002001.Focus();
                                    }
                                    else if (cbx001002003.SelectedIndex == -1 && cbx001002004.SelectedIndex == -1)
                                    {
                                        Error = Cultures.ReturnTranslation("رجاء قم بإختيار وحدة قياس أو الوحدة المتبوعة");
                                        cbx001002003.Focus();
                                    }
                                }
                            }
                            if (Error == "")
                            {
                                // فحص البيانات للتأكد من عدم وجود تكرار في الجدول
                                bool? SameArabicName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002005.Text.Replace("'", ""), 10);
                                bool? SameEnglishName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002006.Text.Replace("'", ""), 11);

                                bool? SameShortArabicName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002008.Text.Replace("'", ""), 12);
                                bool? SameShortEnglishName = ElementsTools.DataGridView_.findValueThenSelected(dgv08001, ActionType.edit, txt08001002009.Text.Replace("'", ""), 13);

                                if (SameArabicName == true)
                                {
                                    Error = Cultures.ReturnTranslation("توجد سلعة أو خدمة بنفس الإسم العربي المفصل");
                                    txt08001002005.Focus();

                                }
                                else
                                {
                                    if (SameEnglishName == true)
                                    {
                                        Error = Cultures.ReturnTranslation("توجد سلعة أو خدمة بنفس الإسم الإنجليزي المفصل");
                                        txt08001002006.Focus();
                                    }
                                    else
                                    {
                                        if (SameEnglishName == true)
                                        {
                                            Error = Cultures.ReturnTranslation("توجد سلعة أو خدمة بنفس الإسم العربي المختصر");
                                            txt08001002008.Focus();
                                        }
                                        else
                                        {
                                            if (SameEnglishName == true)
                                            {
                                                Error = Cultures.ReturnTranslation("توجد سلعة أو خدمة بنفس الإسم الإنجليزي المختصر");
                                                txt08001002009.Focus();
                                            }

                                        }
                                    }
                                }
                            }
                            if (Error == "" && cbx001002006.SelectedIndex < 0)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتحديد طريقة التسعير");
                                cbx001002006.Focus();
                            }
                            if (Error == "" && txt08001002010.Text.Trim() != "")
                            {
                                if (Convert.ToDouble(txt08001002010.Text) > 999999.99)
                                {
                                    Error = Cultures.ReturnTranslation("تجاوزت أكبر رقم وهو 999999.99");
                                    txt08001002010.Focus();
                                }
                            }
                            if (Error == "" && txt08001002011.Text.Trim() != "")
                            {
                                if (Convert.ToDouble(txt08001002011.Text) > 999999.99)
                                {
                                    Error = Cultures.ReturnTranslation("تجاوزت أكبر رقم وهو 999999.99");
                                    txt08001002011.Focus();
                                }
                            }
                            if (Error == "" && txt08001002012.Text.Trim() != "")
                            {
                                if (Convert.ToDouble(txt08001002012.Text) > 999999.99)
                                {
                                    Error = Cultures.ReturnTranslation("تجاوزت أكبر رقم وهو 999999.99");
                                    txt08001002012.Focus();
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
                                    ElementsTools.TreeView_.CircleOfElements(tv, MoveNode, MoveNodeTo);
                                    CircleElementsTest = ElementsTools.TreeView_.CircleOfElementsResut;
                                    ElementsTools.TreeView_.CircleOfElementsResut = null; // اعادتها لوضعها الطبيعي
                                }

                                if (CircleElementsTest == false)
                                {
                                    // لا توجد مشكلة دوران

                                    string[] result = null;
                                    DataTools.DataBases.Run(ref result, @"update TblproductAndServicesDetails set 
                                    productOrServiceNumber = @productOrServiceNumber , 
                                    EncapsulationUnitsNo = @EncapsulationUnitsNo , 
                                    MeasureUnitValue = @MeasureUnitValue , 
                                    MeasureUnitNo = @MeasureUnitNo , 
                                    UnitDetailsValue = @UnitDetailsValue , 
                                    UnitDetailsNoSelfJoin = @UnitDetailsNoSelfJoin , 
                                    ManufacturerNo = @ManufacturerNo , 
                                    ModelOrProductArabicDescription = @ModelOrProductArabicDescription , 
                                    ModelEnglishOrProductEnglishDescription = @ModelEnglishOrProductEnglishDescription ,
                                    DetailedNameForProductOrServiceAr = @DetailedNameForProductOrServiceAr , 
                                    DetailedNameForProductOrServiceEn = @DetailedNameForProductOrServiceEn , 
                                    ShortArabicName = @ShortArabicName , 
                                    ShortEnglishName = @ShortEnglishName , 
                                    StockQuantity = @StockQuantity , 
                                    StockCost = @StockCost , 
                                    UnitCost = @UnitCost , 
                                    PriceCalculationMethod = @PriceCalculationMethod
                                    where UnitDetailsNo = @UnitDetailsNo"
                                    ,
                                    CommandType.Text, new object[][] {
                                      new object[] { "@UnitDetailsNo", txt08001002001.Text.Replace("'", "") }
                                    , new object[] { "@productOrServiceNumber", cbx001002001.SelectedValue }
                                    , new object[] { "@EncapsulationUnitsNo", cbx001002002.SelectedValue }
                                    , new object[] { "@MeasureUnitValue", txt08001002002.Text.Replace("'", "") }
                                    , new object[] { "@MeasureUnitNo", cbx001002003.SelectedValue }
                                    , new object[] { "@UnitDetailsValue", txt08001002003.Text.Replace("'", "") }
                                    , new object[] { "@UnitDetailsNoSelfJoin", cbx001002004.SelectedValue }
                                    , new object[] { "@ManufacturerNo", cbx001002005.SelectedValue }
                                    , new object[] { "@ModelOrProductArabicDescription", txt08001002007.Text.Replace("'", "") }
                                    , new object[] { "@ModelEnglishOrProductEnglishDescription", txt08001002004.Text.Replace("'", "") }
                                    , new object[] { "@DetailedNameForProductOrServiceAr", txt08001002005.Text.Replace("'","") }
                                    , new object[] { "@DetailedNameForProductOrServiceEn", txt08001002006.Text.Replace("'", "") }
                                    , new object[] { "@ShortArabicName", txt08001002008.Text.Replace("'", "") }
                                    , new object[] { "@ShortEnglishName", txt08001002009.Text.Replace("'", "") }
                                    , new object[] { "@StockQuantity", txt08001002010.Text.Replace("'", "") }
                                    , new object[] { "@StockCost", txt08001002011.Text.Replace("'", "") }
                                    , new object[] { "@UnitCost", txt08001002012.Text.Replace("'", "") }
                                    , new object[] { "@PriceCalculationMethod ", cbx001002006.SelectedValue }
                                    });

                                    if (result[1] == "succeeded")
                                    {

                                        // تحديث بيانات الجدول
                                        int rowIndex = 0;
                                        DataRow[] dataRows = TblproductAndServicesDetails.Select("UnitDetailsNo = " + txt08001002001.Text);
                                        rowIndex = TblproductAndServicesDetails.Rows.IndexOf(dataRows[0]);


                                        // table 1
                                        TblproductAndServicesDetails.Rows[rowIndex][1] = cbx001002001.SelectedValue == null ? DBNull.Value : cbx001002001.SelectedValue;

                                        TblproductAndServicesDetails.Rows[rowIndex][2] = cbx001002002.SelectedValue == null ? DBNull.Value : cbx001002002.SelectedValue;

                                        if (txt08001002002.Text.Trim() == "")
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][3] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][3] = txt08001002002.Text;
                                        }

                                        TblproductAndServicesDetails.Rows[rowIndex][4] = cbx001002003.SelectedValue == null ? DBNull.Value : cbx001002003.SelectedValue;

                                        if (txt08001002003.Text.Trim() == "")
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][5] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][5] = txt08001002003.Text;
                                        }


                                        TblproductAndServicesDetails.Rows[rowIndex][6] = cbx001002004.SelectedValue == null ? DBNull.Value : cbx001002004.SelectedValue;

                                        TblproductAndServicesDetails.Rows[rowIndex][7] = cbx001002005.SelectedValue == null ? DBNull.Value : cbx001002005.SelectedValue;
                                        if (txt08001002004.Text.Trim() == "")
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][8] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][8] = txt08001002004.Text;
                                        }


                                        if (txt08001002007.Text.Trim() == "")
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][9] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][9] = txt08001002007.Text;
                                        }



                                        if (txt08001002005.Text.Trim() == "")
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][10] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][10] = txt08001002005.Text;
                                        }
                                        if (txt08001002006.Text.Trim() == "")
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][11] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][11] = txt08001002006.Text;
                                        }

                                        //---
                                        if (txt08001002008.Text.Trim() == "")
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][12] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][12] = txt08001002008.Text;
                                        }
                                        if (txt08001002009.Text.Trim() == "")
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][13] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][13] = txt08001002009.Text;
                                        }
                                        if (txt08001002010.Text.Trim() == "")
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][14] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][14] = txt08001002010.Text;
                                        }
                                        if (txt08001002011.Text.Trim() == "")
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][15] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][15] = txt08001002011.Text;
                                        }
                                        if (txt08001002012.Text.Trim() == "")
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][16] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblproductAndServicesDetails.Rows[rowIndex][16] = txt08001002012.Text;
                                        }
                                        //---
                                        TblproductAndServicesDetails.Rows[rowIndex][17] = cbx001002006.SelectedValue;



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

                                        TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][7] = cbx001002005.SelectedValue == null ? DBNull.Value : cbx001002005.SelectedValue;
                                        if (txt08001002004.Text.Trim() == "")
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][8] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][8] = txt08001002004.Text;
                                        }

                                        if (txt08001002007.Text.Trim() == "")
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][9] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][9] = txt08001002007.Text;
                                        }


                                        if (txt08001002005.Text.Trim() == "")
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][10] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][10] = txt08001002005.Text;
                                        }
                                        if (txt08001002006.Text.Trim() == "")
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][11] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][11] = txt08001002006.Text;
                                        }
                                        if (txt08001002008.Text.Trim() == "")
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][12] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][12] = txt08001002008.Text;
                                        }
                                        if (txt08001002009.Text.Trim() == "")
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][13] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][13] = txt08001002009.Text;
                                        }
                                        if (txt08001002010.Text.Trim() == "")
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][14] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][14] = txt08001002010.Text;
                                        }
                                        if (txt08001002011.Text.Trim() == "")
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][15] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][15] = txt08001002011.Text;
                                        }
                                        if (txt08001002012.Text.Trim() == "")
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][16] = DBNull.Value;
                                        }
                                        else
                                        {
                                            TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][16] = txt08001002012.Text;
                                        }
                                        TblMeasureAndEncapsulationUnitsForCbx.Rows[rowIndex][17] = cbx001002006.SelectedValue;




                                        // هل هناك نودات محددة
                                        if (tv.SelectedNode == null)
                                        {
                                            // لم يتم تحديد اي نود

                                            // التحديث لأنه تم إضافة النود بدون التابعة له وذلك يتطلب تحديث الجدول بشكل كامل
                                            fillTblproductAndServicesDetails();
                                            dgv08001EventsAndProperties(true);
                                            tvEventsAndProperties(true);
                                        }
                                        else
                                        {
                                            // تم تحديد نود

                                            // تحديث بيانات النود
                                            tv.SelectedNode.Text = GeneralVariables.cultureCode == "AR" ? txt08001002005.Text.Replace("'", "").Trim() : txt08001002006.Text.Replace("'", "").Trim();

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

                                            //if (GeneralVariables._frmproductAndServicesDetails14 != null) { GeneralVariables._frmproductAndServicesDetails14.AllfrmproductAndServicesDetails14ElementsEventsAndProperties(true, true); } // تحديث خصائص نموذج المنتجات
                                        }

                                        //------------------

                                        btn08001002003.Text = Cultures.ReturnTranslation("تعديل");

                                        btn08001002001.Enabled = true;
                                        btn08001002002.Enabled = false;
                                        btn08001002003.Enabled = true;
                                        btn08001002004.Enabled = true;

                                        txt08001002001.Enabled = false;
                                        txt08001002002.Enabled = false;
                                        txt08001002003.Enabled = false;
                                        txt08001002004.Enabled = false;
                                        txt08001002007.Enabled = false;
                                        txt08001002008.Enabled = false;
                                        txt08001002009.Enabled = false;
                                        txt08001002010.Enabled = false;
                                        txt08001002011.Enabled = false;
                                        txt08001002012.Enabled = false;

                                        cbx001002002.Enabled = false;
                                        cbx001002001.Enabled = false;
                                        cbx001002003.Enabled = false;
                                        cbx001002004.Enabled = false;
                                        cbx001002005.Enabled = false;
                                        cbx001002006.Enabled = false;

                                        dgv08001.Enabled = true;
                                        tv.Enabled = true;

                                        dgv08001.Focus();
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
                                        GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> btn08001002003EventsAndProperties", DateTime.Now, "لقد إرتكبت خطأ منطقي حيث يوجد سجلين كلاً منهما يتبع الاّخر", "You made a logical error as there are two records that follow each other");
                                        ElementsTools.TreeView_.CircleOfElementsResut = null;
                                        cbx001002004.SelectedIndex = -1;
                                    }
                                    else
                                    {
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء قم بالمحاولة من جديد"), MessageBoxStatus.Ok);
                                        GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> btn08001002003EventsAndProperties", DateTime.Now, "رجاء قم بالمحاولة من جديد", "Please try again");

                                        ElementsTools.TreeView_.CircleOfElementsResut = null;
                                        cbx001002004.SelectedIndex = -1;
                                    }
                                }


                            }
                            else
                            {
                                //btn08001002003.PerformClick();
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);
                                GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> btn08001002003EventsAndProperties", DateTime.Now, Error, Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> btn08001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    if (Permissions.AccountHavePermission(PermissionObjectes.product_And_Services_Details, PermissionType.Edit))
                    {
                        if (btn08001002003.Enabled)
                        {
                            if (btn08001002003.Text == Cultures.ReturnTranslation("تعديل"))
                            {
                                btn08001002003.Text = Cultures.ReturnTranslation("إلغاء");

                                btn08001002001.Enabled = false;
                                btn08001002002.Enabled = true;
                                btn08001002003.Enabled = true;
                                btn08001002004.Enabled = false;

                                txt08001002001.Enabled = false;
                                txt08001002002.Enabled = true;
                                txt08001002003.Enabled = true;
                                txt08001002004.Enabled = true;
                                txt08001002007.Enabled = true;
                                txt08001002008.Enabled = true;
                                txt08001002009.Enabled = true;
                                txt08001002010.Enabled = true;
                                txt08001002011.Enabled = true;
                                txt08001002012.Enabled = true;

                                cbx001002002.Enabled = true;
                                cbx001002001.Enabled = true;
                                cbx001002003.Enabled = true;
                                cbx001002004.Enabled = true;
                                cbx001002005.Enabled = true;
                                cbx001002006.Enabled = true;

                                dgv08001.Enabled = false;
                                tv.Enabled = false;

                                cbx001002001.Focus();
                            }
                            else
                            {
                                btn08001002003.Text = Cultures.ReturnTranslation("تعديل");

                                btn08001002001.Enabled = true;
                                btn08001002002.Enabled = false;
                                btn08001002003.Enabled = true;
                                btn08001002004.Enabled = true;

                                txt08001002001.Enabled = false;
                                txt08001002002.Enabled = false;
                                txt08001002003.Enabled = false;
                                txt08001002004.Enabled = false;
                                txt08001002007.Enabled = false;
                                txt08001002008.Enabled = false;
                                txt08001002009.Enabled = false;
                                txt08001002010.Enabled = false;
                                txt08001002011.Enabled = false;
                                txt08001002012.Enabled = false;

                                cbx001002002.Enabled = false;
                                cbx001002001.Enabled = false;
                                cbx001002003.Enabled = false;
                                cbx001002004.Enabled = false;
                                cbx001002005.Enabled = false;
                                cbx001002006.Enabled = false;

                                dgv08001.Enabled = true;
                                tv.Enabled = true;

                                dgv08001.Focus();
                            }
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> btn08001002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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
                        if (Permissions.AccountHavePermission(PermissionObjectes.product_And_Services_Details, PermissionType.Delete))
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
                                    DataTools.DataBases.Run(ref result, "delete from TblproductAndServicesDetails where UnitDetailsNo = @UnitDetailsNo", CommandType.Text, new object[][] { new object[] { "@UnitDetailsNo", txt08001002001.Text.ToString() } });


                                    if (result[1] == "succeeded")
                                    {

                                        if (result[0] == "1")
                                        {
                                            if (cbx001002001 != null && cbx001002001.Items.Count > 0) cbx001002001.SelectedIndex = -1;
                                            if (cbx001002002 != null && cbx001002002.Items.Count > 0) cbx001002002.SelectedIndex = -1;
                                            if (cbx001002003 != null && cbx001002003.Items.Count > 0) cbx001002003.SelectedIndex = -1;
                                            if (cbx001002004 != null && cbx001002004.Items.Count > 0) cbx001002004.SelectedIndex = -1;
                                            if (cbx001002005 != null && cbx001002005.Items.Count > 0) cbx001002005.SelectedIndex = -1;
                                            if (cbx001002006 != null && cbx001002006.Items.Count > 0) cbx001002006.SelectedIndex = -1;


                                            txt08001002001.Text = "";
                                            txt08001002002.Text = "";
                                            txt08001002003.Text = "";
                                            txt08001002004.Text = "";
                                            txt08001002005.Text = "";
                                            txt08001002006.Text = "";
                                            txt08001002007.Text = "";
                                            txt08001002008.Text = "";
                                            txt08001002009.Text = "";
                                            txt08001002010.Text = "";
                                            txt08001002011.Text = "";
                                            txt08001002012.Text = "";

                                            txtSearch.Text = "";


                                            if (tv.SelectedNode != null)
                                            {

                                                TblproductAndServicesDetails.Rows.Remove(TblproductAndServicesDetails.Select("UnitDetailsNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                TblMeasureAndEncapsulationUnitsForCbx.Rows.Remove(TblMeasureAndEncapsulationUnitsForCbx.Select("UnitDetailsNo = " + Convert.ToInt32(nodeNumber))[0]);
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
                                                    TblproductAndServicesDetails.Rows.Remove(TblproductAndServicesDetails.Select("UnitDetailsNo = " + Convert.ToInt32(nodeNumber))[0]);
                                                    TblMeasureAndEncapsulationUnitsForCbx.Rows.Remove(TblMeasureAndEncapsulationUnitsForCbx.Select("UnitDetailsNo = " + Convert.ToInt32(nodeNumber))[0]);
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
                            GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> btn08001002004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> btn08001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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

                    ElementsTools.TreeView_.fillTreeView(tv, TblproductAndServicesDetails, "UnitDetailsNoSelfJoin", 6, -1, 10, 11, 0);
                    ElementsTools.TreeView_.CustumProperties(tv);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                //fillTblMeasureAndEncapsulationUnits();
                try
                {
                    tv.Nodes.Clear();

                    ElementsTools.TreeView_.fillTreeView(tv, TblproductAndServicesDetails, "UnitDetailsNoSelfJoin", 6, -1, 10, 11, 0);
                    ElementsTools.TreeView_.CustumProperties(tv);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                        GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                        else if (e.KeyData == Keys.Enter)
                        {
                            if (tv.SelectedNode != null)
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
                        GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> tvEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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

                    if (TblproductAndServicesDetails is null) { TblproductAndServicesDetails = new DataTable(); };
                    if (TblproductAndServicesDetails.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblproductAndServicesDetails;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الوحدة");
                        dgv08001.Columns[1].Visible = false;
                        dgv08001.Columns[2].Visible = false;
                        dgv08001.Columns[3].Visible = false;
                        dgv08001.Columns[4].Visible = false;
                        dgv08001.Columns[5].Visible = false;
                        dgv08001.Columns[6].Visible = false;
                        dgv08001.Columns[7].Visible = false;
                        dgv08001.Columns[8].Visible = false;
                        dgv08001.Columns[9].Visible = false;
                        dgv08001.Columns[10].HeaderText = Cultures.ReturnTranslation("اسم الوحدة عربي");
                        dgv08001.Columns[11].HeaderText = Cultures.ReturnTranslation("اسم الوحدة انجليزي");
                        dgv08001.Columns[12].Visible = false;
                        dgv08001.Columns[13].Visible = false;
                        dgv08001.Columns[14].Visible = false;
                        dgv08001.Columns[15].Visible = false;
                        dgv08001.Columns[16].Visible = false;
                        dgv08001.Columns[17].Visible = false;





                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgv08001.Columns[10].Visible = true;
                            dgv08001.Columns[11].Visible = false;
                        }
                        else
                        {
                            dgv08001.Columns[10].Visible = false;
                            dgv08001.Columns[11].Visible = true;
                        }


                        dgv08001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgv08001.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv08001.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



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
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> dgv08001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    //fillTblMeasureAndEncapsulationUnits();

                    if (TblproductAndServicesDetails is null) { TblproductAndServicesDetails = new DataTable(); };
                    if (TblproductAndServicesDetails.Rows.Count > 0)
                    {

                        dgv08001.DataSource = TblproductAndServicesDetails;

                        dgv08001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الوحدة");
                        dgv08001.Columns[1].Visible = false;
                        dgv08001.Columns[2].Visible = false;
                        dgv08001.Columns[3].Visible = false;
                        dgv08001.Columns[4].Visible = false;
                        dgv08001.Columns[5].Visible = false;
                        dgv08001.Columns[6].Visible = false;
                        dgv08001.Columns[7].Visible = false;
                        dgv08001.Columns[8].Visible = false;
                        dgv08001.Columns[9].Visible = false;
                        dgv08001.Columns[10].HeaderText = Cultures.ReturnTranslation("اسم الوحدة عربي");
                        dgv08001.Columns[11].HeaderText = Cultures.ReturnTranslation("اسم الوحدة انجليزي");
                        dgv08001.Columns[12].Visible = false;
                        dgv08001.Columns[13].Visible = false;
                        dgv08001.Columns[14].Visible = false;
                        dgv08001.Columns[15].Visible = false;
                        dgv08001.Columns[16].Visible = false;
                        dgv08001.Columns[17].Visible = false;

                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgv08001.Columns[10].Visible = true;
                            dgv08001.Columns[11].Visible = false;
                        }
                        else
                        {
                            dgv08001.Columns[10].Visible = false;
                            dgv08001.Columns[11].Visible = true;
                        }


                        dgv08001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgv08001.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv08001.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



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
                    GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> dgv08001EventsAndProperties 1", DateTime.Now, ex.Message, ex.Message);
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

                            if (cbx001002005 != null)
                            {
                                if (cbx001002005.Items.Count > 0)
                                {
                                    if (dgv08001.SelectedRows[0].Cells[7].Value.ToString() != null)
                                    {
                                        if (dgv08001.SelectedRows[0].Cells[7].Value.ToString().Trim() != "")
                                        {
                                            cbx001002005.SelectedValue = dgv08001.SelectedRows[0].Cells[7].Value.ToString();
                                        }
                                        else
                                        {
                                            cbx001002005.SelectedIndex = -1;
                                        }
                                    }
                                    else
                                    {
                                        cbx001002005.SelectedIndex = -1;
                                    }
                                }
                            }

                            txt08001002004.Text = dgv08001.SelectedRows[0].Cells[8].Value.ToString();
                            txt08001002007.Text = dgv08001.SelectedRows[0].Cells[9].Value.ToString();


                            txt08001002005.Text = dgv08001.SelectedRows[0].Cells[10].Value.ToString();
                            txt08001002006.Text = dgv08001.SelectedRows[0].Cells[11].Value.ToString();

                            txt08001002008.Text = dgv08001.SelectedRows[0].Cells[12].Value.ToString();
                            txt08001002009.Text = dgv08001.SelectedRows[0].Cells[13].Value.ToString();
                            txt08001002010.Text = dgv08001.SelectedRows[0].Cells[14].Value.ToString();
                            txt08001002011.Text = dgv08001.SelectedRows[0].Cells[15].Value.ToString();
                            txt08001002012.Text = dgv08001.SelectedRows[0].Cells[16].Value.ToString();

                            if (cbx001002006 != null)
                            {
                                if (cbx001002006.Items.Count > 0)
                                {
                                    if (dgv08001.SelectedRows[0].Cells[17].Value.ToString() != null)
                                    {
                                        if (dgv08001.SelectedRows[0].Cells[17].Value.ToString().Trim() != "")
                                        {
                                            cbx001002006.SelectedValue = dgv08001.SelectedRows[0].Cells[17].Value.ToString();
                                        }
                                        else
                                        {
                                            cbx001002006.SelectedIndex = -1;
                                        }
                                    }
                                    else
                                    {
                                        cbx001002006.SelectedIndex = -1;
                                    }
                                }
                            }



                            tv.SelectedNode = ElementsTools.TreeView_.Search(tv, dgv08001.SelectedRows[0].Cells[0].Value);

                            // تحديث بيانات النماذج الفرعية
                            if (pnl08001002001.Controls.Count > 0)
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
                        GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> dgv08001EventsAndProperties 2", DateTime.Now, ex.Message, ex.Message);
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
                        GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> dgv08001EventsAndProperties 3 ", DateTime.Now, ex.Message, ex.Message);
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
                ElementsTools.TextBox_.CustumProperties(txtSearch,"",50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtSearch, "",50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txtSearch.TextChanged += delegate
                {
                    try
                    {
                        DataView dv = new DataView(TblproductAndServicesDetails);
                        string filter = "";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            filter = "DetailedNameForProductOrServiceAr like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        else
                        {
                            filter = "DetailedNameForProductOrServiceEn like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        dv.RowFilter = filter;
                        dgv08001.DataSource = dv;
                        ElementsTools.DataGridView_.CustumProperties(dgv08001);  // تخصيص خصائص جدول عرض البيانات

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> txtSearchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }


        //------------------------------ 

        DataTable TblproductAndServicesDetails = new DataTable(); // جدول تفاصيل السلع والخدمات للجدول السفلي 
        DataTable TblMeasureAndEncapsulationUnitsForCbx = new DataTable(); // جدول تفاصيل السلع والخدمات للقائمة المنسدلة
        DataTable TblEncapsulationUnits = new DataTable(); // جدول وحدات التغليف 
        DataTable TblMeasureUnit = new DataTable(); // جدول وحدات القياس
        DataTable TblProductsAndServices = new DataTable(); // جدول السلع والخدمات


        private void fillTblproductAndServicesDetails()// تعبئة جدول تفاصيل السلع والخدمات
        {
            try
            {
                if (TblproductAndServicesDetails is null) { TblproductAndServicesDetails = new DataTable(); };
                if (TblproductAndServicesDetails.Rows.Count > 0) { TblproductAndServicesDetails.Rows.Clear(); }
                if (TblMeasureAndEncapsulationUnitsForCbx is null) { TblMeasureAndEncapsulationUnitsForCbx = new DataTable(); };
                if (TblMeasureAndEncapsulationUnitsForCbx.Rows.Count > 0) { TblMeasureAndEncapsulationUnitsForCbx.Rows.Clear(); }

                TblproductAndServicesDetails = DataTools.DataBases.ReadTabel("select * from TblproductAndServicesDetails ");
                TblMeasureAndEncapsulationUnitsForCbx = DataTools.DataBases.ReadTabel("select * from TblproductAndServicesDetails ");
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> fillTblproductAndServicesDetails ", DateTime.Now, ex.Message, ex.Message);
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
                GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> fillTblEncapsulationUnits ", DateTime.Now, ex.Message, ex.Message);
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
                GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> fillTblMeasureUnit ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        private void fillTblProductsAndServices()// تعبئة جدول السلع والخدمات
        {
            try
            {
                if (TblProductsAndServices is null) { TblProductsAndServices = new DataTable(); };
                if (TblProductsAndServices.Rows.Count > 0) { TblProductsAndServices.Rows.Clear(); }

                TblProductsAndServices = DataTools.DataBases.ReadTabel("select * from TblProductsAndServices ");
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> fillTblProductsAndServices ", DateTime.Now, ex.Message, ex.Message);
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
                        GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> btnBarcodeEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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
                        GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> btnPriceCategoriesEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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
                        GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> btnFreeUnitsOffersEventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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
                    if (pnl08001002001.Controls.Count > 0)
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
                GeneralAction.AddNewNotification("frmproductAndServicesDetails14 >> tooltip ", DateTime.Now, ex.Message, ex.Message);
            }

        }
    }


}

