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
    public class Person1
    {
        private string _name; // Name 2-100 characters long, not containing semicolons
        private int _age; // Age 0-150
        private string _city; // City 2-100 characters long, not containing semicolons

        public Person1(string name, int age, string city)
        {
            //setCity(city);
            //setAge(age);
            //Name.set(name);
        }



        public string Name
        {
            get { return _name; }
            set {
                if (verify(value, "name"))
                {
                    _name = value;

                }
            }

        }

        public int Age
        {
            get { return _age; }
            set {
                if (value < 0 || value > 150)
                {
                    throw new ArgumentException("Age 0-150.");
                }
                _age = value; 
            }

        }

        public string City
        {
            get { return _city; }
            set {
                if (verify(value, "city"))
                {
                    _city = value;

                }

            }

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
            string strAge = _age.ToString();
            return $"{_name};{strAge};{_city}";
        }

        public override string ToString()
        {
            string strAge = _age.ToString();
            return $"{_name} is {strAge} from {_city}. ";
        }
    }

}
