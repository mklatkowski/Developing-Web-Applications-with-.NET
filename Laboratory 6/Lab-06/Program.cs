using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tuple = ("Michał", "Klatkowski", 21, 875.32F);
            var anonymous_type = new { name = "Michał", lastName = "Klatkowski", age = 21, salary = 875.32F };

            excercise01(tuple);
            excercise02();
            excercise03();
            excercise04(anonymous_type);

            DrawCard("Michał");
            DrawCard("Michał", "Klatkowski", 'P', 3, 40);
            DrawCard("Michał", lastName: "Kowal", width: 5);

            Console.WriteLine(CountMyTypes(5, "string", 6, 4.4, 5.5F));
        }

        static void excercise01((string, string, int, float) tuple)
        {

            //1 sposób - przez typowaną krotkę
            (string name, string lastName, int age, float salary) = tuple;
            Console.WriteLine($"{name}, {lastName}, {age}, {salary}");

            //2 sposób - deklarowanie nazwanej krotki
            (string Name, string LastName, int Age, float Salary) dataTuple = tuple;
            Console.WriteLine($"{dataTuple.Name}, {dataTuple.LastName}, {dataTuple.Age}, {dataTuple.Salary}");

            //3 sposób - dostęp na podstawie numerowanych własności
            Console.WriteLine($"{tuple.Item1}, {tuple.Item2}, {tuple.Item3}, {tuple.Item4}");
        }

        static void excercise02()
        {
            int @class = 6;
            Console.WriteLine(@class);
        }

        static void excercise03()
        {
            int[] array = {6, 8, 4, 6};

            //Array.IndexOf
            Console.WriteLine(Array.IndexOf(array, 6));

            //Array.Sort
            Array.Sort(array);
            Console.WriteLine(string.Join(", ", array));

            //Array.Resize
            Array.Resize(ref array, 5);
            array[4] = 2;
            Console.WriteLine(string.Join(", ", array));

            //Array.Reverse
            Array.Reverse(array);
            Console.WriteLine(string.Join(", ", array));

            //Array.Clear
            Array.Clear(array, 0, 2);
            Console.WriteLine(string.Join(", ", array));

        }

        static void excercise04(dynamic anonymous_type)
        {
            var name = anonymous_type.name;
            var lastName = anonymous_type.lastName;
            var age = anonymous_type.age;
            var salary = anonymous_type.salary;

            Console.WriteLine(name + " " + lastName + " " + age + " " + salary);

        }

        static void DrawCard(string name, string lastName = "Kowalski", char symbol = 'O', int width = 2, int minCardWidth = 20)
        {
            int longerCharLength = Math.Max(name.Length, lastName.Length);
            int numOfSpaces = longerCharLength;

            if ((longerCharLength + 2*width) >= minCardWidth)
            {
                minCardWidth = longerCharLength + 2 * width;
            }
            else
            {
                numOfSpaces = minCardWidth - 2 * width;
            }

            int availableSpacesName = numOfSpaces - name.Length;
            double spacesNameLeft = Math.Floor((double)availableSpacesName / 2);
            double spacesNameRight = availableSpacesName - (int)spacesNameLeft;

            int availableSpacesLastName = numOfSpaces - lastName.Length;
            double spacesLastNameLeft = Math.Floor((double)availableSpacesLastName / 2);
            double spacesLastNameRight = availableSpacesLastName - (int)spacesLastNameLeft;

            WriteRow(symbol, width, minCardWidth);

            WriteWidth(symbol, width); ;
            WriteWidth(' ', (int)spacesNameLeft);
            Console.Write(name);
            WriteWidth(' ', (int) spacesNameRight);
            WriteWidth(symbol, width);

            Console.WriteLine();

            WriteWidth(symbol, width);
            WriteWidth(' ', (int)spacesLastNameLeft);
            Console.Write(lastName);
            WriteWidth(' ', (int)spacesLastNameRight);
            WriteWidth(symbol, width);

            Console.WriteLine();

            WriteRow(symbol, width, minCardWidth);

            Console.WriteLine();
        }

        private static void WriteRow(char symbol, int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
        }

        private static void WriteWidth(char symbol, int width) {
            for (int i = 0; i < width; i++)
            {
                Console.Write(symbol);
            }
        }

        static (int, int, int, int) CountMyTypes(params object[] list)
        {
            int intCount = 0;
            int doubleCounter = 0;
            int stringCounter = 0;
            int otherCounter = 0;

            for(int i=0; i<list.Length; i++) {
                switch(list[i]) {
                    case int value when value % 2 == 0:
                        intCount++;
                        break;

                    case double value when value > 0:
                        doubleCounter++;
                        break;

                    case string value when value.Length > 5:
                        stringCounter++;
                        break;

                    default:
                        otherCounter++;
                        break;
                }
            }
            return (intCount, doubleCounter, stringCounter, otherCounter);
        }
    }
}
