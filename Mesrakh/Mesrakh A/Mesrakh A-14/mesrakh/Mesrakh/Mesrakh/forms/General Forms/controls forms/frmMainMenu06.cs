using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mesrakh
{
    public partial class frmMainMenu06 : Form
    {
        public frmMainMenu06()
        {
            InitializeComponent();
            AllfrmMainMenu06ElementsEventsAndProperties(true, true); // تحميل الخصائص والاحداث
        }

        public void AllfrmMainMenu06ElementsEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmMainMenu06EventsAndProperties(Properties, Events); //  النموذج

            pnl06002EventsAndProperties(Properties, Events); // الحاوية 1
            pnl06004EventsAndProperties(Properties, Events); // الحاوية 2
            pnl06006EventsAndProperties(Properties, Events); // الحاوية 3
            pnl06008EventsAndProperties(Properties, Events); // الحاوية 4

            btn06001EventsAndProperties(Properties, Events);    //  الزر 1
            btn06002001EventsAndProperties(Properties, Events); //  الزر 1-1
            btn06002002EventsAndProperties(Properties, Events); //  الزر 1-2
            btn06002003EventsAndProperties(Properties, Events); //  الزر 1-3
            btn06002004EventsAndProperties(Properties, Events); //  الزر 1-4
            btn06002005EventsAndProperties(Properties, Events); //  الزر 1-5
            btn06002006EventsAndProperties(Properties, Events); //  الزر 1-6
            btn06002007EventsAndProperties(Properties, Events); //  الزر 1-7

            btn06003EventsAndProperties(Properties, Events);    //  الزر 2
            btn06004001EventsAndProperties(Properties, Events); //  الزر 2-1
            btn06004002EventsAndProperties(Properties, Events); //  الزر 2-2
            btn06004003EventsAndProperties(Properties, Events); //  الزر 2-3
            btn06004004EventsAndProperties(Properties, Events); //  الزر 2-4

            btn06005EventsAndProperties(Properties, Events);    //  الزر 3
            btn06006001EventsAndProperties(Properties, Events); //  الزر 3-1
            btn06006002EventsAndProperties(Properties, Events); //  الزر 3-2
            btn06006003EventsAndProperties(Properties, Events); //  الزر 3-3
            btn06006004EventsAndProperties(Properties, Events); //  الزر 3-4

            btn06007EventsAndProperties(Properties, Events);    //  الزر 4
            btn06008001EventsAndProperties(Properties, Events); //  الزر 4-1
            btn06008002EventsAndProperties(Properties, Events); //  الزر 4-2
            btn06008003EventsAndProperties(Properties, Events); //  الزر 4-3
            btn06008004EventsAndProperties(Properties, Events); //  الزر 4-4
        }




        private void frmMainMenu06EventsAndProperties(bool Properties, bool Events = false) //  النموذج 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Form_.CustumProperties(this,ColorPropertyName.BackColor_2);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Form_.CustumProperties(this, ColorPropertyName.BackColor_2,true,true);
                tooltip();
            }
        }

        private void pnl06002EventsAndProperties(bool Properties, bool Events = false) // الحاوية 1
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl06002, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl06002, ColorPropertyName.BackColor_2,true,true);
            }
        }

        private void pnl06004EventsAndProperties(bool Properties, bool Events = false) // الحاوية 2
        {
            // الخصائص
            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl06004, ColorPropertyName.BackColor_2);
            }

            // الاحداث
            if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl06004, ColorPropertyName.BackColor_2,true,true);
            }
        }
        private void pnl06006EventsAndProperties(bool Properties, bool Events = false) // الحاوية 3
        {
            // الخصائص
            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl06006, ColorPropertyName.BackColor_2);
            }
            else  if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl06006, ColorPropertyName.BackColor_2,true,true);
            }
        }
        private void pnl06008EventsAndProperties(bool Properties, bool Events = false) // الحاوية 4
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl06008, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl06008, ColorPropertyName.BackColor_2,true,true);
            }
        }

        private void btn06001EventsAndProperties(bool Properties, bool Events = false) // الزر 1 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06001, "إدارة المخزون", ColorPropertyName.ForeColor_3);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06001, "إدارة المخزون",ColorPropertyName.ForeColor_3, true,true);

                btn06001.Click += delegate 
                {
                    if (pnl06002.Visible == true) { pnl06002.Visible = false; } else { pnl06002.Visible = true; }
                    //foreach (Control c in this.Controls)
                    //{
                    //    if (c.GetType().Name == "Panel") { c.Visible = false; }
                    //}
                };
            }
        }

        private void btn06002001EventsAndProperties(bool Properties, bool Events = false) // الزر 1-1 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06002001, "الشركات الصانعة", ColorPropertyName.ForeColor_4);
                toolTip1.SetToolTip(btn06002001, "Click This Button Then Click F1 For Update");  // تلميح
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06002001, "الشركات الصانعة",ColorPropertyName.ForeColor_4, true,true);
                toolTip1.SetToolTip(btn06002001, "Click This Button Then Click F1 For Update");  // تلميح


                btn06002001.Click += delegate 
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Manufacturers, PermissionType.Show))
                        {
                            if (GeneralVariables._frmManufacturers08 == null)
                            {
                                GeneralVariables._frmManufacturers08 = new frmManufacturers08();
                            }
                            GeneralAction.openForm(GeneralVariables._frmManufacturers08);
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMainMenu06 >>  btn06002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                };

                btn06002001.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    try
                    {
                        if (e.KeyData == Keys.F1)
                        {
                            if (Permissions.AccountHavePermission(PermissionObjectes.Manufacturers, PermissionType.Show))
                            {
                                if (GeneralVariables._frmManufacturers08 == null)
                                {
                                    GeneralVariables._frmManufacturers08 = new frmManufacturers08();
                                }
                                else
                                {
                                    GeneralVariables._frmManufacturers08 = null;
                                    GeneralVariables._frmManufacturers08 = new frmManufacturers08();
                                }
                                GeneralAction.openForm(GeneralVariables._frmManufacturers08);
                            }
                            else
                            {
                                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                                GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMainMenu06 >>  btn06002001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

            }
        }

        private void btn06002002EventsAndProperties(bool Properties, bool Events = false) // الزر 1-2 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06002002, "المنتجات", ColorPropertyName.ForeColor_4);
                toolTip1.SetToolTip(btn06002002, "Click This Button Then Click F1 For Update");  // تلميح

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06002002, "المنتجات", ColorPropertyName.ForeColor_4, true, true);
                toolTip1.SetToolTip(btn06002002, "Click This Button Then Click F1 For Update");  // تلميح


                btn06002002.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Products, PermissionType.Show))
                    {
                        if (GeneralVariables._frmProducts09 == null)
                        {

                            GeneralVariables._frmProducts09 = new frmProducts09();

                        }
                        GeneralAction.openForm(GeneralVariables._frmProducts09);
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002002EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }

                };

                btn06002002.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.F1)
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Products, PermissionType.Show))
                        {
                            if (GeneralVariables._frmProducts09 == null)
                            {
                                GeneralVariables._frmProducts09 = new frmProducts09();
                            }
                            else
                            {
                                GeneralVariables._frmProducts09 = null;
                                GeneralVariables._frmProducts09 = new frmProducts09();
                            }
                            GeneralAction.openForm(GeneralVariables._frmProducts09);
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                };

            }
        }

        private void btn06002003EventsAndProperties(bool Properties, bool Events = false) // الزر 1-3 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06002003, "التصنيفات" , ColorPropertyName.ForeColor_4);
                toolTip1.SetToolTip(btn06002003, "Click This Button Then Click F1 For Update");  // تلميح

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06002003, "التصنيفات", ColorPropertyName.ForeColor_4, true, true);
                toolTip1.SetToolTip(btn06002003, "Click This Button Then Click F1 For Update");  // تلميح


                btn06002003.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Categories, PermissionType.Show))
                    {
                        if (GeneralVariables._frmCategories10 == null)
                        {
                            GeneralVariables._frmCategories10 = new frmCategories10();
                        }

                        GeneralAction.openForm(GeneralVariables._frmCategories10);
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }

                };

                btn06002003.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.F1)
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Categories, PermissionType.Show))
                        {
                            if (GeneralVariables._frmCategories10 == null)
                            {
                                GeneralVariables._frmCategories10 = new frmCategories10();
                            }
                            else
                            {
                                GeneralVariables._frmCategories10 = null;
                                GeneralVariables._frmCategories10 = new frmCategories10();
                            }
                            GeneralAction.openForm(GeneralVariables._frmCategories10);
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                };

            }
        }

        private void btn06002004EventsAndProperties(bool Properties, bool Events = false) // الزر 1-4 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06002004, "وحدات القياس", ColorPropertyName.ForeColor_4);
                toolTip1.SetToolTip(btn06002004, "Click This Button Then Click F1 For Update");  // تلميح

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06002004, "وحدات القياس", ColorPropertyName.ForeColor_4, true, true);
                toolTip1.SetToolTip(btn06002004, "Click This Button Then Click F1 For Update");  // تلميح


                btn06002004.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Measurement_units, PermissionType.Show))
                    {
                        if (GeneralVariables._frmMeasureUnit12 == null)
                        {
                            GeneralVariables._frmMeasureUnit12 = new frmMeasureUnit12();
                        }

                        GeneralAction.openForm(GeneralVariables._frmMeasureUnit12);
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }

                };

                btn06002004.KeyDown += delegate (object sender, KeyEventArgs e)
                {

                    if (e.KeyData == Keys.F1)
                    {

                        if (Permissions.AccountHavePermission(PermissionObjectes.Measurement_units, PermissionType.Show))
                        {
                            if (GeneralVariables._frmMeasureUnit12 == null)
                            {
                                GeneralVariables._frmMeasureUnit12 = new frmMeasureUnit12();
                            }
                            else
                            {
                                GeneralVariables._frmMeasureUnit12 = null;
                                GeneralVariables._frmMeasureUnit12 = new frmMeasureUnit12();
                            }
                            GeneralAction.openForm(GeneralVariables._frmMeasureUnit12);
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                };

            }
        }

        private void btn06002005EventsAndProperties(bool Properties, bool Events = false) // الزر 1-5 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06002005, "وحدات التغليف", ColorPropertyName.ForeColor_4);
                toolTip1.SetToolTip(btn06002005, "Click This Button Then Click F1 For Update");  // تلميح

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06002005, "وحدات التغليف", ColorPropertyName.ForeColor_4, true, true);
                toolTip1.SetToolTip(btn06002005, "Click This Button Then Click F1 For Update");  // تلميح


                btn06002005.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Encapsulation_Units, PermissionType.Show))
                    {
                        if (GeneralVariables._frmEncapsulationUnits13 == null)
                        {
                            GeneralVariables._frmEncapsulationUnits13 = new frmEncapsulationUnits13();
                        }

                        GeneralAction.openForm(GeneralVariables._frmEncapsulationUnits13);
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002003EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }

                };

                btn06002005.KeyDown += delegate (object sender, KeyEventArgs e)
                {

                    if (e.KeyData == Keys.F1)
                    {

                        if (Permissions.AccountHavePermission(PermissionObjectes.Encapsulation_Units, PermissionType.Show))
                        {
                            if (GeneralVariables._frmEncapsulationUnits13 == null)
                            {
                                GeneralVariables._frmEncapsulationUnits13 = new frmEncapsulationUnits13();
                            }
                            else
                            {
                                GeneralVariables._frmEncapsulationUnits13 = null;
                                GeneralVariables._frmEncapsulationUnits13 = new frmEncapsulationUnits13();
                            }
                            GeneralAction.openForm(GeneralVariables._frmEncapsulationUnits13);
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                };

            }

        }

        private void btn06002006EventsAndProperties(bool Properties, bool Events = false) // الزر 1-6 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06002006, "جديد", ColorPropertyName.ForeColor_4);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06002006, "جديد", ColorPropertyName.ForeColor_4, true, true);
            }
        }

        private void btn06002007EventsAndProperties(bool Properties, bool Events = false) // الزر 1-7 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06002007, "جديد", ColorPropertyName.ForeColor_4);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06002007, "جديد", ColorPropertyName.ForeColor_4, true, true);
            }
        }


        private void btn06003EventsAndProperties(bool Properties, bool Events = false)    // الزر 2 // -------------------------------------------------------- SALSE AND BAU المبيعات والمشتريات 
        {

            if (Properties == true && Events == false)
            {

                ElementsTools.Button_.CustumProperties(btn06003, "المبيعات والمشتريات", ColorPropertyName.ForeColor_3);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06003, "المبيعات والمشتريات", ColorPropertyName.ForeColor_3, true, true);

                btn06003.Click += delegate
                {

                    //foreach (Control c in this.Controls)
                    //{
                    //    if (c.GetType().Name == "Panel") { c.Visible = false; }
                    //}
                    //pnl06004.Visible = true;
                    if (pnl06004.Visible == true) { pnl06004.Visible = false; } else { pnl06004.Visible = true; }

                    //----------------------------------------------------------
                };
            }
        }


        private void btn06004001EventsAndProperties(bool Properties, bool Events = false) // الزر 2-1 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06004001, "المبيعات والمشتريات", ColorPropertyName.ForeColor_4);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06004001, "المبيعات والمشتريات", ColorPropertyName.ForeColor_4, true, true);
            }
        }

        private void btn06004002EventsAndProperties(bool Properties, bool Events = false) // الزر 2-2 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06004002, "المبيعات والمشتريات", ColorPropertyName.ForeColor_4);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06004002, "المبيعات والمشتريات", ColorPropertyName.ForeColor_4, true, true);
            }
        }

        private void btn06004003EventsAndProperties(bool Properties, bool Events = false) // الزر 2-3 
        {

            if (Properties == true && Events == false)
            {

                ElementsTools.Button_.CustumProperties(btn06004003, "المبيعات والمشتريات", ColorPropertyName.ForeColor_4);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06004003, "المبيعات والمشتريات", ColorPropertyName.ForeColor_4, true, true);
            }
        }

        private void btn06004004EventsAndProperties(bool Properties, bool Events = false) // الزر 2-4 
        {

            if (Properties == true && Events == false)
            {

                ElementsTools.Button_.CustumProperties(btn06004004, "المبيعات والمشتريات", ColorPropertyName.ForeColor_4);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06004004, "المبيعات والمشتريات", ColorPropertyName.ForeColor_4, true, true);
            }
        }

        private void btn06005EventsAndProperties(bool Properties, bool Events = false)    // الزر 3 //----------------------------------------------------------  ACCOUNTING المحاسبة
        {

            if (Properties == true && Events == false)
            {

                ElementsTools.Button_.CustumProperties(btn06005, "المحاسبة", ColorPropertyName.ForeColor_3);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06005, "المحاسبة", ColorPropertyName.ForeColor_3, true, true);

                btn06005.Click += delegate
                {

                    //foreach (Control c in this.Controls)
                    //{
                    //    if (c.GetType().Name == "Panel") { c.Visible = false; }
                    //}
                    //pnl06006.Visible = true;
                    if (pnl06006.Visible == true) { pnl06006.Visible = false; } else { pnl06006.Visible = true; }

                    //----------------------------------------------------------
                };
            }
        }

        private void btn06006001EventsAndProperties(bool Properties, bool Events = false) // الزر 3-1 
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06006001, "الحسابات", ColorPropertyName.ForeColor_4);
                toolTip1.SetToolTip(btn06006001, "Click This Button Then Click F1 For Update");  // تلميح

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06006001, "الحسابات", ColorPropertyName.ForeColor_4, true, true);
                toolTip1.SetToolTip(btn06006001, "Click This Button Then Click F1 For Update");  // تلميح


                btn06006001.Click += delegate
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Accounting_Accounts, PermissionType.Show))
                    {
                        if (GeneralVariables._frmAccounts11 == null)
                        {
                            GeneralVariables._frmAccounts11 = new frmAccounts11();
                        }
                        GeneralAction.openForm(GeneralVariables._frmAccounts11);
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMainMenu06 >> btn06006001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }

                };

                btn06006001.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.F1)
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Accounting_Accounts, PermissionType.Show))
                        {
                            if (GeneralVariables._frmAccounts11 == null)
                            {
                                GeneralVariables._frmAccounts11 = new frmAccounts11();
                            }
                            else
                            {
                                GeneralVariables._frmAccounts11 = null;
                                GeneralVariables._frmAccounts11 = new frmAccounts11();
                            }
                            GeneralAction.openForm(GeneralVariables._frmAccounts11);
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                };

            }
        }

        private void btn06006002EventsAndProperties(bool Properties, bool Events = false) // الزر 3-2 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06006002, "المحاسبة", ColorPropertyName.ForeColor_4);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06006002, "المحاسبة", ColorPropertyName.ForeColor_4, true, true);
            }
        }

        private void btn06006003EventsAndProperties(bool Properties, bool Events = false) // الزر 3-3 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06006003, "المحاسبة", ColorPropertyName.ForeColor_4);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06006003, "المحاسبة", ColorPropertyName.ForeColor_4, true, true);
            }
        }

        private void btn06006004EventsAndProperties(bool Properties, bool Events = false) // الزر 3-4 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06006004, "المحاسبة", ColorPropertyName.ForeColor_4);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06006004, "المحاسبة", ColorPropertyName.ForeColor_4, true, true);
            }
        }

        private void btn06007EventsAndProperties(bool Properties, bool Events = false)   // الزر 4 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06007, "النظام", ColorPropertyName.ForeColor_3);
            }
            else if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn06007, "النظام", ColorPropertyName.ForeColor_3, true, true);

                // زر فتح القائمة واغلاق القوائم الاخرى
                btn06007.Click += delegate
                {

                    //foreach (Control c in this.Controls)
                    //{
                    //    if (c.GetType().Name == "Panel") { c.Visible = false; }
                    //}
                    //pnl06008.Visible = true;
                    if (pnl06008.Visible == true) { pnl06008.Visible = false; } else { pnl06008.Visible = true; }

                    //----------------------------------------------------------

                };
            }
        }

        private void btn06008001EventsAndProperties(bool Properties, bool Events = false) // الزر 4-1 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06008001, "حسابات المستخدمين", ColorPropertyName.ForeColor_4);
                toolTip1.SetToolTip(btn06008001, "Click This Button Then Click F1 For Update");  // تلميح

            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06008001, "حسابات المستخدمين", ColorPropertyName.ForeColor_4, true, true);
                toolTip1.SetToolTip(btn06008001, "Click This Button Then Click F1 For Update");  // تلميح

                
                btn06008001.Click += delegate 
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Users_Accounts , PermissionType.Show))
                    {
                        if (GeneralVariables._frmAccount05 == null)
                        {
                            GeneralVariables._frmAccount05 = new frmAccount05();
                        }
                        GeneralAction.openForm(GeneralVariables._frmAccount05);
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام") , MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }


                };


                btn06008001.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.F1)
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Users_Accounts, PermissionType.Show))
                        {
                            if (GeneralVariables._frmAccount05 == null)
                            {
                                GeneralVariables._frmAccount05 = new frmAccount05();
                            }
                            else
                            {
                                GeneralVariables._frmAccount05 = null;
                                GeneralVariables._frmAccount05 = new frmAccount05();
                            }
                            GeneralAction.openForm(GeneralVariables._frmAccount05);
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                };

            }
        }

        private void btn06008002EventsAndProperties(bool Properties, bool Events = false) // الزر 4-2 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06008002, "مجموعات الصلاحيات", ColorPropertyName.ForeColor_4);
                toolTip1.SetToolTip(btn06008002, "Click This Button Then Click F1 For Update");  // تلميح

            }
            else  if (Properties == true && Events == true)
            {

                ElementsTools.Button_.CustumProperties(btn06008002, "مجموعات الصلاحيات", ColorPropertyName.ForeColor_4, true, true);
                toolTip1.SetToolTip(btn06008002, "Click This Button Then Click F1 For Update");  // تلميح


                btn06008002.Click += delegate 
                {
                    if (Permissions.AccountHavePermission(PermissionObjectes.Manage_User_Group_Permissions , PermissionType.Show))
                    {
                        if (GeneralVariables._frmPermissionsGroup07 == null)
                        {
                            GeneralVariables._frmPermissionsGroup07 = new frmPermissionsGroup07();
                        }
                        GeneralAction.openForm(GeneralVariables._frmPermissionsGroup07);
                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }



                };

                btn06008002.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyData == Keys.F1)
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.Manage_User_Group_Permissions, PermissionType.Show))
                        {
                            if (GeneralVariables._frmPermissionsGroup07 == null)
                            {
                                GeneralVariables._frmPermissionsGroup07 = new frmPermissionsGroup07();
                            }
                            else
                            {
                                GeneralVariables._frmPermissionsGroup07 = null;
                                GeneralVariables._frmPermissionsGroup07 = new frmPermissionsGroup07();
                            }
                            GeneralAction.openForm(GeneralVariables._frmPermissionsGroup07);
                        }
                        else
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation( "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام"), MessageBoxStatus.Ok);
                            GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                        }
                    }
                };


            }
        }

        private void btn06008003EventsAndProperties(bool Properties, bool Events = false) // الزر 4-3 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06008003, "الالوان", ColorPropertyName.ForeColor_4);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06008003, "الالوان", ColorPropertyName.ForeColor_4, true, true);

                btn06008003.Click += delegate 
                {
                    
                    frmColors frm = new frmColors();
                    frm.Show();

                    Mesrakh.forms.frmTest frm2 = new Mesrakh.forms.frmTest();
                    frm2.Show();
                };
            }
        }

        private void btn06008004EventsAndProperties(bool Properties, bool Events = false) // الزر 4-4 
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Button_.CustumProperties(btn06008004, "النظام", ColorPropertyName.ForeColor_4);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Button_.CustumProperties(btn06008004, "النظام", ColorPropertyName.ForeColor_4, true, true);
            }
        }

        // اداة التلميح
        ToolTip toolTip1;
        private void tooltip()
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

                //toolTip1.SetToolTip(this.tv, Cultures.ReturnTranslation("إنتر للإضافة و + للتعديل و - للحذف"));  // تلميح

            }


        }
    }
}
