using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Snake
    {
        List<Unit> body = new List<Unit>();
        double speed = 200;
        int length;
        bool incSpeed;
        bool collTail;
        public Unit head;

        public Direction direction { get; set; } = Direction.Right;
        public Unit Head
        {
            get
            {
                return head;
            }
            
            set
            {
                head = value;
            }
        }

        public List<Unit> Body 
        {
            get 
            {
                return body; 
            } 
        }

        public Snake()
        {
            length = Settings.length;
            incSpeed = Settings.speedMode;
            collTail = Settings.collisionTail;

            CreateBody();
        }

        void CreateBody()
        {
            body = new List<Unit>(length);

            for (int i = 0; i < length; i++)
            {
                body.Add(new Unit() { X = 8 + i, Y = 5 });
            }
            Head = body.Last();
        }

        public void MakeStep()
        {
            DefineNextStep();     
            UpSpeed();
            SpeedSnake();
        }

        void SpeedSnake()
        {
            Thread.Sleep((int)speed);
        }

        void UpSpeed()
        {
            if (incSpeed)
            {
                speed -= 0.01;
            }
        }

        public void DefineNextStep()
        {
            switch (direction)
            {
                case Direction.Left: head.X -= 1; break;
                case Direction.Right: head.X += 1; break;
                case Direction.Top: head.Y -= 1; break;
                case Direction.Bottom: head.Y += 1; break;
            }
        }

        public bool CheckHeadToTailCollision()
        {
            if (collTail)
                for (int i = 0; i < body.Count - 1; i++)
                {
                    if (((Head.X == body[i].X) && (Head.Y == body[i].Y)))
                    {
                        return true;
                    }
                }
            return false;
        }

        public void ChangeDirection(Direction newDirection)
        {
            switch (newDirection)
            {
                case Direction.Bottom:
                    if (direction != Direction.Top)
                    {
                        direction = Direction.Bottom;
                    }
                    break;
                case Direction.Top:
                    if (direction != Direction.Bottom)
                    {
                        direction = Direction.Top;
                    }
                    break;
                case Direction.Left:
                    if (direction != Direction.Right)
                    {
                        direction = Direction.Left;
                    }
                    break;
                case Direction.Right:
                    if (direction != Direction.Left)
                    {
                        direction = Direction.Right;
                    }
                    break;
            }
        }

        public void AddUnitToBody()
        {
            Unit u = new Unit() { X = body[0].X, Y = body[0].Y};
            body.Insert(0, u);
        }

        public void Move()
        {
            body.Add(Head);

            body.RemoveAt(0);
        }
    }
}
