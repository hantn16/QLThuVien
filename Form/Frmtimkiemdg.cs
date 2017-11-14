using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using System.Data.SqlClient;
using quanly.frm;
namespace quanly.frm
{
    public partial class Frmtimkiemdg : Form
    {
        public Frmtimkiemdg()
        {
            InitializeComponent();
        }

        private void Frmtimkiemdg_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Frmtimkiemdg_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }

        private void bttaothe_Click(object sender, EventArgs e)
        {
            //laydulieu dl = new laydulieu();
            //SqlDataReader dr = dl.lay_reader("select DocGia.MaDocGia,DocGia.HoTen,DocGia.DiaChi,DocGia.NgaySinh,khoa.tenkhoa,DocGia.ViTri,DocGia.NgayLapThe from DocGia,khoa where DocGia.MaKhoa = khoa.MaKhoa and ((DocGia.HoTen like N'%" + txttimkiem.Text + "%')or (DocGia.DiaChi like N'%" + txttimkiem.Text + "%') or (DocGia.MaDocGia = N'" + txttimkiem.Text + "') or (khoa.tenkhoa like N'%" + txttimkiem.Text + "%'))");
            //frmtaothe fdg = new frmtaothe();
            //fdg.set_dr(dr);
            //fdg.Show();
        }


    }
}