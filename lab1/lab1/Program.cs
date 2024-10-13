
using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection.Metadata;
//Console.WriteLine("Hello, World!");
//Console.WriteLine("stoj"); // 

//int b = 34;
//double c = 34;
//short s = 1;

//long longbA = 121212121212121;
//char znak = 'a';
//string sumaa = "jan kowal";
//bool type = true;
//Console.WriteLine("Poda liczb");
////int number = Convert.ToUInt32(Console.ReadLine());
////Console.WriteLine("Podana liczba:" + number);


//int x = 2;

////string name = Console.ReadLine();

//for (int i = 0; i <= x; i++)
//{
//    Console.WriteLine(i);

//}
//int a = 1;

//while (a < 5) 
//{
//    Console.WriteLine(a);
//    a++;
//}
//do
//{
//    Console.WriteLine(a);
//    a++;
//}
//while (a < 5);

//for(int i=0;i<5;i++)
//{
//    Console.WriteLine(a);
//}
//string[] name = { "jan", "alina" };
//int[] number = { 1, 2, 3, 3 };
//Console.WriteLine(number[0]);
//Console.WriteLine("dlugosc tablicy: " + number.Length);
zadanie1();
static void zadanie1()
{
    // deklaracja zmiennych
    double a = doubleInput();
    double b = doubleInput();
    double c = doubleInput();
    double delta, x1, x2;

    if (a != 0)
    {
        delta = Math.Pow(b, 2) - (4 * a * c);
        if (delta < 0)
        {
            Console.WriteLine("Brak rozwiazania w zbiorze liczb rzeczywistych");
        }
        else if (delta == 0)
        {
            x1 = -b / (2 * a);
            Console.WriteLine("jedno rozwiazanie x1 = " + x1);
        }
        else
        {
            x1 = (-b - Math.Sqrt(delta)) / (2 * a);
            x2 = (-b + Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine("Dwa rozwiazania: \t x1 = " + x1 + "\t x2 = " + x2);
        }

    }
    else { Console.WriteLine("To nie jest równanie kwadratowe!"); }
}
static void zadanie2()
{
    Console.WriteLine("K A L K U L A T O R ")


}
static double doubleInput()
{
    Console.WriteLine("Podaj liczbe: ");
    double input = Convert.ToDouble(Console.ReadLine());
    return input;
}


