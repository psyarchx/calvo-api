using System.Data.Common;

namespace Calvo.Domain.Interfaces.Repositories
{
    public interface ITransactionContext
    {
        ITransactionContext BeginTransaction();

        void UseTransaction(DbTransaction transaction);

    }
}