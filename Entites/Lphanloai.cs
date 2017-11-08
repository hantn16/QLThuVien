using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;

namespace quanly.doituong
{
    public class Lphanloai
    {
        string maphanloai, loai;
        public Lphanloai() { }
        public Lphanloai(string maphanloai, string loai)
        {
            this.maphanloai = maphanloai;
            this.loai = loai;
        }
        public bool taomoi()
        {
            laydulieu dl = new laydulieu();
            if (dl.thucthitruyvan("insert into phanloai values ('" + maphanloai + "',N'" + loai + "')") == 1)
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
            if (dl.thucthitruyvan("update phanloai set loai = N'" + loai + "' where maphanloai='" + maphanloai + "'") == 1)
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
