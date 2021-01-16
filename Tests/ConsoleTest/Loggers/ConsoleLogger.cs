using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Loggers
{
    internal class ConsoleLogger : Logger
    {
        public override void Flush()
        {
            Console.WriteLine("Все данные логгера сохранены");
        }

        public override void Log(string txt)
        {
            Console.WriteLine(txt);
        }
    }
}
