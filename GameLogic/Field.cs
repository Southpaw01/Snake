using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Field
    {
        public int x { get; set; }
        public int y { get; set; }

        bool collWall { get; set; }

        public Snake snake;
        public Unit food;
        public List<Unit> bottomWall = new List<Unit>();
        public List<Unit> topWall = new List<Unit>();
        public List<Unit> rightWall = new List<Unit>();
        public List<Unit> leftWall = new List<Unit>();

        public Field()
        {
            x = Settings.x;
            y = Settings.y;
            collWall = Settings.collisionWalls;

            snake = new Snake();
            CreateWalls();
            AddNewFood();
        }

        public void CreateWalls()
        {
            bottomWall = WallCreation.CreateHorizontalWalls(x, y + 1);
            topWall = WallCreation.CreateHorizontalWalls(x, 0);
            rightWall = WallCreation.CreateVerticalWalls(x + 1, y);
            leftWall = WallCreation.CreateVerticalWalls(0, y);
        }

        public void FindNextStepSnake(Direction direction)
        {
            snake.ChangeDirection(direction);
            snake.MakeStep();
        }

        public void MakeMoveSnake()
        {
            snake.Move();
        }

        public bool CheckBumpedSnakeOnWallOrTail()
        {
            bool bumpInWall = false;

            if (collWall)
            {
               bumpInWall = SelectCheckedWall();
            }
            else
            {
                CheckCollisionWithWallsWithoutCollision();
            }

            bool bumpInTail = snake.CheckHeadToTailCollision();

            return bumpInWall | bumpInTail;
        }

        bool SelectCheckedWall()
        {

            switch (snake.direction)
            {
                case Direction.Left: return CheckCollisionSnakeWithWalls(leftWall);
                case Direction.Right: return CheckCollisionSnakeWithWalls(rightWall);
                case Direction.Top: return CheckCollisionSnakeWithWalls(topWall);
                case Direction.Bottom: return CheckCollisionSnakeWithWalls(bottomWall);
            }

            return false;
        }

        bool CheckCollisionSnakeWithWalls(List<Unit> wall)
        {
            foreach (Unit u in wall)
            {
                if ((u.X == snake.Head.X) && (u.Y == snake.Head.Y))
                {
                    return true;
                }
            }

            return false;
        }

        void CheckCollisionWithWallsWithoutCollision()
        {
            Unit u = snake.Head;

            if ((snake.Head.X == rightWall[0].X) && (snake.direction == Direction.Right))
            {
                u.X = leftWall[0].X + 1;
            }
            else if ((snake.Head.X == leftWall[0].X) && (snake.direction == Direction.Left))
            {
                u.X = rightWall[0].X - 1;
            }
            else if ((snake.Head.Y == topWall[0].Y) && (snake.direction == Direction.Top))
            {
                u.Y = bottomWall[0].Y - 1;
            }
            else if ((snake.Head.Y == bottomWall[0].Y) && (snake.direction == Direction.Bottom))
            {
                u.Y = topWall[0].Y + 1;
            }

            snake.Head = u;
        }

        public bool CheckFoodEaten()
        {
            Unit u = snake.Head;
            if ((u.X == food.X) && (u.Y == food.Y))
            {
                snake.AddUnitToBody();

                if (snake.Body.Count - Settings.length != x * y)
                AddNewFood();

                return true;
            }

            return false;
        }

        void AddNewFood()
        {
            do
            {
                food = FoodCreation.CreateFood(x, y);
            }
            while (CheckPlaceForEat());
        }

        bool CheckPlaceForEat()
        {
            foreach (Unit u in snake.Body)
            {
                if ((u.X == food.X) && (u.Y == food.Y))
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckFullField()
        {
            if (x * y == snake.Body.Count)
            {
                return true;
            }
            return false;
        }
    }
}
