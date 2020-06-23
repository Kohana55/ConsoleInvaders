using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Serenity
    {
        public Cell[] Model =
        {
            new Cell(0,0,"_"),
            new Cell(0,1,"o"),
            new Cell(0,2,"-")
        };

        /// <summary>
        /// Standard Ctor - Must input transform coords of ship
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Serenity(int x, int y)
        {
            foreach (Cell cell in Model)
            {
                cell.X += x;
                cell.Y += y;
                cell.isRigid = true;
            }
        }

        /// <summary>
        /// Call each frame to animate Invader
        /// </summary>
        public void Animate()
        {
            if (Model[0].Contents == "_")
            {
                Model[0].Contents = "-";
                Model[2].Contents = "_";
            }
            else
            {
                Model[0].Contents = "_";
                Model[2].Contents = "-";
            }
        }

        /// <summary>
        /// Transforms each cell in a Galatica model by X
        /// </summary>
        /// <param name="x"></param>
        public void Move(int x)
        {
            foreach (Cell cell in Model)
                cell.Y += x;
        }

        /// <summary>
        /// Drops each cell down the X-Axis
        /// </summary>
        public void Drop()
        {
            foreach (Cell cell in Model)
                cell.X -= -1;
        }
    }
}
