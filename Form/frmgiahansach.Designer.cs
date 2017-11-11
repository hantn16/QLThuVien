namespace quanly.frm
{
    partial class frmgiahansach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmgiahansach));
            this.btthoat = new System.Windows.Forms.Button();
            this.bthuythaotac = new System.Windows.Forms.Button();
            this.btgiahan = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btkiemtratt = new System.Windows.Forms.Button();
            this.txtMaTaiLieu = new System.Windows.Forms.TextBox();
            this.txtngaymuon = new System.Windows.Forms.TextBox();
            this.txtMaDocGia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btthoat
            // 
            this.btthoat.Location = new System.Drawing.Point(359, 8);
            this.btthoat.Name = "btthoat";
            this.btthoat.Size = new System.Drawing.Size(62, 30);
            this.btthoat.TabIndex = 5;
            this.btthoat.Tag = "7";
            this.btthoat.Text = "Thoát";
            this.btthoat.UseVisualStyleBackColor = true;
            this.btthoat.Click += new System.EventHandler(this.btthoat_Click);
            // 
            // bthuythaotac
            // 
            this.bthuythaotac.Location = new System.Drawing.Point(97, 8);
            this.bthuythaotac.Name = "bthuythaotac";
            this.bthuythaotac.Size = new System.Drawing.Size(84, 30);
            this.bthuythaotac.TabIndex = 4;
            this.bthuythaotac.Tag = "6";
            this.bthuythaotac.Text = "Huỷ thao tác";
            this.bthuythaotac.UseVisualStyleBackColor = true;
            this.bthuythaotac.Click += new System.EventHandler(this.bthuythaotac_Click);
            // 
            // btgiahan
            // 
            this.btgiahan.Location = new System.Drawing.Point(6, 8);
            this.btgiahan.Name = "btgiahan";
            this.btgiahan.Size = new System.Drawing.Size(85, 30);
            this.btgiahan.TabIndex = 3;
            this.btgiahan.Tag = "5";
            this.btgiahan.Text = "Gia hạn";
            this.btgiahan.UseVisualStyleBackColor = true;
            this.btgiahan.Click += new System.EventHandler(this.btgiahan_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox3.Controls.Add(this.btthoat);
            this.groupBox3.Controls.Add(this.btgiahan);
            this.groupBox3.Controls.Add(this.bthuythaotac);
            this.groupBox3.ForeColor = System.Drawing.Color.LawnGreen;
            this.groupBox3.Location = new System.Drawing.Point(15, 123);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(427, 41);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(6, 47);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(415, 10);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Controls.Add(this.btkiemtratt);
            this.groupBox1.Controls.Add(this.txtMaTaiLieu);
            this.groupBox1.Controls.Add(this.txtngaymuon);
            this.groupBox1.Controls.Add(this.txtMaDocGia);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 105);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kiểm tra thông tin sách";
            // 
            // btkiemtratt
            // 
            this.btkiemtratt.Location = new System.Drawing.Point(307, 19);
            this.btkiemtratt.Name = "btkiemtratt";
            this.btkiemtratt.Size = new System.Drawing.Size(114, 23);
            this.btkiemtratt.TabIndex = 2;
            this.btkiemtratt.Tag = "3";
            this.btkiemtratt.Text = "Kiểm tra thông tin";
            this.btkiemtratt.UseVisualStyleBackColor = true;
            this.btkiemtratt.Click += new System.EventHandler(this.btkiemtratt_Click);
            // 
            // txtMaTaiLieu
            // 
            this.txtMaTaiLieu.Location = new System.Drawing.Point(219, 22);
            this.txtMaTaiLieu.Name = "txtMaTaiLieu";
            this.txtMaTaiLieu.Size = new System.Drawing.Size(77, 20);
            this.txtMaTaiLieu.TabIndex = 1;
            this.txtMaTaiLieu.Tag = "2";
            this.txtMaTaiLieu.TextChanged += new System.EventHandler(this.txtMaTaiLieu_TextChanged);
            this.txtMaTaiLieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaTaiLieu_KeyDown);
            // 
            // txtngaymuon
            // 
            this.txtngaymuon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtngaymuon.Enabled = false;
            this.txtngaymuon.Location = new System.Drawing.Point(79, 70);
            this.txtngaymuon.Name = "txtngaymuon";
            this.txtngaymuon.Size = new System.Drawing.Size(100, 20);
            this.txtngaymuon.TabIndex = 25;
            this.txtngaymuon.Tag = "4";
            // 
            // txtMaDocGia
            // 
            this.txtMaDocGia.Location = new System.Drawing.Point(79, 22);
            this.txtMaDocGia.Name = "txtMaDocGia";
            this.txtMaDocGia.Size = new System.Drawing.Size(73, 20);
            this.txtMaDocGia.TabIndex = 0;
            this.txtMaDocGia.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Mã sách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ngày mượn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Mã sinh viên";
            // 
            // frmgiahansach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::quanlythuvien.Properties.Resources.nen11;
            this.ClientSize = new System.Drawing.Size(448, 169);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmgiahansach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gia hạn sách";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmgiahansach_FormClosed);
            this.Load += new System.EventHandler(this.frmgiahansach_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btthoat;
        private System.Windows.Forms.Button bthuythaotac;
        private System.Windows.Forms.Button btgiahan;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaTaiLieu;
        private System.Windows.Forms.TextBox txtngaymuon;
        private System.Windows.Forms.TextBox txtMaDocGia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btkiemtratt;
    }
}