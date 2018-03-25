using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseSolutions
{
    class Program
    {
        //Reversing printing array
        private static void ReverseArray(string[] array, int index)
        {
            if (index < 0)
            {
                return;
            }
            Console.Write(array[index] + ' ');
            ReverseArray(array, index - 1);
        }

        //Simulation 'n' numbers of loops and printing combinations from 1 to 'loops size'
        private static void SimulateNestedLoops(int loops, int[] arr, int n)
        {
            if (loops == n)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;

            }
            else
            {
                for (int i = 1; i <= loops; i++)
                {
                    arr[n] = i;
                    SimulateNestedLoops(loops, arr, n + 1);
                }
            }

        }

        //Get all combinations only once a.k.a if we get '1 3' we should skip '3 1'
        private static void CombinationsWithRepetitions(int[] arr, int maxVal, int index = 0, int num = 1)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = num; i <= maxVal; i++)
            {
                arr[index] = i;
                CombinationsWithRepetitions(arr, maxVal, index + 1, i);
            }
        }

        //Get all non-duplicate combinations a.k.a skip '1 1' , '2 2' etc. 
        private static void CombinationsWithoutRepetitions(int[] arr, int maxValue, int index = 0, int num = 1)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = num; i <= maxValue; i++)
            {
                arr[index] = i;
                CombinationsWithoutRepetitions(arr, maxValue, index + 1, i + 1);
            }
        }

        private static void Main(string[] args)
        {
           
        }
    }
}
