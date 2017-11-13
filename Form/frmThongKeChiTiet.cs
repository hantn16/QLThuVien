using quanlythuvien.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace quanly.frm
{
    public partial class frmThongKeChiTiet : Form
    {
        public frmThongKeChiTiet()
        {
            InitializeComponent();
        }

        private void frmThongKeChiTiet_Load(object sender, EventArgs e)
        {
            try
            {
                Load_ThongTinTextbox();
                tcThongKeTL.SelectedTab = tcThongKeTL.TabPages["tpTatCa"];
                Load_dgv(0);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Load_ThongTinTextbox()
        {
            try
            {
                //Lấy thông tin số lượng
                string query = "SELECT dbo.GetSLTaiLieu( @type )";
                txtSLTatCa.Text = DataProvider.ExecuteScalar(query, new object[] { 0 }).ToString();
                txtSLMuon.Text = DataProvider.ExecuteScalar(query, new object[] { 1 }).ToString();
                txtSLCoSan.Text = DataProvider.ExecuteScalar(query, new object[] { 2 }).ToString();
                txtSLHong.Text = DataProvider.ExecuteScalar(query, new object[] { 3 }).ToString();

                //Lấy thông tin số lượng mã
                string query2 = "SELECT dbo.GetSLMaTaiLieu( @type )";
                txtSoMaTatCa.Text = DataProvider.ExecuteScalar(query2, new object[] { 0 }).ToString();
                txtSoMaMuon.Text = DataProvider.ExecuteScalar(query2, new object[] { 1 }).ToString();
                txtSoMaCoSan.Text = DataProvider.ExecuteScalar(query2, new object[] { 2 }).ToString();
                txtSoMaHong.Text = DataProvider.ExecuteScalar(query2, new object[] { 3 }).ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                Load_ThongTinTextbox();
                int selectedTabPage = tcThongKeTL.SelectedIndex;
                Load_dgv(selectedTabPage);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void tcThongKeTL_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tcThongKeTL.SelectedIndex)
                {
                    case 1: Load_dgvMuon(); break;
                    case 2: Load_dgvCoSan(); break;
                    case 3: Load_dgvHong(); break;
                    default: Load_dgvTatCa(); break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Load_dgv(int type)
        {
            try
            {
                switch (type)
                {
                    case 1: Load_dgvMuon(); break;
                    case 2: Load_dgvCoSan(); break;
                    case 3: Load_dgvHong(); break;
                    default: Load_dgvTatCa(); break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Load_dgvTatCa()
        {
            try
            {
                string query = @"Select tl.IDTaiLieu as ID, tl.MaTaiLieu as [Mã tài liệu],tl.NhanDe as [Nhan đề],
                                tl.SoLuong as [Tổng số lượng], Coalesce(p.SumSoLuong,0) as [SL Mượn],
                                dbo.GetSLCoSanTheoID(tl.IDTaiLieu) as [SL có sẵn],tl.SoLuongHong as [Số lượng hỏng]
                                from TaiLieu tl left join (Select pm.IDTaiLieu,SUM(pm.SoLuong) as SumSoLuong 
                                from PhieuMuon pm where pm.TinhTrang <>0  group by pm.IDTaiLieu) p 
                                on p.IDTaiLieu = tl.IDTaiLieu";
                DataTable dt = DataProvider.ExecuteQuery(query);
                dgvTatCa.DataSource = dt;
                dgvTatCa.Refresh();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Load_dgvHong()
        {
            try
            {
                string query = @"Select tl.IDTaiLieu as [ID] ,tl.MaTaiLieu as [Mã tài liệu] ,tl.NhanDe as [Nhan đề] ,
                                tl.SoLuongHong as [SL hỏng] from TaiLieu tl where tl.SoLuongHong > 0";
                DataTable dt = DataProvider.ExecuteQuery(query);
                dgvHong.DataSource = dt;
                dgvHong.Refresh();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Load_dgvCoSan()
        {
            try
            {
                string query = @"Select tl.IDTaiLieu as [ID] ,tl.MaTaiLieu as [Mã tài liệu] ,tl.NhanDe as [Nhan đề] ,
                                dbo.GetSLCoSanTheoID(tl.IDTaiLieu) as [SL có sẵn] 
                                from TaiLieu tl where dbo.GetSLCoSanTheoID(tl.IDTaiLieu) > 0";
                DataTable dt = DataProvider.ExecuteQuery(query);
                dgvCoSan.DataSource = dt;
                dgvCoSan.Refresh();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Load_dgvMuon()
        {
            try
            {
                string query = @"Select p.IDTaiLieu,tl.MaTaiLieu,tl.NhanDe,p.SumSL,Coalesce(n.SLDaTra,0) as [SL đã trả],
                                p.SumSL-Coalesce(n.SLDaTra,0) as [SL chưa trả] from
                                (Select pm.IDTaiLieu,Sum(pm.SoLuong) as SumSL
                                from PhieuMuon pm group by pm.IDTaiLieu) p left join
                                (Select a.IDTaiLieu, SUM(a.SoLuong) as SLDaTra
                                from PhieuMuon a where a.TinhTrang = 0 group by a.IDTaiLieu) n on p.IDTaiLieu = n.IDTaiLieu
                                inner join TaiLieu tl on p.IDTaiLieu = tl.IDTaiLieu";
                DataTable dt = DataProvider.ExecuteQuery(query);
                dgvMuon.DataSource = dt;
                dgvMuon.Refresh();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}