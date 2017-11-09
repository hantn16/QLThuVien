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
    public class Lsach
    {
        public string MaSach { get; set; }
        public string TheThuc { get; set; }
        public string NhanDe { get; set; }
        public string MaTheLoai { get; set; }
        public string MaNXB { get; set; }
        public string MaNgonNgu { get; set; }
        public string MaTacGia { get; set; }
        public string MaViTri { get; set; }
        public int SoTrang { get; set; }
        public int SoLuong { get; set; }
        public int LanXuatBan { get; set; }
        public int SoLanMuon { get; set; }
        public DateTime NamXuatBan { get; set; }
        public DateTime NgayNhap { get; set; }

        public Lsach() { }
       
        #region các thủ tục lấy mã
        public int LayMaTheLoai(string tam)
        {
            try
            {
                string query = "select MaTheLoai from TheLoai where TenTheLoai = N'" + tam + "'";
                DataTable dt = DataProvider.ExecuteQuery(query);
                this.MaTheLoai = dt.Rows[0][0].ToString();

                if (String.IsNullOrEmpty(this.MaTheLoai)) return 0; else return 1;
            }
            catch{ return 0;}
        }
        public int LayMaTacGia(string tam)
        {
            try
            {
                string query = "select MaTacGia from TacGia where TenTacGia=N'" + tam + "'";
                DataTable dt = DataProvider.ExecuteQuery(query);
                if (dt.Rows.Count>0)
                {
                    this.MaTacGia = dt.Rows[0][0].ToString();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch { return 0; }
        }
        public int LayMaNgonNgu(string tam)
        {
            try
            {
                string query = "select MaNgonNgu from NgonNgu where TenNgonNgu= '" + tam + "'";
                DataTable dt = DataProvider.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    this.MaNgonNgu = dt.Rows[0][0].ToString();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch { return 0; }
        }
        public int LayMaNXB(string tam)

        {
            try
            {
                string query = "select MaNXB from NhaXuatBan where TenNXB=N'" + tam + "'";
                DataTable dt = DataProvider.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    this.MaNXB = dt.Rows[0][0].ToString();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch { return 0; }
        }
        public int LayMaViTri(string kho,string ke, string ngan)
        {
            try
            {
                string query = "select MaViTri from ViTriluutru where Kho=N'" + kho + "' and Ke=N'" + ke + "' and Ngan=N'" + ngan + "'";
                DataTable dt = DataProvider.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    this.MaViTri = dt.Rows[0][0].ToString();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch { return 0; }
        }
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
                string updateQuery = " update Sach set MaTheLoai ='" + this.MaTheLoai + "' where MaSach = '" + MaSach + "'";
                if (DataProvider.ExecuteNonQuery(updateQuery) == 1) return true; else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        //Chưa cập nhật xong
        public bool TaoMoi()
        {
            string query = "insert into sach values('" + MaSach + "',N'" + NhanDe + "','" + SoTrang + "','" + SoLuong + "','" + NamXuatBan + "','" + LanXuatBan + "','" + SoLanMuon + "','" + MaTheLoai + "','" + MaNXB + "','" + MaNgonNgu + "','" + MaTacGia + "','" + MaViTri + "','" + NgayNhap + "',N'" + TheThuc + "')";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool CapNhat()
        {
            string query = "update sach set NhanDe=N'" + NhanDe + "',SoTrang='" + SoTrang + "',SoLuong='" + SoLuong + "',NamXuatBan='" + NamXuatBan + "',LanXuatBan='" + LanXuatBan + "',SoLanMuon='" + SoLanMuon + "',MaTheLoai='" + MaTheLoai + "',MaNXB='" + MaNXB + "',MaNgonNgu='" + MaNgonNgu + "',MaTacGia='" + MaTacGia + "',MaViTri='" + MaViTri + "', NgayNhap='" + NgayNhap + "', TheThuc=N'" + TheThuc + "' where  MaSach='" + MaSach + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool XoaBo()
        {
            string query = "delete from sach where MaSach='" + MaSach + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool ChoMuon(string i)
        {
            string query = "update sach set SoLuong= SoLuong - " + i + ",SoLanMuon = SoLanMuon + 1 where  MaSach='" + MaSach + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool TraSach(string i)
        {
            string query = "update sach set SoLuong= SoLuong + " + i + " where  MaSach='" + MaSach + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        #endregion
    }
}
