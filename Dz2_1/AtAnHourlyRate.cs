using System;
using System.Collections.Generic;
using System.Text;

namespace Dz2_1
{
    internal class AtAnHourlyRate : WorkerNameAndSalary
    {
        public AtAnHourlyRate(string Name, double WorkerSalary) 
            : base(Name, WorkerSalary)
        {
             this.Name = Name;
             this.WorkerSalary = WorkerSalary;
        }
    
        
        public void Print()
        {
            Console.WriteLine(Name + " " + WorkerSalary);

        }

    }
}
