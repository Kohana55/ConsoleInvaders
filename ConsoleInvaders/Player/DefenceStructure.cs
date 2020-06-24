using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    internal class DefenceStructure
    {
        public Cell[] Model =
        {
            new Cell(2,0,"#"),
            new Cell(3,0,"#"),
            new Cell(4,0,"#"),

            new Cell(1,1,"#"),
            new Cell(2,1,"#"),
            new Cell(3,1,"#"),
            new Cell(4,1,"#"),
            new Cell(5,1,"#"),

            new Cell(0,2,"#"),
            new Cell(1,2,"#"),
            new Cell(2,2,"#"),
            new Cell(3,2,"#"),
            new Cell(4,2,"#"),
            new Cell(5,2,"#"),
            new Cell(6,2,"#"),

            new Cell(0,3,"#"),
            new Cell(1,3,"#"),

            new Cell(5,3,"#"),
            new Cell(6,3,"#")
        };

        /// <summary>
        /// Standard Ctor - Must take structure transform coords
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public DefenceStructure(int x, int y)
        {
            foreach(Cell cell in Model)
            {
                cell.X += x;
                cell.Y += y;
                cell.isRigid = true;
            }
        }


    }
}
