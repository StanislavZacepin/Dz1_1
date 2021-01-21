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
        private static readonly Image _image = Properties.Resources.heal;
        public Heel(Point Position, Point Direction, Size size, Image image) 
            : base(Position, Direction, size, image)
        {

        }

        public Rectangle Rect   => new Rectangle(_Position, _Size);

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);


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
