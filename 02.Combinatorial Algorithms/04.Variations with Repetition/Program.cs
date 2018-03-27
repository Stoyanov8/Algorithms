namespace _04.Variations_with_Repetitions
{
    using System;
    using System.Linq;

    class Program
    {
        private static string[] elements;
        private static string[] variaty;

        private static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split()
                .ToArray();
            var combinations = int.Parse(Console.ReadLine());
            variaty = new string[combinations];
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
                variaty[index] = elements[i];

                Variate(index + 1);

            }
        }
    }
}
