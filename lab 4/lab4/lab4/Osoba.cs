using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab4
{
    internal abstract class Osoba
    {
        protected string firstName;
        protected string lastName;
        protected string pesel;

        public void SetFirstName(string firstName) { this.firstName = firstName; }
        public void SetLastName(string lastName) { this.lastName = lastName; }

        public void SetPesel(string pesel)
        {
            
            if (string.IsNullOrWhiteSpace(pesel))
            {
                throw new ArgumentException("Numer PESEL nie może być pusty ani zawierać wyłącznie białych znaków.");
            }

            // 2. Sprawdzenie długości ciągu (powinien mieć 11 znaków)
            if (pesel.Length != 11)
            {
                throw new ArgumentException("Numer PESEL musi zawierać dokładnie 11 cyfr.");
            }

            // 3. Sprawdzenie, czy wszystkie znaki są cyframi
            if (!Regex.IsMatch(pesel, @"^\d{11}$"))
            {
                throw new ArgumentException("Numer PESEL może zawierać wyłącznie cyfry.");
            }

            // 4. Walidacja sumy kontrolnej PESEL
            //    Wzór obliczania sumy kontrolnej:
            //    (9×p1 + 7×p2 + 3×p3 + 1×p4 + 9×p5 + 7×p6 + 3×p7 + 1×p8 + 9×p9 + 7×p10) mod 10
            //    powinno być równe p11 (ostatniej cyfrze PESEL).
            int[] wagi = { 9, 7, 3, 1, 9, 7, 3, 1, 9, 7 };
            int sumaKontrolna = 0;

            // p1..p10
            for (int i = 0; i < 10; i++)
            {
                sumaKontrolna += (pesel[i] - '0') * wagi[i];
            }

            int cyfraKontrolna = sumaKontrolna % 10;
            int ostatniaCyfra = pesel[10] - '0';

            if (cyfraKontrolna != ostatniaCyfra)
            {
                throw new ArgumentException("Numer PESEL jest nieprawidłowy – niezgodna suma kontrolna.");
            }

            // Jeśli wszystkie warunki są spełnione, PESEL jest prawidłowy
            this.pesel = pesel;
        }

        public int GetAge(DateTime? dateToCheck = null)
        {
            if (string.IsNullOrWhiteSpace(pesel) || pesel.Length != 11)
            {
                throw new InvalidOperationException("Nieprawidłowy numer PESEL");
            }

            int year = int.Parse(pesel.Substring(0, 2));
            int month = int.Parse(pesel.Substring(2, 2));
            int day = int.Parse(pesel.Substring(4, 2));

            int century;

            if (month > 20)
            {
                century = 2000;
                month -= 20;
            }
            else
            {
                century = 1900;
            }

            int fullYear = century + year;

            DateTime dateOfBirth;
            try
            {
                dateOfBirth = new DateTime(fullYear, month, day);
            }
            catch
            {
                throw new InvalidOperationException("Numer PESEL zawiera nieprawidłową datę");
            }

            DateTime checkedDate = dateToCheck ?? DateTime.Today;
            int age = checkedDate.Year - dateOfBirth.Year;
            if (checkedDate < dateOfBirth.AddYears(age))
            {
                age--;
            }

            return age;
        }
        public string GetGender()
        {
            if (string.IsNullOrWhiteSpace(pesel) || pesel.Length != 11)
            {
                throw new InvalidOperationException("Nieprawidłowy numer PESEL");
            }

            return Convert.ToInt32(pesel[9]) % 2 == 0 ? "kobieta" : "mężczyzna";
        }

        public abstract void GetEducationInfo();
        public virtual void GetFullName()
        {
            Console.WriteLine($"{firstName} {lastName}");
        }
        public abstract void CanGoAloneToHome();

        public Osoba(string firstName, string lastName, string pesel)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            SetPesel(pesel);
        }
    }
}
