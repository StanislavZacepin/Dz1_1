using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AsteroidGame.VisualObject
{
    internal abstract class VisualObject: IDisposable
    {
        protected Point _Position; // Положения
        protected Point _Direction; // Вектор скорости
        protected Size _Size; //размер
        protected VisualObject(Point Position, Point Direction, Size size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = size;
        }

        public abstract void Draw(Graphics graphics);

        public abstract void Update(); // Надеюсь я правельнопонял задание 2

        public abstract void Dispose();
        
    }
}
