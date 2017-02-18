using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sort_it
{
    class Program
    {
        private static bool CompareObject(object obj1, object obj2, string dataType, string direction)
        {
            if (dataType.Equals("-i") && direction.Equals("-a"))
            {
                return int.Parse(obj1.ToString()) > int.Parse(obj2.ToString());
            }
            if (dataType.Equals("-i") && direction.Equals("-d"))
            {
                return int.Parse(obj1.ToString()) < int.Parse(obj2.ToString());
            }
            if (dataType.Equals("-s") && direction.Equals("-a"))
            {
                return obj1.ToString().CompareTo(obj2.ToString()) >= 0;
            }
            if (dataType.Equals("-s") && direction.Equals("-d"))
            {
                return obj1.ToString().CompareTo(obj2.ToString()) <= 0;
            }
            return false;
        }

        private static object[] InsertionSort(object[] array, string dataType, string direction)
        {
            object[] result = new object[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && CompareObject(result[j - 1], array[i], dataType, direction))
                {
                    result[j] = result[j - 1];
                    j--;
                }
                result[j] = array[i];
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Чтение данных из файла: {0}", args[0]);
            object[] array = new object[File.ReadAllLines(args[0]).Length];
            using (StreamReader reader = new StreamReader(args[0]))
            {
                int index = 0;
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    array[index] = int.Parse(currentLine);
                    index++;
                }
            }

            Console.WriteLine("Сортировка данных методом вставок (insertion sort)");
            array = InsertionSort(array, args[2], args[3]);

            Console.WriteLine("Запись данных в файл: {0}", args[1]);
            using (StreamWriter writer = new StreamWriter(args[1]))
            {
                foreach(object line in array)
                {
                    writer.WriteLine(line.ToString());
                }
            }

            Console.WriteLine("Для выхода из программы нажмите Утеук...");
            Console.ReadLine();
        }
    }
}
