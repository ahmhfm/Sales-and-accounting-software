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
            txt001002002EventsAndProperties(Properties, Events); // مربع نص رقم الوردية المستلمة
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
            lbl001002009EventsAndProperties(Properties, Events); //  ملصق نوع الإقفال
            cbx001002002EventsAndProperties(Properties, Events); // قائمة منسدلة نوع الإقفال
            lbl001002010EventsAndProperties(Properties, Events); //  ملصق رقم الحساب الذي قام بالاقفال
            txt001002006EventsAndProperties(Properties, Events); // رقم الحساب الذي قام بالاقفال
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
            checkBox9EventsAndProperties(Properties, Events);
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
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
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
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
                };
            }
        }

        private void lbl001002003EventsAndProperties(bool Properties, bool Events = false) //  ملصق رقم الوردية المستلمة
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002003, "رقم الوردية المستلمة", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002003, "رقم الوردية المستلمة", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002002EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم الوردية المستلمة
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002002, "", 10);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002002, "", 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
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
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
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
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
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
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
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
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
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

                    }
                    else
                    {
                        if (dt.Rows.Count < 1)
                        {
                            dt.Rows.Add("1", "نشط", "active");
                            dt.Rows.Add("2", "للإغلاق", "to close");
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

                    }
                    else
                    {
                        if (dt.Rows.Count < 1)
                        {
                            dt.Rows.Add("1", "نشط", "active");
                            dt.Rows.Add("2", "للإغلاق", "to close");
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
                        cbx001002002.Select();
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
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
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
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
                };

            }
        }

        private void lbl001002009EventsAndProperties(bool Properties, bool Events = false) //  ملصق نوع الإقفال
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002009, "نوع الإقفال", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002009, "نوع الإقفال", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void cbx001002002EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة نوع الإقفال
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
                        dt.Rows.Add("1", "إقفال نهائي", "final closing");
                        dt.Rows.Add("2", "إقفال مرحلي", "phase closure");

                    }
                    else
                    {
                        if (dt.Rows.Count < 1)
                        {
                            dt.Rows.Add("1", "إقفال نهائي", "final closing");
                            dt.Rows.Add("2", "إقفال مرحلي", "phase closure");
                        }
                    }

                    cbx001002002.DataSource = dt;
                    cbx001002002.ValueMember = "no";
                    if (GeneralVariables.cultureCode == "AR")
                    {
                        cbx001002002.DisplayMember = "ar";
                    }
                    else
                    {
                        cbx001002002.DisplayMember = "en";
                    }

                    ElementsTools.ComboBox_.CustumProperties(cbx001002002);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmShifts21 >> cbx001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                        dt.Rows.Add("1", "إقفال نهائي", "final closing");
                        dt.Rows.Add("2", "إقفال مرحلي", "phase closure");

                    }
                    else
                    {
                        if (dt.Rows.Count < 1)
                        {
                            dt.Rows.Add("1", "إقفال نهائي", "final closing");
                            dt.Rows.Add("2", "إقفال مرحلي", "phase closure");
                        }
                    }

                    cbx001002002.DataSource = dt;
                    cbx001002002.ValueMember = "no";
                    if (GeneralVariables.cultureCode == "AR")
                    {
                        cbx001002002.DisplayMember = "ar";
                    }
                    else
                    {
                        cbx001002002.DisplayMember = "en";
                    }

                    ElementsTools.ComboBox_.CustumProperties(cbx001002002, "", true, true);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmShifts21 >> cbx001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                cbx001002002.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        cbx001002002.Select();
                    }
                };

            }
        }

        private void checkBox9EventsAndProperties(bool Properties, bool Events = false) // مربع اختيار نوع الاقفال
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox9, "");
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.CheckBox_.CustumProperties(checkBox9, "", ColorPropertyName.ForeColor_1, true, true);

                checkBox9.CheckedChanged += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
                };

            }
        }

        private void lbl001002010EventsAndProperties(bool Properties, bool Events = false) //  ملصق رقم الحساب الذي قام بالاقفال
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002010, "رقم الحساب الذي قام بالاقفال", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002010, "رقم الحساب الذي قام بالاقفال", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002006EventsAndProperties(bool Properties, bool Events = false) // رقم الحساب الذي قام بالاقفال
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002006, "", 10);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002006, "", 10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
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
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
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
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
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
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
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
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
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
                                btn001002001.Text = Cultures.ReturnTranslation("إلغاء");

                                txt001002001.Enabled = false;
                                dateTimePicker1.Enabled = false;
                                txt001002002.Enabled = true;
                                txt001002003.Enabled = true;
                                txt001002004.Enabled = false;
                                txt001002005.Enabled = false;
                                cbx001002001.Enabled = false;
                                dateTimePicker2.Enabled = false;
                                cbx001002002.Enabled = false;
                                txt001002006.Enabled = false;
                                txt001002007.Enabled = false;
                                txt001002008.Enabled = false;
                                txt001002009.Enabled = false;


                                txt001002001.Text = "" ;
                                dateTimePicker1.Value = DateTime.Now;
                                txt001002002.Text = "";
                                txt001002003.Text = "";
                                txt001002004.Text = GeneralVariables.ActiveAccount.Rows[0][0].ToString();
                                txt001002005.Text = GeneralVariables.ActiveAccount.Rows[0][4].ToString();
                                cbx001002001.SelectedIndex = 0;
                                dateTimePicker2.Value = Convert.ToDateTime("1900/1/1");
                                cbx001002002.SelectedIndex = -1;
                                txt001002006.Text = "";
                                txt001002007.Text = "";
                                txt001002008.Text = "";
                                txt001002009.Text = "";

                                txt001002002.Focus();

                                btn001002002.Enabled = true;
                                btn001002002.Enabled = true;
                                btn001002003.Enabled = false;
                                btn001002004.Enabled = false;

                            }
                            else
                            {
                                btn001002001.Text = Cultures.ReturnTranslation("جديد");


                                txt001002001.Enabled = false;
                                dateTimePicker1.Enabled = false;
                                txt001002002.Enabled = false;
                                txt001002003.Enabled = false;
                                txt001002004.Enabled = false;
                                txt001002005.Enabled = false;
                                cbx001002001.Enabled = false;
                                dateTimePicker2.Enabled = false;
                                cbx001002002.Enabled = false;
                                txt001002006.Enabled = false;
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

                        if (txt001002001.Text.Trim() == "")
                        {
                            string Error = "";

                            if (txt001002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الموظف عربي");
                                txt001002002.Focus();
                            }

                            else if (txt001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الموظف إنجليزي");
                                txt001002003.Focus();
                            }
                            else if (cbx001002001.SelectedIndex < 0)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار الجنس");
                                cbx001002001.Focus();
                            }
                            else if (cbx001002002.SelectedIndex < 0)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار الجنسية");
                                cbx001002002.Focus();
                            }
                            else
                            {
                                bool? SameEmployeeNameAR = ElementsTools.DataGridView_.findValueThenSelected(dgv001, ActionType.add, txt001002002.Text.Replace("'", ""), 1);
                                bool? SameEmployeeNameEN = ElementsTools.DataGridView_.findValueThenSelected(dgv001, ActionType.add, txt001002003.Text.Replace("'", ""), 2);

                                if (SameEmployeeNameAR == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد موظف بنفس الإسم العربي");
                                    txt001002002.Focus();

                                }
                                else
                                {
                                    if (SameEmployeeNameEN == true)
                                    {
                                        Error = Cultures.ReturnTranslation("يوجد موظف بنفس الإسم الإنجليزي");
                                        txt001002003.Focus();
                                    }
                                }
                            }

                            if (Error == "")
                            {

                                string[] result = null;
                                object ConnectingMethodsOfCommunicationNO = DataTools.DataBases.Run(ref result, "SpAddNewTblConnectingMethodsOfCommunication", CommandType.StoredProcedure, new object[][] { new object[] { "@OtherDetails", "Add New TblEnterpriseBranches  >> " + DateTime.Now }, new object[] { "@ConnectingMethodsOfCommunicationNO", "OUT" } });

                                string[] result00 = null;
                                DataTools.DataBases.Run(ref result00, "insert into TblEmployees values (@EmployeeNameAR,@EmployeeNameEN,@Gendar,@CountryNo,@ConnectingMethodsOfCommunicationNO)", CommandType.Text, new object[][] {
                                    new object[] { "@EmployeeNameAR", txt001002002.Text },
                                    new object[] { "@EmployeeNameEN", txt001002003.Text },
                                    new object[] { "@Gendar", cbx001002001.SelectedValue },
                                    new object[] { "@CountryNo", cbx001002002.SelectedValue },
                                    new object[] { "@ConnectingMethodsOfCommunicationNO", ConnectingMethodsOfCommunicationNO } });


                                if (result00[1] == "succeeded")
                                {

                                    txt001002001.Enabled = false;
                                    txt001002002.Enabled = false;
                                    txt001002003.Enabled = false;
                                    cbx001002001.Enabled = false;
                                    cbx001002002.Enabled = false;


                                    btn001002001.Enabled = true;
                                    btn001002002.Enabled = false;
                                    btn001002003.Enabled = true;
                                    btn001002004.Enabled = true;

                                    dgv001.Enabled = true;

                                    // تحديث بيانات جدول البيانات
                                    fillTblShifts(); // تعبئة جدول الموظفين
                                    AllEventsAndProperties(true); // تم تحديث جميع الخصائص لتعود الازرار لوضعها الطبيعي

                                    //// تحديث بيانات جدول المنتجات 
                                    //if (GeneralVariables._frmProductsAndServices09 != null) GeneralVariables._frmProductsAndServices09 = null;
                                }



                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);

                                txt001002001.Text = "";
                            }
                            btn001002001.Select();
                        }
                        else
                        {

                            string Error = "";

                            if (txt001002002.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الموظف عربي");
                                txt001002002.Focus();
                            }

                            else if (txt001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل إسم الموظف إنجليزي");
                                txt001002003.Focus();
                            }
                            else if (cbx001002001.SelectedIndex < 0)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار الجنس");
                                cbx001002001.Focus();
                            }
                            else if (cbx001002002.SelectedIndex < 0)
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بإختيار الجنسية");
                                cbx001002002.Focus();
                            }
                            else
                            {
                                bool? SameEmployeeNameAR = ElementsTools.DataGridView_.findValueThenSelected(dgv001, ActionType.edit, txt001002002.Text.Replace("'", ""), 1);
                                bool? SameEmployeeNameEN = ElementsTools.DataGridView_.findValueThenSelected(dgv001, ActionType.edit, txt001002003.Text.Replace("'", ""), 2);

                                if (SameEmployeeNameAR == true)
                                {
                                    Error = Cultures.ReturnTranslation("يوجد موظف بنفس الإسم العربي");
                                    txt001002002.Focus();

                                }
                                else
                                {
                                    if (SameEmployeeNameEN == true)
                                    {
                                        Error = Cultures.ReturnTranslation("يوجد موظف بنفس الإسم الإنجليزي");
                                        txt001002003.Focus();
                                    }
                                }
                            }



                            if (Error == "")
                            {

                                string[] result00 = null;
                                DataTools.DataBases.Run(ref result00, "update TblEmployees set EmployeeNameAR = @EmployeeNameAR,EmployeeNameEN = @EmployeeNameEN, Gendar = @Gendar, CountryNo = @CountryNo  where EmployeeNo = @EmployeeNo", CommandType.Text, new object[][] {
                                    new object[] { "@EmployeeNameAR", txt001002002.Text },
                                    new object[] { "@EmployeeNameEN", txt001002003.Text },
                                    new object[] { "@Gendar", cbx001002001.SelectedValue },
                                    new object[] { "@CountryNo", cbx001002002.SelectedValue },
                                    new object[] { "@EmployeeNo", txt001002001.Text } });

                                if (result00[1] == "succeeded")
                                {
                                    txt001002001.Enabled = false;
                                    txt001002002.Enabled = false;
                                    txt001002003.Enabled = false;
                                    cbx001002001.Enabled = false;
                                    cbx001002002.Enabled = false;

                                    btn001002001.Enabled = true;
                                    btn001002002.Enabled = false;
                                    btn001002003.Enabled = true;
                                    btn001002004.Enabled = true;



                                    dgv001.Enabled = true;

                                    // تحديث بيانات جدول البيانات
                                    fillTblShifts(); // تعبئة جدول الفروع
                                    AllEventsAndProperties(true);

                                    //// تحديث بيانات الشركات الصانعة بنموذج المنتجات
                                    //if (GeneralVariables._frmProductsAndServices09 != null) GeneralVariables._frmProductsAndServices09 = null;
                                }


                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Error, MessageBoxStatus.Ok);
                                dgv001.Enabled = true;
                            }
                            btn001002003.Select();
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


        private void btn001002003EventsAndProperties(bool Properties, bool Events = false) // تعديل 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001002003, "تعديل");

            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn001002003, "تعديل", ColorPropertyName.ForeColor_1, true, true);
                btn001002003.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Shifts, PermissionType.Edit))
                    {
                        if (btn001002003.Enabled)
                        {
                            if (btn001002003.Text == Cultures.ReturnTranslation("تعديل"))
                            {
                                btn001002003.Text = Cultures.ReturnTranslation("إلغاء");

                                txt001002001.Enabled = false;
                                dateTimePicker1.Enabled = false;
                                txt001002002.Enabled = false;
                                txt001002003.Enabled = false;
                                txt001002004.Enabled = false;
                                txt001002005.Enabled = false;
                                cbx001002001.Enabled = true;
                                dateTimePicker2.Enabled = false;
                                cbx001002002.Enabled = false;
                                txt001002006.Enabled = false;
                                txt001002007.Enabled = false;
                                txt001002008.Enabled = false;
                                txt001002009.Enabled = false;

                                cbx001002001.Focus();

                                btn001002002.Enabled = false;
                                btn001002002.Enabled = true;
                                btn001002003.Enabled = true;
                                btn001002004.Enabled = false;
                            }
                            else
                            {
                                btn001002003.Text = Cultures.ReturnTranslation("تعديل");

                                txt001002001.Enabled = false;
                                dateTimePicker1.Enabled = false;
                                txt001002002.Enabled = false;
                                txt001002003.Enabled = false;
                                txt001002004.Enabled = false;
                                txt001002005.Enabled = false;
                                cbx001002001.Enabled = false;
                                dateTimePicker2.Enabled = false;
                                cbx001002002.Enabled = false;
                                txt001002006.Enabled = false;
                                txt001002007.Enabled = false;
                                txt001002008.Enabled = false;
                                txt001002009.Enabled = false;

                                cbx001002001.Focus();

                                btn001002002.Enabled = true;
                                btn001002002.Enabled = false;
                                btn001002003.Enabled = true;
                                btn001002004.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmShifts21 >> btn001002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }



                };

            }
        }
        //private void btn001002004EventsAndProperties(bool Properties, bool Events = false) // حذف 
        //{

        //    if (Properties == true && Events == false)
        //    {
        //        ElementsTools.Button_.CustumProperties(btn001002004, "حذف");
        //    }
        //    else if (Properties == true && Events == true)
        //    {
        //        ElementsTools.Button_.CustumProperties(btn001002004, "حذف", ColorPropertyName.ForeColor_1, true, true);
        //        btn001002004.Click += delegate
        //        {
        //            if (Permissions.AccountHavePermission(PermissionObjectes.Employees, PermissionType.Delete))
        //            {
        //                try
        //                {

        //                    string[] result = null;
        //                    DataTools.DataBases.Run(ref result, "delete from TblEmployees where EmployeeNo = @EmployeeNo", CommandType.Text, new object[][] { new object[] { "@EmployeeNo", txt001002001.Text } });

        //                    if (result[1] == "succeeded")
        //                    {
        //                        txt001002001.Text = "";
        //                        txt001002002.Text = "";
        //                        txt001002003.Text = "";
        //                        cbx001002001.SelectedIndex = -1;
        //                        if (cbx001002002.Items.Count > 0) cbx001002002.SelectedIndex = -1;


        //                        txtSearch.Text = "";

        //                        // تحديث بيانات جدول البيانات
        //                        fillTblEmployees(); // تحديث جدول فروع المنشآت
        //                        dgv001EventsAndProperties(true);
        //                    }

        //                }
        //                catch (Exception ex)
        //                {
        //                    GeneralAction.AddNewNotification("frmShifts21 >> btn001002004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
        //                }


        //            }
        //            else
        //            {
        //                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
        //                GeneralAction.AddNewNotification("frmShifts21 >> btn001002004EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
        //            }


        //        };
        //    }
        //}

        private void dgv001EventsAndProperties(bool Properties, bool Events = false) // جدول عرض الورديات المغلقة
        {
            if (Properties == true && Events == false)
            {
                try
                {

                    fillTblShifts();

                    if (TblShifts.Rows.Count > 0)
                    {

                        dgv001.DataSource = TblShifts;

                        dgv001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الوردية");
                        dgv001.Columns[1].HeaderText = Cultures.ReturnTranslation("تاريخ ووقت فتح الوردية");
                        dgv001.Columns[2].HeaderText = Cultures.ReturnTranslation("رقم الوردية المستلمة");
                        dgv001.Columns[3].HeaderText = Cultures.ReturnTranslation("الرصيد المستلم من الوردية السابقة");
                        dgv001.Columns[4].HeaderText = Cultures.ReturnTranslation("رقم المستخدم");
                        dgv001.Columns[5].HeaderText = Cultures.ReturnTranslation("رقم وحدة العمليات");
                        dgv001.Columns[6].HeaderText = Cultures.ReturnTranslation("حالة الوردية");
                        dgv001.Columns[7].HeaderText = Cultures.ReturnTranslation("تاريخ ووقت إقفال الوردية");
                        dgv001.Columns[8].HeaderText = Cultures.ReturnTranslation("نوع الإقفال");
                        dgv001.Columns[9].HeaderText = Cultures.ReturnTranslation("رقم الحساب الذي قام بالاقفال");
                        dgv001.Columns[10].HeaderText = Cultures.ReturnTranslation("الرصيد القيدي");
                        dgv001.Columns[11].HeaderText = Cultures.ReturnTranslation("الرصيد الفعلي");
                        dgv001.Columns[12].HeaderText = Cultures.ReturnTranslation("الفرق بين الرصيدين");

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
                        dgv001.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                        dgv001.Columns[0].Visible = checkBox1.Checked;
                        dgv001.Columns[1].Visible = checkBox2.Checked;
                        dgv001.Columns[2].Visible = checkBox3.Checked;
                        dgv001.Columns[3].Visible = checkBox4.Checked;
                        dgv001.Columns[4].Visible = checkBox5.Checked;
                        dgv001.Columns[5].Visible = checkBox6.Checked;
                        dgv001.Columns[6].Visible = checkBox7.Checked;
                        dgv001.Columns[7].Visible = checkBox8.Checked;
                        dgv001.Columns[8].Visible = checkBox9.Checked;
                        dgv001.Columns[9].Visible = checkBox10.Checked;
                        dgv001.Columns[10].Visible = checkBox11.Checked;
                        dgv001.Columns[11].Visible = checkBox12.Checked;
                        dgv001.Columns[12].Visible = checkBox13.Checked;

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

                    fillTblShifts();

                    if (TblShifts.Rows.Count > 0)
                    {

                        dgv001.DataSource = TblShifts;

                        dgv001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الوردية");
                        dgv001.Columns[1].HeaderText = Cultures.ReturnTranslation("تاريخ ووقت فتح الوردية");
                        dgv001.Columns[2].HeaderText = Cultures.ReturnTranslation("رقم الوردية المستلمة");
                        dgv001.Columns[3].HeaderText = Cultures.ReturnTranslation("الرصيد المستلم من الوردية السابقة");
                        dgv001.Columns[4].HeaderText = Cultures.ReturnTranslation("رقم المستخدم");
                        dgv001.Columns[5].HeaderText = Cultures.ReturnTranslation("رقم وحدة العمليات");
                        dgv001.Columns[6].HeaderText = Cultures.ReturnTranslation("حالة الوردية");
                        dgv001.Columns[7].HeaderText = Cultures.ReturnTranslation("تاريخ ووقت إقفال الوردية");
                        dgv001.Columns[8].HeaderText = Cultures.ReturnTranslation("نوع الإقفال");
                        dgv001.Columns[9].HeaderText = Cultures.ReturnTranslation("رقم الحساب الذي قام بالاقفال");
                        dgv001.Columns[10].HeaderText = Cultures.ReturnTranslation("الرصيد القيدي");
                        dgv001.Columns[11].HeaderText = Cultures.ReturnTranslation("الرصيد الفعلي");
                        dgv001.Columns[12].HeaderText = Cultures.ReturnTranslation("الفرق بين الرصيدين");

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
                        dgv001.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                        dgv001.Columns[0].Visible = checkBox1.Checked;
                        dgv001.Columns[1].Visible = checkBox2.Checked;
                        dgv001.Columns[2].Visible = checkBox3.Checked;
                        dgv001.Columns[3].Visible = checkBox4.Checked;
                        dgv001.Columns[4].Visible = checkBox5.Checked;
                        dgv001.Columns[5].Visible = checkBox6.Checked;
                        dgv001.Columns[6].Visible = checkBox7.Checked;
                        dgv001.Columns[7].Visible = checkBox8.Checked;
                        dgv001.Columns[8].Visible = checkBox9.Checked;
                        dgv001.Columns[9].Visible = checkBox10.Checked;
                        dgv001.Columns[10].Visible = checkBox11.Checked;
                        dgv001.Columns[11].Visible = checkBox12.Checked;
                        dgv001.Columns[12].Visible = checkBox13.Checked;


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


        //------------------------------ 
        DataTable TblShifts = new DataTable(); // بيانات الموظفين

        // بيانات الموظفين
        private void fillTblShifts()
        {
            try
            {
                if (TblShifts is null)
                {
                TblShifts = new DataTable();
                }
                if (TblShifts.Rows.Count > 0)
                {
                TblShifts.Rows.Clear();
                }

                if (TblShifts.Rows.Count > 0) TblShifts.Rows.Clear();

            TblShifts = DataTools.DataBases.ReadTabel("select * from TblShifts where  DateAndTimeOfShiftClosing > '2000/1/1' ");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmShifts21 >> fillTblShifts ", DateTime.Now, ex.Message, ex.Message);
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
                        DataView dv = new DataView(TblShifts);
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


    }
}

