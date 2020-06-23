using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the GameWorld, Player, Invaders and GraphicsManager
            GameWorld game = new GameWorld();
            BallisticManager ballisticManager = new BallisticManager();
            Player player = new Player(game.X-1);
            Invaders invaders = new Invaders();
            GraphicsManager graphicsManager = new GraphicsManager(game);

            // Register player and Invaders with the GameWorld
            game.RegisterPlayer(player);
            game.RegisterInvaders(invaders);
            game.RegisterBallisticManager(ballisticManager);
            player.RegisterBallisticManager(ballisticManager);

            // Player and Invader control threads
            Thread playerControlThread = new Thread(player.Controller);
            playerControlThread.Start();
            Thread invaderControlThread = new Thread(invaders.Controller);
            invaderControlThread.Start();
            Thread ballisticControlThread = new Thread(ballisticManager.Update);
            ballisticControlThread.Start();
           
            // Game Loop
            while (true)
            {
                // Update the GameWorld
                game.Update();

                // Update and Draw the game
                graphicsManager.Update();
                graphicsManager.Draw();

                // Don't hammer the CPU
                Thread.Sleep(5);
            }
            
        }
    }
}
