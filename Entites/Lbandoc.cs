using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;

namespace quanly.doituong
{
    public class Lbandoc
    {
        string madocgia, hoten,makhoa,vitri,diachi;
        DateTime ngaysinh,ngaylapthe;
        public Lbandoc() { }
        public Lbandoc(string madocgia, string hoten, string makhoa, string vitri, string diachi, DateTime ngaysinh, DateTime ngaylapthe)
        {
            this.madocgia = madocgia;
            this.hoten=hoten;
            this.makhoa=makhoa;
            this.vitri=vitri;
            this.diachi=diachi;
            this.ngaysinh=ngaysinh;
            this.ngaylapthe = ngaylapthe;
        }
        public void set_madocgia(string ma)
        { 
            this.madocgia = ma;
        }
#region Các phương thức hoạt động
        public bool taomoi()
        {
            laydulieu dl = new laydulieu();
            if (dl.thucthitruyvan("insert into docgia values ('" + madocgia + "',N'" + hoten + "','"+ ngaysinh+"','"+ makhoa+"',N'"+ vitri+"',N'"+ diachi+"','"+ ngaylapthe+"')") == 1)
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
            if (dl.thucthitruyvan("update docgia set hoten=N'" + hoten + "',ngaysinh='" + ngaysinh + "',makhoa='" + makhoa + "',vitri=N'" + vitri + "',diachi=N'" + diachi + "',ngaylapthe='" + ngaylapthe + "' where madocgia='" + madocgia + "'") == 1)
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
            if (dl.thucthitruyvan("delete from docgia where madocgia='" + madocgia + "'") == 1)
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
        #endregion
    }
}