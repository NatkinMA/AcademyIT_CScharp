using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Square : Shape
    {
        // Свойства класса Square
        public double Side { get; set; }

        // Конструктор класса Square
        public Square(double side) { this.Type = "Квадрат"; this.Side = side; }

        // Методы класса Square
        public override double GetWidth()
        {
            return Side;
        }
        public override double GetHeight()
        {
            return Side;
        }
        public override double GetArea()
        {
            return Side * Side;
        }
        public override double GetPerimeter()
        {
            return 4 * Side;
        }
        public override string ToString()
        {
            return this.Type + "\t\t" + String.Format("{0:0.00}", this.GetWidth()) + 
                        "\t" + String.Format("{0:0.00}", this.GetHeight()) + 
                        "\t" + String.Format("{0:0.00}", this.GetArea()) + 
                        "\t" + String.Format("{0:0.00}", this.GetPerimeter());
        }
        public override int GetHashCode()
        {
            return Type.GetHashCode() ^ Side.GetHashCode();
        }
        public bool Equals(Square square)
        {
            return this.Type.Equals(square.Type) && this.Side.Equals(square.Side);
        }
        public bool Equals(Shape shape)
        {
            if (shape == null)
            {
                return false;
            }
            Square square = shape as Square;
            if (square == null)
            {
                return false;
            }
            return this.Equals(square);
        }
        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            Square square = obj as Square;
            if ((System.Object)square == null)
            {
                return false;
            }
            return this.Equals(square);
        }
    }
}
