using Lab2;
//Osoba osoba = new Osoba();
//osoba.FirstName = "Jan";
//osoba.LastName = "Nowak";
//osoba.Age = 20;
//osoba.View();

//Osoba osoba1 = new Osoba("Janina", "Kowalska", 23);
//osoba1.View();

// ZADANIE 1
//CreatePerson();
// ZADANIE 2
//CreateBankAccount();
// dziedziczenie
//Inheritance();

//void Inheritance()
//{
//    Student student = new Student("Jakub", "Czarnoita", 22, "w69772");
//    student.View();
//    student.ViewStudent();
//}

// ZADANIE 3
//CreateStudent();

//static void CreatePerson()
//{
//    Console.WriteLine("Podaj imię: ");
//    string firstName = Console.ReadLine();
//    Console.WriteLine("Podaj nazwisko: ");
//    string lastName = Console.ReadLine();
//    Console.WriteLine("Podaj wiek: ");
//    int age = int.Parse(Console.ReadLine());
//    Osoba osoba = new Osoba(firstName, lastName, age);
//    osoba.View();
//}

//static void CreateBankAccount()
//{
//    BankAccount konto = new BankAccount("Jan Kowalski", 1000);
//    konto.Deposit(500);
//    konto.View();
//    konto.Withdraw(200);
//    konto.View();
//    Console.WriteLine($"Saldo: {konto.Balance}");
//}

//static void CreateStudent()
//{
//    Student student = new Student("Kamil", "Pawlak");
//    student.AddGrade(4.5);
//    student.AddGrade(3);
//    Console.WriteLine(student.AverageGrade);
//}

// ZADANIE 4
//static void CreateNumber()
//{
//    Number number1 = new Number(4);
//    number1.Add(5);
//    number1.Subtract(3);
//    number1.GetValue();

//    Number number2 = new Number(-6.5);
//    number2.Add(5);
//    number2.Subtract(0.33);
//    number2.GetValue();

//    Number number3 = new Number(0);
//    number3.Add(3);
//    number3.Subtract(3.01);
//    number3.GetValue();
//}
//CreateNumber();

// ZADANIE 5
static void CreateSumator()
{
    Summator sumator = new Summator([1, 2, 3, 4, 5, 6]);
    Console.WriteLine($"Suma: {sumator.Suma()}");
    Console.WriteLine($"Suma podzielnych /2: {sumator.SumaPodziel2()}");
    Console.WriteLine($"Elementów: {sumator.IleElementow()}");
    sumator.PrintAll();
    sumator.PrintIndexRange(1, 3);
    sumator.PrintIndexRange(-1, 22);
}
CreateSumator();