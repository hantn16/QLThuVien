using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace quanly.frm
{
    public partial class Frmhelpfast : Form
    {
        public Frmhelpfast()
        {
            InitializeComponent();
        }
        int i = 0;
        int j=1;
        public static string t = "      Chào! tôi là người hỗ trợ hệ thống có gì thắc mắc hãy liên hệ với tôi !";
        private void Frmhelpfast_Load(object sender, EventArgs e)
        {
           
        }
        public void set_anh(int i)
        {
            if (i==1) this.pictureBox1.Image = global::quanlythuvien.Properties.Resources._5214496;
            if (i == 2) this.pictureBox1.Image = global::quanlythuvien.Properties.Resources._12;
            if (i == 3) this.pictureBox1.Image = global::quanlythuvien.Properties.Resources._13;
        }
        public void set_text(string s)
        {
            label1.Text = s;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            this.Location = new System.Drawing.Point(0, i);
            i+=j;
            j++;
            if (i > (Frmmain.rong-225))
            {
                timer1.Enabled = false;
                timer2.Enabled = true;
                j = 0;
            }
           
        }
        int k=10;
        private void timer2_Tick(object sender, EventArgs e)
        {
           
            this.Location = new System.Drawing.Point(0, this.Location.Y - k);
            k +=j;
            j++;
            if (this.Location.Y < (Frmmain.rong - 525)) { timer2.Enabled = false; timer3.Enabled = true; k = 0; j = 1; }
           
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
          
            this.Location = new System.Drawing.Point(0, this.Location.Y  + k);
            k = k + j;
            j++;
            if (this.Location.Y > (Frmmain.rong - 275))
            {
                label1.Visible = true;
                timer3.Enabled = false;
                label1.Text = t;
            }
        }
        public static bool an = true;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            an = false;
            this.Hide();
        }

       
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer4.Enabled = true;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(MousePosition.X - 5, MousePosition.Y-100);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer4.Enabled = false;
            }
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        bool mt = true;
        private void timer5_Tick(object sender, EventArgs e)
        {
            if (mt) label1.ForeColor = Color.DarkViolet;
            else label1.ForeColor = Color.ForestGreen;
            mt = !mt;
        }
    }
}