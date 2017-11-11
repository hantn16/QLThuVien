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
    public partial class FrmTheLoaisach : Form
    {
        public FrmTheLoaisach()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmTheLoaisach_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true; Load_treeview();

        }
        private void Load_treeview()
        {
            laydulieu dl = new laydulieu();
            SqlDataReader dr = dl.lay_reader("select * from TheLoai");
            while(dr.Read())
            {
                TreeNode tn = new TreeNode();
                tn.Tag =dr[0].ToString();
                tn.Text = dr[1].ToString();
                tn.ImageIndex = 1;
                treeView1.Nodes.Add(tn);
                cbTheLoaiSach.Items.Add(dr[1].ToString());
                
            }
            L_Ketnoi.HuyKetNoi();
            foreach (TreeNode n in treeView1.Nodes)
            {
                laydulieu dl1 = new laydulieu();
                SqlDataReader dr1 = dl1.lay_reader("select * from sach where MaTheLoai='" + n.Tag.ToString().Trim() + "'");
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
        TaiLieu s = new TaiLieu();
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string str = treeView1.SelectedNode.Tag.ToString();
            if (str.Substring(0, 2) != "PL")
            {
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select MaTaiLieu,NhanDe,TenTacGia,LanXuatBan,loai,NamXuatBan from sach,TacGia,TheLoai where sach.MaTacGia = TacGia.MaTacGia and sach.MaTheLoai = TheLoai.MaTheLoai and MaTaiLieu='" + str + "'");
                while (dr.Read())
                {
                    lbtensach.Text = dr["NhanDe"].ToString();
                    lbTacGia.Text = dr["TenTacGia"].ToString();
                    lbtaiban.Text = dr["LanXuatBan"].ToString();
                    lbNamXuatBan.Text = dr["NamXuatBan"].ToString();
                    lbMaTaiLieu.Text = dr["MaTaiLieu"].ToString();
                    cbTheLoaiSach.Text = dr["loai"].ToString();
                    s.MaTaiLieu = (dr["MaTaiLieu"].ToString());
                }
                L_Ketnoi.HuyKetNoi();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (btTheLoai.Text == "OK")
            {
                btTheLoai.Text = "Phân loại";
                cbTheLoaiSach.Enabled = false;
                string str = treeView1.SelectedNode.Tag.ToString();
                if (str.Substring(0, 2) == "PL") MessageBox.Show("Bạn phải chọn sách cần đổi");
                else
                {
                    if (s.TheLoai(cbTheLoaiSach.Text))
                    {
                       
                        string str1 = treeView1.SelectedNode.Tag.ToString();
                        string str2 = treeView1.SelectedNode.Text;
                        treeView1.SelectedNode.Remove();
                        while(true)
                        {
                            if (treeView1.Nodes[i].Text == cbTheLoaiSach.Text)
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
                btTheLoai.Text = "OK";
                cbTheLoaiSach.Enabled = true;
            }
        }

        private void FrmTheLoaisach_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }
    }
}