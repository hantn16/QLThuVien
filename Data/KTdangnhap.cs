using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using quanly.lopdulieu;
using quanly.doituong;

namespace quanly.lopdulieu
{
    public class KTdangnhap
    {
        
        private DataSet ds;
        public static string strquyenhan = "", strnguoidung="",strhoten="",strdiachi="",strmanhanvien="",strmatkhau="";
        public bool kt_dangnhap(string ten, string matkhau, string tenserver, string matkhauserver)
        {
            Lnhanvien nv = new Lnhanvien();
            try
           {
                if (tenserver != "")
                {
                    L_Ketnoi.strChuoiKN = L_Ketnoi.strChuoiKN + "; server= " + tenserver;
                    if (matkhauserver != "") L_Ketnoi.strChuoiKN = L_Ketnoi.strChuoiKN + " ; Password = " + matkhauserver;
                }
                L_Ketnoi.ThietlapketNoi();
                laydulieu dl = new laydulieu();
                ds = dl.getdata("select * from nhanvien where matkhau = '" + matkhau + "' and tendangnhap = '" + ten + "'");
                if (ds.Tables[0].Rows.Count == 0) { L_Ketnoi.HuyKetNoi(); return false; }
                else
                {
                    strmanhanvien= ds.Tables[0].Rows[0]["manhanvien"].ToString();
                    strhoten= ds.Tables[0].Rows[0]["hoten"].ToString();
                    strdiachi =  ds.Tables[0].Rows[0]["diachi"].ToString();
                    strquyenhan =  ds.Tables[0].Rows[0]["quyenhan"].ToString();
                    strnguoidung = ds.Tables[0].Rows[0]["tendangnhap"].ToString();
                    strmatkhau = ds.Tables[0].Rows[0]["matkhau"].ToString();
                    L_Ketnoi.HuyKetNoi();
                    return true;
                }
            }
           catch { return false; }
        }
    }
}
