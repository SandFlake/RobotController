using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotTests
{
    [TestClass]
    public class MovementTests
    {
        [TestMethod]
        public void MoveCorrectlyCase()
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

            Assert.IsTrue(finalDirection == Direction.North);
            Assert.IsTrue(finalColumn == 3);
            Assert.IsTrue(finalRow == 2);


        }
    }
}
