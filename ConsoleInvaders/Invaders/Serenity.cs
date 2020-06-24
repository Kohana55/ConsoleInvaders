namespace ConsoleInvaders
{
    class Serenity : BaseInvader, IInvader
    {
        public override Cell[] Model { get; } =
        {
            new Cell(0, 0,"_"),
            new Cell(1, 0,"o"),
            new Cell(2, 0,"-")
        };

        /// <summary>
        /// Standard Ctor - Must input transform coords of ship
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Serenity(int x, int y)
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
            if (Model[0].Contents == "_")
            {
                Model[0].Contents = "-";
                Model[2].Contents = "_";
            }
            else
            {
                Model[0].Contents = "_";
                Model[2].Contents = "-";
            }
        }
    }
}
