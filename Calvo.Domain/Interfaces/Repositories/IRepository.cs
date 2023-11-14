using Microsoft.EntityFrameworkCore;
using Calvo.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Calvo.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbContext MainDbContext { get; }
        IQueryable<T> ReturnAll();
        T FindById(long id);
        T Add(T entity);
        void Add(IEnumerable<T> entity);
        T Update(T entity);
        T Remove(T entity);
        void Save();
    }
}
