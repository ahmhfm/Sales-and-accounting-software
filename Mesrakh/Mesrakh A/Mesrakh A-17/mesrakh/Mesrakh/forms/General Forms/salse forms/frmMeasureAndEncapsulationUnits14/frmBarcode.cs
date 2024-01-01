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
    public partial class frmBarcode : Form
    {
        DataTable TblBarcode = new DataTable(); // جدول الباركورد

        public frmBarcode()
        {

            //if (GeneralVariables.font is null)
            //{
            //    GeneralVariables.font = new Font("Microsoft Sans Serif", 12);
            //}

            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
            fillTblBarcode();
        }

        public void fillTblBarcode()// تعبئة جدول الباركودات
        {
            try
            {
                if (TblBarcode.Rows.Count > 0)
                {
                    TblBarcode.Rows.Clear();
                }
                if (this.Parent == null) return;
                if (this.Parent.Parent == null) return;
                if (this.Parent.Parent.Controls["txt08001002001"] != null)
                {
                    if (!string.IsNullOrEmpty(this.Parent.Parent.Controls["txt08001002001"].Text.Trim()))
                    {
                        TblBarcode = DataTools.DataBases.ReadTabel("select * from TblBarcode where MeasureAndEncapsulationUnitNo = " + this.Parent.Parent.Controls["txt08001002001"].Text.Trim());
                    }
                }

                txt001.Text = "";
                txt002.Text = "";
                dgv001EventsAndProperties(true);
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmBarcode  >>  fillTblBarcode  ", DateTime.Now, ex.Message, ex.Message);
            }

        }
      

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmBarcodeEventsAndProperties(Properties, Events); // النموذج

            lbl001EventsAndProperties(Properties, Events); // ملصق الرقم المتسلسل للباركود
            txt001EventsAndProperties(Properties, Events); // مربع نص الرقم المتسلسل للباركود 

            lbl003EventsAndProperties(Properties, Events); // ملصق رقم الباركود 
            txt002EventsAndProperties(Properties, Events); // مربع نص رقم الباركود 

            btn001EventsAndProperties(Properties, Events); // جديد
            btn002EventsAndProperties(Properties, Events); // حفظ
            btn003EventsAndProperties(Properties, Events); // تعديل
            btn004EventsAndProperties(Properties, Events); // حذف

            dgv001EventsAndProperties(Properties, Events); // جدول عرض بيانات الحسابات
        }




        private void frmBarcodeEventsAndProperties(bool Properties, bool Events = false) // النموذج 
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
        
        private void lbl001EventsAndProperties(bool Properties, bool Events = false) // ملصق الرقم المتسلسل للباركود
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001, "الرقم المتسلسل للباركود", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001, "الرقم المتسلسل للباركود", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001EventsAndProperties(bool Properties, bool Events = false) // مربع نص الرقم المتسلسل للباركود 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001, "");

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001, "", ColorPropertyName.BackColor_1,ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void lbl003EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم الباركود 
        {


            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "رقم الباركود", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "رقم الباركود", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void txt002EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم الباركود 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt002, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1);

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt002, "", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                txt002.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) 
                    {
                        btn002.PerformClick();
                    }
                };
            }
        }




        



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
                        if (Permissions.AccountHavePermission(PermissionObjectes.Barcode, PermissionType.Add))
                        {

                            if (btn001.Text == Cultures.ReturnTranslation("جديد"))
                            {
                                txt002.Enabled = true;

                                txt001.Text = "";
                                txt002.Text = "";

                                
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
                            GeneralAction.AddNewNotification("frmBarcode >> btn001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmBarcode  >>  btn001EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
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
                        if (btn001.Text=="إلغاء")
                        {
                            string Error = "";

                            if(this.Parent.Parent.Controls["txt08001002001"].Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار وحدة القياس والتغليف");
                            }
                            else if (txt002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بكتابة رقم الباركود");
                                txt002.Focus();
                            }
                            else
                            {

                                bool? FindBarcodeNo = ElementsTools.DataGridView_.findValueThenSelected(dgv001, ActionType.add, txt002.Text, 2);
                                if (FindBarcodeNo == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد باركود بنفس الرقم");
                                }

                            }

                            if (Error == "")
                            {


                                string[] result = null;
                                DataTools.DataBases.Run(ref result, "insert into TblBarcode values (@MeasureAndEncapsulationUnitNo,@BarcodeNo);"
                                    , CommandType.Text , new object[][] { 
                                          new object[] { "@MeasureAndEncapsulationUnitNo",this.Parent.Parent.Controls["txt08001002001"].Text }
                                        , new object[] { "@BarcodeNo", txt002.Text.Replace("'", "").Trim() } });

                                if (result[1] == "succeeded")
                                {
                                    txt002.Enabled = false;

                                    btn001.Enabled = true;
                                    btn002.Enabled = false;
                                    btn003.Enabled = true;
                                    btn004.Enabled = true;

                                    dgv001.Enabled = true;
                                    //--------------------------
                                    btn001.Text = Cultures.ReturnTranslation("جديد");
                                    btn001.Focus();
                                    // تحديث بيانات جدول البيانات
                                    fillTblBarcode();
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
                        else if(btn003.Text=="إلغاء")
                        {

                            string Error = "";

                            if (txt001.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتحديد السجل الذي ترغب في تحديث بياناته");
                                dgv001.Enabled = true;
                                dgv001.Focus();
                            }
                            else if (this.Parent.Parent.Controls["txt08001002001"].Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار وحدة القياس والتغليف");
                            }
                            else if (txt002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بكتابة رقم الباركود");
                                txt002.Focus();
                            }
                            else
                            {
                                bool? FindBarcodeNo = ElementsTools.DataGridView_.findValueThenSelected(dgv001, ActionType.edit, txt002.Text, 2);
                                if (FindBarcodeNo == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد باركود بنفس الرقم");
                                }
                            }

                            if (Error == "")
                            {


                                string[] result = null;
                                DataTools.DataBases.Run(ref result, "update TblBarcode set BarcodeNo = @BarcodeNo where BarcodeSN = @BarcodeSN"
                                    , CommandType.Text, new object[][] {
                                          new object[] { "@MeasureAndEncapsulationUnitNo", this.Parent.Parent.Controls["txt08001002001"].Text.Trim() == "" }
                                        , new object[] { "@BarcodeNo", txt002.Text.Replace("'", "").Trim() }
                                        , new object[] { "@BarcodeSN", txt001.Text.Replace("'", "").Trim() }
                                    });

                                if (result[1] == "succeeded")
                                {
                                    txt002.Enabled = false;

                                    btn001.Enabled = true;
                                    btn002.Enabled = false;
                                    btn003.Enabled = true;
                                    btn004.Enabled = true;

                                    dgv001.Enabled = true;
                                    //--------------------------
                                    btn003.Text = Cultures.ReturnTranslation("تعديل");
                                    btn003.Focus();

                                    // تحديث بيانات جدول البيانات
                                    fillTblBarcode();
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
                        GeneralAction.AddNewNotification("frmBarcode  >>  btn002EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);

                        txt001.Enabled = false;
                        txt002.Enabled = false;

                        btn001.Enabled = true;
                        btn002.Enabled = false;
                        btn003.Enabled = true;
                        btn004.Enabled = true;

                        dgv001.Enabled = true;

                        //--------------------------
                        //btn05002009.Text = Cultures.ReturnTranslation("جديد");
                        //btn05002011.Text = Cultures.ReturnTranslation("تعديل");


                        // تحديث بيانات جدول البيانات
                        fillTblBarcode();
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
                    if (Permissions.AccountHavePermission(PermissionObjectes.Barcode, PermissionType.Edit))
                    {

                        if (btn003.Text == Cultures.ReturnTranslation("تعديل"))
                        {
                            txt002.Enabled = true;


                            btn001.Enabled = false;
                            btn002.Enabled = true;
                            btn004.Enabled = false;

                            txt002.Select();

                            dgv001.Enabled = false;
                            btn003.Text = Cultures.ReturnTranslation("إلغاء");
                        }
                        else
                        {

                            txt002.Enabled = false;

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
                        GeneralAction.AddNewNotification("frmBarcode >> btn003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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
                    if (Permissions.AccountHavePermission(PermissionObjectes.Barcode, PermissionType.Delete))
                    {

                        try
                        {

                            if(Convert.ToInt32(txt001.Text) >= 0)
                            {
                                string[] result = null;
                                DataTools.DataBases.Run(ref result, "delete from TblBarcode where BarcodeSN = @BarcodeSN"
                                    , CommandType.Text, new object[][] {
                                    new object[] { "@BarcodeSN", Convert.ToInt32(txt001.Text) } });
                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء قم بتحديد السجل الذي تريد حذفه"), MessageBoxStatus.Ok);
                            }

                        }
                        catch (Exception ex)
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmBarcode  >>  btn004EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                        }

                        txt001.Text = "";
                        txt002.Text = "";

                        // تحديث بيانات جدول البيانات
                        fillTblBarcode();
                        dgv001EventsAndProperties(true);
                        dgv001.Focus();
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmBarcode >> btn004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
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

                    if (TblBarcode.Rows.Count > 0)
                    {
                        dgv001.DataSource = TblBarcode;

                        dgv001.Columns[0].HeaderText = Cultures.ReturnTranslation("الرقم المتسلسل للباركود");
                        dgv001.Columns[1].Visible = false;
                        dgv001.Columns[2].HeaderText = Cultures.ReturnTranslation("رقم الباركود");

                        dgv001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgv001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


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
                    GeneralAction.AddNewNotification("frmBarcode  >>  dgv001EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {

                    if (TblBarcode.Rows.Count > 0)
                    {
                        dgv001.DataSource = TblBarcode;

                        dgv001.Columns[0].HeaderText = Cultures.ReturnTranslation("الرقم المتسلسل للباركود");
                        dgv001.Columns[1].Visible = false;
                        dgv001.Columns[2].HeaderText = Cultures.ReturnTranslation("رقم الباركود");

                        dgv001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgv001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


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
                    GeneralAction.AddNewNotification("frmBarcode  >>  dgv001EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
                }


                dgv001.SelectionChanged += delegate
                {
                    try
                    {
                        if(dgv001.Rows.Count>0)
                        {
                            if (dgv001.SelectedRows is null) return;
                            if (dgv001.SelectedRows.Count <= 0) return;
                            txt001.Text = dgv001.SelectedRows[0].Cells[0].Value.ToString();
                            txt002.Text = dgv001.SelectedRows[0].Cells[2].Value.ToString();
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmBarcode  >>  dgv001EventsAndProperties  ", DateTime.Now, ex.Message, ex.Message);
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
                        GeneralAction.AddNewNotification("frmBarcode >> dgv001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
