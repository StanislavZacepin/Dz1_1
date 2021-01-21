using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz2_1
{
   public class CalculationTest
    {
        public Double calculation(double WorkerSalary)
        {
            WorkerSalary = 20.8 * 8 * WorkerSalary;

            return WorkerSalary;
            //«среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»
        }
    }
}
