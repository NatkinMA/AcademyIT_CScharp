using System;

namespace Vector
{
    class Vector
    {
        private double[] dimentions;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException("Некорректное значение размера массива.");
            }
            dimentions = new double[n];
        }

        public Vector(Vector vector)
        {
            dimentions = (double[]) vector.dimentions.Clone();
        }

        public Vector(params double[] dimentions)
        {
            this.dimentions = (double[]) dimentions.Clone();
        }

        public Vector(int n, params double[] dimentions)
        {
            if (n <= 0) throw new ArgumentOutOfRangeException("Некорректное значение размера массива.");
            this.dimentions = new double[n];
            dimentions.CopyTo(this.dimentions, 0);
        }

        public override string ToString()
        {
            return String.Join(", ", dimentions);
        }

        public int Size => dimentions.Length;

        public void Multiplication (double k)
        {
            for (int i = 0; i < dimentions.Length; i++) dimentions[i] = k * dimentions[i];
        }

        public void Deploy()
        {
            for (int i = 0; i < dimentions.Length; i++) dimentions[i] = -1 * dimentions[i];
        }

        public double Length
        {
            get
            {
                double length = 0;
                foreach (double dimention in dimentions) length = length + Math.Pow(dimention, 2);
                return Math.Sqrt(length);
            }
        }

        public void SetDimention(int i, double dimention) { dimentions[i] = dimention; }

        public double GetDimention(int i) { return dimentions[i]; }

        public void Add(Vector vector)
        {
            if (this.Size < vector.Size)
            {
                double[] temp = (double[])dimentions.Clone();
                this.dimentions = new double[vector.Size];
                temp.CopyTo(this.dimentions, 0);
            }
            for (int i = 0; i < vector.Size; i++)
            {
                this.SetDimention(i, this.GetDimention(i) + vector.GetDimention(i));
            }
        }

        public void Subtract(Vector vector)
        {
            if (this.Size < vector.Size)
            {
                double[] temp = (double[])dimentions.Clone();
                this.dimentions = new double[vector.Size];
                temp.CopyTo(this.dimentions, 0);
            }
            for (int i = 0; i < vector.Size; i++)
            {
                this.SetDimention(i, this.GetDimention(i) - vector.GetDimention(i));
            }
            /*
            vector.Deploy(); // так делать нельзя, потому что меняется объект.
            this.Add(vector);
            */
        }

        public static Vector Addition(Vector vector1, Vector vector2)
        {
            int size = 0;

            if (vector1.Size >= vector2.Size)
            {
                size = vector1.Size;
                vector2 = new Vector(size, vector2.dimentions);
            } else {
                size = vector2.Size;
                vector1 = new Vector(size, vector1.dimentions);
            }

            Vector vector = new Vector(size);

            for (int i = 0; i < size; i++)
            {
                vector.SetDimention(i, vector1.GetDimention(i) + vector2.GetDimention(i));
            }

            return vector;
        }

        public static Vector Subtraction(Vector vector1, Vector vector2)
        {
            int size = 0;

            if (vector1.Size >= vector2.Size)
            {
                size = vector1.Size;
                vector2 = new Vector(size, vector2.dimentions);
            }
            else
            {
                size = vector2.Size;
                vector1 = new Vector(size, vector1.dimentions);
            }

            Vector vector = new Vector(size);

            for (int i = 0; i < size; i++)
            {
                vector.SetDimention(i, vector1.GetDimention(i) - vector2.GetDimention(i));
            }

            return vector;
            /*
            vector2.Deploy();
            return Addition(vector1, vector2);
            */
        }

        public static Vector ScalarProduct(Vector vector1, Vector vector2)
        {
            int size = 0;

            if (vector1.Size >= vector2.Size)
            {
                size = vector1.Size;
                vector2 = new Vector(size, vector2.dimentions);
            }
            else
            {
                size = vector2.Size;
                vector1 = new Vector(size, vector1.dimentions);
            }

            Vector vector = new Vector(size);

            for (int i = 0; i < size; i++)
            {
                vector.SetDimention(i, vector1.GetDimention(i) * vector2.GetDimention(i));
            }

            return vector;
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
                    if (!this.GetDimention(i).Equals(vector.GetDimention(i))) return false;
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
