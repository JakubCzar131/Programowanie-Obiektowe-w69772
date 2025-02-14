using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProgramPolski
{
    public class DanePopulacji
    {
        [JsonPropertyName("Year")]
        public int Rok { get; set; }
        [JsonPropertyName("USA")]
        public long USA { get; set; }
        [JsonPropertyName("India")]
        public long Indie { get; set; }
        [JsonPropertyName("China")]
        public long Chiny { get; set; }
    }

    public interface IPersonRepository
    {
        void DodajOsobe(Osoba osoba);
        List<Osoba> PobierzWszystkieOsoby();
        Osoba PobierzOsobePoId(Guid id);
        void AktualizujOsobe(Osoba osoba);
        void UsunOsobe(Guid id);
    }

    public record Osoba(Guid Id, string ImieNazwisko, int Wiek, string Email);

    public class RepozytoriumOsobPlikowe : IPersonRepository
    {
        private string sciezkaPliku;

        public RepozytoriumOsobPlikowe(string sciezka)
        {
            sciezkaPliku = sciezka;
            if (!File.Exists(sciezkaPliku))
            {
                File.Create(sciezkaPliku).Close();
            }
        }

        public void DodajOsobe(Osoba osoba)
        {
            string json = JsonSerializer.Serialize(osoba);
            File.AppendAllText(sciezkaPliku, json + Environment.NewLine);
        }

        public List<Osoba> PobierzWszystkieOsoby()
        {
            List<Osoba> listaOsob = new List<Osoba>();
            string[] linie = File.ReadAllLines(sciezkaPliku);
            foreach (string linia in linie)
            {
                if (linia.Trim() != "")
                {
                    try
                    {
                        Osoba o = JsonSerializer.Deserialize<Osoba>(linia);
                        if (o != null)
                        {
                            listaOsob.Add(o);
                        }
                    }
                    catch { }
                }
            }
            return listaOsob;
        }

        public Osoba PobierzOsobePoId(Guid id)
        {
            List<Osoba> lista = PobierzWszystkieOsoby();
            foreach (Osoba o in lista)
            {
                if (o.Id == id)
                {
                    return o;
                }
            }
            return null;
        }

        public void AktualizujOsobe(Osoba osoba)
        {
            List<Osoba> lista = PobierzWszystkieOsoby();
            bool znaleziono = false;
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Id == osoba.Id)
                {
                    lista[i] = osoba;
                    znaleziono = true;
                    break;
                }
            }
            if (znaleziono)
            {
                ZapiszWszystkie(lista);
            }
            else
            {
                throw new Exception("Nie znaleziono osoby o podanym Id.");
            }
        }

        public void UsunOsobe(Guid id)
        {
            List<Osoba> lista = PobierzWszystkieOsoby();
            lista.RemoveAll(o => o.Id == id);
            ZapiszWszystkie(lista);
        }

        private void ZapiszWszystkie(List<Osoba> lista)
        {
            using (StreamWriter writer = new StreamWriter(sciezkaPliku, false))
            {
                foreach (Osoba o in lista)
                {
                    string json = JsonSerializer.Serialize(o);
                    writer.WriteLine(json);
                }
            }
        }
    }

    class RekordPopulacji
    {
        public string Data { get; set; }
        public string Wartosc { get; set; }
        public string Kraj { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("MEnu:");
                Console.WriteLine("1. Zapis numeru albumu do pliku");
                Console.WriteLine("2. Odczyt zawartości pliku");
                Console.WriteLine("3. Liczenie żeńskich numerów PESEL");
                Console.WriteLine("4. Operacje na bazie danych populacji (nowa wersja)");
                Console.WriteLine("5. Operacje na repozytorium osób");
                Console.WriteLine("0. Wyjście");
                Console.Write("Wybierz opcję: ");
                string opcja = Console.ReadLine();

                if (opcja == "1")
                {
                    Zadanie1();
                }
                else if (opcja == "2")
                {
                    Zadanie2();
                }
                else if (opcja == "3")
                {
                    Zadanie3();
                }
                else if (opcja == "4")
                {
                    Zadanie4();
                }
                else if (opcja == "5")
                {
                    Zadanie5();
                }
                else if (opcja == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa");
                }
                Console.WriteLine();
            }
        }

        static void Zadanie1()
        {
            Console.Write("Podaj nazwę pliku do zapisu numeru albumu: ");
            string nazwaPliku = Console.ReadLine();
            string numerAlbumu = "w69772";

            try
            {
                File.WriteAllText(nazwaPliku, numerAlbumu);
                Console.WriteLine("Numer albumu został zapisany do pliku.");
            }
            catch (Exception wyjatek)
            {
                Console.WriteLine("Wystąpił błąd podczas zapisu: " + wyjatek.Message);
            }
        }

        static void Zadanie2()
        {
            Console.Write("Podaj nazwę pliku do odczytu: ");
            string nazwaPliku = Console.ReadLine();

            if (File.Exists(nazwaPliku))
            {
                try
                {
                    string zawartosc = File.ReadAllText(nazwaPliku);
                    Console.WriteLine("Zawartość pliku:");
                    Console.WriteLine(zawartosc);
                }
                catch (Exception wyjatek)
                {
                    Console.WriteLine("Wystąpił błąd podczas odczytu: " + wyjatek.Message);
                }
            }
            else
            {
                Console.WriteLine("Plik nie istnieje.");
            }
        }

        static void Zadanie3()
        {
            string nazwaPliku = "pesels.txt";

            if (!File.Exists(nazwaPliku))
            {
                Console.WriteLine("Plik pesels.txt nie istnieje.");
                return;
            }

            try
            {
                List<string> pesele = new List<string>(File.ReadAllLines(nazwaPliku));
                int liczbaKobiet = 0;

                foreach (var pesel in pesele)
                {
                    if (CzyKobieta(pesel))
                        liczbaKobiet++;
                }

                Console.WriteLine("Liczba żeńskich numerów PESEL: " + liczbaKobiet);
            }
            catch (Exception wyjatek)
            {
                Console.WriteLine("Wystąpił błąd: " + wyjatek.Message);
            }
        }

        static bool CzyKobieta(string pesel)
        {
            if (pesel.Length != 11)
                return false;

            if (int.TryParse(pesel[9].ToString(), out int cyfraPlec))
            {
                return cyfraPlec % 2 == 0;
            }
            return false;
        }

        static void Zadanie4()
        {
            string sciezkaPliku = "db.json";
            if (!File.Exists(sciezkaPliku))
            {
                Console.WriteLine("Plik db.json nie istnieje.");
                return;
            }

            var dane = WczytajDaneZPliku(sciezkaPliku);

            while (true)
            {
                Console.WriteLine("=== OPERACJE NA POPULACJI ===");
                Console.WriteLine("1. Różnica populacji Indii między 1970 a 2000");
                Console.WriteLine("2. Różnica populacji USA między 1965 a 2010");
                Console.WriteLine("3. Różnica populacji Chin między 1980 a 2018");
                Console.WriteLine("4. Wyświetl populację dla kraju i roku");
                Console.WriteLine("5. Sprawdź procentowy wzrost populacji");
                Console.WriteLine("0. Powrót do menu głównego");
                Console.Write("Wybierz opcję: ");
                string opcja = Console.ReadLine();

                if (opcja == "1")
                {
                    WyswietlRoznicePopulacji(dane, "India", 1970, 2000);
                }
                else if (opcja == "2")
                {
                    WyswietlRoznicePopulacji(dane, "United States", 1965, 2010);
                }
                else if (opcja == "3")
                {
                    WyswietlRoznicePopulacji(dane, "China", 1980, 2018);
                }
                else if (opcja == "4")
                {
                    Console.Write("Podaj kraj: ");
                    string kraj = Console.ReadLine();
                    Console.Write("Podaj rok: ");
                    if (int.TryParse(Console.ReadLine(), out int rok))
                        Console.WriteLine($"Populacja {kraj} w roku {rok}: {PobierzPopulacje(dane, kraj, rok)}");
                    else
                        Console.WriteLine("Nieprawidłowy format roku.");
                }
                else if (opcja == "5")
                {
                    Console.Write("Podaj kraj: ");
                    string krajWzrost = Console.ReadLine();
                    Console.Write("Podaj rok: ");
                    if (int.TryParse(Console.ReadLine(), out int rokWzrost))
                        WyswietlProcentowyWzrost(dane, krajWzrost, rokWzrost);
                    else
                        Console.WriteLine("Nieprawidłowy format roku.");
                }
                else if (opcja == "0")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa opcja.");
                }
                Console.WriteLine();
            }
        }

        static List<RekordPopulacji> WczytajDaneZPliku(string sciezkaPliku)
        {
            string jsonText = File.ReadAllText(sciezkaPliku);
            var jsonElements = JsonSerializer.Deserialize<List<JsonElement>>(jsonText);
            List<RekordPopulacji> rekordy = new List<RekordPopulacji>();
            foreach (var item in jsonElements)
            {
                var rekord = new RekordPopulacji
                {
                    Data = item.GetProperty("date").GetString(),
                    Wartosc = item.GetProperty("value").GetString(),
                    Kraj = item.GetProperty("country").GetProperty("value").GetString()
                };
                rekordy.Add(rekord);
            }
            return rekordy;
        }

        static long PobierzPopulacje(List<RekordPopulacji> dane, string kraj, int rok)
        {
            var rekord = dane.FirstOrDefault(d => d.Kraj == kraj && d.Data == rok.ToString());
            return rekord != null && rekord.Wartosc != null ? long.Parse(rekord.Wartosc) : 0;
        }

        static void WyswietlRoznicePopulacji(List<RekordPopulacji> dane, string kraj, int rok1, int rok2)
        {
            long pop1 = PobierzPopulacje(dane, kraj, rok1);
            long pop2 = PobierzPopulacje(dane, kraj, rok2);
            Console.WriteLine($"Różnica populacji {kraj} między {rok1} a {rok2}: {Math.Abs(pop2 - pop1)}");
        }

        static void WyswietlProcentowyWzrost(List<RekordPopulacji> dane, string kraj, int rok)
        {
            long populacjaAktualna = PobierzPopulacje(dane, kraj, rok);
            long populacjaPoprzednia = PobierzPopulacje(dane, kraj, rok - 1);
            if (populacjaPoprzednia == 0)
            {
                Console.WriteLine("Brak danych dla roku poprzedniego.");
                return;
            }
            double wzrost = ((double)(populacjaAktualna - populacjaPoprzednia) / populacjaPoprzednia) * 100;
            Console.WriteLine($"Procentowy wzrost populacji {kraj} w roku {rok} względem {rok - 1}: {wzrost:F2}%");
        }

        static void Zadanie5()
        {
            string sciezkaPliku = "osoby.txt";
            IPersonRepository repozytorium = new RepozytoriumOsobPlikowe(sciezkaPliku);
            while (true)
            {
                Console.WriteLine("OPERACJE NA REPOZYTORIUM ");
                Console.WriteLine("1. Dodaj osobę");
                Console.WriteLine("2. Wyświetl wszystkie osoby");
                Console.WriteLine("3. Znajdź osobę po Id");
                Console.WriteLine("4. Aktualizuj osobę");
                Console.WriteLine("5. Usuń osobę");
                Console.WriteLine("0. Powrót do menu głównego");
                Console.Write("Wybierz opcję: ");
                string opcja = Console.ReadLine();

                if (opcja == "1")
                {
                    DodajOsobe(repozytorium);
                }
                else if (opcja == "2")
                {
                    WyswietlWszystkieOsoby(repozytorium);
                }
                else if (opcja == "3")
                {
                    ZnajdzOsobePoId(repozytorium);
                }
                else if (opcja == "4")
                {
                    AktualizujOsobe(repozytorium);
                }
                else if (opcja == "5")
                {
                    UsunOsobe(repozytorium);
                }
                else if (opcja == "0")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa opcja.");
                }
                Console.WriteLine();
            }
        }

        static void DodajOsobe(IPersonRepository repo)
        {
            Console.Write("Podaj imię i nazwisko: ");
            string imieNazwisko = Console.ReadLine();
            Console.Write("Podaj wiek: ");
            if (!int.TryParse(Console.ReadLine(), out int wiek))
            {
                Console.WriteLine("Nieprawidłowy format wieku.");
                return;
            }
            Console.Write("Podaj email: ");
            string email = Console.ReadLine();
            Osoba nowaOsoba = new Osoba(Guid.NewGuid(), imieNazwisko, wiek, email);
            repo.DodajOsobe(nowaOsoba);
            Console.WriteLine("Dodano osobę: " + nowaOsoba);
        }

        static void WyswietlWszystkieOsoby(IPersonRepository repo)
        {
            var listaOsob = repo.PobierzWszystkieOsoby();
            if (listaOsob.Count == 0)
            {
                Console.WriteLine("Brak osób w repozytorium.");
                return;
            }
            Console.WriteLine("Wszystkie osoby:");
            foreach (var osoba in listaOsob)
            {
                Console.WriteLine(osoba);
            }
        }

        static void ZnajdzOsobePoId(IPersonRepository repo)
        {
            Console.Write("Podaj Id osoby: ");
            string idTekst = Console.ReadLine();
            if (Guid.TryParse(idTekst, out Guid id))
            {
                Osoba osoba = repo.PobierzOsobePoId(id);
                if (osoba == null)
                    Console.WriteLine("Nie znaleziono osoby o podanym Id.");
                else
                    Console.WriteLine(osoba);
            }
            else
            {
                Console.WriteLine("Nieprawidłowy format Id.");
            }
        }

        static void AktualizujOsobe(IPersonRepository repo)
        {
            Console.Write("Podaj Id osoby do aktualizacji: ");
            string idTekst = Console.ReadLine();
            if (Guid.TryParse(idTekst, out Guid id))
            {
                Osoba osoba = repo.PobierzOsobePoId(id);
                if (osoba == null)
                {
                    Console.WriteLine("Nie znaleziono osoby o podanym Id.");
                    return;
                }
                Console.Write("Podaj nowe imię i nazwisko: ");
                string noweImieNazwisko = Console.ReadLine();
                Console.Write("Podaj nowy wiek: ");
                if (!int.TryParse(Console.ReadLine(), out int nowyWiek))
                {
                    Console.WriteLine("Nieprawidłowy format wieku.");
                    return;
                }
                Console.Write("Podaj nowy email: ");
                string nowyEmail = Console.ReadLine();
                Osoba updated = new Osoba(osoba.Id, noweImieNazwisko, nowyWiek, nowyEmail);
                try
                {
                    repo.AktualizujOsobe(updated);
                    Console.WriteLine("Osoba została zaktualizowana.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Błąd aktualizacji: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowy format Id.");
            }
        }

        static void UsunOsobe(IPersonRepository repo)
        {
            Console.Write("Podaj Id osoby do usunięcia: ");
            string idTekst = Console.ReadLine();
            if (Guid.TryParse(idTekst, out Guid id))
            {
                try
                {
                    repo.UsunOsobe(id);
                    Console.WriteLine("Osoba została usunięta.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Błąd usuwania: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowy format Id.");
            }
        }
    }
}
