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

        private static void Help()
        {
            Console.WriteLine("\nSort-it.exe {inputfilename} {outputfilename} {-i|-s} {-a|-b}");
            Console.WriteLine("Сортировка целых чисел или строк из файла методом вставок. Входной файл должен содержать не более 100 строк.\n");
            Console.WriteLine("- infilename\tОбязательный параметр. Имя файла с данными для обработки.");
            Console.WriteLine("- outfilename\tОбязательный параметр. Имя файла с обработанными данными.");
            Console.WriteLine("- -i|-s\t\tОбязательный параметр. Тип сортируемы данных:\n\t\t-i - целые числа;\n\t\t-s - строки.");
            Console.WriteLine("- -a|-b\t\tОбязательный параметр. Направление сортировки данных:\n\t\t-a - по возрастанию;\n\t\t-d - по убыванию.");
        }

        static void Main(string[] args)
        {
            if (args.Length == 0 || args[0].Equals("-help"))
            {
                Help();
                return;
            }

            if (args.Length != 4)
            {
                Console.WriteLine("Неверное количество параметров для запуска.");
                Help();
                return;
            }

            Console.WriteLine("Чтение данных из файла: {0}", args[0]);

            List<string> ListStringOfFile = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(args[0]))
                {
                    string str;
                    while ((str = reader.ReadLine()) != null)
                    {
                        ListStringOfFile.Add(str);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удалось прочитать файл:");
                Console.WriteLine(e.Message);
            }

            //Console.WriteLine("Сортировка данных методом вставок (insertion sort)");
            //array = InsertionSort(array, args[2], args[3]);

            try
            {
                using (StreamWriter writer = new StreamWriter(args[1]))
                {
                    foreach (string str in ListStringOfFile)
                    {
                        writer.WriteLine(str);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удалось записать файл:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
