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
    public partial class frmShifts21 : Form
    {
        public frmShifts21()
        {
            InitializeComponent();

            AllEventsAndProperties(true, true); // جميع عناصر النموذج
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {

            frmEventsAndProperties(Properties, Events); // النموذج
            pnl001EventsAndProperties(Properties, Events);// الحاوية الرئيسية
            pnl001001EventsAndProperties(Properties, Events); // الحاوية العلوية
            lbl001001001EventsAndProperties(Properties, Events); // ملصق عنوان النموذج 
            pnl001002EventsAndProperties(Properties, Events); // الحاوية الثانية

            lbl001002001EventsAndProperties(Properties, Events); // ملصق رقم الوردية 
            txt001002001EventsAndProperties(Properties, Events); // مربع نص رقم الوردية
            lbl001002002EventsAndProperties(Properties, Events); //  ملصق تاريخ ووقت فتح الوردية 
            dateTimePicker1EventsAndProperties(Properties, Events); // تاريخ ووقت فتح الوردية
            lbl001002003EventsAndProperties(Properties, Events); //  ملصق رقم الوردية المستلمة
            cbxShiftsForClosingEventsAndProperties(Properties, Events); // قائمة منسدلة بالورديات المراد اغلاقها
            
            lbl001002004EventsAndProperties(Properties, Events); //  ملصق الرصيد المستلم من الوردية السابقة
            txt001002003EventsAndProperties(Properties, Events); // مربع نص الرصيد المستلم من الوردية السابقة
            lbl001002005EventsAndProperties(Properties, Events); //  ملصق رقم المستخدم
            txt001002004EventsAndProperties(Properties, Events); // مربع نص رقم المستخدم
            lbl001002006EventsAndProperties(Properties, Events); //  ملصق رقم وحدة العمليات
            txt001002005EventsAndProperties(Properties, Events); // مربع نص رقم وحدة العمليات
            lbl001002007EventsAndProperties(Properties, Events); //  ملصق حالة الوردية
            cbx001002001EventsAndProperties(Properties, Events); // قائمة منسدلة حالة الوردية
            lbl001002008EventsAndProperties(Properties, Events); //  ملصق تاريخ ووقت إقفال الوردية
            dateTimePicker2EventsAndProperties(Properties, Events); // تاريخ ووقت إقفال الوردية
            lbl001002010EventsAndProperties(Properties, Events); //  ملصق رقم الحساب الذي قام بالاقفال
            cbxRecevingAccountEventsAndProperties(Properties, Events); //  الموظف الذي قام بإستلام الوردية
            lbl001002011EventsAndProperties(Properties, Events); //  ملصق الرصيد القيدي
            txt001002007EventsAndProperties(Properties, Events); // مربع نص الرصيد القيدي
            lbl001002012EventsAndProperties(Properties, Events); //  ملصق الرصيد الفعلي
            txt001002008EventsAndProperties(Properties, Events); // مربع نص الرصيد الفعلي
            lbl00100213EventsAndProperties(Properties, Events); //  ملصق الفرق بين الرصيدين
            txt001002009EventsAndProperties(Properties, Events); // مربع نص الفرق بين الرصيدين

            btn001002001EventsAndProperties(Properties, Events); // جديد
            btn001002002EventsAndProperties(Properties, Events); // حفظ
            btn001002003EventsAndProperties(Properties, Events); // تعديل

            checkBox1EventsAndProperties(Properties, Events);
            checkBox2EventsAndProperties(Properties, Events);
            checkBox3EventsAndProperties(Properties, Events);
            checkBox4EventsAndProperties(Properties, Events);
            checkBox5EventsAndProperties(Properties, Events);
            checkBox6EventsAndProperties(Properties, Events);
            checkBox7EventsAndProperties(Properties, Events);
            checkBox8EventsAndProperties(Properties, Events);
            checkBox10EventsAndProperties(Properties, Events);
            checkBox11EventsAndProperties(Properties, Events);
            checkBox12EventsAndProperties(Properties, Events);
            checkBox13EventsAndProperties(Properties, Events);
            dgv001EventsAndProperties(Properties, Events); // جدول عرض بيانات الفروع

            //-------- البحث
            lblSearchEventsAndProperties(Properties, Events);// ملصق البحث عن
            txtSearchEventsAndProperties(Properties, Events);// مربع نص البحث عن

            
        }


        private void frmEventsAndProperties(bool Properties, bool Events = false) // النموذج 
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
                    // اذا كان رقم وحدة العمليات غير مخزن على البرنامج 
                    if (string.IsNullOrEmpty(Mesrakh.Properties.Settings.Default["OperationUnitNumber"].ToString()))
                    {
                        // التأكد هل لهذا الجهاز رقم وحدة عمليات في قاعدة البيانات
                        DataTable dt = new DataTable();
                        dt = DataTools.DataBases.ReadTabel("select * from TblOperationUnits where DeviceNumber = '" + SecurityTools.specialDevices.getCPUID() + "'");
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Mesrakh.Properties.Settings.Default["OperationUnitNumber"] = dt.Rows[0][0].ToString();
                                Mesrakh.Properties.Settings.Default.Save();
                            }
                        }

                    }

                    // اذا لم لكن هذا الجهاز مسجل كوحدة عمليات
                    if (string.IsNullOrEmpty(Mesrakh.Properties.Settings.Default["OperationUnitNumber"].ToString()))
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("هذا الجهاز غير مسجل كوحدة عمليات"), MessageBoxStatus.Ok);
                        foreach (Control control in this.Controls)
                        {
                            control.Enabled = false;
                        }
                        return;
                    }


                    //DataTable TblOpenShifts = new DataTable(); // الورديات المفتوحة لجميع الحسابات
                    //DataTable TblClosingShifts = new DataTable(); // الورديات المفتوحة لجميع الحسابات
                    //DataTable TblOpenShiftsForThisAccount = new DataTable(); // الورديات المفتوحة لهذا الحساب 
                    //DataTable TblClosingShiftsForThisAccount = new DataTable(); // الورديات المغلقة لهذا الحساب 
                    //DataTable TblOpenShiftsForThisOperationUnit = new DataTable(); // الوردية المفتوحة على وحدة العمليات الحالية 
                    //DataTable TblShiftsForClosing = new DataTable(); // ورديات للإغلاق 
                    //DataTable TblEmployeesAndAccounts = new DataTable(); // الموظفين وحساباتهم 
                    //DataTable TblOperationUnits = new DataTable(); // بيانات الفرع ووحدة العمليات الحالية 


                    fillTblOpenShifts(); // تعبئة جدول الورديات المفتوحة لجميع الحسابات
                    fillTblClosingShifts(); // تعبئة جدول الورديات المغلقة لجميع الحسابات

                    fillTblOpenShiftsForThisAccount(); // تعبئة جدول الورديات المفتوحة لهذا الحساب
                    fillTblClosingShiftsForThisAccount(); // تعبئة جدول الورديات المغلقة لهذا الحساب

                    fillTblShiftsForClosing(); // تعبئة جدول ورديات للإغلاق

                    TblShiftsOpenOnThisDevice();  //  الورديات المفتوحة على هذا الجهاز

                    fillTblEmployeesAndAccounts(); // تعبئة جدول الموظفين وحساباتهم
                    fillTblOperationUnits(); // بيانات الفرع ووحدة العمليات الحالية
                    string CurrentAccountNo = GeneralVariables.ActiveAccount.Rows[0][0].ToString(); // رقم حساب المستخدم الحالي


                    //fillDataForAllElements(DataTable tblShift) // تعبئة جميع العناصر ببيانات الشفت

                    // هل هناك وردية مفتوحة على وحدة العمليات الحالية
                    bool OpenShiftsForThisOperationUnit = false; 
                    if (GeneralVariables.TblShiftsOpenOnThisDevice != null)
                    {
                        if(GeneralVariables.TblShiftsOpenOnThisDevice.Rows.Count>0)
                        {
                            OpenShiftsForThisOperationUnit = true;
                        }
                    }

                    // عمليات التحقق من شرط عدم وجود وردية مفتوحة للحساب الحالي على اجهزة اخرى
                    if(TblOpenShiftsForThisAccount != null)
                    {
                        if(TblOpenShiftsForThisAccount.Rows.Count > 0)
                        {
                            if(TblOperationUnits != null)
                            {
                                if(TblOperationUnits.Rows.Count > 0)
                                {
                                    //MessageBox.Show(TblOpenShiftsForThisAccount.Rows[0][5].ToString() +"     "+ TblOperationUnits.Rows[0][0].ToString());
                                    if (TblOpenShiftsForThisAccount.Rows[0][5].ToString() != TblOperationUnits.Rows[0][0].ToString())// نعم لدى الحساب الحالي ورديات مفتوحة على اجهزة اخرى
                                    {
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("لديك وردية مفتوحة على وحدة عمليات أخرى"), MessageBoxStatus.Ok);

                                        foreach (Control control in this.Controls)
                                        {
                                            control.Enabled = false;
                                        }
                                        return;
                                    }
                                }
                                else
                                {
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("وحدة العمليات الحالية غير مهيئة"), MessageBoxStatus.Ok);
                                    foreach (Control control in this.Controls)
                                    {
                                        control.Enabled = false;
                                    }
                                    return;
                                }
                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("خطأ"), Cultures.ReturnTranslation("وحدة العمليات الحالية غير مهيئة"), MessageBoxStatus.Ok);
                                foreach (Control control in this.Controls)
                                {
                                    control.Enabled = false;
                                }
                                return;
                            }

                        }
                    }
                    


                    //  العمليات على بقية الشروط
                    if (OpenShiftsForThisOperationUnit)// نعم توجد وردية مفتوحة على وحدة العمليات الحالية 
                    {
                        if(GeneralVariables.TblShiftsOpenOnThisDevice.Rows[0][4].ToString() == CurrentAccountNo)// نعم الوردية المفتوحة على هذا الجهاز تخص المستخدم الحالي
                        {
                            fillDataForAllElements(GeneralVariables.TblShiftsOpenOnThisDevice); // تعبئة جميع العناصر ببيانات الشفت
                        }
                        else// لا الوردية المفتوحة على هذا الجهاز لا تخص المستخدم الحالي
                        {
                            if(GeneralVariables.TblShiftsOpenOnThisDevice.Rows[0][6].ToString() == "2") // نعم حالية الوردية المفتوحة على هذا الجهاز للإغلاق
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("هل تريد إستلام الوردية الموجودة على هذا الجهاز"), MessageBoxStatus.YesAndNo);
                                
                                if (GeneralVariables.MessageBoxResult == "Yes")// اجراءات استلام الوردية الموجودة على هذا الجهاز
                                {
                                    btn001002001.PerformClick();//فتح لاستلام الوردية الموجودة على هذا الجهاز 
                                    cbxShiftsForClosing.SelectedValue = GeneralVariables.TblShiftsOpenOnThisDevice.Rows[0][0].ToString();// الوردية المستلمة
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("إستلام وردية سابقة"), Cultures.ReturnTranslation("كم المبلغ المستلم"), MessageBoxStatus.Number);
                                    txt001002003.Text = GeneralVariables.MessageBoxResult; // المبلغ المستلم
                                    btn001002002.PerformClick(); // الحفظ
                                }
                                else
                                {

                                    foreach (Control control in this.Controls)
                                    {
                                        control.Enabled = false;
                                    }
                                }
                            }
                            else // لا حالة الوردية المفتوحة على هذا الجهاز ليست للإغلاق
                            {
                                foreach (Control control in this.Controls)
                                {
                                    control.Enabled = false;
                                }
                            }
                        }
                    }
                    else// لا توجد وردية مفتوحة على وحدة العمليات الحالية
                    {
                        // إجراءات فتح وردية جديدة او استلام وريدة موجودة على جهاز آخر
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("هل تريد إستلام وردية أخرى ؟"), MessageBoxStatus.YesAndNo);

                        if (GeneralVariables.MessageBoxResult == "Yes")// اجراءات استلام الوردية الموجودة على جهاز اخر
                        {
                            btn001002001.PerformClick();//فتح لاستلام الوردية الموجودة على جهاز اخر 

                        }
                        else // اجراءات فتح وردية جديدة 
                        {

                            btn001002001.PerformClick();// فتح لانشاء وردية جديدة  
                            cbxShiftsForClosing.SelectedIndex = -1;
                            txt001002003.Text = "0";
                            btn001002002.PerformClick(); // الحفظ

                        }
                    }


                   

                };
            }
        }

        private void pnl001EventsAndProperties(bool Properties, bool Events = false) // الحاوية الرئيسية
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl001);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl001, ColorPropertyName.BackColor_3, true, true);
            }
        }

        private void pnl001001EventsAndProperties(bool Properties, bool Events = false) // الحاوية العلوية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl001001, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl001001, ColorPropertyName.BackColor_2, true, true);
            }
        }

        private void lbl001001001EventsAndProperties(bool Properties, bool Events = false) // ملصق عنوان النموذج 
        {


            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001001001, "الورديات", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001001001, "الورديات", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void pnl001002EventsAndProperties(bool Properties, bool Events = false) // الحاوية الثانية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl001002);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl001002, ColorPropertyName.BackColor_3, true, true);
            }
        }




        //--------- ***** ----------
        private void lbl001002001EventsAndProperties(bool Properties, bool Events = false) // ملصق رقم الوردية 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002001, "رقم الوردية", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002001, "رقم الوردية", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم الوردية
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002001, "", 10);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002001, "", 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void checkBox1EventsAndProperties(bool Properties, bool Events = false) // مربع اختيار رقم الوردية
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox1, "");
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox1, "", ColorPropertyName.ForeColor_1, true, true);

                checkBox1.CheckedChanged += delegate
                {
                    dgv001EventsAndProperties(true);
                };
            }
        }

        private void lbl001002002EventsAndProperties(bool Properties, bool Events = false) //  ملصق تاريخ ووقت فتح الوردية 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002002, "تاريخ ووقت فتح الوردية", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002002, "تاريخ ووقت فتح الوردية", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void dateTimePicker1EventsAndProperties(bool Properties = true, bool Events = false) // تاريخ ووقت فتح الوردية
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.DateTimePicker_.CustumProperties(dateTimePicker1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.DateTimePicker_.CustumProperties(dateTimePicker1, true, true);

                dateTimePicker1.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002003.Select(); };
                };
            }
        }

        private void checkBox2EventsAndProperties(bool Properties, bool Events = false) // مربع اختيار تاريخ ووقت فتح الوردية
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox2, "");
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox2, "", ColorPropertyName.ForeColor_1, true, true);

                checkBox2.CheckedChanged += delegate
                {
                    dgv001EventsAndProperties(true);
                };
            }
        }

        private void lbl001002003EventsAndProperties(bool Properties, bool Events = false) //  ملصق استلام وردية الموظف
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002003, "إستلام وردية الموظف", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002003, "إستلام وردية الموظف", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void cbxShiftsForClosingEventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة ورديات للإغلاق
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    ElementsTools.ComboBox_.CustumProperties(cbxShiftsForClosing);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmShifts21 >> cbxShiftsForClosingEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {

                   //cbxShiftsForClosing.KeyDown += delegate (object sender, KeyEventArgs e)
                    //{
                    //    if (e.KeyData == Keys.F1)
                    //    {

                    //        fillTblShiftsForClosing();

                    //        if (TblShiftsForClosing.Columns.Count > 0)
                    //        {
                    //            if (cbxShiftsForClosing.DataSource == null)
                    //            {
                    //                cbxShiftsForClosing.DataSource = TblShiftsForClosing;
                    //            }
                    //            cbxShiftsForClosing.ValueMember = "ShiftNumber";
                    //            if (GeneralVariables.cultureCode == "AR")
                    //            {
                    //                cbxShiftsForClosing.DisplayMember = "EmployeeNameAR";
                    //            }
                    //            else
                    //            {
                    //                cbxShiftsForClosing.DisplayMember = "EmployeeNameEN";
                    //            }

                    //        }
                    //    };
                    //};


                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmShifts21 >> cbxShiftsForClosingEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbxShiftsForClosing.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        
                    }
                };

            }
        }

        private void checkBox3EventsAndProperties(bool Properties, bool Events = false) // مربع اختيار رقم الوردية المستلمة
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox3, "");
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox3, "", ColorPropertyName.ForeColor_1, true, true);

                checkBox3.CheckedChanged += delegate
                {
                    dgv001EventsAndProperties(true);
                };
            }
        }
        private void lbl001002004EventsAndProperties(bool Properties, bool Events = false) //  ملصق الرصيد المستلم من الوردية السابقة
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002004, "الرصيد المستلم من الوردية السابقة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002004, "الرصيد المستلم من الوردية السابقة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص الرصيد المستلم من الوردية السابقة
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002003, "", 11);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002003, "", 11, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void checkBox4EventsAndProperties(bool Properties, bool Events = false) // مربع اختيار الرصيد المستلم من الوردية السابقة
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox4, "");
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox4, "", ColorPropertyName.ForeColor_1, true, true);

                checkBox4.CheckedChanged += delegate
                {
                    dgv001EventsAndProperties(true);
                };

            }
        }

        private void lbl001002005EventsAndProperties(bool Properties, bool Events = false) //  ملصق رقم المستخدم
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002005, "رقم المستخدم", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002005, "رقم المستخدم", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002004EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم المستخدم
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002004, "", 10);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002004, "", 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void checkBox5EventsAndProperties(bool Properties, bool Events = false) // مربع اختيار رقم المستخدم
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox5, "");
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox5, "", ColorPropertyName.ForeColor_1, true, true);

                checkBox5.CheckedChanged += delegate
                {
                    dgv001EventsAndProperties(true);
                };

            }
        }

        private void lbl001002006EventsAndProperties(bool Properties, bool Events = false) //  ملصق رقم وحدة العمليات
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002006, "رقم وحدة العمليات", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002006, "رقم وحدة العمليات", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002005EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم وحدة العمليات
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002005, "", 10);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002005, "", 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void checkBox6EventsAndProperties(bool Properties, bool Events = false) // مربع اختيار رقم وحدة العمليات
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox6, "");
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox6, "", ColorPropertyName.ForeColor_1, true, true);

                checkBox6.CheckedChanged += delegate
                {
                    dgv001EventsAndProperties(true);
                };

            }
        }

        private void lbl001002007EventsAndProperties(bool Properties, bool Events = false) //  ملصق حالة الوردية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002007, "حالة الوردية", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002007, "حالة الوردية", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void cbx001002001EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة حالة الوردية
        {
            DataTable dt = new DataTable();
            if (Properties == true && Events == false)
            {
                try
                {
                    if (dt is null) { dt = new DataTable(); }
                    if (dt.Columns.Count < 1)
                    {
                        dt.Columns.Add("no");
                        dt.Columns.Add("ar");
                        dt.Columns.Add("en");
                        dt.Rows.Add("1", "نشط", "active");
                        dt.Rows.Add("2", "للإغلاق", "to close");
                        dt.Rows.Add("3", "إقفال مرحلي", "phase closure");
                        dt.Rows.Add("4", "إقفال نهائي", "final closing");

                    }
                    else
                    {
                        if (dt.Rows.Count < 1)
                        {
                            dt.Rows.Add("1", "نشط", "active");
                            dt.Rows.Add("2", "للإغلاق", "to close");
                            dt.Rows.Add("3", "إقفال مرحلي", "phase closure");
                            dt.Rows.Add("4", "إقفال نهائي", "final closing");
                        }
                    }

                    cbx001002001.DataSource = dt;
                    cbx001002001.ValueMember = "no";
                    if (GeneralVariables.cultureCode == "AR")
                    {
                        cbx001002001.DisplayMember = "ar";
                    }
                    else
                    {
                        cbx001002001.DisplayMember = "en";
                    }

                    ElementsTools.ComboBox_.CustumProperties(cbx001002001, "", true, true);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmShifts21 >> cbx001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (dt is null) { dt = new DataTable(); }
                    if (dt.Columns.Count < 1)
                    {
                        dt.Columns.Add("no");
                        dt.Columns.Add("ar");
                        dt.Columns.Add("en");
                        dt.Rows.Add("1", "نشط", "active");
                        dt.Rows.Add("2", "للإغلاق", "to close");
                        dt.Rows.Add("3", "إقفال مرحلي", "phase closure");
                        dt.Rows.Add("4", "إقفال نهائي", "final closing");

                    }
                    else
                    {
                        if (dt.Rows.Count < 1)
                        {
                            dt.Rows.Add("1", "نشط", "active");
                            dt.Rows.Add("2", "للإغلاق", "to close");
                            dt.Rows.Add("3", "إقفال مرحلي", "phase closure");
                            dt.Rows.Add("4", "إقفال نهائي", "final closing");
                        }
                    }

                    cbx001002001.DataSource = dt;
                    cbx001002001.ValueMember = "no";
                    if (GeneralVariables.cultureCode == "AR")
                    {
                        cbx001002001.DisplayMember = "ar";
                    }
                    else
                    {
                        cbx001002001.DisplayMember = "en";
                    }



                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmShifts21 >> cbx001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx001002001.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        
                    }
                };

            }
        }

        private void checkBox7EventsAndProperties(bool Properties, bool Events = false) // مربع اختيار  حالة الوردية
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox7, "");
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox7, "", ColorPropertyName.ForeColor_1, true, true);

                checkBox7.CheckedChanged += delegate
                {
                    dgv001EventsAndProperties(true);
                };

            }
        }
        private void lbl001002008EventsAndProperties(bool Properties, bool Events = false) //  ملصق تاريخ ووقت إقفال الوردية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002008, "تاريخ ووقت إقفال الوردية", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002008, "تاريخ ووقت إقفال الوردية", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void dateTimePicker2EventsAndProperties(bool Properties = true, bool Events = false) // تاريخ ووقت إقفال الوردية
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.DateTimePicker_.CustumProperties(dateTimePicker2);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.DateTimePicker_.CustumProperties(dateTimePicker2, true, true);

                dateTimePicker2.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002003.Select(); };
                };
            }
        }

        private void checkBox8EventsAndProperties(bool Properties, bool Events = false) // مربع اختيار تاريخ ووقت إقفال الوردية
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox8, "");
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox8, "", ColorPropertyName.ForeColor_1, true, true);

                checkBox8.CheckedChanged += delegate
                {
                    dgv001EventsAndProperties(true);
                };

            }
        }


        private void lbl001002010EventsAndProperties(bool Properties, bool Events = false) //  ملصق رقم الموظف الذي قام بإقفال الوردية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002010, "الموظف الذي قام بإقفال الوردية", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002010, "الموظف الذي قام بإقفال الوردية", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }



        private void cbxRecevingAccountEventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة الموظف الذي قام بإستلام الوردية
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (TblEmployeesAndAccounts is null) { TblEmployeesAndAccounts = new DataTable(); fillTblEmployeesAndAccounts(); }
                    if (TblEmployeesAndAccounts.Columns.Count > 1)
                    {
                        if (cbxRecevingAccount.DataSource == null)
                        {
                            cbxRecevingAccount.DataSource = TblEmployeesAndAccounts;
                        }
                        cbxRecevingAccount.ValueMember = "UserAccountNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbxRecevingAccount.DisplayMember = "EmployeeNameAR";
                        }
                        else
                        {
                            cbxRecevingAccount.DisplayMember = "EmployeeNameEN";
                        }

                    }

                    ElementsTools.ComboBox_.CustumProperties(cbxRecevingAccount);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmShifts21 >> cbxRecevingAccountEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblEmployeesAndAccounts();


                    if (TblEmployeesAndAccounts is null) { TblEmployeesAndAccounts = new DataTable(); fillTblEmployeesAndAccounts(); }
                    if (TblEmployeesAndAccounts.Columns.Count > 1)
                    {
                        if (cbxRecevingAccount.DataSource == null)
                        {
                            cbxRecevingAccount.DataSource = TblEmployeesAndAccounts;
                        }
                        cbxRecevingAccount.ValueMember = "UserAccountNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbxRecevingAccount.DisplayMember = "EmployeeNameAR";
                        }
                        else
                        {
                            cbxRecevingAccount.DisplayMember = "EmployeeNameEN";
                        }

                    }

                    ElementsTools.ComboBox_.CustumProperties(cbxRecevingAccount);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmShifts21 >> cbxRecevingAccountEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


                cbxShiftsForClosing.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {

                    }
                };

            }
        }


        private void checkBox10EventsAndProperties(bool Properties, bool Events = false) // مربع اختيار رقم الحساب الذي قام بالاقفال
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox10, "");
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox10, "", ColorPropertyName.ForeColor_1, true, true);

                checkBox10.CheckedChanged += delegate
                {
                    dgv001EventsAndProperties(true);
                };

            }
        }

        private void lbl001002011EventsAndProperties(bool Properties, bool Events = false) //  ملصق الرصيد القيدي
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002011, "الرصيد القيدي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002011, "الرصيد القيدي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002007EventsAndProperties(bool Properties, bool Events = false) // مربع نص الرصيد القيدي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002007, "", 11);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002007, "", 11, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void checkBox11EventsAndProperties(bool Properties, bool Events = false) // مربع اختيار الرصيد القيدي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox11, "");
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox11, "", ColorPropertyName.ForeColor_1, true, true);

                checkBox11.CheckedChanged += delegate
                {
                    dgv001EventsAndProperties(true);
                };

            }
        }

        private void lbl001002012EventsAndProperties(bool Properties, bool Events = false) //  ملصق الرصيد الفعلي
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002012, "الرصيد الفعلي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002012, "الرصيد الفعلي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002008EventsAndProperties(bool Properties, bool Events = false) // مربع نص الرصيد الفعلي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002008, "", 11);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002008, "", 11, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void checkBox12EventsAndProperties(bool Properties, bool Events = false) // مربع اختيار الرصيد الفعلي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox12, "");
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox12, "", ColorPropertyName.ForeColor_1, true, true);

                checkBox12.CheckedChanged += delegate
                {
                    dgv001EventsAndProperties(true);
                };

            }
        }

        private void lbl00100213EventsAndProperties(bool Properties, bool Events = false) //  ملصق الفرق بين الرصيدين
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002013, "الفرق بين الرصيدين", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002013, "الفرق بين الرصيدين", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002009EventsAndProperties(bool Properties, bool Events = false) // مربع نص الفرق بين الرصيدين
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002009, "", 11);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002009, "", 11, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void checkBox13EventsAndProperties(bool Properties, bool Events = false) // مربع اختيار الفرق بين الرصيد القيدي والرصيد الفعلي
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox13, "");
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox13, "", ColorPropertyName.ForeColor_1, true, true);

                checkBox13.CheckedChanged += delegate
                {
                    dgv001EventsAndProperties(true);
                };

            }
        }

        //--------- ***** ----------


        private void btn001002001EventsAndProperties(bool Properties, bool Events = false) // جديد 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001002001, "جديد");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn001002001, "جديد", ColorPropertyName.ForeColor_1, true, true);

                btn001002001.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Shifts, PermissionType.Add))
                        {

                            if (btn001002001.Text == Cultures.ReturnTranslation("جديد"))
                            {

                                if(GeneralVariables.ActiveAccount.Columns[4].ColumnName == "EmployeeNo")
                                {

                                    if(txt001002001.Text.Trim()=="")
                                    {
                                        btn001002001.Text = Cultures.ReturnTranslation("إلغاء");

                                        txt001002001.Enabled = false;
                                        dateTimePicker1.Enabled = false;
                                        cbxShiftsForClosing.Enabled = true;
                                        txt001002003.Enabled = true;
                                        txt001002004.Enabled = false;
                                        txt001002005.Enabled = false;
                                        cbx001002001.Enabled = false;
                                        dateTimePicker2.Enabled = false;
                                        cbxRecevingAccount.Enabled = false;
                                        txt001002007.Enabled = false;
                                        txt001002008.Enabled = false;
                                        txt001002009.Enabled = false;


                                        txt001002001.Text = "";
                                        dateTimePicker1.Value = DateTime.Now;
                                        cbxShiftsForClosing.SelectedIndex = -1 ;
                                        txt001002003.Text = "";
                                        txt001002004.Text = GeneralVariables.ActiveAccount.Rows[0][0].ToString();
                                        txt001002005.Text = Mesrakh.Properties.Settings.Default["OperationUnitNumber"].ToString();
                                        cbx001002001.SelectedIndex = 0;
                                        dateTimePicker2.Value = Convert.ToDateTime("1999/1/1");
                                        cbxRecevingAccount.SelectedIndex = -1 ;
                                        txt001002007.Text = "";
                                        txt001002008.Text = "";
                                        txt001002009.Text = "";

                                        cbxShiftsForClosing.Focus();

                                        btn001002002.Enabled = true;
                                        btn001002002.Enabled = true;
                                        btn001002003.Enabled = false;
                                        btn001002004.Enabled = false;
                                    }
                                    else
                                    {
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لديك وردية نشطة يجب اغلاقها قبل فتح وردية جديدة"), MessageBoxStatus.Ok);

                                    }
                                }
                                else
                                {
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("يسمح للحسابات المحلية فقط بفتح وردية جديدة"), MessageBoxStatus.Ok);

                                }
                            }
                            else
                            {
                                btn001002001.Text = Cultures.ReturnTranslation("جديد");


                                txt001002001.Enabled = false;
                                dateTimePicker1.Enabled = false;
                                cbxShiftsForClosing.Enabled = false;
                                txt001002003.Enabled = false;
                                txt001002004.Enabled = false;
                                txt001002005.Enabled = false;
                                cbx001002001.Enabled = false;
                                dateTimePicker2.Enabled = false;
                                cbxRecevingAccount.Enabled = false;
                                txt001002007.Enabled = false;
                                txt001002008.Enabled = false;
                                txt001002009.Enabled = false;

                                btn001002002.Enabled = true;
                                btn001002002.Enabled = false;
                                btn001002003.Enabled = true;
                                btn001002004.Enabled = true;
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmShifts21 >> btn001002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmShifts21 >> btn001002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

            }

        }

        private void btn001002002EventsAndProperties(bool Properties, bool Events = false) // حفظ 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001002002, "حفظ");
            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn001002002, "حفظ", ColorPropertyName.ForeColor_1, true, true);

                btn001002002.Click += delegate
                {
                    try
                    {

                        if (btn001002001.Text==Cultures.ReturnTranslation("إلغاء"))
                        {

                            DateTime DateAndTimeOfShiftOpening = dateTimePicker1.Value; // تاريخ ووقت فتح الوردية
                            string ReceivedShiftNumber = cbxShiftsForClosing.SelectedIndex < 0 ? "Null" : cbxShiftsForClosing.SelectedValue.ToString() ; // رقم الشفت المستلم
                            string BalanceReceivedFromPreviousShift = txt001002003.Text.Trim() == "" ? " 0 " : txt001002003.Text.Trim(); // الرصيد المستلم من الوردية السابقة
                            string UserAccountNo = txt001002004.Text.Trim() == "" ? "Null" : txt001002004.Text.Trim(); // رقم المستخدم
                            string OperationUnitNumber = txt001002005.Text.Trim() == "" ? "Null" : txt001002005.Text.Trim(); // رقم وحدة العمليات

                            //{
                            //    if (TblOpenShiftsForThisAccount == null)
                            //    {
                            //        fillTblOpenShiftsForThisAccount();
                            //    }
                            //    else
                            //    {
                            //        if (TblOpenShiftsForThisAccount.Rows.Count < 1)
                            //        {
                            //            fillTblOpenShiftsForThisAccount();
                            //        }
                            //    }

                            //    if (TblOpenShiftsForThisAccount != null)
                            //    {
                            //        if (TblOpenShiftsForThisAccount.Rows.Count > 0)
                            //        {
                            //            OperationUnitNumber = TblOpenShiftsForThisAccount.Rows[0][5].ToString() == "" ? "Null" : TblOpenShiftsForThisAccount.Rows[0][5].ToString();
                            //        }
                            //    }
                            //}

                                if (string.IsNullOrEmpty(OperationUnitNumber))
                                {
                                    OperationUnitNumber = Mesrakh.Properties.Settings.Default["OperationUnitNumber"].ToString();
                                }


                            string ShiftStatus = cbx001002001.SelectedValue.ToString() ; // حالة الشفت
                            DateTime DateAndTimeOfShiftClosing = dateTimePicker2.Value; // تاريخ ووقت اقفال الشفت
                            string ClosingUserAccountNo = cbxRecevingAccount.SelectedIndex < 0 ? "Null" : cbxRecevingAccount.SelectedValue.ToString() ; // المستخدم الذي قام بإغلاق الشفت
                            string BalanceInRecords = BalanceReceivedFromPreviousShift ; // الرصيد القيدي
                            //string ActualBalance = txt001002008.Text.Trim() == "" ? " 0 " : txt001002008.Text.Trim();
                            string ActualBalance = " 0 "; // الرصيد الفعلي

                            // اضافة بيانات الشفت الجديد
                            string[] result00 = null;
                            DataTools.DataBases.Run(ref result00, @"insert into TblShifts (DateAndTimeOfShiftOpening     ,    ReceivedShiftNumber      ,    BalanceReceivedFromPreviousShift      ,     UserAccountNo      ,   OperationUnitNumber      ,    ShiftStatus       ,    DateAndTimeOfShiftClosing        ,   ClosingUserAccountNo      ,   BalanceInRecords      ,   ActualBalance) values " +
                                                                                  " ( '"+ DateAndTimeOfShiftOpening + "' , "+ ReceivedShiftNumber + "  , "+ BalanceReceivedFromPreviousShift + "  , "+ UserAccountNo + "  , "+ OperationUnitNumber + "  , "+ ShiftStatus + "  , '"+ DateAndTimeOfShiftClosing + "'  ,  "+ ClosingUserAccountNo + "  , "+ BalanceInRecords + "  , "+ ActualBalance + " )", CommandType.Text, new object[][] { });
                            // تحديث بيانات الشفت المستلم
                            if(!string.IsNullOrEmpty(ReceivedShiftNumber) && ReceivedShiftNumber != "Null")
                            {
                                string[] result01 = null;
                                DataTools.DataBases.Run(ref result01, "update TblShifts set ActualBalance = '" + BalanceReceivedFromPreviousShift + "' , ShiftStatus = 3 , ClosingUserAccountNo = " + UserAccountNo + " ,DateAndTimeOfShiftClosing = '" + DateTime.Now + "'  where ShiftNumber = " + ReceivedShiftNumber, CommandType.Text, new object[][] { });
                                //DataTools.DataBases.Run(ref result01, "update TblShifts set ActualBalance = '" + BalanceReceivedFromPreviousShift + "' , ShiftStatus = 3 , ClosingUserAccountNo = " + UserAccountNo + " ,DateAndTimeOfShiftClosing = '" + DateTime.Now + "'  where ShiftNumber = " + ReceivedShiftNumber, CommandType.Text, new object[][] { });

                                if (result01[1] == "succeeded")
                                {
                                    fillTblReceivedShifts(ReceivedShiftNumber); // تعبئة بيانات جدول الشفت الذي تم اغلاقه

                                    // قيود اليومية في حال وجود عجز او فائض
                                    // الفائض في حساب ايرادات فوائض والعجز في حساب ذمم الموظفين

                                    // اولا التأكد هل هناك عجز او فائض
                                    string DifferenceBetweenTwoBalances = ""; // الفرق بين الرصيدين
                                    if(TblReceivedShifts != null)
                                    {
                                        if(TblReceivedShifts.Rows.Count > 0 )
                                        {
                                            DifferenceBetweenTwoBalances = TblReceivedShifts.Rows[0][11].ToString().Trim();
                                        }
                                    }

                                    if(DifferenceBetweenTwoBalances != "" || DifferenceBetweenTwoBalances != "0" || DifferenceBetweenTwoBalances != "00" ) //  يوجد عجز او فائض
                                    {

                                        // رقم حساب ذمم الموظف صاحب الوردية التي تم اغلاقها
                                        string DebtsEmployeeAccount = EmployeeDebtsAccount(ReceivedShiftNumber); // يعيد رقم حساب ذمة الموظف بناء على رقم الوردية

                                        // رقم حساب صندوق وحدة العمليات المستلمة
                                        string CasherAccount = OperationUnitsAccount(ReceivedShiftNumber); // يعيد رقم حساب الكاشير بناء على رقم الوردية 


                                        // رقم حساب ايرادات فوائض نقدية
                                        string CashSurplusAccount = CashSurplus();

                                        object journalEntryNo = ""; // رقم قيد اليومية

                                        if (Convert.ToDecimal(DifferenceBetweenTwoBalances) < 0) //-------------- عجز
                                        {
                                            DifferenceBetweenTwoBalances = (Convert.ToDecimal(DifferenceBetweenTwoBalances) * -1).ToString() ;
                                            {
                                                // ايجاد الحسابات المحاسبية وايجاد قيمها
                                                List<JournalEntry> accounts = new List<JournalEntry>();
                                                {
                                                    // قيد عجز على ذمم الموظف
                                                    {

                                                        JournalEntry j = new JournalEntry();
                                                        j.AccountNo = DebtsEmployeeAccount; // رقم الحساب المحاسبي لذمم الموظف
                                                        j.DebitValue = DifferenceBetweenTwoBalances ; // مدين
                                                        j.CreditValue = "0"; // دائن
                                                        j.AccountingEntrytStatement = "ShiftNumber: " + ReceivedShiftNumber;

                                                        accounts.Add(j);
                                                    }

                                                    // قيد خصم من صندوق الكاشير 
                                                    {

                                                        JournalEntry j = new JournalEntry();
                                                        j.AccountNo = CasherAccount; // رقم الحساب المحاسبي لصندوق الكاشير الذي كانت الوردية تعمل عليه
                                                        j.DebitValue = "0"; // مدين
                                                        j.CreditValue = DifferenceBetweenTwoBalances; // دائن
                                                        j.AccountingEntrytStatement = "ShiftNumber: " + ReceivedShiftNumber;

                                                        accounts.Add(j);
                                                    }

                                                    
                                                }

                                                //--- تنفيذ قيد اليومية الرئيسي
                                                string[] result000 = null;
                                                journalEntryNo = DataTools.DataBases.Run(ref result000, "psJournalEntry", CommandType.StoredProcedure, new object[][] {
                                                new object[] { "@EntryDateTime", DateTime.Now }
                                                , new object[] { "@AccountingEntrytStatement", "عجز الوردية رقم" + ReceivedShiftNumber }
                                                ,  new object[] { "@JournalEntryNo", "OUT" }
                                                });

                                                //---- تنفيذ قيود اليومية الفرعية
                                                foreach (JournalEntry _JournalEntry in accounts)
                                                {
                                                    string[] result11 = null;
                                                    DataTools.DataBases.Run(ref result11, "insert into TblSubJournalEntry values (@JournalEntryNo , @AccountNo , @DebitValue , @CreditValue , @AccountingEntrytStatement)", CommandType.Text, new object[][]
                                                   { new object[] { "@JournalEntryNo", journalEntryNo },
                                                new object[] { "@AccountNo", _JournalEntry.AccountNo } ,
                                                new object[] { "@DebitValue", _JournalEntry.DebitValue } ,
                                                new object[] { "@CreditValue", _JournalEntry.CreditValue } ,
                                                new object[] { "@AccountingEntrytStatement", _JournalEntry.AccountingEntrytStatement }
                                                    });
                                                }
                                            }
                                        }
                                        else if (Convert.ToDecimal(DifferenceBetweenTwoBalances) > 0) // فائض
                                        {
                                            {
                                                // ايجاد الحسابات المحاسبية وايجاد قيمها
                                                List<JournalEntry> accounts = new List<JournalEntry>();
                                                {


                                                    // قيد اضافة الفائض الى صندوق الكاشير 
                                                    {

                                                        JournalEntry j = new JournalEntry();
                                                        j.AccountNo = CasherAccount; // رقم الحساب المحاسبي لصندوق الكاشير الذي كانت الوردية تعمل عليه
                                                        j.DebitValue = DifferenceBetweenTwoBalances ; // مدين
                                                        j.CreditValue = "0"; // دائن
                                                        j.AccountingEntrytStatement = "ShiftNumber: " + ReceivedShiftNumber;

                                                        accounts.Add(j);
                                                    }

                                                    // قيد اضافة الفائض الى الايرادات المتنوعة / ايراد فوائض
                                                    {

                                                        JournalEntry j = new JournalEntry();
                                                        j.AccountNo = CashSurplusAccount; // رقم الحساب المحاسبي لحساب الايرادات المتنوعة ايردات فوائض
                                                        j.DebitValue = "0"; // مدين
                                                        j.CreditValue = DifferenceBetweenTwoBalances; // دائن
                                                        j.AccountingEntrytStatement = "ShiftNumber: " + ReceivedShiftNumber;

                                                        accounts.Add(j);
                                                    }
                                                }

                                                //--- تنفيذ قيد اليومية الرئيسي
                                                string[] result000 = null;
                                                journalEntryNo = DataTools.DataBases.Run(ref result000, "psJournalEntry", CommandType.StoredProcedure, new object[][] {
                                                new object[] { "@EntryDateTime", DateTime.Now }
                                                , new object[] { "@AccountingEntrytStatement", "فائض الوردية رقم" + ReceivedShiftNumber }
                                                ,  new object[] { "@JournalEntryNo", "OUT" }
                                                });

                                                //---- تنفيذ قيود اليومية الفرعية
                                                foreach (JournalEntry _JournalEntry in accounts)
                                                {
                                                    string[] result11 = null;
                                                    DataTools.DataBases.Run(ref result11, "insert into TblSubJournalEntry values (@JournalEntryNo , @AccountNo , @DebitValue , @CreditValue , @AccountingEntrytStatement)", CommandType.Text, new object[][]
                                                   { new object[] { "@JournalEntryNo", journalEntryNo },
                                                new object[] { "@AccountNo", _JournalEntry.AccountNo } ,
                                                new object[] { "@DebitValue", _JournalEntry.DebitValue } ,
                                                new object[] { "@CreditValue", _JournalEntry.CreditValue } ,
                                                new object[] { "@AccountingEntrytStatement", _JournalEntry.AccountingEntrytStatement }
                                                    });
                                                }
                                            }
                                        }



                                    }

                                }
                                    
                            }

                            if (result00[1] == "succeeded")
                            {
                                TblShiftsOpenOnThisDevice();
                                //--------------------------------------------------
                                btn001002001.Text = Cultures.ReturnTranslation("جديد");

                                txt001002001.Enabled = false;
                                dateTimePicker1.Enabled = false;
                                cbxShiftsForClosing.Enabled = false;
                                txt001002003.Enabled = false;
                                txt001002004.Enabled = false;
                                txt001002005.Enabled = false;
                                cbx001002001.Enabled = false;
                                dateTimePicker2.Enabled = false;
                                cbxRecevingAccount.Enabled = false;
                                txt001002007.Enabled = false;
                                txt001002008.Enabled = false;
                                txt001002009.Enabled = false;

                                btn001002002.Enabled = true;
                                btn001002002.Enabled = false;
                                btn001002003.Enabled = true;
                                btn001002004.Enabled = true;

                                // تحديث بيانات جدول البيانات
                                
                                fillTblOpenShiftsForThisAccount(); // تعبئة جدول الوردية المفتوحة لهذا الحساب
                                AllEventsAndProperties(true); // تم تحديث جميع الخصائص لتعود الازرار لوضعها الطبيعي

                            }

                        }


                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmEmployees18 >> btn001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };



            }


        }


        private void btn001002003EventsAndProperties(bool Properties, bool Events = false) // تعديل الحالة 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001002003, "تعديل الحالة");

            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn001002003, "تعديل الحالة", ColorPropertyName.ForeColor_1, true, true);
                btn001002003.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Shifts, PermissionType.Edit))
                    {
                        string shiftStatus = "";
                        if (cbx001002001.SelectedValue.ToString() == "1")
                        {
                            shiftStatus = "2";
                        }
                        else if(cbx001002001.SelectedValue.ToString() == "2")
                        {
                            shiftStatus = "1";
                        }

                        string[] result00 = null;
                        DataTools.DataBases.Run(ref result00, "update TblShifts set ShiftStatus = " + shiftStatus + " where ShiftNumber = @ShiftNumber", CommandType.Text, new object[][] {
                                    new object[] { "@ShiftStatus", cbx001002001.SelectedValue },
                                    new object[] { "@ShiftNumber", txt001002001.Text }

                            });

                        if (result00[1] == "succeeded")
                        {

                            if(shiftStatus == "1")
                            {
                                cbx001002001.SelectedIndex = 0;
                            }
                            else if (shiftStatus == "2")
                            {
                                cbx001002001.SelectedIndex = 1;

                            }

                            txt001002001.Enabled = false;
                            dateTimePicker1.Enabled = false;
                            cbxShiftsForClosing.Enabled = false;
                            txt001002003.Enabled = false;
                            txt001002004.Enabled = false;
                            txt001002005.Enabled = false;
                            cbx001002001.Enabled = false;
                            dateTimePicker2.Enabled = false;
                            cbxRecevingAccount.Enabled = false;
                            txt001002007.Enabled = false;
                            txt001002008.Enabled = false;
                            txt001002009.Enabled = false;

                            btn001002002.Enabled = true;
                            btn001002002.Enabled = false;
                            btn001002003.Enabled = true;
                            btn001002004.Enabled = true;

                        }
                    }
                };


            }
        }


private void dgv001EventsAndProperties(bool Properties, bool Events = false) // جدول عرض الورديات المغلقة لهذا الحساب 
        {
            if (Properties == true && Events == false)
            {
                try
                {


                    if (TblClosingShiftsForThisAccount.Rows.Count > 0)
                    {

                            if (TblClosingShiftsForThisAccount.Rows.Count > 0)
                            {
                                dgv001.DataSource = TblClosingShiftsForThisAccount;
                            }

                        

                        dgv001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الوردية");
                        dgv001.Columns[1].HeaderText = Cultures.ReturnTranslation("تاريخ ووقت فتح الوردية");
                        dgv001.Columns[2].HeaderText = Cultures.ReturnTranslation("رقم الوردية المستلمة");
                        dgv001.Columns[3].HeaderText = Cultures.ReturnTranslation("الرصيد المستلم من الوردية السابقة");
                        dgv001.Columns[4].HeaderText = Cultures.ReturnTranslation("رقم المستخدم");
                        dgv001.Columns[5].HeaderText = Cultures.ReturnTranslation("رقم وحدة العمليات");
                        dgv001.Columns[6].HeaderText = Cultures.ReturnTranslation("حالة الوردية");
                        dgv001.Columns[7].HeaderText = Cultures.ReturnTranslation("تاريخ ووقت إقفال الوردية");
                        dgv001.Columns[8].HeaderText = Cultures.ReturnTranslation("رقم الحساب الذي قام بالاقفال");
                        dgv001.Columns[9].HeaderText = Cultures.ReturnTranslation("الرصيد القيدي");
                        dgv001.Columns[10].HeaderText = Cultures.ReturnTranslation("الرصيد الفعلي");
                        dgv001.Columns[11].HeaderText = Cultures.ReturnTranslation("الفرق بين الرصيدين");

                        dgv001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                        dgv001.Columns[0].Visible = checkBox1.Checked;
                        dgv001.Columns[1].Visible = checkBox2.Checked;
                        dgv001.Columns[2].Visible = checkBox3.Checked;
                        dgv001.Columns[3].Visible = checkBox4.Checked;
                        dgv001.Columns[4].Visible = checkBox5.Checked;
                        dgv001.Columns[5].Visible = checkBox6.Checked;
                        dgv001.Columns[6].Visible = checkBox7.Checked;
                        dgv001.Columns[7].Visible = checkBox8.Checked;
                        dgv001.Columns[8].Visible = checkBox10.Checked;
                        dgv001.Columns[9].Visible = checkBox11.Checked;
                        dgv001.Columns[10].Visible = checkBox12.Checked;
                        dgv001.Columns[11].Visible = checkBox13.Checked;

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
                    GeneralAction.AddNewNotification("frmEmployees18 >> dgv001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                }
            }
            else if (Properties == true && Events == true)
            {
                try
                {

                    fillTblClosingShiftsForThisAccount();

                    if (TblClosingShiftsForThisAccount.Rows.Count > 0)
                    {

                            if (TblClosingShiftsForThisAccount.Rows.Count > 0)
                            {
                                dgv001.DataSource = TblClosingShiftsForThisAccount;
                            }

                        dgv001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الوردية");
                        dgv001.Columns[1].HeaderText = Cultures.ReturnTranslation("تاريخ ووقت فتح الوردية");
                        dgv001.Columns[2].HeaderText = Cultures.ReturnTranslation("رقم الوردية المستلمة");
                        dgv001.Columns[3].HeaderText = Cultures.ReturnTranslation("الرصيد المستلم من الوردية السابقة");
                        dgv001.Columns[4].HeaderText = Cultures.ReturnTranslation("رقم المستخدم");
                        dgv001.Columns[5].HeaderText = Cultures.ReturnTranslation("رقم وحدة العمليات");
                        dgv001.Columns[6].HeaderText = Cultures.ReturnTranslation("حالة الوردية");
                        dgv001.Columns[7].HeaderText = Cultures.ReturnTranslation("تاريخ ووقت إقفال الوردية");
                        dgv001.Columns[8].HeaderText = Cultures.ReturnTranslation("رقم الحساب الذي قام بالاقفال");
                        dgv001.Columns[9].HeaderText = Cultures.ReturnTranslation("الرصيد القيدي");
                        dgv001.Columns[10].HeaderText = Cultures.ReturnTranslation("الرصيد الفعلي");
                        dgv001.Columns[11].HeaderText = Cultures.ReturnTranslation("الفرق بين الرصيدين");

                        dgv001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgv001.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                        dgv001.Columns[0].Visible = checkBox1.Checked;
                        dgv001.Columns[1].Visible = checkBox2.Checked;
                        dgv001.Columns[2].Visible = checkBox3.Checked;
                        dgv001.Columns[3].Visible = checkBox4.Checked;
                        dgv001.Columns[4].Visible = checkBox5.Checked;
                        dgv001.Columns[5].Visible = checkBox6.Checked;
                        dgv001.Columns[6].Visible = checkBox7.Checked;
                        dgv001.Columns[7].Visible = checkBox8.Checked;
                        dgv001.Columns[8].Visible = checkBox10.Checked;
                        dgv001.Columns[9].Visible = checkBox11.Checked;
                        dgv001.Columns[10].Visible = checkBox12.Checked;
                        dgv001.Columns[11].Visible = checkBox13.Checked;


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
                    GeneralAction.AddNewNotification("frmEmployees18 >> dgv001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                }


                //dgv001.SelectionChanged += delegate
                //{
                //    try
                //    {
                //        if (dgv001.Rows.Count > 0)
                //        {

                //            if (dgv001.SelectedRows.Count == 0 || dgv001.SelectedRows == null) return;

                //            txt001002001.Text = dgv001.SelectedRows[0].Cells[0].Value.ToString();
                //            txt001002002.Text = dgv001.SelectedRows[0].Cells[1].Value.ToString();
                //            txt001002003.Text = dgv001.SelectedRows[0].Cells[2].Value.ToString();
                //            cbx001002001.SelectedValue = dgv001.SelectedRows[0].Cells[3].Value;
                //            cbx001002002.SelectedValue = dgv001.SelectedRows[0].Cells[4].Value;

                //            SelectedRowIndex = dgv001.SelectedRows[0].Index;

                //            txtConnectionNo.Text = "";
                //            txtOtherDetails.Text = "";
                //            cbxConnectionMethodsTypes.SelectedIndex = -1;

                //            fillTblMethodsOfCommunication(); // تعبئة جدول طرق الاتصال حسب السجل الجديد
                //            dgvAllConnectionsNumbersEventsAndProperties(true); // خصائص جدول عرض بيانات طرق الاتصال

                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                //        GeneralAction.AddNewNotification("frmEmployees18 >> dgv001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);

                //    }
                //};

                dgv001.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات

                };
            }
        }



        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- البحث
        private void lblSearchEventsAndProperties(bool Properties, bool Events = false) // ملصق البحث عن الورديات بالتاريخ 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblSearch, "تاريخ ووفت فتح الوردية", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblSearch, "تاريخ ووفت فتح الوردية", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txtSearchEventsAndProperties(bool Properties, bool Events = false) // مربع نص البحث عن الشركات
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txtSearch, "", 50);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtSearch, "", 50, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txtSearch.TextChanged += delegate
                {
                    try
                    {
                        DataView dv = new DataView(TblOpenShifts);
                        string filter = "";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            filter = "DateAndTimeOfShiftOpening like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        else
                        {
                            filter = "DateAndTimeOfShiftOpening like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        }
                        dv.RowFilter = filter;
                        dgv001.DataSource = dv;
                        ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmShifts21 >> txtSearchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }


        //------------------------------ 
        DataTable TblOpenShifts = new DataTable(); // الورديات المفتوحة لجميع الحسابات
        DataTable TblClosingShifts = new DataTable(); // الورديات المفتوحة لجميع الحسابات
        DataTable TblOpenShiftsForThisAccount = new DataTable(); // الورديات المفتوحة لهذا الحساب 
        DataTable TblClosingShiftsForThisAccount = new DataTable(); // الورديات المغلقة لهذا الحساب 
        //DataTable TblOpenShiftsForThisOperationUnit = new DataTable(); // الوردية المفتوحة على وحدة العمليات الحالية 
        DataTable TblShiftsForClosing = new DataTable(); // ورديات للإغلاق 
        DataTable TblEmployeesAndAccounts = new DataTable(); // الموظفين وحساباتهم 
        DataTable TblOperationUnits = new DataTable(); // بيانات الفرع ووحدة العمليات الحالية 
        DataTable TblReceivedShifts = new DataTable(); // جدول الشفت المستلم





        private void fillTblOpenShifts() // تعبئة جدول الورديات المفتوحة لجميع الحسابات
        {
            try
            {
                if (TblOpenShifts is null)
                {
                    TblOpenShifts = new DataTable();
                }
                if (TblOpenShifts.Rows.Count > 0)
                {
                    TblOpenShifts.Rows.Clear();
                }

                if (TblOpenShifts.Rows.Count > 0) TblOpenShifts.Rows.Clear();

                TblOpenShifts = DataTools.DataBases.ReadTabel("select * from TblShifts where  ShiftStatus in (1 , 2) ");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmShifts21 >> TblOpenShifts ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        private void fillTblClosingShifts() // تعبئة جدول الورديات المغلقة لجميع الحسابات
        {
            try
            {
                if (TblClosingShifts is null)
                {
                    TblClosingShifts = new DataTable();
                }
                if (TblClosingShifts.Rows.Count > 0)
                {
                    TblClosingShifts.Rows.Clear();
                }

                if (TblClosingShifts.Rows.Count > 0) TblClosingShifts.Rows.Clear();

                TblClosingShifts = DataTools.DataBases.ReadTabel("select * from TblShifts where  ShiftStatus = 3  ");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmShifts21 >> fillTblClosingShifts ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        private void  fillTblOpenShiftsForThisAccount() // تعبئة جدول الورديات المفتوحة لهذا الحساب
        {
            try
            {
                if (TblOpenShiftsForThisAccount is null)
                {
                    TblOpenShiftsForThisAccount = new DataTable();
                }

                if (TblOpenShiftsForThisAccount.Rows.Count > 0)
                {
                    TblOpenShiftsForThisAccount.Rows.Clear();
                }


                TblOpenShiftsForThisAccount = DataTools.DataBases.ReadTabel("select * from TblShifts where  ShiftStatus in (1 , 2)  And UserAccountNo = " + GeneralVariables.ActiveAccount.Rows[0][0].ToString());

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmShifts21 >> fillTblOpenShiftsForThisAccount ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        private void fillTblClosingShiftsForThisAccount() // تعبئة جدول الورديات المغلقة لهذا الحساب
        {
            try
            {
                if (TblClosingShiftsForThisAccount is null)
                {
                    TblClosingShiftsForThisAccount = new DataTable();
                }
                if (TblClosingShiftsForThisAccount.Rows.Count > 0)
                {
                    TblClosingShiftsForThisAccount.Rows.Clear();
                }

                if (TblClosingShiftsForThisAccount.Rows.Count > 0) TblClosingShiftsForThisAccount.Rows.Clear();

                TblClosingShiftsForThisAccount = DataTools.DataBases.ReadTabel("select * from TblShifts where  DateAndTimeOfShiftClosing > '2000/1/1'  And UserAccountNo = " + GeneralVariables.ActiveAccount.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmShifts21 >> fillTblClosingShiftsForThisAccount ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        private void fillTblShiftsForClosing() // تعبئة جدول ورديات للإغلاق
        {
            try
            {

                if (TblShiftsForClosing is null)
                {
                    TblShiftsForClosing = new DataTable();
                }
                if (TblShiftsForClosing.Rows.Count > 0)
                {
                    TblShiftsForClosing.Rows.Clear();
                }

                TblShiftsForClosing = DataTools.DataBases.ReadTabel(@"select * from TblShifts 
                                                                         inner join TblUsersAccounts on TblShifts.UserAccountNo = TblUsersAccounts.UserAccountNo 
                                                                         inner join TblEmployees on TblEmployees.EmployeeNo = TblUsersAccounts.EmployeeNo
                                                                         where TblShifts.ShiftStatus = 2");
                

                if (TblShiftsForClosing is null) { TblShiftsForClosing = new DataTable(); }
                if (TblShiftsForClosing.Columns.Count > 0)
                {
                    
                    cbxShiftsForClosing.DataSource = null;
                    cbxShiftsForClosing.DataSource = TblShiftsForClosing;
                   

                    cbxShiftsForClosing.ValueMember = "ShiftNumber";
                    if (GeneralVariables.cultureCode == "AR")
                    {
                        cbxShiftsForClosing.DisplayMember = "EmployeeNameAR";
                    }
                    else
                    {
                        cbxShiftsForClosing.DisplayMember = "EmployeeNameEN";
                    }

                }


            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmShifts21 >> fillTblShiftsForClosing ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        private void fillTblEmployeesAndAccounts() // تعبئة جدول الموظفين وحساباتهم
        {
            try
            {
                if (TblEmployeesAndAccounts is null)
                {
                    TblEmployeesAndAccounts = new DataTable();
                }
                if (TblEmployeesAndAccounts.Rows.Count > 0)
                {
                    TblEmployeesAndAccounts.Rows.Clear();
                }

                if (TblEmployeesAndAccounts.Rows.Count > 0) TblEmployeesAndAccounts.Rows.Clear();

                TblEmployeesAndAccounts = DataTools.DataBases.ReadTabel("select * from TblUsersAccounts inner join TblEmployees on TblEmployees.EmployeeNo = TblUsersAccounts.EmployeeNo");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmShifts21 >> fillTblEmployeesAndAccounts ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        //---------------------------------------------------

        private void TblShiftsOpenOnThisDevice() //  الورديات المفتوحة على هذا الجهاز
        {
            try
            {

                if ( GeneralVariables.TblShiftsOpenOnThisDevice is null)
                {
                    GeneralVariables.TblShiftsOpenOnThisDevice = new DataTable();
                }
                if (GeneralVariables.TblShiftsOpenOnThisDevice.Rows.Count > 0)
                {
                    GeneralVariables.TblShiftsOpenOnThisDevice.Rows.Clear();
                }

                //GeneralVariables.TblShiftsOpenOnThisDevice = DataTools.DataBases.ReadTabel(@"select * from TblShifts inner join TblOperationUnits on TblShifts.OperationUnitNumber = TblOperationUnits.OperationUnitNumber where DeviceNumber = '"+ SecurityTools.specialDevices.getCPUID() + "' and ShiftStatus  in (1,2) ");
                GeneralVariables.TblShiftsOpenOnThisDevice = DataTools.DataBases.ReadTabel(@"select * from TblShifts where OperationUnitNumber = '" + Properties.Settings.Default["OperationUnitNumber"].ToString() + "' and ShiftStatus  in (1,2) ");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmShifts21 >> CheckOpenShiftsOnThisDevice ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        
        //private bool OpenShiftsForThisUserAccountOnOtherDevices() // هل لهذا الحساب ورديات مفتوحة على اجهزة اخرى
        //{
        //    DataTable TblOpenShiftsForThisUserAccountOnOtherDevices = new DataTable(); // الورديات المفتوحة لهذا الحساب على اجهزة اخرى 

        //    try
        //    {
        //        bool result = false;
        //        if (TblOpenShiftsForThisUserAccountOnOtherDevices is null)
        //        {
        //            TblOpenShiftsForThisUserAccountOnOtherDevices = new DataTable();
        //        }
        //        if (TblOpenShiftsForThisUserAccountOnOtherDevices.Rows.Count > 0)
        //        {
        //            TblOpenShiftsForThisUserAccountOnOtherDevices.Rows.Clear();
        //        }

        //        if (TblOpenShiftsForThisUserAccountOnOtherDevices.Rows.Count > 0) TblOpenShiftsForThisUserAccountOnOtherDevices.Rows.Clear();

        //        TblOpenShiftsForThisUserAccountOnOtherDevices = DataTools.DataBases.ReadTabel(@"select * from TblShifts inner join TblOperationUnits on TblShifts.OperationUnitNumber = TblOperationUnits.OperationUnitNumber where DeviceNumber != '" + SecurityTools.specialDevices.getCPUID() + "' and ShiftStatus in ( 1 , 2 ) ");

        //        if (TblOpenShiftsForThisUserAccountOnOtherDevices != null)
        //        {
        //            if (TblOpenShiftsForThisUserAccountOnOtherDevices.Rows.Count > 0)
        //            {
        //                result = true;
        //            }

        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralAction.AddNewNotification("frmShifts21 >> CheckOpenShiftsOnThisDevice ", DateTime.Now, ex.Message, ex.Message);
        //        return true;
        //    }
        //}
        ////------------------------------------------------------

        // بيانات الفرع ووحدة العمليات الحالية
        private void fillTblOperationUnits() // بيانات الفرع ووحدة العمليات الحالية
        {
            try
            {

                if (TblOperationUnits is null)
                {
                    TblOperationUnits = new DataTable();
                }
                if (TblOperationUnits.Rows.Count > 0)
                {
                    TblOperationUnits.Rows.Clear();
                }
                TblOperationUnits = DataTools.DataBases.ReadTabel(@"select * from TblOperationUnits  where DeviceNumber = '" + SecurityTools.specialDevices.getCPUID() + "' ");
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmShifts21 >> CheckOpenShiftsOnThisDevice ", DateTime.Now, ex.Message, ex.Message);
            }
        }



        // تعبئة جميع العناصر ببيانات الشفت
        private void fillDataForAllElements(DataTable tblShift) // تعبئة جميع العناصر ببيانات الشفت
        {
            if (tblShift.Rows.Count > 0)
            {
                txt001002001.Text = tblShift.Rows[0][0].ToString();//-- رقم الوردية
                dateTimePicker1.Value = Convert.ToDateTime(tblShift.Rows[0][1].ToString());//-- تاريخ ووقت فتح الوردية
                cbxShiftsForClosing.SelectedValue = tblShift.Rows[0][2].ToString();//-- رقم الوردية المستلمة
                txt001002003.Text = tblShift.Rows[0][3].ToString();//-- الرصيد المستلم من الوردية السابقة
                txt001002004.Text = tblShift.Rows[0][4].ToString();//-- رقم المستخدم
                txt001002005.Text = tblShift.Rows[0][5].ToString();//-- رقم وحدة العمليات
                cbx001002001.SelectedValue = tblShift.Rows[0][6];//-- حالة الوردية
                dateTimePicker2.Value = Convert.ToDateTime(tblShift.Rows[0][7].ToString());//-- تاريخ ووقت إقفال الوردية
                cbxRecevingAccount.SelectedValue = tblShift.Rows[0][8].ToString() == "" ? -1 : tblShift.Rows[0][8];//-- رقم الحساب الذي قام بالاقفال
                txt001002007.Text = tblShift.Rows[0][9].ToString();//--الرصيد القيدي
                txt001002008.Text = tblShift.Rows[0][10].ToString();//--الرصيد الفعلي
                txt001002009.Text = tblShift.Rows[0][11].ToString();//--الفرق بين الرصيدين

            }
        }

        // تعبئة جدول الشفت الذي تم اغلاقه وذلك لاعداد قيود اليومية
        private void fillTblReceivedShifts(string ShiftNumber) // تعبئة جدول بيانات الوردية التي تم اغلاقها
        {
            try
            {
                if (TblReceivedShifts is null)
                {
                    TblReceivedShifts = new DataTable();
                }
                if (TblReceivedShifts.Rows.Count > 0)
                {
                    TblReceivedShifts.Rows.Clear();
                }

                TblReceivedShifts = DataTools.DataBases.ReadTabel("select * from TblShifts where  ShiftNumber = " + ShiftNumber);

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmShifts21 >> fillTblReceivedShifts ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        // رقم حساب ذمم الموظف صاحب الوردية التي تم اغلاقها
        private string EmployeeDebtsAccount(string ShiftNumber) // يعيد رقم حساب ذمم الموظف بناء على رقم الوردية  
        {
           
            try
            {
                if(ShiftNumber.Trim() != "")
                {
                    DataTable dt = new DataTable();
                    dt = DataTools.DataBases.ReadTabel(@"select TblEmployees.AccountNo from TblShifts
                                                 inner join TblUsersAccounts on TblUsersAccounts.UserAccountNo = TblShifts.UserAccountNo
                                                 inner join TblEmployees on TblEmployees.EmployeeNo = TblUsersAccounts.EmployeeNo
                                                 where ShiftNumber = " + ShiftNumber);

                    return dt.Rows[0][0].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                return "";
            }

        }

        // رقم حساب صندوق وحدة العمليات المستلمة
        private string OperationUnitsAccount(string ShiftNumber) // يعيد رقم حساب الكاشير بناء على رقم الوردية  
        {
            


            try
            {
                if (ShiftNumber.Trim() != "")
                {
                    DataTable dt = new DataTable();
                    dt = DataTools.DataBases.ReadTabel(@"select TblOperationUnits.AccountNo from TblShifts
                                                 inner join TblOperationUnits on TblOperationUnits.OperationUnitNumber = TblShifts.OperationUnitNumber
                                                 where ShiftNumber = " + ShiftNumber);
                  
                    return dt.Rows[0][0].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                return "";
            }

        }


        // رقم حساب ايرادات فوائض نقدية
        private string CashSurplus()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DataTools.DataBases.ReadTabel(@"select AccountNo from TblStandardAccounts where StandardAccountNo = 13 ");

                return dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                return "";
            }
        }
    }
}

