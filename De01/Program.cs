using System;
using System.Windows.Forms;

namespace De01
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmSinhvien());
        }
    }
}

