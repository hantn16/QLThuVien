using quanlythuvien.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlythuvien.DoiTuong
{
    public class Lop
    {
        public int IDLop { get; set; }
        public string TenLop { get; set; }
        public int IDKhoa { get; set; }
        public Lop() { }
        public Lop(int id, string tenLop, int idKhoa)
        {
            this.IDLop = id; this.TenLop = tenLop; this.IDKhoa = idKhoa;
        }
        public static DataTable LayDSLop()
        {
            return DataProvider.ExecuteQuery("Select * from Lop");
        }
        public static bool XoaBo(int id)
        {
            try
            {
                if (DataProvider.ExecuteNonQuery(string.Format("Delete from Lop where IDLop = {0}",id))>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception)
            {

                return false;
            }
        }
        public static bool CapNhat(Lop lop)
        {
            try
            {
                Lop updatedLop = Lop.GetLopTheoID(lop.IDLop);
                if (updatedLop!=null)
                {
                    string query = string.Format("Update Lop Set TenLop = N'{0}', IDKhoa= {1} Where IDLop = {2}", lop.TenLop, lop.IDKhoa,lop.IDLop);
                    if (DataProvider.ExecuteNonQuery(query)>0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool ThemMoi(Lop lop)
        {
            try
            {
                if (DataProvider.ExecuteQuery(string.Format("Select * from Lop Where TenLop = N'{0}'", lop.TenLop)).Rows.Count > 0)
                {
                    throw new Exception("Tên lớp đã tồn tại!!!");
                }
                else
                {
                    string query = string.Format("Insert into Lop (TenLop,IDKhoa) values (N'{0}',{1})", lop.TenLop, lop.IDKhoa);
                    return (DataProvider.ExecuteNonQuery(query) > 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        public static Lop GetLopTheoID(int id)
        {
            try
            {

                DataTable dt = DataProvider.ExecuteQuery(string.Format("Select * from Lop where IDLop = {0}", id));
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    Lop lop = new Lop();
                    lop.IDLop = Convert.ToInt32(dr["IDLop"]);
                    lop.TenLop = dr["TenLop"].ToString();
                    lop.IDKhoa = Convert.ToInt32(dr["IDKhoa"]);
                    return lop;
                }
                else return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
