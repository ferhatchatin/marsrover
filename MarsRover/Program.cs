using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static int roverCount = 0;
        static List<int> boundaries = new List<int>();
        static List<Rover> rovers = new List<Rover>();
        static StringBuilder sb = new StringBuilder();
        static string boundaryInput = "";

        static void Main(string[] args)
        {
            Console.WriteLine("*****************Information*****************");
            Console.WriteLine("Possible Directions : N(North), S(South), W(West), E(East)");
            Console.WriteLine("Possible Moves: L(Left), R(Right), M(Move)");
            Console.WriteLine("*****************Information*****************");
            try
            {

                SetBoundaries();
                SetRoverCount();

                for (int i = 1; i <= roverCount; i++)
                {
                    Console.WriteLine($"Please enter start positions for Rover[{i}]. Format= X Y Direction");
                    var startPositions = Console.ReadLine().Trim().Split(' ');
                    int startX = Convert.ToInt32(startPositions[0]);
                    int startY = Convert.ToInt32(startPositions[1]);
                    char startDirection = Convert.ToChar(startPositions[2].ToUpper());

                    Rover rover = new Rover(i, startX, startY, startDirection);
                    rover.MaxX = boundaries[0]+1;
                    rover.MaxY = boundaries[1]+1;

                    Console.WriteLine($"Please enter moves for Rover[{i}]. Format(LRM) (with no space!)");
                    rover.Moves = Console.ReadLine().ToUpper();

                    rover.Go();
                    rovers.Add(rover);
                    Console.WriteLine("----------------------------");
                }

                sb.AppendLine("********************************");
                sb.AppendLine("Rovers' final states: ");

                foreach (Rover rover in rovers)
                    sb.AppendLine(rover.ToString());

                WriteWholePlateu();

                Console.WriteLine(sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        private static void SetBoundaries()
        {
            try
            {
                Console.WriteLine("Please enter the boundaries of plateu. Format(X Y)");
                boundaryInput = Console.ReadLine().Trim();

                boundaries = boundaryInput.Split(' ').Select(int.Parse).ToList();
            }
            catch
            {
                Console.WriteLine($"Invalid input: '{boundaryInput}'. Please try again.");
            }
        }

        private static void SetRoverCount()
        {
            Console.WriteLine("Please enter rover count:");
            var roverInput = Console.ReadLine();

            if (!IsNumeric(roverInput))
            {
                throw new Exception($"Invalid number : '{roverInput}'");
            }

            roverCount = Convert.ToInt32(roverInput);
        }

        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private static void WriteWholePlateu()
        {
            Console.WriteLine("Plateu View: ");
            StringBuilder sb = new StringBuilder();
            int dimX = boundaries[0];
            int dimY = boundaries[1];

            for (int i = 0; i <= dimX; i++)
            {
                sb.AppendLine();
                for (int j = 0; j <= dimY; j++)
                {                    
                    sb.Append(CheckRoverExists(i, j));
                }
            }

            Console.WriteLine(sb.ToString());
        }

        private static string CheckRoverExists(int plateuX, int plateuY)
        {
            foreach (var rover in rovers)
            {
                if (rover.coordinate.X == plateuX && rover.coordinate.Y == plateuY)
                    return $" R{rover.Id}";
            }

            return "  -  ";
        }

    }
}
