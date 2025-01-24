namespace Mission3;

public static class Program
{
    static List<FoodItem> inventory = new List<FoodItem>();

    public static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nFood Bank Inventory System");
            Console.WriteLine("1. Add Food Item");
            Console.WriteLine("2. Delete Food Item");
            Console.WriteLine("3. Print List of Current Food Items");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AddFoodItem();
                        break;
                    case 2:
                        DeleteFoodItem();
                        break;
                    case 3:
                        PrintInventory();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void AddFoodItem()
    {
        Console.WriteLine("\nAdding a new food item:");
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter category: ");
        string category = Console.ReadLine();

        int quantity;
        DateTime expirationDate;
        if (GetQuantity(out quantity) && GetExpirationDate(out expirationDate))
        {
            inventory.Add(new FoodItem(name, category, quantity, expirationDate));
            Console.WriteLine("Food item added successfully!");
        }
    }

    static void DeleteFoodItem()
    {
        // Implement deletion logic here (e.g., delete by name or index)
        Console.WriteLine("Deleting a food item:");
        Console.Write("Enter the name of the item to delete: ");
        string nameToDelete = Console.ReadLine();

        // Find the item in the list by name
        FoodItem itemToRemove = inventory.Find(item => item.Name == nameToDelete);

        if (itemToRemove != null)
        {
            inventory.Remove(itemToRemove);
            Console.WriteLine("Food item deleted successfully!");
        }
        else
        {
            Console.WriteLine("Food item not found.");
        }
    }

    static void PrintInventory()
    {
        Console.WriteLine("\nCurrent Food Inventory:");
        if (inventory.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        foreach (var item in inventory)
        {
            Console.WriteLine($"- {item.Name} ({item.Category}), Quantity: {item.Quantity}, Expires: {item.ExpirationDate.ToShortDateString()}");
        }
    }

    static bool GetQuantity(out int quantity)
    {
        Console.Write("Enter quantity: ");
        if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 0)
        {
            return true;
        }
        else
        {
            Console.WriteLine("Invalid quantity. Please enter a non-negative number.");
            quantity = 0; // Assign a default value
            return false;
        }
    }

    static bool GetExpirationDate(out DateTime expirationDate)
    {
        Console.Write("Enter expiration date (YYYY-MM-DD): ");
        if (DateTime.TryParse(Console.ReadLine(), out expirationDate))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Invalid date format. Please use YYYY-MM-DD.");
            expirationDate = DateTime.MinValue; // Assign a default value
            return false;
        }
    }
}