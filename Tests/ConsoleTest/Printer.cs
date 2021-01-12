using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    class Printer
    {
        public virtual /*virtual Дает возможность наследникам переопределить этот метод*/ void Print(string txt) => Console.WriteLine(txt);

        public override string ToString() => "Принтер"; //переопределения метода тостринг
    }

    class PrefixPrinter : Printer // наследник
    {
        public string Prefix { get; set; }

        public PrefixPrinter(string Prefix)
        {
            this.Prefix = Prefix;
        }

        public override /*override  можем изменить логику метода принт*/ void Print(string txt) => Console.WriteLine($"{Prefix}{txt}");
        // public override string ToString() => "Принтер с префиксом"; //переопределения метода тостринг

        public override string ToString() // вызов стандартный тостринг
        {
            return base.ToString() + " с Префиксом";
        }
    }
}
