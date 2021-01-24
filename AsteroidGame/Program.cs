using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using AsteroidGame.VisualObject;

namespace AsteroidGame
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
       
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            Form GameWindow = new Form();
            #region *** Размер окна
            GameWindow.Width = 800;
            GameWindow.Height = 700;
            #endregion
            GameWindow.Show();
            Game.Initialize(GameWindow);
            Game.Load(10);
            Game.Draw();

            Application.Run(GameWindow);


            
        }
    }
}
