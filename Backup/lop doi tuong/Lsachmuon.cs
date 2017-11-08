using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;

namespace quanly.doituong
{
    public class Lsachmuon
    {
        string maphieumuon;
        public Lsachmuon() { }
        public Lsachmuon(string maphieumuon)
        {
            this.maphieumuon = maphieumuon;
        }
        public bool taomoi()
        {
            laydulieu dl = new laydulieu();
            if (dl.thucthitruyvan("insert into sachmuon values ('" + maphieumuon + "')") == 1)
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
            if (dl.thucthitruyvan("delete from sachmuon where maphieumuon='" + maphieumuon + "'") == 1)
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