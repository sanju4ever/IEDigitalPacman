using System;

namespace PacmanService
{
    public class Pacman: IPacman
    {
        public const string NORTH = "NORTH";
        public const string EAST = "EAST";
        public const string SOUTH = "SOUTH";
        public const string WEST = "WEST";

        private const int GRIDMAX = 4;
        private const int GRIDMIN = 0;

        private int positionX = int.MinValue;
        private int positionY = int.MinValue;
        private string direction = string.Empty;

        public int PositionX
        {
            get { return positionX; }
        }

        public int PositionY
        {
            get { return positionY; }
        }

        public string Direction
        {
            get { return direction; }
        }

        public void Place(int x, int y, string d)
        {
            if (x >= GRIDMIN && x <= GRIDMAX) positionX = x;
            if (y >= GRIDMIN && y <= GRIDMAX) positionY = y;

            switch (d.ToUpper())
            {
                case NORTH:
                case EAST:
                case SOUTH:
                case WEST:
                    direction = d.ToUpper();
                    break;
                default:
                    direction = string.Empty;
                    break;
            }
        }

        public void Move()
        {
            if (IsPlacedOnGrid())
            {
                switch (direction)
                {
                    case NORTH:
                        if (positionY < GRIDMAX) positionY++;
                        break;
                    case EAST:
                        if (positionX < GRIDMAX) positionX++;
                        break;
                    case SOUTH:
                        if (positionY > GRIDMIN) positionY--;
                        break;
                    case WEST:
                        if (positionX > GRIDMIN) positionX--;
                        break;
                }
            }
        }

        public void Left()
        {
            if (IsPlacedOnGrid())
            {
                switch (direction)
                {
                    case NORTH:
                        direction = WEST;
                        break;
                    case EAST:
                        direction = NORTH;
                        break;
                    case SOUTH:
                        direction = EAST;
                        break;
                    case WEST:
                        direction = SOUTH;
                        break;
                }
            }
        }

        public void Right()
        {
            if (IsPlacedOnGrid())
            {
                switch (direction)
                {
                    case NORTH:
                        direction = EAST;
                        break;
                    case EAST:
                        direction = SOUTH;
                        break;
                    case SOUTH:
                        direction = WEST;
                        break;
                    case WEST:
                        direction = NORTH;
                        break;
                }
            }
        }

        public string Report()
        {
            if (IsPlacedOnGrid())
            {
                var message = "Output: {0}, {1}, {2}";
                return string.Format(message, positionX.ToString(), positionY.ToString(), direction.ToString());
            }

            return string.Empty;
        }

        private bool IsPlacedOnGrid()
        {
            return (positionX >= GRIDMIN && positionX <= GRIDMAX)
                && (positionY >= GRIDMIN && positionY <= GRIDMAX)
                && (direction.Equals(NORTH) || direction.Equals(EAST) || direction.Equals(SOUTH) || direction.Equals(WEST));
        }
    }
}
