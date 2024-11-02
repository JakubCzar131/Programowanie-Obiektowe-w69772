
using System.ComponentModel.Design;
using System.Globalization;

using System.Numerics;

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
//zadanie1();

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

static double doubleInput()
{
    throw new NotImplementedException();
}

menu();
static void menu()
{
ViewMenu:
    Console.WriteLine("K A L K U L A T O R ");
    Console.WriteLine("1.Suma\n2 Różnica\n3 iloczyn\n4  iloraz\n5  Potegowanie\n6 Pierwiastek\n7 Funkcje trygonometryczne\n8 Wyjście");
    Console.WriteLine("WYbierz Opcje: ");
    int choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1: Total(); break;
        case 2: Diference(); break;
        // case 3: ProductNumber(); break;
        // case 4: QuationNumber(); break;
        //  case 5: PotentationNumber(); break;
        //   case 6: SquareNumber(); break;
        //  case 7: TrigonNumber(); break;
        case 8: Close(); break;
        default: Console.WriteLine("bledny wyor wybierz jeszcze raz opcje"); goto ViewMenu;
    }

    static void zadanie2()
    {
        Console.WriteLine("K A L K U L A T O R ");





        static double doubleInput()
        {
            Console.WriteLine("Podaj liczbe: ");
            double input = Convert.ToDouble(Console.ReadLine());
            return input;
        }



        static void Total()
        {
            double a = doubleInput();
            double b = doubleInput();
            Console.WriteLine($"różnica wynosi {a}+{b}");
        }


        static void Diference()
        {
            double a = doubleInput();
            double b = doubleInput();
            Console.WriteLine($"różnica wynosi {a}-{b}");
        }


        static void Close()
        {
            Console.WriteLine("koniec programu");
            System.Environment.Exit(1);
        }
    }
}

