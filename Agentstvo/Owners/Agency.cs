﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Agentstvo.Owners
{
    class Agency:Property_Owner
    {
        private const string type = "Агенство";
        private string name; //имя
        private string phone; //телефон
        private string address; //адрес
        private int numberOfObjects;
        private int t;

        public string Type { get => type; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public int NumberOfObjects { get => numberOfObjects; set => numberOfObjects = value; }

        public Agency()
        {
            string[] strok = File.ReadAllLines("agency.txt");
            if (strok.Length == 0)
            {
                Console.WriteLine("Файл пуст. Необходимо заполнить данные об агентстве");
                input();
                WriteToFile.Write(this);

            }
            else
            {
                //переменная для выбора варианта реализации
                bool cacheBool = false;
                string cache;
                //цикл для получения корректного ответа от пользователя
                do
                {
                    Console.WriteLine("В файле уже содержится информация о агенстве. Желаете заменить данные? Да или нет");
                    cache = Console.ReadLine();
                    if (cache.Equals("да"))
                    {
                        cacheBool = true;
                    }
                    else if (cache.Equals("нет"))
                    {
                        cacheBool = false;
                    }
                } while (!(cache.Equals("да") || cache.Equals("нет")));
                //выбор инициализации
                if (cacheBool)
                {
                    input();
                    WriteToFile.Write(this);
                }
                else
                {
                    ReadFromFile.Read(this);
                }
            }
        }

        public Agency(string[] data)
        {
            name = data[0];
            phone = data[1];
            address = data[2];
        }

        public string[] getData()
        {
            return new string[] { name, phone, address };
        }

        void input()
        {
            MyObject.inputValue(ref name, "Введите название Агентства:");
            do {
                Console.WriteLine("Введите номер телефона:");
                phone = Console.ReadLine();
            } while (phone.Length!=11);
            MyObject.inputValue(ref address, "Введите адрес:");
            do
            {
                Console.WriteLine("Введите количество объектов:");
                numberOfObjects = int.Parse(Console.ReadLine());
            } while (numberOfObjects==0||numberOfObjects<MyObject.checkCountObject());
        }
        
    }
}
