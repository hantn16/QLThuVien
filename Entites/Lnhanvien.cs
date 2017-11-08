using System;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;
using System.Windows.Forms;

namespace quanly.doituong
{
    public class Lnhanvien
    {
        public string manhanvien { get; set; }
        public string hoten { get; set; }
        public string diachi { get; set; }
        public string quyenhan { get; set; }
        public string tendangnhap { get; set; }
        public string matkhau { get; set; }
        // Thủ tục khởi tạo
        public Lnhanvien() { }
        public Lnhanvien(string maNhanVien, string hoTen, string diaChi, string quyenHan, string tenDangNhap, string matKhau)
        {
            this.manhanvien = maNhanVien;
            this.hoten = hoTen;
            this.diachi = diaChi;
            this.quyenhan = quyenHan;
            this.tendangnhap = tenDangNhap;
            this.matkhau = matKhau;
        }

        #region cac phuong thuc hoat dong
        public bool TaoMoi()
        {
            try
            {
                if (DataProvider.ExecuteQuery("Select * from nhanvien where manhanvien = N''").Rows.Count > 0)
                {
                    throw new Exception("Mã nhân viên đã tồn tại!!!");
                }
                string query = " insert into nhanvien values ('" + manhanvien + "',N'" + hoten + "',N'" + diachi + "',N'" + tendangnhap + "','" + matkhau + "','" + quyenhan + "')";
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
            this.quyenhan = quyenmoi;
            string query = " update nhanvien set quyenhan ='" + quyenmoi + "' where manhanvien = '" + this.manhanvien + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool CapNhat()
        {           
            string query = "update nhanvien set hoten=N'" + hoten + "',diachi=N'" + diachi + "',tendangnhap=N'" + tendangnhap + "',matkhau=N'" + matkhau + "' where manhanvien='" + manhanvien + "'";
            int updateResult = DataProvider.ExecuteNonQuery(query);
            if (updateResult == 1) return true; else return false;
        }
        public bool Doimatkhau(string matKhauMoi)
        {
            laydulieu ld = new laydulieu();
            string query = " update nhanvien set matkhau=N'" + matKhauMoi + "' where manhanvien='" + manhanvien + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool XoaBo()
        {
            if (DataProvider.ExecuteNonQuery(" delete from nhanvien where manhanvien= '"+ manhanvien+"'") == 1)
            {
                return true;
            }
            else return false;
        }
        #endregion
    }
}
