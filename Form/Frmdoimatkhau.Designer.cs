namespace quanly.frm
{
    partial class FrmdoiMatKhau
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
            this.btthaydoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMatKhaucu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.l2 = new System.Windows.Forms.Label();
            this.l1 = new System.Windows.Forms.Label();
            this.txtnhaplai = new System.Windows.Forms.TextBox();
            this.txtMatKhaumoi = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btthaydoi
            // 
            this.btthaydoi.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btthaydoi.ForeColor = System.Drawing.Color.Cyan;
            this.btthaydoi.Location = new System.Drawing.Point(103, 169);
            this.btthaydoi.Name = "btthaydoi";
            this.btthaydoi.Size = new System.Drawing.Size(75, 23);
            this.btthaydoi.TabIndex = 3;
            this.btthaydoi.Tag = "4";
            this.btthaydoi.Text = "Thực hiện";
            this.btthaydoi.UseVisualStyleBackColor = false;
            this.btthaydoi.Click += new System.EventHandler(this.btthaydoi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mật khẩu cũ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nhập lại mật khẩu mới";
            // 
            // txtMatKhaucu
            // 
            this.txtMatKhaucu.Location = new System.Drawing.Point(153, 27);
            this.txtMatKhaucu.Name = "txtMatKhaucu";
            this.txtMatKhaucu.PasswordChar = '*';
            this.txtMatKhaucu.Size = new System.Drawing.Size(157, 20);
            this.txtMatKhaucu.TabIndex = 0;
            this.txtMatKhaucu.Tag = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.l2);
            this.groupBox1.Controls.Add(this.l1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtnhaplai);
            this.groupBox1.Controls.Add(this.txtMatKhaumoi);
            this.groupBox1.Controls.Add(this.txtMatKhaucu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 151);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin";
            // 
            // l2
            // 
            this.l2.AutoSize = true;
            this.l2.Location = new System.Drawing.Point(317, 93);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(35, 13);
            this.l2.TabIndex = 3;
            this.l2.Text = "+ Lỗi";
            this.l2.Visible = false;
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.Location = new System.Drawing.Point(317, 27);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(35, 13);
            this.l1.TabIndex = 3;
            this.l1.Text = "+ Lỗi";
            this.l1.Visible = false;
            // 
            // txtnhaplai
            // 
            this.txtnhaplai.Location = new System.Drawing.Point(153, 90);
            this.txtnhaplai.Name = "txtnhaplai";
            this.txtnhaplai.PasswordChar = '*';
            this.txtnhaplai.Size = new System.Drawing.Size(157, 20);
            this.txtnhaplai.TabIndex = 2;
            this.txtnhaplai.Tag = "3";
            this.txtnhaplai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnhaplai_KeyDown);
            // 
            // txtMatKhaumoi
            // 
            this.txtMatKhaumoi.Location = new System.Drawing.Point(153, 61);
            this.txtMatKhaumoi.Name = "txtMatKhaumoi";
            this.txtMatKhaumoi.PasswordChar = '*';
            this.txtMatKhaumoi.Size = new System.Drawing.Size(157, 20);
            this.txtMatKhaumoi.TabIndex = 1;
            this.txtMatKhaumoi.Tag = "2";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.ForeColor = System.Drawing.Color.Cyan;
            this.button1.Location = new System.Drawing.Point(194, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Tag = "5";
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmdoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::quanlythuvien.Properties.Resources.nen1_copy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(370, 197);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btthaydoi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmdoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu đăng nhập";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmdoiMatKhau_FormClosed);
            this.Load += new System.EventHandler(this.FrmdoiMatKhau_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btthaydoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMatKhaucu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtnhaplai;
        private System.Windows.Forms.TextBox txtMatKhaumoi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label l1;
    }
}