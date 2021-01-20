using System.Drawing;
using System.Windows.Forms;
using System;

using AsteroidGame.VisualObject;
using System.Collections.Generic;
using AsteroidGame.ConsoleLoggers;




namespace AsteroidGame.VisualObject
{
   static class Game 
    {

        private static readonly Image _Image = Properties.Resources.fon;

        private static BufferedGraphicsContext __Contex;
        private static BufferedGraphics __Buffer;

        private static VisualObject[] __GameObjects; // создания масива обьектов

        private static Timer __Timer;
        private static Bullet __Bullet;
        private static SpaceShip __SpaceShip;

        //private static ColnsoleLogger<Asteroid> __ColnsoleLogger_Asteroid;
        //private static ColnsoleLogger<Bullet> __ColnsoleLogger_Bullet;
        //private static ColnsoleLogger<SpaceShip> __ColnsoleLogger_SpaseShip;
        private static ColnsoleLogger __ConsoleLogger;

       private static ColnsoleLogger.Action Show;

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

            __Timer = new Timer { Interval = 100 };
            __Timer.Tick += OnTimerTick;
            __Timer.Start();

            GameForm.KeyDown += OnGameFormKeyDown;
           
        }

        private static void OnGameFormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    __Bullet = new Bullet(__SpaceShip.Rect.Y);
                    Show?.Invoke();
                    break;

                case Keys.Up:
                    __SpaceShip.MoveUp();
                    break;

                case Keys.Down:
                    __SpaceShip.MoveDown();
                    break;
            }
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

            var rnd = new Random();
            const int asteroid_count = 10;
            const int asteroid_size = 25;
            const int asteroid_max_speed = 20;
            
            __ConsoleLogger = new ColnsoleLogger();
           Show += __ConsoleLogger.LogCreateAsteroid;
            for (int i = 0; i < asteroid_count; i++)
            {
                game_objects.Add(new Asteroid(new Point(rnd.Next(0,Width),rnd.Next(0,Height)), new Point(-rnd.Next(0,asteroid_max_speed),
                    0), asteroid_size));
                Show?.Invoke();
       
            }
            Show -= __ConsoleLogger.LogCreateAsteroid;
            for (int i = 0; i < 15; i++)
            {
                game_objects.Add(new Star(new Point(800, (int)(i / 2.0*10)), new Point( - i, 10),15));

            }
            Show += __ConsoleLogger.LogCreateBullet;
            for (int i = 0; i < 2; i++)
            {
                game_objects.Add(new Planet(new Point(800, (int)(i / 2.0 * 10)), new Point(-i, 0), 100));

            }
            //for (int i = 0; i < 3; i++)
            //{
            //    game_objects.Add(new Bullet(500));
            //}
                __GameObjects = game_objects.ToArray();// из списк аделаем масив
            
        
            __SpaceShip = new SpaceShip(new Point(10, 400),
                new Point(5,5),
                new Size(20,20));
            __SpaceShip.Destroyd += OnShipDestroyed;
            

            #endregion
        }

        private static void OnShipDestroyed(object sender,EventArgs e)
        {
            __Timer.Stop();
            var g = __Buffer.Graphics;
            g.Clear(Color.DarkBlue);
            g.DrawString("Game over!!!", new Font(FontFamily.GenericSerif, 60, FontStyle.Bold),Brushes.Red,200,100);
            __Buffer.Render();
        }

        #region *** public static void Draw() будет рисовать что либо
        public static void Draw()
        {
            Graphics graphics = __Buffer.Graphics; // используем буфер и извлекаем обьекат графики


           // graphics.Clear(Color.Black);
            graphics.DrawImage(_Image, 0, 0, 800, 700);
            

            
            

            //graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));// рисуем триугольник
            //graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));

            foreach (var game_object in __GameObjects)
                game_object.Draw(graphics);

            __SpaceShip.Draw(graphics);
            __Bullet?.Draw(graphics);

            if (!__Timer.Enabled) return;
            __Buffer.Render();//выводим буфер
        }
        #endregion
        private static void Update()
        {
           
            foreach (var __GameObjects in __GameObjects)
                    __GameObjects?.Update();

            __Bullet?.Update();

            for(var i = 0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];

                if(obj is ICollision collision_object)
                {
                    __SpaceShip.CheckCollision(collision_object);

                    if (__Bullet?.CheckCollision(collision_object) != true) continue;

                    __Bullet = null;
                    __GameObjects[i] = null;
                    System.Media.SystemSounds.Beep.Play();
                }
            }
        }
    }
}
