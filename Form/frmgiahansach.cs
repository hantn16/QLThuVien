using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using quanly.doituong;
using System.Data.SqlClient;


namespace quanly.frm
{
    public partial class frmgiahansach : Form
    {
        public DateTime NgayGiaHan
        {
            get
            {
                return dtpkGiaHan.Value;
            }
        }
        public DialogResult Result = DialogResult.Cancel;
        public frmgiahansach()
        {
            InitializeComponent();
        }

        private void frmgiahansach_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
            dtpkGiaHan.Focus();
            dtpkGiaHan.Format = DateTimePickerFormat.Custom;
            dtpkGiaHan.CustomFormat = "dd/MM/yyyy";
            dtpkGiaHan.MinDate = DateTime.Now;
            dtpkGiaHan.Value = DateTime.Now.AddDays(3);
        }

        private void frmgiahansach_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }
        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}