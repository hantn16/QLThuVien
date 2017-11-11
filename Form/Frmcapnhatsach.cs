using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using quanly.doituong;
using System.Data.SqlClient;
using QLTV.GUI.DoiTuong;
using quanly.DoiTuong;
using quanlythuvien.Data;
using quanlythuvien.DoiTuong;

namespace quanly.frm
{
    public partial class FrmCapNhatsach : Form
    {
        public FrmCapNhatsach()
        {
            InitializeComponent();
        }
        public static int tb = 0;
        public int ht = 0;
        private void FrmCapNhatsach_Load(object sender, EventArgs e)
        {
            try
            {
                //Kiểm tra quyền
                if ((KTdangnhap.strQuyenHan.Trim() == "ADMIN") || KTdangnhap.strQuyenHan.IndexOf("THUKHO") >= 0)
                {
                    btCapNhat.Enabled = btxoa.Enabled = btnThemMoi.Enabled = true;
                    ctmnEdit.Enabled = true;
                }
                else
                {
                    btCapNhat.Enabled = btxoa.Enabled = btnThemMoi.Enabled = false;
                    ctmnEdit.Enabled = false;
                }

                Frmmain.tt = true;
                Load_combobox(); //gọi thủ tục Load_combobox
                Load_treeview(); //gọi thủ tục Load_treeview
                if (tb == 0)
                {
                    int idTaiLieu = (int)trvListTaiLieu.Nodes[0].Tag;
                    Load_textbox(idTaiLieu);
                }
                else Load_textbox(tb);
                if (ht == 1) btnThemMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        void Load_textbox(int id)
        {
            DataTable dt = DataProvider.ExecuteQuery(string.Format("EXEC GetFullTaiLieuByID {0}", id));
            DataRow dr = dt.Rows[0];
            txtMaTL.Tag = id;
            txtMaTL.Text = dr["MaTaiLieu"].ToString();
            txtnamxuatban.Text = dr["NamXuatBan"].ToString();
            txtNhanDe.Text = dr["NhanDe"].ToString();
            txtSoLanMuon.Text = dr["SoLanMuon"].ToString();
            txtSoLuong.Text = dr["SoLuong"].ToString();
            txtSoTrang.Text = dr["SoTrang"].ToString();
            cbGiaXep.Text = dr["MaGiaXep"].ToString();
            txtlanxuatban.Text = dr["LanXuatBan"].ToString();
            cbloaisach.Text = dr["TenTheLoai"].ToString();
            cbNgonNgu.Text = dr["TenNgonNgu"].ToString();
            cbNhaXuatBan.Text = dr["TenNhaXuatBan"].ToString();
            cbTacGia.Text = dr["TenTacGia"].ToString();
            txtNgayNhap.Text = DateTime.Parse(dr["NgayNhap"].ToString()).ToShortDateString();
            cbTheThuc.Text = dr["TheThuc"].ToString();
        }
        #region Trình bày giao diện
        void Load_combobox()
        {
            //DataTable dtTheLoai = DataProvider.ExecuteQuery("select * from TheLoai");
            cbloaisach.DataSource = TheLoai.GetDanhSachTheLoai();
            cbloaisach.ValueMember = "MaTheLoai";
            cbloaisach.DisplayMember = "TenTheLoai";

            DataTable dtNgonNgu = DataProvider.ExecuteQuery("select * from NgonNgu");
            cbNgonNgu.DataSource = dtNgonNgu;
            cbNgonNgu.ValueMember = "MaNgonNgu";
            cbNgonNgu.DisplayMember = "TenNgonNgu";

            DataTable dtTacGia = DataProvider.ExecuteQuery("select * from TacGia");
            cbTacGia.DataSource = dtTacGia;
            cbTacGia.ValueMember = "MaTacGia";
            cbTacGia.DisplayMember = "TenTacGia";

            DataTable dtNhaXuatBan = DataProvider.ExecuteQuery("select * from NhaXuatBan");
            cbNhaXuatBan.DataSource = dtNhaXuatBan;
            cbNhaXuatBan.ValueMember = "MaNhaXuatBan";
            cbNhaXuatBan.DisplayMember = "TenNhaXuatBan";

            cbGiaXep.DataSource = GiaXep.GetDSGiaXep();
            cbGiaXep.ValueMember = "IDGiaXep";
            cbGiaXep.DisplayMember = "MaGiaXep";

        }
        void Load_treeview()
        {
            trvListTaiLieu.Nodes.Clear();
            DataTable dtTaiLieu = DataProvider.ExecuteQuery("select IDTaiLieu, NhanDe from TaiLieu");
            if (dtTaiLieu.Rows.Count > 0)
            {
                foreach (DataRow dr in dtTaiLieu.Rows)
                {
                    TreeNode n = new TreeNode();
                    n.Tag = Convert.ToInt32(dr["IDTaiLieu"].ToString());
                    n.Text = dr["NhanDe"].ToString();
                    n.ImageIndex = 0;
                    trvListTaiLieu.Nodes.Add(n);
                }
            }

        }
        void Binding()
        {

        }
        private void trvListTaiLieu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int selectedItemIndex = (int)trvListTaiLieu.SelectedNode.Tag;
            Load_textbox(selectedItemIndex);
        }
        void set_enable(bool tam)
        {
            txtMaTL.Enabled = tam;
            txtlanxuatban.Enabled = tam;
            txtnamxuatban.Enabled = tam;
            txtNgayNhap.Enabled = tam;
            txtNhanDe.Enabled = tam;
            txtSoTrang.Enabled = tam;
            txtSoLuong.Enabled = tam;

            cbloaisach.Enabled = tam;
            cbNgonNgu.Enabled = tam;
            cbNhaXuatBan.Enabled = tam;
            cbTacGia.Enabled = tam;
            cbTheThuc.Enabled = tam;
            cbGiaXep.Enabled = tam;

        }
        #endregion
        #region Sinh mã tự động
        string MaViTri()
        {
            laydulieu dl = new laydulieu();
            string tam = "";
            int i = 0;
            SqlDataReader dr = dl.lay_reader("select MaViTri from ViTriluutru");
            while (dr.Read())
                tam = dr[0].ToString();
            L_Ketnoi.HuyKetNoi();
            i = int.Parse(tam.Substring(2, tam.Length - 2));
            i++;
            if (i < 10) return "VT0000" + i.ToString();
            else
                if (i < 100) return "VT000" + i.ToString();
            else
                    if (i < 1000) return "VT00" + i.ToString();
            else
                        if (i < 10000) return "VT0" + i.ToString();
            else return "VT" + i.ToString();
        }
        string MaTheLoai()
        {
            laydulieu dl = new laydulieu();
            string tam = "";
            int i = 0;
            SqlDataReader dr = dl.lay_reader("select MaTheLoai from TheLoai");
            while (dr.Read())
                tam = dr[0].ToString();
            L_Ketnoi.HuyKetNoi();
            i = int.Parse(tam.Substring(2, tam.Length - 2));
            i++;
            if (i < 10) return "PL00" + i.ToString();
            else
                if (i < 100) return "PL0" + i.ToString();
            else return "PL" + i.ToString();

        }
        string MaTacGia()
        {
            laydulieu dl = new laydulieu();
            string tam = "";
            int i = 0;
            SqlDataReader dr = dl.lay_reader("select MaTacGia from TacGia");
            while (dr.Read())
                tam = dr[0].ToString();
            L_Ketnoi.HuyKetNoi();
            i = int.Parse(tam.Substring(2, tam.Length - 2));
            i++;
            if (i < 10) return "TG00" + i.ToString();
            else
                if (i < 100) return "TG0" + i.ToString();
            else
                return "TG" + i.ToString();
        }
        string maNhaXuatBan()
        {
            laydulieu dl = new laydulieu();
            string tam = "";
            int i = 0;
            SqlDataReader dr = dl.lay_reader("select MaNXB from NhaXuatBan");
            while (dr.Read())
                tam = dr[0].ToString();
            L_Ketnoi.HuyKetNoi();
            i = int.Parse(tam.Substring(2, tam.Length - 2));
            i++;
            if (i < 10) return "XB00" + i.ToString();
            else
                if (i < 100) return "XB0" + i.ToString();
            else return "XB" + i.ToString();
        }
        string MaNgonNgu()
        {
            laydulieu dl = new laydulieu();
            string tam = "";
            int i = 0;
            SqlDataReader dr = dl.lay_reader("select MaNgonNgu from NgonNgu");
            while (dr.Read())
                tam = dr[0].ToString();
            L_Ketnoi.HuyKetNoi();
            i = int.Parse(tam.Substring(2, tam.Length - 2));
            i++;
            if (i < 10) return "NN00" + i.ToString();
            else
                if (i < 100) return "NN0" + i.ToString();
            else return "NN" + i.ToString();
        }
        #endregion
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnThemMoi.Text == "OK") //Nếu đang trạng thái nhập liệu
                {
                    //--thuc hien tao du lieu cho doi tuong sach
                    #region set giá trị
                    TaiLieu taiLieu = new TaiLieu();
                    taiLieu.MaTaiLieu = txtMaTL.Text;
                    taiLieu.NhanDe = txtNhanDe.Text;
                    taiLieu.SoTrang = int.Parse(txtSoTrang.Text);
                    taiLieu.NamXuatBan = int.Parse(txtnamxuatban.Text);
                    taiLieu.LanXuatBan = int.Parse(txtlanxuatban.Text);
                    taiLieu.NgayNhap = DateTime.Parse(txtNgayNhap.Text);
                    taiLieu.MaTheLoai = cbloaisach.SelectedValue.ToString();
                    taiLieu.MaNgonNgu = (int)cbNgonNgu.SelectedValue;
                    taiLieu.MaTacGia = (int)cbTacGia.SelectedValue;
                    taiLieu.IDNXB = (int)cbNhaXuatBan.SelectedValue;
                    taiLieu.TheThuc = String.IsNullOrEmpty(cbTheThuc.Text) ? "Không mượn về nhà" : cbTheThuc.Text;
                    taiLieu.IDGiaXep = (int)cbGiaXep.SelectedValue;

                    if (TaiLieu.ThemMoi(taiLieu))
                    {
                        MessageBox.Show("Thêm mới thành công");
                        Load_treeview();
                        trvListTaiLieu.Enabled = true;
                    }
                    #endregion
                }
                else
                {
                    trvListTaiLieu.Enabled = false;
                    set_enable(true);
                    btCapNhat.Enabled = false;
                    btxoa.Enabled = false;
                    txtNgayNhap.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    btnThemMoi.Text = "OK";
                    txtlanxuatban.Text = "0";
                    txtnamxuatban.Text = "";
                    txtNhanDe.Text = "";
                    txtSoTrang.Text = "0";
                    txtMaTL.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thực hiện thao tác xoá ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TaiLieu taiLieu = TaiLieu.GetTaiLieuTheoMa(txtMaTL.Text);
                if (taiLieu != null)
                {
                    if (TaiLieu.XoaBo(taiLieu.IDTaiLieu))
                    {
                        MessageBox.Show("Xóa tài liệu thành công!!!");
                        Load_treeview();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi trong xoá bỏ tài liệu", "Thông báo");
                    }
                }
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            if (btCapNhat.Text == "OK")
            {

                //--thuc hien tao du lieu cho doi tuong sach
                #region set giá trị
                TaiLieu taiLieu = new TaiLieu();

                taiLieu.IDTaiLieu = Convert.ToInt32(txtMaTL.Tag);
                taiLieu.MaTaiLieu = txtMaTL.Text;
                taiLieu.NhanDe = txtNhanDe.Text;
                taiLieu.SoTrang = int.Parse(txtSoTrang.Text);
                taiLieu.NamXuatBan = int.Parse(txtnamxuatban.Text);
                taiLieu.LanXuatBan = int.Parse(txtlanxuatban.Text);
                taiLieu.NgayNhap = DateTime.Parse(txtNgayNhap.Text);
                taiLieu.MaTheLoai = cbloaisach.SelectedValue.ToString();
                taiLieu.MaNgonNgu = (int)cbNgonNgu.SelectedValue;
                taiLieu.MaTacGia = (int)cbTacGia.SelectedValue;
                taiLieu.IDNXB = (int)cbNhaXuatBan.SelectedValue;
                taiLieu.TheThuc = String.IsNullOrEmpty(cbTheThuc.Text) ? "Không mượn về nhà" : cbTheThuc.Text;
                taiLieu.IDGiaXep = (int)cbGiaXep.SelectedValue;

                if (TaiLieu.CapNhat(taiLieu))
                {
                    MessageBox.Show("Cập nhật thành công");
                    Load_treeview();
                    trvListTaiLieu.Enabled = true;
                }

                #endregion
            }
            else
            {
                trvListTaiLieu.Enabled = false;
                set_enable(true);
                btnThemMoi.Enabled = false;
                btxoa.Enabled = false;
                btCapNhat.Text = "OK";
            }
        }

        private void FrmCapNhatsach_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
            Frmmain.hf.set_text(Frmhelpfast.t);
            Frmmain.hf.set_anh(1);
            Frmmain.hf.timer5.Enabled = false;
        }
    }
}