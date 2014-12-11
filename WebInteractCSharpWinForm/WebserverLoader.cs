using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebInteractCSharpWinForm
{
    class WebserverLoader
    {
        public WebserverLoader()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(System.IO.Directory.GetCurrentDirectory() + "\\babyweb.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            startInfo.Arguments = "//Config:.\babyweb.ini";
            Process.Start(startInfo);

            //startInfo.Arguments = "/Config:.\babyweb.ini";

            //Process.Start(startInfo);
            //MessageBox.Show(Application.StartupPath);
        }
    }
}
