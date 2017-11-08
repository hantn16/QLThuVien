using System;
using System.Collections.Generic;
using System.Windows.Forms;
using quanly.frm;
using quanlythuvien.Thong_ke_bao_cao;

namespace quanly.frm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frmmain());
        }
    }
}