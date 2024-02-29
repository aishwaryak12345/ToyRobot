using FakeItEasy;
using ToyRobot;
using Xunit;

namespace ToyRobottest
{
    [TestClass]
    public class SimulatorMove
    {
        [DataTestMethod]
        [DataRow("PLACE 0,0,NORTH", 0, 0, Directionenum.North)]
        [DataRow("PLACE 1,2,EAST", 1, 2, Directionenum.East)]
        [DataRow("PLACE 3,4,SOUTH", 3, 4, Directionenum.South)]
        [DataRow("PLACE 4,0,WEST", 4, 0, Directionenum.West)]
        public void Execute_Place_command(string command, int x, int y, string direction)
        {
            var toyRobot = A.Fake<Robot>();
            var simulator = new Simulator(toyRobot);

            simulator.ExecuteCommand(command);

            A.CallTo(() => toyRobot.postion(x, y, direction)).MustHaveHappened();
        }
        [TestMethod]
        [Fact]
        public void Execute_Move_command()
        {
            var toyRobot = A.Fake<Robot>();
            var simulator = new Simulator(toyRobot);
            toyRobot.postion(2, 2, Directionenum.North);

            simulator.ExecuteCommand("MOVE");

            A.CallTo(() => toyRobot.move()).MustHaveHappened();
        }
        [TestMethod]
        [Fact]
        public void Execute_Left_command()
        {
            var toyRobot = A.Fake<Robot>();
            var simulator = new Simulator(toyRobot);
            toyRobot.postion(2, 2, Directionenum.North);

            simulator.ExecuteCommand("LEFT");

            A.CallTo(() => toyRobot.Left()).MustHaveHappened();
        }
        [TestMethod]
        [Fact]
        public void Execute_Right_command()
        {
            var toyRobot = A.Fake<Robot>();
            var simulator = new Simulator(toyRobot);
            toyRobot.postion(2, 2, Directionenum.North);

            simulator.ExecuteCommand("RIGHT");

            A.CallTo(() => toyRobot.Right()).MustHaveHappened();
        }
        [TestMethod]
        [Fact]
        public void Execute_Report_command()
        {
            var toyRobot = A.Fake<Robot>();
            var simulator = new Simulator(toyRobot);
            toyRobot.postion(2, 2, Directionenum.North);

            simulator.ExecuteCommand("REPORT");

            A.CallTo(() => toyRobot.Report()).MustHaveHappened();
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow("A")]
        [DataRow("BB")]
        [DataRow("CCC")]
        [DataRow("PLACE x,0,NORTH")]
        [DataRow("PLACE 1,x,EAST")]
        [DataRow("PLACE 11111111111111111111,0,SOUTH")]
        [DataRow("PLACE 0,222222222222222222222,WEST")]
        public void Ignore_invalid_commands(string command)
        {
            var toyRobot = A.Fake<Robot>();
            var simulator = new Simulator(toyRobot);

            simulator.ExecuteCommand(command);

            A.CallTo(() => toyRobot.postion(A<int>.Ignored, A<int>.Ignored, A<string>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => toyRobot.move()).MustNotHaveHappened();
            A.CallTo(() => toyRobot.Left()).MustNotHaveHappened();
            A.CallTo(() => toyRobot.Right()).MustNotHaveHappened();
            A.CallTo(() => toyRobot.Report()).MustNotHaveHappened();
        }
    }
}

