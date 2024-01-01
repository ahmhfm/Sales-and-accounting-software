using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mesrakh
{
    public partial class frmInventoryOperations25 : Form
    {
        public frmInventoryOperations25()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmEncapsulationUnits13EventsAndProperties(Properties, Events); // النموذج
            pnl08001EventsAndProperties(Properties, Events);// الحاوية الرئيسية
            pnl08001001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl08001001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl08001002EventsAndProperties(Properties, Events); // الحاوية الثانية

            lbl08001002000EventsAndProperties(Properties, Events);  // ملصق عمليات فتح الصناديق

            lbl08001002001EventsAndProperties(Properties, Events); // ملصق المنتجات
            cbx001EventsAndProperties(Properties, Events); // قائمة منسدلة المنتجات المجمعة

            lbl08001002003EventsAndProperties(Properties, Events); // ملصق الكمية المتوفرة
            txt08001002003EventsAndProperties(Properties, Events); // مربع نص الكمية المتوفرة


            lbl08001002002EventsAndProperties(Properties, Events); // ملصق الكمية
            txt08001002002EventsAndProperties(Properties, Events); // مربع نص الكمية

            btn08001002001EventsAndProperties(Properties, Events); // تحويل


            
            
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
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "عمليات المخزون", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001001001, "عمليات المخزون", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
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
                ElementsTools.panel_.CustumProperties(pnl08001002, ColorPropertyName.BackColor_1, true, true);
            }
        }

        private void lbl08001002000EventsAndProperties(bool Properties, bool Events = false) // ملصق عمليات فتح الصناديق 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002000, "عمليات فتح الصناديق", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_6, true, false);

            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002000, "عمليات فتح الصناديق", ColorPropertyName.BackColor_5, ColorPropertyName.ForeColor_6, true, true);


            }
        }


        private void lbl08001002001EventsAndProperties(bool Properties, bool Events = false) // ملصق اسم المنتج
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "إسم المنتج", ColorPropertyName.BackColor_1);
                lbl08001002001.BackColor = Color.Transparent;


            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002001, "إسم المنتج", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl08001002001.BackColor = Color.Transparent;

            }
        }


        private void cbx001EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة المنتجات المجمعة
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
                            cbx001.DisplayMember = "DetailedNameForProductOrServiceAr";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001);
                    cbx001.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmInventoryOperations25 >> cbx001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                            cbx001.DisplayMember = "DetailedNameForProductOrServiceAr";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001, "", true, true);
                    cbx001.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmInventoryOperations25 >> cbx001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txt08001002002.Select();
                    }
                };

                cbx001.SelectedIndexChanged += delegate
                {
                    if(!(cbx001.SelectedValue is null))
                    {
                        var i = from currentrow in TblproductAndServicesDetails.AsEnumerable()
                                where currentrow[0].ToString().Contains(cbx001.SelectedValue.ToString())
                                select currentrow;
                        foreach (var item in i)
                        {
                            txt08001002003.Text = item[14].ToString();
                        }
                    }

                };
            }
        }

        private void lbl08001002003EventsAndProperties(bool Properties, bool Events = false) // ملصق المتوفرة
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "الكمية المتوفرة", ColorPropertyName.BackColor_1);
                lbl08001002003.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002003, "الكمية المتوفرة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl08001002003.BackColor = Color.Transparent;
            }
        }

        private void txt08001002003EventsAndProperties(bool Properties = true, bool Events = false) // مربع نص الكمية المتوفرة
        {
            string cultureInfo = "";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, cultureInfo, 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002003, cultureInfo, 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Decimal);

                txt08001002003.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt08001002003.Select(); };

                };
            }
        }




        private void lbl08001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق الكمية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "الكمية المراد تحويلها", ColorPropertyName.BackColor_1);
                lbl08001002002.BackColor = Color.Transparent;
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl08001002002, "الكمية المراد تحويلها", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
                lbl08001002002.BackColor = Color.Transparent;
            }
        }

        private void txt08001002002EventsAndProperties(bool Properties = true, bool Events = false) // مربع نص الكمية
        {
            string cultureInfo = "";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, cultureInfo, 9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt08001002002, cultureInfo,9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true,TextBoxType.Decimal);

                txt08001002002.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btn08001002001.PerformClick(); };

                };
            }
        }
        

        //**********************************************************
        private void btn08001002001EventsAndProperties(bool Properties, bool Events = false) // تحويل الوحدة الكبيرة الى وحدة صغيرة 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn08001002001, "تحويل");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn08001002001, "تحويل", ColorPropertyName.ForeColor_1, true, true);

                btn08001002001.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Inventory_Operations, PermissionType.Edit))
                        {

                            string Error = "";
                            if (txt08001002002.Text.Trim() == "")
                            {
                                txt08001002002.Focus();
                                return;
                            }
                            else if (cbx001.SelectedIndex < 0)
                            {
                                cbx001.Focus();
                                return;
                            }
                            if(Convert.ToDecimal(txt08001002002.Text) > Convert.ToDecimal(txt08001002003.Text)  )
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("الكميرة المراد تحويلها أكبر من الكمية المتوفرة بالمخزون"), MessageBoxStatus.Ok);

                                txt08001002002.Focus();
                                txt08001002002.SelectAll();
                                return;

                            }
                            if( Convert.ToDecimal(txt08001002003.Text) == 0)
                            {
                                return; 
                            }

                            string[] result = null;
                            object result2 = DataTools.DataBases.Run(ref result, "spConvertingToSmallestUnit",
                                CommandType.StoredProcedure, new object[][]
                                {
                                    new object[] { "@UnitDetailsNo", cbx001.SelectedValue },
                                    new object[] { "@Qty", txt08001002002.Text }
                                });


                            if (result[1] == "succeeded")
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("تم التحويل بنجاح"), MessageBoxStatus.Ok);
                                txt08001002002.Text = "";
                                txt08001002003.Text = "";
                                cbx001.SelectedIndex = -1;
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmInventoryOperations25 >> btn08001002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {

                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmInventoryOperations25 >> btn08001002001EventsAndProperties", DateTime.Now, ex.Message, ex.Message);
                    }   

                };


            }


        }

        //-----------------------------------------------------------------------------------------------------------------------------
        DataTable TblproductAndServicesDetails = new DataTable(); // المنتجات المجمعة
        private void fillTblproductAndServicesDetails() // تعبئة جدول المنتجات المجمعة
        {
            try
            {
                if(TblproductAndServicesDetails != null)
                {
                    if (TblproductAndServicesDetails.Rows.Count > 0)
                    {
                        TblproductAndServicesDetails.Rows.Clear();
                    }
                }
                else
                {
                    TblproductAndServicesDetails = new DataTable();
                }

                TblproductAndServicesDetails = DataTools.DataBases.ReadTabel(" select * from TblproductAndServicesDetails where UnitDetailsNoSelfJoin is not null");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmEmployees18 >> fillTblproductAndServicesDetails ", DateTime.Now, ex.Message, ex.Message);
            }
        }
    }


}

