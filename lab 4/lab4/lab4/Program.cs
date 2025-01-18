using Lab4;

public static class OsobaZad3Extensions
{
    public static void WritePersons(this List<IOsobaZad3> osoby)
    {
        foreach (var osoba in osoby)
        {
            osoba.GetFullName();
        }
    }

    public static void WritePersons(this List<IStudent> osoby)
    {
        foreach (var osoba in osoby)
        {
            Console.WriteLine(osoba.GetFullNameAndSchool());
        }
    }

    public static void SortByLastName(this List<IOsobaZad3> osoby)
    {
        osoby.Sort((o1, o2) => string.Compare(o1.LastName, o2.LastName, StringComparison.Ordinal));
    }
}

internal class Program
{
    static void Main()
    {
        // Zadanie 1
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Rectangle(10, 20, 30, 40));
        shapes.Add(new Triangle(15, 25, 35, 55));
        shapes.Add(new Circle(15, 55, 10));

        foreach (Shape shape in shapes)
        {
            shape.Draw();
        }

        // Zadanie 2
        Uczen uczen1 = new Uczen("Paweł", "Kozak", "59092865479", "Szkoła 2");
        Uczen uczen2 = new Uczen("Anna", "Bąk", "74071694369", "Szkoła 2");

        Nauczyciel nauczyciel = new Nauczyciel("Karol", "Dobrowolski", "86051073378", "Szkoła 2", "mgr", new List<Uczen> { uczen1, uczen2 });

        nauczyciel.WhichStudentCanGoHomeAlone(DateTime.Today);

        // Zadanie 3
        List<IOsobaZad3> osoby = new List<IOsobaZad3>
        {
            new OsobaZad3("Marek", "Kwiatkowski"),
            new OsobaZad3("Ewa", "Zielińska"),
            new OsobaZad3("Leszek", "Górski"),
        };
        osoby.WritePersons();

        osoby.SortByLastName();
        osoby.WritePersons();

        List<IStudent> students = new List<IStudent>
        {
            new StudentWSIiZ("Oliwia", "Maj", "IIZ", 2022, 3),
            new StudentWSIiZ("Zofia", "Nowak", "IID", 2022, 5),
        };

        students.WritePersons();
    }
}