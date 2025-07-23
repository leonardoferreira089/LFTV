using Xunit;
using LFTV.Application.Services;
using LFTV.Application.DTOs;

public class UserServiceTests
{
    [Fact]
    public void CreateUser_Should_ThrowException_When_Email_Is_Invalid()
    {
        // Arrange
        var service = new UserService(...); // Ajoute les dépendances nécessaires
        var dto = new CreateUserDto
        {
            Email = "invalid-email",
            UserName = "testuser",
            Password = "password123"
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => service.CreateUser(dto));
    }
}