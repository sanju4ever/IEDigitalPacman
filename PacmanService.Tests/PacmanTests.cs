using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PacmanService.Tests
{
    [TestClass]
    public class PacmanTests
    {
        private Pacman _pacmanObj;

        public PacmanTests()
        {
            _pacmanObj = new Pacman();
        }

        // Place

        [TestMethod]
        public void Place_Positive_Numbers_XY_Within_Range()
        {
            _pacmanObj.Place(2, 3, "NORTH");
            Assert.AreEqual(2, _pacmanObj.PositionX);
            Assert.AreEqual(3, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.NORTH, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Place_Positive_Numbers_XY_Not_Within_Range()
        {
            _pacmanObj.Place(5, 6, "NORTH");
            Assert.AreEqual(int.MinValue, _pacmanObj.PositionX);
            Assert.AreEqual(int.MinValue, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.NORTH, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Place_Negative_Numbers_XY()
        {
            _pacmanObj.Place(-2, -3, "NORTH");
            Assert.AreEqual(int.MinValue, _pacmanObj.PositionX);
            Assert.AreEqual(int.MinValue, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.NORTH, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Place_Valid_Numbers_XY_Invalid_Direction()
        {
            _pacmanObj.Place(2, 3, "HTRON");
            Assert.AreEqual(2, _pacmanObj.PositionX);
            Assert.AreEqual(3, _pacmanObj.PositionY);
            Assert.AreEqual(string.Empty, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Place_Valid_XY_Direction_Null()
        {
            _pacmanObj.Place(0, 0, null);
            Assert.AreEqual(0, _pacmanObj.PositionX);
            Assert.AreEqual(0, _pacmanObj.PositionY);
            Assert.AreEqual(string.Empty, _pacmanObj.Direction);
        }

        // Move

        [TestMethod]
        public void Move_Without_Placing_On_Grid()
        {
            _pacmanObj.Move();
            Assert.AreEqual(int.MinValue, _pacmanObj.PositionX);
            Assert.AreEqual(int.MinValue, _pacmanObj.PositionY);
            Assert.AreEqual(string.Empty, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Move_North()
        {
            _pacmanObj.Place(2, 2, Pacman.NORTH);
            _pacmanObj.Move();
            Assert.AreEqual(2, _pacmanObj.PositionX);
            Assert.AreEqual(3, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.NORTH, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Move_East()
        {
            _pacmanObj.Place(2, 2, Pacman.EAST);
            _pacmanObj.Move();
            Assert.AreEqual(3, _pacmanObj.PositionX);
            Assert.AreEqual(2, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.EAST, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Move_South()
        {
            _pacmanObj.Place(2, 2, Pacman.SOUTH);
            _pacmanObj.Move();
            Assert.AreEqual(2, _pacmanObj.PositionX);
            Assert.AreEqual(1, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.SOUTH, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Move_West()
        {
            _pacmanObj.Place(2, 2, Pacman.WEST);
            _pacmanObj.Move();
            Assert.AreEqual(1, _pacmanObj.PositionX);
            Assert.AreEqual(2, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.WEST, _pacmanObj.Direction);
        }

        // Left

        [TestMethod]
        public void Left_Without_Placing_On_Grid()
        {
            _pacmanObj.Left();
            Assert.AreEqual(int.MinValue, _pacmanObj.PositionX);
            Assert.AreEqual(int.MinValue, _pacmanObj.PositionY);
            Assert.AreEqual(string.Empty, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Left_North()
        {
            _pacmanObj.Place(2, 2, Pacman.NORTH);
            _pacmanObj.Left();
            Assert.AreEqual(2, _pacmanObj.PositionX);
            Assert.AreEqual(2, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.WEST, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Left_East()
        {
            _pacmanObj.Place(2, 2, Pacman.EAST);
            _pacmanObj.Left();
            Assert.AreEqual(2, _pacmanObj.PositionX);
            Assert.AreEqual(2, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.NORTH, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Left_South()
        {
            _pacmanObj.Place(2, 2, Pacman.SOUTH);
            _pacmanObj.Left();
            Assert.AreEqual(2, _pacmanObj.PositionX);
            Assert.AreEqual(2, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.EAST, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Left_West()
        {
            _pacmanObj.Place(2, 2, Pacman.WEST);
            _pacmanObj.Left();
            Assert.AreEqual(2, _pacmanObj.PositionX);
            Assert.AreEqual(2, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.SOUTH, _pacmanObj.Direction);
        }

        // Right

        [TestMethod]
        public void Right_Without_Placing_On_Grid()
        {
            _pacmanObj.Right();
            Assert.AreEqual(int.MinValue, _pacmanObj.PositionX);
            Assert.AreEqual(int.MinValue, _pacmanObj.PositionY);
            Assert.AreEqual(string.Empty, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Right_North()
        {
            _pacmanObj.Place(2, 2, Pacman.NORTH);
            _pacmanObj.Right();
            Assert.AreEqual(2, _pacmanObj.PositionX);
            Assert.AreEqual(2, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.EAST, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Right_East()
        {
            _pacmanObj.Place(2, 2, Pacman.EAST);
            _pacmanObj.Right();
            Assert.AreEqual(2, _pacmanObj.PositionX);
            Assert.AreEqual(2, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.SOUTH, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Right_South()
        {
            _pacmanObj.Place(2, 2, Pacman.SOUTH);
            _pacmanObj.Right();
            Assert.AreEqual(2, _pacmanObj.PositionX);
            Assert.AreEqual(2, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.WEST, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Right_West()
        {
            _pacmanObj.Place(2, 2, Pacman.WEST);
            _pacmanObj.Right();
            Assert.AreEqual(2, _pacmanObj.PositionX);
            Assert.AreEqual(2, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.NORTH, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Combined_Command_Example_1()
        {
            _pacmanObj.Place(0, 0, Pacman.NORTH);
            _pacmanObj.Move();
            Assert.AreEqual(0, _pacmanObj.PositionX);
            Assert.AreEqual(1, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.NORTH, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Combined_Command_Example_2()
        {
            _pacmanObj.Place(0, 0, Pacman.NORTH);
            _pacmanObj.Left();
            Assert.AreEqual(0, _pacmanObj.PositionX);
            Assert.AreEqual(0, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.WEST, _pacmanObj.Direction);
        }

        [TestMethod]
        public void Combined_Command_Example_3()
        {
            _pacmanObj.Place(1, 2, Pacman.EAST);
            _pacmanObj.Move();
            _pacmanObj.Move();
            _pacmanObj.Left();
            _pacmanObj.Move();
            Assert.AreEqual(3, _pacmanObj.PositionX);
            Assert.AreEqual(3, _pacmanObj.PositionY);
            Assert.AreEqual(Pacman.NORTH, _pacmanObj.Direction);
        }
    }
}
