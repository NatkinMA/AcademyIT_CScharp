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
        public double From { get; set; }
        public double To { get; set; }

        // Конструкторы класса Range
        public Range(double from, double to)
        {
            this.From = from;
            this.To = to;
        }

        public Range() { }

        // Свойства класса Range.
        // Свойство для получения длины интервала.
        public double Length
        {
            get { return (To - From); }
        }

        // Методы класса Range
        // Метод, определяющий принадлежит ли число диапазону.
        public bool IsInside(double number)
        {
            return ((number >= From) && (number <= To));
        }
        // Метод для получения пересечения двух интервалов. 
        // Если пересечения нет, выдать null. 
        // Если есть, то выдать новый диапазон с соответствующими концами.
        public Range Intersection(Range range)
        {
            Range ResultRange = new Range();

            if (range.From < this.From)
            {
                ResultRange.From = this.From;
            }
            else if (this.IsInside(range.From))
            {
                ResultRange.From = range.From;
            }
            else if (range.From > this.To)
            {
                ResultRange = null;
            }

            if (ResultRange != null)
            {
                if (range.To < this.From)
                {
                    ResultRange = null;
                }
                else if (this.IsInside(range.To))
                {
                    ResultRange.To = range.To;
                }
                else if (range.To > this.To)
                {
                    ResultRange.To = this.To;
                }
            }

            return ResultRange;
        }
        // Метод для получения объединения двух интервалов.
        // Может получиться 1 или 2 отдельных куска.
        public Range[] Union(Range range)
        {
            Range[] ResultRange = new Range[0];
            if (range.From < this.From)
            {
                if (range.To < this.From)
                {
                    ResultRange = new Range[2] { range, this };
                }
                else if (this.IsInside(range.To))
                {
                    ResultRange = new Range[1] { new Range(range.From, this.To) };
                }
                else if (range.To > this.To)
                {
                    ResultRange = new Range[1] { range };
                }
            }
            else if (this.IsInside(range.From))
            {
                if (this.IsInside(range.To))
                {
                    ResultRange = new Range[1] { this };
                }
                else if (range.To > this.To)
                {
                    ResultRange = new Range[1] { new Range(this.From, range.To) };
                }
            }
            else if (range.From > this.To)
            {
                ResultRange = new Range[2] { this, range };
            }
            return ResultRange;
        }
        // Метод для получения разности двух интервалов.
        // Может получиться 1 или 2 отдельных куска.
        // Может получиться пустое множество, в этом случае метод возвращает пустой массив длины 0.
        public Range[] Difference(Range range)
        {
            Range[] ResultRange = new Range[0];
            if (range.From < this.From)
            {
                if (range.To < this.From)
                {
                    ResultRange = new Range[1] { this };
                }
                else if (this.IsInside(range.To))
                {
                    ResultRange = new Range[1] { new Range(range.To, this.To) };
                }
                else if (range.To > this.To)
                {
                    ResultRange = new Range[0];
                }
            }
            else if (this.IsInside(range.From))
            {
                if (this.IsInside(range.To))
                {
                    ResultRange = new Range[2] { new Range(this.From, range.From), new Range(range.To, this.To) };
                }
                else if (range.To > this.To)
                {
                    ResultRange = new Range[1] { new Range(this.From, range.From) };
                }
            }
            else if (range.From > this.To)
            {
                ResultRange = new Range[1] { this };
            }
            return ResultRange;
        }
    }
}
