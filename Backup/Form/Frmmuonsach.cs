using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using quanly.lopdulieu;
using System.Windows.Forms;
using System.Data.SqlClient;
using quanly.doituong;
namespace quanly.frm
{
    public partial class Frmmuonsach : Form
    {
        public Frmmuonsach()
        {
            InitializeComponent();
        }
        string strthethuc = "";
        bool ktsach = false, ktbandoc = false;
        private void button1_Click(object sender, EventArgs e)
        {
            laydulieu dl = new laydulieu();
            bool tam = false;
            SqlDataReader dr = dl.lay_reader("select thethuc,ten,lanxb,nhande,soluong ,namxb,sotrang,ngonngu,tentacgia, kho,ke,ngan from sach,ngonngu,nhaxuatban,vitriluutru,tacgia where sach.matacgia = tacgia.matacgia and sach.mangonngu = ngonngu.mangonngu and sach.manxb = nhaxuatban.manxb and sach.mavitri = vitriluutru.mavitri and sach.masach='"+ txtmasach.Text+"'");
            while (dr.Read())
            {
                txtnamxb.Text = DateTime.Parse(dr["namxb"].ToString()).ToShortDateString();
                txtke.Text = dr["ke"].ToString();
                txtkho.Text = dr["kho"].ToString();
                txtlanxuatban.Text = dr["lanxb"].ToString();
                txtngan.Text = dr["ngan"].ToString();
                txtngonngu.Text = dr["ngonngu"].ToString();
                txtnhande.Text = dr["nhande"].ToString();
                txtnhaxb.Text = dr["ten"].ToString();
                txtsoluong.Text = dr["soluong"].ToString();
                txtsotrang.Text = dr["sotrang"].ToString();
                txttacgia.Text = dr["tentacgia"].ToString();
                txtthethuc.Text = dr["thethuc"].ToString();
                tam = true;
                ktsach = true;
            }
            L_Ketnoi.HuyKetNoi();
            if (tam == true)
            {
                L_Ketnoi.ThietlapketNoi();
                SqlDataReader dr1 = dl.lay_reader("select * from sachhong where masach='" + txtmasach.Text + "'");
                int i = 0;
                while (dr1.Read())
                    i++;
                L_Ketnoi.HuyKetNoi();
                btsach.Enabled = false;
                if (i > 0)
                {
                    lbhong.Visible = true;
                    lbketqua.Text = i.ToString() + " cuốn";
                }
                else
                {
                    lbhong.Visible = false;
                    lbketqua.Text = "";
                }
                txtmasach.Enabled = false;
            }
        }

        private void Frmmuonsach_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
        }

        private void btbandoc(object sender, EventArgs e)
        {
            laydulieu dl = new laydulieu();
            bool tam = false;
         
            SqlDataReader dr = dl.lay_reader("select * from docgia,khoa where docgia.madocgia = '"+ txtmabandoc.Text+"'");
            while (dr.Read())
            {
                txthoten.Text = dr["hoten"].ToString();
                txtvitri.Text = dr["vitri"].ToString();
                txtdiachi.Text = dr["diachi"].ToString();
                txtkhoa.Text = dr["tenkhoa"].ToString();
                tam = true;
                ktbandoc = true;
            }
            L_Ketnoi.HuyKetNoi();
            
            if (ktbandoc)
            {
                L_Ketnoi.ThietlapketNoi();
                SqlDataReader dr1 = dl.lay_reader("select thethucmuon from phieumuon,sachmuon where phieumuon.maphieumuon = sachmuon.maphieumuon and phieumuon.madocgia='" + txtmabandoc.Text + "'");
                while (dr1.Read())
                    strthethuc = dr1[0].ToString();
                L_Ketnoi.HuyKetNoi();
                if (strthethuc != "") MessageBox.Show("Đối tượng này đã mượn sách với thể thức là " + strthethuc);
                if (tam)
                {
                    txtmabandoc.Enabled = false;
                    bttkbandoc.Enabled = false;
                }
                else
                {
                    txtmabandoc.Enabled = true;
                    bttkbandoc.Enabled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ktbandoc = ktsach = false;
            txtmabandoc.Text = "";
            txtdiachi.Text = txthoten.Text = txtke.Text = txtkho.Text = txtkhoa.Text = "";
            txtlanxuatban.Text = txtmabandoc.Text = txtmasach.Text = txtnamxb.Text = "";
            txtngan.Text = txtngonngu.Text = txtnhande.Text = txtnhaxb.Text = txtsoluong.Text = "";
            txtsotrang.Text = txttacgia.Text = txtvitri.Text = "";txtthethuc.Text = "";
            bttkbandoc.Enabled = btsach.Enabled = true;
            txtmasach.Enabled = txtmabandoc.Enabled= true;
            lbhong.Visible = false;
            lbketqua.Text = "";
        }
        string maphieumuon(string ma)
        {
            string s = ma.Substring(2, ma.Length - 2);
            double i = double.Parse(s);
            i++;
            if (i < 10) return "PM0000" + i.ToString();
            else
                if (i < 100) return "PM000" + i.ToString();
                else
                    if (i < 1000) return "PM00" + i.ToString();
                    else
                        if (i < 10000) return "PM0" + i.ToString();
                        else
                            return "PM" + i.ToString();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (ktbandoc && ktsach)
            {
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select maphieumuon from phieumuon");
                string tam = "";
                while (dr.Read())
                    tam = dr[0].ToString();
                L_Ketnoi.HuyKetNoi();
                if (tam == "") tam = "PM00000";
                else tam = maphieumuon(tam);
                if(comboBox1.Text=="") MessageBox.Show("Bạn phải chọn thể thức mượn");
                else
                {
                    if ((comboBox1.Text == strthethuc) && (comboBox1.Text != "Mượn giáo trình"))
                        MessageBox.Show("Không thể " + strthethuc + " 2 quyển sách, phải trả sách mới được mượn tiếp");
                    else
                    {
                        if (int.Parse(txtsoluong.Text) < int.Parse(textBox1.Text)) MessageBox.Show("Số lượng sách trong thư viện không đủ cho bạn mượn hãy nhập lại", "Thông báo");
                        else
                        {

                            if (txtthethuc.Text != comboBox1.Text) MessageBox.Show("Thể thức bạn mượn sách này không thể đáp ứng được hãy chọn lại sách khác", "Thông báo");
                            else
                            {
                                Lsach s = new Lsach();
                                s.set_masach(txtmasach.Text);
                                                             
                                if (s.chomuon(textBox1.Text))
                                {
                                    try
                                    {
                                        int tamsl = int.Parse(textBox1.Text);
                                        Lphieumuon pm = new Lphieumuon(tam, txtmabandoc.Text, comboBox1.Text, txtmasach.Text, KTdangnhap.strmanhanvien, DateTime.Parse(DateTime.Now.ToShortDateString()), tamsl);
                                        if (pm.taomoi())
                                        {
                                            Lsachmuon sm = new Lsachmuon(tam);
                                            if (sm.taomoi())
                                            {
                                                button2_Click(sender, e);
                                                MessageBox.Show("Đã hoàn thành thao tác", "Thông báo");
                                            }
                                            else
                                            {
                                                button2_Click(sender, e);
                                                MessageBox.Show("Thao tác gặp lỗi hãy thực hiện lại sau", "Thông báo");
                                            }
                                        }
                                        else
                                        {
                                            button2_Click(sender, e);
                                            MessageBox.Show("Thao tác gặp lỗi hãy thực hiện lại sau", "Thông báo");
                                        }
                                    }
                                    catch { MessageBox.Show(" Nhập sai số lượng sách mượn"); }
                                }
                                else
                                {
                                    MessageBox.Show("Quá trình cho mượn sách bị thất bại");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn phải kiểm tra thông tin trước mới thực hiện được thao tác này", "Thông báo");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Mượn giáo trình")
                textBox1.Enabled = true;
            else
            {
                textBox1.Text = "1";
                textBox1.Enabled = false;
            }
        }

        private void txtmasach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) button1_Click(sender, e);
        }

        private void txtmabandoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) btbandoc(sender, e);
        }

        private void Frmmuonsach_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }
    }
}