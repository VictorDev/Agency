using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Agentstvo
{
    class LoadManager
    {
        FileInfo file;
        StreamReader sr;
        public LoadManager(String filename)
        {
            file = new FileInfo(filename + ".txt");
            //file.CreateText().Close();
        }

        public void ReadObject(IReadableObject obj)
        {
            
            obj.Read(this);
        }
    }
}
