using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AsteroidGame
{
    class VisualObject
    {
        protected Point _Position; // Положения
        protected Point _Direction; // Вектор скорости
        protected Size _Size; //размер
        public VisualObject(Point Position,Point Direction,Size size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = size;
        }
   
    public void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pens.White, _Position.X, _Position.Y, _Size.Width,_Size.Height);
        }
    public void Update()
        {
            _Position.X += _Direction.X;
            _Position.Y += _Direction.Y;
            
            if (_Position.X < 0) _Direction.X *= -1;
                                                        // выход за зону
            if (_Position.Y < 0) _Direction.Y *= -1;


            if (_Position.X > Game.Width) _Direction.X *= -1;
            // выход за другую зону
            if (_Position.Y >Game.Height) _Direction.Y *= -1;
        }
    }
}
