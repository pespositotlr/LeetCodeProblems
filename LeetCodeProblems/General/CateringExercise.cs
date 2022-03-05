using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace LeetCodeProblems.General
{
    //Catering Exercise

    //Marie and Diane are considering hosting a graduation party.They are going to cater the event from “Food for Thought Cafe."
    //They like a variety of foods, so no item should be ordered more than once.
    //Their budget is $300 and want to make sure they have exactly 5 appetizers and 5 desserts, and as many entrees as they can afford.

    //Using a language in our technical stack, write an app or script that will download the menu directly from https://www.olo.com/menu.json and generate the expected output:
    //An integer indicating the total number of menu items (appetizers, entrees, and desserts) they can order.
    //The menu items and their respective prices to order. The list should be grouped by food type and sorted by price in increasing order. Please output food types in the following order: appetizers, entrees, desserts.

    class CateringExercise
    {
        private List<MenuItem> restaurantAppetizers;
        private List<MenuItem> restaurantEntrees;
        private List<MenuItem> restaurantDesserts;

        private List<MenuItem> selectedAppetizers;
        private List<MenuItem> selectedEntrees;
        private List<MenuItem> selectedDesserts;

        const double budget = 300;

        public async Task CateringExercise_Main()
        {
            RestaurantMenu menu = await GetRestaurantMenu();

            restaurantAppetizers = menu.MenuItems.Where(x => x.FoodType == "appetizer").OrderBy(y => y.Price).ToList();
            restaurantEntrees = menu.MenuItems.Where(x => x.FoodType == "entree").OrderBy(y => y.Price).ToList();
            restaurantDesserts = menu.MenuItems.Where(x => x.FoodType == "dessert").OrderBy(y => y.Price).ToList();

            selectedAppetizers = restaurantAppetizers.Take(5).ToList();
            selectedDesserts = restaurantDesserts.Take(5).ToList();
            selectedEntrees = new List<MenuItem>();

            double amountSpentBeforeEntrees = selectedAppetizers.Sum(x => x.Price);
            amountSpentBeforeEntrees += selectedDesserts.Sum(x => x.Price);

            if (amountSpentBeforeEntrees < budget)
            {
                SetEntreesByBudget(budget - amountSpentBeforeEntrees);
            }

            OutputMenuSelections();

        }

        private void SetEntreesByBudget(double remainingBudget)
        {
            selectedEntrees = new List<MenuItem>();

            foreach (MenuItem item in restaurantEntrees)
            {
                if (item.Price <= remainingBudget)
                {
                    selectedEntrees.Add(item);
                    remainingBudget -= item.Price;
                }
                else
                {
                    return;
                }
            }
        }

        private void OutputMenuSelections()
        {
            if (selectedAppetizers.Count > 0)
            {
                Console.WriteLine($"#####Appetizers: ({selectedAppetizers.Count} items)");
                PrintMenuItems(selectedAppetizers);
            }

            if (selectedEntrees.Count > 0)
            {
                Console.WriteLine($"###Entrees: ({selectedEntrees.Count} items)");
                PrintMenuItems(selectedEntrees);
            }

            if (selectedDesserts.Count > 0)
            {
                Console.WriteLine($"###Desserts: ({selectedDesserts.Count} items)");
                PrintMenuItems(selectedDesserts);
            }
        }

        private void PrintMenuItems(List<MenuItem> items)
        {
            foreach (MenuItem item in items)
            {
                Console.WriteLine($"===Name: {item.Name}");
                Console.WriteLine($"===Price: ${string.Format("{0:N2}", item.Price)}");
                Console.WriteLine("-----------------");
            }
        }

        public async Task<RestaurantMenu> GetRestaurantMenu()
        {
            string requestUrl = "https://www.olo.com/menu.json";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(requestUrl);
                    if (response != null)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<RestaurantMenu>(jsonString);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }
    }

    public class RestaurantMenu
    {
        public string Restaurant;
        public List<MenuItem> MenuItems;
    }
    public class MenuItem
    {
        public string FoodType;
        public string Name;
        public double Price;
    }
}
