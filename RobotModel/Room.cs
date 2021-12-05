using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotModel
{
    public class Room
    {
        public int RowSize { get; set; }
        public int ColumnSize { get; set; }

        public Field[,] theGrid { get; set; }

        public Room(int r, int c)
        {
            RowSize = r;
            ColumnSize = c;

            theGrid = new Field[r, c];

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    theGrid[i, j] = new Field(i, j);
                }
            }
        }

        public bool isSafe(int x, int y)
        {
            if (x < 0 || x >= RowSize || y < 0 || y >= ColumnSize)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
