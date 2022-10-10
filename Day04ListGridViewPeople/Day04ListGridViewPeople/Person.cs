using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04ListGridViewPeople
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {

        }

        public Person (string name, int age)
        {
            Name = name;
            Age = age;
        }

        public bool IsNameValid(string name)
        {
            return !(name.Length < 2 || name.Length > 50 || name.Contains(";"));
        }

        public bool IsAgeValid(int age)
        {
            return !(age < 0 || age > 50);
        }

        public override string ToString()
        {
            return $"{Name} is {Age.ToString()} y/o.";
        }

        public string ToString(string save)
        {
            return $"{Name};{Age.ToString()}";
        }
    }
}
