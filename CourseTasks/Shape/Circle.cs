using System;

namespace Shape
{
    sealed class Circle : IShape
    {
        // Свойства класса Circle
        public double Radius { get; set; }

        // Конструктор класса Circle
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        // Методы класса Circle
        public double GetWidth()
        {
            return 2 * Radius;
        }

        public double GetHeight()
        {
            return 2 * Radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return "Круг" + "\t\t" + string.Format("{0:0.00}", this.GetWidth()) 
                + "\t" + string.Format("{0:0.00}", this.GetHeight()) 
                + "\t" + string.Format("{0:0.00}", this.GetArea()) 
                + "\t" + string.Format("{0:0.00}", this.GetPerimeter());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public bool Equals(Circle circle)
        {
            if (circle == null)
            {
                return false;
            }
            if (circle == this)
            {
                return true;
            }
            return this.Radius.Equals(circle.Radius);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !(obj is Circle))
            {
                return false;
            }
            return this.Equals((Circle)obj);
        }
    }
}
