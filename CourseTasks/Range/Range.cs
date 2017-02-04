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
        private double dblFrom;
        private double dblTo;

        // Конструкторы класса Range
        public Range(double from, double to)
        {
            this.dblFrom = from;
            this.dblTo = to;
        }

        public Range()
        { }

        // Свойства класса Range
        public double From
        {
            get { return dblFrom; }
            set { dblFrom = value; }
        }

        public double To
        {
            get { return dblTo; }
            set { dblTo = value; }
        }

        // Методы класса Range
        public double GetInterval()
        {
            return Math.Abs(dblTo - dblFrom);
        }

        public bool IsInside(double number)
        {
            if ((number >= dblFrom)&&(number <= dblTo))
            { return true; }
            else
            { return false; }
        }
    }
}
