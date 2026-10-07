
namespace Inventory_Management_System;

public enum EditResult
{
    Success,
    NotFound,
    DuplicateName
}

public class Inventory
{
    private List<Product> productsList = new List<Product>();


    public bool IsInInventory(string name)
    {
        return productsList.Exists(
            p => p.Name.Equals(
                name,
                StringComparison.OrdinalIgnoreCase
            )
        );
    }


    public bool Add(Product product)
    {
        if (IsInInventory(product.Name))
            return false;

        productsList.Add(product);
        return true;
    }


    public bool Delete(string name)
    {
        int removed = productsList.RemoveAll(
            p => p.Name.Equals(
                name,
                StringComparison.OrdinalIgnoreCase
            )
        );

        return removed > 0;
    }


    public EditResult Edit(Product product, string name)
    {
        var existingProduct = Search(name);

        if (existingProduct is null)
            return EditResult.NotFound;


        bool nameChanged = !name.Equals(
            product.Name,
            StringComparison.OrdinalIgnoreCase
        );


        if (nameChanged && IsInInventory(product.Name))
            return EditResult.DuplicateName;


        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Quantity = product.Quantity;

        return EditResult.Success;
    }


    public List<Product> ViewAll()
    {
        return [.. productsList];
    }


    public Product? Search(string name)
    {
        return productsList.Find(
            p => p.Name.Equals(
                name,
                StringComparison.OrdinalIgnoreCase
            )
        );
    }
}
