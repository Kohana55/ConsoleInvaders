using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleInvaders
{
    internal class Invaders
    {
        public List<BaseInvader> Enemies = new List<BaseInvader>();
        public int LeftBound;
        public int RightBound;

        private readonly Cell _leftBoundCell;
        private readonly Cell _rightBoundCell;
        private readonly int _invadersPerRow = 14;

        /// <summary>
        /// Direction is += onto the invaders Y coord.
        /// 1 = Right
        /// -1 = Left
        /// Flip its value to change direction
        /// </summary>
        private int direction = 1;
        private bool drop = false;

        /// <summary>
        /// Invaders Ctor - Holds & Controls the Invader fleet
        /// </summary>
        public Invaders()
        {
            for (var i = 0; i < _invadersPerRow; i++)
            {
                Enemies.Add(new Galactica(5 + (3 * i), 9));
                Enemies.Add(new Galactica(5 + (3 * i), 8));
                Enemies.Add(new Serenity(5 + (3 * i), 7));
                Enemies.Add(new Serenity(5 + (3 * i), 6));
                Enemies.Add(new Deadalus(5 + (3 * i), 5));
            }

            // Grab reference to left most and right most cells of any row
            _leftBoundCell = Enemies.First().Model.First();

            _rightBoundCell = Enemies.Last().Model.Last();
        }

        /// <summary>
        /// Invader controller method
        /// To be run in own thread
        /// </summary>
        public void Update()
        {
            Thread animationThread = new Thread(Animate);
            animationThread.Start();

            while (true)
            {
                Enemies.RemoveAll(x => x.Dead);
                UpdateDirectionAndDrop();
                Move();

                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// Updates all Invader's positions
        /// </summary>
        private void Move()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (drop)
                {
                    Enemies[i].Drop();
                }
                else
                {
                    Enemies[i].Move(direction);
                }
            }

            drop = false;
        }

        /// <summary>
        /// Animate the Invaders
        /// </summary>
        private void Animate()
        {
            while (true)
            {
                for (int i = 0; i < Enemies.Count(); i++)
                {
                    Enemies[i].Animate();
                }

                Thread.Sleep(250);
            }
        }

        /// <summary>
        /// Updates direction of Invaders
        /// rightBoundCell and leftBoundCell are fields set during the Ctor
        /// </summary>
        private void UpdateDirectionAndDrop()
        {
            // Update direction 
            if (direction == 1 && _rightBoundCell.X == RightBound - 1)
            {
                direction = -1;
                drop = true;
            }
            else if (direction == -1 && _leftBoundCell.X == 0)
            {
                direction = 1;
                drop = true;
            }
        }
    }
}
