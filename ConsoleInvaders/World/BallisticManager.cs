﻿using ConsoleInvaders.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleInvaders
{
    class BallisticManager
    {
        /// <summary>
        /// List of registered projectiles
        /// </summary>
        public List<Projectile> Projectiles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BallisticManager()
        {
            Projectiles = new List<Projectile>();
        }

        /// <summary>
        /// Updates all ballistics
        /// To be run in its own thread
        /// </summary>
        public void Update(IEnumerable<IInvader> invaders)
        {
            while (true)
            {
                if (Projectiles.Any())
                {
                    foreach (var projectile in Projectiles)
                    {
                        projectile.Update();

                        foreach (var invader in invaders)
                        {
                            if (invader.GetHitbox().ContainsCell(projectile.Model))
                            {
                                invader.Dead = true;
                                projectile.Collision = true;
                            }
                        }
                    }

                    Projectiles.RemoveAll(x => x.Collision);
                }

                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Register a projectile
        /// </summary>
        /// <param name="projectile"></param>
        public void RegisterProjectile(Projectile projectile)
        {
            Projectiles.Add(projectile);
        }

    }
}
