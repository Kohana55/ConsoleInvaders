using System.Linq;

namespace ConsoleInvaders
{
    class GameWorld
    {
        public int X = 60;
        public int Y = 25;

        private Cell[,] _board;
        private Player _player;
        public Invaders _invaders;
        public DefenceStructure[] _structures;
        private BallisticManager _ballisticManager;

        /// <summary>
        /// Standard Ctor
        /// </summary>
        public GameWorld()
        {
            _board = new Cell[X, Y];
            InitiateGameBoard();
            InitiateDefence();
        }

        /// <summary>
        /// Initiate a blank board of constructed Cells
        /// </summary>
        private void InitiateGameBoard()
        {
            for (int x = 0; x < X; x++)
            {
                for (int y = 0; y < Y; y++)
                {
                    _board[x, y] = new Cell(x, y);
                }
            }
        }

        /// <summary>
        /// Initiate the Defence Structures
        /// </summary>
        private void InitiateDefence()
        {
            _structures = new DefenceStructure[4];
            int structureOffset = 6;
            for (int i = 0; i < 4; i++)
            {
                _structures[i] = new DefenceStructure(structureOffset, Y - 7);
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
            return _board[x, y].Contents;
        }

        /// <summary>
        /// Register the Player with the game world
        /// </summary>
        /// <param name="argPlayer"></param>
        public void RegisterPlayer(Player argPlayer)
        {
            _player = argPlayer;
            _player.X = X;
            _player.Y = Y;
        }

        /// <summary>
        /// Register the Space Invaders with the game world
        /// </summary>
        /// <param name="invaders"></param>
        public void RegisterInvaders(Invaders argInvaders)
        {
            _invaders = argInvaders;
            _invaders.LeftBound = 1;
            _invaders.RightBound = X;
        }

        /// <summary>
        /// Register the BallisticManager with the game world
        /// </summary>
        /// <param name="argBallisticManager"></param>
        public void RegisterBallisticManager(BallisticManager argBallisticManager)
        {
            _ballisticManager = argBallisticManager;
            _ballisticManager.Game = this;
            _player.RegisterBallisticManager(_ballisticManager);
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
            foreach (Cell cell in _player.model)
            {
                _board[cell.X, cell.Y] = cell;
            }
        }

        /// <summary>
        /// Updates the GameWorld with current Invaders position
        /// </summary>
        private void UpdateInvadersPosition()
        {
            foreach (var cell in _invaders.Enemies.Where(x => !x.Dead).SelectMany(x => x.Model))
            {
                _board[cell.X, cell.Y] = cell;
            }
        }

        /// <summary>
        /// Updates the GameWorld with current Ballistic Cells
        /// </summary>
        private void UpdateBallistics()
        {
            foreach (Projectile projectile in _ballisticManager.Projectiles)
            {
                _board[projectile.Model.X, projectile.Model.Y] = projectile.Model;
            }
        }

        /// <summary>
        /// Updates the GameWorld with current state of Structures
        /// </summary>
        private void UpdateStructures()
        {
            for (int i = 0; i < 4; i++)
            {
                foreach (Cell cell in _structures[i].Model)
                {
                    _board[cell.X, cell.Y] = cell;
                }
            }
        }
    }
}
