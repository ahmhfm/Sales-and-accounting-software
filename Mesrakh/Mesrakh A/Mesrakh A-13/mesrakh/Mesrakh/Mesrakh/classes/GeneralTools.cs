using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// 01  >>  General Tools 
/// </summary>
class GeneralTools
{
    // الالوان
    /// <summary>
    /// 01001  >> colors
    /// </summary>
    public class colors
    {
        // التدرج اللوني
        //https://yrefu.be/mHBfzgx3WwI?list=PLHIfW1KZRIfnbNoGB0NdoRdllq9fdo6uM&t=95
        // using System.Drawing.Drawing2D;
        /// <summary>
        /// 01001001   >>  Create Gradient Color
        /// </summary>
        /// <param name="StartPoint">Required : first color / Point Variable</param>
        /// <param name="LastPoint">Required : second color / Point Variable</param>
        /// <param name="StartColor">Required : first point / Color Variable</param>
        /// <param name="LastColor">Required : second point / Color Variable</param>
        /// <returns>LinearGradientBrush Variable from System.Drawing.Drawing2D;</returns>
        public static LinearGradientBrush GradientColor( Point StartPoint, Point LastPoint, Color StartColor, Color LastColor)
        {

            try
            {
                LinearGradientBrush gb = new LinearGradientBrush(StartPoint, LastPoint, StartColor, LastColor);
                return gb;
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools >> colors  >>  GradientColor ", DateTime.Now, "مشكلة عند رسم لون متدرج  ", ex.Message); //---------------------------

                return new LinearGradientBrush(new Point(0, 0), new Point(10, 10), Color.Red, Color.Blue);
            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
            LinearGradientBrush lgb = MyGeneralTools01.colors_01008.GradientColor_01008001(new Point(10, 0), new Point(110, 0) ,Color.Red, Color.Green) ;
            MyGeneralTools01.Drawing_01006.FillRectangle_01006007(this, lgb, 10, 10, 100, 100);
            }
            */
        }
    }



        // Date And Time / التاريخ والوقت
        /// <summary>
        /// 01002  >>  Date And Time
        /// </summary>
        public class DateAndTime
        {
        // تحويل التاريخ الميلادي الى هجري والعكس مع اعادة التاريخ على شكل نص و بالفورمات التي نحددها
        /// <summary>
        /// 01002001  >>  Convert The Date Variable To String With ( Different Calendar And Different Formats )
        /// </summary>
        /// <param name="DateAndTime">Required DateTime Variable</param>
        /// <param name="DateTimeFormat">Required a Date Time Format</param>
        /// <param name="CultureCode">Required a Culture Code</param>
        /// <returns> date as a string Variable</returns>
        public static string ConvertDateToStringWithDifferentCalendarAndDifferentFormats( DateTime DateAndTime, string DateTimeFormat, string CultureCode )
        {
            try
            {
                string dat;
                CultureInfo ci = new CultureInfo(CultureCode);
                dat = DateAndTime.ToString(DateTimeFormat, ci);

                return dat;
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >>  DateAndTime >> ConvertDateToStringWithDifferentCalendarAndDifferentFormats ", DateTime.Now, ex.Message, ex.Message);
                return null;
            }
            /* 
            private void button1_Click(object sender, EventArgs e)
            {
            DateTime dt = Convert.ToDateTime(textBox1.Text);
            textBox2.Text= MyGeneralTools01.DateAndTime_01002.ConvertDateToStringWithDifferentCalendarAndDifferentFormats_01002001(dt, textBox3.Text, "AR");
            } 
            */
        }

    }


    // الرياضيات
    /// <summary>
    /// 01003  >>  Math
    /// </summary>
    public class math
    {

        // التقريب للعدد الاقرب
        //https://yrefu.be/46RFr7nKpSE?list=PLHIfW1KZRIfnbNoGB0NdoRdllq9fdo6uM&t=498
        /// <summary>
        /// 01003001  >>  rounding to close number
        /// </summary>
        /// <param name="number">Required :The number we want to round / double Variable</param>
        /// <param name="UpDown">Optional :The Round Type we want / string Variable write up or down</param>
        /// <returns>double Variable</returns>
        public static double Rounding( double number, string UpDown = null)
        {

            try
            {
                double r = 0;
                if (UpDown is null)
                {
                    r = Math.Round(number);
                }
                else if (UpDown == "up")
                {
                    r = Math.Ceiling(number);
                }
                else if (UpDown == "down")
                {
                    r = Math.Floor(number);
                }

                return r;
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >> math >> Rounding ", DateTime.Now, ex.Message, ex.Message);

                return -100 ;
            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
            //double d =  MyGeneralTools01.Math_01007.Rounding_01007001(1.49);
            //double d = MyGeneralTools01.Math_01007.Rounding_01007001(1.99, "up");
            double d = MyGeneralTools01.Math_01007.Rounding_01007001(1.99,"down");
            textBox1.Text = d.ToString();
            }
            */
        }



        // الاسس
        //https://yrefu.be/46RFr7nKpSE?list=PLHIfW1KZRIfnbNoGB0NdoRdllq9fdo6uM&t=805
        /// <summary>
        /// 01003002  >>  number and power 
        /// </summary>
        /// <param name="number">Required :The number / double Variable</param>
        /// <param name="pow">Required :The power / double Variable</param>
        /// <returns>double Variable</returns>
        public static double power(  double number, double pow)
        {

            try
            {
                double r = 0;
                r = Math.Pow(number, pow);

                return r;
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >> math >>  power ", DateTime.Now, ex.Message, ex.Message);

                return -100 ;
            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
            double d = MyGeneralTools01.Math_01007.power_01007002(2,4);
            textBox1.Text = d.ToString();
            }
            */
        }

    }



    // FONT الخط
    /// <summary>
    /// 01004  >>  Fonts
    /// </summary>
    public class Fonts
    {
        // تغيير خط العنصر
        //https://www.yrefube.com/watch?v=o0JDiKCi1zc&list=PLHIfW1KZRIfnbNoGB0NdoRdllq9fdo6uM&index=81
        /// <summary>
        /// 01004001  >>  Change the font of the element
        /// </summary>
        /// <param name="control">Required : the element / Control Variable</param>
        /// <param name="FontName">Required : the Font Name / String Variable</param>
        /// <param name="FontSize">Required : the Font Size / Float Variable</param>
        /// <param name="FontStyleName">Required : the Font Style Name / FontStyle Variable</param>
        public static void ChangeFont( Control control, string FontName, float FontSize, FontStyle FontStyleName)
        {


            try
            {
                Font f = new Font(FontName, FontSize, FontStyleName);
                control.Font = f;
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools >> Fonts >> ChangeFont ", DateTime.Now, ex.Message, ex.Message);
                control.Font = new Font("arial", 14,FontStyle.Regular); 
            }  

            /* 
            private void button1_Click(object sender, EventArgs e)
            {
            MyGeneralTools01.TheFont_01005.ChangeFont_01005001(textBox1,"arial", 16, FontStyle.Bold);
            }
            */
        }


        // اعادة جميع الخطوط في مصفوفة
        //https://www.yrefube.com/watch?v=St2x0z0OAlw&list=PLHIfW1KZRIfnbNoGB0NdoRdllq9fdo6uM&index=84
        /// <summary>
        /// 01004002  >>  Return all fonts in a String Array 
        /// </summary>
        /// <returns>all fonts in a String[] Variable</returns>
        public static string[] ReturnAllFont()
        {

            try
            {
                FontFamily[] allFonts = FontFamily.Families;
                string[] fonts = new string[allFonts.Length];
                int x = 0;
                foreach (FontFamily ff in allFonts)
                {
                    fonts[x] = ff.Name;
                    x++;
                }
                return fonts;
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools >> Fonts >> ReturnAllFont ", DateTime.Now, ex.Message, ex.Message);
                return new string[]{ "arial" };  
            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
            comboBox1.Items.AddRange(MyGeneralTools01.Fonts_01005.ReturnAllFont_01005002());
            }
            */

        }

    }


    // الرسم
    /// <summary>
    /// 01005  >>  Drawing
    /// </summary>
    public class Drawing
    {

        // رسم خط على العنصر
        //https://www.yrefube.com/watch?v=Hcl0CPNQ3uU&list=PLHIfW1KZRIfnbNoGB0NdoRdllq9fdo6uM&index=86
        /// <summary>
        /// 01005001  >>  Draw Line On The element  
        /// </summary>
        /// <param name="TheControl">Required : the element / Control Variable</param>
        /// <param name="ThePen">Required : the pen colore and ... / Pen Variable</param>
        /// <param name="FerristPoint">Required : the Point number 1 / Point Variable</param>
        /// <param name="LastPoint">Required : the Point number 2 / Point Variable</param>
        public static void DrawLine( Control TheControl, Pen ThePen, Point FerristPoint, Point LastPoint)
        {

            try
            {
                TheControl.CreateGraphics().DrawLine(ThePen, FerristPoint, LastPoint);
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >> Drawing >> DrawLine ", DateTime.Now, ex.Message, ex.Message);
            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
            MyGeneralTools01.Drawing_01006.DrawLine_01006001(this, Pens.Red, new Point(10, 10), new Point(100, 100));
            }
            */
        }


        // مسح الرسمات الموجودة على العنصر
        //https://yrefu.be/Hcl0CPNQ3uU?list=PLHIfW1KZRIfnbNoGB0NdoRdllq9fdo6uM&t=732
        /// <summary>
        /// 01005002  >>  For Clear All Drawings 
        /// </summary>
        /// <param name="TheControl">Required : the element / Control Variable</param>
        /// <param name="TheColor">Required : the Clear Color / Color Variable</param>
        public static void DrawClear( Control TheControl, Color TheColor)
        {

            try
            {
                TheControl.CreateGraphics().Clear(TheColor);
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >> Drawing  >> DrawClear ", DateTime.Now, ex.Message, ex.Message);

            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
            MyGeneralTools01.Drawing_01006.DrawClear_01006002(this, Color.White);
            }
            */
        }


        // رسم خطوط مستقيمة متصلة ببعض
        //https://yrefu.be/4q673FpDpeY?list=PLHIfW1KZRIfnbNoGB0NdoRdllq9fdo6uM&t=320
        /// <summary>
        /// 01005003  >>  Draw a lot of Lines On The element  
        /// </summary>
        /// <param name="TheControl">Required : the element / Control Variable</param>
        /// <param name="ThePen">Required : the pen colore and ... / Pen Variable</param>
        /// <param name="PointsArray">Required : All Points in an Array / Point[] Variable</param>
        public static void DrawLines(  Control TheControl, Pen ThePen, Point[] PointsArray)
        {
 
            try
            {
                TheControl.CreateGraphics().DrawLines(ThePen, PointsArray);
  
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >> Drawing  >> DrawLines ", DateTime.Now, ex.Message, ex.Message);

            }
            /*
            private void button1_Click(object sender, EventArgs e)
            {
            MyGeneralTools01.Drawing_01006.DrawLine_01006003(this, Pens.Red,new Point[] { new Point(10, 10), new Point(10,100) ,new Point(100,100) });
            }
            */
        }


        // رسم مستطيل
        //https://yrefu.be/8lBQllI-Jzk?list=PLHIfW1KZRIfnbNoGB0NdoRdllq9fdo6uM&t=68
        /// <summary>
        /// 01005004  >>  Draw Rectangle On The element  
        /// </summary>
         /// <param name="TheControl">Required : the element / Control Variable</param>
        /// <param name="ThePen">Required : the pen colore and ... / Pen Variable</param>
        /// <param name="x">Required : Left / float Variable</param>
        /// <param name="y">Required : Top / float Variable</param>
        /// /// <param name="width">Required : Rectangle Width / float Variable</param>
        /// /// <param name="height">Required : Rectangle Hieght / float Variable</param>
        public static void DrawRectangle( Control TheControl, Pen ThePen, float x, float y, float width, float height)
        {
 

            try
            {
                TheControl.CreateGraphics().DrawRectangle(ThePen, x, y, width, height);
 
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >> Drawing  >> DrawRectangle ", DateTime.Now, ex.Message, ex.Message);

            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
            MyGeneralTools01.Drawing_01006.DrawRectangle_01006004(this, Pens.Red, 10, 10, 100, 50);
            }
            */
        }


        // رسم نص
        //https://www.yrefube.com/watch?v=fsGHOnwW0is&list=PLHIfW1KZRIfnbNoGB0NdoRdllq9fdo6uM&index=92
        /// <summary>
        /// 01005005  >>  Draw String on the element
        /// </summary>
        /// <param name="TheControl">Required : the element / Control Variable</param>
        /// <param name="TheBrush">Required : the Brush colore and ... / Brush Variable</param>
        /// <param name="text">Required : the string we need Drawing / string Variable</param>
        /// <param name="font">Required : the font we will use / Font Variable</param>
        /// <param name="thePoint">Required : the drow location / Point Variable</param>
        public static void DrawString(  Control TheControl, Brush TheBrush, string text, Font font, Point thePoint)
        {
 

            try
            {
                TheControl.CreateGraphics().DrawString(text, font, TheBrush, thePoint);
 
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >> Drawing  >> DrawString ", DateTime.Now, ex.Message, ex.Message);

            }
            /*
            private void button1_Click(object sender, EventArgs e)
            {
            // MyGeneralTools01.Drawing_01006.DrawString_01006005(this, Brushes.Red, "بسم الله", new Font("tahoma", 14, FontStyle.Regular), new Point(10, 10));
            }
            */
        }


        // رسم صورة
        //https://yrefu.be/iLw_JtVB9nI?list=PLHIfW1KZRIfnbNoGB0NdoRdllq9fdo6uM&t=36
        /// <summary>
        /// 01005006  >>  Draw image on the element
        /// </summary>
        /// <param name="TheControl">Required : the element / Control Variable</param>
        /// <param name="TheImage">Required : the image we will Drowing / Image Variable</param>
        /// <param name="x">Required : Left / float Variable</param>
        /// <param name="y">Required : Top / float Variable</param>
        /// /// <param name="width">Optional : Rectangle Width / float Variable</param>
        /// /// <param name="height">Optional : Rectangle Hieght / float Variable</param>
        public static void DrawImage(   Control TheControl, Image TheImage, float x, float y, float width = 0, float height = 0)
        {
 

            try
            {
                if (width == 0 || height == 0)
                {
                    TheControl.CreateGraphics().DrawImage(TheImage, x, y);
 
                }
                else
                {
                    TheControl.CreateGraphics().DrawImage(TheImage, x, y, width, height);
 
                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >> Drawing  >> DrawImage ", DateTime.Now, ex.Message, ex.Message);

            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
            Image i = Image.FromFile(@"C:\Users\user\Desktop\mbs.jpeg");
            //MyGeneralTools01.Drawing_01006.DrawImage_01006006(this, i, 10, 10);
            MyGeneralTools01.Drawing_01006.DrawImage_01006006(this, i, 10, 10, 200, 200);
            }
            */
        }


        // رسم مستطيل ملون بالكامل
        //https://yrefu.be/tQ2MGAcP25Y?list=PLHIfW1KZRIfnbNoGB0NdoRdllq9fdo6uM&t=175
        /// <summary>
        /// 01005007  >>  Fill Rectangle On The element by color 
        /// </summary>
        /// <param name="TheControl">Required : the element / Control Variable</param>
        /// <param name="TheBrush">Required : the Brush colore and ... / Brush Variable</param>
        /// <param name="x">Required : Left / float Variable</param>
        /// <param name="y">Required : Top / float Variable</param>
        /// /// <param name="width">Required : Rectangle Width / float Variable</param>
        /// /// <param name="height">Required : Rectangle Hieght / float Variable</param>
        public static void FillRectangle(Control TheControl, Brush TheBrush, float x, float y, float width, float height)
        {
            try
            {
                TheControl.CreateGraphics().FillRectangle(TheBrush, x, y, width, height);
            }
            catch (Exception ex)
            {

                GeneralAction.AddNewNotification("GeneralTools  >> Drawing  >> FillRectangle ", DateTime.Now, ex.Message, ex.Message);

            }




            /*
            private void button1_Click(object sender, EventArgs e)
            {
            MyGeneralTools01.Drawing_01006.FillRectangle_01006007(this, Brushes.Red, 10, 10, 100, 50);
            }
            */
        }

        // قياس حجم النص
        //https://yrefu.be/XVthY97uXvg?list=PLHIfW1KZRIfnbNoGB0NdoRdllq9fdo6uM&t=145
        /// <summary>
        /// Text Size Scale
        /// </summary>
         /// <param name="TheControl">Required : which contains the text / Control Variable</param>
        /// <param name="text">Required : The text we want to scale / string Variable</param>
        /// <param name="font">Required : The font of the text we want to scale / Font Variable</param>
        /// <returns>the size width and height at a float[] Variable</returns>
        public static float[] StringSize(  Control TheControl, string TheText, Font TheFont)
        {
 
            try
            {
                float[] f = new float[2];
                SizeF sf = TheControl.CreateGraphics().MeasureString(TheText, TheFont);
                f[0] = sf.Width;
                f[1] = sf.Height;
 
                return f;
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >> Drawing  >> StringSize ", DateTime.Now, ex.Message, ex.Message);
                return new float[] { -100};
            }


            /*

            private void button1_Click(object sender, EventArgs e)
            {
            Font f1 = new Font("tahoma", 14, FontStyle.Regular);
            string s1 = "بسم الله";
            MyGeneralTools01.Drawing_01006.DrawString_01006005(this, Brushes.Red, s1 , f1 , new Point(10, 10));
            float[] sizeOfstring = MyGeneralTools01.Drawing_01006.StringSize_01006008(this, s1, f1);
            textBox1.Text = sizeOfstring[0].ToString();
            textBox2.Text = sizeOfstring[1].ToString();
            }
            */
        }
        

        // مستطيل منحني الزوايا

        public static class RoundRect
        {
            private static GraphicsPath CreateRoundRect(int x, int y, int w, int h, int r)
            {

                try
                {
                    int r2 = r * 2;

                    GraphicsPath p = new GraphicsPath();
                    p.AddArc(x, y, r2, r2, 180, 90);
                    //p.AddLine(x + r, y, x + w - r, y);
                    p.AddArc(x + w - r2, y, r2, r2, 270, 90);
                    //p.AddLine(x + w, y + r, x + w, y + h - r);
                    p.AddArc(x + w - r2, y + h - r2, r2, r2, 0, 90);
                    //p.AddLine(x + r, y + h, x + w - r, y + h);
                    p.AddArc(x, y + h - r2, r2, r2, 90, 90);
                    p.CloseFigure();
                    return p;
                }
                catch (Exception ex)
                {

                    GeneralAction.AddNewNotification("GeneralTools  >> Drawing  >> RoundRect  >> CreateRoundRect ", DateTime.Now, ex.Message, ex.Message);
                    return null;
                }
            }

            public static void FillRoundRect(Form frm,Color color, int x = 10, int y = 10, int Rect = 20)
            {
                try
                {
                    SolidBrush brush = new SolidBrush(color);

                    Task.Run(() => { Thread.Sleep(50); }).ContinueWith((d) =>
                    {
                        GraphicsPath gfxPath = CreateRoundRect(x, y, frm.Width - (x * 2), frm.Height - (y * 2), Rect);
                        Region region = new Region(gfxPath);
                        frm.CreateGraphics().FillRegion(brush, region);
                    });
                }
                catch (Exception ex)
                {

                    GeneralAction.AddNewNotification("GeneralTools  >> Drawing  >> RoundRect  >> CreateRoundRect ", DateTime.Now, ex.Message, ex.Message);

                }

            }

            /*
            private void frmMessageBox_Load(object sender, EventArgs e)
            {
                GeneralTools.Drawing.RoundRect.FillRoundRect((Form)this,DisplayMode.ReturnColor(ElementType.Form, ColorPropertyName.BackColor_2)); // رسم مستطيل ذو زوايا منحنية
            }
            */
        }

    }







    // احداث الضغط على الازرار
    /// <summary>
    /// 01008  >>  Special Keys
    /// </summary>
    public class SpecialKeys
    {
        // عند الضغط على زر الانتر لعنصر على النموذج
        //https://yrefu.be/nIyErMsXPx0?list=PLHIfW1KZRIfl6UP-PlUli03pokSc4af2S&t=533
        /// <summary>
        /// 01008001  >>  When you press the Enter button for an element on the form
        /// </summary>
         /// <param name="control">Required : The Control  / Control Variable </param>
        /// <param name="MyE">Required : The KeyEventArgs /KeyEventArgs Variable </param>
        public static void PressEnter(  Control control, KeyEventArgs MyE)
        {
 

            try
            {
                if (MyE.KeyCode == Keys.Enter)
                {
                    //MessageBox.Show(control.Text);
 
                }
 
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >> SpecialKeys  >> PressEnter ", DateTime.Now, ex.Message, ex.Message);
            }

            /*
            private void textBox1_KeyDown(object sender, KeyEventArgs e)
            {
                MyGeneralTools01.SpecialKeys.PressEnter_01010001((Control)sender, e);
            }
            */
        }

        // عند الضغط على زر الحذف
        /// <summary>
        /// 01008002  >>  When you press the Delete button for an element on the form
        /// </summary>
         /// <param name="control">Required : The Control  / Control Variable </param>
        /// <param name="MyE">Required : The KeyEventArgs /KeyEventArgs Variable </param>
        public static void PressDelete(  Control control, KeyEventArgs MyE)
        {
 

            try
            {
                if (MyE.KeyCode == Keys.Delete)
                {
                    //MessageBox.Show("delte");
  
                }
 
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >> SpecialKeys  >> PressDelete ", DateTime.Now, ex.Message, ex.Message);

            }

            /*
            private void textBox1_KeyDown(object sender, KeyEventArgs e)
            {
                MyGeneralTools01.SpecialKeys_01010.PressDelete_01010002((Control)sender, e);
            }
            */
        }


        // عند الضغط على زر الحذف الخلفي
        /// <summary>
        /// 01008003  >>  When you press the BackSpace button for an element on the form
        /// </summary>
         /// <param name="control">Required : The Control  / Control Variable </param>
        /// <param name="MyE">Required : The KeyEventArgs /KeyEventArgs Variable </param>
        public static void PressBackSpace(  Control control, KeyEventArgs MyE)
        {
 

            try
            {
                if (MyE.KeyCode == Keys.Back)
                {
                    //MessageBox.Show("back");
  
                }
 
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >> SpecialKeys  >> PressBackSpace ", DateTime.Now, ex.Message, ex.Message);

            }


            /*
            private void textBox1_KeyDown(object sender, KeyEventArgs e)
            {
                MyGeneralTools01.SpecialKeys_01010.PressBackSpace_01010003((Control)sender, e);
            }
            */
        }


        // عند الضغط على زر اف واحد
        /// <summary>
        /// 01008004  >>  When you press the F1 button for an element on the form
        /// </summary>
         /// <param name="control">Required : The Control  / Control Variable </param>
        /// <param name="MyE">Required : The KeyEventArgs /KeyEventArgs Variable </param>
        public static void PressF1(  Control control, KeyEventArgs MyE)
        {
 

            try
            {
                if (MyE.KeyCode == Keys.F1)
                {
                    //MessageBox.Show("F1");

                }

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >> SpecialKeys  >> PressF1 ", DateTime.Now, ex.Message, ex.Message);

            }

            /*
            private void textBox1_KeyDown(object sender, KeyEventArgs e)
            {
                MyGeneralTools01.SpecialKeys_01010.PressF1_01010004((Control)sender, e);
            }
            */
        }
    }


    // كلاس تشغيل واغلاق البرامج
    /// <summary>
    /// 01009   >> Open Programs And Web prawsers
    /// </summary>
    public class OpenProgramsAndWeb
    {
        // فتح صفحة انترنت
        //https://yrefu.be/vKc5SE45dWo?list=PLHIfW1KZRIfl6UP-PlUli03pokSc4af2S&t=124
        /// <summary>
        /// 01009001  >>  Open WebSite by url
        /// </summary>
         /// <param name="Url">Required : website OR Program path / string Variable </param>
        public static void OpenWebSiteOrProgram(  string Url)
        {
 

            try
            {
                System.Diagnostics.Process.Start(Url);
 
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >> OpenProgramsAndWeb  >> OpenWebSiteOrProgram ", DateTime.Now, ex.Message, ex.Message);

            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
                MyGeneralTools01.OpenProgramsAndWeb_01011.OpenWebSiteOrProgram_01011001("www.facebook.com");
            }
            */
        }

    }




    // العمليات المتزامنه
    /// <summary>
    /// 01010  >>  Threadss
    /// </summary>
    public static class Threadss
    {
        //تنفيذ عملية متزامنه مع بقية العمليات باتخدام الثريد 
        //https://www.yrefube.com/watch?v=zHg6cKLaMzc
        //https://www.yrefube.com/watch?v=QEoxYFefN6o
        //https://www.yrefube.com/watch?v=OnL-IcYBl5c
        //https://www.yrefube.com/watch?v=QEoxYFefN6o
        /// <summary>
        /// 01010001  >>  Run the method synchronously by Thread
        /// </summary>
         /// <param name="method">The method we want to implement</param>
        public static void CreateNewThread(  Func<int> method)
        {
 

            try
            {
                Thread th = new Thread(delegate () { method(); });
                th.Start();
 
            }
            catch (Exception ex )
            {
                GeneralAction.AddNewNotification("GeneralTools  >> Threadss  >> CreateNewThread ", DateTime.Now, ex.Message, ex.Message);

            }
            /*
            public int myMethod()
            {
                MessageBox.Show("Test");
                return 5;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                MyGeneralTools01.Threads_01013.CreateNewThread_01013001(myMethod);
            }
            */

            // th.Join(); // تستخدم لايقاف التنفيذ حتى يتم اكمال تنفيذ المثود الموجودة في الثريد
        }

        // تنفيذ عملية متزامنه مع بقية العمليات باستخدام التاسك
        //https://www.yrefube.com/watch?v=zHg6cKLaMzc
        //https://www.yrefube.com/watch?v=QEoxYFefN6o
        //https://www.yrefube.com/watch?v=OnL-IcYBl5c
        //https://www.yrefube.com/watch?v=QEoxYFefN6o
        //https://yrefu.be/HadXHio_A8s?list=PLHIfW1KZRIflAus00vgdVEzLUBCx8ooH_&t=696
        //https://www.yrefube.com/watch?v=OkMotSO4eYA&list=PLHIfW1KZRIflAus00vgdVEzLUBCx8ooH_&index=187
        /// <summary>
        /// 01010002  >>  Run the method synchronously by Task
        /// </summary>
         /// <param name="method">The method we want to implement</param>
        public static void CreateNewTask(  Func<int> method)
        {
 

            try
            {
                Task t = new Task(delegate () { method(); });
                t.Start();
 
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("GeneralTools  >> Threadss  >> CreateNewTask ", DateTime.Now, ex.Message, ex.Message);

            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
                MyGeneralTools01.Threads_01013.CreateNewTask_01013002(myMethod);
            }
            */
            // t.Wait();  // تستخدم لايقاف التنفيذ حتى يتم اكمال تنفيذ المثود الموجودة في الثريد
            // تستخدم في اصدارات الدوت نيت بعد اصدار 4.0



            // تنفيذ عملية بعد تحميل النموذج 
            // Task.Run(() => { Thread.Sleep(50); }).ContinueWith((d) => { this.CreateGraphics().FillRectangle(Brushes.Red, 10, 10, 380 , 280); });
        }


        // تنفيذ عمليات في الخلفية
        /// <summary>
        /// 01010003  >>  Back gound 
        /// </summary>
        public static void WorkInBackgound()
        {
            MessageBox.Show("DataGridView dgv ; \n  dgv.Invoke((MethodInvoker)delegate() { your method ... });"); // شرح فقط لكيفية التنفيذ
        }


        // دالة تنتظر ومن ثم تنفذ دالة من الخلف
        //  Task.Run(() => Thread.Sleep(3000)).ContinueWith((d)=> GeneralVariables._frmManufacturers08.Invoke((MethodInvoker)delegate { Application.OpenForms["frmMain01"].Controls["pnl01003"].Controls[0].Controls[0].Top = 20; }));
        // او
        // Task.Run(() => Thread.Sleep(100)).ContinueWith((d) => Application.OpenForms["frmMain01"].Invoke((MethodInvoker)delegate { Application.OpenForms["frmMain01"].Controls["pnl01003"].Controls[0].Controls[0].Top = DisplayMode.ReturnTop(8); }));
        // الشرح
        // Task.Run(() => Thread.Sleep(---- الوقت ----- )).ContinueWith((d) => Application.OpenForms["frmMain01"].Invoke((MethodInvoker)delegate { ----- الدالة ------- }));


        // ايقاف لوب من خلال زر 
        /*
              int mouseDown = 0;
              btn01001009.MouseDown += delegate
              {

                          if (pnl01003.Controls.Count > 0)
                          {
                              Task.Run(delegate {
                              for (mouseDown = 0; mouseDown< 1000; mouseDown++)
                              {
                                  this.Invoke((MethodInvoker)delegate { pnl01003.Controls[0].Font = new Font(pnl01003.Controls[0].Font.Name, pnl01003.Controls[0].Font.Size + 1);  });
                                  Thread.Sleep(200);
                             }
                                          } );
                          }
                };

                btn01001009.MouseUp += delegate
                {
                   mouseDown = 1000;
                      if (pnl01003.Controls.Count > 0)
                      {
                              DisplayMode.ChangeFontAndLocation(pnl01003.Controls[0].Font.Name, pnl01003.Controls[0].Font.Size, this.pnl01003.Controls[0].Controls[0].Left, this.pnl01003.Controls[0].Controls[0].Top);
                      }
                };
         */




    }


    // عمليات على مستوى التطبيق
    /// <summary>
    /// 01011   >>   Application
    /// </summary>
    public class Application
    {
        // معرفة تفاصيل جميع الاضافات على البرنامج واصداراتها
        /// <summary>
        /// 01011001  >>  Details Of All Additions To The Program And Their Versions 
        /// </summary>
         /// <returns> String Array Have All Additions Details / string[] Variable</returns>
        public static string[] DetailsOfAllAdditionsToTheProgramAndTheirVersions( )
        {
 

            try
            {
                string[] AllVerisons = new string[AppDomain.CurrentDomain.GetAssemblies().Length];
                int x = 0;
                foreach (System.Reflection.Assembly MyVerison in AppDomain.CurrentDomain.GetAssemblies())
                {
                    AllVerisons[x] = MyVerison.ToString();
                    x++;
                }
 
                return AllVerisons;
            }
            catch (Exception ex )
            {
                GeneralAction.AddNewNotification("GeneralTools  >> Application  >> DetailsOfAllAdditionsToTheProgramAndTheirVersions ", DateTime.Now, ex.Message, ex.Message);

                return new string[] { ""};
            }



            ;
            /*
            private void button1_Click(object sender, EventArgs e)
            {
                string[] all = MyGeneralTools01.Application_01014.DetailsOfAllAdditionsToTheProgramAndTheirVersions_01014001();
                foreach (string s in all)
                {
                    MessageBox.Show(s);
                }
            }
            */
        }

        // نسخ ملف من الرسورسوز الى الكمبيوتر

    }


}



