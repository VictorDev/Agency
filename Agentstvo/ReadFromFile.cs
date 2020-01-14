using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Agentstvo.Owners;
using Agentstvo.MyObjects;

namespace Agentstvo
{
    class ReadFromFile
    {
        /*static public void Read(Agency agency)
        {
            StreamReader sr = new StreamReader("agency.txt");

            string line = sr.ReadToEnd();
            char[] r = { ':', '\n' };
            string[] mass = line.Split(r);
            for (int i = 1; i < mass.Length; i += 2)
            {
                
                switch (i)
                {
                    
                    case 1: agency.Name = mass[i]; break;
                    case 3: agency.Phone = mass[i]; break;
                    case 5: agency.Address = mass[i]; break;
                }

            }
        }*/

        static public void Read(Agency agency)
        {
            StreamReader sr = new StreamReader("agency.txt");
            for(int i = 0; i < 3; i++)
            {
                string line1 = sr.ReadLine();
                string element = line1.Split(':')[1];
                switch (i)
                {

                    case 0: agency.Name = element; break;
                    case 1: agency.Phone = element; break;
                    case 2: agency.Address = element; break;
                }
            }
        }

        static public void Read(ref List<MyObject> myObjects)
        {
            StreamReader sr = new StreamReader("myobject.txt");
            int j = 0;
            string[] mass = new string[30];
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                mass[j] = line.Split(':')[1];
                if (line.Equals("-:---"))
                {
                    myObjects.Add(new MyObject(mass));
                    j = 0;
                }
                else { j++; }
                
            }
            sr.Close();
        }
    }
}
