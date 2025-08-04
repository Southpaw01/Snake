using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Game
    {
        public Field field;

        public Game()
        {
            field = new Field();
        }

        public Direction NextDirection { get; set; } = Direction.Right;
        public bool isGameOver { get; set; } = false;
        public int counter { get; private set; } = 0;

        public void Process()
        {
            field.FindNextStepSnake(NextDirection);

            if ((field.CheckBumpedSnakeOnWallOrTail()) || (field.CheckFullField()))
            {
                GameOver();
            }

            if (field.CheckFoodEaten())
            {
                IncreaseCounter();
            }

            field.MakeMoveSnake();
        }

        void IncreaseCounter()
        {
            counter++;
        }

        void GameOver()
        {
            isGameOver = true;
        }

    }
}
