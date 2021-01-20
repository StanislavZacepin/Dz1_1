using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AsteroidGame.ConsoleLoggers
{
   
     internal class ColnsoleLogger//<Titem>
    {
        public  delegate void Action ();

        private int count = 0;
        public  void LogCreateAsteroid()
        {
            count++;
          
           Debug.Print(DateTime.Now + $" Создания обьекта Asteroid Всего обьектов {count}");
        }
        public void LogCreateBullet()
        {
            count++;

            Debug.Print(DateTime.Now + $" Создания обьекта Buulet Всего обьектов {count}");
        }

    }
}
