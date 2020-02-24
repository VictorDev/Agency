using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Agentstvo.MyObjects;
using Agentstvo.Owners;

namespace Agentstvo
{
    class WriteToFile
    {
        
        static public bool ClearFile()
        {
            string answer="";
            do {
                Console.WriteLine("Заменить данные об объектах? Да или нет");
                answer = Console.ReadLine();
            } while (!(answer.Equals("да") || answer.Equals("нет")));
            if (answer.Equals("да")) {
                StreamWriter sw = new StreamWriter("myobject.txt");
                sw.Write("");
                sw.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
