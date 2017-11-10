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

namespace quanly.frm
{
    public partial class Formhienthi : Form
    {
        private DataTable dataTable = new DataTable();
        private CurrencyManager bmb = null;
        public string ChuoiKetNoi { get; set; }
        public string BangKetNoi { get; set; }
        public string TenCotMa { get; set; }
        public string TenCotTen { get; set; }
        public string ActiveTab { get; set; }
        public enum FormStatusOption
        {
            VuaTao,
            DangSua

        }
        public FormStatusOption FormStatus { get; set; }
        public BindingSource bindingSource = new BindingSource();

        public Formhienthi()
        {
            InitializeComponent();
            this.FormStatus = FormStatusOption.VuaTao;

        }

        private void Formhienthi_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
            try
            {
                this.lbMa.Text = TenCotMa;
                this.lbTen.Text = TenCotTen;
                this.txtMa.ReadOnly = true;
                this.txtTen.ReadOnly = true;
                LoadDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        /// <summary>
        /// Hàm load lại dữ liệu cho DataGridView
        /// </summary>
        private void LoadDataGridView()
        {
            dataTable = DataProvider.ExecuteQuery(ChuoiKetNoi);
            this.dghienthi.DataSource = dataTable;
            dghienthi.Refresh();
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
                txtMa.DataBindings.Add(new Binding("Text", dghienthi.DataSource, this.TenCotMa));               
                txtTen.DataBindings.Add(new Binding("Text", dghienthi.DataSource, this.TenCotTen));
            }
            catch (Exception)
            {
                throw;
            }

        }

        //------Bat su kien nhan enter trong textbox tim kiem
        private void tbtimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { bttimkiem_Click(sender, e); }
        }

        private void bttimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string query = String.Format("{0} where (Ma{2} like '%{1}%' or Ten{2} like N'%{1}%') ", ChuoiKetNoi, txtTimKiem.Text, BangKetNoi);
                DataTable dt = DataProvider.ExecuteQuery(query);
                this.dghienthi.DataSource = dt;
                this.dghienthi.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    bmb.RemoveAt(bmb.Position);
                    //SqlDataAdapter da = new SqlDataAdapter();
                    //SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    //da.Update(dataTable, BangKetNoi);
                    //da.Update()
                    MessageBox.Show("Ban da xoa thanh cong");
                }
                catch { MessageBox.Show("hay kiem tra lai tinh dung dan cua du lieu"); }

            }
        }

        private void Formhienthi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataTable.GetChanges() != null)
            {
                if (MessageBox.Show("Đã có sự thay đổi dữ liệu bạn có muốn lưu lại hay không ?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.CapNhat();
            }
            L_Ketnoi.HuyKetNoi();
        }

        private void dghienthi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46) btxoa_Click(sender, e);
        }

        private void btTaoMoi_Click(object sender, EventArgs e)
        {

        }
        string TaoMaMacDinh(string ma)
        {
            string tam = ma.Substring(0, 2);
            int i = 0;
            if (int.TryParse(ma.Substring(2, ma.Length - 2),out i))
            {
                i++;
                return tam + i.ToString("000");
            }
            else
            {
                return ma + "1";
            }                       
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataTable.GetChanges() != null) this.CapNhat();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Formhienthi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
            Frmmain.hf.set_text(Frmhelpfast.t);
            Frmmain.hf.set_anh(1);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = DataProvider.ExecuteQuery("select * from " + BangKetNoi);
                string strmacuoi = dt.Rows[dt.Rows.Count - 1][0].ToString();
                if (btnThem.Text == "OK")
                {
                    //Kiểm tra mã tồn tại chưa
                    string queryCheck = string.Format("Select * from {0} where Ma{0} = N'{1}'",BangKetNoi,txtMa.Text);
                    if (DataProvider.ExecuteQuery(queryCheck).Rows.Count>0)
                    {
                        txtMa.Focus();
                        throw new Exception("Mã đã tồn tại. Thêm mới không thành công!!!");
                    }
                    //Thêm vào database
                    string addQuery = string.Format("Insert into {0} (Ma{0},Ten{0}) values (N'{1}',N'{2}')",BangKetNoi,txtMa.Text,txtTen.Text);
                    if (DataProvider.ExecuteNonQuery(addQuery)>0)
                    {
                        MessageBox.Show("Thêm mới thành công!!!");
                        LoadDataGridView();
                        btnThem.Text = "Thêm";
                        txtMa.ReadOnly = txtTen.ReadOnly = true;
                        btnSua.Enabled = btnXoa.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại!!!");
                    }                
                }
                else
                {
                    txtMa.ReadOnly = txtTen.ReadOnly = false;
                    string maMacDinh = TaoMaMacDinh(strmacuoi);
                    txtMa.Text = maMacDinh;
                    txtTen.Text = "";
                    btnThem.Text = "OK";
                    btnSua.Enabled = btnXoa.Enabled = false;
                    txtMa.Focus();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dghienthi_DataSourceChanged(object sender, EventArgs e)
        {
            //Mỗi lần thay đổi datasource của gridview là kích hoạt sự kiện này
            try
            {
                AddBindingData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSua.Text == "Sửa")
                {
                    txtTen.ReadOnly = false;
                    btnSua.Text = "Lưu";
                    btnThem.Enabled = btnXoa.Enabled = false;
                }
                else
                {
                    string updateQuery = string.Format("Update {0} set Ten{0} = N'{2}' where Ma{0} = N'{1}'", BangKetNoi, txtMa.Text, txtTen.Text);
                    if (DataProvider.ExecuteNonQuery(updateQuery) > 0)
                    {
                        MessageBox.Show("Sửa thành công!!!");
                        LoadDataGridView();
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
                    string delQuery = string.Format("Delete from {0} where Ma{0} = N'{1}'", BangKetNoi, txtMa.Text);
                    if (DataProvider.ExecuteNonQuery(delQuery)>0)
                    {
                        MessageBox.Show("Xóa thành công!!!");
                        LoadDataGridView();
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
    }
}