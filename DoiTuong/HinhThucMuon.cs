using quanlythuvien.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlythuvien.DoiTuong
{
    public class HinhThucMuon
    {
        public int IDHinhThucMuon { get; set; }
        public string TenHinhThucMuon { get; set; }


        public static bool TaoMoi(HinhThucMuon item)
        {
            try
            {
                string query = string.Format("Insert into HinhThucMuon (TenHinhThucMuon) values (N'{0}')", item.TenHinhThucMuon);
                if (DataProvider.ExecuteNonQuery(query)==1) return true; return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<HinhThucMuon> GetDSHinhThucMuon()
        {
            try
            {
                List<HinhThucMuon> list = new List<HinhThucMuon>();
                DataTable dt = DataProvider.ExecuteQuery("Select * from HinhThucMuon");
                if (dt.Rows.Count>0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        HinhThucMuon item = new HinhThucMuon();
                        item.IDHinhThucMuon = Convert.ToInt32(dr["IDHinhThucMuon"]);
                        item.TenHinhThucMuon = dr["TenHinhThucMuon"].ToString();
                        list.Add(item);
                    }
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static HinhThucMuon GetHinhThucMuonTheoID(int id)
        {
            try
            {
                return GetDSHinhThucMuon().Find(c => c.IDHinhThucMuon == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool CapNhat(HinhThucMuon item)
        {
            try
            {
                HinhThucMuon ht = GetHinhThucMuonTheoID(item.IDHinhThucMuon);
                if (ht!=null)
                {
                    string query = "update HinhThucMuon set TenHinhThucMuon=N'" + item.TenHinhThucMuon + "' where IDHinhThucMuon=" + item.IDHinhThucMuon;
                    if (DataProvider.ExecuteNonQuery(query) == 1) return true; 
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
                string query = "Delete From HinhThucMuon Where IDHinhThucMuon = " + id;
                if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
