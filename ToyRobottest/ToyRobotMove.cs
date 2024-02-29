using ToyRobot;
using Xunit;

namespace ToyRobottest
{
    [TestClass]
    public class ToyRobotMove
    {
        [TestMethod]
        [Fact]
        public void Discard_Move_command_when_the_robot_was_not_placed_on_the_table()
        {
            var toyRobot = new Robot();

            toyRobot.move();

            Assert.AreEqual(null,toyRobot.X);
            Assert.AreEqual(null, toyRobot.Y);
            Assert.AreEqual(null, toyRobot.F);
        }
        [TestMethod]
        [Fact]
        public void Discard_Left_command_when_the_robot_was_not_placed_on_the_table()
        {
            var toyRobot = new Robot();

            toyRobot.Left();

            Assert.AreEqual(null, toyRobot.X);
            Assert.AreEqual(null, toyRobot.Y);
            Assert.AreEqual(null, toyRobot.F);
        }
        [TestMethod]
        [Fact]
        public void Discard_Right_command_when_the_robot_was_not_placed_on_the_table()
        {
            var toyRobot = new Robot();

            toyRobot.Right();

            Assert.AreEqual(null, toyRobot.X);
            Assert.AreEqual(null, toyRobot.Y);
            Assert.AreEqual(null, toyRobot.F);
        }
        [TestMethod]
        [Fact]
        public void Discard_Report_command_when_the_robot_was_not_placed_on_the_table()
        {
            var toyRobot = new Robot();

            var result = toyRobot.Report();

            Assert.AreEqual(null, result);
        }
    }
}
