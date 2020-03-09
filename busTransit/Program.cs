using System;
using System.Linq;

namespace busTransit
{
    public class Passenger
    {
        public string getName() { return name; }
        public string getSurname() { return surname; }
        public string getGender() { return gender; }
        public int getAge() { return age; }
        public string getOccupation() { return occupation; }

        int age;
        string name;
        string surname;
        string gender;
        string occupation;

        public Passenger(string Name, string Surname, string Gender, string Occupation, int Age) //the basic recipe for one passenger
        {
            name = Name;
            surname = Surname;
            gender = Gender;
            age = Age;
            occupation = Occupation;
        }
    }

    class Buss // creating a class for bus
    {
        public Passenger[] passengers = new Passenger[25]; // this bus only fits 25 passengers
        int passengerCount = 0; // initial count is zero passengers

        //------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void addPassenger() // adding passenger
        {
            bool isFull = passengerCount == passengers.Length ? true : false; // creating a ternary operator 
            Console.Clear(); // clears all data above
            int age = 0; // age is set to zero
            string gender = null; // setting these to null (null refers to unassigned value)
            string sname = null;
            string name = null;
            string occupation = null;


            if (!isFull)
            {
                Console.WriteLine("------Registration-------");

                Console.Write("Your name: ");
                while (name == null) // creating a while loop 
                {
                    string input = Console.ReadLine(); // user input gets assigned to a string 
                    if (!Int32.TryParse(input, out int useless)) // checks if user input is a string aka letters and not numbers
                    {
                        name = input; // if the statement is true, 
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

                Console.Write("Your Age: ");
                while (age == 0)
                {
                    if (Int32.TryParse(Console.ReadLine(), out int tempAge) && tempAge > 0 && tempAge < 100)
                        age = tempAge;
                    else
                        Console.WriteLine("Error: Invalid age, try again.");
                }


                Console.WriteLine("Your gender: ");
                Console.WriteLine(" [F]emale");
                Console.WriteLine(" [M]ale");

                while (gender == null)
                {
                    switch (Console.ReadLine())
                    {
                        case "F":
                            gender = "Female";
                            break;
                        case "f":
                            gender = "Female";
                            break;
                        case "M":
                            gender = "Male";
                            break;
                        case "m":
                            gender = "Male";
                            break;
                        default:
                            Console.WriteLine("Error: Invalid characters, try again.");
                            break;
                    }
                }

                Console.WriteLine("Your Occupation: ");
                while (occupation == null)
                {
                    string input = Console.ReadLine();
                    if (!Int32.TryParse(input, out int useless))
                    {
                        occupation = input;
                    }
                    else
                        Console.WriteLine("Error: Invalid characters, try again.");
                }

                Passenger newPassenger = new Passenger(name, sname, gender, occupation, age);

                for (int i = 0; i < passengers.Length; i++)
                {
                    if (passengerCount != passengers.Length && passengers[i] == null)
                    {
                        passengers[i] = newPassenger;
                        passengerCount++;
                        break;
                    }
                }

                Console.WriteLine("\nRegistration: Successful! Here's the info given: ");
                Console.WriteLine(name + " | " + sname + " | " + age + " | " + gender + " | " + occupation);
            }
            else
            {
                Console.Write("The bus is full, take the next one!");
            }

            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------

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
            if (passengerCount <= 0)
                Console.WriteLine("The bus is empty!");

            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
        }

        public void printGender()
        {
            Console.Clear();
            Console.WriteLine("---Passengers onboard----");

            foreach (Passenger person in passengers)
            {
                if (person != null)
                {
                    var countF = person.getGender().Count(x => x == 'F');
                    var countM = person.getGender().Count(x => x == 'M');
                    Console.WriteLine(countF);
                }
            }

            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void getCalculation()
        {
            Console.Clear();
            Console.WriteLine("--------Calculate--------");
            Console.WriteLine(" [A]verage age");
            Console.WriteLine(" [T]otal age");

            switch (Console.ReadLine())
            {
                case "A":
                    getAverageAge();
                    break;
                case "a":
                    getAverageAge();
                    break;
                case "T":
                    getTotalAge();
                    break;
                case "t":
                    getTotalAge();
                    break;
            }
        }

        public void getAverageAge()
        {
            Console.Clear();
            Console.WriteLine("--------Calculate--------");
            Console.Write("Average age on the bus: ");

            int ageCount = 0;
            int tempCount = 0;
            foreach (Passenger person in passengers)
            {
                if (person != null)
                {
                    ageCount += person.getAge();
                    tempCount++;
                }
            }
            ageCount = ageCount / tempCount;

            Console.Write(ageCount);
            Console.ReadKey();
        }

        public void getTotalAge()
        {
            Console.Clear();
            Console.WriteLine("--------Calculate--------");
            Console.Write("Total age on the bus: ");

            int ageCount = 0;
            foreach (Passenger person in passengers)
            {
                if (person != null)
                {
                    ageCount += person.getAge();
                }
            }

            Console.Write(ageCount);
            Console.ReadKey();
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void sort()
        {
            Console.Clear();
            Console.WriteLine("---------Sort Bus--------");
            Console.WriteLine("What would you like to sort?");

            Console.WriteLine(" [A]ge");
            Console.WriteLine(" [N]ame");

            switch (Console.ReadLine())
            {
                case "A":
                    sortAge();
                    break;
                case "a":
                    sortAge();
                    break;
                case "N":
                    break;
                case "n":
                    break;
            }
        }

        public void sortAge()
        {
            Console.Clear();
            Console.WriteLine("---------Sort Age--------");
            Console.WriteLine("How would you want to sort the age?");

            Console.WriteLine(" [A]scending order");
            Console.WriteLine(" [D]ecending order");

            switch (Console.ReadLine())
            {
                case "A":
                    sortAgeAscending();
                    break;
                case "a":
                    sortAgeAscending();
                    break;
                case "D":
                    break;
                case "d":
                    break;
            }
        }

        public void sortAgeAscending()
        {
            Console.WriteLine("---------Sort Age--------");


        }

        public void sortAgeDecending()
        {

        }

        public void sortNameAlpha()
        {

        }

        public void sortNameReverse()
        {

        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------

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
                //Console.WriteLine(" [F]ind passenger by age");
                Console.WriteLine(" [S]ort passengers");
                //Console.WriteLine(" [N]udge passenger");
                //Console.WriteLine(" [G]et off");
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
                        getCalculation();
                        break;

                    case "c":
                        getCalculation();
                        break;

                    case "F":
                        break;

                    case "f":
                        break;

                    case "S":
                        sort();
                        break;

                    case "s":
                        sort();
                        break;

                    case "N":
                        sort();
                        break;

                    case "n":
                        sort();
                        break;

                    case "G":
                        sort();
                        break;

                    case "g":
                        sort();
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




