
class Person
{
    private string _name;
    private int _pay;

    public Person(string n, int p)
    {
        _name = n;
        _pay = p;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetPay()
    {
        return _pay;
    }
}

class Register
{
    private List<Person> _register = new List<Person>();

    public void AddPerson(Person p)
    {
        _register.Add(p);
    }

    public List<Person> GetPersons()
    {
        return (_register);
    }
}

class PersonalRegister
{
    private static Register _register = new Register();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Ditt val. Lägg till eller visa dina anställda:");
            Console.WriteLine("n: Ny anställd");
            Console.WriteLine("v: Visa registret");
            Console.WriteLine("q: Avsluta");

            try
            {
                string val = Console.ReadLine();
                switch (val)
                {
                    case "n":
                        NewEmployee();
                        break;
                    case "v":
                        ListEmployees();
                        break;
                    case "q":
                        Console.WriteLine("Adjö");
                        System.Environment.Exit(1);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(("Attans. Fel inmatning " + e.Message));
            }
        }
    }

    private static void NewEmployee()
    {
        Console.WriteLine("Namn:");

        try
        {
            string namn = Console.ReadLine();
            Console.WriteLine("Och stackarens lön:");
            int lon = Int32.Parse(Console.ReadLine());

            _register.AddPerson(new Person(namn, lon));
        }
        catch (Exception e)
        {
            Console.WriteLine("Nu har du matat in tokigt: " + e.Message);
        }
    }

    private static void ListEmployees()
    {
        int n = 1;
        Console.WriteLine("Dina anställda:");
        foreach (var p in _register.GetPersons())
        {
            Console.WriteLine(n++ + ": " + p.GetName() + ", lön: " + p.GetPay());
        }
    }
}