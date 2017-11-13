using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;
using System.Data;

namespace QLTV.GUI.DoiTuong
{
    public class TacGia
    {
        public int IDTacGia { get; set; }
        public string TenTacGia { get; set; }
        public TacGia() { }
        public TacGia(int IDTacGia, string TenTacGia)
        {
            this.IDTacGia = IDTacGia;
            this.TenTacGia = TenTacGia;
        }
        public bool TaoMoi()
        {
            string query = "insert into TacGia values ('" + IDTacGia + "',N'" + TenTacGia + "')";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool CapNhat()
        {
            string query = "update TacGia set TenTacGia=N'" + TenTacGia + "' where IDTacGia='" + IDTacGia + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public static List<TacGia> LayDSTacGia()
        {
            string query = @"Select * from dbo.TacGia";
            DataTable dt = DataProvider.ExecuteQuery(query);
            List<TacGia> list = new List<TacGia>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TacGia() { IDTacGia = (int)dr["IDTacGia"], TenTacGia = dr["TenTacGia"].ToString() });
                }
            }
            return list;
        }
    }
}