# Toy Robot Simulation Unit Tests

This repository contains unit tests for the Toy Robot Simulation application, focusing on verifying the correct behavior of the `Robot` class.

## Table of Contents

- [Overview](#overview)
- [Test Cases](#test-cases)
- [How to Run the Tests](#how-to-run-the-tests)
- [Additional Information](#additional-information)

## Overview

The unit tests are designed to validate the functionality of the `Robot` class within the Toy Robot Simulation application. These tests cover movement, rotation, and integration scenarios to ensure the robot behaves as expected.

## Test Cases

### 1. TestRobotMovement

This test checks if the robot moves correctly in the specified direction.

```csharp
[TestMethod]
public void TestRobotMovement()
{
    // Arrange
    Tabletop tabletop = new Tabletop();
    Robot robot = new Robot(tabletop);

    // Act
    robot.Place(0, 0, "NORTH");
    robot.Move();
    string result = robot.Report();

    // Assert
    Assert.AreEqual("0,1,NORTH", result);
}
