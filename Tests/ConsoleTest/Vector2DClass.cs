using System;

namespace ConsoleTest
{
    public class Vector2DClass
    {
        // static Vector2DClass()
        //{
        //    Unit = new Vector2DClass(1, 1);
        //    Zero = new Vector2DClass(0, 0);   для статический полей 
        //}

        public static readonly Vector2DClass Unit;
        public static readonly Vector2DClass Zero;
        public double _X { get; set; }
        public double _Y { get; set; }
        public Vector2DClass()
        {

        }

        public double Length => Math.Sqrt(_X * _X + _Y * _Y); //Длина вектора
       
        public Vector2DClass(double _X,double _y)
        {
            this._X = _X;
            this._Y = _Y;
        }
    
        public static Vector2DClass operator +(Vector2DClass a, Vector2DClass b) // перегрузка операторов
        {
            return new Vector2DClass(a._X + b._X, a._Y + a._Y);
        }
        public static bool operator ==(Vector2DClass a, Vector2DClass b)
        {
            return a._X == b._X && a._Y == b._Y;
        }
        public static bool operator !=(Vector2DClass a, Vector2DClass b)
        {
            return !(a == b);
        }
        public static implicit /*implicit переопределяем не явный оператор типов*/ operator double/* в double   из*/ (Vector2DClass v) // Оператор поведения
        {
            return v.Length;
        }

        public static explicit /*explicit явное преобразование оператор типов*/ operator int/* в int   из*/ (Vector2DClass v) // Оператор поведения
        {
            return (int)v.Length;
        }
    }
}
