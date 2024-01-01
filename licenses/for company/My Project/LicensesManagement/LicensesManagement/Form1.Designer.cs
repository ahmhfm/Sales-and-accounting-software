
namespace LicensesManagement
{
    partial class frmMain
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
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.txt01TransferBanckNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt01TransferBank = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt01TransferDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt01TransferTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt01TransferAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt02TransferAmount = new System.Windows.Forms.TextBox();
            this.txt02TransferTime = new System.Windows.Forms.TextBox();
            this.txt02TransferDate = new System.Windows.Forms.TextBox();
            this.txt02TransferBank = new System.Windows.Forms.TextBox();
            this.txt02TransferBanckNumber = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btn02RegisterNewTransfare = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(12, 122);
            this.dgv1.Margin = new System.Windows.Forms.Padding(2);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(648, 464);
            this.dgv1.TabIndex = 0;
            this.dgv1.SelectionChanged += new System.EventHandler(this.dgv1_SelectionChanged);
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(664, 122);
            this.dgv2.Margin = new System.Windows.Forms.Padding(2);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(648, 464);
            this.dgv2.TabIndex = 1;
            this.dgv2.SelectionChanged += new System.EventHandler(this.dgv2_SelectionChanged);
            // 
            // txt01TransferBanckNumber
            // 
            this.txt01TransferBanckNumber.Location = new System.Drawing.Point(307, 602);
            this.txt01TransferBanckNumber.Name = "txt01TransferBanckNumber";
            this.txt01TransferBanckNumber.Size = new System.Drawing.Size(172, 24);
            this.txt01TransferBanckNumber.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(181, 602);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "رقم الحوالة :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt01TransferBank
            // 
            this.txt01TransferBank.Location = new System.Drawing.Point(307, 632);
            this.txt01TransferBank.Name = "txt01TransferBank";
            this.txt01TransferBank.Size = new System.Drawing.Size(172, 24);
            this.txt01TransferBank.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(181, 632);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "إسم البنك :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt01TransferDate
            // 
            this.txt01TransferDate.Location = new System.Drawing.Point(307, 662);
            this.txt01TransferDate.Name = "txt01TransferDate";
            this.txt01TransferDate.Size = new System.Drawing.Size(172, 24);
            this.txt01TransferDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(181, 662);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "تاريخ الحوالة :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt01TransferTime
            // 
            this.txt01TransferTime.Location = new System.Drawing.Point(307, 692);
            this.txt01TransferTime.Name = "txt01TransferTime";
            this.txt01TransferTime.Size = new System.Drawing.Size(172, 24);
            this.txt01TransferTime.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(181, 692);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "وقت الحوالة :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt01TransferAmount
            // 
            this.txt01TransferAmount.Location = new System.Drawing.Point(307, 722);
            this.txt01TransferAmount.Name = "txt01TransferAmount";
            this.txt01TransferAmount.Size = new System.Drawing.Size(172, 24);
            this.txt01TransferAmount.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(181, 722);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "مبلغ الحوالة :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(828, 722);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = "مبلغ الحوالة :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(828, 692);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 24);
            this.label7.TabIndex = 10;
            this.label7.Text = "وقت الحوالة :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(828, 662);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 24);
            this.label8.TabIndex = 11;
            this.label8.Text = "تاريخ الحوالة :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(828, 632);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 24);
            this.label9.TabIndex = 12;
            this.label9.Text = "إسم البنك :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(828, 602);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 24);
            this.label10.TabIndex = 13;
            this.label10.Text = "رقم الحوالة :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt02TransferAmount
            // 
            this.txt02TransferAmount.Location = new System.Drawing.Point(954, 722);
            this.txt02TransferAmount.Name = "txt02TransferAmount";
            this.txt02TransferAmount.Size = new System.Drawing.Size(172, 24);
            this.txt02TransferAmount.TabIndex = 4;
            // 
            // txt02TransferTime
            // 
            this.txt02TransferTime.Location = new System.Drawing.Point(954, 692);
            this.txt02TransferTime.Multiline = true;
            this.txt02TransferTime.Name = "txt02TransferTime";
            this.txt02TransferTime.Size = new System.Drawing.Size(172, 27);
            this.txt02TransferTime.TabIndex = 5;
            // 
            // txt02TransferDate
            // 
            this.txt02TransferDate.Location = new System.Drawing.Point(954, 662);
            this.txt02TransferDate.Name = "txt02TransferDate";
            this.txt02TransferDate.Size = new System.Drawing.Size(172, 24);
            this.txt02TransferDate.TabIndex = 6;
            // 
            // txt02TransferBank
            // 
            this.txt02TransferBank.Location = new System.Drawing.Point(954, 632);
            this.txt02TransferBank.Name = "txt02TransferBank";
            this.txt02TransferBank.Size = new System.Drawing.Size(172, 24);
            this.txt02TransferBank.TabIndex = 7;
            // 
            // txt02TransferBanckNumber
            // 
            this.txt02TransferBanckNumber.Location = new System.Drawing.Point(954, 602);
            this.txt02TransferBanckNumber.Name = "txt02TransferBanckNumber";
            this.txt02TransferBanckNumber.Size = new System.Drawing.Size(172, 24);
            this.txt02TransferBanckNumber.TabIndex = 8;
            // 
            // btnConnect
            // 
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Location = new System.Drawing.Point(505, 632);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(317, 84);
            this.btnConnect.TabIndex = 14;
            this.btnConnect.Text = "إعتماد الحوالة وتفعيل رخصة إستخدام البرنامج";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btn02RegisterNewTransfare
            // 
            this.btn02RegisterNewTransfare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn02RegisterNewTransfare.Location = new System.Drawing.Point(1132, 602);
            this.btn02RegisterNewTransfare.Name = "btn02RegisterNewTransfare";
            this.btn02RegisterNewTransfare.Size = new System.Drawing.Size(172, 144);
            this.btn02RegisterNewTransfare.TabIndex = 15;
            this.btn02RegisterNewTransfare.Text = "تسجيل حوالة واردة للحساب";
            this.btn02RegisterNewTransfare.UseVisualStyleBackColor = true;
            this.btn02RegisterNewTransfare.Click += new System.EventHandler(this.btn02RegisterNewTransfare_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(12, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(648, 24);
            this.label11.TabIndex = 16;
            this.label11.Text = "طلبات تفعيل تراخيص إستخدام البرامج";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(664, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(648, 24);
            this.label12.TabIndex = 17;
            this.label12.Text = "الحوالات التي وردت إلى الحساب";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1328, 758);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn02RegisterNewTransfare);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt02TransferAmount);
            this.Controls.Add(this.txt02TransferTime);
            this.Controls.Add(this.txt02TransferDate);
            this.Controls.Add(this.txt02TransferBank);
            this.Controls.Add(this.txt02TransferBanckNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt01TransferAmount);
            this.Controls.Add(this.txt01TransferTime);
            this.Controls.Add(this.txt01TransferDate);
            this.Controls.Add(this.txt01TransferBank);
            this.Controls.Add(this.txt01TransferBanckNumber);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.dgv1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.TextBox txt01TransferBanckNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt01TransferBank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt01TransferDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt01TransferTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt01TransferAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt02TransferAmount;
        private System.Windows.Forms.TextBox txt02TransferTime;
        private System.Windows.Forms.TextBox txt02TransferDate;
        private System.Windows.Forms.TextBox txt02TransferBank;
        private System.Windows.Forms.TextBox txt02TransferBanckNumber;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btn02RegisterNewTransfare;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

