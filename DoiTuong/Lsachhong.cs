using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;

namespace quanly.doituong
{
    public class Lsachhong
    {
        string MaSachhong,MaSach;
        public Lsachhong() { }
        public Lsachhong(string MaSachhong,string MaSach)
        {
            this.MaSachhong = MaSachhong;
            this.MaSach = MaSach;
        }
        public bool TaoMoi()
        {
            laydulieu dl = new laydulieu();
            if (DataProvider.ExecuteNonQuery("insert into sachhong values ('" + MaSachhong+ "','"+ MaSach+"')") == 1)
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
            if (DataProvider.ExecuteNonQuery("delete from sachhong where MaSachhong='" + MaSachhong+ "'") == 1)
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