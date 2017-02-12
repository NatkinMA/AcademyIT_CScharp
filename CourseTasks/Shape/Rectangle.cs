using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Rectangle : Shape
    {
        // Свойства класса Rectangle
        public double Height { get; set; }
        public double Width { get; set; }

        // Конструктор класса Rectangle
        public Rectangle(double width, double height)
        {
            this.Type = "Прямоугольник";
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
        public override string ToString()
        {
            return this.Type + "\t" + String.Format("{0:0.00}", this.GetWidth()) +
                        "\t" + String.Format("{0:0.00}", this.GetHeight()) +
                        "\t" + String.Format("{0:0.00}", this.GetArea()) +
                        "\t" + String.Format("{0:0.00}", this.GetPerimeter());
        }
        public override int GetHashCode()
        {
            return Type.GetHashCode() ^ Width.GetHashCode() ^ Height.GetHashCode();
        }
        public bool Equals(Rectangle rectangle)
        {
            return this.Type.Equals(rectangle.Type) && this.Height.Equals(rectangle.Height) 
                    && this.Width.Equals(rectangle.Width);
        }
        public bool Equals(Shape shape)
        {
            if (shape == null)
            {
                return false;
            }
            Rectangle rectangle = shape as Rectangle;
            if (rectangle == null)
            {
                return false;
            }
            return this.Equals(rectangle);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Rectangle rectangle = obj as Rectangle;
            if ((System.Object)rectangle == null)
            {
                return false;
            }
            return this.Equals(rectangle);
        }
    }
}
