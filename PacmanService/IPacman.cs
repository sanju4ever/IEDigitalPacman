using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanService
{
    public interface IPacman
    {
        void Place(int x, int y, string d);

        void Move();

        void Left();

        void Right();

        string Report();
    }
}
