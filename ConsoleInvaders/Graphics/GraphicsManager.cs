using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class GraphicsManager
    {
        #region Fields
        /// <summary>
        /// Reference to the game world to be rendered
        /// Set by the Ctor
        /// </summary>
        private GameWorld gameWorld;

        /// <summary>
        /// Scene buffer to be drawn
        /// </summary>
        private string gameScene;
        #endregion

        #region Ctors
        /// <summary>
        /// Standard Ctor must accept a reference to GameWorld
        /// </summary>
        /// <param name="argGameWorld">GameWorld to be rendered</param>
        public GraphicsManager(GameWorld argGameWorld)
        {
            Console.Title = "Space Invaders";
            gameWorld = argGameWorld;
            Console.CursorVisible = false;
            Console.SetWindowSize(gameWorld.Y+2, gameWorld.X+1);
            Console.BufferHeight = gameWorld.X+1;
            Console.BufferWidth = gameWorld.Y+2;
        }
        #endregion

        #region Public
        /// <summary>
        /// Updates the current scene
        /// </summary>
        public void Update()
        {
            gameScene = "";
            for (int i = 0; i < gameWorld.X; i++)
            {
                for (int j = 0; j < gameWorld.Y; j++)
                {
                    gameScene += gameWorld.GetCellContents(i, j);
                }

                gameScene += "\n";
            }
        }

        /// <summary>
        /// Draws the current scene
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(gameScene);
        }
        #endregion
    }
}
