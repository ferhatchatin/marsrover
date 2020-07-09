using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Rover
    {
        public int Id { get; set; }
        public Coordinate coordinate { get; set; }
        public Enums Direction { get; set; }
        public string Moves { get; set; }

        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public Rover(int id, int x, int y, char direction)
        {
            this.Id = id;
            this.coordinate = new Coordinate(x, y);
            this.Direction = ConvertToDirectionEnum(direction);
        }

        private void RotateLeft()
        {
            switch (this.Direction)
            {
                case Enums.North:
                    Direction = Enums.West;
                    break;
                case Enums.South:
                    Direction = Enums.East;
                    break;
                case Enums.East:
                    Direction = Enums.North;
                    break;
                case Enums.West:
                    Direction = Enums.South;
                    break;
                default:
                    break;
            }
        }

        private void RotateRight()
        {
            switch (this.Direction)
            {
                case Enums.North:
                    Direction = Enums.East;
                    break;
                case Enums.South:
                    Direction = Enums.West;
                    break;
                case Enums.East:
                    Direction = Enums.South;
                    break;
                case Enums.West:
                    Direction = Enums.North;
                    break;
                default:
                    break;
            }
        }

        private MoveEnum ConvertToMoveEnum(char command)
        {
            MoveEnum result;
            switch (command)
            {
                case 'L':
                    result = MoveEnum.Left;
                    break;
                case 'R':
                    result = MoveEnum.Right;
                    break;
                case 'M':
                    result = MoveEnum.Go;
                    break;
                default:
                    throw new Exception("invalid command");
            }

            return result;
        }

        private Enums ConvertToDirectionEnum(char command)
        {
            Enums result;
            switch (command)
            {
                case 'N':
                    result = Enums.North;
                    break;
                case 'S':
                    result = Enums.South;
                    break;
                case 'E':
                    result = Enums.East;
                    break;
                case 'W':
                    result = Enums.West;
                    break;
                default:
                    throw new Exception("invalid command");
            }

            return result;
        }

        public void Go()
        {
            foreach (char command in this.Moves)
            {
                MoveEnum move = ConvertToMoveEnum(command);
                if (move == MoveEnum.Left)
                    RotateLeft();
                else if (move == MoveEnum.Right)
                    RotateRight();
                else if (move == MoveEnum.Go)
                    this.coordinate.Move(this.Direction);
                else
                    throw new Exception($"Unknown command:'{command}'");

                if (this.coordinate.X > this.MaxX || this.coordinate.X < 0 || this.coordinate.Y < 0 || this.coordinate.Y > MaxY)
                    throw new OutOfBoundsException("Out of bounds. Coordinates: " + this.ToString());
            }
        }

        public override string ToString()
        {
            return $"{this.coordinate.X} {this.coordinate.Y} {this.Direction.ToString().Substring(0, 1)}"; //$"Coordinates for Rover[{this.Id}] = X:{this.coordinate.X}, Y: {this.coordinate.Y}, Direction:{this.Direction.ToString()}";
        }

    }
}
