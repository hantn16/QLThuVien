using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using quanly.lopdulieu;
using System.Drawing.Printing;
namespace quanly.frm
{
    public partial class frmtaothe : Form
    {
        public frmtaothe()
        {
            InitializeComponent();
        }

        private void tsBtnLuuMau_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.WriteLine(txt1.Font.FontFamily.GetName(1));
                sw.WriteLine(txt1.Font.Size.ToString());
                sw.WriteLine(txt1.Font.Style.ToString());

                sw.WriteLine(txt2.Font.FontFamily.GetName(1));
                sw.WriteLine(txt2.Font.Size.ToString());
                sw.WriteLine(txt2.Font.Style.ToString());

                sw.WriteLine(txt3.Font.FontFamily.GetName(1));
                sw.WriteLine(txt3.Font.Size.ToString());
                sw.WriteLine(txt3.Font.Style.ToString());

                sw.WriteLine(txt4.Font.FontFamily.GetName(1));
                sw.WriteLine(txt4.Font.Size.ToString());
                sw.WriteLine(txt4.Font.Style.ToString());

                sw.WriteLine(txt5.Font.FontFamily.GetName(1));
                sw.WriteLine(txt5.Font.Size.ToString());
                sw.WriteLine(txt5.Font.Style.ToString());

                sw.WriteLine(txt6.Font.FontFamily.GetName(1));
                sw.WriteLine(txt6.Font.Size.ToString());
                sw.WriteLine(txt6.Font.Style.ToString());

                sw.WriteLine(txt7.Font.FontFamily.GetName(1));
                sw.WriteLine(txt7.Font.Size.ToString());
                sw.WriteLine(txt7.Font.Style.ToString());

                sw.WriteLine(txt8.Font.FontFamily.GetName(1));
                sw.WriteLine(txt8.Font.Size.ToString());
                sw.WriteLine(txt8.Font.Style.ToString());

                sw.WriteLine(txt9.Font.FontFamily.GetName(1));
                sw.WriteLine(txt9.Font.Size.ToString());
                sw.WriteLine(txt9.Font.Style.ToString());

                sw.WriteLine(txt10.Font.FontFamily.GetName(1));
                sw.WriteLine(txt10.Font.Size.ToString());
                sw.WriteLine(txt10.Font.Style.ToString());

                sw.WriteLine(txt11.Font.FontFamily.GetName(1));
                sw.WriteLine(txt11.Font.Size.ToString());
                sw.WriteLine(txt11.Font.Style.ToString());

                sw.WriteLine(txt12.Font.FontFamily.GetName(1));
                sw.WriteLine(txt12.Font.Size.ToString());
                sw.WriteLine(txt12.Font.Style.ToString());

                sw.WriteLine(txt13.Font.FontFamily.GetName(1));
                sw.WriteLine(txt13.Font.Size.ToString());
                sw.WriteLine(txt13.Font.Style.ToString());

                sw.WriteLine(txt14.Font.FontFamily.GetName(1));
                sw.WriteLine(txt14.Font.Size.ToString());
                sw.WriteLine(txt14.Font.Style.ToString());

                sw.WriteLine(txt15.Font.FontFamily.GetName(1));
                sw.WriteLine(txt15.Font.Size.ToString());
                sw.WriteLine(txt15.Font.Style.ToString());
                sw.Close();
            }
        }

        private void tsBtnLayMau_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string kieufont = "";
                float cochu = 0;
                string kieuchu = "";
               
                StreamReader sw = File.OpenText(openFileDialog1.FileName);
                try
                {
                    Font f=null;
                    for (int i = 1; i < 16; i++)
                    {
                        kieufont = sw.ReadLine();
                        cochu = float.Parse(sw.ReadLine());
                        kieuchu = sw.ReadLine();
                        switch (kieuchu)
                        {
                            case "Regular":
                                {
                                    f = new Font(kieufont, cochu, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                    break;
                                }
                            case "Bold":
                                {
                                    f = new Font(kieufont, cochu, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                    break;
                                }
                            case "Italic":
                                {
                                    f = new Font(kieufont, cochu, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                    break;
                                }
                            case "Strikeout":
                                {
                                    f = new Font(kieufont, cochu, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                    break;
                                }
                            case "Underline":
                                {
                                    f = new Font(kieufont, cochu, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                    break;
                                }
                        }
                        switch (i)
                        {
                            case 1:
                                {
                                    txt1.Font = f;
                                    break;
                                }
                            case 2:
                                {
                                    txt2.Font = f;
                                    break;
                                }
                            case 3:
                                {
                                    txt3.Font = f;
                                    break;
                                }
                            case 4:
                                {
                                    txt4.Font = f;
                                    break;
                                }
                            case 5:
                                {
                                    txt5.Font = f;
                                    break;
                                }
                            case 6:
                                {
                                    txt6.Font = f;
                                    break;
                                }
                            case 7:
                                {
                                    txt7.Font = f;
                                    break;
                                }
                            case 8:
                                {
                                    txt8.Font = f;
                                    break;
                                }
                            case 9:
                                {
                                    txt9.Font = f;
                                    break;
                                }
                            case 10:
                                {
                                    txt10.Font = f;
                                    break;
                                }
                            case 11:
                                {
                                    txt11.Font = f;
                                    break;
                                }
                            case 12:
                                {
                                    txt12.Font = f;
                                    break;
                                }
                            case 13:
                                {
                                    txt3.Font = f;
                                    break;
                                }
                            case 14:
                                {
                                    txt14.Font = f;
                                    break;
                                }
                            case 15:
                                {
                                    txt15.Font = f;
                                    break;
                                }
                        }
                    }
                }
                catch { MessageBox.Show("Kiểu font này không được hỗ trợ"); };
                this.Refresh();

                sw.Close();
            }
        
        }
        private void tsBtnIn_Click(object sender, EventArgs e)
        {
          
                printPreviewDialog1.ShowDialog();
           
        }
        int j = 0, i = 0; int tam1 = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
             i = 0;
            while(j< listView1.CheckedItems.Count)
            {
               
                if (tam1 == 3)
                {

                    e.HasMorePages = true;
                    tam1 = 0;
                    return;
                }
                else
                {
                        tam1++;
                        e.Graphics.DrawString(txt1.Text, txt1.Font, Brushes.Black, txt1.Location.X, txt1.Location.Y + i);
                        e.Graphics.DrawString(txt2.Text, txt2.Font, Brushes.Black, txt2.Location.X, txt2.Location.Y + i);
                        e.Graphics.DrawString(txt3.Text, txt3.Font, Brushes.Black, txt3.Location.X, txt3.Location.Y + i);
                        e.Graphics.DrawString(txt4.Text, txt4.Font, Brushes.Black, txt4.Location.X, txt4.Location.Y + i);
                        e.Graphics.DrawString(txt5.Text, txt5.Font, Brushes.Black, txt5.Location.X, txt5.Location.Y + i);
                        e.Graphics.DrawString(listView1.CheckedItems[j].Text, txt6.Font, Brushes.Black, txt6.Location.X, txt6.Location.Y + i);
                        e.Graphics.DrawString(txt7.Text, txt7.Font, Brushes.Black, txt7.Location.X, txt7.Location.Y + i);
                        e.Graphics.DrawString(listView1.CheckedItems[j].SubItems[1].Text, txt8.Font, Brushes.Black, txt8.Location.X, txt8.Location.Y + i);
                        e.Graphics.DrawString(txt9.Text, txt9.Font, Brushes.Black, txt9.Location.X, txt9.Location.Y + i);
                        e.Graphics.DrawString(listView1.CheckedItems[j].SubItems[2].Text.Substring(0, 10), txt10.Font, Brushes.Black, txt10.Location.X, txt10.Location.Y + i);
                        e.Graphics.DrawString(txt11.Text, txt11.Font, Brushes.Black, txt11.Location.X, txt11.Location.Y + i);
                        e.Graphics.DrawString(listView1.CheckedItems[j].SubItems[3].Text, txt12.Font, Brushes.Black, txt12.Location.X, txt12.Location.Y + i);
                        e.Graphics.DrawString(txt13.Text, txt13.Font, Brushes.Black, txt13.Location.X, txt13.Location.Y + i);
                        e.Graphics.DrawString(listView1.CheckedItems[j].SubItems[4].Text, txt14.Font, Brushes.Black, txt14.Location.X, txt14.Location.Y + i);
                        e.Graphics.DrawString(txt15.Text, txt15.Font, Brushes.Black, txt15.Location.X, txt15.Location.Y + i);
                        try
                        {
                            e.Graphics.DrawImage(Image.FromFile(st[listView1.CheckedItems[j].Index]),
                                              new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y + i,
                                              pictureBox1.Width, pictureBox1.Height));
                        }
                        catch { };
                        i = i + txt15.Location.Y + 300; j++;
            
                }
                
            }


            e.HasMorePages = false;
        }
        string[] st=new string[100];
        SqlDataReader dr;
        public void set_dr(SqlDataReader dr)
        {
            this.dr = dr;
        }
        private void frmtaothe_Load(object sender, EventArgs e)
        {
            if (dr == null)
            {
                laydulieu dl = new laydulieu();
                dr = dl.lay_reader("select * from DocGia order by MaDocGia desc");
            }
            int tam = 0;
            while (dr.Read())
            {
                try
                {
                    listView1.Items.Add(dr[0].ToString());
                    st[tam] = listView1.Items[tam].Text;
                    listView1.Items[tam].SubItems.Add(dr[1].ToString());
                    listView1.Items[tam].SubItems.Add(dr[2].ToString());
                    string luu = dr[4].ToString();
                    listView1.Items[tam].SubItems.Add(luu.Substring(0, luu.Length - 3));
                    listView1.Items[tam].SubItems.Add(luu.Substring(luu.Length - 3, 3));
                    listView1.Items[tam].SubItems.Add(dr[5].ToString());
                    tam++;
                }
                catch
                {
                    MessageBox.Show("Lỗi dữ liệu nhập vào");
                    Frmmain.hf.set_text("   Kiểm tra lại dữ liệu nhập vào đi xem có đúng không");
                }

            }
            L_Ketnoi.HuyKetNoi();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt6.Text = listView1.SelectedItems[0].Text;
                txt8.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txt10.Text = listView1.SelectedItems[0].SubItems[2].Text.Substring(0, 10);
                txt12.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txt14.Text = listView1.SelectedItems[0].SubItems[4].Text;
                try
                {
                    pictureBox1.BackgroundImage = Image.FromFile(st[listView1.SelectedItems[0].Index]);
                }
                catch { pictureBox1.BackgroundImage = null; }
            }
            catch { };
        }
        void set_textbox(string tam)
        {
            switch (tam)
            {
                case "txt1":
                    {
                        txt1.Font = fontDialog1.Font;
                        break;
                    }
                case "txt2":
                    {
                        txt2.Font = fontDialog1.Font;
                        break;
                    }
                case "txt3":
                    {
                        txt3.Font = fontDialog1.Font;
                        break;
                    }
                case "txt4":
                    {
                        txt4.Font = fontDialog1.Font;
                        break;
                    }
                case "txt5":
                    {
                        txt5.Font = fontDialog1.Font;
                        break;
                    }
                case "txt6":
                    {
                        txt6.Font = fontDialog1.Font;
                        break;
                    }
                case "txt7":
                    {
                        txt7.Font = fontDialog1.Font;
                        break;
                    }
                case "txt8":
                    {
                        txt8.Font = fontDialog1.Font;
                        break;
                    }
                case "txt9":
                    {
                        txt9.Font = fontDialog1.Font;
                        break;
                    }
                case "txt10":
                    {
                        txt10.Font = fontDialog1.Font;
                        break;
                    }
                case "txt11":
                    {
                        txt11.Font = fontDialog1.Font;
                        break;
                    }
                case "txt12":
                    {
                        txt12.Font = fontDialog1.Font;
                        break;
                    }
                case "txt13":
                    {
                        txt3.Font = fontDialog1.Font;
                        break;
                    }
                case "txt14":
                    {
                        txt14.Font = fontDialog1.Font;
                        break;
                    }
                case "txt15":
                    {
                        txt15.Font = fontDialog1.Font;
                        break;
                    }
            }
        }
        private void chọnFontMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                set_textbox(tam);
        }

        private void chọnChếĐộMặcĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
             StreamReader sw = File.OpenText("fontmacdinh.ma");
             string kieufont = "";
             float cochu = 0;
             string kieuchu = "";
             Font f=null;
             for (int i = 1; i < 16; i++)
             {
                kieufont = sw.ReadLine();
                cochu = float.Parse(sw.ReadLine());
                kieuchu = sw.ReadLine();
                #region
                switch (kieuchu)
                {
                    case "Regular":
                        {
                            f = new Font(kieufont, cochu, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        }
                    case "Bold":
                        {
                            f = new Font(kieufont, cochu, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        }
                    case "Italic":
                        {
                            f = new Font(kieufont, cochu, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        }
                    case "Strikeout":
                        {
                            f = new Font(kieufont, cochu, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        }
                    case "Underline":
                        {
                            f = new Font(kieufont, cochu, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        }
                }
                switch (i)
                {
                    case 1:
                        {
                            txt1.Font = f;
                            break;
                        }
                    case 2:
                        {
                            txt2.Font = f;
                            break;
                        }
                    case 3:
                        {
                            txt3.Font = f;
                            break;
                        }
                    case 4:
                        {
                            txt4.Font = f;
                            break;
                        }
                    case 5:
                        {
                            txt5.Font = f;
                            break;
                        }
                    case 6:
                        {
                            txt6.Font = f;
                            break;
                        }
                    case 7:
                        {
                            txt7.Font = f;
                            break;
                        }
                    case 8:
                        {
                            txt8.Font = f;
                            break;
                        }
                    case 9:
                        {
                            txt9.Font = f;
                            break;
                        }
                    case 10:
                        {
                            txt10.Font = f;
                            break;
                        }
                    case 11:
                        {
                            txt11.Font = f;
                            break;
                        }
                    case 12:
                        {
                            txt12.Font = f;
                            break;
                        }
                    case 13:
                        {
                            txt3.Font = f;
                            break;
                        }
                    case 14:
                        {
                            txt14.Font = f;
                            break;
                        }
                    case 15:
                        {
                            txt15.Font = f;
                            break;
                        }
                }
#endregion
             }
           sw.Close();
           }
        string tam = "";
        private void txt1_Click(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            tam = tb.Name.ToString();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.BackgroundImage = Image.FromFile(openFileDialog2.FileName);
                    st[listView1.SelectedItems[0].Index] = openFileDialog2.FileName;
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
                listView1.Items[i].Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < listView1.Items.Count; i++)
                listView1.Items[i].Checked = !listView1.Items[i].Checked;
        }
    }
}