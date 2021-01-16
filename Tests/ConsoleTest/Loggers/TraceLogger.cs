using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ConsoleTest.Loggers
{
    internal class TraceLogger : Logger
    {
        public override void Flush()
        {
            Trace.Flush();
        }

        public override void Log(string txt)
        {
            Trace.WriteLine(txt);
        }
    }
}
