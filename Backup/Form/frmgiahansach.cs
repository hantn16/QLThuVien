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
        public frmgiahansach()
        {
            InitializeComponent();
        }
        string maphieumuon = "";
        private void btkiemtratt_Click(object sender, EventArgs e)
        {
            laydulieu dl = new laydulieu();
            bool tam = false;
            SqlDataReader dr = dl.lay_reader("select * from phieumuon where phieumuon.masach='" + txtmasach.Text + "' and phieumuon.madocgia='" + txtmadocgia.Text + "' and phieumuon.thethucmuon=N'Mượn về nhà'");
            while (dr.Read())
            {
                txtngaymuon.Text = dr["ngaymuon"].ToString();
                maphieumuon = dr["maphieumuon"].ToString();
                tam = true;
            }
            L_Ketnoi.HuyKetNoi();
            btgiahan.Enabled = tam;
            if (tam)
            {
                txtmasach.Enabled = false;
                txtmadocgia.Enabled = false;
                btkiemtratt.Enabled = false;
                btgiahan.Enabled = true;
            }
            else
            {
                txtmasach.Enabled = true;
                txtmadocgia.Enabled = true;
                btkiemtratt.Enabled = true;
                btgiahan.Enabled = false;
            }
        }

        private void bthuythaotac_Click(object sender, EventArgs e)
        {
            txtmasach.Enabled = true;
            txtmadocgia.Enabled = true;
            btkiemtratt.Enabled = true;
            btgiahan.Enabled = false;
            txtngaymuon.Text = "";
            txtmadocgia.Text = "";
            txtmasach.Text = "";
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btgiahan_Click(object sender, EventArgs e)
        {
            laydulieu dl = new laydulieu();
            DataSet d = dl.getdata("select * from phieumuon where maphieumuon='" + maphieumuon + "' and GETdate()- phieumuon.ngaymuon > day(7)");
            if (d.Tables[0].Rows.Count > 0)
                MessageBox.Show("Sách này đã quá hạn không thể thực hiện thao tác xin gia hạn được");
            else
            {
                if (txtngaymuon.Text != "")
                {
                    Lphieumuon pm = new Lphieumuon();
                    pm.set_maphieumuon(maphieumuon);
                    pm.set_ngaymuon(DateTime.Parse(DateTime.Now.ToShortDateString()));
                    if (pm.giahan())
                    {
                        bthuythaotac_Click(sender, e);
                        btgiahan.Enabled = false;
                        btkiemtratt.Enabled = true;
                        MessageBox.Show("Bạn đã thực hiện thành công thao tác");
                    }
                    else MessageBox.Show("Thao tác gặp lỗi");

                }
                else MessageBox.Show("Bạn phải kiểm tra thông tin trước khi thực hiện thao tác này");
            }
        }

        private void txtmasach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) btkiemtratt_Click(sender, e);
        }

        private void frmgiahansach_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
        }

        private void frmgiahansach_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }

        private void txtmasach_TextChanged(object sender, EventArgs e)
        {

        }
    }
}