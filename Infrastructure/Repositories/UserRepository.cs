using Application.Abstraction;
using Domain.Entities;
using Microsoft.Win32;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> mockUser = new List<User>
            {
               new User { Email = "email1@example.com", Password = "senha1" },
               new User { Email = "email2@example.com", Password = "senha2" },
               new User { Email = "email3@example.com", Password = "senha3" },
               new User { Email = "email4@example.com", Password = "senha4" },
               new User { Email = "email5@example.com", Password = "senha5" }
            };
        public async Task<User> CreateUser(User user)
        {
            var result = await GetUser(user.Email);
            if (result is not null) return null;
            mockUser.Add(user);
            return user;
        }

        public async Task<User> DeleteUser(string user)
        {
            var result = await GetUser(user);
            if (result is null) return null;
            mockUser.Remove(result);
            return result;

        }

        public async Task<User> GetUser(string user)
        {
            var result = mockUser.Where(x => x.Email == user).FirstOrDefault();
            if (result is null) return null;
            return result;
        }

        public async Task<List<User>> GetUsers()
        {
            return mockUser;
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await GetUser(user.Email);
            if (result is null) return null;
            result.Email = user.Email;
            result.Password = user.Password;
            return result;
        }
    }
}
