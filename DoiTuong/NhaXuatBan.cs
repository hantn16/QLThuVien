using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;
using System.Data;
using System.Windows.Forms;

namespace quanly.DoiTuong
{
    public class NhaXuatBan
    {
        public int IDNhaXuatBan { get; set; }
        public string TenNhaXuatBan { get; set; }

        public NhaXuatBan() { }
        public NhaXuatBan(int MaNXB, string ten)
        {
            this.IDNhaXuatBan = MaNXB;
            this.TenNhaXuatBan= ten;
        }
        public bool TaoMoi()
        {
            string query = "insert into NhaXuatBan values ('" + IDNhaXuatBan + "','" + TenNhaXuatBan + "')";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool CapNhat()
        {
            string query = "update NhaXuatBan set ten=N'" + TenNhaXuatBan + "' where MaNXB='" + IDNhaXuatBan + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public static List<NhaXuatBan> LayDSNhaXuatBan()
        {
            string query = @"Select * from dbo.NhaXuatBan";
            DataTable dt = DataProvider.ExecuteQuery(query);
            List<NhaXuatBan> list = new List<NhaXuatBan>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new NhaXuatBan() { IDNhaXuatBan = (int)dr["IDNhaXuatBan"], TenNhaXuatBan = dr["TenNhaXuatBan"].ToString() });
                }
            }
            return list;
        }
        public static NhaXuatBan TimNXBTheoID(int id)
        {
            try
            {
                string query = "Select * from NhaXuatBan Where IDNhaXuatBan = " + id;
                DataRow dr = DataProvider.ExecuteQuery(query).Rows[0];
                NhaXuatBan nxb = new NhaXuatBan();
                nxb.IDNhaXuatBan = Convert.ToInt32(dr["IDNhaXuatBan"]);
                nxb.TenNhaXuatBan = dr["TenNhaXuatBan"].ToString();
                return nxb;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}