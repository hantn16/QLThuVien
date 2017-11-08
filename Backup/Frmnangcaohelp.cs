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
        public void set_giatri(string tensach, string tacgia, string soluong, string kho, string ke, string ngan)
        {
            lbtensach.Text = tensach;
            lbtacgia.Text = tacgia;
            lbkho.Text = kho;
            lbngan.Text = ngan;
            lbsoluong.Text = soluong;
            lbke.Text = ke;
        }
        public void set_point(int x, int y)
        {
            this.Location = new Point(x, y);
        }
    }
}