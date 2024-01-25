using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ToyRobotStimulation;

namespace ToyRobotStimulationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRobotMovement()
        {
            Tabletop tabletop = new Tabletop();
            Robot robot = new Robot(tabletop);

            robot.Place(0, 0, "NORTH");
            robot.Move();
            string result = robot.Report();

            Assert.AreEqual("0,1,NORTH", result);
        }

        [TestMethod]
        public void TestRobotRotation()
        {
            Tabletop tabletop = new Tabletop();
            Robot robot = new Robot(tabletop);

            robot.Place(0, 0, "NORTH");
            robot.Left();
            string resultLeft = robot.Report();

            robot.Place(0, 0, "NORTH");
            robot.Right();
            string resultRight = robot.Report();

            Assert.AreEqual("0,0,WEST", resultLeft);
            Assert.AreEqual("0,0,EAST", resultRight);
        }

        [TestMethod]
        public void TestRobotIntegration()
        {
            Tabletop tabletop = new Tabletop();
            Robot robot = new Robot(tabletop);

            ExecuteCommands(robot, new string[]
            {
                "PLACE 0,0,NORTH",
                "MOVE",
                "REPORT"
            }, out string result);

            Assert.AreEqual("0,1,NORTH", result);
        }


        private void ExecuteCommands(Robot robot, string[] commands, out string result)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                foreach (var command in commands)
                {
                    ProcessCommand(robot, command);
                }

                result = sw.ToString().Trim();
            }
        }

        private void ProcessCommand(Robot robot, string command)
        {
            var parts = command.Split(" ");
            switch (parts[0])
            {
                case "PLACE":
                    var placeArgs = parts[1].Split(",");
                    robot.Place(int.Parse(placeArgs[0]), int.Parse(placeArgs[1]), placeArgs[2]);
                    break;
                case "MOVE":
                    robot.Move();
                    break;
                case "LEFT":
                    robot.Left();
                    break;
                case "RIGHT":
                    robot.Right();
                    break;
                case "REPORT":
                    Console.WriteLine(robot.Report());
                    break;
            }
        }
    }
}
  
