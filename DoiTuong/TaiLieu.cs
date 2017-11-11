using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using System.Data.SqlClient;
using quanlythuvien.Data;
using System.Data;
using System.Windows.Forms;

namespace quanly.doituong
{
    public class TaiLieu
    {
        public long IDTaiLieu { get; set; }
        public string MaTaiLieu { get; set; }

        public string NhanDe { get; set; }
        public string MaTheLoai { get; set; }
        public int IDNXB { get; set; }
        public int MaNgonNgu { get; set; }
        public int MaTacGia { get; set; }
        public int IDGiaXep { get; set; }
        public int SoTrang { get; set; }
        public int SoLuong { get; set; }
        public int LanXuatBan { get; set; }
        public int SoLanMuon { get; set; }
        public string TheThuc { get; set; }
        public int NamXuatBan { get; set; }
        public DateTime NgayNhap { get; set; }

        public TaiLieu() { }

        #region các thủ tục lấy mã
        //public int LayMaTheLoai(string tam)
        //{
        //    try
        //    {
        //        string query = "select MaTheLoai from TheLoai where TenTheLoai = N'" + tam + "'";
        //        DataTable dt = DataProvider.ExecuteQuery(query);
        //        this.MaTheLoai = dt.Rows[0][0].ToString();

        //        if (String.IsNullOrEmpty(this.MaTheLoai)) return 0; else return 1;
        //    }
        //    catch { return 0; }
        //}
        //public int LayMaTacGia(string tam)
        //{
        //    try
        //    {
        //        string query = "select MaTacGia from TacGia where TenTacGia=N'" + tam + "'";
        //        DataTable dt = DataProvider.ExecuteQuery(query);
        //        if (dt.Rows.Count > 0)
        //        {
        //            this.MaTacGia = int.Parse(dt.Rows[0][0].ToString());
        //            return 1;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    catch { return 0; }
        //}
        //public int LayMaNgonNgu(string tam)
        //{
        //    try
        //    {
        //        string query = "select MaNgonNgu from NgonNgu where TenNgonNgu= '" + tam + "'";
        //        DataTable dt = DataProvider.ExecuteQuery(query);
        //        if (dt.Rows.Count > 0)
        //        {
        //            this.MaNgonNgu = int.Parse(dt.Rows[0][0].ToString());
        //            return 1;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    catch { return 0; }
        //}
        //public int LayMaNXB(string tam)

        //{
        //    try
        //    {
        //        string query = "select ID from NhaXuatBan where TenNXB=N'" + tam + "'";
        //        DataTable dt = DataProvider.ExecuteQuery(query);
        //        if (dt.Rows.Count > 0)
        //        {
        //            //this.IDNXB = dt.Rows[0][0].ToString();
        //            return 1;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    catch { return 0; }
        //}
        //public int LayMaViTri(string kho, string ke, string ngan)
        //{
        //    try
        //    {
        //        string query = "select MaViTri from ViTriluutru where Kho=N'" + kho + "' and Ke=N'" + ke + "' and Ngan=N'" + ngan + "'";
        //        DataTable dt = DataProvider.ExecuteQuery(query);
        //        if (dt.Rows.Count > 0)
        //        {
        //            this.MaViTri = dt.Rows[0][0].ToString();
        //            return 1;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    catch { return 0; }
        //}
        #endregion
        #region các phương thức hoạt động
        public bool TheLoai(string loai)
        {
            try
            {
                string query = "select MaTheLoai from TheLoai where TenTheLoai=N'" + loai + "'";
                DataTable dt = DataProvider.ExecuteQuery(query);
                if (dt.Rows.Count <= 0) throw new Exception("Không tìm thấy mã thể loại với tên tương ứng!!!");
                this.MaTheLoai = dt.Rows[0]["MaTheLoai"].ToString();
                string updateQuery = " update Sach set MaTheLoai ='" + this.MaTheLoai + "' where MaTaiLieu = '" + MaTaiLieu + "'";
                if (DataProvider.ExecuteNonQuery(updateQuery) == 1) return true; else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        //Chưa cập nhật xong
        public static bool ThemMoi(TaiLieu taiLieu)
        {
            string query = string.Format("INSERT INTO TaiLieu (MaTaiLieu, NhanDe, SoTrang, SoLuong, NamXuatBan, LanXuatBan, SoLanMuon, MaTheLoai, IDNXB, MaNgonNgu, MaTacGia, IDGiaXep, NgayNhap, TheThuc) VALUES ('{0}',N'{1}',{2},{3},{4},{5},{6},N'{7}',{8},{9},{10},{11},Convert(datetime,'{12}'),N'{13}')",
                taiLieu.MaTaiLieu, taiLieu.NhanDe, taiLieu.SoTrang, taiLieu.SoLuong, taiLieu.NamXuatBan, taiLieu.LanXuatBan, 0, taiLieu.MaTheLoai, taiLieu.IDNXB,
                taiLieu.MaNgonNgu, taiLieu.MaTacGia, taiLieu.IDGiaXep, taiLieu.NgayNhap.ToShortDateString(), taiLieu.TheThuc);
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public static bool CapNhat(TaiLieu taiLieu)
        {
            string query = string.Format(@"Update TaiLieu Set 
                MaTaiLieu = '{0}',
                NhanDe = N'{1}',
                SoTrang = {2},
                SoLuong = {3},
                NamXuatBan = {4},
                LanXuatBan = {5},
                MaTheLoai = N'{6}',
                IDNXB = {7},
                MaNgonNgu = {8},
                MaTacGia = {9},
                IDGiaXep = {10},
                NgayNhap = Convert(datetime,N'{11}'),
                TheThuc = N'{12}'
                Where IDTaiLieu = {13}
                ",
                taiLieu.MaTaiLieu, taiLieu.NhanDe, taiLieu.SoTrang, taiLieu.SoLuong, taiLieu.NamXuatBan, taiLieu.LanXuatBan, taiLieu.MaTheLoai, taiLieu.IDNXB,
                taiLieu.MaNgonNgu, taiLieu.MaTacGia, taiLieu.IDGiaXep, taiLieu.NgayNhap.ToString("yyyy-MM-dd hh:mm:ss"), taiLieu.TheThuc,taiLieu.IDTaiLieu);
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public static bool XoaBo(long id)
        {
            string query = "delete from TaiLieu where IDTaiLieu=" + id;
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool ChoMuon(string i)
        {
            string query = "update sach set SoLuong= SoLuong - " + i + ",SoLanMuon = SoLanMuon + 1 where  MaTaiLieu='" + MaTaiLieu + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool TraSach(string i)
        {
            string query = "update sach set SoLuong= SoLuong + " + i + " where  MaTaiLieu='" + MaTaiLieu + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public static TaiLieu GetTaiLieuTheoMa(string maTaiLieu)
        {
            try
            {
                string query = string.Format("Select * from TaiLieu where MaTaiLieu = N'{0}'", maTaiLieu);
                DataTable dt = DataProvider.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    TaiLieu taiLieu = new TaiLieu();
                    taiLieu.IDTaiLieu = int.Parse(dr["IDTaiLieu"].ToString());
                    taiLieu.MaTaiLieu = dr["MaTaiLieu"].ToString();
                    taiLieu.NhanDe = dr["NhanDe"].ToString();
                    taiLieu.SoTrang = int.Parse(dr["SoTrang"].ToString());
                    taiLieu.SoLuong = int.Parse(dr["SoLuong"].ToString());
                    taiLieu.NamXuatBan = int.Parse(dr["NamXuatBan"].ToString());
                    taiLieu.LanXuatBan = int.Parse(dr["LanXuatBan"].ToString());
                    taiLieu.SoLanMuon = int.Parse(dr["SoLanMuon"].ToString());
                    taiLieu.MaTheLoai = dr["MaTheLoai"].ToString();
                    taiLieu.IDNXB = int.Parse(dr["IDNXB"].ToString());
                    taiLieu.MaNgonNgu = int.Parse(dr["MaNgonNgu"].ToString());
                    taiLieu.MaTacGia = int.Parse(dr["MaTacGia"].ToString());
                    taiLieu.IDGiaXep = int.Parse(dr["IDGiaXep"].ToString());
                    taiLieu.NgayNhap = (DateTime)dr["NgayNhap"];
                    taiLieu.TheThuc = dr["TheThuc"].ToString();

                    return taiLieu;
                }
                else
                {
                    throw new Exception("Không tìm thấy mã tài liệu tương ứng");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        #endregion
    }
}
