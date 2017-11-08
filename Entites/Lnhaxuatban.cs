using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;

namespace quanly.doituong
{
    public class Lnhaxuatban
    {
        string manxb, ten;
        public Lnhaxuatban() { }
        public Lnhaxuatban(string manxb, string ten)
        {
            this.manxb = manxb;
            this.ten= ten;
        }
        public bool taomoi()
        {
            laydulieu dl = new laydulieu();
            if (dl.thucthitruyvan("insert into nhaxuatban values ('" + manxb + "','" + ten+ "')") == 1)
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
            if (dl.thucthitruyvan("update nhaxuatban set ten=N'" + ten + "' where manxb='" + manxb + "'") == 1)
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