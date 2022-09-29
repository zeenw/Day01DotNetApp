using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01DotNetConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name? ");
            string name = Console.ReadLine();
            Console.WriteLine("What is your age? ");
            string strAge = Console.ReadLine();

            /*
            try
            {
                int age = int.Parse(strAge);
                //Console.WriteLine("Hello " + name + "! You are " + age + " y/o! ");
                Console.WriteLine($"Hello {name}! You are {age} y/o! ");


            } catch(FormatException e)
            {
                Console.WriteLine("Invalid numerical input.");
            }
            Console.ReadKey();

            */

            try
            {
                if (int.TryParse(strAge, out int age)) 
                {
                    Console.WriteLine($"Hello {name}! You are {age} y/o! ");
                }
                else
                {
                    Console.WriteLine("Invalid numerical input.");
                }

                if (name.ToLower() == "santa")
                {
                    Console.WriteLine("I can not believe that. ");
                }
            }
            finally
            {
                Console.ReadKey();
            }
            

        }
    }
}
