using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mesrakh
{
    public partial class frmJournalEntry20 : Form
    {
        public frmJournalEntry20()
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

            lbl001002001EventsAndProperties(Properties, Events); //  ملصق رقم القيد المحاسبي الرئيسي في سجل اليومية
            txt001002001EventsAndProperties(Properties, Events); //  مربع نص رقم القيد المحاسبي الرئيسي في سجل اليومية 
            lbl001002002EventsAndProperties(Properties, Events); // ملصق التاريخ والوقت 
            dtp001002001EventsAndProperties(Properties, Events); // مربع نص التاريخ والوقت
            lbl001002003EventsAndProperties(Properties, Events); // ملصق بيان القيد المحاسبي 
            txt001002003EventsAndProperties(Properties, Events); // مربع نص بيان القيد المحاسبي

            btn001002001EventsAndProperties(Properties, Events); // جديد
            btn001002002EventsAndProperties(Properties, Events); // حفظ
            btn001002003EventsAndProperties(Properties, Events); // تعديل
            btn001002004EventsAndProperties(Properties, Events); // حذف

            dgv001EventsAndProperties(Properties, Events); // جدول عرض بيانات القيود المحاسبية
            //-------- البحث
            lblSearchEventsAndProperties(Properties, Events);// ملصق البحث عن
            txtSearchEventsAndProperties(Properties, Events);// مربع نص البحث عن

            //--------- القيود الفرعية
            lblAccountNoEventsAndProperties(Properties, Events); // ملصق رقم الحساب
            cbx08001002001EventsAndProperties(Properties, Events); // قائمة منسدلة المنشأة
            lblDebitValueEventsAndProperties(Properties, Events); // ملصق مدين
            txtDebitValueEventsAndProperties(Properties, Events); // مربع نص مدين
            lblCreditValueEventsAndProperties(Properties, Events); // ملصق دائن
            txtCreditValueEventsAndProperties(Properties, Events); // مربع نص دائن
            lblAccountingEntrytStatementEventsAndProperties(Properties, Events); // ملصق التفاصيل
            txtAccountingEntrytStatementEventsAndProperties(Properties, Events); // مربع نص التفاصيل
            btn001EventsAndProperties(Properties, Events); // زر اضافة قيد فرعي
            btn002EventsAndProperties(Properties, Events); // زر حذف وحدات العمليات

            dgvSubJournalEntryEventsAndProperties(Properties, Events); // جدول عرض بيانات وحدات العمليات

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
                ElementsTools.Lable_.CustumProperties(lbl001001001, "قيود اليومية", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001001001, "قيود اليومية", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
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


        private void lbl001002001EventsAndProperties(bool Properties, bool Events = false) //  ملصق رقم القيد المحاسبي الرئيسي في سجل اليومية  // رقم قيد اليومية
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002001, "رقم قيد اليومية", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002001, "رقم قيد اليومية", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002001EventsAndProperties(bool Properties, bool Events = false) // مربع نص رقم القيد المحاسبي الرئيسي في سجل اليومية
        {
            if (Properties == true & Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002001,"",10);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002001, "",10, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }



     
        private void lbl001002002EventsAndProperties(bool Properties, bool Events = false) // ملصق التاريخ والوقت 
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002002, "التاريخ والوقت", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002002, "التاريخ والوقت", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

            }
        }

        private void dtp001002001EventsAndProperties(bool Properties = true, bool Events = false) // مربع نص التاريخ والوقت
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.DateTimePicker_.CustumProperties(dtp001002001);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.DateTimePicker_.CustumProperties(dtp001002001,true,true);

                dtp001002001.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txt001002003.Select(); };
                };
            }
        }
        private void lbl001002003EventsAndProperties(bool Properties, bool Events = false) // ملصق بيان القيد المحاسبي 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002003, "بيان القيد المحاسبي", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lbl001002003, "بيان القيد المحاسبي", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txt001002003EventsAndProperties(bool Properties, bool Events = false) // مربع نص بيان القيد المحاسبي
        {
            string cultureInfo = "";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002003, cultureInfo,300);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txt001002003, cultureInfo,300, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txt001002003.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btn001002002.PerformClick(); };
                };
            }
        }

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
                        if (Permissions.AccountHavePermission(PermissionObjectes.Journal_Entry, PermissionType.Add))
                        {

                            if (btn001002001.Text == Cultures.ReturnTranslation("جديد"))
                            {
                                btn001002001.Text = Cultures.ReturnTranslation("إلغاء");

                                txt001002001.Enabled = false;
                                dtp001002001.Enabled = true;
                                txt001002003.Enabled = true;


                                txt001002001.Text = "";
                                dtp001002001.Value = DateTime.Now;
                                txt001002003.Text = "";


                                dtp001002001.Focus();

                                btn001002002.Enabled = true;
                                btn001002003.Enabled = false;
                                btn001002004.Enabled = false;

                                dgv001.Enabled = false;
                            }
                            else
                            {
                                btn001002001.Text = Cultures.ReturnTranslation("جديد");

                                txt001002001.Enabled = false;
                                dtp001002001.Enabled = true;
                                txt001002003.Enabled = true;


                                txt001002001.Text = "";
                                dtp001002001.Value = DateTime.Now ;
                                txt001002003.Text = "";

                                dgv001.Enabled = true;

                                btn001002002.Enabled = false;
                                btn001002003.Enabled = true;
                                btn001002004.Enabled = true;
                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmJournalEntry20 >> btn001002001EventsAndProperties - 0", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmJournalEntry20 >> btn001002001EventsAndProperties - 1", DateTime.Now, ex.Message, ex.Message);
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

                            if (dtp001002001.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل التاريخ");
                                dtp001002001.Focus();
                            }
                            else if (txt001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل البيان");
                                txt001002003.Focus();
                            }


                            if (Error == "")
                            {

                                string[] result00 = null;
                                DataTools.DataBases.Run(ref result00, "insert into TblJournalEntry values " +
                                    "(@EntryDateTime,@AccountingEntrytStatement)", CommandType.Text, new object[][] { 
                                    new object[] { "@EntryDateTime", dtp001002001.Value }, 
                                    new object[] { "@AccountingEntrytStatement", txt001002003.Text }
                                    });


                               if(result00[1] == "succeeded")
                                {
                                    btn001002001.Text = Cultures.ReturnTranslation("جديد");

                                    txt001002001.Enabled = false;
                                    dtp001002001.Enabled = false;
                                    txt001002003.Enabled = false;

                                    txt001002001.Text = "";
                                    dtp001002001.Value = DateTime.Now;
                                    txt001002003.Text = "";

                                    btn001002001.Enabled = true;
                                    btn001002002.Enabled = false;
                                    btn001002003.Enabled = true;
                                    btn001002004.Enabled = true;

                                    dgv001.Enabled = true;

                                    // تحديث بيانات جدول البيانات

                                    fillTblJournalEntry(); // تعبئة جدول القيود اليومية الفرعية
                                    dgv001EventsAndProperties(true); // تم تحديث جميع الخصائص لتعود الازرار لوضعها الطبيعي

                                    dgv001.Rows[dgv001.Rows.Count - 1].Selected = true;

                                    fillTblSubJournalEntry(Convert.ToInt32(txt001002001.Text)); // تعبئة جدول قيود اليومية الفرعية
                                    dgvSubJournalEntryEventsAndProperties(true);
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

                            if (dtp001002001.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل التاريخ");
                                dtp001002001.Focus();
                            }
                            else if (txt001002003.Text.Trim() == "")
                            {
                                Error = Cultures.ReturnTranslation("رجاء قم بتسجيل البيان");
                                txt001002003.Focus();
                            }


                            if (Error == "")
                            {

                                string[] result00 = null;
                                DataTools.DataBases.Run(ref result00, "update TblJournalEntry  set" +
                                    " EntryDateTime = @EntryDateTime , AccountingEntrytStatement = @AccountingEntrytStatement where JournalEntryNo = @JournalEntryNo", CommandType.Text, new object[][] {
                                    new object[] { "@EntryDateTime", dtp001002001.Value },
                                    new object[] { "@AccountingEntrytStatement", txt001002003.Text },
                                    new object[] { "@JournalEntryNo", txt001002001.Text }
                                    });

                                if (result00[1] == "succeeded")
                                {
                                    btn001002003.Text = Cultures.ReturnTranslation("تعديل");


                                    txt001002001.Enabled = false;
                                    dtp001002001.Enabled = false;
                                    txt001002003.Enabled = false;


                                    txt001002001.Text = "";
                                    dtp001002001.Value = DateTime.Now;
                                    txt001002003.Text = "";

                                    btn001002001.Enabled = true;
                                    btn001002002.Enabled = false;
                                    btn001002003.Enabled = true;
                                    btn001002004.Enabled = true;



                                    dgv001.Enabled = true;

                                    // تحديث بيانات جدول البيانات
                                    fillTblJournalEntry(); // تعبئة جدول العملاء
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
                        GeneralAction.AddNewNotification("frmJournalEntry20 >> btn001002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
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
                    if (Permissions.AccountHavePermission(PermissionObjectes.Journal_Entry, PermissionType.Edit))
                    {
                        if (btn001002003.Enabled)
                        {
                            if (btn001002003.Text == Cultures.ReturnTranslation("تعديل"))
                            {
                                btn001002003.Text = Cultures.ReturnTranslation("إلغاء");

                                txt001002001.Enabled = false;
                                dtp001002001.Enabled = true;
                                txt001002003.Enabled = true;


                                btn001002001.Enabled = false;
                                btn001002002.Enabled = true;
                                btn001002004.Enabled = false;

                                dtp001002001.Select();

                                dgv001.Enabled = false;
                            }
                            else
                            {
                                btn001002003.Text = Cultures.ReturnTranslation("تعديل");

                                txt001002001.Enabled = false;
                                dtp001002001.Enabled = false;
                                txt001002003.Enabled = false;

                                btn001002001.Enabled = true;
                                btn001002002.Enabled = false;
                                btn001002004.Enabled = true;

                                dgv001.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmJournalEntry20 >> btn001002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }

                    

                };

            }
        }
        private void btn001002004EventsAndProperties(bool Properties, bool Events = false) // حذف 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn001002004, "حذف");
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn001002004, "حذف", ColorPropertyName.ForeColor_1, true, true);
                btn001002004.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Journal_Entry, PermissionType.Delete))
                    {
                        try
                        {

                            string[] result = null;
                            DataTools.DataBases.Run(ref result, "delete from TblJournalEntry where JournalEntryNo = @JournalEntryNo", CommandType.Text, new object[][] { new object[] { "@JournalEntryNo", txt001002001.Text } });

                            if(result[1] == "succeeded")
                            {
                                txt001002001.Text = "";
                                dtp001002001.Text = "";
                                txt001002003.Text = "";

                                txtSearch.Text = "";

                                // تحديث بيانات جدول البيانات
                                fillTblJournalEntry(); // تحديث جدول فروع المنشآت
                                dgv001EventsAndProperties(true);
                            }

                        }
                        catch (Exception ex)
                        {
                            GeneralAction.AddNewNotification("frmJournalEntry20 >> btn001002004EventsAndProperties - 0 ", DateTime.Now,ex.Message, ex.Message);
                        }


                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmJournalEntry20 >> btn001002004EventsAndProperties - 1", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }


                };
            }
        }

        int SelectedRowIndex = -1; // يستخدم في تعبئة الجدول

        private void dgv001EventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات القيود المحاسبية
        {
            if (Properties == true && Events == false)
            {
                try
                {

                    if (TblJournalEntry is null) { fillTblJournalEntry(); }
                    if (TblJournalEntry.Rows.Count <= 0) { fillTblJournalEntry(); }

                    if (TblJournalEntry.Rows.Count > 0)
                    {

                        dgv001.DataSource = TblJournalEntry;

                        dgv001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم قيد اليومية");
                        dgv001.Columns[1].HeaderText = Cultures.ReturnTranslation("التاريخ والوقت");
                        dgv001.Columns[2].HeaderText = Cultures.ReturnTranslation("بيان القيد المحاسبي");

                        dgv001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv001.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                    GeneralAction.AddNewNotification("frmJournalEntry20 >> dgv001EventsAndProperties - 0 ", DateTime.Now, ex.Message, ex.Message);

                }
            }
            else if (Properties == true && Events == true)
            {
                try
                {

                    if (TblJournalEntry is null) { fillTblJournalEntry(); }
                    if (TblJournalEntry.Rows.Count <= 0) { fillTblJournalEntry(); }
                    if (TblJournalEntry.Rows.Count > 0)
                    {

                        dgv001.DataSource = TblJournalEntry;
                        dgv001.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم قيد اليومية");
                        dgv001.Columns[1].HeaderText = Cultures.ReturnTranslation("التاريخ والوقت");
                        dgv001.Columns[2].HeaderText = Cultures.ReturnTranslation("بيان القيد المحاسبي");

                        dgv001.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv001.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                    GeneralAction.AddNewNotification("frmJournalEntry20 >> dgv001EventsAndProperties - 1 ", DateTime.Now, ex.Message, ex.Message);

                }


                dgv001.SelectionChanged += delegate
                {
                    try
                    {
                        if (dgv001.Rows.Count > 0)
                        {

                            if (dgv001.SelectedRows.Count == 0 || dgv001.SelectedRows == null) return;

                            txt001002001.Text = dgv001.SelectedRows[0].Cells[0].Value.ToString();
                            dtp001002001.Text = dgv001.SelectedRows[0].Cells[1].Value.ToString();
                            txt001002003.Text = dgv001.SelectedRows[0].Cells[2].Value.ToString();

                            SelectedRowIndex = dgv001.SelectedRows[0].Index;

                            fillTblSubJournalEntry(Convert.ToInt32(dgv001.CurrentRow.Cells[0].Value));// تعبئة القيود الفرعية
                            dgvSubJournalEntryEventsAndProperties(true); // عرض القيود الفرعية

                            //// جمع عمودين والتأكد هل هما متساووين
                            //decimal DebitValue = Convert.ToDecimal(TblSubJournalEntry.Compute("Sum(DebitValue)", string.Empty));
                            //decimal CreditValue = Convert.ToDecimal(TblSubJournalEntry.Compute("Sum(CreditValue)", string.Empty));

                            if (dgvSubJournalEntry.Rows != null)
                            {
                                if (dgvSubJournalEntry.Rows.Count > 0)
                                {
                                    if (dgvSubJournalEntry.Rows[dgvSubJournalEntry.Rows.Count - 1].Cells[4].Value.ToString().Trim() == dgvSubJournalEntry.Rows[dgvSubJournalEntry.Rows.Count - 1].Cells[5].Value.ToString().Trim())
                                    {
                                        ElementsTools.DataGridView_.CustumProperties(dgvSubJournalEntry);
                                        dgvSubJournalEntry.Rows[dgvSubJournalEntry.Rows.Count - 1].DefaultCellStyle.BackColor = Color.GreenYellow;
                                    }
                                    else
                                    {
                                        dgvSubJournalEntry.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed; // لون خلفية صف عناوين الاعمدة
                                        dgvSubJournalEntry.Rows[dgvSubJournalEntry.Rows.Count - 1].DefaultCellStyle.BackColor = Color.IndianRed;
                                    }
                                }
                            }


                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmJournalEntry20 >> dgv001EventsAndProperties - 2 ", DateTime.Now, ex.Message, ex.Message);

                    }
                };

                dgv001.KeyDown += delegate (object sender, KeyEventArgs e)
                {

                    try
                    {
                        if (e.KeyData == Keys.Subtract)
                        {

                            btn001002004.PerformClick();

                        }
                        else if (e.KeyData == Keys.Enter)
                        {
                            if (dgv001.SelectedRows != null)
                            {
                                btn001002003.PerformClick();

                            }
                        }
                        else if (e.KeyData == Keys.Add)
                        {

                            btn001002001.PerformClick();
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmJournalEntry20 >> dgv001EventsAndProperties - 3 ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                dgv001.DataBindingComplete += delegate
                {
                    ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات



                };
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- البحث
        private void lblSearchEventsAndProperties(bool Properties, bool Events = false) // ملصق البحث عن الشركات 
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

        private void txtSearchEventsAndProperties(bool Properties, bool Events = false) // مربع نص البحث عن الشركات
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
                        DataView dv = new DataView(TblJournalEntry);
                        string filter = "";
                        filter = "AccountingEntrytStatement like '%" + txtSearch.Text.Replace("'", "") + "%'";
                        dv.RowFilter = filter;
                        dgv001.DataSource = dv;
                        ElementsTools.DataGridView_.CustumProperties(dgv001);  // تخصيص خصائص جدول عرض البيانات
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmJournalEntry20 >> txtSearchEventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }


        //--------------------------------- القيود التفصيلية

        DataTable TblJournalEntry = new DataTable(); // بيانات القيود الرئيسية
        DataTable TblAccounts = new DataTable();      // بيانات الحسابات
        DataTable TblSubJournalEntry = new DataTable();// بيانات القيود الفرعية



        // بيانات العملاء
        private void fillTblJournalEntry()
        {
            try
            {
                if (TblJournalEntry is null)
                {
                    TblJournalEntry = new DataTable();
                }
                if (TblJournalEntry.Rows.Count > 0)
                {
                    TblJournalEntry.Rows.Clear();
                }

                if (TblJournalEntry.Rows.Count > 0) TblJournalEntry.Rows.Clear();

                TblJournalEntry = DataTools.DataBases.ReadTabel("select * from TblJournalEntry ");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmJournalEntry20 >> fillTblJournalEntry ", DateTime.Now, ex.Message, ex.Message);
            }
        }
        private void fillTblAccounts()
        {
            try
            {
                if (TblAccounts is null)
                {
                    TblAccounts = new DataTable();
                }

                if (TblAccounts.Rows.Count > 0)
                {
                    TblAccounts.Rows.Clear();
                }

                if (TblAccounts.Rows.Count > 0) TblAccounts.Rows.Clear();

                TblAccounts = DataTools.DataBases.ReadTabel("select * from TblAccounts ");

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("frmJournalEntry20 >> fillTblAccounts ", DateTime.Now, ex.Message, ex.Message);
            }
        }

        private void fillTblSubJournalEntry(int JournalEntryNo = 0)
        {
            try
            {
                if (TblSubJournalEntry.Rows.Count > 0) TblSubJournalEntry.Clear();
                string commandString = @"select TblSubJournalEntry.SubJornalEntryNo,TblAccounts.AccountNo ,TblAccounts.AccountNameAR,TblAccounts.AccountNameEN,TblSubJournalEntry.DebitValue,TblSubJournalEntry.CreditValue, TblSubJournalEntry.AccountingEntrytStatement , TblSubJournalEntry.JournalEntryNo from TblSubJournalEntry inner join TblAccounts on TblAccounts.AccountNo = TblSubJournalEntry.AccountNo where TblSubJournalEntry.JournalEntryNo = "+ JournalEntryNo;
                SqlCommand com = new SqlCommand(commandString, ConnectionsTools.ConMesrakhMainDB());


                if (dgv001.CurrentRow.Cells[0].Value is null)
                {
                    fillTblJournalEntry();
                    dgv001EventsAndProperties(true);
                    dgv001.Rows[SelectedRowIndex].Selected = true; // تحديد الصف الذي كنا عليه
                }

                TblSubJournalEntry.Load(com.ExecuteReader());

                decimal DebitValue = Convert.ToDecimal(TblSubJournalEntry.Compute("Sum(DebitValue)", string.Empty));
                decimal CreditValue = Convert.ToDecimal(TblSubJournalEntry.Compute("Sum(CreditValue)", string.Empty));

                DataRow dr = TblSubJournalEntry.NewRow();
                dr[0] = 1000000;
                dr[1] = 1000000;
                dr[2] = "المجموع";
                dr[3] = "Total";
                dr[4] = DebitValue;
                dr[5] = CreditValue;
                dr[6] = GeneralVariables.cultureCode == "AR"? "المجموع" : "Total";
                dr[7] = TblSubJournalEntry.Rows[0][7];

                TblSubJournalEntry.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmJournalEntry20 >> fillTblSubJournalEntry ", DateTime.Now, ex.Message, ex.Message);
            }
        }


        //---
        private void lblAccountNoEventsAndProperties(bool Properties, bool Events = false) // ملصق  الحسابات
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblAccountNo, "الحساب", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblAccountNo, "الحساب", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void cbx08001002001EventsAndProperties(bool Properties, bool Events = false) // قائمة منسدلة الحسابات
        {
            if (Properties == true && Events == false)
            {
                try
                {

                    if (TblAccounts is null) return;
                    if (TblAccounts.Rows.Count > 0)
                    {
                        cbxAccountNo.DataSource = TblAccounts;
                        cbxAccountNo.ValueMember = "AccountNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbxAccountNo.DisplayMember = "AccountNameAR";
                        }
                        else
                        {
                            cbxAccountNo.DisplayMember = "AccountNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbxAccountNo);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmJournalEntry20 >> cbx08001002001EventsAndProperties - 0 ", DateTime.Now, ex.Message, ex.Message);
                }


            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    fillTblAccounts();

                    if (TblAccounts is null) return;
                    if (TblAccounts.Rows.Count > 0)
                    {
                        cbxAccountNo.DataSource = TblAccounts;
                        cbxAccountNo.ValueMember = "AccountNo";
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cbxAccountNo.DisplayMember = "AccountNameAR";
                        }
                        else
                        {
                            cbxAccountNo.DisplayMember = "AccountNameEN";
                        }
                    }
                    ElementsTools.ComboBox_.CustumProperties(cbxAccountNo, "", true, true);

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmJournalEntry20 >> cbx08001002001EventsAndProperties - 1 ", DateTime.Now, ex.Message, ex.Message);
                }

                cbxAccountNo.KeyDown += delegate (object mysender, KeyEventArgs mye)
                {
                    if (mye.KeyData == Keys.Enter)
                    {
                        txtDebitValue.Select();
                    }
                };

            }
        }


        private void lblDebitValueEventsAndProperties(bool Properties, bool Events = false) // ملصق مدين
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblDebitValue, "مدين", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblDebitValue, "مدين", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txtDebitValueEventsAndProperties(bool Properties = true, bool Events = false) // مربع نص مدين
        {
            string cultureInfo = "en-US";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txtDebitValue, cultureInfo,9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtDebitValue, cultureInfo,9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true,TextBoxType.Decimal);

                txtDebitValue.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter)
                    {
                        if(txtDebitValue.Text == "0" || txtDebitValue.Text.Trim() == "")
                        {
                            txtCreditValue.Select();
                        }
                        else
                        {
                            txtAccountingEntrytStatement.Select();
                        }
                    };
                };

                txtDebitValue.Enter += delegate 
                {
                    txtDebitValue.Select();
                    txtCreditValue.Text = "0";
                };
            }
        }

        private void lblCreditValueEventsAndProperties(bool Properties, bool Events = false) // ملصق دائن
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblCreditValue, "دائن", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblCreditValue, "دائن", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txtCreditValueEventsAndProperties(bool Properties = true, bool Events = false) // مربع نص دائن
        {
            string cultureInfo = "en-US";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txtCreditValue, cultureInfo,9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, false, TextBoxType.Decimal);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtCreditValue, cultureInfo,9, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true, TextBoxType.Decimal);

                txtCreditValue.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { txtAccountingEntrytStatement.Select(); };

                };

                txtCreditValue.Enter += delegate
                {
                    txtCreditValue.Select();
                    txtDebitValue.Text = "0";
                };
            }
        }

        private void lblAccountingEntrytStatementEventsAndProperties(bool Properties, bool Events = false) // ملصق التفاصيل
        {

            if (Properties == true & Events == false)
            {
                ElementsTools.Lable_.CustumProperties(lblAccountingEntrytStatement, "التفاصيل", ColorPropertyName.BackColor_1);
            }
            else if (Properties == true & Events == true)
            {
                ElementsTools.Lable_.CustumProperties(lblAccountingEntrytStatement, "التفاصيل", ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);
            }
        }

        private void txtAccountingEntrytStatementEventsAndProperties(bool Properties = true, bool Events = false) // مربع نص التفاصيل
        {
            string cultureInfo = "";
            if (Properties == true && Events == false)
            {
                ElementsTools.TextBox_.CustumProperties(txtAccountingEntrytStatement, cultureInfo,300);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.TextBox_.CustumProperties(txtAccountingEntrytStatement, cultureInfo,300, ColorPropertyName.BackColor_1, ColorPropertyName.ForeColor_1, true, true);

                txtAccountingEntrytStatement.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter) { btn001.PerformClick(); };

                };
            }
        }


        private void btn001EventsAndProperties(bool Properties, bool Events = false) // زر اضافة قيد فرعي
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
                        if (Permissions.AccountHavePermission(PermissionObjectes.Journal_Entry, PermissionType.Add))
                        {

                            if (btn001.Text == Cultures.ReturnTranslation("إضافة"))
                            {
                                btn001.Text = Cultures.ReturnTranslation("حفظ");

                                cbxAccountNo.Enabled = true;
                                txtDebitValue.Enabled = true;
                                txtCreditValue.Enabled = true;
                                txtAccountingEntrytStatement.Enabled = true;

                                txtDebitValue.Text = "";
                                txtCreditValue.Text = "";
                                txtAccountingEntrytStatement.Text = "";

                                dgvSubJournalEntry.Enabled = false;

                                cbxAccountNo.Select();
                            }
                            else
                            {
                                string check = "";

                                if (cbxAccountNo.SelectedIndex < 0 )
                                {
                                    check += Cultures.ReturnTranslation("رجاء قم بتحديد الحساب من القائمة");
                                    cbxAccountNo.Select();
                                }
                                else if (txtAccountingEntrytStatement.Text.Trim() == "")
                                {
                                    check += Cultures.ReturnTranslation("رجاء قم بتسجيل بيانات القيد");
                                    txtAccountingEntrytStatement.Focus();
                                }
                                else if(txt001002001.Text.Trim()=="")
                                {
                                    check += Cultures.ReturnTranslation("رجاء قم بتحديد القيد الرئيسي");
                                    dgv001.Enabled = true;
                                    dgv001.Select();
                                }
                                else
                                {
                                    int xxx = 0;
                                    Regex reg = new Regex("\\d+");
                                    bool deb =  reg.IsMatch(txtDebitValue.Text);
                                    bool ced =  reg.IsMatch(txtCreditValue.Text);
                                    if(deb)
                                    {
                                        xxx += Convert.ToInt32(txtDebitValue.Text);
                                    }
                                    if(ced)
                                    {
                                        xxx += Convert.ToInt32(txtCreditValue.Text);
                                    }


                                    if(txtCreditValue.Text.Trim() == "" && txtDebitValue.Text.Trim() == "")
                                    {
                                        xxx += 0;
                                    }

                                    if(xxx == 0 )
                                    {
                                        check += Cultures.ReturnTranslation("رجاء قم بتسجيل قيمة أكبر من صفر في أحد الجانبين");
                                        txtDebitValue.Enabled = true;
                                    }
                                }


                                if (check == "")
                                {

                                    string[] result = null;
                                     DataTools.DataBases.Run(ref result, "insert into TblSubJournalEntry values (@JournalEntryNo , @AccountNo , @DebitValue , @CreditValue , @AccountingEntrytStatement)", CommandType.Text, new object[][] 
                                    { new object[] { "@JournalEntryNo", txt001002001.Text },
                                        new object[] { "@AccountNo", cbxAccountNo.SelectedValue } ,
                                        new object[] { "@DebitValue", txtDebitValue.Text } ,
                                        new object[] { "@CreditValue", txtCreditValue.Text } ,
                                        new object[] { "@AccountingEntrytStatement", txtAccountingEntrytStatement.Text } ,
                                    });

                                    if(result[1] == "succeeded")
                                    {
                                        btn001.Text = Cultures.ReturnTranslation("إضافة");
                                        cbxAccountNo.Enabled = false;
                                        txtDebitValue.Enabled = false;
                                        txtCreditValue.Enabled = false;
                                        txtAccountingEntrytStatement.Enabled = false;

                                        dgvSubJournalEntry.Enabled = true;


                                        fillTblSubJournalEntry(Convert.ToInt32(txt001002001.Text));// تعبئة القيود الفرعية
                                        dgvSubJournalEntryEventsAndProperties(true); // عرض القيود الفرعية
                                        btn001.Focus();

                                        //// جمع عمودين والتأكد هل هما متساووين
                                        //decimal DebitValue = Convert.ToDecimal(TblSubJournalEntry.Compute("Sum(DebitValue)", string.Empty));
                                        //decimal CreditValue = Convert.ToDecimal(TblSubJournalEntry.Compute("Sum(CreditValue)", string.Empty));

                                        //if(DebitValue == CreditValue)
                                        //{
                                        //    ElementsTools.DataGridView_.CustumProperties(dgvSubJournalEntry);
                                        //}
                                        //else
                                        //{
                                        //    dgvSubJournalEntry.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkRed; // لون خلفية صف عناوين الاعمدة
                                        //}

                                        if (dgvSubJournalEntry.Rows != null)
                                        {
                                            if (dgvSubJournalEntry.Rows.Count > 0)
                                            {
                                                if (dgvSubJournalEntry.Rows[dgvSubJournalEntry.Rows.Count - 1].Cells[4].Value.ToString().Trim() == dgvSubJournalEntry.Rows[dgvSubJournalEntry.Rows.Count - 1].Cells[5].Value.ToString().Trim())
                                                {
                                                    ElementsTools.DataGridView_.CustumProperties(dgvSubJournalEntry);
                                                    dgvSubJournalEntry.Rows[dgvSubJournalEntry.Rows.Count - 1].DefaultCellStyle.BackColor = Color.GreenYellow;
                                                }
                                                else
                                                {
                                                    dgvSubJournalEntry.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed; // لون خلفية صف عناوين الاعمدة
                                                    dgvSubJournalEntry.Rows[dgvSubJournalEntry.Rows.Count - 1].DefaultCellStyle.BackColor = Color.IndianRed;
                                                }
                                            }
                                        }


                                    }

                                }
                                else
                                {
                                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), check, MessageBoxStatus.Ok);

                                }

                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmJournalEntry20 >> btn001EventsAndProperties - 0", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }

                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmJournalEntry20 >> btn001EventsAndProperties - 1 ", DateTime.Now, ex.Message, ex.Message);
                    }



                };
            }
        }


        private void btn002EventsAndProperties(bool Properties, bool Events = false) // زر حذف وحدات العمليات
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
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Journal_Entry, PermissionType.Delete))
                        {
                            int xxx = 0;
                            if (dgvSubJournalEntry.Rows.Count > 0)
                            {
                                if (dgvSubJournalEntry.SelectedRows != null)
                                {
                                    if (dgvSubJournalEntry.SelectedRows.Count > 0)
                                    {
                                        xxx = int.Parse(dgvSubJournalEntry.SelectedRows[0].Cells[0].Value.ToString());
                                    }
                                    else
                                    {
                                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء قم بالضغط على القيد الفرعي الذي ترغب في حذفه"), MessageBoxStatus.Ok);
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }

                            if (xxx > -1)
                            {
                                string[] result = null;
                                object r = DataTools.DataBases.Run(ref result, "delete from TblSubJournalEntry where SubJornalEntryNo = @SubJornalEntryNo", CommandType.Text, new object[][] { new object[] { "@SubJornalEntryNo", xxx } });
                                
                                fillTblSubJournalEntry(Convert.ToInt32(txt001002001.Text));// تعبئة القيود الفرعية
                                dgvSubJournalEntryEventsAndProperties(true); // عرض القيود الفرعية

                                txtDebitValue.Text = "";
                                txtCreditValue.Text = "";
                                txtAccountingEntrytStatement.Text = "";


                                // الألوان
                                if (dgvSubJournalEntry.Rows != null)
                                {
                                    if (dgvSubJournalEntry.Rows.Count > 0)
                                    {
                                        if (dgvSubJournalEntry.Rows[dgvSubJournalEntry.Rows.Count - 1].Cells[4].Value.ToString().Trim() == dgvSubJournalEntry.Rows[dgvSubJournalEntry.Rows.Count - 1].Cells[5].Value.ToString().Trim())
                                        {
                                            ElementsTools.DataGridView_.CustumProperties(dgvSubJournalEntry);
                                            dgvSubJournalEntry.Rows[dgvSubJournalEntry.Rows.Count - 1].DefaultCellStyle.BackColor = Color.GreenYellow;
                                        }
                                        else
                                        {
                                            dgvSubJournalEntry.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed; // لون خلفية صف عناوين الاعمدة
                                            dgvSubJournalEntry.Rows[dgvSubJournalEntry.Rows.Count - 1].DefaultCellStyle.BackColor = Color.IndianRed;
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmJournalEntry20 >> btn002EventsAndProperties - 0", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmJournalEntry20 >> btn002EventsAndProperties - 1 ", DateTime.Now, ex.Message, ex.Message);
                    }


                };


            }
        }

        private void dgvSubJournalEntryEventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات وحدات العمليات
        {
            if (Properties == true && Events == false)
            {
                try
                {


                    if (TblSubJournalEntry is null) { if (!string.IsNullOrEmpty(txt001002001.Text)) { fillTblSubJournalEntry(Convert.ToInt32(txt001002001.Text)); } };
                    if (TblSubJournalEntry.Rows.Count <= 0) { if (!string.IsNullOrEmpty(txt001002001.Text)) { fillTblSubJournalEntry(Convert.ToInt32(txt001002001.Text)); } };

                    if (TblSubJournalEntry.Rows.Count > 0)
                    {
                        if (dgvSubJournalEntry.DataSource == null) dgvSubJournalEntry.DataSource = TblSubJournalEntry;

                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgvSubJournalEntry.Columns[0].Visible = false;
                            dgvSubJournalEntry.Columns[1].Visible = false;
                            dgvSubJournalEntry.Columns[2].Visible = true;
                            dgvSubJournalEntry.Columns[2].HeaderText = Cultures.ReturnTranslation("الحساب");
                            dgvSubJournalEntry.Columns[3].Visible = false;
                            dgvSubJournalEntry.Columns[4].HeaderText = Cultures.ReturnTranslation("مدين");
                            dgvSubJournalEntry.Columns[5].HeaderText = Cultures.ReturnTranslation("دائن");
                            dgvSubJournalEntry.Columns[6].HeaderText = Cultures.ReturnTranslation("التفاصيل");
                            dgvSubJournalEntry.Columns[7].Visible = false;

                            dgvSubJournalEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgvSubJournalEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgvSubJournalEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgvSubJournalEntry.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        else
                        {
                            dgvSubJournalEntry.Columns[0].Visible = false;
                            dgvSubJournalEntry.Columns[1].Visible = false;
                            dgvSubJournalEntry.Columns[2].Visible = false;
                            dgvSubJournalEntry.Columns[3].Visible = true;
                            dgvSubJournalEntry.Columns[3].HeaderText = Cultures.ReturnTranslation("الحساب");
                            dgvSubJournalEntry.Columns[4].HeaderText = Cultures.ReturnTranslation("مدين");
                            dgvSubJournalEntry.Columns[5].HeaderText = Cultures.ReturnTranslation("دائن");
                            dgvSubJournalEntry.Columns[6].HeaderText = Cultures.ReturnTranslation("التفاصيل");
                            dgvSubJournalEntry.Columns[7].Visible = false;

                            dgvSubJournalEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgvSubJournalEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgvSubJournalEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgvSubJournalEntry.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        ElementsTools.DataGridView_.CustumProperties(dgvSubJournalEntry);
                    }
                    else
                    {
                        dgvSubJournalEntry.DataSource = null;
                        dgvSubJournalEntry.Rows.Clear();
                        ElementsTools.DataGridView_.CustumProperties(dgvSubJournalEntry);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmJournalEntry20 >> dgvSubJournalEntryEventsAndProperties - 0 ", DateTime.Now, ex.Message, ex.Message);
                }


            }

            // الاحداث
            if (Properties == true && Events == true)
            {

                try
                {


                    if (TblSubJournalEntry is null ) { if (!string.IsNullOrEmpty(txt001002001.Text)) { fillTblSubJournalEntry(Convert.ToInt32(txt001002001.Text)); } };
                    if (TblSubJournalEntry.Rows.Count <= 0) { if (!string.IsNullOrEmpty(txt001002001.Text)) { fillTblSubJournalEntry(Convert.ToInt32(txt001002001.Text)); } };

                    if (TblSubJournalEntry.Rows.Count > 0)
                    {
                        if (dgvSubJournalEntry.DataSource == null) dgvSubJournalEntry.DataSource = TblSubJournalEntry;

                        if (GeneralVariables.cultureCode == "AR")
                        {
                            dgvSubJournalEntry.Columns[0].Visible = false;
                            dgvSubJournalEntry.Columns[1].Visible = false;
                            dgvSubJournalEntry.Columns[2].Visible = true;
                            dgvSubJournalEntry.Columns[2].HeaderText = Cultures.ReturnTranslation("الحساب");
                            dgvSubJournalEntry.Columns[3].Visible = false;
                            dgvSubJournalEntry.Columns[4].HeaderText = Cultures.ReturnTranslation("مدين");
                            dgvSubJournalEntry.Columns[5].HeaderText = Cultures.ReturnTranslation("دائن");
                            dgvSubJournalEntry.Columns[6].HeaderText = Cultures.ReturnTranslation("التفاصيل");
                            dgvSubJournalEntry.Columns[7].Visible = false;

                            dgvSubJournalEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgvSubJournalEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgvSubJournalEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgvSubJournalEntry.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        else
                        {
                            dgvSubJournalEntry.Columns[0].Visible = false;
                            dgvSubJournalEntry.Columns[1].Visible = false;
                            dgvSubJournalEntry.Columns[2].Visible = false;
                            dgvSubJournalEntry.Columns[3].Visible = true;
                            dgvSubJournalEntry.Columns[3].HeaderText = Cultures.ReturnTranslation("الحساب");
                            dgvSubJournalEntry.Columns[4].HeaderText = Cultures.ReturnTranslation("مدين");
                            dgvSubJournalEntry.Columns[5].HeaderText = Cultures.ReturnTranslation("دائن");
                            dgvSubJournalEntry.Columns[6].HeaderText = Cultures.ReturnTranslation("التفاصيل");
                            dgvSubJournalEntry.Columns[7].Visible = false;

                            dgvSubJournalEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgvSubJournalEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgvSubJournalEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgvSubJournalEntry.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }

                        ElementsTools.DataGridView_.CustumProperties(dgvSubJournalEntry);
                    }
                    else
                    {
                        dgvSubJournalEntry.DataSource = null;
                        dgvSubJournalEntry.Rows.Clear();
                        ElementsTools.DataGridView_.CustumProperties(dgvSubJournalEntry);
                    }
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmJournalEntry20 >> dgvSubJournalEntryEventsAndProperties - 1 ", DateTime.Now, ex.Message, ex.Message);
                }

            };

            dgvSubJournalEntry.DataBindingComplete += delegate
            {
                ElementsTools.DataGridView_.CustumProperties(dgvSubJournalEntry);
            };

            dgvSubJournalEntry.SelectionChanged += delegate
            {
                if (dgvSubJournalEntry.SelectedRows != null)
                {
                    if (dgvSubJournalEntry.SelectedRows.Count > 0)
                    {
                        cbxAccountNo.SelectedValue = dgvSubJournalEntry.SelectedRows[0].Cells[1].Value;
                        txtDebitValue.Text = dgvSubJournalEntry.SelectedRows[0].Cells[4].Value.ToString();
                        txtCreditValue.Text = dgvSubJournalEntry.SelectedRows[0].Cells[5].Value.ToString();
                        txtAccountingEntrytStatement.Text = dgvSubJournalEntry.SelectedRows[0].Cells[6].Value.ToString();
                    }
                }
            };

            dgvSubJournalEntry.KeyDown += delegate (object sender, KeyEventArgs e)
            {
                try
                {
                    if (e.KeyData == Keys.Subtract)
                    {

                        if (dgvSubJournalEntry.SelectedRows != null)
                        {
                            if (dgvSubJournalEntry.SelectedRows.Count > 0)
                            {
                                btn002.PerformClick();
                            }
                        }

                    }
                    if (e.KeyData == Keys.Add)
                    {
                        if (btn001.Text == "إضافة" || btn001.Text == "Add")
                        {
                            btn001.PerformClick();
                        }
                    }

                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmJournalEntry20 >> dgvSubJournalEntryEventsAndProperties - 2 ", DateTime.Now, ex.Message, ex.Message);
                }

            };
            
        }
               

    }
}

