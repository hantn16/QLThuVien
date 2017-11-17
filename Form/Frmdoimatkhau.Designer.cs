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
            this.txtnhaplai = new System.Windows.Forms.TextBox();
            this.txtMatKhaumoi = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btthaydoi
            // 
            this.btthaydoi.BackColor = System.Drawing.Color.Transparent;
            this.btthaydoi.ForeColor = System.Drawing.Color.Black;
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
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtnhaplai);
            this.groupBox1.Controls.Add(this.txtMatKhaumoi);
            this.groupBox1.Controls.Add(this.txtMatKhaucu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 151);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin";
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
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Transparent;
            this.btnThoat.ForeColor = System.Drawing.Color.Black;
            this.btnThoat.Location = new System.Drawing.Point(194, 169);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Tag = "5";
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmdoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyThuVien.Properties.Resources.blue_backgroud;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(350, 197);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThoat);
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
        private System.Windows.Forms.Button btnThoat;
    }
}