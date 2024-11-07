using System;
using System.Linq;
Console.WriteLine("zad 3 Podaj 10 liczb:");
static void Zadanie3()
{
    double[] lista = new double[10];

    for (int indeks = 0; indeks < 10; indeks++)
    {
        double wartosc = WczytajDouble();
        lista[indeks] = wartosc;
    }

    Console.WriteLine("od pierwszego do ostatniego ");
    for (int indeks = 0; indeks < 10; indeks++)
    {
        Console.WriteLine(lista[indeks]);
    }

    Console.WriteLine("od ostatniego ");
    for (int indeks = 9; indeks >= 0; indeks--)
    {
        Console.WriteLine(lista[indeks]);
    }

    Console.WriteLine("nieparzyste indeksy ");
    for (int indeks = 0; indeks < 10; indeks++)
    {
        if (indeks % 2 != 0) Console.WriteLine(lista[indeks]);
    }

    Console.WriteLine("parzyste indeksy");
    for (int indeks = 0; indeks < 10; indeks++)
    {
        if (indeks % 2 == 0) Console.WriteLine(lista[indeks]);
    }
}

Zadanie3();


Console.WriteLine("zadanie 4 Podaj 10 liczb rzeczywistych: ");
static void Zadanie4()
{
    double[] lista2 = new double[10];

    for (int indeks = 0; indeks < 10; indeks++)
    {
        double wartosc = WczytajDouble();
        lista2[indeks] = wartosc;
    }

    Console.WriteLine($"Suma: {lista2.Sum()}");
    Console.WriteLine($"Iloczyn: {lista2.Aggregate(1.0, (a, b) => a * b)}");
    Console.WriteLine($"Średnia: {lista2.Average()}");
    Console.WriteLine($"minimum: {lista2.Min()}");
    Console.WriteLine($"Maximum: {lista2.Max()}");
}

Zadanie4();


static double WczytajDouble()
{

    double wartosc = Convert.ToDouble(Console.ReadLine());
    return wartosc;
}