using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Mouser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var frm = new Form1())
            {
                frm.HotKeyId = 0x32;
                frm.FormClosed += (s, e) =>
                {
                    HotKeys.Unregister(frm, frm.HotKeyId);
                };

                Application.Run(frm);
            }

            return 0; // OK
        }
    }
}
