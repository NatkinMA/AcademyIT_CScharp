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
        private double from;
        private double to;
       
        public double From
        {
            get
            {
                return this.from;
            }
            set
            {
                if (value > this.to) throw new Exception("Неправильно задано начало отрезка.");
                this.from = value;
            }
        }

        public double To
        {
            get
            {
                return this.to;
            }
            set
            {
                if (value < this.from) throw new Exception("Ошибочно задано окончание отрезка.");
                this.to = value;
            }
        }

        // Конструктор класса Range
        public Range(double from, double to)
        {
            if (from > to)
            {
                throw new Exception("Не правильно заданы параметры для создания отрезка.");
            }
            this.From = from;
            this.To = to;
        }

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
        // Метод, определяющий пересекаются ли интервалы.
        public bool IsIntersect(Range range)
        {
            return !((range.To < this.From) || (range.From > this.To));
        }
        // Метод для получения пересечения двух интервалов. 
        // Если пересечения нет, выдать null. 
        // Если есть, то выдать новый диапазон с соответствующими концами.
        public Range Intersection(Range range)
        {
            if (!this.IsIntersect(range))
            {
                return null;
            }
            return new Range(Math.Max(this.From, range.From), Math.Min(this.To, range.To));
        }
        // Метод для получения объединения двух интервалов.
        // Может получиться 1 или 2 отдельных куска.
        public Range[] Union(Range range)
        {
            if (!this.IsIntersect(range))
            {
                return new Range[] { new Range(Math.Min(this.From, range.From), Math.Min(this.To, range.To)),
                                        new Range(Math.Max(this.From, range.From), Math.Max(this.To, range.To)) };
            }
            return new Range[] { new Range(Math.Min(this.From, range.From), Math.Max(this.To, range.To)) };
        }
        // Метод для получения разности двух интервалов.
        // Может получиться 1 или 2 отдельных куска.
        // Может получиться пустое множество, в этом случае метод возвращает пустой массив длины 0.
        public Range[] Difference(Range range)
        {
            if (!this.IsIntersect(range))
            {
                return new Range[] { new Range(this.From, this.To) };
            }
            if (range.From < this.From)
            {
                if (this.IsInside(range.To))
                {
                    return new Range[] { new Range(range.To, this.To) };
                }
                else
                {
                    return new Range[0];
                }
            }
            else
            {
                if (this.IsInside(range.To))
                {
                    return new Range[] { new Range(this.From, range.From), new Range(range.To, this.To) };
                }
                else
                {
                    return new Range[] { new Range(this.From, range.From) };
                }
            }
        }
    }
}
