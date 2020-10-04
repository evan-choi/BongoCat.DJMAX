using System.Collections.Generic;
using System.Linq;

namespace BongoCat.DJMAX.Setting.Data
{
    internal sealed class TransactionGroup : ITransaction
    {
        public bool IsChanged => _transactions.Any(b => b.IsChanged);

        private readonly ITransaction[] _transactions;

        public TransactionGroup(IEnumerable<ITransaction> transactions) : this(transactions.ToArray())
        {
        }

        public TransactionGroup(params ITransaction[] transactions)
        {
            _transactions = transactions;
        }

        public void Rollback()
        {
            foreach (var transaction in _transactions)
            {
                transaction.Rollback();
            }
        }

        public void Commit()
        {
            foreach (var transaction in _transactions)
            {
                transaction.Commit();
            }
        }
    }
}
