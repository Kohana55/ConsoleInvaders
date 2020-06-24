using ConsoleInvaders.Models;
using System.Linq;

namespace ConsoleInvaders
{
    public abstract class BaseInvader : IInvader
    {
        public abstract Cell[] Model { get; }

        public bool Dead { get; set; }

        public abstract void Animate();

        public Rectangle GetHitbox()
        {
            return new Rectangle(Model.First().X, Model.First().Y, Model.Last().X, Model.Last().Y);
        }

        /// <summary>
        /// Transforms each cell in a Galatica model by X
        /// </summary>
        /// <param name="x"></param>
        public void Move(int x)
        {
            foreach (Cell cell in Model)
            {
                cell.X += x;
            }
        }

        /// <summary>
        /// Drops each cell down the X-Axis
        /// </summary>
        public void Drop()
        {
            foreach (Cell cell in Model)
            {
                cell.Y += 1;
            }
        }
    }
}
