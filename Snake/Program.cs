using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSnake
{
    internal class Program
    {
   /*     static void Main(string[] args)
        {
            try
            {
                ApplyCommandLineArguments(args);
                Game game = new Game();
            }
            catch
            {
                MainMenu mainMenu = new MainMenu().OpenMainMenu();
            }
        }

        static void ApplyCommandLineArguments(string[] args)
        {
            ApplySizeField(args[1].Split('x'));
            ApplyLength(args[0]);
            ApplySpeedMode(args[2]);
            ApplyCollisionWalls(args[3]);
            ApplyCollisionTail(args[4]);
        }

        static void ApplySizeField(string[] div)
        {
            Settings.x = int.Parse(div[0]);
            Settings.y = int.Parse(div[1]);
        }

        static void ApplyLength(string length)
        {
            Settings.length = int.Parse(length);
        }

        static void ApplySpeedMode(string speedMode)
        {
            Settings.speedMode = bool.Parse(speedMode);
        }

        static void ApplyCollisionWalls(string collisionWalls)
        {
            Settings.collisionWalls = bool.Parse(collisionWalls);
        }

        static void ApplyCollisionTail(string collisionTail)
        {
            Settings.collisionTail = bool.Parse(collisionTail);
        }


        public static void StartGame(Game game)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            Printer.PrintGameField();

            while (true)
            {
                if (Console.KeyAvailable)
                {


                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.P: Printer.Pause(); break;
                        case ConsoleKey.Escape:
                            MainMenu mainMenu = new MainMenu();
                            mainMenu.OpenMainMenu();
                            break;
                    }
                }

                game.NextDirection = getDirection(key);
                game.Process();

                if (game.isGameOver)
                    break;
            }
            FinishGame();
        }

        public static void FinishGame()
        {
            Printer.PrintFinishGame();

            MainMenu mainMenu = new MainMenu();
            mainMenu.OpenMainMenu();
        }

        static Direction direction = new Direction();
        static Direction getDirection(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    direction = Direction.Bottom;
                    break;
                case ConsoleKey.UpArrow:

                    direction = Direction.Top;
                    break;
                case ConsoleKey.LeftArrow:
                    direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    direction = Direction.Right;
                    break;
            }

            return direction;
        } */
    } 
}
