using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using quanly.doituong;
using System.IO;
namespace quanly.frm
{
    public partial class Frmquanlybandoc : Form
    {
        public Frmquanlybandoc()
        {
            InitializeComponent();
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataSet ds;
        CurrencyManager cm;
        public static int i = 0;
        private void Frmquanlybandoc_Load(object sender, EventArgs e)
        {
            set_giattri();
        }
        public void set_giattri()
        {
            Frmmain.tt = true;
            laydulieu dl = new laydulieu();
            ds = dl.getdata("select * from khoa;select * from docgia");
            DataRelation dr = new DataRelation("Danh sách sinh viên", ds.Tables[0].Columns["makhoa"], ds.Tables[1].Columns["makhoa"]);
            ds.Relations.Add(dr);
            cm = BindingContext[this.ds.Tables[1]] as CurrencyManager;
            dataGrid1.DataSource = ds.Tables[0];
            txttenkhoa.Items.Clear();
            laydulieu dl1 = new laydulieu();
            SqlDataReader dr1 = dl1.lay_reader("select tenkhoa from khoa");
            while (dr1.Read())
                txttenkhoa.Items.Add(dr1[0].ToString());
            L_Ketnoi.HuyKetNoi();
            load_text(i);
        }
        void load_text(int i)
        {
            txtdiachi.Text = ds.Tables[1].Rows[i]["diachi"].ToString();
            txthoten.Text = ds.Tables[1].Rows[i]["hoten"].ToString();
            txtmadocgia.Text = ds.Tables[1].Rows[i]["madocgia"].ToString();
            txtngaylapthe.Text = DateTime.Parse(ds.Tables[1].Rows[i]["ngaylapthe"].ToString()).ToShortDateString();
            txtngaysinh.Text = DateTime.Parse(ds.Tables[1].Rows[i]["ngaysinh"].ToString()).ToShortDateString();
            txtvitri.Text = ds.Tables[1].Rows[i]["vitri"].ToString();
            laydulieu layd = new laydulieu();
            SqlDataReader drr = layd.lay_reader("select tenkhoa from khoa where makhoa ='" + ds.Tables[1].Rows[i]["makhoa"].ToString()+"'");
            while (drr.Read())
                txttenkhoa.Text = drr[0].ToString();
            L_Ketnoi.HuyKetNoi();
        }
        #region Di chuyển
        private void btlast_Click(object sender, EventArgs e)
        {
            cm.Position = 0;
            load_text(0);
        }

        private void btpreview_Click(object sender, EventArgs e)
        {
            if (cm.Position > 0) cm.Position -= 1;
            load_text(cm.Position);
        }

        private void btnext_Click(object sender, EventArgs e)
        {
            if (cm.Position < cm.Count) cm.Position += 1;
            load_text(cm.Position);
        }

        private void bttop_Click(object sender, EventArgs e)
        {
            cm.Position = cm.Count;
            load_text(cm.Position);
        }
        #endregion
        #region Các thủ tục cập nhật , chèn , xoá
        private void bttaomoi_Click(object sender, EventArgs e)
        {
            if (bttaomoi.Text == "OK")
            {
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select makhoa from khoa where tenkhoa=N'" + txttenkhoa.Text + "'");
                string tam = "";
                while (dr.Read())
                    tam = dr[0].ToString();
                L_Ketnoi.HuyKetNoi();
                if (tam == "") MessageBox.Show("Bạn hãy kiểm tra lại giá trị khoa");
                else
                {
                    try
                    {
                        DateTime ns = DateTime.Parse(DateTime.Parse(txtngaysinh.Text).ToShortDateString());
                        Lbandoc bd = new Lbandoc(txtmadocgia.Text, txthoten.Text, tam, txtvitri.Text, txtdiachi.Text, ns, DateTime.Parse(txtngaylapthe.Text));
                        if (bd.taomoi())
                        {
                            txtdiachi.Enabled = txthoten.Enabled = txtngaysinh.Enabled = txttenkhoa.Enabled = txtvitri.Enabled = false;
                            bttaomoi.Text = "Tạo mới";
                            btcapnhat.Enabled = btxoabo.Enabled = true;
                            ctcapnhat.Enabled = cttaomoi.Enabled = ctxoabo.Enabled = ctchondoituong.Enabled = true;
                            Frmquanlybandoc_Load(sender, e);
                            MessageBox.Show("Quá trình tạo mới hoàn thành");
                            Frmmain.hf.timer5.Enabled = true;
                            Frmmain.hf.set_text("     OK làm tốt lắm !");
                            Frmmain.hf.set_anh(3);
                        }
                        else MessageBox.Show("Bị lỗi hãy kiểm tra lại thông tin");
                    }
                    catch 
                    {
                        Frmmain.hf.set_anh(2);
                        Frmmain.hf.set_text("     Chú ý ngày sinh có dạng như sau : ngày/tháng/năm nhập lại cho đúng đi ");
                        Frmmain.hf.timer5.Enabled = true;
                    }
                }
            }
            else
            {
                txtdiachi.Enabled = txthoten.Enabled = txtngaysinh.Enabled = txttenkhoa.Enabled = txtvitri.Enabled = true;
                txtdiachi.Text = txthoten.Text = txtngaysinh.Text = txtvitri.Text = "";
                txtngaylapthe.Text = DateTime.Now.ToShortDateString();
                bttaomoi.Text = "OK";
                string macuoi = taoma(ds.Tables[1].Rows[cm.Count - 1]["madocgia"].ToString());
                txtmadocgia.Text = macuoi;
                btcapnhat.Enabled = btxoabo.Enabled = false;
                ctcapnhat.Enabled = cttaomoi.Enabled = ctxoabo.Enabled = ctchondoituong.Enabled = false;
            }
        }
        private void btxoabo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xoá độc giả này ra khỏi danh sách không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Lbandoc bd = new Lbandoc();
                bd.set_madocgia(txtmadocgia.Text);
                if (bd.xoabo())
                {
                    i--;
                    Frmquanlybandoc_Load(sender, e);
                    MessageBox.Show("Đã xoá thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Xoá thất bại hãy kiểm tra lại thao tác");
                }
            }
        }
        private void btcapnhat_Click(object sender, EventArgs e)
        {
            if (btcapnhat.Text == "OK")
            {
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select makhoa from khoa where tenkhoa=N'" + txttenkhoa.Text + "'");
                string tam = "";
                while (dr.Read())
                    tam = dr[0].ToString();
                L_Ketnoi.HuyKetNoi();
                if (tam == "") MessageBox.Show("Bạn hãy kiểm tra lại giá trị khoa");
                else
                {
                    try
                    {
                        DateTime ns = DateTime.Parse(DateTime.Parse(txtngaysinh.Text).ToShortDateString());
                        Lbandoc bd = new Lbandoc(txtmadocgia.Text, txthoten.Text, tam, txtvitri.Text, txtdiachi.Text, ns, DateTime.Parse(txtngaylapthe.Text));
                        if (bd.capnhat())
                        {
                            txtngaylapthe.Enabled = txtdiachi.Enabled = txthoten.Enabled = txtngaysinh.Enabled = txttenkhoa.Enabled = txtvitri.Enabled = false;
                            btcapnhat.Text = "Cập nhật";
                            bttaomoi.Enabled = btxoabo.Enabled = true;
                            ctcapnhat.Enabled = cttaomoi.Enabled = ctxoabo.Enabled = ctchondoituong.Enabled = true;
                            Frmquanlybandoc_Load(sender, e);
                            MessageBox.Show("Quá trình cập nhật hoàn thành");
                        }
                        else MessageBox.Show("Bị lỗi hãy kiểm tra lại thông tin");
                    }
                    catch { MessageBox.Show("Nhập lại giá trị ngày sinh"); }
                }
            }
            else
            {
                txtngaylapthe.Enabled = txtdiachi.Enabled = txthoten.Enabled = txtngaysinh.Enabled = txttenkhoa.Enabled = txtvitri.Enabled = true;
                btcapnhat.Text = "OK";
                bttaomoi.Enabled = btxoabo.Enabled = false;
                ctcapnhat.Enabled = cttaomoi.Enabled = ctxoabo.Enabled = ctchondoituong.Enabled = false;
            }
        }
        #endregion
        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ctchondoituong.Text == "Chọn đối tượng")
            {
                txtmadocgia.Enabled = true;
                ctchondoituong.Text = "Thực hiện";
                btcapnhat.Enabled = btxoabo.Enabled = bttaomoi.Enabled = false;
                ctcapnhat.Enabled = cttaomoi.Enabled = ctxoabo.Enabled = false;
            }
            else
            {
                txtmadocgia.Enabled = false;
                ctchondoituong.Text = "Chọn đối tượng";
                btcapnhat.Enabled = btxoabo.Enabled = bttaomoi.Enabled = true;
                ctcapnhat.Enabled = cttaomoi.Enabled = ctxoabo.Enabled = true;
                DataView dv = new DataView();
                dv.Table = ds.Tables[1];
                dv.RowFilter = "madocgia='"+ txtmadocgia.Text+"'";
                if (dv.Count == 0) MessageBox.Show("Bạn hãy kiểm tra lại mã vừa nhập", "Thông báo");
                else 
                {
                    txtdiachi.Text = dv[0]["diachi"].ToString();
                    txthoten.Text = dv[0]["hoten"].ToString();
                    txtmadocgia.Text = dv[0]["madocgia"].ToString();
                    txtngaylapthe.Text = DateTime.Parse(dv[0]["ngaylapthe"].ToString()).ToShortDateString();
                    txtngaysinh.Text = DateTime.Parse(dv[0]["ngaysinh"].ToString()).ToShortDateString();
                    txtvitri.Text = dv[0]["vitri"].ToString();
                }
            }
        }
        string taoma(string ma)
        {
            string s = ma.Substring(2, ma.Length - 2);
            int i = int.Parse(s);
            i++;
            if (i < 10) return "DG0000" + Convert.ToString(i);
            else
                if (i < 100) return "DG000" + Convert.ToString(i);
                else
                    if (i < 1000) return "DG00" + Convert.ToString(i);
                    else
                        if (i < 10000) return "DG0" + Convert.ToString(i);
                        else return "DG" + Convert.ToString(i);

        }

        private void Frmquanlybandoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
            Frmmain.hf.set_text(Frmhelpfast.t);
            Frmmain.hf.set_anh(1);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            try
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.WriteLine("==========Thông tin của độc giả thư viện===========");
                sw.WriteLine("--------------------------------------------------");
                sw.WriteLine("| Mã độc giả  :        " + txtmadocgia.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Họ tên      :        " + txthoten.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Địa chỉ     :        " + txtdiachi.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Ngày sinh   :        " + txtngaysinh.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Ngày lập thẻ:        " + txtngaylapthe.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Tên khoa    :        " + txttenkhoa.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Vị trí      :        " + txtvitri.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.Close();
            }
            catch { };
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                if (dataGrid1[dataGrid1.CurrentCell].ToString().Substring(0, 2) == "DG")
                    while (ds.Tables[1].Rows[i][0].ToString() != dataGrid1[dataGrid1.CurrentCell].ToString())
                        i++;
                load_text(i);
                cm.Position = i;
            }
            catch { }
        }

        private void txtmadocgia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) hToolStripMenuItem_Click(sender, e);
        }
        
    }
}