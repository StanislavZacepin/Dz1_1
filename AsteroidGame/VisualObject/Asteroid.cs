using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AsteroidGame.VisualObject
{
    internal class Asteroid : ImageObject, ICollision
    {
        private static readonly Image _Image = Image.FromFile("image/ast.png");

        public int Power { get; set; }

        public Rectangle Rect => new Rectangle(_Position, _Size); // астеройд возвращает облост которую он занимает

        public Asteroid(Point Position, Point Direction, int size) 
            : base(Position, Direction, new Size(size,size),_Image)
        {

        }

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect); // выполнения проверки н астолкновения
       
    }
}
