using System;
using System.Collections.Generic;
using System.IO;

namespace List
{
    class Program
    {
        private static void Help()
        {
            Console.WriteLine("\nЧтение данных из файла в список. Удаление четных элементов. Создание нового списка с неповторяющимися элементами.\n");
            Console.WriteLine("List.exe {filename}");
            Console.WriteLine("- filename\tОбязательный параметр. Имя файла с данными для обработки.");
        }

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Неверно указан входной параметр.");
                Help();
                return;
            }

            if (args[0].Equals("-help"))
            {
                Help();
                return;
            }
            
            List<int> ListIntOfFile = new List<int>();
            try
            {
                using (StreamReader reader = new StreamReader(args[0]))
                {
                    string currentLine;
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        ListIntOfFile.Add(int.Parse(currentLine));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удалось прочитать файл:");
                Console.WriteLine(e.Message);
            }
           

            for(int index = ListIntOfFile.Count; index > 0; index--)
            {
                if ((ListIntOfFile[index - 1] % 2) == 0)
                {
                    ListIntOfFile.RemoveAt(index - 1);
                }
            }

            List<int> ListWithoutRepeats = new List<int>();
            foreach(int number in ListIntOfFile)
            {
                if (!ListWithoutRepeats.Contains(number))
                {
                    ListWithoutRepeats.Add(number);
                }
            }

            foreach(int currentLine in ListIntOfFile)
            {
                Console.WriteLine(currentLine);
            }

            Console.WriteLine();

            foreach (int number in ListWithoutRepeats)
            {
                Console.WriteLine(number);
            }
        }
    }
}
