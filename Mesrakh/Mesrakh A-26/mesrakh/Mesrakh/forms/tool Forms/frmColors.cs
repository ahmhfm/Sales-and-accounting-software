using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mesrakh
{
    public partial class frmColors : Form
    {
        public frmColors()
        {
            InitializeComponent();
            button1.Text = Cultures.ReturnTranslation("حفظ");
            button1.ForeColor = Color.Black;
        }
 
        private void allColors_Load(object sender, EventArgs e)
        {

            string[] elements = new string[15];
            elements[0] = myElementType.Button.ToString();
            elements[1] = myElementType.CheckBox.ToString();
            elements[2] = myElementType.ComboBox.ToString();
            elements[3] = myElementType.DataGridView.ToString();
            elements[4] = myElementType.DateTimePicker.ToString();
            elements[5] = myElementType.Form.ToString();
            elements[6] = myElementType.Label.ToString();
            elements[7] = myElementType.ListBox.ToString();
            elements[8] = myElementType.Panel.ToString();
            elements[9] = myElementType.PictureBox.ToString();
            elements[10] = myElementType.RadioButton.ToString();
            elements[11] = myElementType.TextBox.ToString();
            elements[12] = myElementType.TreeView.ToString();
            elements[13] = myElementType.TabControl.ToString();
            elements[14] = myElementType.GroupBox.ToString();

            string[] colorsproperties = new string[12];
            colorsproperties[0] = ColorPropertyName.BackColor_1.ToString();
            colorsproperties[1] = ColorPropertyName.BackColor_2.ToString();
            colorsproperties[2] = ColorPropertyName.BackColor_3.ToString();
            colorsproperties[3] = ColorPropertyName.BackColor_4.ToString();
            colorsproperties[4] = ColorPropertyName.BackColor_5.ToString();
            colorsproperties[5] = ColorPropertyName.BackColor_6.ToString();
            colorsproperties[6] = ColorPropertyName.ForeColor_1.ToString();
            colorsproperties[7] = ColorPropertyName.ForeColor_2.ToString();
            colorsproperties[8] = ColorPropertyName.ForeColor_3.ToString();
            colorsproperties[9] = ColorPropertyName.ForeColor_4.ToString();
            colorsproperties[10] = ColorPropertyName.ForeColor_5.ToString();
            colorsproperties[11] = ColorPropertyName.ForeColor_6.ToString();

            cbxElement.Items.AddRange(elements);
            cbxColorProperty.Items.AddRange(colorsproperties);
        }



        private void cbxElement_SelectedIndexChanged(object sender, EventArgs e)
        {

            myElementType mye = new myElementType();
            if (myElementType.Button.ToString() == cbxElement.Text)
            {
                mye = myElementType.Button;
            }
            else if (myElementType.CheckBox.ToString() == cbxElement.Text)
            {
                mye = myElementType.CheckBox;
            }
            else if (myElementType.ComboBox.ToString() == cbxElement.Text)
            {
                mye = myElementType.ComboBox;
            }
            else if (myElementType.DataGridView.ToString() == cbxElement.Text)
            {
                mye = myElementType.DataGridView;
            }
            else if (myElementType.DateTimePicker.ToString() == cbxElement.Text)
            {
                mye = myElementType.DateTimePicker;
            }
            else if (myElementType.Form.ToString() == cbxElement.Text)
            {
                mye = myElementType.Form;
            }
            else if (myElementType.Label.ToString() == cbxElement.Text)
            {
                mye = myElementType.Label;
            }
            else if (myElementType.ListBox.ToString() == cbxElement.Text)
            {
                mye = myElementType.ListBox;
            }
            else if (myElementType.Panel.ToString() == cbxElement.Text)
            {
                mye = myElementType.Panel;
            }
            else if (myElementType.PictureBox.ToString() == cbxElement.Text)
            {
                mye = myElementType.PictureBox;
            }
            else if (myElementType.RadioButton.ToString() == cbxElement.Text)
            {
                mye = myElementType.RadioButton;
            }
            else if (myElementType.TextBox.ToString() == cbxElement.Text)
            {
                mye = myElementType.TextBox;
            }
            else if (myElementType.TreeView.ToString() == cbxElement.Text)
            {
                mye = myElementType.TreeView;
            }
            else if (myElementType.TabControl.ToString() == cbxElement.Text)
            {
                mye = myElementType.TabControl;
            }
            else if (myElementType.GroupBox.ToString() == cbxElement.Text)
            {
                mye = myElementType.GroupBox;
            }


            ColorPropertyName mycp = new ColorPropertyName();
            if (ColorPropertyName.ForeColor_1.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.ForeColor_1;
            }
            else if (ColorPropertyName.ForeColor_2.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.ForeColor_2;
            }
            else if (ColorPropertyName.ForeColor_3.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.ForeColor_3;
            }
            else if (ColorPropertyName.ForeColor_4.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.ForeColor_4;
            }
            else if (ColorPropertyName.ForeColor_5.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.ForeColor_5;
            }
            else if (ColorPropertyName.ForeColor_6.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.ForeColor_6;
            }
            else if (ColorPropertyName.BackColor_1.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.BackColor_1;
            }
            else if (ColorPropertyName.BackColor_2.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.BackColor_2;
            }
            else if (ColorPropertyName.BackColor_3.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.BackColor_3;
            }
            else if (ColorPropertyName.BackColor_4.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.BackColor_4;
            }
            else if (ColorPropertyName.BackColor_5.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.BackColor_5;
            }
            else if (ColorPropertyName.BackColor_6.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.BackColor_6;
            }

            this.BackColor = DisplayMode.ReturnColor(mye,mycp);
        }

        private void cbxColorProperty_SelectedIndexChanged(object sender, EventArgs e)
        {

            myElementType mye = new myElementType();
            if (myElementType.Button.ToString() == cbxElement.Text)
            {
                mye = myElementType.Button;
            }
            else if (myElementType.CheckBox.ToString() == cbxElement.Text)
            {
                mye = myElementType.CheckBox;
            }
            else if (myElementType.ComboBox.ToString() == cbxElement.Text)
            {
                mye = myElementType.ComboBox;
            }
            else if (myElementType.DataGridView.ToString() == cbxElement.Text)
            {
                mye = myElementType.DataGridView;
            }
            else if (myElementType.DateTimePicker.ToString() == cbxElement.Text)
            {
                mye = myElementType.DateTimePicker;
            }
            else if (myElementType.Form.ToString() == cbxElement.Text)
            {
                mye = myElementType.Form;
            }
            else if (myElementType.Label.ToString() == cbxElement.Text)
            {
                mye = myElementType.Label;
            }
            else if (myElementType.ListBox.ToString() == cbxElement.Text)
            {
                mye = myElementType.ListBox;
            }
            else if (myElementType.Panel.ToString() == cbxElement.Text)
            {
                mye = myElementType.Panel;
            }
            else if (myElementType.PictureBox.ToString() == cbxElement.Text)
            {
                mye = myElementType.PictureBox;
            }
            else if (myElementType.RadioButton.ToString() == cbxElement.Text)
            {
                mye = myElementType.RadioButton;
            }
            else if (myElementType.TextBox.ToString() == cbxElement.Text)
            {
                mye = myElementType.TextBox;
            }
            else if (myElementType.TreeView.ToString() == cbxElement.Text)
            {
                mye = myElementType.TreeView;
            }
            else if (myElementType.TabControl.ToString() == cbxElement.Text)
            {
                mye = myElementType.TabControl;
            }
            else if (myElementType.GroupBox.ToString() == cbxElement.Text)
            {
                mye = myElementType.GroupBox;
            }

            ColorPropertyName mycp = new ColorPropertyName();
            if (ColorPropertyName.ForeColor_1.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.ForeColor_1;
            }
            else if (ColorPropertyName.ForeColor_2.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.ForeColor_2;
            }
            else if (ColorPropertyName.ForeColor_3.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.ForeColor_3;
            }
            else if (ColorPropertyName.ForeColor_4.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.ForeColor_4;
            }
            else if (ColorPropertyName.ForeColor_5.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.ForeColor_5;
            }
            else if (ColorPropertyName.ForeColor_6.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.ForeColor_6;
            }
            else if (ColorPropertyName.BackColor_1.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.BackColor_1;
            }
            else if (ColorPropertyName.BackColor_2.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.BackColor_2;
            }
            else if (ColorPropertyName.BackColor_3.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.BackColor_3;
            }
            else if (ColorPropertyName.BackColor_4.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.BackColor_4;
            }
            else if (ColorPropertyName.BackColor_5.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.BackColor_5;
            }
            else if (ColorPropertyName.BackColor_6.ToString() == cbxColorProperty.Text)
            {
                mycp = ColorPropertyName.BackColor_6;
            }

            this.BackColor = DisplayMode.ReturnColor(mye, mycp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        int movex;
        int movey;
        bool mouseDown = false;
        private void frmColors_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
             movex = e.X ;
             movey = e.Y ;
        }

        private void frmColors_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }



        private void frmColors_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.SetDesktopLocation(MousePosition.X - movex, MousePosition.Y - movey);
            }
        }
    }
}
