using Calvo.Domain.Entities.General;
using Calvo.Domain.Interfaces.Repositories.General;
using Calvo.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Calvo.Infrastructure.Data.Repositories.General
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MainDbContext context) : base(context) { }

        public List<User> GetAllUsers()
        {
            return ReturnAll()
                .OrderBy(x => x.Id)
                .ToList();
        }

        public User GetUserById(long id)
        {
            return FindById(id);
        }

        public User CreateUser(User user)
        {
            Add(user);
            Save();
            return user;
        }

        public User UpdateUser(User user)
        {
            Update(user);
            Save();
            return user;
        }

        public void CreateUserList(List<User> list)
        {
            Add(list);
            Save();
        }

        public User DeleteUser(User user)
        {
            Remove(user);
            Save();
            return user;
        }
    }
}

