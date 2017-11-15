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
        private void Frmthongtincanhan_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
            txtIDNhanVien.Text = DangNhap.idNhanVien.ToString();
            txtTenDangNhap.Text = DangNhap.strnguoidung;
            txtHoTen.Text = DangNhap.strHoTen;
            txtDiaChi.Text = DangNhap.strDiaChi;

            if (DangNhap.strQuyenHan.Contains("ADMIN")) chkAdmin.Checked = true;
            if (DangNhap.strQuyenHan.Contains("QUANLY")) chkQuanLy.Checked = true;
            if (DangNhap.strQuyenHan.Contains("MUONTRA")) chkMuonTra.Checked = true;
            if (DangNhap.strQuyenHan.Contains("THUKHO")) chkThuKho.Checked = true;

        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {

            try
            {
                if (btnThongTin.Text != "OK")
                {
                    txtDiaChi.ReadOnly = txtHoTen.ReadOnly = txtTenDangNhap.ReadOnly = false;
                    btnThongTin.Text = "OK";
                }
                else
                {
                    List<String> list = new List<string>();
                    if (chkAdmin.Checked) list.Add(chkAdmin.Text);
                    if (chkMuonTra.Checked) list.Add(chkMuonTra.Text);
                    if (chkQuanLy.Checked) list.Add(chkQuanLy.Text);
                    if (chkThuKho.Checked) list.Add(chkThuKho.Text);
                    string strQuyen = String.Join(",", list.ToArray());

                    NhanVien nv = new NhanVien(DangNhap.idNhanVien, txtHoTen.Text, txtDiaChi.Text, strQuyen, txtTenDangNhap.Text, DangNhap.strMatKhau);
                    if (NhanVien.CapNhat(nv) == true)
                    {
                        DangNhap.strDiaChi = txtDiaChi.Text;
                        DangNhap.strHoTen = txtHoTen.Text;
                        DangNhap.strnguoidung = txtTenDangNhap.Text;
                        DangNhap.strQuyenHan = strQuyen;
                        txtDiaChi.ReadOnly = txtHoTen.ReadOnly = txtTenDangNhap.ReadOnly = true;
                        chkThuKho.Enabled = chkQuanLy.Enabled = chkMuonTra.Enabled = chkAdmin.Enabled = false;
                        btnThongTin.Text = "Thay đổi thông tin";
                        MessageBox.Show("Đã cập nhật thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại bạn hãy thử lại", "Thông báo");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                FrmdoiMatKhau mk = new FrmdoiMatKhau();
                mk.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Frmthongtincanhan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }
    }
}