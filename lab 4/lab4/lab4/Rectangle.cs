using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Rectangle : Shape
    {
        public Rectangle(double x, double y, double height, double width) : base(x, y, height, width)
        {
        }

        public override void Draw()
        {
          
            Console.WriteLine($"Rysujemy prostokąt o współrzędnych: {X}, {Y} o długości {Width} i wysokości {Height}");
        }
    }
}
