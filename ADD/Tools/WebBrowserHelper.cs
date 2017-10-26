using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADD.Tools
{
    public class WebBrowserHelper
    {


        public static int GetEmbVersion()
        {
            int BrowserVer;

            // get the installed IE version
            using (WebBrowser Wb = new WebBrowser())
                BrowserVer = Wb.Version.Major;

            // set the appropriate IE version
            if (BrowserVer >= 11)
                return 11001;
            else if (BrowserVer == 10)
                return 10001;
            else if (BrowserVer == 9)
                return 9999;
            else if (BrowserVer == 8)
                return 8888;
            else
                return 7000;
        } // End Function GetEmbVersion

        public static void FixBrowserVersion()
        {
            string appName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location);
            FixBrowserVersion(appName);
        }

        public static void FixBrowserVersion(string appName)
        {
            FixBrowserVersion(appName, GetEmbVersion());
        } // End Sub FixBrowserVersion

        // FixBrowserVersion("<YourAppName>", 9000);
        public static void FixBrowserVersion(string appName, int ieVer)
        {
            FixBrowserVersion_Internal("HKEY_LOCAL_MACHINE", appName + ".exe", ieVer);
            FixBrowserVersion_Internal("HKEY_CURRENT_USER", appName + ".exe", ieVer);
            FixBrowserVersion_Internal("HKEY_LOCAL_MACHINE", appName + ".vshost.exe", ieVer);
            FixBrowserVersion_Internal("HKEY_CURRENT_USER", appName + ".vshost.exe", ieVer);
        } // End Sub FixBrowserVersion 

        private static void FixBrowserVersion_Internal(string root, string appName, int ieVer)
        {
            try
            {
                //For 64 bit Machine 
                if (Environment.Is64BitOperatingSystem)
                    Microsoft.Win32.Registry.SetValue(root + @"\Software\Wow6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", appName, ieVer);
                else  //For 32 bit Machine 
                    Microsoft.Win32.Registry.SetValue(root + @"\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", appName, ieVer);


            }
            catch (Exception)
            {
                // some config will hit access rights exceptions
                // this is why we try with both LOCAL_MACHINE and CURRENT_USER
            }
        } // End Sub FixBrowserVersion_Internal 

       


    }
}
