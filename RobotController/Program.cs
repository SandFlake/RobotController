using RobotModel;
using System;
using System.Linq;

namespace RobotController
{
    class Program
    {
        //Initialize variables 
        public static int roomColumnSize;
        public static int roomRowSize;
        public static int startingRow;
        public static int startingColumn;
        public static Direction startingDirection;
        public static char[] movingDirections;
        public static Room theRoom;
        public static Robot walle;

        static void Main(string[] args)
        {
            //Ask for room size input
            getBoardSize();

            //Initialize the room
            theRoom = new Room(roomColumnSize, roomRowSize);

            //Print empty room
            printRoom();

            //Ask for robot starting position
            getRobotStartingPosition();

            //Print room with robot in starting position
            printRoomWithStartingPosition();

            //Initialize robot with initial direction from movement instructions
            walle = new Robot(startingDirection);

            //Ask for robot movement instructions
            getRobotDirections();

            //Calculate where the robot will end up after having followed the movement instructions
            Tuple<int[], Direction> newMovement = walle.CalculateMove(movingDirections);

            //Print room with robot in final position
            printFinalLocation(newMovement);

            Console.WriteLine("Thank you for using the Robot Controller. Have a nice day!");
            Console.ReadLine();
        }

        private static void getBoardSize()
        {
            Console.WriteLine("Welcome! Please enter 2 numbers, separated by a space, to set the size of the room.");

            //Read the input from the user and check if it is in a valid format. If it is not, keep asking the user for a new input.
            var firstInput = Console.ReadLine();
            bool isEmpty = string.IsNullOrEmpty(firstInput);
            bool isCorrectLength = firstInput.Split().Length == 2;
            var numbersString = firstInput.Split();
            int firstInt = 0;
            int secondInt = 0;
            bool secondValueIsInt = false;
            bool firstValueIsInt = (int.TryParse(numbersString[0], out firstInt));
            if (numbersString.Length == 2)
            {
                secondValueIsInt = (int.TryParse(numbersString[1], out secondInt));
            }

            bool validInput = !isEmpty && isCorrectLength && firstValueIsInt && secondValueIsInt;

            while (!validInput)
            {
                Console.WriteLine("The input you left was invalid. Please only leave input in the form of 2 numbers separated by a space.");

                firstInput = Console.ReadLine();
                isEmpty = string.IsNullOrEmpty(firstInput);
                isCorrectLength = firstInput.Split().Length == 2;
                numbersString = firstInput.Split();
                firstValueIsInt = (int.TryParse(numbersString[0], out firstInt));
                if (numbersString.Length > 1)
                {
                    secondValueIsInt = (int.TryParse(numbersString[1], out secondInt));
                }

                validInput = !isEmpty && isCorrectLength && firstValueIsInt && secondValueIsInt;
            }

            //If the input is valid, set the rows and columns of the room
            roomColumnSize = int.Parse(numbersString[0]);
            roomRowSize = int.Parse(numbersString[1]);
        }

        private static void printRoom()
        {
            //Print the room based on number of rows and columns
            for (int i = 0; i < theRoom.RowSize; i++)
            {
                for (int j = 0; j < theRoom.ColumnSize; j++)
                {
                    Field f = theRoom.theGrid[j, i];
                    Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        private static void getRobotStartingPosition()
        {
            Console.WriteLine("Please put in the robots starting position. 2 digits and a direction( N / E / S / W)");

            //Read the input from the user and check if it is in a valid format. If it is not, keep asking the user for a new input.
            var secondInput = Console.ReadLine();
            bool isEmpty = string.IsNullOrEmpty(secondInput);
            bool isCorrectLength = secondInput.Split().Length == 3;
            var inputArray = secondInput.Split();
            int firstInt = 0;
            int secondInt = 0;
            int thirdInt = 0;
            bool firstValueIsInt = (int.TryParse(inputArray[0], out firstInt));
            bool secondValueIsInt = false;
            bool thirdValueIsNotInt = false;
            bool startingColumnOutOfBounds = false;

            if (inputArray.Length == 3)
            {
                secondValueIsInt = (int.TryParse(inputArray[1], out secondInt));
                thirdValueIsNotInt = (!int.TryParse(inputArray[2], out thirdInt));
            }

            if (firstValueIsInt && secondValueIsInt)
            {
                startingColumnOutOfBounds = (firstInt < 0 || firstInt > roomColumnSize - 1 || secondInt < 0 || secondInt > roomRowSize - 1);
            }

            bool validInput = !isEmpty && isCorrectLength && firstValueIsInt && secondValueIsInt && thirdValueIsNotInt && !startingColumnOutOfBounds;

            while (!validInput)
            {
                Console.WriteLine("The input you left was invalid. Please only leave input in the form of 2 numbers and 1 letter separated by a space.");
                secondInput = Console.ReadLine();
                isEmpty = string.IsNullOrEmpty(secondInput);
                isCorrectLength = secondInput.Split().Length == 3;
                inputArray = secondInput.Split();
                firstValueIsInt = (int.TryParse(inputArray[0], out firstInt));
                if (inputArray.Length == 3)
                {
                    secondValueIsInt = (int.TryParse(inputArray[1], out secondInt));
                    thirdValueIsNotInt = (!int.TryParse(inputArray[2], out thirdInt));
                }

                if (firstValueIsInt && secondValueIsInt)
                {
                    startingColumnOutOfBounds = (firstInt < 0 || firstInt > roomColumnSize - 1 || secondInt < 0 || secondInt > roomRowSize - 1);
                }

                validInput = !isEmpty && isCorrectLength && firstValueIsInt && secondValueIsInt && thirdValueIsNotInt && !startingColumnOutOfBounds;
            }

            //If the input is valid, put the starting row, column and direction of the robot
            startingColumn = int.Parse(inputArray[0]);
            startingRow = int.Parse(inputArray[1]);
            var startingDirectionString = inputArray[2];

            switch (startingDirectionString)
            {
                case "N":
                    startingDirection = Direction.North;
                    break;
                case "E":
                    startingDirection = Direction.East;
                    break;
                case "S":
                    startingDirection = Direction.South;
                    break;
                case "W":
                    startingDirection = Direction.West;
                    break;
            }
        }

        private static void printRoomWithStartingPosition()
        {
            //Print the room with the starting position marked
            Field currentField = theRoom.theGrid[startingColumn, startingRow];
            currentField.CurrentlyOccupied = true;

            for (int i = 0; i < theRoom.RowSize; i++)
            {
                for (int j = 0; j < theRoom.ColumnSize; j++)
                {
                    Field f = theRoom.theGrid[j, i];

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
            currentField.CurrentlyOccupied = false;

        }


        private static void getRobotDirections()
        {
            Console.WriteLine("Please enter how you wish the robot to move. You can use R for turning right, L for turning left, and F for walking forward. In any combination you want");

            //Read the input from the user and check if it is in a valid format. If it is not, keep asking the user for a new input.
            var thirdInput = Console.ReadLine();
            bool isEmpty = string.IsNullOrEmpty(thirdInput);
            string[] illegalLetters = { "A", "B", "C", "D", "E", "G", "H", "I", "J", "K", "M", "N", "O", "P", "Q", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            bool containsIllegalCharacters = (illegalLetters.Any(thirdInput.ToUpper().Contains));
            bool valid = !isEmpty && !containsIllegalCharacters;

            while (!valid)
            {
                Console.WriteLine("You entered suspicious characters. Please only use R for turning right, L for turning left, and F for walking forward.");
                thirdInput = Console.ReadLine();
                isEmpty = string.IsNullOrEmpty(thirdInput);
                containsIllegalCharacters = (illegalLetters.Any(thirdInput.ToUpper().Contains));
                valid = !isEmpty && !containsIllegalCharacters;
            }

            //If the input is valid, set the movement instructions for the robot
            movingDirections = thirdInput.ToCharArray();
        }


        private static void printFinalLocation(Tuple<int[], Direction> newMovement)
        {
            //Set the final location of the robot. If the robot has landed outside the room, inform the user. 
            int finalColumn = startingColumn + newMovement.Item1[0];
            int finalRow = startingRow - newMovement.Item1[1];

            if (finalColumn < 0 || finalColumn > roomColumnSize || finalRow < 0 || finalRow > roomRowSize)
            {
                Console.WriteLine("Oops! Your robot landed outside of the room....");
            }
            else
            {
                Field currentField = theRoom.theGrid[finalColumn, finalRow];
                currentField.CurrentlyOccupied = true;

                for (int i = 0; i < theRoom.RowSize; i++)
                {
                    for (int j = 0; j < theRoom.ColumnSize; j++)
                    {
                        Field f = theRoom.theGrid[j, i];

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

                Console.WriteLine("You finished at " + finalColumn + " and " + finalRow + " facing direction " + newMovement.Item2);
            }

        }

    }
}
