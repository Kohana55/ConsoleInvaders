using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Invaders
    {

        /// <summary>
        /// Rows 1&2 of Invaders
        /// </summary>
        public Galactica[] row1Galacticas;
        public Galactica[] row2Galacticas;

        /// <summary>
        /// Rows 3&4 of Invaders
        /// </summary>
        public Serenity[] row3Serenties;
        public Serenity[] row4Serenties;

        /// <summary>
        /// Row 5 of Invaders
        /// </summary>
        public Deadalus[] row5Deadalus;

        public int leftBound;
        public int rightBound;
        private Cell leftBoundCell;
        private Cell rightBoundCell;

        private readonly int numberOfInvaders = 14;

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
            row1Galacticas = new Galactica[numberOfInvaders];
            row2Galacticas = new Galactica[numberOfInvaders];
            int offset = 0;
            for (int i = 0; i < numberOfInvaders; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    row1Galacticas[i] = new Galactica(9, (5 + offset) + j);
                    row2Galacticas[i] = new Galactica(8, (5 + offset) + j);
                }
                offset += 3;
            }

            row3Serenties = new Serenity[numberOfInvaders];
            row4Serenties = new Serenity[numberOfInvaders];
            offset = 0;
            for (int i = 0; i < numberOfInvaders; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    row3Serenties[i] = new Serenity(7, (5 + offset) + j);
                    row4Serenties[i] = new Serenity(6, (5 + offset) + j);
                }
                offset += 3;
            }

            row5Deadalus = new Deadalus[numberOfInvaders];
            offset = 0;
            for (int i = 0; i < numberOfInvaders; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    row5Deadalus[i] = new Deadalus(5, (5 + offset) + j);
                }
                offset += 3;
            }

            // Grab reference to left most and right most cells of any row
            rightBoundCell = row1Galacticas[row1Galacticas.Length - 1].Model[2];
            leftBoundCell = row1Galacticas[0].Model[0];
        }

        /// <summary>
        /// Invader controller method
        /// To be run in own thread
        /// </summary>
        public void Controller()
        {
            Thread animationThread = new Thread(Animate);
            animationThread.Start();

            while(true)
            {
                UpdateDirectionAndDrop();
                Update();

                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// Updates all Invader's positions & animations
        /// </summary>
        private void Update()
        {
            for (int i = 0; i < row1Galacticas.Length; i++)
            {
                if (drop)
                {
                    row1Galacticas[i].Drop();
                    row2Galacticas[i].Drop();
                    row3Serenties[i].Drop();
                    row4Serenties[i].Drop();
                    row5Deadalus[i].Drop();
                }
                else
                {
                    row1Galacticas[i].Move(direction);
                    row2Galacticas[i].Move(direction);
                    row3Serenties[i].Move(direction);
                    row4Serenties[i].Move(direction);
                    row5Deadalus[i].Move(direction);
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
                for (int i = 0; i < row1Galacticas.Length; i++)
                {
                    row1Galacticas[i].Animate();
                    row2Galacticas[i].Animate();
                    row3Serenties[i].Animate();
                    row4Serenties[i].Animate();
                    row5Deadalus[i].Animate();
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
            if (direction == 1 && rightBoundCell.Y == rightBound - 1)
            {
                direction = -1;
                drop = true;
            }
            else if (direction == -1 && leftBoundCell.Y == 0)
            {
                direction = 1;
                drop = true;
            }
        }
    }
}
