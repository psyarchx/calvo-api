using Calvo.Domain.Entities.General;
using System.Collections.Generic;

namespace Calvo.Domain.Interfaces.Repositories.General
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(long id);
        User CreateUser(User user);
        User UpdateUser(User user);
        void CreateUserList(List<User> list);
        User DeleteUser(User user);
    }
}
