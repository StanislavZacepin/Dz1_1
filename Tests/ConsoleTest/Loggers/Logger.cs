using System;

namespace ConsoleTest.Loggers
{
   internal abstract class Logger
    {

        public abstract void Log(string txt);
             
        public void LogInformation(string txt) 
        {
            Log($"{DateTime.Now:s}[info]:{txt}");
        }
        public void LogWarning(string txt)
        {
            Log($"{DateTime.Now:s}[warn]:{txt}");
        }
        public void LogError(string txt)
        {
            Log($"{DateTime.Now:s}[error]:{txt}");
        }
        public void LogCritical(string txt)
        {
            Log($"{DateTime.Now:s}[critical]:{txt}");
        }
        public abstract void Flush(); // Сброс с буфера на диск
    }
}
