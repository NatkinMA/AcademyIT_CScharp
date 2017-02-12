using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Triangle : Shape
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
            this.Type = "Треугольник";
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
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
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

        public override string ToString()
        {
            return this.Type + "\t" + String.Format("{0:0.00}", this.GetWidth()) +
                        "\t" + String.Format("{0:0.00}", this.GetHeight()) +
                        "\t" + String.Format("{0:0.00}", this.GetArea()) +
                        "\t" + String.Format("{0:0.00}", this.GetPerimeter());
        }
        public override int GetHashCode()
        {
            return Type.GetHashCode() ^ X1.GetHashCode() ^ Y1.GetHashCode() 
                    ^ X2.GetHashCode() ^ Y2.GetHashCode() ^ X3.GetHashCode() ^ Y3.GetHashCode();
        }
        public bool Equals(Triangle triangle)
        {
            return this.Type.Equals(triangle.Type) && this.A.Equals(triangle.A) 
                    && this.B.Equals(triangle.B) && this.C.Equals(triangle.C);
        }
        public bool Equals(Shape shape)
        {
            if (shape == null)
            {
                return false;
            }
            Triangle triangle = shape as Triangle;
            if (triangle == null)
            {
                return false;
            }
            return this.Equals(triangle);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Triangle triangle = obj as Triangle;
            if ((System.Object)triangle == null)
            {
                return false;
            }
            return this.Equals(triangle);
        }
    }
}
