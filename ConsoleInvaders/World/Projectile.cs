﻿namespace ConsoleInvaders
{
    class Projectile
    {

        public Cell Model = new Cell(0, 0, "!");
        public bool Collision = false;

        private readonly int _direction;

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
            _direction = direction;
        }

        public void Update()
        {
            if (Model.Y == 0)
            {
                Collision = true;
            }
            else
            {
                Model.Y += _direction;
            }
        }
    }
}
