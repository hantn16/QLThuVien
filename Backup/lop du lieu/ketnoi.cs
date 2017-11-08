using System;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for L_Ketnoi
/// </summary>
/// 
namespace quanly.lopdulieu
{
    public class L_Ketnoi
    {
        public static string strChuoiKN = "Initial Catalog=quanlythuvien;Integrated Security=True";
        static public SqlConnection cn;
        public static string Chuoiketnoi()
        {
            return strChuoiKN;
        }

        public static void ThietlapketNoi()
        {
            try
            {
                cn = new SqlConnection(strChuoiKN);
                cn.Open();
            }
            catch { };
        }
        public static void HuyKetNoi()
        {
            cn.Close();
        }

    }
}