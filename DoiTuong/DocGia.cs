using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;
using System.Windows.Forms;
using System.Data;

namespace quanly.DoiTuong
{
    public class DocGia
    {
        public int IDDocGia { get; set; }
        public string MaDocGia { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public int IDLop { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public DateTime NgayLapThe { get; set; }
        public bool Lock { get; set; }

        public DocGia() { }
        public DocGia(int id, string maDocGia, string hoTen, int idLop, string diaChi, string dienThoai, string email, DateTime ngaySinh, DateTime ngayLapThe, bool khoa)
        {
            this.IDDocGia = id;
            this.MaDocGia = maDocGia;
            this.HoTen = HoTen;
            this.IDLop = idLop;
            this.DiaChi = DiaChi;
            this.DienThoai = dienThoai;
            this.Email = email;
            this.NgaySinh = NgaySinh;
            this.NgayLapThe = NgayLapThe;
            this.Lock = khoa;
        }
        #region Các phương thức hoạt động
        public static bool TaoMoi(DocGia dg)
        {
            try
            {
                string queryCheckExist = string.Format("Select * from DocGia where MaDocGia = N'{0}'", dg.MaDocGia);
                if (DataProvider.ExecuteQuery(queryCheckExist).Rows.Count > 0)
                {
                    throw new Exception("Mã độc giả đã tồn tại!!!");
                }
                else
                {
                    string query = @"Insert into DocGia (MaDocGia,HoTen,NgaySinh,IDLop,DiaChi,DienThoai,Email,NgayLapThe,Lock) 
                                    Values ( @madocgia , @hoten , @ngaySinh , @idLop , @diachi , @dienthoai , @email , @ngaylapthe , @lock )";
                    int result = DataProvider.ExecuteNonQuery(query, new object[] { dg.MaDocGia, dg.HoTen, dg.NgaySinh, dg.IDLop, dg.DiaChi, dg.DienThoai, dg.Email, dg.NgayLapThe, dg.Lock });
                    if (result == 1) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }


        }
        public static bool CapNhat(DocGia dg)
        {
            try
            {
                DocGia docGia = DocGia.GetDocGiaTheoID(dg.IDDocGia);
                if (docGia != null)
                {
                    string query = @"Update DocGia Set MaDocGia = @madocgia ,
                        HoTen = @hoten ,
                        NgaySinh = @ngaysinh ,
                        IDLop = @idlop ,
                        DiaChi = @diachi ,
                        DienThoai = @dienthoai ,
                        Email = @email ,
                        NgayLapThe = @ngaylapthe ,
                        Lock = @lock Where IDDocGia = @idDocGia ";
                    int result = DataProvider.ExecuteNonQuery(query, new object[] { dg.MaDocGia, dg.HoTen, dg.NgaySinh, dg.IDLop, dg.DiaChi, dg.DienThoai, dg.Email, dg.NgayLapThe, dg.Lock, dg.IDDocGia });
                    if (result == 1) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool XoaBo(int id)
        {
            try
            {
                string query = "delete from DocGia where IDDocGia=" + id;
                if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static DocGia GetDocGiaTheoID(int id)
        {
            try
            {
                string query = string.Format("Select * from DocGia where IDDocGia = {0}", id);
                DataTable dt = DataProvider.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    DocGia docGia = new DocGia();
                    docGia.MaDocGia = dr["MaDocGia"].ToString();
                    docGia.HoTen = dr["HoTen"].ToString();
                    docGia.NgaySinh = Convert.ToDateTime(dr["NgaySinh"]);
                    docGia.IDLop = Convert.ToInt32(dr["IDLop"]);
                    docGia.DiaChi = dr["DiaChi"].ToString();
                    docGia.DienThoai = dr["DienThoai"].ToString();
                    docGia.Email = dr["Email"].ToString();
                    docGia.NgaySinh = Convert.ToDateTime(dr["NgaySinh"]);
                    docGia.Lock = string.IsNullOrEmpty(dr["Lock"].ToString()) ? false : Convert.ToBoolean(dr["Lock"]);
                    return docGia;
                }
                else return null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static DataTable GetDSDocGiaFull(string dieukien = "")
        {
            try
            {
                string addedStr = "";
                if (!String.IsNullOrEmpty(dieukien))
                {
                    addedStr = string.Format(@" Where MaDocGia like N'%{0}%'
                    OR HoTen like N'%{0}%' OR TenLop like N'%{0}%' OR MaKhoa like N'%{0}%'", dieukien);
                }
                string query = string.Format(@"Select dg.IDDocGia as [ID],dg.MaDocGia as [Mã độc giả],dg.HoTen [Họ tên],dg.NgaySinh as [Ngày sinh],l.TenLop [Lớp],k.MaKhoa as [Khoa],dg.Lock as [Khóa] 
                    from DocGia dg inner join Lop l on dg.IDLop = l.IDLop
					inner join Khoa k on l.IDKhoa = k.IDKhoa")+addedStr;
                return DataProvider.ExecuteQuery(query);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static List<DocGia> GetDSDocGia()
        {
            try
            {
                string query = "Select * from DocGia";
                DataTable dt = DataProvider.ExecuteQuery(query);
                List<DocGia> list = new List<DocGia>();
                foreach (DataRow dr in dt.Rows)
                {
                    DocGia dg = new DocGia();
                    dg.IDDocGia = Convert.ToInt32(dr["IDDocGia"]);
                    dg.IDLop = Convert.ToInt32(dr["IDLop"]);
                    dg.MaDocGia = dr["MaDocGia"].ToString();
                    dg.HoTen = dr["HoTen"].ToString();
                    dg.DiaChi = dr["DiaChi"].ToString();
                    dg.DienThoai = dr["DienThoai"].ToString();
                    dg.Email = dr["Email"].ToString();
                    dg.NgaySinh = Convert.ToDateTime(dr["NgaySinh"]);
                    dg.NgayLapThe = Convert.ToDateTime(dr["NgayLapThe"]);
                    dg.Lock = Convert.ToBoolean(dr["Lock"]);
                    list.Add(dg);
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}