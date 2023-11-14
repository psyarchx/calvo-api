using Microsoft.EntityFrameworkCore;
using Calvo.Domain.Entities;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Calvo.Domain.Interfaces.Repositories
{
    public interface IRepositoryContext
    {
        DbContext MainContext { get; }
        DbTransaction Transaction { get; }
        void Commit();
        void Rollback();
        IQueryable<T> ReturnAll<T>() where T : BaseEntity;
        T FindById<T>(long id) where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
        void Add<T>(IEnumerable<T> entity) where T : BaseEntity;
        T Update<T>(T entity) where T : BaseEntity;
        T Remove<T>(T entity) where T : BaseEntity;
        void Save();
    }
}
