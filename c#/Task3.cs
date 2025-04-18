using System;
using System.Collections.Generic;

class Task3
{
    static void Main()
    {
        List<string> items = new List<string>();
        string input = "";

        Console.WriteLine("Welcome to the List Manager!");
        
        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add item");
            Console.WriteLine("2. Remove item");
            Console.WriteLine("3. Display items");
            Console.WriteLine("4. Exit");

            input = Console.ReadLine().Trim();

            switch (input)
            {
                case "1":
                    Console.Write("Enter item to add: ");
                    string newItem = Console.ReadLine().Trim();
                    items.Add(newItem);
                    Console.WriteLine($"'{newItem}' added.");
                    break;

                case "2":
                    Console.Write("Enter item to remove: ");
                    string itemToRemove = Console.ReadLine().Trim();

                    if (items.Remove(itemToRemove))
                        Console.WriteLine($"'{itemToRemove}' removed.");
                    else
                        Console.WriteLine($"'{itemToRemove}' not found.");
                    break;

                case "3":
                    Console.WriteLine("\nCurrent items:");
                    if (items.Count == 0)
                    {
                        Console.WriteLine("No items in the list.");
                    }
                    else
                    {
                        for (int i = 0; i < items.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {items[i].ToUpper()}"); // Example of ToUpper()
                        }
                    }
                    break;

                case "4":
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please enter 1, 2, 3, or 4.");
                    break;
            }
        }
    }
}
