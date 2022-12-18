using System;
using System.Security.Cryptography.X509Certificates;

namespace test
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name = "C#";
            bool test = true;
            int integer = 5;
            double pi = 3.14;
            char leuk = 'B';
            double integerPi = (double)integer + pi;
            int convertedDouble = 12;
            convertedDouble = Convert.ToInt32(integerPi);

            int mySwitch = 3;

            switch (mySwitch) {
                case 1:
                    Console.WriteLine("Case 1");
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
            }

            int[,] myArray = new int[,] { { 1, 2 }, { 3, 4 } };
            foreach (int i in myArray)
            {
                Console.WriteLine(i);
            }

            List<int> myList = new List<int>();
            myList.Add(123);
            myList.Add(442);

            foreach(int number in myList)
            {
                Console.WriteLine(number);
            }

            Animal hond = new Animal("Boris", 15);
            hond.printName();
            Console.WriteLine("Hello, " + name + "!");
            Console.WriteLine("Hello, {0}{1}!", name, name);
            Console.WriteLine($"Hello, {name}!");
            Console.WriteLine("The number: " + integerPi + " is an instance of " + integerPi.GetType());

            string path = "C:\\My Documents\\";
            path = @"C:\My Documents\";
        }
    }
}