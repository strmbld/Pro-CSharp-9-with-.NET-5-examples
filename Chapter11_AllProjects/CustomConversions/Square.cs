using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversions
{
    struct Square
    {
        public int Length { get; set; }

        public Square(int length)
        {
            Length = length;
        }
        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public override string ToString()
        {
            return $"[Length = {Length}]";
        }
        public static explicit operator Square(Rectangle r)
        {
            return new Square(r.Height);
        }
        public static explicit operator Square(int side)
        {
            return new Square(side);
        }
        public static explicit operator int(Square s)
        {
            return s.Length;
        }
    }
}
