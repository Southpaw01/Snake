using System;
using GameLogic;
using Xunit;

namespace SnakeTests
{
    public class FieldTest
    {
        [Fact]
        public void TestBumpedSnakeOnWallWithCollision_ReturnedFalse()
        {
            // Arrange
            Settings.collisionWalls = true;
            Field field = new Field();
            field.snake.Head = new Unit { X = 5, Y = 6 };
            bool expected = false;

            // Act
            bool bumpedInWall = field.CheckBumpedSnakeOnWallOrTail();

            // Assert
            Assert.Equal(expected, bumpedInWall);
        }

        [Fact]
        public void TestBumpedSnakeOnRightWallWithCollision_ReturnedTrue()
        {
            // Arrange
            Settings.collisionWalls = true;
            Field field = new Field();
            field.snake.Head = new Unit() { X = field.x + 1, Y = 6 };
            bool expected = true;

            // Act
            bool bumpedInWall = field.CheckBumpedSnakeOnWallOrTail();

            // Assert
            Assert.Equal(expected, bumpedInWall);
        }

        [Fact]
        public void TestBumpedSnakeOnLeftWallWithCollision_ReturnedTrue()
        {
            // Arrange
            Settings.collisionWalls = true;
            Field field = new Field();
            field.snake.Head = new Unit() { X = 0, Y = 5 };
            field.snake.direction = Direction.Left;
            bool expected = true;

            // Act
            bool bumpedInWall = field.CheckBumpedSnakeOnWallOrTail();

            // Assert
            Assert.Equal(expected, bumpedInWall);
        }

        [Fact]
        public void TestBumpedSnakeOnTopWallWithCollision_ReturnedTrue()
        {
            // Arrange
            Settings.collisionWalls = true;
            Field field = new Field();
            field.snake.Head = new Unit() { X = 4, Y = 0 };
            field.snake.direction = Direction.Top;
            bool expected = true;

            // Act
            bool bumpedInWall = field.CheckBumpedSnakeOnWallOrTail();

            // Assert
            Assert.Equal(expected, bumpedInWall);
        }

        [Fact]
        public void TestBumpedSnakeOnBottomtWallWithCollision_ReturnedTrue()
        {
            // Arrange
            Settings.collisionWalls = true;
            Field field = new Field();
            field.snake.Head = new Unit() { X = 6, Y = field.y + 1};
            field.snake.direction = Direction.Bottom;
            bool expected = true;

            // Act
            bool bumpedInWall = field.CheckBumpedSnakeOnWallOrTail();

            // Assert
            Assert.Equal(expected, bumpedInWall);
        }

        [Fact]
        public void TestBumpedSnakeOnRightWallWithoutCollision()
        {
            // Arrange
            Settings.collisionWalls = false;
            Field field = new Field();
            field.snake.Head = new Unit() { X = field.x + 1, Y = 6 };
            Unit expectedHead = new Unit() { X = 1, Y = 6 };

            // Act
            field.CheckBumpedSnakeOnWallOrTail();

            // Assert
            Assert.Equal(expectedHead.X, field.snake.Head.X);
            Assert.Equal(expectedHead.Y, field.snake.Head.Y);
        }

        [Fact]
        public void TestBumpedSnakeOnLeftWallWithoutCollision()
        {
            // Arrange
            Settings.collisionWalls = false;
            Field field = new Field();
            field.snake.Head = new Unit() { X = 0, Y = 6 };
            field.snake.direction = Direction.Left;
            Unit expectedHead = new Unit() { X = field.x, Y = 6 };

            // Act
            field.CheckBumpedSnakeOnWallOrTail();

            // Assert
            Assert.Equal(expectedHead.X, field.snake.Head.X);
            Assert.Equal(expectedHead.Y, field.snake.Head.Y);
        }

        [Fact]
        public void TestBumpedSnakeOnTopWallWithoutCollision()
        {
            // Arrange
            Settings.collisionWalls = false;
            Field field = new Field();
            field.snake.Head = new Unit() { X = 23, Y = 0 };
            field.snake.direction = Direction.Top;
            Unit expectedHead = new Unit() { X = 23, Y = field.y };

            // Act
            field.CheckBumpedSnakeOnWallOrTail();

            // Assert
            Assert.Equal(expectedHead.X, field.snake.Head.X);
            Assert.Equal(expectedHead.Y, field.snake.Head.Y);
        }

        [Fact]
        public void TestBumpedSnakeOnBottomWallWithoutCollision()
        {
            // Arrange
            Settings.collisionWalls = false;
            Field field = new Field();
            field.snake.Head = new Unit() { X = 23, Y = field.y + 1 };
            field.snake.direction = Direction.Bottom;
            Unit expectedHead = new Unit() { X = 23, Y = 1 };

            // Act
            field.CheckBumpedSnakeOnWallOrTail();

            // Assert
            Assert.Equal(expectedHead.X, field.snake.Head.X);
            Assert.Equal(expectedHead.Y, field.snake.Head.Y);
        }


    }
}