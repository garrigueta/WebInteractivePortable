using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace WebInteractCSharpWinForm.Classes.RegKeys
{
    class RegistryChecker
    {
        /// <summary>
        /// Checks for BabyWebserver License
        /// </summary>
        public void checkRegistry()
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Pablo Software Solutions\\babyweb\\");

            if(rk == null)
            {
                RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Pablo Software Solutions");
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Pablo Software Solutions\\babyweb");
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Pablo Software Solutions\\babyweb\\Settings");
                key.SetValue("ShowLicense 2.7", 0);
                key.SetValue("UsageCount", 11);
                key.Close();
            }
        }
    }
    
}
