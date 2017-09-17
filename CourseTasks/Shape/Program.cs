using System;

namespace Shape
{
    class Program
    {
        private static void GetShapeWithMaxArea(IShape[] shapes)
        {
            int index = 0;
            double maxArea = 0;
            for (int i = 0; i < shapes.Length; i++)
            {
                if (shapes[i].GetArea() > maxArea)
                {
                    maxArea = shapes[i].GetArea();
                    index = i;
                }
            }
            Console.WriteLine("\nФигура с максимальной площадью:\nТип\t\tШирина\tВысота\tПлощадь\tПериметр\tHashCode");
            Console.WriteLine("{0}\t\t{1}", shapes[index], shapes[index].GetHashCode());
        }

        private static void GetShapeWithSecondPerimeter(IShape[] shapes)
        {
            // SortShapesByPerimeter(shapes);
            Array.Sort(shapes, new Comparison<IShape>((shape1, shape2) => shape2.GetPerimeter().CompareTo(shape1.GetPerimeter())));
            Console.WriteLine("\nФигура со вторым по величине периметром:\nТип\t\tШирина\tВысота\tПлощадь\tПериметр\tHashCode");
            Console.WriteLine("{0}\t\t{1}", shapes[1], shapes[1].GetHashCode());
        }

        static void Main(string[] args)
        {
            IShape[] shapes = { new Square(2), new Triangle(1, 1, 2, 2, 3, 1), new Rectangle(2, 3), new Circle(3),
                                new Square(15), new Triangle(3, 3, 10, 10, 12, 2), new Rectangle(5, 7), new Circle(7),
                                new Square(7), new Triangle(0, 0, 7, 15, 14, 0), new Rectangle(6, 2), new Circle(4) };
            Console.WriteLine("Все фигуры:\nТип\t\tШирина\tВысота\tПлощадь\tПериметр\tHashCode");
            foreach(IShape shape in shapes)
            {
                Console.WriteLine("{0}\t\t{1}", shape, shape.GetHashCode());
            }

            GetShapeWithMaxArea(shapes);
            GetShapeWithSecondPerimeter(shapes);

            Square square = new Square(2);
            Circle circle = new Circle(7);
            Rectangle rectangle = new Rectangle(6, 2);
            Triangle triangle = new Triangle(0, 0, 7, 15, 14, 0);

            Console.WriteLine("\nПоиск фигур:");
            Console.WriteLine("Тип\t\tШирина\tВысота\tПлощадь\tПериметр");
            Console.WriteLine(square.ToString());
            Console.WriteLine(circle.ToString());
            Console.WriteLine(rectangle.ToString());
            Console.WriteLine(triangle.ToString());
            Console.WriteLine("\nТип\t\tШирина\tВысота\tПлощадь\tПериметр");
            foreach (IShape shape in shapes)
            {
                if (square.Equals(shape) || circle.Equals(shape) || rectangle.Equals(shape) 
                    || triangle.Equals(shape))
                {
                    Console.WriteLine("{0}\tФигуры равны", shape);
                }
                else
                {
                    Console.WriteLine("{0}\tФигуры не равны", shape);
                }
            }

            Console.WriteLine("Для выхода нажмите Утеук...");
            Console.ReadLine();
        }
    }
}
