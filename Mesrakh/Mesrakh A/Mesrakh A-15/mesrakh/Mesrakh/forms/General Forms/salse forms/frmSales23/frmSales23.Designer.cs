
namespace Mesrakh
{
    partial class frmSales23
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnl002 = new System.Windows.Forms.Panel();
            this.pic001 = new System.Windows.Forms.PictureBox();
            this.pnl001 = new System.Windows.Forms.Panel();
            this.lblTitel = new System.Windows.Forms.Label();
            this.tc001 = new System.Windows.Forms.TabControl();
            this.pnlMain.SuspendLayout();
            this.pnl002.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic001)).BeginInit();
            this.pnl001.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnl002);
            this.pnlMain.Controls.Add(this.pnl001);
            this.pnlMain.Location = new System.Drawing.Point(1, 1);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1078, 718);
            this.pnlMain.TabIndex = 1;
            // 
            // pnl002
            // 
            this.pnl002.Controls.Add(this.tc001);
            this.pnl002.Controls.Add(this.pic001);
            this.pnl002.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl002.Location = new System.Drawing.Point(0, 44);
            this.pnl002.Margin = new System.Windows.Forms.Padding(0);
            this.pnl002.Name = "pnl002";
            this.pnl002.Size = new System.Drawing.Size(1078, 674);
            this.pnl002.TabIndex = 2;
            // 
            // pic001
            // 
            this.pic001.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic001.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic001.Location = new System.Drawing.Point(1042, 4);
            this.pic001.Name = "pic001";
            this.pic001.Size = new System.Drawing.Size(34, 33);
            this.pic001.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic001.TabIndex = 1;
            this.pic001.TabStop = false;
            // 
            // pnl001
            // 
            this.pnl001.Controls.Add(this.lblTitel);
            this.pnl001.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl001.Location = new System.Drawing.Point(0, 0);
            this.pnl001.Margin = new System.Windows.Forms.Padding(0);
            this.pnl001.Name = "pnl001";
            this.pnl001.Size = new System.Drawing.Size(1078, 44);
            this.pnl001.TabIndex = 1;
            // 
            // lblTitel
            // 
            this.lblTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitel.Location = new System.Drawing.Point(0, 0);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(1078, 44);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "lblTitel";
            this.lblTitel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tc001
            // 
            this.tc001.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tc001.Location = new System.Drawing.Point(0, 43);
            this.tc001.Margin = new System.Windows.Forms.Padding(0);
            this.tc001.Name = "tc001";
            this.tc001.RightToLeftLayout = true;
            this.tc001.SelectedIndex = 0;
            this.tc001.Size = new System.Drawing.Size(1078, 631);
            this.tc001.TabIndex = 2;
            // 
            // frmSales23
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSales23";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "frmSales23";
            this.pnlMain.ResumeLayout(false);
            this.pnl002.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic001)).EndInit();
            this.pnl001.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Panel pnl002;
        private System.Windows.Forms.Panel pnl001;
        private System.Windows.Forms.PictureBox pic001;
        private System.Windows.Forms.TabControl tc001;
    }
}