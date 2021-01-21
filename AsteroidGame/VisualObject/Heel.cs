using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObject
{
    class Heel : ImageObject, ICollision
    {
        public Heel(Point Position, Point Direction, Size size, Image image) 
            : base(Position, Direction, size, image)
        {

        }

        public Rectangle Rect => throw new NotImplementedException();

        public bool CheckCollision(ICollision obj)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            _Position.X += _Direction.X;

            if (_Position.X < 0) _Position.X = Game.Width + _Size.Width;
        }
    }
}
