using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AsteroidGame.VisualObject
{
    class Star : ImageObject
    {
        private static readonly Image _image = Properties.Resources.star;
        public  Star(Point Position, Point Direction, int Size)
            : base(Position, Direction, new Size(Size, Size),_image)
            {

            }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(_image, _Position.X, _Position.Y,
                _Size.Width, _Size.Height);
            
            
        }
        public override void Update()
        {
            _Position.X += _Direction.X;

            if (_Position.X < 0) _Position.X = Game.Width + _Size.Width;

            

        }
    }
}
