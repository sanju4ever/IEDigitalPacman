using GridProvider;
using System;

namespace MacmanSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;

            do
            {
                Console.Write("Enter command: ");
                command = Console.ReadLine();

                var grid = BasicGrid.Create();
                grid.Execute(command);
            }
            while (command.Length > 0);
        }
    }
}
