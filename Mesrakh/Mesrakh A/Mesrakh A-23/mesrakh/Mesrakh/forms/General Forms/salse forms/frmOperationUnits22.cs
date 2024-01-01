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
    public partial class frmOperationUnits22 : Form
    {
        public frmOperationUnits22()
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

            frmEncapsulationUnits13EventsAndProperties(Properties, Events); // النموذج 
            pnl08001EventsAndProperties(Properties, Events); // الحاوية الرئيسية
            pnl08001001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl08001001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl08001002EventsAndProperties(Properties, Events); // الحاوية الثانية
            lbl001EventsAndProperties(Properties, Events); // ملصق المنشأة
            cbx001EventsAndProperties(Properties, Events); // قائمة منسدلة المنشآت
            lbl002EventsAndProperties(Properties, Events); // ملصق الفرع
            cbx002EventsAndProperties(Properties, Events); // قائمة منسدلة الفروع
            lbl003EventsAndProperties(Properties, Events); // ملصق رقم وحدة العمليات
            cbx003EventsAndProperties(Properties, Events); // قائمة رقم وحدة العمليات
            //lbl004EventsAndProperties(Properties, Events); // ملصق رقم الحساب
            //txt001EventsAndProperties(Properties, Events); // مربع نص رقم الحساب

            lblCurrentOperationNumberEventsAndProperties(Properties, Events); // ملصق رقم وحدة العمليات الحالي

            btn001EventsAndProperties(Properties, Events); // إضافة
            btn002EventsAndProperties(Properties, Events); // حذف
            btnSaveEventsAndProperties(Properties, Events); // حفظ


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
                ElementsTools.Lable_.CustumProperties(lblTitel, "تسجيل رقم وحدة العمليات", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblTitel, "تسجيل رقم وحدة العمليات", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
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

        //**************

        private void lbl001EventsAndProperties(bool Properties, bool Events = false) // ملصق المنشأة
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001, "المنشأة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001, "المنشأة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void cbx001EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة المنشآت
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblEnterprise is null) fillTblEnterprise();
                    if (TblEnterprise is null) return;
                    if (TblEnterprise.Rows.Count > 0)
                    {
                        cbx001.DataSource = TblEnterprise;
                        cbx001.ValueMember = "EnterpriseNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001.DisplayMember = "EnterpriseNameAR";
                        }
                        else
                        {
                            cbx001.DisplayMember = "EnterpriseNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmOperationUnits22 >> cbx001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblEnterprise();

                    if (TblEnterprise is null) return;
                    if (TblEnterprise.Rows.Count > 0)
                    {
                        cbx001.DataSource = TblEnterprise;
                        cbx001.ValueMember = "EnterpriseNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx001.DisplayMember = "EnterpriseNameAR";
                        }
                        else
                        {
                            cbx001.DisplayMember = "EnterpriseNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx001, "", true, true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmOperationUnits22 >> cbx001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx002.Select();
                    }
                };

                cbx001.SelectedIndexChanged += delegate
                {
                    fillTblEnterpriseBranches();
                    cbx002EventsAndProperties(true);
                };

            }
        }


        private void lbl002EventsAndProperties(bool Properties, bool Events = false) // ملصق الفرع
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl002, "الفرع", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl002, "الفرع", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }


        private void cbx002EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة الفروع
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblEnterpriseBranches is null) fillTblEnterpriseBranches();
                    if (TblEnterpriseBranches is null) return;
                    if (TblEnterpriseBranches.Rows.Count > 0)
                    {
                        cbx002.DataSource = TblEnterpriseBranches;
                        cbx002.ValueMember = "BranchNumber";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx002.DisplayMember = "BranchNameAR";
                        }
                        else
                        {
                            cbx002.DisplayMember = "BranchNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx002);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmOperationUnits22 >> cbx002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblEnterpriseBranches();

                    if (TblEnterpriseBranches is null) return;
                    if (TblEnterpriseBranches.Rows.Count > 0)
                    {
                        cbx002.DataSource = TblEnterpriseBranches;
                        cbx002.ValueMember = "BranchNumber";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx002.DisplayMember = "BranchNameAR";
                        }
                        else
                        {
                            cbx002.DisplayMember = "BranchNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx002, "", true, true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmOperationUnits22 >> cbx002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx002.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx003.Select();
                    }
                };

                cbx002.SelectedIndexChanged += delegate
                {
                    fillTblOperationUnits();
                    cbx003EventsAndProperties(true);
                };

            }
        }

        private void lbl003EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم وحدة العمليات
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "وحدة العمليات", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl003, "وحدة العمليات", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void cbx003EventsAndProperties(bool Properties, bool Events = false) // قائمة رقم وحدة العمليات
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblOperationUnits is null) fillTblOperationUnits();
                    if (TblOperationUnits is null) return;
                    if (TblOperationUnits.Rows.Count > 0)
                    {
                        cbx003.DataSource = TblOperationUnits;
                        cbx003.ValueMember = "OperationUnitNumber";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx003.DisplayMember = "UnitNoInBranch";
                        }
                        else
                        {
                            cbx003.DisplayMember = "UnitNoInBranch";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx003);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmOperationUnits22 >> cbx003EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblOperationUnits();

                    if (TblOperationUnits is null) return;
                    if (TblOperationUnits.Rows.Count > 0)
                    {
                        cbx003.DataSource = TblOperationUnits;
                        cbx003.ValueMember = "OperationUnitNumber";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbx003.DisplayMember = "UnitNoInBranch";
                        }
                        else
                        {
                            cbx003.DisplayMember = "UnitNoInBranch";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbx003, "", true, true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmOperationUnits22 >> cbx003EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx003.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        btn001.PerformClick();
                    }
                };

            }
        }


        //private void lbl004EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم الحساب
        //{

        //    if (Properties == true & Events == false)
        //    {
        //        ElementsTools.Lable_.CustumProperties(lbl004, "رقم الحساب", ColorPropertyName.BackColor_1);
        //    }
        //    else if (Properties == true & Events == true)
        //    {
        //        ElementsTools.Lable_.CustumProperties(lbl004, "رقم الحساب", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
        //    }
        //}

        //private void txt001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم الحساب 
        //{
        //    string cultureInfo = "";
        //    if (Properties == true && Events == false)
        //    {
        //        ElementsTools.TextBox_.CustumProperties(txt001, cultureInfo, 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Int);
        //    }
        //    else if (Properties == true && Events == true)
        //    {
        //        ElementsTools.TextBox_.CustumProperties(txt001, cultureInfo, 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Int);

        //        txt001.KeyDown += delegate (object sender, KeyEventArgs e)
        //        {
        //            if (e.KeyData == Keys.Enter) { btn001.PerformClick(); };
        //        };
        //    }
        //}


        private void lblCurrentOperationNumberEventsAndProperties(bool Properties, bool Events = false) // ملصق رقم وحدة العمليات الحالي
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblCurrentOperationNumber, "", ColorPropertyName.BackColor_1);

                //lblCurrentOperationNumber.Text = "";
                if (TblCurrentOperationUnit != null)
                {
                    if (TblCurrentOperationUnit.Rows.Count > 0)
                    {
                        lblCurrentOperationNumber.Text = TblCurrentOperationUnit.Rows[0][2].ToString();
                    }
                }
            }
            else if (Properties == true & Events == true)
            {
                fillTblCurrentOperationUnit();
                ElementsTools.Lable_.CustumProperties(lblCurrentOperationNumber, "", ColorPropertyName.BackColor_1,ColorPropertyName.ForeColor_1,true,true);

                //lblCurrentOperationNumber.Text = "";
                if (TblCurrentOperationUnit != null)
                {
                    if(TblCurrentOperationUnit.Rows.Count>0)
                    {
                        lblCurrentOperationNumber.Text = TblCurrentOperationUnit.Rows[0][2].ToString();
                    }
                }

            }
        }

        //*************





        private void btn001EventsAndProperties(bool Properties, bool Events = false) // إضافة 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001, "إضافة");
            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn001, "إضافة", ColorPropertyName.ForeColor_1, true, true);

                btn001.Click += delegate
                {
                    try
                    {

                        if(lblCurrentOperationNumber.Text=="")
                        {
                            if (btn001.Text == Cultures.ReturnTranslation("إضافة"))
                            {
                                btn001.Text = Cultures.ReturnTranslation("إلغاء");
                                pnl001.Visible = true;
                            }
                            else
                            {

                                btn001.Text = Cultures.ReturnTranslation("إضافة");
                                pnl001.Visible = false;
                            }

                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء قم بحذف رقم وحدة العمليات السابق قبل الإضافة") , MessageBoxStatus.Ok);
                            btn001.Text = Cultures.ReturnTranslation("إضافة");
                            pnl001.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmOperationUnits22 >> btn001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                

            }


        }


        private void btnSaveEventsAndProperties(bool Properties, bool Events = false) // حفظ 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btnSave, "حفظ");
            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btnSave, "حفظ", ColorPropertyName.ForeColor_1, true, true);

                btnSave.Click += delegate
                {
                    try
                    {

                        btn001.Text = "إضافة";
                        pnl001.Visible = false;


                        string Error = "";
                        if (cbx003.SelectedIndex < 0)
                        {
                            Error = Cultures.ReturnTranslation("رجاء قم بتحديد رقم وحدة العمليات");
                            cbx003.Select();
                        }


                        if (Error == "")
                        {

                            string[] result = null;
                            object result2 = DataTools.DataBases.Run(ref result, "update TblOperationUnits set  DeviceNumber = @DeviceNumber   where OperationUnitNumber = @OperationUnitNumber", CommandType.Text, new object[][] { new object[] { "@DeviceNumber", SecurityTools.specialDevices.getCPUID() }, new object[] { "@OperationUnitNumber", cbx003.SelectedValue } });


                            if (result[1] == "succeeded")
                            {
                                Mesrakh.Properties.Settings.Default["OperationUnitNumber"] = cbx003.SelectedValue.ToString();
                                Mesrakh.Properties.Settings.Default.Save();

                                fillTblOperationUnits();
                                fillTblCurrentOperationUnit();
                                AllEventsAndProperties(true);

                            }

                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);

                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmOperationUnits22 >> btn001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

            }

        }


        private void btn002EventsAndProperties(bool Properties, bool Events = false) // حذف 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn002, "حذف");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn002, "حذف", ColorPropertyName.ForeColor_1, true, true);
                btn002.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Encapsulation_Units, PermissionType.Delete))
                    {
                        try
                        {

                            if(lblCurrentOperationNumber.Text.Trim() != "")
                            {
                                string[] result = null;
                                object result2 = DataTools.DataBases.Run(ref result, "update TblOperationUnits set  DeviceNumber = null where OperationUnitNumber = @OperationUnitNumber", CommandType.Text, new object[][] { new object[] { "@DeviceNumber", SecurityTools.specialDevices.getCPUID() }, new object[] { "@OperationUnitNumber", Mesrakh.Properties.Settings.Default["OperationUnitNumber"] } });

                                if (result[1] == "succeeded")
                                {
                                    Mesrakh.Properties.Settings.Default["OperationUnitNumber"] = "";
                                    Mesrakh.Properties.Settings.Default.Save();

                                    fillTblOperationUnits();
                                    fillTblCurrentOperationUnit();
                                    AllEventsAndProperties(true);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            GeneralAction.AddNewNotification("frmEncapsulationUnits13 >> btn08001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        }


                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEncapsulationUnits13 >> btn08001002004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }


                };
            }
        }

        
        //------------------------------ 
        DataTable TblEnterprise = new DataTable(); // جدول المنشآت 
        DataTable TblEnterpriseBranches = new DataTable(); // جدول الفروع 
        DataTable TblOperationUnits = new DataTable(); // جدول وحدات العمليات 
        DataTable TblCurrentOperationUnit = new DataTable(); // جدول وحدات العمليات الحالية 

        // تعبئة جدول المنشآت
        private void fillTblEnterprise()
        {
            try
            {

                if(TblEnterprise != null)
                {
                    if (TblEnterprise.Rows.Count > 0) TblEnterprise.Rows.Clear();

                    TblEnterprise = DataTools.DataBases.ReadTabel("select * from TblEnterprise ");
                }
                else
                {
                    TblEnterprise = new DataTable();
                    TblEnterprise = DataTools.DataBases.ReadTabel("select * from TblEnterprise ");
                }

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmOperationUnits22 >> fillTblEnterprise ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        // تعبئة جدول الفروع
        private void fillTblEnterpriseBranches()
        {
            try
            {

                if(TblEnterpriseBranches != null)
                {
                    if (TblEnterpriseBranches.Rows.Count > 0) TblEnterpriseBranches.Rows.Clear();

                    TblEnterpriseBranches = DataTools.DataBases.ReadTabel("select * from TblEnterpriseBranches where EnterpriseNo = " + cbx001.SelectedValue);
                }
                else
                {
                    TblEnterpriseBranches = new DataTable();
                    TblEnterpriseBranches = DataTools.DataBases.ReadTabel("select * from TblEnterpriseBranches where EnterpriseNo = " + cbx001.SelectedValue);

                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmOperationUnits22 >> fillTblEnterpriseBranches ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        // تعبئة جدول وحدات العمليات
        private void fillTblOperationUnits()
        {
            try
            {

                if(TblOperationUnits != null)
                {
                    if (TblOperationUnits.Rows.Count > 0) TblOperationUnits.Rows.Clear();

                    TblOperationUnits = DataTools.DataBases.ReadTabel("select * from TblOperationUnits where  DeviceNumber is null  and BranchNumber = " + cbx002.SelectedValue + " ");
                }
                else
                {
                    TblOperationUnits = new DataTable();
                    TblOperationUnits = DataTools.DataBases.ReadTabel("select * from TblOperationUnits where DeviceNumber is null  and BranchNumber = " + cbx002.SelectedValue + " ");

                }


            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmOperationUnits22 >> fillTblOperationUnits ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        // تعبئة جدول وحدات العمليات الحالية
        private void fillTblCurrentOperationUnit()
        {
            try
            {

                if (TblCurrentOperationUnit.Rows.Count > 0) TblCurrentOperationUnit.Rows.Clear();

                if(Mesrakh.Properties.Settings.Default["OperationUnitNumber"] != null)
                {
                    if (Mesrakh.Properties.Settings.Default["OperationUnitNumber"] != "")
                    {
                        TblCurrentOperationUnit = DataTools.DataBases.ReadTabel("select * from TblOperationUnits where OperationUnitNumber = " + Mesrakh.Properties.Settings.Default["OperationUnitNumber"]);
                    }

                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmOperationUnits22 >> fillTblCurrentOperationUnit ", DateTime.Now, ex.Message, ex.Message);
            }
        }

    }


}

