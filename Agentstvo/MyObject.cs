using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Agentstvo.Owners;
using Agentstvo.MyObjects;

/*в объекте агенство можно назначить количество объектов
тогда можно переписать функцию которая получает кол-во объектов считывая их с файла
    */
namespace Agentstvo
{
    class MyObject
    {
        private string name; //имя объекта
        private int price; //цена объекта
        private int square; //площадь объекта
        private string district; //район расположения
        private string street; //улица
        private string nHouse; //номер дома
        private ObjectType objectType;
        private string bargaining; //торг (есть/нет)
        private string description; //описание
        private string note; //примечания
        private string status; //статус (отложено, продано)
        private Property_Owner owner;
        private Agency agency;
        

        internal Property_Owner Owner { get => owner; set => owner = value; }
        public string Status { get => status; set => status = value; }
        public string Note { get => note; set => note = value; }
        public string Description { get => description; set => description = value; }
        public string Bargaining { get => bargaining; set => bargaining = value; }
        public string NHouse { get => nHouse; set => nHouse = value; }
        public string Street { get => street; set => street = value; }
        public string District { get => district; set => district = value; }
        public int Square { get => square; set => square = value; }
        public int Price { get => price; set => price = value; }
        public string Name { get => name; set => name = value; }
        internal ObjectType ObjectType { get => objectType; set => objectType = value; }

        public MyObject(Agency agency)
        {
            this.agency = agency;
            Console.WriteLine("Введите данные об объекте");
                input();
                WriteToFile.Write(this);
           
            
        }

        public MyObject(string[] mass)
        {
            name = mass[0];
            price = int.Parse(mass[1]);
            square = int.Parse(mass[2]);
            district = mass[3];
            street = mass[4];
            nHouse = mass[5];
            if (mass[6].Equals("Участок"))
            {
                objectType = new LandPlot();
            }
            else if (mass[6].Equals("Дом"))
            {
                string[] data = { mass[7] };
                objectType = new House(data);
            }
            else if (mass[6].Equals("Квартира"))
            {
                string[] data = { mass[7], mass[8] };
                objectType = new Apartment(data);
            }
            else
            {
                string[] data = { mass[7] };
                objectType = new LivingRoom(data);
            }
            bargaining = mass[9];
            description = mass[10];
            note = mass[11];
            status = mass[12];
            if (mass[13].Equals("Физ. лицо"))
            {
                string[] data = { mass[14], mass[15] };
                owner = new Owner(data);
            }
            else if (mass[13].Equals("Агенство"))
            {
                string[] data = { mass[14], mass[15], mass[16] };
                owner = new Agency(data);
            }
        }

        public static int[] checkFile()
        {
            StreamReader sr = new StreamReader("agency.txt");
            string line = sr.ReadToEnd();
            char[] r = { ':', '\n' };
            string[] mass = line.Split(r);
            int numberOfObject = int.Parse(mass[7]);
            string[] strok = File.ReadAllLines("myobject.txt");
            int numberOfObjectOfFile = strok.Length / 17;
            if (strok.Length == 0)
            {
                Console.WriteLine("Файл с данными об объектах пуст. Необходимо заполнить данные об объектах");
                return new int[] {0,numberOfObject};

            }
            else if(numberOfObjectOfFile<numberOfObject)
            {
                Console.WriteLine("В файле недостаточно данных об объектах. Введите недостающие данные");
                return new int[] { numberOfObjectOfFile, numberOfObject };
            }
            return new int[] { numberOfObject, numberOfObject};
            

        }

        public static int checkCountObject()
        {
            string[] strok = File.ReadAllLines("myobject.txt");
            return strok.Length / 17;
        }

        void input()
        {
            inputValue(ref name, "Введите имя объекта: ");
            inputValue(ref price, "Введите цену объекта: ");
            inputValue(ref square, "Введите площадь(кв.м): ");
            inputValue(ref district, "Введите район: ");
            inputValue(ref street, "Введите улицу: ");
            inputValue(ref nHouse, "Введите номер дома: ");
            int cache = 0;
            do
            {
                
                Console.WriteLine("Введите вид недвижимости.\n 1 - участок\n 2 - дом\n 3 - квартира\n 4 - гостинка");
                bool cacheB = true;
                do
                {
                    cacheB = int.TryParse(Console.ReadLine(), out cache);
                } while (cache>4||cache < 0 || !cacheB);
                switch (cache)
                {
                    case 1: objectType = new LandPlot(); break;
                    case 2: objectType = new House(); break;
                    case 3: objectType = new Apartment(); break;
                    case 4: objectType = new LivingRoom(); break;
                }
                
            } while (cache<1||cache>4);
            do
            {
                Console.WriteLine("Возможен торг? Да или нет: ");
                bargaining = Console.ReadLine();
            } while (!(bargaining.Equals("да") || bargaining.Equals("нет")));
            inputValue(ref description, "Введите описание объекта: ");
            Console.WriteLine("Примечания: ");
            Note = Console.ReadLine();
            if (note.Length == 0)
            {
                note = "-";
            }
            Console.WriteLine("Выберите статус: 1 - продано, 2 - продается, 3 - другое ");
            bool cache3 = true;
            do
            {
                status = Console.ReadLine();
                if (status.Equals("1"))
                {
                    cache3 = false;
                    owner = new Owner();
                    status = "Продано";
                }
                else if (status.Equals("2"))
                {
                    cache3 = false;
                    owner = agency;
                    status = "Продается";
                }
                else if (status.Equals("3"))
                {
                    cache3 = false;
                    status = Console.ReadLine();
                    owner = agency;
                }
            } while (cache3);
        }
        public static void inputValue(ref int v, string request)
        {
            bool cache = true;
            do
            {
                Console.WriteLine(request);
                cache = int.TryParse(Console.ReadLine(), out v);
            } while (v < 0 || !cache);
        }

        public static void inputValue(ref string v, string request)
        {
            do
            {
                Console.WriteLine(request);
                v = Console.ReadLine();
            } while (v.Length==0);
        }
    }
}
