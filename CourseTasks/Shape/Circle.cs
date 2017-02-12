using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Circle : Shape
    {
        // Свойства класса Circle
        public double Radius { get; set; }

        // Конструктор класса Circle
        public Circle(double radius)
        {
            this.Type = "Круг";
            this.Radius = radius;
        }

        // Методы класса Circle
        public override double GetWidth()
        {
            return 2 * Radius;
        }
        public override double GetHeight()
        {
            return 2 * Radius;
        }
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
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
            return Type.GetHashCode() ^ Radius.GetHashCode();
        }
        public bool Equals(Circle circle)
        {
            return this.Type.Equals(circle.Type) && this.Radius.Equals(circle.Radius);
        }
        public bool Equals(Shape shape)
        {
            if (shape == null)
            {
                return false;
            }
            Circle circle = shape as Circle;
            if (circle == null)
            {
                return false;
            }
            return this.Equals(circle);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Circle circle = obj as Circle;
            if ((System.Object)circle == null)
            {
                return false;
            }
            return this.Equals(circle);
        }
    }
}
