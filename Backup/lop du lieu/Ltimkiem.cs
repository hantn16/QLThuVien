using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using System.Data;
namespace quanly.lopdulieu
{
    public class Ltimkiem
    {
        public Ltimkiem() { }
        public DataSet coban(string strtk)
        {
            laydulieu dl = new laydulieu();
            return dl.getdata("select sach.masach as ' Mã Sách',sach.nhande as 'Nhan Đề',tacgia.tentacgia as 'Tên tác giả',ngonngu.ngonngu as 'Ngôn ngữ',sach.soluong as 'Sách còn',vitriluutru.kho, vitriluutru.ke as 'Kệ',vitriluutru.ngan as 'Ngăn' from tacgia,phanloai,ngonngu,sach,vitriluutru where sach.mavitri = vitriluutru.mavitri and sach.maphanloai = phanloai.maphanloai and tacgia.matacgia = sach.matacgia and sach.mangonngu = ngonngu.mangonngu and (sach.nhande like N'%" + strtk + "%' or tacgia.tentacgia like N'%" + strtk + "%' or sach.masach='"+ strtk+"')");

        }
        public DataSet nangcao(string strsach, string tacgia, string strphanloai, string strngonngu)
        {
            string strkn = "select sach.masach as ' Mã Sách',sach.nhande as 'Nhan Đề',tacgia.tentacgia as 'Tên tác giả',ngonngu.ngonngu as 'Ngôn ngữ',sach.soluong as 'Sách còn',vitriluutru.kho, vitriluutru.ke as 'Kệ',vitriluutru.ngan as 'Ngăn' from tacgia,phanloai,ngonngu,sach,vitriluutru where sach.mavitri = vitriluutru.mavitri and sach.maphanloai = phanloai.maphanloai and tacgia.matacgia = sach.matacgia and sach.mangonngu = ngonngu.mangonngu and sach.nhande like N'%" + strsach + "%' ";
            if (tacgia != "") strkn = strkn + " and tacgia.tentacgia like N'%" + tacgia + "%'";
            if (strphanloai != "") strkn = strkn + " and phanloai.loai like N'%" + strphanloai + "%'";
            if (strngonngu!= "") strkn = strkn + " and ngonngu.ngonngu like N'%" + strngonngu+ "%'";
            laydulieu dl = new laydulieu();
            return dl.getdata(strkn);

        }

    }
}
