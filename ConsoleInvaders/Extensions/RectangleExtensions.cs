using ConsoleInvaders.Models;

namespace ConsoleInvaders.Extensions
{
    internal static class RectangleExtensions
    {
        public static bool ContainsCell(this Rectangle rectangle, Cell cell)
        {
            return rectangle.ContainsPoint(cell.X, cell.Y);
        }
    }
}
