using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Calvo.Application.Interfaces
{
    public interface ITransactionContext : IDisposable
    {
        DbContext MainContext { get; }
        DbTransaction Transaction { get; }
        void Commit();
        void Rollback();
    }
}
