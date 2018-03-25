using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static Stack<int> source;
    private static Stack<int> destination = new Stack<int>();
    private static Stack<int> spare = new Stack<int>();
    private static int step = 0;

    static void Main(string[] args)
    {
        int disks = int.Parse(Console.ReadLine());
        source = new Stack<int>(Enumerable.Range(1, disks).Reverse());
        Print();
        MoveDisks(disks, source, destination, spare);
    }

    private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
    {
        if (bottomDisk == 1)
        {
            step++;
            destination.Push(source.Pop());
            Console.WriteLine($"Step #{step}: Moved disk {bottomDisk}");
            Print();
        }
        else
        {
            MoveDisks(bottomDisk - 1, source, spare, destination);
            step++;
            destination.Push(source.Pop());
            Console.WriteLine($"Step #{step}: Moved disk {bottomDisk}");
            Print();
            MoveDisks(bottomDisk - 1, spare, destination, source);
        }
    }

    private static void Print()
    {
        Console.WriteLine($"Source: {String.Join(", ", source.Reverse())}");
        Console.WriteLine($"Destination: {String.Join(", ", destination.Reverse())}");
        Console.WriteLine($"Spare: {String.Join(", ", spare.Reverse())}");
        Console.WriteLine();
    }
}