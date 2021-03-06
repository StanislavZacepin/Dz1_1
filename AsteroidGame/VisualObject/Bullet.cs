﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObject
{
    internal class Bullet : CollisionObject
    {
        private const int __BulletSizeX = 20;
        private const int __BulletSizeY = 5;
        private const int __BulletSpeed = 15;

       

        public Bullet(int Position) 
            : base( new Point(0,Position), Point.Empty,new Size(__BulletSizeX,__BulletSizeY))
        {

        }
        //2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
        public override void Update() => _Position.X += __BulletSpeed; // положения позицая Х будет увеличеватьсч на велечину скорости пули

        public override void Draw(Graphics graphics)
        {
            var rect = Rect;
            graphics.FillEllipse(Brushes.Red, rect);
            graphics.DrawEllipse(Pens.White,rect);
        }

        public void Reset(int Y)
        {
            _Position = new Point(0, Y);
            Enabled = true;
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
