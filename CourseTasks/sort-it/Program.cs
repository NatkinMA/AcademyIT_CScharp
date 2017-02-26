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
        private static bool DirectionSort(string direction)
        {
            return direction.Equals("-a") && !direction.Equals("-d");
        }

        private static bool IsBigOrEqual(string str1, string str2, string dataType)
        {
            if (dataType.Equals("-i"))
            {
                return int.Parse(str1) >= int.Parse(str2);
            }
            return str1.CompareTo(str2) >= 0;

        }

        private static void InsertionSort(List<string> ListString, string dataLine, string dataType, string direction)
        {
            int index = ListString.Count;
            while (index > 0 && IsBigOrEqual(ListString[index - 1], dataLine, dataType) && DirectionSort(direction))
            {
                index--;
            }
            ListString.Insert(index, dataLine);
        }

        private static void Help()
        {
            Console.WriteLine("\nSort-it.exe {inputfilename} {outputfilename} {-i|-s} {-a|-b}");
            Console.WriteLine("Сортировка целых чисел или строк из файла методом вставок. Входной файл должен содержать не более 100 строк.\n");
            Console.WriteLine("- infilename\tОбязательный параметр. Имя файла с данными для обработки.");
            Console.WriteLine("- outfilename\tОбязательный параметр. Имя файла с обработанными данными.");
            Console.WriteLine("- -i|-s\t\tОбязательный параметр. Тип сортируемы данных:\n\t\t-i - целые числа;\n\t\t-s - строки.");
            Console.WriteLine("- -a|-d\t\tОбязательный параметр. Направление сортировки данных:\n\t\t-a - по возрастанию;\n\t\t-d - по убыванию.");
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

            if (!args[2].Equals("-i") && !args[2].Equals("-s"))
            {
                Console.WriteLine("Неверно указан тип сортируемых данных.");
                Help();
                return;
            }

            if (!args[3].Equals("-a") && !args[3].Equals("-d"))
            {
                Console.WriteLine("Неверно указано направление сортировки данных.");
                Help();
                return;
            }

            List<string> ListStringOfFile = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(args[0]))
                {
                    string str;
                    while ((str = reader.ReadLine()) != null)
                    {
                        InsertionSort(ListStringOfFile, str, args[2], args[3]);
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
