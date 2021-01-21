using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObject
{
    internal abstract class CollisionObject : VisualObject, ICollision
    {
        public CollisionObject(Point Position, Point Direction, Size size) 
            : base(Position, Direction, size)
        {
        }
        public Rectangle Rect => new Rectangle(_Position, _Size);
        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);
    }
}
