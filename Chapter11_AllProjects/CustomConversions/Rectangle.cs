using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversions
{
    struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public override string ToString()
        {
            return $"[Width = {Width}; Height = {Height}]";
        }
        public static implicit operator Rectangle(Square s)
        {
            return new Rectangle(s.Length * 2, s.Length);
        }
        public static bool operator ==(Rectangle r1, Rectangle r2) => r1.ToString() == r2.ToString();
        public static bool operator !=(Rectangle r1, Rectangle r2) => !(r1 == r2);

    }
}
