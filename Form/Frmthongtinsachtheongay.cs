using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using quanly.lopdulieu;

namespace quanly.frm
{
    public partial class Frmthongtinsachtheongay : Form
    {
        public Frmthongtinsachtheongay()
        {
            InitializeComponent();
        }

        private void Frmthongtinsachtheongay_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        SqlDataReader dr;
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {

            DateTime dau = monthCalendar1.SelectionStart;
            DateTime cuoi = monthCalendar1.SelectionEnd;
            listView1.Items.Clear();
            while (dau <= cuoi)
            {
                laydulieu dl = new laydulieu();
                dr = dl.lay_reader("select phieumuon.MaTaiLieu,NhanDe,TenTacGia,TheThucmuon,phieumuon.MaDocGia,phieumuon.SoLuong from phieumuon,sach,TacGia where phieumuon.MaTaiLieu = sach.MaTaiLieu and sach.MaTacGia = TacGia.MaTacGia and phieumuon.TheThucmuon like N'%" + comboBox1.Text + "%' and ngaymuon ='" + dau.ToShortDateString() + "'");
                int i = 0;
                while (dr.Read())
                {
                    listView1.Items.Add(dr[0].ToString());
                    listView1.Items[i].SubItems.Add(dr[1].ToString());
                    listView1.Items[i].SubItems.Add(dr[2].ToString());
                    listView1.Items[i].SubItems.Add(dr[3].ToString());
                    listView1.Items[i].SubItems.Add(dr[4].ToString());
                    listView1.Items[i].SubItems.Add(dr[5].ToString());
                    i++;
                }
                L_Ketnoi.HuyKetNoi();
                dau = dau.AddDays(1);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }



        private void Frmthongtinsachtheongay_Load_1(object sender, EventArgs e)
        {

        }

       
        private void Frmthongtinsachtheongay_Load_2(object sender, EventArgs e)
        {

        }

        private void Frmthongtinsachtheongay_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }
    }
}