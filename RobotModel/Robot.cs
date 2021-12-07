using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RobotModel.Robot;

namespace RobotModel
{
    public class Robot
    {
        public Direction direction;
        public int rowNumber;
        public int columnNumber;
        public int[] finalCoordinates;

        public Robot(Direction _direction)
        {
            direction = _direction;
        }

        public Tuple<int[], Direction> CalculateMove(char[] instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.ToString().ToUpper() == "R")
                {
                    switch (direction)
                    {
                        case Direction.North:
                            direction = Direction.East;
                            break;
                        case Direction.East:
                            direction = Direction.South;
                            break;
                        case Direction.South:
                            direction = Direction.West;
                            break;
                        case Direction.West:
                            direction = Direction.North;
                            break;
                    }
                }
                else if (instruction.ToString().ToUpper() == "L")
                {
                    switch (direction)
                    {
                        case Direction.North:
                            direction = Direction.West;
                            break;
                        case Direction.West:
                            direction = Direction.South;
                            break;
                        case Direction.South:
                            direction = Direction.East;
                            break;
                        case Direction.East:
                            direction = Direction.North;
                            break;
                    }
                }
                else if (instruction.ToString().ToUpper() == "F")
                {
                    switch (direction)
                    {
                        case Direction.North:
                            rowNumber += 1;
                            break;
                        case Direction.East:
                            columnNumber += 1;
                            break;
                        case Direction.South:
                            rowNumber -= 1;
                            break;
                        case Direction.West:
                            columnNumber -= 1;
                            break;
                    }
                }

            }

            return new Tuple<int[], Direction>(new[] { columnNumber, rowNumber }, direction);

        }
    }
}

