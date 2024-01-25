# Toy Robot Simulation

This repository contains a C# implementation of a toy robot simulation on a square tabletop. The simulation adheres to specific rules and constraints, including movement, rotation, and position reporting. Unit tests are included to ensure the correctness of the implemented functionalities.

## Table of Contents
- [Introduction](#introduction)
- [Implementation Details](#implementation-details)
- [Unit Tests](#unit-tests)
- [How to Run the Tests](#how-to-run-the-tests)

## Introduction

The toy robot simulation involves a robot moving on a tabletop with dimensions 5 units x 5 units. The robot can be placed on the table, moved, rotated, and its position can be reported. The implementation includes safeguards to prevent the robot from falling off the table.

## Implementation Details

The code is organized into two main classes: `Robot` and `Tabletop`. The `Robot` class represents the toy robot and contains methods for placing the robot on the tabletop, moving it, rotating it left or right, and reporting its current position. The `Tabletop` class represents the tabletop, providing information about its dimensions.

The `UnitTest1` class contains Microsoft Visual Studio unit tests to verify the correctness of the robot's movement, rotation, and integration of multiple commands.

## Unit Tests

### TestRobotMovement

This test verifies that the robot moves correctly on the tabletop. It places the robot at position (0, 0) facing NORTH, executes a move command, and then checks if the reported position is (0, 1, NORTH).

### TestRobotRotation

This test checks the robot's ability to rotate left and right correctly. It places the robot at position (0, 0) facing NORTH, executes left and right rotation commands separately, and checks if the reported positions are as expected.

### TestRobotIntegration

This test checks the integration of multiple commands. It places the robot at position (0, 0) facing NORTH, executes a sequence of commands (PLACE, MOVE, REPORT), and checks if the final reported position is as expected.

## How to Run the Tests

1. Clone the repository to your local machine:

```bash
git clone <repository_url>
cd ToyRobotSimulation
