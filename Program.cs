
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


    public static bool AddProduct(
        Inventory inventory,
        string name,
        decimal price,
        int quantity)
    {
        return inventory.Add(new Product(name, price, quantity));
    }


    public static void DeleteProduct(Inventory inventory, string name)
    {
        bool deleted = inventory.Delete(name);

        if (deleted)
            Console.WriteLine("Product Deleted Successfully.");
        else
            Console.WriteLine("Product Not Found.");
    }


    public static void EditProduct(
        Inventory inventory,
        string name,
        decimal price,
        int quantity,
        string oldName)
    {
        Product updatedProduct = new(name, price, quantity);

        EditResult result = inventory.Edit(updatedProduct, oldName);

        switch (result)
        {
            case EditResult.Success:
                Console.WriteLine("Product Edited Successfully.");
                break;

            case EditResult.DuplicateName:
                Console.WriteLine("A Product With This Name Already Exists.");
                break;

            case EditResult.NotFound:
                Console.WriteLine("Product Not Found.");
                break;
        }
    }


    public static void ViewAllProducts(Inventory inventory)
    {
        List<Product> products = inventory.ViewAll();

        if (products.Count == 0)
        {
            Console.WriteLine("Inventory Is Empty.");
            return;
        }

        Console.WriteLine("All Products:");

        foreach (Product product in products)
        {
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: {product.Price}");
            Console.WriteLine($"Quantity: {product.Quantity}");
            Console.WriteLine("----------------------");
        }
    }


    public static void FindProduct(Inventory inventory, string name)
    {
        Product? product = inventory.Search(name);

        if (product is null)
        {
            Console.WriteLine("Product Not Found.");
            return;
        }

        Console.WriteLine("Product Found:");
        Console.WriteLine($"Name: {product.Name}");
        Console.WriteLine($"Price: {product.Price}");
        Console.WriteLine($"Quantity: {product.Quantity}");
    }
}
