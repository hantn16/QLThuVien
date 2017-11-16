using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using quanly.lopdulieu;
using quanly.doituong;
using quanlythuvien.Data;
using System.Windows.Forms;

namespace quanly.lopdulieu
{
    /// <summary>
    /// Class chứa thông tin của nhân viên đang đăng nhập
    /// </summary>
    public class DangNhap
    {

        public static string strQuyenHan = "", strnguoidung="",strHoTen="",strDiaChi="",strMatKhau="";
        public static int idNhanVien = 0;

        /// <summary>
        /// Hàm kiểm tra user, password nhập vào có hợp lệ không?
        /// </summary>
        /// <param name="ten">Tên đăng nhập truyền vào</param>
        /// <param name="MatKhau">Mật khẩu truyền vào</param>
        /// <returns></returns>
        public bool kt_dangnhap(string ten, string MatKhau)
        {
            NhanVien nv = new NhanVien();
            try
           {
                string query = "select * from NhanVien where MatKhau = '" + MatKhau + "' and TenDangNhap = '" + ten + "'";
                DataTable dt = DataProvider.ExecuteQuery(query);
                if (dt.Rows.Count == 0) { return false; }
                else
                {
                    idNhanVien = Convert.ToInt32(dt.Rows[0]["IDNhanVien"]);
                    strHoTen= dt.Rows[0]["HoTen"].ToString();
                    strDiaChi =  dt.Rows[0]["DiaChi"].ToString();
                    strQuyenHan =  dt.Rows[0]["QuyenHan"].ToString();
                    strnguoidung = dt.Rows[0]["TenDangNhap"].ToString();
                    strMatKhau = dt.Rows[0]["MatKhau"].ToString();
                    return true;
                }
            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
