using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region *** Пример провекри на null
            DateTime? time = null;

            if (time != null)
            {
                DateTime t = (DateTime)time;
                Console.WriteLine(time);
            }

            if (time.HasValue)
            {
               // DateTime t = time.GetValueOrDefault();
                DateTime t = time.Value;
                Console.WriteLine(time);
            }
            #endregion
            //Vector2DClass unit =  Vector2DClass.Unit;
            //Vector2DClass zero = Vector2DClass.Zero;  обращения к статическим полям

            Vector2DClass v1 = new Vector2DClass();
        }
    }
}
