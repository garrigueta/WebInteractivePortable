using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebInteractCSharpWinForm.Classes.Parser;

namespace WebInteractCSharpWinForm.Classes.Process
{
    class WebserverLoader
    {
        private System.Diagnostics.Process prcs;
        public WebserverLoader()
        {
            prcs = new System.Diagnostics.Process();
            prcs.StartInfo = new ProcessStartInfo(System.IO.Directory.GetCurrentDirectory() + "\\babyweb.exe");
            prcs.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            string res = prepareTmpFile();
            res = prepareIniFile(res);
            prcs.StartInfo.Arguments = "/Config:\"" + res + "\"";
            //MessageBox.Show(startInfo.Arguments);
            prcs.Start();

        }
        /// <summary>
        /// sets webserver path to BabyWebserver config file
        /// </summary>
        /// <param name="fileName">path of file to write</param>
        /// <returns>same path to reuse</returns>
        public string prepareIniFile(string fileName)
        {
            try
            {
                IniFile ini = new IniFile(fileName);
                ini.IniWriteValue("Settings", "WebPages", (System.IO.Directory.GetCurrentDirectory() + @"\docs").Replace("\\\\","\\"));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return fileName;
        }
        /// <summary>
        /// Creates temp file with project ini template content
        /// </summary>
        /// <returns>same path to reuse</returns>
        public string prepareTmpFile()
        {
            string fileName = TempFile.CreateTmpFile();
            try
            {
                string content = System.IO.File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "\\babyweb.ini");
                TempFile.UpdateTmpFile(fileName, content);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return fileName;
        }
        public void endProcess(object sender, FormClosedEventArgs e)
        {
            prcs.Kill();
        }
    }
}
