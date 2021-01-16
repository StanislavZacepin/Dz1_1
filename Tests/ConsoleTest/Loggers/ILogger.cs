using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Loggers
{
   internal interface ILogger
    {
        public abstract void Log(string txt);

        public void LogInformation(string txt);

        public void LogWarning(string txt);

        public void LogError(string txt);

        public void LogCritical(string txt);
        
        public abstract void Flush(); // Сброс с буфера на

    }
}
