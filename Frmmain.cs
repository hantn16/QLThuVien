using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using quanly.lopdulieu;
using quanlythuvien.Thong_ke_bao_cao;
using System.Data.SqlClient;
using quanly.doituong;
namespace quanly.frm
{
    public partial class Frmmain : Form
    {
        public Frmmain()
        {
            InitializeComponent();
        }
        public static Frmhelpfast hf = new Frmhelpfast();
        public static int rong = 0;
        public static NhanVien nv = new NhanVien();
        public void Frmmain_Load(object sender, EventArgs e)
        {
            rong = this.Size.Height;
            hf.Show();
            lbnam.Text = "Ngày " + DateTime.Now.Day.ToString() + " Tháng " + DateTime.Now.Month.ToString() + " Năm " + DateTime.Now.Year.ToString();
            if (KTdangnhap.strQuyenHan.IndexOf("ADMIN") >= 0)
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
                if (KTdangnhap.strQuyenHan.IndexOf("THUKHO") >= 0)
                {
                    mnquanlykho.Enabled = true;
                    mnquanlydanhmuc.Enabled = true;
                    khoaToolStripMenuItem.Enabled = false;
                }
                if (KTdangnhap.strQuyenHan.IndexOf("MUONTRA") >= 0)
                    mnquanlymuontra.Enabled = true;
                if (KTdangnhap.strQuyenHan.IndexOf("QUANLY") >= 0)
                {
                    mnquanlyDocGia.Enabled = true;
                    mnquanlydanhmuc.Enabled = true;
                    tácGiảToolStripMenuItem.Enabled = false;
                    loạiSáchToolStripMenuItem.Enabled = false;
                    ngônNgữToolStripMenuItem.Enabled = false;
                    nhàXuấtBảnToolStripMenuItem.Enabled = false;
                }
            }
            if (KTdangnhap.strQuyenHan != "")
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
            KTdangnhap.strQuyenHan = "";
            KTdangnhap.strnguoidung = "";
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
                        hf.set_text("        Nhập thông tin tài liệu ẩu rồi giờ lại vào chỉnh thông tin");
                        hf.set_anh(3);
                        FrmCapNhatsach cns = new FrmCapNhatsach();
                        cns.MdiParent = this;
                        cns.Show();
                        break;
                    }
                case "Huỷ tài liệu":
                    {
                        hf.set_text("        Lại huỷ tài liệu trong thư viện rồi");
                        hf.set_anh(3);
                        FrmCapNhatsach cns = new FrmCapNhatsach();
                        cns.MdiParent = this;
                        cns.Show();
                        break;
                    }
                case "Nhập tài liệu mới":
                    {
                        hf.set_text("        Có tài liệu mới nhập về thư viện à");
                        hf.set_anh(3);
                        FrmCapNhatsach cns = new FrmCapNhatsach();
                        cns.MdiParent = this;
                        cns.ht = 1;
                        cns.Show();
                        break;
                    }
                case "Tạo thẻ thư viện cho độc giả":
                    {
                        hf.set_text("        Vô tạo thẻ cho đoàn hoàn kẻo  in nhầm tốn giấy đó");
                        hf.set_anh(3);
                        frmtaothe cns = new frmtaothe();
                        cns.MdiParent = this;
                        cns.Show();
                        break;
                    }
                case "Tác giả":
                    {
                        hf.set_text("       cập nhật thông tin danh mục à!!");
                        hf.set_anh(3);
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
                        hf.set_text("       cập nhật thông tin danh mục à!!");
                        hf.set_anh(3);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        string query = " select IDNhaXuatBan as 'Mã nhà xuất bản',TenNhaXuatBan as 'Tên nhà xuất bản' from NhaXuatBan";
                        Formhienthi ht = new Formhienthi() { ChuoiKetNoi = query, BangKetNoi = "NhaXuatBan", TenCotMa = "Mã nhà xuất bản", TenCotTen = "Tên nhà xuất bản" };
                        ht.MdiParent = this;
                        ht.Show(); break;
                    }
                case "Loại tài liệu":
                    {
                        hf.set_text("       cập nhật thông tin danh mục à!!");
                        hf.set_anh(3);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        string query = " select IDTheLoai as 'Mã thể loại',TenTheLoai as 'Tên Thể Loại' from TheLoai";
                        Formhienthi ht = new Formhienthi() { ChuoiKetNoi = query, BangKetNoi = "TheLoai", TenCotMa = "Mã thể loại", TenCotTen = "Tên Thể Loại" };
                        ht.MdiParent = this;
                        ht.Show(); break;
                    }
                case "Thông tin tài liệu mượn trong ngày":
                    {
                        hf.set_text("       Kiểm tra cuối ngày, để xem có độc giả nào chưa trả tài liệu hay không!!");
                        hf.set_anh(3);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmthongtinsachtrongngay stn = new Frmthongtinsachtrongngay();
                        stn.MdiParent = this;
                        stn.Show();
                        break;
                    }
                case "Ngôn ngữ":
                    {
                        hf.set_text("       cập nhật thông tin danh mục à!!");
                        hf.set_anh(3);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        string query = " select IDNgonNgu as 'Mã ngôn ngữ',TenNgonNgu as 'Tên ngôn ngữ' from NgonNgu";
                        Formhienthi ht = new Formhienthi() { ChuoiKetNoi = query, BangKetNoi = "NgonNgu", TenCotMa = "Mã ngôn ngữ", TenCotTen = "Tên ngôn ngữ" };
                        ht.MdiParent = this;
                        ht.Show(); break;
                    }
                case "Khoa":
                    {
                        hf.set_text("       cập nhật thông tin danh mục à!!");
                        hf.set_anh(3);
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
                        hf.set_text("       Kiểm tra kỹ coi chừng có tài liệu hỏng thì phải click vô mục tài liệu hỏng!!");
                        hf.set_anh(2);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        FrmTraSach ts = new FrmTraSach();
                        ts.MdiParent = this;
                        ts.Show();
                        break;
                    }
                case "Thông tin tài liệu mượn theo ngày":
                    {
                        hf.set_text("       Để kiểm tra tài liệu mượn trong ngày nào đó hoặc có thể kiểm tra tình hình mượn tài liệu trong khoản thời gian nào đó có chọn thể thức mượn tài liệu!!");
                        hf.set_anh(2);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmthongtinsachtheongay tn = new Frmthongtinsachtheongay();
                        tn.MdiParent = this;
                        tn.Show();
                        break;
                    }
                case "Thông tin tài liệu hỏng":
                    {
                        hf.set_text("       Vào xem thông tin tài liệu hỏng để biết mà cập nhật tài liệu mới cho thư viên!!!");
                        hf.set_anh(3);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmthongtinsachhong ttsh = new Frmthongtinsachhong();
                        ttsh.MdiParent = this;
                        ttsh.Show();
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
                        hf.set_text("       Tìm xem hộ có tác giả nào tên tui không!!");
                        hf.set_anh(3);
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
                        hf.set_text("        Chú ý nhập tên server và mật khấu server cho đúng. Nếu muốn lưu thông tin đăng nhập lại thì click lưu để sau đăng nhập cho khoẻ");
                        hf.set_anh(2);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frdangnhap dn1 = new Frdangnhap();
                        dn1.ShowDialog(this);
                        dn1.MdiParent = this;
                        if (dn1.DialogResult == DialogResult.OK)
                        {
                            KTdangnhap dn = new KTdangnhap();
                            if (dn.kt_dangnhap(Frdangnhap.strtendn, Frdangnhap.strMatKhaudn))
                            {
                                s = "Người đang sử dụng chương trình có tài khoản là: " + KTdangnhap.strnguoidung.Trim() + " và quyền hạn là: " + KTdangnhap.strQuyenHan + "        ";
                                NhanVien nv = new NhanVien(KTdangnhap.idNhanVien, KTdangnhap.strMaNhanVien, KTdangnhap.strHoTen, KTdangnhap.strDiaChi, KTdangnhap.strQuyenHan, KTdangnhap.strnguoidung, KTdangnhap.strMatKhau);
                                Frmmain_Load(sender, e);
                                MessageBox.Show("Bạn đã đăng nhập thành công vào hệ thống với quyền hạn là: " + KTdangnhap.strQuyenHan, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else { MessageBox.Show("BAN DA NHAP KHONG ĐUNG DU LIEU"); }
                        }
                        break;
                    }
                case "Thay đổi thông tin cá nhân":
                    {
                        //hf.set_text("        Thông tin cá nhân bị sai chỗ nào à");
                        //hf.set_anh(3);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmthongtincanhan cn = new Frmthongtincanhan();
                        cn.MdiParent = this;
                        cn.Show();
                        break;
                    }
                case "Phân quyền":
                    {
                        hf.set_text("        Phân quyền có thể cùng một tài khoản đảm nhận nhiều chức năng và quyền hạn admin là duy nhất 1 tài khoản không thể tạo thêm tài khoản 2");
                        hf.set_anh(3);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmphanquyen pq = new Frmphanquyen();
                        pq.MdiParent = this;
                        pq.Show();
                        break;
                    }
                case "Phân loại tài liệu":
                    {
                        hf.set_text("        Nhập tài liệu cho ẩu rồi giờ phân loại lại, rõ khổ");
                        hf.set_anh(3);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        FrmTheLoaisach pl = new FrmTheLoaisach();
                        pl.MdiParent = this;
                        pl.Show();
                        break;
                    }
                case "Quản lý tài khoản":
                    {
                        hf.set_text("        Nhớ kiểm tra tư chất người mượn hẵng tạo tài khoản nghe, kẻo gặp đứa ăn cắp tài liệu !");
                        hf.set_anh(3);
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
                        hf.set_text("        Không nắm rõ thông tin tìm kiếm phải không ? chọn mục này là phải rồi");
                        hf.set_anh(3);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmtkcoban tkcb = new Frmtkcoban();
                        tkcb.Show();
                        break;
                    }
                case "Nâng cao":
                    {
                        hf.set_text("        Khi vô tìm kiếm được thông tin tài liệu cần tìm bạn có thể thực hiện chuyển tài liệu đó qua mục cập nhật thông tin thông qua nút xem chi tiết hoặc click d2 lần vô tài liệu cần xử lý");
                        hf.set_anh(3);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmtknangcao nc = new Frmtknangcao();
                        nc.MdiParent = this;
                        nc.Show();
                        break;
                    }
                case "Mượn tài liệu":
                    {
                        hf.set_text("       Chon mượn tài liệu nhớ cẩn thận kẻo mất tài liệu, kiểm tra kỹ thông tin của tài liệu, của độc giả rồi hãy cho mượn ");
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        Frmmuonsach ms = new Frmmuonsach();
                        ms.MdiParent = this;
                        ms.Show();
                        break;
                    }
                case "Danh mục tài liệu mượn":
                    {
                        hf.set_text("      Thong thả mà xem báo cáo tình hình mượn tài liệu của thư viện ");
                        hf.set_anh(3);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        laydulieu dl = new laydulieu();
                        DataSet ds = dl.getdata("select * from sach");
                        CrystalReportsachmuon rp = new CrystalReportsachmuon();
                        rp.SetDataSource(ds.Tables[0]);
                        Form1 f = new Form1();
                        f.crystalReportViewer1.ReportSource = rp;
                        f.MdiParent = this;
                        f.Show();

                        break;

                    }
                case "Danh mục tài liệu còn":
                    {
                        hf.set_text("      Báo cáo xem trong thư viện còn những cuốn tài liệu nào");
                        hf.set_anh(3);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        laydulieu dl = new laydulieu();
                        DataSet ds = dl.getdata("select * from sach where SoLuong > 0");
                        CrystalReportsachcon rp = new CrystalReportsachcon();
                        rp.SetDataSource(ds.Tables[0]);
                        Form1 f = new Form1();
                        f.crystalReportViewer1.ReportSource = rp;
                        f.MdiParent = this; timer2.Enabled = true;
                        f.Show();

                        break;
                    }
                case "Danh mục tài liệu đang mượn":
                    {
                        hf.set_text("      Báo cáo xem tài liệu nào đang được sinh viên mượn");
                        hf.set_anh(3);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        laydulieu dl = new laydulieu();
                        DataSet ds = dl.getdata("select phieumuon.* from sachmuon inner join phieumuon on sachmuon.maphieumuon = phieumuon.maphieumuon ");
                        CrystalReportdangmuon1 rp = new CrystalReportdangmuon1();
                        rp.SetDataSource(ds.Tables[0]);
                        Form1 f = new Form1();
                        f.crystalReportViewer1.ReportSource = rp;
                        f.MdiParent = this; timer2.Enabled = true;
                        f.Show();

                        break;
                    }
                case "Danh mục tài liệu hỏng":
                    {
                        hf.set_text("      Thong thả mà xem báo cáo tình hình tài liệu hỏng đi nha");
                        hf.set_anh(3);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        laydulieu dl = new laydulieu();
                        DataSet ds = dl.getdata("select * from sach inner join sachhong on sachhong.MaTaiLieu = sach.MaTaiLieu");
                        CrystalReportsachcon rp = new CrystalReportsachcon();
                        rp.SetDataSource(ds.Tables[0]);
                        Form1 f = new Form1();
                        f.crystalReportViewer1.ReportSource = rp;
                        f.MdiParent = this;
                        f.Show();

                        break;
                    }
                case "Danh mục tài liệu trễ hạn":
                    {
                        hf.set_text("      Xem báo cáo tình hình tài liệu trễ hạn ");
                        hf.set_anh(3);
                        ProgressBar1.Value = 0;
                        timer2.Enabled = true;
                        laydulieu dl = new laydulieu();
                        DataSet ds = dl.getdata("select phieumuon.* from sachmuon inner join phieumuon on sachmuon.maphieumuon = phieumuon.maphieumuon where (GETdate()- phieumuon.ngaymuon > day(7)) or (phieumuon.TheThucmuon=N'Mượn tại chỗ')");
                        CrystalReporttrehan rp = new CrystalReporttrehan();
                        rp.SetDataSource(ds.Tables[0]);
                        Form1 f = new Form1();
                        f.crystalReportViewer1.ReportSource = rp;
                        f.MdiParent = this;
                        f.Show();

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
            if (Frmhelpfast.an == false)
            {
                Frmhelpfast.an = true;
                hf.Show();
            }
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