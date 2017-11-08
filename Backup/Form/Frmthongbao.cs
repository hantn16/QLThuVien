using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace quanly.frm
{
    public partial class Frmthongbao : Form
    {
        public Frmthongbao()
        {
            InitializeComponent();
        }
        public static string tam = "";
        private void Frmthongbao_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tam=textBox1.Text;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                tam = textBox1.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}