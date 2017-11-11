using quanlythuvien.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlythuvien.DoiTuong
{
    public class Kho
    {

        public int IDKho { get; set; }
        public string MaKho { get; set; }
        public string TenKho { get; set; }
        public Kho()
        {

        }
        public Kho(string maKho,string tenKho)
        {
            this.MaKho = maKho;
            this.TenKho = tenKho;
        }
        public static List<Kho> GetDanhSachKho()
        {
            List<Kho> list = new List<Kho>();
            DataTable dataTable = DataProvider.ExecuteQuery("Select * from Kho");
            foreach (DataRow dr in dataTable.Rows)
            {
                Kho kho = new Kho()
                {
                    IDKho = (int)dr["IDKho"],
                    MaKho = dr["MaKho"].ToString(),
                    TenKho = dr["TenKho"].ToString()

                };
                list.Add(kho);
            }
            return list;
        }
    }
}
