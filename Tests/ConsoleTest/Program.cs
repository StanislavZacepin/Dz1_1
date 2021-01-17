using System;
using ConsoleTest.Loggers;
using System.Collections.Generic;

namespace ConsoleTest
{
    class Program
    {
        private static int _X = 5;
        private static int _Y = 0;
        private static ILogger _Logger;
        static void Main(string[] args)
        {
            var student = new Student
            {
                Surname = "Иванов",
                Name = "Иван"
            };

            Console.WriteLine(student);
            //_Logger = new TextFileLogger("test.log"); За место него создаем консольного логера
            //_Logger = new ConsoleLogger(); Заместо него создаем и на конслоль и в фаил
            // _Logger = new CombineLogger(new ConsoleLogger(), new TextFileLogger("test.log"));
            _Logger = student;
       
            
            _Logger.LogInformation("Приложение запущено");

            try
            {
                var z = _X / _Y;
            }
            catch (DivideByZeroException )
            {

                _Logger.LogError($"Ошибка при делении {_X} на 0");
            }

            var students = new List<Student>();

            var rnd = new Random();

            for (var i = 1; i < 10; i++)
            {
                students.Add(new Student
                {
                    Surname = $"Фамилия-{i}",
                    Name = $"Имя-{i}",
                    Rating = rnd.Next(1,6)
                });
            }

            students.Sort();

            if (!students.Contains(student))
            {
                Console.WriteLine("Журналист отсуствует в списке!");
            }
            
            //TextFileLogger text_logger = null;

            //try
            //{
            //    text_logger = new TextFileLogger("test2.log");

            //    text_logger.LogInformation("Info");
            //    text_logger.LogWarning("Warn");
            //    text_logger.LogError("Err");
            //    text_logger.LogCritical("Crit");
            //}
            //finally
            //{
            //    if(text_logger != null)
            //    text_logger.Dispose();
            //}
           
            using(var text_logger = new TextFileLogger("test2.log")) 
            {
                text_logger.LogInformation("Info");
                text_logger.LogWarning("Warn");
                text_logger.LogError("Err");
                text_logger.LogCritical("Crit");
            }


            Console.WriteLine("Нажмите Enter для выхода");
            Console.ReadKey();

            _Logger.LogInformation("Работа приложения завершена");
            /*не нужно если перевели на ватоматическую функцыю сброаса на диск */_Logger.Flush(); // Сброс с буфера на диск
        }
    }
}
