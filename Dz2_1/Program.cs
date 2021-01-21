using System;
using System.Collections.Generic;

namespace Dz2_1
{
    //   1. Построить три класса(базовый и 2 потомка), описывающих некоторых работников с почасовой оплатой(один из потомков) и фиксированной оплатой(второй потомок).
    //а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы.Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка», для работников с фиксированной оплатой «среднемесячная заработная плата = фиксированная месячная оплата».
    //б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
    class Program
    {
        static void Main(string[] args)
        {
            CalculationTest calcul = new CalculationTest();
            var rnd = new Random();
            List<SalaryFixing> Fix = new List<SalaryFixing>();
            for (var i=0;i<10; i++)
            {
                Fix.Add(new SalaryFixing("Иван", rnd.Next(25000, 45000)));
            }
          
            List<AtAnHourlyRate> Ata = new List<AtAnHourlyRate>();
            for (var i = 0; i < 10; i++)
            {
                double random = Convert.ToDouble(rnd.Next(150, 200));
                Ata.Add(new AtAnHourlyRate("Толя",calcul.calculation(random)));

            }

           

        }
      
    }
    

}

