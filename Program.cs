
namespace Inventory_Management_System;

class Program
{
    static void Main(string[] args)
    {
        Inventory inventory = new();

        while (true)
        {
            DisplayMenu();

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) ||
                   choice < 1 || choice > 6)
            {
                Console.WriteLine("Please Enter Number Between 1 - 6:");
            }

            switch (choice)
            {
                case 1:
                    {
                        string name;

                        while (true)
                        {
                            Console.WriteLine("Please Enter Product Name:");
                            name = (Console.ReadLine() ?? string.Empty).Trim();

                            if (!string.IsNullOrWhiteSpace(name))
                                break;

                            Console.WriteLine("Invalid name. Try again.");
                        }

                        decimal price;

                        while (true)
                        {
                            Console.WriteLine("Please Enter Product Price:");

                            if (decimal.TryParse(Console.ReadLine(), out price)
                                && price > 0)
                                break;

                            Console.WriteLine("Invalid price. Try again.");
                        }

                        int quantity;

                        while (true)
                        {
                            Console.WriteLine("Please Enter Product Quantity:");

                            if (int.TryParse(Console.ReadLine(), out quantity)
                                && quantity >= 0)
                                break;

                            Console.WriteLine("Invalid quantity. Try again.");
                        }

                        if (AddProduct(inventory, name, price, quantity))
                            Console.WriteLine("Product Added Successfully.");
                        else
                            Console.WriteLine("Product Already Exists.");

                        break;
                    }

                case 2:
                    {
                        ViewAllProducts(inventory);
                        break;
                    }

                case 3:
                    {
                        string oldName;

                        while (true)
                        {
                            Console.WriteLine("Please Enter Product Name You Want To Edit:");
                            oldName = (Console.ReadLine() ?? string.Empty).Trim();

                            if (!string.IsNullOrWhiteSpace(oldName))
                                break;

                            Console.WriteLine("Invalid name. Try again.");
                        }

                        string newName;

                        while (true)
                        {
                            Console.WriteLine("Please Enter New Product Name:");
                            newName = (Console.ReadLine() ?? string.Empty).Trim();

                            if (!string.IsNullOrWhiteSpace(newName))
                                break;

                            Console.WriteLine("Invalid name. Try again.");
                        }

                        decimal price;

                        while (true)
                        {
                            Console.WriteLine("Please Enter New Product Price:");

                            if (decimal.TryParse(Console.ReadLine(), out price)
                                && price > 0)
                                break;

                            Console.WriteLine("Invalid price. Try again.");
                        }

                        int quantity;

                        while (true)
                        {
                            Console.WriteLine("Please Enter New Product Quantity:");

                            if (int.TryParse(Console.ReadLine(), out quantity)
                                && quantity >= 0)
                                break;

                            Console.WriteLine("Invalid quantity. Try again.");
                        }

                        EditProduct(inventory, newName, price, quantity, oldName);
                        break;
                    }

                case 4:
                    {
                        string name;

                        while (true)
                        {
                            Console.WriteLine("Please Enter Product Name:");
                            name = (Console.ReadLine() ?? string.Empty).Trim();

                            if (!string.IsNullOrWhiteSpace(name))
                                break;

                            Console.WriteLine("Invalid name. Try again.");
                        }

                        DeleteProduct(inventory, name);
                        break;
                    }

                case 5:
                    {
                        string name;

                        while (true)
                        {
                            Console.WriteLine("Please Enter Product Name:");
                            name = (Console.ReadLine() ?? string.Empty).Trim();

                            if (!string.IsNullOrWhiteSpace(name))
                                break;

                            Console.WriteLine("Invalid name. Try again.");
                        }

                        FindProduct(inventory, name);
                        break;
                    }

                case 6:
                    {
                        Console.WriteLine("Exiting...");
                        return;
                    }
            }

            Console.WriteLine();
        }
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("Please Choose Your Operation:");
        Console.WriteLine("1. Add a product.");
        Console.WriteLine("2. View all products.");
        Console.WriteLine("3. Edit a product.");
        Console.WriteLine("4. Delete a product.");
        Console.WriteLine("5. Search for a product.");
        Console.WriteLine("6. Exit.");
    }


}
