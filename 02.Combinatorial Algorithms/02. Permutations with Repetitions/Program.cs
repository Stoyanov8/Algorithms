namespace _02.Permutations_with_Repetitions
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
            var usedSet = new HashSet<string> { elements[index] };

            Permute(index + 1);

            for (int i = index + 1; i < elements.Length; i++)
            {
                if (!usedSet.Contains(elements[i]))
                {
                    usedSet.Add(elements[i]);

                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                }

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
