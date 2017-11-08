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

namespace quanly.frm
{
    public partial class Frmthongtinsachhong : Form
    {
        public Frmthongtinsachhong()
        {
            InitializeComponent();
        }
        DataSet ds ;
        CurrencyManager cm ;
        private void Frmthongtinsachhong_Load(object sender, EventArgs e)
        {
            Frmmain.tt = true;
            load_grid();
        }
        public void load_grid()
        {
           
                laydulieu dl = new laydulieu();
                ds = dl.getdata("select masachhong,sach.* from sach,sachhong where sach.masach = sachhong.masach ");
                cm = BindingContext[this.ds.Tables[0]] as CurrencyManager;    
                dataGridView1.DataSource = ds.Tables[0];
                
        }
        string masachhong(string tam)
        {
            if (tam == "") return "SH0000";
            int ma = int.Parse(tam.Substring(2, tam.Length - 2));
            ma++;
            if (ma < 10) return "SH000" + ma.ToString();
            else
                if (ma < 100) return "SH00" + ma.ToString();
                else
                    if (ma < 1000) return "SH0" + ma.ToString();
                    else return "SH" + ma.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Frmthongbao tb = new Frmthongbao();
            tb.ShowDialog(this);
            if (tb.DialogResult == DialogResult.OK)
            {
                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select masach from sach where masach='" + Frmthongbao.tam + "' ");
                string tam="";
                while (dr.Read())
                    tam = dr[0].ToString();
                L_Ketnoi.HuyKetNoi();
                if (tam != "")
                {
                    L_Ketnoi.ThietlapketNoi();
                    SqlDataReader dr1 = dl.lay_reader("select masachhong from sachhong");
                    string strtam = "";
                    while (dr1.Read())
                        strtam = dr1[0].ToString();
                    L_Ketnoi.HuyKetNoi();
                    Lsachhong sh = new Lsachhong(masachhong(strtam),Frmthongbao.tam);
                    if (sh.taomoi())
                    {
                        load_grid();
                        MessageBox.Show("Thao tác thành công", "Thông báo");
                    }
                    else MessageBox.Show("Lỗi trong tạo mới", "Thông báo");
                }
                else
                {
                    if (MessageBox.Show("Không có đối tượng sách này hãy nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                        tb.ShowDialog(this);
                }
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Lsachhong sh = new Lsachhong(ds.Tables[0].Rows[cm.Position][0].ToString(), ds.Tables[0].Rows[cm.Position][1].ToString());
                if (MessageBox.Show("Bạn có thật sự muốn thực hiện thao tác xoá", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (sh.xoabo())
                    {
                        load_grid();
                        MessageBox.Show("Thao tác thành công", "Thông báo");
                    }
                    else MessageBox.Show("Lỗi trong xoá danh sách", "Thông báo");
                }
            }
            catch { MessageBox.Show("Không còn đối tượng sách hỏng trong danh mục", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

         private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == 46) button1_Click(sender, e);
        

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Frmthongtinsachhong_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frmmain.tt = false;
        }

       
    }
}