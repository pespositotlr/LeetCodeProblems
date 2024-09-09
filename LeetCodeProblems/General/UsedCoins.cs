using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


public class UsedCoins
{
    //From a coding test
    public static void UsedCoins_Main()
    {
        Coin[] coins;

        coins = new Coin[] { new Coin(1, 3), new Coin(5, 2)};
        Console.WriteLine("GetCoins(coins, 7)  → e:[1,2][5,1]     | a:" + GetCoins(coins, 7)?.ToPrettyPrint());

        coins = new Coin[] { new Coin(1, 7), new Coin(5, 2), new Coin(20, 4) };
        Console.WriteLine("GetCoins(coins, 24) → e:[1,4][20,1]    | a:" + GetCoins(coins, 24)?.ToPrettyPrint());

        coins = new Coin[] { new Coin(1, 3), new Coin(5, 2), new Coin(20, 4) };
        Console.WriteLine("GetCoins(coins, 24) →                  | a:" + GetCoins(coins, 24)?.ToPrettyPrint());

        coins = new Coin[] { new Coin(1, 17), new Coin(20, 4) };
        Console.WriteLine("GetCoins(coins, 16) → e:[1,16]         | a:" + GetCoins(coins, 16)?.ToPrettyPrint());
    }

    // Given a set of coins with certain denominations and count,
    // implement the method below to find the minimum number of coins
    // required to make up a targetAmount.
    // If it's not possible to make up the targetAmount using the given denominations, return null.
    public static Coin[]? GetCoins(Coin[] coins, int targetAmount)
    {
        List<(int Denomination, int Count)> orderedCoins = new List<(int Denomination, int Count)>();
        //Start with higher denominations and go down to lower
        for (int i = 0; i < coins.Length; i++)
        {
            orderedCoins.Add((coins[i].Denomination, coins[i].Count));
        }

        orderedCoins.OrderBy(x => x.Denomination);

        var currentRemainingValue = targetAmount;
        Dictionary<int, int> usedCoins = new Dictionary<int, int>();
        foreach (var orderedCoin in orderedCoins)
        {
            //Subtract higher-denomination coins first
            var currentCoinCount = orderedCoin.Count;
            //Will stop this coin if you run out of coins of this denomination or your coint is done
            while (currentCoinCount > 0 && currentRemainingValue > 0)
            {
                currentRemainingValue = currentRemainingValue - orderedCoin.Denomination;
                currentCoinCount--;

                //if contains this denomination, then +1 the count
                //if not, add new denomination
                if (usedCoins.ContainsKey(orderedCoin.Denomination))
                {
                    usedCoins[orderedCoin.Denomination]++;
                }
                else
                {
                    usedCoins.Add(orderedCoin.Denomination, 1);
                }

                if (currentRemainingValue == 0)
                {
                    //You're done. Turn the dictionary into an array of Coins
                    var result = new Coin[usedCoins.Count()];
                    int i = 0;
                    foreach(var usedCoin in usedCoins)
                    {
                        result[i] = new Coin(usedCoin.Key, usedCoin.Value);
                        i++;
                    }                        
                    return result;
                }
            }
        }

        return null;
    }
}


public record Coin(int Denomination, int Count);


public static class CoinExtns
{
    public static string ToPrettyPrint(this Coin[] coins)
     => string.Join("", coins.Select(c => $"[{c.Denomination},{c.Count}]"));
}