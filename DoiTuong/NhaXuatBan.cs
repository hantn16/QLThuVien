using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;

namespace quanly.DoiTuong
{
    public class NhaXuatBan
    {
        public string MaNXB { get; set; }
        public string TenNXB { get; set; }

        public NhaXuatBan() { }
        public NhaXuatBan(string MaNXB, string ten)
        {
            this.MaNXB = MaNXB;
            this.TenNXB= ten;
        }
        public bool TaoMoi()
        {
            string query = "insert into NhaXuatBan values ('" + MaNXB + "','" + TenNXB + "')";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool CapNhat()
        {
            string query = "update NhaXuatBan set ten=N'" + TenNXB + "' where MaNXB='" + MaNXB + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
    }
}