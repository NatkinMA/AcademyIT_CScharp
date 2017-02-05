using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class Range
    {
        // Свойства класса Range
        public double from { get; set; }
        public double to { get; set; }

        // Конструкторы класса Range
        public Range(double from, double to)
        {
            this.from = from;
            this.to = to;
        }

        public Range() { }

        // Свойства класса Range
        public double GetLength
        {
            get { return (to - from); }
        }

        // Методы класса Range
        public bool IsInside(double number)
        {
            return ((number >= from)&&(number <= to));
        }
    }
}
