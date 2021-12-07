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

        public Room(int c, int r)
        {
            ColumnSize = c;
            RowSize = r;

            theGrid = new Field[c, r];

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    theGrid[j, i] = new Field(j, i);
                }
            }
        }

    }
}
