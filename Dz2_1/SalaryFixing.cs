using System;
using System.Collections.Generic;
using System.Text;

namespace Dz2_1
{
   internal  class SalaryFixing : WorkerNameAndSalary
    {

        
        public SalaryFixing(string Name, double WorkerSalary) : base(Name, WorkerSalary)
        {

            this.Name = "Иван";
           this.WorkerSalary = WorkerSalary;
        }
  
        public void Print()
        {
            Console.WriteLine(Name+" "+WorkerSalary);

        }
    
    }
}
