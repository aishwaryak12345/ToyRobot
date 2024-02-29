using System.Diagnostics.Metrics;
using ToyRobot;
using Xunit;

namespace ToyRobottest
{
    [TestClass]
   public class MoveShould
   {
        [TestMethod]
        [Fact]
    public void Move_North_when_facing_North()
    {
        var toyRobot = new Robot();
        toyRobot.postion(2, 2, Directionenum.North);

        toyRobot.move();

        Assert.AreEqual(2, toyRobot.X);
        Assert.AreEqual(3, toyRobot.Y);
    }

    [TestMethod]
    [Fact]
    public void Move_East_when_facing_East()
    {
        var toyRobot = new Robot();
        toyRobot.postion(2, 2, Directionenum.East);

        toyRobot.move();

         Assert.AreEqual(2, toyRobot.X);
         Assert.AreEqual(2, toyRobot.Y);
        }
    [TestMethod]
    [Fact]
    public void Move_South_when_facing_South()
    {
        var toyRobot = new Robot();
        toyRobot.postion(2, 2, Directionenum.South);

        toyRobot.move();

        Assert.AreEqual(2, toyRobot.X);
        Assert.AreEqual(1, toyRobot.Y);
        }
    [TestMethod]
    [Fact]
    public void Move_West_when_facing_West()
    {
        var toyRobot = new Robot();
        toyRobot.postion(2, 2, Directionenum.West);

        toyRobot.move();

        Assert.AreEqual(1, toyRobot.X);
        Assert.AreEqual(2, toyRobot.Y);
    }

    [DataTestMethod]
    [DataRow(4, 4, Directionenum.North)]
    [DataRow(4, 4, Directionenum.East)]
    [DataRow(0, 0, Directionenum.South)]
    [DataRow(0, 0, Directionenum.West)]

        public void Not_cause_the_robot_to_fall_outside_the_table(int x, int y, string direction)
        {
            var toyRobot = new Robot();
            toyRobot.postion(x, y, direction);

            toyRobot.move();

            Assert.AreEqual(x, toyRobot.X);
            Assert.AreEqual(y, toyRobot.Y);
        }
    }
}
