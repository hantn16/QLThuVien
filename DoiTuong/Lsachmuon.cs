using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;

namespace quanly.doituong
{
    public class TaiLieumuon
    {
        string maphieumuon;
        public TaiLieumuon() { }
        public TaiLieumuon(string maphieumuon)
        {
            this.maphieumuon = maphieumuon;
        }
        public bool TaoMoi()
        {
            laydulieu dl = new laydulieu();
            if (DataProvider.ExecuteNonQuery("insert into sachmuon values ('" + maphieumuon + "')") == 1)
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
        public bool XoaBo()
        {
            laydulieu dl = new laydulieu();
            if (DataProvider.ExecuteNonQuery("delete from sachmuon where maphieumuon='" + maphieumuon + "'") == 1)
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