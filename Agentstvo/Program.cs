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
//доделать loadManager
//реализовать возможность хранения нескольких агентств
//создать большую модульность для объекта, не передавать объект в конструктор

namespace Agentstvo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<MyObject> listObjects = new List<MyObject>();
            Agency agency = new Agency();
            // ?????????
            bool clearFile = WriteToFile.ClearFile();
            
                int[] mass = MyObject.checkFile();

                // mass[0] - количество объектов в списке объектов
                // mass[1] - указанное количество объектов в информации об агентстве
                while (mass[0] != mass[1])
                {
                    MyObject myObject = new MyObject(agency);
                    mass[0]++;
                }
            //вызов функции для получения данных об объектах из файла
            //в функцию передается ссылка на коллекцию объектов куда добавляются новые объекты
            //решить как вызвать функцию не создавая объект
            //функция записи вызывается внутри объекта и все ок
            //функция чтения вызывается извне
            //изменить логику чтения
            //сделать чтобы явно создавался объект,вызывалась его функция и заполнялись поля
            //примерно MyObject myobject = new MyObject.Read();
            //для выбора чтения/записи объекта в файл используется 2 конструктора
            //в 1 передается агентство
            //во 2 передается массив с данными о полях
            //и 
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
