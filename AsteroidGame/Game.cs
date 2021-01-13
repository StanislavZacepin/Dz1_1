﻿using System.Drawing;
using System.Windows.Forms;
using System;

namespace AsteroidGame
{
   static class Game 
    {
        private static BufferedGraphicsContext __Contex;
        private static BufferedGraphics __Buffer;

        private static VisualObject[] __GameObjects; // создания масива обьектов
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

            Timer timer = new Timer { Interval = 100 };
            timer.Tick += OnTimerTick;
            timer.Start();
           
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }
        public static void Load()
        {
            const int visual_object_count = 30; // для масива . количество обьектов
            __GameObjects = new VisualObject[visual_object_count];

            for( int i = 0; i < __GameObjects.Length/2; i++)
            {
                __GameObjects[i] = new VisualObject(
                new Point(600, i * 20),
                new Point(15 - i, 20 - i),
                new Size(20, 20));
                
            }
           
            for (int i = __GameObjects.Length / 2; i < __GameObjects.Length ; i++)
            {
                __GameObjects[i] = new Star(
                new Point(500, (int)(i/1.5 * 20)),
                new Point(- i, 0),
                10);

            }
        }
    public static void Draw()// будет рисовать что либо
        {
            Graphics graphics = __Buffer.Graphics; // используем буфер и извлекаем обьекат графики

            graphics.Clear(Color.Black);

            //graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));// рисуем триугольник
            //graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));

            foreach (var game_object in __GameObjects)
                game_object.Draw(graphics);

            __Buffer.Render();//выводим буфер
        }
    private static void Update()
        {
            foreach (var game_object in __GameObjects)
                game_object.Update();
        }
    }
}