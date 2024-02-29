using ToyRobot;
using Xunit;

namespace ToyRobottest
{
    [TestClass]
    public class LeftMove
    {
        [DataTestMethod]
        [DataRow(Directionenum.North, Directionenum.West)]
        [DataRow(Directionenum.East, Directionenum.North)]
        [DataRow(Directionenum.South, Directionenum.East)]
        [DataRow(Directionenum.West, Directionenum.South)]
        public void Rotate_robot_left_90_degrees(string before, string after)
        {
            // Arrange
            var toyRobot = new Robot();
            toyRobot.postion(1, 1, before);

            // Act
            toyRobot.Left();

            // Assert
            Assert.AreEqual(after, toyRobot.F);
        }
    }
}
