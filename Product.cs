namespace Inventory_Management_System;

public class Product
{

    private string _name = string.Empty;
    private decimal _price;
    private int _quantity;

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Invalid name");
            _name = value;
        }
    }


    public decimal Price
    {
        get
        {
            return _price;
        }
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Price must be greater than 0");
            _price = value;
        }
    }


    public int Quantity
    {
        get
        {
            return _quantity;
        }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Quantity can't be negative");

            _quantity = value;
        }
    }


    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }


}