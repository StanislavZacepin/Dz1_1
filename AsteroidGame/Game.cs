using System.Drawing;
using System.Windows.Forms;
using System;
using System.IO;
using AsteroidGame.VisualObject;
using System.Collections.Generic;

namespace AsteroidGame.VisualObject
{
   static class Game 
    {
        private static readonly Image _Image = Properties.Resources.fon;

        private static BufferedGraphicsContext __Contex;
        private static BufferedGraphics __Buffer;

        private static VisualObject[] __GameObjects; // создания масива обьектов
        public static int Width { get; set; }
        public static int Height { get; set; }
        #region*** public static void Initialize(Form GameForm) Создания контекста и формирования буфера
        public static void Initialize(Form GameForm)
        {
            if (!(GameForm.Width >= 1000 || GameForm.Height >= 1000))
            {
                Width = GameForm.Width;
                Height = GameForm.Height;
            }
            else throw new ArgumentOutOfRangeException();

            __Contex = BufferedGraphicsManager.Current; //создания контекста
            Graphics graphics = GameForm.CreateGraphics(); // обьект отвечающий за рисования
            __Buffer = __Contex.Allocate(graphics, new Rectangle(0, 0, Width, Height));
            // формирования буфура указывая размеры где будет обресовка

            Timer timer = new Timer { Interval = 100 };
            timer.Tick += OnTimerTick;
            timer.Start();
           
        }
        #endregion
        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }
        #region*** public static void Load() масив обьектов
        public static void Load()
       
        {
            var game_objects = new List<VisualObject>();
            for (int i = 0; i < 15; i++)
            {
                game_objects.Add(new Asteroid(new Point(600, i * 20), new Point(15 - i, 20 - i), 20));
       
            }

            for (int i = 0; i < 15; i++)
            {
                game_objects.Add(new Star(new Point(800, (int)(i / 2.0*10)), new Point( - i, 10),15));

            }
            for (int i = 0; i < 2; i++)
            {
                game_objects.Add(new Planet(new Point(800, (int)(i / 2.0 * 10)), new Point(-i, 0), 100));

            }

            __GameObjects = game_objects.ToArray();// из списк аделаем масив
            #endregion

        }

        #region *** public static void Draw() будет рисовать что либо
        public static void Draw()
        {
            Graphics graphics = __Buffer.Graphics; // используем буфер и извлекаем обьекат графики


            graphics.Clear(Color.Black);
            graphics.DrawImage(_Image, 0, 0, 800, 700);
            

            
            

            //graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));// рисуем триугольник
            //graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));

            foreach (var game_object in __GameObjects)
                game_object.Draw(graphics);

            __Buffer.Render();//выводим буфер
        }
        #endregion
        private static void Update()
        {
            foreach (var game_object in __GameObjects)
                game_object.BazeObject();
        }
    }
}
