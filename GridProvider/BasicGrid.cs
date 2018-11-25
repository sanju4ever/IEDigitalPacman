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

            try
            {
                string[] commandParts = command.Split(',');
                var c = commandParts[0].ToUpper();

                return commandList.Contains(c);             
            }
            catch
            {
                return false;
            }
        }

        public void Execute(string command)
        {
            command = command.Replace(" ", ",");

            if (IsValidCommand(command))
            {
                RunCommand(command);
            }
        }

        private void RunCommand(string command)
        {
            try
            {
                if (command.Contains(","))
                {
                    string[] commandParts = command.Split(',');
                    var x = Convert.ToInt32(commandParts[1]);
                    var y = Convert.ToInt32(commandParts[2]);
                    var d = Convert.ToString(commandParts[3]).ToUpper();

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
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
