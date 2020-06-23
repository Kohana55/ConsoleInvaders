using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        public void Update()
        {
            while(true)
            {
                if (Projectiles.Count > 0)
                {
                    foreach (Projectile projectile in Projectiles.ToList())
                    {
                        projectile.Update();
                        if (projectile.collision)
                            Projectiles.Remove(projectile);
                    }
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
