using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public class Shape
    {
        // Методы класса Shape
        public virtual double GetWidth() { return 0; }
        public virtual double GetHeight() { return 0; }
        public virtual double GetArea() { return 0; }
        public virtual double GetPerimeter() { return 0; }
    }

    public class Square : Shape
    {
        // Свойства класса Square
        public double Side { get; set; }

        // Конструктор класса Square
        public Square(double side) { this.Side = side; }

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
    }

    public class Triangle : Shape
    {
        // Свойства класса Triangle
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public double X3 { get; set; }
        public double Y3 { get; set; }
        public double A
        {
            get { return GetLength(X1, Y1, X2, Y2); }
        }
        public double B
        {
            get { return GetLength(X2, Y2, X3, Y3); }
        }
        public double C
        {
            get { return GetLength(X1, Y1, X3, Y3); }
        }

        // Конструктор класса Triangle
        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
            this.X3 = x3;
            this.Y3 = y3;
        }

        // Методы класса Triangle
        private double GetMax(double n1, double n2, double n3)
        {
            return Math.Max(Math.Max(n1, n2), n3);
        }
        private double GetMin(double n1, double n2, double n3)
        {
            return Math.Min(Math.Min(n1, n2), n3);
        }
        private double GetLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x1-x2), 2) + Math.Pow((y1-y2), 2));
        }
        public override double GetWidth()
        {
            return GetMax(X1, X2, X3) - GetMin(X1, X2, X3);
        }
        public override double GetHeight()
        {
            return GetMax(Y1, Y2, Y3) - GetMin(Y1, Y2, Y3);
        }
        public override double GetArea()
        {
            double p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
        public override double GetPerimeter()
        {
            return A + B + C;
        }
    }

    public class Rectangle : Shape
    {
        // Свойства класса Rectangle
        public double Height { get; set; }
        public double Width { get; set; }

        // Конструктор класса Rectangle
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        // Методы класса Rectangle
        public override double GetWidth()
        {
            return Width;
        }

        public override double GetHeight()
        {
            return Height;
        }

        public override double GetArea()
        {
            return Width * Height;
        }

        public override double GetPerimeter()
        {
            return 2 * (Width + Height);
        }
    }

    public class Circle : Shape
    {
        // Свойства класса Circle
        public double Radius { get; set; }

        // Конструктор класса Circle
        public Circle(double radius)
        {
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
    }
}
