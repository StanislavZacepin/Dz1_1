using System;
using System.Collections.Generic;
using System.Text;


namespace ConsoleTest.Loggers
{
    /*IComparable текущий обьект должен себя сравнить сводиться к одному интерфейсу */
    //IEquatable<Student>  шаблоного типа сравнивать сам себя с другим обьектом возварщает истину либо лож  
    //ICloneable  позволяет клонировать обьект
    class Student : ILogger, IComparable  , IEquatable<Student> , ICloneable
    {
        public string Name { get; init; }

        public string Surname { get; init; }

        public double Rating { get; set; }

        void ILogger.Log(string txt)
        {
            Console.WriteLine("{0}: {1}", this, txt);
        }

        void ILogger.LogInformation(string txt) => ((ILogger)this).Log($"{DateTime.Now:s}[info]:{txt}");
        void ILogger.LogWarning(string txt) => ((ILogger)this).Log($"{DateTime.Now:s}[warn]:{txt}");
        void ILogger.LogError(string txt) => ((ILogger)this).Log($"{DateTime.Now:s}[error]:{txt}");
        void ILogger.LogCritical(string txt) => ((ILogger)this).Log($"{DateTime.Now:s}[critical]:{txt}");
        void ILogger.Flush() // Сброс с буфера на диск
        => Console.WriteLine("{0} работу закончил!", this);
        void ILogger.TestMethod() => Console.WriteLine("Я {0}", this);
    
        public override string ToString() => $"{Surname} {Name}";

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (obj is Student)
            {
                var other_student = (Student)obj; //жесткое преведения типа - в случае неудачи получаем InvalidCastException
                                                  //var other_student = obj as Student;// алтарнатива мягкое преведения типа - в случае неудачи получаем null
                if (Rating > other_student.Rating) 
                    return +1;
                else if(Rating < other_student.Rating) 
                        return -1;
                else return 0;
            }
            else throw new ArgumentException("Студента можно сравнивать только с студентом", nameof(obj));
        }

        public bool Equals(Student other)
        {
            return other != null
                && Name == other.Name
                && Surname == other.Surname
                && Math.Abs(Rating - other.Rating) < 0.0001;
        }

        public object Clone()
        {
            //return new Student
            //{
            //    Name = Name,
            //    Surname = Surname,
            //    Rating = Rating
            //};
            var new_student = (Student)MemberwiseClone();
            return new_student;
        }
    }
}
