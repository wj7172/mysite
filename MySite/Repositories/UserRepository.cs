using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySite.Repositories
{
    public class UserRepository
    {
        private static User[] usersForTest = new[] {
            new User{ ID = 1, Name = "bob", Password = "bob", Roles = new []{"employee"}},
            new User{ ID = 2, Name = "tom", Password = "tom", Roles = new []{"manager"}},
            new User{ ID = 3, Name = "admin", Password = "admin", Roles = new[]{"admin"}},
        };

        public bool ValidateUser(string userName, string password)
        {
            return usersForTest
                .Any(u => u.Name == userName && u.Password == password);
        }

        public string[] GetRoles(string userName)
        {
            return usersForTest
                .Where(u => u.Name == userName)
                .Select(u => u.Roles)
                .FirstOrDefault();
        }

        public User GetByNameAndPassword(string name, string password)
        {
            return usersForTest
                .FirstOrDefault(u => u.Name == name && u.Password == password);
        }
    }
}