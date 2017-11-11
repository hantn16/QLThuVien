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
        string strTheThuc = "";
        bool ktsach = false, ktbandoc = false;
        private void button1_Click(object sender, EventArgs e)
        {
            laydulieu dl = new laydulieu();
            bool tam = false;
            SqlDataReader dr = dl.lay_reader("select TheThuc,ten,LanXuatBan,NhanDe,SoLuong ,NamXuatBan,SoTrang,NgonNgu,TenTacGia, kho,ke,ngan from sach,NgonNgu,NhaXuatBan,ViTriluutru,TacGia where sach.MaTacGia = TacGia.MaTacGia and sach.MaNgonNgu = NgonNgu.MaNgonNgu and sach.MaNXB = NhaXuatBan.MaNXB and sach.MaViTri = ViTriluutru.MaViTri and sach.MaTaiLieu='"+ txtMaTaiLieu.Text+"'");
            while (dr.Read())
            {
                txtNamXuatBan.Text = DateTime.Parse(dr["NamXuatBan"].ToString()).ToShortDateString();
                txtke.Text = dr["ke"].ToString();
                txtkho.Text = dr["kho"].ToString();
                txtlanxuatban.Text = dr["LanXuatBan"].ToString();
                txtngan.Text = dr["ngan"].ToString();
                txtNgonNgu.Text = dr["NgonNgu"].ToString();
                txtNhanDe.Text = dr["NhanDe"].ToString();
                txtnhaxb.Text = dr["ten"].ToString();
                txtSoLuong.Text = dr["SoLuong"].ToString();
                txtSoTrang.Text = dr["SoTrang"].ToString();
                txtTacGia.Text = dr["TenTacGia"].ToString();
                txtTheThuc.Text = dr["TheThuc"].ToString();
                tam = true;
                ktsach = true;
            }
            L_Ketnoi.HuyKetNoi();
            if (tam == true)
            {
                L_Ketnoi.ThietlapketNoi();
                SqlDataReader dr1 = dl.lay_reader("select * from sachhong where MaTaiLieu='" + txtMaTaiLieu.Text + "'");
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
                txtMaTaiLieu.Enabled = false;
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
         
            SqlDataReader dr = dl.lay_reader("select * from DocGia,khoa where DocGia.MaDocGia = '"+ txtmabandoc.Text+"'");
            while (dr.Read())
            {
                txtHoTen.Text = dr["HoTen"].ToString();
                txtViTri.Text = dr["ViTri"].ToString();
                txtDiaChi.Text = dr["DiaChi"].ToString();
                txtkhoa.Text = dr["tenkhoa"].ToString();
                tam = true;
                ktbandoc = true;
            }
            L_Ketnoi.HuyKetNoi();
            
            if (ktbandoc)
            {
                L_Ketnoi.ThietlapketNoi();
                SqlDataReader dr1 = dl.lay_reader("select TheThucmuon from phieumuon,sachmuon where phieumuon.maphieumuon = sachmuon.maphieumuon and phieumuon.MaDocGia='" + txtmabandoc.Text + "'");
                while (dr1.Read())
                    strTheThuc = dr1[0].ToString();
                L_Ketnoi.HuyKetNoi();
                if (strTheThuc != "") MessageBox.Show("Đối tượng này đã mượn sách với thể thức là " + strTheThuc);
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
            txtDiaChi.Text = txtHoTen.Text = txtke.Text = txtkho.Text = txtkhoa.Text = "";
            txtlanxuatban.Text = txtmabandoc.Text = txtMaTaiLieu.Text = txtNamXuatBan.Text = "";
            txtngan.Text = txtNgonNgu.Text = txtNhanDe.Text = txtnhaxb.Text = txtSoLuong.Text = "";
            txtSoTrang.Text = txtTacGia.Text = txtViTri.Text = "";txtTheThuc.Text = "";
            bttkbandoc.Enabled = btsach.Enabled = true;
            txtMaTaiLieu.Enabled = txtmabandoc.Enabled= true;
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
                    if ((comboBox1.Text == strTheThuc) && (comboBox1.Text != "Mượn giáo trình"))
                        MessageBox.Show("Không thể " + strTheThuc + " 2 quyển sách, phải trả sách mới được mượn tiếp");
                    else
                    {
                        if (int.Parse(txtSoLuong.Text) < int.Parse(textBox1.Text)) MessageBox.Show("Số lượng sách trong thư viện không đủ cho bạn mượn hãy nhập lại", "Thông báo");
                        else
                        {

                            if (txtTheThuc.Text != comboBox1.Text) MessageBox.Show("Thể thức bạn mượn sách này không thể đáp ứng được hãy chọn lại sách khác", "Thông báo");
                            else
                            {
                                TaiLieu s = new TaiLieu();
                                s.MaTaiLieu =(txtMaTaiLieu.Text);
                                                             
                                if (s.ChoMuon(textBox1.Text))
                                {
                                    try
                                    {
                                        int tamsl = int.Parse(textBox1.Text);
                                        Lphieumuon pm = new Lphieumuon(tam, txtmabandoc.Text, comboBox1.Text, txtMaTaiLieu.Text, KTdangnhap.strMaNhanVien, DateTime.Parse(DateTime.Now.ToShortDateString()), tamsl);
                                        if (pm.TaoMoi())
                                        {
                                            TaiLieumuon sm = new TaiLieumuon(tam);
                                            if (sm.TaoMoi())
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

        private void txtMaTaiLieu_KeyDown(object sender, KeyEventArgs e)
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