using RobotModel;
using System;
using System.Linq;

namespace RobotController
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] roomSize = getBoardSize();
            printRoom(roomSize);
            string[] startingPosition = getRobotStartingPosition();
            printRoomWithStartingPosition(roomSize, startingPosition);
            Console.ReadLine();
        }

        private static void printRoomWithStartingPosition(string[] roomSize, string[] startingPosition)
        {
            int startingRow;
            int startingColumn;
            var startingDirection = "";
            startingRow = int.Parse(startingPosition[0]);
            startingColumn = int.Parse(startingPosition[1]);
            startingDirection = startingPosition[2];
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

            roomRowSize = int.Parse(roomSize[0]);
            roomColumnSize = int.Parse(roomSize[1]);

            Room myRoom = new Room(roomRowSize, roomColumnSize);

            for (int i = 0; i < myRoom.RowSize; i++)
            {
                for (int j = 0; j < myRoom.ColumnSize; j++)
                {
                    Field f = myRoom.theGrid[i, j];
                    Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        private static string[] getBoardSize()
        {
            Console.WriteLine("Hi. Please input 2 numbers, separated by a space, to set the size of the room.");

            var firstInput = Console.ReadLine();
            int firstInt;

            bool success;

            while (string.IsNullOrEmpty(firstInput))
            {
                Console.WriteLine("First input can't be empty. Please input 2 numbers.");
                firstInput = Console.ReadLine();
            }

            //while (!int.TryParse(firstInput, out firstInt))
            //{
            //    Console.WriteLine("Please enter whole numbers only, no letters or special characters.");
            //    firstInput = Console.ReadLine();
            //}

            var numbers = firstInput.Split();
            while (numbers.Length > 3)
            {
                Console.WriteLine("You can only enter 2 numbers. Please try again.");
                firstInput = Console.ReadLine();
                numbers = firstInput.Split();
            }





            return numbers;


            //var numberList = firstInput.Select(x => (int)char.GetNumericValue(x)).ToArray();
            //Console.WriteLine("You've put in: " + numberList[0] + " and " + numberList[1]);


        }
    }
}
