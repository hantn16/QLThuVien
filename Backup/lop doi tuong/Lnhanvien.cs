using System;
using System.Text;
using quanly.lopdulieu;

namespace quanly.doituong
{
    public class Lnhanvien
    {
        string manhanvien, hoten, diachi, quyenhan, tendangnhap, matkhau;
        // Thủ tục khởi tạo
        public Lnhanvien() { }
        public Lnhanvien(string manhanvien, string hoten, string diachi, string quyenhan, string tendangnhap, string matkhau)
        {
            this.manhanvien = manhanvien;
            this.hoten = hoten;
            this.diachi = diachi;
            this.quyenhan = quyenhan;
            this.tendangnhap = tendangnhap;
            this.matkhau = matkhau;
        }
        #region cac thu tuc Set
        public void set_manhanvien(string manhanvien)
        {
            this.manhanvien = manhanvien;
        }
        public void set_hoten(string hoten)
        {
            this.hoten = hoten;
        }
        public void set_diachi(string diachi)
        {
            this.diachi = diachi;
        }
        public void set_quyenhan(string quyenhan)
        {
            this.quyenhan = quyenhan;
        }
        public void set_tendangnhap(string tendangnhap)
        {
            this.tendangnhap = tendangnhap;
        }
        public void set_matkhau(string matkhau)
        {
            this.matkhau = matkhau;
        }
        #endregion
        #region cac thu tuc get
        public string get_manhanvien()
        {
            return manhanvien;
        }
        public string get_hoten()
        {
            return hoten;
        }
        public string get_diachi()
        {
            return diachi;
        }
        public string get_quyenhan()
        {
            return quyenhan;
        }
        public string get_tendangnhap()
        {
            return tendangnhap;
        }
        public string get_matkhau()
        {
            return matkhau;
        }
        #endregion
        #region cac phuong thuc hoat dong
        public bool taomoi()
        {
            laydulieu ld = new laydulieu();
            if (ld.thucthitruyvan(" insert into nhanvien values ('" + manhanvien + "',N'" + hoten + "',N'" + diachi + "',N'" + tendangnhap + "','" + matkhau + "','" + quyenhan + "')") == 1)
            {
                L_Ketnoi.HuyKetNoi();
                return true;
            }
            else return false;
        }
        public bool nangquyen(string quyenmoi)
        {
            this.quyenhan = quyenmoi;
            laydulieu ld = new laydulieu();
            if (ld.thucthitruyvan(" update nhanvien set quyenhan ='" + quyenmoi + "' where manhanvien = '" + manhanvien + "'") == 1)
            {
                L_Ketnoi.HuyKetNoi();
                return true;
            }
            else return false;
        }
        public bool capnhat()
        {
            laydulieu ld = new laydulieu();
            if (ld.thucthitruyvan(" update nhanvien set hoten=N'" + hoten + "',diachi=N'" + diachi + "',tendangnhap=N'" + tendangnhap + "',matkhau=N'" + matkhau + "' where manhanvien='" + manhanvien + "'") == 1)
            {
                L_Ketnoi.HuyKetNoi();
                return true;
            }
            else return false;
        }
        public bool doimatkhau(string moi)
        {
            laydulieu ld = new laydulieu();
            matkhau = moi;
            if (ld.thucthitruyvan(" update nhanvien set matkhau=N'" + moi + "' where manhanvien='" + manhanvien + "'") == 1)
            {
                L_Ketnoi.HuyKetNoi();
                return true;
            }
            else return false;
        }
        public bool xoabo()
        {
            laydulieu ld = new laydulieu();
            if (ld.thucthitruyvan(" delete from nhanvien where manhanvien= '"+ manhanvien+"'") == 1)
            {
                L_Ketnoi.HuyKetNoi();
                return true;
            }
            else return false;
        }
        #endregion
    }
}
