namespace quanly.frm
{
    partial class Frmthongtinsachtheongay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmthongtinsachtheongay));
            this.mCldChonNgay = new System.Windows.Forms.MonthCalendar();
            this.cbHinhThucMuon = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mCldChonNgay
            // 
            this.mCldChonNgay.Location = new System.Drawing.Point(12, 17);
            this.mCldChonNgay.MaxSelectionCount = 30;
            this.mCldChonNgay.Name = "mCldChonNgay";
            this.mCldChonNgay.TabIndex = 0;
            this.mCldChonNgay.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            this.mCldChonNgay.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // cbHinhThucMuon
            // 
            this.cbHinhThucMuon.FormattingEnabled = true;
            this.cbHinhThucMuon.Items.AddRange(new object[] {
            "Mượn tại chỗ",
            "Mượn về nhà",
            "Mượn giáo trình"});
            this.cbHinhThucMuon.Location = new System.Drawing.Point(12, 204);
            this.cbHinhThucMuon.Name = "cbHinhThucMuon";
            this.cbHinhThucMuon.Size = new System.Drawing.Size(121, 21);
            this.cbHinhThucMuon.TabIndex = 12;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(9, 188);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "Thể thức mượn";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(108, 231);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(213, 12);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(779, 267);
            this.dgvData.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.mCldChonNgay);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.cbHinhThucMuon);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 267);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tùy chọn";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 231);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 14;
            this.btnLoad.Text = "Cập nhật";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Frmthongtinsachtheongay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1004, 286);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frmthongtinsachtheongay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thông tin sách theo ngày";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frmthongtinsachtheongay_FormClosed);
            this.Load += new System.EventHandler(this.Frmthongtinsachtheongay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mCldChonNgay;
        private System.Windows.Forms.ComboBox cbHinhThucMuon;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoad;
    }
}