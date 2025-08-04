using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSnake
{
   /* internal class MainMenu
    {
        ConsoleKeyInfo k = new ConsoleKeyInfo();

        public void OpenMainMenu()
        {
            Settings.ReadSettingsFromTextFile();

            Printer.PrintMainMenu();

            ApplyUserChoose();
        }

        void ApplyUserChoose()
        {
            GetCorrectUserChoose();

            if (k.Key == ConsoleKey.S)
            {
                Settings.ApplyUserSettings();
            }
            Game game = new Game();
            Program.StartGame(game);
        }

        void GetCorrectUserChoose()
        {
            do
            {
                k = Console.ReadKey(true);
            }

            while ((k.Key != ConsoleKey.Spacebar) && (k.Key != ConsoleKey.S));
        }
    } */
}
