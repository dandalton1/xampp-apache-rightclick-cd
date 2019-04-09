using System.IO;
using System;
using System.Diagnostics;

namespace xampp_apache_rightclick_cd
{
    class Program
    {
        /**
         * Change me if your http_conf is NOT C:\xampp\apache\conf\httpd.conf
         * 
         * C# also needs to replace one backslash with two (C:\xampp -> C:\\xampp)
         **/
        static string httpd_conf = "C:\\xampp\\apache\\conf\\httpd.conf";

        /**
         * Change me if your httpd.exe is NOT C:\xampp\apache\bin\httpd.exe
         **/
        static string httpd_loc = "C:\\xampp\\apache\\bin\\httpd.exe";

        /**
         * Use for debugging
         **/
        static bool Debug = false;

        static int Main(string[] args)
        {
            try
            {
                string wd = Directory.GetCurrentDirectory();

                foreach (Process process in Process.GetProcessesByName("httpd"))
                {
                    Console.WriteLine("Stopping httpd (PID " + process.Id + " ...");
                    process.Kill();
                }

                Parser p = new Parser(httpd_conf, wd, Debug);

                p.Parse();

                Console.WriteLine("Done.");

                pause();

                Console.WriteLine("Starting httpd...");

                Process httpd_proc = new Process();
                httpd_proc.StartInfo.CreateNoWindow = true;
                httpd_proc.StartInfo.UseShellExecute = false;
                httpd_proc.StartInfo.FileName = httpd_loc;
                httpd_proc.Start();
            } catch (Exception e)
            {
                err(e);
                return 1;
            }
            return 0;
        }

        static void err(Exception e)
        {
            Console.Error.WriteLine("ERROR: " + e.Message);
            Console.Error.WriteLine(e.StackTrace);
            pause();
        }

        static void pause()
        {
            if (Debug)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
