using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class Range
    {
        // Поля класса Range
        private double from, to;

        // Конструкторы класса Range
        public Range(double from, double to)
        {
            this.from = from;
            this.to = to;
        }

        // Свойства класса Range
        public double From
        {
            get { return from; }
            set { from = value; }
        }

        public double To
        {
            get { return to; }
            set { to = value; }
        }

        public double GetLength
        {
            get { return (to - from); }
        }

        // Методы класса Range
        public bool IsInside(double number)
        {
            return ((number >= From)&&(number <= To));
        }
    }
}
