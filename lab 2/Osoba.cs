using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Osoba
    {
        // definiowanie pól
        private string firstName;
        private string lastName;
        private int age;

        // właściwości (gettery, settery)
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length > 2) firstName = value;
                else Console.WriteLine("Imię musi posiadać co najmniej 2 znaki");
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length > 2) lastName = value;
                else Console.WriteLine("Nazwisko musi posiadać co najmniej 2 znaki");
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0) Console.WriteLine("Wiek nie może być liczbą ujemną");
                else age = value;
            }
        }

        // konstruktor
        //public Osoba()
        //{

        //}

        public Osoba(string firstName1, string lastName, int age)
        {
            this.firstName = firstName1;
            this.lastName = lastName;
            this.age = age;
        }


        public void View()
        {
            Console.WriteLine($"Imie:\t{firstName}\tNazwisko:\t{lastName}\tWiek:{age}");
        }
    }
}