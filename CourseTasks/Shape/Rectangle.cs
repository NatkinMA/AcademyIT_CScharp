namespace Shape
{
    sealed class Rectangle : IShape
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
        public double GetWidth()
        {
            return Width;
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public double GetPerimeter()
        {
            return 2 * (Width + Height);
        }

        public override string ToString()
        {
            return "Прямоугольник" + "\t" + string.Format("{0:0.00}", this.GetWidth()) 
                + "\t" + string.Format("{0:0.00}", this.GetHeight()) 
                + "\t" + string.Format("{0:0.00}", this.GetArea()) 
                + "\t" + string.Format("{0:0.00}", this.GetPerimeter());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public bool Equals(Rectangle rectangle)
        {
            if (rectangle == null)
            {
                return false;
            }
            if (rectangle == this)
            {
                return true;
            }
            return this.Height.Equals(rectangle.Height) 
                && this.Width.Equals(rectangle.Width);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !(obj is Rectangle))
            {
                return false;
            }
            return this.Equals((Rectangle)obj);
        }
    }
}
