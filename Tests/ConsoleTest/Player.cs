using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    class Player
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; } = DateTime.Now; // Присвоить дату этого дня

        public Player()
        {

        }
        public Player(string Name)
        {
            this.Name = Name;
        }
        public Player(string Name, string Surname)
            : this(Name) // вызов другой конструктор
        {
            this.Surname = Surname;
        }
    }
}
