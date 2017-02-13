using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    sealed class Square : IShape
    {
        // Свойства класса Square
        public double Side { get; set; }

        // Конструктор класса Square
        public Square(double side)
        {
            this.Side = side;
        }

        // Методы класса Square
        public double GetWidth()
        {
            return Side;
        }

        public double GetHeight()
        {
            return Side;
        }

        public double GetArea()
        {
            return Side * Side;
        }

        public double GetPerimeter()
        {
            return 4 * Side;
        }

        public override string ToString()
        {
            return "Квадрат" + "\t\t" + string.Format("{0:0.00}", this.GetWidth()) + 
                        "\t" + string.Format("{0:0.00}", this.GetHeight()) + 
                        "\t" + string.Format("{0:0.00}", this.GetArea()) + 
                        "\t" + string.Format("{0:0.00}", this.GetPerimeter());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public bool Equals(Square square)
        {
            if (square == null)
            {
                return false;
            }
            if (square == this)
            {
                return true;
            }
            return this.Side.Equals(square.Side);
        }

        public override bool Equals(object obj)
        {
            if((obj == null) || !(obj is Square))
            {
                return false;
            }
            return this.Equals((Square)obj);
        }
    }
}
