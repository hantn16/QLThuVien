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
    public partial class Frmthongtinsachtrongngay : Form
    {
        public Frmthongtinsachtrongngay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void Frmthongtinsachtrongngay_Load(object sender, EventArgs e)
        {
            try
            {
                Add_DataTableColumns();
                Load_DataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Frmmain.tt = true;

        }

        private void Load_DataGridView()
        {
            try
            {
                DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime end = start.AddTicks(-1).AddDays(1);
                string query = @"Select pm.MaPhieuMuon as [Mã phiếu mượn],tl.MaTaiLieu as [Mã tài liệu],tl.NhanDe as [Nhan đề],
                        dg.MaDocGia as [Mã độc giả],dg.HoTen as [Họ tên],pm.NgayMuon as [Ngày mượn],
                        pm.IDHinhThucMuon as [Hình thức mượn],pm.SoLuong as [Số lượng],pm.TinhTrang as [Tình trạng] 
                        from PhieuMuon pm inner join TaiLieu tl on pm.IDTaiLieu = tl.IDTaiLieu
                        inner join DocGia dg on pm.IDDocGia = dg.IDDocGia
                        where (pm.NgayMuon >= @start and pm.NgayMuon <= @end ) ";
                DataTable data = new DataTable();
                data = DataProvider.ExecuteQuery(query, new object[] { start, end });
                DataTable dtMuonVeNha = data.Clone();
                DataTable dtMuonTaiCho = data.Clone();
                DataTable dtChuaTra = new DataTable();
                dtChuaTra.Columns.AddRange(new DataColumn[] { new DataColumn("Mã phiếu mượn"),
                    new DataColumn("Mã tài liệu"), new DataColumn("Mã độc giả")});
                
                foreach (DataRow dr in data.Rows)
                {
                    if (Convert.ToInt32(dr["Hình thức mượn"]) == 2)
                    {
                        DataRow rowMVN = dtMuonVeNha.NewRow();
                        foreach (DataColumn cl in data.Columns)
                        {
                            rowMVN[cl.ColumnName] = dr[cl.ColumnName];
                        }
                        dtMuonVeNha.Rows.Add(rowMVN);
                    }
                    else if (Convert.ToInt32(dr["Hình thức mượn"]) == 1)
                    {
                        DataRow rowMTC = dtMuonTaiCho.NewRow();
                        foreach (DataColumn cl in dtMuonTaiCho.Columns)
                        {
                            rowMTC[cl.ColumnName] = dr[cl.ColumnName];
                        }
                        dtMuonTaiCho.Rows.Add(rowMTC);
                        if (Convert.ToInt32(dr["Tình trạng"]) != 0)
                        {
                            DataRow row = dtChuaTra.NewRow();
                            row["Mã phiếu mượn"] = dr["Mã phiếu mượn"];
                            row["Mã tài liệu"] = dr["Mã tài liệu"];
                            row["Mã độc giả"] = dr["Mã độc giả"];
                            dtChuaTra.Rows.Add(row);
                        }
                    }
                }
                dgvMuonVeNha.DataSource = dtMuonVeNha;
                dgvMuonTaiCho.DataSource = dtMuonTaiCho;
                dgvChuaTra.DataSource = dtChuaTra;
                dgvChuaTra.Refresh();
                dgvMuonTaiCho.Refresh();
                dgvMuonVeNha.Refresh();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Add_DataTableColumns()
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Frmthongtinsachtrongngay_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Frmthongtinsachtrongngay_Load(this, e);
        }
    }
}
