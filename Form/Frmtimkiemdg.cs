using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using System.Data.SqlClient;
using quanly.frm;
namespace quanly.frm
{
    public partial class Frmtimkiemdg : Form
    {
        public Frmtimkiemdg()
        {
            InitializeComponent();
        }

        private void Frmtimkiemdg_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
        }

        private void bttimkiem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            laydulieu dl = new laydulieu();
            SqlDataReader dr = dl.lay_reader("select DocGia.MaDocGia,DocGia.HoTen,DocGia.DiaChi,DocGia.NgaySinh,khoa.tenkhoa,DocGia.ViTri,DocGia.NgayLapThe from DocGia,khoa where DocGia.MaKhoa = khoa.MaKhoa and ((DocGia.HoTen like N'%" + txttimkiem.Text + "%')or (DocGia.DiaChi like N'%" + txttimkiem.Text + "%') or (DocGia.MaDocGia = N'" + txttimkiem.Text + "') or (khoa.tenkhoa like N'%" + txttimkiem.Text + "%'))");
            int i = 0;
            while (dr.Read())
            {
                listView1.Items.Add(dr[0].ToString(), 1);
                listView1.Items[i].SubItems.Add(dr[1].ToString());
                listView1.Items[i].SubItems.Add(dr[2].ToString());
                listView1.Items[i].SubItems.Add(dr[3].ToString());
                listView1.Items[i].SubItems.Add(dr[4].ToString());
                listView1.Items[i].SubItems.Add(dr[5].ToString());
                listView1.Items[i].SubItems.Add(dr[6].ToString());
                i++;
            }
            label2.Text = i.ToString();
            L_Ketnoi.HuyKetNoi();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) bttimkiem_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string str = listView1.SelectedItems[0].Text;
                int i = 0;
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select * from DocGia");
                while (dr.Read())
                    if (dr[0].ToString() == str) break;
                    else i++;
                L_Ketnoi.HuyKetNoi();
                //Frmquanlybandoc.i = i;
                Frmquanlybandoc bd = new Frmquanlybandoc();
                bd.MdiParent = this.MdiParent;
                bd.set_giattri();
                bd.Show();
               
            }
            else { MessageBox.Show("Bạn phải chọn một đối tượng độc giả"); };
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button1_Click(sender, e);
        }
        Frmthongtindgchitiet dg = new Frmthongtindgchitiet();
        private void Frmtimkiemdg_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                
            if (listView1.SelectedItems.Count > 0)
            {
                dg.set_giatri(listView1.SelectedItems[0].SubItems[1].Text, listView1.SelectedItems[0].SubItems[2].Text, listView1.SelectedItems[0].SubItems[5].Text, listView1.SelectedItems[0].SubItems[3].Text, listView1.SelectedItems[0].SubItems[6].Text, listView1.SelectedItems[0].SubItems[4].Text);
                dg.Show();
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             dg.set_point(MousePosition.X, MousePosition.Y - 197);
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            dg.Hide();
        }

        private void bttaothe_Click(object sender, EventArgs e)
        {
            laydulieu dl = new laydulieu();
            SqlDataReader dr = dl.lay_reader("select DocGia.MaDocGia,DocGia.HoTen,DocGia.DiaChi,DocGia.NgaySinh,khoa.tenkhoa,DocGia.ViTri,DocGia.NgayLapThe from DocGia,khoa where DocGia.MaKhoa = khoa.MaKhoa and ((DocGia.HoTen like N'%" + txttimkiem.Text + "%')or (DocGia.DiaChi like N'%" + txttimkiem.Text + "%') or (DocGia.MaDocGia = N'" + txttimkiem.Text + "') or (khoa.tenkhoa like N'%" + txttimkiem.Text + "%'))");
            frmtaothe fdg = new frmtaothe();
            fdg.set_dr(dr);
            fdg.Show();
        }


    }
}