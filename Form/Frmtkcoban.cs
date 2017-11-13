using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;

namespace quanly.frm
{
    public partial class Frmtkcoban : Form
    {
        public Frmtkcoban()
        {
            InitializeComponent();
        }
        private void Frmtkcoban_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem tk = new TimKiem();
            DataTable dt = tk.TKCoBan(txtTimKiem.Text);
            dgvListTaiLieu.DataSource = dt;
            dgvListTaiLieu.Refresh();
        }

        private void txttimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) btnTimKiem_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCapNhatsach frm = new FrmCapNhatsach();
                frm.selectedID = Convert.ToInt32(dgvListTaiLieu.SelectedCells[0].OwningRow.Cells["ID"].Value);
                frm.ShowDialog();
                //FrmCapNhatsach.tb = ds.Tables[0].Rows[cm.Position][0].ToString();
                //cn.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Frmtkcoban_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }

        private void dgvListTaiLieu_DataSourceChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvListTaiLieu.DataSource;
            lbdem.Text = dt.Rows.Count.ToString();
        }
    }
}