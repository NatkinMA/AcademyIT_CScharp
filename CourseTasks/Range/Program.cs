using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для работы с классом Range");

            Range Range1 = new Range(-5.5, 5.5);
            Range Range2 = new Range();
            Range2.From = 6;
            Range2.To = 12;
            double Number01 = 1.5;
            double Number02 = 6.5;

            Console.WriteLine("Длина интервала ({0}, {1}): {2}.", Range1.From, Range1.To, Range1.Length);
            Console.WriteLine("Длина интервала ({0}, {1}): {2}.", Range2.From, Range2.To, Range2.Length);

            if (Range1.IsInside(Number01))
            {
                Console.WriteLine("Число {0} входит в интервал ({1}, {2}).", Number01, Range1.From, Range1.To);
            }
            else
            {
                Console.WriteLine("Число {0} не входит в интервал ({1}, {2}).", Number01, Range1.From, Range2.To);
            }

            if (Range2.IsInside(Number02))
            {
                Console.WriteLine("Число {0} входит в интервал ({1}, {2}).", Number02, Range2.From, Range2.To);
            }
            else
            {
                Console.WriteLine("Число {0} не входит в интервал ({1}, {2}).", Number02, Range2.From, Range2.To);
            }

            Range RangeRes = Range2.Intersection(Range1);
            if (RangeRes != null)
            {
                Console.WriteLine("Длина пересечения интервалов ({0}, {1}): {2}.", RangeRes.From, RangeRes.To, RangeRes.Length);
            }
            else
            {
                Console.WriteLine("Интервалы не пересекаются.");
            }

            Console.WriteLine("Для выходя нажмите клавишу Утеук...");
            Console.ReadLine();
        }
    }
}
