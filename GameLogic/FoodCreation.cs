using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    internal class FoodCreation
    {
        static Random r = new Random();

        public static Unit CreateFood(int x, int y)
        {
            return new Unit()
            {
                X = r.Next(1, x),
                Y = r.Next(1, y)
            };
        }
    }
}
