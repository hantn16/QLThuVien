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
        bool tam = true,tam1 = true;
        public FrmdoiMatKhau()
        {
            InitializeComponent();
        }

        private void FrmdoiMatKhau_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btthaydoi_Click(object sender, EventArgs e)
        {
            if (txtMatKhaucu.Text.Trim() != KTdangnhap.strMatKhau.Trim())
            {
                l1.Visible = true;
                tam = false;
               
            }
            else
            {
                l1.Visible = false;
                tam = true;
            }
            if (txtMatKhaumoi.Text != txtnhaplai.Text)
            {
                l2.Visible = true;
                tam1 = false;
            }
            else
            {
                l2.Visible = false;
                tam1 = true;
            }
            if (tam&&tam1) 
            {
                NhanVien nv = new NhanVien(KTdangnhap.idNhanVien,KTdangnhap.strMaNhanVien, KTdangnhap.strHoTen, KTdangnhap.strDiaChi, KTdangnhap.strQuyenHan, KTdangnhap.strnguoidung, KTdangnhap.strMatKhau);
                if (nv.DoiMatKhau(txtMatKhaumoi.Text) == true)
                    MessageBox.Show("Đã hoàn thành việc thay đôi mật khẩu", "Thông báo");
                else
                    MessageBox.Show("Việc thay đổi đã bị lỗi hãy thử lại sau", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Question);
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