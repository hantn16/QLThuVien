using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using System.Data.SqlClient;
using quanly.doituong;
namespace quanly.frm
{
    public partial class Frmtrasach : Form
    {
        public Frmtrasach()
        {
            InitializeComponent();
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        string maphieumuon="";
        private void btkiemtratt_Click(object sender, EventArgs e)
        {
            laydulieu dl = new laydulieu();
            bool tam = false;
            SqlDataReader dr = dl.lay_reader("select * from phieumuon,sachmuon where phieumuon.maphieumuon = sachmuon.maphieumuon and phieumuon.madocgia='"+ txtmadocgia.Text+"' and phieumuon.thethucmuon=N'"+ comboBox1.Text+"'");
            while (dr.Read())
            {
                txtngaymuon.Text = dr["ngaymuon"].ToString();
                DateTime tam1=DateTime.Parse(dr["ngaymuon"].ToString());
                txtsongaymuon.Text = ((TimeSpan)(DateTime.Now - tam1)).Days.ToString();
                txtsosachmuon.Text = dr["soluong"].ToString();
                maphieumuon = dr["maphieumuon"].ToString();
                txtmasach.Text = dr["masach"].ToString();
                tam = true;
            }
            L_Ketnoi.HuyKetNoi();
                 bttrasach.Enabled = tam;
                 if (tam)
                 {
                   
                     txtmadocgia.Enabled = false;
                     comboBox1.Enabled = false;
                     btkiemtratt.Enabled = false;
                 }
                 
        }

        private void bthuytt_Click(object sender, EventArgs e)
        {
            
            txtmadocgia.Enabled = true;
            comboBox1.Enabled = true;
            btkiemtratt.Enabled = true;
            bttrasach.Enabled = false;
            txtmasach.Text = txtngaymuon.Text = txtsongaymuon.Text = txtsosachmuon.Text = txtmadocgia.Text = txtmasach.Text = comboBox1.Text = "";
        }
        string masachhong(string tam)
        { 
            if (tam=="") return "SH0000";
            int ma = int.Parse(tam.Substring(2,tam.Length -2));
            ma++;
            if (ma < 10) return "SH000" + ma.ToString();
            else
                if (ma < 100) return "SH00" + ma.ToString();
                else
                    if (ma < 1000) return "SH0" + ma.ToString();
                    else return "SH" + ma.ToString();
        }
        private void bttrasach_Click(object sender, EventArgs e)
        {
            laydulieu dl = new laydulieu();
            DataSet d = dl.getdata("select * from phieumuon where maphieumuon='" + maphieumuon + "' and GETdate()- phieumuon.ngaymuon > day(7)");
            while (true)
            {
                if(d.Tables[0].Rows.Count > 0)
                    if (MessageBox.Show("Sách này đã quá hạn bạn có thật sự muốn tiếp tục thực hiện thao tác này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        Frmmain.hf.set_text("Sách quá hạn là sách mượn vượt quá 7 ngày không xét trường hợp sách mượn đọc tại chỗ");
                        Frmmain.hf.set_anh(2);
                        Frmmain.hf.timer5.Enabled = true;
                        break;
                    }
                    Lsachmuon sm = new Lsachmuon(maphieumuon);
                    Lsach s = new Lsach();
                    s.set_masach(txtmasach.Text);
                    if (s.trasach(txtsosachmuon.Text))
                    {
                        if (sm.xoabo())
                        {
                            if (checkBox1.Checked)
                                if (MessageBox.Show("Sách này có thật sự bị hỏng không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    L_Ketnoi.ThietlapketNoi();
                                    SqlDataReader dr = dl.lay_reader("select masachhong from sachhong");
                                    string strtam = "";
                                    while (dr.Read())
                                        strtam = dr[0].ToString();
                                    L_Ketnoi.HuyKetNoi();
                                    Lsachhong sh = new Lsachhong(masachhong(strtam), txtmasach.Text);
                                    if (sh.taomoi() == false) MessageBox.Show("Quá trình cập nhật sách hỏng bị lỗi hãy chuyển qua mục thông tin sách hỏng để làm", "Thông báo");

                                }
                            bthuytt_Click(sender, e);
                            MessageBox.Show("Thao tác trả hoàn thành", "Thông báo");
                        }
                        else MessageBox.Show("Thao tác xoá gặp lỗi thành", "Thông báo");
                    }
                    else MessageBox.Show("Thao tác xoá gặp lỗi thành", "Thông báo");
                    break;
                }
        }

        private void Frmtrasach_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
        }

        private void Frmtrasach_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }
    }
}