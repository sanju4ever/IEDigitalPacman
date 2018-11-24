using PacmanService;
using System;
using Unity;

namespace GridProvider
{
    public sealed class BasicGrid
    {
        private Pacman _pacman;

        private BasicGrid()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IPacman, Pacman>();
            _pacman = container.Resolve<Pacman>();
        }

        private static BasicGrid instance = null;
        private static readonly object padlock = new object();
        public static BasicGrid Create()
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new BasicGrid();
                }

                return instance;
            }            
        }

        private bool IsValidCommand(string command)
        {
            const string commandList = "PLACE,MOVE,REPORT,LEFT,RIGHT";
            bool valid = false;

            try
            {
                string[] commandParts = command.Split(',');
                var c = commandParts[0].ToUpper();

                valid = commandList.Contains(c);
                if (!valid) return false;

                if (!c.Equals("PLACE"))
                {
                    valid = _pacman.IsPlacedOnGrid();
                }                
            }
            catch
            {
                return false;
            }

            return valid;
        }

        public void Execute(string command)
        {
            command = command.Replace(" ", ",");
            bool successful = false;

            if (IsValidCommand(command))
            {
                successful = RunCommand(command);
            }
        }

        private bool RunCommand(string command)
        {
            bool result = false;

            try
            {
                if (command.Contains(","))
                {
                    string[] commandParts = command.Split(',');
                    var x = Convert.ToInt32(commandParts[1]);
                    var y = Convert.ToInt32(commandParts[2]);
                    var d = Convert.ToString(commandParts[3]).ToUpper();
                    result = (d.Equals(Pacman.NORTH) || d.Equals(Pacman.EAST) || d.Equals(Pacman.SOUTH) || d.Equals(Pacman.WEST));
                    if (!result) return false;

                    _pacman.Place(x, y, d);
                }
                else
                {
                    switch (command.ToUpper())
                    {
                        case "MOVE":
                            _pacman.Move();
                            break;
                        case "LEFT":
                            _pacman.Left();
                            break;
                        case "RIGHT":
                            _pacman.Right();
                            break;
                        case "REPORT":
                            _pacman.Report();
                            break;
                    }

                    result = true;
                }
            }
            catch
            {
                return false;
            }

            return result;
        }
    }
}
