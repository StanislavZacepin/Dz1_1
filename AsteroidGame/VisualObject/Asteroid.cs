using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AsteroidGame.VisualObject
{
    internal class Asteroid : ImageObject, ICollision
    {
        private static readonly Image _Image = Image.FromFile("image/ast.png");


        public int Power { get; set; } = 3;

        public Rectangle Rect => new Rectangle(_Position, _Size); // астеройд возвращает облост которую он занимает

        public Asteroid(Point Position, Point Direction, int size) 
            : base(Position, Direction, new Size(size,size),_Image)
        {

        }

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect); // выполнения проверки на столкновения

        
        public override void Update()
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

        public override void Dispose()
        {
            _Image.Dispose();
        }
    }
}
