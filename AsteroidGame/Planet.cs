using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AsteroidGame
{
    class Planet : VisualObject
    {
        public Planet(Point postion, Point Direction, Size size):base(postion,Direction,size)
        {
            
        }
        public override void Draw(Graphics graphics)
        {
            SolidBrush silverBrush = new SolidBrush(Color.Silver);
            graphics.FillEllipse(silverBrush, _Position.X, _Position.Y, _Size.Width, _Size.Height) ;
        }

        public override void Update()
        {
            _Position.X += _Direction.X;

            if (_Position.X < 0) _Position.X = Game.Width + _Size.Width;



        }
    }
}
