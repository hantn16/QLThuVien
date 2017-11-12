using quanlythuvien.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlythuvien.DoiTuong
{
    public class Khoa
    {
        public int IDKhoa { get; set; }
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }

        public static List<Khoa> GetDSKhoa()
        {
            try
            {
                string query = "Select * from Khoa";
                DataTable dt = DataProvider.ExecuteQuery(query);
                List<Khoa> list = new List<Khoa>();
                if (dt.Rows.Count>0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        Khoa item = new Khoa();
                        item.IDKhoa = Convert.ToInt32(dr["IDKhoa"]);
                        item.MaKhoa = dr["MaKhoa"].ToString();
                        item.TenKhoa = dr["TenKhoa"].ToString();
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
    }
}
