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
using quanly.DoiTuong;

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
            ds = dl.getdata("select * from khoa;select * from DocGia");
            DataRelation dr = new DataRelation("Danh sách sinh viên", ds.Tables[0].Columns["MaKhoa"], ds.Tables[1].Columns["MaKhoa"]);
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
            txtDiaChi.Text = ds.Tables[1].Rows[i]["DiaChi"].ToString();
            txtHoTen.Text = ds.Tables[1].Rows[i]["HoTen"].ToString();
            txtMaDocGia.Text = ds.Tables[1].Rows[i]["MaDocGia"].ToString();
            txtNgayLapThe.Text = DateTime.Parse(ds.Tables[1].Rows[i]["NgayLapThe"].ToString()).ToShortDateString();
            txtNgaySinh.Text = DateTime.Parse(ds.Tables[1].Rows[i]["NgaySinh"].ToString()).ToShortDateString();
            txtViTri.Text = ds.Tables[1].Rows[i]["ViTri"].ToString();
            laydulieu layd = new laydulieu();
            SqlDataReader drr = layd.lay_reader("select tenkhoa from khoa where MaKhoa ='" + ds.Tables[1].Rows[i]["MaKhoa"].ToString()+"'");
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
        private void btTaoMoi_Click(object sender, EventArgs e)
        {
            if (btTaoMoi.Text == "OK")
            {
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select MaKhoa from khoa where tenkhoa=N'" + txttenkhoa.Text + "'");
                string tam = "";
                while (dr.Read())
                    tam = dr[0].ToString();
                L_Ketnoi.HuyKetNoi();
                if (tam == "") MessageBox.Show("Bạn hãy kiểm tra lại giá trị khoa");
                else
                {
                    try
                    {
                        DateTime ns = DateTime.Parse(DateTime.Parse(txtNgaySinh.Text).ToShortDateString());
                        BanDoc bd = new BanDoc(txtMaDocGia.Text, txtHoTen.Text, tam, txtViTri.Text, txtDiaChi.Text, ns, DateTime.Parse(txtNgayLapThe.Text));
                        if (bd.TaoMoi())
                        {
                            txtDiaChi.Enabled = txtHoTen.Enabled = txtNgaySinh.Enabled = txttenkhoa.Enabled = txtViTri.Enabled = false;
                            btTaoMoi.Text = "Tạo mới";
                            btCapNhat.Enabled = btXoaBo.Enabled = true;
                            ctCapNhat.Enabled = ctTaoMoi.Enabled = ctXoaBo.Enabled = ctchondoituong.Enabled = true;
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
                txtDiaChi.Enabled = txtHoTen.Enabled = txtNgaySinh.Enabled = txttenkhoa.Enabled = txtViTri.Enabled = true;
                txtDiaChi.Text = txtHoTen.Text = txtNgaySinh.Text = txtViTri.Text = "";
                txtNgayLapThe.Text = DateTime.Now.ToShortDateString();
                btTaoMoi.Text = "OK";
                string macuoi = taoma(ds.Tables[1].Rows[cm.Count - 1]["MaDocGia"].ToString());
                txtMaDocGia.Text = macuoi;
                btCapNhat.Enabled = btXoaBo.Enabled = false;
                ctCapNhat.Enabled = ctTaoMoi.Enabled = ctXoaBo.Enabled = ctchondoituong.Enabled = false;
            }
        }
        private void btXoaBo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xoá độc giả này ra khỏi danh sách không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BanDoc bd = new BanDoc();
                bd.MaDocGia = txtMaDocGia.Text;
                if (bd.XoaBo())
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
        private void btCapNhat_Click(object sender, EventArgs e)
        {
            if (btCapNhat.Text == "OK")
            {
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select MaKhoa from khoa where tenkhoa=N'" + txttenkhoa.Text + "'");
                string tam = "";
                while (dr.Read())
                    tam = dr[0].ToString();
                L_Ketnoi.HuyKetNoi();
                if (tam == "") MessageBox.Show("Bạn hãy kiểm tra lại giá trị khoa");
                else
                {
                    try
                    {
                        DateTime ns = DateTime.Parse(DateTime.Parse(txtNgaySinh.Text).ToShortDateString());
                        BanDoc bd = new BanDoc(txtMaDocGia.Text, txtHoTen.Text, tam, txtViTri.Text, txtDiaChi.Text, ns, DateTime.Parse(txtNgayLapThe.Text));
                        if (bd.CapNhat())
                        {
                            txtNgayLapThe.Enabled = txtDiaChi.Enabled = txtHoTen.Enabled = txtNgaySinh.Enabled = txttenkhoa.Enabled = txtViTri.Enabled = false;
                            btCapNhat.Text = "Cập nhật";
                            btTaoMoi.Enabled = btXoaBo.Enabled = true;
                            ctCapNhat.Enabled = ctTaoMoi.Enabled = ctXoaBo.Enabled = ctchondoituong.Enabled = true;
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
                txtNgayLapThe.Enabled = txtDiaChi.Enabled = txtHoTen.Enabled = txtNgaySinh.Enabled = txttenkhoa.Enabled = txtViTri.Enabled = true;
                btCapNhat.Text = "OK";
                btTaoMoi.Enabled = btXoaBo.Enabled = false;
                ctCapNhat.Enabled = ctTaoMoi.Enabled = ctXoaBo.Enabled = ctchondoituong.Enabled = false;
            }
        }
        #endregion
        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ctchondoituong.Text == "Chọn đối tượng")
            {
                txtMaDocGia.Enabled = true;
                ctchondoituong.Text = "Thực hiện";
                btCapNhat.Enabled = btXoaBo.Enabled = btTaoMoi.Enabled = false;
                ctCapNhat.Enabled = ctTaoMoi.Enabled = ctXoaBo.Enabled = false;
            }
            else
            {
                txtMaDocGia.Enabled = false;
                ctchondoituong.Text = "Chọn đối tượng";
                btCapNhat.Enabled = btXoaBo.Enabled = btTaoMoi.Enabled = true;
                ctCapNhat.Enabled = ctTaoMoi.Enabled = ctXoaBo.Enabled = true;
                DataView dv = new DataView();
                dv.Table = ds.Tables[1];
                dv.RowFilter = "MaDocGia='"+ txtMaDocGia.Text+"'";
                if (dv.Count == 0) MessageBox.Show("Bạn hãy kiểm tra lại mã vừa nhập", "Thông báo");
                else 
                {
                    txtDiaChi.Text = dv[0]["DiaChi"].ToString();
                    txtHoTen.Text = dv[0]["HoTen"].ToString();
                    txtMaDocGia.Text = dv[0]["MaDocGia"].ToString();
                    txtNgayLapThe.Text = DateTime.Parse(dv[0]["NgayLapThe"].ToString()).ToShortDateString();
                    txtNgaySinh.Text = DateTime.Parse(dv[0]["NgaySinh"].ToString()).ToShortDateString();
                    txtViTri.Text = dv[0]["ViTri"].ToString();
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
                sw.WriteLine("| Mã độc giả  :        " + txtMaDocGia.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Họ tên      :        " + txtHoTen.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Địa chỉ     :        " + txtDiaChi.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Ngày sinh   :        " + txtNgaySinh.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Ngày lập thẻ:        " + txtNgayLapThe.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Tên khoa    :        " + txttenkhoa.Text);
                sw.WriteLine("---------------------------------------------------");
                sw.WriteLine("| Vị trí      :        " + txtViTri.Text);
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

        private void txtMaDocGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) hToolStripMenuItem_Click(sender, e);
        }
        
    }
}