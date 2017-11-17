using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using System.Data.SqlClient;
using quanlythuvien.Data;
using quanlythuvien.DoiTuong;

namespace quanly.frm
{
    public partial class frmQuanLyLop : Form
    {
        public frmQuanLyLop()
        {
            InitializeComponent();
        }
        BindingSource DSLop = new BindingSource();
        private void frmQuanLyLop_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
            try
            {
                this.txtMa.ReadOnly = true;
                this.txtTen.ReadOnly = true;
                this.cbKhoa.Enabled = false;
                Load_Combobox();

                LoadDSLop();
                this.dghienthi.DataSource = DSLop;
                AddBindingData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Load_Combobox()
        {
            try
            {
                cbKhoa.DataSource = Khoa.GetDSKhoa();
                cbKhoa.DisplayMember = "TenKhoa";
                cbKhoa.ValueMember = "IDKhoa";
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Hàm load lại dữ liệu cho DSLop
        /// </summary>
        private void LoadDSLop(string strTimKiem = "")
        {
            try
            {
                string queryAdd = string.Format(" where l.IDLop like N'%{0}%' or l.TenLop like N'%{0}%' or k.TenKhoa like N'%{0}%'", strTimKiem);
                string query = " select l.IDLop as 'ID',l.TenLop as 'Tên lớp',l.IDKhoa as 'IDKhoa',k.TenKhoa as 'Khoa' from Lop l inner join Khoa k on l.IDKhoa = k.IDKhoa";
                if (!String.IsNullOrEmpty(strTimKiem)) query += queryAdd;
                DataTable dt = DataProvider.ExecuteQuery(query);
                DSLop.DataSource = dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Hàm binding dữ liệu giữa datagridview và các textbox
        /// </summary>
        private void AddBindingData()
        {
            try
            {
                //Xóa các bindings đã thêm trước đây vào textbox để đảm bảo mỗi textbox chỉ có 1 bindings
                txtMa.DataBindings.Clear();
                txtTen.DataBindings.Clear();

                //Add binding vào cho các textbox
                txtMa.DataBindings.Add(new Binding("Text", dghienthi.DataSource, "ID",true,DataSourceUpdateMode.Never));               
                txtTen.DataBindings.Add(new Binding("Text", dghienthi.DataSource, "Tên lớp", true,DataSourceUpdateMode.Never));
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void CapNhat()
        {
            if (MessageBox.Show("Bạn có muốn cập nhật dữ liệu", "Thông báo", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                try
                {
                    //cb = new SqlCommandBuilder(da);
                    //da.Update(ds, BangKetNoi);
                }
                catch { MessageBox.Show("hay kiem tra lai tinh dung dan cua du lieu"); }
            }
        }
        private void btCapNhat_Click(object sender, EventArgs e)
        {
            this.CapNhat();
        }
        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban that su muon xoa ?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    MessageBox.Show("Ban da xoa thanh cong");
                }
                catch { MessageBox.Show("hay kiem tra lai tinh dung dan cua du lieu"); }

            }
        }

        private void btTaoMoi_Click(object sender, EventArgs e)
        {

        }

        private void frmQuanLyLop_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnThem.Text == "OK")
                {
                    Lop lop = new Lop();
                    lop.TenLop = txtTen.Text;
                    lop.IDKhoa = (int)cbKhoa.SelectedValue;
                    if (Lop.ThemMoi(lop))
                    {
                        MessageBox.Show("Thêm mới thành công!!!");
                        LoadDSLop();
                        dghienthi.Refresh();
                        btnThem.Text = "Thêm";
                            txtTen.ReadOnly = true;
                        btnSua.Enabled = btnXoa.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại!!!");
                    }                
                }
                else
                {
                     txtTen.ReadOnly = false;cbKhoa.Enabled = true;
                    txtTen.Text = "";

                    btnThem.Text = "OK";
                    btnSua.Enabled = btnXoa.Enabled = false;
                    txtTen.Focus();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSua.Text == "Sửa")
                {
                    txtTen.ReadOnly = false;cbKhoa.Enabled = true;
                    txtTen.Focus();
                    btnSua.Text = "Lưu";
                    btnThem.Enabled = btnXoa.Enabled = false;
                }
                else
                {
                    Lop lop = new Lop();
                    lop.IDLop = Int32.Parse(txtMa.Text);
                    lop.IDKhoa = (int)cbKhoa.SelectedValue;
                    lop.TenLop = txtTen.Text;
                    if (Lop.CapNhat(lop))
                    {
                        MessageBox.Show("Sửa thành công!!!");
                        LoadDSLop();
                        dghienthi.Refresh();
                        btnSua.Text = "Sửa";
                        btnThem.Enabled = btnXoa.Enabled = true;
                        txtTen.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại!!!");
                        txtTen.Focus();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi!!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn thực sự muốn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idKhoa = Int32.Parse(txtMa.Text);
                    if (Lop.XoaBo(idKhoa))
                    {
                        MessageBox.Show("Xóa thành công!!!");
                        LoadDSLop(); dghienthi.Refresh();
                    }
                    else
                    {
                        throw new Exception("Lỗi trong quá trình xóa");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDSLop(txtTimKiem.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnTimKiem_KeyDown(sender, e); }
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int idKhoa = (int)dghienthi.SelectedCells[0].OwningRow.Cells["IDKhoa"].Value;
                Khoa khoa = Khoa.GetKhoaTheoID(idKhoa);
                int index = -1; int i = 0;
                foreach (Khoa item in cbKhoa.Items)
                {
                    if (item.IDKhoa == idKhoa) index = i;
                    i++;
                }
                cbKhoa.SelectedIndex = index;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}