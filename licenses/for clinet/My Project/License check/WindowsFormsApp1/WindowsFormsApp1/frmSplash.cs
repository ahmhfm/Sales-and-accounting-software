// المتطلبات
// SecurityTools اضافة كلاس 
// program.cs  جعل هذا النموذج النموذج الافتتاحي من ملف 

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class frmsplash : Form
{

    private void InitializeComponent()
    {
        this.panel1 = new System.Windows.Forms.Panel();
        this.panel2 = new System.Windows.Forms.Panel();
        this.progressBar1 = new System.Windows.Forms.ProgressBar();
        this.panel2.SuspendLayout();
        this.SuspendLayout();
        // 
        // panel1
        // 
        this.panel1.BackColor = System.Drawing.Color.Navy;
        this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
        this.panel1.Location = new System.Drawing.Point(0, 0);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(200, 400);
        this.panel1.TabIndex = 0;
        // 
        // panel2
        // 
        this.panel2.BackColor = System.Drawing.Color.Navy;
        this.panel2.Controls.Add(this.progressBar1);
        this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
        this.panel2.Location = new System.Drawing.Point(205, 0);
        this.panel2.Name = "panel2";
        this.panel2.Size = new System.Drawing.Size(595, 400);
        this.panel2.TabIndex = 1;
        // 
        // progressBar1
        // 
        this.progressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        this.progressBar1.Location = new System.Drawing.Point(20, 343);
        this.progressBar1.Name = "progressBar1";
        this.progressBar1.Size = new System.Drawing.Size(557, 38);
        this.progressBar1.TabIndex = 0;
        // 
        // frmsplash
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        this.ClientSize = new System.Drawing.Size(800, 400);
        this.Controls.Add(this.panel2);
        this.Controls.Add(this.panel1);
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        this.Name = "frmsplash";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Form1";
        this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        this.Load += new System.EventHandler(this.frmsplash_Load);
        this.panel2.ResumeLayout(false);
        this.ResumeLayout(false);

    }
    //#endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.ProgressBar progressBar1;



    //***************************************************************************************************************************************************************

    public frmsplash()
    {
        InitializeComponent();
    }

    private void frmsplash_Load(object sender, EventArgs e)
    {
        checkLicenseInSeplash();
    }

    SqlConnection con = new SqlConnection("Data Source = 52.147.200.137; Initial Catalog = licenses; User ID = sa; Password = Aah51771#");
    string programName = "mesrakh";
    Form frmlicens = new Form();
    Form frmmain = new Form();

    private void checkLicenseInSeplash()
    {
        Timer t = new Timer();  // وضع في الاعلى لانه يستخدم في عدة سطور
        t.Interval = 100;

        try
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
        }
        catch (Exception) { }

        // التحقق من صلاحية الرخصة  ----------------------------------------------------
        string[] ResultLicense = null;
        Task.Run(() =>
        {
            SecurityTools.LicenseCheck.AreWeHaveActiveLicense(ref ResultLicense, con, programName);
        }).ContinueWith((d) =>
        {
            this.Invoke((MethodInvoker)delegate { t.Interval = 20; });    // تسريع البروقريس بار لأن النتيجة وصلت
        });

        // البروقرس بار والتايمر  -----------------------------------------------------
        t.Tick += delegate
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 1;
                if (progressBar1.Value == 70 && ResultLicense == null) { t.Interval = 200; };   // إبطاء البروقريس بار في حال تجاوز 70 في المئة وعدم وصول نتيجة التحقق من الترخيص
            }
            else
            {
                t.Stop();
                if (ResultLicense[1] == "success")
                {
                    this.Hide();
                    frmmain.Text = "main";
                    frmmain.Show();
                }
                else if (ResultLicense[1] == "not success")
                {
                    frmlicens.Show();
                    frmlicens.Text = "license";
                    this.Hide();
                }
                else if (ResultLicense[1] != null)
                {
                    MessageBox.Show(ResultLicense[0] + "  >>  " + ResultLicense[1]);
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        };
        t.Start();
    }
}

