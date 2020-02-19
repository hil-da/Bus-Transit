using System;
namespace busTransit
{
    public class Passenger
    {
        public string getName() { return name; }
        public string getSurname() { return surname; }
        public string getGender() { return gender; }
        public int getAge() { return age; }

        int age;
        string name;
        string surname;
        string gender;

        public Passenger(string Name, string Surname, int Age, string Gender)
        {
            name = Name;
            surname = Surname;
            gender = Gender;
            age = Age;
        }
    }

    class Buss
    {
        public Passenger[] passengers = new Passenger[25];
        bool isFull = false;

        public void addPassenger()
        {
            Console.Clear();
            int age = 0;
            string gender = null;
            string sname = null;
            string name = null;
            int female = 0;
            int male = 0;


            if (!isFull)
            {
                Console.WriteLine("------Registration-------");
                Console.Write("Your name: ");
                while (name == null)
                {
                    string input = Console.ReadLine();
                    if (!Int32.TryParse(input, out int useless))
                    {
                        name = input;
                    }
                    else
                        Console.WriteLine("Error: Invalid characters, try again.");
                }

                Console.Write("Your surname: ");
                while (sname == null)
                {
                    string input = Console.ReadLine();
                    if (!Int32.TryParse(input, out int useless))
                    {
                        sname = input;
                    }
                    else
                        Console.WriteLine("Error: Invalid characters, try again.");
                }

                Console.WriteLine("Your gender: ");
                Console.WriteLine(" [F]emale");
                Console.WriteLine(" [M]ale");
                switch (gender = Console.ReadLine())
                {
                    case "F":
                        gender = "Female";
                        female++;
                        break;
                    case "f":
                        gender = "Female";
                        female++;
                        break;
                    case "M":
                        gender = "Male";
                        male++;
                        break;
                    case "m":
                        gender = "Male";
                        male++;
                        break;
                }

                Console.Write("Your Age: ");
                while (age == 0)
                {
                    if (Int32.TryParse(Console.ReadLine(), out int tempAge) && tempAge > 0 && tempAge < 100)
                        age = tempAge;
                    else
                        Console.WriteLine("Error: Invalid age, try again.");
                }

                Passenger newPassenger = new Passenger(name, sname, age, gender);

                for (int i = 0; i < passengers.Length; i++)
                {
                    if (passengers[i] == null)
                    {
                        passengers[i] = newPassenger;
                        break;
                    }
                    else
                        isFull = true;
                }

                Console.WriteLine("\nRegistration: Successful! Here's the info given: ");
                Console.WriteLine(name + " | " + sname + " | " + age + " | " + gender);
            }
            else
            {
                Console.Write("The bus is full, take the next one!");
            }

            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
        }

        public void print()
        {
            Console.Clear();
            Console.WriteLine("----------Print----------");
            Console.WriteLine(" [B]us");
            Console.WriteLine(" [G]ender");

            switch (Console.ReadLine())
            {
                case "B":
                    printBus();
                    break;
                case "b":
                    printBus();
                    break;
                case "G":
                    printGender();
                    break;
                case "g":
                    printGender();
                    break;
            }
        }

        public void printBus()
        {
            Console.Clear();
            Console.WriteLine("---Passengers onboard----");

            foreach (Passenger person in passengers)
            {
                if (person != null)
                    Console.WriteLine(person.getName() + " | " + person.getSurname() + " | " + person.getGender() + " | " + person.getAge());
            }

            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
        }

        public void printGender()
        {
            Console.WriteLine("---Passengers onboard----");

        {

            }

            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
        }



        public void Run()
        {
            string choice;

            do
            {
                Console.Clear();
                Console.WriteLine("----------Menu-----------");
                Console.WriteLine(" [A]dd a new passenger");
                Console.WriteLine(" [P]rint...");
                Console.WriteLine(" [C]alculate...");
                Console.WriteLine(" [F]ind passenger by age");
                Console.WriteLine(" [S]ort passengers");
                Console.WriteLine(" [N]udge passenger");
                Console.WriteLine(" [G]et off");
                Console.WriteLine(" [E]xit application");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "A":
                        addPassenger();
                        break;

                    case "a":
                        addPassenger();
                        break;

                    case "P":
                        print();
                        break;

                    case "p":
                        print();
                        break;

                    case "C":
                        break;

                    case "c":
                        break;

                    case "E":
                        Environment.Exit(1);
                        break;

                    case "e":
                        Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("Error, try again");
                        break;
                }
            }
            while (choice != "0");
        }

        public static void Main(string[] args)
        {
            var minbuss = new Buss();
            minbuss.Run();
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}




