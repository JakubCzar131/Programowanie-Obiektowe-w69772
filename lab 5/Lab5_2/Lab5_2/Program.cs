using System;
using System.Collections.Generic;

namespace ZarzadzanieZamowieniami
{
    enum StatusZamowienia
    {
        Oczekujące,
        Przyjęte,
        Zrealizowane,
        Anulowane
    }

    class Program
    {
        private static Dictionary<int, List<string>> zamowienia = new Dictionary<int, List<string>>();
        private static Dictionary<int, StatusZamowienia> statusZamowien = new Dictionary<int, StatusZamowienia>();

        static void Main(string[] args)
        {
            DodajZamowienie(1, new List<string> { "Chleb", "Masło" });
            DodajZamowienie(2, new List<string> { "Cukier", "Herbata" });

            try
            {
                ZmienStatusZamowienia(1, StatusZamowienia.Przyjęte);
                ZmienStatusZamowienia(2, StatusZamowienia.Oczekujące);
                ZmienStatusZamowienia(2, StatusZamowienia.Oczekujące);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                ZmienStatusZamowienia(99, StatusZamowienia.Anulowane);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            WyswietlZamowienia();
            Console.ReadKey();
        }

        private static void DodajZamowienie(int numerZamowienia, List<string> produkty)
        {
            zamowienia[numerZamowienia] = produkty;
            statusZamowien[numerZamowienia] = StatusZamowienia.Oczekujące;
        }

        private static void ZmienStatusZamowienia(int numerZamowienia, StatusZamowienia nowyStatus)
        {
            if (!zamowienia.ContainsKey(numerZamowienia) || !statusZamowien.ContainsKey(numerZamowienia))
                throw new KeyNotFoundException($"Zamówienie o numerze {numerZamowienia} nie istnieje.");
            if (statusZamowien[numerZamowienia] == nowyStatus)
                throw new ArgumentException($"Zamówienie {numerZamowienia} ma już status '{nowyStatus}'.");
            statusZamowien[numerZamowienia] = nowyStatus;
            Console.WriteLine($"Status zamówienia {numerZamowienia} zmieniony na {nowyStatus}");
        }

        private static void WyswietlZamowienia()
        {
            if (zamowienia.Count == 0)
            {
                Console.WriteLine("Brak zamówień w systemie.");
                return;
            }

            foreach (var para in zamowienia)
            {
                int numer = para.Key;
                List<string> produkty = para.Value;
                StatusZamowienia status = statusZamowien[numer];
                Console.WriteLine($"Zamówienie nr {numer}");
                Console.WriteLine($"Status: {status}");
                Console.WriteLine("Produkty:");
                foreach (var p in produkty)
                {
                    Console.WriteLine($"- {p}");
                }
                Console.WriteLine();
            }
        }
    }
}
