using Application.Abstraction;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteUser(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
