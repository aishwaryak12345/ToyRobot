namespace ToyRobot
{
    public class Robot
    {
        private readonly int _X;
        private readonly int _Y;

        public Robot(int x = 5, int y = 5)
        {
            _X = x;
            _Y = y;
        }

        public int? X { get; set; }
        public int? Y { get; set; }
        public string? F{ get; set; }

        public virtual void postion(int x, int y, string f)
        {
            if (IsValid(x, y, f))
            {
                X = x;
                Y = y;
                F = f;
            }
        }
        public virtual void move()
        {
            if (F == Directionenum.North && IsValid(X, Y + 1, F))
                Y += 1;
            if (F == Directionenum.East && IsValid(X + 1, Y, F))
                X += 1;
            if (F == Directionenum.South && IsValid(X, Y - 1, F))
                Y -= 1;
            if (F == Directionenum.West && IsValid(X - 1, Y, F))
                X -= 1;
        }
        private bool IsValid(int? x, int? y, string f)
        {
            var xIsValid = x >= 0 && x < _X;
            var yIsValid = y >= 0 && y < _Y;
            return xIsValid && yIsValid && f.IsValidDirection();
        }

        public virtual void Left()
        {
            if (F.IsValidDirection())
            {
                F = F.LeftRotation();
            }
            else
            {
                F = null;
            }
        }
        public virtual void Right()
        {
            if (F.IsValidDirection())
            {
                F = F.RightRotation();
            }
            else
            {
                F = null;
            }
        }

        public virtual string Report()
        {
            if (IsValid(X, Y, F))
            {
                return $"{X},{Y},{F}";
            }
            else
            {
                return null;
            }
        }
    }
}
