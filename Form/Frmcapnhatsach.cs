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
using QLTV.GUI.DoiTuong;
using quanly.DoiTuong;

namespace quanly.frm
{
    public partial class FrmCapNhatsach : Form
    {
        public FrmCapNhatsach()
        {
            InitializeComponent();
        }
        public static string tb = "";
        public int ht = 0;
        private void FrmCapNhatsach_Load(object sender, EventArgs e)
        {
            if ((KTdangnhap.strQuyenHan.Trim() == "ADMIN") || KTdangnhap.strQuyenHan.IndexOf("THUKHO") >=0)
            {
                btCapNhat.Enabled = btxoa.Enabled = button1.Enabled = true;
                contextMenuStrip1.Enabled = true;
            }
            else
            {
                btCapNhat.Enabled = btxoa.Enabled = button1.Enabled = false;
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
            SqlDataReader dr = dl.lay_reader("select * from TacGia,TheLoai,NgonNgu,sach,ViTriluutru,NhaXuatBan where sach.MaViTri = ViTriluutru.MaViTri and sach.MaTheLoai = TheLoai.MaTheLoai and TacGia.MaTacGia = sach.MaTacGia and sach.MaNgonNgu = NgonNgu.MaNgonNgu and sach.MaNXB = NhaXuatBan.MaNXB and sach.MaSach='" + str + "'");
            while (dr.Read())
            {
                txtMaSach.Text = str;
                txtnamxuatban.Text = DateTime.Parse(dr["NamXuatBan"].ToString()).ToShortDateString();
                txtngan.Text = dr["ngan"].ToString();
                txtNhanDe.Text = dr["NhanDe"].ToString();
                txtSoLanMuon.Text = dr["SoLanMuon"].ToString();
                txtSoLuong.Text = dr["SoLuong"].ToString();
                txtSoTrang.Text = dr["SoTrang"].ToString();
                txtke.Text = dr["ke"].ToString();
                txtkho.Text = dr["kho"].ToString();
                txtlanxuatban.Text = dr["LanXuatBan"].ToString();
                cbloaisach.Text = dr["loai"].ToString();
                cbNgonNgu.Text = dr["NgonNgu"].ToString();
                cbNhaXuatBan.Text = dr["ten"].ToString();
                cbTacGia.Text = dr["TenTacGia"].ToString();
                txtNgayNhap.Text = DateTime.Parse(dr["NgayNhap"].ToString()).ToShortDateString();
                cbTheThuc.Text = dr["TheThuc"].ToString();
            }
            L_Ketnoi.HuyKetNoi();
        }
        #region Trình bày giao diện
        void Load_combobox()
        {
            laydulieu dl = new laydulieu();
            SqlDataReader dr1 = dl.lay_reader("select loai from TheLoai");
            while (dr1.Read())
                cbloaisach.Items.Add(dr1[0].ToString());
            L_Ketnoi.HuyKetNoi();
            L_Ketnoi.ThietlapketNoi();
            SqlDataReader dr2 = dl.lay_reader("select NgonNgu from NgonNgu");
            while (dr2.Read())
                cbNgonNgu.Items.Add(dr2[0].ToString());
            L_Ketnoi.HuyKetNoi();
            L_Ketnoi.ThietlapketNoi();
            SqlDataReader dr3 = dl.lay_reader("select TenTacGia from TacGia");
            while (dr3.Read())
                cbTacGia.Items.Add(dr3[0].ToString());
            L_Ketnoi.HuyKetNoi();
            L_Ketnoi.ThietlapketNoi();
            SqlDataReader dr4 = dl.lay_reader("select ten from NhaXuatBan");
            while (dr4.Read())
                cbNhaXuatBan.Items.Add(dr4[0].ToString());
            L_Ketnoi.HuyKetNoi();

        }
        void Load_treeview()
        {
            treeView1.Nodes.Clear();
            laydulieu dl = new laydulieu();
            SqlDataReader dr = dl.lay_reader("select NhanDe,MaSach from sach");
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
            SqlDataReader dr = dl.lay_reader("select * from TacGia,TheLoai,NgonNgu,sach,ViTriluutru,NhaXuatBan where sach.MaViTri = ViTriluutru.MaViTri and sach.MaTheLoai = TheLoai.MaTheLoai and TacGia.MaTacGia = sach.MaTacGia and sach.MaNgonNgu = NgonNgu.MaNgonNgu and sach.MaNXB = NhaXuatBan.MaNXB and sach.MaSach='"+ str +"'");
            while (dr.Read())
            {
                txtMaSach.Text = str;
                txtnamxuatban.Text = DateTime.Parse(dr["NamXuatBan"].ToString()).ToShortDateString();
                txtngan.Text = dr["ngan"].ToString();
                txtNhanDe.Text = dr["NhanDe"].ToString();
                txtSoLanMuon.Text = dr["SoLanMuon"].ToString();
                txtSoLuong.Text = dr["SoLuong"].ToString();
                txtSoTrang.Text = dr["SoTrang"].ToString();
                txtke.Text = dr["ke"].ToString();
                txtkho.Text = dr["kho"].ToString();
                txtlanxuatban.Text = dr["LanXuatBan"].ToString();
                cbloaisach.Text = dr["loai"].ToString();
                cbNgonNgu.Text = dr["NgonNgu"].ToString();
                cbNhaXuatBan.Text = dr["ten"].ToString();
                cbTacGia.Text = dr["TenTacGia"].ToString();
                txtNgayNhap.Text = DateTime.Parse(dr["NgayNhap"].ToString()).ToShortDateString();
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
            txtNgayNhap.Enabled = tam;
            txtNhanDe.Enabled = tam;
            txtSoTrang.Enabled = tam;
            cbloaisach.Enabled = tam;
            cbNgonNgu.Enabled = tam;
            cbNhaXuatBan.Enabled = tam;
            cbTacGia.Enabled = tam;
            cbTheThuc.Enabled = tam;
            txtSoLuong.Enabled = tam;

        }
        #endregion
        #region Sinh mã tự động
        string MaViTri()
        {
            laydulieu dl = new laydulieu();
            string tam = "";
            int i = 0;
            SqlDataReader dr = dl.lay_reader("select MaViTri from ViTriluutru");
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
        string MaTheLoai()
        {
            laydulieu dl = new laydulieu();
            string tam = "";
            int i = 0;
            SqlDataReader dr = dl.lay_reader("select MaTheLoai from TheLoai");
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
        string MaTacGia()
        {
            laydulieu dl = new laydulieu();
            string tam = "";
            int i = 0;
            SqlDataReader dr = dl.lay_reader("select MaTacGia from TacGia");
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
        string maNhaXuatBan()
        {
            laydulieu dl = new laydulieu();
            string tam = "";
            int i = 0;
            SqlDataReader dr = dl.lay_reader("select MaNXB from NhaXuatBan");
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
        string MaNgonNgu()
        {
            laydulieu dl = new laydulieu();
            string tam = "";
            int i = 0;
            SqlDataReader dr = dl.lay_reader("select MaNgonNgu from NgonNgu");
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
        string MaSach(string ma)
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
                if (cbTheThuc.Text == "") s.TheThuc = "Mượn về nhà";
                else s.TheThuc = (cbTheThuc.Text);
                s.MaSach =(txtMaSach.Text);
                s.LanXuatBan = (int.Parse(txtlanxuatban.Text));
                try
                {
                    s.NamXuatBan = (DateTime.Parse(txtnamxuatban.Text));
                }
                catch
                {
                    tam = false;
                    str += ", Năm xuất bản";
                }
                s.NgayNhap = (DateTime.Parse(DateTime.Now.ToShortDateString()));
                s.NhanDe = (txtNhanDe.Text);
                try
                {
                    s.SoTrang=(int.Parse(txtSoTrang.Text));
                }
                catch 
                {
                    tam = false;
                    str += ", Số trang";
                }
                try
                {
                s.SoLuong = (int.Parse(txtSoLuong.Text));
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
                    if (s.LayMaNgonNgu(cbNgonNgu.Text) == 0)
                    {
                        strtam = MaNgonNgu();
                        NgonNgu nn = new NgonNgu(strtam, cbNgonNgu.Text);
                        if (nn.TaoMoi() == false) MessageBox.Show("Lỗi trong tạo mới ngôn ngữ", "Thông báo");
                        else s.MaNgonNgu = (strtam);
                    }
                    if (s.LayMaNXB(cbNhaXuatBan.Text) == 0)
                    {
                        strtam=maNhaXuatBan();
                        NhaXuatBan xb = new NhaXuatBan(strtam, cbNhaXuatBan.Text);
                        if (xb.TaoMoi() == false) MessageBox.Show("Lỗi trong tạo mới nhà xuất bản", "Thông báo");
                        else s.MaNXB = (strtam);
                    }
                    if (s.LayMaTheLoai(cbloaisach.Text) == 0)
                    {
                        strtam = MaTheLoai();
                        TheLoai pl = new TheLoai(strtam, cbloaisach.Text);
                        if (pl.TaoMoi() == false) MessageBox.Show("Lỗi trong tạo mới loại sách", "Thông báo");
                        else s.MaTheLoai = (strtam);
                    }
                    if (s.LayMaTacGia(cbTacGia.Text) == 0)
                    {
                        strtam = MaTacGia();
                        TacGia tg = new TacGia(strtam, cbTacGia.Text);
                        if (tg.TaoMoi() == false) MessageBox.Show("Có lỗi trong tạo mới tác giả", "Thông báo");
                        else s.MaTacGia = (strtam);
                    }
                    //--tạo mới một đối tượng vị trí----
                    string macuoiViTri = MaViTri();
                    ViTriLuuTru vt = new ViTriLuuTru(txtkho.Text, macuoiViTri, txtke.Text, txtngan.Text);
                    s.MaViTri = (macuoiViTri);
                    if (vt.TaoMoi() == false) MessageBox.Show("Lỗi trong tạo mới một vị trí");

                    if (s.TaoMoi() == true)
                    {
                        set_enable(false);
                        btCapNhat.Enabled = true;
                        btxoa.Enabled = true;
                        button1.Text = "Tạo mới";
                        TreeNode n = new TreeNode();
                        n.Tag = txtMaSach.Text;
                        n.Text = txtNhanDe.Text;
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
                btCapNhat.Enabled = false;
                btxoa.Enabled = false;
                txtNgayNhap.Text = DateTime.Now.ToShortDateString();
                button1.Text = "OK";
                txtke.Text = "";
                txtkho.Text = "";
                txtlanxuatban.Text = "0";
                txtnamxuatban.Text = "";
                txtngan.Text = "";
                txtNhanDe.Text = "";
                txtSoTrang.Text = "0";
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select MaSach from sach");
                string strtam = "";
                while(dr.Read())
                    strtam=dr[0].ToString();
                L_Ketnoi.HuyKetNoi();
                if (strtam == "") txtMaSach.Text = "S00000";
                else txtMaSach.Text = MaSach(strtam);
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
                SqlDataReader dr = dl.lay_reader("select MaViTri from sach where MaSach='" + txtMaSach.Text + "'");
                string tam = "";
                while (dr.Read())
                    tam = dr[0].ToString();
                L_Ketnoi.HuyKetNoi();
                Lsach s = new Lsach();
                s.MaSach = (txtMaSach.Text);
                if (s.XoaBo() == false) MessageBox.Show("Lỗi trong xoá bỏ sách", "Thông báo");
                int i = 0;
                while (i < treeView1.Nodes.Count)
                {
                    if (treeView1.Nodes[i].Tag.ToString() == txtMaSach.Text)
                    {
                        treeView1.Nodes[i].Remove();
                        break;
                    }
                    i++;
                }
                ViTriLuuTru lt = new ViTriLuuTru();
                lt.MaViTri = tam;
                if (lt.XoaBo() == false) MessageBox.Show("Lỗi trong xoá bỏ vị trí lưu trữ", "Thông báo");
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            bool tam = true;
            string str = "";
            if (btCapNhat.Text == "OK")
            {

                //--thuc hien tao du lieu cho doi tuong sach
                #region set giá trị
                Lsach s = new Lsach();
                if (cbTheThuc.Text == "") s.TheThuc = ("Mượn về nhà");
                else s.TheThuc = (cbTheThuc.Text);
                s.MaSach = (txtMaSach.Text);
                s.MaSach = (txtMaSach.Text);
                try
                {
                    s.LanXuatBan = (int.Parse(txtlanxuatban.Text));
                }
                catch
                {
                    tam = false;
                    str += ", Lần xuất bản";
                }
                try
                {
                    s.NamXuatBan =(DateTime.Parse(txtnamxuatban.Text));
                }
                catch
                {
                    tam = false;
                    str += ", Năm xuất bản";
                }
                try
                {
                    s.SoTrang = (int.Parse(txtSoLuong.Text));
                }
                catch
                {
                    tam = false;
                    str += ", số lượng";
                }
                s.NgayNhap = (DateTime.Parse(DateTime.Now.ToShortDateString()));
                s.NhanDe = (txtNhanDe.Text);
                try
                {
                    s.SoTrang = (int.Parse(txtSoTrang.Text));
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
                    if (s.LayMaNgonNgu(cbNgonNgu.Text) == 0)
                    {
                        strtam = MaNgonNgu();
                        NgonNgu nn = new NgonNgu(strtam, cbNgonNgu.Text);
                        if (nn.TaoMoi() == false) MessageBox.Show("Lỗi trong tạo mới ngôn ngữ", "Thông báo");
                        else s.MaNgonNgu = (strtam);
                    }
                    if (s.LayMaNXB(cbNhaXuatBan.Text) == 0)
                    {
                        strtam = maNhaXuatBan();
                        NhaXuatBan xb = new NhaXuatBan(strtam, cbNhaXuatBan.Text);
                        if (xb.TaoMoi() == false) MessageBox.Show("Lỗi trong tạo mới nhà xuất bản", "Thông báo");
                        else s.MaNXB = (strtam);
                    }
                    if (s.LayMaTheLoai(cbloaisach.Text) == 0)
                    {
                        strtam = MaTheLoai();
                        TheLoai pl = new TheLoai(strtam, cbloaisach.Text);
                        if (pl.TaoMoi() == false) MessageBox.Show("Lỗi trong tạo mới loại sách", "Thông báo");
                        else s.MaTheLoai = (strtam);
                    }
                    if (s.LayMaTacGia(cbTacGia.Text) == 0)
                    {
                        strtam = MaTacGia();
                        TacGia tg = new TacGia(strtam, cbTacGia.Text);
                        if (tg.TaoMoi() == false) MessageBox.Show("Có lỗi trong tạo mới tác giả", "Thông báo");
                        else s.MaTacGia = (strtam);
                    }
                    //--tạo mới một đối tượng vị trí----
                    string macuoiViTri = MaViTri();
                    ViTriLuuTru vt = new ViTriLuuTru(txtkho.Text, macuoiViTri, txtke.Text, txtngan.Text);
                    if (vt.TaoMoi() == false) MessageBox.Show("Lỗi trong tạo mới một vị trí");
                    s.MaViTri = (macuoiViTri);
                    if (L_Ketnoi.cn.State == ConnectionState.Open)
                        L_Ketnoi.HuyKetNoi();
                    L_Ketnoi.ThietlapketNoi();
                    if (s.CapNhat() )
                    {
                        set_enable(false);
                        button1.Enabled = true;
                        btxoa.Enabled = true;
                        btCapNhat.Text = "Cập nhật";
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
                btCapNhat.Text = "OK";
                
               
            }
        }

        private void FrmCapNhatsach_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
            Frmmain.hf.set_text(Frmhelpfast.t);
            Frmmain.hf.set_anh(1);
            Frmmain.hf.timer5.Enabled = false;
        }

        
    }
}