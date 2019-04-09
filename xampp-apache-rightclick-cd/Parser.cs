using System;
using System.IO;
using System.Text;

namespace xampp_apache_rightclick_cd
{
    class Parser
    {
        private string filename;
        private string workingDir;
        private bool debug;
        
        public Parser(string fName, string wDir, bool d)
        {
            filename = fName;
            workingDir = wDir;
            debug = d;
        }

        public void Parse()
        {
            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                string line = "";
                StringBuilder stringBuilder = new StringBuilder();
                TextWriter writer = debug ? Console.Out : new StringWriter(stringBuilder);

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("DocumentRoot"))
                    {
                        writer.WriteLine("DocumentRoot \"" + workingDir + "\"");
                        line = reader.ReadLine(); // trash the next line of the file, since it's more than likely a "Directory" directive
                        writer.WriteLine("<Directory \"" + workingDir + "\">");
                        writer.WriteLine(reader.ReadToEnd()); // write all of the rest of the file
                        break; // end parse
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                }

                reader.Close();

                if (!debug)
                {
                    StreamWriter fileWriter = new StreamWriter(filename);

                    fileWriter.WriteLine(stringBuilder.ToString());

                    fileWriter.Flush();

                    fileWriter.Close();
                }
            } else
            {
                throw new FileNotFoundException("XAMPP Apache httpd.conf file " + filename + " not found.");
            }
        }
    }
}
