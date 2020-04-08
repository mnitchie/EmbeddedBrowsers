using System;
using WebWindows;
using System.IO;

namespace EmbeddedBrowser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Get the directory of the application, for use in locating
            // index.html
            var execPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            
            var window = new WebWindow("The Embedded Browser");
            window.NavigateToLocalFile(Path.Combine(execPath, "index.html"));
            window.WaitForExit();
        }
    }
}

