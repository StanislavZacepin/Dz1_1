using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using AsteroidGame.VisualObject;

namespace AsteroidGame.VisualObject
{
    class Planet : ImageObject
    {
        private static readonly Image _Image = Properties.Resources.zemla2;
        public Planet(Point postion, Point Direction, Size size):base(postion,Direction,size,_Image)
        {
            
        }
        public override void Draw(Graphics graphics)
        {
            
            graphics.DrawImage(_Image, _Position.X, _Position.Y, _Size.Width, _Size.Height) ;
        }

        public override void Update()
        {
            _Position.X += _Direction.X;

            if (_Position.X < 0) _Position.X = Game.Width + _Size.Width;



        }
    }
}
