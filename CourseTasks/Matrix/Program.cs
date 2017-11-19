using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(3, 5);
            Console.WriteLine("Размер матрицы {0}: {1}X{2}.", matrix1, matrix1.RowsSize, matrix1.ColumnSize);
            matrix1[1] = new Vector.Vector(2.0, 3.0, 4.0);
            Console.WriteLine("Матрица с измененным вторым ветором {0}.", matrix1);
            matrix1[2] = new Vector.Vector(5.5, 6.9, 7.0);
            Console.WriteLine("Вектор матрицы с индексом 2: {0}", "{" + matrix1[2] + "}");

            Console.WriteLine("Для выхода нажмите Утеук...");
            Console.ReadLine();
        }
    }
}
