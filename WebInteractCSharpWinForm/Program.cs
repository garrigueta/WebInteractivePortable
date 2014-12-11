using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WebInteractCSharpWinForm.Classes.Process;
using WebInteractCSharpWinForm.Classes.RegKeys;

namespace WebInteractCSharpWinForm
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
            RegistryChecker rc = new RegistryChecker();
            rc.checkRegistry();
            WebserverLoader wsl = new WebserverLoader();
            Form1 frm = new Form1();
            frm.FormClosed += new FormClosedEventHandler(wsl.endProcess);
            
            Application.Run(frm);
        }
        
    }
}
