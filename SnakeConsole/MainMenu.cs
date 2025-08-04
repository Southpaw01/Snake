using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;

namespace SnakeConsole
{
    internal class MainMenu
    {
        ConsoleKeyInfo k = new ConsoleKeyInfo();

        public void OpenMainMenu()
        {
            string[] line = InputOutputSystem.ReadFile.ReadSettingsFromTextFile();

            if (line != null)
                Settings.ApplySettings(line);

            Printer.PrintMainMenu();

            ApplyUserChoose();
        }

        void ApplyUserChoose()
        {
            GetCorrectUserChoose();

            if (k.Key == ConsoleKey.S)
            {
                string[] line = GettingSettings.ApplyUserSettings();
                Settings.ApplySettings(line);
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
    }
}
