using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadedOperators
{
    class Point : IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }
        public static Point operator + (Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Point operator +(Point p1, int delta)
        {
            return new Point(p1.X + delta, p1.Y + delta);
        }
        public static Point operator - (Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static Point operator - (Point p1, int delta)
        {
            return new Point(p1.X - delta, p1.Y - delta);
        }
        public static Point operator ++ (Point p)
        {
            return new Point(p.X + 1, p.Y + 1);
        }
        public static Point operator -- (Point p)
        {
            return new Point(p.X - 1, p.Y - 1);
        }
        public override bool Equals(object obj)
        {
            return obj.ToString() == ToString();
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public int CompareTo(Point other)
        {
            if (X > other.X && Y > other.Y)
            {
                return 1;
            }
            if (X < other.X && Y < other.Y)
            {
                return -1;
            }
            return 0;
        }

        public static bool operator ==(Point p1, Point p2) => p1.Equals(p2);
        public static bool operator !=(Point p1, Point p2) => !(p1 == p2); // !p1.Equals(p2);
        public static bool operator <(Point p1, Point p2) => p1.CompareTo(p2) < 0;
        public static bool operator >(Point p1, Point p2) => p1.CompareTo(p2) > 0;
        public static bool operator <=(Point p1, Point p2) => p1.CompareTo(p2) <= 0;
        public static bool operator >=(Point p1, Point p2) => p1.CompareTo(p2) >= 0;
    }
}
