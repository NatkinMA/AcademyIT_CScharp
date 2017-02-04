using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact
{
    class Contact
    {
        // Поля класса Contact
        private string strName;
        private string strSurname;
        private string strPhoneNumber;

        // Конструктор класса Contact
        public Contact(string strName, string strSurname, string strPhoneNumber)
        {
            this.strName = strName;
            this.strSurname = strSurname;
            this.strPhoneNumber = strPhoneNumber;
        }

        public Contact()
        { }

        // Геттеры и сеттеры класса Contact
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        public string Surname
        {
            get { return strSurname; }
            set { strSurname = value; }
        }

        public string PhoneNumber
        {
            get { return strPhoneNumber; }
            set { strPhoneNumber = value; }
        }
    }
}
