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
    public partial class frmFreeUnitsOffers : Form
    {
        DataTable TblFreeUnitsOffers = new DataTable(); // جدول عروض الوحدات المجانية

        public frmFreeUnitsOffers()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
            fillTblFreeUnitsOffers();
        }

        public void fillTblFreeUnitsOffers()// تعبئة جدول عروض الوحدات المجانية
        {
            try
            {
                if (TblFreeUnitsOffers.Rows.Count > 0)
                {
                    TblFreeUnitsOffers.Rows.Clear();
                }
                if (this.Parent == null) return;
                if (this.Parent.Parent == null) return;
                if (this.Parent.Parent.Controls["txt08001002001"] != null)
                {
                    if (!string.IsNullOrEmpty(this.Parent.Parent.Controls["txt08001002001"].Text.Trim()))
                    {
                        TblFreeUnitsOffers = DataTools.DataBases.ReadTabel("select * from TblFreeUnitsOffers where UnitDetailsNo = " + this.Parent.Parent.Controls["txt08001002001"].Text.Trim());
                    }
                }


                txt001.Text = "";
                txt002.Text = "";
                txt003.Text = "";
                txt004.Text = "";

                dgv001EventsAndProperties(true);
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmFreeUnitsOffers  >>  fillTblFreeUnitsOffers  ", DateTime.Now, ex.Message, ex.Message);
            }

        }


        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            mainFrmEventsAndProperties(Properties, Events); // النموذج

            lbl001EventsAndProperties(Properties, Events); // ملصق رقم العرض
            txt001EventsAndProperties(Properties, Events); // مربع نص رقم العرض 
            lbl002EventsAndProperties(Properties, Events); // ملصق أقل كيمة 
            txt002EventsAndProperties(Properties, Events); // مربع نص أقل كيمة 
            lbl003EventsAndProperties(Properties, Events); // ملصق أعلى كمية 
            txt003EventsAndProperties(Properties, Events); // مربع نص أعلى كمية 
            lbl004EventsAndProperties(Properties, Events); // ملصق عدد الوحدات المجانية 
            txt004EventsAndProperties(Properties, Events); // مربع نص عدد الوحدات المجانية 
            lbl005EventsAndProperties(Properties, Events); // ملصق تاريخ بداية العرض 
            dtp001EventsAndProperties(Properties, Events); // مربع نص تاريخ بداية العرض 
            lbl006EventsAndProperties(Properties, Events); // ملصق تاريخ نهاية العرض 
            dtp002EventsAndProperties(Properties, Events); // مربع نص تاريخ نهاية العرض 

            btn001EventsAndProperties(Properties, Events); // جديد
            btn002EventsAndProperties(Properties, Events); // حفظ
            btn003EventsAndProperties(Properties, Events); // تعديل
            btn004EventsAndProperties(Properties, Events); // حذف

            dgv001EventsAndProperties(Properties, Events); // جدول عرض السجلات 
        }




        private void mainFrmEventsAndProperties(bool Properties, bool Events = false) // النموذج 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Form_.CustumProperties(this);

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Form_.CustumProperties(this, ColorPropertyName.BackColor_3, true, true);

                this.Load += delegate
                {
                    this.Font = this.Parent.Font;
                };
            }
        }

        private void lbl001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم العرض
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001, "رقم العرض", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001, "رقم العرض", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم العرض 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001, "",10);

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001, "",10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void lbl002EventsAndProperties(bool Properties, bool Events = false) // ملصق أقل كيمة 
        {


            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl002, "أقل كيمة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl002, "أقل كيمة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void txt002EventsAndProperties(bool Properties, bool Events = false) // مربع نص أقل كيمة 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt002, "",9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt002, "",9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Decimal);
                txt002.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter)
                    {
                        txt003.Select();
                    }
                };
            }
        }

        private void lbl003EventsAndProperties(bool Properties, bool Events = false) // ملصق أعلى كيمة 
        {


            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "أعلى كيمة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "أعلى كيمة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void txt003EventsAndProperties(bool Properties, bool Events = false) // مربع نص أعلى كيمة 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt003, "",9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt003, "",9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Decimal);
                txt003.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter)
                    {
                        txt004.Select();
                    }
                };
            }
        }

        private void lbl004EventsAndProperties(bool Properties, bool Events = false) // ملصق عدد الوحدات المجانية 
        {


            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl004, "عدد الوحدات المجانية", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl004, "عدد الوحدات المجانية", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void txt004EventsAndProperties(bool Properties, bool Events = false) // مربع نص عدد الوحدات المجانية 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt004, "",9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt004, "",9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Decimal);
                txt004.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter)
                    {
                        dtp001.Select();
                    }
                };
            }
        }

        private void lbl005EventsAndProperties(bool Properties, bool Events = false) // ملصق تاريخ بداية العرض 
        {


            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl005, "تاريخ بداية العرض", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl005, "تاريخ بداية العرض", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void dtp001EventsAndProperties(bool Properties, bool Events = false) // مربع نص تاريخ بداية العرض 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.DateTimePicker_.CustumProperties(dtp001);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.DateTimePicker_.CustumProperties(dtp001,true,true);

                dtp001.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter)
                    {
                        dtp002.Select();
                    }
                };
            }
        }


        private void lbl006EventsAndProperties(bool Properties, bool Events = false) // ملصق تاريخ نهاية العرض 
        {


            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl006, "تاريخ نهاية العرض", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl006, "تاريخ نهاية العرض", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void dtp002EventsAndProperties(bool Properties, bool Events = false) // مربع نص السعر 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.DateTimePicker_.CustumProperties(dtp002);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.DateTimePicker_.CustumProperties(dtp002, true, true);

                dtp002.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter)
                    {
                        btn002.PerformClick();
                    }
                };
            }
        }
        //**********

        private void btn001EventsAndProperties(bool Properties, bool Events = false) // جديد 
        {

            // الخصائص
            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001, "جديد");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn001, "جديد", ColorPropertyName.ForeColor_1, true, true);
                btn001.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Free_Unit_Offers, PermissionType.Add))
                        {

                            if (btn001.Text == Cultures.ReturnTranslation("جديد"))
                            {
                                txt002.Enabled = true;
                                txt003.Enabled = true;
                                txt004.Enabled = true;
                                dtp001.Enabled = true;
                                dtp002.Enabled = true;

                                txt001.Text = "";
                                txt002.Text = "";
                                txt003.Text = "";
                                txt004.Text = "";
                                dtp001.Value = DateTime.Now;
                                dtp002.Value = DateTime.Now;

                                btn002.Enabled = true;
                                btn003.Enabled = false;
                                btn004.Enabled = false;

                                txt002.Select();

                                dgv001.Enabled = false;

                                btn001.Text = Cultures.ReturnTranslation("إلغاء");
                            }
                            else
                            {
                                txt002.Enabled = false;
                                txt003.Enabled = false;
                                txt004.Enabled = false;
                                dtp001.Enabled = false;
                                dtp002.Enabled = false;

                                btn002.Enabled = false;
                                btn003.Enabled = true;
                                btn004.Enabled = true;

                                dgv001.Enabled = true;
                                dgv001.Focus();

                                btn001.Text = Cultures.ReturnTranslation("جديد");
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmFreeUnitsOffers >> btn001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmFreeUnitsOffers  >>  btn001EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

            }
        }
        private void btn002EventsAndProperties(bool Properties, bool Events = false) // حفظ 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn002, "حفظ");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn002, "حفظ", ColorPropertyName.ForeColor_1, true, true);

                btn002.Click += delegate
                {

                    try
                    {
                        if (btn001.Text == "إلغاء")
                        {
                            string Error = "";

                            if (this.Parent.Parent.Controls["txt08001002001"].Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار وحدة القياس والتغليف");
                            }
                            else if (txt002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بكتابة أقل كمية");
                                txt002.Focus();
                            }
                            else if (txt003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بكتابة أكبر كمية");
                                txt003.Focus();
                            }
                            else if (Convert.ToDecimal(txt002.Text) > Convert.ToDecimal(txt003.Text))
                            {
                                Error = Cultures.ReturnTranslation("خطأ منطقي في تحديد الكميات");
                                txt002.Focus();
                            }
                            else if (txt004.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بكتابة عدد الوحدات المجانية");
                                txt004.Focus();
                            }
                            else if (dtp001.Value > dtp002.Value)
                            {
                                Error = Cultures.ReturnTranslation("خطأ منطقي في ترتيب التواريخ");
                                dtp001.Focus();
                            }
                            else
                            {
                                // فحص هل الرقم يقع ضمن حدود فئة اخرى
                                decimal min = Convert.ToDecimal(txt002.Text);
                                decimal max = Convert.ToDecimal(txt003.Text);
                                foreach (DataGridViewRow row in dgv001.Rows)
                                {
                                    if (min >= Convert.ToDecimal(row.Cells[2].Value) && min <= Convert.ToDecimal(row.Cells[3].Value))
                                    {
                                        Error = Cultures.ReturnTranslation("خطأ منطقي أقل كمية تقع ضمن حدود تصنيف كمي آخر");
                                        row.Selected = true;
                                        txt002.Focus();
                                        break;
                                    }

                                    if (max >= Convert.ToDecimal(row.Cells[2].Value) && max <= Convert.ToDecimal(row.Cells[3].Value))
                                    {
                                        Error = Cultures.ReturnTranslation("خطأ منطقي أعلى كمية تقع ضمن حدود تصنيف كمي آخر");
                                        row.Selected = true;
                                        txt002.Focus();
                                        break;
                                    }
                                }
                            }

                            if (Error == "")
                            {


                                string[] result = null;
                                DataTools.DataBases.Run(ref result, "insert into TblFreeUnitsOffers values (@UnitDetailsNo,@LessQuantity, @HighestQuantity, @NumberOfFreeUnits ,@PromoStartDate,@PromoEndDate );"
                                    , CommandType.Text, new object[][] {
                                          new object[] { "@UnitDetailsNo",this.Parent.Parent.Controls["txt08001002001"].Text }
                                        , new object[] { "@LessQuantity", txt002.Text.Replace("'", "").Trim() }
                                        , new object[] { "@HighestQuantity", txt003.Text.Replace("'", "").Trim() }
                                        , new object[] { "@NumberOfFreeUnits", txt004.Text.Replace("'", "").Trim() }
                                        , new object[] { "@PromoStartDate", dtp001.Value }
                                        , new object[] { "@PromoEndDate", dtp002.Value }
                                    });

                                if (result[1] == "succeeded")
                                {
                                    txt002.Enabled = false;
                                    txt003.Enabled = false;
                                    txt004.Enabled = false;
                                    dtp001.Enabled = false;
                                    dtp002.Enabled = false;

                                    btn001.Enabled = true;
                                    btn002.Enabled = false;
                                    btn003.Enabled = true;
                                    btn004.Enabled = true;

                                    dgv001.Enabled = true;
                                    //--------------------------
                                    btn001.Text = Cultures.ReturnTranslation("جديد");
                                    btn001.Focus();
                                    // تحديث بيانات جدول البيانات
                                    fillTblFreeUnitsOffers();
                                    dgv001EventsAndProperties(true);
                                }
                                else
                                {
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), result[1], MessageBoxStatus.Ok);
                                }

                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);
                                txt001.Text = "";
                            }

                        }
                        else if (btn003.Text == "إلغاء")
                        {

                            string Error = "";

                            if (this.Parent.Parent.Controls["txt08001002001"].Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار وحدة القياس والتغليف");
                            }
                            else if (txt002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بكتابة أقل كمية");
                                txt002.Focus();
                            }
                            else if (txt003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بكتابة أكبر كمية");
                                txt003.Focus();
                            }
                            else if (Convert.ToDecimal(txt002.Text) > Convert.ToDecimal(txt003.Text))
                            {
                                Error = Cultures.ReturnTranslation("خطأ منطقي في تحديد الكميات");
                                txt002.Focus();
                            }
                            else if (txt004.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بكتابة عدد الوحدات المجانية");
                                txt004.Focus();
                            }
                            else if (dtp001.Value > dtp002.Value)
                            {
                                Error = Cultures.ReturnTranslation("خطأ منطقي في ترتيب التواريخ");
                                dtp001.Focus();
                            }
                            else
                            {
                                // فحص هل الرقم يقع ضمن حدود فئة اخرى
                                decimal min = Convert.ToDecimal(txt002.Text);
                                decimal max = Convert.ToDecimal(txt003.Text);
                                foreach (DataGridViewRow row in dgv001.Rows)
                                {
                                    if (min >= Convert.ToDecimal(row.Cells[2].Value) && min <= Convert.ToDecimal(row.Cells[3].Value))
                                    {
                                        if (row != dgv001.CurrentRow)
                                        {
                                            Error = Cultures.ReturnTranslation("خطأ منطقي أقل كمية تقع ضمن حدود تصنيف كمي آخر");
                                            row.Selected = true;
                                            txt002.Focus();
                                            break;
                                        }

                                    }

                                    if (max >= Convert.ToDecimal(row.Cells[2].Value) && max <= Convert.ToDecimal(row.Cells[3].Value))
                                    {
                                        if (row != dgv001.CurrentRow)
                                        {
                                            Error = Cultures.ReturnTranslation("خطأ منطقي أعلى كمية تقع ضمن حدود تصنيف كمي آخر");
                                            row.Selected = true;
                                            txt002.Focus();
                                            break;
                                        }

                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string[] result = null;
                                DataTools.DataBases.Run(ref result, "update TblFreeUnitsOffers set LessQuantity = @LessQuantity , HighestQuantity = @HighestQuantity  , NumberOfFreeUnits = @NumberOfFreeUnits , PromoStartDate = @PromoStartDate , PromoEndDate = @PromoEndDate  where PromoNo = @PromoNo"
                                    , CommandType.Text, new object[][] {
                                         new object[] { "@LessQuantity", txt002.Text.Replace("'", "").Trim() }
                                        , new object[] { "@HighestQuantity", txt003.Text.Replace("'", "").Trim() }
                                        , new object[] { "@NumberOfFreeUnits", txt004.Text.Replace("'", "").Trim() }
                                        , new object[] { "@PromoStartDate", dtp001.Value }
                                        , new object[] { "@PromoEndDate", dtp002.Value }
                                        , new object[] { "@PromoNo", txt001.Text.Replace("'", "").Trim() }
                                    });

                                if (result[1] == "succeeded")
                                {
                                    txt002.Enabled = false;
                                    txt003.Enabled = false;
                                    txt004.Enabled = false;
                                    dtp001.Enabled = false;
                                    dtp002.Enabled = false;

                                    btn001.Enabled = true;
                                    btn002.Enabled = false;
                                    btn003.Enabled = true;
                                    btn004.Enabled = true;

                                    dgv001.Enabled = true;
                                    //--------------------------
                                    btn003.Text = Cultures.ReturnTranslation("تعديل");
                                    btn003.Focus();

                                    // تحديث بيانات جدول البيانات
                                    fillTblFreeUnitsOffers();
                                    dgv001EventsAndProperties(true);
                                }
                                else
                                {
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), result[1], MessageBoxStatus.Ok);
                                }

                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);
                            }

                        }

                    }
                    catch (Exception ex)
                    {

                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmFreeUnitsOffers  >>  btn002EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);

                        txt001.Enabled = false;
                        txt002.Enabled = false;
                        txt003.Enabled = false;
                        txt004.Enabled = false;
                        dtp001.Enabled = false;
                        dtp002.Enabled = false;

                        btn001.Enabled = true;
                        btn002.Enabled = false;
                        btn003.Enabled = true;
                        btn004.Enabled = true;

                        dgv001.Enabled = true;

                        //--------------------------
                        //btn05002009.Text = Cultures.ReturnTranslation("جديد");
                        //btn05002011.Text = Cultures.ReturnTranslation("تعديل");


                        // تحديث بيانات جدول البيانات
                        fillTblFreeUnitsOffers();
                        dgv001EventsAndProperties(true);
                        dgv001.Focus();
                    }

                };
            }


        }
        private void btn003EventsAndProperties(bool Properties, bool Events = false) // تعديل 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn003, "تعديل");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn003, "تعديل", ColorPropertyName.ForeColor_1, true, true);

                btn003.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Free_Unit_Offers, PermissionType.Edit))
                    {

                        if (btn003.Text == Cultures.ReturnTranslation("تعديل"))
                        {
                            if(txt001.Text.Trim() != "")
                            {
                                txt002.Enabled = true;
                                txt003.Enabled = true;
                                txt004.Enabled = true;
                                dtp001.Enabled = true;
                                dtp002.Enabled = true;

                                btn001.Enabled = false;
                                btn002.Enabled = true;
                                btn004.Enabled = false;

                                txt002.Select();

                                dgv001.Enabled = false;
                                btn003.Text = Cultures.ReturnTranslation("إلغاء");
                            }
                            else
                            {
                                if (dgv001.Rows.Count > 0)
                                {
                                    dgv001.ClearSelection();
                                    dgv001.Rows[0].Selected = true;
                                }
                            }
                        }
                        else
                        {

                            txt002.Enabled = false;
                            txt003.Enabled = false;
                            txt004.Enabled = false;
                            dtp001.Enabled = false;
                            dtp002.Enabled = false;


                            btn001.Enabled = true;
                            btn002.Enabled = false;
                            btn004.Enabled = true;

                            dgv001.Enabled = true;
                            btn003.Text = Cultures.ReturnTranslation("تعديل");

                            dgv001.Focus();
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmFreeUnitsOffers >> btn003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }

                };
            }
        }
        private void btn004EventsAndProperties(bool Properties, bool Events = false) // حذف 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn004, "حذف");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn004, "حذف", ColorPropertyName.ForeColor_1, true, true);
                btn004.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Free_Unit_Offers, PermissionType.Delete))
                    {

                        try
                        {

                            if (Convert.ToInt32(txt001.Text) >= 0)
                            {
                                string[] result = null;
                                DataTools.DataBases.Run(ref result, "delete from TblFreeUnitsOffers where PromoNo = @PromoNo"
                                    , CommandType.Text, new object[][] {
                                    new object[] { "@PromoNo", Convert.ToInt32(txt001.Text) } });
                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء قم بتحديد السجل الذي تريد حذفه"), MessageBoxStatus.Ok);
                            }

                        }
                        catch (Exception ex)
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmFreeUnitsOffers  >>  btn004EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                        }

                        txt001.Text = "";
                        txt002.Text = "";
                        txt003.Text = "";
                        txt004.Text = "";
                        dtp001.Value = DateTime.Now;
                        dtp002.Value = DateTime.Now;

                        // تحديث بيانات جدول البيانات
                        fillTblFreeUnitsOffers();
                        dgv001EventsAndProperties(true);
                        dgv001.Focus();
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmFreeUnitsOffers >> btn004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }

                };
            }
        }

        private void dgv001EventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات الباركودات
        {
            if (Properties == true && Events == false)
            {
                try
                {

                    if (TblFreeUnitsOffers.Rows.Count > 0)
                    {
                        dgv001.DataSource = TblFreeUnitsOffers;

                        dgv001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم العرض");
                        dgv001.Columns[1].Visible = false;
                        dgv001.Columns[2].HeaderText = Cultures.ReturnTranslation("أقل كيمة");
                        dgv001.Columns[3].HeaderText = Cultures.ReturnTranslation("أعلى كيمة");
                        dgv001.Columns[4].HeaderText = Cultures.ReturnTranslation("عدد الوحدات المجانية");
                        dgv001.Columns[5].Visible = false;
                        dgv001.Columns[6].Visible = false;

                        dgv001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgv001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgv001.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgv001.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


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
                    GeneralAction.AddNewNotification("frmFreeUnitsOffers  >>  dgv001EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {

                    if (TblFreeUnitsOffers.Rows.Count > 0)
                    {
                        dgv001.DataSource = TblFreeUnitsOffers;


                        dgv001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم العرض");
                        dgv001.Columns[1].Visible = false;
                        dgv001.Columns[2].HeaderText = Cultures.ReturnTranslation("أقل كيمة");
                        dgv001.Columns[3].HeaderText = Cultures.ReturnTranslation("أعلى كيمة");
                        dgv001.Columns[4].HeaderText = Cultures.ReturnTranslation("عدد الوحدات المجانية");
                        dgv001.Columns[5].Visible = false;
                        dgv001.Columns[6].Visible = false;

                        dgv001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgv001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgv001.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgv001.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


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
                    GeneralAction.AddNewNotification("frmFreeUnitsOffers  >>  dgv001EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                }


                dgv001.SelectionChanged += delegate
                {
                    try
                    {
                        if (dgv001.Rows.Count > 0)
                        {
                            if (dgv001.SelectedRows is null) return;
                            if (dgv001.SelectedRows.Count <= 0) return;
                            txt001.Text = dgv001.SelectedRows[0].Cells[0].Value.ToString();
                            txt002.Text = dgv001.SelectedRows[0].Cells[2].Value.ToString();
                            txt003.Text = dgv001.SelectedRows[0].Cells[3].Value.ToString();
                            txt004.Text = dgv001.SelectedRows[0].Cells[4].Value.ToString();
                            dtp001.Value = Convert.ToDateTime(dgv001.SelectedRows[0].Cells[5].Value.ToString());
                            dtp002.Value = Convert.ToDateTime(dgv001.SelectedRows[0].Cells[6].Value.ToString());
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmFreeUnitsOffers  >>  dgv001EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                dgv001.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    try
                    {
                        if (e.KeyData == Keys.Subtract)
                        {
                            if (dgv001.SelectedRows != null)
                            {
                                btn004.PerformClick();
                            }

                        }
                        else if (e.KeyData == Keys.Add)
                        {
                            if (dgv001.SelectedRows != null)
                            {
                                btn001.PerformClick();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmFreeUnitsOffers >> dgv001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                // عند تغيير بيانات جدول عرض البيانات
                // عند التنقل عندما يكون الجدول في وضع امكانية الاضافة
                dgv001.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
                };
            }
        }






    }
}
