using System.Linq;
static void zad5()
{
    int[] skipNumbers = { 2, 6, 9, 15, 19 };
    for (int ilosc = 20; ilosc >= 0; ilosc--)
    {
        if (skipNumbers.Contains(ilosc)) continue;
        else Console.WriteLine(ilosc);
    }
}

zad5();
static void zadanie6()
{
    while (true)
    {
        int liczba = PobierzLiczbe();
        if (liczba < 0) break;
    }
}

zadanie6();

static int PobierzWartosc()
{
    Console.WriteLine("Wprowadź liczbę: ");
    int wartosc = Convert.ToInt32(Console.ReadLine());
    return wartosc;
}

static void WykonajSortowanie()
{
    int iloscElementow = PobierzLiczbe("Podaj ilość elementów do posortowania:");
    int[] tablica = new int[iloscElementow];

    for (int indeks = 0; indeks < iloscElementow; indeks++)
    {
        tablica[indeks] = PobierzLiczbe($"Element {indeks + 1}:");
    }

    SortowanieBabelkowe(tablica);

    Console.WriteLine("\nPosortowane liczby:");
    foreach (int liczba in tablica)
    {
        Console.WriteLine(liczba);
    }
}

WykonajSortowanie();

static int PobierzLiczbe(string komunikat = "Wprowadź liczbę: ")
{
    Console.Write($"{komunikat} ");
    int wartosc = Convert.ToInt32(Console.ReadLine());
    return wartosc;
}

static void SortowanieBabelkowe(int[] dane)
{
    int dlugosc = dane.Length;
    for (int i = 0; i < dlugosc - 1; i++)
    {
        for (int j = 0; j < dlugosc - i - 1; j++)
        {
            if (dane[j] > dane[j + 1])
            {
                int temp = dane[j];
                dane[j] = dane[j + 1];
                dane[j + 1] = temp;
            }
        }
    }
}
