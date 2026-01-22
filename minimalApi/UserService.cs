using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimalApi
{
    public class UserService(IUserRepository _userRepository)
    {

        public bool NewUserRegistered(string username, string password)
        {
            _userRepository.AddUser(new User {Name = username});
            return true;
        }
    }
}

public interface IUserRepository
{
    void AddUser(User user);
}

public class UserRepository : IUserRepository
{
    public void AddUser(User user)
    {
    }
}