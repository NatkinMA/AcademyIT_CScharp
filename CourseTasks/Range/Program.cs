using System;

namespace Range
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для работы с классом Range");
            Range range1, range2;

            range1 = new Range(-5.5, 5.5);
            range2 = new Range(6, 7);

            double number01 = 1.5;
            double number02 = 6.5;

            Console.WriteLine("Длина интервала ({0}, {1}): {2}.", range1.From, range1.To, range1.Length);
            Console.WriteLine("Длина интервала ({0}, {1}): {2}.", range2.From, range2.To, range2.Length);

            if (range1.IsInside(number01))
            {
                Console.WriteLine("Число {0} входит в интервал ({1}, {2}).", number01, range1.From, range1.To);
            }
            else
            {
                Console.WriteLine("Число {0} не входит в интервал ({1}, {2}).", number01, range1.From, range2.To);
            }

            if (range2.IsInside(number02))
            {
                Console.WriteLine("Число {0} входит в интервал ({1}, {2}).", number02, range2.From, range2.To);
            }
            else
            {
                Console.WriteLine("Число {0} не входит в интервал ({1}, {2}).", number02, range2.From, range2.To);
            }

            Range rangeRes = range2.Intersection(range1);
            if (rangeRes != null)
            {
                Console.WriteLine("Длина пересечения интервалов ({0}, {1}): {2}.", rangeRes.From, rangeRes.To, rangeRes.Length);
            }
            else
            {
                Console.WriteLine("Интервалы не пересекаются.");
            }

            Range[] rangeResUnion = range2.Union(range1);
            Console.Write("Объединение интервалов ");
            for(int i = 0; i < rangeResUnion.Length; i++)
            {
                if (i > 0)
                {
                    Console.Write("U");
                }
                Console.Write("({0}, {1})", rangeResUnion[i].From, rangeResUnion[i].To);
            }
            Console.WriteLine(".");

            Range[] rangeResDif = range2.Difference(range1);
            Console.Write("Разница интервалов ");
            if (rangeResDif.Length > 0)
            {
                for(int i = 0; i < rangeResDif.Length; i++)
                {
                    if(i > 0)
                    {
                        Console.Write("U");
                    }
                    Console.Write("({0}, {1})", rangeResDif[i].From, rangeResDif[i].To);
                }
                Console.WriteLine(".");
            }
            else
            {
                Console.WriteLine("пустое множество.");
            }

            //try
            //{
            //    Range wrongRange = new Range(5.5, -6);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            Range oneMoreRange = new Range(-3, 3);

            try
            {
                oneMoreRange.From = 4;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //try
            //{
            //    oneMoreRange.To = -4;
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            Console.WriteLine("Для выходя нажмите клавишу Утеук...");
            Console.ReadLine();
        }
    }
}
