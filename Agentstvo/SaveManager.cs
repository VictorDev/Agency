using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Agentstvo
{
    class SaveManager
    {
        FileInfo file;
        StreamWriter sw;
        public SaveManager(String filename)
        {
            file = new FileInfo(filename+".txt");
            file.CreateText().Close();
        }
        public void WriteLine(String line)
        {
            sw = file.AppendText();
            sw.WriteLine(line);
            sw.Close();
        }
        public void WriteObject(IWritableObject obj)
        {
            obj.Write(this);
        }
    }
}
