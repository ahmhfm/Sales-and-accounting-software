using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public enum MessageBoxStatus { Ok, YesAndNo, Text }

public partial class frmMessageBox : Form
{
    static MessageBoxStatus messageBoxState;
    static bool Round = false;
    static string MessageTitle = "";
    static string MessageText = "";


    public frmMessageBox()
    {
        GeneralVariables.frmMessageIsOpen = true;
        InitializeComponent();
        AllEventsAndProperties(true, true); // الخصائص والاحداث
        //Cultures.cheangeCultuer(this, GeneralVariables.cultureCode); // اللغة
    }

    public static void ShowMessageBox(string _MessageTitle, string _MessageText, MessageBoxStatus _messageBoxState, bool _Round = false)
    {
        messageBoxState = _messageBoxState;
        Round = _Round;
        MessageTitle = _MessageTitle;
        MessageText = _MessageText;

        GeneralVariables._frmMessageBox = new frmMessageBox();
        GeneralVariables._frmMessageBox.ShowDialog();
    }

    public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
    {
        frmMessageBoxEventsAndProperties(Properties, Events); //  النموذج
        pnlMainEventsAndProperties(Properties, Events); //  الحاوية الرئيسية
        pnl01EventsAndProperties(Properties, Events); // حاوية العنوان
        lbl0101EventsAndProperties(Properties, Events); // ملصق العنوان
        pnl02EventsAndProperties(Properties, Events); // حاوية الرسالة
        lbl0201EventsAndProperties(Properties, Events); // ملصق الرسالة
        pnl03EventsAndProperties(Properties, Events); // حاوية نعم ولا
        btn0301EventsAndProperties(Properties, Events); // زر نعم 
        btn0302EventsAndProperties(Properties, Events); // زر لا 
        pnl04EventsAndProperties(Properties, Events); // حاوية موافق
        btn0401EventsAndProperties(Properties, Events); // زر موافق
        pnl05EventsAndProperties(Properties, Events); // حاوية مربع النص
        btn0501EventsAndProperties(Properties, Events); // زر استلام القيمة في مربع النص
    }

    private void frmMessageBoxEventsAndProperties(bool Properties, bool Events = false) //   النموذج 
    {
        // الخصائص
        if (Properties)
        {
            this.BackColor = Color.Yellow;
        }

        // الاحداث
        if (Events)
        {
            this.Load += delegate
            {
                if (messageBoxState == MessageBoxStatus.YesAndNo)
                {
                    pnl03.Visible = true;
                    pnl04.Visible = false;
                    pnl05.Visible = false;
                }
                else if(messageBoxState == MessageBoxStatus.Ok)
                {
                    pnl03.Visible = false;
                    pnl04.Visible = true;
                    pnl05.Visible = false;
                }
                else if(messageBoxState == MessageBoxStatus.Text)
                {
                    pnl03.Visible = false;
                    pnl04.Visible = false;
                    pnl05.Visible = true;
                }

                if (Round)
                {
                    GeneralTools.Drawing.RoundRect.FillRoundRect((Form)this, DisplayMode.ReturnColor(myElementType.Form, ColorPropertyName.BackColor_2)); // رسم مستطيل ذو زوايا منحنية
                }


            };
        }
    }

    private void pnlMainEventsAndProperties(bool Properties, bool Events = false) // الحاوية الرئيسية 
    {
        // الخصائص
        if (Properties)
        {
            pnlMain.BackColor = DisplayMode.ReturnColor(myElementType.Form, ColorPropertyName.BackColor_2);
        }

        // الاحداث
        if (Events)
        {

        }
    }

    private void pnl01EventsAndProperties(bool Properties, bool Events = false) //  حاوية العنوان
    {
        // الخصائص
        if (Properties)
        {
            pnl01.BackColor = DisplayMode.ReturnColor(myElementType.Form, ColorPropertyName.BackColor_2);
        }

        // الاحداث
        if (Events)
        {

        }
    }

    private void lbl0101EventsAndProperties(bool Properties, bool Events = false) // عنوان الرسالة 
    {
        // الخصائص
        if (Properties)
        {
            lbl0101.ForeColor = DisplayMode.ReturnColor(myElementType.Button, ColorPropertyName.ForeColor_2); 
            lbl0101.Text = MessageTitle;
        }

        // الاحداث
        if (Events)
        {

        }
    }

    private void pnl02EventsAndProperties(bool Properties, bool Events = false) //  حاوية الرسالة
    {
        // الخصائص
        if (Properties)
        {
            pnl02.BackColor = DisplayMode.ReturnColor(myElementType.Form, ColorPropertyName.BackColor_2);
        }

        // الاحداث
        if (Events)
        {

        }
    }

    private void lbl0201EventsAndProperties(bool Properties, bool Events = false) // عنوان الرسالة 
    {
        // الخصائص
        if (Properties)
        {
            lbl0201.ForeColor = DisplayMode.ReturnColor(myElementType.Button, ColorPropertyName.ForeColor_2);
            lbl0201.Text = MessageText;
        }

        // الاحداث
        if (Events)
        {

        }
    }

    private void pnl03EventsAndProperties(bool Properties, bool Events = false) // حاوية نعم ولا  
    {
        // الخصائص
        if (Properties)
        {
            pnl03.BackColor = DisplayMode.ReturnColor(myElementType.Form, ColorPropertyName.BackColor_2);
        }

        // الاحداث
        if (Events)
        {

        }
    }

    private void btn0301EventsAndProperties(bool Properties, bool Events = false) // زر نعم
    {
        // الخصائص
        if (Properties)
        {
            btn0301.ForeColor = DisplayMode.ReturnColor(myElementType.Button, ColorPropertyName.ForeColor_2);
            btn0301.Text = Cultures.ReturnTranslation("لا");

        }
       
        // الاحداث
        if (Events)
        {
            Color clr = Color.Yellow;
            btn0301.MouseMove += delegate
            {
                if (clr == Color.Yellow)
                {
                    clr = btn0301.ForeColor;
                    btn0301.ForeColor = DisplayMode.ReturnColor(myElementType.Button, ColorPropertyName.ForeColor_2); 
                }
            };
            btn0301.MouseLeave += delegate
            {
                btn0301.ForeColor = clr;
                clr = Color.Yellow;
            };

            btn0301.Click += delegate
            {
                GeneralVariables.MessageBoxResult = "No";
                GeneralVariables.frmMessageIsOpen = false;
                this.Close();
            };
        }
    }

    private void btn0302EventsAndProperties(bool Properties, bool Events = false) // زر لا
    {
        // الخصائص
        if (Properties)
        {
            btn0302.ForeColor = DisplayMode.ReturnColor(myElementType.Button, ColorPropertyName.ForeColor_2);
            btn0302.Text = Cultures.ReturnTranslation("نعم");
        }

        // الاحداث
        if (Events)
        {
            Color clr = Color.Yellow;
            btn0302.MouseMove += delegate
            {
                if (clr == Color.Yellow)
                {
                    clr = btn0302.ForeColor;
                    btn0302.ForeColor = DisplayMode.ReturnColor(myElementType.Button, ColorPropertyName.ForeColor_2);
                }
            };
            btn0302.MouseLeave += delegate
            {
                btn0302.ForeColor = clr;
                clr = Color.Yellow;
            };

            btn0302.Click += delegate
            {
                GeneralVariables.MessageBoxResult = "Yes";
                GeneralVariables.frmMessageIsOpen = false;
                this.Close();
            };
        }
    }

    private void pnl04EventsAndProperties(bool Properties, bool Events = false) //  حاوية موافق  
    {
        // الخصائص
        if (Properties)
        {
            pnl04.BackColor = DisplayMode.ReturnColor(myElementType.Form, ColorPropertyName.BackColor_2);
        }

        // الاحداث
        if (Events)
        {

        }
    }

    private void btn0401EventsAndProperties(bool Properties, bool Events = false) // زر موافق
    {
        // الخصائص
        if (Properties)
        {
            btn0401.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
            btn0401.Text = Cultures.ReturnTranslation("موافق");
        }

        // الاحداث
        if (Events)
        {
            Color clr = Color.Yellow;
            btn0401.MouseMove += delegate
            {
                if (clr == Color.Yellow)
                {
                    clr = btn0401.ForeColor;
                    btn0401.ForeColor = DisplayMode.ReturnColor(myElementType.Button, ColorPropertyName.ForeColor_2);
                }
            };
            btn0401.MouseLeave += delegate
            {
                btn0401.ForeColor = clr;
                clr = Color.Yellow;
            };

            btn0401.Click += delegate
            {
                GeneralVariables.MessageBoxResult = "Ok";
                GeneralVariables.frmMessageIsOpen = false;
                this.Close();
            };
        }
    }

    private void pnl05EventsAndProperties(bool Properties, bool Events = false) //  حاوية النص  
    {
        // الخصائص
        if (Properties)
        {
            pnl05.BackColor = DisplayMode.ReturnColor(myElementType.Form, ColorPropertyName.BackColor_2);
        }

        // الاحداث
        if (Events)
        {

        }
    }

    private void btn0501EventsAndProperties(bool Properties, bool Events = false) // زر موافق
    {
        // الخصائص
        if (Properties)
        {
            btn0502.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
            btn0502.Text = Cultures.ReturnTranslation("موافق");
        }

        // الاحداث
        if (Events)
        {
            Color clr = Color.Yellow;
            btn0502.MouseMove += delegate
            {
                if (clr == Color.Yellow)
                {
                    clr = btn0502.ForeColor;
                    btn0502.ForeColor = DisplayMode.ReturnColor(myElementType.Button, ColorPropertyName.ForeColor_2);
                }
            };
            btn0502.MouseLeave += delegate
            {
                btn0502.ForeColor = clr;
                clr = Color.Yellow;
            };

            btn0502.Click += delegate
            {
                GeneralVariables.MessageBoxResult = txt0501.Text;
                GeneralVariables.frmMessageIsOpen = false;
                this.Close();
            };
        }
    }


    /*
       frmMessageBox.ShowMessageBox("استلام معلومات الهوايات", "رجاء قم بكتابة جميع هواياتك",MessageBoxStatus.Text,true);
       MessageBox.Show(GeneralVariables.MessageBoxResult);
    */

}


