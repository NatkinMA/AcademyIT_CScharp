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

        // Свойства класса Range.
        // Свойство для получения длины интервала.
        public double GetLength
        {
            get { return (to - from); }
        }

        // Методы класса Range
        // Метод, определяющий принадлежит ли число диапазону.
        public bool IsInside(double number)
        {
            return ((number >= from)&&(number <= to));
        }
        // Получение интервала-пересечения двух интервалов. 
        // Если пересечения нет, выдать null. 
        // Если есть, то выдать новый диапазон с соответствующими концами.
        public Range Intersection(Range range)
        {
            if((range.from > this.to) || (range.to < this.to)) { return null; }
            if((range.from < this.from) && this.IsInside(range.to)) { return new Range(this.from, range.to); }
            if((range.from < this.from) && (range.to > this.to)) { return new Range(this.from, this.to); }
            if(this.IsInside(range.from) && (range.to > this.to)) { return new Range(range.from, this.to); }
            return null;
        }
    }
}
