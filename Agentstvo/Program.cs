using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agentstvo.MyObjects;
using Agentstvo.Owners;
using SaveLoadManager;


namespace Agentstvo
{
    class Program
    {
        static void Main(string[] args)
        {
            string cache;
            List<Agency> aList = new List<Agency>();
            do
            {
                Console.WriteLine("Заменить данные об агентстве? Да или нет");
                cache = Console.ReadLine();
                if (cache.Equals("да"))
                {
                    WriteToFile.ClearFileAgency();
                    Agency agency = new Agency("agency");
                }
            } while (!(cache.Equals("да") || cache.Equals("нет")));

            LoadManager loader1 = new LoadManager("agency");
            Logger logger = new Logger(new FileInfo("log.txt").AppendText());
            LoadLogger loadLogger = new LoadLogger(loader1, logger);
            loader1.BeginRead();
            while (loader1.IsLoading)
                aList.Add(loader1.Read(new Agency.Loader()) as Agency);
            loader1.EndRead();
            bool clearFile = WriteToFile.ClearFile();
            if (clearFile)
            {
                for (int i = 0; i < aList[0].Cout; i++)
                {
                    MyObject myObject = new MyObject(aList[0], "myobject");
                }
            }
            LoadManager loader = new LoadManager("myobject");
            Logger logger1 = new Logger(new FileInfo("log1.txt").AppendText());
            LoadLogger loadLogger1 = new LoadLogger(loader, logger1);
            List<MyObject> sList = new List<MyObject>();
            loader.BeginRead();
            while (loader.IsLoading)
                sList.Add(loader.Read(new MyObject.Loader()) as MyObject);
            loader.EndRead();
            Console.Write("Агенство недвижимости ");
            Console.Write(aList[0].Name);
            Console.WriteLine(": ");
            foreach (MyObject m in sList)
                Console.WriteLine($" - {m.Name} ({m.Status})");
            Console.ReadKey();

            Console.ReadKey();
        }
    }
}
