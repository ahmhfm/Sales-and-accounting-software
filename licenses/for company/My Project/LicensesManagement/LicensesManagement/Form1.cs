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

namespace LicensesManagement
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //SqlConnection con = new SqlConnection("Data Source=52.147.200.137;Initial Catalog=licenses;User ID=sa;Password=Aah51771#");
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenses;Integrated Security=True");


        DataTable tbl_LicenseActivationRequestsNotConnect = new DataTable();
        DataTable tbl_MoneyTransfersNotConnect = new DataTable();

        private void frmMain_Load(object sender, EventArgs e)
        {
            if ( con.State == ConnectionState.Closed) { con.Open();  }
            fillAllDatatables();

        }

        // تحميل البيانات وعرضها  --------------------------------------------------------------- 01 -----------------------------------------------------
         private void fillAllDatatables()
        {
            string commadString01 = @"select * from tbl006_LicenseActivationRequests  
                                          left join tbl011_linkActivationRequestsAndMonyTransfers on tbl011_linkActivationRequestsAndMonyTransfers.c002_tbl006TransferAoutoNo = tbl006_LicenseActivationRequests.c001_tbl006TransferAoutoNo
                                          where C001_number is null ";

            string commadString02 = @"select * from tbl005_MoneyTransfers 
                                       left join tbl011_linkActivationRequestsAndMonyTransfers on tbl005_MoneyTransfers.c001_tbl005TransferAoutoNo = tbl011_linkActivationRequestsAndMonyTransfers.c003_tbl005TransferAoutoNo
                                          where C001_number is null ";



            SqlCommand com01 = new SqlCommand(commadString01, con);
            SqlCommand com02 = new SqlCommand(commadString02, con);

            if (tbl_LicenseActivationRequestsNotConnect.Rows.Count>0) { tbl_LicenseActivationRequestsNotConnect.Rows.Clear(); }
            if (tbl_MoneyTransfersNotConnect.Rows.Count>0) { tbl_MoneyTransfersNotConnect.Rows.Clear(); }

            tbl_LicenseActivationRequestsNotConnect.Load(com01.ExecuteReader());
            tbl_MoneyTransfersNotConnect.Load(com02.ExecuteReader());

            dgv1.DataSource = tbl_LicenseActivationRequestsNotConnect;
            dgv2.DataSource = tbl_MoneyTransfersNotConnect;

            Coordinate_dgv1();
            Coordinate_dgv2();
        }

        //تنسيق جدول عرض البيانات --------------------------------------------------- 02 -------------------------------------------------------
        private void Coordinate_dgv1()
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
            dgv1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(153, 204, 255);
            dgv1.DefaultCellStyle.SelectionForeColor = Color.White;

            // ارتفاع الصفوف
            foreach (DataGridViewRow item in dgv1.Rows)
            {
                item.Height = 30;
            }

            //if (tbl_MoneyTransfersNotConnect.Rows.Count > 0)
            //{

                dgv1.Columns[0].Visible = false;
                dgv1.Columns[6].Visible = false;
                dgv1.Columns[7].Visible = false;
                dgv1.Columns[8].Visible = false;
                dgv1.Columns[9].Visible = false;
                dgv1.Columns[10].Visible = false;
                dgv1.Columns[11].Visible = false;

                dgv1.Columns[1].HeaderText = "رقم الحوالة";
                dgv1.Columns[2].HeaderText = "البنك";
                dgv1.Columns[3].HeaderText = "تاريخ الحوالة";
                dgv1.Columns[4].HeaderText = "وقت الحوالة";
                dgv1.Columns[5].HeaderText = "مبلغ الحوالة";




                dgv1.Columns[1].Width = 120;
                dgv1.Columns[2].Width = 120;
                dgv1.Columns[3].Width = 120;
                dgv1.Columns[4].Width = 120;
                dgv1.Columns[5].Width = dgv2.Width - 120 - 120 - 120 - 120 - 2;

                dgv1.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgv1.Columns[4].DefaultCellStyle.Format = "hh:mm  tt";
            //}
        }

        // تنسيق جدول عرض البيانات------------------------------------------------------ 03  -----------------------------------------------------------------
        private void Coordinate_dgv2()
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

            //if (tbl_MoneyTransfersNotConnect.Rows.Count > 0)
            //{

                dgv2.Columns[0].Visible = false;
                dgv2.Columns[6].Visible = false;
                dgv2.Columns[7].Visible = false;
                dgv2.Columns[8].Visible = false;

                dgv2.Columns[1].HeaderText = "رقم الحوالة";
                dgv2.Columns[2].HeaderText = "البنك";
                dgv2.Columns[3].HeaderText = "تاريخ الحوالة";
                dgv2.Columns[4].HeaderText = "وقت الحوالة";
                dgv2.Columns[5].HeaderText = "مبلغ الحوالة";




                dgv2.Columns[1].Width = 120;
                dgv2.Columns[2].Width = 120;
                dgv2.Columns[3].Width = 120;
                dgv2.Columns[4].Width = 120;
                dgv2.Columns[5].Width = dgv2.Width - 120 - 120 - 120 - 120 - 2;

                dgv2.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgv2.Columns[4].DefaultCellStyle.Format = "hh:mm  tt";
            //}
        }

        // عرض بيانات السطر الذي تم التأشير عليه -------------------------------------------- 04 ----------------------------------------------------------
        private void dgv1_SelectionChanged(object sender, EventArgs e)
        {
            if(dgv1.Rows.Count>0)
            {
                txt01TransferBanckNumber.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
                txt01TransferBank.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
                txt01TransferDate.Text = Convert.ToDateTime(dgv1.CurrentRow.Cells[3].Value.ToString()).ToString("yyyy-MM-dd");
                txt01TransferTime.Text = Convert.ToDateTime(dgv1.CurrentRow.Cells[4].Value.ToString()).ToString("hh:mm  tt");
                txt01TransferAmount.Text = dgv1.CurrentRow.Cells[5].Value.ToString();
            }

            Coordinate_textboxes();
        }

        // عرض بيانات السطر الذي تم التأشير عليه -------------------------------------------- 05 ----------------------------------------------------------
        private void dgv2_SelectionChanged(object sender, EventArgs e)
        {
            if(dgv2.Rows.Count>0)
            {
                txt02TransferBanckNumber.Text = dgv2.CurrentRow.Cells[1].Value.ToString();
                txt02TransferBank.Text = dgv2.CurrentRow.Cells[2].Value.ToString();
                txt02TransferDate.Text = Convert.ToDateTime(dgv2.CurrentRow.Cells[3].Value.ToString()).ToString("yyyy-MM-dd");
                txt02TransferTime.Text = Convert.ToDateTime(dgv2.CurrentRow.Cells[4].Value.ToString()).ToString("hh:mm  tt");
                txt02TransferAmount.Text = dgv2.CurrentRow.Cells[5].Value.ToString();
            }

            Coordinate_textboxes();
        }

        // تنسيق مربعات النص------------------------------------------------------ 06  --------------------------------------------------------------------------
        private void Coordinate_textboxes()
        {
            if (txt01TransferBanckNumber.Text == txt02TransferBanckNumber.Text) { txt01TransferBanckNumber.BackColor = Color.Green; txt02TransferBanckNumber.BackColor = Color.Green; } else { txt01TransferBanckNumber.BackColor = Color.PaleVioletRed; txt02TransferBanckNumber.BackColor = Color.PaleVioletRed; }
            if (txt01TransferBank.Text == txt02TransferBank.Text) { txt01TransferBank.BackColor = Color.Green; txt02TransferBank.BackColor = Color.Green; } else { txt01TransferBank.BackColor = Color.PaleVioletRed; txt02TransferBank.BackColor = Color.PaleVioletRed; }
            if (txt01TransferDate.Text == txt02TransferDate.Text) { txt01TransferDate.BackColor = Color.Green; txt02TransferDate.BackColor = Color.Green; } else { txt01TransferDate.BackColor = Color.PaleVioletRed; txt02TransferDate.BackColor = Color.PaleVioletRed; }
            if (txt01TransferTime.Text == txt02TransferTime.Text) { txt01TransferTime.BackColor = Color.Green; txt02TransferTime.BackColor = Color.Green; } else { txt01TransferTime.BackColor = Color.PaleVioletRed; txt02TransferTime.BackColor = Color.PaleVioletRed; }
            if (txt01TransferAmount.Text == txt02TransferAmount.Text) { txt01TransferAmount.BackColor = Color.Green; txt02TransferAmount.BackColor = Color.Green; } else { txt01TransferAmount.BackColor = Color.PaleVioletRed; txt02TransferAmount.BackColor = Color.PaleVioletRed; }

        }

        // اعتماد الحوالة وتفعيل الرخصة ----------------------------------------------------- 07 ---------------------------------------------------------------------
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(txt02TransferBank.Text.Trim()!="" && txt02TransferDate.Text.Trim() != "" && txt02TransferTime.Text.Trim() != "" && txt02TransferAmount.Text.Trim() != "" && txt01TransferBank.Text.Trim() != "" && txt01TransferDate.Text.Trim() != "" && txt01TransferTime.Text.Trim() != "" && txt01TransferAmount.Text.Trim() != "")
            {
                SqlCommand com = new SqlCommand("ReNewLicenses", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@c001_tbl006TransferAoutoNo", dgv1.CurrentRow.Cells[0].Value.ToString());
                com.Parameters.AddWithValue("@c001_tbl005TransferAoutoNo", dgv2.CurrentRow.Cells[0].Value.ToString());
                com.Parameters.AddWithValue("@c001_licenseNo", dgv1.CurrentRow.Cells[7].Value.ToString());
                com.Parameters.AddWithValue("@c004_PackageDuration", dgv1.CurrentRow.Cells[8].Value.ToString());
                com.ExecuteNonQuery();
                fillAllDatatables();
            }
        }

        // تسجيل بيانات حوالة جديدة -------------------------------------  08  ------------------------------------------------------------------------------------------------
        private void btn02RegisterNewTransfare_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand com = new SqlCommand("AddMoneyTransfers", con); com.CommandType = CommandType.StoredProcedure;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@c002_TransferBanckNumber", txt02TransferBanckNumber.Text);
                com.Parameters.AddWithValue("@c003_TransferBank", txt02TransferBank.Text);
                com.Parameters.AddWithValue("@c004_TransferDate", txt02TransferDate.Text);
                com.Parameters.AddWithValue("@c005_TransferTime", txt02TransferTime.Text);
                com.Parameters.AddWithValue("@c006_TransferAmount", txt02TransferAmount.Text);

                com.ExecuteNonQuery();
                fillAllDatatables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
