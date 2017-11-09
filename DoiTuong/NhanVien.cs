using System;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;
using System.Windows.Forms;

namespace quanly.doituong
{
    public class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string QuyenHan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        // Thủ tục khởi tạo
        public NhanVien() { }
        public NhanVien(string maNhanVien, string hoTen, string diaChi, string quyenHan, string tenDangNhap, string matKhau)
        {
            this.MaNhanVien = maNhanVien;
            this.HoTen = hoTen;
            this.DiaChi = diaChi;
            this.QuyenHan = quyenHan;
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
        }

        #region cac phuong thuc hoat dong
        public bool TaoMoi()
        {
            try
            {
                if (DataProvider.ExecuteQuery("Select * from NhanVien where MaNhanVien = N''").Rows.Count > 0)
                {
                    throw new Exception("Mã nhân viên đã tồn tại!!!");
                }
                string query = " insert into NhanVien values ('" + MaNhanVien + "',N'" + HoTen + "',N'" + DiaChi + "',N'" + TenDangNhap + "','" + MatKhau + "','" + QuyenHan + "')";
                if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        public bool NangQuyen(string quyenmoi)
        {
            this.QuyenHan = quyenmoi;
            string query = " update NhanVien set QuyenHan ='" + quyenmoi + "' where MaNhanVien = '" + this.MaNhanVien + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool CapNhat()
        {           
            string query = "update NhanVien set HoTen=N'" + HoTen + "',DiaChi=N'" + DiaChi + "',TenDangNhap=N'" + TenDangNhap + "',MatKhau=N'" + MatKhau + "' where MaNhanVien='" + MaNhanVien + "'";
            int updateResult = DataProvider.ExecuteNonQuery(query);
            if (updateResult == 1) return true; else return false;
        }
        public bool DoiMatKhau(string matKhauMoi)
        {
            laydulieu ld = new laydulieu();
            string query = " update NhanVien set MatKhau=N'" + matKhauMoi + "' where MaNhanVien='" + MaNhanVien + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool XoaBo()
        {
            if (DataProvider.ExecuteNonQuery(" delete from NhanVien where MaNhanVien= '"+ MaNhanVien+"'") == 1)
            {
                return true;
            }
            else return false;
        }
        #endregion
    }
}
