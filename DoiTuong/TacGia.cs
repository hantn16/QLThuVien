using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;

namespace QLTV.GUI.DoiTuong
{
    public class TacGia
    {
        public string MaTacGia { get; set; }
        public string TenTacGia { get; set; }
        //public TacGia() { }
        public TacGia(string MaTacGia, string TenTacGia)
        {
            this.MaTacGia = MaTacGia;
            this.TenTacGia = TenTacGia;
        }
        public bool TaoMoi()
        {
            string query = "insert into TacGia values ('" + MaTacGia + "',N'" + TenTacGia + "')";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool CapNhat()
        {
            string query = "update TacGia set TenTacGia=N'" + TenTacGia + "' where MaTacGia='" + MaTacGia + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
    }
}