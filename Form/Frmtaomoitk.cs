using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using quanly.lopdulieu;
using quanly.doituong;
using quanlythuvien.Data;

namespace quanly.frm
{
    public partial class FrmTaoMoitk : Form
    {
        public FrmTaoMoitk()
        {
            InitializeComponent();
        }
        DataTable dataTable = new DataTable();
        string[] s = new string[50];
        int i = 0;
        private void FrmTaoMoitk_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
            dataTable = DataProvider.ExecuteQuery("select * from NhanVien");
            //---xây dựng thuộc tính khoá cho trường trong bảng nhằm sau này có thể
            //---thực hiện được phương thức Find của datarows--------
            DataColumn[] cl = new DataColumn[1];
            cl[0] = dataTable.Columns[0];
            dataTable.PrimaryKey = cl;
            load_listbox();
            load_textbox(i);
            
             
        }
        void load_listbox()
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                listView1.Items.Add(dataTable.Rows[i]["HoTen"].ToString(),1);
                listView1.Items[i].SubItems.Add(dataTable.Rows[i]["DiaChi"].ToString());
                listView1.Items[i].SubItems.Add(dataTable.Rows[i]["TenDangNhap"].ToString());
                listView1.Items[i].SubItems.Add(dataTable.Rows[i]["QuyenHan"].ToString());
                s[i] = dataTable.Rows[i]["MaNhanVien"].ToString();
                
            }
        }
        void load_textbox(int i)
        {
            txtHoTen.Text = listView1.Items[i].SubItems[0].Text; ;
            txtDiaChi.Text = listView1.Items[i].SubItems[1].Text;
            txtmanv.Text = s[i];
            txtTenDangNhap.Text = listView1.Items[i].SubItems[2].Text;
            comboBox1.Text = listView1.Items[i].SubItems[3].Text;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #region di chuyển
        private void button4_Click(object sender, EventArgs e)
        {
            load_textbox(0);
            i = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (i != dataTable.Rows.Count - 1)
            {
                i = dataTable.Rows.Count - 1;
                load_textbox(i);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i--;
                load_textbox(i);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (i < dataTable.Rows.Count - 1)
            {
                i++;
                load_textbox(i);
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xoá nhân viên này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NhanVien nv = new NhanVien();
                nv.MaNhanVien = (txtmanv.Text);
                if (nv.XoaBo() == true)
                {
                    MessageBox.Show("Bạn đã xoá bỏ thành công");
                    listView1.Items[i].Remove();
                    DataRow dr = dataTable.Rows.Find(txtmanv.Text);
                    dataTable.Rows.Remove(dr);
                    for (int j = i; j < dataTable.Rows.Count - 1; j++)
                    {
                        s[j] = s[j + 1];
                    }
                    if (i > 0)
                    {
                        i = i-1;
                    }
                        load_textbox(i);
                    
                   
                }
                else
                {
                    MessageBox.Show("Quá trình xoá bỏ gặp thất bại bạn hãy kiểm tra lại");
                }
            }
        }
        string taoma(string ma)
        {
            string s = ma.Substring(2, ma.Length - 2);
            int i = int.Parse(s);
            i++;
            if (i < 10) return "NV00" + Convert.ToString(i);
            else
                if (i < 100) return "NV0" + Convert.ToString(i);
                else return "NV" + Convert.ToString(i);
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "OK")
            {
                button1.Text = "Tạo mới";
                txtDiaChi.Enabled = false;
                txtHoTen.Enabled = false;
                txtTenDangNhap.Enabled = false;
                comboBox1.Enabled = false;
                NhanVien nv = new NhanVien();
                nv.MaNhanVien = (txtmanv.Text);
                nv.MatKhau = ("");
                nv.DiaChi = (txtDiaChi.Text);
                nv.HoTen = (txtHoTen.Text);
                nv.QuyenHan = (comboBox1.Text);
                nv.TenDangNhap = (txtTenDangNhap.Text);
                i = dataTable.Rows.Count;
                if (nv.TaoMoi())
                {
                    s[i] = txtmanv.Text;
                    //======cập nhật thông tin cho Dataset===========
                    DataRow dr ;
                    dr = dataTable.NewRow();
                    dr[0] = txtmanv.Text;
                    dr[1] = txtHoTen.Text;
                    dr[2] = txtDiaChi.Text;
                    dr[3] = txtTenDangNhap.Text;
                    dr[4] = "";
                    dr[5] = comboBox1.Text;
                    dataTable.Rows.Add(dr);
                    //-------------------------------

                    //======Cập nhật thông tin cho Listview==========
                    listView1.Items.Add(txtHoTen.Text, 1);
                    listView1.Items[i].SubItems.Add(txtDiaChi.Text);
                    listView1.Items[i].SubItems.Add(txtTenDangNhap.Text);
                    listView1.Items[i].SubItems.Add(comboBox1.Text);
                    //---------------------------------
                    MessageBox.Show("Quá trình tạo mới đã thành công");
                }
                else
                    MessageBox.Show("Quá trình tạo mới bị lỗi bạn hãy thử lại");

            }
            else
            {
                button1.Text = "OK";
                txtDiaChi.Enabled = true;
                txtHoTen.Enabled = true;
                txtTenDangNhap.Enabled = true;
                comboBox1.Enabled = true;
                txtDiaChi.Text = "";
                txtHoTen.Text = "";
                txtTenDangNhap.Text = "";
                txtmanv.Text = taoma(s[dataTable.Rows.Count-1]);
            }
        }

        private void FrmTaoMoitk_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
            Frmmain.hf.set_text(Frmhelpfast.t);
            Frmmain.hf.set_anh(1);
        }
    }
}