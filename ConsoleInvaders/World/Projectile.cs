using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Projectile
    {

        public Cell Model = new Cell(0,0,"!");
        private int Direction;

        public bool collision = false;

        /// <summary>
        /// Ctor must take X and Y transform
        /// Direction 
        /// -1 == North
        /// 1 == South 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        public Projectile(int x, int y, int direction)
        {
            Model.X = x;
            Model.Y = y;
            Model.isRigid = true;
            Direction = direction;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Update()
        {
            if (Model.X == 0)
                collision = true;
            else
                Model.X += Direction;
        }
    }
}
