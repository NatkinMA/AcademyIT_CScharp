using System;

namespace Matrix
{
    using Vector;
    class Matrix
    {
        private Vector[] vectors;

        public Matrix(int n, int m)
        {
            if (m <= 0 || n <= 0)
            {
                throw new ArgumentOutOfRangeException("Некорректное значение размера матрицы.");
            }
            vectors = new Vector[m];
            for (int i = 0; i < m; i++)
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

        public int RowsSize => vectors.Length;

        public int ColumnSize => vectors[0].Size;

        public Vector this[int index]
        {
            set => vectors[index] = value;
            get => vectors[index];
        }

        public override string ToString()
        {
            string[] result = new string[vectors.Length];
            for(int i = 0; i < vectors.Length; i++)
            {
                result[i] = "{" + vectors[i].ToString() + "}";
            }
            return "{" + string.Join(", ", result) + "}";
        }


    }
}
