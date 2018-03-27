namespace _01.Permutations_without_Repetitions
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static string[] elements;
        private static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ');
            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < elements.Length; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);

            }
        }
        private static void Swap(int index, int i)
        {
            var temp = elements[index];
            elements[index] = elements[i];
            elements[i] = temp;
        }

    }
}
