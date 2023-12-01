namespace AlmaaTest;

//Interface
public interface IDatabase
{
    void AddUser(User user);
    void RemoveUser(int userId);
    User GetUser(int userId);
}
