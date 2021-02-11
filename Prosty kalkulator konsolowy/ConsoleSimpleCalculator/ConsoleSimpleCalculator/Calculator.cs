using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSimpleCalculator
{
    class Calculator
    {
        public Calculator()
        {
            Menu();
        }

        public void Menu()
        {
            //inicjalizacja zmiennych
            int a = 0;
            int b = 0;

            //pobranie danych i wybór działania
            Console.WriteLine("Podaj liczbę a:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj liczbę b:");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wybierz działanie:");
            Console.WriteLine("1 - Dodawanie");
            Console.WriteLine("2 - Odejmowanie");
            Console.WriteLine("3 - Mnożenie");
            Console.WriteLine("4 - Dzielenie");
            switch (Console.ReadLine())
            {
                case "1": Console.WriteLine("Wynik sumowania: " + Sum(a, b)); break;
                case "2": Console.WriteLine("Wynik odejmowania: " + Substract(a, b)); break;
                case "3": Console.WriteLine("Wynik mnożenia: " + Multiplication(a, b)); break;
                case "4": if (b != 0) Console.WriteLine("Wynik dzielenia: " + Division(a, b)); else Console.WriteLine("Dzielenie przez 0"); break;
                default: Console.WriteLine("Opcja nie istnieje"); break;
            }

            //pauza
            Console.ReadKey();
        }

        public float Sum(float a, float b) { return a + b; }

        public float Substract(float a, float b) { return a - b; }

        public float Multiplication(float a, float b) { return a * b; }

        public float Division(float a, float b) { return a / b; }
    }
}
