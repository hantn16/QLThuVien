using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using System.Data;
namespace quanly.lopdulieu
{
    public class TimKiem
    {
        public TimKiem() { }
        public DataSet coban(string strtk)
        {
            laydulieu dl = new laydulieu();
            return dl.getdata("select sach.MaSach as ' Mã Sách',sach.NhanDe as 'Nhan Đề',TacGia.TenTacGia as 'Tên tác giả',NgonNgu.NgonNgu as 'Ngôn ngữ',sach.SoLuong as 'Sách còn',ViTriluutru.kho, ViTriluutru.ke as 'Kệ',ViTriluutru.ngan as 'Ngăn' from TacGia,TheLoai,NgonNgu,sach,ViTriluutru where sach.MaViTri = ViTriluutru.MaViTri and sach.MaTheLoai = TheLoai.MaTheLoai and TacGia.MaTacGia = sach.MaTacGia and sach.MaNgonNgu = NgonNgu.MaNgonNgu and (sach.NhanDe like N'%" + strtk + "%' or TacGia.TenTacGia like N'%" + strtk + "%' or sach.MaSach='"+ strtk+"')");

        }
        public DataSet nangcao(string strsach, string TacGia, string strTheLoai, string strNgonNgu)
        {
            string strkn = "select sach.MaSach as ' Mã Sách',sach.NhanDe as 'Nhan Đề',TacGia.TenTacGia as 'Tên tác giả',NgonNgu.NgonNgu as 'Ngôn ngữ',sach.SoLuong as 'Sách còn',ViTriluutru.kho, ViTriluutru.ke as 'Kệ',ViTriluutru.ngan as 'Ngăn' from TacGia,TheLoai,NgonNgu,sach,ViTriluutru where sach.MaViTri = ViTriluutru.MaViTri and sach.MaTheLoai = TheLoai.MaTheLoai and TacGia.MaTacGia = sach.MaTacGia and sach.MaNgonNgu = NgonNgu.MaNgonNgu and sach.NhanDe like N'%" + strsach + "%' ";
            if (TacGia != "") strkn = strkn + " and TacGia.TenTacGia like N'%" + TacGia + "%'";
            if (strTheLoai != "") strkn = strkn + " and TheLoai.loai like N'%" + strTheLoai + "%'";
            if (strNgonNgu!= "") strkn = strkn + " and NgonNgu.NgonNgu like N'%" + strNgonNgu+ "%'";
            laydulieu dl = new laydulieu();
            return dl.getdata(strkn);

        }

    }
}
