using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
namespace quanly.doituong
{
    public class Lvitriluutru
    {
        string mavitri, kho, ke, ngan;
        public Lvitriluutru() { }
        public Lvitriluutru(string kho,string mavitri,string ke,string ngan)
        {
            this.ke = ke;
            this.kho = kho;
            this.ngan = ngan;
            this.mavitri = mavitri;
        }
        public void set_mavitri(string ma)
        {
            this.mavitri = ma;
        }
        public bool taomoi()
        {
            laydulieu dl = new laydulieu();
            if (dl.thucthitruyvan("insert into vitriluutru values ('" + mavitri + "','" + kho + "','" + ke + "','" + ngan + "')") == 1)
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
            if (dl.thucthitruyvan("update vitriluutru set kho='" + kho + "',ke='" + ke + "',ngan='" + ngan + "' where mavitri='" + mavitri + "'") == 1)
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
            if (dl.thucthitruyvan("delete from vitriluutru where mavitri='"+ mavitri+"'") == 1)
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
