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

namespace quanly.frm
{
    public partial class Frmtaomoitk : Form
    {
        public Frmtaomoitk()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        string[] s = new string[50];
        int i = 0;
        private void Frmtaomoitk_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
            laydulieu dl = new laydulieu();
            ds = dl.getdata("select * from nhanvien");
            //---xây dựng thuộc tính khoá cho trường trong bảng nhằm sau này có thể
            //---thực hiện được phương thức Find của datarows--------
            DataColumn[] dt = new DataColumn[1];
            dt[0] = ds.Tables[0].Columns[0];
            ds.Tables[0].PrimaryKey = dt;
            load_listbox();
            load_textbox(i);
            
             
        }
        void load_listbox()
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listView1.Items.Add(ds.Tables[0].Rows[i]["hoten"].ToString(),1);
                listView1.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["diachi"].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["tendangnhap"].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["quyenhan"].ToString());
                s[i] = ds.Tables[0].Rows[i]["manhanvien"].ToString();
                
            }
        }
        void load_textbox(int i)
        {
            txthoten.Text = listView1.Items[i].SubItems[0].Text; ;
            txtdiachi.Text = listView1.Items[i].SubItems[1].Text;
            txtmanv.Text = s[i];
            txttendangnhap.Text = listView1.Items[i].SubItems[2].Text;
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
            if (i != ds.Tables[0].Rows.Count - 1)
            {
                i = ds.Tables[0].Rows.Count - 1;
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
            if (i < ds.Tables[0].Rows.Count - 1)
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
                Lnhanvien nv = new Lnhanvien();
                nv.manhanvien = (txtmanv.Text);
                if (nv.XoaBo() == true)
                {
                    MessageBox.Show("Bạn đã xoá bỏ thành công");
                    listView1.Items[i].Remove();
                    DataRow dr = ds.Tables[0].Rows.Find(txtmanv.Text);
                    ds.Tables[0].Rows.Remove(dr);
                    for (int j = i; j < ds.Tables[0].Rows.Count - 1; j++)
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
                txtdiachi.Enabled = false;
                txthoten.Enabled = false;
                txttendangnhap.Enabled = false;
                comboBox1.Enabled = false;
                Lnhanvien nv = new Lnhanvien();
                nv.manhanvien = (txtmanv.Text);
                nv.matkhau = ("");
                nv.diachi = (txtdiachi.Text);
                nv.hoten = (txthoten.Text);
                nv.quyenhan = (comboBox1.Text);
                nv.tendangnhap = (txttendangnhap.Text);
                i = ds.Tables[0].Rows.Count;
                if (nv.TaoMoi())
                {
                    s[i] = txtmanv.Text;
                    //======cập nhật thông tin cho Dataset===========
                    DataRow dr ;
                    dr = ds.Tables[0].NewRow();
                    dr[0] = txtmanv.Text;
                    dr[1] = txthoten.Text;
                    dr[2] = txtdiachi.Text;
                    dr[3] = txttendangnhap.Text;
                    dr[4] = "";
                    dr[5] = comboBox1.Text;
                    ds.Tables[0].Rows.Add(dr);
                    //-------------------------------

                    //======Cập nhật thông tin cho Listview==========
                    listView1.Items.Add(txthoten.Text, 1);
                    listView1.Items[i].SubItems.Add(txtdiachi.Text);
                    listView1.Items[i].SubItems.Add(txttendangnhap.Text);
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
                txtdiachi.Enabled = true;
                txthoten.Enabled = true;
                txttendangnhap.Enabled = true;
                comboBox1.Enabled = true;
                txtdiachi.Text = "";
                txthoten.Text = "";
                txttendangnhap.Text = "";
                txtmanv.Text = taoma(s[ds.Tables[0].Rows.Count-1]);
            }
        }

        private void Frmtaomoitk_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
            Frmmain.hf.set_text(Frmhelpfast.t);
            Frmmain.hf.set_anh(1);
        }
    }
}