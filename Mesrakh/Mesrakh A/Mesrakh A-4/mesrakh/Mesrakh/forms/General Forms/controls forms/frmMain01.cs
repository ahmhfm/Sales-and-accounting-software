using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mesrakh
{
    public partial class frmMain01 : Form
    {
        public frmMain01()
        {
            this.Icon = Images.convertBase64StringToIcon(Images.ImagesLibrary.imgAccount64Dark);  // ايقونة البرنامج
            InitializeComponent();
            AllEventsAndProperties(true, true); // الخصائص والاحداث لجميع العناصر
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  All Elements
        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frm01EventsAndProperties(Properties, Events);       // النموذج الرئيسي
            pnl01001EventsAndProperties(Properties, Events);    // الحاوية العلوية
            pnl01001001EventsAndProperties(Properties, Events); // اظهار واخفاء الحاوية العلوية
            btn01001002EventsAndProperties(Properties, Events); // اغلاق البرنامج
            btn01001003EventsAndProperties(Properties, Events); // تغيير حجم البرنامج
            btn01001004EventsAndProperties(Properties, Events); // اخفاء البرنامج
            btn01001005EventsAndProperties(Properties, Events); // اللغة
            btn01001006EventsAndProperties(Properties, Events); // نمط العرض
            btn01001007EventsAndProperties(Properties, Events); //  اظهار واخفاء الحاوية الجانبية 
            btn01001008EventsAndProperties(Properties, Events); //  الاشعارات
            btn01001009EventsAndProperties(Properties, Events); // تكبير
            btn01001010EventsAndProperties(Properties, Events); // تصغير
            btn01001011EventsAndProperties(Properties, Events); // تنزيل
            btn01001012EventsAndProperties(Properties, Events); // رفع
            btn01001013EventsAndProperties(Properties, Events); // يمين
            btn01001014EventsAndProperties(Properties, Events); // يسار

            cbx01001001EventsAndProperties(Properties, Events); // اسم الخط
            pic01001009EventsAndProperties(Properties, Events); // ايقونة البرنامج 
            pnl01002EventsAndProperties(Properties, Events);    // الحاوية الجانبية
            pnl01002001EventsAndProperties(Properties, Events); // اعلى حاوية بالحاوية الجانبية
            btn01002001001EventsAndProperties(Properties, Events); // فتح نافذة تسجيل الدخول
            btn01002001002EventsAndProperties(Properties, Events); // فتح نافذة اعدادات نص الاتصال
            btn01002001003EventsAndProperties(Properties, Events); // فتح نافذة القوائم الرئيسية
            pnl01002002EventsAndProperties(Properties, Events); // فاصل
            pnl01002003EventsAndProperties(Properties, Events); // حاوية العناصر الجانبية

            pnl01003EventsAndProperties(Properties, Events); // الحاوية الرئيسية
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  Elements one by one 
        
        private void frm01EventsAndProperties(bool Properties, bool Events = false)
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Form_.CustumProperties(this,ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Form_.CustumProperties(this, ColorPropertyName.BackColor_1,true,true);

                this.Load += delegate 
                {
                    try
                    {
                        frmLocationAndSize.AdjustLocationAndSize(this); // اعدادات الحجم والموقع  

                        foreach (FontFamily font in System.Drawing.FontFamily.Families) // تعبئة القائمة المنسدلة بأسماء الخطوط الموجودة في النظام
                        {
                            cbx01001001.Items.Add(font.Name);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  frm01EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                this.FormClosing += delegate
                {
                    Application.Exit(); // اذا استخدم زر اغلاق النموذج الموجود في شريط البروقريس بار
                };

                //this.KeyDown += delegate (object sender, KeyEventArgs e)
                //{
                //    if(e.KeyData == Keys.Enter)
                //    {
                //        btn01002001001.PerformClick();
                //    }
                //};
            }

        } // النموذج الرئيسي

        private void pnl01001EventsAndProperties(bool Properties, bool Events = false) // الحاوية العلوية
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl01001, ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl01001, ColorPropertyName.BackColor_1,true,true);
            }
        }

        private void pnl01001001EventsAndProperties(bool Properties, bool Events = false) // اظهار واخفاء الحاوية العلوية
        {


            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl01001001, ColorPropertyName.BackColor_1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl01001001, ColorPropertyName.BackColor_1,true,true);

                pnl01001001.Click += delegate
                {
                    try
                    {
                        if (pnl01001.Height == 50)
                        {
                            pnl01001.Height = 1;
                            pnl01001.BackColor = Color.Transparent;
                        }
                        else
                        {
                            pnl01001.Height = 50;
                            pnl01001.BackColor = DisplayMode.ReturnColor(myElementType.Panel, ColorPropertyName.BackColor_1);
                        }

                        GeneralAction.RefreshAllElementsProperties(); // تحديث خصائص العناصر المعروضة
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  pnl01001001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                };
            }
        }

        private void btn01001002EventsAndProperties(bool Properties, bool Events = false) // اغلاق البرنامج
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001002.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCloseBlue);
                    }
                    else
                    {
                        btn01001002.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCloseDark);
                    }
                    btn01001002.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {

                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001002.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCloseBlue);
                    }
                    else
                    {
                        btn01001002.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCloseDark);
                    }
                    btn01001002.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {

                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgClose = null;
                btn01001002.MouseMove += delegate
                {
                    try
                    {
                        if (imgClose == null)
                        {
                            imgClose = btn01001002.Image;
                            btn01001002.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgCloseRed);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
                btn01001002.MouseLeave += delegate
                {
                    try
                    {
                        btn01001002.Image = imgClose;
                        imgClose = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01001002.Click += delegate
                {
                    Application.Exit();
                };
            }

        }

        private void btn01001003EventsAndProperties(bool Properties, bool Events = false) // تغيير حجم البرنامج
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001003.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgSizeBlue);
                    }
                    else
                    {
                        btn01001003.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgSizeDark);
                    }
                    btn01001003.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001003EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001003.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgSizeBlue);
                    }
                    else
                    {
                        btn01001003.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgSizeDark);
                    }
                    btn01001003.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001003EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgSize = null;
                btn01001003.MouseMove += delegate
                {
                    try
                    {
                        if (imgSize == null)
                        {
                            imgSize = btn01001003.Image;
                            btn01001003.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgSizeRed);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001003EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
                btn01001003.MouseLeave += delegate
                {
                    try
                    {
                        btn01001003.Image = imgSize;
                        imgSize = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001003EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01001003.Click += delegate
                {
                    frmLocationAndSize.form(this);
                };
            }

        }

        private void btn01001004EventsAndProperties(bool Properties, bool Events = false) // إخفاء البرنامج
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001004.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgMinimizeBlue);
                    }
                    else
                    {
                        btn01001004.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgMinimizeDark);
                    }
                    btn01001004.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001004.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgMinimizeBlue);
                    }
                    else
                    {
                        btn01001004.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgMinimizeDark);
                    }
                    btn01001004.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgMinimize = null;
                btn01001004.MouseMove += delegate
                {
                    try
                    {
                        if (imgMinimize == null)
                        {
                            imgMinimize = btn01001004.Image;
                            btn01001004.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgMinimizeRed);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
                btn01001004.MouseLeave += delegate
                {
                    try
                    {
                        btn01001004.Image = imgMinimize;
                        imgMinimize = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001004EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01001004.Click += delegate
                {
                    this.WindowState = FormWindowState.Minimized;
                };
            }
        }

        private void btn01001005EventsAndProperties(bool Properties, bool Events = false) // تغيير اللغة
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001005.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLanguageBlue);
                    }
                    else
                    {
                        btn01001005.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLanguageDark);
                    }
                    btn01001005.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001005EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001005.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLanguageBlue);
                    }
                    else
                    {
                        btn01001005.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLanguageDark);
                    }
                    btn01001005.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001005EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgLanguage = null;
                btn01001005.MouseMove += delegate
                {
                    try
                    {
                        if (imgLanguage == null)
                        {
                            imgLanguage = btn01001005.Image;
                            btn01001005.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLanguageRed);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001005EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
                btn01001005.MouseLeave += delegate
                {
                    try
                    {
                        btn01001005.Image = imgLanguage;
                        imgLanguage = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001005EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01001005.Click += delegate
                {
                    try
                    {
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            GeneralVariables.cultureCode = "EN";

                            btn01001005.Image = imgLanguage;
                            imgLanguage = null;
                        }
                        else
                        {
                            GeneralVariables.cultureCode = "AR";

                            btn01001005.Image = imgLanguage;
                            imgLanguage = null;
                        }

                        //Cultures.cheangeCultuer(this, GeneralVariables.cultureCode);  // عكس مواقع الحقول  // تم الغائها لانها ثقيلة على الجهاز وتسبب مشاكل في الاكواد
                        GeneralAction.RefreshAllElementsProperties(); // تحديث خصائص العناصر المعروضة
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001005EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }

        private void btn01001006EventsAndProperties(bool Properties, bool Events = false) // نمط العرض
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001006.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDisplayModeBlue);

                    }
                    else
                    {
                        btn01001006.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDisplayModeDark);
                    }
                    btn01001006.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001006EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001006.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDisplayModeBlue);

                    }
                    else
                    {
                        btn01001006.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDisplayModeDark);
                    }
                    btn01001006.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001006EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgDisplayMode = null;
                btn01001006.MouseMove += delegate
                {
                    try
                    {
                        if (imgDisplayMode == null)
                        {
                            imgDisplayMode = btn01001006.Image;
                            btn01001006.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDisplayModeRed);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001006EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
                btn01001006.MouseLeave += delegate
                {
                    try
                    {
                        btn01001006.Image = imgDisplayMode;
                        imgDisplayMode = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001006EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01001006.Click += delegate
                {
                    try
                    {
                        if (GeneralVariables.DisplayMode == "Blue")
                        {
                            GeneralVariables.DisplayMode = "Dark";
                        }
                        else
                        {
                            GeneralVariables.DisplayMode = "Blue";
                        }

                        GeneralAction.RefreshAllElementsProperties(); // تحديث خصائص العناصر المعروضة
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001006EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                };
            }
        }

        private void btn01001007EventsAndProperties(bool Properties, bool Events = false) // اظهار واخفاء الحاوية الجانبية
        {


            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001007.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgimgSideContainerBlue);

                    }
                    else
                    {
                        btn01001007.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgimgSideContainerDark);
                    }
                    btn01001007.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001007EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001007.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgimgSideContainerBlue);

                    }
                    else
                    {
                        btn01001007.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgimgSideContainerDark);
                    }
                    btn01001007.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001007EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgSideContainer = null;
                btn01001007.MouseMove += delegate
                {
                    try
                    {
                        if (imgSideContainer == null)
                        {
                            imgSideContainer = btn01001007.Image;
                            btn01001007.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgimgSideContainerRed);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001007EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01001007.MouseLeave += delegate
                {
                    try
                    {
                        btn01001007.Image = imgSideContainer;
                        imgSideContainer = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001007EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01001007.Click += delegate
                {
                    try
                    {
                        int widthBefor = pnl01003.Width;

                        if (pnl01002.Width == 0)
                        {
                            pnl01002.Width = 247;
                        }
                        else
                        {
                            pnl01002.Width = 0;
                        }
                        int widthAfter = pnl01003.Width;

                        if (pnl01003.Controls.Count > 0)
                        {
                            if (pnl01003.Controls[0].Controls[0].GetType().Name == "Panel")
                            {
                                ((Panel)pnl01003.Controls[0].Controls[0]).Left += ((widthAfter - widthBefor) / 2);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001007EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }

        private void btn01001008EventsAndProperties(bool Properties, bool Events = false) // الاشعارات
        {


            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001008.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgNotificationsBlue);

                    }
                    else
                    {
                        btn01001008.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgNotificationsDark);
                    }
                    btn01001008.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001008EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }
                
            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001008.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgNotificationsBlue);

                    }
                    else
                    {
                        btn01001008.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgNotificationsDark);
                    }
                    btn01001008.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001008EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgNotifications = null;
                btn01001008.MouseMove += delegate
                {
                    try
                    {
                        if (imgNotifications == null)
                        {
                            imgNotifications = btn01001008.Image;
                            btn01001008.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgNotificationsOther);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001008EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01001008.MouseLeave += delegate
                {
                    try
                    {
                        btn01001008.Image = imgNotifications;
                        imgNotifications = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001008EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01001008.Click += delegate
                {
                    try
                    {
                        GeneralVariables._frmNotifications = null;
                        pnl01003.Controls.Clear();
                        GeneralVariables._frmNotifications = new frmNotifications() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                        GeneralVariables._frmNotifications.Name = "frmNotifications";
                        GeneralVariables._frmNotifications.FormBorderStyle = FormBorderStyle.None;
                        pnl01003.Controls.Add(GeneralVariables._frmNotifications);
                        GeneralVariables._frmNotifications.Show();

                        GeneralAction.RefreshAllElementsProperties();// تحديث خصائص العناصر
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001008EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                };
            }
        }


        private void btn01001009EventsAndProperties(bool Properties, bool Events = false) // تكبير
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001009.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgZoomInBlue);

                    }
                    else
                    {
                        btn01001009.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgZoomInDark);
                    }
                    btn01001009.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001009EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001009.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgZoomInBlue);

                    }
                    else
                    {
                        btn01001009.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgZoomInDark);
                    }
                    btn01001009.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001009EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgzoomin = null;
                btn01001009.MouseMove += delegate
                {
                    try
                    {
                        if (imgzoomin == null)
                        {
                            imgzoomin = btn01001009.Image;
                            btn01001009.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgZoomInOther);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001009EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01001009.MouseLeave += delegate
                {
                    try
                    {
                        btn01001009.Image = imgzoomin;
                        imgzoomin = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001009EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                // الدالة الاولى التي تنفذ اثناء الغضط على الزر ويجب ان تعيد رقم
                Func<int> f1 = delegate 
                {
                    try
                    {
                        if (pnl01003.Controls.Count > 0)
                        {
                            pnl01003.Controls[0].Font = new Font(pnl01003.Controls[0].Font.Name, pnl01003.Controls[0].Font.Size + 1);
                        }
                        Thread.Sleep(200);
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001009EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        return 0;
                    }

                };

                // الدالة الثانية التي تنفذ بعد رفع الضغط عن الزر ويجب ان تعيد رقم
                Func<int> f2 = delegate
                {
                    try
                    {
                        if (pnl01003.Controls.Count > 0)
                        {
                            DisplayMode.ChangeFontAndLocation(pnl01003.Controls[0].Font.Name, pnl01003.Controls[0].Font.Size, this.pnl01003.Controls[0].Controls[0].Left, this.pnl01003.Controls[0].Controls[0].Top);
                        }
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001009EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        return 0;
                    }

                };

                // دالة العمل اثناء الضغط على الزر
                GeneralAction.loopOfFanction(btn01001009,200, f1, f2);

            }
        }

        private void btn01001010EventsAndProperties(bool Properties, bool Events = false) // تصغير
        {


            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001010.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgZoomOutBlue);

                    }
                    else
                    {
                        btn01001010.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgZoomOutDark);
                    }
                    btn01001010.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001010EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001010.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgZoomOutBlue);

                    }
                    else
                    {
                        btn01001010.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgZoomOutDark);
                    }
                    btn01001010.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001010EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgzoomout = null;
                btn01001010.MouseMove += delegate
                {
                    try
                    {
                        if (imgzoomout == null)
                        {
                            imgzoomout = btn01001010.Image;
                            btn01001010.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgZoomOutOther);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001010EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01001010.MouseLeave += delegate
                {
                    try
                    {
                        btn01001010.Image = imgzoomout;
                        imgzoomout = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001010EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };


                // الدالة الاولى التي تنفذ اثناء الغضط على الزر ويجب ان تعيد رقم
                Func<int> f1 = delegate
                {
                    try
                    {
                        if (pnl01003.Controls.Count > 0)
                        {
                            pnl01003.Controls[0].Font = new Font(pnl01003.Controls[0].Font.Name, pnl01003.Controls[0].Font.Size - 1);
                        }
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001010EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        return 0;
                    }

                };

                // الدالة الثانية التي تنفذ بعد رفع الضغط عن الزر ويجب ان تعيد رقم
                Func<int> f2 = delegate
                {
                    try
                    {
                        if (pnl01003.Controls.Count > 0)
                        {
                            DisplayMode.ChangeFontAndLocation(pnl01003.Controls[0].Font.Name, pnl01003.Controls[0].Font.Size, this.pnl01003.Controls[0].Controls[0].Left, this.pnl01003.Controls[0].Controls[0].Top);
                        }
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001010EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        return 0;
                    }

                };

                // دالة العمل اثناء الضغط على الزر
                GeneralAction.loopOfFanction(btn01001010,200, f1, f2);
            }
        }

        private void btn01001011EventsAndProperties(bool Properties, bool Events = false) // تنزيل
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001011.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDownBlue);

                    }
                    else
                    {
                        btn01001011.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDownDark);
                    }
                    btn01001011.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001011EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001011.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDownBlue);

                    }
                    else
                    {
                        btn01001011.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDownDark);
                    }
                    btn01001011.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001011EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgzoomout = null;
                btn01001011.MouseMove += delegate
                {
                    try
                    {
                        if (imgzoomout == null)
                        {
                            imgzoomout = btn01001011.Image;
                            btn01001011.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgDownOther);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001011EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01001011.MouseLeave += delegate
                {
                    try
                    {
                        btn01001011.Image = imgzoomout;
                        imgzoomout = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001011EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                // الدالة الاولى التي تنفذ اثناء الغضط على الزر ويجب ان تعيد رقم
                Func<int> f1 = delegate
                {
                    try
                    {
                        if (pnl01003.Controls.Count > 0)
                        {
                            this.pnl01003.Controls[0].Controls[0].Top = this.pnl01003.Controls[0].Controls[0].Top + 1;
                        }
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001011EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        return 0;
                    }

                };

                // الدالة الثانية التي تنفذ بعد رفع الضغط عن الزر ويجب ان تعيد رقم
                Func<int> f2 = delegate
                {
                    try
                    {
                        if (pnl01003.Controls.Count > 0)
                        {
                            DisplayMode.ChangeFontAndLocation(pnl01003.Controls[0].Font.Name, pnl01003.Controls[0].Font.Size, this.pnl01003.Controls[0].Controls[0].Left, this.pnl01003.Controls[0].Controls[0].Top);
                        }
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001011EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        return 0;
                    }

                };

                // دالة العمل اثناء الضغط على الزر
                GeneralAction.loopOfFanction(btn01001011,1, f1, f2);

            }
        }
        
        private void btn01001012EventsAndProperties(bool Properties, bool Events = false) // رفع
        {
            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001012.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgUpBlue);

                    }
                    else
                    {
                        btn01001012.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgUpDark);
                    }
                    btn01001012.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001012EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001012.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgUpBlue);

                    }
                    else
                    {
                        btn01001012.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgUpDark);
                    }
                    btn01001012.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001012EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgzoomout = null;
                btn01001012.MouseMove += delegate
                {
                    try
                    {
                        if (imgzoomout == null)
                        {
                            imgzoomout = btn01001012.Image;
                            btn01001012.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgUpOther);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001012EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01001012.MouseLeave += delegate
                {
                    try
                    {
                        btn01001012.Image = imgzoomout;
                        imgzoomout = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001012EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };


                // الدالة الاولى التي تنفذ اثناء الغضط على الزر ويجب ان تعيد رقم
                Func<int> f1 = delegate
                {
                    try
                    {
                        if (pnl01003.Controls.Count > 0)
                        {
                            this.pnl01003.Controls[0].Controls[0].Top = this.pnl01003.Controls[0].Controls[0].Top - 1;
                        }
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001012EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        return 0;
                    }

                };

                // الدالة الثانية التي تنفذ بعد رفع الضغط عن الزر ويجب ان تعيد رقم
                Func<int> f2 = delegate
                {
                    try
                    {
                        if (pnl01003.Controls.Count > 0)
                        {
                            DisplayMode.ChangeFontAndLocation(pnl01003.Controls[0].Font.Name, pnl01003.Controls[0].Font.Size, this.pnl01003.Controls[0].Controls[0].Left, this.pnl01003.Controls[0].Controls[0].Top);
                        }
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001012EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        return 0;
                    }

                };

                // دالة العمل اثناء الضغط على الزر
                GeneralAction.loopOfFanction(btn01001012,1, f1, f2);
            }
        }

        private void btn01001013EventsAndProperties(bool Properties, bool Events = false) // يمين
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001013.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgRightBlue);

                    }
                    else
                    {
                        btn01001013.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgRightDark);
                    }
                    btn01001013.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001013EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001013.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgRightBlue);

                    }
                    else
                    {
                        btn01001013.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgRightDark);
                    }
                    btn01001013.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001013EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image img = null;
                btn01001013.MouseMove += delegate
                {
                    try
                    {
                        if (img == null)
                        {
                            img = btn01001013.Image;
                            btn01001013.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgRightOther);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001013EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01001013.MouseLeave += delegate
                {
                    try
                    {
                        btn01001013.Image = img;
                        img = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001013EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };


                // الدالة الاولى التي تنفذ اثناء الغضط على الزر ويجب ان تعيد رقم
                Func<int> f1 = delegate
                {
                    try
                    {
                        if (pnl01003.Controls.Count > 0)
                        {
                            if (GeneralVariables.cultureCode == "AR")
                            {
                                this.pnl01003.Controls[0].Controls[0].Left = this.pnl01003.Controls[0].Controls[0].Left - 1;
                            }
                            else
                            {
                                this.pnl01003.Controls[0].Controls[0].Left = this.pnl01003.Controls[0].Controls[0].Left + 1;

                            }
                        }
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001013EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        return 0;
                    }

                };

                // الدالة الثانية التي تنفذ بعد رفع الضغط عن الزر ويجب ان تعيد رقم
                Func<int> f2 = delegate
                {
                    try
                    {
                        if (pnl01003.Controls.Count > 0)
                        {
                            DisplayMode.ChangeFontAndLocation(pnl01003.Controls[0].Font.Name, pnl01003.Controls[0].Font.Size, this.pnl01003.Controls[0].Controls[0].Left, this.pnl01003.Controls[0].Controls[0].Top);
                        }
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001013EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        return 0;
                    }

                };

                // دالة العمل اثناء الضغط على الزر
                GeneralAction.loopOfFanction(btn01001013,1, f1, f2);
            }
        }


        private void btn01001014EventsAndProperties(bool Properties, bool Events = false) // يسار
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001014.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLeftBlue);

                    }
                    else
                    {
                        btn01001014.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLeftDark);
                    }
                    btn01001014.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001014EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01001014.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLeftBlue);

                    }
                    else
                    {
                        btn01001014.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLeftDark);
                    }
                    btn01001014.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01001014EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image img = null;
                btn01001014.MouseMove += delegate
                {
                    try
                    {
                        if (img == null)
                        {
                            img = btn01001014.Image;
                            btn01001014.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLeftOther);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001014EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01001014.MouseLeave += delegate
                {
                    try
                    {
                        btn01001014.Image = img;
                        img = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001014EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };



                // الدالة الاولى التي تنفذ اثناء الغضط على الزر ويجب ان تعيد رقم
                Func<int> f1 = delegate
                {
                    try
                    {
                        if (pnl01003.Controls.Count > 0)
                        {
                            if (GeneralVariables.cultureCode == "AR")
                            {
                                this.pnl01003.Controls[0].Controls[0].Left = this.pnl01003.Controls[0].Controls[0].Left + 1;
                            }
                            else
                            {
                                this.pnl01003.Controls[0].Controls[0].Left = this.pnl01003.Controls[0].Controls[0].Left - 1;
                            }
                        }
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001014EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        return 0;
                    }

                };

                // الدالة الثانية التي تنفذ بعد رفع الضغط عن الزر ويجب ان تعيد رقم
                Func<int> f2 = delegate
                {
                    try
                    {
                        if (pnl01003.Controls.Count > 0)
                        {
                            DisplayMode.ChangeFontAndLocation(pnl01003.Controls[0].Font.Name, pnl01003.Controls[0].Font.Size, this.pnl01003.Controls[0].Controls[0].Left, this.pnl01003.Controls[0].Controls[0].Top);
                        }
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01001014EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                        return 0;
                    }

                };

                // دالة العمل اثناء الضغط على الزر
                GeneralAction.loopOfFanction(btn01001014,1, f1, f2);
            }
        }


        private void cbx01001001EventsAndProperties(bool Properties, bool Events = false) // اسماء الخطوط 
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    cbx01001001.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_1);
                    cbx01001001.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_1);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  cbx01001001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    cbx01001001.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_1);
                    cbx01001001.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_1);
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  cbx01001001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }


                cbx01001001.SelectedValueChanged += delegate
                {
                    try
                    {
                        if (this.pnl01003.Controls.Count > 0)
                        {
                            Font f = new Font(cbx01001001.Text, this.Font.Size, this.Font.Style);
                            this.pnl01003.Controls[0].Font = f;
                            DisplayMode.ChangeFontAndLocation(pnl01003.Controls[0].Font.Name, pnl01003.Controls[0].Font.Size, this.pnl01003.Controls[0].Controls[0].Left, this.pnl01003.Controls[0].Controls[0].Top);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  cbx01001001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }


        private void pic01001009EventsAndProperties(bool Properties, bool Events = false) // ايقونة البرنامج
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        pic01001009.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAccount32Blue);
                    }
                    else
                    {
                        pic01001009.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAccount32Dark);
                    }
                    pic01001009.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  pic01001009EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        pic01001009.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAccount32Blue);
                    }
                    else
                    {
                        pic01001009.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAccount32Dark);
                    }
                    pic01001009.BorderStyle = BorderStyle.None;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  pic01001009EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
        }

        private void pnl01002EventsAndProperties(bool Properties, bool Events = false) // الحاوية الجانبية    
        {
            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl01002, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl01002, ColorPropertyName.BackColor_2,true,true);
            }

        }

        private void pnl01002001EventsAndProperties(bool Properties, bool Events = false) // اعلى حاوية بالحاوية الجانبية
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl01002001, ColorPropertyName.BackColor_2);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl01002001, ColorPropertyName.BackColor_2,true,true);
            }
        }
        
        private void btn01002001001EventsAndProperties(bool Properties, bool Events = false) // فتح نافذة تسجيل الدخول
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01002001001.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLoginBordBlue);
                    }
                    else
                    {
                        btn01002001001.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLoginBordDark);
                    }
                    btn01002001001.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01002001001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01002001001.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLoginBordBlue);
                    }
                    else
                    {
                        btn01002001001.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLoginBordDark);
                    }
                    btn01002001001.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01002001001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgEnter = null;
                btn01002001001.MouseMove += delegate
                {
                    try
                    {
                        if (imgEnter == null)
                        {
                            imgEnter = btn01002001001.Image;
                            btn01002001001.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgLoginBordOther);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01002001001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
                btn01002001001.MouseLeave += delegate
                {
                    try
                    {
                        btn01002001001.Image = imgEnter;
                        imgEnter = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01002001001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01002001001.Click += delegate
                {
                    try
                    {
                        if (GeneralVariables._frmLogin03 is null)
                        {
                            if (pnl01002003.Controls.Count > 0) pnl01002003.Controls.Clear();
                            GeneralVariables._frmLogin03 = new frmLogin03() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                            GeneralVariables._frmLogin03.Name = "frm03";
                            GeneralVariables._frmLogin03.FormBorderStyle = FormBorderStyle.None;
                            pnl01002003.Controls.Add(GeneralVariables._frmLogin03);
                            GeneralVariables._frmLogin03.Show();
                        }
                        else
                        {
                            if(pnl01002003.Controls.Count>0) pnl01002003.Controls.Clear();
                            pnl01002003.Controls.Add(GeneralVariables._frmLogin03);
                            GeneralVariables._frmLogin03.Show();
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01002001001EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }



                };


            }



        }

        private void btn01002001002EventsAndProperties(bool Properties, bool Events = false) // فتح نافذة اعدادات نص الاتصال
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01002001002.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgConnectionBlue);
                    }
                    else
                    {
                        btn01002001002.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgConnectionDark);
                    }
                    btn01002001002.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01002001002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01002001002.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgConnectionBlue);
                    }
                    else
                    {
                        btn01002001002.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgConnectionDark);
                    }
                    btn01002001002.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01002001002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgConnectionSettings = null;
                btn01002001002.MouseMove += delegate
                {
                    try
                    {
                        if (imgConnectionSettings == null)
                        {
                            imgConnectionSettings = btn01002001002.Image;
                            btn01002001002.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgConnectionOther);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01002001002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
                btn01002001002.MouseLeave += delegate
                {
                    try
                    {
                        btn01002001002.Image = imgConnectionSettings;
                        imgConnectionSettings = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01002001002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01002001002.Click += delegate
                {
                    try
                    {
                        if (Permissions.AccountHavePermission(PermissionObjectes.DataBases_Connections, PermissionType.Show))
                        {
                            pnl01002003.Controls.Clear();

                            if (GeneralVariables._frmConnectionSettings is null)
                            {
                                GeneralVariables._frmConnectionSettings = new frmConnectionSettings02() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                                GeneralVariables._frmConnectionSettings.Name = "frm02";
                                GeneralVariables._frmConnectionSettings.FormBorderStyle = FormBorderStyle.None;
                                pnl01002003.Controls.Add(GeneralVariables._frmConnectionSettings);
                                GeneralVariables._frmConnectionSettings.Show();
                            }
                            else
                            {
                                pnl01002003.Controls.Add(GeneralVariables._frmConnectionSettings);
                                GeneralVariables._frmConnectionSettings.Show();
                            }
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
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01002001002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }


                };
            }
        }

        private void btn01002001003EventsAndProperties(bool Properties, bool Events = false) // فتح نافذة القوائم الرئيسية
        {

            if (Properties == true && Events == false)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01002001003.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgMainMenusBlue);
                    }
                    else
                    {
                        btn01002001003.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgMainMenusDark);
                    }
                    btn01002001003.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01002001002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

            }
            else if (Properties == true && Events == true)
            {
                try
                {
                    if (GeneralVariables.DisplayMode == "Blue")
                    {
                        btn01002001003.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgMainMenusBlue);
                    }
                    else
                    {
                        btn01002001003.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgMainMenusDark);
                    }
                    btn01002001003.FlatAppearance.BorderSize = 0;
                }
                catch (Exception ex)
                {
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("frmMain01 >>  btn01002001002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                }

                Image imgConnectionSettings = null;
                btn01002001003.MouseMove += delegate
                {
                    try
                    {
                        if (imgConnectionSettings == null)
                        {
                            imgConnectionSettings = btn01002001003.Image;
                            btn01002001003.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgMainMenusOther);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01002001002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
                btn01002001003.MouseLeave += delegate
                {
                    try
                    {
                        btn01002001003.Image = imgConnectionSettings;
                        imgConnectionSettings = null;
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01002001002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };

                btn01002001003.Click += delegate
                {
                    try
                    {
                        pnl01002003.Controls.Clear();

                        if (GeneralVariables._frmMainMenu06 is null)
                        {
                            GeneralVariables._frmMainMenu06 = new frmMainMenu06() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                            GeneralVariables._frmMainMenu06.Name = "_frmMainMenu06";
                            GeneralVariables._frmMainMenu06.FormBorderStyle = FormBorderStyle.None;
                            pnl01002003.Controls.Add(GeneralVariables._frmMainMenu06);
                            GeneralVariables._frmMainMenu06.Show();
                        }
                        else
                        {
                            pnl01002003.Controls.Add(GeneralVariables._frmMainMenu06);
                            GeneralVariables._frmMainMenu06.Show();
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMain01 >>  btn01002001002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
                    }

                };
            }
        }

        private void pnl01002002EventsAndProperties(bool Properties, bool Events = false) // فاصل 
        {
            try
            {
                if (Properties == true && Events == false)
                {
                    ElementsTools.panel_.CustumProperties(pnl01002002);
                }
                else if (Properties == true && Events == true)
                {
                    ElementsTools.panel_.CustumProperties(pnl01002002, ColorPropertyName.BackColor_3, true, true);

                }
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmMain01 >>  pnl01002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
            }

        }

        private void pnl01002003EventsAndProperties(bool Properties, bool Events = false) // حاوية العناصر الجانبية 
        {
            try
            {
                if (Properties == true && Events == false)
                {
                    ElementsTools.panel_.CustumProperties(pnl01002003, ColorPropertyName.BackColor_2);
                }
                else if (Properties == true && Events == true)
                {
                    ElementsTools.panel_.CustumProperties(pnl01002003, ColorPropertyName.BackColor_2, true, true);
                }
            }
            catch (Exception ex)
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmMain01 >>  pnl01002002EventsAndProperties ", DateTime.Now, ex.Message, ex.Message);
            }

        }

        private void pnl01003EventsAndProperties(bool Properties, bool Events = false) // الحاوية الرئيسية
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.panel_.CustumProperties(pnl01003, ColorPropertyName.BackColor_3);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(pnl01003, ColorPropertyName.BackColor_3,true,true);
                //pnl01003.ControlAdded += delegate
                //{

                //};
            }
        }
    }
}
