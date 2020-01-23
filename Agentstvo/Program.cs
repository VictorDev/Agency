using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agentstvo.MyObjects;
using Agentstvo.Owners;

//перенести запись в файл в каждый класс
//управлять записью будет класс savemanager

namespace Agentstvo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MyObject> listObjects = new List<MyObject>();
            Agency agency = new Agency();
            bool clearFile = WriteToFile.ClearFile();
            
                int[] mass = MyObject.checkFile();

                while (mass[0] != mass[1])
                {
                    MyObject myObject = new MyObject(agency);
                    mass[0]++;
                }
            
            ReadFromFile.Read(ref listObjects);
            Console.WriteLine();
            Console.Write("Агенство недвижимости ");
            Console.WriteLine(agency.Name);
            Console.Write("Всего объектов ");
            Console.WriteLine(listObjects.Count);
            for (int i = 0; i < listObjects.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {listObjects[i].Name} ({listObjects[i].Status})");
            }
            Console.ReadKey();
        }
    }
}
