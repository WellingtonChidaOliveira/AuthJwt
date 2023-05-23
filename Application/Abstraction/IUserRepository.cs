using Domain.Entities;

namespace Application.Abstraction
{
    public interface IUserRepository
    {
        Task<User> GetUser(string username);

        Task<List<User>> GetUsers();    

        Task<User> CreateUser(User user);

        Task<User> UpdateUser(User user);

        Task<User> DeleteUser(string username);

    }
}
