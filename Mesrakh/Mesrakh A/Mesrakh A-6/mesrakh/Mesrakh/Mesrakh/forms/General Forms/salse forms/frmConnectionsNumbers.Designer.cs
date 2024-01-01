
namespace Mesrakh.forms.General_Forms.salse_forms
{
    partial class frmConnectionsNumbers
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTitel = new System.Windows.Forms.Label();
            this.cbxContactMethodsTypes = new System.Windows.Forms.ComboBox();
            this.txtCommunicationNo = new System.Windows.Forms.TextBox();
            this.dgvAllConnectionNumbers = new System.Windows.Forms.DataGridView();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllConnectionNumbers)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnDelete);
            this.pnlMain.Controls.Add(this.btnAdd);
            this.pnlMain.Controls.Add(this.lblTitel);
            this.pnlMain.Controls.Add(this.cbxContactMethodsTypes);
            this.pnlMain.Controls.Add(this.txtCommunicationNo);
            this.pnlMain.Controls.Add(this.dgvAllConnectionNumbers);
            this.pnlMain.Location = new System.Drawing.Point(12, 12);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(365, 202);
            this.pnlMain.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(15, 69);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(163, 26);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(188, 69);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(163, 26);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "اضافة";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lblTitel
            // 
            this.lblTitel.Location = new System.Drawing.Point(15, 6);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(334, 24);
            this.lblTitel.TabIndex = 14;
            this.lblTitel.Text = "label1";
            this.lblTitel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxContactMethodsTypes
            // 
            this.cbxContactMethodsTypes.FormattingEnabled = true;
            this.cbxContactMethodsTypes.Location = new System.Drawing.Point(232, 35);
            this.cbxContactMethodsTypes.Name = "cbxContactMethodsTypes";
            this.cbxContactMethodsTypes.Size = new System.Drawing.Size(121, 28);
            this.cbxContactMethodsTypes.TabIndex = 13;
            // 
            // txtCommunicationNo
            // 
            this.txtCommunicationNo.Location = new System.Drawing.Point(11, 35);
            this.txtCommunicationNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCommunicationNo.Multiline = true;
            this.txtCommunicationNo.Name = "txtCommunicationNo";
            this.txtCommunicationNo.Size = new System.Drawing.Size(218, 28);
            this.txtCommunicationNo.TabIndex = 12;
            // 
            // dgvAllConnectionNumbers
            // 
            this.dgvAllConnectionNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllConnectionNumbers.Location = new System.Drawing.Point(11, 99);
            this.dgvAllConnectionNumbers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvAllConnectionNumbers.Name = "dgvAllConnectionNumbers";
            this.dgvAllConnectionNumbers.Size = new System.Drawing.Size(342, 97);
            this.dgvAllConnectionNumbers.TabIndex = 11;
            // 
            // frmConnectionsNumbers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(389, 226);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConnectionsNumbers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "frmConnectionsNumbers";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllConnectionNumbers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.ComboBox cbxContactMethodsTypes;
        private System.Windows.Forms.TextBox txtCommunicationNo;
        private System.Windows.Forms.DataGridView dgvAllConnectionNumbers;
    }
}