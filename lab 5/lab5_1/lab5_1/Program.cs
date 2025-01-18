using System;
using System.Collections.Generic;

namespace std 
{
    enum Operacja
    {
        Dodawanie,
        Odejmowanie,
        Mnożenie,
        Dzielenie
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            List<double> historiaWynikow = new List<double>();
            bool czyKontynuowac = true;

            while (czyKontynuowac)
            {
                try
                {
                   
                    Console.Write("Podaj pierwszą liczbę: ");
                    double liczba1 = double.Parse(Console.ReadLine());

                    Console.Write("Podaj drugą liczbę: ");
                    double liczba2 = double.Parse(Console.ReadLine());

                    Console.Write("Wybierz opcje Dodawanie, Odejmowanie, Mnożenie, Dzielenie ");
                    string wyborUzytkownika = Console.ReadLine();

                    
                    Operacja wybranaOperacja = (Operacja)Enum.Parse(typeof(Operacja), wyborUzytkownika, true);

                   
                    double wynik = 0;
                    switch (wybranaOperacja)
                    {
                        case Operacja.Dodawanie:
                            wynik = liczba1 + liczba2;
                            break;
                        case Operacja.Odejmowanie:
                            wynik = liczba1 - liczba2;
                            break;
                        case Operacja.Mnożenie:
                            wynik = liczba1 * liczba2;
                            break;
                        case Operacja.Dzielenie:
                          
                            if (liczba2 == 0)
                            {
                                throw new DivideByZeroException("Nie można dzielić przez zero.");
                            }
                            wynik = liczba1 / liczba2;
                            break;
                    }

                 
                    Console.WriteLine($"Wynik operacji: {wynik}\n");
                    historiaWynikow.Add(wynik);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Błąd formatu liczby: {ex.Message}\n");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Błąd dzielenia przez zero: {ex.Message}\n");
                }
                catch (ArgumentException ex)
                {
                   
                    Console.WriteLine($"Błąd argumentu: {ex.Message}\n");
                }

                Console.Write("Czy chcesz wykonać kolejne działanie? (T/N): ");
                string odpowiedz = Console.ReadLine();
                if (!odpowiedz.Equals("T", StringComparison.OrdinalIgnoreCase))
                {
                    czyKontynuowac = false;
                }
                Console.WriteLine();
            }

          
            Console.WriteLine("Historia wyników:");
            if (historiaWynikow.Count == 0)
            {
                Console.WriteLine("Brak obliczeń do wyświetlenia.");
            }
            else
            {
                foreach (double w in historiaWynikow)
                {
                    Console.WriteLine(w);
                }
            }

            Console.WriteLine("Naciśnij dowolny klawisz, aby zamknąć.");
            Console.ReadKey();
        }
    }
}