using System;
using Moq;
using TestinApp.Functionality;
using Xunit;

namespace TestinApp.Test;


// public class DbServiceMock : IDbService
// {
//     public bool ProcessResult { get; set; }

//     public Product ProductBeingProcessed { get; set; }

//     public int ProductIdBeingProcessed { get; set; }

//     public bool RemoveItemFromShoppingCart(int? prodId)
//     {
//         if(prodId == null) 
//             return false;

        
//         ProductIdBeingProcessed = Convert.ToInt32(prodId);
//         return ProcessResult;
//     }

//     public bool SaveItemToShoppingCart(Product? prod)
//     {
//         if(prod == null)
//             return false;
        
//         ProductBeingProcessed = prod;
//         return ProcessResult;
//     }
// }

public class ShoppingCartTest
{
    public readonly Mock<IDbService> _dbServiceMock = new();
    

    [Fact]
    public void AddProduct_Success()
    {
        // Given

        var shoppingCart = new ShoppingCart(_dbServiceMock.Object);

            // var dbMock = new DbServiceMock();
            // dbMock.ProcessResult = true;

            // var shoppingCart = new ShoppingCart(dbMock);

        // When

        var product = new Product(1, "shoes", 150);
        var result = shoppingCart.AddProduct(product);

        // Assert

        Assert.True(result);
        _dbServiceMock.Verify(x => x.SaveItemToShoppingCart( It.IsAny<Product>()), Times.Once);
            // Assert.Equal(result,dbMock.ProcessResult);
            // Assert.Equal("shoes", dbMock.ProductBeingProcessed.Name);
    }

    [Fact]
    public void AddProduct_Failure_DueToInvalidPayload()
    {
        // Given

        var shoppingCart = new ShoppingCart(_dbServiceMock.Object);

            // var dbMock = new DbServiceMock();
            // dbMock.ProcessResult = false;

            // var shoppingCart = new ShoppingCart(dbMock);

        // When
        var result = shoppingCart.AddProduct(null);

        // Then
        Assert.False(result);
        _dbServiceMock.Verify(x => x.SaveItemToShoppingCart( It.IsAny<Product>()), Times.Never);
            // Assert.Equal(result, dbMock.ProcessResult);
    }

    [Fact]
    public void RemoveProduct_Success()
    {
        // Given

        var shoppingCart = new ShoppingCart(_dbServiceMock.Object);

            // var dbMock = new DbServiceMock();
            // dbMock.ProcessResult = true;

            // var shoppingCart = new ShoppingCart(dbMock);

        // When

        var product = new Product(1, "shoes", 150);
        var result = shoppingCart.AddProduct(product);

        var deleteResult = shoppingCart.DeleteProduct(product.Id);

        // Then

        Assert.True(deleteResult);
        _dbServiceMock.Verify(x => x.SaveItemToShoppingCart( It.IsAny<Product>()), Times.Once);
            // Assert.Equal(deleteResult, dbMock.ProcessResult);
    }
}