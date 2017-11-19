using System;

namespace Vector
{
    public class Vector
    {
        private double[] elements;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException("Некорректное значение размера массива.");
            }
            elements = new double[n];
        }

        public Vector(Vector vector)
        {
            elements = (double[]) vector.elements.Clone();
        }

        public Vector(params double[] elements)
        {
            if (elements.Length == 0)
            {
                throw new ArgumentOutOfRangeException("Некорректный размер вектора.");
            }
            this.elements = (double[]) elements.Clone();
        }

        public Vector(int n, params double[] elements)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException("Некорректное значение размера массива.");
            }
            this.elements = new double[n];
            for (int i = 0; i < this.elements.Length; i++)
            {
                this.elements[i] = elements[i];
            }
        }

        public override string ToString()
        {
            return string.Join(", ", elements);
        }

        public int Size => elements.Length;

        public void Multiplication (double k)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = k * elements[i];
            }
        }

        public void Revert()
        {
            Multiplication(-1);
        }

        public double Length
        {
            get
            {
                double length = 0;
                foreach (double element in elements)
                {
                    length += Math.Pow(element, 2);
                }
                return Math.Sqrt(length);
            }
        }

        public double this[int index]
        {
            set
            {
                elements[index] = value;
            }
            get
            {
                return elements[index];
            }
        }

        public void Add(Vector vector)
        {
            if (this.Size < vector.Size)
            {
                double[] temp = elements;
                this.elements = new double[vector.Size];
                temp.CopyTo(this.elements, 0);
            }
            for (int i = 0; i < vector.Size; i++)
            {
                this[i] += vector[i];
            }
        }

        public void Subtract(Vector vector)
        {
            if (this.Size < vector.Size)
            {
                double[] temp = elements;
                this.elements = new double[vector.Size];
                temp.CopyTo(this.elements, 0);
            }
            for (int i = 0; i < vector.Size; i++)
            {
                this[i] -= vector[i];
            }
        }

        public static Vector Addition(Vector vector1, Vector vector2)
        {
            Vector vector = new Vector(vector1);
            vector.Add(vector2);
            return vector;
        }

        public static Vector Subtraction(Vector vector1, Vector vector2)
        {
            Vector vector = new Vector(vector1);
            vector.Subtract(vector2);
            return vector;
        }

        public static double ScalarProduct(Vector vector1, Vector vector2)
        {
            int size = Math.Min(vector1.Size, vector2.Size);
            double result = 0.0;
            
            for (int i = 0; i < size; i++)
            {
                result += vector1[i] * vector2[i];
            }

            return result;
        }

        public bool Equals(Vector vector)
        {
            if (vector == null)
            {
                return false;
            }
            if (vector == this)
            {
                return true;
            }
            if (this.Length == vector.Length)
            {
                for(int i = 0; i < vector.Length; i++)
                {
                    if (!this[i].Equals(vector[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !(obj is Vector))
            {
                return false;
            }
            return this.Equals((Vector)obj);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
