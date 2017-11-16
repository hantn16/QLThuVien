using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using System.Data.SqlClient;
using quanly.doituong;
using quanlythuvien.DoiTuong;
using quanly.DoiTuong;
using quanlythuvien.Data;

namespace quanly.frm
{
    public partial class FrmTraSach : Form
    {
        public DateTime NgayGiaHan = new DateTime();
        public FrmTraSach()
        {
            InitializeComponent();
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuMuon pm = PhieuMuon.GetPhieuMuonTheoID(Convert.ToInt32(grbPhieuMuon.Tag));
                if (pm.TinhTrang == 0) throw new Exception("Phiếu mượn này đã trả sách rồi!!!");
                pm.NgayTra = DateTime.Now;
                pm.TinhTrang = 0;
                if(PhieuMuon.CapNhat(pm)) MessageBox.Show("Trả sách thành công!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmTraSach_Load(object sender, EventArgs e)
        {
            try
            {
                Frmmain.tt = true;
                Load_AutoComplete();
                Load_ComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Load_ComboBox()
        {
            try
            {
                List<HinhThucMuon> list = HinhThucMuon.GetDSHinhThucMuon();
                cbHinhThucMuon.DataSource = list;
                cbHinhThucMuon.ValueMember = "IDHinhThucMuon";
                cbHinhThucMuon.DisplayMember = "TenHinhThucMuon";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Load_AutoComplete()
        {
            try
            {
                List<PhieuMuon> list = PhieuMuon.GetDSPhieuMuon();
                List<string> listMaPhieuMuon = new List<string>();
                foreach (PhieuMuon item in list)
                {
                    listMaPhieuMuon.Add(item.MaPhieuMuon);
                }
                txtPhieuMuon.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtPhieuMuon.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                collection.AddRange(listMaPhieuMuon.ToArray());
                txtPhieuMuon.AutoCompleteCustomSource = collection;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FrmTraSach_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Frmmain.tt = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuMuon pm = PhieuMuon.GetDSPhieuMuon().Find(c => c.MaPhieuMuon == txtPhieuMuon.Text);
                if (pm.TinhTrang == 0) { MessageBox.Show("Phiếu mượn này đã trả sách"); btnTraSach.Enabled = false; } else btnTraSach.Enabled = true;
                Load_ThongTinPhieu(pm.IDPhieuMuon);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Load_ThongTinPhieu(long id)
        {
            try
            {
                PhieuMuon pm = PhieuMuon.GetPhieuMuonTheoID(id);
                //Load thông tin độc giả
                txtIDDocGia.Text = pm.IDDocGia.ToString();
                DocGia dg = DocGia.GetDocGiaTheoID(pm.IDDocGia);
                txtMaDocGia.Text = dg.MaDocGia;
                txtTenDocGia.Text = dg.HoTen;
                //Load thông tin tài liệu
                txtIDTaiLieu.Text = pm.IDTaiLieu.ToString();
                txtMaTaiLieu.Text = TaiLieu.GetMaTLTheoID(pm.IDTaiLieu);
                TaiLieu tl = TaiLieu.GetTaiLieuTheoMa(txtMaTaiLieu.Text);
                txtTenTaiLieu.Text = tl.NhanDe;
                txtSLMuon.Text = pm.SoLuong.ToString();
                //Load thông tin phiếu mượn
                cbHinhThucMuon.SelectedValue = pm.IDHinhThucMuon;
                txtNgayMuon.Text = pm.NgayMuon.ToString("dd/MM/yyyy");
                txtThoiHanTra.Text = pm.ThoiHanTra.ToString("dd/MM/yyyy");
                //Tính ngày quá hạn
                if (pm.ThoiHanTra < DateTime.Now)
                {
                    lblQuaHan.Text = "Quá hạn " + Math.Round((pm.ThoiHanTra - DateTime.Now).TotalDays, 2) + " ngày";
                    btnGiaHan.Enabled = true;
                }
                else
                { lblQuaHan.Text = ""; btnGiaHan.Enabled = true; }
                grbPhieuMuon.Tag = pm.IDPhieuMuon;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void GetNgayTraMoi(DateTime date)
        {
            this.NgayGiaHan = date;
        }
        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuMuon pm = PhieuMuon.GetPhieuMuonTheoID(Convert.ToInt32(grbPhieuMuon.Tag));

                if (pm.TinhTrang == 0) throw new Exception("Phiếu mượn này đã trả rồi!!!");
                frmgiahansach frm = new frmgiahansach();
                DialogResult dialog = frm.ShowDialog();
                if (dialog == DialogResult.OK)
                {                  
                    pm.ThoiHanTra = frm.NgayGiaHan;
                    pm.TinhTrang = 1;
                    string query = string.Format(@"Update PhieuMuon Set ThoiHanTra = Convert(datetime,N'{0}'),
                    TinhTrang = {1} Where IDPhieuMuon = {2}", pm.ThoiHanTra.ToString("yyyy-MM-dd HH:mm:ss"), 1, pm.IDPhieuMuon);
                    int result = DataProvider.ExecuteNonQuery(query);
                    if (result>0) { MessageBox.Show("Gia hạn thành công"); Load_ThongTinPhieu(pm.IDPhieuMuon); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}