using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using quanly.doituong;
using System.Data.SqlClient;

namespace quanly.frm
{
    public partial class Frmcapnhatsach : Form
    {
        public Frmcapnhatsach()
        {
            InitializeComponent();
        }
        public static string tb = "";
        public int ht = 0;
        private void Frmcapnhatsach_Load(object sender, EventArgs e)
        {
            if ((KTdangnhap.strquyenhan.Trim() == "ADMIN") || KTdangnhap.strquyenhan.IndexOf("THUKHO") >=0)
            {
                btcapnhat.Enabled = btxoa.Enabled = button1.Enabled = true;
                contextMenuStrip1.Enabled = true;
            }
            else
            {
                btcapnhat.Enabled = btxoa.Enabled = button1.Enabled = false;
                contextMenuStrip1.Enabled = false;
            }
            Frmmain.tt = true;
            Load_combobox();
            Load_treeview();
            if (tb=="")
                Load_textbox(treeView1.Nodes[0].Tag.ToString());
            else Load_textbox(tb);
            if(ht==1) button1_Click(sender, e);
            
        }
        void Load_textbox(string str)
        {
            laydulieu dl = new laydulieu();
            SqlDataReader dr = dl.lay_reader("select * from tacgia,phanloai,ngonngu,sach,vitriluutru,nhaxuatban where sach.mavitri = vitriluutru.mavitri and sach.maphanloai = phanloai.maphanloai and tacgia.matacgia = sach.matacgia and sach.mangonngu = ngonngu.mangonngu and sach.manxb = nhaxuatban.manxb and sach.masach='" + str + "'");
            while (dr.Read())
            {
                txtmasach.Text = str;
                txtnamxuatban.Text = DateTime.Parse(dr["namxb"].ToString()).ToShortDateString();
                txtngan.Text = dr["ngan"].ToString();
                txtnhande.Text = dr["nhande"].ToString();
                txtsolanmuon.Text = dr["solanmuon"].ToString();
                txtsoluong.Text = dr["soluong"].ToString();
                txtsotrang.Text = dr["sotrang"].ToString();
                txtke.Text = dr["ke"].ToString();
                txtkho.Text = dr["kho"].ToString();
                txtlanxuatban.Text = dr["lanxb"].ToString();
                cbloaisach.Text = dr["loai"].ToString();
                cbngonngu.Text = dr["ngonngu"].ToString();
                cbnhaxuatban.Text = dr["ten"].ToString();
                cbtacgia.Text = dr["tentacgia"].ToString();
                txtngaynhap.Text = DateTime.Parse(dr["ngaynhap"].ToString()).ToShortDateString();
                cbthethuc.Text = dr["thethuc"].ToString();
            }
            L_Ketnoi.HuyKetNoi();
        }
        #region Trình bày giao diện
        void Load_combobox()
        {
            laydulieu dl = new laydulieu();
            SqlDataReader dr1 = dl.lay_reader("select loai from phanloai");
            while (dr1.Read())
                cbloaisach.Items.Add(dr1[0].ToString());
            L_Ketnoi.HuyKetNoi();
            L_Ketnoi.ThietlapketNoi();
            SqlDataReader dr2 = dl.lay_reader("select ngonngu from ngonngu");
            while (dr2.Read())
                cbngonngu.Items.Add(dr2[0].ToString());
            L_Ketnoi.HuyKetNoi();
            L_Ketnoi.ThietlapketNoi();
            SqlDataReader dr3 = dl.lay_reader("select tentacgia from tacgia");
            while (dr3.Read())
                cbtacgia.Items.Add(dr3[0].ToString());
            L_Ketnoi.HuyKetNoi();
            L_Ketnoi.ThietlapketNoi();
            SqlDataReader dr4 = dl.lay_reader("select ten from nhaxuatban");
            while (dr4.Read())
                cbnhaxuatban.Items.Add(dr4[0].ToString());
            L_Ketnoi.HuyKetNoi();

        }
        void Load_treeview()
        {
            treeView1.Nodes.Clear();
            laydulieu dl = new laydulieu();
            SqlDataReader dr = dl.lay_reader("select nhande,masach from sach");
            while (dr.Read())
            {
                TreeNode n = new TreeNode();
                n.Tag = dr[1].ToString();
                n.Text = dr[0].ToString();
                n.ImageIndex = 0;
                treeView1.Nodes.Add(n);
            }
            L_Ketnoi.HuyKetNoi();
        }   
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string str = treeView1.SelectedNode.Tag.ToString();
            laydulieu dl = new laydulieu();
            SqlDataReader dr = dl.lay_reader("select * from tacgia,phanloai,ngonngu,sach,vitriluutru,nhaxuatban where sach.mavitri = vitriluutru.mavitri and sach.maphanloai = phanloai.maphanloai and tacgia.matacgia = sach.matacgia and sach.mangonngu = ngonngu.mangonngu and sach.manxb = nhaxuatban.manxb and sach.masach='"+ str +"'");
            while (dr.Read())
            {
                txtmasach.Text = str;
                txtnamxuatban.Text = DateTime.Parse(dr["namxb"].ToString()).ToShortDateString();
                txtngan.Text = dr["ngan"].ToString();
                txtnhande.Text = dr["nhande"].ToString();
                txtsolanmuon.Text = dr["solanmuon"].ToString();
                txtsoluong.Text = dr["soluong"].ToString();
                txtsotrang.Text = dr["sotrang"].ToString();
                txtke.Text = dr["ke"].ToString();
                txtkho.Text = dr["kho"].ToString();
                txtlanxuatban.Text = dr["lanxb"].ToString();
                cbloaisach.Text = dr["loai"].ToString();
                cbngonngu.Text = dr["ngonngu"].ToString();
                cbnhaxuatban.Text = dr["ten"].ToString();
                cbtacgia.Text = dr["tentacgia"].ToString();
                txtngaynhap.Text = DateTime.Parse(dr["ngaynhap"].ToString()).ToShortDateString();
            }
            L_Ketnoi.HuyKetNoi();
        }
        void set_enable(bool tam)
        {
            txtke.Enabled = tam;
            txtkho.Enabled = tam;
            txtlanxuatban.Enabled = tam;
            txtnamxuatban.Enabled = tam;
            txtngan.Enabled = tam;
            txtngaynhap.Enabled = tam;
            txtnhande.Enabled = tam;
            txtsotrang.Enabled = tam;
            cbloaisach.Enabled = tam;
            cbngonngu.Enabled = tam;
            cbnhaxuatban.Enabled = tam;
            cbtacgia.Enabled = tam;
            cbthethuc.Enabled = tam;
            txtsoluong.Enabled = tam;

        }
        #endregion
        #region Sinh mã tự động
        string mavitri()
        {
            laydulieu dl = new laydulieu();
            string tam = "";
            int i = 0;
            SqlDataReader dr = dl.lay_reader("select mavitri from vitriluutru");
            while (dr.Read())
                tam = dr[0].ToString();
            L_Ketnoi.HuyKetNoi();
            i = int.Parse(tam.Substring(2, tam.Length - 2));
            i++;
            if (i < 10) return "VT0000" + i.ToString();
            else
                if (i < 100) return "VT000" + i.ToString();
                else
                    if (i < 1000) return "VT00" + i.ToString();
                    else
                        if (i < 10000) return "VT0" + i.ToString();
                        else return "VT" + i.ToString();
        }
        string maphanloai()
        {
            laydulieu dl = new laydulieu();
            string tam = "";
            int i = 0;
            SqlDataReader dr = dl.lay_reader("select maphanloai from phanloai");
            while (dr.Read())
                tam = dr[0].ToString();
            L_Ketnoi.HuyKetNoi();
            i = int.Parse(tam.Substring(2, tam.Length - 2));
            i++;
            if (i < 10) return "PL00" + i.ToString();
            else
                if (i < 100) return "PL0" + i.ToString();
                else  return "PL" + i.ToString();
                     
        }
        string matacgia()
        {
            laydulieu dl = new laydulieu();
            string tam = "";
            int i = 0;
            SqlDataReader dr = dl.lay_reader("select matacgia from tacgia");
            while (dr.Read())
                tam = dr[0].ToString();
            L_Ketnoi.HuyKetNoi();
            i = int.Parse(tam.Substring(2, tam.Length - 2));
            i++;
            if (i < 10) return "TG00" + i.ToString();
            else
                if (i < 100) return "TG0" + i.ToString();
                else
                    return "TG" + i.ToString();
        }
        string manhaxuatban()
        {
            laydulieu dl = new laydulieu();
            string tam = "";
            int i = 0;
            SqlDataReader dr = dl.lay_reader("select manxb from nhaxuatban");
            while (dr.Read())
                tam = dr[0].ToString();
            L_Ketnoi.HuyKetNoi();
            i = int.Parse(tam.Substring(2, tam.Length - 2));
            i++;
            if (i < 10) return "XB00" + i.ToString();
            else
                if (i < 100) return "XB0" + i.ToString();
                else return "XB" + i.ToString();
        }
        string mangonngu()
        {
            laydulieu dl = new laydulieu();
            string tam = "";
            int i = 0;
            SqlDataReader dr = dl.lay_reader("select mangonngu from ngonngu");
            while (dr.Read())
                tam = dr[0].ToString();
            L_Ketnoi.HuyKetNoi();
            i = int.Parse(tam.Substring(2, tam.Length - 2));
            i++;
            if (i < 10) return "NN00" + i.ToString();
            else
                if (i < 100) return "NN0" + i.ToString();
                else return "NN" + i.ToString();
        }
        string masach(string ma)
        {
            string s = ma.Substring(1, ma.Length - 1);
            double i = double.Parse(s);
            i++;
            if (i < 10) return "S0000" + i.ToString();
            else
                if (i < 100) return "S000" + i.ToString();
                else
                    if (i < 1000) return "S00" + i.ToString();
                    else
                        if (i < 10000) return "S0" + i.ToString();
                        else
                            return "S" + i.ToString();
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            bool tam = true;
            string str = "";
            if (button1.Text == "OK")
            {
               
                //--thuc hien tao du lieu cho doi tuong sach
                #region set giá trị
                Lsach s = new Lsach();
                if (cbthethuc.Text == "") s.set_thethuc("Mượn về nhà");
                else s.set_thethuc(cbthethuc.Text);
                s.set_masach(txtmasach.Text);
                s.set_lanxb(int.Parse(txtlanxuatban.Text));
                try
                {
                    s.set_namxb(DateTime.Parse(txtnamxuatban.Text));
                }
                catch
                {
                    tam = false;
                    str += ", Năm xuất bản";
                }
                s.set_ngaynhap(DateTime.Parse(DateTime.Now.ToShortDateString()));
                s.set_nhande(txtnhande.Text);
                try
                {
                    s.set_sotrang(int.Parse(txtsotrang.Text));
                }
                catch 
                {
                    tam = false;
                    str += ", Số trang";
                }
                try
                {
                s.set_soluong(int.Parse(txtsoluong.Text));
                }
                catch
                {
                    tam = false;
                    str += ", số lượng";
                }
                #endregion
                if (tam)
                {
                    string strtam = "";
                    //---Tạo mới các đối tượng------------
                    if (s.laymangonngu(cbngonngu.Text) == 0)
                    {
                        strtam = mangonngu();
                        Lngonngu nn = new Lngonngu(strtam, cbngonngu.Text);
                        if (nn.taomoi() == false) MessageBox.Show("Lỗi trong tạo mới ngôn ngữ", "Thông báo");
                        else s.set_mangonngu(strtam);
                    }
                    if (s.laymanhaxuatban(cbnhaxuatban.Text) == 0)
                    {
                        strtam=manhaxuatban();
                        Lnhaxuatban xb = new Lnhaxuatban(strtam, cbnhaxuatban.Text);
                        if (xb.taomoi() == false) MessageBox.Show("Lỗi trong tạo mới nhà xuất bản", "Thông báo");
                        else s.set_manxb(strtam);
                    }
                    if (s.laymaphanloai(cbloaisach.Text) == 0)
                    {
                        strtam = maphanloai();
                        Lphanloai pl = new Lphanloai(strtam, cbloaisach.Text);
                        if (pl.taomoi() == false) MessageBox.Show("Lỗi trong tạo mới loại sách", "Thông báo");
                        else s.set_maphanloai(strtam);
                    }
                    if (s.laymatacgia(cbtacgia.Text) == 0)
                    {
                        strtam = matacgia();
                        Ltacgia tg = new Ltacgia(strtam, cbtacgia.Text);
                        if (tg.taomoi() == false) MessageBox.Show("Có lỗi trong tạo mới tác giả", "Thông báo");
                        else s.set_matacgia(strtam);
                    }
                    //--tạo mới một đối tượng vị trí----
                    string macuoivitri = mavitri();
                    Lvitriluutru vt = new Lvitriluutru(txtkho.Text, macuoivitri, txtke.Text, txtngan.Text);
                    s.set_mavitri(macuoivitri);
                    if (vt.taomoi() == false) MessageBox.Show("Lỗi trong tạo mới một vị trí");

                    if (s.taomoi() == true)
                    {
                        set_enable(false);
                        btcapnhat.Enabled = true;
                        btxoa.Enabled = true;
                        button1.Text = "Tạo mới";
                        TreeNode n = new TreeNode();
                        n.Tag = txtmasach.Text;
                        n.Text = txtnhande.Text;
                        n.ImageIndex = 0;
                        treeView1.Nodes.Add(n);
                        treeView1.Enabled = true;
                        MessageBox.Show("Đã tạo mới thành công");
                        Frmmain.hf.timer5.Enabled = false;
                        Frmmain.hf.set_text("Làm tốt lắm");
                        Frmmain.hf.set_anh(3);
                    }
                    else MessageBox.Show("Lỗi trong tạo mới sách");
                }
                else
                {
                    MessageBox.Show("Một số lỗi trong nhập dữ liệu "+ str);
                    Frmmain.hf.set_text("Số trang , lần xuất bản phải nhập vào một số. Năm xuất bản có dạng ngày/tháng/năm");
                    
                }
            }
            else
            {
                treeView1.Enabled = false;
                set_enable(true);
                btcapnhat.Enabled = false;
                btxoa.Enabled = false;
                txtngaynhap.Text = DateTime.Now.ToShortDateString();
                button1.Text = "OK";
                txtke.Text = "";
                txtkho.Text = "";
                txtlanxuatban.Text = "0";
                txtnamxuatban.Text = "";
                txtngan.Text = "";
                txtnhande.Text = "";
                txtsotrang.Text = "0";
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select masach from sach");
                string strtam = "";
                while(dr.Read())
                    strtam=dr[0].ToString();
                L_Ketnoi.HuyKetNoi();
                if (strtam == "") txtmasach.Text = "S00000";
                else txtmasach.Text = masach(strtam);
                Frmmain.hf.set_anh(2);
                Frmmain.hf.set_text("Nếu các danh mục như loại sách, ngôn ngữ.v.v..không có trong mục chọn thì chỉ cần đánh giá trị mới vào mục chọn là nó sẽ tự động tạo mới danh mục cho bạn");
                Frmmain.hf.timer5.Enabled = true;
                    
            }
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thực hiện thao tác xoá ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select mavitri from sach where masach='" + txtmasach.Text + "'");
                string tam = "";
                while (dr.Read())
                    tam = dr[0].ToString();
                L_Ketnoi.HuyKetNoi();
                Lsach s = new Lsach();
                s.set_masach(txtmasach.Text);
                if (s.xoabo() == false) MessageBox.Show("Lỗi trong xoá bỏ sách", "Thông báo");
                int i = 0;
                while (i < treeView1.Nodes.Count)
                {
                    if (treeView1.Nodes[i].Tag.ToString() == txtmasach.Text)
                    {
                        treeView1.Nodes[i].Remove();
                        break;
                    }
                    i++;
                }
                Lvitriluutru lt = new Lvitriluutru();
                lt.set_mavitri(tam);
                if (lt.xoabo() == false) MessageBox.Show("Lỗi trong xoá bỏ vị trí lưu trữ", "Thông báo");
            }
        }

        private void btcapnhat_Click(object sender, EventArgs e)
        {
            bool tam = true;
            string str = "";
            if (btcapnhat.Text == "OK")
            {

                //--thuc hien tao du lieu cho doi tuong sach
                #region set giá trị
                Lsach s = new Lsach();
                if (cbthethuc.Text == "") s.set_thethuc("Mượn về nhà");
                else s.set_thethuc(cbthethuc.Text);
                s.set_masach(txtmasach.Text);
                s.set_masach(txtmasach.Text);
                try
                {
                    s.set_lanxb(int.Parse(txtlanxuatban.Text));
                }
                catch
                {
                    tam = false;
                    str += ", Lần xuất bản";
                }
                try
                {
                    s.set_namxb(DateTime.Parse(txtnamxuatban.Text));
                }
                catch
                {
                    tam = false;
                    str += ", Năm xuất bản";
                }
                try
                {
                    s.set_soluong(int.Parse(txtsoluong.Text));
                }
                catch
                {
                    tam = false;
                    str += ", số lượng";
                }
                s.set_ngaynhap(DateTime.Parse(DateTime.Now.ToShortDateString()));
                s.set_nhande(txtnhande.Text);
                try
                {
                    s.set_sotrang(int.Parse(txtsotrang.Text));
                }
                catch
                {
                    tam = false;
                    str += ", Số trang";
                }

                #endregion
                if (tam)
                {
                    string strtam = "";
                    if (s.laymangonngu(cbngonngu.Text) == 0)
                    {
                        strtam = mangonngu();
                        Lngonngu nn = new Lngonngu(strtam, cbngonngu.Text);
                        if (nn.taomoi() == false) MessageBox.Show("Lỗi trong tạo mới ngôn ngữ", "Thông báo");
                        else s.set_mangonngu(strtam);
                    }
                    if (s.laymanhaxuatban(cbnhaxuatban.Text) == 0)
                    {
                        strtam = manhaxuatban();
                        Lnhaxuatban xb = new Lnhaxuatban(strtam, cbnhaxuatban.Text);
                        if (xb.taomoi() == false) MessageBox.Show("Lỗi trong tạo mới nhà xuất bản", "Thông báo");
                        else s.set_manxb(strtam);
                    }
                    if (s.laymaphanloai(cbloaisach.Text) == 0)
                    {
                        strtam = maphanloai();
                        Lphanloai pl = new Lphanloai(strtam, cbloaisach.Text);
                        if (pl.taomoi() == false) MessageBox.Show("Lỗi trong tạo mới loại sách", "Thông báo");
                        else s.set_maphanloai(strtam);
                    }
                    if (s.laymatacgia(cbtacgia.Text) == 0)
                    {
                        strtam = matacgia();
                        Ltacgia tg = new Ltacgia(strtam, cbtacgia.Text);
                        if (tg.taomoi() == false) MessageBox.Show("Có lỗi trong tạo mới tác giả", "Thông báo");
                        else s.set_matacgia(strtam);
                    }
                    //--tạo mới một đối tượng vị trí----
                    string macuoivitri = mavitri();
                    Lvitriluutru vt = new Lvitriluutru(txtkho.Text, macuoivitri, txtke.Text, txtngan.Text);
                    if (vt.taomoi() == false) MessageBox.Show("Lỗi trong tạo mới một vị trí");
                    s.set_mavitri(macuoivitri);
                    if (L_Ketnoi.cn.State == ConnectionState.Open)
                        L_Ketnoi.HuyKetNoi();
                    L_Ketnoi.ThietlapketNoi();
                    if (s.capnhat() )
                    {
                        set_enable(false);
                        button1.Enabled = true;
                        btxoa.Enabled = true;
                        btcapnhat.Text = "Cập nhật";
                        treeView1.Enabled = true;
                        MessageBox.Show("Đã cập nhật thành công");
                        Load_treeview();
                    }
                    else MessageBox.Show("Lỗi trong cập nhật sách");
                }
                else
                {
                    MessageBox.Show("Một số lỗi trong nhập dữ liệu " + str);
                    Frmmain.hf.set_text("Số trang , lần xuất bản phải nhập vào một số. Năm xuất bản có dạng tháng/ngày/năm ");
                    Frmmain.hf.set_anh(2);
                    Frmmain.hf.timer5.Enabled = true;
                    
                }
            }
            else
            {
                treeView1.Enabled = false;
                set_enable(true);
                button1.Enabled = false;
                btxoa.Enabled = false;
                btcapnhat.Text = "OK";
                
               
            }
        }

        private void Frmcapnhatsach_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
            Frmmain.hf.set_text(Frmhelpfast.t);
            Frmmain.hf.set_anh(1);
            Frmmain.hf.timer5.Enabled = false;
        }

        
    }
}