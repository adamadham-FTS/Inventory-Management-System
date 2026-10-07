
public class Products
{

    private string _name;
    private double _price;
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


    public double Price
    {
        get
        {
            return _price;
        }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Price must be greater than 0");
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
                throw new ArgumentException("quantity cant be negative");

            _quantity = value;
        }
    }


    public Products(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }


}