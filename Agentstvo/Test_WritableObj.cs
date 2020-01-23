using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agentstvo
{
    class Test_WritableObj:IWritableObject
    {
        public int number;
        public string subject;
        public void Write(SaveManager man)
        {
            man.WriteLine($"subject:{subject}");
            man.WriteLine($"number:{number}");
        }
    }
}
