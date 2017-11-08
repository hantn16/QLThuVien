using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using System.Data.SqlClient;


namespace quanly.frm
{
    public partial class Formhienthi : Form
    {
        private SqlCommand cmd;
        private SqlDataAdapter da = new SqlDataAdapter();
        private DataSet ds = new DataSet();
        private CurrencyManager bmb;
        private SqlCommandBuilder cb;
        public static string chuoiketnoi = "";
        public static string bangketnoi = "";

        public Formhienthi()
        {
            InitializeComponent();
        }
        
        private void Formhienthi_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
            try
            {
                L_Ketnoi.ThietlapketNoi();
                cmd = new SqlCommand(chuoiketnoi, L_Ketnoi.cn);
                da.SelectCommand = cmd;
                da.Fill(ds, bangketnoi);
                bmb = BindingContext[this.ds.Tables[0]] as CurrencyManager;
                this.dghienthi.DataSource = ds.Tables[0];
                switch (bangketnoi)
                {
                    case "tacgia": this.cbdanhmuc.Items.AddRange(new object[] { "tentacgia" }); break;
                    case "phanloai": this.cbdanhmuc.Items.AddRange(new object[] { "loai" }); break;
                    case "nhaxuatban": this.cbdanhmuc.Items.AddRange(new object[] { "ten" }); break;
                    case "ngonngu": this.cbdanhmuc.Items.AddRange(new object[] { "ngonngu" }); break;
                    case "khoa": this.cbdanhmuc.Items.AddRange(new object[] { "tenkhoa" }); break;
                };

            }
            catch { MessageBox.Show("error: ket noi du lieu "); }


        }
        //------Bat su kien nhan enter trong textbox tim kiem
        private void tbtimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { bttimkiem_Click(sender, e); }
        }

        private void bttimkiem_Click(object sender, EventArgs e)
        {
            if (cbdanhmuc.Text == "") 
            {
                MessageBox.Show("Ban  phai chon muc tim kiem");
                
            }
            else
            {
                string chuoitimkiem;
                chuoitimkiem = chuoiketnoi + " where " + cbdanhmuc.Text + " like '%" + tbtimkiem.Text + "%'";
                cmd = new SqlCommand(chuoitimkiem, L_Ketnoi.cn);
                ds.Clear();
                da.SelectCommand = cmd;
                da.Fill(ds, bangketnoi);
                bmb = BindingContext[ds.Tables[bangketnoi]] as CurrencyManager;
                this.dghienthi.DataSource = ds.Tables[bangketnoi];
                this.dghienthi.Refresh();

            }
        }
        private void capnhat()
        {
            if (MessageBox.Show("Ban co muon luu lai su thay doi du lieu", "Thong bao", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                try
                {
                    cb = new SqlCommandBuilder(da);
                    da.Update(ds, bangketnoi);
                }
                catch { MessageBox.Show("hay kiem tra lai tinh dung dan cua du lieu"); }
            }
        }
        private void btcapnhat_Click(object sender, EventArgs e)
        {
            this.capnhat();
        }
        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban that su muon xoa ?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    laydulieu dl = new laydulieu();
                    bmb.RemoveAt(bmb.Position);
                     cb = new SqlCommandBuilder(da);
                    da.Update(ds, bangketnoi);
                    MessageBox.Show("Ban da xoa thanh cong");
                }
                catch { MessageBox.Show("hay kiem tra lai tinh dung dan cua du lieu"); }
                    
                  }
        }

        private void Formhienthi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ds.GetChanges() != null)
            {
               if (MessageBox.Show("Đã có sự thay đổi dữ liệu bạn có muốn lưu lại hay không ?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                   this.capnhat();
            }
            L_Ketnoi.HuyKetNoi();
        }

        private void dghienthi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46) btxoa_Click(sender, e);
        }

        private void bttaomoi_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds1;
                laydulieu dl = new laydulieu();
                ds1 = dl.getdata("select * from " + bangketnoi);
                string strmacuoi = ds1.Tables[0].Rows[ds1.Tables[0].Rows.Count - 1][0].ToString();
                if (bttaomoi.Text == "OK")
                {
                    this.capnhat();
                    bttaomoi.Text = "Tạo mới";


                }
                else
                {
                    DataRow tam;
                    tam = ds.Tables[0].NewRow();
                    tam[0] = macuoi(strmacuoi);
                    ds.Tables[0].Rows.Add(tam);
                    bttaomoi.Text = "OK";
                }
            }
            catch { }
        }
        string macuoi(string ma)
        {
            string tam = ma.Substring(0, 2);
            int i = int.Parse(ma.Substring(2, ma.Length - 2));
            i++;
            if (i < 10) return (tam + "00" + i.ToString());
            else
                if (i < 100) return (tam + "0" + i.ToString());
                else  return (tam + i.ToString());
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
             if (ds.GetChanges() != null) this.capnhat();
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