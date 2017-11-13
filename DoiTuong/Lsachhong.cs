using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;

namespace quanly.doituong
{
    public class TaiLieuhong
    {
        string MaTaiLieuhong,MaTaiLieu;
        public TaiLieuhong() { }
        public TaiLieuhong(string MaTaiLieuhong,string MaTaiLieu)
        {
            this.MaTaiLieuhong = MaTaiLieuhong;
            this.MaTaiLieu = MaTaiLieu;
        }
        public bool TaoMoi()
        {
            laydulieu dl = new laydulieu();
            if (DataProvider.ExecuteNonQuery("insert into sachhong values ('" + MaTaiLieuhong+ "','"+ MaTaiLieu+"')") == 1)
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
            if (DataProvider.ExecuteNonQuery("delete from sachhong where MaTaiLieuhong='" + MaTaiLieuhong+ "'") == 1)
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