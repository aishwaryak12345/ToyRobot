using System.Text.RegularExpressions;

namespace ToyRobot
{
    public class Simulator
    {
        private static readonly Regex _placeCommand = new Regex(@"PLACE (\d+),(\d+),(\w+)");
        private readonly Robot _robot;

        public Simulator(Robot robot)
        {
            _robot = robot;
        }
        public void ExecuteCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                return;
            if (command == "MOVE")
                _robot.move();
            if (command == "LEFT")
                _robot.Left();
            if (command == "RIGHT")
                _robot.Right();
            if (command == "REPORT")
                Console.WriteLine(_robot.Report());

            var match = _placeCommand.Match(command);
            if (match.Success)
            {
                var xIsValid = int.TryParse(match.Groups[1].Value, out var x);
                var yIsValid = int.TryParse(match.Groups[2].Value, out var y);
                var f = match.Groups[3].Value;
                if (xIsValid && yIsValid)
                {
                    _robot.postion(x, y, f);
                }
            }
        }
    }
}
