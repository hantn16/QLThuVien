using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using quanly.lopdulieu;
using quanlythuvien.DoiTuong;
using quanlythuvien.Data;

namespace quanly.frm
{
    public partial class Frmthongtinsachtheongay : Form
    {
        public Frmthongtinsachtheongay()
        {
            InitializeComponent();
        }

        private void Frmthongtinsachtheongay_Load(object sender, EventArgs e)
        {
            try
            {
                Frmmain.tt = true;
                //AddColumn_ListView();
                Load_ComboBox();
                mCldChonNgay.SelectionStart = DateTime.Now;
                DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime end = start.AddTicks(-1).AddDays(1);
                Load_ListView(start,end,0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Load_ListView(DateTime start, DateTime end, int idHinhThuc)
        {
            try
            {
                string query = @"Select pm.MaPhieuMuon as [Mã phiếu mượn],tl.MaTaiLieu as [Mã tài liệu],tl.NhanDe as [Nhan đề],
                                        dg.MaDocGia as [Mã độc giả],dg.HoTen as [Họ tên],pm.NgayMuon as [Ngày mượn],ht.TenHinhThucMuon as [Hình thức mượn],pm.SoLuong as [Số lượng] 
                                        from PhieuMuon pm inner join TaiLieu tl on pm.IDTaiLieu = tl.IDTaiLieu
                                        inner join DocGia dg on pm.IDDocGia = dg.IDDocGia
                                        inner join HinhThucMuon ht on pm.IDHinhThucMuon = ht.IDHinhThucMuon
                                        where (pm.NgayMuon >= @start and pm.NgayMuon <= @end ) ";
                DataTable data = new DataTable();
                if (idHinhThuc != 0)
                {
                    query += "And pm.IDHinhThucMuon = @idHinhThuc";
                     data = DataProvider.ExecuteQuery(query,new object[] { start,end,idHinhThuc});
                }
                else
                {
                     data = DataProvider.ExecuteQuery(query, new object[] { start, end });
                }                
                dgvData.DataSource = data;
                dgvData.Refresh();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Load_ComboBox()
        {
            try
            {
                List<HinhThucMuon> list = new List<HinhThucMuon>();
                list.Add(new HinhThucMuon() { IDHinhThucMuon = 0, TenHinhThucMuon = "Tất cả" });
                list.AddRange(HinhThucMuon.GetDSHinhThucMuon());
                cbHinhThucMuon.DataSource = list;
                cbHinhThucMuon.ValueMember = "IDHinhThucMuon";
                cbHinhThucMuon.DisplayMember = "TenHinhThucMuon";
                cbHinhThucMuon.SelectedIndex = 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AddColumn_ListView()
        {
            try
            {

                dgvData.Columns.Add("MaPhieuMuon", "Mã phiếu mượn");
                dgvData.Columns.Add("MaTaiLieu", "Mã tài liệu");
                dgvData.Columns.Add("NhanDe", "Nhan đề");
                dgvData.Columns.Add("MaDocGia", "Mã độc giả");
                dgvData.Columns.Add("HoTen", "Tên độc giả");
                dgvData.Columns.Add("NgayMuon", "Ngày mượn");
                dgvData.Columns.Add("TenHinhThucMuon", "Hình thức mượn");
                dgvData.Columns.Add("SoLuong", "Số lượng");
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime dau = e.Start;
            DateTime cuoi = e.End;

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void Frmthongtinsachtheongay_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime sDate = mCldChonNgay.SelectionStart;
                DateTime eDate = mCldChonNgay.SelectionEnd;
                DateTime start = new DateTime(sDate.Year, sDate.Month, sDate.Day);
                DateTime end = new DateTime(eDate.Year, eDate.Month, eDate.Day).AddTicks(-1).AddDays(1);
                Load_ListView(start, end, Convert.ToInt32(cbHinhThucMuon.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}