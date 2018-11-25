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

        [TestMethod]
        public void Place_Positive_Numbers_All_Within_Range()
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
    }
}
