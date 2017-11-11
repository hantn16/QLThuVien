using quanlythuvien.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlythuvien.DoiTuong
{
    public class GiaXep
    {
        public int IDGiaXep { get; set; }
        public string MaGiaXep { get; set; }
        public string TenGiaXep { get; set; }
        public int IDKho { get; set; }
        public string MoTa { get; set; }

        public static List<GiaXep> GetDSGiaXep()
        {
            List<GiaXep> list = new List<GiaXep>();
            DataTable dataTable = DataProvider.ExecuteQuery("Select * from GiaXep");
            foreach (DataRow dr in dataTable.Rows)
            {
                GiaXep giaXep = new GiaXep()
                {
                    IDGiaXep = (int)dr["IDGiaXep"],
                    MaGiaXep = dr["MaGiaXep"].ToString(),
                    TenGiaXep = dr["TenGiaXep"].ToString(),
                    IDKho = (int)dr["IDKho"],
                    MoTa = dr["Mota"].ToString()

                };
                list.Add(giaXep);
            }
            return list;
        }
    }
}
