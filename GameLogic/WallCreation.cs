using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class WallCreation
    {
        static List<Unit> wall;

        public static List<Unit> CreateHorizontalWalls(int x, int y)
        {
            wall = new List<Unit>();

            for (int i = 0; i <= x; i++)
            {
                wall.Add(new Unit() { X = i, Y = y });
            }

            return wall;
        }

        public static List<Unit> CreateVerticalWalls(int x, int y) 
        {
            wall = new List<Unit>();

            for (int i = 0; i <= y; i++)
            {
                wall.Add(new Unit() { X = x, Y = i });
            }

            return wall;
        }
    }
}
