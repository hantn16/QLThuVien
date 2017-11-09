using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;

namespace quanly.DoiTuong
{
    public class NgonNgu
    {
        public string MaNgonNgu { get; set; }
        public string TenNgonNgu { get; set; }
        public NgonNgu() { }
        public NgonNgu(string MaNgonNgu, string tenNgonNgu)
        {
            this.MaNgonNgu = MaNgonNgu;
            this.TenNgonNgu = tenNgonNgu;
        }
        public bool TaoMoi()
        {
            if (DataProvider.ExecuteNonQuery("insert into NgonNgu values ('" + MaNgonNgu + "','" + TenNgonNgu + "')") == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CapNhat()
        {
            if (DataProvider.ExecuteNonQuery("update dbo.NgonNgu set TenNgonNgu=N'" + TenNgonNgu + "' where MaNgonNgu='" + MaNgonNgu + "'") == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool XoaBo()
        {
            if (DataProvider.ExecuteNonQuery("delete from dbo.NgonNgu Where MaNgonNgu='" + MaNgonNgu + "'") == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
    }
}