using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Triangle : Shape
    {
        public Triangle(double x, double y, double height, double width) : base(x, y, height, width)
        {
        }

        public override void Draw()
        {
            //base.Draw();
            Console.WriteLine($"Rysujemy trójkąt o współrzędnych: {X}, {Y} o podstawie {Width} i wysokości {Height}");
        }
    }
}
