namespace _01.Recursion
{
    using System;
    using System.Linq;

    class Program
    {
        //Returns the sum of all elements
        private static int Sum(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            return arr[index] + Sum(arr, index + 1);
        }

        //Returns the factorial of 'n'
        private static int Factorial(int n)
        {
            if (n == 1 || n == 0)
            {
                return 1;
            }
            var number = n * Factorial(n - 1);
            return number;
        }

        //Drawing '*' in descending order then '#' in ascending
        private static void Draw(int n)

        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));
            Draw(n - 1);
            Console.WriteLine(new string('#', n));
        }

        //Generate binary array with length 'n'
        private static void GenerateVector(int[] arr, int index)
        {
            if (arr.Length <= index)
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }
            for (int i = 0; i <= 1; i++)
            {
                arr[index] = i;

                GenerateVector(arr, index + 1);
            }
        }

        //Gets all combinations of numbers
        private static void GetCombinations(int[] set, int[] vector, int index, int border)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(String.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GetCombinations(set, vector, index + 1, i + 1);
                }
            }
        }

        private static void Main(string[] args)
        {
            var set = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var length = int.Parse(Console.ReadLine());

            var vector = new int[length];

            GetCombinations(set, vector, 0, 0);
        }
    }
}