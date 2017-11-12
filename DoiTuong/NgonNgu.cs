using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;
using System.Data;

namespace quanly.DoiTuong
{
    public class NgonNgu
    {
        public int IDNgonNgu { get; set; }
        public string TenNgonNgu { get; set; }
        public NgonNgu() { }
        public NgonNgu(int IDNgonNgu, string tenNgonNgu)
        {
            this.IDNgonNgu = IDNgonNgu;
            this.TenNgonNgu = tenNgonNgu;
        }
        public bool TaoMoi()
        {
            if (DataProvider.ExecuteNonQuery("insert into NgonNgu values ('" + IDNgonNgu + "','" + TenNgonNgu + "')") == 1)
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
            if (DataProvider.ExecuteNonQuery("update dbo.NgonNgu set TenNgonNgu=N'" + TenNgonNgu + "' where IDNgonNgu='" + IDNgonNgu + "'") == 1)
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
            if (DataProvider.ExecuteNonQuery("delete from dbo.NgonNgu Where IDNgonNgu='" + IDNgonNgu + "'") == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static List<NgonNgu> LayDSNgonNgu()
        {
            string query = @"Select * from dbo.NgonNgu";
            DataTable dt = DataProvider.ExecuteQuery(query);
            List<NgonNgu> list = new List<NgonNgu>();
            if (dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new NgonNgu() { IDNgonNgu = (int)dr["IDNgonNgu"], TenNgonNgu = dr["TenNgonNgu"].ToString() });
                }
            }
            return list;
        }
       
    }
}