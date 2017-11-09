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
    public partial class Frmphanquyen : Form
    {
        public Frmphanquyen()
        {
            InitializeComponent();
        }
        SqlDataReader dr;
        
        private void Frmphanquyen_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true; 
            laydulieu dl = new laydulieu();
            TreeNode n = new TreeNode();
            n.Tag = "Ro";
            n.Text = "Danh sach nhân viên";
            n.ImageIndex = 0;
            treeView1.Nodes.Add(n);
            dr = dl.lay_reader("select TenDangNhap,MaNhanVien from NhanVien");
           
            while(dr.Read())
            {
                TreeNode tn = new TreeNode();
                tn.Tag = "E" + dr[1].ToString();
                tn.Text = dr[0].ToString();
                tn.ImageIndex = 1;
                n.Nodes.Add(tn);
            }
            L_Ketnoi.HuyKetNoi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Items[0].Checked = false;
            listView1.Items[1].Checked = false;
            listView1.Items[2].Checked = false;
            listView1.Items[3].Checked = false;
            string str = treeView1.SelectedNode.Tag.ToString();
            if (str != "Ro")
            {
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select TenDangNhap,MaNhanVien,HoTen,QuyenHan from NhanVien where MaNhanVien='" + str.Substring(1, str.Length - 1) + "'");
                while (dr.Read())
                {
                    txtHoTen.Text = dr[2].ToString();
                    txtMaNhanVien.Text = dr[1].ToString();
                    txtTenDangNhap.Text = dr[0].ToString();
                    if (dr[3].ToString().Trim() == "ADMIN") listView1.Items[3].Checked=true;
                    else
                    {
                        if (dr[3].ToString().IndexOf("THUKHO") >= 0) listView1.Items[0].Checked = true;
                        if (dr[3].ToString().IndexOf("MUONTRA") >= 0) listView1.Items[1].Checked = true;
                        if (dr[3].ToString().IndexOf("QUANLY") >= 0) listView1.Items[2].Checked = true;
                    }
                    
                }
                L_Ketnoi.HuyKetNoi();
            }

        }
        bool tam = true;
        private void button1_Click(object sender, EventArgs e)
        {
                string str = treeView1.SelectedNode.Tag.ToString();
                if (str != "Ro")
                {
                    if (tam)
                    {
                        listView1.Enabled = true;
                        tam = false;
                        button1.Text = "OK";
                    }
                    else
                    {
                        string st = "";
                        for (int i = 0; i < listView1.CheckedItems.Count; i++)
                            st = st + listView1.CheckedItems[i].Text;
                        MessageBox.Show(st);
                        if (st != "")
                        {
                            NhanVien nv = new NhanVien();
                            nv.MaNhanVien= (str.Substring(1, str.Length - 1));
                            if(st.IndexOf("ADMIN") >=0)
                                  nv.NangQuyen("ADMIN");
                            else
                                 nv.NangQuyen(st);
                            button1.Text = "Phân quyền";
                            tam = true;
                            listView1.Enabled = false;
                            MessageBox.Show("Đã thực hiện thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        else
                        {
                            MessageBox.Show("Hãy kiểm tra lại giá trị quyền hạn", "Thông báo");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo");
                }
            }
           
        private void Frmphanquyen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }

        
    }
}