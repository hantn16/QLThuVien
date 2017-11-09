using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;

namespace quanly.DoiTuong
{
    public class BanDoc
    {
        public string MaDocGia { get; set; }
        public string HoTen { get; set; }
        public string MaKhoa { get; set; }
        public string ViTri { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayLapThe { get; set; }

        public BanDoc() { }
        public BanDoc(string MaDocGia, string HoTen, string MaKhoa, string ViTri, string DiaChi, DateTime NgaySinh, DateTime NgayLapThe)
        {
            this.MaDocGia = MaDocGia;
            this.HoTen=HoTen;
            this.MaKhoa=MaKhoa;
            this.ViTri=ViTri;
            this.DiaChi=DiaChi;
            this.NgaySinh=NgaySinh;
            this.NgayLapThe = NgayLapThe;
        }
#region Các phương thức hoạt động
        public bool TaoMoi()
        {
            string query = "insert into DocGia values ('" + MaDocGia + "',N'" + HoTen + "','" + NgaySinh + "','" + MaKhoa + "',N'" + ViTri + "',N'" + DiaChi + "','" + NgayLapThe + "')";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool CapNhat()
        {
            string query = "update DocGia set HoTen=N'" + HoTen + "',NgaySinh='" + NgaySinh + "',MaKhoa='" + MaKhoa + "',ViTri=N'" + ViTri + "',DiaChi=N'" + DiaChi + "',NgayLapThe='" + NgayLapThe + "' where MaDocGia='" + MaDocGia + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        public bool XoaBo()
        {
            string query = "delete from DocGia where MaDocGia='" + MaDocGia + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        #endregion
    }
}