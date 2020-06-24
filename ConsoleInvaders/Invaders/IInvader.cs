using ConsoleInvaders.Models;

namespace ConsoleInvaders
{
    interface IInvader
    {
        Cell[] Model { get; }
        bool Dead { get; set; }
        void Animate();
        void Move(int x);
        void Drop();
        Rectangle GetHitbox();
    }
}
