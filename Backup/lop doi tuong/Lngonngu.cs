using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;

namespace quanly.doituong
{
    public class Lngonngu
    {
        string mangonngu, ngonngu;
        public Lngonngu() { }
        public Lngonngu(string mangonngu, string ngonngu)
        {
            this.mangonngu = mangonngu;
            this.ngonngu = ngonngu;
        }
        public bool taomoi()
        {
            laydulieu dl = new laydulieu();
            if (dl.thucthitruyvan("insert into ngonngu values ('" + mangonngu + "','" + ngonngu + "')") == 1)
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
            if (dl.thucthitruyvan("update ngonngu set ngonngu=N'" + ngonngu + "' where mangonngu='" + mangonngu + "'") == 1)
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