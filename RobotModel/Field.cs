using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotModel
{
    public class Field
    {
        public int RowNumber { get; set; }

        public int ColumnNumber { get; set; }

        public bool CurrentlyOccupied { get; set; }

        public Field(int x, int y)
        {
            RowNumber = x;
            ColumnNumber = y;
        }
    }
}
