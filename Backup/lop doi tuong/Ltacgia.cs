using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;

namespace quanly.doituong
{
    public class Ltacgia
    {
        string matacgia, tentacgia;
        public Ltacgia() { }
        public Ltacgia(string matacgia, string tentacgia)
        {
            this.matacgia = matacgia;
            this.tentacgia = tentacgia;
        }
        public bool taomoi()
        {
            laydulieu dl = new laydulieu();
            if (dl.thucthitruyvan("insert into tacgia values ('" + matacgia + "',N'" + tentacgia + "')") == 1)
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
            if (dl.thucthitruyvan("update tacgia set tentacgia=N'" + tentacgia + "' where matacgia='" + matacgia + "'") == 1)
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