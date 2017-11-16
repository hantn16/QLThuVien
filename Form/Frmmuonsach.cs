using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using quanly.lopdulieu;
using System.Windows.Forms;
using System.Data.SqlClient;
using quanly.doituong;
using quanlythuvien.Data;
using quanly.DoiTuong;
using QLTV.GUI.DoiTuong;
using quanlythuvien.DoiTuong;

namespace quanly.frm
{
    public partial class Frmmuonsach : Form
    {
        public Frmmuonsach()
        {
            InitializeComponent();
            AddAutoComplete();
            Load_ComboBox();
        }

        private void Load_ComboBox()
        {
            List<HinhThucMuon> list = HinhThucMuon.GetDSHinhThucMuon();
            cbHinhThucMuon.DataSource = list;
            cbHinhThucMuon.ValueMember = "IDHinhThucMuon";
            cbHinhThucMuon.DisplayMember = "TenHinhThucMuon";
        }

        private void btnCheckTL_Click(object sender, EventArgs e)
        {
            try
            {
                TaiLieu taiLieu = TaiLieu.GetTaiLieuTheoMa(txtMaTaiLieu.Text);
                if (taiLieu == null) throw new Exception("Không tìm thấy tài liệu với mã tương ứng");

                txtIDTL.Text = taiLieu.IDTaiLieu.ToString();
                txtNhanDe.Text = taiLieu.NhanDe.ToString();
                txtSoLuong.Text = taiLieu.SoLuong.ToString();
                txtSLCoSan.Text = TaiLieu.SoLuongCoSan(taiLieu.IDTaiLieu).ToString();
                txtLanXuatBan.Text = taiLieu.LanXuatBan.ToString();
                txtSoTrang.Text = taiLieu.SoTrang.ToString();

                NhaXuatBan nxb = NhaXuatBan.TimNXBTheoID(taiLieu.IDNXB);
                txtNXB.Text = nxb.TenNhaXuatBan;
                NgonNgu nn = NgonNgu.LayDSNgonNgu().Find(c => c.IDNgonNgu == taiLieu.IDNgonNgu);
                txtNgonNgu.Text = nn.TenNgonNgu;
                txtNamXuatBan.Text = taiLieu.NamXuatBan.ToString();
                TacGia tg = TacGia.LayDSTacGia().Find(c => c.IDTacGia == taiLieu.IDTacGia);
                txtTacGia.Text = tg.TenTacGia;
                TheLoai theLoai = TheLoai.GetDanhSachTheLoai().Find(c => c.IDTheLoai == taiLieu.IDTheLoai);
                txtTheLoai.Text = theLoai.TenTheLoai;
                GiaXep gx = GiaXep.GetDSGiaXep().Find(c => c.IDGiaXep == taiLieu.IDGiaXep);
                txtGiaXep.Text = gx.MaGiaXep;
                Kho kho = Kho.GetDanhSachKho().Find(c => c.IDKho == gx.IDKho);
                txtKho.Text = kho.MaKho;
                txtNamXuatBan.Text = taiLieu.NamXuatBan.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtMaTaiLieu.Focus();

            }

        }

        private void Frmmuonsach_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
        }

        private void AddAutoComplete()
        {
            try
            {
                //AutoComplete mục gõ tên tài liệu
                DataTable dt = DataProvider.ExecuteQuery("Select IDTaiLieu,MaTaiLieu,NhanDe From dbo.TaiLieu");
                List<string> list = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    string item = dr["MaTaiLieu"].ToString();
                    list.Add(item);
                }

                AutoCompleteStringCollection autoList = new AutoCompleteStringCollection();
                autoList.AddRange(list.ToArray());
                txtMaTaiLieu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtMaTaiLieu.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtMaTaiLieu.AutoCompleteCustomSource = autoList;

                //AutoComplete mục gõ mã bạn đọc
                DataTable dtDocGia = DataProvider.ExecuteQuery("Select MaDocGia From dbo.DocGia");
                List<string> listDG = new List<string>();
                foreach (DataRow dr in dtDocGia.Rows)
                {
                    string item = dr["MaDocGia"].ToString();
                    listDG.Add(item);
                }
                txtMaDocGia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtMaDocGia.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection autoListDG = new AutoCompleteStringCollection();
                autoListDG.AddRange(listDG.ToArray());
                txtMaDocGia.AutoCompleteCustomSource = autoListDG;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btbandoc(object sender, EventArgs e)
        {
            try
            {
                DocGia dg = DocGia.GetDSDocGia().Find(c => c.MaDocGia == txtMaDocGia.Text);
                txtIDDocGia.Text = dg.IDDocGia.ToString();
                txtHoTen.Text = dg.HoTen;
                Lop lop = Lop.GetLopTheoID(dg.IDLop);
                txtLop.Text = lop.TenLop;
                txtDiaChi.Text = dg.DiaChi;
                Khoa khoa = Khoa.GetDSKhoa().Find(c => c.IDKhoa == lop.IDKhoa);
                txtKhoa.Text = khoa.TenKhoa;
                txtHoTen.Tag = dg.Lock;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Hàm tự sinh mã phiếu mượn theo ngày
        /// </summary>
        /// <returns></returns>
        string SetMaPhieuMuon()
        {
            string TienTo = "PM" + DateTime.Now.ToString("yyMMdd") + "-";
            string query = string.Format("Select Max(Convert(int,RIGHT(MaPhieuMuon,3)))from PhieuMuon Where MaPhieuMuon like N'{0}%'", TienTo);
            Object obj = DataProvider.ExecuteScalar(query);
            if (obj == DBNull.Value)
            {
                return TienTo + "001";
            }
            else
            {
                return TienTo + (Convert.ToInt32(obj) + 1).ToString("000");
            }
        }
        private void btnChoMuon_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtSLCoSan.Text) == 0) throw new Exception("Tài liệu không có sẵn trong thư viện, không thể mượn");
                if (Convert.ToBoolean(txtHoTen.Tag)) throw new Exception("Mã độc giả này đang bị khóa, không thể mượn tài liệu");
                if (cbHinhThucMuon.Text == "") MessageBox.Show("Bạn phải chọn thể thức mượn");
                PhieuMuon pm = new PhieuMuon();
                pm.MaPhieuMuon = SetMaPhieuMuon();
                pm.IDNhanVien = Frmmain.nv.IDNhanVien;
                pm.IDDocGia = int.Parse(txtIDDocGia.Text);
                pm.IDTaiLieu = int.Parse(txtIDTL.Text);
                pm.IDHinhThucMuon = Convert.ToInt32(cbHinhThucMuon.SelectedValue);
                pm.SoLuong = int.Parse(txtSLMuon.Text);
                pm.NgayMuon = DateTime.Now;
                pm.ThoiHanTra = TinhThoiHanTra(DateTime.Now, pm.IDHinhThucMuon);
                pm.TinhTrang = 1;

                if (PhieuMuon.ThemMoi(pm)) MessageBox.Show("Thêm mới phiếu mượn thành công!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// Hàm tính thời hạn trả theo ngày mượn và hình thức mượn
        /// </summary>
        /// <param name="ngayMuon">Ngày bắt đầu mượn</param>
        /// <param name="iDHinhThucMuon">id hình thức mượn: 1-mượn tại chỗ, 2-mượn về nhà</param>
        /// <returns></returns>
        private DateTime TinhThoiHanTra(DateTime ngayMuon, int iDHinhThucMuon)
        {
            try
            {
                if (iDHinhThucMuon == 1) //Nếu mượn tại chỗ thì trả trước 18h cùng ngày
                {
                    return new DateTime(ngayMuon.Year, ngayMuon.Month, ngayMuon.Day, 18, 00, 00);
                }
                else //Nếu mượn về nhà thì phải trả trước 7 ngày
                {
                    return ngayMuon.AddDays(7);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHinhThucMuon.Text == "Mượn giáo trình")
                txtSLMuon.Enabled = true;
            else
            {
                txtSLMuon.Text = "1";
                txtSLMuon.Enabled = false;
            }
        }
        private void Frmmuonsach_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }
    }
}