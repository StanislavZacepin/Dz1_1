using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

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
            #region *** ������ ����
            GameWindow.Width = 800;
            GameWindow.Height = 700;
            #endregion
            GameWindow.Show();
            Game.Initialize(GameWindow);
            Game.Load();
            Game.Draw();

            Application.Run(GameWindow);


            
        }
    }
}
