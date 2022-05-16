using System.Linq;
using TestinApp.Functionality;
using Xunit;


namespace TestinApp.Test;

public class UserManagementTestin
{
    [Fact]
    public void Add_CreateUser()
    {
        // Arrange
        var userManagement = new UserManagement();

        // Act
        userManagement.Add(new("Nosirbek","Xakimov"));

        // Assert
        var savedUser = Assert.Single(userManagement.AllUsers);
        Assert.NotNull(savedUser); // checking that the usermanagement list is not empty
        Assert.Equal("Nosirbek", savedUser.firstName);
        Assert.Equal("Xakimov", savedUser.LastName);
        Assert.False(savedUser.VerifiedEmail);
    }

    [Fact]
    public void Update_UpdateMobileNumber()
    {
        // Arrange
        var userManagement = new UserManagement();

        // Act
        userManagement.Add(new("Nosirbek", "Xakimov"));

        var firstUser = userManagement.AllUsers.First();
        firstUser.Phone = "+998901203949";

        userManagement.UpdatePhone(firstUser);

        // Assert
        var savedUser = Assert.Single(userManagement.AllUsers);
        Assert.NotNull(savedUser);
        Assert.Equal("+998901203949", savedUser.Phone);
        
    }
}