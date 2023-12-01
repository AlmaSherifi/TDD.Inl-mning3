namespace AlmaaTest;

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
