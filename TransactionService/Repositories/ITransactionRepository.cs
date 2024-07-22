using TransactionService.Models;

namespace TransactionService.Repositories
{
    public interface ITransactionRepository
    {
        Task<bool> AddTransactionAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetTransactionsAsync(DateTime date);
    }
}
