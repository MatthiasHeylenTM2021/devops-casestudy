using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Animal
    {
        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        virtual public void printName()
        {
            Console.WriteLine("Animal name: {0}, Animal age: {1}", this.Name, this.Age);
        }
    }
}
