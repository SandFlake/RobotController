using RobotModel;
using System;
using System.Linq;

namespace RobotController
{
    class Program
    {

        static void Main(string[] args)
        {
            //Ask for room size input
            string[] roomSize = getBoardSize();
            Room robotsRoom = new Room(0, 0);
            robotsRoom.setRowAndColumn(roomSize);

            //Print empty room
            printRoom(roomSize);

            //Ask for robot starting position
            string[] startingPosition = getRobotStartingPosition();

            //Print room with robot in starting position
            Direction robotDirection = printRoomWithStartingPosition(roomSize, startingPosition);

            //Ask for robot movement instructions
            char[] movingDirections = getRobotDirections();

            //Initialize robot with initial direction from movement instructions
            Robot walle = new Robot(robotDirection);

            //Calculate where the robot will end up after having followed the movement instructions
            Tuple<int[], Direction> newMovement = walle.CalculateMove(movingDirections);

            //Print room with robot in final position
            printFinalLocation(roomSize, startingPosition, newMovement);

            Console.ReadLine();
        }

        private static void printFinalLocation(string[] roomSize, string[] startingPosition, Tuple<int[], Direction> newMovement)
        {
            int startingRow;
            int startingColumn;
            startingColumn = int.Parse(startingPosition[0]);
            startingRow = int.Parse(startingPosition[1]);

            int minusColumn = newMovement.Item1[0];
            int minusRow = newMovement.Item1[1];

            int finalColumn = startingColumn + minusColumn;
            int finalRow = startingRow - minusRow;

            Console.WriteLine("You finished at " + finalColumn + " and " + finalRow + " facing direction " + newMovement.Item2);

            int roomRowSize;
            int roomColumnSize;

            roomColumnSize = int.Parse(roomSize[0]);
            roomRowSize = int.Parse(roomSize[1]);

            Room myRoom = new Room(roomColumnSize, roomRowSize);

            Field currentField = myRoom.theGrid[finalColumn, finalRow];
            currentField.CurrentlyOccupied = true;

            for (int i = 0; i < myRoom.RowSize; i++)
            {
                for (int j = 0; j < myRoom.ColumnSize; j++)
                {
                    Field f = myRoom.theGrid[j, i];

                    if (f.CurrentlyOccupied == true)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(".");
                    }

                }
                Console.WriteLine();
            }

        }

        private static char[] getRobotDirections()
        {
            Console.WriteLine("Please enter how you wish the robot to move. You can use R for turning right, L for turning left, and F for walking forward. In any combination you want");
            var thirdOutput = Console.ReadLine();
            var thirdInputArray = thirdOutput.ToCharArray();

            return thirdInputArray;
        }

        private static Direction printRoomWithStartingPosition(string[] roomSize, string[] startingPosition)
        {
            int startingRow;
            int startingColumn;
            var startingDirection = "";
            startingColumn = int.Parse(startingPosition[0]);
            startingRow = int.Parse(startingPosition[1]);
            startingDirection = startingPosition[2];
            Direction robotDirection = Direction.North;


            switch (startingDirection)
            {
                case "N":
                    robotDirection = Direction.North;
                    break;
                case "E":
                    robotDirection = Direction.East;
                    break;
                case "S":
                    robotDirection = Direction.South;
                    break;
                case "W":
                    robotDirection = Direction.West;
                    break;
            }

            int roomRowSize;
            int roomColumnSize;

            roomColumnSize = int.Parse(roomSize[0]);
            roomRowSize = int.Parse(roomSize[1]);

            Room myRoom = new Room(roomColumnSize, roomRowSize);

            Field currentField = myRoom.theGrid[startingColumn, startingRow];
            currentField.CurrentlyOccupied = true;

            for (int i = 0; i < myRoom.RowSize; i++)
            {
                for (int j = 0; j < myRoom.ColumnSize; j++)
                {
                    Field f = myRoom.theGrid[j, i];

                    if (f.CurrentlyOccupied == true)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(".");
                    }

                }
                Console.WriteLine();
            }

            return robotDirection;
        }

        private static string[] getRobotStartingPosition()
        {

            Console.WriteLine("Please put in the robots starting position. 2 digits and a direction( N / E / S / W)");

            var secondInput = Console.ReadLine();
            var inputArray = secondInput.Split();

            return inputArray;
        }


        private static void printRoom(string[] roomSize)
        {
            int roomRowSize;
            int roomColumnSize;

            roomColumnSize = int.Parse(roomSize[0]);
            roomRowSize = int.Parse(roomSize[1]);

            Room myRoom = new Room(roomColumnSize, roomRowSize);

            for (int i = 0; i < myRoom.RowSize; i++)
            {
                for (int j = 0; j < myRoom.ColumnSize; j++)
                {
                    Field f = myRoom.theGrid[j, i];
                    Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        private static string[] getBoardSize()
        {
            Console.WriteLine("Welcome! Please enter 2 numbers, separated by a space, to set the size of the room.");

            var firstInput = Console.ReadLine();
            bool isEmpty = string.IsNullOrEmpty(firstInput);
            bool isLongerThan2Integers = firstInput.Split().Length > 3;
            var numbersString = firstInput.Split();
            int firstInt = 0;
            bool isNotInt = (!int.TryParse(numbersString[0], out firstInt));
            bool validInput = !isEmpty && !isLongerThan2Integers && !isNotInt;

            while (!validInput)
            {
                Console.WriteLine("The input you left was invalid. Please only leave input in the form of 2 numbers separated by a space");
                firstInput = Console.ReadLine();
                isEmpty = string.IsNullOrEmpty(firstInput);
                isLongerThan2Integers = firstInput.Split().Length > 2;
                numbersString = firstInput.Split();
                isNotInt = (!int.TryParse(numbersString[0], out firstInt));
                validInput = !isEmpty && !isLongerThan2Integers && !isNotInt;
            }

            return numbersString;

        }
    }
}
