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
        DataSet ds;
        CurrencyManager cm;
        private void Frmtkcoban_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimKiem tk = new TimKiem();
            ds = tk.coban(txttimkiem.Text);
            lbdem.Text = ds.Tables[0].Rows.Count.ToString();
            dataGridView1.DataSource = ds.Tables[0];
            cm = BindingContext[this.ds.Tables[0]] as CurrencyManager;
        }

        private void txttimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) button1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Frmcapnhatsach cn = new Frmcapnhatsach();
                Frmcapnhatsach.tb = ds.Tables[0].Rows[cm.Position][0].ToString();
                cn.Show();
            }
            catch { MessageBox.Show("Bạn phải chọn mục để xem thông tin", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Frmtkcoban_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }
    }
}