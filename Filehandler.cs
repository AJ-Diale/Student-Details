using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AppForms
{
    class Filehandler
    {
        static FileInfo fileinfo = new FileInfo(@"Users");
        List<User> usli = new List<User>();
        public void Writer(List<User> userlist)
        {
            FileStream file = fileinfo.Open(FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter writer = new StreamWriter(file);
            foreach (var item in userlist)
            {
                writer.WriteLine(item.ToString());
            }
            writer.Close();
            file.Close();

        }
        public List<string> ReadData(string filename)
        {
            FileStream filestream;
            StreamReader streamreader;
            List<string> userdata = new List<string>();
            filestream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            streamreader = new StreamReader(filestream);

            string line = string.Empty;

            while ((line = streamreader.ReadLine()) != null)
            {
                userdata.Add(line);
            }

            streamreader.Close();
            filestream.Close();

            return userdata;
        }
    }
}
