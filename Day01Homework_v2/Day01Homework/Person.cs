using System;
/* *************************
    Create on Sep 29. 2022
    Create by Zeen
 * *************************/
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Day01Homework
{
    public class Person
    {
        private string name; // Name 2-100 characters long, not containing semicolons
        private int age; // Age 0-150
        private string city; // City 2-100 characters long, not containing semicolons

        public Person(string name, int age, string city)
        {
            setCity(city);
            setAge(age);
            setName(name);
        }

        public void setCity(string city)
        {
            try
            {
                if (verify(city, "city"))
                {
                    this.city = city;

                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void setName(string name)
        {
            try
            {
                if (verify(name, "name"))
                {
                    this.name = name;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void setAge(int age)
        {
            try
            {
                if (age < 0 || age > 150)
                {
                    throw new ArgumentException("Age 0-150.");
                }
                else
                {
                    this.age = age;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public string getName()
        {
            return name;
        }

        public int getAge()
        {
            return age;
        }

        public string getCity()
        {
            return city;
        }

        private bool verify(string str, string name)
        {
            if (str == null || str == "")
            {
                throw new ArgumentException($"{name} can not be empty.");

            }

            if (str.IndexOf(";") != -1)
            {
                throw new ArgumentException($"{name} not containing semicolons.");
            }

            if (str.Length < 2 || str.Length > 100)
            {
                throw new ArgumentException($"{name} need 2-100 characters long.");
            }

            return true;
        }
        public string ToString(string str)
        {
            string strAge = age.ToString();
            return $"{name};{strAge};{city}";
        }

        public override string ToString()
        {
            string strAge = age.ToString();
            return $"{name} is {strAge} from {city}. ";
        }
    }

}
