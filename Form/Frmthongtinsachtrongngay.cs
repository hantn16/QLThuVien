using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using System.Data.SqlClient;

namespace quanly.frm
{
    public partial class Frmthongtinsachtrongngay : Form
    {
        public Frmthongtinsachtrongngay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        SqlDataReader dr;
        private void Frmthongtinsachtrongngay_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;    
            laydulieu dl = new laydulieu();
                dr = dl.lay_reader("select phieumuon.MaTaiLieu,NhanDe,TenTacGia,phieumuon.MaDocGia,phieumuon.SoLuong from phieumuon,sach,TacGia where phieumuon.MaTaiLieu = sach.MaTaiLieu and sach.MaTacGia = TacGia.MaTacGia and phieumuon.TheThucmuon like N'%" + "Mượn về nhà" + "%' and ngaymuon ='" + DateTime.Now.ToShortDateString() + "'");
                int i = 0;
                while (dr.Read())
                {
                    listView1.Items.Add(dr[0].ToString());
                    listView1.Items[i].SubItems.Add(dr[1].ToString());
                    listView1.Items[i].SubItems.Add(dr[2].ToString());
                    listView1.Items[i].SubItems.Add(dr[3].ToString());
                    listView1.Items[i].SubItems.Add(dr[4].ToString());
                    i++;
                }
                L_Ketnoi.HuyKetNoi();
                L_Ketnoi.ThietlapketNoi();
                dr = dl.lay_reader("select phieumuon.MaTaiLieu,NhanDe,TenTacGia,phieumuon.MaDocGia,phieumuon.SoLuong from phieumuon,sach,TacGia where phieumuon.MaTaiLieu = sach.MaTaiLieu and sach.MaTacGia = TacGia.MaTacGia and phieumuon.TheThucmuon like N'%" + "Mượn tại chỗ" + "%' and ngaymuon ='" + DateTime.Now.ToShortDateString() + "'");
                i = 0;
                while (dr.Read())
                {
                    listView2.Items.Add(dr[0].ToString());
                    listView2.Items[i].SubItems.Add(dr[1].ToString());
                    listView2.Items[i].SubItems.Add(dr[2].ToString());
                    listView2.Items[i].SubItems.Add(dr[3].ToString());
                    listView2.Items[i].SubItems.Add(dr[4].ToString());
                    i++;
                }
                L_Ketnoi.HuyKetNoi();
                L_Ketnoi.ThietlapketNoi();
                dr = dl.lay_reader("select phieumuon.MaTaiLieu,NhanDe,TenTacGia,phieumuon.MaDocGia,phieumuon.SoLuong from phieumuon,sach,TacGia where phieumuon.MaTaiLieu = sach.MaTaiLieu and sach.MaTacGia = TacGia.MaTacGia and phieumuon.TheThucmuon like N'%" + "Mượn giáo trình" + "%' and ngaymuon ='" + DateTime.Now.ToShortDateString() + "'");
                i = 0;
                while (dr.Read())
                {
                    listView3.Items.Add(dr[0].ToString());
                    listView3.Items[i].SubItems.Add(dr[1].ToString());
                    listView3.Items[i].SubItems.Add(dr[2].ToString());
                    listView3.Items[i].SubItems.Add(dr[3].ToString());
                    listView3.Items[i].SubItems.Add(dr[4].ToString());
                    i++;
                }
                L_Ketnoi.HuyKetNoi();
                L_Ketnoi.ThietlapketNoi();
                dr = dl.lay_reader("select phieumuon.MaTaiLieu,phieumuon.MaDocGia from phieumuon,sachmuon where phieumuon.maphieumuon = sachmuon.maphieumuon and phieumuon.TheThucmuon like N'%" + "Mượn tại chỗ" + "%' and ngaymuon ='" + DateTime.Now.ToShortDateString() + "'");
                i = 0;
                while (dr.Read())
                {
                    listView4.Items.Add(dr[0].ToString());
                    listView4.Items[i].SubItems.Add(dr[1].ToString());
                    i++;
                }
                L_Ketnoi.HuyKetNoi();
            }

        private void Frmthongtinsachtrongngay_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }
        }
    }
