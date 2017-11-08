using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using System.Data.SqlClient;

namespace quanly.doituong
{
    public class Lsach
    {
        string masach,thethuc, nhande,maphanloai="",manxb="",mangonngu="",matacgia="",mavitri="";
        int sotrang,soluong,lanxb,solanmuon;
        DateTime namxb,ngaynhap;
        public Lsach() { }
        #region các thủ tục SET
        public void set_masach(string masach)
        {
            this.masach = masach;
        }
        public void set_nhande(string nhande)
        {
            this.nhande = nhande;
        }
        public void set_maphanloai(string maphanloai)
        {
            this.maphanloai= maphanloai;
        }
        public void set_manxb(string manxb)
        {
            this.manxb= manxb;
        }
        public void set_mangonngu(string mangonngu)
        {
            this.mangonngu = mangonngu;
        }
        public void set_matacgia(string matacgia)
        {
            this.matacgia = matacgia;
        }
        public void set_mavitri(string mavitri)
        {
            this.mavitri = mavitri;
        }
        public void set_sotrang(int sotrang)
        {
            this.sotrang = sotrang;
        }
        public void set_soluong(int soluong)
        {
            this.soluong= soluong;
        }
        public void set_lanxb(int lanxb)
        {
            this.lanxb= lanxb;
        }
        public void set_thethuc(string thethuc)
        {
            this.thethuc = thethuc;
        }
        public void set_solanmuon(int solanmuon)
        {
            this.solanmuon= solanmuon;
        }
        public void set_namxb(DateTime namxb)
        {
            this.namxb= namxb;
        }
        public void set_ngaynhap(DateTime ngaynhap)
        {
            this.ngaynhap = ngaynhap;
        }
        #endregion
       
        #region các thủ tục lấy mã
        public int laymaphanloai(string tam)
        {
            try
            {
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select maphanloai from phanloai where loai = N'"+ tam+"'");
                while (dr.Read())
                    this.maphanloai = dr[0].ToString();

                if (this.maphanloai=="")
                {
                    L_Ketnoi.HuyKetNoi();
                    return 0;
                }
                else
                {
                    L_Ketnoi.HuyKetNoi();
                    return 1;
                }
            }
            catch{ return 0;}
        }
        public int laymatacgia(string tam)
        {
            try
            {
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select matacgia from tacgia where tentacgia=N'"+ tam+"'");
                while (dr.Read())
                    this.matacgia = dr[0].ToString();
                if (this.matacgia =="" )
                {
                    L_Ketnoi.HuyKetNoi();
                    return 0;
                }
                else
                {
                    L_Ketnoi.HuyKetNoi();
                    return 1;
                }
            }
            catch { return 0; }
        }
        public int laymangonngu(string tam)
        {
            try
            {
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select mangonngu from ngonngu where ngonngu= '" + tam +"'");
                while (dr.Read())
                    this.mangonngu = dr[0].ToString();
                if (this.mangonngu == "")
                {
                    L_Ketnoi.HuyKetNoi();
                    return 0;
                }
                else
                {
                    L_Ketnoi.HuyKetNoi();
                    return 1;
                }
            }
            catch { return 0; }
        }
        public int laymanhaxuatban(string tam)

        {
            try
            {
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select manxb from nhaxuatban where ten=N'"+ tam+"'");
                while (dr.Read())
                    this.manxb = dr[0].ToString();
                if (this.manxb == "")
                {
                    L_Ketnoi.HuyKetNoi();
                    return 0;
                }
                else
                {
                    L_Ketnoi.HuyKetNoi();
                    return 1;
                }
            }
            catch { return 0; }
        }
        public int laymavitri(string kho,string ke, string ngan)
        {
            try
            {
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select mavitri from vitriluutru where kho=N'"+ kho+"' and ke=N'"+ke+"' and ngan=N'"+ ngan+"'");
                while (dr.Read())
                    this.mavitri = dr[0].ToString();
                if (this.mavitri == "")
                {
                    L_Ketnoi.HuyKetNoi();
                    return 0;
                }
                else
                {
                    L_Ketnoi.HuyKetNoi();
                    return 1;
                }
            }
            catch { return 0; }
        }
        #endregion
        #region các phương thức hoạt động
        public bool phanloai(string loai)
        {
            laydulieu dl = new laydulieu();
            SqlDataReader dr = dl.lay_reader("select maphanloai from phanloai where loai=N'" + loai + "'");
            while (dr.Read())
                this.maphanloai = dr[0].ToString();
            L_Ketnoi.HuyKetNoi();
            laydulieu ld1 = new laydulieu();
            if (ld1.thucthitruyvan(" update sach set maphanloai ='" + this.maphanloai + "' where masach = '" + masach + "'") == 1)
            {
                L_Ketnoi.HuyKetNoi();
                return true;
            }
            else return false;
        }
        public bool taomoi()
        {
            laydulieu dl = new laydulieu();
            if (dl.thucthitruyvan("insert into sach values('" + masach + "',N'" + nhande + "','" + sotrang + "','" + soluong + "','" + namxb + "','" + lanxb + "','" + solanmuon + "','" + maphanloai + "','" + manxb + "','" + mangonngu + "','" + matacgia + "','" + mavitri + "','" + ngaynhap + "',N'"+ thethuc+"')") == 1)
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
            if (dl.thucthitruyvan("update sach set nhande=N'" + nhande + "',sotrang='" + sotrang + "',soluong='" + soluong + "',namxb='" + namxb + "',lanxb='" + lanxb + "',solanmuon='" + solanmuon + "',maphanloai='" + maphanloai + "',manxb='" + manxb + "',mangonngu='" + mangonngu + "',matacgia='" + matacgia + "',mavitri='" + mavitri + "', ngaynhap='" + ngaynhap + "', thethuc=N'"+ thethuc+"' where  masach='" + masach + "'") == 1)
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
            if (dl.thucthitruyvan("delete from sach where masach='"+ masach+"'") == 1)
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
        public bool chomuon(string i)
        {
            laydulieu dl = new laydulieu();
            if (dl.thucthitruyvan("update sach set soluong= soluong - " + i + ",solanmuon = solanmuon + 1 where  masach='" + masach + "'") == 1)
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
        public bool trasach(string i)
        {
            laydulieu dl = new laydulieu();
            if (dl.thucthitruyvan("update sach set soluong= soluong + " + i + " where  masach='" + masach + "'") == 1)
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
