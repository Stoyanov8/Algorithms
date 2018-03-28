using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 2 };
        var targetSum = 51;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var dict = new Dictionary<int, int>();
        var currentSum = 0;
        var index = 0;

        List<int> orederedCoins = coins.OrderByDescending(x => x).ToList();

        while (targetSum != currentSum && index < orederedCoins.Count)
        {
            var currentCoin = orederedCoins[index];

            var remaining = targetSum - currentSum;

            var coinsToTake = remaining / currentCoin;

            if (coinsToTake > 0)
            {
                dict.Add(currentCoin, coinsToTake);
            }
            currentSum += coinsToTake * currentCoin;

            index++;
        }

        if (targetSum != currentSum)
        {
            throw new InvalidOperationException("Greedy algorithm cannot produce desired sum with specified coins.");
        }

        return dict;
    }
}