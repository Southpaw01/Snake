using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;
using Xunit;

namespace SnakeTests
{
    public class SnakeTest
    {
        [Fact]
        public void TestDefineNextStep_ToRight()
        {
            // Arrange
            Snake snake = new Snake();
            snake.direction = Direction.Right;
            snake.Head = new Unit { X = 8, Y = 10 };
            Unit expected = new Unit { X = 9, Y = 10 };


            // Act
            snake.DefineNextStep();

            // Assert
            Assert.Equal(expected.X, snake.Head.X);

        }

        [Fact]
        public void TestDefineNextStep_ToLeft()
        {
            // Arrange
            Snake snake = new Snake();
            snake.direction = Direction.Left;
            snake.Head = new Unit { X = 8, Y = 10 };
            Unit expected = new Unit { X = 7, Y = 10 };


            // Act
            snake.DefineNextStep();

            // Assert
            Assert.Equal(expected.X, snake.Head.X);
        }

        [Fact]
        public void TestDefineNextStep_ToTop()
        {
            // Arrange
            Snake snake = new Snake();
            snake.direction = Direction.Top;
            snake.Head = new Unit { X = 8, Y = 10 };
            Unit expected = new Unit { X = 8, Y = 9 };


            // Act
            snake.DefineNextStep();

            // Assert
            Assert.Equal(expected.X, snake.Head.X);
        }

        [Fact]
        public void TestDefineNextStep_ToBottom()
        {
            // Arrange
            Snake snake = new Snake();
            snake.direction = Direction.Bottom;
            snake.Head = new Unit { X = 8, Y = 10 };
            Unit expected = new Unit { X = 8, Y = 11 };


            // Act
            snake.DefineNextStep();

            // Assert
            Assert.Equal(expected.X, snake.Head.X);
        }
    }
}
