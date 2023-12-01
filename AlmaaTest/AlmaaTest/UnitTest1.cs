using System;
using Moq;
using NUnit.Framework;


namespace AlmaaTest;

//Interface
public interface IDatabase
{
    void AddUser(User user);
    void RemoveUser(int userId);
    User GetUser(int userId);
}

public class User //user-class
{
    public int UserId { get; set; }
    public string ?Username { get; set; }
}

public class UserManager
{
    private readonly IDatabase _database;

    public UserManager(IDatabase database)
    {
        _database = database ?? throw new ArgumentNullException(nameof(database));
    }

    public void AddUser(User user)
    {
        _database.AddUser(user);
    }

    public void RemoveUser(int userId)
    {
        _database.RemoveUser(userId);
    }

    public User GetUser(int userId)
    {
        return _database.GetUser(userId);
    }
}


[TestFixture]
public class UserManagerTests
{
    [Test] //test for method 1
    public void AddUser()
    {
        //Arrange
        var mockDatabase = new Mock<IDatabase>();
        var userManager = new UserManager(mockDatabase.Object);
        var user = new User { UserId = 1, Username = "TestUser" };

        //Act
        userManager.AddUser(user);

        //Assert
        mockDatabase.Verify(db => db.AddUser(user), Times.Once);

    }

    [Test] //test for method 2
    public void RemoveUser()
    {
        // Arrange
        var mockDatabase = new Mock<IDatabase>();
        var userManager = new UserManager(mockDatabase.Object);
        var userId = 1;

        // Act
        userManager.RemoveUser(userId);

        // Assert
        mockDatabase.Verify(db => db.RemoveUser(userId), Times.Once);
    }


    [Test] //test for method 3
    public void GetUser()
    {
        // Arrange
        var mockDatabase = new Mock<IDatabase>();
        var userManager = new UserManager(mockDatabase.Object);
        var userId = 1;

        // Act
        userManager.GetUser(userId);

        // Assert
        mockDatabase.Verify(db => db.GetUser(userId), Times.Once);
    }

}
