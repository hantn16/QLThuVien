using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using System.Data;
using quanlythuvien.Data;
using System.Windows.Forms;

namespace quanly.lopdulieu
{
    public class TimKiem
    {
        public TimKiem() { }
        public DataTable TKCoBan(string strtk)
        {
            //string query = string.Format("EXEC dbo.TimKiemTaiLieuCoBan N'{0}'",strtk);
            string query2 = string.Format(@"Select tl.IDTaiLieu as 'ID',tl.MaTaiLieu as 'Mã Tài Liệu',tl.NhanDe as 'Nhan Đề', tg.TenTacGia as 'Tên Tác Giả',nn.TenNgonNgu as 'Ngôn ngữ',tl.SoLuong as 'Sách còn', gx.MaGiaXep as 'Giá xếp',k.MaKho as 'Kho'
	                        from dbo.TaiLieu tl inner join dbo.TacGia tg on tl.IDTacGia = tg.IDTacGia
						                        inner join dbo.NgonNgu nn on tl.IDNgonNgu = nn.IDNgonNgu
						                        inner join dbo.NhaXuatBan nxb on tl.IDNXB = nxb.IDNhaXuatBan
						                        inner join dbo.TheLoai th on tl.IDTheLoai = th.IDTheLoai
						                        left join dbo.GiaXep gx on tl.IDGiaXep = gx.IdGiaXep
						                        inner join dbo.Kho k on gx.IdKho = k.IdKho
	                        WHERE tl.MaTaiLieu like N'%{0}%'
	                        OR tl.NhanDe like N'%{0}%'
	                        OR tg.TenTacGia like N'%{0}%'
	                        OR th.TenTheLoai like N'%{0}%'", strtk);
            DataTable dt = DataProvider.ExecuteQuery(query2);
            return dt;

        }
        public DataTable TKNangCao(string strtk,string keyType = "TatCa", int keyValue = 0)
        {
            try
            {
                string addedQuery = "";
                if (keyType != "TatCa")
                {
                    addedQuery = string.Format(" And tl.ID{0} = {1}", keyType, keyValue);
                }
                string query = string.Format(@"Select tl.IDTaiLieu as 'ID',tl.MaTaiLieu as 'Mã Tài Liệu',tl.NhanDe as 'Nhan Đề', tg.TenTacGia as 'Tên Tác Giả',nn.TenNgonNgu as 'Ngôn ngữ',tl.SoLuong as 'Sách còn', gx.MaGiaXep as 'Giá xếp',k.MaKho as 'Kho'
	                        from dbo.TaiLieu tl inner join dbo.TacGia tg on tl.IDTacGia = tg.IDTacGia
						                        inner join dbo.NgonNgu nn on tl.IDNgonNgu = nn.IDNgonNgu
						                        inner join dbo.NhaXuatBan nxb on tl.IDNXB = nxb.IDNhaXuatBan
						                        inner join dbo.TheLoai th on tl.IDTheLoai = th.IDTheLoai
						                        left join dbo.GiaXep gx on tl.IDGiaXep = gx.IdGiaXep
						                        inner join dbo.Kho k on gx.IdKho = k.IdKho
	                        WHERE (tl.MaTaiLieu like N'%{0}%'
	                        OR tl.NhanDe like N'%{0}%'){1}", strtk,addedQuery);

                DataTable dataTable = DataProvider.ExecuteQuery(query);
                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
