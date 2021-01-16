using System;
using System.Collections.Generic;
using System.Text;


namespace ConsoleTest.Loggers
{
    class Student : ILogger
    {
        public string Name { get; init; }

        public string Surname { get; init; }

        public void Flush()
        {
            throw new NotImplementedException();
        }

        public void Log(string txt)
        {
            throw new NotImplementedException();
        }

        public void LogInformation(string txt) => Log($"{DateTime.Now:s}[info]:{txt}");
        public void LogWarning(string txt) => Log($"{DateTime.Now:s}[warn]:{txt}");
        public void LogError(string txt) => Log($"{DateTime.Now:s}[error]:{txt}");
        public void LogCritical(string txt) => Log($"{DateTime.Now:s}[critical]:{txt}");
        public abstract void Flush(); // Сброс с буфера на диск
    
        public void TestMethod() => Console.WriteLine("Я {0}", this);
    
        public override string ToString() => $"{Surname} {Name}";
       

    }
}
