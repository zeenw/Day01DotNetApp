/* *************************
    Create on Sep 29. 2022
    Create by Zeen
 * *************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Day01Homework
{
    internal class Program
    {
        static List<Person> people = new List<Person>();
        const string FILE = "person.txt";

        static void Main(string[] args)
        {
            ReadAllPeopleFromFile();
            menu();
        }

        static void menu()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Add person info");
            Console.WriteLine("2. List persons info");
            Console.WriteLine("3. Find and list a person by name");
            Console.WriteLine("4. Find and list persons younger than age");
            Console.WriteLine("0. Exit");
            Console.WriteLine("*******************************************");

            try
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("");
                        Console.WriteLine("Enter name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter age:");
                        string age = Console.ReadLine();
                        Console.WriteLine("Enter city:");
                        string city = Console.ReadLine();
                        if (!int.TryParse(age, out int result))
                        {
                            Console.WriteLine("Age cannot be identified.");
                            return;
                        }

                        if (verify(name) && verify(city))
                        {
                            AddPersonInfo(new Person(name, int.Parse(age), city));
                        }
                        else
                        {
                            Console.WriteLine("Name and City will be 2-100 characters long, not containing semicolons");
                        }
                        break;

                    case "2":
                        Console.WriteLine("");
                        ListAllPersonsInfo();
                        break;

                    case "3":
                        Console.WriteLine("");
                        Console.WriteLine("Enter partial person name:");
                        string name3 = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine("Matches found:");
                        FindPersonByName(name3);
                        break;

                    case "4":
                        Console.WriteLine("");
                        Console.WriteLine("Enter maximum age:");
                        string strAge = Console.ReadLine();
                        if (!int.TryParse(strAge, out int rs))
                        {
                            Console.WriteLine("Age cannot be identified.");
                            return;
                        }
                        else
                        {
                            FindPersonYoungerThan(int.Parse(strAge));
                        }
                        break;

                    case "0":
                        SaveAllPeopleToFile();
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Invalid choice try again.");
                        break;

                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
                menu();
            }


        }

        static void ReadAllPeopleFromFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(FILE))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] arr = line.Split(';');
                        Person person = new Person(arr[0], int.Parse(arr[1]), arr[2]);
                        people.Add(person);
                    }
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static void AddPersonInfo(Person person)
        {
            people.Add(person);
            Console.WriteLine("Person added.");
        }
        static void ListAllPersonsInfo()
        {
            int count = 0;
            foreach (Person person in people)
            {
                count++;
                Console.WriteLine(count + ". " + person.ToString());

            }

        }
        static void FindPersonByName(string name)
        {
            bool isFound = false;
            foreach (Person person in people)
            {
                if ((name.ToLower()).Equals((person.getName()).ToLower()))
                {
                    Console.WriteLine(person.ToString());
                    isFound = true;
                }
            }
            if (!isFound)
                Console.WriteLine($" * {name} is not fond.");
        }

        static void FindPersonYoungerThan(int age)
        {
            bool isFound = false;
            int count = 0;
            foreach (Person person in people)
            {
                if (person.getAge() <= age)
                {
                    count++;
                    Console.WriteLine(count + ". " + person.ToString());
                    isFound = true;
                }
            }
            if (!isFound)
                Console.WriteLine($" * No people is younger than {age}.");
        }

        static void SaveAllPeopleToFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FILE))
                {
                    foreach (Person person in people)
                    {
                        sw.WriteLine(person.ToString("save"));
                    }   
                    sw.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static bool verify(string str)
        {
            if (str == null || str == "")
            {
                return false;

            }

            if (str.IndexOf(";") != -1)
            {
                return false;
            }

            if (str.Length < 2 || str.Length > 100)
            {
                return false;
            }

            return true;
        }

    }
}
