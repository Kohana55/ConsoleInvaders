using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    public class Cell
    {
        /// <summary>
        /// Coords of the cell
        /// </summary>
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// To be rendered
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// For collision detection
        /// Set by the Contents propety
        /// </summary>
        public bool isRigid{ get; set; }

        /// <summary>
        /// Ctor for Cell must setup the Cells
        /// initial state
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="contents"></param>
        public Cell(int x, int y, string contents = " ")
        {
            X = x;
            Y = y;
            Contents = contents;
        }
    }
}
