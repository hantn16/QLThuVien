using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace quanlythuvien
{
    public partial class Frmnangcaohelp : Form
    {
        public Frmnangcaohelp()
        {
            InitializeComponent();
        }

        private void Frmnangcaohelp_Load(object sender, EventArgs e)
        {

        }
        public void set_giatri(string tensach, string TacGia, string SoLuong, string kho, string ke, string ngan)
        {
            lbtensach.Text = tensach;
            lbTacGia.Text = TacGia;
            lbkho.Text = kho;
            lbngan.Text = ngan;
            lbSoLuong.Text = SoLuong;
            lbke.Text = ke;
        }
        public void set_point(int x, int y)
        {
            this.Location = new Point(x, y);
        }
    }
}