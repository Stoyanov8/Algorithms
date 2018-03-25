using System;

namespace BinarySearh
{
    class Program
    {
        private static void Main(string[] args)
        {
            var arr = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.Write("Number to search in the collection: ");
            var number = int.Parse(Console.ReadLine());

            var index = Search(arr, 0, arr.Length - 1,number);

            Console.WriteLine(index == -1 ? $"{number} is not present in the collection" : $"{number} is at {index} position in the collection");
        }

        private static int Search(int[] arr, int startIndex, int endIndex, int number )
        {
            if (startIndex >= endIndex)
            {
                return -1;
            }

            int middleIndex = (startIndex + endIndex) / 2;

            if (arr[middleIndex] > number)
            {
                return Search(arr, startIndex, middleIndex,number);

            }
            else if (arr[middleIndex] < number)
            {
                return Search(arr, middleIndex + 1, endIndex,number);
            }
            else
            {
                return middleIndex;
            }
        }

    }
}
