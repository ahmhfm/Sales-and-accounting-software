using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mesrakh
{

    public partial class frmNotifications : Form
    {
        public frmNotifications()
        {
            InitializeComponent();
            AllEventsAndProperties(true, true);
        }

        public void AllEventsAndProperties(bool Properties, bool Events = false)  //  جميع العناصر
        {
            frmNotificationsEventsAndProperties(Properties, Events); // النموذج الرئيسي
            dgvNotificationsEventsAndProperties(Properties, Events); // جدول عرض البيانات
            lblHeaderEventsAndProperties(Properties, Events); // العنوان
            panel1EventsAndProperties(Properties, Events); // حاوية العنوان
        }

        private void frmNotificationsEventsAndProperties(bool Properties, bool Events = false) // النموذج الرئيسي
        {

            if (Properties == true && Events == false)
            {
                ElementsTools.Form_.CustumProperties(this);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.Form_.CustumProperties(this);
            }
        } 

        private void dgvNotificationsEventsAndProperties(bool Properties, bool Events = false) // جدول عرض بيانات الاشعارات
        {
            if (Properties == true && Events == false)
            {
                if(GeneralAction.Notifications.Rows.Count > 0)
                {
                    dgvNotifications.DataSource = GeneralAction.Notifications;
                    ElementsTools.DataGridView_.CustumProperties(dgvNotifications);  // تخصيص خصائص جدول عرض البيانات


                    dgvNotifications.Columns[0].HeaderText = Cultures.ReturnTranslation("الموقع");
                    dgvNotifications.Columns[1].HeaderText = Cultures.ReturnTranslation("التاريخ والوقت");
                    dgvNotifications.Columns[2].HeaderText = Cultures.ReturnTranslation("رسالة");
                    dgvNotifications.Columns[3].HeaderText = Cultures.ReturnTranslation("رسالة آلية");
                    dgvNotifications.Columns[4].HeaderText = Cultures.ReturnTranslation("النص البرمجي");
                    dgvNotifications.Columns[5].HeaderText = Cultures.ReturnTranslation("الباراميترات");

                    dgvNotifications.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvNotifications.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvNotifications.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvNotifications.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvNotifications.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvNotifications.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    dgvNotifications.Columns[1].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss tt";

                    // اللغة
                    if (GeneralVariables.cultureCode == "AR")
                    {
                        dgvNotifications.Columns[2].Visible = true;
                        dgvNotifications.Columns[3].Visible = false;
                    }
                    else
                    {
                        dgvNotifications.Columns[2].Visible = false;
                        dgvNotifications.Columns[3].Visible = true;
                    }


                }
                ElementsTools.DataGridView_.CustumProperties(dgvNotifications);  // تخصيص خصائص جدول عرض البيانات
                dgvNotifications.ReadOnly = false;
                dgvNotifications.Enabled = true;
            }
            else  if (Properties == true && Events == true)
            {
                if (GeneralAction.Notifications.Rows.Count > 0)
                {
                    dgvNotifications.DataSource = GeneralAction.Notifications;
                    ElementsTools.DataGridView_.CustumProperties(dgvNotifications);  // تخصيص خصائص جدول عرض البيانات


                    dgvNotifications.Columns[0].HeaderText = Cultures.ReturnTranslation("الموقع");
                    dgvNotifications.Columns[1].HeaderText = Cultures.ReturnTranslation("التاريخ والوقت");
                    dgvNotifications.Columns[2].HeaderText = Cultures.ReturnTranslation("الرسالة ");
                    dgvNotifications.Columns[3].HeaderText = Cultures.ReturnTranslation("الرسالة ");
                    dgvNotifications.Columns[4].HeaderText = Cultures.ReturnTranslation("الباراميترات");

                    dgvNotifications.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvNotifications.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvNotifications.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvNotifications.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvNotifications.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                    dgvNotifications.Columns[1].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss tt";

                    // اللغة
                    if (GeneralVariables.cultureCode == "AR")
                    {
                        dgvNotifications.Columns[2].Visible = true;
                        dgvNotifications.Columns[3].Visible = false;
                    }
                    else
                    {
                        dgvNotifications.Columns[2].Visible = false;
                        dgvNotifications.Columns[3].Visible = true;
                    }

                }
                ElementsTools.DataGridView_.CustumProperties(dgvNotifications,true,true);  // تخصيص خصائص جدول عرض البيانات
                dgvNotifications.ReadOnly = false;
                dgvNotifications.Enabled = true;
            }
        }

        private void lblHeaderEventsAndProperties(bool Properties, bool Events = false) // العنوان
        {

            if (Properties == true && Events == false)
            {
                lblHeader.Text = Cultures.ReturnTranslation("الإشعارات");
                lblHeader.Left = (panel1.Width - (lblHeader.Width)) / 2;
                lblHeader.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);

            }
            else if (Properties == true && Events == true)
            {
                lblHeader.Text = Cultures.ReturnTranslation("الإشعارات");
                lblHeader.Left = (panel1.Width - (lblHeader.Width)) / 2;
                lblHeader.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ColorPropertyName.ForeColor_1);
            }
        }

        private void panel1EventsAndProperties(bool Properties, bool Events = false) // حاوية العنوان
        {
            if (Properties == true && Events == false)
            {
                panel1.BorderStyle = BorderStyle.None;
                panel1.BackColor = DisplayMode.ReturnColor(myElementType.Panel, ColorPropertyName.BackColor_3);

                ElementsTools.panel_.CustumProperties(panel1);
            }
            else if (Properties == true && Events == true)
            {
                ElementsTools.panel_.CustumProperties(panel1,ColorPropertyName.BackColor_3,true,true);
                //panel1.Paint += delegate (object sender, PaintEventArgs e) { ControlPaint.DrawBorder(e.Graphics, (sender as Panel).ClientRectangle, DisplayMode.ReturnColor(7), ButtonBorderStyle.Solid); }; // تغيير لون الاطار الخارجي
            }
        }

    }

}
