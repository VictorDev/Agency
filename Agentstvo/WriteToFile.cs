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

        static public void Write(Agency agency)
        {
            StreamWriter sw = new StreamWriter("agency.txt");
            sw.WriteLine($"Название агентства:{agency.Name}");
            sw.WriteLine($"Телефон:{agency.Phone}");
            sw.WriteLine($"Адрес:{agency.Address}");
            sw.WriteLine($"Количество объектов:{agency.NumberOfObjects}");
            sw.Close();
        }

        static public void Write(MyObject myObject)
        {
            StreamWriter sw = new StreamWriter("myobject.txt", true);
            sw.WriteLine($"Имя объекта:{myObject.Name} ");
            sw.WriteLine($"Цена объекта:{myObject.Price} ");
            sw.WriteLine($"Площадь объекта: {myObject.Square}");
            sw.WriteLine($"Район расположения:{myObject.Description}");
            sw.WriteLine($"Улица:{myObject.Street}");
            sw.WriteLine($"Номер дома:{myObject.NHouse}");
            ObjectType objectType = myObject.ObjectType;
            string type = objectType.Type;
            sw.WriteLine($"Вид недвижимости:{type}");
            //оставляю ненужные поля пустые, чтобы общее количество строк всегда было одинаковым
            if (type.Equals("Дом"))
            {
                //функция сделана для того чтобы получить все данные, даже те которые не определены в интерфейсе
                string[] data = objectType.getData();
                sw.WriteLine($"Номер квартиры:0");
                sw.WriteLine($"Количество комнат:{data[0]}");
            }
            else if (type.Equals("Квартира"))
            {
                string[] data = objectType.getData();
                sw.WriteLine($"Номер квартиры:{data[0]}");
                sw.WriteLine($"Количество комнат:{data[1]}");
            }else if (type.Equals("Гостинка"))
            {
                string[] data = objectType.getData();
                sw.WriteLine($"Номер квартиры:{data[0]}");
                sw.WriteLine($"Количество комнат:0");
            }
            else
            {
                sw.WriteLine($"Номер квартиры:0");
                sw.WriteLine($"Количество комнат:0");
            }
            sw.WriteLine($"Торг (есть/нет):{myObject.Bargaining}");
            sw.WriteLine($"Описание:{myObject.Description}");
            sw.WriteLine($"Примечания:{myObject.Note}");
            
            sw.WriteLine($"Статус:{myObject.Status}");
            Property_Owner owner = myObject.Owner;
            string propery = owner.Type;
            sw.WriteLine($"Владелец:{propery}");
            //оставляю ненужные поля пустые, чтобы общее количество строк всегда было одинаковым
            if (propery.Equals("Физ. лицо"))
            {
                string[] data = owner.getData();
                sw.WriteLine($"ФИО:{data[0]}");
                sw.WriteLine($"Телефон:{data[1]}");
                sw.WriteLine($"Адрес:-");
            }
            else if (propery.Equals("Агенство"))
            {
                string[] data = owner.getData();
                sw.WriteLine($"Название:{data[0]}");
                sw.WriteLine($"Телефон:{data[1]}");
                sw.WriteLine($"Адрес:{data[2]}");
            }
            sw.WriteLine("-:---");
            sw.Close();
        }

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
