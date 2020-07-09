namespace ConsoleApp1
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Move(Enums direction)
        {
            switch (direction)
            {
                case Enums.North:
                    this.Y += 1;
                    break;
                case Enums.South:
                    this.Y -= 1;
                    break;
                case Enums.East:
                    this.X += 1;
                    break;
                case Enums.West:
                    this.X -= 1;
                    break;
            }
        }

    }
}
