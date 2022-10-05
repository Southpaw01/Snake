using GameLogic;

namespace SnakeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Settings.ConvertParametersOfSettingsFromString(args);
                Game game = new Game();
            }
            catch
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.OpenMainMenu();
            }
        }


        public static void StartGame(Game _game)
        {
            Game game = _game;
            direction = Direction.Right;

            ConsoleKeyInfo key = new ConsoleKeyInfo();

            PrinGame(game);

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
                PrinGame(game);

                if (game.isGameOver)
                    break;
            }
            FinishGame();
        }

        static void PrinGame(Game game)
        {
            Console.Clear();
            Printer.PrintGameField();
            Printer.PrintWall(game.field.leftWall);
            Printer.PrintWall(game.field.rightWall);
            Printer.PrintWall(game.field.topWall);
            Printer.PrintWall(game.field.bottomWall);
            Printer.PrintSnake(game.field.snake.Body);
            Printer.Graphic(game.field.food, '$');
            Printer.PrintCount(game.counter);
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
        }
    }
}