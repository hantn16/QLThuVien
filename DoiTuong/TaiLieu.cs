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
        public string IDTheLoai { get; set; }
        public int IDNXB { get; set; }
        public int IDNgonNgu { get; set; }
        public int IDTacGia { get; set; }
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
        //public int LayIDTheLoai(string tam)
        //{
        //    try
        //    {
        //        string query = "select IDTheLoai from TheLoai where TenTheLoai = N'" + tam + "'";
        //        DataTable dt = DataProvider.ExecuteQuery(query);
        //        this.IDTheLoai = dt.Rows[0][0].ToString();

        //        if (String.IsNullOrEmpty(this.IDTheLoai)) return 0; else return 1;
        //    }
        //    catch { return 0; }
        //}
        //public int LayIDTacGia(string tam)
        //{
        //    try
        //    {
        //        string query = "select IDTacGia from TacGia where TenTacGia=N'" + tam + "'";
        //        DataTable dt = DataProvider.ExecuteQuery(query);
        //        if (dt.Rows.Count > 0)
        //        {
        //            this.IDTacGia = int.Parse(dt.Rows[0][0].ToString());
        //            return 1;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    catch { return 0; }
        //}
        //public int LayIDNgonNgu(string tam)
        //{
        //    try
        //    {
        //        string query = "select IDNgonNgu from NgonNgu where TenNgonNgu= '" + tam + "'";
        //        DataTable dt = DataProvider.ExecuteQuery(query);
        //        if (dt.Rows.Count > 0)
        //        {
        //            this.IDNgonNgu = int.Parse(dt.Rows[0][0].ToString());
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
                string query = "select IDTheLoai from TheLoai where TenTheLoai=N'" + loai + "'";
                DataTable dt = DataProvider.ExecuteQuery(query);
                if (dt.Rows.Count <= 0) throw new Exception("Không tìm thấy mã thể loại với tên tương ứng!!!");
                this.IDTheLoai = dt.Rows[0]["IDTheLoai"].ToString();
                string updateQuery = " update Sach set IDTheLoai ='" + this.IDTheLoai + "' where MaTaiLieu = '" + MaTaiLieu + "'";
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
            try
            {
                //Kiểm tra xem mã tài liệu nhập vào đã tồn tại hay chưa
                string queryCheck = @"Select * from TaiLieu Where MaTaiLieu = @matailieu";
                if (DataProvider.ExecuteQuery(queryCheck, new object[] { taiLieu.MaTaiLieu }).Rows.Count > 0) throw new Exception("Mã tài liệu đã tồn tại");

                //Thực hiện câu truy vấn thêm tài liệu và cơ sở dữ liệu
                string query = @"INSERT INTO TaiLieu (MaTaiLieu, NhanDe, SoTrang, SoLuong, NamXuatBan, LanXuatBan, SoLanMuon, IDTheLoai, IDNXB, IDNgonNgu, IDTacGia, IDGiaXep, NgayNhap, TheThuc) VALUES 
                                            ( @MaTaiLieu , @NhanDe , @SoTrang , @SoLuong , @NamXB , @LanXB , @SoLanMuon , @IDTheLoai , @IDNXB , @IDNgonNgu , @IDTacGia , @IDGiaXep , @NgayNhap , @TheThuc )";
                if (DataProvider.ExecuteNonQuery(query, new object[] {
                    taiLieu.MaTaiLieu, taiLieu.NhanDe, taiLieu.SoTrang, taiLieu.SoLuong, taiLieu.NamXuatBan, taiLieu.LanXuatBan, 0, taiLieu.IDTheLoai, taiLieu.IDNXB,
                    taiLieu.IDNgonNgu, taiLieu.IDTacGia, taiLieu.IDGiaXep, taiLieu.NgayNhap, taiLieu.TheThuc
                }) == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                throw;
            }

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
                IDTheLoai = N'{6}',
                IDNXB = {7},
                IDNgonNgu = {8},
                IDTacGia = {9},
                IDGiaXep = {10},
                NgayNhap = Convert(datetime,N'{11}'),
                TheThuc = N'{12}'
                Where IDTaiLieu = {13}
                ",
                taiLieu.MaTaiLieu, taiLieu.NhanDe, taiLieu.SoTrang, taiLieu.SoLuong, taiLieu.NamXuatBan, taiLieu.LanXuatBan, taiLieu.IDTheLoai, taiLieu.IDNXB,
                taiLieu.IDNgonNgu, taiLieu.IDTacGia, taiLieu.IDGiaXep, taiLieu.NgayNhap.ToString("yyyy-MM-dd hh:mm:ss"), taiLieu.TheThuc, taiLieu.IDTaiLieu);
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public static bool XoaBo(long id)
        {
            try
            {
                string query = "delete from TaiLieu where IDTaiLieu=" + id;
                if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool ChoMuon(string i)
        {
            try
            {
                string query = "update sach set SoLuong= SoLuong - " + i + ",SoLanMuon = SoLanMuon + 1 where  MaTaiLieu='" + MaTaiLieu + "'";
                if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool TraSach(string i)
        {
            try
            {
                string query = "update sach set SoLuong= SoLuong + " + i + " where  MaTaiLieu='" + MaTaiLieu + "'";
                if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
            }
            catch (Exception)
            {
                throw;
            }

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
                    taiLieu.IDTheLoai = dr["IDTheLoai"].ToString();
                    taiLieu.IDNXB = int.Parse(dr["IDNXB"].ToString());
                    taiLieu.IDNgonNgu = int.Parse(dr["IDNgonNgu"].ToString());
                    taiLieu.IDTacGia = int.Parse(dr["IDTacGia"].ToString());
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
        public static string GetMaTLTheoID(long id)
        {
            try
            {
                DataTable dt = DataProvider.ExecuteQuery("Select MaTaiLieu from TaiLieu Where IDTaiLieu = " + id);
                if (dt.Rows.Count <= 0) throw new Exception("Không tìm thấy Mã tài liệu nào với id đã cho");
                DataRow dr = dt.Rows[0];
                return dr["MaTaiLieu"].ToString();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static int SoLuongCoSan(long id)
        {
            try
            {
                string maTL = TaiLieu.GetMaTLTheoID(id);
                TaiLieu taiLieu = TaiLieu.GetTaiLieuTheoMa(maTL);
                int tongSL = taiLieu.SoLuong;
                int slMuon = 0;
                string query = string.Format(@"Select SUM(SoLuong) from dbo.PhieuMuon
                            Where IDTaiLieu = {0} and TinhTrang > 0", id);
                slMuon = DataProvider.ExecuteScalar(query)==DBNull.Value? 0 : Convert.ToInt32(DataProvider.ExecuteScalar(query));
                return (tongSL - slMuon);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
