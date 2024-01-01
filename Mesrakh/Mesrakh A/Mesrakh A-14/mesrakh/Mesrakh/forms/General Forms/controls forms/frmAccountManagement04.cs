using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


public class frmAccountManagement : Form
{


    private void InitializeComponent()
    {
        this.pnl001 = new System.Windows.Forms.Panel();
        this.pnl001002 = new System.Windows.Forms.Panel();
        this.btn04_cancel = new System.Windows.Forms.Button();
        this.btn03_send = new System.Windows.Forms.Button();
        this.txt016c014_country = new System.Windows.Forms.TextBox();
        this.label16 = new System.Windows.Forms.Label();
        this.txt015c013_City = new System.Windows.Forms.TextBox();
        this.label15 = new System.Windows.Forms.Label();
        this.txt014c012_PostalCode = new System.Windows.Forms.TextBox();
        this.label14 = new System.Windows.Forms.Label();
        this.txt013c011_District = new System.Windows.Forms.TextBox();
        this.label13 = new System.Windows.Forms.Label();
        this.txt012c010_SecondaryNo = new System.Windows.Forms.TextBox();
        this.label12 = new System.Windows.Forms.Label();
        this.txt011c009_Street = new System.Windows.Forms.TextBox();
        this.label11 = new System.Windows.Forms.Label();
        this.txt010c008_BuildingNo = new System.Windows.Forms.TextBox();
        this.label10 = new System.Windows.Forms.Label();
        this.txt009c007_ShortAddress = new System.Windows.Forms.TextBox();
        this.label9 = new System.Windows.Forms.Label();
        this.txt008c006_ClientEmail = new System.Windows.Forms.TextBox();
        this.label8 = new System.Windows.Forms.Label();
        this.txt007c005_ClientPhone = new System.Windows.Forms.TextBox();
        this.label7 = new System.Windows.Forms.Label();
        this.txt006c004_ClientName = new System.Windows.Forms.TextBox();
        this.label6 = new System.Windows.Forms.Label();
        this.txt005c003_password = new System.Windows.Forms.TextBox();
        this.label5 = new System.Windows.Forms.Label();
        this.txt004c002_userName = new System.Windows.Forms.TextBox();
        this.label4 = new System.Windows.Forms.Label();
        this.txt003c001_AccountNo = new System.Windows.Forms.TextBox();
        this.label3 = new System.Windows.Forms.Label();
        this.pnl001001 = new System.Windows.Forms.Panel();
        this.btn20Exit = new System.Windows.Forms.Button();
        this.lbl001 = new System.Windows.Forms.Label();
        this.btn02_CreateNewAccount = new System.Windows.Forms.Button();
        this.btn01_LoginToAccount = new System.Windows.Forms.Button();
        this.txt002c003_password = new System.Windows.Forms.TextBox();
        this.txt001c002_userName = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.btnExit = new System.Windows.Forms.Button();
        this.txt017c001_licenseNo = new System.Windows.Forms.TextBox();
        this.txt019c003_DateOfLicenseRequest = new System.Windows.Forms.TextBox();
        this.txt020c004_DateOfLicenseStart = new System.Windows.Forms.TextBox();
        this.txt021c003_information = new System.Windows.Forms.TextBox();
        this.txt022c004_PackageDuration = new System.Windows.Forms.TextBox();
        this.txt023c007_LicenseEndDate = new System.Windows.Forms.TextBox();
        this.label17 = new System.Windows.Forms.Label();
        this.label18 = new System.Windows.Forms.Label();
        this.label19 = new System.Windows.Forms.Label();
        this.label20 = new System.Windows.Forms.Label();
        this.label21 = new System.Windows.Forms.Label();
        this.label22 = new System.Windows.Forms.Label();
        this.label23 = new System.Windows.Forms.Label();
        this.btn05first = new System.Windows.Forms.Button();
        this.btn06previes = new System.Windows.Forms.Button();
        this.btn07next = new System.Windows.Forms.Button();
        this.btn08last = new System.Windows.Forms.Button();
        this.tabPage2 = new System.Windows.Forms.TabPage();
        this.pnl007 = new System.Windows.Forms.Panel();
        this.dgv2 = new System.Windows.Forms.DataGridView();
        this.pnl006 = new System.Windows.Forms.Panel();
        this.cmb002 = new System.Windows.Forms.ComboBox();
        this.btn031Pay = new System.Windows.Forms.Button();
        this.txt036c006_TransferAmount = new System.Windows.Forms.TextBox();
        this.txt035c005_TransferTime = new System.Windows.Forms.TextBox();
        this.txt034c004_TransferDate = new System.Windows.Forms.TextBox();
        this.txt033c003_TransferBank = new System.Windows.Forms.TextBox();
        this.txt032c002_TransferBanckNumber = new System.Windows.Forms.TextBox();
        this.label36 = new System.Windows.Forms.Label();
        this.label32 = new System.Windows.Forms.Label();
        this.label33 = new System.Windows.Forms.Label();
        this.label34 = new System.Windows.Forms.Label();
        this.label35 = new System.Windows.Forms.Label();
        this.pnl005 = new System.Windows.Forms.Panel();
        this.txt031c016_AllCost = new System.Windows.Forms.TextBox();
        this.txt030c005_TaxCost = new System.Windows.Forms.TextBox();
        this.txt029c004_TaxPercentage = new System.Windows.Forms.TextBox();
        this.txt028c003_LicenseCost = new System.Windows.Forms.TextBox();
        this.txt027c002_data = new System.Windows.Forms.TextBox();
        this.txt026c001_invoiceNumber = new System.Windows.Forms.TextBox();
        this.btn030PayPanel = new System.Windows.Forms.Button();
        this.label27 = new System.Windows.Forms.Label();
        this.label28 = new System.Windows.Forms.Label();
        this.label29 = new System.Windows.Forms.Label();
        this.label25 = new System.Windows.Forms.Label();
        this.label30 = new System.Windows.Forms.Label();
        this.label31 = new System.Windows.Forms.Label();
        this.tabPage1 = new System.Windows.Forms.TabPage();
        this.pnl004 = new System.Windows.Forms.Panel();
        this.dgv1 = new System.Windows.Forms.DataGridView();
        this.pnl002 = new System.Windows.Forms.Panel();
        this.btn22AddDevice = new System.Windows.Forms.Button();
        this.txt025c006_deviceUses = new System.Windows.Forms.TextBox();
        this.label26 = new System.Windows.Forms.Label();
        this.txt024c005_location = new System.Windows.Forms.TextBox();
        this.label24 = new System.Windows.Forms.Label();
        this.pnl003 = new System.Windows.Forms.Panel();
        this.btn20forAddDevice = new System.Windows.Forms.Button();
        this.btn21DeleteDevice = new System.Windows.Forms.Button();
        this.tabControl1 = new System.Windows.Forms.TabControl();
        this.cmb01c002_PackageName = new System.Windows.Forms.ComboBox();
        this.btn09New = new System.Windows.Forms.Button();
        this.btn10Delete = new System.Windows.Forms.Button();
        this.btn11Save = new System.Windows.Forms.Button();
        this.label37 = new System.Windows.Forms.Label();
        this.txt040c002_price = new System.Windows.Forms.TextBox();
        this.label38 = new System.Windows.Forms.Label();
        this.txt035c005_packageDevicesNumber = new System.Windows.Forms.TextBox();
        this.panel1 = new System.Windows.Forms.Panel();
        this.label39 = new System.Windows.Forms.Label();
        this.pnl001.SuspendLayout();
        this.pnl001002.SuspendLayout();
        this.pnl001001.SuspendLayout();
        this.tabPage2.SuspendLayout();
        this.pnl007.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
        this.pnl006.SuspendLayout();
        this.pnl005.SuspendLayout();
        this.tabPage1.SuspendLayout();
        this.pnl004.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
        this.pnl002.SuspendLayout();
        this.pnl003.SuspendLayout();
        this.tabControl1.SuspendLayout();
        this.panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnl001
        // 
        this.pnl001.Controls.Add(this.pnl001002);
        this.pnl001.Controls.Add(this.pnl001001);
        this.pnl001.Location = new System.Drawing.Point(11, 59);
        this.pnl001.Name = "pnl001";
        this.pnl001.Size = new System.Drawing.Size(303, 698);
        this.pnl001.TabIndex = 0;
        // 
        // pnl001002
        // 
        this.pnl001002.Controls.Add(this.btn04_cancel);
        this.pnl001002.Controls.Add(this.btn03_send);
        this.pnl001002.Controls.Add(this.txt016c014_country);
        this.pnl001002.Controls.Add(this.label16);
        this.pnl001002.Controls.Add(this.txt015c013_City);
        this.pnl001002.Controls.Add(this.label15);
        this.pnl001002.Controls.Add(this.txt014c012_PostalCode);
        this.pnl001002.Controls.Add(this.label14);
        this.pnl001002.Controls.Add(this.txt013c011_District);
        this.pnl001002.Controls.Add(this.label13);
        this.pnl001002.Controls.Add(this.txt012c010_SecondaryNo);
        this.pnl001002.Controls.Add(this.label12);
        this.pnl001002.Controls.Add(this.txt011c009_Street);
        this.pnl001002.Controls.Add(this.label11);
        this.pnl001002.Controls.Add(this.txt010c008_BuildingNo);
        this.pnl001002.Controls.Add(this.label10);
        this.pnl001002.Controls.Add(this.txt009c007_ShortAddress);
        this.pnl001002.Controls.Add(this.label9);
        this.pnl001002.Controls.Add(this.txt008c006_ClientEmail);
        this.pnl001002.Controls.Add(this.label8);
        this.pnl001002.Controls.Add(this.txt007c005_ClientPhone);
        this.pnl001002.Controls.Add(this.label7);
        this.pnl001002.Controls.Add(this.txt006c004_ClientName);
        this.pnl001002.Controls.Add(this.label6);
        this.pnl001002.Controls.Add(this.txt005c003_password);
        this.pnl001002.Controls.Add(this.label5);
        this.pnl001002.Controls.Add(this.txt004c002_userName);
        this.pnl001002.Controls.Add(this.label4);
        this.pnl001002.Controls.Add(this.txt003c001_AccountNo);
        this.pnl001002.Controls.Add(this.label3);
        this.pnl001002.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.pnl001002.Location = new System.Drawing.Point(0, 186);
        this.pnl001002.Name = "pnl001002";
        this.pnl001002.Size = new System.Drawing.Size(303, 511);
        this.pnl001002.TabIndex = 1;
        // 
        // btn04_cancel
        // 
        this.btn04_cancel.FlatAppearance.BorderSize = 0;
        this.btn04_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn04_cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn04_cancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn04_cancel.Location = new System.Drawing.Point(12, 472);
        this.btn04_cancel.Name = "btn04_cancel";
        this.btn04_cancel.Size = new System.Drawing.Size(128, 35);
        this.btn04_cancel.TabIndex = 31;
        this.btn04_cancel.Text = "إلغاء";
        this.btn04_cancel.UseVisualStyleBackColor = true;
        this.btn04_cancel.Click += new System.EventHandler(this.btn04_cancel_Click);
        // 
        // btn03_send
        // 
        this.btn03_send.FlatAppearance.BorderSize = 0;
        this.btn03_send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn03_send.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn03_send.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn03_send.Location = new System.Drawing.Point(163, 472);
        this.btn03_send.Name = "btn03_send";
        this.btn03_send.Size = new System.Drawing.Size(127, 35);
        this.btn03_send.TabIndex = 30;
        this.btn03_send.Text = "إرسال";
        this.btn03_send.UseVisualStyleBackColor = true;
        this.btn03_send.Click += new System.EventHandler(this.btn03_send_Click);
        // 
        // txt016c014_country
        // 
        this.txt016c014_country.Location = new System.Drawing.Point(12, 440);
        this.txt016c014_country.Name = "txt016c014_country";
        this.txt016c014_country.Size = new System.Drawing.Size(168, 26);
        this.txt016c014_country.TabIndex = 29;
        // 
        // label16
        // 
        this.label16.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label16.Location = new System.Drawing.Point(186, 441);
        this.label16.Name = "label16";
        this.label16.Size = new System.Drawing.Size(109, 24);
        this.label16.TabIndex = 28;
        this.label16.Text = "الدولة :";
        this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt015c013_City
        // 
        this.txt015c013_City.Location = new System.Drawing.Point(12, 408);
        this.txt015c013_City.Name = "txt015c013_City";
        this.txt015c013_City.Size = new System.Drawing.Size(168, 26);
        this.txt015c013_City.TabIndex = 27;
        // 
        // label15
        // 
        this.label15.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label15.Location = new System.Drawing.Point(186, 409);
        this.label15.Name = "label15";
        this.label15.Size = new System.Drawing.Size(109, 24);
        this.label15.TabIndex = 26;
        this.label15.Text = "المدينة :";
        this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt014c012_PostalCode
        // 
        this.txt014c012_PostalCode.Location = new System.Drawing.Point(12, 376);
        this.txt014c012_PostalCode.Name = "txt014c012_PostalCode";
        this.txt014c012_PostalCode.Size = new System.Drawing.Size(168, 26);
        this.txt014c012_PostalCode.TabIndex = 25;
        // 
        // label14
        // 
        this.label14.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label14.Location = new System.Drawing.Point(186, 377);
        this.label14.Name = "label14";
        this.label14.Size = new System.Drawing.Size(109, 24);
        this.label14.TabIndex = 24;
        this.label14.Text = "الرمز البريدي :";
        this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt013c011_District
        // 
        this.txt013c011_District.Location = new System.Drawing.Point(12, 344);
        this.txt013c011_District.Name = "txt013c011_District";
        this.txt013c011_District.Size = new System.Drawing.Size(168, 26);
        this.txt013c011_District.TabIndex = 23;
        // 
        // label13
        // 
        this.label13.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label13.Location = new System.Drawing.Point(186, 345);
        this.label13.Name = "label13";
        this.label13.Size = new System.Drawing.Size(109, 24);
        this.label13.TabIndex = 22;
        this.label13.Text = "الحي :";
        this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt012c010_SecondaryNo
        // 
        this.txt012c010_SecondaryNo.Location = new System.Drawing.Point(12, 312);
        this.txt012c010_SecondaryNo.Name = "txt012c010_SecondaryNo";
        this.txt012c010_SecondaryNo.Size = new System.Drawing.Size(168, 26);
        this.txt012c010_SecondaryNo.TabIndex = 21;
        // 
        // label12
        // 
        this.label12.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label12.Location = new System.Drawing.Point(186, 313);
        this.label12.Name = "label12";
        this.label12.Size = new System.Drawing.Size(109, 24);
        this.label12.TabIndex = 20;
        this.label12.Text = "الرقم الفرعي :";
        this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt011c009_Street
        // 
        this.txt011c009_Street.Location = new System.Drawing.Point(12, 280);
        this.txt011c009_Street.Name = "txt011c009_Street";
        this.txt011c009_Street.Size = new System.Drawing.Size(168, 26);
        this.txt011c009_Street.TabIndex = 19;
        // 
        // label11
        // 
        this.label11.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label11.Location = new System.Drawing.Point(186, 281);
        this.label11.Name = "label11";
        this.label11.Size = new System.Drawing.Size(109, 24);
        this.label11.TabIndex = 18;
        this.label11.Text = "الشارع :";
        this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt010c008_BuildingNo
        // 
        this.txt010c008_BuildingNo.Location = new System.Drawing.Point(12, 247);
        this.txt010c008_BuildingNo.Name = "txt010c008_BuildingNo";
        this.txt010c008_BuildingNo.Size = new System.Drawing.Size(168, 26);
        this.txt010c008_BuildingNo.TabIndex = 17;
        // 
        // label10
        // 
        this.label10.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label10.Location = new System.Drawing.Point(186, 248);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(109, 24);
        this.label10.TabIndex = 16;
        this.label10.Text = "رقم المبنى :";
        this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt009c007_ShortAddress
        // 
        this.txt009c007_ShortAddress.Location = new System.Drawing.Point(12, 213);
        this.txt009c007_ShortAddress.Name = "txt009c007_ShortAddress";
        this.txt009c007_ShortAddress.Size = new System.Drawing.Size(168, 26);
        this.txt009c007_ShortAddress.TabIndex = 15;
        // 
        // label9
        // 
        this.label9.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label9.Location = new System.Drawing.Point(186, 214);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(109, 24);
        this.label9.TabIndex = 14;
        this.label9.Text = "العنوان المختصر :";
        this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt008c006_ClientEmail
        // 
        this.txt008c006_ClientEmail.Location = new System.Drawing.Point(12, 179);
        this.txt008c006_ClientEmail.Name = "txt008c006_ClientEmail";
        this.txt008c006_ClientEmail.Size = new System.Drawing.Size(168, 26);
        this.txt008c006_ClientEmail.TabIndex = 13;
        // 
        // label8
        // 
        this.label8.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label8.Location = new System.Drawing.Point(186, 180);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(109, 24);
        this.label8.TabIndex = 12;
        this.label8.Text = "الإيميل";
        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt007c005_ClientPhone
        // 
        this.txt007c005_ClientPhone.Location = new System.Drawing.Point(12, 145);
        this.txt007c005_ClientPhone.Name = "txt007c005_ClientPhone";
        this.txt007c005_ClientPhone.Size = new System.Drawing.Size(168, 26);
        this.txt007c005_ClientPhone.TabIndex = 11;
        // 
        // label7
        // 
        this.label7.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label7.Location = new System.Drawing.Point(186, 146);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(109, 24);
        this.label7.TabIndex = 10;
        this.label7.Text = "رقم الجوال :";
        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt006c004_ClientName
        // 
        this.txt006c004_ClientName.Location = new System.Drawing.Point(12, 111);
        this.txt006c004_ClientName.Name = "txt006c004_ClientName";
        this.txt006c004_ClientName.Size = new System.Drawing.Size(168, 26);
        this.txt006c004_ClientName.TabIndex = 9;
        // 
        // label6
        // 
        this.label6.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label6.Location = new System.Drawing.Point(186, 112);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(109, 24);
        this.label6.TabIndex = 8;
        this.label6.Text = "إسم العميل :";
        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt005c003_password
        // 
        this.txt005c003_password.Location = new System.Drawing.Point(12, 77);
        this.txt005c003_password.Name = "txt005c003_password";
        this.txt005c003_password.Size = new System.Drawing.Size(168, 26);
        this.txt005c003_password.TabIndex = 7;
        this.txt005c003_password.UseSystemPasswordChar = true;
        // 
        // label5
        // 
        this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label5.Location = new System.Drawing.Point(186, 78);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(109, 24);
        this.label5.TabIndex = 6;
        this.label5.Text = "كلمة المرور :";
        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt004c002_userName
        // 
        this.txt004c002_userName.Location = new System.Drawing.Point(12, 42);
        this.txt004c002_userName.Name = "txt004c002_userName";
        this.txt004c002_userName.Size = new System.Drawing.Size(168, 26);
        this.txt004c002_userName.TabIndex = 5;
        // 
        // label4
        // 
        this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label4.Location = new System.Drawing.Point(186, 43);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(109, 24);
        this.label4.TabIndex = 4;
        this.label4.Text = "إسم المستخدم :";
        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt003c001_AccountNo
        // 
        this.txt003c001_AccountNo.Location = new System.Drawing.Point(12, 11);
        this.txt003c001_AccountNo.Name = "txt003c001_AccountNo";
        this.txt003c001_AccountNo.Size = new System.Drawing.Size(168, 26);
        this.txt003c001_AccountNo.TabIndex = 3;
        // 
        // label3
        // 
        this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label3.Location = new System.Drawing.Point(186, 12);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(109, 24);
        this.label3.TabIndex = 1;
        this.label3.Text = "الرقم :";
        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pnl001001
        // 
        this.pnl001001.Controls.Add(this.btn20Exit);
        this.pnl001001.Controls.Add(this.lbl001);
        this.pnl001001.Controls.Add(this.btn02_CreateNewAccount);
        this.pnl001001.Controls.Add(this.btn01_LoginToAccount);
        this.pnl001001.Controls.Add(this.txt002c003_password);
        this.pnl001001.Controls.Add(this.txt001c002_userName);
        this.pnl001001.Controls.Add(this.label2);
        this.pnl001001.Controls.Add(this.label1);
        this.pnl001001.Location = new System.Drawing.Point(0, 0);
        this.pnl001001.Name = "pnl001001";
        this.pnl001001.Size = new System.Drawing.Size(303, 186);
        this.pnl001001.TabIndex = 0;
        // 
        // btn20Exit
        // 
        this.btn20Exit.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
        this.btn20Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
        this.btn20Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
        this.btn20Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn20Exit.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
        this.btn20Exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn20Exit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn20Exit.Location = new System.Drawing.Point(12, 151);
        this.btn20Exit.Name = "btn20Exit";
        this.btn20Exit.Size = new System.Drawing.Size(274, 27);
        this.btn20Exit.TabIndex = 7;
        this.btn20Exit.Text = "خروج";
        this.btn20Exit.UseVisualStyleBackColor = true;
        this.btn20Exit.Visible = false;
        this.btn20Exit.Click += new System.EventHandler(this.btn20Exit_Click);
        // 
        // lbl001
        // 
        this.lbl001.BackColor = System.Drawing.Color.LightGray;
        this.lbl001.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
        this.lbl001.ForeColor = System.Drawing.Color.Brown;
        this.lbl001.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.lbl001.Location = new System.Drawing.Point(12, 124);
        this.lbl001.Name = "lbl001";
        this.lbl001.Size = new System.Drawing.Size(274, 24);
        this.lbl001.TabIndex = 6;
        this.lbl001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btn02_CreateNewAccount
        // 
        this.btn02_CreateNewAccount.FlatAppearance.BorderSize = 0;
        this.btn02_CreateNewAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn02_CreateNewAccount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn02_CreateNewAccount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn02_CreateNewAccount.Location = new System.Drawing.Point(12, 83);
        this.btn02_CreateNewAccount.Name = "btn02_CreateNewAccount";
        this.btn02_CreateNewAccount.Size = new System.Drawing.Size(128, 35);
        this.btn02_CreateNewAccount.TabIndex = 5;
        this.btn02_CreateNewAccount.Text = "جديد";
        this.btn02_CreateNewAccount.UseVisualStyleBackColor = true;
        this.btn02_CreateNewAccount.Click += new System.EventHandler(this.btn02_CreateNewAccount_Click);
        // 
        // btn01_LoginToAccount
        // 
        this.btn01_LoginToAccount.FlatAppearance.BorderSize = 0;
        this.btn01_LoginToAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn01_LoginToAccount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn01_LoginToAccount.Location = new System.Drawing.Point(159, 83);
        this.btn01_LoginToAccount.Name = "btn01_LoginToAccount";
        this.btn01_LoginToAccount.Size = new System.Drawing.Size(127, 35);
        this.btn01_LoginToAccount.TabIndex = 4;
        this.btn01_LoginToAccount.Text = "دخول";
        this.btn01_LoginToAccount.UseVisualStyleBackColor = true;
        this.btn01_LoginToAccount.Click += new System.EventHandler(this.btn01_LoginToAccount_Click);
        // 
        // txt002c003_password
        // 
        this.txt002c003_password.Location = new System.Drawing.Point(12, 48);
        this.txt002c003_password.Name = "txt002c003_password";
        this.txt002c003_password.Size = new System.Drawing.Size(179, 29);
        this.txt002c003_password.TabIndex = 3;
        this.txt002c003_password.UseSystemPasswordChar = true;
        // 
        // txt001c002_userName
        // 
        this.txt001c002_userName.Location = new System.Drawing.Point(12, 13);
        this.txt001c002_userName.Name = "txt001c002_userName";
        this.txt001c002_userName.Size = new System.Drawing.Size(179, 29);
        this.txt001c002_userName.TabIndex = 2;
        // 
        // label2
        // 
        this.label2.BackColor = System.Drawing.Color.Transparent;
        this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label2.Location = new System.Drawing.Point(186, 48);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(105, 24);
        this.label2.TabIndex = 1;
        this.label2.Text = "كلمة المرور :";
        // 
        // label1
        // 
        this.label1.BackColor = System.Drawing.Color.Transparent;
        this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label1.Location = new System.Drawing.Point(186, 13);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(105, 24);
        this.label1.TabIndex = 0;
        this.label1.Text = "إسم المستخدم :";
        // 
        // btnExit
        // 
        this.btnExit.BackColor = System.Drawing.Color.Silver;
        this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
        this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
        this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
        this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnExit.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
        this.btnExit.ForeColor = System.Drawing.Color.White;
        this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btnExit.Location = new System.Drawing.Point(1083, 11);
        this.btnExit.Margin = new System.Windows.Forms.Padding(0);
        this.btnExit.Name = "btnExit";
        this.btnExit.Size = new System.Drawing.Size(30, 30);
        this.btnExit.TabIndex = 7;
        this.btnExit.Text = "X";
        this.btnExit.UseVisualStyleBackColor = false;
        this.btnExit.Visible = false;
        this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
        // 
        // txt017c001_licenseNo
        // 
        this.txt017c001_licenseNo.Enabled = false;
        this.txt017c001_licenseNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt017c001_licenseNo.Location = new System.Drawing.Point(413, 72);
        this.txt017c001_licenseNo.Name = "txt017c001_licenseNo";
        this.txt017c001_licenseNo.Size = new System.Drawing.Size(274, 26);
        this.txt017c001_licenseNo.TabIndex = 3;
        // 
        // txt019c003_DateOfLicenseRequest
        // 
        this.txt019c003_DateOfLicenseRequest.Enabled = false;
        this.txt019c003_DateOfLicenseRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt019c003_DateOfLicenseRequest.Location = new System.Drawing.Point(413, 104);
        this.txt019c003_DateOfLicenseRequest.Name = "txt019c003_DateOfLicenseRequest";
        this.txt019c003_DateOfLicenseRequest.Size = new System.Drawing.Size(274, 26);
        this.txt019c003_DateOfLicenseRequest.TabIndex = 3;
        // 
        // txt020c004_DateOfLicenseStart
        // 
        this.txt020c004_DateOfLicenseStart.Enabled = false;
        this.txt020c004_DateOfLicenseStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt020c004_DateOfLicenseStart.Location = new System.Drawing.Point(810, 139);
        this.txt020c004_DateOfLicenseStart.Name = "txt020c004_DateOfLicenseStart";
        this.txt020c004_DateOfLicenseStart.Size = new System.Drawing.Size(293, 26);
        this.txt020c004_DateOfLicenseStart.TabIndex = 3;
        // 
        // txt021c003_information
        // 
        this.txt021c003_information.Enabled = false;
        this.txt021c003_information.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt021c003_information.Location = new System.Drawing.Point(810, 107);
        this.txt021c003_information.Name = "txt021c003_information";
        this.txt021c003_information.Size = new System.Drawing.Size(293, 26);
        this.txt021c003_information.TabIndex = 3;
        this.txt021c003_information.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt021c005_DevicesCount_KeyPress);
        // 
        // txt022c004_PackageDuration
        // 
        this.txt022c004_PackageDuration.Enabled = false;
        this.txt022c004_PackageDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt022c004_PackageDuration.Location = new System.Drawing.Point(810, 74);
        this.txt022c004_PackageDuration.Name = "txt022c004_PackageDuration";
        this.txt022c004_PackageDuration.Size = new System.Drawing.Size(93, 26);
        this.txt022c004_PackageDuration.TabIndex = 3;
        // 
        // txt023c007_LicenseEndDate
        // 
        this.txt023c007_LicenseEndDate.Enabled = false;
        this.txt023c007_LicenseEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt023c007_LicenseEndDate.Location = new System.Drawing.Point(810, 175);
        this.txt023c007_LicenseEndDate.Name = "txt023c007_LicenseEndDate";
        this.txt023c007_LicenseEndDate.Size = new System.Drawing.Size(293, 26);
        this.txt023c007_LicenseEndDate.TabIndex = 3;
        // 
        // label17
        // 
        this.label17.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label17.Location = new System.Drawing.Point(320, 72);
        this.label17.Name = "label17";
        this.label17.Size = new System.Drawing.Size(89, 24);
        this.label17.TabIndex = 4;
        this.label17.Text = "الرقم :";
        this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label18
        // 
        this.label18.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label18.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label18.Location = new System.Drawing.Point(320, 139);
        this.label18.Name = "label18";
        this.label18.Size = new System.Drawing.Size(89, 24);
        this.label18.TabIndex = 4;
        this.label18.Text = "الباقة :";
        this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label19
        // 
        this.label19.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label19.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label19.Location = new System.Drawing.Point(320, 104);
        this.label19.Name = "label19";
        this.label19.Size = new System.Drawing.Size(89, 24);
        this.label19.TabIndex = 4;
        this.label19.Text = "التاريخ :";
        this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label20
        // 
        this.label20.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label20.Location = new System.Drawing.Point(695, 141);
        this.label20.Name = "label20";
        this.label20.Size = new System.Drawing.Size(109, 24);
        this.label20.TabIndex = 4;
        this.label20.Text = "تاريخ البداية :";
        this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label21
        // 
        this.label21.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label21.Location = new System.Drawing.Point(695, 107);
        this.label21.Name = "label21";
        this.label21.Size = new System.Drawing.Size(109, 24);
        this.label21.TabIndex = 4;
        this.label21.Text = "معلومات الباقة :";
        this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label22
        // 
        this.label22.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label22.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label22.Location = new System.Drawing.Point(695, 74);
        this.label22.Name = "label22";
        this.label22.Size = new System.Drawing.Size(109, 24);
        this.label22.TabIndex = 4;
        this.label22.Text = "مدة الترخيص :";
        this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label23
        // 
        this.label23.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label23.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label23.Location = new System.Drawing.Point(695, 175);
        this.label23.Name = "label23";
        this.label23.Size = new System.Drawing.Size(109, 24);
        this.label23.TabIndex = 4;
        this.label23.Text = "تاريخ النهاية :";
        this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btn05first
        // 
        this.btn05first.BackColor = System.Drawing.Color.Gainsboro;
        this.btn05first.Enabled = false;
        this.btn05first.FlatAppearance.BorderSize = 0;
        this.btn05first.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn05first.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn05first.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn05first.Location = new System.Drawing.Point(320, 247);
        this.btn05first.Name = "btn05first";
        this.btn05first.Size = new System.Drawing.Size(198, 35);
        this.btn05first.TabIndex = 32;
        this.btn05first.Text = "الأول";
        this.btn05first.UseVisualStyleBackColor = false;
        this.btn05first.Click += new System.EventHandler(this.btn05first_Click);
        // 
        // btn06previes
        // 
        this.btn06previes.BackColor = System.Drawing.Color.Gainsboro;
        this.btn06previes.Enabled = false;
        this.btn06previes.FlatAppearance.BorderSize = 0;
        this.btn06previes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn06previes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn06previes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn06previes.Location = new System.Drawing.Point(520, 247);
        this.btn06previes.Name = "btn06previes";
        this.btn06previes.Size = new System.Drawing.Size(197, 35);
        this.btn06previes.TabIndex = 33;
        this.btn06previes.Text = "السابق";
        this.btn06previes.UseVisualStyleBackColor = false;
        this.btn06previes.Click += new System.EventHandler(this.btn06previes_Click);
        // 
        // btn07next
        // 
        this.btn07next.BackColor = System.Drawing.Color.Gainsboro;
        this.btn07next.Enabled = false;
        this.btn07next.FlatAppearance.BorderSize = 0;
        this.btn07next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn07next.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn07next.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn07next.Location = new System.Drawing.Point(719, 247);
        this.btn07next.Name = "btn07next";
        this.btn07next.Size = new System.Drawing.Size(191, 35);
        this.btn07next.TabIndex = 34;
        this.btn07next.Text = "التالي";
        this.btn07next.UseVisualStyleBackColor = false;
        this.btn07next.Click += new System.EventHandler(this.btn07next_Click);
        // 
        // btn08last
        // 
        this.btn08last.BackColor = System.Drawing.Color.Gainsboro;
        this.btn08last.Enabled = false;
        this.btn08last.FlatAppearance.BorderSize = 0;
        this.btn08last.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn08last.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn08last.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn08last.Location = new System.Drawing.Point(912, 247);
        this.btn08last.Name = "btn08last";
        this.btn08last.Size = new System.Drawing.Size(191, 35);
        this.btn08last.TabIndex = 35;
        this.btn08last.Text = "الأخير";
        this.btn08last.UseVisualStyleBackColor = false;
        this.btn08last.Click += new System.EventHandler(this.btn08last_Click);
        // 
        // tabPage2
        // 
        this.tabPage2.Controls.Add(this.pnl007);
        this.tabPage2.Controls.Add(this.pnl006);
        this.tabPage2.Controls.Add(this.pnl005);
        this.tabPage2.Location = new System.Drawing.Point(4, 33);
        this.tabPage2.Name = "tabPage2";
        this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage2.Size = new System.Drawing.Size(775, 440);
        this.tabPage2.TabIndex = 1;
        this.tabPage2.Text = "الفواتير";
        this.tabPage2.UseVisualStyleBackColor = true;
        // 
        // pnl007
        // 
        this.pnl007.Controls.Add(this.dgv2);
        this.pnl007.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnl007.Location = new System.Drawing.Point(3, 186);
        this.pnl007.Name = "pnl007";
        this.pnl007.Size = new System.Drawing.Size(769, 251);
        this.pnl007.TabIndex = 59;
        // 
        // dgv2
        // 
        this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgv2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgv2.Location = new System.Drawing.Point(0, 0);
        this.dgv2.Name = "dgv2";
        this.dgv2.Size = new System.Drawing.Size(769, 251);
        this.dgv2.TabIndex = 48;
        this.dgv2.SelectionChanged += new System.EventHandler(this.dgv2_SelectionChanged);
        // 
        // pnl006
        // 
        this.pnl006.Controls.Add(this.cmb002);
        this.pnl006.Controls.Add(this.btn031Pay);
        this.pnl006.Controls.Add(this.txt036c006_TransferAmount);
        this.pnl006.Controls.Add(this.txt035c005_TransferTime);
        this.pnl006.Controls.Add(this.txt034c004_TransferDate);
        this.pnl006.Controls.Add(this.txt033c003_TransferBank);
        this.pnl006.Controls.Add(this.txt032c002_TransferBanckNumber);
        this.pnl006.Controls.Add(this.label36);
        this.pnl006.Controls.Add(this.label32);
        this.pnl006.Controls.Add(this.label33);
        this.pnl006.Controls.Add(this.label34);
        this.pnl006.Controls.Add(this.label35);
        this.pnl006.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnl006.Location = new System.Drawing.Point(3, 113);
        this.pnl006.Name = "pnl006";
        this.pnl006.Size = new System.Drawing.Size(769, 73);
        this.pnl006.TabIndex = 58;
        this.pnl006.Visible = false;
        // 
        // cmb002
        // 
        this.cmb002.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
        this.cmb002.FormattingEnabled = true;
        this.cmb002.Items.AddRange(new object[] {
            "صباحاً",
            "مساءً"});
        this.cmb002.Location = new System.Drawing.Point(149, 38);
        this.cmb002.Name = "cmb002";
        this.cmb002.Size = new System.Drawing.Size(74, 26);
        this.cmb002.TabIndex = 71;
        // 
        // btn031Pay
        // 
        this.btn031Pay.BackColor = System.Drawing.SystemColors.ControlLight;
        this.btn031Pay.FlatAppearance.BorderSize = 0;
        this.btn031Pay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn031Pay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
        this.btn031Pay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn031Pay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn031Pay.Location = new System.Drawing.Point(6, 39);
        this.btn031Pay.Name = "btn031Pay";
        this.btn031Pay.Size = new System.Drawing.Size(132, 26);
        this.btn031Pay.TabIndex = 70;
        this.btn031Pay.Text = "دفع الفاتورة";
        this.btn031Pay.UseVisualStyleBackColor = false;
        this.btn031Pay.Click += new System.EventHandler(this.btn031Pay_Click);
        // 
        // txt036c006_TransferAmount
        // 
        this.txt036c006_TransferAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt036c006_TransferAmount.Location = new System.Drawing.Point(7, 5);
        this.txt036c006_TransferAmount.Name = "txt036c006_TransferAmount";
        this.txt036c006_TransferAmount.Size = new System.Drawing.Size(79, 26);
        this.txt036c006_TransferAmount.TabIndex = 66;
        // 
        // txt035c005_TransferTime
        // 
        this.txt035c005_TransferTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt035c005_TransferTime.Location = new System.Drawing.Point(229, 38);
        this.txt035c005_TransferTime.Name = "txt035c005_TransferTime";
        this.txt035c005_TransferTime.Size = new System.Drawing.Size(99, 26);
        this.txt035c005_TransferTime.TabIndex = 67;
        // 
        // txt034c004_TransferDate
        // 
        this.txt034c004_TransferDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt034c004_TransferDate.Location = new System.Drawing.Point(149, 6);
        this.txt034c004_TransferDate.Name = "txt034c004_TransferDate";
        this.txt034c004_TransferDate.Size = new System.Drawing.Size(179, 26);
        this.txt034c004_TransferDate.TabIndex = 68;
        // 
        // txt033c003_TransferBank
        // 
        this.txt033c003_TransferBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt033c003_TransferBank.Location = new System.Drawing.Point(457, 38);
        this.txt033c003_TransferBank.Name = "txt033c003_TransferBank";
        this.txt033c003_TransferBank.Size = new System.Drawing.Size(181, 26);
        this.txt033c003_TransferBank.TabIndex = 62;
        // 
        // txt032c002_TransferBanckNumber
        // 
        this.txt032c002_TransferBanckNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt032c002_TransferBanckNumber.Location = new System.Drawing.Point(457, 5);
        this.txt032c002_TransferBanckNumber.Name = "txt032c002_TransferBanckNumber";
        this.txt032c002_TransferBanckNumber.Size = new System.Drawing.Size(181, 26);
        this.txt032c002_TransferBanckNumber.TabIndex = 63;
        // 
        // label36
        // 
        this.label36.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label36.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label36.Location = new System.Drawing.Point(334, 39);
        this.label36.Name = "label36";
        this.label36.Size = new System.Drawing.Size(109, 26);
        this.label36.TabIndex = 69;
        this.label36.Text = "وقت الحوالة :";
        this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label32
        // 
        this.label32.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label32.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label32.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label32.Location = new System.Drawing.Point(87, 6);
        this.label32.Name = "label32";
        this.label32.Size = new System.Drawing.Size(51, 26);
        this.label32.TabIndex = 64;
        this.label32.Text = "المبلغ :";
        this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label33
        // 
        this.label33.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label33.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label33.Location = new System.Drawing.Point(334, 7);
        this.label33.Name = "label33";
        this.label33.Size = new System.Drawing.Size(109, 26);
        this.label33.TabIndex = 65;
        this.label33.Text = "تاريخ الحوالة :";
        this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label34
        // 
        this.label34.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label34.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label34.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label34.Location = new System.Drawing.Point(645, 38);
        this.label34.Name = "label34";
        this.label34.Size = new System.Drawing.Size(109, 26);
        this.label34.TabIndex = 60;
        this.label34.Text = "البنك :";
        this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label35
        // 
        this.label35.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label35.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label35.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label35.Location = new System.Drawing.Point(645, 5);
        this.label35.Name = "label35";
        this.label35.Size = new System.Drawing.Size(109, 26);
        this.label35.TabIndex = 61;
        this.label35.Text = "رقم الحوالة :";
        this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pnl005
        // 
        this.pnl005.Controls.Add(this.txt031c016_AllCost);
        this.pnl005.Controls.Add(this.txt030c005_TaxCost);
        this.pnl005.Controls.Add(this.txt029c004_TaxPercentage);
        this.pnl005.Controls.Add(this.txt028c003_LicenseCost);
        this.pnl005.Controls.Add(this.txt027c002_data);
        this.pnl005.Controls.Add(this.txt026c001_invoiceNumber);
        this.pnl005.Controls.Add(this.btn030PayPanel);
        this.pnl005.Controls.Add(this.label27);
        this.pnl005.Controls.Add(this.label28);
        this.pnl005.Controls.Add(this.label29);
        this.pnl005.Controls.Add(this.label25);
        this.pnl005.Controls.Add(this.label30);
        this.pnl005.Controls.Add(this.label31);
        this.pnl005.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnl005.Location = new System.Drawing.Point(3, 3);
        this.pnl005.Name = "pnl005";
        this.pnl005.Size = new System.Drawing.Size(769, 110);
        this.pnl005.TabIndex = 57;
        // 
        // txt031c016_AllCost
        // 
        this.txt031c016_AllCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt031c016_AllCost.Location = new System.Drawing.Point(149, 75);
        this.txt031c016_AllCost.Name = "txt031c016_AllCost";
        this.txt031c016_AllCost.Size = new System.Drawing.Size(181, 26);
        this.txt031c016_AllCost.TabIndex = 56;
        // 
        // txt030c005_TaxCost
        // 
        this.txt030c005_TaxCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt030c005_TaxCost.Location = new System.Drawing.Point(149, 42);
        this.txt030c005_TaxCost.Name = "txt030c005_TaxCost";
        this.txt030c005_TaxCost.Size = new System.Drawing.Size(181, 26);
        this.txt030c005_TaxCost.TabIndex = 57;
        // 
        // txt029c004_TaxPercentage
        // 
        this.txt029c004_TaxPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt029c004_TaxPercentage.Location = new System.Drawing.Point(149, 10);
        this.txt029c004_TaxPercentage.Name = "txt029c004_TaxPercentage";
        this.txt029c004_TaxPercentage.Size = new System.Drawing.Size(181, 26);
        this.txt029c004_TaxPercentage.TabIndex = 53;
        // 
        // txt028c003_LicenseCost
        // 
        this.txt028c003_LicenseCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt028c003_LicenseCost.Location = new System.Drawing.Point(457, 75);
        this.txt028c003_LicenseCost.Name = "txt028c003_LicenseCost";
        this.txt028c003_LicenseCost.Size = new System.Drawing.Size(181, 26);
        this.txt028c003_LicenseCost.TabIndex = 50;
        // 
        // txt027c002_data
        // 
        this.txt027c002_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt027c002_data.Location = new System.Drawing.Point(457, 42);
        this.txt027c002_data.Name = "txt027c002_data";
        this.txt027c002_data.Size = new System.Drawing.Size(181, 26);
        this.txt027c002_data.TabIndex = 51;
        // 
        // txt026c001_invoiceNumber
        // 
        this.txt026c001_invoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt026c001_invoiceNumber.Location = new System.Drawing.Point(457, 10);
        this.txt026c001_invoiceNumber.Name = "txt026c001_invoiceNumber";
        this.txt026c001_invoiceNumber.Size = new System.Drawing.Size(181, 26);
        this.txt026c001_invoiceNumber.TabIndex = 47;
        // 
        // btn030PayPanel
        // 
        this.btn030PayPanel.BackColor = System.Drawing.SystemColors.ControlLight;
        this.btn030PayPanel.FlatAppearance.BorderSize = 0;
        this.btn030PayPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn030PayPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn030PayPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn030PayPanel.Location = new System.Drawing.Point(6, 11);
        this.btn030PayPanel.Name = "btn030PayPanel";
        this.btn030PayPanel.Size = new System.Drawing.Size(132, 90);
        this.btn030PayPanel.TabIndex = 58;
        this.btn030PayPanel.Text = "السداد  >>";
        this.btn030PayPanel.UseVisualStyleBackColor = false;
        this.btn030PayPanel.Click += new System.EventHandler(this.btn030PayPanel_Click);
        // 
        // label27
        // 
        this.label27.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label27.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label27.Location = new System.Drawing.Point(335, 76);
        this.label27.Name = "label27";
        this.label27.Size = new System.Drawing.Size(109, 26);
        this.label27.TabIndex = 54;
        this.label27.Text = "إجمالي الفاتورة :";
        this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label28
        // 
        this.label28.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label28.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label28.Location = new System.Drawing.Point(335, 43);
        this.label28.Name = "label28";
        this.label28.Size = new System.Drawing.Size(109, 26);
        this.label28.TabIndex = 55;
        this.label28.Text = "مبلغ الضريبة :";
        this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label29
        // 
        this.label29.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label29.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label29.Location = new System.Drawing.Point(335, 11);
        this.label29.Name = "label29";
        this.label29.Size = new System.Drawing.Size(109, 26);
        this.label29.TabIndex = 52;
        this.label29.Text = "نسبة الضريبة :";
        this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label25
        // 
        this.label25.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label25.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label25.Location = new System.Drawing.Point(645, 75);
        this.label25.Name = "label25";
        this.label25.Size = new System.Drawing.Size(109, 26);
        this.label25.TabIndex = 48;
        this.label25.Text = "السعر :";
        this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label30
        // 
        this.label30.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label30.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label30.Location = new System.Drawing.Point(645, 42);
        this.label30.Name = "label30";
        this.label30.Size = new System.Drawing.Size(109, 26);
        this.label30.TabIndex = 49;
        this.label30.Text = "تاريخ الصدور :";
        this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label31
        // 
        this.label31.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label31.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label31.Location = new System.Drawing.Point(645, 10);
        this.label31.Name = "label31";
        this.label31.Size = new System.Drawing.Size(109, 26);
        this.label31.TabIndex = 46;
        this.label31.Text = "الرقم :";
        this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // tabPage1
        // 
        this.tabPage1.Controls.Add(this.pnl004);
        this.tabPage1.Controls.Add(this.pnl002);
        this.tabPage1.Controls.Add(this.pnl003);
        this.tabPage1.Location = new System.Drawing.Point(4, 33);
        this.tabPage1.Name = "tabPage1";
        this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage1.Size = new System.Drawing.Size(775, 440);
        this.tabPage1.TabIndex = 0;
        this.tabPage1.Text = "الاجهزة";
        this.tabPage1.UseVisualStyleBackColor = true;
        // 
        // pnl004
        // 
        this.pnl004.Controls.Add(this.dgv1);
        this.pnl004.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnl004.Location = new System.Drawing.Point(3, 148);
        this.pnl004.Name = "pnl004";
        this.pnl004.Size = new System.Drawing.Size(769, 289);
        this.pnl004.TabIndex = 39;
        // 
        // dgv1
        // 
        this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgv1.Location = new System.Drawing.Point(0, 0);
        this.dgv1.Name = "dgv1";
        this.dgv1.Size = new System.Drawing.Size(769, 289);
        this.dgv1.TabIndex = 37;
        this.dgv1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv1_CellMouseDoubleClick);
        // 
        // pnl002
        // 
        this.pnl002.Controls.Add(this.btn22AddDevice);
        this.pnl002.Controls.Add(this.txt025c006_deviceUses);
        this.pnl002.Controls.Add(this.label26);
        this.pnl002.Controls.Add(this.txt024c005_location);
        this.pnl002.Controls.Add(this.label24);
        this.pnl002.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnl002.Location = new System.Drawing.Point(3, 62);
        this.pnl002.Name = "pnl002";
        this.pnl002.Size = new System.Drawing.Size(769, 86);
        this.pnl002.TabIndex = 38;
        this.pnl002.Visible = false;
        // 
        // btn22AddDevice
        // 
        this.btn22AddDevice.BackColor = System.Drawing.SystemColors.ControlLight;
        this.btn22AddDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn22AddDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
        this.btn22AddDevice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn22AddDevice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn22AddDevice.Location = new System.Drawing.Point(19, 14);
        this.btn22AddDevice.Name = "btn22AddDevice";
        this.btn22AddDevice.Size = new System.Drawing.Size(93, 58);
        this.btn22AddDevice.TabIndex = 36;
        this.btn22AddDevice.Text = "إضافة";
        this.btn22AddDevice.UseVisualStyleBackColor = false;
        this.btn22AddDevice.Click += new System.EventHandler(this.btn22AddDevice_Click);
        // 
        // txt025c006_deviceUses
        // 
        this.txt025c006_deviceUses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
        this.txt025c006_deviceUses.Location = new System.Drawing.Point(116, 45);
        this.txt025c006_deviceUses.Multiline = true;
        this.txt025c006_deviceUses.Name = "txt025c006_deviceUses";
        this.txt025c006_deviceUses.Size = new System.Drawing.Size(520, 27);
        this.txt025c006_deviceUses.TabIndex = 13;
        // 
        // label26
        // 
        this.label26.BackColor = System.Drawing.Color.WhiteSmoke;
        this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
        this.label26.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label26.Location = new System.Drawing.Point(642, 45);
        this.label26.Name = "label26";
        this.label26.Size = new System.Drawing.Size(101, 27);
        this.label26.TabIndex = 12;
        this.label26.Text = "إستخدام الجهاز :";
        this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt024c005_location
        // 
        this.txt024c005_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
        this.txt024c005_location.Location = new System.Drawing.Point(116, 14);
        this.txt024c005_location.Multiline = true;
        this.txt024c005_location.Name = "txt024c005_location";
        this.txt024c005_location.Size = new System.Drawing.Size(520, 27);
        this.txt024c005_location.TabIndex = 11;
        // 
        // label24
        // 
        this.label24.BackColor = System.Drawing.Color.WhiteSmoke;
        this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
        this.label24.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label24.Location = new System.Drawing.Point(642, 14);
        this.label24.Name = "label24";
        this.label24.Size = new System.Drawing.Size(101, 27);
        this.label24.TabIndex = 10;
        this.label24.Text = "موقع الجهاز :";
        this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pnl003
        // 
        this.pnl003.Controls.Add(this.btn20forAddDevice);
        this.pnl003.Controls.Add(this.btn21DeleteDevice);
        this.pnl003.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnl003.Location = new System.Drawing.Point(3, 3);
        this.pnl003.Name = "pnl003";
        this.pnl003.Size = new System.Drawing.Size(769, 59);
        this.pnl003.TabIndex = 37;
        // 
        // btn20forAddDevice
        // 
        this.btn20forAddDevice.BackColor = System.Drawing.SystemColors.ControlLight;
        this.btn20forAddDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn20forAddDevice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn20forAddDevice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn20forAddDevice.Location = new System.Drawing.Point(385, 12);
        this.btn20forAddDevice.Name = "btn20forAddDevice";
        this.btn20forAddDevice.Size = new System.Drawing.Size(360, 35);
        this.btn20forAddDevice.TabIndex = 37;
        this.btn20forAddDevice.Text = "إضافة الجهاز الحالي >>";
        this.btn20forAddDevice.UseVisualStyleBackColor = false;
        this.btn20forAddDevice.Click += new System.EventHandler(this.btn20forAddDevice_Click);
        // 
        // btn21DeleteDevice
        // 
        this.btn21DeleteDevice.BackColor = System.Drawing.SystemColors.ControlLight;
        this.btn21DeleteDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn21DeleteDevice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn21DeleteDevice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn21DeleteDevice.Location = new System.Drawing.Point(19, 12);
        this.btn21DeleteDevice.Name = "btn21DeleteDevice";
        this.btn21DeleteDevice.Size = new System.Drawing.Size(360, 35);
        this.btn21DeleteDevice.TabIndex = 36;
        this.btn21DeleteDevice.Text = "حذف الجهاز الحالي";
        this.btn21DeleteDevice.UseVisualStyleBackColor = false;
        this.btn21DeleteDevice.Click += new System.EventHandler(this.btn21DeleteDevice_Click);
        // 
        // tabControl1
        // 
        this.tabControl1.Controls.Add(this.tabPage1);
        this.tabControl1.Controls.Add(this.tabPage2);
        this.tabControl1.Enabled = false;
        this.tabControl1.Location = new System.Drawing.Point(320, 285);
        this.tabControl1.Name = "tabControl1";
        this.tabControl1.RightToLeftLayout = true;
        this.tabControl1.SelectedIndex = 0;
        this.tabControl1.Size = new System.Drawing.Size(783, 477);
        this.tabControl1.TabIndex = 36;
        this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
        // 
        // cmb01c002_PackageName
        // 
        this.cmb01c002_PackageName.Enabled = false;
        this.cmb01c002_PackageName.FormattingEnabled = true;
        this.cmb01c002_PackageName.Items.AddRange(new object[] {
            "Mesrakh",
            "non"});
        this.cmb01c002_PackageName.Location = new System.Drawing.Point(413, 135);
        this.cmb01c002_PackageName.Name = "cmb01c002_PackageName";
        this.cmb01c002_PackageName.Size = new System.Drawing.Size(273, 32);
        this.cmb01c002_PackageName.TabIndex = 37;
        this.cmb01c002_PackageName.SelectedIndexChanged += new System.EventHandler(this.cmb01c002_PackageName_SelectedIndexChanged);
        // 
        // btn09New
        // 
        this.btn09New.BackColor = System.Drawing.Color.Gainsboro;
        this.btn09New.Enabled = false;
        this.btn09New.FlatAppearance.BorderSize = 0;
        this.btn09New.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn09New.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn09New.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn09New.Location = new System.Drawing.Point(320, 210);
        this.btn09New.Name = "btn09New";
        this.btn09New.Size = new System.Drawing.Size(198, 35);
        this.btn09New.TabIndex = 38;
        this.btn09New.Text = "جديد";
        this.btn09New.UseVisualStyleBackColor = false;
        this.btn09New.Click += new System.EventHandler(this.btn09New_Click);
        // 
        // btn10Delete
        // 
        this.btn10Delete.BackColor = System.Drawing.Color.Gainsboro;
        this.btn10Delete.Enabled = false;
        this.btn10Delete.FlatAppearance.BorderSize = 0;
        this.btn10Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn10Delete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn10Delete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn10Delete.Location = new System.Drawing.Point(912, 210);
        this.btn10Delete.Name = "btn10Delete";
        this.btn10Delete.Size = new System.Drawing.Size(191, 35);
        this.btn10Delete.TabIndex = 38;
        this.btn10Delete.Text = "حذف";
        this.btn10Delete.UseVisualStyleBackColor = false;
        this.btn10Delete.Click += new System.EventHandler(this.btn10Delete_Click);
        // 
        // btn11Save
        // 
        this.btn11Save.BackColor = System.Drawing.Color.Gainsboro;
        this.btn11Save.Enabled = false;
        this.btn11Save.FlatAppearance.BorderSize = 0;
        this.btn11Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btn11Save.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.btn11Save.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.btn11Save.Location = new System.Drawing.Point(520, 210);
        this.btn11Save.Name = "btn11Save";
        this.btn11Save.Size = new System.Drawing.Size(390, 35);
        this.btn11Save.TabIndex = 39;
        this.btn11Save.Text = "حفظ";
        this.btn11Save.UseVisualStyleBackColor = false;
        this.btn11Save.Click += new System.EventHandler(this.btn11Save_Click);
        // 
        // label37
        // 
        this.label37.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label37.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label37.Location = new System.Drawing.Point(320, 173);
        this.label37.Name = "label37";
        this.label37.Size = new System.Drawing.Size(89, 24);
        this.label37.TabIndex = 42;
        this.label37.Text = "سعر الباقة :";
        this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt040c002_price
        // 
        this.txt040c002_price.Enabled = false;
        this.txt040c002_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt040c002_price.Location = new System.Drawing.Point(413, 173);
        this.txt040c002_price.Name = "txt040c002_price";
        this.txt040c002_price.Size = new System.Drawing.Size(274, 26);
        this.txt040c002_price.TabIndex = 41;
        // 
        // label38
        // 
        this.label38.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.label38.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label38.Location = new System.Drawing.Point(912, 75);
        this.label38.Name = "label38";
        this.label38.Size = new System.Drawing.Size(91, 24);
        this.label38.TabIndex = 44;
        this.label38.Text = "عدد الأجهزة :";
        this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txt035c005_packageDevicesNumber
        // 
        this.txt035c005_packageDevicesNumber.Enabled = false;
        this.txt035c005_packageDevicesNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        this.txt035c005_packageDevicesNumber.Location = new System.Drawing.Point(1009, 75);
        this.txt035c005_packageDevicesNumber.Name = "txt035c005_packageDevicesNumber";
        this.txt035c005_packageDevicesNumber.Size = new System.Drawing.Size(93, 26);
        this.txt035c005_packageDevicesNumber.TabIndex = 43;
        // 
        // panel1
        // 
        this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
        this.panel1.Controls.Add(this.label39);
        this.panel1.Controls.Add(this.btnExit);
        this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
        this.panel1.Location = new System.Drawing.Point(0, 0);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(1124, 53);
        this.panel1.TabIndex = 45;
        this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
        this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
        this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
        // 
        // label39
        // 
        this.label39.AutoSize = true;
        this.label39.BackColor = System.Drawing.Color.Transparent;
        this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
        this.label39.ForeColor = System.Drawing.Color.White;
        this.label39.Location = new System.Drawing.Point(505, 12);
        this.label39.Name = "label39";
        this.label39.Size = new System.Drawing.Size(115, 29);
        this.label39.TabIndex = 8;
        this.label39.Text = "إدارة الحساب";
        // 
        // frmAccountManagement
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.WhiteSmoke;
        this.ClientSize = new System.Drawing.Size(1124, 786);
        this.Controls.Add(this.panel1);
        this.Controls.Add(this.label38);
        this.Controls.Add(this.txt035c005_packageDevicesNumber);
        this.Controls.Add(this.label37);
        this.Controls.Add(this.txt040c002_price);
        this.Controls.Add(this.btn11Save);
        this.Controls.Add(this.btn10Delete);
        this.Controls.Add(this.btn09New);
        this.Controls.Add(this.cmb01c002_PackageName);
        this.Controls.Add(this.tabControl1);
        this.Controls.Add(this.btn08last);
        this.Controls.Add(this.btn07next);
        this.Controls.Add(this.btn06previes);
        this.Controls.Add(this.btn05first);
        this.Controls.Add(this.label23);
        this.Controls.Add(this.label22);
        this.Controls.Add(this.label21);
        this.Controls.Add(this.label20);
        this.Controls.Add(this.label19);
        this.Controls.Add(this.label18);
        this.Controls.Add(this.label17);
        this.Controls.Add(this.txt023c007_LicenseEndDate);
        this.Controls.Add(this.txt022c004_PackageDuration);
        this.Controls.Add(this.txt021c003_information);
        this.Controls.Add(this.txt020c004_DateOfLicenseStart);
        this.Controls.Add(this.txt019c003_DateOfLicenseRequest);
        this.Controls.Add(this.txt017c001_licenseNo);
        this.Controls.Add(this.pnl001);
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
        this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Margin = new System.Windows.Forms.Padding(6);
        this.Name = "frmAccountManagement";
        this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.RightToLeftLayout = true;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Form1";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccountManagement_FormClosing);
        this.Load += new System.EventHandler(this.frm001_main_Load);
        this.pnl001.ResumeLayout(false);
        this.pnl001002.ResumeLayout(false);
        this.pnl001002.PerformLayout();
        this.pnl001001.ResumeLayout(false);
        this.pnl001001.PerformLayout();
        this.tabPage2.ResumeLayout(false);
        this.pnl007.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
        this.pnl006.ResumeLayout(false);
        this.pnl006.PerformLayout();
        this.pnl005.ResumeLayout(false);
        this.pnl005.PerformLayout();
        this.tabPage1.ResumeLayout(false);
        this.pnl004.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
        this.pnl002.ResumeLayout(false);
        this.pnl002.PerformLayout();
        this.pnl003.ResumeLayout(false);
        this.tabControl1.ResumeLayout(false);
        this.panel1.ResumeLayout(false);
        this.panel1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }


    private System.Windows.Forms.Panel pnl001;
    private System.Windows.Forms.Panel pnl001001;
    private System.Windows.Forms.Panel pnl001002;
    private System.Windows.Forms.Button btn02_CreateNewAccount;
    private System.Windows.Forms.Button btn01_LoginToAccount;
    private System.Windows.Forms.TextBox txt002c003_password;
    private System.Windows.Forms.TextBox txt001c002_userName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txt011c009_Street;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox txt010c008_BuildingNo;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txt009c007_ShortAddress;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox txt008c006_ClientEmail;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txt007c005_ClientPhone;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txt006c004_ClientName;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txt005c003_password;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txt004c002_userName;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txt003c001_AccountNo;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btn04_cancel;
    private System.Windows.Forms.Button btn03_send;
    private System.Windows.Forms.TextBox txt016c014_country;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.TextBox txt015c013_City;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.TextBox txt014c012_PostalCode;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.TextBox txt013c011_District;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox txt012c010_SecondaryNo;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label lbl001;
    private System.Windows.Forms.Button btn20Exit;
    private System.Windows.Forms.TextBox txt017c001_licenseNo;
    private System.Windows.Forms.TextBox txt019c003_DateOfLicenseRequest;
    private System.Windows.Forms.TextBox txt020c004_DateOfLicenseStart;
    private System.Windows.Forms.TextBox txt021c003_information;
    private System.Windows.Forms.TextBox txt022c004_PackageDuration;
    private System.Windows.Forms.TextBox txt023c007_LicenseEndDate;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.Label label21;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.Label label23;
    private System.Windows.Forms.Button btn05first;
    private System.Windows.Forms.Button btn06previes;
    private System.Windows.Forms.Button btn07next;
    private System.Windows.Forms.Button btn08last;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.Panel pnl004;
    private System.Windows.Forms.DataGridView dgv1;
    private System.Windows.Forms.Panel pnl002;
    private System.Windows.Forms.Button btn22AddDevice;
    private System.Windows.Forms.TextBox txt025c006_deviceUses;
    private System.Windows.Forms.Label label26;
    private System.Windows.Forms.TextBox txt024c005_location;
    private System.Windows.Forms.Label label24;
    private System.Windows.Forms.Panel pnl003;
    private System.Windows.Forms.Button btn20forAddDevice;
    private System.Windows.Forms.Button btn21DeleteDevice;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.ComboBox cmb01c002_PackageName;
    private System.Windows.Forms.Button btn09New;
    private System.Windows.Forms.Button btn10Delete;
    private System.Windows.Forms.Button btn11Save;
    private System.Windows.Forms.Panel pnl006;
    private System.Windows.Forms.Button btn031Pay;
    private System.Windows.Forms.TextBox txt036c006_TransferAmount;
    private System.Windows.Forms.TextBox txt035c005_TransferTime;
    private System.Windows.Forms.TextBox txt034c004_TransferDate;
    private System.Windows.Forms.TextBox txt033c003_TransferBank;
    private System.Windows.Forms.TextBox txt032c002_TransferBanckNumber;
    private System.Windows.Forms.Label label36;
    private System.Windows.Forms.Label label32;
    private System.Windows.Forms.Label label33;
    private System.Windows.Forms.Label label34;
    private System.Windows.Forms.Label label35;
    private System.Windows.Forms.Panel pnl005;
    private System.Windows.Forms.TextBox txt031c016_AllCost;
    private System.Windows.Forms.TextBox txt030c005_TaxCost;
    private System.Windows.Forms.TextBox txt029c004_TaxPercentage;
    private System.Windows.Forms.TextBox txt028c003_LicenseCost;
    private System.Windows.Forms.TextBox txt027c002_data;
    private System.Windows.Forms.TextBox txt026c001_invoiceNumber;
    private System.Windows.Forms.Button btn030PayPanel;
    private System.Windows.Forms.Label label27;
    private System.Windows.Forms.Label label28;
    private System.Windows.Forms.Label label29;
    private System.Windows.Forms.Label label25;
    private System.Windows.Forms.Label label30;
    private System.Windows.Forms.Label label31;
    private System.Windows.Forms.Panel pnl007;
    private System.Windows.Forms.DataGridView dgv2;
    private System.Windows.Forms.Label label37;
    private System.Windows.Forms.TextBox txt040c002_price;
    private System.Windows.Forms.ComboBox cmb002;
    private System.Windows.Forms.Label label38;
    private System.Windows.Forms.TextBox txt035c005_packageDevicesNumber;

    private void btnExit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }








    //**************************************************************************************************************************************************************************************************************************************************
    //**************************************************************************************************************************************************************************************************************************************************





    /*
        // كيفية استخدام هذا الكلاس
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=52.147.200.137;Initial Catalog=licenses;User ID=sa;Password=Aah51771#");
            con.Open();
            AccountManagement frm = new AccountManagement(con);
            frm.Show();
        }
    */
    public frmAccountManagement()
    {
        InitializeComponent();
    }

    //SqlConnection con = new SqlConnection("Data Source=52.147.200.137;Initial Catalog=licenses;User ID=sa;Password=Aah51771#");

    DataTable tblaccount = new DataTable();
    DataTable tbllicense = new DataTable();
    DataTable tbldevices = new DataTable();
    DataTable tblPackages = new DataTable();
    DataTable tblInvoices = new DataTable();

    DataTable tbldevicesDatatableSUB = new DataTable();
    DataTable tblInvoicesSUB = new DataTable();

    int RowNumberLicense = 0;
    private Button btnExit;
    private Panel panel1;
    private Label label39;
    ////////////////////int RowNumberDevices = 0;



    private void frm001_main_Load(object sender, EventArgs e)
    {
        try
        {
            pnl001002.Visible = false;
            txt001c002_userName.Focus();

            foreach (Control con in this.Controls)
            {
                if (con.Name != "pnl001" && con.Name != "panel1") { con.Visible = false; }
            }
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------   ????????  1
            //try
            //{
            //    if(!(ConnectionsTools.Conlicenses() is null))
            //    {
            //        if (ConnectionsTools.Conlicenses().State == ConnectionState.Closed) { ConnectionsTools.Conlicenses().Open(); }
            //    }
            //    else
            //    {
            //        throw new Exception("Connection Object is Null ");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    // اذا لم يتوفر اتصال سيتم فتح نافذة اعداد الاتصال
            //this.Invoke((MethodInvoker)delegate
            //{
            //    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation(23), Cultures.ReturnTranslation(24), MessageBoxStatus.YesAndNo);
            //    if (GeneralVariables.MessageBoxResult == "Yes")
            //    {
            //        this.Hide();
            //        Mesrakh.frmConnectionSettings02 frm = new Mesrakh.frmConnectionSettings02();
            //        frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            //        frm.StartPosition = FormStartPosition.CenterScreen;
            //        frm.ShowDialog();
            //        Application.Exit();
            //    }
            //    else
            //    {
            //        Application.Exit();
            //    }
            //    //});
            //}

            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------  ?????????  1

            btnExit.Visible = true;
            btnExit.ForeColor = Color.DarkRed;
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  frm001_main_Load  ", DateTime.Now, ex.Message, ex.Message);
        }
        
    }

    // تعبئة جدول الباقات
    public void filltbl008Packages()
    {
        try
        {
            SqlCommand com = new SqlCommand("select * from tbl008Packages", ConnectionsTools.Conlicenses());
            tblPackages.Load(com.ExecuteReader());
            fillcmb01c002_PackageName();
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  filltbl008Packages  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    public void fillcmb01c002_PackageName()
    {
        try
        {
            cmb01c002_PackageName.DataSource = tblPackages;
            cmb01c002_PackageName.DisplayMember = "c001_package";
            cmb01c002_PackageName.ValueMember = "c001_package";
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  fillcmb01c002_PackageName  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    // تعبئة جدول الحسابت
    public void filltbl002_Accounts()
    {
        try
        {
            tblaccount.Rows.Clear();
            string CommandString = string.Format("select * from tbl002_Accounts where c002_userName = '{0}' and c003_password = '{1}'", txt001c002_userName.Text, txt002c003_password.Text);
            SqlCommand com = new SqlCommand(CommandString, ConnectionsTools.Conlicenses());
            tblaccount.Load(com.ExecuteReader());

            filltbl003_licenses();
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  filltbl002_Accounts  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    // تعبئة جدول الرخص
    public void filltbl003_licenses()
    {
        try
        {
            formNurmal();
            if (tblaccount.Rows.Count > 0)
            {
                filltbl008Packages();

                tbllicense.Rows.Clear();
                RowNumberLicense = 0;
                string CommandString2 = string.Format("select * from tbl003_licenses  where c008_AccountNo = '{0}' ", tblaccount.Rows[0][0].ToString());
                SqlCommand com2 = new SqlCommand(CommandString2, ConnectionsTools.Conlicenses());
                tbllicense.Load(com2.ExecuteReader());

                filltblInvoices(); // تعبئة جدول الفواتير
                filltbl001_devices(); //  تعبئة جدول الاجهزة
                showLicense();

            }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  filltbl003_licenses  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    // تعبئة جدول الاجهزة الرئيسي
    public void filltbl001_devices()
    {
        try
        {
            tbldevices.Rows.Clear();
            ////////////////////RowNumberDevices = 0;
            string CommandString3 = string.Format("select * from tbl001_devices  inner join  tbl004_licenseAndDevices on   tbl004_licenseAndDevices.c002_deviceAuotoNo = tbl001_devices.c001_deviceAuotoNo inner join   tbl003_licenses on tbl003_licenses.c001_licenseNo = tbl004_licenseAndDevices.c003_licensNo where c008_AccountNo = '{0}' ", tblaccount.Rows[0][0].ToString());
            SqlCommand com3 = new SqlCommand(CommandString3, ConnectionsTools.Conlicenses());
            tbldevices.Load(com3.ExecuteReader());
            if (tbldevicesDatatableSUB.Columns.Count == 0) { BuildDevicesSUB(); }
            fileDevicesDatatableSUB();
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  filltbl001_devices  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    // بناء جدول الاجهزة الفرعي
    public void BuildDevicesSUB()
    {
        try
        {
            tbldevicesDatatableSUB.Rows.Clear();
            tbldevicesDatatableSUB.Columns.Clear();
            foreach (DataColumn dc in tbldevices.Columns)
            {
                tbldevicesDatatableSUB.Columns.Add(dc.ColumnName, dc.DataType);
            }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  BuildDevicesSUB  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    // تعبئة جدول الاجهزة الفرعي 
    public void fileDevicesDatatableSUB()
    {
        try
        {
            if (tbldevices.Rows.Count > 0)
            {
                tbldevicesDatatableSUB.Rows.Clear();
                ////////////////////////////RowNumberDevices = 0;

                string commandString = "c003_licensNo = " + tbllicense.Rows[RowNumberLicense][0].ToString();
                DataRow[] drArray = tbldevices.Select(commandString);
                if (drArray.Length > 0)
                {

                    foreach (DataRow dr in drArray)
                    {
                        tbldevicesDatatableSUB.ImportRow(dr);
                    }

                }
                ShowDevices();
            }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  BuildDevicesSUB  ", DateTime.Now, ex.Message, ex.Message);
        }
    }

    // عرض بيانات الاجهزة
    public void ShowDevices()
    {
        try
        {
            // ستايل جدول البيانات
            dgv1.BorderStyle = BorderStyle.None;
            dgv1.AllowUserToAddRows = false;
            dgv1.ReadOnly = true;
            //dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;  // الغاء اطار عناوين الاعمدة


            dgv1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // محاذات النص في الخلايا
                                                                                         //dgv1.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                                                                                         //dgv1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv1.EnableHeadersVisualStyles = true;
            dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv1.ColumnHeadersVisible = false;
            dgv1.RowHeadersVisible = false;

            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(211, 211, 211);
            dgv1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgv1.DefaultCellStyle.ForeColor = Color.White;
            dgv1.BackgroundColor = Color.FromArgb(211, 211, 211);
            dgv1.RowsDefaultCellStyle.BackColor = Color.FromArgb(211, 211, 211);
            dgv1.RowsDefaultCellStyle.ForeColor = Color.White;
            dgv1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(161, 143, 95);
            dgv1.DefaultCellStyle.SelectionForeColor = Color.White;


            // ارتفاع الصفوف
            foreach (DataGridViewRow item in dgv1.Rows)
            {
                item.Height = 30;
            }

            if (tbldevicesDatatableSUB.Rows.Count > 0)
            {
                dgv1.DataSource = tbldevicesDatatableSUB;

                dgv1.Columns[1].Visible = false;
                dgv1.Columns[2].Visible = false;
                dgv1.Columns[3].Visible = false;
                dgv1.Columns[4].Visible = false;
                dgv1.Columns[5].Visible = false;
                dgv1.Columns[6].Visible = false;

                dgv1.Columns[9].Visible = false;
                dgv1.Columns[10].Visible = false;
                dgv1.Columns[11].Visible = false;
                dgv1.Columns[12].Visible = false;
                dgv1.Columns[13].Visible = false;
                dgv1.Columns[14].Visible = false;
                dgv1.Columns[15].Visible = false;
                dgv1.Columns[16].Visible = false;

                dgv1.Columns[0].HeaderText = "الرقم";
                dgv1.Columns[7].HeaderText = "موقع الجهاز";
                dgv1.Columns[8].HeaderText = "إستخدامات الجهاز";

                dgv1.Columns[0].Width = 100;
                dgv1.Columns[7].Width = 300;
                dgv1.Columns[8].Width = pnl004.Width - 400 - 2;

            }
            else
            {
                dgv1.DataSource = new DataTable();
            }

        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  ShowDevices  ", DateTime.Now, ex.Message, ex.Message);
        }
        

    }

    // الوضع الطبيعي للنموذج
    public void formNurmal()
    {
        try
        {
            foreach (Control con in this.Controls)
            {
                con.Visible = true;
            }
            pnl002.Visible = false;

            //btn20Exit.Visible = false;

            txt017c001_licenseNo.Text = "";
            cmb01c002_PackageName.SelectedIndex = 0;
            txt019c003_DateOfLicenseRequest.Text = "";
            txt020c004_DateOfLicenseStart.Text = "";
            txt021c003_information.Text = "";
            txt022c004_PackageDuration.Text = "";
            txt023c007_LicenseEndDate.Text = "";

            txt017c001_licenseNo.Enabled = false;
            cmb01c002_PackageName.Enabled = false;
            txt019c003_DateOfLicenseRequest.Enabled = false;
            txt020c004_DateOfLicenseStart.Enabled = false;
            txt021c003_information.Enabled = false;
            txt022c004_PackageDuration.Enabled = false;
            txt023c007_LicenseEndDate.Enabled = false;

            btn09New.Text = "جديد";
            btn11Save.Enabled = false;


            txt003c001_AccountNo.Enabled = false;
            txt004c002_userName.Enabled = false;
            txt005c003_password.Visible = false;
            txt006c004_ClientName.Enabled = false;
            txt007c005_ClientPhone.Enabled = false;
            txt008c006_ClientEmail.Enabled = false;
            txt009c007_ShortAddress.Enabled = false;
            txt010c008_BuildingNo.Enabled = false;
            txt011c009_Street.Enabled = false;
            txt012c010_SecondaryNo.Enabled = false;
            txt013c011_District.Enabled = false;
            txt014c012_PostalCode.Enabled = false;
            txt015c013_City.Enabled = false;
            txt016c014_country.Enabled = false;
            btn03_send.Visible = false;
            btn04_cancel.Visible = false;

            pnl001002.Visible = false;




            tabControl1.Enabled = true;
            btn05first.Enabled = true;
            btn06previes.Enabled = true;
            btn07next.Enabled = true;
            btn08last.Enabled = true;
            btn09New.Enabled = true;
            btn10Delete.Enabled = true;


        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  formNurmal  ", DateTime.Now, ex.Message, ex.Message);
        }
        

    }

    // تسجيل الدخول
    private void btn01_LoginToAccount_Click(object sender, EventArgs e)
    {
        try
        {
            pnl001002.Visible = false;
            txt003c001_AccountNo.Enabled = false;
            txt004c002_userName.Enabled = false;
            txt005c003_password.Enabled = false;
            txt006c004_ClientName.Enabled = false;
            txt007c005_ClientPhone.Enabled = false;
            txt008c006_ClientEmail.Enabled = false;
            txt009c007_ShortAddress.Enabled = false;
            txt010c008_BuildingNo.Enabled = false;
            txt011c009_Street.Enabled = false;
            txt012c010_SecondaryNo.Enabled = false;
            txt013c011_District.Enabled = false;
            txt014c012_PostalCode.Enabled = false;
            txt015c013_City.Enabled = false;
            txt016c014_country.Enabled = false;

            lbl001.Text = "";

            txt003c001_AccountNo.Text = "";
            txt004c002_userName.Text = "";
            txt005c003_password.Text = "";
            txt006c004_ClientName.Text = "";
            txt007c005_ClientPhone.Text = "";
            txt008c006_ClientEmail.Text = "";
            txt009c007_ShortAddress.Text = "";
            txt010c008_BuildingNo.Text = "";
            txt011c009_Street.Text = "";
            txt012c010_SecondaryNo.Text = "";
            txt013c011_District.Text = "";
            txt014c012_PostalCode.Text = "";
            txt015c013_City.Text = "";
            txt016c014_country.Text = "";

            btn03_send.Visible = false;
            btn04_cancel.Visible = false;

            txt001c002_userName.Focus();

            if (txt001c002_userName.Text.Trim() != "" && txt002c003_password.Text.Trim() != "")
            {

                filltbl002_Accounts();

                if (tblaccount.Rows.Count == 1)
                {
                    lbl001.Text = tblaccount.Rows[0][3].ToString();

                    txt001c002_userName.Text = "";
                    txt002c003_password.Text = "";
                    txt001c002_userName.Enabled = false;
                    txt002c003_password.Enabled = false;

                    btn01_LoginToAccount.Enabled = false;
                    btn02_CreateNewAccount.Enabled = false;

                    btn20Exit.Visible = true;

                }
                else { lbl001.Text = "لا يوجد حساب بهذه البيانات "; }

            }
            else { lbl001.Text = "رجاء قم بتعبئة إسم المستخدم وحقل كلمة المرور"; }

            pnl002.Visible = false;
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  btn01_LoginToAccount_Click  ", DateTime.Now, ex.Message, ex.Message);
        }
        

    }



    private void btn02_CreateNewAccount_Click(object sender, EventArgs e)
    {
        lbl001.Text = "";
        txt003c001_AccountNo.Text = "";
        txt004c002_userName.Text = "";
        txt005c003_password.Text = "";
        txt006c004_ClientName.Text = "";
        txt007c005_ClientPhone.Text = "";
        txt008c006_ClientEmail.Text = "";
        txt009c007_ShortAddress.Text = "";
        txt010c008_BuildingNo.Text = "";
        txt011c009_Street.Text = "";
        txt012c010_SecondaryNo.Text = "";
        txt013c011_District.Text = "";
        txt014c012_PostalCode.Text = "";
        txt015c013_City.Text = "";
        txt016c014_country.Text = "";


        pnl001002.Visible = true;

        txt003c001_AccountNo.Enabled = false;
        txt004c002_userName.Enabled = true;
        txt005c003_password.Visible = true;
        txt005c003_password.Enabled = true;
        txt006c004_ClientName.Enabled = true;
        txt007c005_ClientPhone.Enabled = true;
        txt008c006_ClientEmail.Enabled = true;
        txt009c007_ShortAddress.Enabled = true;
        txt010c008_BuildingNo.Enabled = true;
        txt011c009_Street.Enabled = true;
        txt012c010_SecondaryNo.Enabled = true;
        txt013c011_District.Enabled = true;
        txt014c012_PostalCode.Enabled = true;
        txt015c013_City.Enabled = true;
        txt016c014_country.Enabled = true;
        btn03_send.Visible = true;
        btn04_cancel.Visible = true;

        txt004c002_userName.Focus();
    }

    private void btn03_send_Click(object sender, EventArgs e)
    {
        try
        {
            string CommandString = @"insert into tbl002_Accounts (c002_userName,c003_password,c004_ClientName,c005_ClientPhone,c006_ClientEmail ,c007_ShortAddress,c008_BuildingNo,c009_Street,c010_SecondaryNo,c011_District,c012_PostalCode,c013_City,c014_country) values (@c002_userName,@c003_password,@c004_ClientName,@c005_ClientPhone,@c006_ClientEmail ,@c007_ShortAddress,@c008_BuildingNo,@c009_Street,@c010_SecondaryNo,@c011_District,@c012_PostalCode,@c013_City,@c014_country)";
            SqlCommand com = new SqlCommand(CommandString, ConnectionsTools.Conlicenses());
            com.Parameters.AddWithValue("@c002_userName", txt004c002_userName.Text);
            com.Parameters.AddWithValue("@c003_password", txt005c003_password.Text);
            com.Parameters.AddWithValue("@c004_ClientName", txt006c004_ClientName.Text);
            com.Parameters.AddWithValue("@c005_ClientPhone", txt007c005_ClientPhone.Text);
            com.Parameters.AddWithValue("@c006_ClientEmail", txt008c006_ClientEmail.Text);
            com.Parameters.AddWithValue("@c007_ShortAddress", txt009c007_ShortAddress.Text);
            com.Parameters.AddWithValue("@c008_BuildingNo", txt010c008_BuildingNo.Text);
            com.Parameters.AddWithValue("@c009_Street", txt011c009_Street.Text);
            com.Parameters.AddWithValue("@c010_SecondaryNo", txt012c010_SecondaryNo.Text);
            com.Parameters.AddWithValue("@c011_District", txt013c011_District.Text);
            com.Parameters.AddWithValue("@c012_PostalCode", txt014c012_PostalCode.Text);
            com.Parameters.AddWithValue("@c013_City", txt015c013_City.Text);
            com.Parameters.AddWithValue("@c014_country", txt016c014_country.Text);

            com.ExecuteNonQuery();



            pnl001002.Visible = false;
            txt003c001_AccountNo.Enabled = false;
            txt004c002_userName.Enabled = false;
            txt005c003_password.Enabled = false;
            txt006c004_ClientName.Enabled = false;
            txt007c005_ClientPhone.Enabled = false;
            txt008c006_ClientEmail.Enabled = false;
            txt009c007_ShortAddress.Enabled = false;
            txt010c008_BuildingNo.Enabled = false;
            txt011c009_Street.Enabled = false;
            txt012c010_SecondaryNo.Enabled = false;
            txt013c011_District.Enabled = false;
            txt014c012_PostalCode.Enabled = false;
            txt015c013_City.Enabled = false;
            txt016c014_country.Enabled = false;

            txt003c001_AccountNo.Text = "";
            txt004c002_userName.Text = "";
            txt005c003_password.Text = "";
            txt006c004_ClientName.Text = "";
            txt007c005_ClientPhone.Text = "";
            txt008c006_ClientEmail.Text = "";
            txt009c007_ShortAddress.Text = "";
            txt010c008_BuildingNo.Text = "";
            txt011c009_Street.Text = "";
            txt012c010_SecondaryNo.Text = "";
            txt013c011_District.Text = "";
            txt014c012_PostalCode.Text = "";
            txt015c013_City.Text = "";
            txt016c014_country.Text = "";

            btn03_send.Visible = false;
            btn04_cancel.Visible = false;

            txt001c002_userName.Focus();

        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  btn03_send_Click  ", DateTime.Now, ex.Message, ex.Message);
        }
        
    }

    private void btn04_cancel_Click(object sender, EventArgs e)
    {
        pnl001002.Visible = false;
        txt003c001_AccountNo.Enabled = false;
        txt004c002_userName.Enabled = false;
        txt005c003_password.Enabled = false;
        txt006c004_ClientName.Enabled = false;
        txt007c005_ClientPhone.Enabled = false;
        txt008c006_ClientEmail.Enabled = false;
        txt009c007_ShortAddress.Enabled = false;
        txt010c008_BuildingNo.Enabled = false;
        txt011c009_Street.Enabled = false;
        txt012c010_SecondaryNo.Enabled = false;
        txt013c011_District.Enabled = false;
        txt014c012_PostalCode.Enabled = false;
        txt015c013_City.Enabled = false;
        txt016c014_country.Enabled = false;

        txt003c001_AccountNo.Text = "";
        txt004c002_userName.Text = "";
        txt005c003_password.Text = "";
        txt006c004_ClientName.Text = "";
        txt007c005_ClientPhone.Text = "";
        txt008c006_ClientEmail.Text = "";
        txt009c007_ShortAddress.Text = "";
        txt010c008_BuildingNo.Text = "";
        txt011c009_Street.Text = "";
        txt012c010_SecondaryNo.Text = "";
        txt013c011_District.Text = "";
        txt014c012_PostalCode.Text = "";
        txt015c013_City.Text = "";
        txt016c014_country.Text = "";

        btn03_send.Visible = false;
        btn04_cancel.Visible = false;

        txt001c002_userName.Focus();
        pnl001002.Visible = false;

    }



    public void showLicense()
    {
        try
        {
            if (tbllicense.Rows.Count > 0)
            {
                if (tblPackages.Rows.Count > 0)
                {
                    int row = cmb01c002_PackageName.SelectedIndex;
                    txt040c002_price.Text = tblPackages.Rows[row][1].ToString();
                    txt021c003_information.Text = tblPackages.Rows[row][2].ToString();
                    txt022c004_PackageDuration.Text = tblPackages.Rows[row][3].ToString();
                }

                txt017c001_licenseNo.Text = tbllicense.Rows[RowNumberLicense][0].ToString();
                cmb01c002_PackageName.Text = tbllicense.Rows[RowNumberLicense][1].ToString();
                txt019c003_DateOfLicenseRequest.Text = (Convert.ToDateTime(tbllicense.Rows[RowNumberLicense][2].ToString())).ToString("yyyy-MM-dd");
                txt020c004_DateOfLicenseStart.Text = (Convert.ToDateTime(tbllicense.Rows[RowNumberLicense][3].ToString())).ToString("yyyy-MM-dd");
                txt023c007_LicenseEndDate.Text = (Convert.ToDateTime(tbllicense.Rows[RowNumberLicense][6].ToString())).ToString("yyyy-MM-dd");

            }
            filltblInvoicesSUB(); // ملئ بيانات الفواتير بناء على رقم الرخصة
            fileDevicesDatatableSUB(); // عرض بيانات الاجهزة بناء على رقم الرخصة

        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  showLicense  ", DateTime.Now, ex.Message, ex.Message);
        }
        
    }



    private void btn05first_Click(object sender, EventArgs e)
    {
        try
        {
            formNurmal();

            if (tbllicense.Rows.Count > 0)
            {
                RowNumberLicense = 0;
                showLicense();

            }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  btn05first_Click  ", DateTime.Now, ex.Message, ex.Message);
        }
        
    }

    private void btn06previes_Click(object sender, EventArgs e)
    {
        try
        {
            formNurmal();

            if (tbllicense.Rows.Count > 0)
            {
                if (RowNumberLicense > 0) { RowNumberLicense--; }
                showLicense();
            }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  btn06previes_Click  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    private void btn07next_Click(object sender, EventArgs e)
    {
        try
        {
            formNurmal();

            if (tbllicense.Rows.Count > 0)
            {
                if (RowNumberLicense < tbllicense.Rows.Count - 1) { RowNumberLicense++; }
                showLicense();
            }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  btn07next_Click  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    private void btn08last_Click(object sender, EventArgs e)
    {
        try
        {
            formNurmal();

            if (tbllicense.Rows.Count > 0)
            {
                RowNumberLicense = tbllicense.Rows.Count - 1;
                showLicense();
            }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  btn08last_Click  ", DateTime.Now, ex.Message, ex.Message);
        }

    }


    public void forNewLicense()
    {
        try
        {
            txt017c001_licenseNo.Text = "";
            cmb01c002_PackageName.SelectedIndex = 0;
            txt019c003_DateOfLicenseRequest.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            txt020c004_DateOfLicenseStart.Text = "";
            txt023c007_LicenseEndDate.Text = "";

            txt017c001_licenseNo.Enabled = false;
            cmb01c002_PackageName.Enabled = true;
            txt040c002_price.Enabled = false;
            txt021c003_information.Enabled = false;
            txt022c004_PackageDuration.Enabled = false;
            txt019c003_DateOfLicenseRequest.Enabled = false;
            txt020c004_DateOfLicenseStart.Enabled = false;
            txt023c007_LicenseEndDate.Enabled = false;

            btn11Save.Enabled = true;
            btn10Delete.Enabled = false;
            btn05first.Enabled = false;
            btn06previes.Enabled = false;
            btn07next.Enabled = false;
            btn08last.Enabled = false;

            tabControl1.Enabled = false;

            btn09New.Text = "إلغاء";
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  forNewLicense  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    private void btn09New_Click(object sender, EventArgs e)
    {
        if (btn09New.Text == "جديد")
        {
            forNewLicense();
        }
        else
        {

            formNurmal();
        }
    }

    private void btn11Save_Click(object sender, EventArgs e)
    {
        try
        {
            string commandString = "insert into tbl003_licenses (c002_PackageName,c003_DateOfLicenseRequest,c008_AccountNo) values (@c002_PackageName,@c003_DateOfLicenseRequest,@c008_AccountNo)";
            SqlCommand com = new SqlCommand(commandString, ConnectionsTools.Conlicenses());
            com.Parameters.AddWithValue("@c002_PackageName", cmb01c002_PackageName.Text);
            com.Parameters.AddWithValue("@c003_DateOfLicenseRequest", txt019c003_DateOfLicenseRequest.Text);
            com.Parameters.AddWithValue("@c008_AccountNo", tblaccount.Rows[0][0].ToString());
            com.ExecuteNonQuery();

            formNurmal();
            filltbl003_licenses();
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  btn11Save_Click  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    private void btn10Delete_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt017c001_licenseNo.Text.Trim() != "")
            {
                string commandString = "licenseDelete";
                SqlCommand com = new SqlCommand(commandString, ConnectionsTools.Conlicenses());
                com.CommandType = CommandType.StoredProcedure;
                string licenseNo = tbllicense.Rows[RowNumberLicense][0].ToString();
                com.Parameters.AddWithValue("@c001_licenseNo", licenseNo);
                com.ExecuteNonQuery();

                formNurmal();
                filltbl003_licenses();

            }
            else { MessageBox.Show("لا توجد بيانات للرخصةالمراد حذفها"); }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  btn10Delete_Click  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    // الخروج من الحساب
    private void btn20Exit_Click(object sender, EventArgs e)
    {
        try
        {
            formNurmal();
            txt001c002_userName.Text = "";
            txt002c003_password.Text = "";
            txt001c002_userName.Enabled = true;
            txt002c003_password.Enabled = true;
            btn01_LoginToAccount.Enabled = true;
            btn02_CreateNewAccount.Enabled = true;
            lbl001.Text = "";

            tblaccount.Rows.Clear();
            tbllicense.Rows.Clear();
            tbldevices.Rows.Clear();
            tbldevicesDatatableSUB.Rows.Clear();


            tabControl1.Enabled = false;
            btn05first.Enabled = false;
            btn06previes.Enabled = false;
            btn07next.Enabled = false;
            btn08last.Enabled = false;
            btn09New.Enabled = false;
            btn10Delete.Enabled = false;

            btn20Exit.Visible = false;
            foreach (Control con in this.Controls)
            {
                if (con.Name != "pnl001" && con.Name != "panel1") { con.Visible = false; }
            }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  btn10Delete_Click  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    private void btn20forAddDevice_Click(object sender, EventArgs e)
    {
        if (btn20forAddDevice.Text == "إضافة الجهاز الحالي >>")
        {
            pnl002.Visible = true;
            btn20forAddDevice.Text = "إضافة الجهاز الحالي <<";
        }
        else
        {
            pnl002.Visible = false;
            btn20forAddDevice.Text = "إضافة الجهاز الحالي >>";
        }

    }

    private void btn22AddDevice_Click(object sender, EventArgs e)
    {
        try
        {
            pnl002.Visible = false;
            btn20forAddDevice.Text = "إضافة الجهاز الحالي >>";

            //-----  يجب اضافة كلاس الحماية واضافة المكتبات التي ترتبط به


            string uniqueNumber = SecurityTools.specialDevices.getUniqueID("c");

            string VolumeSerial = SecurityTools.specialDevices.getVolumeSerial("c");

            string CPUNumber = SecurityTools.specialDevices.getCPUID();
            string location = txt024c005_location.Text;
            string uses = txt025c006_deviceUses.Text;
            string licensNo = tbllicense.Rows[RowNumberLicense][0].ToString();

            // هل الجهاز موجود ضمن الاجهزة في الداتا قريد فيو
            bool start = true;
            string[] problems = new string[3];
            problems[0] = "No problem";
            problems[1] = "No problem";
            problems[2] = "No problem";
            foreach (DataGridViewRow item in dgv1.Rows)
            {
                if (item.Cells[1].Value.ToString() == uniqueNumber) { start = false; problems[0] = "الجهاز بالفعل مضاف ضمن هذا الترخيص "; } // هل الجهاز موجود ضمن الاجهزة في الداتا قريد فيو
            }
            if (dgv1.Rows.Count >= int.Parse(txt035c005_packageDevicesNumber.Text)) { start = false; problems[1] = "لقد إستفدت من عدد الأجهزة المحددة ضمن هذا الترخيص "; } // عدد الاجهزة
            if (txt017c001_licenseNo.Text.Trim() == "") { start = false; problems[2] = "رجاء قم بتحديد الرخصة التي تريد إضافة الجهاز إليها"; } // رقم الرخصة



            if (start)
            {
                // اضافة الجهاز


                // https://www.youtube.com/watch?v=ujt_jGafB2E
                string s = string.Format("c002_DeviceNo = '{0}' ", uniqueNumber);
                DataRow[] drr = tbldevices.Select(s);
                if (drr.Length == 0)
                {
                    string DevicesCommandString = "AddDeviceAndConnctWithLicense";
                    SqlCommand AddDeviceInLicense = new SqlCommand(DevicesCommandString, ConnectionsTools.Conlicenses());
                    AddDeviceInLicense.CommandType = CommandType.StoredProcedure;
                    AddDeviceInLicense.Parameters.AddWithValue("@c002_DeviceNo", uniqueNumber);
                    AddDeviceInLicense.Parameters.AddWithValue("@c003_HardiceNo", VolumeSerial);
                    AddDeviceInLicense.Parameters.AddWithValue("@c004_ProcessorNo", CPUNumber);
                    AddDeviceInLicense.Parameters.AddWithValue("@c005_location", location);
                    AddDeviceInLicense.Parameters.AddWithValue("@c006_deviceUses", uses);
                    AddDeviceInLicense.Parameters.AddWithValue("@c003_licensNo", licensNo);
                    AddDeviceInLicense.Parameters.AddWithValue("@c001_deviceAuotoNoOUT", SqlDbType.Int).Direction = ParameterDirection.Output;
                    AddDeviceInLicense.ExecuteNonQuery();
                    int c001_deviceAuotoNo = int.Parse(AddDeviceInLicense.Parameters["@c001_deviceAuotoNoOUT"].Value.ToString());

                }
                else
                {
                    string DevicesCommandString = "ConnctDeviceAndLicense";
                    SqlCommand ConnctDeviceAndLicense = new SqlCommand(DevicesCommandString, ConnectionsTools.Conlicenses());
                    ConnctDeviceAndLicense.CommandType = CommandType.StoredProcedure;
                    ConnctDeviceAndLicense.Parameters.AddWithValue("@c002_DeviceNo", uniqueNumber);
                    ConnctDeviceAndLicense.Parameters.AddWithValue("@c003_licensNo", licensNo);
                    ConnctDeviceAndLicense.Parameters.AddWithValue("@c005_location", location);
                    ConnctDeviceAndLicense.Parameters.AddWithValue("@c006_deviceUses", uses);
                    ConnctDeviceAndLicense.ExecuteNonQuery();

                }

            }
            else { MessageBox.Show("  << 1 >>  " + problems[0] + "\n  << 2 >>  " + problems[1] + "\n  << 3 >>  " + problems[2]); }

            filltbl001_devices();
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  btn22AddDevice_Click  ", DateTime.Now, ex.Message, ex.Message);
        }
        
    }

    // الغاء ربط الجهاز بهذا الترخيص
    private void btn21DeleteDevice_Click(object sender, EventArgs e)
    {
        try
        {
            bool start = true;
            string[] prablems = new string[2];
            if (dgv1.Rows.Count == 0) { start = false; prablems[0] = "لا توجد اجهزة لحذفها"; }
            if (txt017c001_licenseNo.Text.Trim() == "") { start = false; prablems[1] = "لا توجد رخصة ليتم الحذف منها "; }
            if (start)
            {

                string uniqueNumber = SecurityTools.specialDevices.getUniqueID("c");
                int licensNo = int.Parse(txt017c001_licenseNo.Text);


                string DevicesCommandString = "DesConnctDeviceAndLicense";
                SqlCommand ConnctDeviceAndLicense = new SqlCommand(DevicesCommandString, ConnectionsTools.Conlicenses());
                ConnctDeviceAndLicense.CommandType = CommandType.StoredProcedure;
                ConnctDeviceAndLicense.Parameters.AddWithValue("@c002_DeviceNo", uniqueNumber);
                ConnctDeviceAndLicense.Parameters.AddWithValue("@c003_licensNo", licensNo);

                ConnctDeviceAndLicense.ExecuteNonQuery();

                filltbl001_devices();
            }
            else { MessageBox.Show("  << 1  >>  " + prablems[0] + "\n  << 2  >>  " + prablems[1]); }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  btn21DeleteDevice_Click  ", DateTime.Now, ex.Message, ex.Message);
        }
        
    }

    private void txt021c005_DevicesCount_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!(e.KeyChar == '0' || e.KeyChar == '1' || e.KeyChar == '2' || e.KeyChar == '3' || e.KeyChar == '4' || e.KeyChar == '5' || e.KeyChar == '6' || e.KeyChar == '7' || e.KeyChar == '8' || e.KeyChar == '9' || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete))
        {
            e.Handled = true;
        }
    }

    private void btn030PayPanel_Click(object sender, EventArgs e)
    {
        if (btn030PayPanel.Text == "السداد  >>")
        {
            pnl006.Visible = true;
            btn030PayPanel.Text = "السداد  <<";
        }
        else
        {
            pnl006.Visible = false;
            btn030PayPanel.Text = "السداد  >>";
        }
    }

    private void btn031Pay_Click(object sender, EventArgs e)
    {
        try
        {
            if (dgv2.CurrentRow.Cells[9].Value.ToString() == "")
            {
                string TransferBanckNumber = txt032c002_TransferBanckNumber.Text;
                string TransferBankName = txt033c003_TransferBank.Text;

                string date = txt034c004_TransferDate.Text + " 00:00:00 AM";
                DateTime TransferDate = Convert.ToDateTime(date);

                string time = "2000/01/01 " + txt035c005_TransferTime.Text + (cmb002.Text == "صباحاً" ? " AM" : " PM");
                DateTime TransferTime = Convert.ToDateTime(time);

                string TransferAmount = txt036c006_TransferAmount.Text;
                int invoiceNumber = Convert.ToInt32(txt026c001_invoiceNumber.Text);

                int licenseNo = Convert.ToInt32(txt017c001_licenseNo.Text);
                int PackageDuration = Convert.ToInt32(txt022c004_PackageDuration.Text);

                SqlCommand com = new SqlCommand("addLicenseActivationRequests", ConnectionsTools.Conlicenses());
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@c002_TransferBanckNumber", TransferBanckNumber);
                com.Parameters.AddWithValue("@c003_TransferBank", TransferBankName);
                com.Parameters.AddWithValue("@c004_TransferDate", TransferDate);
                com.Parameters.AddWithValue("@c005_TransferTime", TransferTime);
                com.Parameters.AddWithValue("@c006_TransferAmount", TransferAmount);
                com.Parameters.AddWithValue("@c007_invoiceNumber", invoiceNumber);
                com.Parameters.AddWithValue("@c008_licenseNo", licenseNo);
                com.Parameters.AddWithValue("@c009_PackageDuration", PackageDuration);

                com.ExecuteNonQuery();

                pnl006.Visible = false;
                btn030PayPanel.Text = "السداد  >>";

                filltblInvoices();
            }
            else if (dgv2.CurrentRow.Cells[9].Value.ToString() != "" && dgv2.CurrentRow.Cells[18].Value.ToString() == "")
            {
                // 
                string TransferAoutoNo = dgv2.CurrentRow.Cells[9].Value.ToString();

                string TransferBanckNumber = txt032c002_TransferBanckNumber.Text;
                string TransferBankName = txt033c003_TransferBank.Text;

                string date = txt034c004_TransferDate.Text + " 00:00:00 AM";
                DateTime TransferDate = Convert.ToDateTime(date);

                string time = "2000/01/01 " + txt035c005_TransferTime.Text + (cmb002.Text == "صباحاً" ? " AM" : " PM");
                DateTime TransferTime = Convert.ToDateTime(time);

                string TransferAmount = txt036c006_TransferAmount.Text;
                int invoiceNumber = Convert.ToInt32(txt026c001_invoiceNumber.Text);

                int licenseNo = Convert.ToInt32(txt017c001_licenseNo.Text);
                int PackageDuration = Convert.ToInt32(txt022c004_PackageDuration.Text);
                int tbl006TransferAoutoNo = Convert.ToInt32(dgv2.CurrentRow.Cells[0].Value.ToString());

                SqlCommand com = new SqlCommand("updateLicenseActivationRequests", ConnectionsTools.Conlicenses());
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@c001_tbl006TransferAoutoNo", tbl006TransferAoutoNo);
                com.Parameters.AddWithValue("@c002_TransferBanckNumber", TransferBanckNumber);
                com.Parameters.AddWithValue("@c003_TransferBank", TransferBankName);
                com.Parameters.AddWithValue("@c004_TransferDate", TransferDate);
                com.Parameters.AddWithValue("@c005_TransferTime", TransferTime);
                com.Parameters.AddWithValue("@c006_TransferAmount", TransferAmount);
                com.Parameters.AddWithValue("@c007_invoiceNumber", invoiceNumber);
                com.Parameters.AddWithValue("@c008_licenseNo", licenseNo);
                com.Parameters.AddWithValue("@c009_PackageDuration", PackageDuration);

                com.ExecuteNonQuery();

                pnl006.Visible = false;
                btn030PayPanel.Text = "السداد  >>";

                filltblInvoices();
            }
            else
            {
                MessageBox.Show("لا يمكن التعديل على الفواتير الخضراء");
            }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  btn031Pay_Click  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    private void cmb01c002_PackageName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (tblPackages.Rows.Count > 0)
            {
                int row = cmb01c002_PackageName.SelectedIndex;
                txt040c002_price.Text = tblPackages.Rows[row][1].ToString();
                txt021c003_information.Text = tblPackages.Rows[row][2].ToString();
                txt022c004_PackageDuration.Text = tblPackages.Rows[row][3].ToString();
                txt035c005_packageDevicesNumber.Text = tblPackages.Rows[row][4].ToString();
            }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  cmb01c002_PackageName_SelectedIndexChanged  ", DateTime.Now, ex.Message, ex.Message);
        }
        

    }


    // تعبئة جدول الفواتير
    public void filltblInvoices()
    {
        try
        {
            string allLicense = "";
            int LicenseCount = tbllicense.Rows.Count;
            int rowNo = 0;
            foreach (DataRow row in tbllicense.Rows)
            {
                if (rowNo < LicenseCount - 1)
                {
                    allLicense += row[0].ToString() + " , ";
                }
                else
                {
                    allLicense += row[0].ToString();
                }
                rowNo++;
            }


            if (tbllicense.Rows.Count > 0)
            {
                string commandString = @"select * from tbl007_invoices 
                                             left join linkInvoiceWithLicense on linkInvoiceWithLicense.c002_invoiceNo = tbl007_invoices.c001_invoiceNumber 
                                             left join tbl006_LicenseActivationRequests on tbl006_LicenseActivationRequests.c007_invoiceNumber = tbl007_invoices.c001_invoiceNumber 
                                             left join tbl011_linkActivationRequestsAndMonyTransfers on tbl011_linkActivationRequestsAndMonyTransfers.c002_tbl006TransferAoutoNo = tbl006_LicenseActivationRequests.c001_tbl006TransferAoutoNo 
	                                         left join tbl005_MoneyTransfers on tbl005_MoneyTransfers.c001_tbl005TransferAoutoNo = tbl011_linkActivationRequestsAndMonyTransfers.c003_tbl005TransferAoutoNo 
                                             where c003_licenseNo in ( " + allLicense + " ) "; // استخراج جميع الفواتير المرتبطة بجميع رخص هذا الحساب  

                SqlCommand com = new SqlCommand(commandString, ConnectionsTools.Conlicenses());
                tblInvoices.Rows.Clear();
                tblInvoices.Load(com.ExecuteReader());
                if (tblInvoicesSUB.Columns.Count == 0) { BuildTblInvoicesSUB(); } // بناء الجدول الفرعي في حال لم يتم بنائه سابقاً
                filltblInvoicesSUB(); // تعبئة الجدول الفرعي 

            }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  filltblInvoices  ", DateTime.Now, ex.Message, ex.Message);
        }
        
    }

    // بناء جدول الفواتير الفرعي
    public void BuildTblInvoicesSUB()
    {
        try
        {
            tblInvoicesSUB.Columns.Clear();
            foreach (DataColumn column in tblInvoices.Columns)
            {
                tblInvoicesSUB.Columns.Add(column.ColumnName, column.DataType);
            }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  BuildTblInvoicesSUB  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    // تعبئة جدول الفواتير الفرعي بناء على الرخصة المعروضه
    public void filltblInvoicesSUB()
    {
        try
        {
            tblInvoicesSUB.Rows.Clear();
            if (tblInvoices.Rows.Count != 0)
            {
                DataRow[] drArray = tblInvoices.Select(string.Format("c003_licenseNo = {0} ", tbllicense.Rows[RowNumberLicense][0].ToString()));
                foreach (DataRow row in drArray)
                {
                    tblInvoicesSUB.ImportRow(row);
                }
            }
            showInvoice();

        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  filltblInvoicesSUB  ", DateTime.Now, ex.Message, ex.Message);
        }
    }

    public void showInvoice()
    {
        try
        {
            // ستايل جدول البيانات
            dgv2.BorderStyle = BorderStyle.None;
            dgv2.AllowUserToAddRows = false;
            dgv2.ReadOnly = true;
            //dgv2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;  // الغاء اطار عناوين الاعمدة


            dgv2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // محاذات النص في الخلايا
                                                                                         //dgv2.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                                                                                         //dgv2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv2.EnableHeadersVisualStyles = true;
            dgv2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv1.ColumnHeadersVisible = false;
            dgv2.RowHeadersVisible = false;

            dgv2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(211, 211, 211);
            dgv2.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgv2.DefaultCellStyle.ForeColor = Color.White;
            dgv2.BackgroundColor = Color.FromArgb(211, 211, 211);
            dgv2.RowsDefaultCellStyle.BackColor = Color.FromArgb(211, 211, 211);
            dgv2.RowsDefaultCellStyle.ForeColor = Color.White;
            dgv2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(153, 204, 255);
            dgv2.DefaultCellStyle.SelectionForeColor = Color.White;

            // ارتفاع الصفوف
            foreach (DataGridViewRow item in dgv2.Rows)
            {
                item.Height = 30;
            }

            if (tblInvoicesSUB.Rows.Count > 0)
            {
                dgv2.DataSource = tblInvoicesSUB;

                dgv2.Columns[6].Visible = false;
                dgv2.Columns[7].Visible = false;
                dgv2.Columns[8].Visible = false;
                dgv2.Columns[9].Visible = false;
                dgv2.Columns[10].Visible = false;
                dgv2.Columns[11].Visible = false;
                dgv2.Columns[12].Visible = false;
                dgv2.Columns[13].Visible = false;
                dgv2.Columns[14].Visible = false;
                dgv2.Columns[15].Visible = false;
                dgv2.Columns[16].Visible = false;
                dgv2.Columns[17].Visible = false;
                dgv2.Columns[18].Visible = false;
                dgv2.Columns[19].Visible = false;
                dgv2.Columns[20].Visible = false;
                dgv2.Columns[21].Visible = false;
                dgv2.Columns[22].Visible = false;
                dgv2.Columns[23].Visible = false;
                dgv2.Columns[24].Visible = false;
                dgv2.Columns[25].Visible = false;
                dgv2.Columns[26].Visible = false;

                dgv2.Columns[0].HeaderText = "رقم الفاتورة";
                dgv2.Columns[1].HeaderText = "تاريخ الإصدار";
                dgv2.Columns[2].HeaderText = "سعر الرخصة";
                dgv2.Columns[3].HeaderText = "نسبة الضريبة";
                dgv2.Columns[4].HeaderText = "مبلغ الضريبة";
                dgv2.Columns[5].HeaderText = "إجمالي الفاتورة";



                dgv2.Columns[0].Width = 120;
                dgv2.Columns[1].Width = 120;
                dgv2.Columns[2].Width = 120;
                dgv2.Columns[3].Width = 120;
                dgv2.Columns[4].Width = 120;
                dgv2.Columns[5].Width = pnl004.Width - 120 - 120 - 120 - 120 - 120 - 2;

                dgv2.Columns[1].DefaultCellStyle.Format = "yyyy-MM-dd";


                string column9 = "";
                string column18 = "";
                for (int RowNo = 0; RowNo < dgv2.Rows.Count; RowNo++)
                {

                    column9 = dgv2.Rows[RowNo].Cells[9].Value.ToString();
                    column18 = dgv2.Rows[RowNo].Cells[18].Value.ToString();

                    if (column9 == "")
                    {
                        dgv2.Rows[RowNo].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (column9 != "" && column18 == "")
                    {
                        dgv2.Rows[RowNo].DefaultCellStyle.BackColor = Color.Orange;
                    }
                    else
                    {
                        dgv2.Rows[RowNo].DefaultCellStyle.BackColor = Color.Green;
                    }

                }

                dgv2.ClearSelection();

            }


            // اعدادات اصدار فاتورة 
            if (txt023c007_LicenseEndDate.Text != "")
            {
                if (Convert.ToDateTime(txt023c007_LicenseEndDate.Text).AddDays(-30) < DateTime.Now)
                {
                    txt023c007_LicenseEndDate.BackColor = Color.Orange;

                    if (Convert.ToDateTime(txt023c007_LicenseEndDate.Text) < DateTime.Now)
                    {
                        txt023c007_LicenseEndDate.BackColor = Color.PaleVioletRed;
                        // اخفاء عناصر قائمة الاجهزة
                        foreach (Control item in tabControl1.TabPages[0].Controls)
                        {
                            item.Visible = false;
                        }
                    }

                    bool renew = true;
                    // هل هناك فاتورة لم تتم اجراءات سدادها
                    foreach (DataRow row in tblInvoicesSUB.Rows)
                    {
                        if (row[0].ToString() != "" && row[9].ToString() == "" && row[18].ToString() == "") { renew = false; break; }
                        if (row[0].ToString() != "" && row[9].ToString() != "" && row[18].ToString() == "") { renew = false; break; }
                    }
                    if (renew)
                    {
                        createNewInvoice();

                    }

                }
                else
                {
                    txt023c007_LicenseEndDate.BackColor = Color.White;

                    // اظهار عناصر قائمة الاجهزة
                    foreach (Control item in tabControl1.TabPages[0].Controls)
                    {
                        if (item.Name != "pnl002") { item.Visible = true; }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  showInvoice  ", DateTime.Now, ex.Message, ex.Message);
        }

    }


    private void dgv2_SelectionChanged(object sender, EventArgs e)
    {
        if (dgv2.Rows.Count > 0)
        {
            try
            {
                txt026c001_invoiceNumber.Text = dgv2.CurrentRow.Cells[0].Value.ToString();
                txt027c002_data.Text = Convert.ToDateTime(dgv2.CurrentRow.Cells[1].Value.ToString()).ToString("yyyy-MM-dd");
                txt028c003_LicenseCost.Text = dgv2.CurrentRow.Cells[2].Value.ToString();
                txt029c004_TaxPercentage.Text = dgv2.CurrentRow.Cells[3].Value.ToString();
                txt030c005_TaxCost.Text = dgv2.CurrentRow.Cells[4].Value.ToString();
                txt031c016_AllCost.Text = dgv2.CurrentRow.Cells[5].Value.ToString();



                txt032c002_TransferBanckNumber.Text = dgv2.CurrentRow.Cells[10].Value.ToString();
                txt033c003_TransferBank.Text = dgv2.CurrentRow.Cells[11].Value.ToString();
                txt034c004_TransferDate.Text = Convert.ToDateTime(dgv2.CurrentRow.Cells[12].Value.ToString()).ToString("yyyy/MM/dd");
                txt035c005_TransferTime.Text = Convert.ToDateTime(dgv2.CurrentRow.Cells[13].Value.ToString()).ToString("hh:mm");
                string tt = Convert.ToDateTime(dgv2.CurrentRow.Cells[13].Value.ToString()).ToString("tt").ToUpper();
                cmb002.Text = (tt == "AM" ? "صباحاً" : "مساءً");
                txt036c006_TransferAmount.Text = dgv2.CurrentRow.Cells[14].Value.ToString();
            }
            catch (Exception ex)
            {

                txt032c002_TransferBanckNumber.Text = "";
                txt033c003_TransferBank.Text = "";
                txt034c004_TransferDate.Text = "";
                txt035c005_TransferTime.Text = "";
                cmb002.Text = "";
                txt036c006_TransferAmount.Text = "";

                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
                GeneralAction.AddNewNotification("frmAccountManagement04  >>  dgv2_SelectionChanged  ", DateTime.Now, ex.Message, ex.Message);
            }

        }
    }


    private void tabControl1_Click(object sender, EventArgs e)
    {
        try
        {
            string column9 = "";
            string column18 = "";
            for (int RowNo = 0; RowNo < dgv2.Rows.Count; RowNo++)
            {

                column9 = dgv2.Rows[RowNo].Cells[9].Value.ToString();
                column18 = dgv2.Rows[RowNo].Cells[18].Value.ToString();

                if (column9 == "")
                {
                    dgv2.Rows[RowNo].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (column9 != "" && column18 == "")
                {
                    dgv2.Rows[RowNo].DefaultCellStyle.BackColor = Color.Orange;
                }
                else
                {
                    dgv2.Rows[RowNo].DefaultCellStyle.BackColor = Color.Green;
                }

            }

            dgv2.ClearSelection();
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  tabControl1_Click  ", DateTime.Now, ex.Message, ex.Message);
        }
        
    }


    // إصدار الفاتورة
    public void createNewInvoice()
    {
        try
        {
            SqlCommand com = new SqlCommand("createNewInvoice", ConnectionsTools.Conlicenses());
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@c003_LicenseCost", txt040c002_price.Text);
            com.Parameters.AddWithValue("@c007_licenseNo", txt017c001_licenseNo.Text);
            com.ExecuteNonQuery();

            filltblInvoices();
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  createNewInvoice  ", DateTime.Now, ex.Message, ex.Message);
        }

    }


    //--  تغيير موقع النموذج  --

    bool mouseDown = false;
    int click_x = 0;
    int click_y = 0;

    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
        try
        {
            panel1.Cursor = Cursors.Hand;
            mouseDown = true;
            click_x = e.Location.X;
            click_y = e.Location.Y;
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  panel1_MouseDown  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        try
        {
            if (mouseDown)
            {
                int y = (this.Location.Y - click_y) + e.Location.Y;
                int x = (this.Location.X - click_x) + e.Location.X;

                this.Location = new Point(x, y);
            }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  panel1_MouseMove  ", DateTime.Now, ex.Message, ex.Message);
        }

    }

    private void panel1_MouseUp(object sender, MouseEventArgs e)
    {
        try
        {
            mouseDown = false;
            panel1.Cursor = Cursors.Default;
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  panel1_MouseUp  ", DateTime.Now, ex.Message, ex.Message);
        }

    }




    private void dgv1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        try
        {
            int LinkNo = int.Parse(dgv1.CurrentRow.Cells[4].Value.ToString());

            Form frm = new Form();
            frm.Name = "TransfareDevice";
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.BackColor = Color.White;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Size = new Size(300, 150);
            frm.BackColor = Color.FromArgb(0, 191, 255);


            Label lbl = new Label();
            lbl.Text = "رقم الرخصة التي تريد نقل الجهاز إليها";
            //lbl.Location = new Point(100, 20);
            lbl.Dock = DockStyle.Top;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Padding = new Padding(0, 20, 0, 0);
            lbl.AutoSize = false;
            lbl.Height = 50;

            ComboBox cmbAllLicens = new ComboBox();
            cmbAllLicens.Name = "cmbAllLicens";
            cmbAllLicens.DataSource = tbllicense;
            cmbAllLicens.DisplayMember = "c001_licenseNo";
            cmbAllLicens.ValueMember = "c001_licenseNo";
            cmbAllLicens.Location = new Point(100, 50);

            Button btnTransfare = new Button();
            btnTransfare.Name = "btnTransfare";
            btnTransfare.Text = "تأكيد العملية";
            btnTransfare.Location = new Point(70, 90);
            btnTransfare.Click += delegate
            {
                bool start = true;
                string[] prablems = new string[2];
                if (dgv1.Rows.Count == 0) { start = false; prablems[0] = "لا توجد اجهزة لحذفها"; }
                if (txt017c001_licenseNo.Text.Trim() == "") { start = false; prablems[1] = "لا توجد رخصة ليتم الحذف منها "; }
                if (start)
                {
                    //string[] uniqueNumberResult = null;
                    int licensNo = int.Parse(cmbAllLicens.Text);


                    string DevicesCommandString = "TransfareDeviceToOtherLicense";
                    SqlCommand TransfareDevice = new SqlCommand(DevicesCommandString, ConnectionsTools.Conlicenses());
                    TransfareDevice.CommandType = CommandType.StoredProcedure;
                    TransfareDevice.Parameters.AddWithValue("@c001_linkNo", LinkNo);
                    TransfareDevice.Parameters.AddWithValue("@c003_licensNo", licensNo);

                    TransfareDevice.ExecuteNonQuery();

                    filltbl001_devices();
                }
                else { MessageBox.Show("  << 1  >>  " + prablems[0] + "\n  << 2  >>  " + prablems[1]); }
                frm.Close();
            };


            Button btnCanselTransfare = new Button();
            btnCanselTransfare.Name = "btnCanselTransfare";
            btnCanselTransfare.Text = "إلغاء العملية";
            btnCanselTransfare.Location = new Point(170, 90);
            btnCanselTransfare.Click += delegate { frm.Close(); };

            frm.Controls.Add(lbl);
            frm.Controls.Add(cmbAllLicens);
            frm.Controls.Add(btnTransfare);
            frm.Controls.Add(btnCanselTransfare);


            frm.ShowDialog();

        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("frmAccountManagement04  >>  dgv1_CellMouseDoubleClick  ", DateTime.Now, ex.Message, ex.Message);
        }
        

    }

    private void frmAccountManagement_FormClosing(object sender, FormClosingEventArgs e)
    {
        Application.Exit();
    }
}

