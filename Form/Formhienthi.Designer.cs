namespace quanly.frm
{
    partial class Formhienthi
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btcapnhat = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bttaomoi = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btxoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtimkiem = new System.Windows.Forms.ToolStripTextBox();
            this.cbdanhmuc = new System.Windows.Forms.ToolStripComboBox();
            this.bttimkiem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.dghienthi = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cậpNhậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ỗâToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dghienthi)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btcapnhat,
            this.toolStripSeparator1,
            this.bttaomoi,
            this.toolStripSeparator2,
            this.btxoa,
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.toolStripSeparator5,
            this.tbtimkiem,
            this.cbdanhmuc,
            this.bttimkiem,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(690, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btcapnhat
            // 
            this.btcapnhat.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btcapnhat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btcapnhat.Name = "btcapnhat";
            this.btcapnhat.Size = new System.Drawing.Size(59, 22);
            this.btcapnhat.Text = "Cập nhật";
            this.btcapnhat.Click += new System.EventHandler(this.btcapnhat_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bttaomoi
            // 
            this.bttaomoi.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttaomoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttaomoi.Name = "bttaomoi";
            this.bttaomoi.Size = new System.Drawing.Size(55, 22);
            this.bttaomoi.Text = "Tạo mới";
            this.bttaomoi.Click += new System.EventHandler(this.bttaomoi_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btxoa
            // 
            this.btxoa.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btxoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btxoa.Name = "btxoa";
            this.btxoa.Size = new System.Drawing.Size(31, 22);
            this.btxoa.Text = "Xóa";
            this.btxoa.Click += new System.EventHandler(this.btxoa_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtimkiem
            // 
            this.tbtimkiem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbtimkiem.Name = "tbtimkiem";
            this.tbtimkiem.Size = new System.Drawing.Size(100, 25);
            this.tbtimkiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbtimkiem_KeyDown);
            // 
            // cbdanhmuc
            // 
            this.cbdanhmuc.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cbdanhmuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbdanhmuc.Name = "cbdanhmuc";
            this.cbdanhmuc.Size = new System.Drawing.Size(121, 25);
            // 
            // bttimkiem
            // 
            this.bttimkiem.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttimkiem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttimkiem.Name = "bttimkiem";
            this.bttimkiem.Size = new System.Drawing.Size(63, 22);
            this.bttimkiem.Text = "Tìm kiếm";
            this.bttimkiem.Click += new System.EventHandler(this.bttimkiem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // dghienthi
            // 
            this.dghienthi.AllowUserToAddRows = false;
            this.dghienthi.AllowUserToOrderColumns = true;
            this.dghienthi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dghienthi.ContextMenuStrip = this.contextMenuStrip1;
            this.dghienthi.Location = new System.Drawing.Point(0, 28);
            this.dghienthi.Name = "dghienthi";
            this.dghienthi.Size = new System.Drawing.Size(690, 307);
            this.dghienthi.TabIndex = 1;
            this.dghienthi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dghienthi_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cậpNhậtToolStripMenuItem,
            this.ỗâToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 70);
            // 
            // cậpNhậtToolStripMenuItem
            // 
            this.cậpNhậtToolStripMenuItem.Name = "cậpNhậtToolStripMenuItem";
            this.cậpNhậtToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.cậpNhậtToolStripMenuItem.Text = "Cập nhật";
            // 
            // ỗâToolStripMenuItem
            // 
            this.ỗâToolStripMenuItem.Name = "ỗâToolStripMenuItem";
            this.ỗâToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.ỗâToolStripMenuItem.Text = "Xóa";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(605, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Formhienthi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(690, 336);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dghienthi);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Formhienthi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hiển thị thông tin danh mục";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Formhienthi_FormClosed);
            this.Load += new System.EventHandler(this.Formhienthi_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dghienthi)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btcapnhat;
        private System.Windows.Forms.ToolStripButton bttaomoi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btxoa;
        private System.Windows.Forms.ToolStripButton bttimkiem;
        private System.Windows.Forms.ToolStripTextBox tbtimkiem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripComboBox cbdanhmuc;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.DataGridView dghienthi;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cậpNhậtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ỗâToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.Button button1;

    }
}