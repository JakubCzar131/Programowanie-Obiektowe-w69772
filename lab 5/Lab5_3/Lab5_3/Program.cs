//using System;
using System.Collections.Generic;

namespace ZgadywanieKolorow
{
    enum Kolor
    {
        Czerwony,
        Niebieski,
        Zielony,
        Żółty,
        Fioletowy
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Kolor> kolory = new List<Kolor>
            {
                Kolor.Czerwony,
                Kolor.Niebieski,
                Kolor.Zielony,
                Kolor.Żółty,
                Kolor.Fioletowy
            };

            Random rand = new Random();
            Kolor wylosowanyKolor = kolory[rand.Next(kolory.Count)];
            bool odgadniety = false;

            while (!odgadniety)
            {
                Console.Write("Zgadnij kolor: ");
                string input = Console.ReadLine();

                try
                {
                    Kolor podanyKolor = (Kolor)Enum.Parse(typeof(Kolor), input, true);

                    if (!kolory.Contains(podanyKolor))
                        throw new ArgumentException("Kolor nie znajduje się na liście.");

                    if (podanyKolor == wylosowanyKolor)
                    {
                        Console.WriteLine("Gratulacje, odgadłeś kolor!");
                        odgadniety = true;
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowa odpowiedź. Spróbuj ponownie.\n");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadKey();
        }
    }
}
