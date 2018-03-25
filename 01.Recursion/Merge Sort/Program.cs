using System;

namespace Merge_Sort
{
    class Program
    {
        private static void Main(string[] args)
        {
            var numbers = new[] 
            { 7, 64, 46, 0, 5, 90, 44, 12, 47, 84, 65, 4, 60, 90, 39, 27, 74, 4, 68, 89, 91,
                7, 59, 54, 18, 37, 55, 68, 62, 9, 27, 51, 85, 99, 68, 12, 10, 2, 69, 10, 33, 5,
                50, 91, 44, 99, 86, 46, 93, 24, 75, 51, 87, 47, 8, 7, 91, 33, 60, 79, 32, 55, 32,
                62, 39, 80, 50, 33, 51, 38, 64, 14, 25, 29, 48, 94, 72, 27, 42, 2, 1, 43, 68, 45, 30,
                14, 67, 73, 68, 50, 79, 85, 86, 3, 70, 22, 30, 43, 62, 78 };


            Sort(numbers, 0, numbers.Length - 1);

            Console.WriteLine(string.Join(",", numbers));
        }

        private static void Sort(int[] numbers, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int middleIndex = (startIndex + endIndex) / 2; //get the middle index of the array

            Sort(numbers, startIndex, middleIndex); //left portion of the array

            Sort(numbers, middleIndex + 1, endIndex); //right portion of the array

            Merge(numbers, startIndex, middleIndex, endIndex); // merge all together
        }

        private static void Merge(int[] numbers, int startIndex, int middleIndex, int endIndex)
        {
            if (middleIndex < 0 ||
                 middleIndex + 1 >= numbers.Length
                 || numbers[middleIndex] <= numbers[middleIndex + 1])
            {
                return;
            }
            int[] tempArray = new int[numbers.Length];

            Array.Copy(numbers, tempArray, numbers.Length);

            int leftIndex = startIndex;
            int rightIndex = middleIndex + 1;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (leftIndex > middleIndex)
                {
                    numbers[i] = tempArray[rightIndex++];
                }

                else if (rightIndex > endIndex)
                {
                    numbers[i] = tempArray[leftIndex++];
                }
                else if (tempArray[leftIndex] <= tempArray[rightIndex])
                {
                    numbers[i] = tempArray[leftIndex++];
                }
                else
                {
                    numbers[i] = tempArray[rightIndex++];
                }
            }
        }
    }
}
