using System;

namespace PacmanService
{
    public class Pacman: IPacman
    {
        public const string NORTH = "NORTH";
        public const string EAST = "EAST";
        public const string SOUTH = "SOUTH";
        public const string WEST = "WEST";

        private int PositionX { get; set; } = int.MinValue;
        private int PositionY { get; set; } = int.MinValue;
        private string Direction { get; set; } = string.Empty;

        public void Place(int x, int y, string d)
        {
            PositionX = x;
            PositionY = y;
            Direction = d;
        }

        public void Move()
        {
            PositionX++;
            PositionY++;
        }

        public void Left()
        {
            Direction = NORTH;
        }

        public void Right()
        {
            Direction = SOUTH;
        }

        public void Report()
        {
            var cLocation = "X: {0}, Y: {1}, F: {2}";
            Console.WriteLine(cLocation, PositionX.ToString(), PositionY.ToString(), Direction.ToString());
        }

        public bool IsPlacedOnGrid()
        {
            return (PositionX >= 0 && PositionY >= 0 && Direction.Length > 0);
        }
    }
}
