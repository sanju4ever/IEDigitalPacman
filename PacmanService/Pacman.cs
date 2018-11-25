using System;

namespace PacmanService
{
    public class Pacman: IPacman
    {
        public const string NORTH = "NORTH";
        public const string EAST = "EAST";
        public const string SOUTH = "SOUTH";
        public const string WEST = "WEST";

        public const int GRIDMAX = 4;
        public const int GRIDMIN = 0;

        private int PositionX { get; set; } = int.MinValue;
        private int PositionY { get; set; } = int.MinValue;
        private string Direction { get; set; } = string.Empty;

        public void Place(int x, int y, string d)
        {
            if (x >= GRIDMIN && x <= GRIDMAX) PositionX = x;
            if (y >= GRIDMIN && y <= GRIDMAX) PositionY = y;

            switch (d.ToUpper())
            {
                case NORTH:
                case EAST:
                case SOUTH:
                case WEST:
                    Direction = d.ToUpper();
                    break;
                default:
                    Direction = string.Empty;
                    break;
            }
        }

        public void Move()
        {
            if (IsPlacedOnGrid())
            {
                switch (Direction)
                {
                    case NORTH:
                        if (PositionY < GRIDMAX) PositionY++;
                        break;
                    case EAST:
                        if (PositionX < GRIDMAX) PositionX++;
                        break;
                    case SOUTH:
                        if (PositionY > GRIDMIN) PositionY--;
                        break;
                    case WEST:
                        if (PositionX > GRIDMIN) PositionX--;
                        break;
                }
            }
        }

        public void Left()
        {
            if (IsPlacedOnGrid())
            {
                switch (Direction)
                {
                    case NORTH:
                        Direction = WEST;
                        break;
                    case EAST:
                        Direction = NORTH;
                        break;
                    case SOUTH:
                        Direction = EAST;
                        break;
                    case WEST:
                        Direction = SOUTH;
                        break;
                }
            }
        }

        public void Right()
        {
            if (IsPlacedOnGrid())
            {
                switch (Direction)
                {
                    case NORTH:
                        Direction = EAST;
                        break;
                    case EAST:
                        Direction = SOUTH;
                        break;
                    case SOUTH:
                        Direction = WEST;
                        break;
                    case WEST:
                        Direction = NORTH;
                        break;
                }
            }
        }

        public void Report()
        {
            if (IsPlacedOnGrid())
            {
                var message = "Output: {0}, {1}, {2}";
                Console.WriteLine(message, PositionX.ToString(), PositionY.ToString(), Direction.ToString());
            }
        }

        private bool IsPlacedOnGrid()
        {
            return (PositionX >= GRIDMIN && PositionX <= GRIDMAX)
                && (PositionY >= GRIDMIN && PositionY <= GRIDMAX)
                && (Direction.Equals(NORTH) || Direction.Equals(EAST) || Direction.Equals(SOUTH) || Direction.Equals(WEST));
        }
    }
}
