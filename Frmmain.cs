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
using CrystalDecisions.Windows.Forms;

namespace quanly.frm
{
    public partial class Frmmain : Form
    {
        public Frmmain()
        {
            InitializeComponent();
        }
        public static int rong = 0;
        public static NhanVien nv = new NhanVien();
        public void Frmmain_Load(object sender, EventArgs e)
        {
            rong = this.Size.Height;
            lbnam.Text = "Ngày " + DateTime.Now.Day.ToString() + " Tháng " + DateTime.Now.Month.ToString() + " Năm " + DateTime.Now.Year.ToString();
            if (DangNhap.strQuyenHan.IndexOf("ADMIN") >= 0)
            {
                mnquanlykho.Enabled = true;
                mnquanlymuontra.Enabled = true;
                mnquanlyDocGia.Enabled = true;
                mnphanquyen.Enabled = true;
                mntaotaikhoanmoi.Enabled = true;
                mnquanlydanhmuc.Enabled = true;
                mntaotaikhoanmoi.Enabled = true;
            }
            else
            {
                if (DangNhap.strQuyenHan.IndexOf("THUKHO") >= 0)
                {
                    mnquanlykho.Enabled = true;
                    mnquanlydanhmuc.Enabled = true;
                    khoaToolStripMenuItem.Enabled = false;
                }
                if (DangNhap.strQuyenHan.IndexOf("MUONTRA") >= 0)
                    mnquanlymuontra.Enabled = true;
                if (DangNhap.strQuyenHan.IndexOf("QUANLY") >= 0)
                {
                    mnquanlyDocGia.Enabled = true;
                    mnquanlydanhmuc.Enabled = true;
                    tácGiảToolStripMenuItem.Enabled = false;
                    loạiSáchToolStripMenuItem.Enabled = false;
                    ngônNgữToolStripMenuItem.Enabled = false;
                    nhàXuấtBảnToolStripMenuItem.Enabled = false;
                }
            }
            if (DangNhap.strQuyenHan != "")
            {
                mnttcanhan.Enabled = true;
                mndangxuat.Enabled = true;
                ctdangnhap.Enabled = false;
                ctdangxuat.Enabled = true;
                mndangnhap.Enabled = false;
            }
        }

        private void mndangxuat_Click(object sender, EventArgs e)
        {
            s = "Chương trình quản lý thư viện - Hãy đăng nhập vạo hệ thống để sử dụng        ";
            DangNhap.strQuyenHan = "";
            DangNhap.strnguoidung = "";
            mnquanlykho.Enabled = false;
            mnquanlymuontra.Enabled = false;
            mnquanlyDocGia.Enabled = false;
            mnphanquyen.Enabled = false;
            mnttcanhan.Enabled = false;
            mndangxuat.Enabled = false;
            mndangnhap.Enabled = true;
            mnquanlydanhmuc.Enabled = false;
            ctdangnhap.Enabled = true;
            ctdangxuat.Enabled = false;
            this.Refresh();
        }
        public static Frmquanlybandoc bd = new Frmquanlybandoc();
        private void mndangnhap_Click(object sender, EventArgs e)
        {

            switch (sender.ToString())
            {
                case "Hiệu chỉnh thông tin":
                    {
                        FrmCapNhatsach cns = new FrmCapNhatsach();
                        cns.MdiParent = this;
                        cns.Show();
                        break;
                    }
                case "Huỷ tài liệu":
                    {
                        FrmCapNhatsach cns = new FrmCapNhatsach();
                        cns.MdiParent = this;
                        cns.Show();
                        break;
                    }
                case "Nhập tài liệu mới":
                    {
                        FrmCapNhatsach cns = new FrmCapNhatsach();
                        cns.MdiParent = this;
                        cns.ht = 1;
                        cns.Show();
                        break;
                    }
                case "Tác giả":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        string query = " select IDTacGia as 'Mã tác giả',TenTacGia as 'Tên tác giả' from TacGia";
                        Formhienthi ht = new Formhienthi() { ChuoiKetNoi = query, BangKetNoi = "TacGia", TenCotMa = "Mã tác giả", TenCotTen = "Tên tác giả" };
                        ht.MdiParent = this;
                        ht.Show();
                        break;
                    }
                case "Nhà xuất bản":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        string query = " select IDNhaXuatBan as 'Mã nhà xuất bản',TenNhaXuatBan as 'Tên nhà xuất bản' from NhaXuatBan";
                        Formhienthi ht = new Formhienthi() { ChuoiKetNoi = query, BangKetNoi = "NhaXuatBan", TenCotMa = "Mã nhà xuất bản", TenCotTen = "Tên nhà xuất bản" };
                        ht.MdiParent = this;
                        ht.Show(); break;
                    }
                case "Loại tài liệu":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        string query = " select IDTheLoai as 'Mã thể loại',TenTheLoai as 'Tên Thể Loại' from TheLoai";
                        Formhienthi ht = new Formhienthi() { ChuoiKetNoi = query, BangKetNoi = "TheLoai", TenCotMa = "Mã thể loại", TenCotTen = "Tên Thể Loại" };
                        ht.MdiParent = this;
                        ht.Show(); break;
                    }
                case "Thông tin tài liệu mượn trong ngày":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmthongtinsachtrongngay stn = new Frmthongtinsachtrongngay();
                        stn.MdiParent = this;
                        stn.Show();
                        break;
                    }
                case "Ngôn ngữ":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        string query = " select IDNgonNgu as 'Mã ngôn ngữ',TenNgonNgu as 'Tên ngôn ngữ' from NgonNgu";
                        Formhienthi ht = new Formhienthi() { ChuoiKetNoi = query, BangKetNoi = "NgonNgu", TenCotMa = "Mã ngôn ngữ", TenCotTen = "Tên ngôn ngữ" };
                        ht.MdiParent = this;
                        ht.Show(); break;
                    }
                case "Khoa":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Formhienthi ht = new Formhienthi()
                        {
                            ChuoiKetNoi = " select MaKhoa as 'Mã khoa',TenKhoa as 'Tên Khoa' from Khoa",
                            BangKetNoi = "Khoa",
                            TenCotMa = "Mã khoa",
                            TenCotTen = "Tên Khoa"
                        };
                        ht.MdiParent = this;
                        ht.Show(); break;
                    }
                case "Trả tài liệu":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        FrmTraSach ts = new FrmTraSach();
                        ts.MdiParent = this;
                        ts.Show();
                        break;
                    }
                case "Thông tin tài liệu mượn theo ngày":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmthongtinsachtheongay tn = new Frmthongtinsachtheongay();
                        tn.MdiParent = this;
                        tn.Show();
                        break;
                    }
                case "Thống kê tài liệu":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        frmThongKeChiTiet tkct = new frmThongKeChiTiet();
                        tkct.MdiParent = this;
                        tkct.Show();
                        break;
                    }
                case "Gia hạn mượn":
                    {

                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        FrmTraSach frm = new FrmTraSach();
                        frm.MdiParent = this;
                        frm.Show();
                        break;
                    }
                case "Tìm kiếm độc giả":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmtimkiemdg tkdg = new Frmtimkiemdg();
                        tkdg.MdiParent = this;
                        tkdg.Show();
                        break;
                    }
                case "Thông tin tài khoản":
                    {
                        //hf.set_text("       Tài khoản của người dùng chương trình có gi đâu mà xem!!");
                        //hf.set_anh(3);                         
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        bd = new Frmquanlybandoc();
                        bd.MdiParent = this;
                        bd.Show();
                        break;
                    }
                case "Đăng nhập":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frdangnhap dn1 = new Frdangnhap();
                        dn1.ShowDialog(this);
                        dn1.MdiParent = this;
                        if (dn1.DialogResult == DialogResult.OK)
                        {
                            DangNhap dn = new DangNhap();
                            if (dn.kt_dangnhap(Frdangnhap.strtendn, Frdangnhap.strMatKhaudn))
                            {
                                s = "Người đang sử dụng chương trình có tài khoản là: " + DangNhap.strnguoidung.Trim() + " và quyền hạn là: " + DangNhap.strQuyenHan + "        ";
                                NhanVien nv = new NhanVien(DangNhap.idNhanVien, DangNhap.strHoTen, DangNhap.strDiaChi, DangNhap.strQuyenHan, DangNhap.strnguoidung, DangNhap.strMatKhau);
                                Frmmain_Load(sender, e);
                                MessageBox.Show("Bạn đã đăng nhập thành công vào hệ thống với quyền hạn là: " + DangNhap.strQuyenHan, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else { MessageBox.Show("Sai tên đăng nhập/mật khẩu"); }
                        }
                        break;
                    }
                case "Thay đổi thông tin cá nhân":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmthongtincanhan cn = new Frmthongtincanhan();
                        cn.MdiParent = this;
                        cn.Show();
                        break;
                    }
                case "Phân quyền":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmphanquyen pq = new Frmphanquyen();
                        pq.MdiParent = this;
                        pq.Show();
                        break;
                    }
                case "Quản lý tài khoản":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        FrmTaoMoitk tm = new FrmTaoMoitk();
                        tm.MdiParent = this;
                        tm.Show();
                        break;
                    }
                case "Tra cứu tài liệu":
                case "Cơ bản":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmtkcoban tkcb = new Frmtkcoban();
                        tkcb.Show();
                        break;
                    }
                case "Nâng cao":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmtknangcao nc = new Frmtknangcao();
                        nc.MdiParent = this;
                        nc.Show();
                        break;
                    }
                case "Mượn tài liệu":
                    {
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmmuonsach ms = new Frmmuonsach();
                        ms.MdiParent = this;
                        ms.Show();
                        break;
                    }
            }


        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool an = true;
        private void formChínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (an)
            {
                toolStrip1.Hide();
                an = false;
            }
            else toolStrip1.Show();
        }

        private void trênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (sender.ToString())
            {
                case "Trên":
                    {
                        toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                        toolStrip1.Dock = DockStyle.Top;
                        toolStripButton1.Text = "Ẩn chương trình";
                        toolStripButton2.Text = "Thoát chương trình";
                        label2.Visible = true;
                        break;
                    }
                case "Trái":
                    {
                        toolStrip1.LayoutStyle = ToolStripLayoutStyle.Table;
                        toolStrip1.Dock = DockStyle.Left;
                        toolStripButton1.Text = "Ẩn";
                        toolStripButton2.Text = "Thoát";
                        label2.Visible = false;
                        break;
                    }
                case "Phải":
                    {
                        toolStrip1.LayoutStyle = ToolStripLayoutStyle.Table;
                        toolStrip1.Dock = DockStyle.Right;
                        toolStripButton1.Text = "Ẩn";
                        toolStripButton2.Text = "Thoát";
                        label2.Visible = false;
                        break;
                    }
                case "Dưới":
                    {
                        toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                        toolStrip1.Dock = DockStyle.Bottom;
                        toolStripButton1.Text = "Ẩn chương trình";
                        toolStripButton2.Text = "Thoát chương trình";
                        label2.Visible = true;
                        break;
                    }
                case "Ẩn":
                    {
                        toolStrip1.Hide();
                        an = false;
                        break;
                    }
            }
        }
        bool trangthai = true;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            trangthai = false;
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (trangthai == false)
                this.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (trangthai == false)
                this.Show();
        }
        public static string s = "Chương trình quản lý thư viện - Hãy đăng nhập vạo hệ thống để sử dụng        ";
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = s;
            string tam = s[0].ToString();
            s = s.Substring(1, s.Length - 1) + tam;

        }
        public static bool tt = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            ProgressBar1.PerformStep();
            if (tt == true)
            {
                ProgressBar1.Value = ProgressBar1.Maximum;
                timer2.Enabled = false;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            lbdongho.Text = DateTime.Now.ToLongTimeString();
        }

        private void thôngTinChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, @"help.chm");

        }

        private void ngườiThựcHiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thongtinct ttc = new thongtinct();
            ttc.MdiParent = this;
            ttc.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += this.Opacity + 0.02;
            else timer4.Enabled = false;
        }

        private void mnquanlyht_Click(object sender, EventArgs e)
        {

        }






    }
}