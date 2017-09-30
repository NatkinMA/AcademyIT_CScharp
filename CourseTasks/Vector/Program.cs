using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Vector vector1 = new Vector(10);
                Console.WriteLine(vector1.ToString());
                Console.WriteLine("Размер вектора: {0}.", vector1.Size);
                Vector vector2 = new Vector(1.2, 1.3);
                Console.WriteLine(vector2.ToString());
                Console.WriteLine("Размер вектора: {0}.", vector2.Size);
                Vector vector3 = new Vector(vector2);
                Console.WriteLine(vector3.ToString());
                Console.WriteLine("Размер вектора: {0}.", vector3.Size);
                Vector vector4 = new Vector(5, 1.7, 1.9, 2.2);
                Console.WriteLine(vector4.ToString());
                Console.WriteLine("Размер вектора: {0}.", vector4.Size);
                Console.WriteLine("Умножение вектора на скаляр k = 2,3.");
                vector4.Multiplication(2.3);
                Console.WriteLine(vector4.ToString());
                Console.WriteLine("Размер вектора: {0}.", vector4.Size);
                Console.WriteLine("Разворачиваем вектор.");
                vector4.Revert();
                Console.WriteLine(vector4.ToString());
                Console.WriteLine("Размер вектора: {0}.", vector4.Size);
                Console.WriteLine("Длина вектора: {0}.", vector4.Length);
                Console.WriteLine("Значение компоненты вектора с индексом 1: {0}", vector4[1]);
                vector4[4] = 6.7;
                Console.WriteLine("Устанавливаем компонент вектора с индексом 4: {0}", vector4[4]);
                Console.WriteLine("Складываем два вектора ({0}) и ({1}) с помощью статического метода.", vector2.ToString(), vector4.ToString());
                Vector vector5 = Vector.Addition(vector2, vector4);
                Console.WriteLine("Суммарный вектор: {0}", vector5.ToString());
                Console.WriteLine("Прибавляем к вектору ({0}) вектор ({1}).", vector2.ToString(), vector4.ToString());
                vector2.Add(vector4);
                Console.WriteLine("Получившийся вектор: ({0})", vector2.ToString());
                Console.WriteLine("Вычитаем из вектора ({0}) вектор ({1}).", vector2.ToString(), vector4.ToString());
                vector2.Subtract(vector4);
                Console.WriteLine("Получившийся вектор: ({0})", vector2.ToString());
                Console.WriteLine("Скалярное произведение вектора ({0}) и вектора ({1}) равно {2}.", vector2.ToString(), vector4.ToString(), Vector.ScalarProduct(vector2, vector4));
                Console.WriteLine("Сравнение вектора ({0}) и вектора ({1}): {2}.", vector2.ToString(), vector4.ToString(), vector2.Equals(vector4).ToString());
                Console.WriteLine("Сравнение вектора ({0}) и вектора ({1}): {2}.", vector2.ToString(), vector2.ToString(), vector2.Equals(vector2).ToString());
                Vector vector6 = new Vector(1.2, 1.3);
                Vector vector7 = new Vector(1.2, 1.3);
                Console.WriteLine("Сравнение вектора ({0}) и вектора ({1}): {2}.", vector7.ToString(), vector6.ToString(), vector7.Equals(vector6).ToString());
                Console.WriteLine("Хэш-код вектора ({0}) = ({1}).", vector2.ToString(), vector2.GetHashCode());
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine(exception);
            }
            Console.WriteLine("Для выхода нажмите Утеук...");
            Console.ReadLine();
        }
    }
}
