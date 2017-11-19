using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<int> myAL = new ArrayList<int>();

            Console.WriteLine("Новый пустой список: {0}. Размер списка: {1}.", myAL, myAL.Count);

            myAL.Add(5);
            myAL.Add(9);
            myAL.Add(15);
            myAL.Add(25);
            myAL.Add(29);
            myAL.Add(215);
            myAL.Add(315);
            myAL.Add(325);
            myAL.Add(329);
            myAL.Add(3215);
            myAL.Add(4215);
            Console.WriteLine("Добавили в список элементы \"5, 9, 15, 25, 29, 215, 315, 325, 329, 3215, 4215\": {0}. Размер списка: {1}.", myAL, myAL.Count);

            myAL.RemoveAt(1);
            Console.WriteLine("Удалили из списка элемент с индексом \"1\": {0}. Размер списка: {1}.", myAL, myAL.Count);

            myAL.Insert(1, 42);
            Console.WriteLine("Вставили в список элемент с индексом \"1\": {0}. Размер списка: {1}.", myAL, myAL.Count);

            if (myAL.Remove(42))
            {
                Console.WriteLine("Удалили из списка элемент \"42\": {0}. Размер списка: {1}.", myAL, myAL.Count);
            }

            myAL = new ArrayList<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);

            Console.WriteLine("Новый список: {0}. Размер списка: {1}.", myAL, myAL.Count);

            ArrayList<string> myStringAL = new ArrayList<string>(capacity: 25);

            Console.WriteLine("Новый пустой список размерностью 25 элементов: {0}.", myStringAL);
            
            Console.WriteLine("Для выхода нажмите Утеук...");
            Console.ReadLine();
        }
    }
}
