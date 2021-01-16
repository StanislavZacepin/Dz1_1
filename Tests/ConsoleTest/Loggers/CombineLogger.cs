using System;

namespace ConsoleTest.Loggers
{
    internal class CombineLogger : Logger
    {
        private readonly Logger _Logger1;
        private readonly Logger _Logger2;
        public CombineLogger(Logger logger1,Logger logger2)
        {
            _Logger1 = logger1;
            _Logger2 = logger2;
        }
        public override void Flush()
        {
            _Logger1.Flush();
            _Logger2.Flush();
        }

        public override void Log(string txt)
        {
            _Logger1.Log(txt);
            _Logger2.Log(txt);
        }
    }
}
