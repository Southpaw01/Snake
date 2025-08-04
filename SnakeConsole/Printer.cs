using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;

namespace SnakeConsole
{
    internal class Printer
    {
        public static void PrintMainMenu()
        {
            Console.Clear();
            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(100, 30);
                Console.SetBufferSize(100, 30);
            }
            Console.CursorVisible = true;

            Console.WriteLine("Добро пожаловать в игру \"Змейка\"");
            Console.WriteLine("Разработчик: Илья Петров, группа БПИ-311");

            Console.WriteLine();
            Console.WriteLine("Нажмите Space (Пробел), чтобы начать игру с настройками по умолчанию:");
            Console.WriteLine();
            Console.WriteLine("Начальная длина змейки: " + Settings.length);
            Console.WriteLine("Поле: " + Settings.x + "x" + Settings.y);
            Console.WriteLine("Скорость: " + Settings.speedMode);
            Console.WriteLine("Столкновение со стенами: " + Settings.collisionWalls);
            Console.WriteLine("Столкновение с хвостом: " + Settings.collisionTail);
            Console.WriteLine();
            Console.WriteLine("Нажмите S, чтобы изменить данные настройки");
        }

        public static void Graphic(Unit u, char symbol)
        {
            Console.SetCursorPosition(u.X, u.Y + 4);
            Console.Write(symbol);
        }

        public static void PrintGameField()
        {
            int x = Settings.x;
            int y = Settings.y;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Esc - Выход");
            Console.WriteLine("P - Пауза");
            Console.WriteLine("Счет: 0");
            Console.WriteLine();

            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(x + 2, y + 6);
                Console.SetBufferSize(x + 2, y + 6);
            }
            Console.CursorVisible = false;
        }

        public static void PrintWall(List<Unit> wall)
        {
            foreach (var u in wall)
            {
                Graphic(u, '#');
            }
        }

        public static void PrintSnake(List<Unit> snake)
        {
            foreach(Unit u in snake)
            {
                Graphic(u, '0');
            }
            Graphic(snake.Last(), '+');
        }

        public static void PrintSelectLengthOfSnake()
        {
            Console.WriteLine();
            Console.Write("Начальная длина змейки, включая голову (Укажите значение от 3 до 5): ");
        }

        public static void PrintSelectSizeOfField()
        {
            Console.WriteLine();
            Console.Write("Размер поля(от 15x15 до 50x30): ");
        }

        public static void PrintSelectSpeedMode()
        {
            Console.Write("Увеличивать скорость движения (y/n)? ");
        }

        public static void PrintSelectCollisionWall()
        {
            Console.Write("\nВключить столкновение со стенами (y/n)? ");
        }

        public static void PrintSelectCollisionTail()
        {
            Console.Write("\nВключить столкновение с хвостом (y/n)? ");
        }

        public static void PrintUserAnswer(ConsoleKeyInfo k)
        {
            Console.Write(k.KeyChar);
            Console.WriteLine();
        }

        public static void Pause()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                key = Console.ReadKey(true);
            }
            while (key.Key != ConsoleKey.P);
        }

        public static void PrintFinishGame()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 6, 3);
            Console.Write("Нажмите Space"); Console.SetCursorPosition(Console.WindowWidth / 2 - 6, 3);

            ConsoleKeyInfo k = new ConsoleKeyInfo();

            do
            {
                k = Console.ReadKey(true);
            }
            while (k.Key != ConsoleKey.Spacebar);
        }

        public static void PrintCount(int count)
        {
            Console.SetCursorPosition(6, 2);
            Console.Write(count);
        }
    }
}
