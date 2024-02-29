using System.Diagnostics.Metrics;
using ToyRobot;
using Xunit;

namespace ToyRobottest
{
    [TestClass]
    public class PlaceMove
    {
        [DataTestMethod]
        [DataRow(0)]                                              
        [DataRow(1)]
        [DataRow(2)]
        public void Set_robots_X_position(int x)
        {
            var toyRobot = new Robot();

            toyRobot.postion(x, 2, Directionenum.South);

            Assert.AreEqual(x, toyRobot.X);
        }
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        public void Set_robots_Y_position(int y)
        {
            var toyRobot = new Robot();

            toyRobot.postion(1, y, Directionenum.South);

            Assert.AreEqual(y, toyRobot.Y);
        }

        [DataTestMethod]
        [DataRow(Directionenum.North)]
        [DataRow(Directionenum.South)]
        [DataRow(Directionenum.East)]
        [DataRow(Directionenum.West)]
        public void Set_robots_direction(string direction)
        {
            var toyRobot = new Robot();

            toyRobot.postion(1, 2, direction);

            Assert.AreEqual(direction, toyRobot.F);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-2)]
        [DataRow(5)]
        [DataRow(6)]
        public void Discard_command_when_X_is_invalid(int x)
        {
            var toyRobot = new Robot();

            toyRobot.postion(x, 2, Directionenum.South);

            Assert.IsNull(toyRobot.X);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-2)]
        [DataRow(5)]
        [DataRow(6)]
        public void Discard_command_when_Y_is_invalid(int y)
        {
            var toyRobot = new Robot();

            toyRobot.postion(1, y, Directionenum.South);

            Assert.IsNull( toyRobot.Y);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("A")]
        [DataRow("BB")]
        [DataRow("CCC")]
        public void Discard_command_when_direction_is_invalid(string direction)
        {
            var toyRobot = new Robot();

            toyRobot.postion(1, 2, direction);

            Assert.IsNull(toyRobot.F);
        }
    }
}