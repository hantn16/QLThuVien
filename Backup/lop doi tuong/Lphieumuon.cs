using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;

namespace quanly.doituong
{
    public class Lphieumuon
    {
        string maphieumuon, madocgia, thethucmuon, masach,manhanvien;
        DateTime ngaymuon;
        int soluongmuon;
        public Lphieumuon() { }
        public Lphieumuon(string maphieumuon, string madocgia,string thethucmuon,string masach,string manhanvien,DateTime ngaymuon,int soluongmuon)
        {
            this.soluongmuon = soluongmuon;
            this.ngaymuon = ngaymuon;
            this.maphieumuon = maphieumuon;
            this.madocgia= madocgia;
            this.thethucmuon = thethucmuon;
            this.masach = masach;
            this.manhanvien = manhanvien;
        }
        public void set_maphieumuon(string ma)
        {
            this.maphieumuon = ma;
        }
        public void set_ngaymuon(DateTime ngay)
        {
            this.ngaymuon = ngay;
        }
        public bool taomoi()
        {
            laydulieu dl = new laydulieu();
            if (dl.thucthitruyvan("insert into phieumuon values ('"+maphieumuon+"','"+ madocgia+"',N'"+ thethucmuon+"','"+ngaymuon+"','"+ masach+"','"+manhanvien+"','"+ soluongmuon+"')") == 1)
            {
                L_Ketnoi.HuyKetNoi();
                return true;
            }
            else
            {
                L_Ketnoi.HuyKetNoi();
                return false;
            }
        }
        public bool capnhat()
        {
            laydulieu dl = new laydulieu();
            if (dl.thucthitruyvan("update phieumuon set madocgia='" + madocgia + "',thethucmuon=N'" + thethucmuon + "',ngaymuon='" + ngaymuon + "',masach='" + masach + "',manhanvien='" + manhanvien + "',soluongmuon='"+ soluongmuon+"' where maphieumuon='" + maphieumuon + "'") == 1)
            {
                L_Ketnoi.HuyKetNoi();
                return true;
            }
            else
            {
                L_Ketnoi.HuyKetNoi();
                return false;
            }
        }
        public bool xoabo()
        {
            laydulieu dl = new laydulieu();
            if (dl.thucthitruyvan("delete from phieumuon where maphieumuon='" + maphieumuon + "'") == 1)
            {
                L_Ketnoi.HuyKetNoi();
                return true;
            }
            else
            {
                L_Ketnoi.HuyKetNoi();
                return false;
            }
        }
        public bool giahan()
        {
            laydulieu dl = new laydulieu();
            if (dl.thucthitruyvan("update phieumuon set ngaymuon='" + ngaymuon + "' where maphieumuon='" + maphieumuon + "'") == 1)
            {
                L_Ketnoi.HuyKetNoi();
                return true;
            }
            else
            {
                L_Ketnoi.HuyKetNoi();
                return false;
            }
        }
    }
}