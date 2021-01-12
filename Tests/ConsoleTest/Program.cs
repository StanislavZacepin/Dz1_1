using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Vector2DClass unit =  Vector2DClass.Unit;
            //Vector2DClass zero = Vector2DClass.Zero;  статические поля

            Vector2DClass v1 = new Vector2DClass();
        }
    }
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

        public Vector2DClass(double _X,double _y)
        {
            this._X = _X;
            this._Y = _Y;
        }
    }
}
