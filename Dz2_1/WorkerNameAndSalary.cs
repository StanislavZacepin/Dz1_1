using System;

namespace Dz2_1
{
    internal abstract class WorkerNameAndSalary
    {
      protected string Name { get; init; }
        protected double WorkerSalary { get; set; }

        protected WorkerNameAndSalary(String Name,double WorkerSalary)
        {
            this.Name = Name;
            this.WorkerSalary = WorkerSalary;
        }
       
    }
    

}


