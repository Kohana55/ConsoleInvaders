using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    internal class Player
    {

        public int X;
        public int Y;

        /// <summary>
        /// Player Model
        /// </summary>
        public Cell[] model =
        {   new Cell (0, 0, "/"),
            new Cell (1, 0, "-"),
            new Cell (2, 0, "^"),
            new Cell (3, 0, "-"),
            new Cell (4, 0, "\\")
        };

        private BallisticManager ballisticManager;


        /// <summary>
        /// Standard Ctor - must provide starting Y-Axis of player
        /// </summary>
        /// <param name="y"></param>
        public Player(int y)
        {
            foreach (Cell cell in model)
            {
                cell.X += 30;
                cell.Y += y;
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
                    if (model[0].X == 0)
                        continue;

                    // Move each Cell in the players model, Left
                    foreach (Cell cell in model)
                        cell.X -= 1;
                }

                // Move Right
                if (keypress.KeyChar == 'd')
                {
                    // Bumper to ensure we don't fall out of the array bounds
                    if (model[4].X == X-1)
                        continue;

                    // Move each Cell in the players model, Right
                    foreach (Cell cell in model)
                        cell.X += 1;
                }

                // Shoot
                if (keypress.KeyChar == ' ')
                {
                    ballisticManager.RegisterProjectile(new Projectile(model[2].X, model[2].Y - 1, -1));
                }
            }
        }
    }
}
