using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.frm;

namespace quanlythuvien.Thong_ke_bao_cao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
            Frmmain.hf.set_text(Frmhelpfast.t);
            Frmmain.hf.set_anh(1);
        }
    }
}