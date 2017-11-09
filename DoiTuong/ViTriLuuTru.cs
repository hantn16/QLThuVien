using System;
using System.Collections.Generic;
using System.Text;
using quanly.lopdulieu;
using quanlythuvien.Data;

namespace quanly.DoiTuong
{
    public class ViTriLuuTru
    {
        public string MaViTri { get; set; }
        public string Kho { get; set; }
        public string Ke { get; set; }
        public string Ngan { get; set; }
        public ViTriLuuTru() { }
        public ViTriLuuTru(string kho,string MaViTri,string ke,string ngan)
        {
            this.Ke = ke;
            this.Kho = kho;
            this.Ngan = ngan;
            this.MaViTri = MaViTri;
        }
        /// <summary>
        /// Hàm thêm mới đối tượng Vị trí lưu trữ vào cơ sở dữ liệu
        /// </summary>
        /// <returns></returns>
        public bool TaoMoi()
        {
            string query = "insert into ViTriluutru values ('" + MaViTri + "','" + Kho + "','" + Ke + "','" + Ngan + "')";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
        /// <summary>
        /// Hàm cập nhật đối tượng vị trí lưu trữ vào cơ sở dữ liệu
        /// </summary>
        /// <returns></returns>
        public bool CapNhat()
        {
            string query = "update ViTriluutru set kho='" + Kho + "',ke='" + Ke + "',ngan='" + Ngan + "' where MaViTri='" + MaViTri + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;

        }
        /// <summary>
        /// Hàm xóa bỏ một đối tượng vị trí lưu trữ
        /// </summary>
        /// <returns></returns>
        public bool XoaBo()
        {
            string query = "delete from ViTriluutru where MaViTri='" + MaViTri + "'";
            if (DataProvider.ExecuteNonQuery(query) == 1) return true; else return false;
        }
    }
}
