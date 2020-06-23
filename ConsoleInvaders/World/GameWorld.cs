using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class GameWorld
    {
        public int X = 25;
        public int Y = 60;

        private Cell[,] board;
        private Player player;
        private Invaders invaders;
        private DefenceStructure[] structures;
        private BallisticManager ballisticManager;

        /// <summary>
        /// Standard Ctor
        /// </summary>
        public GameWorld()
        {
            board = new Cell[X, Y];
            InitiateGameBoard();
            InitiateDefence();
        }

        /// <summary>
        /// Initiate a blank board of constructed Cells
        /// </summary>
        private void InitiateGameBoard()
        {
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    board[i, j] = new Cell(i, j);
                }
            }
        }

        /// <summary>
        /// Initiate the Defence Structures
        /// </summary>
        private void InitiateDefence()
        {
            structures = new DefenceStructure[4];
            int structureOffset = 6;
            for (int i = 0; i < 4; i++)
            {
                structures[i] = new DefenceStructure(X - 7, structureOffset);
                structureOffset += 14;
            }
        }

        /// <summary>
        /// Return contents of a cell
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public string GetCellContents(int x, int y)
        {
            return board[x, y].Contents;
        }

        /// <summary>
        /// Register the Player with the game world
        /// </summary>
        /// <param name="argPlayer"></param>
        public void RegisterPlayer(Player argPlayer)
        {
            player = argPlayer;
            player.X = X;
            player.Y = Y;
        }

        /// <summary>
        /// Register the Space Invaders with the game world
        /// </summary>
        /// <param name="invaders"></param>
        public void RegisterInvaders(Invaders argInvaders)
        {
            invaders = argInvaders;
            invaders.leftBound = X;
            invaders.rightBound = Y;
        }

        /// <summary>
        /// Register the BallisticManager with the game world
        /// </summary>
        /// <param name="argBallisticManager"></param>
        public void RegisterBallisticManager(BallisticManager argBallisticManager)
        {
            ballisticManager = argBallisticManager;
        }

        /// <summary>
        /// Update the GameWorld
        /// </summary>
        public void Update()
        {
            InitiateGameBoard();
            UpdatePlayerPosition();
            UpdateInvadersPosition();
            UpdateStructures();
            UpdateBallistics();
        }

        /// <summary>
        /// Updates the GameWorld with current Player position
        /// </summary>
        private void UpdatePlayerPosition()
        {
            foreach(Cell cell in player.model)
            {
                board[cell.X, cell.Y] = cell;
            }
        }

        /// <summary>
        /// Updates the GameWorld with current Invaders position
        /// </summary>
        private void UpdateInvadersPosition()
        {
            // Galacticas
            for (int i = 0; i < invaders.row1Galacticas.Length; i++)
            {
                foreach (Cell cell in invaders.row1Galacticas[i].Model)
                {
                    board[cell.X, cell.Y] = cell;
                }
                foreach (Cell cell in invaders.row2Galacticas[i].Model)
                {
                    board[cell.X, cell.Y] = cell;
                }
                foreach (Cell cell in invaders.row3Serenties[i].Model)
                {
                    board[cell.X, cell.Y] = cell;
                }
                foreach (Cell cell in invaders.row4Serenties[i].Model)
                {
                    board[cell.X, cell.Y] = cell;
                }
                foreach (Cell cell in invaders.row5Deadalus[i].Model)
                {
                    board[cell.X, cell.Y] = cell;
                }
            }
        }

        /// <summary>
        /// Updates the GameWorld with current Ballistic Cells
        /// </summary>
        private void UpdateBallistics()
        {
            foreach (Projectile projectile in ballisticManager.Projectiles)
            {
                board[projectile.Model.X, projectile.Model.Y] = projectile.Model;
            }
        }

        /// <summary>
        /// Updates the GameWorld with current state of Structures
        /// </summary>
        private void UpdateStructures()
        {
            for (int i = 0; i < 4; i++)
            {
                foreach (Cell cell in structures[i].Model)
                {
                    board[cell.X, cell.Y] = cell;
                }
            }
        }
    }
}
