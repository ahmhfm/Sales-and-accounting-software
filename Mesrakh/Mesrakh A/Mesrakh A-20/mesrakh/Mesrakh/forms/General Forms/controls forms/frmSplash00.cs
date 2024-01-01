// المتطلبات
// SecurityTools اضافة كلاس 
// program.cs  جعل هذا النموذج النموذج الافتتاحي من ملف 
// DataTools اضافة كلاس
// frmAccountManagement اضافة كلاس
// frmGeneral  اضافة كلاس

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



public partial class frmsplash : Form
{
    private void InitializeComponent()
    {
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(595, 400);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(20, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(557, 309);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
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
            this.ClientSize = new System.Drawing.Size(595, 400);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmsplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Load += new System.EventHandler(this.frmsplash_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

    }
    //#endregion
    private System.Windows.Forms.Panel panel2;
    public ProgressBar progressBar1;



    //***************************************************************************************************************************************************************

    //string programName = "mesrakh";
    //frmAccountManagement frmAccount;
    private PictureBox pictureBox1;
    public Timer timer01;


    public frmsplash()
    {
        try
        {
            this.Icon = Images.convertBase64StringToIcon(Images.ImagesLibrary.imgAccount64Dark);  // ايقونة البرنامج
            InitializeComponent();
            //DisplayMode.fillTblColors(); // تعبئة جدول الالوان
            //Cultures.fillTranslationTable(); // تعبئة جدول اللغات
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmsplash >>  frmsplash() ", DateTime.Now, ex.Message, ex.Message);
        }


    }


    private void frmsplash_Load(object sender, EventArgs e)
    {
        try
        {
            checkLicenesInSeplash();
            pictureBox1.Image = Images.ConvertBase64StringToImage(Images.ImagesLibrary.imgAccount265Dark);
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmsplash >>  frmsplash_Load ", DateTime.Now, ex.Message, ex.Message);
        }


    }



    private void checkLicenesInSeplash()
    {
        try
        {
            timer01 = new Timer();  // وضع في الاعلى لانه يستخدم في عدة سطور
            timer01.Interval = 100;



            // التحقق من صلاحية الرخصة  ----------------------------------------------------
            string[] ResultLicense = null;
            Task.Run(() =>
            {
                (GeneralVariables._frmSplash00).Invoke((MethodInvoker)delegate
                {
                    progressBar1.Style = ProgressBarStyle.Marquee;
                    timer01.Enabled = false;
                });

                GeneralVariables._frmAccountManagement04 = new frmAccountManagement();
                SecurityTools.LicenseCheck.AreWeHaveActiveLicense(ref ResultLicense);
                GeneralVariables._frmMain01 = new Mesrakh.frmMain01();
                GeneralVariables._frmMain01.Name = "frmMain01";

            }).ContinueWith((d) =>
            {
                (GeneralVariables._frmSplash00).Invoke((MethodInvoker)delegate
                {
                    progressBar1.Style = ProgressBarStyle.Continuous;
                    timer01.Enabled = true;
                });
                this.Invoke((MethodInvoker)delegate { timer01.Interval = 20; });    // تسريع البروقريس بار لأن النتيجة وصلت
            });

            // البروقرس بار والتايمر  -----------------------------------------------------
            timer01.Tick += delegate
            {
                if (progressBar1.Value < 100)
                {
                    progressBar1.Value += 1;
                    if (progressBar1.Value >= 30) { if (ResultLicense == null) { if (timer01.Interval != 500) { timer01.Interval = 500; } } else { if (timer01.Interval != 50) { timer01.Interval = 50; } } };   // إبطاء البروقريس بار في حال تجاوز 70 في المئة وعدم وصول نتيجة التحقق من الترخيص
                    if (progressBar1.Value == 99 && ResultLicense == null) { this.Close(); };   // اغلاق البرنامج في حال عدم الوصول لنتيجة
                }
                else
                {
                    timer01.Stop();
                    if (ResultLicense[1] == "success")
                    {
                        this.Hide();
                        GeneralVariables._frmMain01.Text = "frmMain01";
                        GeneralVariables._frmMain01.Show();
                    }
                    else if (ResultLicense[1] == "not success" && !(ConnectionsTools._Conlicenses is null))
                    {
                        GeneralVariables._frmAccountManagement04.Show();
                        GeneralVariables._frmAccountManagement04.Text = "license";
                        this.Hide();
                    }
                    else if (ResultLicense[1] != null)
                    {
                        frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("تحقق من وجود إتصال بالإنترنت ووجود رخصة سارية المفعول"), MessageBoxStatus.Ok);
                        this.Close();
                    }
                    else
                    {
                        if (!GeneralVariables.frmMessageIsOpen)
                        {
                            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("توجد مشكلة في الإتصال"), MessageBoxStatus.Ok);
                            this.Close();
                        }
                    }
                }
            };
            timer01.Start();
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmsplash >>  checkLicenesInSeplash ", DateTime.Now, ex.Message, ex.Message);
        }
        
    }

    public void stopTimer()
    {
        timer01.Enabled = false;
    }

    public void startTimer()
    {
        timer01.Enabled = true;
    }
}

