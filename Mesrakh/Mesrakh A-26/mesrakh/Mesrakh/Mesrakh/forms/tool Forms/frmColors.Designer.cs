
namespace Mesrakh
{
    partial class frmColors
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxElement = new System.Windows.Forms.ComboBox();
            this.cbxColorProperty = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxElement
            // 
            this.cbxElement.FormattingEnabled = true;
            this.cbxElement.Location = new System.Drawing.Point(12, 40);
            this.cbxElement.Name = "cbxElement";
            this.cbxElement.Size = new System.Drawing.Size(242, 21);
            this.cbxElement.TabIndex = 5;
            this.cbxElement.SelectedIndexChanged += new System.EventHandler(this.cbxElement_SelectedIndexChanged);
            // 
            // cbxColorProperty
            // 
            this.cbxColorProperty.FormattingEnabled = true;
            this.cbxColorProperty.Location = new System.Drawing.Point(12, 67);
            this.cbxColorProperty.Name = "cbxColorProperty";
            this.cbxColorProperty.Size = new System.Drawing.Size(242, 21);
            this.cbxColorProperty.TabIndex = 5;
            this.cbxColorProperty.SelectedIndexChanged += new System.EventHandler(this.cbxColorProperty_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmColors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(262, 238);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbxColorProperty);
            this.Controls.Add(this.cbxElement);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmColors";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "allColors";
            this.Load += new System.EventHandler(this.allColors_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmColors_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmColors_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmColors_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxElement;
        private System.Windows.Forms.ComboBox cbxColorProperty;
        private System.Windows.Forms.Button button1;
    }
}