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

        public bool Enabled { get; set; } = true;
        protected VisualObject(Point Position, Point Direction, Size size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = size;
        }

        public abstract void Draw(Graphics graphics);

        public virtual void Update()
        {
            if (!Enabled) return;

            _Position.X += _Direction.X;
            _Position.Y += _Direction.Y;

            if (_Position.X < 0) _Direction.X *= -1;
            // выход за зону
            if (_Position.Y < 0) _Direction.Y *= -1;


            if (_Position.X > Game.Width - 45) _Direction.X *= -1;
            // выход за другую зону
            if (_Position.Y > Game.Height - 65) _Direction.Y *= -1;
        } 

        public abstract void Dispose();
        
    }
}
