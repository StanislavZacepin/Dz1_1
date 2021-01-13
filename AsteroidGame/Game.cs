using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
   static class Game 
    {
        private static BufferedGraphicsContext __Contex;
        private static BufferedGraphics __Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static void Initialize(Form GameForm)
        {
            Width = GameForm.Width;
            Height = GameForm.Height;

            __Contex = BufferedGraphicsManager.Current; //создания контекста
            Graphics graphics = GameForm.CreateGraphics(); // обьект отвечающий за рисования
            __Buffer = __Contex.Allocate(graphics, new Rectangle(0, 0, Width, Height));
            // формирования буфура указывая размеры где будет обресовка
        }
    public static void Draw()// будет рисовать что либо
        {
            Graphics graphics = __Buffer.Graphics; // используем буфер и извлекаем обьекат графики

            graphics.Clear(Color.Black);

            graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));// рисуем триугольник

            graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));

            __Buffer.Render();//выводим буфер
        }
    }
}
