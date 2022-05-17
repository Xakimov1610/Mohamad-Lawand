namespace TestinApp.Functionality;

public record Product(int Id, string Name, double price);

public interface IDbService
{
    bool SaveItemToShoppingCart(Product? prod);

    bool RemoveItemFromShoppingCart(int? prodId);
}

public class ShoppingCart
{
    private IDbService _dbService;

    public ShoppingCart(IDbService dbService)
    {
        _dbService = dbService;
    }
    // Service.AddSingelton(IDService, DbService);

    public bool AddProduct(Product? product)
    {
        if (product == null)
            return false;

        if (product.Id == 0)
            return false;
        
        _dbService.SaveItemToShoppingCart(product);
        return true;
    }

    public bool DeleteProduct(int? id)
    {
        if(id == null) return false;

        if(id == 0) return false;

        _dbService.RemoveItemFromShoppingCart(id);
        return true;
    }
}