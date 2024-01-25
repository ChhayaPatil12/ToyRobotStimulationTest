using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ToyRobotStimulation;

namespace ToyRobotStimulationTest
{
    [TestClass]
    public class UnitTest1
    {
        // Test to ensure that the robot moves correctly on the tabletop
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

        // Test to check the robot's ability to rotate left and right correctly
        [TestMethod]
        public void TestRobotRotation()
        {
            Tabletop tabletop = new Tabletop();
            Robot robot = new Robot(tabletop);

            // Rotate left
            robot.Place(0, 0, "NORTH");
            robot.Left();
            string resultLeft = robot.Report();
            Assert.AreEqual("0,0,WEST", resultLeft);

            // Rotate right
            robot.Place(0, 0, "NORTH");
            robot.Right();
            string resultRight = robot.Report();
            Assert.AreEqual("0,0,EAST", resultRight);
        }

        // Test to check the integration of multiple commands
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

        // Test to check that the robot ignores commands when not placed on the tabletop
        //[TestMethod]
        //public void TestRobotIgnoredCommands()
        //{
        //    Tabletop tabletop = new Tabletop();
        //    Robot robot = new Robot(tabletop);

        //    // Trying to move, rotate, and report before placing the robot
        //    robot.Move();
        //    robot.Left();
        //    robot.Right();
        //    string resultBeforePlacement = robot.Report();

        //    // Place the robot and then check if the commands are executed
        //    robot.Place(2, 2, "EAST");
        //    robot.Move();
        //    robot.Left();
        //    robot.Right();
        //    string resultAfterPlacement = robot.Report();

        //    Assert.AreEqual("2,2,EAST", resultBeforePlacement);
        //    Assert.AreEqual("3,2,EAST", resultAfterPlacement);
        //}

        // Test to check that the robot ignores invalid PLACE commands
        //[TestMethod]
        //public void TestInvalidPlaceCommand()
        //{
        //    Tabletop tabletop = new Tabletop();
        //    Robot robot = new Robot(tabletop);

        //    // Invalid place command with incorrect arguments
        //    robot.Place(1, 1, "NORTH");
        //    robot.Place(1, 1, "INVALID_DIRECTION");
        //    string resultInvalidPlace = robot.Report();

        //    // Valid place command
        //    robot.Place(2, 2, "SOUTH");
        //    string resultValidPlace = robot.Report();

        //    Assert.AreEqual("1,1,NORTH", resultInvalidPlace);
        //    Assert.AreEqual("2,2,SOUTH", resultValidPlace);
        //}

        // Test to check that the robot ignores moves that would make it fall off the tabletop
        [TestMethod]
        public void TestAvoidFallingOffTabletop()
        {
            Tabletop tabletop = new Tabletop();
            Robot robot = new Robot(tabletop);

            // Place the robot at the edge of the tabletop facing NORTH
            robot.Place(0, 4, "NORTH");

            // Try to move, but it should not fall off the tabletop
            robot.Move();
            robot.Move();
            string result = robot.Report();

            Assert.AreEqual("0,4,NORTH", result);
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
