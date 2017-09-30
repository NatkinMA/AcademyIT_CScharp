using System;

namespace Vector
{
    class Vector
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

        public Vector(params double[] dimentions)
        {
            this.elements = (double[]) dimentions.Clone();
        }

        public Vector(int n, params double[] dimentions)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException("Некорректное значение размера массива.");
            }
            this.elements = new double[n];
            dimentions.CopyTo(this.elements, 0);
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
                foreach (double dimention in elements)
                {
                    length = length + Math.Pow(dimention, 2);
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
                this[i] = this[i] + vector[i];
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
                this[i] = this[i] - vector[i];
            }
        }

        public static Vector Addition(Vector vector1, Vector vector2)
        {
            vector1.Add(vector2);
            return vector1;
        }

        public static Vector Subtraction(Vector vector1, Vector vector2)
        {
            vector1.Subtract(vector2);
            return vector1;
        }

        public static double ScalarProduct(Vector vector1, Vector vector2)
        {
            int size = 0;
            double result = 0.0;

            if (vector1.Size >= vector2.Size)
            {
                size = vector1.Size;
                vector2 = new Vector(size, vector2.elements);
            }
            else
            {
                size = vector2.Size;
                vector1 = new Vector(size, vector1.elements);
            }

            for (int i = 0; i < size; i++)
            {
                result = result + vector1[i] * vector2[i];
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
