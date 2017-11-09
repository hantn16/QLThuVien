using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace quanly.frm
{
    public partial class Frmthongtindgchitiet : Form
    {
        public Frmthongtindgchitiet()
        {
            InitializeComponent();
        }

        private void Frmthongtindgchitiet_Load(object sender, EventArgs e)
        {

        }
        public void set_giatri(string ten, string DiaChi, string ViTri, string NgaySinh, string ngaylamthe, string tenkhoa)
        {
            lbDiaChi.Text = DiaChi;
            lbHoTen.Text = ten;
            lbViTri.Text = ViTri;
            lbngaylamthe.Text = ngaylamthe;
            lbkhoa.Text = tenkhoa;
            lbNgaySinh.Text = NgaySinh;
        }
        public void set_point(int x, int y)
        {
            this.Location = new Point(x, y);
        }
    }
}