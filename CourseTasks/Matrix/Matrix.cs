using System;

namespace Matrix
{
    class Matrix
    {
        private Vector[] vectors;

        public Matrix(int n, int m)
        {
            if (m <= 0)
            {
                throw new ArgumentOutOfRangeException("Некорректное значение размера матрицы.");
            }
            vectors = new Vector[m];
            for (int i = 0; i < n; i++)
            {
                vectors[i] = new Vector(n);
            }
        }

        public Matrix(Matrix matrix)
        {
            vectors = new Vector[matrix.vectors.Length];
            for (int i = 0; i < matrix.vectors.Length; i++)
            {
                vectors[i] = new Vector(matrix.vectors[i]);
            }
        }

        public Matrix(double[][] elements)
        {
            vectors = new Vector[elements.Length];
            for (int i = 0; i < elements.Length; i++)
            {
                vectors[i] = new Vector(elements[i]);
            }
        }

        public Matrix(Vector[] array)
        {
            vectors = new Vector[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                vectors[i] = new Vector(array[i]);
            }
        }


    }
}
