namespace _06.Combinations_with_Repetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static string[] elements;
        private static string[] combination;

        private static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split()
                .ToArray();

            var combinations = int.Parse(Console.ReadLine());

            combination = new string[combinations];


            Combinate(0, 0);
        }

        private static void Combinate(int index, int start)
        {
            if (index >= combination.Length)
            {
                Console.WriteLine(string.Join(" ", combination));

            }
            else
            {
                for (int i = start; i < elements.Length; i++)
                {

                    combination[index] = elements[i];

                    Combinate(index + 1, i);

                }
            }

        }
    }
}
