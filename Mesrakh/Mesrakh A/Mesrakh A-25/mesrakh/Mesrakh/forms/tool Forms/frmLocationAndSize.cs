using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mesrakh.Properties;

class frmLocationAndSize : Form
{

    // متغيرات يجب تسجيلها في البروبرتي 
    /*
    write four Variables in properties : 
    1 form_Width  int
    2 form_Height  int
    3 form_left  int
    4 form_top  int 
    */


    /*
    private void Form1_Load(object sender, EventArgs e)
    {
        // ضبط اعدادات الموقع والحجم بناء على الاعدادات المخزنة
        frmLocationAndSize.AdjustLocationAndSize((Form)sender);
    }

    private void btnFormSize_Click(object sender, EventArgs e)
    {
        // تغيير اعدادات الموقع والحجم
        frmLocationAndSize.form(this);
    }
    */



    //-------------------------------------------------------------------------------

    // ضبط اعدادات الحجم والموقع
    // التاكد من حجم النموذج قبل عرضه فإن كان 0 يتم تكبيره
    public static void AdjustLocationAndSize(Form sender)
    {
        // التاكد من حجم النموذج قبل عرضه فإن كان 0 يتم تكبيره
        if (frmLocationAndSize.getSize()[0] == 0 || frmLocationAndSize.getSize()[1] == 0)
        {
            chingeSize(700, 400);
            chingeLocation(0, 0);

            sender.Size = new Size(700, 400);
            sender.Location = new Point(0, 0);
        }
        else
        {
            sender.Size = new Size(frmLocationAndSize.getSize()[0], frmLocationAndSize.getSize()[1]);
            sender.Location = new Point(frmLocationAndSize.getLocation()[0], frmLocationAndSize.getLocation()[1]);
        }

    }

    //----------------------------------------------------------------------------------

    // تغيير قيم الطول والعرض للنموذج في الخصائص
    public static void chingeSize(int width, int height)
    {
        Settings.Default["form_Width"] = width;
        Settings.Default["form_Height"] = height;
        Settings.Default.Save();
    }


    // تغيير قيم موقع النموذج في الخصائص
    public static void chingeLocation(int left, int top)
    {
        Settings.Default["form_left"] = left;
        Settings.Default["form_top"] = top;
        Settings.Default.Save();
    }

    // الحصول على قيم الطول العرض للنموذج
    public static int[] getSize()
    {
        int[] size = new int[2];
        size[0] = int.Parse(Settings.Default["form_Width"].ToString());
        size[1] = int.Parse(Settings.Default["form_Height"].ToString());
        return size;
    }

    // الحصول على موقع النموذج
    public static int[] getLocation()
    {
        int[] size = new int[2];
        size[0] = int.Parse(Settings.Default["form_left"].ToString());
        size[1] = int.Parse(Settings.Default["form_top"].ToString());
        return size;
    }


    //---------------------------------------------------------------------------------------
    // تغيير الحجم والموقع
    public static void form(Form form)
    {


        Form frm = new Form();
        frm.FormBorderStyle = FormBorderStyle.None;
        frm.BackColor = Color.FromArgb(1, 174, 243);
        frm.Name = "aaa";

        //-------------------------------------------
        Button btn = new Button();
        btn.BackColor = Color.FromArgb(254, 168, 133);
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.Location = new Point(0, 0);
        btn.Dock = DockStyle.Top;
        btn.Text = "Save Size And Location";
        btn.Click += delegate
        {
            chingeSize(frm.Width, frm.Height);
            chingeLocation(frm.Left, frm.Top);

            // تحديث موقع البرنامج وحجمه
            // حل مشكلة مواقع العناصر عند تغيير الحجم باللغة الانجليزية
            //if (GeneralVariables.cultureCode != "AR")
            //{
            //    frmLocationAndSize.AdjustLocationAndSize(form); // اعدادات الحجم والموقع

            //    GeneralAction.RefreshAllElementsProperties(); // تحديث خصائص العناصر المعروضة

            //    form.Controls["pnl01001"].Controls["btn01001002"].Left = 9;
            //    form.Controls["pnl01001"].Controls["btn01001003"].Left = 50;
            //    form.Controls["pnl01001"].Controls["btn01001004"].Left = 92;
            //    form.Controls["pnl01001"].Controls["btn01001005"].Left = 136;
            //    form.Controls["pnl01001"].Controls["btn01001006"].Left = 178;
            //    form.Controls["pnl01001"].Controls["btn01001007"].Left = 217;
            //    form.Controls["pnl01001"].Controls["btn01001008"].Left = 253;
            //    form.Controls["pnl01001"].Controls["btn01001009"].Left = 289;
            //    form.Controls["pnl01001"].Controls["btn01001010"].Left = 325;
            //    form.Controls["pnl01001"].Controls["btn01001011"].Left = 361;
            //    form.Controls["pnl01001"].Controls["btn01001012"].Left = 397;

            //    form.Controls["pnl01001"].Controls["pic01001009"].Left = form.Controls["pnl01001"].Width-50;

            //}
            //else
            //{
            //    frmLocationAndSize.AdjustLocationAndSize(form); // اعدادات الحجم والموقع
            //    GeneralAction.RefreshAllElementsProperties(); // تحديث خصائص العناصر المعروضة
            //}

            frmLocationAndSize.AdjustLocationAndSize(form); // اعدادات الحجم والموقع
            GeneralAction.RefreshAllElementsProperties(); // تحديث خصائص العناصر المعروضة


            if (Application.OpenForms["aaa"] != null)
            {
                Application.OpenForms["aaa"].Close(); // هذا النموذج
            }
        };

        //-------------------------------------------
        Button btn1 = new Button();
        btn1.Width = 30;
        btn1.Height = 30;
        btn1.BackColor = Color.FromArgb(100, 236, 254);
        btn1.FlatStyle = FlatStyle.Flat;
        btn1.FlatAppearance.BorderSize = 0;
        btn1.Text = "←";
        btn1.Click += delegate
        {
            frm.Left = frm.Left - 1;
        };

        //-------------------------------------------
        Button btn2 = new Button();
        btn2.Width = 30;
        btn2.Height = 30;
        btn2.BackColor = Color.FromArgb(100, 236, 254);
        btn2.FlatStyle = FlatStyle.Flat;
        btn2.FlatAppearance.BorderSize = 0;
        btn2.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
        btn2.Text = "→";
        btn2.Click += delegate
        {
            frm.Left = frm.Left + 1;
        };
        //-------------------------------------------
        int topOf_9_1_2_3_4 = btn.Height + 30;
        int leftOf_9_5_6_7_8 = 30;
        //-------------------------------------------
        Button btn9 = new Button();
        btn9.Width = leftOf_9_5_6_7_8 + 28;
        btn9.Height = topOf_9_1_2_3_4 - btn.Height + 28;
        btn9.BackColor = Color.FromArgb(208, 208, 208);
        btn9.FlatStyle = FlatStyle.Flat;
        btn9.FlatAppearance.BorderSize = 0;
        btn9.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
        btn9.Text = "+";
        bool mouseDown = false;
        int click_x = 0;
        int click_y = 0;
        btn9.MouseDown += delegate (object sender, MouseEventArgs e)
        {
            btn9.Cursor = Cursors.Hand;
            mouseDown = true;
            click_x = e.Location.X;
            click_y = e.Location.Y;
        };
        btn9.MouseMove += delegate (object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int y = (frm.Location.Y - click_y) + e.Location.Y;
                int x = (frm.Location.X - click_x) + e.Location.X;

                frm.Location = new Point(x, y);
            }

        };
        btn9.MouseUp += delegate
        {
            mouseDown = false;
            btn9.Cursor = Cursors.Default;
        };

        //-------------------------------------------
        Button btn3 = new Button();
        btn3.Width = 30;
        btn3.Height = 30;
        btn3.BackColor = Color.FromArgb(208, 208, 208); ;
        btn3.FlatStyle = FlatStyle.Flat;
        btn3.FlatAppearance.BorderSize = 0;
        btn3.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
        btn3.Text = "←";
        btn3.Click += delegate
        {
            if (frm.Width > btn9.Width + 2 + 120 + 10) frm.Width = frm.Width - 1;
        };

        //-------------------------------------------
        Button btn4 = new Button();
        btn4.Width = 30;
        btn4.Height = 30;
        btn4.BackColor = Color.FromArgb(208, 208, 208); 
        btn4.FlatStyle = FlatStyle.Flat;
        btn4.FlatAppearance.BorderSize = 0;
        btn4.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
        btn4.Text = "→";
        btn4.Click += delegate
        {
            frm.Width = frm.Width + 1;
        };

        //-------------------------------------------
        Button btn5 = new Button();
        btn5.Width = 30;
        btn5.Height = 30;
        btn5.BackColor = Color.FromArgb(100, 236, 254); 
        btn5.FlatStyle = FlatStyle.Flat;
        btn5.FlatAppearance.BorderSize = 0;
        btn5.Text = "↑";
        btn5.Click += delegate
        {
            frm.Top = frm.Top - 1;
        };

        //-------------------------------------------
        Button btn6 = new Button();
        btn6.Width = 30;
        btn6.Height = 30;
        btn6.BackColor = Color.FromArgb(100, 236, 254); ;
        btn6.FlatStyle = FlatStyle.Flat;
        btn6.FlatAppearance.BorderSize = 0;
        btn6.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
        btn6.Text = "↓";
        btn6.Click += delegate
        {
            frm.Top = frm.Top + 1;
        };

        //-------------------------------------------
        Button btn7 = new Button();
        btn7.Width = 30;
        btn7.Height = 30;
        btn7.BackColor = Color.FromArgb(208, 208, 208);
        btn7.FlatStyle = FlatStyle.Flat;
        btn7.FlatAppearance.BorderSize = 0;
        btn7.Text = "↑";
        btn7.Click += delegate
        {
            if (frm.Height > topOf_9_1_2_3_4 + 150) frm.Height = frm.Height - 1;
        };

        //-------------------------------------------
        Button btn8 = new Button();
        btn8.Width = 30;
        btn8.Height = 30;
        btn8.BackColor = Color.FromArgb(208, 208, 208);
        btn8.FlatStyle = FlatStyle.Flat;
        btn8.FlatAppearance.BorderSize = 0;
        btn8.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
        btn8.Text = "↓";
        btn8.Click += delegate
        {
            frm.Height = frm.Height + 1;
        };



        //-------------------------------------------
        Button btn10 = new Button();
        btn10.ForeColor = Color.Black;
        btn10.Width = frm.Width - btn9.Width - 2;
        btn10.Height = topOf_9_1_2_3_4 - btn.Height - 2;
        btn10.BackColor = Color.FromArgb(151, 242, 254);
        btn10.FlatStyle = FlatStyle.Flat;
        btn10.FlatAppearance.BorderSize = 0;
        btn10.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
        btn10.Text = "↔";


        btn10.MouseDown += delegate (object sender, MouseEventArgs e)
        {
            if (e.X < btn10.Width / 2)
            {
                if (frm.Width > btn9.Width + 2 + 120 + 10)
                {
                    frm.Width -= 20;
                }

            }
            else if (e.X > btn10.Width / 2)
            {
                frm.Width += 20;
            }
        };

        //-------------------------------------------
        Button btn11 = new Button();
        btn11.ForeColor = Color.Black;
        btn11.Width = leftOf_9_5_6_7_8 - 2;
        btn11.Height = frm.Height - topOf_9_1_2_3_4 + 30;
        btn11.BackColor = Color.FromArgb(151, 242, 254);
        btn11.FlatStyle = FlatStyle.Flat;
        btn11.FlatAppearance.BorderSize = 0;
        btn11.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
        btn11.Text = "↕";


        btn11.MouseDown += delegate (object sender, MouseEventArgs e)
        {
            if (e.Y < btn11.Height / 2)
            {
                if (frm.Height > topOf_9_1_2_3_4 + 170)
                {
                    frm.Height -= 20;
                }

            }
            else if (e.Y > btn11.Height / 2)
            {
                frm.Height += 20;
            }
        };

        //-------------------------------------------

        frm.Controls.Add(btn);
        frm.Controls.Add(btn1);
        frm.Controls.Add(btn2);
        frm.Controls.Add(btn3);
        frm.Controls.Add(btn4);
        frm.Controls.Add(btn5);
        frm.Controls.Add(btn6);
        frm.Controls.Add(btn7);
        frm.Controls.Add(btn8);
        frm.Controls.Add(btn9);
        frm.Controls.Add(btn10);
        frm.Controls.Add(btn11);


        //-------------------------------------------
        frm.Load += delegate
        {
            // اولا التأكد هل حجم النموذج 0 ليتم تغييره
            if (frmLocationAndSize.getSize()[0] == 0 || frmLocationAndSize.getSize()[1] == 0)
            {
                frm.Size = new Size(200, 200);
                frm.Location = new Point(10, 10);
            }
            else
            {
                frm.Size = new Size(frmLocationAndSize.getSize()[0], frmLocationAndSize.getSize()[1]);
                frm.Location = new Point(frmLocationAndSize.getLocation()[0], frmLocationAndSize.getLocation()[1]);
            }



            btn1.Location = new Point(leftOf_9_5_6_7_8 + 30, topOf_9_1_2_3_4);
            btn2.Location = new Point(frm.Width - btn2.Width, topOf_9_1_2_3_4);
            btn3.Location = new Point(leftOf_9_5_6_7_8 + 30 + btn1.Width, topOf_9_1_2_3_4);
            btn4.Location = new Point(frm.Width - btn4.Width - btn2.Width, topOf_9_1_2_3_4);
            btn5.Location = new Point(leftOf_9_5_6_7_8, topOf_9_1_2_3_4 + btn1.Height);
            btn6.Location = new Point(leftOf_9_5_6_7_8, frm.Height - btn6.Height);
            btn7.Location = new Point(leftOf_9_5_6_7_8, topOf_9_1_2_3_4 + btn1.Height + btn5.Height);
            btn8.Location = new Point(leftOf_9_5_6_7_8, frm.Height - btn6.Height - btn8.Height);
            btn9.Location = new Point(1, btn.Height + 1);
            btn10.Location = new Point(btn9.Width + 2, btn.Height + 1);
            btn11.Location = new Point(1, btn9.Width + 1);


        };
        frm.Opacity = .99;
        frm.ShowDialog();

    }

    private void InitializeComponent()
    {
        this.SuspendLayout();
        // 
        // LocationAndSize
        // 
        this.ClientSize = new System.Drawing.Size(651, 437);
        this.Name = "LocationAndSize";
        this.ResumeLayout(false);

    }
}

