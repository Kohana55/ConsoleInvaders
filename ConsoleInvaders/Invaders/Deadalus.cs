namespace ConsoleInvaders
{
    internal class Deadalus : BaseInvader, IInvader
    {
        public override Cell[] Model { get; } =
        {
            new Cell(0,0,"."),
            new Cell(1,0,"^"),
            new Cell(2,0,".")
        };

        /// <summary>
        /// Standard Ctor - Must input transform coords of ship
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Deadalus(int x, int y)
        {
            foreach (Cell cell in Model)
            {
                cell.X += x;
                cell.Y += y;
                cell.isRigid = true;
            }
        }

        /// <summary>
        /// Call each frame to animate Invader
        /// </summary>
        public override void Animate()
        {
            if (Model[1].Contents == "^")
            {
                Model[1].Contents = "-";
            }
            else
            {
                Model[1].Contents = "^";
            }
        }
    }
}
