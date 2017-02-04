﻿using System;
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

            Range objRange = new Range(-5.5, 5.5);
            double dblNumber01 = 1.5;
            double dblNumber02 = 6.5;

            Console.WriteLine("Длина интервала ({0}, {1}): {2}.", objRange.From, objRange.To, objRange.GetInterval());

            if (objRange.IsInside(dblNumber01))
            {
                Console.WriteLine("Число {0} входит в интервал ({1}, {2}).", dblNumber01, objRange.From, objRange.To);
            }
            else
            {
                Console.WriteLine("Число {0} не входит в интервал ({1}, {2}).", dblNumber01, objRange.From, objRange.To);
            }

            if (objRange.IsInside(dblNumber02))
            {
                Console.WriteLine("Число {0} входит в интервал ({1}, {2}).", dblNumber02, objRange.From, objRange.To);
            }
            else
            {
                Console.WriteLine("Число {0} не входит в интервал ({1}, {2}).", dblNumber02, objRange.From, objRange.To);
            }

            Console.WriteLine("Для выходя нажмите клавишу Утеук...");
            Console.ReadLine();
        }
    }
}
