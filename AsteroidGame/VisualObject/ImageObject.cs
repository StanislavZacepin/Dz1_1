using System.Drawing;

namespace AsteroidGame.VisualObject
{
    internal abstract class ImageObject : VisualObject
    {
        private  readonly Image _Image;
        protected ImageObject(Point Position, Point Direction, Size size,Image image) 
            : base(Position, Direction, size)
        {
            _Image = image;
        }
        public override void Draw(Graphics graphics)
        {
            if (!Enabled) return;
            graphics.DrawImage(_Image, _Position.X, _Position.Y, _Size.Width, _Size.Height); 
        }
    }
}
