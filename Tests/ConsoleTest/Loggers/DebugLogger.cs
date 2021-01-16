using System.Diagnostics;

namespace ConsoleTest.Loggers
{
    internal class DebugLogger : Logger
    {
        public override void Flush()
        {
            Debug.Flush();
        }

        public override void Log(string txt)
        {
            Debug.WriteLine(txt);
        }
    }
}
