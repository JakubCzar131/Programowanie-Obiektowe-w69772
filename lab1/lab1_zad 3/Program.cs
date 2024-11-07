using System;
Console.WriteLine("Podaj 10 liczb:");
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

static double WczytajDouble()
{
    
    double wartosc = Convert.ToDouble(Console.ReadLine());
    return wartosc;
}