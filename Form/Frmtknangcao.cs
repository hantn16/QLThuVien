using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using System.Data.SqlClient;
using quanlythuvien;
using quanly.DoiTuong;
using quanlythuvien.Data;
using QLTV.GUI.DoiTuong;
using quanlythuvien.DoiTuong;

namespace quanly.frm
{
    public partial class Frmtknangcao : Form
    {
        public Frmtknangcao()
        {
            InitializeComponent();
        }
        private void Frmtknangcao_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true; 
            Load_combobox();
        }
        private void cbTimTheo_SelectedValueChanged(object sender, EventArgs e)
        {
            
            string selectedText = cbTimTheo.SelectedValue.ToString();
            Set_CbLoaiTimTheo(selectedText);

        }
        void Set_CbLoaiTimTheo(string loai = "TacGia")
        {
            
            switch (loai)
            {
                case "NgonNgu":
                    {
                        lbTimTheo.Visible = cbLoaiTimTheo.Visible = true;
                        lbTimTheo.Text = "Chọn ngôn ngữ";
                        cbLoaiTimTheo.DataSource = NgonNgu.LayDSNgonNgu();
                        cbLoaiTimTheo.ValueMember = "IDNgonNgu";
                        cbLoaiTimTheo.DisplayMember = "TenNgonNgu";
                        break;
                    }
                case "NhaXuatBan":
                    {
                        lbTimTheo.Visible = cbLoaiTimTheo.Visible = true;
                        lbTimTheo.Text = "Chọn NXB";
                        cbLoaiTimTheo.DataSource = NhaXuatBan.LayDSNhaXuatBan();
                        cbLoaiTimTheo.ValueMember = "IDNhaXuatBan";
                        cbLoaiTimTheo.DisplayMember = "TenNhaXuatBan";
                        break;
                    }
                case "GiaXep":
                    {
                        lbTimTheo.Visible = cbLoaiTimTheo.Visible = true;
                        lbTimTheo.Text = "Chọn giá xếp";
                        cbLoaiTimTheo.DataSource = GiaXep.GetDSGiaXep();
                        cbLoaiTimTheo.ValueMember = "IDGiaXep";
                        cbLoaiTimTheo.DisplayMember = "MaGiaXep";
                        break;
                    }
                case "TheLoai":
                    {
                        lbTimTheo.Visible = cbLoaiTimTheo.Visible = true;
                        lbTimTheo.Text = "Chọn thể loại";
                        cbLoaiTimTheo.DataSource = TheLoai.GetDanhSachTheLoai();
                        cbLoaiTimTheo.ValueMember = "IDTheLoai";
                        cbLoaiTimTheo.DisplayMember = "TenTheLoai";
                        break;
                    }
                case "TacGia":
                    {

                        lbTimTheo.Visible = cbLoaiTimTheo.Visible = true;
                        lbTimTheo.Text = "Chọn tác giả";
                        cbLoaiTimTheo.DataSource = TacGia.LayDSTacGia();
                        cbLoaiTimTheo.ValueMember = "IDTacGia";
                        cbLoaiTimTheo.DisplayMember = "TenTacGia";
                        break;


                    }
                default:
                    {
                        lbTimTheo.Visible = cbLoaiTimTheo.Visible = false;
                        lbTimTheo.Text = "TatCa";
                        cbLoaiTimTheo.DataSource = new int[] { 0 };
                        break;
                    }
            }
        }
        void Load_combobox()
        {
            //DataTable dtTheLoai = DataProvider.ExecuteQuery("select * from TheLoai");
            string[] listTheLoaiTim = new string[] { "Tác giả", "Ngôn ngữ", "Nhà xuất bản", "Giá xếp", "Thể loại" };
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("TatCa", "Chọn loại tìm kiếm"));
            list.Add(new KeyValuePair<string, string>("TheLoai", "Thể loại"));
            list.Add(new KeyValuePair<string, string>("TacGia", "Tác Giả"));
            list.Add(new KeyValuePair<string, string>("NgonNgu", "Ngôn Ngữ"));
            list.Add(new KeyValuePair<string, string>("NhaXuatBan", "Nhà xuất bản"));
            list.Add(new KeyValuePair<string, string>("GiaXep", "Giá xếp"));
            cbTimTheo.DataSource = list;
            cbTimTheo.ValueMember = "Key";
            cbTimTheo.DisplayMember = "Value";
            cbTimTheo.SelectedItem = list[0];
            Set_CbLoaiTimTheo(list[0].Key);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                TimKiem tk = new TimKiem();
                DataTable dt = tk.TKNangCao(txtTimKiem.Text, cbTimTheo.SelectedValue.ToString(), Convert.ToInt32(cbLoaiTimTheo.SelectedValue));
                dgvListTaiLieu.DataSource = dt;
                dgvListTaiLieu.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //dataGridView1.DataSource = ds.Tables[0];
            //cm = BindingContext[this.ds.Tables[0]] as CurrencyManager;
            //label5.Text = cm.Count.ToString();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCapNhatsach frm = new FrmCapNhatsach();
                frm.selectedID = Convert.ToInt32(dgvListTaiLieu.SelectedCells[0].OwningRow.Cells["ID"].Value);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) btnTimKiem_Click(sender, e);
        }

        private void Frmtknangcao_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }
        private void dataGridView1_CellMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                timer1.Enabled = true;
                //dg.set_giatri(ds.Tables[0].Rows[cm.Position][1].ToString(), ds.Tables[0].Rows[cm.Position][2].ToString(), ds.Tables[0].Rows[cm.Position][4].ToString(), ds.Tables[0].Rows[cm.Position][5].ToString(), ds.Tables[0].Rows[cm.Position][6].ToString(), ds.Tables[0].Rows[cm.Position][7].ToString());
                //dg.Show();
               
             }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //dg.set_point(MousePosition.X, MousePosition.Y - 197);
        }

        private void dgvListTaiLieu_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgvListTaiLieu.DataSource;
                lbSoBanGhi.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}