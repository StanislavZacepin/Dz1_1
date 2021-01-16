using System;
using ConsoleTest.Loggers;

namespace ConsoleTest
{
    class Program
    {
        private static int _X = 5;
        private static int _Y = 0;
        private static Logger _Logger;
        static void Main(string[] args)
        {

            //_Logger = new TextFileLogger("test.log"); За место него создаем консольного логера
            //_Logger = new ConsoleLogger(); Заместо него создаем и на конслоль и в фаил
            _Logger = new CombineLogger(new ConsoleLogger(), new TextFileLogger("test.log"));
            _Logger.LogInformation("Приложение запущено");

            try
            {
                var z = _X / _Y;
            }
            catch (DivideByZeroException )
            {

                _Logger.LogError($"Ошибка при делении {_X} на 0");
            }

            Console.WriteLine("Нажмите Enter для выхода");
            Console.ReadKey();

            _Logger.LogInformation("Работа приложения завершена");
            /*не нужно если перевели на ватоматическую функцыю сброаса на диск */_Logger.Flush(); // Сброс с буфера на диск
        }
    }
}
