using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using quanly.lopdulieu;
using quanly.doituong;
using quanlythuvien.Data;

namespace quanly.frm
{
    public partial class FrmTaoMoitk : Form
    {
        public FrmTaoMoitk()
        {
            InitializeComponent();
        }
        DataTable dataTable = new DataTable();
        string[] s = new string[50];
        int i = 0;
        private void FrmTaoMoitk_Load(object sender, EventArgs e)
        {
            try
            {
                Frmmain.tt = true;
                load_dgv();
                load_textbox(Convert.ToInt32(dgvListNV.Rows[0].Cells[0].Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                 
        }
        void load_dgv()
        {
            try
            {
                string query = @"select nv.IDNhanVien as [ID],nv.[TenDangNhap] as [Tên đăng nhập],
                                nv.HoTen as [Họ tên],nv.DiaChi as [Địa chỉ],nv.QuyenHan as [Quyền Hạn]
                                from NhanVien nv";
                DataTable dt = DataProvider.ExecuteQuery(query);
                dgvListNV.DataSource = dt;
                dgvListNV.Refresh();
            }
            catch (Exception)
            {
                throw;
            }

        }
        void load_textbox(int id)
        {
            try
            {
                NhanVien nv = NhanVien.GetNhanVienTheoID(id);
                txtHoTen.Text = nv.HoTen;
                txtDiaChi.Text = nv.DiaChi;
                txtTenDangNhap.Text = nv.TenDangNhap;
                txtIDNhanVien.Text = nv.IDNhanVien.ToString();


                chkAdmin.Checked = nv.QuyenHan.Contains("ADMIN");
                chkQUANLY.Checked = nv.QuyenHan.Contains("QUANLY");
                chkThuKho.Checked = nv.QuyenHan.Contains("THUKHO");
                chkMuonTra.Checked = nv.QuyenHan.Contains("MUONTRA");
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnXoaBo_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có thật sự muốn xoá nhân viên này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(txtIDNhanVien.Text);
                    if (NhanVien.XoaBo(id))
                    {
                        MessageBox.Show("Bạn đã xoá bỏ thành công");
                        load_dgv();
                        load_textbox(Convert.ToInt32(dgvListNV.Rows[0].Cells[0].Value));
                    }
                    else
                    {
                        MessageBox.Show("Quá trình xoá bỏ gặp thất bại bạn hãy kiểm tra lại");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnTaoMoi.Text == "OK")
                {

                    NhanVien nv = new NhanVien();
                    nv.MatKhau = "1";
                    nv.DiaChi = (txtDiaChi.Text);
                    nv.HoTen = (txtHoTen.Text);
                    nv.TenDangNhap = (txtTenDangNhap.Text);
                    List<string> list = new List<string>();
                    if (chkAdmin.Checked) list.Add("ADMIN");
                    if (chkMuonTra.Checked) list.Add("MUONTRA");
                    if (chkQUANLY.Checked) list.Add("QUANLY");
                    if (chkThuKho.Checked) list.Add("THUKHO");
                    string strQuyen = string.Join(",",list.ToArray());
                    nv.QuyenHan = strQuyen;
                    if (NhanVien.TaoMoi(nv))
                    {
                        btnTaoMoi.Text = "Tạo mới";
                        txtDiaChi.ReadOnly = txtHoTen.ReadOnly = txtTenDangNhap.ReadOnly = true;
                        chkAdmin.Enabled = chkMuonTra.Enabled = chkQUANLY.Enabled = chkThuKho.Enabled = false;
                        load_dgv();
                        MessageBox.Show("Thêm mới nhân viên thành công");
                    }
                }
                else
                {
                    btnTaoMoi.Text = "OK";
                    txtDiaChi.ReadOnly = txtHoTen.ReadOnly = txtTenDangNhap.ReadOnly = false;
                    txtDiaChi.Text = "";
                    txtHoTen.Text = "";
                    txtTenDangNhap.Text = "";
                    chkAdmin.Enabled = chkMuonTra.Enabled = chkQUANLY.Enabled = chkThuKho.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FrmTaoMoitk_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }

        private void dgvListNV_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedCellCollection collection = dgvListNV.SelectedCells;
                if (collection.Count > 0)
                {
                    int id = Convert.ToInt32(collection[0].OwningRow.Cells[0].Value);
                    load_textbox(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}