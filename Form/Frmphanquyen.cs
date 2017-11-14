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
using quanlythuvien.Data;

namespace quanly.frm
{
    public partial class Frmphanquyen : Form
    {
        public Frmphanquyen()
        {
            InitializeComponent();
        }

        private void Frmphanquyen_Load(object sender, EventArgs e)
        {
            try
            {
                Frmmain.tt = true;
                Load_TreeNode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Load_TreeNode()
        {
            try
            {
                TreeNode n = new TreeNode();
                n.Tag = "Ro";
                n.Text = "Danh sach nhân viên";
                n.ImageIndex = 0;
                treeView1.Nodes.Add(n);
                string query = "select TenDangNhap,IDNhanVien from NhanVien";
                DataTable dt = DataProvider.ExecuteQuery(query);
                foreach (DataRow dr in dt.Rows)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = "E" + dr["IDNhanVien"].ToString();
                    tn.Text = dr["TenDangNhap"].ToString();
                    tn.ImageIndex = 1;
                    n.Nodes.Add(tn);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string selectTag = e.Node.Tag.ToString();
                int id = 0;
                if (selectTag != "Ro")
                {
                    id = Convert.ToInt32(selectTag.Substring(1, selectTag.Length - 1));
                }
                Load_ThongTin_NhanVien(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Load_ThongTin_NhanVien(int id)
        {
            try
            {
                listView1.Items[0].Checked = false;
                listView1.Items[1].Checked = false;
                listView1.Items[2].Checked = false;
                listView1.Items[3].Checked = false;
                string str = treeView1.SelectedNode.Tag.ToString();
                if (str != "Ro")
                {
                    NhanVien nv = NhanVien.GetNhanVienTheoID(id);
                    txtHoTen.Text = nv.HoTen;
                    txtDiaChi.Text = nv.DiaChi;
                    txtTenDangNhap.Text = nv.TenDangNhap;
                    if(nv.QuyenHan.Contains("ADMIN")) listView1.Items[3].Checked = true;
                    if (nv.QuyenHan.Contains("THUKHO")) listView1.Items[0].Checked = true;
                    if (nv.QuyenHan.Contains("MUONTRA")) listView1.Items[1].Checked = true;
                    if (nv.QuyenHan.Contains("QUANLY")) listView1.Items[2].Checked = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSetQuyen_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedTag = treeView1.SelectedNode.Tag.ToString();
                if (selectedTag != "Ro")
                {
                    if (btnSetQuyen.Text == "Phân quyền")
                    {
                        listView1.Enabled = true;
                        btnSetQuyen.Text = "OK";
                    }
                    else
                    {
                        List<string> list = new List<string>();
                        for (int i = 0; i < listView1.CheckedItems.Count; i++) list.Add(listView1.CheckedItems[i].Text);
                        string strQuyen = string.Join(",", list.ToArray());
                        MessageBox.Show(strQuyen);
                        if (strQuyen != "")
                        {
                            int idNhanVien = Convert.ToInt32((selectedTag.Substring(1, selectedTag.Length - 1)));
                            NhanVien nv = NhanVien.GetNhanVienTheoID(idNhanVien);
                            nv.QuyenHan = strQuyen;
                            if (NhanVien.CapNhat(nv))
                            {
                                btnSetQuyen.Text = "Phân quyền";
                                listView1.Enabled = false;
                                MessageBox.Show("Cấp quyền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Frmphanquyen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }


    }
}