using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoZap
{
    class Oil
    {
        
        public string _TypeOil { get; set; }
        public int _maxSizeOil { get; set; }
        public int _Co { get; set; }
        
        public Oil(string typeOil, int maxSizeOil, int co)
        {
            _TypeOil = typeOil;
           _maxSizeOil = maxSizeOil;
            _Co = co;
        }
        public void Mission(Automobile aDA, Worker wr, Oil oil)
        {
            if (oil._maxSizeOil == 0)
            {
                Console.WriteLine($"{oil._TypeOil} увы, закончился ");
            }
            else if ((oil._maxSizeOil - (aDA._MaxSize - aDA._NowOil)) <= 0)
            {
                Console.WriteLine($"Оставшиийся(еся) {oil._maxSizeOil} литр(ы) {oil._TypeOil} на {oil._Co * oil._maxSizeOil} рубль(ей) заправщик {wr._Name} залил в {aDA._Name} и закрыл колонку");
                oil._maxSizeOil = 0;

            }
            else if ((oil._maxSizeOil - (aDA._MaxSize - aDA._NowOil)) > 0)
            {
                oil._maxSizeOil = oil._maxSizeOil - (aDA._MaxSize - aDA._NowOil);
                Console.WriteLine($"Заправщик {wr._Name} залил бензин {oil._TypeOil} в {aDA._Name} {aDA._MaxSize - aDA._NowOil} литра на {oil._Co * (aDA._MaxSize - aDA._NowOil)} рубль(ей), бензина осталось : {oil._maxSizeOil}");
            }
        }
            
        public void PrintOil()
        {
            Console.WriteLine("Тип топлива: " + _TypeOil + " Количество: " + _maxSizeOil + " Цена: " + _Co);
        }
    }

    class Worker 
    {
        public string _Name { get; set; }
        public string _Type { get; set; }
        public Worker(string name, string type)
        {
            _Name = name;
            _Type = type;
        }
        public void PrintWorker()
        {
            Console.WriteLine("Имя работника: " + _Name + " С каким топливом работает: " + _Type);
        }
    }
    class Automobile
    {
        public string _Name { get; set; }
        public string _TypeOfOil { get; set; }
        public int _MaxSize { get; set; }
        public int _NowOil { get; set; }
        public Automobile(string name, string typeOfOil, int maxSize, int nowOil)
        {
            _Name = name;
            _TypeOfOil = typeOfOil;
            _MaxSize = maxSize;
            _NowOil = nowOil;
        }
    }

    class Eazy : Automobile
    {
        public Eazy(string name, string typeOfOil, int maxSize, int nowOil) : base(name, typeOfOil, maxSize, nowOil)
        {

        }
    }
    class Heavy : Automobile
    {
        public Heavy(string name, string typeOfOil, int maxSize, int nowOil) : base(name, typeOfOil, maxSize, nowOil)
        {

        }
    }

    class LADA : Eazy
    {  
        public LADA(string name,string typeOfOil,int maxSize, int nowOil) : base(name, typeOfOil,maxSize, nowOil)
        {
            
        }
    }

    class KAMAZ : Heavy
    {
        public KAMAZ(string name, string typeOfOil, int maxSize, int nowOil) : base(name, typeOfOil, maxSize, nowOil)
        {

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Worker wr1 = new Worker("Robin", "A-92");
            Worker wr2 = new Worker("Bobin", "A-95");
            Worker[] wrMas = new Worker[2];
            wrMas[0] = wr1;
            wrMas[1] = wr2;
            Oil oil1 = new Oil("A-92", 300,33);
            Oil oil2 = new Oil("A-95", 200,55);
            Oil[] masOil = new Oil[2];
            masOil[0] = oil1;
            masOil[1] = oil2;
            for (int y = 0; y < wrMas.Length; y++)
            {
                wrMas[y].PrintWorker();
            }
            for (int i = 0; i < masOil.Length; i++)
            {
                masOil[i].PrintOil();
            }

            LADA lada = new LADA("LADA PRIORA", "A-92", 40,22);
            KAMAZ kam = new KAMAZ("KAMAZ 31001", "A-95", 50, 1);
            Automobile[] masA = new Automobile[2];
            masA[0] = lada;
            masA[1] = kam;

            for (int i = 0; i < masA.Length; i++)
            {
                for (int j = 0; j < masOil.Length; j++)
                {
                    for (int y = 0; y < wrMas.Length; y++)
                    {
                        if (masA[i]._TypeOfOil == masOil[j]._TypeOil && masA[i]._TypeOfOil == wrMas[y]._Type)
                        {
                            
                            masOil[i].Mission(masA[i], wrMas[y], masOil[j]);

                        }
                    }
                }
            }

            Console.ReadKey();
           
        }
    }
}
