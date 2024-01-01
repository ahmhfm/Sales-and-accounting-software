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

namespace Mesrakh.forms.General_Forms.salse_forms
{
    public partial class frmConnectionsNumbers : Form
    {
        DataTable TblConnectionsNumbers = new DataTable();
        public int ConnectingMethodsOfCommunicationNO = -1;

        public frmConnectionsNumbers()
        {
            InitializeComponent();
            AllucConnectionControlEventsAndProperties(true, true);
        }

        public void AllucConnectionControlEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            ucConnectionControlEventsAndProperties(Properties, Events); // النموذج
            pnlMainEventsAndProperties(Properties, Events);// الحاوية الرئيسية
            dgvAllConnectionNumbersEventsAndProperties(Properties, Events); // جدول عرض البيانات
        }
        private void ucConnectionControlEventsAndProperties(bool Properties, bool Events = false) // النموذج 
        {
            // الخصائص
            if (Properties)
            {
                this.Dock = DockStyle.Fill;
                //this.BackColor = DisplayMode.ReturnColor(ElementType.Form, ColorPropertyName.BackColor_3);
                this.BackColor = Color.Yellow;
                lblTitel.Width = this.Width - 4;
                txtCommunicationNo.Width = (this.Width - ((this.Width / 100) * 30)) - 2;
                cbxContactMethodsTypes.Width = (((this.Width / 100) * 30)) - 4;
                cbxContactMethodsTypes.Left = txtCommunicationNo.Left + txtCommunicationNo.Width;
                dgvAllConnectionNumbers.Width = this.Width - 4;
                dgvAllConnectionNumbers.Height = this.Height - btnAdd.Top - btnAdd.Height - 4;
                pnlMain.Dock = DockStyle.Fill;
                pnlMain.BackColor = Color.Red;
                dgvAllConnectionNumbers.BackgroundColor = Color.DarkRed;
            }

            // الاحداث
            if (Events)
            {
                //this.Load += delegate
                //{

                //};

                dgvAllConnectionNumbers.Resize += delegate
                {
                    this.Dock = DockStyle.Fill;
                    //this.BackColor = DisplayMode.ReturnColor(ElementType.Form, ColorPropertyName.BackColor_3);
                    this.BackColor = Color.Yellow;
                    lblTitel.Width = this.Width - 4;
                    txtCommunicationNo.Width = (this.Width - ((this.Width / 100) * 30)) - 2;
                    cbxContactMethodsTypes.Width = (((this.Width / 100) * 30)) - 4;
                    cbxContactMethodsTypes.Left = txtCommunicationNo.Left + txtCommunicationNo.Width;
                    dgvAllConnectionNumbers.Width = this.Width - 4;
                    dgvAllConnectionNumbers.Height = this.Height - btnAdd.Top - btnAdd.Height - 4;
                    pnlMain.Dock = DockStyle.Fill;
                    pnlMain.BackColor = Color.Red;
                    dgvAllConnectionNumbers.BackgroundColor = Color.DarkRed;
                };
            }
        }
        private void pnlMainEventsAndProperties(bool Properties, bool Events = false) // الحاوية الرئيسية
        {

            // الخصائص
            if (Properties)
            {
                pnlMain.BackColor = DisplayMode.ReturnColor(ElementType.Form, ColorPropertyName.BackColor_3);

            }

            // الاحداث
            if (Events)
            {

            }
        }

        private void dgvAllConnectionNumbersEventsAndProperties(bool Properties, bool Events = false) // الحاوية الرئيسية
        {

            if (Properties)
            {
                if (TblConnectionsNumbers.Rows.Count > 0)
                {
                    dgvAllConnectionNumbers.DataSource = TblConnectionsNumbers;

                    //dgvAllConnectionNumbers.Columns[0].HeaderText = Cultures.ReturnTranslation("رقم الشركة الصانعة");
                    //dgvAllConnectionNumbers.Columns[1].HeaderText = Cultures.ReturnTranslation("اسم الشركة عربي");
                    //dgvAllConnectionNumbers.Columns[2].HeaderText = Cultures.ReturnTranslation("اسم الشركة انجليزي");

                    //dgvAllConnectionNumbers.Columns[0].Width = 250;

                    //dgvAllConnectionNumbers.Columns[1].Width = (dgvAllConnectionNumbers.Width - 250 - 1);
                    //dgvAllConnectionNumbers.Columns[2].Width = (dgvAllConnectionNumbers.Width - 250 - 1);



                    if (GeneralVariables.cultureCode == "AR")
                    {
                        //dgvAllConnectionNumbers.Columns[1].Visible = true;
                        //dgvAllConnectionNumbers.Columns[2].Visible = false;
                    }
                    else
                    {
                        //dgvAllConnectionNumbers.Columns[1].Visible = false;
                        //dgvAllConnectionNumbers.Columns[2].Visible = true;
                    }
                }
                else
                {
                    if (dgvAllConnectionNumbers.Rows.Count > 0) { dgvAllConnectionNumbers.DataSource = null; dgvAllConnectionNumbers.Rows.Clear(); };

                }
                ElemntsTools.DataGridView_.CustumProperties(dgvAllConnectionNumbers, TblConnectionsNumbers);  // تخصيص خصائص جدول عرض البيانات
            }

            // الاحداث
            if (Events)
            {
                dgvAllConnectionNumbers.SelectionChanged += delegate
                {
                    //txt08001002001.Text = dgv08001.CurrentRow.Cells[0].Value.ToString();
                    //txt08001002002.Text = dgv08001.CurrentRow.Cells[1].Value.ToString();
                    //txt08001002003.Text = dgv08001.CurrentRow.Cells[2].Value.ToString();
                };
            }

        }

        public void fillTblConnectionsNumbers()
        {
            string commandString = @"select * from TblConnectingMethodsOfCommunication
                                    inner join TblMethodsOfCommunication 
                                    on TblMethodsOfCommunication.ConnectingMethodsOfCommunicationNO = TblConnectingMethodsOfCommunication.ConnectingMethodsOfCommunicationNO
                                    where ConnectingMethodsOfCommunicationNO = @ConnectingMethodsOfCommunicationNO";
            SqlCommand com = new SqlCommand(commandString, ConnectionsTools.ConMesrakhMainDB());
            com.Parameters.AddWithValue("@ConnectingMethodsOfCommunicationNO", typeof(int)).Value = ConnectingMethodsOfCommunicationNO;
            TblConnectionsNumbers.Load(com.ExecuteReader());

            dgvAllConnectionNumbersEventsAndProperties(true);
        }

        //private void ucConnectionControl_Resize(object sender, EventArgs e)
        //{
        //    //lblTitel.Width = this.Width - 4;
        //    //txtCommunicationNo.Width = (this.Width - ((this.Width / 100) * 30)) - 2;
        //    //cbxContactMethodsTypes.Width = (((this.Width / 100) * 30)) - 2;
        //    //cbxContactMethodsTypes.Left = txtCommunicationNo.Left + txtCommunicationNo.Width;
        //    //dgvAllConnectionNumbers.Width = this.Width - 4;
        //    //dgvAllConnectionNumbers.Height = this.Height - btnAdd.Top -btnAdd.Height - 4 ;
        //    //pnlMain.Width = this.Width;
        //}
    }
}
