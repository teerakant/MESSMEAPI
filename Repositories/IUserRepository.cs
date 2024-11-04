using MessmeApi.Models;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUserById(long id);
    Task AddUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(int id);
}
