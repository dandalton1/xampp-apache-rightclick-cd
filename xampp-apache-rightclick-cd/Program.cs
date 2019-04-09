using System.IO;
using System;
using System.Threading;

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
         * Use for debugging
         **/
        static bool Debug = false;

        static void Main(string[] args)
        {
            try
            {
                string wd = Directory.GetCurrentDirectory();

                Console.WriteLine("Working directory: " + wd);

                Parser p = new Parser(httpd_conf, wd, Debug);

                p.Parse();

                pause();
            } catch (Exception e)
            {
                err(e);
            }
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
