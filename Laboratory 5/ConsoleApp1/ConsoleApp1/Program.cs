using System;
using System.Xml.XPath;

namespace ConsoleEmpty
{
    class Program
    {
        static void Main(string[] args)
        {

            double a;
            double b;
            double c;


            getValues(out a,out b, out c);
            List<double> results = result(a, b, c);
            printResults(results);

        }

        static void getValues(out double a, out double b, out double c)
        {
            while (true)
            {
                Console.Write("Podaj wartość a: ");
                try
                {
                    a = double.Parse(Console.ReadLine());
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Zła wartość, podaj ponownie");
                }
            }

            while (true)
            {
                Console.Write("Podaj wartość b: ");
                try
                {
                    b = double.Parse(Console.ReadLine());
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Zła wartość, podaj ponownie");
                }
            }

            while (true)
            {
                Console.Write("Podaj wartość c: ");
                try
                {
                    c = double.Parse(Console.ReadLine());
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Zła wartość, podaj ponownie");
                }
            }
        }

        static List<double> result(double a, double b, double c)
        {
            List<double> results = new List<double>();
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                    {
                        return null;
                    }
                    else
                    {
                    }
                    
                }
                else
                {
                    results.Add(-c / b);
                }
            }
            else
            {
                double delta = Math.Pow(b, 2) - 4 * a * c;
                if (delta > 0)
                {
                    double result1 = (-b + delta) / (2 * a);
                    double result2 = (-b - delta) / (2 * a);
                    results.Add(result1);
                    results.Add(result2);
                }
                else if (delta == 0)
                {
   
                    results.Add(-b / (2 * a));
                }
                else
                {
                }
            }
            return results;
        }

        static void printResults(List<double> results)
        {
            if (results == null)
            {
                Console.WriteLine("Jest nieskończenie wiele rozwiązań");
            }
            else if(results.Count == 0)
            {
                Console.WriteLine("Brak rozwiązań");
            }
            else
            {
                Console.WriteLine("Rozwiązania: ");
                for(int i=0; i<results.Count; i++)
                {
                    Console.WriteLine(results[i]);  
                }
            }
        }
    }
}
