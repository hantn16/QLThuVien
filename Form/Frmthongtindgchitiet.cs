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
        public void set_giatri(string ten, string diachi, string vitri, string ngaysinh, string ngaylamthe, string tenkhoa)
        {
            lbdiachi.Text = diachi;
            lbhoten.Text = ten;
            lbvitri.Text = vitri;
            lbngaylamthe.Text = ngaylamthe;
            lbkhoa.Text = tenkhoa;
            lbngaysinh.Text = ngaysinh;
        }
        public void set_point(int x, int y)
        {
            this.Location = new Point(x, y);
        }
    }
}