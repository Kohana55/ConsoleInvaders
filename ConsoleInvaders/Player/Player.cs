using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Player
    {

        public int X;
        public int Y;

        /// <summary>
        /// Player Model
        /// </summary>
        public Cell[] model =
        {   new Cell (0, 0, "/"),
            new Cell (0, 1, "-"),
            new Cell (0, 2, "^"),
            new Cell (0, 3, "-"),
            new Cell (0, 4, "\\")
        };

        private BallisticManager ballisticManager;


        /// <summary>
        /// Standard Ctor - must provide starting X-Axis of player
        /// </summary>
        /// <param name="x"></param>
        public Player(int x)
        {
            foreach (Cell cell in model)
            {
                cell.X += x;
                cell.Y += 30;
                cell.isRigid = true;
            }
        }

        /// <summary>
        /// Register the BallisticManager with the player
        /// so they can register projectiles with it
        /// </summary>
        /// <param name="argBallisticManager"></param>
        public void RegisterBallisticManager(BallisticManager argBallisticManager)
        {
            ballisticManager = argBallisticManager;
        }

        /// <summary>
        /// Player controller method
        /// To be run in own thread
        /// </summary>
        public void Controller()
        {
            ConsoleKeyInfo keypress;

            while(true)
            {
                // Grab Player input
                keypress = Console.ReadKey(true);

                // Move Left
                if (keypress.KeyChar == 'a')
                {
                    // Bumper to ensure we don't fall out of the array bounds
                    if (model[0].Y == 0)
                        continue;

                    // Move each Cell in the players model, Left
                    foreach (Cell cell in model)
                        cell.Y -= 1;
                }

                // Move Right
                if (keypress.KeyChar == 'd')
                {
                    // Bumper to ensure we don't fall out of the array bounds
                    if (model[4].Y == Y-1)
                        continue;

                    // Move each Cell in the players model, Right
                    foreach (Cell cell in model)
                        cell.Y += 1;
                }

                // Shoot
                if (keypress.KeyChar == ' ')
                {
                    ballisticManager.RegisterProjectile(new Projectile(model[2].X - 1, model[2].Y, -1));
                }
            }
        }
    }
}
