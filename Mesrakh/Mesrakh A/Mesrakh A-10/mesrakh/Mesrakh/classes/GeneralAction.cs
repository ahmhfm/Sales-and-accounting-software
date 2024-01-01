using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 10  >> General Action 
/// </summary>
public class GeneralAction
{



    // اعادة تخصيص الخصائص 
    public static void RefreshAllElementsProperties()
    {

        if (GeneralVariables._frmMain01 != null) { GeneralVariables._frmMain01.AllEventsAndProperties(true); } // تحديث خصائص عناصر النموذج الرئيسي
        if (GeneralVariables._frmConnectionSettings != null) { GeneralVariables._frmConnectionSettings.AllEventsAndProperties(true); } // تحديث خصائص جميع عناصر نموذج نص الاتصال
        if (GeneralVariables._frmLogin03 != null) { GeneralVariables._frmLogin03.AllEventsAndProperties(true); } // تحديث خصائص جميع عناصر نموذج الدخول
        if (GeneralVariables._frmNotifications != null) { GeneralVariables._frmNotifications.AllEventsAndProperties(true); } // تحديث خصائص نموذج الاشعارات
        if (GeneralVariables._frmAccount05 != null) { GeneralVariables._frmAccount05.AllEventsAndProperties(true); } // تحديث خصائص نموذج حسابات المستخدمين
        if (GeneralVariables._frmMainMenu06 != null) { GeneralVariables._frmMainMenu06.AllEventsAndProperties(true); } // تحديث خصائص نموذج القائمة الرئيسية
        if (GeneralVariables._frmManufacturers08 != null) { GeneralVariables._frmManufacturers08.AllEventsAndProperties(true); } // تحديث خصائص نموذج الشركات الصانعة
        if (GeneralVariables._frmPermissionsGroup07 != null) { GeneralVariables._frmPermissionsGroup07.AllEventsAndProperties(true); } // تحديث خصائص نموذج مجموعات الصلاحيات
        if (GeneralVariables._frmProductsAndServices09 != null) { GeneralVariables._frmProductsAndServices09.AllEventsAndProperties(true); } // تحديث خصائص نموذج السلع والخدمات
        if (GeneralVariables._frmCategories10 != null) { GeneralVariables._frmCategories10.AllEventsAndProperties(true); } // تحديث خصائص نموذج التصنيفات
        if (GeneralVariables._frmAccounts11 != null) { GeneralVariables._frmAccounts11.AllEventsAndProperties(true); } // تحديث خصائص نموذج الحسابات المحاسبية
        if (GeneralVariables._frmMeasureUnit12 != null) { GeneralVariables._frmMeasureUnit12.AllEventsAndProperties(true); } // تحديث خصائص نموذج وحدات القياس
        if (GeneralVariables._frmEncapsulationUnits13 != null) { GeneralVariables._frmEncapsulationUnits13.AllEventsAndProperties(true); } // تحديث خصائص نموذج وحدات القياس
        if (GeneralVariables.frmproductAndServicesDetails14 != null) { GeneralVariables.frmproductAndServicesDetails14.AllEventsAndProperties(true); } // تحديث خصائص نموذج تفاصيل السلع والخدمات  
        if (GeneralVariables._frmEnterprise15 != null) { GeneralVariables._frmEnterprise15.AllEventsAndProperties(true); } // تحديث خصائص نموذج المنشآت  
        if (GeneralVariables._frmEnterpriseBranches16 != null) { GeneralVariables._frmEnterpriseBranches16.AllEventsAndProperties(true); } // تحديث خصائص نموذج فروع المنشآت  
        if (GeneralVariables._frmCountries17 != null) { GeneralVariables._frmCountries17.AllEventsAndProperties(true); } // تحديث خصائص نموذج الدول  
        if (GeneralVariables._frmEmployees18 != null) { GeneralVariables._frmEmployees18.AllEventsAndProperties(true); } // تحديث خصائص نموذج الموظفين  
        if (GeneralVariables._frmClients19 != null) { GeneralVariables._frmClients19.AllEventsAndProperties(true); } // تحديث خصائص نموذج العملاء  
        if (GeneralVariables._frmJournalEntry20 != null) { GeneralVariables._frmJournalEntry20.AllEventsAndProperties(true); } // تحديث خصائص نموذج قيود اليومية  
        if (GeneralVariables._frmShifts21 != null) { GeneralVariables._frmShifts21.AllEventsAndProperties(true); } // تحديث خصائص نموذج الورديات  
        if (GeneralVariables._frmOperationUnits22 != null) { GeneralVariables._frmOperationUnits22.AllEventsAndProperties(true); } // تحديث خصائص نموذج وحدات العمليات  



    }


    // فتح النماذج
    public static void openForm(Form form)
    {
        try
        {
            if(form != null)
            {
                GeneralVariables._frmMain01.pnl01003.Controls.Clear();

                form.Dock = DockStyle.Fill;
                form.TopLevel = false;
                form.TopMost = true;

                form.FormBorderStyle = FormBorderStyle.None;
                GeneralVariables._frmMain01.Controls["pnl01003"].Controls.Add(form);


                // تحديد الخط والموقع في حال لم تكن اول مرة يفتح فيها النموذج
                if (!(DisplayMode.ReturnFont(form.Name).Size == 5) || !(DisplayMode.ReturnLocation(form.Name) == new System.Drawing.Point(1000, 1000)))
                {
                    form.Invoke((MethodInvoker)delegate
                    {
                        form.Font = DisplayMode.ReturnFont(form.Name);
                        form.Controls[0].Location = DisplayMode.ReturnLocation(form.Name);
                    });
                }

                form.Show();

                // في حال كانت اول مرة يفتح فيها النموذج يتم حفظ الخط والموقع الافتراضي
                if (DisplayMode.ReturnFont(form.Name).Size == 5 || DisplayMode.ReturnLocation(form.Name) == new System.Drawing.Point(1000, 1000))
                {
                    DisplayMode.ChangeFontAndLocation("Microsoft JhengHei", 12, (form.Width - form.Controls[0].Width) / 2, (form.Height - form.Controls[0].Height) / 2);
                    form.Font = DisplayMode.ReturnFont(form.Name);
                    form.Controls[0].Location = DisplayMode.ReturnLocation(form.Name);
                }
            }
        }
        catch (Exception ex)
        {
            GeneralAction.AddNewNotification("GeneralAction  >> openForm", DateTime.Now, ex.Message, ex.Message);
        }


        // تم ايقاف الانعكاس عند تغيير اللغة
        //// اذا تم فتح النموذج واللغة ليست عربي
        //if (GeneralVariables.cultureCode != "AR")
        //{
        //    Cultures.cheangeCultuer(form, GeneralVariables.cultureCode);
        //}


    }


    //تنفيذ اجراء بشكل متكرر اثناء الضغط على الزر والتوقف بعد توقف الضغط على الزر  
    public static void loopOfFanction(Control control, int sleep, Func<int> MethodinsideLoop, Func<int> MethodafterLoop)
    {
        try
        {
            int mouseDown = 0;
            //int xx = 0;
            control.MouseDown += delegate
            {

                if (mouseDown == 0) // لنتجنب تعليق الزر بعد الضغط مرتين على الزر
                {
                    Task.Run(delegate
                    {
                        for (mouseDown = 0; mouseDown < 1000000; mouseDown++)
                        {
                            control.Invoke((MethodInvoker)delegate { MethodinsideLoop(); });
                            if (sleep > 0)
                            {
                                Thread.Sleep(sleep);
                            }
                        }

                        mouseDown = 0;
                    });
                }
                else
                {
                    mouseDown = 0;
                }

            };

            control.MouseUp += delegate
            {

                mouseDown = 1000000;
                MethodafterLoop();
            };

        }
        catch (Exception ex)
        {

            GeneralAction.AddNewNotification("GeneralAction  >> loopOfFanction", DateTime.Now, ex.Message, ex.Message);
        }
       

        /*
            // الدالة الاولى التي تنفذ اثناء الغضط على الزر ويجب ان تعيد رقم
            Func<int> f1 = delegate 
            {
                if (pnl01003.Controls.Count > 0)
                {
                    pnl01003.Controls[0].Font = new Font(pnl01003.Controls[0].Font.Name, pnl01003.Controls[0].Font.Size + 1);
                }
                Thread.Sleep(200);
                return 0;
            };

            // الدالة الثانية التي تنفذ بعد رفع الضغط عن الزر ويجب ان تعيد رقم
            Func<int> f2 = delegate
            {
                if (pnl01003.Controls.Count > 0)
                {
                    DisplayMode.ChangeFontAndLocation(pnl01003.Controls[0].Font.Name, pnl01003.Controls[0].Font.Size, this.pnl01003.Controls[0].Controls[0].Left, this.pnl01003.Controls[0].Controls[0].Top);
                }
                return 0;
            };

            // دالة العمل اثناء الضغط على الزر
            GeneralAction.loopOfFanction(btn01001009, f1, f2);
         */

    }




    // جدول الاشعارات 
    public static DataTable Notifications = new DataTable(); //08002 // اشعارات الاخطاء


    // اضافة اشعار 
    /// <summary>
    /// 08003 >> add Error Notification 
    /// </summary>
    /// <param name="ErrorLocation"></param>
    /// <param name="ErrorDateTime"></param>
    /// <param name="ErrorMessage"></param>
    /// <param name="ErrorMessageEnglish"></param>
    public static void AddNewNotification(string Location, DateTime DateTime, string ErrorMessage, string ErrorAutomaticMessage, string CommandString = null, string Parameters = null) //08003
    {
        try
        {
            //MessageBox.Show(ErrorAutomaticMessage);
            if (Notifications.Columns.Count == 0)
            {
                Notifications.Columns.Add("Location", typeof(string));
                Notifications.Columns.Add("DateTime", typeof(DateTime));
                Notifications.Columns.Add("Message", typeof(string));
                Notifications.Columns.Add("Automatic Message", typeof(string));
                Notifications.Columns.Add("CommandString", typeof(string));
                Notifications.Columns.Add("parameters", typeof(string));
            }

            DataRow datarow = Notifications.NewRow();
            datarow[0] = Location;
            datarow[1] = DateTime;
            datarow[2] = ErrorMessage;
            datarow[3] = ErrorAutomaticMessage;
            datarow[4] = CommandString;
            datarow[5] = Parameters;

            Notifications.Rows.Add(datarow);
        }
        catch (Exception ex)
        {
            GeneralAction.AddNewNotification("GeneralAction  >> AddNewNotification", DateTime.Now, ex.Message, ex.Message);

        }

    }


}

