using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AsteroidGame.VisualObject
{
    internal class Asteroid : ImageObject
    {
        private static readonly Image _Image = Image.FromFile("image/ast.png");
        public Asteroid(Point Position, Point Direction, int size) 
            : base(Position, Direction, new Size(size,size),_Image)
        {

        }
    }
}
