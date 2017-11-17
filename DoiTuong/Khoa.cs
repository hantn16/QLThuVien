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
        /// <summary>
        /// Hàm get danh sách khoa
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Hàm lấy ra Khoa theo id truyền vào
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Khoa GetKhoaTheoID(int id)
        {
            try
            {
                return Khoa.GetDSKhoa().Find(c => c.IDKhoa == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
