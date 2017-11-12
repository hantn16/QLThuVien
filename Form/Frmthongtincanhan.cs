using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using quanly.doituong;

namespace quanly.frm
{
    public partial class Frmthongtincanhan : Form
    {
        public Frmthongtincanhan()
        {
            InitializeComponent();
        }
        bool tam = false;
        private void Frmthongtincanhan_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
            txtMaNhanVien.Text = KTdangnhap.strMaNhanVien;
            txtQuyenHan.Text = KTdangnhap.strQuyenHan;
            txtTenDangNhap.Text = KTdangnhap.strnguoidung;
            txtHoTen.Text = KTdangnhap.strHoTen;
            txtDiaChi.Text = KTdangnhap.strDiaChi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tam == false)
            {
                txtDiaChi.Enabled = txtHoTen.Enabled = txtTenDangNhap.Enabled = true;
                tam = true;
                btthongtin.Text = "OK";
            }
            else
            {
                KTdangnhap.strDiaChi=txtDiaChi.Text;
                KTdangnhap.strHoTen=txtHoTen.Text;
                KTdangnhap.strnguoidung=txtTenDangNhap.Text;
                NhanVien nv = new NhanVien(KTdangnhap.idNhanVien,KTdangnhap.strMaNhanVien, KTdangnhap.strHoTen, KTdangnhap.strDiaChi, KTdangnhap.strQuyenHan, KTdangnhap.strnguoidung, KTdangnhap.strMatKhau);
                if (nv.CapNhat() == true)
                {
                    txtDiaChi.Enabled = txtHoTen.Enabled = txtTenDangNhap.Enabled = false;
                    tam = false;
                    btthongtin.Text = "Thay đổi thông tin";
                    MessageBox.Show("Đã cập nhật thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại bạn hãy thử lại", "Thông báo");
                }

            }
        }

        private void btMatKhau_Click(object sender, EventArgs e)
        {
            FrmdoiMatKhau mk = new FrmdoiMatKhau();
            mk.Show();
        }

        private void THo(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Frmthongtincanhan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }

      
    }
}