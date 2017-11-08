using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using System.Data.SqlClient;
using quanlythuvien;
namespace quanly.frm
{
    public partial class Frmtknangcao : Form
    {
        public Frmtknangcao()
        {
            InitializeComponent();
        }
        DataSet ds;
        CurrencyManager cm;
        private void Frmtknangcao_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true; 
            Load_combobox();
        }
        void Load_combobox()
        {
            laydulieu dl = new laydulieu();
            SqlDataReader dr1 = dl.lay_reader("select loai from phanloai");
            while (dr1.Read())
                cbloaisach.Items.Add(dr1[0].ToString());
            L_Ketnoi.HuyKetNoi();
            L_Ketnoi.ThietlapketNoi();
            SqlDataReader dr2 = dl.lay_reader("select ngonngu from ngonngu");
            while (dr2.Read())
                cbngonngu.Items.Add(dr2[0].ToString());
            L_Ketnoi.HuyKetNoi();
            L_Ketnoi.ThietlapketNoi();
            SqlDataReader dr3 = dl.lay_reader("select tentacgia from tacgia");
            while (dr3.Read())
                cbtacgiac.Items.Add(dr3[0].ToString());
            L_Ketnoi.HuyKetNoi();
            

        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ltimkiem tk = new Ltimkiem();
            ds = tk.nangcao(textBox1.Text, cbtacgiac.Text, cbloaisach.Text, cbngonngu.Text);
            dataGridView1.DataSource = ds.Tables[0];
            cm = BindingContext[this.ds.Tables[0]] as CurrencyManager;
            label5.Text = cm.Count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frmcapnhatsach cn = new Frmcapnhatsach();
            Frmcapnhatsach.tb = ds.Tables[0].Rows[cm.Position][0].ToString();
            cn.Show();
        
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) button1_Click(sender, e);
        }

        private void Frmtknangcao_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }
        Frmnangcaohelp dg = new Frmnangcaohelp();
        private void dataGridView1_CellMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                timer1.Enabled = true;
                dg.set_giatri(ds.Tables[0].Rows[cm.Position][1].ToString(), ds.Tables[0].Rows[cm.Position][2].ToString(), ds.Tables[0].Rows[cm.Position][4].ToString(), ds.Tables[0].Rows[cm.Position][5].ToString(), ds.Tables[0].Rows[cm.Position][6].ToString(), ds.Tables[0].Rows[cm.Position][7].ToString());
                dg.Show();
               
             }
        }

       
        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            dg.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dg.set_point(MousePosition.X, MousePosition.Y - 197);
        }
    }
}