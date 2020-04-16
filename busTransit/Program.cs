using System;

namespace busTransit
{
    // Creating a constructor
    public class Passenger 
    {
        public string getName() { return name; }
        public string getSurname() { return surname; }
        public string getGender() { return gender; }
        public int getAge() { return age; }
        public string getOccupation() { return occupation; }
        
        // Private variables
        int age;
        string name;
        string surname;
        string gender;
        string occupation;

        // Creating the basic recipe for one passenger
        public Passenger(string Name, string Surname, string Gender, string Occupation, int Age) 
        {
            name = Name;
            surname = Surname;
            gender = Gender;
            age = Age;
            occupation = Occupation;
        }
    }
    class Buss 
    {
        // Creating an array which only fits 25 passengers
        public Passenger[] passengers = new Passenger[25]; 
        
        // Initial count is zero passengers
        int passengerCount = 0; 

        //------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Registering a new passenger
        public void addPassenger() 
        {
            // Creating a ternary operator which checks if the bus is full
            bool isFull = passengerCount == passengers.Length ? true : false; 
            
            // Clears all data above
            Console.Clear(); 
            int age = 0; 
            string gender = null; 
            string sname = null;
            string name = null;
            string occupation = null;

            // The code will run while the passengerCount is below 25
            if (!isFull) 
            {
                Console.WriteLine("------Registration-------");

                Console.Write("Your name: ");
                
                // Creating a while loop where the rest of the code can occur if the position in the array == null
                while (name == null) 
                {
                    string input = Console.ReadLine(); 
                    if (!Int32.TryParse(input, out int useless)) 
                        name = input; 
                    else
                        Console.WriteLine("Error: Invalid characters, try again."); 
                }

                Console.Write("Your surname: "); 
                while (sname == null)
                {
                    string input = Console.ReadLine();
                    if (!Int32.TryParse(input, out int useless))
                        sname = input;
                    else
                        Console.WriteLine("Error: Invalid characters, try again.");
                }

                Console.Write("Your Age: ");
                while (age == 0)
                {
                    // Checks if the input is between 1-99 and that the input isn't a string
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
                        occupation = input;
                    else
                        Console.WriteLine("Error: Invalid characters, try again.");
                }
                
                // Creating an instance of the type passenger
                Passenger newPassenger = new Passenger(name, sname, gender, occupation, age); 

                for (int i = 0; i < passengers.Length; i++)
                {
                    if (passengerCount != passengers.Length && passengers[i] == null)
                    {
                        passengers[i] = newPassenger; 
                        
                        // The passenger count gets increased by one
                        passengerCount++; 
                        break;
                    }
                }
                Console.WriteLine("\nRegistration: Successful! Here's the info given: ");
                
                // Printing out the passengers
                Console.WriteLine(name + " | " + sname + " | " + age + " | " + gender + " | " + occupation); 
            }
            else
                Console.Write("The bus is full, take the next one!"); 

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
                default:
                    Console.WriteLine("Error: Invalid characters, try again.");
                    break;
            }
            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
        }

        public void printBus()
        {
            Console.Clear();
            Console.WriteLine("---Passengers onboard----");

            // Prints out all passengers
            foreach (Passenger person in passengers) 
            {
                if (person != null)
                    Console.WriteLine(person.getName() + " | " + person.getSurname() + " | " + person.getGender() + " | " + person.getAge() + " | " + person.getOccupation());
            }

            // If there are no passengers onboard
            if (passengerCount <= 0) 
                Console.WriteLine("The bus is empty!");

            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
        }

        public void printGender()
        {
            Console.Clear();
            Console.WriteLine("---Passengers onboard----");
            int countF = 0; // Counts female passengers
            int countM = 0; // Counts male passengers

            foreach (Passenger person in passengers)
            {
                if (person != null) 
                {
                    if (person.getGender() == "Female") 
                    {
                        countF++; 
                       
                        // Prints out the position of the passenger
                        Console.WriteLine("Female sitting in seat: {0} \n", Array.IndexOf(passengers, person) + 1); 
                    }
                    else
                    {
                        countM++; 
                        // Prints out the position of the passenger
                        Console.WriteLine("Male sitting in seat: {0} \n", Array.IndexOf(passengers, person) + 1);
                    }
                }
            }
            
            // Printing out how many of each gender there are
            Console.Write("Females: {0} | Males: {1}", countF, countM); 

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
                default:
                    Console.WriteLine("Error: Invalid characters, try again.");
                    break;
            }
            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
        }

        public void getAverageAge()
        {
            Console.Clear();
            Console.WriteLine("--------Calculate--------");
            Console.Write("Average age on the bus: ");

            // Total age
            int ageCount = 0; 
            
            // Passenger count 
            int tempCount = 0; 
            foreach (Passenger person in passengers)
            {
                if (person != null)
                {
                    // Adds all the ages 
                    ageCount += person.getAge(); 
                    
                    // Adds how many passengers there are
                    tempCount++; 
                }
            }
            
            // The total number of all ages divided by how many passengers there are onboard
            ageCount = ageCount / tempCount; 

            Console.Write(ageCount); 
            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
        }

        public void getTotalAge()
        {
            Console.Clear();
            Console.WriteLine("--------Calculate--------");
            Console.Write("Total age on the bus: ");

            // Total age
            int ageCount = 0; 
            foreach (Passenger person in passengers)
            {
                if (person != null)
                    // Adds all the ages
                    ageCount += person.getAge(); 
            }

            Console.Write(ageCount); 
            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void sort()
        {
            Console.Clear();
            Console.WriteLine("---------Sort Bus--------");
            Console.WriteLine("What would you like to sort?");

            Console.WriteLine(" [A]ge");
            switch (Console.ReadLine())
            {
                case "A": // Supports uppercase
                    sortAge(); 
                    break;
                case "a": // Supports lowercase
                    sortAge();
                    break;
            }
            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
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
                    sortAgeDecending();
                    break;
                case "d":
                    sortAgeDecending();
                    break;
                default:
                    Console.WriteLine("Error: Invalid characters, try again.");
                    break;
            }
            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
        }
        public void sortAgeAscending()
        {
            Console.Clear();
            Console.WriteLine("---------Sort Age--------");

            // Creating a new array for the sorted list
            Passenger[] sortedListA = new Passenger[passengers.Length]; 
            int index = 0;

            foreach (Passenger unsortedPassenger in passengers)
            {
                // Puts all the passengers in a new array for sorting later
                sortedListA[index] = unsortedPassenger; 
                index++;
            }

            for (int i = 0; i < sortedListA.Length; i++)
                for (int j = 1; j < sortedListA.Length - 1; j++)
                {
                    // Checks if the sorted- and unsorted list isn't equal to null
                    if (sortedListA[i] != null && sortedListA[j] != null) 
                    {
                        if (sortedListA[j].getAge() < sortedListA[j - 1].getAge())
                        {
                            // swaps the elements
                            Passenger exPerson = sortedListA[j - 1];
                            sortedListA[j - 1] = sortedListA[j];
                            sortedListA[j] = exPerson;
                        }
                    }
                }

            foreach (Passenger age in sortedListA)
            {
                if (age != null)
                    Console.Write("{0}, ", age.getAge()); 
            }

            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
        }

        public void sortAgeDecending() 
        {
            Console.Clear();
            Console.WriteLine("---------Sort Age--------");
            
            Passenger[] sortedListD = new Passenger[passengers.Length];
            int index = 0;

            foreach (Passenger unsortedPassenger in passengers)
            {
                sortedListD[index] = unsortedPassenger;
                index++;
            }

            for (int i = 0; i < sortedListD.Length; i++)
                for (int j = 1; j < sortedListD.Length - 1; j++)
                {
                    if (sortedListD[i] != null && sortedListD[j] != null)
                    {
                        if (sortedListD[j].getAge() > sortedListD[j - 1].getAge())
                        {
                            Passenger exPerson = sortedListD[j];
                            sortedListD[j] = sortedListD[j - 1];
                            sortedListD[j - 1] = exPerson;
                        }
                    }
            }

            foreach (Passenger age in sortedListD)
            {
                if (age != null)
                {
                    Console.Write("{0}, ", age.getAge());
                }
            }

            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void findPassenger()
        {
            Console.Clear();
            Console.WriteLine("-----Find Passengers-----");

            int oAge = 0; // Oldest age
            int yAge = 0; // Youngest age

            if (passengerCount > 0)
            {
                Console.WriteLine("Whats the age range you're looking for? Begin by writing the highest age: ");
                while (oAge == 0)
                {
                    if (Int32.TryParse(Console.ReadLine(), out int tempAge) && tempAge > 0 && tempAge < 100)
                        oAge = tempAge;
                    else
                        Console.WriteLine("Error: Invalid age, try again.");
                }

                Console.WriteLine("\nAnd the lowest: ");
                while (yAge == 0)
                {
                    if (Int32.TryParse(Console.ReadLine(), out int tempAge) && tempAge > 0 && tempAge < 100)
                        yAge = tempAge;
                    else
                        Console.WriteLine("Error: Invalid age, try again.");
                }

                int minAge = Math.Min(oAge, yAge); // Compares the values and determines the lowest 
                int maxAge = Math.Max(oAge, yAge); // Compares the values and determines the highest 

                Console.WriteLine("\nThe passengers that fit into that age range are: {0} - {1}", minAge,
                    maxAge); 

                for (int i = 0; i < passengers.Length; i++)
                {
                    if (passengers[i] != null)
                    {
                        // Finds all the ages between the values given
                        if (passengers[i].getAge() >= minAge && passengers[i].getAge() <= maxAge && passengers[i].getAge() != 0) 
                            Console.WriteLine(passengers[i].getName() + " | " + passengers[i].getAge()); 
                    }
                }
            }
            else
                Console.WriteLine("The bus is empty.");

            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Did not get it to work, will come back to it later

        //public void nudgePassenger()
        //{
        //    Console.Clear();
        //    Console.WriteLine("-----Nudge Passenger-----");

        //    string[] vPhrases = {
        //        "Pleased to meet you.",
        //        "God bless you.",
        //        "Good evening love!"
        //    };

        //    string[] mPhrases = {
        //        "Hello!",
        //        "Hi",
        //        "Can i help you with something?",
        //        "Have a nice day!"
        //    };

        //    string[] yPhrases = {
        //        "Back off!",
        //        "What's crackin'?",
        //        "Don't touch me, thanks.",
        //        "Whazzup.",
        //        "What’s new?",
        //    };

        //    Random rnd = new Random();
        //    int pvIndex = rnd.Next(vPhrases.Length);
        //    int pmIndex = rnd.Next(mPhrases.Length);
        //    int pyIndex = rnd.Next(yPhrases.Length);

        //    Console.WriteLine("Here's a list of all the passengers onboard:");

        //    foreach (Passenger person in passengers)
        //    {
        //        if (person != null)
        //            Console.WriteLine("" + person.getName() + " | " + person.getSurname() + " | " + person.getGender() + " | " + person.getAge());
        //    }

        //    Console.WriteLine("\nWho would you like to give a nudge?");
        //    string pass = Console.ReadLine();

        //    for (int i = 0; i < passengers.Length; i++)
        //    {
        //        if (passengers[i] != null)
        //        {
        //            if (passengers[i].getAge() > 90)
        //            {
        //                Console.WriteLine("\n{0}: {1}", pass, vPhrases[pvIndex]);
        //            }
        //            else if (passengers[i].getAge() < 20)
        //            {
        //                Console.WriteLine("\n{0}: {1}", pass, yPhrases[pyIndex]);
        //            }
        //            else
        //            {
        //                Console.WriteLine("\n{0}: {1}", pass, mPhrases[pmIndex]);
        //            }
        //        }      
        //    }
        //    Console.ReadKey();
        //}

        //------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void getOff()
        {
            Console.Clear();
            Random rndPass = new Random();
            
            // Randomizes a passenger from the array
            int index = rndPass.Next(passengerCount); 

            if (passengerCount > 0 && passengers[index] != null)
            {
                // Prints out the removed passenger
                Console.WriteLine(passengers[index].getName() + " got off the bus."); 
                
                // Removes the random passenger
                Array.Clear(passengers, index, 1); 
                
                // reduces passengerCount by one
                passengerCount--; 
            }
            else
                Console.WriteLine("The bus is empty.");

            Console.ReadKey();
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
                Console.WriteLine(" [F]ind passenger by age");
                Console.WriteLine(" [S]ort passengers");
                //Console.WriteLine(" [N]udge passenger");
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
                        getCalculation();
                        break;

                    case "c":
                        getCalculation();
                        break;

                    case "F":
                        findPassenger();
                        break;

                    case "f":
                        findPassenger();
                        break;

                    case "S":
                        sort();
                        break;

                    case "s":
                        sort();
                        break;

                    case "N":
                        //nudgePassenger();
                        break;

                    case "n":
                        //nudgePassenger();
                        break;

                    case "G":
                        getOff();
                        break;

                    case "g":
                        getOff();
                        break;

                    case "E":
                        Environment.Exit(1);
                        break;

                    case "e":
                        Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("Error: Invalid characters, try again.");
                        break;
                }
            } while (choice != "0");
            Console.ReadKey();
            Console.Write("Press any key to return to the menu . . . ");
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
