using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotModel;
using System;

namespace RobotTest
{
    [TestClass]
    public class MovementTest
    {
        [TestMethod]
        public void FinalLocationCorrectCase()
        {
            var testRoom = new Room(8, 8);
            Direction testStartingDirection = Direction.North;
            var testRobot = new Robot(testStartingDirection);
            int testStartingColumn = 4;
            int testStartingRow = 2;

            char[] testInstructions = "LFFRFFLF".ToCharArray();
            Tuple<int[], Direction> newMovement = testRobot.CalculateMove(testInstructions);

            int finalColumn = testStartingColumn + newMovement.Item1[0];
            int finalRow = testStartingRow - newMovement.Item1[1];
            Direction finalDirection = newMovement.Item2;

            Assert.IsTrue(finalDirection == Direction.West);
            Assert.IsTrue(finalColumn == 1);
            Assert.IsTrue(finalRow == 0);
        }

        [TestMethod]
        public void SecondFinalLocationCorrectCase()
        {
            var testRoom = new Room(9, 7);
            Direction testStartingDirection = Direction.East;
            var testRobot = new Robot(testStartingDirection);
            int testStartingColumn = 3;
            int testStartingRow = 6;

            char[] testInstructions = "FFRRFRLFF".ToCharArray();
            Tuple<int[], Direction> newMovement = testRobot.CalculateMove(testInstructions);

            int finalColumn = testStartingColumn + newMovement.Item1[0];
            int finalRow = testStartingRow - newMovement.Item1[1];
            Direction finalDirection = newMovement.Item2;

            Assert.IsTrue(finalDirection == Direction.West);
            Assert.IsTrue(finalColumn == 2);
            Assert.IsTrue(finalRow == 6);
        }


        [TestMethod]
        public void FinalLocationWrongCase()
        {
            var testRoom = new Room(8, 8);
            Direction testStartingDirection = Direction.North;
            var testRobot = new Robot(testStartingDirection);
            int testStartingColumn = 4;
            int testStartingRow = 2;

            char[] testInstructions = "LFFRFFLF".ToCharArray();
            Tuple<int[], Direction> newMovement = testRobot.CalculateMove(testInstructions);

            int finalColumn = testStartingColumn + newMovement.Item1[0];
            int finalRow = testStartingRow - newMovement.Item1[1];
            Direction finalDirection = newMovement.Item2;

            Assert.IsFalse(finalDirection == Direction.North);
            Assert.IsFalse(finalColumn == 3);
            Assert.IsFalse(finalRow == 2);
        }

        [TestMethod]
        public void SecondFinalLocationWrongCase()
        {
            var testRoom = new Room(3, 5);
            Direction testStartingDirection = Direction.North;
            var testRobot = new Robot(testStartingDirection);
            int testStartingColumn = 0;
            int testStartingRow = 3;

            char[] testInstructions = "FFRFFLF".ToCharArray();
            Tuple<int[], Direction> newMovement = testRobot.CalculateMove(testInstructions);

            int finalColumn = testStartingColumn + newMovement.Item1[0];
            int finalRow = testStartingRow - newMovement.Item1[1];
            Direction finalDirection = newMovement.Item2;

            Assert.IsFalse(finalDirection == Direction.South);
            Assert.IsFalse(finalColumn == 0);
            Assert.IsFalse(finalRow == 2);
        }
    }
}
