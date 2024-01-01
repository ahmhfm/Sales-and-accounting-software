using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace license
{
    public partial class frm001_main : Form
    {

        public frm001_main()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenses;Integrated Security=True");
        //SqlConnection con = new SqlConnection("Data Source=52.147.200.137;Initial Catalog=licenses;User ID=sa;Password=Aah51771#");
        DataTable tblaccount = new DataTable();
        DataTable tbllicense = new DataTable();
        DataTable tbldevices = new DataTable();
        DataTable tblPackages = new DataTable();
        DataTable tblInvoices = new DataTable();

        DataTable tbldevicesDatatableSUB = new DataTable();
        DataTable tblInvoicesSUB = new DataTable();

        int RowNumberLicense = 0;
        int RowNumberDevices = 0;


        
        private void frm001_main_Load(object sender, EventArgs e)
        {
            pnl001002.Visible = false;
            txt001c002_userName.Focus();

            foreach (Control con in this.Controls)
            {
                if (con.Name != "pnl001") { con.Visible = false; }
            }

            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("no connection 00 >> " + ex.Message);
            }
        }

        // تعبئة جدول الباقات
        public void filltbl008Packages()
        {
            SqlCommand com = new SqlCommand("select * from tbl008Packages", con);
            tblPackages.Load(com.ExecuteReader());
            fillcmb01c002_PackageName();
        }

        public void fillcmb01c002_PackageName()
        {
            cmb01c002_PackageName.DataSource = tblPackages;
            cmb01c002_PackageName.DisplayMember = "c001_package";
            cmb01c002_PackageName.ValueMember = "c001_package";
        }

        // تعبئة جدول الحسابت
        public void filltbl002_Accounts()
        {
            tblaccount.Rows.Clear();
            string CommandString = string.Format("select * from tbl002_Accounts where c002_userName = '{0}' and c003_password = '{1}'", txt001c002_userName.Text, txt002c003_password.Text);
            SqlCommand com = new SqlCommand(CommandString, con);
            tblaccount.Load(com.ExecuteReader());

            if (tblaccount.Rows.Count == 1)
            {
                filltbl008Packages();
                filltbl003_licenses();
            }
            else { MessageBox.Show("تأكد من صحة بيانات الحساب !!!");}
        }

        // تعبئة جدول الرخص
        public void filltbl003_licenses()
        {
            formNurmal();
            if (tblaccount.Rows.Count>0)
            {
                tbllicense.Rows.Clear();
                RowNumberLicense = 0;
                string CommandString2 = string.Format("select * from tbl003_licenses  where c008_AccountNo = '{0}' ", tblaccount.Rows[0][0].ToString());
                SqlCommand com2 = new SqlCommand(CommandString2, con);
                tbllicense.Load(com2.ExecuteReader());

                filltblInvoices(); // تعبئة جدول الفواتير
                filltbl001_devices(); //  تعبئة جدول الاجهزة
                showLicense();

            }
        }

        // تعبئة جدول الاجهزة الرئيسي
        public void filltbl001_devices()
        {
            tbldevices.Rows.Clear();
            RowNumberDevices = 0;
            string CommandString3 = string.Format("select * from tbl001_devices  inner join  tbl004_licenseAndDevices on   tbl004_licenseAndDevices.c002_deviceAuotoNo = tbl001_devices.c001_deviceAuotoNo inner join   tbl003_licenses on tbl003_licenses.c001_licenseNo = tbl004_licenseAndDevices.c003_licensNo where c008_AccountNo = '{0}' ", tblaccount.Rows[0][0].ToString());
            SqlCommand com3 = new SqlCommand(CommandString3, con);
            tbldevices.Load(com3.ExecuteReader());
            if (tbldevicesDatatableSUB.Columns.Count == 0) { BuildDevicesSUB(); }
            fileDevicesDatatableSUB();
        }

        // بناء جدول الاجهزة الفرعي
        public void BuildDevicesSUB()
        {
            tbldevicesDatatableSUB.Rows.Clear();
            tbldevicesDatatableSUB.Columns.Clear();
            foreach (DataColumn dc in tbldevices.Columns)
            {
                tbldevicesDatatableSUB.Columns.Add(dc.ColumnName, dc.DataType);
            }
        }

        // تعبئة جدول الاجهزة الفرعي 
        public void fileDevicesDatatableSUB()
        {
            try
            {
                if(tbldevices.Rows.Count > 0 )
                {
                    tbldevicesDatatableSUB.Rows.Clear();
                    RowNumberDevices = 0;

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
                MessageBox.Show("  0  >>>>>" +ex.Message);
            }
        }

        // عرض بيانات الاجهزة
        public void ShowDevices()
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
                dgv1.Columns[8].Width = pnl004.Width - 400-2;

            }
            else 
            { 
                dgv1.DataSource = new DataTable();
            }
            

        }

        // الوضع الطبيعي للنموذج
        public void formNurmal()
        {
            foreach (Control con in this.Controls)
            {
                con.Visible = true; 
            }
            pnl002.Visible = false;

            //btn20Exit.Visible = false;

            txt017c001_licenseNo.Text = "";
            if (cmb01c002_PackageName.Items.Count>0) { cmb01c002_PackageName.SelectedIndex = 0; }
            txt019c003_DateOfLicenseRequest.Text = "";
            txt020c004_DateOfLicenseStart.Text = "";
            txt021c003_information.Text = "";
            txt022c004_PackageDuration.Text = "";
            txt023c007_LicenseEndDate.Text = "";
            txt035c005_packageDevicesCount.Text = "";
            txt040c002_price.Text = "";

            txt017c001_licenseNo.Enabled = false;
            cmb01c002_PackageName.Enabled = false;
            txt019c003_DateOfLicenseRequest.Enabled = false;
            txt020c004_DateOfLicenseStart.Enabled = false;
            txt021c003_information.Enabled = false;
            txt022c004_PackageDuration.Enabled = false;
            txt023c007_LicenseEndDate.Enabled = false;
            txt035c005_packageDevicesCount.Enabled = false;
            txt040c002_price.Enabled = false;

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

        // تسجيل الدخول
        private void btn01_LoginToAccount_Click(object sender, EventArgs e)
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
            
            string CommandString = @"insert into tbl002_Accounts (c002_userName,c003_password,c004_ClientName,c005_ClientPhone,c006_ClientEmail ,c007_ShortAddress,c008_BuildingNo,c009_Street,c010_SecondaryNo,c011_District,c012_PostalCode,c013_City,c014_country) values (@c002_userName,@c003_password,@c004_ClientName,@c005_ClientPhone,@c006_ClientEmail ,@c007_ShortAddress,@c008_BuildingNo,@c009_Street,@c010_SecondaryNo,@c011_District,@c012_PostalCode,@c013_City,@c014_country)";
            SqlCommand com = new SqlCommand(CommandString, con);
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

        private void fillFromCmbobox()
        {
            if (tblPackages.Rows.Count > 0)
            {
                int row = cmb01c002_PackageName.SelectedIndex;
                txt040c002_price.Text = tblPackages.Rows[row][1].ToString();
                txt021c003_information.Text = tblPackages.Rows[row][5].ToString();
                txt022c004_PackageDuration.Text = tblPackages.Rows[row][3].ToString();
                txt035c005_packageDevicesCount.Text = tblPackages.Rows[row][4].ToString();
            }
        }

        public void showLicense()
        {
            if(tbllicense.Rows.Count>0)
            {

                txt017c001_licenseNo.Text = tbllicense.Rows[RowNumberLicense][0].ToString();
                cmb01c002_PackageName.SelectedIndex = cmb01c002_PackageName.FindStringExact(tbllicense.Rows[RowNumberLicense][1].ToString());
                txt019c003_DateOfLicenseRequest.Text = (Convert.ToDateTime(tbllicense.Rows[RowNumberLicense][2].ToString())).ToString("yyyy-MM-dd");
                txt020c004_DateOfLicenseStart.Text = (Convert.ToDateTime(tbllicense.Rows[RowNumberLicense][3].ToString())).ToString("yyyy-MM-dd");
                txt023c007_LicenseEndDate.Text = (Convert.ToDateTime(tbllicense.Rows[RowNumberLicense][6].ToString())).ToString("yyyy-MM-dd");

                fillFromCmbobox();
            }
            filltblInvoicesSUB(); // ملئ بيانات الفواتير بناء على رقم الرخصة
            fileDevicesDatatableSUB(); // عرض بيانات الاجهزة بناء على رقم الرخصة

        }



        private void btn05first_Click(object sender, EventArgs e)
        {

            formNurmal();

            if (tbllicense.Rows.Count>0)
            {
                RowNumberLicense = 0;
                showLicense();

            }
        }

        private void btn06previes_Click(object sender, EventArgs e)
        {
            formNurmal();
            
            if (tbllicense.Rows.Count > 0)
            {
                if (RowNumberLicense > 0) { RowNumberLicense--; }
                showLicense();
            }
        }

        private void btn07next_Click(object sender, EventArgs e)
        {
            formNurmal();
            
            if (tbllicense.Rows.Count > 0)
            {
                if (RowNumberLicense < tbllicense.Rows.Count -1 ) { RowNumberLicense++; }
                showLicense();
            }
        }

        private void btn08last_Click(object sender, EventArgs e)
        {

            formNurmal();
            
            if (tbllicense.Rows.Count > 0)
            {
                RowNumberLicense = tbllicense.Rows.Count - 1;
                showLicense();
            }
        }


        public void forNewLicense()
        {
            
            txt017c001_licenseNo.Text = "";
            cmb01c002_PackageName.SelectedIndex = 0;
            txt019c003_DateOfLicenseRequest.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") ;
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
            txt035c005_packageDevicesCount.Enabled = false;

            btn11Save.Enabled = true;
            btn10Delete.Enabled = false;
            btn05first.Enabled = false;
            btn06previes.Enabled = false;
            btn07next.Enabled = false;
            btn08last.Enabled = false;

            tabControl1.Enabled = false;

            btn09New.Text = "إلغاء";
        }

        private void btn09New_Click(object sender, EventArgs e)
        {
            if(btn09New.Text == "جديد")
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
            string commandString = "insert into tbl003_licenses (c002_PackageName,c003_DateOfLicenseRequest,c008_AccountNo) values (@c002_PackageName,@c003_DateOfLicenseRequest,@c008_AccountNo)";
            SqlCommand com = new SqlCommand(commandString, con);
            com.Parameters.AddWithValue("@c002_PackageName", cmb01c002_PackageName.Text);
            com.Parameters.AddWithValue("@c003_DateOfLicenseRequest", txt019c003_DateOfLicenseRequest.Text);
            com.Parameters.AddWithValue("@c008_AccountNo", tblaccount.Rows[0][0].ToString());
            com.ExecuteNonQuery();

            formNurmal();
            filltbl003_licenses();
        }

        private void btn10Delete_Click(object sender, EventArgs e)
        {

            if(txt017c001_licenseNo.Text.Trim() != "")
            {
                string commandString = "licenseDelete";
                SqlCommand com = new SqlCommand(commandString, con);
                com.CommandType = CommandType.StoredProcedure;
                string licenseNo = tbllicense.Rows[RowNumberLicense][0].ToString();
                com.Parameters.AddWithValue("@c001_licenseNo", licenseNo);
                com.ExecuteNonQuery();

                formNurmal();
                filltbl003_licenses();

            }
            else { MessageBox.Show("لا توجد بيانات للرخصةالمراد حذفها");}
        }

        // الخروج من الحساب
        private void btn20Exit_Click(object sender, EventArgs e)
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
            foreach(Control con in this.Controls)
            {
                if (con.Name!= "pnl001") { con.Visible = false; }
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
            pnl002.Visible = false;
            btn20forAddDevice.Text = "إضافة الجهاز الحالي >>";

            //-----  يجب اضافة كلاس الحماية واضافة المكتبات التي ترتبط به

            string uniqueNumberResult = "";
            string uniqueNumber =  my004SecurityTools.specialDevices_04001.getUniqueID_04001001(out uniqueNumberResult, "c");
            string VolumeSerialResult = "";
            string VolumeSerial = my004SecurityTools.specialDevices_04001.getVolumeSerial_04001002  (out VolumeSerialResult, "c");
            string CPUNumberResult = "";
            string CPUNumber = my004SecurityTools.specialDevices_04001.getCPUID_04001003(out CPUNumberResult);
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
            if (dgv1.Rows.Count >= int.Parse(txt035c005_packageDevicesCount.Text)) { start = false; problems[1] = "لقد إستفدت من عدد الأجهزة المحددة ضمن هذا الترخيص "; } // عدد الاجهزة
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
                        SqlCommand AddDeviceInLicense = new SqlCommand(DevicesCommandString, con);
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
                        SqlCommand ConnctDeviceAndLicense = new SqlCommand(DevicesCommandString, con);
                        ConnctDeviceAndLicense.CommandType = CommandType.StoredProcedure;
                        ConnctDeviceAndLicense.Parameters.AddWithValue("@c002_DeviceNo", uniqueNumber);
                        ConnctDeviceAndLicense.Parameters.AddWithValue("@c003_licensNo", licensNo);
                        ConnctDeviceAndLicense.Parameters.AddWithValue("@c005_location", location);
                        ConnctDeviceAndLicense.Parameters.AddWithValue("@c006_deviceUses", uses);
                        ConnctDeviceAndLicense.ExecuteNonQuery();

                    }

            }
            else { MessageBox.Show("  << 1 >>  " + problems[0] + "\n  << 2 >>  " + problems[1] + "\n  << 3 >>  " + problems[2] );}

            filltbl001_devices();
        }

        // الغاء ربط الجهاز بهذا الترخيص
        private void btn21DeleteDevice_Click(object sender, EventArgs e)
        {
            bool start = true;
            string[] prablems = new string[2];
            if (dgv1.Rows.Count==0) { start = false; prablems[0] = "لا توجد اجهزة لحذفها";  }
            if (txt017c001_licenseNo.Text.Trim() == "") { start = false; prablems[1] = "لا توجد رخصة ليتم الحذف منها "; }
            if (start)
            {
                string uniqueNumberResult = "";
                string uniqueNumber = my004SecurityTools.specialDevices_04001.getUniqueID_04001001(out uniqueNumberResult, "c");
                int licensNo = int.Parse(txt017c001_licenseNo.Text);


                string DevicesCommandString = "DesConnctDeviceAndLicense";
                SqlCommand ConnctDeviceAndLicense = new SqlCommand(DevicesCommandString, con);
                ConnctDeviceAndLicense.CommandType = CommandType.StoredProcedure;
                ConnctDeviceAndLicense.Parameters.AddWithValue("@c002_DeviceNo", uniqueNumber);
                ConnctDeviceAndLicense.Parameters.AddWithValue("@c003_licensNo", licensNo);

                ConnctDeviceAndLicense.ExecuteNonQuery();

                filltbl001_devices();
            }
            else { MessageBox.Show("  << 1  >>  " + prablems[0] + "\n  << 2  >>  " + prablems[1]);}
        }

        private void txt021c005_DevicesCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(e.KeyChar == '0' || e.KeyChar == '1' || e.KeyChar == '2' || e.KeyChar == '3' || e.KeyChar == '4' || e.KeyChar == '5' || e.KeyChar == '6' || e.KeyChar == '7' || e.KeyChar == '8' || e.KeyChar == '9' || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete ))
            {
                e.Handled = true;
            }
        }

        private void btn030PayPanel_Click(object sender, EventArgs e)
        {
            if(btn030PayPanel.Text== "السداد  >>")
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

                SqlCommand com = new SqlCommand("addLicenseActivationRequests", con);
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

                SqlCommand com = new SqlCommand("updateLicenseActivationRequests", con);
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

        private void cmb01c002_PackageName_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillFromCmbobox();
        }


        // تعبئة جدول الفواتير
        public void filltblInvoices()
        {

            string allLicense = "" ;
            int LicenseCount = tbllicense.Rows.Count ;
            int rowNo = 0;
            foreach (DataRow row in tbllicense.Rows)
            {
                if(rowNo < LicenseCount-1)
                {
                    allLicense += row[0].ToString() + " , " ;
                }
                else
                {
                    allLicense += row[0].ToString();
                }
                rowNo++;
            }


            if(tbllicense.Rows.Count > 0)
            {
                string commandString = @"select * from tbl007_invoices 
                                             left join linkInvoiceWithLicense on linkInvoiceWithLicense.c002_invoiceNo = tbl007_invoices.c001_invoiceNumber 
                                             left join tbl006_LicenseActivationRequests on tbl006_LicenseActivationRequests.c007_invoiceNumber = tbl007_invoices.c001_invoiceNumber 
                                             left join tbl011_linkActivationRequestsAndMonyTransfers on tbl011_linkActivationRequestsAndMonyTransfers.c002_tbl006TransferAoutoNo = tbl006_LicenseActivationRequests.c001_tbl006TransferAoutoNo 
	                                         left join tbl005_MoneyTransfers on tbl005_MoneyTransfers.c001_tbl005TransferAoutoNo = tbl011_linkActivationRequestsAndMonyTransfers.c003_tbl005TransferAoutoNo 
                                             where c003_licenseNo in ( " + allLicense + " ) "; // استخراج جميع الفواتير المرتبطة بجميع رخص هذا الحساب  

                SqlCommand com = new SqlCommand(commandString, con);
                tblInvoices.Rows.Clear();
                tblInvoices.Load(com.ExecuteReader());
                if (tblInvoicesSUB.Columns.Count == 0) { BuildTblInvoicesSUB(); } // بناء الجدول الفرعي في حال لم يتم بنائه سابقاً
                filltblInvoicesSUB(); // تعبئة الجدول الفرعي 

            }
        }

        // بناء جدول الفواتير الفرعي
        public void BuildTblInvoicesSUB()
        {
            tblInvoicesSUB.Columns.Clear();
            foreach (DataColumn column in tblInvoices.Columns)
            {
                tblInvoicesSUB.Columns.Add(column.ColumnName, column.DataType);
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
            catch (Exception)
            {

            }
        }

        public void showInvoice()
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

            if(tblInvoicesSUB.Rows.Count>0)
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
                dgv2.Columns[5].Width = pnl004.Width - 120-120-120-120-120-2;

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
                        if (item.Name!= "pnl002") { item.Visible = true; }
                    }
                }
            }

        }






        private void dgv2_SelectionChanged(object sender, EventArgs e)
        {
            if(dgv2.Rows.Count>0)
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
                catch (Exception)
                {

                    txt032c002_TransferBanckNumber.Text = "";
                    txt033c003_TransferBank.Text = "";
                    txt034c004_TransferDate.Text = "";
                    txt035c005_TransferTime.Text = "";
                    cmb002.Text = "";
                    txt036c006_TransferAmount.Text = "";
                }

            }
        }


        private void tabControl1_Click(object sender, EventArgs e)
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


        // إصدار الفاتورة
        public void createNewInvoice()
        {
            SqlCommand com = new SqlCommand("createNewInvoice", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@c003_LicenseCost", txt040c002_price.Text);
            com.Parameters.AddWithValue("@c007_licenseNo", txt017c001_licenseNo.Text);
            com.ExecuteNonQuery();

            filltblInvoices();
        }
    }
}



