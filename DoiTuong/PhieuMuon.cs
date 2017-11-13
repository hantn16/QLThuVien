using quanlythuvien.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlythuvien.DoiTuong
{
    public class PhieuMuon
    {
        public long IDPhieuMuon { get; set; }
        public string MaPhieuMuon { get; set; }
        public int IDNhanVien { get; set; }
        public int IDDocGia { get; set; }
        public int IDTaiLieu { get; set; }
        public int IDHinhThucMuon { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime ThoiHanTra { get; set; }
        public DateTime NgayTra { get; set; }
        public int TinhTrang { get; set; }

        public static bool ThemMoi(PhieuMuon item)
        {
            try
            {
                string query = string.Format(@"Insert into dbo.PhieuMuon (MaPhieuMuon,IDNhanVien,IDDocGia,IDTaiLieu,IDHinhThucMuon,SoLuong,NgayMuon,ThoiHanTra,TinhTrang) Values 
                    (N'{0}',{1},{2},{3},{4},{5},Convert(datetime,N'{6}'),Convert(datetime,N'{7}'),{8})",
                    item.MaPhieuMuon, item.IDNhanVien, item.IDDocGia, item.IDTaiLieu, item.IDHinhThucMuon, 
                    item.SoLuong, item.NgayMuon.ToString("yyyy-MM-dd HH:mm:ss"), item.ThoiHanTra.ToString("yyyy-MM-dd HH:mm:ss"), item.TinhTrang);
                if (DataProvider.ExecuteNonQuery(query) > 0) return true; else return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<PhieuMuon> GetDSPhieuMuon()
        {
            try
            {
                List<PhieuMuon> list = new List<PhieuMuon>();
                string query = "Select * from dbo.PhieuMuon";
                DataTable dt = DataProvider.ExecuteQuery(query);
                if (dt.Rows.Count <= 0) return null;
                foreach (DataRow dr in dt.Rows)
                {
                    PhieuMuon item = new PhieuMuon();
                    item.IDPhieuMuon = Convert.ToInt32(dr["IDPhieuMuon"]);
                    item.IDNhanVien = Convert.ToInt32(dr["IDNhanVien"]);
                    item.IDDocGia = Convert.ToInt32(dr["IDDocGia"]);
                    item.IDTaiLieu = Convert.ToInt32(dr["IDTaiLieu"]);
                    item.IDHinhThucMuon = Convert.ToInt32(dr["IDHinhThucMuon"]);
                    item.SoLuong = Convert.ToInt32(dr["SoLuong"]);
                    item.TinhTrang = Convert.ToInt32(dr["TinhTrang"]);
                    item.MaPhieuMuon = dr["MaPhieuMuon"].ToString();
                    if(dr["NgayMuon"] != DBNull.Value) item.NgayMuon= Convert.ToDateTime(dr["NgayMuon"]);
                    if (dr["ThoiHanTra"] != DBNull.Value) item.ThoiHanTra = Convert.ToDateTime(dr["ThoiHanTra"]);
                    if (dr["NgayTra"] != DBNull.Value) item.NgayTra = Convert.ToDateTime(dr["NgayTra"]);
                    list.Add(item);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static PhieuMuon GetPhieuMuonTheoID(long id)
        {
            try
            {
                return GetDSPhieuMuon().Find(c => c.IDPhieuMuon == id);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static bool CapNhat(PhieuMuon pm)
        {
            try
            {
                PhieuMuon phieu = PhieuMuon.GetPhieuMuonTheoID(pm.IDPhieuMuon);
                if (phieu != null)
                {
                    string query = string.Format(@"Update PhieuMuon Set MaPhieuMuon = N'{0}',
                        IDNhanVien = {1},
                        IDDocGia = {2},
                        IDTaiLieu = {3},
                        IDHinhThucMuon = {4},
                        SoLuong = {5},
                        NgayMuon = Convert(datetime,N'{6}'),
                        ThoiHanTra = Convert(datetime,N'{7}'),
                        NgayTra = Convert(datetime,N'{8}'),
                        TinhTrang = {9} Where IDPhieuMuon = {10}",
                        pm.MaPhieuMuon, pm.IDNhanVien, pm.IDDocGia,
                        pm.IDTaiLieu, pm.IDHinhThucMuon, pm.SoLuong, pm.NgayMuon.ToString("yyyy-MM-dd HH:mm:ss"), pm.ThoiHanTra.ToString("yyyy-MM-dd HH:mm:ss"),pm.NgayTra.ToString("yyyy-MM-dd HH:mm:ss") ,pm.TinhTrang, pm.IDPhieuMuon);
                    if (DataProvider.ExecuteNonQuery(query) == 1) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool XoaBo(long id)
        {
            try
            {
                string query = "Delete from PhieuMuon where IDPhieuMuon = " + id;
                if (DataProvider.ExecuteNonQuery(query) > 0) return true; else return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
