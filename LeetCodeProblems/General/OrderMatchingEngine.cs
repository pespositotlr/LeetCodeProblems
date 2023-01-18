using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems.General
{
        //From a HackerRank test
        //The full instructions can be found at github.com/maringantis/OrderMatchingEngine

        //static void Main(String[] args)
        //{
        //    /* Enter your code here. Read input using Console.ReadLine. Print output using Console.WriteLine. Your class should be named Solution */

        //    //Create objects for each of the types (BUY/SELL/CANCEL/MODIFY/PRINT)
        //    //Create an Order Book object that holds a list of Operations
        //    //Do logic for printing existing Order Book
        //    //Do logic for buying/selling (Include GFD and IOC types)
        //    //Do TRADE printing for buying/selling
        //    ////These are all selling the same "stock" so buys/sells apply to all
        //    ////A MATCH occurs when the BUY price is higher or equal to the SELL price. Then these items are TRADED
        //    ////Prioritize the order that was added first if they have the same price
        //    ////If they have different prices, use the BETTER one, prioritize the lower SELL and higher BUY
        //    ////If two matching values exist, exhaust the BETTER one first then proceed to the less BETTER one to exhaust the rest of the QUANITTIY
        //    ////When an item is MODIFIED it goes to the end of the order.

        //    //Order of BUY and SELL matter, but MODIFY/cANCEL can also potentially matter even though that's not in the instructions, 
        //    //if you tried to MODIFY/CANCEL something after it was matched

        //    //I think it just has to run through them as they come in. "Print" doesn't care about Cancel/Modify.

        //    //Get Inputs
        //    List<string> inputs = new List<string>();

        //    string inputLine = " ";

        //    while ((inputLine = Console.ReadLine()) != null && inputLine != "")
        //    {
        //        inputs.Add(inputLine);
        //    }

        //    var engine = new OrderMatchingEngine(inputs);
        //    engine.Run();

        //}

        public class OrderMatchingEngine
        {

            private List<string> inputList;

            private enum OrderType { IOC, GFD }

            private const string BuyOperation = "BUY";
            private const string SellOperation = "SELL";
            private const string CancelOperation = "CANCEL";
            private const string ModifyOperation = "MODIFY";
            private const string PrintOperation = "PRINT";

            private int maximumBuyArrivalOrder = 0;
            private int maximumSellArrivalOrder = 0;

            private class OrderBookItem
            {
                public string orderOperation { get; set; } = "";
                public int orderQuantity { get; set; } = 0;
                public int orderQuantityExhausted { get; set; } = 0;
                public int orderPrice { get; set; } = 0;
                public OrderType orderType { get; set; } = OrderType.IOC;
                public string orderId { get; set; } = "";
                public bool isOrderExhausted { get { return orderQuantity == orderQuantityExhausted; } }
                public int remainingUnexhaustedQuantity { get { return orderQuantity - orderQuantityExhausted; } }
                public int arrivalOrder { get; set; } = 0;
            }

            //The keys here are the orderid
            private Dictionary<string, OrderBookItem> BuyOrderBook_ByOrderId = new Dictionary<string, OrderBookItem>();
            private Dictionary<string, OrderBookItem> SellOrderBook_ByOrderId = new Dictionary<string, OrderBookItem>();

            public OrderMatchingEngine(List<string> input)
            {
                inputList = input;
            }

            public void Run()
            {

                foreach (var inputLine in inputList)
                {
                    string[] lineArray = inputLine.Split(null);

                    //Validate inputs
                    if (IsValidInputLine(inputLine, lineArray)) //If we wanted we could catch these as errors, I'm simply ignoring them if invalid
                    {
                        //Get inputs ready for processing
                        switch (lineArray[0])
                        {
                            case BuyOperation:
                                {
                                    RunBuyOperation(lineArray);
                                    break;
                                }
                            case SellOperation:
                                {
                                    RunSellOperation(lineArray);
                                    break;
                                }
                            case CancelOperation:
                                {
                                    RunCancelOperation(lineArray);
                                    break;
                                }
                            case ModifyOperation:
                                {
                                    RunModifyOperation(lineArray);
                                    break;
                                }
                            case PrintOperation:
                                {
                                    RunPrintOperation();
                                    break;
                                }
                        }
                    }
                }
            }

            private static bool IsValidInputLine(string inputLine, string[] lineArray)
            {

                if (String.IsNullOrEmpty(inputLine))
                    return false;

                if ((lineArray[0] != BuyOperation)
                && (lineArray[0] != SellOperation)
                && (lineArray[0] != CancelOperation)
                && (lineArray[0] != ModifyOperation)
                && (lineArray[0] != PrintOperation))
                    return false;

                if (lineArray[0] == BuyOperation)
                    return IsValidBuySellOperation(lineArray);
                else if (lineArray[0] == SellOperation)
                    return IsValidBuySellOperation(lineArray);
                else if (lineArray[0] == CancelOperation)
                    return IsValidCancelOperation(lineArray);
                else if (lineArray[0] == ModifyOperation)
                    return IsValidModifyOperation(lineArray);

                //Print operation only cares about the "PRINT" line so assume it's true as the rest can be ignored.

                return true;
            }

            private static bool IsNumeric(string input)
            {
                int number;
                return int.TryParse(input, out number);
            }

            private static int GetNumericalValue(string input)
            {
                int number;
                var result = int.TryParse(input, out number);
                return number;
            }

            private static bool IsValidBuySellOperation(string[] lineArray)
            {

                //5 items, order type of IOC or GFD, Price, Quantity, OrderId
                if (lineArray.Length != 5)
                    return false;

                if (lineArray[1] != OrderType.IOC.ToString() && lineArray[1] != OrderType.GFD.ToString())
                    return false;

                if (!IsNumeric(lineArray[2]) || GetNumericalValue(lineArray[2]) <= 0)
                    return false;

                if (!IsNumeric(lineArray[3]) || GetNumericalValue(lineArray[3]) <= 0)
                    return false;

                if (!(lineArray[4].Length > 0))
                    return false;

                return true;
            }

            private static bool IsValidCancelOperation(string[] lineArray)
            {

                //2 items, second is orderid (which can be anything)
                if (lineArray.Length != 2)
                    return false;

                if (!(lineArray[1].Length > 0))
                    return false;

                return true;
            }

            private static bool IsValidModifyOperation(string[] lineArray)
            {

                //5 items, orderid, BUY or SELL, new price (int), new quantity (int)
                if (lineArray.Length != 5)
                    return false;

                if (!(lineArray[1].Length > 0))
                    return false;

                if (!(lineArray[2] == BuyOperation) && !(lineArray[2] == SellOperation))
                    return false;

                if (!IsNumeric(lineArray[3]) || GetNumericalValue(lineArray[3]) <= 0)
                    return false;

                if (!IsNumeric(lineArray[4]) || GetNumericalValue(lineArray[4]) <= 0)
                    return false;

                return true;
            }

            private static OrderType GetOrderTypeFromString(string orderTypeString)
            {
                if (orderTypeString == OrderType.IOC.ToString())
                    return OrderType.IOC;

                if (orderTypeString == OrderType.GFD.ToString())
                    return OrderType.GFD;

                return OrderType.GFD;
            }

            private void RunBuyOperation(string[] inputLine)
            {

                //5 items, order type of IOC or GFD, Price, Quantity, OrderId
                maximumBuyArrivalOrder++;
                var newItem = new OrderBookItem()
                {
                    orderOperation = BuyOperation,
                    orderType = GetOrderTypeFromString(inputLine[1]),
                    orderPrice = Convert.ToInt32(inputLine[2]),
                    orderQuantity = Convert.ToInt32(inputLine[3]),
                    orderId = inputLine[4],
                    arrivalOrder = maximumBuyArrivalOrder
                };

                BuyOrderBook_ByOrderId.Add(newItem.orderId, newItem);

                AttemptBuy(newItem);
            }

            private void RunSellOperation(string[] inputLine)
            {

                //5 items, order type of IOC or GFD, Price, Quantity, OrderId
                maximumSellArrivalOrder++;
                var newItem = new OrderBookItem()
                {
                    orderOperation = SellOperation,
                    orderType = GetOrderTypeFromString(inputLine[1]),
                    orderPrice = Convert.ToInt32(inputLine[2]),
                    orderQuantity = Convert.ToInt32(inputLine[3]),
                    orderId = inputLine[4],
                    arrivalOrder = maximumSellArrivalOrder
                };

                SellOrderBook_ByOrderId.Add(newItem.orderId, newItem);

                AttemptSell(newItem);
            }

            private void AttemptSell(OrderBookItem sellItem)
            {

                //Try to get a match, and if found, print.
                //TRADE order1 1000 10 order2 900 10

                //See if someone is buying for >= the price, if so sell that qty
                //If multiple are selling for >= that price, sell the highest buyer 
                //If not all is sold, look for a second buyer
                //An order is "exhausted" when either all quantity is sold or it's an IOC-type order

                List<string> completedTrades = new List<string>();
                List<OrderBookItem> possibleBuyers = new List<OrderBookItem>();

                //Look for any existing buyers (buying for price > than selling price)
                foreach (var buyItem in BuyOrderBook_ByOrderId.Values)
                {
                    if (buyItem.orderPrice >= sellItem.orderPrice && buyItem.orderType != OrderType.IOC && !buyItem.isOrderExhausted)
                    {
                        //Found a buyer
                        possibleBuyers.Add(buyItem);
                    }
                }

                //If found any valid buyers, sell as much as possible to BEST buyers
                if (possibleBuyers.Count > 0)
                {
                    if (possibleBuyers.Count == 1)
                    {
                        //If only one buyer, sell to that buyer
                        var buyItem = possibleBuyers.FirstOrDefault();
                        int quantitySold = Math.Min(sellItem.remainingUnexhaustedQuantity, buyItem.remainingUnexhaustedQuantity);
                        ExhaustQuantities(sellItem, buyItem, quantitySold);
                        completedTrades.Add($"TRADE {buyItem.orderId} {buyItem.orderPrice} {quantitySold} {sellItem.orderId} {sellItem.orderPrice} {quantitySold}");
                    }
                    else
                    {
                        //If more than one possible buyer, then order them and then keep trying to sell until seller is exhausted or no more buyers.
                        possibleBuyers = possibleBuyers.OrderByDescending(x => x.orderPrice).ThenBy(x => x.arrivalOrder).ToList();

                        var buyersQueue = new Queue<OrderBookItem>(possibleBuyers);

                        while (!sellItem.isOrderExhausted && buyersQueue.Count > 0)
                        {
                            var buyItem = buyersQueue.Dequeue();
                            int quantitySold = Math.Min(sellItem.remainingUnexhaustedQuantity, buyItem.remainingUnexhaustedQuantity);
                            ExhaustQuantities(sellItem, buyItem, quantitySold);
                            completedTrades.Add($"TRADE {buyItem.orderId} {buyItem.orderPrice} {quantitySold} {sellItem.orderId} {sellItem.orderPrice} {quantitySold}");
                        }

                    }
                }

                //Exhaust IOC types "The non-traded part is cancelled"
                if (sellItem.orderType == OrderType.IOC)
                {
                    sellItem.orderQuantityExhausted = sellItem.orderQuantity;
                }

                //Print completed trades
                foreach (string completedTrade in completedTrades)
                {
                    Console.WriteLine(completedTrade);
                }

            }

            private static void ExhaustQuantities(OrderBookItem firstItem, OrderBookItem secondItem, int quantityExhausted)
            {
                firstItem.orderQuantityExhausted += quantityExhausted;
                secondItem.orderQuantityExhausted += quantityExhausted;
            }

            private void AttemptBuy(OrderBookItem buyItem)
            {

                //Try to get a match, and if found, print.
                //TRADE order1 1000 10 order2 900 10

                //See if someone is buying for >= the price, if so sell that qty
                //If multiple are selling for >= that price, sell the highest buyer 
                //If not all is sold, look for a second buyer
                //An order is "exhausted" when either all quantity is sold or it's an IOC-type order

                List<string> completedTrades = new List<string>();
                List<OrderBookItem> possibleSellers = new List<OrderBookItem>();

                //Look for any existing sellers (sellers for price < than buying price)
                foreach (var sellItem in SellOrderBook_ByOrderId.Values)
                {
                    if (sellItem.orderPrice <= buyItem.orderPrice && sellItem.orderType != OrderType.IOC && !sellItem.isOrderExhausted)
                    {
                        //Found a seller
                        possibleSellers.Add(sellItem);
                    }
                }

                //If found any valid sellers, buy as much as possible to BEST sellers
                if (possibleSellers.Count > 0)
                {
                    if (possibleSellers.Count == 1)
                    {
                        //If only one seller, buy from that seller
                        var sellItem = possibleSellers.FirstOrDefault();
                        int quantityBought = Math.Min(sellItem.remainingUnexhaustedQuantity, buyItem.remainingUnexhaustedQuantity);
                        ExhaustQuantities(buyItem, sellItem, quantityBought);
                        completedTrades.Add($"TRADE {sellItem.orderId} {sellItem.orderPrice} {quantityBought} {buyItem.orderId} {buyItem.orderPrice} {quantityBought}");
                    }
                    else
                    {
                        //If more than one possible seller, then order them and then keep trying to buy until buyrt is exhausted or no more sellers.
                        possibleSellers = possibleSellers.OrderBy(x => x.orderPrice).ThenBy(x => x.arrivalOrder).ToList();

                        var sellersQueue = new Queue<OrderBookItem>(possibleSellers);

                        while (!buyItem.isOrderExhausted && sellersQueue.Count > 0)
                        {
                            var sellItem = sellersQueue.Dequeue();
                            int quantityBought = Math.Min(sellItem.remainingUnexhaustedQuantity, buyItem.remainingUnexhaustedQuantity);
                            ExhaustQuantities(sellItem, buyItem, quantityBought);
                            completedTrades.Add($"TRADE {sellItem.orderId} {sellItem.orderPrice} {quantityBought} {buyItem.orderId} {buyItem.orderPrice} {quantityBought}");
                        }

                    }
                }

                //Exhaust IOC types "The non-traded part is cancelled"
                if (buyItem.orderType == OrderType.IOC)
                {
                    buyItem.orderQuantityExhausted = buyItem.orderQuantity;
                }

                //Print completed trades
                foreach (string completedTrade in completedTrades)
                {
                    Console.WriteLine(completedTrade);
                }

            }

            private void RunCancelOperation(string[] inputLine)
            {

                //2 items, second is orderid (which can be anything)
                //If the orderid doesn't exist, do nothing
                var orderId = inputLine[1];

                if (SellOrderBook_ByOrderId.ContainsKey(orderId))
                    SellOrderBook_ByOrderId.Remove(orderId);

                if (BuyOrderBook_ByOrderId.ContainsKey(orderId))
                    BuyOrderBook_ByOrderId.Remove(orderId);
            }

            private void RunModifyOperation(string[] inputLine)
            {

                //5 items, orderid, BUY or SELL, new price (int), new quantity (int)        
                string orderId = inputLine[1];

                if (SellOrderBook_ByOrderId.ContainsKey(orderId))
                {
                    ModifySellOrder(orderId, inputLine);
                }
                else if (BuyOrderBook_ByOrderId.ContainsKey(orderId))
                {
                    ModifyBuyOrder(orderId, inputLine);
                }

                //If OrderID doesn't exist, then do nothing             

            }


            private void ModifySellOrder(string orderId, string[] inputLine)
            {
                //5 items, orderid, BUY or SELL, new price (int), new quantity (int) 
                //Cannot Modift IOC type     
                string newOrderOperation = inputLine[2];
                int newPrice = Convert.ToInt32(inputLine[3]);
                int newQuantity = Convert.ToInt32(inputLine[4]);

                //If existing order was a Sell order
                if (SellOrderBook_ByOrderId.ContainsKey(orderId) && SellOrderBook_ByOrderId[orderId].orderType != OrderType.IOC)
                {
                    var modifiedItem = new OrderBookItem()
                    {
                        orderOperation = newOrderOperation,
                        orderType = SellOrderBook_ByOrderId[orderId].orderType,
                        orderPrice = newPrice,
                        orderQuantity = newQuantity,
                        orderId = orderId
                    };

                    if (modifiedItem.orderOperation == BuyOperation)
                    {
                        //Shift order from SELL to BUY
                        SellOrderBook_ByOrderId.Remove(orderId);
                        maximumBuyArrivalOrder++;
                        modifiedItem.arrivalOrder = maximumBuyArrivalOrder;
                        BuyOrderBook_ByOrderId.Add(orderId, modifiedItem);
                        AttemptBuy(modifiedItem);
                    }
                    else
                    {
                        //Same operation, shift item to end of the list.
                        SellOrderBook_ByOrderId.Remove(orderId);
                        maximumSellArrivalOrder++;
                        modifiedItem.arrivalOrder = maximumSellArrivalOrder;
                        SellOrderBook_ByOrderId.Add(orderId, modifiedItem);
                        AttemptSell(modifiedItem);
                    }
                }
            }

            private void ModifyBuyOrder(string orderId, string[] inputLine)
            {
                //5 items, orderid, BUY or SELL, new price (int), new quantity (int) 
                //Cannot Modift IOC type     
                string newOrderOperation = inputLine[2];
                int newPrice = Convert.ToInt32(inputLine[3]);
                int newQuantity = Convert.ToInt32(inputLine[4]);

                //If existing order was a Buy order
                if (BuyOrderBook_ByOrderId.ContainsKey(orderId) && BuyOrderBook_ByOrderId[orderId].orderType != OrderType.IOC)
                {
                    var modifiedItem = new OrderBookItem()
                    {
                        orderOperation = newOrderOperation,
                        orderType = BuyOrderBook_ByOrderId[orderId].orderType,
                        orderPrice = newPrice,
                        orderQuantity = newQuantity,
                        orderId = orderId
                    };

                    if (modifiedItem.orderOperation == SellOperation)
                    {
                        //Shift order from BUY to SELL
                        BuyOrderBook_ByOrderId.Remove(orderId);
                        maximumSellArrivalOrder++;
                        modifiedItem.arrivalOrder = maximumSellArrivalOrder;
                        SellOrderBook_ByOrderId.Add(orderId, modifiedItem);
                        AttemptSell(modifiedItem);
                    }
                    else
                    {
                        //Same operation, shift item to end of the list.
                        BuyOrderBook_ByOrderId.Remove(orderId);
                        maximumBuyArrivalOrder++;
                        modifiedItem.arrivalOrder = maximumBuyArrivalOrder;
                        BuyOrderBook_ByOrderId.Add(orderId, modifiedItem);
                        AttemptBuy(modifiedItem);
                    }
                }
            }

            private void RunPrintOperation()
            {

                //SELL:
                //price1 qty1
                //price2 qty2
                //BUY: 
                //price1 qty1
                //price2 qty2

                //Show the sum of all order quantities at a given price
                //Should be in decreasing order
                SortedDictionary<int, int> BuyPriceQuantityDictionary = new SortedDictionary<int, int>();
                SortedDictionary<int, int> SellPriceQuantityDictionary = new SortedDictionary<int, int>();

                //Add up sell quantity totals by price
                foreach (var item in SellOrderBook_ByOrderId.Values)
                {
                    if (!item.isOrderExhausted) //Based on Example 4-5 you should onlt count the non-exhausted quantities here
                    {
                        int printQuantity = item.orderQuantity - item.orderQuantityExhausted;

                        if (SellPriceQuantityDictionary.ContainsKey(item.orderPrice))
                        {
                            SellPriceQuantityDictionary[item.orderPrice] += printQuantity;
                        }
                        else
                        {
                            SellPriceQuantityDictionary.Add(item.orderPrice, printQuantity);
                        }
                    }
                }

                //Add up buy quantity totals by price
                foreach (var item in BuyOrderBook_ByOrderId.Values)
                {
                    if (!item.isOrderExhausted) //Based on Example 4 you should only count the non-exhausted quantities here
                    {
                        int printQuantity = item.orderQuantity - item.orderQuantityExhausted;

                        if (BuyPriceQuantityDictionary.ContainsKey(item.orderPrice))
                        {
                            BuyPriceQuantityDictionary[item.orderPrice] += printQuantity;
                        }
                        else
                        {
                            BuyPriceQuantityDictionary.Add(item.orderPrice, printQuantity);
                        }
                    }
                }

                Console.WriteLine("SELL:");

                foreach (KeyValuePair<int, int> keyValuePair in SellPriceQuantityDictionary.OrderByDescending(x => x.Key))
                {
                    Console.WriteLine($"{keyValuePair.Key} {keyValuePair.Value}");
                }

                Console.WriteLine("BUY:");

                foreach (KeyValuePair<int, int> keyValuePair in BuyPriceQuantityDictionary.OrderByDescending(x => x.Key))
                {
                    Console.WriteLine($"{keyValuePair.Key} {keyValuePair.Value}");
                }

            }

        }

}
