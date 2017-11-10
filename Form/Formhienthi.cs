using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using System.Data.SqlClient;
using quanlythuvien.Data;

namespace quanly.frm
{
    public partial class Formhienthi : Form
    {
        private DataTable dataTable = new DataTable();
        private CurrencyManager bmb = null;
        public string ChuoiKetNoi { get; set; }
        public string BangKetNoi { get; set; }
        public string TenCotMa { get; set; }
        public string TenCotTen { get; set; }
        public string ActiveTab { get; set; }

        public Formhienthi()
        {
            InitializeComponent();
        }

        void SetActiveTab()
        {
            switch (this.ActiveTab)
            {
                case "TheLoai": this.tcHienThi.SelectedTab = tpTheLoai;break;
                case "NgonNgu": this.tcHienThi.SelectedTab = tpNgonNgu; break;
                case "Khoa": this.tcHienThi.SelectedTab = tpKhoa; break;
                case "NXB": this.tcHienThi.SelectedTab = tpNXB; break;
                default: this.tcHienThi.SelectedTab = tpTacGia;
                    break;
            }
        }
        private void Formhienthi_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
            try
            {
                SetActiveTab();
                dataTable = DataProvider.ExecuteQuery(ChuoiKetNoi);
                bmb = BindingContext[dataTable] as CurrencyManager;
                this.dgTacGia.DataSource = dataTable;
                AddBindingData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        /// <summary>
        /// Hàm binding dữ liệu giữa datagridview và các textbox
        /// </summary>
        private void AddBindingData()
        {
            txtMaTacGia.DataBindings.Add(new Binding("Text", dgTacGia.DataSource, this.TenCotMa));
            txtTenTacGia.DataBindings.Add(new Binding("Text", dgTacGia.DataSource, this.TenCotTen));
        }

        //------Bat su kien nhan enter trong textbox tim kiem
        private void tbtimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { bttimkiem_Click(sender, e); }
        }

        private void bttimkiem_Click(object sender, EventArgs e)
        {
            string chuoitimkiem = String.Format("{0} where TenTacGia like '%{1}%'", ChuoiKetNoi, txtTimKiemTacGia.Text);
            DataTable dt = DataProvider.ExecuteQuery(chuoitimkiem);
            this.dgTacGia.DataSource = dt;
            this.dgTacGia.Refresh();

        }
        private void CapNhat()
        {
            if (MessageBox.Show("Bạn có muốn cập nhật dữ liệu", "Thông báo", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                try
                {
                    //cb = new SqlCommandBuilder(da);
                    //da.Update(ds, BangKetNoi);
                }
                catch { MessageBox.Show("hay kiem tra lai tinh dung dan cua du lieu"); }
            }
        }
        private void btCapNhat_Click(object sender, EventArgs e)
        {
            this.CapNhat();
        }
        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban that su muon xoa ?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bmb.RemoveAt(bmb.Position);
                    //SqlDataAdapter da = new SqlDataAdapter();
                    //SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    //da.Update(dataTable, BangKetNoi);
                    //da.Update()
                    MessageBox.Show("Ban da xoa thanh cong");
                }
                catch { MessageBox.Show("hay kiem tra lai tinh dung dan cua du lieu"); }

            }
        }

        private void Formhienthi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataTable.GetChanges() != null)
            {
                if (MessageBox.Show("Đã có sự thay đổi dữ liệu bạn có muốn lưu lại hay không ?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.CapNhat();
            }
            L_Ketnoi.HuyKetNoi();
        }

        private void dghienthi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46) btxoa_Click(sender, e);
        }

        private void btTaoMoi_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = DataProvider.ExecuteQuery("select * from " + BangKetNoi);
                string strmacuoi = dt.Rows[dt.Rows.Count - 1][0].ToString();
                if (btnTaoMoiTacGia.Text == "OK")
                {
                    this.CapNhat();
                    btnTaoMoiTacGia.Text = "Tạo mới";


                }
                else
                {
                    DataRow tam;
                    tam = dt.NewRow();
                    tam[0] = TaoMaCuoi(strmacuoi);
                    dt.Rows.Add(tam);
                    btnTaoMoiTacGia.Text = "OK";
                    dgTacGia.Refresh();
                }
            }
            catch { }
        }
        string TaoMaCuoi(string ma)
        {
            string tam = ma.Substring(0, 2);
            int i = int.Parse(ma.Substring(2, ma.Length - 2));
            i++;
            return i.ToString("000");

        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataTable.GetChanges() != null) this.CapNhat();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Formhienthi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
            Frmmain.hf.set_text(Frmhelpfast.t);
            Frmmain.hf.set_anh(1);
        }



    }
}