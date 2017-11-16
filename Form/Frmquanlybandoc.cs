using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using quanly.doituong;
using System.IO;
using quanly.DoiTuong;
using quanlythuvien.DoiTuong;
using quanlythuvien.Data;

namespace quanly.frm
{
    public partial class Frmquanlybandoc : Form
    {
        public Frmquanlybandoc()
        {
            InitializeComponent();
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Frmquanlybandoc_Load(object sender, EventArgs e)
        {
            set_giattri();
        }
        public void set_giattri()
        {
            try
            {
                Load_DataGridView(txtTimKiem.Text);
                DataGridViewCell cell = dgvListDocGia.Rows[0].Cells["ID"];
                dgvListDocGia.CurrentCell = cell;
                load_combobox();
                load_text(Convert.ToInt32(cell.Value));
                Enable_Controls(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Load_DataGridView(string dieukien = "")
        {
            try
            {
                DataTable dt = DocGia.GetDSDocGiaFull(dieukien);
                dgvListDocGia.DataSource = dt;
                dgvListDocGia.Refresh();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void load_combobox()
        {
            try
            {
                DataTable dt = DataProvider.ExecuteQuery("Select IDLop,TenLop from Lop");
                cbLop.DataSource = dt;
                cbLop.ValueMember = "IDLop";
                cbLop.DisplayMember = "TenLop";
            }
            catch (Exception)
            {
                throw;
            }

        }

        void load_text(int i)
        {
            try
            {
                DocGia dg = DocGia.GetDocGiaTheoID(i);
                txtID.Text = i.ToString(); txtMaDocGia.Text = dg.MaDocGia;
                txtHoTen.Text = dg.HoTen;
                txtNgaySinh.Text = dg.NgaySinh.ToString("dd/MM/yyyy");
                txtDiaChi.Text = dg.DiaChi;
                txtDienThoai.Text = dg.DienThoai;
                txtEmail.Text = dg.Email;
                txtNgayLapThe.Text = dg.NgayLapThe.ToString("dd/MM/yyyy");
                chkLock.Checked = dg.Lock;
                Lop lop = Lop.GetLopTheoID(dg.IDLop);
                cbLop.Text = lop.TenLop;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #region Các thủ tục cập nhật , chèn , xoá
        private void btTaoMoi_Click(object sender, EventArgs e)
        {
            if (btnTaoMoi.Text == "OK")
            {
                string query = string.Format("Select * from DocGia where MaDocGia = N'{0}'", txtMaDocGia.Text);
                if (DataProvider.ExecuteQuery(query).Rows.Count > 0)
                {
                    throw new Exception("Mã độc giả đã tồn tại!!!");
                }
                DocGia dg = new DocGia();
                dg.MaDocGia = txtMaDocGia.Text;
                dg.HoTen = txtHoTen.Text;
                dg.NgaySinh = String.IsNullOrEmpty(txtNgaySinh.Text)? DateTime.Now : Convert.ToDateTime(txtNgaySinh.Text);
                dg.IDLop = Convert.ToInt32(cbLop.SelectedValue);
                dg.DiaChi = txtDiaChi.Text;
                dg.DienThoai = txtDienThoai.Text;
                dg.Email = txtEmail.Text;
                dg.NgayLapThe = Convert.ToDateTime(txtNgayLapThe.Text);
                dg.Lock = chkLock.Checked;
                if (DocGia.TaoMoi(dg))
                {
                    
                    btnTaoMoi.Text = "Tạo Mới";
                    btnCapNhat.Enabled = btnXoaBo.Enabled = true;
                    Enable_Controls(false);
                    Load_DataGridView();
                    MessageBox.Show("Thêm mới độc giả thành công!!!");
                }
            }
            else
            {
                Enable_Controls(true);
                txtDiaChi.Text = txtHoTen.Text = txtNgaySinh.Text = txtDienThoai.Text = txtEmail.Text = txtMaDocGia.Text = "";
                txtNgayLapThe.Text = DateTime.Now.ToShortDateString();
                btnTaoMoi.Text = "OK";
                btnCapNhat.Enabled = btnXoaBo.Enabled = false;
                ctCapNhat.Enabled = ctTaoMoi.Enabled = ctXoaBo.Enabled = ctchondoituong.Enabled = false;
            }
        }

        private void Enable_Controls(bool value)
        {
            txtDiaChi.Enabled = txtDienThoai.Enabled = txtEmail.Enabled = txtHoTen.Enabled = txtMaDocGia.Enabled = txtNgayLapThe.Enabled
            = txtNgaySinh.Enabled = cbLop.Enabled = chkLock.Enabled = value;
        }

        private void btXoaBo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xoá độc giả này ra khỏi danh sách không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = int.Parse(txtID.Text);
                if (DocGia.XoaBo(id))
                {
                    set_giattri();
                    MessageBox.Show("Đã xoá thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Xoá thất bại hãy kiểm tra lại thao tác");
                }
            }
        }
        private void btCapNhat_Click(object sender, EventArgs e)
        {
            if (btnCapNhat.Text == "OK")
            {
                DocGia dg = new DocGia();
                dg.IDDocGia = int.Parse(txtID.Text);
                dg.MaDocGia = txtMaDocGia.Text;
                dg.HoTen = txtHoTen.Text;
                dg.NgaySinh = Convert.ToDateTime(txtNgaySinh.Text);
                dg.IDLop = Convert.ToInt32(cbLop.SelectedValue);
                dg.DiaChi = txtDiaChi.Text;
                dg.DienThoai = txtDienThoai.Text;
                dg.Email = txtEmail.Text;
                dg.NgayLapThe = Convert.ToDateTime(txtNgayLapThe.Text);
                dg.Lock = chkLock.Checked;
                if (DocGia.CapNhat(dg))
                {
                    Enable_Controls(false);
                    btnCapNhat.Text = "Cập nhật";
                    btnTaoMoi.Enabled = btnXoaBo.Enabled = true;
                    ctCapNhat.Enabled = ctTaoMoi.Enabled = ctXoaBo.Enabled = ctchondoituong.Enabled = true;
                    MessageBox.Show("Cập nhật thông tin độc giả thành công");
                }
            }
            else
            {
                Enable_Controls(true);
                btnCapNhat.Text = "OK";
                btnTaoMoi.Enabled = btnXoaBo.Enabled = false;
                ctCapNhat.Enabled = ctTaoMoi.Enabled = ctXoaBo.Enabled = ctchondoituong.Enabled = false;
            }
        }
        #endregion
        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (ctchondoituong.Text == "Chọn đối tượng")
            //{
            //    txtMaDocGia.Enabled = true;
            //    ctchondoituong.Text = "Thực hiện";
            //    btnCapNhat.Enabled = btnXoaBo.Enabled = btnTaoMoi.Enabled = false;
            //    ctCapNhat.Enabled = ctTaoMoi.Enabled = ctXoaBo.Enabled = false;
            //}
            //else
            //{
            //    txtMaDocGia.Enabled = false;
            //    ctchondoituong.Text = "Chọn đối tượng";
            //    btnCapNhat.Enabled = btnXoaBo.Enabled = btnTaoMoi.Enabled = true;
            //    ctCapNhat.Enabled = ctTaoMoi.Enabled = ctXoaBo.Enabled = true;
            //    DataView dv = new DataView();
            //    dv.Table = ds.Tables[1];
            //    dv.RowFilter = "MaDocGia='" + txtMaDocGia.Text + "'";
            //    if (dv.Count == 0) MessageBox.Show("Bạn hãy kiểm tra lại mã vừa nhập", "Thông báo");
            //    else
            //    {
            //        txtDiaChi.Text = dv[0]["DiaChi"].ToString();
            //        txtHoTen.Text = dv[0]["HoTen"].ToString();
            //        txtMaDocGia.Text = dv[0]["MaDocGia"].ToString();
            //        txtNgayLapThe.Text = DateTime.Parse(dv[0]["NgayLapThe"].ToString()).ToShortDateString();
            //        txtNgaySinh.Text = DateTime.Parse(dv[0]["NgaySinh"].ToString()).ToShortDateString();
            //        txtDienThoai.Text = dv[0]["ViTri"].ToString();
            //    }
            //}
        }
        string taoma(string ma)
        {
            string s = ma.Substring(2, ma.Length - 2);
            int i = int.Parse(s);
            i++;
            if (i < 10) return "DG0000" + Convert.ToString(i);
            else
                if (i < 100) return "DG000" + Convert.ToString(i);
            else
                    if (i < 1000) return "DG00" + Convert.ToString(i);
            else
                        if (i < 10000) return "DG0" + Convert.ToString(i);
            else return "DG" + Convert.ToString(i);

        }

        private void Frmquanlybandoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            try
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.WriteLine("==========Thông tin của độc giả thư viện===========");
                sw.WriteLine("--------------------------------------------------");
                sw.WriteLine("| Mã độc giả  :        " + txtMaDocGia.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Họ tên      :        " + txtHoTen.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Địa chỉ     :        " + txtDiaChi.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Ngày sinh   :        " + txtNgaySinh.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Ngày lập thẻ:        " + txtNgayLapThe.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Tên khoa    :        " + cbLop.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Vị trí      :        " + txtDienThoai.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.Close();
            }
            catch { };
        }

        private void txtMaDocGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) hToolStripMenuItem_Click(sender, e);
        }

        private void dgvListDocGia_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvListDocGia.SelectedCells.Count>0)
                {
                    int id = Convert.ToInt32(dgvListDocGia.SelectedCells[0].OwningRow.Cells["ID"].Value);
                    if (id > 0)
                    {
                        load_text(id);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                Load_DataGridView(txtTimKiem.Text);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}