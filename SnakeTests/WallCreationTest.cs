using System.Collections.Generic;
using Xunit;
using GameLogic;

namespace SnakeTests
{
    public class WallCreationTest
    {
        [Fact]
        public void CreateLeftlWall()
        {
            // Arrange
            List<Unit> wall = new List<Unit>();
            int y = 15;
            int expected = 17;

            // Act
            wall = WallCreation.CreateVerticalWalls(0, y + 1);

            // Assert
            Assert.Equal(expected, wall.Count);
        }

        [Fact]
        public void CreateRightlWall()
        {
            // Arrange
            List<Unit> wall = new List<Unit>();
            int x = 30;
            int y = 15;
            int expected = 17;

            // Act
            wall = WallCreation.CreateVerticalWalls(x, y + 1);

            // Assert
            Assert.Equal(expected, wall.Count);
        }

        [Fact]
        public void CreateTopWall()
        {
            // Arrange
            List<Unit> wall = new List<Unit>();
            int x = 25;
            int expected = 27;

            // Act
            wall = WallCreation.CreateHorizontalWalls(x + 1, 0);

            // Assert
            Assert.Equal(expected, wall.Count);
        }

        [Fact]
        public void CreateBottomWall()
        {
            // Arrange
            List<Unit> wall = new List<Unit>();
            int x = 25;
            int y = 20;
            int expected = 27;

            // Act
            wall = WallCreation.CreateHorizontalWalls(x + 1, y);

            // Assert
            Assert.Equal(expected, wall.Count);
        }
    }
}