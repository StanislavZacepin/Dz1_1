using System.Drawing;
using System.Windows.Forms;
using System;
using System.Linq;
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

        private static VisualObject[] __GameObjects_Aster; // создания масива обьектов asterod

        private static VisualObject[] __Game_Stars_and_planet;

        private static Timer __Timer;

        private static List<Bullet> __Bullets = new();
        private static SpaceShip __SpaceShip;
        private static bool nexstLvL = false;

       static Random rnd = new Random();

        const int asteroid_size = 25;
        const int asteroid_max_speed = 20;

        private static ColnsoleLogger __ConsoleLogger;

        private static ColnsoleLogger.Action Show;

        public static int Width { get; set; }
        public static int Height { get; set; }

        private static int Count { get; set; }

        public static int asteroid_count { get; set; } = 10;
        public static int count_lvl { get; set; } = 8;





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
                    var disabled_bullet = __Bullets.FirstOrDefault(b => !b.Enabled);
                    if (disabled_bullet != null)
                    {
                        disabled_bullet.Reset(__SpaceShip.Rect.Y);
                    }
                    else
                        __Bullets.Add(new Bullet(__SpaceShip.Rect.Y));
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
            nexstLvL = false;
            var game_Asteroids = new List<VisualObject>(11);
            var game_stars_and_planet = new List<VisualObject>(17);
           

           

           

            __ConsoleLogger = new ColnsoleLogger();
            Show += __ConsoleLogger.LogCreateAsteroid;
            for (int i = 0; i < asteroid_count; i++)
            {
                game_Asteroids.Add(new Asteroid(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(-rnd.Next(0, asteroid_max_speed),
                    0), asteroid_size));
                Show?.Invoke();

            }
            Show -= __ConsoleLogger.LogCreateAsteroid;
            for (int i = 0; i < 15; i++)
            {
                game_stars_and_planet.Add(new Star(new Point(rnd.Next(0, Width), rnd.Next(0, Height)), new Point(-i, 10), 15));

            }
            Show += __ConsoleLogger.LogCreateBullet;
            for (int i = 0; i < 2; i++)
            {
                game_stars_and_planet.Add(new Planet(new Point(800, (int)(i / 2.0 * 10)), new Point(-i, 0), 100));

            }
            game_Asteroids.Add(new Heal(new Point(rnd.Next(0, Width), rnd.Next(0, Height)),  //Создания хила
                new Point(-10, 10),
                new Size(25, 25), Properties.Resources.heal));


            __GameObjects_Aster = game_Asteroids.ToArray();
            __Game_Stars_and_planet = game_stars_and_planet.ToArray();

            // из списк аделаем масив
            __Bullets.Clear();

            //foreach (var bullet in __Bullets)
            //    bullet.Draw(graphics);



            __SpaceShip = new SpaceShip(new Point(10, 400),
                new Point(5, 5),
                new Size(20, 20));
            __SpaceShip.Destroyd += OnShipDestroyed;




            #endregion
        }

        private static void OnShipDestroyed(object sender, EventArgs e)
        {
            __Timer.Stop();
            var g = __Buffer.Graphics;
            g.Clear(Color.DarkBlue);
            g.DrawString("Game over!!!", new Font(FontFamily.GenericSerif, 60, FontStyle.Bold), Brushes.Red, 200, 100);
            __Buffer.Render();
        }

        #region *** public static void Draw() будет рисовать что либо
        public static void Draw()
        {
            Graphics graphics = __Buffer.Graphics; // используем буфер и извлекаем обьекат графики


            // graphics.Clear(Color.Black);
            graphics.DrawImage(_Image, 0, 0, 800, 700);


            var g = __Buffer.Graphics;


            g.DrawString(Count.ToString(), new Font(FontFamily.GenericSerif, 30, FontStyle.Regular), Brushes.Gray, 700, 0);

            g.DrawString("HP" + __SpaceShip._Energy.ToString(), new Font(FontFamily.GenericSerif, 30, FontStyle.Regular), Brushes.Red, 0, 0);

            //graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));// рисуем триугольник
            //graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));

            foreach (var game_object in __GameObjects_Aster)
                game_object.Draw(graphics);

            foreach (var game_object in __Game_Stars_and_planet)
                game_object.Draw(graphics);

            __SpaceShip.Draw(graphics);

            __Bullets.ForEach(bullet => bullet.Draw(graphics));

            if (!__Timer.Enabled) return;
            __Buffer.Render();//выводим буфер
        }
        #endregion
        private static void Update()
        {
            var game_Asteroids_lvl_nexst = new List<VisualObject>();

            if (nexstLvL == true)
            {

                game_Asteroids_lvl_nexst.Add(new Asteroid(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(-rnd.Next(0, asteroid_max_speed),
                    0), asteroid_size));
                Graphics g = __Buffer.Graphics;
                foreach (var game_object in game_Asteroids_lvl_nexst)
                    game_object.Draw(g);
                __Buffer.Render();
                nexstLvL = false;
                
            }
            foreach (var __GameObjects in __GameObjects_Aster)
                __GameObjects?.Update();
            foreach (var __GameObjects in __Game_Stars_and_planet)
                __GameObjects?.Update();
            
            foreach (var __GameObjects in game_Asteroids_lvl_nexst)
                __GameObjects?.Update();

            __Bullets.ForEach(bullet => bullet.Update());

            foreach (var o in __GameObjects_Aster.Where(o => o.Enabled))
            {

                if (o is not ICollision obj) continue;


                if (o is Heal heal)
                {
                    if (__SpaceShip.CheckCollision(heal))
                        __SpaceShip._Energy += 5;
                }
                if (__SpaceShip.CheckCollision(obj))
                {
                  
                    count_lvl--;
                    o.Enabled = false;                    
                    continue;
                }
                //if (__Bullets.Any(b=>b.Enabled && b.CheckCollision(obj)))
                //  {
                //      ((VisualObject)obj).Enabled = false;
                //      continue;
                //  } 
               
                    foreach (var bullet in __Bullets.Where(b => b.Enabled))
                    {
                        if (!bullet.CheckCollision(obj)) continue;


                        bullet.Enabled = false;
                        o.Enabled = false;
                        
                        count_lvl--;
                        Count++;
                        if (count_lvl == 0)
                        {
                        
                            count_lvl = asteroid_count -= 2;
                        asteroid_count++;
                        foreach (var d in __GameObjects_Aster.Where(d => !d.Enabled))
                        {
                            d.Enabled = true;
                            
                        }
                        }
                

                }
            }

            foreach (var bullet in __Bullets.Where(b => b.Enabled && b.Rect.X > Width))
                bullet.Enabled = false;

        }
    }
}
