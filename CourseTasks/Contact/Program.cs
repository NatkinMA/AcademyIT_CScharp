using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа демонстрирующая работу с классом Contact");
            // Console.ReadLine();

            Contact objContact01 = new Contact("Иван", "Иванов", "+79991234567");
            
            Contact objContact02 = new Contact();
            objContact02.Name = "Петр";
            objContact02.Surname = "Петров";
            objContact02.PhoneNumber = "+79992345678";

            Console.WriteLine("Контакт № 1: {0} {1}, тел.: {2}", objContact01.Name, objContact01.Surname, objContact01.PhoneNumber);
            Console.WriteLine("Контакт № 2: {0} {1}, тел.: {2}", objContact02.Name, objContact02.Surname, objContact02.PhoneNumber);

            Console.WriteLine("Для завершения работы программы нажмите клавишу Утеук...");
            Console.ReadLine();
        }
    }
}
