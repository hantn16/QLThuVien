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
    public partial class FrmdoiMatKhau : Form
    {
        public FrmdoiMatKhau()
        {
            InitializeComponent();
        }

        private void FrmdoiMatKhau_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btthaydoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMatKhaucu.Text.Trim() != DangNhap.strMatKhau.Trim()) throw new Exception("Mật khẩu hiện tại không đúng!!!");

                if (txtMatKhaumoi.Text != txtnhaplai.Text) throw new Exception("Mật khẩu nhập lại không khớp với mật khẩu mới");

                if (NhanVien.DoiMatKhau(DangNhap.idNhanVien, txtMatKhaumoi.Text) == true)
                {
                    MessageBox.Show("Đã hoàn thành việc thay đôi mật khẩu", "Thông báo");
                    btnThoat_Click(this, e);
                }
                
                else
                    MessageBox.Show("Việc thay đổi đã bị lỗi hãy thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void txtnhaplai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) btthaydoi_Click(sender, e);
        }

        private void FrmdoiMatKhau_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }
    }
}