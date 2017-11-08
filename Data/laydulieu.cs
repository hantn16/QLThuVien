using System;
using quanly.lopdulieu;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace quanly.lopdulieu
{
public class laydulieu
{
	public laydulieu()
	{
        L_Ketnoi.ThietlapketNoi();
	}
    public DataSet getdata(string truyvan)
    {
        try
        {
            DataSet ds = new DataSet(); ;
            SqlCommand cmd = new SqlCommand(truyvan, L_Ketnoi.cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "bang");
            L_Ketnoi.HuyKetNoi();
            return ds;

        }
        catch { return null; }
    }
    public SqlDataReader lay_reader(string truyvan)
    {
        try
        {
            DataSet ds = new DataSet(); ;
            SqlCommand cmd = new SqlCommand(truyvan, L_Ketnoi.cn);
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;

        }
        catch { return null; }
    }
    public int thucthitruyvan(string truyvan)
    {
        try 
        {
            SqlCommand cmd = new SqlCommand(truyvan, L_Ketnoi.cn);
            cmd.ExecuteNonQuery();
            return 1;
        }
        catch
        {
            return 0;
        }
        
    }

}
}