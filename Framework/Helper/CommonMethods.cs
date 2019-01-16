using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Helper
{
    public class CommonMethods
    {
        IWebDriver webDriver;
        string path;
        string user;

        public CommonMethods()
        {
            this.user = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Desktop";
            this.path = user + "\\tempScreenshotFolder";
        }

        public CommonMethods(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.user = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Desktop";
            this.path = user + "\\tempScreenshotFolder";
            //this.wait = new OpenQA.Selenium.Support.UI.WebDriverWait(webDriver, TimeSpan.FromMinutes(4));
        }


        //public static string TestOpenLogFile(string tcName)
        //{
        //    //Trace.Flush();
        //    //Trace.Close();
        //    string ur = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Desktop";
        //    string p = ur + "\\tempScreenshotFolder";
        //    string folder;
        //    folder = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");



        //    if (!Directory.Exists(p)) { Directory.CreateDirectory(p); }

        //    DirectoryInfo DirInfo = new DirectoryInfo(ur + "\\Evidences\\");

        //    if (!DirInfo.Exists)
        //    {
        //        DirInfo.Create();
        //    }

        //    string fileWithPath = ur + "\\tempScreenshotFolder\\" + tcName + "_" + folder + "_ExecutionLog.txt";
        //    //string fileWithPath = ur + "\\Evidences\\" + tcName + "_" + folder + "_ExecutionLog.txt";

        //    using (var listener = new TextWriterTraceListener(fileWithPath))
        //    {
        //        Trace.Listeners.Add(listener);
        //        Trace.AutoFlush = true;
        //        Trace.WriteLine(String.Format("{0:yyyy-MM-dd} {0:HH:mm:ss}", DateTime.Now) +
        //            " Test => " + tcName);
        //        Trace.Indent();
        //    }
        //    return fileWithPath;
        //}


        public void screenShot()
        {
            //Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
            //String timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            //ss.SaveAsFile(path + "\\" + timestamp + text + ".jpg", ScreenshotImageFormat.Jpeg);

            Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
            ss.SaveAsFile(@"C:\temp\uno.jpg");
        }



        StringBuilder sb;
        public void OpenLog()
        {
            sb = new StringBuilder();
        }

        public void Log(string text)
        {
            sb.Append(text);
        }

        public void CloseLog()
        {
            File.AppendAllText(@"C:\temp\log.txt", sb.ToString());
            sb.Clear();
        }
      
            
    }
}
