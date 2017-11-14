using System;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace quanly.doituong
{
    public class NhanVien
    {
        public int IDNhanVien { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string QuyenHan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        // Thủ tục khởi tạo
        public NhanVien() { }
        public NhanVien(int id, string hoTen, string diaChi, string quyenHan, string tenDangNhap, string matKhau)
        {
            this.IDNhanVien = id;
            this.HoTen = hoTen;
            this.DiaChi = diaChi;
            this.QuyenHan = quyenHan;
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
        }

        #region cac phuong thuc hoat dong
        public static bool TaoMoi(NhanVien nv)
        {
            try
            {
                if (DataProvider.ExecuteQuery("Select * from NhanVien where TenDangNhap = N' @user '",new object[] { nv.TenDangNhap}).Rows.Count > 0)
                {
                    throw new Exception("Mã nhân viên đã tồn tại!!!");
                }
                string query = string.Format("insert into NhanVien (TenDangNhap, MatKhau,HoTen,DiaChi,QuyenHan) values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')",nv.TenDangNhap,nv.MatKhau,nv.HoTen,nv.DiaChi,nv.QuyenHan);
                if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static bool CapNhat(NhanVien nv)
        {
            try
            {
                NhanVien nhanVien = GetNhanVienTheoID(nv.IDNhanVien);
                if (nhanVien!=null)
                {
                    string query = string.Format("update NhanVien set HoTen=N'{0}',DiaChi=N'{1}',TenDangNhap=N'{2}',MatKhau=N'{3}',QuyenHan = N'{4}' where IDNhanVien={5}",
                        nv.HoTen,nv.DiaChi,nv.TenDangNhap,nv.MatKhau,nv.QuyenHan,nv.IDNhanVien);
                    int updateResult = DataProvider.ExecuteNonQuery(query);
                    if (updateResult == 1) return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static bool XoaBo(int id)
        {
            try
            {
                if (DataProvider.ExecuteNonQuery(" delete from NhanVien where IDNhanVien= '" + id + "'") == 1) return true; else return false;
            }
            catch (Exception)
            {
                throw;
            }                  
        }
        public static List<NhanVien> GetDSNhanVien()
        {
            try
            {
                List<NhanVien> list = new List<NhanVien>();
                DataTable dt = DataProvider.ExecuteQuery("Select * from NhanVien");
                if (dt.Rows.Count>0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        NhanVien nv = new NhanVien();
                        nv.IDNhanVien = Convert.ToInt32(dr["IDNhanVien"]);
                        nv.TenDangNhap = dr["TenDangNhap"].ToString();
                        nv.HoTen = dr["HoTen"].ToString();
                        nv.DiaChi = dr["DiaChi"].ToString();
                        nv.MatKhau = dr["MatKhau"].ToString();
                        nv.QuyenHan = dr["QuyenHan"].ToString();
                        list.Add(nv);
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static NhanVien GetNhanVienTheoID(int id)
        {
            try
            {
                return GetDSNhanVien().Find(c => c.IDNhanVien == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool DoiMatKhau(int id,string newPass)
        {
            try
            {
                string query = string.Format("Update NhanVien Set MatKhau = N'{0}' Where IDNhanVien = {1}", newPass, id);
                if (DataProvider.ExecuteNonQuery(query) > 0) return true; else return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
