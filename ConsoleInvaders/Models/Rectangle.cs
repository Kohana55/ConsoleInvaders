using System;

namespace ConsoleInvaders.Models
{
    /// <summary>
    /// Rectangle container
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// Left value of the rectangle
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// Top value of the rectangle
        /// </summary>
        public int Top { get; set; }
        
        /// <summary>
        /// Right value of the rectangle
        /// </summary>
        public int Right { get; set; }

        /// <summary>
        /// Bottom value of the rectangle
        /// </summary>
        public int Bottom { get; set; }

        /// <summary>
        /// Rectangle Width
        /// </summary>
        public int Width => Math.Abs(Right - Left);

        public int Height => Math.Abs(Top - Bottom);

        public Rectangle(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public bool ContainsPoint(int x, int y)
        {
            return x >= Left && x <= Right && y <= Top && y >= Bottom;
        }
    }
}
