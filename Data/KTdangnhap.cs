using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using quanly.lopdulieu;
using quanly.doituong;
using quanlythuvien.Data;

namespace quanly.lopdulieu
{
    public class KTdangnhap
    {
        
        public static string strquyenhan = "", strnguoidung="",strhoten="",strdiachi="",strmanhanvien="",strmatkhau="";
        public bool kt_dangnhap(string ten, string matkhau)
        {
            Lnhanvien nv = new Lnhanvien();
            try
           {
                //if (tenserver != "")
                //{
                //    L_Ketnoi.strChuoiKN = L_Ketnoi.strChuoiKN + "; server= " + tenserver;
                //    if (matkhauserver != "") L_Ketnoi.strChuoiKN = L_Ketnoi.strChuoiKN + " ; Password = " + matkhauserver;
                //}
                //L_Ketnoi.ThietlapketNoi();
                //laydulieu dl = new laydulieu();
                string query = "select * from nhanvien where matkhau = '" + matkhau + "' and tendangnhap = '" + ten + "'";
                DataTable dt = DataProvider.ExecuteQuery(query);
                if (dt.Rows.Count == 0) { return false; }
                else
                {
                    strmanhanvien= dt.Rows[0]["manhanvien"].ToString();
                    strhoten= dt.Rows[0]["hoten"].ToString();
                    strdiachi =  dt.Rows[0]["diachi"].ToString();
                    strquyenhan =  dt.Rows[0]["quyenhan"].ToString();
                    strnguoidung = dt.Rows[0]["tendangnhap"].ToString();
                    strmatkhau = dt.Rows[0]["matkhau"].ToString();
                    return true;
                }
            }
           catch { return false; }
        }
    }
}
