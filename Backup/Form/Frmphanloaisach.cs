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
    public partial class Frmphanloaisach : Form
    {
        public Frmphanloaisach()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Frmphanloaisach_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true; Load_treeview();

        }
        private void Load_treeview()
        {
            laydulieu dl = new laydulieu();
            SqlDataReader dr = dl.lay_reader("select * from phanloai");
            while(dr.Read())
            {
                TreeNode tn = new TreeNode();
                tn.Tag =dr[0].ToString();
                tn.Text = dr[1].ToString();
                tn.ImageIndex = 1;
                treeView1.Nodes.Add(tn);
                comboBox1.Items.Add(dr[1].ToString());
                
            }
            L_Ketnoi.HuyKetNoi();
            foreach (TreeNode n in treeView1.Nodes)
            {
                laydulieu dl1 = new laydulieu();
                SqlDataReader dr1 = dl1.lay_reader("select * from sach where maphanloai='" + n.Tag.ToString().Trim() + "'");
                while (dr1.Read())
                {
                    TreeNode tn1 = new TreeNode();
                    tn1.Tag = dr1[0].ToString();
                    tn1.Text = dr1[1].ToString();
                    tn1.ImageIndex = 0;
                    n.Nodes.Add(tn1);
                }
                L_Ketnoi.HuyKetNoi();
            }            
        }
        Lsach s = new Lsach();
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string str = treeView1.SelectedNode.Tag.ToString();
            if (str.Substring(0, 2) != "PL")
            {
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select masach,nhande,tentacgia,lanxb,loai,namxb from sach,tacgia,phanloai where sach.matacgia = tacgia.matacgia and sach.maphanloai = phanloai.maphanloai and masach='" + str + "'");
                while (dr.Read())
                {
                    lbtensach.Text = dr["nhande"].ToString();
                    lbtacgia.Text = dr["tentacgia"].ToString();
                    lbtaiban.Text = dr["lanxb"].ToString();
                    lbnamxb.Text = dr["namxb"].ToString();
                    lbmasach.Text = dr["masach"].ToString();
                    comboBox1.Text = dr["loai"].ToString();
                    s.set_masach(dr["masach"].ToString());
                }
                L_Ketnoi.HuyKetNoi();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (btphanloai.Text == "OK")
            {
                btphanloai.Text = "Phân loại";
                comboBox1.Enabled = false;
                string str = treeView1.SelectedNode.Tag.ToString();
                if (str.Substring(0, 2) == "PL") MessageBox.Show("Bạn phải chọn sách cần đổi");
                else
                {
                    if (s.phanloai(comboBox1.Text))
                    {
                       
                        string str1 = treeView1.SelectedNode.Tag.ToString();
                        string str2 = treeView1.SelectedNode.Text;
                        treeView1.SelectedNode.Remove();
                        while(true)
                        {
                            if (treeView1.Nodes[i].Text == comboBox1.Text)
                            {
                                TreeNode n1 = new TreeNode();
                                n1.Tag = str1;
                                n1.Text = str2;
                                n1.ImageIndex = 0;
                                treeView1.Nodes[i].Nodes.Add(n1);
                                break;
                                
                            }
                            i++;
                        }
                        MessageBox.Show("Bạn đã chuyển đổi thành công");
                    }
                }
            }
            else
            {
                btphanloai.Text = "OK";
                comboBox1.Enabled = true;
            }
        }

        private void Frmphanloaisach_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }
    }
}