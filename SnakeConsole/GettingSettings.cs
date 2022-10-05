using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;

namespace SnakeConsole
{
    public static class GettingSettings
    {

        static string[] line = new string[5];
        static ConsoleKeyInfo k = new ConsoleKeyInfo();

        static readonly int minX = 15;
        static readonly int maxX = 50;
        static readonly int minY = 15;
        static readonly int maxY = 30;

        static bool CheckUserAnswer()
        {
            do
            {
                k = Console.ReadKey(true);
            }
            while ((k.Key != ConsoleKey.Y) && (k.Key != ConsoleKey.N));

            if (k.Key == ConsoleKey.Y)
                return true;
            else return false;
        }

        public static bool CheckSizeOfGameField(int x, int y)
        {
            if ((x < minX) || (x > maxX))
            {
                return true;
            }
            else
            if ((y < minY) || (y > maxY))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string[] ApplyUserSettings()
        {
            int i = 0;

            line[i] = SelectLengthOfSnake();
            i++;

            line[i] = SelectSizeOfField();
            i++;

            line[i] = SelectSpeedMode();
            i++;

            line[i] = SelectCollisionWall();
            i++;

            line[i] = SelectCollisionTail();

            InputOutputSystem.SaveFile.SaveSettingsToTextFile(line);

            return line;
        }

        static string SelectLengthOfSnake()
        {
            do
            {
                Printer.PrintSelectLengthOfSnake();
                k = Console.ReadKey();
            }
            while ((Convert.ToInt32(k.Key) < 3) && (Convert.ToInt32(k.Key) > 5));

            return Convert.ToString(k.KeyChar);
        }

        static string SelectSizeOfField()
        {
            int x = 0;
            int y = 0;

            string size;
            do
            {
                Printer.PrintSelectSizeOfField();
                size = Console.ReadLine();
                string[] div = size.Split('x');
                x = int.Parse(div[0]);
                y = int.Parse(div[1]);
            }
            while ((CheckRecordFormatOfSizeField(size)) || (CheckSizeOfGameField(x, y)));

            return size;
        }

        static string SelectSpeedMode()
        {
            Printer.PrintSelectSpeedMode();
            bool speedMode = CheckUserAnswer();

            return speedMode.ToString();
        }

        static string SelectCollisionWall()
        {
            Printer.PrintSelectCollisionWall();
            bool collisionWalls = CheckUserAnswer();

            return collisionWalls.ToString();
        }

        static string SelectCollisionTail()
        {
            Printer.PrintSelectCollisionTail();
            bool collisionTail = CheckUserAnswer();

            return collisionTail.ToString();
        }

        static bool CheckRecordFormatOfSizeField(string s)
        {
            if ((s.Length == 5) && (s[2] == 'x'))
                return false;
            else return true;
        }

    }
}
