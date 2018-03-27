namespace _03.Variations_without_Repetitions
{
    using System;
    using System.Linq;

    class Program
    {
        private static string[] elements;
        private static string[] variaty;
        private static bool[] usedElements;

        private static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split()
                .ToArray();
            var combinations = int.Parse(Console.ReadLine());
            variaty = new string[combinations];
            usedElements = new bool[elements.Length];
            Variate(0);
        }

        private static void Variate(int index)
        {
            if (index >= variaty.Length)
            {
                Console.WriteLine(string.Join(" ", variaty));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!usedElements[i])
                {
                    usedElements[i] = true;
                    variaty[index] = elements[i];

                    Variate(index + 1);
                    usedElements[i] = true;
                }
               
            }
        }
    }
}
