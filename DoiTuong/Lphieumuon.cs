using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;

namespace quanly.doituong
{
    public class Lphieumuon
    {
        string maphieumuon, MaDocGia, TheThucmuon, MaTaiLieu,MaNhanVien;
        DateTime ngaymuon;
        int SoLuongmuon;
        public Lphieumuon() { }
        public Lphieumuon(string maphieumuon, string MaDocGia,string TheThucmuon,string MaTaiLieu,string MaNhanVien,DateTime ngaymuon,int SoLuongmuon)
        {
            this.SoLuongmuon = SoLuongmuon;
            this.ngaymuon = ngaymuon;
            this.maphieumuon = maphieumuon;
            this.MaDocGia= MaDocGia;
            this.TheThucmuon = TheThucmuon;
            this.MaTaiLieu = MaTaiLieu;
            this.MaNhanVien = MaNhanVien;
        }
        public void set_maphieumuon(string ma)
        {
            this.maphieumuon = ma;
        }
        public void set_ngaymuon(DateTime ngay)
        {
            this.ngaymuon = ngay;
        }
        public bool TaoMoi()
        {
            laydulieu dl = new laydulieu();
            if (DataProvider.ExecuteNonQuery("insert into phieumuon values ('"+maphieumuon+"','"+ MaDocGia+"',N'"+ TheThucmuon+"','"+ngaymuon+"','"+ MaTaiLieu+"','"+MaNhanVien+"','"+ SoLuongmuon+"')") == 1)
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
        public bool CapNhat()
        {
            laydulieu dl = new laydulieu();
            if (DataProvider.ExecuteNonQuery("update phieumuon set MaDocGia='" + MaDocGia + "',TheThucmuon=N'" + TheThucmuon + "',ngaymuon='" + ngaymuon + "',MaTaiLieu='" + MaTaiLieu + "',MaNhanVien='" + MaNhanVien + "',SoLuongmuon='"+ SoLuongmuon+"' where maphieumuon='" + maphieumuon + "'") == 1)
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
            if (DataProvider.ExecuteNonQuery("delete from phieumuon where maphieumuon='" + maphieumuon + "'") == 1)
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
        public bool giahan()
        {
            laydulieu dl = new laydulieu();
            if (DataProvider.ExecuteNonQuery("update phieumuon set ngaymuon='" + ngaymuon + "' where maphieumuon='" + maphieumuon + "'") == 1)
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