using System;
using System.IO;

namespace Shooting {
    internal class ErrorLog {
        public static void SaveErrorLog(string Message,string Description) {
            string str = null+DateTime.Now.ToString("yyyy'/'MM'/'dd HH:mm")+"\r\n"+Message+"\r\n"+Description+"\r\n";
            string path = "Log.txt";
            StreamWriter streamWriter = File.Exists(path) ? new StreamWriter(path,true) : File.CreateText(path);
            streamWriter.Write(str);
            streamWriter.Close();
        }
    }
}
