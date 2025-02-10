
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LeetCodeProblems.General
{
    public class ParseBuySell
    {
        /*
        
        
        Given a String of data in the format price:Symbol separated by "," (commas) eg :- 10.5:MSFT,200.2:AAPL,10.1:FCG

        Create a function called buyAndSell that will print the stock/s at the lowest price to buy and  print the stock/s at the highest price to sell given the input string.
        After processing the string data determine the lowest priced stock/s available to buy and the highest priced stock to sell available using the function mentioned above. 
        Print them in the output format mentioned below. In the case that multiple stocks are printed out, please print them in alphabetical order.

        Can your solution  be used to print  highest 2 or 3 and lowest 2 or 3 stocks as well? 
        Note: There can be duplicate stocks at the same price and we would like print all stocks at  the lowest buy price and the highest sell price.

        
        Output format :
        Buy : [AAPL] @ 4.0
        Sell : [MSFT] @ 10.0

        or 

        Buy : [AAPL, FCG] @ 4.0
        Sell : [F, MSFT, OIH] @ 10.0

    
        1. Sample Input :  200.1:AAPL,150.6:MSFT,10:T
        Output 
        Buy : [T] @ 10.0
        Sell : [AAPL] @ 200.1

        2. Sample Input :  200.1:AAPL,150.6:MSFT,10:T,200.1:VM
        Output 
        Buy : [T] @ 10.0
        Sell : [AAPL, VM] @ 200.1
            
     * Complete the 'buyAndSell' function below.
     *
     * The function accepts STRING data as parameter.
     */

        public static void buyAndSell(String data)
        {

            //10.5:MSFT,200.2:AAPL,10.1:FCG

            List<string> stockValues = data.Split(',').ToList();
            List<StockTickerWithPrice> stockTickers = new List<StockTickerWithPrice>();

            Dictionary<double, StockTickerWithPrice> priceToStock = new Dictionary<double, StockTickerWithPrice>();
            //Dictionary price : StockTickerWithPrice
            //

            foreach (var stockValue in stockValues)
            {
                List<string> values = stockValue.Split(':').ToList();
                var price = Double.Parse(values[0]);
                var ticker = values[1];
                //var currentStockTicker = new StockTickerWithPrice { Ticker = values[1] , Price = Double.Parse(values[0]) };
                if (priceToStock.ContainsKey(price))
                {
                    priceToStock[price].Tickers.Add(ticker);
                }
                else
                {
                    priceToStock.Add(price, new StockTickerWithPrice { Tickers = new List<string> { ticker }, Price = price });
                }
            }

            if (priceToStock.Any())
            {
                var toSell = priceToStock.MaxBy(kvp => kvp.Key);
                var toBuy = priceToStock.MinBy(kvp => kvp.Key);
                toBuy.Value.PrintBuy();
                toSell.Value.PrintSell();

                //There was a secondary question about buying/selling top2/3
                //priceToStock[Key[0]].PrintBuy();
                //.Sort
                //Sort CompareBy            
            }
        }

        public class StockTickerWithPrice
        {
            public List<string> Tickers { get; set; }
            public double Price { get; set; }


            public void PrintBuy()
            {
                Print("Buy");
            }

            public void PrintSell()
            {
                Print("Sell");
            }

            public void Print(string type)
            {
                Console.WriteLine($"{type} : [ {String.Join(",", Tickers.ToArray())} ] @ {Price} ");
            }

        }

        static void ParseBuySellMain(String[] args)
        {
            String input = Console.ReadLine();

            buyAndSell(input);
        }
    }
}
