namespace ToyRobot
{
    public static class Directionenum
    {
        public const string North = "NORTH";
        public const string East = "EAST";
        public const string South = "SOUTH";
        public const string West = "WEST";

        public static LinkedList<string>
            DirectionenumList = new LinkedList<string>(new[] { North, East, South, West });

        public static bool IsValidDirection(this string direction)
        {
            if (DirectionenumList.Contains(direction))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string LeftRotation(this string direction)
        {
            var currentpostion = DirectionenumList.Find(direction);

            if (currentpostion == null)
                return null;

            return (currentpostion.Previous ?? DirectionenumList.Last).Value;
        }

        public static string RightRotation(this string direction)
        {
            var currentpostion = DirectionenumList.Find(direction);

            if (currentpostion == null)
                return null;

            return (currentpostion.Previous ?? DirectionenumList.First).Value;
        }
    }
}
